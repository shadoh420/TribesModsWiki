exec("game.cs");


$flagReturnTime = 28;

function ObjectiveMission::missionComplete()
{
	$missionComplete = true;
	
	// Make Sure all this stuff is cleared on mission change.
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		// droid stuff
		%cl.droid = false;
		$DroidType[%cl] = "";
		
		// possession stuff
		%cl.isPossessed = false;
		%cl.Possby = "";
		%cl.noSuicide = 0;
		%cl.isPossessing = false;
		%cl.hasPossPlayer = "";
		%cl.hasPossClient = "";
		
		// freeze
		%cl.isfrozen = 0;
	}
	
	%group = nameToID("MissionCleanup/ObjectivesSet");
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{ ObjectiveMission::objectiveChanged(%obj); }
	
	for(%i = 0; %i < getNumTeams(); %i++)
	{ 
		Team::setObjective(%i, $firstObjectiveLine -4, " ");
		Team::setObjective(%i, $firstObjectiveLine -3, "<f5>Mission Summary:");
		Team::setObjective(%i, $firstObjectiveLine -2, " ");
	}
	ObjectiveMission::setObjectiveHeading();
	ObjectiveMission::refreshTeamScores();
	%lineNum = "";
	$missionComplete = false;
	
	// back out of all the functions...
	schedule("Server::nextMission();", 0);
}

function ObjectiveMission::setObjectiveHeading()
{
	if($missionComplete) 
	{
		%curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		
		for(%i = 0; %i < getNumTeams() ; %i++) 
		echo("GAME: teamfinalscore "@ getTeamName(%i) @" = "@ $teamScore[%i]);
		
		for(%i = 1; %i < getNumTeams() ; %i++) 
		{
			if($teamScore[%i] == $teamScore[%curLeader])
			{
				%tieGame = true;
				%tieTeams[%tie++] = %i;
			}
			else
			{
				if($teamScore[%i] > $teamScore[%curLeader])
				{
					%curLeader = %i;	   
					%tieGame = false;
					%tie = 0;
					%tieTeams[%tie] = %curLeader; 
				}
			}
		}
		
		if(%tieGame) 
		{
			for(%g = 0; %g <= %tie; %g++)
			{ 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
				{ %names = %names @ " and "; }
				else if(%g != %tie)
				{ %names = %names @ ", "; } 
			}
			if(%tie > 1)
			{ %names = %names @ " all"; }
		}
		
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			objective::displayBitmap(%i, 0);
			if(!%tieGame)
			{
				if(%i == %curLeader)
				{ 
					if($teamScore[%curLeader] == 1)
					{ Team::setObjective(%i, 1, "<F5>       Your team won the mission with "@ $teamScore[%curLeader] @" point!"); }
					else
					{ Team::setObjective(%i, 1, "<F5>       Your team won the mission with "@ $teamScore[%curLeader] @" points!"); }
				}
				else
				{
					if($teamScore[%curLeader] == 1)
					{ Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!"); }
					else
					{ Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!"); }
				}
			}	
			else
			{
				if(getNumTeams() > 2)
				{ Team::setObjective(%i, 1, "<F5>     The "@ %names @" tied with a score of "@ $teamScore[%curLeader]); }
				else
				{ Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of "@ $teamScore[%curLeader]); }
			}
			Team::setObjective(%i, 2, " ");
			echo("*** Printing Player Stats");
			%linenum = 11;
			%numClients = getNumClients();
			for(%k = 0 ; %k < %numClients; %k++) 
			%clientList[%k] = getClientByIndex(%k);
			%doIt = 1;
			while(%doIt == 1)
			{
				%doIt = "";								
				for(%k= 0 ; %k < %numClients; %k++)
				{
					if((%clientList[%k]).score < (%clientList[%k+1]).score)
					{
						%hold = %clientList[%k];
						%clientList[%k] = %clientList[%k+1];
						%clientList[%k+1] = %hold;
						%doIt = 1;
					}
				}
			}
			%c = 0;
			Team::setObjective(%i, %lineNum++, "<L36>Score\t\tKills\t\tDeaths\t\tRatio\t\t|");					 
			while(%c < %numClients)
			{
				(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);			
				Team::setObjective(%i, %lineNum++, "<L2><f2>"@(%c + 1) @ ". " @ Client::getName(%clientList[%c]) @ "<L36><f0>" @ (%clientList[%c]).score @ "\t\t\t\t" @ (%clientList[%c]).ScoreKills @ "\t\t\t" @ (%clientList[%c]).ScoreDeaths @ "\t\t\t\t" @ (%clientList[%c]).ratio @ "%\t\t\t");
				%lastRatio = (%clientList[%index]).score;
				%c++;
			}  
		}  
		echo("...done");
	}
	else
	{
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			objective::displayBitmap(%i, 0);
			Team::setObjective(%i, 1, "<f5>UltraVX5 GoD By:  .:B|B:.BLooDLuST");
			Team::setObjective(%i, 2,"<f5>Mission Completion:");
			Team::setObjective(%i, 3,"<f1>   - "@ $teamScoreLimit @" points needed to win the mission.");
		}
	}
	
	if(!$Server::timeLimit)
	{ %str = "<f1>   - No time limit on the game."; }
	else if($timeLimitReached)
	{ %str = "<f1>   - Time limit reached."; }
	else
	{
		if($missionComplete)
		{
			%time = getSimTime() - $missionStartTime;
			%minutes = Time::getMinutes(%time);
			%seconds = Time::getSeconds(%time);
			if(%minutes < 10)
			{ %minutes = "0"@ %minutes; }
			if(%seconds < 10)
			{ %seconds = "0"@ %seconds; }
			%str = "<f1>   - Total match time: "@ %minutes @":"@ %seconds;
		}
		else
		{ %str = "<f1>   - Time remaining: "@ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @" minutes."; }
		for(%i = -1; %i < getNumTeams(); %i++)
		{
			Team::setObjective(%i, 4, " ");
			Team::setObjective(%i, 5, "<f5>Mission Information:");
			Team::setObjective(%i, 6, "<f1>   - Mission Name: "@ $missionName); 
			Team::setObjective(%i, 7, %str);
		}
	}
}

function getEfficiencyRatio(%clientId){ %ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100); if (%ratio > 0){ return %ratio; }else{ return "0"; } }

function objective::displayBitmap(%team, %line)
{
	if($TestMissionType == "CTF") {
		%bitmap1 = "capturetheflag1.bmp";
		%bitmap2 = "capturetheflag2.bmp";
	}
	else if($TestMissionType == "C&H") {
		%bitmap1 = "captureandhold1.bmp";
		%bitmap2 = "captureandhold2.bmp";
	}
	else if($TestMissionType == "D&D") {
		%bitmap1 = "defendanddest1.bmp";
		%bitmap2 = "defendanddest2.bmp";
	}	   
	else if($TestMissionType == "F&R") {
		%bitmap1 = "findandret1.bmp";
		%bitmap2 = "findandret2.bmp";
	}
	if(%bitmap1 == "" || %bitmap2 == "")
 		Team::setObjective(%team, %line, " ");
	else
 		Team::setObjective(%team, %line, "<jc><B0,0:" @ %bitmap1 @ "><B0,0:" @ %bitmap2 @ ">");
}

function Game::checkTimeLimit()
{
	$timeLimitReached = false;
	ObjectiveMission::setObjectiveHeading();
	if(!$Server::timeLimit)
	{
		schedule("Game::checkTimeLimit();", 60);
		return;
	}
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	
	if(%curTimeLeft <= 120 && $TG::TwoMinWarn != false)
	{
		%newTime = %curTimeLeft;
		Echo("Should Be 120 Secs. --> "@ %newTime);
		%newTime = "";
		MessageAll(0, "2 MINUTES LEFT!~waccess_denied.wav");
		Schedule("MessageAll(0, \"2 Minute Warning!~waccess_denied.wav\");", 0.5);
		Schedule("MessageAll(0, \"2 Minute Warning!~waccess_denied.wav\");", 1.0);
		Schedule("MessageAll(0, \"2 Minute Warning!~waccess_denied.wav\");", 1.5);
	}
	else if(%curTimeLeft == 350 && %curTimeLeft != 340 && $TG::FiveMinWarn != false)
	{
		%newTime = %curTimeLeft;
		Echo("Should Be 350 Secs. --> "@ %newTime);
		%newTime = "";
		MessageAll(0, "5 Minute Warning!~wAccess_Denied.Wav");
		Schedule("MessageAll(0, \"5 Minute Warning!~waccess_denied.wav\");", 0.5);
		Schedule("MessageAll(0, \"5 Minute Warning!~waccess_denied.wav\");", 1.0);
		Schedule("MessageAll(0, \"5 Minute Warning!~waccess_denied.wav\");", 1.5);
	}
	else if(%curTimeLeft <= 0 && $matchStarted)
	{
		echo("GAME: Mission Complete");
		$timeLimitReached = true;
		%set = nameToID("MissionCleanup/ObjectiveSet");
		for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
		GameBase::virtual(%obj, "timeLimitReached", %clientId);
		ObjectiveMission::missionComplete();
	}
	else
	{
		if(%curTimeLeft >= 20)
		Schedule("Game::checkTimeLimit();", 20);
		
		else
		schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
		UpdateClientTimes(%curTimeLeft);
	}
}

function Vote::changeMission()
{
   $missionComplete = true;
   ObjectiveMission::refreshTeamScores();
   %group = nameToID("MissionCleanup/ObjectivesSet");
	%lineNum = "";
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	   Team::setObjective(%i, $firstObjectiveLine-1, "<f5>Mission Summary:");
	}
	ObjectiveMission::setObjectiveHeading();
   $missionComplete = false;
}

function ObjectiveMission::checkScoreLimit()
{
   %done = false;
   ObjectiveMission::refreshTeamScores();

   for(%i = 0; %i < getNumTeams(); %i++)
      if($teamScore[%i] >= $teamScoreLimit)
         %done = true;

   if(%done)
      ObjectiveMission::missionComplete();
}

function ObjectiveMission::checkPoints()
{
   for(%i = 0; %i < getNumTeams(); %i++)
      $teamScore[%i] += $deltaTeamScore[%i] / 12;
   schedule("ObjectiveMission::checkPoints();", 5);
   ObjectiveMission::checkScoreLimit();
}

function ObjectiveMission::initCheck(%object)
{
	if($TestMissionType == "") {
		%name = gamebase::getdataname(%object); 
	   if(%name == Flag) { 
			if(gamebase::getteam(%object) != -1)
				$TestMissionType = "CTF";
			else
				$TestMissionType = "F&R";
		}
		else if(%object.objectiveName != "" && %object.scoreValue)
			$TestMissionType = "D&D";
		else if(%name == TowerSwitch)
			$NumTowerSwitchs++;
	}

   %object.trainingObjectiveComplete = "";
   %object.objectiveLine = "";
   if(GameBase::virtual(%object, objectiveInit))
      addToSet("MissionCleanup/ObjectivesSet", %object);
}

function Game::refreshClientScore(%clientId)
{
   %team = Client::getTeam(%clientId);
   if(%team == -1) // observers go last.
      %team = 9;
   // objective mission sorts by team first.
   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score  @ "\t%p\t%l", %clientId.score + (9 - %team) * 10000);
//   Client::setScore(%clientId, "%n\t%t\t  " @ %clientId.score, %clientId.score);
}


function ObjectiveMission::refreshTeamScores()
{

	%nt = getNumTeams();
	Team::setScore(-1, "%t\t  0", 0);
	for(%i = 0; %i < %nt; %i++)
	{
		Team::setScore(%i, "%t\t  " @ $teamScore[%i], $teamScore[%i]);
		for(%j = 0; %j < %nt; %j++) 
		Team::setObjective(%i, %j + $firstTeamLine, "<f1>   - Team "@ getTeamName(%j) @" score = "@ $teamScore[%j]);
   }
}

function ObjectiveMission::objectiveChanged(%this)
{
	if(%this.objectiveLine)
      for(%i = -1; %i < getNumTeams(); %i++)
         Team::setObjective(%i,%this.objectiveLine, 
            "<f1> " @ GameBase::virtual(%this, getObjectiveString, %i));
}


function Mission::init()
{
   setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
//   setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");
   setTeamScoreHeading(":::|| VX5 GOD ||:::\t\xA6Count\t\xD6Score");

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++)
   {
      $teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
      Team::setObjective(%i, $firstTeamLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      $firstObjectiveLine++;
		$deltaTeamScore[%i] = 0;
      $teamScore[%i] = 0;
      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   $numObjectives = 0;
   newObject(ObjectivesSet, SimSet);
   addToSet(MissionCleanup, ObjectivesSet);
   
   Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
   %group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %i + $firstObjectiveLine;
      ObjectiveMission::objectiveChanged(%obj);
   }
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }
   schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
   AI::setupAI();
}

function Game::pickRandomSpawn(%team)
{
	%spawnSet = nameToID("MissionCleanup/TeamDrops"@ %team);
	%spawnCount = Group::objectCount(%spawnSet);
	if(!%spawnCount)
	return -1;
	
	%spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
	%value = %spawnCount;
	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%spawnSet, %i);
		if(containerBoxFillSet(%set, $SimPlayerObjectType | $VehicleObjectType, GameBase::getPosition(%obj), 2, 2, 4, 0) == 0)
		{
			deleteObject(%set);
			return %obj;		
		}
		
		if(%i == %spawnCount - 1)
		{
			%i = -1;
			%value = %spawnIdx;
		}
		
		deleteObject(%set);
		}
	return false;
}

//handles all scoring based on distance to Towers
function Client::leaveGame(%clientId){
	if($debug) echo("GAME: clientdrop "@ %clientId);
	%set = nameToID("MissionCleanup/ObjectivesSet");
	for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++) GameBase::virtual(%obj, "clientDropped", %clientId);
}

function Game::clientKilled(%playerId, %killerId)
{
	%set = nameToID("MissionCleanup/ObjectivesSet");
	for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++) GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}

function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
     Client::sendMessage(Player::getClient(%this),1,"You have re-entered the mission area.~wmine_act.wav");
    // Client::sendMessage(Player::getClient(%this),1,"You have entered the mission area.");
     // Client::sendMessage(Player::getClient(%player),0,"~wmine_act.wav");
}

function Player::leaveMissionArea(%this)
{
	%this.outArea=1;
	Client::sendMessage(Player::getClient(%this),1,"You have left the mission area.");
	alertPlayer(%this, 3);
}
   
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		if(%count > 0) {
		  	Client::sendMessage(Player::getClient(%player),0,"~wLeftMissionArea.wav");
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%player);
		}
		else { 
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  			GameBase::virtual(%obj, "playerLeaveMissionArea", %player);
		}
	}
}
function checkObjectives(%this)
{
   //echo("checking for objective player leave mission area...");
}

// objective init must return true
function TowerSwitch::objectiveInit(%this)
{
   return %this.scoreValue || %this.deltaTeamScore;
}

function TowerSwitch::onAdd(%this)
{
	%this.numSwitchTeams = 0;	
}

function TowerSwitch::onDamage()
{
   // tower switches can't take damage
}

function TowerSwitch::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   
   if($missionComplete)
   {
      if(%thisTeam == -1)
         return "<Btowers_neutral.bmp>\nNo team claimed " @ %this.objectiveName @ ".";
      else if(%thisTeam == %forTeam)
         return "<Btower_teamcontrol.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
      else {
       	if(%forTeam != -1)
		   	return "<Btower_enemycontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
   		else
		   	return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
		}
	}
   else
   {
		if(%forTeam != -1) {
     		if(%this.deltaTeamScore)
     		{																	  
				if(%thisTeam == -1)
 			   	return "<Btowers_neutral.bmp>\nClaim " @ %this.objectiveName @ " to gain " @ %this.deltaTeamScore @ " points per minute."; 
 			   else if(%thisTeam == %forTeam)
 			      return "<Btower_teamcontrol.bmp>\nDefend " @ %this.objectiveName @ " to retain " @ %this.deltaTeamScore @ " points per minute.";
 			   else
 			      return "<Btower_enemycontrol.bmp>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points per minute.";
			}
     		else if(%this.scoreValue)
     		{
     			if(%thisTeam == -1)
     		      return "<Btowers_neutral.bmp>\nClaim and defend " @ %this.objectiveName @ " to gain " @ %this.scoreValue @ " points.";
     		   else if(%thisTeam == %forTeam)
     		      return "<Btower_teamcontrol.bmp>\nDefend " @ %this.objectiveName @ " to retain " @ %this.scoreValue @ " points.";
     		   else
     		      return "<Btower_enemycontrol.bmp>\nCapture " @ %this.objectiveName @ " from the " @ getTeamName(%thisTeam) @ " team to gain " @ %this.deltaTeamScore @ " points.";
     		 }
		}
		else {
 			if(%thisTeam == -1)
 			  	return "<Btowers_neutral.bmp>\n" @ %this.objectiveName @ " has not been claimed."; 
 			else
 			   return "<Btower_teamcontrol.bmp>\nThe " @ getTeamName(%thisTeam) @ " team is in control of the " @ %this.objectiveName @ ".";
	  	}
   }
}

