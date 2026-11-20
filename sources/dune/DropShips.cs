//*******************************************************************************
//	These functions control the automated dropship abilites of DUNE.	*
// It should be able to handle multiple drop ships at a time, and		*
// the abilities of those drop ships can be expanded at any time.		*
//	In order to use this module, the map must have a group in it		*
// called "DropShip" which contains a bunch of waypoint markers that		*
// determine the dropship's waypoints and rotations at those waypoints.		*
// The waypoints much each be given a "sequenceLoc" value, 			*
// ("sequenceLoc = -1;" for example) which you will need to put in AFTER	*
// the map is completed. The dropship will travel from the least		*
// to the greatest, and stop at the 0 marker for a time. So basically,		*
// negative numbers is the "landing sequence" and positive numbers is		*
// the "departure sequence" with the 0 waypoint as the "landed" position.	*
// The dropship must be the first object in the group. It can be placed, as a 	*
// default location, out of the way at position "0 0 -1000". If you're using an	*
// Invasion dropship, you must have, as the last object in the group, another 	*
// group called "DropPoints" that contains the droppoints that will be 		*
// activated by that dropship.
// 	Additionally, DropShip::Inilitize() must be called upon start of 	*
// the mission, for each dropship, usualy in the mission intro function. When  	*
// called, it must have a parameter that defines the location of the DropShip 	*
// group, in relation to the map's other groups. For example,			*
//   DropShip::Initilize("MissionGroup/tower0/DropShip");			*
// or										*
//   DropShip::Initilize("MissionGroup/teams/team0/DropShip");			*
// Be as specific as you want, but make sure that it is owned by a team.	*
// The dropship will NOT come unless the group/dropship it is in is owned by a	*
// team.									*
// 	Lastly, make sure to, in the map constants, define the constants	*
// below. Currently all dropships on a map have to be of one type.		*
//										*
//*******************************************************************************

// Defines which prefab we use for the ship.
// $DropShip::Type = "Cargo"; // Cargo, Invasion
// Defines what the ship does when its landed.
// $DropShip::Perform = "TeamEnergyBoost"; // TeamEnergyBoost, TriggerRespawn
// How often do you want a dropship to arrive? (will be fuzzed up by 60%)
// $DropShip::ShipmentPeriods = 10; //In minutes.
// How long should the ship unload for?
// $DropShip::UnloadTime = 3; //In minutes.
// If its a cargo, how much TE should it unload ever second?
// $DropShip::CargoPerSec = 100;


// Private constants. Don't Touch!!!!
// $DropShip::ShipWaypoints[1]
// $DropShip::Ship[1]

//Dont touch!
$DropShip::NumberOfWaypoints = 0;
$DropShip::TimeJump = 0.005;
$DropShip::DistJump = 0.1;
$DropShip::RotJump = 0.001;


//*************************************************************************
// Name: 	DropShip::Inilitize
// Description: Will organize the dropship waypoints, and will start the
//		arrival driver.
//
// Param:	%location	What group directory are the waypoints in?
//
//*************************************************************************
function DropShip::Initilize(%location,%time)
{
   	%group = nameToID(%location);
   	%count = Group::objectCount(%group);
	$DropShip::ShipWaypoints = "";
	
	// Make sure we have at least one waypoint, and make sure the 
	//  waypoints are owned.
   	if(%count == 0 || %count == 1){

   		return -1;
	}
	else if(gamebase::GetTeam(Group::getObject(%group, 0)) == -1)
	{
		Schedule("DropShip::Initilize(\""@%location@"\");",30);
		return;
	}
	$DropShip::NumberOfWayPoints++;
	%num = $DropShip::NumberOfWayPoints;

	for(%i = 0; %i < %count; %i++)
	{
		$DropShip::ShipWaypoints[%num, %i] = "";
	}

	//Remember our ship
	$DropShip::Ship[%num] = Group::getObject(%group, 0);
	$DropShip::Path[%num] = %location;

	//Organize them from greatest to least.
	for(%x = 1; %x < %count; %x++)
	{
		%Done = false;
		%obj = "";
		%obj = Group::getObject(%group, %x);
		for(%y = 0; %y < (%count-1) && !%Done; %y++)
		{
			if(%obj != "" && %obj.sequenceLoc != "") {
				if( $DropShip::ShipWaypoints[%num, %y] == "" 
				 || $DropShip::ShipWaypoints[%num, %y].sequenceLoc == "") {
					$DropShip::ShipWaypoints[%num, %y] = %obj;
					%Done = true;
				} else if ($DropShip::ShipWaypoints[%num, %y].sequenceLoc > %obj.sequenceLoc) {
					%temp = $DropShip::ShipWaypoints[%num, %y];
					$DropShip::ShipWaypoints[%num, %y] = %obj;
					%obj = %temp;
				}
			}
		}	
	}

	$DropShip::DropPoints[$DropShip::Ship[%num]] = nameToId(%location @ "/DropPoints");
	
	if(%time == "")
		%time = 2;
	DropShip::ArrivalDriver(%num, %time);
	//DropShip::Create(%num);
}

