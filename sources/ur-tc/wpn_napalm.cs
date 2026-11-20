//================================================================
// Napalm Launcher
//================================================================

SoundData SoundFireNapalm
{
   wavFileName = "turretfire2.wav";
   profile = Profile3dNear;
};

SoundData SoundNapalmReload
{
   wavFileName = "turretturn1.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionNapalm
{
   wavFileName = "exp_napalm.wav";
   profile = Profile3dFar;
};

ExplosionData Burn
{
	shapeName = "plasmatrail.dts";
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

ExplosionData fireExp
{
	shapeName = "plasmatrail.dts";
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
BulletData Flames
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = Burn;
	mass               = 0.75;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.025;
	damageType         = $NapalmDamageType;

	aimDeflection      = 0.004;
	muzzleVelocity     = 50.0;
	totalTime          = 0.35;
	inheritedVelocityScale = 0.5;
	isVisible          = true;
};

GrenadeData Burning
{
	bulletShapeName    = "plasmabolt.dts";
	explosionTag       = FireExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.5;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.013;
	damageType         = $NapalmDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 1;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "plasmatrail.dts";
};

function Fire::onAdd(%this)
{
	Fire::BurnCheck(%this);
}

function Fire::BurnCheck(%this)
{
	if(GameBase::getPosition(%this) != GameBase::getPosition(%this.victim))
		GameBase::setPosition(%this,Vector::add(GameBase::getPosition(%this.victim),"0 0 "@$FlameBurnElevation));
	schedule("Fire::BurnCheck("@%this@");",0.5,%this);
}
//================================================================
ExplosionData NapalmExp
{
   shapeName = "tumult_large.dts";
   soundId   = ExplosionNapalm;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 3.0;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};
//================================================================
GrenadeData ProjNapalm
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = NapalmExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $NapalmDamageType;

   explosionRadius    = 25;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 400;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.75;

   smokeName              = "plastrail.dts";
};

//================================================================



ItemImageData GrenadeLauncherImage
{
	shapeFile = "wpn_napalm";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//ammoType = NapalmAmmo;
	projectileType = ProjNapalm;
	accuFire = false;
	reloadTime = 0.0;
	fireTime = 0.08;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireNapalm;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundNapalmReload;
};

ItemData GrenadeLauncher
{
	description = "Napalm Launcher";
	className = "Weapon";
	shapeFile = "wpn_napalm";
	hudIcon = "grenade";
   	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 0;
	  showWeaponBar = false;
	showInventory = true;
   	//validateShape = true;
   	//validateMaterials = true;
};



//=================================================================
echo("Item Loaded");