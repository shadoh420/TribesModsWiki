dbecho(1,"Precaching Bot AI Functions");

$SPOONBOT::Version = "4.0";

exec("JetToPos");
exec("BotGear");
exec("BotBehaviour");
exec("BotThink");
exec("BotTypes");
exec("BotFuncs");
exec("BotSpawn");
exec("BotTree");
exec("BotHUD");
exec("BotMove");

//
// AI support functions.
//

//
// This function creates an AI player using the supplied group of markers 
//    for locations.  The first marker in the group gives the starting location 
//    of the the AI, and the remaining markers specify the path to follow.  
//
// Example call:  
// 
//    createAI( guardNumberOne, "MissionGroup\\Teams\\team0\\guardPath", larmor );
//

//globals
//--------
// path type
// 0 = circular
// 1 = oneWay
// 2 = twoWay
$AI::defaultPathType = 1; //run oneWay paths. Changed from TwoWayPath by Werewolf

//armor types
//hyperlight = hlarmor
//light = larmor
//medium = marmor
//heavy = harmor
//ultraheavy = uharmor
//engineer = earmor
$AI::defaultArmorType = "larmor";



//HUGE CHANGE FROM THIS VERSION
//---------------------------------
//createAI()
//---------------------------------
//modified by Werewolf

function createAI( %aiName, %markerGroup, %armorType, %name )
{
	%group = nameToID( %markerGroup );
	%voice = "male2";
	if( %group == -1 || Group::objectCount(%group) == 0 )
	{
		dbecho(1, %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
		return -1;
	}
	else
	{
		%spawnMarker = Group::getObject(%group, 0);
	//	%spawnMarker = AI::pickRandomSpawn(%team); //Much more convenient
		%spawnPos = GameBase::getPosition(%spawnMarker);
		%spawnRot = GameBase::getRotation(%spawnMarker);

		if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
		{
			$AI::defaultArmorType = "lfemale";
			%voice = "female2";
		}
		else
		{
			$AI::defaultArmorType = "larmor";
			%voice = "male2";
		}

		if( AI::spawn( %aiName, $AI::defaultArmorType, %spawnPos, %spawnRot, %aiName, %voice ) != "false" )
		{
			$Spoonbot::NumBots = $Spoonbot::NumBots + 1;

			// The order number is used for sorting waypoints, and other directives.
			// Set to two so it won't fuck up my precious chasing code :-P

			BotFuncs::InitVars( %aiId );      // Wicked69

			//CAN MAKE ANOTHER LINE TO SET SKIN TO YOUR OWN SKIN
			Client::setSkin(%aiId, $Server::teamSkin[Client::getTeam(%aiId)]);  // Werewolf

			if (BotTypes::IsMedic(%newName))    //As of yet only one Medic can work in the Object Repair Task Queue. (This means repairing Turrets, etc)
			{
				if (%teamnum == 0)
					$Spoonbot::Team0Medic = %aiId;//SETS UP TO FOUR TEAMS TO HAVE A MEDIC
				if (%teamnum == 1)
					$Spoonbot::Team1Medic = %aiId;
				if (%teamnum == 2)
					$Spoonbot::Team2Medic = %aiId;
				if (%teamnum == 3)
					$Spoonbot::Team3Medic = %aiId;
			}

			schedule("BotThink::Think(" @ %aiId @ ", True);", 3);      // Wicked69
			%orderNumber = 2;

			for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
			{
				%spawnMarker = Group::getObject(%group, %i);
				%spawnPos = GameBase::getPosition(%spawnMarker);
			//	AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );//CHANGED. old version
			//	%orderNumber++;
			}
		}
		else
		{
			dbecho( 1, "Failure spawning: " @ %aiName );
		}
	}
}


//-----------------------------------
// AI::initDrones()
//-----------------------------------

function AI::initDrones(%team, %numAi)
{
	dbecho(1, "spawning team " @ %team @ " ai...");
	for(%guard = 0; %guard < %numAi; %guard++)
	{
		//check for internal data
		%tempSet = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
		%tempItem = Group::getObject(%tempSet, %guard);
		%aiName = Object::getName(%tempItem);

		%set = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %aiName);
		%numPts = Group::objectCount(%set);

		if(%numPts > 0)
		{
			createAI(%aiName, %set, $AI::defaultArmorType, %aiName);

			%aiId = ai::GetId( %aiName );
			GameBase::setTeam(%aiId, %team);
			AI::setVar( %aiName,  iq,  60 );
			AI::setVar( %aiName,  attackMode, 1);
			AI::setVar( %aiName,  pathType, $AI::defaultPathType);
//			schedule("AI::setWeapons(" @ %aiName @ ");", 1);
			%aiId = ai::GetId(%aiName);
			schedule("AI::setWeapons(" @ %aiId @ ");", 1);
		}
		else
			dbecho(1, "no info to spawn ai...");
	}
}


//------------------------------------------------------------------
//functions to test and move AI players.
//
//------------------------------------------------------------------

//
//This function will spawn an AI player about 5 units away from the 
//player that is passed to the function(%commandIssuer).
//
//

$numAI = 0;

function AI::helper(%aiName, %armorType, %commandIssuer)
{
	%spawnMarker = GameBase::getPosition(%commandIssuer);
	%xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 15);
	%yPos = getword(%spawnMarker, 1) + floor(getRandom() * 10);
	%zPos = getWord(%spawnMarker, 2) + 5;
	%rPos = GameBase::getRotation(%commandIssuer);
	
	dbecho(2, "Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
	dbecho(2, "Current Issuer rotation: " @ %rPos);
	
	%aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	%newName = %aiName @ $numAI;
	$numAI++;
	Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos,  %newName, %voice );
	$Spoonbot::NumBots = $Spoonbot::NumBots + 1;
	return ( %newName );
}

//
//This function will move an AI player to the position of an object
//that the players LOS is hitting(terrain included). Must be `	within 50 units.
//
//

