//*****************************************************************************************************
// Hopefully will provide AIs with the ability to act "smart": Not notice players unless they need to,
//  run for cover if being shot at.  
//
// Two reactions: One AI version will dive for cover, another will try to charge the enemy.
//
// Requirements: 
//	Patroll a position; patrolling can be as simple as standing in one spot and rotating a little.
//		Between each patrol, they'll pause for a random amount of time.
//	If their back is to a player, anyone not sneaking won't be heard.
//	Explosions, gunshots, or other lound sounds within "hearing range" of an AI will cause them to
//		"react"
//	When in reaction mode, they will have extended vision, and will turn to the source of what
//		caused them to react.
//	When in patrol mode, their vision will be restricted, except when paused.
//*****************************************************************************************************
$AAI::Executed = 1;
// Needs to be set on each mission start with the max visibility distance in the mission.
$AAI::MissionVisibleDistance = 400;

// How often to check our patrol status.
$AAI::PatrolSlice = 0.5;

//AI Status
$AAI::StatusPatrol = 0;
$AAI::StatusReact = 1;
$AAI::StatusScan = 2;

// Scan time while patrolling
$AAI::MinScanTime = 5; // Seconds
$AAI::MaxScanTime = 30; // Seconds

// Will scan walls that are further away then this, but won't bother with those this close and closer.
$AAI::WallScanDist = 10;

// While scanning, how quickly to set their rotation, and how much to set it by.
$AAI::RotateSlice = 0.05;
$AAI::RotateAmt = 0.01;

// How far away until we'll definately hear them, even if they arn't moving?
$AAI::SneakDistMin = 2.5;
// How fast can they go before they're heard inside the SneakStartHear range? 
$AAI::SneakSpeedMax[0] = 1; // Close in,
$AAI::SneakSpeedMax[1] = 3; // Far out (at $AAI::SneakStartHear)
// Inside what range will they start to be heard?
$AAI::SneakStartHear = 15;
// What's the slowest fastest speed we can go, no matter how close we are?
// Basically, the close we are, the slower we have to go. But if the "slowest" speed is lower then this,
// then this is the speed that we use.
$AAI::VelMaxMin = 1.3;

// How wide of a "cone" do bullets get heard from within.
$AAI::MinDotToHearBullet = 0.9962; //About 5 degrees...
$AAI::MaxNormalDotToHear = -0.4;
$AAI::DistanceToHearBuffer = 3; //Just a lil give to the LOS Distance...

$AAI::RandomChanceForRepairKit = 0.075; //Percentage... 7.5%
$AAI::DefaultRandomFactor = 0.8; //Default chance for AI to spawn if not forced to spawn.


exec(bordergame);
exec(limitedlives);
exec(AAIGameStats);

//----------------------------------------------------------
// Spawns an AAI.
//
//----------------------------------------------------------
function AAI::spawn(%path,%team)
{
	
	if($noAAISpawn)
	{
		return;
	}
	%pathset = group::getObject(%path,0); // 0 Should always be the "Patrol" paths.
	for(%i = 0; %i < group::ObjectCount(%pathset); %i++)
	{
		group::getobject(%pathset, %i).useInitialPath = 0;
	}
	%name = object::GetName(%path);
	
		
	%armor = getWord(%name,0);
		
	%weapon = getWord(%name,1);
		//if($GetData)
		//{
		//$AAIStat::Armor[%armor]++;
		//$AAIStat::Weapon[%weapon]++;
		
		//if(String::findSubStr(%name, "Elite") >= 0)
		//$AAIStat::Status["Elite"]++;
		//else if(String::findSubStr(%name, "Vet") >= 0)
		//$AAIStat::Status["Vet"]++;
		//else
		//$AAIStat::Status["Normal"]++;

		//$AAIStat::Count++;
		//return;
		//}
	%type = $AIWeaponToType[%weapon];
	if(%type == "")
		%type = 1;
	
	%ainame = eval("Extermination::spawn"@%armor@"("@%team@", "@%pathset@", "@%type@",\""@%name@"\");");
	%ai = AI::GetObject(%ainame);
	if(%path.BorderPatrol)
	{
	$BorderKiller = AI::GetId(%ainame);	

	}
	%ai.root = %path;
	%ai.patrol = %pathset;
	%ai.react = group::getObject(%path,1);
	
	// Start them running blind.
	AI::setVar(%ainame,SpotDist,0);
	AI::setVar(%aiName, pathtype, 1);
   	AI::SetVar(%aiName, triggerPct, 0.03 );
   	AI::setVar(%aiName, iq, 70 );
   	AI::setVar(%aiName, attackMode, 1);
	%ai.status = $AAI::StatusReact;
	
	%ai.nextWaypoint = 0;

	%curmark = group::getObject(%ai.patrol,%ai.NextWaypoint);

	if(%armor == "Random")
	{
		%curmark = group::getObject(%ai.patrol,group::objectcount(%ai.patrol)-1);
		for(%i = 0; %i < group::ObjectCount(%pathset); %i++)
		{
			group::getobject(%pathset, %i).useInitialPath = -1;
		}
		%moveto = group::getObject(%ai.patrol, 1+floor(getrandom() * (group::objectcount(%ai.patrol) - 2)));
		schedule("MoveRAAI(\""@%ainame@"\", \""@gamebase::getposition(%moveto)@"\");", 1);
	}
	// If it's one, we want to be sure to mark it after hitting it.
	%curmark.useInitialPath = 1;
	if(%curmark.isInitialPath == 1)
	{
		%curmark.useInitialPath = -1;
	}

	for(%x=100;AI::directiveremove(%ainame,%x);%x+=100){}
	// They'll need a voice
	%ai.voice = floor(getrandom()*5)+1;
	%ai.isAAI = true;

	//AI::directivelist(%ainame);

	%player = Client::getOwnedObject(AI::GetId(%ainame));

	if(String::findSubStr(%name, "Elite") >= 0)
	{	
  		AI::SetVar(%aiName, triggerPct, 1 );

		$Veteran::Kills[%player,Knife] = 10;
		$Veteran::Kills[%player,Pistol] = 10;
		$Veteran::Kills[%player,M16] = 10;
		$Veteran::Kills[%player,SAW] = 10;
		$Veteran::Kills[%player,MP5] = 10;
		$Veteran::Kills[%player,PSG1] = 10;
		$Veteran::Kills[%player,Robar] = 10;
		$Veteran::Kills[%player,Shotgun] = 10;
		$Veteran::Kills[%player,Law] = 10;
		
	} else if(String::findSubStr(%name, "Vet") >= 0)
	{
 		AI::SetVar(%aiName, triggerPct, 0.5 );

		$Veteran::Kills[%player,Knife] = 3;
		$Veteran::Kills[%player,Pistol] = 3;
		$Veteran::Kills[%player,M16] = 3;
		$Veteran::Kills[%player,SAW] = 3;
		$Veteran::Kills[%player,MP5] = 3;
		$Veteran::Kills[%player,PSG1] = 3;
		$Veteran::Kills[%player,Robar] = 3;
		$Veteran::Kills[%player,Shotgun] = 3;
		$Veteran::Kills[%player,Law] = 3;
		
	} else
	{
		AI::SetVar(%aiName, triggerPct, 0.1 );
	}

	if(String::findSubStr(%name, "Radio") >= 0)
	{
		%ai.hasRadio = true;
		player::mountitem(%player, RadioFlasher, 5);
	}

	if(String::findSubStr(%name, "NoPatrol") >= 0)
	{
		%ai.noPatrol = true;
	}

	return %ainame;
}





