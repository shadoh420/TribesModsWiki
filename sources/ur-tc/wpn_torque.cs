//================================================================
// Torque 
//================================================================

SoundData SoundFireTorque
{
   wavFileName = "wpn_torque.wav";
   profile = Profile3dNear;
};

SoundData SoundTorqueReload
{
   wavFileName = "wpn_Torque_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionTorque
{
   wavFileName = "exp_torque.wav";
   profile = Profile3dFar;
};

//================================================================

ExplosionData TorqueExp
{
   shapeName = "proj_torque.dts";
   soundId   = ExplosionTorque;

   faceCamera = true;
   randomSpin = true;
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
BulletData TorqueShell
{
   bulletShapeName    = "proj_torque.dts";
   explosionTag       = TorqueExp;

   damageClass        = 1;
   damageValue        = 1.0;
   damageType         = $TorqueDamageType;
   explosionRadius    = 15;

   muzzleVelocity     = 800;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;
	rotationPeriod = 3.0;
   soundId = SoundJetLight;
};

//================================================================

ItemImageData MortarImage 
{ 
        shapeFile = "wpn_torque";
        mountPoint = 0;

        weaponType = 0;
        //ammoType = TorqueAmmo;
        projectileType = TorqueShell;
        accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.0;
	minEnergy = 0.01;
	maxEnergy = 0.01;

        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
	sfxFire = SoundFireTorque;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTorqueReload;
};

ItemData Mortar
{ 
        description = "Torque Cannon";
        className = "Weapon";
        shapeFile = "wpn_torque";
        hudIcon = "plasma";
        heading = "TWeapons";
        shadowDetailMask = 4;
        imageType = MortarImage;
        price = 100;
        //showWeaponBar = true;
};


//=================================================================
echo("Item Loaded");