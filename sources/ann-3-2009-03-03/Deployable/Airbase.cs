

$InvList[AirBasePack] = 1;
$MobileInvList[AirBasePack] = 1;
$RemoteInvList[AirBasePack] = 0;
AddItem(AirBasePack);

ItemImageData AirBasePackImage
{	
	shapeFile = "vehi_pur_pnl";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AirBasePack
{	
	description = "Air Base";
	shapeFile = "vehi_pur_pnl";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = AirBasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData AirBaseForceFieldLarge
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};

StaticShapeData AirBaseForceFieldSmall
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Air Base";
};



function CreateAirBaseSimSet(%team)
{
	%Baseset = nameToID("MissionCleanup/AirBase" @ %team);
	if(%Baseset == -1)
	{
		%group = newObject("AirBase" @ %team,SimGroup);
		addToSet("MissionCleanup",%group);
	}	
}

//	StaticShapeData AirBaseChecker	//11/16/2005 6:51AM
//	{
//		shapeFile = "elevator16x16_octo";	//"ARROW50";
//		debrisId = defaultDebrisLarge;
//		maxDamage = 50000;
//		visibleToSensor = true;
//		isTranslucent = true;
//		description = "AirBitch";
//	};

function AirBasePack::deployshape(%player,%item)
{
	%name = "Air Base";
	%team = GameBase::getTeam(%player);

	%client = Player::getClient(%player);

	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy, Air Base Already In Place");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%flag = $teamFlag[%team];
	%flagpos = gamebase::getPosition(%flag);

	if(getWord(%playerpos,2) < -100)
	{
		Client::sendMessage(%client,0,"Position unstable, too close to center of planet.");
		return false;
	}
	
	if(Vector::getDistance(%flagpos, %playerpos) < 50)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return false;
	}
		
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	
	
	
//	CreateAirBaseSimSet(%team);
	%group = nameToID("MissionCleanup/AirBase" @ %team);
	if(%group == -1)
	{
		%group = newObject("AirBase" @ %team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
	
	
	%pRot = vector::add("0 0 "@getword(GameBase::getRotation(%player),2),"0 0 0.785");
	%object = newObject("test","Moveable",elevator16x16Octa,false);
	//newObject("test","StaticShape",AirBaseChecker,false);
	//
	addToSet(%group, %object);
	
	if(!GameBase::testPosition(%object,vector::add(%playerpos,"0 0 110")))
		%noway = 1;	
	else if(!GameBase::testPosition(%object,vector::add(%playerpos,"0 0 125")))
		%noway = 2;	
	else if(!GameBase::testPosition(%object,vector::add(%playerpos,"0 0 115")))
		%noway = 3;	
	else if(!GameBase::testPosition(%object,vector::add(%playerpos,"0 0 120")))
		%noway = 4;	
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("-7.49755 1.43987 16",%pRot),vector::add(%playerpos,"0 0 95"))))
		%noway = 5;
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("-7.49755 1.43987 16",%pRot),vector::add(%playerpos,"0 0 100"))))
		%noway = 6;	
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("1.58014 -7.45512 16",%pRot),vector::add(%playerpos,"0 0 95"))))
		%noway = 7;
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("1.58014 -7.45512 16",%pRot),vector::add(%playerpos,"0 0 100"))))
		%noway = 8;		
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("4.25588 4.13451 16",%pRot),vector::add(%playerpos,"0 0 100"))))
		%noway = 9;
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("-10.6862 -11.1697 16",%pRot),vector::add(%playerpos,"0 0 95"))))
		%noway = 10;
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("-10.6862 -11.1697 16",%pRot),vector::add(%playerpos,"0 0 100"))))
		%noway = 11;
	else if(!GameBase::testPosition(%object,vector::add(rotateVector("-10.6862 -11.1697 16",%pRot),vector::add(%playerpos,"0 0 105"))))
		%noway = 12;
		
	//Tribes gets confused when testing position with .dis and .dts, so we need more tests.. Sigh. 
	%camera = newObject("Camera","Turret",cameraturret,true);
			
	GameBase::setPosition(%camera,vector::add(rotateVector("-15 -7 10",%pRot),vector::add(%playerpos,"0 0 100")));
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 13;	
	GameBase::setPosition(%camera,vector::add(rotateVector("15 -7 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 14;	
	GameBase::setPosition(%camera,vector::add(rotateVector("0 -22 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 15;	
	GameBase::setPosition(%camera,vector::add(rotateVector("0 7 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 16;			
			
		
	DeleteObject(%object);
	DeleteObject(%camera);		
	if(%noway)
	{
		Client::sendMessage(%client,0,"Whisky, tango, foxtrot: "@%noway);
		return false;
	}	
	
//	%playerpos = "0 0 -100";
//	GameBase::setRotation(%player,"0 0 0");
	
	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 100;	//150;	//3.0 change. 
	%AirbasePos = %posX@" "@%posY@" "@%posZ;
	
	
	%object = newObject("Air Base","InteriorShape", "BEMfloatingPad.dis");
	Ann::DeployRotate(%group,%object,%AirbasePos,"-5 -5 0",%pRot,"0 0 0",%team,"");	

	%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
	Ann::DeployRotate(%group,%object,%AirbasePos,"0 0 38",%pRot,"0 3.14159 0",%team,"");	

	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"5.8746 0 14.5",%pRot,"0 0 1.570796",%team,"");	
	
	%object = newObject("Air Base Small1","StaticShape",AirBaseForceFieldSmall,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"-5.75 2.05 16",%pRot,"0 0 1.570796",%team,"");
	
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"0 5.8746 14.5",%pRot,"0 0 0",%team,"");
	
	%object = newObject("Air Base Small2","StaticShape",AirBaseForceFieldSmall,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"2.03 -5.75 16",%pRot,"0 0 0",%team,"");
	
	%object = newObject("Vehicle Station","StaticShape",VehicleStation,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"-3.60177 3.95522 16",%pRot,"0 0 0.7853981",%team,"Air Base Vehicle Station");
		
	%object = newObject("Vehicle Pad","StaticShape",VehiclePad,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"-10.6862 -11.1697 16",%pRot, "0 -0 2.3561944",%team,"Air Base Vehicle Pad");
	
	%object = newObject("Inventory Station","StaticShape",InventoryStation,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"3.69689 -3.64708 16",%pRot,"0 0 -2.3561944",%team,"Air Base Inventory Station");
	
	%object = newObject("Command Station","StaticShape",CommandStation,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"4.25588 4.13451 16",%pRot,"0 0 -0.7853981",%team,"Air Base Command Station");
	
	%object = newObject(MedPulse, Sensor, MediumPulseSensor,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"0 0 20.55",%pRot,"0 0 0",%team,"Air Base Pulse Sensor");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	Ann::DeployRotate(%group,%object,%AirbasePos,"-7.49755 1.43987 16",%pRot,"0 0 -1.5707963",%team,"Air Base Solar Panel");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);	
	Ann::DeployRotate(%group,%object,%AirbasePos,"1.58014 -7.45512 16",%pRot,"0 0 0",%team,"Air Base Solar Panel");


	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed an Air Base");
	Client::sendMessage(%client,0,%item.description @ " summoned 100 meters up");	//150
	playSound(SoundPickupBackpack,$los::position);
	return true;
}

function Ann::DeployRotate(%group,%this,%deployPos,%vec,%Vrot,%rot,%team,%name)
{
	addToSet(%group, %this);
	//echo(%group);
	gamebase::setposition(%this,vector::add(rotateVector(%vec,%Vrot),%deployPos));
	GameBase::setRotation(%this,vector::add(%Vrot,%rot));
	GameBase::setTeam(%this,%team);
	Gamebase::setMapName(%this,%name);	
}
