$InvList[BabyNukeMortar] = 1;
$MobileInvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$InvList[BabyNukeAmmo] = 1;
$MobileInvList[BabyNukeAmmo] = 1;
$RemoteInvList[BabyNukeAmmo] = 1;

$AutoUse[BabyNukeMortar]= True;
$WeaponAmmo[BabyNukeMortar] = BabyNukeAmmo;
$SellAmmo[BabyNukeAmmo] = 25;

addWeapon(BabyNukeMortar);
addAmmo(BabyNukeMortar, BabyNukeAmmo, 1);

$BabyNukeMortarSlotA=4;

ItemData BabyNukeAmmo 
{
	description = "Nuclear Device";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData BabyNukeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.005, 0 };
	mountRotation = { 0, 0 , 0 };
	weaponType = 0; // Single Shot
	//projectileType = BabyNukeBomb;
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 2.0;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData BabyNukeMortar
{
	description = "Baby Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNukeImage;
	price = 1500;
	showWeaponBar = true;
};

ItemImageData BabyNuke2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.0365, 0, -0.035 };
	mountRotation = { 0, -1.575, 0 };
	weaponType = 0; // Single Shot
	//projectileType = BabyNukeBomb;
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 2.0;
	fireTime = 2.0;
};

ItemData BabyNukeMortar2
{
	description = "Baby Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNuke2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

function BabyNukeMortar::onMount(%player,%item) 
{
	Player::mountItem(%player,BabyNukeMortar2,$BabyNukeMortarSlotA);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "Baby Nuke Mortar: <f2>Throw this lil baby and watch them run for the hills.");
}

function BabyNukeMortar::onUnmount(%player,%item)
{
	Player::unmountItem(%player,$BabyNukeMortarSlotA);
}

function BabyNukeImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,BabyNukeAmmo,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("BabyNukeBomb",%trans,%player,%vel,%player);
	if(!%player.firingBabyNuke)
		FireBabyNukeMortar(%client, %player);
}

function FireBabyNukeMortar(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "BabyNukeMortar")) 
	{
		Player::trigger(%player,$BabyNukeMortarSlotA,true);
		schedule("FireBabyNukeMortar(" @ %client @ "," @ %player @ ");",0.1); 
		%player.firingBabyNuke = true;
	}
	else 
	{
		Player::trigger(%player,$BabyNukeMortarSlotA,false);
		%player.firingBabyNuke = false;
	}
}
