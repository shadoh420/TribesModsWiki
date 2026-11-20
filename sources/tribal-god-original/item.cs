//------------------------------------
// Change This If You Add New Items
// Or It Will Fuck Up Everyones Favs.
$ItemFavoritesKey = "Tribal_God_v6.4";
//------------------------------------

// Setup Inventory Variables.
$InvHeading[PsionicsWeapons] = "ePsionics Weapons:";
$InvHeading[DeployableBases] = "jDeployable Bases:";
$InvHeading[BulletWeapons] = "cProjectile Weapons:";
$InvHeading[EnergyWeapons] = "dEnergy Weapons:";
$InvHeading[Deployables2] = "iOther Deployables:";
$InvHeading[JailingItems] = "mJailing Toyz:";
$InvHeading[ForceFields] = "gForce Field Doors:";
$InvHeading[Deployables] = "hDeployables:";
$InvHeading[BackPacks] = "bBackPacks:";
$InvHeading[Turrets] = "fBase Defence Items:";
$InvHeading[oddnend] = "lSpecialty Items:";
$InvHeading[Armor] = "aArmors:";
$InvHeading[Walls] = "kDeployable Walls:";
$InvHeading[Misc] = "nMisc. Items:";
//-------------------------------------------------------------------------------------------


$ItemPopTime  = 3;

// Image Slot Variables.
$FlagSlot = 2;
$ToolSlot = 0;
$WeaponSlot = 0;
$DefaultSlot = 3;
$BackpackSlot = 1;

// Extra Image Slot Variables.
$XtraSlotA = 4;
$XtraSlotB = 5;
$XtraSlotC = 6;
$XtraSlotD = 7;
//-------------------------------------------------------------------------------------------


// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};
//-------------------------------------------------------------------------------------------


$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
//-------------------------------------------------------------------------------------------


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = TankRPGAmmo;
//-------------------------------------------------------------------------------------------

// Flags Data
function Flag::onUse(%player, %item)
{ Player::mountItem(%player, %item, $FlagSlot); }

ItemImageData FlagImage
{
	shapeFile   = "Flag";
	mountPoint  = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType   = 2;
	lightRadius = 4;
	lightTime   = 1.5;
	lightColor  = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
    validateShape = false;
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};
//-----------------------------------------------------

// Armors Data
ItemData LightArmor
{
	heading = $InvHeading[Armor];
	description = "Asassin";
	className = "Armor";
	price = 175;
};

ItemData MediumArmor
{
	heading = $InvHeading[Armor];
	description = "Mercenary";
	className = "Armor";
	price = 250;
};

ItemData HeavyArmor
{
	heading = $InvHeading[Armor];
	description = "BoRg";
	className = "Armor";
	price = 400;
};
//-----------------------------------------------------

// Vehicles
ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 875;
};
//-----------------------------------------------------

// Tools Data: Weapons, Tools, Ammo, Misc. Items..
ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload")
	{ Item::onDrop(%player, %item); }
}	
//-----------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{ Player::mountItem(%player,%item,$ToolSlot); }
//-----------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};
//-----------------------------------------------------

//====Begin Repair Kit====|
$AutoUse[RepairKit] = false;

$ItemMax[larmor, RepairKit]  = 3;
$ItemMax[marmor, RepairKit]  = 5;
$ItemMax[harmor, RepairKit]  = 7;
$ItemMax[lfemale, RepairKit] = 3;
$ItemMax[mfemale, RepairKit] = 5;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile   = "armorKit";
   heading     = $InvHeading[Misc];
   shadowDetailMask = 4;
   price            = 35;
   validateShape    = true;
   validateMaterials = false;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player, %item);
	GameBase::repairDamage(%player, 0.99);
}
//====End Repair Kit====|


//====Begin Mine Ammo====|
$InvList[MineAmmo] = 1;

$ItemMax[larmor, MineAmmo]  = 50;
$ItemMax[marmor, MineAmmo]  = 75;
$ItemMax[harmor, MineAmmo]  = 100;
$ItemMax[lfemale, MineAmmo] = 50;
$ItemMax[mfemale, MineAmmo] = 75;

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			%obj = newObject("","Mine","antipersonelMine");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam(%obj,GameBase::getTeam (%client));
		}
		if($TG::InfiniteAmmo:Mine != true)
		{ Player::decItemCount(%player, %item); }
	}
}
//====End Mine Ammo====|


//====Begin Radius Mine====|
$ItemMax[larmor, RadiusMineAmmo]  = 1;
$ItemMax[marmor, RadiusMineAmmo]  = 1;
$ItemMax[harmor, RadiusMineAmmo]  = 1;
$ItemMax[lfemale, RadiusMineAmmo] = 1;
$ItemMax[mfemale, RadiusMineAmmo] = 1;

ItemData RadiusMineAmmo
{
	description = "Radius Mine";
	shapeFile = "mineammo";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function RadiusMineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","radiusMine");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
}
//====End Radius Mine====|


