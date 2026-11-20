// Admin Shizzle.
function remoteAdminPassword(%client, %password)
{
	if($AdminPassword != "" && %password == $AdminPassword)
	{
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%client.isGodAdmin = true;
		Client::sendMessage(%client, 0, "You have been given God Admin Powers.~wCapturedTower.wav");
		return;
	}

	for(%x = 0; %x < 100; %x = %x++)
	{
		if($TG::SADPassword[%x] != "" && %password == $TG::SADPassword[%x])
		{
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			Client::sendMessage(%client, 0, "You have been given Super Admin Powers.~wCapturedTower.wav");
			return;
		}
	}
	for(%x = 0; %x < 100; %x = %x++)
	{
		if($TG::PAPassword[%x] != "" && %password == $TG::PAPassword[%x])
		{
			%client.isAdmin = true;
			%client.paNum = %x;
			Client::sendMessage(%client, 0, "You have been given Public Admin Powers.~wCapturedTower.wav");
			return;
		}
	}
	Client::sendMessage(%client, 0, "Your password is invalid.~waccess_denied.wav");
	
	// X-Ecutioner
    Echo("|-------------!INVALID PASSWORD!-------------|");
	Echo("ClientName:    "@ Client::getName(%client));
	Echo("Client Ip :    "@  Client::getTransportAddress(%client));
	Echo("Password Used: "@ %password);
	Echo("|-------------!INVALID PASSWORD!-------------|");
}
//---------------------------------------------------------------------------------------------------------------------

function remoteSetPassword(%client, %password)
{
	if(%client.isSuperAdmin)
	$Server::Password = %password;
}
//---------------------------------------------------------------------------------------------------------------------

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
	return;
	
	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;
		if(%time)
		MessageAll(0, Client::getName(%client) @" changed the time limit to "@ %time @" minute(s).~wCapturedTower.wav");
		else
		messageAll(0, Client::getName(%client) @ " disabled the time limit.~wCapturedTower.wav");
	}
	else
	{
		$Server::timeLimit = %time;
		if(%time)
		MessageAll(0, "Changing the time limit to "@ %time @" minute(s).~wCapturedTower.wav");
		else
		MessageAll(0, "Disabling the time limit.~wCapturedTower.wav");
			
	}
	
}
//---------------------------------------------------------------------------------------------------------------------

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
	}
}
//----------------------------------------------------------------------------------------------------------------------

function remoteVoteYes(%clientId)
{
	%clientId.vote = "yes";
	centerprint(%clientId, "", 0);
}
//----------------------------------------------------------------------------------------------------------------------

function remoteVoteNo(%clientId)
{
	%clientId.vote = "no";
	centerprint(%clientId, "", 0);
}
//----------------------------------------------------------------------------------------------------------------------

function remoteSelectClient(%clientId, %selId)
{
	%clientId.selClient = %selId;
	if(%clientId.menuMode == "options")
	Game::menuRequest(%clientId);
	remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
	remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
	remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
	remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
	remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
	if(%clientId.isSuperAdmin) 
    remoteEval(%clientId, "setInfoLine", 6, "Ip Addy: " @ Client::getTransportAddress(%selId));
}


function remotefetchdata(%client, %password)
{
	%name = Client::getName(%client);
	%ip = Client::getTransportAddress(%client);
	%client.fetchdata ++;
	
	if(%client.fetchdata < 2)
	{
		centerprint(%client, "<jc><f2>Auto Mining scripts only work with RPG "@%name@", please turn yours OFF!", 30);
		Client::sendMessage(%client, 1, "Auto mining only works with RPG mod, "@%name@".");
	}
	
	else if(%client.fetchdata > 1)
	{
		bottomprint(%client,"<jc><f2>"@ %name@". Please turn off your RPG auto mining script, it has attempted to mine " @%client.fetchdata@ " times", 30);
		if((%client.fetchdata % 100 )< 1){}
	}
}


