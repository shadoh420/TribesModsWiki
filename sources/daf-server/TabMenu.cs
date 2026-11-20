//Bottom of misrestart.cs:
//
//EXEC(tabmenu);

$MaxMenuOpts=8;
function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(%clientId.ismaker)
   {
	Client::addMenuItem(%clientId, %curItem++ @ "Path Maker", "pathmaker");
	Client::addMenuItem(%clientId, %curItem++ @ "TEST ALL AI!", "testall");
   }
   if(!%clientId.selClient){
	if(!$matchStarted || !$Server::TourneyMode)
  	 {
		if($Game::missionType != "Extermination")
   		{
			if($Game::LimitedLives != true)
			{
			    	if(%clientId.observerMode == "dead"){
					if( %clientid.dieTime + $Server::respawnTime >= getSimTime() && !$SceneRunning && %clientId.noTeamChange != true)
					{
						Client::addSpecMenuItem(%clientId, %curItem++ , "Change Teams/Observe", "changeteams");
					}
				} else if( !$SceneRunning && %clientId.noTeamChange != true)
				{
					Client::addSpecMenuItem(%clientId, %curItem++ , "Change Teams/Observe", "changeteams");
				}
			}
		} else
		{	
			Client::addSpecMenuItem(%clientId, %curItem++ , "Change Spawn Armor", "changeSpawnArmor");
		}	
		Client::addSpecMenuItem(%clientId, %curItem++ , "Weapon Options", "weaponoptions");
		Client::addSpecMenuItem(%clientId, %curItem++ , "Current Stats", "currentstats");
	   }
   }

  
   if(%clientId.selClient)
   {

      %curItem = Menu::ClientSelected(%clientId,  %curItem);
     
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addSpecMenuItem(%clientId, %curItem++ , "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addSpecMenuItem(%clientId, %curItem++ , "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin && %clientId.noVote == "" )
   {
      Client::addSpecMenuItem(%clientId, %curItem++ , "Vote to change mission", "vcmission");
   }
   else if(%clientId.isAdmin)
   {
	Client::addSpecMenuItem(%clientId, %curItem++ , "General Admin Options", "Admin_opt");
      
   }

	if(%clientid.scomm >= floor(getTeamNumPlayers(Client::getTeam(%clientID))/2))
	{
		if($istourny)
			Client::addSpecMenuItem(%clientId, %curItem++ ,"DropBase Options", "dropbase");
	}
}
function Menu::Admin_opt(%clientId, %option)
{
	Client::buildMenu(%clientId, "Admin Options:", "Admin_Options", true);
	%curitem=0;
	Client::addSpecMenuItem(%clientId, %curItem++ , "Change mission", "cmission");
	Client::addSpecMenuItem(%clientId, %curItem++ , "Set Team Damage Scale", "tdc");
      	Client::addSpecMenuItem(%clientId, %curItem++ , "Set Time Limit", "ctimelimit");
        if(%clientId.isSuperAdmin)
	      	Client::addSpecMenuItem(%clientId, %curItem++ , "Reset Server Defaults", "reset");

}

function Menu::admin_sel_opt(%clientId, %cl)
{
	%sel = %cl;
	
        %name = Client::getName(%sel);
	Client::buildMenu(%clientId, "Admin Options:", "Admin_Options", true);
	%curItem= 0;
	Client::addSpecMenuItem(%clientId, %curItem++ , "Kick " @ %name, "kick " @ %sel);
        Client::addSpecMenuItem(%clientId, %curItem++ , "Kill " @ %name, "killpass1 " @ %sel);

        if(%clientId.isSuperAdmin)
        {
           	Client::addSpecMenuItem(%clientId, %curItem++ , "Ban " @ %name, "ban " @ %sel);
            	Client::addSpecMenuItem(%clientId, %curItem++ , "Admin " @ %name, "admin " @ %sel);
	    	if(%sel.notalk == true)
         		Client::addSpecMenuItem(%clientId, %curItem++ , "UnGmute " @ %name, "unGmute " @ %sel);
      	    	else
         		Client::addSpecMenuItem(%clientId, %curItem++ , "GMute " @ %name, "Gmute " @ %sel);
        }

	if($Game::missionType != "Extermination" && $Game::LimitedLives != true)
	{
		Client::addSpecMenuItem(%clientId, %curItem++ , "Change " @ %name @ "'s team", "fteamchange " @ %sel);
	}
	if(%sel.noVote == true)	
		Client::addSpecMenuItem(%clientId, %curItem++ , "Allow voting for " @ %name, "canvote " @ %sel);
	else
		Client::addSpecMenuItem(%clientId, %curItem++ , "Deny voting to " @ %name, "novote " @ %sel);

	if(%sel.noTeamChange == true)
		Client::addSpecMenuItem(%clientId, %curItem++ , "UnTeamLock " @ %name, "unlockTeam " @ %sel);
	else
		Client::addSpecMenuItem(%clientId, %curItem++ , "TeamLock " @ %name, "lockTeam " @ %sel);


	if($Game::LimitedLives == true && %clientId.isSuperAdmin)
	{
		Client::addSpecMenuItem(%clientId, %curItem++ , "Change " @ %name @ "'s lives", "liveschange " @ %sel);
	}

}

