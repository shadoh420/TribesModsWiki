//  Mod to keep players on even teams
//
//  Originally written by Shane Hyde
//  Download it from http://www.users.bigpond.net.au/shyde/tribes/
//
//  Modified for use with Shifter, (http://www.dopplegangers.com/tribes/shifter/)

//  Name & version
//

if($Shifter::newFairTeams == "false")
{
	$modmgtModName = "SHFairteams2";
	$modmgtModVers = "1.30";
}
else
{
	$modmgtModName = "YyFairTeams";
	$modmgtModVers = "0.9b";
}

function SHResetStats()
{
	// echo("Executing reset stats");

	%numteams = getNumTeams();
	%numPlayers = getNumClients();

	if($Shifter::newFairTeams == "false")
	{
		for(%i = 0; %i < %numTeams; %i = %i + 1)
		{
			$SHNumTeamPlayers[%i] = 0;
			$SHMinTeamScore[%i] = 0;
		}

		$SHMinTeamPlayers = 9999;
		$SHMaxTeamScore = 9999;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);
			%team = Client::getTeam(%pl);
			//=== Modify some stuff to work properly with infiltration
			if($InfTime[%pl] > 0 && %pl.origTeam != "")
				%team = %pl.origTeam;

			$SHNumTeamPlayers[%team] = $SHNumTeamPlayers[%team] + 1;

			if(%pl.SHAddOrder  > $SHMinTeamScore[%team])
			{
				$SHMinTeamScore[%team] = %pl.SHAddOrder ;
				$SHMinTeamClient[%team] = %pl;
			}
		}
		for(%i=0;%i<%numteams;%i++)
		{
			if($SHNumTeamPlayers[%i] < $SHMinTeamPlayers)
			{
				$SHMinTeamPlayers = $SHNumTeamPlayers[%i];
			}
			if($TeamScore[%i] < $SHMaxTeamScore)
			{
				$SHMaxTeamScore = $teamScore[%i];
			}
		}
	}
	else
	{
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

	if($Shifter::newFairTeams == "false")
	{
		if($SHAddOrder == "")
			$SHAddOrder = 1;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);
			if(%pl.SHAddOrder == "")
			{
				%pl.SHAddOrder = $SHAddOrder;
				$SHAddOrder++;
			}
		}

		SHResetStats();
		DumpStats();

		if($SHFairTeams == "")
		{
			return;
		}
	
		for(%i = 0; %i < %numTeams; %i = %i + 1)
		{
			if(($SHNumTeamPlayers[%i]-1 > $SHMinTeamPlayers || ($SHNumTeamPlayers[%i] > $SHMinTeamPlayers && %teamscore[%i] > $SHMaxTeamScore ))	&& $SHNumTeamPlayers[%i] > 2)
			{
				if(%numteams == 2)
				{
					if($SHNumTeamPLayers[%i] > $SHNumTeamPlayers[1-%i]+1)
					{
						processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
						bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switched sides to even the teams.", 5); 
						centerprint($SHMinTeamClient[%i],"<jc><f2>The teams were uneven, you have been switched.", 10);
						return;
					}
					else
					{
						processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
						bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switched sides to even the teams.", 5); 
						centerprint($SHMinTeamClient[%i],"<jc><f2>The teams were uneven, you have been switched.", 10);
					}
				}
				else
				{
					processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
					bottomprintall( Client::getName($SHMinTeamClient[%i]) @ " has switched sides to even the teams.", 5); 
					centerprint($SHMinTeamClient[%i],"<jc><f2>The teams were uneven, you have been switched.", 10);
				}
			}
		}
	}
	else
	{
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

	if($Shifter::newFairTeams == "false")
	{
		if($SHAddOrder == "")
			$SHAddOrder = 1;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);
			if(%pl.SHAddOrder == "")
			{
				%pl.SHAddOrder = $SHAddOrder;
				$SHAddOrder++;
			}
		}
		SHResetStats();
	
		if($SHFairTeams == "")
		{
			schedule("CheckteamsAreEven();",$Shifter::FairCheck);
			return;
		}
	
		for(%i = 0; %i < %numTeams; %i = %i + 1)
		{
			if(($SHNumTeamPlayers[%i]-1 > $SHMinTeamPlayers || ($SHNumTeamPlayers[%i] > $SHMinTeamPlayers && %teamscore[%i] > $SHMaxTeamScore )) && $SHNumTeamPlayers[%i] > 2)
			{
				if(%numteams == 2)
				{
					if($SHNumTeamPLayers[%i] > $SHNumTeamPlayers[1-%i]+1)
					{
						//processmenuPickTeam($SHMinTeamClient[%i],1-%i,"");
						%name = Client::getName($SHMinTeamClient[%i]);
						%name = String::replace(%name,"\<", " ");
						%name = String::replace(%name,"\>", " ");
						bottomprintall(%name @ " needs to switch sides to even the teams.", 10); 
						echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***"); 
						centerprint($SHMinTeamClient[%i],"<jc><f2>The teams are uneven, you must switch.", 15);
						schedule("CheckteamsAreEven();",$Shifter::FairCheck);
						schedule("eventeams();",$Shifter::FairEvens);
						return;
					}
					else
					{
						//processMenuPickTeam($SHMinTeamClient[%i],-2,"");
						%name = Client::getName($SHMinTeamClient[%i]);
						%name = String::replace(%name,"\<", " ");
						%name = String::replace(%name,"\>", " ");
						bottomprintall( %name @ " needs to switch sides to even the teams.", 10); 
						echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***"); 
						centerprint($SHMinTeamClient[%i],"<jc><f2>The teams are uneven, you must switch.", 15);
						schedule("eventeams();",$Shifter::FairEvens);
					}
	
				}
				else
				{
					//processMenuPickTeam($SHMinTeamClient[%i],-2,"");
					%name = Client::getName($SHMinTeamClient[%i]);
					%name = String::replace(%name,"\<", " ");
					%name = String::replace(%name,"\>", " ");
					bottomprintall(%name @ " needs to switch sides to even the teams.", 10); 
					echo("ADMINMSG: **** " @ Client::getName($SHMinTeamClient[%i]) @ " needs to switch sides to even the teams. ***"); 
					centerprint($SHMinTeamClient[%i],"<jc><f2>The teams are uneven, you must switch.", 15);
					schedule("eventeams();",$Shifter::FairEvens);
				}
			}
		}
	}
	else
	{
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