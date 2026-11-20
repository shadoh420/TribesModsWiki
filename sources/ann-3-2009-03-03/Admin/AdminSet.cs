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
	else if(%option == "Flag Cap Limit"){if(%action) $NoFlagCaps = 0;else $NoFlagCaps = 1;}
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
	else if(%option == "Flag Hunter"){if(%action) $FlagHunter::Enabled = 1;else {$FlagHunter::Enabled = false;exec(player);exec(game);exec(objectives);}}

	else if(%option == "deploy turrets in power grid"){if(%action) $turret::deployinpower = 1;else $turret::deployinpower = 0;}

	
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
			$Annihilation::NoPlayerDamage = 0;
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
			$Annihilation::NoPlayerDamage = 1;
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
				messageAll(0, "Map boundries ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Map boundries ENABLED by consensus.", 3);
				logAdminAction(%admin, "Map boundries ENABLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " ENABLED map boundries.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " ENABLED map boundries.", 3);
				logAdminAction(%admin, "Map boundries ENABLED.");
			}				
		}
		else
		{
			$ANNIHILATION::OutOfArea = 1;
			if(%admin == -1)
			{
				messageAll(0, "Map boundries DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Map boundries DISABLED by consensus.", 3);
				logAdminAction(%admin, "Map boundries DISBLED by consensus.");
			}
			else
			{
				messageAll(0, %AdminName @ " DISABLED map boundries.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@%AdminName @ " DISABLED map boundries.", 3);
				logAdminAction(%admin, "Map boundries DISABLED.");
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
				Annihilation::setItemCount(%player, Flag, 0);
				GameBase::setPosition(%obj, %obj.originalPosition);
				GameBase::setIsTarget(%obj,false);	//plasmatic 2.2
				Item::setVelocity(%obj, "0 0 0");
				GameBase::startFadeIn(%obj);
				%obj.atHome = true;
				%obj.carrier = -1;
				%obj.pickupSequence++;
				%player.carryFlag = "";	
				
				//Rotating flag fix, completed 2/3/2007 8:45PM. Soooo Lazy.. 
				if(%obj.dummy)
					deleteobject(%obj.dummy);				
						
				Item::Hide(%obj,false);
			}
		}
	}	
}

// Taken from Uber_Annihilation 2/12/2008 1:16AM
// a version of Annihilation 2.0 I put together some time ago... 
// -Plasmatic

$jetForceM = 2.0;
$jetEnergyDrainM = 1.5;
$ArmorSpeedM = 2.0;

function Uber::switchSpeed(%armorData,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM)
{
	//Plasmatic

	%armorData.maxJetForwardVelocity = %armorData.maxJetForwardVelocity * %ArmorSpeedM;
	%armorData.jetForce = %armorData.jetForce * %jetForceM;
	%armorData.jetEnergyDrain = %armorData.jetEnergyDrain * %jetEnergyDrainM;
	%armorData.maxForwardSpeed = %armorData.maxForwardSpeed * %ArmorSpeedM;
	%armorData.maxBackwardSpeed = %armorData.maxBackwardSpeed * %ArmorSpeedM;
	%armorData.maxSideSpeed = %armorData.maxSideSpeed * %ArmorSpeedM;

}
function uber::switchreload(%weapon,%reload)
{
	%weapon.reloadTime = %weapon.reloadTime/%reload;
	%weapon.fireTime = %weapon.fireTime/%reload;
	
}
function uber::switchTurret(%turret,%reload)
{
	%turret.reloadDelay = %turret.reloadDelay/%reload;
//	%turret.maxEnergy = %turret.maxEnergy/%reload;
	if(%turret.maxGunEnergy)
		%turret.maxGunEnergy = %turret.maxGunEnergy/%reload;
	//%turret.maxDamage = %turret.maxDamage*%reload;	//handling this in ::ondamage -Plasmatic
}

