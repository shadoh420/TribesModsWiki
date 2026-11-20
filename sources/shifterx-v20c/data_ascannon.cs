BulletData AsCannonBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpMedium;

   damageClass        = 1;
   damageValue        = 0.25;		//=== Shifter X - Was 0.29
   damageType         = $ExplosionDamageType;
   explosionRadius    = 1.5;

   muzzleVelocity     = 2000.0;
   totalTime          = 5.5;
   liveTime           = 6.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   soundId = SoundJetLight;
};

ItemImageData AsCannonImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 2;
	lightColor = { 0, 1.0, 0 };

//	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AsCannonGun
{
	description   = "Assault Cannon";
	className     = "Weapon";
	shapeFile     = "radar_small";
	hudIcon       = "mortar";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType     = AsCannonImage;
	price         = 1200;
	showWeaponBar = true;
};

exec("weapon_ascannon.cs");