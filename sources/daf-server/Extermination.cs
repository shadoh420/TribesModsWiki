$AIWeaponToType[M16] = 1;
$AIWeaponToType[SAW] = 2;
$AIWeaponToType[ShotGun] = 3;
$AIWeaponToType[LAW] = 4;

$AIWeaponToType[PSG1] = 1;
$AIWeaponToType[FiftyCal] = 2;

$AIWeaponToType[MP5] = 1;

function createAI( %aiName, %markerGroup, %armorType, %name )
{
   %group = nameToID( %markerGroup );
   
   if( %group == -1 || Group::objectCount(%group) == 0 )
   {
      dbecho(1, %aiName @ "Couldn't create AI: " @ %markerGroup @ " empty or not found." );
      return -1;
   }
   else
   {
      %spawnMarker = Group::getObject(%group, 0);
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);
	//echo("NAME: "@%name@"  AINAME: "@%ainame);
	if(%name == "")
		%name = %ainame;
      if( AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %ainame, "male2" ) != "false" )
      {
         // The order number is used for sorting waypoints, and other directives.  
         %orderNumber = 100;
	
        $AAI::RealName[AI::GetID(%ainame)] = %ainame;
	$AAI::Dead[%aiName] = false;
        AI::GetID(%ainame).AIisDead = false;
	 for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);
            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );

			$SquadWaypoint[%team, %squad, %i-1] = %spawnPos;
            
            %orderNumber += 100;
         }
			
		 $SquadWaypointNum[%team, %squad] = Group::objectCount(%group) - 1;
		 //$AISpawn[AI::getId(%aiName)] = %spawnPos;
      }
      else{
         dbecho( 1, "Failure spawning: " @ %aiName );
      }
   }
}
$RandomAIWeaponName[0] = "M16";
$RandomAIWeaponName[1] = "ShotGun";
$RandomAIWeaponName[2] = "MP5";
$RandomAIWeaponName[3] = "SAW";
$RandomAIWeaponName[4] = "PSG1";
$RandomAIWeaponName[5] = "FiftyCal";
$RandomAIWeaponName[6] = "LAW";


$RandomAIWeaponChance[M16] = 24;
$RandomAIWeaponChance[ShotGun] = 12;
$RandomAIWeaponChance[MP5] = 20;

$RandomAIWeaponChance[SAW] = 18;

$RandomAIWeaponChance[PSG1] = 10;
$RandomAIWeaponChance[FiftyCal] = 10;

$RandomAIWeaponChance[LAW] = 6;


$RandomAIWeaponToArmor["M16"] = "Infantry";
$RandomAIWeaponToArmor["ShotGun"] = "Infantry";
$RandomAIWeaponToArmor["SAW"] = "Infantry";
$RandomAIWeaponToArmor["LAW"] = "Infantry";

$RandomAIWeaponToArmor["MP5"] = "SpecOps";

$RandomAIWeaponToArmor["PSG1"] = "Sniper";
$RandomAIWeaponToArmor["FiftyCal"] = "Sniper";


function Extermination::spawnRandom(%team, %set, %type,%oldName)
{
	%lastchance = 0;
	%rand = 100*getrandom();
echo("RAND: "@%rand);
	for(%x = 0; %x < 7; %x++)
	{
		//echo("***** "@%rand@" < "@%lastchance+$RandomAIWeaponChance[$RandomAIWeaponName[%x]]@" ("@%lastchance@" + "@$RandomAIWeaponChance[$RandomAIWeaponName[%x]]@")");
		if(%rand < %lastchance+$RandomAIWeaponChance[$RandomAIWeaponName[%x]])
		{
			%weapon	= $RandomAIWeaponName[%x];
			%armor = $RandomAIWeaponToArmor[%weapon];
			%type = $AIWeaponToType[%weapon];
			//echo(%weapon@" "@%armor);
			break;
		}
		%lastchance += $RandomAIWeaponChance[$RandomAIWeaponName[%x]];
	}
	return eval("Extermination::spawn"@%armor@"("@%team@", "@%set@", "@%type@",\""@%oldname@"\");");
}

