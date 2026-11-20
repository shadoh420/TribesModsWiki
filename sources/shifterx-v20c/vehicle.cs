//=== Shifter X - Defines for ship/passenger shield values
$ScoutSheildStrength = 0.004;	//=== Shifter X - Was: 0.005 (1.8h)
$LAPCSheildStrength = 0.0120;	//=== Shifter X - Was: 0.0125 (1.8h)

//------------------------------ Begin ---------------------------------------
FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1.57;  // Shifter X - See Jet...
   maxPitch = 999999; //.7?
   maxSpeed = 53;
   minSpeed = -20;
	lift = 0.5;
	maxAlt = 155;
	maxVertical = 30;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.5;

	groundDamageScale = 1.0;

	projectileType = TurretMissile;
	reloadDelay = 1;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 0.8;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
};

FlierData Jet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 1.57;	// ShifterX - To make it unlimited, use 999999 or so.
   maxPitch = 999999;
   maxSpeed = 63;
   minSpeed = -30;
	lift = 0.5;
	maxAlt = 155;
	maxVertical = 50;
	maxDamage = 0.38;
	damageLevel = {1.0, 1.0};
	maxEnergy = 30;	// Shifter X - 90 before the anti-aircraft rockets.
	accel = 0.6;

	groundDamageScale = 1.0;

//	projectileType = JetBullet;
//	reloadDelay = 0.055;
	repairRate = 0;
	fireSound = SoundChainTurretFire;
	damageSound = SoundFlierCrash;
	ramDamage = 0.8;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
};

exec("xData_interceptor.cs");

FlierData Wraith
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 999999;
   maxPitch = 999999;
   maxSpeed = 35;
   minSpeed = -20;
	lift = 0.5;
	maxAlt = 155;
	maxVertical = 20;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.5;

	groundDamageScale = 1.0;

	reloadDelay = 2;
	repairRate = 0;
	fireSound = SoundFireChaingun;
	damageSound = SoundFlierCrash;
	ramDamage = 0.8;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;

};

//=== Shifter X
FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.8;
   maxSpeed = 35;	//=== Shifter X - Was: 31
   minSpeed = -15;	//=== Shifter X - Was: -10
	lift = 0.5;
	maxAlt = 155;
	maxVertical = 15;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 110;
	accel = 0.3;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 1;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	
	projectileType = BomberRocket;
	fireSound = SoundFireMortar;
	reloadDelay = 3.5;		//=== Shifter X - Was: 4.0
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.65;
   maxPitch = 0.65;
   maxSpeed = 29;								   
   minSpeed = -10;
	lift = 0.45;
	maxAlt = 155;
	maxVertical = 12;
	maxDamage = 3.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.35;

	groundDamageScale = 0.4;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
};

//----------------------------------------------------------------------------

//==================================================== Boom Stick Damage
$DamageScale[Scout, $ShellDamageType]       = 1.0;
$DamageScale[Jet, $ShellDamageType]         = 1.0;
$DamageScale[Wraith, $ShellDamageType]      = 1.0;
$DamageScale[LAPC, $ShellDamageType]        = 1.0;
$DamageScale[HAPC, $ShellDamageType]        = 1.0;

//==================================================== Nuke Damage
$DamageScale[Scout, $NukeDamageType]       = 1.0;
$DamageScale[Jet, $NukeDamageType]         = 1.0;
$DamageScale[Wraith, $NukeDamageType]      = 1.0;
$DamageScale[LAPC, $NukeDamageType]        = 1.0;
$DamageScale[HAPC, $NukeDamageType]        = 1.0;

//==================================================== Flash Damage
$DamageScale[Scout, $FlashDamageType]       = 1.0;
$DamageScale[Jet, $FlashDamageType]         = 1.0;
$DamageScale[Wraith, $FlashDamageType]      = 1.0;
$DamageScale[LAPC, $FlashDamageType]        = 1.0;
$DamageScale[HAPC, $FlashDamageType]        = 1.0;

//==================================================== Grav Gun
$DamageScale[Scout, $GravDamageType]       = 0;
$DamageScale[Jet, $GravDamageType]         = 0;
$DamageScale[Wraith, $GravDamageType]      = 0;
$DamageScale[LAPC, $GravDamageType]        = 0;
$DamageScale[HAPC, $GravDamageType]        = 0;

