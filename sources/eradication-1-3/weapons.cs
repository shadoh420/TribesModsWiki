
//----------------------------------------------------------------------------

$AutoUse[Blaster] = True;
$Use[Blaster] = True;
$WeaponAmmo[Blaster] = "";
$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;
$ItemMax[larmor, Blaster] = 1;
$ItemMax[lfemale, Blaster] = 1;
$ItemMax[marmor, Blaster] = 1;
$ItemMax[mfemale, Blaster] = 1;
$ItemMax[harmor, Blaster] = 1;
$ItemMax[carmor, Blaster] = 1;
$ItemMax[sarmor, Blaster] = 1;

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 149;
	showWeaponBar = true;
};


function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Blaster");
}

//--------------------------------------
// SniperRifle
//--------------------------------------

$AutoUse[SniperRifle] = True;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$SellAmmo[SniperAmmo] = 10;
$InvList[SniperRifle] = 1;
$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperRifle] = 1;
$RemoteInvList[SniperAmmo] = 1;
$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[larmor, SniperAmmo] = 8;
$ItemMax[lfemale, SniperRifle] = 1;
$ItemMax[lfemale, SniperAmmo] = 8;
$ItemMax[marmor, SniperRifle] = 1;
$ItemMax[marmor, SniperAmmo] = 15;
$ItemMax[mfemale, SniperRifle] = 1;
$ItemMax[mfemale, SniperAmmo] = 15;
$ItemMax[harmor, SniperRifle] = 0;
$ItemMax[harmor, SniperAmmo] = 15;
$ItemMax[carmor, SniperRifle] = 1;
$ItemMax[carmor, SniperAmmo] = 10;
$ItemMax[sarmor, SniperRifle] = 1;
$ItemMax[sarmor, SniperAmmo] = 15;


ItemData SniperAmmo 
{
  	description = "APHE 50cal Bullet";
  	className = "Ammo";
 	shapeFile = "ammo1";
  heading = "xAmmunition";
  	shadowDetailMask = 4;
	price = 9;
};

ItemImageData SniperRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 2.5;

	ammoType = SniperAmmo;
	projectileType = APHE50cal;
	accuFire = true;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
 	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
  heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 199;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Sniper Rifle");
}

//----------------------------------------------------------------------------

$AutoUse[LaserRifle] = True;
$WeaponAmmo[LaserRifle] = "";
$InvList[LaserRifle] = 1;
$RemoteInvList[LaserRifle] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[marmor, LaserRifle] = 1;
$ItemMax[mfemale, LaserRifle] = 1;
$ItemMax[harmor, LaserRifle] = 0;
$ItemMax[carmor, LaserRifle] = 1;
$ItemMax[sarmor, LaserRifle] = 0;


ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 149;
	showWeaponBar = true;
};


function LaserRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Laser Rifle");
}

//----------------------------------------------------------------------------

$AutoUse[PlasmaGun] = True;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$SellAmmo[PlasmaAmmo] = 10;
$InvList[PlasmaGun] = 1;
$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaAmmo] = 1;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, PlasmaAmmo] = 15;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, PlasmaAmmo] = 15;
$ItemMax[marmor, PlasmaGun] = 1;
$ItemMax[marmor, PlasmaAmmo] = 20;
$ItemMax[mfemale, PlasmaGun] = 1;
$ItemMax[mfemale, PlasmaAmmo] = 20;
$ItemMax[harmor, PlasmaGun] = 1;
$ItemMax[harmor, PlasmaAmmo] = 40;
$ItemMax[carmor, PlasmaGun] = 1;
$ItemMax[carmor, PlasmaAmmo] = 15;
$ItemMax[sarmor, PlasmaGun] = 1;
$ItemMax[sarmor, PlasmaAmmo] = 20;

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 199;
	showWeaponBar = true;
};


function PlasmaGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plasma Gun");
}

//--------------------------------------
// Plamsa Shotgun
//--------------------------------------