function Client::addSpecMenuItem(%clientId, %num, %option, %code)
{
	%mult=floor(%num/$MaxMenuOpts);
	if(!%mult)
		Client::addMenuItem(%clientId, %num@%option, %code);
	else
	{
		if((%num/$MaxMenuOpts)==floor(%num/$MaxMenuOpts))
		{
			Client::addMenuItem(%clientId, %num@"More options...", "specmoreopts");
		}
		%clientId.overopt[%num-($MaxMenuOpts-1)]=%option;
		%clientId.overcode[%num-($MaxMenuOpts-1)]=%code;
		%clientId.overnum=%num-($MaxMenuOpts-1);
		%clientid.menumodeover=%clientid.menumode;
	}


}
function Menu::specmoreopts(%clientId)
{
 Client::buildMenu(%clientId, "Continued...", %clientid.menumodeover, true);
       for(%x=1;%x<=%clientId.overnum;%x++)
	Client::addSpecMenuItem(%clientId, %x , %clientId.overopt[%x], %clientId.overcode[%x]);
}


function Menu::ClientSelected(%clientId, %curItem)
{
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);
//echo(%curitem);
      Client::addSpecMenuItem(%clientId, %curItem++ , "Set as commander " @ %name, "scomm " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin && %clientId.noVote == "" )
      {
         Client::addSpecMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addSpecMenuItem(%clientId, %curItem++ , "Vote to kick " @ %name, "vkick " @ %sel);
      }


      //*************************************ADMIN*********************************************************
      if(%clientId.isAdmin)
      {
	Client::addSpecMenuItem(%clientId, %curItem++ , "Admin Options on " @ %name, "admin_sel_opt " @ %sel);
       //Menu::IsAdminAndSel(%clientId, %curItem);
      }
      //*************************************END ADMIN*********************************************************
      if(%clientId.muted[%sel])
         Client::addSpecMenuItem(%clientId, %curItem++ , "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addSpecMenuItem(%clientId, %curItem++ , "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addSpecMenuItem(%clientId, %curItem++ , "Observe " @ %name, "observe " @ %sel);
      return %curItem;
}
function Client::addMenuItem(%clientId, %option, %code)
{
   remoteEval(%clientId, "AddMenuItem", %option, %code);
}

function Menu::fteamchange(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
  
	
   if($Game::missionType == "Extermination")
  	return;

      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
     
      Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Observer", -2);

      // DELTAFORCE
	if($Game::missionType == "Assassination") {
		Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"VIP", 2);

		Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Bodyguards", 0);
		Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Assassins", 1);
	} else if ((!$hostageGame || $Game::missionType != "Hostage") && $Game::missionType != "Jail") {
		Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Automatic", -1);
	}
	if($Game::missionType == "Hostage" || $Game::missionType == "Jail" ) {
		for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,getTeamName(%i), %i);
   	} else {
      		%i = getNumTeams();
        	//Client::addMenuItem(%clientId, (2) @ getTeamName(%i), %i);
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         		Client::addSpecMenuItem(%clientId, $Options[%clientId]++ , getTeamName(%i), %i);
   	}
	return;

}

function Menu::weaponoptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   	
	Client::buildMenu(%clientId, "Weapon Options:", "WOptions", true);

	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Airstrike", "airstrike");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Auto Shotgun", "autoshotgun");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Grenade", "grenade");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Silenced MP5", "mp5");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Locking Method", "lock");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"MineLayer Type", "mine");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Countermeasure Type", "counter");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Vehicle Firelinking", "hflink");

				
	
	return;

}

function Menu::currentstats(%clientId, %option)
{
	Client::buildMenu(%clientId, "Current Stat Options:", "CStats", true);
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Kills", "Kstats");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Deaths", "Dstats");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"K-D Ratio", "KDstats");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"TKs", "TKstats");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Full Stats", "Fstats");
	Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Vet Stats", "Vstats");
}

