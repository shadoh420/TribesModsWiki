BulletData ChaingunBulletBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;    //=== Shifter X - Was: 0.07 (1.9), .11
   damageType         = $BulletDamageType;

//   aimDeflection      = 0.006;   //=== Shifter X - Was: 0.005
   muzzleVelocity     = 1500.0;	//425.0
   totalTime          = 1.5;
   inheritedVelocityScale = 0.0;	//was 1.0
   isVisible          = False;

   tracerPercentage   = 0;	//1.0
   tracerLength       = 30;
};

LaserData ChaingunBulletLaser
{
  //laserPulse.bmp = origional beam
  //lflame.bmp = 2 side by side blue beams
  //lightningTemp.bmp = multicolor strait beam (white/blue)
  //trailtest.bmp = dark blue beam, no fade
  //warp.bmp = twirling purple beam
  //flame = bland blue beam
  //flare = morphing pink beam
  //plasmabolt.bmp = orange beam

   laserBitmapName   = "laserPulse.bmp";
//   hitName           = "laserhit.dts";

   damageConversion  = 0.0;		//=== Shifter X - Was: 0.009
   baseDamageType    = $GravDamageType;

   beamTime          = 0.7;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
//   hitSoundId        = SoundLaserHit;
};

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // 1 = Spinning
	reloadTime = 0; //0
	spinUpTime = 0.15;   //=== Shifter X - Was: 0.2
	spinDownTime = 3;
	fireTime = 0.15;   //=== Shifter X - Was: 0.125 (1.9), 0.2

	ammoType = BulletAmmo;
//	projectileType = ChaingunBullet;
//	accuFire = false;   //=== Shifter X
	accuFire = True;

//	minEnergy = 1;
//	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

exec("weapon_chaingun.cs");