//********************************************************************************************
// Support for the Campaign maps.
// Campaign will do the following:
// - Keep track how many missions have been played
// - Keep track of how many people on each side have died
// - Keep track of how much money was spent on each side
// - Keep track of total points from each side
// - Keep track of how long the campaign took in total
// - Keep track of a list of missions in the campaign started
// - When a mission ends, decide (based on who won) to proceed forward with the campaign, or 
//   reverse to the previous mission.
// - When the campaign reaches an end (defenders win on the first mission, or attackers win
//   on the last mission) display all the campaign information, in the O screen, announce
//   the winner, and start normal ServerSide rotation again.
//
// NOTE: This campaign module is made only for two teams. Otherwise.. the third team doesn't
//       have a way of winning, since it's a linear progression. And having two teams only 
//       makes it easier on me :D
//
//********************************************************************************************
//                       ---==Designing Missions To Use This Module==---
// When you make a set of missions to use for this module, they must all be named the same, 
// and have the suffix "XX" where XX represents the number of the mission in the sequence.
// For example, the first misison will be "01" the second "02" the tenth "10" the and the
// ninty-ninth "99". Note that you can only have up to 99 missions in one campaign (I figure
// that that'll be sufficient given that most missions take 30-60 minutes to complete...).
// You can have as few as one mission in a campaign. I suggest having between 3 and 5, since
// as mentioned, most games will be at least a half-hour long, and the defenders probably
// will win a few.
// The Missions can be of any type as far as I know, although I suggest making them the 
// new type of capture and hold (where the first to capture all switches wins).
// Besides that, the game type in the *.dsc file should be:
// $MDESC::Type = "Campaign";
// for each mission in the campaign, and the following variables need to be set:
// $Campaign::DefendingTeam
// $Campaign::AttackingTeam
// These two variables need to be set in the *.mis file. One will be 0, the other 1.
// They *must* remain constant through the rest of the campaign once set. So if you design
// a campaign, be sure that team0 stays the defending team if they were set to defending
// for the first mission in the campaign, or that they stay the attacking team if they were
// set to attacking for the first mission, and that team1 is the opposite, and stays there.
//********************************************************************************************
//         ----==Note for those who want to use this with a mod other then DUNE==---
// First, this (obviously) was made for DUNE. I give no garuntee you'll be able to make it
// work in another mod. Second, besides this module and the additions to the missions, you'll
// need to modify the following files (I think these are the only ones I did):
// Admin.cs, Server.cs, Objectives.cs, MissionList.cs
// I'd suggest a search for "campaign" to find out all the stuff you'll need to fix.
// Sorry I didn't make it more portable then that.
//********************************************************************************************

// Campaign::NumMissions[<Campaign-name>] = <number of missions in campaign>
// Campaign::CurMission = <number of the map we're on (or 0 if not in a campaign)>
// Campagin::CurCampaign = <name of the campaign we're on>
// Campaign::TotalKills[<team number>] = <kills>
// Campaign::TotalDeaths[<team number>] = <deaths>
// Campaign::TotalPoints[<team number>] = <points>
// Campaign::TotalCashSpent[<team number>] = <cash>
// Campaign::TotalTime = <cumulative time>
// Campaign::TotalMissions = <number times the mission changed>

// Mission to begin on after a campaign.
$Campaign::postCampaignMission = "DUNE_Ambush";

// We never start on a campaign, so always initialize this to 0
$Campaign::isCampaign = 0; // Tells us if this is a campaign or not

//-----------------------------------------------------------------------
// Name: beginCampaign
//
// Will start off a campaign of the specified name
// This will be called from a tab menu mission change
//  either from a vote or an admin change.
// This will handle starting the campaign and initializing
//  variables.
// %campaignName is the name of the campaign. Numbers need to be added
//               to make it a mission.
//-----------------------------------------------------------------------
function Campaign::beginCampaign(%campaignName)
{
	echo("***Starting New Campaign***");
//	return;
	$Campaign::CurMission = 1;
	$Campaign::CurCampaign = %campaignName;
	$Campaign::isCampaign = 1;
	$Campaign::JustStarted = 1;
	$Campaign::TotalKills[0] = 0;
	$Campaign::TotalDeaths[0] = 0;
	$Campaign::TotalPoints[0] = 0;
	$Campaign::TotalCashSpent[0] = 0;
	$Campaign::TotalKills[1] = 0;
	$Campaign::TotalDeaths[1] = 0;
	$Campaign::TotalPoints[1] = 0;
	$Campaign::TotalCashSpent[1] = 0;

	$Campaign::TotalTime = 0;
	$Campaign::TotalMissions = 0;

	Campaign::beginMission(Campaign::getNextMission());
}


//-----------------------------------------------------------------------
// Name: beginMission
//
// Will start the next mission in the list (given to it by endMission)
//
// %mission Full name of the mission to start.
//-----------------------------------------------------------------------
function Campaign::beginMission(%mission)
{
echo(%mission);
	server::loadmission(%mission);
}


