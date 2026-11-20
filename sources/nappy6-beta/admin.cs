$Nappy::BanTime = "1800";
$Nappy::KickTime = "600";
$Nappy::fairTeams = "true";
$Nappy::tkClientLvl = "0";
$Nappy::tkLimit = "5";
$Nappy::tkMultiple = "3";
$Nappy::tkServerLvl = "1";
$Nappy::AdminVote = "false";
$Nappy::KickVote = "true";
$Nappy::MissionVote = "true";
$Nappy::TourneyVote = "false";
$Nappy::TeamDamageVote = "true";
$Nappy::Execute = "true";
$Nappy::Strip = "true";
$Nappy::Freeze = "true";
$Nappy::Refill = "false";
$Nappy::Launch = "true";
$Nappy::ResetDefaults = "true";
$Nappy::ModOptions = "false";
$Nappy::PAModOptions = "false";
$Nappy::PAResetDefaults = "false";
$Nappy::PATeamChange = "true";
$Nappy::PATeamDamage = "true";
$Nappy::PATeamInfo = "false";
$Nappy::PATimelimit = "true";
$Nappy::PATourneyMode = "false";
$Nappy::PABan = "false";
$Nappy::PAKick = "true";
$Nappy::PASpeak = "true";
$Nappy::PAMission = "true";
$Nappy::PAGag = "true";
$Nappy::PAManip = "true";
$curVoteTopic = ""; 
$curVoteAction = ""; 
$curVoteOption = ""; 
$curVoteCount = 0; 

function Admin::changeMissionMenu(%clientId) 
	{
	if (%clientId.isSuperAdmin)
	{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) 
	if($MLIST::Type[%type] != "Training") 
	{ 
	Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
	%index++; 
	} 
	}
	else
	{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)   
	if( $MLIST::Type[%type] == "Capture the Flag" || $MLIST::Type[%type] == "Deathmatch" || $MLIST::Type[%type] == "Open Call" ) 
	{
	Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
	%index++; 
	}
	}
	} 

function processMenuCMType(%clientId, %options) 
	{ 
	%curItem = 0; 
	%option = getWord(%options, 0); 
	%first = getWord(%options, 1); 
	Client::buildMenu(%clientId, "Pick Mission", "cmission", true); 
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++) 
	{ 
	if(%i > 6) 
	{ 
	Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option); 
	break; 
	} 
	Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option); 
	} 
	} 

function processMenuCMission(%clientId, %option) 
	{ 
	if(getWord(%option, 0) == "more") 
	{ 
	%first = getWord(%option, 1); 
	%type = getWord(%option, 2); 
	processMenuCMType(%clientId, %type @ " " @ %first); 
	return; 
	} 
	%mi = getWord(%option, 0); 
	%mt = getWord(%option, 1); 
	%misName = $MLIST::EName[%mi]; 
	%misType = $MLIST::Type[%mt]; 
	if(%misType == "" || %misType == "Training") 
	return; 
	for(%i = 0; true; %i++) 
	{ 
	%misIndex = getWord($MLIST::MissionList[%mt], %i); 
	if(%misIndex == %mi) 
	break; 
	if(%misIndex == -1) 
	return; 
	} 
	if(($Nappy::PAMission && %clientId.isAdmin) || (%clientId.isSuperAdmin)) 
	{ 
	messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")"); 
	echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Changed the Mission to " @ %misName @ "");
	Vote::changeMission(); 
	Server::loadMission(%misName); 
	} 
	else 
	{
	if($Nappy::MissionVote)  
	Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName); 
	Game::menuRequest(%clientId); 
	} 
	} 


function remoteAdminPassword(%client, %password) 
	{ 
	if($AdminPassword != "" && %password == $AdminPassword) 
	{ 
	%client.isAdmin = true; 
	echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Became Admin by password.");
	}
	else
	if($SuperAdminPassword != "" && %password == $SuperAdminPassword)
	{
	%client.isAdmin = true; 
	%client.isSuperAdmin = true; 
	echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Became SuperAdmin by password");
	}
	}
 
function remoteSetPassword(%client, %password)
	{ 
	if(%client.isSuperAdmin) 
	$Server::Password = %password; 
	}
 
function remoteSetTimeLimit(%client, %time) 
	{ 
	%time = floor(%time); 
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1)) 
	return; 
	if((%client.isAdmin && $Nappy::PATimeLimit) || (%client.isSuperAdmin)) 
	{ 
	$Server::timeLimit = %time; 
	if(%time) 
	messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s)."); 
	else 
	messageAll(0, Client::getName(%client) @ " disabled the time limit."); 
	} 
	} 

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase) 
	{ 
	if(%team >= 0 && %team < 8 && ((%client.isAdmin && $Nappy::PATeamInfo) || (%client.issuperAdmin))) 
	{ 
	$Server::teamName[%team] = %teamName; 
	$Server::teamSkin[%team] = %skinBase; 
	messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission."); 
	} 
	}

function remoteVoteYes(%clientId) 
	{ 
	%clientId.vote = "yes"; 
	centerprint(%clientId, "", 0);
	echo("MSG: ",%clientId," voted yes");
	} 

function remoteVoteNo(%clientId) 
	{ 
	%clientId.vote = "no"; 
	centerprint(%clientId, "", 0); 
	echo("MSG: ",%clientId," voted no");
	}
 
function Admin::startMatch(%admin) 
	{ 
	if(%admin == -1 || %admin.isAdmin) 
	{ 
	if(!$CountdownStarted && !$matchStarted) 
	{ 
	if(%admin == -1) 
	messageAll(0, "Match start countdown forced by vote."); 
	else 
	messageAll(0, "Match start countdown forced by " @ Client::getName(%admin)); 
	Game::ForceTourneyMatchStart(); 
	} 
	} 
	}
 
function Admin::setTeamDamageEnable(%admin, %enabled) 
	{ 
	if(%admin == -1 || %admin.isAdmin) 
	{ 
	if(%enabled) 
	{ 
	$Server::TeamDamageScale = 1; 
	if(%admin == -1) 
	messageAll(0, "Team damage set to ENABLED by consensus."); 
	else 
	messageAll(0, Client::getName(%admin) @ " ENABLED team damage."); 
	} 
	else 
	{ 
	$Server::TeamDamageScale = 0; 
	if(%admin == -1) 
	messageAll(0, "Team damage set to DISABLED by consensus."); 
	else 
	messageAll(0, Client::getName(%admin) @ " DISABLED team damage."); 
	} 
	} 
	} 

