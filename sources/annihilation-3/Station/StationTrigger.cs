
// inventory triggers... -plasmatic


// this is called on mission change, when inv station is added..
// slowed this down a little so server can load mission up fully  -Plasmatic
function InventoryStation::onadd(%this)
{
//	echo("!! adding Inv");
	if($Annihilation::ExtendedInvs && !$ME::varsInitialized)				
		schedule("AddInventoryTrigger("@%this@");",5);	
}
function testInventoryStation::onadd(%this)
{
	GameBase::setPosition(%this,vector::add(GameBase::getPosition(%this),vector::getfromrot(GameBase::getRotation(%this),-10,0)));		
	GameBase::setRotation(%this,vector::add(gamebase::getrotation(%this),"0 0 -1.57"));
	if($Annihilation::ExtendedInvs && !$ME::varsInitialized)				
		schedule("AddInventoryTrigger("@%this@");",3);
	schedule("GameBase::playSequence("@%this@",0,\"busy\");",5);
}



//for additional inventory check..
LightningData InventoryCharge
{
	bitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 10.0;
	coneAngle = 35.0;
	damagePerSec = -0.5;
	energyDrainPerSec = 0.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;	// how wide..
	lightRange = 3.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundMortarIdle;	//SoundELFFire;
};

TurretData InvTurret	   
{			 
	maxDamage = 1000.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 7.5;		//15 plasm 3.0

	visibleToSensor = false;
	dopplerVelocity = 0.1;
	castLOS = true;
	supression = false;
	pinger = false;
	supressable = false;
	
	debrisId = defaultDebrisMedium;
	className = "";
	shapeFile = "camera";
	projectileType = InventoryCharge;
	speed = 5.0;
	speedModifier = 1.5;
	reloadDelay = 0.0; //0.3;	-handling this elsewhere... -plasmatic

	isSustained     = true;
	firingTimeMS    = 5000;	//1750
	energyRate      = 30.0;
};



TriggerData InvTrigger
{
	className = "Trigger";
	rate = 0.1;	//1.0;
};


// this is called on mission change, when inv station is added..
function AddInventoryTrigger(%this)
{
	//echo("ghost? "@$ghosting);
	if(!$ghosting)
		schedule("AddInventoryTrigger("@%this@");",3);
	else
	{				
		%group = newObject("InvNum"@%this,Simset);
		addToSet(MissionCleanup, %group);
		addToSet("MissionCleanup/Inventory",%group);	
		addToSet(%group,%this);	
		%this.group = %group;
		
		%Invpos = GameBase::GetPosition(%this);
		%rot = gamebase::getrotation(%this);
		%team = GameBase::getTeam(%this);
		%vec = rotateVector("0 -2.25 1.5",%rot);
		%pos = vector::add(%InvPos,%vec);
		
		// now for the fun part..
		instant Trigger "InventoryTrigger" {
			dataBlock = "InvTrigger";
			name = "InvTrigger";
			Team = %team;
			position = %pos;
			rotation = %rot;
			boundingBox = "-3 -3 -2.0 3 3 2.0";
			isSphere = "true";
			Owner = %this;
		};	
		
		// add inv turrets.. bah..	
		%vec = rotateVector("2.16 -0.5 1.4",%rot);
		%pos = vector::add(%InvPos,%vec);	
		%camera = newObject("Camera","Turret",InvTurret,true); 
		addToSet("MissionCleanup/Inventory", %camera);
		addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
		GameBase::setRotation(%camera,vector::add(%rot,"0 0 -2.02")); 
		GameBase::setPosition(%camera,%pos); 
		%this.rTurret = %camera;
		%camera.Owner = %this;	// bah -Plasm 3.0
			GameBase::setTeam(%camera,getNumTeams()-1); 	
			GameBase::setActive(%camera,true);	
			GameBase::setRechargeRate(%camera,100); 	
					
		%vec = rotateVector("-2.2 -0.5 1.4",%rot);	// -damn inv is lopsided.. -plasmatic
		%pos = vector::add(%InvPos,%vec);	
		%camera = newObject("Camera","Turret",InvTurret,true); 
		addToSet("MissionCleanup/Inventory", %camera);
		addToSet("MissionCleanup/Inventory/InvNum"@%this,%camera);
		GameBase::setRotation(%camera,vector::add(%rot,"0 0 -1.14")); 
		GameBase::setPosition(%camera,%pos); 	
		%this.lTurret = %camera;
		%camera.Owner = %this;	// bah -Plasm 3.0
			GameBase::setTeam(%camera,getNumTeams()-1); 	
			GameBase::setActive(%camera,true);	//plasm 3.0
			GameBase::setRechargeRate(%camera,100); 					
	}	
}


