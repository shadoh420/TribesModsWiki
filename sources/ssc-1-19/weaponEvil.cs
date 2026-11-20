//
$InvList[Dis] = 1;
$RemoteInvList[Dis] = 1;
$AutoUse[Dis] = True;
$WeaponAmmo[Dis] = "";

addWeapon(EMP);

RocketData DisShell 
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = LargeShockwave;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.05;
  damageType = $FlashDamageType;
  explosionRadius = 40.5;
  kickBackStrength = 50.0;
  muzzleVelocity = 65.0;
  terminalVelocity = 65.0;
  acceleration = 5.0;
  totalTime = 10.0;
  liveTime = 10.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
};

ItemImageData DisImage
{
	shapeFile = "sensor_small";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = DisShell;
	accuFire = true;
	reloadTime = 3.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Dis
{
	description = "Psychic Disruption";
	className = "Weapon";
	shapeFile = "sensor_small";
	hudIcon = "plasma";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = DisImage;
	price = 3350;
	showWeaponBar = true;
};

function Dis::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "This psionic ability sends a charge of force at the enemy, disrupting their energy sources.");
}


