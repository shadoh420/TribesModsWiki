//Other Stuff
$ComchatCoreVer = "3.X - 1/24/02 - ShifterX ONLY";

//===Server.cs Stuff
//Overwrite Emo's back door stuff and make sure every server will show the Join Message
function Server::onClientConnect(%clientId)
{

//===Multiple Name AutoBanning Code
   %Clname = client::getname(%ClientID);
//   %dot = string::FindSubStr(%Clname, ".");
//   %num = string::right(%Clname, string::len(%Clname) - %h - 1);

  if ((string::right(%Clname, 2) == ".2") || (string::right(%Clname, 2) == ".3") || (string::right(%Clname, 2) == ".4") || (string::right(%Clname, 2) == ".5"))
  {
    BanList::add(Client::getTransportAddress(%clientId), 900);
    Net::Kick(%ClientId, "Duplicate names not allowed.");
    echo("ADMINMSG: **** Not allowing " @ client::getname(%clientId) @ " (" @ Client::getTransportAddress(%clientId) @ ") to connect: duplicate name.");
    return;
  }
//==END

   echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   Game::onPlayerConnected(%clientId);
}

//=== Begin real comchat.cs...
$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
   if (!$matchStarted) return;
   for(%length=0; String::getSubStr(%message, %length, 1) != ""; %length++) {}
   if (%length > 110)
   {
    echo("ADMINMSG: **** " @ client::getName(%clientId) @ " (" @ Client::getTransportAddress(%clientId) @ ") tried to send a message of " @ %length @ " characters.");
    return;
   }

   if ((String::Left(%message, 4) == "SAD(") || (String::Left(%message, 4) == "Sad(") || (String::Left(%message, 4) == "sad("))
   {
    Client::sendMessage(%clientId, 1, "Try not to enter your SAD password into the chatbox, thanks.  --Lofar");
    echo("ADMINMSG: **** " @ client::getName(%clientId) @ " almost said his SAD in a message.");
    return;
   }

   %msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
   if(%message == "") return;

   // check for flooding if it's a broadcast OR if it's team in FFA
   if($Server::FloodProtectionEnabled)
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
      schedule(%clientId @ ".floodMessageCount--;", 1.5, %clientId);
      if(%clientId.floodMessageCount > 1)
      {
         %clientId.floodMute = true;
         %clientId.muteDoneTime = %time + 1;
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 2 seconds.");
         return;
      } else if (%message == %clientID.LastSentMessage) {
         Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot send the same message for 4 seconds!");
         return;
      }
   }

   %clientID.LastSentMessage = %message;
   schedule(%clientId @ ".LastSentMessage=\"\";", 4, %clientId);

   if(%clientID.isSuperAdmin == true)
   {
	if ((String::left(%message, 2) == ";;") && (String::Len(%message) > 2))
	{
	 remoteAdminChat(%clientId, String::Right(%message, String::Len(%message) - 2));
	 return;
	}

	else if (%message == ":qa")				//Query Admins
	{
	 remoteQueryAdmin(%clientID);
	 return;
	}

	else if (%message == ":si")				//Comchat Version & Server Info
	{
	 remoteGetServerInfo(%clientID);
	 return;
	}

	else if (%message == ":usad")				//Un-sad Me
	{
	 remoteUnSadMe(%clientID);
	 return;
	}

	else if ((%message == ":help") || (%message == ":?"))		//Admin Help
	{
	 remoteAdminHelp(%clientID);
	 return;
	}

	else if (%message == ":DCShutdown")			//Close DCon remote
	{
	 echo("DCon::Shutdown - " @ client::getname(%clientId) @ " (" @ client::getTransportAddress(%clientId) @ ")");
	 Client::sendMessage(%clientId, 1, "DCon remote shutdown request sent...");
	 return;
	}
   }

   if ((String::left(%message, 1) == ";") && (String::Len(%message) > 1))
   {
    if (remoteFedChat(%clientId, String::Right(%message, String::Len(%message) - 1)) == 1) return 1;
   }

   if (%message == ":!")
   {
    %from = client::getname(%clientId);
    if ((String::left(client::getname(%client), 5) != "[*HF]")
	&& (String::left(client::getname(%client), 5) != "[HF*]")
	&& (String::left(client::getname(%client), 4) != "[HF]")
	&& (String::left(client::getname(%client), 4) != "HF*|")
	&& (String::left(client::getname(%client), 3) != "HF|")
	&& (String::left(client::getname(%client), 3) != "HF*")
	&& (String::left(client::getname(%client), 4) != "*HF|")) return 0;
    echo("! assistance requested by " @ %from);
    Client::sendMessage(%clientId, 1, "Paging remote admins...");
    return;
   }

   if(%team)
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
         echo("SAY: " @ %msg);
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(!%cl.muted[%clientId])
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

