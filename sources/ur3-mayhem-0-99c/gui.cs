//------------------------------------
//
// Game/network functions
//
//------------------------------------

function checkMasterTranslation()
{
   for(%i = 0; %i < $Server::numMasters; %i++)
   {
      %mstr = DNet::getResolvedMaster(%i);
      if(%mstr != "")
         $Server::XLMasterN[%i] = %mstr;
      $inet::master[%i+1] = $Server::XLMasterN[%i];
   }
}


function selectNewMaster()
{
	$Server::XLMaster1 = "";
	$inet::Master1 = "";

	//translate the address
	%translatedAddress = "";
	if ($Server::Master1 != "") %translatedAddress = DNet::translateAddress($Server::Master1, 5000);
	if (%translatedAddress == "")
	{
		GuiPopDialog(MainWindow, 0);
		GuiPushDialog(MainWindow, "gui\\DNSWarning.gui");
		%mesg = "Internet Connection Problem: Unable to resolve hostname from address: <f1>" @ $Server::Master1 @ ".<f0>  Be aware that you may experience timeout problems while refreshing your game server list.  Ensure your internet connection is operational, and that the master server chosen from the <f1>network options<f0> menu is valid.";
		schedule("Control::setValue(DNSWarningTextFormat, \"" @ %mesg @ "\");", 1);
	}
	else
	{
		GuiPopDialog(MainWindow, 0);
		$Server::XLMaster1 = %translatedAddress;
		$inet::Master1 = %translatedAddress;
	}
}

function translateMasters()
{
	if ($DNSLookupFinished) return;
	$DNSLookupFinished = TRUE;
	echo("Verifying Internet connection - please wait...");
	if (! $dedicated) renderCanvas(MainWindow);
	%finished = false;
	%num = 1;
	if ($Server::Master1 == "") %finished = TRUE;
	while (! %finished)
	{
		//translate the address
		%translatedAddress = DNet::translateAddress($Server::Master[%num], 5000);

		//if the translation failed, push the warning dialog and exit
		if (%translatedAddress == "" && %num == 1 && (! $dedicated))
		{
			%succeeded = FALSE;
			GuiPushDialog(MainWindow, "gui\\DNSWarning.gui");
			%mesg = "Unable to resolve hostname from address: <f1>" @ $Server::Master1 @ ".<f0>  Be aware that you may experience timeout problems while refreshing your game server list.  Ensure your internet connection is operational, and that the master server chosen from the <f1>network options<f0> menu is valid.";
			schedule("Control::setValue(DNSWarningTextFormat, \"" @ %mesg @ "\");", 1);
		}
		else if (%translatedAddress != "")
		{
			$Server::XLMaster[%num] = %translatedAddress;
		}
		$inet::Master[%num] = $Server::XLMaster[%num];
		%num++;
		if ($Server::Master[%num] == "")
		{
			//we're finished - also pop the verification dialog
			%finished = TRUE;
		}
	}
}

function DNSWarning::retry()
{
	GuiPopDialog(MainWindow, 0);
	$DNSLookupFinished = FALSE;
	translateMasters();
}

function DNSWarning::cancel()
{
	GuiPopDialog(MainWindow, 0);
}

function QuickStart()
{
	$ConnectedToServer = FALSE;
   setCursor(MainWindow, "Cur_Arrow.bmp");
	cursorOn(MainWindow);
	$QuickStart = TRUE;
	if ($PlayingDemo)
	{
		$PlayingDemo = FALSE;
		GuiLoadContentCtrl(MainWindow, "gui\\Recordings.gui");
	}
	else if ($PCFG::Name == "")
	   GuiLoadContentCtrl(MainWindow, "gui\\PlayerSetup.gui");
	else if ($pref::PlayGameMode == "")
	   GuiLoadContentCtrl(MainWindow, "gui\\Connect.gui");
	else if ($Pref::PlayGameMode == "JOIN")
	   GuiLoadContentCtrl(MainWindow, "gui\\JoinGame.gui");
	else if ($pref::PlayGameMode == "TRAIN")
	   GuiLoadContentCtrl(MainWindow, "gui\\training.gui");
	else
	   GuiLoadContentCtrl(MainWindow, "gui\\CreateServer.gui");

	//autologin to the irc client
	IRCLogin::AutoConnect();
}

function PlayerSetupNext()
{
	if ($QuickStart == "TRUE")
		QuickStart();
	else
	{
		if ($PCFG::Name == "")
			OpenNewPlayerDialog();
		else
		   GuiLoadContentCtrl(MainWindow, "gui\\Connect.gui");
	}
}

function JoinGame()
{
	if ($IRC::DisconnectInSim == "")
		$IRC::DisconnectInSim = true;

	//disconnect from IRC if req'd
	if ($IRC::DisconnectInSim == true)
	{
		ircDisconnect();
		$IRCConnected = FALSE;
		$IRCJoinedRoom = FALSE;
	}
	//load the "connecting" gui
	GuiLoadContentCtrl(MainWindow, "gui\\Connecting.gui");

   $SinglePlayer = False;
   purgeResources();
   connect($Server::Address);
}

function EndGame()
{
	$ConnectedToServer = FALSE;
   setCursor(MainWindow, "Cur_Arrow.bmp");
   disconnect();
   if ($SinglePlayer)
	   TrainingEndGameCallback();

	if ($pref::userCDOverride == False)
	{
		rbSetPlayMode (CD, 0);
		rbStop (CD);
		$cdTrack = "";
	}
	$recordDemo = FALSE;
   startMainMenuScreen();
   deleteServer();
	QuickStart();
   deleteObject(ConsoleScheduler);
   newObject(ConsoleScheduler, SimConsoleScheduler);
}

function Canvas::handleEscapeKey()
{
	if ($ConnectedToServer && $InLobbyMode)
	{
		Client::exitLobbyMode();
		return "true";
	}
	return "false";
}

function startMainMenuScreen()
{
   GuiLoadContentCtrl(MainWindow, "gui\\MainMenu.gui");
	translateMasters();

	if ($pref::userCDOverride == False)
	{
		rbSetPlayMode (CD, 0);
		rbStop (CD);
		$cdPlayMode = 1;
		$cdTrack = 2;
		if ($pref::cdMusic)
			rbPlay (CD, $cdTrack);
	}
	else if ($Override == "")
	{
		$Override = True;
		rbStop (CD);
		rbSetPlayMode (CD, 2);
		rbPlay (CD);
	}
   setCursor(MainWindow, "Cur_Arrow.bmp");
   cursorOn(MainWindow);
}

function loadPlayGui()
{
	if (File::FindFirst("play.gui") != "")
		GuiLoadContentCtrl(MainWindow, "play.gui");
	else
		GuiLoadContentCtrl(MainWindow, "gui\\play.gui");
}

function switchToChat()
{
	if ($IRCConnected == "TRUE")
		GuiLoadContentCtrl(MainWindow, "gui\\IRCChat.gui");
	else
		GuiLoadContentCtrl(MainWindow, "gui\\IRCLogin.gui");
}

//-----------------------------------------------
//
// onExit() is called when the program terminates
//
//-----------------------------------------------

function onExit()
{
   if(isObject(playGui))
      storeObject(playGui, "config\\play.gui");

   saveActionMap("config\\config.cs", "actionMap.sae", "playMap.sae", "pdaMap.sae");

	//update the video mode - since it can be changed with alt-enter
	$pref::VideoFullScreen = isFullScreenMode(MainWindow);

	echo("exporting pref::* to prefs.cs");
   export("pref::*", "config\\ClientPrefs.cs", False);
   export("Server::*", "config\\ServerPrefs.cs", False);
   export("pref::lastMission", "config\\ServerPrefs.cs", True);
   BanList::export("config\\banlist.cs");
}

//-----------------------------------------------
//
// onQuit() is called when the user clicks the
// in-shell close box
//
//-----------------------------------------------

function onQuit()
{
	GuiPushDialog(MainWindow, "gui\\Exit.gui");
}

function buildMissionList()
{
   $MLIST::Count = 0;
   $MLIST::TypeCount = 1;
   $MLIST::Type[0] = "All Types";
   $MLIST::MissionList[0] = "";

   %file = File::findFirst("missions\\*.dsc");
   while(%file != "")
   {
      $MDESC::Type = "";
      $MDESC::Name = "";
      $MDESC::Text = "";

      exec(%file);

      if($MDESC::Type == "")
      {
         %file = File::findNext("missions\\*.dsc");
         continue;
      }
      for(%i = 0; %i < $MLIST::TypeCount; %i++)
      {
         if($MLIST::Type[%i] == $MDESC::Type)
            break;
      }
      if(%i == $MLIST::TypeCount)
      {
         $MLIST::Type[%i] = $MDESC::Type;
         $MLIST::TypeCount++;
         $MLIST::MissionList[%i] = "";
      }
      %ct = $MLIST::Count;
      $MLIST::Count++;
      
      $MLIST::EType[%ct] = $MDESC::Type;
      $MLIST::EName[%ct] = File::getBase(%file);
      $MLIST::EText[%ct] = $MDESC::Text;
      if($MDESC::Type != "Training")
         $MLIST::MissionList[0] = %ct @ " " @ $MLIST::MissionList[0];
      $MLIST::MissionList[%i] = %ct @ " " @ $MLIST::MissionList[%i];
      %file = File::findNext("missions\\*.dsc");
   }


   for(%type = 1; %type < $MLIST::TypeCount; %type++)
   {
      %prev = getWord($MLIST::MissionList[%type], 0);
      %ml = $MLIST::MissionList[%type] @ %prev;
      %prevName = $MLIST::EName[%prev];
      for(%i = 1; (%mis = getWord(%ml, %i)) != -1; %i++)
      {
         %misName = $MLIST::EName[%mis];
         $nextMission[%prevName] = %misName;
         %prevName = %misName;
      }
   }
}

