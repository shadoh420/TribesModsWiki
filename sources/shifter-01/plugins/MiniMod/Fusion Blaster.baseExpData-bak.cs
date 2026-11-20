// MiniMod Plugin...
// Fusion Blaster Created/ported by Dewy

ExplosionData FusionGunExp
{
   shapeName = "shockwave.dts";
   soundId = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.5;

   timeZero = 0.0;
   timeOne  = 2.5;

   colors[0]  = { 0.15, 0.15, 1.0 };
   colors[1]  = { 0.015, 0.015, 0.1 };
   colors[2]  = { 0.0015, 0.0015, 0.01 };
   radFactors = { 0.15, 0.15, 1.0 };
};