//¦Modified By: [TG]-X-Ecutioner
//¦¦¦¦¦¦Author: Plasmatic
//¦¦¦¦¦¦¦Email: dustin8420@adelphia.net
//¦¦¦¦¦¦¦¦¦AIM: dustin8420
//-------------------------------------------------------------------------------------------
// Originally This Gun Was In Plasmatic's Sex Mod, 
// It's Been Modified Slightly By Me.
//
BulletData Spredder
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;
   expRandCycle       = 0.02;
   aimDeflection      = 0.02;
   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 600.0;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   rotationPeriod     = 1;
};
//
ItemImageData BlasterImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.05;
	fireTime   = 0.05;
	minEnergy  = 5;
	maxEnergy  = 2;
	accuFire   = true;
	sfxFire    = SoundFireBlaster;// SoundFloatMineTarget;
	sfxActivate = SoundPickUpWeapon;
};
//
ItemData Blaster
{
	heading    = $InvHeading[EnergyWeapons];
	description = "Blaster";
	className  = "Weapon";
	shapeFile  = "paintgun";
	hudIcon    = "blaster";
	shadowDetailMask = 4;
	imageType  = BlasterImage;
	price      = 85;
	showWeaponBar = true;
};
//
function BlasterImage::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	//
	if(%clientId.BlasterPref == "Spredder")
	{
		for(%i = 0; %i < 5; %i += 1)
		{ Projectile::spawnProjectile("Spredder", %trans, %player, %vel); }
		return;
	}
	else if(%clientId.BlasterPref == "Default" || %clientId.BlasterPref == "")
	{ Projectile::spawnProjectile("BlasterBolt", %trans, %player, %vel); return; }
}
//
function Blaster::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }