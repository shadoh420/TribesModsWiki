function BotBehaviour::RepairSomething(%aiName, %aiId, %aiTeam)
{
	// Try to find item to repair.

	BotFuncs::checkObstacle(%aiId);
	%Task = BotFuncs::GetRepairTask(%aiName, %aiId, %aiTeam);

	if ($Spoonbot::DebugMode)
		dbecho(1,%ainame @ " finding task " @ %Task);

	if(%Task > 0) // Have a target ? Close enough to repair ? repaired ?
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " found target");

		%object = %Task;
		%objectpos = GameBase::getPosition(%object);
		%aiPos = GameBase::getPosition(%aiId);
		%curDistance = Vector::getDistance(%objectpos,%aiPos);  //Check if AI is in range for repairs

		if ($Spoonbot::DebugMode)
			dbecho(1,"distance = " @ %curdistance);

		if (%curDistance < 25)
			BotFuncs::RepairObject(%aiName, %object);
		else
		{
			if ($Spoonbot::DebugMode)
				dbecho(1,"Target pos = " @ %objectpos);

			$Spoonbot::BotStatus[%aiId] = "Moving to Objective";
			BotTree::GetMeToPos(%aiId,%objectpos,true);

			$BotThink::Definitive_Attackpoint[%aiId] = %object;
			$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
			$BotThink::ForcedOfftrack[%aiId] = false;
			$BotThink::LastPoint[%aiId] = True;
		}
	}

	else // no repair task, do nothing
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no repair target");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}


function BotBehaviour::GuardTheFlag(%aiName, %aiId, %aiTeam)
{
	//Defend and Chase-Return the flag

	if (%aiId==0)
		return;
	if (!BotFuncs::CheckAlive(%aiId))
		return;

	//now sticks to flag and hunts it down if flag is gone

	BotFuncs::checkObstacle(%aiId);

	%imtheone = 0;
	%flagId = BotFuncs::GetFlagId(%aiTeam);
	%flagPos = GameBase::GetPosition(%flagId);

	//Jump up and forward every now and then just in case

	%flyaway = floor(getRandom() * 10); 
	if (%flyaway == 0)
	{
		if ($Spoonbot::BotEvadeUp[%aiId] != 1)
		AI::EvadeUp(%aiId);
	}

	//Enumerate all clients and see if an enemy has flag

	for(%cl = 2049; %cl <= 2138; %cl++)
	{
		%clteam = Client::getTeam(%cl);

		if(%clteam != %aiTeam)	//Client is not same team as bot
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)	//An enemy has a flag
					if(GameBase::getTeam(%player.carryFlag) == %aiTeam)  //Carried flag is the same team as the bot
						%imtheone = %cl;
			}
		}
	}

	if (%imtheone != 0)	//If so then follow that enemy
	{
		BotFuncs::FollowPlayer(%aiName, %aiId, %imtheone);
		$Spoonbot::BotStatus[%aiId] = "Retrieving Our Flag";
	}

	else	//If not then go right to the flag
	{
		// can bot see the flag?
		if (BotFuncs::CheckForItemLOS(%aiId, %flagId) && Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%flagId)) <= 25)
			$Stormbots::LastSawFlag[%aiId] = 0;
		else // can't see flag
		{
			$Stormbots::LastSawFlag[%aiId]++;
			if($Stormbots::LastSawFlag[%aiId] > 80) //hasn't seen flag for quite a while
			{
				BotFuncs::TeleportToPosition(%aiId,%flagPos);
				$Stormbots::LastSawFlag[%aiId] = 0;
			}
		}
		BotTree::Getmetopos(%aiId,%flagPos, false);
		$BotThink::Definitive_Attackpoint[%aiId] = %flagId;
		$BotThink::Definitive_Attackpos[%aiId] = %flagPos;
		$BotThink::ForcedOfftrack[%aiId] = True;
		$BotThink::LastPoint[%aiId] = false;
		$Spoonbot::BotStatus[%aiId] = "Guarding Our Flag";
	}
}


