// Bot Think Function by Wicked69 (Paul@Lathope.demon.co.uk) Started 6/11/1999.

//Main Bot think function calls itself recursively each second

function BotThink::Think(%aiId,%requeue)
{
	if ($Spoonbot::DebugMode)
		echo ("CALL BotThink::Think("@ %aiId @ ", " @ %requeue @ ");");

	if(BotThink::IsBotDead(%aiId))
		return;

	if ($Spoonbot::RidingWith[%aiId] != 0)	//If bot rides in a vehicle, skip all of the bot's thinking.
	{
		if (%requeue == True)
			schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}

	// Generic variables

	%aiName = Client::getName(%aiId);
	%aiTeam = Client::getTeam(%aiId);
	%AiPos = GameBase::getPosition(%aiId);

	if (BotTypes::IsCMD(%aiName) == 1)
		return;

	// Tidy Attacker List

	BotFuncs::TidyAttackerList(%aiId);

	if ($Spoonbot::DebugMode)
		echo("STATUS BotThink::Think = Bot alive check passed for ID " @ %aiId @ " Name " @ %aiName);

	BotThink::CheckBotStuck(%aiId,%AiPos);

	// Start if main AI action 'IF' sequence

	//if we have a flag do something with it

	if (Player::getMountedItem(%aiId, $FlagSlot) != -1)   
		BotBehaviour::ReturnTheFlag(%aiName, %aiId, %aiTeam);

	// Check to see if AI is healthy. If not get help.

	else if (BotFuncs::IsHealthy(%aiId) == False) // Not Healthy. Return to Base (Or Find a Medic?)
		BotBehaviour::FeelingSick(%aiName,%aiId,%aiTeam);

	// Else Check to see if bot is under attack

	else if(BotFuncs::IsUnderAttack(%aiId) > 0) // Under Attack. Respond (Or run!)
		BotBehaviour::RespondToAttack(%aiName,%aiId,%aiTeam);

	//Class-related behaviour

	else if(BotTypes::IsMedic(%aiName) == 1)
		BotBehaviour::RepairSomething(%aiName, %aiId, %aiTeam);

	else if(BotTypes::IsGuard(%aiName) == 1)
		BotBehaviour::GuardTheFlag(%aiName, %aiId, %aiTeam);

	else if(BotTypes::IsMiner(%aiName) == 1)
		BotBehaviour::AttackFurthestEnemy(%aiName, %aiId, %aiTeam);

	else if(BotTypes::IsMortar(%aiName) == 1)
	{
		%painter = BotFuncs::LookForPainter(%aiTeam);
		if(%painter > 0)
		{
			BotFuncs::FollowPlayer(%aiName, %aiId, %painter);
			$Spoonbot::BotStatus[%aiId] = "Escorting " @ Client::getName(%painter);
		}
		else
			BotBehaviour::AttackNearestEnemy(%aiName, %aiId, %aiTeam);
	}

	else if(BotTypes::IsPainter(%aiName) == 1)
		BotBehaviour::PaintSomething(%aiName, %aiId, %aiTeam);

	else if(BotTypes::IsDemo(%aiName) == 1)
		BotBehaviour::DestroySomething(%aiName, %aiId, %aiTeam);

	else if(BotTypes::IsSniper(%aiName) == 1)
	{
		AI::SetVar(%aiName, triggerPct, 0.005 );
		BotBehaviour::LookForGoodTarget(%aiName, %aiId, %aiTeam);
	}

	else if(BotTypes::IsRunner(%aiName) == 1)
		BotBehaviour::GetTheFlag(%aiName, %aiId, %aiTeam);

	else
		BotBehaviour::NormalBotBehaviour(%aiName, %aiId, %aiTeam);

	// Tidy Attacker List Again !

	BotFuncs::TidyAttackerList(%aiId);

	// Requeue Think

	if ($Spoonbot::DebugMode)
		echo ("STATUS BotThink::Think = Requeue: " @ %aiId @ ", True");

	if (%requeue == True)
		schedule("BotThink::Think(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
}


function BotThink::getWordCount(%string)
{
	for(%num = 0; getWord(%string, %num) != -1; %num++)
	{
	} // it's all done above!
	return %num;
}

function BotThink::IsBotDead(%aiId)
{
	//Sanity check. Check if Bot is alive. If not then clear Vars and abort functiom
	//----------------------------------------
	//Werewolf

	if ($Spoonbot::BotStatus[%aiId] == "Dead")
		return 1;

	%player = Client::getOwnedObject(%aiId);

	if (Player::isDead(%player))
	{
		BotFuncs::ClearVars(%aiId);
		return 1;
	}

	%aiName = Client::getName(%aiId);

	//The following needs to be done in case
	//IsDead doesn't work in this version

	%newId = BotFuncs::GetId(%aiName);
	if (%newId==0)
		return 1;

	if (%newId != %aiId)
	{
		BotFuncs::ClearVars(%aiId);
		return 1;
	}
	return 0;
}

function BotThink::CheckBotStuck(%aiId,%AiPos)
{
	// Bot "stuck" check

	// Now we're checking of the AI is stuck somewhere by comparing the actual position with the previous one.
	// Then we either issue a RandomEvade to try to solve this problem, or use the nearest treepoint and go from there.

	%xPos = getWord(%AiPos, 0);
	%yPos = getWord(%AiPos, 1);
	%zPos = getWord(%AiPos, 2);
	%LastxPos = getWord($Spoonbot::lastPosition[%aiId], 0);
	%LastyPos = getWord($Spoonbot::lastPosition[%aiId], 1);
	%LastzPos = getWord($Spoonbot::lastPosition[%aiId], 2);

	if ($Spoonbot::DebugMode)
		echo("PREVIOUS POSITION of ID " @ %aiId @ " Name " @ %aiName @ " is " @ $Spoonbot::lastPosition[%aiId]);
	if ($Spoonbot::DebugMode)
		echo("ACTUAL POSITION of ID " @ %aiId @ " Name " @ %aiName @ " is " @ %AiPos);

	%stuck = False;
	%MinPositionDelta = 1;
	%MaxGracePeriod = 1;

	if (BotFuncs::Delta(%xPos, %LastxPos) < %MinPositionDelta)
		if (BotFuncs::Delta(%yPos, %LastyPos) < %MinPositionDelta)
			if (BotFuncs::Delta(%zPos, %LastzPos) < %MinPositionDelta)  //If the bot hasn't moved recently, it may be stuck.
				%stuck = True;

	if (%stuck)
	{
		$Spoonbot::StuckGracePeriod[%aiId]++;
		if ($Spoonbot::StuckGracePeriod[%aiId] >= %MaxGracePeriod)
		{
			if($Spoonbot::MedicBusy[%aiId] == 0)
			{
				if ($Spoonbot::DebugMode)
					echo("STUCK ID " @ %aiId @ " Name " @ %aiName @ " at " @ %AiPos);
				$BotThink::ForcedOfftrack[%aiId] = True;
				BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4); //Recently enabled this one, dunno if it helps
				AI::RandomEvade(%aiId);
				$Spoonbot::StuckGracePeriod[%aiId] = 0;
			}
		}
	}
	$Spoonbot::lastPosition[%aiId] = %AiPos;
}

