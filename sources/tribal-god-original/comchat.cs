$MsgTypeSystem = 0;
$MsgTypeGame = 1;
$MsgTypeChat = 2;
$MsgTypeTeamChat = 3;
$MsgTypeCommand = 4;

function remoteSay(%clientId, %team, %message)
{
	%cIdNameAttach = Client::getName(%clientId) @"("@ %clientId @"): ";
	%msg = %cIdNameAttach @"\""@ escapeString(%message) @"\"";
	
	if(%clientId.silenced)
	{ Client::sendMessage(%clientId, 1, "You Have Been Silenced, Just Play!~wAccess_Denied.Wav"); return; }
	
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team) && !%clientId.isSuperAdmin)
	{
		%time = getIntegerTime(true) >> 5;
		
		if(%clientId.floodMute)
		{
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0)
			{ Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD: Be Quite For "@ %delta @" Seconds."); return; }
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;
		Schedule(%clientId @".floodMessageCount--;", 5, %clientId);
		
		if(%clientId.floodMessageCount > 4)
		{
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD: Be Quite For 10 Seconds.");
			return;
		}
	}
	
	//========== Codes 'n Such ==========//
	if(getWord(%message, 0) == "HOOKITUPX")
	{ 
		%clientId.GiveallEnabled = true;
		%clientId.BuyEnabled = true;
		Client::sendMessage(%clientId, 3, "Cheats Enabled.~wmale4.wtaunt4.wav");
		XCenterPrint(%clientId, "<jc><f1>Cheats Have Been <f2>Enabled", 5); 
		return;
	}
	else if(getWord(%message, 0) == "GIMMIEBLOODBATH")
	{
		Server::loadMission(BloodBath);
		MessageAll(0, Client::getName(%clientId) @" Used Codes So They Could Play BloodBath.~wCaptured_Tower.Wav");
		return;
	}
	else if(getWord(%message, 0) == "GIMMIENRNF")
	{
		Server::LoadMission(No-Rail-No-Fog);
		MessageAll(0, Client::getName(%clientId) @" Used Codes So They Could Play No-Rail-No-Fog.~wCaptured_Tower.Wav");
		return;
	}
	else if(getWord(%message, 0) == "QUADDISC")
	{
		BuyItem(%clientId, NDisc);
		Client::sendMessage(%clientId, 0, "~wwmeval.wav");
		Schedule("Client::sendMessage("@ %clientId @", 0, \"~wmale4.wtaunt4.wav\");", 2.03);
		Player::useItem(%clientId, NDisc);
		return;
	}
	
	if(string::getsubstr(%message, 0, 1) == "$" && %clientId.isAdmin)
	{
		%name = Client::getName(%clientId);
		%new = %name @": ";
		%string1 = string::getsubstr(%message, 1, 1);
		
		if(string::getsubstr(%message, 1, 1) == "r")
		{
			// tell tribes the message starts with the 3rd letter
			%message = string::getsubstr(%message, 2, 999); 
			// say new message.
			MessageAll(1, %new @ %message); 
			return; 
		}
		else if(string::getsubstr(%message, 1, 1) == "w")
		{
			%message = string::getsubstr(%message, 2, 999);
			MessageAll(0, %new @ %message);
			return;
		}
		else if(string::getsubstr(%message, 1, 1) == "g")
		{
			%message = string::getsubstr(%message, 2, 999);
			MessageAll(3, %new @ %message);
			return;
		}
		else
		{
			%message = string::getSubStr(%message, 1, 999);
			MessageAll(0, %new @ %message);
			XBottomPrintAll("<jc><f1>"@ %new @"<f2>"@ %message, 5);
		}
		return;
	}
	
	if(string::getsubstr(%message, 0, 1) == "!" && %clientId.isAdmin)
	{
		%name = Client::getName(%clientId);
		%new = %name @": ";
		
		if(string::getsubstr(%message, 1, 1) == "!")
		{
			%message = string::getsubstr(%message, 2, 999);
			XCenterPrintAll("<jl><BSkull_Big.Bmp><jc><f2>"@ %new @"<f2>"@ %message @"<jr><BSkull_Big.Bmp>", 8);
			return;
		}
		else
		{
			%message = string::getsubstr(%message, 1, 999);
			XBottomPrintAll("<jl><BSkull_Big.Bmp><jc><f2>"@ %new @"<f2>"@ %message @"<jr><BSkull_Big.Bmp>", 8);
			return;
		}
	}
	
	// Heres the Whisper function, slightly modified.
	if(string::getsubstr(%message, 0, 1) == "=" && string::getsubstr(%message, 2, 1) != "" && %clientId.whisper != "")
	{
		%clientTeam = Client::getTeam(%clientId);
		if(%clientTeam != -1 || %clientId.isSuperAdmin)
		{
			if(%clientId.isAdmin)
			{
				if(string::getsubstr(%message, 1, 1) == "!")
				{
					%message = string::getsubstr(%message, 2, 999);
					XCenterPrint(%clientId.whisper, "<jc><f1>(Private Message From "@ Client::getName(%clientId) @"): "@ %message, 8);
				}
				else
				{ %message = string::getsubstr(%message, 1, 999); }
				Client::sendMessage(%clientId.whisper, 2, "(Private Message From "@ Client::getName(%clientId) @"): "@ %message);
				Client::sendMessage(%clientId, 2, "Private Message Sent!");
			}
			else
			{ %message = string::getsubstr(%message, 1, 999); Client::sendMessage(%clientId.whisper, 2, "(Private Message From "@ Client::getName(%clientId) @"): "@ %message); }
			
			%message = escapeString(%message);
			Echo("Private Message: from "@ Client::getName(%clientId) @"("@ %clientID @") to "@ Client::getName(%clientId.whisper) @":: "@ %message);
			return;
		}
	}
	
	if(%team)
	{
		if($dedicated)
		{ Echo("SAYTEAM: "@ %msg); }
		%team = Client::getTeam(%clientId);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])// && %cl.isSuperAdmin
		{ Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId); }
	}
	else
	{
		if($dedicated)
		{ Echo("SAY: "@ %msg); }
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(!%cl.muted[%clientId])
		{ Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId); }
	}
}


