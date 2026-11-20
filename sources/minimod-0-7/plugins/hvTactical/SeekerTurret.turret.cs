// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.
//
// To install this plugin just...
// Add:
//
//    SeekerTurret.ArmorData.cs
//    SeekerTurret.baseProjData.cs
//    SeekerTurret.item.cs
//    SeekerTurret.reinitData.cs
//    SeekerTurret.station.cs
//    SeekerTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableSeeker
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 0.5;//0.5
	speedModifier = 1.0;//1.0
	range = 300;
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
	description = "Seeker";
	damageSkinData = "objectDamageSkins";
};

function DeployableSeeker::onAdd(%this)
{
	schedule("DeployableSeeker::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Seeker");
	}
}

function DeployableSeeker::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSeeker::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableSeeker::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SeekerPack"]--;
}

// Override base class just in case.
function DeployablePussycat::onPower(%this,%power,%generator) {}
function DeployablePussycat::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

