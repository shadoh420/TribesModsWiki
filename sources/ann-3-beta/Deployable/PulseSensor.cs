$InvList[PulseSensorPack] = 1;
$MobileInvList[PulseSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
AddItem(PulseSensorPack);

$CanAlwaysTeamDestroy[DeployablePulseSensor] = 1;

ItemImageData PulseSensorPackImage 
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack 
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = $InvHead[ihDSe];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function PulseSensorPack::DeployShape(%player,%item) 
{
	if(Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item) && !$build) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}

SensorData DeployablePulseSensor
{
	description = "Remote Pulse Sensor";
	className = "DeployableSensor";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	visibleToSensor = true;
	validateShape = true;
	validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 1.0;
	debrisId = defaultDebrisSmall;
	//explosionId = flashDebrisSmall;
	range = 200;
	castLOS = true;
	supression = false;
	mapFilter = 4;
	mapIcon = "M_Radar";
	damageSkinData = "objectDamageSkins";
};
