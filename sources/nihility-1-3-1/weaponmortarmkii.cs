//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Mortarr);
$InvList[Mortarr] = 1;

$AutoUse[Mortarr] = True;
$WeaponAmmo[Mortarr] = MortarAmmo;

$ItemMax[larmor, Mortarr] = 0;		//Seraph
$ItemMax[lfemale, Mortarr] = 0;		//Seraph
$ItemMax[earmor, Mortarr] = 0;		//Slave
$ItemMax[efemale, Mortarr] = 0;		//Slave
$ItemMax[marmor, Mortarr] = 0;		//Pawn
$ItemMax[aarmor, Mortarr] = 0;		//Navigator
$ItemMax[darmor, Mortarr] = 0;		//Atomizer
$ItemMax[barmor, Mortarr] = 1;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData MortarrImage 
{
	shapeFile = "mortargun";
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0 , -0.2, 0.5 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShellBlue;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemImageData MortarrImage2 
{
	shapeFile = "mortargun";
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0 , -0.6, 0.5 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemImageData MortarrImage3 
{
	shapeFile = "shotgun";
	mountRotation = { 0, -0.925, 0 }; // 1.57  .785
	mountOffset = { -0.15 , -0.75, 0.72 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemImageData MortarrImage4 
{
	shapeFile = "shotgun";
	mountRotation = { 0, -2.229, 0 }; // 1.57  .785
	mountOffset = { -0.15 , -0.75, 0.48 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 


ItemData Mortarr 
{
	description = "Mortar MKII";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarrImage;
	price = 77;
	showWeaponBar = true;
};

ItemData Mortar2 
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarrImage2;
	price = 77;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Mortarr3 
{
	description = "Mortar*";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarrImage3;
	price = 77;
	showWeaponBar = true;
};

ItemData Mortarr4 
{
	description = "Mortar*";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarrImage4;
	price = 77;
	showWeaponBar = true;
};

$MortarrSlotA=4;
$MortarrSlotB=7;
$MortarrSlotC=6;

function Mortarr::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Mortar MKII");

	Player::mountItem(%player,Mortarr2,$MortarrSlotA); 
	Player::mountItem(%player,Mortarr3,$MortarrSlotB);
	Player::mountItem(%player,Mortarr4,$MortarrSlotC);
}

function Mortarr::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$MortarrSlotA); 
	Player::unmountItem(%player,$MortarrSlotB); 
	Player::unmountItem(%player,$MortarrSlotC); 
}