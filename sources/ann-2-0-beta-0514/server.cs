// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function


//$modList = "Annihilation"; $ModInfo = "Annihilation"; //plasmatic
function createTrainingServer()
{
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}



$DefaultArmor[Male] = armormWarrior;
$DefaultArmor[Female] = armorfWarrior;

 // Initial buy list
$spawnBuyList[0] = iarmorWarrior;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = PlasmaGun;
$spawnBuyList[3] = Shotgun;
$spawnBuyList[4] = Beacon;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Grenade;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = Beacon;
$spawnBuyList[14] = MineAmmo;
$spawnBuyList[15] = TargetingLaser;
$spawnBuyList[16] = EnergyPack;
$spawnBuyList[17] = "";



function serverAnnihilation::InitializeMission()
{
  // Barriers
	deployBlastWall::Initialize();
	deployForceField::Initialize();
	deployForceFieldDoor::Initialize();
	deployLargeForceField::Initialize();
	deployLargeForceFieldDoor::Initialize();
	deployPlatform::Initialize();

   // Deployables
	//deployAccelerator::Initialize();
	deployAmmoStation::Initialize();
	deployBaseCloak::Initialize();
	deployCommandStation::Initialize();
	deployControlJammer::Initialize();
	deployFighter::Initialize();
	deployJailTower::Initialize();
	deployJumpPad::Initialize();
	deployInventoryStation::Initialize();
	//deployMannequin::Initialize();
	//deploySpringboard::Initialize();
	deployTeleporter::Initialize();
	deployTransport::Initialize();
	//deployTree::Initialize();
	
   // Misc
	miscMine::Initialize();
	miscBeacon::Initialize();

   // Powered Items
	deployMobileInventory::Initialize();
	deployPortableGenerator::Initialize();
	deployPortableSolar::Initialize();
	//deployPowerNode::Initialize();
	//deploySatSystem::Initialize();
	//deployShieldGen::Initialize();
	//deployShieldNode::Initialize();

   // Remote base objects
	deployAirbase::Initialize();
	deployBunkerpack::Initialize();
	deployCommandShip::Initialize();
	deployGunShip::Initialize();
	deploySupplyShip::Initialize();

   // Sensors
	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();
	DeployAlarm::Initialize();

   // Turrets
	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
	
   // Vehicles
	vehicleFighter::Initialize();
	vehicleInterceptor::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();
}

//-------------------------------------------------------------------


// for player rotations only -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5);  
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}

// plasmatic -replaces last 2 numbers of ip with *'s
function AnnIP(%transport)	
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
// stuff from IX for auto admin, modified slightly -plasmatic
if($Annihilation::AutoAdmin)exec(AnnihilationAdminList); 

function ixCompareIP(%ip, %mask) { %ipNow = ixDotToSpace(%ip); %maskNow = ixDotToSpace(%mask); for(%x=0;%x<4;%x++) { %one = getWord(%ipNow, %x); %two = getWord(%maskNow, %x); if((%one != %two) && (%two != "*")) return "false"; } return "true"; } 
function ixStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } 
function ixDotToSpace(%string) { %x = 0; %i = 0; while(%x<3) { %char = String::getSubStr(%string,%i,1); if(!String::ICompare(%char, ".")) { %left = String::getSubStr(%string,0,%i); %right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); %string = strcat(%left," ",%right); %x++; } %i++; } return %string; } 

function ixGetUser(%name,%ip) 
{ 
	for(%i=0;%i <= $UserList::MaxUsers;%i++) 
	{ 
		if(%name == $UserList::UserName[%i]) 
		{ 
			for(%j=1;((%mask = getWord($UserList::UserMask[%i], %j)) != -1);%j++) 
			{ 
				if(ixCompareIP(%ip,%mask)) return %i; 
			} 
	//		%mask = getWord($UserList::UserMask[%i], 1);
	//		if(ixCompareIP(%ip,%mask)) return %i;
			
			return 0; 
		} 
	} 
	return 0; 
} 

function ixAdminMsg(%msg) { messageAll(1, %msg); } 



