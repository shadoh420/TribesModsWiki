// This is a MiniMod Plugin.
// This plugin is the GuardDog (Spotter) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    WatchdogTurret.ArmorData.cs
//    WatchdogTurret.baseProjData.cs
//    WatchdogTurret.item.cs
//    WatchdogTurret.reinitData.cs
//    WatchdogTurret.station.cs
//    WatchdogTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableWatchdog
{
	className = "Turret";
	shapeFile = "camera"; //"remoteturret";
	projectileType = WatchdogLaser;
	maxDamage = 0.65;
	maxEnergy = 300;
	minGunEnergy = 75;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.1;
	speed = 4.0;//4.0
	speedModifier = 1.5;//1.5
	range = 200;
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
	description = "Watchdog";
	damageSkinData = "objectDamageSkins";
};

function DeployableWatchdog::onAdd(%this)
{
	schedule("DeployableWatchdog::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Watchdog");
	}
}

function DeployableWatchdog::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableWatchdog::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableWatchdog::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "WatchdogPack"]--;
}

// Override base class just in case.
function DeployableWatchdog::onPower(%this,%power,%generator) {}
function DeployableWatchdog::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

