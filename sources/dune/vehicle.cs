//----------------------------------------------------------------------------
//
//~`~`~`~`~`~`~`~`~`~`NEW~`~`~`~`~`~`~`~`~`~`
//~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~`~

//Ornithopters

FlierData BasicThopter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.0;
	maxPitch = 0.5;
	maxSpeed = 75;
	minSpeed = 0;
	lift = 1.0;
	maxAlt = 75;
	maxVertical = 10;
	maxDamage = 0.4;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 5.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 2.1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 22;
	description = "Spotter";
};


FlierData VulcanThopter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.0;
	maxPitch = 0.5;
	maxSpeed = 65;
	minSpeed = 0;
	lift = 0.9;
	maxAlt = 75;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 5.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 2.1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 22;
	description = "Attack 'Thopter";
};

FlierData ArtillaryThopter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.0;
	maxPitch = 0.5;
	maxSpeed = 55;
	minSpeed = 0;
	lift = 0.9;
	maxAlt = 75;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 5.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 2.1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 22;
	description = "Artillary 'Thopter";
};

FlierData LasgunThopter
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.0;
	maxPitch = 0.5;
	maxSpeed = 65;
	minSpeed = 0;
	lift = 0.9;
	maxAlt = 75;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 5.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 2.1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 22;
	description = "Lasgun 'Thopter";
};

FlierData Carryall
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
	maxSpeed = 40;								   
	minSpeed = 0;
	lift = 0.35;
	maxAlt = 75;
	maxVertical = 6;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 5.0;

	repairRate = 0;
	ramDamage = 5;
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

	visibleDriver = False;
	driverPose = 23;
	description = "Carryall";
};

//GroundCars

FlierData Roller
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.3;
	maxPitch = 2.5;
	maxSpeed = 35;
	minSpeed = -2;
	lift = 2.0;
	maxAlt = 15;
	maxVertical = 10;
	maxDamage = 5.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
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

	visibleDriver = False;
	driverPose = 22;
	description = "Roller";
};

FlierData Tracker
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
	maxPitch = 2.5;
	maxSpeed = 25;
	minSpeed = -1;
	lift = 2.0;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.0;

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

	visibleDriver = False;
	driverPose = 23;
	description = "Tracker";
};

function Tracker::onAdd(%this) 
{
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}
FlierData Crawler
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
	maxPitch = 2.5;
	maxSpeed = 20;								   
	minSpeed = -1;
	lift = 2.0;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 9.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.0;

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

	visibleDriver = False;
	driverPose = 23;
	description = "Crawler";
};

