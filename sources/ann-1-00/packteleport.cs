$InvList[TeleportPack2] = 1;
$MobileInvList[TeleportPack2] = 1;
$RemoteInvList[TeleportPack2] = 1;

ItemImageData TeleportPack2Image
{	shapeFile = "sensor_small";
	mountPoint = 2;
	maxEnergy = 0;
	weaponType = 2;
	mountOffset= { 0, 0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	sfxFire = SoundTeleport;
};

ItemData TeleportPack
{	description = "Teleport Pack2";
	className = "Backpack";
	shapeFile = "sensor_small";
	hudIcon = "energypack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TeleportPack2Image;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack2Image::onActivate(%player, %imageSlot)
{	if(!$TeleUsed[%player]) 
	{	GameBase::playSound(%player,SoundTeleport,0);
		Client::sendMessage(Player::getClient(%player),1,"You successfully teleported!");
		Client::sendMessage(Player::getClient(%player),1,"Your armor's teleport module is now recharging.");
		%hasflag = Player::getMountedItem(%player, 2);
		if(%hasflag!=-1 && %hasflag!="DeadWeight")
		{	Player::dropItem(%player, %hasflag);
      			Client::sendMessage(Player::getClient(%player),1,"While teleporting, you dropped the flag...");
		}
		%client = Player::getClient(%player);
		%object = Client::getOwnedObject(%client);
		Player::setDamageFlash(%player, 0.4);
		GameBase::startFadein(%player);
		GameBase::setPosition(%player, $TeleSpot[Client::getTeam(%client)]);
		Player::trigger(%player,$BackpackSlot,false);
		$TeleUsed[%player] = true;
		%time = 10;
		schedule("TelePackCooling(" @ %time @ ", " @ %player @ ");", 1, %player);
	}
	else 
	{	Client::sendMessage(Player::getClient(%player),0,"Your armor's teleport module is still recharging jack ass.");
		GameBase::playSound(%player,SoundTelefail,0);
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function TeleportPackImage2::onDeactivate(%player, %imageSlot)
{	//do nothing
}

function TelePackCooling(%time, %player)
{	if(%time > 0)
	{	schedule("TelePackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
	}
	else if(%time == 0)
	{	TeleReset(%player);
	}
}

function TeleReset(%player)
{	$TeleUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),1,"Teleport module is now available...");
}
