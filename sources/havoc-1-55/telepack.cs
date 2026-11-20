//----------------------------------------------------------------------------
// Deployable Teleport Pack
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Global Definitions
//----------------------------------------------------------------------------
$ItemMax[earmor, DeployableTeleportPack] = 1;
$ItemMax[efemale, DeployableTeleportPack] = 1;

$TeamItemMax[DeployableTeleportPack] = 8;

$InvList[DeployableTeleportPack] = 1;
$RemoteInvList[DeployableTeleportPack] = 0;

//----------------------------------------------------------------------------
// Projectile Definitions
//----------------------------------------------------------------------------
ExplosionData TeleportSFXexp
{ 
	shapeName = "fusionex.dts"; 
	faceCamera = true; 
	randomSpin = true; 
	hasLight = false; 
	lightRange = 0.0; 
	timeScale = 5.05; 
	colors[0] = { 0.12, 0.12, 1.0 }; 
	colors[1] = { 0.12, 0.12, 1.0 }; 
	colors[2] = { 0.0, 0.0, 1.0 }; 
	radFactors = { 1.0, 1.0, 1.0 }; 
}; 

GrenadeData TeleportSFX
{ 
	bulletShapeName = "breath.dts"; 
	explosionTag = TeleportSFXexp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = 0; 
	damageType = $TeleFragDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 1; 
	totalTime = 0.05; 
	liveTime = 0.05; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
}; 

//----------------------------------------------------------------------------
// Type Definitions
//----------------------------------------------------------------------------
ItemImageData DeployableTeleportPackImage 
{
	shapeFile = "flagstand";
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
}; 

ItemData DeployableTeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "fDeployables";
	imageType = DeployableTeleportPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableTeleportPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableTeleportPack::onDeploy(%player,%item,%pos)
{
	%newObj = DeployableTeleportPack::deployShape(%player,%item);
	if(%newObj) {
		Player::decItemCount(%player,%item);

		%team = GameBase::getTeam(%newObj);
		%newObj.telePadLinkNum = $telePadNum[%team];
		$telePadNum[%team]++;
		addToSet($TeleportPads[%team],%newObj);

		%newObj.teleFXSet = newObject("set",SimSet);

		%pos = GameBase::getPosition(%newObj);
		%rot = GameBase::getRotation(%newObj);

		for(%i = 0; %i < 4; %i++)
			TeleportPad::createBeams(%newObj,%pos,Vector::add(%rot,"0 0 " @ (1.570796 * %i) + 0.785398));

		%newObj.passenger = "";
		GameBase::setEnergy(%newObj,0);
		GameBase::setRechargeRate(%newObj,10);

		%trig = newObject("",StaticShape,TeleportPadTrigger,true);

		GameBase::setPosition(%trig,Vector::add(GameBase::getPosition(%newObj),Vector::getFromRot(Vector::add(GameBase::getRotation(%newObj),"0 0 1.5708"),1.0,1.75)));
		GameBase::setRotation(%trig,Vector::add(GameBase::getRotation(%newObj),"1.5708 0 1.5708"));
		GameBase::setTeam(%trig,%team);
		GameBase::playSequence(%trig,0,"power");

		%trig.trigger = %newObj;
		%newObj.trigger = %trig;
	}
}

function DeployableTeleportPack::checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num || (%num == 1 && GameBase::getDataName(Group::getObject(%set,0)) == "AirAmmoBasePad")) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way.");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way.");
	}
	else 
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way.");

	deleteObject(%set);
	return 0;	
}

function DeployableTeleportPack::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%target = $los::object;
			%obj = getObjectType(%target);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName(%target) == "AirAmmoBasePad") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(DeployableTeleportPack::checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%newobj = newObject("",StaticShape,TeleportPad,true);
						addToSet("MissionCleanup", %newobj);
						GameBase::setTeam(%newobj,GameBase::getTeam(%player));
						GameBase::setPosition(%newobj,$los::position);
						GameBase::setRotation(%newobj,%rot);
						Gamebase::setMapName(%newobj,%item.description);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
						echo("MSG: " @ %client @ " deployed a " @ %item.description);
						return %newObj;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s.");

	return false;
}

StaticShapeData TeleportPad
{
	description = "Teleport Pad";
	shapeFile = "enerpad";
	className = "Misc";
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
	maxDamage = 1.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	maxEnergy = 200;
};

StaticShapeData TeleportPadTrigger
{
	shapeFile = "sensor_small";
	className = "Misc";
	maxDamage = 1.0;
	visibleToSensor = false;
	damageSkinData = "objectDamageSkins";
};

