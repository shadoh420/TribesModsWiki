function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}
//----------------------------------------------------------------------------
ItemImageData FlagImage 
	{ 
	shapeFile = "flag"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, -0.35 }; 
	mountRotation = { 0, 0, 0 }; 
	lightType = 2; 
	lightRadius = 4; 
	lightTime = 1.5; 
	lightColor = { 1, 1, 1}; 
	}; 

ItemData Flag 
	{ 
	description = "Flag"; 
	shapeFile = "flag"; 
	imageType = FlagImage; 
	showInventory = false; 
	shadowDetailMask = 4; 
	lightType = 2; 
	lightRadius = 4; 
	lightTime = 1.5; 
	lightColor = { 1, 1, 1 }; 
	};

function Flag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Flag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
} 

ItemData RaceFlag 
	{ 
	description = "Race Flag"; 
	shapeFile = "flag"; 
	imageType = FlagImage; 
	showInventory = false; 
	shadowDetailMask = 4; 
	lightType = 2; 
	lightRadius = 4; 
	lightTime = 1.5; 
	lightColor = { 1, 1, 1 }; 
	}; 

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData BrandonArmor
{
   heading = "a(Armors)";
	description = "Hyper Sniper";
	className = "Armor";
	price = 150;
};

ItemData LightArmor
{
   heading = "a(Armors)";
	description = "Battalion Warrior";
	className = "Armor";
	price = 250;
};

ItemData MediumArmor
{
   heading = "a(Armors)";
	description = "Deffence Engineer";
	className = "Armor";
	price = 350;
};

ItemData HeavyArmor
{
   heading = "a(Armors)";
	description = "Nova Mercenary";
	className = "Armor";
	price = 450;
};

ItemData NewArmor
{
   heading = "a(Armors)";
	description = "Hybrid Destroyer";
	className = "Armor";
	price = 1000;
};
//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Shredder Scout";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 150;
};

ItemData WarthogVehicle
{
	description = "Spirit Scout";
	classname = "Vehicle";
	heading = "a||Vehicle||";
	price = 250;
};

ItemData SR71Vehicle
{
	description = "Mini-Gun Scout";
	classname = "Vehicle";
	heading = "a||Vehicle||";
	price = 350;
};

ItemData EnterpriseVehicle
{
	description = "Napalm Scout";
	className = "Vehicle";
   	heading = "a||Vehicle||";
	price = 450;
};

ItemData BomberVehicle
{
	description = "Bomber Scout";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 550;
};

ItemData SpeedBikeVehicle
{
	description = "Plasma Jet-Bike";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 650;
};

ItemData ColossusVehicle
{
	description = "Disc Jet-Bike";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData ArwingVehicle
{
	description = "RPG Jet-Bike";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 850;
};

ItemData LAPCVehicle
{
	description = "Repair Transporter";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 950;
};

ItemData HAPCVehicle
{
	description = "Assault Transporter";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 1050;
};


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	if(%player.Station==""){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else {
				Client::sendMessage(Player::getClient(%player),0,
				strcat(%item.description," has no ammo"));
			}
		}
	}
}

//----------------------------------------------------------------------------
ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}
//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	
//----------------------------------------------------------------------------
ItemImageData BlasterImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;
      mountRotation = { 0,-7, 0 };
	mountOffset = { 0, 0, -0.1 };
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = BlasterBolt;
	accuFire = true;
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower;
};

ItemData Blaster
{
   heading = "b(New Age)";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "mortargun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	//price = 0;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Blaster]: <f2>A Modified Blaster", 3);
}

ItemImageData TachyonImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 7, 0 };//1.57
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;
	minEnergy = 7;
	maxEnergy = 8;
	projectileType = FusionRifleBullet;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Tachyon
{
   heading = "c(Energized)";
	description = "Fusion Rifle";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = TachyonImage;
	price = 100;
	showWeaponBar = true;
};

function Tachyon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fusion Rifle]: <f2>Shoots a fast bolt of electricty that when come in contact with anything burst into a fire.", 3);
}

ItemData MagnumAmmo
{
	description = "PP7-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MagnumImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0; // Single shot
	reloadTime = 0.2;
	fireTime = 0.2;
	ammoType = MagnumAmmo;
	projectileType = MagnumBullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Magnum
{
	description = "PP7 Pistal";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = MagnumImage;
	price = 200;
	showWeaponBar = true;
};

function Magnum::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[PP7 Pistal]: <f2>Shoots a high Cal.bullet.", 3);
}

//----------------------------------------------------------------------------
ItemData BulletAmmo
{
	description = "Ripper-Shot";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Ripper XL";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "sniper";
   heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Ripper XL]: <f2>Like the original chaingun but with a few modifications.", 3);
}
//----------------------------------------------------------------------------
ItemData BlueRageAmmo
{
	description = "BlueR-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData BlueRageImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = BlueRageAmmo;
	projectileType = BlueRageBullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData BlueRage
{
	description = "Blue Rage";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = BlueRageImage;
	price = 900;
	showWeaponBar = true;
};

function BlueRage::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Blue Rage]: <f2>A very fast and furious killer.", 3);
}

$MinigunSlot=4; 

ItemData MinigunAmmo 
{ 
	description = "Mini-Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "x(Ammo)"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.225, 0, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = MinigunAmmo;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

function MinigunImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[Minigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMinigun[%client]) MDCheckMinigun(%client, %player); 
} 

ItemData Minigun 
{ 
	description = "Minigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "d(Guns)";
	shadowDetailMask = 4; 
	imageType = MinigunImage; 
	price = 5000; 
	showWeaponBar = true; 
}; 

function Minigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, Minigun2, 0); 
		Item::onDrop(%player,%item); 
	} 
} 

function Minigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,Minigun2,$MinigunSlot); 
} 

function Minigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MinigunSlot); 
} 

ItemImageData Minigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 };
	mountOffset = { 0, 0, 0 };
 	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = MinigunAmmo;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = debrissmallexplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Minigun2 
{ 
	description = "Mantis M-II"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Minigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

$MinigunSlot=4; 

function MDCheckMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Minigun")) 
	{ 
		Player::trigger(%player,$MinigunSlot,true); 
		schedule("MDCheckMinigun(" @ %client @ "," @ %player @ ");",0.05); 
		$MDFiringMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MinigunSlot,false); 
		$MDFiringMinigun[%client] = false; 
	} 
} 

function Minigun2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "[Minigun]: <f2>Double Chaingun");
}

ItemData HybridRailAmmo
{
	description = "Hybrid Rail Spikes";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData HybridRailImage
{
	shapeFile = "sniper"; //"sniper";
	mountPoint = 0;
      minEnergy = 30;
	maxEnergy = 60;
	weaponType = 0; // Single Shot
	ammoType = HybridRailAmmo;
//	projectileType = ThisShouldBeUndefined;
	accuFire = true;
	reloadTime = 0.2;//++++
	fireTime = 2.0;
//	mountOffset = { 0, -1.5, 0 }; //(side-side(+=right), front-back(+=forward), up-down)
//	mountRotation = { 30.0, 0, 0}; //(vertical-front(+=down?), vertical-sideways, horizontal-sideways)
	lightType = 3;  // Weapon Fire
	lightRadius = 8;//6;+++++++++++++++++++++
	lightTime = 2;
	lightColor = {0.05, 0.25, 0.45}; //{ 1.0, 0, 0 };+++++++++++++++
//	sfxFire = SoundMissileTurretFire;//+++++
	sfxActivate = SoundPickUpWeapon;//++++++
	sfxReload = SoundDiscReload;//++++++
	sfxReady = SoundGeneratorPower;//+++++++
};
ItemData HybridRail
{
	description = "Hybrid RailGun";
	className = "Weapon";
	shapeFile = "sniper"; //"sniper";
	hudIcon = "targetlaser";
  heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = HybridRailImage;
	price = 475;
	showWeaponBar = true;
};
function HybridRail::onUse(%player,%item,%slot,%timeSlice,%enDrainPerSec)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "[Hybrid RailGun]: <f2>Great modified rail gun", 3);
}
function HybridRailImage::onFire(%player,%slot)
 {
   %enVal  = 50.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[HybridRail]);
   if (%energy > 20.0) //20.0+++++++++++
{
		 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));//+++++
		 Player::decItemCount(%player,$WeaponAmmo[HybridRail],1);
		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("HybridRailBullet",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundDryFire,GameBase::getPosition(%player));//++++
	 Player::trigger(%player,$WeaponSlot,false);//+++++
	 Client::sendMessage(Player::getClient(%player), 0,"Not enough energy to fire Hybrid Rail");
	}
 }

ItemData AmbushAmmo
{
	description = "Smoker-Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AmbushImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = AmbushAmmo;
	projectileType = AmbushBullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = bigExplosion4;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};


ItemData Ambush
{
	description = "Destroyer Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = AmbushImage;
	price = 1500;
	showWeaponBar = true;
};

function Ambush::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Destroyer Chaingun]: <f2>This weapon has a fast fire rate and is able to eat threw anything in its way", 3);
}

ItemData M10Ammo
{
	description = "M-9 Round";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData M10Image
{
	shapeFile = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 1.57, 0 };
	weaponType = 1; // Spinning
	weaponType = 0;
	reloadTime = 0.50; //0.15
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0.1;
	ammoType = M10Ammo;
	projectileType = M10Bullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.75, 0.75, 0.35 };//+++++++++++++++++++++++++++++
      sfxFire = SoundFiremortar;
	sfxReload = Soundmortarreload; 
	sfxActivate = Soundfliercrash;
};

ItemData M10
{
	description = "M-9 Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
      heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = M10Image;
	price = 1175;
	showWeaponBar = true;
};


function M10::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[M-9 Rifle]: <f2>This weapon is a nasty one and was taken out in hybrid 6.0 for bad behavior but has been rereleased on good behavior....", 3);
}

ItemData VulcanAmmo
{
	description = "DFMIYA-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; // Spinning
	reloadTime = 0.1;
	//spinUpTime = 0;
	//spinDownTime = 0.1;
	fireTime = 0.02;
	ammoType = VulcanAmmo;
	projectileType = VulcanBullet;
	accuFire = true;
	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan
{
	description = "D.F.M.I.Y.A";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 1300;
	showWeaponBar = true;
};

function Vulcan::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[D.F.M.I.Y.A]: <f2>This Chaingun is the king of kings,top 'o' the line destruction", 3);
}


