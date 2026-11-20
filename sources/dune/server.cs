// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

$MODInfo = "<jc><f0>|||<f1>||<f2>| <f3>DUNE <f2>|<f1>||<f0>|||\n<f1>Offical DUNE mod website: <f2>http://jmods.bravepages.com\n <f1>Download mappacks, clientpack, releases, and any updates there.\n<F3>Download the DAF Server from there and host it!.";

function createTrainingServer()
{
   $SinglePlayer = true;
   createServer($pref::lastTrainingMission, false);
}

function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask)
{
   $Client::info[%clientId, 0] = %skin;
   $Client::info[%clientId, 1] = %name;
   $Client::info[%clientId, 2] = %email;
   $Client::info[%clientId, 3] = %tribe;
   $Client::info[%clientId, 4] = %url;
   $Client::info[%clientId, 5] = %info;
   if(%autowp)
      %clientId.autoWaypoint = true;
   if(%enterInv)
      %clientId.noEnterInventory = true;
   if(%msgMask != "")
      %clientId.messageFilter = %msgMask;
}

function Server::storeData()
{
   $ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";

   export("Server::*", "temp\\" @ $ServerDataFile, False);
   export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
   EvalSearchPath();
}

function Server::refreshData()
{
   exec($ServerDataFile);  // reload prefs.
   checkMasterTranslation();
   Server::nextMission(false, true);
}

function Server::onClientDisconnect(%clientId)
{
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}

	
	$GholaOwned[%clientId] = 0;
	for(%x = 1; %x <= $GholaOwnedMax; %x++ ) {
	  if($OwnedGholaList[%clientid, %x] != "" ) {
	   Player::Kill(AI::getId($OwnedGholaList[%clientid, %x]));
	   $OwnedGholaList[%clientid, %x] = "";
	  }

	}

   Client::setControlObject(%clientId, -1);
	%done = false;
	for(%x=0;%x<20 && !%done;%x++)
	{
		if($NukeConnections[getIP(%clientID),%x] == "")
		{
			$NukeConnections[getIP(%clientID),%x] = "O**"@GetSpawnTime(%clientID);
			%done = true;
		}
	}

   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
}

function KickDaJackal(%clientId)
{
   Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function Server::onClientConnect(%clientId)
{
      %clienID.weaponLooping = false;
      %clientID.initnotalk = true;
      schedule(%clientId @ ".initnotalk = false;", 11, %clientId);

   if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
   {
      // force admin the loopback dude
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;
   }
   echo("CONNECT: " @ %clientId @ " \"" @ 
      escapeString(Client::getName(%clientId)) @ 
      "\" " @ Client::getTransportAddress(%clientId));

   if(Client::getName(%clientId) == "DaJackal")
      schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);


   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, $MODInfo);
   remoteEval(%clientId, FileURL, $Server::FileURL);

   //****to place your self as perm admin, just stick your local ip there \/
   if(String::findSubStr(Client::getTransportAddress(%clientId),"IP:192.168.") == 0){
      %clientId.isAdmin = true;
      %clientId.isSuperAdmin = true;   
   }

   if(Client::getName(%clientId) == "")
	net::Kick(%clientId, "That name is restricted on this server. Please pick another");

   //****to place others as standard admin, just stick their ips here \/
//   if(Client::getName(%clientId) == "NAMEGOESHERE" && String::findSubStr(Client::getTransportAddress(%clientId),"IPGOESHERE") == 0){
//      schedule("bottomprint(" @ %clientId @ ", \"<jc><f1><jc><f2>Welcome Administrator!.\", 5);", 35);
//      %clientId.isAdmin = true; 
   }
   //********
   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   //CheckGlobalStick(%clientId);
   Game::onPlayerConnected(%clientId);
}

//Everyone is a male now.
function Client::GetGender()
{
	return "Male";
}

