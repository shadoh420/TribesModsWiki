$Server::AutoAssignTeams = 1;
$BorderWarningBuffer = 10;
function StartBorderChecking()
{
	$Game::HasBorders = true;
	%clientlist = "";
	%clients = 0;
	$LimitedLives::ClientsInGame = 0;

	AAI::ResetStats();
	for(%i = client::getfirst(); %i != -1; %i = Client::getnext(%i))
	{
	if($Game::LimitedLives)
		LimitedLives::AddToGame(%i, $Game::PlayerLives);
	%i.AAILastPos = -1;
	%i.CurQuad = 0;
	CheckQuadrant(%i);
	}
	$LimitedLives::GameStarted = 1;
	echo($LimitedLives::ClientsInGame@" clients in game");
	%pass = BorderGame::MakePassword();
	$Server::password = %pass;
	
	if($Game::LimitedLives)
		LimitedLives::CheckEndOfGame();


}

function BorderGame::MakePassword()
{
	%len = 8 + getrandom() * 5;
	%str = "";
	for(%x = 0; %x < %len; %x++)
	{
	%num = floor(getrandom() * 38);
	if(%num > 27)
		%num = %num - 28;
	else
		%num = $letter[%num];
	
	%str = %str @ %num;
	}
	echo("Password is: \""@%str@"\"");
	return %str;



}


function CheckQuadrant(%clientId)
{
	
	if(!%clientId.ingame||%clientId.ingame== false)
	{
		%clientId.AAILastPos = -1;
		//PlayerPermDead(%clientId);
		return;
	}
	
	%player = client::getownedobject(%clientID);
	if(%player == -1 || Player::isDead(%player))
	{
	%clientId.AAILastPos = -1;
	schedule("CheckQuadrant("@%clientId@");", 1.0);
	return;
	}
	if(%clientId.AAILastPos == -1)
	{
		%clientId.AAILastPos = gamebase::getposition(%clientId);
	}
	$AAI::GameStats[%cl, "distance"] = vector::getdistance(%clientId.AAILastPos, gamebase::getposition(%clientId));
	%clientId.AAILastPos = gamebase::getposition(%clientId);
	%Quad = %clientId.CurQuad;
	%pos = getword(gamebase::getposition(%clientId), 0)@" "@getword(gamebase::getposition(%clientId), 1)@" 0";

	//Bottom Check
	%botdot = vector::dot(vector::normalize(vector::sub($AAIBorderData::LeftPos[%Quad], %pos)), $AAIBorderData::CrossDirBorderDir[%Quad]);
	if(%botdot<0)
		{
		%clientId.CurQuad = %clientId.CurQuad-1;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		if(%clientId.CurQuad < 0)
			EndOutOfArea(%clientId, 0 ,-1);
		else
			CheckQuadrant(%clientId);
	
		return;
		}
	//Top Check
	%topdot = vector::dot(vector::normalize(vector::sub($AAIBorderData::LeftPos[%Quad+1], %pos)), $AAIBorderData::CrossDirBorderDir[%Quad+1]);
	if(%topdot>0)
		{
		%clientId.CurQuad = %clientId.CurQuad+1;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		if(%clientId.CurQuad >= $AAIBorderData::BorderMax)
			EndOutOfArea(%clientId, $AAIBorderData::BorderMax, 1);
		else
			CheckQuadrant(%clientId);
	
		return;
		}

	//Left Check
	%leftdot = vector::dot(vector::normalize(vector::sub(%pos, $AAIBorderData::LeftPos[%Quad])), $AAIBorderData::LeftDir[%Quad]);
	
	//Right Check
	%rightdot = vector::dot(vector::normalize(vector::sub($AAIBorderData::RightPos[%Quad], %pos)), $AAIBorderData::RightDir[%Quad]);
	%warned =0;
	if( (%leftdot * vector::getdistance(%pos, $AAIBorderData::LeftPos[%Quad])) < $BorderWarningBuffer || (%rightdot * vector::getdistance(%pos, $AAIBorderData::RightPos[%Quad])) < $BorderWarningBuffer)
	{	
		if(BorderGame::SpecialCases(%clientId))
		{
		%warned = 1;
		BorderGame::NearEdge(%clientId);
		}
		
	}

	if(%clientId.CurQuad == 0)
	{
	if((%botdot * vector::getdistance(%pos, $AAIBorderData::LeftPos[%Quad]) < $BorderWarningBuffer))
		{
		%warned = 1;
		BorderGame::NearEdge(%clientId);
		}
	}

	if(%clientId.CurQuad == $AAIBorderData::BorderMax-1)
	{
	if((-1*%topdot * vector::getdistance(%pos, $AAIBorderData::LeftPos[%Quad+1]) < $BorderWarningBuffer))
		{
		%warned = 1;
		BorderGame::NearEdge(%clientId);
		}
	}
	
	//echo(%leftdot@" "@%rightdot);
	if(%leftdot<0||%rightdot<0)
	{
		OutOfBoundsChecker(%clientID);
	}
	else
		%clientID.outofboundstimes = 0;
	
	if(%warned == 0 && %clientID.nearedge)
		%clientID.nearedge = 0;

	schedule("CheckQuadrant("@%clientId@");", 1.0);
}

