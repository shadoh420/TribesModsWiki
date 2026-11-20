$InvList[DeployableInvPack] = 1;
$MobileInvList[DeployableInvPack] = 1;
$RemoteInvList[DeployableInvPack] = 0;
AddItem(DeployableInvPack);

$CanAlwaysTeamDestroy[DeployableInvStation] = 1;

ItemImageData DeployableInvPackImage 
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack 
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
	heading = $InvHead[ihDOb];
	shadowDetailMask = 4;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);

	%inv.cloakable = true;
 	addToSet("MissionCleanup/deployed/station", %inv);
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player));
	GameBase::setPosition(%inv,$los::position);
	GameBase::setRotation(%inv,%rot);
	Gamebase::setMapName(%inv,"Inventory Station");
	Client::sendMessage(%client,0,"Inventory Station deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
	echo("MSG: ",%client," deployed an Inventory Station");
	return true;
}

StaticShapeData DeployableInvStation 
{	
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundInventoryStationPower };
	visibleToSensor = true;
	validateMaterials = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpSmall;
};

function DeployableInvStation::onAdd(%this) 
{	
	$StaticShape::count += 1;
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this) 
{	
	if(%this.deployed == 1) 
	{
		GameBase::playSequence(%this,1,"use");
		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else 
		GameBase::setActive(%this,false);
}
