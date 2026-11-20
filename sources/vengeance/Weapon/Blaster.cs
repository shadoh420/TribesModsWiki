
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332

$InvList[BlasterGun] = 1;
$MobileInvList[BlasterGun] = 1;
$RemoteInvList[BlasterGun] = 1;

$AutoUse[BlasterGun] = false;
$WeaponAmmo[BlasterGun] = "";

addWeapon(BlasterGun);

BulletData BlasterBolt
{
	bulletShapeName    = "shotgunbolt.dts";
	explosionTag       = blasterExp;

	damageClass        = 0;
	damageValue        = 0.05;	// 0.125;	//plasmatic
	damageType         = $BlasterDamageType;

	muzzleVelocity     = 200.0;
	totalTime          = 2.0;
	liveTime           = 1.125;
	aimDeflection = 0.02;	//plasmatic
	lightRange         = 3.0;
	lightColor         = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible          = True;
	tracerPercentage = 1.0;	//1.0	//plasmatic

	rotationPeriod = 0.01;
};

//----------------------------------------------------------------------------

ItemImageData BlasterGunAImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.01;	//0.3;
	minEnergy = 5;
	maxEnergy = 6;

//	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BlasterGunA
{
  	heading = $InvHead[ihWea];
	description = "Blaster";
	className = "EyeCandy";	//className = "Weapon";
   	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterGunAImage;
	price = 85;
	showWeaponBar = true;
};


function BlasterGunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
		Player::trigger(%player, $SpareSlot1,true);
		%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
		schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.01);
		Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),0.3);
				
		%vel = Item::getVelocity(%player);
		
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%trans = GameBase::getMuzzleTransform(%player);	
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
			%energy = GameBase::getEnergy(%player);
			gamebase::setenergy(%player,%energy -20);	
		}
		else 	
			echo("!! Butterfly Error, Blaster. vel ="@%vel);					

	}	
}
//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData BlasterGunImage
{
	shapeFile = "Force";
	mountPoint = 0;
	weaponType = 0;

	mountOffset = { 0.0, -0.095, 0.05};		// 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.0, 3.14, 0.0};		// ?, around gun barrel, ?
	accuFire = true;
	
	reloadTime = 0.01;	//0.1
	fireTime = 0.01;	//0.25;
	
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
};

ItemData BlasterGun
{
	description = "Blaster";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BlasterGunImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
function Blastergun::MountExtras(%player,%weapon) 
{	
	Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Fires a blast of energy.");
}