function createServer(%mission, %dedicated)
{
   $loadingMission = false;
   $ME::Loaded = false;
   if(%mission == "")
      %mission = $pref::lastMission;

   if(%mission == "")
   {
      echo("Error: no mission provided.");
      return "False";
   }

   if(!$SinglePlayer)
      $pref::lastMission = %mission;

	//display the "loading" screen
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);

   if(!%dedicated)
   {
      deleteServer();
      purgeResources();
      newServer();
      focusServer();
   }
   if($SinglePlayer)
      newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
   else
      newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);

	exec(admin);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	exec(ArmorData);
	exec(Mission);
	exec(Item);
	exec(Player);
	exec(Vehicle);
	exec(Turret);
	exec(Beacon);
	exec(StaticShape);
	exec(Station);
	exec(Moveable);
	exec(Sensor);
	exec(Mine);
	exec(worms);
	exec(dropships);
	exec(Atomics);
	exec(ShieldWork);
	exec(AI);
	exec(InteriorLight);	
	exec(Messages);
	exec(Lansarad);
	exec(Team);
	exec(ClientPackScripts);
	exec(Campaign);

   // Keep track of velocities
   Server::storeData();

   // NOTE!! You must have declared all data blocks BEFORE you call
   // preloadServerDataBlocks.

   preloadServerDataBlocks();

   // A little bit of short circuiting...
   %mission = $StartMission; // As defined in missionList.cs 
   // It's the last mission "Read" int the $nextMission array,
   // or in other words, the first mission alphabetacally in the
   // last type loaded (in this case, the serverside missions)
   Server::loadMission( ($missionName = %mission), true );

   if(!%dedicated)
   {
      focusClient();

		if ($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if ($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
      // join up to the server
      $Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
      connect($Server::Address);
   }
   return "True";
}

function Server::nextMission(%replay, %noreturn)
{
   if($Campaign::isCampaign)
   {
	Campaign::endMission();
	if(%noreturn != true)
		return;
   }

   if(%replay || $Server::TourneyMode)
      %nextMission = $missionName;
   else
      %nextMission = $nextMission[$missionName];
   echo("Changing to mission ", %nextMission, ".");
   // give the clients enough time to load up the victory screen
   Server::loadMission(%nextMission, -1);
}

function remoteCycleMission(%clientId)
{
   if(%clientId.isAdmin)
   {
      messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
      Server::nextMission();
   }
}

function remoteDataFinished(%clientId)
{
   if(%clientId.dataFinished)
      return;
   %clientId.dataFinished = true;
   Client::setDataFinished(%clientId);
   %clientId.svNoGhost = ""; // clear the data flag
   if($ghosting)
   {
      %clientId.ghostDoneFlag = true; // allow a CGA done from this dude
      startGhosting(%clientId);  // let the ghosting begin!
   }
}

function remoteCGADone(%playerId)
{
   if(!%playerId.ghostDoneFlag || !$ghosting)
      return;
   %playerId.ghostDoneFlag = "";

   Game::initialMissionDrop(%playerid);

	if ($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
   remoteEval(%playerId, MInfo, $missionName);
}

function Server::SwapTeams(%TTS, %TTST)
{
	// Can't swap teams if we're in a campaign
	if($Campaign::isCampaign)
	{
		echo("Attempt to swap teams failed. Can't swap teams during a campaign.");
		return;
	}

	if($Server::JustSetTeams == 1)
		$Server::JustSetTeams = 0;
	%temp = $Server::Team[%TTS];
	$Server::Team[%TTS] = $Server::Team[%TTST];
	$Server::Team[%TTST] = %temp;
	$Server::IgnoreSetTeams = true;
	Server::nextMission(true);
}

// I doubt we'll have anymore then 7
// If you need a team set that isn't preceeded by a teamset (1->HA, 2->who cares, 3->HH) or (1->who cares, 2->HA) ect
// Then enter in a -1 for them. (Server::SetTeams("HA",-1,"HH");) or (Server::SetTeams(-1,"HA");

function Server::SetTeams(%first, %second, %third, %fourth, %fifth, %sixth, %seventh)
{
	if($Server::IgnoreSetTeams == true)
		$Server::IgnoreSetTeams = false;
	else
	{	
		%switches = 0;
		// Ew.
		if(%first != "")
		{
			%newTeams[%switches] = %first;
			%switches++;
		}
		if(%Second != "")
		{
			%newTeams[%switches] = %Second;
			%switches++;
		}
		if(%Third != "")
		{
			%newTeams[%switches] = %third;
			%switches++;
		}
		if(%fourth != "")
		{
			%newTeams[%switches] = %fourth;
			%switches++;
		}
		if(%fith != "")
		{
			%newTeams[%switches] = %fifth;
			%switches++;
		}
		if(%sixth != "")
		{
			%newTeams[%switches] = %sixth;
			%switches++;
		}
		if(%seventh != "")
		{
			%newTeams[%switches] = %seventh;
			%switches++;
		}


		for(%i=0;%i<$numTeamsAvailable;%i++)
			$Server::HoldOldTeams[%i] =$Server::Team[%i];
		
		for(%x=0;%x<%switches;%x++)
		{
			%TTST = %x;
			if($ServerNameToKeyName[%newTeams[%x]] != $Server::Team[%x])
			{
				%TTS = -1;
				for(%y=0;%y<$NumTeamsAvailable;%y++)
				{
					if(%newTeams[%x] == $Server::Team[%y])
					{
						%TTS = %y;
					}
				}
				if(%TTS != -1)
				{
					$Server::JustSetTeams = 2; // 2 = next mission change does nothing (1) + next mission change we use it...(1) 
					%temp = $Server::Team[%TTS];
					$Server::Team[%TTS] = $Server::Team[%TTST];
					$Server::Team[%TTST] = %temp;
				}	
			}
		}		
	}
}

function Server::teamDefaults()
{
	// Can't swap teams if we're in a campaign
	if($Campaign::isCampaign)
	{
		echo("Attempt to swap teams failed. Can't swap teams during a campaign.");
		return;
	}

	if($Server::JustSetTeams == 1)
		$Server::JustSetTeams = 0;
	$Server::IgnoreSetTeams = true;

	for(%i = 0; %i < $numTeamsAvailable; %i++)
		$Server::Team[%i] = $ServerTeamDefaults[%i];
	
	Server::nextMission(true);
}

function ListTeams()
{
	for(%i = 0; %i < $NumTeamsAvailable; %i++)
		echo(%i @ " " @ $Server::Team[%i]);

}

function Server::ForceChange(%missionName)
{
	Server::loadMission(%missionName, -1, 1);
}
function Server::loadMission(%missionName, %immed, %endcamp)
{
   if($loadingMission)
      return;

   if(%endCamp == 1 && $Campaign::isCampaign && $Campaign::JustStarted == -1)
  	Campaign::endCampaign(true);

   if((!%endCamp || %endcamp == "" || %endcamp == -1)
      && $Campaign::isCampaign && $Campaign::JustStarted == -1 && !$Campaign::LoadingMission)
   {
	echo("Attempting to leave Campaign! Use Server::ForceChange(%missionname);");
	return;
   }

   $Campaign::LoadingMission = -1;
   $Campaign::JustStarted = -1;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
   }

   %missionSuppFile = "missions\\" $+ %missionName $+ ".cs";
   if(File::FindFirst(%missionSuppFile) != "")
   {
	echo("Loading Supplementary Mission Scripts...");
	exec(%missionSuppFile);
   }

   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();

   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); // deal with time imprecision

   newObject(ConsoleScheduler, SimConsoleScheduler);
   if(!%immed||%immed == -1)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();      
}

