


ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "bArmor Items";
   shadowDetailMask = 4;
   price = 35;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "bArmor Items";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","AntiEnemyMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "bArmor Items";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			%armor = Player::getArmor(%player); 
			if (%armor == "sarmor" || %armor == "sfemale"){
				%obj = newObject("","Mine","Firebomb");
			}
			if (%armor == "sparmor" || %armor == "spfemale"){
				%obj = newObject("","Mine","Nukebomb");
				Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds"); 
			}
			if (%armor == "sniparmor" || %armor == "snipfemale"){
				%obj = newObject("","Mine","HoloMine");
			}
			if (%armor == "mercarmor" || %armor == "mercfemale" || %armor == "duelarmor" || %armor == "duelfemale"){
				%obj = newObject("","Mine","Handgrenade");
			}
			if (%armor == "engarmor" || %armor == "engfemale"){
				%obj = newObject("","Mine","Shockgrenade");
			}
			if (%armor == "flagarmor" || %armor == "flagfemale"){
				%obj = newObject("","Mine","Tranqgrenade");
			}
			if (%armor == "barmor" || %armor == "bfemale"){
				%obj = newObject("","Mine","Concussion");
			}
			if (%armor == "darmor"){
				%obj = newObject("","Mine","Mortarbomb");
			}
			Player::decItemCount(%player,%item);
			//%obj = newObject("","Mine","%grenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "bArmor Items";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};


function Beacon::onUse(%player,%item) 
{ 
%armor = Player::getArmor(%player); 
%clientId = Player::getClient(%player);
%beacon = %item; 
	if (%armor == "sniparmor" || %armor == "snipfemale"){ 
		if(!$BuilderMode){
			%name = "Sensor Jammer#" @ $totalNumSensorJammers[%clientId]++;
			%shape = DeployableSensorJammer;
			%item = DeployableSensorJammerPack;
			%type = "Sensor";
			if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)){
				Player::decItemCount(%player,%beacon);
				$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
			}
		}
		else if($BuilderMode){
			%name = "Inventory Station#" @ $totalNumInventoryStations[%clientId]++;
			%shape = DeployableInvStation;
			%item = DeployableInvPack;
			if (DeployableStation::deployShape(%player,%name,%shape,%item)){
				//Player::decItemCount(%player,%beacon);
				//$TeamItemCount[GameBase::getTeam(%player) @ "DeployableInvPack"]++;
			}
		} 
	} 
	if(%armor == "engarmor" || %armor == "engfemale"){ 
		if(!$BuilderMode){
			%name = "Motion Sensor#" @ $totalNumMotionSensors[%clientId]++;
			%shape = DeployableMotionSensor;
			%item = MotionSensorPack;
			%type = "Sensor";
			if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)){
				Player::decItemCount(%player,%beacon);
				$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
			}
		}
		else if($BuilderMode){
			%name = "Inventory Station#" @ $totalNumInventoryStations[%clientId]++;
			%shape = DeployableInvStation;
			%item = DeployableInvPack;
			if (DeployableStation::deployShape(%player,%name,%shape,%item)){
				//Player::decItemCount(%player,%beacon);
				//$TeamItemCount[GameBase::getTeam(%player) @ "DeployableInvPack"]++;
			}
		}
	} 
	if (%armor == "sarmor" || %armor == "sfemale"){ 
		if(!$BuilderMode){
			%name = "Pulse Sensor#" @ $totalNumPulseSensors[%clientId]++;
			%shape = DeployablePulseSensor;
			%item = PulseSensorPack;
			%type = "Sensor";
			if (DeployableSensor::deployShape(%player,%name,%shape,%item,%type)){
				Player::decItemCount(%player,%beacon);
				$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
			}
		}
		else if($BuilderMode){
			%name = "Inventory Station#" @ $totalNumInventoryStations[%clientId]++;
			%shape = DeployableInvStation;
			%item = DeployableInvPack;
			if (DeployableStation::deployShape(%player,%name,%shape,%item)){
				//Player::decItemCount(%player,%beacon);
				//$TeamItemCount[GameBase::getTeam(%player) @ "DeployableInvPack"]++;
			}
		} 
	} 
	if (%armor == "sparmor" || %armor == "spfemale"){ 
		DeploySatchel(%clientId, %player, %item); 
	} 
	if (%armor == "mercarmor" || %armor == "mercfemale" || %armor == "duelarmor" || %armor == "duelfemale"){ 
		if($matchStarted){ 
			if(%player.throwTime < getSimTime()){ 
				%obj = newObject("","Mine","Booster"); 
				addToSet("MissionCleanup", %obj); 
				%client = Player::getClient(%player); 
				GameBase::throw(%obj,%player,15 * %client.throwStrength,false); 
				%player.throwTime = getSimTime() + 0.5; 
				Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); 
				Player::decItemCount(%player,%item); 
			} 
		} 
	} 
	if (%armor == "flagarmor" || %armor == "flagfemale"){ 
		Renegades_startCloak(%clientId, %player); 
		Player::decItemCount(%player,%item); 
	} 
	if (%armor == "barmor" || %armor == "bfemale"){ 
		Renegades_startStim(%clientId, %player); 
		Player::decItemCount(%player,%item); 
	} 
	if (%armor == "darmor"){ 
		Renegades_startShield(%clientId, %player); 
		Player::decItemCount(%player,%item); 
	}
} 





