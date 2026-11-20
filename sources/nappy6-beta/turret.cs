//=================================================================================================================
//===================================================================================== Base Elf Turret ===========
//=================================================================================================================

TurretData ELFTurret 
	{ 
	maxDamage = 1.0; 
	maxEnergy = 350; 
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
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
	}; 

//=================================================================================================================
//================================================================================== Base Indoor Turret ===========
//=================================================================================================================

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

//=================================================================================================================
//=================================================================================== Base Missile Turret =========
//=================================================================================================================

TurretData RocketTurret 
	{ 
	maxDamage = 1.75; 
	maxEnergy = 100; 
	minGunEnergy = 60; 
	maxGunEnergy = 60; 
	range = 270; 
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
	speed = 3.0; 
	speedModifier = 3.0; 
	projectileType = TurretMissile; 
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundMissileTurretOn; 
	deactivateSound = SoundMissileTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	targetableFovRatio = 0.5; 
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
	return "True"; 
	else 
	return "False"; 
	} 

//=================================================================================================================
//================================================================================== Base Mortar Turret ===========
//=================================================================================================================

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
	description = "Mortar Turret"; 
	}; 

//=================================================================================================================
//================================================================================= Base Plasma Turret ============
//=================================================================================================================

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
	range = 150; 
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

//=================================================================================================================
//===================================================================================== Base Target Turret ========
//=================================================================================================================

TurretData TargetTurret 
	{ 
	maxDamage = 1.5; 
	maxEnergy = 300; 
	minGunEnergy = 5; 
	maxGunEnergy = 5; 
	range = 100; 
	visibleToSensor = true; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = defaultDebrisMedium; 
	className = "Targeting Turret"; 
	shapeFile = "camera"; 
	shieldShapeName = "shield"; 
	speed = 5.0; 
	speedModifier = 1.5; 
	projectileType = targetLaser; 
	reloadDelay = 0.3; 
	explosionId = flashExpMedium; 
	description = "Deployable Targeting Turret"; 
	fireSound = SoundFireTargetingLaser; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
	}; 

function TargetTurret::onAdd(%this) 
	{ 
	schedule("TargetTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,15); 
	%this.shieldStrength = 0; 
	if (GameBase::getMapName(%this) == "")  
	GameBase::setMapName (%this, "Remote Targeting Turret");  
	} 

function TargetTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function TargetTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function TargetTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; 
	} 

function TargetTurret::onPower(%this,%power,%generator) {} 

function TargetTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Anti-Air Turret ===========
//=================================================================================================================

TurretData AntiAirTurret 
	{ 
	className = "Turret"; 
	shapeFile = "missileturret"; 
	projectileType = AntiAirMissile; 
	maxDamage = 1.0; 
	maxEnergy = 500; 
	minGunEnergy = 1; 
	maxGunEnergy = 2; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 3; 
	speed = 12.0; 
	speedModifier = 1.5; 
	range = 340; 
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
	targetableFovRatio = 0.5; 
	explosionId = LargeShockwave; 
	description = "Anti Air Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

ItemImageData AntiAirPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData AntiAirPack 
	{ 
	description = "AntiAir Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = AntiAirPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function AntiAirPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 350)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 350)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function AntiAirPack::onDeploy(%player,%item,%pos) 
	{ 
	if (AntiAirPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function AntiAirPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",AntiAirTurret,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Anti-Air Turret "@ Client::getName(%client));
	Client::setOwnedObject(%client, %camera);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Anti-Air Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "AntiAirPack"]++;
	echo("MSG: ",%client," deployed an AntiAir Turret");  
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function AntiAirTurret::verifyTarget(%this,%target) 
	{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
	return "True"; 
	else 
	return "False"; 
	} 

function AntiAirTurret::onAdd(%this) 
	{ 
	schedule("AntiAirTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Mortar Turret"); 
	} 

function AntiAirTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function AntiAirTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function AntiAirTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "AntiAirPack"]--; 
	} 

function AntiAirTurret::onPower(%this,%power,%generator) {} 

function AntiAirTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Elf Turret ================
//=================================================================================================================