//====Begin Grenade====|
$InvList[Grenade] = 1;

$ItemMax[larmor, Grenade]  = 100;
$ItemMax[marmor, Grenade]  = 125;
$ItemMax[harmor, Grenade]  = 250;
$ItemMax[lfemale, Grenade] = 100;
$ItemMax[mfemale, Grenade] = 125;

ItemData Grenade
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	validateShape = false;
	validateMaterials = false;
};

function Grenade::onUse(%armor, %item)
{
	if(!$matchStarted)
	{ return; }
	
	%client = Player::getClient(%armor);
	%velocity = Item::getVelocity(%armor);
	
	%velX = getWord(%velocity, 0);
	%velY = getWord(%velocity, 1);
	%velZ = getWord(%velocity, 2);
	
	%velXa = %velX / 6;
	%velYa = %velY / 6;
	%velZa = %velZ / 6;
	
	%newVelocity = %velXa @" "@ %velYa @" "@ %velZa;
	
	Item::setVelocity(%armor, %newVelocity);
	Client::sendMessage(%client, 0, "AirBrake Used.");
}


//====Begin Flash Grenade====|
$ItemMax[larmor, FlashGrenade]  = 40;
$ItemMax[marmor, FlashGrenade]  = 65;
$ItemMax[harmor, FlashGrenade]  = 90;
$ItemMax[lfemale, FlashGrenade] = 40;
$ItemMax[mfemale, FlashGrenade] = 65;

ItemData FlashGrenade
{
   description = "FlashGrenade";
   shapeFile   = "grenade";
   heading     = $InvHeading[Misc];
   shadowDetailMask = 4;
   price            = 5;
   className        = "HandAmmo";
   validateShape    = false;
   validateMaterials = false;
};

function FlashGrenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Flash");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//====End Flash Grenade====|


//====Begin LiLBoost====|
$ItemMax[larmor, LiLBoostammo]  = 35;
$ItemMax[marmor, LiLBoostammo]  = 35;
$ItemMax[harmor, LiLBoostammo]  = 35;
$ItemMax[lfemale, LiLBoostammo] = 35;
$ItemMax[mfemale, LiLBoostammo] = 35;

ItemData LiLBoostammo
{
	description = "LiLBoost";
	shapeFile = "sensor_small";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function LiLBoostammo::onUse(%player, %item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","LiLBoost");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,0,false);
			%player.throwTime = getSimTime() + 0.5;
			Client::sendMessage(Player::getClient(%player),0,"You use a LiL Booster.");
		}
	}
}
//====End LiLBoost====|

//====Begin Beacon====| - (Boost)
MineData Boost
{
	className = "Handgrenade";
    description = "Beacon";
    shapeFile = "mine";
    validateShape = false;
    validateMaterials = false;
    shadowDetailMask = 4;
    explosionId = mineExp;
	explosionRadius = 20.0; 
	damageValue = 0.0; 
	damageType = $MineDamageType;
	kickBackStrength = 550; 
	triggerRadius = 250; 
	maxDamage = 0.0;
};

function Boost::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{ GameBase::setDamageLevel(%this, 2); }

$InvList[Beacon] = 1;

$ItemMax[larmor, Beacon]  = 100;
$ItemMax[marmor, Beacon]  = 175;
$ItemMax[harmor, Beacon]  = 250;
$ItemMax[lfemale, Beacon] = 100;
$ItemMax[mfemale, Beacon] = 175;

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
	if(!$matchStarted)
	{ return; }
	
	if($TG::InfiniteAmmo:Boosts != true)
	{ Player::decItemCount(%player,%item); }
	
	if(%player.throwTime < getSimTime())
	{
		%player.throwTime = getSimTime() + 0.2;
		%obj = newObject("", "Mine", "Boost");
		addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		GameBase::throw(%obj, %player, 0, false);
		Client::sendMessage(Player::getClient(%player), 0, "Speed Boost Used.");
	}
}


