$InvList[PowerNodePack] = 1;
$MobileInvList[PowerNodePack] = 1;
$RemoteInvList[PowerNodePack] = 1;

function deployPowerNode::Initialize()
{	$TeamItemCount[0 @ PowerNodePack] = 0; 
	$TeamItemCount[1 @ PowerNodePack] = 0; 
	$TeamItemCount[2 @ PowerNodePack] = 0; 
	$TeamItemCount[3 @ PowerNodePack] = 0; 
	$TeamItemCount[4 @ PowerNodePack] = 0; 
	$TeamItemCount[5 @ PowerNodePack] = 0; 
	$TeamItemCount[6 @ PowerNodePack] = 0; 
	$TeamItemCount[7 @ PowerNodePack] = 0; 
}

ItemImageData PowerNodePackImage 
{	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, -0.15, 0 };
	mountRotation = {-1.570796327, 0 , 0};
	mass = 2.5;
	firstPerson = false;
};

ItemData PowerNodePack
{	description = "Remote Power Node";
	shapeFile = "sensor_small";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = PowerNodePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData PowerNode 
{	description = "Remote Power Node";
	shapeFile = "sensor_small";
	classname = "pGen";
	debrisId = flashDebrisSmall;
	maxDamage = 8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	//sequenceSound[0] = { "power", SoundSatNode };
};

function PowerNodePack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function PowerNodePack::onDeploy(%player,%item,%pos)
{	if (PowerNodePack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function PowerNodePack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%pNode=(DeployStuff(%player,%item,PowerNode,2,4,4,2,true,2,15));
	if(%pNode)
	{	%team=GameBase::getTeam(%pNode);
		if(!$PowerSatSet[%team])
		{	$PowerSatSet[%team]=newobject("set",SimSet);
			addtoSet("missionCleanup",$PowerSatSet[%team]);
		}
		addtoSet($PowerSatSet[%team],%pNode);
		PowerNode::onEnabled(%pNode);
		return (true);
	}
		
}

function PowerNode::onDestroyed(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onDestroyed");
	%team=GameBase::GetTeam(%this);
	PowerNode::onDisabled(%this);
	DisconnectGenerator(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	removeFromSet($PowerSatSet[%team],%this);
	$TeamItemCount[%team @ PowerNodePack]--;
}

function PowerNode::onEnabled(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onEnabled");
	%team=GameBase::getTeam(%this);
	if(GameBase::getDamageState($PowerSat[%team])=="Enabled")
	{	if(GameBase::isPowered($PowerSat[%team]))
		{	GameBase::setActive(%this,true);
			GameBase::playSequence(%this,0,"power");
			GameBase::generatePower(%this, true);
			GameBase::isPowerGenerator(%this);
		}
	}
}

function PowerNode::onDisabled(%this)
{	if($tracePwr) echo($ver,"|PowerNode::onDisabled");
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}
