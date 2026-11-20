//===================================================================================================
// This module implements two different features:
// 1) A radar "pulse" for the new OH-58D Kiowa Warrior Chopper
//	-Identical to normal sensors, except it only occures as a split second pulse when "fired"
// 	-Probably done by spawning an actual sensor staticshape above or below the chopper for that time.
// 2) An aircraft detection system for use on all Jets, and extended range use for the new E-3 AWACS
//	-Probably will switch the team of the jet over to the enemy when the jet is visible to an enemy 
//	 radar. This will make them visible to the enemy.
//	-Will use LOS to all other jets.
//	-Normal large sensors will have one of these.
//
// Obviously, the second feature is the one focused primarilly here. The radar pulse will be in here
// as well, and first, but it will only be in one or two methods.
//===================================================================================================

//===================================================================================================
// Sensor "pulse" for the OH-58D
//===================================================================================================

$SensorPulse::VerticalDistance = 3;
$SensorPulse::PulseTime = 0.5;
$SensorPulse::UpdateTime = 0.05;

function SensorPulse::Ping(%vehicle,%player)
{
	// Find a spot above our vehicle.
	%add = "0 0 "@$SensorPulse::VerticalDistance;

	%rot = GameBase::getRotation(%vehicle);                            
	%pos = getBoxCenter(%vehicle);
	%pos = GetOffSetRot(%add,%rot,%Pos);
	
	// Spawn a sensor at that spot
	%sensor = newObject("","Sensor","KiowaPulseSensor",true);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	GameBase::setPosition(%sensor,%pos);
	GameBase::setActive(%sensor,true);

	// Make sure it stays with the vehicle.
	SensorPulse::UpdatePingPos(%vehicle,%sensor);

	// Remove sensor after a set time.
	schedule("DeleteObject("@%sensor@");",$SensorPulse::PulseTime);
}

function SensorPulse::UpdatePingPos(%vehicle,%sensor)
{
	// As long as it hasn't been deleted yet.
	if(Gamebase::Getposition(%sensor) == "0 0 0" || Gamebase::GetDataName(%sensor) != KiowaPulseSensor)
		return;

	%add = "0 0 "@$SensorPulse::VerticalDistance;

	%rot = GameBase::getRotation(%vehicle);                            
	%pos = getBoxCenter(%vehicle);
	%pos = GetOffSetRot(%add,%rot,%Pos);
	gamebase::setposition(%sensor,%pos);

	schedule("SensorPulse::UpdatePingPos("@%vehicle@","@%sensor@");",$SensorPulse::UpdateTime);
}

//===================================================================================================
// Aircraft Radar Detection
//===================================================================================================


$Radar::ScanTime = 1.0; // scan once every 0.1 seconds.


$Radar::Range[Tomcat] = 800;
$Radar::Range[Falcon] = 400;
$Radar::Range[Warthog] = 400;
$Radar::Range[Gunship] = 400;
$Radar::Range[Hercules] = 400;
$Radar::Range[Bomber] = 400;
$Radar::Range[Sentry] = 2400;

$Radar::Range[Apache] = 400;
$Radar::Range[Kiowa] = 400;
$Radar::Range[Hind] = 400;
$Radar::Range[Blackhawk] = 400;

$Radar::Range[PulseSensor] = 1000;
$Radar::Range[MediumPulseSensor] = 625;
$Radar::Range[DeployableRadar] = 400;


function Radar::Add(%this)
{
	// Shouldn't let them add a radar if it has no range.
	%range = $Radar::Range[GameBase::getDataName(%this)];

	if(%range == "" || %range < 0)
		return;
	if($Radar::List == "")
		$Radar::List = 0;
	
	$Radar::List[$Radar::List] = %this;
	$Radar::List++;
}

function Radar::Remove(%this)
{
	%done = false;
	for(%x=$Radar::List;%x>=0 && !%done;%x--)
	{
		if($Radar::List[%x] == %this)
		{
			for(%pack = %x;%pack <= $Radar::List; %pack++)
			{
				$Radar::List[%pack] = $Radar::List[(%pack)+1];
			}
			$Radar::List--;
			%done = true;
		}
	}
}

function Radar::Clear()
{
	for(%x=$Radar::List;%x>=0;%x--)
	{
		$Radar::List[x] = "";
	}
	$Radar::List = 0;
}


function Radar::Detectable::Add(%this)
{
	// Shouldn't let them add a detectable if it isn't an aircaft.
	if(getObjectType(%this) != "Flier" || !Vehicle::isAircraft(%this))
		return;

	if($Radar::Detectable::List == "")
		$Radar::Detectable::List = 0;
	
	$Radar::Detectable::List[$Radar::Detectable::List] = %this;
	$Radar::Detectable::List++;

}

function Radar::Detectable::Remove(%this)
{
	%done = false;
	// Remove AI from our list.
	for(%x=$Radar::Detectable::List;%x>=0 && !%done;%x--)
	{
		if($Radar::Detectable::List[%x] == %this)
		{
			for(%pack = %x;%pack <= $Radar::Detectable::List; %pack++)
			{
				$Radar::Detectable::List[%pack] = $Radar::Detectable::List[(%pack)+1];
			}
			$Radar::Detectable::List--;
			%done = true;
		}
	}
}

