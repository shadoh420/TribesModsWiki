$InvList[SniperRifle] = 1;
$MobileInvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;

$InvList[SniperAmmo] = 1;
$MobileInvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

$AutoUse[SniperRifle] = false;
$SellAmmo[SniperAmmo] = 5;
$WeaponAmmo[SniperRifle] = SniperAmmo;

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 2);

ItemData SniperAmmo 
{
	description = "Sniper Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData Scope1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Scope1
{
	description = "Scope1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Scope1Image;
	showWeaponBar = false;
};


ItemImageData SniperRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	projectileType = SniperBullet;
	ammoType = SniperAmmo;
	accuFire = true;
	fireTime = 1.50;
	reloadTime = 0;
	sfxFire = debrisSmallExplosion;	//ricochet1; // SoundFireSniper
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 4500;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item)
{	

    Player::mountItem(%player,Scope1,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>SniperRifle: <f2>If mastered noone is safe from a bullet to the head.");
}

function SniperRifle::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}