// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.

$TeamItemMax[ChaingunTurretPack] = 3;

ItemImageData ChaingunTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ChaingunTurretPack
{
        description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
        imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
        price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ChaingunTurretPack::onDeploy(%player,%item,%pos)
{
        if (ChaingunTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function ChaingunTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
	    			%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}

                              %turret = newObject("remoteTurret","Turret",DeployableChaingun,true);
                              addToSet("MissionCleanup", %turret);
		  GameBase::setTeam(%turret,GameBase::getTeam(%player));
		  GameBase::setPosition(%turret,$los::position);
		  GameBase::setRotation(%turret,%rot);
                              Gamebase::setMapName(%turret,"RMT Chaingun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                              Client::sendMessage(%client,0,"Remote Chaingun Turret deployed");
		  playSound(SoundPickupBackpack,$los::position);
                              $TeamItemCount[GameBase::getTeam(%player) @ "ChaingunTurretPack"]++;
                              echo("MSG: ",%client," deployed a Remote Chaingun Turret");
					//	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
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



	$TeamItemCount[0 @ ChaingunTurretPack] = 0;
	$TeamItemCount[1 @ ChaingunTurretPack] = 0;
	$TeamItemCount[2 @ ChaingunTurretPack] = 0;
	$TeamItemCount[3 @ ChaingunTurretPack] = 0;
	$TeamItemCount[4 @ ChaingunTurretPack] = 0;
	$TeamItemCount[5 @ ChaingunTurretPack] = 0;
	$TeamItemCount[6 @ ChaingunTurretPack] = 0;
	$TeamItemCount[7 @ ChaingunTurretPack] = 0;
