//Infested  burst laser, Zerg, L-m
$InvList[InfOmega] = 1;
$RemoteInvList[InfOmega] = 1;
$VehicleInvList[InfOmega] = 1;
$AutoUse[InfOmega] = False;
$WeaponAmmo[InfOmega] = "";

addWeapon(InfOmega);

LaserData InfOmegaBolt
{
   laserBitmapName   = "grn_blink2.bmp";
   hitName           = "paint.dts";
   damageConversion  = 0.028;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = false;
   hitSoundId        = ricochet3;
};

ItemImageData InfOmegaImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.01;
  fireTime = 0.19;
  minEnergy = 3;
  maxEnergy = 4;
  projectileType = InfOmegaBolt;
  accuFire = false;
  sfxFire = SoundFireLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData InfOmega 
{
  heading = $InvHead[ihPsi];
  description = "Infested Burst Laser";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = InfOmegaImage;
  price = 350;
  showWeaponBar = true;
};

function InfOmega::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Infested Burst Laser: <f2>Obtained from the Terran's marines, this laser now serves the Zerg's force of Infested Terrans.");
}