//Old
//++++++++++++++++++++++++++++++++++++++++++

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
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = FlierRocket;
	reloadDelay = 2.0;
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
	maxAlt = 15;
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
	maxAlt = 15;
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
//New
$DamageScale[BasicThopter, $ImpactDamageType] 	= 1.0;
$DamageScale[BasicThopter, $BulletDamageType] 	= 0.7;
$DamageScale[BasicThopter, $PlasmaDamageType] 	= 1.0;
$DamageScale[BasicThopter, $EnergyDamageType] 	= 1.0;
$DamageScale[BasicThopter, $ExplosionDamageType] 	= 1.0;
$DamageScale[BasicThopter, $ShrapnelDamageType] 	= 1.0;
$DamageScale[BasicThopter, $DebrisDamageType] 	= 1.0;
$DamageScale[BasicThopter, $MissileDamageType] 	= 1.0;
$DamageScale[BasicThopter, $LaserDamageType] 	= 0.5;
$DamageScale[BasicThopter, $MortarDamageType] 	= 1.0;
$DamageScale[BasicThopter, $BlasterDamageType] 	= 0.5;
$DamageScale[BasicThopter, $ElectricityDamageType] 	= 1.0;
$DamageScale[BasicThopter, $MineDamageType]        	= 1.0;
$DamageScale[BasicThopter, $StabDamageType]        	= 0.1;
$DamageScale[BasicThopter, $StunnerDamageType]     	= 0.02;
$DamageScale[BasicThopter, $PoisonDamageType]      	= 0.0;
$DamageScale[BasicThopter, $NukeDamageType]       	= 1.0;
$DamageScale[BasicThopter, $Poison2DamageType]      	= 0.0;
$DamageScale[BasicThopter, $WormDamageType]     	= 1.0;
$DamageScale[BasicThopter, $CutterayDamageType]     	= 1.5;
$DamageScale[BasicThopter, $SmallLasDamageType]     	= 1.0;
$DamageScale[BasicThopter, $RifleLasDamageType]     	= 1.0;
$DamageScale[BasicThopter, $HeavyLasDamageType]     	= 1.0;
$DamageScale[BasicThopter, $AsphyxiationDamageType]    	= 0.0;
$DamageScale[BasicThopter, $LargeBulletDamageType] 	= 0.7;
$DamageScale[BasicThopter, $ThrownWeaponDamageType] 	= 0.1;
$DamageScale[BasicThopter, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[VulcanThopter, $ImpactDamageType] 		= 1.0;
$DamageScale[VulcanThopter, $BulletDamageType] 		= 0.7;
$DamageScale[VulcanThopter, $PlasmaDamageType] 		= 1.0;
$DamageScale[VulcanThopter, $EnergyDamageType] 		= 1.0;
$DamageScale[VulcanThopter, $ExplosionDamageType] 	= 1.0;
$DamageScale[VulcanThopter, $ShrapnelDamageType] 	= 1.0;
$DamageScale[VulcanThopter, $DebrisDamageType] 		= 1.0;
$DamageScale[VulcanThopter, $MissileDamageType] 	= 1.0;
$DamageScale[VulcanThopter, $LaserDamageType] 		= 0.5;
$DamageScale[VulcanThopter, $MortarDamageType] 		= 1.0;
$DamageScale[VulcanThopter, $BlasterDamageType] 	= 0.5;
$DamageScale[VulcanThopter, $ElectricityDamageType] 	= 1.0;
$DamageScale[VulcanThopter, $MineDamageType]        	= 1.0;
$DamageScale[VulcanThopter, $StabDamageType]        	= 0.1;
$DamageScale[VulcanThopter, $StunnerDamageType]     	= 0.02;
$DamageScale[VulcanThopter, $PoisonDamageType]      	= 0.0;
$DamageScale[VulcanThopter, $NukeDamageType]       	= 1.0;
$DamageScale[VulcanThopter, $Poison2DamageType]     	= 0.0;
$DamageScale[VulcanThopter, $WormDamageType]     	= 1.0;
$DamageScale[VulcanThopter, $CutterayDamageType]     	= 1.5;
$DamageScale[VulcanThopter, $SmallLasDamageType]     	= 1.0;
$DamageScale[VulcanThopter, $RifleLasDamageType]     	= 1.0;
$DamageScale[VulcanThopter, $HeavyLasDamageType]     	= 1.0;
$DamageScale[VulcanThopter, $AsphyxiationDamageType]   	= 0.0;
$DamageScale[VulcanThopter, $LargeBulletDamageType] 	= 0.7;
$DamageScale[VulcanThopter, $ThrownWeaponDamageType] 	= 0.1;
$DamageScale[VulcanThopter, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[LasgunThopter, $ImpactDamageType] 		= 1.0;
$DamageScale[LasgunThopter, $BulletDamageType] 		= 0.7;
$DamageScale[LasgunThopter, $PlasmaDamageType] 		= 1.0;
$DamageScale[LasgunThopter, $EnergyDamageType] 		= 1.0;
$DamageScale[LasgunThopter, $ExplosionDamageType] 	= 1.0;
$DamageScale[LasgunThopter, $ShrapnelDamageType] 	= 1.0;
$DamageScale[LasgunThopter, $DebrisDamageType] 		= 1.0;
$DamageScale[LasgunThopter, $MissileDamageType] 	= 1.0;
$DamageScale[LasgunThopter, $LaserDamageType] 		= 0.5;
$DamageScale[LasgunThopter, $MortarDamageType] 		= 1.0;
$DamageScale[LasgunThopter, $BlasterDamageType] 	= 0.5;
$DamageScale[LasgunThopter, $ElectricityDamageType] 	= 1.0;
$DamageScale[LasgunThopter, $MineDamageType]        	= 1.0;
$DamageScale[LasgunThopter, $StabDamageType]        	= 0.1;
$DamageScale[LasgunThopter, $StunnerDamageType]     	= 0.02;
$DamageScale[LasgunThopter, $PoisonDamageType]      	= 0.0;
$DamageScale[LasgunThopter, $NukeDamageType]       	= 1.0;
$DamageScale[LasgunThopter, $Poison2DamageType]     	= 0.0;
$DamageScale[LasgunThopter, $WormDamageType]     	= 1.0;
$DamageScale[LasgunThopter, $CutterayDamageType]     	= 1.5;
$DamageScale[LasgunThopter, $SmallLasDamageType]     	= 1.0;
$DamageScale[LasgunThopter, $RifleLasDamageType]     	= 1.0;
$DamageScale[LasgunThopter, $HeavyLasDamageType]     	= 1.0;
$DamageScale[LasgunThopter, $AsphyxiationDamageType]   	= 0.0;
$DamageScale[LasgunThopter, $LargeBulletDamageType] 	= 0.7;
$DamageScale[LasgunThopter, $ThrownWeaponDamageType] 	= 0.1;
$DamageScale[LasgunThopter, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[ArtillaryThopter, $ImpactDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $BulletDamageType] 	= 0.7;
$DamageScale[ArtillaryThopter, $PlasmaDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $EnergyDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $ExplosionDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $ShrapnelDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $DebrisDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $MissileDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $LaserDamageType] 	= 0.5;
$DamageScale[ArtillaryThopter, $MortarDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $BlasterDamageType] 	= 0.5;
$DamageScale[ArtillaryThopter, $ElectricityDamageType] 	= 1.0;
$DamageScale[ArtillaryThopter, $MineDamageType]        	= 1.0;
$DamageScale[ArtillaryThopter, $StabDamageType]        	= 0.1;
$DamageScale[ArtillaryThopter, $StunnerDamageType]     	= 0.02;
$DamageScale[ArtillaryThopter, $PoisonDamageType]      	= 0.0;
$DamageScale[ArtillaryThopter, $NukeDamageType]       	= 1.0;
$DamageScale[ArtillaryThopter, $Poison2DamageType]     	= 0.0;
$DamageScale[ArtillaryThopter, $WormDamageType]     	= 1.0;
$DamageScale[ArtillaryThopter, $CutterayDamageType]     = 1.5;
$DamageScale[ArtillaryThopter, $SmallLasDamageType]     = 1.0;
$DamageScale[ArtillaryThopter, $RifleLasDamageType]     = 1.0;
$DamageScale[ArtillaryThopter, $HeavyLasDamageType]     = 1.0;
$DamageScale[ArtillaryThopter, $AsphyxiationDamageType] = 0.0;
$DamageScale[ArtillaryThopter, $LargeBulletDamageType] 	= 0.7;
$DamageScale[ArtillaryThopter, $ThrownWeaponDamageType] 	= 0.1;
$DamageScale[ArtillaryThopter, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[Carryall, $ImpactDamageType] 		= 1.0;
$DamageScale[Carryall, $BulletDamageType] 		= 0.7;
$DamageScale[Carryall, $PlasmaDamageType] 		= 1.0;
$DamageScale[Carryall, $EnergyDamageType] 		= 1.0;
$DamageScale[Carryall, $ExplosionDamageType] 		= 1.0;
$DamageScale[Carryall, $ShrapnelDamageType] 		= 1.0;
$DamageScale[Carryall, $DebrisDamageType] 		= 1.0;
$DamageScale[Carryall, $MissileDamageType] 		= 1.0;
$DamageScale[Carryall, $LaserDamageType] 		= 0.5;
$DamageScale[Carryall, $MortarDamageType] 		= 1.0;
$DamageScale[Carryall, $BlasterDamageType] 		= 0.5;
$DamageScale[Carryall, $ElectricityDamageType] 		= 1.0;
$DamageScale[Carryall, $MineDamageType]        		= 1.0;
$DamageScale[Carryall, $StabDamageType]        		= 0.1;
$DamageScale[Carryall, $StunnerDamageType]     		= 0.02;
$DamageScale[Carryall, $PoisonDamageType]      		= 0.0;
$DamageScale[Carryall, $NukeDamageType]       		= 1.0;
$DamageScale[Carryall, $Poison2DamageType]     		= 0.0;
$DamageScale[Carryall, $WormDamageType]     		= 1.0;
$DamageScale[Carryall, $CutterayDamageType]     	= 1.5;
$DamageScale[Carryall, $SmallLasDamageType]     	= 1.0;
$DamageScale[Carryall, $RifleLasDamageType]     	= 1.0;
$DamageScale[Carryall, $HeavyLasDamageType]     	= 1.0;
$DamageScale[Carryall, $AsphyxiationDamageType]    	= 0.0;
$DamageScale[Carryall, $LargeBulletDamageType] 		= 0.7;
$DamageScale[Carryall, $ThrownWeaponDamageType] 	= 0.1;
$DamageScale[Carryall, $ThrownPoisonWeaponDamageType] 	= 0.0;

$DamageScale[Roller, $ImpactDamageType] 		= 1.0;
$DamageScale[Roller, $BulletDamageType] 		= 0.1;
$DamageScale[Roller, $PlasmaDamageType] 		= 1.0;
$DamageScale[Roller, $EnergyDamageType] 		= 1.0;
$DamageScale[Roller, $ExplosionDamageType] 		= 1.0;
$DamageScale[Roller, $ShrapnelDamageType] 		= 1.0;
$DamageScale[Roller, $DebrisDamageType] 		= 1.0;
$DamageScale[Roller, $MissileDamageType] 		= 1.0;
$DamageScale[Roller, $LaserDamageType] 			= 0.08;
$DamageScale[Roller, $MortarDamageType] 		= 1.0;
$DamageScale[Roller, $BlasterDamageType] 		= 0.5;
$DamageScale[Roller, $ElectricityDamageType] 		= 1.0;
$DamageScale[Roller, $MineDamageType]        		= 1.0;
$DamageScale[Roller, $StabDamageType]        		= 0.02;
$DamageScale[Roller, $StunnerDamageType]     		= 0.02;
$DamageScale[Roller, $PoisonDamageType]      		= 0.0;
$DamageScale[Roller, $NukeDamageType]       		= 1.0;
$DamageScale[Roller, $Poison2DamageType]     		= 0.0;
$DamageScale[Roller, $WormDamageType]     		= 1.0;
$DamageScale[Roller, $CutterayDamageType]   	  	= 1.0;
$DamageScale[Roller, $SmallLasDamageType]   	  	= 0.8;
$DamageScale[Roller, $RifleLasDamageType]   	  	= 0.8;
$DamageScale[Roller, $HeavyLasDamageType]   	  	= 0.8;
$DamageScale[Roller, $AsphyxiationDamageType]    	= 0.0;
$DamageScale[Roller, $LargeBulletDamageType] 		= 0.5;
$DamageScale[Roller, $ThrownWeaponDamageType] 		= 0.02;
$DamageScale[Roller, $ThrownPoisonWeaponDamageType] 	= 0.0;

$DamageScale[Tracker, $ImpactDamageType] 		= 1.0;
$DamageScale[Tracker, $BulletDamageType] 		= 0.01;
$DamageScale[Tracker, $PlasmaDamageType] 		= 1.0;
$DamageScale[Tracker, $EnergyDamageType] 		= 1.0;
$DamageScale[Tracker, $ExplosionDamageType] 		= 1.0;
$DamageScale[Tracker, $ShrapnelDamageType] 		= 1.0;
$DamageScale[Tracker, $DebrisDamageType] 		= 1.0;
$DamageScale[Tracker, $MissileDamageType] 		= 1.0;
$DamageScale[Tracker, $LaserDamageType] 		= 0.08;
$DamageScale[Tracker, $MortarDamageType] 		= 1.0;
$DamageScale[Tracker, $BlasterDamageType] 		= 0.5;
$DamageScale[Tracker, $ElectricityDamageType] 		= 1.0;
$DamageScale[Tracker, $MineDamageType]        		= 1.0;
$DamageScale[Tracker, $StabDamageType]        		= 0.02;
$DamageScale[Tracker, $StunnerDamageType]     		= 0.02;
$DamageScale[Tracker, $PoisonDamageType]      		= 0.0;
$DamageScale[Tracker, $NukeDamageType]       		= 1.0;
$DamageScale[Tracker, $Poison2DamageType]     		= 0.0;
$DamageScale[Tracker, $WormDamageType]     		= 1.0;
$DamageScale[Tracker, $CutterayDamageType]   	  	= 1.0;
$DamageScale[Tracker, $SmallLasDamageType]   	  	= 0.8;
$DamageScale[Tracker, $RifleLasDamageType]   	  	= 0.8;
$DamageScale[Tracker, $HeavyLasDamageType]   	  	= 0.8;
$DamageScale[Tracker, $AsphyxiationDamageType]    	= 0.0;
$DamageScale[Tracker, $LargeBulletDamageType] 		= 0.1;
$DamageScale[Tracker, $ThrownWeaponDamageType] 		= 0.02;
$DamageScale[Tracker, $ThrownPoisonWeaponDamageType] 	= 0.0;

$DamageScale[Crawler, $ImpactDamageType] 		= 1.0;
$DamageScale[Crawler, $BulletDamageType] 		= 0.01;
$DamageScale[Crawler, $PlasmaDamageType] 		= 1.0;
$DamageScale[Crawler, $EnergyDamageType] 		= 1.0;
$DamageScale[Crawler, $ExplosionDamageType] 		= 1.0;
$DamageScale[Crawler, $ShrapnelDamageType] 		= 1.0;
$DamageScale[Crawler, $DebrisDamageType] 		= 1.0;
$DamageScale[Crawler, $MissileDamageType] 		= 1.0;
$DamageScale[Crawler, $LaserDamageType] 		= 0.08;
$DamageScale[Crawler, $MortarDamageType] 		= 1.0;
$DamageScale[Crawler, $BlasterDamageType] 		= 0.5;
$DamageScale[Crawler, $ElectricityDamageType] 		= 1.0;
$DamageScale[Crawler, $MineDamageType]        		= 1.0;
$DamageScale[Crawler, $StabDamageType]        		= 0.02;
$DamageScale[Crawler, $StunnerDamageType]     		= 0.02;
$DamageScale[Crawler, $PoisonDamageType]      		= 0.0;
$DamageScale[Crawler, $NukeDamageType]       		= 1.0;
$DamageScale[Crawler, $Poison2DamageType]     		= 0.0;
$DamageScale[Crawler, $WormDamageType]     		= 1.0;
$DamageScale[Crawler, $CutterayDamageType]   	  	= 1.0;
$DamageScale[Crawler, $SmallLasDamageType]   	  	= 0.8;
$DamageScale[Crawler, $RifleLasDamageType]   	  	= 0.8;
$DamageScale[Crawler, $HeavyLasDamageType]   	  	= 0.8;
$DamageScale[Crawler, $AsphyxiationDamageType]    	= 0.0;
$DamageScale[Crawler, $LargeBulletDamageType] 		= 0.1;
$DamageScale[Crawler, $ThrownWeaponDamageType] 		= 0.02;
$DamageScale[Crawler, $ThrownPoisonWeaponDamageType] 	= 0.0;

//Old
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

//----------------------------------------------------------------------------
//New stuff dealing with extra weapons and switching weapons.

//-Weapons to their slots for each vehicle
$VehicleWeaponNum[LasgunThopter,0] = LasGun;
$VehicleWeaponNum[LasgunThopter,1] = Shield;
$VehicleWeaponNum[VulcanThopter,0] = Vulcan;
$VehicleWeaponNum[VulcanThopter,1] = Shield;
$VehicleWeaponNum[ArtillaryThopter,0] = Bombs;
$VehicleWeaponNum[ArtillaryThopter,1] = Shield;
$VehicleWeaponNum[CarryAll,0] = Shield;
$VehicleWeaponNum[CarryAll,1] = Cargo;
$VehicleWeaponNum[CarryAll,2] = DropInf;
$VehicleWeaponNum[Roller,0] = Vulcan2;
$VehicleWeaponNum[Crawler,0] = DropInf;

//-Max Ammo for each weapon for each Vehicle
$MaxAmmoVehicle[LasgunThopter,LasGun] = 10;
$MaxAmmoVehicle[LasgunThopter,Shield] = 1;
$MaxAmmoVehicle[VulcanThopter,Vulcan] = 10;
$MaxAmmoVehicle[VulcanThopter,Shield] = 1;
$MaxAmmoVehicle[ArtillaryThopter,Bombs] = 10;
$MaxAmmoVehicle[ArtillaryThopter,Shield] = 1;
$MaxAmmoVehicle[CarryAll,Shield] = 1;
$MaxAmmoVehicle[CarryAll,Cargo] = 1;
$MaxAmmoVehicle[CarryAll,DropInf] = 1;
$MaxAmmoVehicle[Crawler,DropInf] = 1;
$MaxAmmoVehicle[Roller,Vulcan2] = 10;

//-Reload delay for each type
$ReloadRate[Vulcan] = 0.050;
$ReloadRate[Vulcan2] = 0.050;
$ReloadRate[LasGun] = 0.001;
$ReloadRate[Bombs] = 5.000;
$ReloadRate[Shield] = 0.500;
$ReloadRate[Cargo] = 0.500;
$ReloadRate[DropInf] = 0.500;

//-Projectile for Modes
$VehWeapProjectile[Vulcan] = "RMachineBullet";
$VehWeapProjectile[Vulcan2] = "RMachineBullet";
$VehWeapProjectile[LasGun] = "HLasGunLaser";
$VehWeapProjectile[bombs] = "Bomb";
$VehWeapProjectile[Shield] = "Special";
$VehWeapProjectile[Cargo] = "Special";
$VehWeapProjectile[DropInf] = "Special";

//-Sounds for Modes
$VehWeapSound[Vulcan] = "shockExplosion";
$VehWeapSound[Vulcan2] = "shockExplosion";
$VehWeapSound[LasGun] = "SoundVehLasGun";
$VehWeapSound[Bombs] = "SoundDryFire";
$VehWeapSound[Shield] = "SoundDryFire";
$VehWeapSound[Cargo] = "SoundDoorOpen";
$VehWeapSound[DropInf] = "SoundDoorOpen";

//-Weapon Descriptions
$WeapMountMSG[Vulcan] = "Vulcan Machine Guns";
$WeapMountMSG[Vulcan2] = "Vulcan Machine Guns";
$WeapMountMSG[LasGun] = "Heavy Lasgun";
$WeapMountMSG[Bombs] = "Artillary Bombs";
$WeapMountMSG[Shield] = "Shield Toggle";
$WeapMountMSG[Cargo] = "Drop/Pickup Cargo";
$WeapMountMSG[DropInf] = "Drop Current Passengers";

//-Modes that use Lock On
//::WingMount	= Mounted on the wings and alternate sides
//::Laser	= Mounted on the Nose, Laser fire
//::NoseFire	= Mounted on the Nose normal fire
//::BombA	= Fire from center of the vehicle and drops down
//::BombB	= Fire from center of the vehicle and uses path
//::LockOnA	= Requires a Lock On
//::LockOnB	= Lock On supported but not required
//::LockOnC	= Lock On supported but not required bomb fall mode
//::Deflect	= Deflects and shields against all attacks for a limited time
//::Shield	= Shields against as long as it is activated, disables firing ability
//::Detonate	= Detonates current vehicle
//::Spike	= Sequential projectiles spawned to form a sphere
//::DropA	= Pickup vehicle/Drop vehicle.
//::DropB	= Drop infantry. Infantry cannot voluntarilly jump from this vehicle.

$NumBombsDropped = 3; // for artillary thopter.

$VehWeapType[Shield] = Shield;
$VehWeapType[Cargo] = DropA;
$VehWeapType[DropInf] = DropB;
$VehWeapType[Vulcan] = wingmount;
$VehWeapType[Vulcan2] = NoseFire;
$VehWeapType[Bombs] = BombB;
$VehWeapType[LasGun] = Laser;

//-How many weapons each Vehicle has
$VehicleWeapons[BasicThopter] = 0;
$VehicleWeapons[LasgunThopter] = 2;
$VehicleWeapons[VulcanThopter] = 2;
$VehicleWeapons[ArtillaryThopter] = 2;
$VehicleWeapons[CarryAll] = 3;
$VehicleWeapons[Roller] = 1;
$VehicleWeapons[Tracker] = 0;
$VehicleWeapons[Crawler] = 1;

function Vehicle::onWeaponSwitch(%this)
{
	%client = GameBase::getControlClient(%this);
	%data = GameBase::getDataName(%this);
	%curWeapNum = $VehicleWeaponMode[%this];
	%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
	%ammo = $VehicleAmmo[%this,%curWeap];
	%delay = $ReloadRate[%curWeap];
	GameBase::playSound(%this,SoundPickUpWeapon,1);
	bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,5);
}

$VehLasGunMultiplier = 1.0;

function Vehicle::onFire(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%this);
	%curWeapNum = $VehicleWeaponMode[%this];
	%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
	%ammo = $VehicleAmmo[%this,%curWeap];
	%delay = $ReloadRate[%curWeap];
	%weaps = $VehicleWeapons[%data];
	if($FireTime[%this] != 1) {
		if(%ammo >= 1) {

			%vel   = Item::getVelocity(%this);
			%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
			%rot2  = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");   	   //- rotation aim back
			%rot3  = Vector::Add(GameBase::getRotation(%this),"0 0 -1.570796327");  	   //- rotation aim left
			%rot4  = Vector::Add(GameBase::getRotation(%this),"0 0 1.570796327");   	   //- rotation aim right
			%rot5  = Vector::Add(GameBase::getRotation(%this),"1.570796327 0 0");   	   //- rotation aim up
			%rot6  = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0 0");  	   //- rotation aim down
			%rot7  = Vector::Add(GameBase::getRotation(%this),"-0.7853981635 0 0");		   //- rotation aim down/forward
			%rot8  = Vector::Add(GameBase::getRotation(%this),"0.7853981635 0 0");  	   //- rotation aim up/forward
			%rot9  = Vector::Add(GameBase::getRotation(%this),"-3.9269908175 0 0");            //- rotation aim down/back
			%rot10 = Vector::Add(GameBase::getRotation(%this),"3.9269908175 0 0");             //- rotation aim up/back
			%rot11 = Vector::Add(GameBase::getRotation(%this),"0 0 -0.7853981635");            //- rotation aim left/forward
			%rot12 = Vector::Add(GameBase::getRotation(%this),"0 0 0.7853981635");             //- rotation aim right/forward
			%rot13 = Vector::Add(GameBase::getRotation(%this),"0 0 -3.9269908175");            //- rotation aim left/back
			%rot14 = Vector::Add(GameBase::getRotation(%this),"0 0 3.9269908175");             //- rotation aim right/back
			%rot15 = Vector::Add(GameBase::getRotation(%this),"1.570796327 0.7853981635 0");   //- rotation aim up/right
			%rot16 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0.7853981635 0");  //- rotation aim down/right
			%rot17 = Vector::Add(GameBase::getRotation(%this),"1.570796327 -0.7853981635 0");  //- rotation aim up/left
			%rot18 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
			%vec1  = Vector::getFromRot(%rot1,1);
			%vec2  = Vector::getFromRot(%rot2,1);
			%vec3  = Vector::getFromRot(%rot3,1);
			%vec4  = Vector::getFromRot(%rot4,1);
			%vec5  = Vector::getFromRot(%rot5,1);
			%vec6  = Vector::getFromRot(%rot6,1);
			%vec7  = Vector::getFromRot(%rot7,1);
			%vec8  = Vector::getFromRot(%rot8,1);
			%vec9  = Vector::getFromRot(%rot9,1);
			%vec10 = Vector::getFromRot(%rot10,1);
			%vec11 = Vector::getFromRot(%rot11,1);
			%vec12 = Vector::getFromRot(%rot12,1);
			%vec13 = Vector::getFromRot(%rot13,1);
			%vec14 = Vector::getFromRot(%rot14,1);
			%vec15 = Vector::getFromRot(%rot15,1);
			%vec16 = Vector::getFromRot(%rot16,1);
			%vec17 = Vector::getFromRot(%rot17,1);
			%vec18 = Vector::getFromRot(%rot18,1);
			%vec19 = Vector::getFromRot(%rot1,9);
			%vec20 = Vector::getFromRot(%rot1,2.0);
			%vec21 = Vector::getFromRot(%rot6,10);
			%pos1  = getBoxCenter(%this);
			%pos2  = Vector::add(%pos1,%vec19);
			//if(%curWeap == ChainGun || %curWeap == ShockMsl)
				%pos2 = Vector::add(%pos2,Vector::getFromRot(%rot5,0.95));
			%pos3  = Vector::add(%pos2,%vec3);
			%pos4  = Vector::add(%pos2,%vec4);
			%pos5  = Vector::add(%pos2,%vec5);
			%pos6  = Vector::add(%pos2,%vec6);
			%pos7  = Vector::add(%pos2,%vec7);
			%pos8  = Vector::add(%pos2,%vec8);
			%pos9  = Vector::add(%pos2,%vec9);
			%pos10 = Vector::add(%pos2,%vec10);
			%pos11 = Vector::add(%pos2,%vec11);
			%pos12 = Vector::add(%pos2,%vec12);
			%pos13 = Vector::add(%pos2,%vec13);
			%pos14 = Vector::add(%pos2,%vec14);
			%pos15 = Vector::add(%pos2,%vec15);
			%pos16 = Vector::add(%pos2,%vec16);
			%pos17 = Vector::add(%pos2,%vec17);
			%pos18 = Vector::add(%pos2,%vec18);
			%pos19 = Vector::add(%pos1,%vec1);
			%pos20 = Vector::add(%pos1,%vec2);
			%pos21 = Vector::add(%pos1,%vec3);
			%pos22 = Vector::add(%pos1,%vec4);
			%pos23 = Vector::add(%pos1,%vec5);
			%pos24 = Vector::add(%pos1,%vec6);
			%pos25 = Vector::add(%pos1,%vec7);
			%pos26 = Vector::add(%pos1,%vec8);
			%pos27 = Vector::add(%pos1,%vec9);
			%pos28 = Vector::add(%pos1,%vec10);
			%pos29 = Vector::add(%pos1,%vec11);
			%pos30 = Vector::add(%pos1,%vec12);
			%pos31 = Vector::add(%pos1,%vec13);
			%pos32 = Vector::add(%pos1,%vec14);
			%pos33 = Vector::add(%pos1,%vec15);
			%pos34 = Vector::add(%pos1,%vec16);
			%pos35 = Vector::add(%pos1,%vec17);
			%pos36 = Vector::add(%pos1,%vec18);
			%pos37 = Vector::add(%pos1,%vec20);
			%pos38 = Vector::add(%pos37,"0 0 -3");
			if($VehWeapProjectile[%curWeap] != "") {
				%type = $VehWeapProjectile[%curWeap];
				if(GameBase::getLOSInfo(%this,2000)) {

					if(getObjectType($los::object) == "Flier") {
						if($VehWeapType[%curWeap] == LockOnA)
							%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
						%target = $los::object;
						%targetPos = $los::position;
					}
					else if($VehWeapType[%curWeap] == LockOnA)
						bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);


				}
				else if($VehWeapType[%curWeap] == LockOnA)
					bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);
				if(%type == "HLasGunLaser")
					%firefromveh = 1;
				if($VehWeapType[%curWeap] == Shield) {
					%proj = "Shields";
					
					//If were a carryall carrying a GC, cant use shields.
					if(false)
					{
				
						$FireTime[%this] = 1;
						schedule("$FireTime["@%this@"] = 0;",%delay,%this);
						return 0;
					}
					
					if($Shieldon[%this] != 1) {
						$Shieldon[%this] = 1;
						%this.shieldStrength = 1;
						DisplayFlierShields(%this);
						Bottomprint(%client,"<jc>Shield Activated", 3);
					}
					else {
						$Shieldon[%this] = 0;
						%this.shieldStrength = 0;	
						Bottomprint(%client,"<jc>Shield Deactivated", 3);
					}
					$FireTime[%this] = 1;
					schedule("$FireTime["@%this@"] = 0;",%delay,%this);
					return 0;
				}
				else if($Shieldon[%this] == 1) {
					Bottomprint(%client,"<jc>Fire Override By Weapons Control. Shield Still Activated.", 3);
					return 0;
				}
				else if($VehWeapType[%curWeap] == DropB) {
					%proj = "DropB";
					
					Vehicle::DropPassengers(%this,%mom);
					$FireTime[%this] = 1;
					schedule("$FireTime["@%this@"] = 0;",%delay,%this);
					return 0;
				}
				else if($VehWeapType[%curWeap] == DropA) {
					%proj = "DropA";
					
					// If we have cargo, drop it.
					if(!$Cargo[%this] || $Cargo[%this] == "" || $Cargo[%this] == -1)
					{
						Vehicle::PickUpCargo(%this,%mom);
					} else {
						Vehicle::DropCargo(%this);
					}

					$FireTime[%this] = 1;
					schedule("$FireTime["@%this@"] = 0;",%delay,%this);
					return 0;
				}
				else if($VehWeapType[%curWeap] == LockOnB) {
					if(%curWeap == KamiDive) {
						%proj = "KamiDive";
						%this.KamiDive = true;
						if($KamiKazeDiveStyle == 0||$KamiKazeDiveStyle == "")
							Vehicle::dismount(%this,%mom);
						if(%target)
							schedule("Kamikaze::Dive(\""@%this@"\",\""@%target@"\",\""@True@"\");",0.1,%this);
						else
							schedule("Kamikaze::Dive(\""@%this@"\",\""@$los::position@"\",\""@False@"\");",0.1,%this);
					}
					else
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
				}
				else if($VehWeapType[%curWeap] == LockOnC) {
					%trans = %rot1@" "@%vec6@" "@%rot1@" "@%pos6;
				}
				else if($VehWeapType[%curWeap] == Deflect) {
					%proj = "Deflecting";
					%this.shieldStrength = 1.0;
					GameBase::setRechargeRate(%this,20);
					HAPC::Deflectors(%this);
					schedule(%this@".superShield = 0;",%delay,%this);
					schedule("GameBase::setRechargeRate("@%this@","@8@");",%delay,%this);
				}
				else if($VehWeapType[%curWeap] == Detonate) {
					%trans = %rot1@" "@%vec5@" "@%rot1@" "@%pos1;
					StaticShape::onDamage(%this,$KamiDiveDamageType,Kamikaze.maxDamage+0.1,%pos1,%vec1,%mom,%this);
				}
				else if($VehWeapType[%curWeap] == BombA) {
					%trans = %rot1@" "@%vec21@" "@%rot1@" "@%pos38;
				}
				else if($VehWeapType[%curWeap] == BombB) {
					%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos1;
				}
				else if($VehWeapType[%curWeap] == NoseFire) {
					%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
				}
				else if($VehWeapType[%curWeap] == Laser) {
					%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
					%value = %type.damageConversion;
					%value *= $VehLasGunMultiplier;
					%pos = GameBase::getPosition($los::object);
					%vecI = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
					%mom = "0 0 0";
					GameBase::applyDamage($los::object,$HeavyLasDamageType,%value,%pos,%vecI,%mom,%client);
				}
				else if($VehWeapType[%curWeap] == WingMount) {
					if($FireSide[%this] == 0 || $FireSide[%this] == "") {
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos3,Vector::getFromRot(%rot1,2000)),%pos3),100);
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos3;
						if($WingMountMethodFix)
							%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos3;
						$FireSide[%this] = 1;
					}
					else if($FireSide[%this] == 1) {
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos4,Vector::getFromRot(%rot1,2000)),%pos4),100);
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos4;
						if($WingMountMethodFix)
							%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos4;
						$FireSide[%this] = 0;
					}
					else { //- dont know how it got here, but just spawn center
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos2,Vector::getFromRot(%rot1,2000)),%pos2),100);
						%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos2;
						$FireSide[%this] = 0;
					}
				}
				else if($VehWeapType[%curWeap] == Spike) {
					if($FireSide[%this] == 1 || $FireSide[%this] == "") {
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos19;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 2) {
						%trans = %rot1@" "@%vec2@" "@%rot1@" "@%pos20;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 3) {
						%trans = %rot1@" "@%vec3@" "@%rot1@" "@%pos21;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 4) {
						%trans = %rot1@" "@%vec4@" "@%rot1@" "@%pos22;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 5) {
						%trans = %rot1@" "@%vec5@" "@%rot1@" "@%pos23;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 6) {
						%trans = %rot1@" "@%vec6@" "@%rot1@" "@%pos24;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 7) {
						%trans = %rot1@" "@%vec7@" "@%rot1@" "@%pos25;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 8) {
						%trans = %rot1@" "@%vec8@" "@%rot1@" "@%pos26;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 9) {
						%trans = %rot1@" "@%vec9@" "@%rot1@" "@%pos27;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 10) {
						%trans = %rot1@" "@%vec10@" "@%rot1@" "@%pos28;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 11) {
						%trans = %rot1@" "@%vec11@" "@%rot1@" "@%pos29;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 12) {
						%trans = %rot1@" "@%vec12@" "@%rot1@" "@%pos30;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 13) {
						%trans = %rot1@" "@%vec13@" "@%rot1@" "@%pos31;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 14) {
						%trans = %rot1@" "@%vec14@" "@%rot1@" "@%pos32;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 15) {
						%trans = %rot1@" "@%vec15@" "@%rot1@" "@%pos33;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 16) {
						%trans = %rot1@" "@%vec16@" "@%rot1@" "@%pos34;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 17) {
						%trans = %rot1@" "@%vec17@" "@%rot1@" "@%pos35;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 18) {
						%trans = %rot1@" "@%vec18@" "@%rot1@" "@%pos36;
						$FireSide[%this] = 1;
					}
					else { //- dont know how it got here, but just reset
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos19;
						$FireSide[%this] = 1;
					}
				}
			}
			// Make 3 bombs drop
			if(%trans || %trans != "") {
				if(%target && ($VehWeapType[%curWeap] == LockonA||$VehWeapType[%curWeap] == LockonB||$VehWeapType[%curWeap] == LockonC) &&(getObjectType(%target) == "Player" || getObjectType(%target) == "Flier"))
					WarnLock(%target,4);
				if(%type == Bomb) {
					Vehicle::dropBombs(%this, %client, %player, %type, %firefromveh,0);
							
				} else if(%curWeap == Vulcan || %curWeap == Vulcan2)
				{
	
					//%cl = %client;
					//%vel = Item::getVelocity(%player);
					//%trans = GameBase::getMuzzleTransform(%player);
	
					//%x = (getRandom() - getRandom()+0.0001)/(40);
					//%y = (getRandom() - getRandom()+0.0001)/(40);
					//%z = (getRandom() - getRandom()+0.0001)/(40);

					//%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ getWord(%trans,3)+%x @ " " @ 
					//	getWord(%trans,4)+%y @ " " @ getWord(%trans,5)+%z @ " " @ getWord(%trans,6) @ " " @ getWord(%trans,7) @ " " @ 
					//	getWord(%trans,8) @ " " @ getWord(%trans,9) @ " " @ getWord(%trans,10) @ " " @ getWord(%trans,11);

					if(%firefromveh == 1)
						%proj = projectile::spawnProjectile(%type,%trans,%this,%vel,%target);
					else
						%proj = projectile::spawnProjectile(%type,%trans,%player,%vel,%target);
					$Shooter[%proj] = %client;
					$Target[%proj]  = %target;
	
				} else {
					if(%firefromveh == 1)
						%proj = projectile::spawnProjectile(%type,%trans,%this,%vel,%target);
					else
						%proj = projectile::spawnProjectile(%type,%trans,%player,%vel,%target);
					$Shooter[%proj] = %client;
					$Target[%proj]  = %target;
				}
			}
			// Sound 3 bombs drop
			if(%proj || %proj != "") {
				if(%type != Bomb) {
				//$VehicleAmmo[%this,%curWeap]--;
				%ammo = $VehicleAmmo[%this,%curWeap];
				%time = %delay+1;
				if(%ammo <= 0)
					%time = 1;
				//bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%time);
				GameBase::playSound(%this,$VehWeapSound[%curWeap],3);
				%sound2 = $VehWeapSound[%curWeap,2];
				if(%sound2 || %sound2 != "")
					schedule("GameBase::playSound("@%this@","@%sound2@",2);",0.01,%this);
				}
			}
			$FireTime[%this] = 1;
			schedule("$FireTime["@%this@"] = 0;",%delay,%this);
		}
		else {
			GameBase::playSound(%this,SoundDryFire,3);
			$FireTime[%this] = 1;
			schedule("$FireTime["@%this@"] = 0;",0.2,%this);
		}
	}
}



