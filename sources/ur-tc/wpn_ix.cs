//===========================================================================
// IX-Weapon Data
//============================================================================
$AutoUse[Shotgun] = False;
$AutoUse[SniperRifle] = False;
$Use[Assault] = True;
//========================================================
$InvList[Assault] = 1;
$InvList[Shotgun] = 1;
$InvList[SniperRifle] = 1;
$RemoteInvList[Assault] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[SniperRifle] = 1;

//============================================================================
$DamageScale[larmor, $ShotgunDamageType] = 0.5;
$DamageScale[larmor, $RifleDamageType] = 0.45;
$DamageScale[larmor, $SniperDamageType] = 1.5;
$DamageScale[lfemale, $ShotgunDamageType] = 0.5;
$DamageScale[lfemale, $RifleDamageType] = 0.45;
$DamageScale[lfemale, $SniperDamageType] = 1.5;

$ItemMax[larmor, Assault] = 1;
$ItemMax[lfemale, Assault] = 1;
$ItemMax[larmor, Shotgun] = 1;
$ItemMax[lfemale, Shotgun] = 1;
$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[lfemale, SniperRifle] = 1;
//============================================================================
SoundData SoundWPNIXassault
{
   wavFileName = "wpn_ixar.wav";
   profile = Profile3dNear;
};

SoundData SoundWPNShotgun
{
   wavFileName = "wpn_ixsg.wav";
   profile = Profile3dNear;
};

SoundData SoundWPNSniper
{
   wavFileName = "wpn_ixsr.wav";
   profile = Profile3dNear;
};

SoundData ricochetShot
{
   wavFileName = "rico_shot.wav";
   profile     = Profile3dNear;
};

SoundData ricochetBullet
{
   wavFileName = "rico_bullet.wav";
   profile     = Profile3dNear;
};

SoundData ricochetSniper
{
   wavFileName = "rico_Sniper.wav";
   profile     = Profile3dNear;
};

SoundData ricochetMini
{
   wavFileName = "rico_mini.wav";
   profile     = Profile3dNear;
};

SoundData ricochetCG
{
   wavFileName = "rico_CG.wav";
   profile = Profile3dNear;
};

//==============================================================

ExplosionData IXshotExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetShot;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
}; 

ExplosionData IXSniperExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetSniper;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
};
ExplosionData IXBulletExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetBullet;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
};


//============================================================================
BulletData Shotgunproj
{
bulletShapeName = "tracer.dts";
explosionTag = IXShotExp;
 mass = 0.05;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.75;
 damageType = $ShotgunDamageType;
 aimDeflection = 0.005;
 muzzleVelocity = 5000.0;
 totalTime = 1.0;
 inheritedVelocityScale = 1.0;
 isVisible = true;
 tracerPercentage = 1.0;
 tracerLength = 50;
 };


BulletData Assaultproj
{
   bulletShapeName    = "bullet.dts";
//   validateShape      = true;
   explosionTag       = IXBulletExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $RifleDamageType;

   aimDeflection      = 0.001;
   muzzleVelocity     = 7000;
   totalTime          = 1;
   //inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};

RocketData Sniperproj
 {
 bulletShapeName = "proj_sniper.dts";
 explosionTag = IXSniperExp;
 collisionRadius = 0.0;
 mass = 0.075;
 damageClass = 0;
 damageValue = 1.5;
 damageType = $SniperDamageType;
 kickBackStrength = 0.0;
 muzzleVelocity = 7000.0;
 terminalVelocity = 9000.0;
 acceleration = -100.0;
 totalTime = 2.0;
 liveTime = 2.0;
 lightRange = 2.0;
 lightColor = { 1, 0, 0};
 inheritedVelocityScale = 0.0;
 //tracerPercentage = 1.0;
// tracerLength = 0;
 detachFromShooter = false;
 
 };
//============================================================================

ItemImageData AssaultImage
 {
 shapeFile = "wpn_ixar";
 mountPoint = 0;
 weaponType = 0;
	minEnergy = 0.01;
	maxEnergy = 0.01;
 //ammoType = IXAssaultAmmo;
 projectileType = Assaultproj;
 accuFire = false;
 reloadTime = 0.03;
 fireTime = 0.03;
 sfxFire = SoundWPNAssault;
 sfxActivate = SoundPickupWeapon;
 };

ItemData Assault
 {
 description = "IX-Assault Rifle";
 className = "weapon";
 shapeFile = "wpn_ixar";
 hudIcon = "sniper";
 heading = "TWeapons";
 shadowDetailMask = 4;
 imageType = AssaultImage;
 price = 0;

  showWeaponBar = false;
 };
//======================================================================================
ItemImageData ShotgunImage
 {
 shapeFile = "wpn_ixsg";
 mountPoint = 0;
 weaponType = 0;
 //ammoType = IXShotAmmo;
 projectileType = NoProjectile;
 accuFire = false;
 reloadTime = 0.5;
 fireTime = 0.25;
 sfxFire = SoundWPNShotgun;
 sfxActivate = SoundPickUpWeapon;
 };

ItemData Shotgun
 {
 description = "IX-Shotgun";
 className = "weapon";
 shapeFile = "wpn_ixsg";
 hudIcon = "ixshot";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = ShotgunImage;
 price = 0;

  showWeaponBar = false;
 };

function ShotgunImage::onFire(%player, %slot) { %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
 if(%AmmoCount) { Player::decItemCount(%player,$WeaponAmmo[Shotgun],5);
 %trans = GameBase::getMuzzleTransform(%player);
 %vel = Item::getVelocity(%player);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 }
 else Client::sendMessage(Player::getClient(%player), 0,"You Ran Out Of Ammo for the Shotgun"); }
//====================================================================================================
ItemImageData SniperRifleImage
 {
 shapeFile = "wpn_ixsr";
 mountPoint = 0;
 weaponType = 0;
	minEnergy = 0.01;
	maxEnergy = 0.01;
 //ammoType = IXSniperAmmo;
 projectileType = Sniperproj;
 accuFire = true;
 reloadTime = 0.03;
 fireTime = 0.07;
 sfxFire = SoundWPNSniper;
 sfxActivate = SoundPickupWeapon;
 };

ItemData SniperRifle
 {
 description = "IX-Sniper Rifle";
 className = "weapon";
 shapeFile = "wpn_ixsr";
 hudIcon = "sniper";
 heading = "TWeapons";
 shadowDetailMask = 4;
 imageType = SniperRifleImage;
 price = 0;
  showWeaponBar = false;
 };
//========================================================================================
//echo("IX weapons Loaded");