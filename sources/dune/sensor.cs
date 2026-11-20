//-------------------------------------------------------------------------- 
//-------------------------------------------------------------------------- 

//-------------------------------------------------------------------------- 
// Default sensor methods

function Sensor::onActivate(%this)
{
	if(GameBase::isPowered(%this)) {
		GameBase::playSequence(%this,0,"power");
	}
}

function Sensor::onDeactivate(%this)
{
	GameBase::pauseSequence(%this,0);
}

function Sensor::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
	}
	GameBase::setActive(%this,%power);
}

function Sensor::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0;				  
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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100);
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
$DamageScale[PulseSensor, $LandingDamageType] = 1.0;	
$DamageScale[PulseSensor, $ImpactDamageType] = 1.0;
$DamageScale[PulseSensor, $CrushDamageType] = 1.0;
$DamageScale[PulseSensor, $BulletDamageType] = 0.01;
$DamageScale[PulseSensor, $PlasmaDamageType] = 0.05;
$DamageScale[PulseSensor, $EnergyDamageType] = 0.0;
$DamageScale[PulseSensor, $ExplosionDamageType] = 1.0;
$DamageScale[PulseSensor, $MissileDamageType] = 2.0;
$DamageScale[PulseSensor, $DebrisDamageType] = 1.0;
$DamageScale[PulseSensor, $ShrapnelDamageType] = 0.01;
$DamageScale[PulseSensor, $LaserDamageType] = 0.01;	
$DamageScale[PulseSensor, $MortarDamageType] = 2.0;	
$DamageScale[PulseSensor, $BlasterDamageType] = 1.0;	
$DamageScale[PulseSensor, $ElectricityDamageType] = 0.01;
$DamageScale[PulseSensor, $MineDamageType] = 1.0;	
$DamageScale[PulseSensor, $StabDamageType] = 0.0;	
$DamageScale[PulseSensor, $PoisonDamageType] = 0.0;	
$DamageScale[PulseSensor, $StunnerDamageType] = 0.0;	
$DamageScale[PulseSensor, $NukeDamageType] = 1.0;	
$DamageScale[PulseSensor, $Poison2DamageType] = 0.0;	
$DamageScale[PulseSensor, $WormDamageType] = 1.0;	
$DamageScale[PulseSensor, $CutterayDamageType] = 3.0;
$DamageScale[PulseSensor, $SmallLasDamageType] = 0.5;
$DamageScale[PulseSensor, $RifleLasDamageType] = 0.5;
$DamageScale[PulseSensor, $HeavyLasDamageType] = 0.5;
$DamageScale[PulseSensor, $AsphyxiationDamageType] = 0.0;
$DamageScale[PulseSensor, $LargeBulletDamageType] = 0.3;
$DamageScale[PulseSensor, $ThrownWeaponDamageType] = 0.0;
$DamageScale[PulseSensor, $ThrownPoisonWeaponDamageType] = 0.0;