function Center(%player)
{
	%pos = 205 + getRandom()*300 @ " " @ 114 + getRandom()*300 @ " " @ 300;
	gamebase::setposition(%player,%pos);
	item::Setvelocity(%player,"0 0 0");
   		item::giveitem(%player, Parachute, 1);
		Player::mountItem(%player,Parachute,$BackpackSlot);
		Player::trigger(%player,$BackpackSlot,true);
		$ParaActivated[%player] = 1;
		schedule("doparaOne("@%player@");",1);
	player::Setarmor(%player,sarmor);
	player::Setitemcount(%player,psg1,1);
	player::Setitemcount(%player,psg1clip,10);
	player::Setitemcount(%player,law,1);
	player::Setitemcount(%player,lawammo,1);

}


function Extermination::SpawnAIs(%team, %numAIs)
{
      	%tempSet = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
      
	%numPts = Group::objectCount(%set);
	
	%first = Group::getObject(%tempSet,0);
	if($Extermination::SpecialType)
	{
		Extermination::SpawnAIsSpecial(%team,%numAIs);
	}
	else
	{
	for(%x=0;%x < %numAIs;%x++)
	{

      		%tempItem = Group::getObject(%tempSet, %x);
      		%aiName = Object::getName(%tempItem);
      		%set = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %aiName);
		
		if(String::findSubStr(%aiName, "Sniper") >= 0)
		{
			if(String::findSubStr(%aiName, "PSG1") >= 0)
				%name = Extermination::spawnSniper(%team, %set, 1,%aiName); //Team,Waypoint set, weponloadtyep
			else if(String::findSubStr(%aiName, "FiftyCal") >= 0)
				%name = Extermination::spawnSniper(%team, %set, 2,%aiName); //Team,Waypoint set, weponloadtyep
		} else if(String::findSubStr(%aiName, "Infantry") >= 0)
		{
			if(String::findSubStr(%aiName, "M16") >= 0)
				%name = Extermination::spawnInfantry(%team, %set, 1,%aiName);
			else if(String::findSubStr(%aiName, "SAW") >= 0)
				%name = Extermination::spawnInfantry(%team, %set, 2,%aiName);
			else if(String::findSubStr(%aiName, "ShotGun") >= 0)
				%name = Extermination::spawnInfantry(%team, %set, 3,%aiName);
			else if(String::findSubStr(%aiName, "LAW") >= 0)
				%name = Extermination::spawnInfantry(%team, %set, 4,%aiName);
		} else if(String::findSubStr(%aiName, "Specops") >= 0)
		{
			%name = Extermination::spawnSpecops(%team, %set, 1,%aiName);
		} else if(String::findSubStr(%aiName, "Commander") >= 0)
		{
			%name = Extermination::spawnCommander(%team,%set,1);
		}

		if(String::findSubStr(%aiName, "Loop") >= 0)
		{	
			AI::setVar( %Name,  pathType, 0); // circular
			Extermination::keepMoving(%Name);

		} else if(String::findSubStr(%aiName, "Patrol") >= 0)
		{
			AI::setVar( %Name,  pathType, 2); // two way
			Extermination::keepMoving(%Name);
		} else
		{
			AI::setVar( %Name,  pathType, 1); // one way
		}

		%player = Client::getOwnedObject(AI::getId(%Name));
		if(String::findSubStr(%aiName, "Elite") >= 0)
		{	
  			AI::SetVar(%aiName, triggerPct, 1 );
  			AI::SetVar(%aiName, SpotDist, 500 );


			$Veteran::Kills[%player,Knife] = 10;
			$Veteran::Kills[%player,Pistol] = 10;
			$Veteran::Kills[%player,M16] = 10;
			$Veteran::Kills[%player,SAW] = 10;
			$Veteran::Kills[%player,MP5] = 10;
			$Veteran::Kills[%player,PSG1] = 10;
			$Veteran::Kills[%player,Robar] = 10;
			$Veteran::Kills[%player,Shotgun] = 10;
			$Veteran::Kills[%player,Law] = 10;
			
		} else if(String::findSubStr(%aiName, "Vet") >= 0)
		{
  			AI::SetVar(%aiName, triggerPct, 0.5 );
  			AI::SetVar(%aiName, SpotDist, 300 );

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
	}
	}
}