function Vehicle::dropBombs(%this, %client, %player, %type, %firefromveh, %count)
{
	if(%count < $NumBombsDropped)
	{
		%vel   = Item::getVelocity(%this);
		%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
		%vec1  = Vector::getFromRot(%rot1,1);
		%pos1  = vector::Add(gamebase::getposition(%this), "0 0 -1");
		%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos1;	


		if(%firefromveh == 1)
			%proj = projectile::spawnProjectile(%type,%trans,%this,%vel);
		else
			%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);		

		$Shooter[%proj] = %client;
		$Target[%proj]  = %target;


		%data = GameBase::getDataName(%this);
		%curWeapNum = $VehicleWeaponMode[%this];
		%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
		GameBase::playSound(%this,$VehWeapSound[%curWeap],3);
		//%sound2 = $VehWeapSound[%curWeap,2];
		//if(%sound2 || %sound2 != "")
		//	schedule("GameBase::playSound("@%this@","@%sound2@",2);",0.01,%this);

		%time = 0.3;
		%count++;
		schedule("Vehicle::dropBombs(\""@%this@"\",\""@%client@"\",\""@%player@"\",\""@%type@"\",\""@%firefromveh@"\",\""@%count@"\");",%time);
	}
}


// $Cargo[%carryall] = %groundcar;
// $Transport[%groundcar] = %carryall;


