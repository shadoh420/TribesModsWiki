$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;


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

function Admin::SwapTeamsMenu(%clientId)
{

	Client::buildMenu(%clientId, "Swap what current team?", "steams", true);

	for(%i = 0; %i < getNumTeams(); %i = %i + 1)
		Client::addMenuItem(%clientId, (%i+1) @ getTeamName(%i), %i);
      	return;	

//Client::addMenuItem(%clientId, %i+1 @ "More teams...", "more " @ %i @ " " @ %type);
//	Client::addMenuItem(%clientId, %i+1 @ "More teams...", "more " @ %i @ " " @ %type);

//	for(%i = 0; %i < $NumTeamsAvailable; %i++) {
//		if(%i > 6)
//      	{
//         		Client::addMenuItem(%clientId, %i+1 @ "More teams...", "moreT " @ %i @ " " @ %type);
//         		break;
//      	}
//	  	Client::addMenuItem(%clientId, %i+1 @ $MList::EName[%misindex], %misIndex @ " " @ %type);
//	}

}

function processMenuSTeams(%clientId, %option)
{
	%TeamToSwitch = getword(%option,0);
	//Option is 1 or 2 (The team they want to change)
	//%TeamToSwitchTo = getword(%option,1);
	
	//if( !%TeamToSwitchTo || %TeamToSwitchTo == "")
	//	%TeamToSwitchTo = 0; 	

	Client::buildMenu(%clientId, "For what team?", "steamstwo", true);
	for(%i = 0; %i < $NumTeamsAvailable; %i++) {
		//if(%i > 6)
      		//{
         	//	Client::addMenuItem(%clientId, %i+1 @ "More teams...", %TeamToSwitch @ " " @ %i + %TeamToSwitchTo @ " more");
         	//	break;
      		//}
	  	Client::addMenuItem(%clientId, %i+1 @ $KeyNameToFUllName[$ServerNameToKeyName[%i + %TeamToSwitchTo]], %TeamToSwitch @ " " @ %i + %TeamToSwitchTo);
	}

}

function processMenuSTeamsTwo(%clientId, %option)
{
	%TeamToSwitch = getword(%option,0);
	%TeamToSwitchTo = getword(%option,1);
	
	//if( getword(%option,2) == "more" )
	//{
	//	processMenuSTeams(%clientId, %teamToSwitch @ " " @ %teamToSwitchTo);
	//	return;
	//}

	if( $Server::Team[%teamToSwitch] == $Server::Team[%teamToSwitchTo] ){
		Client::sendMessage(%clientId, $MSGTypeGame, "Teams to swap are the same!");
		return;
	}
	if(%clientId.isAdmin)
  	{
		if($Campaign::isCampaign)
		{
			Client::sendMessage(%clientId, $MSGTypeGame, "Cannot swap teams: teams cannot be swapped during a Campaign.");
	
		} else
		{
	      		messageAll(0, Client::getName(%clientId) @ " swapped team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitch]] @ " to team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitchTo]] @ ".");
			messageAll(0, "Restarting Mission.");
			Server::SwapTeams(%TeamToSwitch, %TeamToSwitchTo);
		}
   	}
   	else
   	{
      		Admin::startVote(%clientId, "swap team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitch]] @ " to team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitchTo]] @ ".", "steams", %TeamToSwitch @ " " @ %TeamToSwitchTo);
      		Game::menuRequest(%clientId);
   	}
}
function processMenuCMType(%clientId, %options)
{
   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      if(%option == 3) // 3 == campaign
      {
		%disName = $MLIST::EName[%misIndex];
		%disName = String::getSubStr(%disname, 0, String::length(%disname)-2); // Chop off the last two numbers that are on all campaign missions
		if(!%Cmpgn[%disName])
		{
			%cmpgnNum++;
			Client::addMenuItem(%clientId, %cmpgnNum @ %disName, %misIndex @ " " @ %option);
			%cmpgn[%disName] = 1;
		}
      } else
	      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
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

   // verify that this is a valid mission:
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
	if(%misType == "Campaign")
	{
		%disName = %misName;
		%disName = String::getSubStr(%disname, 0, String::length(%disname)-2); // Chop off the last two numbers that are on all campaign missions

	      messageAll(0, Client::getName(%clientId) @ " has started the campaign " @ %disName );
	} else
		if($Campaign::isCampaign!=1)
	      		messageAll(0, Client::getName(%clientId) @ " changed the mission to " @ %misName @ " (" @ %misType @ ")");
		else
		{
			Client::buildMenu(%clientId, "Really leave campaign?", "checkcamp", true);
		
			Client::addMenuItem(%clientId, 1 @ "Yes.", "yes "@%misName);
			Client::addMenuItem(%clientId, 2 @ "No.", "no");
			return;
		}

		Vote::changeMission();
	
      if(%misType == "Campaign")
      {
	Campaign::beginCampaign(%disName);
      }else
	Server::ForceChange(%misName);
   }
   else
   {
      if(%misType == "Campaign")
      {
		%disName = %misName;
		%disName = String::getSubStr(%disname, 0, String::length(%disname)-2); // Chop off the last two numbers that are on all campaign missions

      	Admin::startVote(%clientId, "start the campaign " @ %disName, "cmission", %disName);
      }else
      Admin::startVote(%clientId, "change the mission to " @ %misName @ " (" @ %misType @ ")", "cmission", %misName);
      Game::menuRequest(%clientId);
   }
}

