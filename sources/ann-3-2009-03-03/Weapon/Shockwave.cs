$InvList[ShockwaveGun] = 1;
$MobileInvList[ShockwaveGun] = 1;
$RemoteInvList[ShockwaveGun] = 1;

$AutoUse[ShockwaveGun] = false;
$WeaponAmmo[ShockwaveGun] = "";

// addWeapon(ShockwaveGun);

RocketData Shock 
{	
	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.20;	//0.35
	damageType = $MissileDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0;	//350
	muzzleVelocity = 150.0;		//50
	terminalVelocity = 180.0;	//80
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

ItemImageData ShockwaveGunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 40;
	maxEnergy = 25;		//45. thanks perrinoia!
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

function ShockwaveGun::MountExtras(%player,%weapon) 
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Sends a sonic boom!.");
}
