
FlierData Drone
{	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "camera";
	//shieldShapeName = "shield_medium";
	mass = 0.01;
	drag = 0.6;
	density = 0.3;
	maxBank = 5;
	maxPitch = 12.5;
	maxSpeed = 10;
	//maxSideSpeed = 10;
	minSpeed = -10;
	lift = 1.0;
	maxAlt = 30;
	maxVertical = 10;
	maxDamage = 0.25;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.6;
	groundDamageScale = 0.05; //0.001
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.001; //0.0001
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;
	visibleDriver = false;
	driverPose = 22;
	description = "Drone";
	deployed = false;
};

function DeployDrone(%player,%item,%shape,%data,%name)
{	%client = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,3))
	{	if(Vector::dot($los::normal,"0 0 1") > 0.7)
		{	%rot = GameBase::getRotation(%player);
			%obj = newObject(%name,%data,%shape,true);
			if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
			{	centerprint(%client,"<jc>Maximum number of "@%name@"s deployed.");
				deleteObject(%obj);
				return;
			}
			addToSet("MissionCleanup",%obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setPosition(%obj,$los::position);
			GameBase::setRotation(%obj,%rot);
			Gamebase::setMapName(%obj,%name);
			Client::sendMessage(%client,0,%name@" Deployed ");
			GameBase::startFadeIn(%obj);
			playSound(SoundPickupBackpack,$los::position);
			Client::setControlObject(%client,%obj);
			%player.vehicle = %obj;
			$TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
			return true;
		}
		else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
	}
	else Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

function Drone::onCollision (%this, %object)
{
}

function Drone::jump(%this,%mom)
{	GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function Drone::onFire(%this,%slot)
{	%client = GameBase::getControlClient(%this);
	if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
	{	if(GameBase::getLOSInfo(%this,3))
		{	%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape")
			{	%this.deployed = true;
				%prot = GameBase::getRotation(%this);
				%zRot = getWord(%prot,2);
				if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
				else
				{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
					else %rot = Vector::getRotation($los::normal);
				}
				//%camera = newObject("Camera","Turret",CameraTurret,true);
				addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%this));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,$los::position);
				Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Camera deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
				echo("MSG: Drone deployed a Camera");
				Drone::removeDrone(%this);
			}
		}
	}
}

function Drone::removeDrone(%this)
{	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);

	Player::setMountObject(%player, -1, 0);
	Client::setControlObject(%client,%player);
	%player.vehicle = "";

	Client::sendMessage(%client,0,"Drone camera deployed successfully");
 
	$TeamItemCount[GameBase::getTeam(%this) @ "DronePack"]--;
	GameBase::startFadeOut(%this);
	GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