function AI::moveToLOS(%aiName, %commandIssuer) 
{
	%issuerRot = GameBase::getRotation(%commandIssuer);
	%playerObj = Client::getOwnedObject(%commandIssuer);
	%playerPos = GameBase::getPosition(%commandIssuer);

	//check within max dist
	if(GameBase::getLOSInfo(%playerObj, 100, %issuerRot))
	{ 
		%newIssuedVec = $LOS::position;
		%distance = Vector::getDistance(%playerPos, %newIssuedVec);
		dbecho(2, "Command accepted, AI player(s) moving....");
		dbecho(2, "distance to LOS: " @ %distance);
		AI::DirectiveWaypoint( %aiName, %newIssuedVec, 2, 2 );
	}
	else
		dbecho(2, "Distance too far.");
      
	dbecho(2, "LOS point: " @ $LOS::position);
}

//This function will move an AI player to a position directly in front of
//the player passed, at a distance that is specified.

function  AI::moveAhead(%aiName, %commandIssuer, %distance) 
{
   
	%issuerRot = GameBase::getRotation(%commandIssuer);
	%commPos  = GameBase::getPosition(%commandIssuer);
//	dbecho(2, "Commanders Position: " @ %commPos);
   
	//get commanders x and y positions
	%comm_x = getWord(%commPos, 0);
	%comm_y = getWord(%commPos, 1);

	//get offset x and y positions
	%offSetPos = Vector::getFromRot(%issuerRot, %distance);
	%off_x = getWord(%offSetPos, 0);
	%off_y = getWord(%offSetPos, 1);

	//calc new position
	%new_x = %comm_x + %off_x;
	%new_y = %comm_y + %off_y;
	%newPos = %new_x  @ " " @ %new_y @ " 0";
  
	//move AI player
//	dbecho(2, "AI moving to " @ %newPos);
//	AI::DirectiveWaypoint(%aiName, %newPos, 2, 2);
}  

// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//

