$InvList[SuicidePack] = 1;
$MobileInvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;
AddItem(SuicidePack);

ItemImageData SuicidePackImage 
{	
	shapeFile = "magcargo";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;	
	
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SuicidePack 
{	
	description = "Suicide DetPack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHead[ihBac];
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePackImage::onActivate(%player,%imageSlot)
{	
	%clientId = Player::getClient(%player);
	Player::trigger(%player,$BackpackSlot);
	
	Player::setItemCount(%player,Player::getMountedItem(%player,$backpackslot), 0);
	//Player::unmountItem(%player,$BackpackSlot);
	%obj = newObject("","Mine","Suicidebomb2");
	%obj.timer = %clientId.suicideTimer;
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,3 * %clientId.throwStrength,false);
	if(%obj.timer > 0)
		Client::sendMessage(%clientId,1,"Det Pack will destruct in " @ %obj.timer @ " seconds");
	else
		Client::sendMessage(%clientId,1,"Your Det Pack was set to INSTANT");
	schedule("Mine::Detonate(" @ %obj @ ");",%obj.timer,%obj);
}