function TeleportPadTrigger::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
}

function TeleportPadTrigger::onCollision(%this,%object)
{
	TeleportPad::setupTeleport(%this.trigger,%object);
}

function TeleportPad::onCollision(%this,%object)
{
	if(%this.passenger && %object != %this.passenger && getObjectType(%object) == "Player") {
		Player::blowUp(%this.passenger);
		Player::onDamage(%object,$TeleFragDamageType,100,"0 0 0","0 0 0","0 0 0","torso","middle_middle",%this);
	}
}

function TeleportPad::setupTeleport(%this,%object)
{
	if(%object.teleporting)
		return;

	%team = GameBase::getTeam(%this);
	%client = GameBase::getOwnerClient(%object);
	%armor = Player::getArmor(%object);
	%pack = Player::getMountedItem(%object,$BackPackSlot);

	%enCost = (%armor.mass + %pack.mass) / 4;
	if(%this.freeP) 
		%enCost = pow((%enCost / 2),2);
	else
		%enCost = pow(%enCost,2);

	if(GameBase::getTeam(%object) != %team && (%armor == "spyarmor" || %armor == "spyfemale" || %armor == "earmor" || %armor == "efemale" || %armor == "iarmor" || %armor == "ifarmor"))
		%phasing = true;
	else
		%phasing = "";

	if(%this.passenger && %object != %this.passenger && getObjectType(%object) == "Player") {
		Player::blowUp(%this.passenger);
		Player::onDamage(%object,$TeleFragDamageType,100,"0 0 0","0 0 0","0 0 0","torso","middle_middle",%this);
	}
	else if(!%client.teleportAttempt && getObjectType(%object) == "Player") {
		if(GameBase::getTeam(%object) == %team || %phasing) {
			if(GameBase::getDamageState(%this) == "Enabled") {
				%dest = TeleportPad::findNextPad(%team,%this,%enCost);

				if(%dest != "") {
					%enDist = floor(Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%dest)) / 20);

					if(GameBase::getEnergy(%this) >= (%enCost * %enDist)) {
						if(%phasing)
							Client::sendMessage(%client,1,"Phasing through enemy teleporter.");

						GameBase::playSound(%this,ForceFieldOpen,3);
						GameBase::playSound(%dest,ForceFieldOpen,3);
						GameBase::setEnergy(%this,GameBase::getEnergy(%this) - (%enCost * %enDist));
						GameBase::setEnergy(%dest,GameBase::getEnergy(%dest) - (%enCost * %enDist));
						GameBase::setRechargeRate(%this,0);
						GameBase::setRechargeRate(%dest,0);
						%this.passenger = %object;
						%dest.passenger = %object;
						%this.teleportLink = %dest;
						%dest.teleportLink = %this;
						%object.teleporting = 1;
						%client.teleportAttempt = true;
						schedule(%client @ ".teleportAttempt = false;",10);
						Client::setControlObject(%client, Client::getObserverCamera(%client));
					        Observer::setOrbitObject(%client, %this, 3, 3, 3);
						Item::setVelocity(%object,"0 0 0");
						GameBase::setPosition(%object,Vector::add(GameBase::getPosition(%this),"0 0 0.25"));
						TeleportPad::beginTeleport(%this,%object,%dest);
					}
					else {
						if(!%client.teleportAttempt) {
							%client.teleportAttempt = true;
							schedule(%client @ ".teleportAttempt = false;",5);
							Client::sendMessage(%client,0,"Unit is recharging.~waccess_denied.wav");
						}
					}
				}
				else {
					if(!%client.teleportAttempt) {
						%client.teleportAttempt = true;
						schedule(%client @ ".teleportAttempt = false;",5);
						Client::sendMessage(%client,0,"No available pads to teleport to.~waccess_denied.wav");
					}
				}
			}
			else {
				if(!%client.teleportAttempt) {
					%client.teleportAttempt = true;
					schedule(%client @ ".teleportAttempt = false;",5);
					Client::sendMessage(%client,0,"Unit is disabled.~waccess_denied.wav");
				}
			}
		}
		else {
			if(!%client.teleportAttempt) {
				%client.teleportAttempt = true;
				schedule(%client @ ".teleportAttempt = false;",5);
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team.~waccess_denied.wav");
			}
		}
	}
}

