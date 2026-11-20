$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client)
{
}

function Observer::orbitObjectDeleted(%cl)
{
}

function Observer::leaveMissionArea(%cl)
{
}

function Observer::enterMissionArea(%cl)
{
}

function Observer::triggerUp(%client)
{
	%spawnTime = GetSpawnTime(%client);
   if(%client.observerMode == "dead")
   {
     
	// DropShips::CanSpawn() checks to make sure there's a drop point for them to spawn at. If not.. they don't spawn.
      if(%client.dieTime + %spawnTime < getSimTime() && DropShips::CanSpawn(%client))
      {
         if(Game::playerSpawn(%client, $matchStarted))
         {
            %client.observerMode = "";
            Observer::checkObserved(%client);
         }
      } else
      {
	Observer::nextObservableTeamMate(%client);
      }
   }
   else if(%client.observerMode == "observerOrbit")
      Observer::nextObservable(%client);
   else if(%client.observerMode == "observerFly")
   {
      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
   else if((%client.dieTime + %spawnTime - 10) < getSimTime() && %client.observerMode == "justJoined" && DropShips::CanSpawn(%client)) //Diddily bug fix. Minus 10 to be nice, and so those who behave don't wait.
   {
      %client.observerMode = "";
      Game::playerSpawn(%client, true);
   }
   else if(%client.observerMode == "pregame" && $Server::TourneyMode)
   {
      if($CountdownStarted)
         return;

      if(%client.notready)
      {
         %client.notready = "";
         MessageAll(0, Client::getName(%client) @ " is READY.");
         if(%client.notreadyCount < 3)
            bottomprint(%client, "<f1><jc>Waiting for match start (FIRE if not ready).", 0);
         else 
            bottomprint(%client, "<f1><jc>Waiting for match start.", 0);
      }
      else
      {
         %client.notreadyCount++;
         if(%client.notreadyCount < 4)
         {
            %client.notready = true;
            MessageAll(0, Client::getName(%client) @ " is NOT READY.");
            bottomprint(%client, "<f1><jc>Press FIRE when ready.", 0);
         }
         return;
      }
      Game::CheckTourneyMatchStart();
   }
}

function Observer::jump(%client)
{
	if(%client.ObsJumped)
		return;
	%client.ObsJumped = true;
	schedule(%client@".ObsJumped = false;", 0.5);

	
   if($CamoActivate[$CamoBody[%client]] == 1)
   {
	if((getSimTime() - $CamoBody[%client].packTime) > 2 || !$CamoBody[%client].packTime)
	{
		$CamoBody[%client].packTime = getSimTime();
	 	CamoPackUnBury($CamoBody[%client]);
	}
   }
   else if(%client.observerMode == "observerFly")
   {
      %client.observerMode = "observerOrbit";
      %client.observerDist = 5;
      %client.observerTarget = %client;
      Observer::nextObservable(%client);
   }
   else if(%client.observerMode == "observerOrbit"&& %client.observerDist == 5)
   {
      if($ObserverFirstPerson||%client.isadmin)
	{
      %client.observerDist = -1;
      Observer::checkObserved(%client.observerTarget);
	}
      else if ($ObserverWorm && $Worm::WormCount)
	{
      	%client.observerMode = "observerWorm";
 	Worm::observe(%client);
	}
      else
	{

      	%client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
}

   }
   else if(%client.observerMode == "observerOrbit" && %client.observerDist == -1)
   {
	%client.observerTarget = "";
	%client.observerDist = 5;
      if(($ObserverWorm || %client.isadmin) && $Worm::WormCount)
	{
      	%client.observerMode = "observerWorm";
 	Worm::observe(%client);
	}
      else
	{

      	%client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
}
    
   }
   else if(%client.observerMode == "observerWorm")
   {
      %client.observerTarget = "";
      %client.observerMode = "observerFly";

      %camSpawn = Game::pickObserverSpawn(%client);
      Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	      GameBase::getRotation(%camSpawn), true, true);
   }
}

function Observer::isObserver(%clientId)
{
   return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly" ||  %clientId.observerMode == "observerWorm" ;
}

function Observer::enterObserverMode(%clientId)
{
   if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
      return false;
   %clientId.observerDist = 5;
   Client::clearItemShopping(%clientId);
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
	   Player::kill(%clientId);
	}
   Client::setOwnedObject(%clientId, -1);
   Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %clientId.observerMode = "observerWorm";
   GameBase::setTeam(%clientId, -1);
   Observer::jump(%clientId);
   remotePlayMode(%clientId);
   return true;
}

