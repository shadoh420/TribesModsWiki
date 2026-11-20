//----------------------------------------------------------------------------
// Deployable Teleport Pack
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Global Definitions
//----------------------------------------------------------------------------
$ItemMax[spyarmor, TeleportJammer] = 1;
$ItemMax[spyfemale, TeleportJammer] = 1;
$ItemMax[iarmor, TeleportJammer] = 1;
$ItemMax[ifarmor, TeleportJammer] = 1;
$ItemMax[earmor, TeleportJammer] = 1;
$ItemMax[efemale, TeleportJammer] = 1;

// Link to number of Deployable Teleport Pads.
$TeamItemMax[TeleportJammer] = $TeamItemMax[DeployableTeleportPack];

$InvList[TeleportJammer] = 1;
$RemoteInvList[TeleportJammer] = 1;

$TPDisruptorDamageSet = newObject("Set",SimSet);
$TPDisruptorPulseSet = newObject("Set",SimSet);

//----------------------------------------------------------------------------
// Projectile Definitions
//----------------------------------------------------------------------------

GrenadeData TPDisruptorShell
{
   bulletShapeName    = "enex.dts";
   explosionTag       = energyExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.75;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.20;
   damageType         = $TeleFragDamageType;

   explosionRadius    = 40;
   kickBackStrength   = -250.0;
   maxLevelFlightDist = 15;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 3.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "enex.dts";
};

function TPDisruptorShell::onAdd(%this)
{
	addToSet($TPDisruptorDamageSet,%this);
}

function TPDisruptorShell::inflictDamage(%this)
{
	GameBase::applyRadiusDamage($TeleFragDamageType,getBoxCenter(%this),20,0.10,-150,-1);
}

//----------------------------------------------------------------------------
// Type Definitions
//----------------------------------------------------------------------------
ItemImageData TeleportJammerImage
{
	shapeFile = "sensor_jammer";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportJammer
{
	description = "Teleport Disruptor";
	shapeFile = "sensor_jammer";
	className = "Backpack";
	heading = "fDeployables";
	imageType = TeleportJammerImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportJammer::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TeleportJammer::onDeploy(%player,%item,%pos)
{
	%newObj = TeleportJammer::deployShape(%player,%item);
	if(%newObj) {
		Player::decItemCount(%player,%item);
		%interval = (getRandom() * 60) + 30;
		schedule("TeleportJammerPod::disrupt(" @ %newObj @ ");",%interval,%newObj);
	}
}

function TeleportJammer::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%target = $los::object;
			if(GameBase::getDataName(%target) == TeleportPad && GameBase::getTeam(%player) != GameBase::getTeam(%target)) {
				if(!%target.parasite) {
					%newObj = newObject("",StaticShape,TeleportJammerPod,true);
					$los::object.parasite = %newObj;
					%newObj.parasite = %target;
					GameBase::setPosition(%newObj,Vector::add(GameBase::getPosition(%target),Vector::getFromRot(Vector::add(GameBase::getRotation(%target),"0 0 1.5708"),1.85,1.75)));
					GameBase::setRotation(%newObj,Vector::add(GameBase::getRotation(%target),"1.5708 0 -1.5708"));
					addToSet("MissionCleanup", %newobj);
					GameBase::setTeam(%newobj,GameBase::getTeam(%player));
					Gamebase::setMapName(%newobj,%item.description);
					Client::sendMessage(%client,0,%item.description @ " deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
					echo("MSG: " @ %client @ " deployed a " @ %item.description);
					return %newObj;
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy one disruptor on a teleport pad.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on enemy teleport pads.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s.");

	return false;
}

StaticShapeData TeleportJammerPod
{
	description = "Teleport Disruptor";
	shapeFile = "sensor_jammer";
	className = "Misc";
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
	maxDamage = 0.5;
	visibleToSensor = false;
	mapFilter = 4;
	mapIcon = "M_sensorJammer";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

StaticShapeData TeleportDummy
{
	description = "Teleport Disruptor";
	shapeFile = "breath";
	className = "Misc";
	maxDamage = 10;
	visibleToSensor = false;
	isVisible = false;
};

function TeleportDummy::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
}

function TeleportJammerPod::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $TeleFragDamageType)
		%value *= 0.05;

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function TeleportJammerPod::onDestroyed(%this)
{
	%this.parasite.parasite = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "TeleportJammer"]--;
}

function TeleportJammerPod::disrupt(%this)
{
	%team = GameBase::getTeam(%this.parasite);

	%interval = (getRandom() * 60) + 30;
	schedule("TeleportJammerPod::disrupt(" @ %this @ ");",%interval,%this);

	%start = TeleportPad::findRandomPad(%team,%this.parasite,0);

	if(GameBase::getDamageState(%this) == "Enabled") {
		if(%start) {
			if(GameBase::getDamageState(%start) == "Enabled") {
				%dest = TeleportPad::findRandomPad(%team,%start,0);

				if(%dest != "") {
					GameBase::playSequence(%this,0,"power");

					TeleportPad::cleanUp(%start,%start.teleportLink);
					TeleportPad::cleanUp(%dest,%dest.teleportLink);

					%object = newObject("Teleport Disruptor",StaticShape,TeleportDummy,true);
					addToSet($TPDisruptorPulseSet,%start);
					schedule("deleteObject(" @ %object @ ");",5,%object);
					schedule("GameBase::stopSequence(" @ %this @ ",0);",5,%this);
					schedule("removeFromSet(" @ $TPDisruptorPulseSet @ "," @ %start @ ");", 5.0, %start);

					GameBase::setEnergy(%start,0);
					GameBase::setEnergy(%dest,0);
					GameBase::setRechargeRate(%start,0);
					GameBase::setRechargeRate(%dest,0);
					%start.passenger = %object;
					%dest.passenger = %object;
					%start.teleportLink = %dest;
					%dest.teleportLink = %start;
					%object.teleporting = 1;
					Item::setVelocity(%object,"0 0 0");
					GameBase::setPosition(%object,Vector::add(GameBase::getPosition(%start),"0 0 0.25"));
					TeleportPad::beginTeleport(%start,%object,%dest);
				}
			}
		}
	}
}

function TeleportJammerPod::generatePulse(%this)
{
	if(GameBase::getDamageState(%this) == "Enabled" && GameBase::getDamageState(%this.teleportLink) == "Enabled") {
		%trans = "0 0 0 " @ ((getRandom() * 2) - 1) @ " " @ ((getRandom() * 2) - 1) @ " 1 0 0 0 " @ getBoxCenter(%this);
		Projectile::spawnProjectile(TPDisruptorShell,%trans,-1,"0 0 0");

		%trans = "0 0 0 " @ ((getRandom() * 2) - 1) @ " " @ ((getRandom() * 2) - 1) @ " 1 0 0 0 " @ getBoxCenter(%this.teleportLink);
		Projectile::spawnProjectile(TPDisruptorShell,%trans,-1,"0 0 0");
	}
}

function TeleportJammerPod::manageSchedules()
{
	Group::iterateRecursive($TPDisruptorPulseSet,TeleportJammerPod::generatePulse);
	Group::iterateRecursive($TPDisruptorDamageSet,TPDisruptorShell::inflictDamage);
	schedule("TeleportJammerPod::manageSchedules();",0.5);
}