SensorData PulseSensor
{
   description = "Large Pulse Sensor";
   shapeFile = "radar";
//   explosionId = DebrisExp;
   maxDamage = 8.0;
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
$DamageScale[MediumPulseSensor, $LandingDamageType] = 1.0;	
$DamageScale[MediumPulseSensor, $ImpactDamageType] = 1.0;
$DamageScale[MediumPulseSensor, $CrushDamageType] = 1.0;
$DamageScale[MediumPulseSensor, $BulletDamageType] = 0.01;
$DamageScale[MediumPulseSensor, $PlasmaDamageType] = 0.05;
$DamageScale[MediumPulseSensor, $EnergyDamageType] = 0.0;
$DamageScale[MediumPulseSensor, $ExplosionDamageType] = 1.0;
$DamageScale[MediumPulseSensor, $MissileDamageType] = 2.0;
$DamageScale[MediumPulseSensor, $DebrisDamageType] = 1.0;
$DamageScale[MediumPulseSensor, $ShrapnelDamageType] = 0.01;
$DamageScale[MediumPulseSensor, $LaserDamageType] = 0.01;	
$DamageScale[MediumPulseSensor, $MortarDamageType] = 2.0;	
$DamageScale[MediumPulseSensor, $BlasterDamageType] = 1.0;	
$DamageScale[MediumPulseSensor, $ElectricityDamageType] = 0.01;
$DamageScale[MediumPulseSensor, $MineDamageType] = 1.0;	
$DamageScale[MediumPulseSensor, $StabDamageType] = 0.0;	
$DamageScale[MediumPulseSensor, $PoisonDamageType] = 0.0;	
$DamageScale[MediumPulseSensor, $StunnerDamageType] = 0.0;	
$DamageScale[MediumPulseSensor, $NukeDamageType] = 1.0;	
$DamageScale[MediumPulseSensor, $Poison2DamageType] = 0.0;	
$DamageScale[MediumPulseSensor, $WormDamageType] = 1.0;	
$DamageScale[MediumPulseSensor, $CutterayDamageType] = 3.0;
$DamageScale[MediumPulseSensor, $SmallLasDamageType] = 0.5;
$DamageScale[MediumPulseSensor, $RifleLasDamageType] = 0.5;
$DamageScale[MediumPulseSensor, $HeavyLasDamageType] = 0.5;
$DamageScale[MediumPulseSensor, $AsphyxiationDamageType] = 0.0;
$DamageScale[MediumPulseSensor, $LargeBulletDamageType] = 0.3;
$DamageScale[MediumPulseSensor, $ThrownWeaponDamageType] = 0.0;
$DamageScale[MediumPulseSensor, $ThrownPoisonWeaponDamageType] = 0.0;

SensorData MediumPulseSensor
{
   description = "Medium Pulse Sensor";
   shapeFile = "sensor_pulse_med";
//   explosionId = DebrisExp;
   maxDamage = 6.0;
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
   validateShape = false;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
//   explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 50;
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
   validateShape = false;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 1.0;
//   explosionId = DebrisExp;
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
   validateShape = false;
   validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.5;
//	explosionId = DebrisExp;
	debrisId = defaultDebrisSmall;
	range = 80;
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

function DeployableSensor::onPower(%this,%power,%generator)
{
	// So they don't disable when the global onPower call is made from a gen being added.
}

//------------------------------------------------------------------------



//------------------------------------------------------------------------
$DamageScale[Satelite, $LandingDamageType] = 1.0;	
$DamageScale[Satelite, $ImpactDamageType] = 1.0;
$DamageScale[Satelite, $CrushDamageType] = 1.0;
$DamageScale[Satelite, $BulletDamageType] = 0.01;
$DamageScale[Satelite, $PlasmaDamageType] = 0.05;
$DamageScale[Satelite, $EnergyDamageType] = 0.0;
$DamageScale[Satelite, $ExplosionDamageType] = 1.0;
$DamageScale[Satelite, $MissileDamageType] = 2.0;
$DamageScale[Satelite, $DebrisDamageType] = 1.0;
$DamageScale[Satelite, $ShrapnelDamageType] = 0.01;
$DamageScale[Satelite, $LaserDamageType] = 0.01;	
$DamageScale[Satelite, $MortarDamageType] = 2.0;	
$DamageScale[Satelite, $BlasterDamageType] = 1.0;	
$DamageScale[Satelite, $ElectricityDamageType] = 0.01;
$DamageScale[Satelite, $MineDamageType] = 1.0;	
$DamageScale[Satelite, $StabDamageType] = 0.0;	
$DamageScale[Satelite, $PoisonDamageType] = 0.0;	
$DamageScale[Satelite, $StunnerDamageType] = 0.0;	
$DamageScale[Satelite, $NukeDamageType] = 1.0;	
$DamageScale[Satelite, $Poison2DamageType] = 0.0;	
$DamageScale[Satelite, $WormDamageType] = 1.0;	
$DamageScale[Satelite, $CutterayDamageType] = 3.0;
$DamageScale[Satelite, $SmallLasDamageType] = 0.5;
$DamageScale[Satelite, $RifleLasDamageType] = 0.5;
$DamageScale[Satelite, $HeavyLasDamageType] = 0.5;
$DamageScale[Satelite, $AsphyxiationDamageType] = 0.0;
$DamageScale[Satelite, $LargeBulletDamageType] = 0.3;
$DamageScale[Satelite, $ThrownWeaponDamageType] = 0.0;
$DamageScale[Satelite, $ThrownPoisonWeaponDamageType] = 0.0;

SensorData Satelite
{
   description = "Satelite";
   shapeFile = "breath";
//   explosionId = DebrisExp;
   maxDamage = 20.0;
   range = 10000;
   dopplerVelocity = 0;
   castLOS = true;
   supression = false;
	visibleToSensor = false;
	sequenceSound[0] = { "power", SoundSensorPower };
	mapFilter = 4;
	mapIcon = "M_Radar";
	debrisId = flashDebrisLarge;
   shieldShapeName = "shield_medium";
	maxEnergy = 100;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};


function Satelite::onPower(%this,%power,%generator)
{
	GameBase::setActive(%this,true);
}
