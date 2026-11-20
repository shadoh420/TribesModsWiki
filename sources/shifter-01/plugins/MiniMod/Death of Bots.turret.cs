// This is a MiniMod Plugin.
// This plugin is the Death of Bots.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy then modified further by PeterT.

TurretData DeployableDoB
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = DoBLaser;
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
	description = "Death of Bots";
	damageSkinData = "objectDamageSkins";
};

function DeployableDoB::onAdd(%this)
{
	schedule("DeployableDissection::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "DoB");
	}
}

function DeployableDoB::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableDoB::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableDoB::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DoBPack"]--;
}

// Override base class just in case.
function DeployableDoB::onPower(%this,%power,%generator) {}
function DeployableDoB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

