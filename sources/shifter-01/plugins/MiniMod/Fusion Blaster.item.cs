// MiniMod plugin
// Fusion Blaster created/ported By, Dewy.

addPluginWeapon(Mortar, FusionGun);
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

$AutoUse[FusionGun] = True; 

ItemImageData FusionGunImage
{
        shapeFile  = "energygun";
	mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.1;
        minEnergy = 6;
        maxEnergy = 7;

        projectileType = FusionShell;
	accuFire = true;

	sfxFire = SoundRemoteTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
	sfxReady = SoundUseAmmoStation ;
};

ItemData FusionGun
{
   heading = "bWeapons";
        description = "Fusion Blaster";
	className = "Weapon";
        shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
        imageType = FusionGunImage;
        price = 115;
	showWeaponBar = true;
};


