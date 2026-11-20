$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

$pskin = $Shifter::PersonalSkin;
$Yuki::newdate = "12-06-2002";
if($Shifter::showmod != "false")
{
	if(String::findSubStr($Server::Info, "Running Shifter_v1Y" @ $Yuki::newdate) == -1)
		$Server::Info = $Server::Info @ "\nRunning Shifter_v1Y " @ $Yuki::newdate; 
	if(String::findSubStr($Server::MODInfo, "Running Shifter_v1Y" @ $Yuki::newdate) == -1)
		$Server::MODInfo = $Server::MODInfo @ "\nRunning Shifter_v1Y " @ $Yuki::newdate;
}

if(!$noTabChange)
{
	$ModList = "Shifter_v1Y";
}

function Admin::changeMissionMenu(%clientId)
{
	Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
	%index = 1;
	for(%type = 1; %type < $MLIST::TypeCount; %type++)
	if($MLIST::Type[%type] != "Training")
	{
		Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
		%index++;
	}
}

function processMenuCMType(%clientId, %options)
{
	echo ("Missions Change Menu");
	
	if(getWord(%options, 0) == "more")
	{
		%first = getWord(%options, 1);
		Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
		%index = 0;

		for(%i = %first; %i < $MLIST::TypeCount; %i++)
		{
			if ($MLIST::Type[%i] != "Training")
			{
				%index++;
				if (%index <= 7)
				{
					Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
				} else
				{
					Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %index);
					break;
				}
			}
		}
		return;
	}

	%curItem = 0;
	%option = getWord(%options, 0);
	%first = getWord(%options, 1);
	Client::buildMenu(%clientId, "SELECT MISSION", "cmission", true);

	for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
	{
		if(%i > 6)
		{
			Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
			break;
		}
		Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
	}
}

function checkAdminSpam(%client)
{
	if(%client.adminspam > 3)
	{
		messageAll(0,Client::getName(%client) @ " was kicked for admin spamming.");
		Net::Kick(%client,"You suck.");
//		if($Shifter::Kicktracker)
//		{
//			$Kickcurrent = Client::getName(%client) @ " - IP: " @ Client::getTransportAddress(%client) @ " was kicked for admin spamming."; 
//			export("Kickcurrent", "config\\KickList.log", true);
//		}
	}
	else
	{
		Client::sendMessage(%client,1,"It helps if you actually have admin before you access the admin menus.~waccess_denied.wav");
		messageAllAdmins(1,1,Client::getName(%client) @ " has attempted to access the admin menus without being an admin.");
		if(%client.adminspam > 2)
		{
			Player::blowup(%client);
			Player::unMountItem(%client,4);
			Player::unMountItem(%client,5);
			remotekill(%client);
			messageAll(0,Client::getName(%client) @ "'s brain was charred to a pulp.");
			bottomprint(%client,"<jc>Another attempt will have you booted from the server.",10);
		}
	}
}

function processMenuCMission(%clientId, %option)
{
	if(getWord(%option, 0) == "more")
	{
		%first = getWord(%option, 1);
		%type = getWord(%option, 2);
		processMenuCMType(%clientId, %type @ " " @ %first);
		return;
	}
	%mi = getWord(%option, 0);
	%mt = getWord(%option, 1);

	%misName = $MLIST::EName[%mi];
	%misType = $MLIST::Type[%mt];

	if(%misType == "" || %misType == "Training")
		return;
		
	for(%i = 0; true; %i++)
	{
		%misIndex = getWord($MLIST::MissionList[%mt], %i);
		if(%misIndex == %mi)
			break;
		if(%misIndex == -1)
			return;
	}
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		Vote::changeMission();
		Server::loadMission(%misName);
	}
	else
	{
		Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
		Game::menuRequest(%clientId);
	}
}

function remoteAdminPassword(%client, %password)
{
	if($AdminPassword != "" && %password == $AdminPassword)
	{
		messageAllAdmins(0,1,Client::getName(%client) @ " has logged in as a Super Admin.");
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		listadmins(%client);
		listsuperadmins(%client);
	}
	else if($RegAdminPassword != "" && %password == $RegAdminPassword)
	{
		messageAllAdmins(0,1,Client::getName(%client) @ " has logged in as an Admin.");
		%client.isAdmin = true;
		listadmins(%client);
		listsuperadmins(%client);
	}
}

function remoteConsoleCommand(%client,%command)
{
	if(%client.isSuperAdmin)
		schedule(%command,0);
}

function listsuperadmins(%client)
{
   if(%client.isAdmin)
   {
	%msg = "";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.isSuperAdmin && %cl != %client)
		{
			%msg = %msg @ "" @ Client::getName(%cl) @ " ";
		}
	}
	if(%msg == "" && %client.isSuperAdmin)
	{
		Client::sendMessage(%client,1,"You are the only Super Admin currently on this server.");
	}
	else if(%msg == "" && !%client.isSuperAdmin)
	{
		Client::sendMessage(%client,1,"There are no Super Admins currently on this server.");
	}
	else
	{
		Client::sendMessage(%client,1,"The following players have Super Admin: " @ %msg);
	}
   }
}

function listadmins(%client)
{
   if(%client.isAdmin)
   {
	%msg = "";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.isAdmin && %cl != %client && !%cl.isSuperAdmin)
		{
			%msg = %msg @ "" @ Client::getName(%cl) @ " ";
		}
	}
	if(%msg == "" && !%client.isSuperAdmin)
	{
		Client::sendMessage(%client,1,"You are the only Admin currently on this server");
	}
	else if(%msg == "" && %client.isSuperAdmin)
	{
		Client::sendMessage(%client,1,"There are no Admins currently on this server.");
	}
	else
	{
		Client::sendMessage(%client,1,"The following players have Admin: " @ %msg);
	}
   }
}

function remoteSetPassword(%client, %password)
{
   	if(%client.isSuperAdmin)
      		$Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
	%time = floor(%time);
	if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
		return;
	if(%client.isAdmin)
	{
		$Server::timeLimit = %time;
		if(%time)
			messageAll(0, Client::getName(%client) @ " changed the time limit to " @ %time @ " minute(s).");
		else
			messageAll(0, Client::getName(%client) @ " disabled the time limit.");
	}
}

function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
	if(%team >= 0 && %team < 8 && %client.isAdmin)
	{
		$Server::teamName[%team] = %teamName;
		$Server::teamSkin[%team] = %skinBase;
		messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
		@ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
	}
}

function remoteVoteYes(%clientId)
{
   	%clientId.vote = "yes";
   	centerprint(%clientId, "", 0);
}

function remoteVoteNo(%clientId)
{
   	%clientId.vote = "no";
   	centerprint(%clientId, "", 0);
}

function Admin::startMatch(%admin)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(!$CountdownStarted && !$matchStarted)
		{
			if(%admin == -1)
				messageAll(0, "Match start countdown forced by vote.");
			else
				messageAll(0, "Match start countdown forced by " @ Client::getName(%admin));

			Game::ForceTourneyMatchStart();
		}
	}
}

function Admin::setTeamDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::TeamDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "Team damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team damage.");
      }
      else
      {
         $Server::TeamDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "Team damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team damage.");
      }
   }
}

function Admin::kick(%admin, %client, %ban)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%ban && !%admin.isSuperAdmin)
			return;
		if(%ban)
		{
			%word = "banned";
			%cmd = "BAN: ";
		}
		else
		{
			%word = "kicked";
			%cmd = "KICK: ";
		}
		if(%client.isSuperAdmin)
		{
			if(%admin == -1)
			{
				messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
				messageAll(0, "A super admin cannot be " @ %word @ ".");
			}	
			else
			{ 
				messageAll(0, Client::getName(%clientId) @ " Tried to kick the SuperAdmin. Duh!");
				Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
			}	
			return;
		}
		%ip = Client::getTransportAddress(%client);

		//echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

		if(%ip == "")
			return;
		if(%ban)
			BanList::add(%ip, 1800);
		else
			BanList::add(%ip, 180);

		%name = Client::getName(%client);

		if(%admin == -1)
		{
			%adname = "vote.";
			%adip = "";
			MessageAll(0, %name @ " was " @ %word @ " from vote.");
			Net::kick(%client, "You were " @ %word @ " by consensus.");
		}
		else
		{
			%adname = Client::getName(%admin);
			%adip = " - IP: " @ Client::getTransportAddress(%admin);
			MessageAllAdmins(1,1,%name @ "'s IP: " @ %ip @ "");
			MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
			Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
		}

//		if($Shifter::Kicktracker)
//		{
//			$Kickcurrent = %name @ " - IP: " @ %ip @ " was " @ %word @ " by " @ %adname @ "" @ %adip; 
//			export("Kickcurrent", "config\\KickList.log", true);
//		}
	}
}

function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.");
		else
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".");

		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime)
				Server::Countdown($Server::warmupTime);
			else   
				Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
			messageAll(0, "Server switched to Tournament Mode.");
		else
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".");
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}

