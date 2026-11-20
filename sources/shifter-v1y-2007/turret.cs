// TURRET DYNAMIC DATA
//=============================================================================================================================
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
	range = 100;
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

																					 
//=============================================================================================================================
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
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

function ELFTurret::VerifyTarget(%this,%target)
{
	%client = Player::getClient(%target);
	
	if($Shifter::JustSpawned[%client]) //== Do not shoot at the freshly spawned
		return False;

	if(%client.possessed && %client.possby > 0)
		%client = %client.possby;

	//=== Don't shoot at your own deployer.
	if(%client == %this.deployr && %this.deployer > 0 && ($Shifter::DeathMatch || %client.possessing))
		return False;

	if($InfTime[%client] > 0 && (Player::getArmor(%target) == "spyarmor" || Player::getArmor(%target) == "spyfemale") && %client.origTeam == GameBase::getTeam(%this))
		return False;

	return True;
}

//=============================================================================================================================
TurretData RocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
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
	projectileType = TurretMissile;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 1.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power)
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
	}
	GameBase::setActive(%this,%power);
}

function RocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
   {
	return Turret::verifyTarget(%this,%target);
   }
   else
      	return "False";
}

//====================================================================================================
TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 20;
	maxGunEnergy = 20;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 150; //0;
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
	description = "Mortar Turret";
};

//===================================================================================================
TurretData DeployableMortar
{
	className = "Turret";
	shapeFile = "mortar_turret";
	projectileType = MortarTurretShell;
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 10;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.8;
	speed = 3.0;
	speedModifier = 1.5;
	range = 150;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Mortar Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableMortar::onAdd(%this)
{
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.02;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mortar Turret");
	}
	Turret::onAdd(%this);
}

function DeployableMortar::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableMortar::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableMortar::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--;
}


function DeployableMortar::onFire(%a, %b, %c, %d)
{
	echo ("Mortar Turret");
}

// Override base class just in case.
function DeployableMortar::onPower(%this,%power,%generator) {}
function DeployableMortar::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

 
function Sin(%theta) 
{
 	 return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}
 
function Cos(%theta) 
{
	 return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

																					 
//========================================================================================================
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

//====================================================================================================== Ion Turret
TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = IonBoltTurret;
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
	description = "Remote Ion Turret";
	damageSkinData = "objectDamageSkins";
	//validateShape = true;
	//validateMaterials = true;
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
	Turret::onAdd(%this);
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

//==================================================================================================== Plasma

TurretData DeployablePlasma
{
	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = FusionBolt;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.8;
	speed = 4.0;
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
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;

	explosionId = flashExpMedium;
	description = "Remote Plasma Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlasma::onAdd(%this)
{
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Plasma Turret");
	}
	Turret::onAdd(%this);
}

function DeployablePlasma::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployablePlasma::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployablePlasma::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlasmaTurretPack"]--;
}

// Override base class just in case.
function DeployablePlasma::onPower(%this,%power,%generator) {}
function DeployablePlasma::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//====================================================================================================== Laser Turret
TurretData DeployableLaser
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 75;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Laser Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaser::onAdd(%this)
{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Laser Turret");
	}
	Turret::onAdd(%this);
}

function DeployableLaser::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableLaser::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaser::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
}

// Override base class just in case.
function DeployableLaser::onPower(%this,%power,%generator) {}
function DeployableLaser::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//========================================================================================================= Laser Mine
TurretData DeployableLaserM
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 55;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 150.0;
	speed = 4.0;
	speedModifier = 1.5;
	range = 35;
	visibleToSensor = flase;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Point Defense Laser Mine";
	damageSkinData = "objectDamageSkins";
};

function DeployableLaserM::onAdd(%this)
{
	schedule("DeployableLaserM::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,0.0);
	%this.shieldStrength = 0;
	Turret::onAdd(%this);
}

function DeployableLaserM::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DeployableLaserM::deploy(%this)
{
	schedule("DeployableLaserM::deploy(" @ %this @ ");",1,%this);
	schedule("RemoveDLM(" @ %this @ ", " @ data.maxDamage @ ");",$Shifter::LaserMineLive,%this);

	GameBase::playSequence(%this,1,"deploy");
}

function RemoveDLM(%this, %damage)
{
	if ($Debug) echo("Removing Laser Mine");

	%this.lastDamageObject = 0;
	GameBase::setDamageLevel(%this, 5.0);

}

function DeployableLaserM::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableLaserM::onDestroyed(%this)
{
	GameBase::setDamageLevel(%this, %data.maxDamage);
	Turret::onDestroyed(%this);

}

function DeployableLaserM::onPower(%this,%power,%generator) {}
function DeployableLaserM::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,3);
	GameBase::setActive(%this,true);
}	