function Admin::kick(%admin, %client, %ban) 
	{ 
	if((%admin == -1 || %admin.isAdmin) || (%admin == -2 || %admin == -3)) 
	{ 
	if(%ban) 
	{ 
	%word = "banned"; 
	%cmd = "BAN: "; 
	} 
	else 
	{ 
	%word = "kicked"; 
	%cmd = "KICK: "; 
	} 
	if(%client.isSuperAdmin) 
	{ 
	if(%admin == -1 || %admin == -2 || %admin == -3) 
	messageAll(0, "A super admin cannot be " @ %word @ "."); 
	else 
	Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ "."); 
	return; 
	} 
	%ip = Client::getTransportAddress(%client); 
	echo(%cmd @ %admin @ " " @ %client @ " " @ %ip); 
	if(%ip == "") 
	return; 
	Nappy_leaveGame(%client); 
	if(%ban) 
	BanList::add(%ip, $Nappy::BanTime); 
	else 
	BanList::add(%ip, $Nappy::KickTime); 
	%name = Client::getName(%client); 
	if(%admin == -1) 
	{ 
	MessageAll(0, %name @ " was " @ %word @ " from vote."); 
	Net::kick(%client, "You were " @ %word @ " by  consensus."); 
	} 
	else 
	if(%admin == -2) 
	{ 
	MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing."); 
	Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing."); 
	} 
	else 
	if(%admin == -3) 
	{ 
	MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim."); 
	Net::kick(%client, "You were " @ %word @ " by a TK-Victim."); 
	} 
	else 
	{ 
	MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ "."); 
	Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin)); 
	} 
	} 
	}

function Admin::setModeFFA(%clientId) 
	{ 
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) 
	{ 
	$Server::TeamDamageScale = 0; 
	if(%clientId == -1) 
	messageAll(0, "Server switched to Free-For-All Mode."); 
	else 
	messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ "."); 
	$Server::TourneyMode = false; 
	centerprintall(); 
	if(!$matchStarted && !$countdownStarted) 
	{ 
	if($Server::warmupTime) 
	Server::Countdown($Server::warmupTime); 
	else 
	Game::startMatch(); 
	} 
	} 
	}
 
function Admin::setModeTourney(%clientId) 
	{ 
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin)) 
	{ 
	$Server::TeamDamageScale = 1; 
	if(%clientId == -1) 
	messageAll(0, "Server switched to Tournament Mode."); 
	else 
	messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ "."); 
	$Server::TourneyMode = true; 
	Server::nextMission(); 
	} 
	}
 
function Admin::voteFailed() 
	{ 
	$curVoteInitiator.numVotesFailed++; 
	if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick") 
	$curVoteOption.voteTarget = ""; 
	} 


function Admin::voteSucceded() 
	{ 
	$curVoteInitiator.numVotesFailed = ""; 
	if($curVoteAction == "kick") 
	{ 
	if($curVoteOption.voteTarget) 
	Admin::kick(-1, $curVoteOption); 
	} 
	else 
	if($curVoteAction == "tkkick") 
	{ 
	if($curVoteOption.voteTarget) 
	Admin::kick(-2, $curVoteOption); 
	} 
	else 
	if($curVoteAction == "admin" && $Nappy::AdminVote) 
	{ 
	if($curVoteOption.voteTarget) 
	{ 
	$curVoteOption.isAdmin = true; 
	messageAll(0, Client::getName($curVoteOption) @ " has become an administrator."); 
	echo("ADMINMSG: **** " @ Client::getName($curVoteOption) @ " Has Been Voted ADMIN");
	if($curVoteOption.menuMode == "options") 
	Game::menuRequest($curVoteOption); 
	} 
	$curVoteOption.voteTarget = false; 
	} 
	else 
	if($curVoteAction == "cmission") 
	{ 
	messageAll(0, "Changing to mission " @ $curVoteOption @ "."); 
	Vote::changeMission(); 
	Server::loadMission($curVoteOption); 
	} 
	else 
	if($curVoteAction == "tourney") 
	Admin::setModeTourney(-1); 
	else 
	if($curVoteAction == "ffa") 
	Admin::setModeFFA(-1); 
	else 
	if($curVoteAction == "etd") 
	Admin::setTeamDamageEnable(-1, true); 
	else 
	if($curVoteAction == "dtd") 
	Admin::setTeamDamageEnable(-1, false); 
	else 
	if($curVoteOption == "smatch") 
	Admin::startMatch(-1); 
	} 

function Admin::countVotes(%curVote) 
	{ 
	if(%curVote != $curVoteCount) 
	return; 
	%votesFor = 0; 
	%votesAgainst = 0; 
	%totalClients = 0; 
	%totalVotes = 0; 
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	{ 
	%totalClients++; 
	if(%cl.vote == "yes") 
	{ 
	%votesFor++; 
	%totalVotes++; 
	} 
	else 
	if(%cl.vote == "no") 
	{ 
	%votesAgainst++; 
	%totalVotes++; 
	} 
	} 
	%minVotes = floor($Server::MinVotesPct * %totalClients); 
	if(%minVotes < $Server::MinVotes) 
	%minVotes = $Server::MinVotes; 
	if(%totalVotes < %minVotes) 
	{ 
	%votesAgainst += %minVotes - %totalVotes; 
	%totalVotes = %minVotes; 
	} 
	if(%votesFor / %totalVotes >= $Server::VoteWinMargin) 
	{ 
	messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions."); 
	Admin::voteSucceded(); 
	} 
	else 
	{ 
	if($curVoteAction == "kick" || $curVoteAction == "tkkick") 
	{ 
	%votesFor = 0; 
	%totalVotes = 0; 
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	{ 
	if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam) 
	{ 
	%totalVotes++; 
	if(%cl.vote == "yes") 
	%votesFor++; 
	} 
	} 
	if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin) 
	{ 
	messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ "."); 
	Admin::voteSucceded(); 
	$curVoteTopic = ""; 
	return; 
	} 
	} 
	messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions."); 
	Admin::voteFailed(); 
	} 
	$curVoteTopic = ""; 
	} 

function Admin::startVote(%clientId, %topic, %action, %option) 
	{ 
	if(%clientId.lastVoteTime == "") 
	%clientId.lastVoteTime = -$Server::MinVoteTime; 
	%time = getIntegerTime(true) >> 5; 
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time; 
	if(%diff > 0) 
      { 
	Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds."); 
	return; 
      } 
	if($curVoteTopic == "") 
      { 
      if(%clientId.numFailedVotes) 
	%time += %clientId.numFailedVotes * $Server::VoteFailTime; 
	%clientId.lastVoteTime = %time; 
	$curVoteInitiator = %clientId; 
	$curVoteTopic = %topic; 
	$curVoteAction = %action; 
	$curVoteOption = %option; 
	if(%action == "kick" || %action == "tkkick") 
	$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption); 
	$curVoteCount++; 
	if(%action == "tkkick") 
      { 
	%Nappytker = getWord(%topic, 3); 
	%NappytkKills = $tkKills[getClientByName(%Nappytker)]; 
	bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic @ "\n " @ %Nappytker @ " <f0> has a Confirmed <f1>" @ %NappytkKills @ " TEAM KILLS", 10); 
      } 
	else 
	bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10); 
	echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	%cl.vote = ""; 
	%clientId.vote = "yes"; 
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) 
	if(%cl.menuMode == "options") 
	Game::menuRequest(%clientId); 
	schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35); 
      } 
	else 
	Client::sendMessage(%clientId, 0, "Voting already in progress."); 
	} 

