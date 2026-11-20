// Look Through the ProjectileData folder for all the proctiles.
// Files are named to what they have in them, GrenadeData, RocketData, etc..
# Damage Types
#
$ImpactDamageType	    = -1;
$LandingDamageType	    =  0;
$BulletDamageType       =  1;
$EnergyDamageType       =  2;
$PlasmaDamageType       =  3;
$ExplosionDamageType    =  4;
$ShrapnelDamageType     =  5;
$LaserDamageType        =  6;
$MortarDamageType       =  7;
$BlasterDamageType      =  8;
$ElectricityDamageType  =  9;
$CrushDamageType        = 10;
$DebrisDamageType       = 11;
$MissileDamageType      = 12;
$MineDamageType         = 13;
$LiLRocketDamageType    = 14;
$EMPDamageType          = 15;
$LiLPOOmkiiDamageType   = 16;
$SmokeDamageType        = 17;
$MiniELFDamageType      = 18;
$BeamOfPainDamageType   = 19;
$FlashDamageType        = 20;

// These are my added on damage types    Dustin B.
$SniperDamageType       = 21;
$PlasmaCannonDamageType = 22;
$TrapDam1               = 23;
$JailDamageType         = 24;
$FlameDamageType        = 25;
$NukerDamageType        = 26;
$AdminDamageType        = 27;
$ClaymorDamageType      = 28;
$ChainGunDamageType     = 29;
$MeteoroidDamageType    = 30;

// Must call projectiles --->>> AFTER <<<--- their numbers (above) have been defined.

exec("ProjectileData\\GrenadeData.cs");
exec("ProjectileData\\RocketData.cs");
exec("ProjectileData\\BulletData.cs");
exec("ProjectileData\\Laser-LightningData.cs");