function randomnums(%num)
{
	for(%x=0;%x<%num;%x++)
		echo(floor(getrandom()*%num));
}


function Extermination::SpawnAIsSpecial(%team, %numAIs)
{

	
	if($Extermination::AIWait)
	{
		$Extermination::AIWait = false;
		Schedule("Extermination::SpawnAIsSpecial("@%team@","@%numAIs@");",$Extermination::DelayAI);
		return;
	}
	if($Extermination::AICount > $Extermination::MaxAIs)
	{
		$Extermianation::AICount = 0;
	}
	if($Extermination::AICount || $Extermination::AICount == "")
	{
		$Extermination::AICount = 1;
	} else
	{
		$Extermination::AICount++;
	}
	
      	%tempSet = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
      
	%numPts = Group::objectCount(%tempset);
//echo(%numpts);
	%numAis = floor(getrandom()*%numPts*0.5)+1+Time::getMinutes(getsimtime())/10;//max spawn half each time
	
//	%numAis = %numPts;
	for(%x=0;%x < %numAIs;%x++)
	{
		%class = floor(getrandom()*100);
		%type = floor(getRandom()*100);
		%skill = floor(getRandom()*100)+Time::getMinutes(getsimtime());
//echo(%skill);
			%aiName = "";
		if(%skill >= 90 && !$Extermination::NoElite)
			%aiName = "Elite";
		else if(%skill >=70 && !$Extermination::NoVet)
			%aiName = "Vet";

		%spawnHere = floor(getrandom()*%numPts);

      		%tempItem = Group::getObject(%tempSet, %spawnHere);
      		
      		%set = Extermination::buildPath(%tempItem);
		
		if(%class >= 80)
		{
			if(%type >= 50)
				%name = Extermination::spawnSniper(%team, %set, 1,%aiName); //Team,Waypoint set, weponloadtyep
			else
				%name = Extermination::spawnSniper(%team, %set, 2,%aiName); //Team,Waypoint set, weponloadtyep
		} else if(%class >= 20)
		{
			if(%type >= 60)
				%name = Extermination::spawnInfantry(%team, %set, 1,%aiName);
			else if(%type >= 30)
				%name = Extermination::spawnInfantry(%team, %set, 2,%aiName);
			else if(%type >= 10)
				%name = Extermination::spawnInfantry(%team, %set, 3,%aiName);
			else
				%name = Extermination::spawnInfantry(%team, %set, 4,%aiName);
		} else
		{
			%name = Extermination::spawnSpecops(%team, %set, 1,%aiName);
		}

		AI::setVar( %Name,  pathType, 1); // one way

		%player = Client::getOwnedObject(AI::getId(%Name));
		if(%skill >= 90)
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
			
		} else if(%skill >= 70)
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
		$Extermination::AINameToSet[%Name] = %set;
	}
	%time = $Extermination::MaxOccuranceTime*getRandom();
	Schedule("Extermination::SpawnAIsSpecial("@%team@", "@%numAIs@");",%time);
}

function Extermination::BuildPath(%group)
{
	%set = newObject("set",SimSet);
	addToSet("MissionCleanup", %set);
	Extermination::recursiveBuild(%set,%group);
	return %set;
}

function Extermination::recursiveBuild(%set,%group)
{
	%marker = Group::getobject(%group,0);

	if(%marker != -1)
	{
		addtoSet(%set,%marker);	
		%num = group::objectCount(%group)-1;
		if(%num > 0)
		{
			%rand = floor(getRandom()*%num)+1;
			return Extermination::recursiveBuild(%set,group::getobject(%group,%rand));
		} else
			return %set;
	} else
		return %set;
}

function Extermination::AIKilled(%aiName)
{
	%set = $Extermination::AINameToSet[%ainame];
	deleteobject(%set);
}