function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, %cmdStatus, %cmdSequence )
{
	%aiId = BotFuncs::GetId( %name );
	if (%aiId==0)
		return;

	%cmdId = Player::getClient(%commander); // Don't want traitors (i.e. those using
	if(%cmdId.traitor == 1)			// Chameleon Devices) giving orders to
	{					// the other teams's bots.
		Client::sendMessage(%cmdId,2,%name @ " will not respond to commands from you!~wC_BuySell.wav");
		return;
	}

	if($IsDoppelganger[%aiId] > 0 && $IsDoppelganger[%aiId] != %cmdId)
	{					// Doppelgangers only take orders from their originals
		Client::sendMessage(%cmdId,2,%name @ " will not respond to commands from you!~wC_BuySell.wav");
		return;
	}

	%T = GameBase::getTeam( %aiId );
	TeamMessages(0, %T, Client::GetName(%cmdId) @ " gave " @ Client::GetName(%aiId) @ " orders to " @ %cmdText); // Let the team know what's going on
//	echo("Command = " @ %command @ ", Target ID = " @ %targetId);

	%groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI\\" @ %name ); 
  	%nodeCount = Group::objectCount( %groupId );

	if( %command == 1 )  //Attack
	{
		if(!BotTypes::IsCmd(%name) && $IsDoppelganger[%aiId] <= 0)
		{
			Client::sendMessage(%cmdId,2,%name @ " will not respond to movement commands!~wC_BuySell.wav");
			return;
		}

		// must convert waypoint location into world location.  waypoint location
		//    is given in range [0-1023, 0-1023].  
		%worldLoc = WaypointToWorld ( %waypoint );

		Vehicle::passengerJump(0,%aiId,0);	//Crude way to make passengers hop off vehicles :-P

		AI::DirectiveWaypoint( %name, %worldLoc, 3000);
	}
	else if( %command == 2 )  //Defend
	{
		// must convert waypoint location into world location.  waypoint location
		//    is given in range [0-1023, 0-1023].  
		%worldLoc = WaypointToWorld ( %waypoint );

		if (getWord(%cmdText, 0) == "Deploy") //Deploy
		{
			if($IsDoppelganger[%aiId] > 0)
			{
				Client::sendMessage(%cmdId,2,"Doppelgangers can not deploy equipment!~wC_BuySell.wav");
				return;
			}

			%armor = Player::getArmor(%aiId);

			if (String::findSubStr(getWord(%cmdText, 1), "beacon") == 0) //Deploy Beacon
			{
				AI::DeployItem(%aiId, Beacon);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (%armor == "hlarmor" || %armor == "hlfemale")
			{
				Client::sendMessage(%cmdId,2,%name @ " does not carry those!~wC_BuySell.wav");
				return;
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "pulse") == 0) //Deploy Pulse Sensor
			{
				AI::DeployItem(%aiId, PulseSensorPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "sensor") == 0) //Deploy Sensor Jammer
			{
				AI::DeployItem(%aiId, DeployableSensorJammerPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "motion") == 0) //Deploy Motion Sensor
			{
				AI::DeployItem(%aiId, MotionSensorPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "camera") == 0) //Deploy Camera
			{
				AI::DeployItem(%aiId, CameraPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (%armor == "larmor" || %armor == "lfemale")
			{
				Client::sendMessage(%cmdId,2,%name @ " does not carry those!~wC_BuySell.wav");
				return;
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "Ammo") == 0) //Deploy Ammo Station
			{
				AI::DeployItem(%aiId, DeployableAmmoPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "Inventory") == 0) //Deploy Inventory Station
			{
				AI::DeployItem(%aiId, DeployableInvPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
			else if (%armor != "earmor" && %armor != "efemale")
			{
				Client::sendMessage(%cmdId,2,%name @ " does not carry those!~wC_BuySell.wav");
				return;
			}
			else if (String::findSubStr(getWord(%cmdText, 1), "Turret") == 0) //Deploy Turret
			{
				AI::DeployItem(%aiId, TurretPack);
				schedule("Vehicle::passengerJump(0," @ %aiId @ ",0);", 1);
			}
		}
		else if (getWord(%cmdText, 0) == "Defend") //Defend
		{
			if(!BotTypes::IsCmd(%name) && $IsDoppelganger[%aiId] <= 0)
			{
				Client::sendMessage(%cmdId,2,%name @ " will not respond to movement commands!~wC_BuySell.wav");
				return;
			}

			AI::DirectiveFollow( %name, %commander, 0,3000);
		}
	}
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, cheer3 );
//

function Ai::soundHelper( %sourceId, %destId, %waveFileName )
{
	%wName = strcat( "~w", Client::getVoiceBase( %sourceId ) );
	%wName = strcat( %wName, ".w" );
	%wName = strcat( %wName, %waveFileName );
	%wName = strcat( %wName, ".wav" );

	dbecho( 2, "Trying to play " @ %wName );

	Client::sendMessage( %destId, 0, %wName );
}


function Ai::messageHelper(%targetId, %msg )
{
	Client::sendMessage( %targetId, 0, %msg );
}



// Default periodic callback.  [Note by default it isn't called unless a frequency 
//    is set up using AI::CallbackPeriodic().  Type in that command to see how 
//    it works].  

function AI::onPeriodic( %aiName )
{
	// dbecho(2, "onPeriodic() called with " @ %aiName );
}



//The following callbacks are responsible for the bot's chasing behaviour.
//modified by Werewolf

function AI::onDroneKilled(%aiName)
{
	$Spoonbot::NumBots = $Spoonbot::NumBots - 1;
	if( ! $SinglePlayer )
	{

		%aiId = BotFuncs::GetId(%aiName);
		%team = GameBase::getTeam(%aiId);
		$Spoonbot::BotStatus[%aiId] = "Dead";
		%curTarget = ai::getTarget( %aiName );
		%targetName = Client::getName(%curTarget);

		$BotThink::Definitive_Attackpoint[%aiId] = "";  // ERROR: I think there's no player ID for a dead bot.
		$BotThink::ForcedOfftrack[%aiId] = true;

		if ($Spoonbot::BotChat)
		{
			%chatdelay = floor(getRandom() * (10 - 0.1));
			schedule("AI::RandomSuckMsg(" @ %aiName @ ", " @ %team @ ");", %chatdelay );
		}

		if (%aiId != $DoNotRespawnAI)
		{
			// Delay $RespawnDelay seconds before respawning
			if ($Spoonbot::RespawnDelay == 0)
			{
				$Spoonbot::RespawnDelay = 30;    //No respawn delay set in spoonbot.cs ?? Ok, then assume 30 seconds.
			}
			
			//== INVENTORY STATION BOTS ==========================================================================
			
			if ((String::findSubStr(%aiName, "CMD") >= 0) || (String::findSubStr(%aiName, "NRS") >= 0))       //is it a bot bought at an inv. station?
			{
				if (String::findSubStr(%aiName, "Guard_CMD") >= 0)
					%bot = "Guard_CMD";
				else if (String::findSubStr(%aiName, "Mortar_CMD") >= 0)
					%bot = "Mortar_CMD";
				else if (String::findSubStr(%aiName, "Demo_CMD") >= 0)
					%bot = "Demo_CMD";
				else if (String::findSubStr(%aiName, "Medic_CMD") >= 0)
					%bot = "Medic_CMD";
				else if (String::findSubStr(%aiName, "Miner_CMD") >= 0)
					%bot = "Miner_CMD";
				else if (String::findSubStr(%aiName, "Sniper_CMD") >= 0)
					%bot = "Sniper_CMD";
				else if (String::findSubStr(%aiName, "Painter_CMD") >= 0)
					%bot = "Painter_CMD";
				else if (String::findSubStr(%aiName, "Runner_CMD") >= 0)
					%bot = "Runner_CMD";
				else if (String::findSubStr(%aiName, "Guard_NRS") >= 0)
					%bot = "Guard_NRS";
				else if (String::findSubStr(%aiName, "Mortar_NRS") >= 0)
					%bot = "Mortar_NRS";
				else if (String::findSubStr(%aiName, "Demo_NRS") >= 0)
					%bot = "Demo_NRS";
				else if (String::findSubStr(%aiName, "Medic_NRS") >= 0)
					%bot = "Medic_NRS";
				else if (String::findSubStr(%aiName, "Miner_NRS") >= 0)
					%bot = "Miner_NRS";
				else if (String::findSubStr(%aiName, "Sniper_NRS") >= 0)
					%bot = "Sniper_NRS";
				else if (String::findSubStr(%aiName, "Painter_NRS") >= 0)
					%bot = "Painter_NRS";
				else if (String::findSubStr(%aiName, "Runner_NRS") >= 0)
					%bot = "Runner_NRS";
				$TeamItemCount[%team @ %bot]--;
			}
			else if($IsDoppelganger[%aiId] <= 0)
			{
				schedule("AI::spawnAdditionalBot(" @ %aiName @ ", " @ %team @ ", False);", $Spoonbot::RespawnDelay );
				$DoNotRespawnAI = 0;
			}
		}
	}
	else
	{
		// just in case:
		dbecho( 2, "Non training callback called from Training" );
	}

}


//these AI function callbacks can be very useful!

function AI::onTargetDied(%aiName, %idNum)
{

	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;
	%curTarget = %idNum;

	%team=Client::getTeam(%aiId);
	if ($Spoonbot::BotChat)
	{
		%chatdelay = floor(getRandom() * (10 - 0.1));
		schedule("AI::RandomCheerMsg(" @ %aiName@ ", " @ %team @ ");", %chatdelay );
	}

	%animation = radnomItems(8, $PlayerAnim::Celebration1, $PlayerAnim::Celebration2, $PlayerAnim::Celebration3, $PlayerAnim::Taunt1, $PlayerAnim::Taunt2, $PlayerAnim::Wave, $PlayerAnim::OverHere, $PlayerAnim::Salute);
	BotFuncs::Animation(%aiId, %animation);

	BotFuncs::DelAttackerFromAll(%aiId);	// Wicked69
	$BotThink::Definitive_Attackpoint[%aiId] = "";
	$BotThink::ForcedOfftrack[%aiId] = True;

	if(%curTarget == -1)
	{
		return;
	}
      
	$Spoonbot::BotStatus[%aiId] = "Idle";
}                                 


function AI::onTargetLOSAcquired(%aiName, %idNum)
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;				//Sometimes, switching teams make your own bots chase you like an enemy. This is very
	%aiTeam = Client::getTeam(%aiId);	//strange, since switching to Observer mode and THEN to an other team does NOT produce this error.
	%targetTeam = Client::getTeam(%idNum);	//This is a quick hack so bots won't continue hunting you if you're in the same team
	if (%targetTeam != %aiTeam)
	{
	//	echo(%aiName @ " just spotted an enemy");
		AI::HuntTarget(%aiId, %idNum, 1);
	}
}


function AI::onTargetLOSLost(%aiName, %idNum)
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;
	%aiTeam = Client::getTeam(%aiId);
	%targetTeam = Client::getTeam(%idNum);
	if (%targetTeam != %aiTeam)
	{
	//	echo(%aiName @ " lost eye contact to enemy");
		AI::HuntTarget(%aiId, %idNum, 1);

		if ($Spoonbot::BotJetting[%aiId] != 1)
			AI::JetSimulation(%aiId, 0);

	}
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;
	%aiTeam = Client::getTeam(%aiId);
	%targetTeam = Client::getTeam(%idNum);
	if (%targetTeam != %aiTeam)
	{
	//	echo(%aiName @ " found the enemy again");
		AI::HuntTarget(%aiId, %idNum, 1);
		$SPOONBOT::AbortAIJet = %aiId;
	}
}




function AI::HuntTarget(%aiId, %idNum, %Follow) //If %Follow is 0 then waypoint will be updated. If 1 then Bot will follow regardless of LOS.
{
	if (%aiId==0)
		return;
	%aiName = Client::getName(%aiId);
	%curTarget = %idNum;

	if(%curTarget == -1)
		return;
      
//	echo(%aiName @ " target: " @ %curTarget);	
   
	%targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
	%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
	%targetDist = Vector::getDistance(%aiLoc, %targLoc);
//	dbecho(2, "distance to target: " @ %targetDist @ " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);


	if(String::findSubStr(%aiName, "Sniper") >= 0)
	{
		AI::SmartStayAway (%aiId, %idNum, %targLoc, %Follow, %targetDist, 80, 2);
	}

	else if(String::findSubStr(%aiName, "Painter") >= 0)
	{
		AI::SmartStayAway (%aiId, %idNum, %targLoc, %Follow, %targetDist, 80, 2);
	}

	else if(String::findSubStr(%aiName, "Guard") >= 0)
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 80, 2);
	}

	else if(String::findSubStr(%aiName, "Mortar") >= 0)
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 80, 2);
	}

	else if(String::findSubStr(%aiName, "Demo") >= 0)
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 50, 2);
	}

	else if(String::findSubStr(%aiName, "Medic") >= 0)
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 60, 2);
	}

	else if(String::findSubStr(%aiName, "Miner") >= 0)
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 30, 2);
	}
	
	//RUNNER BOT ADD IN.
	else if (String::findSubStr(%aiName, "Runner") >= 0)
	{
		AI::SmartStayAway (%aiId, %idNum, %targLoc, %Follow, %targetDist, 30, 2);
	}

	else
	{
		AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, 30, 2);
	}
}




