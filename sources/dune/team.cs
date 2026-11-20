//
// Team Module
//

// HOUSE RICHESE DOESN'T WORK. DON'T BOTHER WITH IT.

$NumTeamsAvailable = 7; //Change this number if you add a new team..

// Team names for keywords

// Defaults
$ServerTeamDefaults[0] = HA;
$ServerTeamDefaults[1] = HH;
$ServerTeamDefaults[2] = HC;
$ServerTeamDefaults[3] = IX;
$ServerTeamDefaults[4] = BT;
//$ServerTeamDefaults[5] = HR;
$ServerTeamDefaults[5] = MH;
$ServerTeamDefaults[6] = MH2;


//Defaults
$ServerNameToKeyName[0] = $ServerTeamDefaults[0];
$ServerNameToKeyName[1] = $ServerTeamDefaults[1];
$ServerNameToKeyName[2] = $ServerTeamDefaults[2];
$ServerNameToKeyName[3] = $ServerTeamDefaults[3];
$ServerNameToKeyName[4] = $ServerTeamDefaults[4];
//$ServerNameToKeyName[5] = $ServerTeamDefaults[5];
$ServerNameToKeyName[5] = $ServerTeamDefaults[5];
$ServerNameToKeyName[6] = $ServerTeamDefaults[6];

//Defaults
$KeyNameToServerName[$ServerTeamDefaults[0]] = 0;
$KeyNameToServerName[$ServerTeamDefaults[1]] = 1;
$KeyNameToServerName[$ServerTeamDefaults[2]] = 2;
$KeyNameToServerName[$ServerTeamDefaults[3]] = 3;
$KeyNameToServerName[$ServerTeamDefaults[4]] = 4;
//$KeyNameToServerName[$ServerTeamDefaults[5]] = 5;
$KeyNameToServerName[$ServerTeamDefaults[5]] = 5;
$KeyNameToServerName[$ServerTeamDefaults[6]] = 6;

$KeyNameToFullName[HA] = "House Atreides"; 
$KeyNameToFullName[HH] = "House Harkonnen";
$KeyNameToFullName[HC] = "House Corrino";
$KeyNameToFullName[IX] = "Ix";
$KeyNameToFullName[BT] = "Bene Tleilaxu";
$KeyNameToFullName[MH] = "Minor House";
//$KeyNameToFullName[HR] = "House Richese";
$KeyNameToFullName[MH2] = "Minor House 2";

$KeyNameToTeamSkin[HA] = "green";
$KeyNameToTeamSkin[HH] = "blue";
$KeyNameToTeamSkin[HC] = "swolf";
$KeyNameToTeamSkin[IX] = "dsword";
$KeyNameToTeamSkin[BT] = "beagle";
//$KeyNameToTeamSkin[HR] = "orange";
$KeyNameToTeamSkin[MH] = "MinorOne";
$KeyNameToTeamSkin[MH2] = "MinorTwo";


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// Team Armor availabilities

//Atreites
$TeamArmor[HA, SoldierArmor] = 100;
$TeamArmor[HA, TrooperArmor] = 100;
$TeamArmor[HA, FremenArmor] = 35;
$TeamArmor[HA, FedaykinArmor] = 20;
$TeamArmor[HA, SardaukarArmor] = 0;
$TeamArmor[HA, BasharArmor] = 0;
$TeamArmor[HA, BursegArmor] = 0;
$TeamArmor[HA, FaceDancerArmor] = 0;

//Harkonnen
$TeamArmor[HH, SoldierArmor] = 100;
$TeamArmor[HH, TrooperArmor] = 100;
$TeamArmor[HH, FremenArmor] = 0;
$TeamArmor[HH, FedaykinArmor] = 0;
$TeamArmor[HH, SardaukarArmor] = 30;
$TeamArmor[HH, BasharArmor] = 0;
$TeamArmor[HH, BursegArmor] = 0;
$TeamArmor[HH, FaceDancerArmor] = 0;

//Corrino
$TeamArmor[HC, SoldierArmor] = 0;
$TeamArmor[HC, TrooperArmor] = 0;
$TeamArmor[HC, FremenArmor] = 0;
$TeamArmor[HC, FedaykinArmor] = 0;
$TeamArmor[HC, SardaukarArmor] = 100;
$TeamArmor[HC, BasharArmor] = 50;
$TeamArmor[HC, BursegArmor] = 25;
$TeamArmor[HC, FaceDancerArmor] = 0;

//Ix
$TeamArmor[IX, SoldierArmor] = 100;
$TeamArmor[IX, TrooperArmor] = 0;
$TeamArmor[IX, FremenArmor] = 0;
$TeamArmor[IX, FedaykinArmor] = 0;
$TeamArmor[IX, SardaukarArmor] = 0;
$TeamArmor[IX, BasharArmor] = 0;
$TeamArmor[IX, BursegArmor] = 0;
$TeamArmor[IX, FaceDancerArmor] = 0;

