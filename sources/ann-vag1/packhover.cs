$InvList[TankHoverPack] = 1;
$MobileInvList[TankHoverPack] = 1;
$RemoteInvList[TankHoverPack] = 1;
AddItem(TankHoverPack);

// pack by armagedon

ItemImageData TankHoverPackImage
{
	shapeFile = "sensor_small";
	mountRotation = { 11, 0, 0 };
	mountOffset = { 0, -0.10, 0.05 };
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData TankHoverPack 
{
	description = "Tank Hover Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TankHoverPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TankHoverPack::onMount(%player,%item) 
{
}

function TankHoverPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Tank Hover Engaged.");
	%clientId = Player::getClient(%player);
	$tankhover[%clientId] = 1;
	Tank_Hover(%clientId, %player);
}

function TankHoverPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Tank Hover Disengaged.");
	Player::trigger(%player,$BackpackSlot,false);
	%clientId = Player::getClient(%player);
	$tankhover[%clientId] = 0;
}