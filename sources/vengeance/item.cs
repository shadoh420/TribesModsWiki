//----------------------------------------------------------------------------
// this is handled automatically now for 2.2 -plasmatic
//$ItemFavoritesKey = "Annihilation_2202";	// Change this if you add new items
						// and don't want to mess up everyone's
						// favorites - just put in something
						// that uniquely describes your new stuff.
						
//----------------------------------------------------------------------------

$InvHead[ihArm] = "aArmor";

$InvHead[ihVeh] = "bVehicle";

$InvHead[ihWea] = "cWeapons";
$InvHead[ihtool] = "dTools";
$InvHead[ihBac] = "eBackpacks";

$InvHead[ihSpl] = "gSpells";

$InvHead[ihMis] = "jMiscellany";

$InvHead[ihDSe] = "lSensors";
$InvHead[ihDSm] = "mSmall Deployables";
$InvHead[ihDOb] = "nObjects";
$InvHead[ihDLd] = "oLarge Deployables";
$InvHead[ihBar] = "pBarriers";

$InvHead[ihTur] = "rTurrets";

$InvHead[ihPwr] = "tPower Systems";

$InvHead[ihRem] = "vRemote Bases";
$InvHead[ihDro] = "xDrones";
$InvHead[ihAmm] = "zAmmunition";


//--------------------------------------


//-----------------------------------------------------------------------------
$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$SpareSlot1 = 4;
$SpareSlot2 = 5;
$SpareSlot3 = 6;
$SpareSlot4 = 7;

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;

$Use[Blaster] = True;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 0;	//5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;


// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[TransportPack] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;

// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
	bmpName[0] = "dobj1_object";
	bmpName[1] = "dobj2_object";
	bmpName[2] = "dobj3_object";
	bmpName[3] = "dobj4_object";
	bmpName[4] = "dobj5_object";
	bmpName[5] = "dobj6_object";
	bmpName[6] = "dobj7_object";
	bmpName[7] = "dobj8_object";
	bmpName[8] = "dobj9_object";
	bmpName[9] = "dobj10_object";
};

// Weapon to ammo table


//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling	 IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station);
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%station.Energy += %cost; //Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite")
	{
		$TeamEnergy[%team] += %cost; //Total TeamEnergy
 		%client.teamEnergy += %cost; //Personal TeamEnergy
	}
}

function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	// only can buy fav every 1/2 second
	%time = getIntegerTime(true) >> 4; // int half seconds
	if(%time <= %client.lastBuyFavTime)
		return;
			
	%player = Client::getOwnedObject(%client);
	// player is dead, 2.2 fix -plasmatic
	if(%player == -1 || %client.observerMode != "")
		return;
	// cant buy favs if busy shooting or in vehicle
	if(isPlayerBusy(%client) || %player.vehicle)
		return;
		
	if((Client::getGuiMode(%client) != $GuiModeInventory && !%Client.InvConnect) && !$build)
		return;


	%client.lastBuyFavTime = %time;
		%player = Client::getOwnedObject(%client);	//quick inv code -plasmatic
	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" || $build || $Annihilation::QuickInv || %Client.InvConnect) 
	{
		%stationName = GameBase::getDataName(%station);
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0 || $build || $Annihilation::QuickInv || %Client.InvConnect)
		{
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for(%i = 0; %i < %max; %i = %i + 1) 
			{ 
				%item = getItemData(%i);
				//%item = $Itemlist[%i];
				if($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats || $build || $Annihilation::QuickInv || %Client.InvConnect) 
				{
					%count = Player::getItemCount(%client,%item);
					if(%count && %item != flag) 
					{
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);
					}
				}
			}
			for(%i = 0; %i < 20; %i++) 
			{ 
				if(%favItem[%i] != "") 
				{
					%item = getItemData(%favItem[%i]);
					if((Client::isItemShoppingOn(%client,%item) || $build || $Annihilation::QuickInv || %Client.InvConnect) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor))
					{
						if(!buyItem(%client,%item))
							%error = 1;
						else
							%bought++;
					}
				}
			}
			if(%bought) 
			{
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}