//Bene Tleilaxu
$TeamArmor[BT, SoldierArmor] = 100;
$TeamArmor[BT, TrooperArmor] = 0;
$TeamArmor[BT, FremenArmor] = 0;
$TeamArmor[BT, FedaykinArmor] = 0;
$TeamArmor[BT, SardaukarArmor] = 0;
$TeamArmor[BT, BasharArmor] = 0;
$TeamArmor[BT, BursegArmor] = 0;
$TeamArmor[BT, FaceDancerArmor] = 25;

//House Richese
$TeamArmor[HR, SoldierArmor] = 100;
$TeamArmor[HR, TrooperArmor] = 0;
$TeamArmor[HR, FremenArmor] = 0;
$TeamArmor[HR, FedaykinArmor] = 0;
$TeamArmor[HR, SardaukarArmor] = 0;
$TeamArmor[HR, BasharArmor] = 0;
$TeamArmor[HR, BursegArmor] = 0;
$TeamArmor[HR, FaceDancerArmor] = 0;

//Minor House
$TeamArmor[MH, SoldierArmor] = 100;
$TeamArmor[MH, TrooperArmor] = 100;
$TeamArmor[MH, FremenArmor] = 0;
$TeamArmor[MH, FedaykinArmor] = 0;
$TeamArmor[MH, SardaukarArmor] = 0;
$TeamArmor[MH, BasharArmor] = 0;
$TeamArmor[MH, BursegArmor] = 0;
$TeamArmor[MH, FaceDancerArmor] = 0;

//Minor House 2
$TeamArmor[MH2, SoldierArmor] = 100;
$TeamArmor[MH2, TrooperArmor] = 100;
$TeamArmor[MH2, FremenArmor] = 0;
$TeamArmor[MH2, FedaykinArmor] = 0;
$TeamArmor[MH2, SardaukarArmor] = 0;
$TeamArmor[MH2, BasharArmor] = 0;
$TeamArmor[MH2, BursegArmor] = 0;
$TeamArmor[MH2, FaceDancerArmor] = 0;

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


// Team Vehicle availabilities

//Atreites
$TeamVehicleMax[HA, BasicThopterVehicle] = 3;
$TeamVehicleMax[HA, VulcanThopterVehicle] = 3;
$TeamVehicleMax[HA, LasgunThopterVehicle] = 3;
$TeamVehicleMax[HA, ArtillaryThopterVehicle] = 3;
$TeamVehicleMax[HA, CarryallVehicle] = 2;
$TeamVehicleMax[HA, RollerVehicle] = 0;
$TeamVehicleMax[HA, TrackerVehicle] = 0;
$TeamVehicleMax[HA, CrawlerVehicle] = 1;

//Harkonnen
$TeamVehicleMax[HH, BasicThopterVehicle] = 2;
$TeamVehicleMax[HH, VulcanThopterVehicle] = 0;
$TeamVehicleMax[HH, LasgunThopterVehicle] = 0;
$TeamVehicleMax[HH, ArtillaryThopterVehicle] = 0;
$TeamVehicleMax[HH, CarryallVehicle] = 1;
$TeamVehicleMax[HH, RollerVehicle] = 3;
$TeamVehicleMax[HH, TrackerVehicle] = 3;
$TeamVehicleMax[HH, CrawlerVehicle] = 2;

//Corrino
$TeamVehicleMax[HC, BasicThopterVehicle] = 2;
$TeamVehicleMax[HC, VulcanThopterVehicle] = 0;
$TeamVehicleMax[HC, LasgunThopterVehicle] = 0;
$TeamVehicleMax[HC, ArtillaryThopterVehicle] = 1;
$TeamVehicleMax[HC, CarryallVehicle] = 1;
$TeamVehicleMax[HC, RollerVehicle] = 0;
$TeamVehicleMax[HC, TrackerVehicle] = 2;
$TeamVehicleMax[HC, CrawlerVehicle] = 1;

//Ix
$TeamVehicleMax[IX, BasicThopterVehicle] = 2;
$TeamVehicleMax[IX, VulcanThopterVehicle] = 0;
$TeamVehicleMax[IX, LasgunThopterVehicle] = 2;
$TeamVehicleMax[IX, ArtillaryThopterVehicle] = 0;
$TeamVehicleMax[IX, CarryallVehicle] = 0;
$TeamVehicleMax[IX, RollerVehicle] = 0;
$TeamVehicleMax[IX, TrackerVehicle] = 0;
$TeamVehicleMax[IX, CrawlerVehicle] = 0;

//Bene Tleilaxu
$TeamVehicleMax[BT, BasicThopterVehicle] = 0;
$TeamVehicleMax[BT, VulcanThopterVehicle] = 0;
$TeamVehicleMax[BT, LasgunThopterVehicle] = 0;
$TeamVehicleMax[BT, ArtillaryThopterVehicle] = 0;
$TeamVehicleMax[BT, CarryallVehicle] = 0;
$TeamVehicleMax[BT, RollerVehicle] = 2;
$TeamVehicleMax[BT, TrackerVehicle] = 0;
$TeamVehicleMax[BT, CrawlerVehicle] = 0;

