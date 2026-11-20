# Damage Types
#
$ImpactDamageType      = -1;
$LandingDamageType     =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;	//=== Poison Effect
$PlasmaDamageType      =  3;	//=== On Fire Damage
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
$SniperDamageType      = 14;	//=== Drop Weapon-Flag Damage
$FlashDamageType       = 15;	//=== EMP Damage
$GravDamageType	       = 20;	//=== Shifter X - Damage is ignored (Used with nuke effects)
$ShellDamageType       = 21;
$CloakDamageType       = 22;
$NukeDamageType        = 23;
$NoDamageType          = 99;

//Globals
$hacking = "false";
$Viral = "false";
$isInfected[0] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";
$minInfected = "-1";
$minInfected = "-1";

$RSP::HackTime = "5";
$RSP::HackedTime = "25";
//End Globals


//==================================

SeekingMissileData StingerMissileTracker 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.5;
damageType = $MissileDamageType;
explosionRadius = 8.0;			  //=== Shifter X - Was 8.5?
kickBackStrength = 180.0;             //=== Shifter X - Was: 200.0
muzzleVelocity = 45.0;
terminalVelocity = 60.0;
acceleration = 15.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

RocketData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10;	//20.5
   kickBackStrength = 300.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;


   soundId = SoundJetHeavy;
};

//=======================================================

BulletData AAAShell
{
   bulletShapeName		= "rocket.dts";
   explosionTag			= debrisExpLarge;
   explosionRadius		= 2.5;

   expRandCycle			= 4;
   mass				= 0.05;
   bulletHoleIndex		= 0;

   damageClass			= 1;	// 0 impact, 1 radius
   damageValue			= 0.20;
   damageType			= $ShrapnelDamageType;

   aimDeflection			= 0.008;
   muzzleVelocity			= 325.0;
   totalTime			= 1.0;
   inheritedVelocityScale	= 1.0;
   isVisible			= True;

   tracerPercentage		= 0.0;
   tracerLength			= 1.0;
};

//======================================================================== Sniper Round

RocketData SniperRound
{
   bulletShapeName  = "bullet.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.79;	//=== Shifter X - Was: 0.83, 0.59
   damageType       = $LaserDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;
   soundId = SoundJetHeavy;

   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 10;
};

//======================================================================== Mini-Locking Missle 

SeekingMissileData MiniMissileTracker 
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.3;
damageType = $MissileDamageType;
explosionRadius = 5.5;
kickBackStrength = 200.0;
muzzleVelocity = 45.0;
terminalVelocity = 60.0;
acceleration = 15.0;
totalTime = 20.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 0.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "plasmatrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};

//function SeekingMissile::updateTargetPercentage(%target)
//{
//   return GameBase::virtual(%target, "getHeatFactor");
//}

//======================================================================== ChainGun
//BulletData ChaingunBullet
//{
//   bulletShapeName    = "bullet.dts";
//   explosionTag       = bulletExp0;
//   expRandCycle       = 3;
//   mass               = 0.05;
//   bulletHoleIndex    = 0;

//   damageClass        = 0;       // 0 impact, 1, radius
//   damageValue        = 0.07;    //=== Shifter X - Was: .11
//   damageType         = $BulletDamageType;

//   aimDeflection      = 0.006;   //=== Shifter X - Was: 0.005
//   muzzleVelocity     = 425.0;
//   totalTime          = 1.5;
//   inheritedVelocityScale = 1.0;
//   isVisible          = False;

//   tracerPercentage   = 1.0;
//   tracerLength       = 30;
//};

//======================================================================== Jet Bullet

BulletData JetBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;		// 0 impact, 1, radius
   damageValue        = 0.10;		//=== Shifter X - Was: 0.12
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 1000.0;
   totalTime          = 1.5;		//=== Shifter X - Was: 2
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 0.0;
   tracerLength       = 0;
};

//======================================================================== Vulcan Bullet

BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;		// 0 impact, 1, radius
   damageValue        = 0.023;	//=== Shifter X - Was: 0.02
   damageType         = $BulletDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 800.0;	//=== Shifter X - Was: 900
   totalTime          = 2;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 60;
};

//======================================================================== BoomStickBlast

BulletData BoomStickBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.063;	 //=== Shifter X - Was: 0.08 (*19 shots)
   damageType         = $ShellDamageType;

   aimDeflection      = 0.029;
   muzzleVelocity     = 200.0;
   totalTime          = 1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 2.0;
   tracerLength       = 30;
   soundId = SoundJetLight;
   
};