//-----------------------------------------------------------------------
// Name: endMission
//
// Ends the current mission, determines which mission to move on to,
// and ends the campaign if need be.
//
//
//-----------------------------------------------------------------------
function Campaign::endMission()
{
echo("Ended");
	// Who won?
	// Give the defenders the win for a tie.
	if($teamScore[$Campaign::DefendingTeam] >= $teamScore[$Campaign::AttackingTeam])
		%winnerTeam = $Campaign::DefendingTeam;
	else
		%winnerTeam = $Campaign::AttackingTeam;
	// Are they the attacker?
	if(%winnerTeam == $Campaign::AttackingTeam)
		$Campaign::CurMission++;
	else
		$Campaign::CurMission--;

	Campaign::addUpStats();
	// Are we out of bounds?
	if($Campaign::CurMission < 1 || $Campaign::CurMission > $Campaign::NumMissions[$Campaign::CurCampaign])
	{
		// Then the winnerTeam has won the campaign
		Campaign::endCampaign(1);
	} else
	{
		%next = Campaign::getNextMission();
		$Campaign::LoadingMission = 1; // This line was added to fix the mission change out of campaing bug.
		// Load next mission
		Campaign::beginMission(%next);
	}
}


//-----------------------------------------------------------------------
// Name: addUpStats
//
// Adds up everything we want to see at campaign end.
//
//
//-----------------------------------------------------------------------
function Campaign::addUpStats()
{
	// Add things up
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
	{

		$Campaign::TotalKills[Client::getTeam(%i)] = $Campaign::TotalKills[Client::getTeam(%i)] + %i.scoreKills;
		$Campaign::TotalDeaths[Client::getTeam(%i)] = $Campaign::TotalDeaths[Client::getTeam(%i)] + %i.scoreDeaths;
		$Campaign::TotalPoints[Client::getTeam(%i)] = $Campaign::TotalPoints[Client::getTeam(%i)] + %i.score;
		$Campaign::TotalCashSpent[Client::getTeam(%i)] = $Campaign::TotalCashSpent[Client::getTeam(%i)] - %i.teamenergy; // TE is stored as negative.
	}

	$Campaign::TotalTime = $Campaign::TotalTime + (getSimTime() - $missionStartTime);
	$Campaign::TotalMissions++;

}

//-----------------------------------------------------------------------
// Name: endCampaign
//
// Will close out our campaign, give a special O menu for mission end,
// and start normal serverside rotation.
//
//-----------------------------------------------------------------------
function Campaign::endCampaign(%noload)
{
	echo("***Ending "@$Campaign::CurCampaign@" Campaign***");

	$Campaign::isCampaign = 0;
	$Campaign::CurMission = 0;
	$Campaign::CurCampaign = "";

	// Start normal rotation
	if(%noload)
	server::loadmission($Campaign::postCampaignMission);
}

//-----------------------------------------------------------------------
// Name: getNextMission
//
// Via the Campaign name and current mission, we'll find out which
// mission is ready to load. 
//
//-----------------------------------------------------------------------
function Campaign::getNextMission()
{
	// We've got to add a 0 if it's a one digit number.
	if(String::length($Campaign::CurMission) == 1)
		%addon = "0" @ $Campaign::CurMission;
	return $Campaign::CurCampaign @ %addon;
}

//-----------------------------------------------------------------------
// Name: ShowMissionComplete
//
// Figure out if we want to show mission end, or campaign end screen.
//
//-----------------------------------------------------------------------
function Campaign::ShowMissionComplete()
{
echo("ShowMissionComplete");
   	// I hate to repeat but... I'm lazy, resulting in more work!

	if($teamScore[$Campaign::DefendingTeam] >= $teamScore[$Campaign::AttackingTeam])
		%winnerTeam = $Campaign::DefendingTeam;
	else
		%winnerTeam = $Campaign::AttackingTeam;

	// Are they the attacker?
	if(%winnerTeam == $Campaign::AttackingTeam)
		%curmis = $Campaign::CurMission + 1;
	else
		%curmis = $Campaign::CurMission - 1;

	if(%curmis < 1 || %curmis > $Campaign::NumMissions[$Campaign::CurCampaign])
	{
		Campaign::CampaignComplete(%winnerTeam);
	} else
	{
		Campaign::missionComplete(%winnerTeam);
	}
   // back out of all the functions...
   schedule("Server::nextMission();", 0);
}

//-----------------------------------------------------------------------
// Name: missionComplete
//
// Same as what's in objectives.cs
//
//-----------------------------------------------------------------------
function Campaign::missionComplete(%winnerTeam)
{
   $missionComplete = true;
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
   }
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $OMCOS::MissionBriefing-1, " ");
	   Team::setObjective(%i, $OMCOS::MissionBriefing, "<f5>Mission Summary:");
		for(%x=0;$MissionBriefing[%x] != "";%x++)
		{
	   Team::setObjective(%i, $OMCOS::MissionBriefing+%x+1, " ");
		}
	}
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
   $missionComplete = false;

}

