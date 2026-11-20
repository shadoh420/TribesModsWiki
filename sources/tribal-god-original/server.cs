exec(CenterPrintLvls);
function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
   $Client::info[%clientId, 0] = %skin;
   $Client::info[%clientId, 1] = %name;
   $Client::info[%clientId, 2] = %email;
   $Client::info[%clientId, 3] = %tribe;
   $Client::info[%clientId, 4] = %url;
   $Client::info[%clientId, 5] = %info;
   if(%autowp)
   %clientId.autoWaypoint = true;
   if(%enterInv)
   %clientId.noEnterInventory = true;
   if(%msgMask != "")
   %clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
   $ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

   export("Server::*", "temp\\" @ $ServerDataFile, False);
   export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
   EvalSearchPath();
}

function Server::refreshData()
{
   exec($ServerDataFile);  
   checkMasterTranslation();
   Server::loadMission($pref::lastMission, false);
}

function Server::onClientConnect(%clientId) 
{
	%ip = Client::getTransportAddress(%clientId);
	%name = Client::getName(%clientId);
	if(!String::NCompare(%ip, "LOOPBACK", 8))
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
		%clientId.isGodAdmin = true;
	}
	
	if(!String::NCompare(%name, "+]-[+", 5))
	{ KickDaJackal(%clientId); return; }
	
	if($hasDropped)
	%clientId.goodT = "";
	else
	%clientId.goodT = "good";
	
	%clientId.hasDeployed = false;
	%username = Client::getName(%clientId);
	IpLogger::Check(%clientId, %ip);
	if(!String::NCompare(%name, "[TG]", 4))
	{ Schedule("XBottomPrint("@ %clientId @", \"<jc><f1>Attention TG Member, Sign Up For The Clan Forums At <f2>http://www.chatarea.com/TGMod\", 10);", 20, %clientId); }
	
	
	%clientId.spawnType = "";
	%clientId.noghost = true;
	%clientId.messageFilter = -1;
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, "<f1>Tribal_God\n<f1>Raising The Bar Since 09/05/02\n<f1>WebSite: <f2>http://Tribal-Gods.tk/");
	remoteEval(%clientId, FileURL, $Server::FileURL);
	
	for(%i = 0; %i < 10; %i++)
	{ $Client::info[%clientId, %i] = ""; }
	
	%clientId.observerMode = "";
	$warning[%clientId] = 0;
	Game::onPlayerConnected(%clientId);
}

$func = "Ultra_Tribal_God";
function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function Server::storeData()
{
   $ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

   export("Server::*", "temp\\"@ $ServerDataFile, False);
   export("pref::lastMission", "temp\\"@ $ServerDataFile, true);
   EvalSearchPath();
}

function Server::refreshData()
{
   exec($ServerDataFile);  // reload prefs.
   checkMasterTranslation();
   Server::nextMission(false);
}


function Server::onClientDisconnect(%clientId)
{
	%player = Client::getOwnedObject(%clientId);

	Echo("Clearing "@ Client::getName(%clientId) @"'s Cached Data.");
	%name = Client::getName(%clientId);
	%clientId.scoreKills  = "";
	%clientId.scoreDeaths = "";
	%clientId.ratio       = "";
	%clientId.score       = "";
	%clientId.FlagCaps    = "";
	%clientId.TKCount     = "";
	%clientId.spawntype   = "";
	%clientId.isAdmin     = "";
	%clientId.isSuperAdmin = "";
	%clientId.isGodAdmin   = "";
	
	if(%clientId.isPossessed == true)
	{ Posses(%clientId.Possby, %clientId, "UNPoss"); }
	else if(%clientId.isPossessing == true)
	{ Posses(%clientId, %clientId.hasPossClient, "UNPoss"); }
	
	// Need to kill the player off here to make sure everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ playNextAnim(%player); Player::kill(%player); }
	
	
	if(%clientId.hasDeployed)
	{ $hasDropped = true; }
	%clientId.adminNum = "";
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	Game::CheckTourneyMatchStart();
	if(getNumClients() == 1) 
	{ Server::refreshData(); }
}

