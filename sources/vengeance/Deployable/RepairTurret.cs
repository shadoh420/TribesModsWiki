$InvList[RepairTurretPack] = 1;
$MobileInvList[RepairTurretPack] = 1;
$RemoteInvList[RepairTurretPack] = 1;
AddItem(RepairTurretPack);
addWeapon(RepairTurretPack);

$CanAlwaysTeamDestroy[RepairTurret] = 1;

ItemImageData RepairTurretPackImage 
{
	shapeFile = "camera";
	mountPoint = 0;			//Vengeance
	weaponType = 0;			//Vengeance
	reloadTime = 0.1;			//Vengeance	
	fireTime = 0.1;			//Vengeance
	sfxActivate = SoundPickUpWeapon;	//Vengeance
	mountOffset = { 0.1, 0.5 , -0.2 };		//Vengeance	//right, forward, up
	mountRotation = {1.07, -0.11, 0};		//Vengeance	//up, right, around player axis	
};

ItemData RepairTurretPack 
{
	description = "Repair Turret";
	shapeFile = "camera";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = RepairTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
//	hiliteOnActive = true;
};


LightningData RepairCharge
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 10.0;
	coneAngle = 35.0;
	damagePerSec = 0.15;
	energyDrainPerSec = 0.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;	// how wide..
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundMortarIdle;	//SoundELFFire;
};

SoundData SoundRepairBurn
{
	wavFileName = "repair.wav";
	profile = Profile3dNear;
};

GrenadeData RepairTurretBurn
{

   bulletShapeName = "plasmabolt.dts";
   explosionTag       = repairExp;
   collideWithOwner   = True;
   ownerGraceMS       = 25;	//250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $RepairTurretDamage;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 25;	//275
   totalTime          = 0.25;
   liveTime           = 0.25; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};

TurretData RepairTurret 
{
	maxDamage = 1.5;	//2.0
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 15;
	visibleToSensor = false;	//true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";		//ELF Turret
	shapeFile = "camera"; 		//chainturret
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = RepairTurretBurn;	//DiscShell;	//RepairCharge;	//RepairlBurn;	//
	reloadDelay = 0.5;
	explosionId = LargeShockwave;
	description = "Repair Turret"; //ELF Turret

	fireSound        = SoundRepairBurn;		//SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

//	isSustained     = true;
//	firingTimeMS    = 750;
//	energyRate      = 30.0;
	
	disableCollision = true; 
};
StaticShapeData RepairTurretMarker
{
	description = "Repair Turret";
	shapeFile = "PLASAMMO";	//force";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 50;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
};
function RepairTurret::onAdd(%this)
{	
	schedule("RepairTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
//	if(GameBase::getMapName(%this) == "") 
//		GameBase::setMapName (%this, "RepairTurret");
}

function RepairTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function RepairTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function RepairTurret::onDestroyed(%this) 
{
	%repairmarker = %this.repairmarker;
	GameBase::setDamageLevel(%repairmarker, 51);	
	
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "RepairTurretPack"]--;
}

function RepairTurret::onPower(%this,%power,%generator) 
{
}

function RepairTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	GameBase::setAutoRepairRate(%this,0.015);
}


function RepairCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	%enVal = %timeSlice * %enDrainPerSec;

	GameBase::applyDamage(%target, $HealingDamage, %damVal, %pos, %vec, %mom, %shooterId);

	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if(%energy < 0) 
		%energy = 0;
	GameBase::setEnergy(%target, %energy);
}

// yep. hacked up into a weapon type... Suck it. -Plasmatic
function RepairTurretPackImage::onFire(%player,%item) 
{
//	if(Turret::deployShape(%player, "Repair Turret (" @ Client::getName(Player::getClient(%player)) @ ")", RepairTurret, %item, $TurretLocAnywhere)&& !$build)
//		Player::decItemCount(%player,%item);

	%item = RepairTurretPack;
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,5))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}

	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform")	 
	{ 
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return;
	}
	
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%num = CountTurrets(%set, %num);
	deleteObject(%set);
	if(%num > $MaxNumTurretsInBox) 
	{
		Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
		return;
	}


	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if(Vector::dot($los::normal,"0 0 1") > 0.6) 
		%rot = "0 0 " @ %zRot;
	else 
	{	
		if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
			%rot = "3.14159 0 " @ %zRot;
		else 
		{
			Client::sendMessage(%client, 0, "Cannot deploy there.");
			return;
			//%rot = Vector::getRotation($los::normal);		
		}

	}
	if(!checkInvDeployArea(%client,$los::position))
	{
		Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
		return false;
	}
	%turret = newObject("Repair Turret","Turret",RepairTurret,true);

	$TurretList[%turret] = %client;	//we're going to disable when client changes team or drops -plasmatic 2.2

	addToSet("MissionCleanup/deployed/turret", %turret);
	GameBase::setTeam(%turret,2);	//GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
//	Gamebase::setMapName(%turret,"Repair Turret " @ Client::getName(%client));

	%turret.RepairTeam = GameBase::getTeam(%player);

	$turret::count++;
	%obj.deployer = %client;
	Client::sendMessage(%client,0,"Repair Turret deployed");
	playSound(SoundThrowItem,$los::position);	//playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	echo("MSG: ",%client," deployed a Repair Turret");
	
	//	Remote turrets - kill points to player that deploy them
	// Yep, we're fooling Tribes into contradicting itself.. Ownership of an enemy turret.. -Plasmatic
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	
	// Ok, since this is tecnically on the other team, we need to place something on our team as a marker.. -Plasmatic
	%repairmarker = newObject("Repair Turret","StaticShape",RepairTurretMarker,true);
	%repairmarker.cloakable = true;

	addToSet("MissionCleanup/deployed/turret", %repairmarker);
	GameBase::setTeam(%repairmarker,GameBase::getTeam(%player));

	if(floor(%rot) == 0)
		GameBase::setPosition(%repairmarker,vector::add($los::position,"0 0 -0.210"));
	else
		GameBase::setPosition(%repairmarker,vector::add($los::position,"0 0 0.210"));
		
	GameBase::setRotation(%repairmarker,%rot);	
	Gamebase::setMapName(%repairmarker,"Repair Turret");

	%turret.repairmarker = %repairmarker;
	%repairmarker.turret = %turret;	
	GameBase::setAutoRepairRate(%repairmarker,1.0);
	
	if(!$build)
		Player::setItemCount(%player, %item, 0);		
	
	return true;
}
function RepairTurretPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Repairs nearby friendlys.");
}
function RepairTurret::verifyTarget(%this,%target)
{
	if($debug)
		echo("RepairTurret::verifyTarget "@%this@", "@%target);
	if(GameBase::getDamageLevel(%target) != 0) 
	{
		%TurretTeam = %this.RepairTeam;
		%TargetTeam = GameBase::getTeam(%target);
		if(%TurretTeam == %TargetTeam)
		{
			%client = GameBase::getOwnerClient(%target);
			%control = GameBase::getControlClient(%target);
			//verifying the object is being controled
			if(%control != -1)
				return true;
		}
		else 
			return false;
		
	}
	else
		return false;		
}