//====Begin [TG]ClayMorMine====|
$ItemMax[larmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[marmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[harmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[lfemale, TG::ClayMorMineAmmo] = 35;
$ItemMax[mfemale, TG::ClayMorMineAmmo] = 35;

ItemData TG::ClayMorMineAmmo
{
   description = "Claymor Mine";
   shapeFile = "mineammo";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

function TG::ClayMorMineAmmo::onUse(%player, %item)
{
	if(!$matchStarted)
	{ return; }
	
	%client = Player::getClient(%player);
	%playerTeam = GameBase::getTeam(%player);
	
	if(%player.throwTime < getSimTime())
	{
		Player::decItemCount(%player, %item);
		%obj = newObject("", "Mine", "TG::ClayMorMine");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
		%player.throwTime = getSimTime() + 0.5;
		GameBase::setTeam(%obj, %playerTeam);
	}
}
//====End [TG]ClayMorMine====|


//====Begin Repair Patch====|
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 2;
	validateShape = false;
	validateMaterials = false;
};
function RepairPatch::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player")
	{
		if(GameBase::getDamageLevel(%object))
		{
			GameBase::repairDamage(%object, 0.5);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}
function RepairPatch::onUse(%player,%item)
{ Player::decItemCount(%player,%item); GameBase::repairDamage(%player, 0.1); }
//====End Repair Patch====|


//====Begin Cactus Pack====|
$ItemMax[larmor, cactuspack]  = 1;
$ItemMax[marmor, cactuspack]  = 1;
$ItemMax[harmor, cactuspack]  = 1;
$ItemMax[lfemale, cactuspack] = 1;
$ItemMax[mfemale, cactuspack] = 1;

ItemImageData 	cactuspackImage
{
	shapeFile = "cactus2";
	mountPoint = 2;
	mountOffset = { 0, 0.2, -1.7 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};
ItemData cactusPack
{
	description = "Land Camo";
	shapeFile = "cactus2";
	className = "Backpack";
	heading = $InvHeading[Misc];
	imageType = cactuspackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
//====End Cactus Pack====|
	  


//====Begin Tunneler====|
$InvList[Tunneler] = 1;
$RemoteInvList[Tunneler] = 1;

$ItemMax[larmor, Tunneler]  = 1;
$ItemMax[marmor, Tunneler]  = 1;
$ItemMax[harmor, Tunneler]  = 1;
$ItemMax[lfemale, Tunneler] = 1;
$ItemMax[mfemale, Tunneler] = 1;

ItemData Tunneler
{
   description = "Tunneler";
   shapeFile = "sensor_small";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};
function Tunneler::onUse(%player, %item)
{
	if($matchStarted) 
	{
		GameBase::getLOSinfo(%player, 225);
		GameBase::setPosition(%player, $los::position);
	}
}
//====End Tunneler====|


//====Begin Giveall(); Cheat====|
// NOTE: $TestCheats and $Servercheats variables no longer have 
// ANYTHING to do with this cheat.
function remoteGiveAll(%clientId)
{
	if($TG::GiveallOn != true)
	{ Client::sendMessage(%clientId, 1, "GiveAll Cheat is currently Unavailable.~access_denied.wav"); return; }
	if(!%clientId.GiveallEnabled && !%clientId.isAdmin)
	{ return; }
	// Stock Weapons.
	Player::setItemCount(%clientId, Blaster     ,   1);
	Player::setItemCount(%clientId, PlasmaGun   ,   1);
	Player::setItemCount(%clientId, DoublePlasma,   1);
	Player::setItemCount(%clientId, DiscLauncher,   1);
	Player::setItemCount(%clientId, Mortar      ,   1);
	Player::setItemCount(%clientId, LiLPOOmki   ,   1);
	Player::setItemCount(%clientId, LiLPOOmkii  ,   1);
	Player::setItemCount(%clientId, JailRifle   ,   1);
	Player::setItemCount(%clientId, PlasmaCannon,   1);
	Player::setItemCount(%clientId, TankShredder,   1);
	Player::setItemCount(%clientId, LiLFFB      ,   1);
	Player::setItemCount(%clientId, RepairRifle ,   1);
	Player::setItemCount(%clientId, MineLauncher,   1);
	Player::setItemcount(%clientId, DetPackLauncher,1);
	Player::setItemCount(%clientId, TRocketLauncher,1);
	Player::setItemCount(%clientId, FireballAbility,1);
	Player::setItemCount(%clientId, TankRPGLauncher,1);
	
	// Stock Ammo
	Player::setItemCount(%clientId, BulletAmmo      ,   500);
	Player::setItemCount(%clientId, PlasmaAmmo      ,   999);
	Player::setItemCount(%clientId, DoublePlasmaAmmo,   999);
	Player::setItemCount(%clientId, DiscAmmo        ,   500);
	Player::setItemCount(%clientId, MortarAmmo      ,   500);
	Player::setItemCount(%clientId, LiLPOOmkiAmmo   ,   999);
	Player::setItemCount(%clientId, LiLPOOmkiiAmmo  ,   999);
	Player::setItemCount(%clientId, TankRPGAmmo     ,   500);
	Player::setItemCount(%clientId, TankShredderAmmo,   999);
	Player::setItemCount(%clientId, TRocketLauncherAmmo,999);
	Player::setItemCount(%clientId, FireballAbilityAmmo,999);
	Player::setItemCount(%clientId, MineLauncherAmmo,   500);
	Player::setItemCount(%clientId, LiLFFBAmmo      ,   55);
	Player::setItemcount(%clientId, DetPackLauncherAmmo,15);
	
	// Stock Misc. Items.
	Player::setItemCount(%clientId, Grenade  , 350);
	Player::setItemCount(%clientId, Beacon   , 350);
	Player::setItemCount(%clientId, MineAmmo , 50);
	Player::setItemCount(%clientId, RepairKit, 10);
	Client::sendMessage(%clientId, 3, "Stocking Inventory~wfailpack.wav");
}
//====End Giveall(); Cheat====|