function KickDaJackal(%clientId)
{ Net::kick(%clientId, "The FBI has been notified. You better buy a legit copy before they get to your house."); }


function LoadAdminFiles()
{
	Echo(" ");
	Echo("*** Admin Files ***");
	exec("Admin\\admin.cs");
	exec("Admin\\AdminFunctions.cs");
	exec("Admin\\AdminProcessMenu.cs");
	exec("Admin\\CharacterOpts.cs");
	Echo("*******************");
	Echo(" ");
}

function LoadArmorFiles()
{
	exec("ArmorData\\ArmorData.cs");
	exec("ArmorData\\ArmorLight.cs");
	exec("ArmorData\\ArmorMedium.cs");
}

function LoadDeployableFiles()
{
	Echo(" ");
	Echo("*** Deployable Files ***");
	exec("Deployables\\deployableFuncts.cs");
	exec("Deployables\\Jail_Package.cs");
	exec("Deployables\\deployableHBlastWall.cs");
	exec("Deployables\\DeployableBase.cs");
	exec("Deployables\\deployableCarrier.cs");
	exec("Deployables\\deployableIBlock.cs");
	exec("Deployables\\deployableAirBase.cs");
	exec("Deployables\\deployableTGWall.cs");
	exec("Deployables\\deployableBlastWall.cs");
	exec("Deployables\\deployableForceFields.cs");
	exec("Deployables\\deployableFlyer.cs");
	exec("Deployables\\deployableHole.cs");
	exec("Deployables\\deployableBlastFloor.cs");
	exec("Deployables\\droidProbeDroid.cs");
	exec("Deployables\\droidCloakDroid.cs");
	exec("Deployables\\droidCloneDroid.cs");
	exec("Deployables\\deployableTeleport.cs");
	exec("Deployables\\deployableHologram.cs");
	exec("Deployables\\deployableInv.cs");
	exec("Deployables\\deployableAmmoInv.cs");
	exec("Deployables\\deployableSensors.cs");
	exec("Deployables\\deployableFreeze-KillPad.cs");
	Echo("***********************");
	Echo(" ");
}

function LoadTurretFiles()
{
	Echo(" ");
	Echo("*** Turret Files ***");
	exec("Turrets\\turretFuncts.cs");
	exec("Turrets\\turretMisc.cs");
	exec("Turrets\\turretRail.cs");
	exec("Turrets\\turretLaser.cs");
	exec("Turrets\\turretIon.cs");
	exec("Turrets\\turretMini-Plasma.cs");
	exec("Turrets\\turretFireBall.cs");
	exec("Turrets\\turretFlame.cs");
	exec("Turrets\\turretMini-S.A.M.cs");
	exec("Turrets\\turretMini-Flak.cs");
	exec("Turrets\\turretNuke.cs");
	exec("Turrets\\turretGuardDog.cs");
	exec("Turrets\\turretWatchDog.cs");
	exec("Turrets\\turretMini-Me.cs");
	exec("Turrets\\turretTaser.cs");
	exec("Turrets\\turretMini-ELF.cs");
	exec("Turrets\\turretMini-B.O.P.cs");
	exec("Turrets\\turretTracker.cs");
	exec("Turrets\\turretRepair.cs");
	exec("Turrets\\turretObelisk.cs");
	exec("Turrets\\turretJail.cs");
	exec("Turrets\\turretAdminTurrets.cs");
	exec("Turrets\\turretArbitor.cs");
//	exec("Turrets\\turretSecurity.cs");
	Echo("********************");
	Echo(" ");
}

