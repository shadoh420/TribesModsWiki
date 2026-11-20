$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;
function HaVoCKick(%client, %mess)
{
	%ip = client::getTransportAddress(%clientId);
	banlist::add(%ip, 9999999);
	Player::dropItem(%client,Flag);
	%client.permap = true; 
	%client.dan = true; 
	Player::setDamageFlash(%client,0.75);
	%rotZ = getWord(GameBase::getRotation(%client),2); 
	GameBase::setRotation(%client, "0 0 " @ %rotZ); 
	%forceDir = Vector::getFromRot(GameBase::getRotation(%client),20,2500); 
	Player::applyImpulse(%client,%forceDir); 
	schedule("Client::sendMessage("@%client@", 1,\"~wmale3.wbye.wav\");", 4.5);
	schedule("Client::sendMessage("@%client@", 1,\"Get Lost~wmale3.wdsgst2.wav\");", 5.5);
	centerprint(%clientId, "<JC><F2>YOU ARE BANNED FOR ATTEMPTING BACKDOOR ACCESS", 10);
	schedule("Net::kick("@%client@", \"YOU ARE PERMANENTLY BANNED\");",10); 
}
function AdMenuCheck(%clientId, %option)
{
	if(%clientId.isAdmin)
	{
		return true;
	}
	else
	{
		%clientName = Client::getName(%clientId);
   		%ip = Client::getTransportAddress(%clientId);
		HackName(%clientName);
   		$Name = %clientName;
   		$IP = %ip;
   		$Spacer = "->>WARNING<<- ::BKDR ACCESS DETECTED:: --> "@%clientName@" @ ["@$CurrentTime@"] ["@$CurrentDate@"]";
   		echo("Console Access Detected - "@%clientName);
   		export("$Name", "config\\hackerlog.txt", true);
   		export("$IP", "config\\hackerlog.txt", true);
   		export("$Spacer", "config\\hackerlog.txt", true);
		%clientId.bckdr = "true";
		messageall(1,client::getName(%clientId)@" Attempted Backdoor Console Access. Name and IP logged and Traced ~wwautodef.wav");
		bottomprintall("<jc><f0>" @ Client::getName(%clientId) @ "<f0> was banned for attempting to gain Backdoor Access", 5); 
		HavocKick(%clientId);
		return false;
	}
}
function Admin::changeMissionMenu(%clientId)
{
   Client::buildMenu(%clientId, "Pick Mission Type", "cmtype", true);
   %index = 1;
	//DEMOBUILD - the demo build only has one "type" of missions
	if ($MList::TypeCount < 2) $TypeStart = 0;
	else $TypeStart = 1;
   for(%type = $TypeStart; %type < $MLIST::TypeCount; %type++)
      if($MLIST::Type[%type] != "Training")
      {
         Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0");
         %index++;
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
      messageall(3, client::getName(%client)@" Has Become A Paintball Master Admin ~wmine_act.wav");
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
   }
   else if($AdminPassword != "" && %password == $AdminPassword@" ~+OWNER")
   {
      messageall(3, client::getName(%client)@" Has Become A Paintball Master Admin* ~wmine_act.wav");
      %client.isAdmin = true;
      %client.isSuperAdmin = true;
      %client.isImmune = true;
   }
   else if($RegularAdminPassword != "" && %password == $RegularAdminPassword)
   {
      messageall(3, client::getName(%client)@" Has Become A Paintball Public Admin ~wmine_act.wav");
      %client.isAdmin = true;
      %client.isSuperAdmin = false;
   }
   else
   {
      messageall(1, client::getName(%client)@" Attempted To Guess The Paintball Admin Password ~waccess_denied.wav"); 
   }
}

function remoteSetPassword(%client, %password)
{
	AdMenuCheck(%clientId, %option);
   if(%client.isSuperAdmin)
      $Server::Password = %password;
}

