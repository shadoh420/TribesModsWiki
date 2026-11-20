$InvList[PlatformPack] = 1;
$MobileInvList[PlatformPack] = 1;
$RemoteInvList[PlatformPack] = 1;
AddItem(PlatformPack);

$CanAlwaysTeamDestroy[DeployablePlatform] = 1;

ItemImageData PlatformPackImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlatformPack 
{
	description = "Deployable Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,4)) 
	{
		if(!$build)Client::sendMessage(%client,0,"Deploy position out of range");
		GameBase::playSound(%player, SoundPackUse, 0);
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	%type = GameBase::getDataName(%obj);
	
	%deployPos = $los::position;
	%DeployRot = GameBase::getRotation(%player);//floor
	if(%type == DeployablePlatform)
	{
		%PlatPos = GameBase::getPosition(%obj);
		%PlatRot = GameBase::getRotation(%obj);
		for(%f = 0; %f < 6; %f += 1.575)
		{
			%markerpos =  vector::add(%PlatPos,rotatevector("2.3 0 0.5",vector::add(%PlatRot,"0 0 "@%f )));
			if(Vector::getdistance(%markerpos,%deployPos) < 0.5)
			{
				%deployPos = vector::add(rotatevector("6 0 0",vector::add(%PlatRot,"0 0 "@%f )),%PlatPos);
				%DeployRot = %PlatRot;
			}
			
		}
	}
	if(%obj.inmotion == true && !$Build)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	
		
	

	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	{
		%prot = GameBase::getRotation(%player);
		%xRot = getWord(%prot,0);
		%yRot = getWord(%prot,1);
		%zRot = getWord(%prot,2);			
		%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
		%up = true;
	}	
	
	%platform = newObject("DeployablePlatform", "StaticShape", DeployablePlatform, true);

	addToSet("MissionCleanup/deployed/Barrier", %platform);
//	%rot = GameBase::getRotation(%player);
	GameBase::setTeam(%platform, GameBase::getTeam(%player));
	GameBase::setPosition(%platform, %deployPos);
	GameBase::setRotation(%platform, %deployRot);
	Gamebase::setMapName(%platform, "Deployable Platform "@Client::getName(%client));
	if(!$build)
		Client::sendMessage(%client,0,"Platform Deployed");
	GameBase::startFadeIn(%platform);
	playSound(SoundPickupBackpack,%deployPos);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	if($build && !%up)
	{		
		GameBase::setPosition(%player, vector::add(GameBase::getPosition(%player),"0 0 1"));		
	}	
	if(!$build)
		echo("MSG: ",%client," deployed an platform");
		
		
//	for(%f = 0; %f < 6; %f += 1.575)
//	{
//		%platform = newObject("DeployableForce", "StaticShape", DeployableForce, true);
//		addToSet("MissionCleanup/deployed/Barrier", %platform);	
//		%markermove = rotatevector("2.3 0 0.5",vector::add(%deployRot,"0 0 "@%f ));
//		echo(%f@" "@%markermove);
//		%markerpos =  vector::add(%deployPos,%markermove);
//		GameBase::setPosition(%platform, %markerPos);	
//		
//	}
		
		
	return true;
}
StaticShapeData DeployableForce 
{
	shapeFile = "force";
	debrisId = defaultDebrisSmall;
	maxDamage = 4;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Force Marker";
};

StaticShapeData DeployablePlatform 
{
	shapeFile = "elevator6x6thin";
	debrisId = defaultDebrisSmall;
	maxDamage = 4;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Deployable Platform";
};

function DeployablePlatform::onDestroyed(%this) 
{
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
}

