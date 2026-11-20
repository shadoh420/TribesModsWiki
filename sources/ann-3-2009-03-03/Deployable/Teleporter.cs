$InvList[TeleportPack] = 1;
$MobileInvList[TeleportPack] = 1;
$RemoteInvList[TeleportPack] = 0;
AddItem(TeleportPack);

$CanAlwaysTeamDestroy[DeployableTeleport] = 1;

//	ItemImageData oldTeleportPackImage
//	{
//		shapeFile = "flagstand";
//		mountPoint = 2;
//		mountOffset = { 0, 0, 0.1 };
//		mountRotation = { 1.57, 0, 0 };
//		firstPerson = false;
//	};

ItemImageData TeleportPackImage
{
	shapeFile = "MagCargo";
	mountPoint = 2;
	mountOffset = { 0, -0.65, -0.45 };
	mountRotation = { -0.3, 0, 0 };
	firstPerson = false;
};


ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "enerpad";	//flagstand";
	className = "Backpack";
	heading = $InvHead[ihDOb];
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NeedTeleportSimSet()
{
	%teleset = nameToID("MissionCleanup/Teleports");
	if(%teleset == -1)
	{
		newObject(Teleports, SimSet);
		addToSet(MissionCleanup, Teleports);
	}
}

// reworked this function to tele on beam contact, and set into floor a little - plasmatic
function TeleportPack::deployShape(%player,%item)
{
	//%name = "Teleport Pad";
	//%shape = DeployableTeleport,
	%client = Player::getClient(%player);
	 // Verify item limit
	if($TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"] >= $TeamItemMax[TeleportPack]) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	// Verify proximity to player
	// GetLOSInfo sets the following globals:
	// 	los::position
	// 	los::normal
	// 	los::object
	if(!GameBase::getLOSInfo(%player,5)) 
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	// Verify type of deploy location
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform") 
	{
		client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	// Verify slope of deploy location
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	
	// Make sure A player can fit here.. Plasmatic 3/18/2005 6:17AM
	if(!GameBase::testPosition(%player,vector::add($los::position,"0 0 0.25"))) 
	{
		Client::sendMessage(%client,0,"The teleporter will not function there.");
		return false;
	}	
	
	// Make sure nothing is in the way of the deploy
	if(!checkInvDeployArea(%client,$los::position)) 
	{
		return false;
	}
	//
	// Passed validation, create the object
	//
	NeedTeleportSimSet();

	//-dropped a bit for new shape, plasmatic
	%pos = Vector::add($los::position,"0 0 -0.286");	//Vector::add($los::position,"0 0 1");
	
	// Create teleporter pad
	%objTeleport = newObject("Teleport Pad", "StaticShape", DeployableTeleport, true);
	echo("teleporter # "@%objTeleport);
	GameBase::playSequence(%objTeleport,0,"busy");	//plasmatic 2.3
	%objTeleport.deployer = %client; 	//for destroy points, bk messages -plasmatic
	
	GameBase::setPosition(%objTeleport,%pos);
	%prot =GameBase::getRotation(%player);
	GameBase::setRotation(%objTeleport,Vector::add(%prot,"0 0 -1.57"));
	GameBase::setTeam(%objTeleport,GameBase::getTeam(%player));
	Gamebase::setMapName(%objTeleport,%item.description);
	addToSet("MissionCleanup/Teleports", %objTeleport);
	addToSet("MissionCleanup", %objTeleport);
	
	// Create teleporter beam
	%beam = newObject("", "StaticShape", TeleportBeam, true);

	GameBase::setPosition(%beam,%pos);
	GameBase::setRotation(%beam,Vector::add(%prot,"0 0 3.14"));
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	addToSet("MissionCleanup/Teleports", %beam);
	addToSet("MissionCleanup", %beam);
	%objTeleport.beam1 = %beam;
	
	// Wrap things up
	%beam.disabled = false;
	%beam.Functional = true;
	playSound(SoundPickupBackpack, $los::position);
	Client::sendMessage(%client, 0, %item.description @ " deployed");
	echo("MSG: ",%client," deployed a Teleport Pad");
	$TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"]++;
	
	return true;
}

StaticShapeData DeployableTeleport
{
	className = "DeployableStation";
	damageSkinData = "objectDamageSkins";
	shapeFile = "enerpad";
	maxDamage = 3.0;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};

//Plasmatic
StaticShapeData TeleportBeam 	
{ 
	className = "TeleportBeam";
	shapeFile = "zap";		//_5"; 
	maxDamage = 10000.0; 
	isTranslucent = true; 
//	description = "Electrical Beam";  
	disableCollision = true;	//2.2 -plasmatic
};

function RemoveBeam(%b)
{
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}

function DeployableTeleport::Destruct(%this)
{
	//CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}

// reworked this function to tele on base contact, and destroy properly - plasmatic
function DeployableTeleport::onDestroyed(%this)
{
	echo("DeployableTeleport::onDestroyed");
	schedule("RemoveBeam("@%this.beam1@");",0.01);
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleportPack"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		// Applying damage to all teleporters on this team
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		}
	}

}


// reworked this function to tele on base contact - plasmatic
// added player rotation and push out of tele also.
// changed for 2.2 -plasmatic
function DeployableTeleport::onCollision(%this, %obj)
{	
	if($debug) 
		event::collision(%this,%obj);
	if(%obj.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;		
	if(getObjectType(%obj) == "Player")
		%isPlayer = true;
	if(%isPlayer && Player::isDead(%obj))
		return;
	%telepos = gamebase::getposition(%obj);
	%playpos = gamebase::getposition(%this);
	%diff = vector::getdistance(vector::multiply(gamebase::getposition(%this),"1 1 0"),vector::multiply(gamebase::getposition(%obj),"1 1 0"));
	%vert = vector::getdistance(vector::multiply(gamebase::getposition(%this),"0 0 1"),vector::add(vector::multiply(gamebase::getposition(%obj),"0 0 1"),"0 0 -2.1"));
 	if($debug){
 		bottomprintall("<jc>Tele Collision "@%diff@" "@%vert);
 		messageall(1,"tele collision "@getObjectType(%obj));
 	}
	if(%diff > 1.3 || %vert > 1.7)
		return;	
		
	%c = Player::getClient(%obj);
	if(%this.Disabled)
	{
		Client::SendMessage(%c,0,"Recharging...");
		return;
	}
	if(GameBase::getDamageState(%this) != "Enabled")
	{
		Client::SendMessage(%c,0,"Needs repairs");
		return;
	}	
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	if($debug)
		messageall(1,"tele team "@%teleTeam@" object team  "@%playerTeam);
	%phased = false;
	if(%teleTeam != %playerTeam && %isPlayer)
	{
		if(Laptop::IsAvailable(%obj))
			%phased = true;
		else
		{
			Client::SendMessage(%c,0,"--ACCESS DENIED-- Wrong Team~waccess_denied.wav");
			return;
		}
	}	

	//
	// Teleport operation passed initial validation.
	//
	
	// non player objects can only go one way... -plasmatic
	if(%obj.teled == true)
		return;
		
	// Find the other pad
	%teleset = nameToID("MissionCleanup/Teleports");
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == %teleTeam && %o != %this && GameBase::getDataName(%o) == DeployableTeleport)// 2.2
		{
			if(%isPlayer)
			{
				GameBase::stopSequence(%this,0);				//plasmatic 2.3
				schedule("GameBase::playSequence("@%this@",0,\"busy\");",5);	//plasmatic 2.3
				GameBase::stopSequence(%o,0);					//plasmatic 2.3
				schedule("GameBase::playSequence("@%o@",0,\"busy\");",5);	//plasmatic 2.3				
				%o.Disabled = true;
				%this.Disabled = true;
				schedule(%o@".disabled = false;",5);
				schedule(%this@".disabled = false;",5);
			}
			else
				%obj.teled = true;
			
			%Scramble =  100*(GameBase::getDamageLevel(%this)/1.0);
			//echo("scramble %"@%scramble);
			if(floor(getRandom() * 100) <  1 + %Scramble && %scramble > 20)
			{
				Player::onDamage(%obj,3,0.25,%pos,%vec,%mom,%vertPos,%quadrant,%c);
				%spawnMarker = Game::pickRandomSpawn(%playerTeam);
				%spawnPos = GameBase::getPosition(%spawnMarker);
				%spawnRot = "0 0 "@ getword(GameBase::getRotation(%spawnMarker),2);

				Client::SendMessage(%c, 0, "Teleport communication error.~wError_Message.wav");
			//	echo(GameBase::getDamageLevel(%this)," ",GameBase::getDamageLevel(%o));
				if(GameBase::getDamageLevel(%this)< 0.8)
					GameBase::setDamageLevel(%this, GameBase::getDamageLevel(%this)+ 0.05);
				if(GameBase::getDamageLevel(%o)< 0.8)	
					GameBase::setDamageLevel(%o, GameBase::getDamageLevel(%o)+ 0.05);
				
			}			
			else
			{
				%spawnpos = Vector::add(GameBase::GetPosition(%o),"0 0 1.5");
				%spawnrot = vector::add(GameBase::getRotation(%o),"0 0 -1.57"); 
				GameBase::setRotation(%obj,%Trot);
				GameBase::playSound(%o, ForceFieldOpen, 0);
				if(!%phased)
					Client::SendMessage(%c, 0, "Teleport successful");
				else
					Laptop::Output(%c, "Enemy teleport override successful");				
			}
			if($debug)
				messageall(1,"tele Respawn point "@%spawnpos);
			GameBase::SetPosition(%obj, %spawnpos);
			GameBase::setRotation(%obj, %spawnrot);			
			
			Item::setVelocity(%obj,"0 0 0");
			if(%isPlayer)
				%forceDir = Vector::getFromRot(GameBase::getRotation(%obj),70,10); 
			else
				%forceDir = Vector::getFromRot(GameBase::getRotation(%obj),700,100); 
			
			
			Player::applyImpulse(%obj,%forceDir); 
			GameBase::playSound(%this, ForceFieldOpen, 0);	
			GameBase::playSound(%obj, ForceFieldOpen, 0);	

			return;
		}
	}
	if(Laptop::IsAvailable(%obj))
		Laptop::Error(%c, "No receiving teleport pad has been deployed.");
	else
		Client::SendMessage(%c,0,"No other teleport pad");
}

//plasmatic 2.3
function DeployableTeleport::onEnabled(%this)
{
	GameBase::playSequence(%objTeleport,0,"busy");	//plasmatic 2.3
}
//plasmatic 2.3
function DeployableTeleport::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);	//plasmatic 2.3
}