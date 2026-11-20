exec(objectives);

function CheckForVIP()
{	
	%numTeams = getNumTeams();
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
	  	if(Client::getteam($teamVIP[%team]) != %team && $teamVIP[%team] != -1)
	  		StripVIP($teamVIP[%team], %team, "changed to the other team");
	  	if(Client::getteam($teamDecoy[%team]) != %team && $teamDecoy[%team] != -1)
	  		StripDecoy($teamDecoy[%team], %team, "changed to the other team");
	  	if(Client::getteam($teamCom[%team]) != %team && $teamCom[%team] != "")
	  		$teamCom[%team] = "";
	 	if(Client::getteam($nextVIP[%team]) != %team && $nextVIP[%team] != -1)
	  		$nextVIP[%team] = -1;
	  	if(Client::getteam($nextDecoy[%team]) != %team && $nextDecoy[%team] != -1)
	  		$nextDecoy[%team] = -1;

	}
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if($teamVIP[%team] == -1)
			GetNewVIP(%team);
		if($teamDecoy[%team] == -1)
			GetNewDecoy(%team);
	}
	
	schedule("CheckForVIP();", 1);
}

function VIPregeneration()
{
	%numTeams = getNumTeams();
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if($teamVIP[%team] == -1)
			continue;
		Player::setItemCount($teamVIP[%team],Repairpatch,1);
		Player::useitem($teamVIP[%team],Repairpatch);
	}
	
	schedule("VIPregeneration();", 10);
}

function StripVIP(%client, %team, %reason)
	{
		if(!String::ICompare(Client::getGender($teamVIP[%team]), "Male"))
	      		%pronoun = "he";
	   		else
	      		%pronoun = "she";
		
		%teamname = getTeamName(%team);
		
		teamMessages(1, %team, $nameVIP[%team] @ " is no longer your " @ $VIPname @ " because " @ %pronoun @ " " @ %reason @ ".");
		
		Client::sendMessage(%client, 0, "You are no longer the " @ %teamname @ " " @ $VIPname @ " because you " @ %reason @ ".");
		
		$teamVIP[%team] = -1;
		$nameVIP[%team] = -1;
		$aliveVIP[%team] = -1;
	}
				
function StripDecoy(%client, %team, %reason)
	{
		if(!String::ICompare(Client::getGender($teamVIP[%team]), "Male"))
	      		%pronoun = "he";
	   		else
	      		%pronoun = "she";
		
		%teamname = getTeamName(%team);
		
		teamMessages(1, %team, $nameDecoy[%team] @ " is no longer your Decoy because " @ %pronoun @ " " @ %reason @ ".");
			
		Client::sendMessage(%client, 0, "You are no longer the " @ %teamname @ " Decoy because you " @ %reason @ ".");
		
		$teamDecoy[%team] = -1;
		$nameDecoy[%team] = -1;
	}
	
