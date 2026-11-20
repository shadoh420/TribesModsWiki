
//================================================================
// Minigun 
//================================================================
$AutoUse[Minigun] = False;
//===============================================================

//================================================================

//================================================================
SoundData SoundWPNMinigun
{
   wavFileName = "wpn_minigun.wav";
   profile = Profile3dNearloop;
};
SoundData SoundWPNMinigunSpinUp
{
   wavFileName = "wpn_minigun_up.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMinigunSpinDown
{
   wavFileName = "wpn_minigun_down.wav";
   profile = Profile3dNear;
};

SoundData SoundWhizMini
{
   wavFileName = "whiz_mini.wav";
   profile = Profile3dCloseLoop;
};
SoundData SoundRicochetMini
{
   wavFileName = "exp_mini.wav";
   profile = Profile3dNear;
};
//=============================================================
ExplosionData MinigunExp
{
   shapeName = "chainspk.dts";
   soundId   = RicochetMini;
   //validateShape = true;
   //validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

//================================================================


BulletData Minigunproj
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = MinigunExp;
	expRandCycle       = 0;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.3;
	damageType         = $BulletDamageType;
	
	aimDeflection      = 0.005;
	muzzleVelocity     = 700.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = false;
	
	tracerPercentage   = 1.0;
	tracerLength       = 50;
};

//-------------------------------------------------------


//================================================================


ItemImageData MinigunImage
{
	shapeFile = "wpn_minigun";
	mountPoint = 0;
	
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 1.0;
	fireTime = 0.04;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//ammoType = MinigunAmmo;
	projectileType = MinigunProj;
	accuFire = false;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	
	sfxFire = SoundWPNMinigun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundWPNMinigunSpinUp;
	sfxSpinDown = SoundWPNMinigunSpinDown;
};

ItemData Minigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "wpn_Minigun";
	hudIcon = "Minigun";
	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 0;
	  showWeaponBar = false;
};


//================================================================
////////////////////////////////////////////////////////////////////
//echo("Minigun Loaded");