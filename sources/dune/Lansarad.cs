// How many atomics have they been the cause of?
//$NukeCount[getIP(%clientID)]

// Whats their current spawn time?
//$SpawnTime[getIP(%clientID)]

// Should we inc their spawn time because they shot off an atomic?
//$JustNuked[getIP(%clientID)]

// How many Suicide bombers have they been the cause of?
//$SuicideCount[getIP(%clientID)]

// Should we inc their spawn time because they detonated a suicide pack?
//$JustSuicided[getIP(%clientID)]

//==================================================================================
// On which nuke detonation will they start spawning slower?
//==================================================================================
$NukeSpawnLimit = 1;

//==================================================================================
// On which nuke detonation will they start chancing their kick?
//==================================================================================
$NukeKickLimit = 3;

//==================================================================================
// How much should we increase their kick % chance for each exp over $NukeKickLimit?
//==================================================================================
$NukeKickInc = 20;

//==================================================================================
// What percent will we start the chance for kicking at?
//==================================================================================
$NukeInitPercent = 30;

//==================================================================================
// How much much time will their spawntime increase after any suicide (in seconds)
// (implimentation added not only to encourage living, but to restrict suicide pack
//  spammers)
//==================================================================================

$SuicideSpawnInc = 5;

//==================================================================================
// How much to increase ST everytime you TK?
//==================================================================================

$TKSpawnInc = 15;

//==================================================================================
// How much to increase ST everytime you do any damage to a teammate?
//==================================================================================

$TDSpawnInc = 5;

//==================================================================================
// How much should we increase their spawn time for each exp over $NukeSpawnLimit?
//==================================================================================
$NukeSpawnInc = 20;

//==================================================================================
// How much should the initial spawn time for nuking be for over $NukeSpawnLimit?
//==================================================================================

$InitNukeSpawnTime = 60;

//==================================================================================
// How much time between each second decrement of their spawntime (in seconds)
// ***Do NOT set below a value of 1***
//==================================================================================

$SpawnDecTime = 20;

//==================================================================================
// How long do we banish the player for being caught by the Lansarad? (in seconds)
// ***Do NOT set below a value of 1***
//==================================================================================

$LansaradBanishTime = 300;

//==================================================================================
// On which suicide pack detonation will they start spawning slower?
//==================================================================================
$SuicideSpawnLimit = 0;

//==================================================================================
// How much should we increase their spawn time for each suicide over $SuicideSpawnLimit?
//==================================================================================
$SuicidePackSpawnInc = 5;


//****************************************************************************************************************
//  Calculate the clients new spawn time based on how many nukes they have used, and if they just set them off. 
// This will just be standard spawn time for most people. 
// This will also calculate spawntime for suicide pack detonations.
//
// %clientId - The client we are affecting
//
// 
//
//****************************************************************************************************************
function CalcSpawnTime(%clientId) 
{

	%clientName = Client::getName(%clientID); 

	// If have just nuked, then inc their spawn time to their new level.
	if ( $JustNuked[getIP(%clientID)] )
	{
		$JustNuked[getIP(%clientId)] = false;
		%spawnTime = $InitNukeSpawnTime + ( $NukeCount[getIP(%clientId)] - $NukeSpawnLimit - 1 ) * $NukeSpawnInc;
		
		if( %spawnTime > ( %OldSpawnTime = GetSpawnTime(%clientId) ) )
			AdjustSpawnTime(%clientId, %spawnTime);
		else 
			IncSpawnTime(%clientId, ($NukeSpawnInc*2));

		if ( $NukeCount[getIP(%clientId)] == $NukeSpawnLimit ) 	
		{
			$FirstClassMessage[%clientId] = "<jc>By using Atomics you risk banishment from the Empire!";
			$FirstClassMessageExists[%clientId] = true;
			Bottomprint(%clientId, $FirstClassMessage[%clientId], 10);
			schedule("$FirstClassMessageExists["@%clientId@"] = false;", 10);
		
		} else if ( $NukeCount[getIP(%clientId)] > $NukeSpawnLimit )
		{
			$FirstClassMessage[%clientId] = "<jc>You better lay low for a while so the Lansarad Council doesn't catch you using Atomics! (Your spawn time has been increased to " @ 
				GetSpawnTime(%clientId) @ " seconds. It will decrease back to normal over time.)";
			$FirstClassMessageExists[%clientId] = true;
			Bottomprint(%clientId, $FirstClassMessage[%clientId], 10);
			schedule("$FirstClassMessageExists["@%clientId@"] = false;", 10);
		
		}

		if ( $NukeCount[getIP(%clientId)] >= $NukeKickLimit )
			LansaradEvaluation(%clientId);
	}
	// If have just detonated a suicide pack, then inc their spawn time to their new level.
	if ( $JustSuicided[getIP(%clientID)] )
	{
		$JustSuicided[getIP(%clientId)] = false;
		%spawnTime = GetSpawnTime(%clientId) + ( $SuicideCount[getIP(%clientId)] - $SuicideSpawnLimit - 1 ) * $SuicidePackSpawnInc;
		
		if( %spawnTime >= ( %OldSpawnTime = GetSpawnTime(%clientId) ) )
		{
			AdjustSpawnTime(%clientId, %spawnTime);
		}
	}
}


