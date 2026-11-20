// This is a MiniMod Plugin.
// This Plugin is the Repair Rifle.
// Requirements: MiniMod v.07 or later
//   and the Energizer Pack Plugin.

MiniMod::WeaponCycle(Blaster, RepairRifle, PlasmaGun);

ItemImageData RepairRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = RepairRifleBolt;
	accuFire = true;
//	reloadTime = 0.1;
//	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 30;  // Energy used/sec for sustained weapons

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairRifle
{
	description = "Repair Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "repairpack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RepairRifleImage;
	price = 500;
	showWeaponBar = true;
};

function RepairRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Repair Rifle.", 2);

	if(Player::getMountedItem(%player,$BackpackSlot) == EnergizerPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energizer Pack to use Repair Rifle."); 
}

