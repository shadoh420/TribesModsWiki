$InvList[SightPack] = 1;
$MobileInvList[SightPack] = 1;
$RemoteInvList[SightPack] = 1;
AddItem(SightPack);

// pack by Plasmatic
// ziptiezmail@netscape.net


ItemImageData SightPackImage
{	
	shapeFile = "sensor_small";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	mountOffset = { 0, -0.1, 0.2 };
	mountRotation = { 1.0, -3.14, 0};
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = true;

//	sfxReload = SoundSightOff;
//	sfxActivate = SoundMortarIdle;	//SoundPickUpWeapon;
//	sfxReady = SoundMortarIdle;
	sfxFire = SoundLaserIdle;
};

ItemData SightPack
{	
	description = "True Sight Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SightPackImage;
	price = 15;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SightPackImage::onActivate(%player,%imageSlot)
{	
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Sight Pack on. See all, know all.");
	schedule("CheckSight("@%player@");",1);

}


function SightPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
	%client = Player::getClient(%player);
	Client::sendMessage(%client,0,"Sight Pack Off, reverting to mortal sight.");
}

function SightPack::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%client = Player::getClient(%player);
	if(%client.weaponHelp)
		Bottomprint(%client, "<jc>True Sight:<f2> See with the help of your God(s). ");
}

//changes to true sight to decham chams -plasmatic 2.2
function CheckSight(%player)
{
	%client = Player::getClient(%player);
	%player = Client::getOwnedObject(%client);
	if(Player::isTriggered(%player,$BackpackSlot) && (Player::getMountedItem(%player,$BackpackSlot) == "SightPack")) 
	{	
		if (GameBase::getLOSInfo(%player,3000))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%set = newObject("set",SimSet);
			%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; 
			%num = containerBoxFillSet(%set,%Mask,$los::position,30,30,30,0);
			%totalnum = Group::objectCount(%set);
			%enemyflag=0;
			for(%i = 0; %i < %totalnum; %i++)
			{
				%obj = Group::getObject(%set, %i);
				//%name = Item::getItemData(%obj);
				//client::sendMessage(Player::getClient(%player),1,"Itemdata: "@ %i @ " " @ %name);
				%dist = Vector::getDistance($los::position, GameBase::getPosition(%obj));
				// uncloak in a sphere, not a box..
				if(%dist < 15)
				{
					if(%obj.cloaked && %team != Client::getTeam(%obj))
					{     
						GameBase::startFadeIn(%obj);
						%obj.cloaked = "";	
					}
					else if(getObjectType(%obj) == "Player" && %dist < 7.5)
					{
						%enemycl = Player::getclient(%obj);
						if(%enemycl.isSpy)
						{
							ChameleonPackImage::onDeactivate(%obj);
							schedule("ChameleonPackImage::onActivate("@%obj@");",0.5);
						}
						
					}
				}
			}
			deleteObject(%set);	
		}
		schedule("CheckSight("@%player@");",1);
	}

}