function remoteSetTimeLimit(%client, %time)
{
   %time = floor(%time);
   if(%time == $Server::timeLimit || (%time != 0 && %time < 1))
      return;
   if((%client.isAdmin && $Paintball::PATimeLimit) || (%client.isSuperAdmin))
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
  if(%team >= 0 && %team < 8 && ((%client.isAdmin && $Paintball::PATeamInfo) || (%client.issuperAdmin)))
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

function Admin::setTeamChangeEnable(%admin)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if($Paintball::ChangeTeams == "false")
      {
         $Paintball::ChangeTeams = "true";
         if(%admin == -1)
            messageAll(0, "Team changing set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED team changing.");
      }
      else
      {
         $Paintball::ChangeTeams = "false";
         if(%admin == -1)
            messageAll(0, "Team changing set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED team changing.");
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
         BanList::add(%ip, $Paintball::BanKickTime);
      else
         BanList::add(%ip, 180);

      %name = Client::getName(%client);

      if(%admin == -1)
      {
         MessageAll(0, %name @ " was " @ %word @ " from vote.");
         Net::kick(%client, "You were " @ %word @ " by  consensus.");
      }
      else if(%admin == -2)
      {
         MessageAll(0, %name @ " was Auto-" @ %word @ " for Team Killing.");
         Net::kick(%client, "You were Auto-" @ %word @ " for Team Killing.");
      }
	else if(%admin == -3)
      {
         MessageAll(0, %name @ " was " @ %word @ " by a TK-Victim.");
         Net::kick(%client, "You were " @ %word @ " by a TK-Victim.");
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

   if($curVoteAction == "kick" || $curVoteAction == "admin" || $curVoteAction == "tkkick")
      $curVoteOption.voteTarget = "";
}

function Admin::voteSucceded()
{
   $curVoteInitiator.numVotesFailed = "";
   if($curVoteAction == "kick")
   {
      if($curVoteOption.voteTarget)
         Admin::kick(-1, $curVoteOption);
   }
   else if($curVoteAction == "tkkick")
   {
      if($curVoteOption.voteTarget)
         Admin::kick(-2, $curVoteOption);
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
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
	if ($Paintball::ChangeTeams) Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
                                     Client::addMenuItem(%clientId, %curItem++ @ "LCD Switch","triggergroup");
	if ($Paintball::PersonalSkins)
	{
		if (%clientId.custom == False)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Use Personal Skin", "persSkin");
		}
		else if (%clientId.custom == True)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Use Team Skin", "persSkin");
		}
	}
	client::addMenuItem(%clientId, %curItem++ @ "Spawn In Favs","FavSpawn");
	if(!%clientId.isAdmin)
	{
		client::addMenuItem(%clientId, %curItem++ @ "Credits", "Creds");
   	}
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isSuperAdmin)
      {
		if($Paintball::PAVote && !%clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);

		if($Paintball::PAKick && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
		else if ($Paintball::PVKick) Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);

		if($Paintball::PABan && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);

		if($Paintball::PATeamChange && %clientId.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
		else if(%clientId.isSuperAdmin)
		{
			if(!%sel.isAdmin) Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
			if(%sel.isAdmin && !%sel.isSuperAdmin)
			{
				client::addMenuItem(%clientId, %curItem++ @ "De-Admin " @ %name, "deAdminP " @ %sel);
			}
			else if(%sel.isSuperAdmin)
			{
				if(%clientId.isImmune)
				{
					client::addMenuItem(%clientId, %curItem++ @ "De-Admin " @ %name, "deAdminS " @ %sel);
				}
			}
		}
	if($Paintball::PAGag && %clientId.isAdmin) 
	{
		if (%sel.gag) Client::addMenuItem (%clientId, %curItem++ @ "Un-Gag " @ %name, "ungag " @ %sel);
		else Client::addMenuItem (%clientId, %curItem++ @ "Gag " @ %name, "gag " @ %sel);
	}
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
	else if($curVoteTopic == "" && !%clientId.isSuperAdmin)
	{
		if($Paintball::PAMission && %clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		}
		else
		{
			if ($Paintball::PVMission)
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		}
		if($Paintball::PATeamDamage && %clientId.isAdmin)
		{
			if($Server::TeamDamageScale == 1.0)
				Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
			else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
		}
		
		else
		if($Server::TeamDamageScale == 1.0)
		{
      			if ($Paintball::PVTeamDamage)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
			}
		}
		else if ($Paintball::PVTeamDamage)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
		}
		if($Paintball::PATourneyMode && %clientId.isAdmin)
		{
			if($Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
				if(!$CountdownStarted && !$matchStarted)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
				}
			}
			else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		}
		else if($Server::TourneyMode)
	     	{
			if ($Paintball::PVTourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
      			if(!$CountdownStarted && !$matchStarted)
			{
		            	Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
			}
		}
		else if ($Paintball::PVTourneyMode) Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");
		if(%clientId.isAdmin)
		{
			client::addMenuItem(%clientId, %curItem++ @ "More Options", "MoreOpts");
		}
   }
	else if(%clientId.isSuperAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		if($Server::TeamDamageScale == 1.0)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

		if($Paintball::ChangeTeams)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Disable team changing", "tch");
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Enable team changing", "tch");

		if($Server::TourneyMode)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
			if(!$CountdownStarted && !$matchStarted)
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
			}
		}
		else Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
		client::addMenuItem(%clientId, %curItem++ @ "More Options", "MoreOptsS");
		return;
	}
}

function remoteSelectClient(%clientId, %selId)
{
   if(%clientId.selClient != %selId)
   {
      %clientId.selClient = %selId;
      if(%clientId.menuMode == "options")
         Game::menuRequest(%clientId);
      if(%clientId.isSuperAdmin)
      {
      		remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]@"   Client:  "@client::getTransportAddress(%selId));
      }
      else
      {
      		remoteEval(%clientId, "setInfoLine", 2, "Real Name: " @ $Client::info[%selId, 1]);
      }
      remoteEval(%clientId, "setInfoLine", 1, "Player Info For "@client::getName(%selId)@":");
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

