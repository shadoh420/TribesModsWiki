
$Nappy::Mod::Version = "24_2";//mod version





function Server::onClientDisconnect(%clientId)
{
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	%client = Player::getClient(%player);
	ClientItem::reinitData(%client);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1 && $Nappy::RefreshOnEmpty) // this is the last client.
		Server::refreshData();
}


function Server::finishMissionLoad()
{
	$loadingMission = false;
	$TestMissionType = "";
	// instant off of the manager
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);

	exec($missionFile);
	Mission::init();
	Mission::reinitData();
	if($prevNumTeams != getNumTeams()){
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
	}

	$ghosting = true;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(!%cl.svNoGhost){
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}
	if($SinglePlayer)
		Game::startMatch();
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();
		$teamplay = (getNumTeams() != 1);
	purgeResources(true);

	if(!$Nappy::UnlimitedMapTime){
		// make sure the match happens within 5-10 hours.
		schedule("Server::CheckMatchStarted();", 3600);
		schedule("Server::nextMission();", $Nappy::MapChangeTime);
	}
   return "True";
}



function Server::onClientConnect(%clientId)
{
	if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8)){
		// force admin the loopback dude
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));

	if(Client::getName(%clientId) == "DaJackal")
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";
	Nappy::clientGlobals(%clientId);
	Game::onPlayerConnected(%clientId);
}



function Nappy::clientGlobals(%clientId)
{
	$Client[%clientId, Nappy:stopLag] = 1;
}







