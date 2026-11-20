//================================================================
// Railgun
//================================================================

SoundData SoundFireRail
{
   wavFileName = "turretfire1.wav";
   profile = Profile3dNear;
};

SoundData ricochet1
{
   wavFileName = "ricoche1.wav";
   profile     = Profile3dNear;
};

SoundData ricochet2
{
   wavFileName = "ricoche2.wav";
   profile     = Profile3dNear;
};

SoundData ricochet3
{
   wavFileName = "ricoche3.wav";
   profile     = Profile3dNear;
};

//==================================================

ExplosionData RailExp0
 {
 shapeName = "chainspk.dts";
 soundId = ricochet1;
 faceCamera = true;
 randomSpin = true;
 hasLight = false;
 lightRange = 3.0;
 timeZero = 0.100;
 timeOne = 0.900;
 colors[0] = { 3.0, 0.0, 0.0 };
 colors[1] = { 3.0, 0.0, 0.0 };
 colors[2] = { 3.0, 0.0, 0.0 };
 radFactors = { 0.0, 1.0, 0.0 };
 shiftPosition = False; 
};

ExplosionData RailExp1
 {
 shapeName = "chainspk.dts";
 soundId =  ricochet2;
 faceCamera = true;
 randomSpin = true;
 hasLight = false;
 lightRange = 3.0;
 timeZero = 0.100;
 timeOne = 0.900;
 colors[0] = { 3.0, 0.0, 0.0 };
 colors[1] = { 3.0, 0.0, 0.0 };
 colors[2] = { 3.0, 0.0, 0.0 };
 radFactors = { 0.0, 1.0, 0.0 };
 shiftPosition = False; 
};

ExplosionData RailExp2
 {
 shapeName = "chainspk.dts";
 soundId =  ricochet3;
 faceCamera = true;
 randomSpin = true;
 hasLight = false;
 lightRange = 3.0;
 timeZero = 0.100;
 timeOne = 0.900;
 colors[0] = { 3.0, 0.0, 0.0 };
 colors[1] = { 3.0, 0.0, 0.0 };
 colors[2] = { 3.0, 0.0, 0.0 };
 radFactors = { 0.0, 1.0, 0.0 };
 shiftPosition = False; 
};

//================================================================

RocketData ProjRail
{
   bulletShapeName = "breath.dts";
   explosionTag    = RailExp0;
   exprandcycle    = 3;

   collisionRadius = 0;
   mass            = 3;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $RailDamageType;

   explosionRadius  = 1;
   kickBackStrength = 0;

   muzzleVelocity   = 1000;
   terminalVelocity = 1000;
   acceleration     = 100;

   totalTime        = 10;
   liveTime         = 7;

   lightRange       = 1;
   lightColor       = { 0.5, 0.5, 2.0 };

   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.35;

};

//================================================================
ItemData RailAmmo
 {
 	description = "Rail Ammo";
 	className = "Ammo";
 	heading = "xAmmunition";
 	shapeFile = "ammo1";
 	shadowDetailMask = 4;
 	price = 0;
 };
ItemImageData BlasterImage
 {
 	shapeFile = "sniper";
 	mountPoint = 0;
 	weaponType = 0;
 	ammoType = RailAmmo;
 	projectileType = ProjRail;
 	accuFire = true;
 	reloadTime = 0.00;
 	fireTime = 0.1;


 	lightType = 3;
 	lightRadius = 1;
 	lightTime = 2;
 	lightColor = { 1.0, 0.25, 0.25 };
 	sfxFire = SoundFireRail;
 	sfxActivate = SoundPickupWeapon;
 };
ItemData Blaster
 {
 	description = "RailGun";
 	className = "Weapon";
 	shapeFile = "sniper";
 	hudIcon = "sniper";
 	heading = "bWeapons";
 	shadowDetailMask = 4;
 	imageType = BlasterImage;
 	price = 0;
 	showWeaponBar = true;
	showinventory = true;
   	//validateShape = true;
   	//validateMaterials = true;
 };

/////////////////////////////////////////////////////////////////////////////////////////////////////////
echo("Railgun Loaded");