//===================================================================================================== EMP Turret
TurretData DeployableShock
{
	maxDamage = 1.5;
	maxEnergy = 110;
	minGunEnergy = 15;
	maxGunEnergy = 20;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 30;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield_medium";
	speed = 5.0;
	speedModifier = 1.50;
	projectileType = EMPShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "EMP Turret";

};

function DeployableShock::onAdd(%this)
{
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,6);
	//%this.shieldStrength = 0;
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote EMP Turret");
	}
	Turret::onAdd(%this);
}

function DeployableShock::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableShock::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableShock::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--;
}

// Override base class just in case.
function DeployableShock::onPower(%this,%power,%generator) {}
function DeployableShock::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

function DeployableShock::VerifyTarget(%this,%target)
{
	%client = Player::getClient(%target);
	
	if($Shifter::JustSpawned[%client])
		return False;

	if(%client.possessed && %client.possby > 0)
		%client = %client.possby;

	//=== Don't shoot at your own deployer in Deathmatch
	if(%client == %this.deployr && ($Shifter::Deathmatch || %client.possessing))
		return False;

	if($InfTime[%client] > 0 && (Player::getArmor(%target) == "spyarmor" || Player::getArmor(%target) == "spyfemale") && %client.origTeam == GameBase::getTeam(%this))
	{
		return False;
	}
	return True;
}

//================================================================================================== Satchel
TurretData DeployableSatchel
{
	className = "Turret";
	shapeFile = "camera";
//	projectileType = "Undefined";
	maxDamage = 0.01;
	maxEnergy = 75;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
	speed = 4.0;
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
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = rocketExp;
	description = "Satchel Charge";
	damageSkinData = "objectDamageSkins";
};

function DeployableSatchel::onFire(%this)
{
	GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 20, 0.75, 305, %this);
}

function DeployableSatchel::onAdd(%this)
{
	GameBase::setMapName(%this,"Satchel Charge");
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this);
	Turret::onAdd(%this);
}

function DeployableSatchel::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");	
}

function DeployableSatchel::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::setRechargeRate(%this,0);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Satchel Charge");
	}	
}

function DeployableSatchel::onControl(%this)
{
	GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 20, 0.75, 305, %this);
}

function DeployableSatchel::onDestroyed(%this)
{
	echo ("StaticShape::objectiveDestroyed = Turret.cs 1");

	StaticShape::objectiveDestroyed(%this);

	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,30,0.2,25,20,20,1.5,0.5,200,100);
  	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--;
}

function DeployableSatchel::onPower(%this,%power,%generator) {}

function DeployableSatchel::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//================================================================================================ Deployable Elf Turret
TurretData DeployableELFTurret
{			 
	className = "Turret"; //was ELF Turret
	shapeFile = "chainturret";
	projectileType = turretCharge;
	maxDamage = 1.35;
	maxEnergy = 90;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 80;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	speed = 15.0;
	speedModifier = 1.5;
	reloadDelay = 0;
	explosionId = LargeShockwave;
	description = "Deployable ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	    isSustained     = true;
	    firingTimeMS    = 750;
 	    energyRate      = 30.0;
};

function DeployableELFTurret::onAdd(%this)
{
	schedule("DeployableELFTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.009;
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "ELF Turret");
	Turret::onAdd(%this);
}

function DeployableELFTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableELFTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableELFTurret::onDestroyed(%this)
{
    	Gamebase::setActive(%this,false);
	GameBase::setRechargeRate(%this,0);
	StaticShape::objectiveDestroyed(%this); //added
	if($origteam[%this])
	{
		echo("Setting " @ %this.description @ "'s team back to " @ $origteam[%this] @ ".");
		Gamebase::setTeam(%this, $origteam[%this]);
		$origteam[%this] = "";
	}
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableELF"]--;    
	schedule("Turret::onDestroyed("@%this@");",0.8,%this);
}

function DeployableELFTurret::onPower(%this,%power,%generator) {}

function DeployableELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
}	

