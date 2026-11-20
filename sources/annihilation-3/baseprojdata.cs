# Damage Types
#
$ImpactDamageType = -1;
$LandingDamageType = 0;
$BulletDamageType = 1;
$EnergyDamageType = 2;
$PlasmaDamageType = 3;
$ExplosionDamageType = 4;
$ShrapnelDamageType = 5;
$LaserDamageType = 6;	//anything using laser will report back as this type, regardless what its called.. -plasmatic
$MortarDamageType = 7;
$BlasterDamageType = 8;
$ElectricityDamageType = 9;
$CrushDamageType = 10;
$DebrisDamageType = 11;
$MissileDamageType = 12;
$MineDamageType = 13;
$SniperDamageType = 14;
$ShockDamageType = 15;
$ShotgunDamageType = 16;
$AssassinDamageType = 17;
$DisarmDamageType = 18;
$StasisDamageType = 19;
$LucifersMarkType = 20;	//Using this for Hammer marking now -Plasmatic
$TurretVortexDamageType = 21;
$PoisonDamageType = 22;
$JailDamageType = 23;
$ForkImpact = 24;			//New damage type for Pitchfork impack damage -plasmatic 2.2
$SoulDamageType = 25;			//plasmatic
$OSMissileDamageType = 26;		//Plasmatic
$TrollPlasmaDamageType = 27;		//plasmatic
$RocketDamageType = 28;			// new damage type for 2.2 to correctly report rocket damage -plasmatic
$JettingDamage = 29;
$NullDamageType = 30;
$RadiationDamage = 31;	//2/23/2009 7:56PM Plasmatic
//--------------------------------------
BulletData ChaingunBullet
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "bullet.dts";
	validateShape = true;
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
	aimDeflection = 0.005;
	muzzleVelocity = 500.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 2.0;
	tracerLength = 30;
};
BulletData VulcanBullet 
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "bullet.dts";
	validateShape = true;
	explosionTag = VulcanExp;	//blasterExp;	//bulletExp0;
	//collisionRadius = 0.0;
	expRandCycle = 3;
	mass = 0.10;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.15;
	damageType = $BulletDamageType;
	//explosionRadius = 2.0;
	//kickBackStrength = 100.0;
	aimDeflection = 0.010;
	muzzleVelocity = 250.0;
	totalTime = 1.0;
	//liveTime = 18.0;
	inheritedVelocityScale = 1.0;
	isVisible = false;
	tracerPercentage = 3.0;
	tracerLength = 20;
};

BulletData FusionBolt
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	mass = 0.05;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.25;
	damageType = $EnergyDamageType;
	muzzleVelocity = 50.0;
	totalTime = 6.0;
	liveTime = 4.0;
	isVisible = True;
	rotationPeriod = 1.5;
};

BulletData MiniFusionBolt
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.1;
	damageType = $PoisonDamageType;
	muzzleVelocity = 80.0;
	totalTime = 4.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};






BulletData ShotgunBullet 
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "tracer.dts";
	explosionTag = ShotExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.07;
	damageType = $ShotgunDamageType;
	kickBackStrength = 200.0;
	aimDeflection = 0.02;
	muzzleVelocity = 400.0;
	acceleration = 5.0;
	totalTime = 0.5;
	inheritedVelocityScale = 1.0;
	isVisible = true;
	tracerPercentage = 1.0;	//1.0
	tracerLength = 30;
};


BulletData Flames
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "tumult_large.dts";
	explosionTag = flameExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.01;
	muzzleVelocity = 96.0;
	totalTime = 1;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};


BulletData BlastCannonShot
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rocket.dts";
	explosionTag = BlastExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.255;
	damageType = $MissileDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.025;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};



BulletData DisruptorBolt
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "paint.dts";
	explosionTag = disexp;
	damageClass = 1;
	damageValue = 0.35;
	damageType = $DisruptorDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 150.0;
	totalTime = 10.0;
	liveTime = 7;
	lightRange = 3.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