//----------------------------------------------------------
// Keeps the AI patrolling unless they get distracted.
//
//----------------------------------------------------------
function AAI::patrol(%aicl)
{

	%aiName = AAI::ClientGetName(%AICl);
	
	%ai = AI::GetObject(%ainame);
	
	
	%aiObj = Client::GetOwnedObject(%aiCL);

	if(!%ai || %ai == -1 || %ai == "")
		return; // AI must be dead.
	
	// Somethings happening!
	// We're reacting!

	// Status == Reacting?
	
	if(%ai.status == $AAI::StatusReact)
	{
		if(%ai.movetogether == 1)
		{
			echo(%ainame@" breaking out of formation");
			%ai.movetogether = 0;
			String::ReplaceAll($AIsTogether[getgroup(getgroup(%ai.patrol))], %ainame@" ", " ");
			%ai.status = $AAI::StatusPatrol;
			CheckGroupMotion(getgroup(getgroup(%ai.patrol)));
		}
		else
			return;
	}

	// Setting attack mode! This might need to be removed!
	AI::setvar(%aiName,attackMode,1);
	
	// Not reacting...
	// We're patrolling

	%nextWp = group::getobject(%ai.patrol,%ai.nextWaypoint);
	// Not at waypoint
	if(%ai.status == $AAI::StatusPatrol && vector::getdistance(gamebase::getposition(%aiCL),gamebase::Getposition(%nextwp)) > 1)
	{
	
		%speed = vector::getdistance("0 0 0",item::getvelocity(%aiCL));
		if(%ai.specialstatus == "jump" && (getSimTime() - %ai.lastjump) > 2.5)
		{
		
		%ai.lastjump = getSimTime();
		%dir = vector::normalize(vector::sub(gamebase::Getposition(%nextwp), gamebase::getposition(%aiCL)));
		Player::applyImpulse(%aiCL,vector::add(vector::scale(%dir, 20), "0 0 60"));
		}
		if(%ai.specialstatus == "grapple")
		{
		if(%ai.isgrappling != 1)
		{
		%ai.isgrappling = 1;
		AAI::DoGrappleStuff(%aiobj);
		}
		%dir = vector::sub(gamebase::Getposition(%nextwp), gamebase::getposition(%aiCL));
		item::setvelocity(%aiCl, "0 0 0");
		Player::applyImpulse(%aiCL,getword(%dir, 0)@" "@getword(%dir, 1)@" 8");
		} else if(%ai.isgrappling){
		%ai.isgrappling = 0;
		EndGrapple(%aiobj);
		}
		// Standing still?
		if(%speed < 0.1 && %ai.specialstatus != "jump")
		{
			// get unstuck.
			
					
					
				
					
			
			Player::applyImpulse(%aiCL,50*getRandom() - 50*getRandom()@" "@50*getRandom() - 50*getRandom()@" "@50*getRandom() - 50*getRandom()+50);
			// Just make sure we know where our next waypoint is
			AI::DirectiveRemove(%aiName,100);
			AI::DirectiveWaypoint(%aiName,gamebase::Getposition(%nextWp));
		} else
		{
			// Must be on our way.
		}
		// Check for enemies while running.
		%enemiesFound = AAI::ScanForEnemies(%ai,%aiCL,%aiObj,0.25);
		// If we found some enemies, switch to reaction.
		if(%enemiesFound)
		{
			%ai.target = %enemiesFound;
			%ai.status = $AAI::StatusReact;
			AAI::FoundEnemyReaction(%ainame,%ai,%aiCL,%aiObj);
		}
	}
	// At Waypoint
	else
	{
		// Status == scanning
		if(%ai.status == $AAI::StatusScan)
		{
			// Not done scanning.
			
			if((getSimTime() - %ai.scanTime) < %ai.ScanDuration)
			{
			
			
				// Check for enemies.
				%enemiesFound = AAI::ScanForEnemies(%ai,%aiCL,%aiObj,1);
				
				// If we found some enemies, switch to reaction.
				if(%enemiesFound)
				{
					%ai.target = %enemiesFound;
					%ai.status = $AAI::StatusReact;
					AAI::FoundEnemyReaction(%ainame,%ai,%aiCL,%aiObj);
				}
			
				// Rotate a bit to get some scanning in.
				if(%ai.rotate == "")
				{
					%ai.rotate = floor(getrandom()*2);
				}

				// Make sure we're not staring at a wall.
				// If this always returns false, then %ai is the client object; we need the player.

				if(GameBase::getLOSInfo(%aiObj, $AAI::WallScanDist))
				{
					// We are! Rotate our scan the other direction.
					// Make sure we're not stuck stairing at the middile of a wall.
					if(!%ai.lastWall)
					{
						%ai.rotate = -1*(%ai.rotate - 1);
						%ai.lastWall = true;
					}
				} else
				{
					%ai.lastwall = false;
				}
			} 
			// Done scanning
			else
			{
				// Move to next waypoint
				if(%ai.NextWaypoint != -1)
				{
					%ai.NextWaypoint++;
					
					// Take care of initial path stuff.
				}
				if(%ai.NextWaypoint >= group::objectcount(%ai.patrol))
				{
					%ai.NextWaypoint = 0;
				
					// If no Patrol, then we're done here.
					if(%ai.noPatrol)
					{
						%ai.NextWaypoint = -1;
						$AIsTogether[getgroup(getgroup(%ai.patrol))] = "";
					}

				}
				if(%ai.NextWaypoint != -1)
				{
					%done = false;
					%curmark = group::getObject(%ai.patrol,%ai.NextWaypoint);
					while(!%done)
					{
						// If it's one, we want to be sure to mark it after hitting it.
						
						if(%curmark.isInitialPath == 1 && %curmark.useInitialPath != -1)
						{
							%curmark.useInitialPath = -1;
							//%curmark.isInitialPath = -1;
							%done = true;
						}
						// If it's -1, then we want to skip it
						else if(%curmark.isInitialPath == 1 && %curMark.useInitialPath == -1)
						{
							
							%ai.NextWaypoint++;
							
						} else
							%done = true;
						%curmark = group::getObject(%ai.patrol,%ai.NextWaypoint);
					}
					%ai.specialstatus = "";
					%lastmark = group::getObject(%ai.patrol,%ai.NextWaypoint-1);
					if(%lastmark.jumpup)
						%ai.specialstatus = "jump";
					if(%lastmark.dograpple)
						%ai.specialstatus = "grapple";

					%ai.status = $AAI::StatusPatrol;
					AI::DirectiveWaypoint(%aiName,gamebase::Getposition(group::getobject(%ai.patrol,%ai.nextWaypoint)));
				}
				else
				{
					%ai.ScanTime = getSimTime();	
					%ai.ScanDuration = $AAI::MinScanTime + ($AAI::MaxScanTime-$AAI::MinScanTime)*getrandom();
					if(%ai.movetogether)
					{
						echo(%ainame@" waiting at "@%ai.atwaypt);
						%ai.ScanDuration = 10; //If its any longer than this, they can catch up...
						%ai.atwaypt = %ai.NextWaypoint;
						CheckGroupMotion(getgroup(getgroup(%ai.patrol)));
					}
				}
			}
		}

		// Status == patrolling?
		else if(%ai.status == $AAI::StatusPatrol)
		{
			AI::DirectiveRemove(%aiName,100); // Last always appears to be "100"

			// Stop and scan
			%ai.status = $AAI::StatusScan;
			%ai.ScanTime = getSimTime();
			if(%ai.movetogether)
			{
				echo(%ainame@" waiting at "@%ai.atwaypt);
				%ai.ScanDuration = 10; //If its any longer than this, they can catch up...
				%ai.atwaypt = %ai.NextWaypoint;
				CheckGroupMotion(getgroup(getgroup(%ai.patrol)));
			}
			else if(%ai.noPatrol || (group::getObject(%ai.patrol,%ai.NextWaypoint).isInitialPath == 1 && group::getObject(%ai.patrol,%ai.NextWaypoint).useInitialPath == -1)||group::getObject(%ai.patrol,%ai.NextWaypoint).nostop)
			{
				%ai.ScanDuration = 0;
				%TimeSlice = 0.1;
			}
			else
			{
			%ai.ScanDuration = $AAI::MinScanTime + ($AAI::MaxScanTime-$AAI::MinScanTime)*getrandom();

				
			}
			AAI::ScanRotation(%ai,%aiCL);
		}
	}
	
	if(%TimeSlice != 0.1)
		%TimeSlice = $AAI::PatrolSlice;

	schedule("AAI::patrol("@%aicl@");",%TimeSlice,%ai);
}

//----------------------------------------------------------
// While an AI stands and scanns an area, they need to
// rotate. This will keep them doing so.
//----------------------------------------------------------
function CheckGroupMotion(%group)
{
	%wp = -1;
	%move = true;
	%x = 0;
	echo(object::getname(%group)@" "@%group);
	if($AllAISpawned[%group] == 0 || $TempWait[%group] == 1)
		return;
	while(getword($AIsTogether[%group], %x) != -1)
	{
	%ainame = getword($AIsTogether[%group], %x); 
	%x++;
	
	%ai = AI::GetObject(%ainame);
	if(%wp == -1)
		%wp = %ai.atwaypt;
	//echo(%ainame@" "@%ai.movetogether@" "@%ai.atwaypt);
	//%ai.movetogether = 1;
	if(%ai.atwaypt != %wp)
	{	
		%move = false;
	}
	}

	if(%move == true)
	{
	//echo("AIs in "@object::getname(%group)@" are moving to "@%wp + 1);
	%x = 0;
	$TempWait[%group] = 1;
	schedule("$TempWait["@%group@"] = 0;", 0.12);
	while(getword($AIsTogether[%group], %x) != -1)
	{
	%ainame = getword($AIsTogether[%group], %x); 
	%x++;
	%ai = AI::GetObject(%ainame);
	%ai.ScanDuration = 0;
	if(%group.waittime)
	{
		%ai.ScanDuration = %group.waittime;
		//echo(%ainame@ " waiting for "@%ai.ScanDuration);
	}
	}

	}
	
}


