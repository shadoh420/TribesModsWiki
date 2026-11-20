ItemData Mfgl3Ammo
{
	description = "ICBM Warhead";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 500;
};

ItemImageData Mfgl3Image
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Mfgl3Ammo;
//	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 4.5;	//=== Shifter X - Was: 3.1
	fireTime = 5;	//=== Shifter X - Was: 4.0

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

//	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mfgl3
{
	description = "ICBM";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mfgl3Image;
	price = 3500;
	showWeaponBar = true;
};

ExplosionData Nuke3Shockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 0.0, 0.0 };
   colors[2]  = { 0.0, 0.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

RocketData Nuke3Rocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = LargeShockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 7;	//=== Shifter X - Was: 6 (1.8H)
   damageType       = $NukeDamageType;

   explosionRadius  = 85;	//=== Shifter X - Was: 85 (1.8H)
   kickBackStrength = 300.0;

   muzzleVelocity   = 7.5;
   terminalVelocity = 7.5;
   acceleration     = 0.0;

   totalTime        = 30.5;
   liveTime         = 30.0;

   lightRange       = 30.0;
   lightColor       = { 1.0, 1.0, 1.0 };

   inheritedVelocityScale = 0.1;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rocket.dts";	//plasmatrail.dts //rsmoke.dt
   smokeDist   = 1.0;
};

RocketData Nuke3Rocket2
{
   bulletShapeName = "bullet.dts";
   explosionTag    = Nuke3Shockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;
   damageValue      = 0.0;
   damageType       = $NukeDamageType;

   explosionRadius  = 1;
   kickBackStrength = 0.0;

   muzzleVelocity   = 7.5;
   terminalVelocity = 7.5;
   acceleration     = 0.0;

   totalTime        = 30.5;
   liveTime         = 30.0;

   lightRange       = 0.0;
   lightColor       = { 1.0, 1.0, 1.0 };

   inheritedVelocityScale = 0.1;
};


exec("weapon_nuke3.cs");