BulletData IrradiationBlast
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "dustplume.dts";
	explosionTag = debrisExpSmall;
	mass = 0.07;
	damageClass = 1; // 0 impact, 1, radius
	explosionRadius = 5.0;
	damageValue = 0.1;
	baseDamageType = $BulletDamageType;
	aimDeflection = 0.0004;
	muzzleVelocity = 180.0;
	totalTime = 2;
	inheritedVelocityScale = 1.0;
	isVisible = True;
};

//--------------------------------------





RocketData IonBolt 
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "enbolt.dts";
	explosionTag = turretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $ElectricityDamageType;
	explosionRadius = 4;
	kickBackStrength = 0.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 1;
	trailLength = 50;
	trailWidth = 0.3;
	soundId = SoundJetHeavy;
};

RocketData VortexBolt 
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortartrail.dts";
	explosionTag = energyExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.01;
	damageType = $TurretVortexDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};




RocketData FlameStrikeBig
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 30.0;
	DamageType = $PlasmaDamageType;
	explosionRadius = 45.0;
	kickBackStrength = 500.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 2.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 9.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 5.0 };
	inheritedVelocityScale = 0.5;
	TrailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="plasmatrail.dts";
	smokeDist = 1.0;
};

RocketData FlameStrikeSmall
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
	explosionTag = PlasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.6;
	DamageType = $PlasmaDamageType;
	explosionRadius = 3.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 100.0;
	acceleration = 2.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 9.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 5.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="laserhit.dts";
	smokeDist = 0.6;
};

RocketData ScoutMissile 
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $ShrapnelDamageType;
	explosionRadius = 20.5;
	kickBackStrength = 450.0;
	muzzleVelocity = 80.0;
	terminalVelocity = 2000.0;
	acceleration = 200.0;
	totalTime = 8.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};



RocketData PlasmaCharge
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "Mortar.dts";
	explosionTag = FireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.30;
	damageType = $PlasmaDamageType;
	explosionRadius = 3.5;
	kickBackStrength = 0.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	liveTime = 1.0;
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="plasmatrail.dts";
	smokeDist = 3.0;
};

RocketData FusionCharge
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "fusionbolt.dts";
	explosionTag = turretExp;
	damageType = 1;
	damageValue = 0.45;
	explosionRadius = 5.0;
	DamageType = $EnergyDamageType;
	liveTime = 4.5;
	totalTime = 4.5;
	lightRange = 1.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0, 0.75 };
	muzzleVelocity = 90.0;
	terminalVelocity = 90.0;
	inheritedVelocityScale = 1.0;
	detachFromShooter = false;
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="shield.dts";
	smokeDist = 10;
};

RocketData NukeShell
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "fusionbolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 60;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 500.0;
	muzzleVelocity = 90.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

RocketData BabyShell
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "fusionbolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;	//10.0
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 60;
	damageType = $MissileDamageType;
	explosionRadius = 15.0;	//9.5;
	kickBackStrength = 500.0;
	muzzleVelocity = 90.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 2.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};
RocketData FlameShell
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
	explosionTag = fireExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 3.0;
	kickBackStrength = 10.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 3.0;
	liveTime = 4.0;
	lightRange = 10.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="plasmabolt.dts";
	smokeDist = 1.0;
	soundId = SoundJetHeavy;
};

RocketData StingerRocket
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $RocketDamageType;		//$MissileDamageType; -plasmatic 2.2
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};



RocketData TankRocket
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $RocketDamageType;		//$MissileDamageType; -plasmatic 2.2
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};



//--------------------------------------

