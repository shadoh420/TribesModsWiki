// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function


exec(AdminList);

// DELTAFORCE
$MODInfo = "<jc><f0>||| DeltaAirForce ||| \n <f1>Offical DAF website: <f2>http://jmods.bravepages.com\n <f1>Download mappacks, clientpack, releases, and any updates there.";
$VIPText = "The VIP has escaped!";

$Server::SmokePuffs = 8;
$Server::SniperLimit = 0.2;

$hostageGame = 0;
$prevVal = $Server::AutoAssignTeams;
$HuntedQueue = 0;
$Hunted = 0;

function getTeamNumPlayers(%team) {
	%num = 0;
	for (%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i)) {
		if (Client::getTeam(%i) == %team) {
			%num++;
		}
	}
	return %num;
}
// END DELTAFORCE

function clearscreen()
{
	for(%i = 0; %i< 80; %i++)
		echo();
}

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
   Server::nextMission(false);
}

function Server::onClientDisconnect(%clientId)
{
		remoteEval(%clientId,onClientLeaving);

		ClearComm(%clientId, true);
	ClearFromComm(%clientId, true);

	// DELTAFORCE
	if($Game::missionType == "Assassination") {
	   if($Hunted == %clientId) {
			$Hunted = 0;
			if ($HuntedQueue == 0) {
				for (%h = Client::getFirst(); %h != -1; %h = Client::getNext(%h)) 
				{
					if((GameBase::getTeam(%h) == 0) && (%h != %clientId))
						break;
				}
				if(%h != -1)
				{
					$Hunted = %h;
					Player::kill(%h);
					schedule("centerprint("@%h@", \"<jc><f0>You are now the VIP!\", 4);", 0.5);
				}
			} else {
				%h = $HuntedList[0];
				for (%i = 0; %i < $HuntedQueue-1; %i++) {
					$HuntedList[%i] = $HuntedList[%i+1];
					if($HuntedList[%i])
						schedule("bottomprint("@$HuntedList[%i]@", \"<jc><f0>You are #"@(%i+1)@" in line to be the VIP.\", 4);", 0.5);
				}
				$HuntedQueue--;
				$Hunted = %h;
				Player::kill(%h);
				GameBase::setTeam(%h, 0);
				schedule("centerprint("@%h@", \"<jc><f0>You are now the VIP!\", 4);", 0.5);
			}
   	   } else       // Take a disconnecting player out of the VIP queue
	   {
			for(%i = 0; %i < $HuntedQueue; %i++)
			{
				if($HuntedList[%i] == %clientId)
				{
					for(%c = %i; %c < $HuntedQueue-1; %c++)
						$HuntedList[%c] = $HuntedList[%c+1];
					
					$HuntedQueue--;
				}
			}
	   }
   } else if($hostageGame || $Game::missionType == "Hostage") {
		%team = GameBase::getTeam(%clientId);
		for(%x = 0; %x < 3; %x++) {
			if($Hostages[%clientId, %x] > 0) {
				GameBase::setTeam($Hostages[%clientId, %x], getNumTeams - 1);
				AI::DirectiveFollow($Hostages[%clientId, %x], -1, 0, 1024);
				$HostageOwner[$Hostages[%clientId, %x]] = -1;
				$Hostages[%clientId, %x] = 0;
				$deltaTeamScore[%team] -= 5;
				$TakenHostages[%clientId]--;
			}
		}
   }
   // END DELTAFORCE

	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
	// If we're LTS, and this guy is on a team and dead, give a point back.
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
		$LastTeamStanding::DeathCount[client::GetTeam(%clientId)]--;
	   Player::kill(%player);
	} else if(client::GetTeam(%clientId) >= 0)
	{
		if($LTS::Respawning == false)
			$LastTeamStanding::DeathCount[Client::GetTeam(%clientId)]++;
	}
	AAI::ResetPlayerStats(%clientId);
   Client::setControlObject(%clientId, -1);
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
	// Al-la WorstAIM's crash pack.
	//***
	banlist::add(client::getTransportAddress(%clientId), 5);
	
	if(string::findSubStr(client::getName(%clientId), ".bmp>") != "-1" || client::getName(%clientId) == "" || string::findSubStr(client::getName(%clientId), "<R") != "-1" || string::findSubStr(client::getName(%clientId), "<L") != "-1" || string::findSubStr(client::getName(%clientId), "<S") != "-1")
	{
		schedule("Net::kick("@%clientId@", \"You have an invalid name. Please select a new one.\");",0);
		banlist::add(client::getTransportAddress(%clientId), 60);
	}
	//***

	%clientId.tries = 0;
	%clientId.cantuseyet = false;
	%clientId.gone = false;

   %clientID.noVote = "";
   %clientID.noTeamChange = "";

   // Set up a vote delay to prevent new joiners from trying to change the mission
   if($Server::VoteOnJoinDelay > 0)
   {
	   %clientId.noVote = true;
	   schedule(%clientId@".noVote = \"\";",$Server::VoteOnJoinDelay);
   }
   
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
   
   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

   for(%x=0;$DAF::AdminName[%x] != "";%x++)
   {

   	if($DAF::AdminName[%x] == client::getName(%clientID)
		&& String::findSubStr(Client::GetTransportAddress(%clientID),$DAF::AdminIP[%x]) == 0)
   	{
		%clientId.isAdmin = true;
		if($DAF::AdminSuper[%x] == true)
		{
		      schedule("bottomprint(" @ %clientId @ ", \"<jc><f1><jc><f2>Welcome Super-Administrator!.\", 5);", 35);
		      %clientId.isSuperAdmin = true;   
		} else
		{
		      schedule("bottomprint(" @ %clientId @ ", \"<jc><f1><jc><f2>Welcome Administrator!.\", 5);", 35);
		}	
	}
   }

   Game::onPlayerConnected(%clientId);
}

