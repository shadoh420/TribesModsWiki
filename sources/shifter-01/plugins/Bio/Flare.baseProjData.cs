// Flare Gun by [BIO]iCE.! and [BIO]EvilBastard (uses a Tool Slot)
// Revised By Dewy.
GrenadeData Flare
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = FlareExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.5;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};
