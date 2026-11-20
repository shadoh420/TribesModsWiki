//================================================================
// Torque 
//================================================================

SoundData SoundFireTorque
{
   wavFileName = "plasma2.wav";
   profile = Profile3dNear;
};

SoundData SoundTorqueReload
{
   wavFileName = "mortar_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionTorque
{
   wavFileName = "shieldhit.wav";
   profile = Profile3dFar;
};

//================================================================
ExplosionData TorqueExp
{
   shapeName = "shield_large.dts";
   soundId   = ExplosionTorque;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};
//================================================================
RocketData ProjTorque
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = TorqueExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $TorqueDamageType;

   explosionRadius  = 10;
   kickBackStrength = 500.0;

   muzzleVelocity   = 1000.0;
   terminalVelocity = 5000.0;
   acceleration     = 25.0;

   totalTime        = 3.0;
   liveTime         = 3.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 2.0;
};
//================================================================

ItemData TorqueAmmo
{
	description = "Torque Ammo";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = TorqueAmmo;
	projectileType = ProjTorque;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.35;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireTorque;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundTorqueReload;
};

ItemData PlasmaGun
{
	description = "Torque";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};
//=================================================================
echo("Item Loaded");