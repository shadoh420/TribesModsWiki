$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	if(%clientId.notalk == true || %clientID.initnotalk == true || %clientid.garrotenotalk == true)
		return;
	
     %badchar[0] = "\x10";
     %badchar[1] = "\x11";
     %badchar[2] = "\x12";
     %badchar[3] = "\x13";
     %badchar[4] = "\x14";
     %badchar[5] = "\x15";
     %badchar[6] = "\x16";
     %badchar[7] = "\x17";
     %badchar[8] = "\x18";
     %badchar[9] = "\x19";
     %badchar[10] = "\t";

   for(%x=0;%x<11;%x++)
   {
	if(String::findSubStr(%message,%badchar[%x]) != -1)
	{
		echo("Caught");
		return;
	}
   }
   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team))
   {
      // we use getIntTime here because getSimTime gets reset.
      // time is measured in 32 ms chunks... so approx 32 to the sec
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
      // funky use of schedule here:
      schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
      if(%clientId.floodMessageCount > 4)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 10;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
         return;
      }
   }

   if(%team)
   {
      if($dedicated)
         echo("SAYTEAM "@Client::getTeam(%clientId)@": " @ %msg);

	// No talking when you're dead!

	if(%clientId.observerMode == "dead")
	{
	        Client::sendMessage(%clientId, $MSGTypeGame, "You cannot talk while you're dead!");
		return;
	}

      %team = Client::getTeam(%clientId);
	
	if(String::findSubStr(%message,"Ghola") == 0 ) {
		if(String::findSubStr(%message,"follow") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::Follow(%ghola, %clientId);
				}
			}

		} else if(String::findSubStr(%message,"stay") == 6 || String::findSubStr(%message,"stop") == 6 || String::findSubStr(%message,"halt") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::stay( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"go") == 6 || String::findSubStr(%message,"ahead") == 6 || String::findSubStr(%message,"advance") == 6 ) {
			%dist = getword(%message, 2);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::AdvanceAhead( %ghola, %dist );
				}
			}

		} else if(String::findSubStr(%message,"stance") == 6 || String::findSubStr(%message,"act") == 6 || String::findSubStr(%message,"style") == 6 ) {
			%style = getword(%message, 2);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::Stance( %ghola, %style );
				}
			}

		} else if(String::findSubStr(%message,"clear") == 6 || String::findSubStr(%message,"align") == 6 ) {
			Ghola::packList(%clientId);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::clearDir( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"formation") == 6 || String::findSubStr(%message,"form") == 6) {

			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::SetFormation( %ghola, getword(%message, 2), getword(%message, 3), getword(%message, 4), getword(%message, 5) );
				}
			}

		} else if(String::findSubStr(%message,"getTarget") == 6 || String::findSubStr(%message,"who") == 6 || String::findSubStr(%message,"attacking") == 6) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					schedule("Ghola::whoAttacking( \"" @ %ghola @ "\");\"", 0.1);
				}
			}

		} else if(String::findSubStr(%message,"attack") == 6 || String::findSubStr(%message,"kill") == 6 
			|| String::findSubStr(%message,"murder") == 6 || String::findSubStr(%message,"eliminate") == 6
			|| String::findSubStr(%message,"charge") == 6 || String::findSubStr(%message,"assult") == 6 ) {
			//%person = getword(%message, 2);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::stance( %ghola, 3 );
				}
			}

		} else if(String::findSubStr(%message,"guard") == 6 || String::findSubStr(%message,"defend") == 6 ) {
			//%person = getword(%message, 2);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::stance( %ghola, 2 );
				}
			}

		} else if(String::findSubStr(%message,"shield") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::ShieldOn( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"pack") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::PackOn( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"use") == 6 ) {
			%weapon = String::getSubStr(%message, 10, 20);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::UseWeapon( %ghola, %weapon );
				}
			}

		} else if(String::findSubStr(%message,"dist") == 6) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::DistWeap( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"melee") == 6) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::MeleeWeap( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"drop") == 6) {
			// Weapon, ammo, pack, or specified.
			%type = String::getSubStr(%message, 11, 20);
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					if(String::findSubStr(%type, "Weapon") == 0)
						Ghola::DropWeap( %ghola );
					else if(String::findSubStr(%type, "Ammo") == 0)
						Ghola::DropAmmo( %ghola );
					else if(String::findSubStr(%type, "Pack") == 0)
						Ghola::DropPack( %ghola );
					else 
						Ghola::Drop( %ghola, %type );
			
				}
			}

		} else if(String::findSubStr(%message,"antitank") == 6 || String::findSubStr(%message,"anti-tank") == 6 
			|| String::findSubStr(%message,"anti tank") == 6 || String::findSubStr(%message,"antigr") == 6 
			|| String::findSubStr(%message,"anti-gr") == 6 || String::findSubStr(%message,"anti gr") == 6 
			|| String::findSubStr(%message,"tank") == 6 || String::findSubStr(%message,"gr") == 6 
			|| String::findSubStr(%message,"car") == 6 || String::findSubStr(%message,"anticar") == 6 
			|| String::findSubStr(%message,"anti-car") == 6 || String::findSubStr(%message,"anti car") == 6
			|| String::findSubStr(%message,"AT") == 6 || String::findSubStr(%message,"AGC") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::ATankWeap( %ghola );
				}
			}

		} else if(String::findSubStr(%message,"antithopter") == 6 || String::findSubStr(%message,"anti-thopter") == 6 
			|| String::findSubStr(%message,"anti thopter") == 6 || String::findSubStr(%message,"antiOrni") == 6 
			|| String::findSubStr(%message,"anti-Orni") == 6 || String::findSubStr(%message,"anti Orni") == 6 
			|| String::findSubStr(%message,"thop") == 6 || String::findSubStr(%message,"Orni") == 6 
			|| String::findSubStr(%message,"AA") == 6 || String::findSubStr(%message,"AO") == 6 ) {
			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				if( %ghola != "" ) {
					Ghola::AThopterWeap( %ghola );
				}
			}

		} else {

			for(%x = 1; %x <= $GholaOwnedMax; %x++){
				%ghola = $OwnedGholaList[%clientid, %x];
				%gholatwo = String::getSubStr(%ghola, 5, 50);
				if(String::findSubStr(%message,%ghola) == 6 || String::findSubStr(%gholatwo, getword(%message, 1)) != -1) {
					// Probably wont have anymore then 5 arguments
					%arg1 = getword(%message, 2);
					%arg2 = getword(%message, 3);
					%arg3 = getword(%message, 4);
					%arg4 = getword(%message, 5);
					%arg5 = getword(%message, 6);
					
					// Concat all but the first argument.(first will be the command)
					%arguments = %arg2;
					if(!String::empty(%arg3) && %arg3 != -1)
						%arguments = %arguments @ " " @ %arg3;
					if(!String::empty(%arg4) && %arg4 != -1)
						%arguments = %arguments @ " " @ %arg4;
					if(!String::empty(%arg5) && %arg5 != -1)
						%arguments = %arguments @ " " @ %arg5;

	

					if( String::findSubStr(%message, "follow") == 0) {
						Ghola::Follow(%ghola, %clientId);
					} else if( String::findSubStr(%arg1, "stay") == 0 || String::findSubStr(%arg1, "stop") == 0 || String::findSubStr(%arg1, "halt") == 0 ) { 
						Ghola::Stay(%ghola);
					} else if( String::findSubStr(%arg1, "shield") == 0 ) {
						Ghola::ShieldOn( %ghola );
					} else if( String::findSubStr(%arg1, "pack") == 0 ) {
						Ghola::PackOn( %ghola );
					} else if( String::findSubStr(%arg1, "use") == 0 ) {
						Ghola::UseWeapon( %ghola, %arguments );
					} else if( String::findSubStr(%arg1, "dist") == 0 ) {
						Ghola::DistWeap(%ghola);
					} else if( String::findSubStr(%arg1, "melee") == 0 ) {
						Ghola::MeleeWeap(%ghola);
					} else if( String::findSubStr(%arg1, "AttackMode") == 0 ) {
						Ghola::AttackMode( %ghola, %arg2 );
					} else if( String::findSubStr(%arg1, "PathType") == 0 ) {
						Ghola::PathType( %ghola, %arg2 );
					} else if( String::findSubStr(%arg1, "drop") == 0 ) {
						Ghola::Drop( %ghola, %arg2 );
					} else if( String::findSubStr(%arg1,"antitank") == 0 || String::findSubStr(%arg1,"anti-tank") == 0 
						|| String::findSubStr(%arg1,"anti tank") == 0 || String::findSubStr(%arg1,"antigr") == 0 
						|| String::findSubStr(%arg1,"anti-gr") == 0 || String::findSubStr(%arg1,"anti gr") == 0 
						|| String::findSubStr(%arg1,"tank") == 0 || String::findSubStr(%arg1,"gr") == 0 
						|| String::findSubStr(%arg1,"car")== 0 || String::findSubStr(%arg1,"anticar") == 0
						|| String::findSubStr(%arg1,"anti-car") == 0 || String::findSubStr(%arg1,"anti car") == 0
						|| String::findSubStr(%arg1,"AT") == 0 || String::findSubStr(%arg1,"AGC") == 0 ) {
						Ghola::ATankWeap(%ghola);
					} else if(String::findSubStr(%arg1,"antithopter") == 0 || String::findSubStr(%arg1,"anti-thopter") == 0 
						|| String::findSubStr(%arg1,"anti thopter") == 0 || String::findSubStr(%arg1,"antiOrni") == 0 
						|| String::findSubStr(%arg1,"anti-Orni") == 0 || String::findSubStr(%arg1,"anti Orni") == 0 
						|| String::findSubStr(%arg1,"thop") == 0 || String::findSubStr(%arg1,"Orni") == 0 
						|| String::findSubStr(%arg1,"AA") == 0 || String::findSubStr(%arg1,"AO") == 0 ) {
						Ghola::AThopterWeap(%ghola);
					} else if( String::findSubStr(%arg1, "follow") == 0 ) {
						Ghola::Follow(%ghola, %clientId);
					}
				}
			}
		}
		
	}
		
	
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if((Client::getTeam(%cl) == %team) && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
	 else if ($FaceDancerIsSwitched[%cl] && !%cl.muted[%clientId])
	    Client::sendMessage(%cl, $MsgTypeTeamChat, "*Enemy* "@%message, %clientId);
	
   }
   else if(!$NoTalk)
   {

//	if((Client::getName(%clientId) == "Vincent" || Client::getName(%clientId) == "[HA]Vincent" || (String::findSubStr(Client::getTransportAddress(%clientId),"IP:66.169.29.") == 0)))
//	{
//		Client::sendMessage(%clientId, $MSGTypeGame, "You have been Permanently muted until further notice.");
//            	if(!%clientId.floodgmute || %clientId.floodgmute == "")
//		{
//			Client::sendMessage(%clientId, $MSGTypeGame, "A message has been sent to everyone alerting them of your situation.");
//     			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
//        			if(!%cl.muted[%clientId] && %cl != %clientId)
//            				Client::sendMessage(%cl, $MsgTypeGame, client::getName(%clientId) @ " has been permenantly muted on the global channel, and so is unable to respond to any global messages.");
//			%clientId.floodgmute = true;
//			schedule(%clientId @ ".floodgmute = false;", 72000, %clientId);
//      		}
//		return;
//	}

	if(String::findSubStr(%message,"~w") != -1 && $NoLoudTalk)
	{
		Client::sendMessage(%clientId, $MSGTypeGame, "But loud noises attract worms!");
		return;
	}
	//echo($LastMessage[%clientId]@ " " @%msg@ ": " @  getlength($LastMessage[%clientId]));
	//echo(!String::NCompare($LastMessage[%clientId], %msg, getlength($LastMessage[%clientId])));
	if($LastMessage[%clientId] != (%clientId@" \"\"") && !String::NCompare($LastMessage[%clientId], %msg, getlength($LastMessage[%clientId])) && $NoRepeat) 
	{
		Client::sendMessage(%clientId, $MSGTypeGame, "Shai-Hulud forbids repitition.");
	        return;
	} else
		$LastMessage[%clientId] = %msg;


      if($dedicated)
	if($STALK)
        	echo("SAY: " @ %msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   } else if($NoTalk) {
	Client::sendMessage(%clientId, $MSGTypeGame, "Global chat has been turned off to encourage teamwork.");
	         
   }
//   else
//   {
//     if($dedicated)
//         echo("SAY: " @ %msg);
//      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
//         if(!%cl.muted[%clientId])
//            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
//   }
}




function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY,
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   // issueCommandI takes waypoint 0-1023 in x,y scaled mission area
   // issueCommand takes float mission coords.
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, 
      %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
   if($dedicated)
      echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\"");
   for(%i = 1; %dest[%i] != ""; %i = %i + 1)
      if(!%dest[%i].muted[%commander])
         issueTargCommand(%commander, %dest[%i], %cmdIcon, %command, %targIdx);
}

function remoteCStatus(%clientId, %status, %message)
{
   // setCommandStatus returns false if no status was changed.
   // in this case these should just be team says.
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

function getLength(%string)
{
	%length = 0;
	%sub = " ";
	while(%sub != ""){
		%sub = String::Getsubstr(%string,%length,1);
	//	echo(%sub);
		%length++;
	}
	%length = %length-2;
	if(%length < 1)
		%length = 1;	
	//echo(%length);
	return %length;
}