function messageAll(%mtype, %message, %filter, %force, %id1, %id2)
{
 if ((%mtype == 2) && (%filter == 10)) return;
 if (%filter == 0) %filter = "";

 if(%force == 1)
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
 else
 {
   if(%filter == "")
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         { if((%cl.KillMsgOpt == 0) || (String::findSubStr(%message,client::getname(%cl)) != -1)) Client::sendMessage(%cl, %mtype, %message); }
   else
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         if ((%cl.messageFilter & %filter) && ((%cl.KillMsgOpt == 0) || (String::findSubStr(%message,client::getname(%cl)) != -1)))
            Client::sendMessage(%cl, %mtype, %message);
      }
   }
 }
}

function messageAllExcept(%except, %mtype, %message, %force, %id1, %id2)
{
 if(%force == 1)
 {
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {if (%cl != %except) Client::sendMessage(%cl, %mtype, %message);}
 }
 else
 {
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      { if ((%cl != %except) && ((%cl.KillMsgOpt == 0) || (String::findSubStr(%message,client::getname(%cl))) != -1)) Client::sendMessage(%cl, %mtype, %message); }
 }
}

//===New Stuff
function remoteAdminChat(%from, %msg)
{
 if (!%from.isSuperAdmin) return;
 %from = Client::getName(%from);
 %client = Client::getFirst(); 

 echo("ADMINMSG: ***** SAD Chat: \"" @ %msg @ "\" - " @ %from);

 while (%client != -1)
 {
  if (%client.isSuperAdmin) Client::sendMessage(%client, 1, "SAD Chat - " @ %from @ ": " @ %msg);
  %client = Client::getNext(%client);
 }
}

function remoteFedChat(%from, %msg)
{
 %from = client::getname(%from);

 if (!FedTagCheck(%from)) return 0;

 echo("ADMINMSG: ***** Fed Chat: \"" @ %msg @ "\" - " @ %from);
 %client = Client::getFirst(); 

 while (%client != -1)
 {
  if (FedTagCheck(client::getname(%client))) Client::sendMessage(%client, 1, %from @ ": " @ %msg, %from);

  %client = Client::getNext(%client);
 }
 return 1;
}

function FedTagCheck(%name)
{
 if (String::left(%name, 5) == "[*HF]")	return 1;
 if (String::left(%name, 5) == "[HF*]")	return 1;
 if (String::left(%name, 4) == "[HF]")	return 1;
 if (String::left(%name, 4) == "HF*|")	return 1;
 if (String::left(%name, 3) == "HF|")	return 1;
 if (String::left(%name, 3) == "HF*")	return 1;
 if (String::left(%name, 4) == "*HF|")	return 1;
 return 0;
}

function remoteQueryAdmin(%from)
{
 if (!%from.isSuperAdmin) return;
 %client = Client::getFirst(); 
 %alist = "SADs: " @ Client::getName(%from);

 while (%client != -1)
 {
  if ((%client.isSuperAdmin) && (%client != %from)) %alist = %alist @ ", " @ Client::getName(%client);
  %client = Client::getNext(%client);
 }

 Client::sendMessage(%from, 1, %alist, %from);
}

