//created by jake miracle, adapted by me for the SC mod
$InvList[BlueTerror] = 1;
$RemoteInvList[BlueTerror] = 1;
$VehicleInvList[BlueTerror] = 1;
$AutoUse[BlueTerror] = False;
$WeaponAmmo[BlueTerror] = "";

addWeapon(BlueTerror);

RocketData NeutBlast
{
  bulletShapeName = "enbolt.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 1.35;
  baseDamageType = $MissileDamageType;
  explosionRadius = 15.0;
  kickBackStrength = 150.0;
  muzzleVelocity = 500.0;
  terminalVelocity = 500.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 9.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 200;
  trailWidth = 0.4;
};

ItemImageData BlueTerror
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 1.0;
  fireTime = 2.5;
  minEnergy = 40;
  maxEnergy = 50;
  projectileType = NeutBlast;
  accuFire = true;
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
  sfxActivate = SoundPickUpWeapon;
};

ItemData BlueTerrorImage
{
  heading = $InvHead[ihWet];
  description = "Neutron Blast";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  shadowDetailMask = 4;
  imageType = BlueTerrorImage;
  price = 500;
  showWeaponBar = true;
};

function BlueTerror::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Neutron Blast: <f2>Don't be fooled by it's size. Focuses neutrons into a tiny ball of unstable anti-matter.  Script by Jake Miracle, AKA DarkFox.");
}