function BotBehaviour::PaintSomething(%aiName, %aiId, %aiTeam)
{
	// Paint enemy installations.

	if ($Spoonbot::DebugMode)
		dbecho(1, "Painter code running");

	BotFuncs::checkObstacle(%aiId);

	%foundone = false;
	for(%object = 0; (%object <= $BotFuncs::AllCount); %object++)
	{
		%potentialTarget = $BotFuncs::AllList[%object];
		%PTname = GameBase::getDataName(%potentialTarget);
		%PTteam = GameBase::getTeam(%potentialTarget);

		if ($Spoonbot::DebugMode)
		{
			dbecho(1,"potentialTarget= "@ %potentialTarget);
			dbecho(1,"PTname= "@ %PTname);
			dbecho(1,"PTteam= "@ %PTteam);
			dbecho(1,"Distance= "@ Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)));
		}

		if (%aiTeam != %PTteam && GameBase::getDamageLevel(%potentialTarget) <= 0.7 && %PTname != "" && %PTteam != -1)
		{
			if (!%foundone)
			{
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) + 1;
				%foundone = true;
			}
			if (Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) < %range)
			{
				%gotTarget = %potentialTarget;
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget));
			}
		}
	}

	if (%gotTarget > 0)
	{
		AI::SetVar(%aiName, triggerPct, 1000 );
		BotFuncs::PaintTarget(%aiName, %gotTarget);
	}
	else
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no target to paint");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}


function BotBehaviour::DestroySomething(%aiName, %aiId, %aiTeam)
{
	// Attack and destroy enemy installations

	if ($Spoonbot::DebugMode)
		dbecho(1, "Demo code running");

	BotFuncs::checkObstacle(%aiId);
	%foundone = False;
	for(%object = 0; (%object <= $BotFuncs::AllCount); %object++)
	{
		%potentialTarget = $BotFuncs::AllList[%object];
		%PTname = GameBase::getDataName(%potentialTarget);
		%PTteam = GameBase::getTeam(%potentialTarget);

		if ($Spoonbot::DebugMode)
		{
			dbecho(1,"potentialTarget= "@ %potentialTarget);
			dbecho(1,"PTname= "@ %PTname);
			dbecho(1,"PTteam= "@ %PTteam);
			dbecho(1,"Distance= "@ Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)));
		}

		if (%aiTeam != %PTteam && GameBase::getDamageLevel(%potentialTarget) <= 0.7 && %PTname != "" && %PTteam != -1)
		{
			if (!%foundone)
			{
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) + 1;
				%foundone = True;
			}
			if (Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget)) < %range)
			{
				%gotTarget = %potentialTarget;
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%potentialTarget));
			}
		}
	}
	if (%gotTarget > 0)
	{
		%objectpos = GameBase::getPosition(%gotTarget);
		BotTree::Getmetopos(%aiId,%objectpos, false);
		$BotThink::Definitive_Attackpoint[%aiId] = %gotTarget;
		$BotThink::Definitive_Attackpos[%aiId] = %objectpos;
		$BotThink::ForcedOfftrack[%aiId] = true;
		$BotThink::LastPoint[%aiId] = False;

		BotFuncs::AttackObject(%aiName, %gotTarget);
	}
	else
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no target to attack");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}


function BotBehaviour::FeelingSick(%aiName,%aiId,%aiTeam)
{
	if ($Spoonbot::DebugMode)
		dbecho (1,"STATUS BotThink::Think = IsHealthy returned False");

	// Lets see if we've got a repair kit. If so use it.

	%kitcount = Player::GetItemCount(%aiId,RepairKit);
	if(%kitcount > 0)
	{
		Player::useItem(%aiId,RepairKit); // Not sure about this one - Wicked69

		if ($Spoonbot::DebugMode)
			dbecho (1, "STATUS BotThink::Think = Using Repairkit");
	}
	else
	{
		// Lets find a medic!

		%Medic = BotFuncs::FindNearestTeamAI(%aiId, 0, 500, 0, "Medic");
		if (%Medic == 0) // Not Found
		{
			if ($Spoonbot::DebugMode)
				echo ("STATUS BotThink::Think = No Medic found, returning to base.");

			//Return to Base, no medic available - needs work to use tree points- Wicked69

//			AI::DirectiveWaypoint( %aiName, $BotThink::BotHome[%aiId], 2, 0 );

			BotTree::Getmetopos(%aiId,$BotThink::BotHome[%aiId], false);
			$BotThink::Definitive_Attackpoint[%aiId] = BotFuncs::GetFlagId(%aiTeam);
			$BotThink::Definitive_Attackpos[%aiId] = $BotThink::BotHome[%aiId];
			$BotThink::ForcedOfftrack[%aiId] = true;
			$BotThink::LastPoint[%aiId] = false;

			$Spoonbot::BotStatus[%aiId] = "Retreating";
		}
		else

		// Goto Medic and get Medic to come to me. Could be interesting to see them pass each other!

		{
			%MedicName = Client::getName(%Medic);
			if ($Spoonbot::DebugMode)
				echo ("STATUS BotThink::Think = Meeting medic " @ %MedicName);

			// Ask medic to come to me

			BotFuncs::AddAttacker(%Medic, %aiId, 30, 3);

			// Go to Medic

			BotFuncs::AddAttacker(%aiId, %Medic, 30, 3);
			AI::HuntTarget(%aiName, %Medic, 1);
			$Spoonbot::BotStatus[%aiId] = "Visit Medic";
		}
	}
	if ($Spoonbot::DebugMode)
		 echo ("STATUS BotThink::Think = End Medic stuff ");
}


