
//----------------------------------------------------------------------------
//Tomcat, F-14 Crashing
//----------------------------------------------------------------------------

FlierData TomcatCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 100.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100.0;
   maxPitch = 100.0;//6
   maxSpeed = 80;
   minSpeed = 70;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = FalconBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-14A Tomcat";
};


FlierData TomcatMove
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 100.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100.0;
   maxPitch = 100.0;//6
   maxSpeed = 80;
   minSpeed = 80;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = FalconBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-14A Tomcat";
};

//----------------------------------------------------------------------------
//Falcon, F-16 Crashing
//----------------------------------------------------------------------------

FlierData FalconCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 100.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 5.0;
   maxPitch = 100.0; //(5) This way we can do many loops in the air without rewinding
   maxSpeed = 75;
   minSpeed = 65.6;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1000;//0.5;

	groundDamageScale = 1.0;

	//projectileType = FalconBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-16 Falcon";
};

FlierData FalconMove
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 100.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 5.0;
   maxPitch = 100.0; //(5) This way we can do many loops in the air without rewinding
   maxSpeed = 75;
   minSpeed = 75;
	lift = 20.0;
	maxAlt = 450;
	maxVertical = 20;
	maxDamage = 3.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1000;//0.5;

	groundDamageScale = 1.0;

	//projectileType = FalconBullet;
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "F-16 Falcon";
};

FlierData ApacheCrash
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
   maxSpeed = 45;
   minSpeed = 39;
	lift = 0.75;
	maxAlt = 300;
	maxVertical = 10;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	//projectileType = ApacheRocket;
	reloadDelay = 0.5;
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
	description = "AH-64D Apache";
};

FlierData KiowaCrash
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
   maxSpeed = 40;
   minSpeed = 34;
	lift = 0.65;
	maxAlt = 300;
	maxVertical = 10;
	maxDamage = 1.75;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	//projectileType = ApacheRocket;
	reloadDelay = 0.5;
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
	description = "OH-58D Kiowa";
};

FlierData HindCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_medium";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 26;
	lift = 1.24;
	maxAlt =300;
	maxVertical = 10;
	maxDamage = 5.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 0.5;

	//projectileType = ApacheRocket;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 8.0;
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
	driverPose = 23;
	description = "Mi-24 Hind";
};

function HindCrash::onFire(%this) 
{
	Vehicle::onFire(%this);
}

FlierData BomberCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 26.25;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundDryFire;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "B-52 Stratofortress";
};
FlierData BomberMove
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 30;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundDryFire;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "B-52 Stratofortress";
};

FlierData HerculesCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 26.25;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = True;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "C-130 Hercules";
};

FlierData SentryCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 26.25;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundDryFire;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "E-3 Sentry";
};
FlierData SentryMove
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 30;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundDryFire;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = False;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "E-3 Sentry";
};

FlierData GunshipCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
     mass = 500.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.5;
   maxSpeed = 30;
   minSpeed = 26.25;
	lift = 20.0;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 15.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = BombShell;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = True;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "AC-130U Gunship";
};

function GunshipCrash::onAdd(%this) 
{
	$VehicleAmmo[%this, LowMountTwentyFivemmgun] = 1000;
	$VehicleAmmo[%this, LowMountAbramsGun] = 30;
	$VehicleAmmo[%this, Fortymmgun] = 500;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	$PassengerSlot[%this, 4] = 0;
	$PassengerSlot[%this, 5] = 0;
	Vehicle::onAdd(%this);
}

FlierData WarthogCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
     mass = 100.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100;//2.7;
   maxPitch = 100;//5.7;
   maxSpeed = 55;
   minSpeed = 48.125;
	lift = 20.0;
	maxAlt = 250;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = WarthogBullet;
	//reloadDelay = 0.5;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	//reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "A-10 Warthog";
};
function WarthogCrash::onFire(%this)
{
	Vehicle::onFire(%this);
}

FlierData BlackhawkCrash
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
   maxSpeed = 37;
   minSpeed = 32;
	lift = 0.5;
	maxAlt = 300;
	maxVertical = 6;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.5;

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

	visibleDriver = false;
	driverPose = 23;
	description = "Blackhawk";
};

function BlackhawkCrash::onAdd(%this) 
{
	$VehicleAmmo[%this, LowMountMinigun] = 400;
	$PassengerSlot[%this, 2] = 0;
	$PassengerSlot[%this, 3] = 0;
	Vehicle::onAdd(%this);
}


FlierData MoveWarthogCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 0.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100;//0.70;           //maxBank = 0.25;
   maxPitch = 100;//0.70;          //maxPitch = 0.25;
   maxSpeed = 55;            //maxSpeed = 45;
   minSpeed = 48.125;
	lift = 0.75;
	maxAlt = 250;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

	groundDamageScale = 1.0;

	//projectileType = WarthogBullet;
	//reloadDelay = 0.5;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	//reloadDelay = 0.15;            //reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "A-10 Warthog";
};

function MoveWarthogCrash::onFire(%this)
{
	Vehicle::onFire(%this);
}

FlierData MoveBlackhawkExtractionCrash
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 0.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100;//0.70;           //maxBank = 0.25;
   maxPitch = 100;//0.70;          //maxPitch = 0.25;
   maxSpeed = 37;            //maxSpeed = 45;
   minSpeed = 32;
	lift = 0.75;
	maxAlt = 300;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 1000;

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

	visibleDriver = false;
	driverPose = 23;
	description = "Blackhawk";
};

FlierData MoveWarthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 0.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100;//0.70;           //maxBank = 0.25;
   maxPitch = 100;//0.70;          //maxPitch = 0.25;
   maxSpeed = 55;            //maxSpeed = 45;
   minSpeed = 55;
	lift = 0.75;
	maxAlt = 250;
	maxVertical = 20;
	maxDamage = 7.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.2363;

	groundDamageScale = 1.0;

	//projectileType = WarthogBullet;
	//reloadDelay = 0.5;
	//reloadRate = 0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	//fireSound = SoundFireMortar;
	//reloadDelay = 0.15;            //reloadDelay = 0.3;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;

	visibleDriver = False;
	driverPose = 23;
	description = "A-10 Warthog";
};

function MoveWarthog::onFire(%this)
{
	Vehicle::onFire(%this);
}


FlierData MoveBlackhawkExtraction
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 0.0;
   drag = 0.5;
   density = 1.2;
   maxBank = 100;//0.70;           //maxBank = 0.25;
   maxPitch = 100;//0.70;          //maxPitch = 0.25;
   maxSpeed = 37;            //maxSpeed = 45;
   minSpeed = 37;
	lift = 0.75;
	maxAlt = 300;
	maxVertical = 20;
	maxDamage = 7.0;
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

	visibleDriver = false;
	driverPose = 23;
	description = "Blackhawk";
};