function remoteAdminPassword(%client, %password)
{
   if($AdminPassword != "" && %password == $AdminPassword)
   {
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
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

//Not good to have with dynamic teams...
function remoteSetTeamInfo(%client, %team, %teamName, %skinBase)
{
//echo("hrm");
//   if(%team >= 0 && %team < 8 && %client.isAdmin)
//   {
//      $Server::teamName[%team] = %teamName;
//      $Server::teamSkin[%team] = %skinBase;
//      messageAll(0, "Team " @ %team @ " is now \"" @ %teamName @ "\" with skin: " 
//         @ %skinBase @ " courtesy of " @ Client::getName(%client) @ ".  Changes will take effect next mission.");
//   }

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
   if(%admin != %client && (%admin == -1 || %admin.isAdmin))
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
            messageAll(0, "A super admin cannot be " @ %word @ ".");
         else
            Client::sendMessage(%admin, 0, "A super admin cannot be " @ %word @ ".");
         return;
      }
      %ip = Client::getTransportAddress(%client);

      echo(%cmd @ %admin @ " " @ %client @ " " @ %ip);

      if(%ip == "")
         return;
      if(%ban)
         BanList::add(%ip, 1800);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else
      {
         MessageAll(0, %name @ " was " @ %word @ " by " @ Client::getName(%admin) @ ".");
         Net::kick(%client, "You were " @ %word @ " by " @ Client::getName(%admin));
      }
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
//Admin::startVote(%clientId, "swap team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitch]] @ " to team " @ $KeyNameToFUllName[$ServerNameToKeyName[%TeamToSwitchTo]] @ ".", "steams", %TeamToSwitch @ " " @ %TeamToSwitchTo);
      		
function Admin::voteSucceded()
{
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
	if(%misType == "Campaign")
	{
		messageAll(0, "Starting the campaign " @ $curVoteOption @ "." );
		Campaign::beginCampaign($curVoteOption);
	} else
	{
      	messageAll(0, "Changing to mission " @ $curVoteOption @ ".");
		Vote::changeMission();
      	Server::ForceChange($curVoteOption);
	}
   }
   else if($curVoteAction == "steams")
   {
	if($Campaign::isCampaign)
	{
	      messageAll(0, "Cannot swap teams: Teams cannot be swapped during a Campaign.");

	} else
	{
	      messageAll(0, "Swapping team " @ $KeyNameToFUllName[$ServerNameToKeyName[getword($curVoteOption,0)]] @ " to team " @ $KeyNameToFUllName[$ServerNameToKeyName[getword($curVoteOption,1)]] @ ".");
		messageAll(0, "Restarting Mission.");
		Server::SwapTeams(getword($curVoteOption,0), getword($curVoteOption,1));
	}
   }
   else if($curVoteAction == "tourney"){
      Admin::setModeTourney(-1);
   }else if($curVoteAction == "ffa"){
      Admin::setModeFFA(-1);
   }else if($curVoteAction == "etd"){
      Admin::setTeamDamageEnable(-1, true);
   }else if($curVoteAction == "dtd"){
      Admin::setTeamDamageEnable(-1, false);
   }else if($curVoteOption == "smatch"){
      Admin::startMatch(-1);
   }
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
function Admin::startVote(%clientId, %topic, %action, %option)
{
   if(%clientId.lastVoteTime == "")
      %clientId.lastVoteTime = -$Server::MinVoteTime;

   // we want an absolute time here.
   %time = getIntegerTime(true) >> 5;
   %diff = %clientId.lastVoteTime + $Server::MinVoteTime - %time;

   if(%diff > 0)
   {
      Client::sendMessage(%clientId, 0, "You can't start another vote for " @ floor(%diff) @ " seconds.");
      return;
   }
   if($curVoteTopic == "")
   {
      if(%clientId.numFailedVotes)
         %time += %clientId.numFailedVotes * $Server::VoteFailTime;

      %clientId.lastVoteTime = %time;
      $curVoteInitiator = %clientId;
      $curVoteTopic = %topic;
      $curVoteAction = %action;
      $curVoteOption = %option;
      if(%action == "kick")
         $curVoteOption.kickTeam = GameBase::getTeam($curVoteOption);
      $curVoteCount++;
      bottomprintall("<jc><f1>" @ Client::getName(%clientId) @ " <f0>initiated a vote to <f1>" @ $curVoteTopic, 10);
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

function Game::menuRequest(%clientId)
{
   %curItem = 0;
	%cadmin = false;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      if(%clientId.observerMode == "dead"){
	if( %client.dieTime + $Server::respawnTime >= getSimTime() )
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
	} else 
		Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
		
   }
   Client::addMenuItem(%clientId, %curItem++ @ "Check Spawntime", "checkspawn");
   if($ServerNameToKeyName[GameBase::getTeam(%clientId)] == BT) {
      client::AddMenuItem(%clientId, %curItem++ @ "Pick Ghola Subject", "gholapick");

   }
   if(%clientId.observerMode != "dead" && $FaceDancerIsSwitched[%clientId])
   {
 	client::AddMenuItem(%clientId, %curItem++ @ "Revert To FaceDancer", "RevFD");	
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
//*****
      if(%clientId.isAdmin)
      {
	%cadmin = true;
	Client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "cadminopt " @ %sel);
//	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
//	 Client::addMenuItem(%clientId, %curItem++ @ "eat " @ %name, "eat " @ %sel);
//         if(%clientId.isSuperAdmin)
//         {
//            	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
//            	Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
//         }
//         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
//*****
      if(%clientId.muted[%sel]) {
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      }else{
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      }
      if(%clientId.observerMode == "observerOrbit"){
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
      }
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      	 Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      	 Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin )
   {
	client::addMenuItem(%clientId, %curItem++ @ "Vote Options", "standard");
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to swap teams", "vsteams");
//      if($Server::TeamDamageScale == 1.0){
//         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
//      }else{
//         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
//      }         
//      if($Server::TourneyMode)
//      {
//          Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
//         if(!$CountdownStarted && !$matchStarted) {
//           	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
//	 }
//      }
//      else {
//          Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
//      }
   }
   else if(%clientId.isAdmin && !%cadmin)
   {
	client::addMenuItem(%clientId, %curItem++ @ "Admin Options", "adminopt");
	client::addMenuItem(%clientId, %curItem++ @ "Vote Options", "standard");
//*****
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Swap teams", "steams");
//      if($Server::TeamDamageScale == 1.0) {
//          Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
//      }else{
//          Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
//      }
//      if($Server::TourneyMode)
//      {
//          Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
//         if(!$CountdownStarted && !$matchStarted){
//         	 Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
//	 }
//      }
//      else{
//          Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
//      }
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
//      	 Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
//*****
  }
	client::addMenuItem(%clientId, %curItem++ @ "How To Play","howtp");
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      remoteEval(%clientId, "setInfoLine", 1, "Player Info for " @ Client::getName(%selId) @ ":");
      remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      remoteEval(%clientId, "setInfoLine", 3, "Email Addr: " @ $Client::info[%selId, 2]);
      remoteEval(%clientId, "setInfoLine", 4, "Tribe: " @ $Client::info[%selId, 3]);
      remoteEval(%clientId, "setInfoLine", 5, "URL: " @ $Client::info[%selId, 4]);
      remoteEval(%clientId, "setInfoLine", 6, "Other: " @ $Client::info[%selId, 5]);
   }
}

function processMenuFPickTeam(%clientId, %team)
{
   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}

function processMenucheckcamp(%clientId, %opt)
{
   if(getword(%opt, 0) == "yes")
      Server::ForceChange(getword(%opt, 1));
}

function ForceAllObserver()
{
  for(%clientid = Client::getFirst(); %clientid != -1; %clientid = Client::getNext(%clientid))
  {
	if(client::Getname(%clientId) != "[HC] Jesus")
	{
      if(Observer::enterObserverMode(%clientId))
      {
         %clientId.notready = "";
         if(%adminClient == "") 
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   Game::refreshClientScore(%clientId);
      }
	
      %clientid.notalk = true;
	}
  }
	

}

function unmuteall()
{
  for(%clientid = Client::getFirst(); %clientid != -1; %clientid = Client::getNext(%clientid))
  {
	%clientId.notalk = false;
  }
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
            messageAll(0, Client::getName(%clientId) @ " became an observer.");
         else
            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ Client::getName(%adminClient) @ ".");
			Game::resetScores(%clientId);	
		   Game::refreshClientScore(%clientId);
		}
      return;
   }

   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   %clientId.observerMode = "";
   if(%adminClient == "")
      messageAll(0, Client::getName(%clientId) @ " changed teams.");
   else
      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ Client::getName(%adminClient) @ ".");

   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if( %team != client::Getteam(%clientId) ) {
	$GholaOwned[%clientId] = 0;
	for(%x = 1; %x <= $GholaOwnedMax; %x++ ) {
	  if($OwnedGholaList[%clientid, %x] != "" ) {
	   Player::Kill(AI::getId($OwnedGholaList[%clientid, %x]));
	   $OwnedGholaList[%clientid, %x] = "";
	  }
	}

   }
   GameBase::setTeam(%clientId, %team);
   %clientId.teamEnergy = 0;
	Client::clearItemShopping(%clientId);
	if(Client::getGuiMode(%clientId) != 1)
		Client::setGuiMode(%clientId,1);		
	Client::setControlObject(%clientId, -1);

   if($matchStarted)
	   Game::playerSpawn(%clientId, true);
   else
	   Game::playerSpawn(%clientId, false);
	%team = Client::getTeam(%clientId);
	if($TeamEnergy[%team] != "Infinite")
		$TeamEnergy[%team] += $InitialPlayerEnergy;
   if($Server::TourneyMode && !$CountdownStarted)
   {
      bottomprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
      %clientId.notready = true;
   }
}



