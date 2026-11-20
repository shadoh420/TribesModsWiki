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

$AI::defaultPathType = 2; //run twoWay paths
$AI::defaultArmorType = "larmor";



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

//      %spawnMarker = AI::pickRandomSpawn(%team); //Much more convenient

      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);

//================================================================================================================================ Standard
    //echo("BOT: Constructing Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
      {
	  //echo("BOT: SPAWN: Base Bot");
      $AI::defaultArmorType = "lfemale";
      %voice = "female2";
      }
      else
      {
      $AI::defaultArmorType = "larmor";
      %voice = "male2";
      }

//================================================================================================================================= Medic
    if(String::findSubStr(%aiName, "Medic") >= 0)
    {
    //echo("BOT: SPAWN: Medic Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "efemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "earmor";
      %voice = "female2";
      }
    }

//================================================================================================================================ Guard
    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
    //echo("BOT: SPAWN: Guard Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "darmor";
      %voice = "female5";
      }
      else
      {
      $AI::defaultArmorType = "darmor";
      %voice = "male5";
      }
    }
//================================================================================================================================= Demo
    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
    //echo("BOT: SPAWN: Demo Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "mfemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "marmor";
      %voice = "female2";
      }
    }



      if( AI::spawn( %aiName, $AI::defaultArmorType, %spawnPos, %spawnRot, %aiName, %voice ) != "false" )
      {

         // The order number is used for sorting waypoints, and other directives.
         // Set to two so it won't fuck up my precious chasing code :-P
         %orderNumber = 2;
         
         for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);

            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );
            
//            %orderNumber++;
         }
      }
      else{
         dbecho( 1, "Failure spawning: " @ %aiName );
      }
   }
}

//----------------------------------
// AI::setupAI()
//
// Called from Mission::init() which is defined in Objectives.cs (or Dm.cs for
//    deathmatch missions).  
//----------------------------------   
//modified by Werewolf


function AI::setupAI(%key, %team)
{

    %aiName = %key;


//================================================================================================================= Define Base Bot Classes


//========================================================================================== Basic Light Default Armour
//    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
//      {
//      $AI::defaultArmorType = "lfemale";
//      %voice = "female2";
//      }
//      else
//      {
//      $AI::defaultArmorType = "larmor";
//      %voice = "male2";
//      }
//
//========================================================================================== Basic Medic Bot
    if(String::findSubStr(%aiName, "Medic") >= 0)
    {
	  //echo("SPAWN: Medic Bot");
	    if(String::findSubStr(%aiName, "Female") >= 0)
	      {
		      $AI::defaultArmorType = "efemale";
		      %voice = "female4";
	      }
	      else
	      {
		      $AI::defaultArmorType = "earmor";
		      %voice = "female2";
	      }
    }
//========================================================================================== Basic Guard Armour
    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
	  //echo("SPAWN: Guard Bot");
	    if(String::findSubStr(%aiName, "Female") >= 0)
	      {
		      $AI::defaultArmorType = "darmor";
		      %voice = "female5";
	      }
	      else
	      {
		      $AI::defaultArmorType = "darmor";
		      %voice = "male5";
	      }
    }

//========================================================================================== Basic Demo Bot
    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
	  //echo("SPAWN: Demo Bot");
	    if(String::findSubStr(%aiName, "Female") >= 0)
	      {
		      $AI::defaultArmorType = "mfemale";
		      %voice = "female4";
	      }
	      else
	      {
		      $AI::defaultArmorType = "marmor";
		      %voice = "female2";
	      }
    }




//============================================================================================ If there is no key then they don't exist yet
   
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
      if( %aiFound == 0 )
         dbecho(1, "No drones exist...");
      else
         dbecho(1, %aiFound @ " drones installed..." );
   }
   else     //respawning dead AI with original name and path
   {
      %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %key);
      %num = Group::objectCount(%group);
      %aiId = AI::getId(%key);

      if( %aiId <= 0) // Is it a pre-defined AI, or a dynamically spawned? If it is the latter, then...
      {
         %teamnum = %team;
         %newName = %key;



// New method for finding spawn points:
//------------------------------------
   %spawnMarker = AI::pickRandomSpawn(%teamnum);
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

         dbecho(1, "Random Spawn Position is: " @ %xPos @ "  " @ %yPos @ "  " @ %zPos);


         Ai::spawn(%newName, $AI::defaultArmorType, %aiSpawnPos, %spawnRot, %newName, %voice );
         %aiId = AI::getId( %newName );
         GameBase::setTeam(%aiId, %teamnum);
         AI::setVar( %newName,  iq,  90 );
         AI::setVar( %newName,  attackMode, 1);
         AI::setVar( %newName,  pathType, $AI::defaultPathType);
         AI::DirectiveWaypoint( %newName, %aiSpawnPos, 2, 2);
         schedule("AI::setWeapons(" @ %newName @ ");", 1);
         
      }
      //--------------------------------------------


      else  //else respawn like regular AIs
      {


      createAI(%key, %group, $AI::defaultArmorType, %key);
      %aiId = AI::getId(%key);

      %so = getObjectType(%aiId);
      dbecho(1, "AI objectType is " @ %so );


      GameBase::setTeam(%aiId, %team);
      AI::setVar(%key, pathType, $AI::defaultPathType);
      AI::setWeapons(%key);



   }
  }	
}

