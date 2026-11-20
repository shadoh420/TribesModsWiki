//Apex Bomber
$VehicleInvList[BomberVehicle] = 1;
$DataBlockName[BomberVehicle] = Bomber;
$VehicleToItem[Bomber] = Bomber;
$VehicleSlots[Bomber] = 4;

$TeamItemMax[BomberVehicle] = 1;

$DamageScale[Bomber, $ImpactDamageType] = 2.0;		//Due to momentium, ground hurts
$DamageScale[Bomber, $PsiDamageType] = 1.0;
$DamageScale[Bomber, $BulletDamageType] = 0.6;		//Slightly immune to bullets
$DamageScale[Bomber, $PlasmaDamageType] = 1.0;
$DamageScale[Bomber, $EnergyDamageType] = 1.0;
$DamageScale[Bomber, $ExplosionDamageType] = 1.0;
$DamageScale[Bomber, $ShrapnelDamageType] = 1.0;
$DamageScale[Bomber, $DebrisDamageType] = 1.0;
$DamageScale[Bomber, $MissileDamageType] = 1.0;
$DamageScale[Bomber, $LaserDamageType] = 0.5;
$DamageScale[Bomber, $MortarDamageType] = 1.0;
$DamageScale[Bomber, $BlasterDamageType] = 0.5;
$DamageScale[Bomber, $ElectricityDamageType] = 1.0;
$DamageScale[Bomber, $MineDamageType] = 1.0;
$DamageScale[Bomber, $SniperDamageType] = 1.0;
$DamageScale[Bomber, $MeltaDamageType] = 1.0;
$DamageScale[Bomber, $DeathDamageType] = 1.0;
$DamageScale[Bomber, $DDamageType] = 1.0;
$DamageScale[Bomber, $FlamerDamageType] = 1.0;
$DamageScale[Bomber, $ShellDamageType] = 1.0;
$DamageScale[Bomber, $ShurikenDamageType] = 1.0;
$DamageScale[Bomber, $ReaperDamageType] = 1.0;

function vehicleBomber::Initialize()
{
  $TeamItemCount[0 @ BomberVehicle] = 0;
  $TeamItemCount[1 @ BomberVehicle] = 0;
  $TeamItemCount[2 @ BomberVehicle] = 0;
  $TeamItemCount[3 @ BomberVehicle] = 0;
  $TeamItemCount[4 @ BomberVehicle] = 0;
  $TeamItemCount[5 @ BomberVehicle] = 0;
  $TeamItemCount[6 @ BomberVehicle] = 0;
  $TeamItemCount[7 @ BomberVehicle] = 0;
}

GrenadeData A_Bomb
{
     bulletShapeName    = "mortar.dts";
     explosionTag       = largeShockwave;
     collideWithOwner   = True;
     ownerGraceMS       = 250;
     collisionRadius    = 0.3;
     mass               = 5.0;
     elasticity         = 0.1;
  
     damageClass        = 1;       
     damageValue        = 2.5;	//OW!
     damageType         = $MortarDamageType;
  
     explosionRadius    = 50.0;  //BIG boom
     kickBackStrength   = 650.0;
     maxLevelFlightDist = 5;
     totalTime          = 8.0;
     liveTime           = 0.4;
     projSpecialTime    = 0.05;
  
inheritedVelocityScale = 0.5;  //Has to fall to ground
smokeDist              = 8.0;
smokeName              = "fusionex.dts";
};

ItemData BomberVehicle 
{
  description = "Apex Bomber-Terran";
  className = "Vehicle";
  heading = $InvHead[ihTsh];
  price = 1000;
};

FlierData Bomber 
{
  explosionId = flashExpLarge;
  debrisId = flashDebrisLarge;
  className = "Vehicle";
  shapeFile = "hover_apc";
  shieldShapeName = "shield_large";
  mass = 18.0;
  drag = 1.0;
  density = 1.2;
  maxBank = 0.25;
  maxPitch = 0.3;
  maxSpeed = 23;	//Slow as your grandmom :)
  minSpeed = -1;
  lift = 0.4;		//Heavy, remember?
  maxAlt = 15;
  maxVertical = 6;
  maxDamage = 1.8;	//You may want to change this for balance issues.
  damageLevel = {1.0, 1.0};
  maxEnergy = 100;
  accel = 0.20;		//A little slow on the acceleration
  groundDamageScale = 0.125;
  projectileType = A_Bomb;	//Clever name?
  repairRate = 0;
  ramDamage = 2;
  ramDamageType = -1;
  mapFilter = 2;
  mapIcon = "M_vehicle";
  fireSound = SoundFireMortar;	//I hope to get a replacement sound and add it to nsound.cs
  reloadDelay = 7.0;		//Long reload, this is a bomber, remember?
  damageSound = SoundTankCrash;
  visibleToSensor = true; 
  shadowDetailMask = 2;
  mountSound = SoundFlyerMount;
  dismountSound = SoundFlyerDismount;
  idleSound = SoundFlyerIdle;
  moveSound = SoundFlyerActive;
  visibleDriver = true;
  driverPose = 23;
};

function Bomber::onPilot(%this, %player)
{
  //
}

function Bomber::onRemove(%this, %player)
{
  vehicleBomber::Initialize();
}