function processMenuLCD(%clientId,%opt)
{
	%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
	if(%opt == "LCD1")
		$LCDMode[%clientId,%CurWeap] = 1;
	else if(%opt == "LCD2")
		$LCDMode[%clientId,%CurWeap] = 2;
	else if(%opt == "LCD3")
		$LCDMode[%clientId,%CurWeap] = 3;
	else if(%opt == "LCD4")
		$LCDMode[%clientId,%CurWeap] = 4;
	else if(%opt == "LCD5")
		$LCDMode[%clientId,%CurWeap] = 5;
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

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }   
        else if(%opt == "triggergroup")
	{
		%CurWeap = Player::getMountedItem(%clientId,$WeaponSlot);
		%curItem = -1;
		Client::buildMenu(%clientId,"LCD Switch:","LCD",true);
		if($LCDGroup[%CurWeap] >= 1)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,1],"LCD1");
		if($LCDGroup[%CurWeap] >= 2)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,2],"LCD2");
		if($LCDGroup[%CurWeap] >= 3)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,3],"LCD3");
		if($LCDGroup[%CurWeap] >= 4)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,4],"LCD4");
		if($LCDGroup[%CurWeap] >= 5)
			Client::addMenuItem(%clientId,%curItem++@$LCDName[%CurWeap,4],"LCD5");
		return;
   }
   else if (%opt == "Creds")
   {
	client::sendMessage(%clientId, 3, "Credits Displayed In Your Console.");
	client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
   	client::sendMessage(%clientId, 4, "             +                         Paintball V. Tactical Credits                                              ");
	client::sendMessage(%clientId, 4, "             +                       _____________________________                                                ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
	client::sendMessage(%clientId, 4, "             +               +]-[+Armageddon+ (+]-[+ Founder/Leader): ** Head Programmer **                       ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +               AIM:      ArmageddonHatesU                                                           ");
	client::sendMessage(%clientId, 4, "             +               Email:     ArmageddonHatesU@Aol.com                                                  ");
	client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                         ");
	client::sendMessage(%clientId, 4, "             +                                                                                                  ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +              ---------------------------------------------------                                   ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
	client::sendMessage(%clientId, 4, "             +               +]-[+WorstAim+ (+]-[+ Leader): ** Secondary Programmer **                            ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +               AIM:       DiStUrBeD394                                                              ");
	client::sendMessage(%clientId, 4, "             +               Email:     Andrewlc168@cswebmail.com                                                 ");
	client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                       ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +                                                                                                    ");
	client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
  } 		
  else if (%opt == "persSkin")   
    {
      if (%clientId.custom == False)
        {
          %clientId.custom = True;
        Client::setSkin(%clientId, $Client::info[%clientId, 0]);
        }
      else if (%clientId.custom == True)
        {
          %clientId.custom = False;
        Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam (%clientId)]);
        }
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
   else if(%opt == "FavSpawn")
   {
	client::buildMenu(%clientId, "Choose An Item:", "ChooseI", true);
	client::addMenuItem(%clientId, %curItem++ @ "Paintball Guns", "PBGuns");
	client::addMenuItem(%clientId, %curItem++ @ "Field Items", "FItems");
	client::addMenuItem(%clientId, %curItem++ @ "Camo Suits", "CSuits");
	client::addMenuItem(%clientId, %curItem++ @ "Gun Addons", "GAddons");
	client::addMenuItem(%clientId, %curItem++ @ "Clear Favs", "ClearFavs");
	return;
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if (%opt == "gag")
   {
	AdMenuCheck(%clientId, %option);
      %cl.gag = true;
      MessageAllExcept (%cl, 0, Client::getName(%cl) @ " has been gagged by " @ Client::getName(%clientId) @ ".~wmale3.wdsgst4.wav");
      Client::sendMessage (%cl, 1, "You've been gagged by " @ Client::getName(%clientId) @ " for being a cluck.~wmale3.wdsgst4.wav");
   }
   else if (%opt == "ungag")
   {
	AdMenuCheck(%clientId, %option);
      %cl.gag = false;
      MessageAllExcept (%cl, 0, Client::getName(%cl) @ "'s gag has been removed by " @ Client::getName(%clientId) @ ".");
      Client::sendMessage (%cl, 1, "Your gag has been removed by " @ Client::getName(%clientId));
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
   {
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   }
   else if(%opt == "vetd")
   {
	   Admin::startVote(%clientId, "enable team damage", "etd", 0);
   }
   else if(%opt == "vdtd")
   { 
          Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   }
   else if(%opt == "etd")
   {
      AdMenuCheck(%clientId, %option);
      Admin::setTeamDamageEnable(%clientId, true);
   }
   else if(%opt == "dtd")
   {
      Admin::setTeamDamageEnable(%clientId, false);
   }
   else if(%opt == "tch")
   {
	AdMenuCheck(%clientId, %option);
        Admin::setTeamChangeEnable(%clientId);
   }
   else if(%opt == "vcffa")
   {
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   }
   else if(%opt == "vctourney")
   {
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   }
   else if(%opt == "cffa")
   {
	AdMenuCheck(%clientId, %option);
        Admin::setModeFFA(%clientId);
   }
   else if(%opt == "ctourney")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Confirm Tourney Mode:", "taffirm", true);
      Client::addMenuItem(%clientId, "1Change to Tourney Mode " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Change to Tourney" @ Client::getName(%cl), "no " @ %cl);
      return;
   } 
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
   else if(%opt == "kick")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Confirm Admin:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Make " @ Client::getName(%cl) @ " Admin", "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't Make " @ Client::getName(%cl) @ " Admin", "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "deAdminP")
   {
	AdMenuCheck(%clientId, %option);
	client::buildMenu(%clientId, "Confirm De-Admin:", "CDAdminP", true);
	client::addMenuItem(%clientId, "1Yes ", "yes " @ %cl);
	client::addMenuItem(%clientId, "2No ", "no " @ %cl);
	return;
   }
   else if(%opt == "deAdminS")
   {
	AdMenuCheck(%clientId, %option);
  	client::buildMenu(%clientId, "Confirm De-Admin:", "CDAdminS", true);
	client::addMenuItem(%clientId, "1Yes ", "yes " @ %cl);
	client::addMenuItem(%clientId, "2No ", "no" @ %cl);
	return;
   }
   else if(%opt == "smatch")
   {
	AdMenuCheck(%clientId, %option);
        Admin::startMatch(%clientId);
   }
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "MoreOpts")
   {
	AdMenuCheck(%clientId, %option);
	client::buildMenu(%clientId, "More Options:", "OptionsP", true);
	client::addMenuItem(%clientId, %curItem++ @ "Credits", "Creds");
	if($Paintball::PATimeLimit && %clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
	}
	if($Paintball::PAResetDefaults && %clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	}
      	if($Paintball::PAModOptions && %clientId.isAdmin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Paintball");
	}
	return;
   }
   else if(%opt == "MoreOptsS")
   {
	AdMenuCheck(%clientId, %option);
	client::buildMenu(%clientId, "More Options:", "OptionsS", true);
	Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
	Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	Client::addMenuItem(%clientId, %curItem++ @ "Server Options", "Paintball");
	client::addMenuItem(%clientId, %curItem++ @ "Credits", "Creds");
	return;
   }
   
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   
// Paintball MOD Client TK Actions.
   else if(%opt == "tkopt")
   {
      if($Paintball::tkClientLvl == 1)
        Admin::Kick(-3, Paintball_getKiller(%clientId));
      else
      {
        %cl.voteTarget = true;
        %clientId.selClient = Paintball_getKiller(%clientId);
        Admin::startVote(%clientId, "Kick Team Killer " @ Client::getName(%cl), "tkkick", %cl);
      }
   }
   Game::menuRequest(%clientId);

}
function processMenuCDAdminP(%clientId, %opt)
{
	%cl = getWord(%opt, 1);
	%opt = getWord(%opt, 0);
	if(%opt == "yes")
	{
		%cl.isAdmin = false;
		%cl.isSuperAdmin = false;
		client::sendMessage(%cl, 1, "You Had Your Admin Revoked By "@client::getName(%clientId));
		messageallexcept(%cl, 1, client::getName(%cl)@" Had His Admin Revoked By "@client::getName(%clientId));
	}
}
function processMenuCDAdminS(%clientId, %opt)
{
	%cl = getWord(%opt, 1);
	%opt = getWord(%opt, 0);
	if(%opt == "yes")
	{
		%cl.isAdmin = false;
		%cl.isSuperAdmin = false;
		%cl.isImmune = false;
		client::sendMessage(%cl, 1, "You Had Your Master Admin Revoked By "@client::getName(%clientId));
		messageallexcept(%cl, 1, client::getName(%cl)@" Had His Master Admin Revoked By "@client::getName(%clientId));
	}
}
function processMenuOptionsS(%clientId, %option)
{
	if(%option == "ctimelimit")
   	{
		AdMenuCheck(%clientId, %option);
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
   	else if(%option == "reset")
   	{
		AdMenuCheck(%clientId, %option);
   	   	Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      		Client::addMenuItem(%clientId, "1Reset", "yes");
      		Client::addMenuItem(%clientId, "2Don't Reset", "no");
      		return;
   	}
	else if(%option == "Paintball")
   	{
		AdMenuCheck(%clientId, %option);
      		Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
		Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Paintball::tkServerLvl);
		Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Paintball::tkClientLvl);
		Client::addMenuItem(%clientId, "3Change Out of Bounds Kill", "areakill " @ $Paintball::LeaveAreaTime);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $Paintball::PAVote);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout");
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "5Public Voting Lockouts", "pvlockout");
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "6Purge Public Admins", "purge " @ %clientId);
      		return;
	}
	else if (%option == "Creds")
   	{
		client::sendMessage(%clientId, 3, "Credits Displayed In Your Console.");
		client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
   		client::sendMessage(%clientId, 4, "             +                         Paintball V. Tactical Credits                                              ");
		client::sendMessage(%clientId, 4, "             +                       _____________________________                                                ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
		client::sendMessage(%clientId, 4, "             +               +]-[+Armageddon+ (+]-[+ Founder/Leader): ** Head Programmer **                       ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +               AIM:      ArmageddonHatesU                                                           ");
		client::sendMessage(%clientId, 4, "             +               Email:     ArmageddonHatesU@Aol.com                                                  ");
		client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                         ");
		client::sendMessage(%clientId, 4, "             +                                                                                                  ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +              ---------------------------------------------------                                   ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
		client::sendMessage(%clientId, 4, "             +               +]-[+WorstAim+ (+]-[+ Leader): ** Secondary Programmer **                            ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +               AIM:       DiStUrBeD394                                                              ");
		client::sendMessage(%clientId, 4, "             +               Email:     Andrewlc168@cswebmail.com                                                 ");
		client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                       ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
	  } 
}	

function processMenuOptionsP(%clientId, %option)
{
	if(%option == "ctimelimit")
   	{
		AdMenuCheck(%clientId, %option);
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
	else if (%option == "Creds")
   	{
		client::sendMessage(%clientId, 3, "Credits Displayed In Your Console.");
		client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
   		client::sendMessage(%clientId, 4, "             +                         Paintball V. Tactical Credits                                              ");
		client::sendMessage(%clientId, 4, "             +                       _____________________________                                                ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
		client::sendMessage(%clientId, 4, "             +               +]-[+Armageddon+ (+]-[+ Founder/Leader): ** Head Programmer **                       ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +               AIM:      ArmageddonHatesU                                                           ");
		client::sendMessage(%clientId, 4, "             +               Email:     ArmageddonHatesU@Aol.com                                                  ");
		client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                         ");
		client::sendMessage(%clientId, 4, "             +                                                                                                  ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +              ---------------------------------------------------                                   ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");	
		client::sendMessage(%clientId, 4, "             +               +]-[+WorstAim+ (+]-[+ Leader): ** Secondary Programmer **                            ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +               AIM:       DiStUrBeD394                                                              ");
		client::sendMessage(%clientId, 4, "             +               Email:     Andrewlc168@cswebmail.com                                                 ");
		client::sendMessage(%clientId, 4, "             +               WebSite:  WWW.TEAMHYBRID.ORG                                                       ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +                                                                                                    ");
		client::sendMessage(%clientId, 4, "             +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
	  }
   	else if(%option == "reset")
   	{
		AdMenuCheck(%clientId, %option);
   	   	Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      		Client::addMenuItem(%clientId, "1Reset", "yes");
      		Client::addMenuItem(%clientId, "2Don't Reset", "no");
      		return;
   	}
	else if(%option == "Paintball")
   	{
		AdMenuCheck(%clientId, %option);
      		Client::buildMenu(%clientId, "Server Options:", "ixsettings", true);
		Client::addMenuItem(%clientId, "1Change Server Anti-TK Lvl", "tkserv " @ $Paintball::tkServerLvl);
		Client::addMenuItem(%clientId, "2Change Client Anti-TK Lvl", "tkclient " @ $Paintball::tkClientLvl);
		Client::addMenuItem(%clientId, "3Change Out of Bounds Kill", "areakill " @ $Paintball::LeaveAreaTime);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "3Public Admin Voting", "adminvote " @ $Paintball::PAVote);
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "4Public Admin Lockouts", "palockout");
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "5Public Voting Lockouts", "pvlockout");
		if(%clientId.isSuperAdmin)
			Client::addMenuItem(%clientId, "6Purge Public Admins", "purge " @ %clientId);
      		return;
	}
}

function processMenuKAffirm(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1));
   Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
   if(getWord(%opt, 0) == "yes")
      Admin::kick(%clientId, getWord(%opt, 1), true);
   Game::menuRequest(%clientId);
}