$AutoUse[PlasmaShotgun] = True;
$WeaponAmmo[PlasmaShotgun] = "";
$SellAmmo[PlasmaShotgunAmmo] = 10;
$InvList[PlasmaShotgun] = 1;
$RemoteInvList[PlasmaShotgun] = 1;
$ItemMax[larmor, PlasmaShotgun] = 0;
$ItemMax[lfemale, PlasmaShotgun] = 0;
$ItemMax[marmor, PlasmaShotgun] = 1;
$ItemMax[mfemale, PlasmaShotgun] = 1;
$ItemMax[harmor, PlasmaShotgun] = 1;
$ItemMax[carmor, PlasmaShotgun] = 0;
$ItemMax[sarmor, PlasmaShotgun] = 1;

ItemImageData PlasmaShotgunImage
{
   shapeFile  = "plasma";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0.5;
	fireTime = 1.0;
	projectileType = whatever;
	accuFire = false;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxFire     = SoundFirePlasma;
};

ItemData PlasmaShotgun
{
   heading = "bWeapons";
	description = "Plasma Shotgun";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PlasmaShotgunImage;
	price = 199;
	showWeaponBar = true;
};


function PlasmaShotgunImage::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 40)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%pelletCount=0; %pelletCount<=10; %pelletCount++)
		{ Projectile::spawnProjectile("PlasmaShotgunBolt",%transform,%player,%velocity); } 
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 40);
	}
else
	Client::sendMessage(Player::getClient(%player), 0,"Not Enough Energy");
}

function PlasmaShotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Plasma Shotgun");
}

//------------------------------------------------------------------------------
// Lamprey
//------------------------------------------------------------------------------

$AutoUse[Lamprey] = True;
$WeaponAmmo[Lamprey] = "";
$InvList[Lamprey] = 1;
$RemoteInvList[Lamprey] = 1;
$ItemMax[larmor, Lamprey] = 1;
$ItemMax[lfemale, Lamprey] = 1;
$ItemMax[marmor, Lamprey] = 1;
$ItemMax[mfemale, Lamprey] = 1;
$ItemMax[harmor, Lamprey] = 1;
$ItemMax[carmor, Lamprey] = 1;
$ItemMax[sarmor, Lamprey] = 1;

ItemImageData LampreyImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = LampreyCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Lamprey
{
   description = "Lamprey";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = LampreyImage;
	showWeaponBar = true;
   price = 199;
};

function Lamprey::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Lamprey");
}

//------------------------------------------------------------------------------

$AutoUse[EnergyRifle] = True;
$WeaponAmmo[EnergyRifle] = "";
$InvList[EnergyRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[harmor, EnergyRifle] = 1;
$ItemMax[carmor, EnergyRifle] = 1;
$ItemMax[sarmor, EnergyRifle] = 1;


ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 149;
};


function EnergyRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "ELF Gun");
}

//----------------------------------------
// AutoBlaster
//----------------------------------------

$AutoUse[AutoBlaster] = True;
$WeaponAmmo[AutoBlaster] = "";
$InvList[AutoBlaster] = 1;
$RemoteInvList[AutoBlaster] = 1;
$ItemMax[larmor, AutoBlaster] = 0;
$ItemMax[lfemale, AutoBlaster] = 0;
$ItemMax[marmor, AutoBlaster] = 1;
$ItemMax[mfemale, AutoBlaster] = 1;
$ItemMax[harmor, AutoBlaster] = 1;
$ItemMax[carmor, AutoBlaster] = 1;
$ItemMax[sarmor, AutoBlaster] = 1;

ItemImageData AutoBlasterImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; 
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 3;
	fireTime = 0.1;
	minEnergy = 2;
	maxEnergy = 5;

	projectileType = VoltBolt;
	accuFire = false;

	lightType = 3; 
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AutoBlaster
{
	description = "AutoBlaster";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoBlasterImage;
	price = 199;
	showWeaponBar = true;
};

function AutoBlaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "AutoBlaster");
}

//--------------------------------------
// Shotgun
//--------------------------------------

