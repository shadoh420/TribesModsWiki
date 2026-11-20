//psionic storm, toss, H
$InvList[Demogun] = 1;
$RemoteInvList[Demogun] = 1;
$AutoUse[Demogun] = False;
$WeaponAmmo[Demogun] = "";
$VehicleInvList[Demogun] = 1;

addWeapon(Demogun);

BulletData DemoBurst
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = StormExp;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 13.0;
   damageValue        = 0.15;
   damageType         = $ReaperDamageType;
   aimDeflection      = 0.0035;
   muzzleVelocity     = 600.0;
   totalTime          = 0.8;
   liveTime           = 0.8;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
};

BulletData DemoBurst2
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = StormExp2;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 10.0;
   damageValue        = 0.15;
   damageType         = $ReaperDamageType;
   aimDeflection      = 0.0035;
   muzzleVelocity     = 600.0;
   totalTime          = 0.8;
   liveTime           = 0.8;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
};

ItemImageData DemoGunImage 
{
  shapeFile = "lflame";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1.5;
  fireTime = 2.0;
  minEnergy = 29;
  maxEnergy = 30;
  projectileType = Undefined;
  accuFire = false;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};

ItemData DemoGun 
{
  heading = $InvHead[ihWet];
  description = "Psionic Storm";
  className = "Weapon";
  shapeFile = "lflame";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = DemoGunImage;
  price = 550;
  showWeaponBar = true;
};

function DemoGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Psionic Storm: <f2>This weapon focuses time-space ripples into a storm of raw psychic energy that tears apart the minds of others");
}

function DemoGunImage::onFire(%player, %slot) 
{
 %energy = GameBase::getEnergy(%player);
	 if (%energy > 15)
	 {
		%client = GameBase::getOwnerClient(%player);
		%curren = GameBase::getEnergy(%player) - 16;
		GameBase::setEnergy(%player,%curren);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
                        Projectile::spawnProjectile("DemoBurst2",%trans,%player,%vel);
	}
}