//****************************************************************************************************************
//  Simply decreases the client's spawntime by one and tells it to do it again in $SpawnDecTime amount of time.
// If it is <= the normal spawn time, it stops.
//
// %clientId - The client we are affecting
//
// ****DEPRECIATED****
//
//****************************************************************************************************************
function DecSpawnTimeOLD(%clientId)
{
	%clientName = Client::getName(%clientID); 
	if ( $SpawnTime[getIP(%clientId)] <= $Server::respawnTime )
		$SpawnTime[getIP(%clientId)] = $Server::respawnTime;
	else { 
		$SpawnTime[getIP(%clientId)]--;
		schedule("DecSpawnTime("@%clientId@");", $SpawnDecTime);
	}	
}


//****************************************************************************************************************
//  Determines if the Lansarad Council has caught wind of the person's use of nukes. If they have, the person 
// is banished from the Empire. (the person gets kicked)
//
// %clientId - The client we are affecting
//
//****************************************************************************************************************
function LansaradEvaluation(%clientId)
{
	%clientName = Client::getName(%clientID);

	%chance = floor(getRandom() * 100) + 1;
	
	// The Lansarad has noticed, and passed judgment.....
	if ( !%clientId.issuperadmin && %chance <= ( $NukeInitPercent + ($NukeCount[getIP(%clientId)] - $NukeKickLimit) * $NukeKickInc) )
	{
		%ip = Client::getTransportAddress(%clientID);
		if(%ip != "")
        		BanList::add(%ip, $LansaradBanishTime);
		schedule("net::kick("@%clientId@", \"You have been caught using Atomics by the Lansarad Council, and have been banished from the Empire!\");",0.1);
		
      
	}	

}


//****************************************************************************************************************
//  Call this whenever someone is the CAUSE of a nuclear explosion.
//
// %clientId - The client we are affecting
//
//****************************************************************************************************************
function NukeCaused(%clientId)
{
echo(%clientId @ " " @client::Getname(%clientID) @ " CAUSED NUKE!");
	if ( !$NukeCount[getIP(%clientId)] )
 		$NukeCount[getIP(%clientId)] = 1;
	else
		$NukeCount[getIP(%clientId)]++;
	
	$JustNuked[getIP(%clientId)] = true;

}

//****************************************************************************************************************
//  Use this for Adjusting spawntime (setting it). Is called by Decspawntime and Incspawntime with 
//   the use of the mod parameter.
//
// %clientId - The client we are affecting
// %st - spawntime to set it to (or add to or subtract)
// %mod - "add" if we want to add, or "sub"/"subtract" if we want to subtract.
//
//****************************************************************************************************************

function AdjustSpawnTime(%clientId, %st, %mod)
{
	%name = client::Getname(%clientId);

	if(%mod == "add") {
		$SpawnTime[getIP(%clientId)] = GetSpawnTime(%clientId) + %st;
	
	} else if (%mod == "subtract" || "sub") {
		$SpawnTime[getIP(%clientId)] = GetSpawnTime(%clientId) - %st;
	} else {
		GetSpawnTime(%clientId);
		$SpawnTime[getIP(%clientId)] = %st;
	}
}

