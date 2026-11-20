$InvList[Hellfire] = 1;
$MobileInvList[Hellfire] = 1;
$RemoteInvList[Hellfire] = 1;

$InvList[HellfireAmmo] = 1;
$MobileInvList[HellfireAmmo] = 1;
$RemoteInvList[HellfireAmmo] = 1;

$AutoUse[Hellfire] = False;
$SellAmmo[HellfireAmmo] = 5;
$WeaponAmmo[Hellfire] = HellfireAmmo;

addWeapon(Hellfire);
addAmmo(Hellfire, HellfireAmmo, 2);

ItemData HellfireAmmo
{	description = "Hellfire Missle Ammo";
	className = "Ammo";
	shapeFile = "mortarpack";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData HellfireImage
{	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = HellfireAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Hellfire
{	description = "Hellfire Missile";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HellfireImage;
	price = 900;
	showWeaponBar = true;
};

function Hellfire::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Hellfire Missile: <f2>Fires missiles with the fury of hell itself.");
}

function HellfireImage::onFire(%player, %slot)
{	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Hellfire]);
	if(%AmmoCount > 0)
	{	%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,3000))
		{	%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{	%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,0,"Hellfire lock acquired "@ %targetP @"~wtaunt10.wav");
				Client::sendMessage(%targeted,0,"Hellfire lock detected - " @ %clientId @ "~wono.wav");
				Projectile::spawnProjectile("HellfireMissile",%trans,%player,%vel,$los::object);
				//Projectile::spawnProjectile("HellfireMissile2",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[Hellfire],1);
			}
		else
		{	Projectile::spawnProjectile("HellfireRocket",%trans,%player,%vel,%player);
			//Projectile::spawnProjectile("HellfireMissileM",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[Hellfire],1);
		}
	}
	else
	{	Projectile::spawnProjectile("HellfireRocket",%trans,%player,%vel,%player);
		//Projectile::spawnProjectile("HellfireMissileM",%trans,%player,%vel,%player);
		Player::decItemCount(%player,$WeaponAmmo[Hellfire],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"Hellfire Launcher out of ammo.");
}
