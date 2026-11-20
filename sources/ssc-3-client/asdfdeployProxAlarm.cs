//NOT USED YET-RSP
$TeamItemMax[ProxAlarm] = 2;
$InvList[ProxAlarm] = 1;
$RemoteInvList[ProxAlarm] = 1;

$CanAlwaysTeamDestroy[ProxAlarm] = 1;

 //-=-=-=-

function deployProxAlarm::Initialize()
{
  $TeamItemCount[0 @ ProxAlarm] = 0;
  $TeamItemCount[1 @ ProxAlarm] = 0;
  $TeamItemCount[2 @ ProxAlarm] = 0;
  $TeamItemCount[3 @ ProxAlarm] = 0;
  $TeamItemCount[4 @ ProxAlarm] = 0;
  $TeamItemCount[5 @ ProxAlarm] = 0;
  $TeamItemCount[6 @ ProxAlarm] = 0;
  $TeamItemCount[7 @ ProxAlarm] = 0;
}


//------------------------------------
// Proximity Detector
//------------------------------------
ItemImageData ProxAlarmImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ProxAlarm
{
   description = "Proximity Detector";
   shapeFile = "sensor_small";
   className = "Backpack";
   heading = $InvHead[ihDSe];
   shadowDetailMask = 4;
   imageType = ProxAlarmImage;
   mass = 2.0;
   elasticity = 0.2;
   price = 150;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function ProxAlarm::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ProxAlarm::onDeploy(%player,%item,%pos)
{
	if (ProxAlarm::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ProxAlarm::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if (GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		if (%obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
			if(checkDeployArea(%client,$los::position)) {
				%alarm = newObject("","StaticShape", "AlarmKit",true);
 	 			addToSet("MissionCleanup", %alarm);
				GameBase::setTeam(%alarm,GameBase::getTeam(%player));
				GameBase::setRotation(%alarm,%rot);
				GameBase::setPosition(%alarm,$los::position);
				Gamebase::setMapName(%alarm,%name);
				Gamebase::setMapName(%alarm,"Proximity Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++);
				Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
				$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;
				return true;
			}
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}

	return false;
}

