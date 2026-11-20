// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.

RocketData FlakShell
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 8.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 1.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