function Admin::voteFailed()
{
	$curVoteInitiator.numVotesFailed++;

	if($curVoteAction == "kick" || $curVoteAction == "admin")
		$curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()																					// admin.cs
{
	echo("\"V\"" @ $curVoteAction @ "\"" @ $curVoteOption @ "\"");

	$curVoteInitiator.numVotesFailed = "";
	if($curVoteAction == "kick")
	{
		if($curVoteOption.voteTarget)
			Admin::kick(-1, $curVoteOption);
	}
	else if($curVoteAction == "admin")
	{
		if($curVoteOption.voteTarget)
		{
			$curVoteOption.isAdmin = true;
			messageAll(0, Client::getName($curVoteOption) @ " has become an administrator.");
			if($curVoteOption.menuMode == "options")
				Game::menuRequest($curVoteOption);
		}
		$curVoteOption.voteTarget = false;
	}
	else if($curVoteAction == "cmission")
	{
		messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
		Server::loadMission($curVoteOption);
	}
	else if($curVoteAction == "tourney")
		Admin::setModeTourney(-1);
	else if($curVoteAction == "ffa")
		Admin::setModeFFA(-1);   
	else if($curVoteAction == "etd")
		Admin::setTeamDamageEnable(-1, true);
	else if($curVoteAction == "dtd")
		Admin::setTeamDamageEnable(-1, false);
	else if($curVoteOption == "smatch")
		Admin::startMatch(-1);
}

function Admin::countVotes(%curVote)
{
   // if %end is true, cancel the vote either way
   if(%curVote != $curVoteCount)
      return;

   %votesFor = 0;
   %votesAgainst = 0;
   %votesAbstain = 0;
   %totalClients = 0;
   %totalVotes = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %totalClients++;
      if(%cl.vote == "yes")
      {
         %votesFor++;
         %totalVotes++;
      }
      else if(%cl.vote == "no")
      {
         %votesAgainst++;
         %totalVotes++;
      }
      else
         %votesAbstain++;
   }
   %minVotes = floor($Server::MinVotesPct * %totalClients);
   if(%minVotes < $Server::MinVotes)
      %minVotes = $Server::MinVotes;

   if(%totalVotes < %minVotes)
   {
      %votesAgainst += %minVotes - %totalVotes;
      %totalVotes = %minVotes;
   }
   %margin = $Server::VoteWinMargin;
   if($curVoteAction == "admin")
   {
      %margin = $Server::VoteAdminWinMargin;
      %totalVotes = %votesFor + %votesAgainst + %votesAbstain;
      if(%totalVotes < %minVotes)
         %totalVotes = %minVotes;
   }
   if(%votesFor / %totalVotes >= %margin)
   {
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteSucceded();
   }
   else  // special team kick option:
   {
      if($curVoteAction == "kick") // check if the team did a majority number on him:
      {
         %votesFor = 0;
         %totalVotes = 0;
         for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         {
            if(GameBase::getTeam(%cl) == $curVoteOption.kickTeam)
            {
               %totalVotes++;
               if(%cl.vote == "yes")
                  %votesFor++;
            }
         }
         if(%totalVotes >= $Server::MinVotes && %votesFor / %totalVotes >= $Server::VoteWinMargin)
         {
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %totalVotes - %votesFor @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %totalClients - (%votesFor + %votesAgainst) @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function Admin::startVote(%clientId, %topic, %action, %option)													// admin.cs
{
	if(%clientId.lastVoteTime == "")
		%clientId.lastVoteTime = -$Server::MinVoteTime;

	%time = getIntegerTime(true) >> 5;
	%diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

	if(%diff > 0)
	{
		Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
		return;
	}
	if ((%action=="cmission") && ($TribeStat::BlockMIS == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled mission voting.");
	else if (((%action=="dtd") || (%action=="etd")) && ($TribeStat::BlockTD == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled team damage voting.");
	else if ((%action=="admin") && ($TribeStat::BlockADM == 1))
		Client::sendMessage(%clientId,0,"The server administrator has disabled admin voting.");
	else if (((%action=="ffa") || (%action=="tourney")) && ($TribeStat::BlockGT == 1))
      		Client::sendMessage(%clientId,0,"The server administrator has disabled game type voting.");

	else if($curVoteTopic == "")
	{
		if(%clientId.numFailedVotes)
			%time += %clientId.numFailedVotes * $Server::VoteFailTime;

		%clientId.lastVoteTime = %time;
		$curVoteInitiator = %clientId;
		$curVoteTopic = %topic;
		$curVoteAction = %action;
		$curVoteOption = %option;
		
		if(%action == "kick")
		{
			$curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
		}
		$curVoteCount++;
		bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " initiated a vote to " @ $curVoteTopic @ "");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		%cl.vote = "";
		%clientId.vote = "yes";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		if(%cl.menuMode == "options")
			Game::menuRequest(%clientId);
		schedule("Admin::countVotes(" @ $curVoteCount @ ", true);", $Server::VotingTime, 35);
	}
	else
	{
		Client::sendMessage(%clientId, 0, "Voting already in progress.");
	}
}


function remoteSelectClient(%clientId, %selId)
{
	if(%clientId.selClient != %selId)
	{
		%clientId.selClient = %selId;
		if(%clientId.menuMode == "options")
			Game::menuRequest(%clientId);

		%addr = Client::getTransportAddress(%selId);

		remoteEval(%clientId, "setInfoLine", 1, "Game Stats");
		remoteEval(%clientId, "setInfoLine", 2, "Addr-IP   :" @ %addr);
		remoteEval(%clientId, "setInfoLine", 3, "Last TKer :" @ $Shifter::LastTKer @ "    T-Kills   :" @ %clientId.TotalKills);
		remoteEval(%clientId, "setInfoLine", 4, "Last TKed :" @ $Shifter::LastTKed @ "    T-Score   :" @ %clientId.TotalScore);
		remoteEval(%clientId, "setInfoLine", 5, "TK Count  :" @ $Shifter::LastTKno @ "    T-Deaths  :" @ %clientId.TotalDeaths);
		remoteEval(%clientId, "setInfoLine", 6, "T-Caps    :" @ %clientId.TotalFlagCaps);
	}
}

function processMenuFPickTeam(%clientId, %team)
{
	if(%clientId.isAdmin)
		processMenuPickTeam(%clientId.ptc, %team, %clientId);
	%clientId.ptc = "";
}

function processMenuPickTeam(%clientId, %team, %adminClient)
{
	checkPlayerCash(%clientId);
	if(%team != -1 && %team == Client::getTeam(%clientId))
		return;

	if(%clientId.observerMode == "justJoined")
	{
		%clientId.observerMode = "";
		centerprint(%clientId, "");
	}

	if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
	{
		if(Observer::enterObserverMode(%clientId))
		{
			%clientId.notready = "";
			if(%adminClient == "")
			{
				messageAll(0, Client::getName(%clientId) @ " became an observer.");
			}
			else
			{
				messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
				if ($debug) echo ("Observer Force");
				if ($Shifter::SwitchPerm)
				{
					%clientId.SwitchPerm = true;
				}
			}
			Game::resetScores(%clientId);	
			Game::refreshClientScore(%clientId);
		}
		return;
	}

	%player = Client::getOwnedObject(%clientId);

	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	
	%clientId.observerMode = "";

	if(%adminClient == "")
	{
		messageAll(0, Client::getName(%clientId) @ " changed teams.");
	}
	else
	{
		messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");
		if ($Shifter::SwitchPerm)
		{
			%clientId.SwitchPerm = true;
		}
	}
	if(%team == -1)
	{
		Game::assignClientTeam(%clientId);
		%team = Client::getTeam(%clientId);
	}

	GameBase::setTeam(%clientId, %team);
	%clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

	Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);

	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;

}


//======================================================================================================================== 
//							Main Menus
//======================================================================================================================== 

//
//

function Game::menuRequest(%clientId)
{
    if(%clientId.possessed == "true")
    {
	Client::buildMenu(%clientId, "Here are your options:", "options", true);
	Client::addMenuItem(%clientId, "1Leave the server", "kickme");
	Client::addMenuItem(%clientId, "2Sit down and shut up", "canit");
	Client::addMenuItem(%clientId, "..Have a nice day!", "smile");
    }
    else
    {
   	%curItem = 0;
   	Client::buildMenu(%clientId, "Shifter_v1Y " @ $Yuki::newdate @ "", "options", true);

	//=========================================================================================== Basic Menu   	
   	if(!$matchStarted || !$Server::TourneyMode)
   	{
		if(!%clientId.selClient && !$Server::TourneyMode)
		{
	    		if (!%clientId.SwitchPerm)
	    			Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		}
   	}
	if (%clientId.observerMode != "observerOrbit" && %clientId.observerMode != "observerFly")
	{
		if ($Shifter::HelpOn != "false")
			Client::addMenuItem(%clientId, %curItem++ @ "Shifter Help", "helpprint");

		if ($Shifter::Weapons != "false" && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Weapon Options", "weaponoptions");
		
		if ($Shifter::SaveOn != "false" && !%clientId.selClient)
			Client::addMenuItem(%clientId, %curItem++ @ "Save Player Info", "saveinfo");
	}
	else 
	if (%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Observer Functions", "menurequest4");
	}
	
	//=========================================================================================== If Vote Topic
	if($curVoteTopic != "" && %clientId.vote == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
		Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
	}
	
	//=========================================================================================== Admin's Menus
	if(%clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Admin Functions", "menurequest2");
	}

	Client::addMenuItem(%clientId, %curItem++ @ "Voting Functions", "menurequest3");
	Client::addMenuItem(%clientId, %curItem++ @ "Shifter_v1Y FAQ", "faq_menu");
    }
}
//================================================================================================================
//						End of Initial Menu System
//================================================================================================================


//===================================================================================================
//						FAQ Menu Processing
//===================================================================================================
function processFAQOptions(%clientId, %option)
{
	%curItem = 0;
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);

	if(%opt == "faq_menu")
	{
		bottomprint(%clientId,"<jc><f1>The FAQ has a few of the more common questions asked about the mod.  To navigate simply click on the option that most closely relates to your question.",0);
		Client::buildMenu(%clientId,"Shifter_v1Y FAQ Menu","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Overview of the mod", "faq_overview");
		Client::addMenuItem(%clientId,%curItem++ @ "Armor related Q's", "faq_armor");
		Client::addMenuItem(%clientId,%curItem++ @ "Weapon related Q's", "faq_weapon");
		Client::addMenuItem(%clientId,%curItem++ @ "All other Q's", "faq_other");
		Client::addMenuItem(%clientId,%curItem++ @ "How to report a Q", "faq_report");
		Client::addMenuItem(%clientId,%curItem++ @ "Important changes", "faq_changes");
		return;
	}

//============================================ Overview
	if(%opt == "faq_overview")
	{
		bottomprint(%clientId,"<jc><f1>Shifter_v1Y was started as a version of the 7-30-2000 release of Shifter (<f3>the one immediately before advanced boosters were added<f1>) with the notorious glitches -- like no-inventory armor changing -- removed.  (<f2>More<f1>)",0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The motto used when coding this mod was \\\"no weapon, armor or deployable left useless\\\".  For example the 7 \\\"useless\\\" weapons -- Hyperblaster, ELF Gun, Equalizer, Dart Rifle, Magnum, Laser Rifle and Ion Rifle -- all have been modified (<f2>More<f1>)\", 0);", 11);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Some elements were borrowed (<f3>read: stolen<f1>) from mods like Shifter_v1G, others were thought up in responce to new exploits that arose.  Each addition to the mod was made with one of two things in mind: Balance or Fun. (<f2>More<f1>)\", 0);", 22);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>A number of the changes made to the mod are somewhat drastic to say the least, which is why this FAQ is present.  If you are finding that something isn't working as you expected this FAQ should have the reason.  --- Y|yukichigai\", 10);", 33);
		return;
	}

//============================================ Armor FAQ
	if(%opt == "faq_armor")
	{
		bottomprint(%clientId,"<jc><f1>These are questions concerning the abilities and properties of the 9 different armors.",0);
		Client::buildMenu(%clientId,"Armor FAQ Menu","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Quick Overdose in Scout?","faq_OD");
		Client::addMenuItem(%clientId,%curItem++ @ "Juggy-Jump not working?","faq_jugjump");
		Client::addMenuItem(%clientId,%curItem++ @ "No advanced boosters?", "faq_boosters");
		return;
	}
	if(%opt == "faq_OD")
	{
		bottomprint(%clientId,"<jc><f1>At the time you were stimmed were you using a Laser Rifle?",0);
		Client::buildMenu(%clientId,"Were you using Laser Rifle?","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Yes","faq_ODyes");
		Client::addMenuItem(%clientId,%curItem++ @ "No","faq_ODno");
		return;
	}
	if(%opt == "faq_ODyes")
	{
		bottomprint(%clientId,"<jc><f1>In this case the quick overdose was probably because you were attempting to use the stim-laser trick.  While not an exploit in itself, the new power given to the Laser Rifle makes it necessary to limit it.  Try stimming without using Laser Rifle.",0);
		return;
	}
	if(%opt == "faq_ODno")
	{
		bottomprint(%clientId,"<jc><f1>If you think you overdosed at too low a percentage it is likely because the overdose scale has been shifted.  Although the level you will overdose at is lower, so is the rate of increase.  The actual time is the same.",0);
		return;
	}
	if(%opt == "faq_jugjump")
	{
		bottomprint(%clientId,"<jc><f1>Standard Mortars fired by Juggernaught are now higher-damaging (1.32x normal) higher-radius (1.5x normal) but lower-concussion shells.  This was done in part to decrease mobility and the frequency of Heavy Plasma Raids.",0);
		return;
	}
	if(%opt == "faq_boosters")
	{
		bottomprint(%clientId,"<jc><f1>While Advanced Boosters are very fun they make Mercenary far too powerful and eclipse the abilities of the other three medium armors.  There <f3>has<f1> been talk of a separate pack to allow advanced boosting however....",0);
		return;
	}

//============================================ Weapon FAQ
	if(%opt == "faq_weapon")
	{
		bottomprint(%clientId,"These are questions relating to weapons and things that killed or damaged you.",0);
		Client::buildMenu(%clientId,"Weapon FAQ Menu","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Red Laser?","faq_redlas");
		Client::addMenuItem(%clientId,%curItem++ @ "Mysterious EMP damage?", "faq_emp");
		Client::addMenuItem(%clientId,%curItem++ @ "Blue Explosions?", "faq_magnum");
		Client::addMenuItem(%clientId,%curItem++ @ "Can't lock with rocket?", "faq_rocket");
		return;
	}
	if(%opt == "faq_redlas")
	{
		bottomprint(%clientId,"<jc><f1>Red Lasers come from two sources: Laser Turrets and the Juggernaught's Laser Cannon.  The Laser Cannon has been changed such that instead of charging with beacons it uses energy like a normal weapon, but with far more damage.",0);
		return;
	}
	if(%opt == "faq_emp")
	{
		bottomprint(%clientId,"<jc><f1>Did the message \"You were hit with EMP!\" appear on your message screen twice at the same time?",0);
		Client::buildMenu(%clientId,"Two EMPs at the same time?","options");
		Client::addMenuItem(%clientId,%curItem++ @ "Yes","faq_empbeac");
		Client::addMenuItem(%clientId,%curItem++ @ "No","faq_empdart");
		return;
	}
	if(%opt == "faq_empbeac")
	{
		bottomprint(%clientId,"<jc><f1>What damaged you was most likely an EMP Beacon.  EMP Beacons do a small amount of EMP damage to any enemy object near them every 15 seconds.",0);
		return;
	}
	if(%opt == "faq_empdart")
	{
		bottomprint(%clientId,"<jc><f1>If you did not see \"You were hit with EMP!\" flash on your message screen twice you were probably hit with an EMP dart.  EMP darts are fired by the Dart Rifle, which can also fire Poison darts and Flare darts.",0);
		return;
	}
	if(%opt == "faq_magnum")
	{
		bottomprint(%clientId,"<jc><f1>The Magnum fires a bullet which produces a blue/purple explosion when it hits.  While the damage it does is very high the range is fairly short.",0);
		return;
	}
	if(%opt == "faq_rocket")
	{
		bottomprint(%clientId,"<jc><f1>Certain conditions will make it impossible to lock on to a player: <f3>1)<f1> the player is in Chemeleon, <f3>2)<f1> the player is sensor supressed (i.e. StealthShield), <f3>3)<f1> the player is wearing a Sensor Jammer Pack.",0);
		return;
	}

//============================================ Other FAQ
	if(%opt == "faq_other")
	{
		bottomprint(%clientId,"<jc><f1>All other questions about Shifter_v1Y.",0);
		Client::buildMenu(%clientId,"Other FAQ Menu","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Rotating Pickups?","faq_weapcyc");
		return;
	}
	if(%opt == "faq_weapcyc")
	{
		bottomprint(%clientId,"<jc><f1>Rotating weapons behave differently than other weapons when you run across them.  The weapon you receive will be a randomly determined weapon which has the same shape as the rotating item, so a rotating ELF gun could give you a Boomstick instead.",0);
		return;
	}

//============================================ Report a question
	if(%opt == "faq_report")
	{
		bottomprint(%clientId,"<jc><f1>If you would like a question to be covered in this FAQ you can either e-mail me at Yukichigai@netscape.net or post it on the message board at www.tribeshifter.com.  Please include \"FAQ QUESTION\" in the topic.",0);
		return;
	}

//============================================ Important Changes
	if(%opt == "faq_changes")
	{
		bottomprint(%clientId,"<jc><f1>A list of the most important and impacting changes made to Shifter_v1Y when comparing it to other Shifter-based mods.",0);
		Client::buildMenu(%clientId,"Changes in Shifter_v1Y","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Laser Mines", "faq_lasmine");
		Client::addMenuItem(%clientId,%curItem++ @ "FastFavs", "faq_fastfavs");
		Client::addMenuItem(%clientId,%curItem++ @ "Juggernaught", "faq_jug");
		Client::addMenuItem(%clientId,%curItem++ @ "Rotating Weapons", "faq_weapcyc");
		if(!$Shifter::noStimFix)
			Client::addMenuItem(%clientId,%curItem++ @ "Scout+Stim+Shield", "faq_sss");
		Client::addMenuItem(%clientId,%curItem++ @ "Sensor Jammer Pack", "faq_sjp");
		Client::addMenuItem(%clientId,%curItem++ @ "Grav Gun", "faq_grav");
		Client::addMenuItem(%clientId,%curItem++ @ "Weapon Mode Cycling", "faq_weaponcycle");
		return;
	}
	if(%opt == "faq_lasmine")
	{
		bottomprint(%clientId,"<jc><f1>Laser Mines are now limited on an amount active basis.  On this server you are allowed to deploy " @ $Shifter::LaserMineCountLimit @ " Laser Mines at one time, and must wait for one to detonate itself in order to deploy another.",0);
		return;
	}
	if(%opt == "faq_fastfavs")
	{
		bottomprint(%clientId,"<jc><f1>FastFavs is an Inventory System similar to the Tribes 2 Inventory System, controlled in the <f3>Spawn Options<f1> menu under <f3>Weapon Options<f1>.  To use FastFavs simply hit the corresponding \"buy\" key for any favorite and then touch an Invo.",0);
		return;
	}
	if(%opt == "faq_jug")
	{
		bottomprint(%clientId,"<jc><f1>The Juggernaught armor has changed in numerous aspects.  Select a topic for a brief summary of the related changes.",0);
		Client::buildMenu(%clientId,"Juggernaught Changes","options",true);
		Client::addMenuItem(%clientId,%curItem++ @ "Beacons","faq_jug_beac");
		Client::addMenuItem(%clientId,%curItem++ @ "Laser Cannon","faq_jug_las");
		Client::addMenuItem(%clientId,%curItem++ @ "Heavy Plasma","faq_jug_plas");
		Client::addMenuItem(%clientId,%curItem++ @ "Godhammers","faq_jug_GH");
		Client::addMenuItem(%clientId,%curItem++ @ "Tactical Nuke!","faq_jug_nuke");
		Client::addMenuItem(%clientId,%curItem++ @ "Mortar Jumping","faq_jugjump");
		return;
	}
	if(%opt == "faq_jug_beac")
	{
		bottomprint(%clientId,"<jc><f1>Juggernaught beacons now do more than charge the Heavy Plasma Cannon.  They now can be activated to temporarily boost your energy recharge rate or to increase the cooling rate of the Godhammer Cooling System.",0);
		return;
	}
	if(%opt == "faq_jug_las")
	{
		bottomprint(%clientId,"<jc><f1>The Laser Cannon has been modified to function more like the Laser Rifle, converting energy to damage directly.  Although the damage it does is very high the reload time is long, leaving the user unshielded and defensless for a few seconds.",0);
		return;
	}
	if(%opt == "faq_jug_plas")
	{
		bottomprint(%clientId,"<jc><f1>The Heavy Plasma Cannon now has a limiting function to cut down on Heavy Plasma Raids.  On this server you are allowed " @ $Shifter::PlasCanLimit @ " Heavy Plasma uses every " @ $Shifter::PlasCanLimitTime @ " minutes.",0);
		return;
	}
	if(%opt == "faq_jug_GH")
	{
		bottomprint(%clientId,"<jc><f1>The Godhammer Cannons now overheat more slowly, and can be cooled somewhat by activating one of your beacons.  The speed of the missiles has also increased, and they will lock on to certain targets.",0);
		return;
	}
	if(%opt == "faq_jug_nuke")
	{
		bottomprint(%clientId,"<jc><f1>To fire the Tactical Nuke you must now have a beacon for each Nuclear Shell you intend to fire.  Firing the Tactical Nuke without a beacon to power the Containment Pack will cause you damage.",0);
		return;
	}
	if(%opt == "faq_sss")
	{
		bottomprint(%clientId,"<jc><f1>The Scout + Stim + Shieldpack trick, otherwise known as SSS, has been weakened somewhat on this server.  The amount of damage prevented by the Shieldpack is decreased when stimmed.",0);
		return;
	}
	if(%opt == "faq_sjp")
	{
		bottomprint(%clientId,"<jc><f1>Carrying a Deployable Sensor Jammer or wearing a Sensor Jammer Pack will prevent players from locking on to you with rockets.  An active Sensor Jammer Pack will also prevent Rocket Turrets from firing at you.",0);
		return;
	}
	if(%opt == "faq_grav")
	{
		bottomprint(%clientId,"<jc><f1>The Grav Gun now has an Advanced mode where all pushing and pulling is done in all 3 dimensions.  This means you can push or pull people up or down, and the Grapple beam allows you to execute some Metroid-style stunts.",0);
		return;
	}
	if(%opt == "faq_weaponcycle")
	{
		bottomprint(%clientId,"<jc><f1>There is now a clientside key binding which will cycle through all modes of fire for the weapon you are using.  Add something like this to your autoexec.cs: <f3>bindCommand(mouse0, make, \"button2\", TO, \"remoteEval(2048,cycleweapons);\");",0);
		return;
	}
}

//=================================================================================================== 
//						Main Menu Process
//=================================================================================================== 
function processMenuOptions(%clientId, %option)
{
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%playerId = %cl;
	%armor = Player::getArmor(%clientId);
	%weapon = Player::getMountedItem (%clientId, $WeaponSlot);
	%pack = Player::getMountedItem (%clientId, $BackPackSlot);
	%flag = Player::getMountedItem (%clientId, $FlagSlot);

	if(%opt == "menurequest4")
	{   
		if ($Debug) echo("*** Process Observer Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Observer Options Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Observer Options", "options", true);

		//================================================================================== Client Selected 
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Observe Player " @ %name, "observep " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Warn Player " @ %name, "warnp " @ %sel);
		}

		Client::addMenuItem(%clientId, %curItem++ @ "Observe Very Close ", "obssetvclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Close ", "obssetclose");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Far ", "obssetfar");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe 1st Person ", "obssetfirst");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Close ", "obssetcfollow");
		Client::addMenuItem(%clientId, %curItem++ @ "Observe Follow Far ", "obssetffollow");
		Client::addMenuItem(%clientId, %curItem++ @ "Observer Direct Chat", "obssetdirchat");
		
		if (%clientId.isAdmin && %clientId.isSuperAdmin)
		{
			if (%clientId.spymode == "0" || !%clientId.spymode)
				Client::addMenuItem(%clientId, %curItem++ @ "Set Warning Mode ", "obssetspy");
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Set Silent Mode ", "obssetspy");
		}

		return;
	}
	else if(%opt == "warnp")  //================================================================================= Send Observe Warning
	{
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if (%clientId.isadmin && %clientId.isSuperAdmin)
				bottomprint(%sel, "<jc>You Being Observed By : " @ Client::getName(%clientId) @ " who is admin...", 5);
			else
				bottomprint(%sel, "<jc>You Being Observed By : " @ Client::getName(%clientId), 5);
			
		}
		return;
	}
	else if(%opt == "observep") //================================================================================= Obs, Selected
	{
		%sel = %clientId.selClient;
		%name = Client::getName(%sel);
		Observer::setTargetClient(%clientId, %sel);
	}
	
	//========================================================================================================== Set Observer Options
	if(%opt == "obssetcfollow") {		%clientId.obsmode = 4; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetffollow") {	%clientId.obsmode = 5; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetaction") {	%clientId.obsmode = 6; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer,Follow mode set as default.",3); return; }
	else if(%opt == "obssetvclose") { 	%clientId.obsmode = 3; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Very close mode set as default.",3); return; }
	else if(%opt == "obssetclose") { 	%clientId.obsmode = 0; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Close mode set as default.",3); return; }
	else if(%opt == "obssetfar") { 		%clientId.obsmode = 1; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, Far View set as default.",3); return; }
	else if(%opt == "obssetfirst") { 	%clientId.obsmode = 2; if (%clientId.observerTarget) { Observer::setTargetClient(%clientId, %clientId.observerTarget); } bottomprint(%clientId, "Observer, First person view set as default.",3); return; }
	else if(%opt == "obssetspy") { if (	%clientId.spymode == "0" || !%clientId.spymode) { %clientId.spymode = "1"; bottomprint(%clientId, "Observer Spy mode is set, observed player will recieve no warning.",3); } else { %clientId.spymode = "0"; bottomprint(%clientId, "Observer Warn mode is set, player will recieve notice that you are observing",3); } return; }
	else if(%opt == "obssetdirchat") { if(%clientId.obsdirect == "") { %clientId.obsdirect = true; bottomprint(%clientId,"<jc><f1>Observer Direct Chat enabled.  Use Teamchat to send messages directly to the person you are observing.  Changing observed players will disable this.",10); return; } else { %clientId.obsdirect = ""; bottomprint(%clientId,"<jc><f1>Observer Direct Chat disabled.  Teamchat will function normally.",10); return;}}
	
	//================================================================================================================ Voting Options
	if(%opt == "menurequest3")
	{   
		if ($Debug) echo("*** Process Voting Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Voting Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Voting Options", "options", true);

		//================================================================================== Client Selected 
		if(%clientId.selClient)
		{
			%sel = %clientId.selClient;
			%name = Client::getName(%sel);

			if($curVoteTopic == "" && !%sel.isSuperAdmin && !%sel.justConnected)
			{
				if ($Shifter::VoteAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
				if ($Shifter::VoteKick)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
			}

			if(%clientId.muted[%sel])
				Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
			else
				Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
//			if(%clientId.soundmute[%sel])
//				Client::addMenuItem(%clientId, %curItem++ @ "Un-sound-mute " @ %name, "smute " @ %sel);
//			else
//				Client::addMenuItem(%clientId, %curItem++ @ "Sound-mute " @ %name, "smute " @ %sel);
//			if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "ObserverFly")
//				Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observep " @ %sel);
		}

		//================================================================================== No Client Selected 
		if (!%clientId.selClient && $curVoteTopic == "")
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");

			if($Shifter::VoteDTD)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
			}         

			if($Shifter::VoteFFA)
			{
				if($Server::TourneyMode)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
			}	
		}
		return;
	}
	//================================================================================================
	//  Secondary Menu System - Mostly Super Admin Functions
	//================================================================================================

	else if(%opt == "menurequest2")
	{   
		if ($Debug) echo("*** Process Admin Options ***");
		echo("ADMINMSG: **** " @ Client::getName(%clientId) @ " Is Accessing Admin Menu");
		%curItem = 0;
		
		Client::buildMenu(%clientId, "Admin Options", "options", true);

		//================================================================================== Client Is Only Admin
		if(%clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);

				Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);				

				if (%sel.ismuted)
					Client::addMenuItem(%clientId, %curItem++ @ "Global UnMute " @ %name @ ".", "muteplayer " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Global Mute " @ %name @ ".", "muteplayer " @ %sel);
					
				if (%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "UnLock " @ %name @ "'s Team", "tcrights " @ %sel);
				if (!%sel.SwitchPerm)
					Client::addMenuItem(%clientId, %curItem++ @ "Lock " @ %name @ "'s Team", "tcrights " @ %sel);			
			}
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");			
				if($Server::TourneyMode)																	//============ Toggle Tourney Mode
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
					if(!$CountdownStarted && !$matchStarted)
						Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable Tournament mode", "ctourney");
			}
		}
		
		//============================================================================== Client Is Admin & Super
		if(%clientId.isSuperAdmin && %clientId.isAdmin)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);
				
				Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);		
				Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "kill " @ %sel);
				
				if (%sel.isAdmin)
					Client::addMenuItem(%clientId, %curItem++ @ "DeAdmin " @ %name, "deadmin " @ %sel);
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);

				if (%armor != parmor) 
					Client::addMenuItem(%clientId, %curItem++ @ "Give " @ %name @ " the Penis Curse", "peniscurse " @ %sel); //== Penis Curse
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ "'s Penis Curse", "peniscurse " @ %sel); //== Penis Curse

				Client::addMenuItem(%clientId, %curItem++ @ "Boot " @ %name, "boot " @ %sel);
				Client::addMenuItem(%clientId, "0Possess " @ %name, "blink " @ %sel);
			}	
			//=============================================================================== With No Client			
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
				Client::addMenuItem(%clientId, %curItem++ @ "Cycle To Next Mission", "cyclemissions");
			}
		}
		if(!%clientId.selClient)
		{
			if(%clientId.isAdmin)
			{
				if($Server::TeamDamageScale == 1.0)
					Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); 
				else
					Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");		
			}
			if(%clientId.isSuperAdmin)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Enable Match Configuration", "matchConfig");
				Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");		
			}
		}
		//================================================================= Client Is Admin But NOT Super Admin
		if(%clientId.isAdmin && %clientId.isSuperAdmin && %clientId.isGod)
		{
			if(%clientId.selClient)
			{
				%sel = %clientId.selClient;
				%name = Client::getName(%sel);
				%armor = Player::getArmor(%sel);
			}
			else
			{
			}
		}
		return;
	}

	else if (%opt == "cyclemissions")
	{
		if(%clientId.isAdmin)
			remoteCycleMission(%clientId);
	}

   	//====================================================================================================================
   	// Print Help Screens.
   	//====================================================================================================================

	else if (%opt == "helpprint") 
	{ 	
   		%curItem = 0;
      
   		Client::buildText(%clientId, "Help Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Help", "weapon");
   		Client::addMenuItem(%clientId, %curItem++ @ "Pack Help", "pack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grenade Help", "grenade");
   		Client::addMenuItem(%clientId, %curItem++ @ "Mine Help", "mine");
   		Client::addMenuItem(%clientId, %curItem++ @ "Beacon Help", "beacon");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Help", "flag");
   		Client::addMenuItem(%clientId, %curItem++ @ "Locate/Flagfinder", "locate");
   		return;
   	} 	

	else if (%opt == "locate")
	{
		Client::buildMenu(%clientId, "Flag Finder", "options", true);
		for(%i=0; %i < getNumTeams(); %i++)
		{
			if(%i != Gamebase::getTeam(%clientId))
			Client::addMenuItem(%clientId, %curItem++ @ "" @ getTeamName(%i) @ " Flag Location", "flagfind" @ %i);
		}
//		Client::addMenuItem(%clientId, %curItem++ @ "Enemy Flag Location", "nmeflag");
   		Client::addMenuItem(%clientId, %curItem++ @ "Friendly Flag Location", "frdflag");
		return;
	}
	else if	(String::findSubStr(%opt,"flagfind") != -1)//(%opt == "flagfind")
	{
		%x = String::getSubStr(%opt,8,1);
		%playerpos = GameBase::getPosition(%clientId);
		%pos = GameBase::getPosition($teamFlag[%x]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The " @ getTeamName(%x) @ " flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}

//	else if (%opt == "nmeflag")
//	{
//		%playerteam = GameBase::getTeam(%clientId);
//		%playerpos = GameBase::getPosition(%clientId);
//
//		if (%playerteam == 0)
//		{
//			%pos = GameBase::getPosition($teamFlag[1]);
//			%posX = getWord(%pos,0);
//			%posY = getWord(%pos,1);
//			%distance = Vector::getDistance(%pos, %playerpos);
//		}
//		else if (%playerteam == 1)
//		{
//			%pos = GameBase::getPosition($teamFlag[0]);
//			%posX = getWord(%pos,0);
//			%posY = getWord(%pos,1);
//			%distance = Vector::getDistance(%pos, %playerpos);
//		}
//		else if (%playerteam > 1)
//		{
//			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Locate does not work in multi team.\", 3);", 0);
//			return;
//		}
//		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
//		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The enemy flag is " @ %distance @ " meters away.\", 3);", 0);
//		return;
//	}

	else if (%opt == "kickme")
	{
		messageall(0,Client::getName(%clientId) @ " didn't want to play anymore.");
		Net::Kick(%clientId,"Have it your way");
		return;
	}
	
	else if (%opt == "tcrights")
	{
		if(%clientId.isAdmin)
		{
			if (%cl.SwitchPerm)
			{
				%cl.SwitchPerm = "False";
				schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You now have rights to switch teams.\", 3);", 0);			
			}
			else if (!%cl.SwitchPerm)
			{
				%cl.SwitchPerm = "True";
				schedule("bottomprint(" @ %cl @ ", \"<jc><f1>Your rights to switch teams has been revoked.\", 3);", 0);
			}
		}
	}
	else if (%opt == "muteplayer")
	{
		if(%clientId.isAdmin)
		{
			if (%cl.ismuted)
			{
				%cl.ismuted = "False";
				schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been allow to speak again, watch you mouth...\", 3);", 0);			
			}
			else if (!%cl.ismuted)
			{
				%cl.ismuted = "True";
				schedule("bottomprint(" @ %cl @ ", \"<jc><f1>You have been globally muted by admin, NO ONE CAN HEAR YOU ANY MORE...\", 3);", 0);
			}
		}
	}	
	else if (%opt == "frdflag")
	{
		%playerteam = GameBase::getTeam(%clientId);
		%playerpos = GameBase::getPosition(%clientId);
		%pos = GameBase::getPosition($teamFlag[%playerteam]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Way point set to your flag. Your flag is " @ %distance @ "meters away.", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your flag is " @ %distance @ " meters away.\", 3);", 0);
		return;
	}
