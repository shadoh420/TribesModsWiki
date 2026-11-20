// This is a MiniMod Plugin.
// This plugin is the Mine Launcher from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    MineLauncher.ArmorData.cs
//    MineLauncher.baseProjData.cs
//    MineLauncher.item.cs
//    MineLauncher.station.cs
//
// to your MiniMod/plugins directory.

$AutoUse[MineLauncher] = True;
$SellAmmo[MinelAmmo] = 5;
$WeaponAmmo[MineLauncher] = MinelAmmo;

addPluginWeapon(Mortar, MineLauncher);
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

ItemData MinelAmmo
{
	description = "Mine Launcher Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MinelAmmo;
	projectileType = MineShell; 
	accuFire = false;
	reloadTime = 1.4;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MineLauncher
{
	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 175;
	showWeaponBar = true;
};
