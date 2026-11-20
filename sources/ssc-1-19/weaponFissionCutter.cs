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
   explosionTag = bulletexp0;
   bulletHoleIndex = 0;
   damageClass        = 0;
   damageValue        = 0.12;
   damageType         = $BulletDamageType;
   muzzleVelocity     = 200.0;
   totalTime          = 4.5;
   liveTime           = 4.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;
   trailType = 1;
   trailWidth = 0.5;
   trailLength = 20.0;
   soundId = SoundJetLight;
};


ItemImageData BlasterImage
{
   shapeFile  = "disc";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.1;
	fireTime = 0.1;
        projectileType = fusionCBolt;
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
   shapeFile  = "disc";
	hudIcon = "disk";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 150;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fission Cutter: <f2>Fires razor sharp energy based disks that tear through metal");
}

