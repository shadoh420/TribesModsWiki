// part 3 of admin
// admin set.

//=============================
// process changes in a less painfull way.. -plasmatic

function ServerSwitches(%clientId,%option,%action)
{
	if(%clientId != -1)
	{
		if(%clientId.SecretAdmin)
			%AdminName = SecretAdmin();
		else
			%AdminName = Client::getName(%clientId);
	}	
	else %adminName = "Majority Vote";
	
	if (%action)
	{
		messageAll(0,	%AdminName @ " ENABLED " @ %option @"~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " ENABLED " @ %option, 3);
		logAdminAction(%clientId, " ENABLED " @ %option);
	}	
	else
	{
		messageAll(0, %AdminName @ " DISABLED " @ %option @"~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ %AdminName @ " DISABLED " @ %option, 3);
		logAdminAction(%clientId, " DISABLED " @ %option);	
	}
	if (%option == "Fair Teams"){if(%action) $ANNIHILATION::FairTeams = 1;else $ANNIHILATION::FairTeams = 0;}
	else if(%option == "turret points"){if(%action) $TurretPoints = 1;else $TurretPoints = 0;}
	else if(%option == "deployable turrets"){if(%action) $NoDeployableTurret = 0;else $NoDeployableTurret = 1;}
	else if(%option == "map turrets"){if(%action) $NoMapTurrets = 0;else $NoMapTurrets = 1;}
	else if(%option == "Inventories"){if(%action) $NoInv = 0;else $NoInv = 1;}
	else if(%option == "Vehicle Stations"){if(%action) $NoVehicle = 0;else $NoVehicle = 1;}
	else if(%option == "Generators"){if(%action) $NoGenerator = 0;else $NoGenerator = 1;}
	else if(%option == "Flag captures"){if(%action) $NoFlagCaps = 0;else $NoFlagCaps = 1;}
	else if(%option == "Voting"){if(%action) $NoVote = 0;else $NoVote = 1;}	
	else if(%option == "Voting Admin"){if(%action) $ANNIHILATION::VoteAdmin = 1;else $ANNIHILATION::VoteAdmin = 0;}
	else if(%option == "Voting Builder"){if(%action) $ANNIHILATION::VoteBuild = 1;else $ANNIHILATION::VoteBuild = 0;}
	else if(%option == "Observer Alert"){if(%action) $ANNIHILATION::obsAlert = 1;else $ANNIHILATION::obsAlert = 0;}
	else if(%option == "personal skins"){if(%action) $ANNIHILATION::UsePersonalSkin = 1;else $ANNIHILATION::UsePersonalSkin = 0;}

	else if(%option == "Quick Inventories"){if(%action) $ANNIHILATION::QuickInv = 1;else $ANNIHILATION::QuickInv = 0;}
	else if(%option == "Zappy Inventories"){if(%action) $ANNIHILATION::Zappy = 1;else $ANNIHILATION::Zappy = 0;}
	else if(%option == "Extended Inventories"){if(%action) $ANNIHILATION::ExtendedInvs = 1;else $ANNIHILATION::ExtendedInvs = 0;}
//plasmatic 2.3
	else if(%option == "team change turret disable"){if(%action) $annihilation::DisableTurretsOnTeamChange = 1;else $annihilation::DisableTurretsOnTeamChange = 0;}
	else if(%option == "Flag Hunter"){if(%action) $FlagHunter::Enabled = 1;else $FlagHunter::Enabled = 0;}


	
}



//===================================


function Admin::setTeamDamageEnable(%admin, %enabled)
{
	
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);	
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Server::TeamDamageScale = 1;
			if(%admin == -1)
			{
				messageAll(0, "Team damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage ENABLED by consensus.");
			}
			else
			{	
				messageAll(0, %AdminName @ " ENABLED team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED team damage.", 3);
				logAdminAction(%admin, "Team damage ENABLED.");
			}
		}
		else
		{
			$Server::TeamDamageScale = 0;
			if(%admin == -1)
			{
				messageAll(0, "Team damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED Team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED Team damage.", 3);
				logAdminAction(%admin, "Team damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseDamageEnable(%admin, %enabled)
{
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);		
	
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$ANNIHILATION::SafeBase = 0;
			if(%admin == -1)
			{
				messageAll(0, "BASE damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>BASE damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Base damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED BASE damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED BASE damage.", 3);
				logAdminAction(%admin, "BASE damage ENABLED.");
			}
		}
		else
		{
			$ANNIHILATION::SafeBase = 1;
			if(%admin == -1)
			{
				messageAll(0, "Base damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED Base damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED Base damage.", 3);
				logAdminAction(%admin, "Base damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseHealingEnable(%admin, %enabled)
{
	
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);	
			
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$ANNIHILATION::BaseHeal = 1;
			AutoRepair(0.003);
			if(%admin == -1)
			{
				messageAll(0, "Base healing ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing ENABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED base healing.", 3);
				logAdminAction(%admin, "base healing ENABLED.");
			}
		}
		else
		{
			$ANNIHILATION::BaseHeal = 0;
			AutoRepair(-0.003);
			if(%admin == -1)
			{
				messageAll(0, "Base healing DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing DISABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED base healing.", 3);
				logAdminAction(%admin, "Base healing DISABLED.");
			}
		}
	}
}

function Admin::setPlayerDamageEnable(%admin, %enabled)
{
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);	
			
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$NoPlayerDamage = 0;
			if(%admin == -1)
			{
				messageAll(0, "Player damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Player damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Player damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED Player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED Player damage.", 3);
				logAdminAction(%admin, "Player damage ENABLED.");
			}
		}
		else
		{
			$NoPlayerDamage = 1;
			if(%admin == -1)
			{
				messageAll(0, "Player damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Player damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Player damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED player damage.", 3);
				logAdminAction(%admin, "Player damage DISABLED.");
			}

		}
	}
}