function AAI::ScanRotation(%ai,%aiCL)
{
	
	if(!%ai || %ai == -1 || %ai == "")
		return; // AI must be dead.

	if(%ai.status != $AAI::StatusScan)
		return; // AI isn't supposed to be rotating.

	// Switch rotate direction once in a while
	if(getrandom() < 0.01)
		%ai.rotate = -1*(%ai.rotate - 1);

	gamebase::setRotation(%aiCL,vector::add(gamebase::getRotation(%aiCL),"0 0 "@($AAI::RotateAmt*(%ai.rotate*2 - 1))));
	
	schedule("AAI::ScanRotation("@%ai@","@%aiCL@");",$AAI::RotateSlice,%ai);
}


//----------------------------------------------------------
// Track all enemies, and find out if any are in our field
// of vision. Return the first we find.
//----------------------------------------------------------

function AAI::DoGrappleStuff(%aiobj)
{
	%HookGroup=newObject("HG", SimGroup);
	addToSet("MissionCleanup", %HookGroup);
	%obj=newObject("GrapHook","StaticShape","GrapHook",true);
	addToSet(%HookGroup, %obj);
	gamebase::setposition(%obj, gamebase::getposition(%aiobj));
	gamebase::setrotation(%obj,"0 0 0");
	%aiobj.hookgroup = %hookgroup;
	%aiobj.hookpos=gamebase::getposition(%obj);
	MakeRope(%aiobj);
	


}

function AAI::ScanForEnemies(%ai,%aiCL,%aiObj,%Tol)
{
	%rot = gamebase::getRotation(%aiCL);
	%pos = gamebase::Getposition(%aiCL);

	

	// Change this to Client::GetFirst() if it's too laggy.
	//  At that point it'll only count enemy people, not AIs
	//  (Note about the existance of baseRep:: found on Annihilation.info forums)
	%spotted = "";
	for(%cur = AAI::getFirst();%cur != -1 && %spotted == "";%cur = AAI::getNext(%cur))
	{
	if(%cur.ingame)
	{

		if(%cur != %aiCL && gamebase::getteam(%cur) != gamebase::getTeam(%aiobj) && gamebase::getteam(%cur) != -1 && !%cur.dead && %cur.observerMode == "" && %Cur.justjoined == "" && client::getownedobject(%cur) != -1)
		{
			if(AAI::SpecialScanCases(%cur))
			{
			//echo(client::Getname(%cur)@" is a valid target to "@object::getname(%aiobj));
			%curPos = gamebase::getposition(%cur);

			// First we'll check for sound
	
			// If a player is close to us, and moving a certain speed, we'll probably hear them
			%dist = vector::getdistance(%curPos,%pos);
			%vel = Vector::getDistance("0 0 0",item::getVelocity(%cur));
			%distMin = $AAI::SneakDistMin - %dist;
			//%dist = $AAI::SneakStartHear - %dist;
			%vel = %vel;
			if(%dist < 0) %dist = 0;
			if(%vel < 0) %vel = 0;
			%velMax = %dist*($AAI::SneakSpeedMax[0]+($AAI::SneakSpeedMax[1] - $AAI::SneakSpeedMax[0])/($AAI::SneakStartHear));
			if(%velMax < $AAI::VelMaxMin) %velMax = $AAI::VelMaxMin;
			if(%vel > %velMax || %distMin > 0)
			{
				%spotted = %cur;
				return %spotted;
			}
			// Then we'll check for a visual
			
			%viewAngle = getword(%rot,2) - getword(vector::getrotaim(%pos,%curPos),2);
			%viewAngle = sqrt(pow(%viewAngle,2));
			// Gives us a 180 deg look in front of us.
			%viewAngle = %viewAngle - $PI/2;
			// 180 deg range reduced by random amount (so they don't *always* catch it)
			%catchAngle = -1*($Pi/2)*getRandom()*%Tol;
			if(%viewAngle <= %catchAngle)
			{
				// Distance should be a factor.
				%dist = Vector::getdistance(%pos,%curPos);
				%distChance = ( 0.5*$AAI::MissionVisibleDistance*pow(%viewAngle,2) )*%tol;

				// Within seeing distance

				if(%distChance > %dist)
				{
					// Finally, they need to have an LOS in order to see us.
					%viewPoint = newObject("ViewPoint", "StaticShape", "ViewPoint", false);
					%viewPoint2 = newObject("ViewPoint", "StaticShape", "ViewPoint", false);
					%VPPos = GetOffSetRot("0 1 2",%Rot,%Pos);

					if(Player::isCrouching(%cur))
						%VPPos2 = GetOffSetRot("0 0 1.5",%Rot,%CurPos);
					else
						%VPPos2 = GetOffSetRot("0 0 2",%Rot,%CurPos);
					gamebase::setposition(%viewPoint,%VPPos);
					gamebase::setposition(%viewPoint2,%VPPos2);
					if(GameBase::getLOSInfo(%viewpoint, $AAI::MissionVisibleDistance,vector::getrotaim(%VPPos,%VPPos2)))
					{

						if($LOS::Object == client::GetOwnedObject(%cur)
						   || $LOS::Object == %viewPoint2)
						{
							%spotted = client::GetOwnedObject(%cur);
						}
					}
					deleteObject(%viewPoint);
					deleteobject(%viewpoint2);
				}
			}
		}
		}
		}
	}
	return %spotted;
}


//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::FoundEnemyReaction(%aiName,%ai,%aiCL,%aiObj)
{
	//Player::setAnimation(%aiObj, 50);
//	%ai.status = $AAI::StatusPatrol;
	schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(4*getRandom)+1);
//	schedule("AAI::patrol("@%aiName@");",5,%ai);
	schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));

	// Additionally, if this guy has a radio, he's going to be calling for some help
	if(%ai.hasRadio)
	{
		schedule("AAi::RadioForAssistance("@%ainame@","@%ai@","@%aiCL@","@%aiObj@");",5);
		%ai.hasRadio = false;
	}
}

//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::FiredOnReaction(%this,%shooter)
{
	
	if(!Player::isAiControlled(%this))
		return;
	%aiCL = Player::getClient(%this);
	%aiName = AAI::ClientGetName(%aiCl);
	%ai = AI::GetObject(%ainame);
	//%aiCL = AI::GetId(%ainame);
	%aiObj = %this;
	if(%ai.target == "" || %ai.target == "*" || %ai.target == -1)
	{
	%ai.target = %shooter;
	
	
	%ai.status = $AAI::StatusReact;

	schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",1);",floor(4*getRandom)+1);
	schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));
	}
	// Additionally, if this guy has a radio, he's going to be calling for some help
	if(%ai.hasRadio)
	{
		schedule("AAi::RadioForAssistance("@%ainame@","@%ai@","@%aiCL@","@%aiObj@");",5);
		%ai.hasRadio = false;
	}

}


//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::WasShotReaction(%this,%shooter)
{
	if(!Player::isAiControlled(%this))
		return;
	%aiCL = Player::GetClient(%this);
	%aiName = AAI::ClientGetname(%aiCL);
	%ai = AI::GetObject(%ainame);
	AAI::AddToStats(Player::getClient(%shooter), "shotshit");
	%aiObj = %this;
	%ai.isShot = true;
	if(Player::GetItemCount(%aiCl, "RepairKit") > 0)
		schedule("if("@%ai@".AIisDead != true) { Player::UseItem("@%aiCl@", \"RepairKit\"); }", 1.5);
	if(gamebase::GetTeam(%shooter) != gamebase::getTeam(%this))
	{
	if(%ai.target == "" || %ai.target == "*" || %ai.target == -1)
	{
		%ai.status = $AAI::StatusReact;
		%ai.target = %shooter;
	
		
		schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",2);",floor(4*getRandom)+1);
		schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));
		}
		// Additionally, if this guy has a radio, he's going to be calling for some help
		if(%ai.hasRadio)
		{
			schedule("AAi::RadioForAssistance("@%ainame@","@%ai@","@%aiCL@","@%aiObj@");",5);
			%ai.hasRadio = false;
		}
		
	} else
	{
		%ai.TKAttacker = %shooter;
		schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",3);",floor(4*getRandom)+1);
