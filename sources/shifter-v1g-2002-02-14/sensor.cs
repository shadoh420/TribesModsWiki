//-------------------------------------------------------------------------- 
// Default sensor methods

function Sensor::onActivate(%this)
{
	if(GameBase::isPowered(%this))
	{
		GameBase::playSequence(%this,0,"power");
	}
}

function Sensor::onCollision(%this,%obj)
{	%damageLevel = GameBase::getDamageLevel(%this);
	%disable = GameBase::getDisabledDamage(%this);
	if(getObjectType(%obj) == "Player" && %damagelevel >= %disable && GameBase::getTeam(%this) == GameBase::getTeam(%obj))
	{	%client = Player::getClient(%obj);
		Client::sendMessage(%client,1,"Unit is not powered or disabled.");
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
	if (GameBase::isPowered(%this))
	{
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
		StaticShape::objectiveDestroyed(%this);

	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Sensor::onDeactivate(%this);
	%sensorName = GameBase::getDataName(%this);
	if(%sensorName == DeployableSensorJammer) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableSensorJammerPack"]--;
	else if(%sensorName == DeployableMotionSensor) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "MotionSensorPack"]--;
	else if(%sensorName == DeployablePulseSensor) 
   	$TeamItemCount[GameBase::getTeam(%this) @ "PulseSensorPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
}

function Sensor::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;

	if (%type == $FlashDamageType)
	{
		%value = (%value * 0.75);
		%energy = (GameBase::getEnergy(%this) - 100);
		GameBase::setEnergy(%this, %energy);
	}	

	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
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
};


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
	range = 200;
	castLOS = true;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
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
	maxDamage = 1.0;
	debrisId = defaultDebrisSmall;
	range = 100;
	castLOS = true;
	supression = true;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
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

//------------------------------------------------------------------------

function DeployableSensorJammer::onAdd(%this)
{
	schedule("DeployableSensorJammer::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Jammer Box");
}
function DeployableSensorJammer::deploy(%this)
{	
	GameBase::playSequence(%this,1,"deploy");
}
function DeployableSensorJammer::onEndSequence(%this,%thread)
{	
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}
function DeployableSensorJammer::onDisabled(%this) { Sensor::onDisabled(%this); %this.broke = "1"; }
function DeployableSensorJammer::onDestroyed(%this) { Sensor::onDestroyed(%this); }
function DeployableSensorJammer::onPower(%this,%power,%generator) {}
function DeployableSensorJammer::onEnabled(%this) {%this.broke = "0"; schedule("DeployableSensorJammer::checkDeployableSensorJammer(" @ %this @ ");", 0.2, %this); }
function DeployableSensorJammer::checkDeployableSensorJammer(%this)
{
	//if(GameBase::getDamageState(%this) != "Enabled")
	//	GameBase::setDamageLevel(%this, 20);

	%Set = newObject("jammerset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 150, 150, 150, 0);
	%num = Group::objectCount(%Set);

	%i = "";
	%obj = "";

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		if (%data == "CoolProj" || %data == "ShortCoolProj")
		{
				%cl = GameBase::getControlClient(%obj);
				if(%cl != -1)
				{
			      %pl = Client::getOwnedObject(%cl);
					Client::setControlObject(%cl, %pl);
					%pos = gamebase::getposition(%obj);
					GameBase::applyDamage(%this, $ImpactDamageType, 1.0,%pos,"0 0 0","0 0 0",%obj);
					bottomprint(%cl, "<jc><f2>You are being JAMMED! Control Lock Failed, Jammer DESTROYED! ", 2);
				}
		}
		else if (%data == "NapProj" || %data == "BooProj" || %data == "EMPProj" || %data == "GasProj")
		{
			if (gamebase::getteam(%this) != gamebase::getteam(%obj))
			{
				%obj.popped = "1";
				echo ("POPPED " @ %obj.popped);
				
				%rot = gamebase::getrotation(%obj);
				%dir = Vector::getfromrot(%rot);
				%vel = item::getvelocity(%obj);
				%pos = gamebase::getposition(%obj);
				%trans =  %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos;
				%fired = Projectile::spawnProjectile(DeadRocket, %trans ,%obj,%vel);
				GameBase::setDamageLevel(%obj, 1000);
				GameBase::applyDamage(%this, $ImpactDamageType, 1.0,%pos,"0 0 0","0 0 0",%obj);
			}
		}
	}
	
	if(%set)deleteobject(%set);
	
	if (%this.broke == "0")
	{
		schedule("DeployableSensorJammer::checkDeployableSensorJammer(" @ %this @ ");", 0.1, %this);
	}
}

