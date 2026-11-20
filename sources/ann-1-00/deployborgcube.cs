$InvList[BaseOpsPack] = 1;
$MobileInvList[BaseOpsPack] = 0;
$RemoteInvList[BaseOpsPack] = 0;

$ItemMax[armormBuilder, BaseOpsPack] = 1;
$ItemMax[armorfBuilder, BaseOpsPack] = 1;

function deployBorgCube::Initialize()
{	
	$TeamItemCount[0 @ BaseOpsPack] = 0;
	$TeamItemCount[1 @ BaseOpsPack] = 0;
	$TeamItemCount[2 @ BaseOpsPack] = 0;
	$TeamItemCount[3 @ BaseOpsPack] = 0;
	$TeamItemCount[4 @ BaseOpsPack] = 0;
	$TeamItemCount[5 @ BaseOpsPack] = 0;
	$TeamItemCount[6 @ BaseOpsPack] = 0;
	$TeamItemCount[7 @ BaseOpsPack] = 0;
	$TeamItemCount[0 @ DeployableBaseOps] = 0;
	$TeamItemCount[1 @ DeployableBaseOps] = 0;
	$TeamItemCount[2 @ DeployableBaseOps] = 0;
	$TeamItemCount[3 @ DeployableBaseOps] = 0;
	$TeamItemCount[4 @ DeployableBaseOps] = 0;
	$TeamItemCount[5 @ DeployableBaseOps] = 0;
	$TeamItemCount[6 @ DeployableBaseOps] = 0;
	$TeamItemCount[7 @ DeployableBaseOps] = 0;
}

ItemImageData BaseOpsPackImage
{	
	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.4 };
	mass = 5.0;
	firstPerson = false;
};

ItemData BaseOpsPack // Borg cube Pack
{	
	description = "The Borg Cube";
	shapeFile = "logo";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = BaseOpsPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9950;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData DeployableBaseOps // Main Borg cube panel...
{	
	className = "DeployableBaseOps";
	damageSkinData = "objectDamageSkins";
	shapeFile = "elevator6x6thin";
	maxDamage = 50;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,1.0,1.0};
	side = "single";
	isTranslucent = true;
};

StaticShapeData BaseOpsGenerator
{	
	className = "BaseOpsGenerator";
	damageSkinData = "objectDamageSkins";
	shapeFile = "generator"; 
	maxDamage = 3.0;
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

function BaseOpsGenerator::onDestroyed(%this)
{	
	BaseOpsGenerator::onDisabled(%this);
	%team=GameBase::getTeam(%this);
	%set=nameToID("MissionCleanup/BaseOps!"@%team);
	if(%set!=-1) 
	{	
		DeployableBaseOps::onDestroyed(Group::getObject(%set,0));
	}
}

function BaseOpsGenerator::onEnabled(%this)
{	
	BaseOpsGenerator::setActive(%this,true);
}

function BaseOpsGenerator::onDisabled(%this)
{	
	GameBase::stopSequence(%this,0);
	DeployableBaseOps::setPower(GameBase::getTeam(%this),0);
}

function BaseOpsGenerator::setActive(%this)
{	
	GameBase::playSequence(%this,0,"power");
	DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}

function BaseOpsGenerator::onActivate(%this)
{	
	GameBase::playSequence(%this,0,"power");
	DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}

function DeployableBaseOps::Destruct(%this)
{	
	DeployableBaseOps::doDamage(%this);
}

function DeployableBaseOps::doDamage(%this) 
{	
	calcRadiusDamage(%this, $DebrisDamageType, 5, 1, 25, 15, 4, 0.4, 0.1, 250, 100); 
}

function DeployableBaseOps::powerState(%this) 
{	
	%team=GameBase::getTeam(%this);
	%set=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
	if(%set!=-1) 
	{	
		%obs=Group::objectCount(%set);
		%gen=-1;
		%obj=-1;
		for(%x=0;%x<%obs;%x++) 
		{	
			%objt=Group::getObject(%set,%x);
			if(%objt==%this) 
			{	
				%obj=%objt; 
			}
			if(GameBase::getDataName(%objt)=="BaseOpsGenerator") 
				%gen=%objt;
		}
		if(%obj!=-1&&%gen!=-1)
		{	
			if(GameBase::getDamageState(%gen)!="Enabled") 
			{	
				return 0;
			}
			else 
			{	
				return 1;
			}
		}
	}
	return 0;
}

function DeployableBaseOps::onDestroyed(%this)
{	
	DeployableBaseOps::doDamage(%this);
	%team=GameBase::getTeam(%this);
	%set1=nameToID("MissionCleanup/BaseOps!"@%team);
	%set2=nameToID("MissionCleanup/BaseOpsX!"@%team);
	%set3=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
	if(%set1!=-1&&%set2!=-1&&%set3!=-1) 
	{	
		$TeamItemCount[%team @ "DeployableBaseOps"]--;
		if(%this==Group::getObject(%set1,0)) 
		{	
			%objs=group::objectcount(%set1);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set1,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
				if(GameBase::getMapName(%obj)=="Borg Cube") 
					schedule("$TeamItemCount["@%team@"@\"DeployableBaseOps\"]=0;",20);
			} 
			deleteObject(%set1);
			%objs=group::objectcount(%set3);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set3,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
			} 
			deleteObject(%set1);
			%objs=group::objectcount(%set2);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set2,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
			} 
			deleteObject(%set2);
		} 
		else 
		{	
			GameBase::setDamageLevel(Group::getObject(%set1,0),100);
		}
	}
}

