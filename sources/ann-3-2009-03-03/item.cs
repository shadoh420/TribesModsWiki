//----------------------------------------------------------------------------
// this is handled automatically now for 2.2 -plasmatic
//$ItemFavoritesKey = "Annihilation_2202";	// Change this if you add new items
						// and don't want to mess up everyone's
						// favorites - just put in something
						// that uniquely describes your new stuff.
						
//----------------------------------------------------------------------------
$InvHead[ihVeh] = "bVehicle";
$InvHead[ihArm] = "aArmor";
$InvHead[ihWea] = "cWeapons";
$InvHead[ihtool] = "dTools";
$InvHead[ihBac] = "eBackpacks";
$InvHead[ihSpl] = "gSpells";
$InvHead[ihMis] = "jMiscellany";
$InvHead[ihDSe] = "lSensors";
$InvHead[ihDOb] = "nObjects";
$InvHead[ihBar] = "pBarriers";
$InvHead[ihTur] = "rTurrets";
$InvHead[ihPwr] = "tPower Systems";
$InvHead[ihRem] = "vRemote Bases";
$InvHead[ihDro] = "xDrones";
$InvHead[ihAmm] = "zAmmunition";


//--------------------------------------
$InvList[RepairKit] = 1;
$MobileInvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;
AddItem(RepairKit);

$AutoUse[RepairKit] = false;

ItemData RepairKit 
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 35;
};

function RepairKit::onUse(%player,%item) 
{
		
	// handling this in function Armor::onRepairKit(%player)	
//	if(!$build)
//		Annihilation::decItemCount(%player,%item);
	// GameBase::repairDamage(%player,0.2);
	
	%c = Player::getClient(%player);
	 // Alliance armor support
	%armor = Player::getArmor(%player);
	eval(%armor @ "::onRepairKit(" @ %player @ ");");
}

function RepairKit::onCollision(%this,%object) 
{	
	if(getObjectType(%object) == "Player")
		Item::onCollision(%this,%object);
	else
	{
		// Throw a repair kit at some equiptment, and it will repair it. 
		// BAM! Plasmatic 3.x 1/31/2005 7:38AM
		if(GameBase::getDamageLevel(%object) != 0)
		{
	//		%name = GameBase::getDataName(%object);	
	//		%class = %name.className;
	//		%data = %name.description;		
	//		if(%name == PulseSensor || %class == Generator || %class == Station || %class == Turret)
	//		{		
				GameBase::repairDamage(%object,0.20);
				GameBase::playSound(%object, ForceFieldOpen,0);
				deleteobject(%this);
			}
	//	}
	}
	
}

ItemData RepairPatch 
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 2;
};