function DeployableELFTurret::VerifyTarget(%this,%target)
{
	%client = Player::getClient(%target);
	
	if($Shifter::JustSpawned[%client])
		return False;

	if(%client.possessed && %client.possby > 0)
		%client = %client.possby;

	//=== Don't shoot at your own deployer in Deathmatch
	if(%client == %this.deployr && ($Shifter::Deathmatch || %client.possessing))
		return False;

	if($InfTime[%client] > 0 && (Player::getArmor(%target) == "spyarmor" || Player::getArmor(%target) == "spyfemale") && %client.origTeam == GameBase::getTeam(%this))
		return False;

	return True;
}

// =====================================================================================    End new Elf Turret Code

TurretData BarrageTurret
{
	className = "Turret";
	shapeFile = "missileturret";
	projectileType = BarrageBolt;
	maxDamage = 1.5;
	maxEnergy = 350;
	minGunEnergy = 20;
	maxGunEnergy = 20;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 5;
	speedModifier = 4.1;
	range = 325;
	visibleToSensor = false; //true;
	shadowDetailMask = 4;
	dopplerVelocity = 1.5;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield_medium";
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	whirSound = SoundMissileTurretTurn;
	explosionId = flashExpMedium;
	description = "Anti-Aircraft Turret";
};

function BarrageTurret::onAdd(%this)
{
	schedule("BarrageTurret::deploy(" @ %this @ ");",now,%this);
	GameBase::setRechargeRate(%this,20);
	%this.shieldStrength = 0.03;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Anti-Aircraft Battery");
	}
	Turret::onAdd(%this);
}

function BarrageTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function BarrageTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function BarrageTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "BarragePack"]--;
}

function BarrageTurret::onPower(%this,%power,%generator) { }

function BarrageTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,20);
	GameBase::setActive(%this,true);
	%this.shieldStrength = 0.03;
}	

function BarrageTurret::verifyTarget(%this,%target) // Don't shoot if they're not in a vehicle. :) Dewy.
{
	if (GameBase::virtual(%target, "getMountObject") >= 1)
	{
		%this.shieldStrength = 0.09;
		return "True";
	}
	else
	{
		%this.shieldStrength = 0.03;
		return "False";
	}
}



//======================================================================================================= Rocket 

TurretData DeployableRocket
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = TurretMissile;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 25;
	maxGunEnergy = 25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 4.0;
	speedModifier = 1.5;
	range = 125;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "RMT Rocket Turret";
	damageSkinData = "objectDamageSkins";
};

function DeployableRocket::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
   {
	return Turret::verifyTarget(%this,%target);
   }
   else
      return False;
}


function DeployableRocket::onAdd(%this)
{
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "RMT Rocket Turret");
	}
	Turret::onAdd(%this);
}

function DeployableRocket::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableRocket::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableRocket::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--;
}

function DeployableRocket::onPower(%this,%power,%generator) {}
function DeployableRocket::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//=============================================================================================================
TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	projectileType = DeSupress;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadTime = 1.0;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = true; //false;
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
	Turret::onAdd(%this);
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

function CameraTurret::VerifyTarget(%this,%target)
{
	return true;
}

//=============================================================================================================
TurretData CloakCameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = DeSupress;
	maxDamage = 0.25;
	maxEnergy = 40;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	reloadDelay = 1.0;
	speed = 20;
	speedModifier = 1.0;
	range = 50;//0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = true; //false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Cloaking Camera";
};

function CloakCameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Cloaking Camera");
	}
	Turret::onAdd(%this);
}

function CloakCameraTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
	GameBase::startFadeOut(%this);
}

function CloakCameraTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function CloakCameraTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "EngBeacons"]--;  	
}	

function CloakCameraTurret::VerifyTarget(%this,%target)
{
	return true;
}


//========================================================================================== Arbitor Beacon
TurretData ArbitorBeacon
{
	className = "Turret";
	shapeFile = "plasammo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Beacon";
	damageSkinData = "objectDamageSkins";
};

function ArbitorBeacon::onAdd(%this)
{
	schedule("ArbitorBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Arbitor Box");
	}
	Turret::onAdd(%this);
}

function ArbitorBeacon::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }
function ArbitorBeacon::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }
function ArbitorBeacon::onDisabled(%this){}
function ArbitorBeacon::onDestroyed(%this)
{
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
		if (%this != %i)
		{
			%obj = Group::getObject(%this.set, %i);
			if(Gamebase::getTeam(%obj) == Gamebase::getTeam(%this))
			{
				GameBase::startFadeIn(%obj);
				%obj.cloaked = 0;
			}
		}
	}
	deleteObject(%this.set);
	
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBeaconPack"]--;
}