//		schedule("AAI::TestPatrolResume("@%aiName@","@%ai@","@%aiCL@","@%aiObj@");",4+getRandom()*1,%ai);
	}
}

function AAI::OnDisarmed(%this,%shooter)
{
	if(!Player::isAiControlled(%this))
		return;
	
	if(Player::getmounteditem(%this, 0) != -1)
		return;
	%aiCL = Player::GetClient(%this);
	%aiName = AAI::ClientGetname(%aiCl);
	%ai = AI::GetObject(%ainame);
	AAI::AddToStats(Player::getClient(%shooter), "AIsDisarmed");
	%aiObj = %this;
	
	if($AAI::GoSuicidal == 1 )
	{
		schedule("AAI::Suicidal("@%ai@", "@%aiobj@", "@%ainame@");", 1);
		
	}

}
function AAI::Suicidal(%ai, %aiobj, %ainame)
{
	if(player::isdead(%aiobj))
		%ai.isthrowing=1;
		schedule("AAI::checknade("@%ai@", "@%aiobj@");", 1);
		AI::DirectiveFollow(%aiName, Player::GetClient(%ai.target), 0, 1024);
		AI::SetVar(%ainame, seekoff, "0 0 0");

}
function AAI::checknade(%client, %REALclient)
{
	//echo(%client@" "@%client.isthrowing@" "@%client.secondsinthrow);
%pl = Client::getOwnedObject(%client);
	
   
   if(%client.isthrowing)
   {
	%client.secondsinthrow=%client.secondsinthrow+1;
	if(%client.secondsinthrow>=5){

		%obj = newObject("", "Mine", "handgrenade");
		gamebase::throw(%obj, %realclient, 0, true);
	}else{
	        schedule("AAI::checknade("@%client@", "@%realclient@");", 1);
		return;
        }
    }


    %client.secondsinthrow=0;
}

//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::HeardShootingReaction(%this,%shooter)
{
	if(!Player::isAiControlled(%this))
		return;
	%aiCL = Player::GetClient(%this);
	%aiName = AAI::ClientGetname(%aiCl);
	%ai = AI::GetObject(%ainame);
	%aiObj = %this;
	if(%ai.target == "" || %ai.target == "*" || %ai.target == -1)
	{
	%ai.target = %shooter;
	
	%ai.status = $AAI::StatusReact;
	AAI::AddToStats(Player::getClient(%shooter), "shotsheard");
	schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(4*getRandom)+1);
	schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));
	}
}

//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::SawGrenadeReaction(%this,%grenade)
{
	if(!Player::isAiControlled(%this))
		return;
	%aiCL = Player::GetClient(%this);
	%aiName = AAI::ClientGetname(%aiCl);
	%ai = AI::GetObject(%ainame);
	
	%aiObj = %this;
	//AAI::RespondToGrenade(%ainame, %ai, %aiobj, %grenade);
	if(%ai.target == "" || %ai.target == -1)
	{
	%ai.target = "*";
	
	%ai.status = $AAI::StatusReact;


	schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",4);",floor(4*getRandom)+1);
	schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));
	// Additionally, if this guy has a radio, he's going to be calling for some help
	}
	if(%ai.hasRadio)
	{
		schedule("AAi::RadioForAssistance("@%ainame@","@%ai@","@%aiCL@","@%aiObj@");",5);
		%ai.hasRadio = false;
	}
}

function AAI::RespondToGrenade(%ainame, %ai, %aiobj, %grenade)
{
	if(!%ai.ReactingToNade)
	{
		%ai.PreNadePos = gamebase::getposition(%aiobj);
		%ai.ReactingToNade = 1;
		schedule("AAI::PostGrenade("@%ainame@", "@%ai@", "@%aiobj@", "@%grenade@");", 6);
		AI::DirectiveRemove(%aiName,100);
		
	}
	%ai.status = -1;
	%dir = vector::sub(gamebase::Getposition(%aiobj), gamebase::Getposition(%grenade));
	echo(%ainame@" )) "@vector::getdistance(%dir, "0 0 0"));
	if(vector::getdistance(%dir, "0 0 0")<5)
	{
		//echo("Moving to "@gamebase::Getposition(%grenade));
		AI::DirectiveWaypoint(%aiName,gamebase::Getposition(%grenade));
	}
	else
		AI::DirectiveWaypoint(%aiName,vector::add(gamebase::Getposition(%grenade), vector::scale(vector::normalize(%dir), 20)));


}

function AAI::PostGrenade(%ainame, %ai, %aiobj,  %grenade)
{
	AI::DirectiveRemove(%aiName,100);
	echo("PostGrenade "@%ainame);
	if(player::isdead(%aiObj))
		return;
	%ai.ReactingToNade = 0;
	%ai.status = $AAI::StatusReact;
	//AI::DirectiveWaypoint(%aiName,%ai.PreNadePos);
	schedule("AAI::TestPatrolResume("@%aiName@","@%ai@","@Player::GetClient(%aiobj)@","@%aiObj@");", 2);


}
//----------------------------------------------------------
// Start doing whatever reaction we need to do.
//----------------------------------------------------------
function AAI::WarnedOfEnemyReaction(%this,%warningAI)
{
	if(!Player::isAiControlled(%this))
		return;
	%aiCL = Player::GetClient(%this);
	%aiName = AAI::ClientGetname(%aiCl);
	%ai = AI::GetObject(%ainame);

	%aiObj = %this;
	if(%ai.target == "" || %ai.target == -1)
	{
	%ai.target = "*";
	
	%ai.status = $AAI::StatusReact;


	//schedule("AAI::SignalAllies("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(4*getRandom)+1);
	schedule("AAI::RespondToAlly("@%ainame@","@%ai@","@%aiCL@","@%aiObj@");",floor(4*getRandom)+1);
	schedule("AAI::targetEnemy("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",0);",floor(1*getRandom));
	}
}

//----------------------------------------------------------
// AI will let any buddies around him know that something's going down
//----------------------------------------------------------
function AAI::SignalAllies(%aiName,%ai,%aiCL,%aiObj,%type)
{
	if(player::isdead(%aiObj) || %ai.responding || (%ai.isshot && %type != 2 && %type != 3))
		return;
	%ai.isshot = false;
	%ai.responding = true;
	schedule(%ai@".responding = false;",5);
	
	// He has seen an enemy
	if(%type == 0)
	{
		
		if(getRandom() > 0.9)
			Player::setAnimation(%aiObj, 38);
		%rand = getRandom();
		if( %rand > 0.5)
			%sound = "SoundIncommingEnemies"@%ai.voice;
		else
			%sound = "SoundBeingAttacked"@%ai.voice;
		playSound(%sound,GameBase::getPosition(%aiCL));
	} 
	// He's been fired upon!
	else if(%type == 1)
	{
		
		if(getRandom() > 0.9)
			Player::setAnimation(%aiObj, 48);
		%rand = getRandom();
		if( %rand > 0.66)
			%sound = "SoundHitTheDeck"@%ai.voice;
		else if( %rand > 0.33)
			%sound = "SoundBeingAttacked"@%ai.voice;
		else 
			%sound = "SoundCoverMe"@%ai.voice;
		playSound(%sound,GameBase::getPosition(%aiCL));
	}
	// He's been shot!
	else if(%type == 2)
	{
		if(getRandom() > 0.9)
			Player::setAnimation(%aiObj, 25);
		else
		{
			%rand = getRandom();
			if( %rand > 0.66)
				%sound = "SoundStop"@%ai.voice;
			else if( %rand > 0.33)
				%sound = "SoundBeingAttacked"@%ai.voice;
			else 
				%sound = "SoundCoverMe"@%ai.voice;
			playSound(%sound,GameBase::getPosition(%aiCL));
		}
	}
	// He's been shot by a teammate!
	else if(%type == 3)
	{
		if(getRandom() > 0.95)
			Player::setAnimation(%aiObj, 38);
		else
			Player::setAnimation(%aiObj,46);
		%rand = getRandom();
		if( %rand > 0.75)
			%sound = "SoundStop"@%ai.voice;
		else if( %rand > 0.50)
			%sound = "SoundWatchShooting"@%ai.voice;
		else if( %rand > 0.25)
			%sound = "SoundHey"@%ai.voice;
		else 
			%sound = "SoundIdiot"@%ai.voice;
		playSound(%sound,GameBase::getPosition(%aiCL));

	}
	// Grenade! Take cover!!!
	else if(%type == 4)
	{
		if(getRandom() > 0.9)
			Player::setAnimation(%aiObj, 48);
		%rand = getRandom();
		if( %rand > 0.33)
		{
			%sound = "SoundHitTheDeck"@%ai.voice;
			playSound(%sound,GameBase::getPosition(%aiCL));
		}
	}

	if(%type != 3)
	{
		// Any allies within 70m should be told of the impending attack.
		%position = GameBase::getPosition(%aiCL);
		%set = newObject("set",SimSet); // make new box for testing.
		%num = containerBoxFillSet(%set,$SimPlayerObjectType,%position,70,70,70,0);
		for(%x=0;%x<%num;%x++)
		{
			%cur = Group::getObject(%set,%x); // get the objNum of the found object.
			if(%cur != %aiObj && Player::isAiControlled(%cur))
			{
				AAI::WarnedOfEnemyReaction(%cur,%aiObj);
			}
		}
		deleteobject(%set);
		
		// Radio signalling has been moved to specific react functions
	} else
	{
		%aiObj = %ai.TKAttacker;
		
	%aiCL = Player::GetClient(%aiobj);
	%aiName = AAI::ClientGetname(%aiCl);
	%ai = AI::GetObject(%ainame);
		schedule("AAI::RespondToAlly("@%ainame@","@%ai@","@%aiCL@","@%aiObj@",true);",floor(4*getRandom)+1);
	}	
}

