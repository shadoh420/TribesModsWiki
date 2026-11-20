// This is a MiniMod Plugin.
// This plugin is the GuardDog (Spotter) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    WatchdogTurret.ArmorData.cs
//    WatchdogTurret.baseProjData.cs
//    WatchdogTurret.item.cs
//    WatchdogTurret.reinitData.cs
//    WatchdogTurret.station.cs
//    WatchdogTurret.turret.cs
//
// to your MiniMod/plugins directory.

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.001; //0.010;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