function Extermination::keepMoving(%aiName)
{
	%aiId = AI::getId(%aiName);
	if(%aiName == "Commander225")
	%vel = item::GetVelocity(%aiId);
	if(getword(%vel,0) < 0.0001 && getword(%vel,0) > -0.0001 && getword(%vel,1) < 0.0001 && getword(%vel,1) > -0.0001 && getword(%vel,2) < 0.0001 && getword(%vel,2) > -0.0001)
		%vel = "0 0 0";
	if(%vel == "0 0 0" && %aiId)
	{

		Player::applyImpulse(%aiId,50*getRandom() - 50*getRandom()+50@" "@50*getRandom() - 50*getRandom()+50@" "@50*getRandom() - 50*getRandom()+50);
	}
	Schedule("Extermination::keepMoving("@%aiName@");",getRandom()*30);
}

function Extermination::spawnSniper(%team, %set, %type,%oldName,%useOld)
{
	
	%aiName2 = "Sniper";
	if(String::findSubStr(%oldName, "Elite") >= 0)
		%aiName2 = "Elite"@%aiName2;
	else if(String::findSubStr(%oldName, "Vet") >= 0)
		%aiName2 = "Vet"@%aiName2;
	%ainame = %ainame2 @ $numAI;
	$numAI++;
	
	if(getgroup(%set).BorderPatrol)
	{
	%ainame2 = "a concealed sniper";

	}
	
	if(%useOld)
		%aiName2 = %oldName;
	createAI(%aiName, %set, "sarmor", %aiName2);
	%aiId = AI::getId(%aiName);
	if(getgroup(%set).BorderPatrol)
		$BorderKiller = %aiId;

	if(%team != -1)
		GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  150 );
	schedule("Extermination::SniperWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiName;
}


function Extermination::spawnInfantry(%team, %set, %type,%oldName,%useOld)
{
	%aiName2 = "Infantry";
	if(String::findSubStr(%oldName, "Elite") >= 0)
		%aiName2 = "Elite"@%aiName2;
	else if(String::findSubStr(%oldName, "Vet") >= 0)
		%aiName2 = "Vet"@%aiName2;
	%ainame = %ainame2 @ $numAI;
	$numAI++;
	
	if(%useOld)
		%aiName2 = %oldName;

	createAI(%aiName, %set, "iarmor", %aiName2);
	%aiId = AI::getId(%aiName);

	if(%team != -1)
		GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  150 );
	schedule("Extermination::InfantryWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiName;
}


function Extermination::spawnSpecops(%team, %set, %type,%oldName,%useOld)
{
	%aiName2 = "Specops";
	if(String::findSubStr(%oldName, "Elite") >= 0)
		%aiName2 = "Elite"@%aiName2;
	else if(String::findSubStr(%oldName, "Vet") >= 0)
		%aiName2 = "Vet"@%aiName2;
	%ainame = %ainame2 @ $numAI;
	$numAI++;
	
	if(%useOld)
		%aiName2 = %oldName;

	createAI(%aiName, %set, "carmor", %aiName2);
	%aiId = AI::getId(%aiName);
	if(%team != -1)
		GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  150 );
	schedule("Extermination::SpecopsWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiName;
}

function Extermination::spawnPilot(%team, %set, %type,%oldName,%useOld)
{
	%aiName2 = "Pilot";
	if(String::findSubStr(%oldName, "Elite") >= 0)
		%aiName2 = "Elite"@%aiName2;
	else if(String::findSubStr(%oldName, "Vet") >= 0)
		%aiName2 = "Vet"@%aiName2;
	%ainame = %ainame2 @ $numAI;
	$numAI++;
	
	if(%useOld)
		%aiName2 = %oldName;

	createAI(%aiName, %set, "larmor", %aiName2);
	//Ai::spawn(%aiName, larmor, %pos, "0 0 0");
	%aiId = AI::getId(%aiName);
	if(%team != -1)
		GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  150 );
	schedule("Extermination::PilotWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiName;
}


function Extermination::spawnCommander(%team, %set, %type)
{
	%aiName2 = "Commander";
	%ainame = %ainame2 @ $numAI;
	$numAI++;
	

	createAI(%aiName, %set, "larmor", %aiName2);
	%aiId = AI::getId(%aiName);
	$Extermination::Commander[%ainame] = true;
	if(%team != -1)
		GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  150 );
	schedule("Extermination::CommanderWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiName;
}

