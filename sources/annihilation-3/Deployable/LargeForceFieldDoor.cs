$InvList[LargeForceFieldDoorPack] = 1;
$MobileInvList[LargeForceFieldDoorPack] = 1;
$RemoteInvList[LargeForceFieldDoorPack] = 0;
AddItem(LargeForceFieldDoorPack);

$CanAlwaysTeamDestroy[LargeForceFieldDoor] = 1;

ItemImageData LargeForceFieldDoorPackImage
{	
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldDoorPack
{	
	description = "Large Force Field Door";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = $InvHead[ihBar];
	imageType = LargeForceFieldDoorPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldDoorPack::deployShape(%player,%item)
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
	%obj = newObject("LargeForceFieldDoorPack","StaticShape",LargeForceFieldDoorShape,true);//
	%obj.cloakable = true;
	GameBase::playSequence(%obj,2,"");	//Object:thread:seq

	addToSet("MissionCleanup/deployed/Barrier", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setRotation(%obj,%rot);
	GameBase::setPosition(%obj,$los::position);
	Gamebase::setMapName(%obj,"Large Force Field Door "@Client::getName(%client));
	Client::sendMessage(%client,0,"Large Force Field Door deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @ "LargeForceFieldDoorPack"]++;
	%obj.deployer = %client; 	//for destroy points, bk messages -plasmatic
	if(!$build)
		echo("MSG: ",%client," deployed a Large Force Field Door ");
	return true;
}

StaticShapeData LargeForceFieldDoorShape
{	
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield";
	maxDamage = 6.0;
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
	description = "Large Force Field Door";
};

function LargeForceFieldDoorShape::Destruct(%this)
{	
	LargeForceFieldDoorShape::doDamage(%this);
}

function LargeForceFieldDoorShape::onDestroyed(%this)
{	
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
	%this.cloakable = "";
	%this.nuetron = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldDoorPack"]--;
}

function LargeForceFieldDoorShape::onCollision(%this,%obj)
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
		
	LargeForceFieldDoorShape::openDoor(%this);

}

function LargeForceFieldDoorShape::openDoor(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 1000");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("LargeForceFieldDoorShape::closeDoor("@%this@");",2);
}

function LargeForceFieldDoorShape::closeDoor(%this) 
{	
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -1000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function LargeForceFieldDoorShape::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)	//LargeForceFieldDoorShape
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