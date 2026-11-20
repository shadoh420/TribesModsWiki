StaticShapeData ANukeTarget
{
	shapeFile = "breath";
	maxDamage = 0.3;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "";
};

SeekingMissileData ANukeRocket
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.5;
	mass = 1.0;
	damageClass = 1;
	damageValue = 4;
	damageType = $MissileDamageType;
	explosionRadius = 6.0;			  //=== Shifter X - Was 8.5?
	kickBackStrength = 180.0;             //=== Shifter X - Was: 200.0
	muzzleVelocity = 80.0;
	terminalVelocity = 80.0;
	acceleration = 12.0;

	totalTime = 8.0;
	liveTime = 8.0;
	lightRange = 3.0;
	lightColor = { 1.0, 0.7, 0.5 };
	seekingTurningRadius = 0.2;
	nonSeekingTurningRadius = 0.2;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 2.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
//Turret Stuff

TurretData ANukeTurret
{
	className = "Turret";
	shapeFile = "mortar_turret";
//	projectileType = ANukeBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.01;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55; // 30
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
//	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Nuclear Defense System";
	damageSkinData = "objectDamageSkins";
};

//Item stuff

ItemImageData ANukeImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ANuke
{
	description = "N.D. System";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "gTurrets";
	imageType = ANukeImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

exec("func_anuke.cs");