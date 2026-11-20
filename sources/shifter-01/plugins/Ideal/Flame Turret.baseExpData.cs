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

ExplosionData fireExp
{
   shapeName = "plasmaex.dts";
   soundId   = bigExplosion2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 4.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 1.0, 1.0,  0.0 };
   colors[1]  = { 1.0, 1.0, 0.75 };
   colors[2]  = { 1.0, 1.0, 0.75 };
   radFactors = { 0.375, 1.0, 0.9 };
};