function Vehicle::PickUpCargo(%this)
{
// check speed. if were goin to fast, we cant pick anything up
	if(item::getvelocity(%this) > 5)
	{
		Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"You must be in a hover to initiate pick up.~wError_Message.wav");	
		return;		
	}
	for(%i=0;%i<4;%i++)  {
		if(%this.Seat[%i] != "") {
//echo(%this.seat[%i] @ " " @ %i);
			Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"You cannot be carrying passengers while initiating a pick up.~wError_Message.wav");	
			return;	
		}
	}
	
	%target = "";
// Make box.
	%set = newObject("set",SimSet); // make new box for testing.
	if(%num = containerBoxFillSet(%set,$VehicleObjectType,vector::add(gamebase::getposition(%this),"0 0 -5"),15,15,10,0))
	{
// Check for ground vehicles in the box
//echo("Num: " @%num);
		for(%i=0;%num>%i;%i++){
			if(GameBase::getDataName(Group::getObject(%set,%i)) == Roller || GameBase::getDataName(Group::getObject(%set,%i)) == Tracker|| GameBase::getDataName(Group::getObject(%set,%i)) == Crawler){ 
// Take the first ground vehicle found.
				%target = Group::getObject(%set,%i);
				break;
			} 
		}
	}
	if(%target == "")
	{
		Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"No pickup target found.~wError_Message.wav");	
		return;	
	}

// Mark the carryall as carrying the gc
	$Cargo[%this] = %target;
// mark the gc as being carried.
	$Transport[%target] = %this;
// Make some sounds and announcment messages.	
	Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"Pickup target found. Arresting target.");
	GameBase::playSound(%this,SoundPickUpVehicle,3);
	GameBase::playSound(%this,SoundPickUpVehicle,3);
			
// Start update loop
	Vehicle::CarryCargo(%target);
// delete box
	deleteobject(%set);
// MAKE SURE TO MODIFY THE WORM EATING THE VEHICLE
// MAKE SURE TO MODIFY DESTROY FOR THE VEHICLES

}

$Vehicle::TransDist = -3.5;

//Loop
// Consider making this part of it's standard loop. After all, its either doing this, or rolling.
function Vehicle::CarryCargo(%this)
{
//echo("**"@gamebase::getposition(%this));
// make sure were still being carried.
	if($Transport[%this] == "")
		return;
	%carryall = $Transport[%this];
// get position/rotation of carryall
	%pos = gamebase::Getposition(%carryall);
	%rot = Gamebase::GetRotation(%carryall);
// set position of gc to right below it.
	%pos = vector::Add(%pos,"0 0 "@$Vehicle::TransDist);
	gamebase::setposition(%this, %pos);
	gamebase::Setrotation(%this, %rot);
// call this function.
	schedule("Vehicle::CarryCargo("@%this@");",$Timeskip,%this);
}

function Vehicle::DropCargo(%this, %mom)
{
	%Cargo = $Cargo[%this];
// Make dropping noises and drop message.
	GameBase::playSound(%this,SoundReleaseVehicle,3);
	schedule("GameBase::playSound("@%this@",SoundDropVehicle,3);",1.0,%this);
// Let normal groundcar code work.
// mark the gc as not being carried
	schedule("SetTransFree("@%cargo@");",1.0,%this);
// mark the carryall as not carrying anything
	schedule("SetCargoFree("@%this@");",1.0,%this);
	Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"Target releasing...");

}

function SetTransFree(%cargo)
{
	$Transport[%cargo] = "";
}

function SetcargoFree(%trans)
{
	$Cargo[%trans] = "";

}

function Vehicle::onAdd(%this)
{
	%this.dead = false;
	Worm::AddToTargetQueue(%this);
	%data = GameBase::getDataName(%this);
	%this.shieldStrength = 0.0;
	$ShieldOn[%this] = 0;
	GameBase::setRechargeRate(%this, 10);
	GameBase::setMapName(%this,%data.description);
	$FireTime[%this] = 0;
	$VehicleWeaponMode[%this] = 0;
	if( %data == Carryall)
		$Cargo[%this] = "";
	else if( %data == Roller || %data == Tracker || %data == Crawler)
		$Transport[%this] = "";
	for(%i = 0;%i < $VehicleWeapons[%data]; %i++)
		$VehicleAmmo[%this,$VehicleWeaponNum[%data,%i]] = $MaxAmmoVehicle[%data,$VehicleWeaponNum[%data,%i]];
}