//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//If %Follow = 0 the AI will try to keep a minimum distance of %mintargetDist. If the distance is greater, it will come closer.
//If %Follow = 1 then the AI will follow the target %idNum to oblivion
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking

function AI::SmartFollow (%aiId, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
	%aiName = Client::getName(%aiId);
	if (%Follow == 0)
	{
		if(%targetDist > %minTargetDist)
		{
			AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 
		}
		else
		{
//			AI::DirectiveRemove( %aiName, %order);
		}
	}
	else
	{
		if(%targetDist > %minTargetDist)
		{
			AI::DirectiveFollow( %aiName, %idNum, 0, %order );
		}
		else
		{
//			AI::DirectiveRemove( %aiName, %order);
		}
	}
}


//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//The AI will evade slightly until distance to enemy is < %mintargetDist.
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking

function AI::SmartStayAway (%aiId, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
	%aiName = Client::getName(%aiId);
	if (%Follow == 0)
	{
		if(%targetDist < %minTargetDist)
		{
			AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 
		}
		else
		{
//			AI::DirectiveRemove( %aiName, %order);
		}
	}
	else
	{
		if(%targetDist < %minTargetDist)
		{
			AI::DirectiveFollow( %aiName, %idNum, 0, %order );     
		}
		else
		{
//			AI::DirectiveRemove( %aiName, %order);
		}
	}
}




function AI::pickRandomSpawn(%team)
{
	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
	%count = Group::objectCount(%group);
	if(!%count)
	return -1;

	%spawnIdx = floor(getRandom() * (%count - 0.1));
	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) 
			return %obj;
		if(%i == %count - 1)
		{
			dbecho(1, "pickRandomSpawn error: You forgot to set Random Drop points in your map!");
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
	return false;
}

//The following Callback isn't called - only God knows why..
//modified by Werewolf

function AI::onCollision (%aiId, %object)
{

	%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
	%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
	%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 

	dbecho(1, "obstacle location" @ %targLoc);
	dbecho(1, "ai location" @ %aiLoc);
	dbecho(1, "ai rotation" @ %aiLoc);

	dbecho(1, "onCollision called in ai.cs");
	Vehicle::passengerJump(0,%aiId,0);  //Crude way to make players avoid obstacles
	Vehicle::passengerJump(0,%object,0);

}

