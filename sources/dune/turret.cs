//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//************************************NEW***********************************
//##########################################################################

$DamageScale[StationaryLasgun, $LandingDamageType] = 1.0;	
$DamageScale[StationaryLasgun, $ImpactDamageType] = 1.0;
$DamageScale[StationaryLasgun, $CrushDamageType] = 1.0;
$DamageScale[StationaryLasgun, $BulletDamageType] = 0.01;
$DamageScale[StationaryLasgun, $PlasmaDamageType] = 0.05;
$DamageScale[StationaryLasgun, $EnergyDamageType] = 0.0;
$DamageScale[StationaryLasgun, $ExplosionDamageType] = 1.0;
$DamageScale[StationaryLasgun, $MissileDamageType] = 2.0;
$DamageScale[StationaryLasgun, $DebrisDamageType] = 1.0;
$DamageScale[StationaryLasgun, $ShrapnelDamageType] = 0.01;
$DamageScale[StationaryLasgun, $LaserDamageType] = 0.01;	
$DamageScale[StationaryLasgun, $MortarDamageType] = 2.0;	
$DamageScale[StationaryLasgun, $BlasterDamageType] = 1.0;	
$DamageScale[StationaryLasgun, $ElectricityDamageType] = 0.01;
$DamageScale[StationaryLasgun, $MineDamageType] = 1.0;	
$DamageScale[StationaryLasgun, $StabDamageType] = 0.0;	
$DamageScale[StationaryLasgun, $PoisonDamageType] = 0.0;	
$DamageScale[StationaryLasgun, $StunnerDamageType] = 0.0;	
$DamageScale[StationaryLasgun, $NukeDamageType] = 1.0;	
$DamageScale[StationaryLasgun, $Poison2DamageType] = 0.0;	
$DamageScale[StationaryLasgun, $WormDamageType] = 1.0;	
$DamageScale[StationaryLasgun, $CutterayDamageType] = 2.0;
$DamageScale[StationaryLasgun, $SmallLasDamageType] = 0.5;
$DamageScale[StationaryLasgun, $RifleLasDamageType] = 0.5;
$DamageScale[StationaryLasgun, $HeavyLasDamageType] = 0.5;
$DamageScale[StationaryLasgun, $AsphyxiationDamageType] = 0.0;
$DamageScale[StationaryLasgun, $LargeBulletDamageType] = 0.3;


TurretData StationaryLasgun
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = HLasgunLaser;
	maxDamage = 8.0;
	maxEnergy = 60;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.001;
	speed = 2.0;
	speedModifier = 1.5;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretOn;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Stationary Lasgun Turret";
	damageSkinData = "objectDamageSkins";
};

function StationaryLasgun::onAdd(%this)
{
	schedule("StationaryLasgun::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Stationary Lasgun");
	}
}

function StationaryLasgun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function StationaryLasgun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function StationaryLasgun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "StationaryLasgunPack"]--;
}

// Override base class just in case.
function StationaryLasgun::onPower(%this,%power,%generator) {}
function StationaryLasgun::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

TurretData RepeaterLasgun
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = SLasgunLaser;
	maxDamage = 2.0;
	maxEnergy = 200;
	minGunEnergy = 0.6;
	maxGunEnergy = 0.6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.02;
	speed = 2.0;
	speedModifier = 1.5;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretOn;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Stationary Lasgun Turret";
	damageSkinData = "objectDamageSkins";
};

function RepeaterLasgun::onAdd(%this)
{
	schedule("RepeaterLasgun::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Repeater Lasgun");
	}
}

function RepeaterLasgun::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RepeaterLasgun::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RepeaterLasgun::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RepeaterLasgunPack"]--;
}

// Override base class just in case.
function RepeaterLasgun::onPower(%this,%power,%generator) {}
function RepeaterLasgun::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

TurretData RemoteLasgunTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = SLasgunLaser;
	maxDamage = 1.65;
	maxEnergy = 60;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.125;
	speed = 4.0;
	speedModifier = 1.5;
	range = 40;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretOn;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function RemoteLasgunTurret::onAdd(%this)
{
	schedule("RemoteLasgunTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,500);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Lasgun Turret");
	}
}

function RemoteLasgunTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RemoteLasgunTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RemoteLasgunTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteLasgunPack"]--;
}

// Override base class just in case.
function RemoteLasgunTurret::onPower(%this,%power,%generator) {}
function RemoteLasgunTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,500);
	GameBase::setActive(%this,true);
}	

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

TurretData RemoteProjectileGunTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = RifleBullet;
	maxDamage = 1.65;
	maxEnergy = 60;
	minGunEnergy = 2;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 4.0;
	speedModifier = 1.5;
	range = 40;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockExplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Projectile Turret";
	damageSkinData = "objectDamageSkins";
};

function RemoteProjectileGunTurret::onAdd(%this)
{
	schedule("RemoteProjectileGunTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Projectile Gun Turret");
	}
}

function RemoteProjectileGunTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RemoteProjectileGunTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RemoteProjectileGunTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RemoteProjectileGunPack"]--;
}

// Override base class just in case.
function RemoteProjectileGunTurret::onPower(%this,%power,%generator) {}
function RemoteProjectileGunTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Old

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
TurretData ELFTurret	   
{			 
	maxDamage = 10000.0;
	maxEnergy = 10000;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	range = 40;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 0;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "breath";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

$DamageScale[RocketTurret, $LandingDamageType] = 1.0;	
$DamageScale[RocketTurret, $ImpactDamageType] = 1.0;
$DamageScale[RocketTurret, $CrushDamageType] = 1.0;
$DamageScale[RocketTurret, $BulletDamageType] = 0.01;
$DamageScale[RocketTurret, $PlasmaDamageType] = 0.05;
$DamageScale[RocketTurret, $EnergyDamageType] = 0.0;
$DamageScale[RocketTurret, $ExplosionDamageType] = 1.0;
$DamageScale[RocketTurret, $MissileDamageType] = 2.0;
$DamageScale[RocketTurret, $DebrisDamageType] = 1.0;
$DamageScale[RocketTurret, $ShrapnelDamageType] = 0.01;
$DamageScale[RocketTurret, $LaserDamageType] = 0.01;	
$DamageScale[RocketTurret, $MortarDamageType] = 2.0;	
$DamageScale[RocketTurret, $BlasterDamageType] = 1.0;	
$DamageScale[RocketTurret, $ElectricityDamageType] = 0.01;
$DamageScale[RocketTurret, $MineDamageType] = 1.0;	
$DamageScale[RocketTurret, $StabDamageType] = 0.0;	
$DamageScale[RocketTurret, $PoisonDamageType] = 0.0;	
$DamageScale[RocketTurret, $StunnerDamageType] = 0.0;	
$DamageScale[RocketTurret, $NukeDamageType] = 1.0;	
$DamageScale[RocketTurret, $Poison2DamageType] = 0.0;	
$DamageScale[RocketTurret, $WormDamageType] = 1.0;	
$DamageScale[RocketTurret, $CutterayDamageType] = 2.0;
$DamageScale[RocketTurret, $SmallLasDamageType] = 0.5;
$DamageScale[RocketTurret, $RifleLasDamageType] = 0.5;
$DamageScale[RocketTurret, $HeavyLasDamageType] = 0.5;
$DamageScale[RocketTurret, $AsphyxiationDamageType] = 0.0;
$DamageScale[RocketTurret, $LargeBulletDamageType] = 0.3;



TurretData RocketTurret
{
	maxDamage = 4.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 0;
	gunRange = 0;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
//	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,14);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function RocketTurret::onFire(%this, %target)
{

	if ($TurretCanNotFire[%this] != True )
	{
		if( gamebase::getenergy(%this) > 60 )
		{
			Projectile::spawnProjectile(TurretRocket, GameBase::getMuzzleTransform(%this), Client::getControlObject(Player::getClient(%this)), "0 0 0"); // spawn new seeking projectile
			gamebase::setenergy(%this, gamebase::getenergy(%this) - 60);
			GameBase::playSound(%this, Gamebase::getdataname(%this).fireSound, 3);
		}
		$TurretCanNotFire[%this] = True;
		%delay = Gamebase::getdataname(%this).reloadDelay;
		%delay = 3.0; //not reading it otherwise for some reason.
		schedule("$TurretCanNotFire["@%this@"] = False;", %delay, %this);  		
	}

}

//--------------------------------------------

$DamageScale[MortarTurret, $LandingDamageType] = 1.0;	
$DamageScale[MortarTurret, $ImpactDamageType] = 1.0;
$DamageScale[MortarTurret, $CrushDamageType] = 1.0;
$DamageScale[MortarTurret, $BulletDamageType] = 0.01;
$DamageScale[MortarTurret, $PlasmaDamageType] = 0.05;
$DamageScale[MortarTurret, $EnergyDamageType] = 0.0;
$DamageScale[MortarTurret, $ExplosionDamageType] = 1.0;
$DamageScale[MortarTurret, $MissileDamageType] = 2.0;
$DamageScale[MortarTurret, $DebrisDamageType] = 1.0;
$DamageScale[MortarTurret, $ShrapnelDamageType] = 0.01;
$DamageScale[MortarTurret, $LaserDamageType] = 0.01;	
$DamageScale[MortarTurret, $MortarDamageType] = 2.0;	
$DamageScale[MortarTurret, $BlasterDamageType] = 1.0;	
$DamageScale[MortarTurret, $ElectricityDamageType] = 0.01;
$DamageScale[MortarTurret, $MineDamageType] = 1.0;	
$DamageScale[MortarTurret, $StabDamageType] = 0.0;	
$DamageScale[MortarTurret, $PoisonDamageType] = 0.0;	
$DamageScale[MortarTurret, $StunnerDamageType] = 0.0;	
$DamageScale[MortarTurret, $NukeDamageType] = 1.0;	
$DamageScale[MortarTurret, $Poison2DamageType] = 0.0;	
$DamageScale[MortarTurret, $WormDamageType] = 1.0;	
$DamageScale[MortarTurret, $CutterayDamageType] = 2.0;
$DamageScale[MortarTurret, $SmallLasDamageType] = 0.5;
$DamageScale[MortarTurret, $RifleLasDamageType] = 0.5;
$DamageScale[MortarTurret, $HeavyLasDamageType] = 0.5;
$DamageScale[MortarTurret, $AsphyxiationDamageType] = 0.0;
$DamageScale[MortarTurret, $LargeBulletDamageType] = 0.3;

TurretData MortarTurret
{
	maxDamage = 5.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 4.0;
	fireSound = SoundArtillaryFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Artillary Turret";
};
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};


//--------------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = false;
   validateMaterials = true;
	projectileType = MiniFusionBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
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
	description = "Remote Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Camera");
	}
}

function CameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}	


//---------------------------------------------------

function Turret::onAdd(%this)
{
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Turret");
	}
}

function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);

}

function Turret::checkOperator(%this)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,10);
	}
	else {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) {
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
}

function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
	$TurretControl[%this] = 0; 
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name != DeployableTurret && %name != CameraTurret )	
			%TDS = $Server::TeamDamageScale;
	}
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onControl (%this, %object)
{
	if(GameBase::getDataName(%this) == RocketTurret)
		return;
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
	$turretTime[%this] = 1;
}

function Turret::onDismount (%this, %object)
{
	%name = Gamebase::getDataName(%this);
	%client = Player::getClient(%object);
	$TurretControl[%this] = 0;
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
	$turretTime[%this] = 0;
	startGracePeriod(%clientId, %player);
}

$TurretCanMount[StationaryLasgun] = True;
$TurretCanMount[MortarTurret] = True;
$TurretCanMount[RocketTurret] = True;

function Turret::jump(%this,%mom)
{
	if($TurretCanMount[GameBase::getDataName(%this)] == True)
		Turret::dismount(%this, %mom);
	else
		Turret::changeControl(%this);
}

function Turret::dismount(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%pl = Client::getOwnedObject(%cl);
		%pos = GameBase::getPosition(%pl);
		%pl.lastMount = %this;
		%pl.newMountTime = getSimTime() + 3.0;
		%rotZ = getWord(GameBase::getRotation(%pl),2);
		GameBase::setRotation(%pl, "0 0 " @ %rotZ);
		Client::setControlObject(%cl,%pl);
		$turretControlled[%this] = FALSE;
		playSound(soundFlyerDismount, GameBase::getPosition(%pl));
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.turret = "";
	}
}

function Turret::onCollision(%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if($TurretCanMount[GameBase::getDataName(%this)] == True) {
			%client = Player::getClient(%object);
			if(GameBase::getDamageState(%this) == "Enabled") {
				if(GameBase::isPowered(%this) || GameBase::getDataName(%this) == StationaryLasgun ){
				if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || $NoneTeamAccess[%this] == TRUE || $FaceDancerIsSwitched[%client]) {
					if(!$turretControlled[%this] == TRUE) {
						if(getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
							if(Player::isAiControlled(%object))
								return;
							%armor = Player::getArmor(%object);
							%weapon = Player::getMountedItem(%object,$WeaponSlot);
							if(%weapon != -1) {
								%object.lastWeapon = %weapon;
								Player::unMountItem(%object,$WeaponSlot);
							}
							//Player::setMountObject(%object, %this, 0);
							%pos = GameBase::getPosition(%this);
							%rot = GameBase::getRotation(%this);
							%playerpos = vector::add(Vector::add(Vector::getFromRot(%rot,-3.1),%pos),"0 0 20");
							//GameBase::setPosition(%object,%playerpos);
							if(GameBase::getLOSInfo(%object,30,"-1.570796327 0 0")){
								%playerpos = $los::position;
							}
							
							//GameBase::setPosition(%object,%playerpos);
							//GameBase::setRotation(%object,%rot);
							Client::setControlObject(%client,%this);	
							$turretControlled[%this] = TRUE;
							playSound(soundFlyerMount,%pos);
							%object.turret = %this;
							//Recursive check for when people leave by not jumping
							schedule("Turret::isControlled("@%this@");", 6.0, %this);
						}
					}
				}
				else
					Client::sendMessage(%client,0,"Access denied - Wrong team.~waccess_denied.wav");
				}
				else
					Client::sendMessage(%client,0,"Turret not powered.~waccess_denied.wav");
			}
			else
				Client::sendMessage(%client,0,"Unit is disabled.");
		}
	}
}

function Turret::isControlled(%this)
{
	if($turretControlled[%this] == TRUE) {
		if(GameBase::getControlClient(%this) == -1)
			$turretControlled[%this] = FALSE;
		else
			schedule("Turret::isControlled("@%this@");", 6.0, %this);
	}
}