$InvList[BigCratePack] = 1;
$MobileInvList[BigCratePack] = 1;
$RemoteInvList[BigCratePack] = 1;
AddItem(BigCratePack);

$CanAlwaysTeamDestroy[BigCrate] = 1;

ItemImageData BigCratePackImage 
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData BigCratePack 
{
	description = "Big Crate";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHead[ihDOb];	// $InvHead[ihBar];
	imageType = BigCratePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function BigCratePack::deployShape(%player,%item) 
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]  && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(GameBase::getLOSInfo(%player,2.75))
	{
		Client::sendMessage(%client,0,"Deploy position is too close");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,5)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}

	%obj = $los::object;
	//echo (GameBase::getTeam(%obj));
//	if((GameBase::getTeam(%obj) != GameBase::getTeam(%player)) && (getObjectType(%obj) != "SimTerrain") && (GameBase::getTeam(%obj) != -1)) 
//	{
//		Client::sendMessage(%client,0,"Cannot deploy on enemy base");
//		return false;
//	}

// check if object is in motion, for dropships and jail cell -plasmatic
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
		return false;

	%rot = GameBase::getRotation(%player);
	%objBigCrate = newObject("","StaticShape",BigCrate,true);

	addToSet("MissionCleanup/deployed/Barrier", %objBigCrate);
	GameBase::setTeam(%objBigCrate,GameBase::getTeam(%player));
	GameBase::setPosition(%objBigCrate,$los::position);
	GameBase::setRotation(%objBigCrate,%rot);
	Gamebase::setMapName(%objBigCrate,"Big Crate "@Client::getName(%client));
	Client::sendMessage(%client,0,"Big Crate Deployed");
	GameBase::startFadeIn(%objBigCrate);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "BigCratePack"]++;
	if(!$build)
		echo("MSG: ",%client," deployed a Big Crate");
	return true;
}

StaticShapeData BigCrate 
{
	shapeFile = "magcargo";
	maxDamage = 0.25;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "Big Crate";
};

function BigCrate::onDestroyed(%this) 
{
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170);
	$TeamItemCount[GameBase::getTeam(%this) @ "BigCratePack"]--;
}

