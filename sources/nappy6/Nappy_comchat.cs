function remoteSay(%clientId, %team, %message)
{
	if(%clientId.possessed){
		Client::sendMessage(%clientId, 1, "You cannot speak while possessed.~waccess_denied.wav");
		return;
	}
	if(%clientId.gag) {
		Client::sendMessage(%clientId, 1, "You can't talk without a tongue you moron!~waccess_denied.wav");
		return;
	}
	if(%clientId.speakto != "") {
		if(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PASpeak)) {
			%sound = $curPlayChatMenu @ "\\" @ %sound;
			Client::sendMessage(%clientId.speakto, 1, Client::getName(%clientID)@" (private): "@%message@"~w"@%wav);
			Client::sendMessage(%clientId, 1, Client::getName(%clientID)@" (to "@Client::getName(%clientId.speakto)@"): "@%message@"~w"@%wav);
			return;
		} 
	}
	%msg = %clientId @ " \"" @ escapeString(%message) @ "\"";
	// check for flooding if it's a broadcast OR if it's team in FFA
	if($Server::FloodProtectionEnabled && (!$Server::TourneyMode || !%team)){
		// we use getIntTime here because getSimTime gets reset.
		// time is measured in 32 ms chunks... so approx 32 to the sec
		%time = getIntegerTime(true) >> 5;
		if(%clientId.floodMute){
			%delta = %clientId.muteDoneTime - %time;
			if(%delta > 0){
				Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for " @ %delta @ " seconds.");
				return;
			}
			%clientId.floodMute = "";
			%clientId.muteDoneTime = "";
		}
		%clientId.floodMessageCount++;
		// funky use of schedule here:
		schedule(%clientId @ ".floodMessageCount--;", 5, %clientId);
		if(%clientId.floodMessageCount > 4){
			%clientId.floodMute = true;
			%clientId.muteDoneTime = %time + 10;
			Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot talk for 10 seconds.");
			return;
		}
	}
	if(%team){
		if($dedicated)
			echo("SAYTEAM: " @ %msg);
		%team = Client::getTeam(%clientId);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeTeamChat, %message, %clientId);
			else if(%cl.isSuperAdmin && Client::getTeam(%cl) == -1)
				Client::sendMessage(%cl, $Nappy::AdminObserverOtherTeamChatColor, %message, %clientId);
	}
	else{
		if($dedicated)
			echo("SAY: " @ %msg);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(!%cl.muted[%clientId])
				Client::sendMessage(%cl, $MsgTypeChat, %message, %clientId);
	}
}
