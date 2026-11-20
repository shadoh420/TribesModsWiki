//========================================================================
//::::::::::::::::::::::::::::BEAM TOOLS::::::::::::::::::::::::::::::::::
//========================================================================
addWeapon(Fixit);
addWeapon(Hack);
addWeapon(Tract);
addWeapon(ReTract);
addWeapon(Grap);


$ItemMax[larmor, Grap] = 0;		//Seraph
$ItemMax[lfemale, Grap] = 0;		//Seraph
$ItemMax[earmor, Grap] = 1;		//Slave
$ItemMax[efemale, Grap] = 1;		//Slave
$ItemMax[marmor, Grap] = 0;		//Pawn
$ItemMax[aarmor, Grap] = 1;		//Navigator
$ItemMax[darmor, Grap] = 0;		//Atomizer
$ItemMax[barmor, Grap] = 0;		//Paladin

$ItemMax[larmor, ReTract] = 0;		//Seraph
$ItemMax[lfemale, ReTract] = 0;		//Seraph
$ItemMax[earmor, ReTract] = 1;		//Slave
$ItemMax[efemale, ReTract] = 1;		//Slave
$ItemMax[marmor, ReTract] = 0;		//Pawn
$ItemMax[aarmor, ReTract] = 1;		//Navigator
$ItemMax[darmor, ReTract] = 0;		//Atomizer
$ItemMax[barmor, ReTract] = 0;		//Paladin

$ItemMax[larmor, Tract] = 0;		//Seraph
$ItemMax[lfemale, Tract] = 0;		//Seraph
$ItemMax[earmor, Tract] = 1;		//Slave
$ItemMax[efemale, Tract] = 1;		//Slave
$ItemMax[marmor, Tract] = 0;		//Pawn
$ItemMax[aarmor, Tract] = 1;		//Navigator
$ItemMax[darmor, Tract] = 0;		//Atomizer
$ItemMax[barmor, Tract] = 0;		//Paladin

$ItemMax[larmor, Hack] = 0;		//Seraph
$ItemMax[lfemale, Hack] = 0;		//Seraph
$ItemMax[earmor, Hack] = 1;		//Slave
$ItemMax[efemale, Hack] = 1;		//Slave
$ItemMax[marmor, Hack] = 0;		//Pawn
$ItemMax[aarmor, Hack] = 1;		//Navigator
$ItemMax[darmor, Hack] = 0;		//Atomizer
$ItemMax[barmor, Hack] = 0;		//Paladin

$ItemMax[larmor, Fixit] = 0;		//Seraph
$ItemMax[lfemale, Fixit] = 0;		//Seraph
$ItemMax[earmor, Fixit] = 1;		//Slave
$ItemMax[efemale, Fixit] = 1;		//Slave
$ItemMax[marmor, Fixit] = 0;		//Pawn
$ItemMax[aarmor, Fixit] = 1;		//Navigator
$ItemMax[darmor, Fixit] = 0;		//Atomizer
$ItemMax[barmor, Fixit] = 0;		//Paladin

$AutoUse[Tract] = true;
$AutoUse[Hack] = true;
$AutoUse[Retract] = true;
$AutoUse[Grap] = true;
$AutoUse[Fixit] = true;

$WeaponAmmo[Tract]			= "";
$WeaponAmmo[Hack]			= "";
$WeaponAmmo[Retract]			= "";
$WeaponAmmo[Grap]			= "";
$WeaponAmmo[Fixit]			= "";

$InvList[Grap] = 1;
$InvList[Hack] = 1;
$InvList[Tract] = 1;
$InvList[ReTract] = 1;
$InvList[Fixit] = 1;

//======================================================
//:::::::::::::::::::REPAIR MODE::::::::::::::::::::::::
//======================================================
ItemImageData FixitImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = RepairBolt;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Fixit 
{
	description = "Repair Gun";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "repairpack";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = FixitImage;
	price = 77;
	showWeaponBar = true;
}; 

function Fixit::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Repair Gun");
}

ItemData Backpack 
{
	description = "Backpack";
	showInventory = false;
};
function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot);
	}
} 
//======================================================
//:::::::::::::::::::::HACK MODE::::::::::::::::::::::::
//======================================================
ItemImageData HackImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = HackBolt;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Hack 
{
	description = "Hack Gun";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "repairpack";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = HackImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
}; 

function Hack::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Hack Gun");
}

//======================================================
//:::::::::::::::::::TRACTOR MODE:::::::::::::::::::::::
//======================================================
ItemImageData TractImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = gravCharge;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundSensorPower;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Tract 
{
	description = "Tractor Beam";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "energyRifle";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = TractImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
}; 

function Tract::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Tractor Beam");
}
//======================================================
//:::::::::::::::::::RE-TRACTOR MODE::::::::::::::::::::
//======================================================
ItemImageData RetractImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = antigravCharge;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 3;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundSensorPower;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Retract 
{
	description = "Repulsor Beam";
	className = "Tool";
	shapeFile = "repairgun";
	//hudIcon = "energyRifle";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = RetractImage;
	price = 77;
	showWeaponBar = true;
	showInventory = true;
}; 

function Retract::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Repulsor Beam");
}
//======================================================
//:::::::::::::::::::GRAPPLER MODE::::::::::::::::::::::
//======================================================
ItemImageData Pull
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType =tractorCharge;
	minEnergy = 3;
	maxEnergy = 3;
	reloadTime = 1;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundSensorPower;
};

ItemData Grap
{
	description = "Grappler Beam";
	shapeFile = "shotgun";
	//hudIcon = "energyRifle";
	className = "Tool";
	heading = "dBeam Tools";
	shadowDetailMask = 4;
	imageType = Pull;
	showWeaponBar = true;
	price = 77;
};

function Grap::onMount(%player,%item,$ToolSlot)
{	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Grappler Beam");
}
