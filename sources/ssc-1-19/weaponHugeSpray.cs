//Big Huge Spray
$WeaponAmmo[Spray] = "";
$InvList[Spray] = 1;
$AutoUse[Spray] = True;
$RemoteInvList[Spray] = 1;
$VehicleInvList[Spray] = 1;

addWeapon(Spray);

//=====================================================================//=== Psionic Zap

BulletData SprayBolt
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = bulletExp2;
   aimDeflection      = 0.09;
   damageClass        = 0;
   damageValue        = 0.035;
   baseDamageType     = $ReaperDamageType;

   muzzleVelocity     = 70.0;
   totalTime          = 2.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
//   isVisible          = true;

   rotationPeriod = 1;
};

//=====================================================================//=== Psionic Spray

ItemImageData SprayImage
{
   shapeFile  = "snowplume";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 1.0;
	fireTime = 1.0;
	minEnergy = 40;
	maxEnergy = 50;

	projectileType = Undefined;
	accuFire = false;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Spray
{
   heading = $InvHead[ihPsi];
	description = "Needle Spines";
	className = "Weapon";
   shapeFile  = "sensor_small";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SprayImage;
	price = 700;
	showWeaponBar = true;
};

function Spray::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Needle Spines: This ability comes natural to Hydralisks, firing several spines that can puncture PlasSteel armors.");
}

function SprayImage::onFire(%player, %slot) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("SprayBolt",%trans,%player,%vel);
	}