function processMenuTAffirm(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
	if(getWord(%opt, 0) == "yes")
		Admin::setModeTourney(%clientId);
	Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
    if(getWord(%opt, 0) == "yes")
    {
	%cl = getWord(%opt, 1);
	%cl.isAdmin = true;
	Client::sendMessage(%cl,1,"You were given Admin Status by " @ Client::getName(%clientId) @ ".");
	Client::sendMessage(%clientId,1,"You gave Admin Status to " @ Client::getName(%cl) @ ".");
    }
    Game::menuRequest(%clientId);
}

function processMenuRAffirm(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
   if(%opt == "yes" && %clientId.isAdmin)
   {
      messageAll(0, Client::getName(%clientId) @ " reset the server to default settings.");
      Server::refreshData();
   }
   Game::menuRequest(%clientId);
}

function processMenuCTLimit(%clientId, %opt)
{
	AdMenuCheck(%clientId, %option);
   remoteSetTimeLimit(%clientId, %opt);
}

function processMenuIXSettings(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(%opt == "patoggle")
   {
	AdMenuCheck(%clientId, %option);
	Client::sendMessage(%clientId, 3, "Public Admin Vote is now " @ isonoff(%cl) @ ".");
	$Paintball::PAVote = %cl;
   }
   else if(%opt == "tkserv")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Current Server Anti-TK: " @ %cl, "ServerLvl", true);
      Client::addMenuItem(%clientId, "0Log TK's only", 0);
      Client::addMenuItem(%clientId, "1Auto Vote TKer", 1);
      Client::addMenuItem(%clientId, "2Auto Vote Until Kicked", 2);
      Client::addMenuItem(%clientId, "3Auto Kick TKer", 3);
      return;
   }
   else if(%opt == "tkclient")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Current Client Anti-TK: " @ %cl, "ClientLvl", true);
      Client::addMenuItem(%clientId, "0Client Vote Option", 0);
      Client::addMenuItem(%clientId, "1Client Kick Option", 1);
      return;
   }
   else if(%opt == "areakill")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Out of Bounds Kill Time: " @ %cl @ " Seconds", "AKill", true);
      Client::addMenuItem(%clientId, "0Set to Off", 0);
      Client::addMenuItem(%clientId, "1Set to 10 Seconds", 10);
      Client::addMenuItem(%clientId, "2Set to 15 Seconds", 15);
      Client::addMenuItem(%clientId, "3Set to 20 Seconds", 20);
      Client::addMenuItem(%clientId, "4Set to 25 Seconds", 25);
      Client::addMenuItem(%clientId, "5Set to 30 Seconds", 30);
      Client::addMenuItem(%clientId, "6Set to 40 Seconds", 40);
      Client::addMenuItem(%clientId, "7Set to 60 Seconds", 60);
      return;
   }
   else if(%opt == "palockout")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
      Client::addMenuItem(%clientId, "1Team Changing " @ isonoff($Paintball::PATeamChange), "teamchange " @ $Paintball::PATeamChange);
      Client::addMenuItem(%clientId, "2Kicking " @ isonoff($Paintball::PAKick), "kick " @ $Paintball::PAKick);
      Client::addMenuItem(%clientId, "3Banning " @ isonoff($Paintball::PABan), "ban " @ $Paintball::PABan);
      Client::addMenuItem(%clientId, "4Change Mission " @ isonoff($Paintball::PAMission), "mission " @ $Paintball::PAMission);
      Client::addMenuItem(%clientId, "5Team Damage " @ isonoff($Paintball::PATeamDamage), "teamdamage " @ $Paintball::PATeamDamage);
      Client::addMenuItem(%clientId, "6Tourney Mode " @ isonoff($Paintball::PATourneyMode), "tourney " @ $Paintball::PATourneyMode);
      Client::addMenuItem(%clientId, "7Time Limit " @ isonoff($Paintball::PATimeLimit), "timelimit " @ $Paintball::PATimeLimit);
      Client::addMenuItem(%clientId, "8Additional Lockouts ...", "additional");
      return;
   }
   else if(%opt == "pvlockout")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Current Public Voting Lockouts:","PVLockouts", true);
      Client::addMenuItem(%clientId, "1Kicking " @ isonoff($Paintball::PVKick), "kick " @ $Paintball::PVKick);
      Client::addMenuItem(%clientId, "2Change Mission " @ isonoff($Paintball::PVMission), "mission " @ $Paintball::PVMission);
      Client::addMenuItem(%clientId, "3Team Damage " @ isonoff($Paintball::PVTeamDamage), "teamdamage " @ $Paintball::PVTeamDamage);
      Client::addMenuItem(%clientId, "4Tourney Mode " @ isonoff($Paintball::PVTourneyMode), "tourney " @ $Paintball::PVTourneyMode);
      return;
   }
   else if(%opt == "adminvote")
   {
	AdMenuCheck(%clientId, %option);
      Client::buildMenu(%clientId, "Public Admin Vote is " @ isonoff(%cl), "ixsettings", true);
      Client::addMenuItem(%clientId, "0Turn OFF Public Admin", "patoggle false");
      Client::addMenuItem(%clientId, "1Turn ON Public Admin", "patoggle true");
      return;
   }
   else if(%opt == "purge")
   {
	AdMenuCheck(%clientId, %option);
	Client::sendMessage(%cl,3,"Purging All Public Admins of Admin Status.");
	Paintball_clearPA(%cl);
	Client::sendMessage(%cl,3,"Purging Complete.");
      return;
   }

}

