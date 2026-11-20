//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Rocket);
$InvList[Rocket] = 1;
$InvList[RocketAmmo] = 1;

$SellAmmo[RocketAmmo] = 10;
$AutoUse[Rocket] = True;
$WeaponAmmo[Rocket] = RocketAmmo;

$ItemMax[larmor, Rocket] = 0;		//Seraph
$ItemMax[lfemale, Rocket] = 0;		//Seraph
$ItemMax[earmor, Rocket] = 1;		//Slave
$ItemMax[efemale, Rocket] = 1;		//Slave
$ItemMax[marmor, Rocket] = 1;		//Pawn
$ItemMax[aarmor, Rocket] = 0;		//Navigator
$ItemMax[darmor, Rocket] = 1;		//Atomizer
$ItemMax[barmor, Rocket] = 0;		//Paladin

$ItemMax[larmor, RocketAmmo] = 0;	//Seraph
$ItemMax[lfemale, RocketAmmo] = 0;	//Seraph
$ItemMax[earmor, RocketAmmo] = 10;	//Slave
$ItemMax[efemale, RocketAmmo] = 10;	//Slave
$ItemMax[marmor, RocketAmmo] = 10;	//Pawn
$ItemMax[aarmor, RocketAmmo] = 0;	//Navigator
$ItemMax[darmor, RocketAmmo] = 20;	//Atomizer
$ItemMax[barmor, RocketAmmo] = 20;	//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData RocketAmmo
{
	description = "Rockets";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData RocketImage 
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RocketAmmo;
	projectileType = BasicRocket;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;//SoundFireFlierRocket
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Rocket
{	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 77;
	showWeaponBar = true;
};


function Rocket::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "<jc><f2>Rocket Launcher");
}