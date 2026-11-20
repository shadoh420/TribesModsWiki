exec(ASAttackSeqs);


function SpawnAIVehicle(%type,%pos,%team)
{
	
	%pos = vector::add(%pos,"0 0 100");
	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,%type.description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,Client::getTeam(%clientId));
	GameBase::startFadeIn(%vehicle);
	GameBase::setPosition(%vehicle,%Pos);
//	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);

	// Spawn AI
	%aiName = SpawnAIAt(vector::add(%pos,"0 0 10"),%team,"Pilot");
	AI::DirectiveWaypoint(%aiName, vector::add(%Pos,"0 100 0"), 1);
echo(AI::getId(%aiName));
echo(Client::getOwnedObject(AI::getId(%aiName)));
	vehicle::oncollision(%vehicle,Client::getOwnedObject(AI::getId(%aiName)));
}

function go()
{
	Airstrike::spawnvehicle(FalconMoveVehicle,"0 0 0",2048,MavRocket);	
}

function AirStrike::AirCombat()
{
	%type = MoveWarthogVehicle;
	%pos = "-371 0 17";
	%player = 2048;
	%seq = 4;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,1);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);

	%target = %vehicle;

	%type = TomcatMoveVehicle;
	%pos = "-371 0 17";
	%player = 2048;
	%seq = 1;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	%vehicle.lockTarget = %target;
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,0);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
}

function AirStrike::NapalmStrike()
{
	AirStrike::spawnvehicle(MoveWarthogVehicle,"-35 -2 38",2048,ASNapalmBomb,3);	
}

function AirStrike::NapalmStrike2()
{
	AirStrike::spawnvehicle(MoveWarthogVehicle,"-35 -2 38",2048,ASNapalmBomb, 5);
	
}

function AirStrike::BlackhawkOne()
{
	%type = MoveBlackhawkExtractionVehicle;
	%player = 2048;
	%pos = "243 10 26";
	%seq = 2;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,0);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
	
}

function AirStrike::Blackhawktwo()
{
	%type = MoveBlackhawkExtractionVehicle;
	%player = 2048;
	%pos = "-525 -3 10";
	%seq = 3;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,0);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
	
}


function AirStrike::BlackhawkThree()
{
	%type = MoveBlackhawkExtractionVehicle;
	%player = 2048;
	%pos = "498 -145 35";
	%seq = 4;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,1);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
	
}


function AirStrike::BlackhawkFour(%pos)
{
	%type = MoveBlackhawkExtractionVehicle;
	%player = 2048;
	%seq = 5;

	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,1);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
	
}


function AirStrike::spawnvehicle(%type,%pos,%player,%bombtype,%seq)
{
	// Spawn Vehicle
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,gamebase::getTeam(%player));
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);
	%type2 = %type;
	%type = Vehicle::GetDataName(%vehicle);
	%vehicle.targetpos = %pos;
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	return;
	
	if(%type == MoveWarthogVehicle || %type2 == MoveWarthogVehicle )
	{
		//schedule("Airstrike::StartAttackRun("@%vehicle@","@%player@","@%Type2@","@%seq@");",18.55,%vehicle);
		schedule("Airstrike::StartAttackRun("@%vehicle@","@%BombType@","@%player@");",18.55,%vehicle);
	}
	if(%type == FalconMoveVehicle)
	{
		%type = Vehicle::GetDataName(%vehicle);
		%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
		%vehicle.group = %group;
		AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);
	}
	else if(%type == BomberMoveVehicle)
	{
		if($bomberCount[%player] <= 2)
		{
			$BomberCount[%player]++;
			%Bnum = $bomberCount[%player];
			%dist = 20;
			%num = 6;
			if(%BNum > 4)
				%pos = vector::add($DefaultBomberPos[%player],(-1*(%BNum-(%num/3))*%Dist)@" "@(-1*floor(((%BNum)/2)+0.5)*%Dist)@" 0");
			else
				%pos = vector::add($DefaultBomberPos[%player],(pow(-1,(%BNum))*floor(((%BNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%BNum)/2)+0.5)*%Dist)@" 0");
			Airstrike::spawnvehicle(%type,%pos,%player,%bombtype);
		} else
		{
			schedule("$bomberCount["@%player@"] = 0;",1,%player);
		}
		schedule("removeVehicle("@%vehicle@");",60,%vehicle);
		schedule("Airstrike::BomberStartBombing("@%vehicle@","@%BombType@","@%player@",0);",22+getRandom(),%vehicle);
	}
}

