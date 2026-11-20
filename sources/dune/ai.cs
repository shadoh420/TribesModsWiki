$QuietGholas = 1;

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
$AI::defaultPathType = 2; //run twoWay paths

//armor types
//light = larmor
//medium = marmor
//heavy = harmor
$AI::defaultArmorType = "larmor";

//
//---------
// Attack Modes
// 0 = charge
// 1 = continue directive while firing
// 2(anything) = stay in position and fire
 

//---------------------------------
//createAI()
//---------------------------------
function createAI( %aiName, %markerGroup, %armorType, %name )
{

   %group = nameToID( %markerGroup );


   if(!$IsGhola[%aiName])  {
   if( %group == -1 || Group::objectCount(%group) == 0 )
   {
      dbecho(1, %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
      return -1;
   }
   else
   {
      %spawnMarker = Group::getObject(%group, 0);
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);

      if( AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" ) != "false" )
      {
         // The order number is used for sorting waypoints, and other directives.  
         %orderNumber = 100;
         
         for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);
            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );
            
            %orderNumber += 100;
         }
      }
      else{
         dbecho( 1, "Failure spawning: " @ %aiName );
      }
   }
   }
}


//----------------------------------
// AI::setupAI()
//
// Called from Mission::init() which is defined in Objectives.cs (or Dm.cs for
//    deathmatch missions).  
//----------------------------------   
function AI::setupAI(%key, %team)
{
   //if there is no key then they don't exist yet
   if(%key == "")
   {
      %aiFound = 0;
      for( %T = 0; %T < 8; %T++ )
      {
         %groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI" );
         if( %groupId != -1 )
         {
            %teamItemCount = Group::objectCount(%groupId);
            if( %teamItemCount > 0 )
            {
               AI::initDrones(%T, %teamItemCount);
               %aiFound += %teamItemCount;
            }
         }
      }
      //check for Graph information
      if(nameToId("MissionGroup\\AIGraph") != -1)
      	AI::buildGraph();
      else
         echo("No Graph info to build AI Graph!");
      
      if( %aiFound == 0 )
         dbecho(1, "No drones exist...");
      else
         dbecho(1, %aiFound @ " drones installed..." );
   }
   else     //respawning dead AI with original name and path
   {
      %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %key);
      %num = Group::objectCount(%group);

      createAI(%key, %group, $AI::defaultArmorType, %key);

      %aiId = AI::getId(%key);
      GameBase::setTeam(%aiId, %team);
      AI::setVar(%key, pathType, $AI::defaultPathType);
      AI::setWeapons(%key);
      
   }		
}

//------------------------------
// AI::setWeapons()
//------------------------------
function AI::setWeapons(%aiName)
{
	%aiId = AI::getId(%aiName);
	
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, chaingun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, bulletAmmo, 50000);
   }
   
   Player::mountItem(%aiId, blaster, 0);
   AI::SetVar(%aiName, triggerPct, 0.03 );
   AI::setVar(%aiName, iq, 70 );
   AI::setVar(%aiName, attackMode, 1);
   AI::setAutomaticTargets( %aiName );
   ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}


//-----------------------------------
// AI::periodicWeaponChange()
//-----------------------------------
function ai::periodicWeaponChange(%aiName)
{
	dbecho(2, %aiName @ " thinking....");
   %aiId = AI::getId(%aiName);
   %curTarget = ai::getTarget( %aiName );
   
   if(%curTarget == -1)
   {
   	return;
   }
      
   dbecho(1, %aiName @ " target: " @ %curTarget);	
   
   %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %targetDist = Vector::getDistance(%aiLoc, %targLoc);
   dbecho(2, "distance to target: " @ %targetDist @ 
                  " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);
                  
   if(%targetDist > 100)
   {
   	Player::mountItem(%aiId, blaster, 0);
      AI::SetVar(%aiName, triggerPct, 0.03 );
   }   
   else
   {
      dbecho(2, "checking for target jet...");
      dbecho(2, "jetting? " @ Player::isJetting(%curTarget));
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, Chaingun, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, disclauncher, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
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
      %tempSet = 	nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
      %tempItem = Group::getObject(%tempSet, %guard);
      %aiName = Object::getName(%tempItem);
      
      %set = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %aiName);
      %numPts = Group::objectCount(%set);
      
      if(%numPts > 0)
      {
         createAI(%aiName, %set, $AI::defaultArmorType, %aiName);
         %aiId = AI::getId( %aiName );
         GameBase::setTeam(%aiId, %team);
         AI::setVar( %aiName,  iq,  60 );
         AI::setVar( %aiName,  attackMode, 1);
         AI::setVar( %aiName,  pathType, $AI::defaultPathType);
      	schedule("AI::setWeapons(" @ %aiName @ ");", 1);
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
//This function will spawn a Ghola
//
//

function AI::GholaSpawn(%aiName, %armorType, %commandIssuer, %pos, %rot)
{
   dbecho(2, "Spawning AI helper at position " @ %pos);
   dbecho(2, "Spawning AI helper on rotation: " @ %rot);
      
   $numAI++;
   if( %armorType == sarmor2 || %armorType == ssarmor2 || %armorType == barmor2 || %armorType == bbarmor2 )
	%armorType = $ArmorType[Male, $ArmorName[sarmor]];

   if( %armorType == sfemale2 || %armorType == ssfemale2 || %armorType == bfemale2 || %armorType == bbfemale2 )
	%armorType = $ArmorType[Female, $ArmorName[sarmor]];
	$GholaSilence = $QuietGholas;
   Ai::spawn(%aiName, %armorType, %pos, %rot);
	$GholaSilence = 0;
   Ghola::SetWeapons(%aiName, %armorType);
   AI::setVar( %aiName,  iq,  50 + floor(getRandom() * 100) );
   AI::setVar( %aiName, pathType, 1);
   AI::SetVar(%aiName, triggerPct, 1.0 );
   	
   Ghola::Stance( %aiName, 1 );
   Ghola::Stance( %aiName, 7 );

   Ghola::SetFormation( %aiName, "File", 2);
   Ghola::KeepFormation(%aiName);
   $gholadead[%aiName] = false;

   return ( %aiName );
}




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
   %zPos = getWord(%spawnMarker, 2) + 2;
   %rPos = GameBase::getRotation(%commandIssuer);
   
   dbecho(2, "Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
   dbecho(2, "Current Issuer rotation: " @ %rPos);
      
   %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
   %newName = %aiName @ $numAI;
   $numAI++;
   Ai::spawn(%newName, %armorType, %aiSpawnPos, %rPos);
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
	  AI::DirectiveWaypoint( %aiName, %newIssuedVec, 1 );
   }
   else
      dbecho(2, "Distance to far.");
      
   dbecho(2, "LOS point: " @ $LOS::position);
}

//This function will move an AI player to a position directly in front of
//the player passed, at a distance that is specified.
function  AI::moveAhead(%aiName, %commandIssuer, %distance) 
{
   
   %issuerRot = GameBase::getRotation(%commandIssuer);
   %commPos  = GameBase::getPosition(%commandIssuer);
   dbecho(2, "Commanders Position: " @ %commPos);
   
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
   dbecho(2, "AI moving to " @ %newPos);
   AI::DirectiveWaypoint(%aiName, %newPos, 1);
}  

//
// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//
function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{
   %aiId = AI::getId( %name );
   %T = GameBase::getTeam( %aiId );
   %groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI\\" @ %name ); 
  	%nodeCount = Group::objectCount( %groupId );
   dbecho(2, "checking drone information...." @ " number of nodes: " @ %nodeCount);
   dbecho(2, "AI id: " @ %aiId @ " groupId: " @ %groupId);
   
   if($SinglePlayer || %nodeCount == 1)
   {
	   if( %command == 2 || %command == 1 )
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  
	      %worldLoc = WaypointToWorld ( %waypoint );
	      AI::DirectiveWaypoint( %name, %worldLoc, 125 );
	      dbecho ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
	   }
	   dbecho( 2, "AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
	   dbecho( 3, "Cmdr:        " @ %commander );
	   dbecho( 3, "Command:     " @ %command );
	   dbecho( 3, "Waypoint:    " @ %waypoint );
	   dbecho( 3, "TargetId:    " @ %targetId );
	   dbecho( 3, "cmdText:     " @ %cmdText );
	   dbecho( 3, "cmdStatus:   " @ %cmdStatus );
	   dbecho( 3, "cmdSequence: " @ %cmdSequence );
   }
   else
   	return;   
}


// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, 2049, cheer3 );
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


// Default periodic callback.  [Note by default it isn't called unless a frequency 
//    is set up using AI::CallbackPeriodic().  Type in that command to see how 
//    it works].  
function AI::onPeriodic( %aiName )
{
   dbecho(2, "onPeriodic() called with " @ %aiName );
}


function AI::onDroneKilled(%aiName)
{
if( !$IsGhola[%aiName] ) {
   if( ! $SinglePlayer )
   {
      %aiId = AI::getId(%aiName);
      %team = GameBase::getTeam(%aiId);
      dbecho(2, "AI Id: " @ %aiId);
      
      // Trying a little longer delay -
      schedule("AI::setupAI(" @ %aiName @ ", " @ %team @ ");", 8 );
   }
   else
   {
      // just in case:
      dbecho( 2, "Non training callback called from Training" );
   }
} else {
	$AI::AwareOfTarget[%ainame, %idNum] = false;
   	$GholaOwned[$GholaOwner[%aiName]]--;
	$gholaDead[%ainame] = true;
	for(%x = 1; %x <= $GholaOwnedMax; %x++ ) {
	   if( $OwnedGholaList[$GholaOwner[%aiName], %x] == %ainame ) {
		$OwnedGholaList[$GholaOwner[%aiName], %x] = "";
	   }
	}
}
}


function AI::buildGraph(%argv)
{
	
   if(!%argv)
   {
	   echo("building AI Graph...");
	   $nodeGroup = nameToID("MissionGroup\\AIGraph");
	   %numNodes  = Group::ObjectCount($nodeGroup);
	   echo("nodeGroup: " @ %nodeGroup @ " number of Nodes: " @ %numNodes); 
   }
   else
   {
	   echo("rebuilding AI Graph...");
	   %numNodes  = Group::ObjectCount($nodeGroup);
   }
   
   for(%i = 0; %i < %numNodes; %i++)
   {
   	%node = Group::getObject($nodeGroup, %i);
      %nodePos = GameBase::getPosition(%node);
      %type = GameBase::getDataName(%node);
      %name = "Node " @ %i;
      Graph::AddNode(%nodePos, %name);
   }
   if(%numNodes > 0)	
   {   
      Graph::buildGraph();
      echo("Graph build complete.");
   }
   else
   	echo("No nodes to build graph.");
}


function AI::rebuildGraph()
{
	Graph::reset();
   AI::graphOff();
   focusServer();
   AI::buildGraph("true");
   focusClient();
   AI::GraphOn();
}

//these AI function callbacks can be very useful!
function AI::onTargetLOSAcquired(%aiName, %idNum)
{
// Three levels:
// Passive = stand and fire. Do not move.
// Standard = stand and fire until in melee range.
// Aggressive = charge. fire until in melee range.
//	AI::DirectiveWaypoint( %aiName, %newIssuedVec, 1 );
 	
//	%aiId = AI::getId(%aiName);
  
//****CAUSES AIS TO STALL****    	
//	if($GholaHating[%aiName] == Client::Getname(Client::getOwnedObject(%idNum))) {
//		AI::DirectiveTargetPoint(%aiName, gamebase::Getposition(%idNum), 0, 2);
//echo("True1");
//	} else if($GholaStance[%aiName] == "Aggresive") {
//echo("True2");
//		AI::DirectiveTargetPoint(%aiName, gamebase::Getposition(%idNum), 0, 2);
//	}
//***************************


//	%targLoc = GameBase::getPosition(Client::getOwnedObject(%idnum));
//   	%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
//   	%targetDist = Vector::getDistance(%aiLoc, %targLoc);
	
//	if( %targetDist < 10 ) 
//	{
//		Ghola::ShieldOn( %aiName );
//		Ghola::Meleeweap(%aiName);
//	} else if( %targetDist > 10 )
//	{
//		if( $ShieldOn[Client::getOwnedObject(%aiId)] ) {
//			Ghola::ShieldOn( %aiName );
//		}
//		Ghola::MeleeWeap(%aiName);
//	}
	$AI::AwareOfTarget[%ainame, %idNum] = true;
	
	if($GholaStance3D[%aiName] == "melee")
	{
		if( !$ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::Meleeweap(%aiName);
	} else if($GholaStance3D[%aiName] == "ranged")
	{
		if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::DistWeap(%aiName);
	}

	AI::updateTargetLoc(%aiName, %idNum);


}

function AI::onTargetDied(%aiName, %idNum)
{
	$AI::AwareOfTarget[%ainame, %idNum] = false;
	if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
	}


}                                 

function AI::onTargetLOSLost(%aiName, %idNum)
{
	$AI::AwareOfTarget[%ainame, %idNum] = false;

	if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
	}

}


function AI::onTargetLOSRegained(%aiName, %idNum)
{
	$AI::AwareOfTarget[%ainame, %idNum] = true;
	//AI::updateTargetLoc(%aiName, %idNum);
	if($GholaStance3D[%aiName] == "melee")
	{
		if( !$ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::Meleeweap(%aiName);
	} else if($GholaStance3D[%aiName] == "ranged")
	{
		if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::DistWeap(%aiName);
	}


}

function AI::updateTargetLoc(%aiName, %idNum)
{
	//echo(%ainame);
	if(!$gholadead[%aiName]){
		%targetDist = vector::getdistance(gamebase::Getposition(AI::getId(%aiName)), gamebase::Getposition(%idNum));
		%WaypntDist = vector::getdistance(gamebase::Getposition(AI::getId(%aiName)), $GholaWayPoint[%aiName]);

		if($AI::AwareOfTarget[%ainame, %idNum] 
		&& ai::getTarget( %aiName ) == %idNum
		&& ( $GholaStance[%aiName] == "aggressive" || ( $GholaStance[%aiName] == "standard" && %targetDist < 10) )
		&& !$GholaMaintainDist[%aiName] )
		{			
			if( %targetDist < 10) 
			{
				if( !$ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]  && $GholaStance3D[%aiName] == "mixed") {
					Ghola::ShieldOn( %aiName );
				}
				Ghola::Meleeweap(%aiName);
			} else if( %targetDist > 10)
			{
				if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]  && $GholaStance3D[%aiName] == "mixed") {
					Ghola::ShieldOn( %aiName );
				}
				Ghola::DistWeap(%aiName);
			}
			

			AI::setVar( %ainame,  attackMode, 1);
			AI::DirectiveWaypoint( %aiName, gamebase::Getposition(%idNum), 1 );


		}
		schedule ("AI::updateTargetLoc( \"" @ %aiName @ "\",\"" @ %idNum @ "\");",0.1);
	}


}

