# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;

$FusionDamageType      = 14; //for fusion cannon
$QuantumDamageType     = 15; //for the Enterprise E
$EnergyDamageType2     = 16; //for things that damage with energy but need a different death message
$SniperDamageType      = 17; //for the sniper rifle
$BlueDamageType        = 18; //for the minigun
$AvengerDamageType     = 19; //for the A-10
$MagnumDamageType      = 20; //for the .357 Magnum
$GluonDamageType       = 21; //for the gluon gun
$ArwingDamageType      = 22; //for the Arwing
$ColossusDamageType    = 23; //for the GTVA Colossus
$ThermonuclearDamageType = 24; //for the thermonuclear bomb
$RockeyeDamageType     = 25; //for the rockeye
$AssaultChaingunDamageType = 26; //for the Eradicator
$PhaserRifleDamageType = 27; //for the phaser rifle
$PhaserDamageType      = 28; //for the phaser type 10
$ShotgunDamageType     = 29; //for the automatic shotgun
$PulsePhaserDamageType = 30; //for the pulse phaser
$CannonDamageType      = 31; //for the 120mm Cannon
$FirestormDamageType   = 32; //for the firestorm cannon
$FlakDamageType        = 33; //for the flak gun
$UFCDamageType         = 34; //for the UFC
$EMPDamageType         = 35; //for the EMP
//--------------------------------------
RocketData StingerRocket
{	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "snowplume.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//--------------------------------------
SeekingMissileData StingerMissile
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = MortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
      // rocket specific
	trailType = 2;
	trailString = "enex";
	smokeDist = 1;
};
//--------------------------------------
SeekingMissileData TankMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "plasmabolt";
	smokeDist = 1;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
}
//--------------------------------------
GrenadeData BigBoom
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = False;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $BoomDamageType;

   explosionRadius    = 50;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";
};
//----------------------------------------
GrenadeData PlasmaGrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "PlasmaTrail.dts";
};