function GetNewVIP(%team)
{
	
	// see if someone is assigned to be next VIP
	if($nextVIP[%team] != -1)
	{
		if(%team == client::getteam($nextVIP[%team]))
		{
			makeVIP($nextVIP[%team], %team);
			$nextVIP[%team] = -1;
			return;
		}
		else
			$nextVIP[%team] = -1;
	}
	
	%numPlayers = getNumClients();
	
	%numTeamPlayers = 0;
        %numTeamWantVIP = 0;
        
        
        
        for(%i = 0; %i < %numPlayers; %i = %i + 1)
         {
        	%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%plteam != %team)
			continue;
		
		if($wantVIP[%pl] == true)
		        %numTeamWantVIP = %numTeamWantVIP + 1;
		
		%numTeamPlayers = %numTeamPlayers + 1;
	}
		
	
	if(%numTeamPlayers == 0)
		return;
	
   	if(%numTeamWantVIP >> 0)
   	 {
   		
   			
   			%teamVIPselect = (floor(getRandom() * (%numTeamWantVIP)))+1;
   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
		
			if($wantVIP[%pl] == true)
		        	%num = %num +1;
		        	
		        if(%teamVIPselect == %num)
   			{
   				MakeVIP(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	 }
   	 else
   	 {
   	
   		
   		%teamVIPselect = (floor(getRandom() * (%numTeamPlayers)))+1;
   		
   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
		
			%num = %num + 1;
		        	
		        if(%TeamVIPselect == %num)
   			{
   				MakeVIP(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	 }
}
 
function MakeVIP(%client, %team)
{  	
	
	if(%client == $teamDecoy[%team])
		StripDecoy(%client, %team, "got promoted to " @ $VIPname);
		
	
	$teamVIP[%team] = %client;
	$nameVIP[%team] = client::getName(%client);
	$aliveVIP[%team] = 1;
	
	if($initialassign == true)
	 {
		if(!String::ICompare(Client::getGender(%client), "Male"))	
			Player::SetArmor(%client,"MArmor");
		else
			Player::SetArmor(%client,"MFemale");

		Player::setItemCount(%client,LightArmor,0);									
		Player::setItemCount(%client,MediumArmor,1);									
		Player::setItemCount(%client,PlasmaGun,1);
		Player::setItemCount(%client,PlasmaAmmo,40);
		Player::useItem(%client,PlasmaGun);

		Player::mountItem(%client, Flag, $FlagSlot, %team);
				      
	 }
	else
	{
		player::kill(%client);	 					
	}
	
	
		if(!String::ICompare(Client::getGender(%client), "Male"))
	      			%pronoun = "him";
	   			else
	      			%pronoun = "her";


        	teamMessages(1, %team, $nameVIP[%team] @ " is your " @ $VIPname @ "!" @  "  Protect " @ %pronoun @ " at all costs!");
      		
		bottomprint($teamVIP[%team], "<jc><f0>You are your team's " @ $VIPname @".  Don't get killed!", 5);
		
		%numPlayers = getNumClients();
		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%playerId = getClientByIndex(%i);
	 		%teamId = Client::getTeam(%playerId);
	        	if($teamVIP[%team] == %playerId)
	        	continue;
			if(%team == %teamId)
			bottomprint(%playerId, "<jc><f0>" @ $nameVIP[%team] @ " is your " @ $VIPname @ "!" @  "  Protect " @ %pronoun @ " from the enemy team!", 5);
		}

	
}
	
function GetNewDecoy(%team)
{

	
	if($nextDecoy[%team] != -1)
	{
		if(%team == client::getteam($nextDecoy[%team]) && $nextDecoy[%team] != $teamVIP[%team])
		{
			makeDecoy($nextDecoy[%team], %team);
			$nextDecoy[%team] = -1;
			return;
		}
		else
			$nextDecoy[%team] = -1;
	}
	
	%numPlayers = getNumClients();
	
	%numTeamPlayers = 0;
        %numTeamWantDecoy = 0;
        
        
        
        for(%i = 0; %i < %numPlayers; %i = %i + 1)
        {
        	%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%plteam != %team)
			continue;
		
		if(%pl == $teamVIP[%team])
			continue;
		
		if($wantDecoy[%pl] == true)
		        %numTeamWantDecoy = %numTeamWantDecoy + 1;
		
		%numTeamPlayers = %numTeamPlayers + 1;
	}
		
	
	if(%numTeamPlayers == 0)
		return;
	
   	if(%numTeamWantDecoy >> 0)
   	{
   		
   		
   		%teamDecoyselect = (floor(getRandom() * (%numTeamWantDecoy)))+1;
   		   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
				
			if(%pl == $teamVIP[%team])
				continue;
		
			if($wantDecoy[%pl] == true)
		        	%num = %num + 1;
		        	
		        if(%teamDecoyselect == %num)
   			{
   				MakeDecoy(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	}
   	else
   	{
 		%teamDecoyselect = (floor(getRandom() * (%numTeamPlayers)))+1;
   		   			
   		%num = 0;
   			
   		for(%i = 0; %i < %numPlayers; %i = %i + 1)
        	{
   			%pl = getClientByIndex(%i);
			%plteam = Client::getTeam(%pl);
		
			if(%plteam != %team)
				continue;
				
			if(%pl == $teamVIP[%team])
				continue;
		
			%num = %num + 1;
		        	
		        if(%teamDecoyselect == %num)
   			{
   				MakeDecoy(%pl, %team);
   				%i = %numPlayers;
   			}
   		}
   	}
}
 
function MakeDecoy(%client, %team)
{  	
	// this shouldn't happen, but just in case...
	if(%client == $teamVIP[%team])
		return;
		
	$teamDecoy[%team] = %client;
	$nameDecoy[%team] = client::getName(%client);	
	
	 if($initialassign == true)
	 {

		Player::setItemCount(%client,LightArmor,0);									
		Player::setItemCount(%client,MediumArmor,1);
		Player::setItemCount(%client,PlasmaGun,1);
		Player::setItemCount(%client,PlasmaAmmo,40);
		Player::useItem(%client,PlasmaGun);


		if(!String::ICompare(Client::getGender(%client), "Male"))	
			Player::SetArmor(%client,"MArmor");
		else
			Player::SetArmor(%client,"MFemale");
		Player::mountItem(%client, Flag, $FlagSlot, %team);
									
	 }
	 else
	{
	 player::kill(%client);
	}
	
		
		if(!String::ICompare(Client::getGender(%client), "Male"))
	      			%pronoun = "him";
	   			else
	      			%pronoun = "her";
      
        	bottomprint($teamDecoy[%team], "<jc><f0>You are your team's Decoy.  Distract the enemy and keep them away from your " @ $VIPname @ "!", 5);
        
      		teamMessages(1, %team, $nameDecoy[%team] @ " is your Decoy!  Use " @ %pronoun @ " to distract the enemy!");	
}


function Game::clientKilled(%playerId, %killerId)
{
      %numTeams = getNumTeams();
      for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%playerID == $teamVIP[%team])
			{
			
				%killernum = Client::getTeam(%killerId);
				%killername = Client::getName(%killerId);
				%killerteam = getTeamName(%killernum);
				%losername = getTeamName(%team);
				if(%playerId == %killerId)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " committed suicide!");
						Client::sendMessage(%killerId, 0, "You killed yourself!");
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
					   	           %killerId.score = %killerId.score - 4;
         						   Game::refreshClientScore(%killerId);
					}
				else if(%losername == %killerteam)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by his OWN teammate " @ %killername @ "!");
						Client::sendMessage(%killerId, 0, "You killed your OWN " @ $VIPname @ "!");
						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
					   	  
			   	 			   %killerId.score = %killerId.score - 4;
         						   Game::refreshClientScore(%killerId);
					}
				else if(getObjectType(Client::getOwnedObject(%killerId)) != "Player")
      					{
      					  	messageAll(0, "The " @ %losername @ " " @ $VIPname @ " came to an untimely end.");
      						for(%i = 0; %i < getNumTeams(); %i++)
		   	   			  {
					   	      if(%i == %team)
					   	         continue;
					   	      $teamScore[%i] += 10;
					   	  }
      					}
      				else
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by the " @ %killerteam @ " assassin, " @ %killername @ "!");
						Client::sendMessage(%killerId, 0, "You killed the enemy " @ $VIPname @ "!");
						$teamScore[%killernum] += 10;
						
     			   	           	%killerId.score = %killerId.score +4;
         					Game::refreshClientScore(%killerId);

					}

				$aliveVIP[%team] = 0;
			 	

			}
		if(%playerID == $teamDecoy[%team])
			{
			
				
				%killernum = Client::getTeam(%killerId);
				%killername = Client::getName(%killerId);
				%killerteam = getTeamName(%killernum);
				%losername = getTeamName(%team);
				if(%playerId == %killerId)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " committed suicide!  Luckily it was only their DECOY!");
						Client::sendMessage(%killerId, 0, "You killed yourself!");
						%killerId.score = %killerId.score - 1;
					}
				else if(%losername == %killerteam)
					{
						messageAllExcept(%killerId, 0, "The " @ %losername @ " " @ $VIPname @ " was killed by his OWN teammate " @ %killername @ "!  Luckily it was only their DECOY!");
						Client::sendMessage(%killerId, 0, "You killed your OWN DECOY!");
						%killerId.score = %killerId.score - 1;
					}
				else if(getObjectType(Client::getOwnedObject(%killerId)) != "Player")
      					{
      					  	messageAll(0, "The " @ %losername @ " " @ $VIPname @ " came to an untimely end.  Luckily it was only the DECOY!");
      						
      					}
				else
					{
						messageAllExcept(%killerId, 0, %killername @ " thought he killed the " @ %losername @ " " @ $VIPname @ ", but it was only a DECOY!");
						Client::sendMessage(%killerId, 0, "You killed the enemy " @ $VIPname @ "!  NOT!  You were fooled by a DECOY!");
						%killerId.score = %killerId.score + 1;
					}
			 	
			 	$aliveDecoy[%team] = $aliveDecoy[%team] +1;

			}

	}

}


