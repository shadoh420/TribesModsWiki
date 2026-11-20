LaserData LasMortarBolt
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.1;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = "Undefined";
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 200;
	reloadTime = 12;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 200;
	showWeaponBar = false;
};

GrenadeData LasMortar
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 45.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;
   smokeName              = "mortartrail.dts";
};

ExplosionData IonShockwave
{
   shapeName = "shockwave_large.dts";
   soundId   = bigExplosion1;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 50.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData LasIonExp
{
   shapeName = "fusionex.dts";
   soundId   = bigExplosion1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 30.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0, 0, 1.0 };
   colors[1]  = { 0, 0, 1.0 };
   colors[2]  = { 0, 0, 1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = True;
};

BulletData LasIonBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = LasIonExp;

   damageClass        = 1;
   damageValue        = 8.5;
   damageType         = $MortarDamageType;
   explosionRadius    = 9.0;

   muzzleVelocity     = 250.0;
   totalTime          = 4.0;
   liveTime           = 3.0;

   lightRange         = 1.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.0;
   isVisible          = false;

   rotationPeriod = 1;
};

MineData IonRing
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = IonShockwave;
        explosionRadius = 1.0;
        damageValue = 0;
	damageType = $ElectricityDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.1;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

function IonRing::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

//GrenadeData FlameStrike
//{
//	explosionTag = plasmaExp;
//	collideWithOwner = True;
//	ownerGraceMS = 50;
//	collisionRadius = 10.0;
//	mass = 5.0;
//	elasticity = 0.1;
//	damageClass = 1;
//	damageValue = 0.3;
//	damageType = $PlasmaDamageType;
//	explosionRadius = 8.0;
//	kickBackStrength = 0.1;
//	maxLevelFlightDist = 75;
//	totalTime = 10.0;
//	liveTime = 1.0;
//	projSpecialTime = 0.01;
//	lightRange = 10.0;
//	lightColor = { 1, 1, 0 }; 
//	inheritedVelocityScale = 1.5;
//	smokeName = "plasmatrail.dts";
//	soundId = SoundJetLight;
//};

exec("tool_mortarlaser.cs");