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
$MinigunDamageType     = 18; //for the minigun
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

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = plasmaExp;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData MinigunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = turretExp;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $MinigunDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 500.0;
   totalTime          = 0.7;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData M60Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $ChaingunDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData VulcanBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 3;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.12;
   damageType         = $BulletDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 450.0;
   totalTime          = 0.8;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
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

BulletData ShotgunPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.025;
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
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 12;
   aimDeflection      = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $BulletDamageType;

   muzzleVelocity     = 2000;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AssaultChaingunBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $AssaultChaingunDamageType;
   
   

   aimDeflection    = 0.0015;

   explosionRadius  = 2;
   kickBackStrength = 500.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;
};

RocketData FlakBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 15.0;
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
   damageValue      = 2.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 30.0;
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
   trailString = "paint.dts";
   smokeDist   = 2;

   soundId = SoundDiscSpin;
};

BulletData SniperBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1.25;
   damageType         = $SniperDamageType;

   aimDeflection      = 0;
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
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
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
   damageValue        = 0.1;
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

BulletData TachyonBullet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 0;
   damageValue        = 0.70;
   damageType         = $EnergyDamageType2;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

BulletData UFCPellet
{
   bulletShapeName    = "paint.dts";
   explosionTag       = grenadeExp;

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
   explosionTag       = plasmaExp;

   damageClass        = 0;
   damageValue        = 0.25;
   damageType         = $EnergyDamageType2;

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
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

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
   explosionTag       = rocketExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
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
   expRandCycle       = 3;
   mass               = 0.4;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $MagnumDamageType;

   aimDeflection      = 0;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 1;
   damageValue        = 0.60;
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

BulletData AfterburnerBullet
{
   bulletShapeName    = "mortar.dts";
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
   bulletShapeName    = "mortar.dts";
   explosionTag       = turretExp;

   aimDeflection      = 0.01;

   damageClass        = 1;
   damageValue        = 0.175;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 0.4;
   liveTime           = 0.3;
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
   aimDeflection      = 0.005;
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
   explosionTag    = plasmaExp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
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
   trailString = "laserhit.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

BulletData PhaserRifleBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = PhaserRifleExplosion;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $PhaserRifleDamageType;

   muzzleVelocity     = 100.0;
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
   bulletShapeName    = "plasmabolt.dts";
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
   bulletShapeName    = "bullet.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 3.5;

   muzzleVelocity     = 90.0;
   aimDeflection      = 0.00001;
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
   damageValue      = 0.5;
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

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

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
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.0;
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

RocketData TTGBullet
{
   bulletShapeName = "discb.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 5.0;
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
RocketData GravShockBullet
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 5.0;
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
   bulletShapeName    = "fusionex.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;       // no damage
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 5.0;
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
   bulletShapeName = "discb.dts";
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
   trailType   = 1;
   trailLength = 3;
   trailWidth  = 13;

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
   bulletShapeName    = "rocket.dts";
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

   smokeName              = "laserhit.dts";
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

   explosionRadius    = 20.0;
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
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
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
   smokeName              = "fusionbolt.dts";
};

GrenadeData BazookaBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 3000;
   totalTime          = 500.0;
   liveTime           = 0.10;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "smoke.dts";
   smokeDist          = 0.01;
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

   explosionRadius    = 30.0;
   kickBackStrength   = 150;
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
   explosionTag       = mortarExp;
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
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
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
   smokeName	    = "paint.dts";
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
   smokeName	    = "paint.dts";
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
   smokeName	    = "paint.dts";
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
   smokeName	    = "paint.dts";
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
   smokeName	    = "paint.dts";
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
   smokeName	    = "paint.dts";
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
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10;
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
   trailString = "plasmatrail.dts";
   smokeDist   = 1;

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
   damageValue      = 0.4;
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
   trailString = "paint.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData HydraBullet
{
   bulletShapeName  = "plasmabolt.dts";
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
   trailString = "rsmoke.dts";
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

SeekingMissileData HomingTorpedoBullet
{
   bulletShapeName = "rocket.dts";
   explosionTag    = LargeShockwave;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;
   explosionRadius  = 11;
   kickBackStrength = 200.0;

   muzzleVelocity    = 30.0;
   totalTime         = 50;
   liveTime          = 50;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 0.001;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.099;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
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
   laserBitmapName   = "paintpulse.bmp";
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
   laserBitmapName   = "ylite01.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.010;
   damageValue = 0.010;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 7.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};


LaserData GLaserBullet
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.1;
   damageValue = 0.114;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.01;

   lightRange        = 5;
   lightColor        = { 100.0, 100.0, 100.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData FlashlightLaser
{
   laserBitmapName   = "ylite01.bmp";
   hitName           = 0;

   damageConversion = 0.5;
   damageValue = 0.03;

   baseDamageType    = 0;

   beamTime          = 5.0;

   lightRange        = 5;
   lightColor        = { 31, 31, 31 };

   detachFromShooter = false;
   hitSoundId        = SoundJetLight;
};

LaserData AntimatterLaserBullet
{
   laserBitmapName   = "rlite00.bmp";
   hitName           = "laserhit.dts";

   damageValue = 0.1;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 0.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData ALCBullet
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "laserhit.dts"; //make it like the disk explosion

   damageConversion  = 0.075;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 50.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.12;//075;

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
   bitmapName       = "paintpulse.bmp";
   boltLength       = 20.0;
   segmentDivisions = 10;
   beamWidth        = 0.005;

   updateTime   = 45000;
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
			%player.repairRate = 0.40;
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
