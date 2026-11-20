$InvList[TNTPack] = 1;
$MobileInvList[TNTPack] = 1;
$RemoteInvList[TNTPack] = 1;

ItemImageData BlastPackImage
{	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TNTPack
{	description = "Blast Pack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHead[ihBac];
	imageType = BlastPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TNTPack::onUse(%player,%item)
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	
		Player::deployItem(%player,%item);
	}
}

function TNTPack::onUnmount(%player,%item)
{	
	deleteObject(%item);
	
}

function TNTPack::onDeploy(%player,%item,%pos)
{	
	if (TNTPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function TNTPack::deployShape(%player,%item)
{	
	Player::unmountItem(%player,$BackpackSlot);	
	%obj = newObject("Deployable Mortar","Mine","TNT");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
	bottomprint(Player::getClient(%player), "<jc>Blast pack will explode in <f2>15 seconds", 5);
}