function remoteGetServerInfo(%from)
{
 if (!%from.isSuperAdmin) return;
 Client::sendMessage(%from, 1, "Server: " @ $Server::HostName);
 Client::sendMessage(%from, 1, "Mod: " @ $ItemFavoritesKey);
 Client::sendMessage(%from, 1, "Comchat extentions version: " @ $ComChatExt::Ver); 
}

function remoteAdminHelp(%from)
{
 if (!%from.isSuperAdmin) return;
 Client::sendMessage(%from, 1, "Enter the following commands into the chat box:");
 Client::sendMessage(%from, 1, ";;<message>      -Admin (SAD) chat");
 Client::sendMessage(%from, 1, ";<message>       -HF chat (tag based)");
 Client::sendMessage(%from, 1, ";qa                -Query Admins in server");
 Client::sendMessage(%from, 1, ":si                 -Server Info");
 Client::sendMessage(%from, 1, ":usad              -Remove Sad (no longer admin)");
 Client::sendMessage(%from, 1, ":!                  -Page remote admins");
 Client::sendMessage(%from, 1, ":help               -Help Print-Out");
}

function remoteUnSadMe(%from)
{
 if (%from.isSuperAdmin)
 {
  %from.isAdmin = false;
  %from.isSuperAdmin = false;
  %from.PassTry = 0;
  Client::sendMessage(%from, 1, "You are no longer an admin.");
  echo("ADMINMSG: **** " @ Client::getName(%from) @ " manually removed his SAD status.");
 }
}

function remoteAdminPassword(%client, %password)
{
 if(%password == "") return;

 if (%client.PassTry > 2)
 {
  echo("ADMINMSG: **** Kicking " @ client::getname(%client) @ " in 5 seconds, too many password attempts.");
  schedule("Net::Kick(" @ %client @ ", \"Too many password attempts. Good-Bye.\");", 5);
  return 0;
 }
 else
 {
  %client.PassTry++;
 }

 for (%x = 1; %x <= $NumSADPass; %x++)
 {
  if (%password == $AdminPasswordList[%x])
  {
   if ((FedTagCheck(client::getname(%client))) || ((String::findSubStr(%password,"@") > -1)||(String::findSubStr(%password,"@") > -1)||(String::findSubStr(%password,"@") > -1)))
   {
	%client.isAdmin = true;
	%client.isSuperAdmin = true;
	%client.sadNum = %x;
	echo("ADMINMSG: **** Making " @ Client::getName(%client) @ " a SAD with password number " @ %x @ ". (" @ %client.PassTry @ ")");
	Client::sendMessage(%client, 1, "Admin Password Accepted. Welcome...");
	return 1;
   }
   else
   {
	echo("ADMINMSG: **** " @ Client::getName(%client) @ " tried to enter his SAD without a HF tag.");
	Client::sendMessage(%client, 1, "You are not allowed to admin with that name.");
	return 0;
   }
  }
 }
 echo("ADMINMSG: **** Admin Password failed for " @ Client::getname(%client) @ "."); 
}

//===Usefull String Stuff
function String::left(%string, %len)
{
    if(%len >= String::len(%string))
        return %string;
    
    %left = String::getSubStr(%string, 0, %len);
    return %left;
}

function String::right(%string, %len)
{
    if(%len >= String::len(%string))
        return %string;

    %idx = String::len(%string) - %len;
    %right = String::getSubStr(%string, %idx, %len);
    return %right;
}

function String::len(%string)
{
    for(%length=0; String::getSubStr(%string, %length, 1) != ""; %length++)
    {} // it's all done above!
    return %length;
}

exec("pass.comchat.cs");

echo("<--==Comchat Loaded (Core: " @ $ComchatCoreVer @ ", Pass: " @ $ComchatPassVer @ ")==-->");