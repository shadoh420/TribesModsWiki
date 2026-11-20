$InvList[DeployableSensorJammerPack] = 1;
$MobileInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
AddItem(DeployableSensorJammerPack);
addWeapon(DeployableSensorJammerPack);

$CanAlwaysTeamDestroy[DeployableSensorJammer] = 1;

ItemImageData DeployableSensorJamPackImage 
{
	mountPoint = 0;			//Vengeance
	weaponType = 0;			//Vengeance
	reloadTime = 0.1;			//Vengeance	
	fireTime = 0.1;			//Vengeance
	sfxActivate = SoundPickUpWeapon;	//Vengeance
	mountOffset = { 0.1, 0.2 , 0.05 };		//Vengeance	//right, forward, up
	mountRotation = {1.07, -0.11, 0};		//Vengeance	//up, right, around player axis	
		
	shapeFile = "sensor_jammer";
//	mountPoint = 2;
//	mountOffset = { 0, 0.03, 0.1 };
//	mountRotation = { 1.57, 0, 0 };
//	firstPerson = false;
};

ItemData DeployableSensorJammerPack 
{
	description = "Sensor Jammer";
	shapeFile = "sensor_jammer";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = DeployableSensorJamPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
//	hiliteOnActive = true;
};


function DeployableSensorJamPackImage::onFire(%player,%item) 
{
	%item = DeployableSensorJammerPack;
	if(Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)&& !$build) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}
function DeployableSensorJammerPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Jams enemy pulse sensors.");
}
SensorData DeployableSensorJammer
{
	description = "Remote Sensor Jammer";
	className = "DeployableSensor";
	shapeFile = "sensor_jammer";
	shadowDetailMask = 4;
	visibleToSensor = true;
	validateShape = true;
	validateMaterials = true;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	damageLevel = {0.8, 1.0};
	maxDamage = 0.5;
	//explosionId = DebrisExp;
	debrisId = defaultDebrisSmall;
	range = 80;
	castLOS = true;
	supression = true;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
};