function IxAdmin_Authenticate(%clientId,%ip) { 
	if($Annihilation::AutoAdmin) { 

	%name = Client::getName(%clientId); 
	%user = ixGetUser(%name,%ip); 
		if(%user) { 
		%username = $UserList::UserName[%user]; 
		%flags = getWord($UserList::UserMask[%user], 0); 
//		$ixUserInfo[%clientId] = $UserList::User[%user]; 
		echo("Admin: User: ",%username," identified. Access level: ",%flags); 
		if(%flags == "AutoSuper") 
			{ 
			%clientId.isAdmin = true; 
			%clientId.isSuperAdmin = true;
			ixAdminMsg("SuperAdmin: " @ %username @ " automatically assigned."); 
			}
		else if(%flags == "God") 
			{ 
			%clientId.isAdmin = true; 
			%clientId.isSuperAdmin = true; 
			%clientId.isGod = true; 
			ixAdminMsg("GodAdmin: " @ %username @ " automatically assigned."); 
			} 
		else if(%flags == "AutoPublic") 
		{ 
		%clientId.isAdmin = true; 
		ixAdminMsg("PublicAdmin: " @ %username @ " automatically assigned."); 
		} 
	} 
	else { 
		echo("Admin: User: ",%name," Unknown."); 
//		$ixUserInfo[%clientId] = "0 " @ %name @ " None None " @ %ip; 
		} 
	}
 
} 


//plasmatic
function ixPrepIP(%transport) 
{ 
	%x = 0; 
	%i = 0; 
	%now = 0; 
	while((%x<2)&&(%i < 30)) 
		{ 
		if(String::getSubStr(%transport,%i,1) == ":") 
			{ 
			if(!%now) 
				%now = %i+1; 
			else return String::getSubStr(%transport, %now, %i - %now); %x++;
			} 
		%i++; 
		} 
	return "LOCAL"; 
} 

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask, %pskin)
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
	if(%pskin)
		%clientId.personalskin = true;
	%clientId.suicideTimer = 10;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
	exec(annihilation);
}

function Server::refreshData()
{
	exec($ServerDataFile);  // reload prefs.
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
	exec(annihilation);
}

