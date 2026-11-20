//Lurk weapon
$InvList[SBarrage] = 1;
$RemoteInvList[SBarrage] = 1;
$WeaponAmmo[SBarrage] = "";
$VehicleInvList[SBarrage] = 1;
$AutoUse[SBarrage] = True;

addWeapon(SBarrage);

BulletData SBarrageShell1
{
   bulletShapeName  = "tracer.dts";
   explosionTag     = clawExp;
   collisionRadius  = 0.0;
   mass             = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   baseDamageType   = $PsiDamageType;
   aimDeflection    = 0.004;

   explosionRadius  = 6.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 100.0;
   acceleration     = 2.0;
   totalTime        = 20.0;
   liveTime         = 10.0;
   inheritedVelocityScale = 0.5;
};

ItemImageData SBarrageImage
{
	shapeFile = "sensor_small";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = Undefined;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	minEnergy = 6;
	maxEnergy = 7;
        mountRotation = 
        {
        -1.5, 0, 0 }
        ;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SBarrage
{
	description = "Spine Barrage";
	className = "Weapon";
	shapeFile = "snowplume";
	hudIcon = "energyRifle";
   heading = $InvHead[ihPsi];
	shadowDetailMask = 4;
	imageType = SBarrageImage;
	price = 300;
	showWeaponBar = true;
};

function SBarrage::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Spine Barrage: <f2>A Lurker ability, need I say more?");
}

function SBarrageImage::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
 	%client = Player::getClient(%player);

                Projectile::spawnProjectile("SBarrageShell1",%trans,%player,%vel-8);
                Projectile::spawnProjectile("SBarrageShell1",%trans,%player,%vel+8);
                Projectile::spawnProjectile("SBarrageShell1",%trans,%player,%vel);
}