//House Richese
$TeamVehicleMax[HR, BasicThopterVehicle] = 2;
$TeamVehicleMax[HR, VulcanThopterVehicle] = 1;
$TeamVehicleMax[HR, LasgunThopterVehicle] = 0;
$TeamVehicleMax[HR, ArtillaryThopterVehicle] = 1;
$TeamVehicleMax[HR, CarryallVehicle] = 1;
$TeamVehicleMax[HR, RollerVehicle] = 1;
$TeamVehicleMax[HR, TrackerVehicle] = 0;
$TeamVehicleMax[HR, CrawlerVehicle] = 0;

//Minor House
$TeamVehicleMax[MH, BasicThopterVehicle] = 2;
$TeamVehicleMax[MH, VulcanThopterVehicle] = 0;
$TeamVehicleMax[MH, LasgunThopterVehicle] = 0;
$TeamVehicleMax[MH, ArtillaryThopterVehicle] = 2;
$TeamVehicleMax[MH, CarryallVehicle] = 1;
$TeamVehicleMax[MH, RollerVehicle] = 2;
$TeamVehicleMax[MH, TrackerVehicle] = 0;
$TeamVehicleMax[MH, CrawlerVehicle] = 1;

//Minor House 2
$TeamVehicleMax[MH2, BasicThopterVehicle] = 2;
$TeamVehicleMax[MH2, VulcanThopterVehicle] = 0;
$TeamVehicleMax[MH2, LasgunThopterVehicle] = 0;
$TeamVehicleMax[MH2, ArtillaryThopterVehicle] = 2;
$TeamVehicleMax[MH2, CarryallVehicle] = 1;
$TeamVehicleMax[MH2, RollerVehicle] = 2;
$TeamVehicleMax[MH2, TrackerVehicle] = 0;
$TeamVehicleMax[MH2, CrawlerVehicle] = 1;

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

//   Team specific spawnbuylist

// Atreites
$TeamSpawnBuyList[HA, 0] = SoldierArmor;
$TeamSpawnBuyList[HA, 1] = Cutteray;
$TeamSpawnBuyList[HA, 2] = Knife2;
$TeamSpawnBuyList[HA, 3] = Knife;
$TeamSpawnBuyList[HA, 4] = RepairKit;
$TeamSpawnBuyList[HA, 5] = ShieldPack;
$TeamSpawnBuyList[HA, 6] = "";

// Harkonnen
$TeamSpawnBuyList[HH, 0] = TrooperArmor;
$TeamSpawnBuyList[HH, 1] = RLauncher;
$TeamSpawnBuyList[HH, 2] = Knife;
$TeamSpawnBuyList[HH, 3] = Kindjal;
$TeamSpawnBuyList[HH, 4] = RepairKit;
$TeamSpawnBuyList[HH, 5] = RepairKit;
$TeamSpawnBuyList[HH, 6] = ShieldPack;
$TeamSpawnBuyList[HH, 7] = "";

// Corrino
$TeamSpawnBuyList[HC, 0] = SardaukarArmor;
$TeamSpawnBuyList[HC, 1] = SmallLas;
$TeamSpawnBuyList[HC, 2] = Knife2;
$TeamSpawnBuyList[HC, 3] = Knife;
$TeamSpawnBuyList[HC, 4] = Saber;
$TeamSpawnBuyList[HC, 5] = RepairKit;
$TeamSpawnBuyList[HC, 6] = ShieldPack;
$TeamSpawnBuyList[HC, 7] = "";


// Ix
$TeamSpawnBuyList[IX, 0] = SoldierArmor;
$TeamSpawnBuyList[IX, 1] = SmallLas;
$TeamSpawnBuyList[IX, 2] = Knife2;
$TeamSpawnBuyList[IX, 3] = Knife;
$TeamSpawnBuyList[IX, 4] = RepairKit;
$TeamSpawnBuyList[IX, 5] = ShieldPack;
$TeamSpawnBuyList[IX, 6] = "";

// BT
$TeamSpawnBuyList[BT, 0] = SoldierArmor;
$TeamSpawnBuyList[BT, 1] = SlipTip;
$TeamSpawnBuyList[BT, 2] = Knife2;
$TeamSpawnBuyList[BT, 3] = Knife;
$TeamSpawnBuyList[BT, 4] = RepairKit;
$TeamSpawnBuyList[BT, 5] = ShieldPack;
$TeamSpawnBuyList[BT, 6] = "";

// House Richese
$TeamSpawnBuyList[HR, 0] = SoldierArmor;
$TeamSpawnBuyList[HR, 1] = Cutteray;
$TeamSpawnBuyList[HR, 2] = Pistol;
$TeamSpawnBuyList[HR, 3] = Knife;
$TeamSpawnBuyList[HR, 4] = RepairKit;
$TeamSpawnBuyList[HR, 5] = ShieldPack;
$TeamSpawnBuyList[HR, 6] = "";

// Minor House
$TeamSpawnBuyList[MH, 0] = SoldierArmor;
$TeamSpawnBuyList[MH, 1] = Cutteray;
$TeamSpawnBuyList[MH, 2] = Knife2;
$TeamSpawnBuyList[MH, 3] = Knife;
$TeamSpawnBuyList[MH, 4] = RepairKit;
$TeamSpawnBuyList[MH, 5] = ShieldPack;
$TeamSpawnBuyList[MH, 6] = "";

