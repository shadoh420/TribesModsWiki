//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

FlierData Warthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.4;
   maxPitch = 0.4;
   maxSpeed = 10;
   minSpeed = 9;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 4.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierBullet;
	reloadDelay = 0.00001;
	repairRate = 0;
	fireSound = SoundWarthogFire;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "A10 Warthog";
};

FlierData SR71
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.99;
   maxPitch = 0.99;
   maxSpeed = 500;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 7500;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 100000.0;

	groundDamageScale = 1.0;

	projectileType = SR71Bolt;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "SR71 Blackbird";
};

FlierData Enterprise
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 3.0;
   maxPitch = 3.0;
   maxSpeed = 35;
   minSpeed = -2;
	lift = 2.0;
	maxAlt = 9900;
	maxVertical = 10;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = QuantumTorpedo;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundPlasmaTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "Enterprise E";
};

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.75;
   maxPitch = 0.75;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = BomberBullet;
	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundFireMortar;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "B-52 Bomber";
};

FlierData SpeedBike
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 1.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 300;
   minSpeed = -100;
	lift = 5;
	maxAlt = 1000;
	maxVertical = 2.5;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;

	groundDamageScale = 1.0;

	projectileType = SpeedBikeBullet;
	reloadDelay = 0.2;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

FlierData Colossus
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 50.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.3;
   maxPitch = 0.5;
   maxSpeed = 10;
   minSpeed = 0;
	lift = 3.0;
	maxAlt = 5000;
	maxVertical = 10;
	maxDamage = 50.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.1;

	groundDamageScale = 1.0;

	projectileType = ColossusBullet;
	reloadDelay = 0.00001;
	repairRate = 0;
	fireSound = SoundGluonFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "GTVA Colossus";
};

