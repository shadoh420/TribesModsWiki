//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
//$InvList[SensorJammerPack] = 1;

$ItemMax[larmor, SensorJammerPack] = 1;	//Seraph
$ItemMax[lfemale, SensorJammerPack] = 1;//Seraph
$ItemMax[earmor, SensorJammerPack] = 1;	//Slave
$ItemMax[efemale, SensorJammerPack] = 1;//Slave
$ItemMax[marmor, SensorJammerPack] = 0;	//Pawn
$ItemMax[aarmor, SensorJammerPack = 1;	//Navigator
$ItemMax[darmor, SensorJammerPack] = 0;	//Atomizer
$ItemMax[barmor, SensorJammerPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData SensorJammerPackImage 
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
	sfxFire = SoundJammerOn;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
}; 

ItemData SensorJammerPack 
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 33;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
}; 

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
} 