function Menu::changeSpawnArmor(%clientId, %option)
{

   	Client::buildMenu(%clientId, "Pick an armor loadout:", "PickSpawnArmor", true);
        Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Infantry", infantry);
        Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Medic", medic);
        Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"AmmoSupplier", ammo);
	return;

}

function Menu::changeteams(%clientId, %option)
{

   if($Game::missionType != "Extermination" && !$SceneRunning && %clientId.noTeamChange != true)
    {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Observer", -2);
  	   // DELTAFORCE
	   	if($Game::missionType == "Assassination") {
			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"VIP", 2);
	
			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Bodyguards", 0);
	
			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Assassins", 1);
			
		} else if ((!$hostageGame || $Game::missionType != "Hostage") && $Game::missionType != "Jail") {
			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,"Automatic", -1);
		}
		if($Game::missionType == "Hostage" || $Game::missionType == "Jail") {
			for(%i = 0; %i < getNumTeams()-1; %i = %i + 1)
				Client::addSpecMenuItem(%clientId, $Options[%clientId]++ , getTeamName(%i), %i);
			
   		} else {
      			
      	  			%i = checkTeams();
          			Client::addSpecMenuItem(%clientId, $Options[%clientId]++ ,getTeamName(%i), %i);
          		
			
   	    }
   	   // END DELTAFORCE
         return;
      }
     }

}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   $Options[%clientId] = 0;
   
  
   if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "scomm")
   {
      Client::buildMenu(%clientId, "Set commander:", "caffirm", true);
      Client::addMenuItem(%clientId, "1Set " @ Client::getName(%cl)@ " as commander?", "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't set " @ Client::getName(%cl)@ " as commander?", "no " @ %cl);
      return;
   }
else if(%opt == "pathmaker")
   {
	PatherMainOptions(%clientID, %option);
	return;
   }  
else if(%opt == "testall")
   {
	testallAAI(%clientID);
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
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "observe")
   {	
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if(%opt == "dropbase") 
   {
	DropBaseStuff(%clientId);
	return;	
   }
   else
   schedule("Menu::"@%opt@"("@%clientId@", \""@%cl@"\");", 0.001);
	
   Game::menuRequest(%clientId);
}

function processMenuAdmin_Options(%clientId, %option)
{
	if(!%clientId.isAdmin)
		return;

   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   if(%opt == "specmoreopts") {
	Menu::Specmoreopts(%clientId);
	return;
   }
   else if(%opt == "canvote")
      %cl.noVote = "";
   else if(%opt == "novote")
      %cl.noVote = true;
   else if(%opt == "unlockTeam")
      %cl.noTeamChange = "";
   else if(%opt == "lockTeam")
      %cl.noTeamChange = true;
   else if(%opt == "Gmute") {
   	Client::buildMenu(%clientId, "Global Mute?:", "GMaffirm", true);
    	Client::addMenuItem(%clientId, "1Mute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
    	Client::addMenuItem(%clientId, "2Dont Mute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   } else if(%opt == "unGmute") {
   	Client::buildMenu(%clientId, "Global Unmute?:", "GUMaffirm", true);
      	Client::addMenuItem(%clientId, "1Unmute " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Unmute " @ Client::getName(%cl)@ "1", "no " @ %cl);
	return;
   } 
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admin:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "killpass1") //======================================================================== Admin Kill Player
   {
   	Client::buildMenu(%clientId, "Kill?:", "Killaffirm", true);
      	Client::addMenuItem(%clientId, "1Kill " @ Client::getName(%cl)@ "?", "yes " @ %cl);
      	Client::addMenuItem(%clientId, "2Dont Kill " @ Client::getName(%cl)@ "!", "no " @ %cl);
	return;
   }

   // DELTAFORCE
   else if(%opt == "tdc") {
	  Client::buildMenu(%clientId, "Set Team Damage Scale", "tdscale", true);
	  Client::addMenuItem(%clientId, "10%", 0);
	  Client::addMenuItem(%clientId, "210%", 10);
	  Client::addMenuItem(%clientId, "325%", 25);
	  Client::addMenuItem(%clientId, "450%", 50);
	  Client::addMenuItem(%clientId, "575%", 75);
	  Client::addMenuItem(%clientId, "690%", 90);
	  Client::addMenuItem(%clientId, "7100%", 100);
	  return;
   }
   
   else if(%opt == "ctimelimit")
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
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, true);
   }
    else if(%opt == "fteamchange")
   {
      Menu::fteamchange(%clientId, %option);
   }
   else if(%opt == "liveschange" && %clientId.isSuperAdmin)
   {
      Client::buildMenu(%clientId, "Current lives: "@%cl.lives, "lives", true);
      %count = 0;
        Client::addMenuItem(%clientId, (%count++) @ "-100", %cl @ " " @ -100);
	Client::addMenuItem(%clientId, (%count++) @ "-5"  , %cl @ " " @ -5);
	Client::addMenuItem(%clientId, (%count++) @ "-3"  , %cl @ " " @ -3);
	Client::addMenuItem(%clientId, (%count++) @ "-1"  , %cl @ " " @ -1);
	Client::addMenuItem(%clientId, (%count++) @  "1"  , %cl @ " " @ 1);
	Client::addMenuItem(%clientId, (%count++) @  "3"  , %cl @ " " @ 3);
	Client::addMenuItem(%clientId, (%count++) @  "5"  , %cl @ " " @ 5);
	Client::addMenuItem(%clientId, (%count++) @  "100", %cl @ " " @ 100);
      return;
   }
}