function ArbitorBeacon::onPower(%this,%power,%generator) {}
function ArbitorBeacon::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 0.1, %this);

}	

function ArbitorBeacon::checkArbitorBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled" || !%this)
		return;

	ArbitorBeacon::AreaEffect(%this);

	schedule("ArbitorBeacon::checkArbitorBeacon(" @ %this @ ");", 6.0, %this); //then recheck in 10 seconds
}

function ArbitorBeacon::AreaEffect(%this)
{

	%Set = newObject("arbbset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; //|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		
		%datab = GameBase::getDataName(%obj);
		%objn = (getObjectType(%obj));		

		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this || %datab == "ArbitorBeacon")
		{
			if ( %datab == "DeployableSensorJammer" && gamebase::getteam(%obj) != gamebase::getteam(%this) )
			{
				if(%obj.deployr && GameBase::getTeam(%obj.deployr) != GameBase::getTeam(%this))
					%killer = %obj.deployr;
				else
					%killer = %obj;
				GameBase::applyDamage(%this, $ImpactDamageType, 0.15,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
				if(GameBase::getDamageState(%this) != "Enabled")
					GameBase::applyDamage(%this, $ImpactDamageType, 5.0,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
			}
		}
		else
		{

			if(Player::getArmor(%obj) != False)
			{
				%client = Player::getClient(%obj);
				if(%client.possby != "")
					%client = %client.possby;
				if($cloakTime[%client] == 0 || !$cloakTime[%client])
					Renegades_startCloak(%client,%obj);
				else
					$cloakTime[%client] = 20;
			}
			else
				Shifter_startCloak(%obj);
		}
	}
}

function ArbitorBeacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type != $ImpactDamageType && GameBase::getDamageState(%this) == "Enabled" && (GameBase::getTeam(%object) != GameBase::getTeam(%this) || $Server::TeamDamageScale > 0))
		ArbitorBeacon::AreaEffect(%this);
	Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}
//============================================================================================= EMP Beacon

TurretData EMPBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "EMP Beacon";
	damageSkinData = "objectDamageSkins";
};

function EMPBeacon::onAdd(%this)
{
	schedule("EMPBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "EMP Box");
	}
	Turret::onAdd(%this);
}

function EMPBeacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function EMPBeacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function EMPBeacon::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function EMPBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EMPBeaconPack"]--;
}


function EMPBeacon::onPower(%this,%power,%generator) {}

function EMPBeacon::onEnabled(%this) 
{
	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 0.1, %this);
}	

function EMPBeacon::checkEMPBeacon(%this)
{

	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	EMPBeacon::AreaEffect(%this);

	schedule("EMPBeacon::checkEMPBeacon(" @ %this @ ");", 10.0, %this); //then recheck in 10 seconds
}

function EMPBeacon::AreaEffect(%this)
{
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; //|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		%data = GameBase::getDataName(%obj);
	
		if (getObjectType(%obj) == "Player")
		{
			%armor = Player::getArmor(%obj);
		}

		if (%obj != %this) // && (%armor != "parmor" || %armor != "darmor" || %armor != "jarmor" || %armor != "barmor" || %armor != "bfemale" || %armor != "spyarmor" || %armor != "spyfemale" || %armor != "stimarmor" || %armor != "stimfemale")) 
		{
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if(Gamebase::getTeam(%obj) != Client::getTeam(%this.deployr) && $Shifter::TurretKill != "false" && %this.deployr)
				{
					GameBase::applyDamage(%obj,$FlashDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this.deployr);		
				}
				else
					GameBase::applyDamage(%obj,$FlashDamageType, 0.01,GameBase::getPosition(%obj),"0 0 0","0 0 0",%this);		
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
			}
			else
			{
			}
		}
	}
	deleteObject(%set);
}

function EMPBeacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//== Retaliate when damaged
	if(%type != $ImpactDamageType && GameBase::getDamageState(%this) == "Enabled" && (GameBase::getTeam(%object) != GameBase::getTeam(%this) || $Server::TeamDamageScale > 0))
		EMPBeacon::AreaEffect(%this);
	Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

//============================================================================================= Shield Beacon

TurretData ShieldBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Shield Beacon";
	damageSkinData = "objectDamageSkins";
};

function ShieldBeacon::onAdd(%this)
{
	schedule("ShieldBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Shield Box");
	}
	Turret::onAdd(%this);
}

function ShieldBeacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ShieldBeacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ShieldBeacon::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function ShieldBeacon::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ShieldBeaconPack"]--;
}

function ShieldBeacon::onPower(%this,%power,%generator) {}

function ShieldBeacon::onEnabled(%this) 
{
	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 0.1, %this);
}	

function ShieldBeacon::checkShieldBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	ShieldBeacon::AreaEffect(%this);

	schedule("ShieldBeacon::checkShieldBeacon(" @ %this @ ");", 14.0, %this);
}

function ShieldBeacon::AreaEffect(%this)
{
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; //|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	
	containerBoxFillSet(%Set, %Mask, %Pos, 35, 35, 35,0);
	
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		%data = GameBase::getDataName(%obj);
		//=== Deployable Sensor Jammers kill things -- Y|yukichigai
		if ( %data == "DeployableSensorJammer" && gamebase::getteam(%obj) != gamebase::getteam(%this) )
		{
			if(%obj.deployr && GameBase::getTeam(%obj.deployr) != GameBase::getTeam(%this))
				%killer = %obj.deployr;
			else
				%killer = %obj;
			GameBase::applyDamage(%this, $ImpactDamageType, 0.15,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
			if(GameBase::getDamageState(%this) != "Enabled")
				GameBase::applyDamage(%this, $ImpactDamageType, 5.0,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
		}
	
		if (getObjectType(%obj) == "Player")
		{
			%armor = Player::getArmor(%obj);
		}

		if (%obj != %this) 
		{

//Y|yukichigai Bugfix
//Fix to make Shield Beacons... well... less crappy

			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
			{
				if(Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale")
					Shifter_startShield(Player::getClient(%obj),%obj,true);
			}
			else
			{
				%client = Player::getClient(%obj);
				if(!%client || getObjectType(%obj) != "Player") %client = %obj; //-1

				//=== Only shield things that will benefit from the ShieldBeacon
				if(%obj.shieldstrength <= 0.022 || !%obj.shieldstrength)
				{
					Shifter_startShield(%client,%obj,false);
					if($shieldTime[%client] < 20)
						$shieldTime[%client] = 20;
				}
			}
		}
	}
	deleteObject(%set);
}

function ShieldBeacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type != $ImpactDamageType && GameBase::getDamageState(%this) == "Enabled" && (GameBase::getTeam(%object) != GameBase::getTeam(%this) || $Server::TeamDamageScale > 0))
		ShieldBeacon::AreaEffect(%this);
	Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

//============================================================================================= Jammer Beacon
TurretData JammerBeacon
{
	className = "Turret";
	shapeFile = "bridge";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Jammer Beacon";
	damageSkinData = "objectDamageSkins";
};

function JammerBeacon::onAdd(%this) 
{
	schedule("JammerBeacon::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5); 
	if (GameBase::getMapName(%this) == "")  
	{ 
		GameBase::setMapName (%this, "Jammer Box"); 
	} 
	Turret::onAdd(%this);
}
function JammerBeacon::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function JammerBeacon::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
function JammerBeacon::onDisabled(%this) 
{ 
	Turret::onDisabled(%this); 
	%this.broke = "1"; 
}
function JammerBeacon::onDestroyed(%this) 
{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "JammerBeaconPack"]--; 
}
function JammerBeacon::onPower(%this,%power,%generator) 
{
}
function JammerBeacon::onEnabled(%this) 
{
	%this.broke = "0"; 
	schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 0.1, %this); 
}
function JammerBeacon::checkJammerBeacon(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled" || !%this)
		return;

	%Set = newObject("jammerset",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $VehicleObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 75, 75, 75,0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		
		if ( %data == "DeployableSensorJammer" && gamebase::getteam(%obj) != gamebase::getteam(%this) )
		{
			if(%obj.deployr && GameBase::getTeam(%obj.deployr) != GameBase::getTeam(%this))
				%killer = %obj.deployr;
			else
				%killer = %obj;
			GameBase::applyDamage(%this, $ImpactDamageType, 0.15,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
			if(GameBase::getDamageState(%this) != "Enabled")
				GameBase::applyDamage(%this, $ImpactDamageType, 5.0,GameBase::getPosition(%obj),"0 0 0","0 0 0",%killer);
			return;
		}
	}
	
	%i = "";
	%obj = "";

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		%data = GameBase::getDataName(%obj);
		
		if (%data == "CoolProj" || %data == "NapProj" || %data == "BooProj" || %data == "EmpProj" || %data == "GasProj")
		{
			if (gamebase::getteam(%this) != gamebase::getteam(%obj))
			{
				%obj.popped = "1";
				if ($debug) echo ("POPPED " @ %obj.popped);
				
				%rot = gamebase::getrotation(%obj);
				%dir = (Vector::getfromrot(%rot));
				%vel = item::getvelocity(%obj);
				%trans =  %rot @ " " @ %dir @ " " @ %dir @ " " @ gamebase::getposition(%obj);
				%fired = Projectile::spawnProjectile(DeadRocket, %trans ,%obj,%vel);
				GameBase::setDamageLevel(%obj, 1000);
			}
		}
	}
	
	if(%set)deleteobject(%set);
	
	if (%this.broke == "0")
	{
		schedule("JammerBeacon::checkJammerBeacon(" @ %this @ ");", 1.0, %this);
	}
}

