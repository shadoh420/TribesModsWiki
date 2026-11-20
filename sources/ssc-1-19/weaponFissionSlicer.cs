//fission slicer, terran, M
$InvList[PlasmaGun] = 1;
//$InvList[PlasmaAmmo] = 1;
$RemoteInvList[PlasmaGun] = 1;
//$RemoteInvList[PlasmaAmmo] = 1;
$VehicleInvList[Plasmagun] = 1;
//$VehicleInvList[PlasmaAmmo] = 1;
$AutoUse[PlasmaGun] = False;
//$SellAmmo[PlasmaAmmo] = 5;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;

addWeapon(PlasmaGun);
//addAmmo(PlasmaGun, PlasmaAmmo, 10);

BulletData PlasmaBolt 
{
  bulletShapeName = "discb.dts";
  explosionTag = bulletexp0;
  damageClass = 0;
  damageValue = 0.28;
  damageType = $BulletDamageType;
  bulletHoleIndex = 0;
  muzzleVelocity = 200.0;
  totalTime = 4.5;
  liveTime = 4.5;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 1.0;
  isVisible = True;
  soundId = SoundJetLight;
  trailType = 1;
  trailWidth = 0.5;
  trailLength = 25.0;
};
//
//ItemData PlasmaAmmo
//{
  //description = "Arclite Bolt";
  //heading = $InvHead[ihAmm];
  //className = "Ammo";
  //shapeFile = "mortarpack";
  //shadowDetailMask = 4;
  //price = 2;
//};

ItemImageData PlasmaGunImage
{
  shapeFile = "disc";
  mountPoint = 0;
  weaponType = 0;
  ammoType = PlasmaAmmo;
  projectileType = PlasmaBolt;
  accuFire = true;
  reloadTime = 0.1;
  fireTime = 0.3;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 1, 1, 0.2 };
  sfxFire = SoundFirePlasma;
  sfxReload = SoundDiscReload;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
  description = "Fission Slicer";
  className = "Weapon";
  shapeFile = "disc";
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
  Bottomprint(%client, "Fission Slicer: <f2>Using arclite ammunition to dice instead of energy, this is significantly stronger than the Fission Cutter");
}

