//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Sten);
$InvList[Sten] = 1;

$AutoUse[Sten] = True;
$WeaponAmmo[Sten] = "";

$ItemMax[larmor, Sten] = 0;		//Seraph
$ItemMax[lfemale, Sten] = 0;		//Seraph
$ItemMax[earmor, Sten] = 0;		//Slave
$ItemMax[efemale, Sten] = 0;		//Slave
$ItemMax[marmor, Sten] = 0;		//Pawn
$ItemMax[aarmor, Sten] = 1;		//Navigator
$ItemMax[darmor, Sten] = 0;		//Atomizer
$ItemMax[barmor, Sten] = 0;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData StenImage
{
shapeFile = "shotgun";

   mountRotation = { 0, -3.14, 0 };
   mountOffset = { 0, 0, 0.04 };
   
   mountPoint = 0;
   weaponType = 0;  // Single
   //projectileType = StenCharge;
   minEnergy = 5;
   maxEnergy = 8;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireBlaster;
   //sfxFire     = SoundELFIdle;
};

ItemData Sten
{
   description = "Energy Shotgun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = StenImage;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemImageData Sten2Image
{
shapeFile = "ammopack";
mountRotation = { -1.57 , 0 , 3.14 };
mountOffset = { 0 , 0.1 , 0.0 };
   mountPoint = 0;
   weaponType = 0;  // Single
   //projectileType = StenCharge;
   minEnergy = 5;
   maxEnergy = 8;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireBlaster;
   //sfxFire     = SoundELFIdle;
};

ItemData Sten2
{
   description = "Energy Shotgun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Sten2Image;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

function StenImage::onFire(%player, %slot) 
{
	%playerId = Player::getClient(%player);
 	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);			

}

$StenSlotA=4;


function Sten::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Energy Shotgun");

	Player::mountItem(%player,sten2,$StenSlotA); 

}

function Sten::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$StenSlotA); 

}

