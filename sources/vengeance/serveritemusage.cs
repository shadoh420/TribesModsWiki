
// has to be the same as the mod folder name.. 
$modname = "Vengeance";  	// What shows up in server list. -plasmatic

$ModVersion = "1.0 Beta";	//9/6/2003 7:51AM		// BETA";
$betaBuildNumber = "";			//"11.02.02";

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ARMOR WEAPON MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[iarmorDM] = 3;
//	$MaxWeapons[armorfDM] = 3;

$MaxWeapons[iarmorNecro] = 3;
//	$MaxWeapons[armorfNecro] = 3;
//	$MaxWeapons[armormNecroFast] = 3;
//	$MaxWeapons[armorfNecroFast] = 3;
//	$MaxWeapons[armormNecroSpeed] = 3;
//	$MaxWeapons[armorfNecroSpeed] = 3;

$MaxWeapons[iarmorWarrior] = 3;
//	$MaxWeapons[armorfWarrior] = 3;
//	$MaxWeapons[armormWarriorFast] = 3;
//	$MaxWeapons[armorfWarriorFast] = 3;
//	$MaxWeapons[armormWarriorSpeed] = 3;
//	$MaxWeapons[armorfWarriorSpeed] = 3;

$MaxWeapons[iarmorTroll] = 3;
//	$MaxWeapons[armorTrollFast] = 3;
//	$MaxWeapons[armorTrollSpeed] = 3;


$MaxTool[iarmorDM] = 3;
//	$MaxTool[armorfDM] = 3;


$MaxHandDeployable[iarmorNecro] = 1;
//	$MaxHandDeployable[armorfNecro] = 1;
//	$MaxHandDeployable[armormNecroFast] = 1;
//	$MaxHandDeployable[armorfNecroFast] = 1;
//	$MaxHandDeployable[armormNecroSpeed] = 1;
//	$MaxHandDeployable[armorfNecroSpeed] = 1;

$MaxHandDeployable[iarmorWarrior] = 2;
//	$MaxHandDeployable[armorfWarrior] = 2;
//	$MaxHandDeployable[armormWarriorFast] = 2;
//	$MaxHandDeployable[armorfWarriorFast] = 2;
//	$MaxHandDeployable[armormWarriorSpeed] = 2;
//	$MaxHandDeployable[armorfWarriorSpeed] = 2;

$MaxHandDeployable[iarmorTroll] = 2;
//	$MaxHandDeployable[armorTrollFast] = 2;
//	$MaxHandDeployable[armorTrollSpeed] = 2;



// max tool
$MaxTool[iarmorNecro] = 1;
//	$MaxTool[armorfNecro] = 1;
//	$MaxTool[armormNecroFast] = 1;
//	$MaxTool[armorfNecroFast] = 1;
//	$MaxTool[armormNecroSpeed] = 1;
//	$MaxTool[armorfNecroSpeed] = 1;

$MaxTool[iarmorWarrior] = 2;
//	$MaxTool[armorfWarrior] = 2;
//	$MaxTool[armormWarriorFast] = 2;
//	$MaxTool[armorfWarriorFast] = 2;
//	$MaxTool[armormWarriorSpeed] = 2;
//	$MaxTool[armorfWarriorSpeed] = 2;

$MaxTool[iarmorTroll] = 2;
//	$MaxTool[armorTrollFast] = 2;
//	$MaxTool[armorTrollSpeed] = 2;

function PopulateCanPilot(%APC, %light,%medium,%heavy)
{
	$VehicleUse[armormDM, %APC] = %medium;
	$VehicleUse[armorfDM, %APC] = %medium;

	$VehicleUse[armormNecro, %APC] = %light;
	$VehicleUse[armorfNecro, %APC] = %light;
	$VehicleUse[armormNecroFast, %APC] = %light;
	$VehicleUse[armorfNecroFast, %APC] = %light;
	$VehicleUse[armormNecroSpeed, %APC] = %light;
	$VehicleUse[armorfNecroSpeed, %APC] = %light;		
	
	$VehicleUse[armormWarrior, %APC] = %medium;
	$VehicleUse[armorfWarrior, %APC] = %medium;
	$VehicleUse[armormWarriorFast, %APC] = %medium;
	$VehicleUse[armorfWarriorFast, %APC] = %medium;
	$VehicleUse[armormWarriorSpeed, %APC] = %medium;
	$VehicleUse[armorfWarriorSpeed, %APC] = %medium;	
	
	$VehicleUse[armorTroll, %APC] = %heavy;
	$VehicleUse[armorTrollFast, %APC] = %heavy;
	$VehicleUse[armorTrollSpeed, %APC] = %heavy;
	
	
	$VehicleUse[armormNecroIce, %APC] = %light;
	$VehicleUse[armorfNecroIce, %APC] = %light;
	$VehicleUse[armormNecroFastIce, %APC] = %light;
	$VehicleUse[armorfNecroFastIce, %APC] = %light;
	$VehicleUse[armormNecroSpeedIce, %APC] = %light;
	$VehicleUse[armorfNecroSpeedIce, %APC] = %light;		
	
	$VehicleUse[armormWarriorIce, %APC] = %medium;
	$VehicleUse[armorfWarriorIce, %APC] = %medium;
	$VehicleUse[armormWarriorFastIce, %APC] = %medium;
	$VehicleUse[armorfWarriorFastIce, %APC] = %medium;
	$VehicleUse[armormWarriorSpeedIce, %APC] = %medium;
	$VehicleUse[armorfWarriorSpeedIce, %APC] = %medium;	
	
	$VehicleUse[armorTrollIce, %APC] = %heavy;
	$VehicleUse[armorTrollFastIce, %APC] = %heavy;
	$VehicleUse[armorTrollSpeedIce, %APC] = %heavy;	

}