function Airstrike::StartFire(%vehicle,%bombtype,%player)
{
	if(%vehicle.isFiring)
	{
		Airstrike::FireWeap(%vehicle,%bombtype,%player);
		schedule("AirStrike::StartFire("@%vehicle@","@%bombType@","@%player@");",%vehicle.isFiring);
	}
}

function Airstrike::FireWeap(%vehicle,%weapName,%player)
{
	if(%vehicle && !%vehicle.dead && gamebase::Getposition(%vehicle) != "0 0 0")
	{
		%this = %vehicle;
		%vel = Item::getVelocity(%this);
		%playerVel = %vel;
		%rot = GameBase::getRotation(%this);   
		
		// Napalm is different...                          
		if(%weapName == ASNapalmBomb)
		{
			
			AirStrike::DropNap(%this,%weapName,%player);
			schedule("AirStrike::DropNap("@%this@","@%weapName@","@%player@");",0.2);
			schedule("AirStrike::DropNap("@%this@","@%weapName@","@%player@");",0.4);
			schedule("AirStrike::DropNap("@%this@","@%weapName@","@%player@");",0.8);
		} else
		{
		  if(%this && !%this.dead && gamebase::getposition(%this) != "0 0 0")
		  {
			%pos = getBoxCenter(%this);
			%pos = GetOffSetRot("0 2.5 -2",%Rot,%Pos);
			for(%weaponNum=0;%weaponNum<%vehicle.numToFire;%WeaponNum++)
			{
				// If we have an odd number of weapons to fire.
				if((%vehicle.numToFire%2) == 1)
					%mod = 1; //Move things by 1
				else
					%mod = 2; //Else move things up 2				
	
				// If were sweep winged, give us a sweep
				if($VehicleSWType[Vehicle::getDataName(%vehicle)])
					%pos = GetOffSetRot("0 "@ -0.1*floor((%weaponNum+%mod)/2) @" 0",%Rot,%Pos);		
	
				// Calculate our launch position
				%pos = GetOffSetRot(
					pow(-1,(%mod+%weaponNum))*$VehicleHPSpace[Vehicle::getDataName(%vehicle)]*floor((%weaponNum+%mod)/2) @" 0 0",%Rot,%Pos);	

				// Pirmary weapon, or a non-hardpoint Put on nose.
				%transorg = GameBase::getMuzzleTransform(%this);
				%transform = getword(%transorg,0)@" "@getword(%transorg,1)@" "@getword(%transorg,2)@" "@
						getword(%transorg,3)@" "@getword(%transorg,4)@" "@getword(%transorg,5)@" ";
				
				%transform = %transform @ %Rot @" "@ %pos;

				if(player::GetClient(%player) == -1)
				{
					%player = client::GetControlObject($AirStrike::Client[%player]);
				}
				if(player::GetClient(%player) == -1)
				{
					%player = %this;
				}
				if(%player && %player != -1 && %player != "")
					if(%this.lockTarget && %this.lockTarget != -1 && %this.lockTarget != "") 
						Projectile::spawnProjectile(%weapName, %transform, %player, %playerVel,%this.lockTarget);
					else
					{
						%proj = Projectile::spawnProjectile(%weapName, %transform, %player, %playerVel);
						%proj.airstrikeProj = 1;
					}
				GameBase::playSound(%this, $WeaponSound[%weapName], 3);
			}	
		  }
		}
	}
}

