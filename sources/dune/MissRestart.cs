//==================================================================================
// 		If you got anything custom to maps you want reset, or if you have
//		any variables that need to be reset for each mission, stick it in 
//		here.
//==================================================================================
$Server::IgnoreSetTeams = false;
Tackle::TrackVelocity();
$TurretNukeTime = 0;

$Server::timeLimit = 0;
$ItemPopTime = 30;
if($Server::JustSetTeams == 1)
{
	for(%i=0;%i<$NumTeamsAvailable;%i++)	
		$Server::Team[%i] = $Server::HoldOldTeams[%i];
}
$server::JustSetTeams = $Server::JustSetTeams -1;

for(%i = 0; %i < $NumTeamsAvailable; %i++)
{
//echo("%i: " @ %i );
//echo("$Server::teamName[%i]: " @ $Server::teamName[%i] );
//echo("$Server::teamskin[%i]: " @ $Server::teamskin[%i] );
//echo("$Server::team[%i]: " @ $Server::team[%i] );
//echo("$ServerNameToKeyName[%i]: " @ $ServerNameToKeyName[%i] );

//echo("Rst " @$Server::teamName[%i]);

	$Server::teamName[%i] = $KeyNameToFullName[$Server::Team[%i]];
//echo("Rst " @ $Server::Team[%i] );
	$Server::teamSkin[%i] = $KeyNameToTeamSkin[$Server::Team[%i]];
	$ServerNameToKeyName[%i] = $Server::Team[%i];
	$KeyNameToServerName[$ServerNameToKeyName[%i]] = %i;
//echo( "Post");
//echo("$Server::teamName[%i]: " @ $Server::teamName[%i] );
//echo("$Server::teamskin[%i]: " @ $Server::teamskin[%i] );
//echo("$Server::team[%i]: " @ $Server::team[%i] );
//echo("$ServerNameToKeyName[%i]: " @ $ServerNameToKeyName[%i] );
	export("Server::*", "config\\ServerPrefs.cs", False);

}


for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
{
	%spawntime = $Server::respawntime;
	for(%x = 1; %x < $GholaOwnedMax + 1; %x++)
		$OwnedGholaList[%i, %x] = "";

	%i.gholapickarmor = "";
	%i.gholapickname = "";
	%i.dietime = 0;
	$GholaOwned[%i] = 0;
	$FaceDancerIsSwitched[%i] = false;
	$nuketime[%i] = 0;
	//%i.deaths = 0;
	//%i.kills = 0;
	//$TKCount[%i, Client::getName(%i)] = 0;
	schedule(%i@".deaths = 0;", 10, %i);  
	schedule(%i@".kills = 0;", 10, %i);  
	schedule("$TKCount[getIp("@%i@")] = 0;", 10, %i);
	schedule("$NukeCount[getIp("@%i@")] = 0;", 10, %i);
	schedule("AdjustSpawnTime(" @ %i @ ", " @ %spawntime @");", 10, %i);
	schedule("$JustNuked[getIp("@%i@")] = false;", 10, %i);
	schedule("$JustSuicided[getIp("@%i@")] = false;", 10, %i);
	schedule("$SuicideCount[getIp("@%i@")] = 0;", 10, %i);
}

$numCorpses = 0;

$NumWorms = 0;
$Worm::number[$Worm::Amt] = 0;	
$Worm::Amt--;	
$Worm::Attacking = false;

$LastDied = 0;
$LastPlayerDied[0] = "";
$LastSexDied[0] = "";
$LastArmorDied[0] = "";
$LastPlayerDied[1] = "";
$LastSexDied[1] = "";
$LastArmorDied[1] = "";
$LastPlayerDied[2] = "";
$LastSexDied[2] = "";
$LastArmorDied[2] = "";
$LastPlayerDied[3] = "";
$LastSexDied[3] = "";
$LastArmorDied[3] = "";
$LastPlayerDied[4] = "";
$LastSexDied[4] = "";
$LastArmorDied[4] = "";
$LastPlayerDied[5] = "";
$LastSexDied[5] = "";
$LastArmorDied[5] = "";


//Old INV List With fixed availabilities
$InvList[Blaster] = 0;
$InvList[Chaingun] = 0;
$InvList[Disclauncher] = 0;
$InvList[GrenadeLauncher] = 0;
$InvList[Mortar] = 0;
$InvList[PlasmaGun] = 0;
$InvList[LaserRifle] = 0;
$InvList[EnergyRifle] = 0;
$InvList[TargetingLaser] = 0;
$InvList[MineAmmo] = 0;
$InvList[Grenade] = 0;
$InvList[Beacon] = 1;