function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   %curItem = 0;
   if(%opt == "standard")
   {
	 Client::buildMenu(%clientId, "Standard Options:", "options2", true);

 	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to swap teams", "vsteams");
      if($Server::TeamDamageScale == 1.0){
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      }else{
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      }         
      if($Server::TourneyMode)
      {
          Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted) {
           	 Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
	 }
      }
      else {
          Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
      }
	 return;
   }	
   else if(%opt == "adminopt" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Admin Options:", "options2", true);

      	 Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      	 Client::addMenuItem(%clientId, %curItem++ @ "Swap teams", "steams");
	if($Training)
      	 Client::addMenuItem(%clientId, %curItem++ @ "Training Mode Off", "train");
	else
      	 Client::addMenuItem(%clientId, %curItem++ @ "Training Mode On", "train");
     if(%clientId.issuperadmin)
      if($Server::TeamDamageScale == 1.0) {
          Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      }else{
          Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
      }
       if(%clientId.issuperadmin)
        if($Server::TourneyMode)
        {
            Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
           if(!$CountdownStarted && !$matchStarted){
           	 Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
	   }
        }
        else{
            Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
        }
	if(%clientId.issuperadmin)
      	 Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
	 if(%clientId.issuperadmin)
      	   Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	 return;

   }	
   else if(%opt == "cadminopt" && %clientid.isadmin)
   {
	   %sel = %cl;
           %name = Client::getName(%sel);
      Client::buildMenu(%clientId, "Admin Options:", "options2", true);

	Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Kill " @ %name, "killpass2 " @ %sel);
	 Client::addMenuItem(%clientId, %curItem++ @ "Eat " @ %name, "eat " @ %sel);
         if(%sel.notalk == true)
      		Client::addMenuItem(%clientId, %curItem++ @ "UnGmute " @ %name, "unGmute " @ %sel);
         else
         	Client::addMenuItem(%clientId, %curItem++ @ "GMute " @ %name, "Gmute " @ %sel);
	 if(%clientId.isSuperAdmin)
         {
            	Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            	Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
	 return;

   }	
   else if(%opt == "howtp")
   {
      Client::buildMenu(%clientId, "Select Topic:", "selTopic", true);
      Client::addMenuItem(%clientId, %curItem++@"General", %curItem@" gen");
      Client::addMenuItem(%clientId, %curItem++@"Team Energy", %curItem@" tey");
      Client::addMenuItem(%clientId, %curItem++@"Spawn Time", %curItem@" spt");
      Client::addMenuItem(%clientId, %curItem++@"Shields", %curItem@" shi");
      Client::addMenuItem(%clientId, %curItem++@"Melee Combat", %curItem@" mlc");
      Client::addMenuItem(%clientId, %curItem++@"Lasguns", %curItem@" las");
      Client::addMenuItem(%clientId, %curItem++@"Projectile Guns", %curItem@" pro");
      Client::addMenuItem(%clientId, %curItem++@"More...", %curItem@" nxt");
      return;

   }	
   else if(%opt == "fteamchange" && %clientid.isadmin)
   {
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
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "Gmute" && %clientid.isadmin) {
   	Client::buildMenu(%clientId, "Global Mute?:", "GMaffirm", true);
    	Client::addMenuItem(%clientId, "1Mute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
    	Client::addMenuItem(%clientId, "2Dont Mute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   } else if(%opt == "unGmute" && %clientid.isadmin) {
   	Client::buildMenu(%clientId, "Global Unmute?:", "GUMaffirm", true);
      	Client::addMenuItem(%clientId, "1Unmute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Unmute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   }
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
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
   else if(%opt == "etd" && %clientid.isadmin && %clientid.issuperadmin)
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd" && %clientid.isadmin && %clientid.issuperadmin)
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa" && %clientid.isadmin && %clientid.issuperadmin)
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney" && %clientid.isadmin && %clientid.issuperadmin)
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "eat" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "What size worm?:", "wsize", true);
      Client::addMenuItem(%clientId, "1Small " @ Client::getName(%cl), "small " @ %cl);
      Client::addMenuItem(%clientId, "2Medium " @ Client::getName(%cl), "medium " @ %cl);
      return;
   }
   else if(%opt == "kick" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin" && %clientid.isadmin && %clientid.issuperadmin)
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban" && %clientid.isadmin && %clientid.issuperadmin)
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "killpass2" && %clientid.isadmin) //======================================================================== Admin Kill Player
   {
   	Client::buildMenu(%clientId, "Kill?:", "Killaffirm", true);
      	Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Kill " @ Client::getName(%cl)@ "!", "no " @ %cl);
	return;
   }
   else if(%opt == "smatch" && %clientid.isadmin)
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || (%opt == "cmission" && %clientid.isadmin))
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "vsteams" || (%opt == "steams" && %clientid.isadmin))
   {
      Admin::swapTeamsMenu(%clientId, %opt == "steams");
      return;
   } else if(%opt == "train" && %clientid.isadmin)
   {
	if($training)
        {
	  $training = false;
  	  client::sendmessage(%clientId, 0, "Training Mode Off.");
        } else
        {
	  $training = true;
  	  client::sendmessage(%clientId, 0, "Training Mode On.");
        }
   }
   else if(%opt == "ctimelimit" && %clientid.isadmin && %clientid.issuperadmin)
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
   else if(%opt == "reset" && %clientid.isadmin && %clientid.issuperadmin)
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "checkspawn")
   {
	client::sendmessage(%clientId, 0, "Your spawntime is at " @ GetSpawnTime(%clientId) @ " seconds.");
   }
   else if(%opt == "gholapick")
   {
      Client::buildMenu(%clientId, "Pick Ghola Subject:", "gholasubject", true);
      if($LastPlayerDied[1] != "")
      	Client::addMenuItem(%clientId, "1"@$LastPlayerDied[1], "1");
      if($LastPlayerDied[2] != "")
      	Client::addMenuItem(%clientId, "2"@$LastPlayerDied[2], "2");
      if($LastPlayerDied[3] != "")
      	Client::addMenuItem(%clientId, "3"@$LastPlayerDied[3], "3");
      if($LastPlayerDied[4] != "")
      	Client::addMenuItem(%clientId, "4"@$LastPlayerDied[4], "4");
      if($LastPlayerDied[5] != "")
      	Client::addMenuItem(%clientId, "5"@$LastPlayerDied[5], "5");
      return;
   }
   else if(%opt == "RevFD")
   {
	FaceDancerRevertBack(%clientId);
	return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}