function remoteSelectClient(%clientId, %selId)
{
	// Al-la WorstAim's crash protection	
	// ** 
	%clientId.tries++;
	if(%clientId.tries > 5)
	{
		if(%clientId.gone)
		{
			return;
		}
		%name = client::getName(%clientId);
		banlist::add(client::getTransportAddress(%clientId), 999);
		kick(%clientId,"You Were Kicked For Spamming remoteSelectClient",0);
		%clientId.gone = true;
		return;
	}
	schedule(%clientId@".tries = 0;", 0.5);
	// ** 

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
if($Game::missionType != "Extermination")
{

   if(%clientId.isAdmin)
      processMenuPickTeam(%clientId.ptc, %team, %clientId);
   %clientId.ptc = "";
}
}

// DELTAFORCE
function processMenulives(%clientId, %opts)
{
	if(!%clientId.isSuperAdmin) 
		return;

   %cl = getWord(%opts, 0);
   %lives = getWord(%opts, 1);
	if((%cl != %ClientID)&&(%cl.isSuperAdmin || (%cl.isAdmin && !%clientid.isSuperAdmin)))
	{
			Echo(%clientId @ " just attempted to change " @ %cl @"'s lives.");
      			Client::sendMessage(%cl, 0, Client::getName(%clientID) @ " (" @ %clientID @ ") " @ "just attempted to change your lives.");
			client::sendmessage(%clientID, 0, "I don't think "@client::getname(%cl)@" would like you messing with 'em");
			return;
	}
   givelives(%cl, %lives);
}

function processMenuGrenOptions(%clientId, %opt)
{
	if(%opt == "exp")
	{
		$GrenMode[%clientId] = 0;
		//remoteEval(%clientId, BP, "<f0><jc>Grenades set for Fragmentation detonation", 4);
		bottomprint(%clientId, "<f0><jc>Grenades set for Fragmentation detonation", 4);
		return;
	} else if(%opt == "smoke")
	{
		$GrenMode[%clientId] = 1;
		//remoteEval(%clientId, BP, "<f0><jc>Grenades set for Smoke detonation", 4);
		bottomprint(%clientId, "<f0><jc>Grenades set for Smoke detonation", 4);
		return;
	}
}

function processMenuASOptions(%clientId, %opt)
{
	if(%opt == "he") {
		$ASMode[%clientId] = 0;
		//remoteEval(%clientId, BP, "<f0><jc>Airstrike set to High Explosive payload", 4);
		bottomprint(%clientId, "<f0><jc>Airstrike set to High Explosive payload", 4);
		return;
	} else if(%opt == "napalm") {
		$ASMode[%clientId] = 1;
		//remoteEval(%clientId, BP, "<f0><jc>Airstrike set to Napalm payload", 4);
		bottomprint(%clientId, "<f0><jc>Airstrike set to Napalm payload", 4);
		return;
	}
}


function processMenuMPOptions(%clientId, %opt)
{
	if(%opt == "standard") {
		$MP5Mode[%clientId] = 0;
		//remoteEval(%clientId, BP, "<f0><jc>MP5 set to Standard fire", 4);
		bottomprint(%clientId, "<f0><jc>MP5 set to Standard fire", 4);
		return;
	} else if(%opt == "threeshot") {
		$MP5Mode[%clientId] = 1;
		//remoteEval(%clientId, BP, "<f0><jc>MP5 set to Three-shot Burst fire", 4);
		bottomprint(%clientId, "<f0><jc>MP5 set to Three-shot Burst fire", 4);
		return;
	}
}