$AutoUse[Shotgun] = True;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$SellAmmo[ShotgunAmmo] = 10;
$InvList[Shotgun] = 1;
$InvList[ShotgunAmmo] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[ShotgunAmmo] = 1;
$ItemMax[larmor, Shotgun] = 0;
$ItemMax[larmor, ShotgunAmmo] = 10;
$ItemMax[lfemale, Shotgun] = 0;
$ItemMax[lfemale, ShotgunAmmo] = 10;
$ItemMax[marmor, Shotgun] = 1;
$ItemMax[marmor, ShotgunAmmo] = 15;
$ItemMax[mfemale, Shotgun] = 1;
$ItemMax[mfemale, ShotgunAmmo] = 15;
$ItemMax[harmor, Shotgun] = 1;
$ItemMax[harmor, ShotgunAmmo] = 25;
$ItemMax[carmor, Shotgun] = 1;
$ItemMax[carmor, ShotgunAmmo] = 10;
$ItemMax[sarmor, Shotgun] = 1;
$ItemMax[sarmor, ShotgunAmmo] = 15;

ItemData ShotgunAmmo
{
	description = "Shotgun Shells";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData ShotgunImage
{
   shapeFile  = "energygun";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0.5;
	fireTime = 1.0;
	ammoType = ShotgunAmmo;
	projectileType = whatever;
	accuFire = false;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxFire     = SoundFireMortar;
};

ItemData Shotgun
{
   heading = "bWeapons";
	description = "Shotgun";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	price = 199;
	showWeaponBar = true;
};


function ShotgunImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[Shotgun]) > 0)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%pelletCount=0; %pelletCount<=10; %pelletCount++)
		{ Projectile::spawnProjectile("ShotgunShell",%transform,%player,%velocity); } 
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	}
}

function Shotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Shotgun");
}

//----------------------------------------------------------------------------

$AutoUse[DiscLauncher] = True;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$SellAmmo[DiscAmmo] = 10;
$InvList[DiscLauncher] = 1;
$InvList[DiscAmmo] = 1;
$RemoteInvList[DiscLauncher] = 1;
$RemoteInvList[DiscAmmo] = 1;
$ItemMax[larmor, DiscLauncher] = 1;
$ItemMax[larmor, DiscAmmo] = 10;
$ItemMax[lfemale, DiscLauncher] = 1;
$ItemMax[lfemale, DiscAmmo] = 10;
$ItemMax[marmor, DiscLauncher] = 1;
$ItemMax[marmor, DiscAmmo] = 15;
$ItemMax[mfemale, DiscLauncher] = 1;
$ItemMax[mfemale, DiscAmmo] = 15;
$ItemMax[harmor, DiscLauncher] = 1;
$ItemMax[harmor, DiscAmmo] = 25;
$ItemMax[carmor, DiscLauncher] = 1;
$ItemMax[carmor, DiscAmmo] = 10;
$ItemMax[sarmor, DiscLauncher] = 1;
$ItemMax[sarmor, DiscAmmo] = 20;

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function DiscLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "DiscLauncher");
}

//----------------------------------------------------------------------------

$AutoUse[SballLauncher] = True;
$WeaponAmmo[SballLauncher] = SuperballAmmo;
$SellAmmo[SuperballAmmo] = 10;
$InvList[SballLauncher] = 1;
$InvList[SuperballAmmo] = 1;
$RemoteInvList[SballLauncher] = 1;
$RemoteInvList[SuperballAmmo] = 1;
$ItemMax[larmor, SballLauncher] = 1;
$ItemMax[larmor, SuperballAmmo] = 10;
$ItemMax[lfemale, SballLauncher] = 1;
$ItemMax[lfemale, SuperballAmmo] = 10;
$ItemMax[marmor, SballLauncher] = 1;
$ItemMax[marmor, SuperballAmmo] = 15;
$ItemMax[mfemale, SballLauncher] = 1;
$ItemMax[mfemale, SuperballAmmo] = 15;
$ItemMax[harmor, SballLauncher] = 1;
$ItemMax[harmor, SuperballAmmo] = 20;
$ItemMax[carmor, SballLauncher] = 1;
$ItemMax[carmor, SuperballAmmo] = 10;
$ItemMax[sarmor, SballLauncher] = 1;
$ItemMax[sarmor, SuperballAmmo] = 15;

ItemData SuperballAmmo
{
	description = "Superball";
	className = "Ammo";
	shapeFile = "discAmmo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData SballLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // SballLauncher
	ammoType = SuperballAmmo;
	projectileType = Superball;
	accuFire = true;
	reloadTime = 0.10;
	fireTime = 0.25;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData SballLauncher
{
	description = "Superball Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SballLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function SballLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Superball Launcher");
}

