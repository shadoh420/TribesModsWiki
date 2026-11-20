
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332

$InvList[Disclauncher] = 1;
$MobileInvList[Disclauncher] = 1;
$RemoteInvList[Disclauncher] = 1;

$InvList[DiscAmmo] = 1;
$MobileInvList[DiscAmmo] = 1;
$RemoteInvList[DiscAmmo] = 1;

$SellAmmo[DiscAmmo] = 5;
$WeaponAmmo[DiscLauncher] = DiscAmmo;

addWeapon(DiscLauncher);
addAmmo(DiscLauncher, DiscAmmo, 2);
$oundReload[DiscLauncherImage] = SoundDiscReload;

RocketData DiscShell
{
	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;		 // 0 impact, 1, radius
	damageValue = 0.4;	//0.5;
	damageType  = $ExplosionDamageType;
	explosionRadius  = 7.5;
	kickBackStrength = 150.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.5;
	liveTime = 8.0;
	lightRange  = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType	= 1;
	trailLength = 15;
	trailWidth  = 0.3;
	soundId = SoundDiscSpin;
};

ItemData DiscAmmo 
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};
MineData DiscAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};
ItemImageData DiscLauncherAImage 
{
	shapeFile = "disc";
	mountPoint = 0;
	weaponType = 0;	//3
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.0;	//0.75;
	spinUpTime = 0.0;	//0.25;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherA 
{
	description = "Spinfusor";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherAImage;
	price = 150;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData DiscLauncherImage
{
	shapeFile = "Force";
	mountPoint = 0;
	weaponType = 0;
	ammoType = DiscAmmo;
	mountOffset = { 0.0, -0.095, 0.1};		// 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.0, -1.57, 0.0};		// ?, around gun barrel, ?
	accuFire = true;
	
	reloadTime = 0.01;	//0.1
	fireTime = 0.01;	//0.25;
	
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
};

ItemData DiscLauncher
{
	description = "Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 175;
	showWeaponBar = true;
};
function Disclauncher::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,DiscLauncherA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Fires spinning blades that explode upon impact.");
}

//-------------------------------------------------------------------------------	
function DisclauncherImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%client = Player::getClient(%player);

	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
//		messageall(1,"fire disk "@Player::getItemState(%client,$SpareSlot1));
		Player::trigger(%player, $SpareSlot1,true);
		%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
		schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.01);
		Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),0.95);
	}
}