//======================================================================== Turret Fusion Bolt

BulletData TFusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.28;   //=== Shifter X - Was: 0.27
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 65.0;   //=== Shifter X - Was: 50
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   inheritedVelocityScale = 0.5;

   rotationPeriod = 1.5;
};

//======================================================================== ALPC Fusion Bolt

BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.32;   //=== Shifter X - Was: 0.28
   damageType         = $ImpactDamageType;
   explosionRadius    = 3.5;

   muzzleVelocity     = 175.0;   //=== Shifter X - Was: 150, 115
   totalTime          = 1.3;	//=== Shifter X - Was: 1.75, 3.0
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 0, 0, 1 };
   isVisible          = True;

   inheritedVelocityScale = 0.0;
   rotationPeriod = 1.5;
   soundId = SoundJetLight;
};

//======================================================================== MiniFusionBolt

BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $ImpactDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Blaster Bolt

BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.10;      //=== Shifter X - Was: 0.200
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//======================================================================== Hyper Bolt
BulletData HyperBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.052;	//=== Shifter X - Was: 0.049
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 75.0;
   totalTime          = 0.5;
   liveTime           = 0.4;

   lightRange         = 7.0;
   lightColor         = { 0.25, 0.25, 1.00 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.5;
};

//======================================================================== Jet Bolt

BulletData JetBolt
{
    bulletShapeName    = "bullet.dts";
    explosionTag       = bulletExp0;
    expRandCycle       = 3;
    mass               = 0.05;
    bulletHoleIndex    = 0;
   
    damageClass        = 0;       // 0 impact, 1, radius
    damageValue        = 0.04;
    damageType         = $BulletDamageType;
  
    aimDeflection      = 0.002;
    muzzleVelocity     = 900.0;
    totalTime          = 2;
    inheritedVelocityScale = 2.0;
    isVisible          = False;
   
    tracerPercentage   = 2.0;
    tracerLength       = 160;
};

//======================================================================== Plasma Bolt

BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.48;		//=== Shifter X - Was: 0.45
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
//======================================================================== Plasma Bolt Multi

BulletData PlasmaBoltMulti
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.17;		//=== Shifter X - Was: 0.2
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.5;

   muzzleVelocity     = 175.0;
   totalTime          = 2.5;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid

BulletData PlasmaBoltRapid
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.19;		//=== Shifter X - Was: 0.2
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 180.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Plasma Bolt Rapid2

BulletData PlasmaBoltRapid2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.19;		//=== Shifter X - Was: 0.2
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2.0;

   muzzleVelocity     = 110.0;
   totalTime          = 3.0;
   liveTime           = 1.3;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Flamer Bolt

BulletData FlamerBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.23;	//=== Shifter X - Was: 0.21, 0.19
   damageType         = $PlasmaDamageType;
   explosionRadius    = 2;	//=== Shifter X - Was: 3

   muzzleVelocity     = 33.0;	//=== Shifter X - Was: 30.0
   totalTime          = 0.8;	//=== Shifter X - Was: 0.75
   liveTime           = 0.8;	//=== Shifter X - Was: 0.75
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//======================================================================== Disc Shell

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 75.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//======================================================================== Gimp Missle

RocketData GimpMissile
{
  bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.70;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 60.0;
   terminalVelocity = 2000.0;
   acceleration     = 200.0;
   totalTime        = 8.0;
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

//======================================================================== Grenade Shell

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
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
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//======================================================================== Mortar Shell

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

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//======================================================================== Mortar Turret Shell

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
   smokeName              = "mortartrail.dts";
};


//======================================================================== EMP Mortar Shell

//GrenadeData EMPMortar
//{
//   bulletShapeName    = "mortar.dts";
//   explosionTag       = shockwave;
//   collideWithOwner   = True;
//   ownerGraceMS       = 250;
//   collisionRadius    = 0.3;
//   mass               = 400.0;
//   elasticity         = 0.01;

//  damageClass        = 1;       // 0 impact, 1, radius
//   damageValue        = 0.30;
//   damageType         = $FlashDamageType;