TurretData DeployableElf 
	{ 
	maxDamage = 1.0; 
	maxEnergy = 350; 
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
	fireSound = SoundGeneratorPower; 
	activationSound = SoundChainTurretOn; 
	deactivateSound = SoundChainTurretOff; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	isSustained = true; 
	firingTimeMS = 750; 
	energyRate = 30.0; 
	};  

ItemImageData DeployableElfTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData DeployableElfTurret 
	{ 
	description = "Elf Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = DeployableElfTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function DeployableElfTurret::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function DeployableElfTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (DeployableElfTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function DeployableElfTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%turret = newObject("","Turret",DeployableElf,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Elf Turret "@ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Elf Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableElfTurret"]++;
	echo("MSG: ",%client," deployed a Elf Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableElf::onAdd(%this) 
	{ 
	schedule("DeployableElf::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.0275; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Elf Turret"); 
	} 

function DeployableElf::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableElf::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableElf::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableElfTurretTurret"]--; 
	} 

function DeployableElf::onPower(%this,%power,%generator) {} 

function DeployableElf::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,10); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Indoor Turret =============
//=================================================================================================================

TurretData DeployableIndoor 
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

ItemImageData IndoorPackImage 
	{ 
	shapeFile = "indoorgun"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData IndoorPack 
	{ 
	description = "Indoor Turret"; 
	shapeFile = "indoorgun"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = IndoorPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function IndoorPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 110)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 110)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function IndoorPack::onDeploy(%player,%item,%pos) 
	{ 
	if (IndoorPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function IndoorPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",DeployableIndoor,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Indoor Turret "@ Client::getName(%client));
	Client::setOwnedObject(%client, %camera);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Indoor Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "IndoorPack"]++; 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableIndoor::onAdd(%this) 
	{ 
	schedule("DeployableIndoor::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.030; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Indoor Turret"); 
	} 

function DeployableIndoor::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableIndoor::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableIndoor::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "IndoorPack"]--; 
	} 

function DeployableIndoor::onPower(%this,%power,%generator) {} 

function DeployableIndoor::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Ion Turret ================
//=================================================================================================================

TurretData DeployableTurret 
	{ 
	className = "Turret"; 
	shapeFile = "remoteturret"; 
	projectileType = IonBolt; 
	maxDamage = 1.0; 
	maxEnergy = 60; 
	minGunEnergy = 6; 
	maxGunEnergy = 5; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.3; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 155; 
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
	}; 

