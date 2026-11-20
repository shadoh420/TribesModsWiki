//gauss battery, terran, H

$InvList[LasCannon] = 1;
$RemoteInvList[LasCannon] = 1;
$VehicleInvList[LasCannon] = 1;
$AutoUse[LasCannon] = False;
$WeaponAmmo[LasCannon] = "";

addWeapon(LasCannon);

BulletData GBCharge
{
   bulletShapeName   = "shield.dts";
   explosionTag      = debrisExpSmall;
   damageType        = 1;
   damageValue       = 0.135;
   explosionRadius   = 5.0;
   baseDamageType    = $BulletDamageType;
   aimDeflection     = 0.005;
   liveTime          = 4.5;
   totalTime         = 4.5;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0, 0.75 };
   muzzleVelocity    = 200.0;
   terminalVelocity  = 200.0;
   inheritedVelocityScale = 1.0;
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
   trailType         = 1;
   trailLength       = 300;
   trailWidth        = 2.0;
};

ItemImageData LasCannonImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GBCharge;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 2;
	maxEnergy = 3;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "Gauss Battery";
	className = "Weapon";
	shapeFile = "chaingun";
	heading = $InvHead[ihWea];
	hudIcon = "sniper";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 725;
	showWeaponBar = true;
};

function LasCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Gauss Battery: <f2>Searing projectiles will hurl from this weapon, pummeling into anything in it's path.");
}