buildMissionList();

function JoinGameGui::onOpen()
{
	//update the record button
	if (! $recordDemo) $recorderFileName = "";
	Control::setValue(RecordDemo, $recordDemo);
}

function CreateServerGui::onOpen()
{
   TextList::clear(MissionTextList);
   FGCombo::clear(MissionTypePopup);
   for(%i = 0; %i < $MLIST::TypeCount; %i++)
      if($MLIST::Type[%i] != "Training")
         FGCombo::addEntry(MissionTypePopup, $MLIST::Type[%i], %i);

   if($pref::LastMissionType == "" || $pref::LastMissionType >= $MLIST::TypeCount)
      $pref::LastMissionType = 0;
   FGCombo::setSelected(MissionTypePopup, $pref::LastMissionType);
   MissionTypePopup::buildList();

	//verify the max number of players as well...
	verifyMaxPlayers();
	
	//sort the mission text list
	FGTextList::sort(MissionTextList);

	//now set the selected
   MissionTextList::onAction();

	//update the record button
	if (! $recordDemo) $recorderFileName = "";
	Control::setValue(RecordDemo, $recordDemo);
}

function enableHostGame()
{
	%valid = TRUE;

	//check the max number of players
	if ($Server::MaxPlayers < 1 || $Server::MaxPlayers > 128)
	{
		%valid = FALSE;
	}

	//check the server name
	if (String::empty($Server::HostName))
	{
		%valid = FALSE;
	}

	//set the button state
	Control::setActive("CreateServerNow", %valid);
}

function verifyServerName()
{
	if (String::Empty(Control::getValue("CreateServerHostName")))
	{
		Control::setValue("CreateServerHostName", "TRIBES Server");
	}
}

function verifyMaxPlayers()
{
	if (Control::getValue(IDCTG_MAX_PLAYERS) < 1) Control::setValue(IDCTG_MAX_PLAYERS, 8);
	else if (Control::getValue(IDCTG_MAX_PLAYERS) > 32) Control::setValue(IDCTG_MAX_PLAYERS, 32);
	enableHostGame();
}

function TrainingGui::onOpen()
{
   TextList::clear(TrainingMissionTextList);
   for(%i = 0; %i < $MLIST::TypeCount; %i++)
      if($MLIST::Type[%i] == "Training")
         break;

   for(%j = 0; (%mis = getWord($MLIST::MissionList[%i], %j)) != -1; %j++)
      TextList::addLine(TrainingMissionTextList, $MLIST::EName[%mis]);
   
	//sort the training mission text list
	FGTextList::sort(TrainingMissionTextList);

   Control::setValue(TrainingMissionTextList, $pref::LastTrainingMission);
   TrainingMissionTextList::onAction();

   %prev = getWord($MLIST::MissionList[%i], 0);
   %ml = $MLIST::MissionList[%i] @ %prev;
   %prevName = $MLIST::EName[%prev];

	//update the record button
	if (! $recordDemo) $recorderFileName = "";
	Control::setValue(RecordDemo, $recordDemo);
}

function MissionTypePopup::buildList()
{
   %sel = FGCombo::getSelected(MissionTypePopup);
   TextList::clear(MissionTextList);

	//see if it gets added
	%found = FALSE;
   for(%i = 0; (%mis = getWord($MLIST::MissionList[%sel], %i)) != -1; %i++)
	{
      TextList::addLine(MissionTextList, $MLIST::EName[%mis]);
		if ($MLIST::EName[%mis] == $pref::LastMission) %found = TRUE;
	}

	//if the last mission selected was not added, choose the first in the list
	if (%found == FALSE)
	{
	   $pref::lastMission = $MLIST::EName[getWord($MLIST::MissionList[%sel], 0)];
	}

	//sort the mission text list
	FGTextList::sort(MissionTextList);

   Control::setValue(MissionTextList, $pref::LastMission);
   $pref::lastMissionType = %sel;
   MissionTextList::onAction();
}

