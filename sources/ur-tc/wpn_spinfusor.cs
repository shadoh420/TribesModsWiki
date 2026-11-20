//================================================================
//Spinfusor
//================================================================
//================================================================
SoundData SoundWPNDisc
{
   wavFileName = "wpn_disc.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNDiscReload
{
   wavFileName = "wpn_disc_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNDiscIdle
{
   wavFileName = "wpn_disc_idle.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWhizDisc
{
   wavFileName = "whiz_disc.wav";
   profile = Profile3dNearLoop;
};
SoundData discExplosion
{
   wavFileName = "exp_disc.wav";
   profile = Profile3dMedium;
};

//================================================================
ExplosionData DiscExp
{
   shapeName = "exp_disc.dts";
   soundId   = discExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2.5;

   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 3.0 };
   colors[1]  = { 0.0, 0.0, 3.0 };
   colors[2]  = { 0.0, 0.0, 3.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

//================================================================
//================================================================
RocketData Discproj
{
   bulletShapeName = "proj_disc.dts";
   explosionTag    = DiscExp;

   collisionRadius = 0;
   mass            = 3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $DiscDamageType;

   explosionRadius  = 5;
   kickBackStrength = -100;

   muzzleVelocity   = 700;
   terminalVelocity = 3000;
   acceleration     = 25;

   totalTime        = 10;
   liveTime         = 7;

   lightRange       = 1;
   lightColor       = { 0.5, 0.5, 2.0 };

   inheritedVelocityScale = 0.75;

   // rocket specific
   //trailType   = 1;
   //trailLength = 25;
   //trailWidth  = 0.5;

   soundId = SoundWhizDisc;
};
//================================================================

ItemImageData DiscLauncherImage
{
        shapeFile = "wpn_disc";
        mountPoint = 0;

        weaponType = 3; // DiscLauncher
        //ammoType = DiscAmmo;
        projectileType = Discproj;
        accuFire = true;
	minEnergy = 0.01;
	maxEnergy = 0.01;
        reloadTime = 0.05;
        fireTime = 0.05;
        spinUpTime = 0.05;
	
        sfxFire = SoundWPNDisc;
        sfxActivate = SoundPickupWeapon;
        sfxReload = SoundWPNDiscReload;
        sfxReady = SoundWPNDiscIdle;
};
ItemData DiscLauncher
{
        description = "Spinfusor";
        className = "Weapon";
        shapeFile = "wpn_disc";
        hudIcon = "disk";
   heading = "TWeapons";
        shadowDetailMask = 4;
        imageType = DiscLauncherImage;
        price = 0;
          showWeaponBar = true;
	showInventory = true;
   //validateShape = true;
   //validateMaterials = true;
};

//================================================================
echo("Spinfusor Loaded");