//Render lines to show AI Graph
$AI::testGraph = 0;
function AI::GraphOn(){
   if( $AI::testGraph == 0 ){
   	$AI::testGraph = newObject( "graphRender", AI::GraphPathRender );
      echo("Graph render on");
   }
   else{
      echo("Graph render ALREADY on");
   }
}
function AI::GraphOff(){
   if( $AI::testGraph != 0 ){
   	deleteObject( $AI::testGraph );
      $AI::testGraph = 0;
   	echo("Graph render off");
   }
   else{
      echo("Graph render ALREADY off");
   }
}


function AI::testingCommander()
{
   %clientId = "2049";
   AI::helper("jettkiller", harmor, %clientId);
   %aiId = "2050";
   GameBase::setTeam(%aiId, 0);
   AI::callWithId(%aiId, Player::setItemCount, Mortar, 1);
	AI::callWithId(%aiId, Player::setItemCount, MortarAmmo, 10000);
   AI::callWithId(%aiId, Player::mountItem, mortar, 0);
   AI::DirectiveTargetLaser( %aiId, %clientId );
}


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//  Ghola Section
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

function Ghola::SetWeapons(%aiName, %armorType)
{
	%aiId = AI::getId(%aiName);

	if( $ArmorName[%armorType] == SoldierArmor)
	{
		if(checkResources(%aiId, Knife, 1,True)) {
			teamEnergyBuySell(%aiId, Knife.price);
			Player::setItemCount(%aiId, Knife, 1);
		}
		if(checkResources(%aiId, Pistol, 1,True)) {
			teamEnergyBuySell(%aiId, Pistol.price);
			Player::setItemCount(%aiId, Pistol, 1);
		}
		if(checkResources(%aiId, Cutteray, 1,True)) {
			teamEnergyBuySell(%aiId, Cutteray.price);
			Player::setItemCount(%aiId, Cutteray, 1);
		}
		if(checkResources(%aiId, pistolclip, 3,True)) {
			teamEnergyBuySell(%aiId, pistolclip.price*3);
			Player::setItemCount(%aiId, pistolclip, 3);
		}
		if(checkResources(%aiId, pistolammo, 12,True)) {
			teamEnergyBuySell(%aiId, pistolammo.price*12);
			Player::setItemCount(%aiId, pistolammo, 12);
		}
		if(checkResources(%aiId, cutteraycell, 3,True)) {
			teamEnergyBuySell(%aiId, cutteraycell.price*3);
			Player::setItemCount(%aiId, cutteraycell, 3);
		}
		if(checkResources(%aiId, cutterayAmmo, 1,True)) {
			teamEnergyBuySell(%aiId, cutterayAmmo.price*25);
			Player::setItemCount(%aiId, cutterayAmmo, 25);
		}
		if(checkResources(%aiId, shieldpack, 1,True)) {
			teamEnergyBuySell(%aiId, shieldpack.price);
			Player::setItemCount(%aiId, shieldpack, 1);
		}
		Player::useItem(%aiId,Knife);
		Player::useItem(%aiId,shieldpack);									 
		   
	} else if( $ArmorName[%armorType] == TrooperArmor)
	{
		if(checkResources(%aiId, Kindjal, 1,True)) {
			teamEnergyBuySell(%aiId, Kindjal.price);
			Player::setItemCount(%aiId, Kindjal, 1);
		}
		if(checkResources(%aiId, Pistol, 1,True)) {
			teamEnergyBuySell(%aiId, Pistol.price);
			Player::setItemCount(%aiId, Pistol, 1);
		}
		if(checkResources(%aiId, RLauncher, 1,True)) {
			teamEnergyBuySell(%aiId, RLauncher.price);
			Player::setItemCount(%aiId, RLauncher, 1);
		}
		if(checkResources(%aiId, pistolclip, 3,True)) {
			teamEnergyBuySell(%aiId, pistolclip.price*3);
			Player::setItemCount(%aiId, pistolclip, 3);
		}
		if(checkResources(%aiId, pistolammo, 12,True)) {
			teamEnergyBuySell(%aiId, pistolammo.price*12);
			Player::setItemCount(%aiId, pistolammo, 12);
		}
		if(checkResources(%aiId, RLauncherAmmo, 2,True)) {
			teamEnergyBuySell(%aiId, RLauncherAmmo.price*2);
			Player::setItemCount(%aiId, RLauncherAmmo, 2);
		}
		if(checkResources(%aiId, shieldpack, 1,True)) {
			teamEnergyBuySell(%aiId, shieldpack.price);
			Player::setItemCount(%aiId, shieldpack, 1);
		}
		Player::useItem(%aiId,Kindjal);
		Player::useItem(%aiId,shieldpack);
											 
	} else if( $ArmorName[%armorType] == FremenArmor)
	{
		if(checkResources(%aiId, Crysknife, 1,True)) {
			teamEnergyBuySell(%aiId, Crysknife.price);
			Player::setItemCount(%aiId, Crysknife, 1);
		}
		if(checkResources(%aiId, SniperRifle, 1,True)) {
			teamEnergyBuySell(%aiId, SniperRifle.price);
			Player::setItemCount(%aiId, SniperRifle, 1);
		}
		if(checkResources(%aiId, RLauncher, 1,True)) {
			teamEnergyBuySell(%aiId, RLauncher.price);
			Player::setItemCount(%aiId, RLauncher, 1);
		}
		if(checkResources(%aiId, SniperClip, 4,True)) {
			teamEnergyBuySell(%aiId, SniperClip.price*4);
			Player::setItemCount(%aiId, SniperClip, 4);
		}
		if(checkResources(%aiId, SniperAmmo, 3,True)) {
			teamEnergyBuySell(%aiId, SniperAmmo.price*3);
			Player::setItemCount(%aiId, SniperAmmo, 3);
		}
		if(checkResources(%aiId, RLauncherAmmo, 3,True)) {
			teamEnergyBuySell(%aiId, RLauncherAmmo.price*3);
			Player::setItemCount(%aiId, RLauncherAmmo, 3);
		}
		if(checkResources(%aiId, SensorJammerPack, 1,True)) {
			teamEnergyBuySell(%aiId, SensorJammerPack.price);
			Player::setItemCount(%aiId, SensorJammerPack, 1);
		}
		Player::useItem(%aiId,CrysKnife);
		Player::useItem(%aiId,SensorJammerPack);									 
	} else if( $ArmorName[%armorType] == FedaykinArmor)
	{
		if(checkResources(%aiId, Crysknife, 1,True)) {
			teamEnergyBuySell(%aiId, Crysknife.price);
			Player::setItemCount(%aiId, Crysknife, 1);
		}
		if(checkResources(%aiId, SniperRifle, 1,True)) {
			teamEnergyBuySell(%aiId, SniperRifle.price);
			Player::setItemCount(%aiId, SniperRifle, 1);
		}
		if(checkResources(%aiId, Pistol, 1,True)) {
echo("Pistol buying");
			teamEnergyBuySell(%aiId, Pistol.price);
			Player::setItemCount(%aiId, Pistol, 1);
		}
		if(checkResources(%aiId, SniperClip, 4,True)) {
			teamEnergyBuySell(%aiId, SniperClip.price*4);
			Player::setItemCount(%aiId, SniperClip, 4);
		}
		if(checkResources(%aiId, SniperAmmo, 3,True)) {
			teamEnergyBuySell(%aiId, SniperAmmo.price*3);
			Player::setItemCount(%aiId, SniperAmmo, 3);
		}
		if(checkResources(%aiId, pistolclip, 3,True)) {
			teamEnergyBuySell(%aiId, pistolclip.price*3);
			Player::setItemCount(%aiId, pistolclip, 3);
		}
		if(checkResources(%aiId, pistolammo, 12,True)) {
			teamEnergyBuySell(%aiId, pistolammo.price*12);
			Player::setItemCount(%aiId, pistolammo, 12);
		}
		if(checkResources(%aiId, SensorJammerPack, 1,True)) {
			teamEnergyBuySell(%aiId, SensorJammerPack.price);
			Player::setItemCount(%aiId, SensorJammerPack, 1);
		}
		Player::useItem(%aiId,CrysKnife);
		Player::useItem(%aiId,SensorJammerPack);									 
	} else if( $ArmorName[%armorType] == SardaukarArmor)
	{
		if(checkResources(%aiId, Saber, 1,True)) {
			teamEnergyBuySell(%aiId, Saber.price);
			Player::setItemCount(%aiId, Saber, 1);
		}
		if(checkResources(%aiId, Pistol, 1,True)) {
			teamEnergyBuySell(%aiId, Pistol.price);
			Player::setItemCount(%aiId, Pistol, 1);
		}
		if(checkResources(%aiId, SmallLas, 1,True)) {
			teamEnergyBuySell(%aiId, SmallLas.price);
			Player::setItemCount(%aiId, SmallLas, 1);
		}
		if(checkResources(%aiId, MGun2, 1,True)) {
			teamEnergyBuySell(%aiId, MGun2.price);
			Player::setItemCount(%aiId, MGun2, 1);
		}
		if(checkResources(%aiId, pistolclip, 3,True)) {
			teamEnergyBuySell(%aiId, pistolclip.price*3);
			Player::setItemCount(%aiId, pistolclip, 3);
		}
		if(checkResources(%aiId, pistolammo, 12,True)) {
			teamEnergyBuySell(%aiId, pistolammo.price*12);
			Player::setItemCount(%aiId, pistolammo, 12);
		}
		if(checkResources(%aiId, SmallLascell, 3,True)) {
			teamEnergyBuySell(%aiId, SmallLascell.price*3);
			Player::setItemCount(%aiId, SmallLascell, 3);
		}
		if(checkResources(%aiId,  SmallLasAmmo, 75,True)) {
			teamEnergyBuySell(%aiId,  SmallLasAmmo.price*75);
			Player::setItemCount(%aiId, SmallLasAmmo, 75);
		}
		if(checkResources(%aiId, MGunclip, 4,True)) {
			teamEnergyBuySell(%aiId, MGunclip.price*4);
			Player::setItemCount(%aiId, MGunclip, 4);
		}
		if(checkResources(%aiId, MGunammo, 75,True)) {
			teamEnergyBuySell(%aiId, MGunammo.price*75);
			Player::setItemCount(%aiId, MGunammo, 75);
		}
		if(checkResources(%aiId, shieldpack, 1,True)) {
			teamEnergyBuySell(%aiId, shieldpack.price);
			Player::setItemCount(%aiId, shieldpack, 1);
		}
		Player::useItem(%aiId,Saber);
		Player::useItem(%aiId,shieldpack);									 
	} else if( $ArmorName[%armorType] == BasharArmor)
	{
		if(checkResources(%aiId, Saber, 1,True)) {
			teamEnergyBuySell(%aiId, Saber.price);
			Player::setItemCount(%aiId, Saber, 1);
		}
		if(checkResources(%aiId, Pistol, 1,True)) {
			teamEnergyBuySell(%aiId, Pistol.price);
			Player::setItemCount(%aiId, Pistol, 1);
		}
		if(checkResources(%aiId, SmallLas, 1,True)) {
			teamEnergyBuySell(%aiId, SmallLas.price);
			Player::setItemCount(%aiId, SmallLas, 1);
		}
		if(checkResources(%aiId, pistolclip, 3,True)) {
			teamEnergyBuySell(%aiId, pistolclip.price*3);
			Player::setItemCount(%aiId, pistolclip, 3);
		}
		if(checkResources(%aiId, pistolammo, 12,True)) {
			teamEnergyBuySell(%aiId, pistolammo.price*12);
			Player::setItemCount(%aiId, pistolammo, 12);
		}
		if(checkResources(%aiId, SmallLascell, 3,True)) {
			teamEnergyBuySell(%aiId, SmallLascell.price*3);
			Player::setItemCount(%aiId, SmallLascell, 3);
		}
		if(checkResources(%aiId, SmallLasAmmo, 75,True)) {
			teamEnergyBuySell(%aiId, SmallLasAmmo.price*75);
			Player::setItemCount(%aiId, SmallLasAmmo, 75);
		}
		if(checkResources(%aiId, shieldpack, 1,True)) {
			teamEnergyBuySell(%aiId, shieldpack.price);
			Player::setItemCount(%aiId, shieldpack, 1);
		}
		Player::useItem(%aiId,Saber);
		Player::useItem(%aiId,shieldpack);									 
	} else if( $ArmorName[%armorType] == BursegArmor)
	{
		if(checkResources(%aiId, Saber, 1,True)) {
			teamEnergyBuySell(%aiId, Saber.price);
			Player::setItemCount(%aiId, Saber, 1);
		}
		if(checkResources(%aiId, SmallLas, 1,True)) {
			teamEnergyBuySell(%aiId, SmallLas.price);
			Player::setItemCount(%aiId, SmallLas, 1);
		}
		if(checkResources(%aiId, SmallLascell, 3,True)) {
			teamEnergyBuySell(%aiId, SmallLascell.price*3);
			Player::setItemCount(%aiId, SmallLascell, 3);
		}
		if(checkResources(%aiId, SmallLasAmmo, 75,True)) {
			teamEnergyBuySell(%aiId, SmallLasAmmo.price*75);
			Player::setItemCount(%aiId, SmallLasAmmo, 75);
		}
		if(checkResources(%aiId, shieldpack, 1,True)) {
			teamEnergyBuySell(%aiId, shieldpack.price);
			Player::setItemCount(%aiId, shieldpack, 1);
		}
		Player::useItem(%aiId,Saber);
		Player::useItem(%aiId,shieldpack);									 
	} else if( $ArmorName[%armorType] == FaceDancerArmor)
	{
		if(checkResources(%aiId, SlipTip, 1,True)) {
			teamEnergyBuySell(%aiId, SlipTip.price);
			Player::setItemCount(%aiId, SlipTip, 1);
		}
		if(checkResources(%aiId,  Maula, 1,True)) {
			teamEnergyBuySell(%aiId,  Maula.price);
			Player::setItemCount(%aiId, Maula, 1);
		}
		if(checkResources(%aiId, Maulaclip, 2,True)) {
			teamEnergyBuySell(%aiId, Maulaclip.price*2);
			Player::setItemCount(%aiId, Maulaclip, 2);
		}
		if(checkResources(%aiId, Maulaammo, 5,True)) {
			teamEnergyBuySell(%aiId, Maulaammo.price*5);
			Player::setItemCount(%aiId, Maulaammo, 5);
		}
		if(checkResources(%aiId, SensorJammerPack, 1,True)) {
			teamEnergyBuySell(%aiId, SensorJammerPack.price);
			Player::setItemCount(%aiId, SensorJammerPack, 1);
		}
		Player::useItem(%aiId,SlipTip);
		Player::useItem(%aiId,SensorJammerPack);									 
	}
	$Reloading[%aiId] = "";
	$CurWeap[%aiId] = $WeaponToNum[Player::getMountedItem(%aiId,$WeaponSlot)];


}