//   explosionRadius    = 35.0;
//   kickBackStrength   = 0.0;
//   maxLevelFlightDist = 275;
//   totalTime          = 30.0;
//   liveTime           = 2.0;
//   projSpecialTime    = 0.01;
//   lightRange       = 5.0;
//   lightColor       = { 1.0, 0.7, 0.5 };
//   inheritedVelocityScale = 0.5;
//   smokeName              = "rsmoke.dts";
//};

GrenadeData EMPMortar
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 100;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.7;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.8;
   damageType         = $MortarDamageType;

   explosionRadius    = 8.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 1500;
   totalTime          = 6.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//======================================================================== EMP Shell

GrenadeData EMPShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Shockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 995.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $FlashDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.01;
   smokeName              = "smoke.dts";
};

//======================================================================== Satchel Shell

GrenadeData SatchelShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.6;
   damageType         = $DebrisDamageType;

   explosionRadius    = 25;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};


//======================================================================== Flier Rocket

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

//======================================================================== Turret Missile

SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;	// 0 impact, 1, radius
   damageValue      = 0.5;	//=== Shifter X - Was: 0.5
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 150.0;	//=== Shifter X - Was: 175.0

   muzzleVelocity    = 103.0;	//=== Shifter X - Was: 105.0
   totalTime         = 7;
   liveTime          = 7;
   seekingTurningRadius    = 7;	//=== Shifter X - Was: 8
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

//======================================================================== Bomber Rocket - LPC rocket

RocketData BomberRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Shockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;	//=== Shifter X - Was: 0.7
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10;	//=== Shifter X - Was: 30
   kickBackStrength = 200.0;

   muzzleVelocity   = 200.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8;
   liveTime         = 17.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Bomber Shell

GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.01;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 2;
   kickBackStrength   = 1.0;
   maxLevelFlightDist = 150;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 5.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

function BomberShell::onAdd(%this)
{
	schedule("DeployBomblets(" @ %this @ ");",1.2,%this);
	schedule("DeployBomblets(" @ %this @ ");",1.7,%this);
	schedule("DeployBomblets(" @ %this @ ");",2.2,%this);
	schedule("DeployBomblets(" @ %this @ ");",2.7,%this);
}

function DeployBomblets(%this) 
{
	if(!%this)	return;

	%obj = newObject("","Mine","Bomblet1");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-20,true);

	%obj = newObject("","Mine","Bomblet2");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-10,true);

	%obj = newObject("","Mine","Bomblet3");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-5,true);
}

//======================================================================== Bomber Nuke

RocketData Nuke
{
  bulletShapeName  = "rocket.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.70;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 60.0;
   terminalVelocity = 2000.0;
   acceleration     = 200.0;
   totalTime        = 8.0;
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

//======================================================================== Shock Blast

RocketData Shock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
  // trailType   = 2;                // smoke trail
  // trailString = "rsmoke.dts";
  // smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Turret Shock

RocketData TurretShock
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 450.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
  // trailType   = 2;                // smoke trail
  // trailString = "rsmoke.dts";
  // smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//======================================================================== Rail Round

RocketData RailRound
{
//   bulletShapeName  = "bullet.dts";
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = bulletExp0;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.72;	//=== Shifter X - Was: 0.75
   damageType       = $LaserDamageType;

   explosionRadius  = 0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 0.6;	//=== Shifter X - Was: 10
   liveTime         = 0.6;	//=== Shifter X - Was: 11
   lightRange       = 10.0;
   lightColor       = { 0.25, 0.25, 1 };
   inheritedVelocityScale = 1.0;

//   trailType   = 1;         
//   trailLength = 5000;
//   trailWidth  = 0.8;	//=== Shifter X - Was: 0.6

     trailType   = 2;                // smoke trail
//     trailString = "snowplume.dts";
//     trailString = "shockwave.dts";
     trailString = "fusionbolt.dts";
     smokeDist   = 2;
     trailLength = 5000;
  
   soundId = SoundJetHeavy;
};

//========================================================================  Ion Bolt

RocketData IonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0;
	mass = 2.0; 
	damageClass = 1; // 0 impact, 1, radius 
	damageValue = 0.2;				//=== Shifter X - Was: 0.23
	damageType = $ElectricityDamageType; 
	explosionRadius = 5;				//=== Shifter X - Was: 6
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 2000.0;
	 acceleration = 500.0; 
	totalTime = 4.5; 		//=== Shifter X - Was: 10.0
	liveTime = 4.0;  		//=== Shifter X - Was: 3.0
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	// rocket specific 
	trailType = 1;
	trailLength = 250; 
	trailWidth = 0.9; 
	soundId = SoundJetHeavy;
};

