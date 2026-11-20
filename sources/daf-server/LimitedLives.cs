function LimitedLives::StartGame()
{
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
		LimitedLives::AddToGame(%i, $Game::PlayerLives);
	}
	$LimitedLives::GameStarted = 1;
	echo($LimitedLives::ClientsInGame@" clients in game");
	if($Game::LimitedLives)
		LimitedLives::CheckEndOfGame();

}


function LimitedLives::playerSpawned(%pl, %clientId, %armor)
{
	if(%clientId.ingame)
		return 0;
	
	player::setitemcount(%clientId, "Knife", 1);
	player::setitemcount(%clientId, "RepairKit", 1);
	player::setitemcount(%clientId, "InfantryArmor", 1);
	player::useItem(%clientId, "Knife");
	
	return 1;
} 

function Client::leaveGame(%clientId)
{
	if(%clientId.ingame == 1)
		LimitedLives::RemoveFromGame(%clientId);
}

function GiveLives(%clientId, %lives)
{
	if(%lives == 0)
		return;
	if(%lives == "" || !%lives)
		%lives = 1;


	if((%lives > 0) && (%clientId.ingame == 0 || %clientId.ingame == "" || !%clientId.ingame) && (%clientId.lives + %lives > 0))
	{

	LimitedLives::AddToGame(%clientId, %lives);
	if($LimitedLives::GameStarted)
	{
		if(client::getownedobject(%clientId) == -1)
			Game::playerSpawn(%clientId, 1);
		else
		{
			%pl = client::getownedobject(%clientId);
			Game::playerSpawn(%clientId, 1);
			player::kill(%pl);
		}
	}
	schedule("checkquadrant("@%clientId@");", 0.5);
	}
	else if((%lives < 0) && (%clientId.ingame == 1 || %clientId.ingame == true) && (%clientId.lives + %lives <= 0))
	{
	%clientId.lives += %lives;
	client::sendmessage(%clientId, 3, "You have lost "@lifeformat(-1*%lives)@" bringing you to "@lifeformat(%clientId.lives)@" in total.");
	LimitedLives::RemoveFromGame(%clientId);
	player::kill(%clientId);
	}
        else
	{
	
	%clientId.lives += %lives;
	}
	if(%lives < 0)
		client::sendmessage(%clientId, 3, "You have lost "@lifeformat(-1*%lives)@" bringing you to "@lifeformat(%clientId.lives)@" in total.");
	else
		client::sendmessage(%clientId, 3, "You have been given "@lifeformat(%lives)@" bringing you to "@lifeformat(%clientId.lives)@" in total.");
	Game::refreshClientScore(%clientId);
}

function LimitedLives::AddToGame(%clientId, %lives)
{
	gamebase::setteam(%clientId, 0);
	$LimitedLives::ClientsInGame++;
	echo(client::getname(%clientId)@" ("@%clientID@") added to game with "@LifeFormat(%lives)@".");
	%clientID.ingame = true;
	%clientID.lives = %lives;
	%clientID.timestartedingame = getsimtime();
	Game::refreshClientScore(%clientId);
	if(client::getownedobject(%clientId) == -1)
	{
		Game::playerSpawn(%clientId, "false");
	}

}
function LimitedLives::RemoveFromGame(%clientId)
{
	echo("Removing "@client::getname(%clientId)@" from game...");
	%clientId.ingame = 0;
	%clientId.lives = 0;
	client::sendmessage(%clientId, 1, "You are out of the game...");
	LimitedLives::CalcTimeinGame(%clientId);
	$AAI::GameStats[%clientID, "timeingamelast"] = $AAI::GameStats[%clientID, "timeingamelast"] + $AAI::GameStats[%clientID, "timeingame"];
	$LimitedLives::ClientsInGame--;
	LimitedLives::CheckEndOfGame();
	gamebase::setteam(%clientId, -1);
	Game::refreshClientScore(%clientId);
}

function LimitedLives::CalcTimeinGame(%clientId)
{
$AAI::GameStats[%clientID, "timeingame"] = $AAI::GameStats[%clientID, "timeingamelast"] + (getsimtime() - %clientID.timestartedingame);
}

function LimitedLives::CheckEndOfGame()
{
	if($LimitedLives::ClientsInGame <= 0 && $LimitedLives::GameStarted)
	{
		//echo("GAME OVER?");
		$TeamScore[1] = $teamScoreLimit;
	}
}

function lifeformat(%lives)
{

	if(%lives == 1)
		return "1 life";
	else
		return %lives@" lives";

}
function LimitedLives::OnKilled(%playerId, %killerId, %damagetype)
{
	if(Player::isAIControlled(%playerid) || %playerID.inGame != 1)
	{
	//echo("CAUGHT");
		return;
	}
	%playerId.lives--;
		if(%playerId.lives <= 0)
			LimitedLives::RemoveFromGame(%playerId);
		else
			Client::SendMessage(%playerId, 1, "You have "@LifeFormat(%playerId.lives)@" remaining.");


}


function LifeGame::pickInGameSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");//InGame");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);

}

function LifeGame::pickOutofGameSpawn(%team)
{
  // %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Random");//OutOfGame");
  // %count = Group::objectCount(%group);
  // if(!%count)
  //    return -1;

  // %spawnIdx = $lastTeamSpawn[%team] + 1;
  // if(%spawnIdx >= %count)
  //    %spawnIdx = 0;
  // $lastTeamSpawn[%team] = %spawnIdx;
	return "Random";
//   return Group::getObject(%group, %spawnIdx);

}