//===================================================================================================================
//============================================== Weapon Options =====================================================
//===================================================================================================================
   	else if (%opt == "weaponoptions") 
   	{ 	
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Weapon Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Plasma Options", "weapon_plasma");

		if((%armor != "earmor" && %armor != "efemale") || !%client.holo) //Make sure engineers don't have more than 8 options at a time
	   		Client::addMenuItem(%clientId, %curItem++ @ "Mortar Options", "weapon_mortar");

   		Client::addMenuItem(%clientId, %curItem++ @ "Rocket Options", "weapon_rocket");

   		if($Shifter::DiscOpts != "false") 
			Client::addMenuItem(%clientId, %curItem++ @ "Disc Options", "weapon_disc");

		if(Player::getItemCount(%clientId,TranqGun) > 0)
	   		Client::addMenuItem(%clientId, %curItem++ @ "Dart Rifle Options", "weapon_dart");

		if(Player::getItemCount(%clientId,GravGun) > 0)
	   		Client::addMenuItem(%clientId, %curItem++ @ "GravGun Options", "weapon_gravgun");


		if (%armor == "earmor" || %armor == "efemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Engineer Options", "engineer_options");
		if (%armor == "spyarmor" || %armor == "spyfemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Plastique Options", "weapon_plastic");
		
		if (Player::getItemCount(%clientId,Laptop) > 0) //(%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale")
	   		Client::addMenuItem(%clientId, %curItem++ @ "Command LapTop Options", "weapon_laptop");
		
		if ((%armor == "aarmor" || %armor == "afemale") && (Player::getMountedItem(%clientId,$BackpackSlot) == LightningPack))
		{
			if(($Shifter::TelePackOpts == false || $MatchConfig == "true") && %clientId.telepoint)
		   		Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
			else if($Shifter::TelePackOpts != "false" && $MatchConfig != true)
				Client::addMenuItem(%clientId, %curItem++ @ "Teleport Pack Options", "telepack");
		}

		if(%clientId.holo)
			Client::addMenuItem(%clientId, %curItem++ @ "Kill Hologram", "killholo");
   		
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn/Game Options", "spawn_options");

   		Client::addMenuItem(%clientId, %curItem++ @ "Weapon Order", "weapon_order");
   		
//   		if ($Shifter::WeaponAdmin)
//		{
//			if(%clientId.isSuperAdmin)
//			{
//				Client::addMenuItem(%clientId, %curItem++ @ "Admin Weapons", "admin_weapons");
//			}
//		}
      		return;
   	}
	else if(%opt == "saveinfo")
	{
		if($Shifter::SaveOn != "false")
			SaveCharacter(%clientId);
		return;
	}