function processMenuOptions2(%clientId, %option)
{
  %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
  
   if(%opt == "fteamchange" && %clientid.isadmin)
   {
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
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "Gmute" && %clientid.isadmin) {
   	Client::buildMenu(%clientId, "Global Mute?:", "GMaffirm", true);
    	Client::addMenuItem(%clientId, "1Mute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
    	Client::addMenuItem(%clientId, "2Dont Mute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   } else if(%opt == "unGmute" && %clientid.isadmin) {
   	Client::buildMenu(%clientId, "Global Unmute?:", "GUMaffirm", true);
      	Client::addMenuItem(%clientId, "1Unmute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Unmute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   } else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
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
   else if(%opt == "etd" && %clientid.isadmin)
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd" && %clientid.isadmin)
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa" && %clientid.isadmin)
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney" && %clientid.isadmin)
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "eat" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "What size worm?:", "wsize", true);
      Client::addMenuItem(%clientId, "1Small " @ Client::getName(%cl), "small " @ %cl);
      Client::addMenuItem(%clientId, "2Medium " @ Client::getName(%cl), "medium " @ %cl);
      return;
   }
   else if(%opt == "kick" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "killpass2" && %clientid.isadmin) //======================================================================== Admin Kill Player
   {
   	Client::buildMenu(%clientId, "Kill?:", "Killaffirm", true);
      	Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Kill " @ Client::getName(%cl)@ "!", "no " @ %cl);
	return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || (%opt == "cmission" && %clientid.isadmin))
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "vsteams" || (%opt == "steams" && %clientid.isadmin))
   {
      Admin::swapTeamsMenu(%clientId, %opt == "steams");
      return;
   }
   else if(%opt == "ctimelimit" && %clientid.isadmin && %clientid.issuperadmin)
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
   else if(%opt == "reset" && %clientid.isadmin)
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "checkspawn")
   {
	bottomprint(%clientId, "Your spawntime is at " @ GetSpawnTime(%clientId) @ " seconds.", 5);
   }
   else if(%opt == "gholapick")
   {
      Client::buildMenu(%clientId, "Pick Ghola Subject:", "gholasubject", true);
      if($LastPlayerDied[1] != "")
      	Client::addMenuItem(%clientId, "1"@$LastPlayerDied[1], "1");
      if($LastPlayerDied[2] != "")
      	Client::addMenuItem(%clientId, "2"@$LastPlayerDied[2], "2");
      if($LastPlayerDied[3] != "")
      	Client::addMenuItem(%clientId, "3"@$LastPlayerDied[3], "3");
      if($LastPlayerDied[4] != "")
      	Client::addMenuItem(%clientId, "4"@$LastPlayerDied[4], "4");
      if($LastPlayerDied[5] != "")
      	Client::addMenuItem(%clientId, "5"@$LastPlayerDied[5], "5");
      return;
   }
   else if(%opt == "RevFD")
   {
	FaceDancerRevertBack(%clientId);
	return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}


//255 chars
function processMenuSelTopic(%clientId, %opt)
{
	%curItem = 0;
	%opt = getword(%opt,1);
	if(%opt == "gen") {
		Centerprint(%clientId, "<jc><f1>-There are <f2>no<f1> jumpjets here. You can only fly with a <f0>'Thopter<f1>(a vehicle), or a <f0>suspensor pack<f1>(available to some teams).\n-This mod is <f2>Team Based<f1>. That means you <f2>must<f1> cooperate and work with your teammates.", 15 );
	} else if(%opt == "tey") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Team energy<f1> is <f2>on<f1>. This means that whatever you buy, costs the team money. \n-<f2>Be conservitive<f1> in what you buy, and <f2>be aware<f1> of each item's cost. \n-If a teammate has a <f0>semi-automatic<f1>, you don't need one to.", 15 );

	} else if(%opt == "spt") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Spawn Time<f1> here is <f2>dynamic<f1>.\n-<f0>Killing yourself<f1>, <f0>hurting/killing teammates<f1>, and <f0>causing an atomic explosion<f1> will <f2>increase<f1> your spawn time.\n-Your <f0>spawn time<f1> goes <f2>down<f1> over time.", 15 );

	} else if(%opt == "shi") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Shields<f1> will stop <f2>all<f1> <f0>projectiles<f1>.\n-Firing a <f0>projectile<f1> from <f0>inside<f1> a <F2>shield<f1> will hurt!\n-Only <f0>slow moving<f1> objects, or <f0>large exposions<f1> can go through <f2>shields<f1>.", 15 );

	} else if(%opt == "mlc") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-Weapons under the <f0>melee<f1> section will <f2>all<f1> penetrate <f0>shields<f1>.\n-<f0>Melee weapons<f1> are <f0>short<f1> range only, but if <f0>thrown<f1>, can hurt!\n-Your grenade button will <f0>block<f1> melee attacks for 0.5 seconds.", 15 );

	} else if(%opt == "las") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Lasguns<f1> are <f2>expensive<f1> but deadly.\n-<f2>NEVER<f1> shoot <f0>lasguns<f1> at <f0>shields<f1>(includes pentashields).\n-All <f0>lasguns<f1> have a <f2>limited<f1> range. If you are outside this range, they do no damage to the target.", 15 );

	} else if(%opt == "pro") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Projectile guns<f1> are <f2>very expensive<f1> and almost useless.\n-Generally, they <f2>cannot<f1> penetrate <f0>shields<f1>, or armored items.\n-See the online guide for specialty functions of each <f0>projectile weapon<f1>.", 15 );

	} else if(%opt == "tms") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>DUNE<f1> has <f2>6<f1> different teams, each with its own setup of armor/weapons/items.\n-The teams are House Aterides, House Harkonnen, House Corrion, Ix, Bene Tlielaxu, and Minor Houses.\n-Houses are switched through voting, or by an admin.", 15 );

	} else if(%opt == "sws") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-<f0>Sand Worms<f1> are natural <f2>hazzards<f1> of Arrakis, and only appear on missions based there.\n-Worms eat <f2>anything<f1> they hear on the sand.\n-You can identify a worm by the moving dust plume, static discharges, and hissing sound.", 15 );

	} else if(%opt == "web") {
//					123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345
		Centerprint(%clientId, "<jc><f1>-The official website for <f0>DUNE<f1> Mod is located at <f2>http://www.jmods.bravepages.com<f1>.\n-There, you can <f2>read<f1> a more indepth <f0>strat guide<f1>, or <f2>post<f1> ideas on the <f0>forum<f1>.\n-Also home to the <f2>DAF Mod<f1>.", 15 );

	} else if(%opt == "nxt") {
	      Client::buildMenu(%clientId, "Select Topic:", "selTopic", true);
	      Client::addMenuItem(%clientId, %curItem++@"Teams", %curItem@" tms");
	      Client::addMenuItem(%clientId, %curItem++@"Sand Worms", %curItem@" sws");
	      Client::addMenuItem(%clientId, %curItem++@"Web Page/Online info", %curItem@" web");
//	      Client::addMenuItem(%clientId, %curItem++@"More...", %curItem@" nxt2");
	}

}

