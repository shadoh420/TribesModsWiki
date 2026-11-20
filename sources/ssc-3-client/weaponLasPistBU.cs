//Gauss Pistol, terran, L

$InvList[Pist] = 1;
$RemoteInvList[Pist] = 1;
$VehicleInvList[Pist] = 1;
$AutoUse[Pist] = True;

addWeapon(Pist);

bulletData PistBolt
{
   bulletShapeName   = "bullet.dts";
   explosionTag      = bulletexp0;
   damageType        = 0;
   damageValue       = 0.17;
   baseDamageType    = $BulletDamageType;
   aimDeflection     = 0.002;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   muzzleVelocity    = 175.0;
   terminalVelocity  = 175.0;
   inheritedVelocityScale = 1.0;
   trailType         = 1;
   trailLength       = 300;
   trailWidth        = 0.3;
   detachFromShooter = true;
};

ItemImageData PistImage
{
  shapeFile = "energygun";
  mountPoint = 0;
  weaponType = 0;
  projectileType = PistBolt;
  accuFire = false;
  reloadTime = 0.2;
  fireTime = 0.1;
  minEnergy = 5;
  maxEnergy = 6;
  lightType = 3;
  lightRadius = 2;
  lightTime = 1;
  lightColor = { 4, 6, 2 };
  sfxFire = SoundFireBlaster;
  sfxActivate = SoundPickUpWeapon;
};

ItemData Pist 
{
  description = "Gauss Pistol";
  className = "Weapon";
  shapeFile = "energygun";
  hudIcon = "blaster";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = PistImage;
  price = 225;
  showWeaponBar = true;
};

function Pist::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Gauss Gun: <f2>fires super-heated ballistics able to knock weapons off it's target's hands.");
}


