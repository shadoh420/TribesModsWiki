$InvList[SurveyDroidPack] = 1;
$MobileInvList[SurveyDroidPack] = 1;
$RemoteInvList[SurveyDroidPack] = 1;

ItemImageData SurveyDroidPackImage
{	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData SurveyDroidPack
{	description = "Survey Droid";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = $InvHead[ihDro];
	shadowDetailMask = 4;
	imageType = SurveyDroidPackImage;
	mass = 0.5;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

FlierData SurveyDroid
{	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "camera";
	//shieldShapeName = "shield_medium";
	mass = 0.001;
	drag = 1.0;
	density = 1.2;
	maxBank = 7;
	maxPitch = 12.5;
	maxSpeed = 30;
	//maxSideSpeed = 100;
	minSpeed = -15;
	lift = 1.0;
	maxAlt = 50;
	maxVertical = 1;
	maxDamage = 0.25;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;
	groundDamageScale = 0.05; //0.001
	weaponType = 1;
	minEnergy = 5;
	maxEnergy = 7;
	repairRate = 0;
	//fireSound = SoundFireBlaster;
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
	description = "Survey Droid";
};

function SurveyDroidPack::onUse(%player,%item)
{	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function SurveyDroidPack::onDeploy(%player,%item,%pos)
{	if(DeploySurveyDroid(%player,%item,SurveyDroid,flier,SurveyDroid)) 
		if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

function SurveyDroid::onCollision(%this,%object)
{
}

function SurveyDroid::jump(%this,%mom)
{	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function SurveyDroid::onFire(%this,%slot)
{	%client = GameBase::getControlClient(%this);
	if($TeamItemCount[GameBase::getTeam(%this) @ CameraPack] < $TeamItemMax[CameraPack] && !%this.deployed)
	{	if(GameBase::getLOSInfo(%this,3))
		{	%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape")
			{	%this.deployed = true;
				//GameBase::startFadeOut(%this);
				%prot = GameBase::getRotation(%this);
				%zRot = getWord(%prot,2);
				
				if(Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
				else
				{	if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
					else %rot = Vector::getRotation($los::normal);
				}
				%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%this));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,$los::position);
				Gamebase::setMapName(%beacon,"Target Beacon");
				Beacon::onEnabled(%beacon);
				Client::sendMessage(%client,0,"Beacon deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
				echo("MSG: Survey Droid deployed a Beacon");
				SurveyDroid::removeDrone(%this);
			}
		}
	}
}

function SurveyDroid::removeDrone(%this)
{	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);

	Player::setMountObject(%player, -1, 0);
	Client::setControlObject(%client,%player);
	%player.vehicle = "";

	Client::sendMessage(%client,0,"Droid beacon deployed successfully");
 
	$TeamItemCount[GameBase::getTeam(%this) @ "SurveySurveyDroidPack"]--;
	GameBase::startFadeOut(%this);
	GameBase::applyDamage(%this,$ImpactDamageType,1,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function DeploySurveyDroid(%player,%item,%shape,%data,%name)
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
			GameBase::startFadeOut(%obj);
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