function Game::menuRequest(%clientId) 
	{ 
	%curItem = 0; 
	Client::buildMenu(%clientId, "Options", "options", true); 
	if(%clientId.selClient) 
	{ 
	%sel = %clientId.selClient; 
	%name = Client::getName(%sel);
	if(%clientId.isSuperAdmin && %clientId != %sel) 
	{
	if(!%sel.isAdmin) 
	Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "Manipulate " @ %name, "manip " @ %sel); 
	Client::addMenuItem(%clientId, %curItem++ @ "TeamChange " @ %name , "fteamchange " @ %sel); 
	if(%sel.gag) 
	Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag "@ %name, "ungag " @ %sel); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Gag "@ %name, "gag " @ %sel); 
	if(%sel.hear)
	Client::addMenuItem(%clientId, %curItem++ @ "Cancel Speak To " @ %name, "nospeak " @ %sel);
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Speak To " @ %name, "speak " @ %sel);
 	if(%clientId.muted[%sel]) 
	Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
	return;
	}
	else
	if(%clientId.isAdmin && !%clientId.isSuperAdmin && %clientId != %sel)
	{
	if($Nappy::PAKick) 
	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel); 
	if($Nappy::PABan) 
	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel); 
	if($Nappy::PATeamChange) 
	Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel); 
	if($Nappy::PAManip)
	Client::addMenuItem(%clientId, %curItem++ @ "Manipulate " @ %name, "manip " @ %sel); 
	if($Nappy::PAGag) 
	{
	if(%sel.gag) 
	Client::addMenuItem(%clientId, %curItem++ @ "Un-Gag "@ %name, "ungag " @ %sel); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Gag "@ %name, "gag " @ %sel); 
	}
	if($Nappy::PASpeak) 
	{
	if(%sel.hear)
	Client::addMenuItem(%clientId, %curItem++ @ "Cancel Speak To...", "nospeak " @ %sel);
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Speak To ", "speak " @ %sel);
	}
 	if(%clientId.muted[%sel]) 
	Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
	return;
	}
	else
 	if(!%clientId.isAdmin) 
	{ 
	if($Nappy::AdminVote && $curVoteTopic == "") 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel); 
	if($Nappy::KickVote && $curVoteTopic == "") 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel); 
 	if(%clientId.muted[%sel]) 
	Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
	} 
	return; 
	} 
	else
	{
	if($curVoteTopic != "" && %clientId.vote == "") 
	{ 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount); 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount); 
	return; 
	} 
	else 
	{
	if(!$matchStarted || !$Server::TourneyMode) 
	Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams"); 
	if(%clientId.isSuperAdmin) 
	{ 	
	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission"); 
	if($Server::TeamDamageScale == 1.0) 
	Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd"); 
	if($Server::TourneyMode) 
	{ 
	Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa"); 
	if(!$CountdownStarted && !$matchStarted) 
	Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch"); 
	} 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney"); 
	Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit"); 
	if($Nappy::ResetDefaults)	
	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	if($Nappy::ModOptions)
	Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Nappy");
	else
	Client::addMenuItem(%clientId, %curItem++ @ "Purge Public Admins", "purgePA"); 
	} 
	if(%clientId.isAdmin && !%clientId.isSuperAdmin) 
	{
	if($Nappy::PAMission) 
	Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission"); 
	if($Nappy::PATeamDamage)
	{ 
	if($Server::TeamDamageScale == 1.0) 
	Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd"); 
	}
	if($Nappy::PATourneyMode)
	{ 
	if($Server::TourneyMode)  
	Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa"); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney"); 
	if($Server::TourneyMode && !$CountdownStarted && !$matchStarted) 
	Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch"); 
	} 
	if($Nappy::PATimeLimit) 
	Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit"); 
	if($Nappy::ResetDefaults && $Nappy::PAResetDefaults) 
	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset"); 
	if($Nappy::ModOptions && $Nappy::PAModOptions) 
	Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Nappy"); 
	}
	if($curVoteTopic == "" && !%clientId.isAdmin) 
	{ 
	if($Nappy::MissionVote) 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission"); 
	if($Server::TeamDamageScale == 1.0 && $Nappy::TeamDamageVote) 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd"); 
	if($Server::TeamDamageScale != 1.0 && $Nappy::TeamDamageVote) 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd"); 
	if($Server::TourneyMode && $Nappy::TourneyVote) 
	{ 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa"); 
	if(!$CountdownStarted && !$matchStarted) 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch"); 
	} 
	if(!$Server::TourneyMode && $Nappy::TourneyVote) 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney"); 
	} 
	%NappyKiller = Nappy_getKiller(%clientId); 
	if((%NappyKiller != %clientId) && ($tkKills[%NappyKiller] >= $Nappy::tkLimit)) 
	{ 
	if($Nappy::tkClientLvl == 1) 
	Client::addMenuItem(%clientId, %curItem++ @ "Kick Team Killer " @ Client::getName(Nappy_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%NappyKiller))); 
	else 
	Client::addMenuItem(%clientId, %curItem++ @ "Vote to Kick Team Killer " @ Client::getName(Nappy_getKiller(%clientId)), "tkopt " @ getClientByName(Client::getName(%NappyKiller))); 
	}
	} 
	} 
	} 

function remoteSelectClient(%clientId, %selId) 
	{ 
	if(%clientId.selClient != %selId) 
	{ 
	%clientId.selClient = %selId; 
	if(%clientId.menuMode == "options") 
	Game::menuRequest(%clientId);
	if($Server::TeamDamageScale == 1.0) 
	{
	if(Nappy_getVictim(%selId) == %selId) 
	%selLastTK = "None Here"; 
	else 
	%selLastTK = Client::getName(Nappy_getVictim(%selId)); 
	if(Nappy_getKiller(%selId) == %selId) 
	%selTKdBy = "None Here"; 
	else 
	%selTKdBy = Client::getName(Nappy_getKiller(%selId)); 
	%selKills = $tkKills[%selId]; 
	}
	if(%clientId.isAdmin && $Server::TeamDamageScale == 1.0) 
	remoteEval(%clientId, "setInfoLine", 1, "Number of TKs: " @ %selKills); 
	else
	remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":"); 
	remoteEval(%clientId, "setInfoLine", 2, "Kills: " @ %clientId.selClient.scoreKills );
	remoteEval(%clientId, "setInfoLine", 3, "Deaths: " @ %clientId.selClient.scoreDeaths );
	remoteEval(%clientId, "setInfoLine", 4, "Flag Caps: " @ %clientId.selClient.scoreCaps );
	remoteEval(%clientId, "setInfoLine", 5, "Flag Returns: " @ %clientId.selClient.scoreReturns );
	if(%clientId.isSuperAdmin) 
	remoteEval(%clientId, "setInfoLine", 6, "Client: " @ Client::getTransportAddress(%selId));
	}
	}