function RepairPatch::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);
	if(%object.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;
	if(getObjectType(%object) == "Player") 
	{
		if(GameBase::getDamageLevel(%object)) 
		{
			GameBase::repairDamage(%object,0.125);
			%c = Player::getClient(%object);
			$poisonTime[%c] = 0;
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item) 
{
	if(!$build)Annihilation::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}


//-----------------------------------------------------------------------------
$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

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

//$ArmorType[Male, LightArmor] = larmor;
//$ArmorType[Male, MediumArmor] = marmor;
//$ArmorType[Male, HeavyArmor] = harmor;
//$ArmorType[Female, LightArmor] = lfemale;
//$ArmorType[Female, MediumArmor] = mfemale;
//$ArmorType[Female, HeavyArmor] = harmor;

//$ArmorName[larmor] = LightArmor;
//$ArmorName[marmor] = MediumArmor;
//$ArmorName[harmor] = HeavyArmor;
//$ArmorName[lfemale] = LightArmor;
//$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
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
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";


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
	if($debug)
		echo("remote buy favorites");
	// only can buy fav every 1/2 second
	%time = getIntegerTime(true) >> 4; // int half seconds
	if(%time <= %client.lastBuyFavTime)
		return;
			
	%player = Client::getOwnedObject(%client);
	// player is dead, 2.2 fix -plasmatic
	if(%player == -1 || %client.observerMode != "")
		return;
	// cant buy favs if busy shooting or in ghost armor (ghost pack on)
	if(isPlayerBusy(%client) || %player.vehicle)
		return;
		
	if((Client::getGuiMode(%client) != $GuiModeInventory && !%Client.InvConnect) && !$build)
		return;

	// remount weapon after buying faves -Plas 3.0
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	Player::unmountItem(%player,$WeaponSlot);
	
	%armor = $ArmorName[Player::getArmor(%client)];

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
						Annihilation::setItemCount(%client, %item, 0);
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
			
		// remount weapon, ann 3.0
		// damnit, changing armors resets weapon reload vars, and player sometimes fires. -plasm
		//	if(Player::getItemCount(%client,%weapon))
		//		schedule("Player::useItem("@%client@","@%weapon@");",0.125);	
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
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if(Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) 
		{
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
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
	//yep.. uh huh... lets see who is doing this.. -Plasmatic 2.2 temp fix. 
//	if(%item == GhostArmor)
//	{	
//		%name = Client::getName(%client);
//		%ip = Client::getTransportAddress(%client);
//		$Cheater = %name @ " : Client ID : "@%client@" IP Address : "@ %ip @" Using GhostArmor Cheat.."; 
//		export("Cheater","config\\Cheater.log",true);		
//		echo($Cheater);
//		return;
//	}			
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
				%pos = GameBase::getPosition(%player);
				GameBase::setPosition(%player,"0 0 0");
				if(getlosInfo(vector::add(%pos,"0 0 "@(%armor.boxNormalHeight*0.1)),vector::add(%pos,"0 0 "@(%armor.boxNormalHeight*0.9)),1))	//!GameBase::testPosition(%player,%pos))
				{
					Client::sendMessage(%client,1,"~wfemale1.wno.wav");	//no more buying armor when clipping through terrain. 
					GameBase::setPosition(%player,%pos);
					return false;
				}
				GameBase::setPosition(%player,%pos);
				
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) 
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					GameBase::SetDamageLevel(%player,0); //fix all player damage
					Annihilation::setItemCount(%client, $ArmorName[%armor], 0);
					Annihilation::setItemCount(%client, %item, 1);

					// Auto buy pack, refined for 3.0
					if(%item == iarmorTroll)
						buyItem(%client,RegenerationPack);
					if(%item == iarmorSpy)
						buyItem(%client,ChameleonPack);
					if(%item == iarmorTank)
					{
						//auto buy weapons. plas 3.0 
						buyItem(%client,TBlastCannon);
						buyItem(%client,TRocketLauncher);
						buyItem(%client,TankRPGLauncher);
						buyItem(%client,TankShredder);	
						buyItem(%client,TankPack);		
					}						

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
				
				//No more selling expensive items at small deployable invs. -plasmatic
				if(Client::isItemShoppingOn(%client,%pack)) 
				{
					teamEnergyBuySell(%player,%pack.price);
					Annihilation::decItemCount(%client,%pack);
				}
				else
				{
					Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
					Player::dropItem(%client,%pack); // You can't sell but you can drop					
				}
			}
			if(checkResources(%player,%item,1) || $testCheats) 
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Annihilation::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) 
			{
				teamEnergyBuySell(%player,%pack.price * -1);
				Annihilation::incItemCount(%client,%pack);
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
				Annihilation::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem = %item.imageType.ammoType;
				if(%ammoItem != "") 
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) 
					{
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Annihilation::incItemCount(%client,%ammoitem,%delta);
						
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
				Annihilation::incItemCount(%client,%item,%delta);
							
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
	if(%armor == iarmorNecro)
		NecroSight(%player);
		
	// rotation fix 3.x Plasmatic 2/4/2007 4:06AM
	GameBase::setRotation(%player,"0 0 "@getword(GameBase::getRotation(%player),2));
}

