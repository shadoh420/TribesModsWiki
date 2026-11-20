ItemImageData AdminPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 0.1;
	sfxFire = SoundJammerOn;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData AdminPack
{
	description = "Admin Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
//	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = AdminPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};

function AdminPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	if(%client.GiveallEnabled || %client.isAdmin)
	{ remoteGiveAll(%client); }
	
	%player.shieldStrength = 1000;
	Player::setSensorSupression(%player, 10);
	Client::sendMessage(%client, 1, "God Mode: ON~wshieldhit.wav");
}
function AdminPackImage::onDeactivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%player.shieldStrength = 0;
	Player::setSensorSupression(%player, 0);
	Client::sendMessage(%client, 0, "God Mode: OFF~wfloat_explode.wav");
}