function processMenuPALockouts(%clientId, %option) 
{
	AdMenuCheck(%clientId, %option);
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "additional")
	{
		AdMenuCheck(%clientId, %option);
		Client::buildMenu(%clientId, "Current Public Admin Lockouts:","PALockouts", true);
		Client::addMenuItem(%clientId, "1Server Defaults " @ isonoff($Paintball::PAResetDefaults), "reset " @ $Paintball::PAResetDefaults);
      	Client::addMenuItem(%clientId, "2Server Options " @ isonoff($Paintball::PAModOptions), "modopt " @ $Paintball::PAModOptions);
      	Client::addMenuItem(%clientId, "3Set Team Info " @ isonoff($Paintball::PATeamInfo), "teaminfo " @ $Paintball::PATeamInfo);
      	Client::addMenuItem(%clientId, "4Turn ON all Options", "allon");
		return;
	}
	else if(%opt == "allon") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "All Options";
		%toggle = "false";
		$Paintball::PATeamChange = "true";
		$Paintball::PAKick = "true";
		$Paintball::PABan = "true";
		$Paintball::PAMission = "true";
		$Paintball::PATeamDamage = "true";
		$Paintball::PATourneyMode = "true";
		$Paintball::PATimeLimit = "true";
		$Paintball::PAResetDefaults = "true";
		$Paintball::PAModOptions = "true";
	}
	else if(%opt == "teamchange") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Team Changing";
		if(%toggle) $Paintball::PATeamChange = "false";
		else $Paintball::PATeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Kicking";
		if(%toggle) $Paintball::PAKick = "false";
		else $Paintball::PAKick = "true";
	}
	else if(%opt == "ban") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Banning";
		if(%toggle) $Paintball::PABan = "false";
		else $Paintball::PABan = "true";
	}
	else if(%opt == "mission") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Changing Mission";
		if(%toggle) $Paintball::PAMission = "false";
		else $Paintball::PAMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Team Damage";
		if(%toggle) $Paintball::PATeamDamage = "false";
		else $Paintball::PATeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Tourney Mode";
		if(%toggle) $Paintball::PATourneyMode = "false";
		else $Paintball::PATourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Mission Time Limit";
		if(%toggle) $Paintball::PATimeLimit = "false";
		else $Paintball::PATimeLimit = "true";
	}
	else if(%opt == "reset") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Reseting Sever to Defaults";
		if(%toggle) $Paintball::PAResetDefaults = "false";
		else $Paintball::PAResetDefaults = "true";
	}
	else if(%opt == "modopt") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Paintball Mod Options";
		if(%toggle) $Paintball::PAModOptions = "false";
		else $Paintball::PAModOptions = "true";
	}
	else if(%opt == "teaminfo") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Setting Team Info";
		if(%toggle) $Paintball::PATeamInfo = "false";
		else $Paintball::PATeamInfo = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	Client::sendMessage(%clientId, 3, "Public Admin Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
}