//----------------------------------------------------------
// Will respond to any allies signaling him
//----------------------------------------------------------
function AAI::RespondToAlly(%ainame,%ai,%aiCL,%aiObj,%type3)
{
	if(player::isdead(%aiObj) || %ai.responding)
		return;

	%ai.responding = true;
	schedule(%ai@".responding = false;",5);

	// Warned of an enemy. 
	if(!%type3)
	{
		
		%rand = getRandom();
		if( %rand > 0.6)
			%sound = "SoundAcknowledged"@%ai.voice;
		else if( %rand > 0.5)
			%sound = "SoundYes"@%ai.voice;
		else if( %rand > 0.4)
			%sound = "SoundSighOfDisgust"@%ai.voice;
		else if( %rand > 0.3)
			%sound = "SoundShazbot"@%ai.voice;
		else if( %rand > 0.2)
			%sound = "SoundDamnit"@%ai.voice;
		else
			%sound = "SoundCrap"@%ai.voice;
		playSound(%sound,GameBase::getPosition(%aiCL));
	}
	// Told to not shoot them
	else
	{
		if( %rand > 0.8)
			%sound = "SoundHrmph"@%ai.voice;
		else if( %rand > 0.3)
			%sound = "SoundSorry"@%ai.voice;
		else
			%sound = "SoundDamnit"@%ai.voice;
		playSound(%sound,GameBase::getPosition(%aiCL));
	}
}

//----------------------------------------------------------
// Will radio for "assistance"
// Type of assistance depends on the AI type.
// Might be spawning new AIs to come help, might he putting everyone on alert
//  or it might be calling some near by AIs to rush in and help.
//----------------------------------------------------------
function AAi::RadioForAssistance(%aiName,%ai,%aiCL,%aiObj)
{
	echo(%Ainame@" is using radio...");
	player::unmountitem(%aiObj, 5);
	if(player::isdead(%aiObj))
		return;
	AAI::AddToStats(player::getclient(%ai.target), "causedradio");
	Player::setAnimation(%aiObj, 20); // Call em in!

	// Grab our internal AI folder
	//%AIRoot = group::GetObject(%ai.root,2);
	//%delay = String::GetSubStr(object::GetName(%AIRoot),8,String::getLength(object::GetName(%AIRoot)));
	
	%path = getgroup(%ai.Patrol);
	%count = %path.delaycount;
	if(%count == 0)
		%count = 1;

	for(%x = 0; %x < %count; %x++)
	{
		%AIRoot = %path.DelayID[%x];
		%delay = 0;
		if(%path.GroupDelay[%x])
			%delay = %path.GroupDelay[%x];
		echo("Calling: Radio"@%AIRoot);
		schedule("LoadDelayGroup("@nametoid("MissionGroup\\AIs\\"@Object::Getname(getGroup(getGroup(%path))))@", Radio"@%AIRoot@");",%delay);
	}
	
	
	//schedule("AAI::RadioForAssistanceComplete("@%aiName@","@%ai@","@%aiCL@","@%aiObj@");",%delay,%ai);

}
function AAI::RadioForAssistanceComplete(%aiName,%ai,%aiCL,%aiObj)
{
	
	%numAIGroups = group::objectcount(%ai.root);

	if(%numAIGroups > 2)
	{
		// Grab our internal AI folders
		for(%y=2;%y<%numAIGroups;%y++)
		{
		%AIRoot = group::GetObject(%ai.root,%y);	

			// How many AIs do we have for backup
			%num = group::objectcount(%AIRoot);
		
			if(%num > 0)
			{
				// Check 
				for(%x = 0; %x<%num;%x++)
				{
					%path = group::GetObject(%AIRoot,%x);
		
					%ainame = AAI::spawn(%path,gamebase::GetTeam(%aiCL));
		
					%ai = AI::GetObject(%ainame);
					%aiCL = AI::GetId(%ainame);
					%aiObj = Client::getOwnedObject(%aiCL);
					AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);			
				}
			}
		}
	} else
	{
		// Call in anyone close by?
	}
}

//----------------------------------------------------------
// This gets called whenever someone pulls their trigger in missions with AAIs
//----------------------------------------------------------
function AAI::onFire(%this,%vec,%silent)
{
	
	if(Player::isAiControlled(%this))
		return;
	//%trans = GameBase::getMuzzleTransform(%this);
	AAI::AddToStats(Player::getClient(%this), "shotsfired");
	// Tell anyone in line of fire that they're being shot at.
	AAI::ShotsFired(%this,%vec);
//	%projectile = Projectile::spawnProjectile("AAIReactionCharge", %trans, %this, "0 0 0");
//	schedule ("deleteobject(" @ %projectile @ ");",$Locking::LockChargeTime);

	if(!%silent)
	{
		// Tell anyone in hearing distance that gunshots are sounding
		%position = GameBase::getPosition(%this);
		%set = newObject("set",SimSet); // make new box for testing.
		%num = containerBoxFillSet(%set,$SimPlayerObjectType,%position,100,100,100,0);
		for(%x=0;%x<%num;%x++)
		{
			%cur = Group::getObject(%set,%x); // get the objNum of the found object.
			if(%cur != %this && Player::isAiControlled(%cur))
			{
				if(vector::getdistance(gamebase::getposition(%cur),%position) > 10
				   || gamebase::GetTeam(%cur) != gamebase::GetTeam(%this))
				{
					AAI::HeardShootingReaction(%cur,%this);
				}
			}
		}
		deleteobject(%set);
	}
}

//----------------------------------------------------------
// Alert all AIs of shots
//----------------------------------------------------------
function AAI::ShotsFired(%shooter, %vec)
{
	%t = gamebase::getmuzzletransform(%shooter);

	
	%pos = getword(%t, 9) @ " " @ getword(%t, 10) @ " " @ getword(%t, 11);
	%viewPoint = newObject("ViewPoint", "StaticShape", "ViewPoint", false);
	gamebase::setposition(%viewPoint, %pos);
	gamebase::setrotation(%viewPoint, vector::getrotation(%vec));
	if(gamebase::getlosinfo(%viewPoint, 10000000,$pi/2@" 0 0"))
	{

		AI::CallWithId("*", AAI::CheckForFiredOnReactionWithDistance, 
			%shooter, %pos, %vec, (vector::getdistance(%pos, $LOS::Position) + $AAI::DistanceToHearBuffer), $LOS::Position, $LOS::Normal);
	}
	else
   		AI::CallWithId("*", AAI::CheckForFiredOnReaction, %shooter, %pos, %vec);
	deleteobject(%viewPoint);
}