//------------------------------
// AI::setWeapons()
//------------------------------
//modified by Werewolf
function AI::setWeapons(%aiName)
{
	%aiId = AI::getId(%aiName);


//In case some moron ignorant mapmaker (just kidding ;-)) forgot to name the bots according to the readme,
//they'll spawn with the ugly-useless standard weapons.
//by Werewolf

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
	   Player::setItemCount(%aiId, discammo, 25);
	   Player::setItemCount(%aiId, bulletAmmo, 1000);
   }
   Player::mountItem(%aiId, blaster, 0);


//Now comes the hard part: Check if the AI name contains various keywords
//(Guard, Sniper... Female... etc.) and set armor/weapons accordingly.
//by Werewolf



//=============================================================================================================== Set Equipment For Guard

 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
   AI::setVar(%aiName, iq, 120 );
 
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
      Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
//=============================================================================== Set who can assign targets to this mortar

	%clientId = 0;
	%maxhumans = 0;
	%altId = 0;

         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         
		 if (Player::isAIControlled(%cl) == "false")      //===================== Is this a human player?
         {
	    	 if (%clientId == 0)
			 {
				%clientId = %cl;
				%maxhumans++;
        	 }
        	 else
        	 {
  	    	   %clientTwoId = %cl;
   	    	 }
         }

	%T = GameBase::getTeam( %aiId );

	
//========================================== Sick and awkward way to make mortars respond to the first player in each team.

	if (%T == 0)
	{
	   if (%maxhumans==2)
	   { 
	       AI::DirectiveTargetLaser( %aiName, %clientTwoId, 1);
	   }
       else
       {
       		AI::DirectiveTargetLaser( %aiName, %clientId, 1);
       }
   }

	else
   {
     AI::DirectiveTargetLaser( %aiName, %clientId, 1);
   }

//-------------

      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);

// Resetting defaults to 0

	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, discammo, 0);

// Now give him the thing I intended him to have

	   Player::setItemCount(%aiId, VulcanAmmo, 10000);
       Player::setItemCount(%aiId, Vulcan, 1);
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, mortar, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 500);
	   Player::setItemCount(%aiId, beacon, 10);
	   Player::setItemCount(%aiId, Grenade, 5);
	   Player::setItemCount(%aiId, RepairKit, 1);
     Player::mountItem(%aiId, mortar, 0);
   }
 }

//=============================================================================================================== Set Equipment For Demo


 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
 AI::setVar(%aiName, iq, 40 );

   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
   	   Player::setItemCount(%aiId, beacon, 1);
   	   Player::setItemCount(%aiId, Grenade, 5);
	   Player::setItemCount(%aiId, RepairKit, 1);
   Player::mountItem(%aiId, plasmaGun, 0);
   }
 }


//=============================================================================================================== Set Equipment For Painter

 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   AI::setVar(%aiName, iq, 200 );
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
	  
// Uses the default weapons, so don't remove anything
// Now give him the thing I intended him to have

	   Player::setItemCount(%aiId, targetinglaser, 1);
   	   Player::setItemCount(%aiId, beacon, 1);
   	   Player::setItemCount(%aiId, Grenade, 5);
	   Player::setItemCount(%aiId, RepairKit, 1);
	   
   Player::mountItem(%aiId, targetinglaser, 0);
   }
 }


//=============================================================================================================== Set Equipment For Sniper

 if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   AI::setVar(%aiName, iq, 160 );
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have

	   Player::setItemCount(%aiId, laserrifle, 1);
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
   	   Player::setItemCount(%aiId, beacon, 1);
   	   Player::setItemCount(%aiId, Grenade, 5);
	   Player::setItemCount(%aiId, RepairKit, 1);
	   
	   
   Player::mountItem(%aiId, laserrifle, 0);
   }
 }


//=============================================================================================================== Set Equipment For Medic

 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   AI::setVar(%aiName, iq, 70 );
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
	  
// Uses the default weapons, so don't remove anything
// Now give him the thing I intended him to have

	   Player::setItemCount(%aiId, repairkit, 10);
	   Player::setItemCount(%aiId, RepairPack, 1);
	   Player::setItemCount(%aiId, beacon, 1);
	   Player::setItemCount(%aiId, Grenade, 5);

   Player::mountItem(%aiId, repairkit, 0);
   Player::mountItem(%aiId, repairPack,1);

   }
 }
