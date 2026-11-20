//================================================================
// Rocket launcher 
//================================================================


SoundData SoundWPNrocketReload
{
   wavFileName = "wpn_rocket_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNrocket
{
   wavFileName = "wpn_rocket.wav";
   profile = Profile3dNear;
};
SoundData RocketLExplosion
{
	wavFilename = "exp_rocket.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizRocket
{
   wavFileName = "whiz_rocket.wav";
   profile = Profile3dMediumLoop;
};


ExplosionData RocketLExp
{
   shapeName = "fiery.dts";
   soundId   = RocketLExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 3.0, 1.0, 1.0 };
   colors[1]  = { 3.0, 2.0, 2.0 };
   colors[2]  = { 3.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
SeekingMissileData RocketONE
{ 
   bulletShapeName = "proj_rocket.dts";
   explosionTag = RocketLExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $MissileDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 100.0;
   
   terminalVelocity = 1000.0;
   acceleration = 50.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "bsmoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
      soundId = Soundwhizrocket;
}; 

SeekingMissileData RocketTWO
{ 
   bulletShapeName = "proj_rocket.dts";
   explosionTag = RocketLExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 0.5;
   damageType = $MissileDamageType;
   explosionRadius = 3;
   kickBackStrength = 0;//200.0;
   
   muzzleVelocity = 75.0;
   
   terminalVelocity = 1000.0;
   acceleration = 100;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   //smokeDist = 1.5;
   
   trailType = 2; 
   trailString = "bsmoke.dts";
   
   //lightRange = 5.0;
   //lightColor = { 1.0, 0.7, 0.5 };
   
   inheritedVelocityScale = 0.76;
   
   soundId = Soundwhizrocket;
}; 

RocketData Rocketalt
{
   bulletShapeName  = "proj_rocket.dts";
   explosionTag     = rocketLExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 850.0;
   terminalVelocity = 1800.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "bsmoke.dts";
   smokeDist   = 1.8;

   soundId = Soundwhizrocket;
};


ItemImageData RocketLauncherImage
{
	shapeFile = "wpn_rocketL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	//projectileType = LiLFFBShell;
	accuFire = false;
	reloadTime = 0.09;
	fireTime = 0;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 1, 0, 0 };

        sfxFire = SoundWPNrocket;
        sfxActivate = SoundPickupWeapon;
        sfxReload = SoundWPNrocketReload;
};

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "wpn_rocketL";
	hudIcon = "plasma";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 50;
	  showWeaponBar = false;
	showinventory = true;
   //validateShape = true;
   validateMaterials = true;
};

function RocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("RocketONE",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("RocketTWO",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("Rocketalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("Rocketalt",%trans,%player,%vel);  
} 


	//=================================================================
echo("Payload Loaded");