function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage)
{
	if($debug)
		echo("checkResources( "@%player@", "@%item@", "@%delta@", "@%noMessage);
		
	%client = Player::getClient(%player);
	
	// player is dead, 2.3 fix -plasmatic
	if(%player == -1 || %client.observerMode != "")
		return;	
	%team = Client::getTeam(%client);
	%extraAmmo = 0;
	if(Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
	{
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
//	//plasmatic
//	if(Player::getMountedItem(%client,$BackpackSlot) == BuilderPack && $BuilderPackMax[%item] != "") 
//	{
//		%extraAmmo = $BuilderPackMax[%item];
//		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
//			%delta = %delta + %extraAmmo;
//	}
	if($TestCheats == 0) 
	{
		%energy = $TeamEnergy[%team];
		%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") 
		{
			if(%item.price * %delta > %energy)	
				%delta = %energy / %item.price;
			if(%delta < 1 ) 
			{
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon) 
	{
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if(Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%basearmor]) 
		{
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
	}
	// Vengeance mod HandDeployable class. 
	else if(%item.className == HandDeployable) 
	{
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		%tcount = Player::getItemClassCount(%client,"HandDeployable");
		if(Player::getItemClassCount(%client,"HandDeployable") >= $MaxHandDeployable[%basearmor]) 
		{
			Client::sendMessage(%client,0,"To many Deployables for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
	}	
	
	else if(%item.className == Tool) 
	{
		%armor = Player::getArmor(%client);
		%tcount = Player::getItemClassCount(%client,"Tool");
		if(Player::getItemClassCount(%client,"Tool") >= $MaxTool[%basearmor]) 
		{
			Client::sendMessage(%client,0,"To many Tools for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
	}	
	else if(%item == RepairPatch) 
	{
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
	}
	else if($TeamItemMax[%item] != "" && !$TestCheats  && !$build) 
	{
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) 
		{
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle) 
	{
		%count = Player::getItemCount(%client,%item);
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	if($debug)
		echo("buyItem("@%client@","@%item@")");			
	%player = Client::getOwnedObject(%client);

	// player is dead, 2.3 fix -plasmatic
	if(%player == -1 || %client.observerMode != "")
		return;		
	
	%armor = Player::getArmor(%client);
	updateBuyingList(%client);
	if(%armor == "harmor1" || %armor == "harmor2" || %armor == "harmor3" || $ArmorName[%armor] == GhostArmor)
		return;
//	if((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle)) 
//	{

	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %Client.InvConnect || $Annihilation::QuickInv || $build) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) 
	{

		if(%item.className == Armor && !%player.vehicle) 
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) 
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					GameBase::SetDamageLevel(%player,0); //fix all player damage
					Player::setItemCount(%client, $ArmorName[%armor], 0);
					Player::setItemCount(%client, %item, 1);

					// Item trickery.. -Plasmatic
				//	if(%item == EnergyBlade)
				//		Player::setItemCount(%client, TargetingLaser, 1);
						
				//	if(%item == iarmorSpy)
				//		buyItem(%client,ChameleonPack);
				//	if(%item == iarmorTank)
				//	{
				//		//auto buy weapons. plas 3.0 
				//		buyItem(%client,TBlastCannon);
				//		buyItem(%client,TRocketLauncher);
				//		buyItem(%client,TankRPGLauncher);
				//		buyItem(%client,TankShredder);		
				//	}						

					if(Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);
					if($Annihilation::ShoppingList && %client.invo)
						setupShoppingList(%client,%client.invo,%client.ListType); // armor based list
					if($build || $Annihilation::QuickInv || %Client.InvConnect)	//quick invs -plasmatic
						setupQuickShoppingList(%client); 

					return 1;
				}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if(%item.className == Backpack) 
		{
			if($TeamItemMax[%item] != "" && !$build)
			{
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
				return 0;
			}
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if(%pack != -1) 
			{
				if(%pack == ammopack) 
					checkMax(%client,%armor);
			//	else if(%pack = BuilderPack) 
			//		checkMax(%client,%armor);					
				else if(%pack == EnergyPack) 
				{
					//if(Player::getItemCount(%client,"LaserRifle") > 0) 
					//{
					//	Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					//	remoteSellItem(%client,22);
					//}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}
			if(checkResources(%player,%item,1) || $testCheats) 
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) 
			{
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) 
		{
			if(checkResources(%player,%item,1)) 
			{
				//if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) 
				//{
				//	buyItem(%client,"EnergyPack");
				//	Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				//}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem = %item.imageType.ammoType;
				if(%ammoItem != "") 
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) 
					{
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
		else if(%item.className == Vehicle) 
		{
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) 
			{
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) 
				{
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}
				else if(%shouldBuy == 2)
					return 1;
			}
		}		
		else 
		{
			if($TeamItemMax[%item] != "" && !$build) 
			{	
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
				return 0;
			}
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) 
			{
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
	}
	return 0;
}

function armorChange(%client)
{
	$shieldTime[%client] = "";
	$cloakTime[%client]  = "";
	%player = Client::getOwnedObject(%client);
	%armor = $ArmorName[Player::getArmor(%Player)];
	if(%client.respawn == "" && %player.Station != "") 
	{
		
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);
		%newPosX = (getWord(%vec,0) * 1) + %posX;
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
//	if(%armor == iarmorNecro)
//		NecroSight(%player);
}

function remoteBuyItem(%client,%type)
{
	%player = client::getownedobject(%client);

//	if(!%type.showInventory)
//	{
//		Client::sendMessage(%client,1,"No way are you getting a "@(%type.description)@"!~waccess_denied.wav");
//		return;
//	}
// handling this in inv screen toggle now... -plasmatic
//	if(!%player.Station)
//	{
//		Client::sendMessage(%client,1,"You must be at an Inventory Station to buy items.~waccess_denied.wav");
//		return;
//	}
	
	if(isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(buyItem(%client,%item)) 
	{
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	if(isPlayerBusy(%client))
		return;
//	if(!%type.showInventory)
//	{
//		Client::sendMessage(%client,1,"No way are you selling a "@(%type.description)@"!~waccess_denied.wav");
//		return;
//	}
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	
	// player is dead, 2.3 fix -plasmatic
	if(%player == -1 || %client.observerMode != "")
		return;		
	if(Client::isItemShoppingOn(%client,%item)) 
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor) 
		{
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) 
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count;
				else 
					%numsell = $SellAmmo[%item];
			}
			else if(%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") 
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack) 
			{ 
				//if(Player::getItemCount(%client,"LaserRifle") > 0) 
				//{
				//	Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
				//	remoteSellItem(%client,22);
				//}
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
	remoteDropItem(%client,%type); // You can't sell but you can drop
}

//plasmatic
$WaitThrowTime = 2;
function remoteUseItem(%player,%type)
{
	%client = Player::getClient(%player);
	%station = (Client::getOwnedObject(%client)).Station;
	%vehicle = (Client::getOwnedObject(%client)).vehicle;
	%item = getItemData(%type);
	
	
	if($debug)
		echo(%player@" "@%type@" "@%item@" station,"@%station@" vehicle,"@%vehicle);
		
	if(%item == beacon)
	{
		//calling this here so we don't need to have any.. always will work -Plasmatic V mod. 
		Beacon::onUse(%player);
		return;
	}
	// weapon options- putting 'use blaster' and 'use laser' to work 
	// since we dont have those weapons in Annihilation -Plasmatic			
	if(%item == TargetingLaser)
	{
		if(Player::getItemCount(%player,EnergyBlade)>0)
		{
			Player::mountItem(%player,EnergyBlade,$WeaponSlot);
			bottomprint(Player::getclient(%player), "<jc>Energy Blade: <f2>It's better than nothing.");
		}
	}

//	if(%item == LaserRifle)
//	{
//		Weapon::Mode(%player,-1);
//		return;
//	}	
	// end weap options.	
		
	//plasmatic
	if(%Station && getItemData(%type) != "RepairKit")
	{
		Client::sendMessage(%client,0,"Sun Tzu Says NO! ~waccess_denied.wav");
		return;
	}
	
	if($debug) 
		echo(%client@" Use item: " @ %type @ " " @ %item@" guimode "@Client::getGuiMode(%client));

	%client.throwStrength = 1;

	if(%item == "Backpack") 
	{		
		//plasmatic		
		if (Client::getGuiMode(%client) == $GuiModeInventory)
			Client::sendMessage(%client,0,"Sun Tzu Says NO! ~waccess_denied.wav");
		else 
			%item = Player::getMountedItem(%client,$BackpackSlot);
		}
	else
	{
		if(%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	if(%item.className == Backpack)// inventory use button -plas
	{
		if(%client != GameBase::getControlClient(%player))
		{
			//were controling something besides a player here, turret, obs turret, vehicle -Plasmatic			
			%object = Client::getControlObject(%client);
			if(%vehicle)
				vehicle::jump(%object,"0 0 100");
		}
	}
	Player::useItem(%client,%item);
}


function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime())
	{
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") 
		{
			//if(GameBase::getControlClient(%player) != -1)
			//{
			//echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if(%item == Grenade || %item == MineAmmo) 
			{
				if(%strength < 0)
					%strength = 0;
				else
					if(%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1 && !%client.ThrowWait)
	{
		%client.throwStrength = 1;
		%item = getItemData(%type);
		if($debug)
			echo(" remote Drop item: ",%client,%type,%item);
		
		if(%item == Backpack)
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
		else if(%item == Weapon)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if(%item == Ammo)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon)
			{
				%item = %item.imageType.ammoType;
				if($debug) 
					echo("ammo type =",%item);
				if(%item != "")
					Player::dropItem(%client,%item);	//no ammo for energy type weapons.. plasmatic 2.2
			}
		}
//		else if(%item == Flag)
//		{	
//			Player::dropItem(%client,%item);
//		}	
		else
			Player::dropItem(%client,%item);
	
		if(%client.InvConnect)
		{	
			%client.ThrowWait = true;
			schedule(%client@".ThrowWait = false;",0.25);		
		}
	}	
	
}


addAmmo("", RepairKit, 1);


function remoteDeployItem(%client,%type)
{
	 //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}



//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	%baseArmor = $ArmorName[%armor];
	if($ItemMax[%armor, %item])
	{
		%client = Player::getClient(%player);
		%description = %item.description;
		if(%item.className == Backpack)
		{
			// Only one backpack per armor, and it's always mounted
			if(Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
				Player::incItemCount(%player,%item);
				Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %description @ " backpack");
				return 1;
			}
		}
		else
		{
			// Check num weapons carried by player can't have more then max
			if(%item.className == Weapon)
			{
				if(Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%basearmor]) 
					return 0;
			}
			%extraAmmo = 0;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if(%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if(%delta > 0)
			{
				Player::incItemCount(%player,%item,%delta);
				if(%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %description);
				return %delta;
			}
		}
	}
	return 0;
}


//----------------------------------------------------------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if(%sound != "")
		playSound(%sound,GameBase::getPosition(%this));
	else 
	{
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if(Item::isRotating(%this)) 
	{
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else 
	{ 
		deleteObject(%this);
	}
}	

function Item::onAdd(%this)
{
	if($debug)echo("Item::onAdd(%this) "@%this);
	$item::count += 1;
	if($debug)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function Item::onRemove(%this)
{
	$item::count -= 1;
	if($debug)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function Item::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	if(getObjectType(%object) == "Player") 
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


//----------------------------------------------------------------------------
// Default Inventory methods

// Remember kiddies. This function calls Weapon::CompleteMount for ALL weapon type items:
// This may cause problems if the second item mounted is also a weapon type.
// set $Console::LogMode = "1"; and $Console::printLevel = "2"; somewhere to check for redundant retardedness.
// -Plasmatic, Vengeance mod
function Item::onMount(%player,%item)
{
	// Only called for item mounts not defined elsewhere.. 
	// Weapon help is now being handled through Weapon::CompleteMount -Plasmatic 3.0
	if($debug)
		echo("?? EVENT mount "@ %item @", "@%item.description@", "@%item.className@", on player "@ %player @" cl# "@ Player::getclient(%player));

	%client = Player::getClient(%player);
	if(%item.className == Backpack && %client.weaponHelp) 
	{
		bottomprint(%client, "<jc>" @ %item.description , 15);	// 2.2 
	}
	if(%item.className == Weapon) 
	{
		Weapon::CompleteMount(%player,%item); 	// Handled here for sweet, sweet lovin'  -Plasmatic 3.0	
	}	
}


function Item::onUnmount(%player,%item)
{
	if($debug)
		echo("item::unmount "@%item.className);
		
	// Eliminating child functions for multi image weapons.. -Plasmatic 3.0
//	%client = Player::getclient(%player);
//	%mounted = Player::getMountedItem(%client,$WeaponSlot);	

	if(%item.className == Weapon)		//if(%item == %mounted)
	{			
		for(%i = 4; %i<8; %i++)
		{
			%class = (Player::getMountedItem(%player,%i)).className;
			if(%class == Weapon || %class == HandDeployable || %class == EyeCandy) 	
				Player::unmountItem(%player,%i);
		}			
	}	
}

function Item::onUse(%player,%item)
{
	if($debug)
		echo("?? EVENT use "@ %item @", "@%item.hudIcon@" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,%item,$DefaultSlot);	
}

function Item::pop(%item)
{
	schedule(%item@".count = false;",2.3);
	schedule(%item@".type = false;",2.3);
 	GameBase::startFadeOut(%item);
	schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
//Made this function alot more flexable -Plasmatic
	if($matchStarted) 
	{
		if(%item.className != Armor) 
		{
			if($debug)
				echo("Item dropped: ",%player," ",%item);

			%obj = newObject("","Item",%item,1,false);	//false
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
		
		if (Player::isDead(%player)) 
			GameBase::throw(%obj,%player,10,true);
		else 
		{
			if(GameBase::getEnergy(%player) < 4 || %Player.rThrow && !%player.rThStr)
				GameBase::throw(%obj,%player,5,true);
			else if(GameBase::getEnergy(%player) < 4 || %Player.rThrow && %player.rThStr)
				GameBase::throw(%obj,%player,%player.rThStr,true);	 			
			else GameBase::throw(%obj,%player,15,false);
			Item::playPickupSound(%obj);
		}
			
		Player::decItemCount(%player,%item,1);
		return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}


//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}


//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType = 2; // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	validateShape = true;
	lightType = 2; // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2; // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};




function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++)
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function checkDeployArea(%client,%pos)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client)
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}

//	to allow for deploying some items on platforms
function checkInvDeployArea(%client,%pos)
{
	if($build)return 1;
	
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType |$ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1) 
	{
		%obj = Group::getObject(%set,0);
		if(getObjectType(Group::getObject(%set,0)) == "Player")
		{		
			if(Player::getClient(%obj) == %client)
				Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
			else
				Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
		}
		else
		{
			if(GameBase::getDataName(%obj) == "DeployablePlatform")
			{
				deleteObject(%set);
				return 1;
			}
			else 
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}

//----------------------------------------------------------------------------
// Remote deploy for items
// pulse sensor and sensor jammer are the only items still using this -plasmatic
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if(($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) || $build)
	{
		if(GameBase::getLOSInfo(%player,3))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object				
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if(Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%sensor = newObject("","Sensor",%shape,true);
						
						%sensor.cloakable = true;
						addToSet("MissionCleanup/deployed/sensor", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundThrowItem,$los::position);//playSound(SoundPickupBackpack,$los::position);
						if(!$build)
							echo("MSG: ",%client," deployed a ",%name);
	
						%obj = $los::object;
						if(%obj.inmotion == true)	 
						{ 
							schedule("replaceSensor("@%sensor@");",5);
						}	
							
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
// function to replace sensors deployed on moving drop ships
// so they collide and render properly -Plasmatic

function replaceSensor(%sensor)
{
	%pos = GameBase::getPosition(%sensor);
	if(%pos != "0 0 0")
	{
		%rot =GameBase::getRotation(%sensor);
		%type = getObjectType(%sensor);
		%shape = GameBase::getDataName(%sensor);
		%newsensor = newObject("",%type,%shape,true);
		
		%newsensor.cloakable = %sensor.cloakable;
		addToSet("MissionCleanup/deployed/sensor", %newsensor);
		GameBase::setTeam(%newsensor,GameBase::getTeam(%sensor));
		GameBase::setPosition(%newsensor,%pos);
		GameBase::setRotation(%newsensor,%rot);
		Gamebase::setMapName(%newsensor,gamebase::getmapname(%sensor));
		deleteObject(%sensor);
		echo("sensor replaced");

	}
	
	
}



//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if($TestCheats)
	{
		//Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		//Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
//		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
	//	Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

		Player::setItemCount(%clientId,Grenade, 200);
		Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon, 200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats)
	{
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

		Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
		Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}


//----------------------------------------------------------------------------


function checkMax(%client,%armor)
{
	%baseArmor = $ArmorName[%armor];
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if(%numweapon > $MaxWeapons[%basearmor])
	{
		%weaponflag = %numweapon - $MaxWeapons[%basearmor];
	}
	%max = getNumItems();
	for(%i = 0; %i < %max; %i = %i + 1)
	{
		
		%item = getItemData(%i);
		//echo("checkmax "@%item);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "")
		{
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{
				%numsell = %count - %maxnum;
			}
			if(%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
				Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);
				updateBuyingList(%client);
			}
		}
	}
}

function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	
