$InvList[DeathRay] = 1;
$MobileInvList[DeathRay] = 1;
$RemoteInvList[DeathRay] = 1;

$AutoUse[DeathRay] = True;
$WeaponAmmo[DeathRay] = "";

addWeapon(DeathRay);

ItemImageData DeathRayImage
{
	shapeFile = "fusionbolt";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.40;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 20;
	projectileType = DeathRayLaser;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DeathRay 
{
	heading = $InvHead[ihSpl];
	description = "Spell: Death Ray";
	className = "Weapon";
	shapeFile = "fusionbolt";
	hudIcon = "targetlaser";
	shadowDetailMask = 4;
	imageType = DeathRayImage;
	price = 250;
	showWeaponBar = true;
};

function DeathRay::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Death Ray: <f2>This spell fires a bolt of negative energy towards your target.");
}