//=============================================================================================================== Set Equipment For Miner
 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   AI::setVar(%aiName, iq, 70 );
   if(Game::missionType == "DM")
   {	
      dbecho(2, "giving DM weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
   Player::mountItem(%aiId, blaster, 0);
   }
   else
   {
      dbecho(2, "giving normal weapon select...");
      Player::setItemCount(%aiId, blaster, 1);
// Resetting defaults to 0
	   Player::setItemCount(%aiId, disclauncher, 0);
	   Player::setItemCount(%aiId, chaingun, 0);
	   Player::setItemCount(%aiId, discammo, 0);
	   Player::setItemCount(%aiId, bulletAmmo, 0);

// Now give him the thing I intended him to have
	   Player::setItemCount(%aiId, mineammo, 10);
	   Player::setItemCount(%aiId, plasmaGun, 1);
	   Player::setItemCount(%aiId, discammo, 500);
	   Player::setItemCount(%aiId, disclauncher, 1);
	   Player::setItemCount(%aiId, grenadelauncher, 1);
	   Player::setItemCount(%aiId, plasmaAmmo, 500);
	   Player::setItemCount(%aiId, mortarAmmo, 15);
	   Player::setItemCount(%aiId, grenadeAmmo, 25);
	   Player::setItemCount(%aiId, beacon, 1);
	   Player::setItemCount(%aiId, Grenade, 5);
	   Player::setItemCount(%aiId, RepairKit, 1);

   Player::mountItem(%aiId, disclauncher, 0);
   }
 }

   AI::SetVar(%aiName, triggerPct, 0.03 );
   AI::setVar(%aiName, attackMode, 1);
   AI::setAutomaticTargets( %aiName );
   ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);

}


//-----------------------------------
// AI::periodicWeaponChange()
//-----------------------------------
//modified by Werewolf
function ai::periodicWeaponChange(%aiName)
{



   // Constantly Updating enemy position (if in sight)
   //Check which weapon to use, according to bot class and situation (Jetting, not jetting, enemy near or far away)
   //modified by Werewolf

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


//=============================================================================================================== Guard Weapon Select
 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
	 Player::mountItem(%aiId, mortar, 0);
	 AI::SetVar(%aiName, triggerPct, 100 );
	 
   if(%targetDist > 100)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, mortar, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
	layer::mountItem(%aiId, mortar, 0);
	AI::SetVar(%aiName, triggerPct, 0.5 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, vulcan, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, vulcan, 0);  
         AI::SetVar(%aiName, triggerPct, 1 );
      }   
   }	 

	 
 }




//=============================================================================================================== Guard Weapon Select
 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
   if(%targetDist > 100)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, blaster, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
	layer::mountItem(%aiId, plasmagun, 0);
	AI::SetVar(%aiName, triggerPct, 0.5 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, grenadelauncher, 0);  
         AI::SetVar(%aiName, triggerPct, 1 );
      }   
   }
  }



//=============================================================================================================== Painter Weapon Select
 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   if(%targetDist > 20)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, targetinglaser, 0);
         AI::SetVar(%aiName, triggerPct, 100 );
      }
      else
      {
	Player::mountItem(%aiId, targetinglaser, 0);
	AI::SetVar(%aiName, triggerPct, 100 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, chaingun, 0);
         AI::SetVar(%aiName, triggerPct, 0.3 );
      }
      else
      {
         Player::mountItem(%aiId, blaster, 0);  
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }   
   }
  }



//=============================================================================================================== Sniper Weapon Select
if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   Player::setDetectParameters(%aiId, 0.0001, 0.00001);
   if(%targetDist > 50)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, laserrifle, 0);
         AI::SetVar(%aiName, triggerPct, 0.005 );
      }
      else
      {
	Player::mountItem(%aiId, laserrifle, 0);
	AI::SetVar(%aiName, triggerPct, 0.005 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 1 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 1 );
      }   
   }
  }




//=============================================================================================================== Miner Weapon Select
 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   if(%targetDist > 100)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, blaster, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   

   }   
   else
   {
      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, disclauncher, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, mineammo, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   
   }
  }


//=============================================================================================================== Medic Weapon Select
 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   if(%targetDist > 20)
   {

      if(Player::isJetting(%curTarget))
      {	
         Player::mountItem(%aiId, blaster, 0);
         AI::SetVar(%aiName, triggerPct, 0.6 );
      }
      else
      {
         Player::mountItem(%aiId, plasmagun, 0);  
         AI::SetVar(%aiName, triggerPct, 0.03 );
      }   

   }   
   else
   {
         Player::mountItem(%aiId, disclauncher, 0);
         Player::useItem(%aiId, repairkit, 0);
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
   return ( %newName );
}

//
//This function will move an AI player to the position of an object
//that the players LOS is hitting(terrain included). Must be `	within 50 units.
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
   