$InvList[BulletAmmo] = 0;
$InvList[PlasmaAmmo] = 0;
$InvList[DiscAmmo] = 0;
$InvList[GrenadeAmmo] = 0;
$InvList[MortarAmmo] = 0;
  
$InvList[EnergyPack] = 0;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 1;
$InvList[SensorJammerPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[CameraPack] = 1;
$InvList[TurretPack] = 0;
$InvList[AmmoPack] = 1;
$InvList[RepairKit] = 1;
$InvList[DeployableInvPack] = 1;
$InvList[DeployableAmmoPack] = 1;

//New INV List

//Weapons
$InvList[Knife] = 1;
$InvList[Knife2] = 1;
$InvList[SlipTip] = 1;
$InvList[Crysknife] = 1;
$InvList[Kindjal] = 1;
$InvList[Rapier] = 0;
$InvList[Saber] = 1;

$InvList[Pistol] = 1;
$InvList[Maula] = 1;
$InvList[Stunner] = 1;
$InvList[Rifle] = 1;
$InvList[SniperRifle] = 1;
$InvList[MGun] = 1;
$InvList[RLauncher] = 1;
$InvList[Flamethrower] = 1;
$InvList[Piller] = 1;

$InvList[Cutteray] = 1;
$InvList[SmallLas] = 1;
$InvList[RifleLas] = 1;
$InvList[HeavyLas] = 1;

$InvList[MountedArtillaryGun] = 0;
$InvList[MountedMachineGun] = 0;
$InvList[MechMachine1Gun] = 0;
$InvList[MechMachine2Gun] = 0;
$InvList[MechMachine3Gun] = 0;
$InvList[MechMachine4Gun] = 0;

//Clips
$InvList[PistolClip] = 1;
$InvList[MaulaClip] = 1;
$InvList[StunnerClip] = 1;
$InvList[RifleClip] = 1;
$InvList[MGunClip] = 1;
$InvList[SniperClip] = 1;
$InvList[CutterayCell] = 1;
$InvList[SmallLasCell] = 1;
$InvList[RifleLasCell] = 1;
$InvList[HeavyLasCell] = 1;
$InvList[RLauncherClip] = 1;

//Ammo
$InvList[PistolAmmo] = 0;
$InvList[MaulaAmmo] = 0;
$InvList[StunnerAmmo] = 0;
$InvList[RifleAmmo] = 0;
$InvList[MGunAmmo] = 0;
$InvList[SniperAmmo] = 0;
$InvList[RLauncherAmmo] = 0;
$InvList[FlamethrowerAmmo] = 1;
$InvList[PillerAmmo] = 0; // pillers use flamethrower ammo now
$InvList[CutterayAmmo] = 0;
$InvList[SmallLasAmmo] = 0;
$InvList[RifleLasAmmo] = 0;
$InvList[HeavyLasAmmo] = 0;

//Packs
$InvList[ExplosivePack] = 1;
$InvList[SuicidePack] = 1;
$InvList[FuelPack] = 1;
$InvList[SuspensorPack] = 1; 
$InvList[CamoPack] = 1; 
$InvList[GrapplePack] = 1; 

$InvList[PlasteelPack] = 1;
$InvList[SPentashieldPack] = 1;
$InvList[LPentashieldPack] = 1;
$InvList[HieregPack] = 1;
$InvList[ThumperPack] = 1; 
$InvList[DeployableGenPack] = 1;
$InvList[StationaryLasgunPack] = 1;
$InvList[RepeaterLasgunPack] = 1;
$InvList[RemoteLasgunPack] = 1;
$InvList[RemoteProjectileGunPack] = 1;
$InvList[HunterSeekerPlatformPack] = 1;
$InvList[StoneBurnerPack] = 1;
$InvList[SNukePack] = 1;
$InvList[MNukePack] = 1;
$InvList[LNukePack] = 1;
$InvList[GholaPack] = 1;
$InvList[MechGunPack] = 1; 
$InvList[MechArtillaryPack] = 1; 
$InvList[MechRocketPack] = 1; 
$InvList[MechFlamePack] = 1; 

//----------------------------------------------------------------------------

// List of all items available to buy from Remote Station
//Old list
$RemoteInvList[Blaster] = 0;
$RemoteInvList[Chaingun] = 0;
$RemoteInvList[Disclauncher] = 0;
$RemoteInvList[GrenadeLauncher] = 0;
$RemoteInvList[Mortar] = 0;
$RemoteInvList[PlasmaGun] = 0;
$RemoteInvList[LaserRifle] = 0;
$RemoteInvList[EnergyRifle] = 0;
$RemoteInvList[TargetingLaser] = 0;
$RemoteInvList[MineAmmo] = 0;
$RemoteInvList[Grenade] = 0;
$RemoteInvList[Beacon] = 0;

$RemoteInvList[BulletAmmo] = 0;
$RemoteInvList[PlasmaAmmo] = 0;
$RemoteInvList[DiscAmmo] = 0;
$RemoteInvList[GrenadeAmmo] = 0;
$RemoteInvList[MortarAmmo] = 0;
  
$RemoteInvList[EnergyPack] = 0;
$RemoteInvList[RepairPack] = 1;
$RemoteInvList[ShieldPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[CameraPack] = 1;
$RemoteInvList[TurretPack] = 0;
$RemoteInvList[AmmoPack] = 1;
$RemoteInvList[RepairKit] = 1;

//New list

//Weapons
$RemoteInvList[Knife] = 1;
$RemoteInvList[Knife2] = 1;
$RemoteInvList[SlipTip] = 1;
$RemoteInvList[Crysknife] = 1;
$RemoteInvList[Kindjal] = 1;
$RemoteInvList[Rapier] = 0;
$RemoteInvList[Saber] = 1;

$RemoteInvList[Pistol] = 1;
$RemoteInvList[Maula] = 1;
$RemoteInvList[Stunner] = 1;
$RemoteInvList[Rifle] = 1;
$RemoteInvList[MGun] = 1;
$RemoteInvList[SniperRifle] = 1;
$RemoteInvList[RLauncher] = 1;
$RemoteInvList[Flamethrower] = 1;

$RemoteInvList[Cutteray] = 1;
$RemoteInvList[SmallLas] = 1;
$RemoteInvList[RifleLas] = 1;

$RemoteInvList[MountedArtillaryGun] = 0;
$RemoteInvList[MountedMachineGun] = 0;

$RemoteInvList[MechMachine1Gun] = 0;
$RemoteInvList[MechMachine2Gun] = 0;
$RemoteInvList[MechMachine3Gun] = 0;
$RemoteInvList[MechMachine4Gun] = 0;

//Clips
$RemoteInvList[PistolClip] = 1;
$RemoteInvList[MaulaClip] = 1;
$RemoteInvList[StunnerClip] = 1;
$RemoteInvList[RifleClip] = 1;
$RemoteInvList[MGunClip] = 1;
$RemoteInvList[SniperClip] = 1;
$RemoteInvList[CutterayCell] = 1;
$RemoteInvList[SmallLasCell] = 1;
$RemoteInvList[RifleLasCell] = 1;
$RemoteInvList[HeavyLasCell] = 1;
$RemoteInvList[RLauncherClip] = 1;

//Ammo
$RemoteInvList[PistolAmmo] = 0;
$RemoteInvList[MaulaAmmo] = 0;
$RemoteInvList[StunnerAmmo] = 0;
$RemoteInvList[RifleAmmo] = 0;
$RemoteInvList[MGunAmmo] = 0;
$RemoteInvList[SniperAmmo] = 0;
$RemoteInvList[RLauncherAmmo] = 0;
$RemoteInvList[FlamethrowerAmmo] = 1;
$RemoteInvList[PillerAmmo] = 0; // Pillers use flamethrower ammo now
$RemoteInvList[CutterayAmmo] = 0;
$RemoteInvList[SmallLasAmmo] = 0;
$RemoteInvList[RifleLasAmmo] = 0;
$RemoteInvList[HeavyLasAmmo] = 0;

//Packs
$RemoteInvList[ExplosivePack] = 1;
$RemoteInvList[SuicidePack] = 1;
$RemoteInvList[FuelPack] = 1;
$RemoteInvList[SuspensorPack] = 1;
$RemoteInvList[CamoPack] = 1;
$RemoteInvList[GrapplePack] = 1;
$RemoteInvList[PlasteelPack] = 1;
$RemoteInvList[SPentashieldPack] = 1;
$RemoteInvList[LPentashieldPack] = 1;
$RemoteInvList[StationaryLasgunPack] = 1;
$RemoteInvList[RepeaterLasgunPack] = 1;
$RemoteInvList[RemoteLasgunPack] = 1;
$RemoteInvList[RemoteProjectileGunPack] = 1;
$RemoteInvList[ThumperPack] = 1; 

//----------------------------------------------------------------------------

// List of all items available to buy from Vehicle station
$VehicleInvList[ScoutVehicle] = 0;
$VehicleInvList[LAPCVehicle] = 0;
$VehicleInvList[HAPCVehicle] = 0;

$VehicleInvList[BasicThopterVehicle] = 0;
$VehicleInvList[VulcanThopterVehicle] = 0;
$VehicleInvList[LasgunThopterVehicle] = 0;
$VehicleInvList[ArtillaryThopterVehicle] = 0;
$VehicleInvList[CarryallVehicle] = 0;
$VehicleInvList[RollerVehicle] = 0;
$VehicleInvList[TrackerVehicle] = 0;
$VehicleInvList[CrawlerVehicle] = 0;

//New vehicle lists
$OrnithopterInvList[BasicThopterVehicle] = 1;
$OrnithopterInvList[VulcanThopterVehicle] = 1;
$OrnithopterInvList[LasgunThopterVehicle] = 1;
$OrnithopterInvList[ArtillaryThopterVehicle] = 1;
$OrnithopterInvList[CarryallVehicle] = 1;

$GroundCarInvList[RollerVehicle] = 1;
$GroundCarInvList[TrackerVehicle] = 1;
$GroundCarInvList[CrawlerVehicle] = 1;
//----------------------------------------------------------------------------

//Old
$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;

//New
$DataBlockName[BasicThopterVehicle] = BasicThopter;
$DataBlockName[VulcanThopterVehicle] = VulcanThopter;
$DataBlockName[LasgunThopterVehicle] = LasgunThopter;
$DataBlockName[ArtillaryThopterVehicle] = ArtillaryThopter;
$DataBlockName[CarryallVehicle] = Carryall;

$DataBlockName[RollerVehicle] = Roller;
$DataBlockName[TrackerVehicle] = Tracker;
$DataBlockName[CrawlerVehicle] = Crawler;

//Old
$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;

//New
$VehicleToItem[BasicThopter] = BasicThopterVehicle;
$VehicleToItem[VulcanThopter] = VulcanThopterVehicle;
$VehicleToItem[LasgunThopter] = LasgunThopterVehicle;
$VehicleToItem[ArtillaryThopter] = ArtillaryThopterVehicle;
$VehicleToItem[Carryall] = CarryallVehicle;

$VehicleToItem[Roller] = RollerVehicle;
$VehicleToItem[Tracker] = TrackerVehicle;
$VehicleToItem[Crawler] = CrawlerVehicle;

$TeamArmor[HH, SardaukarArmor] = 30;
$TeamArmor[HA, FremenArmor] = 35;
$TeamArmor[HA, FedaykinArmor] = 20;

function noSardForHark()
{
for(%i = 0; %i < $Server::NumTeams; %i = %i + 1)
{
	for(%j = 0; %j < $Server::NumTeams; %j = %j + 1)
	{
		if(($Server::team[%i] == HH && $Server::team[%j] == HC )
			|| ($Server::team[%i] == HC && $Server::team[%j] == HH ))
		{
			$TeamArmor[HH, SardaukarArmor] = 0;
		}
	}	
}
}
schedule("noSardForHark();",6);

//echo($MDESC::TeamCount);for(%i = 0; %i < $MDESC::TeamCount; %i = %i + 1){for(%j = 0; %j < $MDESC::TeamCount; %j = %j + 1){if(($Server::team[%i] == HH && $Server::team[%j] == HC )|| ($Server::team[%i] == HC && $Server::team[%j] == HH )){$TeamArmor[HH, SardaukarArmor] = 0;}}}

function MissionIntro::init(%clientId){}

for(%i=0;$MissionBriefing[%i] != "";%i++)
	$MissionBriefing[%i] = "";
for(%i = 0; %i < $Server::NumTeams; %i++)
{
	for(%x=0;%x<40;%x++)
	      Team::setObjective(%i, %x, " ");
}