function FindGhola( %master )
{
	for(%x = -100; %x < 101; %x++)
		echo("Ghola " @ %x @ " " @$OwnedGholaList[%master, %x] );


}


function Ghola::Follow( %ghola, %master )
{
	//Ghola::Stance( %ghola, 2 );
   	AI::setAutomaticTargets(%ghola);
	//AI::DirectiveFollow(%ghola, %master, 1, 1);
	$GholaDoing[%ghola] = "Follow";
}

function Ghola::Stay( %ghola )
{
      	//Ghola::Stance( %ghola, 2 );
	AI::setAutomaticTargets(%ghola);
	AI::DirectiveWaypoint( %ghola, gamebase::getposition(AI::getId(%ghola)), 1 );
	$GholaDoing[%ghola] = "Stop";
}

function Ghola::AdvanceAhead( %ghola, %dist )
{
      	Ghola::Stance( %ghola, 2 );
	AI::setAutomaticTargets(%ghola);

	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%wp = GetOffSetRot(0 @ " "@ %dist @" 0", %OwnerRot, %OwnerPos);
	

	AI::DirectiveWaypoint( %ghola, %wp, 1 );
	$GholaDoing[%ghola] = "Scout";
}

function Ghola::GoToTarget( %ghola )
{
      	Ghola::Stance( %ghola, 2 );
	AI::setAutomaticTargets(%ghola);
	//AI::DirectiveWaypoint( %ghola, gamebase::getposition(AI::getId(%ghola)), 1 );
	$GholaDoing[%ghola] = "Scout";
}


function Ghola::PlaceFormation( %ghola, %GholaNum )
{
	%pos = "";
	if( $GholaFormation[%ghola] == "Wall" )
		%pos = Ghola::GetWallPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Wall Guard" )
		%pos = Ghola::GetWallGuardPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Wedge Guard" )
		%pos = Ghola::GetWedgeGuardPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Wedge" )
		%pos = Ghola::GetWedgePosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Diamond" )
		%pos = Ghola::GetDiamondPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Column" )
		%pos = Ghola::GetColumnPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Line" )
		%pos = Ghola::GetLinePosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "File" )
		%pos = Ghola::GetFilePosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Echelon Left" )
		%pos = Ghola::GetEchelonLeftPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Echelon Right" )
		%pos = Ghola::GetEchelonRightPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Wing Left" )
		%pos = Ghola::GetWingLeftPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Wing Right" )
		%pos = Ghola::GetWingRightPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "V" )
		%pos = Ghola::GetVPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "T" )
		%pos = Ghola::GetTPosition(%ghola, %GholaNum );
	else if( $GholaFormation[%ghola] == "Y" )
		%pos = Ghola::GetYPosition(%ghola, %GholaNum );

	$GholaWayPoint[%ghola] = %pos;
	AI::DirectiveWaypoint( %ghola, %pos, 1 );

}

	
// %pos = GetOffSetRot("0 0 0",%OwnerRot,%OwnerPos);
// Alternate - + 
//	start -: pow(-1,(%GholaNum))
//	start +: pow(-1,(%GholaNum+1))
// DoubleNumbers
//	start 0: floor(((%GholaNum)/2)-0.5)
//	start 1: floor(((%GholaNum)/2)+0.5)
// Alternate 1, 0
// 	start 0: ((%GholaNum+1)%2)
//	start 1: (%GholaNum%2)



function Ghola::GetWallPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	

	%pos = GetOffSetRot((pow(-1,%gholaNum)*floor((%GholaNum/2)+0.5)*%dist) @ " "@ ((floor((%GholaNum/2)+0.5)%2)*(%dist*3/4)) @" 0", %OwnerRot, %OwnerPos);
	
	return %pos;
}

function Ghola::GetWedgePosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot((pow(-1,%GholaNum+1)*floor((%GholaNum/2)+0.5)*%dist) @ " "@ (-1*floor((%GholaNum/2))*%dist) @" 0", %OwnerRot, %OwnerPos);
	
	return %pos;
}

function Ghola::GetWallGuardPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%OwnerPos = GetOffSetRot("0 "@%dist @" 0",%OwnerRot,%OwnerPos);
	if(%gholaNum == 1)
		%pos = %OwnerPos;
	else
		%pos = GetOffSetRot((pow(-1,(%GholaNum-1))*floor(((%GholaNum-1)/2)+0.5)*%dist) @ " "@ (((floor(((%GholaNum-1)/2)+0.5))%2)*(%dist*(3/4))) @" 0", %OwnerRot, %OwnerPos);
	
	return %pos;
}

function Ghola::GetWedgeGuardPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%OwnerPos = GetOffSetRot("0 "@ %Dist@" 0",%OwnerRot,%OwnerPos);
	if(%gholaNum == 1)
		%pos = %OwnerPos;
	else
		%pos = GetOffSetRot((pow(-1,(%GholaNum-1))*floor(((%GholaNum-1)/2)+0.5)*%dist) @ " "@ (-1*floor(((%GholaNum-1)/2)+0.5)*%dist) @" 0", %OwnerRot, %OwnerPos);

	return %pos;
}