// gotta put this somewhere... make sure it gets added to mission cleanup, so it gets deleted on map change.
function InvTrigger::onadd(%this)
{
	%owner = %this.Owner;
	%Owner.Trigger = %this;	//plasm 3.0
	addToSet("MissionCleanup/Inventory", %this);
	addToSet("MissionCleanup/Inventory/InvNum"@%owner,%this);	
}

//Infinite Zappy fix 3/17/2007 6:36AM Plasmatic
function InvTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player") 
	{
		if(Player::isAIControlled(%object))
			return;
		%group = getGroup(%this); 
		%obj = %this.Owner;
		%client = GameBase::getOwnerClient(%object);
		
		//Ok, this is a strange bug. We're only going to track last trigger we enter with this..
		%object.InvObject = %obj;	//Infinite Zappy fix 3/17/2007 6:36AM Plasmatic
		//Lightning projectiles are not deleted when firing object is destroyed. Yay. 
		
		if($debug || $debuginv || $debugt)
		{
			echo("InvTrigger::onEnter "@%obj@" Damage state,"@GameBase::getDamageState(%obj)@", Powered,"@GameBase::isPowered(%obj)@" client,"@%client);
			echo("Left turret active"@%obj.lTurret@", "@GameBase::isActive(%obj.lTurret)@ " energy="@GameBase::getEnergy(%obj.lTurret)@ " right turret active"@%obj.rTurret@", "@GameBase::isActive(%obj.rTurret)@ " energy="@GameBase::getEnergy(%obj.rTurret));
		}
		if((GameBase::getTeam(%object) == GameBase::getTeam(%obj) || GameBase::getTeam(%obj) == -1) && %client.isSpy != true)
		{
			%client.InvTargetable = true;	//moved here in 3.0, station won't fire if unpowered.. -Plas 3.0
			if(GameBase::getDamageState(%obj) == "Enabled") 
			{
				if(GameBase::isPowered(%obj)) 
				{ 
					gamebase::setactive(%obj.lTurret,true);	//just to make certain.. gets changed on drop ship destroy.. for some damn reason..
					gamebase::setactive(%obj.rTurret,true);
					GameBase::setRechargeRate(%obj.lTurret,100);
					GameBase::setRechargeRate(%obj.rTurret,100);						
									
					//plas 3.0
					if(!$Annihilation::Zappy)
					{
						%Client.InvConnect = true;
						%client.ListType = "InvList";
						GameBase::playSound(%object, SoundActivatePDA,0);
						Client::sendMessage(%client,3,"..Inventory Uplink established..");
						QuickInv(%client);
						schedule("ZappyResupply(" @ %client @ ");",0.25);	
					}
				}
			}			
			else
			{
				gamebase::setactive(%obj.lTurret,false);	//just to make certain.. gets changed on drop ship destroy.. for some damn reason..
				gamebase::setactive(%obj.rTurret,false);
				GameBase::setRechargeRate(%obj.lTurret,100);
				GameBase::setRechargeRate(%obj.rTurret,100);	
			}			
		}		
	}
}


