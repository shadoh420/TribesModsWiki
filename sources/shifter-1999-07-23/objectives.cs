exec("game.cs");								
$flagReturnTime = 45;

function ObjectiveMission::missionComplete()
{
    $missionComplete = true;
    %group = nameToID("MissionCleanup/ObjectivesSet");
    for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
    {
         ObjectiveMission::objectiveChanged(%obj);
    }
    for(%i = 0; %i < getNumTeams(); %i++)
	{ 
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	}
	ObjectiveMission::setObjectiveHeading();
    ObjectiveMission::refreshTeamScores();
 	%lineNum = "";
    $missionComplete = false;

   //=== Back out of all the functions...
    schedule("Server::nextMission();", 0);
}

function ObjectiveMission::setObjectiveHeading()
{
   if($missionComplete) //======================================================================================== When The Mission Is Over
   {
        %curLeader = 0;
		%tieGame = false;
		%tie = 0;
		%tieTeams[%tie] = %curLeader; 
		for(%i = 0; %i < getNumTeams() ; %i++) 
		echo("GAME: teamfinalscore " @ %i @ " " @ $teamScore[%i]);
      
		for(%i = 1; %i < getNumTeams() ; %i++) 
        {
		   if($teamScore[%i] == $teamScore[%curLeader])
		   { 
           		 %tieGame = true;
         		 %tieTeams[%tie++] = %i;
		   }
		   else
		       if($teamScore[%i] > $teamScore[%curLeader])
               {
         		    %curLeader = %i;	   
         		    %tieGame = false;
					%tie = 0;
					%tieTeams[%tie] = %curLeader; 
               }
        }
		
		if(%tieGame) //================================================================================================ If The Game Is Tied
		{
			for(%g = 0; %g <= %tie; %g++)
			{ 
				%names = %names @ getTeamName(%tieTeams[%g]);
				if(%g == %tie-1)
					%names = %names @ " and "; 
				else if(%g != %tie)
					%names = %names @ ", "; 
			}
			if(%tie > 1) 
			 	%names = %names @ " all"; 
		}
		
		//================================================================================================ Team Scores
		for(%i = -1; %i < getNumTeams(); %i++)
        {
			objective::displayBitmap(%i,0);
			if(!%tieGame)
			{
	         	if(%i == %curLeader)
			 	{ 
					if($teamScore[%curLeader] == 1)
					   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " point!");
					else
					   	Team::setObjective(%i, 1, "<F5>           Your team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
				else
				{
					if($teamScore[%curLeader] == 1)
						Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " point!");
  					else
	          			Team::setObjective(%i, 1, "<F5>     The " @ getTeamName(%curLeader) @ " team won the mission with " @ $teamScore[%curLeader] @ " points!");
				}
		  	}	
			else
			{
				if(getNumTeams() > 2)
					Team::setObjective(%i, 1, "<F5>     The " @ %names @ " tied with a score of " @ $teamScore[%curLeader]);
  	         
				else
					Team::setObjective(%i, 1, "<F5>     The mission ended in a tie where each team had a score of " @ $teamScore[%curLeader]);
			}
			Team::setObjective(%i, 2, " ");
			
			
		//========================================================================================================== Players Ratio & Scores
		//=== Print out top 5 scores

			echo("*** Printing Player Stats");
			
			%numClients = getNumClients();
			%numCl = ((2049 + %numClients) + 20);
			%linenum = 10;
						
			//========================================= Sort Client List By Score Highest To Lowest
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
							%clientList[%k+1]	= %hold;
							%doIt=1;
						}
					}
				}
			//========================================= Sort Client List By Score
				%index = 0;
				%c = 0;
				while(%index < %numClients)
				{
					%client = getClientByIndex(%count);			
					(%clientList[%c]).ratio = getEfficiencyRatio(%clientList[%c]);			
					echo ("*** Printing Player - " @ Client::getName(%clientList[%c]) @ " Stats" @ (%clientlist[%c]));		
					Team::setObjective(%i, %lineNum++, "<L14><f2>#" @ (%c + 1) @ "." @ Client::getName(%clientList[%c]) @ "<f1> with a Kill-Death Ratio of " @ (%clientList[%c]).ratio @ ".0% With A Score Of " @ (%clientList[%c]).score @ ".");
					Team::setObjective(%i, %lineNum++, "<L14><f1> Kills= " @ (%clientList[%c]).ScoreKills @ " Deaths= " @ (%clientList[%c]).ScoreDeaths @ " TeamKills= " @ (%clientList[%c]).TKCount @ " Flag Caps = " @ (%clientList[%c]).FlagCaps @ ".");
					%lastRatio = (%clientList[%index]).score;
					%index++;
					%c++;
				}  
			}  
    }
    else
    {
        for(%i = -1; %i < getNumTeams(); %i++)
        {
			objective::displayBitmap(%i,0);
		  	Team::setObjective(%i, 1,"<f5>Mission Completion:");
		    Team::setObjective(%i, 2,"<f1>   - " @ $teamScoreLimit @ " points needed to win the mission.");
		}
	}
	
    if(!$Server::timeLimit)
       %str = "<f1>   - No time limit on the game.";
    else if($timeLimitReached)
       %str = "<f1>   - Time limit reached.";
    else
		if($missionComplete)
    	{
    	   %time = getSimTime() - $missionStartTime;
    	   %minutes = Time::getMinutes(%time);
    	   %seconds = Time::getSeconds(%time);
    	   if(%minutes < 10)
    	      %minutes = "0" @ %minutes;
    	   if(%seconds < 10)
    	      %seconds = "0" @ %seconds;
    	   %str = "<f1>   - Total match time: " @ %minutes @ ":" @ %seconds;
    	}
    	else
    	    %str = "<f1>   - Time remaining: " @ floor($Server::timeLimit - (getSimTime() - $missionStartTime) / 60) @ " minutes.";
   	for(%i = -1; %i < getNumTeams(); %i++)
    {
	  	Team::setObjective(%i, 3, " ");
  		Team::setObjective(%i, 4, "<f5>Mission Information:");
		Team::setObjective(%i, 5, "<f1>   - Mission Name: " @ $missionName); 
        Team::setObjective(%i, 6, %str);
	}	
}
//============================================================================================================== Get Player Ratios
function getEfficiencyRatio(%clientId)
{
		%ratio = floor((%clientId.scoreKills/(%clientId.scoreKills + %clientId.scoreDeaths))*100);
		if (%ratio > 0)
			return %ratio;
		else 
			return "0";
}