function processMenuKillAffirm(%clientId, %opt)
{
	if(getword(%opt, 0) == "yes"){
		%cl = getword(%opt, 1);
		if(%cl.issuperadmin != true) {
      			Player::blowUp(%cl);
			client::Getcontrolobject(%cl).blowup = true;
      			remoteKill(%cl);
			Echo(%clientId @ " just remotely killed " @ %cl);
      			Client::sendMessage(%cl, 0, "Try not to piss off the admins next time.");
      			messageAll(0, Client::getName(%cl) @ " was assasinated by " @Client::getName(%clientID)@ " on Shiatan's command.");
      			Game::menuRequest(%clientId);
      		} else {
			Echo(%clientId @ " just attempted to remotely kill " @ %cl);
      			Client::sendMessage(%cl, 0, Client::getName(%clientID) @ " (" @ %clientID @ ") " @ "just attempted to remotely kill you.");
			client::sendmessage(%clientID, 0, "You cannot kill a superadmin fool.");
     		}
	}
	else
		Client::sendMessage(%clientId, 0, "Wuss!");
      		Game::menuRequest(%clientId);

}

function processMenuGMAffirm(%clientId, %opt)
{
	if(getword(%opt, 0) == "yes"){
		%cl = getword(%opt, 1);
		if(%cl.issuperadmin != true){
      			Echo(%clientId @ " just Globaly muted " @ %cl);
      			Client::sendMessage(%cl, 0, "What was that again?");
			%cl.notalk = true;
      			Game::menuRequest(%clientId);
      		} else {
			Echo(%clientId @ " just attempted to globaly mute " @ %cl);
      			Client::sendMessage(%cl, 0, Client::getName(%clientID) @ " (" @ %clientID @ ") " @ "just attempted to globaly mute you.");
			client::sendmessage(%clientID, 0, "You cannot make a superadmin shut up you fool.");
     		}
	}
	else
		Client::sendMessage(%clientId, 0, "Wuss!");
      		Game::menuRequest(%clientId);



}

