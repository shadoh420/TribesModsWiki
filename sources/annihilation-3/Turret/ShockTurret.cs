$InvList[ShockTurretPack] = 1;
$MobileInvList[ShockTurretPack] = 1;
$RemoteInvList[ShockTurretPack] = 1;
AddItem(ShockTurretPack);

$CanAlwaysTeamDestroy[DeployableShockTurret] = 1;

ItemImageData ShockTurretPackImage 
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ShockTurretPack 
{
	description = "Shock Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
	heading = $InvHead[ihTur];
	imageType = ShockTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockTurretPack::deployShape(%player,%item) 
{
	if(Turret::deployShape(%player, "Shock Turret (" @ Client::getName(Player::getClient(%player)) @ ")", DeployableShockTurret, %item, $TurretLocAnywhere)&& !$build)
		Annihilation::decItemCount(%player,%item);
}

TurretData DeployableShockTurret 
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
	className = "SelfPoweredTurret";
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

function DeployableShockTurret::onAdd(%this) 
{	
	schedule("DeployableShockTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,6);
	%this.shieldStrength = 0.010;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Remote Shock Turret");
}

function DeployableShockTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableShockTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function DeployableShockTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockTurretPack"]--;
}


function DeployableShockTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}