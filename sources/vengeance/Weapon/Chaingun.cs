
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332
//
// Overheating chaingun by Plasmatic
// 

$InvList[ChainGun] = 1;			//1
$MobileInvList[ChainGun] = 1;		//1
$RemoteInvList[ChainGun] = 1;		//1

$InvList[BulletAmmo] = 1;
$MobileInvList[BulletAmmo] = 1;
$RemoteInvList[BulletAmmo] = 1;

$AutoUse[ChainGun] = false;
$WeaponAmmo[ChainGun] = BulletAmmo;
$SellAmmo[BulletAmmo] = 20;

addWeapon(ChainGun);
addAmmo(ChainGun, BulletAmmo, 50);

// shell ejector for rail and ChainGun.. 9/5/2003 8:35AM -plasmatic 2.2
ExplosionData SpentShellExp
{
	shapeName = "tumult_small.dts";
	//soundId = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 1.0, 0.5, 0.16 };
	colors[2] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};
GrenadeData SpentShell
{	bulletShapeName = "force.dts";	//bullet
	explosionTag = SpentShellExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.25;
	elasticity = 0.5;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 2;
	totalTime = 3.0;
	liveTime = 1.0;	//after collision
	projSpecialTime = 0.005;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName = "breath.dts";	//rsmoke
	smokeDist = 0.01;	//1.5;
};

MineData BulletAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};


ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];	//plasmatic
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.15;
	spinDownTime = 3;
	fireTime = 0.01;	//0.01;	//0.2;

	ammoType = BulletAmmo;
//	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chain Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	validateShape = true;
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};


function ChaingunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)]);
	%clientId = Player::getClient(%player);
	if(%AmmoCount > 0)
	{
		if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
		{
			%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
			%vel = Item::getVelocity(%player);
			// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
			if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
			{
				Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),0.165);	//0.15	//0.2
				%trans = GameBase::getMuzzleTransform(%player);
				%heat = (%player.chaingunHeat)/4;	//floor((%player.chaingunHeat)/4);
				
				if(%heat > 9)
					%heat = 9;
		//		%proj = "ChaingunBullet"@%heat;
				if(!$dedicated)
					bottomprint(%clientId,"<jc>heat "@%Heat@" %player.chaingunHeat ="@floor(%player.chaingunHeat));
		//		Projectile::spawnProjectile(%proj,%trans,%player,%vel);
		
			%xrnd = (floor(getRandom() *(%heat*2+1)) - %heat)/100;	
			%yrnd = (floor(getRandom() *(%heat*2+1)) - %heat)/100;	
			%zrnd = (floor(getRandom() *(%heat*2+1)) - %heat)/100;		
				
			%trans1= getWord(%trans,0);
			%trans2= getWord(%trans,1);
			%trans3= getWord(%trans,2);
			%trans4= getWord(%trans,3) + %xrnd;
			%trans5= getWord(%trans,4) + %yrnd;
			%trans6= getWord(%trans,5) + %zrnd;
			%trans7= getWord(%trans,6);
			%trans8= getWord(%trans,7);
			%trans9= getWord(%trans,8);
			%trans10=getWord(%trans,9);
			%trans11=getWord(%trans,10);
			%trans12=getWord(%trans,11);
	
			%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;
	
			Projectile::spawnProjectile("ChaingunBullet", %NewTrans, %player, %vel);		
		
		
				Player::decItemCount(%player,BulletAmmo);
				
				%player.chaingunHeat++;	//add heat for each bullet fired
				
	//			if(%player.chaingunHeat > 35)
	//				Projectile::spawnProjectile("PlasmaShockJet", %trans, %player, %Vel);
			}
			else 	
				echo("!! Butterfly Error, Chaingun. vel ="@%vel);			
		}
		if(!%player.vulcanfiring)
		{
			%player.vulcanfiring = true;
			Player::trigger(%player, 4, true);
			vulcan::ejector(%player);	//plasmatic 2.2
		}
	}
}

function vulcan::Ejector(%player)
{	
	//%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Vulcan]);	
	if(Player::isTriggered(%player,0) && %AmmoCount)
		schedule("vulcan::ejector("@%player@");",0.1);
	else
	{
		schedule("Player::trigger("@%player@", $SpareSlot1, false);",0.1);
		%player.vulcanfiring = false;
	}
}



ItemImageData VulcanEjectorimage
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0.09, 0.05, 0.01 };	//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.5,-1.57, -1.57 };	//0.5,-1.57, -1.57
	accuFire = false;
	projectileType = SpentShell;
	maxEnergy = 0;	//energy/sec

	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 3;
	fireTime = 0.25;
	reloadTime = 0.90;
};

ItemData VulcanEjector
{
	description = "Ejector";
	className = "EyeCandy";
	shapeFile = "force";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VulcanEjectorimage;
	price = 375;
	showWeaponBar = true;
};