function processMenuGUMAffirm(%clientId, %opt)
{
	if(getword(%opt, 0) == "yes"){
		%cl = getword(%opt, 1);
		Echo(%clientId @ " just Globaly UNmuted " @ %cl);
      		Client::sendMessage(%cl, 0, "You spam, you die.");
		%cl.notalk = false;
      		Game::menuRequest(%clientId);
      		
	}
	else
		Client::sendMessage(%clientId, 0, "Thats a good lad!");
      		Game::menuRequest(%clientId);



}
function processMenuGholaSubject(%clientId, %option)
{
	if($LastPlayerDied[1] != "" && %option == 1) {
		%clientId.gholapickarmor = $LastArmorDied[1];
		%clientId.gholapickname = $LastPlayerDied[1];
		%clientId.gholapickteam = $LastteamDied[1];

    	} else if($LastPlayerDied[2] != "" && %option == 2) {
		%clientId.gholapickarmor = $LastArmorDied[2];
		%clientId.gholapickname = $LastPlayerDied[2];
		%clientId.gholapickteam = $LastteamDied[2];

	} else if($LastPlayerDied[3] != "" && %option == 3) {
		%clientId.gholapickarmor = $LastArmorDied[3];
		%clientId.gholapickname = $LastPlayerDied[3];
		%clientId.gholapickteam = $LastteamDied[3];

	} else if($LastPlayerDied[4] != "" && %option == 4) {
		%clientId.gholapickarmor = $LastArmorDied[4];
		%clientId.gholapickname = $LastPlayerDied[4];
		%clientId.gholapickteam = $LastteamDied[4];

	} else if($LastPlayerDied[5] != "" && %option == 5) {
		%clientId.gholapickarmor = $LastArmorDied[5];
		%clientId.gholapickname = $LastPlayerDied[5];
		%clientId.gholapickteam = $LastteamDied[5];

	} else {
		%clientId.gholapickarmor = "";
		%clientId.gholapickname = "";
		%clientId.gholapickteam = "";
		Echo("(admin setting)Invalid Ghola Subject Picked");
	}
	
}

function processMenuKAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}


function processMenuWSize(%clientId, %opt)
{
  if(getWord(%opt, 0) == "small")
   	SandWormS::AdminAttack( getWord(%opt, 1));   
   else if( getWord(%opt, 0) == "medium" )
	SandWormM::AdminAttack( getWord(%opt, 1));
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
      }
   }
   Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
   remoteSetTimeLimit(%clientId, %opt);
}


function getnumteamplayers(%team)
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
	return %numTeamPlayers[%team];
}