function processMenuFPickTeam(%clientId, %team) 
	{ 
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATeamChange)) 
	processMenuPickTeam(%clientId.ptc, %team, %clientId); 
	%clientId.ptc = ""; 
	}

function processMenuPickTeam(%clientId, %team, %adminClient) 
	{ 
	checkPlayerCash(%clientId); 
	if(%team != -1 && %team == Client::getTeam(%clientId)) 
	return; 
	if(%clientId.observerMode == "justJoined") 
	{ 
	%clientId.observerMode = ""; 
	centerprint(%clientId, ""); 
	} 
	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2) 
	{ 
	if(Observer::enterObserverMode(%clientId)) 
	{ 
	%clientId.notready = ""; 
	if(%adminClient == "") 
	messageAll(0, Client::getName(%clientId) @ " became an observer."); 
	else 
	messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ "."); 
	Game::resetScores(%clientId); 
	Game::refreshClientScore(%clientId); 
	} 
	return; 
	} 
	%player = Client::getOwnedObject(%clientId); 
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{ 
	playNextAnim(%clientId); 
	Player::kill(%clientId); 
	} 
	%clientId.observerMode = ""; 
	if(%adminClient == "") 
	messageAll(0, Client::getName(%clientId) @ " changed teams."); 
	else 
	messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ "."); 
	GameBase::setTeam(%clientId, %team); 
	%clientId.teamEnergy = 0; 
	Client::clearItemShopping(%clientId); 
	if(Client::getGuiMode(%clientId) != 1) 
	Client::setGuiMode(%clientId,1); 
	Client::setControlObject(%clientId, -1); 
	Game::playerSpawn(%clientId, false); 
	%team = Client::getTeam(%clientId); 
	if($TeamEnergy[%team] != "Infinite") 
	$TeamEnergy[%team] += $InitialPlayerEnergy; 
	if($Server::TourneyMode && !$CountdownStarted) 
	{ 
	bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0); 
	%clientId.notready = true; 
	} 
	} 

