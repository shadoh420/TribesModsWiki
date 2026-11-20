$InvList[SecurityPack] = 1;
$RemoteInvList[SecurityPack] = 1;

$TeamItemMax[SecurityPack] = 1;

$ItemMax[larmor, SecurityPack]  = 1;
$ItemMax[marmor, SecurityPack]  = 1;
$ItemMax[harmor, SecurityPack]  = 1;
$ItemMax[lfemale, SecurityPack] = 1;
$ItemMax[mfemale, SecurityPack] = 1;

ItemImageData SecurityPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};
ItemData SecurityPack
{
	description = "Security Device";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = $InvHeading[Deployables];
	imageType = SecurityPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SecurityPack::onUse(%player, %item)
{ if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function SecurityPack::onDeploy(%player, %item, %pos)
{ if(SecurityPack::deployShape(%player, %item)){ Player::decItemCount(%player, %item); } }

function SecurityPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{ Client::sendMessage(%client, 0, "Deployable Item limit reached for "@ %item.description @"es"); return false; }
	
	if(!GameBase::getLOSInfo(%player, 3))
	{ Client::sendMessage(%client, 0, "Deploy position out of range"); return false; }
	GameBase::getLOSInfo(%player, 3);
	
	%obj = getObjectType($los::object);
	
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("Security Device", "Turret", SecurityTurret, true);
	addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Security Device "@ Client::getName(%client));
	Client::sendMessage(%client,0,"Security Device deployed");
	playSound(SoundPickupBackpack, $los::position);
	$TeamItemCount[GameBase::getTeam(%player) @"SecurityPack"]++;
	Echo("Deploy: "@ Client::getName(%client) @"("@ %client @") deployed a Security Device.");
	return true;
}
//==========================================================================================

TurretData SecurityTurret
{
	className = "Turret";
	shapeFile = "magcargo";
	maxDamage = 2;
	maxEnergy = 10;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = false;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Security Turret";
	damageSkinData = "objectDamageSkins";
};
function SecurityTurret::onAdd(%this)
{
	Schedule("SecurityTurret::deploy("@ %this @");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	if (GameBase::getMapName(%this) == "")
	{ GameBase::setMapName (%this, "Base Security"); }
}
function SecurityTurret::deploy(%this)
{ GameBase::playSequence(%this, 1, "deploy"); }

function SecurityTurret::onEndSequence(%this, %thread)
{ GameBase::setActive(%this, true); }

function SecurityTurret::onDisabled(%this)
{
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	
	for(%i = %num -1; %i >= 0; %i--)
	{
		%obj = Group::getObject(%this.set, %i);
		%cl = GameBase::getOwnerClient(%obj);
		if(%obj.origShieldStrength != "")
		{ %obj.shieldStrength = %obj.origShieldStrength; }
		else
		{ %obj.shieldStrength = 0; }
		%obj.secured = 0;
		%obj.origShieldStrength = "";
	}
	deleteObject(%this.set);
}

function SecurityTurret::onDestroyed(%this)
{
  	$TeamItemCount[GameBase::getTeam(%this) @ "SecurityPack"]--;
	if(%this.set)
	{
		%num = Group::objectCount(%this.set);
		for(%i = %num; %i >= 0; %i--)
		{
			%obj = Group::getObject(%this.set, %i);
			if(%obj != %this)
			{
				if(%obj.origShieldStrength != "")
				{ %obj.shieldStrength = %obj.origShieldStrength; }
				else
				{ Schedule(%obj @".shieldStrength = 0;", 0.1, %obj); }
				%obj.secured = 0;
			}
		}
		deleteObject(%this.set);
	}
}

function SecurityTurret::onPower(%this, %power, %generator)
{}

function SecurityTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this, 5);
	GameBase::setActive(%this, true);
	%Set = newObject("set", SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType | $StaticObjectType | $VehicleObjectType | $MineObjectType | $SimInteriorObjectType;
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 200, 0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this || getObjectType(%obj) == "Player")
		{
			// don't shield enemies or the box itself..
		}
		else
		{
			%obj.origShieldStrength = %obj.ShieldStrength;
			%obj.shieldStrength = 10;
			%obj.secured = 1;
		}
	}
	%this.set = %Set;
	Schedule("SecurityTurret::checkSecurity("@ %this @");", 0.1, %this);
}	

function SecurityTurret::checkSecurity(%this)
{
	if(GameBase::getDamageState(%this) != "Enabled")
	{ return; }
	
	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType | $StaticObjectType | $VehicleObjectType | $MineObjectType | $SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 200, 0);
	%num = Group::objectCount(%Set);
	
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this  || getObjectType(%obj) == "Player")
		{
			// don't shield enemies or the box itself
		}
		else
		{
			%obj.shieldStrength = 25;
			%obj.secured = 1 + %this.evenodd;// 1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}
	%num = Group::objectCount(%this.set);
	
	for(%j; %j < %num; %j++)
	{
		%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this) || getObjectType(%obj) == "Player")
		{
			// No Need to check the box or the other team.
		}
		else if(%obj.secured != (%this.evenodd + 1))//If different, then it's a new set
		{
			%cl = GameBase::getOwnerClient(%obj);
			if(%obj.origShieldStrength != "")
			{ %obj.shieldStrength = %obj.origShieldStrength; }
			else
			{ %obj.shieldStrength = 0; }
			%obj.secured = 0;
		}
	}
	deleteObject(%this.set);// Delete the old set.
	%this.set = %Set;       // Replace with new set
	Schedule("SecurityTurret::checkSecurity("@ %this @");", 6.0, %this);// Recheck in 6.0 seconds
}