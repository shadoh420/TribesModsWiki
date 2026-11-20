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

RocketData SniperBullet
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.80;
	damageType = $LaserDamageType;		//adjusted this some when I fixed head shot damage -plasmatic
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;
	terminalVelocity = 3500.0;
	acceleration = 500.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.8;
	soundId = SoundJetHeavy;
};

ItemData SniperAmmo 
{
	description = "Sniper Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};
MineData SniperAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};

ItemImageData SniperRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	//mountRotation = { 0,-1.57, 0 };
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

function SniperRifle::MountExtras(%player,%weapon)
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Sniper weapon, Elephant gun, whatever..");
}