$InvList[SatSystemPack] = 1;
$MobileInvList[SatSystemPack] = 1;
$RemoteInvList[SatSystemPack] = 0;

function deploySatSystem::Initialize()
{	$TeamItemCount[0 @ SatSystemPack] = 0; 
	$TeamItemCount[1 @ SatSystemPack] = 0; 
	$TeamItemCount[2 @ SatSystemPack] = 0; 
	$TeamItemCount[3 @ SatSystemPack] = 0; 
	$TeamItemCount[4 @ SatSystemPack] = 0; 
	$TeamItemCount[5 @ SatSystemPack] = 0; 
	$TeamItemCount[6 @ SatSystemPack] = 0; 
	$TeamItemCount[7 @ SatSystemPack] = 0; 
}

ItemImageData SatSystemPackImage 
{	shapeFile = "magCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 8.0;
	firstPerson = false;
};

ItemData SatSystemPack
{	description = "Satelite Power System";
	shapeFile = "sat_big";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = SatSystemPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 4500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData SatSystem 
{	description = "Satelite Power System";
	shapeFile = "sat_big";
	classname = "pGen";
	debrisId = flashDebrisLarge;
	maxDamage = 15;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
	visibleToSensor = true;
	mapFilter = 4;
	//sfxAmbient = SoundSatSystem;
};

function SatSystemPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function SatSystemPack::onDeploy(%player,%item,%pos)
{	if (SatSystemPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);}
}

function SatSystemPack::deployShape(%player,%item)
{	//	Deploy ( Player, item, shape, placement, Max Dist, Categorys, Surfaces, Delete, PowerReq,PRange)
	%pSat=(DeployStuff(%player,%item,SatSystem,3,6,0,0,true,1,150));
	if(%pSat)
	{	%team=GameBase::getTeam(%pSat);
		if(!$PowerSatSet[%team])
		{	$PowerSatSet[%team]=newobject("set",SimSet);
			addtoSet("missionCleanup",$PowerSatSet[%team]);
		}
		$PowerSat[%team]=%pSat;
		return (true);
	}
}

function SatSystem::onAdd(%this)
{
}

function SatSystem::onEnabled(%this)
{	%team=GameBase::getTeam(%this);
	if(GameBase::isPowered(%this))
	{	if(%team != -1)
		{	%tnum = Group::objectCount($PowerSatSet[%team]);
			if($tracePwr) echo( $ver@"|SatSystem::OnEnabled Activating Nodes ",%tnum," for Team ",%team);
			if (%tnum>0)
			{	for (%i=0;%i<%tnum;%i++)
				{	%tgt=Group::getObject($PowerSatSet[%team],%i);
					PowerNode::OnEnabled(%tgt);
				}
			}
			GameBase::setActive(%this,true);
			GameBase::playSequence(%this,0,"power");
		}
	}
}

function SatSystem::onDestroyed(%this)
{	if($trace) echo( $ver@"|SatSystem::onDestroyed");
	%team=GameBase::getTeam(%this);
	SatSystem::onDisabled(%this);
	$PowerSat[%team]=false;
	$TeamItemCount[GameBase::getTeam(%this) @ "SatSystemPack"]--;
}

function SatSystem::onDisabled(%this)
{	%team=GameBase::getTeam(%this);
	%tnum = Group::objectCount($PowerSatSet[%team]);
	if($tracePwr) echo( $ver@"|SatSystem::OnDisAbled DE-Activating Nodes ",%tnum," for Team ",%team);
	if (%tnum>0)
	{	for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject($PowerSatSet[%team],%i);
			PowerNode::OnDisabled(%tgt);
		}
	}
}

function SatSystem::onPower(%this, %state, %generator)
{	if($trace) echo($ver,"|SatSystem::onPower this|state|generator ",%this,%state,%generator);
	if (%state)
		SatSystem::onEnabled(%this);
	else
		SatSystem::onDisabled(%this);
}