FlierData Arwing
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 5.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 20.0;
   maxPitch = 20.0;
   maxSpeed = 75;
   minSpeed = -20;
	lift = 0.75;
	maxAlt = 4000;
	maxVertical = 10;
	maxDamage = 10;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;

	groundDamageScale = 1.0;

	projectileType = ArwingBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = SoundFireLaser;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "SFX Arwing";
};

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 1500;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 1500;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 1.0;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $FusionDamageType]      = 1.0;
$DamageScale[Scout, $QuantumDamageType]     = 1.3;
$DamageScale[Scout, $EnergyDamageType2] = 1.0;
$DamageScale[Scout, $SniperDamageType] = 0.6;
$DamageScale[Scout, $MinigunDamageType] = 1.0;
$DamageScale[Scout, $AvengerDamageType] = 1.4;
$DamageScale[Scout, $MagnumDamageType] = 0.6;
$DamageScale[Scout, $GluonDamageType] = 1.0;
$DamageScale[Scout, $ArwingDamageType] = 1.5;
$DamageScale[Scout, $ColossusDamageType] = 1.5;
$DamageScale[Scout, $ThermonuclearDamageType] = 1.0;
$DamageScale[Scout, $AssaultChaingunDamageType] = 1.0;
$DamageScale[Scout, $PhaserRifleDamageType] = 1.3;
$DamageScale[Scout, $PhaserDamageType] = 1.0;
$DamageScale[Scout, $ShotgunDamageType] = 1.0;
$DamageScale[Scout, $PulsePhaserDamageType] = 1.0;
$DamageScale[Scout, $CannonDamageType] = 1.0;
$DamageScale[Scout, $FirestormDamageType] = 1.0;
$DamageScale[Scout, $FlakDamageType] = 2.0;
$DamageScale[Scout, $UFCDamageType] = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $FusionDamageType]      = 1.0;
$DamageScale[LAPC, $QuantumDamageType]     = 1.4;
$DamageScale[LAPC, $SniperDamageType]  = 0.5;
$DamageScale[LAPC, $EnergyDamageType2] = 1.0;
$DamageScale[LAPC, $MinigunDamageType] = 1.0;
$DamageScale[LAPC, $AvengerDamageType] = 1.2;
$DamageScale[LAPC, $MagnumDamageType]  = 0.5;
$DamageScale[LAPC, $GluonDamageType] = 1.0;
$DamageScale[LAPC, $ArwingDamageType] = 1.0;
$DamageScale[LAPC, $ColossusDamageType] = 1.2;
$DamageScale[LAPC, $ThermonuclearDamageType] = 1.0;
$DamageScale[LAPC, $AssaultChaingunDamageType] = 1.3;
$DamageScale[LAPC, $PhaserRifleDamageType] = 1.1;
$DamageScale[LAPC, $PhaserDamageType] = 1.0;
$DamageScale[LAPC, $ShotgunDamageType] = 1.0;
$DamageScale[LAPC, $PulsePhaserDamageType] = 1.0;
$DamageScale[LAPC, $CannonDamageType] = 1.3;
$DamageScale[LAPC, $FirestormDamageType] = 1.0;
$DamageScale[LAPC, $FlakDamageType] = 2.0;
$DamageScale[LAPC, $UFCDamageType] = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $FusionDamageType]      = 1.0;
$DamageScale[HAPC, $QuantumDamageType]     = 1.5;
$DamageScale[HAPC, $EnergyDamageType2] = 1.0;
$DamageScale[HAPC, $SniperDamageType] = 0.4;
$DamageScale[HAPC, $MinigunDamageType] = 1.0;
$DamageScale[HAPC, $AvengerDamageType] = 1.0;
$DamageScale[HAPC, $MagnumDamageType] = 0.4;
$DamageScale[HAPC, $GluonDamageType] = 1.0;
$DamageScale[HAPC, $ArwingDamageType] = 1.0;
$DamageScale[HAPC, $ColossusDamageType] = 1.1;
$DamageScale[HAPC, $ThermonuclearDamageType] = 1.0;
$DamageScale[HAPC, $AssaultChaingunDamageType] = 2.0;
$DamageScale[HAPC, $PhaserRifleDamageType] = 1.4;
$DamageScale[HAPC, $PhaserDamageType] = 1.0;
$DamageScale[HAPC, $ShotgunDamageType] = 1.0;
$DamageScale[HAPC, $PulsePhaserDamageType] = 1.0;
$DamageScale[HAPC, $CannonDamageType] = 1.6;
$DamageScale[HAPC, $FirestormDamageType] = 1.0;
$DamageScale[HAPC, $FlakDamageType] = 2.0;
$DamageScale[HAPC, $UFCDamageType] = 1.0;

$DamageScale[Warthog, $ImpactDamageType] = 0.3;
$DamageScale[Warthog, $BulletDamageType] = 0.3;
$DamageScale[Warthog, $PlasmaDamageType] = 1.5;
$DamageScale[Warthog, $EnergyDamageType] = 2.0;
$DamageScale[Warthog, $ExplosionDamageType] = 0.5;
$DamageScale[Warthog, $ShrapnelDamageType] = 0.3;
$DamageScale[Warthog, $DebrisDamageType] = 0.3;
$DamageScale[Warthog, $MissileDamageType] = 0.5;
$DamageScale[Warthog, $LaserDamageType] = 2.0;
$DamageScale[Warthog, $MortarDamageType] = 1.0;
$DamageScale[Warthog, $BlasterDamageType] = 1.0;
$DamageScale[Warthog, $ElectricityDamageType] = 0.0;
$DamageScale[Warthog, $MineDamageType]        = 1.0;
$DamageScale[Warthog, $FusionDamageType]      = 2.0;
$DamageScale[Warthog, $QuantumDamageType]     = 1.8;
$DamageScale[Warthog, $EnergyDamageType2] = 2.0;
$DamageScale[Warthog, $SniperDamageType] = 0.1;
$DamageScale[Warthog, $MinigunDamageType] = 0.3;
$DamageScale[Warthog, $AvengerDamageType] = 0.6;
$DamageScale[Warthog, $MagnumDamageType] = 0.1;
$DamageScale[Warthog, $GluonDamageType] = 1.0;
$DamageScale[Warthog, $ArwingDamageType] = 1.5;
$DamageScale[Warthog, $ColossusDamageType] = 1.5;
$DamageScale[Warthog, $ThermonuclearDamageType] = 1.0;
$DamageScale[Warthog, $AssaultChaingunDamageType] = 0.7;
$DamageScale[Warthog, $PhaserRifleDamageType] = 1.5;
$DamageScale[Warthog, $PhaserDamageType] = 1.5;
$DamageScale[Warthog, $ShotgunDamageType] = 0.7;
$DamageScale[Warthog, $PulsePhaserDamageType] = 1.5;
$DamageScale[Warthog, $CannonDamageType] = 0.8;
$DamageScale[Warthog, $FirestormDamageType] = 1.5;
$DamageScale[Warthog, $FlakDamageType] = 2.0;
$DamageScale[Warthog, $UFCDamageType] = 0.7;