function blowup3(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","Nbomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","Nbomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function blowup4(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","Nbomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","Nbomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

MineData Nbomb
{
  className = "Mine";
  description = "NapalmEx";
  shapeFile = "plasmabolt";
  shadowDetailMask = 4;
  explosionId = plasmaExp;
  explosionRadius = 3.0;
  damageValue = 0.70;
  damageType = $PlasmaDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData Nbomb2
{
  className = "Mine";
  description = "NapalmEx";
  shapeFile = "plasmabolt";
  shadowDetailMask = 4;
  explosionId = plasmaExp;
  explosionRadius = 3.0;
  damageValue = 0.70;
  damageType = $plasmaDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function Nbomb::onAdd(%this)
{
	schedule("blowup4(" @ %this @ ");",0.3,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

function Nbomb2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function PlasmaGrenadeShell::onAdd(%this)
{
  schedule("blowup3(" @ %this @ ");",1.0,%this);
  schedule("blowup3(" @ %this @ ");",1.2,%this);
  schedule("blowup3(" @ %this @ ");",1.3,%this);
  schedule("blowup3(" @ %this @ ");",1.4,%this);
}


GrenadeData HandHeldRPG
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = smokegrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $FlakDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "tumult_small.dts";
};

function blowup3(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","Dbomb");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","Dbomb");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function blowup4(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","Dbomb2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","Dbomb2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

MineData Dbomb
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "tumult_small";
  shadowDetailMask = 4;
  explosionId = debrisExpLarge;
  explosionRadius = 3.0;
  damageValue = 0.70;
  damageType = $FlakDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData Dbomb2
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "tumult_small";
  shadowDetailMask = 4;
  explosionId = debrisExpLarge;
  explosionRadius = 3.0;
  damageValue = 0.70;
  damageType = $FlakDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function Dbomb::onAdd(%this)
{
	schedule("blowup4(" @ %this @ ");",0.2,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function Dbomb2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

function HandHeldRPG::onAdd(%this)
{
  schedule("blowup3(" @ %this @ ");",1.2,%this);
  schedule("blowup3(" @ %this @ ");",1.4,%this);
  schedule("blowup3(" @ %this @ ");",1.6,%this);
  schedule("blowup3(" @ %this @ ");",1.8,%this);
}

//-------------------------------------------------------
GrenadeData HybridShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};

GrenadeData HybridShell2
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};
//---------------------------------------
RocketData NRocket
{	bulletShapeName = "Mortar.dts";
	explosionTag = DebrisExpLarge;
	collisionRadius = 0.0;
	mass = 1.5;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $FlakDamageType;
	explosionRadius = 5;
	kickBackStrength = 35;
	muzzleVelocity = 120.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 3.0, 0.7, 5.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plastrail.dts";
	smokeDist = 5;
	soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BulletExp2;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.13;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData chainRockets
{	bulletShapeName = "discb.dts";
	explosionTag = TurretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $ExplosionDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "snowplume.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

BulletData ShredderBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp2;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData ALCbullet
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.35;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData MinigunBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
      aimDeflection      = 0.001;
	muzzleVelocity = 900.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData BlastCannonShot
{	bulletShapeName = "shotgunbolt.dts";
	explosionTag = flashExpSmall;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.255;
	damageType = $MissileDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.025;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

RocketData TankRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};

RocketData RPG
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.4;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

RocketData ScoutRocket1
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 3;
	soundId = SoundJetHeavy;
};

RocketData ScoutRocket2
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "smoke.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};

BulletData BlueRageBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = TurretExp;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.16;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 0.7;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AmbushBullet
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = smokerExp;
   expRandCycle       = 0;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData VulcanBullet
{	bulletShapeName = "rocket.dts";
	explosionTag = RocketExp;
	mass = 0.10;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $BulletDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0;
	muzzleVelocity = 355.0;
	totalTime = 10;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData FlierBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 3;
   mass               = 5.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $AvengerDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData HybridRailBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BulletExp0;  
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.5; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};


BulletData ShotgunPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = ShotExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 300.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData MP5Bullet
{
   bulletShapeName    = "bullet.dts";
   //validateShape      = true;
   explosionTag       = shotExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $BulletDamageType;

   //aimDeflection      = 0.0;
   muzzleVelocity     = 5000;
   totalTime          = 100;
   inheritedVelocityScale = 0;
   isVisible          = true;

   //tracerPercentage   = 0;
   //tracerLength       = 0;
};


//--------------------------------------
BulletData M10Bullet
{	bulletShapeName = "smoke.dts";
	explosionTag = smokerExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.85;
	damageType = $BulletDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData AssaultChaingunBullet
{	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $AssaultChaingunDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.01;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

RocketData FlakBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpMedium;

   collisionRadius = 0.0;
   mass            = 1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;
   aimDeflection = 0;
   explosionRadius  = 5.0;
   kickBackStrength = 0.10;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1;

   
   soundId = SoundDiscSpin;
};


BulletData ChargedPlasmaBullet
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = plasmaExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 6;

   muzzleVelocity     = 75.0;
   totalTime          = 111.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   rotationPeriod     = 144.0;
};

RocketData MetreonBullet
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = mortarExp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 100;
   terminalVelocity = 120;
   acceleration     = 1;

   totalTime        = 20.0;
   liveTime         = 21.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 2;

   soundId = SoundDiscSpin;
};

BulletData SniperBullet
{
   bulletShapeName    = "Bullet.dts";
   explosionTag       = ionExp_4;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.25;
   damageType         = $SniperDamageType;

   //aimDeflection      = 0;
   muzzleVelocity     = 1500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 3;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   mass               = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 150.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

BulletData QuantumTorpedo
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = mortarExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $QuantumDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enbolt.dts";
   smokeDist   = 1.8;

   rotationPeriod = 1.5;
};

BulletData SR71Bolt
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   damageClass        = 0;
   damageValue        = 0.075;
   damageType         = $EnergyDamageType2;

   muzzleVelocity     = 100.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData FusionRifleBullet
{
   bulletShapeName = "Shotgunex.dts";
   explosionTag    = FusionRifleExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.60;
   damageType       = $EnergyDamageType2;

   explosionRadius  = 0;
   kickBackStrength = 0;

   muzzleVelocity   = 500.0;
   terminalVelocity = 500.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 1.4, 4, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   //soundId = SoundDiscSpin;
};
//---------------------
BulletData UFCPellet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BlasterExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $UFCDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData FusionCannonBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = FusionCannonExplosion;
   mass               = 0.05;
   explosionRadius    = 50;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5.0;
   damageType         = $FusionDamageType;

   muzzleVelocity     = 30.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData SpeedBikeBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $EnergyDamageType2;
   explosionRadius    = 3.0;

   muzzleVelocity     = 175.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   rotationPeriod = 0.1;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = FusionturretXExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BlasterXExp;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData RFPlasmaBullet
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 400;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData MagnumBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = LargeShockwave;
   mass               = 0.4;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $MagnumDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//-----------------------------------
RocketData NewPlasmaBoltX
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = TurretExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmawall.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};
//--------------------------------------
RocketData PlasmaBolt
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = debrisExpLarge;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

RocketData PlasmaBlasterBolt
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = PlasmaExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

lightningData PlasmaBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.6;
   energyDrainPerSec = 50.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.40;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

BulletData AfterburnerBullet
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 0.4;
   liveTime           = 0.3;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData EngineBullet
{
   bulletShapeName = "bullet.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 51.0;
   acceleration     = 1.0;

   totalTime        = 0.1;
   liveTime         = 10.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 11;
   trailLength = 11;
   trailWidth  = 11;

   soundId = SoundDiscSpin;
};

BulletData RamjetBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = fireExp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 1.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 5.0;
   lightColor         = { 0, 0, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;

   rotationPeriod = 0.1;
};

BulletData FirestormBullet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $FirestormDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 600.0;
   aimDeflection      = 0.001;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData PhasedPlasmaCannonBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = fire3Exp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 300;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

BulletData PhaserRifleBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = ArmExp;

   damageClass        = 0;
   damageValue        = 0.7;
   damageType         = $PhaserRifleDamageType;

   muzzleVelocity     = 9999.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

BulletData PulsePhaserBullet
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = grenadeExp;

   collisionRadius    = 0.0;
   mass               = 1.0;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $PulsePhaserDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 200;

   muzzleVelocity     = 350.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

BulletData PlasmaShotgunBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = PlasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 3.5;

   muzzleVelocity     = 90.0;
   aimDeflection      = 0.01;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};


//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   trailType = 2;
   trailString = "hflame.dts";
   smokeDist = 1;

   soundId = SoundDiscSpin;
};

RocketData AntimatterDiscLauncherBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 10.0;

   totalTime        = 100;
   liveTime         = 100;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

GrenadeData EMPShell 
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = PulseExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 1.0; 
	elasticity = 0.20; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $EMPDamageType; 
	explosionRadius = 40; 
	kickBackStrength = 900.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 0.25; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "Shield.dts"; 
	soundId = SoundELFFire; 
};

RocketData TTGBullet
{
   bulletShapeName = "discb.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};
//--------------------------------------
RocketData KickerBullet
{
   bulletShapeName = "Shield_Large.dts";
   explosionTag    = PulseExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 900.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shotgunex.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData GravShockBullet
{
   bulletShapeName    = "dirarrows.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

//this is just to make it look cooler
RocketData GravShockBullet2
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = LargeShockwave;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;       // no damage
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

RocketData RailgunBullet
{
   bulletShapeName = "paint.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.20;
   damageType       = $BulletDamageType;

   aimDeflection    = 0;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 3;
   trailLength = 3;
   trailWidth  = 3;

   soundId = SoundDiscSpin;
};

RocketData ColossusBullet
{
   bulletShapeName = "discb.dts";
   explosionTag       = rocketExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $ColossusDamageType;

   aimDeflection    = 0.025;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 15.0;
   lightColor       = { 1.0, 0.0, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 4000;
   trailWidth  = 3.0;

   soundId = SoundDiscSpin;
};

RocketData ArwingBullet
{
   bulletShapeName = "rocket.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $ArwingDamageType;

   aimDeflection    = 0.0;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.75;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = grenadeExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 5;
        elasticity = 0.02;
        damageClass = 1;
        damageValue = 0.9;
        damageType = $ShrapnelDamageType;
        explosionRadius = 12;
        kickBackStrength = 100;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 1.5;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "smoke.dts";
        soundId = SoundELFFire;
};
GrenadeData AGLBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "laserhit.dts";
};

GrenadeData Smoker
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = SmokerExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

GrenadeData PGBullet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 20.0;    // special meaning for grenades...
   liveTime           = 15.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData AMMBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 24.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 525;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};

GrenadeData BazookaBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "snowplume.dts";
};
   


GrenadeData ThermonuclearBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 200.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 200.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 500;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "smoke.dts";
   smokeDist          = 0.01;
};


GrenadeData BomberBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 10;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData RepairShellBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.2;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData EnergyBallBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = TimeBombExp;
   collideWithOwner   = false;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 25.0;
   damageType         = $QuantumDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData Suicidebomb2
{
   bulletShapeName    = "generator_p.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 45.0;
   damageType         = $EnergyDamageType2;

   explosionRadius    = 20.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData ClaymoreBullet1
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet3
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 150;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet4
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet5
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet6
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData CannonBullet
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData BlasRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasmabolt.dts";
   smokeDist   = 1.3;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ShieldRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = -500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData GCannonBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 8;
   kickBackStrength = 250.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 210.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 0;
//   trailString = "laserhit.dts";
//   smokeDist   = 0.01;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ScorpianBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData HydraBullet
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 0.2;

   soundId = SoundJetHeavy;
};

RocketData RockeyeBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $RockeyeDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "discb.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};


LaserData sniperLaser
{
   laserBitmapName   = "RPULSE01.bmp";
   hitName           = "shield.dts";

   damageConversion  = 0.80;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundShieldHit;
};
//--------------------------------------
LaserData BeamLaser
{
   laserBitmapName   = "flame.bmp";
   hitname           = "plasmaex.dts";
   damageConversion  = 0.028;
   baseDamageType    = $laserDamageType;
   beamTime          = 2.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};
//----------------------------------------------

LaserData Laser1
{
   laserBitmapName   = "laserpulse.bmp";
   hitname           = "laserhit.dts";
   damageConversion  = 0.5;
   baseDamageType    = $ShockDamageType;
   beamTime          = 2.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};

//--------------------------------------
LaserData GatlaserBeam
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunex.dts";

   damageConversion  = 0.05;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundShieldHit;
};
//--------------------------------------
LaserData GRLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.55;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.10;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundPlasmaTurretOn;
};

