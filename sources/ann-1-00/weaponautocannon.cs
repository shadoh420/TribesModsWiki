$InvList[ATC] = 1;
$MobileInvList[ATC] = 1;
$RemoteInvList[ATC] = 1;

$InvList[ATCAmmo] = 1;
$MobileInvList[ATCAmmo] = 1;
$RemoteInvList[ATCAmmo] = 1;

$SellAmmo[ATCAmmo] = 100;
$AmmoPackMax[ATCAmmo] = 100;

addWeapon(ATC);
addAmmo(ATC, ATCAmmo, 50);

ItemData ATCAmmo
{	description = "Cannon Shells";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ATCImage
{	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 6;
	fireTime = 0.2;
	ammoType = ATCAmmo;
	projectileType = MiniMissile;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData ATC
{	description = "Auto-Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ATCImage;
	price = 1500;
	showWeaponBar = true;
};

function ATC::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "Auto Cannon: <f2>Similar to a Vulcan but instead this baby fires miniture missiles.");
}