$InvList[MobileInventoryPack]	= 1;
$MobileInvList[MobileInventoryPack] = 0;
$RemoteInvList[MobileInventoryPack] = 0;
AddItem(MobileInventoryPack);

$CanAlwaysTeamDestroy[MobileInventory] = 1;

ItemImageData MobileInventoryPackImage 
{
	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData MobileInventoryPack
{
	description = "Mobile Inventory Station";
	shapeFile = "inventory_sta";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = MobileInventoryPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData MobileInventory
{
	description = "Mobile Inventory Station";
	shapeFile = "inventory_sta";
	classname = "MobileStation";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.5;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
	shieldShapeName = "shield";
};

function MobileInventoryPack::deployShape(%player,%item)
{
	//Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	//DeployStuff(%player,%item,MobileInv,1,5,0,0,true,1,250);
	
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);

	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
		return false;
	}
	if(!GameBase::getLOSInfo(%player,5)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}


// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(GameBase::getDataName($los::object) != "DeployablePlatform")
	{
		%obj = getObjectType($los::object);
		if(%obj != "SimTerrain" && %obj != "InteriorShape" && !$build) 
		{
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			return false;
		}		
			
		if(!checkInvDeployArea(%client,$los::position)) 
		{
			Client::sendMessage(%client,0,"Cannot deploy here");
			return false;
		}
	}
	
	%obj = newObject("Mobile Inventory","StaticShape","MobileInventory",true);
	%obj.cloakable = true;	//for base cloaker

	if($debug) Echo($Ver,"|Created New Object :",%obj," ","Mobile Inventory Station");
	
	//GameBase::playSequence(%obj,1,"deploy");
	//GameBase::SetActive(%obj,false);
	
	GameBase::setTeam(%obj,%team);
	addToSet("MissionCleanup/deployed/station", %obj);
	GameBase::setPosition(%obj,$los::position);
	GameBase::setRotation(%obj,GameBase::getRotation(%player));
	Gamebase::setMapName(%obj,"Mobile Inventory Station");
	Client::sendMessage(%client,0,"Mobile Inventory Station deployed");
	playSound(SoundCreateItem,$los::position);
	$TeamItemCount[%team @ %item]++;
	
//	Station::FindPower(%obj);

	schedule("Ann::PowerTap("@%obj@");",3);			//plasmatic 2.3
//	schedule("Ann::AddtoPowerGrid("@%obj@");",5);		//Plasmatic 2.3 power grid
	return true;	
}

function MobileInventory::onDestroyed(%this)
{
	if($trace) 
		echo($ver,"| MobileInventoryPack::onDestroyed");
	MobileInventory::onDisabled(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	StaticShape::objectiveDestroyed(%this);
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	$TeamItemCount[GameBase::getTeam(%this) @ "MobileInventoryPack"]--;
}

function MobileInventory::onDisabled(%this)
{
	if($trace) 
		echo($ver,"| MobileInventory::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
// 	GameBase::generatePower(%this, false);
}

function MobileInventory::onEndSequence(%this,%thread)
{
	if(Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"MobileInvList");
}

// Simplified power grid -plasmatic 2.3
function MobileInventory::onPower(%this,%power,%generator)
{
	//echo(%generator);
	if(%power) 
	{
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
		
	}
	else 
	{		
		GameBase::stopSequence(%this,0);
		GameBase::pauseSequence(%this,1);
		GameBase::pauseSequence(%this,2);
		Station::checkTarget(%this);
		
		%team = GameBase::getTeam(%this);
		if(!GameBase::isPowered(%this))
		{	
			DropshipTeamMessage(%team, 3, "Cycling Mobile Inventory power frequency....");			
			schedule("Ann::PowerTap("@%this@");",getRandom()*6 + 2);	//plasmatic 2.3
		}
	}
}