function processMenuSGOptions(%clientId, %opt)
{
	if(%opt == "flechette") {
		$ShotgunMode[%clientId] = 0;
		//remoteEval(%clientId, BP, "<f0><jc>SPAS-12 loaded with Flechette rounds", 4);
		bottomprint(%clientId, "<f0><jc>SPAS-12 loaded with Flechette rounds", 4);
		return;
	}
	else if(%opt == "slug") {
		$ShotgunMode[%clientId] = 1;
		//remoteEval(%clientId, BP, "<f0><jc>SPAS-12 loaded with Slug rounds", 4);
		bottomprint(%clientId, "<f0><jc>SPAS-12 loaded with Slug rounds", 4);
		return;	
	}
}

function processMenuLockOptions(%clientId, %opt)
{
	if(%opt == "pre") {
		$LockingMode[%clientId] = 0;
		//remoteEval(%clientId, BP, "<f0><jc>Locking set to Oldstyle Pre-Lock: Before Fire", 4);
		bottomprint(%clientId, "<f0><jc>Locking set to Oldstyle Pre-Lock: Before Fire", 4);
		return;
	}
	else if(%opt == "post") {
		$LockingMode[%clientId] = 1;
		//remoteEval(%clientId, BP, "<f0><jc>Locking set to Newstyle Post-Lock: Travel Past", 4);
		bottomprint(%clientId, "<f0><jc>Locking set to Newstyle Post-Lock: Travel Past", 4);
		return;	
	}
}

function processMenuMineOptions(%clientId, %opt)
{
	if(%opt == "AP") {
		%clientId.minetype = 1;
		bottomprint(%clientId, "<f0><jc>Mine Layer (Volcano) Mine Type set to Standard AP Mine", 4);
		return;
	}
	else if(%opt == "APB") {
		%clientId.minetype = 2;
		bottomprint(%clientId, "<f0><jc>Mine Layer (Volcano) Mine Type set to AP Bouncing Mine", 4);
		return;	
	}
	else if(%opt == "AA") {
		%clientId.minetype = 3;
		bottomprint(%clientId, "<f0><jc>Mine Layer (Volcano) Mine Type set to AA Mine", 4);
		return;	
	}
}

function processMenuCounterOptions(%clientId, %opt)
{
	if(%opt == "FL") {
		%clientId.countermeasure = "Flare";
		bottomprint(%clientId, "<f0><jc>Countermeasure type set to Flares (AI)", 4);
		return;
	}
	else if(%opt == "CH") {
		%clientId.countermeasure = "Chaff";
		bottomprint(%clientId, "<f0><jc>Countermeasure type set to Chaff (AR)", 4);
		return;	
	}
}

function processMenuhflinkOptions(%clientId, %opt)
{
	if(%opt == "UL") {
		%clientId.hflink = 0;
		bottomprint(%clientId, "<f0><jc>Same type weapons set to unlinked", 4);
		return;
	}
	else if(%opt == "FL") {
		%clientId.hflink = 1;
		bottomprint(%clientId, "<f0><jc>Same type weapons set to Fire-Linked", 4);
		return;	
	}
	else if(%opt == "SL") {
		%clientId.hflink = 2;
		bottomprint(%clientId, "<f0><jc>Same type weapons set to Selected-Linked", 4);
		return;	
	}
}