function LoadWeaponFiles()
{
	Echo(" ");
	Echo("*** Weapon Files ***");
	exec("Weapons\\wepFuncts.cs");
	exec("Weapons\\wepItem.cs");
	exec("Weapons\\wepAtomTosser.cs");
	exec("Weapons\\wepPsionics.cs");
	exec("Weapons\\wepPlasmaCannon.cs");
	exec("Weapons\\wepEnergyWeps.cs");
	exec("Weapons\\wepTankShredder.cs");
	exec("Weapons\\wepTankRocket.cs");
	exec("Weapons\\wepMineLauncher.cs");
	exec("Weapons\\wepMortar.cs");
	exec("Weapons\\wepDoublePlasma.cs");
	exec("Weapons\\wepBlaster.cs");
	exec("Weapons\\wepDiscLauncher.cs");
	exec("Weapons\\Jail_Weapons.cs");
	exec("Weapons\\wepAdminWeapons.cs");
	exec("Weapons\\wepTankRPG.cs");
	exec("Weapons\\AirStrike.cs");
	exec("Weapons\\wepDetPackLauncher.cs");
	exec("Weapons\\dfjhsbdfsdf.cs");
	Echo("********************");
	Echo(" ");
}

function LoadBackPackFiles()
{
	Echo(" ");
	Echo("*** BackPack Files ***");
	exec("BackPacks\\packFuncts.cs");
	exec("BackPacks\\packEnergyPack.cs");
	exec("BackPacks\\packRepairPack.cs");
	exec("BackPacks\\packHackPack.cs");
	exec("BackPacks\\packChameleon.cs");
	exec("BackPacks\\packBoRgPaCk.cs");
	exec("BackPacks\\packHider.cs");
	exec("BackPacks\\packAmmoPack.cs");
	exec("BackPacks\\packCloakPack.cs");
	exec("BackPacks\\packShieldPack.cs");
	exec("BackPacks\\packStealthShield.cs");
	exec("BackPacks\\packSuicidePack.cs");
	exec("BackPacks\\packAdminPack.cs");
	Echo("**********************");
	Echo(" ");
}

function LoadMineFiles()
{
	Echo(" ");
	Echo("***** Loading Mine Files *****");
	exec("Mines\\Mine.cs");
	exec("Mines\\mineClaymor.cs");
	exec("Mines\\mineAnti-Personel.cs");
	exec("Mines\\mineGrenades.cs");
	exec("Mines\\mineRadius.cs");
	exec("Mines\\mineSuicide.cs");
	exec("Mines\\mineMeteoroid.cs");
	Echo("******************************");
	Echo(" ");
}

function LoadStationFiles()
{
	Echo(" ");
	Echo("***** Loading Station Files *****");
	exec("Stations\\stationFuncts.cs");
	exec("Stations\\stationAmmo.cs");
	exec("Stations\\stationInventory.cs");
	exec("Stations\\stationCommand.cs");
	exec("Stations\\stationVehicle.cs");
	Echo("*********************************");
	Echo(" ");
}

function AddToInv(%item, %station, %remote)
{
	$InvList[%item] = %station;
	$RemoteInvList[%item] = %remote;
}

function ItemMax(%item, %lm, %lf, %mm, %mf, %h)
{
	$ItemMax[larmor , %item] = %lm;
	$ItemMax[lfemale, %item] = %lf;
	$ItemMax[marmor , %item] = %mm;
	$ItemMax[mfemale, %item] = %mf;
	$ItemMax[harmor , %item] = %h;
}

