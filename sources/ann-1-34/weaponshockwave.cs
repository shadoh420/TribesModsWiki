$InvList[ShockwaveGun] = 1;
$MobileInvList[ShockwaveGun] = 1;
$RemoteInvList[ShockwaveGun] = 1;

$AutoUse[ShockwaveGun] = True;
$WeaponAmmo[ShockwaveGun] = "";

addWeapon(ShockwaveGun);

ItemImageData ShockwaveGunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 40;
	maxEnergy = 45;
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockwaveGun 
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "clock";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShockwaveGunImage;
	price = 250;
	showWeaponBar = true;
};

function ShockwaveGun::onMount(%player,%item) 
{
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "Shockwave Cannon: <f2>Sends a sonic boom!.");
}
