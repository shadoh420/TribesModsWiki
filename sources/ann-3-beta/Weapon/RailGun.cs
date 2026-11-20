$InvList[Railgun] = 1;
$MobileInvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$InvList[RailAmmo] = 1;
$MobileInvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$AutoUse[Railgun] = false;
$SellAmmo[RailAmmo] = 10;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

RocketData RailRound
{	
	bulletShapeName = "tracer.dts";	//bullet.dts";	plasmatic 2.2
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.80;	//0.75
	damageType = $SniperDamageType;		//adjusted this some when I fixed head shot damage -plasmatic
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};


ItemData RailAmmo 
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 75;
};
MineData RailAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};

ItemImageData RailgunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;	
	accuFire = true;
	ammoType = RailAmmo;
	reloadTime = 0.05;
	fireTime = 1.75;	
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData Railgun2Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;	
	mountOffset = { 0, -0.2, 0 };
	mountRotation = { 0.005, 0, 0 };
	weaponType = 0;
	projectileType = RailRound;
	accuFire = true;
};

ItemData Railgun2
{
	description = "Railgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Railgun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

RocketData oldBurningOzone
{	
	bulletShapeName = "breath.dts";	//rsmoke.dts";	//fusionex.dts";	//fusionbolt.dts";
	explosionTag = PhaseDisrupterExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.0;
	DamageType = $MissileDamageType;
	explosionRadius = 25.0;
	kickBackStrength = 450.0;
	muzzleVelocity = 10.0;
	terminalVelocity = 10.0;
	acceleration = 5.0;
	totalTime = 0.5;
	liveTime = 0.5;
	lightRange = 10.0;
	lightColor = { 1.0, 6.7, 9.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";	//fusionex.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};


ExplosionData BurningOzoneExp
{
	shapeName = "flash_small.dts";
	//soundId = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

GrenadeData BurningOzone
{	
	bulletShapeName = "flash_small.dts";	//enbolt.dts";	//bullet
	explosionTag = BurningOzoneExp;	//SpentShellExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.01;
	elasticity = 0.15;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 3;
	totalTime = 0.15;
	liveTime = 0.15;	//after collision
	projSpecialTime = 0.0015;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName = "rsmoke.dts";	//breath.dts";	//rsmoke
	smokeDist = 0.001;	//1.5;
};
ItemImageData Ejectorimage
{
	shapeFile = "force";
	mountPoint = 0;
	accuFire = false;
	mountOffset = { 0.05, 0.3, 0.025 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.5,-1.57, -1.57 };	//0.5,-1.57, -1.57	
//	mountOffset = { 0, 0.34, -0.01 };
//	mountRotation = {0.5,-1.57, -1.57 };
	weaponType = 0;
	projectileType = BurningOzone;	//SpentShell;
	maxEnergy = 0;	//energy/sec
	fireTime = 0.0;
};

ItemData Ejector 
{
	description = "Ejector";
	className = "Weapon";
	shapeFile = "force";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Ejectorimage;
	price = 375;
	showWeaponBar = true;
};
function RailgunImage::onFire(%player, %slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Railgun]);
	if(!%AmmoCount)return;
	
	Player::decItemCount(%player,$WeaponAmmo[Railgun],1);
		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		
	
	Player::trigger(%player, 4, true);
	schedule("Player::trigger("@%player@", 4, false);",0.1);
	%energy = GameBase::getEnergy(%player);
	gamebase::setenergy(%player,%energy -20);
		
	Player::trigger(%player, 6, true);
	schedule("Player::trigger("@%player@", 6, false);",0.1);
	
	//Weapon::MissPercentage(%player);
}

//Plasmatic 2.2
function Railgun::MountExtras(%player,%weapon)
{		
	Player::mountItem(%player,Railgun2,4);
	Player::mountItem(%player,Ejector,6);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>The ultimate sniper weapon.");
}

