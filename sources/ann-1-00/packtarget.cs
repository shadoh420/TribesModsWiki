$InvList[TargetPack] = 1;
$MobileInvList[TargetPack] = 1;
$RemoteInvList[TargetPack] = 1;

ItemImageData TargetPackImage
{	
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 1;
 	maxEnergy = 3;
	firstPerson = false;
	mass = 2.5;
};

ItemData TargetPack
{	
	description = "Targeting Pack";
	shapeFile = "radar_small";
	classname = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TargetPackImage;
	price = 750;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
	mass = 4.0;
};

function TargetPack::onUse(%player,%item)
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function TargetPack::onMount(%player,%item)
{	
	Player::trigger(%player,$BackpackSlot,true);
}

function TargetPack::onUnmount(%player,%item)
{
}
