$InvList[RocketLauncher] = 1;
$MobileInvList[RocketLauncher] = 1;
$RemoteInvList[RocketLauncher] = 1;

$InvList[RocketAmmo] = 1;
$MobileInvList[RocketAmmo] = 1;
$RemoteInvList[RocketAmmo] = 1;

$AutoUse[RocketLauncher] = false;
$SellAmmo[RocketAmmo] = 3;
$WeaponAmmo[RocketLauncher] = RocketAmmo;

addWeapon(RocketLauncher);
addAmmo(RocketLauncher, RocketAmmo, 1);

ItemData RocketAmmo 
{
	description = "Rockets";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	ammoType = RocketAmmo;
	//projectileType = BasicRocket;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData RocketLauncher 
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};


function RocketLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Rocket Launcher: <f2>Your basic Rocket Launcher.");
}

function RocketImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("BasicRocket",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
	ArmApplyKickback(%player, 100, 10);
}