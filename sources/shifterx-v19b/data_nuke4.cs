ItemData Mfgl4Ammo
{
	description = "MLRS Missiles";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 100;
};

ItemImageData Mfgl4Image
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Mfgl4Ammo;
//	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 3;	//=== Shifter X - Was: 3.1
	fireTime = 4;	//=== Shifter X - Was: 4.0

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

//	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mfgl4
{
	description = "MLRS";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mfgl4Image;
	price = 600;
	showWeaponBar = true;
};

GrenadeData Nuke4Shell
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = false;
   ownerGraceMS       = 250;
   collisionRadius    = 0.5;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.75;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 12.0;
   kickBackStrength   = 5.0;
   maxLevelFlightDist = 450;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName          = "rsmoke.dts";
  
};

exec("weapon_nuke4.cs");