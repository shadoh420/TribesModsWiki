$InvList[CameraPack] = 1;
$MobileInvList[CameraPack] = 1;
$RemoteInvList[CameraPack] = 1;
AddItem(CameraPack);
addWeapon(CameraPack);

$CanAlwaysControl[CameraTurret] = 1;
$CanAlwaysTeamDestroy[CameraTurret] = 1;

ItemImageData CameraPackImage 
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

ItemData CameraPack 
{
	description = "Camera";
	shapeFile = "camera";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
//	hiliteOnActive = true;
};

function CameraPackImage::onFire(%player,%item) 
{
	%item =CameraPack;
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform")
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
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
			%rot = Vector::getRotation($los::normal);
	}
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		return false;
	}
	%camera = newObject("Camera","Turret",CameraTurret,true);

	%camera.cloakable = true;
	addToSet("MissionCleanup/deployed/sensor", %camera);
	GameBase::setTeam(%camera,GameBase::getTeam(%player));
	GameBase::setRotation(%camera,%rot);
	GameBase::setPosition(%camera,$los::position);
	Gamebase::setMapName(%camera,"Camera");
	Client::sendMessage(%client,0,"Camera deployed");
	playSound(SoundThrowItem,$los::position);	//playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	
	if(!$build)
		echo("MSG: ",%client," deployed a Camera");
	$turret::count++;
	
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		schedule("replaceSensor("@%camera@");",5);
	}	
	if(!$build)
		Player::setItemCount(%player, %item, 0);	
	return true;
}
function CameraPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>View an area remotely.");
}
TurretData CameraTurret 
{	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};

function CameraTurret::onAdd(%this) 
{

	schedule("CameraTurret::deploy(" @ %this @ ");",1,%this);
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Camera");
}

function CameraTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function CameraTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function CameraTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "CameraPack"]--;
}