//======================================================================== Volter Burst

GrenadeData FlameBurst 
{
    explosionTag = plasmaExp;
// 	explosionTag = turretExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.22;
 	damageType = $ElectricityDamageType;
 	explosionRadius = 5.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 75;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	soundId = SoundJetLight;
 };

//======================================
//
// Laser Items
//
//======================================

LaserData sniperLaser
{
  //laserPulse.bmp = origional beam
  //lflame.bmp = 2 side by side blue beams
  //lightningTemp.bmp = multicolor strait beam (white/blue)
  //trailtest.bmp = dark blue beam, no fade
  //warp.bmp = twirling purple beam
  //flame = bland blue beam
  //flare = morphing pink beam
  //plasmabolt.bmp = orange beam

   laserBitmapName   = "warp.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.013;		//=== Shifter X - Was: 0.009
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== 

LaserData turretLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.3;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== 

LaserData LaserTag
{
   laserBitmapName   = "lightningNew.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//======================================================================== 

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;

   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

//======================================================================== Proximity Laser

LaserData proxLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   beamTime          = 0.0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   //hitSoundId        = SoundLaserHit; Silent Attack
};

//======================================================================== ELF Gun

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 90.0;	//=== Shifter X - Was: 100 (1.8H), 40
   coneAngle        = 20.0;	//=== Shifter X - Was: 20 (1.8H), 35
   damagePerSec      = 0.08;	//=== Shifter X - Was: 0.10 (1.8H)
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//======================================================================== 

LightningData lightningCharge2
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//======================================================================== 

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
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

//======================================================================== 

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player)
	{
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
        %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player")
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		
		Client::sendMessage(%client,0,"Repairing " @ %name);
		
		$PlayerRepairing[%player] = "True";												//=== Player Is Repairing
		$PlayerRepairTar[%player] = (GameBase::getDamageLevel(%player.repairTarget));   //=== Amount Of Damage Starting

		//echo ("***  Repair Progress Started " @ $PlayerRepairing[%player] @ " Starting Damage Level = " @ $PlayerRepairTar[%player]);
	}
	
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%client = Player::getClient(%player);

	$PlayerRepairing[%player] = "False";
	//echo ("***  Repair Progress Stopped " @ $PlayerRepairing[%player]);
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
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
	%client = Player::getClient(%player);