function MissionTextList::onAction()
{
   $pref::lastMission = Control::getValue(MissionTextList);

   // find the mission number...
   for(%i = 0; %i < $MLIST::Count; %i++)
      if($MLIST::EName[%i] == $pref::lastMission)
         break;

   Control::setValue(MissionDescText, $MLIST::EText[%i]);

}

function TrainingMissionTextList::onAction()
{
   $pref::lastTrainingMission = Control::getValue(TrainingMissionTextList);

   // find the mission number...
   for(%i = 0; %i < $MLIST::Count; %i++)
      if($MLIST::EName[%i] == $pref::lastTrainingMission)
         break;

   Control::setValue(MissionDescText, $MLIST::EText[%i]);

}
//--------------------------------------------------------------------------------------------------

function RecordingsGui::onOpen()
{
	$RecordingsCount = 0;
   EvalSearchPath();
	TextList::clear(RecordingsTextList);
   %rec = File::FindFirst("*.rec");
   while(%rec != "")
   {
      %demo = File::getBase(%rec);
      TextList::addLine(RecordingsTextList, %demo);
      %rec = File::FindNext("*.rec");

		$Recording[$RecordingsCount] = %demo;
		$RecordingsCount++;
   }
	RecordingsGui::verify();
	FGTextList::sort(RecordingsTextList);
	Control::setValue(RecordingsContinuous, $pref::RecordingsContinuous);
}

function RecordingsGui::verify()
{
	if (Control::getValue(RecordingsTextList) == "")
	{
		%selected = FALSE;
	}
	else
	{
		%selected = TRUE;
	}
	Control::setActive(RecordingsRemove, %selected);
	Control::setActive(RecordingsRename, %selected);
	Control::setActive(RecordingsPlayDemo, %selected);
}

function RecordingsGui::PlayDemo()
{
	%fileName = "recordings\\" @ Control::getValue(RecordingsTextList) @ ".rec";
	if (isFile(%fileName))
	{
		$PlayingDemo = TRUE;
	   playDemo("recordings\\" @ Control::getValue(RecordingsTextList) @ ".rec");
		cursorOn(MainWindow);
	   GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
		renderCanvas(MainWindow);
	}
	else
	{
		RecordingsGui::onOpen();
	}
}

function RecordingsGui::removeSelectedDemo()
{
	if (Control::getValue(RecordingsTextList) != "")
	{
		%srcFile = "recordings\\" @ Control::getValue(RecordingsTextList) @ ".rec";

		//delete the file
		File::delete(%srcFile);

		//now repopulate the list
		RecordingsGui::onOpen();
	}
}

function RecordingsGui::renameSelectedDemo()
{
	//first copy the old
	%newName = Control::getValue(RenameDemoText);
	if (Control::getValue(RecordingsTextList) != "" && %newName != "")
	{
		%srcFile = "recordings\\" @ Control::getValue(RecordingsTextList) @ ".rec";
		if (String::findSubStr(%newName, ".rec") >= 1)
		{
			%destFile = "recordings\\" @ %newName;
		}
		else
		{
			%destFile = "recordings\\" @ %newName @ ".rec";
		}

		//copy the file
		if (File::copy(%srcFile, %destFile))
		{
			//delete the old
			File::delete(%srcFile);

			//now repopulate the list
			RecordingsGui::onOpen();

			//reselect the new name
			TextList::setSelected(RecordingsTextList, %newName);
			RecordingsGui::verify();
			GuiPopDialog(MainWindow, 0);
		}
		else
		{
			GuiPopDialog(MainWindow, 0);
			GuiPushDialog(MainWindow, "gui\\MessageDialog.gui");
			Control::setValue(MessageDialogTextFormat, "Unable to save recording as <f1>" @ %newName @ ".<f0>  Please ensure the new name is a valid file name.");
		}
	}
}

function RenameDemoText::onAction()
{
	if (! String::empty(Control::getValue(RenameDemoText)))
	{
		Control::setActive(IDCTG_RENAME_DEMO_DONE, TRUE);
	}
	else
	{
		Control::setActive(IDCTG_RENAME_DEMO_DONE, FALSE);
	}
}

