//needle spines, zurg, M
$WeaponAmmo[Zap] = "";
$InvList[Zap] = 1;
$AutoUse[Zap] = True;
$RemoteInvList[Zap] = 1;
$VehicleInvList[Zap] = 1;

addWeapon(Zap);

//=====================================================================//=== Psionic Zap

BulletData ZapBolt
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp2;
   aimDeflection      = 0.02;
   damageClass        = 0;
   damageValue        = 0.26;
   baseDamageType     = $PsiDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = false;

   rotationPeriod = 1;
};

//=====================================================================//=== Psionic Zap

ItemImageData ZapImage
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

ItemData Zap
{
   heading = $InvHead[ihPsi];
	description = "Needle Spines";
	className = "Weapon";
   shapeFile  = "sensor_small";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ZapImage;
	price = 700;
	showWeaponBar = true;
};

function Zap::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Needle Spines: This ability comes natural to Hydralisks, firing several spines that can puncture PlasSteel armors.");
}

function ZapImage::onFire(%player, %slot) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Zap],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("ZapBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("ZapBolt",%trans,%player,%vel);
			Projectile::spawnProjectile("ZapBolt",%trans,%player,%vel);		
	}