function Game::startMatch()
{
   
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	


      %numPlayers = getNumClients();
      %numTeams = getNumTeams();
      
      $initialassign = true;
      	for(%team = 0; %team < %numTeams; %team = %team + 1)
      	{
		GetNewVIP(%team);
      		GetNewDecoy(%team);
	}		
      $initialassign = false;
      
      schedule("CheckForVIP();", 1);
      schedule("VIPregeneration();", 10);
      
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Player::leaveMissionArea(%player){
   %cl = Player::getClient(%player);
   Client::sendMessage(%cl,1,"You have left the mission area.");
   %player.outArea=1;
   alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}


function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}

  
function alertPlayer(%player, %count){
   if(%player.outArea == 1){
      %clientId = Player::getClient(%player);
      Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");

      if(%count > 1)
         schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
      else 
         schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
   }
}

function leaveMissionAreaDamage(%client){
   %player = Client::getOwnedObject(%client);

   if(%player.outArea == 1){
      if(!Player::isDead(%player)){
         Player::setDamageFlash(%client,0.1);
         GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.15);
	  schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
      }
      else { 
         playNextAnim(%client);	
         Client::onKilled(%client, %client);
      }
   }
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   if(!%respawn)
   {
      // initial drop
      
        bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }
	
	   
	   if(%clientId == $teamVIP[client::getTeam(%clientId)] || %clientId == $teamDecoy[client::getTeam(%clientId)])
	    {
	   	
	   	
	   	
	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	     		%armor = "marmor";
	   	else
	      		%armor = "mfemale";
	      		
	      	$spawnBuyList[0] = MediumArmor;
	      	$spawnBuyList[1] = Blaster;
		$spawnBuyList[2] = Chaingun;
		$spawnBuyList[3] = Disclauncher;
		$spawnBuyList[4] = Plasmagun;
		$spawnBuyList[5] = RepairKit;
		
		
	   }
	   else
	   {
	   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      		%armor = "larmor";
	   	else
	      		%armor = "lfemale";
	      	
	      	$spawnBuyList[0] = LightArmor;
	      	$spawnBuyList[1] = Blaster;
		$spawnBuyList[2] = Chaingun;
		$spawnBuyList[3] = Disclauncher;
		$spawnBuyList[4] = RepairKit;
		$spawnBuyList[5] = "";
	      	
	    }

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);

	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }

	if(%clientId == $teamVIP[client::getTeam(%clientId)] || %clientId == $teamDecoy[client::getTeam(%clientId)])
	   Player::mountItem(%clientId, Flag, $FlagSlot, client::getTeam(%clientId));
		
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}