//	else if(%opt == "admin_weapons")
//	{
//		if(%clientId.isSuperAdmin)
//		{
//			Client::buildMenu(%clientId, "Admin Weapons", "options", true);
//
//			if ($Shifter::LockOn != "false")
//				Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Missle Lock", "ad_missle_off");
//			if ($Shifter::LockOn == "false")
//				Client::addMenuItem(%clientId, %curItem++ @ "Turn On Missle Lock", "ad_missle_on");
//
//			if ($Shifter::TurretKill)
//				Client::addMenuItem(%clientId, %curItem++ @ "Turn Off Turret Kills", "ad_turret_off");
//			if (!$Shifter::TurretKill)
//				Client::addMenuItem(%clientId, %curItem++ @ "Turn On Turret Kills", "ad_turret_on");
//			return;
//		}
//		if(%clientId.isSuperAdmin)
//			Admin::WeaponOptions(%clientId);
//		return;
//	}
//	else if (%opt == "ad_missle_on")
//	{
//		$Shifter::LockOn = True;
//		return;
//	}
//	else if (%opt == "ad_missle_off")
//	{
//		$Shifter::LockOn = False;
//		return;
//	}
//	else if (%opt == "ad_turret_on")
//	{	
//		$Shifter::TurretKill = True;
//		return;
//	}
//	else if (%opt == "ad_turret_off")
//	{
//		$Shifter::TurretKill = False;
//		return;
//	}
	else if (%opt == "telepack")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Teleport Pack Options", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Normal (Telebeacon)", "telepack1");
		Client::addMenuItem(%clientId, %curItem++ @ "Slipstream (Waypoint)", "telepack2");
		Client::addMenuItem(%clientId, %curItem++ @ "Hyperdrive (Line of Sight)", "telepack3");
		if(%clientId.telepoint)
			Client::addMenuItem(%clientId, %curItem++ @ "Clear Telepoint", "cleartelepoint");
		return;
	}
	else if (%opt == "weapon_order")
	{
		%curItem = 0;
		Client::buildMenu(%clientId, "Weapon Order", "options", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Old-school", "old_school");
		Client::addMenuItem(%clientId, %curItem++ @ "Grey Style (HUD-follow)", "grey_style");
		return;
	}
	else if (%opt == "old_school")
	{
		%clientId.weaponorder = 0;
		bottomprint(%clientId,"<jc><f1>Weapon switching set to Old-school order.",10);
		return;
	}
	else if (%opt == "grey_style")
	{
		%clientId.weaponorder = 1;
		bottomprint(%clientId,"<jc><f1>Weapon switching set to HUD-follow order.",10);
		return;
	}
	else if (%opt == "telepack1")
	{
		%clientId.tele = 0;
		bottomprint(%clientId,"<jc><f1>Teleport pack set to Telebeacon operation.  Sets a beacon which you teleport to until destroyed.\n350m range, requires no energy to use.",10);
		return;
	}
	else if (%opt == "telepack2")
	{
		%clientId.tele = 1;
		bottomprint(%clientId,"<jc><f1>Teleport pack set to Slipstream operation.  Set a waypoint in your command screen to use.",10);
		return;
	}
	else if (%opt == "telepack3")
	{
		%clientId.tele = 2;
		bottomprint(%clientId,"<jc><f1>Teleport pack set to Hyperdrive operation.  Teleports to any line of sight position within 125m.",10);
		return;
	}
	else if (%opt == "cleartelepoint")
	{
		%player = client::getownedobject(%clientId);
		
		%obj = newObject("","Mine","EMPBlast");
		GameBase::throw(%obj,%player,0,false);
		
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 1.5";
		%pos = Vector::add(GameBase::getPosition(%clientId.telepoint), %padd);
		GameBase::setPosition(%obj, %pos);
		
		%clientId.telepoint = "false";
	
		return;
	}
	else if (%opt == "killholo")
	{
		remotekill(%clientId.holo);
		%clientId.holo = "";
	}
	else if (%opt == "weapon_laptop")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Laptop Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Turret Control", "laptop_control");
   		Client::addMenuItem(%clientId, %curItem++ @ "Turret Hack", "laptop_hack");
   		return;	
	}
	else if (%opt == "laptop_control")
	{
		%ClientId.HackPack = True;
	        bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Command Mode", 2);
		return;
	}
	else if (%opt == "laptop_hack")
	{
	        bottomprint(%clientId, "<jc><f2>Comand LapTop Set To Hack Mode", 2);
		%ClientId.HackPack = False;
		return;
	}	

	else if (%opt == "spawn_options")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Spawn Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Standard", "spawn_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Spawn Random", "spawn_random");
   		if ($Shifter::SpawnFavs != "false") Client::addMenuItem(%clientId, %curItem++ @ "Spawn Favorites", "spawn_favs");
		if(%clientId.fastfavs == "true")
			Client::addMenuItem(%clientId, %curItem++ @ "Disable Fast-Favs", "fast_favs");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Enable Fast-Favs", "fast_favs");
   		return;
	}
	else if (%opt == "spawn_standard")
	{
		%clientId.spawntype = "standard";
		return;
	}
	else if (%opt == "spawn_random")
	{
		%clientId.spawntype = "random";
		return;
	}
	else if (%opt == "spawn_favs")
	{
		if($Shifter::SpawnFavs != "false")
			%clientId.spawntype = "favs";
		return;
	}
	else if (%opt == "fast_favs")
	{
		if(%clientId.fastfavs == "true")
		{
			%clientId.fastfavs = false;
			bottomprint(%clientId,"<jc><f1>Fast-Favs disabled.",5);
		}
		else
		{
			%clientId.fastfavs = true;
			bottomprint(%clientId,"<jc><f1>Fast-Favs enabled.  To use Fast-Favs simply hit your \"Buy Favorites\" key and touch an Inventory Station.  Your favorites will be bought instantly, without having to enter the Inventory Screen.  You can still enter Inventory Stations normally.",10);
		}
		return;
	}
	else if (%opt == "weapon_mortar")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Shell", "weapon_mortar_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Shell", "weapon_mortar_emp");
   		Client::addMenuItem(%clientId, %curItem++ @ "Frag Shell", "weapon_mortar_frag");
   		Client::addMenuItem(%clientId, %curItem++ @ "MDM Shell", "weapon_mortar_mdm");
   		return;
	}
	else if (%opt == "weapon_rocket")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mortar Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Stinger", "weapon_rocket1");
   		if ($Shifter::LockOn != "false" || $MatchConfig == true)
   			Client::addMenuItem(%clientId, %curItem++ @ "Locking Stinger", "weapon_rocket2");
		if($Shifter::HeatSeeker == "false" && $MatchConfig != true)
	   		Client::addMenuItem(%clientId, %curItem++ @ "LockJaw", "weapon_rocket3");
		else
			Client::addMenuItem(%clientId, %curItem++ @ "Heat Seeker", "weapon_rocket3");
   		Client::addMenuItem(%clientId, %curItem++ @ "Wire Guided", "weapon_rocket4");
   		return;
	}
	else if (%opt == "weapon_plasma")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plasma Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_plasma_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_plasma_rapid");
   		Client::addMenuItem(%clientId, %curItem++ @ "Multi Fire", "weapon_plasma_multi");
   		return;
	}
	else if (%opt == "weapon_disc")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Disc Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Fire", "weapon_disc_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "Rapid Fire", "weapon_disc_rapid");
   		return;
	}
	else if (%opt == "weapon_dart")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Dart Rifle Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Poison Dart", "weapon_dart_regular");
   		Client::addMenuItem(%clientId, %curItem++ @ "EMP Dart", "weapon_dart_EMP");
   		Client::addMenuItem(%clientId, %curItem++ @ "Flare Dart", "weapon_dart_flare");
   		return;
	}
	else if (%opt == "weapon_gravgun")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "GravGun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Tractor Effect", "weapon_gravgun_trac");
   		Client::addMenuItem(%clientId, %curItem++ @ "Repulse Effect", "weapon_gravgun_repu");
   		Client::addMenuItem(%clientId, %curItem++ @ "Grapple Effect", "weapon_gravgun_grap");
   		Client::addMenuItem(%clientId, %curItem++ @ "Toggle Advanced Mode", "weapon_gravgun_adva");
   		return;
	}
	else if (%opt == "weapon_plastic")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Plastique Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "1 Sec. Delay", "weapon_plastic_plas1");
   		Client::addMenuItem(%clientId, %curItem++ @ "2 Sec. Delay", "weapon_plastic_plas2");
   		Client::addMenuItem(%clientId, %curItem++ @ "5 Sec. Delay", "weapon_plastic_plas5");
   		Client::addMenuItem(%clientId, %curItem++ @ "10 Sec. Delay", "weapon_plastic_plas10");
   		Client::addMenuItem(%clientId, %curItem++ @ "15 Sec. Delay", "weapon_plastic_plas15");
   		return;
	}
	//=============================================================================================== Engineer Opts
	else if (%opt == "engineer_options")
	{
   		%curItem = 0;
   		
   		Client::buildMenu(%clientId, "Engineer Options", "options", true);
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Mines", "weapon_engmine");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Gun", "weapon_eng");
	   	Client::addMenuItem(%clientId, %curItem++ @ "Engineer Beacons", "weapon_engbeacon");
	   	
		return;
	}	
	else if (%opt == "weapon_engmine")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Proximity Warning", "weapon_engmine_proxy");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cloaking Mine", "weapon_engmine_cloak");
   		Client::addMenuItem(%clientId, %curItem++ @ "Laser Mine", "weapon_engmine_laser");
   		Client::addMenuItem(%clientId, %curItem++ @ "Anti-Personel", "weapon_engmine_stand");
   		Client::addMenuItem(%clientId, %curItem++ @ "Replicator", "weapon_engmine_replica");
   		return;
	}
	else if (%opt == "weapon_engbeacon")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Mine Type", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Standard Beacon", "weapon_engbeacon_standard");
   		Client::addMenuItem(%clientId, %curItem++ @ "Cloaked Camera", "weapon_engbeacon_camera");
		Client::addMenuItem(%clientId, %curItem++ @ "Missile Jammer", "weapon_engbeacon_antimissile");
   		Client::addMenuItem(%clientId, %curItem++ @ "Medi-Pack Patch", "weapon_engbeacon_medikit");
   		return;
	}
	else if (%opt == "weapon_eng")
	{
   		%curItem = 0;
   		Client::buildMenu(%clientId, "Engineer Gun Options", "options", true);
   		Client::addMenuItem(%clientId, %curItem++ @ "Repair", "weapon_eng_repair");
   		Client::addMenuItem(%clientId, %curItem++ @ "Hack", "weapon_eng_hack");
   		Client::addMenuItem(%clientId, %curItem++ @ "Disassymbler", "weapon_eng_disa");
   		return;
	}	
	//=============================================================================================== Engineer Mines
	else if (%opt == "weapon_engmine_proxy")
	{
		%clientId.EngMine = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Proximity Detector.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_cloak")
	{
		%clientId.EngMine = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Cloaking Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_laser")
	{
		%clientId.EngMine = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Point Defense Laser Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_stand")
	{
		%clientId.EngMine = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Standard Anti-Personell Mine.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engmine_replica")
	{
		%clientId.EngMine = "4";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mine Set To Replicator Mine.\", 3);", 0);
   		return;
	}
	//==================================================================================== Engineer Beacons
	else if (%opt == "weapon_engbeacon_standard")
	{
		%clientId.EngBeacon = "0";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacon Set To Standard.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_camera")
	{
		%clientId.EngBeacon = "1";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Cloaking Camera.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_antimissile")
	{
		%clientId.EngBeacon = "2";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Anti-Missile Screen, only protects from Guided Missiles.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_engbeacon_medikit")
	{
		%clientId.EngBeacon = "3";
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Beacons Set To Medi Kit Patch. Help You And Your Team Mates On The Field.\", 3);", 0);
 		return;
	}		

	//====================================================================================== Eng-Gun Options
	else if (%opt == "weapon_eng_repair")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 0;		
			Player::setItemCount(%clientId, Fixit , 1);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::mountItem(%clientId, Fixit, $WeaponSlot);		
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Repair Gun Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, FixIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Repair Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}

   		return;
	}
	else if (%opt == "weapon_eng_hack")
	{
		if (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, DisIt, 0);
			Player::setItemCount(%clientId, Hackit, 1);
			Player::mountItem(%clientId, HackIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hacking Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, HackIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Hacking Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}
		
   		return;
	}
	else if (%opt == "weapon_eng_disa")
	{
		if (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, FixIt))
		{
			%clientId.Eng = 1;
			Player::setItemCount(%clientId, Fixit, 0);
			Player::setItemCount(%clientId, Hackit, 0);
			Player::setItemCount(%clientId, DisIt, 1);
			Player::mountItem(%clientId, DisIt, $WeaponSlot);
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Disassymbler Option Selected.\", 3);", 0);
		}
		else
		{		
			if (Player::getItemCount(%clientId, DisIt))
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Engineer Gun Is Already Set To Disassymbler Mode.\", 3);", 0);
			else			
				schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You do not possess a Engineer Gun.\", 3);", 0);
		}
		
   		return;
	}

	//=============================================================================================== Plastique
	if(String::findSubStr(%opt,"weapon_plastic_plas") != -1)
	{
		%x = String::getSubStr(%opt,19,3);
		%clientId.Plastic = %x;
		bottomprint(%clientId,"<jc><f1>Plastique Delay Set To " @ %x @ " Seconds.",3);
		return;
	}

	//======================================================================== Mortar Options
	if (%opt == "weapon_mortar_regular")
	{
		%clientId.Mortar = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Mortar Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_emp")
	{
		%clientId.Mortar = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Magnetic Pulse Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_frag")
	{
		%clientId.Mortar = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Fragmenting Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_mortar_mdm")
	{
		%clientId.Mortar = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MDM Shell Selected.\", 3);", 0);
   		return;
	}
	//======================================================================== Rocket Options
	if (%opt == "weapon_rocket1")
	{
		%clientId.rocket = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Rocket Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket2")
	{
		%clientId.rocket = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Stinger Locking Initiated.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_rocket3")
	{
		%clientId.rocket = 2;
		if($Shifter::HeatSeeker == "false" && $MatchConfig != "true")
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Lock Jaw Initiated.\", 3);", 0);
		else
		{
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Heat Seeker Initiated.  Target Lock Lost.\", 3);", 0);
			%clientId.target = -1;
		}
   		return;
	}
	else if (%opt == "weapon_rocket4")
	{
		%clientId.rocket = 3;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Wire Guided System Initiated.\", 3);", 0);
   		return;
	}
	//========================================================================= Plasma Options
	if (%opt == "weapon_plasma_regular")
	{
		%clientId.Plasma = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Plasma Bolt Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_rapid")
	{
		%clientId.Plasma = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid-Bold Plasma Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_plasma_multi")
	{
		%clientId.Plasma = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Multi-Bold Plasma Selected.\", 3);", 0);
   		return;
	}

	//======================================================================= Disc Options
	if (%opt == "weapon_disc_regular")
	{
		%clientId.Disc = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Standard Disc Shell Selected.\", 3);", 0);
   		return;
	}
	else if (%opt == "weapon_disc_rapid")
	{
		%clientId.Disc = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Rapid Disc Shell Selected.\", 3);", 0);
   		return;
	}

	//======================================================================= Dart Rifle Options
	if (%opt == "weapon_dart_regular")
	{
		%clientId.Tranq = 0;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Poison Dart Selected.\", 3);", 0);
		if(Player::getMountedItem(%clientId,$WeaponSlot) == TranqGun)
		{
			Player::unMountItem(%clientId,7);
			Player::MountItem(%clientId,TranqGun0,7);
		}
   		return;
	}
	else if (%opt == "weapon_dart_EMP")
	{
		%clientId.Tranq = 1;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>EMP Dart Selected.\", 3);", 0);
		if(Player::getMountedItem(%clientId,$WeaponSlot) == TranqGun)
		{
			Player::unMountItem(%clientId,7);
			Player::MountItem(%clientId,TranqGun1,7);
		}
   		return;
	}
	else if (%opt == "weapon_dart_flare")
	{
		%clientId.Tranq = 2;
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Flare Dart Selected.\", 3);", 0);
		if(Player::getMountedItem(%clientId,$WeaponSlot) == TranqGun)
		{
			Player::unMountItem(%clientId,7);
			Player::MountItem(%clientId,TranqGun2,7);
		}
   		return;
	}

	//======================================================================= Grav Gun Options
	else if	(String::findSubStr(%opt,"weapon_gravgun_") != -1)
	{
		%x = String::getSubStr(%opt,15,4);
		if(%x == "trac")
		{
			%clientId.gravbolt = 0;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
		}
		else if(%x == "repu")
		{
			%clientId.gravbolt = 1;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
		}
		else if(%x == "grap")
		{
			%clientId.gravbolt = 2;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
		}
		else if(%clientId.gravADV == "0")
		{
			%clientId.gravADV = 1;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun 3d Setting Selected.\", 3);", 0);
		}
		else
		{
			%clientId.gravADV = 0;
			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun 2d Setting Selected.\", 3);", 0);
		}
		return;
	}

