//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(PlasmaGun);
$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;

$SellAmmo[PlasmaAmmo] = 10;
$AutoUse[PlasmaGun] = True;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

$ItemMax[larmor, PlasmaGun] = 1;	//Seraph
$ItemMax[lfemale, PlasmaGun] = 1;	//Seraph
$ItemMax[earmor, PlasmaGun] = 1;	//Slave
$ItemMax[efemale, PlasmaGun] = 1;	//Slave
$ItemMax[marmor, PlasmaGun] = 1;	//Pawn
$ItemMax[aarmor, PlasmaGun] = 1;	//Navigator
$ItemMax[darmor, PlasmaGun] = 0;	//Atomizer
$ItemMax[barmor, PlasmaGun] = 0;	//Paladin

$ItemMax[larmor, PlasmaAmmo] = 20;	//Seraph
$ItemMax[lfemale, PlasmaAmmo] = 20;	//Seraph
$ItemMax[earmor, PlasmaAmmo] = 20;	//Slave
$ItemMax[efemale, PlasmaAmmo] = 20;	//Slave
$ItemMax[marmor, PlasmaAmmo] = 25;	//Pawn
$ItemMax[aarmor, PlasmaAmmo] = 25;	//Navigator
$ItemMax[darmor, PlasmaAmmo] = 40;	//Atomizer
$ItemMax[barmor, PlasmaAmmo] = 30;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData PlasmaGunImage 
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
}; 

ItemData PlasmaGun 
{
	description = "Plasma Blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 77;
	showWeaponBar = true;
};

function PlasmaGun::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Plasma Blaster", 2); }