function TowerSwitch::onCollision(%this, %object)
{

   %clicked = 0;
   if(getObjectType(%object) != "Player")
      return;

   if(Player::isDead(%object))
      return;

%playerClient = Player::getClient(%object);	


     %numTeams = getNumTeams();
for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
	if(%playerClient == $teamVIP[%team] || %playerClient == $teamDecoy[%team])
		{
			   %playerClient = Player::getClient(%object);
			   %touchClientName = $VIPname;
			   %group = GetGroup(%this);			   
			   %playerTeam = GameBase::getTeam(%object);
			   %oldTeam = GameBase::getTeam(%this);

		
			   %dropPoints = nameToID(%group @ "/DropPoints");
			   %oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %oldTeam);
			   %newDropSet = nameToID("MissionCleanup/TeamDrops" @ %playerTeam);
		
			   if(%oldTeam == %playerTeam)
				{
				  Group::iterateRecursive(%group, GameBase::setTeam, -1);
				  MessageAllExcept(%playerClient, 0, "The " @ getTeamName(%playerTeam) @ " " @ %touchClientName @ " relinquished " @ getTeamName(%playerTeam) @ " control of " @ %this.objectiveName @ "!~wCapturedTower.wav");
				  Client::sendMessage(%playerClient, 0, "You relinquished " @ getTeamName(%playerTeam) @ " control of " @ %this.objectiveName @ "!~wCapturedTower.wav");
				  $owned[%team] = $owned[%team] -1;
				  $teamScore[%playerTeam] -= %this.scoreValue;
				  $deltaTeamScore[%playerTeam] -= %this.deltaTeamScore;
					 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					            removeFromSet(%oldDropSet, %dropPoint);
					      }
					   }


				}
			   else			
			   	{
				if(%oldTeam != -1)
					{
				        Client::sendMessage(%playerClient, 0, "This base is already owned by another team!  You may only claim NEUTRAL bases!~waccess_denied.wav");
					return;
					}
 
				   if($maxowned == $owned[%team])
					{
					Client::sendMessage(%playerClient, 0, "Your team already owns the maximum number of bases for this mission!~waccess_denied.wav");
					return;
					}

				   %this.damage = 0;
				   Group::iterateRecursive(%group, GameBase::setTeam, %playerTeam);
				   $deltaTeamScore[%playerTeam] += %this.deltaTeamScore;
		 		   $teamScore[%playerTeam] += %this.scoreValue;
			            MessageAllExcept(%playerClient, 0, "The " @ getTeamName(%playerTeam) @ " " @ %touchClientName @ " claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!~wCapturedTower.wav");
				    Client::sendMessage(%playerClient, 0, "You claimed " @ %this.objectiveName @ " for the " @ getTeamName(%playerTeam) @ " team!~wCapturedTower.wav");
				    $owned[%team] = $owned[%team] +1;
 				 if(%dropPoints != -1)
					   {
					      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
					      {
					         addToSet(%newDropSet, %dropPoint);
					      }
					   }

				}

			
			   

			   
			   %clicked = 1;
			}
	
	}
	if(%clicked == 0)
		{
			Client::sendMessage(%playerClient, 0, "Only VIPs and Decoys may claim or relinquish control of bases!~waccess_denied.wav");
		}
}


function DeployableStation::onCollision(%this, %object)
{
	//echo("Collision (" @ %this @ ",	" @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  	 	%client = Player::getClient(%object);
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) {
			if (GameBase::getDamageState(%this) == "Enabled") {
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
      else if(Station::getTarget(%this) == %object) {
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

function Station::onCollision(%this, %object)
{
	if(%this.target == ""){
		//echo(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
		%obj = getObjectType(%object);
		if (%obj == "Player" && isPlayerBusy(%object) == 0) {
  		 	%client = Player::getClient(%object);
 			if(GameBase::getTeam(%object) == GameBase::getTeam(%this)) {
				if (GameBase::getDamageState(%this) == "Enabled") {
					if (GameBase::isPowered(%this)) { 
						if(%this.enterTime == "")
							%this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
					}
					else 
						Client::sendMessage(%client,0,"Unit is not powered");
				}
				else 
					Client::sendMessage(%client,0,"Unit is disabled");
			}
			else if(Station::getTarget(%this) == %object)
   	   {
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") {
					Client::clearItemShopping(%client);
					Station::onDeactivate(%this);
					Station::onEndSequence(%this,1);
					if(Client::getGuiMode(%client) != 1)
						Client::setGuiMode(%client,1);
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
		}
	}
}

	
function setupShoppingList(%client,%station,%ListType)
{
	%max = getNumItems();
	if(%ListType == "InvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				{

				%nobuyarmor = 0;

        			%numTeams = getNumTeams();
				for(%team = 0; %team < %numTeams; %team = %team + 1)
				{
					if(%client == $teamVIP[%team] || %client == $teamDecoy[%team])
						{
						%nobuyarmor = 1;
						}
				}
				if(%nobuyarmor != 1)
					Client::setItemShopping(%client, %item);
				}
		}
	}
	else if(%ListType == "RemoteInvList") {
		for (%i = 0; %i < %max; %i = %i + 1) {
			%item = getItemData(%i);
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
	   }
	}
	else {
		for (%i = 0; %i < %max; %i = %i + 1) {						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
}
	
function Server::onClientDisconnect(%clientId)
{

		$wantVIP[%clientId] = false;
		$wantDecoy[%clientId] = false;
		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%clientId == $teamVIP[%team])
				StripVIP(%client, %team, "dropped");
			else if(%clientId == $teamDecoy[%team])
				StripDecoy(%client, %team, "dropped");
			
			if(%clientId == $teamCom[%team])
	  			$teamCom[%team] = "";
	 		if(%clientId == $nextVIP[%team])
	  			$nextVIP[%team] = -1;
		  	if(%clientId == $nextDecoy[%team])
		  		$nextDecoy[%team] = -1;
		}
	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}

   Client::setControlObject(%clientId, -1);
   Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
}


function Observer::enterObserverMode(%clientId)
{
   		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%clientId == $teamVIP[%team])
				StripVIP(%clientId, %team, "entered observer mode");		
			else if(%clientId == $teamDecoy[%team])
				StripDecoy(%clientId, %team, "entered observer mode");
				
			if(%clientId == $teamCom[%team])
	  			$teamCom[%team] = "";
	 		if(%clientId == $nextVIP[%team])
	  			$nextVIP[%team] = -1;
		  	if(%clientId == $nextDecoy[%team])
		  		$nextDecoy[%team] = -1;
			
		}
   
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
      return false;
   Client::clearItemShopping(%clientId);
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   Client::setOwnedObject(%clientId, -1);
   Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %clientId.observerMode = "observerOrbit";
   GameBase::setTeam(%clientId, -1);
   Observer::jump(%clientId);
   remotePlayMode(%clientId);
   return true;
}

