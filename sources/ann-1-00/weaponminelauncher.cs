$InvList[MineLauncher] = 1;
$MobileInvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MinelAmmo] = 1;
$MobileInvList[MinelAmmo] = 1;
$RemoteInvList[MinelAmmo] = 1;

$SellAmmo[MinelAmmo] = 5;
$WeaponAmmo[MineLauncher] = MinelAmmo;

addWeapon(MineLauncher);
addAmmo(MineLauncher, MinelAmmo, 2);

$AutoUse[MineLauncher] = True;

ItemData MinelAmmo
{	description = "Mine Launcher Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MinelAmmo;
	projectileType = MineShell; 
	accuFire = false;
	reloadTime = 1.4;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MineLauncher
{	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 175;
	showWeaponBar = true;
};

function MineLauncher::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Mine Launcher: <f2>Fires a cluster of mines for the unsuspecting person to walk over. Watchout! Anyone will trigger them.");
}