function Radar::Detectable::Clear()
{
	for(%x=$Radar::Detectable::List;%x>=0;%x--)
	{
		$Radar::Detectable::List[x] = "";
	}
	$Radar::Detectable::List = 0;
}

function Radar::ActivateRadar(%this)
{
	if(!$Radar::isActive && Vehicle::isAircraft(%this))
	{
		$Radar::IsActive = true;
		Radar::CheckForEnemyAirCraft();
	}
}

function Radar::CheckForEnemyAirCraft()
{
	// This will keep track of all our aircraft currently being detected.
	//%detectedAircraft[%x] = true;
	// For each radar capable object...
	for(%x = 0; %x < $Radar::List;%x++)
	{
		%this = $Radar::List[%x];

		%RadarPos = gamebase::GetPosition(%this);
		%name = gamebase::GetDataName(%this);
		%range = $Radar::Range[%name];
		if(isObject(%this) && getObjectType(%this) == "Sensor")
		{
			// Then we're a sensor or SAM or something.
			%Radarteam = gamebase::GetTeam(%this);
		} else
		{
			// Then we have to be an aircraft, and must use the owner's team.
			%client = gamebase::GetControlClient(%this);
			%Radarteam = gamebase::GetTeam(%client);
		}

		// Make sure this has a range, and is on a valid team.
		if((%Radarteam == 1 || %Radarteam == 0) && %range != "" && %range > 0)
		{
			// Check all Aircraft in range. Use our Detectable list for this.
			for(%y = 0; %y < $Radar::Detectable::List;%y++)
			{
				%enemy = $Radar::Detectable::List[%y];
				
				// If this isn't an aircraft, don't do anything
				if(isObject(%enemy) && getObjectType(%enemy) == "Flier" && Vehicle::isAircraft(%enemy))
				{
			
					// If there's no controller, immediately set this to observer team.
					if(gamebase::GetControlClient(%enemy) != -1)
					{
						// Make sure The controller isn't on our team.
						if(Gamebase::GetTeam(gamebase::GetControlClient(%enemy)) != %Radarteam)
						{			

							%enemyPos = gamebase::getposition(%enemy);
							// Find out if they're in range.


							%testRange = %range;
							
							// If the enemy has an ECM, our range gets cut in half.
							if(%enemy.ECM)
								%testRange = %testRange/2;

							// make sure he's in range before the wasteful LOS
							if(Vector::GetDistance(%radarPos,%enemyPos) < %testRange)
							{
								%mask = (~0 ^ $BitMask::Vehicle) ^ $BitMask::Player;
								%los = getLOSInfo(vector::Add(%radarPos,"0 5 0"),%enemyPos,%mask);
								%losObj = $LOS::Object;


								if(!%los)
								{
									// If we've got an LOS to them, they should be seen.
									%detectedAircraft[%y] = true;
								}
							}
						}
					} else
					{
						%unpilotedAircaft[%y] = true;
					}
				}
			}
		}
	}

	// For all the detectable aircraft..
	for(%x = 0; %x < $Radar::Detectable::List;%x++)
	{
		%this = $Radar::Detectable::List[%x];
		// We will *only* switch the team of aircraft
		if(isObject(%this) && getObjectType(%this) == "Flier" && Vehicle::isAircraft(%this))
		{

			// If they're on our list, make sure their team is set opposite.
			if(%detectedAircraft[%x])
			{
				%opTeam = gamebase::GetTeam(gamebase::GetControlClient(%this));
				if(%opTeam == 1)
					%opTeam = 0;
				else
					%opTeam = 1;
				Gamebase::Setteam(%this,%opTeam);
			}
			// If it isn't piloted, set its team to null.
			else if(%unpilotedAircraft[%x] || gamebase::GetControlClient(%this) == -1)
			{
				Gamebase::Setteam(%this,-1);
			}
			// otherwise, make sure their team is set the same.
			else
			{
				Gamebase::Setteam(%this,gamebase::GetTeam(gamebase::GetControlClient(%this)));
			}
		}
	}

	schedule("Radar::CheckForEnemyAirCraft();",$Radar::ScanTime);
}


function check32(%client)
{
	for(%x=0;%x<32;%x++)
	{
		checkLOS(%client,1<<%x);
	}
return;
	schedule("Check32("@%client@");",1);
}

function checkLOS(%client,%mask)
{
	if(Gamebase::GetLOSInfo(client::GetOwnedObject(%client),1000))
	{
		%tarPos = $LOS::Position;
		%los = getLOSInfo(vector::add(gamebase::Getposition(%client),"0 0 3"),%tarPos,%mask);
		if(%los)
		{
			%obj = $LOS::Object;
echo(%obj);
			echo(getObjectType(%obj) @" " @Gamebase::GetDataName(%obj) @" -- " @ %mask);
		}
	}
}

$BitMask::Terrain = 1<<0;
$BitMask::InterriorShape = 1<<0;
$BitMask::StaticShape = 1<<1;

$BitMask::Vehicle = 1<<3;
$BitMask::Player = 1<<4;
