// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from
// the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Obelisk Of Light.ArmorData.cs
//    Obelisk Of Light.baseProjData.cs
//    Obelisk Of Light.item.cs
//    Obelisk Of Light.Nsound.cs
//    Obelisk Of Light.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    Obelisk Of Light.station.cs
//    Obelisk Of Light.turret.cs
//
// to your MiniMod/plugins directory.

LaserData ObeliskBeam
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0125;
   damageType    = $ObeliskDamageType;

   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
