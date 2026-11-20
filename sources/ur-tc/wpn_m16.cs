


SoundData SoundWPNAssault
{
   wavFileName = "wpn_assault.wav";
   profile = Profile3dNearLoop;
};

ExplosionData AssaultExp
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};


BulletData m16Bullet
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = AssaultExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $AssaultDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 9000;
   totalTime          = 1;
   inheritedVelocityScale = 0;
   isVisible          = true;

   tracerPercentage   = 0;
   tracerLength       = 0;
};




ItemImageData LiLPOOmkiImage
{
	shapeFile = "wpn_assault";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = M16Bullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.06;
	minEnergy = 1;
	maxEnergy = 0.1;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 1, 0, 0 };

	sfxFire = SoundWPNAssault;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LiLPOOmki
{
	description = "M16 Assault Rifle";
	className = "Weapon";
	shapeFile = "wpn_assault";
	hudIcon = "sniper";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = LiLPOOmkiImage;
	price = 50;
  showWeaponBar = false;
   //validateShape = true;
   validateMaterials = true;
};