function TowerSwitch::onCollision(%this, %object)
{
   //echo("switch collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

   %playerTeam = GameBase::getTeam(%object);
   %oldTeam = GameBase::getTeam(%this);
   if(%oldTeam == %playerTeam)
      return;

   %this.trainingObjectiveComplete = true;
   
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
   %group = GetGroup(%this);
   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);

   %dropPoints = nameToID(%group @ "/DropPoints");
   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);

   $deltaTeamScore[%oldTeam] -= %this.deltaTeamScore;
   $deltaTeamScore[%playerTeam] += %this.deltaTeamScore;
   $teamScore[%oldTeam] -= %this.scoreValue;
   $teamScore[%playerTeam] += %this.scoreValue;

   if(%dropPoints != -1)
   {
      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      {
         if(%oldDropSet != -1)
            removeFromSet(%oldDropSet, %dropPoint);
         addToSet(%newDropSet, %dropPoint);
      }
   }

   if(%oldTeam == -1)
   {
      MessageAllExcept(%playerClient, 0, %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
      Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
 	}
   else
   {
      if(%this.objectiveLine)
      {
         MessageAllExcept(%playerClient, 0, %touchClientName @ " captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
         Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
			%this.numSwitchTeams++;	
			schedule("TowerSwitch::timeLimitCheckPoints(" @ %this @ "," @ %playerClient @ "," @ %this.numSwitchTeams @ ");",60);
      }
   }
   if(%this.objectiveLine)
   {
      TeamMessages(1, %playerTeam, "Your team has taken an objective.~wCapturedTower.wav");
		TeamMessages(0, %playerTeam, "The " @ getTeamName(%playerTeam) @ " has taken an objective.");
		if(%oldTeam != -1)
	      TeamMessages(1, %oldTeam, "The " @ getTeamName(%playerTeam) @ " team has taken your objective.~wLostTower.wav");
      ObjectiveMission::ObjectiveChanged(%this);
   }
   ObjectiveMission::checkScoreLimit();
}

function TowerSwitch::timeLimitCheckPoints(%this,%client,%numChange)
{
	//give player 5 points for capturing tower!
	if(%this.numSwitchTeams == %numChange) 
	{
		%client.score += 5;
		Game::refreshClientScore(%client);
		Client::sendMessage(%client, 0, "You receive 5 points for holding your captured tower!");
	}
}

function TowerSwitch::clientKilled(%this, %playerId, %killerId)
{      
	if(!%this.objectiveLine)
	{ return; }
	
	%killerTeam = Client::getTeam(%killerId);
	%playerTeam = Client::getTeam(%playerId);
	%killerPos = GameBase::getPosition(%killerId);
	
	if(%killerId && (%playerTeam != %killerTeam))
	{   
		%dist = Vector::getDistance(%killerPos, GameBase::getPosition(%this));
		//echo(%dist);
		if(%dist <= 80)
		{
			//echo("distance to objective" @ %this @ " : " @ %dist);
			if(GameBase::getTeam(%this) == Client::getTeam(%killerId) && getObjectType(%killerId) == "Player")
			{
				%killerId.score++;
				Game::refreshClientScore(%killerId);
				messageAll(0, strcat(Client::getName(%killerId), " receives a bonus for defending " @ %this.objectiveName @ "."));
			}
		}
	}
}

// objective init must return true
function Flag::objectiveInit(%this)
{
	%this.originalPosition = GameBase::getPosition(%this);
	%this.atHome = true;
	%this.pickupSequence = 0;
	%this.carrier = -1;
	%this.holdingTeam = -1;
	%this.holder = "";
	%this.changeTeamCount = 0;
	
	%this.enemyCaps = 0;
	%this.caps[0] = 0;
	%this.caps[1] = 0;
	%this.caps[2] = 0;
	%this.caps[3] = 0;
	%this.caps[4] = 0;
	%this.caps[5] = 0;
	%this.caps[6] = 0;
	%this.caps[7] = 0;
	
	$teamFlag[GameBase::getTeam(%this)] = %this;
	return true;
}

function Flag::getObjectiveString(%this, %forTeam)
{
	%thisTeam = GameBase::getTeam(%this);
	//echo("Flag objectiveString");
	if($missionComplete)
	{
		if(%thisTeam == -1)
		{
			if(%this.holdingTeam == %forTeam && %forTeam != -1)
			{ return "<Bflag_atbase.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ "."; }
			else if(%this.holdingTeam == -1)
			{ return "<Bflag_neutral.bmp>\nNo team finished the mission in control of " @ %this.objectiveName @ "."; }
			else
			{
				if(%forTeam != -1)
				{ return "<Bflag_enemycaptured.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ "."; }
				else
				{ return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ "."; }
			}
		}
		else if(%forTeam != -1)
		{
			if(%thisTeam == %forTeam)
			{ return "<Bflag_atbase.bmp>\nYour flag was captured " @ %this.enemyCaps @ " times."; }
			else
			{ return "<Bflag_enemycaptured.bmp>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times."; }
		}
		else 
		{ return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ "'s flag was captured " @ %this.enemyCaps @ " times."; }
	}
	else
	{
		if(%thisTeam == -1)
		{
			if(%forTeam != -1)
			{
				if(%this.holdingTeam == %forTeam)
				{ return "<Bflag_atbase.bmp>\nDefend " @ %this.objectiveName @ "."; }
				else if(%this.holdingTeam != -1)
				{ return "<Bflag_enemycaptured.bmp>\nGrab "@ %this.objectiveName @" from the "@ getTeamName(%this.holdingTeam) @" team."; }
				else if(%this.carrier != -1)
				{
					if(GameBase::getTeam(%this.carrier) == %forTeam)
					{ return "<Bflag_atbase.bmp>\nConvey "@ %this.objectiveName @" to an empty flag stand. (carried by "@ Client::getName(Player::getClient(%this.carrier)) @")"; }
					else
					{ return "<Bflag_enemycaptured.bmp>\nWaylay " @ Client::getName(Player::getClient(%this.carrier)) @ " and convey " @ %this.objectiveName @ " to your base."; }
				}
				else if(%this.atHome)
				{ return "<Bflag_neutral.bmp>\nGrab " @ %this.objectiveName @ " and convey it to an empty flag stand."; }
				else
				{ return "<Bflag_notatbase.bmp>\nFind " @ %this.objectiveName @ " and convey it to an empty flag stand."; }
			}
			else
			{
				if(%this.holdingTeam != -1)
				{ return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team has " @ %this.objectiveName @ "."; }
				else if(%this.carrier != -1)
				return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has " @ %this.objectiveName @ ".";
				else if(%this.atHome)
				return "<Bflag_neutral.bmp>\n" @ %this.objectiveName @ " has not been found.";
				else
				return "<Bflag_notatbase.bmp>\n" @ %this.objectiveName @ " has been dropped in the field.";
			}
		}
		else
		{
			if(%thisTeam == %forTeam)
			{
				if(%this.atHome)
				return "<Bflag_atbase.bmp>\nDefend your flag to prevent enemy captures.";
				else if(%this.carrier != -1)
				return "<Bflag_enemycaptured.bmp>\nReturn your flag to base. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
				else
				return "<Bflag_notatbase.bmp>\nReturn your flag to base. (dropped in the field)";
			}
			else
			{
				if(%forTeam != -1)
				{
					if(%this.atHome)
					{ return "<Bflag_enemycaptured.bmp>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points."; }
					else if(%this.carrier == -1)
					{ return "<Bflag_notatbase.bmp>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points."; }
					else if(GameBase::getTeam(%this.carrier) == %forTeam)
					{ return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " to base."; }
					else
					{ return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " and steal his flag."; }
				}
				else
				{
					if(%this.atHome)
					{ return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base."; }
					else if(%this.carrier == -1)
					{ return "<Bflag_notatbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field."; }
					else
					{ return "<Bflag_atbase.bmp>\n"@ Client::getName(Player::getClient(%this.carrier)) @" has the "@ getTeamName(%thisTeam) @" flag."; }
				}
			}
		}
	}
}

function Flag::onDrop(%player, %type)
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	
	if(%flagTeam == -1)
	{
		MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "~wmine_act.wav!");
		Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "~wmine_act.wav!");
	}
	else
	{
		MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!~wmine_act.wav");
		Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!~wmine_act.wav");
		TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
	}
	GameBase::throw(%flag, %player, 10, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);
	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

function Flag::checkReturn(%flag, %sequenceNum)
{
	//echo("checking for flag return: ", %flag, ", ", %sequenceNum);
	if(%flag.pickupSequence == %sequenceNum && %flag.timerOn == "")
	{
		if(%flag.dropFade)
		{ 
			GameBase::startFadeOut(%flag);
			%flag.dropFade = "";
			%flag.fadeOut = 1;
			schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
		}
		else
		{
			%flagTeam = GameBase::getTeam(%flag);
			if(%flagTeam == -1)
			{
				if(%flag.flagStand == "" || %flag.flagStand.flag != "")
				{
					MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");
					%flag.flagStand = "";
				}
				else
				{
					%holdTeam = GameBase::getTeam(%flag.flagStand);
					TeamMessages(0, %holdTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(GameBase::getTeam(%flag.flagStand)) @ " flag was returned to base.~wflagreturn.wav");
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
					%flag.flagStand.flag = %flag;
					%flag.holdingTeam = %holdTeam;
					%flag.carrier = -1;
					$teamScore[%holdTeam] += %flag.scoreValue;
					$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
					%flag.holder = %flag.flagStand;
					TeamMessages(0,%holdTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
					ObjectiveMission::checkScoreLimit();
				}
			}
			else
			{
				TeamMessages(0, %flagTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was returned to base.~wflagreturn.wav");
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%flag, "0 0 0");
			}
			%flag.atHome = true;
			GameBase::startFadeIn(%flag);
			%flag.fadeOut = "";
			ObjectiveMission::ObjectiveChanged(%flag);
		}
	}
}

function Flag::onCollision(%this, %object)
{
   //echo("Flag collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(%this.carrier != -1)
      return; // spurious collision
      
   if(Player::isAIControlled(%object))
   	return;   
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
							 

   if(%flagTeam == %playerTeam)
   {
      // player is touching his own flag...
      if(!%this.atHome)
      {
         // the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
         %this.atHome = true;
         MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
         %this.pickupSequence++;
         ObjectiveMission::ObjectiveChanged(%this);
      }
      else
      {
         // it's at home - see if we have an enemy flag!
         if(%object.carryFlag != "")
         {
            // can't cap the neutral flags, duh
           	%enemyTeam = GameBase::getTeam(%object.carryFlag);
			   if(%enemyTeam != -1)
            {
               MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               TeamMessages(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");
            
               %flag = %object.carryFlag;
               %flag.atHome = true;
               %flag.carrier = -1;
               %flag.caps[%playerTeam]++;
               %flag.enemyCaps++;
               
               
               Item::hide(%flag, false);
               $flagAtHome[1] = true;
               GameBase::setPosition(%flag, %flag.originalPosition);
               Item::setVelocity(%flag, "0 0 0");

               %flag.trainingObjectiveComplete = true;
               ObjectiveMission::ObjectiveChanged(%flag);

               Player::setItemCount(%object, Flag, 0);
               %object.carryFlag = "";
               Flag::clearWaypoint(%playerClient, true);

               $teamScore[%playerTeam] += %flag.scoreValue;
               ObjectiveMission::checkScoreLimit();

               //flag carrier gets 5 points for caputure
               %playerClient.score += 5;
               Game::refreshClientScore(%playerClient);
               messageAll(0, Client::getName(%playerClient) @ " receives 5 point capture bonus.");
            }
         }
      }
   }
   else
   {
      // it's an enemy's flag! woohoo!
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "") {
				// don't pick up our flags
        		if(%this.holdingTeam == %playerTeam)
        		   return;

        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
	 			if(%this.fadeOut) {
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
				}
        		
        		if((%this.lastTeam == "" || %this.lastTeam != %playerTeam) && %flagTeam == -1) {
			 		%this.currentFlagStand="";
			 		%this.changeTeamCount++;
					%this.lastTeam = %playerTeam;
     		      %this.timerOn = 1;
     		      if($flagToStandTime >= 30) {
	     		      %timeToStand = $flagToStandTime - 30;
						%timeLeft = 30;
	     		      if($flagToStandTime > 30)
	     		      	Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
					}
					else {	
						if($flagToStandTime >= 10)
							%remain = $flagToStandTime % 10;
						else 
							%remain = $flagToStandTime % 5;
						
						if(%remain > 0 && %remain != $flagToStandTime) {
							%timeToStand = %remain;
							%timeLeft = $flagToStandTime - %remain;
		     		      Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
						}
						else {
							%timeToStand = 0;
							%timeLeft = $flagToStandTime;
						}
					}

     		      schedule("Flag::checkFlagsTime(" @ %this @"," @ %timeLeft @ "," @ %this.changeTeamCount @ ");",%timeToStand);
				}
        		
        		if(%flagTeam != -1)
        		{
	     		   MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
        		}
        		else
        		{
        		   %hteam = %this.holdingTeam;
	     		   if(%hteam != -1)
        		   {
        		      $teamScore[%hteam] -= %this.scoreValue;
        		      $deltaTeamScore[%hteam] -= %this.deltaTeamScore;

	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
        		      %this.holdingTeam = -1;
        		      %this.holder.flag = "";
        		   }
        		   else
        		   {
	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ ".~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ ".~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
        		   }
        		}
        		%this.trainingObjectiveComplete = true;
        		ObjectiveMission::ObjectiveChanged(%this);
			}
			else
  		      Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
		}
   }
}


function Flag::checkFlagsTime(%flag,%timeleft,%changeCount)
{
	if(%flag.changeTeamCount == %changeCount)
	{
		%client = Player::getClient(%flag.carrier);
		if(%timeleft <= 0 && %flag.currentFlagStand == "")
		{ 
			GameBase::startFadeOut(%flag);
			Player::setItemCount(%flag.carrier, "Flag", 0);
			%clientName = Client::getName(%client);
			%flagTeam = GameBase::getTeam(%flag);
			if(%flagTeam == -1 && (%flag.flagStand == "" || (%flag.flagStand).flag != "")) 
			{
				if(%client != -1)
				{
					MessageAllExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!  It was returned to its initial position.");
					Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!  It was returned to its initial position.");
				}
				else
				{ MessageAll(0, %flag.objectiveName @ " was not put in a flag stand in time!  It was returned to its initial position."); }
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%flag, "0 0 0");
				%flag.flagStand = "";
			}
			else
			{
				if(%flagTeam != -1)
				{
					%team = %flagTeam;
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%flag, "0 0 0");
				}
				else
				{
					%team = GameBase::getTeam(%flag.flagStand);
					GameBase::setPosition(%flag, GameBase::getPosition(%flag.flagStand));
					Item::setVelocity(%flag, "0 0 0");
				}
				if(%client != -1)
				{
					MessageAllExcept(%client, 0, %clientName @ " didn't put " @ %flag.objectiveName @ " in a flag stand in time!");
					Client::sendMessage(%client, 0, "You didn't get " @ %flag.objectiveName @ " to a flag stand in time!");
				}
				else
				{ MessageAll(0, %flag.objectiveName @ " was not put in a flag stand in time!"); }
				TeamMessages(1, %team, %flag.objectiveName @ " was returned to your base.~wflagreturn.wav", -2, "", %flag.objectiveName @ " was returned to the " @ getTeamName(%team) @ " base.");
				%holdTeam = GameBase::getTeam(%flag.flagStand);
				$teamScore[%holdTeam] += %flag.scoreValue;
				$deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
				%flag.holder = %flag.flagStand;
				%flag.flagStand.flag = %flag;
				%flag.holdingTeam = %holdTeam;
			}
			GameBase::startFadeIn(%flag);
			Item::hide(%flag, false);
			
			(%flag.carrier).carryFlag = "";
			%flag.carrier = -1;
			Flag::clearWaypoint(%client, false);
			ObjectiveMission::ObjectiveChanged(%flag);
			ObjectiveMission::checkScoreLimit();
			%flag.lastTeam = "";
		}
		else if(%flag.currentFlagStand == "")
		{
			Client::sendMessage(%client, 0, "You have " @ %timeleft @ " sec to put the flag in a stand.");
			if(%timeleft <= 5)
			{
				%timeleft--;
				%nextTime = 1;
			}
			else if(%timeleft == 10)
			{ 
				%timeleft -= 5;
				%nextTime = 5;
			}
			else
			{
				%timeleft -= 10;
				%nextTime = 10;
			}
			schedule("Flag::checkFlagsTime(" @ %flag @","@ %timeleft @"," @ %changeCount @ ");",%nextTime);
		}
	}
}

function Flag::clearWaypoint(%client, %success)
{
	if(%success)
	{ setCommandStatus(%client, 0, "Objective completed.~wobjcomp"); }
	else
	{ setCommandStatus(%client, 0, "Objective failed."); }
}

function Flag::setWaypoint(%client, %flag)
{
	if(!%client.autoWaypoint)
	return;
	%flagTeam = GameBase::getTeam(%flag);
	%team = Client::getTeam(%client);
	
	if(%flagTeam == -1)
	{ 
		for(%s = $teamFlagStand[%team]; %s != ""; %s = %s.nextFlagStand) 
		{
			if(%s.flag == "")
			{
				%pos = GameBase::getPosition(%s);
				%posX = getWord(%pos,0);
				%posY = getWord(%pos,1);
				issueCommand(%client, %client, 0,"Take " @ %flag.objectiveName @ " to empty flag stand.~wcapobj", %posX, %posY);
				return;
			}
		}
	}
	else
	{
		%pos = ($teamFlag[%team]).originalPosition;
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		issueCommand(%client, %client, 0, "Take the "@ getTeamName(%flagTeam) @" flag to ours.~wcapobj", %posX, %posY);
		return;
	}
}

function FlagStand::objectiveInit(%this)
{
   %this.flag = "";
   %team = GameBase::getTeam(%this);

   %this.nextFlagStand = $teamFlagStand[%team];
   $teamFlagStand[%team] = %this;
	
   return false;
}

function FlagStand::onCollision(%this, %object)
{
	//echo("FlagStand collision ", %object);
	%standTeam = GameBase::getTeam(%this);
	%playerTeam = GameBase::getTeam(%object);
	
	if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == "" || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
	{ return; }
	
	// if we're here, we're carrying a flag, we've hit 
	// our flag stand, it doesn't have a flag, and we're not carrying
	// a team coded flag.
	
	%flag = %object.carryFlag;
	%flag.carrier = -1;
	Item::hide(%flag, false);
	GameBase::setPosition(%flag, GameBase::getPosition(%this));
	%flag.flagStand = %this;
	Player::setItemCount(%object, Flag, 0);
	%object.carryFlag = "";
	%playerClient = Player::getClient(%object);
	Flag::clearWaypoint(%playerClient, true);
	
	$teamScore[%playerTeam] += %flag.scoreValue;
	$deltaTeamScore[%playerTeam] += %flag.deltaTeamScore;
	%flag.holder = %this;
	%flag.holdingTeam = %playerTeam;
	%this.flag = %flag;
	%flag.currentFlagStand = %this;
	
	MessageAllExcept(%playerClient, 0, Client::getName(%playerClient) @ " conveyed " @ %flag.objectiveName @ " to base.");
	Client::sendMessage(%playerClient, 0, "You conveyed " @ %flag.objectiveName @ " to base.");
	TeamMessages(1, %playerTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
	
	%flag.trainingObjectiveComplete = true;
	ObjectiveMission::ObjectiveChanged(%flag);
	ObjectiveMission::checkScoreLimit();
}

function Flag::clientKilled(%this, %playerId, %killerId)
{
	%player = Client::getOwnedObject(%playerId);
	%killer = Client::getOwnedObject(%killerId);
	
	if(%player == -1 || %killer == -1)
	{ return; }
	
	%flagTeam = GameBase::getTeam(%this);
	
	if(%flagTeam == -1)
	{ return; }
	
	%playerTeam = GameBase::getTeam(%player);
	%killerTeam = GameBase::getTeam(%killer);
	
	if(%playerTeam == %killerTeam)
	{ return; }
	
	// killer's the only guy who gets a bonus.
	if(%killerTeam == %flagTeam)
	{
		// check for defending the flag
		// only if the flag is not being carried
		if(%this.carrier == -1)
		{
			%flagPos = GameBase::getPosition(%this);
			%playerPos = GameBase::getPosition(%player);
			
			if(Vector::getDistance(%flagPos, %playerPos) < 80)
			{
				%killerId.score++;
				Game::refreshClientScore(%killerId);
				messageAll(0, Client::getName(%killerId) @" gets a bonus for defending the flag!");
			}
		}
	}
	else
	{
		if(%this.carrier != -1)
		{
			%carrierTeam = GameBase::getTeam(%this.carrier);
			// check for defending the carrier bonus
			if(%carrierTeam == %killerTeam)
			{
				if(Vector::getDistance(GameBase::getPosition(%this.carrier), GameBase::getPosition(%killer)) < 80)
				{
					%killerId.score++;
					Game::refreshClientScore(%killerId);
					messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
				}               
			}
		}
	}
}

function Flag::clientDropped(%this, %clientId)
{
	%type = Player::getMountedItem(%clientId, $FlagSlot);
	if(%type != -1)
	{ Player::dropItem(%clientId, %type); }
}

function Flag::playerLeaveMissionArea(%this, %playerId)
{
	// if a guy leaves the area, warp the flag back to its base
	if(%this.carrier == %playerId)
	{
		GameBase::startFadeOut(%this);
		Player::setItemCount(%playerId, "Flag", 0);
		%playerClient = Player::getClient(%playerId);
		%clientName = Client::getName(%playerClient);
		%flagTeam = GameBase::getTeam(%this);
		
		if(%flagTeam == -1 && (%this.flagStand == "" || (%this.flagStand).flag != "")) 
		{
			MessageAllExcept(%playerClient, 0, %clientName @" left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			%this.flagStand = "";
			// - BWAdmin Mod - Bug Fix
			%this.atHome = true;
		}
		else
		{
			if(%flagTeam != -1)
			{
				%team = %flagTeam;
				GameBase::setPosition(%this, %this.originalPosition);
				Item::setVelocity(%this, "0 0 0");
				// - BWAdmin Mod - Bug Fix
				%this.atHome = true;
			}
			else
			{
				%team = GameBase::getTeam(%this.flagStand);
				GameBase::setPosition(%this, GameBase::getPosition(%this.flagStand));
				Item::setVelocity(%this, "0 0 0");
				// - BWAdmin Mod - Bug Fix
				%this.currentFlagStand = %this.flagStand;
			}
			
			MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
			Client::sendMessage(%playerClient, 0, "You left the mission area while carrying the " @ getTeamName(%team) @ " flag!");
			TeamMessages(1, %team, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%team) @ " flag was returned to base.");
			%holdTeam = GameBase::getTeam(%this.flagStand);
			$teamScore[%holdTeam] += %this.scoreValue;
			$deltaTeamScore[%holdTeam] += %this.deltaTeamScore;
			%this.holder = %this.flagStand;
			%this.flagStand.flag = %this;
			%this.holdingTeam = %holdTeam;
		}
		GameBase::startFadeIn(%this);
		%this.carrier = -1;
		Item::hide(%this, false);
		
		%playerId.carryFlag = "";
		Flag::clearWaypoint(%playerClient, false);
		ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
	}
}

function Sensor::objectiveInit(%this)
{ return StaticShape::objectiveInit(%this); }
function Turret::objectiveInit(%this)
{ return StaticShape::objectiveInit(%this); }
function StaticShape::objectiveInit(%this)
{ %this.destroyerTeam = ""; return %this.scoreValue != ""; }
function Sensor::getObjectiveString(%this, %forTeam)
{ return StaticShape::getObjectiveString(%this, %forTeam); }
function Turret::getObjectiveString(%this, %forTeam)
{ return StaticShape::getObjectiveString(%this, %forTeam); }

function StaticShape::getObjectiveString(%this, %forTeam)
{
	%thisTeam = GameBase::getTeam(%this);
	if(%this.destroyerTeam != "")
	{
		if(%forTeam == %this.destroyerTeam && %thisTeam != %forTeam)
		{ return "<Bitem_ok.bmp>\nYour team successfully destroyed the "@ getTeamName(%thisTeam) @" "@ %this.objectiveName @" objective."; }
		
		else if(%forTeam == %thisTeam)
		{ return "<Bitem_damaged.bmp>\nYour team failed to defend " @ %this.objectiveName; }
		else
		{ return "<Bitem_ok.bmp>\n" @ getTeamName(%this.destroyerTeam) @ " team destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective."; }
	}
	else
	{
		if($missionComplete)
		{
			if(%forTeam != -1)
			{
				if(%forTeam == %thisTeam)
				{ return "<Bitem_ok.bmp>\nYour team successfully defended " @ %this.objectiveName @ "."; }
				else
				{ return "<Bitem_damaged.bmp>\nYour team failed to destroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ "."; }
			}
			else 
			{ return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " failed to destroy the " @ %this.objectiveName @ " objective."; }
		}
		else
		{
			if(%forTeam != -1)
			{
				if(%forTeam == %thisTeam)
				{ return "<Bitem_ok.bmp>\nDefend " @ %this.objectiveName @ "."; }
				else
				{ return "<Bitem_damaged.bmp>\nDestroy "@ getTeamName(%thisTeam) @" objective, "@ %this.objectiveName @"("@ %this.scoreValue @" points)."; }
			}
			else
			{ return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " must defend the " @ %this.objectiveName @ " objective."; }
		}
	}
}

function StaticShape::timeLimitReached(%this)
{
   if(%this.scoreValue && !%this.destroyerTeam)
   { $teamScore[GameBase::getTeam(%this)] += %this.scoreValue; }
}

function StaticShape::objectiveDestroyed(%this)
{
	if(%this.destroyed == "")
	{
		// test if it's really an objective
		if(!%this.objectiveLine)
		{ return; }
		
		%destroyerTeam = %this.lastDamageTeam;
		%thisTeam = GameBase::getTeam(%this);
		%playerClient = GameBase::getControlClient(%this.lastDamageObject);
		
		if(%playerClient != -1)
		%clientName = Client::getName(%playerClient);
		
		if(%thisTeam == %destroyerTeam)
		{
			// uh-oh... we killed our own stuff.
			// award the points to everyone else
			for(%i = 0; %i < getNumTeams(); %i++)
			{
				if(%i == %thisTeam)
				continue;
				$teamScore[%i] += %this.scoreValue;
			}
			if(%playerClient != -1)
			{
				MessageAllExcept(%playerClient, 0, %clientName @ " destroyed a friendly objective.");
				Client::sendMessage(%playerClient, 0, "You destroyed a friendly objective!");
			}
			MessageAll(1, getTeamName(%destroyerTeam) @" objective "@ %this.objectiveName @ " destroyed.");
		}
		else
		{
			$teamScore[%destroyerTeam] += %this.scoreValue;
			if(%playerClient != -1)
			{
				%playerClient.score+=5;
				Game::refreshClientScore(%playerClient);
				MessageAllExcept(%playerClient, 0, %clientName @ " destroyed an objective!");
				Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
			}
			MessageAll(1, getTeamName(%thisTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
		}
		%this.destroyerTeam = %destroyerTeam;
		ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
		%this.destroyed = 1;
	}
}

function StaticShape::objectiveDisabled(%this){}

// FAT BASTARD MISSION JUNK -Dustin B.

function FatBastardFlag::onCollision(%this, %object)
{
   //echo("Flag collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(%this.carrier != -1)
      return; // spurious collision
      
   if(Player::isAIControlled(%object))
   	return;   
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
							 

   if(%flagTeam == %playerTeam)
   {
      // player is touching his own flag...
      if(!%this.atHome)
      {
         // the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
            Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
         %this.atHome = true;
         MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
         %this.pickupSequence++;
         ObjectiveMission::ObjectiveChanged(%this);
      }
      else
      {
         if(%object.carryFlag != "")
         {
           	%enemyTeam = GameBase::getTeam(%object.carryFlag);
           	if(%enemyTeam != -1)
            {
	            Client::sendMessage(%playerClient, 3, "Feed The Fat Bastard");
            }
         }
      }
   }
   else
   {
      // it's an enemy's flag! woohoo!
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "") {
				// don't pick up our flags
        		if(%this.holdingTeam == %playerTeam)
        		   return;

        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
	 			if(%this.fadeOut) {
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
				}
        		
        		if((%this.lastTeam == "" || %this.lastTeam != %playerTeam) && %flagTeam == -1) {
			 		%this.currentFlagStand="";
			 		%this.changeTeamCount++;
					%this.lastTeam = %playerTeam;
     		      %this.timerOn = 1;
     		      if($flagToStandTime >= 30) {
	     		      %timeToStand = $flagToStandTime - 30;
						%timeLeft = 30;
	     		      if($flagToStandTime > 30)
	     		      	Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
					}
					else {	
						if($flagToStandTime >= 10)
							%remain = $flagToStandTime % 10;
						else 
							%remain = $flagToStandTime % 5;
						
						if(%remain > 0 && %remain != $flagToStandTime) {
							%timeToStand = %remain;
							%timeLeft = $flagToStandTime - %remain;
		     		      Client::sendMessage(%playerClient, 0, "You have " @ $flagToStandTime @ " sec to put the flag in a stand.");
						}
						else {
							%timeToStand = 0;
							%timeLeft = $flagToStandTime;
						}
					}

     		      schedule("Flag::checkFlagsTime(" @ %this @"," @ %timeLeft @ "," @ %this.changeTeamCount @ ");",%timeToStand);
				}
        		
        		if(%flagTeam != -1)
        		{
	     		   MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
        		}
        		else
        		{
        		   %hteam = %this.holdingTeam;
	     		   if(%hteam != -1)
        		   {
        		      $teamScore[%hteam] -= %this.scoreValue;
        		      $deltaTeamScore[%hteam] -= %this.deltaTeamScore;

	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
        		      %this.holdingTeam = -1;
        		      %this.holder.flag = "";
        		   }
        		   else
        		   {
	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " took " @ %this.objectiveName @ ".~wflag1.wav");
        		      Client::sendMessage(%playerClient, 0, "You took " @ %this.objectiveName @ ".~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
        		   }
        		}
        		%this.trainingObjectiveComplete = true;
        		ObjectiveMission::ObjectiveChanged(%this);
			}
			else
  		      Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
		}
   }
}$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$KX99999999999999999999999999999999999999999999998zuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu'xxxxxxxxxxxxxxxxxxxxxxxxxxxxx$k:uu%%Auu:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx|4$F%uuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAk:uu%%D$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$AAAAAAAAAAAAA'kkkkkkkkkkkkkFuuuuuuuuuuuuuu::::::::::::::%uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu|Ej\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\








































































::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::~K****************************************************************************************VOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxD$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$A'''''''''''''''''''''''''''''''''''kueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeee%%%%%%%%%%%%%%%%%%%%:eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeuFeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeD-FFFFFFFFFFFFFFFFFFFFFFFFFFF$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$A44444444444444444444444444444444444444444444444444444%%%%%%%%%%%%%eeeeeeeeeeeeeeeeeeeeeeeeuullllllllllllleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:::::::::::::eelkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk:::::::::::::::::::uuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeel%eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuu\EVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVB;|Dbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb'O$$$$$$$$$$$$$$$$$$$$$$$$$$$$$-FkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkA:::::::::::::::::::::::::::::leeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%%%%%%%%%%%%%%%%%%%%eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeel:%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%xxxxxxxxxxxxxxxxxxxxxxxxxxxxuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeelllllllllllllueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee-DbCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC$$$$$$$$$$$$$$$$$$$$$$$$$$$$$I%Fkeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::lueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeellllllllllllllllll  uuuuuuuuuuuuuuuuuuu%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%hhhhhhhhhhheeeeeeeeeeeeeeeeellllllllllllllllllllllllllllllllllllllllllllllllllllllll: eeeeeeeeeeeeeeeeelAAAAAAAAAAAAAAureeeeeeeeeeeeeeeeeeeeeeeeeeee              eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee‡£¢°†üûùúõöôòóñïîìíëêèéçåãäâàáÜÖÑÉÇÅÄπÛ…·Ù˛∏’‹¿≠±∆™ˆœÆµº˙«¬©¡»‘˘®Ÿ¨`≈^/P¸À˝Z´√ª∂∫Ω€∑Q˚—ˇÊÏ §Ú‰Ò˜ﬁßÂ◊÷›?ÁÌŒÓ¥ﬂ“ÃËÎÈ⁄≤¯„≥ÿÔÕ”∞ƒø•#¶æ‚U–555555555555555555555555555555555555555555555555555ÍØıS[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[HNNNNNNNNNNNNNNNNNNNNNNNNNN8JqXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj*
~\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\4KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKEB;-||||||||||||||||||||||||||||||||||||bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb'''''''''''''''''''''''''DuuuuuuuuuuuuuuuuuuuFCCCCCCCCCCCCCCCCCCCC$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$OI%%%%%%%%%%%%%Akhhhhhhhhhhhhhhllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeerrrrrrrrrrrrrrrrrr                           uuuuuuuuuuueeeeeeeeeeeeeeeeer::::::::::::::::::::::::::::l eeeeeeeeeeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrflllllllllllllluuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeee  :%eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeurhllllllllllllllnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                   A/S-+bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbFC$$$$$$$$$$$$$$$$$$$$$$$$$$$$$xIDuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuhhhhhhhhhhhhhhhhhf::::::::::::::rrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeeeeeelllllllllllllllllllllllllllln eeeeeeeeeeeeeeeeeeeeeeeeeeeeeunnnnnnnnnnnnnnr%eeeeeeeeeeeeeeeeeeeeeeeeeeee  leeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeerhkkkkkkkkkkkkkkkkkkkkffffffffffffffffffflnnnnnnnnnnnnnnuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeee%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%  lrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrreeeeeeeeeeeeeeeee:nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeV5PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP&[fBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\9999999999999999999999999ENA;|SSSSSSSSSSSSSSSSSSSSSSSSSS+//////////////////////////////////////////////////////////////////////--------------IbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbkC$$$$$$$$$$$$$$$$$$$$$$$$$$$$$hx'FFFFFFFFFFF%%%%%%%%%%%%%%%%%%%%lurrrrrrrrrrrrr:::::::::::::::::::eeeeeeeeeeeeeeeeeeeeeeeeeee            neeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuunlrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeee eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%ufhn:Drrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeelllllllllllll                                     eeeeeeeeeeeeeeeeer            nnnnnnnnnnnnnuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee leeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepSA+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++I//////////////////////////////-kbbbbbbbbbbbbbfOOOOOOOOOOOOOOOOOOOOOOOOOOO:C$%hhhhhhhhhhrrrrrrrrrrrrlnuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD  rllllllllllllluuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnn                             eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeu:f%%%%%%%%%%%%%%%%%"pppppppppprllllllllllllllllllllllllllllllllllllllllllllllllllllllllhe                                               neeeeeeeeeeeeeeeee                                    urnlllllllllllllllllllllllllllll          eeeeeeeeeeeeeeeee           eFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF<]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]___________________________________________________________________________HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH6****************************************************~j4







































V5P+01T&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[kEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEzKN;SAx|||||||||||||||||||IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII/%C-bOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOODDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD:ffffffffffffffffuuuuuuuuuuuuuuuuu"nnnnnnnnnnnnnnnnnnnnnnnnnnr           eeeeeeeeeeeeeeeeeeeeF$plllllllllllllllllllllllllllllllllllllllllllllllllll                      eeeeeeeeeennnnnnnnnnnnnuhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhrrrrrrrrrrrrrrrrrrrr                 eeeeeeeeeeeeeeeeeeeeee                                lllllllllllllllllllll%fffffffffffffffffffffffffffffffffff::::::::::::::::::::::::::::::::::::::::::::nnnnnnnnnnnnnuh"""""""""""""""""""""""""eeeeeeeeeeeeeeeeee                                              eeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr  nulllllllllllllllllllllllllleeeeeeeeerpppppppppppppppppppppppppppppppppppppppppppppppppppppppeeeeeeeeeeee                                                               A0kCTg)S1+IIIIIIIIIIIIIIIIIIIImmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmD/-bF'hfffffffffffffffffff%u::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::nrleeeeeeeeeeeeeeeeeeeeeeee                                                     e                       ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppruuuuuuuuuuuune                                      "llllllllllllllllleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                                        mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmphffffffffffffffffffffr%:::::::::::::::::::::::::"$ueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnn                 eeeeeeeeeeeeeeeeeeeeee                                llirssssssssssssssssssssssssssssssssssssssssuuuuuuuuuuuuueeeeeeeeeeeeeeeeee                                              eeeeeeeeennnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn                                vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv<]V5P&Cw\BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBE[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO;x0kATgFS1+I)))))))))))))))))))))))))))))))))))))))))))))))))))))))))mmmmmmmmmmmmmmmmmm-DDDDDDDDDDDDDDDDDDDDDDDDDD/fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffb"phhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhiiiiiiiiiiiiiiiiiiii%sllllllllllllllruuuuuuuuuuuueeeeeeeeennnnnnnnnnnnnnnn:::::::::::::::::::::::::::::::::::::::::::::::::::::::eeeeeeeeeeeee                                                               ssssssssssssssiulnreeeeeeeeeeeeeeeeeeeeeeee                                                     e                       $'||||||||||||||||||||||||||||||||||||||||||||||||||||||||hfffffffffffffffffffffffffffffffffffffffffffffffffff"pmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmusniiiiiiiiiiiiile                                                                %rrrrrrrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                      unnnnnnnnnnnnnnnnnnnnnnnnnns:ieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeellllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeee                                rrTTTTTTTTTTTTTTTTTTTTTTTTTCw1kA000000000000000000000000000000FSggggggggggggggggggggggggggI)+$-DDDDDDDDDDDDDDDDDDDDDDDDDDDDh//////////////////////////////////////////////////////////////////////////////fpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp"""""""""""""""""""""""""""bmunnnnnnnnnnnnnnnnnnnnnnnnnns::::::::::::::::::::iiiiiiiiiiiieeeeeeeeeeeeeeeeee                                              eeeeeeeeelllllllllllllllllllllllllllllllllllllllllllll  uuuuuuuuuuuuuursniiiiiiiiiiiiieeeeeeeeel%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%eeeeeeeeeeee                                                                                                                                                                            h:ppppppppppppppppppffffffffffffff""""""""""""""""""""""""""""""""""""suirlneeeeeeeeeeeeeeeeeeeeeeee                                                     e                       %mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmsiiiiiiiiiiiiiiluuuuuuuuuuuure                                                         nnnnnnnnnnnnnnnnneeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                      PML2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}Y77777777777777777777777777777777777777777777777777777777qUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU8888888888888888888888888888888888888888888888888W;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;; _**********************************HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH46666666666666666666666666666666666666666666666666666~zXj







































vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv<]V5555555555555555555555555555555AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA\EBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB[NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&)TTTTTTTTTTTTTTTTTTTTTTTTTCw1k''''''''''''''''''''''''''''''''''''''''''''''FSggggggggggggggggggggggggggI00000000000000000D$/-++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++%:phif"lsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssxxxxxxxxxxxxxxxxxxxxxxxxxxxxxueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeerrrrrrrrrrrrrrrrrrrr                 eeeeeeeeeeeeeeeeeeeeee                                nnilsssssssssssssssssssssssssmuuuuuuuuuuuuueeeeeeeeeeeeeeeeee                                              eeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr                    ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp%::::::::::::::::ihfsnnnnnnnnnnnnnnluuuuuuuuuuuueeeeeeeeerm"""""""""""""""""""""""""""""""""""""""""""""""""""""""eeeeeeeeeeeee                                                               ssssssssssssssiunrleeeeeeeeeeeeeeeeeeeeeeee                                                     e                       bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbkAI)TTTTTTTTTTTTTTTTTTTTTTTTTCw1,||||||||||||||||||||||||||||||||||||||||||||||||||||||||FSggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg/D+$0-:ppppppppppppppppppppppppppppppppppppmmmmmmmmmmmmmmmmmmmm%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%husriiiiiiiiiiiiine                                      bbbbbbbbbbbbbbbbbbbbbbbbbbbbfllllllllllllllllleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                      urrrrrrrrrrrrrrrrrrrrrrrrrrs"ieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnn                 eeeeeeeeeeeeeeeeeeeeee                                llao::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::mp%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%urrrrrrrrrrrrrrrrrrrrrrrrrrs"hiiiiiiiiiiiieeeeeeeeeeeeeeeeee                                              eeeeeeeeennnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn  tauoooooooooooooolsriiiiiiiiiiiiieeeeeeeeenfffffffffffffffffffffffffffffffffffffffffffffffffffffffeeeeeeeeeeee                                                               O================================PML;2vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv<]TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT5EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\BNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNV[[[[[[[[[[[[[[[[[[[[[[[[[[[[[['''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''&kAI))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))+Cw1,|KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKS/gFFFFFFFFFFFFFFFFFFFFFFFF%bD$0:::::::::::::::::::::::::::::-mpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppttttttttttttttttttttttttttttttttttu"""""""""""""""""""""""""""""""""asoilnreeeeeeeeeeeeeeeeeeeeeeee                                                     e                       fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffustianoooooooooooole                                      hrrrrrrrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                      pppppppppppppppppp%""""""""""""""""""""""""""""m::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::sffffffffffffffffiunttttttttttttahhhhhhhhhhhhhhhhhhhhoeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeellllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeee                                rrssssssssssssssiunttttttttttttaaaaaaaaaaaaaaaaaoooooooooooooeeeeeeeeeeeeeeeeee                                              eeeeeeeeelllllllllllllllllllllllllllllllllllllllllllll                                                                	TkAI)b+Cw1,xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx//////////////////////////FSSSSSSSSSSSSSSSSSSSSSSSSSgmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmD$pf""""""""""""""""""""""""""""0%r::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::hhhhhhhhhhhhhhhhhhhustianooooooooooooeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllleeeeeeeeeeeeeeeeeeee                                                               uuuuuuuuuuuuuutrasoilneeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                                       eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee------------------mhf"pu%:tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttaaaaaaaaaaaaaaorlsssssssssssssiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeeeeeeeeeeeeeeee                                      atoullllllllllllllllllllllllllrrrrrrrrrrrrrrrrsssssssssssssssssssseeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiii                                                        eeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnR3333333333333333333333333333333333333333333333333333333@GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW_*M>4HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH96
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~jOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP=L;2vN<]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]5EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEB\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\V['	y(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII|&CkATxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxb+)F1,wwwwwwwwwwwwwwwwwwwwwwwwwwwww///////////////////////////////////////////////////////////////////////////////////////////////////gSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSDh-$"m%fffffffffffffffffpppppppppppppppppppp:atoullllllllllllllllllllllllllrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrssssssssssssssssssssssssssssssssssssssssssssss                    eeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeee  tnuaaaaaaaaaaaaaaorlsssssssssssssssssssssiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                            ee%%%%%%%%%%%%%%%%%%hhhhhhhhhhhhhhhhhhhh"m0tfffffffffffffffffuuuuuuuuuuuuuuuuppppppppppppppnrasoillllllllllllllllllllllll                                                                       eeeeeeeeeeeeeeeeeeeeeeeeeee::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::urtsniaaaaaaaaaaaao eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeellllllllllllllllllllllllllllllllllllllllllllllllllllllleeeeeeeeeeeeeeeeeeee                                                               A(,IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIyCk	gKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKb+)F1TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT/wwwwwwwwwwwwwwwwwwwwwwwm-------------------------SSSSSSSSSSSSSSSSSSSSSSSS%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%"hhhhhhhhhhhhhh0Dfrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrsuittttttttttttnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnpaeeeeeeeeeeeeeeeeeeeeo                                                                       eeeeeeeeeeeeellllllllllllllllllllllllllllllllllllllllsriiiiiiiiiiiiiiiiiiiiiiiiiu:tttttttttttttnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeelaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeo                                      """"""""""""""""""mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%sh$iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiffffffffffffr::::::::::::::::::::::::::::::::::::::::::ultttttttttttttttttttteeeeeeeeonnnnnnnnnnnnnnnnnnnn                                                        eeeeeeeeeeeeeeeeeeeeeeaaissssssssssssrppppppppppppppppppppppppppultooooooooooooooooooooooooooooooooooo                    eeeeeeeeeeeeeeeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnnneeeeeeeeeeeeeeeeeeeeeeeeeeeee                                >!MOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP=L;2vN<]AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA555555555555555555555555555555555555EBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB[\k|V'''''''''''''''''''''''''''''''''xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx(,IIIIIIIIIIIIIIIIIIIIIIIIIII1yCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC	g&b-)F+TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTcd/wwwwwwwwwwwwwwwwwwww00000000000000000000000000000000000000000000000S""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""ma%hs:$$$$$$$$$$$$$$$$$$$$$$$$riiiiiiiiiiiiiiiiiiiiiiiiiupftttttttttttttttttttttnlllllllllllllllllllleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeo                                                            eerssssssssssssssauittttttttttttnnnnnnnnnnnnnnnnnooooooooooooo                                                                       eeeeeeeeellllllllllllllllllllllllllllllllllllllllllllllllllllllllllldddddddddddddddddddddddddddddddddddcccccccccccccccccc:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"rm%%%%%%%%%%%%%%phustanioooooooooooo eeeeeeeeelllllllllllllllllDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDeeeeeeeeeeeeeeeeeeee                                                               uuuuuuuuuuuuuutrnsoalieeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                                       eeeeeeeeeeeeeffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffkkkkkkkkkkkkkkkkkkkkkAAAAAAAAAAAAAAAAAAAAAA(,IIIIIIIIIIIIIIIIIIIIIIIIIIIII1yCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC	ggggggggggggggggggggggggggg$-)F+TTTTTTTTTTTTTTTTTTTTTTTTTTbc0/////////////////////////wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwdp::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::u"mttttttttttttttttt%nnnnnnnnnnnnnnorlsssssssssssssaaaaaaaaaaaaaaaaaa eeeeeeeeeeeeeeeeeeeeeeeeeeeefhiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeeee                                      ntoullllllllllllllllllllllllllrDSsssssssssssssssssssseeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaa                                                        eeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiicppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppd"::::::::::::::::::::::::::::::::::fmntoullllllllllllllllllllllllllrrrrrrrrrrrrrrrrrrrrrrrr%ssssssssssssssssssssssssssssssssssssssssssssss                    eeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeeeeeeee  tiunnnnnnnnnnnnnnorlsssssssssssssssssssssahhhhhhhhhhhhhhhhhhhheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                            eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee{}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}7777777777777777777777777777777777777777777777777777777777qYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYUz8888888888888888888888888888888888888888888888888888R3<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<@WGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG__________________________________________44444444444444444444444444444444444444444444444444444444444444444444444444444444444*9JH

















































































































6K~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>!MOxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxP=L;2vNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]555555555555555555555555555555555555EB,.[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[|||||||||||||||||||||||||||||||||||'\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\VjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjgggggggggggggggggggggAAAAAAAAAAAAAAAAAAAAAA(kIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIyCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC	111111111111111111111111111$D)F+T-b0pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp/w""""""""""""""""""""cccccccccccccccccccfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffddddddddddddddddt:::::::::::::::::uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuirnsoallllllllllllllllllllllll                                                                       eeeeeeeeehmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmurtsiannnnnnnnnnnno eeeeeeeee%llllllllllllllllllllllllllllllllllllllllllllllllllllllleeeeeeeeeeeeeeeeeeee                                                               cpd""""""""""""""""""""""""""""""""""Sfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff:rhhhhhhhhhhhhhhhhhsuatttttttttttti%%%%%%%%%%%%%%%%%%neeeeeeeeeeeeeeeeeeeeo                                                                          eeeeeeeeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllsraaaaaaaaaaaaaaaaaaaaaaaaaumtttttttttttttiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeelnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeeeeo                                                                      .,cAg(((((((((((((((((((((IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIkCCCCCCCCCCCCCCCCCCCCCCCCCCCCC	y&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&F1$Db)+T/-000000000000000000000000000000000000000000000000000000000000000000000000000ssssssssssssssssssssdSw"pppppppppppppppppppppppppphffffffffffffffffffffffffffffffffff%:::::::::::::aaaaaaaaaaaaaarrrrrrrrrrrummmmmmmmmmmmmmmmmeltoiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                      neeeeeeeeeeeeeeeeeee                                                                               lllllllllllllasnuuuuuuuuuuuuuuuuuurrrrrrrrrto eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeei eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeehhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhpdc"a%%%%%%%%%%%%%%%fffffffffffffffffffmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm:lllllllllllllllllllllllllllllllllsniurteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                                  aiiiiiiiiiiiiiiiiilllllllllllllleeeeeeeeeeeesssssssssssrnnnnnnnnnnnnnnnnn ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeett2<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>!MExxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxP=L;OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]555555555555555555555555555555555555v.|[''''''''''''''''''''''''''''''''''''''''''''BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB(((((((((((((((((((((((((((((((((((((\VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVAg,	IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIFCCCCCCCCCCCCCCCCCCCCCCCCCCCCCkb&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&y/$D111111111111111111111111+T)h-00000000000000000000000000000000000000000000000000000000000000000000000000Spppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppcccccccccccccccccccc%df"mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmaiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiilllllllllllllllllllllllllsrnoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                            :tsaiiiiiiiiiiiiiiiiiiiiiiillllllllllllllennnnnnnnnnnnnnnnnnnnnurrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooofh:pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppcccccccccccccccccccc%dwiiiiiiiiiiiiiiiiiimmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"""""""""""""""""""nsattttttttttttttttttttttllllllllluuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooorrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaiunssssssssssssssssrrrrrrrrrrrrrltttttttttttttttttttttttoeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                   .(fgggggggggggggggggggggggggg	AAAAAAAAAAAAAAAAAAAAAA,FIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIbCCCCCCCCCCCCCCCCCCCCCCCCCCCkdDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDy/T$1111111111111111111111111111111111111111111111+)-------------------------0aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa::::::::::::::::::::phcsssssssssssssssss%wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww"mlunieeeeeeeeeeeeeeeeeeeeeeeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoosaluniiiiiiiiiiiiiiiiiiirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                                            dooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooh:fpu"c%SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSralsssssssssssnieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemmmmmmmmmmttttttttttttttttttttttttttttttttttttttttt                               eeeeeeeeeeeeeeeeeee                                                         luuuuuuuuuuuuuraoooooooooosnnnnnnnnnti eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.RWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW{_____________________________________________@333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333G
4444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444KXH*2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222226!<DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD>ME;xP=======================================LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]'5v|||||||||||||||||||||||||||||||||||||[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[B&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV	gggggggggggggggggggggggggggggggggggggggggggggggFAAAAAAAAAAAAAAAAAAAAAAAAAAAAA,bIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII(C"Tkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk~yyyyyyyyyyyyyyyyyyyyyyy/$111111111111111111111111111111111111111111111111+)w-lhhhhhhhhhhhhhhhhhhhhfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffd:aaaaaaaaaaaaaaaapc%%%%%%%%%%%%%%%%%%%S0tttttttttttttruuuuuuuuuuuuuusnooooooooooiiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      rantttttttttttttleuuuuuuuuuuuuuuuuuuuuuuuuisssssssssssssssss moooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeh"fffffffffffffffffdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddc:::::::::::::::::::ppppppppppppppp%rantttttttttttttluuuuuuuuuuuuuuismmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                            tttttttttttttttttttttttttanrrrrrrrrrrrrrrrrrrrrrrrlesuuuuuuuuuuoiiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee                                                               T.Dhhhhhhhhhhhhhhhhhhhhhh	FggggggggggggggggggggggggggggggggggggggggggggggggggggggbAAAAAAAAAAAAAAAAAAAAAAAAAAA,(IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIcccccccccccccccccccccccCkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkky/$w111111111111111111111111+S)tdffffffffffffffffffffffffffffffff""""""""""""""""""""nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn:::::::::::::::::::mpssssssssssssssaaaaaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrrrol eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%uiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeanosssssssssssssstirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrllllllllllllllllllllllllllll-eeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                    caaaaaaaaaaaaaaaad"fhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm::::::::::::::::::::::::::::::::::::::::::::::::osnetiiiiiiiiiiilrrrrrrrrrrrrrrrrr uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee0p%%%%%%%%%%%%%%aaaaaaaaaaaaaosntilruuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            .!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!22222222222222222222222;<>MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMExPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP=LO''''''''''''''''''''''''''''''''''''''N]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]5v&|[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\TTTTTTTTTTTTTTTFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF	bgggggggggggggggggggggggggggggggggggggggggggggggggggg(AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA,DImmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmCkwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwVy/S$111111111111111111111111111111111111111111111111111+%%%%%%%%%%%%%%%%d"fhhhhhhhhhhhhhhhhhcoooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo0)::::::::::::::::::::::::::::::::::::::iaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnertttttttttttttttttttttllllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuoriapppppppppppppppppppppppssssssssssssssssssssn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemmmmmmmmmmmmmd%ffffffffffffffffffffffffffffff"a-hccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccriollllllllllllllsp::::::::::nueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      iassssssssssssrrrrrrrrrrrrreolllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu.................................................FFFFFFFFFFFFFFFFFFFFFFTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTbg																									(AAAAAAAAAAAAAAAAAAAAAAAAAAwDI,SCkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkky/jjjjjjjjjjjjjjjjj$1d000000000000000000000000fmmmmmmmmmmmmmmm%-++++++++++++++++c""""""""""""""""""""hppppppppppppppppppiassssssssssssrrrrrrrrrrrrrolnnnnnnnnnnnnnntttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                       ulasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeoooooooooo:nnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttcddddddddddddddddddddddddddf)mmmmmmmmmmmmmmmmm%spppppppppppppppp""""""""""""""""""""""""""""""""""""""hhhhhhhhhhhhhhlauuuuuuuuuuirrrrrrrrr:::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetonnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeassssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssllllllllllllniruuuuuuuuuuuuuuuuuuuuuuteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      .9}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}7777777777777777777777777777777777777777777777777777777777qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzYU@WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR_____________________________________________{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{3H
4GKX888888888888888888888888888888888888888888!****************************************************************************************************************************************************************************************;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII2<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>MEx'P=LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON&]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]55555555555555555555555555555555555555555v|[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccFgTTTTTTTTTTTTTTTTTTTTTTTTTbA	w((((((((((((((((((((((((((((((((((((((((((((((((pkD,S/CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC0yj6\$-1a))))))))))))))))))))))))))))))))))))))))))))))))))))))fdmlllllllllllllllllll%%%%%%%%%%%%%%%%"::::::::::::::::::::rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrhhhhhhhhhhhhhhseeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettlarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrssssssssssssnnnnnnnnnnnnnioooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                                              pttttttttttttttttt+dddddddddddddddcffffffffffffffffffm%%%%%%%%%%%%%%%%"::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::narllllllllllllllllllllllllseiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooortinahhhhhhhhhhllllllllllllllllllllllus eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeek.IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIgggggggggggggggggggggggggggggggggggggggggggggggggggFATwbbbbbbbbbbbbbbbbbbbbbbb																													((((((((((((((((((//////////////////////////D,0SCCCCCCCCCCCCCCCCCCCCC----------------------------yV)$rdddddddddddddddddc+1pppppppppppppppa"fm%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%uintttttttttttttllllllllllllllh::::::::::soeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      naaaaaaaaaaaaaauiretttttttttttttttttttttttslllllllllllllllll                                                                                                                                        eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooddddddddddddddddddcccccccccccccccccccppppppppppppppppp""""""""""""""""""""""""mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmfh%naaaaaaaaaaaaaauirtttttttttttttslllllllllllllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            uoooooooooooooaaaaaaaaaaaaaannnnnnnnnnnireltttttttttt:ssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee                                                         .;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;!//////////////////////////////////////////////////////////////////2<'>MEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEExP=&LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]5v|~[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[BkdgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggAAAAAAAAAAAAAAAAAAAAAAAAAAAwFFFFFFFFFFFFFFFFFFFFFFFTTTTTTTTTTTTTTTTTTTTTTTTTTTTTbI	m0((((((((((((((((((((((((((D-,SC))))))))))))))))))))))))))))))))))))))))))))))))y+VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVupc"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""hhhhhhhhhhhhhhhhhhhhhhhh$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$flllllllllllllaooooooooooniiiiiiiii:%r eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetssssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaaaaaalllllllllllllusnioooooooooorrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      hma"ppppppppppppppppppcddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd111111111111111::::::::::::::::::::iiiiiiiiiiiiiiiiflllllllllllllleusssssssssssrnnnnnnnnnnnnnnnnn toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeai%llllllllllllllusrntttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                            0./hhhhhhhhhhhhhhhhhhhhhhhhhgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwFITkbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb-	(((((((((((((((((((((((((()D,S+CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCyyyyyyyyyyyyyyyyyyyyyyyyyyyyy"dpmc%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%1\\\\\\\\\\\\\\\:::::::::::::::::::::::::::::::::::saiiiiiiiiiiiiiiiiiiiiiiillllllllllllllenuuuuuuuuuuorrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttiiiiiiiiiiiinsaffffffffffffffffffffffllllllllloooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeturrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%iddddddddddddddddddm"hpaaaaaaaaaaaaaaacccccccccccccccccccccccccccccccccccccccccccccccccccccc$onssssssssssssrrrrrrrrrrrrrlf:::::::::::::::::::::::teeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      salonieeeeeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt@WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW________________________________________________{HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH43
RGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK*;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;!jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj2<'>MEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~P=&LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOx.................................]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvN5AV|[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[00000000000000000000000000000000000000000000000g/Iwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww-----------------------------FFFFFFFFFFFFFFFFFFFFFFFFFFF)kbT+((((((((((((((((((((((((((																								,SD%CCCCCCCCCCCCCCCCCCCCCd1111111111111111111111111111mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh"""""""""""""""""""ppppppppppppppppppppcfffffffffffffffffsaloniiiiiiiiiiiirrrrrrrrrrrrrrrrrrrrrrrrrruuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee$yeeeeeeeeeeeeeeeeeeee                                            otralsssssssssssnieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuudohmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%%%%%%%%%%%%%%%%%%lf"pppppppppppppppppppppppppppppppppppcccccccccccccrattttttttttsnnnnnnnnn:::::::::::::::::i eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeal\BBBBBBBBBBBBBroooooooooooooosnttttttttttiueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      b.AAAAAAAAAAAAAAAAAAAgggggggggggggggggggggggIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII/-wFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF)))))))))))))))))))))))))))))000000000000000000000000000ffffffffffffffffffffffffffkT+S(																								1,DC$$$$$$$$$$$$$$$$$$$$$aaaaaaaaaaaaaaah%mdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr"p::::::::::::::::::::nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnncccccccccccccleooooooooooooooooooooooooisssssssssssssssss            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuurannnnnnnnnnnnnnnnnnnnnnnnnnnnnlooooooooooooooisssssssssssssssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                                           fu%%%%%%%%%%%%%%%dhhhhhhhhhhhhhhhhhhhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"p::::::::::::::::::::yyyyyyyyyyyyyyanrrrrrrrrrrrrrrrrrrrrrrrlesooooooooootiiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee                                                         nussssssssssssssaccccccccccrrrrrrrrrrrrrrrrrrrrrtl eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee....................................................................!;;;;;;;;;;;;;;;;;;;;;;;;;;<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<E2'>=MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM66666666666666666666666666666666666666P&LvOxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxV]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]N\5|[bbbbbbbbbbbbbbbbIgggggggggggggggggggggggggggggggggggggggggggg-------------------------F/)w000000000000000000000000000000AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAASSSSSSSSSSSSSSSSSSSSSSSSSSSkT1+(	$$$$$$$$$$$$$$$$$$$$$$$$,DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDCnd%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%fhapmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"tssssssssssssssuirrrrrrrrrrrrrc::::::::::lllllllllllleeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                                   aaaaaaaaaaaaatsneuiiiiiiiiiiilrrrrrrrrrrrrrrrrr oyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeddddddddddddddddddddddddddddddddddddddddddddddddddf%ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppphhhhhhhhhhhhhhhhhhhhmcccccccccccccccccccccccccccccccaaaaaaaaaaaaatsnuilroooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"eeeeeeeeeeeeeeeeeeee                                            ttttttttttttiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasneruuuuuuuuuu:llllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooS..........................ddddddddddddddddddddddI-gFFFFFFFFFFFFFFFFFFFFFFF)))))))))))))))))))))))))0/Awbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb1111111111111111111111111111111111111111111111111111111k$T+(B																								,yDtfffffffffffffffffffpppppppppppppppppppppppppppppppp%%%%%%%%%%%%%ccccccccccccccchhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhCmriaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssss::::::::::::::::::n eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoullllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaa"ritllllllllllllllsssssssssssssssssssssnoeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccapfffffffffffffffffffffffffffffffffffddddddddddddddddiiiiiiiiiiiiiiiiiiiii%%%%%%%%%%%%%%%h::::::::::::::::::::s"mrrrrrrrrrrrrretlllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooiassssssssssssssssssrrrrrrrrrrrrrtlnnnnnnnnnnnnnnuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            <.‘‡£¢°†üûùúõöôòóñïﬁìíëêèéçåãäâàáÜÖÑÉÇÅÄπÛ…·Ù˛∏’‹¿±∆™ˆœÆµº˙«¬©¡»î˘®Ÿ¨`≈^¸À˝Z´√ª∂∫€∑Q˚—ˇÊÏ §Ú‰Ò˜≠ßÂ◊÷›?ÁÌŒÓ¥ﬂ“ÃËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËËÿÈ⁄≤”„≥¯ΩÔÕæƒø∞#¶•‚–XÍÎØı9}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}W7zqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU@________________________________________________________________________________________________________________________________________________________________________4j{
RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRG3!KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK~*************************************1E;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;=========================================2''''''''''''''''''''''''''''''''''''''>MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMv666666666666666666666666666666666666666666666666666666666666P&VLOx\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]N5|Sc----------------------FI)g00000000000000000000000AAAAAAAAAAAAAAAAAAAAAAAAAb//////////////////////////wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwk$T+(B[																								,yDDDDDDDDDDDDDDDDDDDDDDDDDDDDooooooooooooooooopdfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff%%%%%%%%%%%%%%%h::::::::::::::::::::"lasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeetttttttttttttttttttttnnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuusoooooooooooooolammmmmmmmmmirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeecsdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddpCfahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%lonirm::::::::::::::::::::::ueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      larrrrrrrrrrrrrrrrrrrrrrrrrseonnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii t"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""" eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuF.10----------------------Sb)gIIIIIIIIIIIIIIIIIIIIIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAkkkkkkkkkkkkkkkkkkkkkkkkkkw/((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((,T+$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$	dDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDcCyyyyyyyyyyyyyyyyyhppppppppppppppppffffffffffffffffffffffffffffffffffffffm%larrrrrrrrrrrrrrrrrrrrrrrrrsonnnnnnnnnnnnnitttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"""""""""""""""eeeeeeeeeeeeeeeeeeee                                                       unarllllllllllllllllllllllllseioooooooooo::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddhccccccccccccccccccccccccccccccccccrmpffffffffffffffffffff"""""""""""""""""""inauuuuuuuuuullllllllllllllllllllll:%s eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetoooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeearrrrrrrrrrrrrrrinnnnnnnnnnnnnnnnnnnnnnnnlllllllllllllluuuuuuuuuusteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      .<!EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEw=====================================;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;2v'>MVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVP\&LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx]BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBN5FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0b-gSSSSSSSSSSSSSSSSSSSSS)))))))))))))))))))))))))IkA11111111111111111111111mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm/(++++++++++++++++++++++++++++++++++++++++++++++++++++++++++,DT$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$|C	ahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhdcn"""""""""""""""""pf:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::ireeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeslllllllllllllllll ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettnaaaaaaaaaaaaaa%irrrrrrrrrrrrrrrrrrrrrrrrsloooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                            "mtttttttttttttttttthdyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy%cccccccccccccccccpf::::::::::::::::::::::::::::::::::::::::::::::aaaaaaaaaaaaaannnnnnnnnnnirelllllllllllllllllllllussssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooooooooooooooootlllllllllllllaaaaaaaaaaaaaaaaaaaaaaaaaaaaniiiiiiiiiur eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooossssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.w"bbbbbbbbbbbbbbbbbbbbbbg000000000000000000000-------------------------Sk)1IFA%++++++++++++++++++++++++++++++++++++++++++++++++/D((((((((((((((((((((((((((((((((((((((((((((((((((((((((((C,T$$$$$$$$$$$$$$$$$$$$$$$$$$$$[[[[[[[[[[[[[[dddddddddddddddddddddddddddddddddhmy	afffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffccccccccccccccccccccccccccccccccccccpullllllllllllltsniiiiiiiiiiiiiiiiiii::::::::::roeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                  aiulllllllllllllletsssssssssssrnnnnnnnnnnnnnnnnn                                                                                          eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeood%%%%%%%%%%%%%%%%"mmmmmmmmmmmmmmmmmmfhcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccaiulllllllllllllltsrnnnnnnnnnnnnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepeeeeeeeeeeeeeeeeeeee                                            uosaiiiiiiiiiiiiiiiiiiiiiiillllllllllllllentttttttttt:rrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee                                                         .HWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW8j________________________________________________@GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG4444444444444444444444444444444444444444444444444~
R{<3KE666666666666666666666666666666666666666666=!+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++;vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvV2'>\MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM***********************************P&LBOxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]NNNNNNNNNNNNNNNNNNNNNNNNNNNdgbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb0k-1SF)wIcDAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAC/(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((,Ty$ummmmmmmmmmmmmmmmf"%%%%%%%%%%%%%%%%%%iiiiiiiiiiiiiiiiiiihhhhhhhhhhhhhhhhhhhhhhhh[5555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555nsaoooooooooooooooooooooolllllllll:::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaipnsurrrrrrrrrrrrrlooooooooooooooooooooooooooooooooooeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                                        cafm%%%%%%%%%%%%%%%%d"ssssssssssssssssssssssssssssssssh	::::::::::::::::::::lpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppnieurrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesalllllllllllllllllniurrrrrrrrrrrrrrrrrrrrrrrrrrtttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                            D.+++++++++++++++++++++++++++++++++++++++gggggggggggggggggggggggggbkkkkkkkkkkkkkkkkkkkkkk10F-wSSSSSSSSSSSSSSSSSSSSSSSSSSS)))))))))))))))CIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/(yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy,,,,,,,,,,,,,,,,,,,,,,,,TTTTTTTTTTTT%fdmcccccccccccccccccccccccccccccccc""""""""""""""""""h	$::::::::::::::::::::pralsssssssssssnieeeeeeeeeeeeeuuuuuuuuuuooooooooooooooooooooooooooooooooooooooooo                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttllllllllllllllllllllllllraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnnnnnnnnnoi eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeld%cfffffffffffffffffffma||||||||||||||||"""""""""""""""""""""""""""""""""""""hooooooooooooorrrrrrrrrrrrrrrrrrrrrrrrrsnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn::::::::::iteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      ranoooooooooooooleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeisssssssssssssssss upppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettVE<=!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!;vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv'>\MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM2.B&xLPOOOOOOOOOOOOOOOOOOOOOOOOO[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]D111111111111111111111g+wkkkkkkkkkkkkkkkkkkkkkkbCF-000000000000000000000000000000000000000000000000000000)SyAAAAAAAAAAAAAAAAAAAAAAAIIIIIIIIIIIIIIIIIIIIIIII/(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((d	,ccccccccccccccccccccccccccccccccc%|NTf"mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmranooooooooooooolllllllllllllllllllllllllisuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepheeeeeeeeeeeeeeeeeeee                                            ottttttttttttttanrrrrrrrrrrrrrrrrrrrrrrrlesssssssssssssssssssss:iiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu"doooooooooooooooooooc$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$%nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnfmmmmmmmmmmmmmmmmmmmmppppppppppppppppssssssssssssssattttttttttrrrrrrrrrrrrrrrrrrrrr::::::::::::::::::l eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeanhssssssssssssssoirrrrrrrrrrrrrttttttttttlueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      )........................."g1wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww+Ck-bbbbbbbbbbbbbbbbbbbbbbbbbbbbFD0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000Sy(AIIIIIIIIIIIIIIIIIIIIIIII	//////////////////////////////////////////////////////555555555555555555555555555555a$,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,cddddddddddddddddddddddddddddp%fm::::::::::::::::::::::::::::::::hhhhhhhhhhhhhhhhsneoiiiiiiiiiiilrrrrrrrrrrrrrrrrr            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnoilrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                            pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppuuuuuuuuuuuuuuuuuTddddddddddddddddddd"cccccccccccccccccccccccccccccccc%fm::::::::::::::::::::hiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnerooooooooootllllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee                                                                     uriaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaassssssssstn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeollllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.JX9}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzq77777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHW4j_8YRGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG@6~
















































V{3<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<K!EEEEEEEEEEEEEEEEEEEEEEE;====================================================================================================================================================vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>'\Mxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx2B[&LP|OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO])pwgggggggggggggggggggggg1CCCCCCCCCCCCCCCCCCCCC-++++++++++++++++++++++++++++kDbbbbbbbbbbbbbbbbbbbbbbbbbFFFFFFFFFFFFFFFFFF(000000000000000000000000000S	yAI555555555555555555555555555555555555555555555555555555555555555555//////////////////////////$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ddddddddddddddddd"TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTamccccccccccccccc%%%%%%%%%%%%%%%%%%%%ftriullllllllllllllssssssssssssssss::::::::::nnnnnnnnnnnneeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      iastrrrrrrrrrrrrreulllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn ohhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeedddddddddddddddddd"pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppm,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,cccccccccccccccc%iastrrrrrrrrrrrrrulnnnnnnnnnnnnnnoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeehfeeeeeeeeeeeeeeeeeeee                                            ttttttttttttlasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeuuuuuuuuuu:nnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooo(.......................ddddddddddddddddddddddwCg-111111111111111111111111111111111111111111111111D+++++++++++++++++++++++++k)bbbbbbbbbbbbbbb	F000000000000000000000000000NSyA$IIIIIIIIIIIIIIIIIIIIIIII/TTTTTTTTTTTTTTTTTTTTTTTTTTttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt"mppppppppppppppppppppppppppppppppppssssssssssssssss,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,hcccccccccccccclaaaaaaaaaaaaaaaaaaaaairrrrrrrrr:%%%%%%%%%%%%% eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeounnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeasffffffffffffffltnirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrroeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                                   ammmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"dplhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh::::::::::::::::::::rfccccccccccccccsetnnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoolar%%%%%%%%%%%%%%stnnnnnnnnnnnnniuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            .!<;V																																									E======================================>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>v*********************************************************************************************************xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx'\[MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM2|B&L5POOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO((((((((((((((((CCCCCCCCCCCCCCCCCCCCCC-wwwwwwwwwwwwwwwwwwwwwwwwwwwwgD111111111111111111111111111111111111111111111)+++++++++++++++++++++++khN]bF0$$$$$$$$$$$$$$$$$$$$$$$$$$$SyTAIIIIIIIIIIIIIIIIIIIIIIII,/oooooooooooooooooomddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd"%ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp::::::::::::::::::::fnarllllllllllllllllllllllllseitttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuroinaccccccccccllllllllllllllllllllllllllllllllls eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%hrddddddddddddddddddddddddddddddddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmaaaaaaaaaaaaaaaaaaa"pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppinooooooooooooollllllllllllllc::::::::::sueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      naaaaaaaaaaaaaaaaaaaaaaaaaireoooooooooooooooooooooooslllllllllllllllll tffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuu-.	DCCCCCCCCCCCCCCCCCCCCCC())))))))))))))))))))))))))))gwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww1$$$$$$$$$$$$$$$$$$$$$$$k+TF0b,Syyyyyyyyyyyyyyyyyyyyyyyyyyy%AIdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp"cccccccccccccccccnaaaaaaaaaaaaaaaaaaaaaaaaairooooooooooooosltttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeefffffffffffffffffffffffffffff/eeeeeeeeeeeeeeeeeeee                                                       uuuuuuuuuuuuuaaaaaaaaaaaaaannnnnnnnnnnireloooooooooo:ssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttpdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddh%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%cmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmf"lllllllllllllauuuuuuuuuuniiiiiiiii:::::::::::::::::r eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetossssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaallllllllllllllllllllllllsniuuuuuuuuuurteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      ..........................................................................................................................................._______________________________________________________________________________________HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH4jW
RGUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU6~@!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!{;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;33333333333333333333333333333333333333333<k>VE=*KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKxvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[['|\MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM52B&NLPO-ppppppppppppppppppppppD)Cg((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((w$$$$$$$$$$$$$$$$$$$$$$$$$	1c00000000000000000000000+TyFb,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,SSSSSSSSSSSSSSSSSSSSSSSSSSSAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa%%%%%%%%%%%%%%%dhhhhhhhhhhhhhffffffffffffffffffmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm::::::::::::::::::::iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii"lllllllllllllleeeeeeeeeeeesssssssssssrnnnnnnnnnnnnnnnnn ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettttttttttttttaiiiiiiiiiiiiiiiiilllllllllllllllllllllllllsrnoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                            fct%%%%%%%%%%%%%%%%%%%ddddddddddddddddppppppppppppppppppppppppppppppphhhhhhhhhhhhhhhhhhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm::::::::::::::::::::/saiiiiiiiiiiiiiiiiiiiiiiillllllllllllllennnnnnnnnnnnnnnnnnnnnurrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooitnsa""""""""""""""""""""""llllllllluuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooorrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee0.kf))))))))))))))))))))))gD]CCCCCCCCCCCCCCCCCCCCC($$$$$$$$$$$$$$$$$$$$$$$$$$$$	w-----------------------------------------y11111111111111111111111++++++++++++++++++++++++++++++TFbbbbbbbbbbbbbbbbbbbbbbbbbbbbb,SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSAid%pppppppppppppppppppccccccccccccccccaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmunstrrrrrrrrrrrrrl":::::::::::::::::::::::oeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      salunietrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr            /IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoodddddddddddddddddpfc%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh""""""""""""""""""salunitrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemeeeeeeeeeeeeeeeeeeee                                            uoralsssssssssssnieeeeeeeeeeeeetttttttttt:::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee                                                         .........................................;>!yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy<VEx========================================================================[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||5'\MNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN2BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB&LP0dg)]OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOD$C	(----------------------------kwhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh111111111111111111111111111111111111111111111111111+TFFFFFFFFFFFFFFFFFFFFFFFFFFb,S///////////////////////////ucpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppfffffffffffffffff%l""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""AAAAAAAAAAAAAAAAAAAAAAAAAAAraoooooooooosnnnnnnnnn::::::::::::::::::i eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeealmmmmmmmmmmmmmruuuuuuuuuuuuuusnooooooooooiiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      "haaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacccccccccccccccccpdfrI%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%::::::::::::::::::::nmmmmmmmmmmmmmmmmmmmmmmmmmmmleuuuuuuuuuuuuuuuuuuuuuuuuisssssssssssssssss toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeerannnnnnnnnnnnnnnnnnnnnnnnnnnnnnluuuuuuuuuuuuuuistttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                                                         .y"""""""""""""""""""""""""""""""""ggggggggggggggggggggg)$$$$$$$$$$$$$$$$$$$$$$	D-Ck(0000000000000000000000000000Iwwwwwwwwwwwwwwwwwwwwwwwww111111111111111111111111111111111111111111111111111+TFFFFFFFFFFFFFFFFFFFFFFFFFFb,S/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////dchppppppppppppppppppf%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%::::::::::::::::::::mmmmmmmmmmmmmmanrrrrrrrrrrrrrrrrrrrrrrrlesuuuuuuuuuuoiiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttnnnnnnnnnnnnssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrrrol eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetuiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"ndddddddddddddddddhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhAcaaaaaaaaaaaaaaaapf%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%osssssssssssssssssssssssssirrrrrrrrrrrrrrrrrrrrrrrrrrr::::::::::lteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                   aaaaaaaaaaaaaosneeeeeeeeeeeeiiiiiiiiiiilrrrrrrrrrrrrrrrrr ummmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeett~9JJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}7z8qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq_______________________________________________________________________________________HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH4jW
RGUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU6666666666666666666666666666666666666666666666666666[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[*{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{;>!@35VEx========================================================================<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||.N\2M''''''''''''''''''''''''''''''''''''''''''''''''''']B&LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL																																	Pgyk$$$$$$$$$$$$$$$$$$$$$$)I-CDDDDDDDDDDDDDDDDDDDDDDD0000000000000000000000000000(FFFFFFFFFFFFFFFFFFFFFFFFF1wS+TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTbddddddddddddddddddddddddddd,h"A////////////////////////////////////////////////////////////////////////////////////////////fccccccccccccccccccccppppppppppppppp%%%%%%%%%%%%%%aaaaaaaaaaaaaosnnnnnnnnnnnnilruuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemmmmmmmmmmmmmmmmmmmeeeeeeeeeeeeeeeeeeee                                            otiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnerrrrrrrrrrrrrrrrrrrrr:llllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuufdoooooooooooooooooooooooohhhhhhhhhhhhhhhh""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""ccccccccccccccccccccmpriatttttttttttttttttttttttsssssssss:%n eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuullllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaariollllllllllllllsttttttttttnueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                 .....................fg	kOOOOOOOOOOOOOOOOOOOOOOyI$C)))))))))))))))))))))))------------------------------DDDDDDDDDDDDDDD10(FTTTTTTTTTTTTTTTTTTTTTTTTTwSSSSSSSSSSSSSSSSSSSSSSSSSSS++++++++++++++++++++++++++++++++++++++++++++++++++++++Abaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa,,,,,,,,,,,,,,,,,,hd"immmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmc::::::::::::::::::::sssssssssssssssssssprrrrrrrrrrrrreolllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuias%rrrrrrrrrrrrrolnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                            mmmmmmmmmmmmmmmuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuud/fh%"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""c::::::::::::::::::::::::::::::::::::::lasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeooooooooootnnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee                                                         suuuuuuuuuuuuuulappppppppppirrrrrrrrrttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeonnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.;[!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1E>K55555555555555555555555555555555555Vx============================================================================<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<v||||||||||||||||||||||||||||||||||||22222222222222222222222222222222222222222222222222222222222222222222N]\M'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''B&&&&&&&&&&&&&&&&&&&&&&&&&&&&mkgggggggggggggggggggggg	IOLCyyyyyyyyyyyyyyyyyyyyyyy$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$)))))))))))))))))))))-%TD0(((((((((((((((((((((((((((FFFFFFFFFFFFFFFFFFFFFFFFFwAS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++sddddddddddddddddddffffffffffffffffffffffffffffff/bach""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""ttttttttttttttlunirp:::::::::::::::::::::::::::::::::eeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      larttttttttttttttseunnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeed%fmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmcccccccccccccccc",,,,,,,,,,,,,,,,,,,,hppppppppppppppppplarttttttttttttttsunnnnnnnnnnnnnioooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            ttttttttttttnarllllllllllllllllllllllllseiuuuuuuuuuu::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooT.1ddddddddddddddddddddddkIgC																							PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPyyyyyyyyyyyyyyyyyyyyy$$$$$$$$$$$$$$$$$$$$$$$$$$$$)"""""""""""""""""""""""""""-D0A(FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFwS+/////////////////////////////tttttttttttttttfcm%%%%%%%%%%%%%%%%%%rpppppppppppppppp,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,hinaaaaaaaaaaaaaaaaaaaaallllllllllllllllllllll:::::::::::::::::s eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeouuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeearrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrintttttttttttttllllllllllllllllllllllllllllllllllsoeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      p"accccccccccccccc%fdmnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnb:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::hiretttttttttttttttttttttttslllllllllllllllll uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoonaaaaaaaaaaaaaaaaaaaaaaaaaaaaaairtttttttttttttsluuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            ..........................................................................................................................................................................................~444444444444444444444444444444444444444444_RHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH6W
j*YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYG;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@E[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[>K{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{5Vxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx======================================<2222222222222222222222222222222222222222222v|]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]N\MO'''''''''''''''''''''''''''''''BTpIIIIIIIIIIIIIIIIIIIIIICkkkkkkkkkkkkkkkkkkkkkkkgggggggggggggggggggggggggggggg																					P&&&&&&&&&&&&&&&&&&&&&&&&&&&&y1$$$$$$$$$$$$$$$$$$$A)-DDDDDDDDDDDDDDDDDDDDDDDD0(F/////////////////////////wS,+o%cddddddddddddddd"fffffffffffffffffmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmbbbbbbbbbbbbbbbbbbbbbbbbbbbbb::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::aaaaaaaaaaaaaannnnnnnnnnnireltttttttttttttttttttttssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuolllllllllllllahhhhhhhhhhniiiiiiiiiiiiiiiiiiiir eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutssssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeed%"cpppppppppppppppaaaaaaaaaaaaaaaaaaaaaaaaaafmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmlllllllllllllosnih::::::::::rueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                                  aiiiiiiiiiiiilllllllllllllleosssssssssssrnnnnnnnnnnnnnnnnn tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuC........................................................IIIIIIIIIIIIIIIIIIIIIITTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTgkAAAAAAAAAAAAAAAAAAAAAL																								1$y/-D),(F00000000000000000000000000000000000000000wdbS"""""""""""""""""""p%%%%%%%%%%%%%%%%%%%%%%%%%%+cmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmfhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhaiiiiiiiiiiiillllllllllllllosrntttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                       usaiiiiiiiiiiiiiiiiiiiiiiillllllllllllllenoooooooooo:rrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttmddddddddddddp"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""%ihccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccfnsauuuuuuuuuuuuuuuuuuuuuulllllllll::::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetorrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaiiiiiiiiiiiiiiiinssssssssssssrrrrrrrrrrrrrluuuuuuuuuuuuuuuuuuuuuuuteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      .E!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>35V2x======================================]<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOON\PM'''''''''''''''''''''''''''''''CmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmIgTAAAAAAAAAAAAAAAAAAAAAAALBkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk	hD1y/F-),b(00000000000000000000000000000000000000000000000000waaaaaaaaaaaaaaaaaaaaaaaaaaaaaSppppppppppppppppp"dddddddddddddddddddsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss%ccccccccccccccc::::::::::::::::::::llllllllllllllllfnieeeeeeeeeeeerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettsallllllllllllllllllniiiiiiiiiiiirrrrrrrrrrrrrrrrrrrrrrrrrroooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                                                                                        httttttttttttttttt+dpm""""""""""""""""""""""""""""""""""""%ccccccccccccccc:::::::::::::::::::::::::::::::::::ralsssssssssssnieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooltttttttttttttraffffffffffsnnnnnnnnnui eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeD.$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ggggggggggggggggggggggggggggggAI&TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTkCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCF	1yb/-)))))))))))))))))))))))))),(00000000000000000000000000000000000000000000000000000ldddddddddddddddddm+whpaaaaaaaaaaaaaaa"""""""""""""""""""%%%%%%%%%%%%%%%%%%%%cuuuuuuuuuuuuurttttttttttttttsnf::::::::::ioeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      ranuuuuuuuuuuuuulettttttttttttttttttttttttisssssssssssssssss                                                                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooddddddddddddddddddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhSSSSSSSSSSSSSSSSSSSpppppppppppppppppppp"f%ranuuuuuuuuuuuuulttttttttttttttisssssssssssssssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeceeeeeeeeeeeeeeeeeeee                                            uooooooooooooooanrrrrrrrrrrrrrrrrrrrrrrrlestttttttttt:iiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee                                                         .U9XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}7777777777777777777777777777777777777777777777777777777788888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888z______________________________________________________________________________________________________________________________________________________________________________444444444444444444444444444444444444444444~
RH6WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW@*YqjEGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK!FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF;[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[2>33333333333333333333333333333333333333333333333335]Vx======================================================================<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Ov||||||||||||||||||||||||||||||||||||PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPNL\M'DdggggggggggggggggggggggggggggAAAAAAAAAAAAAAAAAAAAAA&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&IIIIIIIIIIIIIIIIIIIIIIIIIIITCCCCCCCCCCCCCCCCCCCCCCC$kkkkkkkkkkkkkkkkkkkbbbbbbbbbbbbbbbbbbbbb	11111111111111111111111111y/-----------------------------),(+0uhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmnfSSSSSSSSSSSSSSSSSSSSSSSSSppppppppppppppppppppppppppppppppppp"ssssssssssssssaoooooooooorrrrrrrrrrrrrrrrrrrrr:%l eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeancssssssssssssssuirrrrrrrrrrrrroooooooooolllllllllllleeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      fffffffffffffffffffaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhmdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddwp::::::::::::::::::::::::::::::::c"sneuiiiiiiiiiiilrrrrrrrrrrrrrrrrr toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaa%snuilrtttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                            b.FfAgBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCI$TDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDkkkkkkkkkkkkkkkkkkkkk																													1y/+-),S(((((((((((((((((((((((((((((((((((((((((((dhhhhhhhhhhhhhhhhhhhm%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%w0p::::::::::::::::::::ciaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasneruuuuuuuuuuollllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttria"""""""""""""""""""""""ssssssssson eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetullllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%%%%%%%%%%%%%%%%%%%%%%%%%%%%ddddddddddddddddddddddddddddddddddddddddddddddddddfhapmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmoriiiiiiiiiiiilllllllllllllls"::::::::::nteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      iasorrrrrrrrrrrrreeeeeeeeeeeelllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn ucccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeett]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!O[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[2>{5;Lx======================================================================<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<V.P||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvBN\M'&bbbbbbbbbbbbbbbbbbbbbbbbbbbAgF$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$CIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIDDDDDDDDDDDDDDDDDDDDDDDT+++++++++++++++++++++	kSy/1%-)dw,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,ffffffffffffffffffppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppphhhhhhhhhhhhhhhhhhhhm"""""""""""""""""iasorrrrrrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnnnnnuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeccccccccccccccccccccccccc(eeeeeeeeeeeeeeeeeeee                                            otlasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:nnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuudofffffffffffffffffffpppppppppppppppp%%%%%%%%%%%%%%%%%%s"""""""""""""""hhhhhhhhhhhhhhhhhhhhcmmmmmmmmmmmmmmlattttttttttirrrrrrrrr::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuunnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeas00000000000000lonirttttttttttttttttttttttueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            ...........................................................................................ggggggggggggggggggggggggggg$AAAAAAAAAAAAAAAAAAAAAAFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIICbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"	DT+/////////////////////kSwy1-------------------------)apf%%%%%%%%%%%%%%%%%%%ddddddddddddddddlcccccccccccccccccccccccccccccccch::::::::::::::::::::r0,mmmmmmmmmmmmmmseonnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuularrrrrrrrrrrrrrrrrrrrrrrrrrrrrrsonnnnnnnnnnnnniiiiiiiiiiiiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                            c"u%pdfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffh::::::::::::::::::::(narllllllllllllllllllllllllseiooooooooootttttttttttttttttttttttttttttttttttttttt                               eeeeeeeeeeeeeeeeeee                                                         ruinammmmmmmmmmllllllllllllllllllllllts eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee..........................................................................................._____________________________________________________________________________________________HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH444444444444444444444444444444444444444444444W
R~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~6K@****************************************]jGE3333333333333333333333333333333333333333333333333333!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!																																																																																																																										O5[2>={{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{;LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx<VPB||||||||||||||||||||||||||||||||||||v''''''''''''''''''''''''''''''''N\\\\\\\\\\\\\\\\\\\\\\\c$gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggAIFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbMCCCCCCCCCCCCCCCCC//////////////////////////////DTw+++++++++++++++++++++kkkkkkkkkkkkkkkkkkkkkkkkkSy10-rd%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%p"fahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhtinuuuuuuuuuuuuullllllllllllllm::::::::::sssssssssssseeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      naaaaaaaaaaaaaatireuuuuuuuuuuuuuuuuuuuuuuuslllllllllllllllll o()))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))) eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeedddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddc"%hppppppppppppppppffffffffffffffffffffffffffffffffffffffmmmmmmmmmmmmmmmmmmnaaaaaaaaaaaaaatiruuuuuuuuuuuuusloooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee,,,,,,,,,,,,,,,eeeeeeeeeeeeeeeeeeee                                            ttttttttttttttttttttttttaaaaaaaaaaaaaannnnnnnnnnnireluuuuuuuuuu:ssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooo/.	dddddddddddddddddddddd$$$$$$$$$$$$$$$$$$$$$$$$$$gIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIAbF&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&wCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCDDDDDDDDDDDDDDDDDDDDDDDDDT+++++++++++++++++++++0kSy(1t"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""hccccccccccccccccc%%%%%%%%%%%%%%mpffffffffffffffffffff,-------------------lllllllllllllaaaaaaaaaaaaaaaaaaaaaniiiiiiiii::::::::::::::::::r eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoussssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaaaaallllllllllllltsniiiiiiiiiiiiiiiiiiiiiroeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      mmmmmmmmmmmmmmmmah"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""dccccccccccccc)%pf::::::::::::::::::::iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiilllllllllllllletsssssssssssrnnnnnnnnnnnnnnnnn uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooooaiiiiiiiiiiiiiiiiiilllllllllllllltsrnuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            .!EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE]w55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555=O[2222222222222222222222222222222222222222222>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;LxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB<V'P||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvN/mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmI$$$$$$$$$$$$$$$$$$$$$$$$$$$$$gbbbbbbbbbbbbbbbbbbbbbbbbbbb&\AAAAAAAAAAAAAAAAAAAAAAAF																								))))))))))))))))))))))))))))CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCDDDDDDDDDDDDDDDDDDDDDDDDDT+++++++++++++++++++++0kSy(1,ooooooooooooooooohd"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""c%pf::::::::::::::::::::::::::::::::::saiiiiiiiiiiiiiiiiiiiiiiillllllllllllllentttttttttttttttttttttrrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuionsaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaalllllllllllllllllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemiddddddddddddddddddddddddddddddddh-"afffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffc%%%%%%%%%%%%%%%%%%%%ppppppppppppnsorrrrrrrrrrrrrlllllllllllllllllll:::::::::::::::::::::::ueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      sallllllllllllnieorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuI.wbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb///////////////////////////////////////////////////g$)MAAAAAAAAAAAAAAAAAAAAAAAAAAAD																								FFFFFFFFFFFFFFFFFFFFFCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCyT++++++++++++++++++++++++++++++++++++++++++0kd1SSSSSSSSSSSSSSSSm-(((((((((((((((((fhc""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""%sallllllllllllniorrrrrrrrrrrrrrrrrrrrrrrrrrtttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepeeeeeeeeeeeeeeeeeeee                                                       uralsssssssssssnieeeeeeeeeeeeeoooooooooo:::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttcdddddddddddd,,,,,,,,,,,,,,,,fmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmlllllllllllllllllllh""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""rauuuuuuuuuusnnnnnnnnn:%i eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeealppppppppppppprrrrrrrrrrrrrrrrrrrrrrrrrsnuuuuuuuuuuiteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      5.»‘‡£¢°†üûùúõöôòóñ˜ﬁìíëêèéçåãäâàáÜÖÑÉÇÅÄπÛ…·Ù˛∏’‹ø±∆™ˆœÆµº˙«¬©¡ïî˘®Ÿ¨`≈^¸À˝Z´√ª∂€∑Q˚—ˇÊÏ §Ú‰Ò¿≠ßÂ◊÷›?ÁÌŒÓ¥ﬂ“Ã}≥ÿÈ⁄Õ”„≤∫ΩÔ¯¶æƒ#∞–•‚YÍËÎØU9ııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııııX777777777777777777777777777777777777777777777777777888888888888888888888888888888888888888888888884JJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRH6_____________________________________________W**********************************~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~z3
K!@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@j{GEEEEEEEEEEEEEEEEEEEEEEEE=]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]O[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[2>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>B;Lx''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<VP|&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvIccccccccccccccccccccccbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbg/)))))))))))))))))))))))))))))A$DMNwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww	FFFFFFFFFFFFFFFFFFFFF+CCCCCCCCCCCCCCCCCCCCCCCCCCCCy1TTTTTTTTTTTTTTTTTTTTTTTTT0-kaf,SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSdmrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrh"::::::::::::::::::::npppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppleeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeisssssssssssssssss ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettran%%%%%%%%%%%%%lllllllllllllllllllllllllisoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                                                            ttttttttttttttttttfd(cccccccccccccccc%mmmmmmmmmmmmmmmmmh"::::::::::::::::::::ppppppppppppppanrrrrrrrrrrrrrrrrrrrrrrrlesssssssssssssssssssssuiiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooontssssssssssssssaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrrrul eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.................................................................................gb))))))))))))))))))))))))))A/DDDDDDDDDDDDDDDDDDDDDDDDDDDDDw$I\%+++++++++++++++++++++++++++	F111111111111111111111CCCCCCCCCCCCCCCCCCCCCCCCCCCC-yTTTTTTTTTTTTTTTTTTTTTTTTT,0nddddddddddddddddddcfffffffffffffffffff(ka""""""""""""""""mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhusssssssssssssstirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr::::::::::loeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                   aaaaaaaaaaaaausnetiiiiiiiiiiilrrrrrrrrrrrrrrrrr            pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeood%cccccccccccccccccccccccccccccccccccccccccccccccccc"fmSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSaaaaaaaaaaaaausntilrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepheeeeeeeeeeeeeeeeeeee                                            uoiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnertttttttttt:llllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee                                                         .55555555555555555555555555555555555555555=!+++++++++++++++++++++++++++++++++++++++++++E]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]OB[2>'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''';LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx&<VPM||||||||||||||||||||||||||||||||||||vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvdggggggggggggggggggggggg))))))))))))))))))))))AbDDDDDDDDDDDDDDDDDDDDDDDDDDw/IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII$m1\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\	-FFFFFFFFFFFFFFFFFFFFFC,,,,,,,,,,,,,,,,,,,,,,,,,,,,yT(((((((((((((((((((((((((uuuuuuuuuuuuuuuuuuuc"""""""""""""""%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%fS00000000000000000000ppppppppppppppppriaooooooooooooooooooooooosssssssss:::::::::::::::::n eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaahriullllllllllllllsoooooooooonnnnnnnnnnnneeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                                                                                  ma"""""""""""""""""""%cdddddddddddddddippppppppppppppppppfk::::::::::::::::::::shhhhhhhhhhhhhhhhrrrrrrrrrrrrreulllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiasssssssssssssssssrrrrrrrrrrrrrulnnnnnnnnnnnnnntttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                            1.+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++)gAAAAAAAAAAAAAAAAAAAAAAADDDDDDDDDDDDDDDDDDDDDDwbIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII//////////////////////////////////////////////////////////p-$NNNNNNNNNNNNNNNNNNNNNNNNNNN,	FFFFFFFFFFFFFFFFFFFFF(CCCCCCCCCCCCCCCCCCCCCCCCCCCCySTTTTTTTTTTTT%"dddddddddddddddddddmccccccccccccccccccccccccccccccccccccccccccccccccfkkkkkkkkkkkkkkkkkkkkkkkkk::::::::::::::::::::hlasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeuuuuuuuuuuonnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttssssssssssssssssssssssssslaaaaaaaaaaaaaaaaaaaaaaaaairrrrrrrrrooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetunnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepsd%m"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""a0cccccccccccccccccccccccccccccccccccccccccccccccccccfoooooooooooooollllllllllllnirrrrrrrrrrrrrrrr::::::::::::::::::::::teeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      larooooooooooooooseeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii uhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeett@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@444444444444444444444444444444444444444444RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666H*_~W3333333333333333333333333333333333qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq
B{KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK55555555555555555555555555555555555555555=!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]OEM2>''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''G;L[.&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVx<A\P||||||||||||||||||||||||||||||||||||1w)g++++++++++++++++++++++++DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD-IIIIIIIIIIIIIIIIIIIIIIIIIIb,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,/(Nvvvvvvvvvvvvvvvvvvvvvvvvvvv$SFFFFFFFFFFFFFFFFFFFFF																	CCCCCCCCCCCCCCCCCCCCCCCCCCCCdkymppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp%0T""""""""""""""""""""""""""""""""""""""""""""""""""""ccccccccccccccccccccccccccccccccclaroooooooooooooossssssssssssnnnnnnnnnnnnniuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeehfeeeeeeeeeeeeeeeeeeee                                            otnarllllllllllllllllllllllllseiiiiiiiiiiiiiiiiiiiii::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuudooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooommmmmmmmmmmmmmmmmmmmmmmmmppppppppppppppppp%rrrrrrrrrrrrrrrr""""""""""""""""""""""""""""""""""""""hcinattttttttttllllllllllllllllllllll::::::::::::::::::s eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeearfinooooooooooooollllllllllllllttttttttttsueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                  .AAAAAAAAAAAAAAAgwwwwwwwwwwwwwwwwwwwwwwww))))))))))))))))))))))+-DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD,I1bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb/(((((((((((((((((((((((((((((((((((((((((((((((((((($SkF	C0000000000000000000000000000aaaaaaaaaaaaaaaaaaaaaaaaayyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyymdpnh%""""""""""""""""""":::::::::::::::::::::::::::::::::fcireoooooooooooooooooooooooslllllllllllllllll            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuunaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaairoooooooooooooslllllllllllllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                            hhhhhhhhhhhhhhhhuuuuuuuuuuuuuuuuuTdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddmmmmmmmmmmmmmmmmmmp%"""""""""""""""""""::::::::::::::::::::fffffffffffffaaaaaaaaaaaaaannnnnnnnnnnirelooooooooootssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee                                                                      ulllllllllllllaccccccccccniiiiiiiiitr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeossssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.........................................B!5555555555555555555555555555555555555555555555555555555555555=========================================================================O]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>EML2''''''''''''''''''''''''''''''''''''''''''''''''''''V;[&\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\xN<P|||||||||||||||||||||||||||||hhhhhhhhhhhhhhhhhhhhhhhhggggggggggggggggggggggw-))))))))))))))))))))))))))+,D11111111111111111111111AIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb/k((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((($0SF																									CCCCCCCCCCCCCCdddddddddddddddddddddddddddddddTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTaaaaaaaaaaaaaaaaaaamp%%%%%%%%%%%%%%%%%%%%"tlllllllllllllusnic::::::::::rrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                                  aitlllllllllllllleusssssssssssrnnnnnnnnnnnnnnnnn offffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeddddddddddddddddddddddddddddddddhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhyppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppmc%%%%%%%%%%%%%aitllllllllllllllusrnoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef"eeeeeeeeeeeeeeeeeeee                                            ttttttttttttsaiiiiiiiiiiiiiiiiiiiiiiillllllllllllllenuuuuuuuuuu:rrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo...........................ddddddddddddddddddddddddddddddddddddddddddddd-ggggggggggggggggggggggggggw,)1+ADDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDpkIbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb0/(vvvvvvvvvvvvvvvvvvvvvvvvv$SFT	tttttttttttttttttttttttttttttttttttttttttttttttthhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhicyCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCfmnsaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaalllllllll:%%%%%%%%%%%%%% eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeourrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeai"nstrrrrrrrrrrrrrlllllllllllllllllllllllllllllllllloeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      cpaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadhsffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff::::::::::::::::::::l"mnietrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoosal%nitrrrrrrrrrrrrrrrrrrrrrrrrrruuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            ......................................................YU9}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}X777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777788888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888888884@~6666666666666666666666666666666666666666666666R*_H{3333333333333333333333333333333333WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!BkO5===========================================>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLEVM2'\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\j;[N&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&x<PPPPPPPPPPPPPPPPPPPPPc----------------------------------------------------------------------,g1wA)))))))))))))))))))))))))))))+++++++++++++++++++++++++++Df00000000000000000000000Ibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb/(Tv|$SyFooooooooooooooooooooooooooooooooooooddddddddddddddddppppppppppppppp%hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh																																																													::::::::::::::::::::"ralsssssssssssnieeeeeeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuulooooooooooooorammmmmmmmmmsnnnnnnnnnnnnnnnnnnnni eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%flddddddddddddddddddpppppppppppppppppppccccccccccccccccaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhCCCCCCCCCCCCCCCCCCCCCCCCroooooooooooooosnm::::::::::iueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      rannnnnnnnnnnnnnnnnnnnnnnnleooooooooooooooooooooooooisssssssssssssssss t"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""" eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuu.k1----------------------------------------------------------------------,gggggggggggggggggggggggg0A)wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwD+TIbbbbbbbbbbbbbbbbbbbbbbby/((((((((((((((((((((((((((((((%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%$ddddddddddddddddddddddddddddSpfcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccchhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmmmmmmmmmmmmmmmmmrannnnnnnnnnnnnnnnnnnnnnnnlooooooooooooooistttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee"CFeeeeeeeeeeeeeeeeeeee                                                       uuuuuuuuuuuuuuanrrrrrrrrrrrrrrrrrrrrrrrlesoooooooooo:iiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee tttttttttttttttttttttttttttttttttttttttttttttthddddddddddddcpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppf%%%%%%%%%%%%%%%%%%nmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm"""""""""""""""ssssssssssssssauuuuuuuuuurrrrrrrrrrrrrrrrrrrrr:::::::::::::::::l eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetoiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeean	sssssssssssssssssssssssssirrrrrrrrrrrrruuuuuuuuuulteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      ...................................!OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOD>B5=LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL]VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV\EM2N'G;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;[&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvx<<<<<<<<<<<<<<<<<<<<<<<<<<hhhhhhhhhhhhhhhhhhhhhh11111111111111111111111111111-ggggggggggggggggggggg0,))))))))))))))))))))))))))))))))))))))))))))))))Akwmbbbbbbbbbbbbbbbbbbbbbbbbbbb+T(IIIIIIIIIIIIIIIIIIIIIIIyyyyyyyyyyyyyyyyyyyyyyyyyyyy/////////////////////////////////////////////////////////////////PC$aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaac%pdffffffffffffff"""""""""""""""""""""""""""""""""""""""""""""""""""::::::::::::::::::::::::::::::::	SSSSSSSSSSSSSSSsneeeeeeeeeeeeiiiiiiiiiiilrrrrrrrrrrrrrrrrr ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetttttttttttttttaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnnnnnnnnnnnnilroooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                            "mt%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%dchpppppppppppppppppfffffffffffffffffffffffffffffffffffffffffffffffffff::::::::::::::::::::Fiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnerrrrrrrrrrrrrrrrrrrrrullllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooooooooooooootriaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssssun eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooollllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeb.D""""""""""""""""""""""""""""""""""""""""""""""""""g10-))))))))))))))))))))))))))))))))))))))))))))),kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkAAAAAAAAAAAAAAAAA(wwwwwwwwwwwwwwwwwwwwwwwwwww++++++++++++++++++++++++++++TIIIIIIIIIIIIIIIIIIIIIIICy//////////////////////////////	|||||||||||||d%hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmcaaaaaaaaaaaaaaaapfffffffffffffffffffffffffffffffffffffffffffffffffffffffuritllllllllllllllsssssssssssssss::::::::::noeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      iasurrrrrrrrrrrrretlllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn            F$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoodddddddddddddddddh"m%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%fccccccccccccccccccccppppppppppppppppppppppppppppppppiasurrrrrrrrrrrrrtlnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeSSSSSSSSSSSSSSSSSSSeeeeeeeeeeeeeeeeeeee                                            uolasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeetttttttttt:nnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee                                                         .4444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444_~6@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*R
{3HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWzKOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO>!(LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLB5V=========================================================================\]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNEMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM2'GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGv;[&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&xbdggggggggggggggggggggggggggggg0000000000000000000000)1111111111111111111111111-kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk,DDDDDDDDDDDDDDDDDDDDDDDDffffffffffffffffffffffffffffAwwwwwwwwwwwwwwwwwwwwwwwwwwwC+TI																							y/FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFumhhhhhhhhhhhhhhhh"""""""""""""""""%sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssccccccccccccccccccccS|<pppppppppppppplaooooooooooirrrrrrrrr:::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeassssssssssssssssssssssssssssssssluniroooooooooooooooooooooooooooooooooeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                                    faaaaaaaaaaaaaaaammmmmmmmmmmmmmmmmhd"l$%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%c::::::::::::::::::::rrrrrrrrrrrrrrrrrrrppppppppppppppseunnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeelarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrsunnnnnnnnnnnnnitttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                                                       .(((((((((((((((0g))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))k11111111111111111111111111-DDDDDDDDDDDDDDDDDDDDDb,$$$$$$$$$$$$$$$$$$$$$$$$AwwwwwwwwwwwwwwwwwwwwwwwwwwwC+TI																							y/FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSdmfhhhhhhhhhhhhhhhhhh"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%c::::::::::::::::::::::::::::::::::::::narllllllllllllllllllllllllseiuuuuuuuuuuoooooooooooooooooooooooooooooooooooooooo                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttrrrrrrrrrrrrinappppppppppllllllllllllllllllllllos eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeerdddddddddddddddddffffffffffffffffPmach"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%oinnnnnnnnnnnnnnnnnnnnnnnnllllllllllllllp::::::::::steeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      naaaaaaaaaaaaaaoireeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeslllllllllllllllll uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeett\OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO>!LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLB5V==============================================================================================================================================================================================================================NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNEM].v'[j2;)|&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&k0g(DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD$$$$$$$$$$$$$$$$$$$$$$$$$$-111111111111111111111111111b,,,,,,,,,,,,,,,,,,,,,IAwwwwwwwwwwwwwwwwwwwwwwww/+TCCCCCCCCCCCCCCCCCC																							ddddddddddddddddddddddddddddddyfffffffffffffffPxFFFFFFFFFFFFFFFFFcccccccccccccccc"mmmmmmmmmmmmmmmmmmmmhp%naaaaaaaaaaaaaaoirrrrrrrrrrrrrrrrrrrrrrrrsluuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            otttttttttttttaaaaaaaaaaaaaannnnnnnnnnnirelllllllllllllllllllll:ssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu"doSfcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccppppppppppppppppmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmhlllllllllllllattttttttttniiiiiiiii:%r eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuussssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaalllllllllllllosnittttttttttrueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      ,.)"gkD0000000000000000000000($$$$$$$$$$$$$$$$$$$$$$$$$-----------------------------------------------------------------------------------------------------------1pwbbbbbbbbbbbbbbbbbbbbbITAAAAAAAAAAAAAAAAAAAAAAAA//////////////////////////////+C	<<<<<<<<<<<<<<<<<<<<<<<acSyyyyyyyyyyyyyyyyyyfddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddm::::::::::::::::::::iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiihlllllllllllllleosssssssssssrnnnnnnnnnnnnnnnnn            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuai%llllllllllllllosrnnnnnnnnnnnnnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                                              puuuuuuuuuuuuuuuuuucdF"f%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%m::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::saiiiiiiiiiiiiiiiiiiiiiiillllllllllllllenooooooooootrrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee                                                         iunsahhhhhhhhhhhhhhhhhhhhhhllllllllltttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeorrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqYU9}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX                                                   8777777777777777777777777777777777777777777777776666666666666666666666666666666666666666666666666666666666666666666666666666666666666666664*_~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~3333333333333333333333333333333333@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
{RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRH\WzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzGK!Ow5>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLBV============================================================================================================================================================MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN[E]v|'jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj2P;&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&,,,,,,,,,,,,,,,,,,,Dggggggggggggggggggggggk$0-(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((())))))))))))))))))))))))))%T1bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbIAAAAAAAAAAAAAAAAAAAAAAAA<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<</+CS	idddddddddddddddddd"cpFFFFFFFFFFFFFFFFFFFFFFFamffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffftnsurrrrrrrrrrrrrlh::::::::::::::::::::::::::::::::::eeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      saltnieurrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeed%"""""""""""""""""""ppppppppppppppppppmcccccccccccccccyyyyyyyyyyyyyyyyyyyyfhhhhhhhhhhhhhhhhhsaltniurrrrrrrrrrrrrrrrrrrrrrrrrroooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            ttttttttttttralsssssssssssnieeeeeeeeeeeeeuuuuuuuuuu:::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooT.wddddddddddddddddddddddD$g-kkkkkkkkkkkkkkkkkkkkkkkkkkk0000000000000000000000000000())))))))))))))))))))))))),,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,1bxxxxxxxxxxxxxxxxxxxxxIASSSSSSSSSSSSSSSSSSSSSSSS/+FCtp"mmmmmmmmmmmmmmmmmmm%%%%%%%%%%%%%%%%%%lhcy																																																																																fffffffffffffraaaaaaaaaaaaaaaaaaaaasnnnnnnnnn:::::::::::::::::i eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeallllllllllllllllllllllllllllrttttttttttttttsnnnnnnnnnnnnnnnnnnnnnioeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                      hhhhhhhhhhhhhhhamp%"dddddddddddddddddddrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrccccccccccccccccccccccc::::::::::::::::::::nnnnnnnnnnnnnnnnffffffffffffflettttttttttttttttttttttttisssssssssssssssss uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoorannnnnnnnnnnnnnnnnnnnnnnnnnnnnlttttttttttttttisuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            .!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!5\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\O>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLBVM===================================================================================[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[N||||||||||||||||||||||||||||||||||||||||||||E]Pv''''''''''''''''''''''''''''''''''''''''<2;&Th$$$$$$$$$$$$$$$$$$$$$$-DDDDDDDDDDDDDDDDDDDDDDDDDDDggggggggggggggggggggggggggggk)0,(wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx1SbbbbbbbbbbbbbbbbbbbbbIFAAAAAAAAAAAAAAAAAAAAAAAA/y+o%mdppppppppppppppp""""""""""""""""""""""""""""""""""""""""""""""""""""cccccccccccccccccccccccC::::::::::::::::::::::::::::::::::::::::::::::::anrrrrrrrrrrrrrrrrrrrrrrrlestttttttttttttttttttttiiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuunossssssssssssssaffffffffffrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrl eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeend%%%%%%%%%%%%%%%mhpa	"""""""""""""""""""""""""""""""""""""""""""""""""""""""ccccccccccccssssssssssssssoirrrrrrrrrrrrrf::::::::::lueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                                   aaaaaaaaaaaaaaaaaaaaaaaasneoiiiiiiiiiiilrrrrrrrrrrrrrrrrr ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuu-.........................................................$$$$$$$$$$$$$$$$$$$$$$T,,,,,,,,,,,,,,,,,,,,,,,,,,,gDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD)0kSwwwwwwwwwwwwwwwwwwwwwwwww(FFFFFFFFFFFFFFFFFFFFFFFFFF11111111111111111111111111111yyyyyyyyyyyyyyyyyyyyyIbbbbbbbbbbbbbbbbbAAAAAAAAAAAAAAAAAAAAAAAAddddddddddddddddddddddd///////////////////////////////////////////////////////////////////////////h%	+mmmmmmmmmmmmmmmmmmmpppppppppppppppppppp"fffffffffffffffffffffffffffffffaaaaaaaaaaaaaaaaaaaaaaaasnoilrtttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeceeeeeeeeeeeeeeeeeeee                                                       uiaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasneroooooooooo:llllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttddddddddddddhhhhhhhhhhhhhhhCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC%%%%%%%%%%%%%fmppppppppppppppppppppppppppppppppppp"riauuuuuuuuuuuuuuuuuuuuuuusssssssss::::::::::::::::::n eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetollllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaacriiiiiiiiiiiillllllllllllllsuuuuuuuuuunteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      .............................................~666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666*_4{3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333
@GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGR!HW5jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj\O>MLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLB[V===========================================||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||PNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNE<]v'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxK2;-------------------------------------------------------------------,$gTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT&&&&&&&&&&&&&&&&&&&&&&&&&&&0DS))))))))))))))))))))))))))))))kf1w(FIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyybA																								aC/hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddiiiiiiiiiiiiiiii%mp::::::::::::::::::::sc"rrrrrrrrrrrrreeeeeeeeeeeelllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettiassssssssssssssssssrrrrrrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnnnnnoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                                           fttttttttttttttttt+dhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh%mp::::::::::::::::::::clasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeunnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooosttttttttttttttla""""""""""irrrrrrrrruuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooonnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee1........................................,,,,,,,,,,,,,,,,,,,,,,gggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg$0TSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSD-))))))))))))))))))Ikw(((((((((((((((((((((((FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF	yyyyyyyyyyyyyyyyyyyyybCAsddddddddddddddddddddddddddddddddddd++++++++++++++++++++++++fhappppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp%%%%%%%%%%%%%%%%%%%%muuuuuuuuuuuuuultnir"::::::::::::::::::::::oeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      laruuuuuuuuuuuuuusetnnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii            cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoodddddddddddddddddddddddddddddddddddddddddddddddddddfffffffffffffffffp/////////////////////////////////////////////////////////////hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh"%laruuuuuuuuuuuuuustnnnnnnnnnnnnniiiiiiiiiiiiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeecmeeeeeeeeeeeeeeeeeeee                                            uonarllllllllllllllllllllllllseitttttttttt::::::::::::::::::::::::::::::::::::::::                               eeeeeeeeeeeeeeeeeee                                                         ...............................555555555555555555555555555555555555555!IMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM\O[>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL|BV=PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNxE]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv'''''''''''''''''''''''''''''''''''''''''''''''''''''''21dg,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;;;;;;;;;;;;;;;;;;;;;;0000000000000000000000000000S$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$T---------------------------------------------------DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD)kw	(FFFFFFFFFFFFFFFFFFFFFFFFFFCCCCCCCCCCCCCCCCCCCCCCCCCCCCCyyyyyyyyyyyyyyyyyyyyy+bufffffffffffffffffffpppppppppppppppppppppppppppppppppppppppppppppppppr"/Ahhhhhhhhhhhhhhhhhhhhcccccccccccccccinaoooooooooollllllllllllllllllllll:%s eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeearminuuuuuuuuuuuuulllllllllllllloooooooooosssssssssssseeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      """""""""""""""""""""""""""""""""""""""""""""""""""""""""""""apffffffffffffffffffffffffffffffffffffddddddddddddddddncccccccccccccccccccccccccccccccccccccccch:::::::::::::::::::::::::::::::::mmmmmmmmmmmmmmmireuuuuuuuuuuuuuuuuuuuuuuuslllllllllllllllll toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeenaaaaaaaaaaaaaa%iruuuuuuuuuuuuusltttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeeeeeeeeeeeeeeeeee                                                                  .I"&g0,SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS-$$$$$$$$$$$$$$$$$$$$$$$$$T111111111111111111111111111c	D)kCw(F++++++++++++++++++++++++++++++++++++++++++++++++++++++y/////////////////////////////////////////////////pdfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%bh::::::::::::::::::::mmmmmmmmmmmmmaaaaaaaaaaaaaannnnnnnnnnnireluuuuuuuuuuossssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttlllllllllllllaaaaaaaaaaaaaaaaaaaaaaaaniiiiiiiiior eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetussssssssssssssssss eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee%ccccccccccccccddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddp"fahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhAollllllllllllllllllllllllsniiiiiiiiiiiiiii::::::::::rteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                  aiolllllllllllllleeeeeeeeeeeesssssssssssrnnnnnnnnnnnnnnnnn ummmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttYq99999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}X7Jz888888888888888888888888888888888888888888888~6666666666666666666666666666666666666666666666M_{**********************************44444444444444444444444444444444444444444444444443









































GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG@|jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjRHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH555555555555555555555555555555555555555!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!W<\O[>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLV=PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPB.xN]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]E000000000000000000000000000000000v'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''&2gIIIIIIIIIIIIIIIIIIIIIIIIISSSSSSSSSSSSSSSSSSSSSS,	-$$$$$$$$$$$$$$$$$$$$$$$$$$$$C111111111111111111111111111T+)kD/(Fw%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%ddddddddddddddddddddddddyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyc""""""""""""""""""hppppppppppppppppffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffaiolllllllllllllllllllllllllsrnuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeemAAAAAAAAAAAAAAAAAAAAAeeeeeeeeeeeeeeeeeeee                                            otsaiiiiiiiiiiiiiiiiiiiiiiillllllllllllllennnnnnnnnnnnnnnnnnnnn:rrrrrrrrrrrrrrrrrrrrrrrrrrrr                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuudo"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""hc%%%%%%%%%%%%%%%%%%iiiiiiiiiiiiiiipffffffffffffffffffffmmmmmmmmmmmmmmmmmmmnsattttttttttttttttttttttlllllllll:::::::::::::::::::::::::::::: eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuurrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeaibnsorrrrrrrrrrrrrltttttttttttttttttttttttueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                .0000000000000000gggggggggggggggggggggggggggggggggggggggggggggggggggggg;;;;;;;;;;;;;;;;;;;;;;I	S$,C----------------------------------------------------------------k1T+F)D////////////////////////(wwwwwwwwwwwwwwwwwwwwwwwwwwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAah"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%dcsmmmmmmmmmmmmmmmmmmpf::::::::::::::::::::lbyyyyyyyyyyyyyyyyyyynieorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr            tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuusalllllllllllllllllniorrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeteeeeeeeeeeeeeeeeeeee                                            mmmmmmmmmmmmmmmu%hd""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""ccccccccccccccccccpf::::::::::::::::::::::::::::::::::::::::ralsssssssssssnieeeeeeeeeeeeeoooooooooottttttttttttttttttttttttttttttttttttttttt                               eeeeeeeeeeeeeeeeeee                                                         luuuuuuuuuuuuuraaaaaaaaaaaaaaaaaaaaaaaaaaaasnnnnnnnnnti eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.5|!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!kOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOM<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\[>=LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLVPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]BxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN&Ev'''''''''''''''''''''''''''mmmmmmmmmmmmmmmmmmmmmmmmmggggggggggggggggggggggggggggggggggggggggggggggggggg	;K$ICSSSSSSSSSSSSSSSSSSSSSSS,0-----------------FFFFFFFFFFFFFFFFFFFFFFFFFFFF1TTTTTTTTTTTTTTTTTTTTTTTT+)DA/(wbbbbbbbbbbbbbbbbbbbbbbbbbbld%%%%%%%%%%%%%%%%hhhhhhhhhhhhhhh"afffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffcccccccccccccccccccccccccccccccccccccptttttttttttttruuuuuuuuuuuuuusnnnnnnnnnnnnnnnnnnn::::::::::iiiiiiiiiiiieeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      rantttttttttttttleuuuuuuuuuuuuuuuuuuuuuuuuisssssssssssssssss oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeddddddddddddddddddddddddddddddddmmmmmmmmmmmmmmm%fhc"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""rantttttttttttttluuuuuuuuuuuuuuisoooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeypeeeeeeeeeeeeeeeeeeee                                            tttttttttttttttttttttttttanrrrrrrrrrrrrrrrrrrrrrrrlesuuuuuuuuuu:iiiiiiiiiiiiiiiiiiiiiiiiiiii                               eeeeeeeeeeeeeeeeeee ooooooooooooooooooooooooooooooooooooooooooooooF.kdddddddddddddddddddddddddddddddddddddddddddddd	g$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$C22222222222222222222222I0SSSSSSSSSSSSSSSSSSSSSSSSSSS,cccccccccccccccccccccccc----------------------------1AT+)bD/(((((((((((((((((((((wttttttttttttttttttttttttttttttfmmmmmmmmmmmmmmmmm%nnnnnnnnnnnnnnnnnnnh""""""""""""""""""""yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyssssssssssssssaaaaaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrrr::::::::::::::::::l eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeouiiiiiiiiiiiiiiiiii eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeanpsssssssssssssstirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrloeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                        caffffffffffffffffffffffffffffffffffffffffffffffdmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%h"::::::::::::::::::::::::::::::::pppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppsnetiiiiiiiiiiilrrrrrrrrrrrrrrrrr uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoooooooooooooooaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasntilruuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                            .6{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~_GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG4*j









































333333333333333333333333333333333333333333333333333333333333333333333333333333333333333@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@5555555555555555555555555555555555555555555555555555R!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!HO|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||M=<\[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]VPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPB&xNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;EvFFFFFFFFFFFFFFFFFFF																						$$$$$$$$$$$$$$$$$$$$$$$$$Cgggggggggggggggggggggggggggggggggggggggggggggggggggg02'''''''''''''''''''''''''''IkSSSSSSSSSSSSSSSSSSSSSSSSSSSSS,----------------------------1AT+)bD/(((((((((((((((((((((wyooooooooooooooooofdddddddddddddddcccccccccccccccccccccccccccccccccm%h"::::::::::::::::::::piaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasnertttttttttttttttttttttllllllllllllllllllllllllllll                               eeeeeeeeeeeeeeeeeee uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuoriaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaassssssssssssssssssssn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeutllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeedddddddddddddddddcffffffffffffffffffffffffffffffffffffffffa""""""""""""""""m%%%%%%%%%%%%%%%%%%%%hhhhhhhhhhhhriollllllllllllllsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss::::::::::nueeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttt                      iassssssssssssrrrrrrrrrrrrreolllllllllllnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn tpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuu$..............................................																						FFFFFFFFFFFFFFFFFFFFFFFFFFFCggggggggggggggggggggggggggggggggggggggggggggggggggggg0KWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW1kSI)----------------------------,(T+AAAAAAAAAAAAAAAAAAbDdw/cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc"fmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%iassssssssssssrrrrrrrrrrrrrolnnnnnnnnnnnnnntttttttttttttttttt eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeepheeeeeeeeeeeeeeeeeeee                                                       ulasiiiiiiiiiiirrrrrrrrrrrrreeeeeeeeeeeeeeoooooooooo:nnnnnnnnnnnnnnnnnnnnnnnnnnnn                               eeeeeeeeeeeeeeeeeee ttttttttttttttttttttttttttttttttttttttttttttttmddddddddddddyc""""""""""""""""""""""""""""""""""""""""""""""""""""sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssffffffffffffffffffffffffffffffffffppppppppppppppppppppppppppppplauuuuuuuuuuirrrrrrrrr:%%%%%%%%%%%%% eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetonnnnnnnnnnnnnnnnnn eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeashhhhhhhhhhhhhhllllllllllllniruuuuuuuuuuuuuuuuuuuuuuteeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeoooooooooooooooooooooooooooo                      .O!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!5S=||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||M<\][>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLV&PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP;BxN22222222222222222222222222222222222222222222222222222222222222222222222222222222E$mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm	gFFFFFFFFFFFFFFFFFFFFFFFFFFFFFCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCvvvvvvvvvvvvvvvvvvvvvvvvv100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000kI)+-,(wTAbbbbbbbbbbbbbbbbbbbbbbbbbbDa"y//////////////////cdddddddddddddddddddlpppppppppppppppppfffffffffffffff::::::::::::::::::::rhhhhhhhhhhhhhhhhhhhhhhhhhhhhhseeeeeeeeeeeennnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiii ouuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettlar%%%%%%%%%%%%%%ssssssssssssnnnnnnnnnnnnnioooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeueeeeeeeeeeeeeeeeeeee                                            ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppptttttttttttttttttt"dddddddddddddddddddddmc%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%fffffffffffffff::::::::::::::::::::hnarllllllllllllllllllllllllseiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               eeeeeeeeeeeeeeeeeee oooooooooooooooooooooooooooooooooooooooooooooortinaaaaaaaaaaaaaaaaaaaaaaaaallllllllllllllllllllllus eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeooooooooooooooooooooooooooooooooooooooooo eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee.Sppppppppppppppppppppppppppppppppppppppppppppppppggggggggggggggggggggggggggggggggggggggggggggggggggg	'F1CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC$0%++++++++++++++++++++++++++++++kIw)-,,,,,,,,,,,,,,,,,,,,,,,,,,(TAybrddddddddddddddddddm"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""Daaaaaaaaaaaaaaaccccccccccccccccccccccccccccccccccccccccccccccccccccccfuintttttttttttttlllllllllllllllllllllllllllll::::::::::soeeeeeeeeeeeeeeeeeeeeee                                           eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                      naaaaaaaaaaaaaauiretttttttttttttttttttttttslllllllllllllllll            hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeood%mpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp"""""""""""""""""""////////////////////ccccccccccccccccccccccccccccccccnaaaaaaaaaaaaaauirtttttttttttttslllllllllllllllllllllllllllll eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeehfeeeeeeeeeeeeeeeeeeee                                            uoooooooooooooaaaaaaaaaaaaaannnnnnnnnnnireltttttttttt:ssssssssssssssssssssssssssss                               eeeeeeeeeeeeeeeeeee                                                         5555555555555555555555555555¡»‘‡£¢°†üûùúõöôòóÒ˜ﬁìíëêèéçåãäâàáÜÖÑÉÇÅÄπÛ…·Ù˛∏’ƒø±∆™ˆœÆµº˙«¬©ñïî˘®Ÿ¨`≈^¸À˝Z´√ª€∑Q˚—ˇÊÏ §Ú‰‹¿≠ßÂ◊÷›?ÁÌŒÓ¥ﬂ“U„≥ÿÈÔÕ”⁄∂∫Ω≤#¶æ¯–∞••••••••••••••••••••••••••••••••••••••••••••••••••••••••••Í‚ÃËÎJØ ıqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX_9999999999999999999999999999999999999999999999999997z666666666666666666666666666666666666666666666666666666666666666666666666666666666666666668~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
{4*RGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG3Wj@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOH++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=|\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ML<][V>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>&PNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN;BEx22222222222222222222222222222222222222222222'''''''''''''''''''''''''''''''''''''/SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSggggggggggggggggggggggggggggggggggggggggggggggggggg	F1CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC$0."wk-IIIIIIIIIIIIIIIIIIIIIIIIII)T,y(((((((((((((((((((((AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAb:%mppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaahcccccccccccccccccccccccccccccccccccrooooooooooooouuuuuuuuuuuuniiiiiiiiiiiiiielttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                     eeeeeeeessssssssssss                                                raaaaaaaaaaaaaffffffffffffoiulnnnnnnnnnnneeeeeeeessssssssssssss                                                    eeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttt                       "rm:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::%Dpppppppppppphhhhhhhhhhhhhhhhhhdddddddddddddddddddddddddddddddddddddddddddddddddddddlllllllllllllfcaeoitunssssssssssssssssssssssssssssssss                                                  e                                                                                                    tlllllllllllllrrrrrrrrrrao niiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeessssssssssssssssssss0000000000000000000000000000+++++++++++++++++++++++++++++++++++++++++/gSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSFFFFFFFFFFFFFFFFFFFFFFFC																									1vvvvvvvvvvvvvvvvvvvvvvvvh-$.wTkIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII),yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy(((((((((((((((((m:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::%DAp"""""""""""""""""""""""""""""""dffffffffffffffffffffffffffffffffffffffffffffffffffffntllllllllllllllllllllraaaaaaaaaaaaaaaaaaaaaaaoe      siiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               llllllllllllllllllllllllllntceeeeeeeeeeeeruaosssssssssssssssssssssssssssssssssssssssssssssssssssssssssss                     eeeeeeeeiiiiiiiiiiii                                                :hpppppppppppppppppmmmmmmmmmmmmmmmf%bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbl"""""""""""""""""""""""""""""""""""""""""""""""""dttttttttttttttttttttttttnuccccccccccccccccorrrrrrrrrrreeeeeeeeia                                                    eeeeeeeeesssssssssssssssssssssssssssssssssssssssssssssssssssss                                 otttttttttttttlenussssssssssssssssssssriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                  e aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!5-\KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK=L||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||VM<]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]][>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN&EPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP;'Bx20:ggggggggggggggggggggggggggggggggggggggggggggggggggggggg/FSCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv	+1bbbbbbbbbbbbbbbbbbbbbbbb$.wTkIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII),yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy(DDDDDDDDDDDDmpfffffffffffffffffhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%"cccccccccccccccccccsotttttttttttttttttttttttln ruuuuuuuueeeeeeeeeeeeeeeeeeeeeeaaaaaaaaaaaaaaaaaaaaddddddddddddddddddddddddddddddddddddddd                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiitttttttttttttrsooooooooooooooooooooooooooooooooollllllllllane      iuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                :tfmhpAAAAAAAAAAAAAAAAAoccccccccccccccc%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%"arssssssssssssseeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeelniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                     eeeeeeeeuuuuuuuuuuuu                                                aosttttttttttttrdddddddddddddnnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeul                                                    eeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii         bbbbbbbbbbbbbbbbbbbbbbbbbbbb----------------------------------------------gFFFFFFFFFFFFFFFFFFFFFFFFFFFC/////////////////////////SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS+++++++++++++++++++++++0	cw111111111111111111111111$$$$$$$$$$$$$$$$$$$$$$$$$$.TkyIIIIIIIIIIIIIIIIIIIII)(,ahfAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAm:ppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppp%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%nstoerd"iiiiiiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                                  e llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllttttttttttttinsaaaaaaaaaaor                                       eeeeeeeeeeeeeeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuctDh:ffffffffffffffffffmsssssssssssssssspppppppppppppppppppppppppppppppd%%%%%%%%%%%%%%innnnnnnnnnnnnnnnnnnnaoooooooooolre      uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                               nslllllllllllllliteeeeeeeeeeeeaaaaaaaaaaaaaoruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                     eeeeeeee""""""""""""                                                \______________________________________________________________________________N
66666666666666666666666666666666666666666666666~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~{RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR4W*GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG3j@O!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL=V|<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<M>]KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK[[[[[[[[[[[[[[[[[[[[[[[[[EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE'&PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPv;BxbwwwwwwwwwwwwwwwwwwwwwwwwwwwwwgFFFFFFFFFFFFFFFFFFFFFFFFFFFC/-yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy2222222222222222222222+++++++++++++++++++++++0	SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSST$1.:(kIIIIIIIIIIIIIIIIIIIIIA))))))))))))))))D,hcddddddddddddddddddmfnppppppppppppppppplllllllllllllllllllllllllllllllllissssssssssssssssssssssssssssssssssssstraaaaaaaaaaaeeeeeeee"%o                                                    eeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                    lrisneeeeeeeeeeeeeeeeeeeeeeeeeeutaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                  e oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooom::::::::::::hhhhhhhhhhhhhhhhdddddddddddddddddddddddddddddddddddddddddddddddddcssssssssssssssssssssssssssssssssssssfp"""""""""""""""""urillllllllllnnnnnnnnnnnnnn aaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeottttttttttttttttttttttttttttttttttttttt                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeisaurrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnooooooooooooooe      %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%eeeeeeeeeettttttttttttttttttttttttttttttttt                               																																																				mgwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww/FyCCCCCCCCCCCCCCCCCCCCCC------------------------------------------------------------------b+++++++++++++++++++T0SSSSSSSSSSSSSSSSSSSSSSSSSS(((((((((((((((((((((((($1A.kIDDDDDDDDDDDDDDDDDDDDDidhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh::::::::::::::::::::::::::::::)r"ccccccccccccccccccfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffpoauseeeeeeeeeeeeltnnnnnnnnnnnnnn%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                oruiiiiiiiiiiiiatssssssssssssssllllllllllleeeeeeeeeeeeeeeeeeeen                                                    eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee         """""""""""""""""""ooooooooooooooooooood:hmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm,cccccccccccccccccc%ffffffffffffffuireatttttttttttttttpsllllllllllllllllllllllllllllllllllllllllllll                                                  e nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiuoooooooooora ltttttttteeeeeeeeeeeeeeeeeeeeeensssssssssssssssssssssssssssssssssssssss                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee!N5OTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT\L<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<=V>||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||EM]H'[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv&PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP;B	"""""""""""""""""""""""""""g/wyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyFFFFFFFFFFFFFFFFFFFFFFFCb--------------------------------------------------------------------xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx(+0SAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA$D1.kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkIi::::::::::::::::::::mdddddddddddddddddddhu%%%%%%%%%%%%%%%%,,,,,,,,,,,,,,,,,,,,,cccccccccccccccccccccccccccccccclllllllllllllllllffffffffffffffffffffffffffffffffforrrrrrrrrrnae                  ttttttttttttttttttttttttttttttttttttttttttttttteeeeeeeeeesssssssssssssssssssssssssssssssss                                            unlpieeeeeeeeeeeeosraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                     eeeeeeeetttttttttttt                                                mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%::::::::::::::::::::"""""""""""""""""""""""""""""""""hddddddddddddddddddddddddddddd)nnnnnnnnnnnnnnnnncppppppppppppppppppuuuuuuuuuuuulsiaoooooooooooeeeeeeeetr                                                    eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                    nafuuuuuuuuuuuuuuelsssssssssssssiotttttttttttttttttttttttttttttttt                                                  e rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr((((((((((((((((((((((((((((Tm///////////////////////////yggggggggggggggggggggggwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwbFFFFFFFFFFFFFFFFFFFFFFFFFC	-hA2+0DSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS$1.,kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk%%%%%%%%%%%%%%%:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuddddddddddddddddp)IIIIIIIIIIIIIafcnnnnnnnnnnnnnnnnnnnnnnnl osssssssseeeeeeeeeeeeeeeeeeeeeeriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetttttttttttttttttttttttttttttttttttttuoooooooooooooaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnnnnnnrle      tssssssssssssssssssssssssssssssssssssssssssssssseeeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                               hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh%%%%%%%%%%%%%%%:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::"mapdffffffffffffffffffffffffffffffffffffffffffffffffffffffroooooooooooooueeeeeeeeeeeeniiiiiiiiiiiiiilttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                     eeeeeeeessssssssssss                                                raaaaaaaaaaaaaccccccccccccoiulnnnnnnnnnnneeeeeeeessssssssssssss                                                    eeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttt                                                                                                                                                    UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUqYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY}
9X7777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777_RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRz~6W{4444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444444GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG*!3j5K@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@NA<OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO\>LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL=EV||||||||||||||||||||||||||||||||||||'''''''''''''''''''''''''''''''''''''''''M]vHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP;(((((((((((((((((y//////////////////////////////////////////////////////////////////////gbwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww	FTC"D-2B++++++++++++++++++++++++++++++0SSSSSSSSSSSSSSSSSSSSSSSSSS,,,,,,,,,,,,,,,,,,,,,,,,$1).r%%%%%%%%%%%%%%%%%%::::::::::::::::::::hhhhhhhhhhhhhhhhhhhhhhhhhhfffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffmpppppppppppppppppppdlllllllllllllccccccccccccccccaeoitunssssssssssssssssssssssssssssssss                                                  e                                                                                             kkkkkkkkkkkktlllllllllllllrrrrrrrrrrao niiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeessssssssssssssssssssf"I%%%%%%%%%%%%%%%%%%::::::::::::::::::::hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhmcpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppdntllllllllllllllllllllraaaaaaaaaaaaaaaaaaaaaaaoe      siiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               llllllllllllllllllllllllllntttttttttttttttteeeeeeeeeeeeruaosssssssssssssssssssssssssssssssssssssssssssssssssssssssssss                     eeeeeeeeiiiiiiiiiiii                                                bbbbbbbbbbbbbbbbbbbbbbbbbbbbADy//////////////////////////////////////////////////////////////////////g(,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,	FTCwffffffffffffffffffffffffffffffxS+-000000000000000000)))))))))))))))))))))))))))))))))))))))))))))))))$$$$$$$$$$$$$$$$$$$$$111111111111111I.%"cccccccccccccccccccch:llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllmttttttttttttttttttttttttnuuuuuuuuuuuuuuuuporrrrrrrrrrreeeeeeeeia                                                    eeeeeeeeesssssssssssssssssssssssssssssssssssssssssssssssssssss                                 otttttttttttttlenusdriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                  e aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaahhhhhhhhhhhhhhhhhhhhhhhhhhhhh%%%%%%%%%%%%%%%ckf""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""::::::::::::::::::::::::::::::::::::::::::::::::::sotttttttttttttttttttttttln ruuuuuuuueeeeeeeeeeeeeeeeeeeeeeadmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiitttttttttttttrsooooooooooooooooooooooooooooooooollllllllllane      iuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeppppppppppppppppppppppppppppppppp                                                                                        5<!C>NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOE\LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL'=V|vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]][[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[2&PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPbh/DDDDDDDDDDDDDDDDDDDDDDDDDDDygggggggggggggggggggggg,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,(FFFFFFFFFFFFFFFFFFFFFFFFFA																																																													STwwwwwwwwwwwwwwwwwwwwwwwwwwwwww)x;+---------------------0000000000000000000000000000000000000000000000000I$tc%ffffffffffffffffffffffffffffffffk1oooooooooooooooo"""""""""""""""""""":dddddddddddddddddarssssssssssssseeeeeeeeeeeeeeeeeeeeeeeeeppppppppppppppppppplniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                     eeeeeeeeuuuuuuuuuuuu                                                aosttttttttttttrmmmmmmmmmmmmmnnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeul                                                    eeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                                                    afcccccccccccccccccc%hhhhhhhhhhhhhhhhhhhhhhhhhhd.""""""""""""""""""""p:nstoermmmmmmmmmmmmmmmmmiiiiiiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                                  e llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllttttttttttttinsaaaaaaaaaaor                                       eeeeeeeeeeeeeeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuSSSSSSSSSSSSSSSSSSSSSSSSSSSSCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC/gD,yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyFFFFFFFFFFFFFFFFFFFFFFFA(bbbbbbbbbbbbbbbbbbbbbbbbbd)	TwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwB+I-00000000000000000000000000kkkkkkkkkkkkkkkkkkkkkkkkttttttttttttttttttfhccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc%sppppppppppppppp.$"mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmminnnnnnnnnnnnnnnnnnnnaoooooooooolre      uuuuuuuuuuuuuuuuuuu:::::::::::::::::::::::::::::::::::::::::::::::eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                               nslllllllllllllliteeeeeeeeeeeeaaaaaaaaaaaaaoruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                hdppppppppppppppppppffffffffffffffffmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%cnnnnnnnnnnnnnnn1lllllllllllllllllll"issssssssssssssssssssssssssssssssssssstraaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeo                                                    eeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                    lrisneeeeeeeeeeeeeeeeeeeeeeeeeeuta::::::::::::::::::::::::::::::::                                                  e ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
R8_4W{66666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666666KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG*3<Hj>5)E!NO'''''''''''''''''''''''''''''''''''''''\Lvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv=VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||M]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]@2[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx&PShggggggggggggggggggggggggggg,/////////////////////////////DFyAAAAAAAAAAAAAAAAAAAAAAbbbbbbbbbbbbbbbbbbbbbbbC(%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%	TIwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBk+-0.....................................fpmmmmmmmmmmmmmmmmmmddddddddddddddddsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssccccccccccccccccccccccccccccccc111111111111111111111111urillllllllllnnnnnnnnnnnnnn aaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeottttttttttttttttttttttttttttttttttttttt                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:""""""""""""""""""""isaurrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnooooooooooooooe                                                                                   eeeeeeeeeettttttttttttttttttttttttttttttttt                                                 %imfdphhhhhhhhhhhhhhhhhhrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrc:::::::::::::::oauseeeeeeeeeeeeltnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                oruiiiiiiiiiiiiatssssssssssssssllllllllllleeeeeeeeeeeeeeeeeeeen                                                    eeeeeeeee"""""""""""""""""""""""""""""""""""""""""""""""""""""                                                        ))))))))))))))))))),gggggggggggggggggggggggggggggggggggggggggggggggggggggggF/ADbyCCCCCCCCCCCCCCCCCCCCCCSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSI(((((((((((((((((((((((((	kTwwwwwwwwwwwwwwwwwwwwwwwwwwwwww.;+-10odmhf%pppppppppppp::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::ccccccccccccccuireat"""""""""""""""sllllllllllllllllllllllllllllllllllllllllllll                                                  e nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiii$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$uoooooooooora ltttttttteeeeeeeeeeeeeeeeeeeeeensssssssssssssssssssssssssssssssssssssss                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee:::::::::::::::::ihd%mmmmmmmmmmmmmmmmmmmfuuuuuuuuuuuuuuuuuuuuppppppppppppppppppppppppppppppppp"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""llllllllllllllllllllllllcccccccccccccccccccccccccccccccccorrrrrrrrrrnae                  ttttttttttttttttttttttttttttttttttttttttttttttteeeeeeeeeesssssssssssssssssssssssssssssssss                                            unlllllllllllllllieeeeeeeeeeeeosraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                     eeeeeeeetttttttttttt                                                                                           <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>5EEEEEEEEEEEEEEEEEEEEEEEEEEEE'N\Ovvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv=LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLV!|A22222222222222222222222222222222222222222M]xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB&&&&&&&&&&&&&&&&&&&&&I,gggggggggggggggggggggggggggggggggggggggggggggggggggggggF/).byCCCCCCCCCCCCCCCCCCCCCCSSSSSSSSSSSSSSSSSSSSSSSD:kkkkkkkkkkkkkkkkkkkkkkkkkw	(T%111111111111111111111111111111;P+$--------------------hddddddddddddddddd"""""""""""""""""""fmmmmmmmmmmmmmmppppppppppppppppppnnnnnnnnnnnnnnnnnnnnnnnn000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000uuuuuuuuuuuulsiaoooooooooooeeeeeeeetr                                                    eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                    nacuuuuuuuuuuuuuuelsssssssssssssiotttttttttttttttttttttttttttttttt                                                  e rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrf%%%%%%%%%%%%dddddddddddddddddddd"h:::::::::::::::::uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuumppppppppppppppppppppppppppppppppppppppppppppaccccccccccccccccnnnnnnnnnnnnnnnnnnnnnnnl osssssssseeeeeeeeeeeeeeeeeeeeeeriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttuoooooooooooooaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnnnnnnrle      tssssssssssssssssssssssssssssssssssssssssssssssseeeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                                                AfgIIIIIIIIIIIIIIIIIIIIIIIIIII,/////////////////////////////.Fy))))))))))))))))))))))bbbbbbbbbbbbbbbbbbbbbCCCCCCCCCCCCCCCCCCCCCCCCCCSDkkkkkkkkkkkkkkkkkkkkkkkkkw	(T111111111111111111111111111111111111111111111111111111111111111111111111+$------------------------------------------------------------------------------------dddddddddddddddddddd"h:::::::::::::::::%aaaaaaaaaaaaaaamcpppppppppppppppppppppppppppppppppppproooooooooooooueeeeeeeeeeeeniiiiiiiiiiiiiilttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                     eeeeeeeessssssssssss                                                raaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaoiulnnnnnnnnnnneeeeeeeessssssssssssss                                                    eeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttt                         frrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrhd0""""""""""""c:%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%mllllllllllllllllllllllllllllpaeoitunssssssssssssssssssssssssssssssss                                                  e                                                                                                     tlllllllllllllrrrrrrrrrrao niiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUJqYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY7999999999999999999999999999999999999999999999999999999999X}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}888888888888888888888888888888888888888888888888888~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~{R
















































4W_GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG6HKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK**********************************************************************35<<<<<<<<<<<<<<<<<<<<<<<<<<\>E'=NOvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL22222222222222222222222222222222V!x|||||||||||||||||||||||||||||||||||||||||MB]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]j[;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;g/I.,yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyFFFFFFFFFFFFFFFFFFFFF)AbcccccccccccccccccccccccccCSDTkw	+(111111111111111111111111111111-------------------------------------------&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&hd0$"fffffffffffffffffffffffffffffff%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%:mntllllllllllllllllllllraaaaaaaaaaaaaaaaaaaaaaaoe      siiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               llllllllllllllllllllllllllntpeeeeeeeeeeeeruaosssssssssssssssssssssssssssssssssssssssssssssssssssssssssss                     eeeeeeeeiiiiiiiiiiii                                                                                                            c""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""ddddddddddddddddddddddddhlffffffffffffffffffffffffffffffff:%ttttttttttttttttttttttttnuppppppppppppppporrrrrrrrrrreeeeeeeeia                                                    eeeeeeeeesssssssssssssssssssssssssssssssssssssssssssssssssssss                                 otttttttttttttlenusmriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                  e aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa///////////////////////////.gyIIIIIIIIIIIIIIIIIIIIII,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,AFFFFFFFFFFFFFFFFFFFFFFF))))))))))))))))))))))))bCSDTkw	+(111111111111111111111111111111-P0000000000000000000000000000000"""""""""""""""""""""""""""""""""ccccccccccccccccccccccccccccc:dhfpppppppppppppppppppsotttttttttttttttttttttttln ruuuuuuuueeeeeeeeeeeeeeeeeeeeeeam%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiitttttttttttttrsooooooooooooooooooooooooooooooooollllllllllane      iuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                               :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::tttttttttttttttttttttttttttttttttttc"$$$$$$$$$$$$$$$$$$opppppppppppppppppdhmfarssssssssssssseeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeelniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                     eeeeeeeeuuuuuuuuuuuu                                                aosttttttttttttr%%%%%%%%%%%%%nnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeul                                                    eeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                    5555555555555555555555555555555\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\=<>EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE'NO2vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvLxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxVB!|||||||||||||||||||||||||||||||||||||||||;M]@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[:./yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyygggggggggggggggggggggIA,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,FpD)bC	STkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkw+(PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP1acccccccccccccccc$--------------------------------------------------------------------------------""""""""""""mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmdddddddddddddddhnstoer%fiiiiiiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                                  e llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllttttttttttttinsaaaaaaaaaaor                                       eeeeeeeeeeeeeeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuumpt0cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc::::::::::::::::::::sssssssssssssss""""""""""""""""""""""""""""""""""%ddddddddddddddinnnnnnnnnnnnnnnnnnnnaoooooooooolre      uuuuuuuuuuuuuuuuuuuhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                               nslllllllllllllliteeeeeeeeeeeeaaaaaaaaaaaaaoruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                     eeeeeeeeffffffffffff                                                                                                                      D./yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyggggggggggggggggggggggggggggggggggggggggggggggggggggggA,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,FIm	bTC)SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS&kw+$(((((((((((((((01cp%:::::::::::::::::::::::::::::::::::n""""""""""""""""""lllllllllllllllllllllllllllllllllllissssssssssssssssssssssssssssssssssssstraaaaaaaaaaaeeeeeeeefdo                                                    eeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                    lrisneeeeeeeeeeeeeeeeeeeeeeeeeeutahhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh                                                  e ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooccccccccccccccc%-mpsssssssssssssssssss::::::::::::::::"ffffffffffffffffffurillllllllllnnnnnnnnnnnnnn aaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeottttttttttttttttttttttttttttttttttttttt                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeehhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhisaurrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnooooooooooooooe      dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddeeeeeeeeeettttttttttttttttttttttttttttttttt                                                                                                         Rz~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~W{4






















































GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG________________________________________HK6555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*===============================FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF<>2E'NxOvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvBLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL;V!|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||M]P@3[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[/DDDDDDDDDDDDDDDDDDDDDDDDDDD.gyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAATTTTTTTTTTTTTTTTTTTTTTTTTTI	&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&bC)$Skw0+i%cmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm-(rfp::::::::::::::::h"oauseeeeeeeeeeeeltnnnnnnnnnnnnnndddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                oruiiiiiiiiiiiiatssssssssssssssllllllllllleeeeeeeeeeeeeeeeeeeen                                                    eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee         fffffffffffffffffffom%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%ccccccccccccccccccccccccccccccccccccccccccccch1p:ddddddddddddddddddddddddddddduireattttttttttttttttt"sllllllllllllllllllllllllllllllllllllllllllll                                                  e nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiuoooooooooora ltttttttteeeeeeeeeeeeeeeeeeeeeensssssssssssssssssssssssssssssssssssssss                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeTTTTTTTTTTTTTTTTTTTTTTTTTTTTFfffffffffffffffffffffffffff/gDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD.,yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyAhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhI$	bC0)Sk-wiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiimmmmmmmmmmmmmmmmmmmm%%%%%%%%%%%%%%%%%%%cuddddddddddddddd1+ppppppppppppppppp:lllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllorrrrrrrrrrnae                  ttttttttttttttttttttttttttttttttttttttttttttttteeeeeeeeeesssssssssssssssssssssssssssssssss                                            unl"ieeeeeeeeeeeeosraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                     eeeeeeeetttttttttttt                                                                   hdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddmfffffffffffffffffffffffffffffffffffc%%%%%%%%%%%%%%%%%%%%%%%%%%%%(nnnnnnnnnnnnnnnnnnp":uuuuuuuuuuuulsiaoooooooooooeeeeeeeetr                                                    eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                    naaaaaaaaaaaaaaaauuuuuuuuuuuuuuelsssssssssssssiotttttttttttttttttttttttttttttttt                                                  e rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr=\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555<>2E'NxOvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvBLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL;V!|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||M]Pj[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[&TTTTTTTTTTTTTTTTTTTTgggggggggggggggggggggggggggggggggggggggggggggggggggggggg/,DDDDDDDDDDDDDDDDDDDDDDDDDDDDD........................yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyFFFFFFFFFFFFFFFFFFFFFFFFFc$AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA0I	b-C)S1kkkkkkkkkkkkmdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddhfuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu%%%%%%%%%%%%%%%"(wwwwwwwwwwwwwaaaaaaaaaaaaaaaapnnnnnnnnnnnnnnnnnnnnnnnl osssssssseeeeeeeeeeeeeeeeeeeeeeriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeetttttttttttttttttttt:uoooooooooooooaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnnnnnnrle      tssssssssssssssssssssssssssssssssssssssssssssssseeeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                c:mdddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddhffffffffffffffffffffa"%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+roooooooooooooueeeeeeeeeeeeniiiiiiiiiiiiiilttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt                     eeeeeeeessssssssssss                                                raaaaaaaaaaaaappppppppppppoiulnnnnnnnnnnneeeeeeeessssssssssssss                                                    eeeeeeeeettttttttttttttttttttttttttttttttttttttttttttttttttttt         $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$g,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,////////////////////////DDDDDDDDDDDDDDDDDDDDD.FyTTTTTTTTTTTTTTTTTTTTTTf0000000000000000000000000AAAAAAAAAAAAAAAAAAAAAAA--------------------------I	1bC)(Srd:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::mccccccccccccccccccccccccccccccccccccccccccchhhhhhhhhhhhhhhhhhhh"""""""""""""""""""%lllllllllllllpppppppppppppppaeoitunssssssssssssssssssssssssssssssss                                                  e                                                                         +kkkkkkkkkkkktlllllllllllllrrrrrrrrrrao niiiiiiiieeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesssssssssssssssssssssssssssssssssssfwd:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::mcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccp"h%ntllllllllllllllllllllraaaaaaaaaaaaaaaaaaaaaaaoe      siiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                               llllllllllllllllllllllllllnttttttttttttttteeeeeeeeeeeeruaosssssssssssssssssssssssssssssssssssssssssssssssssssssssssss                     eeeeeeeeiiiiiiiiiiii                                                                                     YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYqU87999999999999999999999999999999999999999999999999999999RX}~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzW4{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{






















































KG_________________________________________________________________________________________H666666666666666666666666666666666666666666666666666666666666=\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\5@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>E<N2O'''''''''''''''''''''''''''''''''''''''xLvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvBBBBBBBBBBBBBBBBBBBBBBBB|||||||||||||||||||||||||||||||||||||;V]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!MPj*$000000000000000000000000000000g,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,///////////////////////////////////[111111111111111111111.FyTTTTTTTTTTTTTTTTTTTTTTDDDDDDDDDDDDDDDD-AIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII:(	bC+)))))))))))))))))wSdfpmccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccclllllllllllllllllllllllllllllllllllllllllllllllllhhhhhhhhhhhhhhhhhhhhttttttttttttttttttttttttnuuuuuuuuuuuuuuu"orrrrrrrrrrreeeeeeeeia                                                    eeeeeeeeesssssssssssssssssssssssssssssssssssssssssssssssssssss                                 otttttttttttttlenus%riiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                  e aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaac::::::::::::dddddddddddddddddpkkkkkkkkkkkkkkkkfffffffffffffhmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmsotttttttttttttttttttttttln ruuuuuuuueeeeeeeeeeeeeeeeeeeeeea%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeiiiiiiiiiiiiiiiiiiiitttttttttttttrsooooooooooooooooooooooooooooooooollllllllllane      iuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeee"""""""""""""""""""""""""""""""""                                                                                                      cg00000000000000000000000000000000000000000000000000000000/,11111111111111111111111111111.&yyyyyyyyyyyyyyyyyyyyy$FhITD-(AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA++++++++++++++++++++++++++	bwCtpdddddddddddddddddddddddddddddddd:k)ooooooooooooooofmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm%%%%%%%%%%%%%%%%%%arssssssssssssseeeeeeeeeeeeeeeeeeeeeeeee"""""""""""""""""""lniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                     eeeeeeeeuuuuuuuuuuuu                                                aosttttttttttttrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrnnnnnnnnnnnnnnnnnnnnnnnneeeeeeeeul                                                    eeeeeeeeeiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                       haaaaaaaaaaaaaaaap:dcccccccccccccccccccccccccccc%Sfm"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""nstoerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrriiiiiiiiiiiiiiiiiiiiiiiiiiuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                                                  e llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllttttttttttttinsaaaaaaaaaaor                                       eeeeeeeeeeeeeeeeeeeeeelllllllllllllllllllllllllllllllllllllllllllllllllll                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\5=IEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE>OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO<NL2'''''''''''''''''''''''''''''''''''''''|xvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv]BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;V!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!MPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPg/0111111111111111111111111111111.,yyyyyyyyyyyyyyyyyyyyyyyyyyyyy$&33333333333333333333333333333333333333333333%(FTD+-AAAAAAAAAAAAAAAAAAAAAAAwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww	kbt::::::::::::::::cphds"""""""""""""""""SCffffffffffffffffffffmmmmmmmmmmmmmminnnnnnnnnnnnnnnnnnnnaoooooooooolre      uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuueeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                               nslllllllllllllliteeeeeeeeeeeeaaaaaaaaaaaaaoruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                c%":::::::::::::::::::::::::::::::::::::::::::::::::hdpnnnnnnnnnnnnnnnnn)lllllllllllllllllllfissssssssssssssssssssssssssssssssssssstraaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeeeemo                                                    eeeeeeeeeuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu                    lrisneeeeeeeeeeeeeeeeeeeeeeeeeeutaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                  e oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo((((((((((((((((((((((((((((Ic///////////////////////////1g.0yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy$,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,[d+++++++++++++++++++++FTwD-AkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkS																											"""""""""""""""""""":%%%%%%%%%%%%%%%ssssssssssssssssssshpppppppppppppppppppppppppppppppppp)burillllllllllnnnnnnnnnnnnnn aaaaaaaaaaaaaaaaaaaaeeeeeeeeeeeeeeeeeeeeeeottttttttttttttttttttttttttttttttttttttt                 eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeffffffffffffffffffffisaurrrrrrrrrrrrrrrrrrrrlnnnnnnnnnnooooooooooooooe      mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmeeeeeeeeeettttttttttttttttttttttttttttttttt                                                 diiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii%"c:rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrhpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppoauseeeeeeeeeeeeltnnnnnnnnnnnnnnmCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                     eeeeeeeeeeeeeeeeeeeeeeeeeeeeeee                                                oruiiiiiiiiiiiiatssssssssssssssllllllllllleeeeeeeeeeeeeeeeeeeen                                                    eeeeeeeeefffffffffffffffffffffffffffffffffffffffffffffffffffff  