//function readwp()
//for(

//*************************************************************************
// Name: 	DropShip::ArrivalDriver
// Description: Will control the landing initilizations, timing their
//		departures appropriately.
//
// Param:	%wpNum		Which waypoint set we are using.
//		%nextArrivalTime	The amount of time till the next
//					arrival.
//
//*************************************************************************
function DropShip::ArrivalDriver(%wpNum, %nextArrivalTime)
{
//echo(%nextarrivaltime);
	if($DropShip::ShipWaypoints[%wpnum,0] == -1)
		return;
	
	if( %nextArrivalTime == -1 ){
		%nextArrivalTime = floor($DropShip::ShipmentPeriods*(1+getrandom()*0.6));

	} else if( %nextArrivalTime == 0 ) {
		%nextArrivalTime = -1;
		DropShip::Create(%wpNum);
		TeamMessages(1, gamebase::getteam($Dropship::ship[%wpNum]), "Shipment enroute to delivery location. Clear the landing zone.~wmine_act.wav");
	} else {
		
		if( %nextArrivalTime == 3 )
			MessageAll(1, "Next Shipment arrival in T-3 minutes.~wmine_act.wav");
			
		%nextArrivalTime = %nextArrivalTime - 0.5;
	}
	Schedule("DropShip::ArrivalDriver("@%wpNum@","@%nextArrivalTime@");",30);
}


//*************************************************************************
// Name: 	DropShip::Create
// Description: Creates the proper drop ship and assigns a waypoint set
//		to it.
//
// Param:	%wpNum		Which waypoint set we are using.
//
//*************************************************************************
function DropShip::Create(%wpNum)
{
//	if($DropShip::Type == "Cargo")
//		%ship = newObject("DropShip", InteriorShape,"bedrop.dis");
//	else if($DropShip::Type == "Invasion")
//		%ship = newObject("DropShip", InteriorShape,"gswdrop.dis");
//	addToSet("MissionCleanup",%ship);
	
	
	%ship = $Dropship::ship[%wpNum];
	%ship.waypointNumber = %wpNum;
echo("Comming in");
// Start the arrival
	if(%ship == "") {
		echo("Error: No ship type selected.");
		return;	
	}
	DropShip::ArrivalSequence(%ship, 0, 0);
}


//*************************************************************************
// Name: 	DropShip::ArrivalSequence
// Description: Keeps the dropship moving through the waypoints until it
//		gets to waypoint squence number 0.
//
// Param:	%dropship	Our Dropship object.
//		%nextMarker	The waypoint we are heading to.
//
//*************************************************************************
function DropShip::ArrivalSequence(%dropship, %nextMarker, %counter)
{
//echo(%nextMarker);
//echo(%dropship);
//return;

	%num = %dropship.waypointnumber;
	if( %nextMarker == 0 )
	{
		%curMarker = $DropShip::ShipWaypoints[%num, %nextMarker];
//echo(%curmarker@ " : " @gamebase::Getposition(%curmarker));
		GameBase::setRotation(%dropship,gamebase::getrotation(%curMarker));
		GameBase::setPosition(%dropship,gamebase::Getposition(%curMarker));
		%nextMarker++;
		%counter++;
		Schedule("DropShip::ArrivalSequence("@%dropship@","@%nextMarker@","@%counter@");",$DropShip::TimeJump);

	} else if($DropShip::ShipWaypoints[%num, %nextMarker].sequenceLoc == 1){
		GameBase::setPosition(%ship,gamebase::Getposition($DropShip::ShipWaypoints[%num, (%nextMarker-1)]));		
		%rot = gamebase::getrotation($DropShip::ShipWaypoints[%num, (%nextMarker-1)]);
		GameBase::setRotation(%ship,%rot);
		
		//Block Enterences		

//echo(%Dropship);
		Schedule("DropShip::perform("@%dropship@", "@%nextMarker@");",5);

	} else {
		
		%nextwp = $DropShip::ShipWaypoints[%num, %nextMarker];
//		%lastmarker = $DropShip::ShipWaypoints[%num, (%nextMarker-1)];

		%nextPos = gamebase::Getposition(%nextwp);
//echo(%nextMarker @ " : " @ %nextPos);
		%nextRot = gamebase::getrotation(%nextwp);
//		%lastPos = gamebase::Getposition(%lastMarker);
		%lastRot = gamebase::getrotation(%lastmarker);
//		%time = Vector::getDistance(%nextPos,%lastpos)/$DropShip::DistJump;
//		%CurRotJump = vector::getdistance(%nextRot,%lastRot)/%time;
//echo("CRJ " @%CurRotJump);
//echo(gamebase::Getposition(%dropship));
		%dropship.lastpos = gamebase::Getposition(%dropship);
		%curPosition = vector::Add(vector::getFromRot(vector::getrotaim(gamebase::Getposition(%dropship),%nextPos),$DropShip::DistJump),gamebase::Getposition(%dropship));
		gamebase::setposition(%dropship,%curPosition);
//		if($DropShip::RotJump != 0)
			%curRotation = Vector::Add(vector::getFromRot(vector::getrotaim(gamebase::GetRotation(%dropship),%nextRot),$DropShip::RotJump),gamebase::GetRotation(%dropship));
//		else
//			%curRotation = Vector::Add(vector::getFromRot(vector::getrotaim(gamebase::GetRotation(%dropship),%nextRot),%CurRotJump),gamebase::GetRotation(%dropship));

		gamebase::setRotation(%dropship,%curRotation);
//echo("Pos: " @ %curposition);
		
//		if((%curPosition > %nextPos-0.01 || %curPosition < %nextPos+0.01)
//		   && (%curRotation > %nextRot-0.01 || %curRotation < %nextRot+0.01))
//			%nextMarker++;
//echo("**"@%curPosition @ " : " @ %nextPos @ " : " @ vector::getdistance(%curPosition,%nextPos));
		if((vector::getdistance(%curPosition,%nextPos) < 1.0 && vector::getdistance(%curPosition,%nextPos) > -1.0 )
		 &&(vector::getdistance(%curRotation,%nextRot) < 0.01 && vector::getdistance(%curRotation,%nextRot) > -0.01 )){
			%nextMarker++;
//echo("Next");
		}

		if($Dropship::Type == "Cargo" && %counter%50 == 0)
			booster(%dropship, 1);
		else if(%counter%75 == 0)
			booster(%dropship, 1);
		//DropShip::AnimateBoosters(%dropShip);
		%counter++;
		Schedule("DropShip::ArrivalSequence("@%dropship@","@%nextMarker@","@%counter@");",$DropShip::TimeJump);

	}

}

