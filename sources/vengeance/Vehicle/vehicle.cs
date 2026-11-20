


function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	//schedule("vehicle::ImpactCheck("@%this@");",1);
	if($annihilation::VehicleImpactor)
		vehicle::ImpactCheck(%this);
}
function checklos(%this)
{
	if(GameBase::getLOSInfo(%this,100,"0.15 0 0"))	//,"0 0 3.14" ,"0 0 1.57" left, "0 1.57 0" forward
	{
		%object = getObjectType($Los::Object);
		return(%object);
		bottomprint(2049,"<jc>"@%object);
	}
}

// a lil something to check for collisions with nasty crashy stuff... -plasmatic 2.2
// this tests for collisions with statics - Blastwalls, platforms, etc..
function vehicle::ImpactCheck(%this)
{
	if(GameBase::getDamageState(%this) == Destroyed) 
		return;	
		
	%control = GameBase::getControlClient(%this);
	if(%control != -1)
	{	
		%vel = Item::getVelocity(%this);
		%velocity = vector::getdistance(%vel,"0 0 0");
		bottomprint(%control,"<jc>Velocity = "@%velocity>>0.1@" mph",2);
		%data = GameBase::getDataName(%this);
		%shape = %data.shapeFile;
		if(%shape != camera && %shape != rocket)
		{
			if(%velocity > 0.75)
			{		
				
				%check = 5 + %velocity/5;	
				if(GameBase::getLOSInfo(%this,%check,"0.15 0 0"))	//look up a lil...
				{
					%object = getObjectType($Los::Object);
						// GetLOSInfo sets the following globals:
						// 	los::position
						// 	los::normal
						// 	los::object		
					if(%object == StaticShape)
					{
						//	if(%control != -1)
						//		bottomprint(%control,"<jc>IMPACT?! "@%object@" Velocity = "@%velocity,5);		
						echo(%this@" "@%shape@" "@%control@" IMPACT?! "@%object@" killing vehicle -error");
						GameBase::setDamageLevel(%this,2);	
					}
				}
				//echo("check vehicle impact. vel ="@%velocity@" check= "@%check);
			}
			
		}
	}
	schedule("vehicle::ImpactCheck("@%this@");",0.1);	
}



function Vehicle::onCollision(%this, %object)
{	
	//if($debug) 
		event::collision(%this,%object);

	%client = Player::getclient(%object);
	
	//inventory cheat holes -plasmatic
	%Client.InvConnect = "";	//external	
	QuickInvOff(%client);	
	%object.ZappyResupply = "";
	%client.ListType = "";
		
	if(%client != GameBase::getControlClient(%object))return;	//check to make sure client is controling player -plasmatic
	
	%vehname = GameBase::getDataName(%this);	
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) 
	{
		if(getObjectType(%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
			if( Player::isAiControlled(%object) )
				return;

		%station = %object.Station;
		if(%Station)//plasmatic
		{
			Client::sendMessage(%client,0,"Sun Tzu Says NO! ~waccess_denied.wav");
			return;
		}				
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			if(($VehicleUse[%armor, %vehname] & $CP) && Vehicle::canMount(%this, %object))
			{
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) 
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}				
				
				Player::setMountObject(%object, %this, 1);	//player, vehicle, seat
				Client::setControlObject(%client, %this);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;

			}
			else if($VehicleSlots[%vehname] == 0)
				Client::sendMessage(Player::getClient(%object),0,"Cannot pilot this vehicle in your current armor class.~wError_Message.wav");
			else if($VehicleUse[%armor, %vehname] & $CR)
			{
				%mountSlot = Vehicle::findEmptySeat(%this,%client);
				if(%mountSlot) 
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
				else
					Client::sendMessage(Player::getClient(%object),0,"No slot.  Dismount the vehicle to free it for takeoff.~wError_Message.wav");
			}
			else if(GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	%numSlots = $VehicleSlots[GameBase::getDataName(%this)];
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "")
		{
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1)
	{
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if(%count > 1)
	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++)
	{
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") 
		{
			%distance = %newDistance;
			%closePos = %i;
		}
	}
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	
	%height = 2;
	%velocity = 140;
	%zVec = 110;

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) 
	{
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player")
		{
			// dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0)))
			{
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
				Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
				Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "")
				{
					Player::useItem(%pl,%pl.lastWeapon);
					%pl.lastWeapon = "";
				}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}
function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this == %object)
		echo("crash!!? (Vehicle::onDamage)");
	if(%type == $NullDamageType)
		return;		
	if(GameBase::getDamageState(%this) == Destroyed) 
		return;	

	if(%Value == 0)
		%value = 0.25;