GrenadeData PlasmaBurn
{
//Plasmatic's admin
   bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
   explosionTag       = BurnExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day!   "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};

GrenadeData TrollBurn
{

   bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
   explosionTag       = BurnExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $TrollPlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 0.2; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};

GrenadeData RatPoison
{
//Plasmatic's admin
   bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "plasmabolt.dts";
   explosionTag       = RatPoisonExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};

GrenadeData suicideShell
{
//Plasmatic's admin
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;	//mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};


GrenadeData DropShell
{
//Plasmatic's admin
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};



GrenadeData BombShell
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 50.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 50;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};





GrenadeData MortarTurretShell
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.32;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 400;
	totalTime = 30.0;
	liveTime = 2.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};

GrenadeData FlameSmoke
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rsmoke.dts";
	explosionTag = SmokeFade;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.002;
	mass = -1;
	elasticity = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0;
	damageType = $NullDamageType;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 0;
	totalTime = 1.0; // special meaning for grenades...
	liveTime = 0.75;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "rsmoke.dts";
};


GrenadeData BabyNukeBomb
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "Shockwave_Large.dts";
	explosionTag = WickedBadExp;	//LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 1.0;	//0.3;	// 3.0 fix -Plasm
	mass = 0.0;
	elasticity = 0.2;	//0.2;	//0.4;	2.2 -plas
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 6.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
};



GrenadeData MinerShell
{
//plasmatic
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ShrapnelDamageType; //$MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 20.0;
   liveTime           = 20.0; // grenade time live after contact
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";
};

GrenadeData MineFloaters
{
//plasmatic
   bulletShapeName    = "mine.dts";//mortar
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	//5.0
   elasticity         = 0.45;	//0.1

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; //$MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; // grenade time live after contact
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";//breath.dts";//mortartrail,plastrail
};

GrenadeData PrettySplit
{
//plasmatic
   bulletShapeName    = "shotgunbolt.dts";//grenade.dts
   explosionTag       = AgedonSplitExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;//$PlasmaDamageType;//

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "plasmabolt.dts";//smoke.dts
};




GrenadeData SuicideGren
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 400;
	collisionRadius = 1.0;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1;
	damageValue = 1.9;
	damageType = $MortarDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0;
	maxLevelFlightDist = 1;
	totalTime = 0.1;
	liveTime = 0.1;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.1;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};

GrenadeData ShockShell 
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = Shockwave;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 995.0;
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.10;
	damageType = $ShockDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 1;
	totalTime = 30.0;
	liveTime = 0.01;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.01;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};

GrenadeData TankShockShell 
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.01;
	damageClass = 1;
	damageValue = 0.10;
	damageType = $ShockDamageType;
	explosionRadius = 60.0;		//30
	kickBackStrength = 0.0;
	maxLevelFlightDist = 100;	//1; Troll beacon fix 10/31/2007 4:53AM Plasmatic
	totalTime = 0.1;
	liveTime = 0.1;
	projSpecialTime = 0.1;
	inheritedVelocityScale = 1.0;	//0.01
//	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "mortartrail.dts";
};


//=====================//

ExplosionData smExp
{
   shapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 10;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
GrenadeData JetSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = smExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "rsmoke.dts";
};

//========================//









//===============================================



ExplosionData AnnihilationFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.25, 0.25, 1.0 };
   colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData AnnihilationFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = AnnihilationFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "plasmatrail.dts";
};
//=========================================
//=====================//

ExplosionData ShockedDamageExp
{
   shapeName = "fusionex.dts";	//enex.dts";
   //soundId = shockExplosion;	//soundId = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.00;
   timeOne  = 0.100;

   colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData ShockedDamage
{
   bulletShapeName    = "breath.dts";
   explosionTag       = ShockedDamageExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "rsmoke.dts";
};


ExplosionData ShockJetExp
{
   //shapeName = "plasmatrail.dts";
   shapeName = "fusionex.dts";	//enex.dts";
   soundId = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;
   timeScale = 10;
   timeZero = 0.100;	//0.450;
   timeOne  = 0.150;	//0.750;

   colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.25, 0.25, 1.0 };
   colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = true;
};