//============================================================================================================== Display Team Bit Maps
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
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;
   ObjectiveMission::setObjectiveHeading();

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }

   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: timelimit");
      $timeLimitReached = true;
      //echo("checking for objective time limit status...");
      %set = nameToID("MissionCleanup/ObjectiveSet");
      for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
         GameBase::virtual(%obj, "timeLimitReached", %clientId);
      ObjectiveMission::missionComplete();
   }
   else
   {
      if(%curTimeLeft >= 20)
         schedule("Game::checkTimeLimit();", 20);
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
   for(%i = -1; %i < %nt; %i++)
   {
      Team::setScore(%i, "%t\t  " @ $teamScore[%i], $teamScore[%i]);
      for(%j = 0; %j < %nt; %j++) 
         Team::setObjective(%i,%j+$firstTeamLine, "<f1>   - Team " @ getTeamName(%j) @ " score = " @ $teamScore[%j]);
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
   setTeamScoreHeading("Team Name\t\xD6Score");

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
   %spawnSet = nameToID("MissionCleanup/TeamDrops" @ %team);
   %spawnCount = Group::objectCount(%spawnSet);
   if(!%spawnCount)
      return -1;
  	%spawnIdx = floor(getRandom() * (%spawnCount - 0.1));
  	%value = %spawnCount;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%spawnSet, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %spawnCount - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

//========================================================================================= Handles all scoring based on distance to Towers
function Client::leaveGame(%clientId)
{
   echo("GAME: clientdrop " @ %clientId);
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientDropped", %clientId);
}

function Game::clientKilled(%playerId, %killerId)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "clientKilled", %playerId, %killerId);
}

