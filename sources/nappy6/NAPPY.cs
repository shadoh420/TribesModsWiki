
//___________________________________________________________________________________________
//						DUEL ARMOR

//=====DUEL SPAWN SETUP======\\
$duelBuyList[0] = DuelerArmor;
$duelBuyList[1] = Disclauncher;
$duelBuyList[2] = RepairKit;
$duelBuyList[3] = Beacon;
$duelBuyList[4] = Grenade;
$duelBuyList[5] = EnergyPack;

//:::::::::::::::::::::::SCALES::::::::::::::::::::::::::::::::
//1 = normal/lower = less damage/higher = more damage

$Nappy::Duel::LandingDamageScale = 1;//damage from landing
$Nappy::Duel::ImpactDamageScale = 1;//damage from hitting objects
$Nappy::Duel::ExplosionDamageScale = 1;//damage from disc
$Nappy::Duel::ShrapnelDamageScale = 1;//damage from grenade

$Nappy::Duel::Ammo = 3;//ammo scale
$Nappy::Duel::ArmorStrength = 3;//armor strength scale
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//----------------------AMMO AMOUNT----------------------------
$Nappy::Duel::MineAmmo 	= 15 * $Nappy::Duel::Ammo;//obvious
$Nappy::Duel::Grenade 	= 25 * $Nappy::Duel::Ammo;//obvious
$Nappy::Duel::Beacon 	= 10 * $Nappy::Duel::Ammo;//obvious
$Nappy::Duel::RepairKit = 1 * $Nappy::Duel::Ammo;//obvious

$duelarmor[BulletAmmo] 	= 500 * $Nappy::Duel::Ammo;//obvious
$duelarmor[PlasmaAmmo] 	= 50 * $Nappy::Duel::Ammo;//obvious
$duelarmor[DiscAmmo] 	= 35 * $Nappy::Duel::Ammo;//obvious
$duelarmor[GrenadeAmmo] = 30 * $Nappy::Duel::Ammo;//obvious
$duelarmor[MortarAmmo] 	= 10 * $Nappy::Duel::Ammo;//obvious
$duelarmor[VulcanAmmo] 	= 500 * $Nappy::Duel::Ammo;//obvious
$duelarmor[RailAmmo] 	= 15 * $Nappy::Duel::Ammo;//obvious
$duelarmor[RocketAmmo] 	= 10 * $Nappy::Duel::Ammo;//obvious
$duelarmor[SniperAmmo] 	= 15 * $Nappy::Duel::Ammo;//obvious
$duelarmor[TranqAmmo] 	= 20 * $Nappy::Duel::Ammo;//obvious
$duelarmor[SilencerAmmo] = 30 * $Nappy::Duel::Ammo;//obvious
$duelarmor[NapalmAmmo] 	= 10 * $Nappy::Duel::Ammo;//obvious
$duelarmor[ShotgunAmmo] = 10 * $Nappy::Duel::Ammo;//obvious
$duelarmor[FlamerAmmo] 	= 0 * $Nappy::Duel::Ammo;//obvious
$duelarmor[MissileAmmo] = 5 * $Nappy::Duel::Ammo;//obvious
//-------------------------------------------------------------
//___________________________________________________________________________________________

$Nappy::VehicleCheckDistance::BoxLength = 30;
$Nappy::VehicleCheckDistance::BoxWidth = 30;
$Nappy::VehicleCheckDistance::BoxHeight = 30;


$Nappy::VehicleServerCrashDistance::BoxLength = 30;
$Nappy::VehicleServerCrashDistance::BoxWidth = 30;
$Nappy::VehicleServerCrashDistance::BoxHeight = 30;



////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
$Nappy::Builder::ObjectStrength = 0.25;
$Nappy::Builder::DeployableDistance = 9999;


$Nappy::Turret::controllReactivationTime = 3;

$Nappy::PersonalSkins = 1;

$Nappy::Elevator::ArmorCrushDamage = 0.01;
$Nappy::Elevator::ObjectCrushDamage = 999;



