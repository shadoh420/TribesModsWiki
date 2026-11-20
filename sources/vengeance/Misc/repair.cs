$InvList[RepairKit] = 1;
$MobileInvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;
AddItem(RepairKit);

$AutoUse[RepairKit] = false;

ItemData RepairKit 
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 35;
};

function RepairKit::onUse(%player,%item) 
{
	if(!$build)Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	%c = Player::getClient(%player);
	 // Alliance armor support
	%armor = Player::getArmor(%player);
	eval(%armor @ "::onRepairKit(" @ %player @ ");");
}

ItemData RepairPatch 
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 2;
};

function RepairPatch::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Player") 
	{
		if(GameBase::getDamageLevel(%object)) 
		{
			GameBase::repairDamage(%object,0.125);
			%c = Player::getClient(%object);
			$poisonTime[%c] = 0;
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item) 
{
	if(!$build)Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}