$DamageScale[SR71, $ImpactDamageType] = 0.0;
$DamageScale[SR71, $BulletDamageType] = 1.0;
$DamageScale[SR71, $PlasmaDamageType] = 1.0;
$DamageScale[SR71, $EnergyDamageType] = 1.0;
$DamageScale[SR71, $ExplosionDamageType] = 1.0;
$DamageScale[SR71, $ShrapnelDamageType] = 1.0;
$DamageScale[SR71, $DebrisDamageType] = 1.0;
$DamageScale[SR71, $MissileDamageType] = 1.0;
$DamageScale[SR71, $LaserDamageType] = 1.0;
$DamageScale[SR71, $MortarDamageType] = 1.0;
$DamageScale[SR71, $BlasterDamageType] = 0.5;
$DamageScale[SR71, $ElectricityDamageType] = 1.0;
$DamageScale[SR71, $MineDamageType]        = 1.0;
$DamageScale[SR71, $FusionDamageType]      = 1.0;
$DamageScale[SR71, $QuantumDamageType]     = 1.0;
$DamageScale[SR71, $EnergyDamageType2] = 1.0;
$DamageScale[SR71, $SniperDamageType] = 0.4;
$DamageScale[SR71, $MinigunDamageType] = 1.0;
$DamageScale[SR71, $AvengerDamageType] = 1.3;
$DamageScale[SR71, $MagnumDamageType] = 0.4;
$DamageScale[SR71, $GluonDamageType] = 1.0;
$DamageScale[SR71, $ArwingDamageType] = 1.5;
$DamageScale[SR71, $ColossusDamageType] = 1.5;
$DamageScale[SR71, $ThermonuclearDamageType] = 1.0;
$DamageScale[SR71, $AssaultChaingunDamageType] = 1.0;
$DamageScale[SR71, $PhaserRifleDamageType] = 1.0;
$DamageScale[SR71, $PhaserDamageType] = 1.0;
$DamageScale[SR71, $ShotgunDamageType] = 1.0;
$DamageScale[SR71, $PulsePhaserDamageType] = 1.0;
$DamageScale[SR71, $CannonDamageType] = 1.0;
$DamageScale[SR71, $FirestormDamageType] = 1.0;
$DamageScale[SR71, $FlakDamageType] = 2.0;
$DamageScale[SR71, $UFCDamageType] = 1.0;

