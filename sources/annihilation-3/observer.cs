$GuiModeCommand	= 2;
$LastControlObject = 0;

// rewrote the bulk of the functions here to allow for flexability. -Plasmatic 5/12/2006 8:09AM
function Observer::triggerDown(%client)
{
	%mode = %client.ObserverMode;
	%target = %client.ObserverTarget;
	if(%target)
		%type = getObjectType(%target);
		
	if(%mode != "")
		%action = %mode;	
	else if(%type != Net::PacketStream)
		%action = %type;
		
//	if(%action)
		eval(%action@"::triggerDown("@%client@");");
	
	if($debug)	
		echo(%action@"::triggerDown "@%this);
}

function Observer::triggerUp(%client)
{
}
function false::triggerUp(%client)
{
	%pl = client::getownedobject(%client);
	if(%pl != -1 && !Player::isDead(%client)) 
	{
		Client::setControlObject(%client, %pl);	
	//	Client::sendMessage(%client, 0, "You IDIOT! You forgot to send the client back..~wfemale2.wdsgst2.wav");
	}
}


function Observer::jump(%client)
{
	%mode = %client.ObserverMode;
	%target = %client.ObserverTarget;
	if(%target)
		%type = getObjectType(%target);
		
	if(%mode != "")
		%action = %mode;	
	else if(%type != Net::PacketStream)
		%action = %type;
		
//	if(%action)
		eval(%action@"::jump("@%client@");");
	
	if($debug)
		echo(%action@"::jump "@%this);
}

function false::jump(%client)
{
	%pl = client::getownedobject(%client);
	if(%pl != -1 && !Player::isDead(%client)) 
	{
		Client::setControlObject(%client, %pl);	
//		Client::sendMessage(%client, 0, "You IDIOT! You forgot to send the client back.. ~wfemale2.wdsgst2.wav");	
	}
}

function Observer::orbitObjectDeleted(%client)
{
	%target = %client.ObserverTarget;
//	Client::sendMessage(%client, 0, "You IDIOT! You forgot to send the client back on object delete.. ("@%target@")~wfemale2.wdsgst2.wav");
	%pl = client::getownedobject(%client);
	if(%pl != -1 && !Player::isDead(%client)) 
		Client::setControlObject(%client, %pl);	
}

function Observer::leaveMissionArea(%cl)
{
	//callback
}

function Observer::enterMissionArea(%cl)
{
	//callback	
}

//============================== 
//         TriggerUp
//============================== 

// overhauled these for flexability -plasmatic 5/12/2006 8:31AM
function dead::triggerDown(%client)
{
	if(%client.dieTime + $Server::respawnTime < getSimTime())
	{
		if(Game::playerSpawn(%client, true))
		{
			%client.ObserverMode = "";
			Observer::checkObserved(%client);
		}
	}
}

function ObserverAdmin::triggerDown(%client)
{
	Admin::observe(%client,%client.ObserverTarget);
}

function ObserverOrbit::triggerDown(%client)
{
	Observer::nextObservable(%client);
}

function ObserverFly::triggerDown(%client)
{
	%camSpawn = Game::pickObserverSpawn(%client);
	Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), 
	GameBase::getRotation(%camSpawn), true, true);
}

function justJoined::triggerDown(%client)
{
	// Some schooling for newbies.. -plasmatic 2.2
	if(%client.firstConnect == true)
	{
		if(%client.InSchool)
		{
			if(%client.InSchool < 8)
			{
				%client.InSchool++;
				NewbieSchool(%client);
				return;
			}
			else 
			{
				%client.firstConnect = false;
				%client.InSchool = "";
				%client.ObserverMode = "";
				Game::playerSpawn(%client, false);						
			}
		}
		else
		{				
			%client.InSchool = 1;
			NewbieSchool(%client);
			return;
		}
	}
	else
	{	
		%client.ObserverMode = "";
		Game::playerSpawn(%client, false);
	}
}