function Extermination::SniperWeapons1(%aiName)
{
   %aiId = AI::getId(%aiName);

   dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,sarmor);
   Player::setItemCount(%aiId, PSG1, 1);
   Player::setItemCount(%aiId, PSG1Ammo, 5);
   Player::setItemCount(%aiId, PSG1Clip, 10);
   Player::mountItem(%aiId, PSG1, 0);

//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}


function Extermination::SniperWeapons2(%aiName)
{
   %aiId = AI::getId(%aiName);

   dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,sarmor);
   Player::setItemCount(%aiId, FiftyCal, 1);
   Player::setItemCount(%aiId, FiftyCalAmmo, 5);
   Player::setItemCount(%aiId, FiftyCalClip, 10);
   Player::mountItem(%aiId, FiftyCal, 0);

//   AI::SetVar(%aiName, triggerPct, 0.1 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}


function spawnAis(%num, %pos, %rad,%up,%team)
{
	for(%i = 0; %i<%num;%i++)
	{
		%base = "0 0 0";
		%pos1 = getRandom()*%rad - getRandom()*%rad @ " " @ getRandom()*%rad - getRandom()*%rad @ " " @ %up;
		%pos = vector::add(%pos,%pos1);
		%ai = spawnTarget3(%team,%player,vector::add(%pos,"1 "@%i*10@" 0"));
		

		AI::setVar( %ainame,SpotDist,500);
		player::setAnimation(%ai,42);
   		item::giveitem(%ai, Parachute, 1);
		Player::mountItem(%ai,Parachute,$BackpackSlot);
		Player::trigger(%ai,$BackpackSlot,true);
		$ParaActivated[%ai] = 1;
		schedule("doparaOne("@%ai@");",1);
	}
}

function spawnTarget3(%team, %player,%pos)
{
	%set = -1;
	%aiName = "Target" @ $numAI;
	$numAI++;

	%type = floor(getrandom()*10)+1;
	%type2 = floor(getrandom()*5)+1;

	if(%type2 >= 4)
		Ai::spawn(%aiName, carmor, %pos, "0 0 0");
	else
		Ai::spawn(%aiName, iarmor, %pos, "0 0 0");
	%aiId = AI::getId(%aiName);
	GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  100 );
	AI::setVar( %aiName,  attackMode, 0);
	AI::setVar( %aiName,  pathType, 1);
   AI::SetVar(%aiName, triggerPct, 1 );
	gamebase::setposition(%aiId,%pos);
	if(%type < 5)
		%type = 1;
	else if(%type < 7)
		%type = 2; 
	else if(%type < 9)
		%type = 3; 
	else if(%type < 11)
		%type = 4; 
	if(%type2 >= 4)
		schedule("Extermination::SpecopsWeapons"@%type%2+1@"(" @ %aiName @ ");", 1);
	else
		schedule("Extermination::InfantryWeapons"@%type@"(" @ %aiName @ ");", 1);
	return %aiId;

}

function spawnAIOn(%player)
{
	%pos = gamebase::Getposition(%player);
		%ai = spawnTarget2(1,%player,vector::add(%pos,"0 0 300"));



	
		player::setAnimation(%ai,42);
   		item::giveitem(%ai, Parachute, 1);
		Player::mountItem(%ai,Parachute,$BackpackSlot);
		Player::trigger(%ai,$BackpackSlot,true);
		$ParaActivated[%ai] = 1;
		schedule("doparaOne("@%ai@");",1);
		%player = Client::getOwnedObject(%ai);

			$Veteran::Kills[%player,Knife] = 10;
			$Veteran::Kills[%player,Pistol] = 10;
			$Veteran::Kills[%player,M16] = 10;
			$Veteran::Kills[%player,SAW] = 10;
			$Veteran::Kills[%player,MP5] = 10;
			$Veteran::Kills[%player,PSG1] = 10;
			$Veteran::Kills[%player,Robar] = 10;
			$Veteran::Kills[%player,Shotgun] = 10;
			$Veteran::Kills[%player,Law] = 10;

}