//****************************************************************************************************************
//  Returns the player's current spawn time. Also does the update for the spawntime since it was last checked.
//   Depreciates the decspawntime recusive calls.
//
// %clientId - The client we are affecting
//
//****************************************************************************************************************

function GetSpawnTime(%clientId)
{
	%name = client::Getname(%clientId);
	%time = getSimTime();
	
	if(%time < $LastSTCheck[getIP(%clientId)])
		$LastSTCHeck[getIP(%clientID)] = %time;
	if( $LastSTCheck[getIP(%clientId)] && $SpawnTime[getIP(%clientId)]) { 
		$SpawnTime[getIP(%clientId)] = $spawnTime[getIP(%clientId)] - (%time - $LastSTCheck[getIP(%clientId)]) / $SpawnDecTime;
	}
	if( !$SpawnTime[getIP(%clientId)] || $SpawnTime[getIP(%clientId)] < $Server::respawnTime ) { 
		$SpawnTime[getIP(%clientId)] =  $Server::respawnTime;
	}
	$LastSTCheck[getIP(%clientId)] = %time;
	
	return $SpawnTime[getIP(%clientId)];
}

//****************************************************************************************************************
//  Decrease the spawn time by %amt
//
// %clientId - The client we are affecting
// %amt - Amount to decrease it by.
//
//****************************************************************************************************************

function DecSpawnTime(%clientId, %amt) 
{
	AdjustSpawnTime(%clientId, %amt, "sub");
}

//****************************************************************************************************************
//  Increases the spawn time by %amt
//
// %clientId - The client we are affecting
// %amt - Amount to increase it by.
//
//****************************************************************************************************************

function IncSpawnTime(%clientId, %amt)
{
	AdjustSpawnTime(%clientId, %amt, "add");
}

//****************************************************************************************************************
//  Checks to make sure the player isnt trying to get rid of their spawntime/nuke count.
//   Will check to see if it has a .# on the end, and modify it from there. Not complete,
//   But not simple to get around unless you have the code, or stumble on it blindly.
//   If they put that much time into getting around it then... maybe ill make it better.
//   Or maybe who cares? They probably will just manage to get them selves kicked real soon. (or noticed, and then kicked)
//
// DEPRECIATED -Already! Just gonna reduce everything to IP. That way, the names dont matter! If someone's brother gets
//     em a bad score then well... they can beat em up. But this way, its easier, not a waste of code, and forces them
//     to get a new connection if they want to reset their information.
//
// %clientId - The client we are affecting
//
//****************************************************************************************************************