ItemData ShotgunAmmo
{
	description = "WT BuckShot Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData AutoShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // SingleShot
	reloadTime = 0.3;
	fireTime = 0.2;
	ammoType = ShotgunAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AutoShotgun
{
	description = "WT.12G";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = AutoShotgunImage;
	price = 400;
	showWeaponBar = true;
};

function AutoShotgunImage::onFire(%player,%slot)
{
	echo("WT 12 Fired! someones hurt'in now");

	for(%i = 0; %i < 15; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[AutoShotgun],1);
}

function AutoShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[WT.12G]: <f2>WT = (White Trash)A powerful and fast double barreled killer.", 3);
}
//----------------------------------------------------------------------------
ItemData MP5Ammo
{
	description = "SXH5000-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};
ItemImageData MP5Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0.55;
	fireTime = 0.02;
	ammoType = MP5Ammo;
	projectileType = MP5Bullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireMortar;
      sfxReload = SoundDiscreload;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MP5
{
	description = "SXH-5000";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = MP5Image;
	price = 100;
	showWeaponBar = true;
};

function MP5::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[SXH-5000]: <f2>Semi-Automatic Sniper Rilfe, great for taking out hovering heavies", 3);
}


ItemData TankShredderAmmo 
{	description = "Hybrid-Chain Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 12;
};

ItemImageData TankShredderImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TankShredder 
{	description = "Hybrid Chain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = TankShredderImage;
	price = 7500;
	showWeaponBar = true;
};


ItemImageData TankShredder2Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 3, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder2 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData TankShredder3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder3 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData TankShredder4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, 3, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder4 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$TankShredderSlotA=4;
$TankShredderSlotB=7;
$TankShredderSlotC=6;

function TankShredder::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	Player::mountItem(%player,TankShredder2,$TankShredderSlotA);
	Player::mountItem(%player,TankShredder3,$TankShredderSlotB);
	Player::mountItem(%player,TankShredder4,$TankShredderSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "[Hybrid Chaingun]: <f2>Made only for the Hybrid,For obvious reasons");
}

function TankShredder::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankShredderSlotA);
	Player::unmountItem(%player,$TankShredderSlotB);	 
	Player::unmountItem(%player,$TankShredderSlotC);
}

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlot,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.05);
		$MDFiringTankShredder[%client] = true;
	}
	else
	{	Player::trigger(%player,$TankShredderSlot,false);
		$MDFiringTankShredder[%client] = false;
	}
}

function TankShredderImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[TankShredder],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShredderBullet",%trans,%player,%vel,%player);
	if(!$MDFiringTankShredder[%client]) 
		MDCheckTankShredder(%client, %player);
}

function TankShredder::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankShredder2, 0);
		Item::onDrop(%player,%item);
	}
}

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlotA,true);
		Player::trigger(%player,$TankShredderSlotB,true);
		Player::trigger(%player,$TankShredderSlotC,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.1);
		$MDFiringTankShredder[%client] = true;
	}
	else 
	{	Player::trigger(%player,$TankShredderSlotA,false);
		Player::trigger(%player,$TankShredderSlotB,false);
		Player::trigger(%player,$TankShredderSlotC,false);
		$MDFiringTankShredder[%client] = false;
	}
}

ItemData AssaultChaingunAmmo
{
	description = "ARPG-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AssaultChaingunImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.3;
	ammoType = AssaultChaingunAmmo;
	projectileType = AssaultChaingunBullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireAssaultChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AssaultChaingun
{
	description = "ARPG";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = AssaultChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function AssaultChaingun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[ARPG]: <f2>The Auto Rocket Propelled Grenade Launcher, Is used to Clear deep lines of enemy soldiers.", 3);
}

ItemData FlakAmmo
{
	description = "RPT-Rockets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData FlakImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 3;
	fireTime = 0.3;
	ammoType = FlakAmmo;
	projectileType = FlakBullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundMortarIdle;
	sfxSpinDown = SoundLaserIdle;
};

ItemData Flak
{
	description = "RPT";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = FlakImage;
	price = 150;
	showWeaponBar = true;
};

function Flak::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[RPT]: <f2>Rocket Propelled Thumper. You figure it out.", 3);
}

echo("Loading.... HaVoC Sniper");

ItemData SniperAmmo
{
	description = "HaVoC-Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;
	ammoType = SniperAmmo;
	projectileType = SniperBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Sniper
{
	description = "HaVoC Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = SniperImage;
	price = 150;
	showWeaponBar = true;
};

echo("HaVoC Sniper Loaded!");

function Sniper::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[HaVoC Sniper]: <f2>The most advanced Sniper rifle ever to exist.", 3);
}


//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolts";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
      mountOffset = {0.065, 0.05, 0};
      mountRotation = {0, 1.80, 0};
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
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Plasma Cannon]: <f2>Packs a bigger punch than the old Plasma gun.", 5);
}

ItemImageData PlasmaBlasterImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;
      mountRotation = { 0, -1.80, 0 };//3.60
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.5;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = PlasmaBlasterBolt;
	accuFire = true;
	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundFirePlasma;
};

ItemData PlasmaBlaster
{
   heading = "e(Plasma)";
	description = "Plasma Blaster";
	className = "Weapon";
   shapeFile  = "mortargun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PlasmaBlasterImage;
	price = 385;
	showWeaponBar = true;
};

function PlasmaBlaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Plasma Blaster]: <f2>Plasma Has Evolved!", 3);
}

ItemData PlasmaGrenadeAmmo
{
	description = "Napalm Ammo";
	className = "Ammo";
	heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
}; 

ItemImageData PlasmaGrenadeImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = PlasmaGrenadeAmmo;
	//projectileType = ;
	accuFire = false;
	mountRotation = { 0, 1.57, 0 };
	//mountOffset = {-0.065, 0, 0.07}; 
	reloadTime = 0.75;
	fireTime = 2.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = bigExplosion3; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData PlasmaGrenade 
{
	description = "Napalm Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
	heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = PlasmaGrenadeImage;
	price = 420;
	showWeaponBar = true;
};

function PlasmaGrenade::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Naplam Launcher]: <f2>Sends a Grenade filled with plasma at your foe.", 5);
}

function PlasmaGrenadeImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,PlasmaGrenadeAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,PlasmaGrenadeAmmo);

 		%newObj = Projectile::spawnProjectile("NapShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("NapSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("NapFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	//%rnd = (floor(getRandom()*20)/80);
		//schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
//function SetMines(%newobj,%this){
//
//	if (GameBase::getPosition(%newObj)){
//		%Pos = GameBase::getPosition(%newobj); 
//   		%vel = Item::getVelocity(%newobj);
//		%Mine = newObject("","Mine","antipersonelMine");
//		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
// 		addToSet("MissionCleanup", %Mine);
//      	GameBase::throw(%Mine,%this,-1,true);
//		GameBase::setPosition(%Mine, %pos);
//		Item::setVelocity(%Mine, %vel);
//	deleteobject(%newObj);
//	}
//}


ItemData PlasmaShotgunAmmo
{
	description = "Hell BuckShot";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaShotgunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PlasmaShotgunAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.2;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaShotgun
{
	description = "Hell Fire";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = PlasmaShotgunImage;
	price = 200;
	showWeaponBar = true;
};

function UnchargePlasmaShotgun(%player)
{
	//echo("Uncharging Plasma Shotgun...");

	if(Player::getItemCount(%player, $WeaponAmmo[PlasmaShotgun]) > 1)
	{
		Player::decItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
	}

	if($PlasmaShotgunUncharging[%player] == True)
	{
		schedule("UnchargePlasmaShotgun(" @ %player @ ");", 1.5);
	}
}

function PlasmaShotgunImage::onFire(%player,%slot)
{
	echo("Hell Fire Shot,TAKE COVER!");

	if(Player::getItemCount(%player, $WeaponAmmo[PlasmaShotgun]) > 9)
	{
		for(%i = 0; %i < 10; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PlasmaShotgunBullet",%trans,%player,%vel);
		}
		Player::setItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
		$PlasmaShotgunUncharging[%player] = False;
	}
	else
	{
		Player::incItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
		if($PlasmaShotgunUncharging[%player] == False)
		{
			echo("$PlasmaShotgunUncharging is false!");
			schedule("UnchargePlasmaShotgun(" @ %player @ ");", 1.5);
			$PlasmaShotgunUncharging[%player] = True;
		}
	}
}

function PlasmaShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Hell Fire]: <f2>This weapon pulls atoms form the air and charges them to there max then sends these pellets into your foe.", 5);
}

ItemData RFPlasmaAmmo
{
	description = "Fusion Chain Ammo";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RFPlasmaImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RFPlasmaAmmo;
	projectileType = RFPlasmaBullet;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RFPlasma
{
	description = "Fusion Chain";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = RFPlasmaImage;
	price = 200;
	showWeaponBar = true;
};

function RFPlasma::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Fusion Chain]: <f2>An updated virsion of the Fusion Rifle", 5);
}
//////////////////
$PlasmaELFSlotA=4;
$PlasmaELFSlotB=7;
$PlasmaELFSlotC=6; 

ItemData PlasmaELFAmmo 
{	description = "Magma Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "x(Ammo)"; 
	shadowDetailMask = 4; 
	price = 12; 
}; 

ItemImageData PlasmaELFLauncherImage 
{	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = PlasmaELFAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData PlasmaELFLauncher 
{	description = "Magma Cannon"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "chain"; 
	heading = "e(Plasma)";
	shadowDetailMask = 4; 
	imageType = PlasmaELFLauncherImage; 
	price = 5500; 
	showWeaponBar = true; 
};

ItemImageData PlasmaELFLauncher2Image 
{	ammoType = PlasmaELFAmmo; 
	projectileType = HMSL; 
	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0, 0 }; 
	mountRotation = { 0, -3, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData PlasmaELFLauncher2 
{	description = "PlasmaELFRPG"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = PlasmaELFLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData PlasmaELFLauncher3Image 
{	ammoType = PlasmaELFAmmo; 
	projectileType = HMS; 
	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData PlasmaELFLauncher3 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = PlasmaELFLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData PlasmaELFLauncher4Image 
{	ammoType = PlasmaELFAmmo; 
	projectileType = HMSL; 
	shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = {0, 0, 0 }; 
	mountRotation = { 0, -3, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData PlasmaELFLauncher4 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = PlasmaELFLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$PlasmaELFSlotA=4;
$PlasmaELFSlotB=7;
$PlasmaELFSlotC=6;

function PlasmaELFLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,PlasmaELFLauncher2,$PlasmaELFSlotA); 
	Player::mountItem(%player,PlasmaELFLauncher3,$PlasmaELFSlotB); 
	Player::mountItem(%player,PlasmaELFLauncher4,$PlasmaELFSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "[Magma Cannon]: <f2>Launches a violent storm of Rockets and mortars all made of white hot plasma");
}

function PlasmaELFLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$PlasmaELFSlotA);
	Player::unmountItem(%player,$PlasmaELFSlotB);	 
	Player::unmountItem(%player,$PlasmaELFSlotC);
}

function PlasmaELFLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,PlasmaELFammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("HMS",%trans,%player,%vel,%player); 
	if(!$FiringPlasmaELFLauncher[%client]) 
		CheckPlasmaELFLauncher(%client, %player); 
}

function PlasmaELFLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, PlasmaELFLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckPlasmaELFLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "PlasmaELFLauncher")) 
	{	Player::trigger(%player,$PlasmaELFSlotA,true);
		Player::trigger(%player,$PlasmaELFSlotB,true);
		Player::trigger(%player,$PlasmaELFSlotC,true); 
		schedule("CheckPlasmaELFLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringPlasmaELFLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$PlasmaELFSlotA,false); 
		Player::trigger(%player,$PlasmaELFSlotB,false); 
		Player::trigger(%player,$PlasmaELFSlotC,false); 
		$FiringPlasmaELFLauncher[%client] = false; 
	} 
}
///////////////////
ItemData AfterburnerAmmo
{
	description = "Flame Thrower Gas";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AfterburnerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = AfterburnerAmmo;
	accuFire = false;
	reloadTime = 0.0000001;
	fireTime = 0.000001;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Afterburner
{
	description = "Flame Thrower";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = AfterburnerImage;
	price = 200;
	showWeaponBar = true;
};

function AfterburnerImage::onFire(%player,%slot)
{
	//echo("Firing afterburner!");
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AfterburnerBullet",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Afterburner],1);
}

function Afterburner::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Flame Thrower]: <f2>Basic Flame thrower.", 3);
}

