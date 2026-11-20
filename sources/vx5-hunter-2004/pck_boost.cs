//================================================================
// Booster Pack
//================================================================
$ItemMax[marmor, Booster1Pack] = 1;
$ItemMax[marmor, Booster2Pack] = 1;
$ItemMax[mfemale, Booster1Pack] = 1;
$ItemMax[mfemale, Booster2Pack] = 1;
//================================================================


///////////////////////////////////////////////////////

///////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////





//=========================================================================
ItemImageData Booster1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 3; 
	mountOffset = { -0.05, -0.15, 0.2 };
	mountRotation = { -1.57, -1.55, 0 }; 

	weaponType = 0; 
	projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster1Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Booster2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 3; 
	mountOffset = { 0.05, -0.15, 0.2 }; 
	mountRotation = { -1.57, 1.55, 0 };

	weaponType = 0;
	projectileType = Booster; 
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.0; 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster2Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//================================================================
echo("booster pack Loaded");