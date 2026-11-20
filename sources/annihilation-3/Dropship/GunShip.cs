$InvList[GunShipPack] = 1;		//1
$MobileInvList[GunShipPack] = 0;
$RemoteInvList[GunShipPack] = 0;
AddItem(GunShipPack);


ItemImageData GunShipPackImage
{
	shapeFile = "anten_small";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData GunShipPack
{
	description = "Gun Ship Beacon";
	shapeFile = "anten_small";
	className = "Backpack";
	heading = $InvHead[ihRem];
	shadowDetailMask = 4;
	imageType = GunShipPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 500000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData GunShipGen
{
	description = "Gun Ship Generator";
	shapeFile = "generator";
	classname = "Generator";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};

function GunShipPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	
	if(!GameBase::getLOSInfo(%player,5)) 
	{	
		%clientId = Player::getClient(%player);
		Client::sendMessage(%clientId,0,"Deploy position out of range");
		return false;
	}
	%object = newObject("Gun Ship","InteriorShape", "gswdrop.dis");
	GameBase::setRotation(%object,"0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14);
	%pos = $los::position;
	%test=GameBase::testPosition(%object,vector::add(%pos,"0 0 9"));	//testposition only tests for .dts with ?rotation? -Plasm

	schedule("DeleteObject("@%object@");",1);
	
	//I'm assuming boxfill creates a trigger shaped object.. -Plas 3.x
	%BoxPos[0] = "0 -35 150";	//nose
	%boxSize[0] = "30 30  290";
	%BoxPos[1] = "0 5 150";		//ass
	%boxSize[1] = "45 45 285";
	%BoxPos[2] = "34 1 155";	//wing
	%boxSize[2] = "17 17 285";
	%BoxPos[3] = "-34 1 155";	//wing
	%boxSize[3] = "17 17 285";	
	%prot  = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	%client = Player::getClient(%player);
	for(%i = 0; %i < 4; %i++)
	{	
		%newpos = vector::add(%pos,rotatevector(%BoxPos[%i],%prot));
		%length = getword(%boxSize[%i],0);
		%width = getword(%boxSize[%i],1);
		%height = getword(%boxSize[%i],2);
		%offset = %height/2;
		echo("pass "@%i);
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType ,%newpos,%length,%width,%height,%offset);
		%boundingBox = "-"@ %length/2 @" -"@  %width/2 @" -"@ %height/2 @" "@ %length/2 @" "@  %width/2 @" "@ %height/2;

		%count = Group::objectCount(%set);	
		for(%num = 1; %num < %Count && %num < 25; %num++)
		{
			%obj = Group::getObject(%set,%num);
			%name = GameBase::getMapName(%obj);
			%type = getObjectType(%obj);			
			echo("found "@%type@", "@%name);
			//Client::sendMessage(%client,0,"Unable to deploy - " @ %type@", "@%name@ " in the landing zone");
			%noway = true;	
		}		
		deleteObject(%set);
	}
//	GunShip::setupfake(%player,%pos);
	
	if(%test && !%noway)
	{
		%obj = DropShip::deployShape(%player,"GunShip",%item,100,80,400,0);
	}
	else
	{
		%clientId = Player::getClient(%player);
		Client::sendMessage(%clientId,0,"Landing area blocked.");
		return;
	}

	if(%obj)
	{
		
		Annihilation::decItemCount(%player,%item);
		%pos = $DropShip[GunShip@%team];
		%pos = Vector::add(%pos,"0 0 300");
		schedule("GunShip::DeployShape(\"" @ %pos @ "\", " @ %team @ ");", 20.0);

	}
}
function GunShipPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%obj = DropShip::deployShape(%player,"GunShip",%item,100,80,400,0);

	if(%obj)
	{
		
		Player::decItemCount(%player,%item);
		%pos = $DropShip[GunShip@%team];
		%pos = Vector::add(%pos,"0 0 300");
		schedule("GunShip::DeployShape(\"" @ %pos @ "\", " @ %team @ ");", 20.0);
	}
}

function GunShip::deployShape(%pos,%team,%beacon)
{	
//	echo(gamebase::getposition($DropShipBeacon[GunShip@%team]));
	if(gamebase::getposition($DropShipBeacon[GunShip@%team]) != "0 0 0")
	{
		%obj = DropShip::CreateShip("GunShip","gswdrop.dis",%pos,%team);
		gamebase::setrotation(%obj,gamebase::getrotation($DropShipBeacon[GunShip@%team]));
		%obj.inmotion = true;
		DropshipTeamMessage(%team, 1, "Your teams GunShip beginning deorbit.");
		DropShip::MoveShip(%obj,2900,"GunShip");
	}
	else {
		$TeamItemCount[%team @ GunShipPack]--;
		DropshipTeamMessage(%team, 1, "Your teams GunShip beacon has been destroyed, no location to lock onto.");
	}
}


