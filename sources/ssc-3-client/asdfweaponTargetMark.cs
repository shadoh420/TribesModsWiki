$InvList[TargetMarkLaser] = 1;
$RemoteInvList[TargetMarkLaser] = 1;
$AutoUse[TargetMarkLaser] = False;

addWeapon(TargetMarkLaser);


TargetLaserData dlagslas
{
  laserBitmapName = "laserpulse.bmp";
  damageConversion = 0.5;
  baseDamageType = $LaserDamageType;
  lightRange = 2.0;
  lightColor = { 0.25, 1.0, 0.25 };
  detachFromShooter = false;
};

ItemImageData TargetMarkLaserImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = dlagslas;
  accuFire = true;
  minEnergy = 5;
  maxEnergy = 15;
  reloadTime = 1.0;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TargetMarkLaser
{
  description = "Death Laser";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = TargetingLaserImage;
  price = 150;
  showWeaponBar = false;
};

//function TargetMarkLaser::onMount(%player,%item) 
//{
  //%client = Player::getClient(%player);
  //Bottomprint(%client, "Death laser: usually used as a last resort when depleted of ammunition.");
//}
