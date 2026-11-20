//dark swarm, zurg, L-M
$InvList[Fireball] = 1;
$RemoteInvList[Fireball] = 1;
$VehicleInvList[Fireball] = 1;
$AutoUse[Fireball] = True;
$Use[Fireball] = True;
$WeaponAmmo[Fireball] = "";

addWeapon(Fireball);

BulletData FireballShot
{
   bulletShapeName    = "dustplume.dts";
   explosionTag       = clawexp;
   damageClass        = 1;
   damageValue        = 0.11;
   damageType         = $EnergyDamageType;
   explosionRadius    = 4.0;
   aimDeflection      = 0.01;
   muzzleVelocity     = 30.0;
   totalTime          = 2.45;
   liveTime           = 2.45;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

//   soundId = SoundJetLight;
};


ItemImageData FireballImage
{
   shapeFile  = "fusionbolt";
	mountPoint = 0;
        mountOffset = 
        {
        0.5, 0.0, 0.3 }
        ;
	weaponType = 0; // Single Shot
	reloadTime = 2.0;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 20;

	projectileType = Undefined;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fireball
{
   heading = $InvHead[ihPsi];
	description = "Dark Swarm";
	className = "Weapon";
   shapeFile  = "fusionbolt";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireballImage;
	price = 485;
	showWeaponBar = true;
};

function Fireball::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Dark Swarm: <f2>This ability will cough forth tons of insects that will eat away at each other and anything they can see, causing disease.");
}

function FireballImage::onFire(%player, %slot) 
//{
 //%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Zap]);
	 //if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 //Player::decItemCount(%player,$WeaponAmmo[Zap],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
                        Projectile::spawnProjectile("FireballShot",%trans,%player,%vel);
	}
	//else
		//Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

//}