//==================================================== Cloak Damage
$DamageScale[Scout, $CloakDamageType]       = 1.0;
$DamageScale[Jet, $CloakDamageType]         = 1.0;
$DamageScale[Wraith, $CloakDamageType]      = 1.0;
$DamageScale[LAPC, $CloakDamageType]        = 1.0;
$DamageScale[HAPC, $CloakDamageType]        = 1.0;


$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.0;
$DamageScale[Scout, $ShrapnelDamageType] = 1.0;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $MissileDamageType] = 1.0;
$DamageScale[Scout, $LaserDamageType] = 0.7;
$DamageScale[Scout, $MortarDamageType] = 1.0;
$DamageScale[Scout, $BlasterDamageType] = 0.5;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType]        = 1.0;
$DamageScale[Scout, $SniperDamageType]        = 1.0;


$DamageScale[Jet, $ImpactDamageType] = 0.5;
$DamageScale[Jet, $BulletDamageType] = 1.2;
$DamageScale[Jet, $PlasmaDamageType] = 1.0;
$DamageScale[Jet, $EnergyDamageType] = 1.0;
$DamageScale[Jet, $ExplosionDamageType] = 1.0;
$DamageScale[Jet, $ShrapnelDamageType] = 1.0;
$DamageScale[Jet, $DebrisDamageType] = 1.0;
$DamageScale[Jet, $MissileDamageType] = 1.0;
$DamageScale[Jet, $LaserDamageType] = 0.7;
$DamageScale[Jet, $MortarDamageType] = 1.0;
$DamageScale[Jet, $BlasterDamageType] = 0.5;
$DamageScale[Jet, $ElectricityDamageType] = 1.0;
$DamageScale[Jet, $MineDamageType]        = 1.0;
$DamageScale[Jet, $SniperDamageType]        = 1.0;


$DamageScale[Wraith, $ImpactDamageType] = 1.0;
$DamageScale[Wraith, $BulletDamageType] = 1.0;
$DamageScale[Wraith, $PlasmaDamageType] = 1.0;
$DamageScale[Wraith, $EnergyDamageType] = 1.0;
$DamageScale[Wraith, $ExplosionDamageType] = 1.0;
$DamageScale[Wraith, $ShrapnelDamageType] = 1.0;
$DamageScale[Wraith, $DebrisDamageType] = 1.0;
$DamageScale[Wraith, $MissileDamageType] = 1.0;
$DamageScale[Wraith, $LaserDamageType] = 0.7;
$DamageScale[Wraith, $MortarDamageType] = 1.0;
$DamageScale[Wraith, $BlasterDamageType] = 0.5;
$DamageScale[Wraith, $ElectricityDamageType] = 1.0;
$DamageScale[Wraith, $MineDamageType]        = 1.0;
$DamageScale[Wraith, $SniperDamageType]        = 1.0;


$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.3;	//=== Shifter X - Was: 1.0
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.3;
$DamageScale[LAPC, $MortarDamageType] = 0.7;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;
$DamageScale[LAPC, $SniperDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.3;	//=== Shifter X - Was: 1.0
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.3;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;
$DamageScale[HAPC, $SniperDamageType]        = 1.0;


//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	if (GameBase::getDataName(%this) == "LAPC")
	{
		%this.shieldStrength = $LAPCSheildStrength;
		GameBase::setRechargeRate(%this, 6);
	}
	else if(GameBase::getDataName(%this) == "Scout")
	{
		%this.shieldStrength = $ScoutSheildStrength;
		GameBase::setRechargeRate(%this, 5);
	}
	else
	{
		%this.shieldStrength = 0.0;
		GameBase::setRechargeRate(%this, 10);
	}

	GameBase::setMapName(%this, GameBase::getDataName(%this));
}

