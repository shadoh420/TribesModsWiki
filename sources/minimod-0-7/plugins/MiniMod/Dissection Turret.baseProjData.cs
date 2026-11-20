// This is a MiniMod Plugin.
// This plugin is the Dissection Turret from the MiniMod.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy.

LaserData DissectionLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.151;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.25;//0.53;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