function AI::DeployItem(%aiId,%desc)  //added by Werewolf. Yay I'm proud of this piece of code ;-)
{

	// List of deployable Items:
	//--------------------------
	//  DeployableAmmoPack
	//  DeployableInvPack
	//  TurretPack
	//  CameraPack
	//  DeployableSensorJammerPack
	//  PulseSensorPack
	//  MotionSensorPack
	//  Beacon

	%item = %desc;
	%player = %aiId;
	%aiName = Client::GetName(%aiId);

	// --------------------------------------
	// This doesn't work, so we have to do it manually.
	// --------------------------------------
	// Player::setItemCount(%aiId, %item, 1);
	// Player::deployItem(%aiId,%item);
	// --------------------------------------

	if (%item == "DeployableInvPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
			addToSet("MissionCleanup", %inv);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
			GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
			GameBase::setRotation(%inv,%rot);
			Gamebase::setMapName(%inv,%name);
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Inventory Station deployed");
			playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
			echo("MSG: ",%client," deployed an Inventory Station");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "DeployableAmmoPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
			addToSet("MissionCleanup", %inv);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
			GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
			GameBase::setRotation(%inv,%rot);
			Gamebase::setMapName(%inv,%name);
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Ammo Station deployed");
			playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
			echo("MSG: ",%client," deployed an Ammo Station");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "MotionSensorPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%inv = newObject("","Sensor","DeployableMotionSensor",true);
			addToSet("MissionCleanup", %inv);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
			GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
			GameBase::setRotation(%inv,%rot);
			Gamebase::setMapName(%inv,"Motion Sensor");
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Motion Sensor deployed");
			playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%inv) @ "MotionSensorPack"]++;
			echo("MSG: ",%client," deployed a Motion Sensor");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "PulseSensorPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%inv = newObject("","Sensor","DeployablePulseSensor",true);
			addToSet("MissionCleanup", %inv);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
			GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
			GameBase::setRotation(%inv,%rot);
			Gamebase::setMapName(%inv,"Pulse Sensor");
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Pulse Sensor deployed");
			playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%inv) @ "PulseSensorPack"]++;
			echo("MSG: ",%client," deployed a Pulse Sensor");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "DeployableSensorJammerPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%inv = newObject("","Sensor","DeployableSensorJammer",true);
			addToSet("MissionCleanup", %inv);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
			GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
			GameBase::setRotation(%inv,%rot);
			Gamebase::setMapName(%inv,"Sensor Jammer");
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Sensor Jammer deployed");
			playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableSensorJammerPack"]++;
			echo("MSG: ",%client," deployed a Sensor Jammer");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "CameraPack")
	{
		%client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%camera = newObject("Camera","Turret",CameraTurret,true);
			addToSet("MissionCleanup", %camera);
			%rot = GameBase::getRotation(%aiId); 
			GameBase::setTeam(%camera,GameBase::getTeam(%aiId));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,GameBase::getPosition(%aiId));
			Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Camera deployed");
			playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
			$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
			echo("MSG: ",%client," deployed a Camera");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

	if (%item == "TurretPack") //PeterT modified this.
	{
                %client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item])
		{
			%obj = getObjectType($los::object);
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableTurret",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if(0 == %num)
				{
					%rot = GameBase::getRotation(%aiId); 
					%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%aiId));
					GameBase::setPosition(%turret,GameBase::getPosition(%aiId));
					GameBase::setRotation(%turret,%rot);
					Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
					TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Sentry Turret deployed");
					playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
					$TeamItemCount[GameBase::getTeam(%aiId) @ "TurretPack"]++;
					echo("MSG: ",%client," deployed a Sentry Turret");
				} 
				else
					TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Frequency Overload - Too close to other sentry turrets");
			}
			else 
				TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Interference from other sentry turrets in the area");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}


	if (%item == "Beacon")
	{
                %client = Player::getClient(%aiId);
		if($TeamItemCount[GameBase::getTeam(%aiId) @ "TargetBeacon"] < $TeamItemMax[TargetBeacon])
		{
			%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%aiId));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,GameBase::getPosition(%aiId));
			Gamebase::setMapName(%beacon,"Target Beacon");
			Beacon::onEnabled(%beacon);
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Target Beacon deployed");
			$TeamItemCount[GameBase::getTeam(%beacon) @ "TargetBeacon"]++;
			echo("MSG: ",%client," deployed a Target Beacon");
		}
		else
			TeamMessages(2,GameBase::getTeam(%aiId),%aiName @ ": Deployable Item limit reached for " @ %item.description @ "s");
	}

}

function AI::RemoveBot(%aiName, %commandissuer)
{
	%aiId = BotFuncs::GetId( %aiName );
	if (%aiId==0)
		return;
	$DoNotRespawnAI = %aiId;
	Player::kill(%aiId);
}

function AI::buildGraph()
{
	echo("building AI Graph...");
	%nodeGroup = nameToID("MissionGroup\\AIGraph");
	%numNodes  = Group::ObjectCount(%nodeGroup);

	echo("nodeGroup: " @ %nodeGroup @ " number of Nodes: " @ %numNodes); 

	for(%i = 0; %i < %numNodes; %i++)
	{
		%node    = Group::getObject(%nodeGroup, %i);
		%nodePos = GameBase::getPosition(%node);
		%name = "Node " @ %i;
		if(name != "")
			Graph::AddNode(%nodePos, %name);
		else 
			Graph::AddNode(%nodePos);
	}
	if(Graph::buildGraph() == -1)
		echo("Can't create adjacent lists for graph nodes.");
	else
		echo("Graph build complete.");
}


//Render lines to show AI Graph
function drawGraph()
{
	newObject("graphRender", GraphPathRender);
}


