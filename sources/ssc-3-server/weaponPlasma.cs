$InvList[PlasMeta] = 1;
$RemoteInvList[PlasMeta] = 1;
$VehicleInvList[PlasMeta] = 1;
$AutoUse[PlasMeta] = True;
$WeaponAmmo[PlasMeta] = "";

addWeapon(PlasMeta);

RocketData PlasIC
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = PlasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   baseDamageType   = $PsiDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 100.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 2.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 5.0 };
   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "plasmatrail.dts";
   smokeDist = 0.6;
};

RocketData PlasNC
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 10.0;
   baseDamageType   = $PsiDamageType;

   explosionRadius  = 40.0;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 2.0;
   totalTime        = 20.0;
   liveTime         = 20.0;
   lightRange       = 9.0;
   lightColor       = { 0.4, 0.4, 5.0 };
   inheritedVelocityScale = 0.5;
   TrailType = 2;
   trailString = "fiery.dts";
   smokeDist = 8.0;
};

ItemImageData PlasMetaImage
{
	shapeFile = "dustplume";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = Undefined;
	accuFire = true;
	reloadTime = 1.7;
	fireTime = 1.0;
	minEnergy = 60;
	maxEnergy = 70;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PlasMeta
{
	description = "Plasma Metamorphosis";
	className = "Weapon";
	shapeFile = "dustplume";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = PlasMetaImage;
	price = 1000;
	showWeaponBar = true;
};

function PlasMeta::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Plasma Metamorphosis: <f2>this is one of the Zerg's most feared weapon, the plasma explodes on contact, although sometimes it happens to go out of control.");
}

function PlasMetaImage::onFire(%player, %slot) 
  {
         if (floor(getRandom() * 23) == 0)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
 	    %client = Player::getClient(%player);
            Bottomprint(%client, "WARNING: PLASMA OUT OF CONTROL- CLEAR THE EXPLOSION AREA");
                        Projectile::spawnProjectile("PlasNC",%trans,%player,%vel);
	 }
	 else
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("PlasIC",%trans,%player,%vel);
         }
	 return;
  }
