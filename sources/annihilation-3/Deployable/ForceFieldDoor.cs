$InvList[ForceFieldDoorPack] = 1;
$MobileInvList[ForceFieldDoorPack] = 1;
$RemoteInvList[ForceFieldDoorPack] = 0;
AddItem(ForceFieldDoorPack);

$CanAlwaysTeamDestroy[ForceFieldDoor] = 1;

ItemImageData ForceFieldDoorPackImage
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldDoorPack
{	
	description = "Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = ForceFieldDoorPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldDoorPack::deployShape(%player,%item)
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build) 
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3)) 
	{
		Client::sendMessage(%client,0,"Cannot deploy here.");
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
	%obj = newObject("ForceFieldDoorPack","StaticShape",ForceFieldDoorShape,true);

	%obj.cloakable = true;
	addToSet("MissionCleanup/deployed/Barrier", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setRotation(%obj,%rot);
	GameBase::setPosition(%obj,$los::position);
	Gamebase::setMapName(%obj,"Force Field Door "@Client::getName(%client));
	Client::sendMessage(%client,0,"Force Field Door deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @ "ForceFieldDoorPack"]++;
	%obj.deployer = %client; 	//for destroy points, bk messages -plasmatic
	if(!$build)
		echo("MSG: ",%client," deployed a Force Field Door ");
	return true;
}

StaticShapeData ForceFieldDoorShape
{	
	className = "ForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 4.5;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Force Field Door";
};

function ForceFieldDoorShape::Destruct(%this)
{	
	ForceFieldDoorShape::doDamage(%this);
}

function ForceFieldDoorShape::onDestroyed(%this)
{	
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldDoorPack"]--;
}

function ForceFieldDoorShape::onCollision(%this,%obj)
{	
	%data = GameBase::getDataName(%obj);
	%velocity = vector::getdistance(Item::GetVelocity(%obj),"0 0 0");
	if($debug)
		echo("!!Collision "@%data@" hitting "@GameBase::getDataName(%this)@" Vel. "@%velocity);
						
	if(getObjectType(%obj) == "Flier") 
	{ 		
		%damage = GameBase::getDamageLevel(%obj) + %velocity/10;
		GameBase::setDamageLevel(%obj,%damage);
		playSound(SoundFlierCrash,GameBase::getPosition(%obj));
	}
	
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj))
		return;
		
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
		return;
		
	if(%this.forker)
		return;
		
	ForceFieldDoorShape::openDoor(%this);
}

function ForceFieldDoorShape::openDoor(%this) 
{	
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("ForceFieldDoorShape::closeDoor("@%this@");",2);
}

function ForceFieldDoorShape::closeDoor(%this) 
{	
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function ForceFieldDoorShape::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)	//LargeForceFieldDoorShape
{
	if(%type == $SniperDamageType && Player::getMountedItem(%object,$WeaponSlot) == Railgun && %object.rail)
		%value = %value*3;	
	
	%damageLevel = GameBase::getDamageLevel(%this);
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