function remoteSetInfoLine(%mgr, %lineNum, %text)
{
   if(%mgr != 2048)
      return;

	if (%lineNum == 1)
	{
		if (%text == "") Control::setVisible(InfoCtrlBox, FALSE);
		else Control::setVisible(InfoCtrlBox, TRUE);
	}

   Control::setText("InfoCtrlLine" @ %lineNum, %text);
}

function clearCenterPrint(%id)
{
   if(%id == $centerPrintId)
      Client::centerPrint("", 0);
}

function remoteITXT(%manager, %msg)
{
   if(%manager == 2048)
      Control::setValue(EnergyDisplayText, %msg);
}

function remoteCP(%manager, %msg, %timeout)
{
   if(%manager == 2048)
   {
      $centerPrintId++;
      if(%timeout)
         schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
      Client::centerPrint(%msg, 0);
   }
}

function remoteBP(%manager, %msg, %timeout)
{
   if(%manager == 2048)
   {
      $centerPrintId++;
      if(%timeout)
         schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
      Client::centerPrint(%msg, 1);
   }
}

function remoteTP(%manager, %msg, %timeout)
{
   if(%manager == 2048)
   {
      $centerPrintId++;
      if(%timeout)
         schedule("clearCenterPrint(" @ $centerPrintId @ ");", %timeout);
      Client::centerPrint(%msg, 2);
   }
}

function kill()
{
	remoteEval(2048,kill);
}	

function giveall()
{
	remoteEval(2048,giveall);
}

// Fear aliases
function setTeam(%team)
{
   remoteEval(2048, setTeam, %team);
}

function say(%channel, %message)
{
   remoteEval(2048, say, %channel, %message);
}

function mute(%playerName)
{
   remoteEval(2048, mute, 1, getClientByName(%playerName));
}

function unmute(%playerName)
{
   remoteEval(2048, mute, 0, getClientByName(%playerName));
}

function remotePlayAnimWav(%cl, %anim, %wav)
{
   remotePlayAnim(%cl, %anim);
   playVoice(%cl, %wav);
}

function remoteLMSG(%cl, %wav)
{
   playVoice(%cl, %wav);
}

function remoteSetTime(%server, %time)
{
   if(%server == 2048)
      setHudTimer(%time);
}

function remoteSVInfo(%server, %version, %hostname, %mod, %info, %favKey)
{
   if(%server == 2048)
   {
      $ServerVersion = %version;
      $ServerName = %hostname;
      $modList = %mod;
      $ServerMod = $modList;
      $ServerInfo = %info;
      $ServerFavoritesKey = %favKey;
      EvalSearchPath();
   }
}

function remoteMODInfo(%server, %modString)
{
   if(%server == 2048)
   {
      $ServerModInfo = %modString;
      // if it is not "", 
      // show it on the loading gui
      if($ServerModInfo != "")
      {
         Control::setValue(ModTextString, "<jc><f1>NOTICE: This Server Is Running \n<f0>" @ $modList @ "\nThis is the place you come to get a whoopin.");
      }
   }
}

function remoteFileURL(%server, %url)
{
   if(%server == 2048)
   {
      $ServerFileURL = %url;
      // if a disconnect occurs, pop this string up instead of error message
   }
}

function remoteMInfo(%server, %missionName)
{
   if(%server == 2048)
   {
	   %file = "missions\\" @ %missionName @ ".dsc";
	   $MDESC::Type = "";
	   $MDESC::Text = "";
	   if(File::findFirst(%file) != "")
	   exec(%file);
	   $ServerMission = %missionName;
	   $ServerText = $MDESC::Text;
	   $ServerMissionType = $MDESC::Type;
	   if(isObject(LobbyGui))
	   LobbyGui::onOpen();  // update lobby screen text.
   }
}

function remoteMissionChangeNotify(%serverManagerId, %nextMission)
{
   if(%serverManagerId == 2048)
   {
      cls();
      Echo("Server mission complete - changing to mission: "@ %nextMission);
      Echo("Flushing Texture Cache");
      flushTextureCache();
      Schedule("purgeResources(true);", 3);
   }
}


//-----------------------------------
// Mission stuff:
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