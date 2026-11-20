//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin8420@adelphia.net
// Aim: Dustin8420
//------------------------------------|
//
ItemImageData ChainTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
//
ItemData ChainTurretPack
{
	description = "God Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = ChainTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
//
function ChainTurretPack::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}
//
function ChainTurretPack::onDeploy(%player, %item, %pos)
{
	if(ChaingunTurretPack::deployShape(%player, %item))
	{ Player::decItemCount(%player, %item); }
}
//
function ChainTurretPack::deployShape(%player, %item)
{ deployable(%player, %item, "Turret", "God Turret", false, false, false, true, false, false, false, 4, true, 100, true, "DeployableChain", "ChainTurretPack"); }
//
//
TurretData DeployableChain
{
	className = "Turret";
	shapeFile = "remoteturret";
    projectileType = ChaingunTurretBullet;
	maxDamage = 5;
    maxEnergy = 500;
    minGunEnergy = 1;
    maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
    reloadDelay = 0;
	speed = 20;
	speedModifier = 2;
    range = 250;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
    fireSound = debrissmallexplosion;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
    description = " ";
	damageSkinData = "objectDamageSkins";
};
//
function DeployableChain::onAdd(%this)
{
	Schedule("DeployableChain::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 10);
	%this.shieldStrength = 2500;
	if(GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Remote Chaingun"); }
}
//
function DeployableChain::deploy(%this)
{ GameBase::playSequence(%this, 1, "deploy"); }
//
function DeployableChain::onEndSequence(%this, %thread)
{ GameBase::setActive(%this, true); }
//
function DeployableChain::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @"ChaingunTurretPack"]--;
}
//
function DeployableChain::onPower(%this, %power, %generator)
{}
//
function DeployableChain::onEnabled(%this)
{
	GameBase::setRechargeRate(%this, 15);
	GameBase::setActive(%this, true);
}
//===========================================================================================
//
ItemImageData PlasmaPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
//
ItemData PlasmaPack
{
	description = ".";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHeading[Turrets];
	imageType = PlasmaPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
//
function PlasmaPack::onUse(%player, %item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::deployItem(%player, %item); }
}
//
function PlasmaPack::onDeploy(%player, %item, %pos)
{
	if(PlasmaPack::deployShape(%player, %item))
	{ Player::decItemCount(%player, %item); }
}
//
function PlasmaPack::deployShape(%player, %item)
{ deployable(%player, %item, "Turret", ".", false, false, false, true, false, false, false, 4, true, 100, true, "DeployableMiniPlasma", "PlasmaPack"); }	
//
TurretData DeployableMiniPlasma
{
	className = "Turret";
	shapeFile = "mine";
	projectileType = PlasmaBolt2;
	maxDamage = 5;
	maxEnergy = 500;
	minGunEnergy = 1;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 5;
	speedModifier = 1.5;
	range = 20;
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
	description = "";
	damageSkinData = "objectDamageSkins";
};
//
function DeployableMiniPlasma::onAdd(%this)
{
	Schedule("DeployableTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 1000;
	if(GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Remote Turret"); }
}
//
function DeployableMiniPlasma::deploy(%this)
{ GameBase::playSequence(%this, 1, "deploy"); }
//
function DeployableMiniPlasma::onEndSequence(%this,%thread)
{ GameBase::setActive(%this, true); }
//
function DeployableMiniPlasma::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @"PlasmaPack"]--;
}
//
function DeployableMiniPlasma::onPower(%this, %power, %generator)
{}
//
function DeployableMiniPlasma::onEnabled(%this)
{
	GameBase::setRechargeRate(%this, 5);
	GameBase::setActive(%this, true);
}