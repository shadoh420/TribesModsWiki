// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    ChainTurret.ArmorData.cs
//    ChainTurret.baseProjData.cs
//    ChainTurret.item.cs
//    ChainTurret.reinitData.cs
//    ChainTurret.station.cs
//    ChainTurret.turret.cs
//
// to your MiniMod/plugins directory.

TurretData DeployableChaingun
{
	className = "Turret";
	shapeFile = "remoteturret";
        projectileType = ChaingunTurretBullet;
	maxDamage = 0.65;
        maxEnergy = 30;
        minGunEnergy = 5;
        maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
        reloadDelay = 0.2;
	speed = 4.0;
	speedModifier = 1.5;
        range = 25;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
        fireSound = SoundPickupAmmo;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
        description = "Remote Chaingun";
	damageSkinData = "objectDamageSkins";
};

function DeployableChaingun::onAdd(%this)
{
        schedule("DeployableChaingun::deploy(" @ %this @ ");",1,%this);
        GameBase::setRechargeRate(%this,10);
        %this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
                GameBase::setMapName (%this, "Remote Chaingun");
	}
}

function DeployableChaingun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableChaingun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableChaingun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
        $TeamItemCount[GameBase::getTeam(%this) @ "ChaingunTurretPack"]--;
}

// Override base class just in case.
function DeployableChaingun::onPower(%this,%power,%generator) {}
function DeployableChaingun::onEnabled(%this) 
{
        GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}	


