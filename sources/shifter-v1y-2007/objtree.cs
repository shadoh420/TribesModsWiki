$LoadedObjTree = "true";

function DumpObjectTree()
{
	if($debug) echo ("DUMPING OBJECT TREE");
	
	%c = 0;
	$PObjList = 0;
	
	for(%team=0;%team < 9;%team++)
	{
		%count[%team] = 0;
		%counts[%team] = 0;
		%monkey[%team] = 0;
		%mule[%team] = 0;
	}

	$NoInv = false;		
		
	for(%object = 8205; (%object < 9800); %object++)
	{
		if (GameBase::getDataName(%object) != "")
		{
			%name = GameBase::getDataName(%object);
			%team = GameBase::getTeam(%object);		  
			%objtype = getObjectType(%object);
			%objname = (GameBase::getDataName(%object));

			if (%objtype != "" && %team != "-1")
			{
				%tc = %count[%team];
				%ts = %counts[%team];
				if (%objname == "Generator")		{$PObj[%tc,%team] = %object; if($debug) echo ("Gens     - "@ $Server::teamName[%team] @ " - " @ %tc); %count[%team]++;}
				else if (%objname == "SolarPanel")	{$PObj[%tc,%team] = %object; if($debug) echo ("Solars   - "@ $Server::teamName[%team] @ " - " @ %tc); %count[%team]++;}
				else if (%objname == "PortGenerator")	{$PObj[%tc,%team] = %object; if($debug) echo ("PortGens - "@ $Server::teamName[%team] @ " - " @ %tc); %count[%team]++;}

				else if (%objname == "PulseSensor")			{$SObj[%ts,%team] = %object; if($debug) echo ("Lg Pulse - "@ $Server::teamName[%team] @ " - " @ %ts); %counts[%team]++;}
				else if (%objname == "MediumPulseSensor")	{$SObj[%ts,%team] = %object; if($debug) echo ("Md Pulse - "@ $Server::teamName[%team] @ " - " @ %ts); %counts[%team]++;}
				else if (%objname == "DeployablePulseSensor")	{$SObj[%ts,%team] = %object; if($debug) echo ("Dp Pulse - "@ $Server::teamName[%team] @ " - " @ %ts); %counts[%team]++;}

				else if(%objname == "InventoryStation") {%monkey[%team]++;}
				else if(%objtype != "Player") {%mule[%team]++;}

			}
		}
	}

	//=== Set some values for the mission bounds
	%temp = WaypointtoWorld("1023 1023");
	$mBounds[X,Max] = getWord(%temp,0);
	$mBounds[Y,Max] = getWord(%temp,1);
	%temp = WaypointtoWorld("0 0");
	$mBounds[X,Min] = getWord(%temp,0);
	$mBounds[Y,Min] = getWord(%temp,1);

	//=== The code below is no longer enabled for the most part, since I want Mortar Turrets to be
	//===  sentient all the time now.

	//=== If there is a team without either Invo Stations or Gens, make Mortar Turrets sentient
	//=== Why?  Because I'm cool like that.
	for(%team=0;%team<9;%team++)
	{
		if(%mule[%team] && (%monkey[%team] == 0 || %count[%team] == 0))
		{
			%mortars = true;
			//=== The "$NoInv" variable is used to track whether or not a map has Inventory stations in it.
			//===  if it doesn't FastFavs will work at any type of permanent station, including Ammo stations
			if($monkey[%team] == 0)
				$NoInv = true;
			if($debug) echo("No Inventory Stations/Generators on Team " @ $Server::TeamName[%team] @ ".");
		}
	}

	schedule ("DumpObjectTree();", 360);
}

function CheckObjectTree()
{
	for (%t = 0; %t < getNumTeams(); %t++)
	{
		echo ("Checking Team " @ %t);
		
		for (%tc = 0; $PObj[%tc,%t] != ""; %tc++)
		{
			if ($debug) echo ("Object on team " @ %tc @ " - " @ $Server::TeamName[%t] @ " = " @ $PObj[%tc,%t]);
		}
	}
}

function ClearObjectTree()
{
	for (%t = 0; %t < 9; %t++)
	{
		for (%tc = 0; %tc < 20; %tc++)
		{
			$PObj[%tc,%t] = "";
		}
	}
}


//=== Oddly enough, this function returns true if the power ISN'T down.  That helps understand it a little better
function IsPowerDown(%t)
{
	//=== These two missions have problems with checking gens for a variety of reasons.  As such we'll hard code it
	//===  to return "true".
	if($missionName == "desert_of_death" || $missionName == "Snowblind")
		return True;

	if ($debug) echo ("Checking Team " @ $Server::TeamName[%t] @ " for Power Devices");
		
	for (%tc = 0; $PObj[%tc,%t] != ""; %tc++)
	{
		%object = $PObj[%tc,%t];
		if (GameBase::getDamageState(%object) == "Enabled")
		{
			if($debug) echo ("Team " @ $Server::TeamName[%t] @ "'s power is up. ");
			return True;
		}
	}
	
	if (!%tc || %tc < 1)
	{
		if ($debug) echo ("Team " @ $Server::TeamName[%t] @ " has no power units to check. ");
		return True;
	}
	if ($debug) echo ("Team " @ $Server::TeamName[%t] @ "'s power is down ");
	return False;
}

function IsNetWorkDown(%t)
{
	if ($debug) echo ("Checking Team " @ $Server::teamName[%t] @ " for Network Devices");
		
	for (%tc = 0; $SObj[%tc,%t] != ""; %tc++)
	{
		%object = $SObj[%tc,%t];
		if (GameBase::getDamageState(%object) == "Enabled")
		{
			if ($debug) echo ("Team " @ $Server::teamName[%t] @ "'s network is up. ");
			return True;
		}
	}
	
	if (!%tc || %tc < 1)
	{
		if ($debug) echo ("Team " @ $Server::teamName[%t] @ " has no sensors to check. ");
		return True;
	}
	if($debug) echo ("Team " @ $Server::teamName[%t] @ "'s sensors are down.");
	return False;
}