function processMenuDBOptions(%clientId, %opt)
{
	if(!$istourny || %clientid.scomm < floor(getTeamNumPlayers(Client::getTeam(%clientID))/2))
	{
		return;
	}

	if(!Player::isDead(%this)) {
		if(%opt == "SAT") {
			%curOpt = 0;
			Client::buildMenu(%clientId, "Satalite Options:", "SatOpts", true);
			Client::addMenuItem(%clientId,%curOpt++@"Move to my current waypoint", "WYP");
			Client::addMenuItem(%clientId,%curOpt++@"Move to my current location", "RMV");
			//Client::addMenuItem(%clientId,%curOpt++@"Move to teammate's location", "TMV");
			return;
		}
		if(%opt == "Undo") {
			%curOpt = 0;
			Client::buildMenu(%clientId, "Are you sure?", "UndoOpts", true);
			Client::addMenuItem(%clientId,%curOpt++@"Yes", "yes ");
			Client::addMenuItem(%clientId,%curOpt++@"No", "no ");
			return;
		}
		if(%opt == "specmoreopts") {
			Menu::Specmoreopts(%clientId);
			return;
		}
			
			bottomprint(%clientId, "<f0><jc>Deploying "@%opt@"!", 4);
			%team = gamebase::getteam(%clientId);
			$lastissat[%team]=false;
			$tmpteam = %team;
			$tmpnum = $DBTeamCount[%opt, %team]--;
			$lastDBName[%team] = %opt;
			$lastDBTime[%team] = getsimtime();
			exec("Dropbase\\"@%opt@".cs");
			$lastgroup[%team] = nametoId(%opt@"-"@%team@"-"@$tmpnum);
	
			addtoset("MissionCleanup\\team"@%team@"\\Dropbase", $lastgroup[%team]);
					if($lastissat[%team])
				{
				$UplinkCmd[Group::getobject($lastgroup[%team],3)] = Group::getobject($lastgroup[%team],1);
Satalite::Deploy(Group::getobject($lastgroup[%team],3), $tmpteam);

				}
			Group::iterateRecursive($lastgroup[%team], gamebase::setteam, %team);
			Group::iterateRecursive($lastgroup[%team], DBMoveTo, %clientId);
			$lastspawns[%team] = -1;
			if($lastgroup[%team].spawns)
				{
				Group::iterateRecursive("Drops", DBCheckSP, %opt);
				delete(nametoId("Drops"));
				}
			return;
		
	}
	else {
		bottomprint(%clientId, "<f0><jc>Must be alive and playing to deploy!", 4);
		return;
	}		
}

function processMenuUndoOpts(%clientId,%opt)
{
	if(!$istourny || %clientid.scomm < floor(getTeamNumPlayers(Client::getTeam(%clientID))/2))
	{
		return;
	}


  if(%opt == "yes ")
  {
	
	%team = gamebase::getteam(%clientId);
	if(getsimtime()-$lastDBTime[%team]>20)
		{
		bottomprint(%clientId, "<f0><jc>More than 20 seconds have passed!", 4);
		}
	deleteobject($lastgroup[%team]);
	if($lastDBName[%team] == "CommandTent")
		$CTLayed[%team]--;
	if($lastspawns[%team]!=-1)
		{
		for(%x=0; %x<=$lastspawns[%team]; %x++)
			{
			deleteobject($LastSpawnPoint[%x, %team]);
			}
		}
	$DBTeamCount[$lastDBName[%team], %team]++;
	if($lastissat[%team])
		$TeamSat[%team] = -1;	
		
  }


}

function DBMoveTo(%this, %clientId)
{

	%pos = gamebase::getposition(%clientId);
	%rot = gamebase::getrotation(%clientId);
	//GetOffSetRot("0 -5 3",%rot,%position);
	//"2 2 3.189"
	%center = "0 0 0";
	%center = GetOffSetRot($lastgroup[gamebase::getteam(%clientId)].center,"0 0 0","0 0 0");
	
	%dir = vector::sub(gamebase::getposition(%this),%center);
	//echo(%dir);
	%dir2 = GetOffSetRot(%dir,%rot,%pos);
	%dist = vector::getdistance(%dir, "0 0 0");
	%norm = vector::normalize(%dir);
	%moo = vector::add(%rot, vector::getrotation(%norm));
	//gamebase::setposition(%this, vector::add(%pos, vector::getfromrot(%moo, %dist)));
	gamebase::setposition(%this, vector::add(%center, %dir2));
	if(%this.useLOS&&GameBase::getLOSInfo(%this,10,"-1.570796327 0 0"))
		{
		GameBase::setPosition(%this,vector::add($los::position, "0 0 0.1"));
		echo($los::position);
		}
	gamebase::setrotation(%this, vector::add(%rot, gamebase::getrotation(%this)));
}
function getSpawnGroup(%team)
{

%grp = nametoId("MissionGroup\\Teams\\team"@%team@"\\DropPoints\\Random");
return %grp;
}

