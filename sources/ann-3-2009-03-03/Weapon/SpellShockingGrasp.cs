$InvList[ShockingGrasp] = 1;
$MobileInvList[ShockingGrasp] = 1;
$RemoteInvList[ShockingGrasp] = 1;

$AutoUse[ShockingGrasp] = False;
$WeaponAmmo[ShockingGrasp] = "";

// addWeapon(ShockingGrasp);

LightningData ShockingGraspBolt
{	bitmapName = "plasmabolt.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 45.0;
	damagePerSec = 0.35;
	energyDrainPerSec = 100.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.3;  //10
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundElfFire;
};
ItemImageData ShockingGraspImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.1, -0.3, -0.1 };
	mountRotation = {0, 1.57, 0};
//	mountRotation = { -1.5, 0, 0 };
//	mountRotation = { 0, 1.57, 1.57 };
	weaponType = 2; // Sustained
	projectileType = ShockingGraspBolt;
	minEnergy = 3;
	maxEnergy = 8; // Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxReady = SoundJammerOn;
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};
ItemData ShockingGrasp
{
	className = "Weapon";
	description = "Spell: Shocking Grasp";
	shapeFile = "mrtwig";
//	shapeFile = "paintgun";
	shadowDetailMask = 4;
	heading = $InvHead[ihSpl];
	hudIcon = "mrtwig";
	imageType = ShockingGraspImage;
	showWeaponBar = true;
	showInventory = true;
	price = 2000;
};


ItemImageData ShockingGrasp2Image
{
	shapeFile = "mrtwig";
//	mountPoint = 2;
//	mountOffset = { 0.2, 0.4, 0.0 };
//	mountRotation = { -1.57, 0, 0 };

	mountPoint = 0;
	mountOffset = { 0, -0.6, 0 };
	mountRotation = { -1.57 ,0 ,0 };

	weaponType = 2; // Sustained
	projectileType = ShockingGraspBolt;
	minEnergy = 3;
	maxEnergy = 8; // Energy used/sec for sustained weapons
	reloadTime = 0.2;
	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
//	sfxReady = SoundJammerOn;
//	sfxActivate = SoundPickUpWeapon;
//	sfxFire = SoundELFIdle;
	showInventory = false;
};

ItemData ShockingGrasp2
{
	className = "Weapon";
//	description = "Spell: Shocking Grasp";
	heading = $InvHead[ihSpl];
	hudIcon = "mrtwig";
	imageType = ShockingGrasp2Image;
	price = 350;
	shadowDetailMask = 4;
	shapeFile = "mrtwig";
	showWeaponBar = false;
	showInventory = false;
};

function ShockingGrasp::MountExtras(%player,%weapon) 
{	
	Player::mountItem(%player,ShockingGrasp2,4);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>This spell drains a target's energy while inflicting electrical damage rendering shields, jetpacks, and energy weapons useless.");
}
