//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Plasmaii);
$InvList[Plasmaii] = 1;

$AutoUse[Plasmaii] = True;
$WeaponAmmo[Plasmaii] = PlasmaAmmo;

$ItemMax[larmor, Plasmaii] = 0;		//Seraph
$ItemMax[lfemale, Plasmaii] = 0;	//Seraph
$ItemMax[earmor, Plasmaii] = 0;		//Slave
$ItemMax[efemale, Plasmaii] = 0;	//Slave
$ItemMax[marmor, Plasmaii] = 0;		//Pawn
$ItemMax[aarmor, Plasmaii] = 0;		//Navigator
$ItemMax[darmor, Plasmaii] = 1;		//Atomizer
$ItemMax[barmor, Plasmaii] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData blasteriImage
{
	shapeFile = "shotgun";//energygun
	mountPoint = 0;
	mountOffset = { -0.11, -0.05, -0.05 };  
	mountRotation = { 0, -2.0, 0 };
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaiiBolt;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemImageData blasteriiImage
{
	shapeFile = "shotgun";//energygun
	mountPoint = 0;
	mountOffset = { 0.11, -0.05, -0.05 };
	mountRotation = { 0, 2.0, 0};
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaiiBolt;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemImageData blasteriiiImage
{
	shapeFile = "shotgun";//shotgun
	mountPoint = 0;
	mountOffset = { 0, 0.05, 0.055 };
	mountRotation = { 0,  0, 3.1416};

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaiiBolt;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

	
ItemImageData PlasmaiiImage
{
	shapeFile = "shotgun";//plasma
	mountPoint = 0;
	mountOffset = { 0, -0.25, -0.065 };
	mountRotation = { 0,  3.1416, 0}; //3.1416
	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaiiBolt;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;// FireMortar SoundMissileTurretFire
	sfxActivate = SoundPickUpWeapon;
	//sfxReady = SoundMortarIdle; 
	sfxReload = SoundDryFire;
};


ItemData blasteri
{
	description = "left hand blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};

ItemData blasterii
{
	description = "right hand blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriiImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};

ItemData blasteriii
{
	description = "bottom blaster";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = blasteriiiImage;
	price = 1;
	showWeaponBar = false;
	showinventory = false;
   validateShape = true;
};


ItemData Plasmaii
{
	description = "Plasma Blaster MKII";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaiiImage;
	price = 777;
	showWeaponBar = true;
   	validateShape = true;
};

$PlasmaiiSlotA=4;
$PlasmaiiSlotB=7;
$PlasmaiiSlotC=6;

function Plasmaii::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Plasma Blaster MKII");

	Player::mountItem(%player,blasteri,$PlasmaiiSlotA); 
	Player::mountItem(%player,blasterii,$PlasmaiiSlotB);
	Player::mountItem(%player,blasteriii,$PlasmaiiSlotC);

}

function Plasmaii::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$PlasmaiiSlotA); 
	Player::unmountItem(%player,$PlasmaiiSlotB); 
	Player::unmountItem(%player,$PlasmaiiSlotC); 
}