function Ghola::GetDiamondPosition(%ghola, %GholaNum )
{
	%num = $GholaOwned[$GholaOwner[%ghola]];
	if(%num <= 3)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 2;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 1;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 1;
	} else if(%num <= 7)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 4;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 3;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 3;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 2;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 2;
		$Pos[6,"x"] = -1;
		$Pos[6,"y"] = 1;
		$Pos[7,"x"] = 1;
		$Pos[7,"y"] = 1;
	} else if(%num <= 11)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 6;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 5;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 5;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 4;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 4;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 3;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 3;
		$Pos[8,"x"] = -2;
		$Pos[8,"y"] = 2;
		$Pos[9,"x"] = 2;
		$Pos[9,"y"] = 2;
		$Pos[10,"x"] = -1;
		$Pos[10,"y"] = 1;
		$Pos[11,"x"] = 1;
		$Pos[11,"y"] = 1;
	} else if(%num <= 15)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 8;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 7;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 7;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 6;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 6;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 5;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 5;
		$Pos[8,"x"] = -4;
		$Pos[8,"y"] = 4;
		$Pos[9,"x"] = 4;
		$Pos[9,"y"] = 4;
		$Pos[10,"x"] = -3;
		$Pos[10,"y"] = 3;
		$Pos[11,"x"] = 3;
		$Pos[11,"y"] = 3;
		$Pos[12,"x"] = -2;
		$Pos[12,"y"] = 2;
		$Pos[13,"x"] = 2;
		$Pos[13,"y"] = 2;
		$Pos[14,"x"] = -1;
		$Pos[14,"y"] = 1;
		$Pos[15,"x"] = 1;
		$Pos[15,"y"] = 1;
	} else if(%num <= 19)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 10;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 9;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 9;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 8;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 8;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 7;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 7;
		$Pos[8,"x"] = -4;
		$Pos[8,"y"] = 6;
		$Pos[9,"x"] = 4;
		$Pos[9,"y"] = 6;
		$Pos[10,"x"] = -5;
		$Pos[10,"y"] = 5;
		$Pos[11,"x"] = 5;
		$Pos[11,"y"] = 5;
		$Pos[12,"x"] = -4;
		$Pos[12,"y"] = 4;
		$Pos[13,"x"] = 4;
		$Pos[13,"y"] = 4;
		$Pos[14,"x"] = -3;
		$Pos[14,"y"] = 3;
		$Pos[15,"x"] = 3;
		$Pos[15,"y"] = 3;
		$Pos[16,"x"] = -2;
		$Pos[16,"y"] = 2;
		$Pos[17,"x"] = 2;
		$Pos[17,"y"] = 2;
		$Pos[18,"x"] = -1;
		$Pos[18,"y"] = 1;
		$Pos[19,"x"] = 1;
		$Pos[19,"y"] = 1;
	} else if(%num <= 23)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 12;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 11;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 11;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 10;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 10;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 9;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 9;
		$Pos[8,"x"] = -4;
		$Pos[8,"y"] = 8;
		$Pos[9,"x"] = 4;
		$Pos[9,"y"] = 8;
		$Pos[10,"x"] = -5;
		$Pos[10,"y"] = 7;
		$Pos[11,"x"] = 5;
		$Pos[11,"y"] = 7;
		$Pos[12,"x"] = -6;
		$Pos[12,"y"] = 6;
		$Pos[13,"x"] = 6;
		$Pos[13,"y"] = 6;
		$Pos[14,"x"] = -5;
		$Pos[14,"y"] = 5;
		$Pos[15,"x"] = 5;
		$Pos[15,"y"] = 5;
		$Pos[16,"x"] = -4;
		$Pos[16,"y"] = 4;
		$Pos[17,"x"] = 4;
		$Pos[17,"y"] = 4;
		$Pos[18,"x"] = -3;
		$Pos[18,"y"] = 3;
		$Pos[19,"x"] = 3;
		$Pos[19,"y"] = 3;
		$Pos[20,"x"] = -2;
		$Pos[20,"y"] = 2;
		$Pos[21,"x"] = 2;
		$Pos[21,"y"] = 2;
		$Pos[22,"x"] = -1;
		$Pos[22,"y"] = 1;
		$Pos[23,"x"] = 1;
		$Pos[23,"y"] = 1;
	} else if(%num <= 27)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 14;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 13;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 13;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 12;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 12;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 11;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 11;
		$Pos[8,"x"] = -4;
		$Pos[8,"y"] = 10;
		$Pos[9,"x"] = 4;
		$Pos[9,"y"] = 10;
		$Pos[10,"x"] = -9;
		$Pos[10,"y"] = 5;
		$Pos[11,"x"] = 9;
		$Pos[11,"y"] = 5;
		$Pos[12,"x"] = -8;
		$Pos[12,"y"] = 6;
		$Pos[13,"x"] = 8;
		$Pos[13,"y"] = 6;
		$Pos[14,"x"] = -7;
		$Pos[14,"y"] = 7;
		$Pos[15,"x"] = 7;
		$Pos[15,"y"] = 7;
		$Pos[16,"x"] = -6;
		$Pos[16,"y"] = 6;
		$Pos[17,"x"] = 6;
		$Pos[17,"y"] = 6;
		$Pos[18,"x"] = -5;
		$Pos[18,"y"] = 5;
		$Pos[19,"x"] = 5;
		$Pos[19,"y"] = 5;
		$Pos[20,"x"] = -4;
		$Pos[20,"y"] = 4;
		$Pos[21,"x"] = 4;
		$Pos[21,"y"] = 4;
		$Pos[22,"x"] = -3;
		$Pos[22,"y"] = 3;
		$Pos[23,"x"] = 3;
		$Pos[23,"y"] = 3;
		$Pos[24,"x"] = -2;
		$Pos[24,"y"] = 2;
		$Pos[25,"x"] = 2;
		$Pos[25,"y"] = 2;
		$Pos[26,"x"] = -1;
		$Pos[26,"y"] = 1;
		$Pos[27,"x"] = 1;
		$Pos[27,"y"] = 1;
	} else if(%num <= 31)
	{
		$Pos[1,"x"] = 0;
		$Pos[1,"y"] = 16;
		$Pos[2,"x"] = -1;
		$Pos[2,"y"] = 15;
		$Pos[3,"x"] = 1;
		$Pos[3,"y"] = 15;
		$Pos[4,"x"] = -2;
		$Pos[4,"y"] = 14;
		$Pos[5,"x"] = 2;
		$Pos[5,"y"] = 14;
		$Pos[6,"x"] = -3;
		$Pos[6,"y"] = 13;
		$Pos[7,"x"] = 3;
		$Pos[7,"y"] = 13;
		$Pos[8,"x"] = -4;
		$Pos[8,"y"] = 12;
		$Pos[9,"x"] = 4;
		$Pos[9,"y"] = 12;
		$Pos[10,"x"] = -5;
		$Pos[10,"y"] = 11;
		$Pos[11,"x"] = 5;
		$Pos[11,"y"] = 11;
		$Pos[12,"x"] = -6;
		$Pos[12,"y"] = 10;
		$Pos[13,"x"] = 6;
		$Pos[13,"y"] = 10;
		$Pos[14,"x"] = -7;
		$Pos[14,"y"] = 9;
		$Pos[15,"x"] = 7;
		$Pos[15,"y"] = 9;
		$Pos[16,"x"] = -8;
		$Pos[16,"y"] = 8;
		$Pos[17,"x"] = 8;
		$Pos[17,"y"] = 8;
		$Pos[18,"x"] = -7;
		$Pos[18,"y"] = 7;
		$Pos[19,"x"] = 7;
		$Pos[19,"y"] = 7;
		$Pos[20,"x"] = -6;
		$Pos[20,"y"] = 6;
		$Pos[21,"x"] = 6;
		$Pos[21,"y"] = 6;
		$Pos[22,"x"] = -5;
		$Pos[22,"y"] = 5;
		$Pos[23,"x"] = 5;
		$Pos[23,"y"] = 5;
		$Pos[24,"x"] = -4;
		$Pos[24,"y"] = 4;
		$Pos[25,"x"] = 4;
		$Pos[25,"y"] = 4;
		$Pos[26,"x"] = -3;
		$Pos[26,"y"] = 3;
		$Pos[27,"x"] = 3;
		$Pos[27,"y"] = 3;
		$Pos[28,"x"] = -2;
		$Pos[28,"y"] = 2;
		$Pos[29,"x"] = 2;
		$Pos[29,"y"] = 2;
		$Pos[31,"x"] = -1;
		$Pos[31,"y"] = 1;
	}

	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot( $Pos[%gholaNum,"x"]*%dist@" "@$Pos[%gholaNum,"y"]*%Dist@" 0", %OwnerRot, %OwnerPos);

	return %pos;
}

function Ghola::GetColumnPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot( (((%GholaNum)%2)*%dist)@" "@(-1*floor(((%GholaNum)/2))*%dist)@" 0",%OwnerRot,%OwnerPos);

	return %pos;
}

function Ghola::GetLinePosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot((pow(-1,%GholaNum)*floor((%GholaNum/2)+0.5)*%dist) @" 0 0", %OwnerRot, %OwnerPos);


	return %pos;
}

function Ghola::GetFilePosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot("0 "@ -1*%GholaNum*%dist @" 0", %OwnerRot, %OwnerPos);

	return %pos;
}

function Ghola::GetEchelonLeftPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot( (-1*%GholaNum*%dist) @" "@ (%GholaNum*%dist) @" 0", %OwnerRot, %OwnerPos);

	return %pos;
}

function Ghola::GetEchelonRightPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot( %GholaNum*%dist @" "@ %GholaNum*%dist @" 0", %OwnerRot, %OwnerPos);

	return %pos;
}

function Ghola::GetWingLeftPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%num = $GholaOwned[$GholaOwner[%ghola]];
	
	if( %Num <= 3)
	{
		%num = 3;
		if(%GholaNum > 2)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
	
	} else if( %Num <= 6 )
	{
		%num = 6;
		if(%GholaNum > 4)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
			

	} else if( %num <= 9 )
	{
		%num = 9;
		if(%GholaNum > 6)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 12 )
	{
		%num = 12;
		if(%GholaNum > 8)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 15 )
	{
		%num = 15;
		if(%GholaNum > 10)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 18 )
	{
		%num = 18;
		if(%GholaNum > 12)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 21 )
	{
		%num = 21;
		if(%GholaNum > 14)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 24 )
	{
		%num = 24;
		if(%GholaNum > 16)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 27 )
	{
		%num = 27;
		if(%GholaNum > 18)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 30 )
	{
		%num = 30;
		if(%GholaNum > 20)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 33 )
	{
		%num = 33;
		if(%GholaNum > 22)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 36 )
	{
		%num = 36;
		if(%GholaNum > 24)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 39 )
	{
		%num = 39;
		if(%GholaNum > 26)
			%pos = GetOffSetRot((-1*(%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} 
	return %pos;
}

function Ghola::GetWingRightPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%num = $GholaOwned[$GholaOwner[%ghola]];
	
	if( %Num <= 3)
	{
		%num = 3;
		if(%gholaNum > 2)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
	
	} else if( %Num <= 6 )
	{
		%num = 6;
		if(%GholaNum > 4)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
			

	} else if( %num <= 9 )
	{
		%num = 9;
		if(%GholaNum > 6)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 12 )
	{
		%num = 12;
		if(%GholaNum > 8)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 15 )
	{
		%num = 15;
		if(%GholaNum > 10)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 18 )
	{
		%num = 18;
		if(%GholaNum > 12)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 21 )
	{
		%num = 21;
		if(%GholaNum > 14)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 24 )
	{
		%num = 24;
		if(%GholaNum > 16)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 27 )
	{
		%num = 27;
		if(%GholaNum > 18)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 30 )
	{
		%num = 30;
		if(%GholaNum > 20)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 33 )
	{
		%num = 33;
		if(%GholaNum > 22)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 36 )
	{
		%num = 36;
		if(%GholaNum > 24)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} else if( %num <= 39 )
	{
		%num = 39;
		if(%GholaNum > 26)
			%pos = GetOffSetRot(((%GholaNum-(%num/3))*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);
		else
			%pos = GetOffSetRot((pow(-1,(%GholaNum))*floor(((%GholaNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%GholaNum)/2)+0.5)*%Dist)@" 0",%OwnerRot,%OwnerPos);

	} 
	return %pos;
}

function Ghola::GetVPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot((pow(-1,(%GholaNum+1))*floor(((%GholaNum)/2)+0.5)*%dist)@" "@(floor(((%GholaNum)/2))*%dist)@" 0",%OwnerRot,%OwnerPos);


	return %pos;
}


// Not used
function Ghola::GetZPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	%pos = GetOffSetRot("0 0 0",%OwnerRot,%OwnerPos);
	return %pos;
}

