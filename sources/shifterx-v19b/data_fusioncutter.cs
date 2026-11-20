LightningData FusionCutterBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $PlasmaDamageType;
   boltLength       = 6.0;
   coneAngle        = 30.0;
   damagePerSec      = 0.8;
   energyDrainPerSec = 0.0;
   segmentDivisions = 2;
   numSegments      = 3;
   beamWidth        = 0.5;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.0, 0, 0 };

   soundId = SoundJetHeavy;
};


ItemImageData FusionCutterImage
{
	shapeFile = "bullet";
	mountPoint = 0;
	mountOffset = { 0, -0.33, -0.1 };
			// Left/right
			    // Into the arm
				  // Down towards feet

	weaponType = 2;  // Sustained
	projectileType = FusionCutterBeam;
	
	minEnergy = 6;
	maxEnergy = 15;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1.0, 0, 0 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemImageData FusionCutterImageFake
{
	shapeFile = "rocket";
	mountPoint = 0;
	mountRotation = { 3.14, 0, 0 };
	mountOffset = { 0, -0.33, -0.1 };
			// Left/right
			    // Into the arm
				  // Down towards feet

	weaponType = 2;  // Sustained
//	projectileType = FusionCutterBeam;
	
	minEnergy = 5;
	maxEnergy = 14;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1.0, 0, 0 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData FusionCutterGun
{
	description = "Fusion Cutter";
	shapeFile = "rocket";
	hudIcon = "energyRifle";
	className = "Weapon";		//=== Weapon
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FusionCutterImage;
	showWeaponBar = true;
	price = 550;
};

ItemData FusionCutterGunFake
{
	description = "Fusion Cutter Particle Stream";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Weapon";		//=== Weapon
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FusionCutterImageFake;
	showWeaponBar = false;
	price = 0;
};

exec("weapon_fusioncutter.cs");