//============================================================================================= Healing Beacon

TurretData HealingPlant
{
	className = "Turret";
	shapeFile = "cactus2";
	maxDamage = 1;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Healing Plant";
//	damageSkinData = "objectDamageSkins";
};

function HealingPlant::onAdd(%this)
{
	schedule("HealingPlant::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{
		GameBase::setMapName (%this, "Healing Box");
	}
	Turret::onAdd(%this);
}

function HealingPlant::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function HealingPlant::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function HealingPlant::onDisabled(%this)
{
	Turret::onDisabled(%this);
}
function HealingPlant::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--;
}

function HealingPlant::onPower(%this,%power,%generator) {}

function HealingPlant::onEnabled(%this) 
{
	schedule("HealingPlant::checkHealingPlant(" @ %this @ ");", 0.1, %this);
}	

function HealingPlant::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(%playerTeam != %teleTeam && Player::getArmor(%obj) != "spyarmor" && Player::getArmor(%obj) != "spyfemale")
		return;

	Item::GiveItem(%obj,RepairKit,2);
	$empTime[%c] = 0;
	$poisonTime[%c] = 0;
	$burnTime[%c] = 0;
	$freezeTime[%c] = 0;

	if(GameBase::getDamageLevel(%obj)) 
	{
		GameBase::setDamageLevel(%obj,0);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

function HealingPlant::checkHealingPlant(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	HealingPlant::AreaEffect(%this);

	schedule("HealingPlant::checkHealingPlant(" @ %this @ ");", 7.0, %this);
}

function HealingPlant::AreaEffect(%this)
{
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType; //|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
	
	containerBoxFillSet(%Set, %Mask, %Pos, 50, 50, 50,0);
	
	%num = Group::objectCount(%Set);

	if($Shifter::HealingPlant != "false" || $MatchConfig == "true")
	{	
		for(%i; %i < %num; %i++)
		{
			%obj = Group::getObject(%Set, %i);

			if (%obj != %this) 
			{
				if (getObjectType(%obj) == "Player")
				{
					%c = Player::getClient(%obj);
					if(GameBase::getTeam(%obj) != GameBase::getTeam(%this))
					{
						if(GameBase::getDamageLevel(%obj))
						{
							%armor = Player::getArmor(%obj);

							if(%armor == "spyarmor" || %armor == "spyfemale")
							{
								Gamebase::repairDamage(%obj,0.12);
								schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %obj @ "));",0.1);
							}
						}
					}
					else
					{
						if(GameBase::getDamageLevel(%obj))
						{
							Gamebase::repairDamage(%obj,0.3);
							$empTime[%c] = 0;
							$poisonTime[%c] = 0;
							$burnTime[%c] = 0;
							schedule ("playSound(ForceFieldOpen,GameBase::getPosition(" @ %obj @ "));",0.1);
						}
					}
				}
			}
		}
	}
	deleteObject(%set);
}

function HealingPlant::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type != $ImpactDamageType && GameBase::getDamageState(%this) == "Enabled" && (GameBase::getTeam(%object) != GameBase::getTeam(%this) || $Server::TeamDamageScale > 0))
		HealingPlant::AreaEffect(%this);
	Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}
//========================================================================================================================
// 					Standard Turret Functions For Shifter.
//========================================================================================================================