function ObjectiveMission::missionComplete()
{
   $missionComplete = true;
   
   for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		$helpsayVIP[%team] = "";
		$helpsayDecoy[%team] = "";
		$teamVIP[%team] = "";
		$nameVIP[%team] = "";
		$aliveVIP[%team] = "";
		$teamDecoy[%team] = "";
		$nameDecoy[%team] = "";
		$aliveDecoy[%team] = "";
		$owned[%team] = "";
		$deltaTeamScore[%team] = 0;
        	$teamScore[%team] = 0; 
        	$nextVIP[%team] = "-1";
        	$nextDecoy[%team] = "-1";

        }
   
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	   
	   if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine -1, "<f1><Bflag_neutral.bmp>\n Your team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine - 1, "<f1><Bflag_atbase.bmp>\n Your team successfully protected your " @ $VIPname @ ".");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine - 1, "<f1><Bflag_enemycaptured.bmp>\n Your team failed to protect your " @ $VIPname @ ".");
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team didn't have a Decoy at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team's Decoy avoided detection and fooled the enemy.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team's Decoy was exposed " @ $aliveDecoy[%i] @ " times.");
	   
      	   %l= 1;
           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n The " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\n Your team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\n Your team successfully assassinated the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n The " @ getteamname(%team) @ " team didn't have a Decoy at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\n Your team failed to expose the " @ getteamname(%team) @ " Decoy.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n Your team exposed the " @ getteamname(%team) @ " Decoy " @ $aliveDecoy[%team] @ " times.");
		%l++;
	}
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
	}
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
      $VIPname = "";
   $missionComplete = false;
   
   
   // back out of all the functions...
   schedule("Server::nextMission();", 0);
}