function AI::RandomCheerMsg(%aiName, %team)
{
	%perChance = floor(getRandom() * (10 - 0.1));
	if (%perChance >= 8)
	{
		%aiId = BotFuncs::GetId( %aiName );
		if (%aiId==0)
		return;
		%enemyTeam = 1;
		if (%team == 1)
			%enemyTeam = 0;
	
		%msgIdx = floor(getRandom() * (8 - 0.1));
		%msgIdx1 = floor(getRandom() * (128 - 0.1));
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			Ai::soundHelper( %aiId, %cl, $vcheerList[%msgIdx] );
			Client::sendMessage(%cl, 2, %aiName @ ": " @ $cheerList[%msgIdx1], %aiId);
		}
	}
}



function AI::RandomSuckMsg(%aiName, %team)
{
	%perChance = floor(getRandom() * (10 - 0.1));
	if (%perChance >= 8 )
	{
		%aiId = BotFuncs::GetId( %aiName );
//		if (%aiId==0)
//			return;
		%msgIdx = floor(getRandom() * (8 - 0.1));
		%msgIdx1 = floor(getRandom() * (48 - 0.1));
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			Ai::soundHelper( %aiId, %cl, $vsuckList[%msgIdx] );
			Client::sendMessage(%cl, 2, %aiName @ ": " @ $suckList[%msgIdx1], %aiId);
		}
	}
}


//Moved ProcessAutoSpawn function.  Ganvit.

function AI::Jet(%aiId)
{
	%passenger = %aiId;
	%armor = Player::getArmor(%passenger);

	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%height = 15;
		%velocity = 70;
		%zVec = 40;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%height = 19;
		%velocity = 100;
		%zVec = 60;
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%height = 22;
		%velocity = 140;
		%zVec = 90;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	 {	
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}

}

function AI::Jump(%aiId)      //This function makes the AI jump. If %jet=1 then it Calls the Jetpack Routine
{
	%passenger = %aiId;
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{	
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
}




//ERROR, NOT ALL BOTS HELP WITH RETURNING THE FLAG SINCE THIS INFO WAS PUT UNDER RANDOM. Ganvit.

function AI::AttackRandomEnemy(%aiName)	//This function is for "Roaming" Bots to choose targets at will. By Werewolf
{
	%aiId = BotFuncs::GetId(%aiName);
	if (%aiId==0)
		return;

	if (!BotFuncs::CheckAlive(%aiId))
		return;

	%player = Client::getOwnedObject(%aiId);
	if (Player::isDead(%player))
		return;

	%newName = Client::getName(%aiId);
	if (%newName != %aiName)
		return;

	schedule("AI::RoamingBotsStartup(" @ %aiName @ ");", $Spoonbot::ThinkingInterval);    //Do this over and over again, as long as bot lives.

	%aiTeam = Client::getTeam(%aiId);
	%player = Client::getOwnedObject(%aiId);
	%hasFlag = Player::getItemCount(%player, Flag);

	if (%hasFlag != 0)	//If bot has the enemy's flag, get it to our flag
 	{
		%pos = ($teamFlag[%aiTeam]).originalPosition;
		%xPos = getWord(%pos, 0);
		%yPos = getword(%pos, 1);
		%zPos = getWord(%pos, 2);
		%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;//Dont know why almost all the AI::DirectiveWaypoints are blocked out.
//		AI::DirectiveWaypoint( %aiName, %flagPos, 2);
		echo(%aiName @ " tries to get the enemy's flag to our flag stand.");
		return;
	}

	if ($Spoonbot::BotsRetreat)
	{

		%player = Client::getOwnedObject(%aiId);
		%dlevel = GameBase::getDamageLevel(%player);
		if (%dlevel >= $Spoonbot::RetreatDamageLevel)      //If damage level exceeds maximum, let bot retreat.
		{
			%spawnMarker = AI::pickRandomSpawn(%aiTeam);
			if(%spawnMarker == -1)
			{
				%spawnPos = "0 0 300";
				%spawnRot = "0 0 0";
			}
			else
			{
				%spawnPos = GameBase::getPosition(%spawnMarker);
				%spawnRot = GameBase::getRotation(%spawnMarker);
			}

			%xPos = getWord(%spawnPos, 0);
			%yPos = getword(%spawnPos, 1);
			%zPos = getWord(%spawnPos, 2);
			%aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
//			AI::DirectiveWaypoint( %aiName, %aiSpawnPos, 2);
			echo(%aiName @ " is retreating!");
			return;
		}
	}

	if ($Spoonbot::HuntFlagrunner != 0)                   //If an enemy has our flag, let ALL of our bots attack him.
	{
		%cl = $Spoonbot::HuntFlagrunner;
		%aiTeam = Client::getTeam(%aiId);
		%targetTeam = Client::getTeam(%cl);
		if (%targetTeam != %aiTeam)           //Is this an enemy?
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				%enemyName = Client::getName(%cl);
				if (%enemyName != "")
				{
					echo(%aiName @ " is attacking the enemy flagrunner " @ %enemyName);
					AI::HuntTarget(%aiName, %cl, 1);
					return;
				}
			}
		}
		else	//else this is a friendly, so let's escort him to safety.
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				%enemyName = Client::getName(%cl);
				if (%enemyName != "")
				{
					echo(%aiName @ " is escorting the friendly flagrunner " @ %enemyName);
					AI::HuntTarget(%aiName, %cl, 1);  //The procedure is the same, except the friendly bot won't fire on the flagrunner
					return;
				}
			}
		}
	}

	%spawnIdx = floor(getRandom() * ($Spoonbot::NumBots - 0.1));  //Add a random variation to the target selection