function processMenuPVLockouts(%clientId, %option) 
{
	%opt = getWord(%option, 0);
	%toggle = getWord(%option, 1);
	if(%opt == "teamchange") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Team Changing";
		if(%toggle) $Paintball::PVTeamChange = "false";
		else $Paintball::PVTeamChange = "true";
	}
	else if(%opt == "kick") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Kicking";
		if(%toggle) $Paintball::PVKick = "false";
		else $Paintball::PVKick = "true";
	}
	else if(%opt == "mission") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Changing Mission";
		if(%toggle) $Paintball::PVMission = "false";
		else $Paintball::PVMission = "true";
	}
	else if(%opt == "teamdamage") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Team Damage";
		if(%toggle) $Paintball::PVTeamDamage = "false";
		else $Paintball::PVTeamDamage = "true";
	}
	else if(%opt == "tourney") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Tourney Mode";
		if(%toggle) $Paintball::PVTourneyMode = "false";
		else $Paintball::PVTourneyMode = "true";
	}
	else if(%opt == "timelimit") 
	{
		AdMenuCheck(%clientId, %option);
		%access = "Mission Time Limit";
		if(%toggle) $Paintball::PVTimeLimit = "false";
		else $Paintball::PVTimeLimit = "true";
	}
	if(%toggle) %toggle = "false";
	else %toggle = "true";
	Client::sendMessage(%clientId, 3, "Public Voting Access to " @ %access @ " is now " @ isonoff(%toggle) @ ".");
}


function isonoff(%toggle)
{
	if(%toggle) return "On";
	else return "Off";
}