function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if (Player::isExposed(%this)) {
      %damagedClient = Player::getClient(%this);
      %shooterClient = %object;

   		%numTeams = getNumTeams();
		for(%team = 0; %team < %numTeams; %team = %team + 1)
		{
			if(%damagedClient == $teamVIP[%team] && %type != $ImpactDamageType && %type != $LandingDamageType)
			{
				
				if($helpsayVIP[%team] != false)
				{
					schedule("$helpsayVIP[" @ %team @ "]= true;", 1);
					if(%damagedClient == %shooterClient)
					{
						playVoice(%damagedClient, "oops1"); 
						RemotePlayAnim(%damagedClient, 9);
					}
					else if(client::getteam(%damagedClient) == client::getteam(%shooterClient))
					{
						playVoice(%damagedClient, "cease"); 
						RemotePlayAnim(%damagedClient, 0);
					}
					else
					{
						RemotePlayAnim(%damagedClient, 0);
						playVoice(%damagedClient, "help"); 
					}
				
					$helpsayVIP[%team] = false;
				}
				if($Server::TeamDamageScale >> 0 && $Server::VIPDamageScale >> 0 || %damagedClient == %shooterClient)
				{
					%numPlayers = getNumClients();
	   				for(%i = 0; %i < %numPlayers; %i = %i + 1)
	       				{
	        				%playerId = getClientByIndex(%i);
	 					%teamId = Client::getTeam(%playerId);
	 					if(%damagedClient == %playerId)
	        					continue;
		        			if(%team == %teamId)
		        			bottomprint(%playerId, "<jc><f0>Your " @ $VIPname @ " is under attack!", 5);
	        			}
	        		}
	        	}
	        	else if(%damagedClient == $teamDecoy[%team]  && %type !=0)
			{
				if($helpsayDecoy[%team] != false)
				{
				schedule("$helpsayDecoy[" @ %team @ "]= true;", 1);
				if(%damagedClient == %shooterClient)
				{
					playVoice(%damagedClient, "oops1"); 
					RemotePlayAnim(%damagedClient, 9);
				}
				else if(client::getteam(%damagedClient) == client::getteam(%shooterClient))
				{
					playVoice(%damagedClient, "cease"); 
					RemotePlayAnim(%damagedClient, 0);
				}
				else
				{
					RemotePlayAnim(%damagedClient, 0);
					playVoice(%damagedClient, "help"); 
				}
				
				$helpsayDecoy[%team]=false;
				}
			}
		}

		Player::applyImpulse(%this,%mom);
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
			if (%shooterClient != -1) {
				%curTime = getSimTime();
			   if ((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) {
					if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])	
					{
						if($Server::VIPDamageScale > 0)
						{
						if(%type != $MineDamageType) {
							Client::sendMessage(%shooterClient,0,"You just harmed your " @ $VIPname @ ", " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else {
							Client::sendMessage(%shooterClient,0,"You just harmed your " @ $VIPname @ ", " @ Client::getName(%damagedClient) @ ", with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
						}
					}
					else
					{
						if(%type != $MineDamageType) {
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
							Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
						}
						else {
							Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
							Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						}
					}
					%this.LastHarm = %shooterClient;
					%this.DamageStamp = %curTime;
				}
			}
			%friendFire = $Server::TeamDamageScale;

			if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])
				%VIPFriendFire = $Server::VIPDamageScale;
			else
				%VIPFriendFire = 1.0;
		}
		else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
		{
			%friendFire = $Server::TeamDamageScale;
			
			if(%damagedClient == $teamVIP[client::getteam(%damagedClient)])
				%VIPFriendFire = $Server::VIPDamageScale;
			else
				%VIPFriendFire = 1.0;
		}
		else  
		{
			%friendFire = 1.0;
			%VIPfriendFire = 1.0;
		}
		

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head" && %type == $LaserDamageType) {
				if(%armor == "harmor") { 
					if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
						%value += (%value * 0.3);
					}
				}
				else {
					%value += (%value * 0.3);
				}
			}
			//If Shield Pack is on
			if (%type != -1 && %this.shieldStrength) {
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				%absorb = %energy * %strength;
				if (%value < %absorb) {
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else {
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
  			if (%value) {
				%value = $DamageScale[%armor, %type] * %value * %friendFire * %VIPFriendFire;
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if (%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
               if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
                	Player::blowUp(%this);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	}
}

function Mission::init()
{
	
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	
	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		$helpsayVIP[%team] = true;
		$helpsayDecoy[%team] = true;
		$teamVIP[%team] = "-1";
		$nameVIP[%team] = "-1";
		$aliveVIP[%team] = "-1";
		$teamDecoy[%team] = "-1";
		$nameDecoy[%team] = "-1";
		$aliveDecoy[%team] = "0";
		$owned[%team] = "0";
		$deltaTeamScore[%team] = 0;
        	$teamScore[%team] = 0;
        }
	
      	if($VIPname == "")
		$VIPname = "VIP";

   setClientScoreHeading("Player Name\t\x6FTeam\t\xA6Score\t\xCFPing\t\xEFPL");
//   setClientScoreHeading("Player Name\t\x6FTeam\t\xD6Score");//\t\xFFPing\t\xFFPL");
   setTeamScoreHeading("Team Name\t\xD6Score");

   $firstTeamLine = 7;
   $firstObjectiveLine = $firstTeamLine + getNumTeams() + 1;
   for(%i = -1; %i < getNumTeams(); %i++)
   
   {
      $teamFlagStand[%i] = "";
		$teamFlag[%i] = "";
      Team::setObjective(%i, $firstTeamLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine - 1, " ");
      Team::setObjective(%i, $firstObjectiveLine, "<f5>Mission Objectives: ");
      $firstObjectiveLine++;
      Team::setObjective(%i, $firstObjectiveLine + 2, "<f1><Bflag_atbase.bmp>\n Hide and protect your " @ $VIPname @ ".");
      Team::setObjective(%i, $firstObjectiveLine + 3, "<f1><Bflag_neutral.bmp>\n Use your Decoy to distract the enemy.");
      %l= 4;
      %numTeams = getNumTeams();
   	for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\n Find and kill the " @ getTeamName(%team) @ " " @ $VIPname @ ".");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\n Expose the " @ getTeamName(%team) @ " Decoy in order to find their " @ $VIPname @ ".");
		%l++;
	}   

      newObject("TeamDrops" @ %i, SimSet);
      addToSet(MissionCleanup, "TeamDrops" @ %i);
      %dropSet = nameToID("MissionGroup/Teams/Team" @ %i @ "/DropPoints/Random");
      for(%j = 0; (%dropPoint = Group::getObject(%dropSet, %j)) != -1; %j++)
         addToSet("MissionCleanup/TeamDrops" @ %i, %dropPoint);
   }
   $numObjectives = 0;
   newObject(ObjectivesSet, SimSet);
   addToSet(MissionCleanup, ObjectivesSet);
   
   Group::iterateRecursive(MissionGroup, ObjectiveMission::initCheck);
   %group = nameToID("MissionCleanup/ObjectivesSet");

	ObjectiveMission::setObjectiveHeading();
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      %obj.objectiveLine = %i + $firstObjectiveLine;
      ObjectiveMission::objectiveChanged(%obj);
   }
   ObjectiveMission::refreshTeamScores();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      %cl.score = 0;
      Game::refreshClientScore(%cl);
   }
   schedule("ObjectiveMission::checkPoints();", 5);

	if($TestMissionType == "") {
		if($NumTowerSwitchs) 
			$TestMissionType = "C&H";
		else 
			$TestMissionType = "NONE";		
		$NumTowerSwitchs = "";
	}
   AI::setupAI();
}

