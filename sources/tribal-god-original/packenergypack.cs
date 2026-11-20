ItemImageData EnergyPackImage
{
	shapeFile  = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy  = -1;
 	maxEnergy  = -20;
	firstPerson = false;
};
ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
    heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
    validateShape = false;
    validateMaterials = false;
};
function EnergyPack::onUse(%player, %item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
}
function EnergyPack::onMount(%player, %item)
{
	Player::trigger(%player, $BackpackSlot, true);
	%player.isUnNukable = true;
}
function EnergyPack::onUnmount(%player, %item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle)
	Player::unmountItem(%player, $WeaponSlot);
	%player.isUnNukable = false;
}