//Plasmatic 2.2
function Chaingun::MountExtras(%player,%weapon)
{		
	Player::mountItem(%player,VulcanEjector,$SpareSlot1);
	if(!%player.trackingCGheat)
	{
		%player.trackingCGheat = true;
		Chaingun::checkHeat(%player);
	}
	%client = Player::getclient(%player);
	if(%client.weaponHelp)
		bottomprint(%client, "<jc>"@%weapon.description@": <f2> Fills the air with sharpened toothpicks.", 2);
	
}
function Chaingun::checkHeat(%player)
{
	
	if(Player::getItemCount(%player, chaingun))
	{
	//	echo("chaingun heat " @ %player.chaingunHeat );
		%player.chaingunHeat -= 0.29;	// speed heat is dissipated	0.35	// 0.25	//0.125
		
		if(%player.chaingunHeat < 0) 
			%player.chaingunHeat = 0;
				
		if(Player::getMountedItem(%player,$WeaponSlot) == Chaingun)
		{
			%vel = Item::getVelocity(%player);
			// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
			if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
			{				
				if(%player.chaingunHeat > 10)
				{
					
					%trans = GameBase::getMuzzleTransform(%player);				
					Projectile::spawnProjectile("ChaingunSmoke", %trans, %player, %Vel);
				}
				if(%player.chaingunHeat > 15)
					Projectile::spawnProjectile("ChaingunFlame", %trans, %player, %Vel);	
			}
			else 	
				echo("!! Butterfly Error, Chaingun heat. vel ="@%vel);						
		
			// benificial to keep weapon out in the breeze! -Plasmatic	
			%speed = vector::getdistance(%vel,"0 0 0");	
			if(%speed > 50)
			{
				if(floor(getRandom() * 100) == 1 && %player.chaingunHeat > 10)
					client::sendmessage(Player::getclient(%player),1,"Air cooled!~wfemale1.wtaunt1.wav");
				%player.chaingunHeat -= (%speed-25)/50;	//air cooled, baby -Plasmatic	
			}						
		}
			
		schedule("Chaingun::checkHeat("@%player@");",0.175);	//step speed to reduce heat
	}
	else 
		%player.trackingCGheat = false;
	
}

// The good -Plasmatic
ExplosionData ChaingunSmokeExp
{
   shapeName = "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.010;	//0.100;
   timeOne  = 0.035;	//0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
GrenadeData ChaingunSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = ChaingunSmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;	//0;
   totalTime          = 0.1;	//0.01;    // special meaning for grenades...
   liveTime           = 0.1;		//0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 1.0;
   smokeName              = "rsmoke.dts";
};

// The Bad -Plasmatic
ExplosionData ChaingunFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 1.25;

   timeZero = 0.010;
   timeOne  = 0.035;

//	   colors[0]  = { 0.25, 0.25, 1.0 };
//	   colors[1]  = { 0.25, 0.25, 1.0 };
//	   colors[2]  = { 1.0, 1.0,  1.0 };
//	   radFactors = { 1.0, 1.0,  1.0 };
   colors[0]  = { 1.0, 0, 0 };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };
   
   shiftPosition = true;
};

GrenadeData ChaingunFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = ChaingunFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.5;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 0;	//0 impact, 1 radius
   damageValue        = 0.01;	//0.00675;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0.0;	// Needs to be zero to animate properly for some reason -Plasmatic
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    	//0.01// special meaning for grenades...
   liveTime           = 0.01;		//0.01
   projSpecialTime    = 2.5;	//0.05;

   inheritedVelocityScale = 1.0;

   smokeName              = "plasmatrail.dts";
};

// and The Ugly -Plasmatic
GrenadeData ChaingunExplosion
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.00675;//0.0125
   damageType         = $ShrapnelDamageType;	//9/6/2003 8:21AM $EnergyDamageType;	//$PlasmaDamageType

   explosionRadius    = 2.5;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.15;	//0.01// special meaning for grenades...
   liveTime           = 0.15;	//0.01
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

RocketData ChaingunBullet
{
	bulletShapeName = "bullet.dts";	//tracer.dts";
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;
	explosionRadius  = 0.0;		//7.5;
	kickBackStrength = 50.0;
	muzzleVelocity = 425;		//65.0;
	terminalVelocity = 425.0;
	acceleration = 0.0;
	totalTime = 1.5;
	liveTime = 1.65;
	lightRange  = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 1.0;
	// rocket specific
//	trailType	= 1;
//	trailLength = 50;
//	trailWidth  = 0.15;

	// rocket specific
	trailType   = 2;                // smoke trail
	trailString = "breath.dts";
	smokeDist   = 0.95;	//1.8;
	
	soundId = SoundBulletWhif;	//soundId = SoundDiscSpin;
};

//==================================================
// multiple chaingun projectiles for overheat spreading -Plasmatic
//==================================================

%rootDeflection = 0.00125;
%deflectionStep = 0.00250;

BulletData ChaingunBullet0
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

BulletData ChaingunBullet1
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet2
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet3
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet4
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet5
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet6
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet7
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet8
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};
BulletData ChaingunBullet9
{
	bulletShapeName    = "tracer.dts";	//bullet.dts";		plasmatic
	validateShape      = true;
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.11;
	damageType         = $BulletDamageType;

	aimDeflection      = %rootDeflection += %deflectionStep;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = true;		//plasmatic
	soundId = SoundBulletWhif;	//plasmatic
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};