LaserData PlasmaLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "Plasmabolt.dts";

   damageConversion  = 0.08;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.4;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundChainTurretOn;
};

LaserData TauLaser
{
   laserBitmapName   = "ylite00.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.025;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.0;

   lightRange        = 10.0;
   lightColor        = { 130.0, 110.0, 50.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData PhaserBullet
{
   laserBitmapName   = "x00.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 75;
   damageValue = 50;

   baseDamageType    = $PhaserDamageType;

   beamTime          = 30.0;

   lightRange        = 10;
   lightColor        = { 40.0, 0.23, 1.0 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData GluonLaser
{
   laserBitmapName   = "blite01.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.002;
   damageValue = 0.002;

   baseDamageType    = $GluonDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 40.0, 35.0, 19.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData CutterBullet
{
   laserBitmapName   = "repairadd.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.025;
   

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 7.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};


LaserData GLaserBullet
{
   laserBitmapName   = "shex03.bmp";
   hitName           = "shotgunbolt.dts"; //make it like the disk explosion

   damageConversion  = 0.060;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData GrapBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 35.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 1000.0;
   segmentDivisions = 1;
   numSegments      = 5;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = 0;
};


BulletData FlameSwordBullet
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = plasmaExp;

   damageClass        = 0;
   damageValue        = 1;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 150.0;
   totalTime          = 0.050;
   liveTime           = 0.025;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

LaserData AntimatterLaserBullet
{
   laserBitmapName   = "rlite00.bmp";
   hitName           = "laserhit.dts";

   damageValue = 0.30;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 0.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData brimBolt1
{
   laserBitmapName   = "mortar1.bmp";
   hitName           = "shield.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.3;

   lightRange        = 1.0;
   lightColor        = { 0.0, 0.0, 4.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData brimBolt2
{
   laserBitmapName   = "mortar1.bmp";
   hitName           = "shield.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.3;

   lightRange        = 1.0;
   lightColor        = { 0.0, 0.0, 4.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

TargetingLaserData TargetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData PlasmaBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 3;
   numSegments      = 3;
   beamWidth        = 0.30;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 8;
   numSegments      = 2;
   beamWidth        = 0.12;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData EMPBullet
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 10.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 30.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};


LightningData TerawattBullet
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 60.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 80.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

RepairEffectData RepairBullet
{
   bitmapName       = "fx_lensflare_3.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.60;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepairing...");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range Max Range 35.5m");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.6;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not in need of medical attention");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being Patched by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Patching " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Complete.");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Completed");
			}
			else {
				Client::sendMessage(%client,0,"Repair Interupted");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = 0;

   damageConversion  = 0; 
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LightningData turretCharge
{
   bitmapName       = "paintpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}


RepairEffectData RepairBolt
{
   bitmapName       = "eflsh5.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 100.0;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
//===================
//Field Repair
//===================
RepairEffectData ToolBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function ToolBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairTarget = %target;
	if(getObjectType(%target) == "Player")
		return false;
	if(getObjectType(%player.repairTarget) != "Player") {
		%player.repairRate = 100.0;
		%name = GameBase::getMapName(%target);
		if(%name == "")
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return false;
		}
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function ToolBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(getObjectType(%object) == "Player")
		return false;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(getObjectType(%object) != "Player") {
			if(GameBase::getDamageLevel(%object) == 0)
				Client::sendMessage(%client,0,"Fixing Done");
			else
				Client::sendMessage(%client,0,"Fixing Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function ToolBolt::checkDone(%this,%player)
{
	if(getObjectType(%player.repairTarget) == "Player")
		return false;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == TB && %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if(getObjectType(%object) != "Player" && GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
	}
}