function BotBehaviour::RespondToAttack(%aiName,%aiId,%aiTeam)
{
	if ($Spoonbot::DebugMode)
		echo ("STATUS BotThink::Think = Under Attack");

	$BotThink::ForcedOfftrack[%aiId] = True;
	%Attacker = BotFuncs::NearestAttacker(%aiId, 200, 1);

	// Attacker Found if ID > 0, Set It as Target

	if (%Attacker > 0)
	{
		$Spoonbot::BotStatus[%aiId] = "Under Attack";
		AI::HuntTarget(%aiName, %Attacker, 1);
	}
	else

	//Nearest attacker too far away... So delete him

	{
		$Spoonbot::BotStatus[%aiId] = "Lost Target";
		%Attacker = BotFuncs::NearestAttacker(%aiId, 99999, 1);
		BotFuncs::DelAttacker(%aiId,%Attacker);
	}

	if (BotFuncs::IsUnderAttack(%aiId) > 1) 

	// More than one attacker, lets drum up support

	{
		BotFuncs::TeamMessage(%aiTeam, %aiName @ ": Somebody help...");
		$Spoonbot::BotStatus[%aiId] = "Need Help";

		%animation = $PlayerAnim::OverHere;
		BotFuncs::Animation(%aiId, %animation);

		%TeamMateId = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, 0, "");

		if (%TeamMateId != 0)
		{
			if(BotFuncs::AddAttacker(%TeamMateId,%Attacker,50,3))
			{
				BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMateId) @ ": Coming");
				$Spoonbot::BotStatus[%TeamMateId] = "Helping";
				%animation = $PlayerAnim::Salute;
				BotFuncs::Animation(%TeamMateId, %animation);
			}
		}

		if (BotFuncs::IsUnderAttack(%aiId) > 2)

		// More than two attackers, lets drum up more support !

		{
			BotFuncs::TeamMessage(%aiTeam, %aiName @ ": I need more help ...");
			%animation = $PlayerAnim::OverHere;
			BotFuncs::Animation(%aiId, %animation);

			%TeamMate2Id = BotFuncs::FindNearestTeamAI(%aiId, 150, 300, %TeamMateId, "");

			if (%TeamMate2Id != 0)
			{
				if(BotFuncs::AddAttacker(%TeamMate2Id,%Attacker,50,3))
				{
					BotFuncs::TeamMessage(%aiTeam, Client::getName(%TeamMate2Id) @ ": I'm on my way ...");
					$Spoonbot::BotStatus[%TeamMate2Id] = "Helping";
					%animation = $PlayerAnim::Wave;
					BotFuncs::Animation(%TeamMateId, %animation);
				}

			}
		}
	}
}