//function SuicidePack::deployShape(%player,%item) 
//	{ 
//	Player::unmountItem(%player,$BackpackSlot); 
//	%obj = newObject("","Mine","Suicidebomb2"); 
//	addToSet("MissionCleanup", %obj); 
//	%client = Player::getClient(%player); 
//	GameBase::throw(%obj,%player,3 * %client.throwStrength,false); 
//	Client::sendMessage(%client,1,"Det Pack will destruct in 10 seconds"); 
//	} 
//%obj = newObject("","Mine","Mortarbomb");
//			Player::decItemCount(%player,%item);
			//%obj = newObject("","Mine","%grenade");
// 	 	 	addToSet("MissionCleanup", %obj);
//			%client = Player::getClient(%player);
//			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
//			%player.throwTime = getSimTime() + 0.5;


function Renegades_startStim(%clientId, %player) 
{
%obj = newObject("","Mine","Firebomb2");
			Player::decItemCount(%player,%item);
			//%obj = newObject("","Mine","%grenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,8,false);
			%player.throwTime = getSimTime() + 0.5;
} 

function checkPlayerStim(%clientId, %player) 
{ 
	if($StimTime[%clientId] > 0){ 
		$StimTime[%clientId] -= 2; 
		if (!Player::isDead(%player)){
		} 
		else{ 
			$StimTime[%clientId] = 0; 
			%armor.maxForwardSpeed = 9;
			%armor.maxBackwardSpeed = 9;
		} 
		schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	else{ 
		Client::sendMessage(%clientId,0,"......and so I just kept on running"); 
		%armor = Player::getArmor(%player); 
		%armor.maxForwardSpeed = 10;
		%armor.maxBackwardSpeed = 10;
	} 
} 








function Renegades_startShield(%clientId, %player) 
{ 
Client::sendMessage(%clientId,0,"Emergency Force Shields Activated"); 
GameBase::playSound(%player,ForceFieldOpen,0); 
%player.shieldStrength = 0.006; 
	if($shieldTime[%clientId] == 0){ 
		$shieldTime[%clientId] = 20; 
		checkPlayerShield(%clientId, %player); 
	} 
	else 
		$shieldTime[%clientId] = 20; 
} 

function checkPlayerShield(%clientId, %player) 
{ 
%armor = Player::getArmor(%player); 
	if($shieldTime[%clientId] > 0){ 
		$shieldTime[%clientId] -= 2; 
		if ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale")){ 
			if (Player::isDead(%player)){ 
			} 
		} 
		else{ 
			$shieldTime[%clientId] = 0; 
		} 
	schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	else{ 
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted"); 
		%player.shieldStrength = 0; 
		GameBase::playSound(%player,ForceFieldOpen,0); 
	} 
} 





function Renegades_startCloak(%clientId, %player) 
{ 
%armor = Player::getArmor(%player); 
Client::sendMessage(%clientId,0,"Cloaking On"); 
GameBase::playSound(%player,ForceFieldOpen,0); 
GameBase::startFadeout(%player); 
%rate = Player::getSensorSupression(%player) + 3; 
Player::setSensorSupression(%player,%rate); 
	if($cloakTime[%clientId] == 0){ 
		$cloakTime[%clientId] = 30; 
		checkPlayerCloak(%clientId, %player); 
	} 
	else 
		$cloakTime[%clientId] = 30; 
} 

function checkPlayerCloak(%clientId, %player) 
{ 
%armor = Player::getArmor(%player); 
	if($cloakTime[%clientId] > 0){ 
		$cloakTime[%clientId] -= 2; 
		if ((!Player::isDead(%player)) && (%armor == "flagarmor" || %armor == "flagfemale")){ 
		} 
		else{ 
			$cloakTime[%clientId] = 0; 
		} 
	schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	else{ 
		Client::sendMessage(%clientId,0,"Cloaking Off"); 
		GameBase::playSound(%player,ForceFieldOpen,0); 
		GameBase::startFadein(%player); 
		%rate = Player::getSensorSupression(%player) - 5; 
		Player::setSensorSupression(%player,0); 
	} 
} 





//{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{
//:::::::::::::::::::::::::::  SATCHEL  CHARGE  :::::::::::::::::::::::::::::::::::::::::
//}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}


function DeploySatchel( %clientId, %player, %bec) 
{ 
%item = "SatchelPack"; 
%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]){ 
		if (GameBase::getLOSInfo(%player,10000)){ 
			%obj = getObjectType($los::object); 
			%prot = GameBase::getRotation(%player); 
			%zRot = getWord(%prot,2); 
			if (Vector::dot($los::normal,"0 0 1") > 0.6){ 
				%rot = "0 0 " @ %zRot; 
			} 
			else{ 
				if (Vector::dot($los::normal,"0 0 -1") > 0.6){ 
					%rot = "3.14159 0 " @ %zRot; 
				} 
				else{ 
					%rot = Vector::getRotation($los::normal); 
				} 
			} 
			%camera = newObject("Camera","Turret",DeployableSatchel,true); 
			addToSet("MissionCleanup", %camera); 
			GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
			GameBase::setRotation(%camera,%rot); 
			GameBase::setPosition(%camera,$los::position); 
			Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); 
			Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen."); 
			playSound(SoundPickupBackpack,$los::position); 
			$TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++; 
			echo("MSG: ",%client," deployed a Satchel Charge."); Player::decItemCount(%player,%bec); 
			return true; 
		} 
		else{ 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	} 
	else 
		Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges"); 
return false; 
} 




















//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "bArmor Items";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}