//	else if (%opt == "weapon_gravgun_tract")
//	{
//		%clientId.gravbolt = 0;
//		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Tractor Setting Selected.\", 3);", 0);
//		return;
//	}
//	else if (%opt == "weapon_gravgun_repulse")
//	{
//		%clientId.gravbolt = 1;
//		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Grav Gun Repulse Setting Selected.\", 3);", 0);
  // 		return;
//	}
//=============================================================================== Print Help Menu Selections
   	
   	if (%opt == "weapon") //================================================================================== Weapons Help
   	{
   		if ($Shifter::Debug) echo ("Weapon - " @ %weapon);

		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not currently have a weapon mounted.\", 10);", 0);		
		}
		if (%weapon == "Blaster")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Blaster is a modified version of the original with a little more kick.\", 10);", 0);
		}
		if (%weapon == "PlasmaGun")
		{
			if(%clientId.Plasma == 0 || !%clientId.Plasma)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Plasma Gun is currently set to <f3>Standard Fire<f1>.  Plasma fired in this mode has a large blast radius and damage.\", 10);", 0);
			else if(%clientId.Plasma == 1)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Plasma Gun is currently set to <f3>Rapid Fire<f1>.  This mode of fire does less damage but travels faster than <f3>Standard Fire<f1>.\", 10);", 0);
			else if(%clientId.Plasma == 2)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Plasma Gun is currently set to <f3>Multi-Fire<f1>.  Your Plasma Gun will fire several weaker Plasma bolts in a spread pattern.\", 10);", 0);
		}
		if (%weapon == "ChainGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Equalizer is simply a basic Chaingun loaded with explosive-tipped rounds.  The bullet speed of these rounds is somewhat slow, making this weapon difficult to use effectively.\", 10);", 0);
		}
		if (%weapon == "Disclauncher")
		{
			if($Shifter::DiscOpts != "false")
			{
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Disc Launcher has two firing modes: the Standard Disc and a higher-speed but lower-damage Disc.\", 10);", 0);
			}
			else
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Disc Launcher has undergone a minor upgrade in Disc speed and damage.\", 10);", 0);
		}
		if (%weapon == "GrenadeLauncher")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Grenade-launcher is the same stock weapon as always.\", 10);", 0);
		}
		if (%weapon == "Mortar")
		{
			if(%clientId.Mortar == 0 || !%clientId.Mortar)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Mortar is currenly set to <f3>Standard Mortar<f1>.  It will fire the classic green Fusion Mortar shell.\", 10);", 0);
			else if(%clientId.Mortar == 1)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Mortar is currenly set to <f3>EMP Mortar<f1>.  This option does EMP damage in a wide area, sapping the energy of all players hit with it.\", 10);", 0);
			else if(%clientId.Mortar == 2)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Mortar is currenly set to <f3>Fragmentation Mortar<f1>.  This fires a bouncy shell which deploys 15 smaller grenades.\", 10);", 0);
			else if(%clientId.Mortar == 3)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Mortar is currenly set to <f3>Manually Detonated Mortar<f1>.  This mortar will bounce around for up to 30 seconds until you press fire again, detonating the mortar.\", 10);", 0);
		}
		if (%weapon == "LaserRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Laser Rifle has been equipped with an improved focusing lense for higher damage.  The ultimate in efficient sniping.\", 10);", 0);
		}
		if (%weapon == "RocketLauncher")
		{
			if(%clientId.Rocket == 0 || !%clientId.Rocket)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Rocket Launcher is set to <f3>Standard Stinger<f1>.  This rocket does high damage but also has a good bit of muzzle recoil.\", 10);", 0);
			else if(%clientId.Rocket == 1)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Rocket Launcher is set to <f3>Locking Stinger<f1>.  This is a lower-damaging rocket which will lock on to an enemy if you get them in your crosshairs.\", 10);", 0);
			else if(%clientId.Rocket == 2)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Rocket Launcher is set to <f3>Lockjaw<f1>.  This will lock on to an enemy, and each rocket fired for the next 15 seconds will track them.\", 10);", 0);
			else if(%clientId.Rocket == 3)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Rocket Launcher is set to <f3>Wire-Guided<f1>.  The rocket fired will proceed in the direction you are facing.  Very high damage.\", 10);", 0);
		}
		if (%weapon == "SniperRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Sniper Rifle is another sniper weapon, used only by the Assassin armor.  Not nearly as visible or trackable as the Laser Rifle.\", 10);", 0);
		}
		if (%weapon == "ConCun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Shockwave Cannon does very little damage, mainly appying a concussive force where it hits.  The damage it does is not stopped by shields.\", 10);", 0);
		}
		if (%weapon == "EnergyRifle")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Good ol' ELF gun.  Suck the enemy's energy right out with this one.\", 10);", 0);
		}
		if (%weapon == "RailGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>A high-powered, high-speed and deadly-accurate projectile weapon.  Very little ammo capacity.\", 10);", 0);
		}
		if (%weapon == "Mfgl")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Start your own apocalypse with this weapon.  The Tactical Nuke has a timed fuse which will detonate 3 seconds after firing, regardless of where it is.\", 10);", 0);
		}
		if (%weapon == "Silencer")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Much like the Equalizer this weapon employs explosive-tipped bullets, but on a much higher-caliber scale.\", 10);", 0);
		}
		if (%weapon == "Vulcan")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Vulcan is a new and improved version of the Chaingun, firing bullets at an almost ludicrous speed.\", 10);", 0);
		}
		if (%weapon == "IonGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Ion Rifle was developed for exclusive use by the Arbitor armor, firing a stream of heavily charged particles at the enemy.\", 10);", 0);
		}
		if (%weapon == "Flamer")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Flamethrower is great for taking out anything in its path, but has a short range due to the energy-to-plasma conversion.\", 10);", 0);
		}
		if (%weapon == "TranqGun")
		{
			if(%clientId.Tranq == 0 || !%clientId.Tranq)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dart Rifle is currently set to <f3>Poison Dart<f1>.  This dart does fairly decent damage and poisons the enemy.\", 10);", 0);
			else if(%clientId.Tranq == 1)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dart Rifle is currently set to <f3>EMP Dart<f1>.  This dart does minor EMP damage, which will knock out the enemy's energy.  Takes double ammo to fire.\", 10);", 0);
			else if(%clientId.Tranq == 2)
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dart Rifle is currently set to <f3>Flare Dart<f1>.  This dart will set the enemy on fire and light up the area it hit for about 30 seconds.  It also decloaks enemy objects.\", 10);", 0);
		}
		if (%weapon == "HyperB")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The HyperBlaster fires projectiles that do a bit less damage than a Blaster bolt, but fires them at three times the Blaster's rate of fire.  End result: death.\", 10);", 0);
		}
		if (%weapon == "Volter")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Another Arbitor-only weapon, the Volter fires an ion-charged stream of plasma.\", 10);", 0);
		}
		if (%weapon == "FixIt")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Repair gun is an integrated part of the Engineer armor, almost identical to the Repair Pack.\", 10);", 0);
		}
		if (%weapon == "HackIt")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Hack Gun allows you to infect enemy objects with a virus that temporarily changes their team assignment.\", 10);", 0);
		}
		if (%weapon == "DisIt")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dyssi... Dissysi... Dysisy... nevermind.  It breaks deployables back into their backpack form, that's the important part.\", 10);", 0);
		}
		if (%weapon == "GravGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Grav Gun either drags or repels whomever it locks on to, depending on which firing mode you have selected.\", 10);", 0);
		}
		if (%weapon == "BoomStick")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Boomstick is a sawed-off shotgun.  With it a light armor can take out even the heaviest of heavy armors.\", 10);", 0);
		}
		if (%weapon == "TargetingLaser")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Targetting laser is useful for gathering teammates.  It also provides a pinpoint-accurate target for players using a Mortar or other lobbed weapons.\", 10);", 0);
		}
		if (%weapon == "RepairGun")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The repair gun comes with the repair pack and will allow you to repair other players and your own base items.\", 10);", 0);
		}
   	}
   	if (%opt == "flag") //======================================================================================= Flag Help
   	{

//		if (%flag == "-1")
//		{
//			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are not carrying a flag! .\", 10);", 0);		
//		}   	
//		if (%flag == "flag")
//		{
//			if ($Shifter::FlagNoReturn == "True")
//			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are carrying a flag, you need to take the flag to your flag stand!\", 10);", 0); 			
//			else
//			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>You are carrying a flag, you need to take the flag to your flag stand!\", 10);", 0);		
//		}
		if(%clientId.spawntype == "standard")
			bottomprint(%clientId,"<jc><f1>Your spawn prefference is currently set to Standard, the most basic of the spawn options.  This will give you the same armor each time you spawn.  You can go to Weapon Options if you wish to change this.",10);
		if(%clientId.spawntype == "random")
			bottomprint(%clientId,"<jc><f1>Your spawn prefference is currently set to Random.  This will spawn you in a randomly selected loadout.  Each loadout typically features some of the better weapons and packs that Shifter has to offer.",10);
		if(%clientId.spawntype == "favs")
			bottomprint(%clientId,"<jc><f1>Your spawn prefference is currently set to Favorites.  This spawns you in the last favorite loadout you selected, either in an inventory station or by pressing your favorites key.",10);
	
	}

   	if (%opt == "pack") //======================================================================================= Pack Help
   	{
   			//echo ("Pack - " @ %pack);	

		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You do not currently have a pack.\", 10);", 0);		
		}
		if (%pack == "EnergyPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Energy Pack helps to regenerate your energy faster, as well as providing some resistance to EMP effects.\", 10);", 0);
		}
		if (%pack == "RepairPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Repair Pack gives you the ability to repair items and other players.\", 10);", 0);
		}
		if (%pack == "ShieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Shield Pack will convert your energy into shielding to resist damage.\", 10);", 0);
		}
		if (%pack == "SensorJammerPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Sensor Jammer will dampen your sensor signal with in a certain radius.\", 10);", 0);
		}
		if (%pack == "RocketPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Rocket Turret is a smaller version of the large base rocket turret.\", 10);", 0);
		}
		if (%pack == "LaserPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Laser Turret can attach to almost any surface, and is small enough to conceal inside other objects.  A most deadly turret.\", 10);", 0);
		}
		if (%pack == "CloakingDevice")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Cloaking Device will make you invisable to enemies as well as friendly.\", 10);", 0);
		}
		if (%pack == "StealthShieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Stealth Shield will hide you from turrets and locking missles, while still providing some protection from damage.\", 10);", 0);
		}
		if (%pack == "LapTop")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Command Laptop will let you hack enemy turrets, as well as control friendly turrets without being at a command station.\", 10);", 0);
		}
		if (%pack == "ShockPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The EMP turret will drop an EMP blasting shell that will knock out all enemy energy and shielding.\", 10);", 0);
		}
		if (%pack == "TargetPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Mortar Turret is a smaller deployable version of the base mortar turret.  Unlike the base turrets it will fire on its own.\", 10);", 0);
		}
		if (%pack == "SuicidePack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Suicide Det Pack is a nuclear device which will detonate 20 seconds after you drop it.  It will also detonate immediately if you suicide.\", 10);", 0);
		}
		if (%pack == "DetPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The suicide pack is quite devistating, basically a nuclear device that you can drop, it will detonate in 20 seconds after drop..\", 10);", 0);
		}
		if (%pack == "CameraPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The camera pack will allow you to spy on the enemy (from a command station or lap top), placed in a sneaky location they might not even see it.\", 10);", 0);
		}
		if (%pack == "TurretPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Ion turret is quite nasty, firing the same bolts as the Ion Rifle.\", 10);", 0);
		}
		if (%pack == "AmmoPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Ammo Pack gives you an extra supplt of ammo for those long trips.\", 10);", 0);
		}
		if (%pack == "DeployableInvPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Inventory Station is quite nice for those far away mission, allowing you to purchace weapons, ammo and turrets.\", 10);", 0);
		}
		if (%pack == "DeployableAmmoPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>This small deployable station allows you to resupply just like the larger ones in your base.\", 10);", 0);
		}
		if (%pack == "MotionSensorPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Motion Sensor will allow your turrets to see targets that are cloaked or shielded by sensor surpression.\", 10);", 0);
		}
		if (%pack == "PulseSensorPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Pulse Sensor is a smaller version of the pulsing sensor found on many bases.\", 10);", 0);
		}
		if (%pack == "DeployableSensorJammerPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Sensor Jammer will shield you and your teammates from enemy sensors.\", 10);", 0);
		}
		if (%pack == "DeployableComPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Command Center will give you a remote station to control turrets.\", 10);", 0);
		}
		if (%pack == "PlasmaTurretPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Plasma Turret is a somewhat weaker version of the standard base defense turret.\", 10);", 0);
		}
		if (%pack == "ForceFieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>This is a smaller version of the forcefields found in your base.  It will temporarily deactivate when a friendly comes in contact with it.\", 10);", 0);
		}
		if (%pack == "LargeForceFieldPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>This is a large version of the forcefields you may have seen in your base.  It will temporarily deactivate when a friendly comes in contact with it.\", 10);", 0);
		}
		if (%pack == "DeployableElf")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable ELF turret is the smaller companion to the larger base defence version and can be mounted any where.\", 10);", 0);
		}
		if (%pack == "TeleportPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Teleport pack is just that: a Telepad platform.  You must use two of these.\", 10);", 0);
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> Place one where you want to start and the other were you want to go, your team can use it too.\", 10);", 10);
		}
		if (%pack == "BlastWallPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Blast Wall is a deployable wall which can take great amounts of damage.  Be warned that it does not open on contact like the similar-looking base doors.\", 10);", 0);
		}
		if (%pack == "PlatformPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Platform is a small platform which can be used to cover and defend deployables or block up entrances.  Not very strong.\", 10);", 0);
		}
		if (%pack == "BlastFloorPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Blast Floor is a large platform perfect for covering defensive turrets or blocking entrances.  Very strong.\", 10);", 0);
		}
		if (%pack == "TreePack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Mechanical tree serves little purpose but can be used for cover in many cases.\", 10);", 0);
		}
		if (%pack == "FgcPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Containment pack is needed for the Tactical Nuke when it is wielded by a Dreadnaught.\", 10);", 0);
		}
		if (%pack == "MechPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Deployable Interceptor pack is basically a small portable weaponless version of the Interceptor flier.\", 10);", 0);
		}
		if (%pack == "HoloPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Hologram is a very rudimentary artificially controlled drone.\", 10);", 0);
		}
		if (%pack == "RegenerationPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Regeneration Pack allows you to heal yourself by draining enemy objects or even players.  Very powerful.\", 10);", 0);
		}
		if (%pack == "LightningPack")
		{
			if($Shifter::TelePackOpts != false)
			{
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Teleport Pack has three different modes of operation, set in the Weapon Options menu.\", 7);", 0);
				if(%clientId.Tele == 0 || !%clientId.Tele)
		   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Teleport Pack is currently set to <f3>Telebeacon Operation<f1>.  This will teleport you to a beacon you deploy.\", 10);", 7);
				else if(%clientId.Tele == 1)
		   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Teleport Pack is currently set to <f3>Slipstream Operation<f1>.  This will teleport you to a waypoint you set in your command screen, but requires full energy to use.\", 10);", 7);
				else if(%clientId.Tele == 2)
		   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Your Teleport Pack is currently set to <f3>Hyperdrive Operation<f1>.  This will teleport you to any point in your line of sight within 125m of you.  Requires some energy to use.\", 10);", 7);
			}
			else
	   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Teleport Pack will teleport you to the position of a special beacon you set with the pack.\", 10);", 0);
		}
		if (%pack == "PlantPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Healing Plant will instantly heal any friendly players who come in contact with it.\", 10);", 0);
		}
		if (%pack == "FlightPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Flight Pack gives light armors an energy boost like the Energy Pack does, but is absent of the EMP resistance the Energy Pack possesses.\", 10);", 0);
		}
		if (%pack == "SMRPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Rocket Launcher Pack is an undearm pack which shoots Locking Stinger rockets.\", 10);", 0);
		}
		if (%pack == "LaunchPack")
		{
   			schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Launch Pad launches players upward when they come in contact with it.\", 10);", 0);
		}
		if(Player::getItemCount(%clientId,Hammer1Pack) > 0 && %armor == "jarmor")
		{
			bottomprint(%clientId,"<jc><f1>The Godhammer Cannon is actually two shoulder-mounted weapons, each firing high-yield missiles.\nThese weapons are cooled by a plasma cooling system integrated into the Juggernaught armor.\nOveruse of the Godhammers will cause it to overheat.",10);
		}
  	}   

   	else if (%opt == "mine") //================================================================================================= Mines
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The chemeleon mines are cloaking anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Scout armor mines are standard anti personel mines.\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Assassin armor mines are very simple flag decoys.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Arbitor armor mines are concussion mines.  These mines cloak so most enemies cannot see them.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Mercinary armor carries standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Engineer's mines can be set to many different options.  By default they are set to Replicator mines, which form two new mines when one is destroyed.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Goliath mines are standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "harmor")						//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Heavy's mines are standard anti-personel mines.\", 10);", 0);
   		}
   		if (%armor == "darmor")						//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dreadnaught armor mines are special, small Point Defense Laser turrets that will detonate after a short time.\", 10);", 0);
   		}
   		if (%armor == "jarmor")						//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Juggernaught does not carry any mines.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>I refuse to answer that until you put it back in your pants\", 10);", 0);
   		}
   	}
   	else if (%opt == "grenade") //===================================================================================== Grenades
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Chemeleon grenades are a plastique explosive which will detonate after a time period you can set in Weapon Options.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Scout grenades are a concussive grenade, good for boosting you or other people away from where they detonate.\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Assassin grenades are actually mines disguised as repair packs.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Arbitor grenades will poison the enemy.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Mercenary armor has only standard grenades.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Engineer grenade does EMP damage in a wide radius, great for stopping a fleeing flag runner.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Goliath grenades are similar to its beacons, doing plasma damage over a huge radius.\", 10);", 0);
   		}
   		if (%armor == "harmor")									//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Heavy's grenade is much like a mortar shell.\", 10);", 0);
   		}
   		if (%armor == "darmor")									//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Dreadnaught grenade is much like a mortar shell.\", 10);", 0);
   		}
   		if (%armor == "jarmor")									//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> The Juggernaught does not carry grenades.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Why are you worried about grenades when you have a penis that's bigger than you?\", 10);", 0);
   		}
   	}
   	else if (%opt == "beacon") //===================================================================================== Beacon
   	{
		if ($Shifter::Debug) echo ("Armor = " @ %armor);
   		
		if (%armor == "-1")
		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> You are either dead or in observer mode.\", 10);", 0);
		}
		if (%armor == "spyarmor" || %armor == "spyfemale") 		//== Chemeleon
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Chemeleon beacons are Satchel Charges.  They can either be detonated by shooting them or accessing them remotely through the command screen.\", 10);", 0);
   		}
   		if (%armor == "sarmor" || %armor == "sfemale") 			//== Scout
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Scout beacon induces a stim effect on the user, replenishing energy and giving a huge boost of speed but run the risk of killing the user.\", 10);", 0);
   		}
   		if (%armor == "larmor" || %armor == "lfemale") 			//== Assasin
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Assassin's beacons are poison-tipped shurikens.\", 10);", 0);
   		}
   		if (%armor == "aarmor" || %armor == "afemale")			//== Arbitor
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Arbitor beacons will allow you to cloak for about 15 seconds.\", 10);", 0);
   		}
   		if (%armor == "marmor" || %armor == "mfemale")			//== Mercinary
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Mercenary beacon will boost you in the direction you are facing.\", 10);", 0);
   		}
   		if (%armor == "earmor" || %armor == "efemale")			//== Engineer
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Engineer beacons have several deploy options, configured in the Weapon Options menu.\", 10);", 0);
   		}
   		if (%armor == "barmor" || %armor == "bfemale")			//== Goliath
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Goliath beacons are firebomb grenades.  After 5 seconds they detonate, spraying plasma damage in a huge radius.\", 10);", 0);
   		}
   		if (%armor == "harmor")									//== Base Heavy
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1> With standard heavy armor, you have Nuke Bomb grenades, much like mortar shells.\", 10);", 0);
   		}
   		if (%armor == "darmor")									//== Dreadnaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Dreadnaught's beacons initiate emergency shielding, which lasts for about 20 seconds.\", 10);", 0);
   		}
   		if (%armor == "jarmor")									//== Juggernaught
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Juggernaught's beacons serve multiple uses.  They can be used to temporarily boost energy regeneration, charge up the Heavy Plasma Cannon or increase the cooling speed of the Godhammer Cannons.\", 10);", 0);
   		}
   		if (%armor == "parmor")
   		{
   			   schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>I'd say a giant penis is a pretty big beacon in itself.\", 10);", 0);
   		}
   	}

