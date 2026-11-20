//================================================================
//Flamer
//================================================================



//================================================================
SoundData flameExplosion
{
   wavFileName = "exp_flame.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNFlamer
{
   wavFileName = "wpn_flamer.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWPNFlamerIdle
{
   wavFileName = "wpn_flamer_idle.wav";
   profile = Profile3dNearLoop;
};
SoundData SoundWPNFlamerLoad
{
   wavFileName = "wpn_flamer_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWhizFlamer
{
   wavFileName = "whiz_flame.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData FlamerExp
{
   shapeName = "fiery.dts";
   soundId   = flameExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 3.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};
//================================================================

RocketData Flamerproj
{
   bulletShapeName  = "breath.dts";
   explosionTag     = FlamerExp;
   collisionRadius  = 0.0;
   mass             = 0.3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $FlamerDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 5.0;
   muzzleVelocity   = 35.0;
   terminalVelocity = 40.0;
   acceleration     = 3.0;
   totalTime        = 2.0;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 3.0, 2.0, 0.0 };
   
   inheritedVelocityScale = 0.3;

   trailType   = 2;
   trailString = "plastrail.dts";
   smokeDist   = 0.35;

   soundId = SoundWhizFlamer;
};
//================================================================

ItemImageData FlamerImage
 {
 shapeFile = "wpn_flamer";
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0.0;
 fireTime = 0.05;
	minEnergy = 0.01;
	maxEnergy = 0.01;
 projectileType = Flamerproj;
 //ammoType = FlamerAmmo;
 accuFire = false;
 sfxFire = SoundWPNFlamer;
 sfxActivate = SoundWPNFlamerLoad;
 sfxReady = SoundWPNFlamerIdle;
};
ItemData Flamer
{
	description = "Flame Thrower";
	className = "Weapon";
	shapeFile = "wpn_flamer";
	hudIcon = "plasma";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 50;
	  showWeaponBar = false;
showInventory = true;
   //validateShape = true;
   validateMaterials = true;
};
//================================================================