// Fix for overlaping Zappy Inv triggers 3/23/2007 4:21AM Plasamtic
// made easier by the.. Infinite Zappy fix 3/17/2007 6:46AM
function InvTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player")
	{
		if(Player::isAIControlled(%object))
			return;
		
		%client = GameBase::getOwnerClient(%object);
				
		%TrigPos = Gamebase::getPosition(%this);
		%PlPos = getBoxCenter(%object);	
		%dist = vector::getdistance(%PlPos,%TrigPos);		
		if(%dist > 3)
		{
			
			%PlayerStation = %object.InvObject;
			%TriggerStation = %this.owner;
			if(%PlayerStation == %TriggerStation)
			{
				if($debug || $debuginv || $debugt)
				{
					echo("InvTrigger::onLeave, client= "@%client@" Dist= "@%dist);
				}
		
				%client.ConnectBeam = "";	//internal
				%client.InvTargetable = "";	//internal
				%Client.InvConnect = "";	//external	
				QuickInvOff(%client);	
				%object.ZappyResupply = "";
				%client.ListType = "";
			}
			else
			{
				//For the odd time 2 triggers overlap.. 3/23/2007 4:21AM Plasamtic
				// fire up the new triggers inventory station. 
		
				%client.ConnectBeam = "";	//internal
				if((GameBase::getTeam(%object) == GameBase::getTeam(%PlayerStation) || GameBase::getTeam(%PlayerStation) == -1) && %client.isSpy != true)
				{
					%client.InvTargetable = true;	//moved here in 3.0, station won't fire if unpowered.. -Plas 3.0
					if(GameBase::getDamageState(%PlayerStation) == "Enabled") 
					{
						if(GameBase::isPowered(%PlayerStation)) 
						{ 
							gamebase::setactive(%PlayerStation.lTurret,true);	//just to make certain.. gets changed on drop ship destroy.. for some damn reason..
							gamebase::setactive(%PlayerStation.rTurret,true);
							GameBase::setRechargeRate(%PlayerStation.lTurret,100);
							GameBase::setRechargeRate(%PlayerStation.rTurret,100);						
							Client::sendMessage(%client,3,"..Attempting Uplink transfer..");	//3/23/2007 4:41AM For overlaping triggers. -Plasmatic	
					
							//	//plas 3.0
							if(!$Annihilation::Zappy)
							{
								%Client.InvConnect = true;
								%client.ListType = "InvList";
								GameBase::playSound(%object, SoundActivatePDA,0);
								Client::sendMessage(%client,3,"..Inventory Uplink established..");
								QuickInv(%client);
								schedule("ZappyResupply(" @ %client @ ");",0.25);	
							}
						}
					}			
					else
					{
						gamebase::setactive(%PlayerStation.lTurret,false);	//just to make certain.. gets changed on drop ship destroy.. for some damn reason..
						gamebase::setactive(%PlayerStation.rTurret,false);
						GameBase::setRechargeRate(%PlayerStation.lTurret,100);
						GameBase::setRechargeRate(%PlayerStation.rTurret,100);	
					}			
				}
			}	
		}
	}
}


function InvTurret::verifyTarget(%this,%target)
{
	if(!$Annihilation::ExtendedInvs || !$Annihilation::Zappy) 
		return false;
	
	%client = GameBase::getOwnerClient(%target);
	%control = GameBase::getControlClient(%target);
	// was a little funkyness (cheat hole) with turrets damaging vehicles and giving inv to owner.
	// owner would not lose inv when leaving trigger -the vehicle would.. added the '%control' check for 2.2 -plasmatic
	if(!%client.InvTargetable || %client.ConnectBeam || %control == -1)
		return "False";
		
	//meh, lets do a double power check here.. plasm 3.0
	%owner = %this.Owner;
	if(!GameBase::isPowered(%Owner) || GameBase::getDamageState(%Owner) != "Enabled") // notice the big O... heh heh eeeheh heh.. -Plasmatic 3.0
		return false;
	
	else return true;
}

function InventoryCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	// verify player is within sight of coresponding inventory -invs not covered with blast walls..	
	// could do this with a diffrent damage type, but this would have to be in player::ondamage

	%client = GameBase::getOwnerClient(%target);
	if(!%Client.InvConnect)
	{	
		Client::sendMessage(%client,3,"..Inventory Uplink established..");
		
		QuickInv(%client);
		schedule("ZappyResupply(" @ %client @ ");",0.25);
		GameBase::playSound(%target, SoundActivatePDA,0);		
	}	
		
	%client.InvConnect = true;
	%client.ListType = "InvList";
	schedule("QuitBeam("@%client@");",1.0);
}

