
%dmgstr = "";


for(%x = -1; %x<21; %x++)
{
%dmgstr = %dmgstr @ $DamageName[%x] @ "kill ";
}
for(%x = 100; %x<109; %x++)
{
%dmgstr = %dmgstr @ $DamageName[%x] @ "kill ";
}



%weaps = "Knife SOCOM OICW SAW MP5 PSG1 FiftyCal Shotgun LAW";
%weapstr = "";
%x = 0;
while(getword(%weaps, %x) != -1)
	{
	%w = getword(%weaps, %x); 
	%x++;
	%weapstr = %weapstr @ %w @ "fired ";
	}

$AAI::GameStatsList = "TKS armshotout legsshotout bleed damagetaken distance timeingame timeingamelast causedradio headshots shotshit shotsfired timestargetted AIsDisarmed shotsheard grenthrown grenheard parachute "@ %dmgstr @" "@%weapstr@" kills resurrects medic enemymedic revived failedpara";

function AAI::AddToStats(%cl, %stat, %value)
{
	if(%cl.ingame)
	{
		if(!%value)
			$AAI::GameStats[%cl, %stat]++;
		else
			$AAI::GameStats[%cl, %stat] += %value;

		Game::refreshClientScore(%cl);
	}

}

function AAI::ResetStats()
{
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
		%x = 0;
		while(getword($AAI::GameStatsList, %x) != -1)
		{
			%w = getword($AAI::GameStatsList, %x); 
			%x++;
			$AAI::GameStats[%i, %w] = 0;
			Game::refreshClientScore(%i);
		}
	}
}

function AAI::ResetPlayerStats(%i)
{
	
	while(getword($AAI::GameStatsList, %x) != -1)
	{
			%w = getword($AAI::GameStatsList, %x); 
			%x++;
			$AAI::GameStats[%i, %w] = 0;
			Game::refreshClientScore(%i);
	}
	
}

$AAI::AwardCount = 0;
$AAI::Award[$AAI::AwardCount] = "Accuracy";
$AAI::AwardCalc[$AAI::AwardCount] = "<shotshit>/<shotsfired> * 100";
$AAI::AwardGeneral[$AAI::AwardCount] = 1;
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Sharpshooter";
$AAI::AwardCalc[$AAI::AwardCount] = "((<shotshit>/<shotsfired>)-0.9)*1000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "I don't miss";
$AAI::AwardCalc[$AAI::AwardCount] = "((<shotshit>/<shotsfired>)-1.05)*100000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Mr. Spray and Pray";
$AAI::AwardCalc[$AAI::AwardCount] = "-100*(<shotshit>/<shotsfired>)";
$AAI::AwardNoMin[$AAI::AwardCount] = 1;
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Live Bait";
$AAI::AwardCalc[$AAI::AwardCount] = "<timestargetted> * 25";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Bear in a China Shop";
$AAI::AwardCalc[$AAI::AwardCount] = "<shotsheard> + (<grenthrown> * 2) + (<grenheard> * 10)";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Honorary Emu";
$AAI::AwardCalc[$AAI::AwardCount] = "<failedpara> * 100000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Rambo";
$AAI::AwardCalc[$AAI::AwardCount] = "<shotsfired> + <grenthrown> * 20 + <kills> * 10";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Bambi";
$AAI::AwardCalc[$AAI::AwardCount] = "(-10 * <kills>)";
$AAI::AwardNoMin[$AAI::AwardCount] = 1;
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Red Cross Hero";
$AAI::AwardCalc[$AAI::AwardCount] = "2*<medic> + <resurrects * 50>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Humanitarian of the Year";
$AAI::AwardCalc[$AAI::AwardCount] = "<enemymedic>*10000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Bring 'em on!";
$AAI::AwardCalc[$AAI::AwardCount] = "<causedradio>*300";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Most Deadly";
$AAI::AwardCalc[$AAI::AwardCount] = "<kills> * 10 + <headshots> * 100";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Pyromaniac";
$AAI::AwardCalc[$AAI::AwardCount] = "<grenthrown> * 5 + <grenadekill> * 20 + <lawfired> * 30 + <lawkill> * 100";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Necromancer";
$AAI::AwardCalc[$AAI::AwardCount] = "(<resurrects> - 2) * 1000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Necrophiliac";
$AAI::AwardCalc[$AAI::AwardCount] = "(<revives> - 2) * 1000";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "I hate parachutes";
$AAI::AwardCalc[$AAI::AwardCount] = "1 - (<parachute> ) * "@$AAI::ParadropMission@"";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "World Traveller";
$AAI::AwardCalc[$AAI::AwardCount] = "10 * <distance>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Benedict Arnold";
$AAI::AwardCalc[$AAI::AwardCount] = "100 * <TKS>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "I like Pain";
$AAI::AwardCalc[$AAI::AwardCount] = "50 * <damagetaken>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Gimpy";
$AAI::AwardCalc[$AAI::AwardCount] = "50 * <legsshotout> + 50 * <armshotout>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Blooooooood!";
$AAI::AwardCalc[$AAI::AwardCount] = "25 * <bleed>";
$AAI::AwardCount++;