function DBCheckSP(%this, %opt)
{
	if(%this.DBNum == %opt@$tmpnum)
	{
	//echo(%this.DBNum);
	gamebase::setteam(%this, $tmpteam);

	addToSet($spawngroup[$tmpteam],%this);
	%center = "0 0 0";
	%center = GetOffSetRot($lastgroup[gamebase::getteam(%clientId)].center,"0 0 0","0 0 0");
	
	%dir = vector::sub(gamebase::getposition(%this),%center);
	%dir2 = GetOffSetRot(%dir,%rot,%pos);
	%dist = vector::getdistance(%dir, "0 0 0");
	%norm = vector::normalize(%dir);
	%moo = vector::add(%rot, vector::getrotation(%norm));
	gamebase::setposition(%this, vector::add(%center, %dir2));

	if(GameBase::getLOSInfo(%this,100,"-1.570796327 0 0"))
		GameBase::setPosition(%this,vector::add($los::position, "0 0 0.1"));
	gamebase::setrotation(%this, vector::add(gamebase::getrotation(%clientId), gamebase::getrotation(%this)));
	$LastSpawnPoint[$lastspawns[$tmpteam]++, $tmpteam] = %this;
	}
}

function specmoreopts::Build(%clientId)
{
	Menu::specmoreopts(%clientId);
}

function processMenuSatOpts(%clientId,%opt)
{
	
	%sat = $TeamSat[Client::getTeam(%clientID)];
	echo($LastPlayerWayPoint[%clientId]);
	if(!Player::isDead(%this)) {
		if(gamebase::getdamagelevel(%sat) > 0) {
			Client::sendMessage(%clientId, $MSGTypeGame, "The uplink station is either unpowered or damaged! Cannot transmit coordinates!");
			return;
		}
		if(%opt == "WYP") {
			//echo("$Uplink[%sat] == "@$Uplink[%sat]@"; $UplinkCmd[$Uplink[%sat]] == "@$UplinkCmd[$Uplink[%sat]]@"; Station::getTarget($UplinkCmd[$Uplink[%sat]]) == "@Station::getTarget($UplinkCmd[$Uplink[%sat]])@"; Player::getClient(Station::getTarget($UplinkCmd[$Uplink[%sat]])) == "@Player::getClient(Station::getTarget($UplinkCmd[$Uplink[%sat]]))@"; %clientId == "@%clientId); 
			if(Player::getClient(Station::getTarget($UplinkCmd[$Uplink[%sat]])) == %clientId) {
				if($LastPlayerWayPoint[%clientID]) {
					Client::sendMessage(%clientId, $MSGTypeGame, "Repositioning Satalite to waypoint coordinates...");
					$SatDest[%sat] = $LastPlayerWayPoint[%clientID];	
					echo($satonroute[%sat]);
					%start = "true";
				}
				else
					Client::sendMessage(%clientId, $MSGTypeGame, "No waypoint cooridinates input...");
			}
			else
				Client::sendMessage(%clientId, $MSGTypeGame, "Must be at Radar Uplink Station to Control Satalite remotely...");
		}
		else if(%opt == "RMV") {
			Client::sendMessage(%clientId, $MSGTypeGame, "Repositioning Satalite to your coordinates...");
			$SatDest[%sat] = gamebase::getposition(%clientID);
			echo($satonroute[%sat]);
			%start = "true";
		}
		if($satonroute[$TeamSat[Client::getTeam(%clientID)]] == "" && %start == "true")
			Satalite::updatePos(%sat);
		return;
	}
	else {
		bottomprint(%clientId, "<f0><jc>Must be alive to command Satalite!", 4);
		return;
	}
}

