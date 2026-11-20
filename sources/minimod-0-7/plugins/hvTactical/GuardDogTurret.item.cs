// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    GuardDogTurret.ArmorData.cs
//    GuardDogTurret.baseProjData.cs
//    GuardDogTurret.item.cs
//    GuardDogTurret.reinitData.cs
//    GuardDogTurret.station.cs
//    GuardDogTurret.turret.cs
//
// to your MiniMod/plugins directory.

$TeamItemMax[ConPack] = 2;

ItemImageData GuardDogImage //image name while a pack
{
	shapeFile = "remoteturret";//name of shape file, same as in turret.cs
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ConPack //ItemData name, used below in item.cs
{
	description = "Guard Dog";
	shapeFile = "remoteturret";//"chainturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = GuardDogImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ConPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ConPack::onDeploy(%player,%item,%pos)
{
	if (ConPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function ConPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableConTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableConTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableConTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Guard Dog#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Guard Dog deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ConPack"]++;
								echo("MSG: ",%client," deployed a Guard Dog");
						      Client::setOwnedObject(%client, %turret);
						      Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
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

	$TeamItemCount[0 @ ConPack] = 0;
	$TeamItemCount[1 @ ConPack] = 0;
	$TeamItemCount[2 @ ConPack] = 0;
	$TeamItemCount[3 @ ConPack] = 0;
	$TeamItemCount[4 @ ConPack] = 0;
	$TeamItemCount[5 @ ConPack] = 0;
	$TeamItemCount[6 @ ConPack] = 0;
	$TeamItemCount[7 @ ConPack] = 0;
