// MiniMod plugin
// Fusion Blaster created/ported By, Dewy.

BulletData FusionGunBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = FusionGunExp;
   collisionRadius    = 2.0;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $EnergyDamageType;

   explosionRadius    = 3.0;
   muzzleVelocity     = 5.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime          = 15.0;
   liveTime           = 15.0;
   lightRange         = 5.0;
   lightColor         = { 0.15, 0.15, 1 };
   inheritedVelocityScale = 1.5;
   isVisible          = True;

   rotationPeriod = 0.05;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundJetHeavy;
};

RocketData FusionShell
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag    = FusionGunExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 10.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor         = { 0.15, 0.15, 1 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 50;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};


