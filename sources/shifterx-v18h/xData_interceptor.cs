SeekingMissileData InterceptorRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;	// 0 impact, 1, radius
   damageValue      = 0.45;
   damageType       = $MissileDamageType;
   explosionRadius  = 4.5;
   kickBackStrength = 100.0;

   muzzleVelocity    = 190.0;	//=== Shifter X - Was: 105.0
   totalTime         = 5;
   liveTime          = 5;
   seekingTurningRadius = 2;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 1.0;

   soundId = SoundJetHeavy;
};

LightningData InterceptorLock
{
	bitmapName       = "lightningNew.bmp";

	damageType       = $GravDamageType;
	boltLength       = 800.0;		//=== Shifter X - Was: 950
	coneAngle        = 45.0;		//=== Shifter X - Was: 30, 26.0
	damagePerSec      = 0.00001;
	energyDrainPerSec = 0;

	segmentDivisions = 1;
	numSegments      = 0;
	beamWidth        = 0.01;
	updateTime   = 150;
	skipPercent  = 0.10;
	displaceBias = 0.25;

	lightRange = 0.1;
	lightColor = { 1, 0, 0 };

//	soundId = SoundELFFire;
};

exec("interceptor.cs");