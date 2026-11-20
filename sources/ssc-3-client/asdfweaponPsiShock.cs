//
$InvList[DCannon] = 1;
$RemoteInvList[DCannon] = 1;
$AutoUse[DCannon] = True;
$WeaponAmmo[DCannon] = "";

addWeapon(DCannon);

BulletData Clawclaw
{
  bulletShapeName = "dustplume.dts";
  explosionTag  = bulletExp2;
  damageClass = 0;
  damageValue = 0.4;
  elasticity = 0.35;
  damageType = $ReaperDamageType;
  aimDeflection = 0.04;
  explosionRadius = 5.0;
  muzzleVelocity = 100.0;
  terminalVelocity = 100.0;
  totalTime = 0.03;
  liveTime = 0.02;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.5;
  isVisible = True;
//   trailType   = 2;                // smoke trail
//   trailString = "lflame.dts";
//   smokeDist   = 1.0;
};

ItemImageData DCannonImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = Clawclaw;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 2;
	sfxFire = SoundJetLight;
//	sfxActivate = SoundPickUpWeapon;
};

ItemData DCannon
{
	description = "Claws";
	className = "Weapon";
	shapeFile = "mrtwig";
	hudIcon = "disk";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = DCannonImage;
	price = 250;
	showWeaponBar = false;
};

function DCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Claws: A basic Zerg ability, this weapon is able to hack away at close range targets.");
}
