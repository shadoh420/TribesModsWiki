$InvList[EnergyBlade] = 1;
$MobileInvList[EnergyBlade] = 1;
$RemoteInvList[EnergyBlade] = 1;

AddItem(EnergyBlade);	// adding this way so doesnt cycle -plasmatic
$AutoUse[EnergyBlade] = False;

//addWeapon(EnergyBlade);	//not in the cycle chain, so
// it's not added, but it could be if you want.


// Targeting Laser is not in the cycle chain, so
// it's not added, but it could be if you want.
// addWeapon(TargetingLaser);
// -Plasmatic

// fooling tribes into mounting this on default target laser use key. -Plasmatic

ExplosionData EnergyBladeCutExp
{
	shapeName = "shotgunex.dts";
	soundId   = energyExplosion;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 3.0;

	timeZero = 0.450;
	timeOne  = 0.750;

	colors[0]  = { 1.0, 0.25, 0.25 };
	colors[1]  = { 1.0, 0.25, 0.25 };
	colors[2]  = { 1.0, 0.25, 0.25 };
	radFactors = { 1.0, 1.0, 1.0 };

	shiftPosition = True;
};
BulletData EnergyBladeCut 
{	
	bulletShapeName = "shotgunex.dts";	//fusionbolt.dts";
	explosionTag = EnergyBladeCutExp;
	damageClass = 0;
	damageValue = 0.025;	//0.07;
	damageType = $ElectricityDamageType;
	aimDeflection = 0.00;	//0.015;
	muzzleVelocity = 7.5;	//10
	totalTime = 0.5;	//0.25;	
	liveTime = 0.5;	//0.25;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 1.0;
	isVisible = True;
	soundId = SoundPlayerDeath;	//SoundJetLight;
};

ItemImageData EnergyBladeAImage 
{
	shapeFile = "bullet";
	accuFire = true;	
	mountOffset = { -0.01, -0.10, -0.1250 };//right, forward, up	//0.1, 0.25, 0.01
	
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.1;
	fireTime = 0.02;
	minEnergy = 0;
	maxEnergy = 0;
	projectileType = EnergyBladeCut;
//	sfxFire = SoundPodReload;	//SoundJetHeavy;
//	sfxActivate = SoundPickUpWeapon;
};
ItemData EnergyBladeA
{
	heading = $InvHead[ihtool];
	description = "Energy Blade";
	className = "EyeCandy";
	shapeFile = "rocket";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = EnergyBladeAImage;
	price = 385;
	showWeaponBar = true;
};
ItemImageData EnergyBladeImage 
{
	shapeFile = "rocket";
	
	mountOffset = { 0.0, -0.5, -0.250 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {3.50, 0.0,  0.0};		//mountRotation = {0.5,-1.57, -1.57 };	//0.5,-1.57, -1.57
	accuFire = true;	
	
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 0.02;
	minEnergy = 6;
	maxEnergy = 7;
//	projectileType = EnergyBladeCut;
	accuFire =true;
	sfxFire = SoundThrowItem;	//SoundPodReload;	//SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnergyBlade 
{
	heading = $InvHead[ihtool];
	description = "Energy Blade";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "rocket";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = EnergyBladeImage;
	price = 385;
	showWeaponBar = true;
};
function EnergyBladeImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	Player::trigger(%player, $WeaponSlot,false);
	if(GameBase::getLOSInfo(%player,3.5)) 	//2.75
	{
		
		Player::trigger(%player, $SpareSlot1,true);
		schedule("Player::trigger("@%player@", 4 ,false);",0.1);	
	}
}
function EnergyBlade::onmount(%player,%weapon)
{	
	Player::mountItem(%player,EnergyBladeA,$SpareSlot1);
	
//	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>energy blade at explode upon impact.");
}
//====================================================

//AddItem(TargetingLaser);
TargetLaserData targetLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 20.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};
ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
	showInventory = false;
};