//----------------------------------------------------------------------------

$AutoUse[GrenadeLauncher] = True;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$SellAmmo[GrenadeAmmo] = 10;
$InvList[GrenadeLauncher] = 1;
$InvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeAmmo] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, GrenadeAmmo] = 6;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, GrenadeAmmo] = 6;
$ItemMax[marmor, GrenadeLauncher] = 1;
$ItemMax[marmor, GrenadeAmmo] = 9;
$ItemMax[mfemale, GrenadeLauncher] = 1;
$ItemMax[mfemale, GrenadeAmmo] = 9;
$ItemMax[harmor, GrenadeLauncher] = 1;
$ItemMax[harmor, GrenadeAmmo] = 18;
$ItemMax[carmor, GrenadeLauncher] = 1;
$ItemMax[carmor, GrenadeAmmo] = 6;
$ItemMax[sarmor, GrenadeLauncher] = 1;
$ItemMax[sarmor, GrenadeAmmo] = 9;

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 29;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.75;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function GrenadeLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Grenade Launcher");
}

//----------------------------------------------------------------------------
$AutoUse[Chaingun] = True;
$WeaponAmmo[Chaingun] = BulletAmmo;
$SellAmmo[BulletAmmo] = 50;
$InvList[Chaingun] = 1;
$InvList[BulletAmmo] = 1;
$RemoteInvList[Chaingun] = 1;
$RemoteInvList[BulletAmmo] = 1;
$ItemMax[larmor, Chaingun] = 0;
$ItemMax[larmor, BulletAmmo] = 50;
$ItemMax[lfemale, Chaingun] = 0;
$ItemMax[lfemale, BulletAmmo] = 50;
$ItemMax[marmor, Chaingun] = 1;
$ItemMax[marmor, BulletAmmo] = 100;
$ItemMax[mfemale, Chaingun] = 1;
$ItemMax[mfemale, BulletAmmo] = 100;
$ItemMax[harmor, Chaingun] = 1;
$ItemMax[harmor, BulletAmmo] = 175;
$ItemMax[carmor, Chaingun] = 0;
$ItemMax[carmor, BulletAmmo] = 50;
$ItemMax[sarmor, Chaingun] = 0;
$ItemMax[sarmor, BulletAmmo] = 100;

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.15;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 199;
	showWeaponBar = true;
};


function Chaingun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Chaingun");
}

//----------------------------------------------------------------------------

$AutoUse[Mortar] = True;
$WeaponAmmo[Mortar] = MortarAmmo;
$SellAmmo[MortarAmmo] = 5;
$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;
$ItemMax[larmor, Mortar] = 0;
$ItemMax[larmor, MortarAmmo] = 1;
$ItemMax[lfemale, Mortar] = 0;
$ItemMax[lfemale, MortarAmmo] = 1;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, MortarAmmo] = 2;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, MortarAmmo] = 2;
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, MortarAmmo] = 5;
$ItemMax[carmor, Mortar] = 0;
$ItemMax[carmor, MortarAmmo] = 1;
$ItemMax[sarmor, Mortar] = 0;
$ItemMax[sarmor, MortarAmmo] = 2;

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 49;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 299;
	showWeaponBar = true;
};


function Mortar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Mortar");
}

//----------------------------------------------------------------------------

$AutoUse[MultiGrenadeLauncher] = True;
$WeaponAmmo[MultiGrenadeLauncher] = GrenadeAmmo;
$InvList[MultiGrenadeLauncher] = 1;
$RemoteInvList[MultiGrenadeLauncher] = 1;
$ItemMax[larmor, MultiGrenadeLauncher] = 0;
$ItemMax[lfemale, MultiGrenadeLauncher] = 0;
$ItemMax[marmor, MultiGrenadeLauncher] = 1;
$ItemMax[mfemale, MultiGrenadeLauncher] = 1;
$ItemMax[harmor, MultiGrenadeLauncher] = 1;
$ItemMax[carmor, MultiGrenadeLauncher] = 0;
$ItemMax[sarmor, MultiGrenadeLauncher] = 0;

