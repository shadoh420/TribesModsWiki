
SoundData SoundWPNFEB
{
   wavFileName = "wpn_feb.wav";
   profile = Profile3dNearLoop;
};


ExplosionData feb
{
	shapeName = "plasmaex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

ExplosionData febExp
{
	shapeName = "plasmaex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};
BulletData febtrail
{
	bulletShapeName    = "plasmaex.dts";
	explosionTag       = Feb;
	mass               = 0.75;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.025;
	damageType         = $tranqDamageType;

	aimDeflection      = 0.004;
	muzzleVelocity     = 50.0;
	totalTime          = 0.35;
	inheritedVelocityScale = 0.5;
	isVisible          = true;
};

GrenadeData febeating
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = FebExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.5;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.013;
	damageType         = $tranqDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 1;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "plasmatrail.dts";
};

function FEB::onAdd(%this)
{
	FEB::febCheck(%this);
}

function FEB::febCheck(%this)
{
	if(GameBase::getPosition(%this) != GameBase::getPosition(%this.victim))
		GameBase::setPosition(%this,Vector::add(GameBase::getPosition(%this.victim),"0 0 "@$FebBurnElevation));
	schedule("FEB::FEBCheck("@%this@");",0.5,%this);
}

BulletData FebBullet
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = febExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $TranqDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 6000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   tracerPercentage   = 0;
   tracerLength       = 0;
};


ItemImageData LiLPOOmkiiImage
{
	shapeFile = "wpn_feb";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = FebBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.09;
	minEnergy = 1;
	maxEnergy = 0.1;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 1, 0, 0 };

	sfxFire = SoundWPNFEB;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LiLPOOmkii
{
	description = "FEB Rifle";
	className = "Weapon";
	shapeFile = "wpn_feb";
	hudIcon = "sniper";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = LiLPOOmkiiImage;
	price = 50;
  showWeaponBar = false;
   //validateShape = true;
   validateMaterials = true;
};