//	{
//		//GameBase::setDamageLevel(%this,2);
		echo("!! No "@GameBase::getDataName(%this)@" Damage, ERROR! cl# "@%this.clLastMount);
//		return;	
//	}

	//T:V mod -Plasmatic
	if(%type ==$HealingDamage || %type == $RepairTurretDamage)
	{
	//	if(GameBase::getTeam(%this) ==  GameBase::getTeam(%object))
			RepairDamage(%this,%value);
		return;	
	}		
	%damageLevel = GameBase::getDamageLevel(%this);	
	%dValue = %damageLevel + %Value;
	GameBase::setDamageLevel(%this,%dValue);
}
function Vehicle::onDestroyed (%this,%mom)
{
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	%this.cloakable = "";
	%this.nuetron = "";
	if(%pl != -1)
	{
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "")
		{
			Player::useItem(%pl,%pl.lastWeapon);
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
		%pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "")
		{
			%pl = Client::getOwnedObject(%this.Seat[%i]);
			Player::setMountObject(%pl, -1, 0);
			Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
			%pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}

//handling all this in the seperate files.. plasmatic 2.2
function Vehicleold::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(GameBase::getDamageState(%this) == Destroyed) 
		return;

	if($debug)
	{
		%data = GameBase::getDataName(%this);
		%velocity = vector::getdistance(%vec,"0 0 0");		
		echo("!!Vehicle::onDamage "@%this@" damaged by "@GameBase::getDataName(%object)@" object ="@%object@" Vel. "@%velocity@" type ="@%type@" pos="@%pos@" vec="@%vec@" mom="@%mom);
	}
	// Anti server crash crap for 2.2... coding around idiots again... -plasmatic
	if(%type == -1)
	{
		%control = GameBase::getControlClient(%this);
		echo(%this@" "@GameBase::getDataName(%this)@" cl# "@%control@" IMPACT!!  %value ="@%value);
		if(%Value == 0)
			%Value = 0.05;
	}	
	%damageLevel = GameBase::getDamageLevel(%this);	
	//%Value *= $damageScale[GameBase::getDataName(%this), %type];
	%dValue = %damageLevel + %Value;
	GameBase::setDamageLevel(%this,%dValue);

}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
	return 1.0;
}


// killing yet another cheat.. deploying vehicle with back to a wall, and jumping
// out through wall, or deploying and jumping out through ceiling -plasmatic
function Vehicle::DeployArea(%player,%shape,%pos)
{
	echo("!! Check vehicle deploy area");
	%client = Player::getClient(%player);
	%Ppos = GameBase::getPosition(%player);
	%rot = gamebase::getrotation(%player);
	gamebase::setposition(%player,vector::add(%Ppos, "0 0 100"));	//moving player temporarily out of way
	%objVehicle = newObject("",flier,%shape,true);
	GameBase::setRotation(%objVehicle, %rot);
	addToSet("MissionCleanup", %objVehicle); 

	if(!GameBase::testPosition(%objVehicle, vector::add(%pos,"0 0 1.75")))
	{ 
		Client::sendMessage(%client,0,"Vehicle will not fit there.");
		deleteObject(%objVehicle);
		gamebase::setposition(%player,%Ppos);
		return false;
	}
	else
	{
		deleteObject(%objVehicle);
		gamebase::setposition(%player,%Ppos);
		return true;	
	}
}


// tribes wont allow vehicles below terrain, and will raise untill above ground
// checks are to determine if a player is trying to place below terrain. 
// Eliminate some evil server lag issues.. -plasmatic

function Vehicle::TerrainCheck(%object)
{
	%pos = getBoxCenter(%object);
	%object.Lpos = %pos;
	schedule("Vehicle::Checkpos(" @ %object @ ");",0.1);				
}
function Vehicle::Checkpos(%object)
{	
	%pos = getBoxCenter(%object);
	%pos3 = getWord(%pos,2);
	%Lpos = %object.Lpos;
	%Lpos3 = getWord(%Lpos,2);
	%object.Lpos = "";
	//echo("vehiclepos/ lastpos ",%pos," ",%Lpos);
	if(%pos3 -2 > %Lpos3)
	{
		GameBase::setPosition(%object,%Lpos);
		Item::setVelocity(%object, 0);
		GameBase::setDamageLevel(%object,2);		
	}		
}


//----------------------------------------------------------------------------
// this will mount a player onto another player.. fun for all ages.. -plasmatic
function GrabAss(%client,%passenger)
{
	%player = Client::getOwnedObject(%passenger);
	%vehicle = Client::getOwnedObject(%client);
	Player::setMountObject(%player, %vehicle, 1);	//player, vehicle, seat
}