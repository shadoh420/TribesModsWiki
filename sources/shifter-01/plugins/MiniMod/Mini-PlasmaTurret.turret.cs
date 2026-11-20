// This is a MiniMod Plugin.
// This is the Mini-Plasma turret created/ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Mini-PlasmaTurret.ArmorData.cs
//    Mini-PlasmaTurret.baseProjData.cs
//    Mini-PlasmaTurret.item.cs
//    Mini-PlasmaTurret.reinitData.cs
//    Mini-PlasmaTurret.station.cs
//    Mini-PlasmaTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableMiniPlasma
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = PlasmaBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55; // 30
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
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
	description = "Mini-Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMiniPlasma::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableMiniPlasma::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMiniPlasma::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMiniPlasma::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaPack"]--;
}

// Override base class just in case.
function DeployableMiniPlasma::onPower(%this,%power,%generator) {}
function DeployableMiniPlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

