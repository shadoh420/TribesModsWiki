//----------------------------------------------------------------------------
// Deployable stations

function DeployableStation::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	
	if (%obj != -1)
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else
	{
		GameBase::setActive(%this,false);
	}
}


function DeployableStation::onEndSequence(%this,%thread)
{
	if(!%thread)
	{
		%this.deployed = 1;
		GameBase::playSequence(%this,2,"power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this,0,"deploy");
}

function DeployableStation::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this,2,"power");
	GameBase::setRechargeRate(%this,8);
}

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::stopSequence(%this,1);
	GameBase::setRechargeRate(%this,0);
	Station::checkTarget(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);

	if(%stationName == DeployableInvStation) 
    		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	else if( %stationName == DeployableAmmoStation) 
	  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100); 
}

function DeployableStation::onCollision(%this, %object)
{
	%obj = getObjectType(%object);
	if (%obj == "Player") 
	{
  	 	%client = Player::getClient(%object);
  		%armor = Player::getArmor(%object);
		
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || (%armor == "spyarmor" || %armor == "spyfemale") )
		{
			if (GameBase::getDamageState(%this) == "Enabled")
			{
				%data = GameBase::getDataName(%this);     
				if (%data.description == "Missile Control Station")
				{
					if(GameBase::getDamageState(%this.comstation) == "Enabled")
					{       
						schedule("CoolStationCheck(" @ %this @ ", " @ %object @ ");",0.5,%this);
						return;
					}
					else
					{       
						Client::sendMessage(%client,0,"Turret is damaged.~waccess_denied.wav");
					}      
					return;
				} 
				
					if(%this.enterTime == "") 
						%this.enterTime = getSimTime();
					GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
      		else if(Station::getTarget(%this) == %object)
      		{
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
			{
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}


//================================================================================ Deployables Station

StaticShapeData DeployablesStation
{
   	description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	maxEnergy = 200;
	shieldShapeName = "shield_medium";
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
};

function DeployablesStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"DepList");
}

function DeployablesStation::onResupply(%this,%InvShopList)
{
	dbecho(3, "STATION::Resupply");
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client) 
			{
				%player.Station = %this;
				%client.ListType = "DepList";
				setupShoppingList(%client,%this,"DepList");
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
            			if(!%client.noEnterInventory)
   					Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				%player.ResupplyFlag = 1;
			}
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			
			if(%player.ResupplyFlag) 
				%player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{	   
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation)
		{
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
			%player.Station = "";
			%this.target = "";
		}
	}
	%this.enterTime="";
}