function Turret::onAdd(%this)
{
	//=== First try to give the turret a map name indicating what it is
	if (GameBase::getMapName(%this) == "" || GameBase::getMapName(%this) == "Turret")
	{
		GameBase::setMapName (%this, GameBase::getDataName(%this).description);
	}
	//=== If, for some reason, that fails, just use the generic name
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "Turret");
	}
	if (GameBase::getTeam(%this) >= 0)
	{
		$origTeam[%this] = GameBase::getTeam(%this);
		if(%this < $minHacked || $minHacked == -1)
			$minHacked = %this;
		if(%this > $maxHacked || $maxHacked == -1)
			$maxHacked = %this;
	}
	else
		$origTeam[%this] = "";


	//=== Clear out any deployer variables that happen to have been left behind
	%this.deployr = "";
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
   if(%cl != -1)
   {
	%pl = Client::getOwnedObject(%cl);
	Player::setMountObject(%pl, -1,0);
	Client::setControlObject(%cl, %pl);
	%cl.contrling = "";
	UnCheckObservers(%cl);
   }
   Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
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
	if (GameBase::isPowered(%this))
	{
		%this.shieldStrength = 0.03;
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
	echo ("StaticShape::objectiveDestroyed = Turret.cs 2");
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100);
				

//Y|yukichigai bug fix
//fix to prevent hacked turrets from being destroyed while still hacked
//thereby increasing the other teams item count permanently

	if($origteam[%this])
	{
		echo("Setting " @ %this.description @ "'s team back to " @ $origteam[%this] @ ".");
		Gamebase::setTeam(%this, $origteam[%this]);
		$origteam[%this] = "";
//		$HackEndTime[%this] = -1;
	}

}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
	{
		%name = GameBase::getDataName(%this);

		if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableShock)	
			%TDS = $Server::TeamDamageScale;
	}

	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);

	
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
	if (GameBase::getMapName == "Satchel Charge")
	{
		GameBase::applyDamage(%this,$DebrisDamageType,20,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

function Turret::VerifyTarget(%this,%target)
{
	%cl = Player::getClient(%target);

	if($Shifter::JustSpawned[%cl]) //== Do not shoot at the freshly spawned
		return False;

	if(%cl.possessed && %cl.possby > 0)
		%cl = %cl.possby;

	//=== Don't shoot at your own deployer.
	if(%cl == %this.deployr && %this.deployer > 0 && ($Shifter::DeathMatch || %cl.possessing))
		return False;

	if(Player::getSensorSupression(%target) < 30)
	{
		if($InfTime[%cl] > 0 && (Player::getArmor(%target) == "spyarmor" || Player::getArmor(%target) == "spyfemale") && %cl.origTeam == GameBase::getTeam(%this))
		{
			return False;
		}
		return True;
	}
	else
		return False;

}

function Turret::onCollision (%this, %object)
{
	%c = Player::getClient(%object);
	%client = Player::getClient(%object);
	%playerTeam = GameBase::getTeam(%object);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%client);
	%player.repairTarget = %this;
	%name = GameBase::getMapName(%this);
	%team = GameBase::getTeam(%this);
	%pTeam = GameBase::getTeam(%object); //added
	%pName = Client::getName(%client); //added
	%tName = getTeamName(%team); //added

	if(%team == %pTeam)
	{
		return;
	}
	
	if($origTeam[%this] == "")
	{
		$origTeam[%this] = %team;
		if(%this < $minHacked || $minHacked == -1)
			$minHacked = %this;
		if(%this > $maxHacked || $maxHacked == -1)
			$maxHacked = %this;
	}		
	
	if (%client.Laptop == "True" && (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale"))
	{
		if (%client.HackPack == True)
		{
			if($debug) echo ("Controlling");
			if(getObjectType(%object) != "Player")
			{
				return;
			}
			if(Player::isDead(%object))
			{
				return;
			}
			if(%this.disabled == true)
			{
				Client::SendMessage(%c,0,"Turret is recharging");
				return;
			}
			if(%teleTeam != %playerTeam)
			{
				if( ((Player::getArmor(%object) == "spyarmor") || (Player::getArmor(%object) == "spyfemale")) && (Player::getMountedItem(%object,$BackpackSlot) == Laptop) )
				{
					%name = GameBase::getDataName(%this);

					if(%name == "RocketTurret" || %name == "PlasmaTurret" || %name == "IndoorTurret" || %name == "ELFTurret" || %name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name ==DeployableRail || %name == MortarTurret)
					{
						if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
						{
							Client::getOwnedObject(%client).CommandTag = 1;
							Client::sendMessage(%client,0,"Re-programming turret");
							GameBase::setTeam (%this,GameBase::getTeam (%client));
							schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
							schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
							Client::takeControl(%client, %this);
							%this.Disabled = true;
							Client::getOwnedObject(%client).CommandTag = "";
							if(%name == DeployablePlasma || %name ==  DeployableRail ) GameBase::SetPosition(%object,GameBase::GetPosition(%this));
							
							TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
							TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");

							return;
						}
					}
				}
				return;
			}
			if((Player::getArmor(%obj) == "efemale") || (Player::getArmor(%obj) == "earmor"))
			{
				%name = GameBase::getDataName(%this);
				if(%name == DeployableRail)
				{
					if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object))
					{
						Client::getOwnedObject(%client).CommandTag = 1;
						Client::sendMessage(%client,0,"Manually controlling turret");
						schedule("GameBase::setTeam('" @ %this @ "','" @ $origTeam[%this] @ "');", $Shifter::HackedTime);
						schedule("" @ %this @ ".disabled = false;", $Shifter::HackedTime);
						Client::takeControl(%client, %this);
						GameBase::SetPosition(%object,GameBase::GetPosition(%this));
						%this.Disabled = true;
						Client::getOwnedObject(%client).CommandTag = "";
						return;
					}
				}
			}
		}
		else	//== Hack Pack Allows You To Hack Enemy Stuff! Not Just take control of turrets
		{
			if (%client.hacking == "True")
			{
				return;
			}
			
			if($Shifter::AllowHacking)
			{	
				%target = %this;
				if (%target != %player)
				{
					if(%name == "")
					{
						%name = (GameBase::getDataName(%player.repairTarget)).description;
					}

					%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

					%client.hacking = "true";
					if(!$origTeam[%target])
					{
						$origTeam[%target] = %team;
						if(%target < $minHacked || $minHacked == -1)
							$minHacked = %target;
						if(%target > $maxHacked || $maxHacked == -1)
							$maxHacked = %target;
					}					
				
					hackingturret(%target, %pTeam, %pName, %tName, %name, %team, $Shifter::HackTime, %client);
				}	
			}
			else
			{
				Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
			}
		}
	}
	return;
}

function Turret::Reenable(%this)
{
        %this.disabled = false;
}

function hackingturret(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if(%time > 0)
	{
		Client::sendMessage(%client,0,"Hacking In Progress - Time Remaining " @ %time);
		if(%client.hacking)
		{		
			schedule("hackingturret('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		Client::sendMessage(Player::getClient(%client),0,("Finished In " @ %time @ "."));

		if (%client.Laptop == "True")
		{		
			if(%client.hacking)
			{				
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	

					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				else
				{

					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);

					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackedTime);
					}
					else
					{
						schedule("" @ %target @ ".disabled = false;", $Shifter::HackLock);					
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}

				}
				if($debug) echo ("Client Hacking Off");
				%client.hacking = "false";
			}
		}
	}
}

