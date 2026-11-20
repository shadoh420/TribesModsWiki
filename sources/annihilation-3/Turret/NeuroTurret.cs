// Neuro Basher Image, code and name,
// copywrite June 2003 plasmatic aka Steve Madden.
// ziptiezmail@netscape.net


$InvList[NeuroTurretPack] = 1;
$MobileInvList[NeuroTurretPack] = 1;
$RemoteInvList[NeuroTurretPack] = 1;
AddItem(NeuroTurretPack);
$TeamItemMax[NeuroTurretPack] = 2;	//4;

$CanControl[NeuroTurret] = 0;
$CanAlwaysTeamDestroy[NeuroTurret] = 1;

ItemImageData NeuroTurretPackImage 
{
	shapeFile = "mortargun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 1.57, 0, 0 };

	firstPerson = false;
};

ItemData NeuroTurretPack 
{
	description = "Neuro Basher";
	shapeFile = "mortargun";
	className = "Backpack";
	
	heading = $InvHead[ihTur];
	imageType = NeuroTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData Neurobase
{
	description = "Neuro Basher";
	shapeFile = "mine";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
};

function Neurobase::onDestroyed(%this)
{
	%this.cloakable = "";
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	GameBase::setDamageLevel(%this.turret, 1.6);
	GameBase::setDamageLevel(%this.cannon, 1.6);
}


StaticShapeData NeuroCannon
{
	description = "Neuro Basher";
	shapeFile = "mortargun";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
};

function NeuroCannon::onDestroyed(%this)
{
	%this.cloakable = "";
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
	GameBase::setDamageLevel(%this.turret, 1.6);
	GameBase::setDamageLevel(%this.base, 1.6);
}

// realy short lived bullet...
BulletData NeuroBullet
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "bullet.dts";
	validateShape = true;
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $BulletDamageType;
	aimDeflection = 0.005;
	muzzleVelocity = 1.0;
	totalTime = 0.01;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 2.0;
	tracerLength = 30;
};

TurretData NeuroTurret
{
	className = "SelfPoweredTurret";
	shapeFile = "camera";
	projectileType = NeuroBullet;	//MortarTurretShell;
	maxDamage = 1.5;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 15;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 2;
	speed = 2;
	speedModifier = 1.0;	//1.5
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
//	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = LargeShockwave;
	description = "Neuro Turret";
	damageSkinData = "objectDamageSkins";
};

function NeuroTurret::onAdd(%this) 
{
	schedule("NeuroTurret::deploy(" @ %this @ ");",1,%this);
	
	%this.shieldStrength = 0.005;
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Mortar Turret");
}

function NeuroTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function NeuroTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function NeuroTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "NeuroTurretPack"]--;
	GameBase::setDamageLevel(%this.base, 1.6);
	GameBase::setDamageLevel(%this.cannon, 1.6);
}

function NeuroTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
}

function NeuroTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3.5))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(GameBase::getLOSInfo(%player,1.0))
	{
		Client::sendMessage(%client,0,"Deploy position is too close");
		return false;
	}
	%deployPosition = $los::position;
// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
		
	if(getNumTeams()-1 == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, %deployPosition)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}
	%obj = getObjectType($los::object);
	if(%obj != "InteriorShape" && %obj != "SimTerrain")
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return false;
	}
	