function TeleportPad::beginTeleport(%this,%object,%dest)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);

	for(%i = 0; %i < 4; %i++)
		schedule("TeleportPad::createSFX(" @ %this @ ",\"" @ escapeString(%pos) @ "\",\"" @ escapeString(Vector::add(%rot,"0 0 " @ (1.570796 * %i))) @ "\");",0.00,%this);

	%pos = GameBase::getPosition(%dest);
	%rot = GameBase::getRotation(%dest);

	for(%i = 0; %i < 4; %i++)
		schedule("TeleportPad::createSFX(" @ %dest @ ",\"" @ escapeString(%pos) @ "\",\"" @ escapeString(Vector::add(%rot,"0 0 " @ (1.570796 * %i))) @ "\");",2.45,%dest);

	if(%object != %this)
		Group::iterateRecursive(%this.teleFXSet, TeleportBeam::Hide,"");
	Group::iterateRecursive(%dest.teleFXSet, TeleportBeam::Hide,"");

	if(%object != %this)
		Group::iterateRecursive(%this.teleFXSet, GameBase::startFadeIn);
	Group::iterateRecursive(%dest.teleFXSet, GameBase::startFadeIn);

	if(%object != %this)
		GameBase::startFadeOut(%object);
	else
		GameBase::startFadeOut(%this);

	schedule("TeleportPad::teleportObject(" @ %this @ "," @ %object @ "," @ %dest @ ");",2.5);
}

function TeleportPad::teleportObject(%this,%object,%dest)
{
	%client = GameBase::getOwnerClient(%object);

	if((GameBase::getDamageState(%this) == "Enabled" || %object == %this) && GameBase::getDamageState(%dest) == "Enabled") {
	        Observer::setOrbitObject(%client, %dest, 3, 3, 3);

		Item::setVelocity(%object,"0 0 0");
		GameBase::setPosition(%object,Vector::add(GameBase::getPosition(%dest),Vector::getFromRot(Vector::add(GameBase::getRotation(%dest),"0 0 1.5708"),-0.5,0.5)));
		GameBase::startFadeIn(%object);

		if(%object != %this)
			Group::iterateRecursive(%this.teleFXSet, GameBase::startFadeOut);
		Group::iterateRecursive(%dest.teleFXSet, GameBase::startFadeOut);

		if(%this.parasite || %dest.parasite) {
			Player::blowUp(%this.passenger);
			Player::onDamage(%this.passenger,$TeleFragDamageType,100,"0 0 0","0 0 0","0 0 0","torso","middle_middle",%this);
		}

		GameBase::playSound(%this,ForceFieldClose,3);
		GameBase::playSound(%dest,ForceFieldClose,3);

		schedule("TeleportPad::finishTeleport(" @ %this @ "," @ %object @ "," @ %dest @ ");",2.5);
	}
}

function TeleportPad::finishTeleport(%this,%object,%dest)
{
	%client = GameBase::getOwnerClient(%object);

	if(!Player::isDead(%object)) {
		Client::setControlObject(%client, %object);
		if(%object == %this)
			GameBase::setRechargeRate(%this,8);
	}

	%this.passenger = "";
	%dest.passenger = "";

	%object.teleporting = "";

	if(%object != %this)
		TeleportPad::cleanUp(%this,%dest);
	else
		TeleportPad::cleanUp(0,%dest);
}

function TeleportPad::cleanUp(%this,%dest)
{
	if(%this.passenger) {
		%this.passenger.teleporting = "";
		Player::blowUp(%this.passenger);
		Player::onDamage(%this.passenger,$TeleFragDamageType,100,"0 0 0","0 0 0","0 0 0","torso","middle_middle",%this);
	}

	Group::iterateRecursive(%this.teleFXSet,TeleportBeam::Hide,"True");
	Group::iterateRecursive(%dest.teleFXSet,TeleportBeam::Hide,"True");

	%this.teleportLink = "";
	%this.passenger = "";

	%dest.teleportLink = "";
	%dest.passenger = "";

	if(GameBase::getDamageState(%this) == "Enabled")
		GameBase::setRechargeRate(%this,10);
	if(GameBase::getDamageState(%dest) == "Enabled")
		GameBase::setRechargeRate(%dest,10);
}

function TeleportPad::createBeams(%this,%pos,%rot)
{
	%newObj = newObject("",StaticShape,ElectricalBeam,"");

	GameBase::setPosition(%newObj,Vector::add(%pos,Vector::getFromRot(%rot,2)));
	GameBase::setRotation(%newObj,GameBase::getRotation(%this));
	addToSet(%this.teleFXSet, %newObj);

	TeleportBeam::Hide(%newObj,True);
}

function TeleportPad::createSFX(%this,%pos,%rot)
{
	%vel = Item::getVelocity(%this);
	%trans = "0 0 1 0 0 0 0 0 1 " @ Vector::add(%pos,Vector::getFromRot(%rot,2,2)); 
	Projectile::spawnProjectile(TeleportSFX,%trans,%this.passenger,%vel,%this.passenger); 
}