$Nappy::Gun[RepairGun, reloadTime] = 3;//time it takes to shoot the gun again
$Nappy::Gun[RepairGun, minEnergy] = 3; //this is how much energy you have and turns off the gun
$Nappy::Gun[RepairGun, maxEnergy] = 10;//this is how much energy it will take if you have it 

$Nappy::Projectile[RepairBolt, autoRepairRate] = 0.25;//repair rate when you repair yourself
$Nappy::Projectile[RepairBolt, ObjectRepairRate] = 3.0;//repair rate for non-player objects
$Nappy::Projectile[RepairBolt, OtherPlayerRepairRate] = 0.75;//repair rate when repairing someone else


$Nappy::ItemFavorites = "Nappy_Test";//name of the server favorites set

$Base::validate = false;//validates shapes and materials but I would keep it off 
			 //cause of problems with it not letting people join the server

$Nappy::validate = false;//validates shapes and materials but I would keep it off 
			 //cause of problems with it not letting people join the server

$BaseArmors = 0;//turn base armors on and off
$BuilderMode = 0;//turn builder mode on and off
$BaseMode = 0;   // if = 1 then you spawn with base armor spawn

$Nappy::AdminObserverOtherTeamChatColor = 0;//0=white 1=red 2=yellow 3=green

$Nappy::SetOwnerToTurrets = 1;//sets deployer as the owner of the turret and give points

$Nappy::TeleportReenableTime = 5;//time it takes to use teleport again
$Nappy::TeleportTime = 1.25;//time it takes to teleport

$Nappy::PackTime = 5;//time it takes to repack an item
$Nappy::VehiclePackTime = 5;//time it takes to pack a vehicle

$Nappy::ItemRespawnTime = 30;//time it takes for items to respawn

$Nappy::respawnInvulnerableTime = 0;//spawn shield time

$Nappy::RemoteInvEnergy = 9000;
$Nappy::RemoteInvPrice = 800;
$Nappy::RemoteAmmoEnergy = 2000;
$Nappy::RemoteAmmoPrice = 600;

//sets deployable station energy the same as base inventory stations
$Nappy::BigStationEnergyDeployableStation = 1;

//makes it so you can buy armors from deployable inventory station
$Nappy::BuyArmorDeployableStation = 1;

//turn the deployable station to run off of the big station item list
//if set to 1 then $Nappy::BuyArmorDeployableStation can be set to 0
$Nappy::FullInventoryListDeploaybleStation = 0;

//deploy distance for objects
$Nappy::DeployableDistanceMultiplyer = 1;
if($BuilderMode)
	$Nappy::DeployableDistanceMultiplyer = $Nappy::Builder::DeployableDistance;
$Nappy::BaseDeployDistance = 15 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::StationDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::TurretDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::SmallTurretDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::SensorDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::BeaconDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::ObjectDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::WallDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::PlatformDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;
$Nappy::ObjectDeployDistance = 10 * $Nappy::DeployableDistanceMultiplyer;

//if turret range is set to 0 then the turret must be manually controlled
$Nappy::Base::PlasmaTurretRange = 150;
$Nappy::Base::ElfTurretRange = 40;
$Nappy::Base::RocketTurretRange = 270;
$Nappy::Base::RocketTurretGunRange = 300;
$Nappy::Base::MortarTurretRange = 0;
$Nappy::Base::IndoorTurretRange = 25;
$Nappy::Base::DeployableTurretRange = 30;//base ion turret...  not used in nappy



$Nappy::DeployOnAnything = 1;//makes it so you can deploy anything on any kind of object
$Nappy::NoObjectInTheWay = 1;//makes it so you can deploy as close to an object as you want
$Nappy::NoObjectInterference = 1;//makes it so you can deploy as many of the same object 
				 //next to each other

$Nappy::DuelDamageScale = 1.0;//sets damage strength for duel team


$Nappy::StaticShapeStrength = 1.0;//used to scale the strength of deployable objects
$Nappy::TurretStrength = 1.0;//use to scale the strength of turrets
$Nappy::ArmorStrength = 1.0;//used to scale the strength of the armors
if($BuilderMode){
	$Nappy::StaticShapeStrength = $Nappy::Builder::ObjectStrength;
}