GrenadeData ShockJet
{
   bulletShapeName    = "force.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.0;	//0.1; -plasmatic 3.0
   damageType         = $JettingDamage;	//9/5/2003 4:53AM $EnergyDamageType;	//$PlasmaDamageType

   explosionRadius    = 2.5;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "plasmatrail.dts";
};

//plasmatic 2.3
GrenadeData PlasmaShockJet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.0;	//0.00675;//0.0125
   damageType         = $JettingDamage;	//9/6/2003 8:21AM $EnergyDamageType;	//$PlasmaDamageType

   explosionRadius    = 2.5;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.05;	//0.01// special meaning for grenades...
   liveTime           = 0.05;	//0.01
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "plasmatrail.dts";
};

//===========================================



GrenadeData GrenadeLauncherGren
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 350;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.35;
	damageClass = 1;
	damageValue = 0.40;	//0.25
	damageType = $ShrapnelDamageType;
	explosionRadius = 20;	//15
	kickBackStrength = 10.0;
	maxLevelFlightDist = 130;
	totalTime = 12.0;
	liveTime = 1.0;
	projSpecialTime = 0.2;
	inheritedVelocityScale = 0.25;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "plasmatrail.dts";
};


GrenadeData GrenadeLauncherGren1
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 400;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.25;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 150;
	totalTime = 15.0;
	liveTime = 1.0;
	projSpecialTime = 0.3;
	inheritedVelocityScale = 0.35;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "plasmatrail.dts";
};

GrenadeData GrenadeLauncherGren2
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 350;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.35;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 130;
	totalTime = 12.0;
	liveTime = 1.0;
	projSpecialTime = 0.2;
	inheritedVelocityScale = 0.25;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "plasmatrail.dts";
};

GrenadeData GrenadeLauncherGren3
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 300;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.45;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 10.0;
	maxLevelFlightDist = 110;
	totalTime = 9.0;
	liveTime = 1.0;
	projSpecialTime = 0.1;
	inheritedVelocityScale = 0.15;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "plasmatrail.dts";
};

//--------------------------------------
SeekingMissileData TurretMissile
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.65;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 72.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 7.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};



SeekingMissileData StingerMissile
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $RocketDamageType;		//$MissileDamageType; -plasmatic 2.2
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="mortartrail.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

SeekingMissileData TankMissile
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $RocketDamageType;		//$MissileDamageType; -plasmatic 2.2
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! trailString ="mortartrail.dts";
	smokeDist = 2;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------


LaserData SeekerLaser
{
	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!     = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 20.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

LaserData TurretLaser 
{	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!     = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.0065;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = true;	//false;
	hitSoundId = SoundLaserHit;
};

LightningData SoulBolt
{
	bitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!         = "zap03.bmp";	//lightningNew.bmp"; //lightningNew.bmp
   	boltLength       = 50.0;
   	coneAngle        = 50.0;
   	damagePerSec = 10;
   	energyDrainPerSec = 250;
   	segmentDivisions = 6;	//0;
   	numSegments = 8;		//1;
   	beamWidth = 0.4;	//0.25;
   	updateTime   = 30;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   lightRange = 15.0;
   lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 0.85 };
//   	lightRange = 3.0;
//   	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.5, 0.5, 0.5 };
   	isVisible = false;//false
};




LightningData turretCharge
{
	bitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.06;
	energyDrainPerSec = 60.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};




function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	%enVal = %timeSlice * %enDrainPerSec;

	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if(%energy < 0) 
		%energy = 0;
	GameBase::setEnergy(%target, %energy);
}

RepairEffectData RepairBolt
{
	bitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "repairadd.bmp";
	boltLength = 7.5;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.85, 0.25, 0.25 };
};

