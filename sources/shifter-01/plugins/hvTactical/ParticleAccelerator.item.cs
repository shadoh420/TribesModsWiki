// This is a MiniMod Plugin.
// This plugin is the Particle Accelerator from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ParticleAccelerator.ArmorData.cs
//    ParticleAccelerator.baseProjData.cs
//    ParticleAccelerator.item.cs
//    ParticleAccelerator.station.cs
//
// to your MiniMod/plugins directory.

$AutoUse[ClusterBomb] = True;//+++++++++++++++++++++++++++++++++++++++++++++++
$WeaponAmmo[ClusterBomb] = "";

addPluginWeapon(Mortar, ClusterBomb);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemImageData ClusterBombImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; 
      minEnergy = 30;
	maxEnergy = 50;//26;++++++++++++++++++++++++++++
//	projectileType = ThisShouldBeUndefined;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.25;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };	

//	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower; //+++++++++++++++++++++++++++++++++++
};

ItemData ClusterBomb
{
	description = "Particle Accelerator";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ClusterBombImage;
	price = 475;
	showWeaponBar = true;
};

function ClusterBombImage::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 20.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(turretExplosion,GameBase::getPosition(%player));//+++++
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));//++++
	 Player::trigger(%player,$WeaponSlot,false);//+++++
	 Client::sendMessage(Player::getClient(%player), 0,"Not enough energy to fire the Particle Accelerator");
	} 
}