function Observer::checkObserved(%client)
{
   // this function loops through all the clients and checks
   // if anyone was observing %client... if so, it updates that
   // observation to reflect the new %client owned object.

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerTarget == %client)
      {
         if(%cl.observerMode == "observerOrbit")
{
	if(%cl.observerDist)
      	   Observer::setOrbitObject(%cl, %client, %cl.observerDist, %cl.observerDist, %cl.observerDist);
	else
	   Observer::setOrbitObject(%cl, client::getcontrolobject(%client), %cl.observerDist, %cl.observerDist, %cl.observerDist);

}
         else if(%cl.observerMode == "commander")
   		   Observer::setOrbitObject(%cl, %client, -3, -3, -3);
      }
   }
}

function Observer::setTargetClient(%client, %target)
{
      	   
   if(%client.observerMode != "observerOrbit")
      return false;
   %owned = Client::getOwnedObject(%target);
   if(%owned == -1)
      return false;
	if(%client.observerDist)
      	   Observer::setOrbitObject(%client, %target, %client.observerDist, %client.observerDist, %client.observerDist);
	else
	   Observer::setOrbitObject(%client, client::getcontrolobject(%target), %client.observerDist, %client.observerDist, %client.observerDist);

   bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
   %client.observerTarget = %target;
   return true;
}

function Observer::nextObservable(%client)
{
   %lastObserved = %client.observerTarget;
   %nextObserved = Client::getNext(%lastObserved);
   %ct = 128;  // just in case
   while(%ct--)
   {
      if(%nextObserved == -1)
      {
         %nextObserved = Client::getFirst();
         continue;
      }
      %owned = Client::getOwnedObject(%nextObserved);
      if(%nextObserved == %lastObserved && %owned == -1)
      {
         Observer::jump(%client);
         return;
      }
      if(%owned == -1)
      {
         %nextObserved = Client::getNext(%nextObserved);
         continue;
      }
      Observer::setTargetClient(%client, %nextObserved);
      return;
   }
   Observer::jump(%client);
}

function Observer::nextObservableTeammate(%client)
{
   	%lastObserved = %client.lastObservedTeammate;
   	%nextObserved = Client::getNext(%lastObserved);
	%ct = 128;  // just in case

	while(%ct--)
	{
		if(%nextObserved == -1)
			%nextObserved = Client::getFirst();
		if(%nextObserved == %lastObserved)
			return;
		if(Client::getTeam(%nextObserved) == Client::getTeam(%client))
		{
			if(%nextObserved.observerMode != "dead")
			{
				Observer::setOrbitObject(%client, %nextObserved, 5, 5, 5);
				%client.lastObservedTeammate = %nextObserved;
  				return true;
			} else if(%nextObserved.observerMode == "dead")		
			{
				if(%nextObserved.lastCorpse != -1 && %nextObserved.lastCorpse != "") 
				{
					Observer::setOrbitObject(%client, %nextObserved.lastCorpse, 5, 5, 5);
					%client.lastObservedTeammate = %nextObserved;
  					return true;	
				}	
			}
		}
		%nextObserved = CLient::getNext(%nextObserved);
	}
	return false;
}

function Observer::prevObservable(%client)
{
}

function remoteSCOM(%clientId, %observeId)
{
   if (%observeId != -1)
   {
      if (Client::getTeam(%clientId) == Client::getTeam(%observeId) &&
         (%clientId.observerMode == "" || %clientId.observerMode == "commander") 
	&& Client::getGuiMode(%clientId) == $GuiModeCommand && $CamoActivate[$CamoBody[%clientid]] != 1)
      {
         Client::limitCommandBandwidth(%clientId, true);
         if(%clientId.observerMode != "commander" )
         {
            %clientId.observerMode = "commander";
	         %clientId.lastControlObject = Client::getControlObject(%clientId);
         }
	      Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		   Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
         %clientId.observerTarget = %observeId;
         Observer::setDamageObject(%clientId, %clientId);
      }
   }
   else 
   {
      Client::limitCommandBandwidth(%clientId, false);
      if(%clientId.observerMode == "commander")
      {
         Client::setControlObject(%clientId, %clientId.lastControlObject);
		   %clientId.lastControlObject = "";
         %clientId.observerMode = "";
         %clientId.observerTarget = "";
	   }
   }
}