$InvList[HDiscLauncher] = 1;
$MobileInvList[HDiscLauncher] = 1;
$RemoteInvList[HDiscLauncher] = 1;

$InvList[HDiscLauncherAmmo] = 1;
$MobileInvList[HDiscLauncherAmmo] = 1;
$RemoteInvList[HDiscLauncherAmmo] = 1;

$AutoUse[HDiscLauncher] = false;
$WeaponAmmo[HDiscLauncher] = HDiscLauncherAmmo; 
$SellAmmo[HDiscLauncherAmmo] = 5;


addWeapon(HDiscLauncher);
addAmmo(HDiscLauncher,HDiscLauncherAmmo,20);


RocketData HyperDiscShell
{	
	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.37;
	damageType = $ExplosionDamageType;
	explosionRadius = 6;
	kickBackStrength = 110.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 90.0;
	acceleration = 5.0;
	totalTime = 6.5;
	liveTime = 8.0;
	lightRange = 5.0;
	lightColor = { 0, 1.0, 0 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailLength = 28;
	trailWidth = 0.3;
	soundId = SoundDiscSpin;
};


ItemData HDiscLauncherAmmo
{
	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
}; 

MineData HDiscLauncherAmmoBomb
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
ItemData HDiscLauncher1Ammo
{
	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
}; 
ItemData HDiscLauncher2Ammo
{
	description = "Hyper Disc";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
}; 


ItemImageData HDiscLauncher1Image 
{
	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };
	ammoType = HDiscLauncher1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = HyperDiscShell;
};

ItemData HDiscLauncher1
{
	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncher2Image
{
	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,1.57, 0 };
	ammoType = HDiscLauncher2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = HyperDiscShell;
};

ItemData HDiscLauncher2
{
	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncherImage
{
	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = HDiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	// sfxReady = SoundSpinIdle;
};

ItemData HDiscLauncher 
{
	description = "Hyper Spinfusor";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function HDiscLauncherImage::onFire(%player, %slot)
{ 		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if(%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
	{
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "HDiscLauncherAmmo", 1);
		%num = Player::getItemCount(%player, "HDiscLauncherAmmo");
		if(%client.hd == 0)
		{
			%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "HDiscLauncher1Ammo", 0);
			else 
				Player::setItemCount(%player, "HDiscLauncher1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{
			%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "HDiscLauncher2Ammo", 0);
 			else
				Player::setItemCount(%player, "HDiscLauncher2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	}
}

//Plasmatic 2.2
function HDiscLauncher::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,HDiscLauncher1,6);
 	Player::mountItem(%player,HDiscLauncher2,7);
 	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>This dual barreled disc launcher can unload a score of deadly spinning blades in seconds.");
}