function Admin::setAreaDamageEnable(%admin, %enabled)
{
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);
			
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$ANNIHILATION::OutOfArea = "";
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED.");
			}				
		}
		else
		{
			$ANNIHILATION::OutOfArea = 1;
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage DISABLED.");
			}
		}
	}
}
function Admin::setBuild(%admin, %enabled)
{
	if(%admin.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%admin);
	
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Build = 1;
			$ItemMax[armormBuilder, Slapper] = 1;
			$ItemMax[armorfBuilder, Slapper] = 1;				
			if(%admin == -1)
			{
				messageAll(0, "Builder ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Builder ENABLED by consensus.", 3);
				logAdminAction(%admin, "builder ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED Builder.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED Builder.", 3);
				logAdminAction(%admin, " ENABLED builder.");
			}
		}
		else
		{
			$Build = 0;
			$ItemMax[armormBuilder, Slapper] = 0;
			$ItemMax[armorfBuilder, Slapper] = 0;				
 			if(%admin == -1)
 			{
				messageAll(0, "Builder DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Builder DISABLED by consensus.", 3);
				logAdminAction(%admin, "builder ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED Builder.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED Builder.", 3);
				logAdminAction(%admin, " DISABLED builder.");
			}
		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
		
	
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.~wCapturedTower.wav");
		else
		{	
			messageAll(0, "Server switched to Free-For-All Mode by " @ %AdminName @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@%AdminName @ " switched to free for all mode.", 3);
			logAdminAction(%clientId, "switched to free for all mode.");
		}
		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
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
	
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
		
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
			messageAll(0, "Server switched to Tournament Mode.~wCapturedTower.wav");
		else
		{
			messageAll(0, "Server switched to Tournament Mode by " @ %AdminName @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@%AdminName @ " switched server to Tournament Mode.", 3);
			logAdminAction(%clientId, "Server switched to Tournament Mode.");
		}
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}





//=======================================
// map changes


function randommap(%type,%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
		
	if(%clientId)
		messageAll(0,%AdminName@ " picked a random mission.~wCapturedTower.wav");
	else
		messageAll(0, "Starting a random mission");
	echo("GAME: "@%clientId@" Starting a random mission. Type= "@%type);
	
	//$MDESC::Type  		=current type
	//$MLIST::Type[%i]		=list of types
	//$MLIST::MissionList[%i]	=list of maps of %i type
	//$MLIST::EType[%ct]  		=type of map
	//$MLIST::EName[%ct]  		=name of map
	//$MLIST::EText[%ct]  		=textdescription	
	
	if(!%type)
	{
		// 3.0 upgrade, Training missions suck for multiplayers and admins -Plasmatic
		%picking = 100;
		while(%picking>0)
		{
			//echo(%picking--);
			%mapNum = floor(getrandom() * $MLIST::Count);
			//echo($MLIST::EType[%mapNum]);
			if($MLIST::EType[%mapNum] != "Training")
				%picking = false;
			
		}	
	}
	else
	{
		%typelist = $MLIST::MissionList[%type];
		//echo(%typelist);
		for(%i = 0; getword(%typelist,%i) != -1; %i++)
		{
			%NumMaps++;
		}
		%mapNum = getword(%typelist,floor(getrandom() * %NumMaps));	
	}
	messageAll(0,"Changing to random mission: "@$MLIST::EName[%mapNum]@" ("@$MLIST::EType[%mapNum]@")");
	$timeLimitReached = true;
	Server::loadMission($MLIST::EName[%mapNum]);
}

function Server::nextMission(%replay)
{
	if(%replay || $Server::TourneyMode)
		%nextMission = $missionName;
	else if($nextMap != "")
  	{
  		%nextMission = $nextMap;
  		$nextMap = "";
  	}		
	else
		%nextMission = $nextMission[$missionName];
	echo("Changing to mission ", %nextMission, ".");
	// give the clients enough time to load up the victory screen
	Server::loadMission(%nextMission);
}




function nextmap(%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
		
	if(%clientId)
		messageAll(0,%AdminName@ " started the next mission.~wCapturedTower.wav");
	else
		messageAll(0, "Starting next Mission.");
	echo("GAME: Starting next map.");
	$timeLimitReached = true;
	Server::nextMission();
}

function replaymap(%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
	
	if(%clientId)
		messageAll(0,%AdminName@ " restarted the mission.~wCapturedTower.wav");
	else
		messageAll(0, "Restarting Mission");
	echo("GAME: restarting map.");
	$timeLimitReached = true;
	Server::nextMission(true);
}
//=================================================

//function by Plasmatic 2.3 annihilation
function ReturnFlags()
{
	%group = nameToID("MissionCleanup/ObjectivesSet");
	//messageall(1,"returning flags");
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		%name = Item::getItemData(%obj);
		if(%name == flag)
		{
			if(!%obj.atHome)
			{			
				messageall(1,"returning "@ getTeamName(GameBase::getTeam(%obj))@"'s "@%name);
				%player = %obj.carrier;
				Player::setItemCount(%player, Flag, 0);
				GameBase::setPosition(%obj, %obj.originalPosition);
				GameBase::setIsTarget(%obj,false);	//plasmatic 2.2
				Item::setVelocity(%obj, "0 0 0");
				GameBase::startFadeIn(%obj);
				%obj.atHome = true;
				%obj.carrier = -1;
				%obj.pickupSequence++;
				%player.carryFlag = "";		
						
				Item::Hide(%obj,false);
			}
		}
	}	
}