function Ann::uber()
{
	if(!$Annihilation::uber)
	{
		$Annihilation::uber = true;
		%jetForceM = 2.0;
		%jetEnergyDrainM = 1.5;
		%ArmorSpeedM = 2.0;
		%reload = 5;
		%ammo = 10;
		
	}
	else
	{
		$Annihilation::uber = false;
		%jetForceM = 0.5;
		%jetEnergyDrainM = 0.75;
		%ArmorSpeedM = 0.5;
		%reload = 0.2;	
		%ammo = 1;
	}
	
	
	Uber::switchSpeed(armormAngel,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorfAngel,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(armormSpy,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorfSpy,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(armormNecro,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorfNecro,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(armormWarrior,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorfWarrior,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(armormBuilder,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorfBuilder,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(armorTroll,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorTank,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(armorTitan,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	Uber::switchSpeed(lghost,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	Uber::switchSpeed(fghost,%jetForceM,%jetEnergyDrainM,%ArmorSpeedM);
	
	//weapon reloads
	uber::switchreload(AngelFireImage,%reload);
//	uber::switchreload(BabyNukeImage,%reload);
	uber::switchreload(BlasterImage,%reload);
	uber::switchreload(DiscLauncherImage ,%reload);
	uber::switchreload(FlamerImage,%reload);
	uber::switchreload(FlameThrowerImage ,%reload);
	uber::switchreload(GrenadeLauncherImage ,%reload);
	uber::switchreload(HammerImage,%reload);
	uber::switchreload(HDiscLauncher1Image ,%reload);
	uber::switchreload(HDiscLauncher2Image,%reload);
	uber::switchreload(HDiscLauncherImage,%reload);
	uber::switchreload(HeavensfuryImage ,%reload);
	uber::switchreload(LaserRifleImage,%reload);
	uber::switchreload(MortarImage ,%reload);
		
//	uber::switchreload(ParticleBeamWeaponImage ,%reload);
	uber::switchreload(PhaseDisrupterImage,%reload);
	uber::switchreload(PlasmaGunImage,%reload);
	uber::switchreload(RailgunImage ,%reload);
	uber::switchreload(Railgun2Image ,%reload);
	uber::switchreload(RocketLauncherImage ,%reload);
	uber::switchreload(RocketPodImage ,%reload);
	uber::switchreload(RMortarImage,%reload);
	uber::switchreload(ShockwaveGunImage ,%reload);
	uber::switchreload(ShotgunImage ,%reload);
	uber::switchreload(SniperRifleImage ,%reload);
	uber::switchreload(SoulSuckerImage,%reload);
	
	uber::switchreload(DeathRayImage,%reload);
	uber::switchreload(DeathRayBeamImage,%reload);
	uber::switchreload(DisarmerSpellImage,%reload);
	uber::switchreload(FlameStrikeImage,%reload);
	uber::switchreload(SpellFlameThrowerImage ,%reload);
	
	uber::switchreload(ShockingGraspImage ,%reload);
	uber::switchreload(ShockingGrasp2Image,%reload);
	uber::switchreload(StasisImage,%reload);
	uber::switchreload(StingerImage,%reload);
	uber::switchreload(TBlastCannonImage,%reload);
	
	uber::switchreload(TRocketLauncherImage ,%reload);
	uber::switchreload(TRocketLauncher2Image ,%reload);
	uber::switchreload(TRocketLauncher3Image ,%reload);
	uber::switchreload(TRocketLauncher4Image ,%reload);
	
	uber::switchreload(TankRPGLauncherImage ,%reload);
	uber::switchreload(TankRPGLauncher2Image ,%reload);
	uber::switchreload(TankRPGLauncher3Image ,%reload);
	uber::switchreload(TankRPGLauncher4Image ,%reload);
	
	uber::switchreload(TankShredderImage ,%reload);
	uber::switchreload(TankShredder2Image ,%reload);
	uber::switchreload(TankShredder3Image ,%reload);
	uber::switchreload(TankShredder4Image ,%reload);
	
	uber::switchreload(VulcanImage ,%reload);
	
	//can't forget ammo you pansies!
	
	PopulateItemMax(BabyNukeAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   4*%ammo);
	PopulateItemMax(DiscAmmo,			30*%ammo,  30*%ammo,  0,   0,  30*%ammo,  30*%ammo,   0,   0,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,   0,  15*%ammo);
	PopulateItemMax(FlamerAmmo,			50*%ammo,  50*%ammo,  0,   0,  40*%ammo,  40*%ammo,   0,   0,  50*%ammo,  50*%ammo,  50*%ammo,  50*%ammo,  75*%ammo,   0, 100*%ammo);
	PopulateItemMax(FlameThrowerAmmo,		50*%ammo,  50*%ammo,  0,   0,   0,   0,   0,   0,  50*%ammo,  50*%ammo,   0,   0,  75*%ammo,   0, 100*%ammo);
	PopulateItemMax(GrenadeAmmo,			20*%ammo,  20*%ammo,  0,   0,  15*%ammo,  15*%ammo,   0,   0,  20*%ammo,  20*%ammo,  15*%ammo,  15*%ammo,  30*%ammo,   0,  30*%ammo);
	PopulateItemMax(HammerAmmo,			30*%ammo,  30*%ammo,  0,   0,  10*%ammo,  10*%ammo,  10,  10*%ammo,  15*%ammo,  15*%ammo,   0,   0,   0,   0,   0);
	PopulateItemMax(HDiscLauncherAmmo,		30*%ammo,  30*%ammo,  0,   0,   0,   0,   0,   0,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,   0,  40*%ammo);
//	PopulateItemMax(MineLauncherAmmo,		5*%ammo,   5*%ammo,   0,   0,   0,   0,   0,   0,   5*%ammo,   5*%ammo,   5*%ammo,   5*%ammo,   0,   0,  10*%ammo);
	PopulateItemMax(MortarAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15*%ammo,   0,   0);
	PopulateItemMax(OSAmmo,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   8*%ammo);
	PopulateItemMax(PhaseAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15*%ammo,   0,  20*%ammo);
	PopulateItemMax(PlasmaAmmo,			30*%ammo,  30*%ammo,  0,   0,  25*%ammo,  25*%ammo,   0,   0,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,  40*%ammo,   0,  40*%ammo);
	PopulateItemMax(RailAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10*%ammo,  10*%ammo,   0,   0,   0);
	PopulateItemMax(RocketAmmo,			10*%ammo,  10*%ammo,  0,   0,   0,   0,   0,   0,  10*%ammo,  10*%ammo,  10*%ammo,  10*%ammo,  10*%ammo,   0,  20*%ammo);

	PopulateItemMax(RocketPodShells,		6*%ammo,   6*%ammo,   0,   0,   0,   0,   0,   0,   6*%ammo,   6*%ammo,   0,   0,   6*%ammo,   0,   0);
	
	PopulateItemMax(RubberAmmo,			10*%ammo,  10*%ammo,  0,   0,   0,   0,   0,   0,  10*%ammo,  10*%ammo,   0,   0,  15*%ammo,   0,  20*%ammo);
	PopulateItemMax(ShotGunShells,			30*%ammo,  30*%ammo,  0,   0,  30*%ammo,  30*%ammo,   0,   0,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,  30*%ammo,   0,   0);
	PopulateItemMax(SniperAmmo,			0,   0,   0,   0,  15*%ammo,  15*%ammo,   0,   0,   0,   0,   0,   0,   0,   0,   0);
	PopulateItemMax(StingerAmmo,			10*%ammo,  10*%ammo,  0,   0,   0,   0,   0,   0,   8*%ammo,   8*%ammo,   8*%ammo,   8*%ammo,  10*%ammo,   0,   10*%ammo);
	PopulateItemMax(TankShredderAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 500*%ammo,   0);
	PopulateItemMax(TRocketLauncherAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  40*%ammo,   0);
	PopulateItemMax(TankRPGAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  60*%ammo,   0);
	PopulateItemMax(TBlastCannonAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  30*%ammo,   0);
	PopulateItemMax(VulcanAmmo,			300*%ammo, 300*%ammo, 0,   0,   0,   0,   0,   0, 300*%ammo, 300*%ammo, 300*%ammo, 300*%ammo, 450*%ammo,   0,   0);
	
	// Turret reloads.. Probably only base turrets... 
	uber::switchTurret(PlasmaTurret ,%reload);
	uber::switchTurret(RocketTurret ,%reload);
	uber::switchTurret(MortarTurret ,%reload);
	uber::switchTurret(IndoorTurret ,%reload);
	
	
	
	


	
	
	//preloadServerDataBlocks();

}

