

// A base class function for Turrets, fixes friendly turrets firing at friendly chams -Plas 3.0
function Turret::verifyTarget(%this,%target)
{
	%client = Player::getClient(%target);
	if(%client.isSpy == true)
		return false;
	else 
	{
		%type = gamebase::getdataname(%this);
		
		if(%type == RocketTurret)
		{
			if(GameBase::virtual(%target, "getHeatFactor") >= 0.5)
				return "True";
			else
				return "False";
		}	
		// For some @#$%!@ Damn reason, Tribes won't allow "function RocketTurret::verifyTarget" to override base class.
		// Fudging around Rocket Turret freakyness with hard code. -Plasmatic 3.0		
		if($debug)
		{
			if (getSimTime() - %this.alarmtime > 5)
			{
				%this.alarmtime = getSimTime();	
				messageall(1,%type@" is hunting "@%target);
			}
		}
	//	if(!eval(%type @"::verifyTarget("@%this@", "@%target@");"))
	//		return false;
	//	else
			return true;	
		
	}
}


//----------------------------------------------------------------------------
// TURRET DYNAMIC DATA

TurretData PlasmaTurret
{
	maxDamage = 1.75;
	maxEnergy = 300;
	minGunEnergy = 50;
	maxGunEnergy = 6;
	reloadDelay = 0.75;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 125;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.5;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
	//isSustained = true;
};
																						 
TurretData ELFTurret		
{			 
	maxDamage = 1.25;
	maxEnergy = 175;
	minGunEnergy = 35;
	maxGunEnergy = 5;
	range = 50;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret"; // ELF Turret
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";
	fireSound = SoundGeneratorPower;
	activationSound = SoundChainTurretOn;
	deactivateSound = SoundChainTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	isSustained = true;
	firingTimeMS = 750;
	energyRate = 30.0;
};

TurretData RocketTurret
{
	maxDamage = 1.5;
	maxEnergy = 175;
	minGunEnergy = 50;
	maxGunEnergy = 50;
	range = 175;
	gunRange = 350;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 4.0;
	speedModifier = 1.5;
	projectileType = TurretMissile;
	reloadDelay = 1.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
	//whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function RocketTurret::onPower(%this,%power,%generator)
{
	if(%power) 
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,14);
	}
	else 
	{	
		%this.shieldStrength = 0;	
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
		schedule("Ann::PowerGlide("@%this@");",1);	//1/21/2008 4:31AM -Plasmatic
	}
	GameBase::setActive(%this,%power);
}

// For some @#$%!@ Damn reason, Tribes won't allow this function to override base class.
// A base class function will need to have this hard coded in. -Plasmatic 3.0
//	function RocketTurret::verifyTarget(%this,%target)
//	{
//		if(GameBase::virtual(%target, "getHeatFactor") >= 0.5)
//			return "True";
//		else
//			return "False";
//	}

//--------------------------------------------

TurretData MortarTurret
{
	maxDamage = 1.5;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 15;
	reloadDelay = 2;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 150; // 0
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
																						 
//--------------------------------------------

TurretData IndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};

//---------------------------------------------------

$TurretStatusIdle = 0;
$TurretStatusRecalibrating = 1;
$TurretStatusAlert = 2;

// generic function, overwritten by anything defined -plasmatic
function Turret::onAdd(%this)
{
	if($debug)
		echo("add turret "@GameBase::getDataName(%this));
		
	if(GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Turret");
		
//	if(GameBase::getDataName(%this) != InvTrigger)	
//		$turret::count++;
}
 
function Turret::onRemove(%this)
{
}


function Turret::onActivate(%this)
{
	GameBase::playSequence(%this,0,power);
	%this.Status = $TurretStatusIdle;
}

function Turret::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
	Turret::checkOperator(%this);
}

function Turret::onSetTeam(%this,%oldTeam)
{
	if(!%this.ControlledTeamChange)
		%this.OrgTeam = GameBase::getTeam(%this);
	else
		%this.ControlledTeamChange = "";
	if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) 
		Turret::checkOperator(%this);
}

function Turret::checkOperator(%this)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) 
	{
		%pl = Client::getOwnedObject(%cl);
		if(%player.ManualCommandTag)
		{	%player.ManualCommandTag = False;
			%player.CommandTag = "";
		}
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
	//Client::setGuiMode(%cl,2);
}

function Turret::onPower(%this,%power,%generator)
{
	if(%power) 
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);		
	}
	else 
	{
		%this.shieldStrength = 0;
		GameBase::setRechargeRate(%this,0);
		Turret::checkOperator(%this);
		schedule("Ann::PowerGlide("@%this@");",1);	//1/21/2008 4:31AM -Plasmatic
	}
	GameBase::setActive(%this,%power);
}