//----------------------------------------------------------
// Check who should react.
//----------------------------------------------------------
function AAI::CheckForFiredOnReaction(%AiCl, %shooter, %pos, %vec)
{
	%aiObj = Client::GetOwnedObject(%aicl);
	%toAIVec = vector::normalize(vector::sub(vector::add(gamebase::getposition(%AiCL), "0 0 2"), %pos)); //Adding two to the AI's position to get their head, because that is where people hear from. Normally.
	if(vector::dot(%toAIVec, %vec)>$AAI::MinDotToHearBullet)
	{
       		AAI::FiredOnReaction(%aiObj, %shooter);
	}
}
function AAI::CheckForFiredOnReactionWithDistance(%AiCl, %shooter, %pos, %vec, %distance, %lospos, %losnorm)
{
	%aiObj = Client::GetOwnedObject(%aicl);
	%AiPos = vector::add(gamebase::getposition(%AiCL), "0 0 1.8");
	%toAIVec = vector::normalize(vector::sub(%AiPos, %pos));//Adding two to the AI's position to get their head, because that is where people hear from. Normally.

	if(vector::dot(%toAIVec, %vec)>$AAI::MinDotToHearBullet)
	{
		if(vector::getdistance(%aiPos, %pos) < %distance+$AAI::DistanceToHearBuffer)
		{

					%viewPoint = newObject("ViewPoint", "StaticShape", "ViewPoint", false);
					%VPPos = vector::add(%lospos, vector::scale(%losnorm, 0.15));
					gamebase::setposition(%viewPoint,%VPPos);
					if(GameBase::getLOSInfo(%viewpoint, 100,vector::getrotaim(%VPPos,%aipos)))
					{
						if($LOS::Object == client::GetOwnedObject(%aicl)||vector::getdistance($los::position, %aipos)<$MaxDistanceWithoutLOS)
						{
							
							AAI::FiredOnReaction(%aiObj, %shooter);
						}
	
					}
					deleteObject(%viewPoint);
				



			//	AAI::FiredOnReaction(%aiObj, %shooter);
		}
	}
}
$MaxDistanceWithoutLOS = 3;
//----------------------------------------------------------
// When a grenade is thrown, we need to alert any AIs in the
// area.
//----------------------------------------------------------
function AAI::GrenadeThrown(%grenade)
{
	
	// Start tracking the grenade.
	AAI::AddToStats($GrenOwner[%grenade], "grenthrown");
	AAI::TrackGrenade(%grenade);
	
}

function AAI::TrackGrenade(%grenade)
{
	
	if(!%grenade || %grenade == -1 || !%grenade.dead)
	{
		// If anyone is in 20m of us, check if they can see the grenade.
		%position = GameBase::getPosition(%grenade);
		%set = newObject("set",SimSet); // make new box for testing.
		%num = containerBoxFillSet(%set,$SimPlayerObjectType,%position,20,20,20,0);
		for(%x=0;%x<%num;%x++)
		{
			%cur = Group::getObject(%set,%x); // get the objNum of the found object.
			if(Player::isAiControlled(%cur))
			{
				AAI::SawGrenadeReaction(%cur,%grenade);
			}
		}
		deleteobject(%set);
		

		schedule("AAI::TrackGrenade("@%grenade@");",0.1,%grenade);
	}
}

//----------------------------------------------------------
// When a grenade pops, we need to alert any AIs in the area.
//----------------------------------------------------------
function AAI::GrenadeExplodes(%grenade)
{
	%grenade.dead = true;
	%position = gamebase::Getposition(%grenade);
	
	// Anyone that could have heard it should be warned. (Grenades arn't loud like guns.. make it 50m..)
	%set = newObject("set",SimSet); // make new box for testing.
	%num = containerBoxFillSet(%set,$SimPlayerObjectType,%position,50,50,50,0);
	for(%x=0;%x<%num;%x++)
	{
		%cur = Group::getObject(%set,%x); // get the objNum of the found object.
		if(Player::isAiControlled(%cur))
		{
			
			AAI::AddToStats($GrenOwner[%grenade], "grenheard");
			AAI::HeardShootingReaction(%cur,$GrenOwner[%grenade]);
		}
	}
	deleteobject(%set);
}



//----------------------------------------------------------
// When we've found an enemy, we'll start shooting at him.
//----------------------------------------------------------
function AAI::targetEnemy(%aiName,%ai,%aiCL,%aiObj)
{
	//echo(%ainame@" targetting "@%ai.target);
	AAI::AddToStats(player::getclient(%ai.target), "timestargetted");
	if(%ai.target != "")
	{
		AI::setvar(%aiName,SpotDist,$AAI::MissionVisibleDistance);
		//%ai.target = "";
		AAI::RunToClosestReactPosition(%aiName,%ai,%aiCl,%aiObj);
		if(%ai.target == "*")
		{
			schedule(%ai@".target = \"\";",10);
		}
	}
	schedule("AAI::TestPatrolResume("@%aiName@","@%ai@","@%aiCL@","@%aiObj@");",10+getRandom()*30,%ai);
}

// Problem here is, we don't know when they arrive at that position.
// Which means we can't clear their directive queue, which means they start
// running off to never never land. Fixed?
function AAI::RunToClosestReactPosition(%aiName,%ai,%aiCl,%aiObj)
{
	%num = group::objectcount(%ai.react);
	if(%num > 0)
	{
		%pos = gamebase::Getposition(%aiCl);
		%best = "";
		%bestdist = "";
		for(%x=0; %x < %num;%x++)
		{
			%cur = group::getObject(%ai.react,%x);
			%Curpos = gamebase::Getposition(%cur);
			%curDist = vector::getDistance(%curpos,%pos);
			if(%best == "" || %bestDist > %curDist)
			{
				%best = %cur;
				%bestDist = %curDist;
			}
		}

		// %Best is now our best bet for safety.
		// Run to it!
		//if(%aicl.lastrunningpos == gamebase::getposition(%aicl))
		//	echo("AHA!");
	
		AI::DirectiveRemove(%aiName,100); //Cause of some console spam
		//%aicl.lastrunningpos = gamebase::getposition(%aicl);
		AI::DirectiveWaypoint(%aiName,gamebase::getposition(%best));
	} else if(%ai.target != "")
	{
		// Charge! (?)
		AI::setvar(%aiName,attackmode,0);
		AAI::WatchEnemy(%aiName,%ai,%aiCl,%aiObj);
	}
}

function AAI::WatchEnemy(%aiName,%ai,%aiCl,%aiObj)
{
	if(%ai.status == $AAI::StatusReact)
	{
		if(%ai.target != "" && %ai.target != -1)
		{
			%ai.targetPos = gamebase::Getposition(%ai.target);
			Schedule("AAI::WatchEnemy("@%aiName@","@%ai@","@%aiCl@","@%aiObj@");",0.2);
		} else if(%ai.target != -1)
		{	
			
		AI::DirectiveRemove(%aiName,100);
		
			AI::DirectiveWaypoint(%aiName,%ai.targetPos);
		}		
	}
}

function AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj)
{
	if((%ai.target == -1 || %ai.target == "" ) && %ai.status == $AAI::StatusReact)
	{
		%ai.status = $AAI::StatusPatrol;
		%ai.target = "";
		AI::setvar(%aiName,SpotDist,0);
		
		AI::DirectiveRemove(%aiName,100);
		
		if(%ai.nextWaypoint == -1)
		{	
			// Need to go to the last waypoint.
			%ai.nextWaypoint = group::objectcount(%ai.patrol)-1;
		}

		//%wp = group::getobject(%ai.patrol,%ai.nextWaypoint);
		if(group::objectcount(%ai.react)==0)
			%ai.nextWaypoint = AAI::CheckPassedWP(%ai, %aicl, %ai.nextWaypoint);
			
		%wp = group::getobject(%ai.patrol,%ai.nextWaypoint);
	
		AI::DirectiveWaypoint(%aiName,gamebase::getposition(%wp));
		
		AAI::Patrol(%aicl);
	}
}
function AAI::CheckPassedWP(%ai, %aiCl, %num)
{
	//echo(%num);
	if(%num == group::objectcount(%ai.patrol))
		return group::objectcount(%ai.patrol)-1;
	%wp = group::getobject(%ai.patrol, %num);
	if(%num == 0)
		return 0;
	if(%wp.isinitialpath)
	{
		%pathdir = vector::normalize(vector::flatten(vector::sub(gamebase::getposition(%wp), gamebase::getposition(group::getobject(%ai.patrol, %num-1)))));
		%aidir = vector::normalize(vector::flatten(vector::sub(gamebase::getposition(%wp), gamebase::getposition(%aiCl))));
		//echo(%num@": "@vector::dot(%pathdir, %aidir));
		if(vector::dot(%pathdir, %aidir)<0)
			return AAI::CheckPassedWP(%ai, %aiCl, %num++);

	}
	
	return %num;
}

function vector::flatten(%vec)
{
	return getword(%vec, 0)@" "@getword(%vec, 1)@" 0";
}

function AAI::onTargetLOSAcquired(%aiName, %idNum)
{
	

	%ai = AI::GetObject(%ainame);
	%aiCL = AI::GetId(%ainame);
	
	%aiObj = Client::GetOwnedObject(%aiCL);
	%ai.target = %idNum;
}

