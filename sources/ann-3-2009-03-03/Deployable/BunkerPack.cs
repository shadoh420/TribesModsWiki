$InvList[BunkerPack] = 1;
$MobileInvList[BunkerPack] = 1;
$RemoteInvList[BunkerPack] = 0;
AddItem(BunkerPack);

ItemImageData BunkerPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData BunkerPack
{
	description = "Deployable Bunker";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihRem];
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

// how many objects named %name in %set with count %num -plasmatic
function BunkerCountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{	%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function BunkerPack::deployShape(%player,%item)
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
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
	%num = BunkerCountObjects(%set,"eround1",%num);
	deleteObject(%set);
	if(20 < %num) 
	{
		Client::sendMessage(%client,0,"Too close to other objects.");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
	%num = BunkerCountObjects(%set,"eround1",%num);
	deleteObject(%set);
	if(0 != %num) 
	{
		Client::sendMessage(%client,0,"Too close to other objects.");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!BnkrDeployArea(%client,$los::position))
	{
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%vctr = "0 0 3.3";
	%rot = Vector::add(%rot,%vctr);
	%pos = $los::position;
	DeployBunkerJewels(%player,%pos,%rot);

	Client::sendMessage(%client,0,"Bunker Deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
	echo("MSG: ",%client," deployed a bunker.");
	return true;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
StaticShapeData BunkerPanel0
{
	shapeFile = "panel_set";
	debrisId = defaultDebrisLarge;	//flashDebrisSmall;
	explosionId = WickedBadExp;	//flashExpMedium;
	maxDamage = 30;
	damageSkinData = "objectDamageSkins";
	description = "Bunker Panel";
};
StaticShapeData BunkerPanel1
{
	shapeFile = "dsply_s1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 30;
	damageSkinData = "objectDamageSkins";
	description = "Bunker Panel";
};
StaticShapeData BunkerPanel2
{
	shapeFile = "dsply_s2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 30;
	damageSkinData = "objectDamageSkins";
	description = "Bunker Panel";
};
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function PickRandomJewel()
{
	return getword("BunkerPanel0 BunkerPanel1 BunkerPanel2",floor(getrandom()*3));
}
function DeployBunkerJewels(%player,%pos,%rot)
{
	
	while(%group != -1)
	{
		%group = nameToID("MissionCleanup/Bunker" @ %team@%i);
		%i++;
	}
	%group = newObject("Bunker" @ %team@%i,SimGroup);
	addToSet("MissionCleanup",%group);		
	
	%team = GameBase::getTeam(%player);
	
	%bunker = newObject("eround1",InteriorShape,"eround.dis",false);
	addToSet(%group, %bunker);
	GameBase::setTeam(%bunker,%team);
	GameBase::setPosition(%bunker,%pos);
	GameBase::setRotation(%bunker,%rot);	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"3.2688 1.86615 2",%Rot,"0 0 1.95997",%team,"Bunker");	
	addToSet(%group,%object);
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"-3.20441 1.91813 2",%Rot,"0 0 -1.95997",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"2.17032 -3.10829 2",%Rot,"0 -0 0.399997",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"-2.11798 -3.12288 2",%Rot,"0 -0 -0.379992",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"-3.21266 -1.96599 2",%Rot,"0 -0 1.95996",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"2.18351 3.10245 2",%Rot,"0 -0 -0.379994",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"3.19522 -1.92592 2",%Rot,"0 -0 1.17996",%team,"Bunker");	
		
	%object = newObject("","StaticShape",PickRandomJewel(),false);
	Ann::DeployRotate(%group,%object,%pos,"-2.16143 3.12258 2",%Rot,"0 -0 0.379997",%team,"Bunker");	
	
}
function Bunker::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($debug::Damage)
	{
		echo("Bunker::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}	
	
	if(%value == 0)
		return;
	//messageall(1,"ouch....");
	
	if(%type == $SniperDamageType && Player::getMountedItem(%object,$WeaponSlot) == Railgun && %object.rail)
		%value = %value*3;	
	
	%group = getgroup(%this);
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	if(%dValue < 27)
	{	
		for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
		{
			//echo("Index "@%obj@" "@%i);
			GameBase::setDamageLevel(%obj,%dValue);
		}
	}
	else
	{		
		%bunker = Group::getObject(%group, 0);
		for(%i = 1; (%obj = Group::getObject(%group, %i)) != -1; %i++)
		{
			//schedule("GameBase::setDamageLevel("@%obj@",50);",0.125);
			GameBase::setDamageLevel(%obj,50);
		}
		schedule("deleteobject("@%bunker@");",0.025);
		schedule("deleteobject("@%group@");",0.25);
	}	
}

function BnkrDeployArea(%client,%pos)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
	if(!%num) 
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}