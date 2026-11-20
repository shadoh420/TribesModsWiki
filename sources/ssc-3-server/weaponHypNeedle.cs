//Hyper Needle Spray, Used by Medics to disperse poision
$InvList[HypN] = 0;
$RemoteInvList[HypN] = 0;
$VehicleInvList[HypN] = 0;
$VehicleInvList[HypNAmmo] = 0;
$AutoUse[HypN] = False;
$WeaponAmmo[HypN] = HypNAmmo;
$SellAmmo[HypNAmmo] = 15;
$InvList[HypNAmmo] = 0;
$RemoteInvList[HypNAmmo] = 0;

addWeapon(HypN);
addAmmo(HypN, HypNAmmo, 4);

BulletData HypNNeedle
{
  bulletShapeName = "tracer.dts";
  explosionTag = bulletExpToxin;
  collisionRadius = 0;
  mass = 1.0;
  damageClass = 0;
  explosionRadius = 5;
  damageValue = 0.04;
  damageType = $ElectricityDamageType;
  kickBackStrength = 0;
  muzzleVelocity = 600;
//  terminalVelocity = 600;
  acceleration = 1.0;
  totalTime = 4.0;
  liveTime = 3.0;
  inheritedVelocityScale = 0.3;
};

BulletData HypN3Needle
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExpToxin;

   damageClass        = 1;
   damageValue        = 0.02;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.006;
   muzzleVelocity     = 400;
   totalTime          = 2.45;
   liveTime           = 2.45;
   lightRange         = 0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;
};

BulletData HypN2Needle
{
  bulletShapeName = "bullet.dts";
  explosionTag = bulletExpToxin;
  collisionRadius = 0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 8;
  damageValue = 0.025;
  damageType = $ElectricityDamageType;
  kickBackStrength = 10;
  muzzleVelocity = 700;
  terminalVelocity = 700;
  acceleration = 1;
  totalTime = 4;
  liveTime = 2;
  inheritedVelocityScale = 0.3;
};

ItemData HypNAmmo 
{
  description = "Spray Syringes";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 4;
};

ItemImageData HypNImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  ammoType = HypNAmmo;
  projectileType = Undefined;
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 0;
  lightTime = 0;
  lightColor = 
  {
    0.0, 0, 0 }
  ;
  sfxReload = SoundDryFire;
  sfxFire = SoundJetLight;
  sfxActivate = SoundPickUpWeapon;
};

ItemData HypN 
{
  description = "Biotoxin Spray";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "energyRifle";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = HypNImage;
  price = 200;
  showWeaponBar = true;
};

function HypNImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[HypN]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[HypN],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("HypN2Needle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypN3Needle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypN3Needle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypN3Needle",%trans,%player,%vel,team-1);
                        Projectile::spawnProjectile("HypNNeedle",%trans,%player,%vel,team-1);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

function HypN::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Hypodermic Spray: <f2>A spray of poison mixed in with several explosive agents forms a lethal rain.");
}