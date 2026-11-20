$InvList[KShredder]=1;
$MobileInvList[KShredder]=1;
$RemoteInvList[KShredder]=1;

$InvList[KShredderAmmo]=1;
$MobileInvList[KShredderAmmo]=1;
$RemoteInvList[KShredderAmmo]=1;

$AutoUse[KShredder] = True;
$WeaponAmmo[KShredder] = KShredderAmmo;
$SellAmmo[KShredderAmmo] = 500;

addweapon(KShredder);
addAmmo(KShredder, KShredderAmmo, 15);

$KShredderSlotA=4;
$KShredderSlotB=7;
$KShredderSlotC=6;


ItemData KShredderAmmo 
{	description = "Tank Shredder Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData KShredderImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, -1.01, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = KShredderAmmo;
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

ItemData KShredder 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = KShredderImage;
	price = 7500;
	showWeaponBar = true;
};


ItemImageData KShredder2Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 1.01, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = KShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData KShredder2 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = KShredder2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData KShredder3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 1.501, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = KShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData KShredder3 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = KShredder3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData KShredder4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, -1.501, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = KShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData KShredder4 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = KShredder4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

// --------------------------------------- Firing Functions --------------------------------------

function MDCheckKShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "KShredder")) 
	{	Player::trigger(%player,$KShredderSlot,true);
		schedule("MDCheckKShredder(" @ %client @ "," @ %player @ ");",0.05);
		$MDFiringKShredder[%client] = true;
	}
	else
	{	Player::trigger(%player,$KShredderSlot,false);
		$MDFiringKShredder[%client] = false;
	}
}

function KShredderImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[KShredder],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShredderBullet",%trans,%player,%vel,%player);
	if(!$MDFiringKShredder[%client]) 
		MDCheckKShredder(%client, %player);
}

function KShredder::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, KShredder2, 0);
		Item::onDrop(%player,%item);
	}
}

function KShredder::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	Player::mountItem(%player,KShredder2,$KShredderSlotA);
	Player::mountItem(%player,KShredder3,$KShredderSlotB);
	Player::mountItem(%player,KShredder4,$KShredderSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Tank Shredder: <f2>You don't want to get in the way of this quad chaingun!");
}

function KShredder::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$KShredderSlotA);
	Player::unmountItem(%player,$KShredderSlotB);	 
	Player::unmountItem(%player,$KShredderSlotC);
}

function MDCheckKShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "KShredder")) 
	{	Player::trigger(%player,$KShredderSlotA,true);
		Player::trigger(%player,$KShredderSlotB,true);
		Player::trigger(%player,$KShredderSlotC,true);
		schedule("MDCheckKShredder(" @ %client @ "," @ %player @ ");",0.1);
		$MDFiringKShredder[%client] = true;
	}
	else 
	{	Player::trigger(%player,$KShredderSlotA,false);
		Player::trigger(%player,$KShredderSlotB,false);
		Player::trigger(%player,$KShredderSlotC,false);
		$MDFiringKShredder[%client] = false;
	}
}
