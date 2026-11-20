$InvList[CatPack] = 1;
$MobileInvList[CatPack] = 1;
$RemoteInvList[CatPack] = 1;
AddItem(CatPack);

$CanAlwaysTeamDestroy[DeployableCat] = 1;
$TeamItemMax[CatPack] = 10;

ItemImageData CatPackImage 
{
	shapeFile = "shieldPack";	//sensor_small";
	mountPoint = 2;
//	mountOffset = { 0, 0, 0.1 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData CatPack 
{
	description = "Cat sensor";
	shapeFile = "shieldPack";	//sensor_small";
	className = "Backpack";
	heading = $InvHead[ihDSe];
	imageType = CatPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CatPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(!checkDeployArea(%client,$los::position)) 
	{
		return false;
	}		
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
// Check for other cats to avoid cat fights...
	%set = newObject("set",SimSet);
	%Mask = $StaticObjectType; 
	%num = containerBoxFillSet(%set,%Mask,$los::position,50,50,50,0);
	%totalnum = Group::objectCount(%set);
	for(%i = 0; %i < %totalnum; %i++)
	{
		%obj = Group::getObject(%set, %i);
		%item = Item::getItemData(%obj);
		%type = getObjectType(%obj);
		%name = GameBase::getDataName(%obj);
		%dist = Vector::getDistance($los::position, GameBase::getPosition(%obj));
		if(%dist < 25)
			if(GameBase::getDataName(%obj) == DeployableCat)
				if(%obj.CatTeam == GameBase::getTeam(%player))
					%no = true;
	}
	deleteObject(%set);
	if(!%no!=true)	//teehee -Plasmatic
	{
		Client::sendMessage(%client,0,"Interference from another Cat sensor.");		
		return false;	
	}		

	//Ok, lets set this up. 
	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	%xpos = getWord($los::position,0);
	%ypos = getWord($los::position,1);
	%zpos = getWord($los::position,2);
	if(Vector::dot($los::normal,"0 0 1") > 0.6) 
	{
		%rot = "0 0 " @ %zRot;
		%zpos += 0.05;//floor
	}
	else 
	{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
		{
			%rot = "3.14159 0 " @ %zRot;
			%zpos -= 0.05;//ceiling
		}
		else 	
		{
			%rot = Vector::getRotation($los::normal);

			//wall
			%xopos = getWord($los::normal,0);
			%yopos = getWord($los::normal,1);

			%xpos = %xpos + %xopos/10;
			%ypos = %ypos + %yopos/10;

		}
	}
	%pos = %xpos@" "@%ypos@" "@%zpos;
	%rot = vector::add(%rot,"-1.57 0 0");

	%mSensor = newObject("DeployableKitty","Turret",DeployableCat,true);

	addToSet("MissionCleanup/deployed/sensor", %mSensor);
	%PlayerTeam = GameBase::getTeam(%player);
	if(%PlayerTeam == 0) 	%catTeam = 1;	
		else %catTeam = 0;	
	%TeamNum = getNumTeams()-1;	//
	GameBase::setTeam(%mSensor,%TeamNum);		//%catTeam
	%mSensor.CatTeam = %PlayerTeam;
	GameBase::setRotation(%mSensor,%rot);
	GameBase::setPosition(%mSensor,%pos);
	Gamebase::setMapName(%mSensor,"Pussy Cat #"@$TeamItemCount[GameBase::getTeam(%player) @ %item]+1);
	Client::sendMessage(%client,0,"Pussy Cat deployed");
	playSound(SoundPickupBackpack,$los::position);
	if(!$build)
		echo("MSG: ",%client," deployed a Pussy Cat");
	$TeamItemCount[GameBase::getTeam(%player) @ "CatPack"]++;	
	return true;
}

TurretData DeployableCat
{
	className = "SelfPoweredSensor";
	shapeFile = "shieldPack";	//sensor_small"; //"remoteturret";
	projectileType = SeekerLaser;
	maxDamage = 2.50;
	maxEnergy = 300;
	minGunEnergy = 90;
	maxGunEnergy = 0.1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2.5;	//2.5
	speed = 0.5;		//0.5
	speedModifier = 1.0;	//1.0
	range = 15;
	visibleToSensor = false;	//true;
//	shadowDetailMask = 4;
	dopplerVelocity = 1;	//0;
	castLOS = false;	//true;
	supression = false;
	supressable = false;
	pinger = false;		//true;
//	mapFilter = 2;
//	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
//	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Cat sensor";
	damageSkinData = "objectDamageSkins";
	
//	lightType = 2; // Pulsing
//	lightRadius = 4;
//	lightTime = 1.5;
//	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1, 1, 1 };	
	
};

function DeployableCat::verifyTarget(%this,%target)
{
	if (getSimTime() - $Catnap[%this] > 5)
	{
		%thispos = GameBase::getPosition(%this);
		%targetpos = GameBase::getPosition(%target);
		%dist = Vector::getDistance(%thispos, %targetpos);
		%clientId = Player::getClient(%target);
		if(%dist < 25 && %clientId.isSpy && %this.CatTeam == gamebase::getteam(%target)) 
		{		
			//echo("Distance to target is " @ %dist);
			$Catnap[%this] = getSimTime();
			%team =gamebase::getteam(%this);
			%client = Player::getClient(%target);
			TeamMessages(3, %this.CatTeam, Gamebase::getMapName(%this)@" has detected chameleon " @ Client::getName(%client)@"~wC_BuySell.wav");	
		//ann 2.2 -plasmatic -20% chance of deactivating cham pack
		//Ann 3.0 Change to distance based. 100% 'chance' if standing on top of cat. 
			%chance = floor(150*(1/%dist));
			if(%chance> 100)
				%chance = 100;

			
			if(floor(getrandom() * 100) < %chance)
			{
				%target.ChamCollapse = true; 
				Client::sendMessage(%clientId,0,"WARNING! Imminent Chameleon field collapse.~waccess_denied.wav");
				schedule("Player::trigger("@%target@", $BackpackSlot, false);",1.0);
			}	
			else 
				ChameleonPack::Buffer(%target);

			if($debug)
				echo(GameBase::GetMapName(%this) @ " has detected Chameleon" @ Client::getName(%client));
			return false;
		}
		return false;
	}
	return false;
}

function DeployableCat::onAdd(%this)
{
	$Catnap[%this] = "";	//resetting for simtime.. gets reset every map, could carry over...
	schedule("DeployableCat::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.010;//0.0
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Pussy cat");
	}
}

function DeployableCat::deploy(%this)
{
	//GameBase::playSequence(%this,1,"deploy");
	GameBase::setActive(%this,true);
}

//function DeployableCat::onEndSequence(%this,%thread)
//{
//	GameBase::setActive(%this,true);
//}

function DeployableCat::onDestroyed(%this)
{
	$Catnap[%this] = "";// clean up
	Turret::onDestroyed(%this);
	%team = %this.OrgTeam;
	$TeamItemCount[%team @ "CatPack"]--;	
	
	%this.OrgTeam = "";

  //	$TeamItemCount[GameBase::getTeam(%this) @ "BaseAlarm"]--;	// 3.0 fix
}