function Vehicle::onCollision(%this, %object)
{
//echo(%this @ " " @ %object);
//======================================Variables==========================================

	%client = Player::getClient(%object);
	%objType = getObjectType(%object);
	%armor = Player::getArmor(%object);
	%vname = GameBase::getDataName(%this);

//======================================BooleanChecks======================================
	
	%isPlayer = %objType == "Player";
	%isPilot = %armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "sarmor2" || %armor == "sfemale2" || %armor == "farmor0" || %armor == "ffemale0" || %armor == "ffarmor" || %armor == "fffemale" || %armor == "bbarmor" || %armor == "bbfemale" || %armor == "bbarmor2" || %armor == "bbfemale2";
	%isOnePersonCraft = %vname == Roller || %vname == BasicThopter || %vname == VulcanThopter || %vname == LasgunThopter || %vname == ArtillaryThopter || %vname == Scout;
	%isThopter = %vname == BasicThopter || %vname == VulcanThopter || %vname == LasgunThopter || %vname == ArtillaryThopter || %vname == Carryall || %vname == Scout || %vname == LAPC || %vname == HAPC;
	%isGroundCar = %vName == Roller || %vName == Tracker || %vname == Crawler;
	%hasPilotWeapon = %vName == Roller || %vName == VulcanThopter || %vName == LasgunThopter || %vName == ArtillaryThopter || %vName == Carryall || %vName == Crawler;
	
//======================================HunterseekerCheck==================================

	
	if( %Vname == HunterSeeker || %VName == HunterSeeker2 )
		return; 

//======================================DamageCheck========================================

	if(GameBase::getDamageLevel(%this) > (GameBase::getDataName(%this)).maxDamage || %this.dead)
		return;
	
//======================================PlayerCheck========================================

	// if we're not a player or we already are in a vehicle.
//echo(%object.vehicle);
	if(!%isPlayer || !%object.vehicle == "") 
		return;
	
//======================================RemountDelayCheck==================================

	if(getSimTime() <= %object.newMountTime && %object.lastMount == %this)
		return;

//======================================FadingCheck========================================

	if(%this.fading != "")
		return;

//======================================AICheck============================================
		
	if(Player::isAiControlled(%object))
        	return;
               

//======================================OnePersonCraft=====================================

	if(%isOnePersonCraft)
	{
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Is Pilot?
		if(!%isPilot)
		{
			Client::sendMessage(%client,0,"You must be a light armor class to control the vehicles.~wError_Message.wav");
			return;
		}
				
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Is Piloted?
		if(GameBase::getControlClient(%this) != -1)
		{
			Client::sendMessage(%client,0,"This Vehicle is already occupied.~wError_Message.wav");
			return;
		}	

		if(!Vehicle::canMount(%this, %object))
		{
			Client::sendMessage(%client,0,"This Vehicle is already occupied.~wError_Message.wav");
			return;
		}


		//*************************************************************** Yay! Give our client the boat!

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Remember the client's weapon
		%weapon = Player::getMountedItem(%object,$WeaponSlot);
		if(%weapon != -1) {
			%object.lastWeapon = %weapon;
			Player::unMountItem(%object,$WeaponSlot);
		}

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Set our client in control
		Player::setMountObject(%object, %this, 1);
		Client::setControlObject(%client, %this);
		%object.driver = 1;
        	%object.vehicle = %this;
		%this.clLastMount = %client;
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Tell the client that they're flying a vehicle, and to activate jets.
		ActivateJets(%client);
	
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Play fun mounting sound!
		playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ EMC?
		//if(%this.EMC == true)
		//	Player::setSensorSupression(%client,20);
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Donno what or why but... what will it hurt...
		$SFdrivingAPC[%client] = 1;


		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were a jet, give it landing gear
		//if (%isThopter) 
		//{
		//	%tRot = GameBase::getRotation(%this);
		//	landingGear(%this, %client, getWord(%tRot, 2), getWord(%tRot, 1));
		//}

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were a tank, and we got our REAL tank code on, stick it to the ground (If were a jet, we cant be a tank so why bother checking?)
		if(%isGroundCar)
		{
			vehicleHover(%this, %client);
		}
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If our vehicle has a pilot weapon, hand it over.
		if(%hasPilotWeapon)
		{
			//%weapName = $VehicleWeapon[%vName, $VehicleCurWeapon[%this]];
			//%newEner = $VehicleWeaponAmmo[%this, %weapName] / $VehicleWeaponAmmoMax[%vName, %weapName] * 100;
			//GameBase::setEnergy(%this, %newEner);
			%curWeapNum = $VehicleWeaponMode[%this];
			%curWeap = $VehicleWeaponNum[%vName,%curWeapNum];
			%ammo = $VehicleAmmo[%this,%curWeap];
			%delay = $ReloadRate[%curWeap];
			bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%delay+1);
			if(%delay >= 15)
				bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,2);

		}
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If we got here, just break out for safty reasons.
		return;
	}

//======================================NotAOnePersonCraft=================================

	else if(!%isOnePersonCraft)
	{
	
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Is Pilot?
		if(%isPilot && GameBase::getControlClient(%this) == -1 && Vehicle::canMount(%this, %object))
		{
			//*************************************************************** Yay! Give our client the boat!

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Remember the client's weapon
			%weapon = Player::getMountedItem(%object,$WeaponSlot);
			if(%weapon != -1) {
				%object.lastWeapon = %weapon;
				Player::unMountItem(%object,$WeaponSlot);
			}		

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Set our client in control
			Player::setMountObject(%object, %this, 1);
			Client::setControlObject(%client, %this);
			%object.driver = 1;
       		 	%object.vehicle = %this;
			%this.clLastMount = %client;
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Tell the client that they're flying a vehicle, and to activate jets.
			ActivateJets(%client);
		
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Play fun mounting sound!
			playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ EMC?
			//if(%this.EMC == true)
			//	Player::setSensorSupression(%client,20);
		
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Donno what or why but... what will it hurt...
			$SFdrivingAPC[%client] = 1;


			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were a jet, give it landing gear
			//if (%isThopter) 
			//{
			//	%tRot = GameBase::getRotation(%this);
			//	landingGear(%this, %client, getWord(%tRot, 2), getWord(%tRot, 1));
			//}

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were a tank, and we got our REAL tank code on, stick it to the ground (If were a jet, we cant be a tank so why bother checking?)
			if(%isGroundCar)
			{
				vehicleHover(%this, %client);
			}
		
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If our vehicle has a pilot weapon, hand it over.
			if(%hasPilotWeapon)
			{
				//%weapName = $VehicleWeapon[%vName, $VehicleCurWeapon[%this]];
				//%newEner = $VehicleWeaponAmmo[%this, %weapName] / $VehicleWeaponAmmoMax[%vName, %weapName] * 100;
				//GameBase::setEnergy(%this, %newEner);
				%curWeapNum = $VehicleWeaponMode[%this];
				%curWeap = $VehicleWeaponNum[%vName,%curWeapNum];
				%ammo = $VehicleAmmo[%this,%curWeap];
				%delay = $ReloadRate[%curWeap];
				bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%delay+1);
				if(%delay >= 15)
					bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,2);

			}
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If we got here, just break out for safty reasons.
			return;
		}

		//*********************************************************************** If were here, we can't pilot it. Check to see if we can ride.
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If theres no driver, dont go in!
		if(GameBase::getControlClient(%this) == -1)
		{
			Client::sendMessage(Player::getClient(%object),0,"Vehicle must be piloted to enter!~wError_Message.wav");
			return;		
		
		}
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If the driver is an enemy, you dont go in!	
		if(GameBase::getTeam(GameBase::getControlClient(%this)) != gamebase::GetTeam(%object))
		{
			Client::sendMessage(Player::getClient(%object),0,"You can't enter a vehicle piloted by an enemy! They won't let you in!~wError_Message.wav");
			return;		
		
		}
		

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Get a position to ride in.		
		%mountSlot = Vehicle::findEmptySeat(%this,%client);

		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If we have a position, put em in their position
		if(%mountSlot)
		{
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Take away their weapon while riding
			%weapon = Player::getMountedItem(%object,$WeaponSlot);

			if(%weapon != -1) {
				%object.lastWeapon = %weapon;
				Player::unMountItem(%object,$WeaponSlot);
			}		

			
			//*************************************************************** Assign proper weapons to the rider.

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were in a Crawler,
			if(%vname == Crawler)
			{
				// Havent decided if im gonna give them anything...
				//Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
				//Player::setItemCount(%client,Minigun,1);
				//Player::useItem(%client,Minigun);
			}
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If were in an Tracker,
			else if(%vname == Tracker)
			{
				if (%mountSlot == 2) {
					//Gonna have it use infinate ammo.
					//Player::setItemCount(%client,AbramsAmmo,$VehicleAmmo[%this, AbramsGun]);
					Player::setItemCount(%client,MountedArtillaryGun,1);
					Player::mountItem(%client,MountedArtillaryGun,$WeaponSlot);
//					Player::useItem(%client,MountedArtillaryGun);
				} else if(%mountSlot == 3){
					// Gonna have it use infinate ammo.
					//Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
					Player::setItemCount(%client,MountedMachineGun,1);
					Player::mountItem(%client,MountedMachineGun,$WeaponSlot);
//					Player::useItem(%client,MountedMachineGun);
				} 
			}
			
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ So the client knows where they are sitting...
			%object.vehicleSlot = %mountSlot;
	
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ So the client knows where they are sitting...
			%client.inVehicle = true;
			

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ So the client knows WHICH vehicle they are in...
			%object.vehicle = %this;

			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Put our client in the boat.
			Player::setMountObject(%object, %this, %mountSlot);
		
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Play fun sound!
			playSound (%vname.mountSound, GameBase::getPosition(%this));
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Remember which slot has who.
			$PassengerSlot[%this, %mountSlot] = %client;
			
			//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ To be on the safe side.	
			return;
		}
		
		//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ If we didn't find a mount slot, and arn't in pilot, and there is no pilot, then assume they want to ride, and there are no more slots.	
		else if(!%isPilot && GameBase::getControlClient(%this) == -1)
			Client::sendMessage(Player::getClient(%object),0,"The vehicle is full.~wError_Message.wav");
	}

}


function Vehicle::onCollisionOld (%this, %object)
{
	if(%this.shieldStrength > 0)
	{
		Client::sendMessage(Player::getClient(%object),0,"Can not mount while vehicle shields are up.~wError_Message.wav");	
		return;
	}


	%data = GameBase::getDataName(%this);
	%client = Player::getClient(%object);
	if( Gamebase::getDataName(%this) == HunterSeeker || Gamebase::getDataName(%this) == HunterSeeker2 )
		return; 


	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {

		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{

            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "ffemale" || %armor == "farmor" || %armor == "fffemale" || %armor == "ffarmor" || %armor == "bbfemale" || %armor == "bbarmor") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						
						//****NEW
						%vName = GameBase::getDataName(%this);
						$SFdrivingAPC[%client] = 1;	
						%object.driver= 1;
						%object.vehicle = %this;
						if(%vName == Roller || %vName == Tracker || %vname == Crawler)
						{
							%tRot = GameBase::getRotation(%this);
							//vehicleHover(%this, %client, getWord(%tRot, 2), getWord(%tRot, 1));
							%this.lastRos = GameBase::getRotation(%this);
							%this.lastPos = GameBase::getPosition(%this);

							vehicleHover(%this, %client);//, getWord(%tRot, 2), getWord(%tRot, 1));
						}
						if(%vName == BasicThopter || %vName == VulcanThopter || %vName == LasgunThopter || %vName == Carryall || %vName == Roller)
						{
							//%weapName = $VehicleWeapon[%vName, $VehicleCurWeapon[%this]];
							//Unlimited ammo, so we don need this.
							//%newEner = $VehicleWeaponAmmo[%this, %weapName] / $VehicleWeaponAmmoMax[%vName, %weapName] * 100;
							//GameBase::setEnergy(%this, %newEner);
							%curWeapNum = $VehicleWeaponMode[%this];
							%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
							%ammo = $VehicleAmmo[%this,%curWeap];
							%delay = $ReloadRate[%curWeap];
							bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%delay+1);
							if(%delay >= 15)
								bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,2);
						}
						//*******

						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != BasicThopter && GameBase::getDataName(%this) != VulcanThopter && GameBase::getDataName(%this) != LasgunThopter && GameBase::getDataName(%this) != Roller) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
								
								//****NEW
								//For adding extra weapons on the passenger slots
								$PassengerSlot[%this, %mountSlot] = %client;
