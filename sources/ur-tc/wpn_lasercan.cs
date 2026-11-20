//================================================================
//Laser Cannon
//================================================================
//================================================================


//================================================================

//================================================================
SoundData SoundWPNLaser
{
   wavFileName = "wpn_Laser.wav";
   profile = Profile3dNear;
};
SoundData laserExplosion
{
	wavFilename = "exp_laser.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizLaser
{
   wavFileName = "whiz_laser.wav";
   profile = Profile3dNearLoop;
};
//================================================================
ExplosionData LaserCanExp
{
   shapeName = "exp_laser.dts";
   soundId   = laserExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 2;

   timeZero = 0.250;
   timeOne  = 0.650;
	
//                red, grn, blu
   colors[0]  = { 0.0, 3.0, 0.0 };
   colors[1]  = { 0.0, 3.0, 0.0 };
   colors[2]  = { 0.0, 3.0, 0.0 };
   radFactors = { 1.0, 1.0, 1.0 };
 };
//================================================================
RocketData Laserproj
{
   bulletShapeName = "proj_laser.dts";
   explosionTag    = LaserCanExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;    // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $LascanDamageType;
   explosionRadius  = 6.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 40.0;

   totalTime        = 5.0;
   liveTime         = 4.0;
   lightRange        = 3.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   isVisible          = True;
   inheritedVelocityScale = 1.0;
   soundId = SoundWhizLaser;
 };
//================================================================


ItemImageData LasercanImage
{
        shapeFile  = "wpn_lasercan";
        mountPoint = 0;
        	
        weaponType = 0; // Single Shot
        reloadTime = 0.01;
        fireTime = 0.09;
	minEnergy = 0.01;
	maxEnergy = 0.01;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 2;
 	 //lightColor        = { 0.25, 1.0, 0.25 };
	
	  //ammoType = LaserAmmo;
        projectileType = Laserproj;
        accuFire = true;

        sfxFire = SoundWPNLaser;
        sfxActivate = SoundPickUpWeapon;
};

ItemData Lasercan
{
        heading = "TWeapons";
        description = "Laser Cannon";
        className = "Weapon";
        shapeFile  = "wpn_lasercan";
        hudIcon = "sniper";
        shadowDetailMask = 4;
        imageType = LasercanImage;
        price = 0;
          showWeaponBar = false;
   //validateShape = true;
   //validateMaterials = true;
};
//================================================================
//echo("Laser Loaded");