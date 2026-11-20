$InvList[Heavensfury] = 1;
$MobileInvList[Heavensfury] = 1;
$RemoteInvList[Heavensfury] = 1;

$AutoUse[Heavensfury] = false;
$WeaponAmmo[Heavensfury] = "";

addWeapon(Heavensfury);

ItemImageData HeavensfuryImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.02;
	fireTime = 0.02;
	minEnergy = 6;
	maxEnergy = 7;
	projectileType = HeavensfuryBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Heavensfury 
{
	heading = $InvHead[ihWea];
	description = "Heaven's Fury";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "weapon";
	shadowDetailMask = 4;
	imageType = HeavensfuryImage;
	price = 385;
	showWeaponBar = true;
};

function Heavensfury::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Heaven's Fury: <f2>The angel's version of a shotgun.");
}