echo("Mount weapon!");
								if(Gamebase::getDataName(%this) == Tracker) {
									if (%mountSlot == 2) {
										//Unlimited Ammo
										//Player::setItemCount(%client,AbramsAmmo,$VehicleAmmo[%this, AbramsGun]);
										Player::setItemCount(%client,AbramsGun,1);
										Player::useItem(%client,AbramsGun);
									} else {
										//Unlimited Ammo
										//Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
										//Player::setItemCount(%client,Minigun,1);
										//Player::useItem(%client,Minigun);
									}
								} else if(Gamebase::getDataName(%this) == Crawler) {
									if (%mountSlot == 4) {
										//Unlimited Ammo
										//Player::setItemCount(%client,MinigunAmmo,$VehicleAmmo[%this, Minigun]);
										//Player::setItemCount(%client,Minigun,1);
										//Player::useItem(%client,Minigun);
									}
								}
								//*******
	
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be a soldier, fremen, fedykin or burseg to pilot the vehicles.~wError_Message.wav");
			}
	}

}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == Crawler || GameBase::getDataName(%this) == Carryall)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  {
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
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
	else {
		return "False";
	}
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
	if(%this.shieldStrength > 0)
	{
		Client::sendMessage(Player::getClient(%passenger),0,"Can not dismount while shields are up.~wError_Message.wav");	
		return;
	}
	
	if(GameBase::getDataName(%this) == Crawler || GameBase::getDataName(%this) == Carryall)
	{
		Client::sendMessage(Player::getClient(%passenger),0,"The driver must let you out. You cannot exit.~wError_Message.wav");	
		return;
	}
						
	
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "farmor" || %armor == "ffemale" || %armor == "ffarmor" || %armor == "fffemale") {
		%height = 2;
		%velocity = 35;
		%zVec = 35;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "tarmor" || %armor == "tfemale" || %armor == "ssarmor" || %armor == "ssfemale" || %armor == "barmor" || %armor == "bfemale" || %armor == "ssarmor2" || %armor == "ssfemale2" || %armor == "barmor2" || %armor == "bfemale2") {
		%height = 2;
		%velocity = 50;
		%zVec = 50;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		
		//****NEW
		// Not really used right now with unlimited ammo.
		if(GameBase::getDataName(%this) == Tracker) {
			if(%passenger.vehicleSlot == 2) {
				//$VehicleAmmo[%this, AbramsGun] = Player::getItemCount(%client, AbramsAmmo);
			} else if(%passenger.vehicleSlot == 3) {
				//$VehicleAmmo[%this, Minigun] = Player::getItemCount(%client, MinigunAmmo);
			}
		} else if(GameBase::getDataName(%this) == Crawler) {
			if(%passenger.vehicleSlot == 4) {
				//$VehicleAmmo[%this, Minigun] = Player::getItemCount(%client, MinigunAmmo);
			}
		}
		//DeactivateJets(%client);
		$PassengerSlot[%this, %passenger.vehicleSlot] = 0;
		//*******

		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		schedule("Player::applyimpulse("@%passenger@",\"0 0 30\");",0.9);
	}
	else
		Client::sendMessage(Player::getClient(%passenger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");

	//****NEW
	Player::setItemCount(%passenger,MountedMachineGun,0);
	//Player::setItemCount(%passenger,MinigunAmmo,0);
	Player::setItemCount(%passenger,MountedArtillaryGun,0);
	//Player::setItemCount(%passenger,AbramsAmmo,0);
	//*******

}

function Vehicle::dropPassengers(%this,%mom)
{

	if(GameBase::getDataName(%this) == Crawler || GameBase::getDataName(%this) == Carryall)
		%numSlots = 4;
	else
		%numSlots = 2;


	for(%x = 0; %x < %numslots;%x++)
	{
	
		%passenger = Client::getControlObject(%this.Seat[%x]);
		if(%passenger != ""){
			%armor = Player::getArmor(%passenger);
			if(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "farmor" || %armor == "ffemale" || %armor == "ffarmor" || %armor == "fffemale") {
				%height = 2;
				%velocity = 35;
				%zVec = 35;
			}
			else if(%armor == "marmor" || %armor == "mfemale" || %armor == "tarmor" || %armor == "tfemale" || %armor == "ssarmor" || %armor == "ssfemale" || %armor == "barmor" || %armor == "bfemale" || %armor == "ssarmor2" || %armor == "ssfemale2" || %armor == "barmor2" || %armor == "bfemale2") {
				%height = 2;
				%velocity = 50;
				%zVec = 50;
			}
			else if(%armor == "harmor") {
				%height = 2;
				%velocity = 140;
				%zVec = 110;
			}
		
			%pos = GameBase::getPosition(%passenger);
			%posX = getWord(%pos,0);
			%posY	= getWord(%pos,1);
			%posZ	= getWord(%pos,2);

			if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
				%client = Player::getClient(%passenger);
		
				//****NEW
				// Not really used right now with unlimited ammo.
				if(GameBase::getDataName(%this) == Crawler) {
					if(%passenger.vehicleSlot == 4) {
						//$VehicleAmmo[%this, Minigun] = Player::getItemCount(%client, MinigunAmmo);
					}
				}
				$PassengerSlot[%this, %passenger.vehicleSlot] = 0;
				//*******

				%this.Seat[%passenger.vehicleSlot-2] = "";
				%this.Seat[%x] = "";
				%passenger.vehicleSlot = "";
				%passenger.vehicle= "";
				Player::setMountObject(%passenger, -1, 0);
				%rotZ = getWord(GameBase::getRotation(%passenger),2);
				GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
				GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
				%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
				Player::applyImpulse(%passenger,%jumpDir);
				schedule("Player::applyimpulse("@%passenger@",\"0 0 30\");",0.9);
			}
			else
				Client::sendMessage(Player::getClient(%passenger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		
			//****NEW
			Player::setItemCount(%passenger,MountedMachineGun,0);
			//Player::setItemCount(%passenger,MinigunAmmo,0);
			Player::setItemCount(%passenger,MountedArtillaryGun,0);
			//Player::setItemCount(%passenger,AbramsAmmo,0);
			//*******	

		}
	}

}

function Vehicle::jump(%this,%mom)
{

	if(%this.shieldStrength > 0)
	{
		Client::sendMessage(Player::getClient(GameBase::getControlClient(%this)),0,"Can not dismount while shields are up.~wError_Message.wav");	
		return;
	}

   if(GameBase::getDataName(%this) == HunterSeeker) {
	%mom = "0 0 50";
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%vec = Vector::getFromRot(%rot,10);

	StaticShape::onDamage(%this,$PoisonDamageType,HunterSeeker2.maxDamage+0.1,%pos,%vec,%mom,%this);
   } else
   	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %mom = getword(%mom,0)/3 @ " " @ getword(%mom,1)/3 @ " 0";// @ getword(%mom,2)/-3;
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);

      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				DeactivateJets(%cl);
				$SFdrivingAPC[%cl] = 0;
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 		Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
				schedule("Player::applyimpulse("@%pl@",\"0 0 30\");",0.5);
        	 		Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      				}
				%pl.driver = "";
				%pl.vehicle = "";
				
				//****NEW
				Player::setItemCount(%pl,MountedMachineGun,0);
				//Player::setItemCount(%pl,MinigunAmmo,0);
				Player::setItemCount(%pl,MountedArtillaryGun,0);
				//Player::setItemCount(%pl,AbramsAmmo,0);
				//*******

			} else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}

   }

}

function Vehicle::onDestroyed (%this,%mom)
{
	%this.dead = true;
	DeactivateJets(Gamebase::getControlClient(%this));
	if(gamebase::getdataname(%this) == HunterSeeker)
	{
		%client = GameBase::getControlClient(%this);
		%player = Client::getOwnedObject(%client);

		if(%player != -1) {
		   Player::setMountObject(%player, -1, 0);
	   	   	Client::setControlObject(%client, %player);
			$SFdrivingAPC[%client] = 0;
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
			}
			%player.driver = "";
			%player.vehicle= "";

			%player.HSStation.comstation.controller = "";
			%player.HSStation = "";
		}

		//echo(%client);
		$CanUseHS[%client] = 0;
		schedule("$CanUseHS[\""@%client@"\"] = 1;",1.0);
		//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		//	0.1, 225, 100);
	



	} else 
	{
	//	if($testcheats || $servercheats)
		$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   
		%cl = GameBase::getControlClient(%this);
		%pl = Client::getOwnedObject(%cl);
		if(%pl != -1) {
			Player::setMountObject(%pl, -1, 0);
   			Client::setControlObject(%cl, %pl);
			$SFdrivingAPC[%cl] = 0;
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
			
				//****NEW
				Player::setItemCount(%pl,MountedMachineGun,0);
				//Player::setItemCount(%pl,MinigunAmmo,0);
				Player::setItemCount(%pl,MountedArtillaryGun,0);
				//Player::setItemCount(%pl,AbramsAmmo,0);
				//*******

			}
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
			0.1, 225, 100);
		Worm::RemoveFromTargetQueue(%this);
		if( gamebase::getdataname(%this) == Carryall)
		{
			$Transport[$Cargo[%this]] = "";
		} else if( gamebase::getdataname(%this) == Roller || gamebase::getdataname(%this) == Tracker || gamebase::getdataname(%this) == Crawler)
		{
			$Cargo[$Transport[%this]] = "";
		}
	}
}