function Turret::onEnabled(%this)
{
	if(GameBase::isPowered(%this)) 
	{
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this,true);
	}
	else
		schedule("Ann::PowerGlide("@%this@");",1 + getRandom()*5);	//1/21/2008 4:31AM -Plasmatic
}


function Turret::onDisabled(%this)
{
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}

function Turret::onDestroyed(%this)
{
	%this.NeedsNewOwner = "";	//plasmatic 2.2
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	%this.cloakable = "";	
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
	Turret::objectiveDestroyed(%this);
	if(!$NoCalcDamage)
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100);
}

function Turret::objectiveDestroyed(%this) // ???
{
}

function Turret::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if($debug::Damage)
	{
		echo("Turret::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}	
	if(%value <= 0) return;	//plasmatic 2.3
	if($Annihilation::uber)
		%value *= 0.75;
		
	if(%type == $SniperDamageType && Player::getMountedItem(%object,$WeaponSlot) == Railgun && %object.rail)
		%value = %value*3;

	if(%this.objectiveLine)
		%this.lastDamageTeam = GameBase::getTeam(%object);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) 
	{
		%name = GameBase::getDataName(%this);
		if(!$CanAlwaysTeamDestroy[%name])
			%TDS = $Server::TeamDamageScale;
			
		
	}
	else if(%type == $ShockDamageType)	//plasmatic 2.3... Turrets can be shocked...
		GameBase::setEnergy(%this,0);
		
	if(%type == $LucifersMarkType && GameBase::getTeam(%this) != GameBase::getTeam(%object))	//12/19/2007 6:27AM
		hammer::damage(%this,%object);
	else	
		StaticShape::shieldDamage(%this,%type,%value * %TDS,%pos,%vec,%mom,%object);
}

function Turret::onManualControl(%this, %player) 
{	 
	// When a player jumps in
	%client = Player::getClient(%player);

	%player.ManualCommandTag = True;
	%player.CommandTag = 1;
	Client::takeControl(%client, %this);

	 // Move the player onto the turret if appropriate
	%name = GameBase::getDataName(%this);
	if($EmbedController[%name])
		GameBase::SetPosition(%player, GameBase::GetPosition(%this));
}

function Turret::onControl (%this, %object)
{
	%client = Player::getClient(%object);
	Client::sendMessage(%client,0,"Controlling turret " @ %this);
}

function Turret::onDismount (%this, %object) 
{	 
	// When a player ceases to control the turret (either jump or stop control)
	%client = %object;
	Turret::checkOperator(%this);
	%this.Status = $TurretStatusRecalibrating;
	schedule("Turret::onInternalDiagnostics(" @ %this @ ", " @ %object @ ");", 10, %this);
}

function Turret::Jump(%this, %mom) 
{	
	%cl = GameBase::getControlClient(%this);
	Turret::onDismount(%this, %cl);
}

function Turret::onInternalDiagnostics(%this, %object)
{	
	 // Verify that we're on our original team
	if(GameBase::getTeam(%this) != %this.OrgTeam)
	{	%this.Status = $TurretStatusAlert;
		GameBase::setTeam(%this, %this.OrgTeam);
		//  Spend additional time in alert if we had to correct our team
		schedule("Turret::onReturnToIdle(" @ %this @ ");", 10, %this);
	}
	else 
		Turret::onReturnToIdle(%this);
}

function Turret::onReturnToIdle(%this)
{	
	%this.Status = $TurretStatusIdle;
}