function Server::finishMissionLoad()
{
   exec("MissRestart.cs");
   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();
   if($prevNumTeams != getNumTeams())
   {
      // loop thru clients and setTeam to -1;
      messageAll(0, "New teamcount - resetting teams.");
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         GameBase::setTeam(%cl, -1);
   }

   $ghosting = true;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(!%cl.svNoGhost)
      {
         %cl.ghostDoneFlag = true;
         startGhosting(%cl);
      }
   }
   if($SinglePlayer)
      Game::startMatch();
   else if($Server::warmupTime && !$Server::TourneyMode)
      Server::Countdown($Server::warmupTime);
   else if(!$Server::TourneyMode)
      Game::startMatch();

   $teamplay = (getNumTeams() != 1);
   purgeResources(true);

   // make sure the match happens within 5-10 hours.
   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);
   
   return "True";
}

function Server::CheckMatchStarted()
{
   // if the match hasn't started yet, just reset the map
   // timing issue.
   if(!$matchStarted)
      Server::nextMission(true);
}

function Server::Countdown(%time)
{
   $countdownStarted = true;
   schedule("Game::startMatch();", %time);
   Game::notifyMatchStart(%time);
   if(%time > 30)
      schedule("Game::notifyMatchStart(30);", %time - 30);
   if(%time > 15)
      schedule("Game::notifyMatchStart(15);", %time - 15);
   if(%time > 10)
      schedule("Game::notifyMatchStart(10);", %time - 10);
   if(%time > 5)
      schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
   remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
   if(%timeout == "")
      %timeout = 5;
   for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
      remoteEval(%clientId, "TP", %msg, %timeout);
}

