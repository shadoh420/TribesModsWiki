//================================================================
// Shredder
//================================================================
//================================================================


//================================================================
SoundData none
{
   wavFileName = "no_sound.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNshredderReload
{
   wavFileName = "wpn_shredder_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNshredder
{
   wavFileName = "wpn_shredder.wav";
   profile = Profile3dNear;
};
SoundData shredderExplosion
{
	wavFilename = "exp_shredder.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizshredder
{
   wavFileName = "whiz_shredder.wav";
   profile = Profile3dMediumLoop;
};
//================================================================
ExplosionData noExp 
{
 shapeName = "breath.dts";
 soundId = none;
 faceCamera = false;
 randomSpin = false;
 hasLight = false; 
 lightRange = 1.0; 
 timeZero = 0.100; 
 timeOne = 0.900; 
 colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
 radFactors = { 0.0, 1.0, 0.0 }; 
 shiftPosition = True; 
};
ExplosionData ShredderExp 
{
 shapeName = "exp_shredder.dts";
 soundId = ShredderExplosion;
 faceCamera = true;
 randomSpin = false;
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

//================================================================
BulletData Shredinvproj
{
	bulletShapeName = "tracer.dts";
	explosionTag = ShredderExp;
 	mass = 0.05;
 	bulletHoleIndex = 0;
 	damageClass = 0;
 	damageValue = 0.33;
 	damageType = $ShredderDamageType;
 	aimDeflection = 0.005;
 	muzzleVelocity = 4000.0;
 	totalTime = 5.0;
 	inheritedVelocityScale = 1.0;
 	isVisible = false;
 	//tracerPercentage = 1.0;
 	//tracerLength = 50;
};


RocketData Shredderproj
{
   bulletShapeName  = "proj_shredder.dts";
   explosionTag     = noExp;
   collisionRadius  = 0.0;
   mass             = 0.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.33;
   damageType       = $ShredderDamageType;

   explosionRadius  = 0.5;
   kickBackStrength = 1.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 5000.0;
   acceleration     = 100.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   //rocket specific
   //trailType   = 2;                // smoke trail
   //trailString = "mortartrail.dts";
   //smokeDist   = 1.8;

   soundId = SoundWhizShredder;
};



//================================================================

ItemData ShredderAmmo
 {
 description = "shredder shells";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo1";
 shadowDetailMask = 4;
 price = 0;
 };

ItemImageData ShredderImage
 {
 shapeFile = "wpn_shredder";
 mountPoint = 0;
 weaponType = 0;
	minEnergy = 0.01;
	maxEnergy = 0.01;
 ammoType = ShredderAmmo;
 projectileType = undefinedproj;
 accuFire = false;
 reloadTime = 0.1;
 fireTime = 0.15;
 sfxFire = SoundWPNShredder;
 sfxActivate = SoundPickUpWeapon;
 };

ItemData Shredder
 {
 description = "Shredder";
 className = "weapon";
 shapeFile = "wpn_shredder";
 hudIcon = "sniper";
 heading = "TWeapons";
 shadowDetailMask = 4;
 imageType = ShredderImage;
 price = 0;
  showWeaponBar = false;
	showInventory = true;
 };

function ShredderImage::onFire(%player, %slot) { %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[shredder]);
if(%AmmoCount) { Player::decItemCount(%player,$WeaponAmmo[shredder],0);
 %trans = GameBase::getMuzzleTransform(%player);
 %vel = Item::getVelocity(%player);
Projectile::spawnProjectile("shredinvproj",%trans,%player,%vel);
Projectile::spawnProjectile("shredinvproj",%trans,%player,%vel);
Projectile::spawnProjectile("shredinvproj",%trans,%player,%vel);
 Projectile::spawnProjectile("shredinvproj",%trans,%player,%vel);
 Projectile::spawnProjectile("shredinvproj",%trans,%player,%vel);
 Projectile::spawnProjectile("shredderproj",%trans,%player,%vel);
 }
 else Client::sendMessage(Player::getClient(%player), 0,"You Ran Out Of Ammo for the shredder"); }

///////////////////////////////////////////////////////////
echo("shredder Loaded");