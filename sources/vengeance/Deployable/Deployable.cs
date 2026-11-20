
ItemData HandDeployable
{
	description = "HandDeployable";
	showInventory = false;
};

function HandDeployable::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}




