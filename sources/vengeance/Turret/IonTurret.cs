$InvList[TurretPack] = 1;
$MobileInvList[TurretPack] = 1;
$RemoteInvList[TurretPack] = 1;
AddItem(TurretPack);

// changed IonTurretPack to TurretPack and DeployableIonTurret to DeployableIonTurret,
// for some map compatibility, bah. -plasmatic

$CanAlwaysTeamDestroy[DeployableTurret] = 1;

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
	heading = $InvHead[ihDLd];	//$InvHead[ihTur];
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function TurretPack::deployShape(%player,%item) 
{
	if(Turret::deployShape(%player, "Ion Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableTurret, %item, $TurretLocAnywhere)&& !$build)
		Player::decItemCount(%player,%item);
}
GrenadeData Tattlerproj
{	
	bulletShapeName = "bullet.dts";	//"mortar.dts";	//plasammo.dts";
	explosionTag = FierybloodExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.25;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 1500;
	totalTime = 1.0;
	liveTime = 0.0;	//after collision
	projSpecialTime = 0.01;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName              = "shotgunex.dts";	//mortartrail.dts";	//shotgunex.dts";	//";
	//smokeName = "breath.dts";	//rsmoke
	smokeDist = 1.5;
};
RocketData newIonTurretBolt 
{	
	bulletShapeName = "tracer.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $ShrapnelDamageType;
	explosionRadius = 5;
	kickBackStrength = 30.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 50.0;
	totalTime = 3.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "shotgunex.dts";	//mortartrail.dts";
	smokeDist = 1.5;
	soundId = SoundJetHeavy;
};
BulletData IonTurretBolt
{
	bulletShapeName    = "enbolt.dts";
	explosionTag       = energyExp;

	damageClass        = 0;
	damageValue        = 0.1;
	damageType         = $EnergyDamageType;

	muzzleVelocity     = 80.0;
	totalTime          = 4.0;
	liveTime           = 2.0;

	lightRange         = 3.0;
	lightColor         = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.5;
	isVisible          = True;
	rotationPeriod = 1;
};

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
	projectileType = IonTurretBolt;	//DiscShell;	//Tattlerproj;	//fieryBlood;	//IonBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 0;	// energy use per second of fire time
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 1.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 45;
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
TurretData newDeployableTurret		
{			 
	maxDamage = 1.25;
	maxEnergy = 175;
	minGunEnergy = 35;
	maxGunEnergy = 5;
	range = 50;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret"; // ELF Turret
	shapeFile = "remoteturret";	//shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = DiscShell;	//targetLaser;	//turretCharge;
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
function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.005;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Remote Turret");
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
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

function DeployableTurret::onPower(%this,%power,%generator) 
{
}

function DeployableTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}