ItemData RamjetAmmo
{
	description = "Avenger Spread";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RamjetImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	weaponType = 1; // Spinning (for faster shots)
	ammoType = RamjetAmmo;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.9;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Ramjet
{
	description = "Avenger";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = RamjetImage;
	price = 200;
	showWeaponBar = true;
};

function RamjetImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("RamjetBullet",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Ramjet],1);
}

function Ramjet::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Plasma M-16]: <f2>Sends Charged plasma heated to 100,000 Degrees.", 3);
}


ItemImageData PlasmaSniperImage
{
	shapeFile = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 1.60, 0 };//3.60
	weaponType = 0; // Single Shot
	projectileType = PlasmaLaser;
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
	sfxActivate = SoundFirePlasma;
};

ItemData PlasmaSniper
{
	description = "Melt Laser";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = PlasmaSniperImage;
	price = 500;
	showWeaponBar = true;
};

function PlasmaSniper::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Melt Laser]: <f2>Plasma Has many forms, it has been in all fields except Laser form until now.", 5);
}
//------------------------------------------
ItemData FirestormAmmo
{
	description = "PlasmaGat Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData FirestormImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 3;
	fireTime = 0.1;
	ammoType = FirestormAmmo;
	projectileType = FirestormBullet;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundFireGluon;
	sfxSpinDown = SoundFireGluon;
};

ItemData Firestorm
{
	description = "Plasma Gat";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = FirestormImage;
	price = 800;
	showWeaponBar = true;
};

function Firestorm::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Plasma Gat]: <f2>Rapid Fire Heated Balls Of Hot Plasma.", 3);
}

ItemData PhasedPlasmaCannonAmmo
{
	description = "Napalm Rockets";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData PhasedPlasmaCannonImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PhasedPlasmaCannonAmmo;
	projectileType = PhasedPlasmaCannonBullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PhasedPlasmaCannon
{
	description = "Napalm Rocket";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = PhasedPlasmaCannonImage;
	price = 350;
	showWeaponBar = true;
};

function PhasedPlasmaCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Napalm Rocket]: <f2>A very high powered Rocket.", 3);
}

ItemData GravShockAmmo
{
	description = "Super Nova Shells";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GravShockImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = GravShockAmmo;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GravShock
{
	description = "Super Nova";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = GravShockImage;
	price = 225;
	showWeaponBar = true;
};

function GravShockImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("GravShockBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("GravShockBullet2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[GravShock],1);
}

function GravShock::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Super Nova]: <f2>Harness the power of the stars to explode your enemy into thin air.", 5);
}

ItemData PhaserRifleAmmo
{
	description = "Stealth-Ammo";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData PhaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = PhaserRifleAmmo;
	projectileType = PhaserRifleBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.4;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PhaserRifle
{
	description = "Stealth Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = PhaserRifleImage;
	price = 350;
	showWeaponBar = true;
};

function PhaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Stealth]: <f2>A slower sniper rifle but it's a very powerfull shot.", 5);
}

ItemData PulsePhaserAmmo
{
	description = "Hell Shell";
   heading = "x(Ammo)";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData PulsePhaserImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PulsePhaserAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PulsePhaser
{
	description = "Hell Storm";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = PulsePhaserImage;
	price = 500;
	showWeaponBar = true;
};

function RechargePulsePhaserAmmo(%player)
{
	//echo("Recharging ammo for Pulse Phaser");
	%armor = Player::GetArmor(%player);
	if(Player::getItemCount(%player,PulsePhaser) > 0)
	{
		if(Player::getItemCount(%player,PulsePhaserAmmo) < $ItemMax[%armor,PulsePhaserAmmo])
		{
			Player::incItemCount(%player,PulsePhaserAmmo,1);
		}
		else
			$PulsePhaserRecharging[%player] = False;
	}
}

function FirePulsePhaser(%player)
{
	echo("Firing Pulse Phaser!");
	if($FiringPulsePhaser[%player] == True)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PulsePhaserBullet",%trans,%player,%vel);
	}
	
	if($PulsePhaserFired[%player] < 2)
	{
		$PulsePhaserFired[%player]++;
		schedule("FirePulsePhaser(" @ %player @ ");", 0.2);
	}
}

function PulsePhaserImage::onFire(%player,%slot)
{
	//echo("Firing Pulse Phaser!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("PulsePhaserBullet",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[PulsePhaser],1);

	$FiringPulsePhaser[%player] = True;
	$PulsePhaserFired[%player] = 1;

	schedule("FirePulsePhaser(" @ %player @ ");", 0.2);

	schedule("RechargePulsePhaserAmmo(" @ %player @ ");", 2.5);
}

function PulsePhaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Hell Storm]: <f2>Shoots a Storm of Flamable Gases.", 5);
}

//----------------------------------------------------------------------------
ItemData GrenadeAmmo
{
	description = "Glue Nades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{ 
        shapeFile = "grenadeL";
        mountPoint = 0;
        mountrotation = { 0, 3, 0 };
        weaponType = 0;
        ammoType = GrenadeAmmo;
        projectileType = GrenadeShell;
        accuFire = false;
        reloadTime = 0.5;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
        sfxFire = SoundMortarTurretFire;
        sfxActivate = SoundChainTurretOn;
        sfxReady = SoundGeneratorPower;
};

ItemData GrenadeLauncher
{
	description = "Glue Grenade";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Glue Grenade]: <f2>Has a little stick to it.", 5);
}

ItemData AGLAmmo
{
	description = "Nitro Nades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData AGLImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = AGLAmmo;
	projectileType = AGLBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AGL
{
	description = "Nitro Nadder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "grenade";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = AGLImage;
	price = 300;
	showWeaponBar = true;
};

function AGL::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Nitro Nader]: <f2>Lobbs Grenades filled with Nitro at your enemy.", 5);
}
//----------------------------------------------------------------------------
ItemData ChargedPlasmaAmmo
{
	description = "STG Missile";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ChargedPlasmaImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ChargedPlasmaAmmo;
	projectileType = ChargedPlasmaBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = explosion4; //the sound plasma bolts make when they explode
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData ChargedPlasma
{
	description = "S.T.G Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "e(Plasma)";
	shadowDetailMask = 4;
	imageType = ChargedPlasmaImage;
	price = 225;
	showWeaponBar = true;
};

function ChargedPlasma::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[S.T.G Launcher]: <f2>Sky To Ground Launcher is the best way to lead an attack from the sky.", 5);
}
//----------------------------------------------------------------------------
ItemData MortarAmmo
{
	description = "Thumper Shells";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
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
	description = "Thumper";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Thumper]: <f2>High power mortar,Long range.", 5);
}

ItemData AMMAmmo
{
	description = "Fire Mortar Shells";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AMMImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AMMAmmo;
	projectileType = AMMBullet;
	accuFire = false;
	reloadTime = 0.25;
	fireTime = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMortarReload;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundFireLaser;
	sfxReady = SoundMortarIdle;
};

ItemData AMM
{
	description = "Fire Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = AMMImage;
	price = 400;
	showWeaponBar = true;
};

function AMM::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fire Mortar]: <f2>***WARNING*** Very large radius.", 5);
}
//----------------------------------------------------------------------------
ItemImageData CannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountRotation = { 0, 0.99, 0 };//1.57
      mountOffset = {-0.065, 0, 0.07};
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 1.5;
	minEnergy = 3.0;
	maxEnergy = 5.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };	
	sfxFire     = SoundSpinUpDisc;
	sfxActivate = SoundJetHeavy;
	sfxSpinUp = SoundSpinUpDisc;
	sfxReady    = Soundwindgust;
};

ItemData Cannon
{
	description = "Anarchy Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = CannonImage;
	price = 400;
	showWeaponBar = true;
};

function Cannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Anarchy Cannon]: <f2>Devloped by the .:(Anarchy):. Tribe A.K.A .:]Anarchy[:. Tribe (2000-2001)R.I.P | Laser Guided Madness.", 5);
}
function CannonImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("Laser1",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("BlasRocket",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("ShieldRocket",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}

$InvList[ChainRocket] = 1;
$RemoteInvList[ChainRocket] = 1;

$InvList[ChainRocketAmmo] = 1;
$RemoteInvList[ChainRocketAmmo] = 1;


ItemImageData R1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData R1
{
	description = "ETTR2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = R1Image;
	showWeaponBar = false;
};


ItemData ChainRocketAmmo
{	description = "ETTR Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData ChainRocketImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.15, 0.08, 0.01 }; 
	mountRotation = { 0, -1.575, 0};  
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	ammoType = ChainRocketAmmo;
	accuFire = true;
	sfxFire	= floatMineExplosion;
	sfxActivate = SoundTeleportPower;
	sfxReload = SoundMortarReload;
	sfxReady = SoundTeleportPower;
};

ItemData ChainRocket
{	heading = "f(Explosives)";
	description = "ETTR Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = ChainRocketImage;
	price = 350;
	showWeaponBar = true;
};

function ChainRocket::onMount(%player,%item)
{
	Player::mountItem(%player,R1,7);
}

function ChainRocket::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function R1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "[ETTR]: <f2>Electric Tracking Rocket");
}

function ChainRocketImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ChainRocket]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,3,"ETTR lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** ETTR lock detected - " @ %clientId @ "~waccess_denied.wav");
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[ChainRocket],1);
			}
			else
			{
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[ChainRocket],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[ChainRocket],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"ETTR out of ammo.~waccess_denied.wav");
}


