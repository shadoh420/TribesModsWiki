//Rapid Burst Laser
$InvList[Melta] = 1;
$InvList[MeltaAmmo] = 1;
$RemoteInvList[Melta] = 1;
$RemoteInvList[MeltaAmmo] = 1;
$AutoUse[Melta] = False;
$WeaponAmmo[Melta] = "MeltaAmmo";

addWeapon(Melta);
addAmmo(Melta, MeltaAmmo, 2);

RocketData BlueBolta
{
  bulletShapeName = "enbolt.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 5.0;
  damageClass = 1;
  damageValue = 0.8;
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
  trailLength = 50;
  trailWidth = 0.4;
};

ItemData MeltaAmmo
{
	description = "Burst Charges";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData MeltaImage 
{
  shapeFile = "plasma";
  mountPoint = 0;
  ammoType = MeltaAmmo;
  weaponType = 0;
  reloadTime = 1.0;
  fireTime = 2.5;
  minEnergy = 40;
  maxEnergy = 55;
  projectileType = BlueBolta;
  accuFire = false;
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
  sfxReady = SoundMortarIdle;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Melta
{
  heading = $InvHead[ihWea];
  description = "Neutron Blast";
  className = "Weapon";
  shapeFile = "plasma";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = MeltaImage;
  price = 485;
  showWeaponBar = true;
};

function Melta::onMount(%player,%item)
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Neutron Blast: Focuses neutrons into a tiny ball of unstable anti-matter.  Script by Jake Miracle, AKA DarkFox.");
}