function AirStrike::DropNap(%this,%weapName,%player)
{
	ECHO(GAMEBASE::GETPOSITION(%THIS));
	if(%this && !%this.dead && gamebase::getposition(%this) != "0 0 0")
	{
		%vel = Item::getVelocity(%this);
		%playerVel = %vel;
		%rot = GameBase::getRotation(%this);                             

		%pos = getBoxCenter(%this);
		%pos = GetOffSetRot("0 2.5 -2",%Rot,%Pos);
		// Pirmary weapon, or a non-hardpoint Put on nose.
		%transorg = GameBase::getMuzzleTransform(%this);
		%transform = getword(%transorg,0)@" "@getword(%transorg,1)@" "@getword(%transorg,2)@" "@
				getword(%transorg,3)@" "@getword(%transorg,4)@" "@getword(%transorg,5)@" ";
			
		%transform = %transform @ %Rot @" "@ %pos;
		if(%player && %player != -1 && %player != "")
			Projectile::spawnProjectile(%weapName, %transform, %player, %playerVel);
		GameBase::playSound(%this, $WeaponSound[%weapName], 3);
	}
}

function AirStrike::SpawnPathMarkers(%targetPos,%vehicle,%type,%Seq)
{

	%curPaths = ""@%vehicle;
	// Make our group
	%returnGroup = newObject("AirStrikePath"@%curPaths, SimGroup);
	addToSet("MissionCleanup","AirStrikePath"@%curPaths);

	// Initial point
	for(%x=0;%x<$AS::C[%type,%seq];%x++)
	{
		%pos = vector::Add(%targetPos,$AirStrike::Path[%type,%seq,%x]);

		// Switch the comments on the next to lines if you want to see your waypoints in the command for testing.
		%marker = newObject("",Marker,PathMarker,true);
//		%marker = newObject("",Marker,MapMarker,true);

		gamebase::Setposition(%marker,%pos);
		%marker.rotChange = $AirStrike::PathRotChange[%type,%seq,%x];
		if(%x == 0)
			gamebase::setRotation(%marker,vector::GetRotAim(%pos,vector::Add(%targetPos,$AirStrike::Path[%type,%seq,%x+1])));
		addToSet("MissionCleanup/AirStrikePath"@%curPaths,%marker);
		if(%x ==  $AirStrike::PathMarked[%type,%seq])
			%vehicle.markedmarker = %marker;
		
		%cnt = 0;
		%temp[%cnt] = $AirStrike::PathFire[%type,%seq,%x];
		%cnt++;
		%temp[%cnt] = $AirStrike::PathFunction[%type,%seq,%x];
		%cnt++;
		%temp[%cnt] = $AirStrike::PathExit[%type,%seq,%x];
		%cnt++;
		%temp[%cnt] = $AirStrike::PathFireCont[%type,%seq,%x];
		%cnt++;
		%temp[%cnt] = $AirStrike::PathRoll[%type,%seq,%x];
		%cnt++;
		
		for(%y =0;%y<%cnt;%y++)
		{
			
			if(  %temp[%y] || %temp[%y] != "")
			{
			
				%pos = vector::Add(%targetPos,$AirStrike::Path[%type,%seq,%x]);

				// Switch the comments on the next to lines if you want to see your waypoints in the command for testing.
				%marker = newObject("",Marker,PathMarker,true);
//				%marker = newObject("",Marker,MapMarker,true);
				gamebase::Setposition(%marker,%pos);
				%marker.rotChange = $AirStrike::PathRotChange[%type,%seq,%x];
				addToSet("MissionCleanup/AirStrikePath"@%curPaths,%marker);
		
				if(%y == 0)
				{
					%marker.firePoint = true;
					
				}
				else if(%y == 1 && $AirStrike::PathFunction[%type,%seq,%x] != "")	
				{
					%marker.executeFunction = $AirStrike::PathFunction[%type,%seq,%x];
				}
				else if(%y == 2 && $AirStrike::PathExit[%type,%seq,%x])
				{
					%marker.exitPoint = true;
				}
				else if(%y == 3 && $AirStrike::PathFireCont[%type,%seq,%x] != -1)
				{
					$AirStrike::IsFiring[%vehicle] = true;
					%marker.isFiringPoint = $AirStrike::PathFireCont[%type,%seq,%x];
				} else if(%y == 3 && $AirStrike::PathFireCont[%type,%seq,%x] == -1 && $AirStrike::IsFiring[%vehicle])
				{
					$AirStrike::IsFiring[%vehicle] = false;
					%marker.isFiringPoint = -1;
				} else if(%y == 4 && $AirStrike::PathRoll[%type,%seq,%x])
				{	
					%marker.roll = $AirStrike::PathRoll[%type,%seq,%x];
				}
			}
		}
	}
	return %returnGroup;
}

