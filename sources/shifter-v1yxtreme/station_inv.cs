//----------------------------------------------------------------------------

StaticShapeData DeployableInvStation
{
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundInventoryStationPower };			
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
   	explosionId = flashExpSmall;
   	//validateShape = true;
	//validateMaterials = true;
};


function DeployableInvStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1) 
	{
		GameBase::playSequence(%this,1,"use");
 		InventoryStation::onResupply(%this,"RemoteInvList");
	}
	else
		GameBase::setActive(%this,false);
}


//================================================================================ Standard Invo Station

StaticShapeData InventoryStation
{
   	description = "Station Supply Unit";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	maxEnergy = 250;
	shieldShapeName = "shield_medium";
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
   	explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) 
		InventoryStation::onResupply(%this,"InvList");
}

function InventoryStation::onResupply(%this,%InvShopList)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client) 
			{
				%player.Station = %this;
				%client.ListType = %InvShopList;
		
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				if(%client.possessed == "true") %client = %client.possby;
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				
				if ($Shifter::ItemLimit)
				{
					%client.invo = %this;
					%client.ListType = %InvShopList;
				}
				
            			if(!%client.noEnterInventory)
   					Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				%player.ResupplyFlag = 1;
			}
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);

			//=== Reset the dropscript count variable every 0.5 seconds
			%player.dropscriptcount = 0;
			
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


//================================================================================ Emplacement Invo Station

StaticShapeData EmplacementStation
{
   	description = "Emplacement Supply Unit";
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

function EmplacementStation::onEndSequence(%this,%thread)
{
	InventoryStation::onEndSequence(%this,%thread);
}

function EmplacementStation::onResupply(%this,%InvShopList)
{
	InventoryStation::onResupply(%this,%InvShopList);
}