function Player::enterMissionArea(%this)
{
   %set = nameToID("MissionCleanup/ObjectivesSet");
	%this.outArea = "";
   for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
      GameBase::virtual(%obj, "playerEnterMissionArea", %this);
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
//=========================================================================================================== Player Touches A Tower Switch
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
   //============================================================================================== Points For Getting Objectives
   if(%oldTeam == -1)
   {
      MessageAllExcept(%playerClient, 0, %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");
      Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!");

		  //==================================================================================================== Score For Initial Capture
	      %playerClient.score = (%playerClient.score + $Score::InitialObj);
		  if ($ScoresOn) bottomprint(%playerClient, "Score +" @ $Score::InitialObj @ " = " @ %playerClient.score @ " Total Score");
 	}
   else
   {
      if(%this.objectiveLine)
      {
         MessageAllExcept(%playerClient, 0, %touchClientName @ " captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
         Client::sendMessage(%playerClient, 0, "You captured " @ %this.objectiveName @ " from the " @ getTeamName(%oldTeam) @ " team!");
		 %this.numSwitchTeams++;	

		 //======================================================================================================== Score For Capture From
         %playerClient.score = (%playerClient.score + $Score::CaptureObj);	  
	     if ($ScoresOn) bottomprint(%playerClient, "Score +" @ $Score::CaptureObj @ " = " @ %playerClient.score @ " Total Score");

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
    //================== Give player bonus points for holding captured tower
	if(%this.numSwitchTeams == %numChange)
	{
		  //================================================================================== Points For Holding Objective For 60 Seconds   
	      %client.score = (%client.score + $Score::CaptureObj);
		  if ($ScoresOn) bottomprint(%client, "Score +" @ $Score::HoldingObj @ " = " @ %client.score @ " Total Score");
	    
		Game::refreshClientScore(%client);
	    Client::sendMessage(%client, 0, "You receive 5 points for holding your captured tower!");
	}
}

function TowerSwitch::clientKilled(%this, %playerId, %killerId)
{      
   if(!%this.objectiveLine)
      return;

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
            return "<Bflag_atbase.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
         else if(%this.holdingTeam == -1)
            return "<Bflag_neutral.bmp>\nNo team finished the mission in control of " @ %this.objectiveName @ ".";
         else {
				if(%forTeam != -1)
					return "<Bflag_enemycaptured.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
      		else
					return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
			}
		}
      else if(%forTeam != -1)
      {
         if(%thisTeam == %forTeam)
            return "<Bflag_atbase.bmp>\nYour flag was captured " @ %this.enemyCaps @ " times.";
         else
            return "<Bflag_enemycaptured.bmp>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times.";
      }
  		else 
      	return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ "'s flag was captured " @ %this.enemyCaps @ " times.";
   }
   else
   {
      if(%thisTeam == -1)
      {
			if(%forTeam != -1) {
         	if(%this.holdingTeam == %forTeam)
         	   return "<Bflag_atbase.bmp>\nDefend " @ %this.objectiveName @ ".";
         	else if(%this.holdingTeam != -1)
         	   return "<Bflag_enemycaptured.bmp>\nGrab " @ %this.objectiveName @ " from the " @ getTeamName(%this.holdingTeam) @ " team.";
         	else if(%this.carrier != -1)
         	{
         	   if(GameBase::getTeam(%this.carrier) == %forTeam)
         	      return "<Bflag_atbase.bmp>\nConvey " @ %this.objectiveName @ " to an empty flag stand. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
         	   else
         	      return "<Bflag_enemycaptured.bmp>\nWaylay " @ Client::getName(Player::getClient(%this.carrier)) @ " and convey " @ %this.objectiveName @ " to your base.";
         	}
         	else if(%this.atHome)
         	   return "<Bflag_neutral.bmp>\nGrab " @ %this.objectiveName @ " and convey it to an empty flag stand.";
         	else
         	   return "<Bflag_notatbase.bmp>\nFind " @ %this.objectiveName @ " and convey it to an empty flag stand.";
      	}
			else {
         	if(%this.holdingTeam != -1)
         	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team has " @ %this.objectiveName @ ".";
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
				if(%forTeam != -1) {
            	if(%this.atHome)
            	   return "<Bflag_enemycaptured.bmp>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(GameBase::getTeam(%this.carrier) == %forTeam)
            	   return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " to base.";
            	else
            	   return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " and steal his flag.";
         	}
				else {
            	if(%this.atHome)
            	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field.";
            	else 
            	   return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has the " @ getTeamName(%thisTeam) @ " flag.";
				}
			}         
      }
   }
}
//=========================================================================================================================================
//															 Flag Releated Calls
//=========================================================================================================================================

//=========================================================================================================================================
//																 Dropped Flag
//=========================================================================================================================================
function Flag::onDrop(%player, %type)
{
//echo ("*** Flag Dropped");


   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);

	%homepos = ($teamFlag[%playerTeam]).originalPosition; //========= Get Base location for live player.
	%droppos = GameBase::getPosition(%player);
	%disthome = (Vector::getDistance(%homepos,%droppos));

   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);	

   if(%flagTeam == -1)
   {
      MessageAllExcept(%playerClient, 1, %dropClientName @ " dropped " @ %flag.objectiveName @ "!");
      Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
   }
   else //================================================================================ Mesage Players If Flag Was Dropped In The Field.
   {	//=============================================================================== Messaging for the flag dropping needs to go here.

	//echo ("Flag Team    " @ %flagTeam);
	//echo ("Player Team  " @ %playerTeam);
	//echo ("Dist To Home " @ %disthome);
	//echo ("Home Pos     " @ %homepos);
	//echo ("Drop Pos     " @ %droppos);


		if (%flagTeam == %playerTeam && %disthome <= 10)
		{
			//echo ("************** RETURNED FLAG TO BASE **");
			

				//========================================================= Returns Flag From Player To Stand			
				GameBase::startFadeOut(%flag);
				GameBase::setPosition(%flag, %flag.originalPosition);
	            Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%flag);
	            %flag.atHome = true;
                $flagAtHome[1] = true;
                %flag = %object.carryFlag;
                %flag.atHome = true;
                %flag.carrier = -1;                           
                Item::hide(%flag, false);

				//========================================================= Removes Flag From Player				
				Player::setItemCount(%object, Flag, 0);
				%object.carryFlag = "";
				%flag.carrier = -1;
				Flag::clearWaypoint(%playerClient, true);

				//========================================================= Applies Manual Return Score
		        if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + ($Score::FlagReturn * 3));
			   	if ($ScoreOn) bottomprint(%playerClient, "You Safely Returned Your Flag Score + " @ ($Score::FlagReturn * 3) @ " = " @ %playerClient.score @ " Total Score" ,3);
                Game::refreshClientScore(%playerClient);
			
				//========================================================= Message Players And Team About Flag Return
				
	            MessageAllExcept(%playerClient, 0, %playerName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
	            Client::sendMessage(%playerClient, 0, "You returned your flag!~wflagreturn.wav");
	            teamMessages(1, %playerTeam, "Your flag was returned to base by " @ %playerName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
				return;
		}
		else
		{
	    	MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
	    	Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
	    	TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
		}
   }


	if ($Shifter::FlagNoReturn)
	{
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $Shifter::FlagReturnTime);	
        TeamMessages(1, %flagTeam, "You MUST Return Your Flag!!!", -2, "", "Get the " @ getTeamName(%flagTeam) @ " flag!!!");
		
		echo ("Flag      =" @ %flag);
		echo ("Flag Team =" @ getTeamName(%flagTeam));

		Gamebase::setMapName(%flag, "The " @ getTeamName(%flagTeam) @ " Flag");
	}
	else
	{
		schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);	
	}

	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

