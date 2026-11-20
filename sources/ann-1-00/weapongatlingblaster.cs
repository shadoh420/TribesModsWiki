$InvList[GatlingBlaster] = 1;
$MobileInvList[GatlingBlaster] = 1;
$RemoteInvList[GatlingBlaster] = 1;

$AutoUse[GatlingBlaster] = True;
$WeaponAmmo[GatlingBlaster] = "";

addWeapon(GatlingBlaster);

ItemImageData GatlingBlasterImage
{	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 1;
	projectileType = GatlingBlasterBolt;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GatlingBlaster
{	description = "Gatling Blaster";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GatlingBlasterImage;
	price = 500;
	showWeaponBar = true;
};

function GatlingBlaster::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "GatlingBlaster: <f2>Fires charged blaster particles.");
}