$AAI::Award[$AAI::AwardCount] = "Stabby Stabby";
$AAI::AwardCalc[$AAI::AwardCount] = "150 * <knifekill> + (<knifefired> - 20) * 2";
$AAI::AwardCount++;


%x = 0;
while(getword(%weaps, %x) != -1)
{
%w = getword(%weaps, %x); 
%x++;
$AAI::Award[$AAI::AwardCount] = %w@" Whore";
$AAI::AwardCalc[$AAI::AwardCount] = "((<"@%w@"fired> / <shotsfired>)-0.55) * 2000";
$AAI::AwardCount++;

}


function AAI::CalcStats()
{
	for(%x = 0; %x<$AAI::AwardCount; %x++)
	{
		%winnercalc[%x] = "null";
		%winnercl[%x] = -1;
		%ties[%x] = 0;
	}


	
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
		$AAI::ClientAwardList[%i] = "";
		for(%x = 0; %x<$AAI::AwardCount; %x++)
		{
		%calc = String::ReplaceAll($AAI::AwardCalc[%x], "<", "$AAI::GameStats["@%i@", \"");
		%calc = String::ReplaceAll(%calc, ">", "\"]");
		
		eval("$AAI::GameStats["@%i@", \""@$AAI::Award[%x]@"\"] = "@%calc@";");
		%calc = $AAI::GameStats[%i, $AAI::Award[%x]];
		if(%calc == "")
			%calc = 0;

		echo(%i@" got "@$AAI::GameStats[%i, $AAI::Award[%x]]@" in "@$AAI::Award[%x]);
			if(($AAI::AwardNoMin[%x] == 1 || %calc > 0) && $AAI::AwardGeneral[%x] != 1)
			{
				if(%calc == %winnercalc[%x])
				{
					if(%ties[%x] > 2)
					{
						%winnercl[%x] = -1;
			
					} else if(getrandom()<0.50)
					{
						%winnercalc[%x] = %calc;
						%winnercl[%x] = %i;
					}
					%ties[%x]++;
				}
				if(%winnercalc[%x] == "null" || %calc > %winnercalc[%x])
				{
						%winnercalc[%x] = %calc;
						%winnercl[%x] = %i;
						
						%ties[%x] = 0;
				}
			}
		}

	}
	echo("RESULTS: ");
	for(%x = 0; %x<$AAI::AwardCount; %x++)
	{
		if(%winnercalc[%x] == "null" || !%winnercl[%x])
		{

		} else
		{
		if($AAI::AwardNoMin[%x] == 1)
			%winnercalc[%x] = -1 * %winnercalc[%x];
		echo(client::Getname(%winnercl[%x])@" got "@$AAI::Award[%x]@" with a score of "@%winnercalc[%x]);
		
			$AAI::ClientAwardList[%winnercl[%x]] = $AAI::ClientAwardList[%winnercl[%x]] @ %x @ " " @ %winnercalc[%x] @ " ";
	

		}


	}
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
		echo($AAI::ClientAwardList[%i]);
	}
}
$AAI::ListLazyStats = 0;
function AAI::ShowEndAwards()
{
	for(%x = 0; %x < 32; %x++)
	{
	Team::setObjective(0, %x, " ");
	}
	%line = -1;
	if($TeamScore[0] > $TeamScore[1])
		%display = "<F8> RESULT: Your squad successfully completed the mission!";
	else
		%display = "<F8> RESULT: Your squad failed...";
	Team::setObjective(%i, %line++," ");
	Team::setObjective(%i, %line++, %display);

	Team::setObjective(%i, %line++," ");


	Team::setObjective(%i, %line++,"<F7>    Game statistics and awards:");
	Team::setObjective(%i, %line++," ");
	%count = 0;
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
		if(gamebase::getteam(%i) != 0)
			gamebase::setteam(%i, 0);
		if(%i.ingame)
		{
			LimitedLives::CalcTimeinGame(%i);
			%time = $AAI::GameStats[%i, "timeingame"];

		} else {
			%time = $AAI::GameStats[%i, "timeingame"];
		}	
		if(%time == "" || !%time)
		{
			%time = -2;

		}
		%time = floor(%time);
		if($AAI::ListLazyStats)
		{
		%list[%count] = %i @ " " @ %time;

		%count++;

		} else
		{
		%count++;
		for(%x = %count - 1; %x >= 0; %x--)
		{
			if((getword(%list[%x], 0) == -1))
				%list[%x] = %i @ " " @ %time;

			if((%time > getword(%list[%x], 1))||(%time == getword(%list[%x], 1) && $AAI::GameStats[%i, "kills"] > $AAI::GameStats[getword(%list[%x], 0), "kills"]))
			{
				%tmp = %list[%x];
				%list[%x] = %i @ " " @ %time;
				%list[%x + 1] = %tmp;
			}
		}
		}
		
	}
	for(%x = 0; %x < %count; %x++)
	{
	%cl = getword(%list[%x], 0);
	
	%display = "<F5>\t"@(%x + 1)@") "@ Client::getname(%cl)@"  Duration: "@TimeFormat(getword(%list[%x], 1))@"  Kills: "@$AAI::GameStats[%cl, "kills"]@"  Accuracy: "@$AAI::GameStats[%cl, "Accuracy"]@"%";
	Team::setObjective(0, %line++, %display); // 255 characters each
	%awardlist = $AAI::ClientAwardList[%cl];
	
	if(%awardlist == "" && getword(%list[%x], 1) > 0)
	{
	%display = "<F2>\t\t1) Mr. UnNotable";
	Team::setObjective(0, %line++, %display);
	} else if(%awardlist == "" && getword(%list[%x], 1) <= 0)
	{
	%display = "<F2>\t\t1) Late Comer";
	Team::setObjective(0, %line++, %display);
	} else {
		%y = 0;
		while(getword(%awardlist, %y) != -1)
		{
			%aw = getword(%awardlist, %y);
			%sc = getword(%awardlist, %y++);
			%y++;
			
			for(%z = (%y/2)-1; %z >= 0; %z--)
			{
				
				if(getword(%toplist[%z], 0) == -1)
					%toplist[%z] = %sc @ " " @ %aw;
				
				if(%sc > getword(%toplist[%z], 0))
				{
					%tmp = %toplist[%z];
					%toplist[%z] = %sc @ " " @ %aw;
					%toplist[%z + 1] = %tmp;
					
					
				}
				
			}
		}
		echo("Y: "@(%y/2));
		%lcount = (%y/2);
		%realcount = %lcount;
		if(%lcount > 3)
			%lcount = 3;
		%display = "";
		for(%q = 0; %q < %lcount; %q++)
		{
			%display = %display@"<F2>\t\t"@(%q + 1)@") "@$AAI::Award[getword(%toplist[%q], 1)]@"   ";
			
			
		}
		%lcount = 0;
		for(%r = 0; %r < %realcount; %r++)
		{
			echo(%r@": "@%toplist[%r]);
			%toplist[%r] = "";
			
		}
		Team::setObjective(0, %line++, %display);
		
	}
	Team::setObjective(0, %line++, " ");

	}
	
	
	


}
function TimeFormat(%t)
{
	
	%h = floor(%t/3600);
	%m = Time::getMinutes(%t);
      	%s = Time::getSeconds(%t);

	
	if(%m < 10)
		%m = "0"@%m;
	if(%s < 10)
		%s = "0"@%s;
	if(%s != "0-1")
	%str = %h@":"@%m@":"@%s;
	else
	%str = "Not in game.";
	
	return %str;

}