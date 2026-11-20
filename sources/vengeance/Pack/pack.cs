//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if($debug)
		echo("Backpack::onUse "@%item@", deployable ="@$TeamItemMax[%item]);
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		//set defaults -sometimes doesnt get reset when buying new packs.
		
		//resetting to default armor values -Plasmatic
		GameBase::setRechargeRate(%player,8);	//energy
		%player.shieldStrength = 0.0;		//shield
		GameBase::setAutoRepairRate(%player,0.0);	//repair
		
		//speed
		%armor = Player::getArmor(%client);	
		%baseArmor = $ArmorName[%armor];
		%buyarmor = $ArmorType[Client::getGender(%client), %basearmor];
		if(String::findSubStr(%armor, "Ice") > 5)
			%buyarmor = %buyarmor @ "Ice";		//Slippery when wet. -Plasmatic
		%energy = GameBase::getEnergy(%player);
		Player::setArmor(%client,%buyarmor);
		GameBase::setEnergy(%player,%energy);	
		
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		//plasmatic
		// we don't care if packs get used at stations anymore, checks in pack code to turn off passive benefits.. -Plasmatic
	//	if(!Client::isItemShoppingOn(%client,%item) || $build || $Annihilation::QuickInv) 
	//	{  	
			// If theres a team max, chances are its a deployable.. -Plasmatic 3.0
			if($TeamItemMax[%item])
			{
				// Ok, old method for deployable, on backpack use, we:
				// call this function, which calls blah::onuse, which 
				// in turn calls blah::ondeploy that in turn actually deploys the thing..
				// we're eliminating 2 redundant functions here...
				// ::onuse and ::ondeploy, of course these may be overwritten by ::onuse -Plasmatic
				
				//Player::deployItem(%player,%item);	lets kill 2 functions at once.. -Plasmatic
				if (eval(%item@"::deployShape("@%player@","@%item@");") && !$build)
					Player::decItemCount(%player,%item);	//success!!
				
			}
			else
			{
				//echo("Trigger "@%item);
				if(%player.packrecharge > 0)
					GameBase::playSound(%player, SoundPackFail, 0);
				else
					Player::trigger(%player,$BackpackSlot);
			}
	//	}
	//	else Client::sendMessage(%client,0,"~waccess_denied.wav");
	}
}
//	function BackPack::onUse(%player,%item)
//	{
//		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
//			Player::mountItem(%player,%item,$BackpackSlot);
//		else
//			Player::deployItem(%player,%item);
//	}



// generic use cycle is 18 secs. 10 seconds active, 8 recharge. -Plasmatic
function Backpack::recharge(%player,%item)
{
//	echo("Backpack::recharge"@%player@", "@%item@", "@%player.packrecharge);
	if(%player.packrecharge > 0)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if(%mounted == %item)
		{
			%time = %player.packrecharge;
			%player.packrecharge = %time -1;
			if(%player.packrecharge < 8)
			{
				Player::trigger(%player,$BackpackSlot,false);
				
				%client = GameBase::getOwnerClient(%player);
				%armor = Player::getArmor(%client);
				%baseArmor = $ArmorName[%armor];
				if($ArmorType[Client::getGender(%client), %basearmor] !=  %armor || %Item == SpeedPack)			
					SpeedPack::Deactivate(%player);
			//	Client::sendMessage(Player::getClient(%player),0, %item.description@" off, recharging.");
			}
			
			if(%player.packrecharge > 0)
				schedule("Backpack::recharge("@%player@", "@%item@");",1);
			else 
			{

			//	Client::sendMessage(Player::getClient(%player),0, %item.description@" has recharged.");
			}
		}
		else
		{
			%player.packrecharge = false;
			
			echo(%player@" no longer wearing "@%item);		
		}
	}
	else 
		echo("Pack recharge error");
}
			
			
	
