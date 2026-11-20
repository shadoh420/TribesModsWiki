//glave wurm, zurg, H
$InvList[Gravi] = 1;
$RemoteInvList[Gravi] = 1;
$AutoUse[Gravi] = True;
$WeaponAmmo[Gravi] = "";
$VehicleInvList[Gravi] = 1;

addWeapon(Gravi);

RocketData GraviShot
{
   bulletShapeName  = "zerg_spit.dts";
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
   totalTime        = 5.0;
   liveTime         = 3.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "zerg_spit.dts";
   smokeDist   = 4;
};

ItemImageData GraviImage
{
	shapeFile = "ZClaw";
	mountPoint = 0;
//        mountOffset = 
//        {
//        0.0, -0.5, 0.2 }
//        ;
//        mountRotation = 
//        {
//        -1.5, 0, 0 }
//        ;
	weaponType = 0; // Single Shot
	projectileType = "Undefined";
	accuFire = true;
	reloadTime = 0.2;
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
	shapeFile = "ZClaw";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = GraviImage;
	price = 950;
	showWeaponBar = true;
};

function GraviImage::onFire(%player, %slot)
{
         %random = (floor(getRandom() * 2));
         if (%random == 0)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("GraviShot",%trans,%player,%vel);
	 }
	 else if (%random == 1)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("GraviShot",%trans,%player,%vel+20);
         }
	 else if (%random == 2)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
                        Projectile::spawnProjectile("GraviShot",%trans,%player,%vel-20);
         }
	 return;
}

function Gravi::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Glave Wurm: <f2>On impact, this wurm will pull any organic material nearby into the explosion. Excellent for trapping enemies.");
}
