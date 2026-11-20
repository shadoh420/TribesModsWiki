$InvList[doorfivebyfiveForceFieldPack] = 1;
$MobileInvList[doorfivebyfiveForceFieldPack] = 1;
$RemoteInvList[doorfivebyfiveForceFieldPack] = 0;

$InvList[doorfourbyeightForceFieldPack] = 1;
$MobileInvList[doorfourbyeightForceFieldPack] = 1;
$RemoteInvList[doorfourbyeightForceFieldPack] = 0;

$CanAlwaysTeamDestroy[doorfivebyfiveForceField] = 1;
$CanAlwaysTeamDestroy[doorfourbyeightForceField] = 1;

function deployForceFieldDoor::Initialize()
{	$TeamItemCount[0 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[1 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[2 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[3 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[4 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[5 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[6 @ doorfivebyfiveForceFieldPack] = 0; 
	$TeamItemCount[7 @ doorfivebyfiveForceFieldPack] = 0; 

	$TeamItemCount[0 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[1 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[2 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[3 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[4 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[5 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[6 @ doorfourbyeightForceFieldPack] = 0;
	$TeamItemCount[7 @ doorfourbyeightForceFieldPack] = 0;
}

ItemImageData doorfivebyfiveForceFieldPackImage
{	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData doorfivebyfiveForceFieldPack
{	description = "Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = doorfivebyfiveForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{	if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) 
		{	%obj = getObjectType($los::object);
			%rot = GameBase::getRotation(%player);

			%camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Force Field Door deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
			echo("MSG: ",%client," deployed a Force Field Door ");
			return true;
		}
		else 
		{	Client::sendMessage(%client,0,"Cannot deploy here.");
		}
	}
	else
		 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

StaticShapeData doorfivebyfiveForceFieldShape
{	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 4.5;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Force Field Door";
};

function doorfivebyfiveForceFieldShape::Destruct(%this)
{	doorfivebyfiveForceFieldShape::doDamage(%this);
}

function doorfivebyfiveForceFieldShape::doDamage(%this) 
{	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{	doorfivebyfiveForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}

function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{	return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{	return;
	}
	doorfivebyfiveForceFieldShape::openDoor(%this);
	return;
}

function doorfivebyfiveForceFieldShape::openDoor(%this) 
{	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",2);
}

function doorfivebyfiveForceFieldShape::closeDoor(%this) 
{	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function doorfivebyfiveForceFieldShape::openDoor(%this) 
{	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",2);
}

ItemImageData doorfourbyeightForceFieldPackImage
{	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData doorfourbyeightForceFieldPack
{	description = "Large Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = doorfourbyeightForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function doorfourbyeightForceFieldPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
{	if (doorfourbyeightForceFieldPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function doorfourbyeightForceFieldPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) 
		{	%obj = getObjectType($los::object);
			%rot = GameBase::getRotation(%player);
			%camera = newObject("doorfourbyeightForceFieldPack","StaticShape",doorfourbyeightForceFieldShape,true);
			addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Large Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Large Force Field Door deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
			echo("MSG: ",%client," deployed a Large Force Field Door ");
			return true;
		}
		else 
		{	Client::sendMessage(%client,0,"Cannot deploy here.");
		}
	}
	else
		 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

StaticShapeData doorfourbyeightForceFieldShape
{	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield";
	maxDamage = 6.0;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Large Force Field Door";
};

function doorfourbyeightForceFieldShape::Destruct(%this)
{	doorfourbyeightForceFieldShape::doDamage(%this);
}

function doorfourbyeightForceFieldShape::doDamage(%this) 
{	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function doorfourbyeightForceFieldShape::onDestroyed(%this)
{	doorfourbyeightForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}

function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
	{	return;
	}

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
	{	return;
	}
	doorfourbyeightForceFieldShape::openDoor(%this);
	return;
}

function doorfourbyeightForceFieldShape::openDoor(%this) 
{	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",2);
}

function doorfourbyeightForceFieldShape::closeDoor(%this) 
{	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

//function doorfourbyeightForceFieldShape::openDoor(%this)  ???
//{	GameBase::startfadeout(%this);
//	%pos=GameBase::getPosition(%this);
//	%pos=Vector::add(%pos,"0 0 1000");
//	GameBase::setPosition(%this,%pos);
//	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
//	schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",2);
//}
