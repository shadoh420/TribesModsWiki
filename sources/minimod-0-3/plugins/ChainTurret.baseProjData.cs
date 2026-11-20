// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.

BulletData ChaingunTurretBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $CTurretDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