function GunShip::DeployItems(%this)
{
	%shippos = GameBase::GetPosition(%this);
	%team = GameBase::GetTeam(%this);
	
//	%pos = rotateVector("0 0 -1.5",%prot);
//	%pos = Vector::add(%playerPos,%pos);	
//	%rot = Vector::add(%prot,%rot);	
	%prot = gamebase::getrotation(%this);
//	echo("rotation ",%prot);
	
	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("-5.6 3.4 4.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-5.6 3.4 4.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Inventory1","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");	
	%pos = rotateVector("5.6 3.4 4.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"5.6 3.4 4.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ship Inventory","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("-7.375 14.5 13.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-7.375 14.5 13.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("Ship Inventory","StaticShape",InventoryStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Inventory Station");
	%pos = rotateVector("7.375 14.5 13.5",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"7.375 14.5 13.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("CommandStation1","StaticShape",CommandStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Command Station");
	%pos = rotateVector("-6.5 14.375 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-6.5 14.375 18"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
//	GameBase::setPosition(%obj,"0 0 -3.13988");
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
	%pos = rotateVector("6.2 14.7 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%prot);	
//	GameBase::setPosition(%obj,Vector::add(%pos,"6.2 14.7 18"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("AmmoStation1","StaticShape",AmmoStation,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
//	GameBase::setPosition(%obj,"0 0 -3.13988");
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Ammo Station");
	%pos = rotateVector("0 20.5 7.5",%prot);
	%pos = Vector::add(%shippos,%pos);	
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 20.5 7.5"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0.2 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("24.35 1.7 17.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"24.35 1.7 17.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 -2.84 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("24.85 1.7 15.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"24.85 1.7 15.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 -0.2 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("-24.35 1.7 17.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-24.35 1.7 17.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("remoteturret","turret",PlasmaTurret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 2.84 3.14159";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Plasma Turret");
	%pos = rotateVector("-24.85 1.7 15.7",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"-24.85 1.7 15.7"));
	GameBase::startFadeIn(%obj);

	%obj = newObject("chainturret","turret",Elfturret,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 3.14073";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Elf Turret");
	%pos = rotateVector("0 0.5 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 0.5 18"));
	GameBase::startFadeIn(%obj);
	
	%obj = newObject("Sensor1","StaticShape",LargeRadar,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	GameBase::setRotation(%obj,%prot);
	Gamebase::setMapName(%obj,%name @ " Radar");
	%pos = rotateVector("0 12 22",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 12 22"));
	GameBase::startFadeIn(%obj);
		
	%obj = newObject("Generator","StaticShape",GunShipGen,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 1.57079";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	Gamebase::setMapName(%obj,%name @ " Main Generator");
	%pos = rotateVector("0 1.0 4.538",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
//	GameBase::setPosition(%obj,Vector::add(%pos,"0 1.0 4.538"));
	GameBase::startFadeIn(%obj);
	GameBase::setActive(%obj,True);

// drop points.. ;)	

	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 -0.8";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("-8 -3 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
	
	%obj = newObject("Drop Point", Marker, DropPointMarker,false);
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	GameBase::setTeam(%obj,%team);
	%rot = "0 0 0.8";
	%rot = Vector::add(%prot,%rot);
	GameBase::setRotation(%obj,%rot);
	%pos = rotateVector("8 -3 18",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);
	%newDropSet = nameToID("MissionCleanup/TeamDrops" @ %Team);
	addToSet(%newDropSet, %obj);
		
// REPAIR PACK.. its more like a real home now..	
	%obj = newObject("RepairPack","Item","repairpack",1,true,true);	//rotates	
	addToSet("MissionCleanup/GunShip"@%team, %obj);
	%pos = rotateVector("0 13 21",%prot);
	%pos = Vector::add(%shippos,%pos);
	GameBase::setPosition(%obj,%pos);	
		
	playSound(SoundPickupBackpack,%pos);
	playSound(ForceFieldOpen,%pos);
	
	return true;	
}

function GunShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($debug::Damage)
	{
		echo("GunShipGen::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}
	DropShipGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

//	instant InteriorShape "GunShip" {
//		fileName = "GSWDROP.dis";
//		isContainer = "1";
//		position = "0 0 0";
//		rotation = "0 0 0";
//		lightParams = "0 ";
//	};
//	instant Trigger "GroupTrigger1" {
//		dataBlock = "GroupTrigger";
//		name = "";
//		position = "-34 1 155";
//		rotation = "0 0 0";
//		boundingBox = "-8.5 -8.5 -142.5 8.5 8.5 142.5";
//		isSphere = "True";
//	};
//	instant Trigger "GroupTrigger1" {
//		dataBlock = "GroupTrigger";
//		name = "";
//		position = "0 -35 145";
//		rotation = "0 0 0";
//		boundingBox = "-15 -15 -145 15 15 145";
//		isSphere = "True";
//	};
//	instant Trigger "GroupTrigger1" {
//		dataBlock = "GroupTrigger";
//		name = "";
//		position = "0 5 145";
//		rotation = "0 0 0";
//		boundingBox = "-22.5 -22.5 -145 22.5 22.5 145";
//		isSphere = "True";
//	};
//	instant Trigger "GroupTrigger1" {
///		dataBlock = "GroupTrigger";
//		name = "";
//		position = "34 1 155";
//		rotation = "0 0 0";
//		boundingBox = "-8.5 -8.5 -142.5 8.5 8.5 142.5";
//		isSphere = "True";
//	};
function GunShip::CheckDeployArea(%player,%pos)
{
	//I'm assuming boxfill creates a trigger shaped object.. -Plas 3.0
	%BoxPos[0] = "0 -35 150";	//nose
	%boxSize[0] = "30 30  290";
	%BoxPos[1] = "0 5 150";		//ass
	%boxSize[1] = "45 45 285";
	%BoxPos[2] = "34 1 155";	//wing
	%boxSize[2] = "17 17 285";
	%BoxPos[3] = "-34 1 155";	//wing
	%boxSize[3] = "17 17 285";	
	%prot  = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	%client = Player::getClient(%player);
	for(%i = 0; %i < 4; %i++)
	{	
		%newpos = vector::add(%pos,rotatevector(%BoxPos[%i],%prot));
		%length = getword(%boxSize[%i],0);
		%width = getword(%boxSize[%i],1);
		%height = getword(%boxSize[%i],2);
		%offset = %height/2;
		echo("pass "@%i);
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType ,%newpos,%length,%width,%height,%offset);
		%boundingBox = "-"@ %length/2 @" -"@  %width/2 @" -"@ %height/2 @" "@ %length/2 @" "@  %width/2 @" "@ %height/2;
//well shit, lets place triggers so we can see where they end up, for debugging.. -Plas
	
//		instant Trigger "debugTrigger" {
//			dataBlock = "GroupTrigger";
//			name = "debugTrigger";
//		//	Team = %team;
//			position = %newpos;
//			rotation = "0 0 0";
//			boundingBox = %boundingBox;
//			isSphere = "true";
//		//	Owner = %this;
//		};

	//	if(!%num) 
	//	{
	//		deleteObject(%set);
	//	}
	//	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	//	{
	//		%obj = Group::getObject(%set,0);
	//		if(Player::getClient(%obj) == %clientId) 
	//			Client::sendMessage(%clientId,0,"Unable to deploy - You're in the way");
	//		else 
	//			Client::sendMessage(%clientId,0,"Unable to deploy - Player in the way");
	//	}
	//	else if(%num == 1)
	//	{
	//		%obj = Group::getObject(%set,0);
	//		%name = GameBase::getMapName(%obj);
	//		%type = getObjectType(%obj);
	//		Client::sendMessage(%clientId,0,"Unable to deploy - " @ %type@", "@%name@ " in the landing zone");
//
//		}
	//	else if(%num > 1)
	//		Client::sendMessage(%clientId,0,"Unable to deploy - Multiple items in the landing zone");
	//	else
	//		Client::sendMessage(%clientId,0,"Unable to deploy - Item in the way");
		%count = Group::objectCount(%set);	
		for(%num = 1; %num < %Count && %num < 25; %num++)
		{
			%obj = Group::getObject(%set,%num);
			%name = GameBase::getMapName(%obj);
			%type = getObjectType(%obj);			
			echo("found "@%type@", "@%name);
			Client::sendMessage(%client,0,"Unable to deploy - " @ %type@", "@%name@ " in the landing zone");
			%noway = true;	
		}		
		deleteObject(%set);
	}
//	GunShip::setupfake(%player,%pos);
	if(!%noway)
		return true;
}
function GunShip::setupfake(%player,%pos)
{
	%rot = "0 0 "@getWord(GameBase::getRotation(%player),2) + 3.14;
	%object = newObject("GunShip","InteriorShape", "gswdrop.dis");
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,vector::add(%pos,"0 0 5"));
	schedule("deleteobject("@%object@");",10);
}

function bitch()
{
		//Tribes gets confused when testing position with .dis and .dts, so we need more tests.. Sigh. 
	%camera = newObject("Camera","Turret",cameraturret,true);
			
	GameBase::setPosition(%camera,vector::add(rotateVector("-15 -7 10",%pRot),vector::add(%playerpos,"0 0 100")));
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 13;	
	GameBase::setPosition(%camera,vector::add(rotateVector("15 -7 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 14;	
	GameBase::setPosition(%camera,vector::add(rotateVector("0 -22 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 15;	
	GameBase::setPosition(%camera,vector::add(rotateVector("0 7 10",%pRot),vector::add(%playerpos,"0 0 100")));	
	if(GameBase::getLOSInfo(%camera,25,"1.5708 0 0"))
		%noway = 16;			
			
		
	DeleteObject(%object);
	DeleteObject(%camera);		
	if(%noway)
	{
		Client::sendMessage(%client,0,"An Airbase will not fit there. Error: "@%noway);
		return false;
	}
}