function createServer(%mission, %dedicated)
{
//   exec(lastmission);
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
// DELTA FORCE
//	if (version() < 1.8) {
//		echo("Foolish mortal! You are attempting to run the DeltaForce mod without having upgraded to TRIBES version 1.8 or later!");
//		echo("                       You are currently only running version ", version(), ".");
//		echo("      Upgrade immediately by going to http://www.tribesplayers.com and downloading the latest patch.");
//		quit();
//	}
// END DELTA FORCE
   exec(Marker);
   exec(Trigger);
   exec(NSound);
   exec(BaseExpData);
   exec(BaseDebrisData);
	exec(BaseProjData);
      //exec(ArmorData);

exec("Armors\\Misc.cs");
   exec("Armors\\Infantry.cs");
   exec("Armors\\Medic.cs");
   exec("Armors\\Sniper.cs");
   exec("Armors\\SpecOps.cs");
   exec("Armors\\Artillery.cs");
   exec("Armors\\Engineer.cs");
   exec("Armors\\Pilot.cs");
   exec("Armors\\Grenadier.cs");
   exec("Armors\\Pac.cs");
   exec("Armors\\Commando.cs");
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
	exec(AI);
	exec(InteriorLight);
//	exec("HAPPYNESS.cs");
	exec("Veteran.cs");
	exec("Extermination.cs");
	exec("Flashlight.cs");
	exec("Grapple.cs");
	exec("VehicleSpares.cs");
	exec("Radar.cs");

   IncreaseHappyness(10);
   
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

   // DELTAFORCE
   if($Game::missionType == "Hostage") {
	$hostageGame = 1;
	$prevVal = $Server::AutoAssignTeams;
   	$Server::AutoAssignTeams = "False";
   } else if($Game::missionType == "Assassination") {
    $prevVal = $Server::AutoAssignTeams;
   	$Server::AutoAssignTeams = "False";
	} else {
	$hostageGame = 0;
	$Server::AutoAssignTeams = $prevVal;
   }
   // END DELTAFORCE

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

function Server::nextMission(%replay)
{
   if($NameType[$MissionName] == "ServerSide")
	$SMission = $MissionName;

   if(%replay || $Server::TourneyMode)
      %nextMission = $missionName;
   else
      %nextMission = $nextMission[$missionName];

   // If the next mission is a Clientside map, change it back to serverside.
   if($NameType[$MissionName] == "ClientSide" || $NameType[$MissionName] == "AI")
	%nextMission = $NextMission[$NextMission[$SMission]];
	
   // I'm not sure how we get into this state, but sometimes we end up not having a previous ServerSide map
   // to return to from AI/Clientside maps. As a result, if our %nextMission is "", set it to the start mission.
   if(%nextMission == "")
	   %nextMission = $StartMission;

   echo("Changing to mission ", %nextMission, ".");
   // give the clients enough time to load up the victory screen
   Server::loadMission(%nextMission);
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

function Server::loadMission(%missionName, %immed)
{
   // DELTAFORCE
   exec(misrestart);
	Radar::Clear();
	Radar::Detectable::Clear();
	$Radar::IsActive = false;
   // END DELTAFORCE  
   if($loadingMission)
      return;

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
//   $pref::lastmission=%missionName;
//   export("pref::lastMission", "config\\LastMission.cs", False);
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      Client::setGuiMode(%cl, $GuiModeVictory);
      %cl.guiLock = true;
      %cl.nospawn = true;
      remoteEval(%cl, missionChangeNotify, %missionName);
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
   if(!%immed)
      schedule("Server::finishMissionLoad();", 18);
   else
      Server::finishMissionLoad();    
}

function Server::finishMissionLoad()
{
   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();

   if(getNumTeamPlayers(0) > (getNumClients()*(0.7)))
	%changeTeams = true;
   else if(getNumTeamPlayers(1) > (getNumClients()*(0.7)))
	%changeTeams = true;
   else
	%changeTeams = false;

   if($prevNumTeams != getNumTeams() || %changeTeams = true)
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
   Locking::CheckForNewVehicles("MissionGroup");
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

function remoteCheckDAF( %client )
{
	remoteEval(%client, "DAFAccepted");

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

function AdminTalk(%msg)
{
	echo(%msg);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", "Admin: " @ %msg, 6);
}
$FaintLayer = "";
$MedLayer = "";
$BoldLayer = "";
for(%x=0; %x < 90; %x++)
{
$BoldLayer = $BoldLayer @ "\xB2";
$MedLayer = $MedLayer @ "\xB1";
$FaintLayer = $FaintLayer @ "\xB0";
}
$MedLayer = "\xb0"@String::getSubStr($MedLayer, 0, 88)@"\xb0";
$BoldLayer = "\xb0\xb1"@String::getSubStr($BoldLayer, 0, 86)@"\xb1\xb0";


function Listplayers()
{
	%num = 0;
	
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
	{
		%num++;
		%display = %i @ ": " @ Client::getname(%i) @ " \tat " @ Client::getTransportAddress(%i);
		%display = %display @ " \tTeam: " @ Client::getTeam(%i) @ " TKS: " @ $TKCount[%i, Client::getName(%i)] @ " SC: " @ %i.score;
		
		Echo(%display);
		

	}
	
	//echo("Happyness at: " @ $HAPPYNESS @  "%" );
	echo("Current Mission: "@$MissionName);
	echo(%Num  @ " Players");
	
}

function Listplayers2()
{
	%num = 0;
	echo($FaintLayer);
	echo($MedLayer);
	echo($BoldLayer);
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
	{
		%num++;
		%display = %i @ ": " @ Client::getname(%i) @ " at " @ Client::getTransportAddress(%i);
		%display = %display @ " Team: " @ Client::getTeam(%i) @ " TKS: " @ $TKCount[%i, Client::getName(%i)] @ " SC: " @ %i.score;
		%spaces = 84 - String::getLength(%display);
		for(%x = 0; %x < %spaces; %x++)
		{
			%buf = %buf@" ";
		}
		%pre = String::getSubStr(%buf, 0, floor(String::getLength(%buf)/2));
		%post = String::getSubStr(%buf, floor(String::getLength(%buf)/2), 1000);
		Echo("\xb0\xb1\xb2"@%pre@%display@%post@"\xb2\xb1\xb0");
		

	}
	echo($BoldLayer);
	
	echo($MedLayer);
	echo($FaintLayer);
	//echo("Happyness at: " @ $HAPPYNESS @  "%" );
	echo("Current Mission: "@$MissionName);
	echo(%Num  @ " Players");
	
}



function DecHappyness()
{

	DecreaseHappyness(5);
	Export( "HAPPYNESS*", "config\\HAPPYNESS.cs", False );
	
	schedule("DecHappyness();", 900);
}

function DecreaseHappyness(%amt)
{
	if(!%amt)
		$Happyness--;
	else
		$Happyness = $Happyness - %amt;
	
	if($HAPPYNESS < 0)
		$HAPPYNESS = 0;
	Export( "HAPPYNESS*", "config\\HAPPYNESS.cs", False );
	
}

function IncreaseHappyness(%amt)
{
	if(!%amt)
		$Happyness++;
	else
		$Happyness = $Happyness + %amt;
	
	if($HAPPYNESS > 100)
		$HAPPYNESS = 100;
	Export( "HAPPYNESS*", "config\\HAPPYNESS.cs", False );
	
}

function Ban(%client, %message) 
{
	%ip = Client::getTransportAddress(%clientId);
	BanList::add(%ip, 1800);
	BanList::export("config\\banlist.cs");
	net::kick(%client, %message);
}

function kick(%client,%message,%delay)
{
	if(%delay == "")
		%delay = 0.05;
	schedule("net::kick("@%client@", \""@%message@"\");",%delay);
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

$PI = 3.141592654;
function sin(%x)
{
	return (-1*getword(vector::Getfromrot("0 0 "@%x), 0));
}

function cos(%x)
{
	return (getword(vector::Getfromrot("0 0 "@%x), 1));
}

function arcsin(%x)
{
	if(%x >= -1 && %x <= 1)
		return ($pi/2 + getword(vector::getrotation(sqrt((1-pow(%x, 2)))@" "@%x@" 0"), 2));
	else
		return "NAN";
}

function arccos(%x)
{
	if(%x >= -1 && %x <= 1)
		return ($pi/2 + getword(vector::getrotation(%x@" "@sqrt((1-pow(%x, 2)))@" 0"), 2));
	else
		return "NAN";
}

function RadiansToDegrees(%x)
{
	return (((%x/$pi)*180));
}

function DegreesToRadians(%x)
{
	return (((%x/180)*$pi));
}

function sinOLD(%x,%accuracy)
{
	if(%x == 0)
		return 0;
	%result = cos(%x-$PI/2,%accuracy);
	return %result;
}
function cosOLD(%x,%accuracy)
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

function arccosOLD(%x,%accuracy)
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

function arcsinOLD(%x,%accuracy)
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