//  echo ("*** Checking Repair Progress On Player " @ $PlayerRepairing[%player]);

	if (Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == FixIt) && %target != -1)
	{
		%object = %player.repairTarget;
		
		if (%object == %player)
		{
			if (GameBase::getDamageLevel(%player) == 0)
			{
//				echo ("Repair Stopped - Done");
				$PlayerRepairing[%player] = "False";
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				if ($PlayerRepairing[%player] = True)
				{
						%objname = (GameBase::getDataName(%object)).description;
					
					%objectTeam = GameBase::getTeam(%object);								//=== Team Object.
					%playerTeam = GameBase::getTeam(%player); 								//=== Team Player.
					%lastdamage = GameBase::getControlClient(%object.lastDamageObject);	

					if (%objname == "Remote Mortar Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Ion Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Turret")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Laser Turret")			%pntval = $Score::ObjTurretS;
					else if (%objname == "Point Defense Laser Mine")	%pntval = $Score::ObjTurretS;
					else if (%objname == "EMP Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Satchel Charge")				%pntval = $Score::ObjTurretS;
					else if (%objname == "ELF Turret")					%pntval = $Score::ObjTurretS;
					else if (%objname == "Remote Rocket")				%pntval = $Score::ObjTurretS;
					else if (%objname == "Camera")						%pntval = $Score::ObjTurretS;
					else if (%objname == "Large Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Medium Pulse Sensor")			%pntval = $Score::ObjSensorL;
					else if (%objname == "Motion Sensor")				%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Pulse Sensor")			%pntval = $Score::ObjSensorS;
					else if (%objname == "Remote Sensor Jammer")		%pntval = $Score::ObjSensorS;		
					else if (%objname == "Generator")					%pntval = $Score::ObjGeneratorB;
					else if (%objname == "Solar Panel")					%pntval = $Score::ObjGeneratorS;
					else if (%objname == "Portable Generator")			%pntval = $Score::ObjGeneratorS;		
					else if (%objname == "Ammo Supply Unit")	   		%pntval = $Score::ObjStationA;
					else if (%objname == "Station Supply Unit")			%pntval = $Score::ObjStationS;
					else if (%objname == "Command Station")				%pntval = $Score::ObjStationA;
					else if (%objname == "Remote Ammo Unit")			%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Inv Unit")				%pntval = $Score::ObjStationR;
					else if (%objname == "Remote Command Station")		%pntval = $Score::ObjStationR;
					else if (%objname == "Station Vehicle Unit")		%pntval = $Score::ObjFlier;
					else if (%objname == "Vehicle Pad")					%pntval = $Score::ObjFlier;					

					%bonus = (floor($PlayerRepairTar[%player] * %pntval));
					%score = ($Score::RepairObject + %bonus);
					%lastdamage = $lastdamageobj[%object];
					%lastdpl = GameBase::getControlClient(%object.lastDamageObject);
					%objname = GameBase::getMapName(%object);
					if(%objname == "") 
						%objname = (GameBase::getDataName(%object)).description;					

					if (%lastdpl == %client)
					{
							if ((%objectteam == %playerteam || %objectteam == "-1") && (%object.lastDamageTeam == %playerTeam))
							{
								if ($ScoreOn) bottomprint(%client, "No points awarded, you were the last damager.");						
							}
							else if (%objectteam != %playerTeam)
							{
								%client.score = (%client.score - %score);
								if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score.");
							}
							else if (%this.lastDamageTeam != %playerTeam)
							{
								%client.score = (%client.score + %score);
								if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
							}
					}
					else
					{
						if (%objectteam != %playerTeam)
						{
							%client.score = (%client.score - %score);
							if ($ScoreOn) bottomprint(%client, "You Repaired The Enemys Stuff. Score -" @ %score @ " = " @ %client.score @ " Total Score.");
						}
						else
						{
							%client.score = (%client.score + %score);
							if ($ScoreOn) bottomprint(%client, "Repairing Damage Score +" @ %score @ " = " @ %client.score @ " Total Score");
						}
					}
						
					$PlayerRepairing[%player] = "False";
					Game::refreshClientScore(%client);

				}
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//------------------------------------------------------------------------------------------------
// Hack Gun Beam Used this from the RSP - Is now alternate weapon setting for EngRepairGun
//------------------------------------------------------------------------------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onAcquire(%this, %player, %target)
{
	$Shifter::AllowHacking = "True";
	if($Shifter::AllowHacking)
	{

		%client = Player::getClient(%player);
	
		if (%target != %player)
		{
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player); //added
			%pName = Client::getName(%client); //added
			%tName = getTeamName(%team); //added
			
			if(%name == "")
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
	
			if(%team == %pTeam)
			{
				Client::sendMessage(%client,0,"You can not hack your own " @ %name);	
				return;
			}
				
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player")
			{
				if(getObjectType(%player.repairTarget) == "Player")
				{
					Client::sendMessage(%client,0,"You can not hack another player.");
				}
				else
				{
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
				}
				else
				{
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking = "true";
				if(!$origTeam[%target])
				{
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

function HackBolt::onRelease(%this, %player)
{
	$hacking = false;
}

function checkHackable(%name, %shape)
{
	if(%shape == "generator" || %shape == "generator_p" || %shape == "solar_med" || %shape == "inventory_sta" || %shape == "elevator_4x4"	|| %shape == "elevator_6x6" || %shape == "elevator_6x6_octagon" || %shape == "elevator_8x4" || %shape == "elevator_8x6" || %shape == "elevator_9x9"	|| %shape == "elevator16x16_octo" || %shape == "elevator6X4" || %shape == "elevator_6x5" || %shape == "elevator_8x8" || %shape == "elevator6x4thin"	|| %shape == "elevator6x6thin" || %shape == "elevator_5x5" || %shape == "elevator_4x5" || %shape == "door_top" || %shape == "door_bot"	|| %shape == "newdoor1_l" || %shape == "newdoor1_r" || %shape == "newdoor2_l" || %shape == "newdoor2_r" || %shape == "newdoor3_l"
	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "door_8x8_l" || %shape == "door_8x8_r" || %shape == "forcefield" || %shape == "forcefield_3x4" || %shape == "forcefield_4x17"	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"	|| %shape == "forcefield_4x14" || %shape == "forcefield_4x8" || %shape == "forcefield_5x5" || %shape == "door_4x4_diagonal" || %shape == "tower" || %shape == "camera" || %shape == "hellfiregun" || %shape == "indoorgun" || %shape == "ammounit" || %shape == "sensor_pulse_med" || %shape == "station_cmdpnl" || %shape == "missileturret" || %shape == "cmdpnl" || %shape == "radar" || %shape == "anten_lava")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if(%time > 0)
	{
		if($hacking)
		{		
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else
	{
		if($hacking)
		{
			if($isInfected[%target]) 
			{
				showDeathAnim(%client);
				Player::Kill(%client);
				messageallexcept(%client,0,%pName @ " thought it would be safe to hack the infected " @ %name @ ".");
			
				%randNum = getRandom() * 100;
			
				if(%randNum >= 50)
				{
					$isInfected[%target] = "false";
					Client::sendMessage(%client,0,"The viral infection was destroyed for the price of your life.");
				}
				else
				{
					Client::sendMessage(%client,0,"Your hacking attempt wasn't able to destroy the virus. What a pitiful waste of life.");
				}
				return 1;
			}
			//Client::sendMessage(%client,0,"Welcome " @ %pName @ " :)");
			else
			{
				if(%name == "False" && %shape == "magcargo")
				{

//					%rnd = floor(getRandom() * 10);
//					if(%rnd == 1)
//					{	
//					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
//						Mine::Detonate(" @ %this @ ");
//						return;
//					}
//					else
//					{	
					    Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
//					}


				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					if($RSP::HackedTime)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $RSP::HackedTime);
					}
					else
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "120");
					}
			
					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}
			}
		}
	}
}


//------------------------------------------------------------------------------------------------------------------------
// Disasymbler - Alternate To Engineer Repair Gun.
//------------------------------------------------------------------------------------------------------------------------
RepairEffectData DisaBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 20.0;
   segmentDivisions = 4;
   beamWidth        = 0.3;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.25;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function DisaBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target != %player)
	{
		%player.repairTarget = %target;
		%name = GameBase::getMapName(%target);
		%team = GameBase::getTeam(%target);
		%pTeam = GameBase::getTeam(%player); //added
		%pName = Client::getName(%client); //added
		%tName = getTeamName(%team); //added
		
		if(%name == "")
		{
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}

		%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

		if(%team != %pTeam)
		{
			Client::sendMessage(%client,0,"You can not disassymble another teams " @ %name);	
			return;
		}
			
		if(getObjectType(%player.repairTarget) == "Player")
		{
			Client::sendMessage(%client,0,"You can not disassymble another player.");
		}
		else
		{
			Client::sendMessage(%client,0,"Disassymbling " @ %name @ ". Please wait...");
			%disatime = 5;
			$disassymble[%player] = True;
			objectColapsable(%target, %player, %name, %shape, %disatime);
			echo ("Done.");
		}
	}	
}

function DisaBolt::onRelease(%this, %player)
{
	$disassymble[%player] = false;
}


function removeflagdefpoints(%player)
{
	%client = Player::getClient(%player);
	%client.score = %client.score - $Score::FlagDef;
	if ($ScoreOn) bottomprint(%Client, "Score - " @ $Score::FlagDef @ " = " @ %client.score @ " Total Score, for removing flag defencive." ,3);
	Game::refreshClientScore(%client);
}

function objectColapsable(%this, %player, %name, %shape, %disatime)
{	
	%client = Player::getClient(%player);
	%pos = gamebase::GetPosition (%this);
	%description = %name;
	%playerteam = Client::getTeam(%client);				//== Player Team
	%playerpos = GameBase::getPosition(%player);			//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%pos,%homepos);

	if (Player::getmounteditem(%player, $BackPackSlot) != "-1")
	{
		bottomprint( %client, "<jl><f1> You can not disassymble the " @ %description @ ", drop your current pack first...", 3);
		return 0;
	}

	if ($disassymble[%player])
	{
		if (%disatime > 0)
		{
			%disatime = %disatime - 1;
			schedule ("objectColapsable ( '" @ %this @ "', '" @ %player @ "', '" @ %name @ "', '" @ %shape @ "', '" @ %disatime @ "'); ",1);
			return 0;
		}
	}
	else
	{
		return 0;
	}
	//================================================================================================= Ion Turret
	if (String::findSubStr(%name, "Ion Turret") >= 0)
	{
		%item = "TurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;
		
			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		if (%flagdist < 35) removeflagdefpoints(%player);
		return 1;
	}

	//================================================================================================= Command Station
	else if (String::findSubStr(%name, "Command Station") >= 0)
	{
		%item = "DeployableComPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableComPack"]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		return 1;
	}	
	//================================================================================================= Sensor Jammer
	else if (String::findSubStr(%name, "Sensor Jammer") >= 0)
	{
		%item = "DeployableSensorJammerPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Pulse Sensor
	else if (String::findSubStr(%name, "Pulse Sensor") >= 0)
	{
		%item = "PulseSensorPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Camera 
	else if (String::findSubStr(%name, "Camera") >= 0)
	{
		%item = "CameraPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Blast Wall
	else if (String::findSubStr(%name, "Blast Wall") >= 0)
	{
		%item = "BlastWallPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		
		$disassymble[%player] = false;
		deleteObject(%this);
		return 1;
	}
	//================================================================================================= Rocket Turret
	else if (String::findSubStr(%name, "RMT Rocket") >= 0)
	{
		%item = "RocketPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 100) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Plasma Turret
	else if (String::findSubStr(%name, "RMT Plasma Turret") >= 0)
	{
		%item = "PlasmaTurretPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 35) removeflagdefpoints(%player);
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Elf Turret
	else if (String::findSubStr(%name, "Deployable ELF") >= 0)
	{
		%item = "DeployableElf";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 20) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= EMP Turret
	else if (String::findSubStr(%name, "EMP Turret") >= 0)
	{
		%item = "ShockPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 10) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Remote Mortar
	else if (String::findSubStr(%name, "RMT Mortar Turret") >= 0)
	{
		%item = "TargetPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Laser Turret
	else if (String::findSubStr(%name, "Laser Turret") >= 0)
	{
		%item = "LaserPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Blast Floor
	else if (String::findSubStr(%name, "Blast Floor") >= 0)
	{
		%item = "BlastFloorPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}
	//================================================================================================= Indoor Turret
	else if (String::findSubStr(%name, "Indoor Turret") >= 0)
	{
		%item = "IndoorPack";		
		Client::sendMessage(%client,0,"Disassymbling " @ %name);	  		
  		$TeamItemCount[GameBase::getTeam(%this) @ %item]--;
  		$totalNumTurrets = $totalNumTurrets - 1;

			Player::setItemcount (%client, %item, 1);
			Player::mountItem(%client,%item,$BackpackSlot);
			Item::playPickupSound(%this);

		bottomprint( %client, "<jl><f1> Disassymbling " @ %description @ ".", 3);
		if (%flagdist < 55) removeflagdefpoints(%player);
		
		deleteObject(%this);
		$disassymble[%player] = false;
		return 1;
	}

	Client::sendMessage(%client,0,"Disassymbling " @ %name @ " failed...");
	Player::trigger(%client,$WeaponSlot,false);
	$disassymble[%player] = false;
	return 0;
}

//======================================================================== Grav Charge

LightningData gravCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $GravDamageType;
   boltLength       = 100.0;
   coneAngle        = 40.0;
//   damagePerSec      = 0.01;
   damagePerSec      = 0.0;
   energyDrainPerSec = 1.0;
   segmentDivisions = 2;
//   numSegments      = 1;
   numSegments      = 4;
//   beamWidth        = 0.5;
   beamWidth        = 0.3;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%playerId = %shooterId;

	if (%playerId.GravBolt == "0")
	{
		%velocity = -25;
	}
	else
	{
		%velocity = 25;
	}

		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

//		%damVal = %timeSlice * %damPerSec;
//		%enVal  = %timeSlice * %enDrainPerSec;
//		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
}

//======================================================================== Cloaking Blast

RocketData cloakingBlast
{   
   bulletShapeName = "rocket.dts";
   explosionTag    = shockwave;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $CloakDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 0.01;

   muzzleVelocity   = 2.0;
   terminalVelocity = 2.0;
   acceleration     = 2.0;

   totalTime        = 0.01;
   liveTime         = 0.01;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

// rocket specific

   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;   
};

function cloakingBlast::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
        GameBase::startFadeOut(%target);
        schedule("GameBase::startFadeIn(" @ %target @ ");", 60);
}
