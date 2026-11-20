// Tank Stuff

// GameBase
//  className
//  visibleToSensor
//  mapIcon
//  mapFilter
//  description
//  validateShape
//  validateMaterials

// ShapeBase
//  damageSkinData
//  shapeFile
//  shieldShapeName
//  shadowDetailMask
//  explosionId
//  debrisId
//  sequenceSound
//  maxEnergy
//  maxDamage
//  repairRate
//  isPerspective

// StaticBase 
//  sfxAmbient
//  damageLevel
//  isTranslucent
//  triggerRadius
//  disableCollision

// VehicleData
//  mass
//  drag
//  density
//  maxSpeed
//  minSpeed
//  maxDamage
//  reloadDelay
//  projectileType
//  fireSound
//  damageSound
//  mountSound
//  dismountSound
//  idleSound
//  moveSound
//  ramDamage
//  ramDamageType
//  visibleDriver
//  driverPose

// TankData
//  VehicleData
//  maxGrade
//  suspension



TankData TestTank
{	// GameBase
	className = "Vehicle";
	visibleToSensor = true;
	mapIcon = "M_vehicle";
	mapFilter = 2;
	description = "Test Tank";
	//validateShape = false;
	//validateMaterials = false;
	
	// ShapeBase
	//damageSkinData = "";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	//sequenceSound = "";
	maxEnergy = 100;
	maxDamage = 3.5;
	repairRate = 0;
	//isPerspective = false;
	
	// StaticBase
	//sfxAmbient = "";
	damageLevel = {1.0, 1.0};
	//isTranslucent = false;
	//triggerRadius = false;
	//disableCollision = false;

	// VehicleData
	mass = 100.0;
	drag = 0.5;
	density = 1.2;
	maxSpeed = 80;
	minSpeed = 0;
	//maxDamage = 3.5; // Already done.
	reloadDelay = 0.1;
	//projectileType = FalconBullet;
	fireSound = shockExplosion;
	damageSound = SoundTankCrash;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundFlyerActive;
	ramDamage = 1.5;
	ramDamageType = -1;
	visibleDriver = false;
	driverPose = 22;

	// TankData
	maxGrade = 1;
	suspension = 0.5;

// Not used
//	maxBank = 100.0;
//	maxPitch = 100.0;//6
//	lift = 20.0;
//	maxAlt = 450;
//	maxVertical = 20;
//	damageLevel = {1.0, 1.0};
//	accel = 0.5;
//	groundDamageScale = 1.0;
//	shadowDetailMask = 2;

};