//============================================================== get commanders x and y positions

   %comm_x = getWord(%commPos, 0);
   %comm_y = getWord(%commPos, 1);
   
//============================================================== get offset x and y positions

   %offSetPos = Vector::getFromRot(%issuerRot, %distance);
   %off_x = getWord(%offSetPos, 0);
   %off_y = getWord(%offSetPos, 1);
   
//============================================================== calc new position

   %new_x = %comm_x + %off_x;
   %new_y = %comm_y + %off_y;
   %newPos = %new_x  @ " " @ %new_y @ " 0";
  
//============================================================== move AI player

   dbecho(2, "Bot moving to " @ %newPos);
   
	Vehicle::passengerJump(0,%aiId,0);  //====================== Crude way to make passengers hop off vehicles :-P
	postAction(%aiId, IDACTION_JET, 2.0);
	schedule("postAction(" @ %aiId @ ", IDACTION_BREAK1, 0 );",4);
			  
	AI::DirectiveWaypoint(%aiName, %newPos, 2, 2);
}  

//========================================================================================================
// OK, this is the complete command callback - issued for any command sent
//    to an AI. 
//========================================================================================================

function AI::onCommand ( %name, %commander, %command, %waypoint, %targetId, %cmdText, 
         %cmdStatus, %cmdSequence )
{
	%aiId = AI::getId( %name );
	%T = GameBase::getTeam( %aiId );
	%groupId = nameToID("MissionGroup\\Teams\\team" @ %T @ "\\AI\\" @ %name ); 
	%nodeCount = Group::objectCount( %groupId );
	dbecho(2, "checking drone information...." @ " number of nodes: " @ %nodeCount);
	dbecho(2, "AI id: " @ %aiId @ " groupId: " @ %groupId);
   

//=================================================================================================== Bot Goes To Location

 	   if( %command == 1 )  //Attack
	   {
	   
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].
		  
	      %worldLoc = WaypointToWorld ( %waypoint );

	      AI::DirectiveRemove( %name, 2 );   //Crude way to clear all directives. Needs to be done because else the bots won't
                                             //respond to any new orders!

				Vehicle::passengerJump(0,%aiId,0);							   //Crude way to make passengers hop off vehicles :-P
				postAction(%aiId, IDACTION_JET, 2.0);                           //======== Atempt to make bots jet and jump
				schedule("postAction(" @ %aiId @ ", IDACTION_BREAK1, 0 );",4);

              %BotRot = GameBase::getRotation(%aiId);
			  
			  if(GameBase::getLOSInfo(Client::getOwnedObject(%aiId), 150, %BotRot))    //Test if AI is within firing range
                {
//	          AI::DirectiveTargetPoint( %name, %worldLoc, 2, 2);  //Fucks up AI::DirectiveList
                }
                else
                {
//	          AI::DirectiveWaypoint( %name, %worldLoc, 2, 2);
                }
	          AI::DirectiveWaypoint( %name, %worldLoc, 2, 2);  //Used this because TargetPoint fucked up the list
	   }




//============================================================================================================= Bot Defends

	   if( %command == 2 )  //Defend
	   {
	      // must convert waypoint location into world location.  waypoint location
	      //    is given in range [0-1023, 0-1023].  

	      %worldLoc = WaypointToWorld ( %waypoint );
	      
		  AI::DirectiveRemove( %name, 2 );   //Needs to be done because else the bots won't respond to any new orders!

//============================================================================================================= Bot Deploy

        if (getWord(%cmdText, 0) == "Deploy") //Deploy
        {
		
		   AI::DirectiveWaypoint(%aiName, %waypoint, 2, 2);

	          if (getWord(%cmdText, 1) == "pulse") //Deploy Pulse Sensor
	          {
	              AI::DeployItem(%aiId, PulseSensorPack);
	          }

	          if (getWord(%cmdText, 1) == "sensor") //Deploy Sensor Jammer
	          {
	              AI::DeployItem(%aiId, DeployableSensorJammerPack);
	          }
	
	          if (getWord(%cmdText, 1) == "motion") //Deploy Motion Sensor
	          {
	              AI::DeployItem(%aiId, MotionSensorPack);
	          }
	
	          if (getWord(%cmdText, 1) == "camera") //Deploy Camera
	          {
	              AI::DeployItem(%aiId, CameraPack);
	          }
	
	          if (getWord(%cmdText, 1) == "Ammo") //Deploy Ammo Station
	          {
	              AI::DeployItem(%aiId, DeployableAmmoPack);
	          }
	
	          if (getWord(%cmdText, 1) == "Inventory") //Deploy Inventory Station
	          {
	              AI::DeployItem(%aiId, DeployableInvPack);
	          }
	
	          if (getWord(%cmdText, 1) == "Turret") //Deploy Turret
	          {
	              AI::DeployItem(%aiId, TurretPack);
	          }
			  
			  if (getWord(%cmdText, 1) == "beacon") //Deploy Beacon
	          {
 	              AI::DeployItem(%aiId, Beacon);
  			  }
         }
          else
         {
             AI::DirectiveFollow( %name, %commander, 0,2);
		     dbecho ( 2, %name @ " IS PROCEEDING TO LOCATION " @ %worldLoc );
         }

	  	 if( %command == 3 )  //Repair
		 {
		     return;
		 }


	}
	   dbecho( 1, "AI::OnCommand() issued to  " @ %name @ "  with parameters: " );
	   dbecho( 1, "Cmdr:        " @ %commander );
	   dbecho( 1, "Command:     " @ %command );
	   dbecho( 1, "Waypoint:    " @ %waypoint );
	   dbecho( 1, "TargetId:    " @ %targetId );
	   dbecho( 1, "cmdText:     " @ %cmdText );
	   dbecho( 1, "cmdStatus:   " @ %cmdStatus );
	   dbecho( 1, "cmdSequence: " @ %cmdSequence );

 
}