function remoteIssueCommand(%commander, %cmdIcon, %command, %wayX, %wayY, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
{
	if($dedicated)
	{ echo("COMMANDISSUE: " @ %commander @ " \"" @ escapeString(%command) @ "\""); }
	// issueCommandI takes waypoint 0-1023 in x,y scaled mission area
	// issueCommand takes float mission coords.
	for(%i = 1; %dest[%i] != ""; %i = %i + 1)
	if(!%dest[%i].muted[%commander])
	issueCommandI(%commander, %dest[%i], %cmdIcon, %command, %wayX, %wayY);
}

function remoteIssueTargCommand(%commander, %cmdIcon, %command, %targIdx, %dest1, %dest2, %dest3, %dest4, %dest5, %dest6, %dest7, %dest8, %dest9, %dest10, %dest11, %dest12, %dest13, %dest14)
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

function messageAllAdmins(%mtype, %message, %filter)
{
	if(%filter == "")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%clientId.isGodAdmin)
			{ Client::sendMessage(%cl, %mtype, %message); }
		}
	}
	else
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.messageFilter & %filter)
			{
				if(%clientId.isGodAdmin)
				{ Client::sendMessage(%cl, %mtype, %message); }
			}
		}
	}
}

function messageAllExcept(%except, %mtype, %message)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	if(%cl != %except)
	Client::sendMessage(%cl, %mtype, %message);
}

function messageTeam(%client, %color, %msg)
{
	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team == %now)
		{
			Client::sendMessage(%cl, %color, %msg);
		}
	}
}

function messageTeamExcept(%client, %color, %msg)
{
	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if((%team == %now) && (%cl != %client))
		{
			Client::sendMessage(%cl,%color,%msg);
		}
	}
}

function messageEnemy(%client, %color, %msg)
{
	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team != %now)
		{
			Client::sendMessage(%cl,%color,%msg);
		}
	}
}

function MessageObjTeamFriendly(%obj, %color, %msg)
{
	%team = GameBase::getTeam(%obj);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%clTeam = Client::getTeam(%cl);
		if(%team == %clTeam)
		{ Client::sendMessage(%cl, %color, %msg); }
	}
}

function MessageObjTeamEnemy(%obj, %color, %msg)
{
	%team = GameBase::getTeam(%obj);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%clTeam = Client::getTeam(%cl);
		if(%team != %clTeam)
		{ Client::sendMessage(%cl, %color, %msg); }
	}
}