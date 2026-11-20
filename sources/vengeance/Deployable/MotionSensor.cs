$InvList[MotionSensorPack] = 1;
$MobileInvList[MotionSensorPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
AddItem(MotionSensorPack);
addWeapon(MotionSensorPack);

$CanAlwaysTeamDestroy[DeployableMotionSensor] = 1;

ItemImageData MotionSensorPackImage 
{
	shapeFile = "sensor_small";
	
	mountPoint = 0;			//Vengeance
	weaponType = 0;			//Vengeance
	reloadTime = 0.1;			//Vengeance	
	fireTime = 0.1;			//Vengeance
	sfxActivate = SoundPickUpWeapon;	//Vengeance
	mountOffset = { 0.1, 0.2 , 0.05 };		//Vengeance	//right, forward, up
	mountRotation = {1.07, -0.11, 0};		//Vengeance	//up, right, around player axis	
//	mountOffset = { 0, 0, 0.1 };
//	mountRotation = { 1.57, 0, 0 };
//	firstPerson = false;
};

ItemData MotionSensorPack 
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
//	hiliteOnActive = true;
};

function MotionSensorPackImage::onFire(%player,%item) 
{
	%client = Player::getClient(%player);
	%item = MotionSensorPack;
	
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
	{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
			%rot = "3.14159 0 " @ %zRot;
		else 
			%rot = Vector::getRotation($los::normal);
	}
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		return false;
	}
	%mSensor = newObject("","Sensor",DeployableMotionSensor,true);

	%msensor.cloakable = true;
	addToSet("MissionCleanup/deployed/sensor", %mSensor);
	GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,$los::position);
	Gamebase::setMapName(%mSensor,"Motion Sensor");
	Client::sendMessage(%client,0,"Motion Sensor deployed");
	playSound(SoundThrowItem,$los::position);	//playSound(SoundPickupBackpack,$los::position);
	if(!$build)
		echo("MSG: ",%client," deployed a Motion Sensor");

	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		schedule("replaceSensor("@%mSensor@");",5);
	}	
	$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	if(!$build)
		Player::setItemCount(%player, %item, 0);
	
	return true;
}
function MotionSensorPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Detects movement.");
}
SensorData DeployableMotionSensor
{
	description = "Motion Sensor";
	className = "DeployableSensor";
	shapeFile = "sensor_small";
	shadowDetailMask = 16;
	visibleToSensor = true;
	validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	//explosionId = DebrisExp;
	damageLevel = {0.8, 1.0};
	maxDamage = 0.4;
	debrisId = defaultDebrisSmall;
	range = 50;
	dopplerVelocity = 1;
	castLOS = false;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 4;
	mapIcon = "M_motionSensor";
	damageSkinData = "objectDamageSkins";
};