function AAI::onTargetDied(%aiName, %idNum)
{
	%ai = AI::GetObject(%ainame);
	%aiCL = AI::GetId(%ainame);
	
	%aiObj = Client::GetOwnedObject(%aiCL);
	schedule("AAI::TestPatrolResume("@%aiName@","@%ai@","@%aiCL@","@%aiObj@");",10,%ai);
//	AI::setvar(%aiName,SpotDist,0);
	%ai.target = -1;
}                                 

function AAI::onTargetLOSLost(%aiName, %idNum)
{
	%ai = AI::GetObject(%ainame);
	%aiCL = AI::GetId(%ainame);
	
	%aiObj = Client::GetOwnedObject(%aiCL);
	schedule("AAI::TestPatrolResume("@%aiName@","@%ai@","@%aiCL@","@%aiObj@");",10,%ai);
//	AI::setvar(%aiName,SpotDist,0);
	%ai.target = "";
}

function AAI::onTargetLOSRegained(%aiName, %idNum)
{
	%ai = AI::GetObject(%ainame);
	%aiCL = AI::GetId(%ainame);
	
	%aiObj = Client::GetOwnedObject(%aiCL);
	%ai.target = %idNum;
}

function AAI::onDroneKilled(%aiName)
{
	%aiCL = AI::GetId(%ainame);
	
	if(%aiCL.AIisDead == true)
		return;
	%ai.AIisDead = true;
	%aiCL.AIisDead = true;
	%path = getgroup(AI::GetObject(%ainame).patrol);
	//echo(%aiCL@": "@%ainame@"-->"@%path@" or "@getgroup(AI::GetObject(%ainame).patrol));
	if(%path.AAIFuncOnDeath!= "")
		eval(%path.AAIFuncOnDeath@"(\""@%aiName@"\");");
	%ai = AI::GetObject(%ainame);
	%ai.AIisDead = true;
	if(%ai.MoveTogether)
	{
		String::ReplaceAll($AIsTogether[getgroup(%path)], %ainame@" ", " ");
		//echo($AIsTogether[getgroup(%path)]);
		CheckGroupMotion(getgroup(%path));
	}

	if(%path.NoDeleteOnDone)
		return;
	
	if(%ai.hasradio)
	{
	%path = getgroup(%ai.Patrol);
	for(%x = 0; %x < %path.DelayCount; %x++)
	{
		object::getname(getgroup(%path));
		%AIRoot = %path.DelayID[%x];
		eval("function "@object::getname(getgroup(getgroup(%path)))@"::Radio"@%airoot@"() {}");
	}

	}

	deleteobject(%path);
	
	$AAI::Dead[%aiName] = true;
}

function String::replaceAll(%string, %search, %replace)
{
	
	%loc = String::findSubStr(%string, %search);

	while(%loc != -1)
	{
		%ls = String::QuickLen(%search);

		%part1 = String::getSubStr(%string, 0, %loc);
		%part2 = String::getSubStr(%string, %loc + %ls, 99999);

		%string = %part1 @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}

	return %string;
}

function AAI::PrepFiles()
{
	%fold = $MissionName@" AIFiles";
	%file = File::findFirst(%fold@"\\*.cs");
	while(%file != "")
	{
		%i++;
		%name = file::getbase(%file);
		
		if(%name == "Boundries"||%name == "Miscellaneous"||%name == "Functions")
		{
			exec(%file);
		} else {
		%quad = getword(%name, 0);
		
		%root = getword(%name, 1);
		echo(%root@" set to trigger in quadrant #"@%quad);
		$AAISpawning::QuadrantTrigger[%quad] = %root; //T for trigger just for nameing, has no effect codewise.
		$AAISpawning::QuadrantSpawned[%quad] = 0; 
		$AAISpawning::SpawnFile[%root] = %file;
		$AAISpawning::QuadrantTriggered[%quad] = 0;
		
		}	
		%file = File::findNext(%fold@"\\*.cs");
	
	}
	
}
function SetupAAILoad(%root)
{

%group = newObject(%root, SimGroup); 
addtoset(nametoid("MissionGroup\\AIs"), %group);
if($AAIKillIt)
	return;

exec($AAISpawning::SpawnFile[%root]);
for(%x = 0; %x < $AAISpawning::DelayCount[%root]; %x++)
{
	
	schedule("LoadDelayGroup("@%group@", \"AIDelay"@%x@"\");", $AAISpawning::GroupDelay[%root, %x]);
}
}

function LoadDelayGroup(%rootgroup, %name)
{
	%root = Object::getname(%rootgroup);
	eval(%root@"::"@%name@"();");
	if($nooverwritefuncs != 1)
	{
	eval("function "@%root@"::"@%name@"() {}");
		//deletefunctions(%root@"::"@%name@"*");
	}
	%delaygroup = nameToId("NewDelay");
	addtoset(%rootgroup, %delaygroup);
	
	renameObject(%delaygroup, "AI Delay"@%delaygroup.delay);
	$AllAISpawned[%delaygroup] = 0;
	if(%delaygroup.movetogether || %delaygroup.spawnall || String::FindSubStr(%name, "Radio") != -1)
		AAI::SpawnAIDelayGroup(%delaygroup, 1);
	else if(%delaygroup.randomfactor)
		AAI::SpawnAIDelayGroup(%delaygroup, %delaygroup.randomfactor);
	else
		AAI::SpawnAIDelayGroup(%delaygroup, $AAI::DefaultRandomFactor);
	$AllAISpawned[%delaygroup] = 1;
	if(%delaygroup.movetogether)
		CheckGroupMotion(%delaygroup);
}
function MoveToAIWP(%name, %x)
{
	%path = group::GetObject("MissionGroup\\"@$CurDGName@"\\"@%name,%x);
	
}


function AAI::SpawnAIDelayGroup(%DelayGroup, %fact)
{
	%num = group::objectcount(%delaygroup);
	if(%num > 0)
	{
		
		for(%x = 0; %x<%num;%x++)
		{
			%path = group::GetObject(%delaygroup,%x);
			if(getrandom() < %fact || %path.mustspawn || String::FindSubStr(object::getname(%path), "Radio") != -1)
			{
			
			%ainame = AAI::spawn(%path,$AAI::TeamToSpawnTo);
		
			%ai.MoveTogether = 0;
			%ai = AI::GetObject(%ainame);
			%aiCL = AI::GetId(%ainame);
			if(%delaygroup.movetogether)
			{
				$AIsTogether[%delaygroup] = $AIsTogether[%delaygroup] @ %ainame @ " ";
				%ai.MoveTogether = 1;
			}
			%ainame.PatshsGroup = %path;
			%aiObj = Client::getOwnedObject(%aiCL);
			AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);
			if($AAI::GoSuicidal)
				schedule("player::setitemcount("@%aicl@", Grenade, 1);", 1);
			if(getrandom() < $AAI::RandomChanceForRepairKit)
				schedule("player::setitemcount("@%aicl@", repairkit, 1);", 1);
			} else {
			echo("Not spawning");
			deleteobject(%path);
			}			
		}
	}
}



//----------------------------------------------------------
// Delete after done testing...
//----------------------------------------------------------
function TestAAI()
{
	%T = 1;
	%AIRoot = nameToId("MissionGroup\\Teams\\team" @ %T @"\\AI" );
	
	%num = group::objectcount(%AIRoot);

	for(%x = 0; %x<%num;%x++)
	{
		%path = group::GetObject(%AIRoot,%x);
		%ainame = AAI::spawn(%path,%T);
		%ai = AI::GetObject(%ainame);
		%aiCL = AI::GetId(%ainame);
		%aiObj = Client::getOwnedObject(%aiCL);
		AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);			
	}

	// Intro stuff.
	%messages = Intro;
	%delay = 20;
	%team = 0;
	for(%x = 0;%x < $DF_E_Count[%messages];%x++)
	{
		%message = $DF_E_Speaker[%messages,%x] @ ": "@$DF_E_Message[%messages,%x];
	
		Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@%team@"\",\"" @%message@"\");",%delay);
		%delay = %delay + String::length(%message)/13;
	}


	// Drop stuff.
	%messages = Drop;
	%delay = %delay + 30;// 30 seconds after the commander finishes.

	// Call in the chopper.
	schedule("AirStrike::BlackhawkThree();",%delay - 55);

	%team = 0;
	for(%x = 0;%x < $DF_E_Count[%messages];%x++)
	{
		%message = $DF_E_Speaker[%messages,%x] @ ": "@$DF_E_Message[%messages,%x];
		Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@%team@"\",\"" @%message@"\");",%delay);
		%delay = %delay + String::length(%message)/13;
	}
}


