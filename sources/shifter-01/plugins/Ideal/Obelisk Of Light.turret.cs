// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from
// the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Obelisk Of Light.ArmorData.cs
//    Obelisk Of Light.baseProjData.cs
//    Obelisk Of Light.item.cs
//    Obelisk Of Light.Nsound.cs
//    Obelisk Of Light.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    Obelisk Of Light.station.cs
//    Obelisk Of Light.turret.cs
//
// to your MiniMod/plugins directory.

TurretData RealObeliskOfLight
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = ObeliskBeam;
	maxDamage = 5;
	maxEnergy = 80;
	minGunEnergy = 80;
	maxGunEnergy = 80;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 200; //100;
	visibleToSensor = false;
	shadowDetailMask = 4;
	supressable = true;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisLarge;
	shieldShapeName = "shield";
	fireSound = SoundLaserHit;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpLarge;
	description = "";
	damageSkinData = "objectDamageSkins";
};

function RealObeliskOfLight::onAdd(%this)
{
	schedule("RealObeliskOfLight::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.012;
	playSound(SoundBuzz,GameBase::getPosition(%this));
}

function RealObeliskOfLight::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RealObeliskOfLight::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RealObeliskOfLight::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
}

// Override base class just in case.
function RealObeliskOfLight::onPower(%this,%power,%generator) {}
function RealObeliskOfLight::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