$DamageScale[Enterprise, $ImpactDamageType] = 1.0;
$DamageScale[Enterprise, $BulletDamageType] = 1.0;
$DamageScale[Enterprise, $PlasmaDamageType] = 0.8;
$DamageScale[Enterprise, $EnergyDamageType] = 0.2;
$DamageScale[Enterprise, $ExplosionDamageType] = 1.0;
$DamageScale[Enterprise, $ShrapnelDamageType] = 1.0;
$DamageScale[Enterprise, $DebrisDamageType] = 1.0;
$DamageScale[Enterprise, $MissileDamageType] = 1.0;
$DamageScale[Enterprise, $LaserDamageType] = 0.2;
$DamageScale[Enterprise, $MortarDamageType] = 1.0;
$DamageScale[Enterprise, $BlasterDamageType] = 0.1;
$DamageScale[Enterprise, $ElectricityDamageType] = 0.0;
$DamageScale[Enterprise, $MineDamageType]        = 1.0;
$DamageScale[Enterprise, $FusionDamageType]      = 0.7;
$DamageScale[Enterprise, $QuantumDamageType]     = 0.7;
$DamageScale[Enterprise, $EnergyDamageType2] = 0.2;
$DamageScale[Enterprise, $SniperDamageType] = 0.2;
$DamageScale[Enterprise, $MinigunDamageType] = 1.0;
$DamageScale[Enterprise, $AvengerDamageType] = 1.2;
$DamageScale[Enterprise, $MagnumDamageType] = 0.2;
$DamageScale[Enterprise, $GluonDamageType] = 0.5;
$DamageScale[Enterprise, $ArwingDamageType] = 0.4;
$DamageScale[Enterprise, $ColossusDamageType] = 0.5;
$DamageScale[Enterprise, $ThermonuclearDamageType] = 1.0;
$DamageScale[Enterprise, $AssaultChaingunDamageType] = 1.0;
$DamageScale[Enterprise, $PhaserRifleDamageType] = 0.3;
$DamageScale[Enterprise, $PhaserDamageType] = 0.5;
$DamageScale[Enterprise, $ShotgunDamageType] = 1.1;
$DamageScale[Enterprise, $PulsePhaserDamageType] = 0.5;
$DamageScale[Enterprise, $CannonDamageType] = 1.5;
$DamageScale[Enterprise, $FirestormDamageType] = 0.8;
$DamageScale[Enterprise, $FlakDamageType] = 2.0;
$DamageScale[Enterprise, $UFCDamageType] = 1.4;

