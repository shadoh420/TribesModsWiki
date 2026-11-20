ItemData SAMAmmo 
{
	description = "SAM Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 400;
};

SeekingMissileData SAMrocket
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 1;
	damageValue = 0.63;			//=== Shifter X - Was: 0.6
	damageType = $MissileDamageType;
	explosionRadius = 4.5;			//=== Shifter X - Was: 4.0?
	kickBackStrength = 80.0;		//=== Shifter X - Was: 200.0
	muzzleVelocity = 185.0;
	terminalVelocity = 200.0;
	acceleration = 15.0;
	totalTime = 15.0;
	liveTime = 16.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	seekingTurningRadius = 1.0;
	nonSeekingTurningRadius = 5.0;
	proximityDist = 1.0;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	trailType = 2;
	trailString = "plasmatrail.dts";
	smokeDist = 2.5;
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

LightningData SAMlock
{
	bitmapName       = "lightningNew.bmp";

	damageType       = $GravDamageType;
	boltLength       = 900.0;
	coneAngle        = 40.0;		//=== Shifter X - Was: 30, 26.0
	damagePerSec      = 0.00001;
	energyDrainPerSec = 0;

	segmentDivisions = 1;
	numSegments      = 0;
	beamWidth        = 0.01;
	updateTime   = 150;
	skipPercent  = 0.10;
	displaceBias = 0.25;

	lightRange = 0.1;
	lightColor = { 1, 0, 0 };

//	soundId = SoundELFFire;
};

ItemImageData SAMImage
{
	shapeFile = "rocket";
	mountOffset = { 0, 0.2, 0 };

	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	ammoType = SAMAmmo;
	accuFire = false;
	reloadTime = 0.9;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundMineActivate;
};

ItemData SAMgun
{
	description   = "SAM Launcher";
	className     = "Weapon";
	shapeFile     = "radar_small";
	hudIcon       = "mortar";
	heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType     = SAMImage;
	price         = 80;
	showWeaponBar = true;
};

exec("weapon_sam.cs");