$BorderGame::NBCount=0;
$BorderGame::NBMessage[$BorderGame::NBCount] = "Commander: HEY! You're wandering a bit too far out soldier.";
$BorderGame::NBMessage[$BorderGame::NBCount++] = "Commander: Stay away from those hills... Nothing but trouble in them.";
$BorderGame::NBMessage[$BorderGame::NBCount++] = "Commander: Keep your eyes on the objective here!";
$BorderGame::NBMessage[$BorderGame::NBCount++] = "Commander: HEY! You don't want to stick your head out for a sniper, do you?";
$BorderGame::NBCount++;

function remoteps(%clientid, %t, %n, %s)
{
messageall(0, "~w"@%t@"ale"@%n@".w"@%s@".wav");

}

function BorderGame::SpecialCases(%clientId)
{
	%quad = %clientId.CurQuad;
	if(%quad == 5 || %quad == 6 || %quad == 7)
	{
		%t=gamebase::getmuzzletransform(%clientID);
		%w=getword(%t, 3)@" "@getword(%t, 4)@" "@getword(%t, 5);
		%rot = vector::getrotation(%w);
		if((gamebase::getlosinfo(client::getownedobject(%clientId), 20, ($pi)-(getword(%rot, 0))@" 0 0")))
		{
		if(object::getname($LOS::OBJECT) == "newdam1")
			return false;
		}
	

	}
	return true;

}

function BorderGame::NearEdge(%clientId)
{
	if(%clientId.nearedge)
		return;

	%clientId.nearEdge = 1;
	%rand = floor(getRandom()*$BorderGame::NBCount);
	
	Client::sendMessage(%clientId, 3, $BorderGame::NBMessage[%rand]@"~wmale5.wwshoot1.wav");
	

}
function QuickQuadCheck(%clientID)
{
	%Quad = %clientId.CurQuad;
	%pos = getword(gamebase::getposition(%clientId), 0)@" "@getword(gamebase::getposition(%clientId), 1)@" 0";
	%pl = Client::getOwnedObject(%clientID);
	if(%pl.intrigger)
	{
		GroupTrigger::OnEnter(%pl.intrigger, %pl);

	}
	//Bottom Check
	%botdot = vector::dot(vector::normalize(vector::sub($AAIBorderData::LeftPos[%Quad], %pos)), $AAIBorderData::CrossDirBorderDir[%Quad]);
	if(%botdot<0)
		{
		%clientId.CurQuad = %clientId.CurQuad-1;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		QuickQuadCheck(%clientID);
	
		return;
		}
	//Top Check
	%topdot = vector::dot(vector::normalize(vector::sub($AAIBorderData::LeftPos[%Quad+1], %pos)), $AAIBorderData::CrossDirBorderDir[%Quad+1]);
	if(%topdot>0)
		{
		%clientId.CurQuad = %clientId.CurQuad+1;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		QuickQuadCheck(%clientID);
	
		return;
		}


}
$BorderGame::OOBCount=0;
$BorderGame::OOBMessage[$BorderGame::OOBCount] = "Commander: You're going to get your head blown off! Get out of those hills!";
$BorderGame::OOBMessage[$BorderGame::OOBCount++] = "Commander: Soldier, you're going to get shot if you don't get back to safety!";
$BorderGame::OOBMessage[$BorderGame::OOBCount++] = "Commander: Go back! There's nothing but snipers in the hills!";
$BorderGame::OOBMessage[$BorderGame::OOBCount++] = "Commander: You're not going to survive much longer if you don't head back!";
$BorderGame::OOBMessage[$BorderGame::OOBCount++] = "Commander: Turn around before a sniper sees you!";
$BorderGame::OOBCount++;

