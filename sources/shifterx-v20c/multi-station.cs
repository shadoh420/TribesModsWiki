function Station::onActivate(%this)
{
	//echo("Activate " @ %this);

	%obj = Station::getTarget(%this);
	if (%obj != -1) 
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
		%this.lastPlayer = %obj;
		%obj.inStation = %this;

		%obj.stationAccess++;
	}
	else 
		GameBase::setActive(%this,false);
}

function Station::onCollision(%this, %object)
{
	dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player") {
  	 	%client = Player::getClient(%object);

		%armor = Player::getArmor(%object); // == Get Players Armour Type

 		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || (%armor == "spyarmor" || %armor == "spyfemale") ) {

			 if(!%client.isCursed) {

				if (GameBase::getDamageState(%this) == "Enabled") {

					if (GameBase::isPowered(%this)) { 
						
if(gamebase::getdataname(%this) == "InventoryStation")
{
 if ((%client.inStation != "") || Player::isDead(%client))	return;
	if ($Shifter::JustSpawned[%client] == true) { %object.shieldstrength = 0; $Shifter::JustSpawned[%client] = false; }
	setupShoppingList(%client,%this,"InvList");
	updateBuyingList(%client);
	%client.inStation = gamebase::getdataname(%this);
	%this.clTeamEnergy = %client.TeamEnergy;
	%object.ResupplyFlag = 1;
	Client::sendMessage(%client,0,"Station Access On");
	Client::setGuiMode(%client,$GuiModeInventory);
	sexor(%this, client::getOwnedObject(%client));
	return;
}


						if(%this.enterTime == "")
							%this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
					}
					else 
						Client::sendMessage(%client,0,"Unit is not powered");
				}
				else 
					Client::sendMessage(%client,0,"Unit is disabled");
			 }
			 else 
			 {
			Client::sendMessage(%client,0,"You won't rid yourself of the curse this easily...");

	               	%rot = GameBase::getRotation(%this);
        	    	%rad = getWord(%rot, 2);

    			%x = Sin(%rad);
	            	%y = Cos(%rad);

        	    	%dir = %x @ " " @ %y @ " 0";
            		%force = ixDotProd(%dir, 15);
	            	%x = getWord(%force, 0);
        	    	%y = getWord(%force, 1);
            		%vel = %x @ " " @ %y @ " " @ 7;
	            	Item::setVelocity(%client,%vel);
			}
		}
		else if(Station::getTarget(%this) == %object)
		{
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				Client::clearItemShopping(%client);
				Station::onDeactivate(%this);
				Station::onEndSequence(%this,1);
				if(Client::getGuiMode(%client) != 1)
					Client::setGuiMode(%client,1);
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

function Station::isTarget(%this, %obj)
{
 %pos = gamebase::getposition(%this);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$SimPlayerObjectType,%pos,6,6,8,0); 

 for (%i = 0; %i < %num; %i++)
 {
  if (%obj == Group::getObject(%set, %i))
  {
   deleteObject(%set);
   return 1;
  }
 }

 deleteObject(%set);
 return 0;
}

function Sexor(%this, %player)
{
 %client = player::getclient(%player);

 if ((station::isTarget(%this, %player)) && (!Player::isDead(%player)))
 {
  if (%client.inStation == "") return;
  schedule("Sexor("@%this@","@%player@");",1,%player);
  if(%player.ResupplyFlag) %player.ResupplyFlag = resp(%player);
 }
 else
 {
  %client.inStation = "";
  Client::clearItemShopping(%client);
  Client::sendMessage(%client,0,"Station Access Off");
  %player.ResupplyFlag = 0;
  Client::setGuiMode(%client,1);
 }
}

function resp(%player)
{
	if (%player != -1) {
		%client = player::getClient(%player);
		// Hardcoded here for the ammo types
		%cnt = Station::itemsToResupply(%player);
//		if(getSimTime() - %this.enterTime > 11)
//			%cnt = 0;
		if (%cnt != 0) {
			updateBuyingList(%client);
			return 1;
		}
		Client::sendMessage(%client,0,"Resupply Complete");
		return 0;
	}
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

//	%station = (Client::getOwnedObject(%client)).Station;
//	if(%station != "" ) {
	if (%client.inStation != "") {
//		%stationName = GameBase::getDataName(%station); 
		%stationName = %client.inStation;
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0) {
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) {
					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
			if(%bought) {
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}


function deadStationET(%this)
{
	%obj = %this.lastPlayer;
	if(%this == %obj.inStation)
		%obj.inStation = false;
}