function Turret::Jump (%this, %object)
{
	%client = GameBase::getControlClient(%this);
	%name = GameBase::getDataName(%this);
	
	if(%name == DeployableCoolMortar)
	{
		if(%this.load != "")
		{
			Player::unMountItem(%client,$WeaponSlot);
			
			%trans = GameBase::getMuzzleTransform(%this);
			$Faky = %this;
			$Faky2 = GameBase::getPosition(%this);
			Projectile::spawnProjectile("Faker",%trans,%this,"0 0 0");
		}
		else
		{
			Client::sendMessage(%client,0,"Missile Turret is not loaded.");
		}
	}
	else
	{
		remoteCommandMode(%client);
		remotePlayMode(%client);
	}
}

//=== Function to assign "deployer" values to projectiles, if needed -- Y|yukichigai
function FindSourceTurret(%this,%name,%turret1,%turret2)
{
	%set = newObject("set",SimSet);
	%Pos = GameBase::getPosition(%this);
	%Mask = $StaticObjectType|$SimInteriorObjectType;
	%range = 2.5;

	containerBoxFillSet(%Set, %Mask, %Pos, %range, %range, %range, 0);
	%num = Group::objectCount(%set);

	for(%i = 0; %i < %num;%i++)
	{
		%obj = Group::getObject(%set,%i);
		%data = GameBase::getDataName(%obj);
		if(%data.ProjectileType == %name || %data == %turret1 || %data == %turret2)
		{
			if(GameBase::getControlClient(%obj) != -1)
				%this.deployer = GameBase::getControlClient(%obj);
			else
				%this.deployer = %obj.deployr;

			deleteObject(%set);
			return;
		}
	}
	deleteObject(%set);
}