ItemImageData TurretPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData TurretPack 
	{ 
	description = "Ion Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = TurretPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TurretPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function TurretPack::onDeploy(%player,%item,%pos)
	{
	if (TurretPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function TurretPack::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if(%obj != "Player")
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%turret = newObject("","Turret",DeployableTurret,true); 
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setRotation(%turret,%rot);
	GameBase::setPosition(%turret,$los::position);
	Gamebase::setMapName(%turret,"Ion Turret " @ Client::getName(%client)); 
      Client::setOwnedObject(%client, %turret);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Ion Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%turret) @ "TurretPack"]++;
	echo("MSG: ",%client," deployed an Ion Turret"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableTurret::onAdd(%this) 
	{ 
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Turret"); 
	} 

function DeployableTurret::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableTurret::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableTurret::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--; 
	} 

function DeployableTurret::onPower(%this,%power,%generator) {} 

function DeployableTurret::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Laser Turret ==============
//=================================================================================================================

TurretData DeployableLaser
	{
	className = "Turret";
	shapeFile = "camera";
	projectileType = SniperLaser;
	maxDamage = 0.75;
	maxEnergy = 35;
	minGunEnergy = 10;
	maxGunEnergy = 60;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 10.0;
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
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Remote Laser Turret";
	damageSkinData = "objectDamageSkins";
	};

ItemImageData LaserPackImage
	{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	};

ItemData LaserPack
	{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
      heading = "gDeployable Turrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function LaserPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 180)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 180)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function LaserPack::onDeploy(%player,%item,%pos)
	{
	if (LaserPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function LaserPack::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if (%obj != "Player")
	{
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%camera = newObject("","Turret",DeployableLaser,true);
	addToSet("MissionCleanup", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,%rot);
	GameBase::setPosition(%camera,$los::position);
	Gamebase::setMapName(%camera,"Laser Turret "@ Client::getName(%client));
      Client::setOwnedObject(%client, %camera);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Laser Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
	echo("MSG: ",%client," deployed a Laser Turret"); 
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}

function DeployableLaser::onAdd(%this)
	{
	schedule("DeployableLaser::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Laser Turret");
	}

function DeployableLaser::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }

function DeployableLaser::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function DeployableLaser::onDestroyed(%this)
	{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "LaserPack"]--;
	}

function DeployableLaser::onPower(%this,%power,%generator) {}

function DeployableLaser::onEnabled(%this) 
	{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	}	

//=================================================================================================================
//======================================================================================= Missile Turret ==========
//=================================================================================================================

TurretData DeployableRocket 
	{ 
	className = "Turret"; 
	shapeFile = "missileturret"; 
	projectileType = TurretMissile; 
	maxDamage = 1.7; 
	maxEnergy = 90; 
	minGunEnergy = 50; 
	maxGunEnergy = 50; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 2.0; 
	speed = 6.0; 
	speedModifier = 4.5; 
	range = 175; 
	visibleToSensor = true; 
	shadowDetailMask = 4; 
	dopplerVelocity = 0; 
	castLOS = true; 
	supression = false; 
	mapFilter = 2; 
	mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; 
	shieldShapeName = "shield"; 
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; 
	explosionId = flashExpMedium; 
	description = "Missile Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

ItemImageData RocketPackImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 3.0; 
	firstPerson = false; 
	}; 

ItemData RocketPack 
	{ 
	description = "Missile Turret"; 
	shapeFile = "missileturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = RocketPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RocketPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 300)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 300)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function RocketPack::onDeploy(%player,%item,%pos) 
	{ 
	if (RocketPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function RocketPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot;
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot;
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%turret = newObject("","Turret",DeployableRocket,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Missile Turret " @ Client::getName(%client));
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Missile Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
	echo("MSG: ",%client," deployed a Rocket Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableRocket::verifyTarget(%this,%target) 
	{ 
	if (GameBase::virtual(%target, "getHeatFactor") >= 0.5) 
	return "True"; 
	else 
	return "False"; 
	} 

function DeployableRocket::onAdd(%this) 
	{ 
	schedule("DeployableRocket::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.02; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Missile Turret"); 
	} 

function DeployableRocket::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableRocket::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableRocket::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RocketPack"]--; 
	} 

function DeployableRocket::onPower(%this,%power,%generator) {} 

function DeployableRocket::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 


//=================================================================================================================
//===================================================================================== Mortar Turret =============
//=================================================================================================================

TurretData DeployableMortar 
	{ 
	className = "Turret"; 
	shapeFile = "mortar_turret"; 
	projectileType = MortarTurretShell; 
	maxDamage = 1.0; 
	maxEnergy = 45; 
	minGunEnergy = 45; 
	maxGunEnergy = 100; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 2.0; 
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
	fireSound = SoundMortarTurretFire; 
	activationSound = SoundMortarTurretOn; 
	deactivateSound = SoundMortarTurretOff; 
	whirSound = SoundMortarTurretTurn; 
	explosionId = LargeShockwave; 
	description = "Remote Mortar Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

ItemImageData TargetPackImage 
	{ 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData TargetPack 
	{ 
	description = "Mortar Turret"; 
	shapeFile = "mortar_turret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = TargetPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function TargetPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}
 
function TargetPack::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Mortar Turret must be controlled manually to fire."); 
	} 

function TargetPack::onDeploy(%player,%item,%pos) 
	{ 
	if (TargetPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function TargetPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableMortar,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Mortar Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Remote Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++; 
	echo("MSG: ",%client," deployed a Mortar Turret"); 
	Client::setOwnedObject(%client, %turret); 
	Client::setOwnedObject(%client, %player); 
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableMortar::onAdd(%this) 
	{ 
	schedule("DeployableMortar::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,7); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Mortar Turret"); 
	} 

function DeployableMortar::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableMortar::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableMortar::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "TargetPack"]--; 
	} 

function DeployableMortar::onPower(%this,%power,%generator) {} 

function DeployableMortar::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,7); 
	GameBase::setActive(%this,true); 
	}

//=================================================================================================================
//===================================================================================== Plasma Turret =============
//=================================================================================================================

TurretData DeployablePlasma 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = FusionBolt; 
	maxDamage = 1.5; 
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

ItemImageData LaserTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData LaserTurret 
	{ 
	description = "Plasma Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = LaserTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function LaserTurret::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 200)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function LaserTurret::onDeploy(%player,%item,%pos)
	{ 
	if (LaserTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function LaserTurret::deployShape(%player,%item) 
	{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployablePlasma,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Plasma Turret " @ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Plasma Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++;
	echo("MSG: ",%client," deployed a Plasma Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployablePlasma::onAdd(%this) 
	{ 
	schedule("DeployablePlasma::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0.010; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Plasma Turret"); 
	} 

function DeployablePlasma::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployablePlasma::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployablePlasma::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LaserTurret"]--; 
	} 

function DeployablePlasma::onPower(%this,%power,%generator) {} 

function DeployablePlasma::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//==================================================================================== Rail Turret ================
//=================================================================================================================

TurretData DeployableRail 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = railLaser; 
	maxDamage = 1.0; 
	maxEnergy = 155; 
	minGunEnergy = 100; 
	maxGunEnergy = 150; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 8.0; 
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
	fireSound = SoundMissileTurretFire; 
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Rail Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

ItemImageData RailTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData RailTurret 
	{ 
	description = "Rail Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = RailTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RailTurret::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function RailTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (RailTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function RailTurret::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Rail Turret must be controlled manually to fire."); 
	} 

function RailTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player")
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableRail,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Rail Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Rail Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++;
	echo("MSG: ",%client," deployed a Rail Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableRail::onAdd(%this) 
	{ 
	schedule("DeployableRail::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,20); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "")  
	GameBase::setMapName (%this, "Rail Turret"); 
	} 

function DeployableRail::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableRail::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableRail::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "RailTurret"]--; 
	} 

function DeployableRail::onPower(%this,%power,%generator) {} 

function DeployableRail::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,20); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Satchel Turret ============
//=================================================================================================================

TurretData DeployableSatchel 
	{ 
	className = "Turret"; 
	shapeFile = "camera"; 
	projectileType = SatchelShell; 
	maxDamage = 0.4; 
	maxEnergy = 60; 
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

function DeployableSatchel::onAdd(%this) 
	{ 
	schedule("DeployableSatchel::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,0); 
	%this.shieldStrength = 0; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Satchel Charge"); 
	} 

function DeployableSatchel::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableSatchel::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableSatchel::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this);  
	calcRadiusDamage(%this, $DebrisDamageType, 20.0, 1.5, 25, 9, 3, 0.20,0.1, 200, 100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SatchelPack"]--; 
	} 

function DeployableSatchel::onPower(%this,%power,%generator) {} 

function DeployableSatchel::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,0); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//======================================================================================== Shock Turret ===========
//=================================================================================================================

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
	projectileType = ShockShell; 
	damageSkinData = "objectDamageSkins"; 
	shadowDetailMask = 8; 
	explosionId = LargeShockwave; 
	description = "Shock Turret"; 
	}; 

ItemImageData ShockPackImage 
	{ 
	shapeFile = "indoorgun"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
	}; 

ItemData ShockPack 
	{ 
	description = "Shock Turret"; 
	shapeFile = "indoorgun"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = ShockPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function ShockPack::onUse(%player,%item) 
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (%deplteam != 1)
	{
	if (Vector::getDistance(%deplpos, %teamposb) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	else
	{
	if (%deplteam != 0)
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 100)
	{
	Client::sendMessage(%client,0,"You are too close to the enemy base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else 
	Player::deployItem(%player,%item); 
	}
	}
	}
	}

function ShockPack::onDeploy(%player,%item,%pos) 
	{ 
	if (ShockPack::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function ShockPack::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	%prot = GameBase::getRotation(%player); 
	%zRot = getWord(%prot,2); 
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 " @ %zRot; 
	else 
	{ 
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 " @ %zRot; 
	else 
	%rot = Vector::getRotation($los::normal); 
	} 
	%camera = newObject("","Turret",DeployableShock,true); 
	addToSet("MissionCleanup", %camera); 
	GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
	GameBase::setRotation(%camera,%rot); 
	GameBase::setPosition(%camera,$los::position); 
	Gamebase::setMapName(%camera,"Shock Turret "@ Client::getName(%client)); 
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Shock Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++; 
	return true; 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 


function DeployableShock::onAdd(%this) 
	{ 
	schedule("DeployableShock::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,6); 
	%this.shieldStrength = 0.010; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Remote Shock Turret"); 
	} 

function DeployableShock::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableShock::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableShock::onDestroyed(%this) 
	{ 
	Turret::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockPack"]--; 
	} 

function DeployableShock::onPower(%this,%power,%generator) {} 

function DeployableShock::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,5); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//=================================================================================== Vulcan Turret ===============
//=================================================================================================================

TurretData DeployableVulcan 
	{ 
	className = "Turret"; 
	shapeFile = "hellfiregun"; 
	projectileType = TurretBullet; 
	accuFire = false; 
	maxDamage = 4.0; 
	maxEnergy = 300; 
	minGunEnergy = 3; 
	maxGunEnergy = 3.975; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.00001; 
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
	fireSound = SoundFireMortar; 
	activationSound = SoundPlasmaTurretOn; 
	deactivateSound = SoundPlasmaTurretOff; 
	whirSound = SoundPlasmaTurretTurn; 
	explosionId = flashExpMedium; 
	description = "Vulcan Turret"; 
	damageSkinData = "objectDamageSkins"; 
	}; 

ItemImageData VulcanTurretImage 
	{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 }; 
	mountRotation = { 0, 0, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
	}; 

ItemData VulcanTurret 
	{ 
	description = "Vulcan Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "gDeployable Turrets"; 
	imageType = VulcanTurretImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 420; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function VulcanTurret::onUse(%player,%item) 
	{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item); 
	} 

function VulcanTurret::onDeploy(%player,%item,%pos) 
	{ 
	if (VulcanTurret::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item); 
	} 

function VulcanTurret::onMount(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	Bottomprint(%client, "The Vulcan Turret must be controlled manually to fire."); 
	}
 
function VulcanTurret::deployShape(%player,%item) 
	{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,10)) 
	{ 
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{ 
	if (Vector::dot($los::normal,"0 0 1") > 0.7) 
	{ 
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","Turret",DeployableVulcan,true); 
	addToSet("MissionCleanup", %turret); 
	GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
	GameBase::setPosition(%turret,$los::position); 
	GameBase::setRotation(%turret,%rot); 
	Gamebase::setMapName(%turret,"Vulcan Turret " @ Client::getName(%client)); 
	Client::sendMessage(%client,0,"Vulcan Turret deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++;
	echo("MSG: ",%client," deployed a Vulcan Turret");  
	return true;  
	} 
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 

function DeployableVulcan::onAdd(%this) 
	{ 
	schedule("DeployableVulcan::deploy(" @ %this @ ");",1,%this); 
	GameBase::setRechargeRate(%this,10); 
	%this.shieldStrength = 0.005; 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Vulcan Turret"); 
	} 
 
function DeployableVulcan::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployableVulcan::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployableVulcan::onDestroyed(%this) 
	{ 
	StaticShape::objectiveDestroyed(%this); 
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100); 
	$TeamItemCount[GameBase::getTeam(%this) @ "VulcanTurret"]--; 
	} 

function DeployableVulcan::onPower(%this,%power,%generator) {} 

function DeployableVulcan::onEnabled(%this) 
	{ 
	GameBase::setRechargeRate(%this,100); 
	GameBase::setActive(%this,true); 
	} 

//=================================================================================================================
//===================================================================================== Basic Functions ===========
//=================================================================================================================

function Turret::onActivate(%this) { GameBase::playSequence(%this,0,power); }
 
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

function Turret::onAdd(%this) 
	{ 
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Turret"); 
	} 

function Turret::checkOperator(%this) 
	{ 
	%cl = GameBase::getControlClient(%this); 
	if(%cl != -1) 
	{ 
	%pl = Client::getOwnedObject(%cl); 
	Player::setMountObject(%pl, -1,0); 
	Client::setControlObject(%cl, %pl); 
	} 
	Client::setGuiMode(%cl,2); 
	} 

function Turret::onPower(%this,%power,%generator) 
	{ 
	if (%power) 
	{ 
	%this.shieldStrength = 0.03; 
	GameBase::setRechargeRate(%this,10); 
	} 
	else 
	{ 
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
	%this.shieldStrength = 0; 
	GameBase::setRechargeRate(%this,0); 
	Turret::onDeactivate(%this); 
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
	} 

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if(%this.objectiveLine) 
	%this.lastDamageTeam = GameBase::getTeam(%object); 
	%TDS= 1; 
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name != DeployableTurret && %name != CameraTurret && %name != DeployableSatchel && %name != DeployableMortar && %name != DeployableHolo && %name != DeployableHolo2 && %name != DeployableHolo3 && %name != DeployablePlasma && %name != DeployableLaser && %name != DeployableRocket && %name != DeployableVulcan && %name != DeployableRail && %name != DeployableShock && %name != DeployableIndoor && %name != AntiAirTurret && %name != DeployableElf && %name != ArbitorBox) 
	%TDS = $Server::TeamDamageScale; 
	} 
	StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object); 
	} 

function Turret::onControl (%this, %object) 
	{ 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Controlling turret " @ %this); 
	$turretTime[%this] = 1; 
	} 

function Turret::onDismount (%this, %object) 
	{ 
	%client = Player::getClient(%object); 
	Client::sendMessage(%client,0,"Leaving turret " @ %this); 
	$turretTime[%this] = 0; 
	LaptopDrain(%client, %object); 
	} 

function Turret::onCollision (%this, %object) 
	{ 
	if(getObjectType (%object) == "Player") 
	{ 
	%armor = Player::getArmor(%object); 
	if ((Player::getMountedItem(%object,$BackpackSlot) == Laptop)) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name == DeployableMortar || %name == DeployablePlasma || %name == DeployableRocket || %name == DeployableVulcan || %name == DeployableRail || %name == MortarTurret) 
	{ 
	%client = Player::getClient(%object); 
	if($lapTime[%client] == 0) 
	{ 
	if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
	{ 
	Client::getOwnedObject(%client).CommandTag = 1; 
	Client::sendMessage(%client,0,"Re-programming turret"); 
	GameBase::setTeam (%this,GameBase::getTeam (%client)); 
	Client::takeControl(%client, %this); 
	if(%name == DeployablePlasma || %name == DeployableVulcan || %name == DeployableRail ) 
	GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
	return; 
	} 
	} 
	else 
	Client::sendMessage(%client,0,"Turret is recharging."); 
	} 
	} 
	} 
	if(getObjectType (%object) == "Player") 
	{ 
	%armor = Player::getArmor(%object); 
	if (%armor != "darmor") 
	{ 
	if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) 
	{ 
	%client = Player::getClient(%object); 
	if($lapTime[%client] == 0) 
	{ 
	%name = GameBase::getDataName(%this); 
	if(%name == DeployableVulcan || %name == DeployableRail) 
	{ 
	if(GameBase::GetPosition(%this) != GameBase::GetPosition(%object)) 
	{ 
	Client::getOwnedObject(%client).CommandTag = 1; 
	Client::sendMessage(%client,0,"Manually controlling turret"); 
	Client::takeControl(%client, %this); 
	GameBase::SetPosition(%object,GameBase::GetPosition(%this)); 
	return; 
	} 
	} 
	} 
	else 
	Client::sendMessage(%client,0,"Turret is recharging."); 
	} 
	else 
	Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav"); 
	} 
	else 
	Client::sendMessage(%client,0,"Can not manually command turrets in this class."); 
	} 
	} 

function LaptopDrain(%clientId, %player) 
	{ 
	Player::unmountItem(%player,$WeaponSlot); 
	if($lapTime[%clientId] == 0) 
	{ 
	Client::getOwnedObject(%clientId).CommandTag = ""; 
	$lapTime[%clientId] = 14; 
	checkPlayerLaptop(%clientId, %player); 
	} 
	else 
	$lapTime[%clientId] = 14; 
	} 

function checkPlayerLaptop(%clientId, %player) 
	{ 
	if($lapTime[%clientId] > 0) 
	{ 
	$lapTime[%clientId] -= 2; 
	schedule("checkPlayerLaptop(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	}

function CountObjects(%set,%name,%num) 
	{ 
	%count = 0; 
	for(%i=0;%i<%num;%i++) 
	{ 
	%obj=Group::getObject(%set,%i); 
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; 
	} 
	return %count; 
	} 