ItemImageData MultiGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = whatever;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxReady = SoundMortarIdle;
};

ItemData MultiGrenadeLauncher
{
	description = "MultiGrenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MultiGrenadeLauncherImage;
	price = 299;
	showWeaponBar = true;
};


function MultiGrenadeLauncherImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) >= 3)
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)-0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)+0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	GameBase::setRotation(%player, %rot);
	Player::decItemCount(%player,$WeaponAmmo[MultiGrenadeLauncher],3);
	}
if (Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) > 0 && Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) < 3) 
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	Player::decItemCount(%player,$WeaponAmmo[MultiGrenadeLauncher],1);
	}

}

function MultiGrenadeLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "MultiGrenade Launcher");
}

//----------------------------------------------------------------------------

$AutoUse[Howitzer] = True;
$WeaponAmmo[Howitzer] = HowitzerAmmo;
$SellAmmo[HowitzerAmmo] = 10;
$InvList[Howitzer] = 1;
$InvList[HowitzerAmmo] = 1;
$RemoteInvList[Howitzer] = 1;
$RemoteInvList[HowitzerAmmo] = 1;
$ItemMax[larmor, Howitzer] = 0;
$ItemMax[larmor, HowitzerAmmo] = 1;
$ItemMax[lfemale, Howitzer] = 0;
$ItemMax[lfemale, HowitzerAmmo] = 1;
$ItemMax[marmor, Howitzer] = 1;
$ItemMax[marmor, HowitzerAmmo] = 2;
$ItemMax[mfemale, Howitzer] = 1;
$ItemMax[mfemale, HowitzerAmmo] = 2;
$ItemMax[harmor, Howitzer] = 1;
$ItemMax[harmor, HowitzerAmmo] = 5;
$ItemMax[carmor, Howitzer] = 0;
$ItemMax[carmor, HowitzerAmmo] = 1;
$ItemMax[sarmor, Howitzer] = 0;
$ItemMax[sarmor, HowitzerAmmo] = 2;

ItemData HowitzerAmmo
{
	description = "Howitzer Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 69;
};

ItemImageData HowitzerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HowitzerAmmo;
	projectileType = HowitzerShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.15;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Howitzer
{
	description = "Howitzer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HowitzerImage;
	price = 299;
	showWeaponBar = true;
};


function Howitzer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Howitzer");
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
//  Repulsor Gun
//----------------------------------------------------------------------------

$AutoUse[RepulsorGun] = True;
$WeaponAmmo[RepulsorGun] = "";
$InvList[RepulsorGun] = 1;
$RemoteInvList[RepulsorGun] = 1;
$ItemMax[larmor, RepulsorGun] = 1;
$ItemMax[lfemale, RepulsorGun] = 1;
$ItemMax[marmor, RepulsorGun] = 1;
$ItemMax[mfemale, RepulsorGun] = 1;
$ItemMax[harmor, RepulsorGun] = 1;
$ItemMax[carmor, RepulsorGun] = 1;
$ItemMax[sarmor, RepulsorGun] = 1;

ItemImageData RepulsorGunImage
{
   shapeFile = "paintgun";
   mountPoint = 0;

   weaponType = 2; 
   projectileType = RepulsorBeam;
   minEnergy = 18;
   maxEnergy = 22;
   reloadTime = 0.2;
			
   lightType = 3;
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundRepairItem;
};

ItemData RepulsorGun
{
  className = "Tool";
  description = "Repulsor Gun";
  heading = "bWeapons";
  hudIcon = "targetlaser";
  imageType = RepulsorGunImage;
  price = 199;
  shadowDetailMask = 4;
  shapeFile = "paintgun";
  showWeaponBar = true;
};

function RepulsorGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Repulsor Gun");
}

//----------------------------------------------------------------------------

$AutoUse[TargetingLaser] = False;
$WeaponAmmo[TargetingLaser]="";
$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[harmor, TargetingLaser] = 1;
$ItemMax[carmor, TargetingLaser] = 1;
$ItemMax[sarmor, TargetingLaser] = 1;

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 99;
	showWeaponBar = false;
};


function TargetingLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Targeting Laser");
}
