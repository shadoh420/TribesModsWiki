//================================================================================ Invo Functions
function resupply(%this)
{
	if (GameBase::isActive(%this)) 
	{
		%player = Station::getTarget(%this);
		if (%player != -1) 
		{
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
				
			%client = Player::getClient(%player);
			
			if (%cnt != 0) 
			{
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client,0,"Resupply Complete");
			return 0;
		}
	}
	return 0;
}

function setupShoppingList(%client,%station,%ListType)
{
	Client::clearItemShopping(%client);
	%player = Client::getOwnedObject(%client);
	if(%client.possessing)
		%player = Client::getOwnedObject(%client.poss);
	%armor = Player::getarmor(%player);
	%max = getNumItems();
	
	if(%ListType == "InvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			
			if ($Shifter::ItemLimit)
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && ($ItemMax[%armor,%item] > 0 && $Shifter::ItemLimit) && ((%item.heading != "eDefensive" && %item.heading != "dDeployables" && %item.heading != "lArea Effect Items" && %item.heading != "uGuided Missiles") || $Shifter::DeathMatch == "false" || !$Shifter::DeathMatch))
				{
					Client::setItemShopping(%client, %item);
				}
				else if(%item.className == Armor && !%station.dontSell[%item] && (%item != DtmArmor || $Shifter::DeathMatch == true))  
				{
					Client::setItemShopping(%client, %item);
				}
			}
			else
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && ((%item.heading != "eDefensive" && %item.heading != "dDeployables" && %item.heading != "lArea Effect Items" && %item.heading != "uGuided Missiles") || $Shifter::DeathMatch == "false" || !$Shifter::DeathMatch))
				{
					Client::setItemShopping(%client, %item);
				}
				else if(%item.className == Armor && !%station.dontSell[%item] && (%item != DtmArmor || $Shifter::DeathMatch == true))  
				{
					Client::setItemShopping(%client, %item);
				}
			}
		}
	}
	if(%ListType == "DepList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if($DepList[%item] != "" && $DepList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}	
	else if(%ListType == "RemoteInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			
			if ($Shifter::ItemLimit)
			{			
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]  && ($ItemMax[%armor,%item] > 0 && $Shifter::ItemLimit)) 
					Client::setItemShopping(%client, %item);
			}
			else
			{
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
					Client::setItemShopping(%client, %item);
			}
	   	}
	}
	else if (%ListType == "VehicleInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
	else
		return;
}

function updateBuyingList(%client)
{
   	Client::clearItemBuying(%client);
	%player = Client::getOwnedObject(%client);
	if(%client.possessing)
		%player = Client::getOwnedObject(%client.poss);
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%energy = %station.Energy;
   		Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: " @ %energy );
	}
   	else
   	{
		%energy = $TeamEnergy[Client::getTeam(%client)];
		Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);
	}
	
	%armor = Player::getArmor(%player);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
      		if(!%item.showInventory)
      			continue;
      		
		if($ItemMax[%armor, %item] != "0" && Client::isItemShoppingOn(%client,%i))
		{
			%extraAmmo = 0;
			
			if(Player::getMountedItem(%player,$BackpackSlot) == ammopack)
				%extraAmmo = $AmmoPackMax[%item];
			
			//================================================================ Player Has Room For More Ammo
			if($ItemMax[%armor, %item] != "" && $ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))
			{
				//======================================================== Team Has Funds For Items
				if(%energy >= %item.price)
				{	
					//================================================ Can Armor Purache Item ?
					if($ItemMax[%armor,%item] > 0)
					{
						//================================================ Weapon
						if(%item.className == Weapon)
						{
							if(Player::getItemClassCount(%player,"Weapon") < $MaxWeapons[%armor])					
								Client::setItemBuying(%client, %item);
						}
						else
						{
							if((%item != "Mfglammo" && %item != "SuicidePack" && (%item != BooM || !$Shifter::HaVoCNuke)) || $Nukecount[GameBase::getTeam(%client)] < $Shifter::AllNukeLimit || $Shifter::LimitNukes == "false")
							{
								if($TeamItemMax[%item] != "")
								{						
									if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
										Client::setItemBuying(%client, %item);
								}
								else
									Client::setItemBuying(%client, %item);
							}
						}
					}
				}
		   	}
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i) && (%item != DtmArmor || $Shifter::DeathMatch == true))
		{
			Client::setItemBuying(%client, %item);
		}
		else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
		{
			Client::setItemBuying(%client, %item);
		}
	}
}