// This is a MiniMod Plugin.
// This plugin is the Dissection Turret from the MiniMod.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy.

TurretData DeployableDissection
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = DissectionLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 1;//0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Dissection Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableDissection::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableDissection::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDissection::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDissection::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DissectionPack"]--;
}

// Override base class just in case.
function DeployableDissection::onPower(%this,%power,%generator) {}
function DeployableDissection::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