function GroupTrigger::onEnter(%this, %object)
{
	
	if(Player::isAiControlled(%object))
		return;
	%object.intrigger = %this;
	
	if(Vehicle::IsVehicle(%object))
	{
		%object = Client::getOwnedObject(GameBase::getControlClient(%object));
	}

	%cl = Player::getClient(%object);
	
	%name = String::getSubStr(object::Getname(%this), 23, 10000);

	if(!Player::isAiControlled(%object) && %this.hastriggered != true && (!%this.flagtrig || player::getItemcount(%cl,CDFlag) > 0))
	{
		
		echo("LOADING: "@%name);
		eval($MissionName@"_Run"@%name@"Scripts("@%cl@");");
		SetupAAILoad(%name);
		%name2 = getword(object::getname(%this), 1);
		//eval(%name@"("@%cl@","@%this@");");
		%this.hasTriggered = true;
		
	}

	//messageall(2, client::getname(player::getclient(%object))@" entered "@String::getsubstr(object::GetName(%this), 8, 9999));
}
function GroupTrigger::onLeave(%this, %object)
{
	%object.intrigger = false;
	//messageall(1, client::getname(player::getclient(%object))@" exited "@String::getsubstr(object::GetName(%this), 8, 9999));
}


function AAI::SpawnAIsFromTrigger(%this,%object,%aiRoot)
{
	//get the group the trigger is in.
		
		// Grab our internal AI folders
			messageall(0, "Triggering "@object::GetName(%AIRoot));	
			// How many AIs do we have for backup
			%num = group::objectcount(%AIRoot);
			if(%num > 0)
			{
				// Check 
				for(%x = 0; %x<%num;%x++)
				{
					%path = group::GetObject(%AIRoot,%x);
					%ainame = AAI::spawn(%path,1);
	
					%ai = AI::GetObject(%ainame);
					%aiCL = AI::GetId(%ainame);
					%aiObj = Client::getOwnedObject(%aiCL);
					AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);			
				}
			}
		
	
}
function AAI::SpawnAIsFromTriggerold(%this,%object,%aiRoot)
{
	//get the group the trigger is in.

		// Grab our internal AI folders
			messageall(0, "Triggering "@object::GetName(%AIRoot));	
			// How many AIs do we have for backup
			%num = group::objectcount(%AIRoot);
			if(%num > 0)
			{
				// Check 
				for(%x = 0; %x<%num;%x++)
				{
					%path = group::GetObject(%AIRoot,%x);
					%ainame = AAI::spawn(%path,1);
	
					%ai = AI::GetObject(%ainame);
					%aiCL = AI::GetId(%ainame);
					%aiObj = Client::getOwnedObject(%aiCL);
					AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);			
				}
			}
		
	
}


function AAICount()
{
	%count = 0;
	for(%cur = BaseRep::getFirst();%cur != -1 && %spotted == "";%cur = BaseRep::getNext(%cur))
	{
		if(Player::isAIControlled(%cur))
			if(AI::getobject(Client::Getname(%cur)).isAAI)
				%count++;
	}
	echo(%count);

}

function AAI::GetId(%ainame)
{
if($AAI::Dead[%aiName])
{
	
	return -1;

}
return AI::GetId(%ainame);

}

function AAI::GetObject(%ainame)
{
if($AAI::Dead[%aiName])
{
	
	return -1;

}

return AI::GetObject(%ainame);

}
function Client::getPlayer(%cl)
{
	return Client::getOwnedObject(%Cl);
}


function setupsniper(%cl)
{
	player::setarmor(%cl,sarmor);
	player::Setitemcount(%cl,fiftycal,1);
	player::setitemcount(%cl,fiftycalclip,100);
	player::Setitemcount(%cl,repairkit,100);

}

function CDFlag::onDamage(%this, %object)
{
	CDFlag::onCollision(%this, %object);

}

function moomaa(%cl)
{
	%hog = newObject("","Flier","Abrams", true);
	addToSet("MissionCleanup", %hog);
	GameBase::setPosition(%hog, vector::add(gamebase::getposition(%cl), "0 0 10"));
}

function moomaa2(%cl)
{
	%hog = newObject("","Flier","Apache", true);
	addToSet("MissionCleanup", %hog);
	GameBase::setPosition(%hog, vector::add(gamebase::getposition(%cl), "0 0 10"));
}

function MoveRAAI(%ainame, %pos)
{
	%aiCL = AI::GetId(%ainame);
	gamebase::setposition(%aiCl, %pos);
}

function AAI::ClientGetName(%AICl)
{
	return $AAI::RealName[%AICl];


}

function showstuff(%this)
{

echo(%this@" "@getObjectType(%this)@" "@Object::getname(%this)@"                 "@getgroup(%this));

}
function test2los(%cl, %detail, %tweak)
{
	%pl = %cl;
	%t=gamebase::getmuzzletransform(%pl);
	%p=getword(%t, 9)@" "@getword(%t, 10)@" "@getword(%t, 11);
	%w=getword(%t, 3)@" "@getword(%t, 4)@" "@getword(%t, 5);
	%rot = vector::getrotation(%w);
	%rot = ($pi/2 + getword(%rot, 0))@" 0 "@getword(%rot, 2)+%tweak;
	%smov = vector::getfromrot(%rot, 1);
	%mov = vector::getfromrot(%rot, 1000);
	echo(%w @ " vs "@%smov);
	%tp = vector::add(gamebase::getposition(%cl), vector::add(%smov, "0 0 2"));
testlos(%p, vector::add(%p, %mov), %detail);


}
function testlos(%pos1, %pos2, %detail)
{
if(getLosInfo(%pos1, %pos2, %detail))
{
	echo($LOS::Position@" "@$LOS::Normal@" "@$LOS::Object@" "@Object::getname($LOS::Object));
	if(!$rawrrawr)
		$rawrrawr = newObject(AAIPathMarker, StaticShape, AAIPathMarker);
	else
	{
		deleteobject($rawrrawr);
		$rawrrawr = newObject(AAIPathMarker, StaticShape, AAIPathMarker);

	}
	gamebase::setposition($rawrrawr, $LOS::Position);
	gamebase::setrotation($rawrrawr, vector::getrotation($LOS::Normal));
	export("$LOS*", "config\\export1.cs", 0);
	}



}

function dellos(%cl)
{
if(gamebase::getLosInfo(client::getownedobject(%cl), 1000))
{
	echo($LOS::Position@" "@$LOS::Normal@" "@$LOS::Object@" "@Object::getname($LOS::Object));
	deleteobject($LOS::Object);

}

}

function lospos(%cl)
{
if(gamebase::getLosInfo(client::getownedobject(%cl), 1000))
{
	echo($LOS::Position@" "@gamebase::getposition($Los::object));
	

}

}

function DoShiftAll(%group, %start, %end)
{
Group::iteraterecursive(%group, DoShift, %start, %end);



}

function DoShift(%this, %start, %end)
{
if(gamebase::getposition(%this) == "0 0 0")
	return;

%dir = vector::sub(gamebase::getposition(%this), %start);
gamebase::setposition(%this, vector::add(%dir, %end));



}



function String::quickLen(%string)
{
	%len = 0;
	for(%k = 0; String::getSubStr(%string, %k, 1) != ""; %k++)
		%len++;
	return %len;
}

function String::replaceAll(%string, %search, %replace)
{
	
	%loc = String::findSubStr(%string, %search);

	while(%loc != -1)
	{
		%ls = String::QuickLen(%search);

		%part1 = String::getSubStr(%string, 0, %loc);
		%part2 = String::getSubStr(%string, %loc + %ls, 99999);

		%string = %part1 @ %replace @ %part2;
		%loc = String::findSubStr(%string, %search);
	}

	return %string;
}
function String::FindMath(%string)
{
	
	%op[0] = "*";
	%op[1] = "/";
	%op[2] = "+";
	%op[3] = "-";
	for(%i = 0; %i < 4; %i++)
	{
	%search = %op[%i];
	%loc = String::findSubStr(%string, %search);
	if(%loc != -1)
	{
		
		%ls = String::QuickLen(%search);

		%part1 = String::getSubStr(%string, 0, %loc);
		%part2 = String::getSubStr(%string, %loc + %ls, 99999);
		if(%i == 0)
			%string = String::FindMath(%part1) * String::FindMath(%part2);
		else if(%i == 1)
			%string =String::FindMath(%part1) / String::FindMath(%part2);
		else if(%i == 2)
			%string = String::FindMath(%part1) + String::FindMath(%part2);
		else if(%i == 3)
			%string = String::FindMath(%part1) - String::FindMath(%part2);
		
		
	}
	}
	return %string;
}
$Pi = 3.14159265358979;
$PitoDegFactor = $Pi/180;