// Minor House
$TeamSpawnBuyList[MH2, 0] = SoldierArmor;
$TeamSpawnBuyList[MH2, 1] = Cutteray;
$TeamSpawnBuyList[MH2, 2] = Knife2;
$TeamSpawnBuyList[MH2, 3] = Knife;
$TeamSpawnBuyList[MH2, 4] = RepairKit;
$TeamSpawnBuyList[MH2, 5] = ShieldPack;
$TeamSpawnBuyList[MH2, 6] = "";

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

//   These items cannot be used by this armor/team combo

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Atreides Soldier

$TeamRestrictedItem[HA, sarmor, SlipTip]  = true;			$TeamRestrictedItem[HA, sfemale, SlipTip]  = true;			

//Projectiles
$TeamRestrictedItem[HA, sarmor, Maula]  = true;				$TeamRestrictedItem[HA, sfemale, Maula]  = true;				
$TeamRestrictedItem[HA, sarmor, Stunner]  = true;			$TeamRestrictedItem[HA, sfemale, Stunner]  = true;				
$TeamRestrictedItem[HA, sarmor, RLauncher]  = true;			$TeamRestrictedItem[HA, sfemale, RLauncher]  = true;			
$TeamRestrictedItem[HA, sarmor, Piller]  = true;			$TeamRestrictedItem[HA, sfemale, Piller]  = true;				

//Lasguns
$TeamRestrictedItem[HA, sarmor, RifleLas]  = true;			$TeamRestrictedItem[HA, sfemale, RifleLas]  = true;			
$TeamRestrictedItem[HA, sarmor, HeavyLas]  = true;			$TeamRestrictedItem[HA, sfemale, HeavyLas]  = true;			

//New Packs
$TeamRestrictedItem[HA, sarmor, FuelPack] = true;			$TeamRestrictedItem[HA, sfemale, FuelPack] = true;				
$TeamRestrictedItem[HA, sarmor, SuspensorPack] = true;			$TeamRestrictedItem[HA, sfemale, SuspensorPack] = true;			
$TeamRestrictedItem[HA, sarmor, StoneBurnerPack] = true;		$TeamRestrictedItem[HA, sfemale, StoneBurnerPack] = true;			
$TeamRestrictedItem[HA, sarmor, SNukePack] = true;			$TeamRestrictedItem[HA, sfemale, SNukePack] = true;			
$TeamRestrictedItem[HA, sarmor, MNukePack] = true;			$TeamRestrictedItem[HA, sfemale, MNukePack] = true;			
$TeamRestrictedItem[HA, sarmor, LNukePack] = true;			$TeamRestrictedItem[HA, sfemale, LNukePack] = true;			
$TeamRestrictedItem[HA, sarmor, ThumperPack] = true;			$TeamRestrictedItem[HA, sfemale, ThumperPack] = true;			

//Old deployable packs used
$TeamRestrictedItem[HA, sarmor, PulseSensorPack] = true;		$TeamRestrictedItem[HA, sfemale, PulseSensorPack] = true;			
$TeamRestrictedItem[HA, sarmor, DeployableSensorJammerPack] = true;	$TeamRestrictedItem[HA, sfemale, DeployableSensorJammerPack] = true;	
$TeamRestrictedItem[HA, sarmor, CameraPack] = true;			$TeamRestrictedItem[HA, sfemale, CameraPack] = true;			
$TeamRestrictedItem[HA, sarmor, DeployableInvPack] = true;		$TeamRestrictedItem[HA, sfemale, DeployableInvPack] = true;		
$TeamRestrictedItem[HA, sarmor, DeployableAmmoPack] = true;		$TeamRestrictedItem[HA, sfemale, DeployableAmmoPack] = true;		