//	%startCl = Client::getFirst() + %spawnIdx;  //This has caused the bots to not attack unless a player is present.
	%startCl = 2049 + %spawnIdx;                //This is by EMO1313 who told me about it. Thanks EMO1313 !!

	%endCl = %startCl + 90;
	for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
	{
		%aiTeam = Client::getTeam(%aiId);
		%targetTeam = Client::getTeam(%cl);

		if (%targetTeam != %aiTeam)              //Is this an enemy?
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				%enemyName = Client::getName(%cl);
				if (%enemyName != "")
				{
					echo(%aiName @ " has decided to attack " @ %enemyName);
					AI::HuntTarget(%aiName, %cl, 1);
					return;
				}

				//ERROR. STILL UNDER RANDOM, THIS NEEDS TO BE PLACES SOMEWHERE ELSE IN THE CODE.

				else	//If somehow we can't find an enemy, try to capture the flag
				{
			                //find out the enemy team's teamnumber
					if(%aiTeam == 3)
						%EnemyTeam = 2;
					else if(%aiTeam == 2)
						%EnemyTeam = 1;
					else if(%aiTeam == 1)
						%EnemyTeam = 0;
					else
					%EnemyTeam = getNumTeams() - 1;
	
					%pos = ($teamFlag[%enemyTeam]).originalPosition;
					%xPos = getWord(%pos, 0);
					%yPos = getword(%pos, 1);
					%zPos = getWord(%pos, 2);
					%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
//					AI::DirectiveWaypoint( %aiName, %flagPos, 2);         //Head for the flag. NOTE: The bot will still attack all
//					AI::DirectiveWaypoint( %aiName, %flagPos, 125);       //enemies he encounters. I still need to make him concentrate
					echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
					return;
				}
			}
		}
	}

	echo(%aiName @ " could not find any enemies!");

}


//GOOD PLACE TO PLACE A BOT BRAIN!!!

function AI::RoamingBotsStartup(%aiName)         //Checks if %aiName is a roaming bot, and handles it's target selection. By Werewolf
{
	if(String::findSubStr(%aiName, "CMD") < 0)        //is it a roaming bot?
	{
		AI::AttackRandomEnemy(%aiName);	//Yes, so choose an enemy to attack.
	}					//A "bot-brain" could be implemented here someday, so bots can decide if they're
						//healthy enough to attack, and such stuff.
}


// These vector operations are something I am quite proud of.
// They're still in AI.CS and not in BotFuncs.cs because they can be applied on human players too.
// Werewolf

function AI::shove(%aiId, %velocity, %zVec, %rotX, %rotY, %rotZ)
{
	%passenger = %aiId;
	%armor = Player::getArmor(%passenger);
	if(%armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = %velocity * 0.80;
		%zVec = %zVec * 0.80;
	}
	else if(%armor == "larmor" || %armor == "lfemale")
	{
		%velocity = %velocity * 0.90;
		%zVec = %zVec * 0.90;
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		%velocity = %velocity * 0.95;
		%zVec = %zVec * 0.95;
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		%velocity = %velocity * 1.00;
		%zVec = %zVec * 1.00;
	}
	else if(%armor == "harmor")
	{
		%velocity = %velocity * 1.05;
		%zVec = %zVec * 1.05;
	}
	else if(%armor == "uharmor")
	{
		%velocity = %velocity * 1.10;
		%zVec = %zVec * 1.10;
	}

//	%player = Client::getOwnedObject(%aiId);	
//	%hasFlag = Player::getItemCount(%player, Flag);
//	if (%hasFlag != 0)
//	{
//		%velocity = %velocity * 1.20;
//		%zVec = %zVec * 1.20;
//	}

	%OldrotX = getWord(GameBase::getRotation(%passenger),0);
	%OldrotY = getWord(GameBase::getRotation(%passenger),1);
	%OldrotZ = getWord(GameBase::getRotation(%passenger),2);
	%rotation = (%OldrotX + %rotX) @ " " @ (%OldrotY + %rotY) @ " " @ (%OldrotZ + %rotZ);
	GameBase::setRotation(%passenger, %rotation);
	%jumpDir = Vector::getFromRot(%rotation, %velocity, %zVec);
	Player::applyImpulse(%passenger,%jumpDir);
}

function AI::EvadeBack(%aiId) // Ganvit, this function doesn't appear to do anything at the moment. - PeterT
{
	%passenger = (%aiId);
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = -85;
		%zVec = 100;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = -105;
		%zVec = 150;
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -150;
		%zVec = 200;
	}
	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	//schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, -90, 0);", 1);		
}

//These could be adjusted for maximum bot ability.
function AI::EvadeUp(%aiId)         //For climbing towers, one powerful jump back, and one forward after 1 second
{	
	%passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = -85;
		%zVec = 100;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 100;//Verry nice, really helps the bot get up there. Ganvit
		%zVec = 100;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 0);", 1);		
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = -75;
		%zVec = 175;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 100;
		%zVec = 150;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 0);", 1);
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -100;
		%zVec = 200;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 150;
		%zVec = 200;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 0);", 1);
	}
}


function AI::EvadeBackLeft(%aiId)   //Turn back, then left and try again.
{
	%passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = -50;
		%zVec = 60;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 70;
		%zVec = 60;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, -1.6);", 1);		
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = -100;
		%zVec = 100;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 150;
		%zVec = 100;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, -1.6);", 1);
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -150;
		%zVec = 200;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 200;
		%zVec = 200;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, -1.6);", 1);
	}
}

function AI::EvadeBackRight(%aiId)  //Turn back, then right and try again.
{
	%passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = -50;
		%zVec = 60;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 70;
		%zVec = 60;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 1.6);", 1);		
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = -100;
		%zVec = 100;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 150;
		%zVec = 100;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 1.6);", 1);
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -150;
		%zVec = 200;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);

		%velocity = 200;
		%zVec = 200;
		schedule("AI::shove(" @ %aiId @ ", " @ %velocity @ ", " @ %zVec @ ", 0, 0, 1.6);", 1);
	}
}

function AI::EvadeLeft(%aiId)       //Jump left
{
	%passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = 70;
		%zVec = 50;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, -1.6);		
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = 120;
		%zVec = 100;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, -1.6);
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -200;
		%zVec = 175;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, -1.6);
	}
}

