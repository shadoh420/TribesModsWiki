// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableFlak
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FlakShell;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 50;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
	speedModifier = 1.5;
	range = 300;//100
	visibleToSensor = true;
	shadowDetailMask = 8; //4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
   targetableFovRatio = 0.5;

	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableFlak::onAdd(%this)
{
	schedule("DeployableFlak::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Flak Turret");
	}
}

function DeployableFlak::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableFlak::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableFlak::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FlakPack"]--;
}

// Override base class just in case.
function DeployableFlak::onPower(%this,%power,%generator) {}
function DeployableFlak::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function DeployableFlak::onFire(%this) 
{	
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
	Projectile::spawnProjectile("FlakShell",%trans,%player,%vel);
}