function Vote::changeMission()
{
   $timeLimitReached = true;
   $timeReached = true;
   $missionComplete = true;
   
   for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		$helpsayVIP[%team] = "";
		$helpsayDecoy[%team] = "";
		$teamVIP[%team] = "";
		$nameVIP[%team] = "";
		$aliveVIP[%team] = "";
		$teamDecoy[%team] = "";
		$nameDecoy[%team] = "";
		$aliveDecoy[%team] = "";
		$owned[%team] = "";
		$deltaTeamScore[%team] = 0;
	       	$teamScore[%team] = 0;
               	$nextVIP[%team] = "-1";
        	$nextDecoy[%team] = "-1";
        }
   
   %group = nameToID("MissionCleanup/ObjectivesSet");
   for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
   {
      ObjectiveMission::objectiveChanged(%obj);
	}
   for(%i = 0; %i < getNumTeams(); %i++) { 
	   Team::setObjective(%i, $firstObjectiveLine-4, " ");
	   Team::setObjective(%i, $firstObjectiveLine-3, "<f5>Mission Summary:");
	   Team::setObjective(%i, $firstObjectiveLine-2, " ");
	   
	   if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine - 1, "<f1><Bflag_neutral.bmp>\n Your team didn't have a " @ $VIPname @ " at the end of the mission.");
	   else if($aliveVIP[%i] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine - 1, "<f1><Bflag_atbase.bmp>\n Your team successfully protected your " @ $VIPname @ ".");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine - 1, "<f1><Bflag_enemycaptured.bmp>\n Your team failed to protect your " @ $VIPname @ ".");
	   if($teamDecoy[%i] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team didn't have a Decoy at the end of the mission.");
	   else if($aliveDecoy[%i] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team's Decoy avoided detection and fooled the enemy.");
	   else
	   	Team::setObjective(%i, $firstObjectiveLine, "<f1><Bflag_neutral.bmp>\n Your team's Decoy was exposed " @ $aliveDecoy[%i] @ " times.");
	   
      	   %l= 1;
           %numTeams = getNumTeams();
   	    for(%team = 0; %team < %numTeams; %team = %team + 1)
	{
		if(%team == %i)
			continue;
		if($teamVIP[%team] == -1)
		Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n The " @ getteamname(%team) @ " team didn't have a " @ $VIPname @ " at the end of the mission.");
		else if($aliveVIP[%team] == 1)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_enemycaptured.bmp>\n Your team failed to assassinate the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_atbase.bmp>\n Your team successfully assassinated the " @ getteamname(%team) @ " " @ $VIPname @ ".");
	   	%l++;
	   	if($teamDecoy[%team] == -1 && $aliveDecoy[%team] == 0)
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n The " @ getteamname(%team) @ " team didn't have a Decoy at the end of the mission.");
		else if($aliveDecoy[%team] == 0)
	  	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_notatbase.bmp>\n Your team failed to expose the " @ getteamname(%team) @ " Decoy.");
	   	else
	   	Team::setObjective(%i, $firstObjectiveLine + %l, "<f1><Bflag_neutral.bmp>\n Your team exposed the " @ getteamname(%team) @ " Decoy " @ $aliveDecoy[%team] @ " times.");
		%l++;
	}
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;
		Team::setObjective(%i, $firstObjectiveLine + %l, " ");
		%l++;

	}
	ObjectiveMission::setObjectiveHeading();
   ObjectiveMission::refreshTeamScores();
	%lineNum = "";
	   $VIPname = "";
	
	
   $missionComplete = false;
}

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
   else if($curVoteAction == "com")
   {
      if($curVoteOption.voteTarget)
      {
         Commander($curVoteOption);
      }
      $curVoteOption.voteTarget = false;
   }
   else if($curVoteAction == "uncom")
   {
      if($curVoteOption.voteTarget)
      {
         Uncommander($curVoteOption);
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
   else if($curVoteAction == "evd")
      Admin::setVIPDamageEnable(-1, true);
   else if($curVoteAction == "dvd")
      Admin::setVIPDamageEnable(-1, false);
   else if($curVoteOption == "smatch")
      Admin::startMatch(-1);
}

function Admin::setVIPDamageEnable(%admin, %enabled)
{
   if(%admin == -1 || %admin.isAdmin)
   {
      if(%enabled)
      {
         $Server::VIPDamageScale = 1;
         if(%admin == -1)
            messageAll(0, "VIP damage set to ENABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " ENABLED VIP damage.");
      }
      else
      {
         $Server::VIPDamageScale = 0;
         if(%admin == -1)
            messageAll(0, "VIP damage set to DISABLED by consensus.");
         else
            messageAll(0, Client::getName(%admin) @ " DISABLED VIP damage.");
      }
   }
}

function Game::menuRequest(%clientId)
{
   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
  
   }
   
   if($wantVIP[%clientId] == true)
      		Client::addMenuItem(%clientId, %curItem++ @ "VIP Status- Requested", "wantviptoggle");
      else
        	Client::addMenuItem(%clientId, %curItem++ @ "VIP Status- Normal", "wantviptoggle");
      if($wantDecoy[%clientId] == true)
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy Status- Requested", "wantdecoytoggle");
      else
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy Status- Normal", "wantdecoytoggle");
      
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
         if(client::getteam(%sel) == client::getteam(%clientId))
         {
         	if($teamCom[client::getteam(%sel)] == %sel)
         		Client::addMenuItem(%clientId, %curItem++ @ "Vote to remove " @ %name @ " from command", "vuncom " @ %sel);
         	else
         		Client::addMenuItem(%clientId, %curItem++ @ "Vote to place " @ %name @ " in command", "vcom " @ %sel);
         }
      }
      if(%clientId == $teamCom[client::getteam(%clientId)])
      {
      	if(client::getteam(%sel) == client::getteam(%clientId))
      	{	
      		Client::addMenuItem(%clientId, %curItem++ @ "VIP " @ %name, "vip " @ %sel);
      		Client::addMenuItem(%clientId, %curItem++ @ "Decoy " @ %name, "decoy " @ %sel);
        }
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
         if($teamCom[client::getteam(%sel)] == %sel)
         	Client::addMenuItem(%clientId, %curItem++ @ "Remove " @ %name @ " from command", "uncom " @ %sel);
         else
         	Client::addMenuItem(%clientId, %curItem++ @ "Place " @ %name @ " in command", "com " @ %sel);
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
      if($curVoteAction == "com" || $curVoteAction == "uncom")
      {
      	if($curVoteOption.voteTarget)
      	{
      	 	%sel = $curVoteOption;
      	 	if(client::getteam(%sel) == client::getteam(%clientId))
      	 	{
      	 		Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      			Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
      		}
      	}
      }
      else
      {
      	Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      	Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
      }
   
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
      if($Server::VIPDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable VIP damage", "vdvd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable VIP damage", "vevd");               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");
      if($Server::VIPDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable VIP damage", "dvd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable VIP damage", "evd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
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
   else if(%opt == "wantviptoggle")
   {
      if($wantVIP[%clientId] == true)
      	$wantVIP[%clientId] = false;
      else
      	$wantVIP[%clientId] = true;
      	
      
   }      
   else if(%opt == "wantdecoytoggle")
   {
      if($wantDecoy[%clientId] == true)
      	$wantDecoy[%clientId] = false;
      else
      	$wantDecoy[%clientId] = true;
      	
      
   }         
      
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vcom")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "place " @ Client::getName(%cl) @ " in command of the " @ %teamname @ " team", "com", %cl);
   }
   else if(%opt == "vuncom")
   {
      %cl.voteTarget = true;
      %team = client::getteam(%cl);
      %teamname = getteamname(%team);
      Admin::startVote(%clientId, "remove " @ Client::getName(%cl) @ " from command of the " @ %teamname @ " team", "uncom", %cl);
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
   else if(%opt == "vip")
   {
      $nextVIP[client::getteam(%cl)] = %cl;
      teamMessages(1, client::getteam(%cl), client::getname(%cl) @ " has been set to be the next " @ $VIPname @ ".");	
      Client::sendMessage(%clientId, 0, "You have set " @ client::getname(%cl) @ " to be the next " @ $VIPname @ ".");
      Client::sendMessage(%cl, 0, "You have been set to be the next " @ $VIPname @ ".");
   }
   else if(%opt == "decoy")
   {
      $nextDecoy[client::getteam(%cl)] = %cl;
      teamMessages(1, client::getteam(%cl), client::getname(%cl) @ " has been set to be the next Decoy.");	
      Client::sendMessage(%clientId, 0, "You have set " @ client::getname(%cl) @ " to be the next Decoy.");
      Client::sendMessage(%cl, 0, "You have been set to be the next Decoy.");
   }
      
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "vevd")
      Admin::startVote(%clientId, "enable VIP damage", "evd", 0);
   else if(%opt == "vdvd")
      Admin::startVote(%clientId, "disable VIP damage", "dvd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "evd")
      Admin::setVIPDamageEnable(%clientId, true);
   else if(%opt == "dvd")
      Admin::setVIPDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "uncom")
   	Uncommander(%cl);
   else if(%opt == "com")
   	Commander(%cl);
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
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
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
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   Game::menuRequest(%clientId);
}

function Server::onClientConnect(%clientId)
{
   $wantVIP[%clientId] = false;
   $wantDecoy[%clientId] = false;
   
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

   Game::onPlayerConnected(%clientId);
}

function Commander(%clientId)
{
	%team = client::getteam(%clientId);
	$teamCom[%team] = %clientId;
	
	teamMessages(1, %team, client::getname(%clientId) @ " has been placed in command.");	
	Client::sendMessage(%clientId, 0, "You have been placed in command.");
}

function Uncommander(%clientId)
{
	%team = client::getteam(%clientId);
	$teamCom[%team] = "";
	
	teamMessages(1, %team, client::getname(%clientId) @ " has been removed from command.");	
	Client::sendMessage(%clientId, 0, "You have been stripped of command.");
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
   
   if($curVoteAction == "com" || $curVoteAction == "uncom")
   {
	
	%numPlayers = getNumClients();
	
	%numTeamPlayers = 0;

	
	if($curVoteOption.voteTarget)
      	{
        	%sel = $curVoteOption;
        	
        	%team = Client::getteam(%sel);
        	
        }
      	
   	for(%i = 0; %i < %numPlayers; %i = %i + 1)
         {
        	%pl = getClientByIndex(%i);
		%plteam = Client::getTeam(%pl);
		
		if(%plteam != %team)
			continue;
		
		%numTeamPlayers = %numTeamPlayers + 1;
	}
	
   	
   	%otherteamplayers = %numPlayers - %numTeamPlayers;
   	
   	%minVotes = floor($Server::MinVotesPct * %numTeamPlayers);
 	
   	%votesabstain = %votesabstain - %otherteamplayers;
   	
   }
   else
   {	
   	%minVotes = floor($Server::MinVotesPct * %totalClients);
   	if(%minVotes < $Server::MinVotes)
   	%minVotes = $Server::MinVotes;
    }

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
      messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesabastain @ " abstentions.");
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
            messageAll(0, "Vote to " @ $curVoteTopic @ " passed: " @ %votesFor @ " to " @ %votesabstain @ ".");
            Admin::voteSucceded();
            $curVoteTopic = "";
            return;
         }
      }
      messageAll(0, "Vote to " @ $curVoteTopic @ " did not pass: " @ %votesFor @ " to " @ %votesAgainst @ " with " @ %votesabstain @ " abstentions.");
      Admin::voteFailed();
   }
   $curVoteTopic = "";
}

