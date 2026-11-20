// This is a MiniMod Plugin.
// This plugin is the GuardDog (Spotter) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    WatchdogTurret.ArmorData.cs
//    WatchdogTurret.baseProjData.cs
//    WatchdogTurret.item.cs
//    WatchdogTurret.reinitData.cs
//    WatchdogTurret.station.cs
//    WatchdogTurret.turret.cs
//
// to your MiniMod/plugins directory.

$TeamItemMax[WatchdogPack] = 4;

ItemImageData WatchdogImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData WatchdogPack
{
	description = "Watchdog";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = WatchdogImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function WatchdogPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WatchdogPack::onDeploy(%player,%item,%pos)
{
	if (WatchdogPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function WatchdogPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",DeployableWatchdog,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Watchdog#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Watchdog deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "WatchdogPack"]++;
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

	$TeamItemCount[0 @ WatchdogPack] = 0;
	$TeamItemCount[1 @ WatchdogPack] = 0;
	$TeamItemCount[2 @ WatchdogPack] = 0;
	$TeamItemCount[3 @ WatchdogPack] = 0;
	$TeamItemCount[4 @ WatchdogPack] = 0;
	$TeamItemCount[5 @ WatchdogPack] = 0;
	$TeamItemCount[6 @ WatchdogPack] = 0;
	$TeamItemCount[7 @ WatchdogPack] = 0;