function spawnAIAt(%pos,%team,%type)
{
	%set = -1;
	%oldName = "Pilot"@ $NumAI;
	$numAI++;
	%ainame = Extermination::spawnPilot(%team, %set, 1, %oldName);
	%aiId = AI::getId(%aiName);
	GameBase::setTeam(%aiId, %team);
	AI::setVar( %aiName,  iq,  100 );
	AI::setVar( %aiName,  attackMode, 0);
	AI::setVar( %aiName,  pathType, 1);
   	AI::SetVar(%aiName, triggerPct, 1 );
	gamebase::setposition(%aiId,%pos);
	
	%ai = %aiid;
	//if(%type == Pilot)

	item::giveitem(%ai, Parachute, 1);
	Player::mountItem(%ai,Parachute,$BackpackSlot);
	//%player = Client::getOwnedObject(%ai);
	return %ainame;
}

function Extermination::SpecopsWeapons1(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,carmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, mp5, 1);
	Player::setItemCount(%aiId, mp5Ammo, 30);
	Player::setItemCount(%aiId, mp5Clip, 3);
	Player::mountItem(%aiId, mp5, 0);

//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 0);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::SpecopsWeapons2(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,carmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, Stinger, 1);
	Player::setItemCount(%aiId, StingerAmmo, 1);
	Player::setItemCount(%aiId, StingerClip, 3);
	Player::mountItem(%aiId, Stinger, 0);

//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 0);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::SpecopsWeapons3(%aiName)
{
	Extermination::SpecopsWeapons2(%aiName);
}

function Extermination::InfantryWeapons1(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,iarmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, OICW, 1);
	Player::setItemCount(%aiId, OICWAmmo, 30);
	Player::setItemCount(%aiId, OICWClip, 4);
	Player::mountItem(%aiId, OICW, 0);

//   AI::SetVar(%aiName, triggerPct, 0.5 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::InfantryWeapons2(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,iarmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, SAW, 1);
	Player::setItemCount(%aiId, SAWAmmo, 200);
	Player::setItemCount(%aiId, SAWClip, 1);
	Player::mountItem(%aiId, SAW, 0);

//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::InfantryWeapons3(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,iarmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, AutoShotgun, 1);
	Player::setItemCount(%aiId, AutoShotgunAmmo, 7);
	Player::setItemCount(%aiId, AutoShotgunClip, 10);
	Player::mountItem(%aiId, AutoShotGun, 0);

//   AI::SetVar(%aiName, triggerPct, 0.7 );
   AI::setVar(%aiName, attackMode, 0);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}


function Extermination::InfantryWeapons4(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,iarmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::setItemCount(%aiId, LAW, 1);
	Player::setItemCount(%aiId, LAWAmmo, 1);
	Player::mountItem(%aiId, LAW, 0);

//   AI::SetVar(%aiName, triggerPct, 0.1 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}


function Extermination::PilotWeapons1(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,larmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::mountItem(%aiId, SOCOM, 0);
//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::CommanderWeapons1(%aiName)
{
	%aiId = AI::getId(%aiName);

    dbecho(2, "giving normal weapon select...");
	player::Setarmor(%aiId,larmor);
    Player::setItemCount(%aiId, SOCOM, 1);
	Player::setItemCount(%aiId, SOCOMAmmo, 12);
	Player::setItemCount(%aiId, SOCOMClip, 3);

	Player::mountItem(%aiId, SOCOM, 0);
//   AI::SetVar(%aiName, triggerPct, 0.9 );
   AI::setVar(%aiName, attackMode, 1);
//   AI::setVar( %aiName,  pathType, 1);
   AI::setAutomaticTargets( %aiName );
   //ai::callbackPeriodic(%aiName, 5, ai::periodicWeaponChange);
}

function Extermination::playerSpawned(%pl, %clientId, %armor)
{
	%clientId.spawn= 1;
	%max = getNumItems();

	if($Extermination::CurSpawn[%clientId] == "medic")
	{
		%spawnlist[0] = MedicArmor;
		%spawnlist[1] = Knife;
		%spawnlist[2] = SOCOM;
		%spawnlist[3] = MP5;
		%spawnlist[4] = RepairKit;
		%spawnlist[5] = Grenade;
		%spawnlist[6] = MedicPack;
	} else if($Extermination::CurSpawn[%clientId] == "ammo")
	{
		
		%spawnlist[0] = ArtilleryArmor;
		%spawnlist[1] = Knife;
		%spawnlist[2] = SOCOM;
		%spawnlist[3] = oicw;
		%spawnlist[4] = RepairKit;
		%spawnlist[5] = Grenade;
	} else
	{

		%spawnlist[0] = $spawnBuyList[0];
		%spawnlist[1] = $spawnBuyList[1];
		%spawnlist[2] = $spawnBuyList[2];
		%spawnlist[3] = $spawnBuyList[3];
		%spawnlist[4] = $spawnBuyList[4];
		%spawnlist[5] = $spawnBuyList[5];
		%spawnlist[6] = $spawnBuyList[6];
	}

   for(%i = 0; (%item = %spawnlist[%i]) != ""; %i++)
   {
	   // DELTAFORCE
	   if($Game::missionType == "Assassination") {
		   if($Hunted == %clientId) {
			   if (%i == 2) %i++;
		   }
	   }
	   // END DELTAFORCE
		buyItem(%clientId,%item);	
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
	}
	if($Extermination::CurSpawn[%clientId] == "ammo")
	{
		player::setitemcount(%clientId,OICWClip,6);
		player::setitemcount(%clientId,SOCOMClip,6);
	}
	%clientId.spawn= "";
	$Reloading[%clientId] = 0;
	%clientid.inVehicle = false;
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);
   	%clientId.spawnWeapon="";
	}
} 