function CheckGlobalStick(%clientId)
{
	%name = client::getname(%clientId);
	%ip = Client::getTransportAddress(%clientId);
	%end = -1;
	%oldname = "";

	//Always reset the LastSTCheck. That way their spawntime doesnt decrease when they arnt playing :)
	$LastSTCheck[%ip] = getsimtime();

	

	// If our name has a .1, .2, .3 at the end, see if there are constants of the original to gift over.
	if((%end = String::findsubstr(%name, ".1")) != -1 && string::getsubstr(%name, %end, 2) == "")
	{
		%oldname = string::getsubstr(%name, 0, %end);

		// If someone with this name is already connected, we don't want to give their stuff to this guy
		if(IsConnected(%oldname))
			return;
		if($NukeCount[%oldname,%ip] > 0 && $NukeCount[%name,%ip] < $NukeCount[%oldname,%ip])
		{		
			$NukeCount[%name,%ip] = $NukeCount[%oldname,%ip];
			$NukeCount[%oldname,%ip] = 0;
		}
		if($SpawnTime[%oldname,%ip] > 10 && $SpawnTime[%name,%ip] < $SpawnTime[%oldname,%ip])
		{
			$SpawnTime[%name,%ip] = $SpawnTime[%oldname,%ip];
			$SpawnTime[%oldname,%ip] = 0;
		}
		if($JustNuked[%oldname,%ip])
		{
			$JustNuked[%name,%ip] = true;
			$JustNuked[%oldname,%ip] = false;
		}
	}else if((%end = String::findsubstr(%name, ".2")) != -1 && string::getsubstr(%name, %end, 2) == "")
	{
		%oldname = string::getsubstrg(%name, 0, %end);

		// If someone with this name is already connected, we don't want to give their stuff to this guy
		if(IsConnected(%oldname))
			return;

		if($NukeCount[%oldname,%ip] > 0 && $NukeCount[%name,%ip] < $NukeCount[%oldname,%ip])
		{		
			$NukeCount[%name,%ip] = $NukeCount[%oldname,%ip];
			$NukeCount[%oldname,%ip] = 0;
		}
		if($SpawnTime[%oldname,%ip] > 10 && $SpawnTime[%name,%ip] < $SpawnTime[%oldname,%ip])
		{
			$SpawnTime[%name,%ip] = $SpawnTime[%oldname,%ip];
			$SpawnTime[%oldname,%ip] = 0;
		}
		if($JustNuked[%oldname,%ip])
		{
			$JustNuked[%name,%ip] = true;
			$JustNuked[%oldname,%ip] = false;
		}
	}else if((%end = String::findsubstr(%name, ".3")) != -1 && string::getsubstr(%name, %end, 2) == "")
	{
		%oldname = string::getsubstr(%name, 0, %end);

		// If someone with this name is already connected, we don't want to give their stuff to this guy
		if(IsConnected(%oldname))
			return;

		if($NukeCount[%oldname,%ip] > 0 && $NukeCount[%name,%ip] < $NukeCount[%oldname,%ip])
		{		
			$NukeCount[%name,%ip] = $NukeCount[%oldname,%ip];
			$NukeCount[%oldname,%ip] = 0;
		}
		if($SpawnTime[%oldname,%ip] > 10 && $SpawnTime[%name,%ip] < $SpawnTime[%oldname,%ip])
		{
			$SpawnTime[%name,%ip] = $SpawnTime[%oldname,%ip];
			$SpawnTime[%oldname,%ip] = 0;
		}
		if($JustNuked[%oldname,%ip])
		{
			$JustNuked[%name,%ip] = true;
			$JustNuked[%oldname,%ip] = false;
		}
	}else
	{
		// We dont have a .1 or .2 or .3 at the end, treat it as an original name, and check to see if there is
		//  and .1 .2 or .3s already recorded.
		for(%x = 1; %x < 4; %x++)
		{
			%oldname = %name @ "."@%x; 

			// If someone with this name is already connected, we don't want to give their stuff to this guy
			if(IsConnected(%oldname))
				return;

			if($NukeCount[%oldname,%ip] > 0 && $NukeCount[%name,%ip] < $NukeCount[%oldname,%ip])
			{		
				$NukeCount[%name,%ip] = $NukeCount[%oldname,%ip];
				$NukeCount[%oldname,%ip] = 0;
			}
			if($SpawnTime[%oldname,%ip] > 10 && $SpawnTime[%name,%ip] < $SpawnTime[%oldname,%ip])
			{
				$SpawnTime[%name,%ip] = $SpawnTime[%oldname,%ip];
				$SpawnTime[%oldname,%ip] = 0;
			}
			if($JustNuked[%oldname,%ip])
			{
				$JustNuked[%name,%ip] = true;
				$JustNuked[%oldname,%ip] = false;
			}
		}
	}
}

//****************************************************************************************************************
//  Is this person playing? Return true if yes, false if no.  
//
// %name - Name of person to search for
//
//****************************************************************************************************************

function IsConnected( %name )
{
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
		if(Client::Getname(%i) == %name)
			return true;
	return false;
}


//****************************************************************************************************************
//  Return *just* the IP of the person, not the port. Example would be:
//	IP:0.0.0.0
//  As opposed to getTransportAddress() which returns:
//	IP:0.0.0.0:0000
//
// %client - Person to get IP from.
//
//****************************************************************************************************************

function getIP( %client )
{
	%ip = Client::getTransportAddress(%client);
	%temp = String::getSubStr(%ip,String::findSubStr(%ip, ":")+1,getLength(%ip));
	%ip = "IP:"@String::getSubStr(%temp,0,String::findSubStr(%temp, ":"));
	return %ip;

}