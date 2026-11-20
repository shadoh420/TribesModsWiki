$InvList[ShieldGenPack] = 1;
$MobileInvList[ShieldGenPack] = 1;
$RemoteInvList[ShieldGenPack] = 0;

function deployShieldGen::Initialize()
{	$TeamItemCount[0 @ ShieldGenPack] = 0; 
	$TeamItemCount[1 @ ShieldGenPack] = 0; 
	$TeamItemCount[2 @ ShieldGenPack] = 0; 
	$TeamItemCount[3 @ ShieldGenPack] = 0; 
	$TeamItemCount[4 @ ShieldGenPack] = 0; 
	$TeamItemCount[5 @ ShieldGenPack] = 0; 
	$TeamItemCount[6 @ ShieldGenPack] = 0; 
	$TeamItemCount[7 @ ShieldGenPack] = 0; 
}

ItemImageData ShieldGenPackImage 
{	shapeFile = "MagCargo";  // bridge
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData ShieldGenPack
{	description = "Shield Generator";
	shapeFile = "generator";  // bridge
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = ShieldGenPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData ShieldGen 
{	description = "Shield Generator";
	shapeFile = "generator";  // bridge
	classname = "ShieldGen";
	debrisId = flashDebrisLarge;
	maxDamage = 1.8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockWave;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName	= "shield";
	//sequenceSound[0] = { "enable", SoundFabGenStart };
	//sequenceSound[1] = { "power", SoundShieldGenerator };
};


function ShieldGenPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function ShieldGenPack::onDeploy(%player,%item,%pos)
{	if (ShieldGenPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
		
	}
}

function ShieldGenPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%gen=DeployStuff(%player,%item,ShieldGen,1,5,0,0,true,1,100);
	if(%gen)
	{	%team=GameBase::getTeam(%player);
		$ShieldGen[%team]=%gen;
		$ShieldGenOn[%team]=true;
		if($trace) 
			echo( $ver@"|NodeSet for this team is ",$NodeSet[%team]);
		if(!$NodeSet[%team])
		{	if($trace) echo( $ver@"|Creating a Node Set for Team ",%team);
			$NodeSet[%team] = newObject("ShieldNodes",SimSet);
			addToSet("MissionCleanup", $NodeSet[%team]);
		}
	}
}

function ShieldGen::onAdd(%this)
{
}

function ShieldGen::onEnabled(%this)
{	if($trace) 
		echo( $ver@"|Shield Gen OnEnabled");
	%team=GameBase::getTeam(%this);
	if(%this.destroyed==true)
	{	// Was destroyed but is no longer - Has been repaired
		%this.destroyed=false;
	}
	if(GameBase::isPowered(%this))
	{	GameBase::playSequence(%this,0,"power");
		if (%team!=-1)
		{	$ShieldGenOn[%team]=true;
			ActivateNodes(true,%team);
		}
	}
}

function ShieldGen::onDestroyed(%this)
{	if($trace) 
		echo( $ver@"|ShieldGen::onDestroyed");
	%team=GameBase::getTeam(%this);
	if($ShieldGenOn[%team])
		ShieldGen::onDisabled(%this);

	$ShieldGen[%team]=false;
	StaticShape::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShieldGenPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 8.5, 0.10, 55, 23, 3, 1.5, 1.0, 250, 170); 
}

function ShieldGen::onDisabled(%this)
{	if($trace) echo( $ver@"|ShieldGen::onDisabled");
	%team=GameBase::getTeam(%this);
	GameBase::stopSequence(%this,0);
 	$ShieldGenOn[%team]=false;
	ActivateNodes(false,%team);
}

function ShieldGen::onPower(%this, %state, %generator)
{	if($trace) 
		echo($ver,"|ShieldGen::onPower this|state|generator ",%this,%state,%generator);
	if(%state)
		ShieldGen::OnEnabled(%this);
	else
		ShieldGen::OnDisabled(%this);
}

function ActivateNodes(%status,%team)
{	if($trace) 
		echo( $ver@"|Activate Shield Nodes for Team ",%team);
	%num=$TeamItemCount[%team @ ShieldNodePack];
	if (%num>0)
	{	for(%i=0;%i<%num;%i++)
		{	%node=Group::GetObject($NodeSet[%team],%i);
			if($trace) 
				echo( $ver@"|Node ID is:",%node);
			if (%status==true)
			{	if($trace) 
					echo( $ver@"|Activating Node :",%i);
				if($trace) 
					echo( $ver@"|Node ID = ",%node);
				ShieldNode::onActivate(%node);}
			else
			{	if($trace) 
					echo( $ver@"|DeActivating Node :",%i);
				if($trace) 
					echo( $ver@"|Node ID = ",%node);
				ShieldNode::onDeActivate(%node);}
		}
	}
	else
		if($trace) 
			echo( $ver@"|No Nodes to Activate");
}