//modified by Plasmatic to work with admin
function RepairBolt::onAcquire(%this, %player, %target)
{
	if($debug)
		echo("RepairBolt::onAcquire, bolt="@%this@", player="@%player@", target="@ %target);
	
	%client = Player::getClient(%player);
	%player.fixingDisabled = false;
	
	
	if(%target == %player) 
	{
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0) 
		{
			%armor = Player::getArmor(%player);
			%armortype = $ArmorName[%armor];			
			
		//	if(%armortype == iarmorSpy) %player.repairRate = 0.025;
		//	else	
				%player.repairRate = 0.075;
			
				%player.repairTarget = %player;
				Client::sendMessage(%client, 0, "AutoRepair On");
			
		}
		else 
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else 
	{
		%player.repairTarget = %target;
		%player.repairRate = 0.250;
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else if(fixable(%player,%target))
		{
			%target.LastRepairCl =  %client;
			%name = GameBase::getMapName(%target);
			if(%name == "") 
			{
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
			if(GameBase::getTeam(%player)!= GameBase::getTeam(%target))
				%name = "enemy "@%name;		
		}
		else 
		{
			%player.fixingDisabled = true;
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		if(%target.NeedsNewOwner == true && Gamebase::getTeam(%target) == client::GetTeam(%client))
		{
			%name = GameBase::getDataName(%target).description;
			Client::sendMessage(%client,0,%name@": WOOHOO! I'm YOURS Baybeee!");	
			GameBase::playSound(%client, FWooho, 0);
			
			// Remote turrets - kill points to player that deploy them
			client::setOwnedObject(%client, %target);
			%target.deployer = %client; 	//for destroy points, bk messages -plasmatic
			Client::setOwnedObject(%client, %player);
			$TurretList[%target] = %client;	//we're going to disable when client changes team or drops -plasmatic 2.2
			
			Gamebase::setMapName(%target, %name @"(" @ Client::getName(%client) @ ")");
			%target.NeedsNewOwner = false;
		}
		else
			Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}


function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) 
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Client::sendMessage(%client,0,"Repair Done");	
				RepairRewards(%player);
			}
			else 
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if(GameBase::getDamageLevel(%player) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
			else if(GameBase::getLOSInfo(%player,1000) && getObjectType(%object) != "Player")
			{
				%trans = "0 0 0 0 0 0 0 0 0 "@$los::position;
				Projectile::spawnProjectile("nanorepair", %trans, %player, "0 0 0");	

			}
		}
	}
}







// shotgunbolt.dts tracer.dts bullet.dts
GrenadeData Blood
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "shotgunex.dts";
	explosionTag = bloodExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.0;	//0.5;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 0.1;	//8
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 8.0;
	liveTime = 1.0;	//0.1;	//after collision
	projSpecialTime = 0.05;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "breath.dts";	//rsmoke
	smokeDist = 1.5;
};



GrenadeData FieryBlood
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mortar.dts";	//plasammo.dts";
	explosionTag = FierybloodExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.25;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 8.0;
	liveTime = 1.0;	//after collision
	projSpecialTime = 0.01;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "shotgunex.dts";	//mortartrail.dts";	//shotgunex.dts";	//";
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "breath.dts";	//rsmoke
	smokeDist = 1.5;
};


// fork release shocker.. plasmatic 2.3
ExplosionData ForkReleaserExp
{
   shapeName = "plasmaex.dts";	//fusionex.dts";	//enex.dts";
   soundId = SoundForkRelease;	//soundId = energyExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 1;

   timeZero = 0.00;
   timeOne  = 0.100;

   colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

GrenadeData ForkReleaser
{
   bulletShapeName    = "breath.dts";
   explosionTag       = ForkReleaserExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "rsmoke.dts";
};

ExplosionData KickerGrenadeExp
{
	shapeName = "breath.dts";	//plasmaex.dts";
//	soundId = SoundPickupHealth;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 0.0;	//4.0
	timeZero = 0.9;
	timeOne = 0.250;
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.75 };
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};
GrenadeData KickerGrenade
{
//Plasmatic's body blocking
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag       = KickerGrenadeExp;
//	bulletShapeName    = "mortar.dts";
//	explosionTag       = mortarExp;  
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $NullDamageType;

   explosionRadius    = 0.0;	// ann3 -plas
   kickBackStrength   = 0.0;	//50.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.1;
   liveTime           = 0.1; // grenade time live after contact
   projSpecialTime    = 0.8;	//smoke

   inheritedVelocityScale = 1.0;
//   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "smoke.dts";  //mortartrail
};

