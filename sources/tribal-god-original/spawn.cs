function SpawnBuyList(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	
	if(%clientId.spawnType == "larmor")
	{
		// Armor:
		$spawnBuyList[%clientId, 0]   = LightArmor;
		// Misc.
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = Tunneler;
		$spawnBuyList[%clientId, 6] = RepairKit;
		$spawnBuyList[%clientId, 7] = TG::ClayMorMineAmmo;
		
		$spawnBuyList[%clientId, 8] = Blaster;
		$spawnBuyList[%clientId, 9] = MineLauncher;
		$spawnBuyList[%clientId, 10] = TRocketLauncher;
		$spawnBuyList[%clientId, 11] = DiscLauncher;
		$spawnBuyList[%clientId, 12] = TankShredder;
		$spawnBuyList[%clientId, 13] = PlasmaCannon;
		$spawnBuyList[%clientId, 14] = LiLffb;
		$spawnBuyList[%clientId, 15] = Mortar;
		$spawnBuyList[%clientId, 16] = LiLPOOmkii;
		$spawnBuyList[%clientId, 17] = LiLPOOmki;
		$spawnBuyList[%clientId, 18] = DoublePlasma;
		return;
	}
	else if(%clientId.spawnType == "marmor")
	{
		// Armor:
		$spawnBuyList[%clientId, 0]   = MediumArmor;
		
		// Misc.
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = MineLauncher;
		$spawnBuyList[%clientId, 7] = TG::ClayMorMineAmmo;
		
		$spawnBuyList[%clientId, 8] = Blaster;
		$spawnBuyList[%clientId, 9] = TRocketLauncher;
		$spawnBuyList[%clientId, 10] = DiscLauncher;
		$spawnBuyList[%clientId, 11] = TankShredder;
		$spawnBuyList[%clientId, 12] = PlasmaCannon;
		$spawnBuyList[%clientId, 13] = LiLffb;
		$spawnBuyList[%clientId, 14] = Mortar;
		$spawnBuyList[%clientId, 15] = LiLPOOmkii;
		$spawnBuyList[%clientId, 16] = LiLPOOmki;
		$spawnBuyList[%clientId, 17] = DoublePlasma;
		return;
	}
	else if(%clientId.spawnType == "harmor")
	{
		// Armor:
		$spawnBuyList[%clientId, 0]   = MediumArmor;
		
		// Misc.
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = MineLauncher;
		$spawnBuyList[%clientId, 7] = TG::ClayMorMineAmmo;
		
		$spawnBuyList[%clientId, 8] = DetPackLauncher;
		
		$spawnBuyList[%clientId, 9] = TRocketLauncher;
		$spawnBuyList[%clientId, 10] = DiscLauncher;
		$spawnBuyList[%clientId, 11] = TankShredder;
		$spawnBuyList[%clientId, 12] = PlasmaCannon;
		$spawnBuyList[%clientId, 13] = TankRPGLauncher;
		$spawnBuyList[%clientId, 14] = Mortar;
		$spawnBuyList[%clientId, 15] = LiLPOOmkii;
		$spawnBuyList[%clientId, 16] = LiLPOOmki;
		$spawnBuyList[%clientId, 17] = DoublePlasma;
		return;
	}
	else if(%clientId.spawnType == "Favs")
	{
		%armor = Player::getArmor(Client::getOwnedObject(%clientId));
		for(%x = 0; %fav = ($FavsBuyList[%clientId, %x]) != ""; %x++)
		{
			if(%fav != "LightArmor" && %fav != "MediumArmor" && %fav != "HeavyArmor")
			{ BuyItem(%player, %fav); }
			else
			{
				Echo(%fav.classname);
				if(%fav == "LightArmor")
				{ %newFav = larmor; } 
				else if(%fav == "MediumArmor")
				{ %newFav = marmor; }
				else if(%fav == "HeavyArmor")
				{ %newFav = harmor; }
				remoteSetArmor(%player, %newFav);
			}
		}
		return;
	}
	else
	{
		// Armor:
		$spawnBuyList[%clientId, 0]   = LightArmor;
		
		// Misc.
		$spawnBuyList[%clientId, 1] = RepairPack;
		$spawnBuyList[%clientId, 2] = MineAmmo;
		$spawnBuyList[%clientId, 3] = Beacon;
		$spawnBuyList[%clientId, 4] = Grenade;
		$spawnBuyList[%clientId, 5] = RepairKit;
		$spawnBuyList[%clientId, 6] = MineLauncher;
		$spawnBuyList[%clientId, 7] = TG::ClayMorMineAmmo;
		$spawnBuyList[%clientId, 8] = Tunneler;
		
		$spawnBuyList[%clientId, 9] = EnergyRifle;
		$spawnBuyList[%clientId, 10] = Blaster;
		$spawnBuyList[%clientId, 11] = TRocketLauncher;
		$spawnBuyList[%clientId, 12] = DiscLauncher;
		$spawnBuyList[%clientId, 13] = TankShredder;
		$spawnBuyList[%clientId, 14] = PlasmaCannon;
		$spawnBuyList[%clientId, 15] = LiLffb;
		$spawnBuyList[%clientId, 16] = Mortar;
		$spawnBuyList[%clientId, 17] = LiLPOOmkii;
		$spawnBuyList[%clientId, 18] = LiLPOOmki;
		$spawnBuyList[%clientId, 19] = DoublePlasma;
		return;
	}
}
//-----------------------------------------------------
// Not Used, was in development, fell through because 
// I just can't get it to work. :'(
function TG::SetFavsSpawn(%clientId)
{
	if(Player::getMountedItem(%clientId, 1) != -1)
	{ %clientId.SavedList[BackPack] = Player::getMountedItem(%clientId, 1); }
	else
	{ Echo("No Pack Found, Setting Default Pack..."); %clientId.SavedList[BackPack] = RepairPack; }
	
	if(%clientId.dead != "1" || %clientId.observerMode == "" || client::getownedobject(%clientId) != "-1")
	{
		%ii = 0;
		%max = getNumItems();
		$NumItems = getNumItems();
		for (%i = 0; %i < %max; %i++)
		{
			%checkItem = getItemData(%i);
			%datab = GameBase::getDataName(%i);
			if(%itemcount = Player::getItemCount(%clientId, %checkItem))
			{
				if (%itemcount)
				{
					echo ("Item Count  = " @ %itemcount @ "");
					echo ("Item Type   = " @ %checkitem @ "");
					echo("Saving item/weapon " @ %checkItem @ " for " @ %clientId);
					%ii++;
					$FavsBuyList[%clientId, %ii] = %checkItem;
					Echo("$FavsBuyList["@ %clientId @", "@ %ii @"] = "@ %checkItem);
				} 
			}
		}
	}
}