function Vehicle::kickout(%this,%mom)
{

while (gamebase::getdataname(%this) != HunterSeeker && (Client::getOwnedObject(GameBase::getControlClient(%this)) != -1
	||(%this.Seat[0] != "" || %this.Seat[1] != "" || %this.Seat[2] != "" || %this.Seat[3] != "" ))){
//echo("ejecting");
//	item::setvelocity(%this,"0 0 0");
	if(gamebase::getdataname(%this) != HunterSeeker)
	{
   
		%cl = GameBase::getControlClient(%this);
		DeactivateJets(%cl);
		%pl = Client::getOwnedObject(%cl);
		if(%pl != -1) {
			Player::setMountObject(%pl, -1, 0);
   			Client::setControlObject(%cl, %pl);
			$SFdrivingAPC[%cl] = 0;
			if(%pl.lastWeapon != "") {
				Player::useItem(%pl,%pl.lastWeapon);		 	
				%pl.lastWeapon = "";
			}
			%pl.driver = "";
	   		%pl.vehicle= "";
			//(getword(gamebase::getvelocity(%pl),0)*-1)@ " " @(getword(gamebase::getvelocity(%pl),1)*-1)@ " " @(getword(gamebase::getvelocity(%pl),2)*-1)
//			gamebase::setvelocity(%pl, "0 0 0");
//			player::applyimpulse(%pl,(getword(gamebase::getvelocity(%pl),0)*-1)@ " " @(getword(gamebase::getvelocity(%pl),1)*-1)@ " " @(getword(gamebase::getvelocity(%pl),2)*-1 + 410));
//			Player::applyImpulse(%pl,"0 0 410");
		}
		for(%i = 0 ; %i < 4 ; %i++)
			if(%this.Seat[%i] != "") {
				%pl = Client::getOwnedObject(%this.Seat[%i]);
				Player::setMountObject(%pl, -1, 0);
	  	 		Client::setControlObject(%this.Seat[%i], %pl);
				%pl.vehicleSlot = "";
		   		%pl.vehicle= "";
//				item::setvelocity(%pl,"0 0 0");
				Player::applyImpulse(%pl,"0 0 410");
				//****NEW
				Player::setItemCount(%pl,MountedMachineGun,0);
				//Player::setItemCount(%pl,MinigunAmmo,0);
				Player::setItemCount(%pl,MountedArtillaryGun,0);
				//Player::setItemCount(%pl,AbramsAmmo,0);
				//*******

			}

		}
	}
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	if( gamebase::getdataname(%this) == Carryall)
	{
		$Transport[$Cargo[%this]] = "";
	} else if( gamebase::getdataname(%this) == Roller || gamebase::getdataname(%this) == Tracker || gamebase::getdataname(%this) == Crawler)
	{
		$Cargo[$Transport[%this]] = "";
	}

	deleteobject(%this);
}


function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($damageScale[GameBase::getDataName(%this), %type])
		%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
echo("Test");
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


//-Height to float off ground
$GroundFloat = 2.1;
//-Our gravity constant for how fast out vehicles fall.
$GravConst = -21;
//-How often to have this loop.
$TimeSkip = 0.01;
//-The buffer for how much our rot can be off from the terrain's.
// Should smooth the ride out a little.
$RotOffset = 0.1;
// offset for roller
$TRotOffSet = 0.2;

function VehicleHover(%veh,%client)
{
	//Make sure client exists and is the guy controling the car.
	if(%client < 1 || %client == "")
		%client = GameBase::getControlClient(%veh);

	//If we got a driver, arn't being carried and have something under us.
	if($Transport[%veh] == "" && GameBase::getControlClient(%veh) == %client && GameBase::getLOSInfo(%veh,5000,"-1.570796327 0 0")) {
		//Get the position and rotation of the ground
		%groundRot = $los::normal;
		%groundPos = $los::position;

		//get the position and rotation of the vehicle.
		%rot0 = GameBase::getRotation(%veh);
		%pos0 = GameBase::getPosition(%veh);

		//Take care of ground. If were higher, then fall and such.
		%NewPos = getWord(%pos0,0)@" "@getWord(%pos0,1)@" "@getWord(%groundPos,2)+$GroundFloat;
		if(%ZDist > $GroundFloat + 0.9) {
			%displacement = %veh.lastVel*$TimeSkip + 0.5*$GravConst*($TimeSkip*$TimeSkip);
			%veh.lastVel = sqrt( %veh.lastVel*%veh.lastVel + 2*$GravConst*%displacement);
			if(%displacement < 0 )
				%veh.lastVel = %veh.lastVel*-1;
				
			if( (%ZDist-%displacement) > $GroundFloat ){
				%NewPos = getWord(%NewPos,0)@" "@getWord(%NewPos,1)@" "@getWord(%veh.lastPos,2)+%displacement;
			}
		} else {
			%veh.lastVel = getword(Item::getVelocity(%veh),2);
		}

		//Keep rotation constant if were in the "air"


		//if(%ZDist >  $GroundFloat + 0.9)
		//	%NewRot = %veh.lastRot;
		

		//Set all our things.

		GameBase::setPosition(%veh,%newPos);
		
		// Only set rot if its to much.
		//Smooth out the rotation settings a tad.
	
		// %optimal is our "perfect" angle
		%optimal = -1*getword(%groundRot, 1)*cos(getword(%rot0, 2))
			 + getword(%groundRot, 0)*sin(getword(%rot0, 2));
		%RotDifference0 = (%optimal - getword(%rot0, 0));		
		if(%optimal < getWord(%rot0,0))
			%xchange = getWord(%rot0,0) - 0.05;
		else if(%optimal > getWord(%rot0,0))
			%xchange = getWord(%rot0,0) + 0.05;
		else
			%xchange = %optimal;

		if(GameBase::getDataName(%veh) == Roller)
			%rotoffset = $TRotOffset;
		else
			%RotOffset = $RotOffset;
		
		if(%ZDist >  $GroundFloat + 0.9)
			GameBase::setRotation(%veh,%veh.lastRot);
		else if( %rotDifference0 > %RotOffset || %rotDifference0 < -1*%RotOffset) {

			%NewRot = %xchange@" "@getWord(GameBase::getRotation(%veh),1)@" 							 		"@getWord(GameBase::getRotation(%veh),2);
			GameBase::setRotation(%veh,%NewRot);
			%veh.lastRot = %newRot;
		
		} else			
			%veh.lastRot = %rot0;

		%veh.lastPos = %newPos;


	} else if($Transport[%veh] != "")
	{
	// Handles the vehicle while in transport (doesnt matter if someones in the vehicle or not)
		// make sure were still being carried.
		//if($Transport[%veh] == "")
		//	return;
		%carryall = $Transport[%veh];
		// get position/rotation of carryall
		%pos = gamebase::Getposition(%carryall);
		%rot = Gamebase::GetRotation(%carryall);
		// setposition of gc to right below it.	
		%pos = vector::Add(%pos,"0 0 "@$Vehicle::TransDist);
		gamebase::setposition(%veh, %pos);
		gamebase::Setrotation(%veh, %rot);
		%veh.lastRot = %rot;
		%veh.lastPos = %Pos;
		%veh.lastVel = item::Getvelocity(%veh);
		// call this function.
		//schedule("Vehicle::CarryCargo("@%this@");",0.001,%this);
	}
		schedule("VehicleHover("@%veh@","@%client@");",$TimeSkip,%veh);

}

function angles(%client)
{
	%veh = client::Getcontrolobject(%client);	
	if(GameBase::getLOSInfo(%veh,5000,"-1.570796327 0 0")) 
	{
		//Get the position and rotation of the ground
		%groundRot = $los::normal;

		//get the position and rotation of the vehicle.
		%rot0 = GameBase::getRotation(%veh);
		echo("Ground:  " @ AddWhiteSpace(getword(%groundRot,0),10) @ " " @
				  AddWhiteSpace(getword(%groundRot,1),10) @ " " @
				  AddWhiteSpace(getword(%groundRot,2),10));
		echo("Vehicle: " @ AddWhiteSpace(getword(%rot0,0),10) @ " " @
				  AddWhiteSpace(getword(%rot0,1),10) @ " " @
				  AddWhiteSpace(getword(%rot0,2),10));
	}
}

function VehicleHoverold1(%veh,%client)
{
	if(%client < 1 || %client == "")
		%client = GameBase::getControlClient(%veh);
	if($Transport[%veh] == "" && GameBase::getControlClient(%veh) == %client && GameBase::getLOSInfo(%veh,5000,"-1.570796327 0 0")) {
		%groundRot = $los::normal;
		%groundPos = $los::position;
		%rot0 = GameBase::getRotation(%veh);
		%pos0 = GameBase::getPosition(%veh);
		%ZDist = getWord(%pos0,2)-getWord(%groundPos,2);
		//Directional vector pointed up (vehicle's)
		%UpVec = Vector::getFromRot(Vector::add(%rot0,"-1.570796327 0 0"),2);
		//Directional vector pointed up (terrain's)
		%RotVec = Vector::getRotation($los::normal);

		%NewRot = getWord(%rotvec,0)@" "@getWord(GameBase::getRotation(%veh),1)@" "@getWord(GameBase::getRotation(%veh),2);
		%NewPos = getWord(%pos0,0)@" "@getWord(%pos0,1)@" "@getWord(%groundPos,2)+$GroundFloat;
		//%speed = sqrt(pow(getword(Item::getVelocity(%veh),0),2) + pow(getword(Item::getVelocity(%veh),1),2) + pow(getword(Item::getVelocity(%veh),2),2));
		%speed = vector::getdistance(Item::getVelocity(%veh),"0 0 0");
		%Change = getWord(%pos0,2)-getWord(%veh.lastPos,2);
		if((%speed > 0 && %Change >= 0)||(%speed < 0 && %Change < 0)) {
			%NewRot = getWord(%NewRot,0)*-1@" "@getWord(%NewRot,1)@" "@getWord(%NewRot,2);
			
		} else if ( %speed == 0 ) {
			%NewRot = %veh.lastRot;
		}
		if(%change > -0.00000001 && %change < 0) {
			%NewRot = %veh.lastRot;
		}
		if(%ZDist > $GroundFloat + 0.9) {
			%displacement = %veh.lastVel*$TimeSkip + 0.5*$GravConst*($TimeSkip*$TimeSkip);
			%veh.lastVel = sqrt( %veh.lastVel*%veh.lastVel + 2*$GravConst*%displacement);
			if(%displacement < 0 )
				%veh.lastVel = %veh.lastVel*-1;
				
			if( (%ZDist-%displacement) > $GroundFloat ){
				%NewPos = getWord(%NewPos,0)@" "@getWord(%NewPos,1)@" "@getWord(%veh.lastPos,2)+%displacement;
			}
		} else {
			%veh.lastVel = getword(Item::getVelocity(%veh),2);
		}
		if(%ZDist >  $GroundFloat + 0.9)
			%NewRot = %veh.lastRot;
		GameBase::setRotation(%veh,%NewRot);
		GameBase::setPosition(%veh,%newPos);
		GameBase::setRotation(%veh,%NewRot);
		%veh.lastRot = GameBase::getRotation(%veh);
		%veh.lastPos = GameBase::getPosition(%veh);



	} else if($Transport[%veh] != "")
	{
	// Handles the vehicle while in transport (doesnt matter if someones in the vehicle or not)
		// make sure were still being carried.
		//if($Transport[%veh] == "")
		//	return;
		%carryall = $Transport[%veh];
		// get position/rotation of carryall
		%pos = gamebase::Getposition(%carryall);
		%rot = Gamebase::GetRotation(%carryall);
		// setposition of gc to right below it.	
		%pos = vector::Add(%pos,"0 0 10");
		gamebase::setposition(%veh, %pos);
		gamebase::Setrotation(%veh, %rot);
		// call this function.
		//schedule("Vehicle::CarryCargo("@%this@");",0.001,%this);
	}
		schedule("VehicleHover("@%veh@","@%client@");",$TimeSkip,%veh);
}