function TowerSwitch::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
   
 %team = GameBase::getTeam(%this);  
 
 
 
 if(%team == -1)
 	return;
 	
 if(%team == client::getTeam(%object))
 	return;
   
   %this.damage = %this.damage + %value;
   
   
   if(%this.damage > 4)
   {
 	%group = GetGroup(%this);			   
 	%dropPoints = nameToID(%group @ "/DropPoints");
	%oldDropSet = nameToID("MissionCleanup/TeamDrops" @ %team);
			   
 	Group::iterateRecursive(%group, GameBase::setTeam, -1);
        MessageAll(0, "Because the switch was damaged, " @ %this.objectiveName @ " reverted to neutral!~wCapturedTower.wav");
	$owned[%team] = $owned[%team] -1;
	$teamScore[%team] -= %this.scoreValue;
	$deltaTeamScore[%team] -= %this.deltaTeamScore;
	if(%dropPoints != -1)
	   {
	      for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
	      {
	            removeFromSet(%oldDropSet, %dropPoint);
	      }
	   }
	%this.damage = 0;
   }

}

function Server::finishMissionLoad()
{
   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   
   if($game::missiontype != "VIP")
   	{
   	exec(station);
   	exec(admin);
   	exec(observer);
   	exec(player);
   	}
   
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