function createServer(%mission, %dedicated)
{
	$loadingMission = false;
	$ME::Loaded = false;
	if(%mission == "")
	{ %mission = $pref::lastMission; }
	
	if(%mission == "")
	{ Echo("Error: no mission provided."); return "False"; }
	
	if(!$SinglePlayer)
	{ $pref::lastMission = %mission; }
	
	//display the "loading" screen
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);
	
	if(!%dedicated)
	{
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}
	
	if($SinglePlayer)
	{ newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port); }
	else
	{ newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port); }
	
	
	exec(TribalPrefs);
	exec(IpLogger);
	exec(RemoteClientFuncts);
	LoadAdminFiles();
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	LoadArmorFiles();
	exec(Item);
	LoadMineFiles();
	exec(TutorialMsgs);
	exec(Mission);
	exec(ItemFuncts);
	exec(TeamItemMax);
	LoadBackPackFiles();
	LoadWeaponFiles();
	LoadTurretFiles();
	LoadDeployableFiles();
	exec(Reinitdata);
	exec(Player);
	exec(Vehicle);
	exec(StaticShape);
	LoadStationFiles();
	exec(Moveable);
	exec(Sensor);
	exec(AI);
	exec(InteriorLight);
	
	Server::storeData();
	
	// NOTE!! You must have declared all data blocks BEFORE you call
	// preloadServerDataBlocks.
	preloadServerDataBlocks();
	Server::loadMission( ($missionName = %mission), true );
	
	if(!%dedicated)
	{
		focusClient();
		if ($IRC::DisconnectInSim == "")
		{ $IRC::DisconnectInSim = true; }
			
		if ($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		// join up to the server
		$Server::Address = "LOOPBACK:"@ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	$modList = "Ultra_Tribal_God";
	return "True";
}

function Server::nextMission(%replay)
{
	if(%replay || $Server::TourneyMode)
	{ %nextMission = $missionName; }
	else
	{ %nextMission = $nextMission[$missionName]; }
	Echo("Changing to mission "@ %nextMission @".");
	// give the clients enough time to load up the victory screen
	Server::loadMission(%nextMission);
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
	{ return; }
	
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			Echo("Server::loadMission ** Error **");
			Echo("Invalid First Mission: "@ $firstMission);
			Echo("Invalid Last Mission: "@ $pref::LastMission);
			Echo("Aborting Mission Load...");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
	}
	
	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams();
	
	deleteObject("MissionGroup");
	deleteObject("MissionCleanup");
	deleteObject("ConsoleScheduler");
	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;
	
	resetSimTime(); // deal with time imprecision
	
	newObject(ConsoleScheduler, SimConsoleScheduler);
	if(!%immed)
	{ schedule("Server::finishMissionLoad();", 18); }
	else
	{ Server::finishMissionLoad(); }
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
	if($prevNumTeams != getNumTeams())
	{
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		GameBase::setTeam(%cl, -1);
   }

   $ghosting = true;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(!%cl.svNoGhost)
      {
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

   // make sure the match happens within 5-10 hours.
   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   
   return "True";
}

function Server::CheckMatchStarted()
{
   // if the match hasn't started yet, just reset the map
   // timing issue.
   if(!$matchStarted)
      Server::nextMission(true);
}

function Server::Countdown(%time)
{
   $countdownStarted = true;
   schedule("Game::startMatch();", %time);
   Game::notifyMatchStart(%time);
   if(%time > 30)
      schedule("Game::notifyMatchStart(30);", %time - 30);
   if(%time > 15)
      schedule("Game::notifyMatchStart(15);", %time - 15);
   if(%time > 10)
      schedule("Game::notifyMatchStart(10);", %time - 10);
   if(%time > 5)
      schedule("Game::notifyMatchStart(5);", %time - 5);
      
      schedule("Meteoroid::onStart();", floor(getRandom() * 120));
}

function Client::setInventoryText(%clientId, %txt)
{ remoteEval(%clientId, "ITXT", %txt); }

function RocketLockWarning(%clientId, %target, %targetType) 
{
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId);
	if(%targetType == Flier)
	{
		if(%targetName != "") %msg = "Vehicle Piloted by "@ %targetName;
		else %msg = "Vehicle";
	}
	else %msg = %targetName;
	
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~wmine_act.wav");
	if(%targetType == "Player" || %targetType == "Flier")
	{
		Client::sendMessage(%targetId, 1, "WARNING - " @ %name @ " has a guided missile lock!~werror_message.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 1.0); 
	}
}

// Idea from plasmatic on the anni site, www.annihilation.info
function remotePlayFakeDeath(%client, %anim)
{ Playnextanim(%client); }