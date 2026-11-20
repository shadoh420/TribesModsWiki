$InvList[AirbasePack] = 1;
$MobileInvList[AirbasePack] = 1;
$RemoteInvList[AirBasePack] = 0;

$CanAlwaysTeamDestroy[AirbasePack] = 1;

function deployAirbase::Initialize()
{
	$TeamItemCount[0 @ AirBasePack] = 0;
	$TeamItemCount[1 @ AirBasePack] = 0;
	$TeamItemCount[2 @ AirBasePack] = 0;
	$TeamItemCount[3 @ AirBasePack] = 0;
	$TeamItemCount[4 @ AirBasePack] = 0;
	$TeamItemCount[5 @ AirBasePack] = 0;
	$TeamItemCount[6 @ AirBasePack] = 0;
	$TeamItemCount[7 @ AirBasePack] = 0;
}

ItemImageData airbasePackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData airbasePack
{
	description = "Air Base";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = airbasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function airbasePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function airbasePack::onDeploy(%player,%item,%pos)
{
	if(airbasePack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function airbasePack::deployshape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
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
	if(%obj != "SimTerrain")
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	if(!Vector::dot($los::normal,"0 0 1") > 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkDeployArea(%client,$los::position))
	{
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}
	if(getNumTeams() == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);
	//echo("%flagpos " @ %flagpos);
	//echo("%playerpos " @ %playerpos);
	if(Vector::getDistance(%flagpos, %playerPos) <= 20)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to summon the base.");
		return false;
	}
	
	CreateAirBaseSimSet(%team);

//	%objDevice.objSide1.objParent = %objDevice;
//	%objDevice.objSide2.objParent = %objDevice;
//	%objDevice.objSide3.objParent = %objDevice;
//	%objDevice.objSide4.objParent = %objDevice;
//	%objDevice.objSide5.objParent = %objDevice;
//	%objDevice.objSide6.objParent = %objDevice;
//	%objDevice.objSide7.objParent = %objDevice;
//	%objDevice.objSide8.objParent = %objDevice;
//	%objDevice.objSide9.objParent = %objDevice;

//	// Platform
//	//%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
//	%object = newObject("AirBase Platform","Staticshape",LargeAirBasePlatform,true);
//	addToSet(MissionCleanup, %object);
//	addToSet("MissionCleanup/AirBase" @ %team, %object);
//	%pos = Vector::add(GameBase::getPosition(%player), "0 0 33");
//	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
//	%rot = "0 0 0";
//	GameBase::setRotation(%object,%rot);
//	GameBase::setPosition(%object,%pos);
//	GameBase::setTeam(%object,GameBase::getTeam(%player));

	//%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
	
	
	// Top Platform
	%object = newObject("AirBase Platform","Staticshape",AirBasePlatform,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 0 54.983");
	%rot = "0 0 0.393";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Middle Platform
	%object = newObject("AirBase Platform","Staticshape",AirBasePlatform,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 0 50");
	%rot = "0 0 0.393";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Landing Platform
	%object = newObject("AirBase Platform","StaticShape",AirBasePlatform,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "14.74 0 50.00");
	%rot = "0 0 0.393";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Vehicle Platform
	%object = newObject("AirBase Platform","Staticshape",AirBasePlatform,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "-14.74 0 50.00");
	%rot = "0 0 0.393";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Main Side ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField1,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 6.1387 50.45");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Main Side ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField1,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 -6.2062 50.45");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));
	
	// Corner ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField2,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "5.56 -4.51 50.005");
	%rot = "0 0 0.785398";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));
	
	// Corner ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField2,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "-5.578 -4.524 50.005");
	%rot = "0 0 -0.785398";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));
	
	// Corner ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField2,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "-5.580 4.4565 50.005");
	%rot = "0 0 0.785398";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Corner ForceField
	%object = newObject("AirBase ForceField","Staticshape",AirBaseForceField2,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "5.560 4.4425 50.005");
	%rot = "0 0 -0.785398";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Missile Turret
	%object = newObject("Missile Turret","turret",rocketTurret,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "14.74 0 51.182");
	%rot = "0 0 -1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Radar
	%object = newObject("AirBase Radar","Staticshape",MediumRadar,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 0 55.5084");
	%rot = " 0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Generator
	%object = newObject("AirBase Generator","Staticshape",PortGenerator,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "3.295 -4.8566 50.40");
	%rot = " 0 0 -1.14";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

//	// Command Station
//	%object = newObject("AirBase Command Station","StaticShape",CommandStation,true);
//	addToSet(MissionCleanup, %object);
//	addToSet("MissionCleanup/AirBase" @ %team, %object);
//	%pos = Vector::add(%playerPos, "-7 -5 50.40");
//	%rot = Vector::add(GameBase::getRotation(%player), "0 0 4.71339");
//	GameBase::setRotation(%object,%rot);
//	GameBase::setPosition(%object,%pos);
//	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Inventory Station
	%object = newObject("AirBase Inventory Station","StaticShape",InventoryStation,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "0 4.9277 50.40");
	%rot = " 0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Vehicle Station
	%object = newObject("AirBase Vehicle Station","StaticShape",VehicleStation,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "-3.625 -5.3377 50.53");
	%rot = " 0 0 2.72";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));

	// Vehicle Pad
	%object = newObject("AirBase Vehicle Pad","StaticShape",VehiclePad,true);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerPos, "-14.74 0 51.152");
	%rot = " 0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,GameBase::getTeam(%player));
	
	//Gamebase::setMapName(%inv,"Air Base");

	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "AirBasePack"]++;
	Client::sendMessage(%client,1,"Air Base materializes 50 meters up");
	echo("MSG: ",%client," deployed an AirBase");
	return true;
}

function CreateAirBaseSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/AirBase" @ %team);
	if(%teleset == -1)
	{	newObject("AirBase" @ %team,SimSet);
		addToSet("MissionCleanup","AirBase" @ %team);
	}
}

StaticShapeData AirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 50;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData AirBaseForceField1
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	isTranslucent = true;
	description = "Force Field";
};

StaticShapeData AirBaseForceField2
{
	shapeFile = "ForceField_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	isTranslucent = true;
	description = "Force Field";
};
