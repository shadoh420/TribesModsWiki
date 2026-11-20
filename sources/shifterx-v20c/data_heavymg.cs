ItemData HeavyMGAmmo 
{
	description = "Heavy Machinegun Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 20;
};

BulletData HeavyMGBulletA
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;

   explosionRadius  = 2.3;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.18;    //=== Shifter X - Was: .17
   damageType         = $BulletDamageType;

   aimDeflection      = 0.004;   //=== Shifter X - Was: 0.003
   muzzleVelocity     = 425.0;
   liveTime	      = 2;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 20.0;
   tracerLength       = 30;
};

BulletData HeavyMGBulletI
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;

   explosionRadius  = 2.3;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.18;    //=== Shifter X - Was: .17
   damageType         = $BulletDamageType;
   aimDeflection      = 0.027;   //=== Shifter X - Was: 0.025
   muzzleVelocity     = 425.0;
   liveTime	      = 2;
   totalTime          = 3;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 20.0;
   tracerLength       = 30;
};

ItemImageData HeavyMGImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.17;   //=== Shifter X - Was: 0.1
	spinDownTime = 3;
	fireTime = 0.13;   //=== Shifter X - Was: 0.2
	accuFire = true;

	ammoType = HeavyMGAmmo;
//	projectileType = Undefined;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 2;
	lightColor = { 0, 1.0, 0 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData HeavyMGGun
{
	description   = "Heavy Machinegun";
	className     = "Weapon";
	shapeFile     = "radar_small";
	hudIcon       = "mortar";
	heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType     = HeavyMGImage;
	price         = 1050;
	showWeaponBar = true;
};

exec("weapon_HeavyMG.cs");