function BotBehaviour::GetTheFlag(%aiName, %aiId, %aiTeam)   //by EMO1313. Makes %aiName to head for the flag and ignore all enemies.
{
	// Go for the enemy flag

	if ($Spoonbot::DebugMode)
		echo ("CALL BotFuncs::GetTheFlag("@ %aiName @");");

	if (%aiId==0)
		return;

	BotFuncs::checkObstacle(%aiId);
	BotFuncs::FlagGrabMove(%aiId, %aiTeam);

	if(%aiTeam > 0)
		%EnemyTeam = %aiTeam - 1;
	else
		%EnemyTeam = getNumTeams() - 1;

	%pos = ($teamFlag[%enemyTeam]).originalPosition;
	%xPos = getWord(%pos, 0);
	%yPos = getword(%pos, 1);
	%zPos = getWord(%pos, 2);
	%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;

	%flyaway = floor(getRandom() * 10); 
	if (%flyaway == 0)
	{
		if ($Spoonbot::BotEvadeUp[%aiId] != 1)
			AI::EvadeUp(%aiId);
	}

	//Before going for the flag, check to see if a team-mate has it
	//If so, escort him.

	%imtheone = 0;
	for(%cl = 2049; %cl <= 2138; %cl++)
	{
		%clteam = Client::getTeam(%cl);
		if(%clteam == %aiTeam)
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				if (Player::getMountedItem(%cl, $FlagSlot) != -1)
					%imtheone = %cl;
			}
		}
	}

	if (%imtheone != 0)
	{
		BotFuncs::FollowPlayer(%aiName, %aiId, %imtheone);
		$Spoonbot::BotStatus[%aiId] = "Escorting Flagrunner";
	}
	else
	{

		BotTree::Getmetopos(%aiId,%flagPos, false);
		$BotThink::Definitive_Attackpoint[%aiId] = BotFuncs::GetFlagId(%EnemyTeam);
		$BotThink::Definitive_Attackpos[%aiId] = %flagPos;
		$BotThink::ForcedOfftrack[%aiId] = true;
		$BotThink::LastPoint[%aiId] = false;

		$Spoonbot::BotStatus[%aiId] = "Getting Flag";
		if ($Spoonbot::DebugMode)
			echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
	}
}

function BotBehaviour::ReturnTheFlag(%aiName, %aiId, %aiTeam)   //by Werewolf. Makes %aiName to head for the OWN flag and ignore all enemies.
{
	if ($Spoonbot::DebugMode)
		echo ("CALL BotFuncs::ReturnTheFlag("@ %aiName @");");

	if (%aiId==0)
		return;

	BotFuncs::checkObstacle(%aiId);

	//If bot hasn't returned flag within specified time period
	//kill it to let a player get a chance at the flag.

	$increaseflag[%aiId] = $increaseflag[%aiId] + 1;
	if ($increaseflag[%aiId] >= 80)
	{
		$increaseflag[%aiId] = 0;
		Player::kill(%aiId);
	}

	BotFuncs::FlagReturnMove(%aiId, %aiTeam);

	%pos = ($teamFlag[%aiTeam]).originalPosition;
	%xPos = getWord(%pos, 0);
	%yPos = getword(%pos, 1);
	%zPos = getWord(%pos, 2);
	%flagPos = %xPos @ "  " @ %yPos @ "  " @ %zPos;

	BotTree::Getmetopos(%aiId,%flagPos, false);
	$BotThink::Definitive_Attackpoint[%aiId] = BotFuncs::GetFlagId(%aiTeam);
	$BotThink::Definitive_Attackpos[%aiId] = %flagPos;
	$BotThink::ForcedOfftrack[%aiId] = true;
	$BotThink::LastPoint[%aiId] = false;

	$Spoonbot::BotStatus[%aiId] = "Returning Flag";
	if ($Spoonbot::DebugMode)
		echo(%aiName @ " tries to capture the enemy's flag"); //on his objective.
	return;
}