ItemData LilRocketLAmmo
{
	description = "Scout Missiles";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData LilRocketLImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0; // Single Shot
	ammoType = LilRocketLAmmo;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData LilRocketL
{
	description = "Scout Missile Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = LilRocketLImage;
	price = 225;
	showWeaponBar = true;
};

function LilRocketLImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ScoutRocket1",%trans,%player,%vel);
	Projectile::spawnProjectile("ScoutRocket2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[LilRocketL],1);
}

function LilRocketL::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Scout Missile Launcher]: <f2>A rocket Launcher for light armors only", 5);
}

ItemData ScorpianAmmo
{
	description = "TRI Ammo";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ScorpianImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ScorpianAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.8;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Scorpian
{
	description = "Triple Threat";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = ScorpianImage;
	price = 500;
	showWeaponBar = true;
};

function FireScorpian(%player)
{
	echo("Firing Scorpian!");
	if($FiringScorpian[%player] == True)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ScorpianBullet",%trans,%player,%vel);
	}
	
	if($ScorpianFired[%player] < 2)
	{
		$ScorpianFired[%player]++;
		schedule("FireScorpian(" @ %player @ ");", 0.2);
	}
}

function ScorpianImage::onFire(%player,%slot)
{
	echo("Firing Scorpian!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ScorpianBullet",%trans,%player,%vel);
      Projectile::spawnProjectile("ScorpianBullet",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[Scorpian],1);

	$FiringScorpian[%player] = True;
	$ScorpianFired[%player] = 1;

	schedule("FireScorpian(" @ %player @ ");", 0.2);
}

function Scorpian::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Triple Threat]: <f2>Launches 3 Missiles at one time.", 5);
}

ItemData HydraAmmo
{
	description = "Fire Fly Missiles";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HydraImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = HydraAmmo;
	projectileType = HydraBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hydra
{
	description = "Fire Fly";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = HydraImage;
	price = 650;
	showWeaponBar = true;
};

function Hydra::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fire Fly]: <f2>Sends rapid fire missles at your foe.", 5);
}

ItemData BazookaAmmo
{
	description = "Impact Shells";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BazookaImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = BazookaAmmo;
	projectileType = BazookaBullet;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Bazooka
{
	description = "Impact Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = BazookaImage;
	price = 400;
	showWeaponBar = true;
};

function Bazooka::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Impact Mortar]: <f2>Explodes on contact.", 5);
}

ItemData EMPAmmo 
{ 
	description = "Kicker Shell"; 
	className = "Ammo"; 
	heading = "x(Ammo)"; 
	shapeFile = "mortarammo"; 
	shadowDetailMask = 4; 
	price = 50; 
}; 

ItemImageData EMPImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	weaponType = 0; 
	ammoType = EMPAmmo; 
	projectileType = EMPShell; 
	accuFire = false; 
	reloadTime = 0.5; 
	fireTime = 2.0; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.25, 0.25, 1.0 }; 
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload; 
	sfxReady = SoundLaserIdle; 
}; 

ItemData EMP 
{ 
	description = "Shock Wave Mortar"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sensorjamerpack"; 
	heading = "f(Explosives)"; 
	shadowDetailMask = 4; 
	imageType = EMPImage; 
	price = 425; 
	showWeaponBar = true; 
}; 
function EMP::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "[Shock Wave Mortar]:<f2> Give'em DA BOOT!", 5);
}

ItemData ClaymoreAmmo
{
	description = "Air Strike Ammo";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ClaymoreImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = ClaymoreAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Claymore
{
	description = "Air Strike";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = ClaymoreImage;
	price = 400;
	showWeaponBar = true;
};

function ClaymoreImage::onFire(%player,%slot)
{
	echo("Firing Claymore!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	Projectile::spawnProjectile("ClaymoreBullet1",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet2",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet3",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet4",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet5",%trans,%player,%vel);
      Projectile::spawnProjectile("ClaymoreBullet6",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[Claymore],1);
}

function Claymore::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Air Strike]: <f2>The weapon that makes you a one man Air raid.", 5);
}
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//+New Flak Cannon+
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
ItemImageData SrocketImage
{
   shapeFile  = "Grenadel";
	mountPoint = 0; 
	mountRotation = { 0, 1.575, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 0.3;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 20;
	//projectileType = Undefined;
	accuFire = true;
	sfxFire = SoundFiregrenade;
	sfxActivate = Soundfliercrash;
};

ItemData Srocket
{
   heading = "f(Explosives)";
	description = "Flak Launcher";
	className = "Weapon";
   shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SrocketImage;
	price = 666;
	showWeaponBar = true;
};

function Srocket::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "[Flak Launcher]: <f2>This Launcher has a projectile that when it impacts it throws up a cloud of debris that rips the foe apart.");
}

function SrocketImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Srocket]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Srocket],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("Nrocket",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
ItemData xgatlingammo
{
	description = "Hybrid Mortar Shells";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData XHChain1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -0.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };
	 ammoType = xgatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = HybridShell; 
}; 

ItemData XHChain1 
{ 
	description = "Thumper";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = XHChain1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData XHChain2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -1.1, -0.7, 0.5 };
	mountRotation = { 0, 0, 0 };

	 ammoType = xgatlingammo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = HybridShell; 
}; 

ItemData XHChain2 
{ 
	description = "Thumper";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = XHChain2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData XHChaingunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = xgatlingammo; 
	reloadTime = 0.0;
	fireTime = 0.3;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData XHChaingun
{ 
	description = "Hybrid Dual Mortar"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
     heading = "f(Explosives)"; 
	shadowDetailMask = 4; 
	imageType = XHChaingunImage; 
	price = 800; 
	showWeaponBar = true;
}; 

function XHChaingunImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "xgatlingammo", 0.5);   
		%num = Player::getItemCount(%player, "xgatlingammo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "xgatlingammo", 0);    
			else     
			Player::setItemCount(%player, "xgatlingammo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "xgatlingammo", 0);    
			else     
			Player::setItemCount(%player, "xgatlingammo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function XHChaingun::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "xgatlingammo");  
	Player::setItemCount(%player, "xgatlingammo", %num);  
	Player::mountItem(%player,XHChain1,4);  
	Player::mountItem(%player,XHChain2,5); 
} 

function XHChaingun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}

function XHChain2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "[Hybrid Dual Mortar]: <F2>Wicked Dual Mortar Action");
}
//------------------------------------------------
ItemData TBlastCannonAmmo
{	description = "Hybrid CannonShell";
	className = "Ammo";
	heading = "x(Ammo)";
	shapeFile = "mrtwig";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TBlastCannonImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = TBlastCannonAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket; //SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundBeaconActive;
};

ItemData TBlastCannon  
{	description = "Hybrid Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
  	heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = TBlastCannonImage; 
	price = 2000;
	showWeaponBar = true;
};

function TBlastCannon::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "[Hybrid Cannon]: <f2>A very deadly Hybrid weapon,Only a Hybrid could handle this much power");
}
function TBlastCannonImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[TBlastCannon]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{	//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Player::decItemCount(%player,$WeaponAmmo[TBlastCannon],1);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
            Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("BlastCannonShot",%trans,%player,%vel);
	}
	else
	{	Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Hybrid Cannon");
	}
}

$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6; 

ItemData TankRPGAmmo 
{	description = "Hybrid Quad RPGs"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "x(Ammo)"; 
	shadowDetailMask = 4; 
	price = 12; 
}; 

ItemImageData TankRPGLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TankRPGAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TankRPGLauncher 
{	description = "Hybrid Quad RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, 1.1, 0}; 
	hudIcon = "chain"; 
	heading = "f(Explosives)"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncherImage; 
	price = 5500; 
	showWeaponBar = true; 
};

ItemImageData TankRPGLauncher2Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher2 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData TankRPGLauncher3Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher3 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData TankRPGLauncher4Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher4 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6;

function TankRPGLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TankRPGLauncher2,$TankRPGSlotA); 
	Player::mountItem(%player,TankRPGLauncher3,$TankRPGSlotB); 
	Player::mountItem(%player,TankRPGLauncher4,$TankRPGSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "[Hybrid Quad RPG]: <f2>Launches 4 RPG Missiles at one time,Mass destruction with some flare.");
}

function TankRPGLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankRPGSlotA);
	Player::unmountItem(%player,$TankRPGSlotB);	 
	Player::unmountItem(%player,$TankRPGSlotC);
}

function TankRPGLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TankRPGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPG",%trans,%player,%vel,%player); 
	if(!$FiringTankRPGLauncher[%client]) 
		CheckTankRPGLauncher(%client, %player); 
}

function TankRPGLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankRPGLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckTankRPGLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankRPGLauncher")) 
	{	Player::trigger(%player,$TankRPGSlotA,true);
		Player::trigger(%player,$TankRPGSlotB,true);
		Player::trigger(%player,$TankRPGSlotC,true); 
		schedule("CheckTankRPGLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringTankRPGLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$TankRPGSlotA,false); 
		Player::trigger(%player,$TankRPGSlotB,false); 
		Player::trigger(%player,$TankRPGSlotC,false); 
		$FiringTankRPGLauncher[%client] = false; 
	} 
}


$TRocketLauncherSlotA=4;
$TRocketLauncherSlotB=7;
$TRocketLauncherSlotC=6; 

ItemData TRocketLauncherAmmo
{	description = "Hybrid Dual Missiles";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData TRocketLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TRocketLauncher 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "mortar"; 
	heading = "f(Explosives)";  
	shadowDetailMask = 4; 
	imageType = TRocketLauncherImage; 
	price = 2500; 
	showWeaponBar = true; 
}; 

ItemImageData TRocketLauncher2Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};	

ItemData TRocketLauncher2 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData TRocketLauncher3Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData TRocketLauncher3 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData TRocketLauncher4Image 
{	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData TRocketLauncher4 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

//  Begin TRocketLauncher New Fire Function By: Armagedon
                     
function TRocketLauncherImage::onFire(%player, %slot) 
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[TRocketLauncher]);
	if(%AmmoCount)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		// ------- Second Projectile Placement --------
		
		%pos=gamebase::getposition(%player);
		%rot=gamebase::getrotation(%player);
		%vec=Vector::getFromRot(%rot);
		
		%vec1=getWord(%vec,0);
		%vec2=getWord(%vec,1);
		
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=getWord(%trans,3);
		%pos5=getWord(%trans,4);
		%pos6=getWord(%trans,5);
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9) + %vec2;
		%pos11=getWord(%trans,10) - %vec1;
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
		// ----- End of Second Projectile Placement -----
		
		if(GameBase::getLOSInfo(%player,1500))
		{	
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("TankMissile",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("TankMissile",%trans2,%player,%vel,$los::object);
				Client::sendMessage(%client,3,"Missile lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
				if(!$MDFiringTRocketLauncher[%client]) 
					MDCheckTRocketLauncher(%client, %player);
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
			}
			else
			{
				Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,%target);
				Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,%target);
				if(!$MDFiringTRocketLauncher[%client]) 
					MDCheckTRocketLauncher(%client, %player); 
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
			}
		}
		else
		{
			Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,%target);
			Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,%target);
			if(!$MDFiringTRocketLauncher[%client]) 
				MDCheckTRocketLauncher(%client, %player); 
			//GiveKickBack(%player, 125, 1);
			Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
		}
	}
	else
		Client::sendMessage(%client,0,"Hybrid Dual Missile Launcher is out of ammo.~waccess_denied.wav");
}

function TRocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function TRocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TRocketLauncher2,$TRocketLauncherSlotA); 
	Player::mountItem(%player,TRocketLauncher3,$TRocketLauncherSlotB); 
	Player::mountItem(%player,TRocketLauncher4,$TRocketLauncherSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "[Hybrid Dual Launcher]: <f2>This duel Launcher also has a heat sink device for added destruction.");  
}

function TRocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TRocketLauncherSlotA);
	Player::unmountItem(%player,$TRocketLauncherSlotB);	 
	Player::unmountItem(%player,$TRocketLauncherSlotC);
}

function MDCheckTRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TRocketLauncher")) 
	{	Player::trigger(%player,$TRocketLauncherSlotA,true);
		Player::trigger(%player,$TRocketLauncherSlotB,true);
		Player::trigger(%player,$TRocketLauncherSlotC,true);
		schedule("MDCheckTRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringTRocketLauncher[%client] = true;
	} 
	else 
	{	Player::trigger(%player,$TRocketLauncherSlotA,false); 
		Player::trigger(%player,$TRocketLauncherSlotB,false); 
		Player::trigger(%player,$TRocketLauncherSlotC,false); 
		$MDFiringTRocketLauncher[%client] = false; 
	} 
}

ItemImageData MetreonImage
{
	shapeFile = "mortargun";
	projectileType = MetreonBullet;
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.5;
	minEnergy = 10;
	maxEnergy = 20;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMissileTurretOff;
	sfxReady = SoundlaserIdle;
};

ItemData Metreon
{
	description = "Fusion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disc";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = MetreonImage;
	price = 1500;
	showWeaponBar = true;
};

function Metreon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Fusion Cannon]: <f2>Another weapon that uses the Fusion power,This is by far the best fusion weapon.", 5);
}

ItemData RepairShellAmmo
{
	description = "+M+ Shells";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 25;
};

ItemImageData RepairShellImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RepairShellAmmo;
	projectileType = RepairShellBullet;
	accuFire = false;
	reloadTime = 1.0;
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

ItemData RepairShell
{
	description = "+M+ Launcher";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = RepairShellImage;
	price = 400;
	showWeaponBar = true;
};

function RepairShell::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[+M+ Launcher]: <f2>Repairs anything 100% as long as Team Damage is on.", 5);
}

ItemData EnergyBallAmmo
{
	description = "Time Bombs";
	className = "Ammo";
   heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData EnergyBallImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = EnergyBallAmmo;
	projectileType = EnergyBallBullet;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData EnergyBall
{
	description = "Time Bomb Lobber";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "mortar";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = EnergyBallImage;
	price = 350;
	showWeaponBar = true;
};

function EnergyBall::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Time Bomb Launcher]: <f2>Drops Mortars that explode after 10 seconds after the time of the drop.", 5);
}
//----------------------------------------------------------------------------
ItemData DiscLauncherAmmo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 20;
}; 

ItemData DiscLauncher1Ammo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
};

ItemData DiscLauncher2Ammo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
}; 

ItemImageData DiscLauncher1Image 
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	ammoType = DiscLauncher1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData DiscLauncher1
{	description = "Storm Hammer 11";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = DiscLauncher1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData DiscLauncher2Image
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0,1.57, 0 };
	ammoType = DiscLauncher2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData DiscLauncher2
{	description = "Storm Hammer 11";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = DiscLauncher2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData DiscLauncherImage
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = DiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher 
{	description = "Storm Hammer 11";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "b(Explosives)";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%imageSlot,%item)
{	
	%num = Player::getItemCount(%player, "DiscLauncherAmmo");
	Player::setItemCount(%player, "DiscLauncher1Ammo", %num);
	Player::mountItem(%player,DiscLauncher1,6);
 	Player::setItemCount(%player, "DiscLauncher2Ammo", %num);
 	Player::mountItem(%player,DiscLauncher2,7);
	%client = Player::getClient(%player);
	Bottomprint(%client, "[Storm Hammer 11]: <f2>This dual barreled discer packs a hell of a punch.");
}

function DiscLauncher::onUnmount(%player,%imageSlot)
{	
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
}

function DiscLauncherImage::onFire(%player, %slot)
{ 	
	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
	{	%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "DiscLauncherAmmo", 1);
		%num = Player::getItemCount(%player, "DiscLauncherAmmo");
		if(%client.hd == 0)
		{	%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "DiscLauncher1Ammo", 0);
			else 
				Player::setItemCount(%player, "DiscLauncher1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{	%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "DiscLauncher2Ammo", 0);
 			else
				Player::setItemCount(%player, "DiscLauncher2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	} 
}



ItemData AntimatterDiscLauncherAmmo
{
	description = "Projectile Mortars";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData AntimatterDiscLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 3; // DiscLauncher
	ammoType = AntimatterDiscLauncherAmmo;
	projectileType = AntimatterDiscLauncherBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.0;
	spinUpTime = 0.25;
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AntimatterDiscLauncher
{
	description = "Projectile Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disk";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = AntimatterDiscLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function AntimatterDiscLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Projectile Mortar]: <f2>Is an Updated virsion of the lobbing mortar.", 5);
}

ItemData UFCAmmo
{
	description = "Particle Shells";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData UFCImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = UFCAmmo;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.5;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData UFC
{
	description = "Partical Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = UFCImage;
	price = 150;
	showWeaponBar = true;
};

function UFCImage::onFire(%player,%slot)
{
	//echo("Firing UFC!");

	for(%i = 0; %i < 12; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("UFCPellet",%trans,%player,%vel);
	}

	Player::decItemCount(%player,$WeaponAmmo[UFC],1);
}

function UFC::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Partical Shotgun]: <f2>Powerfull Bullets that can rip threw any armor in a hurry", 5);
}
 


ItemData TTGAmmo
{
	description = "Burning Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TTGImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0;
	ammoType = TTGAmmo;
	projectileType = TTGBullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData TTG
{
	description = "Burning Disc";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = TTGImage;
	price = 200;
	showWeaponBar = true;
};

function TTG::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Burning Disc]: <f2>Fires a high powered Disc at a Medium speed.", 5);
}


ItemData RailgunAmmo
{
	description = "Trigger Happy Ammo";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x(Ammo)";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 1; // Spinning
	ammoType = RailgunAmmo;
	projectileType = RailgunBullet;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	spinUpTime = 0;
	spinDownTime = 0;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun
{
	description = "Trigger Happy Rail";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "d(Guns)";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 450;
	showWeaponBar = true;
};

function Railgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Trigger Happy Rail]: <f2>Great weapon for Sniping and destroying anything in it's way.", 5);
}
//----------------------------------------------------------------------------
ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 50;
	maxEnergy = 1;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireLaserX;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Lazer X";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

function LaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Lazer X]: <f2>High power,Long range Need i say more.", 5);
}
//----------------------------------------------------------------------------
ItemImageData TauImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = TauLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 40;
	maxEnergy = 50;
	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 2.0, 2.0, 0.0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Tau
{
	description = "Radiation Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = TauImage;
	price = 1000;
	showWeaponBar = true;
};

function Tau::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Radiation Rifle]: <f2>You tend to glow after useing this.", 5);
}
//----------------------------------------------------------------------------
ItemImageData PhaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = PhaserBullet;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 1.0;
	minEnergy = 25;
	maxEnergy = 25;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Phaser
{
	description = "Disco Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = PhaserImage;
	price = 3000;
	showWeaponBar = true;
};

function Phaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Disco Rifle]: <f2>This weapon has 3 Uses,It can be like a Range finder,A Flash Light and a true killer.", 5);
}

ItemImageData TargetingLaserImage 
{	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = ToolBolt;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser 
{	description = "Engineer Repair Gun";
	className = "weapon";
	shapeFile = "repairgun";
	hudIcon = "targetlaser";
	heading = "b(New Age)";
	shadowDetailMask = 4;
	imageType = TargetingLaserImage;
	price = 50;
	showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Engineer Repair Gun]: <f2>Duh, repair gun... ugh....", 5);
}

//-------------------------------------
ItemImageData FlashlightImage
{
   shapeFile  = "rocket";
	mountPoint = 0;
      mountRotation = { -1.57, 1.57, 0 };
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0.01;

	minEnergy = 0.01;
	maxEnergy = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.2, 1, 0.2 };	

	projectileType = swordbullet;
	accuFire = true;

	sfxFire = SoundTeleportPower;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundTeleportPower;
	sfxSpinDown = SoundTeleportPower;
 };

ItemData Flashlight
{
	description   = "Sword Of Fire";
	className     = "weapon";
	shapeFile     = "Rocket";
	hudIcon       = "targetlaser";
      heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType     = FlashlightImage;
	price         = 250;
	showWeaponBar = true;
};

function Flashlight::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Sword Of Fire]: <f2>For X-Tremely Close combat.", 5);
}
//------------------------------------------------------------------------------
ItemImageData EnergyRifleImage
{
	shapeFile = "energygun";
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
   description = "ELF";
	shapeFile = "paintgun";
	hudIcon = "energygun";
   className = "Weapon";
   heading = "b(New Age)";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};

function EnergyRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[ELF]: <f2>An ELF at a high speed", 5);
}

//============================
ItemImageData TerawattImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.3, 0 };
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 3;
	spinDownTime = 0;
	fireTime = 0.001;
	minEnergy  = 10;
	maxEnergy = 15;  // Energy used/sec for sustained weapons
	projectileType = CannonLaser;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 3, 0 };
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundTeleportPower;
	sfxSpinDown = SoundTeleportPower;
};

ItemData Terawatt
{
   description = "Grazer Cannon";
	shapeFile = "mortargun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "c(Energized)";
   shadowDetailMask = 4;
   imageType = TerawattImage;
	showWeaponBar = true;
   price = 500;
};

function Terawatt::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,LaserCannonT,5); 
	Player::mountItem(%player,LaserCannonL,6); 
	Player::mountItem(%player,LaserCannonR,7); 
}

