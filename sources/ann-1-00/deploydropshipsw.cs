$InvList[DropShipSWPack] = 1;
$MobileInvList[DropShipSWPack] = 0;
$RemoteInvList[DropShipSWPack] = 0;

function deployDropShipSW::Initialize()
{	$TeamItemCount[0 @ DropShipSWPack] = 0;
	$TeamItemCount[1 @ DropShipSWPack] = 0;
	$TeamItemCount[2 @ DropShipSWPack] = 0;
	$TeamItemCount[3 @ DropShipSWPack] = 0;
	$TeamItemCount[4 @ DropShipSWPack] = 0;
	$TeamItemCount[5 @ DropShipSWPack] = 0;
	$TeamItemCount[6 @ DropShipSWPack] = 0;
	$TeamItemCount[7 @ DropShipSWPack] = 0;
}

ItemImageData DropShipSWPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData DropShipSWPack
{	description = "Starwolf DShip";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = DropShipSWPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DropShipSWPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function DropShipSWPack::onDeploy(%player,%item,%pos)
{	if (DropShipSWPack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);
	}
}

StaticShapeData DropShipSWGenerator
{	className = "DropShipSWGenerator";
	damageSkinData = "objectDamageSkins";
	shapeFile = "generator"; 
	maxDamage = 5.0;
	maxEnergy = 500;
	sfxAmbient = SoundGeneratorPower;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	mass=2.5;
};

function DropShipSWGenerator::onEnabled(%this)
{	GameBase::playSequence(%this,0,"power");
	DropShipSWPack::setPower(GameBase::getTeam(%this),1);
}

function DropShipSWGenerator::onDisabled(%this)
{	GameBase::stopSequence(%this,0);
	DropShipSWPack::setPower(GameBase::getTeam(%this),0);
}

function CreateDropShipSWsimSet(%team)
{	%teleset = nameToID("MissionCleanup/DropShipSW"@%team);
	if(%teleset == -1)
	{	
		newObject("DropShipSW"@%team,SimSet);
		addToSet("MissionCleanup","DropShipSW"@%team);
	}
}

function checkDeployAreaDropShipSW(%client,%pos) 
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,65,65,65,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client) 
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else 
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else 
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}

function DropShipSWPack::deployShape(%player,%item)
{	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
		return false; 
	}

	if (!GameBase::getLOSInfo(%player,3)) 
	{	
		Client::sendMessage(%client,0,"Deploy position out of range"); 
		return false; 
	}

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain") 
	{	
		Client::sendMessage(%client,0,"Can only deploy on terrain"); 
		return false; 
	}

	if (!checkDeployAreaDropShipSW(%client,$los::position)) 
	return false;

	// Passed validation, create the object
	
	CreateDropShipSWsimSet(%team);
	%rot="0 0 0";
	%opos=Vector::add($los::position,"0 0 5");

	%objShip2 = newObject("StarWolf DropShip","InteriorShape", "gswdrop.dis"); 
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropshipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player)); 
	%rtime=(floor(getRandom()*150)/10);
	GameBase::setPosition(%objShip2,%pos); 
	GameBase::setRotation(%objShip2,%rot); 
	Gamebase::setMapName(%objShip2,"Starwolf Dropship"); 
	Client::sendMessage(%client,0,"Starwolf Dropship Deployed"); 
	GameBase::startFadeIn(%objShip2); 
	
	%objShip2 = newObject("PortGen1","StaticShape",Mobilegen,false);
	%pos=Vector::add(%opos,"-6.5 15 18");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"-6.5 15 18");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Internal Generator");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	//%objShip2 = newObject("PortGen1","StaticShape",Mobilegen,false);
	//%pos=Vector::add(%opos,"6.5 15 18");
	//addToSet("MissionCleanup", %objShip2);
	//addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	//GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	////GameBase::setPosition(%objShip2,"6.5 15 18");
	//GameBase::setRotation(%objShip2,%rot);
	//Gamebase::setMapName(%objShip2,"Internal Generator");
	//%rtime=(floor(getRandom()*150)/10);
	//schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	//schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	//GameBase::setActive(%objship2,True);

	%objShip2 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"-7.375 14.5 13.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"-7.375 14.5 13.5");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Inventory Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"7.375 14.5 13.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"7.375 14.5 13.5");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Inventory Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"-5.625 3.75 4.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"-5.625 3.75 4.5");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Inventory Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"5.625 3.75 4.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"5.625 3.75 4.5");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Inventory Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);   

	%objShip2 = newObject("CommandStation1","StaticShape",CommandStation,false);
	%pos=Vector::add(%opos,"0 1.5 13.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"0 1.5 13.5");
	GameBase::setRotation(%objShip2,"0 0 3.14073");
	Gamebase::setMapName(%objShip2,"Command Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);   

	%objShip2 = newObject("CommandStation1","StaticShape",CommandStation,false);
	%pos=Vector::add(%opos,"0 2.5 4.5");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"0 2.5 4.5");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Command Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"-24 2 17.625");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"-24 4 17.625");
	GameBase::setRotation(%objShip2,"0 0 3.1416");
	Gamebase::setMapName(%objShip2,"Plasma Turret");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("remoteturret","turret",PlasmaTurret,false);
	%pos=Vector::add(%opos,"24 2 17.625");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"24 4 17.625");
	GameBase::setRotation(%objShip2,"0 0 3.1416");
	Gamebase::setMapName(%objShip2,"Plasma Turret");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("chainturret","turret",Elfturret,false);
	%pos=Vector::add(%opos,"0 0.5 18");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"0 0.5 18");
	GameBase::setRotation(%objShip2,"0 0 3.14073");
	Gamebase::setMapName(%objShip2,"Elf Turret");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	%objShip2 = newObject("Sensor1","StaticShape",LargeRadar,false);
	%pos=Vector::add(%opos,"0 12 22");
	addToSet("MissionCleanup", %objShip2);
	addToSet("MissionCleanup/DropShipSW"@%team, %objship2);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	//GameBase::setPosition(%objShip2,"0 17 22");
	GameBase::setRotation(%objShip2,%rot);
	Gamebase::setMapName(%objShip2,"Radar");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship2@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship2@");",%rtime);
	GameBase::setActive(%objship2,True);

	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DropShipSWPack"]++; 
        reportDeploy(%objShip1, %client);
	return true; 
}
