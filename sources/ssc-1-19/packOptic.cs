//dummy flag, from Orion Mod
$InvList[OpticPack] = 1;
$RemoteInvList[OpticPack] = 1;
$VehicleInvList[OpticPack] = 1;

ItemImageData OpticPackImage 
{
  shapeFile = "flag";
  mountPoint = 2;
  mountOffset = 
  {
    0, 0, -0.1 }
  ;
//  mountRotation = 
//  {
//    0, 0, 0 }
//  ;
//  weaponType = 0;
//  projectileType = sniperLaser;
//  accuFire = true;
//  reloadTime = 0.1;
//  fireTime = 0.1;
//  minEnergy = 1;
//  maxEnergy = 6;
  lightType = 2;
  lightRadius = 5;
  lightTime = 1;
  lightColor = 
  {
    1, 0, 0 }
  ;
//  sfxFire = SoundFireLaser;
}
;
ItemData OpticPack 
{
  description = "Dummy Flag";
  shapeFile = "flag";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = OpticPackImage;
  price = 275;
  hudIcon = "sniper";
  showWeaponBar = false;
  hiliteOnActive = false;
}
;
function OpticPackImage::onActivate(%player,%imageSlot) 
{
//  schedule("use(\"backpack\");", 0.5);
}
function OpticPackImage::onDeactivate(%player,%imageSlot) 
{
//  Player::trigger(%player,$BackpackSlot,false);
}
