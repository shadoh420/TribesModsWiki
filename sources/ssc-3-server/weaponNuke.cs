//NUCLEAR BOOMBOOM
$InvList[Nuke] = 1;
$InvList[NukeAmmo] = 1;
$RemoteInvList[Nuke] = 1;
$RemoteInvList[NukeAmmo] = 1;
$VehicleInvList[Nuke] = 1;
$VehicleInvList[NukeAmmo] = 1;
$AutoUse[Nuke] = False;
$SellAmmo[NukeAmmo] = 1;
$WeaponAmmo[Nuke] = NukeAmmo;

addWeapon(Nuke);
addAmmo(Nuke, NukeAmmo, 1);

GrenadeData Nukegren
{
  bulletShapeName = "mortar.dts";
  explosionTag = BigRedExp;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 80;
  elasticity = 0.3;
  damageClass = 1;
  damageValue = 2.5;
  damageType = $MortarDamageType;
  explosionRadius = 18;
  kickBackStrength = 700;
  maxLevelFlightDist = 0;
  totalTime = 5.0;
  liveTime = 0.001;
  projSpecialTime = 0.05;
  inheritedVelocityScale = 0;
  smokeName = "shockwave_large.dts";
  smokeDist = 1.5;
};

ItemData NukeAmmo 
{
  description = "Nukes";
  className = "Ammo";
  heading = $InvHead[ihAmm];
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 2;
};

ItemImageData NukeImage 
{
  shapeFile = "mortarex";
  mountPoint = 0;
   mountOffset = 
   {
   0.0, 0.0, 5000 }
   ;
   mountRotation = 
   {
   0.0, 0, 0 }
   ;
  weaponType = 0;
  ammoType = NukeAmmo;
  projectileType = Nukegren;
  accuFire = false;
  reloadTime = 0.1;
  fireTime = 0.1;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
  sfxReload = SoundDryFire;
};

ItemData Nuke 
{
  description = "Ghost Nuclear Targeting System";
  className = "Weapon";
  shapeFile = "shotgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = NukeImage;
  price = 175;
  showWeaponBar = true;
};

function Nuke::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Ghost Nuclear Missle Launcher: <f2>Summons a super powerful nuclear missle to drop on your head. Literally.");
}
