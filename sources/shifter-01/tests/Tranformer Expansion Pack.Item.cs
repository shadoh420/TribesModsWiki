$TeamItemMax[TLAPC] = 2;
$TeamItemMax[THAPC] = 2;

ItemData TransAPCVehicle
{
	description = "TLAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

ItemImageData TransAPCPackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TransAPCPack
{
	description = "APC Transformation";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = TransAPCPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function TransAPCPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	Player::applyImpulse(%player, "0 0 300");
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = TransAPCVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("", Flier, TLAPC, true);
	%damage = GameBase::getDamageLevel(%player);


	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
	%vehicle = newObject("","Flier",LAPC,true);
//	%vehicle = newObject("hover_apc_sml","Flier",LAPC,true);
	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
}

function TransAPCPackImage::onDeactivate(%player, %imageSlot)
{
// do nothing really... all handled by dismounting.
}


ItemData TransHAPCVehicle
{
	description = "THAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

ItemImageData TransHAPCPackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TransHAPCPack
{
	description = "HAPC Transformation";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = TransHAPCPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function TransHAPCPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	Player::applyImpulse(%player, "0 0 300");
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = TransHAPCVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, THAPC, true);
	%damage = GameBase::getDamageLevel(%player);


	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	%vehicle = newObject("hover_apc","Flier",THAPC,true);
	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
}

function TransHAPCPackImage::onDeactivate(%player, %imageSlot)
{
// do nothing really... all handled by dismounting.
}

