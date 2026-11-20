// This is a MiniMod Plugin.
// This plugin is the Nuclear Turret from the Ideal mod.
// Ported by Dewy.

TurretData NuclearDeployableTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = NukeTurret;
	maxDamage = 5;
	maxEnergy = 40;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 10;
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireMortar;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Nuclear Turret";
	damageSkinData = "objectDamageSkins";
};

function NuclearDeployableTurret::onAdd(%this)
{
	schedule("NuclearDeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Nuclear Turret");
	}
}

function NuclearDeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function NuclearDeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function NuclearDeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "NuclearTurretPack"]--;
}

// Override base class just in case.
function NuclearDeployableTurret::onPower(%this,%power,%generator) {}
function NuclearDeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	



