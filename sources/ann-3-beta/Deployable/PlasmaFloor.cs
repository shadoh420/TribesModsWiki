$InvList[PlasmafloorPack] = 1;
$MobileInvList[PlasmafloorPack] = 1;
$RemoteInvList[PlasmafloorPack] = 1;
AddItem(PlasmafloorPack);

$CanAlwaysTeamDestroy[DeployablePlasmaFloor] = 1;

ItemImageData PlasmafloorPackImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmafloorPack 
{
	description = "Plasma Floor";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = PlasmafloorPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmafloorPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,4)) 
	{
		if(!$build)Client::sendMessage(%client,0,"Deploy position out of range");
		GameBase::playSound(%player, SoundPackUse, 0);
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true && !$Build)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
		
	%rot = GameBase::getRotation(%player);//floor

	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	{
		%prot = GameBase::getRotation(%player);
		%xRot = getWord(%prot,0);
		%yRot = getWord(%prot,1);
		%zRot = getWord(%prot,2);			
		%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
		%up = true;
	}	
	
	%platform = newObject("DeployablePlasmaFloor", "StaticShape", DeployablePlasmaFloor, true);

	addToSet("MissionCleanup/deployed/Barrier", %platform);
//	%rot = GameBase::getRotation(%player);
	GameBase::setTeam(%platform, GameBase::getTeam(%player));
	GameBase::setPosition(%platform, $los::position);
	GameBase::setRotation(%platform, %rot);
	Gamebase::setMapName(%platform, "Deployable Platform "@Client::getName(%client));
	if(!$build)
		Client::sendMessage(%client,0,"Platform Deployed");
	GameBase::startFadeIn(%platform);
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlasmafloorPack"]++;
	if($build && !%up)
	{		
		GameBase::setPosition(%player, vector::add(GameBase::getPosition(%player),"0 0 1"));		
	}	
	if(!$build)
		echo("MSG: ",%client," deployed an platform");
	return true;
}

StaticShapeData DeployablePlasmaFloor 
{
	shapeFile = "PLASMAWALL";
	debrisId = defaultDebrisSmall;
	maxDamage = 4;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Deployable Platform";
};

function DeployablePlasmaFloor::onDestroyed(%this) 
{
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmafloorPack"]--;
}

function DeployablePlasmaFloor::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);
		
	if(getObjectType(%object) == "Flier") 
	{ 
		%data = GameBase::getDataName(%object);
		if($debug)
			echo(%data@" hitting "@GameBase::getDataName(%this));
			
		%damage = GameBase::getDamageLevel(%object) + 0.01;
		GameBase::setDamageLevel(%object,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%object));
	}
}
