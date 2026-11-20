//  Mod to keep players on even teams
//
//  Originally written by Shane Hyde
//  Download it from http://www.users.bigpond.net.au/shyde/tribes/
//
//  Modified for use with Shifter, (http://www.dopplegangers.com/tribes/shifter/)

//  Name & version
//

$modmgtModName = "YyFairTeams";
$modmgtModVers = "0.9b";

function SHResetStats()
{
	// echo("Executing reset stats");

	%numteams = getNumTeams();
	%numPlayers = getNumClients();

	$YyNonPlayers = 0;
	for(%i = 0; %i < %numTeams; %i++)
	{
		$YyTeamPlayers[%i] = 0;
	}
	$YyMinPlayers = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%team = Client::getTeam(%cl);
		if($InfTime[%cl] > 0 && %cl.origTeam != "")
			%team = %cl.origTeam;

		if(!Player::isAIControlled(%cl))
		{
			if(%team >= 0)
				$YyTeamPlayers[%team]++;
			else
				$YyNonPlayers++;
		}
	}
	$YyMinPlayers = floor((%numPlayers-$YyNonPlayers)/%numTeams);
	if($YyMinPlayers <= 0) $YyMinPlayers = 1;
}

function DumpStats()
{
    	%numteams = getNumTeams();
    	if($debug) echo("MinTeamPlayers " @ $SHMinTeamPlayers);
		if($debug) echo("MinTeamScore " @ $SHMaxteamScore);
    	for(%i=0;%i<%numteams;%i++)
    	{
	  	  if($debug) echo("Team " @ %i);
      	  if($debug) echo("Player count " @ $SHNumTeamPlayers[%i]);
      	  if($debug) echo("MinClient " @ $SHMinTeamClient[%i]);
      	  if($debug) echo("MinClient name: " @ Client::getName($SHMinTeamClient[%i]));
	  	  if($debug) echo("MinClientScore " @ $SHMinTeamScore[%i]);
    	}
}

function EvenTeams()
{
	
	if ($Shifter::FairTeams == "False")
	{
		echo("ADMINMSG: *** Fair Teams Is OFF");
		return;
	}

	%numteams = getNumTeams();
	%numPlayers = getNumClients();

	SHResetStats();
	for(%i = 0; $YySwitchTarget[%i] != ""; %i++)
	{
		%cl = $YySwitchTarget[%i];
		%team = Client::getTeam(%cl);
		if($InfTime[%cl] > 0 && %cl.origTeam != "")
			%team = %cl.origTeam;
		if($YyTeamPlayers[%team] > $YyMinPlayers && %team >= 0)
		{
			for(%j = 0; %j < %numTeams; %j++)
			{
				if($YyTeamPlayers[%j] < $YyMinPlayers)
				{
					processmenuPickTeam(%cl,%j,"");
					messageAllExcept(%cl,0,Client::getName(%cl)@" was switched to even the teams.");
					Client::sendMessage(%cl,1,"You have been switched to even the teams.~waccess_denied.wav");
					$YyTeamPlayers[%team]--;
					$YyTeamPlayers[%j]++;
					//=== In case the break call doesn't work
					%j = %numTeams;
					break;
				}
			}
		}
		$YySwitchTarget[%i] = "";
	}
}

function CheckTeamsAreEven()
{
	
	if ($Shifter::FairTeams == "False")
	{
		echo("ADMINMSG: *** Fair Teams Is OFF");
		return;
	}
	
	echo("ADMINMSG: **** Shifter Is Checking For Even Teams");

	%numPlayers = getNumClients();
	%numTeams = getNumTeams();

	SHResetStats();
	%needs = 0;
	for(%i = 0; %i < %numTeams; %i++)
	{
		%switchCount[%i] = $YyTeamPlayers[%i];
		if($YyTeamPlayers[%i] < $YyMinPlayers)
			%needs += $YyMinPlayers - $YyTeamPlayers[%i];
	}
	%i = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%team = Client::getTeam(%cl);
		if($InfTime[%cl] > 0 && %cl.origTeam != "")
			%team = %cl.origTeam;
		if(%switchCount[%team] > $YyMinPlayers && %team >= 0 && %needs > 0)
		{
			$YySwitchTarget[%i] = %cl;
			%switchCount[%team]--;
			%needs--;
			%i++;
		}
	}
	$YySwitchTarget[%i] = "";

	if(%i > 0)
	{
		SortChangeList();
		%bob = false;
		%msg = "The following players need to switch sides to even the teams: ";
		for(%i = 0; $YySwitchTarget[%i] != "";%i++)
		{
			%cl = $YySwitchTarget[%i];
			Client::sendMessage(%cl,1,"You must switch sides in order to even the teams.~waccess_denied.wav");
			centerprint(%cl,"<jc><f1>The teams are uneven, you must switch.",2); //Use the old message for backwards compatibility with old player scripts
			schedule("centerprint("@%cl@",\"<jc><f1>You must switch sides in order to even the teams.\",10);",2);
			%name = Client::getName(%cl);
			if(%bob)
				%msg = %msg @", ";
			%msg = %msg @""@%name;
			%bob = true;
		}
		if(%i > 0)
		{
			%msg = %msg@".";
			messageAll(1,%msg);
			bottomprintAll("<jc><f1>The teams are uneven. "@ %i @" players must switch sides in order to even them.",10);
			if($Shifter::FairCheck <= $Shifter::FairEvens)
				$Shifter::FairEvens = $Shifter::FairCheck - 1;
			schedule("eventeams();",$Shifter::FairEvens);
		}
	}
	schedule("CheckteamsAreEven();",$Shifter::FairCheck);
}

//=== Bubblesorts the list of players who need to change teams, based on the time at which they joined the team
function SortChangeList()
{
	for(%i = 1;$YySwitchTarget[%i] != ""; %i++)
	{
		%cur = $YySwitchTarget[%i-1];
		%next = $YySwitchTarget[%i];

		if(%next != "")
		{
			if(%cur.TeamJoinTime < %next.TeamJoinTime)
			{
				$YySwitchTarget[%i-1] = %next;
				$YySwitchTarget[%i] = %cur;
				%i = 0;
			}
		}
	}
}

if ($Shifter::FairTeams != "False")
{
	if ($Shifter::FairCheck > 0) schedule("CheckteamsAreEven();",$Shifter::FairCheck);
	if ($Shifter::FairEvens > 0) schedule("EvenTeams();",$Shifter::FairEvens);
	$SHFairTeams = 1;
	echo($modmgtModName @ " v" @ $modmgtModVers @ " loaded");
}