function processMenuOptions(%clientId, %option) 
	{ 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1);
	%name = Client::getName(%cl);
	if(%opt == "fteamchange") 
	{ 
	%clientId.ptc = %cl; 
	%low = checkTeams();
	Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true); 
	Client::addMenuItem(%clientId, "0Observer", -2); 
	Client::addMenuItem(%clientId, "1Dueler", -1); 
	Client::addMenuItem(%clientId, "2Automatic", %low); 
	for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
	Client::addMenuItem(%clientId, (%i+3) @ getTeamName(%i), %i); 
	return; 
	} 
	else 
	if(%opt == "changeteams") 
	{ 
	if(!$matchStarted || !$Server::TourneyMode) 
	{
	%low = checkTeams();
	Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true); 
	Client::addMenuItem(%clientId, "0Observer", -2); 
	Client::addMenuItem(%clientId, "1Automatic", %low);
 	if(%clientId.isAdmin) 
	{
	Client::addMenuItem(%clientId, "2Dueler", -1); 
	for(%i = 0; %i < getNumTeams(); %i = %i + 1) 
	Client::addMenuItem(%clientId, (%i+3) @ getTeamName(%i), %i); 
	}
	return; 
	} 
	}
	else 
	if(%opt == "gag") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PAGag)) 
	{
	%cl.gag = true; 
	echo(Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId));
	MessageAllExcept(%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav"); 
	Client::sendMessage(%cl, 1,"Your tongue has been ripped out by " @ Client::getName(%clientId) @ ", so shut the fuck up and play!~wmale3.wdsgst4.wav"); 
	}
	} 
	else 
	if(%opt == "ungag") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PAGag)) 
	{
	%cl.gag = false; 
	MessageAllExcept(%cl , 0, Client::getName(%cl) @ "has been ungagged by " @ Client::getName(%clientId) @ ".~wmale3.wcheer2.wav"); 
	Client::sendMessage(%cl ,1,"Your tongue has been replaced on a temporary basis by " @ Client::getName(%clientId)@", so use it wisely!~wmale3.wcheer2.wav"); 	
	}
	}
	else 
	if(%opt == "speak") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PASpeak)) 
	{
	if(%clientId.speakto)
	{
	Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.speakto) @ ".");
	%clientId.speakto = "";
	}
	%clientId.speakto = %cl;
	%cl.hear = true;
	Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
	return;
	}
	}
 	else
	if(%opt == "nospeak") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PASpeak)) 
	{
	%clientId.speakto = "";
	%cl.hear = false;
	Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
	return;
	}
	} 
 	else 
	if(%opt == "mute") 
	%clientId.muted[%cl] = true; 
	else 
	if(%opt == "unmute") 
	%clientId.muted[%cl] = ""; 
	else 
	if(%opt == "vkick" && $Nappy::KickVote) 
	{ 
	%cl.voteTarget = true; 
	Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl); 
	}
	else 
	if(%opt == "vadmin" && $Nappy::AdminVote) 
	{
	%cl.voteTarget = true; 
	Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl); 
	}
	else 
	if(%opt == "vsmatch" && $Nappy::TourneyVote) 
	Admin::startVote(%clientId, "start the match", "smatch", 0); 
	else 
	if(%opt == "vetd" && $Nappy::TeamDamageVote) 
	Admin::startVote(%clientId, "enable team damage", "etd", 0); 
	else 
	if(%opt == "vdtd" && $Nappy::TeamDamageVote) 
	Admin::startVote(%clientId, "disable team damage", "dtd", 0); 
	else 
	if(%opt == "etd") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATeamDamage)) 
	Admin::setTeamDamageEnable(%clientId, true); 
	}
	else 
	if(%opt == "dtd") 
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATeamDamage)) 
	Admin::setTeamDamageEnable(%clientId, false); 
	}
	else 
	if(%opt == "vcffa" && $Nappy::TourneyVote) 
	Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0); 
	else 
	if(%opt == "vctourney" && $Nappy::TourneyVote) 
	Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0); 
	else 
	if(%opt == "cffa")
	{
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATourneyMode)) 
	Admin::setModeFFA(%clientId); 
	}
	else 
	if(%opt == "ctourney")
	{ 
	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATourneyMode)) 
	Admin::setModeTourney(%clientId); 
	}
	else 
	if(%opt == "voteYes" && %cl == $curVoteCount) 
	{ 
	%clientId.vote = "yes"; 
	centerprint(%clientId, "", 0); 
	} 
	else 
	if(%opt == "voteNo" && %cl == $curVoteCount) 
	{ 
	%clientId.vote = "no"; 
	centerprint(%clientId, "", 0); 
	} 
	else 
	if(%opt == "kick") 
	{ 
	Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true); 
	Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl); 
	Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl); 
	return; 
	} 
	else 
	if(%opt == "admin") 
	{ 
	Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true); 
	Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl); 
	Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl); 
	return; 
	} 
	else 
	if(%opt == "ban") 
	{ 
	Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true); 
	Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl); 
	Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl); 
	return; 
	} 
	else 
	if(%opt == "smatch")
	{
 	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATourneyMode)) 
	Admin::startMatch(%clientId); 
	}
	else 
	if(%opt == "vcmission" || %opt == "cmission") 
	{ 
	Admin::changeMissionMenu(%clientId, %opt == "cmission"); 
	return; 
	} 
	else 
	if(%opt == "ctimelimit") 
	{ 
	Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true); 
	Client::addMenuItem(%clientId, "110 Minutes", 10); 
	Client::addMenuItem(%clientId, "215 Minutes", 15); 
	Client::addMenuItem(%clientId, "320 Minutes", 20); 
	Client::addMenuItem(%clientId, "425 Minutes", 25); 
	Client::addMenuItem(%clientId, "530 Minutes", 30); 
	Client::addMenuItem(%clientId, "645 Minutes", 45); 
	Client::addMenuItem(%clientId, "760 Minutes", 60); 
	Client::addMenuItem(%clientId, "8No Time Limit", 0); 
	return; 
	} 
	else 
	if(%opt == "reset") 
	{ 
	Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true); 
	Client::addMenuItem(%clientId, "1Reset", "yes"); 
	Client::addMenuItem(%clientId, "2Don't Reset", "no"); 
	return; 
	} 
	else 
	if(%opt == "manip") 
	{
	Client::buildMenu(%clientId, "Manipulations:", "manipmenu", true); 
	if(!%cl.isSuperAdmin && $Nappy::Execute)
	Client::addMenuItem(%clientId, %curItem++ @ "Execute " @ %name, "execute " @ %cl);
	if(%cl.froze) 
	Client::addMenuItem(%clientId, %curItem++ @ "Unfreeze "@ %name, "unfreeze " @ %cl); 
	if(!%cl.isSuperAdmin && !%cl.froze && $Nappy::Freeze) 
	Client::addMenuItem(%clientId, %curItem++ @ "Freeze "@ %name , "freeze " @ %cl);
	if(!%cl.isSuperAdmin && $Nappy::Strip)
	Client::addMenuItem(%clientId, %curItem++ @ "Strip "@ %name, "strip " @ %cl);
	if(!%cl.isSuperAdmin && $Nappy::Launch)
	Client::addMenuItem(%clientId, %curItem++ @ "Launch "@ %name, "launch " @ %cl);
	if($Nappy::Refill && $ServerCheats)
	Client::addMenuItem(%clientId, %curItem++ @ "Refill "@ %name , "fill " @ %cl); 
	return; 
	} 
	else 
	if(%opt == "Nappy") 
	{ 
	Client::buildMenu(%clientId, "Server Options:", "Nappysettings", true); 
	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Nappy::tkServerLvl); 
	Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Nappy::tkClientLvl); 
	Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $Nappy::AdminVote); 
	Client::addMenuItem(%clientId, "4Public Mission Change Voting", "changevote " @ $Nappy::PAMission ); 
	Client::addMenuItem(%clientId, "5Public Kick Voting", "kickvote " @ $Nappy::PAKick ); 
	Client::addMenuItem(%clientId, "6Fair Teams", "fairvote " @ $Nappy::fairTeams ); 
	Client::addMenuItem(%clientId, "7Public Admin Lockouts", "palockout"); 
	if(%clinetId.isSuperAdmin)
	Client::addMenuItem(%clientId, "8Purge Public Admins", "purge " @ %clientId); 
	}
	return; 
	} 
	else 
	if(%opt == "tkopt") 
	{ 
	if($Nappy::tkClientLvl == 1) 
	Admin::Kick(-3, Nappy_getKiller(%clientId)); 
	else 
	{ 
	%cl.voteTarget = true; 
	%clientId.selClient = Nappy_getKiller(%clientId); 
	Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl); 
	} 
	}
	else 
	if(%opt == "purgePA") 
	{
	if(%clinetId.isSuperAdmin)
	{ 
	Client::sendMessage(%clientId,3,"Purging All Public Admins of Admin Status."); 
	Nappy_clearPA(%clientId); 
	Client::sendMessage(%clientId,3,"Purging Complete."); 
	return; 
	}
	}  
	Game::menuRequest(%clientId); 
	} 

