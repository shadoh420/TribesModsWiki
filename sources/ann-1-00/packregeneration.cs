$InvList[RegenerationPack] = 1;
$MobileInvList[RegenerationPack] = 1;
$RemoteInvList[RegenerationPack] = 1;

ItemImageData RegenerationPackImage 
{	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RegenerationPack 
{	description = "Troll Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = RegenerationPackImage;
	price = 275;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RegenerationPack::OnMount(%player,%item)
{	
	Player::trigger(%player,$BackpackSlot,true);
}
 
function Regeneration::onUnmount(%player,%item)
{	
}

function RegenerationPackImage::onActivate(%player,%imageSlot) 
{
	schedule("checkRegeneration(" @ %player @ ");",2,%player); 
}

function RegenerationPackImage::onDeactivate(%player,%item)
{	
}

function checkRegeneration(%player)
{	if (Player::isDead(%player))
		return;
	if(Player::getMountedItem(%player,$BackpackSlot) != "RegenerationPack")
		return;
	
	%dlev = GameBase::getDamageLevel(%player);
	%armor = Player::getArmor(%player); 
	if (%armor == "armorTroll")
	{
		GameBase::setDamageLevel(%player, %dlev-0.035);
	}
	else
	{
		GameBase::setDamageLevel(%player, %dlev+0.035);
	}
	schedule("checkRegeneration(" @ %player @ ");",1,%player); 
}

function RegenerationPack::onUse(%player,%item) 
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}
