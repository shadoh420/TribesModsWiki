// Flare Gun by [BIO]iCE.! and [BIO]EvilBastard (uses a Tool Slot) 
ExplosionData FlareExp
{
   shapeName = "tumult_large.dts";
   soundId = SoundFlare;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 100.0;

   timeScale = 60.0;

   timeZero = 0.0;
   timeOne  = 60.0;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 0.5, 0.5, 0.5 };
   colors[2]  = { 0.05, 0.05, 0.05 };
   radFactors = { 0.0, 0.0, 1.0 };
};