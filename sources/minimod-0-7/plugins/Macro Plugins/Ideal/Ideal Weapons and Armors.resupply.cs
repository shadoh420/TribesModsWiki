// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

	if(Player::getItemCount(%player, C4Ammo))
		%cnt = %cnt + AmmoStation::resupply(%player,"",C4Ammo,2);
	else if(Player::getItemCount(%player, FlashgrenadeAmmo))
		%cnt = %cnt + AmmoStation::resupply(%player,"",FlashgrenadeAmmo,5);
	else if(Player::getItemCount(%player, StungrenadeAmmo))
		%cnt = %cnt + AmmoStation::resupply(%player,"",StungrenadeAmmo,2);
	else if(Player::getItemCount(%player, SuicideAmmo))
	{
		 //max 1
	}
	else
		%cnt = %cnt + AmmoStation::resupply(%player,"",HandgrenadeAmmo,2);

	if (Player::getItemCount(%player, FlagMine) || Player::getItemCount(%player, ReplicatingMine))
	{
		// Max 1
	}
	else
		%cnt = %cnt + AmmoStation::resupply(%player, "", OriginalMine, 3);

	%cnt = %cnt + AmmoStation::resupply(%player,Concuss,ConcussAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,SlowGun,SlowGunAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Marlin,MarlinAmmo,2);

	if(Player::getItemCount(%player, PlasmaGun) && %client.plasmaType == "FlamePlasma")
	{
		%max = 5 * $ItemMax[Player::getArmor(%player), PlasmaAmmo];
		%delta = %max - Player::getItemCount(%player, PlasmaAmmo);
		Player::setItemCount(%player, PlasmaAmmo, %max);
		%cnt = %cnt + %delta;
		teamEnergyBuySell(%player, PlasmaAmmo.price * %delta * -1);
	}
	if(Player::getItemCount(%player, DiscLauncher) && %client.discType == "Homing")
	{
		%max = floor($ItemMax[Player::getArmor(%player), DiscAmmo]/3);
		%delta = %max - Player::getItemCount(%player, DiscAmmo);
		Player::setItemCount(%player, DiscAmmo, %max);
		%cnt = %cnt + %delta;
		teamEnergyBuySell(%player, DiscAmmo.price * %delta * -1);
	}
