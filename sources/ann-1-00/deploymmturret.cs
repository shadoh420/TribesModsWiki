$InvList[MMTurretPack] = 1;
$MobileInvList[MMTurretPack] = 1;
$RemoteInvList[MMTurretPack] = 1;

$CanControl[MMTurret] = 1;
$EmbedController[MMTurret] = 1;
$CanAlwaysTeamDestroy[MMTurret] = 1;

ItemImageData MMTurretPackImage 
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MMTurretPack
{	description = "Manual Missile Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = MMTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

TurretData MMTurret 
{	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = TurretMissile;
	accuFire = false;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 8;
	maxGunEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.9;
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
	description = "Manual Missile Turret";
	damageSkinData = "objectDamageSkins";
};

function deployMMTurret::Initialize()
{	$TeamItemCount[0 @ MMTurretPack] = 0;
	$TeamItemCount[1 @ MMTurretPack] = 0;
	$TeamItemCount[2 @ MMTurretPack] = 0;
	$TeamItemCount[3 @ MMTurretPack] = 0;
	$TeamItemCount[4 @ MMTurretPack] = 0;
	$TeamItemCount[5 @ MMTurretPack] = 0;
	$TeamItemCount[6 @ MMTurretPack] = 0;
	$TeamItemCount[7 @ MMTurretPack] = 0;
}

function MMTurretPack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function MMTurretPack::onDeploy(%player,%item,%pos) 
{	if (Turret::deployShape(%player, "Manual Missile Turret (" @ Client::getName(Player::getClient(%player)) @ ")", MMTurret, %item, $TurretLocGroundOnly))
		Player::decItemCount(%player,%item);
}

function MMTurretPack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "The Manual Missile Turret has no auto-sensor and must be controlled manually to fire.");
}

function MMTurret::onAdd(%this) 
{	schedule("MMTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,10);
	%this.shieldStrength = 0.015;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Manual Missile Turret");
}

function MMTurret::deploy(%this) 
{	GameBase::playSequence(%this,1,"deploy");
}

function MMTurret::onEndSequence(%this,%thread) 
{	GameBase::setActive(%this,true);
}

function MMTurret::onDestroyed(%this) 
{	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.2,25,20,20,2.5,1.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "MMTurretPack"]--;
}

function MMTurret::onPower(%this,%power,%generator) 
{
}

function MMTurret::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,8);
	GameBase::setActive(%this,true);
}
