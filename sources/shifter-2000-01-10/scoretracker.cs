function ScoreTracker(%remote)
{
	echo("ADMINMSG: **** Shifter Is Checking For Poopy Players");
	$Shifter::ScoreTrackerOn = 1;
	%numPLayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%clientId = getClientByIndex(%i);
		if($debug) echo ("Player = " @ %clientId);
		
		if (%clientId.score < $Shifter::WarnScoreFinal)
		{
			for(%i=0; $Server::NoBan[%i] != "" || $Server::NoBanAddr[%i] != "" ;%i++)
			{
				if(($Server::NoBan[%i] == "" || $Server::NoBan[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::NoBanAddr[%i]) == 0)
				{
					echo("Player Has Crappy Score But Is On NoBan List: " @ %clientId @ " \"" @ escapeString(Client::getName(%clientId)) @ "\" " @ Client::getTransportAddress(%clientId));
					echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Would have been kicked for crappy score but is on NoBan list.");
					return;
				}
			}			
			Net::kick(%clientId, "You were kicked for having a crappy score. Score = " @ %clientId.score );
			MessageAll(1, Client::getName(%clientId) @ " got Kicked For Having A Crappy Score...");
			bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0> got Kicked For Having A Crappy Score...<f1>", 10);
			echo("ADMINMSG: **** Shifter Is Checking For Poopy Players");
		}
		else if (%clientId.score < $Shifter::WarnScore3)
		{
			bottomprint(%clientId, "<jc><f2>You will be kicked if your score falls to low. This is your *LAST* warning.<f0>", 10);
			echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " FINAL Warning For Having Crappy Score.");
		}
		else if (%clientId.score < $Shifter::WarnScore2)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL TWO WARNING - You will be kicked if your score falls to low.<f0>", 10);
			echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Warned For Having Crappy Score.");
		}
		else if (%clientId.score < $Shifter::WarnScore1)
		{
			bottomprint(%clientId, "<jc><f2>LEVEL ONE WARNING - You will be kicked if your score falls to low.<f0>", 10);
			echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Warned For Having Crappy Score.");
		}


	}

    	if (!%remote)
    		schedule("ScoreTracker();",$Shifter::CheckScores);
}

function remoteScoreTracker()
{
	ScoreTracker(True);
}

if ($Shifter::ScoreTracker)
{
	if ($Shifter::ScoreTrackerOn < 1)
	{
		echo("ADMINMSG: **** ScoreTracker Loaded");
    		schedule("ScoreTracker();",$Shifter::CheckScores);
	}
}