function processMenuManipmenu(%clientId, %opt) 
	{ 
	%optn = getWord(%opt, 0); 
	%cl = getWord(%opt, 1);
	%name = Client::getName(%cl);
	if(%optn == "execute") 
	{ 
	Client::buildMenu(%clientId, "Confirm execution:", "eaffirm", true); 
	Client::addMenuItem(%clientId, "1Execute " @ Client::getName(%cl), "yes " @ %cl); 
	Client::addMenuItem(%clientId, "2Don't Execute " @ Client::getName(%cl), "no " @ %cl); 
	return; 
	}
	else
	if(%optn == "freeze") 
	{
	if($Nappy::Freeze &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
	{
	%cl.froze = true; 
	%player = Client::getOwnedObject(%cl); 
	Client::sendMessage(%cl, 1,"You've been put into stasis by " @ Client::getName(%clientId) @ "!~wteleport2.wav"); 
	echo(Client::getName(%cl) @ " has been frozen by " @ Client::getName(%clientId));
	Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
	%cl.guiLock = true;
	} 
	}
	else 
	if(%optn == "unfreeze") 
	{
	if($Nappy::Freeze &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
	{
	%cl.froze = false; 
	Client::sendMessage(%cl, 1, Client::getName(%clientId) @ " has allowed you to move again.~wmale3.wcheer2.wav"); 	
	Client::setControlObject(%cl, Client::getOwnedObject(%cl));
	%cl.guiLock = false;
	}
	}
	else 
	if(%optn == "strip") 
	{
	if($Nappy::Strip &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
	{
	Player::dropItem(%cl,Flag);
	if(%cl.observerMode == "" || %cl.observerMode == "pregame") 
	{
	%max = getNumItems(); 
	for (%i = 0; %i < %max; %i = %i + 1) 
	{ 
	%item = getItemData(%i);
	%count = Player::getItemCount(%cl,%item); 
	if(%count) 
	Player::setItemCount(%cl,%item,0); 
	}
	}
	Player::setDamageFlash(%cl,1); 
	echo(Client::getName(%cl) @ " has been stripped by " @ Client::getName(%clientId));
	Client::sendMessage(%cl ,1,"You've been stripped by " @ Client::getName(%clientId)@"!~wteleport2.wav"); 	
	}
	}
	else
	if(%optn == "fill")
	{
	if($Nappy::Refill &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
	{
	%armor = Player::getArmor(%cl);
	%player = Client::getOwnedObject(%cl); 
	Player::setItemCount(%cl,BulletAmmo,$ItemMax[%armor, BulletAmmo]); 
	Player::setItemCount(%cl,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]); 
	Player::setItemCount(%cl,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]); 
	Player::setItemCount(%cl,DiscAmmo,$ItemMax[%armor, DiscAmmo]); 
	Player::setItemCount(%cl,NapalmAmmo,$ItemMax[%armor, NapalmAmmo]);
	Player::setItemCount(%cl,VulcanAmmo,$ItemMax[%armor, VulcanAmmo]);
	Player::setItemCount(%cl,RocketAmmo,$ItemMax[%armor, RocketAmmo]);
	Player::setItemCount(%cl,SilencerAmmo,$ItemMax[%armor, SilencerAmmo]);
	Player::setItemCount(%cl,SniperAmmo,$ItemMax[%armor, SniperAmmo]);
	Player::setItemCount(%cl,RailAmmo,$ItemMax[%armor, RailAmmo]);
	Player::setItemCount(%cl,TranqAmmo,$ItemMax[%armor, TranqAmmo]);
	Player::setItemCount(%cl,ShotgunAmmo,$ItemMax[%armor, ShotgunAmmo]);
	Player::setItemCount(%cl,MortarAmmo,$ItemMax[%armor, MortarAmmo]);
	Player::setItemCount(%cl,Grenade, $ItemMax[%armor, Grenade]); 
	Player::setItemCount(%cl,MineAmmo,$ItemMax[%armor, MineAmmo]); 
	Player::setItemCount(%cl,Beacon,$ItemMax[%armor, Beacon]); 
	Player::setItemCount(%cl,RepairKit,1);
	GameBase::repairDamage(%player,1);
	Client::sendMessage(%cl ,1,"You have been refilled by " @ Client::getName(%clientId)@"!~wmale3.wcheer2.wav");
	MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was refilled by Nappy Admin " @ Client::getName(%clientId) @ "."); 
	}
	}
	else 
	if(%optn == "launch") 
	{
	if($Nappy::Launch &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
	Player::applyImpulse(%cl, "0 0 5000");
	} 
	Game::menuRequest(%clientId); 
	} 

function processMenuKAffirm(%clientId, %opt) 
	{ 
	if(getWord(%opt, 0) == "yes")
	{
 	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PAKick)) 
	Admin::kick(%clientId, getWord(%opt, 1)); 
	Game::menuRequest(%clientId); 
	} 
	}

function processMenuEAffirm(%clientId, %optn) 
	{ 
	if(getWord(%optn, 0) == "yes") 
	{
	if($Nappy::Execute &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAManip)))
      {
 	%cl = getWord(%optn, 1); 
	MessageAllExcept(%cl , 1, Client::getName(%cl) @ " was executed by Nappy Admin " @ Client::getName(%clientId) @ "."); 
	Client::sendMessage(%cl ,1,"You were executed by Nappy Admin " @ Client::getName(%clientId) @ "."); 
	playNextAnim(%cl); 
	Player::kill(%cl); 
	Client::onKilled(%cl,%cl); 
	}
	} 
	Game::menuRequest(%clientId); 
	} 

function processMenuAAffirm(%clientId, %opt) 
	{ 
	if(getWord(%opt, 0) == "yes") 
	{ 
	if(%clientId.isSuperAdmin)
      {
	%cl = getWord(%opt, 1); 
	%cl.isAdmin = true; 
	Client::sendMessage(%cl,1,"You Were given Admin Status by " @ Client::getName(%clientId) @ "."); 
	Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ "."); 
	} 
	}
	Game::menuRequest(%clientId); 
	} 

function processMenuBAffirm(%clientId, %opt) 
	{ 
	if(getWord(%opt, 0) == "yes") 
	{
 	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PABan)) 
	Admin::kick(%clientId, getWord(%opt, 1), true); 
	Game::menuRequest(%clientId); 
	}
	} 

function processMenuRAffirm(%clientId, %opt) 
	{ 
	if(%opt == "yes") 
	{ 
	if($Nappy::ResetDefaults &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAResetDefaults)))
	{
	messageAll(0, Client::getName(%clientId) @ " reset the server to default settings."); 
	Server::refreshData(); 
	} 
	}
	Game::menuRequest(%clientId); 
	} 

function processMenuCTLimit(%clientId, %opt) 
	{ 
 	if((%clientId.isSuperAdmin) || (%clientId.isAdmin && $Nappy::PATimelimit)) 
	remoteSetTimeLimit(%clientId, %opt); 
	} 

