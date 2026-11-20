$InvList[KBlastCannon] = 1;
$MobileInvList[KBlastCannon] = 1;
$RemoteInvList[KBlastCannon] = 1;

$InvList[KBlastCannonAmmo] = 1;
$MobileInvList[KBlastCannonAmmo] = 1;
$RemoteInvList[KBlastCannonAmmo] = 1;

$AutoUse[KBlastCannon]	= True;
$WeaponAmmo[KBlastCannon] = KBlastCannonAmmo;
$SellAmmo[KBlastCannonAmmo] = 5;

AddWeapon(KBlastCannon);
AddAmmo(KBlastCannon, KBlastCannonAmmo, 3);

ItemData KBlastCannonAmmo
{	description = "Blast Cannon Shots";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mrtwig";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData KBlastCannonImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = KBlastCannonAmmo;
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

function KBlastCannonImage::onFire(%player,%slot) 
{	%Ammo = Player::getItemCount(%player, $WeaponAmmo[KBlastCannon]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{	//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Player::decItemCount(%player,$WeaponAmmo[KBlastCannon],1);
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
	{	Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Tank BlastCannon Cannon");
	}
}

ItemData KBlastCannon  
{	description = "Tank Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
  	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = KBlastCannonImage; 
	price = 2000;
	showWeaponBar = true;
};

function KBlastCannon::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Tank Blast Cannon: <f2>Only the Tank could wield this massive weapon.  It's a shotgun on crack!");
}
