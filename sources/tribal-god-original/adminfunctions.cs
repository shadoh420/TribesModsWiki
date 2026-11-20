$TG::FreezePadTime = 25;

function Freeze(%clientId, %var)
{
	%player = Client::getOwnedObject(%clientId);
	%playername = Client::getName(%clientId);
	
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "on")
	{
		%clientId.isfrozen = 1;
		%clientId.nosuicide = 1;
		
		Client::sendMessage(%clientId, 0, "Freeze!~wmale1.wwshoot1.wav");
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		CenterPrint(%clientId, "<jc><f1>"@ $Server::HostName @"\n "@ %playername @", You have been frozen!\n Get comfy you have "@ $TG::FreezePadTime @" Seconds for you to unthaw", 10);
		Schedule("FreezeCheck("@ %clientId @", "@ %player @");", $TG::FreezePadTime);
		return;
	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player) && %var == "off")
	{ 
		Client::setControlObject(%clientId, %player);
		Client::sendMessage(%clientId, 0, "Ok There ya go "@ %playername @"~wmale1.wsorry.wav");
		
		%clientId.isfrozen = 0;
		%clientId.nosuicide = 0;
		return;
	}
}
function FreezeCheck(%clientId, %player)
{ 
	if(%clientId.isfrozen)
	{
		Client::setControlObject(%clientId, %player);
		%clientId.isfrozen = 0;
		%clientId.nosuicide = 0;
	}
}

