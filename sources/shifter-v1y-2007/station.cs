exec("station_list.cs");
exec("station_veh.cs");
exec("station_dep.cs");
exec("station_amo.cs");
exec("station_inv.cs");
exec("station_func.cs");
exec("station_com.cs");
//----------------------------------------------------------------------------
// Default station animations

function Station::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	
	if (%obj != -1)
	{
		%cl = Player::getClient(%obj);
		//=== For some reason when a client has inadverantly possessed someone but isn't controlling them it crashes the server
		if(%cl.possessing)
			doneposs(%cl);
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else
	{
		GameBase::setActive(%this,false);
	}
}

function Station::onDeactivate(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::setSequenceDirection(%this,1,0);
}

function Station::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($Shifter::Hunters)
		return;

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Station::onEndSequence(%this,%thread)
{

	%this.inuse = "";
		
	if($debug) echo ("Station Finished");
	
 	if (%thread == 1 && GameBase::isActive(%this)) 
 	{
		GameBase::playSequence(%this,2,"use");
		return true;
	}
	
	%client = %this.target;
	
	if(%client == "") 
	{
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}
	
	if(%client != "") 
	{
		%pl = Client::getOwnedObject(%client);
		%pl.dropped = 0;

		if(Client::getGuiMode(%client) != 1)
			Client::setGuiMode(%client,1);
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite")
		{
			if(%this.clTeamEnergy != %client.TeamEnergy)
			{
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0))
			{
				TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}
	
	if(%this.target != "")
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	
	%this.clTeamEnergy = "";

	if(%client.driver)
		Vehicle::dismount((Client::getOwnedObject(%client)).vehicle);
	return false;
}

function Station::onPower(%this,%power,%generator)
{
	if (%power)
	{
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
		GameBase::setRechargeRate(%this,8);
	}
	else
	{
		GameBase::stopSequence(%this,0);
		GameBase::pauseSequence(%this,1);
		GameBase::pauseSequence(%this,2);
		GameBase::setRechargeRate(%this,0);
		Station::checkTarget(%this);
	}
}

function Station::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
	{		
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
		GameBase::setRechargeRate(%this,8);
	}
}

function Station::checkTarget(%this)
{
	if(%this.target)
	{
		if ($debug) echo ("Stations Target = " @ %this.target);
		Client::setGuiMode(%this.target,1);
		GameBase::setActive(%this,false);
	}
	else
	{
		if ($debug) echo ("Station Has No Target.");
	}
}

function Station::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::pauseSequence(%this,1);
	GameBase::stopSequence(%this,2);
	GameBase::setRechargeRate(%this,0);
	Station::checkTarget(%this);
}

function Station::onDestroyed(%this)
{
	if ($Shifter::BotVersion)
		BotFuncs::AddRepairTask(%this);            //Werewolf

	echo ("StaticShape::objectiveDestroyed = Station.cs 1");

	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14"))
	{
	  	%obj = getObjectType($los::object);
	  	if (%obj == "Player")
	  	{
         		if( Player::isAiControlled( $los::object ) != "True" )
         		{
				return $los::object;
			}
		}
	}
	return -1;
}	

function Station::onCollision(%this, %object)
{
	%obj = getObjectType(%object);
	if (%obj == "Player")
	{
  	 	%client = Player::getClient(%object);

		//========================================== Spy Can Use Any Invo
		%armor = Player::getArmor(%object); // == Get Players Armour Type

 		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || GameBase::getTeam(%object) == -1 || (%armor == "spyarmor" || %armor == "spyfemale") ) 
		{
				if(%armor != parmor) //=== PArmor Can not use any station.
				{
					if (GameBase::getDamageState(%this) == "Enabled")
					{
						if (GameBase::isPowered(%this) || %this.poweron == "True") 
						{ 
							if((%client.fastfavs == "true" && %client.tobuy == "true" && GameBase::getDataName(%this).shapefile == "inventory_sta") || ($NoInv == true && GameBase::getDataName(%this) != "DeployableInvStation" && GameBase::getDataName(%this) != "CommandStation" && GameBase::getDataName(%this) != "DeployableComStation" && %client.tobuy == true))
							{
								%object.Station = %this;
								%target = %this.target;
								%this.target = %object;
								Client::setGuiMode(%client,$GuiModeInventory);
								GameBase::SetDamageLevel(%object,0);
								%client.lastdropper = "Off";
//								setupShoppingList(%client,%this,"InvList");
								for(%i = 0; %i < 20; %i++)
								{
									if(getItemData(%client.fav[%i]).className == Armor)
									{
										Client::setItemShopping(%client,getItemData(%client.fav[%i]));
										buyItem(%client,getItemData(%client.fav[%i]));
										break;
									}
								}
								setupShoppingList(%client,%this,"InvList");
								remotebuyfavorites(%client,%client.fav0,%client.fav1,%client.fav2,%client.fav3,%client.fav4,%client.fav5,%client.fav6,%client.fav7,%client.fav8,%client.fav9,%client.fav10,%client.fav11,%client.fav12,%client.fav13,%client.fav14,%client.fav15,%client.fav16,%client.fav17,%client.fav18,%client.fav19);
								remoteNextWeapon(%client);
								%object.Station = "";
								%this.target = %target;
								Client::setGuiMode(%client,1);
								return;
							}
							if (!%this.inuse)
							{
								%this.inuse = %this.target;
								if(%this.enterTime == "")
									%this.enterTime = getSimTime();
								GameBase::setActive(%this,true);
								%object.dropscriptcount = 0;
								%object.dscripmtime = 0;
							}
							else if(%this.inuse != %object && %this.inuse != %client)
								Client::sendMessage(%client,1,"Unit is in use... Please wait.");
						}
						else 
							Client::sendMessage(%client,1,"Unit is not powered");
					}
					else 
						Client::sendMessage(%client,1,"Unit is disabled");
				}
				else Client::sendMessage(%client,1,"You won't rid yourself of the penis this easily...");
		}
		else if(Station::getTarget(%this) == %object)
		{
			%curTime = getSimTime();
			
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
			{
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

function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",mineammo,1);

	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,25);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);

	%cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,1);
	%cnt = %cnt + AmmoStation::resupply(%player,SMRPack,AutoRocketAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,Vulcan,VulcanAmmo,50);
	%cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,SMRPack2,AutoRocketAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,BoomStick,BoomAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Hammer1Pack,HammerAmmo,10);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenPack,AutoGrenadeAmmo,10);
	%cnt = %cnt + AmmoStation::resupply(%player,AmmoPack,RepairKit,2);
	return %cnt;
}