$Nappy::ProjectileDamage = 1.0;//used to scale the damage of projectiles
$Nappy::LaserDamageConversion = 1.0;//used to scale the damage of lasers
$Nappy::MineDamage = 1.0;//used to scale the damage of mines
$Nappy::GrenadeDamage = 1.0;//used to scale the damage of grenades
$Nappy::BombDamage = 1.0;//used to scale the damage of bombs

$Nappy::SpeedBoostRadius = 8.0;
$Nappy::SpeedBoostStrength = 300;

//if set to 0 the mission will stay with all the objects when noone is on the server
$Nappy::RefreshOnEmpty = 0; 

//if set to 1 the mission will not change when the time is turned off
$Nappy::UnlimitedMapTime = 1; 

//if $Nappy::UnlimitedMapTime is set to 0 then it will change the mission in this amount of time
$Nappy::MapChangeTime = 18000; //18000 = 5 hours









////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////Admin Variables/////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////

//if set to 1 the public can use observer
$Nappy::Public::Observer = 0;


//This is the time that a player will be banned for in seconds.
$Nappy::BanTime = "1800";

//This is the time that a player will be kicked for in seconds.
$Nappy::KickTime = "600";

//If set to 1 this enables a TK kick-vote option to the public
$Nappy::tkClientLvl = "0";

//This is the number of Tk's needed to activate the server TK protection if it is enabled.
$Nappy::tkLimit = "5";

//If $Nappy::tkServerLvl = 2 this is the number of TK's needed to autokick rather than autovote.
$Nappy::tkMultiple = "3";

//This sets the TK protection for the server.
//0=Log only.  1=Auto vote.  2=Auto vote until kicked.  3=Auto kick.
$Nappy::tkServerLvl = "1";

//If true the public will be able to vote players to be admin.
$Nappy::AdminVote = "false";

//If true the public will be able to vote to kick players.
$Nappy::KickVote = "true";

//If true the public will be able to vote to change the mission.
$Nappy::MissionVote = "true";

//If true the public will be able to vote to change to Tournament or FreeForAll mode.
$Nappy::TourneyVote = "false";

//If true the public will be able to vote to disable or enable team damage.
$Nappy::TeamDamageVote = "true";

//If true the following 5 variables enable the corresponding manipulations to SuperAdmins.
//Note that these override $Nappy::PAManip for that manipulation if false.
$Nappy::Execute = "true";
$Nappy::Strip = "true";
$Nappy::Freeze = "true";
$Nappy::Refill = "false";
$Nappy::Launch = "true";

//If true a SuperAdmin may reset the server defaults.
//Note that this overrides $Nappy::PAResetDefaults if false.
$Nappy::ResetDefaults = "true";

//If true a SuperAdmin may change mod options.
//Note that this overrides $Nappy::PAModOptions if false.
$Nappy::ModOptions = "false";


//Note that all PA variable apply to regular Admins not SuperAdmins.

//If true an Admin may change mod options.
$Nappy::PAModOptions = "false";

//If true an Admin may reset the server defaults.
$Nappy::PAResetDefaults = "false";

//If true an Admin may change a players team.
$Nappy::PATeamChange = "true";

//If true an Admin may enable or disable team damage.
$Nappy::PATeamDamage = "true";

//If true an Admin may change team info like name and skins.
$Nappy::PATeamInfo = "false";

//If true an Admin may change the time limit.
$Nappy::PATimelimit = "true";

//If true an Admin may change the server to Tournament or FreeForAll mode.
$Nappy::PATourneyMode = "false";

//If true an Admin may ban players.
$Nappy::PABan = "false";

//If true an Admin may kick players.
$Nappy::PAKick = "true";

//If true an Admin may speak privately to other players.
$Nappy::PASpeak = "true";

//If true an Admin may change the mission.
$Nappy::PAMission = "true";

//If true an Admin may gag players.
$Nappy::PAGag = "true";

//If true an Admin may perform all enabled manipulations.
$Nappy::PAManip = "true";