$DamageScale[Bomber, $ImpactDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 1.0;
$DamageScale[Bomber, $PlasmaDamageType] = 1.5;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 0.8;
$DamageScale[Bomber, $LaserDamageType] = 1.0;
$DamageScale[Bomber, $MortarDamageType] = 0.8;
$DamageScale[Bomber, $BlasterDamageType] = 0.75;
$DamageScale[Bomber, $ElectricityDamageType] = 0.2;
$DamageScale[Bomber, $MineDamageType]        = 1.0;
$DamageScale[Bomber, $FusionDamageType]      = 1.4;
$DamageScale[Bomber, $QuantumDamageType]     = 1.0;
$DamageScale[Bomber, $EnergyDamageType2] = 1.0;
$DamageScale[Bomber, $SniperDamageType] = 0.3;
$DamageScale[Bomber, $MinigunDamageType] = 1.0;
$DamageScale[Bomber, $AvengerDamageType] = 1.0;
$DamageScale[Bomber, $MagnumDamageType] = 0.3;
$DamageScale[Bomber, $GluonDamageType] = 1.0;
$DamageScale[Bomber, $ArwingDamageType] = 1.5;
$DamageScale[Bomber, $ColossusDamageType] = 1.5;
$DamageScale[Bomber, $ThermonuclearDamageType] = 1.0;
$DamageScale[Bomber, $AssaultChaingunDamageType] = 1.0;
$DamageScale[Bomber, $PhaserRifleDamageType] = 1.3;
$DamageScale[Bomber, $PhaserDamageType] = 1.5;
$DamageScale[Bomber, $ShotgunDamageType] = 1.0;
$DamageScale[Bomber, $PulsePhaserDamageType] = 100.0;
$DamageScale[Bomber, $CannonDamageType] = 1.0;
$DamageScale[Bomber, $FirestormDamageType] = 1.5;
$DamageScale[Bomber, $FlakDamageType] = 2.0;
$DamageScale[Bomber, $UFCDamageType] = 1.3;

$DamageScale[SpeedBike, $ImpactDamageType] = 1.0;
$DamageScale[SpeedBike, $BulletDamageType] = 1.0;
$DamageScale[SpeedBike, $PlasmaDamageType] = 1.5;
$DamageScale[SpeedBike, $EnergyDamageType] = 1.0;
$DamageScale[SpeedBike, $ExplosionDamageType] = 1.0;
$DamageScale[SpeedBike, $ShrapnelDamageType] = 1.0;
$DamageScale[SpeedBike, $DebrisDamageType] = 1.0;
$DamageScale[SpeedBike, $MissileDamageType] = 1.5;
$DamageScale[SpeedBike, $LaserDamageType] = 1.0;
$DamageScale[SpeedBike, $MortarDamageType] = 1.0;
$DamageScale[SpeedBike, $BlasterDamageType] = 0.75;
$DamageScale[SpeedBike, $ElectricityDamageType] = 1.0;
$DamageScale[SpeedBike, $MineDamageType]        = 1.0;
$DamageScale[SpeedBike, $FusionDamageType]      = 2.0;
$DamageScale[SpeedBike, $QuantumDamageType]     = 2.0;
$DamageScale[SpeedBike, $EnergyDamageType2] = 1.0;
$DamageScale[SpeedBike, $SniperDamageType] = 0.1;
$DamageScale[SpeedBike, $MinigunDamageType] = 1.0;
$DamageScale[SpeedBike, $AvengerDamageType] = 1.0;
$DamageScale[SpeedBike, $MagnumDamageType] = 0.3;
$DamageScale[SpeedBike, $GluonDamageType] = 1.0;
$DamageScale[SpeedBike, $ArwingDamageType] = 2.0;
$DamageScale[SpeedBike, $ColossusDamageType] = 5.0;
$DamageScale[SpeedBike, $ThermonuclearDamageType] = 1.0;
$DamageScale[SpeedBike, $AssaultChaingunDamageType] = 1.0;
$DamageScale[SpeedBike, $PhaserRifleDamageType] = 1.0;
$DamageScale[SpeedBike, $PhaserDamageType] = 1.0;
$DamageScale[SpeedBike, $ShotgunDamageType] = 1.0;
$DamageScale[SpeedBike, $PulsePhaserDamageType] = 1.0;
$DamageScale[SpeedBike, $CannonDamageType] = 1.0;
$DamageScale[SpeedBike, $FirestormDamageType] = 1.5;
$DamageScale[SpeedBike, $FlakDamageType] = 2.0;
$DamageScale[SpeedBike, $UFCDamageType] = 1.0;

$DamageScale[Colossus, $ImpactDamageType] = 0.5;
$DamageScale[Colossus, $BulletDamageType] = 0.4;
$DamageScale[Colossus, $PlasmaDamageType] = 1.5;
$DamageScale[Colossus, $EnergyDamageType] = 1.5;
$DamageScale[Colossus, $ExplosionDamageType] = 0.4;
$DamageScale[Colossus, $ShrapnelDamageType] = 1.0;
$DamageScale[Colossus, $DebrisDamageType] = 1.0;
$DamageScale[Colossus, $MissileDamageType] = 1.0;
$DamageScale[Colossus, $LaserDamageType] = 1.2;
$DamageScale[Colossus, $MortarDamageType] = 1.0;
$DamageScale[Colossus, $BlasterDamageType] = 1.1;
$DamageScale[Colossus, $ElectricityDamageType] = 0.0;
$DamageScale[Colossus, $MineDamageType]        = 1.0;
$DamageScale[Colossus, $FusionDamageType]      = 1.5;
$DamageScale[Colossus, $QuantumDamageType]     = 5.0;
$DamageScale[Colossus, $EnergyDamageType2] = 1.5;
$DamageScale[Colossus, $SniperDamageType] = 0.0;
$DamageScale[Colossus, $MinigunDamageType] = 1.0;
$DamageScale[Colossus, $AvengerDamageType] = 0.4;
$DamageScale[Colossus, $MagnumDamageType] = 1.0;
$DamageScale[Colossus, $GluonDamageType] = 1.0;
$DamageScale[Colossus, $ArwingDamageType] = 0.5;
$DamageScale[Colossus, $ColossusDamageType] = 1.0;
$DamageScale[Colossus, $ThermonuclearDamageType] = 1.0;
$DamageScale[Colossus, $AssaultChaingunDamageType] = 1.0;
$DamageScale[Colossus, $PhaserRifleDamageType] = 1.3;
$DamageScale[Colossus, $PhaserDamageType] = 1.0;
$DamageScale[Colossus, $ShotgunDamageType] = 1.0;
$DamageScale[Colossus, $PulsePhaserDamageType] = 1.0;
$DamageScale[Colossus, $CannonDamageType] = 1.0;
$DamageScale[Colossus, $FirestormDamageType] = 1.5;
$DamageScale[Colossus, $FlakDamageType] = 2.0;
$DamageScale[Colossus, $UFCDamageType] = 0.5;

$DamageScale[Arwing, $ImpactDamageType] = 0.2;
$DamageScale[Arwing, $BulletDamageType] = 1.5;
$DamageScale[Arwing, $PlasmaDamageType] = 0.3;
$DamageScale[Arwing, $EnergyDamageType] = 0.3;
$DamageScale[Arwing, $ExplosionDamageType] = 1.2;
$DamageScale[Arwing, $ShrapnelDamageType] = 1.0;
$DamageScale[Arwing, $DebrisDamageType] = 1.0;
$DamageScale[Arwing, $MissileDamageType] = 1.0;
$DamageScale[Arwing, $LaserDamageType] = 0.1;
$DamageScale[Arwing, $MortarDamageType] = 1.5;
$DamageScale[Arwing, $BlasterDamageType] = 0.3;
$DamageScale[Arwing, $ElectricityDamageType] = 0.0;
$DamageScale[Arwing, $MineDamageType]        = 1.0;
$DamageScale[Arwing, $FusionDamageType]      = 1.5;
$DamageScale[Arwing, $QuantumDamageType]     = 5.0;
$DamageScale[Arwing, $EnergyDamageType2] = 0.3;
$DamageScale[Arwing, $SniperDamageType] = 0.3;
$DamageScale[Arwing, $MinigunDamageType] = 1.0;
$DamageScale[Arwing, $AvengerDamageType] = 1.0;
$DamageScale[Arwing, $MagnumDamageType] = 1.0;
$DamageScale[Arwing, $GluonDamageType] = 1.0;
$DamageScale[Arwing, $ArwingDamageType] = 1.0;
$DamageScale[Arwing, $ColossusDamageType] = 0.8;
$DamageScale[Arwing, $ThermonuclearDamageType] = 1.0;
$DamageScale[Arwing, $AssaultChaingunDamageType] = 1.3;
$DamageScale[Arwing, $PhaserRifleDamageType] = 1.0;
$DamageScale[Arwing, $PhaserDamageType] = 1.0;
$DamageScale[Arwing, $ShotgunDamageType] = 1.3;
$DamageScale[Arwing, $PulsePhaserDamageType] = 0.8;
$DamageScale[Arwing, $CannonDamageType] = 1.0;
$DamageScale[Arwing, $FirestormDamageType] = 0.3;
$DamageScale[Arwing, $FlakDamageType] = 2.0;
$DamageScale[Arwing, $UFCDamageType] = 1.5;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "barmor") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout
					&& GameBase::getDataName(%this) != Warthog
					&& GameBase::getDataName(%this) != SR71
					&& GameBase::getDataName(%this) != Enterprise
					&& GameBase::getDataName(%this) != Bomber
					&& GameBase::getDataName(%this) != SpeedBike
					&& GameBase::getDataName(%this) != Colossus
					&& GameBase::getDataName(%this) != Arwing) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light or Cicada Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "barmor")
	{
		%height = 2;
		%velocity = 90;
		%zVec = 90;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else if(%armor == "jarmor") {
		%height = 4;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}