function BotBehaviour::NormalBotBehaviour(%aiName, %aiId, %aiTeam)
{
	if ($Spoonbot::DebugMode)
		echo ("STATUS BotThink::Think = Roaming code running...");

	BotFuncs::checkObstacle(%aiId);

	if ($Spoonbot::Target[%aiId]!=0)
	{
		if (!BotFuncs::CheckForLOS(%aiId, $Spoonbot::Target)) 
		{
			AI::DirectiveFollow(%aiId, $Spoonbot::Target, 255);
			schedule("AI::DirectiveRemove(" @ %aiId @ ", 255);", $Spoonbot::ThinkingInterval);
		}
	}

	if ($Spoonbot::Target[%aiId]!=0)
		if (BotFuncs::CheckAlive($Spoonbot::Target))
			return;

	%attacking = False;
	if ($Spoonbot::HuntFlagrunner == 0)      //Check if in Normal mode or if bots are chasing a flagrunner
	{
		%mode = floor(getRandom() * 3);      //There are two modes of operation: 1) Attack random enemy and 2) attack/defend objects
		if ($Spoonbot::DebugMode)
			 echo ("STATUS BotThink::Think MODE = " @ %mode);
		if (%mode == 0)
		{
			%spawnIdx = floor(getRandom() * ($Spoonbot::NumBots - 0.1));  //Add a random variation to the target selection

		//	%startCl = Client::getFirst() + %spawnIdx;  //This has caused the bots to not attack unless a player is present.
			%startCl = 2048 + %spawnIdx;                  //This is by EMO1313 who told me about it. Thanks EMO1313 !!
			%endCl = %startCl + 90;
   
			for(%cl = %startCl; ((%cl < %endCl) && (%attacking == False)); %cl++)
			{
		  		%targetTeam = Client::getTeam(%cl);
				if (%targetTeam != %aiTeam)           //Is this an enemy?
				{
					%player = Client::getOwnedObject(%cl);
					if (!Player::isDead(%player))
					{
						%enemyName = Client::getName(%cl);
						if (%enemyName != "")
						{
							BotFuncs::AddAttacker(%cl,%aiName,10,4);
							BotFuncs::AddAttacker(%aiName,%cl,10,4);
							$Spoonbot::Target[%aiId]=%cl;
							$Spoonbot::BotStatus[%aiId] = "Attacking Enemy";
							if ($Spoonbot::DebugMode)
								echo ("STATUS BotThink::Think = " @ %aiName @ " has decided to attack " @ %enemyName);
						    	%attacking = True;
						}
					}
				}
			}
		}
		else if (%mode >= 1) //mode 1 and 2 mean attack/defend base equipment
		{
			if ($Spoonbot::DebugMode)
				dbecho(1,%ainame @ " attack due to roaming atackdefend");

			BotBehaviour::NormalAttackDefend(%aiId, %aiName, %aiTeam);

		}  //End of mode 1 and 2
	}

	//end of roaming part, now comes the flagrunner-chasing part.

	else
	{
		%cl = $Spoonbot::HuntFlagrunner;
		%targetTeam = Client::getTeam(%cl);
		if (%targetTeam != %aiTeam)           //Is this an enemy?
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player))
			{
				%enemyName = Client::getName(%cl);
				BotFuncs::AddAttacker(%cl,%aiName,10,4);
				BotFuncs::AddAttacker(%aiName,%cl,10,4);
				$Spoonbot::Target[%aiId]=%cl;
				if ($Spoonbot::DebugMode)
					echo (%aiName @ " has decided to attack enemy flagrunner" @ %enemyName);
				$Spoonbot::BotStatus[%aiId] = "Attacking Flagrunner";
			}
		}
		else	//else this is a friendly, so let's escort him to safety.
	        {
			%player = Client::getOwnedObject(%cl);
		 	if (!Player::isDead(%player))
			{
				%enemyName = Client::getName(%cl);
				if (%enemyName != "")
				{
					BotFuncs::AddAttacker(%cl,%aiName,10,4);
					BotFuncs::AddAttacker(%aiName,%cl,10,4);   //The procedure is the same, except the friendly bot won't fire on the flagrunner
					$Spoonbot::Target[%aiId]=%cl;
					if ($Spoonbot::DebugMode)
						echo(%aiName @ " is escorting the friendly flagrunner " @ %enemyName);
					$Spoonbot::BotStatus[%aiId] = "Escorting Flagrunner";
				}
			}
	        }
	}

// End of Original Roam Code

}