// we're using some math arg's to determine pilot or ride.. -Plasmatic
$CP = 1;	// can pilot
$CR = 2;	// can ride
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// CAN PILOT                  	  Light 		Medium 		Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-	---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---  ---
PopulateCanPilot(Interceptor,	$CP | $CR, 	$CP | $CR, 	$CR);
PopulateCanPilot(Scout,	$CP | $CR, 	$CP | $CR,	$CR);
PopulateCanPilot(LAPC,	$CP | $CR, 	$CP | $CR, 	$CR);
PopulateCanPilot(HAPC,	$CP | $CR, 	$CP | $CR, 	$CR);

function PopulateDamageScale(%damagetype, %light,%medium,%heavy)
{
	$ServerKeyDamageScale = $ServerKeyDamageScale+%damagetype+%light+%medium+%heavy;
	$DamageScale[armormDM, %damagetype] = %medium;
	$DamageScale[armorfDM, %damagetype] = %medium;

	$DamageScale[armormNecro, %damagetype] = %light;
	$DamageScale[armorfNecro, %damagetype] = %light;
	$DamageScale[armormNecroFast, %damagetype] = %light;
	$DamageScale[armorfNecroFast, %damagetype] = %light;
	$DamageScale[armormNecroSpeed, %damagetype] = %light;
	$DamageScale[armorfNecroSpeed, %damagetype] = %light;	
	
	$DamageScale[armormWarrior, %damagetype] = %medium;
	$DamageScale[armorfWarrior, %damagetype] = %medium;
	$DamageScale[armormWarriorFast, %damagetype] = %medium;
	$DamageScale[armorfWarriorFast, %damagetype] = %medium;	
	$DamageScale[armormWarriorSpeed, %damagetype] = %medium;
	$DamageScale[armorfWarriorSpeed, %damagetype] = %medium;	

	$DamageScale[armorTroll, %damagetype] = %heavy;
	$DamageScale[armorTrollFast, %damagetype] = %heavy;
	$DamageScale[armorTrollSpeed, %damagetype] = %heavy;
	
	
	$DamageScale[armormNecroIce, %damagetype] = %light;
	$DamageScale[armorfNecroIce, %damagetype] = %light;
	$DamageScale[armormNecroFastIce, %damagetype] = %light;
	$DamageScale[armorfNecroFastIce, %damagetype] = %light;
	$DamageScale[armormNecroSpeedIce, %damagetype] = %light;
	$DamageScale[armorfNecroSpeedIce, %damagetype] = %light;	
	
	$DamageScale[armormWarriorIce, %damagetype] = %medium;
	$DamageScale[armorfWarriorIce, %damagetype] = %medium;
	$DamageScale[armormWarriorFastIce, %damagetype] = %medium;
	$DamageScale[armorfWarriorFastIce, %damagetype] = %medium;	
	$DamageScale[armormWarriorSpeedIce, %damagetype] = %medium;
	$DamageScale[armorfWarriorSpeedIce, %damagetype] = %medium;	

	$DamageScale[armorTrollIce, %damagetype] = %heavy;
	$DamageScale[armorTrollFastIce, %damagetype] = %heavy;
	$DamageScale[armorTrollSpeedIce, %damagetype] = %heavy;	

}
//					     
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DAMAGE SCALE                                 	Light Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
// adjusted -Plasmatic 
PopulateDamageScale($ImpactDamageType,         0.8, 1.0, 1.0);
PopulateDamageScale($LandingDamageType,       0.8,  1.0,  0.9);
PopulateDamageScale($BulletDamageType,           1.0, 1.0, 1.0);
PopulateDamageScale($EnergyDamageType,         0.5, 1.0,  0.7);
PopulateDamageScale($PlasmaDamageType,         0.8, 0.9, 1.0);
PopulateDamageScale($ExplosionDamageType,     1.0, 1.0, 1.0);
PopulateDamageScale($ShrapnelDamageType,       0.9, 1.0, 1.0);
PopulateDamageScale($LaserDamageType,           0.9, 1.1, 1.0);
PopulateDamageScale($MortarDamageType,         1.0, 0.9, 0.8);
PopulateDamageScale($BlasterDamageType,         1.0, 1.0, 1.0);
PopulateDamageScale($ElectricityDamageType,     0.8, 1.0, 1.2);
PopulateDamageScale($CrushDamageType,           1.0, 1.0, 1.0);
PopulateDamageScale($DebrisDamageType,          0.8, 1.0, 1.0);
PopulateDamageScale($MissileDamageType,          0.8, 1.0, 1.0);
PopulateDamageScale($OSMissileDamageType,     0.7, 0.7, 1.0);
PopulateDamageScale($MineDamageType,             0.8, 0.9, 1.0);
PopulateDamageScale($SniperDamageType,           1.0, 1.0, 1.0);
PopulateDamageScale($ShockDamageType,           1.0, 1.0, 1.0);
PopulateDamageScale($ShotgunDamageType,        1.0, 1.0, 1.0);
PopulateDamageScale($SoulDamageType,              1.0, 1.0, 1.0);
PopulateDamageScale($AssassinDamageType,        1.0, 1.0, 1.0);
PopulateDamageScale($DisarmDamageType,           1.0, 1.0, 1.0);
PopulateDamageScale($TurretVortexDamageType,  1.0, 1.0, 1.0);