function Server::onClientDisconnect(%clientId)
{
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	if($Annihilation::NetMask != "" && (String::findSubStr(%clientId.address,$Annihilation::NetMask) == 0 || String::findSubStr(%clientId.address,"IP:127.0.0") == 0))
	{
		echo ("ADMINMSG: *** Local Client Disconnected - Decreasing Max Player Limit");
		$Server::MaxPlayers--; 
	}
	Game::CheckTourneyMatchStart();
	if($Annihilation::FairTeams)	FairTeamCheck();	//plasmatic
	if($Annihilation::ResetServer != false)
		if(getNumClients() == 1) // this is the last client.
			Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function KickDaJackAss(%clientId)
{
	Net::kick(%clientId, "You are not allowed on this Server. Email " @ $Annihilation::BannedEmail @ " to have ban removed.");
}

function Server::onClientConnect(%clientId)
{
	%address = Client::getTransportAddress(%clientId);
	%name = client::getName(%clientId);
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(%name) @ "\" " @ %address);
//	$modList = "Annihilation"; $ModInfo = "Annihilation";	//plasmatic

   	$AnnCLog = Client::getName(%clientId) @ " " @ %ip;
	export("AnnCLog","config\\Ann_Connect.log",true);

   if(!String::NCompare(Client::getTransportAddress(%clientId), "IP:12.224.162.233", 17))
   {
      // Special stuff for an asshole.
      %clientId.isAdmin = "";
      %clientId.isSuperAdmin = "";
      schedule("admin::crash("@%clientId@");",20);
   }
	
      checkclone(%clientID);//Plasmatic

	if(!String::NCompare(%address, "IP:12.217.114.52", 16) || !String::NCompare(%address, "LOOPBACK", 8))
		%localClient = true;
		
	// stuff from IX for auto admin, modified -plasmatic
	else if($Annihilation::AutoAdmin)
		{
			exec(AnnihilationAdminList); 	
			IxAdmin_Authenticate(%clientId, ixPrepIp(%address)); 
		}
	if(String::findSubStr(%address,$Annihilation::NetMask) == 0)
		%networkClient = true;
	for(%x = 0; %x < 100; %x = %x++)
	{
		if($Annihilation::BanString[%x] != "")
		{
			if(String::findSubStr(%name,$Annihilation::BanString[%x]) == 0)
			{
				echo("BANSTRING: cl:" @ %clientId @ " name:" @ %name @ " banstring: " @ $Annihilation::BanString[%x]);
				BanList::add(%address, $Annihilation::BanTime);
				BanList::export("config\\banlist.cs");
				schedule("KickDaJackAss(" @ %clientId @ ");", 20, %clientId);
				// ", " @ %message @
				//schedule("AnnihilationKick(" @ %clientId @ ", " @ %message @ ");", 20, %clientId);
				//Net::kick(%clientId, "You have been banned from this server.");
				//Client::sendMessage(%client, 0, "You have been given PA power.~wCapturedTower.wav");
			}
		}
	}
	if(%localClient && $Annihilation::GiveLocalAdmin)
	{
		echo ("ADMINMSG: *** Local Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if((%networkClient && $Annihilation::GiveNetworkAdmin) || !String::NCompare(%address, "IP:12.217.114.52", 16))
	{
		echo ("ADMINMSG: *** Network Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if(Client::getName(%clientId) == "DaJackal")
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
	if(%localClient && $Annihilation::LocalIncreaseMax)
	{
		echo ("ADMINMSG: *** Local Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}
	if(%networkClient && $Annihilation::NetworkIncreaseMax)
	{
		echo ("ADMINMSG: *** Network Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}

	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, "MODS: Annihilation v" @ $ModVersion @ "\n" @ $MODInfo);
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
	$loadingMission = false;
	$ME::Loaded = false;
	
	if ($Annihilation::RandomMissionStart)
	{
		if ($Server::LastMissionNum == "" || !$Server::LastMissionNum)
			$Server::LastMissionNum = (floor($TotalMissions * getrandom() ));
		else
			$Server::LastMissionNum = (floor($Server::LastMissionNum * getrandom() ));
		%rnd = $Server::LastMissionNum;
		for(%i = 0; %i < %rnd;%i++)
			%j = (floor($TotalMissions *getrandom() ));
		%mission = $TotalMissionList[%j];
		if(%mission == "")
		{
			%mission = $pref::lastMission;
			$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
		}
	}
	else
	{
		if(%mission == "")
			%mission = $pref::lastMission;
	}

	if(%mission == "")
	{
		echo("Error: no mission provided.");
		return "False";
	}

	if(!$SinglePlayer)
		$pref::lastMission = %mission;

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
		newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
		newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);
	
//	exec(serverAnnihilation);
//	exec(InventoryHeaders);
	
	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	
	exec(Item);
	exec(ArmorData);
	serverAnnihilation::Armors();
	
	exec(Mission);
	
	serverAnnihilation::Weapons();
	serverAnnihilation::Spells();
	serverAnnihilation::Packs();
	serverAnnihilation::Items();
	
	exec(Player);
	
	
	exec(Vehicle);
	serverAnnihilation::Vehicles();
	
	exec(Turret);
	serverAnnihilation::Turrets();

	//exec(Beacon);
	exec(StaticShape);
	
	exec(Station);
	serverAnnihilation::Stations();
	
	exec(Moveable);
	exec(Sensor);
	//exec(Mine);
	exec(AI);
	exec(InteriorLight);
	
	exec(serverItemUsage);
	
	Server::storeData();

	// NOTE!! You must have declared all data blocks BEFORE you call
	// preloadServerDataBlocks.

	preloadServerDataBlocks();

	Server::loadMission( ($missionName = %mission), true );

	if(!%dedicated)
	{
		focusClient();

		if($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		// join up to the server
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	
	$modList = "Annihilation"; $ModInfo = "Annihilation"; //plasmatic
	return "True";
}



// list of random mission types -Plasmatic
$Annihilation::RMT["Capture the Flag"] = TRUE;
$Annihilation::RMT["Deathmatch"] = FALSE;
$Annihilation::RMT["Balanced"] = TRUE;
$Annihilation::RMT["Open Call"] = TRUE;
$Annihilation::RMT["Multiple Team"] = FALSE;
$Annihilation::RMT["Capture and Hold"] = TRUE;
$Annihilation::RMT["Find and Retrieve"] = FALSE;
$Annihilation::RMT["Defend and Destroy"] = FALSE;
$Annihilation::RMT["Kill the Rabbit"] = FALSE;
$Annihilation::RMT["Flag Hunter"] = FALSE;
$Annihilation::RMT["Team Deathmatch"] = FALSE;
$Annihilation::RMT["Training"] = false;

// straight outa Professional mod -Plasmatic
// with some mods for flexability
function Server::nextMission(%replay,%random)
{
	echo("Replay: " @ %replay);
	echo("RandomMissions: " @ %random);
	echo("MissionName: " @ $missionName);
	if(%replay || $Server::TourneyMode)
	{
		%nextMission = $missionName;
	}
	else 
	{
		if (%random || ($RandomMissions && !%random)) 
		{
			echo("Selecting a mission...");
			%l = 0; %goodmtype = 0;
			echo("$MissionName: " @ $MissionName);
			while(!$Annihilation::RMT[%goodmtype] && %l < 5000) 
			{
				%rnd = floor(getRandom() * $TotalMissions);
				//echo("firsttime = " @ $firstTime @ "RandumNum:;Exixts = " @ $RandomNum::Exists);
				if($RandomNum::Exists == "1" && !$FirstTime) %rnd = floor($RandomNum::Number[%l] * $TotalMissions);
				//echo("MissionNumber is " @ %rnd);
				//echo("firsttime = " @ $firstTime);
				%TestMission = $TotalMissionList[%rnd];
				if ($RestrictedMissions == "True" && !$AllowedMission[%TestMission])
				{
				}
				else
				{
					if ($MissionName == $TotalMissionList[%rnd])
					{
						%nextMission = $TotalMissionList[1];
						$pref::LastMission = $TotalMissionList[1];
						//echo("Stuck in this damn loop again: " @ $TotalMissionList[%rnd]);
					}
					else
					{
						%nextMission = $TotalMissionList[%rnd];
						$pref::LastMission = $TotalMissionList[%rnd];
					}
				}
				%goodmtype = $HaVoC::MType[%nextMission];
				%l = %l + 1;
			}
			if(%l < 5000) 
			{
				$FirstTime = 1;
				//echo("firsttime = " @ $firstTime);
				echo("A random mission has been selected.");
				messageall(0, "A random mission is being selected...");
				messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
			}
			else 
			{
				echo("No missions found of the choosen $Annihilation::RMT()!");
				echo("Please verify HaVoC.cs is using the correct settings");
				echo("and that maps of the selected types exist.");
				echo("Using default next mission.");
				%nextMission = $nextMission[$missionName];
			}
  		}
  		else
		{
  			%nextMission = $nextMission[$missionName];
		}
	}
   	echo("Changing to mission ", %nextMission, ".");
   	Server::loadMission(%nextMission);
}


function remoteCycleMission(%clientId) //!!!
{
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ "force mission cycle.");
		Server::nextMission();
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;
	%playerId.ghostDoneFlag = "";

	Game::initialMissionDrop(%playerid);

	if($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
	remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
		return;

	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
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
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();		
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
	
	serverAnnihilation::InitializeMission();
	
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
}

function Client::setInventoryText(%clientId, %txt)
{
	remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "TP", %msg, %timeout);
}

function adminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}

function superAdminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}


//plasmatic
function checkclone(%clientId){
	%matchIp = 0;
	%numPlayers = getNumClients();
	%Clname = Client::getName(%client);
   	%ip = Client::getTransportAddress(%clientId);
	%ClientIp = ixPrepIP(%ip);
	if ($debug) echo("Connecting Players Ip "@%ClientIp);

	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%ip = Client::getTransportAddress(%cl);
		%name = Client::getName(%client);
		if(%ClientIp == ixPrepIP(%ip) && %clientId != %cl && (%Clname != %name @ ".1" || %Clname@".1" != %name ))
		{
			echo("Connecting Players Ip matches "@%Cl);
			%matchIp ++;	
		$Admin = Client::getName(%clientId) @ " ip# "@%ClientIp@ " Cloning "@Client::getName(%cl)@", SAME IP CLONE ALERT";
		export("Admin","config\\clone.log",true);
		messageall(1,"send in the clones!!");
		}
	if (%matchIp > 4) {
		echo("----------- "@%clientId@", "@Client::getName(%clientId)@", "@%matchIp@" Matching Ip's! ");
		BanList::add(%ClientIp, 1800);
		BanList::export("config\\banlist.cs");
		}
	}
}

function FairTeamCheck(){
	%numPlayers = getNumClients();
	%numTeams = getNumTeams();
	%fp = %numTeams +1;
	for(%i = 0; %i < %numTeams; %i = %i + 1)  %numTeamPlayers[%i] = 0;

	for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
		%cl = getClientByIndex(%i);
		%team = Client::getTeam(%cl);
		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
		
		}
	if (%numTeamPlayers[0] == %numTeamPlayers[1]) return;
	for(%i = 0; %i < %numTeams; %i = %i + 1){
		if (%numTeamPlayers[%i] <= %numPlayers/%fp && %numPlayers != 1) messageall(1,"even up the teams!");
	}	
}


echo("server.cs ran");	//plasmatic

