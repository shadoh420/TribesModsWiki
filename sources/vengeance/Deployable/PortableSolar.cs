$InvList[PortableSolarPack] = 1;
$MobileInvList[PortableSolarPack] = 1;
$RemoteInvList[PortableSolarPack] = 1;

AddItem(PortableSolarPack);

ItemImageData PortableSolarPackImage 
{
	shapeFile = "magCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PortableSolarPack
{
	description = "Portable Solar Panel";
	shapeFile = "solar_med";
	classname = "Backpack";
	heading = $InvHead[ihDLd];	//$InvHead[ihPwr];
	imageType = PortableSolarPackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData PortableSolar 
{
	description = "Portable Solar Panel";
	shapeFile = "solar_med";
	classname = "Generator";
	debrisId = flashDebrisSmall;
	maxDamage = 2;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

function PortableSolarPack::deployShape(%player,%item)
{
	%team=GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %descr);
		return false;
	}
	if(!GameBase::getLOSInfo(%player,5)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkDeployArea(%client,$los::position)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}
	%obj = newObject("Solar Panel","StaticShape","PortableSolar",true);

	%obj.cloakable = true;
	if($debug) Echo($Ver,"|Created New Object :",%obj," ","Solar Panel");
	//GameBase::playSequence(%obj,1,"deploy");
	//GameBase::SetActive(%obj,false);
	
	GameBase::setTeam(%obj,%team);
//	addToSet("MissionCleanup", %obj);
//	addToSet("MissionGroup/Teams/Team" @ %team, %obj);

	//new power code here -plasmatic
//	schedule("Ann::AddtoPowerGrid("@%obj@");",getRandom()*6 + 2);	//plasmatic 2.3
	addToSet("MissionCleanup/deployed/power", %obj);


	GameBase::setPosition(%obj,$los::position);
	GameBase::setRotation(%obj,GameBase::getRotation(%player));
	Gamebase::setMapName(%obj,"Solar Panel");
	Client::sendMessage(%client,0,"Solar Panel deployed");
	playSound(SoundCreateItem,$los::position);
	$TeamItemCount[%team @ %item]++;
	return true;
}

function PortableSolar::onDestroyed(%this)
{
	if($debug) echo($ver,"|PortableSolar::onDestroyed");
	PortableSolar::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	%this.cloakable = "";
	%this.nuetron = "";
	GameBase::generatePower(%this, false);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	$TeamItemCount[GameBase::getTeam(%this) @ "PortableSolarPack"]--;
}

function PortableSolar::onEnabled(%this)
{
	if($debug) echo($ver,"|PortableSolar::onEnabled");
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	schedule("Ann::Powering("@%this@",true);",3);	//ann 2.3 power -plasmatic	
	//GameBase::isPowerGenerator(%this);
}

function PortableSolar::onDisabled(%this)
{
	if($debug) echo($ver,"|PortableSolar::onDisabled");
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
 	Ann::Powering(%this,false);	//ann 2.3 power -plasmatic
}

function PortableSolar::onremove(%this)
{
 	Ann::Powering(%this,false);	//ann 2.3 power -plasmatic
}