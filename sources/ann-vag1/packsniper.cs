$InvList[SniperPack] = 1;
$MobileInvList[SniperPack] = 1;
$RemoteInvList[SniperPack] = 1;
AddItem(SniperPack);

//----------------------------------------------------------------------------
// Weapon Packs
//----------------------------------------------------------------------------
ItemImageData SniperPackImage
{
	shapeFile = "sniper";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = -1;
	maxEnergy = -5;   // Energy used/sec for sustained weapons
  	mountOffset = { -0.1, -0.05, -0.05 };
  	mountRotation = { 0.585, 0, -1.57 };
	firstPerson = false;
};

ItemData SniperPack
{
	description = "Assassin Plus Pack";
	shapeFile = "sniper";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SniperPackImage;
	price = 1450;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SniperPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == PackRifle) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function SniperPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
	if(!%player.invulnerable)
		Player::mountItem(%player,PackRifle,$WeaponSlot);
	bottomprint(Player::getClient(%player), "<jc><f2>Using  Assassin Plus Pack", 2);
	}
}

function SniperPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == PackRifle) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the PackRifle
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

function SniperPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Assassin Jammer On");
	%rate = Player::getSensorSupression(%player) + 10;
	Player::setSensorSupression(%player,%rate);
}

function SniperPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Assassin Jammer Off");
	%rate = Player::getSensorSupression(%player) - 10;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

LaserData AssassinLaser
{
	laserBitmapName = "shex00.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.007;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

ItemImageData FakeLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData FakeLaser
{
	description = "FakeLaser";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = FakeLaserImage;
	showWeaponBar = false;
};

ItemImageData PackRifleImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.11 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = true;
	projectileType = AssAssinLaser;
	weaponType = 0; // Spinning
 	reloadTime = 1.2;
 	fireTime = 0.5;
 	minEnergy = 10;
 	maxEnergy = 60;
	lightType   = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 1, 0, 0 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireLaser;
	sfxSpinUp = SoundTeleportPower;
	sfxSpinDown = SoundTeleportPower;
};

ItemData PackRifle
{
	description = "Pack Rifle";
	shapeFile = "sniper";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = PackRifleImage;
	showInventory = false;
	price = 125;
   //validateShape = true;
};

function PackRifle::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,FakeLaser,5); 
	Player::trigger(%player,$BackpackSlot,true);
}

function PackRifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,5);  
	Player::trigger(%player,$BackpackSlot,false);
}