function remoteBuyItem(%client,%type)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%type = Ann::Clean::string(%type);
		
	%player = client::getownedobject(%client);

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
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%type = Ann::Clean::string(%type);
		
	if(isPlayerBusy(%client))
		return;

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

			teamEnergyBuySell(%player,%item.price * %numsell);
			Annihilation::setItemCount(%player,%item,(%count-%numsell));
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

	if(!evalspam(%client))
		return;	//plasm 3.0
		
	%type = Ann::Clean::string(%type);
			
	%station = (Client::getOwnedObject(%client)).Station;
	%vehicle = (Client::getOwnedObject(%client)).vehicle;
	%item = getItemData(%type);
	if($debug)
		echo(%player@" "@%type@" "@%item@" station,"@%station@" vehicle,"@%vehicle);
		
	// weapon options- putting 'use blaster' and 'use laser' to work 
	// since we dont have those weapons in Annihilation -Plasmatic			
	if(%item == Blaster)
	{
		Weapon::Mode(%player,1);
		return;
	}
	if(%item == LaserRifle)
	{
		Weapon::Mode(%player,-1);
		return;
	}	
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
	if(!evalspam(%client))
		return;	//plasm 3.0
		
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
		else if(%item == RepairKit)
		{	
			Player::dropItem(%client,%item);
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
	if(!evalspam(%client))
		return;	//plasm 3.0		
	%type = Ann::Clean::string(%type);
		
	 //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}



function remoteNextWeapon(%client)
{		
	if($debug)
		echo("remoteNextWeapon"@ Client::getControlObject(%client)@ " owned "@Client::getOwnedObject(%client)@" is observer= "@Observer::isObserver(%client));
	
	if($loadingMission)//2.2 -plasmatic
		return;

	if(%client.InSchool)
	{
		if(%client.InSchool < 8)
		{
			%client.InSchool++;
			NewbieSchool(%client);
			return;
		}
		else 
		{
			%clientId.weaponHelp = true;
			centerprint(%client,"",0);	
			if(%client.observerMode == "justJoined")
				Observer::triggerDown(%client);
			else
				%client.InSchool = "";	
				
			return;					
		}
	}

	if(%client.observerMode == dead || %client.observerMode == justJoined || %client.observerMode == observerFly) return;

	// toggle distance for obs -plasmatic
	if(%client.observerMode == "observerOrbit" || %client.observerMode == "observerAdmin")
	{
			%client.obsmode += 1;
			if(%client.obsmode >= 6)
				%client.obsmode = "";	
			if($debug)
				echo("toggle obsmode "@%client@" to "@%client.obsmode);
				
			Observer::setAnnihilationOrbit(%client, %client.observerTarget);
			return;		
	}
	//Vehicle Maddenes. 10/14/2007 6:46AM -Plasmatic	
	else if(getObjectType(Client::getControlObject(%Client)) != "Player")
	{
		
		// get money fuck bitches
		// in a vehicle
		
	}
	//end toggle, start weapon change
	else
	{

		%player = Client::getOwnedObject(%client);		
		%item = Player::getMountedItem(%client,$WeaponSlot);					
		%player.invulnerable = "";
		// remove invulnerability when player selects weapon.	
		
		if(%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
			
		else
		{
			for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
			{
				if(isSelectableWeapon(%client,%weapon))
				{
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if(Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;	
				}
			}			
		}
	}
}
	
function remotePrevWeapon(%client)
{		
	if($loadingMission || %client.observerMode == dead || %client.observerMode == justJoined || %client.observerMode == observerFly)//2.2 -plasmatic
		return;	
	
	//Vehicle Maddenes. 10/14/2007 6:46AM -Plasmatic	
	else if(getObjectType(Client::getControlObject(%Client)) != "Player")
	{
		
		// get money fuck bitches
		// in a vehicle
		
	}
	else
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if(%item == -1 || $PrevWeapon[%item] == "")
			selectValidWeapon(%client);
		else
		{
			for(%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
			{
				if(isSelectableWeapon(%client,%weapon))
				{
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if(Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;
				}
			}
		}
	}
}

function selectValidWeapon(%client)
{
	//%item = EnergyRifle;
	if(isSelectableWeapon(%client,$FirstWeapon))
	{
		//	3.0 fix for no mount first weapon -Plasmatic
		Player::useItem(%client,$FirstWeapon);
		return;
	}
		
	%item = $FirstWeapon; 
	for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
	{
		if(isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon))
	{
		%ammo = $WeaponAmmo[%weapon];
		if(%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}


//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item])
	{
		%client = Player::getClient(%player);
		%description = %item.description;
		if(%item.className == Backpack)
		{
			// Only one backpack per armor, and it's always mounted
			if(Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
				Annihilation::incItemCount(%player,%item);
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
				if(Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
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
				Annihilation::incItemCount(%player,%item,%delta);
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
	if(%object.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;
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
	if(%item.className == Weapon || %item.className == Tool) 
	{
		Weapon::CompleteMount(%player,%item); 	// Handled here for sweet, sweet lovin'  -Plasmatic 3.0	
	}	
}

function Item::onUnmount(%player,%item)
{
	// Eliminating child functions for multi image weapons.. -Plasmatic 3.0
	if(%item.className == Weapon) 
	{	
		for(%i = 4; %i<8; %i++)
		{
			if((Player::getMountedItem(%player,%i)).className == Weapon) 	
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
			
		Annihilation::decItemCount(%player,%item,1);
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
	//className = "mine";
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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
// The rest of Ammo moved to misc folder. -Plasm 3.x
ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

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
						GameBase::setRechargeRate(%this,5);	// Plasmatic 2/4/2008 1:32AM
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
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
		//Annihilation::setItemCount(%clientId,Blaster,1);
		Annihilation::setItemCount(%clientId,Chaingun,1);
		Annihilation::setItemCount(%clientId,PlasmaGun,1);
		Annihilation::setItemCount(%clientId,GrenadeLauncher,1);
		Annihilation::setItemCount(%clientId,DiscLauncher,1);
		//Annihilation::setItemCount(%clientId,LaserRifle,1);
		Annihilation::setItemCount(%clientId,EnergyRifle,1);
		Annihilation::setItemCount(%clientId,TargetingLaser,1);
		Annihilation::setItemCount(%clientId,Mortar,1);

		Annihilation::setItemCount(%clientId,BulletAmmo,200);
		Annihilation::setItemCount(%clientId,PlasmaAmmo,200);
		Annihilation::setItemCount(%clientId,GrenadeAmmo,200);
		Annihilation::setItemCount(%clientId,DiscAmmo,200);
		Annihilation::setItemCount(%clientId,MortarAmmo,200);

		Annihilation::setItemCount(%clientId,Grenade, 200);
		Annihilation::setItemCount(%clientId,MineAmmo, 200);
		Annihilation::setItemCount(%clientId,Beacon, 200);

		Annihilation::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats)
	{
		%armor = Player::getArmor(%clientId);
		Annihilation::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Annihilation::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Annihilation::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Annihilation::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Annihilation::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

		Annihilation::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
		Annihilation::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Annihilation::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Annihilation::setItemCount(%clientId,RepairKit,1);
	}
}


//----------------------------------------------------------------------------


function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if(%numweapon > $MaxWeapons[%armor])
	{
		%weaponflag = %numweapon - $MaxWeapons[%armor];
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
				Annihilation::setItemCount(%client, %item, %count - %numsell);
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


//Hijacking these 3 functions for BabyNuke. -Plasmatic
function Annihilation::incItemCount(%client,%item,%count)
{
	if($debug)
		echo("incItemCount "@%client@", "@%item@", "@%count);		
	if(!%count)
		%count = 1;
	player::incItemCount(%client,%item,%count);
	
}

function Annihilation::decItemCount(%client,%item,%count)
{
	if($debug)
		echo("decItemCount "@%client@", "@%item@", "@%count);			
	if(!%count)
		%count = 1;		
	player::decItemCount(%client,%item,%count);
	
}

function Annihilation::setItemCount(%client,%item,%count)
{
	if($debug)
		echo("setItemCount "@%client@", "@%item@", "@%count);			
	player::setItemCount(%client,%item,%count);
	
}