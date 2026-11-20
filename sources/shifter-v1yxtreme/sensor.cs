//-------------------------------------------------------------------------- 
//-------------------------------------------------------------------------- 

//-------------------------------------------------------------------------- 
// Default sensor methods

function Sensor::onActivate(%this)
{
	if(GameBase::isPowered(%this))
	{
		GameBase::playSequence(%this,0,"power");
	}
}

function Sensor::onDeactivate(%this)
{
	GameBase::pauseSequence(%this,0);
}

function Sensor::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	GameBase::setActive(%this,%power);
}

function Sensor::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0.03;				  
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Sensor::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
}

function Sensor::onDestroyed(%this)
{
	if($debug) echo ("StaticShape::objectiveDestroyed = Sensor.cs");
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
	%sensorName = GameBase::getDataName(%this);
	if(%sensorName == DeployableSensorJammer) 
	{
	   	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableSensorJammerPack"]--;
	}
	else if(%sensorName == DeployableMotionSensor) 
	{
	   	$TeamItemCount[GameBase::getTeam(%this) @ "MotionSensorPack"]--;
	}
	else if(%sensorName == DeployablePulseSensor) 
	{
	   	$TeamItemCount[GameBase::getTeam(%this) @ "PulseSensorPack"]--;
	}
	else
	{
		if ($Shifter::BotVersion) BotFuncs::AddRepairTask(%this);            //Werewolf
	}

	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100);
	CheckNetwork(%this);
}

function Sensor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableMotionSensor && %name != DeployablePulseSensor && %name != DeployableSensorJammer )				
	  		%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}


//------------------------------------------------------------------------

SensorData PulseSensor
{
	description = "Large Pulse Sensor";
	shapeFile = "radar";
	maxDamage = 1.5;
	range = 400;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockwave;
};

//------------------------------------------------------------------------

SensorData SatSensor
{
   	description = "Mega Radar Sensor-Jammer";
   	shapeFile = "sat_big";
   	maxDamage = 8.5;
   	range = 500;
   	dopplerVelocity = 0;
   	castLOS = true;
   	supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   	shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = LargeShockwave;
};

//------------------------------------------------------------------------

SensorData MediumPulseSensor
{
	description = "Medium Pulse Sensor";
	shapeFile = "sensor_pulse_med";
	maxDamage = 1.0;
	range = 250;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	visibleToSensor = true;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};


//------------------------------------------------------------------------

SensorData DeployableMotionSensor
{
   	description = "Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 75;
	dopplerVelocity = 1;
   	castLOS = false;
   	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
	//validateShape = true;
	//validateMaterials = true;
};


//=== A special note from Y|yukichigai -- Deployable Pulse Sensors have been modified slightly, though not in this part
//===  of the code.  Deployable Pulse Sensors will now act as WireTaps, so to speak, picking up enemy transmissions within
//===  a the set range of the sensor.  The function which determines if a WireTap has picked up a transmission is at the
//===  bottom of this file.

SensorData DeployablePulseSensor
{
	description = "Remote Pulse Sensor";
	className = "DeployableSensor";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 1.0;
	debrisId = flashDebrisSmall;
	range = 125; //200;
	castLOS = true;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
	//validateShape = true;
	//validateMaterials = true;
};


SensorData DeployableSensorJammer
{
	description = "Remote Sensor Jammer";
	className = "DeployableSensor";
	shapeFile = "sensor_jammer";
	shadowDetailMask = 4;
	visibleToSensor = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.5;
	debrisId = defaultDebrisSmall;
	range = 80;
	castLOS = true;
	supression = true;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
	//validateShape = true;
	//validateMaterials = true;
};



function DeployableSensor::onAdd(%this)
{
	schedule("DeployableSensor::deploy(" @ %this @ ");",1,%this);
}

function DeployableSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}


function CheckNetwork(%this)
{
	%team = Gamebase::getTeam(%this);
	if($Shifter::ComChat && !isnetworkdown(%team) && !ispowerdown(%team))
	{
		schedule("bottomprintall(\"<jc><f1>The " @ getteamname(%team) @ " team's communications network is down!\", 3);", 1);
		messageAll(1,"The " @ getTeamName(%team) @ " team's communications network is down!~waccess_denied.wav");
	}
}

//=== The previously mentioned WireTap function.  Checks for deployable pulse sensors in the area. Effects are nullified by
//===  command laptops, Deployable Sensor Jammers and certain types of sensor supression
function CheckWireTap(%player,%client)
{
	%rate = Player::getSensorSupression(%player);
	%pack = Player::getMountedItem(%player,$BackPackSlot);
	%armor = Player::getArmor(%player);

	if(%rate >= 30 || (%rate >= 20 && %pack == CloakingDevice) || (%rate > 0 && (%armor == "aarmor" || %armor == "afemale")))
	{
		return -2;
	}

	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%player); 
	%Mask = $StaticObjectType|$SimInteriorObjectType;
	
	%range = DeployableSensorJammer.range;

	containerBoxFillSet(%Set, %Mask, %Pos, %range, %range, %range,0);
	
	%num = Group::objectCount(%Set);


	//=== First check for Sensor Jammers to see if the effects are nullfied
	for(%i = 0; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		if(%data == "DeployableSensorJammer" && GameBase::getTeam(%obj) == GameBase::getTeam(%player))
		{
			deleteObject(%Set);
			return -2;
		}
	}

	deleteObject(%Set);

	%Set = newObject("set",SimSet);

	%range = DeployablePulseSensor.range;

	containerBoxFillSet(%Set, %Mask, %Pos, %range, %range, %range,0);

	%num = Group::objectCount(%Set);

	%team = -1;

	for(%i = 0; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		if(%data == "DeployablePulseSensor" && GameBase::getTeam(%player) != GameBase::getTeam(%obj) && GameBase::getTeam(%obj) >= 0)
		{
			if($debug) echo("Found Deployable Pulse Sensor acting as wiretap.");
			if(%pack == Laptop)
			{
				bottomprint(%client,"<jc><f1>Enemy Remote Pulse Sensor detected in area! Laptop has encrypted teamchat signal to prevent eavesdropping.",5);
				deleteobject(%set);
				return -2;
			}
			if(%team == -1 && GameBase::getTeam(%obj) >= 0)
				%team = GameBase::getTeam(%obj);
			else if(GameBase::getTeam(%obj) >= 0 && String::findSubStr(%team,GameBase::getTeam(%obj)) == -1)
				%team = %team @" "@ GameBase::getTeam(%obj);
		}
	}
	deleteObject(%set);
	return %team;
}