function DropShip::perform(%dropship, %nextMarker, %time)
{
	%team = gamebase::getteam(%dropship);
	if(!%time) {
		TeamMessages(1, %team, "Landing sequence complete. Unloading.~wmine_act.wav");
		%time = 1;
		schedule("DropShip::perform("@%dropship@", "@%nextMarker@", "@%time@");",1);
	} else if(%time == ($DropShip::UnloadTime*60)) {	
		if($DropShip::Perform == "TriggerRespawn")
		{
			//$RespawnEnabled = false;

			%DropSet = nameToID("MissionCleanup/TeamDrops" @ gamebase::getTeam(%Dropship));

			if($DropShip::DropPoints[%dropship] != -1)
			{
				%dropPoints = $DropShip::DropPoints[%dropship];
				for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      			 	{
         				removeFromSet(%DropSet, %dropPoint);
 				}			
			}
		
		}
		TeamMessages(1, %team, "Goods deployed. Initiating departure sequence in 20 seconds. Clear the landing zone.~wmine_act.wav");
		schedule("Dropship::DepartureSequence("@%dropship@", "@%nextMarker@");", 20);
		
	} else {
		if($DropShip::Perform == "TeamEnergyBoost") {
			$TeamEnergy[%team] += $DropShip::CargoPerSec;
		} else if($DropShip::Perform == "TriggerRespawn") {
			//$RespawnEnabled = true;
			
			%DropSet = nameToID("MissionCleanup/TeamDrops" @ gamebase::getTeam(%Dropship));
			
			if($DropShip::DropPoints[%dropship] != -1)
			{
				%dropPoints = $DropShip::DropPoints[%dropship];
				for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      			 	{
         				addToSet(%DropSet, %dropPoint);
				}			
			}
		} 
		%time++;
		schedule("DropShip::perform("@%dropship@", "@%nextMarker@", "@%time@");",1);

	}
}

function Dropship::DepartureSequence(%dropShip, %nextMarker,%counter)
{
// remove entrences

	%num = %dropship.waypointnumber;

	if($DropShip::ShipWaypoints[%num, %nextMarker] == ""){
		DropShip::Delete(%dropship);

	} else {
		%nextwp = $DropShip::ShipWaypoints[%num, %nextMarker];

		%nextPos = gamebase::Getposition(%nextwp);
		%nextRot = gamebase::getrotation(%nextwp);
		
		%dropship.lastpos = gamebase::Getposition(%dropship);
		%curPosition = vector::Add(vector::getFromRot(vector::getrotaim(gamebase::Getposition(%dropship),%nextPos),$DropShip::DistJump),gamebase::Getposition(%dropship));
		gamebase::setposition(%dropship,%curPosition);
		%curRotation = Vector::Add(vector::getFromRot(vector::getrotaim(gamebase::GetRotation(%dropship),%nextRot),$DropShip::RotJump),gamebase::GetRotation(%dropship));
		gamebase::setRotation(%dropship,%curRotation);
//echo(%curRotation);
		if((vector::getdistance(%curPosition,%nextPos) < 1.0 && vector::getdistance(%curPosition,%nextPos) > -1.0 )
		 &&(vector::getdistance(%curRotation,%nextRot) < 0.01 && vector::getdistance(%curRotation,%nextRot) > -0.01 )){
			%nextMarker++;
		}

		
		if( %counter%50 == 0)
			booster(%dropship, 1);
		%counter++;
		//DropShip::AnimateBoosters(%dropShip);
		Schedule("DropShip::DepartureSequence("@%dropship@","@%nextMarker@","@%counter@");",$DropShip::TimeJump);

	}
}

