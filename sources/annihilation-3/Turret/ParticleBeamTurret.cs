$InvList[ParticleBeamTurretPack] = 1;
$MobileInvList[ParticleBeamTurretPack] = 1;
$RemoteInvList[ParticleBeamTurretPack] = 0;
AddItem(ParticleBeamTurretPack);

$CanControl[ParticleBeamTurret] = 1;
$EmbedController[ParticleBeamTurret] = 1;
$CanAlwaysTeamDestroy[ParticleBeamTurret] = 1;

ItemImageData ParticleBeamTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ParticleBeamTurretPack
{
	description = "Particle Beam Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = ParticleBeamTurretPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ParticleBeamTurretPack::deployShape(%player,%item)
{
	if(Turret::deployShape(%player, "Particle Beam (" @ Client::getName(Player::getClient(%player)) @ ")", ParticleBeamTurret, %item, $TurretLocGroundOnly)&& !$build)
		Annihilation::decItemCount(%player,%item);
}

function ParticleBeamTurretPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%client = Player::getClient(%player);
	if(%client.weaponHelp)	
		Bottomprint(%client, "<jc>Particle Beam Turret:<f2> has no auto-sensor and must be controlled manually to fire.");
}

LaserData TurretParticleBeam
{	
	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!     = "warp.bmp";
	hitName = "shockwave_large.dts";
	damageConversion = 0.025;	//0.064;	
	//DamageType = $BulletDamageType;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};

TurretData ParticleBeamTurret
{
	className = "SelfPoweredTurret";
	shapeFile = "hellfiregun";
	projectileType = TurretParticleBeam;
	accuFire = false;
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 200;
	maxGunEnergy = 100;
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
	fireSound = SoundParticleBeamFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	explosionId = LargeShockwave;
	description = "Particle Beam Turret";
	damageSkinData = "objectDamageSkins";
};

function ParticleBeamTurret::onAdd(%this)
{	
	schedule("ParticleBeamTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,15);
	%this.shieldStrength = 0.005;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Particle Beam Turret");
}

function ParticleBeamTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function ParticleBeamTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function ParticleBeamTurret::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	%this.cloakable = "";
	%this.nuetron = "";
	%this.OrgTeam = "";
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ParticleBeamTurretPack"]--;
}

function ParticleBeamTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,15);
	GameBase::setActive(%this,true);
}

