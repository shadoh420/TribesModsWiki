$InvList[PBTurretPack] = 1;
$MobileInvList[PBTurretPack] = 1;
$RemoteInvList[PBTurretPack] = 0;

$CanControl[PBTurret] = 1;
$EmbedController[PBTurret] = 1;
$CanAlwaysTeamDestroy[PBTurret] = 1;

function deployPBTurret::Initialize()
{	$TeamItemCount[0 @ PBTurretPack] = 0;
	$TeamItemCount[1 @ PBTurretPack] = 0;
	$TeamItemCount[2 @ PBTurretPack] = 0;
	$TeamItemCount[3 @ PBTurretPack] = 0;
	$TeamItemCount[4 @ PBTurretPack] = 0;
	$TeamItemCount[5 @ PBTurretPack] = 0;
	$TeamItemCount[6 @ PBTurretPack] = 0;
	$TeamItemCount[7 @ PBTurretPack] = 0;
}

ItemImageData PBTurretPackImage
{	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData PBTurretPack
{	description = "Particle Beam Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = PBTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PBTurretPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function PBTurretPack::onDeploy(%player,%item,%pos)
{	if (Turret::deployShape(%player, "Particle Beam (" @ Client::getName(Player::getClient(%player)) @ ")", PBTurret, %item, $TurretLocGroundOnly))
		Player::decItemCount(%player,%item);
}

function PBTurretPack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "The Particle Beam Turret has no auto-sensor and must be controlled manually to fire.");
}

TurretData PBTurret
{	className = "Turret";
	shapeFile = "hellfiregun";
	projectileType = ParticleBeam;
	accuFire = false;
	maxDamage = 1.0;
	maxEnergy = 320;
	minGunEnergy = 160;
	maxGunEnergy = 160;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;
	speed = 2.0;
	speedModifier = 2.0;
	range = 0;	
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundPBWBreakSoundBarrier;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = LargeShockwave;
	description = "Particle Beam Turret";
	damageSkinData = "objectDamageSkins";
};

function PBTurret::onAdd(%this)
{	schedule("PBTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.001;
	if (GameBase::getMapName(%this) == "") 
	{	GameBase::setMapName (%this, "Particle Beam Turret");
	}
}

function PBTurret::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function PBTurret::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function PBTurret::onDestroyed(%this)
{	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PBTurret"]--;
}

function PBTurret::onPower(%this,%power,%generator) 
{
}

function PBTurret::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}