//=========================================================================================================================================   
   else if(%opt == "fteamchange")
   {
	if ($debug) echo("fteamchange");
		%clientId.ptc = %cl;
		Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
		Client::addMenuItem(%clientId, "0Observer", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);

		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
	return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
      }
	      
	  if($Shifter::KeepBalanced && getNumTeams() <= 2)
      	  {
      	  	%i = checkTeams();
          	Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
          }
      	  else
          {
          	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
               Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      	  }
      return;
      
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
      
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";

   else if(%opt == "smute")
   {
	if(!%clientId.soundmute[%cl])
	   	%clientId.soundmute[%cl] = true;
	else
		%clientId.soundmute[%cl] = false;
   }
      
      
   else if(%opt == "vkick")
   {
      if(!%cl.justConnected)
      {
      	%cl.voteTarget = true;
      	Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
      }
      else bottomprint(%clientId,"<jc>You cannot kick someone until they have finished joining the server.",10);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   
   else if(%opt == "cffa")
   {
	Admin::setModeFFA(%clientId);
   	return;
   }
   
   else if(%opt == "ctourney")
   {
      if(%clientId.isSuperAdmin)
      {
      	Client::buildMenu(%clientId, "Confirm Toruney Mode:", "faffirm", true);
      	Client::addMenuItem(%clientId, "1Enable", "yes");
      	Client::addMenuItem(%clientId, "2Cancel", "no");
      	return;
      }
   }
      
   else if(%opt == "voteYes" && %cl == $curVoteCount) //====================================================================== Yes
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "voteNo" && %cl == $curVoteCount) //======================================================================= No
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   
   else if(%opt == "kick") //================================================================================================= Kick Player
   {
      	Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      	Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      	return;
   }
   
   else if(%opt == "admin") //================================================================================================ Admin
   {
      	Client::buildMenu(%clientId, "Confirm admin:", "aaffirm", true);
      	Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      	return;
   }
   
   else if(%opt == "deadmin") //============================================================================================== DeAdmin Conf
   {
      	Client::buildMenu(%clientId, "Confirm deadmim:", "daffirm", true);
      	Client::addMenuItem(%clientId, "1DeAdmin " @ Client::getName(%cl), "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't DeAdmin " @ Client::getName(%cl), "no " @ %cl);
      	return;
   }
   
   else if(%opt == "botmenu") //============================================================================================== Bot Menu
   {
         Client::buildMenu(%clientId, "Bot Menu:", "selbotaction", true);
         Client::addMenuItem(%clientId, "1Spawn A Bot", "spawnbot");
	     Client::addMenuItem(%clientId, "2Remove Bot", "removebot");
	     if(%clientId.isSuperAdmin)
		 	Client::addMenuItem(%clientId, "3Killem All", "kbaffirm");
         
		 return;
   }
   
   else if(%opt == "ban") //================================================================================================== Ban Player
   {
      	Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      	Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      	return;
   }
   else if(%opt == "kill") //======================================================================== Admin Kill Player
   {
	messageAllAdmins(1,1,Client::getName(%clientId) @ " has accessed the admin kill function.");
	if(%clientId.isSuperAdmin && %clientId.isAdmin)
	{
       		Player::setArmor(%cl,larmor);
   		armorChange(%cl);
		Player::blowUp(%cl);
		Player::unMountItem(%cl,4);
		Player::unMountItem(%cl,5);
   		remoteKill(%cl);
   		messageAll(0, Client::getName(%cl) @ " spontaneously combusted.");
  	    	return; 
	}
	else
	{
		%clientId.adminspam++;
		checkAdminSpam(%clientId);	
		return;
	}
   }
   else if(%opt == "boot") //======================================================================== Admin Boot-to-Head Player
   {
	if(%clientId.isAdmin)
	{
		Client::sendmessage(%cl,1,"Boot to the Head!~wdebris_medium.wav");
		ixApplyKickback(%cl,1500,-10);
   		messageAll(0, Client::getName(%cl) @ " took a Boot to the Head from " @ Client::getName(%clientId) @ ".");
  	    	return; 
	}
   }

   else if(%opt == "blink") //======================================================================== Blink Curse
   {
	messageAllAdmins(1,1,Client::getName(%clientId) @ " has accessed the Possess function.");
	if(%clientId.isSuperAdmin)
	{
//		if(!%cl.Blinked || %cl.Blinked == false)
//		{
//			%pl = Client::getOwnedObject(%cl);
//			Client::sendmessage(%cl,1,"You have been Blinked!~wteleport2.wav");
//			%cl.Blinked = true;
//			KeepBlinking(%cl,%pl);
// 			messageAll(0, Client::getName(%cl) @ " has been Blinked by " @ Client::getName(%clientId) @ ".");
//		    	return; 
//		}
//		else
//		{
//			Client::sendMessage(%cl,1,"You are no longer Blinked.  Count your blessings and move on.~wteleport2.wav");
//			%cl.Blinked = false;
//			messageAll(0, Client::getName(%cl) @ " is no longer Blinked.");
//			return;
//		}
		if(%client.possessing == "true")
		{
			doneposs(%clientId);
			return;
		}
		else
		{
			startposs(%cl, %clientId);
			return;
		}
	}
   }

