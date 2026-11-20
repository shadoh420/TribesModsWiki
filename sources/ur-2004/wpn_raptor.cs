//================================================================
// Raptor Rifle 
//================================================================

SoundData SoundFireRaptor
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

SoundData ExplosionRaptor
{
   wavFileName = "laserhit.wav";
   profile = Profile3dNear;
};

//================================================================
LaserData ProjLaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 10.0;
   baseDamageType    = $RaptorDamageType;

   beamTime          = 0.35;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = ExplosionRaptor;
};
//================================================================
ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ProjLaser;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.08;
	minEnergy = 0.05;
	maxEnergy = 0.05;

	lightType = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireRaptor;
	sfxActivate = SoundPickupWeapon;
};

ItemData LaserRifle
{
	description = "Raptor Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};

//=================================================================
echo("Item Loaded");