function BaseOpsPack::onUse(%player,%item)
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	
		Player::deployItem(%player,%item);
	}
}

function BaseOpsPack::onDeploy(%player,%item,%pos)
{	
	if (BaseOpsPack::deployShape(%player,"Borg Cube",DeployableBaseOps,%item)) 
	{	
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"]++;
	}	
}

function CreateBaseOpsimSet(%team)
{	
	%teleset = nameToID("MissionCleanup/BaseOps!"@%team);
	if(%teleset == -1)
	{	
		newObject("BaseOps!"@%team,SimSet);
		addToSet("MissionCleanup","BaseOps!"@%team);
	}
	%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team);
	if(%teleset == -1)
	{	
		newObject("BaseOpsX!"@%team,SimSet);
		addToSet("MissionCleanup","BaseOpsX!"@%team);
	}
	%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
	if(%teleset == -1)
	{	
		newObject("BaseOpsX!"@%team@"!Powered",SimSet);
		addToSet("MissionCleanup","BaseOpsX!"@%team@"!Powered");
	}
}

function DeployableBaseOps::setPower(%team,%power) 
{	
	%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
	if(%teleset != -1)
	{	
		%objs=Group::objectCount(%teleset);
		if(%objs) 
		{	
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%teleset,%x);
				if(GameBase::getMapName(%obj)=="Borg Cube Inventory Station" || GameBase::getMapName(%obj)=="Borg Cube Ammo Station" || GameBase::getMapName(%obj)=="Borg Cube Command Station") 
				{	
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						Station::onPower(%obj,%power,0);
					}
					else 
					{	
						Station::onPower(%obj,0,0);
					}
				}
				else if(GameBase::getMapName(%obj)=="Borg Cube External Defense Turret") 
				{	
					GameBase::setActive(%obj,%power);
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						if (%power) 
						{	
							%obj.shieldStrength = 0.03;
							GameBase::setRechargeRate(%obj,10);
							GameBase::playSequence(%obj,0,"power");
						}
						else 
						{	
							%this.shieldStrength = 0;
							GameBase::setRechargeRate(%obj,0);
							GameBase::StopSequence(%obj,0);
						}
						GameBase::setActive(%this,%power);
					}
					else 
					{	
						GameBase::StopSequence(%obj,0); 
					}
				}
			}
		}
	}
}

