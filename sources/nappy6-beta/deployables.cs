
//=================================================================================================================
//===================================================================================== Inventory Station =========
//=================================================================================================================

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
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableInvPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableInvPack::onUse(%player,%item) 
	{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	}
 
function DeployableInvPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableInvPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	}
 
function DeployableInvPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7)  
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Inventory Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; 
	echo("MSG: ",%client," deployed an Inventory Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=================================================================================================================
//========================================================================================== Ammo Station =========
//=================================================================================================================

ItemImageData DeployableAmmoPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 1.0; 
	firstPerson = false; 
	}; 

ItemData DeployableAmmoPack 
	{ 
	description = "Ammo Station"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4; 
	imageType = DeployableAmmoPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableAmmoPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployableAmmoPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableAmmoPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableAmmoPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Ammo Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; 
	echo("MSG: ",%client," deployed an Ammo Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

ItemImageData DeployableComPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 4.5; 
	firstPerson = false; 
	}; 

ItemData DeployableComPack 
	{ 
	description = "Command Station"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableComPackImage; 
	mass = 4.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableComPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployableComPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableComPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableComPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Command Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;
	echo("MSG: ",%client," deployed a Command Station");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	}

ItemImageData DeployablevhclPackImage 
	{ 
	shapeFile = "invent_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.3 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData DeployablevhclPack 
	{ 
	description = "Vehicle Station"; 
	shapeFile = "invent_remote"; 
	className = "Backpack"; 
	heading = "eDeployable Stations"; 
	shadowDetailMask = 4 ; 
	imageType = DeployableInvPackImage; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployablevhclPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function DeployablevhclPack::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployablevhclPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployablevhclPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7)  
	{ 
	%inv = newObject("ammounit_remote","StaticShape","DeployablevhclStation",true); 
	addToSet("MissionCleanup", %inv); 
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player)); 
	GameBase::setPosition(%inv,$los::position); 
	GameBase::setRotation(%inv,%rot); 
	Gamebase::setMapName(%inv,%name); 
	Client::sendMessage(%client,0,"Vehicle Station deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployablevhclPack"]++; 
	echo("MSG: ",%client," deployed a Vehicle Station"); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 
 
//=================================================================================================================
//===================================================================================== Motion Sensor =============
//=================================================================================================================

ItemImageData MotionSensorPackImage 
	{ 
	shapeFile = "sensor_small"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData MotionSensorPack 
	{ 
	description = "Motion Sensor"; 
	shapeFile = "sensor_small"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = MotionSensorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function MotionSensorPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function MotionSensorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (MotionSensorPack::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	} 
	} 

function MotionSensorPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%mSensor = newObject("","Sensor",DeployableMotionSensor,true); 
	addToSet("MissionCleanup", %mSensor); 
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
	GameBase::setRotation(%mSensor,%rot); 
	GameBase::setPosition(%mSensor,$los::position); 
	Gamebase::setMapName(%mSensor,"Motion Sensor"); 
	Client::sendMessage(%client,0,"Motion Sensor deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Motion Sensor"); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can not be deployed on players!"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=================================================================================================================
//========================================================================================= Pulse Sensor ==========
//=================================================================================================================

ItemImageData PulseSensorPackImage 
	{ 
	shapeFile = "radar_small"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData PulseSensorPack 
	{ 
	description = "Pulse Sensor"; 
	shapeFile = "radar_small"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = PulseSensorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function PulseSensorPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function PulseSensorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	echo("MSG: ",%client," deployed a Pulse Sensor");  
	} 
	} 

//=================================================================================================================
//======================================================================================== Sensor Jammer ==========
//=================================================================================================================

ItemImageData DeployableSensorJamPackImage
	{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	};

ItemData DeployableSensorJammerPack
	{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
      heading = "fDeployable Sensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 69;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function DeployableSensorJammerPack::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
	{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) 
	{
	Player::decItemCount(%player,%item);
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	echo("MSG: ",%client," deployed a Sensor Jammer"); 
	}
	}

//=================================================================================================================
//=========================================================================================== Camera ==============
//=================================================================================================================

TurretData CameraTurret 
	{ 
	className = "Turret"; 
	shapeFile = "camera"; 
	maxDamage = 0.25; 
	maxEnergy = 10; 
	speed = 20; 
	speedModifier = 1.0; 
	range = 50; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	castLOS = true; 
	supression = false; 
	supressable = false; 
	mapFilter = 2; 
	mapIcon = "M_camera"; 
	debrisId = defaultDebrisSmall; 
	FOV = 0.707; 
	pinger = false; 
	explosionId = debrisExpMedium; 
	description = "Camera"; 
	}; 

ItemImageData CameraPackImage 
	{ 
	shapeFile = "camera"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData CameraPack 
	{ 
	description = "Camera"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
	heading = "fDeployable Sensors"; 
	imageType = CameraPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 69; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function CameraPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function CameraPack::onDeploy(%player,%item,%pos) 
	{ 
	if (CameraPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function CameraPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("Camera","Turret",CameraTurret,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Camera "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Camera deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; 
	echo("MSG: ",%client," deployed a Camera"); 
	return true; 
	}
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function CameraTurret::onAdd(%this) 
	{ 
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this); 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Camera"); 
	}
 
function CameraTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function CameraTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function CameraTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--; 
	} 

//==============================================================================================================
//==================================================================================== Blastwall ===============
//==============================================================================================================

ItemImageData TripwirePackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	};
 
ItemData TripwirePack 
	{ 
	description = "Blast Wall"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "nDeployable Walls";
	imageType = TripwirePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TripwirePack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function TripwirePack::onDeploy(%player,%item,%pos) 
	{ 
	if (TripwirePack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function TripwirePack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("BlastWall","StaticShape",BlastWall,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	Client::setOwnedObject(%client, %phase);
	Client::setOwnedObject(%client, %player);
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Blast Wall "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Blast Wall Deployed");
	echo("MSG: ",%client," deployed an Blast Wall");  
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++; 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Forcefield ==============
//==============================================================================================================

ItemImageData ForceFieldPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData ForceFieldPack 
	{ 
	description = "Force Field"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "nDeployable Walls";
	imageType = ForceFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function ForceFieldPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function ForceFieldPack::onDeploy(%player,%item,%pos) 
	{ 
	if (ForceFieldPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function ForceFieldPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",DeployableForceField,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Force Field "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Force Field Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
	echo("MSG: ",%client," deployed a Force Field");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//============================================================================ Medium Forcefield ===============
//==============================================================================================================

ItemImageData MedffPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData MedffPack
	{
	description = "Medium Force Field"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "nDeployable Walls";
	imageType = MedffPackImage;
	shadowDetailMask = 4; 
	mass = 2.5;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function MedffPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	Player::deployItem(%player,%item);
	}


function MedffPack::onDeploy(%player,%item,%pos)
	{
	if (MedffPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function MedffPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{
	%rot = GameBase::getRotation(%player); 
	%genpack = newObject("","StaticShape",MediumForceField,true);
	addToSet("MissionCleanup", %genpack);
	GameBase::setTeam(%genpack,GameBase::getTeam(%player));
	GameBase::setPosition(%genpack,$los::position);
	GameBase::setRotation(%genpack,%rot);
	Gamebase::setMapName(%genpack,"Medium Forcefield " @ Client::getName(%client));
	GameBase::setActive(%genpack,true); 
	Client::sendMessage(%client,0,"Medium Forcefield deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "MedffPack"]++;
	echo("MSG: ",%client," deployed a forcefield");
	return true;
	}	
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on playerss");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

//=============================================================================================================
//============================================================================ Large Forcefield ===============
//=============================================================================================================

ItemImageData LargeForceFieldPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData LargeForceFieldPack 
	{ 
	description = "Large Force Field"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "nDeployable Walls"; 
	imageType = LargeForceFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function LargeForceFieldPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function LargeForceFieldPack::onDeploy(%player,%item,%pos) 
	{ 
	if (LargeForceFieldPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function LargeForceFieldPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",LargeForceField,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Large Forcefield " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Force Field Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
	echo("MSG: ",%client," deployed a Large Force Field");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Panel One ===============
//==============================================================================================================

ItemImageData newdooroneImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData newdoorone
	{
	description = "Panel One";
	shapeFile = "discammo";
	className = "Backpack";
	heading = "nDeployable Walls";
	imageType = newdooroneImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function newdoorone::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	Player::deployItem(%player,%item);
	}

function newdoorone::onDeploy(%player,%item,%pos)
	{
	if (newdoorone::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function newdoorone::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	%rot = GameBase::getRotation(%player);
	%camera = newObject("newdoorone","StaticShape",newdooroneShape,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,%rot);
	GameBase::setPosition(%camera,$los::position);
	Gamebase::setMapName(%camera," Panel Wall "@ Client::getName(%client));
	Client::sendMessage(%client,0,"Wall deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%camera) @ "newdoorone"]++;
	echo("MSG: ",%client," deployed a Panel One Wall");
	return true;
	}
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

//==============================================================================================================
//==================================================================================== Panel Two ===============
//==============================================================================================================

ItemImageData newdoortwoImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData newdoortwo
	{
      description = "Panel Two";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "nDeployable Walls";
      imageType = newdoortwoImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function newdoortwo::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function newdoortwo::onDeploy(%player,%item,%pos)
	{
      if (newdoortwo::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function newdoortwo::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("newdoortwo","StaticShape",newdoortwoShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera," Panel Wall "@ Client::getName(%client));
      Client::sendMessage(%client,0,"Wall deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "newdoortwo"]++;
      echo("MSG: ",%client," deployed a Panel Two Wall");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== Panel Three =============
//==============================================================================================================

ItemImageData newdoorthreeImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData newdoorthree
	{
      description = "Panel Three";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "nDeployable Walls";
      imageType = newdoorthreeImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function newdoorthree::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function newdoorthree::onDeploy(%player,%item,%pos)
	{
      if (newdoorthree::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function newdoorthree::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("newdoorthree","StaticShape",newdoorthreeShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera," Panel Wall "@ Client::getName(%client));
      Client::sendMessage(%client,0,"Wall deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorthree"]++;
      echo("MSG: ",%client," deployed a Panel Three Wall");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== Panel Four ==============
//==============================================================================================================

ItemImageData newdoorfourImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData newdoorfour
	{
      description = "Panel Four";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "nDeployable Walls";
      imageType = newdoorfourImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function newdoorfour::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function newdoorfour::onDeploy(%player,%item,%pos)
	{
      if (newdoorfour::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function newdoorfour::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("newdoorfour","StaticShape",newdoorfourShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera," Panel Wall "@ Client::getName(%client));
      Client::sendMessage(%client,0,"Wall deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "newdoorfour"]++;
      echo("MSG: ",%client," deployed a Panel Four Wall");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//===========================================================================================================
//=================================================================================== Blast Door ============
//===========================================================================================================

ItemImageData BlastDoorPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData BlastDoorPack
	{
      description = "Blast Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = BlastDoorPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function BlastDoorPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function BlastDoorPack::onDeploy(%player,%item,%pos)
	{
      if (BlastDoorPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function BlastDoorPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("BlastDoorPack","StaticShape",BlastDoorShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"Blast Door "@ Client::getName(%client));
      Client::sendMessage(%client,0,"Blast Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "BlastDoorPack"]++;
      echo("MSG: ",%client," deployed a Blast Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 3x4 Forcedoor ===========
//==============================================================================================================

ItemImageData doorthreebyfourForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorthreebyfourForceFieldPack
	{
      description = "3x4 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorthreebyfourForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorthreebyfourForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorthreebyfourForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorthreebyfourForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorthreebyfourForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorthreebyfourForceFieldPack","StaticShape",doorthreebyfourForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"3x4 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"3x4 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorthreebyfourForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 3x4 Force Field Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x8 Forcedoor ===========
//==============================================================================================================

ItemImageData doorfourbyeightForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyeightForceFieldPack
	{
      description = "4x8 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyeightForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyeightForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyeightForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyeightForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyeightForceFieldPack","StaticShape",doorfourbyeightForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x8 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x8 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x8 Force Field Door ");
      return true;
      }
	else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
      else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x14 Forcedoor ==========
//==============================================================================================================

ItemImageData doorfourbyfourteenForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyfourteenForceFieldPack
	{
      description = "4x14 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyfourteenForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyfourteenForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyfourteenForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyfourteenForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyfourteenForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyfourteenForceFieldPack","StaticShape",doorfourbyfourteenForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x14 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x14 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyfourteenForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x14 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 4x17 Forcedoor ==========
//==============================================================================================================

ItemImageData doorfourbyseventeenForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfourbyseventeenForceFieldPack
	{
      description = "4x17 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfourbyseventeenForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfourbyseventeenForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfourbyseventeenForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfourbyseventeenForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfourbyseventeenForceFieldPack","StaticShape",doorfourbyseventeenForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"4x17 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"4x17 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyseventeenForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 4x17 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== 5x5 Forcedoor ===========
//==============================================================================================================

ItemImageData doorfivebyfiveForceFieldPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData doorfivebyfiveForceFieldPack
	{
      description = "5x5 Field Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = doorfivebyfiveForceFieldPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
	{
      if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
      %rot = GameBase::getRotation(%player);
      %camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"5x5 Forcefield Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"5x5 Forcefield Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
      echo("MSG: ",%client," deployed a 5x5 Force Field Door ");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here.");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}

//==============================================================================================================
//==================================================================================== Platform Door ===========
//==============================================================================================================

ItemImageData PlatformDoorPackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData PlatformDoorPack
	{
      description = "Platform Door";
      shapeFile = "discammo";
      className = "Backpack";
      heading = "pDoors";
      imageType = PlatformDoorPackImage;
      shadowDetailMask = 4;
      mass = 2.5;
      elasticity = 0.2;
      price = 420;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function PlatformDoorPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else
      Player::deployItem(%player,%item);
	}

function PlatformDoorPack::onDeploy(%player,%item,%pos)
	{
      if (PlatformDoorPack::deployShape(%player,%item))
      Player::decItemCount(%player,%item);
	}

function PlatformDoorPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,15)) 
	{
      %obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") < 0.01 && Vector::dot($los::normal,"0 0 -1") < 0.01) 
	%rot = Vector::getRotation($los::normal); 
	else
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2); 
	%rot = "1.570795 0 " @ %zRot; 
	}
      %camera = newObject("PlatformDoor","StaticShape",PlatformDoor,true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,%rot);
      GameBase::setPosition(%camera,$los::position);
      Gamebase::setMapName(%camera,"Platform Door " @ Client::getName(%client));
      Client::sendMessage(%client,0,"Platform Door deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%camera) @ "PlatformDoorPack"]++;
      echo("MSG: ",%client," deployed a Platform Door");
      return true;
      }
      else
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
      Client::sendMessage(%client,0,"Cannot deploy here");
      }
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
      return false;
	}


//==============================================================================================================
//==================================================================================== Medium Platform =========
//==============================================================================================================

ItemImageData MedPlatformImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData MedPlatform
	{
	description = "Medium Platform";
	shapeFile = "discammo";
	className = "Backpack";
      heading = "oDeployable Platforms";
	imageType = MedPlatformImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function MedPlatform::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function MedPlatform::onDeploy(%player,%item,%pos)
	{
	if (MedPlatform::deployShape(%player,%item))
	Player::decItemCount(%player,%item); 
	}

function MedPlatform::deployShape(%player,%item)
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",MediumPlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Medium Platform " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Medium Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "MedPlatform"]++; 
	echo("MSG: ",%client," deployed a Medium Platform");   
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Large Platform ==========
//==============================================================================================================

ItemImageData LrgPltPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData LrgPltPack 
	{ 
	description = "LargePlatform"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "oDeployable Platforms"; 
	imageType = LrgPltPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function LrgPltPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 60 || Vector::GetDistance(%deplpos,%teamposb) < 60 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}

function LrgPltPack::onDeploy(%player,%item,%pos) 
	{ 
	if (LrgPltPack::deployShape(%player,%item))  
	Player::decItemCount(%player,%item);  
	} 

function LrgPltPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",LargePlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Large Platform "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Large Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LrgPltPack"]++; 
	echo("MSG: ",%client," deployed a Large Platform");   
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//==================================================================================== Jail Capture Pad ========
//==============================================================================================================

ItemImageData JailCapPackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData JailCapPack
	{
	description = "Jail Capture Pad";
	shapeFile = "discammo";
	className = "Backpack";
	heading = "iJail";
	imageType = JailCapPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function JailCapPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else 
      Player::deployItem(%player,%item);
	}

function JailCapPack::onDeploy(%player,%item,%pos)
	{
      if (JailCapPack::deployShape(%player,%item)) 
      Player::decItemCount(%player,%item);
	}

function JailCapPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj == "Player")
	{
	Client::sendMessage(%client,0,"Can't be deployed on players");
      return false;
	} 
	%playerPos = GameBase::getPosition(%player);
      %flag = $teamFlag[GameBase::getTeam(%player)];
      %flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerpos) < 10)
      {
      Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
      return false;
      }
	%prot = GameBase::getRotation(%player);
      %zRot = getWord(%prot,2);
      %rot =  "1.57079 0 " @ %zRot;
      %padd = "0 0 0";
      %pos = Vector::add($los::position,%padd); 
	%camera = newObject("","StaticShape","jailpad",true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,"0 0 0");
      GameBase::setPosition(%camera,%pos);
      Gamebase::setMapName(%camera,"JailPad " @ Client::getName(%client));
      Client::sendMessage(%client,0,"Jail Pad Deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
      echo("MSG: ",%client," deployed a Jail Pad");
      return true;
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
	}
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

//==============================================================================================================
//========================================================================================= Jail Cell ==========
//==============================================================================================================

ItemImageData jailpackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData jailpack
	{
	description = "Jail Cell";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = "iJail";
	imageType = jailpackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function jailpack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 111 || Vector::getDistance(%deplpos, %teamposb) < 111 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function jailpack::onDeploy(%player,%item,%pos)
	{
	if (jailpack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function CreatejailportSimSet()
	{
	%teleset = nameToID("MissionCleanup/jailports");
	if(%teleset == -1)
	{
	newObject("jailports",SimSet);
	addToSet("MissionCleanup","jailports");
	}
	}

function jailpack::deployshape(%player,%item)
	{
	GameBase::getLOSInfo(%player,10);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack])
	{
	Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
	return false;
	}
      %objDevice = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide1 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide2 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide3 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide4 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide5 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide6 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide7 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide8 = newObject("Jail","StaticShape",JailSwitchOpen,true);
      %objDevice.objSide9 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide10 = newObject("Jail","StaticShape",JailSwitchClose,true);
      %objDevice.objSide1.objParent = %objDevice;
      %objDevice.objSide2.objParent = %objDevice;
      %objDevice.objSide3.objParent = %objDevice;
      %objDevice.objSide4.objParent = %objDevice;
      %objDevice.objSide5.objParent = %objDevice;
      %objDevice.objSide6.objParent = %objDevice;
      %objDevice.objSide7.objParent = %objDevice;
      %objDevice.objSide8.objParent = %objDevice;
      %objDevice.objSide9.objParent = %objDevice;
      %objDevice.objSide10.objParent = %objDevice;
      addToSet(MissionCleanup, %objDevice);
      addToSet(MissionCleanup, %objDevice.objSide1);
      addToSet(MissionCleanup, %objDevice.objSide2);
      addToSet(MissionCleanup, %objDevice.objSide3);
      addToSet(MissionCleanup, %objDevice.objSide4);
      addToSet(MissionCleanup, %objDevice.objSide5);
      addToSet(MissionCleanup, %objDevice.objSide6);
      addToSet(MissionCleanup, %objDevice.objSide7);
      addToSet(MissionCleanup, %objDevice.objSide8);
      addToSet(MissionCleanup, %objDevice.objSide9);
      addToSet(MissionCleanup, %objDevice.objSide10);
      %pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
      GameBase::setRotation(%objDevice.objSide1,"0 0 0");
      GameBase::setPosition(%objDevice.objSide1,%pos);
      GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide2,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide2,%pos);
      GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide3,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide3,%pos);
      GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
      GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide4,%pos);
      GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
      GameBase::setRotation(%objDevice,"4.71339 0 0");
      GameBase::setPosition(%objDevice,%pos);
      GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
      GameBase::setRotation(%objDevice.objSide6,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide6,%pos);
      GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
      GameBase::setRotation(%objDevice.objSide7,"4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide7,%pos);
      GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
      GameBase::setRotation(%objDevice.objSide8,"0 0 0");
      GameBase::setPosition(%objDevice.objSide8,%pos);
      GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
      GameBase::setRotation(%objDevice.objSide9,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide9,%pos);
      GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
	GameBase::setRotation(%objDevice.objSide10,"0 0 0");
	GameBase::setPosition(%objDevice.objSide10,%pos);
	GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));
	playSound(SoundPickupBackpack,$los::position);
	newObject("jaildoor",SimSet);
	addToSet("MissionCleanup","jaildoor");
	%sensor = newObject("jaildoor","StaticShape",jLargeForceField,true);
	addToSet("MissionCleanup/jaildoor", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setPosition(%sensor,%pos);
	GameBase::setRotation(%sensor,"0 0 0");
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
	CreatejailportSimSet();
	addToSet("MissionCleanup/jailports", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%beam = newObject("","StaticShape",ElectricalBeamBig,true);
	addToSet("MissionCleanup", %beam);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	GameBase::setPosition(%beam,%pos);
	%sensor.beam1 = %beam;
	playSound(SoundPickupBackpack,$los::position);
	newObject("releasepad",SimSet);
	CreatereleasepadSimSet();
	addToSet("MissionCleanup/releasepad", %sensor);
	addToSet("MissionCleanup", %sensor);
	%sensor = newObject("releasepad","StaticShape","jailStandTop",true);
	addToSet("MissionCleanup/releasepad", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	$TeamItemCount[GameBase::getTeam(%sensor) @ "jailpack"]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " deployed 250' Up");
	return true;
	}

function CreatereleasepadSimSet()
	{
	%teleset = nameToID("MissionCleanup/releasepad");
	if(%teleset == -1)
	{
	newObject("releasepad",SimSet);
	addToSet("MissionCleanup","releasepad");
	}
	}

//=============================================================================================================
//======================================================================================== Arbitor Box ========
//=============================================================================================================

TurretData ArbitorBox
	{
	className = "Turret";
	shapeFile = "magcargo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Box";
	damageSkinData = "objectDamageSkins";
	};

ItemImageData ArbitorBoxPackImage
	{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	};

ItemData ArbitorBoxPack
	{
	description = "Arbitor Device";
	shapeFile = "magcargo";
	className = "Backpack";
      heading = "hDeployable Base Objects";
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function ArbitorBoxPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 100 || Vector::GetDistance(%deplpos,%teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
	{
	if (ArbitorBoxPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function ArbitorBoxPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
	if (GameBase::getLOSInfo(%player,10))
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7)
	{
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
      addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Arbitor Device deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
	echo("MSG: ",%client," deployed an Arbitor Box");
	if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
	GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces.");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players.");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");
	return false;
	}

function ArbitorBox::onAdd(%this)
	{
	schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Arbitor Box");
	}

function ArbitorBox::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }

function ArbitorBox::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function ArbitorBox::onDisabled(%this)
	{
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
	%obj = Group::getObject(%this.set, %i);
	GameBase::startFadeIn(%obj);
	%obj.cloaked = 0;
	}
	GameBase::setActive(%this,false);
	deleteObject(%this.set);
	}

function ArbitorBox::onDestroyed(%this)
	{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
	}

function ArbitorBox::onPower(%this,%power,%generator) {}

function ArbitorBox::onEnabled(%this) 
	{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1;
	}
	}
	%this.set = %Set;
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.25, %this);
	}	

function ArbitorBox::checkArbitorBox(%this)
	{
	if(GameBase::getDamageState(%this) != "Enabled")
	return;
	%this.evenodd = !%this.evenodd; 
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1 + %this.evenodd; 
	}
	}
	%num = Group::objectCount(%this.set);
	for(%j; %j < %num; %j++)
	{
	%obj = Group::getObject(%this.set, %j);
	if(%obj != %this && GameBase::getTeam(%obj) == GameBase::getTeam(%this))
	if(%obj.cloaked != (%this.evenodd + 1)) 
	{
	%obj.cloaked = 0;
	if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); 
	}
	}
	deleteObject(%this.set); 
	%this.set = %Set; 
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); 
	}

//=================================================================================================================
//===================================================================================== Base Alarm ================
//=================================================================================================================

ItemImageData BaseAlarmImage
	{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	};

ItemData BaseAlarm
	{
      description = "Base Alarm";
      shapeFile = "sensor_small";
      className = "Backpack";
      heading = "fDeployable Sensors";
      shadowDetailMask = 4;
      imageType = BaseAlarmImage;
      mass = 2.0;
      elasticity = 0.2;
      price = 69;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function BaseAlarm::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function BaseAlarm::onDeploy(%player,%item,%pos)
	{
	if (BaseAlarm::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function BaseAlarm::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if (%obj == "InteriorShape") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 0";
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 0";
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%alarm = newObject("","StaticShape", "AlarmKit",true);
 	addToSet("MissionCleanup", %alarm);
	GameBase::setTeam(%alarm,GameBase::getTeam(%player));
	GameBase::setRotation(%alarm,%rot);
	GameBase::setPosition(%alarm,$los::position);
	Gamebase::setMapName(%alarm,%name);
	Gamebase::setMapName(%alarm,"Base Alarm # "@$totalNumAlarms[GameBase::getTeam(%player)] );
	Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
	$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;
	echo("MSG: ",%client," deployed a Base Alarm"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on buildings");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
	}

//=============================================================================================================
//================================================================================== Builder Pole =============
//=============================================================================================================

ItemImageData BuilderPoleImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData BuilderPole 
	{ 
	description = "Builder Pole"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = BuilderPoleImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function BuilderPole::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function BuilderPole::onDeploy(%player,%item,%pos) 
	{ 
	if (BuilderPole::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "BuilderPole"]++;
	echo("MSG: ",%client," deployed a Builder Pole");  
	} 
	} 

function BuilderPole::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%mSensor = newObject("pole","StaticShape",LargeAntenna,true); 
	addToSet("MissionCleanup", %mSensor); 
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); 
	GameBase::setRotation(%mSensor,%rot); 
	GameBase::setPosition(%mSensor,$los::position); 
	Gamebase::setMapName(%mSensor,"Builder Pole"); 
	Client::sendMessage(%client,0,"Builder Pole deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Builder Pole"); 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//===============================================================================================================
//=================================================================================== Deployable Platform =======
//===============================================================================================================

ItemImageData PlatformPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData PlatformPack 
	{ 
	description = "Deployable Platform"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "oDeployable Platforms"; 
	imageType = PlatformPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function PlatformPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function PlatformPack::onDeploy(%player,%item,%pos) 
	{ 
	if (PlatformPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function PlatformPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Deployable Platform " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Platform Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	echo("MSG: ",%client," deployed a Platform");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//======================================================================================== Flagstand ===========
//==============================================================================================================

ItemImageData FlagstandPackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData FlagstandPack
	{	
	description = "Flag Stand";
	shapefile = "discammo";
	classname = "Backpack";
	heading = "hDeployable Base Objects";
	imageType = FlagstandPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function FlagstandPack::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function FlagStandPack::onDeploy(%player,%item,%pos)
	{
	if (FlagstandPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function FlagstandPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = %flag.originalposition;
	if(Vector::getDistance(%flagpos, %playerpos) < 5000)
	{
	%rot = GameBase::getRotation(%player); 
	%sensor = newObject("","Staticshape",DeployableFlagstand,true);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	GameBase::setPosition(%sensor,$los::position);
	GameBase::setRotation(%sensor,%rot);
	Gamebase::setMapName(%sensor,"Flagstand " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Flagstand deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FlagstandPack"]++;
	echo("MSG: ",%client," deployed a Flag stand");
	return true;
	}	
	else
	Client::sendMessage(%client,0,"You are too far away from the flags original position.");
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableFlagstand::onCollision(%this,%object)
	{
      if(%object.enterTime > getSimTime() - 3)
	return;
      %standTeam = GameBase::getTeam(%this);
      %playerTeam = GameBase::getTeam(%object);
      %playerClient = Player::getClient(%object);
      if(getObjectType(%object) != "Player" || %playerTeam != %standTeam || %object.carryflag == "")
      return;
      %flag = %object.carryFlag;
      %flagTeam = GameBase::getTeam(%flag);
      if(%this.carryflag != "")
	return;
      %this.carryflag = %flag;
      %flag.carrier = -1;
      Item::hide(%flag, false);
      GameBase::setPosition(%flag, GameBase::getPosition(%this)); 
      playSound(SoundPickupBackpack, GameBase::getPosition(%this));
      %flag.flagStand = %this;
      Player::setItemCount(%object, Flag, 0);
      %object.carryFlag = "";
      %playerClient = Player::getClient(%object);
      Flag::clearWaypoint(%playerClient, true);
      if(getTeamName(%flag) == %playerTeam)
	{
   	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " flag has been moved to a new position");
   	Client::sendMessage(%playerClient, 0, "You moved your flag.");
      }
      else 
	{
	MessageAllExcept(%playerClient, 0,"The " @ getTeamName(%playerteam) @ " have set an enemy flag on a flagstand");
   	Client::sendMessage(%playerClient, 0, "You placed the enemy flag down.");
      }	
      %object.enterTime = getSimTime();
	}

//==============================================================================================================
//========================================================================================= Hologram ===========
//==============================================================================================================

ItemImageData HoloPackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData HoloPack 
	{ 
	description = "Hologram"; 
	shapeFile = "larmor"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = HoloPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function HoloPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function HoloPack::onDeploy(%player,%item,%pos) 
	{ 
	if (HoloPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function HoloPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 6) 
	%phase = newObject("","StaticShape",Hologram1,true); 
	else 
	if((%rnd > 2) && (%rnd < 7)) 
	%phase = newObject("","StaticShape",Hologram2,true); 
	else 
	%phase = newObject("","StaticShape",Hologram3,true); 
	%armor = Player::getArmor(%player); 
	if (%armor == "dmarmor" || %armor == "dmfemale")  
	%phase = newObject("","StaticShape",Hologram2,true);  
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Client::sendMessage(%client,0,"Hologram Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
	echo("MSG: ",%client," deployed a Hologram");  
	return true;  
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	}   
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//=============================================================================================================
//=================================================================================== Remote Base =============
//=============================================================================================================

ItemImageData RemoteBaseImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData RemoteBase 
	{ 
	description = "Remote Base"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = RemoteBaseImage; 
	shadowDetailMask = 4; 
	mass = 2.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RemoteBase::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 300 || Vector::getDistance(%deplpos, %teamposb) < 300 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function RemoteBase::onDeploy(%player,%item,%pos) 
	{ 
	if (RemoteBase::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RemoteBase"]++;
	} 
	} 

function RemoteBase::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player);
	%playpos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,20)) 
	{ 
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain" || %obj == "Large Platform") 
	{ 
	if(Vector::GetDistance(%playpos,$los::position) > 9 ) 
	{
	%base = newObject("Remotebase",InteriorShape,"bunker4.dis",false);
	%base.basebackwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseleftwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baserightwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseturret = newObject("Remotebase","Turret",DeployableRocket,false);
	%base.basestation = newObject("Remotebase","StaticShape",BaseStation,false);
	%base.basedoor = newObject("Remotebase","Staticshape",bdForceField,true);
	%base.basedoor.objParent = %base;
	%base.basebackwall.objParent = %base;
	%base.baseleftwall.objParent = %base;
	%base.baserightwall.objParent = %base;
	%base.baseturret.objParent = %base;
	%base.basestation.objParent = %base;
	addToSet("MissionCleanup", %base);
	addToSet("MissionCleanup", %base.basebackwall);
	addToSet("MissionCleanup", %base.baseleftwall);
	addToSet("MissionCleanup", %base.baserightwall);
	addToSet("MissionCleanup", %base.baseturret);
	addToSet("MissionCleanup", %base.basedoor);
	addToSet("MissionCleanup", %base.basestation);
	GameBase::setTeam(%base,GameBase::getTeam(%player));
	GameBase::setPosition(%base,$los::position);
	GameBase::setRotation(%base,"0 0 0");
	%pos = Vector::add($los::position, "0 5.875 0");
	GameBase::setRotation(%base.basebackwall,"0 0 0");
	GameBase::setPosition(%base.basebackwall,%pos);
	GameBase::setTeam(%base.basebackwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -5.875 0");
	GameBase::setRotation(%base.basedoor,"0 0 0");
	GameBase::setPosition(%base.basedoor,%pos);
	GameBase::setTeam(%base.basedoor,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "-5.875 0 0");
	GameBase::setRotation(%base.baseleftwall,"0 0 4.7125");
	GameBase::setPosition(%base.baseleftwall,%pos);
	GameBase::setTeam(%base.baseleftwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "5.875 0 0");
	GameBase::setRotation(%base.baserightwall,"0 0 4.7125");
	GameBase::setPosition(%base.baserightwall,%pos);
	GameBase::setTeam(%base.baserightwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 0 9.77");
	GameBase::setRotation(%base.baseturret,"0 0 0");
	GameBase::setPosition(%base.baseturret,%pos);
	GameBase::setTeam(%base.baseturret,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 3 1");
	GameBase::setRotation(%base.basestation,"0 0 0");
	GameBase::setPosition(%base.basestation,%pos);
	GameBase::setTeam(%base.basestation,GameBase::getTeam(%player));
	$TeamItemCount[GameBase::getTeam(%sensor) @ "RemoteBase"]++;
	Gamebase::setMapName(%base,"Remote Base " @ Client::getName(%client));
	Client::setOwnedObject(%client, %base);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Remote base deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Remote Base"); 
	return true; 
	}
	else 
	Client::sendMessage(%client,0,"You are too close to the deploy position."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only be deployed on terrain."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//========================================================================================================
//============================================================================== Sniper Hut ==============
//========================================================================================================

ItemImageData SniperHutImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData SniperHut
	{
	description = "Sniper Hut"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects";
	imageType = SniperHutImage;
	shadowDetailMask = 4; 
	mass = 2.5;
	elasticity = 0.1;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function SniperHut::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200 || Vector::getDistance(%deplpos, %teamposb) < 200 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function SniperHut::onDeploy(%player,%item,%pos)
	{
	if (SniperHut::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function SniperHut::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,12)) 
	{
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2);
	%xRot = %zRot + 9.44;
	%rot = "0 0 " @ %xRot;
	%pos = Vector::add($los::position, "0 0 0.5"); 
	%hut = newObject("","InteriorShape","eround.dis",false);
	addToSet("MissionCleanup", %hut);
	GameBase::setTeam(%hut,GameBase::getTeam(%player));
	GameBase::setPosition(%hut,%pos);
	GameBase::setRotation(%hut,%rot);
	Gamebase::setMapName(%hut,"Sniper Hut" @ Client::getName(%client));
	Client::sendMessage(%client,0,"Sniper Hut deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "SniperHut"]++;
	echo("MSG: ",%client," deployed a sniper hut");
	return true;
	}	
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on terrain");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

//==============================================================================================================
//====================================================================================== Springboard ===========
//==============================================================================================================

ItemImageData SpringPackImage 
	{
 	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false; 
	}; 

ItemData SpringPack 
	{ 
	description = "Springboard"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = SpringPackImage; 
	shadowDetailMask = 4; 
	mass = 1.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function SpringPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)  
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else  
	Player::deployItem(%player,%item);  
	} 

function SpringPack::onDeploy(%player,%item,%pos) 
	{ 
	if (SpringPack::deployShape(%player,%item))  
	Player::decItemCount(%player,%item);  
	} 

function SpringPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("","StaticShape",DeployableSpring,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Springboard " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Springboard Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
	echo("MSG: ",%client," deployed a Spring Board");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	}    
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

//==============================================================================================================
//========================================================================================= Teleport ===========
//==============================================================================================================

ItemImageData TeleportPackImage 
	{ 
	shapeFile = "flagstand"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData TeleportPack 
	{ 
	description = "Teleport Pad"; 
	shapeFile = "flagstand"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = TeleportPackImage; 
	shadowDetailMask = 4; 
	mass = 5.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TeleportPack::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else  
	Player::deployItem(%player,%item);  
	} 

function TeleportPack::onDeploy(%player,%item,%pos) 
	{ 
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; 
	} 
	} 

function CreateteleportSimSet() 
	{ 
	%teleset = nameToID("MissionCleanup/Teleports"); 
	if(%teleset == -1) 
	{ 
	newObject("Teleports",SimSet); 
	addToSet("MissionCleanup","Teleports"); 
	} 
	} 

function TeleportPack::deployShape(%player,%name,%shape,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%sensor = newObject("Teleport Pad","StaticShape",%shape,true); 
	CreateteleportSimSet(); 
	addToSet("MissionCleanup/Teleports", %sensor); 
	addToSet("MissionCleanup", %sensor); 
	GameBase::setTeam(%sensor,GameBase::getTeam(%player)); 
	%pos = Vector::add($los::position,"0 0 1"); 
	echo("LOS pos " @ $los::position @ " " @ %pos); 
	GameBase::setPosition(%sensor,%pos); 
	Gamebase::setMapName(%sensor,%name); 
	Client::sendMessage(%client,0,%item.description @ " deployed"); 
	%sensor.disabled = false; 
	playSound(SoundPickupBackpack,$los::position); 
	%beam = newObject("","StaticShape",ElectricalBeamBig,true); 
	addToSet("MissionCleanup", %beam); 
	GameBase::setTeam(%beam,GameBase::getTeam(%player)); 
	GameBase::setPosition(%beam,%pos); 
	%sensor.beam1 = %beam; 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); 
	return false; 
	}

//==============================================================================================================
//============================================================================================ Trees ===========
//==============================================================================================================

ItemImageData TreePackImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData TreePack 
	{ 
	description = "Tree"; 
	shapeFile = "tree1"; 
	className = "Backpack"; 
	heading = "hDeployable Base Objects"; 
	imageType = TreePackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	};
 
function TreePack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 100 || Vector::GetDistance(%deplpos,%teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}
 
function TreePack::onDeploy(%player,%item,%pos) 
	{ 
	if (TreePack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function TreePack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 5) 
	%phase = newObject("","StaticShape",DeployableTree,true); 
	else 
	%phase = newObject("","StaticShape",DeployableTree2,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	GameBase::setPosition(%phase,$los::position); 
	GameBase::setRotation(%phase,%rot); 
	Gamebase::setMapName(%phase,"Mechanical Tree "@ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Mechanical Tree Deployed"); 
	GameBase::startFadeIn(%phase); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
	echo("MSG: ",%client," deployed a Tree");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s."); 
	return false; 
	} 


