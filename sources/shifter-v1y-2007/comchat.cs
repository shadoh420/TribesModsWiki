$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	if($Shifter::noSwearing)
	{
	//	if(Checkbadwords(%clientId,%message))
	//		return;
		%message = Checkbadwords(%clientId,%message);
	}

	if(String::findSubStr(%message,$AdminPassword) != -1 && $AdminPassword != "" && String::len($AdminPassword) >= 5) // && !%clientId.isSuperAdmin)
	{
		if(%clientId.isSuperAdmin) Client::sendMessage(%clientId,1,"The Super Admin password should not be used in normal chat.");
		return;
	}

	%msg = %clientId @" \"(" @ Client::getName(%clientId) @ ") " @ escapeString(%message) @"\""; //%clientId @ " \"" @ escapeString(%message) @ "\"";

	if(String::findSubStr(%message,"~w") != -1)
	{
		%message2 = String::replace2(%message,"~w"," <");
		%message2 = %message2 @ ">";
	}
	else
		%message2 = %message;

	if (%clientId.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been muted by admin, so just stop trying.\", 3);", 0);
		return;
	}

	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
	{
		%time = getIntegerTime(true) >> 5;

		if(%clientId.floodMute)
		{
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0)
			{
				Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;

		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);

		if(%clientId.floodMessageCount > 4)
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}
	
	%armor = Player::getArmor(%clientId);

	if(%team)
	{
	
		if ($Shifter::ComChat && !isnetworkdown(gamebase::getteam(%clientId)) && !ispowerdown(gamebase::getteam(%clientId)) && !$portagen[Gamebase::getTeam(%clientId)])
		{
			schedule ("bottomprint( " @ %clientId @ ", \"<jc><f1>Your sensor array and power are down. Team-only coms do <f3>not<f1> function.\", 10);" ,0.2);
			return 0;
		}
	
		if($dedicated) echo("SAYTEAM: " @ %msg);
		%team = Client::getTeam(%clientId);

		if($InfTime[%clientId] > 0 && %clientId.origTeam != "" && %clientIdorigTeam >= 0)
			%team = %clientId.origTeam;

		//============== Observer direct chat
		if(%clientId.obsdirect == "true" && %clientId.obstarget != "" && %clientId.observerMode == "observerOrbit")
		{
			Client::sendMessage(%clientId, 1, "("@Client::getName(%clientId)@") " @ %message);
			Client::sendMessage(%clientId.obstarget, 1, "("@Client::getName(%clientId)@") " @ %message);
			return;
		}
	
		%spyteam = CheckWireTap(Client::getOwnedObject(%clientId),%clientId);

		if($debug) echo("Wiretap Team(s) = "@ %spyteam);

		for(%i = 0; %i < 8; %i++)
		{
			%spyteams[%i] = getWord(%spyteam,%i);
			if(%spyteams[%i] == "")
				%spyteams[%i] = -1;
		}

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%armor = Player::getArmor(%cl);

			if($InfTime[%cl] > 0 && %cl.origTeam != "" && %cl.origTeam >= 0)
				%team2 = %cl.origTeam;
			else
				%team2 = Client::getTeam(%cl);
	
			if(%team2 == %team && !%cl.muted[%clientId])
			{
					if(%cl.soundmute[%clientId] && !%cl.muted[%clientId])
						Client::sendMessage(%cl, $MsgTypeTeamChat, %message2, %clientId);
					else
						Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			}
			else
			{
				if(%team2 > -1 && (Player::getMountedItem(%cl, $BackpackSlot) == Laptop //&& (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale") 
				  && (%clientId.observerMode == "" || %clientId.observerMode == "commander") || %spyteams[0] == %team2 || %spyteams[1] == %team2 || %spyteams[2] == %team2 || %spyteams[3] == %team2
				  || %spyteams[4] == %team2 || %spyteams[5] == %team2 || %spyteams[6] == %team2 || %spyteams[7] == %team2))
				{
					if(%cl.soundmute[%clientId] && !%cl.muted[%clientId])
						Client::sendMessage(%cl, 1, %message2, %clientId);
					else
						if(!%cl.muted[%clientId])
						Client::sendMessage(%cl, 1, %message, %clientId);
				}

				//let observers see all teamchat
				if((%cl.observerMode == "observerOrbit" || %cl.observerMode == "observerFly") && !%cl.obschat)
				{
					if(%cl.soundmute[%clientId] && !%cl.muted[%clientId])
						Client::sendMessage(%cl, 1, %message2, %clientId);
					else
						if(!%cl.muted[%clientId])
							Client::sendMessage(%cl, 1, %message, %clientId);
				}
			}
		}
	}
	else
	{
		if($dedicated) echo("SAY: "@%msg); //echo("SAY: "@Client::getName(%clientId)@" - "@%msg);
		
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.soundmute[%clientId] && (!%cl.muted[%clientId]))
				Client::sendMessage(%cl, $MsgTypeChat, %message2, %clientId);
			else 
			{
				if(!%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
			}
		}
	}
}

