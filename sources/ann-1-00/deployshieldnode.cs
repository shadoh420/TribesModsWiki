$InvList[ShieldNodePack] = 1;
$MobileInvList[ShieldNodePack] = 1;
$RemoteInvList[ShieldNodePack] = 1;

function deployShieldNode::Initialize()
{	$TeamItemCount[0 @ ShieldNodePack] = 0; 
	$TeamItemCount[1 @ ShieldNodePack] = 0; 
	$TeamItemCount[2 @ ShieldNodePack] = 0; 
	$TeamItemCount[3 @ ShieldNodePack] = 0; 
	$TeamItemCount[4 @ ShieldNodePack] = 0; 
	$TeamItemCount[5 @ ShieldNodePack] = 0; 
	$TeamItemCount[6 @ ShieldNodePack] = 0; 
	$TeamItemCount[7 @ ShieldNodePack] = 0; 
}

ItemImageData ShieldNodePackImage 
{	shapeFile = "sensor_jammer";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ShieldNodePack 
{	description = "Remote Shield Node";
	shapeFile = "sensor_jammer";
	classname = "Backpack";
	heading = $InvHead[ihPwr];
	imageType = ShieldNodePackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData ShieldNode 
{	description = "Shield Node";
	shapeFile = "sensor_jammer";
	classname = "ShieldNode";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 7.5;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	maxEnergy = 50;
};

function ShieldNodePack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);	
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function ShieldNodePack::onDeploy(%player,%item,%pos)
{	if (ShieldNodePack::deployShape(%player,%item)) 
	{	Player::decItemCount(%player,%item);}
}

function ShieldNodePack::deployShape(%player,%item)
{	if($trace) echo( $ver@"|Deploying Remote Shield Node");
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{	if (GameBase::getLOSInfo(%player,5)) 
		{	%obj = getObjectType($los::object);
			if($trace) echo( $ver@"|Object Type = ",%obj);
			if ((%obj == "SimTerrain" || %obj == "InteriorShape") || (%obj == "Turret" || %obj =="sensor") || (%obj == "Obstruction" || %obj =="Statue") || (%obj == "Hologram" || %obj =="LargeForceField") || ( %obj == "StaticShape"))  // not original
			{	%set = newObject("set",SimSet);
				%tnum = containerBoxFillSet(%set,$StaticObjectType,$los::position,2,2,2,0);
				//%num = GetNumObjects(%set,0,%tnum);
				%num = group::objectcount(%set);
				if(%num==1) 
				{		%boostObj=Group::getObject(%set,0);
						if (%boostObj.shieldNode)
						{	Client::sendMessage(%client,0,"DANGER!!! Shield Node Feedback!!~wError_message.wav");
							%pos1=GameBase::getPosition(%BoostObj.shieldNode);
							%pos2=GameBase::getPosition(%client);
							%vec=vector::sub(%pos1,%pos2);
							Player::onDamage(%client,$EnergyDamageType,1.5,%pos,%vec,"","head","front_left",%node);
							return false;
						}
						else
						{	deleteObject(%set);
							%prot = GameBase::getRotation(%player);
							%zRot = getWord(%prot,2);
							if (Vector::dot($los::normal,"0 0 1") > 0.6) 
							{	%rot = "0 0 " @ %zRot;}
							else
							{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
								{	%rot = "3.14159 0 " @ %zRot;}
								else
								{	%rot = Vector::getRotation($los::normal);}
							}
							%node = newObject("ShieldNode","StaticShape",ShieldNode,true);
							if($traceObj) Echo($Ver,"|Created New Object :",%newitem," | Remote Shield Node");
							echo("Shield Node Created (Node #",%node,") ");
							%team=GameBase::getTeam(%player);
							GameBase::setTeam(%node,%team);
							GameBase::setPosition(%node,$los::position);
							GameBase::setRotation(%node,%rot);
							Gamebase::setMapName(%node,"ShieldNode#" @ $totalNumNodes++ @ " " @ Client::getName(%client));
							Gamebase::StartFadein(%node);
							addToSet("MissionCleanup", %node);
							Client::setOwnedObject(%client, %node); 
							Client::setOwnedObject(%client, %player);
							GameBase::setActive(%node,true);
							playSound(SoundCreateItem,$los::position);
							%boostObj.shieldNode=%node;
							%node.isGuarding=%boostObj;
							// Add Node to Node Set
							if(!$NodeSet[%team])
							{	if($trace) echo( $ver@"|Creating a Node Set for Team ",%team);
								$NodeSet[%team] = newObject("ShieldNodes",SimSet);
								addToSet("MissionCleanup", $NodeSet[%team]);
							}
								
							addToSet($NodeSet[%team],%node);
							%name=GameBase::GetDataName(%boostObj);
							//	Get the shield strength of the Item
							if (!$ShieldGenOn[%team])
								Client::sendMessage(%client,0,"Shield Generator is destroyed or not deployed!!");
							Client::sendMessage(%client,0,"Remote Shield Node deployed - Shield activated on: "@%name);
							$TeamItemCount[GameBase::getTeam(%player) @ "ShieldNodePack"]++;
							echo("MSG: ",$User[%client]," deployed a Remote Shield Node on ",%name);
							return true;						
						}
				}
				else 
				{	deleteObject(%set);
					if (%num>1)
					{	Client::sendMessage(%client,0,"Too Many Items in area - unable to obtain single interface");}
					else if (%num==0)
					{	Client::sendMessage(%client,0,"Nothing to interface to.\n Node Must be placed close to an object which will have its shield boosted.~Werror_message.wav");}
				}
				
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain/buildings or objects");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


function ShieldNode::onEndSequence(%this)
{	echo("Node on End sequence");
	if(%this.position==1)	
		GameBase::playSequence(%this,0,"power");
}

function ShieldNode::onDestroyed(%this)
{	if($trace) echo( $ver@"|Remote Shield Node::On destroyed");
	%team=GameBase::getTeam(%this);
	$TeamItemCount[%team @ "ShieldNodePack"]--;
	$totalNumNodes--;
	for(%i=0;%i<=Group::objectCount($NodeSet[%team]);%i++)
	{	%node=Group::GetObject($NodeSet[%team],%i);
		if(%node==%this)
		{	removeFromSet($NodeSet[%team], %i);
		}
	}
	%boostObj = %this.isGuarding;
	%this.isGuarding ="";
	%boostObj.shieldNode ="";
						
	if ($ShieldGen[%team])
	{	if($trace) echo( $ver@"|Shield Gen Exists applying Node Feedback Damage");
		%pos1=GameBase::getPosition(%this);
		%pos2=GameBase::getPosition($ShieldGen[%team]);
		%vec=vector::sub(%pos1,%pos2);
		%damageLevel = GameBase::getDamageLevel($ShieldGen[%team]);
		NewStaticShapeDamage($ShieldGen[%team],%this,%damageLevel,0.35);
	}
}

function ShieldNode::onDisabled(%this)
{	if($trace) echo( $ver@"|Remote Shield Node on Disabled");
	GameBase::setRechargeRate(%this,0);
	Gamebase::setEnergy(%this,0);
	%this.Position=0;
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::playSequence(%this,1,"deploy");
	%this.shieldStrength = 0;
	
}

function ShieldNode::onActivate(%this)
{	if($trace) echo( $ver@"|Remote Shield Node onActivate");
	if($trace) echo( $ver@"|Node ID = ",%this);
	%team=GameBase::getTeam(%this);
	%this.shieldStrength = $boostStr;
	if($ShieldGen[%team])
	{	if($ShieldGenOn[%team])
		{	GameBase::setActive(%this,true);
			%this.Position=1;
			GameBase::setSequenceDirection(%this,1,1);
			GameBase::playSequence(%this,1,"deploy");
			GameBase::setRechargeRate(%this,15);
			//GameBase::playSequence(%this,1); 
		}
		else
			if($trace) echo($Ver,"| Shield Generator is Off!");

	}
	else
		if($trace) echo( $ver@"|Shield Generator Does Not Exist for This Team");
	
}

function ShieldNode::onEnabled(%this)
{	if($trace) echo( $ver@"|Shield Node - Enabled");
	if($trace) echo( $ver@"|Node ID = ",%this);
	ShieldNode::onActivate(%this);
}

function ShieldNode::onDeActivate(%this)
{	if($trace) echo( $ver@"|Shield Node - DeActivated");
	ShieldNode::onDisabled(%this);
}