// w00t! -Dustin B.
function Posses(%clientId, %cl, %opt)
{
	if($Debug)
	{ Echo("****** Possess ******"); }
	
	%posseeId = %cl;
	%posseeName = Client::getName(%cl);
	%posseePlayer = Client::getOwnedObject(%cl);
	%posseeStatus = Client::getStatus(%posseeId);
	
	%posserId = %clientId;
	%posserName = Client::getName(%clientId);
	%posserPlayer = Client::getOwnedObject(%clientId);
	%posserStatus = Client::getStatus(%posserId);
	
	if(%opt == "Poss")
	{
		if(%posserId == %posseeId)
		{ Client::sendMessage(%posserId, 1, "ERROR: Cannot Possess Yourself.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isFrozen == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Frozen.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isPossessing == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessing Someone.~wAccess_Denied.Wav"); return; }
		
		if(%posseeId.isPossessed == true)
		{ Client::sendMessage(%posserId, 1, "ERROR: Client Is Currently Possessed.~wAccess_Denied.Wav"); return; }
		
		if(%posseeStatus == "(Dead)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Dead.~wAccess_Denied.Wav"); return; }   
		
		if(%posseeStatus == "(Observing)")
		{ Client::sendMessage(%posserId, 1, "ERROR: Client is Observing.~wAccess_Denied.Wav"); return; }
		
		%posseeId.isPossessed = true;
		%posseePlayer.shieldStrength = 500.0;
		%posseeId.Possby = %posserId;
		%posseeId.noSuicide = 1;
		%posseeId.guiLock = true;
		%posseePlayer.guiLock = true;
		
		%posserPlayer.shieldStrength = 500.0;
		%posserId.isPossessing = true;
		%posserId.hasPossPlayer = %posseePlayer;
		%posserId.hasPossClient = %posseeId;
		
		Client::setControlObject(%posseeId, Client::getObserverCamera(%posseeId));
		
		Observer::setOrbitObject(%posseeId, %posseePlayer, 3, 3, 3);
		CenterPrint(%posseeId, "<jl><BSkull_Big.Bmp><jc><f1>You have been possessed by <f2>"@ %posserName @", <f1>enjoy the ride..<jr><BSkull_Big.Bmp>", 10);
		
		Client::setControlObject(%posserId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
	else if(%opt == "UNPoss")
	{
		if(!%posseeId.isPossessed)
		{ Client::sendMessage(%posserId, 0, "Selected Client Is Not Possessed.~wAccess_Denied.Wav"); return; }
		
		if(%posserId != %posseeId.Possby)
		{
			%posserId = %posseeId.Possby;
			%posserName = Client::getName(%posserId);
			%posserPlayer = Client::getOwnedObject(%posserId);
		}
		
		%posseeId.isPossessed = false;
		%posseePlayer.shieldStrength = 0.0;
		%posseeId.Possby = "";
		%posseeId.noSuicide = 0;
		%posseeId.guiLock = false;
		%posseePlayer.guiLock = false;
		
		%posserPlayer.shieldStrength = 0.0;
		%posserId.isPossessing  = false;
		%posserId.hasPossPlayer = "";
		%posserId.hasPossClient = "";
		
		CenterPrint(%posseeId, "<jc><f1>"@ %posserName @" says 'I can't take the smell anymore. Take A Shower Boy! Damn You Stink!'", 5);
		
		Client::setControlObject(%posserId, %posserPlayer);
		Client::setControlObject(%posseeId, %posseePlayer);
		
		if($Debug)
		{
			Echo("Possesser: "@ %posserName @"("@ %posserId @")");
			Echo("Possesser Status: "@ Client::getStatus(%clientId));
			Echo("Possessee: "@ %posseeName @"("@ %posseeId @")");
			Echo("Possessee Status: "@ Client::getStatus(%cl));
			Echo("*********************");
		}
		return;
	}
}
function Admin::startVote(%clientId, %topic, %action, %option)
{
	if(%clientId.lastVoteTime == "")
	%clientId.lastVoteTime = -$Server::MinVoteTime;

	// we want an absolute time here.
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
		
		if(%action == "kick")
		$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		$curVoteCount++;
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 30);
		echo(Client::getName(%clientId) @" initiated a vote to" @ $curVoteTopic);
		messageAll(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic@".~wCapturedTower.wav");
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
function Admin::changeMissionMenu(%clientId, %voteit)
{
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	{
		if($MLIST::Type[%type] != "Training")
		{
			if(%index == 8 && $MLIST::TypeCount > 8)
			{
				Client::addMenuItem(%clientId, %index @ "More Types...", "more 8 " @ %voteit);
				break;
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0 " @ %voteit);
		%index++; 
		} 
	}
}
function Admin::fun(%admin, %clientId, %word)
{
	if(%admin == -1)
	{
		Centerprintall("<jc><f1>"@ Client::getName(%clientId) @ " was "@ %word @" by consensus.", 3);		
		messageAll(0, Client::getName(%clientId) @" was "@ %word @ " by consensus.~wCapturedTower.wav");
	}
	else
	{
		MessageAll(0, Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin)@".~wCapturedTower.wav");
		Centerprintall("<jc><f1>"@Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin)@".", 3);
	}
	if(%word == "frozen")
	{
		Freeze(%clientId, "on");
  		MessageAll(0, Client::getName(%clientId) @" was "@ %word @" for 2 minutes by consensus.");
  	}
	if(%word=="poisoned")
	{ poison(%clientId); }
	else if(%word=="De-Tongued")
	{ %clientId.silenced = true; }
	else if(%word=="Un-Muted")
	{ %clientId.silenced = ""; }
	else if(%word=="Admined")
	{ %clientId.isAdmin = true; }
	else if(%word=="De -admined")
	{ %clientId.isAdmin = false; }
	else if(%word=="Kicked")
	{ Admin::kick(%admin, %clientId); }
	else if(%word=="Banned")
	{ Admin::kick(%admin, %clientId, true); }
}
function TG::AdminGive(%Adminer, %c, %lvl)
{
	if(%lvl == "God")
	{
		%word = "God Admin";
		%c.isAdmin = true;
		%c.isSuperAdmin = true;
		%c.isGodAdmin = true;
	}
	else if(%lvl == "Super")
	{
		%word = "Super Admin";
		%c.isAdmin = true;
		%c.isSuperAdmin = true;
	}
	else
	{ %word = "Public Admin"; %c.isAdmin = true; }
	MessageAllExcept(%c, 0, Client::getName(%c) @" was givin "@ %word @" by "@ Client::getName(%Adminer) @"~wCapturedTower.wav");
	Client::sendMessage(%c, 0, Client::getName(%c) @", you have been givin "@ %word @" by "@ Client::getName(%Adminer) @".~wCapturedTower.Wav");
	BottomPrint(%c, "<jc><f1>"@ Client::getName(%c) @", you have been givin <f2>"@ %word @" <f1>by <f2>"@ Client::getName(%Adminer) @"<f1>.", 5);
}
function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;
	if($curVoteAction == "kick" || $curVoteAction == "admin")
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
	
	if($curVoteAction == "poison")
	{
		if($curVoteOption.voteTarget)
		{
			KillRatDead($curVoteOption);
			Centerprint($curVoteOption, "<jc><f1>you were poisoned by everyone.", 15);
			MessageAll(0, Client::getName($curVoteOption) @" had some acid with their Wheaties.");
		}
	}
	
	if($curVoteAction == "unsilence")
	{
		if($curVoteOption.voteTarget)
		Admin::fun(-1, $curVoteOption, "Un-Muted");
	}	
	
	if($curVoteAction == "silence")
	{
		if($curVoteOption.voteTarget)
		Admin::fun(-1, $curVoteOption, "De-Tongued");
	}
	
	if($curVoteAction == "freeze")
	{
		if($curVoteOption.voteTarget)
		{
			Freeze($curVoteOption, "on");
			centerprint($curVoteOption, "<jc><f1>you were frozen by everyone.", 15);
			MessageAll(0, Client::getName($curVoteOption) @ " gets the cold shoulder for 2 minutes.");
		}
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.~wCapturedTower.wav");
			
			if($curVoteOption.menuMode == "options")
			Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
		MessageAll(0, "Changing to mission "@ $curVoteOption @".~wCapturedTower.wav");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "tourney"){ Admin::setModeTourney(-1); }
	else if($curVoteAction == "ffa"){ Admin::setModeFFA(-1); }
	else if($curVoteAction == "etd"){ Admin::setTeamDamageEnable(-1, true); }
	else if($curVoteAction == "dtd"){ Admin::setTeamDamageEnable(-1, false); }
	else if($curVoteOption == "smatch"){ Admin::startMatch(-1); }
	else if($curVoteAction == "NextMap"){ nextmap(); }
	else if($curVoteAction == "RandomMap"){ randommap(); }
	else if($curVoteAction == "ReplayMap"){ replaymap(); }
	else if($curVoteAction == "VTime"){ remoteSetTimeLimit(0, $curVoteOption); }
	else if($curVoteAction == "eBaseD"){ Admin::setBaseDamageEnable(-1, true); }
	else if($curVoteAction == "dBaseD"){ Admin::setBaseDamageEnable(-1, false); }
	else if($curVoteAction == "eBaseH"){ Admin::setBaseHealingEnable(-1, true); }
	else if($curVoteAction == "dBaseH"){ Admin::setBaseHealingEnable(-1, false); }
	else if($curVoteAction == "eOutAreaD"){ Admin::setAreaDamageEnable(-1, true); }
	else if($curVoteAction == "dOutAreaD"){ Admin::setAreaDamageEnable(-1, false); }
	else if($curVoteAction == "ePlayerD"){ Admin::setPlayerDamageEnable(-1, true); }
	else if($curVoteAction == "dPlayerD"){ Admin::setPlayerDamageEnable(-1, false); }
}
function Admin::countVotes(%curVote)
{
	if(%curVote != $curVoteCount)
	{ return; }
	
	%votesFor = 0;
	%votesAgainst = 0;
	%votesAbstain = 0;
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
		else if(%cl.vote == "no")
		{
			%votesAgainst++;
			%totalVotes++;
		}
		else %votesAbstain++;
	}
	
	%minVotes = floor($Server::MinVotesPct * %totalClients);
	if(%minVotes < $Server::MinVotes)
	{ %minVotes = $Server::MinVotes; }
	
	if(%totalVotes < %minVotes)
	{
		%votesAgainst += %minVotes - %totalVotes;
		%totalVotes = %minVotes;
	}
	%margin = $Server::VoteWinMargin;
	
	if($curVoteAction == "admin")
	{
		if(%minVotes < $Server::AdminMinVotes) 
		%minVotes = $Server::AdminMinVotes; 
		%margin = $Server::VoteAdminWinMargin;
		%totalVotes = %votesFor + %votesAgainst + %votesAbstain;
		if(%totalVotes < %minVotes) 
		%totalVotes = %minVotes;
	}
	if((%votesFor / %totalVotes >= %margin || $curVoteForce == "YES") && $curVoteForce != "NO")
	{
		messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
		Admin::voteSucceded();
	}
	else  // special team kick option:
	{
		if($curVoteAction == "kick")
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
			if((%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin || $curVoteForce == "YES") && $curVoteForce != "NO")
			{
				messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
				Admin::voteSucceded();
				$curVoteTopic = "";
				$curVoteForce = "";
				return;
			}
		}
		if (%totalClients - (%votesFor + %votesAgainst) <0 || %votesFor > %votesAgainst)
		messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ ", not enough votes to " @ $curVoteTopic);
		else 
		messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions."); Admin::voteFailed();}$curVoteTopic = "";$curVoteForce = "";
}
function Admin::kick(%admin, %client, %ban)
{
	%adminName = Client::getName(%admin);
	%baneeName = Client::getName(%client);
	
	if(%admin != %client && (%admin == -1 || %admin.isAdmin))
	{
		if(%ban && !%admin.isSuperAdmin)
		{ return; }
		
		if(%ban)
		{ %word = "Banned"; %cmd = "BAN: "; }
		else
		{ %word = "Kicked"; %cmd = "KICK: "; }
		
		
		if(%client.isSuperAdmin)
		{
			if(%admin == -1)
			messageAll(0, "Super Admins Cannot Be "@ %word @".");
			else 
			Client::sendMessage(%admin, 0, "A Super Admin Cannot Be "@ %word @" DipShit.");
			return;
		}
		%ip = Client::getTransportAddress(%client);

		if(%ip == "")
		{ return; }
			
		if(%ban)
		{ BanList::add(%ip, $TribalGod::BanTime); BanList::export("config\\banlist.cs"); }
		else
		{ BanList::add(%ip, $TribalGod::KickTime); BanList::export("config\\banlist.cs"); }
		%name = Client::getName(%client);
		
		if(%admin == -1)
		{
			MessageAll(0, %name @" was "@ %word @" from vote.~wCapturedTower.wav");
			echo(%cmd @ %name @"("@ %ip @") was "@ %word @" from vote.");
			Net::kick(%client, "You were "@ %word @" by  consensus.");
		}
		else
		{
			CenterPrint(%client, "<jc><f0>"@ $TG::KickMessage, 5);
			MessageAll(0, %baneeName @" Was "@ %word @" By "@ %adminName @" For Being A AssHole.~wCapturedTower.wav");
			Schedule("Net::kick("@ %client @", \"You were "@ %word @" by " @ %adminName @". Go Away, And Stay Away.\");", 10);
		}
	}
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
function Admin::strip(%client)
{
	%client.isAdmin      = "";
	%client.isSuperAdmin = "";
	%client.isGodAdmin   = "";
	Client::sendMessage(%client, 0, "Your admin status has been stripped.~wCapturedTower.wav");
	BottomPrint(%client, "<f1><jc>Your admin has been stripped.", 20);
}
function Admin::give(%client)
{
	%client.isAdmin      = true;
	%client.isSuperAdmin = true;
	Client::sendMessage(%client, 0, "You have been granted admin.~wCapturedTower.wav");
	BottomPrint(%client, "<f1><jc>You have been granted admin.", 20);
}
function player::status(%client){%player=Client::getOwnedObject(%client);%team=Client::getTeam(%client);if(%player==-1 && %team!=-1){%status="(Dead)";}else if(%player!=-1 && %team!=-1){%status="(Live)";}else if(%team==-1){%status="(Observing)";}return%status;}
function XNotify(){MessageAll(0, "Gotta Restart, It'll only take a second.~wForceOpen.wav");CenterPrintAll("<jc><f1>Gotta Restart, It'll only take a second.", 10);Schedule("MessageAll(0, \"Sorry...~wForceOpen.wav\");", 3);}
function XSay(%m){MessageAll(0, "SERVER MESSAGE: "@ %m @"~wForceOpen.wav");}
function XCP(%m){CenterPrintAll("<jc><f1>SERVER MESSAGE: <f2>"@ %m, 10);}
function XBP(%m){BottomPrintAll("<jc><f1>SERVER MESSAGE: <f2>"@ %m, 10);}
// Get Flag, X-Ecutioner
function getflag(%clientId, %team)
{
	if(getNumTeams() == 2)
	{
		%t1Flagpos = ($teamFlag[0]).originalPosition;
		%t2Flagpos = ($teamFlag[1]).originalPosition;
		%pteam     = GameBase::getTeam(%clientId);
		if(%team == "Friendly")
		{
			if(%t1Flagpos == $teamFlag[GameBase::getTeam(%clientId)])
			{ %enemypos = %t2Flagpos; }
			else if(%t1Flagpos != $teamFlag[GameBase::getTeam(%clientId)])
			{ %enemypos = %t1Flagpos; }
			GameBase::setPosition(%clientId, %enemypos);
		}
		
		else if(%team == "Enemy")
		{
			if(%t1Flagpos == $teamFlag[GameBase::getTeam(%clientId)])
			{ %friendlypos = %t1Flagpos; }
			else if(%t1Flagpos != $teamFlag[GameBase::getTeam(%clientId)])
			{ %friendlypos = %t2Flagpos; }
			GameBase::setPosition(%clientId, %friendlypos);
		}
	}
	else
	{ Echo("getflag("@ %clientId @", "@ %team @"); |  Too many flags to consider"); }
}