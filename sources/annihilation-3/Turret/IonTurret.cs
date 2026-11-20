$InvList[TurretPack] = 1;
$MobileInvList[TurretPack] = 1;
$RemoteInvList[TurretPack] = 1;
AddItem(TurretPack);

// changed IonTurretPack to TurretPack and DeployableIonTurret to DeployableTurret,
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
	heading = $InvHead[ihTur];
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
		Annihilation::decItemCount(%player,%item);
}

TurretData DeployableTurret
{
	className = "SelfPoweredTurret";
	shapeFile = "remoteturret";
	projectileType = IonBolt;
	maxDamage = 0.65;
	maxEnergy = 60;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 4.0;
	speedModifier = 1.5;
	range = 55;
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