function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been Muted by admin, for talking too much...\", 3);", 0);
		return;
	}
	if ($Shifter::ComChat && !isnetworkdown(gamebase::getteam(%clientId)) && !ispowerdown(gamebase::getteam(%clientId)) && !$Portagen[Gamebase::getTeam(%clientId)])
	{
		schedule ("bottomprint( " @ %clientId @ ", \"<jc><f2>Your sensor array and power are down.  Team-only coms do <f3>not<f2> function.\", 10);" ,0.2);
		return 0;
	}
	if($dedicated)
	{
		echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}
	if($debug) echo("Command Issued " @ %command);	

	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area issueCommand takes float mission coords.

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
		if(!%dest[%i].muted[%commander])
		issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);

		// Crap stolen from Meltdown to make the Slipstream mode of the Teleport pack work
		%waypoint = %WayX @ " " @ %WayY;
		%commandee = %dest[%i];
		$point[%commandee] = %waypoint;

		if($debug) echo ("Dest " @ %dest[%i]);
	}
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if (%commander.ismuted)
	{
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You have been muted by admin, so just stop trying.\", 3);", 0);
		return;
	}
	
	if($dedicated)
	{
	echo("COMMANDISSUE: " @ %commander @ " \"" @ %command @ "\"");
	}

	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	{
	if(!%dest[%i].muted[%commander])
	issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
	echo ("Dest " @ %dest[%i]);
	}
}

function remoteCStatus(%clientId, %status, %message)
{

	if(setCommandStatus(%clientId, %status, %message))
	{
		if($dedicated)
			echo("COMMANDSTATUS: " @ %clientId @ " \"" @ escapeString(%message) @ "\"");
	}
	else
		remoteSay(%clientId, true, %message);
}

function teamMessages(%mtype, %team1, %message1, %team2, %message2, %message3)
{
   %numPlayers = getNumClients();
   for(%i = 0; %i < %numPlayers; %i = %i + 1)
   {
      %id = getClientByIndex(%i);
      if(Client::getTeam(%id) == %team1)
      {
         Client::sendMessage(%id, %mtype, %message1);
      }
      else if(%message2 != "" && Client::getTeam(%id) == %team2)
      {
         Client::sendMessage(%id, %mtype, %message2);
      }
      else if(%message3 != "")
      {
         Client::sendMessage(%id, %mtype, %message3);
      }
   }
}

function messageAll(%mtype, %message, %filter)
{
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         Client::sendMessage(%cl, %mtype, %message);
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if(%cl.messageFilter & %filter)
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
}

function messageAllExcept(%except, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if(%cl != %except)
         Client::sendMessage(%cl, %mtype, %message);
}

function bottomprintadmins(%super, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if((%cl.isSuperAdmin && %super) || (%cl.isAdmin && !%super))
         bottomprint(%cl, %message);
   }
}

function messageAllAdmins(%super, %mtype, %message)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      if((%cl.isSuperAdmin && %super) || (%cl.isAdmin && !%super))
         Client::sendMessage(%cl, %mtype, %message);
}

function checkBadWords(%client,%msg)
{
   %saidbadword=false;
   		
   for(%i = 0; $Shifter::badwordlist[%i] != ""; %i++)
   {
	if(String::findSubStr(%msg,$Shifter::badwordlist[%i]) != -1)
	{
		%saidbadword = true;
//		%swear = " ";
		for(%j=0;%j < String::len($Shifter::badwordlist[%i]);%j++)
			%swear = %swear @ "*";
		%msg = String::replace2(%msg,$Shifter::badwordlist[%i],%swear);
	}

	//and now the really tricky bit
//   if($Shifter::brokenswear != "false")
//   {
//	for(%j=0;getWord(%msg,%j) != ""; %j++)
//	{
//		%letter = 0;
//		%word = getWord(%msg,%j);
//		if(%word != "flag")
//		{
//			for(%k=0;%k < String::len(%word);%k++)
//			{
//				if(String::getSubStr(%word,%k,1) == String::getSubStr($Shifter::badwordlist[%i],%letter,1) && %letter < String::len($Shifter::badwordlist[%i]))
//				{
//					%letter++;
//				}
//			}
//			if(%letter >= String::len($Shifter::badWordList[%i]))
//			{
//				for(%k=0;%k < String::len(%word);%k++)
//					%swear = %swear @ "*";
//				%msg = String::replace(%msg,%word,%swear);
//			}
//		}
//	}
//    }
   } 
         
   if(%saidbadword)
   {
      
       %client.BadWordsSpoken++;
//       if(%client.BadWordsSpoken>=$Shifter::BadWordsKick)
//	{
//		%client.BadWordsSpoken = 0;
  //     		Net::Kick(%client,"You have been kicked for foul language");
//		return true;
//	}

       if(%client.BadWordsSpoken<$Shifter::BadWordsMax)
	{
       		Client::sendMessage(%client, $MsgTypeGame, "Cussing is not allowed.");
		centerprint(%client,"<jc><f2>Clean up your language and try again.",10);
	}
       else if(%client.BadWordsSpoken>=$Shifter::BadWordsMax)
       {
       		Client::sendMessage(%client, $MsgTypeGame, "Keep it up.  I can do this all day.");
		%time = getIntegerTime(true) >> 5;
		%client.floodMute = true;
		%client.muteDoneTime = %time + 10;
		%client.ismuted=True;
		schedule(%client @ ".ismuted=false;",10);
		schedule("centerprint(" @ %client @ ",\"<jc><f0>You don't get it do you?  Shut the hell up.\",10);",2);
		messageallexcept(%client,1,Client::getName(%client) @ " is a potty mouth.");
		doneposs(%client);
		Player::blowUp(%client);
		Player::unMountItem(%client,4);
		Player::unMountItem(%client,5);
		Player::Kill(%client);
       }
//   return true;
   }
  return %msg;
}

function getParticiple(%name)
{
	%letter = String::getSubStr(%name,0,1);
	if(%letter == "A" || %letter == "E" || %letter == "I" || %letter == "O" || %letter == "U")
		%participle = "an";
	else
		%participle = "a";
	return %participle;
}