//======================================================================================================================= Flag Check Return
function Flag::checkReturn(%flag, %sequenceNum)
{
   //echo("checking for flag return: ", %flag, ", ", %sequenceNum);

   if(%flag.pickupSequence == %sequenceNum)
   {
		if(%flag.dropFade)
		{ 
			GameBase::startFadeOut(%flag);
		  	%flag.dropFade= "";
			%flag.fadeOut= 1;
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
	   	   %flag.fadeOut= "";
		   ObjectiveMission::ObjectiveChanged(%flag);
	   }
   }
}
//======================================================================================================================= Touching The Flag
function Flag::onCollision(%this, %object)
{
   //echo("Flag collision ", %object);
	
   if(getObjectType(%object) != "Player")
      return;
    
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
   %carriedflag = %object.carryFlag;
   %carriedflagteam = GameBase::getTeam(%carriedFlag);
   %carrierflag = Player::getMountedItem(%object, $FlagSlot);

   if(%this.carrier != -1)
      return; //============= Spurious collision

	//echo ("******** Flag Touch");
	//echo ("Carried Flag  " @ %carriedflag);
	//echo ("Carried Team  " @ %carriedflagteam);
	//echo ("Carrier Flag  " @ %carrierflag);
	//echo ("This At Home  " @ %this.atHome);
	
   if (%carrierflag == "flag")
   {
		if (%this.atHome == "True")
		{
			echo ("Player Has Flag & Flag Hes Touching Is At Home");
		}
		else
		{
	  		bottomprint(%playerClient, "You must return the flag you have before you can pick up another." ,3);
	    	return;
		}
   }


   if(%flagTeam == %playerTeam)      //====== player is touching his own flag...
   {
      if(!%this.atHome)             //======= The flag isn't home! so return it.
      {
			if ($Shifter::FlagNoReturn != "True") //=================================== If No Flag Return Is Not True Flag Returns Normally
			{
				echo ("*** Flag Returned On Contact By " @ %touchClientName @ " - " @ %playerClient);

				GameBase::startFadeOut(%this);
				GameBase::setPosition(%this, %this.originalPosition);
	            Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%this);
	            %this.atHome = true;
	            MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
	            Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
	            teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");

				//============================================================================================= Player Returns Flag To Base
		        if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + $Score::FlagReturn);
			   	if ($ScoreOn) bottomprint(%playerClient, "Score + " @ $Score::FlagReturn @ " = " @ %playerClient.score @ " Total Score" ,3);
                Game::refreshClientScore(%playerClient);
				   
	            %this.pickupSequence++;
	            ObjectiveMission::ObjectiveChanged(%this);
			}
			else //===================================================== If Flag No Return Is True Player Will Have To Return Flag Manually
			{
        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %playerTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
			}
      }
      //============================================================ Modified by Werewolf so that AI cannot capture flags but RETURN them.
	  else
      {
         if(%object.carryFlag != "")
         {
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
				
               //=========================================================================================== Flag carrier gets bonus points
	               %playerClient.score = (%playerClient.score + $Score::FlagCapture);
		   		   if ($ScoreOn) bottomprint(%playerClient, "Score + " @ $Score::FlagCapture @ " = " @ %playerClient.score @ " Total Score" ,3);
				   %playerClient.FlagCaps = (%playerClient.FlagCaps + 1);
	               messageAll(0, Client::getName(%playerClient) @ " receives " @ $Score::FlagCapture @ " point capture bonus.");
	               Game::refreshClientScore(%playerClient);

            }
         }
      }
   }
   else //======================================================================================================= Player Grab Enemy Flag
   {
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "")
			{
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
	 
	 			if(%this.fadeOut)
				{
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
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
   		}
	}
}
//============================================================================================================ Clear Flag Runners Way Point
function Flag::clearWaypoint(%client, %success)
{
   if(%success)
      setCommandStatus(%client, 0, "Objective completed.~wobjcomp");
   else
      setCommandStatus(%client, 0, "Objective failed.");
}