function BotBehaviour::NormalAttackDefend(%aiId, %aiName, %aiTeam)
{
	if (!BotFuncs::CheckAlive(%aiId))
		return;

	if(%aiTeam > 0)
		%EnemyTeam = %aiTeam - 1;
	else
		%EnemyTeam = getNumTeams() - 1;

// First decide if attacking enemy or defending or if we've got an existing destination

	if ((1 == 1) ||		// Fix to always attack at present!
	($BotThink::Definitive_Attackpoint[%aiId] != ""))
	{
		if($BotThink::Definitive_Attackpoint[%aiId] == "")
		{
			//dbecho(1,"no definitive");

			%Target = -1;
			%LastPoint = False;

			%loopcount = 0;

			while((%Target == -1) && (%loopcount < 10))
			{
				%loopcount = %loopcount + 1;

				//dbecho(1,"Target Loop");

				%AttackDefend = floor(getRandom() * 10); // heavily weighted towards attacking.

				if (%AttackDefend > 1) // Selects team eg if enemy team attack else defend.
					%AttackDefend = %enemyTeam;

				%mod = floor(getRandom() * 8); // 7 Groups + 1 for Extra Flag Selection

				%flagDist = BotFuncs::GetDistanceToFlag(%aiId, BotFuncs::GetFlagId(%AttackDefend));  //By Werewolf, makes the bot go for the flag if it's near it.

				if (%flagDist < 5)
					%mod = 7;

				//dbecho(1,"%mod = " @ %mod);

				if (%mod == 1) // Vehicle type Targets
				{
					%Target = BotFuncs::GetVehId(%AttackDefend);
					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));
					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
					{
						%Target = BotFuncs::GetFlagId(%AttackDefend); //If so, go for the flag.
						%LastPoint = True;
						%TargetType = "Flags";
					}

					%TargetType = "Vehicle Pads";
				}
				else if (%mod == 2) // Sensor Type Targets
				{
					%Target = BotFuncs::GetSensorId(%AttackDefend);

					//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
					if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
						%Target = -1;

					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
						%Target = -1;
					%TargetType = "Sensors";
				}
				else if (%mod == 3) // Gun Type Targets
				{
					%Target = BotFuncs::GetGunId(%AttackDefend);

					//dbecho(1,%Target @ " Powered = " @ GameBase::isPowered(%Target));
						
					if(GameBase::isPowered(%Target))			  // Dont attack if it has shields!
						%Target = -1;

					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
						%Target = -1;

					%TargetType = "Guns";
				}
				else if (%mod == 4) // Gen Type Targets
				{
					%Target = BotFuncs::GetGenId(%AttackDefend);

					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
						%Target = -1;
					
					%TargetType = "Generators";
				}
				else if (%mod == 5) // Com Type Targets
				{
					%Target = BotFuncs::GetComId(%AttackDefend);

					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
						%Target = -1;
						
					%TargetType = "Command Stations";
				}
				else if (%mod == 6) // Inv Type Targets
				{
					%Target = BotFuncs::GetInvId(%AttackDefend);

					//dbecho(1,%Target @ " Damage level = " @ GameBase::getDamageLevel(%Target));

					if (GameBase::getDamageLevel(%Target) == 1.0) //Is it already destroyed?
						%Target = -1;
						
					%TargetType = "Inventory Points";
				}
				else // Flags etc.//MIGHT WANT TO BLOCK THIS OUT
				{
					%Target = BotFuncs::GetFlagId(%AttackDefend);
					%LastPoint = True;
						
					%TargetType = "Flags";
				}
		
				%Distance = Vector::getDistance($BotTree::Treepoint_Location[BotTree::FindNearestTreebyId(%Target)],GameBase::getPosition(%Target));

			//	if ((%Distance > 10) || (%Distance == 0)) // Too far away, needs tuning. - Wicked69
			//	{
			//		%Target = -1;
			//		%TargetType = "Error, Object Deselected";
			//	}

				if(%Target == "")
					%Target = -1;
			}

			//dbecho(1,%aiid @ " Target = " @ %Target );				

			if(%Target != -1)
			{
				%AttackPos = GameBase::getPosition(%Target);
				%AttackPoint = %Target;

				if(%AttackDefend == %enemyteam)
				{
					%Style = "Attacking Enemy";
					$Spoonbot::BotStatus[%aiId] = "Attacking Enemy " @ %TargetType; // This is for the ButHud
				}
				else
				{
					%Style = "Defending team";
					$Spoonbot::BotStatus[%aiId] = "Defending Team " @ %TargetType; // This is for the ButHud
				}
				
				BotFuncs::TeamMessage(%aiteam,%AiName @ ": " @ %Style @ " " @ %TargetType );

				//dbecho(1,%AiName @ ": " @ %Style @ " " @ %TargetType @ ", id = " @ %Target );
			}
		}
		else
		{
			%AttackPoint = $BotThink::Definitive_Attackpoint[%aiId];
			%AttackPos = $BotThink::Definitive_Attackpos[%aiId];
			%LastPoint = $BotThink::LastPoint[%aiId];
		}

		// Determine Nearest TreePoint to attack Point.

		if(%Attackpoint != -1)
		{
			BotTree::GetMeToPos(%aiId, %AttackPos, %LastPoint);//BLOCKED THIS AND CHANGED 

			$BotThink::Definitive_Attackpoint[%aiId] = %AttackPoint;
			$BotThink::Definitive_Attackpos[%aiId] = %AttackPos;
			$BotThink::ForcedOfftrack[%aiId] = true;//THIS TO TRUE, USE TO BE FALSE.
			$BotThink::LastPoint[%aiId] = %LastPoint;
		}
	}
}

