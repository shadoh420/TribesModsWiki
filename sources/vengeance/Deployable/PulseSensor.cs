$InvList[PulseSensorPack] = 1;
$MobileInvList[PulseSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
AddItem(PulseSensorPack);
addWeapon(PulseSensorPack);

$CanAlwaysTeamDestroy[DeployablePulseSensor] = 1;

ItemImageData PulseSensorPackImage 
{
	shapeFile = "radar_small";
	mountPoint = 0;			//Vengeance
	weaponType = 0;			//Vengeance
	reloadTime = 0.1;			//Vengeance	
	fireTime = 0.1;			//Vengeance
	sfxActivate = SoundPickUpWeapon;	//Vengeance
	mountOffset = { 0.1, 0.2 , 0.05 };		//Vengeance	//right, forward, up
	mountRotation = {1.07, -0.11, 0};		//Vengeance	//up, right, around player axis	
};

ItemData PulseSensorPack 
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
//	hiliteOnActive = true;
};


function PulseSensorPackImage::onFire(%player,%item) 
{
	%item = PulseSensorPack;
	if(Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item) && !$build) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}
function PulseSensorPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Detects energy.");
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