//Updated 3/17/2007 6:56AM
function InventoryCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	// verify player is within sight of coresponding inventory -invs not covered with blast walls..	
	// could do this with a diffrent damage type, but this would have to be in player::ondamage

	%client = GameBase::getOwnerClient(%target);
	
	//Lightning projectiles are not deleted when firing object is destroyed. Yay. 
	//Infinite Zappy fix 3/17/2007 6:46AM
	//Scratch that. Setting turret energy to 0 just before destroy deletes it. -Plasmatic
	//Fuck it, Leaving fix in for redundancy.
	//Scratch that.. In some cases you can get around the check. Redundancy is good.
	%InvObject = %target.InvObject;
	%InvPos = gamebase::getposition(%InvObject);
	//client::sendmessage(%client,0,"Inv zappy "@%client.InvTargetable@", InvStation ="@%InvPos);
	if(%client.InvTargetable && %InvPos != "0 0 0")
	{
		if(!%Client.InvConnect)
		{	
			Client::sendMessage(%client,3,"..Inventory Uplink established..");
			
			QuickInv(%client);
			schedule("ZappyResupply(" @ %client @ ");",0.25);
			GameBase::playSound(%target, SoundActivatePDA,0);
					
		}
				
		%client.InvConnect = true;
		%client.ListType = "InvList";
		schedule("QuitBeam("@%client@");",1.0);
	}
	else
	{
		%client.ConnectBeam = "";	//internal
		%client.InvTargetable = "";	//internal
		%Client.InvConnect = "";	//external	
		QuickInvOff(%client);	
		%object.ZappyResupply = "";
		%client.ListType = "";		
	}
}

function QuitBeam(%client)
{
	if(%client.InvTargetable)	
		%client.ConnectBeam = "true";	
	else %client.ConnectBeam = "";	
}

function InvTurret::OnDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($debug::Damage)
	{
		echo("InvTurret::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}	
	//do nothing, no damage..
}

function ZappyResupply(%client)
{
	if(%client.InvConnect)
	{
		if(!isPlayerBusy(%client))
		{
			%player = Client::getOwnedObject(%client);
	//			//damnit
	//			%player = Client::getOwnedObject(%client);
	//			echo("zappy resupply dead? "@Player::isDead(%player));	
	//			//end cursing	
			%cnt = Station::itemsToResupply(%player);
			if(%cnt != 0 || gamebase::getdamagelevel(%player)) 
			{
				%player.ZappyResupply = true;
				%player.waitThrowTime = getSimTime();
				GameBase::repairDamage(%player,0.15);
				schedule("ZappyResupply(" @ %client @ ");",0.5);
				//return;
				
			}
			else %player.ZappyResupply = "";	
			//Client::sendMessage(%client,3,"...Resupply Complete, do something...");
		}
		else
			schedule("ZappyResupply("@%client@");",2);	//3.0 fix -plasm
	}
	
}

// handling zappys a little different. -Plasm... Just rearrange you psalm a little punk!
function ZappyPowerSwitch(%this,%power)
{
	%type = Gamebase::getdataname(%this);
	//echo(" ZappyPowerSwitch ("@%this,%power);
	if(string::ICompare(%type, "InventoryStation") == 0 || string::ICompare(%type, "MobileInventory") == 0)
	{
		gamebase::setactive(%this.lTurret,%power);	
		gamebase::setactive(%this.rTurret,%power);
		if(%power)
		{
			GameBase::setRechargeRate(%this.lTurret,100);
			GameBase::setRechargeRate(%this.rTurret,100);
		}
		else
		{
			GameBase::setRechargeRate(%this.lTurret,0);
			GameBase::setRechargeRate(%this.rTurret,0);
		}	
	}
}