function OutOfBoundsChecker(%clientID)
{

if(%clientID.outofboundstimes==0)
{
	
	Client::sendMessage(%clientId, 3, $BorderGame::OOBMessage[floor(getRandom()*$BorderGame::OOBCount)]@"~wmale5.wdeath.wav");
}
%clientID.outofboundstimes++;
if(%clientID.outofboundstimes>3)
{
		playSound(ricochet1,gamebase::Getposition(%clientID));
		Client::sendMessage(Player::getClient(%object),1,"An enemy sharp shooter WOULD HAVE spotted you. Sorry.");
		%clientID.outofboundstimes = 0;
		GameBase::applyDamage(Client::getownedobject(%clientId),$RobarDamageType, 100.0,vector::add(GameBase::getPosition(%clientid),"0 0 3"),"0 0 0","0 0 0",$BorderKiller);

}
}
function NewQuadrant(%clientId)
{
%num = %clientId.CurQuad;


if($AAISpawning::QuadrantTrigger[%num] != "" && $AAISpawning::QuadrantSpawned[%num] != 1)
{
	echo(Client::getname(%clientID)@" in Quadrant: "@%num@" Spawning: "@$AAISpawning::QuadrantTrigger[%num]);
	
	$AAISpawning::QuadrantSpawned[%num] = 1;
	SetupAAILoad($AAISpawning::QuadrantTrigger[%num]);

}

	if($AAISpawning::QuadrantTrigger[%num] != "" && ((player::getItemcount(%clientid,CDFlag) > 0) || $AAISpawning::TriggerWithoutFlag[%num] == 1) && $AAISpawning::QuadrantTriggered[%num] != 1)
	{
	if($aaikillit)
		return;
	eval($MissionName@"_Run"@$AAISpawning::QuadrantTrigger[%num]@"Scripts("@%clientID@");");
	$AAISpawning::QuadrantTriggered[%num] = 1;
	}
}

function EndOutOfArea(%clientId, %wp, %neg)
{
if($stopchecks)
	return;


%pos = getword(gamebase::getposition(%clientId), 0)@" "@getword(gamebase::getposition(%clientId), 1)@" 0";

	
	%dot = vector::dot(vector::normalize(vector::sub($AAIBorderData::LeftPos[%wp], %pos)), $AAIBorderData::CrossDirBorderDir[%wp]);
	if(%neg == 1)
	{
	
	if(%dot<0)
		{
		%clientId.CurQuad = $AAIBorderData::BorderMax-1;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		CheckQuadrant(%clientId);
		return;
		}
	}
	else
	{
	
	if(%dot>0)
		{
		%clientId.CurQuad = 0;
		//client::sendmessage(%clientID, 3, "Now in quadrant #"@%clientId.CurQuad);
		NewQuadrant(%clientId);
		CheckQuadrant(%clientId);
	
		return;
		}
	}
	
	OutOfBoundsChecker(%clientID);
	schedule("EndOutOfArea("@%clientId@", "@%wp@", "@%neg@");", 1.0);
	
}

function Player::enterMissionArea(%this)
{
   return;
}

function Player::leaveMissionArea(%this)
{
	return;
}
 