// This is a MiniMod Plugin.
// This plugin is the Flame Turret from the Ideal mod.
// Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Flame Turret.ArmorData.cs
//    Flame Turret.baseExpData.cs
//    Flame Turret.baseProjData.cs
//    Flame Turret.item.cs
//    Flame Turret.Nsound.cs
//    Flame Turret.reinitData.cs
//    Flame Turret.staticshape.cs
//    Flame Turret.station.cs
//    Flame Turret.turret.cs
//
// to your MiniMod/plugins directory.

$FlameDamageType       = 25;

RocketData FlameLarge
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = fireExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $FlameDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 10.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange         = 10.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.0;

   soundId = SoundJetHeavy;
};