function LaserCannonT::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Grazer Cannon]: <f2>All other lasers dont compair to this wicked beast", 5);
}

function Terawatt::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5); 
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7); 
}

ItemImageData LaserCannonTImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0.2 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserCannonT
{
	description = "Laser Cannon Top";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "sniper";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LaserCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData LaserCannonLImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, -2.0934, 0 };
	mountOffset = { -0.1, 0, 0.05};
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserCannonL
{
	description = "Laser Cannon Left";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "sniper";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LaserCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData LaserCannonRImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 2.0934, 0 };
	mountOffset = { 0.1, 0, 0.05 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserCannonR
{
	description = "Laser Cannon Right";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = true;
	hudIcon = "chain";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LaserCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};
//============================
ItemImageData GrapplingImage
{
   shapeFile = "mortargun";
   mountPoint = 0;
   weaponType = 2;  // Sustained
   projectileType = TractorBeam;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;	
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Grappling
{
  className = "Weapon";
  description = "Grappling Beam";
  heading = "c(Energized)";
  hudIcon = "energyRifle";
  imageType = GrapplingImage;
  price = 225;
  shadowDetailMask = 4;
  shapeFile = "mortargun";
  showWeaponBar = true;
};

function Grappling::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "[Grappling Beam]: <f2>More of a Tool then it is a weapon.", 5);
}

ItemImageData KickerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; 
      minEnergy = 25;
	maxEnergy = 40;//26;++++++++++++++++++++++++++++
	projectileType = KickerBullet;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundGeneratorPower; //+++++++++++++++++++++++++++++++++++
};

ItemData Kicker
{
	description = "Kicker Blaster";
	className = "Weapon";
	shapeFile = "grenadeL";
 	hudIcon = "plasma";
      heading = "c(Energized)";
 	shadowDetailMask = 4;
	imageType = KickerImage;
	price = 450;
	showWeaponBar = true;
};

function Kicker::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Kicker Blaster]: <f2>Blast them off the map!.", 5);
}

ItemImageData GluonImage
{
	shapeFile = "Plasma";
	mountPoint = 0;
                 mountoffset = { 0, 0, -0.1 };
                 mountrotation = { 0, 1.3, 0 };
	weaponType = 0; // Single Shot
	projectileType = SMLaser;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.1;
	minEnergy = 18;
	maxEnergy = 19;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gluon
{
	description = "Grazer Pistal";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "sniper";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = GluonImage;
	price = 400;
	showWeaponBar = true;
};

function Gluon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Grazer Pistar]: <f2>Nice for cutting shit into tiny pieces.", 5);
}

ItemImageData CutterImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; 
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.3;
	minEnergy = 3.0;
	maxEnergy = 5.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };	

	sfxFire     = Mitzi1;
	sfxActivate = SoundGrogFire;
	sfxSpinUp = SoundSpinUpDisc;
	sfxReady    = SoundmortarIdle;
};

ItemData Cutter
{
	description = "Anarchy Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = CutterImage;
	price = 600;
	showWeaponBar = true;
};

function Cutter::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Anarchy Rifle]: <f2>Nice hand held version of the anarchy cannon", 5);
}

function CutterImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("Laser1",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("BlasRocket2",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("ShieldRocket2",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}


ItemImageData GLaserImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
      mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 7, 0 }; 

	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = GatLaserBeam;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData GLaser
{
	description = "Lazer Gat";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = GLaserImage;
	price = 200;
	showWeaponBar = true;
};

function GLaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Lazer Gat]: <f2>Fast and furious.", 5);
}
//------------------------------------------------
ItemImageData Beam1Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam1
{
	description = "Beam1";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = Beam1Image;
	showWeaponBar = false;
};

ItemImageData Beam2Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam2
{
	description = "Beam2";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = Beam2Image;
	showWeaponBar = false;
};

ItemImageData Beam3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.15, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam3
{
	description = "Beam3";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = Beam3Image;
	showWeaponBar = false;
};

ItemImageData Beam4Image
{
	shapeFile = "GrenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Beam4
{
	description = "Beam4";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = Beam4Image;
	showWeaponBar = false;
};

ItemImageData BeamImage
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.3;
	accuFire = true;
	projectiletype = BeamLaser;
	minEnergy = 70;
	maxEnergy = 10; 
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire     = SoundMortarTurretOn;
      sfxreload   = SoundMortarReload;
	sfxActivate = SoundMortarTurretOff;
};

ItemData Beam
{
	description = "Hybrid Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "chain";
	heading = "c(Energized)";
	shadowDetailMask = 4;
	imageType = BeamImage;
	price = 900;
	showWeaponBar = true;
};

function Beam1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "[Hybrid Laser]: <f2>A New Weapon To the Hybrid Family.The King of Lasers.");
}

function Beam::onMount(%player,%item)
{
	Player::mountItem(%player, Beam1, 4);
	Player::mountItem(%player, Beam2, 5);
	Player::mountItem(%player, Beam3, 6);
	Player::mountItem(%player, Beam4, 7);
}

function Beam::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}
//==================================================================================================

ItemData RocketAmmo
{
	description = "PopCorn Ammo";
	className = "Ammo";
	heading = "x(Ammo)";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
}; 

ItemImageData RocketLauncherImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RocketAmmo;
	projectileType = ScatterBomb;
	accuFire = false;
	mountRotation = { 0, 1.57, 0 };
	mountOffset = {-0.065, 0, 0.07}; 
	reloadTime = 0.55;
	fireTime = 2.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = debrisSmallExplosion; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData RocketLauncher 
{
	description = "PopCorn Grenade";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "f(Explosives)";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 420;
	showWeaponBar = true;
};

function RocketLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[PopCorn Grenade]: <f2>Pop pop POP!", 5);
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
// Backpacks
//----------------------------------------------------------------------------
ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}
//===============================================================================
//-------------------------------
ItemImageData EnergyPackImage
{
	shapeFile = "plasammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;

	minEnergy = -3;
 	maxEnergy = -5;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "plasammo";
	className = "Backpack";
   heading = "g(Backpacks)";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}
//----------------------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "g(Backpacks)";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	
//----------------------------------------------------------------------------
ItemImageData XTremePackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	minEnergy = -15; // This is where it negates the armors jet drain. By in creasing its recharge rate.
 	maxEnergy = -20; // This is where it negates the armors jet drain. By in creasing its recharge rate.
	firstPerson = false;
};

ItemData XTremePack
{
	description = "Jet Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = "g(Backpacks)";
	shadowDetailMask = 4;
	imageType = XTremePackImage;
	price = 550;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function XTremePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function XTremePack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function XTremePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

function XTremePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
ItemImageData ShieldPackImage
{
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shield";
	className = "Backpack";
   heading = "g(Backpacks)";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
//----------------------------------------------------------------------------
ItemImageData StealthShieldPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 6;
  maxEnergy = 9;
  sfxFire = SoundShieldOn;
  firstPerson = false;
};

ItemData StealthShieldPack 
{
  description = "Stealth Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = "g(Backpacks)";
  shadowDetailMask = 4;
  imageType = StealthShieldPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};
function StealthShieldPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Stealth Pack On");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),0,"Stealth Pack Off");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
}
//----------------------------------------------------------------------------
ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "g(Backpacks)";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}
//----------------------------------------------------------------------------
ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "g(Backpacks)";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 7 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//----------------------------------------------------------------------------
// P-Inv Code By: Armagedon (cus hes koo)
//============================================================================
ItemImageData DeployableInvPackImage
{
	shapeFile = "enerpad";
	mountPoint = 2;
	mountOffset = { 0, -0.12, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "P-Inventory";
	shapeFile = "enerpad";
	className = "Backpack";
	heading = "h(Deployables)";
	imageType = DeployableInvPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableInvPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if(DeployableInvPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				if(checkDeployArea(%client,$los::position)) {
					if(%client.hasDeployableInvPack == "") {
						%InvName = %Name@"'s P-Inventory Station";
						%LOS = $los::object;
						%inv = newObject("enerpad","StaticShape","PInvStation",true);
 	 		         		addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						%NewPos = Vector::add($los::position,"0 0 -0.35");
						//%rot = Vector::add(GameBase::getRotation(%player),"1.5 0 0");
						%rot = GameBase::getRotation(%player);
						GameBase::setPosition(%inv,%NewPos);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%InvName);
						Client::sendMessage(%client,0,"P-Inventory station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DeployableInvPack"]++;
						%client.hasDeployableInvPack = %inv;
						%inv.deployer = %client;
						echo("MSG: ",%client," deployed a P-Inventory Station");
						return true;
					}
					else
						Client::sendMessage(%client,0,"You already have a P-Inventory Station!");
				}
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on Buildings or Terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function DeployableInvPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc><f2>Perfect for all of those <f1>HARD WORKING ENGINEERS.");
}

StaticShapeData PInvStation
{
	description = "Personal Inv Unit";
	shapeFile = "enerpad";
	className = "DeployableStation";
	maxDamage = 1.0;
	sequenceSound[0] = { "idle", SoundBeaconActive };
	sequenceSound[1] = { "busy", SoundUseCommandStation };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpSmall;
};

function PInvStation::onAdd(%this)
{
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "P-Inventory Station");
	%this.Energy = $TeamEnergy[Client::getTeam(%this.deployer)];
	GameBase::playSequence(%this,1,"busy");
	schedule("GameBase::stopSequence("@%this@","@1@");",1.5);
	schedule("GameBase::playSequence("@%this@","@0@","@"idle"@");",1.5);
	schedule(%this.deployed = 1,1.8);
}

function PInvStation::onEnabled(%this)
{
	GameBase::playSequence(%this,0,"idle");
}

function PInvStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
}

function PInvStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"busy");
		echo("Activate " @ %this);
 		InventoryStation::onResupply(%this,"InvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}

function PInvStation::onCollision(%this,%object)
{
	%client = Player::getClient(%object);
	%obj = getObjectType(%object);
	if(%obj == "Player" && isPlayerBusy(%object) == 0) {
		if(%this.deployer == %client) {
			if(GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
				if(AreGod(%client) == true)
					Client::setItemShopping(%client,Ultra);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
		else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,1,"--ACCESS DENIED-- this is a personal station ~waccess_denied.wav");
			}
		}
	}
}

function PInvStation::onDestroyed(%this)
{
	%this.deployer.hasDeployableInvPack = "";
	Station::onDestroyed(%this);
	Station::weaponCheck(%this);
}
///-------------------------------------
//----------------------------------------------------------------------------
$InvList[GunBuddyPack] = 1;
$RemoteInvList[GunBuddyPack] = 1;
$TeamItemMax[GunBuddyPack] = 10;
	$ItemMax[larmor, GunBuddyPack] = 1;
	$ItemMax[marmor, GunBuddyPack] = 1;
	$ItemMax[harmor, GunBuddyPack] = 1;
	$ItemMax[narmor, GunBuddyPack] = 1;
	$ItemMax[jarmor, GunBuddyPack] = 1;
	$ItemMax[barmor, GunBuddyPack] = 1;
	$ItemMax[lfemale, GunBuddyPack] = 1;
	$ItemMax[mfemale, GunBuddyPack] = 1;
