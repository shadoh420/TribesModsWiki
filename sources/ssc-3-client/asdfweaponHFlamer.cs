//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Happy...er...Heavy Flamer.....
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[HFlamer] = 1;
$RemoteInvList[HFlamer] = 1;
$WeaponAmmo[HFlamer] = "";
$AutoUse[HFlamer] = False;

addWeapon(HFlamer);

BulletData HFlamerBolt 
{
  bulletShapeName = "tumult_medium.dts";
  explosionTag = plasmaExp;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $PlasmaDamageType;
  explosionRadius = 8.0;
  muzzleVelocity = 30.0;
  totalTime = 0.75;
  liveTime = 0.75;
  lightRange = 5.0;
  lightColor = { 2, 2, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};
ItemImageData HFlamerImage 
{
  shapeFile = "mortar";
  mountPoint = 0;
  weaponType = 0;
  reloadTime = 0.05;
  fireTime = 0.05;
  minEnergy = 5;
  maxEnergy = 6;
  projectileType = HFlamerBolt;
  accuFire = true;
  sfxFire = SoundJetHeavy;
  sfxActivate = SoundPickUpWeapon;
};
ItemData HFlamer 
{
  heading = $InvHead[ihWea];
  description = "Heavy Flamer";
  className = "Weapon";
  shapeFile = "mortar";
  hudIcon = "plasma";
  shadowDetailMask = 4;
  imageType = HFlamerImage;
  price = 985;
  showWeaponBar = true;
};

function HFlamer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Heavy Flamer: This is a not a toy. This is better. It's a BIG toy. Recipe available upon request.");
}
