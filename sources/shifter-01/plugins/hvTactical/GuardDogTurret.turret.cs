// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    GuardDogTurret.ArmorData.cs
//    GuardDogTurret.baseProjData.cs
//    GuardDogTurret.item.cs
//    GuardDogTurret.reinitData.cs
//    GuardDogTurret.station.cs
//    GuardDogTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableConTurret //TurretData name, used in item.cs 3 times
{
	className = "Turret";//type classification
	shapeFile = "chainturret"; //"remoteturret";  shape, texture used
	projectileType = Watch;//projectile fired
	maxDamage = 1.5;//stamina of unshielded turret
	maxEnergy = 300;//amount of turret energy
	minGunEnergy = 75;//?
	maxGunEnergy = 10;//?
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };//sound made when deployed
	reloadDelay = 1.5;//0.05,delay between shots (sec)
	speed = 2.0;//4.0; traverse speed?
	speedModifier = 1.5;//?
	range = 150;//sensor range of turret
	visibleToSensor = true;//shows up on command screen (y,n)
	shadowDetailMask = 4;//?
	dopplerVelocity = 1; //2; 0=free attack, 2=motion sensitive?
	castLOS = true;//tracks when target not visible?
	supression = false;//acts as sensor jammer, true=yes
	suppressable = false;//can be jammed, true=yes?
	pinger = false;//?
	mapFilter = 2;//?
	mapIcon = "M_turret";//icon as appears on command screen
	debrisId = flashDebrisLarge;//debris graphic
	shieldShapeName = "shield";//shield type?
	fireSound = SoundPlasmaTurretFire;//sound when firing
	activationSound = SoundChainTurretOn;//sound when on
	deactivateSound = SoundChainTurretOff;//sound when off
	explosionId = debrisexplarge;//explosion graphic
	description = "Guard Dog";//description pertaining to ? file
	damageSkinData = "objectDamageSkins";//damage graphic
};

function DeployableConTurret::onAdd(%this)
{
	schedule("DeployableConTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Guard Dog");
	}
}

function DeployableConTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableConTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableConTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ConPack"]--;
}

// Override base class just in case.
function DeployableConTurret::onPower(%this,%power,%generator) {}
function DeployableConTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

