//fission cutter, terran, L
$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;
$AutoUse[Blaster] = False;
$WeaponAmmo[Blaster] = "";
$VehicleInvList[Blaster] = 1;

addWeapon(Blaster);

BulletData fusionCBolt
{
   bulletShapeName = "discb.dts";
   explosionTag = fusionboltExp;
   aimDeflection      = 0.002;
   damageClass        = 1;
   damageValue        = 0.12;
   explosionRadius    = 4;
   damageType         = $DeathDamageType;
   muzzleVelocity     = 800.0;
   totalTime          = 0.6;
   liveTime           = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
};

ItemImageData BlasterImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.1;
	fireTime = 0.1;
        projectileType = Undefined;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	sfxFire = SoundFirePlasma;
        sfxReload = SoundDiscReload;
	sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDiscSpin;
};

ItemData Blaster
{
   heading = $InvHead[ihWea];
	description = "Fission Cutter";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "disk";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 250;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fission Cutter: <f2>Fires blasts of fission that tear through metal.  A new design has been applied to this gun, making it the smallest hand held fission generator ever.");
}

function BlasterImage::onFire(%player, %slot) 
 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
 			Projectile::spawnProjectile("fusionCBolt",%trans,%player,%vel);
 }