PopulateDamageScale($PoisonDamageType,           0.9, 1.0, 1.0);
PopulateDamageScale($TrollPlasmaDamageType,    1.0, 1.0, 1.0);
//new for Pitchfork
PopulateDamageScale($ForkImpact,	        0.8, 1.0, 1.0);
// new rocketdamage type to fix death messages -plasmatic 2.2
PopulateDamageScale($RocketDamageType,          0.8, 0.9, 1.0);
PopulateDamageScale($JettingDamage,                   0.8, 0.9, 1.0);
PopulateDamageScale($FireDamageType,         0.8, 0.9, 1.0);
//				Light Medium Heavy	
$Console::Prompt = ">>";	//plasmatic

function PopulateItemMax(%item,%light,%medium,%heavy)
{
	$serverKeyItemMax = $serverKeyItemMax+%light+%medium+%heavy;
	$serverKeyItemReload = $serverKeyItemReload+ %item.imageType.reloadTime;
	$serverKeyItemFire = $serverKeyItemFire + %item.imageType.fireTime;
	$serverKeyItemType = $serverKeyItemType + %item.imageType.weaponType;

	$ItemMax[armormNecro, %item] = %light;
	$ItemMax[armorfNecro, %item] = %light;
	$ItemMax[armormNecroFast, %item] = %light;
	$ItemMax[armorfNecroFast, %item] = %light;
	$ItemMax[armormNecroSpeed, %item] = %light;
	$ItemMax[armorfNecroSpeed, %item] = %light;	
	
	$ItemMax[armormWarrior, %item] = %medium;
	$ItemMax[armorfWarrior, %item] = %medium;
	$ItemMax[armormWarriorFast, %item] = %medium;
	$ItemMax[armorfWarriorFast, %item] = %medium;	
	$ItemMax[armormWarriorSpeed, %item] = %medium;
	$ItemMax[armorfWarriorSpeed, %item] = %medium;	

	$ItemMax[armorTroll, %item] = %heavy;
	$ItemMax[armorTrollFast, %item] = %heavy;
	$ItemMax[armorTrollSpeed, %item] = %heavy;
	
	$ItemMax[armormNecroIce, %item] = %light;
	$ItemMax[armorfNecroIce, %item] = %light;
	$ItemMax[armormNecroFastIce, %item] = %light;
	$ItemMax[armorfNecroFastIce, %item] = %light;
	$ItemMax[armormNecroSpeedIce, %item] = %light;
	$ItemMax[armorfNecroSpeedIce, %item] = %light;	
	
	$ItemMax[armormWarriorIce, %item] = %medium;
	$ItemMax[armorfWarriorIce, %item] = %medium;
	$ItemMax[armormWarriorFastIce, %item] = %medium;
	$ItemMax[armorfWarriorFastIce, %item] = %medium;	
	$ItemMax[armormWarriorSpeedIce, %item] = %medium;
	$ItemMax[armorfWarriorSpeedIce, %item] = %medium;	

	$ItemMax[armorTrollIce, %item] = %heavy;
	$ItemMax[armorTrollFastIce, %item] = %heavy;
	$ItemMax[armorTrollSpeedIce, %item] = %heavy;	
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// WEAPONS                                    		 Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(BlasterGun,			1,   1,   1);

PopulateItemMax(Buckler,			0,   1,   0);

PopulateItemMax(Chaingun,			1,   1,   1);
PopulateItemMax(BulletAmmo,			100,   150,   200);

PopulateItemMax(DiscLauncher,			1,   1,   1);
PopulateItemMax(DiscAmmo,			15,   15,   20);

PopulateItemMax(GrapplingHook,			1,   1,   1);

PopulateItemMax(Pitchfork,			0,   0,   0);	// only in build mode for now.. -PLasmatic

PopulateItemMax(GrenadeLauncher,		1,   1,   1);
PopulateItemMax(GrenadeAmmo,			10,   10,   15);

PopulateItemMax(Mortar,			0,   0,   1);
PopulateItemMax(MortarAmmo,			0,   0,   15);

PopulateItemMax(PlasmaGun,			1,   1,   1);

PopulateItemMax(RocketPod,			1,   1,   1);
PopulateItemMax(RocketPodShells,		10,   10,   15);

PopulateItemMax(SniperRifle,			1,   0,   0);
PopulateItemMax(RailAmmo,			10,   0,   0);

PopulateItemMax(EnergyBlade,			1,   1,   1);
// needed to bind 9 to use energy blade -Plasmatic
//PopulateItemMax(TargetingLaser,			1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// MISC                                        			Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(flag,				1,   1,   1);
PopulateItemMax(Grenade,			5,   8,   8);
PopulateItemMax(MineAmmo,			3,   3,   3);

// Yes I know, no beacons in T:V, we're doing something else with these lil buggers
// bah, hard coded in item.cs so we don't need em after all -Plasmatic
//PopulateItemMax(Beacon,			5,   8,   8);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// PACKS                                       		Light  Medium Heavy	
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(SpeedPack,			1,   1,   1);
PopulateItemMax(EnergyPack,			1,   1,   1);
PopulateItemMax(RepairPack,			1,   1,   1);
PopulateItemMax(ShieldPack,			1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// SENSORS                                      		Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,			1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack,	1,   1,   1);
PopulateItemMax(MotionSensorPack,		1,   1,   1);
PopulateItemMax(PulseSensorPack,		1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TURRETS                                     		Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(ShockTurretPack,		0,   1,   1);
PopulateItemMax(FlameTurretPack,		0,   1,   1);
PopulateItemMax(TurretPack,			0,   1,   1);
PopulateItemMax(RepairTurretPack,		1,   1,   1);


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// BARRIERS                                  		Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(ForceFieldDoorPack,		0,   1,   1);
PopulateItemMax(LargeForceFieldDoorPack,		0,   1,   1);
PopulateItemMax(PlatformPack,			1,   1,   1);


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DEPLOYABLES                                  		Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DeployableAmmoPack,		0,   0,   1);
PopulateItemMax(DeployableInvPack,		1,   1,   1);
PopulateItemMax(FighterPack,			1,   0,   0);
PopulateItemMax(JumpPadPack,			0,   1,   1);
PopulateItemMax(TeleportPack,			0,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// POWER SYSTEMS                              		Light  Medium Heavy
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MobileInventoryPack,		0,   0,   1);
PopulateItemMax(PortableGeneratorPack,		0,   0,   1);
PopulateItemMax(PortableSolarPack,		0,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM BARRIERS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[ForceFieldDoorPack] = 8;
$TeamItemMax[LargeForceFieldDoorPack] = 4;
$TeamItemMax[PlatformPack] = 20;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM DEPLOYABLES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[DeployableAmmoPack] = 10;
$TeamItemMax[DeployableInvPack] = 10;
$TeamItemMax[TeleportPack] = 2;
$TeamItemMax[JumpPadPack] = 3;
$TeamItemMax[FighterPack] = 5;		// 3.0 plasmatic


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM POWER SYSTEMS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[MobileInventoryPack] = 5;
$TeamItemMax[PortableGeneratorPack] = 1;
$TeamItemMax[PortableSolarPack] = 1;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM SENSORS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM TURRETS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[FlameTurretPack] = 6;
$TeamItemMax[FusionTurretPack] = 4;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[ShockTurretPack] = 8;
$TeamItemMax[VortexTurretPack] = 6;
$TeamItemMax[RepairTurretPack] = 6;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM VEHICLES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[InterceptorVehicle] = 3;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[HAPCVehicle] = 2;