LaserData ShockwaveEffect
{
	//laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!       = "blue_blink4.bmp";		//"pulse.bmp";
	hitName   	  = "shockwave_large.dts";	//"laserhit.dts";

	damageConversion  = 0.00;		//0.007
	baseDamageType    = $LaserDamageType;

	beamTime          = 0.7;	// This is also the hit animation time. (bitches) -Plasmatic 

//	lightRange        = 2.0;
//	lightColor        = { 1.0, 0.25, 0.25 };

	detachFromShooter = false;	//false to animate properly, how jerkfull. -Plasmatic
//	hitSoundId	= SoundFlierCrash;

};

ExplosionData markerExp
{
	shapeName = "enex.dts";	//breath.dts";	//enex.dts";	//plasmaex.dts";
//	soundId = SoundPickupHealth;
	faceCamera = true;
	randomSpin = false;	//true;
	hasLight = true;
	lightRange = 0.0;	//4.0
	timeZero = 0.9;
	timeOne = 0.250;
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.75 };
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};

GrenadeData markerGrenade
{

	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag       = markerExp;
//	bulletShapeName    = "mortar.dts";
//	explosionTag       = mortarExp;  
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $NullDamageType;

   explosionRadius    = 0.0;	// ann3 -plas
   kickBackStrength   = 0.0;	//50.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.001;
   liveTime           = 0.001; // grenade time live after contact
   projSpecialTime    = 1.0;	//smoke

   inheritedVelocityScale = 0.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail//
};
BulletData MarkerBullet
{
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "enbolt.dts";	//bullet.dts";
//	validateShape = true;
	explosionTag = markerExp;
	expRandCycle = 1;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $BulletDamageType;
	aimDeflection = 0.0;
	muzzleVelocity = 0.1;
	totalTime = 1.0;
	inheritedVelocityScale = 0.0;
	isVisible = false;
	tracerPercentage = 0.0;
	tracerLength = 0;
};
RocketData MarkerRound
{	
//	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";	//bullet.dts";	plasmatic 2.2
	explosionTag = MarkerExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.0;	//0.75
	damageType = $SniperDamageType;		//adjusted this some when I fixed head shot damage -plasmatic
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3.0;	//2000.0;	
	terminalVelocity = 3.0;	//2000.0;
	acceleration = 0.0;
	totalTime = 1.0;
	liveTime = 1.0;
	lightRange = 1.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };	//Blue	//lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.0;
	trailType = 1;
	trailLength = 0;
	trailWidth = 0;
//	soundId = SoundJetHeavy;
};


LaserData MarkerLaser 
{	
	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!     = "paintPulse.bmp";	//laserPulse.bmp";	//blue_blink4.bmp";	//laserPulse.bmp";
//	hitName = "enbolt.dts";	//laserhit.dts";
	damageConversion = 0.0;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.4, 0.4, 1.0 };	//lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = true;	//false;
//	hitSoundId = SoundLaserHit;
};

ExplosionData nanoExp
{
//plasmatic admin
	shapeName = "chainspk.dts";
	//soundId = energyExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne = 0.750;
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 0.25, 0.25 };
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 0.25, 0.25 };
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 0.25, 0.25 };
	radFactors = { 1.0, 1.0, 1.0 };
	shiftPosition = True;
};

GrenadeData nanorepair
{
//Plasmatic's admin
   bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "mine.dts";
   explosionTag       = nanoExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 1.0;
   mass               = 10.0;
   elasticity         = 0.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 300;
   totalTime          = 1.5;
   liveTime           = 1.5; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "mine.dts";//mortartrail
};