function BotBehaviour::AttackFurthestEnemy(%aiName, %aiId, %aiTeam)
{
	if ($Stormbots::BotTarget[%aiId] > 0)
	{
		%player = Client::getOwnedObject($Stormbots::BotTarget[%aiId]);
		if (Player::isDead(%player) || %player <= 0 || Client::getTeam(%player) == %aiTeam)
			$Stormbots::BotTarget[%aiId] = -1;
	}

	if ($Stormbots::BotTarget[%aiId] <= 0)
	{
		%range = 0;
		for(%cl = 2049; %cl <= 2138; %cl++)
		{
			%clteam = Client::getTeam(%cl);

			if(%clteam != %aiTeam)	//Client is not same team as bot
			{
				%player = Client::getOwnedObject(%cl);
				if (!Player::isDead(%player) && %player > 0)
				{
					if (Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) > %range)
					{
						$Stormbots::BotTarget[%aiId] = %cl;
						%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl));
					}
				}
			}
		}
	}

	if ($Stormbots::BotTarget[%aiId] > 0)
	{
		BotFuncs::FollowPlayer(%aiName, %aiId, $Stormbots::BotTarget[%aiId]);
		$Spoonbot::BotStatus[%aiId] = "Attacking " @ Client::getName($Stormbots::BotTarget[%aiId]);
	}
	else
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no enemy to attack");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}

function BotBehaviour::LookForGoodTarget(%aiName, %aiId, %aiTeam)
{
	%foundone = False;
	%foundLOS = False;
	for(%cl = 2049; %cl <= 2138; %cl++)
	{
		%clteam = Client::getTeam(%cl);
		%player = Client::getOwnedObject(%cl);
		if(%clteam != %aiTeam && !Player::isDead(%player) && %player > 0)
		{
			if (!%foundone)
			{
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) + 1;
				%foundone = True;
			}

			if (BotFuncs::CheckForItemLOS(%aiId, %cl) && Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) < 1000)
				%foundLOS = True;

			if (Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) < %range)
			{
				%gotTarget = %cl;
				%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl));
			}
		}
	}
	if (%foundLOS)
	{
		$Spoonbot::BotStatus[%aiId] = "Sighted Enemy";
	}
	else if (%gotTarget > 0)
	{
		BotFuncs::FollowPlayer(%aiName, %aiId, %gotTarget);
		$Spoonbot::BotStatus[%aiId] = "Attacking " @ Client::getName(%gotTarget);
	}
	else
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no enemy to attack");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}

function BotBehaviour::AttackNearestEnemy(%aiName, %aiId, %aiTeam)
{
	%foundone = False;
	for(%cl = 2049; %cl <= 2138; %cl++)
	{
		%clteam = Client::getTeam(%cl);
		if(%clteam != %aiTeam)	//Client is not same team as bot
		{
			%player = Client::getOwnedObject(%cl);
			if (!Player::isDead(%player) && %player > 0)
			{
				if (!%foundone)
				{
					%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) + 1;
					%foundone = True;
				}
				if (Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl)) < %range)
				{
					%gotTarget = %cl;
					%range = Vector::getDistance(GameBase::getPosition(%aiId), GameBase::getPosition(%cl));
				}
			}
		}
	}

	if (%gotTarget > 0)
	{
		BotFuncs::FollowPlayer(%aiName, %aiId, %gotTarget);
		$Spoonbot::BotStatus[%aiId] = "Attacking " @ Client::getName(%gotTarget);
	}
	else
	{
		if ($Spoonbot::DebugMode)
			dbecho(1,%ainame @ " no enemy to attack");
		$Spoonbot::BotStatus[%aiId] = "Idle";
	}
}

