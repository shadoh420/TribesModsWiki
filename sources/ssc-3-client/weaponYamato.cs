//yamato, terran, H
$AutoUse[Vulcan] = False;
$SellAmmo[VulcanAmmo] = 100;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$InvList[Vulcan] = 1;
$InvList[VulcanAmmo] = 1;
$RemoteInvList[Vulcan] = 1;
$RemoteInvList[VulcanAmmo] = 1;
$VehicleInvList[Vulcan] = 1;
$VehicleInvList[VulcanAmmo] = 1;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

GrenadeData VulcanGren
{
  bulletShapeName = "grenade.dts";
  explosionTag = RocketExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.2;
  damageClass = 1;
  damageValue = 0.13;
  damageType = $PlasmaDamageType;
  explosionRadius = 15;
  kickBackStrength = 0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.05;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0.5;
  smokeName = "enex.dts";
  smokeDist = 5;
};

ItemData VulcanAmmo 
{
  description = "Yamato Fuel";
  className = "Ammo";
  shapeFile = "ammo1";
  heading = $InvHead[ihAmm];
  shadowDetailMask = 4;
  price = 1;
};

ItemImageData VulcanImage 
{
  shapeFile = "rocketlauncher";
  mountPoint = 0;
  weaponType = 0;
        mountOffset = 
        {
        -0.15, 0.0, 0.0 }
        ;
  reloadTime = 0.0;
  fireTime = 0.2;
  ammoType = VulcanAmmo;
  projectileType = VulcanGren;
  accuFire = false;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1 };  
  sfxFire = energyExplosion;
  sfxReload = SoundDryFire;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Vulcan 
{
  description = "Yamato Thrower";
  className = "Weapon";
  shapeFile = "rocketlauncher";
  hudIcon = "chain";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = VulcanImage;
  price = 500;
  showWeaponBar = true;
};

function Vulcan::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Yamato Thrower: <f2>Lobs the same type of energy as the battlecruiser, this weapon is a contender.");
}

function aVulcanImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Vulcan]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Vulcan],10);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("VulcanGren",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}