function DropShip::Delete(%dropship)
{
	gamebase::setposition(%dropship, "0 0 -1000");
	gamebase::setrotation(%dropship, "0 0 0");
}

function DropShip::AnimateBoosters(%dropShip)
{
//animate specified boosters

}

function DropShips::CanSpawn(%client)
{
	%spawnSet = nameToID("MissionCleanup/TeamDrops" @ gamebase::getteam(%client));
	%spawnCount = Group::objectCount(%spawnSet);

	if(%spawncount < 1)
	{
           	Client::sendMessage(%client, $MSGTypeGame, "There are no spawn points available. You must wait until an invasion ship lands, or an objective with spawnpoints is captured.");
		return false;
	}
	return true;
}

function DropShip::getTeamObserverPoint(%client)
{
	%ship = 1+floor($DropShip::NumberOfWayPoints*(getRandom()));
	if(%ship < 1 || %ship > $DropShip::NumberOfWayPoints)
		%ship = 1;
	%path = $Dropship::path[%ship];
	%group = nameToId(%path @ "/DropPoints");
	%drop = floor(group::objectcount(%group)*getRandom());
	%droppoint = Group::getObject(%group, %drop);
	Observer::setOrbitObject(%client, %droppoint, 5, 5, 5);
}

function Shoot(%pos1, %rot)
{
	%rot1 = Vector::Add(%rot,"0 0 3.141592654");
	%vec  = Vector::getFromRot(%rot1,1);
	%pos = GetOffSetRot("10 0 10",%rot,%pos1);
	%vel = Vector::getFromRot(%rot1,-100);
	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec@" "@%rot1@" "@%pos,2048,%vel);

	%rot1 = Vector::Add(%rot,"0 0 3.141592654");
	%vec  = Vector::getFromRot(%rot1,1);
	%pos = GetOffSetRot("-10 0 10",%rot,%pos1);
	%vel = Vector::getFromRot(%rot1,-100);
	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec@" "@%rot1@" "@%pos,2048,%vel);
}

function GetOffSetRot2(%offset,%rot,%pos)
{
//echo("********");
//echo("Off " @%offset);
	%x = getWord(%offset,0);
	%y = getWord(%offset,1);
	%z = getWord(%offset,2);
//echo(%pos);
	%posA = Vector::add(%pos,Vector::getFromRot(%rot,%x));
//echo(%posA);
	%posB = Vector::add(%posA,Vector::getFromRot(%rot,%z));
//echo(%posB);
	%posC = Vector::add(%posB,Vector::getFromRot(%rot,%y));
//echo(%posC);
	return %posC;
}

function TestCalc(%object, %offset)
{
	%pos = gamebase::getposition(%object);
	echo("Pos: " @ %pos);
	%rot = gamebase::getrotation(%object);
	echo("Rot: " @ %rot);
	echo("Off: " @ %offset);
	%newpos = getOffsetRot2(%offset,%rot,%pos);
	echo("New: "@ %newpos);
}


// %off = offset from position (c constant)
// %rot = rotation of original
// %pos = position of original

function PositionBasedOnRotation(%off, %rot, %pos)
{
	// rot = 0,0   newpos = 1,0
	// rot = 0
	
	%newPos = vector::Add(%pos, Vector::getFromRot(%rot,%off));
		
	return %NewPos;
}


