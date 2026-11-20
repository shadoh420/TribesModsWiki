// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.
//
// To install this plugin just...
// Add:
//
//    SeekerTurret.ArmorData.cs
//    SeekerTurret.baseProjData.cs
//    SeekerTurret.item.cs
//    SeekerTurret.reinitData.cs
//    SeekerTurret.station.cs
//   SeekerTurret.turret.cs
//
// to your MiniMod/plugins directory.
//laserBitmapName   = "paintPulse.bmp"; 
//mortar.dts    shotgunbolt.dts
LaserData SeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";

   damageConversion  = 0.22; //0.02;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.6;//0.70;

   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
