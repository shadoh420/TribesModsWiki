$InvList[WaveGun] = 1;
$MobileInvList[WaveGun] = 1;
$RemoteInvList[WaveGun] = 1;

$AutoUse[WaveGun] = True;
$WeaponAmmo[WaveGun] = "";

addWeapon(WaveGun);

ItemImageData WaveGunImage 
{	shapeFile = "shotgun";
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

ItemData WaveGun 
{	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = WaveGunImage;
	price = 250;
	showWeaponBar = true;
};

function WaveGun::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Shockwave Cannon: <f2>Sends a sonic boom!.");
}
