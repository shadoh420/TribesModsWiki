//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Gatling);
$InvList[Gatling] = 1;

$AutoUse[Gatling] = True;
$WeaponAmmo[Gatling] = "";

$ItemMax[larmor, Gatling] = 0;		//Seraph
$ItemMax[lfemale, Gatling] = 0;		//Seraph
$ItemMax[earmor, Gatling] = 0;		//Slave
$ItemMax[efemale, Gatling] = 0;		//Slave
$ItemMax[marmor, Gatling] = 0;		//Pawn
$ItemMax[aarmor, Gatling] = 1;		//Navigator
$ItemMax[darmor, Gatling] = 0;		//Atomizer
$ItemMax[barmor, Gatling] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

LaserData GatlingLaserBeam
{
   laserBitmapName   = "paintpulse.bmp"; //snowplume04   paintpulse
   hitName           = "paint.dts"; //laserhit   paint

   damageConversion  = 0.045;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 5.0;
   lightColor = { 0.25, 1.0, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};
 

ItemImageData GatlingImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0 , 0, 0 };
	weaponType = 0; // Spinning
	minEnergy = 1.6;
	maxEnergy = 1.6;
	projectileType = GatlingLaserBeam;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 1.0, 0.25 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage2 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	mountOffset = { 0 , 0, -0.05 };
	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = GatlingLaserBeam;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage3 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	mountOffset = { 0.035 , 0, 0 };
	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = GatlingLaserBeam;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemImageData GatlingImage4 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, -0.785, 0 };
	mountOffset = { -0.035 , 0, 0 };
	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = GatlingLaserBeam;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gatling 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage;
	price = 77;
	showWeaponBar = true;
};

ItemData Gatling2 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage2;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Gatling3 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage3;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Gatling4 
{
	description = "Laser Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chaingun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatlingImage4;
	price = 77;
	showWeaponBar = false;
	showInventory = false;
};


$GatlingSlotA=4;
$GatlingSlotB=7;
$GatlingSlotC=6;



function Gatling::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
	bottomprint(%client, "<jc><f2>Laser Gatling Gun");

	Player::mountItem(%player,Gatling2,$GatlingSlotA); 
	Player::mountItem(%player,Gatling3,$GatlingSlotB);
	Player::mountItem(%player,Gatling4,$GatlingSlotC);

}

function Gatling::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$GatlingSlotA); 
	Player::unmountItem(%player,$GatlingSlotB); 
	Player::unmountItem(%player,$GatlingSlotC); 
}


//function Gatling::onUse(%player,%item)
//{
//Weapon::onUse(%player,%item);
//bottomprint(Player::getClient(%player), "<jc><f2>Laser Gatling Gun", 2);
//}