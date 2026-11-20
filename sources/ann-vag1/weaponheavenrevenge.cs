$InvList[HeavenRevenge] = 1;
$MobileInvList[HeavenRevenge] = 1;
$RemoteInvList[HeavenRevenge] = 1;

$AutoUse[HeavenRevenge] = false;

$WeaponAmmo[HeavenRevenge] = "";

addWeapon(HeavenRevenge);




ItemImageData HeavenRevengeImage 
{
	shapeFile = "grenadel";
	mountPoint = 0;
	weaponType = 0;
	mountOffset = { 0.0, 0.0, -0.1 };
	mountRotation = { 0, 0, 0 };	
	projectileType = HeavenRevengeRocket;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.2;
	minEnergy = 5;
	maxEnergy = 25;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData HeavenRevenge 
{
	description = "Heavens Revenge";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HeavenRevengeImage;
	price = 375;
	showWeaponBar = true;
};


function HeavenRevenge::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Heavens Revenge: <f2>The angels heavenly rocket.");
}

