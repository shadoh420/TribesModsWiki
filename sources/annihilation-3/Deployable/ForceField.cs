$InvList[ForceFieldPack] = 1;
$MobileInvList[ForceFieldPack] = 1;
$RemoteInvList[ForceFieldPack] = 1;
AddItem(ForceFieldPack);

$CanAlwaysTeamDestroy[ForceField] = 1;

ItemImageData ForceFieldPackImage 
{ 
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack 
{ 
	description = "Force Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::deployShape(%player,%item) 
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
	%objForceField = newObject("","StaticShape",DeployableForceField,true);

	addToSet("MissionCleanup/deployed/Barrier", %objForceField);
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player));
	GameBase::setPosition(%objForceField,$los::position);
	GameBase::setRotation(%objForceField,%rot);		//vector::add(%rot,"1.57 1.57 1.57"));
	Gamebase::setMapName(%objForceField,"Force Field "@Client::getName(%client));
	Client::sendMessage(%client,0,"Force Field Deployed");
	GameBase::startFadeIn(%objForceField);
	playSound(SoundPickupBackpack,$los::position);
	playSound(ForceFieldOpen,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
	%objForceField.deployer = %client; 	//for destroy points, bk messages -plasmatic
	if(!$build)
		echo("MSG: ",%client," deployed a Force Field");
	return true;
}

StaticShapeData DeployableForceField 
{ 
	shapeFile = "forcefield_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 4.50;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Force Field";
};

function DeployableForceField::onDestroyed(%this) 
{ 
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
}
function DeployableForceField::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)	//LargeForceFieldDoorShape
{
	%damageLevel = GameBase::getDamageLevel(%this);
	
	if(%type == $SniperDamageType && Player::getMountedItem(%object,$WeaponSlot) == Railgun && %object.rail)
		%value = %value*3;	
	
	%dValue = %damageLevel + %value;
	GameBase::setDamageLevel(%this,%dValue);
			
	if(%value > 0 && %pos != "0 0 0" )
	{
		if(%type == 1 || %type == 6 || %type == 14 || %type == 16)
		{
			%obj = newObject("","StaticShape",DamageMarker,true);
			addToSet("MissionCleanup/deployed/Barrier", %obj);
			
			GameBase::setPosition(%obj,%pos);
			%player = Client::getOwnedObject(%object);
			%trans = GameBase::getMuzzleTransform(%player);
				
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z	
			%GunTipPos = %posX@" "@%posY@" "@%posZ;	
					
			%vektar = vector::normalize(vector::sub(%pos,%GunTippos));		
			%xrot = getword(%vektar,2);
			%rot = gamebase::getrotation(%player);
			GameBase::setRotation(%obj,%xrot@" 0 "@getword(%rot,2));		
		}
	}
}