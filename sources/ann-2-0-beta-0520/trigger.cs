//----------------------------------------------------------------------------

TriggerData GroupTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function GroupTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle")
	{
		%group = getGroup(%this);
 		%count = Group::objectCount(%group);
 		for(%i = 0; %i < %count; %i++) 
 			GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
	}
}	

function GroupTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle")
	{
		%group = getGroup(%this);
		%count = Group::objectCount(%group);
		for(%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigLeave",%object,%this);
	}
}

function GroupTrigger::onContact(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle")
	{
		%group = getGroup(%this);
		%count = Group::objectCount(%group);
		for(%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigger",%object,%this);
	}
}

function GroupTrigger::onActivate(%this)
{
}

function GroupTrigger::onDeactivate(%this)
{
}


//new here for teleporters in mission editor. -plasmatic
//----------------------------------------------------------------------------

TriggerData TeleTrigger
{
	className = "Trigger";
	rate = 1.0;
};
function TeleporterSimSet(%this)
{
	%teleset = nameToID("MissionCleanup/TeleportSet"@%this);
	if(%teleset == -1)
	{
		%group = newObject("TeleportSet"@%this, SimSet);
		addToSet(MissionCleanup, %group);
	}
}

// -yes you can use multiple triggers and multiple drop points -plasmatic

function TeleTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle" || %type == "Flier")
	{
		%client = Player::getclient(%object);
		if(GameBase::getControlClient(%object) != %client) %client = GameBase::getControlClient(%object);
		if(Client::getTeam(%client) != GameBase::getTeam(%this) && GameBase::getTeam(%this) != -1) return;
		%group = getGroup(%this);
 		%count = Group::objectCount(%group);
 		for(%i = 0; %i < %count; %i++)
 			{ 
 			%data = GameBase::getDataName(Group::getObject(%group,%i));
 			if(%data == TeleDropMarker)  
 				{
 				%DropCount++;	
 				%droppos = Group::getObject(%group,%i);
 				TeleporterSimSet(%this);
 				addToSet("MissionCleanup/TeleportSet"@%this, %droppos);	
 				}
 			}
 			
	// pick a random tele point within the set -plasmatic
 			%spawnIdx = floor(getRandom() * (%DropCount - 0.1));
			%group = nameToID("MissionCleanup/TeleportSet"@%this);		
 			%newpos = Group::getObject(%group,%spawnIdx);	
 		
 		if(GameBase::GetPosition(%newpos) != "0 0 0")
 			{
 			GameBase::playSound(%object, ForceFieldOpen, 0);
			GameBase::playSound(%this, ForceFieldOpen, 0);
			Client::sendMessage(%client, 0, "You have been teleported.~wshieldhit.wav");
			GameBase::SetPosition(%object, GameBase::GetPosition(%newpos));
			%Trot = GameBase::getRotation(%newpos); 
			GameBase::setRotation(%object,%Trot);
			GameBase::startFadeIn(%object);	
 			} 
 		else echo("!! WARNING !! No matching teleport drop point in group!!");		
	}
}	


function GroupTrigger::onActivate(%this)
{
}

function GroupTrigger::onDeactivate(%this)
{
}