function VehicleHoverOld(%veh,%client)
{
	if(!%client)
		%client = GameBase::getControlClient(%veh);
	if($Transport[%veh] == "" && GameBase::getControlClient(%veh) == %client && GameBase::getLOSInfo(%veh,5000,"-1.570796327 0 0")) {
		%groundRot = $los::normal;
		%groundPos = $los::position;
		%rot0 = GameBase::getRotation(%veh);
		%pos0 = GameBase::getPosition(%veh);
		%ZDist = getWord(%pos0,2)-getWord(%groundPos,2);
		%UpVec = Vector::getFromRot(Vector::add(%rot0,"-1.570796327 0 0"),2);
		%RotVec = Vector::getRotation($los::normal);
		%NewRot = getWord(%rotvec,0)@" "@getWord(GameBase::getRotation(%veh),1)@" "@getWord(GameBase::getRotation(%veh),2);
		%NewPos = getWord(%pos0,0)@" "@getWord(%pos0,1)@" "@getWord(%groundPos,2)+$GroundFloat;
		//%speed = sqrt(pow(getword(Item::getVelocity(%veh),0),2) + pow(getword(Item::getVelocity(%veh),1),2) + pow(getword(Item::getVelocity(%veh),2),2));
		%speed = vector::getdistance(Item::getVelocity(%veh),"0 0 0");
		%Change = getWord(%pos0,2)-getWord(%veh.lastPos,2);
//echo("Change: " @%change);
//echo("Speed: " @ %speed);
		if((%speed > 0 && %Change >= 0)||(%speed < 0 && %Change < 0)) {
			%NewRot = getWord(%NewRot,0)*-1@" "@getWord(%NewRot,1)@" "@getWord(%NewRot,2);
//echo("Useing normal rot");
			
//echo("In ROT fix");
		} else if ( %speed == 0 ) {
			%NewRot = %veh.lastRot;
		}
		if(%change > -0.00000001 && %change < 0) {
				%NewRot = %veh.lastRot;
//echo("Useing last rot");
		}
		if(%ZDist > $GroundFloat + 0.9) {
			%displacement = %veh.lastVel*$TimeSkip + 0.5*$GravConst*($TimeSkip*$TimeSkip);
			%veh.lastVel = sqrt( %veh.lastVel*%veh.lastVel + 2*$GravConst*%displacement);
			if(%displacement < 0 )
				%veh.lastVel = %veh.lastVel*-1;
				
			if( (%ZDist-%displacement) > $GroundFloat ){
				%NewPos = getWord(%NewPos,0)@" "@getWord(%NewPos,1)@" "@getWord(%veh.lastPos,2)+%displacement;
			}
		} else {
			%veh.lastVel = getword(Item::getVelocity(%veh),2);
		}
		if(%ZDist >  $GroundFloat + 0.9)
			%NewRot = %veh.lastRot;
		GameBase::setRotation(%veh,%NewRot);
		GameBase::setPosition(%veh,%newPos);
		GameBase::setRotation(%veh,%NewRot);
		%veh.lastRot = GameBase::getRotation(%veh);
		%veh.lastPos = GameBase::getPosition(%veh);



	}// else if($Transport[%veh] != "")
//	{
		// make sure were still being carried.
		//if($Transport[%veh] == "")
		//	return;
//		%carryall = $Transport[%veh];
		// get position/rotation of carryall
//		%pos = gamebase::Getposition(%carryall);
//		%rot = Gamebase::GetRotation(%carryall);
		// setposition of gc to right below it.	
//		%pos = vector::Add(%pos,"0 0 10");
//		gamebase::setposition(%veh, %pos);
//		gamebase::Setrotation(%veh, %rot);
		// call this function.
		//schedule("Vehicle::CarryCargo("@%this@");",0.001,%this);
//	}
		schedule("VehicleHover("@%veh@","@%client@");",$TimeSkip,%veh);
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// (from DF as much of the stuff in Vehicles.cs is modified from it) Thanks to Hosed for use of this code...
function vehicleHover2(%vehicle, %clientId, %changeZRot, %changeYRot)
{
	// Global var. True if driving vehicle. False if not. 
	if($SFdrivingAPC[%clientId])  
	{
		%refX1 = "-0.393 0 0";
		%refX2 = "-0.393 0 1.571";
		%refX3 = "-0.786 0 0";
		%refX4 = "-0.786 0 1.571";

		%refY2 = "-0.393 0 0.786";
		%refY1 = "-0.393 0 -0.786";
		%refY4 = "-0.786 0 0.786";
		%refY3 = "-0.786 0 -0.786";
		
		%refHeight = "-1.575 0 0";

		//Temp set Rotations
		%OldRot = GameBase::getRotation(%vehicle);
		%NewXRot = getword(%OldRot, 0);
		%NewYRot = getword(%OldRot, 1);
		%changeInZ = %changeYRot - %NewYRot;
		%changeInZ = %changeInZ * 3;
		//if(($modVal % 5) == 0) 
		//	echo(%changeInZ);
		//$modVal++;
		%NewZRot = %changeZRot + %changeInZ;
		
		// Front Middle Position
		//----------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refX1))
			%frontMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refX3))
				%frontMiddlePos = $los::position;
			else
				%frontMiddlePos = "0 0 0";
		
		// Rear Middle Position
		//-----------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refX2))
			%rearMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refX4))
				%rearMiddlePos = $los::position;
			else
				%rearMiddlePos = "0 0 0";

		// Left Middle Position
		//------------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refY1))
			%leftMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refY3))
				%leftMiddlePos = $los::position;
			else
				%leftMiddlePos = "0 0 0";

		// Right Middle Position
		//------------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refY2))
			%rightMiddlePos = $los::position;
		else
			if(GameBase::getLOSInfo(%vehicle,1000,%refY4))
				%rightMiddlePos = $los::position;
			else
				%rightMiddlePos = "0 0 0";

		//-------------------
		// X Rotation Stuff
		//-------------------
		// Rear Position
		%rMidX = getword(%rearMiddlePos, 0);
		%rMidY = getword(%rearMiddlePos, 1);
		%rMidZ = getword(%rearMiddlePos, 2);
		// Front Position
		%fMidX = getword(%frontMiddlePos , 0);
		%fMidY = getword(%frontMiddlePos , 1);
		%fMidZ = getword(%frontMiddlePos , 2);
		// X Distance
		%rpos = %rMidX@" "@%rMidY@" 0";
		%fpos = %fMidX@" "@%fMidY@" 0";
		// Find average of both rotations
		// Total Distance
		%totDist = Vector::getDistance(%rpos, %fpos);
		%zDistance = %fMidZ - %rMidZ;
		if(%totDist != 0)
	    	if( %zDistance != 0 )
			{
				%OppAdd = %zDistance/%totDist;
				%NewXRot = inverseTan(%OppAdd);
			}

		//-------------------
		// Y Rotation Stuff
		//-------------------
		// Right Side Position
		%rsMidX = getword(%rightMiddlePos, 0);
		%rsMidY = getword(%rightMiddlePos, 1);
		%rsMidZ = getword(%rightMiddlePos, 2);
		// Left Side Position
		%lsMidX = getword(%leftMiddlePos , 0);
		%lsMidY = getword(%leftMiddlePos , 1);
		%lsMidZ = getword(%leftMiddlePos , 2);
		// Y Distance
		%rsPos = %rsMidX@" "@%rsMidY@" 0";
		%lsPos = %lsMidX@" "@%lsMidY@" 0";
		// Total Distance
		%totDist = Vector::getDistance(%rsPos, %lsPos);
		%zDistance = %lsMidZ - %rsMidZ;
		if(%totDist != 0)
			if( %zDistance != 0 )
			{
				%OppAdd = %zDistance/%totDist;
				%NewYRot = inverseTan(%OppAdd);
			}

		//-------------------
		// Height Stuff
		//-------------------
		if(GameBase::getLOSInfo(%vehicle,20,%refHeight))
		{
			%groundPos = $los::position;
			%vehiclePos = GameBase::getPosition(%vehicle);
			%vehicleX = getword(%vehiclePos, 0);
			%vehicleY = getword(%vehiclePos, 1);
			%vehicleZ = getword(%vehiclePos, 2);
			%groundz = getword(%groundPos, 2);
			%height = %vehicleZ - %groundZ;
			if(%height >= 2.49 || %height <= 2.51)
			{
				%newpos = %vehicleX @ " " @ %vehicleY @ " " @ (%groundZ + 2.5);
				GameBase::setPosition(%vehicle,%newpos);
			}
		}

		//-------------------
		// Set Rotation Stuff
		//-------------------
		// New Rotation
		%NewRot = %NewXRot@" "@%NewYRot@" "@%NewZRot;
		GameBase::setRotation(%vehicle,%NewRot);

		schedule("vehicleHover("@%vehicle@","@%clientId@","@%NewZRot@","@%NewYRot@");",0.05, %vehicle);
	}
}

function inverseTan(%x)
{
	%theta = %x - ((%x*%x*%x)/3) + ((%x*%x*%x*%x*%x)/5);
	return %theta;
}

//--------------------------------------------
//ICE'S VEHICLE BASE CODE FOR TESTING STATIONS
//--------------------------------------------
ItemImageData VehPackImage 
{
	shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 0.5;
        firstPerson = false;
};
ItemData VehPack 
{
        description = "Vehicle Station";
        shapeFile = "vehi_pur_pnl";
        className = "Backpack";
     	heading = "fDeployables";
        imageType = VehPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 5.0;
        price = 900000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function VehPack::onUse(%player,%item)
{
        if(Player::getMountedItem(%player,$BackpackSlot) != %item)
                Player::mountItem(%player,%item,$BackpackSlot);
        else
                Player::deployItem(%player,%item);
}
function VehPack::onDeploy(%player,%item,%pos)
{
        if(VehPack::deployShape(%player,%item))
                Player::decItemCount(%player,%item,$VehTestPadDec);
}
function VehPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		%team = GameBase::getTeam(%player);
		if(Vector::dot($los::normal,"0 0 1") > 0.7) {
			%rot1 = GameBase::getRotation(%player);
			%rot2 = Vector::Add(%rot1,"0 0 -1.570796327");
			%pos1 = $los::position;
			%pos2 = Vector::Add(%pos1,Vector::getFromRot(%rot1,5));
			%pos3 = Vector::Add(%pos2,Vector::getFromRot(%rot2,-7));
			
			%phase1 = newObject("vehi_pur_pnl","StaticShape",$VehTestPadType@"Station",true);
			addToSet("MissionGroup/Teams/team"@%team@"/"@$VehTestPadType@"Pad",%phase1);
			GameBase::setTeam(%phase1,%team);
			GameBase::setPosition(%phase1,%pos1);
			GameBase::setRotation(%phase1,%rot1);
			Gamebase::setMapName(%phase1,$VehTestPadType@" Station");
			
			%phase2 = newObject("vehi_pur_poles","StaticShape",$VehTestPadType@"Pad",true);
			addToSet("MissionGroup/Teams/team"@%team@"/"@$VehTestPadType@"Pad",%phase2);
			GameBase::setTeam(%phase2,%team);
			GameBase::setPosition(%phase2,%pos2);
			GameBase::setRotation(%phase2,%rot1);
			Gamebase::setMapName(%phase2,$VehTestPadType@" Pad");

			%phase3 = newObject("solar_med","StaticShape",SolarPanel,true);
			addToSet("MissionGroup/Teams/team"@%team@"/"@$VehTestPadType@"Pad",%phase3);
			GameBase::setTeam(%phase3,%team);
			GameBase::setPosition(%phase3,%pos3);
			GameBase::setRotation(%phase3,%rot2);
			Gamebase::setMapName(%phase3,"Solar Panel");
 			
			Client::sendMessage(%client,0,$VehTestPadType@" Base Deployed");
			playSound(SoundPickupBackpack,%pos1);
			playSound(ForceFieldClose,%pos1);
			playSound(ForceFieldClose,%pos2);
			playSound(ForceFieldClose,%pos3);
			GameBase::startFadeIn(%phase1);
			GameBase::startFadeIn(%phase2);
			GameBase::startFadeIn(%phase3);
			
			if($VehTestPadType == Ornithopter)
				%phase1.OrnithopterPad = %phase2;
			else if($VehTestPadType == GroundCar)
				%phase1.GroundCarPad = %phase2;
			else
				%phase1.VehiclePad = %phase2;
			return true;
		}
		else
			Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else
		Client::sendMessage(%client,0,"Deploy position out of range");
        return false;
}
$VehTestPadDec = 1;
$VehTestPadType = Ornithopter;
//-VEHICLE PAD TYPES-//
//VehicleStation
//VehiclePad
//OrnithopterStation
//OrnithopterPad
//GroundCarStation
//GroundCarPad