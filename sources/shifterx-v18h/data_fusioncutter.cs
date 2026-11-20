LightningData FusionCutterBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $PlasmaDamageType;
   boltLength       = 7.0;
   coneAngle        = 35.0;
   damagePerSec      = 1.1;
   energyDrainPerSec = 1.9;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.1;

   updateTime   = 100;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1, 0, 0 };

   soundId = SoundJetHeavy;
};


ItemImageData FusionCutterImage
{
	shapeFile = "rocket";
	mountPoint = 0;
	mountRotation = { 3.14, 0, 0 };
	mountOffset = { 0, -0.33, -0.1 };
			// Left/right
			    // Into the arm
				  // Down towards feet

	weaponType = 2;  // Sustained
	projectileType = FusionCutterBeam;
	
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
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
	className = "Tool";		//=== Weapon
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FusionCutterImage;
	showWeaponBar = true;
	price = 550;
};

exec("tool_fusioncutter.cs");