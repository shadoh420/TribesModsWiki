//================================================================
// Booster Pack
//================================================================
$ItemMax[larmor, Booster1Pack] = 1;
$ItemMax[larmor, Booster2Pack] = 1;
$ItemMax[lfemale, Booster1Pack] = 1;
$ItemMax[lfemale, Booster2Pack] = 1;

//================================================================



///////////////////////////////////////////////////////
SoundData boostExplosion
{
   wavFileName = "exp_boost.wav";
   profile = Profile3dMedium;
};

SoundData brakeExplosion
{
   wavFileName = "exp_brake.wav";
   profile = Profile3dMedium;
};

///////////////////////////////////////////////////////
ExplosionData BrakeExp
{
   shapeName = "shield_large.dts";
   soundId   = BrakeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};
///////////////////////////////////////////////////////////
ExplosionData boostExp
{
   shapeName = "exp_vortex.dts";
   soundId   = boostExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 2.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};
///////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////
//================================================================
ItemImageData Booster1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 2; 
	mountOffset = { 0.05, -0.1, 0.2 }; 
	mountRotation = { -1.57, 1.55, 0 }; 
	weaponType = 0; 
	projectileType = undefined;
	minEnergy = 0.01;
	maxEnergy = 0.01;
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.01;
	//lightType = 3;
	//lightRadius = 5; 
	//lightTime = 2; 
	//lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster1Pack 
{ 
	description = "Booster Pack";
	shapeFile = "mortargun";
   	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	showInventory = false;
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
	mountPoint = 2; 
	mountOffset = { -0.05, -0.1, 0.2 };
	mountRotation = { -1.57, -1.55, 0 }; 
	weaponType = 0;
	projectileType = undefined;
	minEnergy = 0.01;
	maxEnergy = 0.01;
	accuFire = true; 
	reloadTime = 0.01; 
	fireTime = 0.0; 
	//lightType = 3; 
	//lightRadius = 5; 
	//lightTime = 2; 
	//lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster2Pack 
{ 
	description = "Booster Pack";
	shapeFile = "mortargun";
   	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	showInventory = false;
	hiliteOnActive = true;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//================================================================
echo("booster pack Loaded");