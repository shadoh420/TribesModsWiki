//fission slicer, terran, M
$InvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;
$VehicleInvList[Plasmagun] = 1;
$AutoUse[PlasmaGun] = False;
$WeaponAmmo[PlasmaGun] = "";

addWeapon(PlasmaGun);

BulletData PlasmaBolt 
{
  bulletShapeName = "enbolt.dts";
  explosionTag = energyexp;
  damageClass = 1;
  damageValue = 0.05;
  damageType = $DeathDamageType;
  explosionRadius = 6.0;
  muzzleVelocity = 800.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 1.0;
  isVisible = True;
  soundId = SoundJetLight;
};

ItemImageData PlasmaGunImage
{
  shapeFile = "fission_slicer";
  mountPoint = 0;
  weaponType = 1;
  minEnergy = 8;
  maxEnergy = 2;
  projectileType = PlasmaBolt;
  accuFire = true;
  spinUpTime = 0.8;
  spinDownTime = 1.5;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 1, 0.2 };
  sfxFire = SoundJetHeavy;
  sfxReload = SoundDiscReload;
  sfxSpinUp = SoundSpinUp;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
  description = "Fission Splicer";
  className = "Weapon";
  shapeFile = "fission_slicer";
  hudIcon = "disk";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PlasmaGunImage;
  price = 350;
  showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Fission Splicer: <f2>A new design has been applied to the once useless fusion line of Terran weaponry, this weapons sports top quality Terran innovation.");
}

