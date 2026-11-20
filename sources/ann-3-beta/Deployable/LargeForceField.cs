$InvList[LargeForceFieldPack] = 1;
$MobileInvList[LargeForceFieldPack] = 1;
$RemoteInvList[LargeForceFieldPack] = 1;
AddItem(LargeForceFieldPack);

$CanAlwaysTeamDestroy[LargeForceField] = 1;

ItemImageData LargeForceFieldPackImage 
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack 
{	
	description = "Large Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::deployShape(%player,%item) 
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
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	%rot = GameBase::getRotation(%player);
	%objForceField = newObject("","StaticShape",LargeForceField,true);

	addToSet("MissionCleanup/deployed/Barrier", %objForceField);
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player));
	GameBase::setPosition(%objForceField,$los::position);
	GameBase::setRotation(%objForceField,%rot);
	Gamebase::setMapName(%objForceField,"Force Field "@Client::getName(%client));
	Client::sendMessage(%client,0,"Force Field Deployed");
	GameBase::startFadeIn(%objForceField);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
	if(!$build)
		echo("MSG: ",%client," deployed a Large Force Field");
	return true;
}

StaticShapeData LargeForceField 
{ 
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 5.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Force Field";
};

function LargeForceField::onDestroyed(%this) 
{ 
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;
}
