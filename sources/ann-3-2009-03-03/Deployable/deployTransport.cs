$InvList[TransportPack] = 1;
$MobileInvList[TransportPack] = 1;
$RemoteInvList[TransportPack] = 1;
AddItem(TransportPack);

ItemImageData TransportPackImage 
{
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.03, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData TransportPack 
{
	description = "Transport Vehicle"; 
	shapeFile = "ammounit_remote"; 
	className = "Backpack"; 
	heading = $InvHead[ihDOb]; 
	imageType = TransportPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 1600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
};

function TransportPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ "TransportVehicle"] >= $TeamItemMax[TransportVehicle] && !$build) 
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
	if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(!Vehicle::DeployArea(%player,"Transport",$los::position)) 
		return false;
	

	%rot = GameBase::getRotation(%player); 
	%objVehicle = newObject("",flier,Transport,true); 

	addToSet("MissionCleanup/deployed/object", %objVehicle); 
	
	GameBase::setTeam(%objVehicle,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objVehicle,$los::position); 
	GameBase::setRotation(%objVehicle,%rot); 
	Gamebase::setMapName(%objVehicle,"HPC Pack"); 
	Client::sendMessage(%client,0,"Deployed Transport"); 
	GameBase::startFadeIn(%objVehicle); 
	
	Vehicle::TerrainCheck(%objVehicle);
	playSound(SoundPickupBackpack,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "TransportVehicle"]++; 
	
		//plasmatic 2.2
		echo("MSG: "@Client::getName(%client)@", "@%client@" deployed a Transport Vehicle Pack "@Client::getTransportAddress(%client)); 
//	Vehicle::onCollision(%objVehicle, %player);	//3.0 Plasmatic
	return true; 
}
