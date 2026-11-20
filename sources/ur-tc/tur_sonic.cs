//===================================================================
// Sonic turret
//===================================================================
$DamageScale[larmor, $SonicTDamageType] = 1.0;
$DamageScale[lfemale, $SonicTDamageType] = 1.0;

//===================================================================
SoundData SoundTurSonic
{
   wavFileName = "turret_sonic.wav";
   profile = Profile3dMed;
};
SoundData SoundWhizSonic
{
   wavFileName = "whiz_sonic.wav";
   profile = Profile3dMed;
};
//============================================================
RocketData TurretSonicproj
{
   bulletShapeName  = "proj_sonic.dts";
   explosionTag     = WaveExp;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 1;
   damageValue      = 7;
   damageType       = $SonicTDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 300.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.5, 0.75 };
   inheritedVelocityScale = 0.25;
   trailType   = 2;
   trailString = "shield_medium.dts";
   smokeDist   = 2;
   soundId = SoundWhizSonic;
};
//===================================================================
TurretData SonicTurret
{
	maxDamage = 10.0;
	maxEnergy = 250;
	minGunEnergy = 5;
	maxGunEnergy = 5;
	reloadDelay = 3.0;
	fireSound = SoundTurSonic;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 400;
	gunRange = 400;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "turret_sonic";
	shieldShapeName = "shield_medium";
	speed = 2.75;
	speedModifier = 2.75;
	projectileType = TurretSonicproj;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Sonic Turret";
};