//==================================================================================================== Penis Curse
else if(%opt == "peniscurse") 
{
	messageAllAdmins(1,1,Client::getName(%clientId) @ " has accessed the Penis Curse function.");
	peniscurse(%cl,%clientId);
}
//======================================================================================================================= End Penis Curse

   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   
   else if(%opt == "vcmission" || %opt == "cmission")
   {
	%first = getWord(%options, 1);

	Client::buildMenu(%clientId, "SELECT MISSION TYPE", "cmtype", true);
	%index = 0;

	if ($MList::TypeCount < 2) $TypeStart = 0; else $TypeStart = 1;

	for(%i = $TypeStart; %i < $MLIST::TypeCount; %i++)
	{
	if ($MLIST::Type[%i] != "Training")
	{
	%index++;
	if (%index <= 7)
	{
	Client::addMenuItem(%clientId, %index @ $MLIST::Type[%i], %i @ " 0");
	} else
	{
	Client::addMenuItem(%clientId, %index @ "More Mission Types...", "more " @ %i);
	break;
	}
	}

	}

	return;

      //Admin::changeMissionMenu(%clientId, %opt == "cmission");
      //return;
   }
   else if(%opt == "ctimelimit")
   {
      if(%clientId.isAdmin)
      {
	Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      	Client::addMenuItem(%clientId, "110 Minutes", 10);
      	Client::addMenuItem(%clientId, "215 Minutes", 15);
      	Client::addMenuItem(%clientId, "320 Minutes", 20);
      	Client::addMenuItem(%clientId, "425 Minutes", 25);
      	Client::addMenuItem(%clientId, "530 Minutes", 30);
      	Client::addMenuItem(%clientId, "645 Minutes", 45);
      	Client::addMenuItem(%clientId, "760 Minutes", 60);
      	Client::addMenuItem(%clientId, "8No Time Limit", 0);
      	return;
      }
   }
   else if(%opt == "reset")
   {
      if(%clientId.isSuperAdmin)
      {
      	Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      	Client::addMenuItem(%clientId, "1Reset", "yes");
      	Client::addMenuItem(%clientId, "2Don't Reset", "no");
      	return;
      }
   }
   else if(%opt == "matchConfig")
   {
      if(%clientId.isAdmin)
      {
      	Client::buildMenu(%clientId, "Confirm Match configuration:", "maffirm", true);
      	Client::addMenuItem(%clientId, "1Enable", "yes");
      	Client::addMenuItem(%clientId, "2Cancel", "no");
      	return;
      }
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }

   else if(%opt == "botsoff") //====================================================================== Admin - Disable Bots
   {
		$Shifter::AreThereBots = False;
		$Spoonbot::AutoSpawn = False;
		$sbots = False;
	    	messageAll(0, Client::getName(%clientId) @ " Turns Bots Off.");
		if ($debug) echo(Client::getName(%clientId) @ " Turns Bots Off.");
   }
   else if (%opt == "botson") //====================================================================== Admin - Enable Bots
   {
		$Shifter::AreThereBots = True;
		$Spoonbot::AutoSpawn = True;
		%sbots = True;
		messageAll(0, Client::getName(%clientId) @ " Turns Bots On.");
		if ($debug) echo (Client::getName(%clientId) @ " Turns Bots On.");
   }
   Game::menuRequest(%clientId);
}

