// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

TriggerData GroupTrigger
{
	className = "Trigger";
	rate = 1.0;
};

function GroupTrigger::onEnter(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
 		%count = Group::objectCount(%group);
 		for (%i = 0; %i < %count; %i++) 
 			GameBase::virtual(Group::getObject(%group,%i),"onTrigEnter",%object,%this);
	}
}	

function GroupTrigger::onLeave(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigLeave",%object,%this);
	}
}

function GroupTrigger::onContact(%this,%object)
{
	%type = getObjectType(%object);
	if(%type == "Player" || %type == "Vehicle") {
		%group = getGroup(%this); 
		%count = Group::objectCount(%group);
		for (%i = 0; %i < %count; %i++) 
			GameBase::virtual(Group::getObject(%group,%i),"onTrigger",%object,%this);
	}
}

function GroupTrigger::onActivate(%this)
{
}

function GroupTrigger::onDeactivate(%this)
{
}
