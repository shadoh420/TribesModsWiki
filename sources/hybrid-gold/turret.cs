//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 500;
	minGunEnergy = 1;
	maxGunEnergy = 100;
	reloadDelay = 0.3;
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
	speed = 5.0;
	speedModifier = 5.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
																						 
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
	projectileType = TerawattBullet;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "Lightning Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

TurretData RocketTurret
{
	maxDamage = 0.50;
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
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Disc Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if (%power) {
		%this.shieldStrength = 0.03;
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

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 300;
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
	description = "CFM Turret";
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
	description = "Fusion Turret";

};


//--------------------------------------------

TurretData ESTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = TerawattBullet;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 10.0;
	speedModifier = 1.5;
	range = 350;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 100;
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
	description = "[ES Turret]";
	damageSkinData = "objectDamageSkins";
};

function ESPack::onDeploy(%player,%item,%pos)
{
	if (ESPack::deployShape(%player,%item)&& !$build) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function ESPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ESBoxMaxLength,$ESBoxMaxWidth,$ESBoxMaxHeight,0);
				%num = CountObjects(%set,"ESTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ESBoxMinLength,$ESBoxMinWidth,$ESBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"ES Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								if(!$build)Client::sendMessage(%client,0,"ES Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ESPack"]++;
								echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a ES Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Turrets only deploy on flat surfaces");}
					} 
					else{

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Sonic interference with other turrets.");
			}
				}
			   else {

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other ES turrets.");
			}
			}
			else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");}
		}
		else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range");}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
	

//--------------------------------------------

TurretData TrackerTurret
{
	className = "Turret";
	shapeFile = "camera";
	projectileType = targetLaser;
	maxDamage = 1;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 2;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	shieldShapeName = "shield";
	fireSound = SoundTaserFire;
	activationSound = SoundTaserActivate;
	deactivateSound = SoundTaserDeactivate;
	explosionId = flashExpMedium;
	description = "Taser Turret";
	damageSkinData = "objectDamageSkins";
};

function TrackerTurretPack::onDeploy(%player,%item,%pos)
{
	if (TrackerTurretPack::deployShape(%player,%item)&& !$build) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TrackerTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"TrackerTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"TrackerTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",TrackerTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Tracker Turret#" @ $totalNumTTurrets++ @ " " @ Client::getName(%client));
								if(!$build)Client::sendMessage(%client,0,"Tracker Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TrackerTurretPack"]++;
								echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Tracker Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Turrets only deploy on flat surfaces");}
					} 
					else{

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Ionic interference with other turrets.");
			}
				}
			   else {

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other remote turrets.");
			}
			}
			else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");}
		}
		else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range");}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//--------------------------------------------
//--------------------------------------------

TurretData CameraTurret
{
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 90000;
	maxEnergy = 0.0001;
	speed = 20;
	speedModifier = 1.0;
	range = 100;
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
	description = "Spy Camera";
};

function CameraTurret::onAdd(%this)
{
	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Spy Camera");
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
	if (GameBase::isPowered(%this)) {
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
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 
		0.1, 200, 100); 
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
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function Turret::onDismount (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Leaving turret " @ %this);
}

//function Turret::onCollision (%this, %object)
//{
//	if (getObjectType (%object) == "Player")
//		{
//			Player::mountObject (%object, %this);
//		}
//}
//=====H=Y=B=R=I=D========

TurretData ARPGTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = AssaultChaingunBullet;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[ARPG Turret]";
	damageSkinData = "objectDamageSkins";
};

function ARPGTurret::onAdd(%this)
{
	schedule("ARPGTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "ARPG Turret");
	}
}

function ARPGTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ARPGTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ARPGTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ARPGTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	
//---------------------------------------------
	TurretData ELFx2Turret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
      sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = TachyonBullet;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "[Fusion Turret]";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};

function ELFx2Turret::onAdd(%this)
{
	schedule("ELFx2Turret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Fusion Turret");
	}
}

function ELFx2Turret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ELFx2Turret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ELFx2Turret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ELFx2TurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
//--------------------------------------------
TurretData KickerTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = KickerBullet;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[Kicker Turret]";
	damageSkinData = "objectDamageSkins";
};

function KickerTurret::onAdd(%this)
{
	schedule("KickerTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Kicker Turret");
	}
}

function KickerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function KickerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function KickerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "KickerTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	
//--------------------------------------------
TurretData FireFlyTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = HydraBullet;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[Fire Fly Turret]";
	damageSkinData = "objectDamageSkins";
};

function FireFlyTurret::onAdd(%this)
{
	schedule("FireFlyTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Fire Fly Turret");
	}
}

function FireFlyTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function FireFlyTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function FireFlyTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "FireFlyTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//--------------------------------------------
TurretData RailTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MinigunBullet;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[Rail Turret]";
	damageSkinData = "objectDamageSkins";
};

function RailTurret::onAdd(%this)
{
	schedule("RailTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Rail Turret");
	}
}

function RailTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function RailTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function RailTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}
//--------------------------------------------
TurretData MeltTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = AfterBurnerBullet;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[Melt Turret]";
	damageSkinData = "objectDamageSkins";
};

function MeltTurret::onAdd(%this)
{
	schedule("MeltTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Melt Turret");
	}
}

function MeltTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MeltTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MeltTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MeltTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-------------------------------------------------------------
TurretData LaserTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = PlasmaLaser;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 50;
	visibleToSensor = true;
	shadowDetailMask = 0;
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
	description = "[Laser Turret]";
	damageSkinData = "objectDamageSkins";
};

function LaserTurret::onAdd(%this)
{
	schedule("LaserTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Laser Turret");
	}
}

function LaserTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function LaserTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function LaserTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurretPack"]--;
}

// Override base class just in case.
function LaserTurretB::onPower(%this,%power,%generator) {}
function LaserTurretB::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-------------------------------------------------------------
TurretData TrackerTurret
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
	range = 500;
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
	description = "Tracker Turret";
	damageSkinData = "objectDamageSkins";
};

function TrackerTurret::onAdd(%this)
{
	schedule("TrackerTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Tracker Turret");
	}
}

function TrackerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function TrackerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function TrackerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TrackerTurretPack"]--;
}

// Override base class just in case.
function TrackerTurret::onPower(%this,%power,%generator) {}
function TrackerTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-------------------------------------------------------------
TurretData MiniSmokeTurret
{
	maxDamage = 2.0;
	maxEnergy = 500;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 60;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisSmall;
	className = "Turret";
	shapeFile = "camera";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = MiniSmokeTurretproj;
	reloadDelay = 2.1;
	explosionId = debrisExpMedium;
	description = "Electrode Turret";

	fireSound        = SoundELFIdle;
	activationSound  = SoundTaserActivate;
	deactivateSound  = SoundTaserdeActivate;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 2000;
   energyRate      = 30.0;

};

function MiniSmokeTurret::onAdd(%this)
{
	schedule("MiniSmokeTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Electrode Turret");
	}
}

function MiniSmokeTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniSmokeTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniSmokeTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniSmokeTurretPack"]--;
}

// Override base class just in case.
function MiniSmokeTurret::onPower(%this,%power,%generator) {}
function MiniSmokeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	


//-------------------------------------------------------------


//-------------------------------------------------------------
//--------------------------------------------
//
//function RocketTurret::onPower(%this,%power,%generator)
//{
//	if (%power) {
//		%this.shieldStrength = 0.03;
//		GameBase::setRechargeRate(%this,14);
//	}
//	else {
//		%this.shieldStrength = 0;
//		GameBase::setRechargeRate(%this,0);
//		Turret::checkOperator(%this);
//	}
//	GameBase::setActive(%this,%power);
//}
//
//function RocketTurret::verifyTarget(%this,%target)
//{
//   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
//      return "True";
//   else
//      return "False";
//}
//////////////////////////////////////////////////////////////////

TurretData MiniFlakTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniFlakproj;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
        range = 125;
        //gunRange = 300;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1;
	speed = 2;
	speedModifier = 2;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-Flak Turret";
	damageSkinData = "objectDamageSkins";
};

//-------------------------------------------------------------------------------

function MiniFlakTurret::onAdd(%this)
{
	schedule("MiniFlakTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-Flak Turret");
	}
}

function MiniFlakTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniFlakTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniFlakTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniFlakTurretPack"]--;
}

// Override base class just in case.
function MiniFlakTurret::onPower(%this,%power,%generator) {}
function MiniFlakTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

//-----------------------------------------------------------------------------------

TurretData MiniSAMTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = MiniSAMproj;
	maxDamage = 2;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 20;
        range = 125;
        //gunRange = 300;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 2;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = shockexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Mini-S.A.M Turret";
	damageSkinData = "objectDamageSkins";
};

function MiniSAMTurret::onAdd(%this)
{
	schedule("MiniSAMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Mini-S.A.M Turret");
	}
}

function MiniSAMTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function MiniSAMTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function MiniSAMTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "MiniSAMTurretPack"]--;
}

// Override base class just in case.
function MiniSAMTurret::onPower(%this,%power,%generator) {}
function MiniSAMTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

