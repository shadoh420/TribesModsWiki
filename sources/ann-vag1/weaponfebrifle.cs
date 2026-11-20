$InvList[FEBRifle] = 1;
$MobileInvList[FEBRifle] = 1;
$RemoteInvList[FEBRifle] = 1;

$InvList[FEBRifleAmmo] = 1;
$MobileInvList[FEBRifleAmmo] = 1;
$RemoteInvList[FEBRifleAmmo] = 1;

$AutoUse[FEBRifle] = false;
$SellAmmo[FEBRifleAmmo] = 5;
$WeaponAmmo[FEBRifle] = FEBRifleAmmo;

addWeapon(FEBRifle);
addAmmo(FEBRifle, FEBRifleAmmo, 2);

ItemData FEBRifleAmmo 
{
	description = "FEB Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DartImage
{
	shapeFile = "bullet";
	mountPoint = 0; 
	mountOffset = { 0, 0.6, 0.16 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Dart
{
	description = "Dart";
	className = "Weapon";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	imageType = DartImage;
	showWeaponBar = false;
};


ItemImageData FEBRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	projectileType = FEBBullet;
	ammoType = FEBRifleAmmo;
	accuFire = true;
	fireTime = 1.25;
	reloadTime = 0;
	sfxFire = SoundJetLight;	
	sfxActivate = SoundPickUpWeapon;
};

ItemData FEBRifle 
{
	description = "F.E.B Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FEBRifleImage;
	price = 3500;
	showWeaponBar = true;
};

function FEBRifle::onMount(%player,%item)
{	

    Player::mountItem(%player,Dart,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>F.E.B Rifle: <f2>Inject your foe with some Flesh Eating Bacteria.");
}

function FEBRifle::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}