function AirStrike::StartAttackRun(%vehicle,%player,%type,%seq)
{
	%vehicle.isAirstrikeVehicle = 1;
	%vehicle.requester = %player;
	%vehicle.bombType = $AirStrike::PayLoad[%type,%seq];
	%vehicle.numToFire = $AirStrike::PayLoadReleaseNum[%type,%seq];
	%vehicle.WPTollerance = $Airstrike::WPTollerance[%type,%seq];
	%vehicle.rotAxis = $AirStrike::RotAxis[%type,%seq]; // Does nothing
	AirStrike::FollowMarkers(%vehicle);
	return;	
}

function AirStrike::RemoveVehicle(%this)
{
	%vehicle.isAirstrikeVehicle = 0;
	Vehicle::OnDestroyed(%this);
}

function AirStrike::FollowMarkers(%this)
{
	AirStrike::MoveOnPath(%this,%this.group,0);
}


function AirStrike::MoveOnPath(%this,%MarkerGroup,%marker)
{	
	//deleteobject(%this);
	//gamebase::Setposition(2051, vector::add(gamebase::Getposition(%this), "0 0 20"));
	%vehicle = %this;
	if(%vehicle && %vehicle.dead == false && gamebase::Getposition(%vehicle) != "0 0 0")
	{

		// If it's the first marker, snap us into position/rotation.
		%cur = Group::GetObject(%markerGroup,%Marker);
		%exit = false;
		if(!%cur || %cur == -1 || %cur == "")
		{
			echo("Airstrike: Ran out of markers before seeing an exit point!!");
			deleteobject(%this.group);
			AirStrike::removeVehicle(%this);
			%exit = true;
		}	
		else if(%marker == 0)
		{
			
			gamebase::setposition(%this,gamebase::Getposition(%cur));
			gamebase::setrotation(%this,gamebase::Getrotation(%cur));
			%marker++;
		} else if(%cur.firePoint)
		{

			%marker.firePoint = false; // Unnecessary
	
			%player = %vehicle.requester;
			%bombType = %vehicle.bombType;
			Airstrike::FireWeap(%vehicle,%bombtype,%player);
		
			%marker++;
		} else if(%cur.isFiringPoint)
		{

			if(%cur.isFiringPoint > 0)
			{
				%player = %vehicle.requester;
				%bombType = %vehicle.bombType;
				
				// Already firing? Change RoF
				if(%vehicle.isFiring)
					%vehicle.isFiring = %cur.isFiringPoint;
				// Not? Start Firing
				else
				{
					%vehicle.isFiring = %cur.isFiringPoint;
					Airstrike::StartFire(%vehicle,%bombtype,%player);
				}
			} else
				%vehicle.isFiring = false;	
			%marker++;
		} else if(%cur.exitPoint)
		{
			%exit = true;
			deleteobject(%this.group);
			AirStrike::removeVehicle(%this);
		} else if(%cur.roll)
		{	
			Vehicle::SwapSeekingMissiles::P(%vehicle);
				gamebase::setRotation(%vehicle,vector::add(gamebase::GetRotation(%vehicle),"0 0 "@%cur.roll));
			Vehicle::SwapSeekingMissiles::V(%vehicle);
			%marker++;
		} else if(%cur.executeFunction != "")
		{
			%fn = %cur.executeFunction;
			// 10 should be enough.
			for(%x=0;%x<10;%x++)
			{
				if(string::findsubstr("%this",%fn) != -1)
				{
					%pre = %pre @ String::getsubstr(%fn,0,string::findsubstr("%this",%fn)) @ %this;
					%fn = String::getsubstr(%fn,string::findsubstr("%this",%fn) + 5,String::len(%fn));
				} else
				{
					%pre = %pre@%fn;
					break;
				}
			}
			eval(%pre);
			%marker++;
		
		} else
		{
			// Standard movement between nodes.
			%toPos = gamebase::Getposition(%cur);
			%fromPos = gamebase::getPosition(%this);
		
			%currentRot = gamebase::GetRotation(%this);

			// Check if we're near our node.
			if(Vector::getDistance(%toPos,%fromPos) < %vehicle.WPTollerance)//7.2)
			{
				// New marker.
				%marker++;
			} else
			{
				// Make sure we're pointing at our marker.
				%targRot = vector::getrotaim(%fromPos,%toPos);

			if(String::findSubStr(%targRot, "+NAN") != -1)
			{
				%targRot = String::ReplaceAll(%targRot, "+NAN","0");
//echo("AS targRot: " @ %targRot);	
			}
			if(String::findSubStr(%targRot, "-NAN") != -1)
			{
				%transform = String::ReplaceAll(%targRot, "-NAN","0");
//echo("AS targRot: " @ %targRot);	
			}
	
				%addRot = Airstrike::GetRotChangeAmount(%targRot,%currentRot,%cur.rotChange, %vehicle.rotAxis);		

			if(String::findSubStr(%addRot, "+NAN") != -1)
			{
				%addRot = String::ReplaceAll(%addRot, "+NAN","0");
//echo("AS addRot: " @ %addRot);	
			}
			if(String::findSubStr(%addRot, "-NAN") != -1)
			{
				%transform = String::ReplaceAll(%addRot, "-NAN","0");
//echo("AS addRot: " @ %addRot);	
			}
				%newRot = vector::add(%currentRot,%addRot);

			if(String::findSubStr(%addRot, "+NAN") != -1)
			{
				%addRot = String::ReplaceAll(%addRot, "+NAN","0");
//echo("AS addRot: " @ %addRot);	
			}
			if(String::findSubStr(%addRot, "-NAN") != -1)
			{
				%transform = String::ReplaceAll(%addRot, "-NAN","0");
//echo("AS addRot: " @ %addRot);	
			}
//				Vehicle::SwapSeekingMissiles::P(%vehicle);
					gamebase::SetRotation(%this,%newRot);
//				Vehicle::SwapSeekingMissiles::V(%vehicle);
			}		
		}

		if(!%exit && %vehicle && !%vehicle.dead && gamebase::Getposition(%vehicle) != "0 0 0")
		{
			schedule("AirStrike::MoveOnPath("@%this@","@%MarkerGroup@","@%marker@");",0.1);
		}
	}
}	