//=========================================================================================================== Set Waypoint For Flag Carrier
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
		%pos = ($teamFlag[%team]).originalPosition; //========= Get Base location for live player.
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
  	    issueCommand(%client, %client, 0,"Take the " @ getTeamName(%flagTeam) @ " flag to our flag stand.~wcapobj", %posX, %posY);
		return;
	}
}

//========================================================================================================================= Flag Stand Init
function FlagStand::objectiveInit(%this)
{
   %this.flag = "";
   %team = GameBase::getTeam(%this);

   %this.nextFlagStand = $teamFlagStand[%team];
   $teamFlagStand[%team] = %this;
	
   return false;
}

//==================================================================================================================== Flag Stand Collition
function FlagStand::onCollision(%this, %object)
{
   //echo("************** FlagStand collision ", %object);

   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);
   %carryflagTeam = GameBase::getTeam(%object.carryFlag);
   %playerClient = Player::getClient(%object);
   %playerName = Client::getName(%playerClient);

   //echo ("*** CarryFlag  " @ %object.carryFlag);
   //echo ("*** Stand Team " @ %standteam);
   //echo ("*** PlayerTeam " @ %playerTeam);
   //echo ("*** Object     " @ %object);
   //echo ("*** Flag Carry " @ %carryflagTeam);

	if (%object.carryFlag != "" && %standTeam == %playerTeam && getObjectType(%object) == "Player" && (%carryflagTeam == %standTeam && %carryflagTeam == %playerTeam))
	{
			//echo ("************** RETURNED FLAG TO BASE **");
			
				%flag = %object.carryFlag;

				//========================================================= Returns Flag From Player To Stand			
				GameBase::startFadeOut(%flag);
				GameBase::setPosition(%flag, %flag.originalPosition);
	            Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%flag);
	            %flag.atHome = true;
                $flagAtHome[1] = true;
                %flag = %object.carryFlag;
                %flag.atHome = true;
                %flag.carrier = -1;                           
                Item::hide(%flag, false);

				//========================================================= Removes Flag From Player				
				Player::setItemCount(%object, Flag, 0);
				%object.carryFlag = "";
				%flag.carrier = -1;
				Flag::clearWaypoint(%playerClient, true);

				//========================================================= Applies Manual Return Score
		        if ($Score::FlagReturn > 0) %playerClient.score = (%playerClient.score + ($Score::FlagReturn * 3));
			   	if ($ScoreOn) bottomprint(%playerClient, "You Safely Returned Your Flag Score + " @ ($Score::FlagReturn * 3) @ " = " @ %playerClient.score @ " Total Score" ,3);
			


				//========================================================= Message Players And Team About Flag Return
				
	            MessageAllExcept(%playerClient, 0, %playerName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
	            Client::sendMessage(%playerClient, 0, "You returned your flag!~wflagreturn.wav");
	            teamMessages(1, %playerTeam, "Your flag was returned to base by " @ %playerName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
			
			
	}


//==== Everything After This Is For Find And Retrieve
   if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == "" || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
      return;

   // If we're here, we're carrying a flag, we've hit our flag stand, it doesn't have a flag, and we're not carrying
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


   MessageAllExcept(%playerClient, 0, Client::getName(%playerClient) @ " conveyed " @ %flag.objectiveName @ " to base.");
   Client::sendMessage(%playerClient, 0, "You conveyed " @ %flag.objectiveName @ " to base.");
   TeamMessages(1, %playerTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");

   %flag.trainingObjectiveComplete = true;
   ObjectiveMission::ObjectiveChanged(%flag);
   ObjectiveMission::checkScoreLimit();
}


//==================================================================================================================== Flag Defence For ASS
function Flag::clientKilled(%this, %playerId, %killerId)
{
   %player = Client::getOwnedObject(%playerId);
   %killer = Client::getOwnedObject(%killerId);

   if(%player == -1 || %killer == -1)
      return;

   %flagTeam = GameBase::getTeam(%this);

   if(%flagTeam == -1)
      return;

   %playerTeam = GameBase::getTeam(%player);
   %killerTeam = GameBase::getTeam(%killer);

   if(%playerTeam == %killerTeam)
   {
         %killerId.score = (%killerId.score - ($Score::FlagDef * 2));
		 if ($ScoresOn) centerprint(%killerId, "You Just Team Killed Your Own Flag Runner. Score - " @ $Score::FlagDef @ " = " @ %killerId.score @ " Total Score, You dumb-ass.", 5);
         Game::refreshClientScore(%killerId);
         messageAll(0, Client::getName(%killerId) @ " just Team Killed His Teams Flag Runner!!!");
   }

   //============================================================================================== Killer's the only guy who gets a bonus.   
   if(%killerTeam == %flagTeam)
   {
      if(%this.carrier == -1)
      {
         %flagPos = GameBase::getPosition(%this);
         %playerPos = GameBase::getPosition(%player);

         if(Vector::getDistance(%flagPos, %playerPos) < 80)
         {
               %killerId.score = (%killerId.score + $Score::FlagDef);
			   if ($ScoresOn) bottomprint(%killerId, "Score +" @ $Score::FlagDef @ " = " @ %killerId.score @ " Total Score");
               Game::refreshClientScore(%killerId);
               messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag!");
         }
      }
   }
   else
   {
      if(%this.carrier != -1)
      {
         %carrierTeam = GameBase::getTeam(%this.carrier);
         if(%carrierTeam == %killerTeam)
         {
            if(Vector::getDistance(GameBase::getPosition(%this.carrier), GameBase::getPosition(%killer)) < 80)
            {
                Game::refreshClientScore(%killerId);

	            %killerId.score = (%killerId.score + $Score::FlagKill);
				if ($ScoresOn) bottomprint(%killerId, "Score +" @ $Score::FlagKill @ " = " @ %killerId.score @ " Total Score");

			    messageAll(0, Client::getName(%killerId) @ " gets a bonus for defending the flag carrier!");
            }               
         }
      }
   }
}
//================================================================================================================== Player Drops From Game
function Flag::clientDropped(%this, %clientId)
{
   //echo(%this @ " " @ %clientId);
   %type = Player::getMountedItem(%clientId, $FlagSlot);
   if(%type != -1)
      Player::dropItem(%clientId, %type);
}

//========================================================================================================= Flag Player Leaves Mission Area
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
  	   if(%flagTeam == -1 && (%this.flagStand == "" || (%this.flagStand).flag != "") ) 
   	{
      	MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
      	Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			%this.flagStand = "";
   	}
   	else
   	{
			if(%flagTeam != -1)
			{
				%team = %flagTeam;
				GameBase::setPosition(%this, %this.originalPosition);
            	Item::setVelocity(%this, "0 0 0");
			}
			else
			{
				%team = GameBase::getTeam(%this.flagStand);
				GameBase::setPosition(%this, GameBase::getPosition(%this.flagStand));
            	Item::setVelocity(%this, "0 0 0");
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
{
   return StaticShape::objectiveInit(%this);
}

function Turret::objectiveInit(%this)
{
   return StaticShape::objectiveInit(%this);
}

function StaticShape::objectiveInit(%this)
{
   %this.destroyerTeam = "";
   return %this.scoreValue != "";
}

function Sensor::getObjectiveString(%this, %forTeam)
{
   return StaticShape::getObjectiveString(%this, %forTeam);
}

function Turret::getObjectiveString(%this, %forTeam)
{
   return StaticShape::getObjectiveString(%this, %forTeam);
}

function StaticShape::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   if(%this.destroyerTeam != "")
   {
      if(%forTeam == %this.destroyerTeam && %thisTeam != %forTeam)
         return "<Bitem_ok.bmp>\nYour team successfully destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
      else if(%forTeam == %thisTeam)
         return "<Bitem_damaged.bmp>\nYour team failed to defend " @ %this.objectiveName;
      else
         return "<Bitem_ok.bmp>\n" @ getTeamName(%this.destroyerTeam) @ " team destroyed the " @ getTeamName(%thisTeam) @ " " @ %this.objectiveName @ " objective.";
   }
   else
   {
      if($missionComplete)
      {
         if(%forTeam != -1) {
				if(%forTeam == %thisTeam)
         	   return "<Bitem_ok.bmp>\nYour team successfully defended " @ %this.objectiveName @ ".";
         	else
         	   return "<Bitem_damaged.bmp>\nYour team failed to destroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ ".";
      	}
			else 
        	   return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " failed to destroy the " @ %this.objectiveName @ " objective.";
		}
      else
      {
         if(%forTeam != -1) {
         	if(%forTeam == %thisTeam)
            	return "<Bitem_ok.bmp>\nDefend " @ %this.objectiveName @ ".";
         	else
	          	return "<Bitem_damaged.bmp>\nDestroy " @ getTeamName(%thisTeam) @ " objective, " @ %this.objectiveName @ "(" @ %this.scoreValue @ " points).";
      	}
			else 
        	   return "<Bitem_ok.bmp>\n" @ getTeamName(%thisTeam) @ " must defend the " @ %this.objectiveName @ " objective.";

      }
   }
}

function StaticShape::timeLimitReached(%this)
{
   if(%this.scoreValue && !%this.destroyerTeam)
   {
      // give the defense some props!
      $teamScore[GameBase::getTeam(%this)] += %this.scoreValue;
   }
}

//========================================================================================================= Testing For Destroyed Objects
function StaticShape::objectiveDestroyed(%this)
{
	//echo ("*** Object Destroyed");
	//echo ("*** Object ID = " @ %this);
	
	if(%this.destroyed == "")
	{	
		//=================================================================================================================================
		// == Determins Object Destroyed For Points System
		//=================================================================================================================================
   		if(!%this.objectiveLine)  //===================================================================== Check If it's really an objective
		{
			//======================================================================== Setting Up Variables
	   		%destroyerTeam = %this.lastDamageTeam;								 //=== Team who destroyed Object.
			%thisTeam = GameBase::getTeam(%this); 								 //=== Team whos object belongs.
	        %playerClient = GameBase::getControlClient(%this.lastDamageObject);  //=== Player Who Did The Damage.
			$lastdamageobj[%this] = GameBase::getControlClient(%this.lastDamageObject);	

			if(%playerClient != -1)												 //=== Get The Players Name Who Killed.
	            %clientName = Client::getName(%playerClient);
			
			%objtype = getObjectType(%this);
			%objname = (GameBase::getDataName(%this)).description;
			
			//echo ("*** Object Is      = " @ %objtype);
			//echo ("*** Object Is      = " @ %objname);
			//echo ("*** Destoyer Is    = " @ %clientName @ " ID = " @ %playerClient);
			//echo ("*** Object Is Team = " @ %thisTeam @ " Destroyed By Team = " @ %destroyerTeam);

			if (%thisTeam == -1) //=== Doesnt Matter - Not A Team Item
				return;

				//=================================================== Need to get a list and point values to give to the destroying player.

				if (%objname == "Generator")				%pntval = $Score::ObjGeneratorB;
				if (%objname == "Solar Panel")				%pntval = $Score::ObjGeneratorS;
				if (%objname == "Portable Generator")		%pntval = $Score::ObjGeneratorS;		
		
				if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
				if (%objname == "Station Supply Unit")		%pntval = $Score::ObjStationS;
				if (%objname == "Command Station")			%pntval = $Score::ObjStationA;

				if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
				if (%objname == "Remote Inv Unit")			%pntval = $Score::ObjStationR;
				if (%objname == "Remote Command Station")	%pntval = $Score::ObjStationR;
			
				if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
				if (%objname == "Vehicle Pad")				%pntval = $Score::ObjFlier;
				
				//=============================================================================
				if (%objname == "Plasma Turret")
				{
					%pntval = $Score::ObjTurretL;
					if (GameBase::isPowered(%this))
						%pntval = floor(%pntval * 2);
				}
				
				if (%objname == "ELF Turret")				
				{
					%pntval = $Score::ObjTurretL;
					if (GameBase::isPowered(%this))
						%pntval = floor(%pntval * 2);
				}
				
				if (%objname == "Rocket Turret")			
				{
					%pntval = $Score::ObjTurretL;
					if (GameBase::isPowered(%this))
						%pntval = floor(%pntval * 2);
				}
				
				if (%objname == "Mortar Turret")			
				{
					%pntval = $Score::ObjTurretL;
					if (GameBase::isPowered(%this))
						%pntval = floor(%pntval * 2);
				}
				
				if (%objname == "Indoor Turret")
				{
					%pntval = $Score::ObjTurretL;
					if (GameBase::isPowered(%this))
						%pntval = floor(%pntval * 2);
				}
		
				if (%objname == "Remote Mortar Turret")			%pntval = $Score::ObjTurretS;
				if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
				if (%objname == "Remote Plasma Turret")			%pntval = $Score::ObjTurretS;
				if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
				if (%objname == "Point Defense Laser Mine")		%pntval = $Score::ObjTurretS;
				if (%objname == "EMP Turret")					%pntval = $Score::ObjTurretS;
				if (%objname == "Satchel Charge")				%pntval = $Score::ObjTurretS;
				if (%objname == "Deployable Elf Turret")		%pntval = $Score::ObjTurretS;
				if (%objname == "Deployable Targeting Turret")	%pntval = $Score::ObjTurretS;
				if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
				if (%objname == "Camera")						%pntval = $Score::ObjTurretS;

				if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
				if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
				if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
				if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
				if (%objname == "Remote Sensor Jammer")			%pntval = $Score::ObjSensorS;
			//=================================================================================== End Of Point Values
			
			%item = Player::getMountedItem(%playerClient,$WeaponSlot);

			if (%thisTeam == %destroyerTeam) //========================================================= Goof ball destroyed his own stuff.
			{
				echo ("*** " @ %clientName @ " Destoyed His Own " @ %objname @ " Naughty Naughty...");
				
				 if ((%item == "Mortar") || (%item == "Mfgl"))
				 	%pntval = floor(%pntval / 2);				

		        %playerClient.score = (%playerClient.score - %pntval);
			    if ($ScoreOn) bottomprint(%playerClient, "Destroyed Friendly " @ %objname @ ". Score - " @ %pntval @ " = " @ %playerClient.score @ " Total Score", 2);
			}
			
				if (%pntval > 0)
				{
					if (%thisTeam != %destroyerTeam) //=========================================================== Good job taking out enemy stuff.
					{			
						echo ("*** " @ %clientName @ " Took out the enemys " @ %objname @ " YEAH!");
		
						 if ((%item == "Mortar") || (%item == "Mfgl"))
						 	%pntval = floor(%pntval / 2);				
		
				        %playerClient.score = (%playerClient.score + %pntval);
					    if ($ScoreOn) bottomprint(%playerClient, "Destroyed Enemy " @ %objname @ ". Score + " @ %pntval @ " = " @ %playerClient.score @ " Total Score", 2);
					}	
				}
					Game::refreshClientScore(%playerClient);		
					echo ("*** Object Destroy Scoring Done");					
		}
		else //================================================================================== Award Objective Destroy And Player Points
		{
	   		%destroyerTeam = %this.lastDamageTeam;
			%thisTeam = GameBase::getTeam(%this);
	        %playerClient = GameBase::getControlClient(%this.lastDamageObject);
	    	
			if(%playerClient != -1)
	            %clientName = Client::getName(%playerClient);
	
		   	if(%thisTeam == %destroyerTeam)
		   	{
			   	   //==== uh-oh... we killed our own stuff.
			   	   //==== award the points to everyone else
			
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
	            MessageAll(1, getTeamName(%destroyerTeam) @ " objective " @ %this.objectiveName @ " destroyed.");
	    	}
	    	else
	    	{
	    	   $teamScore[%destroyerTeam] += %this.scoreValue;
	           if(%playerClient != -1)
	           {
				    %playerClient.score = (%playerClient.score + $Score:ObjDestroy);
				   
				   //================================================================================================ Bonus For Obj Destory
	               %playerClient.score = (%playerClient.score + $Score::ObjDestroy);
		   		   if ($ScoreOn) bottomprint(%playerClient, "Score + " @ $Score::ObjDestroy @ " = " @ %playerClient.score @ " Total Score", 4);

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
}

function StaticShape::objectiveDisabled(%this)
{
}


//==================================================================================================================== Bots Return The Flag
function Flag::AIReturnFlag(%flag)  //The nearest AI player should now come and return the flag. by Werewolf
{
			   %flagTeam = GameBase::getTeam(%flag);
			   %minDistance = 999999;
			   %startCl = Client::getFirst();	//Browse through all clients and check for bots.
			   %endCl = %startCl + 90;
			   for(%cl = %startCl; %cl < %endCl; %cl = %cl + 1)
			       if (Player::isAIControlled(%cl)) //Is this a bot?
			       {
			        	%aiName = Client::getName(%cl);
				    	%aiTeam = Client::getTeam(%cl);
						if (%aiTeam==%flagTeam)
						{
							%curDistance = Vector::getDistance(GameBase::getPosition(%flag), Client::getPosition(%cl));
				   			if(%curDistance < %minDistance)      //============================== Is this bot closer than his predecessors?
							{
								  %minDistance = %curDistance;
								  %nearestAI = %cl;              //================= If yes, he's probably the best bet to return the flag.
								  %nearestAIName = Client::getName(%cl);
							}
				 		}
			       }

			   echo (1, "Nearest AI is " @ %nearestAI @ " " @ %nearestAIName @ ". He now tries to return the flag");

			   //TeamMessages(1, %flagTeam, "Bot " @ %nearestAIName @ " tries to return our flag", -2, "", "The " @ getTeamName(%playerTeam) @ " bots try to return their flag to their base!!");

			   Flag::setWaypoint(%nearestAI, %flag);  //Make the closest bot head for the flag.

			//End of AI returning the flag.

}