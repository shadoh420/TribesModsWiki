//================================================================
// Raptor Rifle 
//================================================================

SoundData SoundFireRaptor
{
   wavFileName = "wpn_raptor.wav";
   profile = Profile3dNear;
};

SoundData ExplosionRaptor
{
   wavFileName = "exp_raptor.wav";
   profile = Profile3dNear;
};

//================================================================
LaserData RaptorProj
{
   laserBitmapName   = "raptorpulse.bmp";
   hitName           = "exp_raptor.dts";

   damageConversion  = 10.0;
  // damageValue        = 1.0;
   baseDamageType    = $RlaserDamageType;


   beamTime          = 0.35;

   //lightRange        = 1.0;
   //lightColor        = { 0.0, 1.0, 0.0 };

   detachFromShooter = false;
   hitSoundId        = ExplosionRaptor;
};
//================================================================
ItemImageData LaserRifleImage
{
	shapeFile = "wpn_raptor";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = RaptorProj;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.01;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 1;
	//lightTime = 1;
	//lightColor = { 0, 1, 0 };

	sfxFire = SoundFireRaptor;
	sfxActivate = SoundPickupWeapon;
};

ItemData LaserRifle
{
	description = "Raptor Rifle";
	className = "Weapon";
	shapeFile = "wpn_raptor";
	hudIcon = "sniper";
   	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 0;
	  showWeaponBar = false;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};



//=================================================================
echo("Item Loaded");