//glave wurm, zurg, H
$InvList[Gravi] = 1;
$RemoteInvList[Gravi] = 1;
$AutoUse[Gravi] = True;
$WeaponAmmo[Gravi] = "";
$VehicleInvList[Gravi] = 1;

addWeapon(Gravi);

RocketData GraviShot
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.0;
   mass             = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $PsiDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = -250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 4.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "paint.dts";
   smokeDist   = 2;
};

ItemImageData GraviImage
{
	shapeFile = "mrtwig";
	mountPoint = 0;
        mountOffset = 
        {
        0.0, -0.5, 0.2 }
        ;
        mountRotation = 
        {
        -1.5, 0, 0 }
        ;
	weaponType = 0; // Single Shot
	projectileType = GraviShot;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.2;
        damageClass = 1;
        damageValue = 0.05;
	minEnergy = 49;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gravi
{
	description = "Glave Wurm";
	className = "Weapon";
	shapeFile = "mrtwig";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = GraviImage;
	price = 550;
	showWeaponBar = true;
};

function Gravi::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Glave Wurm: <f2>On impact, this wurm will pull any organic material nearby into the explosion. Excellent for trapping enemies. However, the wurms hate to struggle upwards, so they won't.");
}