//check ceiling  -plasmatic	
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,Vector::add(%deployPosition,"0 0 2"));
	if(GameBase::getLOSInfo(%camera,35,"1.5708 0 0"))
	{
		%name = GameBase::getDataName($los::object);
	
		
		if(!%name) 
			%name = getObjectType($los::object);
		if($los::object == %player)
			Client::sendMessage(%client,0,"You are in the way.");	
		else		
			Client::sendMessage(%client,0,%name@" in way, "@Vector::getDistance($los::position, GameBase::getPosition(%camera))@" meters up.");
		DeleteObject(%camera);
		return false;			
	}
	else DeleteObject(%camera);	

	%set = newObject("set",SimSet);
	%Mask = $StaticObjectType;
	%num = containerBoxFillSet(%set, $StaticObjectType, %deployPosition, 70, 70, 70, 0);//x,y,height
	%num = CountObjects(%set, "NeuroTurret", %num);
	deleteObject(%set);
	if(%num) 
	{	
		Client::sendMessage(%client,0,"Frequency Overload - Too close to another Neuro Turret");
		return;
	}
	if(Vector::dot($los::normal,"0 0 1") <= 0.7)
	{
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}
	if(!checkInvDeployArea(%client,%deployPosition))
	{
		Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
		return false;
	}
	%rot = GameBase::getRotation(%player);
	%cannon = newObject("Neuro cannon","StaticShape",NeuroCannon,true);
	%cannon.cloakable = true;
	addToSet("MissionCleanup/deployed/turret", %cannon);
	GameBase::setTeam(%cannon,GameBase::getTeam(%player));
	GameBase::setPosition(%cannon,vector::add(%deployPosition,Vector::neg(Vector::getFromRot(%rot, 0.05,-0.7))));
	GameBase::setRotation(%cannon,vector::add(%rot,"0.999914 6.9126e-06 -4.6849e-05"));
	Gamebase::setMapName(%cannon,"Neuro Basher: " @ Client::getName(%client));
	%cannon.aim = Vector::getFromRot(%rot, 0.6,0.7);

	%base = newObject("Neuro Turret Base","StaticShape",Neurobase,true);
	%base.cloakable = true;
	addToSet("MissionCleanup/deployed/turret", %base);
	GameBase::setTeam(%base,GameBase::getTeam(%player));
	GameBase::setPosition(%base,%deployPosition);
	GameBase::setRotation(%base,%rot);
	Gamebase::setMapName(%base,"Neuro Basher: " @ Client::getName(%client));

	%turret = newObject("Neuro Turret","Turret",NeuroTurret,true);
	GameBase::setRechargeRate(%turret,7);
	%turret.cloakable = true;
	addToSet("MissionCleanup/deployed/turret", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,%deployPosition);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Neuro Basher: " @ Client::getName(%client));
	$TurretList[%turret] = %client;	//we're going to disable when client changes team or drops -plasmatic 2.2

	%cannon.base = %base;
	%cannon.turret = %turret;
	
	%base.turret = %turret;
	%base.cannon = %cannon;
	
	%turret.base = %base;
	%turret.cannon = %cannon;

	$turret::count++;
	%obj.deployer = %client;
	Client::sendMessage(%client,0,"Neuro Turret deployed");
	playSound(SoundPickupBackpack,%deployPosition);
	$TeamItemCount[GameBase::getTeam(%player) @ "NeuroTurretPack"]++;
	echo("MSG: ",%client," deployed a Neuro Turret");
	//	Remote turrets - kill points to player that deploy them
	Client::setOwnedObject(%client, %turret);
	Client::setOwnedObject(%client, %player);
	return true;
}

SeekingMissileData neuroShock1
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "shield.dts";	//ROCKET.DTS";	//fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.025;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 40.0;
	muzzleVelocity = 60.0;
	totalTime = 3;
	liveTime = 3;
	seekingTurningRadius = 2.0;	//5
	nonSeekingTurningRadius = 3.0;
	proximityDist = 0.25;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
SeekingMissileData neuroShock2
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.001;	//0.5
	damageType = $ShockDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 120.0;
	muzzleVelocity = 120.0;
	totalTime = 3;
	liveTime = 3;
	seekingTurningRadius = 2.0;	//5
	nonSeekingTurningRadius = 3.0;
	proximityDist = 0.25;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};
SeekingMissileData OLDneuroShock3
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "discb.dts";
	explosionTag = Shockwave;
	collideWithOwner = false;	//true
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 2;	//995.0;	
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.0010;
	damageType = $ShockDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 10;	//1
	totalTime = 1.0;
	liveTime = 1.0;	//0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};

GrenadeData neuroShock3
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = turretExp;	//mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.001;
	damageType = $ShockDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 20;	//275;
	totalTime = 0.4;
	liveTime = 0.4;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};
SeekingMissileData neuroShock4
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "ROCKET.DTS";	//fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0025;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 40.0;
	muzzleVelocity = 60.0;	//60
	totalTime = 3;
	liveTime = 3;
	seekingTurningRadius = 2.0;	//5
	nonSeekingTurningRadius = 3.0;
	proximityDist = 0.25;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

