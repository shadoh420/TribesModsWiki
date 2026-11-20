StaticShapeData ShipAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	shieldShapeName = "shield";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	description = "Small Antenna";
};





function DropShip::deployShape(%player,%name,%item,%length,%width,%height,%offset)
{
	%clientId = Player::getClient(%player);
	GameBase::getLOSInfo(%player,3);
	%pos = $los::position;
	%team=GameBase::getTeam(%player);
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{	
		Client::sendMessage(%clientId,0,"Deploy position out of range");
		return false;
	}
	if(getNumTeams() == 2)
	{
		%playerTeam = Client::getTeam(%clientId);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%clientId,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{	
		Client::sendMessage(%clientId,0,"Can only deploy on terrain");
		return false;
	}
// check for other deployed ships.
	for(%i = 0; %i<$ship+1; %i++)
	{
	%shipPos = getword($DropShipPosition[%i],0) @" "@ getword($DropShipPosition[%i],1)@" "@getword($los::position,2);	
//	echo($los::position@" " @%i@" "@%shipPos@" "@Vector::getDistance(%shipPos,$los::position));
	if(Vector::getDistance(%shipPos,$los::position)< 70){
		Client::sendMessage(%clientId,0,"You are too close to another ships landing position~waccess_denied.wav");
		return false;
		}
	}
//----------------
	if(!DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset))
		return false;

	
	DropShip::CreateSimGroup(%name,%team);
	
	%obj = newObject("Sensor1",StaticShape,ShipAntenna,false);
	NukeList(%obj);
	//%obj = newObject("Sensor1",Sensor,AntennaSensor,false);
	addToSet("MissionCleanup",%obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setPosition(%obj,%pos);
	%rot = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	gamebase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name@%team);
	$DropShip[%name@%team] = %pos;
	$DropShipBeacon[%name@%team] = %obj;
	//bottomprintall("GunShip De-Orbit Sequence Commencing, 20 seconds until Landing Sequence");
	%PlayerName = Client::getName(%clientId);
	DropshipTeamMessage(%team, 1, %PlayerName@" has deployed a "@%name@" Beacon, 20 seconds until De-Orbit Burn");
	$TeamItemCount[%team @ %item]++;
//	Client::sendMessage(%clientId,0,%name @ " Beacon Deployed, 20 seconds until De-Orbit Burn");
	echo("MSG: ",%clientId," deployed a " @ %name @ " Beacon");
	
	return %obj;
}

// for player rotations only -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5);  
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}


function ShipAntenna::onDestroyed(%this)
{
	echo("destroy drop ship small antennae");
	%team = GameBase::getTeam(%this);
	%name = Gamebase::getMapName(%this);
	$DropShipBeacon[%name] = "";
//	DropshipTeamMessage(%team, 1, "Your teams "@%name@" has been destroyed");
	schedule("deleteobject(" @ %this @ ");", 2);
}   

function DropshipTeamMessage(%team, %color, %msg)
{
//	%team = Client::getTeam(%client);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%now = Client::getTeam(%cl);
		if(%team == %now)
		{
			Client::sendMessage(%cl,%color,%msg);
		}
	}
}

function DropShip::CheckDeployArea(%clientId,%pos,%length,%width,%height,%offset)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,%length,%width,%height,%offset);
	if(!%num) 
	{
		deleteObject(%set);
		return true;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %clientId) 
			Client::sendMessage(%clientId,0,"Unable to deploy - You're in the way");
		else 
			Client::sendMessage(%clientId,0,"Unable to deploy - Player in the way");
	}
	else if(%num == 1)
	{
		%obj = Group::getObject(%set,0);
		//%name = GameBase::getMapName(%obj);
		%type = getObjectType(%obj);
		Client::sendMessage(%clientId,0,"Unable to deploy - " @ %type @ " in the landing zone");
	}
	else if(%num > 1)
		Client::sendMessage(%clientId,0,"Unable to deploy - Multiple items in the landing zone");
	else
		Client::sendMessage(%clientId,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return false;
}

function DropShip::CreateSimGroup(%name,%team)
{
	%teleset = nameToID("MissionCleanup/"@%name@%team);
	if(%teleset == -1)
	{	
		%group = newObject(%name@%team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
}

function DropShip::CreateShip(%name,%shape,%pos,%team)
{

	$DropShipPosition[$Ship] = %pos;
	$ship = $ship +1;
//	echo("DropShip::CreateShip(" @ %name @ "," @ %shape @ "," @ %pos @ "," @ %team @ ")");
//	echo("name " @ %name);
//	echo("shape " @ %shape);
	%obj = newObject(%name,InteriorShape,%shape);
	GameBase::startFadeIn(%obj);
	echo("Created Dropship name: "@ %name @ " object#: " @ %obj);
	addToSet("MissionCleanup/"@%name@%team, %obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,%team);
	return(%obj);
}

function DropShip::MoveShip(%this,%steps,%name)
{	
	//echo(moveship);
	%movement = 0.100000;
	%pos = GameBase::GetPosition(%this);
	%pos = Vector::add(%pos,"0 0 -" @ %movement);
	GameBase::SetPosition(%this,%pos);
	%steps--;
	//%this.inmotion = true;
	if(%steps > 0)
		schedule("DropShip::MoveShip(" @ %this @ "," @ %steps @ "," @ %name @ ");", 0.01, %this);
	else if(%steps == 0){
		%this.inmotion = "";
		schedule(%name@"::DeployItems(" @ %this @ ");", 3, %this);
		}
}