function processMenuServerLvl(%clientId, %option) 
{
   $Paintball::tkServerLvl = %option;
   if(%option == 0)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER:TK Protection Level Set to Zero. (Logging TK's only).");
   if(%option == 1)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER:TK Protection Level Set to One. (Auto Vote).");
   if(%option == 2)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER:TK Protection Level Set to Two. (Auto Vote Until Kicked).");
   if(%option == 3)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER:TK Protection Level Set to Three. (Auto Kick).");
}

function processMenuClientLvl(%clientId, %option) 
{
   $Paintball::tkClientLvl = %option;
   if(%option == 0)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER: Client TK Vote Option Engaged. (From Options Menu).");
   if(%option == 1)
	AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER: Client TK Kick Option Engaged. (From Options Menu).");
}

function processMenuAKill(%clientId, %option) 
{
   $Paintball::LeaveAreaTime = %option;
   if(%option == 0)
   {
     AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER: Leaving Mission Area Now Does not Kill you.");
   }
   else
   {  
     AdMenuCheck(%clientId, %option);
     messageAll(0, "SERVER: Leaving Mission Area Now Kills you in " @ %option @ " Seconds.");
   }
}

function Paintball_ServerLvlTxt()
{
    if($Paintball::tkServerLvl == 0)
    {
	AdMenuCheck(%clientId, %option);
    	%tkText = "Only Logging TK's";
    } 
    else if($Paintball::tkServerLvl == 1)
    {
	AdMenuCheck(%clientId, %option);
	%tkText = "Votes at " @ $Paintball::tkLimit @ " TK's";
    }
    else if($Paintball::tkServerLvl == 2)
    {
	AdMenuCheck(%clientId, %option);
	%tkText = "Votes at " @ $Paintball::tkLimit @ " TKs and Kicks at " @ $Paintball::tkLimit * $Paintball::tkMultiple @ " TK's";
    }
    else if($Paintball::tkServerLvl == 3)
    {
	AdMenuCheck(%clientId, %option);
	%tkText = "Kicks at " @ $Paintball::tkLimit @ " TK's";
    }
    else %tkText = "ERROR: Server Level set to Unkown Level";
    return %tkText;
}

function Paintball_ClientLvlTxt()
{
    if($Paintball::tkClientLvl == 0)
    {
	AdMenuCheck(%clientId, %option);
    	%tkText = "Vote Option at " @ $Paintball::tkLimit @ " TK's"; 
    }
    else if($Paintball::tkClientLvl == 1)
    {
	AdMenuCheck(%clientId, %option);
	%tkText = "Kick Option at " @ $Paintball::tkLimit @ "TK's";
    }
    else %tkText = "ERROR: Client Level set to Unkown Level";
    return %tkText;
}

// Insomnaix Mod TK Handling - *IX*Savage1
function Paintball_setTeamKill(%victimId, %killerId) 
{
	$tkVictim[%killerId] = %victimId;
	$tkKiller[%victimId] = %killerId;
	$tkKills[%killerId] += 1;
	%trigger = $tkKills[%killerId] % $Paintball::tkLimit;
	%tkTopKills = $Paintball::tkLimit * $Paintball::tkMultiple;
	if(($tkKills[%killerId] >= $Paintball::tkLimit) && (!%trigger)) 
	  {
	  if($Paintball::tkServerLvl) 
	    {
	    if($Paintball::tkServerLvl != 3)
	      {
		if(($tkKills[%killerId] >= %tkTopKills) && ($Paintball::tkServerLvl != 1))
		{
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
		Admin::Kick(-2, %killerId);
		return;
		}
		%killerId.voteTarget = true;
     		%victimId.selClient = Paintball_getKiller(%victimId);
		Admin::startVote(%victimId, "Kick Team Killer " @ Client::getName(%killerId), "tkkick", %killerId);
	      }
	    else
	      {
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing. Confirmed " @ $tkKills[%killerId] @ " Team Kills.");
		Admin::Kick(-2, %killerId);
	      }		
	    }
	  }
	return;
}

function Paintball_getKiller(%clientId) 
{
  return $tkKiller[%clientId];
}

function Paintball_getVictim(%clientId) 
{
  return $tkVictim[%clientId];
}

function Paintball_clearPA(%admin) 
{
	AdMenuCheck(%clientId, %option);
	if(%admin.isSuperAdmin)
	{
	      %numPlayers = getNumClients();
      	for(%i = 0; %i < %numPlayers; %i++)
	      {
			%pl = getClientByIndex(%i);
			if(!%pl.isSuperAdmin && %pl.isAdmin)
			{
				%pl.isAdmin = false;
				Client::sendMessage(%pl,1,"Your Admin Status has been revoked by the Super Admin.");
				Client::sendMessage(%admin,3,"Public Admin Status Stripped from: " @ Client::getName(%pl) @ ".");
			}
		}
	}
}

////////////////////////////////////////////////////////////
//
//Spawn Stuff Starts Here -WorstAim
//
///////////////////////////////////////////////////////////

function processMenuChooseI(%clientId, %option)
{
	if(%option == "PBGuns")
	{
		client::buildMenu(%clientId, "Pick A Weapon:", "PickWep", true);
		client::addMenuItem(%clientId, %curItem++ @ "WDP IR3 Angel 2002", "WDP IR3 Angel 2002");
		client::addMenuItem(%clientId, %curItem++ @ "Shocktech AutoCocker", "Shocktech AutoCocker");
		client::addMenuItem(%clientId, %curItem++ @ "M3 Dragun LCD", "M3 Dragun LCD");
		client::addMenuItem(%clientId, %curItem++ @ "Spyder E-99", "Spyder E-99");
		client::addMenuItem(%clientId, %curItem++ @ "Diablo Inferno T3 Model", "Diablo Inferno T3 Model");
		client::addMenuItem(%clientId, %curItem++ @ "Bob Long Intimidator GZ", "Bob Long Intimidator GZ");
		client::addMenuItem(%clientId, %curItem++ @ "ADG MiniMag", "ADG MiniMag");
		client::addMenuItem(%clientId, %curItem++ @ "More Paintball Guns", "MoreGuns");
		return;
	}
	else if(%option == "FItems")
	{
		client::buildMenu(%clientId, "Pick An Item:", "PickItem", true);
		client::addMenuItem(%clientId, %curItem++ @ "Paint Grenade", "Paint Grenade");
		client::addMenuItem(%clientId, %curItem++ @ "Smoke Grenade", "Smoke Grenade");
		client::addMenuItem(%clientId, %curItem++ @ "Flash Bang", "Flash Bang");
		client::addMenuItem(%clientId, %curItem++ @ "Mine", "Mine");
		return;
	}
	else if(%option == "CSuits")
	{
		client::buildMenu(%clientId, "Pick A Suit:", "PickSuit", true);
		client::addMenuItem(%clientId, %curItem++ @ "Forest Camo", "Forest Camo");
		client::addMenuItem(%clientId, %curItem++ @ "Jungle Camo", "Jungle Camo");
		client::addMenuItem(%clientId, %curItem++ @ "Desert Camo", "Desert Camo");
		return;
	}
	else if(%option == "GAddons")
	{
		client::buildMenu(%clientId, "Pick An Addon:", "PickAdd", true);
		client::addMenuItem(%clientId, %curItem++ @ "Flash Light", "Flash Light");
		client::addMenuItem(%clientId, %curItem++ @ "Laser Scope", "Laser Scope");
		client::addMenuItem(%clientId, %curItem++ @ "Supply Pack", "Supply Pack");
		return;
	}
	else if(%option == "ClearFavs")
	{
		client::buildMenu(%clientId, "Confirm Clear Favs:", "CClear", true);
		client::addMenuItem(%clientId, %curItem++ @ "Yes", "Yes");
		client::addMenuItem(%clientId, %curItem++ @ "No", "No");
		return;
	}
}
function processMenuPickItem(%clientId, %option)
{
	if(!%clientId.clearedFirstSpawn)
	{
		ClearFavs1(%clientId);
	}
	%name = %option;
	if(%option == "Paint Grenade")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[3, %clientId] = "OriginalGrenade";
	}
	else if(%option == "Smoke Grenade")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[3, %clientId] = "SmokerGrenade";
	}
	else if(%option == "Flash Bang")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[3, %clientId] = "FlareGrenade";
	}
	else if(%option == "Mine")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[3, %clientId] = "MineAmmo";
	}
}
function processMenuPickSuit(%clientId, %option)
{
	if(!%clientId.clearedFirstSpawn)
	{
		ClearFavs1(%clientId);
	}
	%name = %option;
	if(%option == "Forest Camo")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "Camo2";
	}
	else if(%option == "Jungle Camo")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "Camo3";
	}
	else if(%option == "Desert Camo")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "Camo";
	}
}
function processMenuPickAdd(%clientId, %option)
{
	if(!%clientId.clearedFirstSpawn)
	{
		ClearFavs1(%clientId);
	}
	%name = %option;
	if(%option == "Flash Light")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "FLPack";
	}
	else if(%option == "Laser Scope")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "TLPack";
	}
	else if(%option == "Supply Pack")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[2, %clientId] = "SuPack";
	}
}
function processMenuPickWep(%clientId, %option)
{
	if(!%clientId.clearedFirstSpawn)
	{
		ClearFavs1(%clientId);
	}
	%name = %option;
	if(%option == "WDP IR3 Angel 2002")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Angel";
	}
	else if(%option == "Shocktech AutoCocker")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "AutoCocker";
	}
	else if(%option == "M3 Dragun LCD")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Dragun";
	}
	else if(%option == "Spyder E-99")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Spyder";
	}
	else if(%option == "Diablo Inferno T3 Model")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Inferno";
	}
	else if(%option == "Bob Long Intimidator GZ")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Intimidator";
	}
	else if(%option == "ADG MiniMag")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Delta";
	}
	else if(%option == "MoreGuns")
	{
		client::buildMenu(%clientId, "More Paintball Guns:", "MGUNS", true);
		client::addMenuItem(%clientId, %curItem++ @ "Diablo Mongoose LCD", "Diablo Mongoose LCD");
		client::addMenuItem(%clientId, %curItem++ @ "Psycho Ballistic Lightning", "Psycho Ballistic Lightning");
		client::addMenuItem(%clientId, %curItem++ @ "Tippmann 98 Sniper", "Tippmann 98 Sniper");
		client::addMenuItem(%clientId, %curItem++ @ "AWPT Shotgun", "AWPT Shotgun");
		client::addMenuItem(%clientId, %curItem++ @ "M-79 PB GrenLauncher", "M-79 PB GrenLauncher");
		client::addMenuItem(%clientId, %curItem++ @ "PB Bunker Thumper", "PB Bunker Thumper");
		return;
	}
}
function processMenuMGUNS(%clientId, %option)
{
	if(!%clientId.clearedFirstSpawn)
	{
		ClearFavs1(%clientId);
	}
	%name = %option;
	if(%option == "Diablo Mongoose LCD")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Mongoose";
	}
	else if(%option == "Psycho Ballistic Lightning")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Psycho";
	}
	else if(%option == "Tippmann 98 Sniper")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "TipmannS";
	}
	else if(%option == "AWPT Shotgun")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "AWPTShotgun";
	}
	else if(%option == "M-79 PB GrenLauncher")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "M79";
	}
	else if(%option == "PB Bunker Thumper")
	{
		client::sendMessage(%clientId, 0, "Adding: "@%name@" To Your Spawn Favorites");
		$spawnBuyList[1, %clientId] = "Bunker";
	}
}
function processMenuCClear(%clientId, %option)
{
	if(%option == "Yes")
	{
		ClearFavs(%clientId);
	}
	else
	{
		Game::MenuRequest(%clientId);
	}
}
function ClearFavs(%clientId)
{
	bottomprint(%clientId, "<F2> Clearing Spawn Favorites...<F0>", 5);
	for(%i = 1; $spawnBuyList[%i, %clientId] != ""; %i++)
	{
		$spawnBuyList[%i, %clientId] = "";
	}
}
function ClearFavs1(%clientId)
{
	%clientId.ClearedFirstSpawn = true;
	for(%i = 1; $spawnBuyList[%i, %clientId] != ""; %i++)
	{
		$spawnBuyList[%i, %clientId] = "";
	}
}