function BaseOpsPack::deployShape(%player,%name,%shape,%item)
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"] < $TeamItemMax[DeployableBaseOps]) 
	{	
		if (GameBase::getLOSInfo(%player,3))
		{	
			%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7) 
			{	
				%team=GameBase::getTeam(%player);
				CreateBaseOpsimSet(%team);
				%rot="0 0 0";
				%opos=Vector::add($los::position,"0 0 5");
	
				//Borg Cube Start
				%sensor = newObject("Borg CubeCL1T0","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 0 0");
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				GameBase::setPosition(%sensor,%pos);
				GameBase::startFadeIn(%sensor);
				Gamebase::setMapName(%sensor,%name);

				%dcont=1;
				for(%z=0;%z<10;%z++) 
				{	
					%tpos=Vector::add(%opos,"0 0 "@%z);
					GameBase::setPosition(%sensor,%tpos);
					for(%x=0;%x<360;%x+=5) 
					{	
						%rad=(%x/180)*3.141592654;
						%rpos="0 0 "@%rad;
						if(GameBase::getLOSInfo(%sensor,14,%rpos)!=False) 
						{	
							%dcont=0;
							break;
						}
					}
					if(%dcont) 
						%z++;
				}
				if(!%dcont) 
				{	
					GameBase::setPosition(%sensor,"-2000,-2000,-2000"); 
					GameBase::setDamageLevel(%sensor,2000); //changed from 10000
					Client::sendMessage(%client,0,"Cannot build Borg Cube. Object(s) in way.");
					return false;
				}
				%opos=%tpos;
				addToSet("MissionCleanup/BaseOps!"@%team, %sensor);
				echo("Final Deployment Position: "@%opos);

				//Inventory Station
				%sensor = newObject("Inventory1","StaticShape",InventoryStation,true);
				%pos=Vector::add(%opos,"6.863 6.844 6.496");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -0.752468");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Inventory Station");

				//Command Station
				%sensor = newObject("Command1","StaticShape",CommandStation,true);
				%pos=Vector::add(%opos,"7.458 -7.435 6.496");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -2.37301");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Command Station");

				//Ammo Station
				%sensor = newObject("Ammo1","StaticShape",AmmoStation,true);
				%pos=Vector::add(%opos,"7.015 -6.949 0.496");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -2.34776");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Ammo Station");

				//Internal Defense Turret
				%sensor = newObject("chainturret","Turret",BorgELFTurret,true);
				%pos=Vector::add(%opos,"-7.459 7.344 1.000");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -1.603911");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Internal Defense Turret");

				//External Defense Turret
				%sensor = newObject("camera","Turret",BorgTurret,true);
				%pos=Vector::add(%opos,"0 8.7 6.2");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"-1.56 0 0");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" External Defense Turret");

				//External Defense Turret 2
				%sensor = newObject("camera","Turret",BorgTurret,true);
				%pos=Vector::add(%opos,"0 -8.7 6.2");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"1.56 0 0");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" External Defense Turret2");

				//External Defense Turret 3
				%sensor = newObject("camera","Turret",BorgTurret,true);
				%pos=Vector::add(%opos,"0 0 12.496");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 0 0");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" External Defense Turret3");

				//External Defense Turret 4
				%sensor = newObject("camera","Turret",BorgTurret,true);
				%pos=Vector::add(%opos,"8.7 0 6.2");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 1.56 0");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" External Defense Turret4");

				//External Defense Turret 5
				%sensor = newObject("camera","Turret",BorgTurret,true);
				%pos=Vector::add(%opos,"-8.7 0 6.2");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -1.56 0");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" External Defense Turret5");

				//External Defense Turret 2
				//%sensor = newObject("camera","Turret",BorgLaserTurret,true);
				//%pos=Vector::add(%opos,"0 -5 12.498");
				//addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				//addToSet("MissionCleanup", %sensor);
				//GameBase::setTeam(%sensor,%team);
				//GameBase::setRotation(%sensor,"0 0 1.57");
				//%rtime=(floor(getRandom()*150)/10);
				//schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				//schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				//Gamebase::setMapName(%sensor,%name@" External Defense Turret")

				//Generator
				%sensor = newObject("Generator1","StaticShape",MobileGen,true);
				%pos=Vector::add(%opos,"-5.909 6.186 6.495");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -0.0219599");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Generator");
				GameBase::setActive(%sensor,True);

				//Self-destruct key 
				%sensor = newObject("Generator1","StaticShape",BaseOpsGenerator,true);
				%pos=Vector::add(%opos,"-5.909 6.186 6.495");
				addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,"0 -0 -0.0219599");
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name@" Generator");
				GameBase::setActive(%sensor,True);

				//The Walls
				//Wall 
				%sensor = newObject("Borg CubeCL1T1","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 0 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T2","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 0 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T3","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 6 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T4","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 -6 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T6","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 -6 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T7","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 6 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1T8","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 -6 0");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W0","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 0 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W1","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 6 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W2","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 -6 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W3","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W4","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W5","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W6","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 0 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W7","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 6 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W8","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 -6 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W9","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 -8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W10","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 -8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL1W11","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 -8.5 3");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T0","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 0 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T1","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 0 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T2","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 0 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T3","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 6 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T4","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 -6 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T5","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 6 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T6","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 -6 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2T7","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 6 6");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W0","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 0 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W1","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 6 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W2","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"8.5 -6 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W9","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 8.5 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W4","StaticShape",BorgWindow,true);
				%pos=Vector::add(%opos,"6 8.5 7");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W5","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 8.5 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W6","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 0 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W7","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 6 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W8","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-8.5 -6 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W9","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 -8.5 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W10","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 -8.5 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL2W11","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 -8.5 9");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T0","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 0 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T1","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 0 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T2","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 0 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T3","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T4","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"0 -6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T5","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T6","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"6 -6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T7","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				%sensor = newObject("Borg CubeCL3T8","StaticShape",%shape,true);
				%pos=Vector::add(%opos,"-6 -6 12");
				addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
				addToSet("MissionCleanup", %sensor);
				GameBase::setTeam(%sensor,%team);
				GameBase::setRotation(%sensor,%rot);
				%rtime=(floor(getRandom()*150)/10);
				schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
				schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
				Gamebase::setMapName(%sensor,%name);

				Client::sendMessage(%client,0,%item.description @ " under construction. 15 seconds to completion.");
				echo("Borg Cube Deployed Deployed ("@%sensor@")");
				playSound(SoundPickupBackpack,$los::position);
				GameBase::startfadein(%sensor);
				return true;
			}
			else 
			Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

StaticShapeData BorgWindow // closest to 6x6, but no 6x6 forcefield
{	
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 25.0;
	isTranslucent = true;
	description = "Borg Cube Window";
};
