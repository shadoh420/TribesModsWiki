//=========================================================================================================================================
//This will spawn an AI player in a map that does not yet contain a bot
//by Werewolf
//=========================================================================================================================================
//
// The following function has been modified so that armors can be modifies in the shifter_v1/spoonbot .cs file... This is to allow the bots
// to be much more configurable by the system admin... Check the Spoonbot.cs file for more details on this!!!
//																																Emo1313
//=========================================================================================================================================

function AI::SpawnAdditionalBot(%aiName, %teamnum, %commandIssuer, %spawnFromAdmin)
{
	if (%aiName == "")
		return;

	$numAI = 0;
	%spawnMarker = AI::pickRandomSpawn(%teamnum);
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
	
		%rPos = %spawnRot;
		%xPos = getWord(%spawnPos, 0);
		%yPos = getword(%spawnPos, 1);
		%zPos = getWord(%spawnPos, 2);
		%aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
	//	dbecho(1, "Random Spawn Position is: " @ %xPos @ "  " @ %yPos @ "  " @ %zPos);
	
	//== Setup Bot Armors ===============================================================================================================
	
	//Declaring Armorsetup. Stuff Moved to BotGear. Ganvit.
	//It was originally declared in this function as in if statement
	//so this function has to be called.

	BotsArmor::SetupArmor(%aiName);

	//=== Done Setting Up Armors =============================================================================================

	//LATEST VERSION INFO 5i.
	//CODE FOR STOMBOTS THAT SPAWN BY THE PLAYER AFTER BOUGHT.

	if (%spawnFromAdmin == 1) // Is it going to be a purchaseable bot?
	{
		%spawnMarker = GameBase::getPosition(%commandIssuer);
		%xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 15) - 7.5;
		%yPos = getword(%spawnMarker, 1) + floor(getRandom() * 15) - 7.5;
		%zPos = getWord(%spawnMarker, 2) + 5;
		%rPos = GameBase::getRotation(%commandIssuer);
		%aiSpawnPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;
   
		dbecho(2, "Spawning AI helper at position " @ %xPos @ " " @ %yPos @ " " @ %zPos);
		dbecho(2, "Current Issuer rotation: " @ %rPos);
      
		if (%teamnum == 0)
			%TeamLabel = $Server::teamLabel0;
		if (%teamnum == 1)
			%TeamLabel = $Server::teamLabel1;
		if (%teamnum == 2)
			%TeamLabel = $Server::teamLabel2;
		if (%teamnum == 3)
			%TeamLabel = $Server::teamLabel3;
		%newName = %TeamLabel @ "_" @ %aiName;
		%spawnSuccessfull = 0;
		if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
		{
			$Spoonbot::NumBots = $Spoonbot::NumBots + 1;
			%spawnSuccessfull = 1;
			echo("MSG: ",%commandIssuer," deployed ",%newName);
		}
		else
		{
			dbecho( 1, "Cannot spawn " @ %aiName @ ", only 1 bot per class allowed for each team");
			return;
		}
	}
	else
	{                      
		%newName = %aiName;
		if( AI::spawn( %newName, $AI::defaultArmorType, %aiSpawnPos, %rPos, %newName, %voice  ) != "false" )
		{
			$Spoonbot::NumBots = $Spoonbot::NumBots + 1;
			%spawnSuccessfull = 1;
			%aiId = BotFuncs::GetId(%aiName);
			$BotThink::BotHome[%aiId] = %spawnPos; // Set AI homepoint as spawnpoint. Wicked69
			//dbecho( 1, "AutoSpawn successfull for " @ %aiName );
		}
		else
		{
			dbecho( 1, "AutoSpawn error: Cannot spawn " @ %aiName );
			return;
		}
	}

	newObject("AI", SimGroup);
	newObject(%newName, SimGroup);
	newObject("Marker1", Marker, PathMarker,0,%xPos,%yPos,%zPos,0,0,0);
	addToSet(%newName, "Marker1");
	addToSet("AI", %newName);
	addToSet("MissionGroup\\Teams\\team" @ %teamnum, AI);
	
	%aiId = BotFuncs::GetId( %newName );
	GameBase::setTeam(%aiId, %teamnum);
	%aiobj = Client::getOwnedObject(%aiId);

	$invulnerable[%aiId] = 0;
	schedule("$invulnerable["@%aiId@"] = 0;",0);

	AI::setVar( %newName,  iq,  90 );
	AI::setVar( %newName,  attackMode, 1);
	AI::setVar( %newName,  pathType, $AI::defaultPathType);
//	AI::DirectiveWaypoint( %newName, %aiSpawnPos, 2, 2 );
	schedule("AI::setWeapons(" @ %aiId @ ");", 1); 
	
//	Add Bot think function to schedule - Wicked69
	BotFuncs::InitVars( %aiId );      // Wicked69
	Client::setSkin(%aiId, $Server::teamSkin[Client::getTeam(%aiId)]);  // Werewolf
	if (BotTypes::IsMedic(%newName))    //As of yet only one Medic can work in the Object Repair Task Queue. (This means repairing Turrets, etc)
	{
		if (%teamnum == 0)
			 $Spoonbot::Team0Medic = %aiId;
		if (%teamnum == 1)
			 $Spoonbot::Team1Medic = %aiId;//ADDED TWO MORE TEAMS, just incase the map had more then two teams.
		if (%teamnum == 2)
			 $Spoonbot::Team2Medic = %aiId;
		if (%teamnum == 3)
			 $Spoonbot::Team3Medic = %aiId;
		$Spoonbot::MedicTask[%aiId] = -1;
	}
	
	$BotThink::Definitive_Attackpoint[%aiId] = "";
	$BotThink::ForcedOfftrack[%aiId] = true;

	if(BotTypes::IsCmd(%newName))
		schedule("BotThink::CommandThink(" @ %aiId @ ", True);", 3);
	else
		schedule("BotThink::Think(" @ %aiId @ ", True);", 3);      // Wicked69
	schedule("BotMove::Move(" @ %aiId @ " );", 3);      // Werewolf
	
	return ( %newName );
}

//Moved this function to BotFuncs.cs.  Ganvit.
//AI::setupAI(%key, %team);

//Moved this from ai.cs.  Ganvit
function AI::ProcessAutoSpawn()
{
	if (($Spoonbot::AutoSpawn) && (!$Spoonbot::BotTree_Design)) // Not more bots in design mode.
	{
		%t = 0.5;
		for(%i = 0; $Spoonbot::Team0Name[%i] != ""; %i++)
		{
			schedule("AI::spawnAdditionalBot(" @ $Spoonbot::Team0Name[%i] @ ", 0, 0);",%t);
			%t += 0.5;
		}
		if(getNumTeams() >= 2)
		{
			for(%i = 0; $Spoonbot::Team1Name[%i] != ""; %i++)
			{
				schedule("AI::spawnAdditionalBot(" @ $Spoonbot::Team1Name[%i] @ ", 1, 0);",%t);
				%t += 0.5;
			}
		}
		if(getNumTeams() >= 3)
		{
			for(%i = 0; $Spoonbot::Team2Name[%i] != ""; %i++)
			{
				schedule("AI::spawnAdditionalBot(" @ $Spoonbot::Team2Name[%i] @ ", 2, 0);",%t);
				%t += 0.5;
			}
		}
		if(getNumTeams() >= 4)
		{
			for(%i = 0; $Spoonbot::Team3Name[%i] != ""; %i++)
			{
				schedule("AI::spawnAdditionalBot(" @ $Spoonbot::Team3Name[%i] @ ", 3, 0);",%t);
				%t += 0.5;
			}
		}
	}
}