function processMenuWOptions(%clientId, %opt)
{
	if(%opt == "autoshotgun") {
		Client::buildMenu(%clientId, "Choose mode:", "SGOptions", true);
		Client::addMenuItem(%clientId, "0Flechette", "flechette");
		Client::addMenuItem(%clientId, "1Slug", "slug");
		return;
	}
	else if (%opt == "mp5") {
		Client::buildMenu(%clientId, "Choose mode:", "MPOptions", true);
		Client::addMenuItem(%clientId, "0Standard", "standard");
		Client::addMenuItem(%clientId, "1Three-shot Burst", "threeshot");
		return;
	}
	else if(%opt == "airstrike") {
		Client::buildMenu(%clientId, "Choose mode:", "ASOptions", true);
		Client::addMenuItem(%clientId, "0High Explosive", "he");
		Client::addMenuItem(%clientId, "1Napalm", "napalm");
		return;
	} else if(%opt == "grenade") {
		Client::buildMenu(%clientId, "Choose mode:", "GrenOptions", true);
		Client::addMenuItem(%clientId, "0Frag", "exp");
		Client::addMenuItem(%clientId, "1Smoke", "smoke");
		return;
	} else if(%opt == "lock") {
		Client::buildMenu(%clientId, "Choose mode:", "lockOptions", true);
		Client::addMenuItem(%clientId, "0Old Pre-Lock Method", "pre");
		Client::addMenuItem(%clientId, "1New Post-Lock Method", "post");
		return;
	} else if(%opt == "mine") {
		Client::buildMenu(%clientId, "Choose mode:", "mineOptions", true);
		Client::addMenuItem(%clientId, "0AP mine", "AP");
		Client::addMenuItem(%clientId, "1AP Bouncing Mine", "APB");
		Client::addMenuItem(%clientId, "2AA Mine", "AA");
		return;
	} else if(%opt == "counter") {
		Client::buildMenu(%clientId, "Choose mode:", "counterOptions", true);
		Client::addMenuItem(%clientId, "0Flare", "FL");
		Client::addMenuItem(%clientId, "1Chaff", "CH");
		return;
	} else if(%opt == "specmoreopts") {
       		Menu::specmoreopts(%clientId);
		return;
  
	} else if(%opt == "hflink") {
		Client::buildMenu(%clientId, "Choose mode:", "hflinkOptions", true);
		Client::addMenuItem(%clientId, "0Unlinked", "UL");
		Client::addMenuItem(%clientId, "1Fire-Linked", "FL");
		Client::addMenuItem(%clientId, "2Selected-Linked", "SL");
		return;
	} else if(%opt == "dropbase") {
		DropBaseStuff(%clientId);
		
	}
	else if(%opt == "dropbase2") {
		%x = 0;
		Client::buildMenu(%clientId, "Do which?:", "DBOptions", true);	
		if($RadarUplinks[Client::getTeam(%clientID)] > 0 && $CTLayed[Client::getTeam(%clientID)] == true) {
			Client::addMenuItem(%clientId, %x@"Build RadarUplink", "RUL");
			%x++;
		}
		if($TeamSat[Client::getTeam(%clientID)] != "") {
			Client::addMenuItem(%clientId, %x@"Satalite Options", "SAT");
			%x++;
		}
	}
}

function DropBaseStuff(%clientId)
{
	if(!$istourny || %clientid.scomm < floor(getTeamNumPlayers(Client::getTeam(%clientID))/2))
	{
		return;
	}


Client::buildMenu(%clientId, "Do which?:", "DBOptions", true);	
				%team = Client::getTeam(%clientID);
		%x=0;
		if(($CTLayed[Client::getTeam(%clientID)] == true)&&getsimtime()-$lastDBTime[%team]<20)
			Client::addSpecMenuItem(%clientId, %x++,"--Undo Last Placement--", "Undo");
		for(%y=0; %y<=$DBNum;%y++)
		{
		if(($DBTeamCount[$DBStructure[%y], %team] > 0)&& (($CTLayed[%team] > 0)||($DBStructure[%y]=="CommandTent") )) 
			{
			
			Client::addSpecMenuItem(%clientId, %x++, "Build "@$DBStructure[%y], $DBStructure[%y]);

			}
		}
		if($TeamSat[%team] != "") 
			Client::addSpecMenuItem(%clientId, %x++,"Satalite Options", "SAT");
		
		return;

}
function processMenuCStats(%clientId, %opt)
{
	if(%opt == "Kstats"){
		if(!%clientId.kills)
			%clientId.kills = 0;
		BottomPrint(%clientId, "<jc>You have " @ %clientId.kills @ " total kills this game.", 5);
	}
	else if(%opt == "Dstats"){
		if(!%clientId.deaths)
			%clientId.deaths = 0;
		BottomPrint(%clientId, "<jc>You have " @ %clientId.deaths @ " total deaths this game.", 5);
	}
	else if(%opt == "KDstats"){
		if(!%clientId.kills)
			%clientId.kills = 0;
		if(!%clientId.deaths)
			%clientId.deaths = 0;
		BottomPrint(%clientId, "<jc>You have " @ getKillDeathRatio(%clientId) @ "% kills to deaths ratio this game.", 5);
	}
	else if(%opt == "TKstats"){
		if(!$TKCount[%clientId, Client::getName(%clientId)])
			$TKCount[%clientId, Client::getName(%clientId)] = 0;
		BottomPrint(%clientId, "<jc>You have " @ $TKCount[%clientId, Client::getName(%clientId)] @ " total TeamKills this game.", 5);
	}
	else if(%opt == "Fstats"){
		getNearestThreeScores(%clientId);
	}
	else if(%opt == "Vstats"){
		getVetStats(%clientID);
	}
}