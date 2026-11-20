$VehicleInvList[ScoutVehicle] = 1;
$DataBlockName[ScoutVehicle] = Scout;
$VehicleToItem[Scout] = ScoutVehicle;
$VehicleSlots[Scout] = 0;

ItemData ScoutVehicle 
{
	description = "Fighter";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 600;
};

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
	maxBank = 0.9;
	maxPitch = 0.9;
	maxSpeed = 95;
	minSpeed = -10;
	lift = 0.95;
	maxAlt = 20000; //30
	maxVertical = 20;
	maxDamage = 0.75;
	damageLevel = {1.0, 1.0};
	maxEnergy = 250;
	accel = 1.5;
	groundDamageScale = 0.5;
	projectileType = ScoutMissile;
	reloadDelay = 2.5;
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
};

function Scout::onPilot(%this, %player)
{
}

function Scout::onUnPilot(%this, %player)
{
}