function booster(%dropship, %local)
{

	%lastpos = %dropship.lastpos;	
	%pos1 = gamebase::Getposition(%dropship);
	%rot = gamebase::getrotation(%dropship);


	if(((getword(%rot,0) < 0.52359 && getword(%rot,0) > -0.52359) || (getword(%rot,0) < 6.80678 && getword(%rot,0) > 5.759586532))
		&& ((pow(getword(%lastPos,2)-getword(%pos1,2),2) > pow(getword(%lastPos,0)-getword(%pos1,0),2)) &&
			(pow(getword(%lastPos,2)-getword(%pos1,2),2) > pow(getword(%lastPos,0)-getword(%pos1,0),2))))
		%local = 2;
	else if(((getword(%rot,0) < 0.52359 && getword(%rot,0) > -0.52359) || (getword(%rot,1) < 6.80678 && getword(%rot,1) > 5.759586532))
		&& ((pow(getword(%lastPos,2)-getword(%pos1,2),2) < pow(getword(%lastPos,1)-getword(%pos1,1),2)) ||
			(pow(getword(%lastPos,2)-getword(%pos1,2),2) < pow(getword(%lastPos,0)-getword(%pos1,0),2))))
		%local = 1;
	else if(((getword(%rot,0) > 0.52359 && getword(%rot,0) < 2.094395) || (getword(%rot,0) < 5.759586532 && getword(%rot,0) > 3.665191429))
		&& ((pow(getword(%lastPos,2)-getword(%pos1,2),2) > pow(getword(%lastPos,1)-getword(%pos1,1),2)) &&
			(pow(getword(%lastPos,2)-getword(%pos1,2),2) > pow(getword(%lastPos,0)-getword(%pos1,0),2))))
		%local = 1;
	else if(((getword(%rot,0) > 0.52359 && getword(%rot,0) < 2.094395) || (getword(%rot,0) < 5.759586532 && getword(%rot,0) > 3.665191429))
		&& ((pow(getword(%lastPos,2)-getword(%pos1,2),2) < pow(getword(%lastPos,1)-getword(%pos1,1),2)) ||
			(pow(getword(%lastPos,2)-getword(%pos1,2),2) < pow(getword(%lastPos,0)-getword(%pos1,0),2))))
		%local = 2;

	
//	if((sqrt(pow((getword(%lastpos,0) - getword(%pos1,0)),2)) > sqrt(pow((getword(%lastpos,2) - getword(%pos1,2)),2))
//	 || sqrt(pow((getword(%lastpos,1) - getword(%pos1,1)),2)) > sqrt(pow((getword(%lastpos,2) - getword(%pos1,2)),2)))
//	 && ((getword(%rot,0) < 0.785398  && getword(%rot,0) > -0.785398)||(getword(%rot,0) < 3.92699  && getword(%rot,0) > 2.35619449)||(getword(%rot,1) > 5.49778  && getword(%rot,1) < 7.06858)))
//		%local = 2;
//	else
//		%local = 1;

	
	if(sqrt(pow((getword(%lastpos,0) - getword(%pos1,0)),2)) < ($DropShip::DistJump/10)
	|| sqrt(pow((getword(%lastpos,1) - getword(%pos1,1)),2)) < ($DropShip::DistJump/10))
		%local = 2;

	if(sqrt(pow((getword(%lastpos,2) - getword(%pos1,2)),2)) > ($DropShip::DistJump -0.1))
		%local = 2;

	%rot1 = Vector::Add(%rot,"0 0 3.141592654");
	%rot2 = Vector::Add(%rot,"-1.570796327 0 0");
	
	%vec1  = Vector::getFromRot(%rot1,1);
	%vec2  = Vector::getFromRot(%rot2,1);
	
	%vel1 = Vector::getFromRot(%rot1,-100);
	%vel2 = Vector::getFromRot(%rot2,100);
	
	if(%local == 1){
	// Back left
	//%pos = PositionBasedOnRotation(
//	%pos = GetOffSetRot("20.014 25.700 12.7",%rot,%pos1);
//	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);
	
	// Back center
//	%pos = GetOffSetRot("0 25.700 12.7",%rot,%pos1);
//	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);
	
	// Back right
//	%pos = GetOffSetRot("-20.014 25.700 12.7",%rot,%pos1);
//	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);

	%pos = GetOffSetRot("20.014 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,"0 0 0 0 0 0 "@%rot1@" "@%pos,2048,%vel1);
	
	// Back center
	%pos = GetOffSetRot("0 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,"0 0 0 0 0 0 "@%rot1@" "@%pos,2048,%vel1);
	
	// Back right
	%pos = GetOffSetRot("-20.014 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,"0 0 0 0 0 0 "@%rot1@" "@%pos,2048,%vel1);
	
	} else if (%local == 2) {

	if($DropShip::Type == "Cargo")
	{
		// bottom back right
		%pos = GetOffSetRot("-17.2 18.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back left
		%pos = GetOffSetRot("17.2 18.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);	

		// bottom center
		%pos = GetOffSetRot("0 6 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front right
		%pos = GetOffSetRot("-17.2 -5.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front left
		%pos = GetOffSetRot("17.2 -5.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back right
		//%pos = GetOffSetRot("-17.2 18.5 5.5",%rot,%pos1);
		//projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

	} else if($DropSHip::type == "Invasion")
	{
		// bottom back right
		%pos = GetOffSetRot("-16.2 17.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back left
		%pos = GetOffSetRot("16.2 17.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);	

		// bottom front right
		%pos = GetOffSetRot("-16.2 -4.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front left
		%pos = GetOffSetRot("16.2 -4.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
	}	
	} else {
//echo(%local);
	// Back left
	%pos = GetOffSetRot("20.014 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);

	// Back center
	%pos = GetOffSetRot("0 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);

	// Back right
	%pos = GetOffSetRot("-20.014 25.700 12.7",%rot,%pos1);
	projectile::spawnProjectile(BoosterFlame,%rot1@" "@%vec1@" "@%rot1@" "@%pos,2048,%vel1);

	if($DropShip::Type == "Cargo")
	{
		// bottom back right
		%pos = GetOffSetRot("-17.2 18.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back left
		%pos = GetOffSetRot("17.2 18.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);	

		// bottom center
		%pos = GetOffSetRot("0 6 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front right
		%pos = GetOffSetRot("-17.2 -5.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front left
		%pos = GetOffSetRot("17.2 -5.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back right
		//%pos = GetOffSetRot("-17.2 18.5 5.5",%rot,%pos1);
		//projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

	} else if($DropSHip::type == "Invasion")
	{
		// bottom back right
		%pos = GetOffSetRot("-16.2 17.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
		// bottom back left
		%pos = GetOffSetRot("16.2 17.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);	

		// bottom front right
		%pos = GetOffSetRot("-16.2 -4.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);

		// bottom front left
		%pos = GetOffSetRot("16.2 -4.5 5.5",%rot,%pos1);
		projectile::spawnProjectile(BoosterFlame,%rot2@" "@%vec2@" "@%rot2@" "@%pos,2048,%vel2);
	
	}	

	}

}


RocketData BoosterFlame1
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmaExp;
   collisionRadius  = 1.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength = 200.0;
   muzzleVelocity   = 225.0;
   terminalVelocity = 225.0;
   acceleration     = 5.0;
   totalTime        = 0.125;
   liveTime         = 0.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

GrenadeData BoosterFlame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 4.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.125;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};


function BoosterFlame::onAdd(%this)
{
//	echo(gamebase::getposition(%this));
//	schedule("BoosterTrail(" @ %this @ ");",0.05,%this); 
}

function BoosterTrail(%this)
{
	if(%this){
		%position = GameBase::getPosition(%this);
		%player = %this.owner;
		//%rotation = GameBase::getRotation(%this); // get rotation of object...
		%velocity = Item::getVelocity(%this); // get velocity of object...
		%transform = "0 0 0 0 0 0 0 0 0 "@ %position; // make the transform for the new object...
			
		Projectile::spawnProjectile(BoosterExplosion, %transform, %player, %velocity); // spawn new projectile
		schedule("Projectile::spawnProjectile(BoosterExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.2, %this); 
		schedule("Projectile::spawnProjectile(BoosterExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.4, %this); 
		schedule("Projectile::spawnProjectile(BoosterExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.6, %this); 
		schedule("Projectile::spawnProjectile(BoosterExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.8, %this); 
		schedule("Projectile::spawnProjectile(BoosterExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 1.0, %this); 
		schedule("FlameTrail(" @ %this @ ");",0.2,%this); 
	}

}
GrenadeData BoosterExplosion
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasma2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 4.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};




function testsetRotation(%dropship, %lastRot, %nextRot, %rotjump)
{
	%curRotation = Vector::Add(vector::getFromRot(vector::getrotaim(%lastRot,%nextRot),%RotJump),gamebase::GetRotation(%dropship));
	gamebase::setRotation(%dropship,%curRotation);
	echo(gamebase::Getrotation(%dropship));
}

function spawnobject(%location)
{
	%ship = newObject("DropShip", InteriorShape,"gbedrop.dis");
	addToSet("MissionCleanup",%ship);
	echo(%ship);
	gamebase::Setposition(%ship, vector::Add(%location,"0 0 30"));
}

$curposition = "0 0 0";
function testmove(%next)
{
	if($stop)
	return;
		//%last = $curposition;
		//$curposition = vector::Add(vector::getFromRot(vector::getrotaim(%last,%next),$DropShip::DistJump),%last);
		//echo($curposition);
		//if(%counter
		schedule("testmove(\""@%next@"\");", 0.5);
}


function lagtest(%veh, %numBs)
{
	%pos = gamebase::Getposition(%veh);
	for(%i = 0; %i < %numBS; %i++)
	{
		%set = newObject("set",SimSet); // make new box for testing.
		%number = containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType|$StaticObjectType,%pos,20,20,200,0);
		echo(%set @ "  "@ %number);
	}

}

function MakeVehicle(%vehname, %client)
{
	%vehicle = newObject("",flier,$DataBlockName[%vehname],true);
	Gamebase::setMapName(%vehicle,%item.description);
	%vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	gamebase::setposition(%vehicle, vector::Add(gamebase::getposition(%client),"0 0 10"));

}

function CommandTent::place( %player )
{
	%team = GameBase::getTeam(%player);
	%position = Gamebase::getposition(%player);
	
	%rot = Gamebase::getrotation(%player);	
	//%rot = NewRotation(%rot,"left");
	%position = GetOffSetRot2("2 2 3.189",%rot,%position);
	
	%posTn1 = GetOffSetRot("7.725 0 1",%rot,%position);
	%posTn2 = GetOffSetRot("0 0 1",%rot,%position);
	%posTn3 = GetOffSetRot("11.5 0 -7",%rot,%position);
	%posTn4 = GetOffSetRot("-3.75 0 -7",%rot,%position);
	%posGen = GetOffSetRot("0.054 6.064 -2",%rot,%position);
	%posRep = GetOffSetRot("-5.025 -1.892 -2",%rot,%position);
	%posSt1 = GetOffSetRot("7.183 6.209 -2",%rot,%position);
	%posSt2 = GetOffSetRot("7.256 11.637 -2",%rot,%position);
	%posCmd = GetOffSetRot("-0.216 10.557 -2",%rot,%position);

	%rotTn1 = Vector::add(%rot,"0 -2.44334 0");
	%rotTn2 = Vector::add(%rot,"0 2.44334 0");
	%rotTn3 = Vector::add(%rot,"0 -1.57 0");
	%rotTn4 = Vector::add(%rot,"0 1.57 0");
	%rotSt1 = Vector::add(%rot,"0 -0 -1.59988");
	%rotSt2 = Vector::add(%rot,"0 -0 -1.59988");
	%rotCmd = Vector::add(%rot,"0 -0 1.59988");

	%Tent1 = newObject("Bunker", InteriorShape,"flatbrdg512.dis");
	%Tent2 = newObject("Bunker", InteriorShape,"flatbrdg512.dis");
	%Tent3 = newObject("Bunker", InteriorShape,"flatbrdg512.dis");
	%Tent4 = newObject("Bunker", InteriorShape,"flatbrdg512.dis");
	%gen = newObject("Bunker", "StaticShape", "PortGenerator", false);
	%reppack = newObject("Bunker", "Item", "RepairPack", 10, true, true);
	%station1 = newObject("Bunker", "StaticShape", "InventoryStation", false);
	%station2 = newObject("Bunker", "StaticShape", "InventoryStation", false);
	%cmdStation = newObject("Bunker", "StaticShape", "CommandStation", false);
	
	%Group2 = newObject("CommandTent", SimGroup,"Group");
	addToSet("MissionCleanup/team"@%team@"/DropBase",%Group2);
	
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%Tent1);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%Tent2);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%Tent3);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%Tent4);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%gen);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%reppack);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%station1);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%station2);
	addToSet("MissionCleanup/team"@%team@"/DropBase/CommandTent",%cmdstation);
	
	//GameBase::setPosition(%gen,Vector::add(%position, "0.054 6.064 -2"));
	GameBase::setRotation(%gen,%rot);
	GameBase::setPosition(%gen,%posGen);

	if(GameBase::getLOSInfo(%gen,10,NewRotation(%rot,"down")))
		GameBase::setPosition(%gen,$los::position);

	//GameBase::setPosition(%reppack,Vector::add(%position, "-5.025 -1.892 -2"));
	GameBase::setRotation(%reppack,%rot);
	GameBase::setPosition(%reppack,%posRep);

	if(GameBase::getLOSInfo(%reppack,10,NewRotation(%rot,"down")))
		GameBase::setPosition(%reppack,$los::position);

	//GameBase::setRotation(%station1,"0 -0 -1.59988");
	GameBase::setRotation(%station1,%rotSt1);
	//GameBase::setPosition(%station1,Vector::add(%position, "7.183 6.209 -2"));
	GameBase::setPosition(%station1,%posSt1);

	if(GameBase::getLOSInfo(%station1,10,NewRotation(%rot,"down")))
		GameBase::setPosition(%station1,$los::position);

	//GameBase::setRotation(%station2,"0 -0 -1.57988");
	GameBase::setRotation(%station2,%rotSt2);
	//GameBase::setPosition(%station2,Vector::add(%position, "7.256 11.637 -2"));
	GameBase::setPosition(%station2,%posSt2);

	if(GameBase::getLOSInfo(%station2,10,NewRotation(%rot,"down")))
		GameBase::setPosition(%station2,$los::position);
	
	//GameBase::setRotation(%cmdstation, "0 -0 1.59988");
	GameBase::setRotation(%cmdstation,%rotCmd);
	//GameBase::setPosition(%cmdstation,Vector::add(%position, "-0.216 10.557 -2"));
	GameBase::setPosition(%cmdstation,%posCmd);
	
	if(GameBase::getLOSInfo(%cmdstation,10,NewRotation(%rot,"down")))
		GameBase::setPosition(%cmdstation,$los::position);

	//GameBase::setRotation(%tent1,"0 -2.44334 0");
	GameBase::setRotation(%tent1,%rotTn1);
	//GameBase::setPosition(%tent1,Vector::add(%position, "7.725 0 1"));
	GameBase::setPosition(%tent1,%posTn1);

	//GameBase::setRotation(%tent2,"0 2.44334 0");
	GameBase::setRotation(%tent2,%rotTn2);
	//GameBase::setPosition(%tent2,Vector::add(%position, "0 0 1"));
	GameBase::setPosition(%tent2,%posTn2);

	//GameBase::setRotation(%tent3,"0 -1.57 0");
	GameBase::setRotation(%tent3,%rotTn3);
	//GameBase::setPosition(%tent3,Vector::add(%position, "11.5 0 -7"));
	GameBase::setPosition(%tent3,%posTn3);

	//GameBase::setRotation(%tent4,"0 1.57 0");
	GameBase::setRotation(%tent4,%rotTn4);
	//GameBase::setPosition(%tent4,Vector::add(%position, "-3.75 0 -7"));
	GameBase::setPosition(%tent4,%posTn4);
	
	%posDP1 = GetOffSetRot("0 -5 3",%rot,%position);
	%posDP2 = GetOffSetRot("12 12 3",%rot,%position);
	%posDP3 = GetOffSetRot("-4 -5 3",%rot,%position);
	%posDP4 = GetOffSetRot("-5 12 3",%rot,%position);
	%posDP5 = GetOffSetRot("-6 -5 3",%rot,%position);
	%posDP6 = GetOffSetRot("13 12 3",%rot,%position);
	%posDP7 = GetOffSetRot("14 -5 3",%rot,%position);
	%posDP8 = GetOffSetRot("15 12 3",%rot,%position);	

	%DP1 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP2 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP3 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP4 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP5 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP6 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP7 = newObject("Drop Point", Marker,"DropPointMarker");
	%DP8 = newObject("Drop Point", Marker,"DropPointMarker");
	
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP1);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP2);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP3);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP4);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP5);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP6);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP7);
	addToSet("MissionGroup/Teams/team"@%team@"/DropPoints/Random",%DP8);

	gamebase::setteam(%gen, %team);
	gamebase::setteam(%station1, %team);
	gamebase::setteam(%station2, %team);
	gamebase::setteam(%cmdstation, %team);

	gamebase::setteam(%DP1, %team);
	gamebase::setteam(%DP2, %team);
	gamebase::setteam(%DP3, %team);
	gamebase::setteam(%DP4, %team);
	gamebase::setteam(%DP5, %team);
	gamebase::setteam(%DP6, %team);
	gamebase::setteam(%DP7, %team);
	gamebase::setteam(%DP8, %team);

	GameBase::setRotation(%DP1,%rot);
	//GameBase::setPosition(%DP1,Vector::add(%position, "0 -5 3"));
	GameBase::setPosition(%DP1,%posDP1);
	if(GameBase::getLOSInfo(%DP1,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP1,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP2,%rot);
	//GameBase::setPosition(%DP2,Vector::add(%position, "12 12 3"));
	GameBase::setPosition(%DP2,%posDP2);
	if(GameBase::getLOSInfo(%DP2,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP2,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP3,%rot);
	//GameBase::setPosition(%DP3,Vector::add(%position, "-4 -5 3"));
	GameBase::setPosition(%DP3,%posDP3);
	if(GameBase::getLOSInfo(%DP3,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP3,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP4,%rot);
	//GameBase::setPosition(%DP4,Vector::add(%position, "-5 12 3"));
	GameBase::setPosition(%DP4,%posDP4);
	if(GameBase::getLOSInfo(%DP4,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP4,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP5,%rot);
	//GameBase::setPosition(%DP5,Vector::add(%position, "-6 -5 3"));
	GameBase::setPosition(%DP5,%posDP5);
	if(GameBase::getLOSInfo(%DP5,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP5,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP6,%rot);
	//GameBase::setPosition(%DP6,Vector::add(%position, "13 12 3"));
	GameBase::setPosition(%DP6,%posDP6);
	if(GameBase::getLOSInfo(%DP6,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP6,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP7,%rot);
	//GameBase::setPosition(%DP7,Vector::add(%position, "14 -5 3"));
	GameBase::setPosition(%DP7,%posDP7);
	if(GameBase::getLOSInfo(%DP7,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP7,vector::add(%Newpos, "0 0 0.1"));
	}
	GameBase::setRotation(%DP8,%rot);
	//GameBase::setPosition(%DP8,Vector::add(%position, "15 12 3"));
	GameBase::setPosition(%DP8,%posDP8);
	if(GameBase::getLOSInfo(%DP8,100,"-1.570796327 0 0")){
		%Newpos = $los::position;
		GameBase::setPosition(%DP8,vector::add(%Newpos, "0 0 0.1"));
	}
	$CommandTents[%team]--;
	$CTLayed[%team] = true;			
	exec(game);
}