//====================================================================================================== Varrious Menu Process

function processMenuKAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Kicked By " @ Client::getName(%clientId));

   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Banned By " @ Client::getName(%clientId));

   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
      if(%clientId.isSuperAdmin)
      {
         %cl = getWord(%opt, 1);
         %cl.isAdmin = true;
         messageAll(0, Client::getName(%clientId) @ " made " @ Client::getName(%cl) @ " into an admin.");
 	 echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined By " @ Client::getName(%clientId));
         
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuDAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
   {
	if(%clientId.isSuperAdmin && !%cl.isSuperadmin)
	{
		%cl = getWord(%opt, 1);
		%cl.isAdmin = false;
		messageAll(0, Client::getName(%clientId) @ " revoked " @ Client::getName(%cl) @ "'s admin ability.");
		echo("ADMINMSG: **** " @ Client::getName(getWord(%opt, 1)) @ " Admined Revoked By " @ Client::getName(%clientId));
		return;
	}
	else if (%cl.isSuperadmin)
	{
		bottomprint(%clientId, "<jc>You can not Revoke a Super Admin.");
		return;
	}
   }
   Game::menuRequest(%clientId);
}


function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server Reset By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      exec("serverConfig.cs");
       	 Server::storeData();
      	 echo("ADMINMSG: **** Default config stored");
      	 Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuFAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to Tournament Mode By " @ Client::getName(%clientId));

      messageAll(0, Client::getName(%clientId) @ " has set the server to Tournament mode.");
      Admin::setModeTourney(%clientId);
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuMAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
	 echo("ADMINMSG: **** Server set to match configuration By " @ Client::getName(%clientId));
	 messageAll(0, Client::getName(%clientId) @ " set the server to match settings.");
     	 exec("matchConfig.cs");
     	 Server::storeData();
      	 echo("ADMINMSG: **** Match config stored");
      	 Server::refreshData();
    
   }
   Game::menuRequest(%clientId);
}

//================================================================================================================ Bot Control Functions
// Check for team with lowest # of players  (Based on code by Shrike and Labrat)

function checkTeams()
{
      %numTeams = getNumTeams();
      %numPlayers = getNumClients();
      for(%i=0;%i<%numTeams;%i=%i+1)
         	%numTeamPlayers[%i] = 0;
			
      for(%i=0;%i<%numPlayers;%i=%i+1)
      {
         	%pl = getClientByIndex(%i);
         	if(%pl != %playerId)
         	{
            		%team = Client::getTeam(%pl);
            		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         	}
      }
      %lowPlayer = %numTeamPlayers[0];
      %lowTeam = 0;

      for(%i=1;%i<%numTeams;%i=%i+1)
      {
         	if(%numTeamPlayers[%i] < %lowPlayer)
         	{
            		%lowTeam = %i;
            		%lowPlayer = %numTeamPlayers;
         	}
      }
      return %lowTeam;
} 

function checkteams2()
{
	for(%i=1;%i<%numTeams;%i++)
		%numplayers[%i] = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		%numplayers[GameBase::getTeam(%cl)]++;

	%lowteam = 0;

	for(%i=1;%i<%numTeams;%i++)
	{
		if(%numplayers[%i] < %numplayers[%lowteam])
			%lowteam = %i;
	}
	return %lowteam;
}

function DistanceToTarget (%clientId, %targetId)
{
	return (Vector::getDistance(GameBase::getPosition(%clientId),GameBase::getPosition(%targetId)));
}

// ===============================================================================================================
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %pl));
      		if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %pl));
      		if(String::findSubStr(%clName,$Shifter::Tag0) == 0)
		 {
			//processmenuPickTeam(%pl,0,"");
			GameBase::setTeam(%pl,0);
		 }		
		else if(String::findSubStr(%clName,$Shifter::Tag1) == 0)
		 {
			//processmenuPickTeam(%pl,1,"");
			GameBase::setTeam(%pl, 1);
		 }
		 else 
      			GameBase::setTeam(%pl, -1);
	}
	return;
}

function PlayerFindFlag(%clientId,%x)
{
		%pos = GameBase::getPosition($teamFlag[%x]);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%distance = Vector::getDistance(%pos, %playerpos);
		issueCommand(%clientId, %clientId, 0,"Waypoint set to enemy flag. ", %posX, %posY);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The " @ getTeamName(%x) @ " flag is " @ %distance @ " meters away.\", 3);", 0);
}