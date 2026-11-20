//================================================================
//Fusion Rifle
//================================================================
$AutoUse[Fusion] = False;
//================================================================

//================================================================



//================================================================
SoundData SoundWPNFusion
{
   wavFileName = "wpn_Fusion.wav";
   profile = Profile3dNear;
};
SoundData FusionExplosion
{
   wavFileName = "exp_Fusion.wav";
   profile = Profile3dFar;
};
SoundData SoundWhizFusion
{
   wavFileName = "whiz_Fusion.wav";
   profile = Profile3dNearLoop;
};
//================================================================
ExplosionData FusionExp
{
   shapeName = "fusionex.dts";
   soundId   = FusionExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25, 1.0 };
   radFactors = { 1.0, 1.0, 0.0 };
};
//================================================================
BulletData Fusionproj
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = FusionExp;

   damageClass        = 1;
   damageValue        = 3;
   damageType         = $FusionDamageType;
   explosionRadius    = 8.0;

   muzzleVelocity     = 125.0;
   totalTime          = 7.0;
   liveTime           = 7.0;
   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundWhizFusion;
};
//================================================================
ItemImageData FusionImage
{
	shapeFile = "wpn_Fusion";
	mountPoint = 0;
	minEnergy = 0.01;
	maxEnergy = 0.01;
	weaponType = 0; // Single Shot
	//ammoType = FusionAmmo;
	projectileType = Fusionproj;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.1;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundWPNFusion;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Fusion
{
	description = "Fusion Rifle";
	className = "Weapon";
	shapeFile = "wpn_Fusion";
	hudIcon = "Fusion";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = FusionImage;
	price = 0;
	  showWeaponBar = false;
};
//================================================================

//echo("Fusion Loaded");