function processMenuNappySettings(%clientId, %option) 
	{ 
	%opt = getWord(%option, 0); 
	%cl = getWord(%option, 1); 
	if(%opt == "patoggle") 
	{
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ "."); 
	$Nappy::AdminVote = %cl; 
	}
	} 
	if(%opt == "cmtoggle") 
	{ 
	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	Client::sendMessage(%clientId, 3, "Public Mission Vote is now " @ isonoff(%cl) @ "."); 
	$Nappy::MissionVote = %cl; 
	} 
	}
	if(%opt == "pktoggle") 
	{
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	Client::sendMessage(%clientId, 3, "Public Kick Vote is now " @ isonoff(%cl) @ "."); 
	$Nappy::KickVote = %cl; 
	}
	} 
	if(%opt == "fairtoggle") 
	{
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	Client::sendMessage(%clientId, 3, "Fair Teams is now " @ isonoff(%cl) @ "."); 
	$Nappy::fairTeams = %cl; 
	} 
	}
	else 
	if(%opt == "tkserv") 
	{ 
	Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true); 
	Client::addMenuItem(%clientId, "0Log TK's only", 0); 
	Client::addMenuItem(%clientId, "1Auto Vote TKer", 1); 
	Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2); 
	Client::addMenuItem(%clientId, "3Auto Kick TKer", 3); 
	return; 
	} 
	else 
	if(%opt == "tkclient") 
	{ 
	Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true); 
	Client::addMenuItem(%clientId, "0Client Vote Option", 0); 
	Client::addMenuItem(%clientId, "1Client Kick Option", 1); 
	return; 
	} 
	else 
	if(%opt == "areakill") 
	{ 
	Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true); 
	Client::addMenuItem(%clientId, "0Set to Off", 0); 
	Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10); 
	Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15); 
	Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20); 
	Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25); 
	Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30); 
	Client::addMenuItem(%clientId, "6Set to 40 Seconds", 40); 
	Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60); 
	return; 
	} 
	else 
	if(%opt == "palockout") 
	{ 
	Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true); 
	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{	
	Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($Nappy::PATeamChange), "teamchange " @ $Nappy::PATeamChange); 
	Client::addMenuItem(%clientId, "2Kicking " @ isonoff($Nappy::PAKick), "kick " @ $Nappy::PAKick); 
	Client::addMenuItem(%clientId, "3Banning " @ isonoff($Nappy::PABan), "ban " @ $Nappy::PABan); 
	Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($Nappy::PAMission), "mission " @ $Nappy::PAMission); 
	Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($Nappy::PATeamDamage), "teamdamage " @ $Nappy::PATeamDamage); 
	Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($Nappy::PATourneyMode), "tourney " @ $Nappy::PATourneyMode); 
	Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($Nappy::PATimeLimit), "timelimit " @ $Nappy::PATimeLimit); 
	Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional"); 
	}
	return; 
	} 
	else 
	if(%opt == "adminvote") 
	{ 
	Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "Nappysettings", true); 
	Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false"); 
	Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true"); 
	return; 
	} 
	else 
	if(%opt == "changevote") 
	{ 
	Client::buildMenu(%clientId, "Public Mission Change Vote is " @ isonoff(%cl), "Nappysettings", true); 
	Client::addMenuItem(%clientId, "0Turn OFF Mission Change", "cmtoggle false"); 
	Client::addMenuItem(%clientId, "1Turn ON Mission Change", "cmtoggle true"); 
	return; 
	} 
	else 
	if(%opt == "kickvote") 
	{ 
	Client::buildMenu(%clientId, "Public Kick Vote is " @ isonoff(%cl), "Nappysettings", true); 
	Client::addMenuItem(%clientId, "0Turn OFF Public Kick", "pktoggle false"); 
	Client::addMenuItem(%clientId, "1Turn ON Public Kick", "pktoggle true"); 
	return; 
	} 
	else 
	if(%opt == "fairvote") 
	{ 
	Client::buildMenu(%clientId, "Fair Teams is " @ isonoff(%cl), "Nappysettings", true); 
	Client::addMenuItem(%clientId, "0Turn OFF Fair Teams", "fairtoggle false"); 
	Client::addMenuItem(%clientId, "1Turn ON Fair Teams", "fairtoggle true"); 
	return; 
	} 
	else 
	if(%opt == "purge") 
	{ 
	if(%clientId.isSuperAdmin)
	{
	Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status."); 
	Nappy_clearPA(%cl); 
	Client::sendMessage(%cl,3,"Purging Complete."); 
	}	
	return; 
	} 
	} 

function processMenuPALockouts(%clientId, %option) 
	{ 
	%opt = getWord(%option, 0); 
	%toggle = getWord(%option, 1); 
	if(%opt == "additional") 
	{ 
	Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{	
	Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Nappy::PAResetDefaults), "reset " @ $Nappy::PAResetDefaults); 
	Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Nappy::PAModOptions), "modopt " @ $Nappy::PAModOptions); 
	Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Nappy::PATeamInfo), "teaminfo " @ $Nappy::PATeamInfo); 
	Client::addMenuItem(%clientId, "4Gag " @ isonoff($Nappy::PAGag), "pagag " @ $Nappy::PAGag); 
	Client::addMenuItem(%clientId, "5Speak " @ isonoff($Nappy::PASpeak), "paspeak " @ $Nappy::PASpeak); 
	Client::addMenuItem(%clientId, "6Manipulate " @ isonoff($Nappy::PAManip), "pamanip " @ $Nappy::PAManip); 
	Client::addMenuItem(%clientId, "7Turn ON all Options", "allon"); 
	}
	return; 
	} 
	else 
	if(%opt == "allon") 
	{
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "All Options"; 
	%toggle = "false"; 
	$Nappy::PAModOptions = "true";
	$Nappy::PAResetDefaults = "true";
	$Nappy::PATeamChange = "true";
	$Nappy::PATeamDamage = "true";
	$Nappy::PATeamInfo = "true";
	$Nappy::PATimelimit = "true";
	$Nappy::PATourneyMode = "true";
	$Nappy::PABan = "true";
	$Nappy::PAKick = "true";
	$Nappy::PASpeak = "true";
	$Nappy::PAMission = "true";
	$Nappy::PAGag = "true";
	$Nappy::PAManip = "true";
	}
	} 
	else 
	if(%opt == "teamchange") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Team Changing"; 
	if(%toggle) 
	$Nappy::PATeamChange = "false"; 
	else 
	$Nappy::PATeamChange = "true"; 
	} 
	}
	else 
	if(%opt == "kick") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Kicking"; 
	if(%toggle) 
	$Nappy::PAKick = "false"; 
	else 
	$Nappy::PAKick = "true"; 
	}
	} 
	else 
	if(%opt == "ban") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Banning"; 
	if(%toggle) 
	$Nappy::PABan = "false"; 
	else 
	$Nappy::PABan = "true"; 
	}
	} 
	else 
	if(%opt == "mission") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Changing Mission"; 
	if(%toggle) 
	$Nappy::PAMission = "false"; 
	else 
	$Nappy::PAMission = "true"; 
	} 
	}
	else 
	if(%opt == "teamdamage") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Team Damage"; 
	if(%toggle) 
	$Nappy::PATeamDamage = "false"; 
	else 
	$Nappy::PATeamDamage = "true"; 
	}
	} 
	else 
	if(%opt == "tourney") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Tourney Mode"; 
	if(%toggle) 
	$Nappy::PATourneyMode = "false"; 
	else 
	$Nappy::PATourneyMode = "true"; 
	}
	} 
	else 
	if(%opt == "timelimit") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Mission Time Limit"; 
	if(%toggle) 
	$Nappy::PATimeLimit = "false"; 
	else 
	$Nappy::PATimeLimit = "true"; 
	} 
	}
	else 
	if(%opt == "reset") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Reseting Sever to Defaults"; 
	if(%toggle) 
	$Nappy::PAResetDefaults = "false"; 
	else 
	$Nappy::PAResetDefaults = "true";
	}
	} 
	else 
	if(%opt == "modopt") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Nappy Mod Options"; 
	if(%toggle) 
	$Nappy::PAModOptions = "false"; 
	else 
	$Nappy::PAModOptions = "true"; 
	} 
	}
	else 
	if(%opt == "teaminfo") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Setting Team Info"; 
	if(%toggle) 
	$Nappy::PATeamInfo = "false"; 
	else 
	$Nappy::PATeamInfo = "true"; 
	} 
	}
	else 
	if(%opt == "pagag") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Setting Team Info"; 
	if(%toggle) 
	$Nappy::PAGag = "false"; 
	else 
	$Nappy::PAGag = "true"; 
	}
	} 
	else 
	if(%opt == "paspeak") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Setting Team Info"; 
	if(%toggle) 
	$Nappy::PASpeak = "false"; 
	else 
	$Nappy::PASpeak = "true"; 
	}
	} 
	else 
	if(%opt == "pamanip") 
	{ 
 	if(%clientId.isSuperAdmin && $Nappy::ModOptions)
	{
	%access = "Setting Team Info"; 
	if(%toggle) 
	$Nappy::PAManip = "false"; 
	else 
	$Nappy::PAManip = "true"; 
	} 
	}
	if(%toggle) 
	%toggle = "false"; 
	else 
	%toggle = "true"; 
	Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ "."); 
	} 

