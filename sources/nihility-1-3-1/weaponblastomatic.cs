//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Steny);
$InvList[Steny] = 1;

$AutoUse[Steny] = True;
$WeaponAmmo[Steny] = "";

$ItemMax[larmor, Steny] = 0;		//Seraph
$ItemMax[lfemale, Steny] = 0;		//Seraph
$ItemMax[earmor, Steny] = 0;		//Slave
$ItemMax[efemale, Steny] = 0;		//Slave
$ItemMax[marmor, Steny] = 0;		//Pawn
$ItemMax[aarmor, Steny] = 0;		//Navigator
$ItemMax[darmor, Steny] = 1;		//Atomizer
$ItemMax[barmor, Steny] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ExplosionData StenExp
{
   shapeName = "paint.dts";
   soundId   = explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

BulletData StenShot
{	bulletShapeName = "paint.dts";
	explosionTag = StenExp;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $ElectricityDamageType;
	explosionRadius = 2.5;
	kickBackStrength = 0.0;
	aimDeflection = 0.025;
	muzzleVelocity = 375.0;
	totalTime = 10.0;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};



BulletData StenCharge
{	bulletShapeName = "paint.dts";
	explosionTag = PlasmaExp;
	mass = 0.05;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $ElectricityDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 375.0;
	totalTime = 0.67;
	liveTime = 0.66;
	isVisible = True;
	rotationPeriod = 1;
};


//--------------------------------------

LightningData EnergyShot
{
   bitmapName       = "lightningNew.bmp";//lightningNew  paintpulse.dts  

   damageType       = $ElectricityDamageType;
   boltLength       = 150.0;
   coneAngle        = 10.0;
   damagePerSec      = 0.023;
   energyDrainPerSec = 0.0;
   
   segmentDivisions = 2;
   numSegments      = 8;
   beamWidth        = 0.2;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 5.0;
   lightColor = { 0.25, 1.0, 0.25 };
   

   soundId = SoundELFFire;
};



//function StenImage::onfire(%player) 
//{ 
//wang(%player);
//}
//
//function wang(%player)
//        {        
//
//%trans = GameBase::getMuzzleTransform(%player);
//%vel = Item::getVelocity(%player);
//        for(%i=0; %i < 10; %i += 1) {
//
//                %xrnd = floor(getRandom() *10)/10 -0.5;
//                %yrnd = floor(getRandom() *10)/10 -0.5;
//                %zrnd = floor(getRandom() *10)/10 -0.5;
//
//                %trans1= getWord(%trans,0);
//                %trans2= getWord(%trans,1);
//                %trans3= getWord(%trans,2);
//                %trans4= getWord(%trans,3) + %xrnd;
//                %trans5= getWord(%trans,4) + %yrnd;
//                %trans6= getWord(%trans,5) + %zrnd;
//                %trans7= getWord(%trans,6);
//                %trans8= getWord(%trans,7);
//                %trans9= getWord(%trans,8);
//                %trans10=getWord(%trans,9);
//                %trans11=getWord(%trans,10);
//                %trans12=getWord(%trans,11);
//                
//        %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;
//
//// targetLaser, sniperLaser -freaky, uses mounted weapon trans
//// turretCharge, MortarShell, TurretMissile, FusionBolt ,discshell -works fine
//        %newObj = Projectile::spawnProjectile("EnergyShot", %NewTrans, %player, %vel);
//        Projectile::spawnProjectile(%newObj);
//        schedule("DeleteLaser(" @ %newObj @ ");", 1.5);
//                        }
//        }
//
//
//function DeleteLaser(%newobj){
//        deleteobject(%newObj);
//}




//================================


ItemImageData StenyImage
{
shapeFile = "plasma";
   mountPoint = 0;
   weaponType = 0;  // Single
   projectileType = StenCharge;
   minEnergy = 4;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
   reloadTime = 0.07;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireBlaster;
};

ItemImageData Steny2Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, 0.12 , 0.17 };
	accuFire = true;
};

ItemImageData Steny3Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
  	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, 0.05 , 0.17 };
	accuFire = true;
};

ItemImageData Steny4Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0.47, 0, 0 };
	mountOffset = { 0.0, -0.02 , 0.17 };
	accuFire = true;
};

ItemData Steny
{
   description = "Blastomatic 3000";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = StenyImage;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny2
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny2Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny3
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny3Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemData Steny4
{
   description = "void";
   shapeFile = "plasma";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Steny4Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

//function Steny::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	%client = Player::getclient(%player);
//        bottomprint(%client, "<jc><f2>Blastomatic 3000");
//
//}

$StenySlotA=4;
$StenySlotB=7;
$StenySlotC=6;

function Steny::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Blastomatic 3000");

	Player::mountItem(%player,steny2,$StenySlotA); 
	Player::mountItem(%player,steny3,$StenySlotB);
	Player::mountItem(%player,steny4,$StenySlotC);
}

function Steny::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$StenySlotA); 
	Player::unmountItem(%player,$StenySlotB); 
	Player::unmountItem(%player,$StenySlotC); 
}