//New deployable packs used
$TeamRestrictedItem[HA, sarmor, PlasteelPack] = true;			$TeamRestrictedItem[HA, sfemale, PlasteelPack] = true;			
$TeamRestrictedItem[HA, sarmor, LPentashieldPack] = true;		$TeamRestrictedItem[HA, sfemale, LPentashieldPack] = true;			
$TeamRestrictedItem[HA, sarmor, SPentashieldPack] = true;		$TeamRestrictedItem[HA, sfemale, SPentashieldPack] = true;			
$TeamRestrictedItem[HA, sarmor, DeployableGenPack] = true;		$TeamRestrictedItem[HA, sfemale, DeployableGenPack] = true;		
$TeamRestrictedItem[HA, sarmor, StationaryLasgunPack] = true;		$TeamRestrictedItem[HA, sfemale, StationaryLasgunPack] = true;		
$TeamRestrictedItem[HA, sarmor, RemoteLasgunPack] = true;		$TeamRestrictedItem[HA, sfemale, RemoteLasgunPack] = true;			
$TeamRestrictedItem[HA, sarmor, RemoteProjectileGunPack] = true;	$TeamRestrictedItem[HA, sfemale, RemoteProjectileGunPack] = true;		
$TeamRestrictedItem[HA, sarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[HA, sfemale, HunterSeekerPlatformPack] = true;		
$TeamRestrictedItem[HA, sarmor, GholaPack] = true;			$TeamRestrictedItem[HA, sfemale, GholaPack] = true;		

//.............................................................................................................

// Atreides Trooper

//Blades
$TeamRestrictedItem[HA, tarmor, SlipTip]  = true;			$TeamRestrictedItem[HA, tfemale, SlipTip]  = true;			

//Projectiles
$TeamRestrictedItem[HA, tarmor, Maula]  = true;				$TeamRestrictedItem[HA, tfemale, Maula]  = true;				
$TeamRestrictedItem[HA, tarmor, Flamethrower]  = true;			$TeamRestrictedItem[HA, tfemale, Flamethrower]  = true;			

$TeamRestrictedItem[HA, tarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[HA, tfemale, HunterSeekerPlatformPack] = true;		
$TeamRestrictedItem[HA, tarmor, SNukePack] = true;			$TeamRestrictedItem[HA, tfemale, SNukePack] = true;			


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Harkonnen Soldier


//Projectiles
$TeamRestrictedItem[HH, sarmor, Stunner]  = true;			$TeamRestrictedItem[HH, sfemale, Stunner]  = true;				
$TeamRestrictedItem[HH, sarmor, RLauncher]  = true;			$TeamRestrictedItem[HH, sfemale, RLauncher]  = true;			
$TeamRestrictedItem[HH, sarmor, Piller]  = true;			$TeamRestrictedItem[HH, sfemale, Piller]  = true;				

//Lasguns
$TeamRestrictedItem[HH, sarmor, RifleLas]  = true;			$TeamRestrictedItem[HH, sfemale, RifleLas]  = true;			
$TeamRestrictedItem[HH, sarmor, HeavyLas]  = true;			$TeamRestrictedItem[HH, sfemale, HeavyLas]  = true;			

//New Packs
$TeamRestrictedItem[HH, sarmor, FuelPack] = true;			$TeamRestrictedItem[HH, sfemale, FuelPack] = true;				
$TeamRestrictedItem[HH, sarmor, SuicidePack] = true;			$TeamRestrictedItem[HH, sfemale, SuicidePack] = true;				
$TeamRestrictedItem[HH, sarmor, SuspensorPack] = true;			$TeamRestrictedItem[HH, sfemale, SuspensorPack] = true;			
$TeamRestrictedItem[HH, sarmor, StoneBurnerPack] = true;		$TeamRestrictedItem[HH, sfemale, StoneBurnerPack] = true;			
$TeamRestrictedItem[HH, sarmor, SNukePack] = true;			$TeamRestrictedItem[HH, sfemale, SNukePack] = true;			
$TeamRestrictedItem[HH, sarmor, MNukePack] = true;			$TeamRestrictedItem[HH, sfemale, MNukePack] = true;			
$TeamRestrictedItem[HH, sarmor, LNukePack] = true;			$TeamRestrictedItem[HH, sfemale, LNukePack] = true;			
$TeamRestrictedItem[HH, sarmor, ThumperPack] = true;			$TeamRestrictedItem[HH, sfemale, ThumperPack] = true;			

//Old deployable packs used
$TeamRestrictedItem[HH, sarmor, DeployableSensorJammerPack] = true;	$TeamRestrictedItem[HH, sfemale, DeployableSensorJammerPack] = true;	
$TeamRestrictedItem[HH, sarmor, CameraPack] = true;			$TeamRestrictedItem[HH, sfemale, CameraPack] = true;			
$TeamRestrictedItem[HH, sarmor, DeployableInvPack] = true;		$TeamRestrictedItem[HH, sfemale, DeployableInvPack] = true;		
$TeamRestrictedItem[HH, sarmor, DeployableAmmoPack] = true;		$TeamRestrictedItem[HH, sfemale, DeployableAmmoPack] = true;		

//New deployable packs used
$TeamRestrictedItem[HH, sarmor, PlasteelPack] = true;			$TeamRestrictedItem[HH, sfemale, PlasteelPack] = true;			
$TeamRestrictedItem[HH, sarmor, LPentashieldPack] = true;		$TeamRestrictedItem[HH, sfemale, LPentashieldPack] = true;			
$TeamRestrictedItem[HH, sarmor, SPentashieldPack] = true;		$TeamRestrictedItem[HH, sfemale, SPentashieldPack] = true;			
$TeamRestrictedItem[HH, sarmor, DeployableGenPack] = true;		$TeamRestrictedItem[HH, sfemale, DeployableGenPack] = true;		
$TeamRestrictedItem[HH, sarmor, StationaryLasgunPack] = true;		$TeamRestrictedItem[HH, sfemale, StationaryLasgunPack] = true;		
$TeamRestrictedItem[HH, sarmor, RemoteLasgunPack] = true;		$TeamRestrictedItem[HH, sfemale, RemoteLasgunPack] = true;			
$TeamRestrictedItem[HH, sarmor, RemoteProjectileGunPack] = true;	$TeamRestrictedItem[HH, sfemale, RemoteProjectileGunPack] = true;		
$TeamRestrictedItem[HH, sarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[HH, sfemale, HunterSeekerPlatformPack] = true;		
$TeamRestrictedItem[HH, sarmor, GholaPack] = true;			$TeamRestrictedItem[HH, sfemale, GholaPack] = true;		

//.............................................................................................................

// Harkonnen Trooper


$TeamRestrictedItem[HH, tarmor, SuicidePack] = true;			$TeamRestrictedItem[HH, tfemale, SuicidePack] = true;			

$TeamRestrictedItem[HH, tarmor, SNukePack] = true;			$TeamRestrictedItem[HH, tfemale, SNukePack] = true;			


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Corrino Sardaukar

//New Packs
$TeamRestrictedItem[HC, ssarmor, FlameThrower] = true;			$TeamRestrictedItem[HC, ssfemale, FlameThrower] = true;			

$TeamRestrictedItem[HC, ssarmor, StoneBurnerPack] = true;		$TeamRestrictedItem[HC, ssfemale, StoneBurnerPack] = true;			
$TeamRestrictedItem[HC, ssarmor, SNukePack] = true;			$TeamRestrictedItem[HC, ssfemale, SNukePack] = true;			
$TeamRestrictedItem[HC, ssarmor, MNukePack] = true;			$TeamRestrictedItem[HC, ssfemale, MNukePack] = true;			
$TeamRestrictedItem[HC, ssarmor, LNukePack] = true;			$TeamRestrictedItem[HC, ssfemale, LNukePack] = true;			

$TeamRestrictedItem[HC, ssarmor2, FlameThrower] = true;			$TeamRestrictedItem[HC, ssfemale2, FlameThrower] = true;			

$TeamRestrictedItem[HC, ssarmor2, StoneBurnerPack] = true;		$TeamRestrictedItem[HC, ssfemale2, StoneBurnerPack] = true;			
$TeamRestrictedItem[HC, ssarmor2, SNukePack] = true;			$TeamRestrictedItem[HC, ssfemale2, SNukePack] = true;			
$TeamRestrictedItem[HC, ssarmor2, MNukePack] = true;			$TeamRestrictedItem[HC, ssfemale2, MNukePack] = true;			
$TeamRestrictedItem[HC, ssarmor2, LNukePack] = true;			$TeamRestrictedItem[HC, ssfemale2, LNukePack] = true;			



//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Ix Soldier


$TeamRestrictedItem[IX, sarmor, SlipTip]  = true;			$TeamRestrictedItem[IX, sfemale, SlipTip]  = true;			

//Projectiles
$TeamRestrictedItem[IX, sarmor, Maula]  = true;				$TeamRestrictedItem[IX, sfemale, Maula]  = true;				

$TeamRestrictedItem[IX, sarmor, SuicidePack] = true;			$TeamRestrictedItem[IX, sfemale, SuicidePack] = true;				
$TeamRestrictedItem[IX, sarmor, GholaPack] = true;			$TeamRestrictedItem[IX, sfemale, GholaPack] = true;		

$TeamRestrictedItem[IX, sarmor2, SlipTip]  = true;			$TeamRestrictedItem[IX, sfemale2, SlipTip]  = true;			

//Projectiles
$TeamRestrictedItem[IX, sarmor2, Maula]  = true;			$TeamRestrictedItem[IX, sfemale2, Maula]  = true;				

$TeamRestrictedItem[IX, sarmor2, SuicidePack] = true;			$TeamRestrictedItem[IX, sfemale2, SuicidePack] = true;				
$TeamRestrictedItem[IX, sarmor2, GholaPack] = true;			$TeamRestrictedItem[IX, sfemale2, GholaPack] = true;		


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Bene Tleilaxu Soldier



//Projectiles
$TeamRestrictedItem[BT, sarmor, Stunner]  = true;			$TeamRestrictedItem[BT, sfemale, Stunner]  = true;				
$TeamRestrictedItem[BT, sarmor, Piller]  = true;			$TeamRestrictedItem[BT, sfemale, Piller]  = true;				

//Lasguns
$TeamRestrictedItem[BT, sarmor, RifleLas]  = true;			$TeamRestrictedItem[BT, sfemale, RifleLas]  = true;			
$TeamRestrictedItem[BT, sarmor, HeavyLas]  = true;			$TeamRestrictedItem[BT, sfemale, HeavyLas]  = true;			

//New Packs
$TeamRestrictedItem[BT, sarmor, FuelPack] = true;			$TeamRestrictedItem[BT, sfemale, FuelPack] = true;				
$TeamRestrictedItem[BT, sarmor, SuspensorPack] = true;			$TeamRestrictedItem[BT, sfemale, SuspensorPack] = true;			
$TeamRestrictedItem[BT, sarmor, SuicidePack] = true;			$TeamRestrictedItem[BT, sfemale, SuicidePack] = true;				

//New deployable packs used
$TeamRestrictedItem[BT, sarmor, StationaryLasgunPack] = true;		$TeamRestrictedItem[BT, sfemale, StationaryLasgunPack] = true;		
$TeamRestrictedItem[BT, sarmor, RemoteLasgunPack] = true;		$TeamRestrictedItem[BT, sfemale, RemoteLasgunPack] = true;			
$TeamRestrictedItem[BT, sarmor, RemoteProjectileGunPack] = true;	$TeamRestrictedItem[BT, sfemale, RemoteProjectileGunPack] = true;		
$TeamRestrictedItem[BT, sarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[BT, sfemale, HunterSeekerPlatformPack] = true;		


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Minor House Soldier


//Projectiles
$TeamRestrictedItem[MH, sarmor, Stunner]  = true;			$TeamRestrictedItem[MH, sfemale, Stunner]  = true;				
$TeamRestrictedItem[MH, sarmor, RLauncher]  = true;			$TeamRestrictedItem[MH, sfemale, RLauncher]  = true;			
$TeamRestrictedItem[MH, sarmor, Piller]  = true;			$TeamRestrictedItem[MH, sfemale, Piller]  = true;				

//Lasguns
$TeamRestrictedItem[MH, sarmor, RifleLas]  = true;			$TeamRestrictedItem[MH, sfemale, RifleLas]  = true;			
$TeamRestrictedItem[MH, sarmor, HeavyLas]  = true;			$TeamRestrictedItem[MH, sfemale, HeavyLas]  = true;			

//New Packs
$TeamRestrictedItem[MH, sarmor, FuelPack] = true;			$TeamRestrictedItem[MH, sfemale, FuelPack] = true;				
$TeamRestrictedItem[MH, sarmor, SuspensorPack] = true;			$TeamRestrictedItem[MH, sfemale, SuspensorPack] = true;			
$TeamRestrictedItem[MH, sarmor, StoneBurnerPack] = true;		$TeamRestrictedItem[MH, sfemale, StoneBurnerPack] = true;			
$TeamRestrictedItem[MH, sarmor, SNukePack] = true;			$TeamRestrictedItem[MH, sfemale, SNukePack] = true;			
$TeamRestrictedItem[MH, sarmor, MNukePack] = true;			$TeamRestrictedItem[MH, sfemale, MNukePack] = true;			
$TeamRestrictedItem[MH, sarmor, LNukePack] = true;			$TeamRestrictedItem[MH, sfemale, LNukePack] = true;			
$TeamRestrictedItem[MH, sarmor, ThumperPack] = true;			$TeamRestrictedItem[MH, sfemale, ThumperPack] = true;			

//Old deployable packs used
$TeamRestrictedItem[MH, sarmor, DeployableSensorJammerPack] = true;	$TeamRestrictedItem[MH, sfemale, DeployableSensorJammerPack] = true;	
$TeamRestrictedItem[MH, sarmor, CameraPack] = true;			$TeamRestrictedItem[MH, sfemale, CameraPack] = true;			
$TeamRestrictedItem[MH, sarmor, DeployableInvPack] = true;		$TeamRestrictedItem[MH, sfemale, DeployableInvPack] = true;		
$TeamRestrictedItem[MH, sarmor, DeployableAmmoPack] = true;		$TeamRestrictedItem[MH, sfemale, DeployableAmmoPack] = true;		

//New deployable packs used
$TeamRestrictedItem[MH, sarmor, PlasteelPack] = true;			$TeamRestrictedItem[MH, sfemale, PlasteelPack] = true;			
$TeamRestrictedItem[MH, sarmor, LPentashieldPack] = true;		$TeamRestrictedItem[MH, sfemale, LPentashieldPack] = true;			
$TeamRestrictedItem[MH, sarmor, SPentashieldPack] = true;		$TeamRestrictedItem[MH, sfemale, SPentashieldPack] = true;			
$TeamRestrictedItem[MH, sarmor, DeployableGenPack] = true;		$TeamRestrictedItem[MH, sfemale, DeployableGenPack] = true;		
$TeamRestrictedItem[MH, sarmor, StationaryLasgunPack] = true;		$TeamRestrictedItem[MH, sfemale, StationaryLasgunPack] = true;		
$TeamRestrictedItem[MH, sarmor, RemoteLasgunPack] = true;		$TeamRestrictedItem[MH, sfemale, RemoteLasgunPack] = true;			
$TeamRestrictedItem[MH, sarmor, RemoteProjectileGunPack] = true;	$TeamRestrictedItem[MH, sfemale, RemoteProjectileGunPack] = true;		
$TeamRestrictedItem[MH, sarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[MH, sfemale, HunterSeekerPlatformPack] = true;		
$TeamRestrictedItem[MH, sarmor, GholaPack] = true;			$TeamRestrictedItem[MH, sfemale, GholaPack] = true;		



//.............................................................................................................

// Minor House Trooper


$TeamRestrictedItem[MH, tarmor, Flamethrower]  = true;			$TeamRestrictedItem[MH, tfemale, Flamethrower]  = true;			

//New Packs
$TeamRestrictedItem[MH, tarmor, ExplosivePack] = true;			$TeamRestrictedItem[MH, tfemale, ExplosivePack] = true;			
$TeamRestrictedItem[MH, tarmor, SuicidePack] = true;			$TeamRestrictedItem[MH, tfemale, SuicidePack] = true;			


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// Minor House 2 Soldier


//Projectiles
$TeamRestrictedItem[MH2, sarmor, Stunner]  = true;			$TeamRestrictedItem[MH2, sfemale, Stunner]  = true;				
$TeamRestrictedItem[MH2, sarmor, RLauncher]  = true;			$TeamRestrictedItem[MH2, sfemale, RLauncher]  = true;			
$TeamRestrictedItem[MH2, sarmor, Piller]  = true;			$TeamRestrictedItem[MH2, sfemale, Piller]  = true;				

//Lasguns
$TeamRestrictedItem[MH2, sarmor, RifleLas]  = true;			$TeamRestrictedItem[MH2, sfemale, RifleLas]  = true;			
$TeamRestrictedItem[MH2, sarmor, HeavyLas]  = true;			$TeamRestrictedItem[MH2, sfemale, HeavyLas]  = true;			

//New Packs
$TeamRestrictedItem[MH2, sarmor, FuelPack] = true;			$TeamRestrictedItem[MH2, sfemale, FuelPack] = true;				
$TeamRestrictedItem[MH2, sarmor, SuspensorPack] = true;			$TeamRestrictedItem[MH2, sfemale, SuspensorPack] = true;			
$TeamRestrictedItem[MH2, sarmor, StoneBurnerPack] = true;		$TeamRestrictedItem[MH2, sfemale, StoneBurnerPack] = true;			
$TeamRestrictedItem[MH2, sarmor, SNukePack] = true;			$TeamRestrictedItem[MH2, sfemale, SNukePack] = true;			
$TeamRestrictedItem[MH2, sarmor, MNukePack] = true;			$TeamRestrictedItem[MH2, sfemale, MNukePack] = true;			
$TeamRestrictedItem[MH2, sarmor, LNukePack] = true;			$TeamRestrictedItem[MH2, sfemale, LNukePack] = true;			
$TeamRestrictedItem[MH2, sarmor, ThumperPack] = true;			$TeamRestrictedItem[MH2, sfemale, ThumperPack] = true;			

//Old deployable packs used
$TeamRestrictedItem[MH2, sarmor, DeployableSensorJammerPack] = true;	$TeamRestrictedItem[MH2, sfemale, DeployableSensorJammerPack] = true;	
$TeamRestrictedItem[MH2, sarmor, CameraPack] = true;			$TeamRestrictedItem[MH2, sfemale, CameraPack] = true;			
$TeamRestrictedItem[MH2, sarmor, DeployableInvPack] = true;		$TeamRestrictedItem[MH2, sfemale, DeployableInvPack] = true;		
$TeamRestrictedItem[MH2, sarmor, DeployableAmmoPack] = true;		$TeamRestrictedItem[MH2, sfemale, DeployableAmmoPack] = true;		

//New deployable packs used
$TeamRestrictedItem[MH2, sarmor, PlasteelPack] = true;			$TeamRestrictedItem[MH2, sfemale, PlasteelPack] = true;			
$TeamRestrictedItem[MH2, sarmor, LPentashieldPack] = true;		$TeamRestrictedItem[MH2, sfemale, LPentashieldPack] = true;			
$TeamRestrictedItem[MH2, sarmor, SPentashieldPack] = true;		$TeamRestrictedItem[MH2, sfemale, SPentashieldPack] = true;			
$TeamRestrictedItem[MH2, sarmor, DeployableGenPack] = true;		$TeamRestrictedItem[MH2, sfemale, DeployableGenPack] = true;		
$TeamRestrictedItem[MH2, sarmor, StationaryLasgunPack] = true;		$TeamRestrictedItem[MH2, sfemale, StationaryLasgunPack] = true;		
$TeamRestrictedItem[MH2, sarmor, RemoteLasgunPack] = true;		$TeamRestrictedItem[MH2, sfemale, RemoteLasgunPack] = true;			
$TeamRestrictedItem[MH2, sarmor, RemoteProjectileGunPack] = true;	$TeamRestrictedItem[MH2, sfemale, RemoteProjectileGunPack] = true;		
$TeamRestrictedItem[MH2, sarmor, HunterSeekerPlatformPack] = true;	$TeamRestrictedItem[MH2, sfemale, HunterSeekerPlatformPack] = true;		
$TeamRestrictedItem[MH2, sarmor, GholaPack] = true;			$TeamRestrictedItem[MH2, sfemale, GholaPack] = true;		


//.............................................................................................................

// Minor House Trooper


$TeamRestrictedItem[MH2, tarmor, Flamethrower]  = true;			$TeamRestrictedItem[MH2, tfemale, Flamethrower]  = true;			

//New Packs
$TeamRestrictedItem[MH2, tarmor, ExplosivePack] = true;			$TeamRestrictedItem[MH2, tfemale, ExplosivePack] = true;			
$TeamRestrictedItem[MH2, tarmor, SuicidePack] = true;			$TeamRestrictedItem[MH2, tfemale, SuicidePack] = true;			