function Turret::onCollision (%this, %object)
{	
	if($debug) 
		event::collision(%this,%object);
	if(%object.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;
	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second -plasmatic
	if(%this.CommandTag) return;

	%name = GameBase::getDataName(%this);
	if(getObjectType(%object) != "Player" || !$CanControl[%name]) 
		return;

	 // Still standing in the turret?
	if(GameBase::GetPosition(%this) == GameBase::GetPosition(%object)) 
		return;

	 // Verify the status of the turret
	if(Player::getMountedItem(%object,$BackpackSlot) == Laptop)
	{	if(%this.Status == $TurretStatusRecalibrating)
		{	 
			Laptop::Error(%client, "Turret is recalibrating.");
			return;
		}
		else if(%this.Status == $TurretStatusAlert)
		{	
			Laptop::Error(%client, "Turret is on alert.");
			return;
		}
	}
	else
	{	if(%this.Status != $TurretStatusIdle)
		{	 
			Client::sendMessage(%client,0,"Turret is recharging.");
			return;
		}
	}
	if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
	{	//  If the player has a laptop, then they can control anything
		if(Player::getMountedItem(%object,$BackpackSlot) != Laptop)
		{	
			Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team.~waccess_denied.wav");
			return;
		}

		//  Team change the turret (internal diagnostics will change it back once dismounted)
		%this.OrgTeam = GameBase::getTeam(%this);
		%this.ControlledTeamchange = True;
		GameBase::setTeam(%this, GameBase::getTeam(%client));

		Turret::onManualControl(%this, %object);
		Laptop::Output(%client, "Successful patch into enemy turret.");
	}
	else // Normal non-laptop connection to team turret
	{	
		Turret::onManualControl(%this, %object);
		Client::sendMessage(%client, 0, "Manually controlling turret");
	}
}

function Turret::onAttemptControl(%this, %client)
{	
	//  If you're controlling via a Command station, this is the first entry into
	//  Turret.  If you're running through collision, this is called above.
	%player = Client::getOwnedObject(%client);
	%name = GameBase::getDataName(%this);

	//  Run some final checks
	if(!%player.CommandTag && !$CanAlwaysControl[%name])
	{	if(Player::getMountedItem(%player, $BackpackSlot) != Laptop) 
		{	
			Client::SendMessage(%client, 0, "Need laptop or Command Station.");
			return;
		}
	}

	//  Actually control the turret
	Client::setControlObject(%client, %this);
	Client::setGuiMode(%client, $GuiModePlay);
}

$TurretLocGroundOnly = 0;
$TurretLocAnywhere = 1;

// we're not going to interfere with enemy turret sensor net, or zappy inv turrets, 2.2 fix -plasmatic
function CountTurrets(%set, %num, %team) 
{	
	%count = 0;
	for(%i=0; %i < %num; %i++)
	{	
		%obj = GameBase::getDataName(Group::getObject(%set,%i));
		if((%obj.ClassName == Turret || %obj.ClassName == SelfPoweredTurret) && %obj.Range > 0 && GameBase::getTeam(%obj) == %team) 
			%count++;
	}
	return %count;
}

function Turret::deployShape(%player, %name, %shape, %item, %validloc)
{	
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]  && !$build) 
	{ 
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return;
	}

	if(!GameBase::getLOSInfo(%player, 3) && (Player::getItemCount(%player, iarmorBuilder) != 1 || !GameBase::getLOSInfo(%player, 4.5)))
	{ 
		if(!$build)
			Client::sendMessage(%client,0,"Deploy position out of range");
		GameBase::playSound(%player, SoundPackUse, 0);
		return;
	}

	if(getNumTeams()-1 == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if(%playerTeam == 1)
			%enemyTeam = 0;
				
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}

		if($turret::deployinpower)
		{
			// Additional restriction on turret placement, needs power grid.
			%team = GameBase::getteam(%player);
			%Pos = $los::position;
		
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,%pos,600,600,600,0);
			%totalnum = Group::objectCount(%set);
			
			for(%i = 0; %i < %totalnum; %i++)
			{
				%obj = Group::getObject(%set, %i);
				%data = GameBase::getDataName(%obj);	
				%objteam = GameBase::getteam(%obj);	
					
				if(%objteam == %team && GameBase::isPowered(%obj))
				{
				//	messageall(1,%desc@" #"@%player@" Found a powered "@%data@", -"@%data.className);		
						
					// Snowblind map has only one gen on team -1, 1000m below ground.. 
					// So I'm expanding the power grid to include stations. -Plasmatic
					if((%data.className == Generator || %data.className == Station))
					{	
						%GenPos = GameBase::getPosition(%obj);
						if(Vector::getDistance(%Pos,%GenPos) <= $Power::Range[%data])
						{	
							%ok = true;
							
						}
					}
				}
			}
			deleteObject(%set);	
			if(!%ok)
			{
				Client::sendMessage(%client,0,"This deployable needs a nearby generator to deploy.~waccess_denied.wav");
				return false;
				
			}	
			
		}
	}
	
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform")	 
	{ 
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		return;
	}

	if(!GameBase::testPosition(%player, vector::add($los::position, "0 0 1")) && %validloc == $TurretLocGroundOnly)
	{ 
		Client::sendMessage(%client,0,"Turret does not fit there");
		return;
	}


// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	//echo("$los::object ",%obj);
	//allowing turrets on enemy jail cell for 2.2 -players can open jail by shooting switch -plasmatic
	if(%obj.inmotion == true && gamebase::getteam($los::object) == Client::getTeam(%client))	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return;
	}
	
	
	//  Check long range count (not applicable to manual turrets)
	if(%shape.Range > 0)
	{	
		%set = newObject("set",SimSet);
		%box = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
		%num = CountTurrets(%set, %box ,%playerTeam);
		deleteObject(%set);
		if(%num > $MaxNumTurretsInBox) 
		{	
			if(!$build)
				Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			GameBase::playSound(%player, mine_act, 0);
			return;
		}
	}

	// Check short range count
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, 0);
	%num = CountObjects(%set, %shape, %num);
	deleteObject(%set);
	if(%num) 
	{	Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
		return;
	}

	// Check slope of the floor
	if(%validloc == $TurretLocGroundOnly)
	{	
		if(Vector::dot($los::normal,"0 0 1") <= 0.7) 
		{	
			Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			return;
		}
		%rot = GameBase::getRotation(%player);
	}
	else if(%validloc == $TurretLocAnywhere)
	{	
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
		if(Vector::dot($los::normal,"0 0 1") > 0.6) 
			%rot = "0 0 " @ %zRot;
		else 
		{	
			if(Vector::dot($los::normal,"0 0 -1") > 0.6) 
				%rot = "3.14159 0 " @ %zRot;
			else 
				%rot = Vector::getRotation($los::normal);
		}
	}
	else
		return;

	// Make sure this isn't colliding with other objects
	if(!checkInvDeployArea(%client,$los::position)) 
	{	
		return;
	}

	// Passed validations, deploy
	%obj = newObject("hellfiregun", "Turret", %shape, true);
	
	addToSet("MissionCleanup/deployed/turret", %obj);
	%obj.cloakable = true;	//for base cloaker
	$turret::count++;	

	
	
	GameBase::setTeam(%obj, GameBase::getTeam(%player));
	GameBase::setPosition(%obj, $los::position);
	GameBase::setRotation(%obj, %rot);
	Gamebase::setMapName(%obj, %name);
	Client::sendMessage(%client, 0, %item.description @ " deployed");
	if(!$build)
		echo("MSG: "@Client::getName(%client)@", "@%client@" deployed a " @ %item.description@ " ob# "@%obj);
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	//reportDeploy(%obj, %client);
	
	// Remote turrets - kill points to player that deploy them
	client::setOwnedObject(%client, %obj);
	%obj.deployer = %client; 	//for destroy points, bk messages -plasmatic
	Client::setOwnedObject(%client, %player);
	$TurretList[%obj] = %client;	//we're going to disable when client changes team or drops -plasmatic 2.2	
	
	if($debug)
		echo(%client @ " deployed a " @ %item.description @" object # "@%obj);
	
	return true;
}

//things are alot simpler with deployable subgroups.. -plasmatic 2.2
function Turret::DisableClients(%client)
{	
	%simset = nameToID("MissionCleanup/deployed/turret");
	for(%i = 0; (%o = Group::getObject(%simset, %i)) != -1 && %i < 2000; %i++)
	{
		if($TurretList[%o] == %client)
		{
			if(Client::getTeam(%client) != Gamebase::getTeam(%o))
			{
				if(!%o.NeedsNewOwner)
				{
					%count++;
					%data = GameBase::getDataName(%o);
					echo("!! Disabling "@%o@" "@%data);
					%destroy = %data.maxDamage;
					%disable = (%destroy/3)*2;
					GameBase::setDamageLevel(%o, %disable);
			
					%o.NeedsNewOwner = true;
					Gamebase::setMapName(%o,"Repair me please.");
					$TurretList[%o] = "";
				}
			}
		}		
	}	
	if(%count > 1)
		messageall(1,"Disabled "@ %count @" of "@ Client::getName(%client) @"'s turrets.");
	else if(%count > 0)
		messageall(1,"Disabled "@ Client::getName(%client) @"'s turret.");
}

// ===================================================================================
// Deployable turret class -Plasmatic
// removing more redundant functions with these 
// and simplifying power code. 

function SelfPoweredTurret::onAdd(%this)
{
	schedule("SelfPoweredTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0;
	if(GameBase::getMapName(%this) == "") 
	{
		%data = GameBase::getDataName(%this);
		
		GameBase::setMapName (%this, %data.description);
		
	}
}

function SelfPoweredTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function SelfPoweredTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}


function SelfPoweredTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

function SelfPoweredTurret::onPower(%this,%power,%generator)
{
}

function SelfPoweredTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function SelfPoweredTurret::onDisabled(%this)
{
//	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}