function resetSpawnTime(%clientId)
{
	if(%clientId)
	{
		%spawntime = $Server::respawnTime;
		AdjustSpawnTime(%clientId, %spawntime);	
		Client::sendMessage(%clientId, $MSGTypeGame, "Your spawn time has been reset.");
	} else {
		for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
		{
			%spawntime = $Server::respawnTime;
			AdjustSpawnTime(%i, %spawntime);	
			Client::sendMessage(%i, $MSGTypeGame, "Your spawn time has been reset.");
		}
	}	

}


function datablocks(%this)
{
	$letter[1] = "";
	$letter[2] = " ";
	$letter[3] = "a";
	$letter[4] = "b";
	$letter[5] = "c";
	$letter[6] = "d";
	$letter[7] = "e";
	$letter[8] = "f";
	$letter[9] = "g";
	$letter[10] = "h";
	$letter[11] = "i";
	$letter[12] = "j";
	$letter[13] = "k";
	$letter[14] = "l";
	$letter[15] = "m";
	$letter[16] = "n";
	$letter[17] = "o";
	$letter[18] = "p";
	$letter[19] = "q";
	$letter[20] = "r";
	$letter[21] = "s";
	$letter[22] = "t";
	$letter[23] = "u";
	$letter[24] = "v";
	$letter[25] = "w";
	$letter[26] = "x";
	$letter[27] = "y";
	$letter[28] = "z";



	for(%aa = 1; %aa < 29; %aa++)
	{
	for(%ab = 1; %ab < 29; %ab++)
	{
	for(%ac = 1; %ac < 29; %ac++)
	{
 	for(%ad = 1; %ad < 29; %ad++)
	{
	for(%ae = 1; %ae < 29; %ae++)
	{
	for(%af = 1; %af < 29; %af++)
	{
	for(%ag = 1; %ag < 29; %ag++)
	{
	for(%ah = 1; %ah < 29; %ah++)
	{
	for(%ai = 1; %ai < 29; %ai++)
	{
	for(%aj = 1; %aj < 29; %aj++)
	{
	for(%ak = 1; %ak < 29; %ak++)
	{
	for(%al = 1; %al < 29; %al++)
	{
	for(%am = 1; %am < 29; %am++)
	{
	for(%an = 1; %an < 29; %an++)
	{
	for(%ao = 1; %ao < 29; %ao++)
	{
	for(%ap = 1; %ap < 29; %ap++)
	{
	for(%aq = 1; %aq < 29; %aq++)
	{
	for(%ar = 1; %ar < 29; %ar++)
	{
	for(%as = 1; %as < 29; %as++)
	{
	for(%at = 1; %at < 29; %at++)
	{
	for(%au = 1; %au < 29; %au++)
	{
	for(%av = 1; %av < 29; %av++)
	{
	for(%aw = 1; %aw < 29; %aw++)
	{
	for(%ax = 1; %ax < 29; %ax++)
	{
	for(%ay = 1; %ay < 29; %ay++)
	{
	for(%az = 1; %az < 29; %az++)
	{
	for(%ba = 1; %ba < 29; %ba++)
	{
	for(%bb = 1; %bb < 29; %bb++)
	{
	for(%bc = 1; %bc < 29; %bc++)
	{
	for(%bd = 1; %bd < 29; %bd++)
	{
		
	%word = $letter[bd] @ $letter[bc] @ $letter[bb] @ $letter[ba] @ $letter[az] @ $letter[ay] @ $letter[ax] @ $letter[aw] @ $letter[av] @ $letter[au] @ $letter[at] @ $letter[as] @ $letter[ar] @ $letter[aq] @ $letter[ap] @ $letter[ao] @ $letter[an] @ $letter[am] @ $letter[al] @ $letter[ak] @ $letter[aj] @ $letter[ai] @ $letter[ah] @ $letter[ag] @ $letter[af] @ $letter[ae] @ $letter[ad] @ $letter[ac] @ $letter[ab] @ $letter[aa];	
	schedule("checkblock("@%client @ "." @%word@","@%client@","@%word@");",0);

	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
	}
echo("Done");
}


function datablocks2(%this)
{
	$letter[1] = "";
	$letter[2] = " ";
	$letter[3] = "a";
	$letter[4] = "b";
	$letter[5] = "c";
	$letter[6] = "d";
	$letter[7] = "e";
	$letter[8] = "f";
	$letter[9] = "g";
	$letter[10] = "h";
	$letter[11] = "i";
	$letter[12] = "j";
	$letter[13] = "k";
	$letter[14] = "l";
	$letter[15] = "m";
	$letter[16] = "n";
	$letter[17] = "o";
	$letter[18] = "p";
	$letter[19] = "q";
	$letter[20] = "r";
	$letter[21] = "s";
	$letter[22] = "t";
	$letter[23] = "u";
	$letter[24] = "v";
	$letter[25] = "w";
	$letter[26] = "x";
	$letter[27] = "y";
	$letter[28] = "z";
	%count = 0;
	%char = "\"";

	for(%aa = 1; %aa < 29; %aa++)
	{
		
	%word = $letter[%aa];
	//schedule("checkblock( \"" @ %this @ "\".\"" @ %word @ "\",\"" @ %this @ "\",\"" @ %word @ "\");",0.1);
	//schedule("checkblock( \""@%char@ %this@ "\".\""@%word @%char@"\");",0);
	$blah = %word;
	//%command = %this.*%blah;
	echo(%command);
	//schedule("$blocks[ \"" @ %count++ @ "\"] = \"" @ %this @ "\".\"" @ %word @ "\";", 0.1);
	schedule("$blocks[ \"" @ %count++ @ "\"] = \"" @ %command @ "\";", 0.1);

	}
echo("Done");
}
function checkblock(%block, %item, %word)
{
echo(%block);
	if(%block != "")
		echo(%word @ " " @%block);

}

function checkblock2()
{

	for(%x = 1; %x < 100; %x++)
	{
		if($blocks[%x] != "")
			echo($blocks[%x]);
		
	}


}

function Ban(%client, %message) 
{
	%ip = Client::getTransportAddress(%clientId);
	BanList::add(%ip, 1800);
	BanList::export("config\\banlist.cs");
	net::kick(%client, %message);
}

function AdminTalk(%msg)
{
	echo(%msg);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", "Admin: " @ %msg, 6);
}

function chat(%message, %team)
{
	if(%team == "")
	{

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	        	Client::sendMessage(%cl,2,"Admin: " @%message);
		echo(">>> " @%message);
	} else
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(Client::getTeam(%cl) == %team)
	        		Client::sendMessage(%cl,3,"Admin: " @%message);
		echo(%team@">>> " @%message);
	}
}

function clear(%to)
{
	if(%to > 2048)
		for(%x=0;%x < 30;%x++)
			client::Sendmessage(%to,1," ");
	else if(%to >= 0 && %to < 7)
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if(Client::getTeam(%cl) == %to)
				for(%x=0;%x < 30;%x++)
					client::Sendmessage(%cl,1," ");
	else
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			for(%x=0;%x < 30;%x++)
				client::Sendmessage(%cl,1," ");

}

function Listplayers()
{
	%num = 0;
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
	{
		%num++;
		%display = %i @ ": " @ Client::getname(%i);
		%display = AddWhitespace(%display,23)@ "at " @ Client::getTransportAddress(%i);
		%display = AddWhitespace(%display,50)@ "Team: " @ Client::getTeam(%i);
		%display = AddWhitespace(%display,59)@ "ST: " @ GetSpawnTime(%i);
		%display = AddWhitespace(%display,71)@ "SC: " @ %i.score;
		Echo(%display);

	}
	//echo("Happyness at: " @ $HAPPYNESS @  "%" );
	echo(%Num  @ " Players");
}

//Adds whitespace to the end of a message. The total message length returned will be equal to %number

function AddWhiteSpace(%message,%number)
{
	%num = 0;
	for(%x = 0; %x < 100; %x++)
	{
		if(string::getsubstr(%message,%x,1) == "")
		{
			%num = %x;			
			break;
		}
	}
	for(%x = %number - %num ;%x > 0 ; %x--)
	{
		%message = %message @ " ";
	
	}
	return %message;	
}

function String::length(%message)
{
	for(%x = 0; true; %x++)
	{
		if(string::getsubstr(%message,%x,1) == "")
		{
			return %x;
		}
	}
}

function String::len(%message)
{
	String::length(%message);
}
function String::getlength(%message)
{
	String::length(%message);
}
function Strlen(%message)
{
	String::length(%message);
}

function knife(%client, %num, %override)
{
	%pos = gamebase::Getposition(%client);
	if(!%num || %num == "")
		%num = 5;
	if(%num > 10 && !%override)
	{
		echo("Yikes! And crash the server? ( third param = 1 to override)");
		return;
	}

	player::Setitemcount(2049,shieldpack,0);
	Client::getOwnedObject(%client).shieldstrength =0;

	%num = floor(%num/2);
	for(%x =-1*%num;%x <%num+1; %x++)
	{
		for(%y =-1*%num;%y <%num+1; %y++)
		{
			
			%obj = newObject("","Item","Knife",1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);	
			%obj.dangerous = true;
			gamebase::setposition(%obj,vector::add(%pos,%x@" "@ %y @" "@ "20"));
			schedule("Deleteobject("@%obj@");",3);
	
		}
	}
}

// Doesn't work. Use Vector::Reflect();
function Vector::reflectByMatrix(%incident,%normal)
{
	// Make sure these are normalized
	%incident = Vector::normalize(%incident);
	%normal = Vector::normalize(%normal);

	// Break things up
	
	%n[0] = getWord(%normal,0);
	%n[1] = getWord(%normal,1);
	%n[2] = getWord(%normal,2);

	%i[0] = getWord(%Incident,0);
	%i[1] = getWord(%Incident,1);
	%i[2] = getWord(%Incident,2);


	// Compute Reflection matrix
	
	%m[0,0] =-1*pow(%n[0],2)+pow(%n[1],2)+pow(%n[2],2);	%m[0,1] =-2*%n[0]*%n[1];				%m[0,2] =-2*%n[0]*%n[2];
	%m[1,0] =-2*%n[0]*%n[1];				%m[1,1] =-1*pow(%n[1],2)+pow(%n[0],2)+pow(%n[2],2);	%m[1,2] =-2*%n[1]*%n[2];
	%m[2,0] =-2*%n[0]*%n[2];				%m[2,1] =-2*%n[1]*%n[2];				%m[2,2] =-1*pow(%n[2],2)+pow(%n[1],2)+pow(%n[0],2);


	// Multiply R-Matrix by incident

	%rx = %m[0,0]*%i[0] + %m[0,1]*%i[1] + %m[0,2]*%i[2];
	%ry = %m[1,0]*%i[0] + %m[1,1]*%i[1] + %m[1,2]*%i[2];
	%rz = %m[2,0]*%i[0] + %m[2,1]*%i[1] + %m[2,2]*%i[2];

	
	// Put it back togeather

	%Reflection = %rx@" "@%ry@" "@%rz;
	//%Reflection = vector::normalize(%Reflection); // Shouldn't be necessary
	return %reflection;
}

function Vector::Reflect(%incident,%normal)
{
	// Make sure these are normalized
	%incident = Vector::normalize(%incident);
	%normal = Vector::normalize(%normal);

	// Break things up
	
	%n[0] = getWord(%normal,0);
	%n[1] = getWord(%normal,1);
	%n[2] = getWord(%normal,2);

	%i[0] = getWord(%Incident,0);
	%i[1] = getWord(%Incident,1);
	%i[2] = getWord(%Incident,2);

	
	// Grab angles.

	%nTheta[0] = arcsin(%n[0]);
	%nTheta[1] = arcsin(%n[1]);
	%nTheta[2] = arcsin(%n[2]);

	%iTheta[0] = arcsin(%i[0]);
	%iTheta[1] = arcsin(%i[1]);
	%iTheta[2] = arcsin(%i[2]);


	// Reflect...

	%rTheta[0] = %nTheta[0]*2 -%iTheta[0];
	%rTheta[1] = %nTheta[1]*2 -%iTheta[1];
	%rTheta[2] = %nTheta[2]*2 -%iTheta[2];


	// Grab our vector.	

	%rx = sin(%rTheta[0]);
	%ry = sin(%rTheta[1]);
	%rz = sin(%rTheta[2]);


	// Put it back togeather

	%Reflection = %rx@" "@%ry@" "@%rz;
	//%Reflection = vector::normalize(%Reflection); // Shouldn't be necessary
	return %reflection;
}

$PI = 3.141592654;

function sin(%x,%accuracy)
{
	if(%x == 0)
		return 0;
	%result = cos(%x-$PI/2,%accuracy);
	return %result;
}
function cos(%x,%accuracy)
{
	if(%x == 0)
		return 1;
	if(!%accuracy)
		%accuracy = 10;
	%result = 1;
	for(%i = 2; %i < 2*%accuracy;%i = %i+2)
	{
		%result	= %result + pow(-1,(%i/2))*(pow(%x,%i)/bang(%i));
	}	
	return %result;
}

function arccos(%x,%accuracy)
{
	if(%x == 0)
		return $PI/2;
	if(%x == 1)
		return 0;
	if(%x == -1)
		return $PI;
	if(%x > 1 || %x < -1)
		return NAN;

	%result = $PI/2 - arcsin(%x);
	return %result;
}

function arcsin(%x,%accuracy)
{
	if(%x == 0)
		return 0;
	if(%x == 1)
		return $PI/2;
	if(%x == -1)
		return -1*$PI/2;
	if(%x > 1 || %x < -1)
		return NAN;
	if(!%accuracy)
		%accuracy = 10;
	%result = 0;
	
	for(%n=1;%n <%accuracy;%n++)
	{
		%result = %result + pow((2*%x),(2*%n))/(pow(%n,2)*choose(2*%n,%n));
	}
	%result = sqrt(%result/2);
	return %result;
}

function choose(%n,%k)
{
	return bang(%n)/(bang(%n-%k)*bang(%k));
}

function bang(%x)
{
	%results = 1;
	while(%x > 0)
	{
		%results = %results *%x;
		%x = %x-1;
	}
	return %results;
}