function Airstrike::GetRotChangeAmount(%rotTo, %rotFrom, %delta, %axis)
{
	%rotDiff = RadianDiff(getword(%rotTo,0),getword(%rotFrom,0))@" "@RadianDiff(getword(%rotTo,1),getword(%rotFrom,1))@" "@RadianDiff(getword(%rotTo,2),getword(%rotFrom,2));
	if(getword(%rotDiff,0) > 0)
		if(getWord(%rotDiff,0) > %delta)
			%addRot = %delta;
		else
			%addRot = getword(%rotDiff,0);
	else
		if(getWord(%rotDiff,0) < -1*%delta)
			%addRot = -1*%delta;
		else
			%addRot = getword(%rotDiff,0);

	if(getword(%rotDiff,1) > 0)
		if(getWord(%rotDiff,1) > %delta)
			%addRot = %addRot @" "@ %delta;
		else
			%addRot = %addRot @" "@ getword(%rotDiff,1);
	else
		if(getWord(%rotDiff,1) < -1*%delta)
			%addRot = %addRot @" "@ -1*%delta;
		else
			%addRot = %addRot @" "@ getword(%rotDiff,1);
	
	if(getword(%rotDiff,2) > 0)
		if(getWord(%rotDiff,2) > %delta)
			%addRot = %addRot @" "@ %delta;
		else
			%addRot = %addRot @" "@ getword(%rotDiff,2);
	else
		if(getWord(%rotDiff,2) < -1*%delta)
			%addRot = %addRot @" "@ -1*%delta;
		else	
			%addRot = %addRot @" "@ getword(%rotDiff,2);

	return %addRot;
}

function abs(%val)
{
	return sqrt(pow(%val,2));
}

function radianDiff(%target, %cur)
{
	%diff = %target - %cur;
	
	// If it's greater then Pi, it's better to go the other way around.
	if(abs(%diff) > $PI)
	{
		if(%target > 0)
		{
			%tC = %target -$Pi;
			%cC = %cur + $Pi;
		} else
		{
			%tC = %target + $Pi;
			%cC = %cur - $Pi;
		}
		%diff = %tC - %cC;
	}
	return %diff;
}