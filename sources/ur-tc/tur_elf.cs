//================================================================
//ELF Turret
//================================================================
//=================================================
$DamageScale[marmor, $ElfTDamageType] = 0.5;
$DamageScale[mfemale, $ElfTDamageType] = 0.5;
$DamageScale[marmor, $ElfTDamageType] = 0.5;
$DamageScale[mfemale, $ElfTDamageType] = 0.5;
$DamageScale[harmor, $ElfTDamageType] = 0.5;
//================================================================	
//================================================================
//================================================================
SoundData SoundElfFire
{
   wavFileName = "wpn_elf.wav";
   profile = Profile3dNear;
};
//================================================================
LightningData ELFTurretProj
{
   bitmapName       = "proj_elfturret.bmp";

   damageType       = $ElfTDamageType;
   boltLength       = 50.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.1;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}


//================================================================
TurretData ELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 45;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = ELFTurretProj;
	reloadDelay = 3.0;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};
