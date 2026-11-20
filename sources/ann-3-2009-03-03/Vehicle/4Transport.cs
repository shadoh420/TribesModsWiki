$VehicleInvList[TransportVehicle] = 1;	//0;
$DataBlockName[TransportVehicle] = Transport;
$VehicleToItem[Transport] = TransportVehicle;
$VehicleSlots[Transport] = 4;

ItemData TransportVehicle 
{
	description = "Transport";
	className = "Vehicle";
	heading = $InvHead[ihVeh];
	price = 875;
};

FlierData Transport
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc";
	shieldShapeName = "shield_large";
	mass = 18.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.4;
	maxPitch = 0.4;
	maxSpeed = 35;
	minSpeed = -1;
	lift = 0.75;
	maxAlt = 20000; //15
	maxVertical = 20;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.30;
	groundDamageScale = 0.5;	//0.125;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 23;
	description = "Transport";
};

function Transport::onPilot(%this, %player)
{
}

function Transport::onUnPilot(%this, %player)
{
}