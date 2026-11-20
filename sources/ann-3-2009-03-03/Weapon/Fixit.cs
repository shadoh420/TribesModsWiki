$InvList[Fixit] = 1;
$MobileInvList[Fixit] = 1;
$RemoteInvList[Fixit] = 1;

$AutoUse[Fixit] = False;
$FixitSlot = 4;

// addWeapon(Fixit);

$FixitSlotA=4;

RepairEffectData SuperRepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 7.5;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

//modified by Plasmatic to work with admin
function SuperRepairBolt::onAcquire(%this, %player, %target)
{
	if($debug)
		echo("SuperRepairBolt::onAcquire, bolt="@%this@", player="@%player@", target="@ %target);	
	
	%client = Player::getClient(%player);
	%player.fixingDisabled = false;
	if(%target == %player) 
	{
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) 
		{
			%player.repairRate = 0.125;	//0.25
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else 
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else 
	{
		%player.repairTarget = %target;
		%player.repairRate = 0.50;
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else if(fixable(%player,%target))
		{
			%target.LastRepairCl =  %client; 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			if(GameBase::getTeam(%player)!= GameBase::getTeam(%target))
				%name = "enemy "@%name;
		}
		else 
		{
			%player.fixingDisabled = true;
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{			
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		
		//reset ownership 
		if(%target.NeedsNewOwner == true && Gamebase::getTeam(%target) == client::GetTeam(%client))
		{
			%name = GameBase::getDataName(%target).description;
			Client::sendMessage(%client,0,%name@": WOOHOO! I'm YOURS Baybeee!");	
			GameBase::playSound(%client, FWooho, 0);
			
			// Remote turrets - kill points to player that fix them
			client::setOwnedObject(%client, %target);
			%target.deployer = %client; 	//for destroy points, bk messages -plasmatic
			Client::setOwnedObject(%client, %player);
			$TurretList[%target] = %client;	//we're going to disable when client changes team or drops -plasmatic 2.2
			
			Gamebase::setMapName(%target, %name @"(" @ Client::getName(%client) @ ")");
			%target.NeedsNewOwner = false;
		}
		else		
			Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function SuperRepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) 
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Client::sendMessage(%client,0,"Repair Done");
				RepairRewards(%player);
			}
			else 
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function SuperRepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == Fixit && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if(GameBase::getDamageLevel(%player) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
			else if(GameBase::getLOSInfo(%player,1000))
			{
				%trans = "0 0 0 0 0 0 0 0 0 "@$los::position;
				Projectile::spawnProjectile("nanorepair", %trans, %player, "0 0 0");	
				
			}
		}
	}
}

ItemImageData FixitImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { -0.2, 0, 0 };
	mountRotation = { 0, -1.575, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit 
{
	description = "Builder Repair-Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = $InvHead[ihtool];	//$InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FixitImage;
	price = 50;
	showWeaponBar = true;
};

ItemImageData FixitImage2 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 1.575, 0};
	weaponType = 2;
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Fixit2
{
	description = "Builder's Repair-Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	//heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FixitImage2;
	showWeaponBar = true;
	showInventory = false;
	Price = 0;
};

//Plasmatic 2.2
function Fixit::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,Fixit2,$FixitSlotA);
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Repairs people or objects.");	
}

// We reward destoy points, why the crap not repairs? -Plasmatic 1/31/2005 4:35AM
// Hmm, we could give points for partial repairs also.. For when base is overrun with enemy,
// and we only want functionality, but that would require tracking damage..
function RepairRewards(%player)
{
	%object = %player.repairTarget;	
	if(%object != -1) 
	{	
		if(GameBase::getTeam(%player) == GameBase::getTeam(%object)) 
		{	
			%lastdamage = %object.lastDamageObject;
			%client = Player::getClient(%player);
			if(%lastdamage != %client)
			{
				%name = GameBase::getDataName(%object);	
				%class = %name.className;
				%data = %name.description;
					
			//	messageall(1,"N:"@ %name @", C:"@%class@", D:"@%data);
	
				if(%name == PulseSensor || %class == Generator || %class == Station || %class == Turret)
				{
					//give players a point if it's their teams, and they didnt damage it last.. 
					%client.score++;
					Game::refreshClientScore(%client);
					%player.repairTarget = "";	//no more points.. 
					
					return ", 1 point";
				}	
			}
			//they caused the damage... NO POINT FOR JOO!
		}
	}
	return;
}