// turret trickyness -plasmatic 2.2 -OS chaser 2.3
function NeuroTurret::verifyTarget(%this,%target)
{
	if($debugn)
	{
		if (getSimTime() - %this.alarmtime > 5)
		{
			%this.alarmtime = getSimTime();	
			messageall(1,%type@" is hunting "@%target);
		}
	}
		
	%client = Player::getClient(%target);
	if(%client.isSpy == true)
		return false;
	else 
	{
		if(!%this.fireing)
		{
			%pos = vector::add(GameBase::getPosition(%this),"0 0 1");
			%targetpos = GameBase::getPosition(%target);
			%cannon = %this.cannon;	
			%control = Client::getControlObject(%client);	

			%this.fireing = true;
			schedule(%this@".fireing = false;",2);
			%TH = getword(%pos,2);
			%PH = getword(%targetpos,2);
			%aim = %cannon.aim;
			%newtrans = "0 0 1 "@ %aim @" 0 0 1 "@ %pos; 
			// ai will return heat of 1 -Plasmatic 3.x fix
			if(%ph - %th > 10 && GameBase::virtual(%target, "getHeatFactor") >= 0.65  && !Player::isAIControlled(%target))	//player::isjetting(%target))
			{	
				// now for the Phun -plasmatic
				GameBase::playSequence(%cannon,1,"fire");
				schedule("GameBase::playSequence("@%cannon@",1,\"reload\");",1);							
				GameBase::playSound(%cannon, SoundMissileTurretFire, 0);
				Projectile::spawnProjectile("neuroShock1",%newtrans,%this,%vel,%target);
				Projectile::spawnProjectile("neuroShock2",%newtrans,%this,%vel,%target);
			}
			else if(vector::getdistance(%targetpos,%pos) < 30)
			{	//close quarters defense.. -plasmatic	
				GameBase::playSequence(%cannon,1,"fire");
				schedule("GameBase::playSequence("@%cannon@",1,\"reload\");",1);				
				Projectile::spawnProjectile("neuroShock3",%newtrans,%this,%vel,%target);
				GameBase::playSound(%cannon, SoundMortarTurretFire, 0);				
			}
			else if(%control != %target && getword(GameBase::getPosition(%control),2) - %th > 2 && vector::getdistance(GameBase::getPosition(%control),%pos) < 150)
			{
				//targeting nearby os missiles..
				%data = gamebase::getdataname(%control);
				if(%data == OSMissile)// || %data == ProbeDroid || %data == SuicideDroid || %data == SurveyDroid)
				{
					GameBase::playSequence(%cannon,1,"fire");
					schedule("GameBase::playSequence("@%cannon@",1,\"reload\");",1);							
					GameBase::playSound(%cannon, SoundMissileTurretFire, 0);
					Projectile::spawnProjectile("neuroShock4",%newtrans,%this,%vel,%control);											
				}
			}				
		}		
		return true;	//or it wont turn... We're not firing anything anyhow.. plasmatic
	}
}


//	GameBase::playSequence(%this,1,"fire");
//	GameBase::playSequence(%this,1,"reload");

	//		%trans = GameBase::getMuzzleTransform(%this);
	//		bottomprintall(GameBase::getMuzzleTransform(%this));
	//		%tr0 = getword(%trans,0);
	//		%tr1 = getword(%trans,1);
	//		%tr2 = getword(%trans,2);
	//		%tr3 = getword(%trans,3);
	//		%tr4 = getword(%trans,4);
	//		%tr5 = getword(%trans,5);
	//		%tr6 = getword(%trans,6);
	//		%tr7 = getword(%trans,7);
	//		%tr8 = getword(%trans,8);
	//		%tr9 = getword(%trans,9);
	//		%tr10 = getword(%trans,10);
	//		%tr11 = getword(%trans,11);
			
	//		%newtrans = %tr0 @" "@ %tr1 @" "@ %tr2 @" "@ %tr3 @" "@ %tr4 @" "@ %tr5 @" "@ %tr6 @" "@ %tr7 @" "@ %tr8 @" "@ %pos; 