function TeleportPad::deleteBeams(%this)
{
	%group = getGroup(%this);

	schedule("removeFromSet(" @ %group @ "," @ %this @ ");",0.5);
	schedule("deleteObject(" @ %this @ ");",0.5);
}

function TeleportPad::onEnabled(%this)
{
	GameBase::playSequence(%this.trigger,0,"power");
	GameBase::setRechargeRate(%this,10);
}

function TeleportPad::onDisabled(%this)
{
	GameBase::stopSequence(%this.trigger,0);
	GameBase::setEnergy(%this,0);
	GameBase::setRechargeRate(%this,0);

	if(%this.teleportLink)
		TeleportPad::cleanUp(%this,%this.teleportLink);
}

function TeleportPad::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $TeleFragDamageType)
		%value *= 0.1;

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function TeleportPad::onDestroyed(%this)
{
	if(%this.teleportLink)
		TeleportPad::cleanUp(%this,%this.teleportLink);

	Group::iterateRecursive(%this.teleFXSet, TeleportPad::deleteBeams);
	schedule("deleteObject(" @ %this.teleFXSet @ ");",0.05);

	%team = GameBase::getTeam(%this);
	removeFromSet($TeleportPads[%team],%this);

	schedule("deleteObject(" @ %this.trigger @ ");",0.1,%this.trigger);
	schedule("deleteObject(" @ %this.parasite @ ");",0.1,%this.parasite);

  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleportPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 1.5, 10, 50, 9, 3, 15.0, 5.0, 300, 200); 
}

function TeleportPad::findNextPad(%team,%this,%enCost)
{
	%retPad = "";
	%retVal = "";
	%minPad = "";
	%minVal = "";

	%thisNum = %this.telePadLinkNum;

	for(%i = 0; %i < Group::objectCount($TeleportPads[%team]); %i++) {
		%pad = Group::getObject($TeleportPads[%team],%i);
		%padNum = %pad.telePadLinkNum;
		%enDist = floor(Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%pad)) / 20);

		if(GameBase::getDamageState(%pad) == "Enabled" && GameBase::getEnergy(%pad) >= (%enCost * %enDist) && %padNum != %thisNum) {
			if(%padNum > %thisNum) {
				if(%padNum < %retVal || %retVal == "") {
					%retPad = %pad;
					%retVal = %padNum;
				}
			}
			else {
				if(%padNum < %minVal || %minVal == "") {
					%minPad = %pad;
					%minVal = %padNum;
				}
			}
		}
	}

	if(%retVal == "")
		%retPad = %minPad;

	return %retPad;
}

function TeleportPad::findClosestPad(%team,%this,%enCost)
{
	%retPad = "";
	%retVal = "";

	for(%i = 0; %i < Group::objectCount($TeleportPads[%team]); %i++) {
		%pad = Group::getObject($TeleportPads[%team],%i);
		%enDist = floor(Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%pad)) / 20);
		echo(%enDist);

		if(GameBase::getDamageState(%pad) == "Enabled" && GameBase::getEnergy(%pad) >= (%enCost * %enDist) && %pad != %this) {
			if(%enDist < %retVal || %retVal == "") {
				%retPad = %pad;
				%retVal = %enDist;
			}
		}
	}


	return %retPad;
}

function TeleportPad::findRandomPad(%team,%this,%enCost)
{
	%set = newObject("Set",SimSet);

	for(%i = 0; %i < Group::objectCount($TeleportPads[%team]); %i++) {
		%pad = Group::getObject($TeleportPads[%team],%i);
		%enDist = floor(Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%pad)) / 20);

		if(GameBase::getDamageState(%pad) == "Enabled" && GameBase::getEnergy(%pad) >= (%enCost * %enDist) && %pad != %this)
			addToSet(%set,%pad);
	}

	if(Group::objectCount(%set)) {
		%retPad = Group::getObject(%set,floor(getRandom() * Group::objectCount(%set)));
	}
	else
		%retPad = "";

	deleteObject(%set);

	return %retPad;
}

function TeleportBeam::hide(%this,%bool)
{
	if(%bool && !%this.hidden)
		GameBase::setPosition(%this,Vector::sub(GameBase::getPosition(%this),"0 0 1000"));

	if(!%bool && %this.hidden)
		GameBase::setPosition(%this,Vector::add(GameBase::getPosition(%this),"0 0 1000"));

	%this.hidden = %bool;
}