function BotThink::CommandThink(%aiId,%requeue)
{
	if ($Spoonbot::DebugMode)
		echo ("CALL BotThink::CommandThink("@ %aiId @ ", " @ %requeue @ ");");

	if(BotThink::IsBotDead(%aiId))
		return;

	if ($Spoonbot::RidingWith[%aiId] != 0)	//If bot rides in a vehicle, skip all of the bot's thinking.
	{
		if (%requeue == True)
			schedule("BotThink::CommandThink(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
		return;
	}

	// Generic variables

	%aiName = Client::getName(%aiId);
	%aiTeam = Client::getTeam(%aiId);
	%AiPos = GameBase::getPosition(%aiId);
	
	if(BotTypes::IsDemo(%aiName))
		BotFuncs::CheckForSomethingToDestroy(%aiId, %aiName, %aiTeam);
	else if(BotTypes::IsMedic(%aiName))
		BotFuncs::CheckForSomethingToRepair(%aiId, %aiName, %aiTeam);
	else if(BotTypes::IsRunner(%aiName))
		BotFuncs::CheckForNearbyFlag(%aiId, %aiName, %aiTeam);
	else if(BotTypes::IsPainter(%aiName))
		BotFuncs::CheckForSomethingToPaint(%aiId, %aiName, %aiTeam);
	else if(BotTypes::IsGuard(%aiName))
		BotFuncs::CheckIfEnemyHasFlag(%aiId, %aiName, %aiTeam);
	else
		$Spoonbot::BotStatus[%aiId] = "Awaiting orders";
	
	// Requeue Think

	if ($Spoonbot::DebugMode)
		echo ("STATUS BotThink::CommandThink = Requeue: " @ %aiId @ ", True");

	if (%requeue == True)
		schedule("BotThink::CommandThink(" @ %aiId @ ", True);", $Spoonbot::ThinkingInterval);
}