function Ghola::GetTPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];
	
	if(%gholaNum%3 == 0)
	{
		%pos = GetOffSetRot("0 "@(-1*floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0",%OwnerRot,%OwnerPos);
		
	} else if(%gholaNum%3 == 1)
	{
		%pos = GetOffSetRot((-1*floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0 0",%OwnerRot,%OwnerPos);
	} else if(%gholaNum%3 == 2)
	{
		%pos = GetOffSetRot((floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0 0",%OwnerRot,%OwnerPos);
	}

	return %pos;
}

function Ghola::GetYPosition(%ghola, %GholaNum )
{
	%OwnerPos = Gamebase::Getposition($GholaOwner[%ghola]);
	%OwnerRot = Gamebase::GetRotation($GholaOwner[%ghola]);
	%dist = $GholaFormationDist[%ghola];

	if(%gholaNum%3 == 1)
	{
		%pos = GetOffSetRot((-1*floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" "@(floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0",%OwnerRot,%OwnerPos);
		
	} else if(%gholaNum%3 == 2)
	{
		%pos = GetOffSetRot((floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" "@(floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0",%OwnerRot,%OwnerPos);
	} else if(%gholaNum%3 == 0)
	{
		%pos = GetOffSetRot("0 "@(-1*floor(((%GholaNum)/3)+(2.00001/3))*%dist)@" 0",%OwnerRot,%OwnerPos);
	}

	return %pos;
}

function Ghola::SetFormation( %ghola, %arg1, %arg2, %arg3, %arg4 ) {
	//
	// *All can be used with Tight/Close/In, Standard/Medium/(no argument), Long/Far/WIde, 
	//   or specific distance number arguments for distance
	//
	// Wall =		Wall/Block
	// Wedge =		Wedge/Triangle/Fluid [Guard, Defense, Defensive]
	// Diamond =		Diamond
	// Column =		Column/Square/Rectangle/Box
	// Line = 		Line/Abreast/LineAbreast
	// File =		File/Follow
	// Echelon (Left) =	EchelonLeft/Echelon@Left
	// Echelon (Right) =	EchelonRight/Echelon@Right
	// Wing (Left) =	WingLeft/Wing@Left/FingerTip@Left/Finger@Left
	// Wing (Right) =	WingRight/Wing@Right/FingerTip@Right/Finger@Right
	// V
	// Z
	// T
	// Y
	
	%formation = "";
	%dist = "";
	
	if( String::ICompare(%arg1,"Wall") == 0 || String::ICompare(%arg1,"Block") == 0 )
	{
		%formation = "Wall";
		if( String::ICompare(%arg2,"Guard") == 0 || String::ICompare(%arg2,"Defense") == 0 
			|| String::ICompare(%arg2,"Defensive") == 0 )
		{
			%formation = %formation@" Guard";
			%arg2 = %arg3;
		}
	} else if( String::ICompare(%arg1,"Wedge") == 0 || String::ICompare(%arg1,"Triangle") == 0 
		|| String::ICompare(%arg1,"Fluid") == 0 )
	{
		%formation = "Wedge";
		if( String::ICompare(%arg2,"Guard") == 0 || String::ICompare(%arg2,"Defense") == 0 
			|| String::ICompare(%arg2,"Defensive") == 0 )
		{
			%formation = %formation@" Guard";
			%arg2 = %arg3;
		}
	
	} else if( String::ICompare(%arg1,"Diamond") == 0 )
	{
		%formation = "Diamond";
	} else if( String::ICompare(%arg1,"Column") == 0 || String::ICompare(%arg1,"Square") == 0
		|| String::ICompare(%arg1,"Box") == 0 || String::ICompare(%arg1,"Rectangle") == 0 )
	{
		%formation = "Column";
	} else if( String::ICompare(%arg1,"Line") == 0 || String::ICompare(%arg1,"Abreast") == 0 
		|| String::ICompare(%arg1,"LineAbreast") == 0 )
	{
		%formation = "Line";
		if( String::ICompare(%arg2,"Abreast") == 0 )
		{
			%arg2 = %arg3;
		}
	
	} else if( String::ICompare(%arg1,"File") == 0 || String::ICompare(%arg1,"Follow") == 0 )
	{
		%formation = "File";
	
	} else if( String::ICompare(%arg1,"EchelonLeft") == 0 )
	{
		%formation = "Echelon Left";

	} else if( String::ICompare(%arg1,"EchelonRight") == 0 )
	{
		%formation = "Echelon Right";
	} else if( String::ICompare(%arg1,"Echelon") == 0 )
	{
		%formation = "Echelon";
		if( String::ICompare(%arg2,"Right") == 0)
		{
			%formation = %formation@" Right";
			%arg2 = %arg3;
		} else if( String::ICompare(%arg2,-1) == 0 || String::ICompare(%arg2,"Left") == 0){
			%arg2 = %arg3;
			%formation = %formation@" Left";
		}
	} else if( String::ICompare(%arg1,"WingLeft") == 0 || String::ICompare(%arg1,"FingerTipLeft") == 0 
		|| String::ICompare(%arg1,"FingerLeft") == 0 )
	{
		%formation = "Wing Left";

	} else if( String::ICompare(%arg1,"WingRight") == 0 || String::ICompare(%arg1,"FingerTipRight") == 0 
		|| String::ICompare(%arg1,"FingerRight") == 0 )
	{
		%formation = "Wing Right";
	} else if( String::ICompare(%arg1,"Wing") == 0 || String::ICompare(%arg1,"FingerTip") == 0 
		|| String::ICompare(%arg1,"Finger") == 0  )
	{
		if( String::ICompare(%arg2,"Tip") == 0 ) {
			%arg2 = %arg3;
			%arg3 = %arg4;
		}
		%formation = "Wing";
		if( String::ICompare(%arg2,"Right") == 0 )
		{
			%formation = %formation@" Right";
			%arg2 = %arg3;
		} else if(String::ICompare(%arg2,"Left") == 0 || String::ICompare(%arg2,-2) == 0){
			%formation = %formation@" Left";
			%arg2 = %arg3;
		}
	} else if( String::ICompare(%arg1,"V") == 0 )
	{
		%formation = "V";
	} else if( String::ICompare(%arg1,"T") == 0 )
	{
		%formation = "T";
	} else if( String::ICompare(%arg1,"Y") == 0 )
	{
		%formation = "Y";
	}

	if(%formation == "")
		%formation = $GholaFormation[%ghola];

	if( String::ICompare(%arg2,"Tight") == 0 || String::ICompare(%arg2,"Close") == 0 
		|| String::ICompare(%arg2,"In") == 0 || String::ICompare(%arg2,"Short") == 0 )
	{
		%dist = 2;
	} else if( String::ICompare(%arg2,"Standard") == 0 || String::ICompare(%arg2,"Medium") == 0 
		|| String::ICompare(%arg2,"Normal") == 0 || %arg2 == -1)
	{
		%dist = 7;
	
	} else if( String::ICompare(%arg2,"Long") == 0 || String::ICompare(%arg2,"Far") == 0 
		|| String::ICompare(%arg2,"Wide") == 0 || %arg2 == "Distant")
	{
		%dist = 20;
	} else if( %arg2 > 0 && %arg2 < 300 )
	{
		%dist = %arg2;
	}
	

	$GholaFormation[%ghola] = %formation;
	$GholaFormationDist[%ghola] = %dist;
	
}

function Ghola::KeepFormation(%ghola)
{

	if(!$gholadead[%ghola]){
		if( $GholaDoing[%ghola] == "Follow" && !( ai::getTarget( %ghola ) != -1
		&& ( $GholaStance[%ghola] == "aggressive" || ( $GholaStance[%ghola] == "standard" 
			&& vector::getdistance(gamebase::Getposition(AI::getId(%ghola)), gamebase::Getposition(ai::getTarget( %ghola ))) < 10 ) )))
		{
			for(%x = 1; %x < $GholaOwnedMax + 1; %x++)
			{
				if($OwnedGholaList[$GholaOwner[%ghola], %x] == %ghola)
					Ghola::PlaceFormation( %ghola, %x );
	
			}
		}
		schedule ("Ghola::KeepFormation( \"" @ %ghola @ "\");",0.1);
	}
}

function Ghola::PackOn( %ghola )
{
	%aiId = AI::getId(%ghola);
	if(Player::getMountedItem(%aiId,$BackPackSlot) == ShieldPack)
	{
		if( !$ShieldOn[Client::getOwnedObject(%aiId)])
			Ghola::MeleeWeap(%ghola);
		else
			Ghola::DistWeap(%ghola);
		Player::useItem(%aiId,ShieldPack);
		
	}
	else
		Player::useItem(%aiId,Player::getMountedItem(%aiId,$BackPackSlot));
}

function Ghola::ShieldOn( %ghola )
{
	%aiId = AI::getId(%ghola);
	if(Player::getMountedItem(%aiId,$BackPackSlot) == ShieldPack)
	{
		Player::useItem(%aiId,ShieldPack);
		if( $ShieldOn[Client::getOwnedObject(%aiId)])
			Ghola::MeleeWeap(%ghola);
		else
			Ghola::DistWeap(%ghola);
		
	}
}

function Ghola::UseWeapon(%ghola, %weapon)
{
	%aiId = AI::GetId(%ghola);

	if(String::ICompare(%weapon,"MachineGun") == 0 || String::ICompare(%weapon,"Machine") == 0 || String::ICompare(%weapon,"Machine Gun") == 0 ) {
		%weapon = MGun2;
	} else if(String::ICompare(%weapon,"Slip-Tip") == 0 || String::ICompare(%weapon,"Slip") == 0 || String::ICompare(%weapon,"Tip") == 0 || String::ICompare(%weapon,"Slip Tip") == 0 ) {
		%weapon = SlipTip;
	} else if(String::ICompare(%weapon,"Sniper") == 0 || String::ICompare(%weapon,"SniperR") == 0 || String::ICompare(%weapon,"Sniper Rifle") == 0 || String::ICompare(%weapon,"Sniper-Rifle") == 0 ) {
		%weapon = SniperRifle;
	} else if(String::ICompare(%weapon,"Semi") == 0 || String::ICompare(%weapon,"SemiAutomatic") == 0 || String::ICompare(%weapon,"Semi-Automatic") == 0 
		|| String::ICompare(%weapon,"Semi Automatic") == 0 || String::ICompare(%weapon,"SemiAutomaticRifle") == 0 
		|| String::ICompare(%weapon,"Semi-Automatic Rifle") == 0 || String::ICompare(%weapon,"Semi-Automatic-Rifle") == 0 
		|| String::ICompare(%weapon,"Semi Automatic Rifle") == 0 || String::ICompare(%weapon,"Automatic Rifle") == 0 
		|| String::ICompare(%weapon,"Semi Rifle") == 0 || String::ICompare(%weapon,"Automatic-Rifle") == 0 
		|| String::ICompare(%weapon,"AutomaticRifle") == 0 ) {
		if(Player::Getitemcount(%aiId, Rifle2) > 0)
			%weapon = Rifle2;
		else
			%weapon = Rifle;
	} else if(String::ICompare(%weapon,"Crys") == 0 || String::ICompare(%weapon,"Crysk") == 0 || String::ICompare(%weapon,"Cryskn") == 0 ) {
		%weapon = CrysKnife;
	} else if(String::ICompare(%weapon,"Launcher") == 0 || String::ICompare(%weapon,"RocketLauncher") == 0 || String::ICompare(%weapon,"Rocket Launcher") == 0 
		|| String::ICompare(%weapon,"Rocket") == 0 || String::ICompare(%weapon,"RocketL") == 0 || String::ICompare(%weapon,"Rocket-Launcher") == 0 ) {
		%weapon = RLauncher;
	} else if(String::ICompare(%weapon,"Flame") == 0 || String::ICompare(%weapon,"Flame-thrower") == 0 || String::ICompare(%weapon,"Flame thrower") == 0 || String::ICompare(%weapon,"thrower") == 0 ) {
		%weapon = Flamethrower;
	} else if(String::ICompare(%weapon,"Piller of Fire") == 0 || String::ICompare(%weapon,"PillerOfFire") == 0 || String::ICompare(%weapon,"Piller-of-fire") == 0 || String::ICompare(%weapon,"Fire") == 0 ) {
		%weapon = Piller;
	} else if(String::ICompare(%weapon,"Cutter") == 0 || String::ICompare(%weapon,"Cuteray") == 0 || String::ICompare(%weapon,"Cutterray") == 0 || String::ICompare(%weapon,"Cutter ray") == 0 || String::ICompare(%weapon,"ray") == 0 ) {
		%weapon = Cutteray;
	} else if(String::ICompare(%weapon,"SmallLasgun") == 0 || String::ICompare(%weapon,"Small Las") == 0 || String::ICompare(%weapon,"Small-Las") == 0 || String::ICompare(%weapon,"SmallL") == 0 
		|| String::ICompare(%weapon,"Small Lasgun") == 0 || String::ICompare(%weapon,"Small-Lasgun") == 0 || String::ICompare(%weapon,"SLas") == 0 || String::ICompare(%weapon,"SLasgun") == 0) {
		%weapon = SmallLas;
	} else if(String::ICompare(%weapon,"RifleLasgun") == 0 || String::ICompare(%weapon,"Rifle Las") == 0 || String::ICompare(%weapon,"Rifle-Las") == 0 || String::ICompare(%weapon,"RifleL") == 0 
		|| String::ICompare(%weapon,"Rifle Lasgun") == 0 || String::ICompare(%weapon,"Rifle-Lasgun") == 0 || String::ICompare(%weapon,"RLas") == 0 || String::ICompare(%weapon,"RLasgun") == 0) {
		%weapon = RifleLas;
	} else if(String::ICompare(%weapon,"HeavyLasgun") == 0 || String::ICompare(%weapon,"Heavy Las") == 0 || String::ICompare(%weapon,"Heavy-Las") == 0 || String::ICompare(%weapon,"HeavyL") == 0 
		|| String::ICompare(%weapon,"Heavy Lasgun") == 0 || String::ICompare(%weapon,"Heavy-Lasgun") == 0 || String::ICompare(%weapon,"HLas") == 0 || String::ICompare(%weapon,"HLasgun") == 0) {
		%weapon = HeavyLas;
	} else if(String::ICompare(%weapon,"Las") == 0 || String::ICompare(%weapon,"Lasgun") == 0 || String::ICompare(%weapon,"Las Gun") == 0 ) {
		if(Player::Getitemcount(%aiId, HeavyLas) > 0 )
			%weapon = HeavyLas;
		else if(Player::Getitemcount(%aiId, RifleLas) > 0 )
			%weapon = RifleLas;
		else if(Player::Getitemcount(%aiId, SmallLas) > 0 )
			%weapon = SmallLas;
		else if(Player::Getitemcount(%aiId, Cutteray) > 0 )
			%weapon = Cutteray;

	} else if( String::ICompare(%weapon,"Melee") == 0 || String::ICompare(%weapon,"MeleeWeapon") == 0 || String::ICompare(%weapon,"MeleeWeapons") == 0 || String::ICompare(%weapon,"MeleeWeap") == 0
		|| String::ICompare(%weapon,"Melee Weap") == 0 || String::ICompare(%weapon,"Melee Weapon") == 0 || String::ICompare(%weapon,"Melee Weapons") == 0 
		|| String::ICompare(%weapon,"Melee-Weapon") == 0 || String::ICompare(%weapon,"Melee-Weapons") == 0 ) {
		Ghola::MeleeWeap(%ghola);
		return;
	} else if( String::ICompare(%weapon,"Dist") == 0 || String::ICompare(%weapon,"DistWeapon") == 0 || String::ICompare(%weapon,"DistWeapons") == 0 || String::ICompare(%weapon,"DistWeap") == 0
		|| String::ICompare(%weapon,"Dist Weap") == 0 || String::ICompare(%weapon,"Dist Weapon") == 0 || String::ICompare(%weapon,"Dist Weapons") == 0 
		|| String::ICompare(%weapon,"Dist-Weapon") == 0 || String::ICompare(%weapon,"Dist-Weapons") == 0
		|| String::ICompare(%weapon,"Distance") == 0 || String::ICompare(%weapon,"DistanceWeapon") == 0 || String::ICompare(%weapon,"DistanceWeapons") == 0 || String::ICompare(%weapon,"DistanceWeap") == 0
		|| String::ICompare(%weapon,"Distance Weap") == 0 || String::ICompare(%weapon,"Distance Weapon") == 0 || String::ICompare(%weapon,"Distance Weapons") == 0 
		|| String::ICompare(%weapon,"Distance-Weapon") == 0 || String::ICompare(%weapon,"Distance-Weapons") == 0 ) {
		Ghola::DistWeap(%ghola);
		return;
	} else if( String::ICompare(%weapon,"Thopter") == 0 || String::ICompare(%weapon,"ThopterWeapon") == 0 || String::ICompare(%weapon,"ThopterWeapons") == 0 || String::ICompare(%weapon,"ThopterWeap") == 0
		|| String::ICompare(%weapon,"Thopter Weap") == 0 || String::ICompare(%weapon,"Thopter Weapon") == 0 || String::ICompare(%weapon,"Thopter Weapons") == 0 
		|| String::ICompare(%weapon,"Thopter-Weapon") == 0 || String::ICompare(%weapon,"Thopter-Weapons") == 0
		|| String::ICompare(%weapon,"AntiThopter") == 0 || String::ICompare(%weapon,"AntiThopterWeapon") == 0 || String::ICompare(%weapon,"AntiThopterWeapons") == 0 || String::ICompare(%weapon,"AntiThopterWeap") == 0
		|| String::ICompare(%weapon,"AntiThopter Weap") == 0 || String::ICompare(%weapon,"AntiThopter Weapon") == 0 || String::ICompare(%weapon,"AntiThopter Weapons") == 0 
		|| String::ICompare(%weapon,"AntiThopter-Weapon") == 0 || String::ICompare(%weapon,"AntiThopter-Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Thopter") == 0 || String::ICompare(%weapon,"Anti-ThopterWeapon") == 0 || String::ICompare(%weapon,"Anti-ThopterWeapons") == 0 || String::ICompare(%weapon,"Anti-ThopterWeap") == 0
		|| String::ICompare(%weapon,"Anti-Thopter Weap") == 0 || String::ICompare(%weapon,"Anti-Thopter Weapon") == 0 || String::ICompare(%weapon,"Anti-Thopter Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Thopter-Weapon") == 0 || String::ICompare(%weapon,"Anti-Thopter-Weapons") == 0
		|| String::ICompare(%weapon,"Ornithopter") == 0 || String::ICompare(%weapon,"OrnithopterWeapon") == 0 || String::ICompare(%weapon,"OrnithopterWeapons") == 0 || String::ICompare(%weapon,"OrnithopterWeap") == 0
		|| String::ICompare(%weapon,"Ornithopter Weap") == 0 || String::ICompare(%weapon,"Ornithopter Weapon") == 0 || String::ICompare(%weapon,"Ornithopter Weapons") == 0 
		|| String::ICompare(%weapon,"Ornithopter-Weapon") == 0 || String::ICompare(%weapon,"Ornithopter-Weapons") == 0
		|| String::ICompare(%weapon,"AntiOrnithopter") == 0 || String::ICompare(%weapon,"AntiOrnithopterWeapon") == 0 || String::ICompare(%weapon,"AntiOrnithopterWeapons") == 0 || String::ICompare(%weapon,"AntiOrnithopterWeap") == 0
		|| String::ICompare(%weapon,"AntiOrnithopter Weap") == 0 || String::ICompare(%weapon,"AntiOrnithopter Weapon") == 0 || String::ICompare(%weapon,"AntiOrnithopter Weapons") == 0 
		|| String::ICompare(%weapon,"AntiOrnithopter-Weapon") == 0 || String::ICompare(%weapon,"AntiOrnithopter-Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Ornithopter") == 0 || String::ICompare(%weapon,"Anti-OrnithopterWeapon") == 0 || String::ICompare(%weapon,"Anti-OrnithopterWeapons") == 0 || String::ICompare(%weapon,"Anti-OrnithopterWeap") == 0
		|| String::ICompare(%weapon,"Anti-Ornithopter Weap") == 0 || String::ICompare(%weapon,"Anti-Ornithopter Weapon") == 0 || String::ICompare(%weapon,"Anti-Ornithopter Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Ornithopter-Weapon") == 0 || String::ICompare(%weapon,"Anti-Ornithopter-Weapons") == 0 ) {
		Ghola::AThopterWeap(%ghola);
		return;
	} else if( String::ICompare(%weapon,"Tank") == 0 || String::ICompare(%weapon,"TankWeapon") == 0 || String::ICompare(%weapon,"TankWeapons") == 0 || String::ICompare(%weapon,"TankWeap") == 0
		|| String::ICompare(%weapon,"Tank Weap") == 0 || String::ICompare(%weapon,"Tank Weapon") == 0 || String::ICompare(%weapon,"Tank Weapons") == 0 
		|| String::ICompare(%weapon,"Tank-Weapon") == 0 || String::ICompare(%weapon,"Tank-Weapons") == 0
		|| String::ICompare(%weapon,"AntiTank") == 0 || String::ICompare(%weapon,"AntiTankWeapon") == 0 || String::ICompare(%weapon,"AntiTankWeapons") == 0 || String::ICompare(%weapon,"AntiTankWeap") == 0
		|| String::ICompare(%weapon,"AntiTank Weap") == 0 || String::ICompare(%weapon,"AntiTank Weapon") == 0 || String::ICompare(%weapon,"AntiTank Weapons") == 0 
		|| String::ICompare(%weapon,"AntiTank-Weapon") == 0 || String::ICompare(%weapon,"AntiTank-Weapons") == 0
		|| String::ICompare(%weapon,"Anti-Tank") == 0 || String::ICompare(%weapon,"Anti-TankWeapon") == 0 || String::ICompare(%weapon,"Anti-TankWeapons") == 0 || String::ICompare(%weapon,"Anti-TankWeap") == 0
		|| String::ICompare(%weapon,"Anti-Tank Weap") == 0 || String::ICompare(%weapon,"Anti-Tank Weapon") == 0 || String::ICompare(%weapon,"Anti-Tank Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Tank-Weapon") == 0 || String::ICompare(%weapon,"Anti-Tank-Weapons") == 0
		|| String::ICompare(%weapon,"Car") == 0 || String::ICompare(%weapon,"CarWeapon") == 0 || String::ICompare(%weapon,"CarWeapons") == 0 || String::ICompare(%weapon,"CarWeap") == 0
		|| String::ICompare(%weapon,"Car Weap") == 0 || String::ICompare(%weapon,"Car Weapon") == 0 || String::ICompare(%weapon,"Car Weapons") == 0 
		|| String::ICompare(%weapon,"Car-Weapon") == 0 || String::ICompare(%weapon,"Car-Weapons") == 0
		|| String::ICompare(%weapon,"AntiCar") == 0 || String::ICompare(%weapon,"AntiCarWeapon") == 0 || String::ICompare(%weapon,"AntiCarWeapons") == 0 || String::ICompare(%weapon,"AntiCarWeap") == 0
		|| String::ICompare(%weapon,"AntiCar Weap") == 0 || String::ICompare(%weapon,"AntiCar Weapon") == 0 || String::ICompare(%weapon,"AntiCar Weapons") == 0 
		|| String::ICompare(%weapon,"AntiCar-Weapon") == 0 || String::ICompare(%weapon,"AntiCar-Weapons") == 0
		|| String::ICompare(%weapon,"Anti-Car") == 0 || String::ICompare(%weapon,"Anti-CarWeapon") == 0 || String::ICompare(%weapon,"Anti-CarWeapons") == 0 || String::ICompare(%weapon,"Anti-CarWeap") == 0
		|| String::ICompare(%weapon,"Anti-Car Weap") == 0 || String::ICompare(%weapon,"Anti-Car Weapon") == 0 || String::ICompare(%weapon,"Anti-Car Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Car-Weapon") == 0 || String::ICompare(%weapon,"Anti-Car-Weapons") == 0
		|| String::ICompare(%weapon,"GroundCar") == 0 || String::ICompare(%weapon,"GroundCarWeapon") == 0 || String::ICompare(%weapon,"GroundCarWeapons") == 0 || String::ICompare(%weapon,"GroundCarWeap") == 0
		|| String::ICompare(%weapon,"GroundCar Weap") == 0 || String::ICompare(%weapon,"GroundCar Weapon") == 0 || String::ICompare(%weapon,"GroundCar Weapons") == 0 
		|| String::ICompare(%weapon,"GroundCar-Weapon") == 0 || String::ICompare(%weapon,"GroundCar-Weapons") == 0
		|| String::ICompare(%weapon,"Ground Car") == 0 || String::ICompare(%weapon,"Ground CarWeapon") == 0 || String::ICompare(%weapon,"Ground CarWeapons") == 0 || String::ICompare(%weapon,"Ground CarWeap") == 0
		|| String::ICompare(%weapon,"Ground Car Weap") == 0 || String::ICompare(%weapon,"Ground Car Weapon") == 0 || String::ICompare(%weapon,"Ground Car Weapons") == 0 
		|| String::ICompare(%weapon,"Ground Car-Weapon") == 0 || String::ICompare(%weapon,"Ground Car-Weapons") == 0
		|| String::ICompare(%weapon,"Ground-Car") == 0 || String::ICompare(%weapon,"Ground-CarWeapon") == 0 || String::ICompare(%weapon,"Ground-CarWeapons") == 0 || String::ICompare(%weapon,"Ground-CarWeap") == 0
		|| String::ICompare(%weapon,"Ground-Car Weap") == 0 || String::ICompare(%weapon,"Ground-Car Weapon") == 0 || String::ICompare(%weapon,"Ground-Car Weapons") == 0 
		|| String::ICompare(%weapon,"Ground-Car-Weapon") == 0 || String::ICompare(%weapon,"Ground-Car-Weapons") == 0
		|| String::ICompare(%weapon,"AntiGroundCar") == 0 || String::ICompare(%weapon,"AntiGroundCarWeapon") == 0 || String::ICompare(%weapon,"AntiGroundCarWeapons") == 0 || String::ICompare(%weapon,"AntiGroundCarWeap") == 0
		|| String::ICompare(%weapon,"AntiGroundCar Weap") == 0 || String::ICompare(%weapon,"AntiGroundCar Weapon") == 0 || String::ICompare(%weapon,"AntiGroundCar Weapons") == 0 
		|| String::ICompare(%weapon,"AntiGroundCar-Weapon") == 0 || String::ICompare(%weapon,"AntiGroundCar-Weapons") == 0
		|| String::ICompare(%weapon,"AntiGround Car") == 0 || String::ICompare(%weapon,"AntiGround CarWeapon") == 0 || String::ICompare(%weapon,"AntiGround CarWeapons") == 0 || String::ICompare(%weapon,"AntiGround CarWeap") == 0
		|| String::ICompare(%weapon,"AntiGround Car Weap") == 0 || String::ICompare(%weapon,"AntiGround Car Weapon") == 0 || String::ICompare(%weapon,"AntiGround Car Weapons") == 0 
		|| String::ICompare(%weapon,"AntiGround Car-Weapon") == 0 || String::ICompare(%weapon,"AntiGround Car-Weapons") == 0
		|| String::ICompare(%weapon,"AntiGround-Car") == 0 || String::ICompare(%weapon,"AntiGround-CarWeapon") == 0 || String::ICompare(%weapon,"AntiGround-CarWeapons") == 0 || String::ICompare(%weapon,"AntiGround-CarWeap") == 0
		|| String::ICompare(%weapon,"AntiGround-Car Weap") == 0 || String::ICompare(%weapon,"AntiGround-Car Weapon") == 0 || String::ICompare(%weapon,"AntiGround-Car Weapons") == 0 
		|| String::ICompare(%weapon,"AntiGround-Car-Weapon") == 0 || String::ICompare(%weapon,"AntiGround-Car-Weapons") == 0
		|| String::ICompare(%weapon,"Anti-Ground-Car") == 0 || String::ICompare(%weapon,"Anti-Ground-CarWeapon") == 0 || String::ICompare(%weapon,"Anti-Ground-CarWeapons") == 0 || String::ICompare(%weapon,"Anti-Ground-CarWeap") == 0
		|| String::ICompare(%weapon,"Anti-Ground-Car Weap") == 0 || String::ICompare(%weapon,"Anti-Ground-Car Weapon") == 0 || String::ICompare(%weapon,"Anti-Ground-Car Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Ground-Car-Weapon") == 0 || String::ICompare(%weapon,"Anti-Ground-Car-Weapons") == 0
		|| String::ICompare(%weapon,"Anti-Ground Car") == 0 || String::ICompare(%weapon,"Anti-Ground CarWeapon") == 0 || String::ICompare(%weapon,"Anti-Ground CarWeapons") == 0 || String::ICompare(%weapon,"Anti-Ground CarWeap") == 0
		|| String::ICompare(%weapon,"Anti-Ground Car Weap") == 0 || String::ICompare(%weapon,"Anti-Ground Car Weapon") == 0 || String::ICompare(%weapon,"Anti-Ground Car Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-Ground Car-Weapon") == 0 || String::ICompare(%weapon,"Anti-Ground Car-Weapons") == 0
		|| String::ICompare(%weapon,"Anti-GroundCar") == 0 || String::ICompare(%weapon,"Anti-GroundCarWeapon") == 0 || String::ICompare(%weapon,"Anti-GroundCarWeapons") == 0 || String::ICompare(%weapon,"Anti-GroundCarWeap") == 0
		|| String::ICompare(%weapon,"Anti-GroundCar Weap") == 0 || String::ICompare(%weapon,"Anti-GroundCar Weapon") == 0 || String::ICompare(%weapon,"Anti-GroundCar Weapons") == 0 
		|| String::ICompare(%weapon,"Anti-GroundCar-Weapon") == 0 || String::ICompare(%weapon,"Anti-GroundCar-Weapons") == 0 ) {
		Ghola::ATankWeap(%ghola);
		return;
	}

	if(Player::Getitemcount(%aiId, %weapon) > 0 && ( ($WeaponAmmo[%weapon] == "" || Player::Getitemcount(%aiId, $WeaponAmmo[%weapon]) > 0) || ($Clip[%weapon] != "" && Player::Getitemcount(%aiId, $Clip[%weapon]) > 0 ) ) )
	{
		if(%weapon == "SniperRifle")
			AI::setVar(%ghola,SpotDist,1000);
		else if(%weapon == "MGun2")
			AI::SetVar(%ghola,SpotDist,300);
		else
			AI::SetVar(%ghola,SpotDist,200);

		Player::useItem(%aiId,%weapon);	

	} 

}

function Ghola::MeleeWeap(%ghola)
{
	%aiId = AI::GetId(%ghola);
	%weapon = "";
	if(Player::Getitemcount(%aiId, Saber) > 0 )
		%weapon = Saber;
	else if(Player::Getitemcount(%aiId, Crysknife) > 0 )
		%weapon = Crysknife;
	else if(Player::Getitemcount(%aiId, Kindjal) > 0 )
		%weapon = Kindjal;
	else if(Player::Getitemcount(%aiId, SlipTip) > 0 )
		%weapon = SlipTip;
	else if(Player::Getitemcount(%aiId, Knife) > 0 )
		%weapon = Knife;

	if(%weapon != "" )
		Ghola::UseWeapon(%ghola, %weapon);
	

}

function Ghola::DistWeap(%ghola)
{
	%aiId = AI::GetId(%ghola);
	
	if( $ShieldOn[Client::getOwnedObject(%AIId)]) {
		Ghola::ShieldOn( %ghola );
	}

	%weapon = "";
	if(Player::Getitemcount(%aiId, SniperRifle) > 0 
		&& ( Player::Getitemcount(%aiId, SniperAmmo) > 0 || Player::Getitemcount(%aiId, SniperClip) > 0 ))
		%weapon = SniperRifle;
	else if(Player::Getitemcount(%aiId, MGun2) > 0 
		&& ( Player::Getitemcount(%aiId, MGunAmmo) > 0 || Player::Getitemcount(%aiId, MGunClip) > 0 ))
		%weapon = MGun2;
	else if(Player::Getitemcount(%aiId, RifleLas) > 0 
		&& ( Player::Getitemcount(%aiId, RifleLasAmmo) > 0 || Player::Getitemcount(%aiId, RifleLasCell) > 0 ))
		%weapon = RifleLas;
	else if(Player::Getitemcount(%aiId, HeavyLas) > 0 
		&& ( Player::Getitemcount(%aiId, HeavyLasAmmo) > 0 || Player::Getitemcount(%aiId, HeavyLasCell) > 0 ))
		%weapon = HeavyLas;
	else if(Player::Getitemcount(%aiId, Rifle2) > 0 
		&& ( Player::Getitemcount(%aiId, RifleAmmo) > 0 || Player::Getitemcount(%aiId, RifleClip) > 0 ))
		%weapon = Rifle2;
	else if(Player::Getitemcount(%aiId, Rifle) > 0 
		&& ( Player::Getitemcount(%aiId, RifleAmmo) > 0 || Player::Getitemcount(%aiId, RifleClip) > 0 ))
		%weapon = Rifle;
	else if(Player::Getitemcount(%aiId, FlameThrower) > 0 
		&& ( Player::Getitemcount(%aiId, FlameThrowerAmmo) > 0 ))
		%weapon = FlameThrower;
	else if(Player::Getitemcount(%aiId, RLauncher) > 0 
		&& ( Player::Getitemcount(%aiId, RLauncherAmmo) > 0))
		%weapon = RLauncher;
	else if(Player::Getitemcount(%aiId, SmallLas) > 0 
		&& ( Player::Getitemcount(%aiId, SmallLasAmmo) > 0 || Player::Getitemcount(%aiId, SmallLasCell) > 0 ))
		%weapon = SmallLas;
	else if(Player::Getitemcount(%aiId, Pistol) > 0 
		&& ( Player::Getitemcount(%aiId, PistolAmmo) > 0 || Player::Getitemcount(%aiId, PistolClip) > 0 ))
		%weapon = Pistol;
	else if(Player::Getitemcount(%aiId, Maula) > 0 
		&& ( Player::Getitemcount(%aiId, MaulaAmmo) > 0 || Player::Getitemcount(%aiId, MaulaClip) > 0 ))
		%weapon = Maula;
	else if(Player::Getitemcount(%aiId, Cutteray) > 0
		&& ( Player::Getitemcount(%aiId, CutterayAmmo) > 0 || Player::Getitemcount(%aiId, CutterayClip) > 0 ))
		%weapon = Cutteray;
	if(%weapon != "" )
		Ghola::UseWeapon(%ghola, %weapon);
	
	
}

function Ghola::AThopterWeap(%ghola)
{
	%aiId = AI::GetId(%ghola);
	if( $ShieldOn[Client::getOwnedObject(%AIId)]) {
		Ghola::ShieldOn( %aiName );
	}
	%weapon = "";
	if(Player::Getitemcount(%aiId, Piller) > 0 )
		%weapon = Piller;
	else if(Player::Getitemcount(%aiId, RLauncher) > 0 
		&& ( Player::Getitemcount(%aiId, RLauncherAmmo) > 0))
		%weapon = RLauncher;
	else if(Player::Getitemcount(%aiId, MGun2) > 0 
		&& ( Player::Getitemcount(%aiId, MGunAmmo) > 0 || Player::Getitemcount(%aiId, MGunClip) > 0 ))
		%weapon = MGun2;
	if(Player::Getitemcount(%aiId, SniperRifle) > 0 
		&& ( Player::Getitemcount(%aiId, SniperAmmo) > 0 || Player::Getitemcount(%aiId, SniperClip) > 0 ))
		%weapon = SniperRifle;
	else if(Player::Getitemcount(%aiId, Rifle) > 0 
		&& ( Player::Getitemcount(%aiId, RifleAmmo) > 0 || Player::Getitemcount(%aiId, RifleClip) > 0 ))
		%weapon = Rifle;
	else if(Player::Getitemcount(%aiId, RifleLas) > 0 
		&& ( Player::Getitemcount(%aiId, RifleLasAmmo) > 0 || Player::Getitemcount(%aiId, RifleLasCell) > 0 ))
		%weapon = RifleLas;
	if(%weapon != "" )
		Ghola::UseWeapon(%ghola, %weapon);
}

function Ghola::ATankWeap(%ghola)
{
	%aiId = AI::GetId(%ghola);
	if( $ShieldOn[Client::getOwnedObject(%AIId)]) {
		Ghola::ShieldOn( %aiName );
	}
	%weapon = "";
	if(Player::Getitemcount(%aiId, RLauncher) > 0 && Player::Getitemcount(%aiId, RLauncherAmmo) > 0)
		%weapon = RLauncher;
	else if(Player::Getitemcount(%aiId, HeavyLas) > 0 
		&& ( Player::Getitemcount(%aiId, HeavyLasAmmo) > 0 || Player::Getitemcount(%aiId, HeavyLasCell) > 0 ))
		%weapon = HeavyLas;
	else if(Player::Getitemcount(%aiId, RifleLas) > 0 
		&& ( Player::Getitemcount(%aiId, RifleLasAmmo) > 0 || Player::Getitemcount(%aiId, RifleLasCell) > 0 ))
		%weapon = RifleLas;
	else if(Player::Getitemcount(%aiId, MGun2) > 0 
		&& ( Player::Getitemcount(%aiId, MGunAmmo) > 0 || Player::Getitemcount(%aiId, MGunClip) > 0 ))
		%weapon = MGun2;
	else if(Player::Getitemcount(%aiId, SmallLas) > 0 
		&& ( Player::Getitemcount(%aiId, SmallLasAmmo) > 0 || Player::Getitemcount(%aiId, SmallLasCell) > 0 ))
		%weapon = SmallLas;
	else if(Player::Getitemcount(%aiId, Cutteray) > 0
		&& ( Player::Getitemcount(%aiId, CutterayAmmo) > 0 || Player::Getitemcount(%aiId, CutterayClip) > 0 ))
		%weapon = Cutteray;
	if(%weapon != "" )
		Ghola::UseWeapon(%ghola, %weapon);
}

function Ghola::DropAmmo(%ghola)
{
	%aiId = AI::GetId(%ghola);
	%item = Player::getMountedItem(%aiId,$WeaponSlot);
	if(%item.className == Weapon) {
		%item = %item.imageType.ammoType;
		Player::dropItem(%aiId,%item);
	}
}

function Ghola::DropPack(%ghola)
{
	%aiId = AI::GetId(%ghola);
	%item = Player::getMountedItem(%aiId,$BackpackSlot);
	Player::dropItem(%aiId,%item);
}

function Ghola::DropWeap(%ghola)
{
	%aiId = AI::GetId(%ghola);
	%item = Player::getMountedItem(%aiId,$WeaponSlot);
	Player::dropItem(%aiId,%item);
}

function Ghola::Drop(%ghola, %item)
{
	%aiId = AI::GetId(%ghola);
	
	%type = "";
	if(String::findSubStr(%item,"Ammo") != -1 && String::findSubStr(%item,"AmmoPack") == -1 && String::findSubStr(%item,"Ammo Pack") == -1)
	{
		%type = "Ammo";
		%item = String::getSubStr(%item, 0, String::findSubStr(%item,"Ammo"));
	
	} else if( String::findSubStr(%item,"Cell") != -1 )
	{
		%type = "Cell";
		%item = String::getSubStr(%item, 0, String::findSubStr(%item,"Cell"));

	} else if( String::findSubStr(%item,"Clip") != -1)
	{
		%Type = "Clip";
		%item = String::getSubStr(%item, 0, String::findSubStr(%item,"Clip"));
	}

	%thing = %item;
	if(getword(%thing, 0) != -1)
		%item = getword(%thing,0);
	if(getword(%thing, 1) != -1)
		%item = %item @ getword(%thing,1);
	if(getword(%thing, 2) != -1)
		%item = %item @ getword(%thing,2);
	if(getword(%thing, 3) != -1)
		%item = %item @ getword(%thing,3);
	if(getword(%thing, 4) != -1)
		%item = %item @ getword(%thing,4);
	
	if(String::ICompare(%item,"MachineGun") == 0 || String::ICompare(%item,"Machine") == 0 || String::ICompare(%item,"Machine Gun") == 0 ) {
		%item = MGun2;
	} else if(String::ICompare(%item,"Slip-Tip") == 0 || String::ICompare(%item,"Slip") == 0 || String::ICompare(%item,"Tip") == 0 || String::ICompare(%item,"Slip Tip") == 0 ) {
		%item = SlipTip;
	} else if(String::ICompare(%item,"Sniper") == 0 || String::ICompare(%item,"SniperR") == 0 || String::ICompare(%item,"Sniper Rifle") == 0 || String::ICompare(%item,"Sniper-Rifle") == 0 ) {
		%item = SniperRifle;
	} else if(String::ICompare(%item,"Semi") == 0 || String::ICompare(%item,"SemiAutomatic") == 0 || String::ICompare(%item,"Semi-Automatic") == 0 
		|| String::ICompare(%item,"Semi Automatic") == 0 || String::ICompare(%item,"SemiAutomaticRifle") == 0 
		|| String::ICompare(%item,"Semi-Automatic Rifle") == 0 || String::ICompare(%item,"Semi-Automatic-Rifle") == 0 
		|| String::ICompare(%item,"Semi Automatic Rifle") == 0 || String::ICompare(%item,"Automatic Rifle") == 0 
		|| String::ICompare(%item,"Semi Rifle") == 0 || String::ICompare(%item,"Automatic-Rifle") == 0 
		|| String::ICompare(%item,"AutomaticRifle") == 0 ) {
		%item = Rifle;
	} else if(String::ICompare(%item,"Crys") == 0 || String::ICompare(%item,"Crysk") == 0 || String::ICompare(%item,"Cryskn") == 0 ) {
		%item = CrysKnife;
	} else if(String::ICompare(%item,"Launcher") == 0 || String::ICompare(%item,"RocketLauncher") == 0 || String::ICompare(%item,"Rocket Launcher") == 0 
		|| String::ICompare(%item,"Rocket") == 0 || String::ICompare(%item,"RocketL") == 0 || String::ICompare(%item,"Rocket-Launcher") == 0 ) {
		%item = RLauncher;
	} else if(String::ICompare(%item,"Flame") == 0 || String::ICompare(%item,"Flame-thrower") == 0 || String::ICompare(%item,"Flame thrower") == 0 || String::ICompare(%item,"thrower") == 0 ) {
		%item = Flamethrower;
	} else if(String::ICompare(%item,"Piller of Fire") == 0 || String::ICompare(%item,"PillerOfFire") == 0 || String::ICompare(%item,"Piller-of-fire") == 0 || String::ICompare(%item,"Fire") == 0 ) {
		%item = Piller;
	} else if(String::ICompare(%item,"Cutter") == 0 || String::ICompare(%item,"Cuteray") == 0 || String::ICompare(%item,"Cutterray") == 0 || String::ICompare(%item,"Cutter ray") == 0 || String::ICompare(%item,"ray") == 0 ) {
		%item = Cutteray;
	} else if(String::ICompare(%item,"SmallLasgun") == 0 || String::ICompare(%item,"Small Las") == 0 || String::ICompare(%item,"Small-Las") == 0 || String::ICompare(%item,"SmallL") == 0 
		|| String::ICompare(%item,"Small Lasgun") == 0 || String::ICompare(%item,"Small-Lasgun") == 0 || String::ICompare(%item,"SLas") == 0 || String::ICompare(%item,"SLasgun") == 0) {
		%item = SmallLas;
	} else if(String::ICompare(%item,"RifleLasgun") == 0 || String::ICompare(%item,"Rifle Las") == 0 || String::ICompare(%item,"Rifle-Las") == 0 || String::ICompare(%item,"RifleL") == 0 
		|| String::ICompare(%item,"Rifle Lasgun") == 0 || String::ICompare(%item,"Rifle-Lasgun") == 0 || String::ICompare(%item,"RLas") == 0 || String::ICompare(%item,"RLasgun") == 0) {
		%item = RifleLas;
	} else if(String::ICompare(%item,"HeavyLasgun") == 0 || String::ICompare(%item,"Heavy Las") == 0 || String::ICompare(%item,"Heavy-Las") == 0 || String::ICompare(%item,"HeavyL") == 0 
		|| String::ICompare(%item,"Heavy Lasgun") == 0 || String::ICompare(%item,"Heavy-Lasgun") == 0 || String::ICompare(%item,"HLas") == 0 || String::ICompare(%item,"HLasgun") == 0) {
		%item = HeavyLas;
	} else if(String::ICompare(%item,"Las") == 0 || String::ICompare(%item,"Lasgun") == 0 || String::ICompare(%item,"Las Gun") == 0 ) {
		if(Player::Getitemcount(%aiId, HeavyLas) > 0 )
			%item = HeavyLas;
		else if(Player::Getitemcount(%aiId, RifleLas) > 0 )
			%item = RifleLas;
		else if(Player::Getitemcount(%aiId, SmallLas) > 0 )
			%item = SmallLas;
		else if(Player::Getitemcount(%aiId, Cutteray) > 0 )
			%item = Cutteray;
	}

	%item = %item @ %type;
	if(Player::Getitemcount(%aiId, %item) > 0 )
		Player::dropItem(%aiId,%item);

}

function Ghola::Stance( %ghola, %style )
{
//	3(1)/aggressive/charge/attack/kill/assult
//	2(0)/standard/guard/defend/stay
//	1(2)/passive/nothing/stop/halt
//	
//	4(1)/maintain/distance/oor/outofrange
// 		$GholaMaintainDist[%aiName] = true;
//
// 	3nd dimension Stance attributes:
//	5/melee/shielded/knife // Forces maintain distance off.
//	6/ranged/projectile/lasgun
//	7/mixed
	%aiName = %ghola; 

	// Stops in place and fires at enemy if it sees one. otherwise, it continues on it's waypoint
	if(String::findSubStr("passive",%style) == 0 || String::findSubStr("nothing",%style) == 0
	|| String::findSubStr("stop",%style) == 0 || String::findSubStr("halt",%style) == 0 || %style == 1)
	{
		$GholaStance[%ghola] = "passive";
		AI::setVar( %ghola,  attackMode, 2);
		$GholaMaintainDist[%aiName] = false;

	// Follows it's waypoint and fires at enemy; if enemy is in melee range, it engages.
	} else if(String::findSubStr("standard",%style) == 0 || String::findSubStr("guard",%style) == 0
	|| String::findSubStr("defend",%style) == 0 || String::findSubStr("stay",%style) == 0 || %style == 2)
	{
		$GholaStance[%ghola] = "standard"; //  for lack of something better....
		AI::setVar( %ghola,  attackMode, 1);
		$GholaMaintainDist[%aiName] = false;

	// Attacks enemy if it sees one, (runs at them). Engages in melee.
	} else if(String::findSubStr("aggressive",%style) == 0 || String::findSubStr("charge",%style) == 0
	|| String::findSubStr("attack",%style) == 0 || String::findSubStr("kill",%style) == 0
	|| String::findSubStr("assult",%style) == 0 || String::findSubStr("murder",%style) == 0 || %style == 3)
	{
		$GholaStance[%ghola] = "aggressive";
		AI::setVar( %ghola,  attackMode, 0);
		$GholaMaintainDist[%aiName] = false;
	
	// Attacks enemy if it sees one, but stays just out of melee range.	
	} else if(String::findSubStr("maintain",%style) == 0 || String::findSubStr("distance",%style) == 0
	|| String::findSubStr("dist",%style) == 0 || String::findSubStr("oor",%style) == 0
	|| String::findSubStr("out",%style) == 0 || String::findSubStr("outofrange",%style) == 0 || %style == 4)
	{
		$GholaStance[%ghola] = "aggressive";
		AI::setVar( %ghola,  attackMode, 0);
		$GholaMaintainDist[%aiName] = true;
	} else if(String::findSubStr("melee",%style) == 0 || String::findSubStr("shielded",%style) == 0
	|| String::findSubStr("knife",%style) == 0 || %style == 5)
	{
		$GholaStance3D[%ghola] = "melee";
		$GholaMaintainDist[%aiName] = false;

		if( !$ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::Meleeweap(%aiName);

	} else if(String::findSubStr("ranged",%style) == 0 || String::findSubStr("projectile",%style) == 0
	|| String::findSubStr("lasgun",%style) == 0 || %style == 6)
	{
		$GholaStance3D[%ghola] = "ranged";
		if( $ShieldOn[Client::getOwnedObject(AI::getId(%aiName))]) {
			Ghola::ShieldOn( %aiName );
		}
			Ghola::DistWeap(%aiName);
	} else if(String::findSubStr("mixed",%style) == 0 || %style == 7)
	{
		$GholaStance3D[%ghola] = "mixed";
	}
}

function Ghola::Attack(%ghola, %person ) {
	
	$GholaLastHating[%ghola] = $GholaHating[%ghola];
	$GholaHating[%ghola] = %person;
	AI::DirectiveTarget(%ghola, %person, true);
	
}

function Ghola::AttackMode(%ghola, %Mode) {
echo("AttackMode");
	AI::setVar( %ghola,  attackMode, %Mode);


}

function Ghola::PathType(%ghola, %pathtype) {
echo("PathType");
	AI::setVar( %ghola,  pathType, %pathtype);
}

function Ghola::clearDir( %ghola ) {
//echo("ClearDir");
	for(%x = 0; %x < 10; %x++)
		AI::DirectiveRemove(%ghola, %x);

}

function Ghola::packList(%clientId)
{

	for(%x = 1; %x <= $GholaOwnedMax; %x++)
	{
		if( $OwnedGholaList[%clientid, %x] == "")
		{
			for(%y = %x+1; %y <= $GholaOwnedMax; %y++)
			{
				if( $OwnedGholaList[%clientId, %y] != "")
				{
					 $OwnedGholaList[%clientId, %x] =  $OwnedGholaList[%clientId, %y];
					 $OwnedGholaList[%clientId, %y] = "";
				}	
			}
		}
	}

}


function Ghola::whoAttacking( %ghola ) {
	%team = gamebase::Getteam(AI::GetId(%ghola));
	//remoteSay(AI::GetId(%ghola), gamebase::Getteam(AI::GetId(%ghola)), "I am attacking " @ ai::getTarget( %ghola ));
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == %team)
            Client::sendMessage(%cl, $MsgTypeTeamChat, %ghola@ ": I am attacking " @ client::Getname(ai::getTarget( %ghola )), AI::GetId(%ghola));
}


function NewRotation(%rot,%dir)
{
	%rot1  = %rot;						   //- rotation aim forward
	%rot2  = Vector::Add(%rot,"0 0 3.141592654");   	   //- rotation aim back
	%rot3  = Vector::Add(%rot,"0 0 -1.570796327");  	   //- rotation aim right
	%rot4  = Vector::Add(%rot,"0 0 1.570796327");   	   //- rotation aim left
	%rot5  = Vector::Add(%rot,"1.570796327 0 0");   	   //- rotation aim up
	%rot6  = Vector::Add(%rot,"-1.570796327 0 0");  	   //- rotation aim down
	%rot7  = Vector::Add(%rot,"-0.7853981635 0 0");		   //- rotation aim down/forward
	%rot8  = Vector::Add(%rot,"0.7853981635 0 0");  	   //- rotation aim up/forward
	%rot9  = Vector::Add(%rot,"-3.9269908175 0 0");            //- rotation aim down/back
	%rot10 = Vector::Add(%rot,"3.9269908175 0 0");             //- rotation aim up/back
	%rot11 = Vector::Add(%rot,"0 0 -0.7853981635");            //- rotation aim left/forward
	%rot12 = Vector::Add(%rot,"0 0 0.7853981635");             //- rotation aim right/forward
	%rot13 = Vector::Add(%rot,"0 0 -3.9269908175");            //- rotation aim left/back
	%rot14 = Vector::Add(%rot,"0 0 3.9269908175");             //- rotation aim right/back
	%rot15 = Vector::Add(%rot,"1.570796327 0.7853981635 0");   //- rotation aim up/right
	%rot16 = Vector::Add(%rot,"-1.570796327 0.7853981635 0");  //- rotation aim down/right
	%rot17 = Vector::Add(%rot,"1.570796327 -0.7853981635 0");  //- rotation aim up/left
	%rot18 = Vector::Add(%rot,"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
	if(%dir == "back")
		return %rot2;
	else if(%dir == "right")
		return %rot3;
	else if(%dir == "left")
		return %rot4;
	else if(%dir == "up")
		return %rot5;
	else if(%dir == "down")
		return %rot6;
	else
		return %rot;
}

function go()
{
	%pos = "0 0 0";
	%rot = "1 0 0";

	%x = 1;
	%y = 1;
	%z = 1;

	%posA = Vector::add(%pos,Vector::getFromRot(Vector::Add(getword(%rot,0)@" 0 0","0 0 0"),%x));
	%posB = Vector::add(%posA,Vector::getFromRot("0 "@getword(%rot,1)@" 0",%y));
	%posC = Vector::add(%posB,Vector::getFromRot(Vector::Add("0 0 "@getword(%rot,2),"0 0 0"),%z));
echo(%posC);

	
//echo(vector::getrotation(vector::normalize(%x@" " @ %y@ " " @ %z)));
//%a = vector::getfromrot(vector::getrotation(%x@" "@%y@" "@%z),1);
//echo(%a);
//%b = vector::Add(%a,vector::getfromrot(vector::getrotation(vector::normalize(%x@" "@%y@" "@%z)),1));
//echo(vector::add(%b,vector::getfromrot(vector::getrotation(vector::normalize(%x+1.570796327@" "@%y@" "@%z)),1)));

}

function GetOffSetRot(%offset,%rot,%pos)
{
	%x = getWord(%offset,0);
	%y = getWord(%offset,1);
	%z = getWord(%offset,2);

	



	%posA = Vector::add(%pos,Vector::getFromRot(Vector::Add("0 "@getword(%rot,1)@" "@getword(%rot,2),"0 0 -1.570796327"),%x));
	%posB = Vector::add(%posA,Vector::getFromRot(getword(%rot,0)@" "@getword(%rot,1)@" "@getword(%rot,2),%y));
	%posC = Vector::add(%posB,Vector::getFromRot(Vector::Add(getword(%rot,0)@" "@getword(%rot,1)@" "@getword(%rot,2),"1.570796327 0 0"),%z));
	return %posC;
}


function GetOffSetRot2(%offset,%rot,%pos)
{
	%x = getWord(%offset,0);
	%y = getWord(%offset,1);
	%z = getWord(%offset,2);
	%posA = Vector::add(%pos,Vector::getFromRot(NewRotation(%rot,"right"),%x));
	%posB = Vector::add(%posA,Vector::getFromRot(%rot,%y));
	%posC = Vector::add(%posB,Vector::getFromRot(NewRotation(%rot,"up"),%z));
}

function Vector::getRotAim(%pos1,%pos2,%neg)
{
	%vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
	if(%neg)
		%vec = Vector::normalize(Vector::sub(%pos1,%pos2));
	%rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
	return %rot;
}