function pregame::triggerDown(%client)
{
	if($Server::TourneyMode)
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

//============================== 
//         Jump
//============================== 

function justJoined::jump(%client)	// space-bar will skip the intro -plasmatic 2.2
{
	%client.firstConnect = false;
	%client.InSchool = "";
	Observer::triggerDown(%client);
}

function ObserverFly::jump(%client)
{
	%client.ObserverMode = "ObserverOrbit";
	bottomprint(%client, "", 0);

	%client.ObserverTarget = %client;
	Observer::nextObservable(%client);
}

function ObserverOrbit::jump(%client)
{
	%lastObserved = %client.ObserverTarget;
	if($Annihilation::obsAlert && %lastObserved != %client && !%client.isAdmin)
	{
		bottomprint(%lastObserved, "<jc> No longer Being Observed by " @ Client::getName(%client), 15);
		client::sendmessage(%lastObserved,0,"No longer Being Observed by " @ Client::getName(%client));
	}
	%client.ObserverTarget = "";
	
	%client.ObserverMode = "ObserverFly";
	%camSpawn = Game::pickObserverSpawn(%client);
	Observer::setFlyMode(%client, GameBase::getPosition(%camSpawn), GameBase::getRotation(%camSpawn), true, true);
}

function ObserverAdmin::jump(%client)
{
	if(%client.ObserverMode == "dead")
	{
		if(%client.dieTime + $Server::respawnTime < getSimTime())
		{
			if(Game::playerSpawn(%client, true))
			{
				%client.ObserverMode = "";
				Observer::checkObserved(%client);
			}
		}
	}	
	Client::setControlObject(%client, %client);
	%pl = Client::getOwnedObject(%client);	
	%pl.invulnerable = false;

	%client.ObserverMode = "";
	bottomprint(%client, "", 0);	
}

//changed to echo observed players name on mode change, 
//and view any turret players controlling.. 2.2 plasmatic
function Observer::setAnnihilationOrbit(%client, %target)
{	
	Client::setControlObject(%client, Client::getObserverCamera(%client));
	bottomprint(%client, "<jc>Observing " @ Client::getName(%target)@".", 50);

	if(!%client.obsmode || %client.obsmode == "") Observer::setOrbitObject(%client, %target, 5, 5, 5);
	else if(%client.obsmode == 1) Observer::setOrbitObject(%client, %target, 15, 15, 15);
	else if(%client.obsmode == 2) Observer::setOrbitObject(%client, %target, 30, 30, 30);
	else if(%client.obsmode == 3) Observer::setOrbitObject(%client, %target, -3, -1, -0);
	else if(%client.obsmode == 4) Observer::setOrbitObject(%client, %target, -7, -7, -0);
	else if(%client.obsmode == 5) Observer::setFlyMode(%client, vector::add("0 0 1",GameBase::getPosition(Client::getControlObject(%target))), GameBase::getRotation(Client::getControlObject(%target)), true, true);	
	//	Observer::setOrbitObject(%client, %target, -18, -18, -0); //can only orbit around client's bah -plasmatic	
}

function Observer::isObserver(%clientId)
{
	return %clientId.ObserverMode == "ObserverOrbit" || %clientId.ObserverMode == "ObserverFly" || %clientId.ObserverMode == "ObserverAdmin";
}

function Observer::enterObserverMode(%clientId)
{
	if(%clientId.ObserverMode == "ObserverOrbit" || %clientId.ObserverMode == "ObserverFly")
		return false;
	Client::clearItemShopping(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	Client::setOwnedObject(%clientId, -1);
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%clientId.ObserverMode = "ObserverOrbit";
	if(Client::getTeam(%clientId) != -1)
		%clientId.LastTeam = Client::getTeam(%clientId);
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
		if(%cl.ObserverTarget == %client)
		{
			if(%cl.ObserverMode == "ObserverOrbit")
				Observer::setAnnihilationOrbit(%cl, %client);//Observer::setOrbitObject(%cl, %client, 5, 5, 5);
			else if(%cl.ObserverMode == "commander")
				Observer::setOrbitObject(%cl, %client, -3, -3, -3);
		}
	}
}

function Observer::setTargetClient(%client, %target)
{
	if(%client.ObserverMode != "ObserverOrbit")
		return false;
	%owned = Client::getOwnedObject(%target);
	if(%owned == -1)
		return false;
	Observer::setAnnihilationOrbit(%client, %target);	
	//Observer::setOrbitObject(%client, %target, 5, 5, 5);
	bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
//plasmatic
	if($Annihilation::obsAlert && !%client.isAdmin)
	{
		bottomprint(%target, "<jc>Being Observed by " @ Client::getName(%client), 15);
		client::sendmessage(%target,0,"Being Observed by " @ Client::getName(%client));
	}
	%client.ObserverTarget = %target;
	schedule("Observer::alert("@%client@","@%target@");",50);
	return true;
}

//notifying Observer and observee if still obsing same player after a while. -plasmatic
function Observer::alert(%client,%target)
{
	if($debug)
		echo("Observer::alert "@%client@", "@%target);
	if(%client.ObserverMode == "ObserverOrbit")
	{	
		%CurrentTarget = %client.ObserverTarget;
		if(%target == %CurrentTarget)
			{
			bottomprint(%client, "<jc>Observing " @ Client::getName(%target)@".", 50);
			if($Annihilation::obsAlert && !%client.isAdmin)
			{	
				bottomprint(%target, "<jc>Being Observed by " @ Client::getName(%client), 15);
				client::sendmessage(%target,0,"Being Observed by " @ Client::getName(%client));
			}		 
		//	schedule("Observer::alert("@%client@");",60);	
		}	 	
	}	
}

function Observer::nextObservable(%client)
{
	%lastObserved = %client.ObserverTarget;
	%nextObserved = Client::getNext(%lastObserved);
		if($Annihilation::obsAlert && %lastObserved != %client && !%client.isAdmin)
		{
		bottomprint(%lastObserved, "<jc> No longer Being Observed by " @ Client::getName(%client), 15);
		client::sendmessage(%lastObserved,0,"No longer Being Observed by " @ Client::getName(%client));
		}
	%ct = 128; // just in case
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

function Observer::prevObservable(%client)
{
}


function remoteSCOM(%clientId, %observeId)
{
	if(!evalspam(%clientId))
		return;	//plasm 3.0
		
	if(%observeId != -1)
	{
		if(Client::getTeam(%clientId) == Client::getTeam(%observeId) &&
			(%clientId.ObserverMode == "" || %clientId.ObserverMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand)
		{
			Client::limitCommandBandwidth(%clientId, true);
			if(%clientId.ObserverMode != "commander")
			{
				%clientId.ObserverMode = "commander";
				%clientId.lastControlObject = Client::getControlObject(%clientId);
			}
			Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
			Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
			%clientId.ObserverTarget = %observeId;
			Observer::setDamageObject(%clientId, %clientId);
		}
	}
	else
	{
		Client::limitCommandBandwidth(%clientId, false);
		if(%clientId.ObserverMode == "commander")
		{
			Client::setControlObject(%clientId, %clientId.lastControlObject);
			%clientId.lastControlObject = "";
			%clientId.ObserverMode = "";
			%clientId.ObserverTarget = "";
		}
	}
}