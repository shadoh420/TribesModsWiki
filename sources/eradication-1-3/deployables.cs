
//----------------------------------------------------------------------------

$TeamItemMax[DeployableInvPack] = 5;
$InvList[DeployableInvPack] = 1;
$RemoteInvList[DeployableInvPack] = 0;
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[harmor, DeployableInvPack] = 0;
$ItemMax[carmor, DeployableInvPack] = 1;
$ItemMax[sarmor, DeployableInvPack] = 1;

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "pDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	addToSet("MissionCleanup", %inv);
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player));
	GameBase::setPosition(%inv,$los::position);
	GameBase::setRotation(%inv,%rot);
	Gamebase::setMapName(%inv,%name);
	Client::sendMessage(%client,0,"Inventory Station deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
	echo("MSG: ",%client," deployed an Inventory Station");
	return true;
}

//----------------------------------------------------------------------------

$TeamItemMax[DeployableAmmoPack] = 7;
$InvList[DeployableAmmoPack] = 1;
$RemoteInvList[DeployableAmmoPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;
$ItemMax[marmor, DeployableAmmoPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 1;
$ItemMax[harmor, DeployableAmmoPack] = 1;
$ItemMax[carmor, DeployableAmmoPack] = 1;
$ItemMax[sarmor, DeployableAmmoPack] = 1;

ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "pDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	addToSet("MissionCleanup", %inv);
	%rot = GameBase::getRotation(%player); 
	GameBase::setTeam(%inv,GameBase::getTeam(%player));
	GameBase::setPosition(%inv,$los::position);
	GameBase::setRotation(%inv,%rot);
	Gamebase::setMapName(%inv,%name);
	Client::sendMessage(%client,0,"Ammo Station deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
	echo("MSG: ",%client," deployed an Ammo Station");
	return true;
}

//----------------------------------------------
$TeamItemMax[BarrierPack] = 15;
$InvList[BarrierPack] = 1;
$RemoteInvList[BarrierPack] = 1;
$ItemMax[larmor, BarrierPack] = 0;
$ItemMax[lfemale, BarrierPack] = 0;
$ItemMax[marmor, BarrierPack] = 1;
$ItemMax[mfemale, BarrierPack] = 1;
$ItemMax[harmor, BarrierPack] = 1;
$ItemMax[carmor, BarrierPack] = 1;
$ItemMax[sarmor, BarrierPack] = 1;

ItemImageData BarrierPackImage 
{ 
	shapeFile = "mineammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData BarrierPack 
{ 
	description = "Barrier"; 
	shapeFile = "sensor_small"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = BarrierPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 199; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function BarrierPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function BarrierPack::onDeploy(%player,%item,%pos) 
{ 
	if (BarrierPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function BarrierPack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else {
			%rot =  "0 1.578 " @ getWord(Vector::getRotation($los::normal),2) + 1.578;
		}
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",Barrier,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Barrier deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	schedule("playSound(ForceFieldOpen,"@$los::position @");",2,%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "BarrierPack"]++;
	echo("MSG: ",%client," deployed a Barrier");
	return true;
}



StaticShapeData Barrier 
{ 
	shapeFile = "forcefield_5x5"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 5.0; 
	visibleToSensor = true; 
	isTranslucent = true; 
	description = "Barrier"; 
}; 

function DeployableBarrier::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BarrierPack"]--; 
} 

//----------------------------------------------
	
$TeamItemMax[StackableCratePack] = 50;
$InvList[StackableCratePack] = 1;
$RemoteInvList[StackableCratePack] = 1;
$ItemMax[larmor, StackableCratePack] = 0;
$ItemMax[lfemale, StackableCratePack] = 0;
$ItemMax[marmor, StackableCratePack] = 1;
$ItemMax[mfemale, StackableCratePack] = 1;
$ItemMax[harmor, StackableCratePack] = 0;
$ItemMax[carmor, StackableCratePack] = 1;
$ItemMax[sarmor, StackableCratePack] = 1;

ItemImageData StackableCratePackImage 
{ 
	shapeFile = "magcargo"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.5, 0 }; 
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData StackableCratePack 
{ 
	description = "Stackable Crate"; 
	shapeFile = "magcargo"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = StackableCratePackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 149; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function StackableCratePack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function StackableCratePack::onDeploy(%player,%item,%pos) 
{ 
	if (StackableCratePack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function StackableCratePack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%shape = newObject("","StaticShape",StackableCrate,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Stackable Crate deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "StackableCratePack"]++;
	echo("MSG: ",%client," deployed a Stackable Crate");
	return true;
}


StaticShapeData StackableCrate 
{
	shapeFile = "magcargo";
	debrisId = flashDebrisSmall;
	maxDamage = 3.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Stackable Crate";
};


function StackableCrate::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "StackableCratePack"]--; 
} 

//----------------------------------------------
	
$TeamItemMax[SuspendedPlatformPack] = 5;
$InvList[SuspendedPlatformPack] = 1;
$RemoteInvList[SuspendedPlatformPack] = 1;
$ItemMax[larmor, SuspendedPlatformPack] = 0;
$ItemMax[lfemale, SuspendedPlatformPack] = 0;
$ItemMax[marmor, SuspendedPlatformPack] = 1;
$ItemMax[mfemale, SuspendedPlatformPack] = 1;
$ItemMax[harmor, SuspendedPlatformPack] = 0;
$ItemMax[carmor, SuspendedPlatformPack] = 1;
$ItemMax[sarmor, SuspendedPlatformPack] = 1;

ItemImageData SuspendedPlatformPackImage 
{ 
	shapeFile = "mineammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData SuspendedPlatformPack 
{ 
	description = "Suspended Platform"; 
	shapeFile = "sensor_small"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = SuspendedPlatformPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 249; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function SuspendedPlatformPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function SuspendedPlatformPack::onDeploy(%player,%item,%pos) 
{ 
	if (SuspendedPlatformPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function SuspendedPlatformPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] > $TeamItemMax[%item]) {
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	%rot = GameBase::getRotation(%player); 
	%shape = newObject("","StaticShape",SuspendedPlatform,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	%pos=GameBase::getPosition(%player);
	%atFeet=getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2)-3 @ " ";
	GameBase::setPosition(%shape,%atFeet);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Suspended Platform deployed");
	playSound(SoundPickupBackpack,%atFeet);
	GameBase::startFadeIn(%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "SuspendedPlatformPack"]++;
	echo("MSG: ",%client," deployed a Suspended Platform");
	return true;
}


StaticShapeData SuspendedPlatform 
{ 
	shapeFile = "elevator6x6thin"; 
	debrisId = defaultDebrisSmall; 
	maxDamage = 3.00; 
	visibleToSensor = false; 
	isTranslucent = true; 
	description = "Suspended Platform"; 
}; 


function SuspendedPlatform::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SuspendedPlatformPack"]--; 
} 

//----------------------------------------------
	
$TeamItemMax[LargeDecoyTurretPack] = 2;
$InvList[LargeDecoyTurretPack] = 1;
$RemoteInvList[LargeDecoyTurretPack] = 0;
$ItemMax[larmor, LargeDecoyTurretPack] = 0;
$ItemMax[lfemale, LargeDecoyTurretPack] = 0;
$ItemMax[marmor, LargeDecoyTurretPack] = 1;
$ItemMax[mfemale, LargeDecoyTurretPack] = 1;
$ItemMax[harmor, LargeDecoyTurretPack] = 0;
$ItemMax[carmor, LargeDecoyTurretPack] = 1;
$ItemMax[sarmor, LargeDecoyTurretPack] = 1;

ItemImageData LargeDecoyTurretPackImage 
{ 
	shapeFile = "mineammo"; 
	mountPoint = 2; 
	mountRotation = { 1.57, 0, 0 };
	mountOffset = { 0, 0, 0.1 }; 
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData LargeDecoyTurretPack 
{ 
	description = "Large Decoy Turret"; 
	shapeFile = "mineammo"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = LargeDecoyTurretPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 149; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function LargeDecoyTurretPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function LargeDecoyTurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (LargeDecoyTurretPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function LargeDecoyTurretPack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%shape = newObject("","StaticShape",LargeDecoyTurret,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"LargeDecoy Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	Gamebase::setMapName(%shape,"Decoy Turret" @ Client::getName(%client));
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeDecoyTurretPack"]++;
	echo("MSG: ",%client," deployed a Large Decoy Turret");
	return true;
}


StaticShapeData LargeDecoyTurret 
{
	shapeFile = "hellfiregun";
	debrisId = flashDebrisSmall;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Large Decoy Turret";
};

function LargeDecoyTurret::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeDecoyTurretPack"]--; 
} 

//----------------------------------------------
	
$TeamItemMax[MediumDecoyTurretPack] = 4;
$InvList[MediumDecoyTurretPack] = 1;
$RemoteInvList[MediumDecoyTurretPack] = 1;
$ItemMax[larmor, MediumDecoyTurretPack] = 0;
$ItemMax[lfemale, MediumDecoyTurretPack] = 0;
$ItemMax[marmor, MediumDecoyTurretPack] = 1;
$ItemMax[mfemale, MediumDecoyTurretPack] = 1;
$ItemMax[harmor, MediumDecoyTurretPack] = 0;
$ItemMax[carmor, MediumDecoyTurretPack] = 1;
$ItemMax[sarmor, MediumDecoyTurretPack] = 1;

ItemImageData MediumDecoyTurretPackImage 
{ 
	shapeFile = "remoteturret"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData MediumDecoyTurretPack 
{ 
	description = "Medium Decoy Turret"; 
	shapeFile = "remoteturret"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = MediumDecoyTurretPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 99; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function MediumDecoyTurretPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function MediumDecoyTurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (MediumDecoyTurretPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function MediumDecoyTurretPack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",MediumDecoyTurret,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Medium Decoy Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "MediumDecoyTurretPack"]++;
	Gamebase::setMapName(%shape,"Decoy Turret" @ Client::getName(%client));
	echo("MSG: ",%client," deployed a Medium Decoy Turret");
	return true;

}

StaticShapeData MediumDecoyTurret 
{
	shapeFile = "remoteturret";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Medium Decoy Turret";
};

function MediumDecoyTurret::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "MediumDecoyTurretPack"]--; 
} 

function MediumDecoyTurret::onAdd(%this)
{
	schedule("MediumDecoyTurret::deploy(" @ %this @ ");",1,%this);
}

function MediumDecoyTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

//----------------------------------------------
	
$TeamItemMax[SmallDecoyTurretPack] = 4;
$InvList[SmallDecoyTurretPack] = 1;
$RemoteInvList[SmallDecoyTurretPack] = 1;
$ItemMax[larmor, SmallDecoyTurretPack] = 0;
$ItemMax[lfemale, SmallDecoyTurretPack] = 0;
$ItemMax[marmor, SmallDecoyTurretPack] = 1;
$ItemMax[mfemale, SmallDecoyTurretPack] = 1;
$ItemMax[harmor, SmallDecoyTurretPack] = 0;
$ItemMax[carmor, SmallDecoyTurretPack] = 1;
$ItemMax[sarmor, SmallDecoyTurretPack] = 1;

ItemImageData SmallDecoyTurretPackImage 
{ 
	shapeFile = "camera"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData SmallDecoyTurretPack 
{ 
	description = "Small Decoy Turret"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
	heading = "pDeployables"; 
	imageType = SmallDecoyTurretPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 49; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function SmallDecoyTurretPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function SmallDecoyTurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (SmallDecoyTurretPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function SmallDecoyTurretPack::deployShape(%player,%item) 
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",SmallDecoyTurret,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Small Decoy Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "SmallDecoyTurretPack"]++;
	Gamebase::setMapName(%shape,"Decoy Turret" @ Client::getName(%client));
	echo("MSG: ",%client," deployed a Small Decoy Turret");
	return true;

}

StaticShapeData SmallDecoyTurret 
{
	shapeFile = "camera";
	debrisId = flashDebrisSmall;
	maxDamage = 0.75;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Small Decoy Turret";
};

function SmallDecoyTurret::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "SmallDecoyTurretPack"]--; 
} 

function SmallDecoyTurret::onAdd(%this)
{
	schedule("SmallDecoyTurret::deploy(" @ %this @ ");",1,%this);
}

function SmallDecoyTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}


//----------------------------------------------------------------------------

$TeamItemMax[AutoPlasmaTurretPack] = 4;
$InvList[AutoPlasmaTurretPack] = 1;
$RemoteInvList[AutoPlasmaTurretPack] = 1;
$ItemMax[larmor, AutoPlasmaTurretPack] = 0;
$ItemMax[lfemale, AutoPlasmaTurretPack] = 0;
$ItemMax[marmor, AutoPlasmaTurretPack] = 1;
$ItemMax[mfemale, AutoPlasmaTurretPack] = 1;
$ItemMax[harmor, AutoPlasmaTurretPack] = 0;
$ItemMax[carmor, AutoPlasmaTurretPack] = 1;
$ItemMax[sarmor, AutoPlasmaTurretPack] = 1;
																			
ItemImageData AutoPlasmaTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData AutoPlasmaTurretPack
{
	description = "AutoPlasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "tTurrets";
	imageType = AutoPlasmaTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 249;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AutoPlasmaTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AutoPlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (AutoPlasmaTurretPack::deployShape(%player,%item)) {
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

function AutoPlasmaTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%turret = newObject("remoteTurret","Turret",AutoPlasmaTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"AutoPlasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"AutoPlasma Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "AutoPlasmaTurretPack"]++;
	echo("MSG: ",%client," deployed a AutoPlasma Turret");
	return true;

}

//----------------------------------------------------------------------------

$TeamItemMax[BlasterTurretPack] = 4;
$InvList[BlasterTurretPack] = 1;
$RemoteInvList[BlasterTurretPack] = 1;
$ItemMax[larmor, BlasterTurretPack] = 0;
$ItemMax[lfemale, BlasterTurretPack] = 0;
$ItemMax[marmor, BlasterTurretPack] = 1;
$ItemMax[mfemale, BlasterTurretPack] = 1;
$ItemMax[harmor, BlasterTurretPack] = 0;
$ItemMax[carmor, BlasterTurretPack] = 1;
$ItemMax[sarmor, BlasterTurretPack] = 1;

ItemImageData BlasterTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData BlasterTurretPack
{
	description = "Blaster Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "tTurrets";
	imageType = BlasterTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 199;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlasterTurretPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ Player::mountItem(%player,%item,$BackpackSlot); }
else { Player::deployItem(%player,%item); }
}

function BlasterTurretPack::onDeploy(%player,%item,%pos)
{
if (BlasterTurretPack::deployShape(%player,%item)) 
	{ Player::decItemCount(%player,%item); }
}

function CountObjects(%set,%name,%num) 
{
%count = 0;
for(%i=0;%i<%num;%i++) 
	{
	%obj=Group::getObject(%set,%i);
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
		%count++;
	}
return %count;
}

function BlasterTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox + 2) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 2) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%turret = newObject("remoteTurret","Turret",BlasterTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Blaster Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Blaster Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "BlasterTurretPack"]++;
	echo("MSG: ",%client," deployed a Blaster Turret");
	return true;

}

//----------------------------------------------------------------------------

$TeamItemMax[ChaingunTurretPack] = 4;
$InvList[ChaingunTurretPack] = 1;
$RemoteInvList[ChaingunTurretPack] = 1;
$ItemMax[larmor, ChaingunTurretPack] = 0;
$ItemMax[lfemale, ChaingunTurretPack] = 0;
$ItemMax[marmor, ChaingunTurretPack] = 1;
$ItemMax[mfemale, ChaingunTurretPack] = 1;
$ItemMax[harmor, ChaingunTurretPack] = 0;
$ItemMax[carmor, ChaingunTurretPack] = 1;
$ItemMax[sarmor, ChaingunTurretPack] = 1;
																				
ItemImageData ChaingunTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ChaingunTurretPack
{
	description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "tTurrets";
	imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 249;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ChaingunTurretPack::onDeploy(%player,%item,%pos)
{
	if (ChaingunTurretPack::deployShape(%player,%item)) {
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

function ChaingunTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%turret = newObject("remoteTurret","Turret",ChaingunTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Chaingun Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Chaingun Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ChaingunTurretPack"]++;
	echo("MSG: ",%client," deployed a Chaingun Turret");
	return true;

}

//----------------------------------------------------------------------------

$TeamItemMax[DiscTurretPack] = 3;
$InvList[DiscTurretPack] = 1;
$RemoteInvList[DiscTurretPack] = 1;
$ItemMax[larmor, DiscTurretPack] = 0;
$ItemMax[lfemale, DiscTurretPack] = 0;
$ItemMax[marmor, DiscTurretPack] = 1;
$ItemMax[mfemale, DiscTurretPack] = 1;
$ItemMax[harmor, DiscTurretPack] = 0;
$ItemMax[carmor, DiscTurretPack] = 1;
$ItemMax[sarmor, DiscTurretPack] = 1;
																			
ItemImageData DiscTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData DiscTurretPack
{
	description = "Disc Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "tTurrets";
	imageType = DiscTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 249;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DiscTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DiscTurretPack::onDeploy(%player,%item,%pos)
{
	if (DiscTurretPack::deployShape(%player,%item)) {
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

function DiscTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else
			%rot = Vector::getRotation($los::normal);
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%turret = newObject("remoteTurret","Turret",DiscTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Disc Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Disc Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "DiscTurretPack"]++;
	echo("MSG: ",%client," deployed a Disc Turret");
	return true;

}

//----------------------------------------------------------------------------

$TeamItemMax[FusionTurretPack] = 2;
$InvList[FusionTurretPack] = 1;
$RemoteInvList[FusionTurretPack] = 1;
$ItemMax[larmor, FusionTurretPack] = 0;
$ItemMax[lfemale, FusionTurretPack] = 0;
$ItemMax[marmor, FusionTurretPack] = 1;
$ItemMax[mfemale, FusionTurretPack] = 1;
$ItemMax[harmor, FusionTurretPack] = 0;
$ItemMax[carmor, FusionTurretPack] = 1;
$ItemMax[sarmor, FusionTurretPack] = 1;
																				
ItemImageData FusionTurretPackImage
{
	shapeFile = "mineammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FusionTurretPack
{
	description = "Fusion Turret";
	shapeFile = "mineammo";
	className = "Backpack";
   heading = "tTurrets";
	imageType = FusionTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 349;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FusionTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function FusionTurretPack::onDeploy(%player,%item,%pos)
{
	if (FusionTurretPack::deployShape(%player,%item)) {
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

function FusionTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%turret = newObject("remoteTurret","Turret",FusionTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Fusion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Fusion Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "FusionTurretPack"]++;
	echo("MSG: ",%client," deployed a Fusion Turret");
	Client::setOwnedObject(%client, %turret); 
	Client::setOwnedObject(%client, %player);
	return true;
}

//----------------------------------------------------------------------------

$TeamItemMax[GrenadeTurretPack] = 2;
$InvList[GrenadeTurretPack] = 1;
$RemoteInvList[GrenadeTurretPack] = 1;
$ItemMax[larmor, GrenadeTurretPack] = 0;
$ItemMax[lfemale, GrenadeTurretPack] = 0;
$ItemMax[marmor, GrenadeTurretPack] = 1;
$ItemMax[mfemale, GrenadeTurretPack] = 1;
$ItemMax[harmor, GrenadeTurretPack] = 0;
$ItemMax[carmor, GrenadeTurretPack] = 1;
$ItemMax[sarmor, GrenadeTurretPack] = 1;
																			
ItemImageData GrenadeTurretPackImage
{
	shapeFile = "mineammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData GrenadeTurretPack
{
	description = "Grenade Turret";
	shapeFile = "mineammo";
	className = "Backpack";
   heading = "tTurrets";
	imageType = GrenadeTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 199;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GrenadeTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function GrenadeTurretPack::onDeploy(%player,%item,%pos)
{
	if (GrenadeTurretPack::deployShape(%player,%item)) {
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

function GrenadeTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%turret = newObject("remoteTurret","Turret",GrenadeTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Grenade Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Grenade Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "GrenadeTurretPack"]++;
	echo("MSG: ",%client," deployed a Grenade Turret");
	return true;
}


//----------------------------------------------------------------------------

$TeamItemMax[LaserTurretPack] = 3;
$InvList[LaserTurretPack] = 1;
$RemoteInvList[LaserTurretPack] = 1;
$ItemMax[larmor, LaserTurretPack] = 0;
$ItemMax[lfemale, LaserTurretPack] = 0;
$ItemMax[marmor, LaserTurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
$ItemMax[harmor, LaserTurretPack] = 0;
$ItemMax[carmor, LaserTurretPack] = 1;
$ItemMax[sarmor, LaserTurretPack] = 1;

ItemImageData LaserTurretPackImage
{
	shapeFile = "mineammo";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret";
	shapeFile = "mineammo";
	className = "Backpack";
   heading = "tTurrets";
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 349;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ Player::mountItem(%player,%item,$BackpackSlot); }
else { Player::deployItem(%player,%item); }
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
if (LaserTurretPack::deployShape(%player,%item)) 
	{ Player::decItemCount(%player,%item); }
}

function CountObjects(%set,%name,%num) 
{
%count = 0;
for(%i=0;%i<%num;%i++) 
	{
	%obj=Group::getObject(%set,%i);
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
		%count++;
	}
return %count;
}

function LaserTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount >= $MaxNumTurretsInBox) {
		Client::sendMessage(%client,0,"Too many turrets in the area");
		return false;
	}

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
	%turretCount = 0;
	for (%count = 0; %count <= %num; %count++)	
		{
		if (getObjectType(Group::getObject(%set,%count)) == "Turret")
			%turretCount++;
		}
	deleteObject(%set);
	if(%turretCount > 0) {
		Client::sendMessage(%client,0,"Frequency Overload - Too close to other Turrets");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Laser Turret deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
	echo("MSG: ",%client," deployed a Laser Turret");
	return true;
}


//----------------------------------------------
	
$TeamItemMax[EnergyVortexPack] = 1;
$InvList[EnergyVortexPack] = 1;
$RemoteInvList[EnergyVortexPack] = 0;
$ItemMax[larmor, EnergyVortexPack] = 0;
$ItemMax[lfemale, EnergyVortexPack] = 0;
$ItemMax[marmor, EnergyVortexPack] = 0;
$ItemMax[mfemale, EnergyVortexPack] = 0;
$ItemMax[harmor, EnergyVortexPack] = 0;
$ItemMax[carmor, EnergyVortexPack] = 0;
$ItemMax[sarmor, EnergyVortexPack] = 1;

ItemImageData EnergyVortexPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.8, -1.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 5.0;
};

ItemData EnergyVortexPack
{
	description = "Energy Vortex";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = "pDeployables";
	imageType = EnergyVortexPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 599;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyVortexPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function EnergyVortexPack::onDeploy(%player,%item,%pos)
{
	if (EnergyVortexPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function EnergyVortexPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","StaticShape",EnergyVortex,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Client::sendMessage(%client,0,"Energy Vortex deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "EnergyVortexPack"]++;
	echo("MSG: ",%client," deployed an Energy Vortex");
	return true;
}

StaticShapeData EnergyVortex 
{
	description = "Evergy Vortex";
	shapeFile = "generator_p";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
	triggerRadius = 20;
}; 


function EnergyVortex::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EnergyVortexPack"]--;
}

function EnergyVortex::onCollision(%this, %obj)
{
if (getObjectType(%obj) == "Player") 
	{
	if (GameBase::getTeam(%this) != GameBase::getTeam(%obj))
		{
		if (GameBase::getEnergy(%obj) >= 20)
			GameBase::setEnergy(%obj, GameBase::getEnergy(%obj) - 20);
		else
			GameBase::setEnergy(%obj, 0);

		if (Player::getDamageFlash(%obj) < 0.5 )
			Player::setDamageFlash(%obj, Player::getDamageFlash(%obj) + 0.3);
		else
			Player::setDamageFlash(%obj, 0.8);

		}
	}
}

//----------------------------------------------
	
$TeamItemMax[EnergyFieldGeneratorPack] = 1;
$InvList[EnergyFieldGeneratorPack] = 1;
$RemoteInvList[EnergyFieldGeneratorPack] = 0;
$ItemMax[larmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[lfemale, EnergyFieldGeneratorPack] = 0;
$ItemMax[marmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[mfemale, EnergyFieldGeneratorPack] = 0;
$ItemMax[harmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[carmor, EnergyFieldGeneratorPack] = 0;
$ItemMax[sarmor, EnergyFieldGeneratorPack] = 1;

ItemImageData EnergyFieldGeneratorPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.8, -1.0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 5.0;
};

ItemData EnergyFieldGeneratorPack
{
	description = "Energy Field Generator";
	shapeFile = "generator_p";
	className = "Backpack";
	heading = "pDeployables";
	imageType = EnergyFieldGeneratorPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 599;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyFieldGeneratorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function EnergyFieldGeneratorPack::onDeploy(%player,%item,%pos)
{
	if (EnergyFieldGeneratorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function EnergyFieldGeneratorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape") {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%rot = GameBase::getRotation(%player); 
	%turret = newObject("","StaticShape",EnergyFieldGenerator,true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Client::sendMessage(%client,0,"Energy Field Generator deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "EnergyFieldGeneratorPack"]++;
	echo("MSG: ",%client," deployed an Energy Field Generator");
	return true;
}

StaticShapeData EnergyFieldGenerator 
{
	description = "Evergy Field Generator";
	shapeFile = "generator_p";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
	triggerRadius = 40;
	disableCollision = true;
}; 


function EnergyFieldGenerator::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "EnergyFieldGeneratorPack"]--;
}

function EnergyFieldGenerator::onCollision(%this, %obj)
{
if (getObjectType(%obj) == "Player") 
	{
	if (GameBase::getTeam(%this) == GameBase::getTeam(%obj)) {
		GameBase::setEnergy(%obj, GameBase::getEnergy(%obj) + 5);
		}
	}
}