//=======================================================================================
// Play the given wave file FROM %source to %DEST.  The wave name is JUST the basic wave
// name without voice base info (which it will grab for you from the source client Id).  
// Basically does some string fiddling for you.  
//
// Example:
//    Ai::soundHelper( 2051, cheer3 );
//


function Ai::soundHelper(%sourceId, %wName )
{

//   %wName = strcat( "~w", Client::getVoiceBase( %sourceId ) );
//   %wName = strcat( %wName, ".w" );
//   %wName = strcat( %wName, %waveFileName );
//   %wName = strcat( %wName, ".wav" );
  
   dbecho( 1, "Trying to play " @ %wName );
   
   %startCl = Client::getFirst();
   %endCl = %startCl + 60;
   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
   Client::sendMessage( %cl, 0, %wName );
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
   dbecho(2, "onPeriodic() called with " @ %aiName );
}


//=========================================================================
//The following callbacks are responsible for the bot's chasing behaviour.
//modified by Werewolf
//=========================================================================

function AI::onDroneKilled(%aiName)
{
   if( ! $SinglePlayer )
   {
      %aiId = AI::getId(%aiName);
      %team = GameBase::getTeam(%aiId);

      Player::blowUp(%aiId);

      dbecho(2, "AI Id: " @ %aiId);

		//for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))

  	  Client::SendMessage(%cl,1, %aiName @ ": Damnit!! You gonna pay for this!");
      
  	  %curTarget = ai::getTarget( %aiName );
  	  %targetName = Object::getName(%curTarget);

  	  AI::soundHelper(%aiId, "~wdsgst4");
  	  AI::messageHelper(%curTarget, "Damnit!!! You gonna pay for this, " @ %targetName);

		// Trying a little longer delay -
		
	  %rnd = floor(getRandom() * 10);
	  
			if(%rnd < 5)
			{	
				echo ("Bot is respawning...");
			    schedule("AI::setupAI(" @ %aiName @ ", " @ %team @ ");", 15 );
			}
				else
				{	
					if(%rnd > 4 && %rnd < 7)
					{	
						echo ("Short Circuit... Rogue Bot Spawning...");
						schedule("AI::setupAI(" @ %aiName @ ", -1);", 5 );
					}
					else 
					{
						echo("Bot Is Dead." );
					}
				}
			


   }
   else
   {
      // just in case:
      echo("Non training callback called from Training" );
   }

}

//=====================================================
//these AI function callbacks can be very useful!
//=====================================================

function AI::onTargetDied(%aiName, %idNum)
{
   %aiId = AI::getId(%aiName);
   %curTarget = %idNum;
   dbecho(1, %aiName @ " killed the enemy");

   %targetName = Object::getName(%curTarget);
   AI::soundHelper(%aiId, "~wcheer1");
   AI::messageHelper(%idNum, "Yeah! Owned.");

   AI::DirectiveRemove( %aiName, 125);
   
   if(%curTarget == -1)
   {
   	return;
   }
      
}                                 

function AI::onTargetLOSAcquired(%aiName, %idNum)
{
   dbecho(1, %aiName @ " just spotted an enemy");
   AI::HuntTarget(%aiName, %idNum, 1);
}

function AI::onTargetLOSLost(%aiName, %idNum)
{
   dbecho(1, %aiName @ " lost eye contact to enemy");
   AI::HuntTarget(%aiName, %idNum, 1);
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
   dbecho(1, %aiName @ " found the enemy again");
   AI::HuntTarget(%aiName, %idNum, 1);
}