//-----------------------------------------------------------------------
// Name: CampaignComplete
//
// End of Campaign stats.
//
//-----------------------------------------------------------------------
// Campaign::NumMissions[<Campaign-name>] = <number of missions in campaign>
// Campaign::CurMission = <number of the map we're on (or 0 if not in a campaign)>
// Campagin::CurCampaign = <name of the campaign we're on>
// Campaign::TotalDeaths[<team number>] = <deaths>
// Campaign::TotalPoints[<team number>] = <points>
// Campaign::TotalCashSpent[<team number>] = <cash>
// Campaign::TotalTime = <cumulative time>
// Campaign::TotalMissions = <number times the mission changed>
function Campaign::CampaignComplete(%winnerTeam)
{
	Campaign::addUpStats();

	$missionComplete = true;
//	%group = nameToID("MissionCleanup/ObjectivesSet");
//	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
//	{
//		ObjectiveMission::objectiveChanged(%obj);
//	}
	for(%i = 0; %i < getNumTeams(); %i++) { 
		Team::setObjective(%i, $OMCOS::MissionBriefing-2, "<f9><jc>"@$Campaign::CurCampaign@" Campaign End");
		
		%loserTeam = (%winnerTeam-1)*(%winnerTeam-1);
		%nameWin = $KeyNameToFullName[$ServerNameToKeyName[%winnerTeam]];
		%nameLose = $KeyNameToFullName[$ServerNameToKeyName[%loserTeam]];
		if(%winnerTeam == $Campaign::AttackingTeam)
			Team::setObjective(%i, $OMCOS::MissionBriefing-1, "<jc><f5>"@%nameWin@" has defeated "@%nameLose@"!");
		else
			Team::setObjective(%i, $OMCOS::MissionBriefing-1, "<jc><f5>"@%nameWin@" has fought back "@%nameLose@"!");

		for(%x=0;$MissionBriefing[%x] != "";%x++)
		{
			Team::setObjective(%i, $OMCOS::MissionBriefing+%x, " ");
		}
		%x=0;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "<f5>Campaign Summary:");
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f2>Missions in Campaign - <f3>"@$Campaign::NumMissions[$Campaign::CurCampaign]);
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f2>Total Missions Played - <f3>"@$Campaign::TotalMissions);
		%x++;
		
		%min = floor($Campaign::TotalTime/60);
		if(%min == 1 || %min = -1)
			%min = %min @ " minute and ";
		else
			%min = %min @ " minutes and ";
		%sec = $Campaign::TotalTime%60;
		if(%sec == 1 || %sec = -1)
			%sec = %sec @ " second";
		else
			%sec = %sec @ " seconds";
	
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f2>Total Time Played - <f3>"@%min@%sec);
		%x++;

		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, " ");
		%x++;

		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "<f5>Campaign Summary For winners, "@%nameWin@":");
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Points - <f4>"@$Campaign::TotalPoints[%winnerTeam]);
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Cash Spent - <f4>"@Format_money($Campaign::TotalCashSpent[%winnerTeam]));
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Kills - <f4>"@$Campaign::TotalKills[%winnerTeam]);
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Deaths - <f4>"@$Campaign::TotalDeaths[%winnerTeam]);
		%x++;

		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, " ");
		%x++;

		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "<f5>Campaign Summary For losers, "@%nameLose@":");
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Points - <f4>"@$Campaign::TotalPoints[%loserTeam]);
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Cash Spent - <f4>"@Format_money($Campaign::TotalCashSpent[%loserTeam]));
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Deaths - <f4>"@$Campaign::TotalDeaths[%loserTeam]);
		%x++;
		Team::setObjective(%i, $OMCOS::MissionBriefing+%x, "\t<f1>Total Kills - <f4>"@$Campaign::TotalKills[%loserTeam]);
		%x++;

		// Clear out anything else.
		for(%j = %x; %j <= 50; %j++)
		{
			Team::setObjective(%i, $OMCOS::MissionBriefing+%j, " ");
		}
		
	}

//	ObjectiveMission::setObjectiveHeading();
//	ObjectiveMission::refreshTeamScores();
	%lineNum = "";
	$missionComplete = false;
}


function format_money(%amt)
{
	if(%amt == "")
		%amt = 0;
	if(String::GetSubStr(%amt,0,1) == "-")	
	{
		%neg = "-";
		%amt = String::GetSubStr(%amt,1,String::length(%amt));
	}	
	else
		%neg = "";

	for(%x = String::length(%amt)-3; %x >= -3; %x-=3)
	{
		if(%x <= 0)
			%add = String::getsubstr(%amt,0,3+%x);
		else
			%add = String::getsubstr(%amt,%x,3);

		if(%x == (String::length(%amt)-3))
			%return = %add;
		else
			%return = %add @ "," @ %return;
	}
	if(String::GetSubStr(%return,0,1) == ",")
		%return = String::GetSubStr(%return,1,String::length(%return));
	%return = "$" @ %neg @ %return;
	return %return;
}