function AI::EvadeRight(%aiId)      //Jump left
{
	%passenger = %aiId;
        %armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale" || %armor == "hlarmor" || %armor == "hlfemale")
	{
		%velocity = 70;
		%zVec = 50;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 1.6);		
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "earmor" || %armor == "efemale")
	{
		%velocity = 120;
		%zVec = 100;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 1.6);
	}
	else if(%armor == "harmor" || %armor == "uharmor")
	{
		%velocity = -200;
		%zVec = 175;
		AI::shove(%aiId, %velocity, %zVec, 0, 0, 1.6);
	}
}

//ADDED RANDOM EVADE
function AI::RandomEvade(%aiId)      //Do anything of the above, randomly.
{
	if ($Spoonbot::DebugMode)
		echo ("CALL AI::RandomEvade(" @ %aiId @ ");");

	%evadeIdx = floor(getRandom() * (5 - 0.1));  // five possibilities

	if ($Spoonbot::DebugMode)
		echo ("STATUS AI::RandomEvade = EvadeIdx=" @ %evadeIdx );

	if (%evadeIdx == 0)
		AI::EvadeUp(%aiId);
	else if (%evadeIdx == 1)
		AI::EvadeBackRight(%aiId);
	else if (%evadeIdx == 2)
		AI::EvadeBackLeft(%aiId);
	else if (%evadeIdx == 3)
		AI::EvadeLeft(%aiId);
	else if (%evadeIdx == 4)
		AI::EvadeRight(%aiId);
	else if (%evadeIdx == 5)
		AI::EvadeBackLeft(%aiId);
	else if (%evadeIdx == 6)
		AI::EvadeBackRight(%aiId);

	return;
}


//The following function comes very close to human players jetting physics. This function calls itself over and over,
//each time applying a small amount of upward thrust to the AI. The variable "phase" is being increased with each call.
//The jetting time is limited, just like for human players.
//To make an AI start jetting, issue this function with "phase" set to 0. Then, this procedure will call itself every 0.5 seconds,
//each time increasing the "phase" variable.
//The AI will jet until "phase" = 6. Then, the AI will begin descending, while the descend speed is kept nominal by short thrusts 
//every 1 second. This prevents injuries.


//Note that once the jetting has started, the whole sequence is being executed. To STOP a jetting maneuver, set the 
//variable $SPOONBOT::StopAIJet to the aiId of the bot you want to stop jetting. If the jetting is being aborted, this function will
//set the "phase" variable to 6, thus starting to descend.


//What's the magic with AbortJet? Or better yet: What's the difference between STOPPING and ABORTING a jet maneuver?
//Well, let's assume you  want to issue a jet command, and don't know if the AI is already in the process of jetting. 
//You need to ABORT the first jetting, and schedule the NEW jetting command 1 or 2 seconds afterwards.
//This keeps the bots from climbing into the stratosphere.

//THIS IS A TOTALLY MODIFIED FROM STORMBOTS ORIGINAL.

function AI::JetSimulation(%aiId, %phase)         // Makes an AI jet like a real player.
{
	if(%aiId.outArea==1)	
		leaveMissionAreaDamage(%aiId);

	if ($Spoonbot::DebugMode)
		echo ("STATUS AI::JetSimulation = in Phase " @ %phase @ " for bot " @ %aiId @ ". BotJetting is " @ $Spoonbot::BotJetting[%aiId]);

	if ($SPOONBOT::StopAIJet == %aiId)  //To stop a jet, set $SPOONBOT::StopAIJet to the aiId you want to stop jetting
	{
		if (%phase < 6 )
			%phase = 6;			     //Just skip the climb phases, and start to descend
 		$SPOONBOT::StopAIJet = 0;
 	}

	if ($SPOONBOT::AbortAIJet == %aiId)  //AbortJet is similar to StopJet, only there will be no controlled descend afterwards
	{
		$SPOONBOT::AbortAIJet = 0;
		return;			     //When Aborting, the function will kill itself immediately.
	}

	$Spoonbot::BotJetting[%aiId] = 1;

	%velocity = 20;
	%zVec = 100;
	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	%phase = %phase + 1;

	if (%phase < 6)
	{
		$Spoonbot::BotJettingHeat[%aiId] = 1;
		schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 0.5);  //First 6 phases: climb
		return;
	}

	$Spoonbot::BotJettingHeat[%aiId] = 0;  //The BotJettingHeat is only 1 if we're in climbing phase. This is for rocket turrets.

	if (%phase < 10)
	{
		schedule("AI::JetSimulation(" @ %aiId @ ", " @ %phase @ ");", 1);    //After climbing, do a controlled descend.
		return;
	}

	$Spoonbot::BotJetting[%aiId] = -1;

	// if "phase" exceeds 10, then this function will simply stop keeping itself alive.
	return;
}

function AI::JetToHeight(%aiId, %height, %phase)         // Makes an AI jet to a specified height. Here the phase variable is only for INTERNAL use!
{
	$Spoonbot::BotJetting[%aiId] = -1;
	$Spoonbot::BotJettingHeat[%aiId] = 0;

	%AiPos = GameBase::getPosition(%aiId);
	%zPos = getWord(%AiPos, 2);

	//If we reached our height, stop jetting and abort this function.
	//I tried a new trick here: I stop the jetting sooner if the bot already has a great upward speed.

	if (%phase >=8)
	{
		if ((%zPos+6) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}

	if (%phase >=6)
	{
		if ((%zPos+5) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}

	if (%phase >=4)
	{
		if ((%zPos+4) >= %height)
		{
			%phase = 0;
			%velocity = 50;
			%zVec = 50;
			AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
			return;
		}
	}


	$Spoonbot::BotJetting[%aiId] = 1;
	$Spoonbot::BotJettingHeat[%aiId] = 1;  //These vars make turrets track the jetting bots, and avoid "double-jetting"

	%velocity = 0;  //This is the forward velocity.

	%zVec = 150;

	AI::shove(%aiId, %velocity, %zVec, 0, 0, 0);
	%phase = %phase + 1;

	schedule("AI::JetToHeight(" @ %aiId @ ", " @ %height @ ", " @ %phase @ ");", 0.3); 
	
	//Reschedule this until bot reaches %height.

	return;
}