function Vehicle::onCollision(%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType(%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			%weapon = Player::getMountedItem(%object,$WeaponSlot);  //=== Shifter X - Moved here because of ALPC Turrets
			if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale") && Vehicle::canMount(%this, %object))
			{
//				GameBase::setTeam(%this, gamebase::getteam(%object));
				GameBase::setMapName(%this, GameBase::getDataName(%this)@" - "@Client::GetName(%client));

				if(%weapon != -1)
				{
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}

				//-=-=-=- Wraith Cloaking
				if(GameBase::getDataName(%this) == Wraith)
				{
					GameBase::startFadeout(%this);
				}
				else if(GameBase::getDataName(%this) == HAPC)
				{
					GameBase::startFadeout(%this);
				}

				Player::setMountObject(%object, %this, 1);
			        Client::setControlObject(%client, %this);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;
				schedule("Vehicle::TestArmor("@ %this @","@ %object @");", 2);
				if (GameBase::getDataName(%this) == "LAPC")
				{
					 %object.shieldstrength = $LAPCSheildStrength;
				}
				else if (GameBase::getDataName(%this) == "Scout")
				{
					 %object.shieldstrength = $ScoutSheildStrength;
				}
			}
			else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Wraith) && (GameBase::getDataName(%this) != Jet))  
			{
			 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));

					if (GameBase::getDataName(%this) == "LAPC")
					{
						%object.shieldstrength = $LAPCSheildStrength;
						if(%weapon != -1)
						{
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setItemCount(%client, "ALPCTurret", 1);
						Player::useItem(%client, "ALPCTurret");
					}
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if (GameBase::getDataName(%this) == "HAPC")
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

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else
	{	
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)))
	{	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle= "";

		if (GameBase::getDataName(%this) == "LAPC") {
			if (Player::getMountedItem(%client, $BackpackSlot) == "ShieldPack") Player::trigger(%client,$BackpackSlot,false);
			%passenger.shieldstrength = 0.0;
			if (Player::getMountedItem(%client,$WeaponSlot) == "ALPCTurret")
				Player::useItem(%passenger, %passenger.lastWeapon);
			Player::setItemCount(%client, "ALPCTurret", 0);
			Player::setItemCount(%client, "ALPCTurretL", 0);
			Player::setItemCount(%client, "ALPCTurretR", 0);
		}

		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{

   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   //Dismount the player	  
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
				//-=-=-=- Wraith Cloaking
				if ((GameBase::getDataName(%this) == "Wraith") || (GameBase::getDataName(%this) == "HAPC"))
				{
					GameBase::startFadein(%this);
				}
				else if ((GameBase::getDataName(%this) == "Scout") || (GameBase::getDataName(%this) == "LAPC")) {

					if (Player::getMountedItem(%cl, $BackpackSlot) == "ShieldPack") Player::trigger(%cl,$BackpackSlot,false);
					%pl.shieldstrength = 0.0;
				}
				else if ((GameBase::getDataName(%this) == "jet") && ((Player::getArmor(%cl) == "sarmor") || (Player::getArmor(%cl) == "sfemale"))) {
					if (Player::getMountedItem(%cl, $BackpackSlot) == -1) { 
						Player::setItemCount(%cl,"MechPack",1);
						Player::mountItem(%cl,"MechPack",$BackpackSlot);
						$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
						schedule("deleteObject("@%this@");", 0.075, %this);
					}
				}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed(%this,%mom)
{
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	%cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
		Player::setMountObject(%pl, -1, 0);
		Client::setControlObject(%cl, %pl);

		if ((GameBase::getDataName(%this) == "LAPC") || (GameBase::getDataName(%this) == "Scout")) {
			if (Player::getMountedItem(%pl, $BackpackSlot) == "ShieldPack") Player::trigger(%pl,$BackpackSlot,false);
			%pl.shieldstrength = 0.0;
		}

		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
			%pl.driver = "";
		}
		for(%i = 0 ; %i < 4 ; %i++)
			if(%this.Seat[%i] != "") {
				%pl = Client::getOwnedObject(%this.Seat[%i]);
			   Player::setMountObject(%pl, -1, 0);
		  	 	Client::setControlObject(%this.Seat[%i], %pl);

			if ((GameBase::getDataName(%this) == "LAPC") || (GameBase::getDataName(%this) == "Scout")) {
				if (Player::getMountedItem(%pl,$BackpackSlot) == "ShieldPack") Player::trigger(%pl,$BackpackSlot,false);
				if (Player::getMountedItem(%pl,$WeaponSlot) == "ALPCTurret") Player::useItem(%pl, %pl.lastWeapon);
				%pl.shieldstrength = 0.0;
				Player::setItemCount(%pl, "ALPCTurret", 0);
				Player::setItemCount(%pl, "ALPCTurretL", 0);
				Player::setItemCount(%pl, "ALPCTurretR", 0);
			}

		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%this.shieldstrength)
	{
		%value *= $damageScale[GameBase::getDataName(%this), %type];
		StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
	else
	{
		%value *= $damageScale[GameBase::getDataName(%this), %type];
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}
