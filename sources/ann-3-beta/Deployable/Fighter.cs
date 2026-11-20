$InvList[FighterPack] = 1;
$MobileInvList[FighterPack] = 1;
$RemoteInvList[FighterPack] = 1;
AddItem(FighterPack);

ItemImageData FighterPackImage 
{
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FighterPack 
{
	description = "Fighter Vehicle Pack"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = FighterPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
};

function FighterPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "FighterPack"] >= $TeamItemMax[FighterPack] && !$build) 
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
	if(%obj != "SimTerrain" && %obj != "InteriorShape") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!Vehicle::DeployArea(%player,"Interceptor",$los::position)) 
		return false;		
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if(!%player.vehicle)
	{		
		%rot = GameBase::getRotation(%player); 
		%objVehicle = newObject("",flier,Interceptor,true); 

		addToSet("MissionCleanup/deployed/object", %objVehicle); 
		GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
		GameBase::setPosition(%objVehicle,$los::position); 
		GameBase::setRotation(%objVehicle,%rot); 
		Client::sendMessage(%client,0,"Piloting Interceptor..."); 
		GameBase::startFadeIn(%objVehicle); 
		Vehicle::TerrainCheck(%objVehicle);
		playSound(SoundPickupBackpack,$los::position); 
		$TeamItemCount[GameBase::getTeam(%player) @ "FighterPack"]++; 
		//plasmatic 2.2
		echo("MSG: "@Client::getName(%client)@", "@%client@" deployed a Fighter= "@ %objVehicle @", "@Client::getTransportAddress(%client)); 
				
		return true;
	}	

	
}

//function no longer used, was under-terrain checker -plasmatic
function deployFighter(%player,%item)
{
	%pPos	= GameBase::getPosition(%player);
	%tPos	= GameBase::getPosition(%player.terCheck);
	deleteobject(%player.terCheck);
	%AboveTerrain = (getWord(%pPos,2)+10 - getWord(%tPos,2)) >0;
	
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if(!%player.vehicle && %AboveTerrain)
	{	
		
		
		%rot = GameBase::getRotation(%player); 
		%objVehicle = newObject("",flier,Interceptor,true); 

		addToSet("MissionCleanup", %objVehicle); 
		GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
		GameBase::setPosition(%objVehicle,$los::position); 
		GameBase::setRotation(%objVehicle,%rot); 
		Client::sendMessage(%client,0,"Piloting Interceptor..."); 
		GameBase::startFadeIn(%objVehicle); 
		playSound(SoundPickupBackpack,$los::position); 
		$TeamItemCount[GameBase::getTeam(%player) @ "FighterPack"]++; 
		echo("MSG: ",%client," deployed a Fighter Vehicle Pack");
		if(!$build)Player::decItemCount(%player,%item);
	}	
	else
	{
		%rot = GameBase::getRotation(%player);
		if(!$build)Player::decItemCount(%player,%item);
		//Client::sendMessage(%client,0,"Cannot deploy below terrain.~wError_Message.wav");
		%obj = newObject("","Mine","Fighterbomb");
		Armor::ThrowGrenade(%player, %obj);
		GameBase::startFadeIn(%obj); 
		
		playSound(SoundPickupBackpack,$los::position); 
		
		%obj.time = 25;
		flierBombSound(%obj);
		GameBase::setRotation(%obj,%rot);
	}	
}

function flierBombSound(%obj)
{
	%BombPos = vector::add(GameBase::getPosition(%obj),"0 0 1");
	playSound(SoundFlyerBomb,%BombPos);
	%obj.time--;
	%rnd = (floor(getRandom() * 60) -30)/30;
	if(%obj.time>0)
		schedule("flierBombSound("@%obj@");",0.70 + %rnd);
	
}