//----------------------------------------------------------------------------															
ItemImageData GunBuddyPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData GunBuddyPack
{
	description = "Deployable Drone";
	shapeFile = "larmor";
	className = "Backpack";
	heading = "h(Deployables)";
	imageType = GunBuddyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GunBuddyPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function GunBuddyPack::onDeploy(%player,%item,%pos)
{
	if(GunBuddyPack::deployShape(%player,%item) && $Friends != 1)
		Player::decItemCount(%player,%item);
}

function GunBuddyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%Name = Client::getName(%client);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && $Friends != 1) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%Data = GameBase::getDataName($los::object);
			echo(%obj@", type: "@%Data);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				%LOS = $los::object;
				%num = $TeamItemCount[GameBase::getTeam(%player)@"GunBuddyPack"];
				%AIName = %Name@" ";
				if(Ai::spawn(%AIName,player::getarmor(%player),$los::position,"0 0 0") != "false") {
					%AIid = AI::getId(%AIName);
					%AIid.Owner = %player;
					GameBase::setRotation(%AIid,GameBase::getRotation(%client));
					GameBase::setTeam(%AIid,GameBase::getTeam(%player));
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ "GunBuddyPack"]++;
					%CurWeap = Player::getMountedItem(%player,$WeaponSlot);
					Player::setItemCount(%AIid,1,%CurWeap);
					Player::mountItem(%AIid,%CurWeap, 4);
					GameBase::startFadeOut(%client);
					Client::sendMessage(%client,3,"Drone Deployed Get To Work");
					if($Friends)
						return true;
					schedule("Player::setAnimation("@%AIid@","@38@");",5,%AIid);
					schedule("OverHeatBoom("@%AIid@");",20.0);
					schedule("GameBase::startFadeIn("@%player@");",$AIliveTime);
					return true;
				}
				else
					Client::sendMessage(%client,0,"Could Not add Drone, possibly because you already have one");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on buildings or terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function GunBuddyPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>Deploy your Drone to confuse enemies when doing a task");
}
//--------------------------------------
ItemImageData KickerTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData KickerTurretPack
{
	description = "Kicker Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "h(Deployable)";
	imageType = KickerTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function KickerTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function KickerTurretPack::onDeploy(%player,%item,%pos)
{
	if (KickerTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function KickerTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",KickerTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Kicker Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Kicker Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "KickerTurretPack"]++;
					echo("MSG: ",%client," deployed a Kicker Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//--------------------------------------
ItemImageData FireFlyTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FireFlyTurretPack
{
	description = "Fire Fly Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "h(Deployable)";
	imageType = FireFlyTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FireFlyTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function FireFlyTurretPack::onDeploy(%player,%item,%pos)
{
	if (FireFlyTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function FireFlyTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteturret","Turret",FireFlyTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Fire Fly Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Fire Fly Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "FireFlyTurretPack"]++;
					echo("MSG: ",%client," deployed a Fire Fly Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//=====================================
ItemImageData ARPGTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ARPGTurretPack
{
	description = "ARPG Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "h(Deployable)";
	imageType = ARPGTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ARPGTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ARPGTurretPack::onDeploy(%player,%item,%pos)
{
	if (ARPGTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function ARPGTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",ARPGTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"ARPG Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ARPG Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "ARPGTurretPack"]++;
					echo("MSG: ",%client," deployed a ARPG Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////
ItemImageData 	MeltTurretPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData MeltTurretPack
{
        description = "Melt Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = "h(Deployables)";
        imageType = MeltTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function MeltTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MeltTurretPack::onDeploy(%player,%item,%pos)
{
	if (MeltTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MeltTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",MeltTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Melt Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Melt Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MeltTurretPack"]++;
					echo("MSG: ",%client," deployed a Melt Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////
ItemImageData 	RailTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData RailTurretPack
{
        description = "Rail Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
      heading = "h(Deployables)";
        imageType = RailTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function RailTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RailTurretPack::onDeploy(%player,%item,%pos)
{
	if (RailTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function RailTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",RailTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Rail Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Rail Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "RailTurretPack"]++;
					echo("MSG: ",%client," deployed a Rail Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
///-----------------------------------------------
ItemImageData 	LaserTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData LaserTurretPack
{
        description = "Laser Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
      heading = "h(Deployables)";
        imageType = LaserTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function LaserTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Laser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretPack"]++;
					echo("MSG: ",%client," deployed a Laser Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
///-----------------------------------------------
$TeamItemMax[door5x5pack] = 100;
$ItemMax[larmor, door5x5pack] = 1;
$ItemMax[lfemale, door5x5pack] = 1;
$ItemMax[marmor, door5x5pack] = 1;
$ItemMax[mfemale, door5x5pack] = 1;
$ItemMax[harmor, door5x5pack] = 1;
///-----------------------------------------------
ItemImageData door5x5packImage
{
        //shapeFile = "forcefield_5x5";
        shapeFile = "armorkit";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.375, 0, 0 };
        mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData door5x5pack
{
        description = "Small Force Field Door";
        //shapeFile = "forcefield_5x5";
        shapeFile = "armorkit";//
        className = "Backpack";
        heading = "h(Deployables)";
        imageType = door5x5packImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function door5x5pack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function door5x5pack::onDeploy(%player,%item,%pos)
{
        if (door5x5pack::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function door5x5pack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("door5x5pack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"5x5 FFD#"@ $totalNumBlue++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"5x5 FFD deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "door5x5pack"]++;$blue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a 5x5 FFD");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Nope wrong asshole.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
///-----------------------------------------------
StaticShapeData doorfivebyfiveForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";//
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Blue Door";
};
function doorfivebyfiveForceFieldShape::Destruct(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
}
function doorfivebyfiveForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfivebyfiveForceFieldShape::openDoor(%this);
return;
}
function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}
function doorfivebyfiveForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",2);
}
///-----------------------------------------------
$ItemMax[larmor, door4x14pack] = 1;
$ItemMax[lfemale, door4x14pack] = 1;
$ItemMax[marmor, door4x14pack] = 1;
$ItemMax[mfemale, door4x14pack] = 1;
$ItemMax[harmor, door4x14pack] = 1;
$TeamItemMax[door4x14pack] = 100;
///-----------------------------------------------
ItemImageData door4x14packImage
{
        //shapeFile = "forcefield_4x14";
        shapeFile = "ammo2";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.25, 0, 0 };
        mountRotation = { 1.57, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData door4x14pack
{
        description = "Large Force Field Doo";
        //shapeFile = "forcefield_4x14";
        shapeFile = "ammo2";//AmmoPack
        className = "Backpack";
        heading = "h(Depolyables)";//          heading = "h.:(Deployables):."; 
        imageType = door4x14packImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function door4x14pack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function door4x14pack::onDeploy(%player,%item,%pos)
{
        if (door4x14pack::deployShape(%player,%item) && !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function door4x14pack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("door4x14pack","StaticShape",BigBlueDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x14 FFD#"@ $totalNumBigBlue++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"4x14 FFD deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "door4x14pack"]++;
						    $BigBlue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a 4x14 FFD");
                                        return true;

                        }
                       else   {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Too far away.");

                        }

         }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
StaticShapeData BigBlueDoorShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "[4x14 FFD]";
};

function BigBlueDoorShape::Destruct(%this)
      {BigBlueDoorShape::doDamage(%this);}

function BigBlueDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BigBlueDoorShape::onDestroyed(%this)
{	BigBlueDoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}

function BigBlueDoorShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
	return;
}
		%c = Player::getClient(%obj);
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		if(%fieldTeam != %playerTeam)
		{return;}
			BigBlueDoorShape::openDoor(%this);return;
}

function BigBlueDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BigBlueDoorShape::closeDoor("@%this@");",4);
}

function BigBlueDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function BigBlueDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BigBlueDoorShape::closeDoor("@%this@");",2);
}
///-----------------------------------------------
$ItemMax[harmor, BlastWall] = 1;
$ItemMax[larmor, BlastWall] = 1;
$ItemMax[lfemale, BlastWall] = 1;
$ItemMax[marmor, BlastWall] = 1;
$ItemMax[mfemale, BlastWall] = 1;
///-----------------------------------------------
$TeamItemMax[BlastWall] = 200;
ItemImageData BlastWallImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastWall
{
        description = "Blast Wall";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
        heading = "h(Deployables)";
        imageType = BlastWallImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWall::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function BlastWall::onDeploy(%player,%item,%pos)
{
        if (BlastWall::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastWall::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Wall#"@ $totalNumBlast++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastWall"]++;$blast++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast wall");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
StaticShapeData BlastWallShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 60.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Portable Wall";
};
function BlastWallShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastWall"]--;

}
///-----------------------------------------------
$ItemMax[larmor, BlastDoorpack] = 1;
$ItemMax[lfemale, BlastDoorpack] = 1;
$ItemMax[marmor, BlastDoorpack] = 1;
$ItemMax[mfemale, BlastDoorpack] = 1;
$ItemMax[harmor, BlastDoorpack] = 1;
$TeamItemMax[BlastDoorpack] = 100;
///-----------------------------------------------
ItemImageData BlastDoorpackImage
{
        //shapeFile = "newdoor5";
        shapeFile = "ammo2";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.25, 0, 0 };
        mountRotation = { 1.57, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastDoorpack
{
        description = "Blast Door";
        //shapeFile = "newdoor5";
        shapeFile = "ammo2";//AmmoPack
        className = "Backpack";
        heading = "h(Depolyables)"; 
        imageType = BlastDoorpackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastDoorpack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function BlastDoorpack::onDeploy(%player,%item,%pos)
{
        if (BlastDoorpack::deployShape(%player,%item) && !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastDoorpack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastDoorpack","StaticShape",BlastDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Blast Door#"@ $totalNumBlastDoor++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Blast Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorpack"]++;
						    $BigBlue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast Door");
                                        return true;

                        }
                       else   {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Too far away.");

                        }

         }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
StaticShapeData BlastDoorShape
{
className = "newdoor5";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "[Blast Door]";
};

function BlastDoorShape::Destruct(%this)
      {BlastDoorShape::doDamage(%this);}

function BlastDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BlastDoorShape::onDestroyed(%this)
{	BlastDoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastDoor"]--;
}

function BlastDoorShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
	return;
}
		%c = Player::getClient(%obj);
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		if(%fieldTeam != %playerTeam)
		{return;}
			BlastDoorShape::openDoor(%this);return;
}

function BlastDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",SoundPlasmaTurretTurn,0);",0.10);
schedule("BlastDoorShape::closeDoor("@%this@");",4);
}

function BlastDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",SoundPlasmaTurretOff,0);",0.10);

}
///-----------------------------------------------
$ItemMax[harmor, plat] = 1;
$ItemMax[larmor, plat] = 1;
$ItemMax[lfemale, plat] = 1;
$ItemMax[marmor, plat] = 1;
$ItemMax[mfemale, plat] = 1;
///-----------------------------------------------
$TeamItemMax[plat] = 2000;
ItemImageData platImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData plat
{
        description = "Blast Floor";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
         heading = "h(Deployables)";
        imageType = platImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function plat::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function plat::onDeploy(%player,%item,%pos)
{
        if (plat::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function plat::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %prot = GameBase::getRotation(%player);
					  %xRot = getWord(%prot,0);
					  %yRot = getWord(%prot,1);
					  %zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						%rot = GameBase::getRotation(%player);//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
					}
					else {
						%rot = GameBase::getRotation(%player);//other
					}
				}

                                        %camera = newObject("plat","StaticShape",platShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Sonic Floor#"@ $totalNumPlat++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Sonic Floor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "plat"]++;$Plat++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Sonic Floor");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData platShape
{
        shapeFile = "elevator16X16_octo";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = defaultDebrisLarge;
        maxDamage = 25.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "[Sonic Floor]";
};

function platShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "plat"]--;

}
//----------------------------------------------------------------------------
ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "h(Deployables)";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//--------------------------------------------------------
ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "h(Deployables)";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}
//----------------------------------------------------------------------------
ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "h(Deployables)";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}
//----------------------------------------------------------------------------
ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Spy Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = "h(Deployables)";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//----------------------------------------------------------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "j(Misc)";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}
//----------------------------------------------------------------------------
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "j(Misc)";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//----------------------------------------------------------------------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "j(Misc)";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "j(Misc)";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

//----------------------------------------------------------------------------
function Item::deployShape(%player,%name,%shape,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%sensor = newObject("","Sensor",%shape,true); 
	addToSet("MissionCleanup", %sensor); 
	GameBase::setTeam(%sensor,GameBase::getTeam(%player)); 
	GameBase::setPosition(%sensor,$los::position); 
	Gamebase::setMapName(%sensor,%name); 
	Client::sendMessage(%client,0,%item.description @ " deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a ",%name); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can cnot be deployed on players!"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); 
	return false; 
	} 
//----------------------------------------------------------------------------
function checkDeployArea(%client,%pos) {return 1;} 

function CountObjects(%set,%name,%num) 
	{ 
	%count = 0; 
	for(%i=0;%i<%num;%i++) 
	{ 
	%obj=Group::getObject(%set,%i); 
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
	%count++; 
	} 
	return %count; 
	}
//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}

//----------------------------------------------------------------------------


function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor]) {
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "") {
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum) {
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon) {
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}
//---------------------------------------------------------
function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite") {
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {

		if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}

function Mission::reinitData()
{
      $TeamItemCount[0 @ TrackerTurretPack] = 0;
      $TeamItemCount[1 @ TrackerTurretPack] = 0;
      $TeamItemCount[2 @ TrackerTurretPack] = 0;
      $TeamItemCount[3 @ TrackerTurretPack] = 0;

	$TeamItemCount[0 @ AcceleratorDevicePack] = 0;
	$TeamItemCount[1 @ AcceleratorDevicePack] = 0;
	$TeamItemCount[2 @ AcceleratorDevicePack] = 0;
	$TeamItemCount[3 @ AcceleratorDevicePack] = 0;

	$TeamItemCount[0 @ AcceleratorDevice1Pack] = 0;
	$TeamItemCount[1 @ AcceleratorDevice1Pack] = 0;
	$TeamItemCount[2 @ AcceleratorDevice1Pack] = 0;
	$TeamItemCount[3 @ AcceleratorDevice1Pack] = 0;

	$TeamItemCount[0 @ RailTurretPack] = 0;
	$TeamItemCount[1 @ RailTurretPack] = 0;
	$TeamItemCount[2 @ RailTurretPack] = 0;
	$TeamItemCount[3 @ RailTurretPack] = 0;

	$TeamItemCount[0 @ ARPGTurretPack] = 0;
	$TeamItemCount[1 @ ARPGTurretPack] = 0;
	$TeamItemCount[2 @ ARPGTurretPack] = 0;
	$TeamItemCount[3 @ ARPGTurretPack] = 0;

	$TeamItemCount[0 @ MeltTurretPack] = 0;
	$TeamItemCount[1 @ MeltTurretPack] = 0;
	$TeamItemCount[2 @ MeltTurretPack] = 0;
	$TeamItemCount[3 @ MeltTurretPack] = 0;

	$TeamItemCount[0 @ ELFx2TurretPack] = 0;
	$TeamItemCount[1 @ ELFx2TurretPack] = 0;
	$TeamItemCount[2 @ ELFx2TurretPack] = 0;
	$TeamItemCount[3 @ ELFx2TurretPack] = 0;

	$TeamItemCount[0 @ LaserTurretPack] = 0;
	$TeamItemCount[1 @ LaserTurretPack] = 0;
	$TeamItemCount[2 @ LaserTurretPack] = 0;
	$TeamItemCount[3 @ LaserTurretPack] = 0;

	$TeamItemCount[0 @ KickerTurretPack] = 0;
	$TeamItemCount[1 @ KickerTurretPack] = 0;
	$TeamItemCount[2 @ KickerTurretPack] = 0;
	$TeamItemCount[3 @ KickerTurretPack] = 0;

	$TeamItemCount[0 @ FireFlyTurretPack] = 0;
	$TeamItemCount[1 @ FireFlyTurretPack] = 0;
	$TeamItemCount[2 @ FireFlyTurretPack] = 0;
	$TeamItemCount[3 @ FireFlyTurretPack] = 0;

	$TeamItemCount[0 @ blastdoorPack] = 0;
	$TeamItemCount[1 @ blastdoorPack] = 0;
	$TeamItemCount[2 @ blastdoorPack] = 0;
	$TeamItemCount[3 @ blastdoorPack] = 0;

	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[0 @ DeployableInvPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	$TeamItemCount[0 @ door5x5Pack] = 0;
	$TeamItemCount[1 @ door5x5Pack] = 0;
	$TeamItemCount[2 @ door5x5Pack] = 0;
	$TeamItemCount[3 @ door5x5Pack] = 0;

	$TeamItemCount[0 @ door4x14Pack] = 0;
	$TeamItemCount[1 @ door4x14Pack] = 0;
      $TeamItemCount[2 @ door4x14Pack] = 0;
      $TeamItemCount[3 @ door4x14Pack] = 0;

      $TeamItemCount[0 @ Plat] = 0;
      $TeamItemCount[1 @ Plat] = 0;
      $TeamItemCount[2 @ Plat] = 0;
      $TeamItemCount[3 @ Plat] = 0;

        $TeamItemCount[0 @ BomberVehicle] = 0;
        $TeamItemCount[1 @ BomberVehicle] = 0;
        $TeamItemCount[2 @ BomberVehicle] = 0;
        $TeamItemCount[3 @ BomberVehicle] = 0;

        $TeamItemCount[0 @ SR71Vehicle] = 0;
        $TeamItemCount[1 @ SR71Vehicle] = 0;
        $TeamItemCount[2 @ SR71Vehicle] = 0;
        $TeamItemCount[3 @ SR71Vehicle] = 0;

        $TeamItemCount[0 @ EnterpriseVehicle] = 0;
        $TeamItemCount[1 @ EnterpriseVehicle] = 0;
        $TeamItemCount[2 @ EnterpriseVehicle] = 0;
        $TeamItemCount[3 @ EnterpriseVehicle] = 0;

        $TeamItemCount[0 @ WarthogVehicle] = 0;
        $TeamItemCount[1 @ WarthogVehicle] = 0;
        $TeamItemCount[2 @ WarthogVehicle] = 0;
        $TeamItemCount[3 @ WarthogVehicle] = 0;

        $TeamItemCount[0 @ SpeedBikeVehicle] = 0;
        $TeamItemCount[1 @ SpeedBikeVehicle] = 0;
        $TeamItemCount[2 @ SpeedBikeVehicle] = 0;
        $TeamItemCount[3 @ SpeedBikeVehicle] = 0;

        $TeamItemCount[0 @ ColossusVehicle] = 0;
        $TeamItemCount[1 @ ColossusVehicle] = 0;
        $TeamItemCount[2 @ ColossusVehicle] = 0;
        $TeamItemCount[3 @ ColossusVehicle] = 0;

	$TeamItemCount[0 @ ArwingVehicle] = 0;
	$TeamItemCount[1 @ ArwingVehicle] = 0;
	$TeamItemCount[2 @ ArwingVehicle] = 0;
	$TeamItemCount[3 @ ArwingVehicle] = 0;
	}

	$totalNumCameras = 0;
	$totalNumTurrets = 0;


for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

/*
function RechargeAmmo(%player,%gunType)
{
	echo("Recharging ammo");
	%armor = Player::GetArmor(%player);
	if(%gunType == PulsePhaser && (Player::getItemCount(%player,PulsePhaser) > 0))
	{
		if(Player::getItemCount(%player,PulsePhaserAmmo) < $ItemMax[%armor,PulsePhaserAmmo])
		{
			Player::incItemCount(%player,PulsePhaser,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",1.0,%player);
		}
		else
			$PulsePhaserRecharging[%player] = False;
	}
}
echo("");
*/

//from Havoc mod
function dropClusters(%this, %count) {
	if(%count && %this) {
		%obj = newObject("","HandGrenade","Clus");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 15, true);

		%obj = newObject("","HandGrenade","Clus");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 10, true);

		%obj = newObject("","HandGrenade","Clus");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 12, true);

		%obj = newObject("","Handgrenade","Clus");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 1, true);

		%count--;
		schedule("dropClusters(" @ %this @ " , " @ %count @ ");",0.4,%this);
		return;
	} else
		$SClu = false;
}

//from Talon mod

/*
function BlastRifleImage::onFire(%player,%slot)
{
	%rawCharge = Player::getItemCount(%player,BlastAmmo);
	%charge = %rawCharge *= 0.2;
	if(%charge > 0)
	{
		for(%i=1; %i<%charge; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BlastShell",%trans,%player,%vel);
		}
		Player::setItemCount(%player,BlastAmmo,0);
		if($BlastRifleRecharging[%player] != True)
		{
			$BlastRifleRecharging[%player] = True;
			%guntype = BlastRifle;
			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.25,%player);
		}
	}
		else Client::sendMessage(Player::getClient(%player),0,"Pulse Phaser is out of ammo.");
}