function AI::HuntTarget(%aiName, %idNum, %Follow) //If %Follow is 0 then waypoint will be updated. If 1 then Bot will follow regardless of LOS.
{
   %aiId = AI::getId(%aiName);
   %curTarget = %idNum;

   if(%curTarget == -1)
   {
   	return;
   }
      
   dbecho(1, %aiName @ " target: " @ %curTarget);	
   
   %targLoc = GameBase::getPosition(Client::getOwnedObject(%curTarget));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %targetDist = Vector::getDistance(%aiLoc, %targLoc);
   dbecho(2, "distance to target: " @ %targetDist @ " targetPosition: " @ targLoc @ " aiLocation: " @ %aiLoc);


 if(String::findSubStr(%aiName, "Sniper") >= 0)
 {
   AI::SmartStayAway (%aiName, %idNum, %targLoc, 0, %targetDist, 100, 125);
 }

 if(String::findSubStr(%aiName, "Painter") >= 0)
 {
   AI::SmartStayAway (%aiName, %idNum, %targLoc, 0, %targetDist, 100, 125);
 }

 if(String::findSubStr(%aiName, "Guard") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 100, 125);
 }

 if(String::findSubStr(%aiName, "Demo") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 50, 125);
 }

 if(String::findSubStr(%aiName, "Medic") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 60, 125);
 }

 if(String::findSubStr(%aiName, "Miner") >= 0)
 {
   AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, 30, 125);
 }


}

//=============================================================================================================================
//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//If %Follow = 0 the AI will try to keep a minimum distance of %mintargetDist. If the distance is greater, it will come closer.
//If %Follow = 1 then the AI will follow the target %idNum to oblivion
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking
//=============================================================================================================================

function AI::SmartFollow (%aiName, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
   if (%Follow == 0)
    {
      if(%targetDist > %minTargetDist)
        {
          AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
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
          AI::DirectiveRemove( %aiName, %order);
        }
    }
}

//============================================================================================================
//added by Werewolf
//This is for "smart" chasing/attack of enemies.
//The AI will evade slightly until distance to enemy < %mintargetDist.
//%order is the order number of the directive, so you can have orders OVERWRITE each other instead of stacking
//============================================================================================================

function AI::SmartStayAway (%aiName, %idNum, %targLoc, %Follow, %targetDist, %mintargetDist, %order)
{
   if (%Follow == 0)
    {
      if(%targetDist < %minTargetDist)
        {
          AI::DirectiveWaypoint( %aiName, %targLoc, %order, 0 ); 

        }
        else
        {
          AI::DirectiveRemove( %aiName, %order);
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
          AI::DirectiveRemove( %aiName, %order);
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
   for(%i = %spawnIdx; %i < %value; %i++) {
      %set = newObject("set",SimSet);
      %obj = Group::getObject(%group, %i);
      if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) 
         return %obj;
      if(%i == %count - 1) {
         dbecho(1, "pickRandomSpawn error: You forgot to set Random Drop points in your map!");
         %i = -1;
         %value = %spawnIdx;
      }
      deleteObject(%set);
   }
   return false;
}



//========================================================================================================================================
//The following Callback isn't called - only God knows why..
//modified by Werewolf
//========================================================================================================================================

function AI::onCollision (%aiId, %object)
{


//============================================== Bot Class Specific

   %targLoc = GameBase::getPosition(Client::getOwnedObject(%object));
   %aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));
   %aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 

   dbecho(1, "obstacle location" @ %targLoc);
   dbecho(1, "ai location" @ %aiLoc);
   dbecho(1, "ai rotation" @ %aiLoc);

   dbecho(1, "onCollision called in ai.cs");
   Vehicle::passengerJump(0,%aiId,0);  //Crude way to make players avoid obstacles
   Vehicle::passengerJump(0,%object,0);

//============================================== Attempt Object Move Around

   %aiRotation = (%aiRotation + 90);

   %Length = 25;
   %Zvalue = 0; 
   %aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 

   Player::applyImpulse(%aiId, %aiVect); 



//Maybe the "testPosition" call can be used to check for obstacles, hmmm...
//	if(GameBase::testPosition(Client::getOwnedObject(%aiId),%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
//		%client = Player::getClient(%aiId);
//		%this.Seat[%passenger.vehicleSlot-2] = "";
//		%passenger.vehicleSlot = "";
//	    %passenger.vehicle= "";
//		Player::setMountObject(%passenger, -1, 0);
//		%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);
//		GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
//		GameBase::setPosition(Client::getOwnedObject(%aiId),%posX @ " " @ %posY @ " " @ (%posZ + %height));
//		%jumpDir = Vector::getFromRot(GameBase::getRotation(Client::getOwnedObject(%aiId)),%velocity,%zVec);
//		Player::applyImpulse(%aiId,%jumpDir);
//	}
//	else
//		Client::sendMessage(Player::getClient(%aiId),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
//


}






//=====================================================================
//This will spawn an AI player in a map that does not yet contain a bot
//=====================================================================

