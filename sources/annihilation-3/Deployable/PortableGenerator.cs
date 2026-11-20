$InvList[PortableGeneratorPack] = 1;
$MobileInvList[PortableGeneratorPack] = 1;
$RemoteInvList[PortableGeneratorPack] = 1;
AddItem(PortableGeneratorPack);

ItemImageData PortableGeneratorPackImage 
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData PortableGeneratorPack
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = PortableGeneratorPackImage;
	shadowDetailMask = 4;
	mass = 4.5;
	elasticity = 0.2;
	price = 2500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData PortableGenerator
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	classname = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};

function PortableGeneratorPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
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
	if(%obj != "SimTerrain" && %obj != "InteriorShape") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
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
	if(!checkDeployArea(%client,$los::position)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}
	%obj = newObject("Portable Generator","StaticShape","PortableGenerator",true);
	%obj.cloakable = true;	
	if($debug) Echo($Ver,"|Created New Object :",%obj," ","Portable Generator");
	
	//New power code 1/23/2008 5:19AM -Plasmatic	
	// we are setting up a NEW simgroup for each gen to avoid a new gen inheriting an old group.	
	%p = newObject("Portgen"@%obj, Simgroup);	//Simgroups yank object out of origional group -Plasmatic
	addToSet("MissionCleanup/deployed/power", %p);	
	%obj.set = %p;
	addToSet("MissionCleanup/deployed/power/PortGen"@%obj, %obj);

	gamebase::generatepower(%obj,true);
	GameBase::setTeam(%obj,%team);
	
	GameBase::setPosition(%obj,$los::position);
	GameBase::setRotation(%obj,GameBase::getRotation(%player));
	Gamebase::setMapName(%obj,"Portable Generator");
	Client::sendMessage(%client,0,"Portable Generator deployed");
	playSound(SoundCreateItem,$los::position);
	$TeamItemCount[%team @ %item]++;
	return true;
}


function PortableGenerator::onAdd(%this)
{
	$StaticShape::count += 1;
}

function PortableGenerator::onDestroyed(%this)
{	
	if($trace) echo($ver,"| PortableGenerator::onDestroyed");
	Generator::onDisabled(%this);	//1/21/2008 5:38AM
	StaticShape::objectiveDestroyed(%this);
	%this.cloakable = false;
	%this.nuetron = "";
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	$TeamItemCount[GameBase::getTeam(%this) @ "PortableGeneratorPack"]--;
}