function Player::leaveMissionArea(%player)
{
   	%cl = Player::getClient(%player);
	if($Game::missionType == "Extermination" && !Player::isAiControlled(%player))
	{
		playSound(ricochet1,gamebase::Getposition(%player));
		Client::sendMessage(Player::getClient(%player),1,"An enemy sharp shooter spotted you. Sorry.");
		GameBase::applyDamage(%player,$LaserDamageType, 100.0,vector::add(GameBase::getPosition(%player),"0 0 3"),"0 0 0","0 0 0",2048);
	}
}


function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}


function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) {
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.1);
	   	schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else { 
			playNextAnim(%client);	
			Client::onKilled(%client, %client);
		}
	}
}



function Trigger::oncollision(%this, %object){
	if(Object::Getname(%this) == "Extermination")
	{
		GroupTrigger::onContact(%this,%object);
	}
}

function GroupTrigger::oncollision(%this, %object){
	if(Object::Getname(%this) == "Extermination")
	{
		GroupTrigger::onContact(%this,%object);
	}
}

function GroupTrigger::onContact(%this, %object)
{
	if(Object::Getname(%this) == "Extermination" && $Game::missionType == "Extermination" && !Player::isAiControlled(%object))
	{
		playSound(ricochet1,gamebase::Getposition(%object));
		Client::sendMessage(Player::getClient(%object),1,"An enemy sharp shooter spotted you. Sorry.");
		GameBase::applyDamage(%object,$LaserDamageType, 100.0,vector::add(GameBase::getPosition(%object),"0 0 3"),"0 0 0","0 0 0",2048);
	}
}	


function go()
{
	extraction::spawnExtractionvehicle("-1734.74 -280.868 125",0);
//	extraction::spawnExtractionvehicle(MoveBlackhawkExtractionVehicle,"-1734.74 880.868 50",0);
}

function Extraction::SpawnExtractionVehicle(%pos,%team)
{
	// Pos = -1828 881 125;
	%type = MoveBlackhawkExtractionVehicle;
	%player = 2048;
	%seq = 1;
	
	%vehicle = newObject("",flier,$DataBlockName[%type],true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,%team);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);

	%type = Vehicle::GetDataName(%vehicle);
	%group = AirStrike::SpawnPathMarkers(%pos,%vehicle,%type,%seq);
	%vehicle.group = %group;
	AirStrike::StartAttackRun(%vehicle,%player,%type,%seq);


	return;	



	// Spawn Vehicle
	%vehicle = newObject("",flier,"MoveBlackhawkExtraction",true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,%team);
	%vehicle.fading = 1;
	GameBase::startFadeIn(%vehicle);
	schedule(%vehicle @ ".fading = \"\";",5,%vehicle);
	GameBase::setPosition(%vehicle,%Pos);
	schedule("Extraction::StartExtractionRun("@%vehicle@");",40.0,%vehicle);
}