function AI::SpawnAdditionalBot(%aiName, %commandIssuer)
{

//===================================================================================================================== Develop Locations

   %issuerRot = GameBase::getRotation(%commandIssuer);
   %playerObj = Client::getOwnedObject(%commandIssuer);
   %playerPos = GameBase::getPosition(%commandIssuer);

   $numAI = 0;
   %spawnMarker = GameBase::getPosition(%commandIssuer);
   %xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 15);
   %yPos = getword(%spawnMarker, 1) + floor(getRandom() * 10);
   %zPos = getWord(%spawnMarker, 2) + 5;
   %rPos = GameBase::getRotation(%commandIssuer);

//===================================================================================================================== Develop Bot Types
//================================================================================================================================ Standard
    echo("BOT: Constructing Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)        //All the IFs are from Werewolf
      {
	  //echo("BOT: SPAWN: Base Bot");
      $AI::defaultArmorType = "lfemale";
      %voice = "female2";
      }
      else
      {
      $AI::defaultArmorType = "larmor";
      %voice = "male2";
      }

//================================================================================================================================= Medic
    if(String::findSubStr(%aiName, "Medic") >= 0)
    {
    //echo("BOT: SPAWN: Medic Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "efemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "earmor";
      %voice = "female2";
      }
    }

//================================================================================================================================ Guard
    if(String::findSubStr(%aiName, "Guard") >= 0)
    {
    //echo("BOT: SPAWN: Guard Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "darmor";
      %voice = "female5";
      }
      else
      {
      $AI::defaultArmorType = "darmor";
      %voice = "male5";
      }
    }
//================================================================================================================================= Demo
    if(String::findSubStr(%aiName, "Demo") >= 0)
    {
    //echo("BOT: SPAWN: Demo Bot");
    if(String::findSubStr(%aiName, "Female") >= 0)
      {
      $AI::defaultArmorType = "mfemale";
      %voice = "female4";
      }
      else
      {
      $AI::defaultArmorType = "marmor";
      %voice = "female2";
      }
    }

//========================================================================================================= Determin Spwn Point After Spawn

//   if(GameBase::getLOSInfo(%playerObj, 100, %issuerRot))    //Used to spawn AI at LOS target. Doesn't work correctly.
//   { 
//     %aiSpawnPos = $LOS::position;
//   }
//   else
//   {   
     %aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
//   }

   %xPos = getWord(%aispawnPos, 0);
   %yPos = getword(%aispawnPos, 1);
   %zPos = getWord(%aispawnPos, 2);

   %teamnum = GameBase::getTeam(%commandIssuer);

//   %newName = "STeam" @ %teamnum @ "_" @ %aiName;
//   %aiName = %newname;
//   newObject("AI", SimGroup);
//   newObject(%newName, SimGroup);
//   newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
//   addToSet(%newName, "Marker1");
//   addToSet("AI", %newName);
//   addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);


      %num = 1;
      %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
      %spawnSuccessfull = 0;


      if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
      {
        %spawnSuccessfull = 1;
      }
//	      else
//	      {
//	        %num++;
//	        %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
//	        if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
//	        {
//	          %spawnSuccessfull = 1;
//		    }
//		        else
//		        {
//		         %num++;
//		          %newName = "T" @ %teamnum @ "N" @ %num @"_" @ %aiName;
//		
//		          if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
//		          {
//		            %spawnSuccessfull = 1;
//		          }
			          else
			          {
			            dbecho( 1, "Cannot spawn " @ %aiName @ ", only 1 bots per class allowed for each team");
			          }



//        }
//      }


        newObject("AI", SimGroup);
        newObject(%newName, SimGroup);
        newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
        addToSet(%newName, "Marker1");
        addToSet("AI", %newName);
        addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);




// Above methos allows spawning of 3 bots per class and team. The old method below only allowed one.
// The problem was to try all names until a free name was found. That way you can control the number of bots the client can spawn...
// ... and we don't wanna have a player spawning huge armies of bots ;-)

//   Ai::spawn(%newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice );


         %aiId = AI::getId( %newName );
         GameBase::setTeam(%aiId, %teamnum);
         AI::setVar( %newName,  iq,  90 );
         AI::setVar( %newName,  attackMode, 1);
         AI::setVar( %newName,  pathType, $AI::defaultPathType);
         AI::DirectiveWaypoint( %newName, %aiSpawnPos, 2, 2 );
         schedule("AI::setWeapons(" @ %newName @ ");", 1);

   return ( %newName );
}


//================================================================================================= Bots deply goodies