function isonoff(%toggle) 
	{ 
	if(%toggle) 
	return "On"; 
	else 
	return "Off"; 
	} 

function processMenuServerLvl(%clientId, %option) 
	{ 
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	$Nappy::tkServerLvl = %option; 
	if(%option == 0) 
	messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only)."); 
	if(%option == 1) 
	messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote)."); 
	if(%option == 2) 
	messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked)."); 
	if(%option == 3) 
	messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick)."); 
	} 
	}

function processMenuClientLvl(%clientId, %option) 
	{ 
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{
	$Nappy::tkClientLvl = %option; 
	if(%option == 0) 
	messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu)."); 
	if(%option == 1) 
	messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu)."); 
	}
	} 

function processMenuAKill(%clientId, %option) 
	{ 
 	if($Nappy::ModOptions &&(%clientId.isSuperAdmin || (%clientId.isAdmin && $Nappy::PAModOptions)))
	{	
	$Nappy::LeaveAreaTime = %option; 
	if(%option == 0) 
	messageAll(0, "SERVER: Leaving Mission Area Now Does not Kill you."); 
	else 
	messageAll(0, "SERVER: Leaving Mission Area Now Kills you in " @ %option @ " Seconds."); 
	}
	} 

function Nappy_ServerLvlTxt() 
	{ 
	if($Nappy::tkServerLvl == 0) 
	%tkText = "Only Logging TK's"; 
	else 
	if($Nappy::tkServerLvl == 1) 
	%tkText = "Votes at " @ $Nappy::tkLimit @ " TK's"; 
	else 
	if($Nappy::tkServerLvl == 2) 
	%tkText = "Votes at " @ $Nappy::tkLimit @ " TKs and Kicks at " @ $Nappy::tkLimit * $Nappy::tkMultiple @ " TK's"; 
	else 
	if($Nappy::tkServerLvl == 3) 
	%tkText = "Kicks at " @ $Nappy::tkLimit @ " TK's"; else %tkText = "ERROR: Server Level set to Unkown Level"; 
	return %tkText; 
	} 

function Nappy_ClientLvlTxt() 
	{ 
	if($Nappy::tkClientLvl == 0) 
	%tkText = "Vote Option at " @ $Nappy::tkLimit @ " TK's"; 
	else 
	if($Nappy::tkClientLvl == 1) 
	%tkText = "Kick Option at " @ $Nappy::tkLimit @ "TK's"; 
	else 
	%tkText = "ERROR: Client Level set to Unkown Level"; 
	return %tkText; 
	} 

function checkTeams()
	{
	%numPlayers = getNumClients();
	for(%i=0; %i<2; %i=%i+1)
	%numTeamPlayers[%i] = 0;
	for(%i=0;%i<%numPlayers;%i=%i+1)
	{
	%pl = getClientByIndex(%i);
	if(%pl != %playerId)
	{
	%team = Client::getTeam(%pl);
	%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
	}
	}
	%lowPlayer = %numTeamPlayers[0];
	%lowTeam = 0;
	for(%i=1; %i<2; %i=%i+1)
	{
	if(%numTeamPlayers[%i] < %lowPlayer)
	{
	%lowTeam = %i;
	%lowPlayer = %numTeamPlayers;
	}
	}
	return %lowTeam;
	} 

function Nappy_setTeamKill(%victimId, %killerId) 
	{ 
	$tkVictim[%killerId] = %victimId; 
	$tkKiller[%victimId] = %killerId; 
	$tkKills[%killerId] += 1; 
	%trigger = $tkKills[%killerId] % $Nappy::tkLimit; 
	%tkTopKills = $Nappy::tkLimit * $Nappy::tkMultiple; 
	if(($tkKills[%killerId] >= $Nappy::tkLimit) && (!%trigger)) 
	{ 
	if($Nappy::tkServerLvl) 
	{ 
	if($Nappy::tkServerLvl != 3) 
	{ 
	if(($tkKills[%killerId] >= %tkTopKills) && ($Nappy::tkServerLvl != 1)) 
	{ 
	messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills."); 
	Admin::Kick(-2, %killerId); 
	return; 
	} 
	%killerId.voteTarget = true; 
	%victimId.selClient = Nappy_getKiller(%victimId); 
	Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId); 
	} 
	else 
	{ 
	messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills."); 
	Admin::Kick(-2, %killerId); 
	} 
	} 
	} 
	return; 
	} 

function Nappy_getKiller(%clientId) 
	{ 
	return $tkKiller[%clientId]; 
	} 

function Nappy_getVictim(%clientId) 
	{ 
	return $tkVictim[%clientId]; 
	} 

function Nappy_leaveGame(%clientId) 
	{ 
	if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; 
	if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; 
	$tkKiller[%clientId] = %clientId; 
	$tkVictim[%clientId] = %clientId; 
	$tkKills[%clientId] = 0; 
	$empTime[%clientId] = 0; 
	return; 
	} 

function Nappy_joinGame(%clientId) 
	{ 
	if (($tkKiller[$tkVictim[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkKiller[$tkVictim[%clientId]] = $tkVictim[%clientId]; 
	if (($tkVictim[$tkKiller[%clientId]] == %clientId) && ($tkVictim != %clientId)) 
	$tkVictim[$tkKiller[%clientId]] = $tkKiller[%clientId]; 
	$tkVictim[%clientId] = %clientId; 
	$tkKiller[%clientId] = %clientId; 
	$tkKills[%clientId] = 0; 
	$empTime[%clientId] = 0; 
	} 

function Nappy_clearPA(%admin) 
	{ 
	if(%admin.isSuperAdmin) 
	{ 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
	%pl = getClientByIndex(%i); 
	if(!%pl.isSuperAdmin && %pl.isAdmin) 
	{ 
	%pl.isAdmin = false; 
	Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin."); 
	Client::sendMessage(%admin,3,"Public Admin Status Stripped from: " @ Client::getName(%pl) @ "."); 
	} 
	} 
	} 
	} 

function Nappywhoison() 
	{ 
	echo(" # cl: CLIENT nm: NAME ip: ADDRESS"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
	%pl = getClientByIndex(%i); 
	%name = Client::getName(%pl); 
	%ip = Client::getTransportAddress(%pl); 
	echo(" " @ %i @ " cl: " @ %pl @ " nm: " @ %name @ " ip: " @ %ip); 
	} 
	} 