function RecordingsGui::playRandom()
{
	if ($RecordingsCount > 0 && $pref::RecordingsContinuous)
	{
		%randomNum = floor(getRandom() * ($RecordingsCount - 0.01));
		Control::setValue(RecordingsTextList, $Recording[%randomNum]);
		RecordingsGui::PlayDemo();
	}
}

//--------------------------------------------------------------------------------------------------

// button names are favbutton1...favbutton5, markfavoritesButton, buyFavoritesButton

function BuyList::onSelect(%sel)
{
   ShapeView::setItem(ItemView, %sel);
   //echo(%sel);
}

function BuyList::onDoubleClick(%sel)
{
   remoteEval(2048, "buyItem", %sel);
   //echo("BuyD " @ %sel);
}

function InventoryList::onSelect(%sel)
{
   ShapeView::setItem(ItemView, %sel);
}

function InventoryList::onDoubleClick(%sel)
{
   remoteEval(2048, "sellItem", %sel);
   //echo("InvD " @ %sel);
}

function CmdInventoryGui::sellSelected()
{
   %sel = Control::getValue(InventoryList);
   if(%sel != -1)
      remoteEval(2048, "sellItem", %sel);
}

function CmdInventoryGui::dropSelected()
{
   %sel = Control::getValue(InventoryList);
   if(%sel != -1)
      remoteEval(2048, "dropItem", %sel);
}

function CmdInventoryGui::useSelected()
{
   %sel = Control::getValue(InventoryList);
   if(%sel != -1)
      remoteEval(2048, "useItem", %sel);
}

function CmdInventoryGui::buySelected()
{
   %sel = Control::getValue(BuyList);
   if(%sel != -1)
      remoteEval(2048, "buyItem", %sel);
}

// ts control's name is ItemView

$curFavorites = -1;

function CmdInventoryGui::onOpen()
{
   if($curFavorites == -1)
   {
      CmdInventoryGui::favoritesSel(1);
      Control::performClick("FavButton1");
   }
}

function CmdInventoryGui::favoritesSel(%favList)
{
   $curFavorites = %favList;
   CmdInventory::setFavorites($pref::favoriteList[$curFavorites]);
}

function CmdInventoryGui::markFavorites()
{
   if($curFavorites != -1)
   {
      $pref::favoriteList[$curFavorites] = CmdInventory::getVisibleSet(InventoryList);
      CmdInventory::setFavorites($pref::favoriteList[$curFavorites]);
   }
}

function CmdInventoryGui::buyFavorites()
{
   if($curFavorites != -1)
   {
      %fav = $pref::favoriteList[$curFavorites];
      %first = getWord(%fav, 0);
      if(%first == -1)
         return;

      %cmd = "remoteEval(2048, buyFavorites, " @ %first;
      for(%i = 1; (%word = getWord(%fav, %i)) != -1; %i++)
         %cmd = %cmd @ ", " @ %word;
      %cmd = %cmd @ ");";
      eval(%cmd);
   }
}

function ConnectGui::ChooseGame()
{
   if($pref::playGameMode == "JOIN")
      GuiLoadContentCtrl(MainWindow, "gui\\joingame.gui");
   else if($pref::playGameMode == "TRAIN")
      GuiLoadContentCtrl(MainWindow, "gui\\training.gui");
   else
      GuiLoadContentCtrl(MainWindow, "gui\\createServer.gui");
}

function LoadingGui::onOpen()
{
   Control::setValue(ProgressSlider, 0.0);
}

//--------------------------------------------------------------------------------------------------
function userCD ()
{
 	$cdPlayMode = 2;
	$pref::cdMusic = False;
	$pref::userCDOverride = True;
	rbStop (CD);
	rbSetPlayMode (CD, $cdPlayMode);
	rbPlay (CD, 1);
}

function gameCD ()
{
	$pref::userCDOverride = False;
	$pref::cdMusic = True;
	rbStop (CD);
	$cdPlayMode = 0;
	rbSetPlayMode (CD, $cdPlayMode);
	rbPlay (CD, 2);
}

//--------------------------------------------------------------------------------------------------
function LobbyGui::onOpen()
{
	Control::setValue(LobbyServerName, $ServerName);
	Control::setValue(LobbyServerType, $ServerMod);
	Control::setValue(LobbyMissionName, $ServerMission);
	Control::setValue(LobbyMissionType, $ServerMissionType);
	Control::setValue(LobbyVersion, $ServerVersion);
	Control::setValue(LobbyAddress, $Server::Address);

   Control::setValue(LobbyServerText, $ServerInfo);
   Control::setValue(LobbyMissionDesc, $ServerText);
}