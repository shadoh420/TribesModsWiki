// This is a MiniMod Plugin.
// This is a "functions" patch for upgrading Tribes to MiniMod v.071 compliance.

function buyItem(%client,%item)
{
	%pack = Player::getMountedItem(%client,$BackpackSlot);
	%numsell = Player::getItemCount(%client, %item);
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	$tempBuyItem = %item;
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor)
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			%checkArmor = %buyarmor;
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1))
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
	     				Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack){ 
						fillAmmoPack(%client);
					}
					if(%checkArmor != tarmor)
					{
						Player::setItemCount(%client, JetfirePack, 0);
						Player::setItemCount(%client, TransAPCPack, 0);
						Player::setItemCount(%client, TransHAPCPack, 0);
					}
					if(%checkArmor != secrarmor)
					{
						Player::setItemCount(%client, ChangelingNet, 0);
						Player::setItemCount(%client, FusionGun, 0);
					}
					if(%checkArmor != SCVArmor)
					{
						Player::setItemCount(%client, SCVPack, 0);
						Player::setItemCount(%client, SCVGun, 0);
					}
					if(%checkArmor != specarmor)
					{
						Player::setItemCount(%client, SpecialistPack, 0);
					}
					if(%checkArmor != earmor || efemale)
					{
						Player::setItemCount(%client, Fixit, 0);
					}
					if(%buyarmor == secrarmor)
					{
						Player::setItemCount(%client, ChangelingNet, 1);
						Player::setItemCount(%client, FusionGun, 1);
						Player::setItemCount(%client, Beacon, 5);
					}
					if(%buyarmor == specrmor)
					{
						Player::setItemCount(%client, Beacon, 5);
						Player::setItemCount(%client, SlowGun, 1);
						Player::setItemCount(%client, SlowGunAmmo, 25);
						Player::setItemCount(%client, SpecialistPack, 1);
						Player::setItemCount(%client, Cloaker, 1);
						Player::setItemCount(%client, Concuss, 1);
						Player::setItemCount(%client, ConcussAmmo, 25);
						Player::setItemCount(%client, Beacon, 5);
					}
					if(%buyarmor == SCVArmor)
					{
						Player::setItemCount(%client, SCVPack, 1);
						Player::mountItem(%client, SCVPack, $BackpackSlot);
						Player::setItemCount(%client, SCVGun, 1);
						Player::mountItem(%client, SCVGun, $WeaponSlot);
						Player::setItemCount(%client, FusionGun, 0);
					}
					if(%buyarmor == tarmor)
					{
						Player::setItemCount(%client, JetfirePack, 1);
						Player::mountItem(%client, JetfirePack, $BackpackSlot);
						Player::setItemCount(%client, FusionGun, 1);
						Player::mountItem(%client, FusionGun, $WeaponSlot);
						Player::setItemCount(%client, Blaster, 1);
						Player::setItemCount(%client, EnergyRifle, 1);
						Player::setItemCount(%client, RepairKit, 2);
						Player::setItemCount(%client, Beacon, 5);
					}
					if (%buyarmor == jarmor) //================================================== Check Juggernaught   
					{

						echo("Purchased Juggernaught");
						checkMaxDrop(%client,%armor);
						
						//========================================================= Set Weapons
						Player::setItemCount(%client, RocketLauncher, 1);
						Player::setItemCount(%client, SMRPack2,1);
						Player::setItemCount(%client, Mortar,1);
						Player::setItemCount(%client, Mfgl,1);
						Player::setItemCount(%client, GrenadeLauncher,1);
						Player::setItemCount(%client, Vulcan,1);
						
						//========================================================= Set Ammo
						Player::setItemCount(%client, RocketAmmo,25);
						Player::setItemCount(%client, AutoRocketAmmo,20);
						Player::setItemCount(%client, MortarAmmo,20);
						Player::setItemCount(%client, MfglAmmo,3);
						Player::setItemCount(%client, GrenadeAmmo,30);
						Player::setItemCount(%client, VulcanAmmo,900);
							
						//========================================================= Mount Items
						Player::mountItem(%client, RocketLauncher, $WeaponSlot);
						Player::mountItem(%client, SMRPack2, $BackPackSlot);
						}
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack)
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						Player::decItemCount(%client,"LaserRifle");
						%gun=LaserRifle;
						teamEnergyBuySell(%player, %gun.price);
					}
					if(Player::getItemCount(%client,"LaserChaingun") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
						Player::decItemCount(%client,"LaserChaingun");
						%gun=LaserChaingun;
						teamEnergyBuySell(%player, %gun.price);
					}

				}	
				else if(%pack == EnergizerPack) {
					if(Player::getItemCount(%client,"RepairRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energizer Pack - Auto Selling Repair Rifle");
						remoteSellItem(%client,22);						
					}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) {
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
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					if(Player::getArmor(%client) != tarmor)
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				if(%item == LaserChaingun && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Chaingun - Auto buying Energy Pack");
				}
				if(%item == RepairRifle && Player::getItemCount(%client,"EnergizerPack") == 0) {
					buyItem(%client,"EnergizerPack");
					Client::sendMessage(%client,0,"Bought Repair Rifle - Auto buying Energizer Pack");
				}

				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle)
		{
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else if(%item.className == Grenade)
		{
			if(checkResources(%player,%item,1))
			{

				for(%i = 1; %i <= $Grenade[0]; %i++)
				{
					%g = $Grenade[%i];
					if(%item == %g) {}
					else
					{
						teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, %g));
						Player::setItemCount(%player, %g, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Grenade, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}

		}
		else if(%item.className == Mine)
		{
			if(checkResources(%player,%item,1))
			{
				for(%i = 1; %i <= $Mine[0]; %i++)
				{
					%m = $Mine[%i];
					if(%item == %m) {}
					else
					{
						teamEnergyBuySell(%player,%m.price * Player::getItemCount(%player, %m));
						Player::setItemCount(%player, %m, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,MineAmmo, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
		else if(%item.className == Tool)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == RealTargetingLaser)
				{
					teamEnergyBuySell(%player, TractorBeam.price * Player::getItemCount(%player, TractorBeam));
					Player::setItemCount(%player, TractorBeam, 0);
				}
				else if(%item == TractorBeam)
				{
					teamEnergyBuySell(%player, RealTargetingLaser.price * Player::getItemCount(%player, TargetingLaser));
					Player::setItemCount(%player, RealTargetingLaser, 0);
				}
				Player::incItemCount(%client, %item);
				teamEnergyBuySell(%player, (%item.price * -1));
				Player::setItemCount(%client, TargetingLaser, 1);
				return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "") {						
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

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats)
	{
		if(%item == shortEnergyRifle || %item == longEnergyRifle)
			%item = EnergyRifle;

		if(Player::getItemCount(%client,%item) && %item.className != Armor)
		{
			if(%item == EnergyRifle || %item == shortEnergyRifle || %item == longEnergyRifle)
				%client.justUsedELF = 0; //otherwise you get a new elf if you go to the inv with it mounted
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack)
			{
				if(Player::getItemCount(%client,"LaserRifle") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					Player::decItemCount(%client,"LaserRifle");
					%gun=LaserRifle;
					teamEnergyBuySell(%player, %gun.price);
				}
				if(Player::getItemCount(%client,"LaserChaingun") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
					Player::decItemCount(%client,"LaserChaingun");
					%gun=LaserChaingun;
					teamEnergyBuySell(%player, %gun.price);
				}

			}
			else if(%item == EnergizerPack)
			{
				if(Player::getItemCount(%client,"RepairRifle") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energizer Pack - Auto Selling Repair Rifle");
					Player::decItemCount(%client,"RepairRifle");
					%gun=LaserRifle;
					teamEnergyBuySell(%player, %gun.price);
				}
			}
			else if(%item.className == Grenade)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, Grenade, %numsell);
			}
			else if(%item.className == Mine)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, MineAmmo, %numsell);
			}
			else if(%item.className == JetfirePack)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, JetfirePack, %numsell);
			}
			else if(%item.className == SCVGun)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, SCVGun, %numsell);
			}
			else if(%item.className == SCVPack)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, SCVPack, %numsell);
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}

	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function MiniMod::resupply(%player)
{
}

function Station::itemsToResupply(%player)
{
	$resupply = %player;
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);
// MiniMod's support for ammo based weapons. Starting here.
MiniMod::Load("plugins\\*.resupply.cs");
// Ending here.

//	return %cnt;
}

