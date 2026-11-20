FlierData TLAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
};

FlierData THAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};


$DamageScale[TLAPC, $ObeliskDamageType] = 0.375;
$DamageScale[TLAPC, $MarlinDamageType] = 0.375;
$DamageScale[TLAPC, $LCGDamageType]    = 0.75;
$DamageScale[TLAPC, $ImpactDamageType] = 0.75;
$DamageScale[TLAPC, $BulletDamageType] = 0.75;
$DamageScale[TLAPC, $PlasmaDamageType] = 0.75;
$DamageScale[TLAPC, $EnergyDamageType] = 0.75;
$DamageScale[TLAPC, $ExplosionDamageType] = 0.75;
$DamageScale[TLAPC, $ShrapnelDamageType] = 0.75;
$DamageScale[TLAPC, $DebrisDamageType] = 0.75;
$DamageScale[TLAPC, $MissileDamageType] = 0.75;
$DamageScale[TLAPC, $LaserDamageType] = 0.375;
$DamageScale[TLAPC, $MortarDamageType] = 0.75;
$DamageScale[TLAPC, $BlasterDamageType] = 0.375;
$DamageScale[TLAPC, $ElectricityDamageType] = 0.5;
$DamageScale[TLAPC, $MineDamageType]        = 0.5;

$DamageScale[THAPC, $ObeliskDamageType] = 0.25;
$DamageScale[THAPC, $MarlinDamageType] = 0.25;
$DamageScale[THAPC, $LCGDamageType]    = 0.5;
$DamageScale[THAPC, $ImpactDamageType] = 0.5;
$DamageScale[THAPC, $BulletDamageType] = 0.5;
$DamageScale[THAPC, $PlasmaDamageType] = 0.5;
$DamageScale[THAPC, $EnergyDamageType] = 0.5;
$DamageScale[THAPC, $ExplosionDamageType] = 0.5;
$DamageScale[THAPC, $ShrapnelDamageType] = 0.5;
$DamageScale[THAPC, $DebrisDamageType] = 0.5;
$DamageScale[THAPC, $MissileDamageType] = 0.5;
$DamageScale[THAPC, $LaserDamageType] = 0.25;
$DamageScale[THAPC, $MortarDamageType] = 0.5;
$DamageScale[THAPC, $BlasterDamageType] = 0.25;
$DamageScale[THAPC, $ElectricityDamageType] = 0.5;
$DamageScale[THAPC, $MineDamageType]        = 0.5;

function TLAPC::Dismount(%this, %cl)
{
//dismount...

	Player::useItem(%cl, "TransAPCPack");
      %pl = Client::getOwnedObject(%cl);
	%pl.lastMount = %this;
	%pl.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%pl, -1, 0);
	%rot = GameBase::getRotation(%this);
	%rotZ = getWord(%rot,2);
	GameBase::setRotation(%pl, "0 0 " @ %rotZ);
      Client::setControlObject(%cl, %pl);

	%newPos = Vector::add(GameBase::getPosition(%cl), "0 0 -2");
	GameBase::setPosition(%pl, %newPos); //to compensate for being too high on dismount

	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	if(%pl.lastWeapon != "")
	{
		Player::useItem(%pl,%pl.lastWeapon);		 	
		%pl.lastWeapon = "";
	}
	%pl.driver = "";
	%pl.vehicle = "";


//make sure you have the same health as in Plane mode:
	%damage = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%pl, %damage);

//then get rid of the vehicle

	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	GameBase::setPosition(%this, "-1000 -1000 -1000");
	GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
}

function THAPC::Dismount(%this, %cl)
{
//dismount...

	Player::useItem(%cl, "TransHAPCPack");
      %pl = Client::getOwnedObject(%cl);
	%pl.lastMount = %this;
	%pl.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%pl, -1, 0);
	%rot = GameBase::getRotation(%this);
	%rotZ = getWord(%rot,2);
	GameBase::setRotation(%pl, "0 0 " @ %rotZ);
      Client::setControlObject(%cl, %pl);

	%newPos = Vector::add(GameBase::getPosition(%cl), "0 0 -2");
	GameBase::setPosition(%pl, %newPos); //to compensate for being too high on dismount

	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	if(%pl.lastWeapon != "")
	{
		Player::useItem(%pl,%pl.lastWeapon);		 	
		%pl.lastWeapon = "";
	}
	%pl.driver = "";
	%pl.vehicle = "";


//make sure you have the same health as in Plane mode:
	%damage = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%pl, %damage);

//then get rid of the vehicle

	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	GameBase::setPosition(%this, "-1000 -1000 -1000");
	GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "tarmor") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if(GameBase::getDataName(%this) == TLAPC || THAPC) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
	if(GameBase::getDataName(%this) == "Jetfire")
	{
		Jetfire::Dismount(%this, %cl);
		return;
	}
	if(GameBase::getDataName(%this) == "TLAPC")
	{
		TLAPC::Dismount(%this, %cl);
		return;
	}
	if(GameBase::getDataName(%this) == "THAPC")
	{
		THAPC::Dismount(%this, %cl);
		return;
	}

      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC || THAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