function AI::DeployItem(%aiId,%desc)  //added by Werewolf. Yay I'm proud of this piece of code ;-)
{
    %item = %desc;
	%player = %aiId;

	echo(1, "Item description: \"" @ %desc @ "\"");

//--------------------------------------------------
// This doesn't work, so we have to do it manually.
//--------------------------------------------------
// Player::setItemCount(%aiId, %item, 1);
// Player::deployItem(%aiId,%item);
//--------------------------------------------------


%armor = Player::getArmor(%object);

        if (%item == "DeployableInvPack")
        {
			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
                addToSet("MissionCleanup", %inv);
				%rot = GameBase::getRotation(%aiId); 
				GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
				GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
				GameBase::setRotation(%inv,%rot);
				Gamebase::setMapName(%inv,%name);
				Client::sendMessage(%client,0,"Inventory Station deployed");
				playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
				echo("MSG: ",%client," deployed an Inventory Station");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Inventory Station There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Invo. Stations... Sorry.");
			return false;
			}
		}


        if (%item == "DeployableAmmoPack")
            {
			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
                addToSet("MissionCleanup", %inv);
				%rot = GameBase::getRotation(%aiId); 
				GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
				GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
				GameBase::setRotation(%inv,%rot);
				Gamebase::setMapName(%inv,%name);
				Client::sendMessage(%client,0,"Ammo Station deployed");
				playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
				echo("MSG: ",%client," deployed an Ammo Station");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Ammo Station There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Ammo Stations... Sorry.");
			return false;
			}
		}			
			
			
        if (%item == "MotionSensorPack")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.
			
                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployableMotionSensor",true);
                addToSet("MissionCleanup", %inv);
				%rot = GameBase::getRotation(%aiId); 
				GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
				GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
				GameBase::setRotation(%inv,%rot);
				Gamebase::setMapName(%inv,"Motion Sensor");
				Client::sendMessage(%client,0,"Motion Sensor deployed");
				playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%inv) @ "MotionSensorPack"]++;
				echo("MSG: ",%client," deployed a Motion Sensor");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Motion Sensor There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Motion Sensors... Sorry.");
			return false;
			}
		}					


        if (%item == "PulseSensorPack")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployablePulseSensor",true);
                addToSet("MissionCleanup", %inv);
				%rot = GameBase::getRotation(%aiId); 
				GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
				GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
				GameBase::setRotation(%inv,%rot);
				Gamebase::setMapName(%inv,"Pulse Sensor");
				Client::sendMessage(%client,0,"Pulse Sensor deployed");
				playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%inv) @ "PulseSensorPack"]++;
				echo("MSG: ",%client," deployed a Pulse Sensor");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Pulse Sensor There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Pulse Sensors... Sorry.");
			return false;
			}
        }

        if (%item == "DeployableSensorJammerPack")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %inv = newObject("","Sensor","DeployableSensorJammer",true);
                addToSet("MissionCleanup", %inv);
				%rot = GameBase::getRotation(%aiId); 
				GameBase::setTeam(%inv,GameBase::getTeam(%aiId));
				GameBase::setPosition(%inv,GameBase::getPosition(%aiId));
				GameBase::setRotation(%inv,%rot);
				Gamebase::setMapName(%inv,"Sensor Jammer");
				Client::sendMessage(%client,0,"Sensor Jammer deployed");
				playSound(SoundPickupBackpack, GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableSensorJammerPack"]++;
				echo("MSG: ",%client," deployed a Sensor Jammer");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Sensor Jammer There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Sensor Jammers... Sorry.");
			return false;
			}
        }
			


        if (%item == "CameraPack")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
				%camera = newObject("Camera","Turret",CameraTurret,true);
			   	addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%aiId));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,GameBase::getPosition(%aiId));
				Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Camera deployed");
				playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
				echo("MSG: ",%client," deployed a Camera");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Camera There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Cameras... Sorry.");
			return false;
			}
        }


        if (%item == "TurretPack")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %rot = GameBase::getRotation(%aiId); 
				%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
		        addToSet("MissionCleanup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%aiId));
				GameBase::setPosition(%turret,GameBase::getPosition(%aiId));
				GameBase::setRotation(%turret,%rot);
				Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Remote Turret deployed");
				playSound(SoundPickupBackpack,GameBase::getPosition(%aiId));
				$TeamItemCount[GameBase::getTeam(%aiId) @ "TurretPack"]++;
				echo("MSG: ",%client," deployed a Remote Turret");
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Turret There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Turrets... Sorry.");
			return false;
			}
        }


        if (%item == "Beacon")
            {

			if($TeamItemCount[GameBase::getTeam(%aiId) @ %item] < $TeamItemMax[%item]) {  //=== Attempt To Limit Deployables.

                %client = Player::getClient(%aiId);
                %beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%aiId));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,GameBase::getPosition(%aiId));
				Gamebase::setMapName(%beacon,"Target Beacon");
				Beacon::onEnabled(%beacon);
				Client::sendMessage(%client,0,"Beacon deployed");
				$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
            }
			else
			{
			echo("MSG: ",%client," Cannot Deploy Becon There Are Too Many.");
		 	Client::sendMessage(%client,0,"Deployable Item limit reached for Becons... Sorry.");
			return false;
			}
        }
}


