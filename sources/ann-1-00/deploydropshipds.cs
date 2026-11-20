$InvList[DropShipDSPack] = 1;
$MobileInvList[DropShipDSPack] = 0;
$RemoteInvList[DropShipDSPack] = 0;

ItemImageData DropShipDSPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData DropShipDSPack
{	description = "Diamond Sword DShip";
	shapeFile = "generator_p";
	className = "Backpack";
   	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = DropShipDSPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function deployDropShipDS::Initialize()
{	$TeamItemCount[0 @ DropShipDSPack] = 0;
	$TeamItemCount[1 @ DropShipDSPack] = 0;
	$TeamItemCount[2 @ DropShipDSPack] = 0;
	$TeamItemCount[3 @ DropShipDSPack] = 0;
	$TeamItemCount[4 @ DropShipDSPack] = 0;
	$TeamItemCount[5 @ DropShipDSPack] = 0;
	$TeamItemCount[6 @ DropShipDSPack] = 0;
	$TeamItemCount[7 @ DropShipDSPack] = 0;
}

function DropShipDSPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function DropShipDSPack::onDeploy(%player,%item,%pos)
{	if (DropShipDSPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
	
StaticShapeData DropShipDSGenerator
{	className = "DropShipDSGenerator";
	damageSkinData = "objectDamageSkins";
	shapeFile = "generator"; 
	maxDamage = 6.0;
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

function DropShipDSGenerator::onEnabled(%this)
{	GameBase::playSequence(%this,0,"power");
	DropShipDSPack::setPower(GameBase::getTeam(%this),1);
}

function DropShipDSGenerator::onDisabled(%this)
{	GameBase::stopSequence(%this,0);
	DropShipDSPack::setPower(GameBase::getTeam(%this),0);
}

function CreateDropShipDSsimSet(%team)
{	%teleset = nameToID("MissionCleanup/DropShipDS"@%team);
	if(%teleset == -1)
	{	
		newObject("DropShipDS"@%team,SimSet);
		addToSet("MissionCleanup","DropShipDS"@%team);
	}
}

function checkDeployAreaDropShipDS(%client,%pos) 
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

function DropShipDSPack::deployShape(%player,%item)
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

	if (!checkDeployAreaDropShipDS(%client,$los::position)) 
		return false;

	// Passed validation, create the object

	CreateDropShipDSsimSet(%team);
	%rot="0 0 0";
	%opos=Vector::add($los::position,"0 0 3");
								
	%objShip1 = newObject("Diamond Sword DropShip","InteriorShape", "gdsdrop.dis"); 
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup", %objShip1); 
	addToSet("MissionCleanup/DropshipDS"@%team, %objship1);
	GameBase::setTeam(%objShip1,GameBase::getTeam(%player)); 
	%rtime=(floor(getRandom()*150)/10);
	GameBase::setPosition(%objShip1,%pos); 
	GameBase::setRotation(%objShip1,%rot); 
	Gamebase::setMapName(%objShip1,"Diamond Sword Dropship"); 
	Client::sendMessage(%client,0,"Diamond Sword Dropship Deployed"); 
	GameBase::startFadeIn(%objShip1); 
	
	%objShip1 = newObject("Generator1","staticshape",mobilegen,false);
	%pos=Vector::add(%opos,"11.0328 5.33114 15.000196456"); 
	addToSet("MissionCleanup", %objShip1);
	addToSet("MissionCleanup/DropshipDS"@%team, %objship1);
	GameBase::setTeam(%objShip2,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Internal Generator");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objship1@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objship1@");",%rtime);
	GameBase::setActive(%objship1,True);

	%objShip1 = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"13.0328 0.0 14.000196456");
	addToSet("MissionCleanup/DropShipDS"@%team, %objship1);	
	addToSet("MissionCleanup", %objShip1);
	GameBase::setTeam(%objship1,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Inventory Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip1@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip1@");",%rtime);
	
	%objShip1 = newObject("Ammo1","StaticShape",AmmoStation,false);
	%pos = Vector::add(%opos,"-13.5328 0.53114 14.000196456");	
	addToSet("MissionCleanup/DropShipDS"@%team, %objship1);	
	addToSet("MissionCleanup", %objShip1);
	GameBase::setTeam(%objship1,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip1,%rot);
	Gamebase::setMapName(%objShip1,"Ammo Station");
	%rtime=(floor(getRandom()*150)/10);
	schedule("GameBase::setPosition("@%objShip1@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip1@");",%rtime);

	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DropShipDSPack"]++; 
        reportDeploy(%objShip1, %client);
	return true; 

} 