function Extraction::startExtractionRun(%vehicle)
{
//echo("Extraction::StartExtractionRun");
	%vehicle.turnLeft = true;
	Extraction::RotationLeft(%vehicle);
	schedule("Extraction::RotationLeft("@%vehicle@");",13.2,%vehicle);
	schedule("Extraction::Land("@%vehicle@");",17.2,%vehicle);
}

function Extraction::rotationLeft(%vehicle)
{
//echo("Mark");
	if(%vehicle && !%vehicle.dead && %vehicle.turnLeft && gamebase::Getposition(%vehicle) != "0 0 0")
	{
		%rot = gamebase::Getrotation(%vehicle);
		%z = getWord(%rot,2);
		if($plummeting[%vehicle] != 1)
		{
			%z = %z+ 0.03;
			if(%vehicle && !%vehicle.dead && gamebase::Getposition(%vehicle) != "0 0 0")
			{
				gamebase::Setrotation(%vehicle,getword(%rot,0)@" " @getWord(%rot,1)@ " " @%z);
			}
		}
		
		schedule("Extraction::rotationLeft("@%vehicle@");",0.1,%vehicle);
	}
}

function Extraction::Land(%oldvehicle)
{
	%oldvehicle.turnLeft = false;
	
	schedule("Extraction::SwitchVehicles("@%oldVehicle@");",1.7);
}

function Extraction::SwitchVehicles(%oldVehicle)
{
	%vehicle = newObject("",flier,Blackhawk,true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,gamebase::getTeam(%oldvehicle));
	%vehicle.fading = "";
	GameBase::setRotation(%vehicle,vector::add(gamebase::Getrotation(%oldVehicle),"0.8 0 0"));
	Item::setvelocity(%vehicle,item::getvelocity(%oldVehicle));
	%pos = gamebase::getposition(%oldVehicle);
	gamebase::setposition(%oldVehicle,"0 0 -1000");
	GameBase::setPosition(%vehicle,%pos);
	AirStrike::removeVehicle(%oldVehicle);
	//deleteobject(%oldvehicle);
	schedule("Extraction::EndGame("@%vehicle@");",15,%vehicle);
}

function Extraction::LandAndWait(%oldVehicle)
{
	%vehicle = newObject("",flier,Blackhawk,true);
	Gamebase::setMapName(%vehicle,GameBase::getDataName(%vehicle).description);
     	%vehicle.clLastMount = "";
	addToSet("MissionCleanup", %vehicle);
	GameBase::setTeam(%vehicle,gamebase::getTeam(%oldvehicle));
	%vehicle.fading = "";
	GameBase::setRotation(%vehicle,vector::add(gamebase::Getrotation(%oldVehicle),"0.8 0 0"));
	Item::setvelocity(%vehicle,item::getvelocity(%oldVehicle));
	%pos = gamebase::getposition(%oldVehicle);
	gamebase::setposition(%oldVehicle,"0 0 -1000");
	GameBase::setPosition(%vehicle,%pos);
	AirStrike::removeVehicle(%oldVehicle);
	//deleteobject(%oldvehicle);


	schedule("Extraction::TakeOff("@%vehicle@",0);",60,%vehicle);
}

function Extraction::TakeOff(%vehicle,%count)
{
	if(%count < 100)
	{
		gamebase::setposition(%vehicle,vector::Add(gamebase::Getposition(%vehicle),"0 0 1"));
		schedule("Extraction::TakeOff("@%vehicle@","@%count++@");",0.05,%vehicle);
	} else
	{
		// Delete Vehicle
		%pos = gamebase::Getposition(%vehicle);
		deleteobject(%vehicle);
		AirStrike::BlackhawkFour(%pos);
	}
}

function Extraction::EndGame(%vehicle)
{
	$TeamScore[0] = $teamScoreLimit;
}
