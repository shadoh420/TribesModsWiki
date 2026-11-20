

DamageSkinData armorDamageSkins 
{ 
bmpName[0] = "dskin1_armor"; 
bmpName[1] = "dskin2_armor"; 
bmpName[2] = "dskin3_armor"; 
bmpName[3] = "dskin4_armor"; 
bmpName[4] = "dskin5_armor"; 
bmpName[5] = "dskin6_armor"; 
bmpName[6] = "dskin7_armor"; 
bmpName[7] = "dskin8_armor"; 
bmpName[8] = "dskin9_armor"; 
bmpName[9] = "dskin10_armor"; 
}; 

//=====================================================================================
//=====================================================================================
//================================= SNIPER ============================================
//=====================================================================================
//=====================================================================================

$DamageScale[larmor, $LandingDamageType] = 1.0; 
$DamageScale[larmor, $ImpactDamageType] = 1.0; 
$DamageScale[larmor, $CrushDamageType] = 1.0; 
$DamageScale[larmor, $BulletDamageType] = 1.2; 
$DamageScale[larmor, $PlasmaDamageType] = 1.0; 
$DamageScale[larmor, $EnergyDamageType] = 1.3; 
$DamageScale[larmor, $ExplosionDamageType] = 1.0; 
$DamageScale[larmor, $MissileDamageType] = 1.0; 
$DamageScale[larmor, $DebrisDamageType] = 1.2; 
$DamageScale[larmor, $ShrapnelDamageType] = 1.2; 
$DamageScale[larmor, $LaserDamageType] = 1.0; 
$DamageScale[larmor, $MortarDamageType] = 1.3; 
$DamageScale[larmor, $BlasterDamageType] = 1.3; 
$DamageScale[larmor, $ElectricityDamageType] = 1.0; 
$DamageScale[larmor, $MineDamageType] = 1.2; 
$DamageScale[larmor, $SniperDamageType] = 1.0; 
$DamageScale[larmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[larmor, Blaster] = 1; 
$ItemMax[larmor, Chaingun] = 1; 
$ItemMax[larmor, Disclauncher] = 1; 
$ItemMax[larmor, GrenadeLauncher] = 1; 
$ItemMax[larmor, Mortar] = 0; 
$ItemMax[larmor, PlasmaGun] = 1; 
$ItemMax[larmor, LaserRifle] = 1; 
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, RocketLauncher] = 0; 
$ItemMax[larmor, SniperRifle] = 1; 
$ItemMax[larmor, WaveGun] = 0; 
$ItemMax[larmor, Railgun] = 1; 
$ItemMax[larmor, Gaussgun] = 0; 
$ItemMax[larmor, Vulcan] = 0; 
$ItemMax[larmor, Silencer] = 0; 
$ItemMax[larmor, Flamer] = 0; 
$ItemMax[larmor, IonGun] = 0;
$ItemMax[larmor, Shotgun] = 0; 
$ItemMax[larmor, TranqGun] = 1; 
$ItemMax[larmor, Napalm] = 0;
$ItemMax[larmor, Omega] = 0;
//=====================================================TOOLS
$ItemMax[larmor, JailGun] = 1; 
$ItemMax[larmor, TargetingLaser] = 1;
$ItemMax[larmor, Fixit] = 0; 
$ItemMax[larmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[larmor, Grenade] = 3; 
$ItemMax[larmor, Beacon] = 1; 
$ItemMax[larmor, Boost] = 3;
$ItemMax[larmor, RepairKit] = 1;  
$ItemMax[larmor, Plastique] = 0; 
$ItemMax[larmor, MineAmmo] = 3; 
//=====================================================AMMO
$ItemMax[larmor, FlamerAmmo] = 0; 
$ItemMax[larmor, ShotgunAmmo] = 10; 
$ItemMax[larmor, BulletAmmo] = 150; 
$ItemMax[larmor, PlasmaAmmo] = 30; 
$ItemMax[larmor, DiscAmmo] = 15; 
$ItemMax[larmor, GrenadeAmmo] = 10; 
$ItemMax[larmor, MortarAmmo] = 10; 
$ItemMax[larmor, RocketAmmo] = 5;
$ItemMax[larmor, MissileAmmo] = 5; 
$ItemMax[larmor, SniperAmmo] = 15; 
$ItemMax[larmor, RailAmmo] = 10; 
$ItemMax[larmor, VulcanAmmo] = 200; 
$ItemMax[larmor, TranqAmmo] = 20; 
$ItemMax[larmor, NapalmAmmo] = 10;
$ItemMax[larmor, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[larmor, EnergyPack] = 1; 
$ItemMax[larmor, RepairPack] = 1; 
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, CloakingDevice] = 0; 
$ItemMax[larmor, StealthShieldPack] = 0;
$ItemMax[larmor, Laptop] = 0;
$ItemMax[larmor, RegenerationPack] = 0; 
$ItemMax[larmor, GasPack] = 0; 
$ItemMax[larmor, OpticPack] = 1; 
$ItemMax[larmor, SMRPack] = 0; 
$ItemMax[larmor, SuicidePack] = 0;
$ItemMax[larmor, SensorJammerPack] = 0; 
//=====================================================SENSORS
$ItemMax[larmor, MotionSensorPack] = 1; 
$ItemMax[larmor, PulseSensorPack] = 1; 
$ItemMax[larmor, DeployableSensorJammerPack] = 1; 
$ItemMax[larmor, CameraPack] = 1; 
$ItemMax[larmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[larmor, DeployablevhclPack] = 0;
$ItemMax[larmor, DeployableInvPack] = 0; 
$ItemMax[larmor, DeployableAmmoPack] = 0; 
$ItemMax[larmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[larmor, TurretPack] = 0; 
$ItemMax[larmor, LaserTurret] = 0;
$ItemMax[larmor, IndoorPack] = 0; 
$ItemMax[larmor, DeployableElfTurret] = 0; 
$ItemMax[larmor, AntiAirPack] = 0; 
$ItemMax[larmor, ShockPack] = 0; 
$ItemMax[larmor, RocketPack] = 0; 
$ItemMax[larmor, LaserPack] = 1;
$ItemMax[larmor, TargetPack] = 0; 
$ItemMax[larmor, RailTurret] = 0; 
$ItemMax[larmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[larmor, ForceFieldPack] = 1;
$ItemMax[larmor, MedffPack] = 0;
$ItemMax[larmor, LargeForceFieldPack] = 0; 
$ItemMax[larmor, TripwirePack] = 0; 
$ItemMax[larmor, newdoorone] = 0;
$ItemMax[larmor, newdoortwo] = 0;
$ItemMax[larmor, newdoorthree] = 0;
$ItemMax[larmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[larmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[larmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[larmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[larmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[larmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[larmor, BlastDoorPack] = 0;
$ItemMax[larmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[larmor, LrgPltPack] = 0;
$ItemMax[larmor, PlatformPack] = 0; 
$ItemMax[larmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[larmor, HoloPack] = 1; 
$ItemMax[larmor, TeleportPack] = 0; 
$ItemMax[larmor, SpringPack] = 0; 
$ItemMax[larmor, jailpack] = 0;
$ItemMax[larmor, JailCapPack] = 0;
$ItemMax[larmor, ArbitorBoxPack] = 0;
$ItemMax[larmor, TreePack] = 1;
$ItemMax[larmor, FlagstandPack] = 0;
$ItemMax[larmor, BuilderPole] = 0;
$ItemMax[larmor, RemoteBase] = 0;
$ItemMax[larmor, SniperHut] = 1;
//=====================================================VEHICLES
$ItemMax[larmor, BigBomberPack] = 1;
$ItemMax[larmor, cloakjetPack] = 1;
$ItemMax[larmor, bomberPack] = 1;
$ItemMax[larmor, MechPack] = 1;
$ItemMax[larmor, DetPack] = 1;

$MaxWeapons[larmor] = 3; 

PlayerData larmor 
{ 
className = "Armor"; 
shapeFile = "larmor"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 12; 
maxJetForwardVelocity = 22; 
minJetEnergy = 1; 
jetForce = 195; 
jetEnergyDrain = 1.05; 
maxDamage = 0.66; 
maxForwardSpeed = 20; 
maxBackwardSpeed = 20; 
maxSideSpeed = 20; 
groundForce = 40 * 9.0; 
mass = 9.0; 
groundTraction = 3.0; 
maxEnergy = 75; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 130; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = {SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft}; 
lFootSounds = {SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft};
footPrints = { 0, 1 }; 
boxWidth = 0.5; 
boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.6666; 
boxCrouchTorsoPercentage = 0.3333; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
};

//=====================================================================================
//=====================================================================================
//============================== SNIPER-FEMALE ========================================
//=====================================================================================
//=====================================================================================

$DamageScale[lfemale, $LandingDamageType] = 1.0; 
$DamageScale[lfemale, $ImpactDamageType] = 1.0; 
$DamageScale[lfemale, $CrushDamageType] = 1.0; 
$DamageScale[lfemale, $BulletDamageType] = 1.2; 
$DamageScale[lfemale, $PlasmaDamageType] = 1.0; 
$DamageScale[lfemale, $EnergyDamageType] = 1.3; 
$DamageScale[lfemale, $ExplosionDamageType] = 1.0; 
$DamageScale[lfemale, $MissileDamageType] = 1.0; 
$DamageScale[lfemale, $ShrapnelDamageType] = 1.2; 
$DamageScale[lfemale, $DebrisDamageType] = 1.2; 
$DamageScale[lfemale, $LaserDamageType] = 1.0; 
$DamageScale[lfemale, $MortarDamageType] = 1.3; 
$DamageScale[lfemale, $BlasterDamageType] = 1.3; 
$DamageScale[lfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[lfemale, $MineDamageType] = 1.2; 
$DamageScale[lfemale, $SniperDamageType] = 1.0; 
$DamageScale[lfemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[lfemale, Blaster] = 1; 
$ItemMax[lfemale, Chaingun] = 1; 
$ItemMax[lfemale, Disclauncher] = 1; 
$ItemMax[lfemale, GrenadeLauncher] = 1; 
$ItemMax[lfemale, Mortar] = 0; 
$ItemMax[lfemale, PlasmaGun] = 1; 
$ItemMax[lfemale, LaserRifle] = 1; 
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, RocketLauncher] = 0; 
$ItemMax[lfemale, SniperRifle] = 1; 
$ItemMax[lfemale, WaveGun] = 0; 
$ItemMax[lfemale, Railgun] = 1; 
$ItemMax[lfemale, Gaussgun] = 0; 
$ItemMax[lfemale, Vulcan] = 0; 
$ItemMax[lfemale, Silencer] = 0; 
$ItemMax[lfemale, Flamer] = 0; 
$ItemMax[lfemale, IonGun] = 0;
$ItemMax[lfemale, Shotgun] = 0; 
$ItemMax[lfemale, TranqGun] = 1; 
$ItemMax[lfemale, Napalm] = 0;
$ItemMax[lfemale, Omega] = 0;
//=====================================================TOOLS
$ItemMax[lfemale, JailGun] = 1; 
$ItemMax[lfemale, TargetingLaser] = 1;
$ItemMax[lfemale, Fixit] = 0; 
$ItemMax[lfemale, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[lfemale, Grenade] = 3; 
$ItemMax[lfemale, Beacon] = 1; 
$ItemMax[lfemale, Boost] = 3;
$ItemMax[lfemale, RepairKit] = 1;  
$ItemMax[lfemale, Plastique] = 0; 
$ItemMax[lfemale, MineAmmo] = 3; 
//=====================================================AMMO
$ItemMax[lfemale, FlamerAmmo] = 0; 
$ItemMax[lfemale, ShotgunAmmo] = 10; 
$ItemMax[lfemale, BulletAmmo] = 150; 
$ItemMax[lfemale, PlasmaAmmo] = 30; 
$ItemMax[lfemale, DiscAmmo] = 15; 
$ItemMax[lfemale, GrenadeAmmo] = 10; 
$ItemMax[lfemale, MortarAmmo] = 10; 
$ItemMax[lfemale, RocketAmmo] = 5;
$ItemMax[lfemale, MissileAmmo] = 5;  
$ItemMax[lfemale, SniperAmmo] = 15; 
$ItemMax[lfemale, RailAmmo] = 10; 
$ItemMax[lfemale, VulcanAmmo] = 200; 
$ItemMax[lfemale, TranqAmmo] = 20; 
$ItemMax[lfemale, NapalmAmmo] = 10;
$ItemMax[lfemale, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[lfemale, EnergyPack] = 1; 
$ItemMax[lfemale, RepairPack] = 1; 
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, CloakingDevice] = 0; 
$ItemMax[lfemale, StealthShieldPack] = 0;
$ItemMax[lfemale, Laptop] = 0;
$ItemMax[lfemale, RegenerationPack] = 0; 
$ItemMax[lfemale, GasPack] = 0; 
$ItemMax[lfemale, OpticPack] = 1; 
$ItemMax[lfemale, SMRPack] = 0; 
$ItemMax[lfemale, SuicidePack] = 0;
$ItemMax[lfemale, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[lfemale, MotionSensorPack] = 1; 
$ItemMax[lfemale, PulseSensorPack] = 1; 
$ItemMax[lfemale, DeployableSensorJammerPack] = 1; 
$ItemMax[lfemale, CameraPack] = 1; 
$ItemMax[lfemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[lfemale, DeployablevhclPack] = 0;
$ItemMax[lfemale, DeployableInvPack] = 0; 
$ItemMax[lfemale, DeployableAmmoPack] = 0; 
$ItemMax[lfemale, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[lfemale, TurretPack] = 0; 
$ItemMax[lfemale, LaserTurret] = 0;
$ItemMax[lfemale, IndoorPack] = 0; 
$ItemMax[lfemale, DeployableElfTurret] = 0; 
$ItemMax[lfemale, AntiAirPack] = 0; 
$ItemMax[lfemale, ShockPack] = 0; 
$ItemMax[lfemale, RocketPack] = 0; 
$ItemMax[lfemale, LaserPack] = 1;
$ItemMax[lfemale, TargetPack] = 0; 
$ItemMax[lfemale, RailTurret] = 0; 
$ItemMax[lfemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[lfemale, ForceFieldPack] = 1;
$ItemMax[lfemale, MedffPack] = 0;
$ItemMax[lfemale, LargeForceFieldPack] = 0; 
$ItemMax[lfemale, TripwirePack] = 0; 
$ItemMax[lfemale, newdoorone] = 0;
$ItemMax[lfemale, newdoortwo] = 0;
$ItemMax[lfemale, newdoorthree] = 0;
$ItemMax[lfemale, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[lfemale, doorthreebyfourForceFieldPack] = 0;
$ItemMax[lfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[lfemale, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[lfemale, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[lfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[lfemale, BlastDoorPack] = 0;
$ItemMax[lfemale, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[lfemale, LrgPltPack] = 0;
$ItemMax[lfemale, PlatformPack] = 0; 
$ItemMax[lfemale, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[lfemale, HoloPack] = 1; 
$ItemMax[lfemale, TeleportPack] = 0; 
$ItemMax[lfemale, SpringPack] = 0; 
$ItemMax[lfemale, jailpack] = 0;
$ItemMax[lfemale, JailCapPack] = 0;
$ItemMax[lfemale, ArbitorBoxPack] = 0;
$ItemMax[lfemale, TreePack] = 1;
$ItemMax[lfemale, FlagstandPack] = 0;
$ItemMax[lfemale, BuilderPole] = 0;
$ItemMax[lfemale, RemoteBase] = 0;
$ItemMax[lfemale, SniperHut] = 1;
//=====================================================VEHICLES
$ItemMax[lfemale, BigBomberPack] = 1;
$ItemMax[lfemale, cloakjetPack] = 1;
$ItemMax[lfemale, bomberPack] = 1;
$ItemMax[lfemale, MechPack] = 1;
$ItemMax[lfemale, DetPack] = 1;

$MaxWeapons[lfemale] = 3;

PlayerData lfemale 
{ 
className = "Armor"; 
shapeFile = "lfemale"; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 12; 
maxJetForwardVelocity = 22; 
minJetEnergy = 1; 
jetForce = 195; 
jetEnergyDrain = 1.05; 
maxDamage = 0.66; 
maxForwardSpeed = 20; 
maxBackwardSpeed = 20; 
maxSideSpeed = 20; 
groundForce = 40 * 9.0; 
mass = 9.0; 
groundTraction = 3.0; 
maxEnergy = 75; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 130; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; 
footPrints = { 0, 1 }; 
boxWidth = 0.5; boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.85; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.88; 
boxCrouchTorsoPercentage = 0.35; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//=====================================================================================
//=====================================================================================
//================================= SCOUT =============================================
//=====================================================================================
//=====================================================================================

$DamageScale[sarmor, $LandingDamageType] = 0.5; 
$DamageScale[sarmor, $ImpactDamageType] = 0.5; 
$DamageScale[sarmor, $CrushDamageType] = 0.5; 
$DamageScale[sarmor, $BulletDamageType] = 1.3; 
$DamageScale[sarmor, $PlasmaDamageType] = 1.2; 
$DamageScale[sarmor, $EnergyDamageType] = 1.3; 
$DamageScale[sarmor, $ExplosionDamageType] = 1.0; 
$DamageScale[sarmor, $MissileDamageType] = 1.0; 
$DamageScale[sarmor, $DebrisDamageType] = 1.2; 
$DamageScale[sarmor, $ShrapnelDamageType] = 1.2; 
$DamageScale[sarmor, $LaserDamageType] = 0.5; 
$DamageScale[sarmor, $MortarDamageType] = 1.5; 
$DamageScale[sarmor, $BlasterDamageType] = 1.3; 
$DamageScale[sarmor, $ElectricityDamageType] = 1.0; 
$DamageScale[sarmor, $MineDamageType] = 1.2; 
$DamageScale[sarmor, $SniperDamageType] = 1.0; 
$DamageScale[sarmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[sarmor, Blaster] = 1; 
$ItemMax[sarmor, Chaingun] = 1; 
$ItemMax[sarmor, Disclauncher] = 1; 
$ItemMax[sarmor, GrenadeLauncher] = 1; 
$ItemMax[sarmor, Mortar] = 0; 
$ItemMax[sarmor, PlasmaGun] = 1; 
$ItemMax[sarmor, LaserRifle] = 1; 
$ItemMax[sarmor, EnergyRifle] = 1;
$ItemMax[sarmor, RocketLauncher] = 0; 
$ItemMax[sarmor, SniperRifle] = 0; 
$ItemMax[sarmor, WaveGun] = 0; 
$ItemMax[sarmor, Railgun] = 0; 
$ItemMax[sarmor, Gaussgun] = 0; 
$ItemMax[sarmor, Vulcan] = 0; 
$ItemMax[sarmor, Silencer] = 0; 
$ItemMax[sarmor, Flamer] = 0; 
$ItemMax[sarmor, IonGun] = 1;
$ItemMax[sarmor, Shotgun] = 0; 
$ItemMax[sarmor, TranqGun] = 0; 
$ItemMax[sarmor, Napalm] = 0;
$ItemMax[sarmor, Omega] = 0;
//=====================================================TOOLS
$ItemMax[sarmor, JailGun] = 1; 
$ItemMax[sarmor, TargetingLaser] = 1;
$ItemMax[sarmor, Fixit] = 0; 
$ItemMax[sarmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[sarmor, Grenade] = 5; 
$ItemMax[sarmor, Beacon] = 5; 
$ItemMax[sarmor, Boost] = 5;
$ItemMax[sarmor, RepairKit] = 1;  
$ItemMax[sarmor, Plastique] = 0; 
$ItemMax[sarmor, MineAmmo] = 3; 
//=====================================================AMMO
$ItemMax[sarmor, FlamerAmmo] = 0; 
$ItemMax[sarmor, ShotgunAmmo] = 10; 
$ItemMax[sarmor, BulletAmmo] = 100; 
$ItemMax[sarmor, PlasmaAmmo] = 30; 
$ItemMax[sarmor, DiscAmmo] = 15; 
$ItemMax[sarmor, GrenadeAmmo] = 10; 
$ItemMax[sarmor, MortarAmmo] = 10; 
$ItemMax[sarmor, RocketAmmo] = 10;
$ItemMax[sarmor, MissileAmmo] = 5;  
$ItemMax[sarmor, SniperAmmo] = 15; 
$ItemMax[sarmor, RailAmmo] = 15; 
$ItemMax[sarmor, VulcanAmmo] = 300; 
$ItemMax[sarmor, TranqAmmo] = 20; 
$ItemMax[sarmor, NapalmAmmo] = 10;
$ItemMax[sarmor, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[sarmor, EnergyPack] = 1; 
$ItemMax[sarmor, RepairPack] = 1; 
$ItemMax[sarmor, ShieldPack] = 1;
$ItemMax[sarmor, AmmoPack] = 1;
$ItemMax[sarmor, CloakingDevice] = 0; 
$ItemMax[sarmor, StealthShieldPack] = 0;
$ItemMax[sarmor, Laptop] = 0;
$ItemMax[sarmor, RegenerationPack] = 0; 
$ItemMax[sarmor, GasPack] = 0; 
$ItemMax[sarmor, OpticPack] = 0; 
$ItemMax[sarmor, SMRPack] = 0; 
$ItemMax[sarmor, SuicidePack] = 0; 
$ItemMax[sarmor, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[sarmor, MotionSensorPack] = 1; 
$ItemMax[sarmor, PulseSensorPack] = 1; 
$ItemMax[sarmor, DeployableSensorJammerPack] = 1; 
$ItemMax[sarmor, CameraPack] = 1; 
$ItemMax[sarmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[sarmor, DeployablevhclPack] = 0;
$ItemMax[sarmor, DeployableInvPack] = 0; 
$ItemMax[sarmor, DeployableAmmoPack] = 0; 
$ItemMax[sarmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[sarmor, TurretPack] = 0; 
$ItemMax[sarmor, LaserTurret] = 0;
$ItemMax[sarmor, IndoorPack] = 0; 
$ItemMax[sarmor, DeployableElfTurret] = 0; 
$ItemMax[sarmor, AntiAirPack] = 0; 
$ItemMax[sarmor, ShockPack] = 0; 
$ItemMax[sarmor, RocketPack] = 0; 
$ItemMax[sarmor, LaserPack] = 1;
$ItemMax[sarmor, TargetPack] = 0; 
$ItemMax[sarmor, RailTurret] = 0; 
$ItemMax[sarmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[sarmor, ForceFieldPack] = 0;
$ItemMax[sarmor, MedffPack] = 0;
$ItemMax[sarmor, LargeForceFieldPack] = 0; 
$ItemMax[sarmor, TripwirePack] = 0; 
$ItemMax[sarmor, newdoorone] = 0;
$ItemMax[sarmor, newdoortwo] = 0;
$ItemMax[sarmor, newdoorthree] = 0;
$ItemMax[sarmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[sarmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[sarmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[sarmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[sarmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[sarmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[sarmor, BlastDoorPack] = 0;
$ItemMax[sarmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[sarmor, LrgPltPack] = 0;
$ItemMax[sarmor, PlatformPack] = 0; 
$ItemMax[sarmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[sarmor, HoloPack] = 1; 
$ItemMax[sarmor, TeleportPack] = 0; 
$ItemMax[sarmor, SpringPack] = 0; 
$ItemMax[sarmor, jailpack] = 0;
$ItemMax[sarmor, JailCapPack] = 0;
$ItemMax[sarmor, ArbitorBoxPack] = 0;
$ItemMax[sarmor, TreePack] = 1;
$ItemMax[sarmor, FlagstandPack] = 0;
$ItemMax[sarmor, BuilderPole] = 0;
$ItemMax[sarmor, RemoteBase] = 0;
$ItemMax[sarmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[sarmor, BigBomberPack] = 1;
$ItemMax[sarmor, cloakjetPack] = 1;
$ItemMax[sarmor, bomberPack] = 1;
$ItemMax[sarmor, MechPack] = 1;
$ItemMax[sarmor, DetPack] = 1;

$MaxWeapons[sarmor] = 2;

PlayerData sarmor 
{ 
className = "Armor"; 
shapeFile = "larmor"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 150; 
minJetEnergy = 1; 
jetForce = 425; 
jetEnergyDrain = 0.1; 
maxDamage = 0.6; 
maxForwardSpeed = 10; 
maxBackwardSpeed = 10; 
maxSideSpeed = 10; 
groundForce = 40 * 9.0; 
mass = 9.0; 
groundTraction = 4.0; 
maxEnergy = 30; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 125; 
damageScale = 0.005; 
jumpImpulse = 95; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; 
footPrints = { 0, 1 }; 
boxWidth = 0.5; 
boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.6666; 
boxCrouchTorsoPercentage = 0.3333; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//================================================================================
//================================================================================
//=============================== SCOUT-FEMALE ===================================
//================================================================================
//================================================================================

$DamageScale[sfemale, $LandingDamageType] = 0.5; 
$DamageScale[sfemale, $ImpactDamageType] = 0.5; 
$DamageScale[sfemale, $CrushDamageType] = 0.5; 
$DamageScale[sfemale, $BulletDamageType] = 1.3; 
$DamageScale[sfemale, $PlasmaDamageType] = 1.2; 
$DamageScale[sfemale, $EnergyDamageType] = 1.3; 
$DamageScale[sfemale, $ExplosionDamageType] = 1.0; 
$DamageScale[sfemale, $MissileDamageType] = 1.0; 
$DamageScale[sfemale, $ShrapnelDamageType] = 1.2; 
$DamageScale[sfemale, $DebrisDamageType] = 1.2; 
$DamageScale[sfemale, $LaserDamageType] = 0.5; 
$DamageScale[sfemale, $MortarDamageType] = 1.5; 
$DamageScale[sfemale, $BlasterDamageType] = 1.3; 
$DamageScale[sfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[sfemale, $MineDamageType] = 1.2; 
$DamageScale[sfemale, $SniperDamageType] = 1.0; 
$DamageScale[sfemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[sfemale, Blaster] = 1; 
$ItemMax[sfemale, Chaingun] = 1; 
$ItemMax[sfemale, Disclauncher] = 1; 
$ItemMax[sfemale, GrenadeLauncher] = 1; 
$ItemMax[sfemale, Mortar] = 0; 
$ItemMax[sfemale, PlasmaGun] = 1; 
$ItemMax[sfemale, LaserRifle] = 1; 
$ItemMax[sfemale, EnergyRifle] = 1;
$ItemMax[sfemale, RocketLauncher] = 0; 
$ItemMax[sfemale, SniperRifle] = 0; 
$ItemMax[sfemale, WaveGun] = 0; 
$ItemMax[sfemale, Railgun] = 0; 
$ItemMax[sfemale, Gaussgun] = 0; 
$ItemMax[sfemale, Vulcan] = 0; 
$ItemMax[sfemale, Silencer] = 0; 
$ItemMax[sfemale, Flamer] = 0; 
$ItemMax[sfemale, IonGun] = 1;
$ItemMax[sfemale, Shotgun] = 0; 
$ItemMax[sfemale, TranqGun] = 0; 
$ItemMax[sfemale, Napalm] = 0;
$ItemMax[sfemale, Omega] = 0;
//=====================================================TOOLS
$ItemMax[sfemale, JailGun] = 1; 
$ItemMax[sfemale, TargetingLaser] = 1;
$ItemMax[sfemale, Fixit] = 0; 
$ItemMax[sfemale, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[sfemale, Grenade] = 5; 
$ItemMax[sfemale, Beacon] = 5; 
$ItemMax[sfemale, Boost] = 5;
$ItemMax[sfemale, RepairKit] = 1;  
$ItemMax[sfemale, Plastique] = 0; 
$ItemMax[sfemale, MineAmmo] = 3; 
//=====================================================AMMO
$ItemMax[sfemale, FlamerAmmo] = 0; 
$ItemMax[sfemale, ShotgunAmmo] = 10; 
$ItemMax[sfemale, BulletAmmo] = 100; 
$ItemMax[sfemale, PlasmaAmmo] = 30; 
$ItemMax[sfemale, DiscAmmo] = 15; 
$ItemMax[sfemale, GrenadeAmmo] = 10; 
$ItemMax[sfemale, MortarAmmo] = 10; 
$ItemMax[sfemale, RocketAmmo] = 10;
$ItemMax[sfemale, MissileAmmo] = 5;  
$ItemMax[sfemale, SniperAmmo] = 15; 
$ItemMax[sfemale, RailAmmo] = 15; 
$ItemMax[sfemale, VulcanAmmo] = 300; 
$ItemMax[sfemale, TranqAmmo] = 20; 
$ItemMax[sfemale, NapalmAmmo] = 10;
$ItemMax[sfemale, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[sfemale, EnergyPack] = 1; 
$ItemMax[sfemale, RepairPack] = 1; 
$ItemMax[sfemale, ShieldPack] = 1;
$ItemMax[sfemale, AmmoPack] = 1;
$ItemMax[sfemale, CloakingDevice] = 0; 
$ItemMax[sfemale, StealthShieldPack] = 0;
$ItemMax[sfemale, Laptop] = 0;
$ItemMax[sfemale, RegenerationPack] = 0; 
$ItemMax[sfemale, GasPack] = 0; 
$ItemMax[sfemale, OpticPack] = 0; 
$ItemMax[sfemale, SMRPack] = 0; 
$ItemMax[sfemale, SuicidePack] = 0;
$ItemMax[sfemale, SensorJammerPack] = 1;  
//=====================================================SENSORS
$ItemMax[sfemale, MotionSensorPack] = 1; 
$ItemMax[sfemale, PulseSensorPack] = 1; 
$ItemMax[sfemale, DeployableSensorJammerPack] = 1; 
$ItemMax[sfemale, CameraPack] = 1; 
$ItemMax[sfemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[sfemale, DeployablevhclPack] = 0;
$ItemMax[sfemale, DeployableInvPack] = 0; 
$ItemMax[sfemale, DeployableAmmoPack] = 0; 
$ItemMax[sfemale, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[sfemale, TurretPack] = 0; 
$ItemMax[sfemale, LaserTurret] = 0;
$ItemMax[sfemale, IndoorPack] = 0; 
$ItemMax[sfemale, DeployableElfTurret] = 0; 
$ItemMax[sfemale, AntiAirPack] = 0; 
$ItemMax[sfemale, ShockPack] = 0; 
$ItemMax[sfemale, RocketPack] = 0; 
$ItemMax[sfemale, LaserPack] = 1;
$ItemMax[sfemale, TargetPack] = 0; 
$ItemMax[sfemale, RailTurret] = 0; 
$ItemMax[sfemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[sfemale, ForceFieldPack] = 0;
$ItemMax[sfemale, MedffPack] = 0;
$ItemMax[sfemale, LargeForceFieldPack] = 0; 
$ItemMax[sfemale, TripwirePack] = 0; 
$ItemMax[sfemale, newdoorone] = 0;
$ItemMax[sfemale, newdoortwo] = 0;
$ItemMax[sfemale, newdoorthree] = 0;
$ItemMax[sfemale, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[sfemale, doorthreebyfourForceFieldPack] = 0;
$ItemMax[sfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[sfemale, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[sfemale, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[sfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[sfemale, BlastDoorPack] = 0;
$ItemMax[sfemale, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[sfemale, LrgPltPack] = 0;
$ItemMax[sfemale, PlatformPack] = 0; 
$ItemMax[sfemale, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[sfemale, HoloPack] = 1; 
$ItemMax[sfemale, TeleportPack] = 0; 
$ItemMax[sfemale, SpringPack] = 0; 
$ItemMax[sfemale, jailpack] = 0;
$ItemMax[sfemale, JailCapPack] = 0;
$ItemMax[sfemale, ArbitorBoxPack] = 0;
$ItemMax[sfemale, TreePack] = 1;
$ItemMax[sfemale, FlagstandPack] = 0;
$ItemMax[sfemale, BuilderPole] = 0;
$ItemMax[sfemale, RemoteBase] = 0;
$ItemMax[sfemale, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[sfemale, BigBomberPack] = 1;
$ItemMax[sfemale, cloakjetPack] = 1;
$ItemMax[sfemale, bomberPack] = 1;
$ItemMax[sfemale, MechPack] = 1;
$ItemMax[sfemale, DetPack] = 1;

$MaxWeapons[sfemale] = 2; 

PlayerData sfemale 
{ 
className = "Armor"; 
shapeFile = "lfemale"; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 150; 
minJetEnergy = 1; 
jetForce = 425; 
jetEnergyDrain = 0.1; 
maxDamage = 0.6; 
maxForwardSpeed = 10; 
maxBackwardSpeed = 10; 
maxSideSpeed = 10; 
groundForce = 40 * 9.0; 
mass = 9.0; 
groundTraction = 4.0; 
maxEnergy = 30; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 125; 
damageScale = 0.005; 
jumpImpulse = 95; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 };   
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; 
footPrints = { 0, 1 }; 
boxWidth = 0.5; 
boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.85; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.88; 
boxCrouchTorsoPercentage = 0.35; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//==============================================================================
//==============================================================================
//================================ SPY =========================================
//==============================================================================
//==============================================================================

$DamageScale[spyarmor, $LandingDamageType] = 0.3; 
$DamageScale[spyarmor, $ImpactDamageType] = 0.3; 
$DamageScale[spyarmor, $CrushDamageType] = 1.0; 
$DamageScale[spyarmor, $BulletDamageType] = 0.5; 
$DamageScale[spyarmor, $PlasmaDamageType] = 1.2; 
$DamageScale[spyarmor, $EnergyDamageType] = 1.3; 
$DamageScale[spyarmor, $ExplosionDamageType] = 1.2; 
$DamageScale[spyarmor, $MissileDamageType] = 1.3; 
$DamageScale[spyarmor, $DebrisDamageType] = 1.3; 
$DamageScale[spyarmor, $ShrapnelDamageType] = 1.3; 
$DamageScale[spyarmor, $LaserDamageType] = 1.0; 
$DamageScale[spyarmor, $MortarDamageType] = 1.3; 
$DamageScale[spyarmor, $BlasterDamageType] = 1.3; 
$DamageScale[spyarmor, $ElectricityDamageType] = 1.0; 
$DamageScale[spyarmor, $MineDamageType] = 1.2; 
$DamageScale[spyarmor, $SniperDamageType] = 1.0; 
$DamageScale[spyarmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[spyarmor, Blaster] = 1; 
$ItemMax[spyarmor, Chaingun] = 1; 
$ItemMax[spyarmor, Disclauncher] = 1; 
$ItemMax[spyarmor, GrenadeLauncher] = 1; 
$ItemMax[spyarmor, Mortar] = 0; 
$ItemMax[spyarmor, PlasmaGun] = 1; 
$ItemMax[spyarmor, LaserRifle] = 1; 
$ItemMax[spyarmor, EnergyRifle] = 1;
$ItemMax[spyarmor, RocketLauncher] = 0; 
$ItemMax[spyarmor, SniperRifle] = 0; 
$ItemMax[spyarmor, WaveGun] = 0; 
$ItemMax[spyarmor, Railgun] = 0; 
$ItemMax[spyarmor, Gaussgun] = 0; 
$ItemMax[spyarmor, Vulcan] = 0; 
$ItemMax[spyarmor, Silencer] = 1; 
$ItemMax[spyarmor, Flamer] = 0; 
$ItemMax[spyarmor, IonGun] = 0;
$ItemMax[spyarmor, Shotgun] = 0; 
$ItemMax[spyarmor, TranqGun] = 1; 
$ItemMax[spyarmor, Napalm] = 0;
$ItemMax[spyarmor, Omega] = 0;
//=====================================================TOOLS
$ItemMax[spyarmor, JailGun] = 1; 
$ItemMax[spyarmor, TargetingLaser] = 1;
$ItemMax[spyarmor, Fixit] = 0; 
$ItemMax[spyarmor, Hackit] = 1;
//=====================================================ARMOR ITEMS
$ItemMax[spyarmor, Grenade] = 10; 
$ItemMax[spyarmor, Beacon] = 5; 
$ItemMax[spyarmor, Boost] = 4;
$ItemMax[spyarmor, RepairKit] = 1;  
$ItemMax[spyarmor, Plastique] = 0; 
$ItemMax[spyarmor, MineAmmo] = 5; 
//=====================================================AMMO
$ItemMax[spyarmor, FlamerAmmo] = 0; 
$ItemMax[spyarmor, ShotgunAmmo] = 10; 
$ItemMax[spyarmor, BulletAmmo] = 300; 
$ItemMax[spyarmor, PlasmaAmmo] = 50; 
$ItemMax[spyarmor, DiscAmmo] = 35; 
$ItemMax[spyarmor, GrenadeAmmo] = 20; 
$ItemMax[spyarmor, MortarAmmo] = 10; 
$ItemMax[spyarmor, RocketAmmo] = 5;
$ItemMax[spyarmor, MissileAmmo] = 5;  
$ItemMax[spyarmor, SniperAmmo] = 25; 
$ItemMax[spyarmor, RailAmmo] = 10; 
$ItemMax[spyarmor, VulcanAmmo] = 200; 
$ItemMax[spyarmor, TranqAmmo] = 25; 
$ItemMax[spyarmor, NapalmAmmo] = 10;
$ItemMax[spyarmor, SilencerAmmo] = 30; 
//=====================================================BACKPACKS
$ItemMax[spyarmor, EnergyPack] = 1; 
$ItemMax[spyarmor, RepairPack] = 1; 
$ItemMax[spyarmor, ShieldPack] = 1;
$ItemMax[spyarmor, AmmoPack] = 1;
$ItemMax[spyarmor, CloakingDevice] = 1; 
$ItemMax[spyarmor, StealthShieldPack] = 1;
$ItemMax[spyarmor, Laptop] = 1;
$ItemMax[spyarmor, RegenerationPack] = 0; 
$ItemMax[spyarmor, GasPack] = 0; 
$ItemMax[spyarmor, OpticPack] = 0; 
$ItemMax[spyarmor, SMRPack] = 0; 
$ItemMax[spyarmor, SuicidePack] = 0;
$ItemMax[spyarmor, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[spyarmor, MotionSensorPack] = 1; 
$ItemMax[spyarmor, PulseSensorPack] = 1; 
$ItemMax[spyarmor, DeployableSensorJammerPack] = 1; 
$ItemMax[spyarmor, CameraPack] = 1; 
$ItemMax[spyarmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[spyarmor, DeployablevhclPack] = 0;
$ItemMax[spyarmor, DeployableInvPack] = 0; 
$ItemMax[spyarmor, DeployableAmmoPack] = 0; 
$ItemMax[spyarmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[spyarmor, TurretPack] = 0; 
$ItemMax[spyarmor, LaserTurret] = 0;
$ItemMax[spyarmor, IndoorPack] = 0; 
$ItemMax[spyarmor, DeployableElfTurret] = 0; 
$ItemMax[spyarmor, AntiAirPack] = 0; 
$ItemMax[spyarmor, ShockPack] = 0; 
$ItemMax[spyarmor, RocketPack] = 0; 
$ItemMax[spyarmor, LaserPack] = 1;
$ItemMax[spyarmor, TargetPack] = 0; 
$ItemMax[spyarmor, RailTurret] = 0; 
$ItemMax[spyarmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[spyarmor, ForceFieldPack] = 1;
$ItemMax[spyarmor, MedffPack] = 0;
$ItemMax[spyarmor, LargeForceFieldPack] = 0; 
$ItemMax[spyarmor, TripwirePack] = 0; 
$ItemMax[spyarmor, newdoorone] = 0;
$ItemMax[spyarmor, newdoortwo] = 0;
$ItemMax[spyarmor, newdoorthree] = 0;
$ItemMax[spyarmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[spyarmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[spyarmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[spyarmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[spyarmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[spyarmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[spyarmor, BlastDoorPack] = 0;
$ItemMax[spyarmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[spyarmor, LrgPltPack] = 0;
$ItemMax[spyarmor, PlatformPack] = 0; 
$ItemMax[spyarmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[spyarmor, HoloPack] = 1; 
$ItemMax[spyarmor, TeleportPack] = 0; 
$ItemMax[spyarmor, SpringPack] = 0; 
$ItemMax[spyarmor, jailpack] = 0;
$ItemMax[spyarmor, JailCapPack] = 0;
$ItemMax[spyarmor, ArbitorBoxPack] = 0;
$ItemMax[spyarmor, TreePack] = 1;
$ItemMax[spyarmor, FlagstandPack] = 0;
$ItemMax[spyarmor, BuilderPole] = 0;
$ItemMax[spyarmor, RemoteBase] = 0;
$ItemMax[spyarmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[spyarmor, BigBomberPack] = 1;
$ItemMax[spyarmor, cloakjetPack] = 1;
$ItemMax[spyarmor, bomberPack] = 1;
$ItemMax[spyarmor, MechPack] = 1;
$ItemMax[spyarmor, DetPack] = 1;

$MaxWeapons[spyarmor] = 3; 

PlayerData spyarmor 
{ 
className = "Armor"; 
shapeFile = "larmor"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
shadowDetailMask = 1; 
visibleToSensor = false; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 1.2; 
maxJetForwardVelocity = 142; 
minJetEnergy = 1; 
jetForce = 250; 
jetEnergyDrain = 0.5; 
maxDamage = 0.66; 
maxForwardSpeed = 25; 
maxBackwardSpeed = 25; 
maxSideSpeed = 25; 
groundForce = 40 * 9.0; 
mass = 7.0; 
groundTraction = 19.0; 
maxEnergy = 30; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 80; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; 
footPrints = { 0, 1 }; 
boxWidth = 0.5; 
boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.6666; 
boxCrouchTorsoPercentage = 0.3333; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//=================================================================================
//=================================================================================
//================================ SPY-FEMALE =====================================
//=================================================================================
//=================================================================================

$DamageScale[spyfemale, $LandingDamageType] = 0.3; 
$DamageScale[spyfemale, $ImpactDamageType] = 0.3; 
$DamageScale[spyfemale, $CrushDamageType] = 1.0; 
$DamageScale[spyfemale, $BulletDamageType] = 0.5; 
$DamageScale[spyfemale, $PlasmaDamageType] = 1.2; 
$DamageScale[spyfemale, $EnergyDamageType] = 1.3; 
$DamageScale[spyfemale, $ExplosionDamageType] = 1.2; 
$DamageScale[spyfemale, $MissileDamageType] = 1.3; 
$DamageScale[spyfemale, $DebrisDamageType] = 1.3; 
$DamageScale[spyfemale, $ShrapnelDamageType] = 1.3; 
$DamageScale[spyfemale, $LaserDamageType] = 1.0; 
$DamageScale[spyfemale, $MortarDamageType] = 1.3; 
$DamageScale[spyfemale, $BlasterDamageType] = 1.3; 
$DamageScale[spyfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[spyfemale, $MineDamageType] = 1.2; 
$DamageScale[spyfemale, $SniperDamageType] = 1.0; 
$DamageScale[spyfemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[spyfemale, Blaster] = 1; 
$ItemMax[spyfemale, Chaingun] = 1; 
$ItemMax[spyfemale, Disclauncher] = 1; 
$ItemMax[spyfemale, GrenadeLauncher] = 1; 
$ItemMax[spyfemale, Mortar] = 0; 
$ItemMax[spyfemale, PlasmaGun] = 1; 
$ItemMax[spyfemale, LaserRifle] = 1; 
$ItemMax[spyfemale, EnergyRifle] = 1;
$ItemMax[spyfemale, RocketLauncher] = 0; 
$ItemMax[spyfemale, SniperRifle] = 0; 
$ItemMax[spyfemale, WaveGun] = 0; 
$ItemMax[spyfemale, Railgun] = 0; 
$ItemMax[spyfemale, Gaussgun] = 0; 
$ItemMax[spyfemale, Vulcan] = 0; 
$ItemMax[spyfemale, Silencer] = 1; 
$ItemMax[spyfemale, Flamer] = 0; 
$ItemMax[spyfemale, IonGun] = 0;
$ItemMax[spyfemale, Shotgun] = 0; 
$ItemMax[spyfemale, TranqGun] = 1; 
$ItemMax[spyfemale, Napalm] = 0;
$ItemMax[spyfemale, Omega] = 0;
//=====================================================TOOLS
$ItemMax[spyfemale, JailGun] = 1; 
$ItemMax[spyfemale, TargetingLaser] = 1;
$ItemMax[spyfemale, Fixit] = 0; 
$ItemMax[spyfemale, Hackit] = 1;
//=====================================================ARMOR ITEMS
$ItemMax[spyfemale, Grenade] = 10; 
$ItemMax[spyfemale, Beacon] = 5; 
$ItemMax[spyfemale, Boost] = 4;
$ItemMax[spyfemale, RepairKit] = 1;  
$ItemMax[spyfemale, Plastique] = 0; 
$ItemMax[spyfemale, MineAmmo] = 5; 
//=====================================================AMMO
$ItemMax[spyfemale, FlamerAmmo] = 0; 
$ItemMax[spyfemale, ShotgunAmmo] = 10; 
$ItemMax[spyfemale, BulletAmmo] = 300; 
$ItemMax[spyfemale, PlasmaAmmo] = 50; 
$ItemMax[spyfemale, DiscAmmo] = 35; 
$ItemMax[spyfemale, GrenadeAmmo] = 20; 
$ItemMax[spyfemale, MortarAmmo] = 10; 
$ItemMax[spyfemale, RocketAmmo] = 5;
$ItemMax[spyfemale, MissileAmmo] = 5;  
$ItemMax[spyfemale, SniperAmmo] = 25; 
$ItemMax[spyfemale, RailAmmo] = 10; 
$ItemMax[spyfemale, VulcanAmmo] = 200; 
$ItemMax[spyfemale, TranqAmmo] = 25; 
$ItemMax[spyfemale, NapalmAmmo] = 10;
$ItemMax[spyfemale, SilencerAmmo] = 30; 
//=====================================================BACKPACKS
$ItemMax[spyfemale, EnergyPack] = 1; 
$ItemMax[spyfemale, RepairPack] = 1; 
$ItemMax[spyfemale, ShieldPack] = 1;
$ItemMax[spyfemale, AmmoPack] = 1;
$ItemMax[spyfemale, CloakingDevice] = 1; 
$ItemMax[spyfemale, StealthShieldPack] = 1;
$ItemMax[spyfemale, Laptop] = 1;
$ItemMax[spyfemale, RegenerationPack] = 0; 
$ItemMax[spyfemale, GasPack] = 0; 
$ItemMax[spyfemale, OpticPack] = 0; 
$ItemMax[spyfemale, SMRPack] = 0; 
$ItemMax[spyfemale, SuicidePack] = 0;
$ItemMax[spyfemale, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[spyfemale, MotionSensorPack] = 1; 
$ItemMax[spyfemale, PulseSensorPack] = 1; 
$ItemMax[spyfemale, DeployableSensorJammerPack] = 1; 
$ItemMax[spyfemale, CameraPack] = 1; 
$ItemMax[spyfemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[spyfemale, DeployablevhclPack] = 0;
$ItemMax[spyfemale, DeployableInvPack] = 0; 
$ItemMax[spyfemale, DeployableAmmoPack] = 0; 
$ItemMax[spyfemale, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[spyfemale, TurretPack] = 0; 
$ItemMax[spyfemale, LaserTurret] = 0;
$ItemMax[spyfemale, IndoorPack] = 0; 
$ItemMax[spyfemale, DeployableElfTurret] = 0; 
$ItemMax[spyfemale, AntiAirPack] = 0; 
$ItemMax[spyfemale, ShockPack] = 0; 
$ItemMax[spyfemale, RocketPack] = 0; 
$ItemMax[spyfemale, LaserPack] = 1;
$ItemMax[spyfemale, TargetPack] = 0; 
$ItemMax[spyfemale, RailTurret] = 0; 
$ItemMax[spyfemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[spyfemale, ForceFieldPack] = 1;
$ItemMax[spyfemale, MedffPack] = 0;
$ItemMax[spyfemale, LargeForceFieldPack] = 0; 
$ItemMax[spyfemale, TripwirePack] = 0; 
$ItemMax[spyfemale, newdoorone] = 0;
$ItemMax[spyfemale, newdoortwo] = 0;
$ItemMax[spyfemale, newdoorthree] = 0;
$ItemMax[spyfemale, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[spyfemale, doorthreebyfourForceFieldPack] = 0;
$ItemMax[spyfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[spyfemale, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[spyfemale, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[spyfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[spyfemale, BlastDoorPack] = 0;
$ItemMax[spyfemale, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[spyfemale, LrgPltPack] = 0;
$ItemMax[spyfemale, PlatformPack] = 0; 
$ItemMax[spyfemale, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[spyfemale, HoloPack] = 1; 
$ItemMax[spyfemale, TeleportPack] = 0; 
$ItemMax[spyfemale, SpringPack] = 0; 
$ItemMax[spyfemale, jailpack] = 0;
$ItemMax[spyfemale, JailCapPack] = 0;
$ItemMax[spyfemale, ArbitorBoxPack] = 0;
$ItemMax[spyfemale, TreePack] = 1;
$ItemMax[spyfemale, FlagstandPack] = 0;
$ItemMax[spyfemale, BuilderPole] = 0;
$ItemMax[spyfemale, RemoteBase] = 0;
$ItemMax[spyfemale, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[spyfemale, BigBomberPack] = 1;
$ItemMax[spyfemale, cloakjetPack] = 1;
$ItemMax[spyfemale, bomberPack] = 1;
$ItemMax[spyfemale, MechPack] = 1;
$ItemMax[spyfemale, DetPack] = 1;

$MaxWeapons[spyfemale] = 3; 

PlayerData spyfemale 
{ 
className = "Armor"; 
shapeFile = "lfemale"; 
flameShapeName = "lflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = false; 
mapFilter = 1; 
mapIcon = "M_player"; 
canCrouch = true; 
maxJetSideForceFactor = 1.2; 
maxJetForwardVelocity = 142; 
minJetEnergy = 1; 
jetForce = 250; 
jetEnergyDrain = 0.5; 
maxDamage = 0.66; 
maxForwardSpeed = 25; 
maxBackwardSpeed = 25; 
maxSideSpeed = 25; 
groundForce = 40 * 9.0; 
mass = 7.0; 
groundTraction = 19.0; 
maxEnergy = 30; 
drag = 1.0; 
density = 1.2; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 80; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft }; 
lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft }; 
footPrints = { 0, 1 }; 
boxWidth = 0.5; 
boxDepth = 0.5; 
boxNormalHeight = 2.2; 
boxCrouchHeight = 1.8; 
boxNormalHeadPercentage = 0.85; 
boxNormalTorsoPercentage = 0.53; 
boxCrouchHeadPercentage = 0.88;
boxCrouchTorsoPercentage = 0.35; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//=====================================================================================
//=====================================================================================
//================================= MERCENARY =========================================
//=====================================================================================
//=====================================================================================

$DamageScale[marmor, $LandingDamageType] = 0.7; 
$DamageScale[marmor, $ImpactDamageType] = 1.0; 
$DamageScale[marmor, $CrushDamageType] = 1.0; 
$DamageScale[marmor, $BulletDamageType] = 1.0; 
$DamageScale[marmor, $PlasmaDamageType] = 1.0; 
$DamageScale[marmor, $EnergyDamageType] = 1.0; 
$DamageScale[marmor, $ExplosionDamageType] = 1.0; 
$DamageScale[marmor, $MissileDamageType] = 1.0; 
$DamageScale[marmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[marmor, $DebrisDamageType] = 1.0; 
$DamageScale[marmor, $LaserDamageType] = 1.0; 
$DamageScale[marmor, $MortarDamageType] = 1.0; 
$DamageScale[marmor, $BlasterDamageType] = 1.0; 
$DamageScale[marmor, $ElectricityDamageType] = 1.0; 
$DamageScale[marmor, $MineDamageType] = 1.0; 
$DamageScale[marmor, $SniperDamageType] = 1.0; 
$DamageScale[marmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[marmor, Blaster] = 1; 
$ItemMax[marmor, Chaingun] = 1; 
$ItemMax[marmor, Disclauncher] = 1; 
$ItemMax[marmor, GrenadeLauncher] = 1; 
$ItemMax[marmor, Mortar] = 0; 
$ItemMax[marmor, PlasmaGun] = 1; 
$ItemMax[marmor, LaserRifle] = 0; 
$ItemMax[marmor, EnergyRifle] = 1;
$ItemMax[marmor, RocketLauncher] = 1; 
$ItemMax[marmor, SniperRifle] = 0; 
$ItemMax[marmor, WaveGun] = 0; 
$ItemMax[marmor, Railgun] = 0; 
$ItemMax[marmor, Gaussgun] = 0; 
$ItemMax[marmor, Vulcan] = 1; 
$ItemMax[marmor, Silencer] = 0; 
$ItemMax[marmor, Flamer] = 0; 
$ItemMax[marmor, IonGun] = 0;
$ItemMax[marmor, Shotgun] = 1; 
$ItemMax[marmor, TranqGun] = 0; 
$ItemMax[marmor, Napalm] = 0;
$ItemMax[marmor, Omega] = 1;
//=====================================================TOOLS
$ItemMax[marmor, JailGun] = 1; 
$ItemMax[marmor, TargetingLaser] = 1;
$ItemMax[marmor, Fixit] = 0; 
$ItemMax[marmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[marmor, Grenade] = 25; 
$ItemMax[marmor, Beacon] = 10; 
$ItemMax[marmor, Boost] = 4;
$ItemMax[marmor, RepairKit] = 1;  
$ItemMax[marmor, Plastique] = 0; 
$ItemMax[marmor, MineAmmo] = 15; 
//=====================================================AMMO
$ItemMax[marmor, FlamerAmmo] = 0; 
$ItemMax[marmor, ShotgunAmmo] = 10; 
$ItemMax[marmor, BulletAmmo] = 500; 
$ItemMax[marmor, PlasmaAmmo] = 50; 
$ItemMax[marmor, DiscAmmo] = 35; 
$ItemMax[marmor, GrenadeAmmo] = 30; 
$ItemMax[marmor, MortarAmmo] = 10; 
$ItemMax[marmor, RocketAmmo] = 10;
$ItemMax[marmor, MissileAmmo] = 5;  
$ItemMax[marmor, SniperAmmo] = 15; 
$ItemMax[marmor, RailAmmo] = 15; 
$ItemMax[marmor, VulcanAmmo] = 500; 
$ItemMax[marmor, TranqAmmo] = 20; 
$ItemMax[marmor, NapalmAmmo] = 10;
$ItemMax[marmor, SilencerAmmo] = 30; 
//=====================================================BACKPACKS
$ItemMax[marmor, EnergyPack] = 1; 
$ItemMax[marmor, RepairPack] = 1; 
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[marmor, AmmoPack] = 1;
$ItemMax[marmor, CloakingDevice] = 0; 
$ItemMax[marmor, StealthShieldPack] = 0;
$ItemMax[marmor, Laptop] = 0;
$ItemMax[marmor, RegenerationPack] = 0; 
$ItemMax[marmor, GasPack] = 0; 
$ItemMax[marmor, OpticPack] = 0; 
$ItemMax[marmor, SMRPack] = 0; 
$ItemMax[marmor, SuicidePack] = 0;
$ItemMax[marmor, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[marmor, MotionSensorPack] = 1; 
$ItemMax[marmor, PulseSensorPack] = 1; 
$ItemMax[marmor, DeployableSensorJammerPack] = 1; 
$ItemMax[marmor, CameraPack] = 1; 
$ItemMax[marmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[marmor, DeployablevhclPack] = 0;
$ItemMax[marmor, DeployableInvPack] = 0; 
$ItemMax[marmor, DeployableAmmoPack] = 0; 
$ItemMax[marmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[marmor, TurretPack] = 1; 
$ItemMax[marmor, LaserTurret] = 0;
$ItemMax[marmor, IndoorPack] = 0; 
$ItemMax[marmor, DeployableElfTurret] = 0; 
$ItemMax[marmor, AntiAirPack] = 0; 
$ItemMax[marmor, ShockPack] = 0; 
$ItemMax[marmor, RocketPack] = 0; 
$ItemMax[marmor, LaserPack] = 0;
$ItemMax[marmor, TargetPack] = 0; 
$ItemMax[marmor, RailTurret] = 0; 
$ItemMax[marmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[marmor, ForceFieldPack] = 1;
$ItemMax[marmor, MedffPack] = 0;
$ItemMax[marmor, LargeForceFieldPack] = 0; 
$ItemMax[marmor, TripwirePack] = 0; 
$ItemMax[marmor, newdoorone] = 0;
$ItemMax[marmor, newdoortwo] = 0;
$ItemMax[marmor, newdoorthree] = 0;
$ItemMax[marmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[marmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[marmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[marmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[marmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[marmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[marmor, BlastDoorPack] = 0;
$ItemMax[marmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[marmor, LrgPltPack] = 0;
$ItemMax[marmor, PlatformPack] = 0; 
$ItemMax[marmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[marmor, HoloPack] = 1; 
$ItemMax[marmor, TeleportPack] = 0; 
$ItemMax[marmor, SpringPack] = 0; 
$ItemMax[marmor, jailpack] = 0;
$ItemMax[marmor, JailCapPack] = 0;
$ItemMax[marmor, ArbitorBoxPack] = 0;
$ItemMax[marmor, TreePack] = 0;
$ItemMax[marmor, FlagstandPack] = 0;
$ItemMax[marmor, BuilderPole] = 0;
$ItemMax[marmor, RemoteBase] = 0;
$ItemMax[marmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[marmor, BigBomberPack] = 0;
$ItemMax[marmor, cloakjetPack] = 0;
$ItemMax[marmor, bomberPack] = 0;
$ItemMax[marmor, MechPack] = 0;
$ItemMax[marmor, DetPack] = 0;

$MaxWeapons[marmor] = 5; 

PlayerData marmor 
{ 
className = "Armor"; 
shapeFile = "marmor"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
canCrouch = false; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 17; 
minJetEnergy = 1; 
jetForce = 325; 
jetEnergyDrain = 1.0; 
maxDamage = 1; 
maxForwardSpeed = 9.0; 
maxBackwardSpeed = 7.0; 
maxSideSpeed = 7.0; 
groundForce = 35 * 13.0; 
mass = 13.0; 
groundTraction = 3.5; 
maxEnergy = 90; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 110; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.49; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
};
 
//=====================================================================================
//=====================================================================================
//============================ MERCENARY-FEMALE =======================================
//=====================================================================================
//=====================================================================================

$DamageScale[mfemale, $LandingDamageType] = 0.7; 
$DamageScale[mfemale, $ImpactDamageType] = 1.0; 
$DamageScale[mfemale, $CrushDamageType] = 1.0; 
$DamageScale[mfemale, $BulletDamageType] = 1.0; 
$DamageScale[mfemale, $EnergyDamageType] = 1.0; 
$DamageScale[mfemale, $PlasmaDamageType] = 1.0; 
$DamageScale[mfemale, $ExplosionDamageType] = 1.0; 
$DamageScale[mfemale, $MissileDamageType] = 1.0; 
$DamageScale[mfemale, $ShrapnelDamageType] = 1.0; 
$DamageScale[mfemale, $DebrisDamageType] = 1.0; 
$DamageScale[mfemale, $LaserDamageType] = 1.0; 
$DamageScale[mfemale, $MortarDamageType] = 1.0; 
$DamageScale[mfemale, $BlasterDamageType] = 1.0; 
$DamageScale[mfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[mfemale, $MineDamageType] = 1.0; 
$DamageScale[mfemale, $SniperDamageType] = 1.0; 
$DamageScale[mfemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[mfemale, Blaster] = 1; 
$ItemMax[mfemale, Chaingun] = 1; 
$ItemMax[mfemale, Disclauncher] = 1; 
$ItemMax[mfemale, GrenadeLauncher] = 1; 
$ItemMax[mfemale, Mortar] = 0; 
$ItemMax[mfemale, PlasmaGun] = 1; 
$ItemMax[mfemale, LaserRifle] = 0; 
$ItemMax[mfemale, EnergyRifle] = 1;
$ItemMax[mfemale, RocketLauncher] = 1; 
$ItemMax[mfemale, SniperRifle] = 0; 
$ItemMax[mfemale, WaveGun] = 0; 
$ItemMax[mfemale, Railgun] = 0; 
$ItemMax[mfemale, Gaussgun] = 0; 
$ItemMax[mfemale, Vulcan] = 1; 
$ItemMax[mfemale, Silencer] = 0; 
$ItemMax[mfemale, Flamer] = 0; 
$ItemMax[mfemale, IonGun] = 0;
$ItemMax[mfemale, Shotgun] = 1; 
$ItemMax[mfemale, TranqGun] = 0; 
$ItemMax[mfemale, Napalm] = 0;
$ItemMax[mfemale, Omega] = 1;
//=====================================================TOOLS
$ItemMax[mfemale, JailGun] = 1; 
$ItemMax[mfemale, TargetingLaser] = 1;
$ItemMax[mfemale, Fixit] = 0; 
$ItemMax[mfemale, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[mfemale, Grenade] = 25; 
$ItemMax[mfemale, Beacon] = 10; 
$ItemMax[mfemale, Boost] = 4;
$ItemMax[mfemale, RepairKit] = 1;  
$ItemMax[mfemale, Plastique] = 0; 
$ItemMax[mfemale, MineAmmo] = 15; 
//=====================================================AMMO
$ItemMax[mfemale, FlamerAmmo] = 0; 
$ItemMax[mfemale, ShotgunAmmo] = 10; 
$ItemMax[mfemale, BulletAmmo] = 500; 
$ItemMax[mfemale, PlasmaAmmo] = 50; 
$ItemMax[mfemale, DiscAmmo] = 35; 
$ItemMax[mfemale, GrenadeAmmo] = 30; 
$ItemMax[mfemale, MortarAmmo] = 10; 
$ItemMax[mfemale, RocketAmmo] = 10;
$ItemMax[mfemale, MissileAmmo] = 5;  
$ItemMax[mfemale, SniperAmmo] = 15; 
$ItemMax[mfemale, RailAmmo] = 15; 
$ItemMax[mfemale, VulcanAmmo] = 500; 
$ItemMax[mfemale, TranqAmmo] = 20; 
$ItemMax[mfemale, NapalmAmmo] = 10;
$ItemMax[mfemale, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[mfemale, EnergyPack] = 1; 
$ItemMax[mfemale, RepairPack] = 1; 
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[mfemale, AmmoPack] = 1;
$ItemMax[mfemale, CloakingDevice] = 0; 
$ItemMax[mfemale, StealthShieldPack] = 0;
$ItemMax[mfemale, Laptop] = 0;
$ItemMax[mfemale, RegenerationPack] = 0; 
$ItemMax[mfemale, GasPack] = 0; 
$ItemMax[mfemale, OpticPack] = 0; 
$ItemMax[mfemale, SMRPack] = 0; 
$ItemMax[mfemale, SuicidePack] = 0;
$ItemMax[mfemale, SensorJammerPack] = 1; 
//=====================================================SENSORS
$ItemMax[mfemale, MotionSensorPack] = 1; 
$ItemMax[mfemale, PulseSensorPack] = 1; 
$ItemMax[mfemale, DeployableSensorJammerPack] = 1; 
$ItemMax[mfemale, CameraPack] = 1; 
$ItemMax[mfemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[mfemale, DeployablevhclPack] = 0;
$ItemMax[mfemale, DeployableInvPack] = 0; 
$ItemMax[mfemale, DeployableAmmoPack] = 0; 
$ItemMax[mfemale, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[mfemale, TurretPack] = 1; 
$ItemMax[mfemale, LaserTurret] = 0;
$ItemMax[mfemale, IndoorPack] = 0; 
$ItemMax[mfemale, DeployableElfTurret] = 0; 
$ItemMax[mfemale, AntiAirPack] = 0; 
$ItemMax[mfemale, ShockPack] = 0; 
$ItemMax[mfemale, RocketPack] = 0; 
$ItemMax[mfemale, LaserPack] = 0;
$ItemMax[mfemale, TargetPack] = 0; 
$ItemMax[mfemale, RailTurret] = 0; 
$ItemMax[mfemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[mfemale, ForceFieldPack] = 1;
$ItemMax[mfemale, MedffPack] = 0;
$ItemMax[mfemale, LargeForceFieldPack] = 0; 
$ItemMax[mfemale, TripwirePack] = 0; 
$ItemMax[mfemale, newdoorone] = 0;
$ItemMax[mfemale, newdoortwo] = 0;
$ItemMax[mfemale, newdoorthree] = 0;
$ItemMax[mfemale, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[mfemale, doorthreebyfourForceFieldPack] = 0;
$ItemMax[mfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[mfemale, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[mfemale, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[mfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[mfemale, BlastDoorPack] = 0;
$ItemMax[mfemale, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[mfemale, LrgPltPack] = 0;
$ItemMax[mfemale, PlatformPack] = 0; 
$ItemMax[mfemale, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[mfemale, HoloPack] = 1; 
$ItemMax[mfemale, TeleportPack] = 0; 
$ItemMax[mfemale, SpringPack] = 0; 
$ItemMax[mfemale, jailpack] = 0;
$ItemMax[mfemale, JailCapPack] = 0;
$ItemMax[mfemale, ArbitorBoxPack] = 0;
$ItemMax[mfemale, TreePack] = 0;
$ItemMax[mfemale, FlagstandPack] = 0;
$ItemMax[mfemale, BuilderPole] = 0;
$ItemMax[mfemale, RemoteBase] = 0;
$ItemMax[mfemale, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[mfemale, BigBomberPack] = 0;
$ItemMax[mfemale, cloakjetPack] = 0;
$ItemMax[mfemale, bomberPack] = 0;
$ItemMax[mfemale, MechPack] = 0;
$ItemMax[mfemale, DetPack] = 0;

$MaxWeapons[mfemale] = 5; 

PlayerData mfemale 
{ 
className = "Armor"; 
shapeFile = "mfemale"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 17; 
minJetEnergy = 1; 
jetForce = 325; 
jetEnergyDrain = 1.0; 
canCrouch = false; 
maxDamage = $MercHealth; 
maxForwardSpeed = 9.0; 
maxBackwardSpeed = 7.0; 
maxSideSpeed = 7.0; 
groundForce = 35 * 13.0; 
mass = 13.0; 
groundTraction = 3.5; 
maxEnergy = 90; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 110; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.84; 
boxNormalTorsoPercentage = 0.55; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 



//=================================================================================
//=================================================================================
//================================ BURSTER ========================================
//=================================================================================
//=================================================================================

$DamageScale[barmor, $LandingDamageType] = 0.8; 
$DamageScale[barmor, $ImpactDamageType] = 1.0; 
$DamageScale[barmor, $CrushDamageType] = 1.0; 
$DamageScale[barmor, $BulletDamageType] = 1.2; 
$DamageScale[barmor, $PlasmaDamageType] = 0.6; 
$DamageScale[barmor, $EnergyDamageType] = 1.1; 
$DamageScale[barmor, $ExplosionDamageType] = 0.7; 
$DamageScale[barmor, $MissileDamageType] = 0.7; 
$DamageScale[barmor, $ShrapnelDamageType] = 0.7; 
$DamageScale[barmor, $DebrisDamageType] = 1.0; 
$DamageScale[barmor, $LaserDamageType] = 1.2; 
$DamageScale[barmor, $MortarDamageType] = 0.6; 
$DamageScale[barmor, $BlasterDamageType] = 1.2; 
$DamageScale[barmor, $ElectricityDamageType] = 1.0; 
$DamageScale[barmor, $MineDamageType] = 0.7; 
$DamageScale[barmor, $SniperDamageType] = 1.0; 
$DamageScale[barmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[barmor, Blaster] = 0; 
$ItemMax[barmor, Chaingun] = 0; 
$ItemMax[barmor, Disclauncher] = 1; 
$ItemMax[barmor, GrenadeLauncher] = 1; 
$ItemMax[barmor, Mortar] = 1; 
$ItemMax[barmor, PlasmaGun] = 1; 
$ItemMax[barmor, LaserRifle] = 0; 
$ItemMax[barmor, EnergyRifle] = 0;
$ItemMax[barmor, RocketLauncher] = 1; 
$ItemMax[barmor, SniperRifle] = 0; 
$ItemMax[barmor, WaveGun] = 0; 
$ItemMax[barmor, Railgun] = 0; 
$ItemMax[barmor, Gaussgun] = 0; 
$ItemMax[barmor, Vulcan] = 0; 
$ItemMax[barmor, Silencer] = 0; 
$ItemMax[barmor, Flamer] = 1; 
$ItemMax[barmor, IonGun] = 0;
$ItemMax[barmor, Shotgun] = 0; 
$ItemMax[barmor, TranqGun] = 0; 
$ItemMax[barmor, Napalm] = 1;
$ItemMax[barmor, Omega] = 0;
//=====================================================TOOLS
$ItemMax[barmor, JailGun] = 1; 
$ItemMax[barmor, TargetingLaser] = 1;
$ItemMax[barmor, Fixit] = 0; 
$ItemMax[barmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[barmor, Grenade] = 15; 
$ItemMax[barmor, Beacon] = 5; 
$ItemMax[barmor, Boost] = 4;
$ItemMax[barmor, RepairKit] = 1;  
$ItemMax[barmor, Plastique] = 0; 
$ItemMax[barmor, MineAmmo] = 10; 
//=====================================================AMMO
$ItemMax[barmor, FlamerAmmo] = 0; 
$ItemMax[barmor, ShotgunAmmo] = 10; 
$ItemMax[barmor, BulletAmmo] = 150; 
$ItemMax[barmor, PlasmaAmmo] = 80; 
$ItemMax[barmor, DiscAmmo] = 35; 
$ItemMax[barmor, GrenadeAmmo] = 20; 
$ItemMax[barmor, MortarAmmo] = 10; 
$ItemMax[barmor, RocketAmmo] = 10;
$ItemMax[barmor, MissileAmmo] = 10;  
$ItemMax[barmor, SniperAmmo] = 15; 
$ItemMax[barmor, RailAmmo] = 25; 
$ItemMax[barmor, VulcanAmmo] = 300; 
$ItemMax[barmor, TranqAmmo] = 20; 
$ItemMax[barmor, NapalmAmmo] = 10;
$ItemMax[barmor, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[barmor, EnergyPack] = 1; 
$ItemMax[barmor, RepairPack] = 1; 
$ItemMax[barmor, ShieldPack] = 1;
$ItemMax[barmor, AmmoPack] = 1;
$ItemMax[barmor, CloakingDevice] = 0; 
$ItemMax[barmor, StealthShieldPack] = 0;
$ItemMax[barmor, Laptop] = 0;
$ItemMax[barmor, RegenerationPack] = 0; 
$ItemMax[barmor, GasPack] = 1; 
$ItemMax[barmor, OpticPack] = 0; 
$ItemMax[barmor, SMRPack] = 0; 
$ItemMax[barmor, SuicidePack] = 1;
$ItemMax[barmor, SensorJammerPack] = 0; 
//=====================================================SENSORS
$ItemMax[barmor, MotionSensorPack] = 1; 
$ItemMax[barmor, PulseSensorPack] = 1; 
$ItemMax[barmor, DeployableSensorJammerPack] = 1; 
$ItemMax[barmor, CameraPack] = 1; 
$ItemMax[barmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[barmor, DeployablevhclPack] = 0;
$ItemMax[barmor, DeployableInvPack] = 0; 
$ItemMax[barmor, DeployableAmmoPack] = 1; 
$ItemMax[barmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[barmor, TurretPack] = 0; 
$ItemMax[barmor, LaserTurret] = 0;
$ItemMax[barmor, IndoorPack] = 0; 
$ItemMax[barmor, DeployableElfTurret] = 0; 
$ItemMax[barmor, AntiAirPack] = 0; 
$ItemMax[barmor, ShockPack] = 0; 
$ItemMax[barmor, RocketPack] = 0; 
$ItemMax[barmor, LaserPack] = 0;
$ItemMax[barmor, TargetPack] = 0; 
$ItemMax[barmor, RailTurret] = 0; 
$ItemMax[barmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[barmor, ForceFieldPack] = 1;
$ItemMax[barmor, MedffPack] = 0;
$ItemMax[barmor, LargeForceFieldPack] = 0; 
$ItemMax[barmor, TripwirePack] = 0; 
$ItemMax[barmor, newdoorone] = 0;
$ItemMax[barmor, newdoortwo] = 0;
$ItemMax[barmor, newdoorthree] = 0;
$ItemMax[barmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[barmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[barmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[barmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[barmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[barmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[barmor, BlastDoorPack] = 0;
$ItemMax[barmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[barmor, LrgPltPack] = 0;
$ItemMax[barmor, PlatformPack] = 0; 
$ItemMax[barmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[barmor, HoloPack] = 1; 
$ItemMax[barmor, TeleportPack] = 0; 
$ItemMax[barmor, SpringPack] = 0; 
$ItemMax[barmor, jailpack] = 0;
$ItemMax[barmor, JailCapPack] = 0;
$ItemMax[barmor, ArbitorBoxPack] = 0;
$ItemMax[barmor, TreePack] = 0;
$ItemMax[barmor, FlagstandPack] = 0;
$ItemMax[barmor, BuilderPole] = 0;
$ItemMax[barmor, RemoteBase] = 0;
$ItemMax[barmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[barmor, BigBomberPack] = 0;
$ItemMax[barmor, cloakjetPack] = 0;
$ItemMax[barmor, bomberPack] = 0;
$ItemMax[barmor, MechPack] = 0;
$ItemMax[barmor, DetPack] = 0;

$MaxWeapons[barmor] = 5; 

PlayerData barmor 
{ 
className = "Armor"; 
shapeFile = "marmor"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
canCrouch = false; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 75; 
minJetEnergy = 1; 
jetForce = 400; 
jetEnergyDrain = 0.9; 
maxDamage = 1.0; 
maxForwardSpeed = 10.0; 
maxBackwardSpeed = 10.0; 
maxSideSpeed = 10.0; 
groundForce = 45 * 15.0; 
mass = 15.0; 
groundTraction = 4.0; 
maxEnergy = 80; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 120; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.49; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 


//================================================================================
//================================================================================
//============================= BURSTER-FEMALE ===================================
//================================================================================
//================================================================================

$DamageScale[bfemale, $LandingDamageType] = 0.8; 
$DamageScale[bfemale, $ImpactDamageType] = 1.0; 
$DamageScale[bfemale, $CrushDamageType] = 1.0; 
$DamageScale[bfemale, $BulletDamageType] = 1.2; 
$DamageScale[bfemale, $PlasmaDamageType] = 0.6; 
$DamageScale[bfemale, $EnergyDamageType] = 1.1; 
$DamageScale[bfemale, $ExplosionDamageType] = 0.7; 
$DamageScale[bfemale, $MissileDamageType] = 0.7; 
$DamageScale[bfemale, $ShrapnelDamageType] = 0.7; 
$DamageScale[bfemale, $DebrisDamageType] = 1.0; 
$DamageScale[bfemale, $LaserDamageType] = 1.2; 
$DamageScale[bfemale, $MortarDamageType] = 0.6; 
$DamageScale[bfemale, $BlasterDamageType] = 1.2; 
$DamageScale[bfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[bfemale, $MineDamageType] = 0.7; 
$DamageScale[bfemale, $SniperDamageType] = 1.0; 
$DamageScale[bfemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[bfemale, Blaster] = 0; 
$ItemMax[bfemale, Chaingun] = 0; 
$ItemMax[bfemale, Disclauncher] = 1; 
$ItemMax[bfemale, GrenadeLauncher] = 1; 
$ItemMax[bfemale, Mortar] = 1; 
$ItemMax[bfemale, PlasmaGun] = 1; 
$ItemMax[bfemale, LaserRifle] = 0; 
$ItemMax[bfemale, EnergyRifle] = 0;
$ItemMax[bfemale, RocketLauncher] = 1; 
$ItemMax[bfemale, SniperRifle] = 0; 
$ItemMax[bfemale, WaveGun] = 0; 
$ItemMax[bfemale, Railgun] = 0; 
$ItemMax[bfemale, Gaussgun] = 0; 
$ItemMax[bfemale, Vulcan] = 0; 
$ItemMax[bfemale, Silencer] = 0; 
$ItemMax[bfemale, Flamer] = 1; 
$ItemMax[bfemale, IonGun] = 0;
$ItemMax[bfemale, Shotgun] = 0; 
$ItemMax[bfemale, TranqGun] = 0; 
$ItemMax[bfemale, Napalm] = 1;
$ItemMax[bfemale, Omega] = 0;
//=====================================================TOOLS
$ItemMax[bfemale, JailGun] = 1; 
$ItemMax[bfemale, TargetingLaser] = 1;
$ItemMax[bfemale, Fixit] = 0; 
$ItemMax[bfemale, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[bfemale, Grenade] = 15; 
$ItemMax[bfemale, Beacon] = 5; 
$ItemMax[bfemale, Boost] = 4;
$ItemMax[bfemale, RepairKit] = 1;  
$ItemMax[bfemale, Plastique] = 0; 
$ItemMax[bfemale, MineAmmo] = 10; 
//=====================================================AMMO
$ItemMax[bfemale, FlamerAmmo] = 0; 
$ItemMax[bfemale, ShotgunAmmo] = 10; 
$ItemMax[bfemale, BulletAmmo] = 150; 
$ItemMax[bfemale, PlasmaAmmo] = 80; 
$ItemMax[bfemale, DiscAmmo] = 35; 
$ItemMax[bfemale, GrenadeAmmo] = 20; 
$ItemMax[bfemale, MortarAmmo] = 10; 
$ItemMax[bfemale, RocketAmmo] = 10;
$ItemMax[bfemale, MissileAmmo] = 10;  
$ItemMax[bfemale, SniperAmmo] = 15; 
$ItemMax[bfemale, RailAmmo] = 25; 
$ItemMax[bfemale, VulcanAmmo] = 300; 
$ItemMax[bfemale, TranqAmmo] = 20; 
$ItemMax[bfemale, NapalmAmmo] = 10;
$ItemMax[bfemale, SilencerAmmo] = 30; 
//=====================================================BACKPACKS
$ItemMax[bfemale, EnergyPack] = 1; 
$ItemMax[bfemale, RepairPack] = 1; 
$ItemMax[bfemale, ShieldPack] = 1;
$ItemMax[bfemale, AmmoPack] = 1;
$ItemMax[bfemale, CloakingDevice] = 0; 
$ItemMax[bfemale, StealthShieldPack] = 0;
$ItemMax[bfemale, Laptop] = 0;
$ItemMax[bfemale, RegenerationPack] = 0; 
$ItemMax[bfemale, GasPack] = 1; 
$ItemMax[bfemale, OpticPack] = 0; 
$ItemMax[bfemale, SMRPack] = 0; 
$ItemMax[bfemale, SuicidePack] = 1;
$ItemMax[bfemale, SensorJammerPack] = 0;  
//=====================================================SENSORS
$ItemMax[bfemale, MotionSensorPack] = 1; 
$ItemMax[bfemale, PulseSensorPack] = 1; 
$ItemMax[bfemale, DeployableSensorJammerPack] = 1; 
$ItemMax[bfemale, CameraPack] = 1; 
$ItemMax[bfemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[bfemale, DeployablevhclPack] = 0;
$ItemMax[bfemale, DeployableInvPack] = 0; 
$ItemMax[bfemale, DeployableAmmoPack] = 1; 
$ItemMax[bfemale, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[bfemale, TurretPack] = 0; 
$ItemMax[bfemale, LaserTurret] = 0;
$ItemMax[bfemale, IndoorPack] = 0; 
$ItemMax[bfemale, DeployableElfTurret] = 0; 
$ItemMax[bfemale, AntiAirPack] = 0; 
$ItemMax[bfemale, ShockPack] = 0; 
$ItemMax[bfemale, RocketPack] = 0; 
$ItemMax[bfemale, LaserPack] = 0;
$ItemMax[bfemale, TargetPack] = 0; 
$ItemMax[bfemale, RailTurret] = 0; 
$ItemMax[bfemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[bfemale, ForceFieldPack] = 1;
$ItemMax[bfemale, MedffPack] = 0;
$ItemMax[bfemale, LargeForceFieldPack] = 0; 
$ItemMax[bfemale, TripwirePack] = 0; 
$ItemMax[bfemale, newdoorone] = 0;
$ItemMax[bfemale, newdoortwo] = 0;
$ItemMax[bfemale, newdoorthree] = 0;
$ItemMax[bfemale, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[bfemale, doorthreebyfourForceFieldPack] = 0;
$ItemMax[bfemale, doorfourbyeightForceFieldPack] = 0;
$ItemMax[bfemale, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[bfemale, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[bfemale, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[bfemale, BlastDoorPack] = 0;
$ItemMax[bfemale, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[bfemale, LrgPltPack] = 0;
$ItemMax[bfemale, PlatformPack] = 0; 
$ItemMax[bfemale, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[bfemale, HoloPack] = 1; 
$ItemMax[bfemale, TeleportPack] = 0; 
$ItemMax[bfemale, SpringPack] = 0; 
$ItemMax[bfemale, jailpack] = 0;
$ItemMax[bfemale, JailCapPack] = 0;
$ItemMax[bfemale, ArbitorBoxPack] = 0;
$ItemMax[bfemale, TreePack] = 0;
$ItemMax[bfemale, FlagstandPack] = 0;
$ItemMax[bfemale, BuilderPole] = 0;
$ItemMax[bfemale, RemoteBase] = 0;
$ItemMax[bfemale, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[bfemale, BigBomberPack] = 0;
$ItemMax[bfemale, cloakjetPack] = 0;
$ItemMax[bfemale, bomberPack] = 0;
$ItemMax[bfemale, MechPack] = 0;
$ItemMax[bfemale, DetPack] = 0;

$MaxWeapons[bfemale] = 5; 

PlayerData bfemale 
{ 
className = "Armor"; 
shapeFile = "mfemale"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 75; 
minJetEnergy = 1; 
jetForce = 400; 
jetEnergyDrain = 0.9; 
canCrouch = false; 
maxDamage = 1.0; 
maxForwardSpeed = 10.0; 
maxBackwardSpeed = 10.0; 
maxSideSpeed = 10.0; 
groundForce = 45 * 15.0; 
groundTraction = 4.0; 
maxEnergy = 80; 
mass = 15.0; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 120; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft}; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.84; 
boxNormalTorsoPercentage = 0.55; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
};
 


//=============================================================================
//=============================================================================
//================================= ENGINEER ==================================
//=============================================================================
//=============================================================================

$DamageScale[earmor, $LandingDamageType] = 1.0; 
$DamageScale[earmor, $ImpactDamageType] = 1.0; 
$DamageScale[earmor, $CrushDamageType] = 1.0; 
$DamageScale[earmor, $BulletDamageType] = 1.0; 
$DamageScale[earmor, $PlasmaDamageType] = 1.0; 
$DamageScale[earmor, $EnergyDamageType] = 1.0; 
$DamageScale[earmor, $ExplosionDamageType] = 1.0; 
$DamageScale[earmor, $MissileDamageType] = 1.0; 
$DamageScale[earmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[earmor, $DebrisDamageType] = 1.0; 
$DamageScale[earmor, $LaserDamageType] = 1.0; 
$DamageScale[earmor, $MortarDamageType] = 1.0; 
$DamageScale[earmor, $BlasterDamageType] = 1.0; 
$DamageScale[earmor, $ElectricityDamageType] = 1.0; 
$DamageScale[earmor, $MineDamageType] = 1.0; 
$DamageScale[earmor, $SniperDamageType] = 1.0; 
$DamageScale[earmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[earmor, Blaster] = 1; 
$ItemMax[earmor, Chaingun] = 1; 
$ItemMax[earmor, Disclauncher] = 1; 
$ItemMax[earmor, GrenadeLauncher] = 1; 
$ItemMax[earmor, Mortar] = 0; 
$ItemMax[earmor, PlasmaGun] = 1; 
$ItemMax[earmor, LaserRifle] = 0; 
$ItemMax[earmor, EnergyRifle] = 1;
$ItemMax[earmor, RocketLauncher] = 1; 
$ItemMax[earmor, SniperRifle] = 0; 
$ItemMax[earmor, WaveGun] = 0; 
$ItemMax[earmor, Railgun] = 1; 
$ItemMax[earmor, Gaussgun] = 0; 
$ItemMax[earmor, Vulcan] = 1; 
$ItemMax[earmor, Silencer] = 0; 
$ItemMax[earmor, Flamer] = 0; 
$ItemMax[earmor, IonGun] = 0;
$ItemMax[earmor, Shotgun] = 0; 
$ItemMax[earmor, TranqGun] = 0; 
$ItemMax[earmor, Napalm] = 0;
$ItemMax[earmor, Omega] = 1;
//=====================================================TOOLS
$ItemMax[earmor, JailGun] = 1; 
$ItemMax[earmor, TargetingLaser] = 1;
$ItemMax[earmor, Fixit] = 1; 
$ItemMax[earmor, Hackit] = 1;
//=====================================================ARMOR ITEMS
$ItemMax[earmor, Grenade] = 15; 
$ItemMax[earmor, Beacon] = 3; 
$ItemMax[earmor, Boost] = 4;
$ItemMax[earmor, RepairKit] = 1;  
$ItemMax[earmor, Plastique] = 0; 
$ItemMax[earmor, MineAmmo] = 15; 
//=====================================================AMMO
$ItemMax[earmor, FlamerAmmo] = 0; 
$ItemMax[earmor, ShotgunAmmo] = 10; 
$ItemMax[earmor, BulletAmmo] = 500; 
$ItemMax[earmor, PlasmaAmmo] = 80; 
$ItemMax[earmor, DiscAmmo] = 35; 
$ItemMax[earmor, GrenadeAmmo] = 20; 
$ItemMax[earmor, MortarAmmo] = 10; 
$ItemMax[earmor, RocketAmmo] = 10;
$ItemMax[earmor, MissileAmmo] = 5;  
$ItemMax[earmor, SniperAmmo] = 15; 
$ItemMax[earmor, RailAmmo] = 25; 
$ItemMax[earmor, VulcanAmmo] = 500; 
$ItemMax[earmor, TranqAmmo] = 20; 
$ItemMax[earmor, NapalmAmmo] = 10;
$ItemMax[earmor, SilencerAmmo] = 30; 
//=====================================================BACKPACKS
$ItemMax[earmor, EnergyPack] = 1; 
$ItemMax[earmor, RepairPack] = 1; 
$ItemMax[earmor, ShieldPack] = 1;
$ItemMax[earmor, AmmoPack] = 1;
$ItemMax[earmor, CloakingDevice] = 0; 
$ItemMax[earmor, StealthShieldPack] = 0;
$ItemMax[earmor, Laptop] = 1;
$ItemMax[earmor, RegenerationPack] = 0; 
$ItemMax[earmor, GasPack] = 0; 
$ItemMax[earmor, OpticPack] = 0; 
$ItemMax[earmor, SMRPack] = 0; 
$ItemMax[earmor, SuicidePack] = 0;
$ItemMax[earmor, SensorJammerPack] = 0; 
//=====================================================SENSORS
$ItemMax[earmor, MotionSensorPack] = 1; 
$ItemMax[earmor, PulseSensorPack] = 1; 
$ItemMax[earmor, DeployableSensorJammerPack] = 1; 
$ItemMax[earmor, CameraPack] = 1; 
$ItemMax[earmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[earmor, DeployablevhclPack] = 1;
$ItemMax[earmor, DeployableInvPack] = 1; 
$ItemMax[earmor, DeployableAmmoPack] = 1; 
$ItemMax[earmor, DeployableComPack] = 1; 
//=====================================================TURRETS
$ItemMax[earmor, TurretPack] = 1; 
$ItemMax[earmor, LaserTurret] = 1;
$ItemMax[earmor, IndoorPack] = 1; 
$ItemMax[earmor, DeployableElfTurret ] = 1; 
$ItemMax[earmor, AntiAirPack] = 1; 
$ItemMax[earmor, ShockPack] = 1; 
$ItemMax[earmor, RocketPack] = 1; 
$ItemMax[earmor, LaserPack] = 1;
$ItemMax[earmor, TargetPack] = 1; 
$ItemMax[earmor, RailTurret] = 1; 
$ItemMax[earmor, VulcanTurret] = 1;
//=====================================================WALLS
$ItemMax[earmor, ForceFieldPack] = 1;
$ItemMax[earmor, MedffPack] = 1;
$ItemMax[earmor, LargeForceFieldPack] = 1; 
$ItemMax[earmor, TripwirePack] = 1; 
$ItemMax[earmor, newdoorone] = 1;
$ItemMax[earmor, newdoortwo] = 1;
$ItemMax[earmor, newdoorthree] = 1;
$ItemMax[earmor, newdoorfour] = 1;
//=====================================================DOORS
$ItemMax[earmor, doorthreebyfourForceFieldPack] = 1;
$ItemMax[earmor, doorfourbyeightForceFieldPack] = 1;
$ItemMax[earmor, doorfourbyfourteenForceFieldPack] = 1;
$ItemMax[earmor, doorfourbyseventeenForceFieldPack] = 1;
$ItemMax[earmor, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[earmor, BlastDoorPack] = 1;
$ItemMax[earmor, PlatformDoorPack] = 1;
//=====================================================PLATFORMS
$ItemMax[earmor, LrgPltPack] = 1;
$ItemMax[earmor, PlatformPack] = 1; 
$ItemMax[earmor, MedPlatform] = 1;
//=====================================================ITEMS
$ItemMax[earmor, HoloPack] = 1; 
$ItemMax[earmor, TeleportPack] = 1; 
$ItemMax[earmor, SpringPack] = 1; 
$ItemMax[earmor, jailpack] = 1;
$ItemMax[earmor, JailCapPack] = 1;
$ItemMax[earmor, ArbitorBoxPack] = 1;
$ItemMax[earmor, TreePack] = 1;
$ItemMax[earmor, FlagstandPack] = 0;
$ItemMax[earmor, BuilderPole] = 1;
$ItemMax[earmor, RemoteBase] = 1;
$ItemMax[earmor, SniperHut] = 1;
//=====================================================VEHICLES
$ItemMax[earmor, BigBomberPack] = 0;
$ItemMax[earmor, cloakjetPack] = 0;
$ItemMax[earmor, bomberPack] = 0;
$ItemMax[earmor, MechPack] = 0;
$ItemMax[earmor, DetPack] = 0;

$MaxWeapons[earmor] = 5; 

PlayerData earmor 
{ 
className = "Armor"; 
shapeFile = "marmor"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
canCrouch = false; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 17; 
minJetEnergy = 1; 
jetForce = 325; 
jetEnergyDrain = 1.0; 
maxDamage = 1.0; 
maxForwardSpeed = 8.0; 
maxBackwardSpeed = 7.0; 
maxSideSpeed = 7.0; 
groundForce = 35 * 13.0; 
mass = 13.0; 
groundTraction = 3.0; 
maxEnergy = 90; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 110; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7;
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.83; 
boxNormalTorsoPercentage = 0.49; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//=================================================================================
//=================================================================================
//============================= ENGINEER-FEMALE ===================================
//=================================================================================
//=================================================================================

$DamageScale[efemale, $LandingDamageType] = 1.0; 
$DamageScale[efemale, $ImpactDamageType] = 1.0; 
$DamageScale[efemale, $CrushDamageType] = 1.0; 
$DamageScale[efemale, $BulletDamageType] = 1.0; 
$DamageScale[efemale, $EnergyDamageType] = 1.0; 
$DamageScale[efemale, $PlasmaDamageType] = 1.0; 
$DamageScale[efemale, $ExplosionDamageType] = 1.0; 
$DamageScale[efemale, $MissileDamageType] = 1.0; 
$DamageScale[efemale, $ShrapnelDamageType] = 1.0; 
$DamageScale[efemale, $DebrisDamageType] = 1.0; 
$DamageScale[efemale, $LaserDamageType] = 1.0; 
$DamageScale[efemale, $MortarDamageType] = 1.0; 
$DamageScale[efemale, $BlasterDamageType] = 1.0; 
$DamageScale[efemale, $ElectricityDamageType] = 1.0; 
$DamageScale[efemale, $MineDamageType] = 1.0; 
$DamageScale[efemale, $SniperDamageType] = 1.0; 
$DamageScale[efemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[efemale, Blaster] = 1; 
$ItemMax[efemale, Chaingun] = 1; 
$ItemMax[efemale, Disclauncher] = 1; 
$ItemMax[efemale, GrenadeLauncher] = 1; 
$ItemMax[efemale, Mortar] = 0; 
$ItemMax[efemale, PlasmaGun] = 1; 
$ItemMax[efemale, LaserRifle] = 0; 
$ItemMax[efemale, EnergyRifle] = 1;
$ItemMax[efemale, RocketLauncher] = 1; 
$ItemMax[efemale, SniperRifle] = 0; 
$ItemMax[efemale, WaveGun] = 0; 
$ItemMax[efemale, Railgun] = 1; 
$ItemMax[efemale, Gaussgun] = 0; 
$ItemMax[efemale, Vulcan] = 1; 
$ItemMax[efemale, Silencer] = 0; 
$ItemMax[efemale, Flamer] = 0; 
$ItemMax[efemale, IonGun] = 0;
$ItemMax[efemale, Shotgun] = 0; 
$ItemMax[efemale, TranqGun] = 0; 
$ItemMax[efemale, Napalm] = 0;
$ItemMax[efemale, Omega] = 1;
//=====================================================TOOLS
$ItemMax[efemale, JailGun] = 1; 
$ItemMax[efemale, TargetingLaser] = 1;
$ItemMax[efemale, Fixit] = 1; 
$ItemMax[efemale, Hackit] = 1;
//=====================================================ARMOR ITEMS
$ItemMax[efemale, Grenade] = 15; 
$ItemMax[efemale, Beacon] = 3; 
$ItemMax[efemale, Boost] = 4;
$ItemMax[efemale, RepairKit] = 1;  
$ItemMax[efemale, Plastique] = 0; 
$ItemMax[efemale, MineAmmo] = 15; 
//=====================================================AMMO
$ItemMax[efemale, FlamerAmmo] = 0; 
$ItemMax[efemale, ShotgunAmmo] = 10; 
$ItemMax[efemale, BulletAmmo] = 500; 
$ItemMax[efemale, PlasmaAmmo] = 80; 
$ItemMax[efemale, DiscAmmo] = 35; 
$ItemMax[efemale, GrenadeAmmo] = 20; 
$ItemMax[efemale, MortarAmmo] = 10; 
$ItemMax[efemale, RocketAmmo] = 10;
$ItemMax[efemale, MissileAmmo] = 5;  
$ItemMax[efemale, SniperAmmo] = 15; 
$ItemMax[efemale, RailAmmo] = 25; 
$ItemMax[efemale, VulcanAmmo] = 500; 
$ItemMax[efemale, TranqAmmo] = 20; 
$ItemMax[efemale, NapalmAmmo] = 10;
$ItemMax[efemale, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[efemale, EnergyPack] = 1; 
$ItemMax[efemale, RepairPack] = 1; 
$ItemMax[efemale, ShieldPack] = 1;
$ItemMax[efemale, AmmoPack] = 1;
$ItemMax[efemale, CloakingDevice] = 0; 
$ItemMax[efemale, StealthShieldPack] = 0;
$ItemMax[efemale, Laptop] = 1;
$ItemMax[efemale, RegenerationPack] = 0; 
$ItemMax[efemale, GasPack] = 0; 
$ItemMax[efemale, OpticPack] = 0; 
$ItemMax[efemale, SMRPack] = 0; 
$ItemMax[efemale, SuicidePack] = 0; 
$ItemMax[efemale, SensorJammerPack] = 0; 
//=====================================================SENSORS
$ItemMax[efemale, MotionSensorPack] = 1; 
$ItemMax[efemale, PulseSensorPack] = 1; 
$ItemMax[efemale, DeployableSensorJammerPack] = 1; 
$ItemMax[efemale, CameraPack] = 1; 
$ItemMax[efemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[efemale, DeployablevhclPack] = 1;
$ItemMax[efemale, DeployableInvPack] = 1; 
$ItemMax[efemale, DeployableAmmoPack] = 1; 
$ItemMax[efemale, DeployableComPack] = 1; 
//=====================================================TURRETS
$ItemMax[efemale, TurretPack] = 1; 
$ItemMax[efemale, LaserTurret] = 1;
$ItemMax[efemale, IndoorPack] = 1; 
$ItemMax[efemale, DeployableElfTurret] = 1; 
$ItemMax[efemale, AntiAirPack] = 1; 
$ItemMax[efemale, ShockPack] = 1; 
$ItemMax[efemale, RocketPack] = 1; 
$ItemMax[efemale, LaserPack] = 1;
$ItemMax[efemale, TargetPack] = 1; 
$ItemMax[efemale, RailTurret] = 1; 
$ItemMax[efemale, VulcanTurret] = 1;
//=====================================================WALLS
$ItemMax[efemale, ForceFieldPack] = 1;
$ItemMax[efemale, MedffPack] = 1;
$ItemMax[efemale, LargeForceFieldPack] = 1; 
$ItemMax[efemale, TripwirePack] = 1; 
$ItemMax[efemale, newdoorone] = 1;
$ItemMax[efemale, newdoortwo] = 1;
$ItemMax[efemale, newdoorthree] = 1;
$ItemMax[efemale, newdoorfour] = 1;
//=====================================================DOORS
$ItemMax[efemale, doorthreebyfourForceFieldPack] = 1;
$ItemMax[efemale, doorfourbyeightForceFieldPack] = 1;
$ItemMax[efemale, doorfourbyfourteenForceFieldPack] = 1;
$ItemMax[efemale, doorfourbyseventeenForceFieldPack] = 1;
$ItemMax[efemale, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[efemale, BlastDoorPack] = 1;
$ItemMax[efemale, PlatformDoorPack] = 1;
//=====================================================PLATFORMS
$ItemMax[efemale, LrgPltPack] = 1;
$ItemMax[efemale, PlatformPack] = 1; 
$ItemMax[efemale, MedPlatform] = 1;
//=====================================================ITEMS
$ItemMax[efemale, HoloPack] = 1; 
$ItemMax[efemale, TeleportPack] = 1; 
$ItemMax[efemale, SpringPack] = 1; 
$ItemMax[efemale, jailpack] = 1;
$ItemMax[efemale, JailCapPack] = 1;
$ItemMax[efemale, ArbitorBoxPack] = 1;
$ItemMax[efemale, TreePack] = 1;
$ItemMax[efemale, FlagstandPack] = 0;
$ItemMax[efemale, BuilderPole] = 1;
$ItemMax[efemale, RemoteBase] = 1;
$ItemMax[efemale, SniperHut] = 1;
//=====================================================VEHICLES
$ItemMax[efemale, BigBomberPack] = 0;
$ItemMax[efemale, cloakjetPack] = 0;
$ItemMax[efemale, bomberPack] = 0;
$ItemMax[efemale, MechPack] = 0;
$ItemMax[efemale, DetPack] = 0;

$MaxWeapons[efemale] = 5;

PlayerData efemale 
{ 
className = "Armor"; 
shapeFile = "mfemale"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 17; 
minJetEnergy = 1; 
jetForce = 325; 
jetEnergyDrain = 1.0; 
canCrouch = false; 
maxDamage = 1.0; 
maxForwardSpeed = 8.0; 
maxBackwardSpeed = 7.0; 
maxSideSpeed = 7.0; 
groundForce = 35 * 13.0; 
mass = 13.0; 
groundTraction = 3.0; 
maxEnergy = 90; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 110; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.84; 
boxNormalTorsoPercentage = 0.55;
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//===================================================================================
//===================================================================================
//============================== FLAG DEFENDER ======================================
//===================================================================================
//===================================================================================

$DamageScale[aarmor, $LandingDamageType] = 0.75; 
$DamageScale[aarmor, $ImpactDamageType] = 0.8; 
$DamageScale[aarmor, $CrushDamageType] = 1.0; 
$DamageScale[aarmor, $BulletDamageType] = 0.7; 
$DamageScale[aarmor, $PlasmaDamageType] = 0.8; 
$DamageScale[aarmor, $EnergyDamageType] = 1.0; 
$DamageScale[aarmor, $ExplosionDamageType] = 0.7; 
$DamageScale[aarmor, $MissileDamageType] = 0.9; 
$DamageScale[aarmor, $ShrapnelDamageType] = 0.7; 
$DamageScale[aarmor, $DebrisDamageType] = 0.7; 
$DamageScale[aarmor, $LaserDamageType] = 1.2; 
$DamageScale[aarmor, $MortarDamageType] = 0.5; 
$DamageScale[aarmor, $BlasterDamageType] = 1.0; 
$DamageScale[aarmor, $ElectricityDamageType] = 1.0; 
$DamageScale[aarmor, $MineDamageType] = 0.9; 
$DamageScale[aarmor, $SniperDamageType] = 1.2; 
$DamageScale[aarmor, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[aarmor, Blaster] = 1; 
$ItemMax[aarmor, Chaingun] = 1; 
$ItemMax[aarmor, Disclauncher] = 1; 
$ItemMax[aarmor, GrenadeLauncher] = 1; 
$ItemMax[aarmor, Mortar] = 0; 
$ItemMax[aarmor, PlasmaGun] = 1; 
$ItemMax[aarmor, LaserRifle] = 0; 
$ItemMax[aarmor, EnergyRifle] = 1;
$ItemMax[aarmor, RocketLauncher] = 1; 
$ItemMax[aarmor, SniperRifle] = 0; 
$ItemMax[aarmor, WaveGun] = 1; 
$ItemMax[aarmor, Railgun] = 0; 
$ItemMax[aarmor, Gaussgun] = 0; 
$ItemMax[aarmor, Vulcan] = 1; 
$ItemMax[aarmor, Silencer] = 0; 
$ItemMax[aarmor, Flamer] = 0; 
$ItemMax[aarmor, IonGun] = 1;
$ItemMax[aarmor, Shotgun] = 1; 
$ItemMax[aarmor, TranqGun] = 0; 
$ItemMax[aarmor, Napalm] = 1;
$ItemMax[aarmor, Omega] = 1;
//=====================================================TOOLS
$ItemMax[aarmor, JailGun] = 1; 
$ItemMax[aarmor, TargetingLaser] = 1;
$ItemMax[aarmor, Fixit] = 1; 
$ItemMax[aarmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[aarmor, Grenade] = 15; 
$ItemMax[aarmor, Beacon] = 3; 
$ItemMax[aarmor, Boost] = 4;
$ItemMax[aarmor, RepairKit] = 1;  
$ItemMax[aarmor, Plastique] = 0; 
$ItemMax[aarmor, MineAmmo] = 10; 
//=====================================================AMMO
$ItemMax[aarmor, FlamerAmmo] = 0; 
$ItemMax[aarmor, ShotgunAmmo] = 10; 
$ItemMax[aarmor, BulletAmmo] = 500; 
$ItemMax[aarmor, PlasmaAmmo] = 80; 
$ItemMax[aarmor, DiscAmmo] = 35; 
$ItemMax[aarmor, GrenadeAmmo] = 20; 
$ItemMax[aarmor, MortarAmmo] = 10; 
$ItemMax[aarmor, RocketAmmo] = 10;
$ItemMax[aarmor, MissileAmmo] = 15;  
$ItemMax[aarmor, SniperAmmo] = 15; 
$ItemMax[aarmor, RailAmmo] = 25; 
$ItemMax[aarmor, SilencerAmmo] = 15; 
$ItemMax[aarmor, VulcanAmmo] = 500; 
$ItemMax[aarmor, TranqAmmo] = 20; 
$ItemMax[aarmor, NapalmAmmo] = 10; 
//=====================================================BACKPACKS
$ItemMax[aarmor, EnergyPack] = 1; 
$ItemMax[aarmor, RepairPack] = 1; 
$ItemMax[aarmor, ShieldPack] = 1;
$ItemMax[aarmor, AmmoPack] = 1;
$ItemMax[aarmor, CloakingDevice] = 0; 
$ItemMax[aarmor, StealthShieldPack] = 0;
$ItemMax[aarmor, Laptop] = 1;
$ItemMax[aarmor, RegenerationPack] = 1; 
$ItemMax[aarmor, GasPack] = 0; 
$ItemMax[aarmor, OpticPack] = 0; 
$ItemMax[aarmor, SMRPack] = 0; 
$ItemMax[aarmor, SuicidePack] = 0; 
$ItemMax[aarmor, SensorJammerPack] = 0;
//=====================================================SENSORS
$ItemMax[aarmor, MotionSensorPack] = 1; 
$ItemMax[aarmor, PulseSensorPack] = 1; 
$ItemMax[aarmor, DeployableSensorJammerPack] = 1; 
$ItemMax[aarmor, CameraPack] = 1; 
$ItemMax[aarmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[aarmor, DeployablevhclPack] = 1;
$ItemMax[aarmor, DeployableInvPack] = 1; 
$ItemMax[aarmor, DeployableAmmoPack] = 1; 
$ItemMax[aarmor, DeployableComPack] = 1; 
//=====================================================TURRETS
$ItemMax[aarmor, TurretPack] = 0; 
$ItemMax[aarmor, LaserTurret] = 0;
$ItemMax[aarmor, IndoorPack] = 0; 
$ItemMax[aarmor, DeployableElfTurret] = 1; 
$ItemMax[aarmor, AntiAirPack] = 0; 
$ItemMax[aarmor, ShockPack] = 0; 
$ItemMax[aarmor, RocketPack] = 0; 
$ItemMax[aarmor, LaserPack] = 0;
$ItemMax[aarmor, TargetPack] = 1; 
$ItemMax[aarmor, RailTurret] = 0; 
$ItemMax[aarmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[aarmor, ForceFieldPack] = 1;
$ItemMax[aarmor, MedffPack] = 1;
$ItemMax[aarmor, LargeForceFieldPack] = 1; 
$ItemMax[aarmor, TripwirePack] = 1; 
$ItemMax[aarmor, newdoorone] = 1;
$ItemMax[aarmor, newdoortwo] = 1;
$ItemMax[aarmor, newdoorthree] = 1;
$ItemMax[aarmor, newdoorfour] = 1;
//=====================================================DOORS
$ItemMax[aarmor, doorthreebyfourForceFieldPack] = 1;
$ItemMax[aarmor, doorfourbyeightForceFieldPack] = 1;
$ItemMax[aarmor, doorfourbyfourteenForceFieldPack] = 1;
$ItemMax[aarmor, doorfourbyseventeenForceFieldPack] = 1;
$ItemMax[aarmor, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[aarmor, BlastDoorPack] = 1;
$ItemMax[aarmor, PlatformDoorPack] = 1;
//=====================================================PLATFORMS
$ItemMax[aarmor, LrgPltPack] = 1;
$ItemMax[aarmor, PlatformPack] = 1; 
$ItemMax[aarmor, MedPlatform] = 1;
//=====================================================ITEMS
$ItemMax[aarmor, HoloPack] = 1; 
$ItemMax[aarmor, TeleportPack] = 1; 
$ItemMax[aarmor, SpringPack] = 1; 
$ItemMax[aarmor, jailpack] = 1;
$ItemMax[aarmor, JailCapPack] = 1;
$ItemMax[aarmor, ArbitorBoxPack] = 1;
$ItemMax[aarmor, TreePack] = 0;
$ItemMax[aarmor, FlagstandPack] = 1;
$ItemMax[aarmor, BuilderPole] = 1;
$ItemMax[aarmor, RemoteBase] = 1;
$ItemMax[aarmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[aarmor, BigBomberPack] = 0;
$ItemMax[aarmor, cloakjetPack] = 0;
$ItemMax[aarmor, bomberPack] = 0;
$ItemMax[aarmor, MechPack] = 0;
$ItemMax[aarmor, DetPack] = 0; 
$MaxWeapons[aarmor] = 6; 

PlayerData aarmor 
{ 
className = "Armor"; 
shapeFile = "harmor"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
canCrouch = false; 
visibleToSensor = False; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.75; 
maxJetForwardVelocity = 12; 
minJetEnergy = 1; 
jetForce = 720; 
jetEnergyDrain = 1.35; 
maxDamage = 1.6; 
maxForwardSpeed = 7.0; 
maxBackwardSpeed = 6.0; 
maxSideSpeed = 5.0; 
groundForce = 35 * 35.0; 
mass = 35.0; 
groundTraction = 6.5; 
maxEnergy = 200; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 175; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.84; 
boxNormalTorsoPercentage = 0.49; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
};
 
//===================================================================================
//===================================================================================
//============================= FLAG DEFENDER-FEMALE ================================
//===================================================================================
//===================================================================================

$DamageScale[afemale, $LandingDamageType] = 0.75; 
$DamageScale[afemale, $ImpactDamageType] = 0.8; 
$DamageScale[afemale, $CrushDamageType] = 1.0; 
$DamageScale[afemale, $BulletDamageType] = 0.7; 
$DamageScale[afemale, $PlasmaDamageType] = 0.8; 
$DamageScale[afemale, $EnergyDamageType] = 1.0; 
$DamageScale[afemale, $ExplosionDamageType] = 0.7; 
$DamageScale[afemale, $MissileDamageType] = 0.9; 
$DamageScale[afemale, $ShrapnelDamageType] = 0.7; 
$DamageScale[afemale, $DebrisDamageType] = 0.7; 
$DamageScale[afemale, $LaserDamageType] =1.2; 
$DamageScale[afemale, $MortarDamageType] = 0.5; 
$DamageScale[afemale, $BlasterDamageType] = 1.0; 
$DamageScale[afemale, $ElectricityDamageType] = 1.1; 
$DamageScale[afemale, $MineDamageType] = 0.9; 
$DamageScale[afemale, $SniperDamageType] = 1.2; 
$DamageScale[afemale, $FlashDamageType] = 1.0; 

//=====================================================WEAPONS
$ItemMax[afemale, Blaster] = 1; 
$ItemMax[afemale, Chaingun] = 1; 
$ItemMax[afemale, Disclauncher] = 1; 
$ItemMax[afemale, GrenadeLauncher] = 1; 
$ItemMax[afemale, Mortar] = 0; 
$ItemMax[afemale, PlasmaGun] = 1; 
$ItemMax[afemale, LaserRifle] = 0; 
$ItemMax[afemale, EnergyRifle] = 1;
$ItemMax[afemale, RocketLauncher] = 1; 
$ItemMax[afemale, SniperRifle] = 0; 
$ItemMax[afemale, WaveGun] = 1; 
$ItemMax[afemale, Railgun] = 0; 
$ItemMax[afemale, Gaussgun] = 0; 
$ItemMax[afemale, Vulcan] = 1; 
$ItemMax[afemale, Silencer] = 0; 
$ItemMax[afemale, Flamer] = 0; 
$ItemMax[afemale, IonGun] = 1;
$ItemMax[afemale, Shotgun] = 1; 
$ItemMax[afemale, TranqGun] = 0; 
$ItemMax[afemale, Napalm] = 1;
$ItemMax[afemale, Omega] = 1;
//=====================================================TOOLS
$ItemMax[afemale, JailGun] = 1; 
$ItemMax[afemale, TargetingLaser] = 1;
$ItemMax[afemale, Fixit] = 1; 
$ItemMax[afemale, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[afemale, Grenade] = 15; 
$ItemMax[afemale, Beacon] = 3; 
$ItemMax[afemale, Boost] = 4;
$ItemMax[afemale, RepairKit] = 1;  
$ItemMax[afemale, Plastique] = 0; 
$ItemMax[afemale, MineAmmo] = 10; 
//=====================================================AMMO
$ItemMax[afemale, FlamerAmmo] = 0; 
$ItemMax[afemale, ShotgunAmmo] = 10; 
$ItemMax[afemale, BulletAmmo] = 500; 
$ItemMax[afemale, PlasmaAmmo] = 80; 
$ItemMax[afemale, DiscAmmo] = 35; 
$ItemMax[afemale, GrenadeAmmo] = 20; 
$ItemMax[afemale, MortarAmmo] = 10; 
$ItemMax[afemale, RocketAmmo] = 10;
$ItemMax[afemale, MissileAmmo] = 10;  
$ItemMax[afemale, SniperAmmo] = 15; 
$ItemMax[afemale, RailAmmo] = 25; 
$ItemMax[afemale, SilencerAmmo] = 15; 
$ItemMax[afemale, VulcanAmmo] = 500; 
$ItemMax[afemale, TranqAmmo] = 20; 
$ItemMax[afemale, NapalmAmmo] = 10; 
//=====================================================BACKPACKS
$ItemMax[afemale, EnergyPack] = 1; 
$ItemMax[afemale, RepairPack] = 1; 
$ItemMax[afemale, ShieldPack] = 1;
$ItemMax[afemale, AmmoPack] = 1;
$ItemMax[afemale, CloakingDevice] = 0; 
$ItemMax[afemale, StealthShieldPack] = 0;
$ItemMax[afemale, Laptop] = 1;
$ItemMax[afemale, RegenerationPack] = 1; 
$ItemMax[afemale, GasPack] = 0; 
$ItemMax[afemale, OpticPack] = 0; 
$ItemMax[afemale, SMRPack] = 0; 
$ItemMax[afemale, SuicidePack] = 0; 
$ItemMax[afemale, SensorJammerPack] = 0;
//=====================================================SENSORS
$ItemMax[afemale, MotionSensorPack] = 1; 
$ItemMax[afemale, PulseSensorPack] = 1; 
$ItemMax[afemale, DeployableSensorJammerPack] = 1; 
$ItemMax[afemale, CameraPack] = 1; 
$ItemMax[afemale, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[afemale, DeployablevhclPack] = 1;
$ItemMax[afemale, DeployableInvPack] = 1; 
$ItemMax[afemale, DeployableAmmoPack] = 1; 
$ItemMax[afemale, DeployableComPack] = 1; 
//=====================================================TURRETS
$ItemMax[afemale, TurretPack] = 0; 
$ItemMax[afemale, LaserTurret] = 0;
$ItemMax[afemale, IndoorPack] = 0; 
$ItemMax[afemale, DeployableElfTurret] = 1; 
$ItemMax[afemale, AntiAirPack] = 0; 
$ItemMax[afemale, ShockPack] = 0; 
$ItemMax[afemale, RocketPack] = 0; 
$ItemMax[afemale, LaserPack] = 0;
$ItemMax[afemale, TargetPack] = 1; 
$ItemMax[afemale, RailTurret] = 0; 
$ItemMax[afemale, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[afemale, ForceFieldPack] = 1;
$ItemMax[afemale, MedffPack] = 1;
$ItemMax[afemale, LargeForceFieldPack] = 1; 
$ItemMax[afemale, TripwirePack] = 1; 
$ItemMax[afemale, newdoorone] = 1;
$ItemMax[afemale, newdoortwo] = 1;
$ItemMax[afemale, newdoorthree] = 1;
$ItemMax[afemale, newdoorfour] = 1;
//=====================================================DOORS
$ItemMax[afemale, doorthreebyfourForceFieldPack] = 1;
$ItemMax[afemale, doorfourbyeightForceFieldPack] = 1;
$ItemMax[afemale, doorfourbyfourteenForceFieldPack] = 1;
$ItemMax[afemale, doorfourbyseventeenForceFieldPack] = 1;
$ItemMax[afemale, doorfivebyfiveForceFieldPack] = 1;
$ItemMax[afemale, BlastDoorPack] = 1;
$ItemMax[afemale, PlatformDoorPack] = 1;
//=====================================================PLATFORMS
$ItemMax[afemale, LrgPltPack] = 1;
$ItemMax[afemale, PlatformPack] = 1; 
$ItemMax[afemale, MedPlatform] = 1;
//=====================================================ITEMS
$ItemMax[afemale, HoloPack] = 1; 
$ItemMax[afemale, TeleportPack] = 1; 
$ItemMax[afemale, SpringPack] = 1; 
$ItemMax[afemale, jailpack] = 1;
$ItemMax[afemale, JailCapPack] = 1;
$ItemMax[afemale, ArbitorBoxPack] = 1;
$ItemMax[afemale, TreePack] = 0;
$ItemMax[afemale, FlagstandPack] = 1;
$ItemMax[afemale, BuilderPole] = 1;
$ItemMax[afemale, RemoteBase] = 1;
$ItemMax[afemale, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[afemale, BigBomberPack] = 0;
$ItemMax[afemale, cloakjetPack] = 0;
$ItemMax[afemale, bomberPack] = 0;
$ItemMax[afemale, MechPack] = 0;
$ItemMax[afemale, DetPack] = 0; 

$MaxWeapons[afemale] = 6; 

PlayerData afemale 
{ 
className = "Armor"; 
shapeFile = "harmor"; 
flameShapeName = "mflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.75; 
maxJetForwardVelocity = 12; 
minJetEnergy = 1; 
jetForce = 720; 
jetEnergyDrain = 1.35; 
canCrouch = false; 
maxDamage = 1.6; 
maxForwardSpeed = 7.0; 
maxBackwardSpeed = 6.0; 
maxSideSpeed = 5.0; 
groundForce = 35 * 35.0; 
mass = 35.0; 
groundTraction = 6.5; 
maxEnergy = 200; 
drag = 1.0; 
density = 1.5; 
minDamageSpeed = 25; 
damageScale = 0.005; 
jumpImpulse = 175; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetLight; 
rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; 
lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; 
footPrints = { 2, 3 }; 
boxWidth = 0.7; 
boxDepth = 0.7; 
boxNormalHeight = 2.4; 
boxNormalHeadPercentage = 0.84; 
boxNormalTorsoPercentage = 0.55; 
boxHeadLeftPercentage = 0; 
boxHeadRightPercentage = 1; 
boxHeadBackPercentage = 0; 
boxHeadFrontPercentage = 1; 
}; 

//================================================================================
//================================================================================
//================================== CYBORG ======================================
//================================================================================
//================================================================================

$DamageScale[darmor, $LandingDamageType] = 0.8; 
$DamageScale[darmor, $ImpactDamageType] = 0.8; 
$DamageScale[darmor, $CrushDamageType] = 0.8; 
$DamageScale[darmor, $BulletDamageType] = 0.5; 
$DamageScale[darmor, $PlasmaDamageType] = 0.7; 
$DamageScale[darmor, $EnergyDamageType] = 0.7; 
$DamageScale[darmor, $ExplosionDamageType] = 0.6; 
$DamageScale[darmor, $MissileDamageType] = 0.6; 
$DamageScale[darmor, $DebrisDamageType] = 0.8; 
$DamageScale[darmor, $ShrapnelDamageType] = 0.8; 
$DamageScale[darmor, $LaserDamageType] = 0.6; 
$DamageScale[darmor, $MortarDamageType] = 0.7; 
$DamageScale[darmor, $BlasterDamageType] = 0.7; 
$DamageScale[darmor, $ElectricityDamageType] = 0.75; 
$DamageScale[darmor, $MineDamageType] = 0.8; 
$DamageScale[darmor, $SniperDamageType] = 0.8; 
$DamageScale[darmor, $FlashDamageType] = 1.0;
 
//=====================================================WEAPONS
$ItemMax[darmor, Blaster] = 1; 
$ItemMax[darmor, Chaingun] = 1; 
$ItemMax[darmor, Disclauncher] = 1; 
$ItemMax[darmor, GrenadeLauncher] = 1; 
$ItemMax[darmor, Mortar] = 1; 
$ItemMax[darmor, PlasmaGun] = 1; 
$ItemMax[darmor, LaserRifle] = 0; 
$ItemMax[darmor, EnergyRifle] = 1;
$ItemMax[darmor, RocketLauncher] = 1; 
$ItemMax[darmor, SniperRifle] = 0; 
$ItemMax[darmor, WaveGun] = 1; 
$ItemMax[darmor, Railgun] = 0; 
$ItemMax[darmor, Gaussgun] = 0; 
$ItemMax[darmor, Vulcan] = 1; 
$ItemMax[darmor, Silencer] = 0; 
$ItemMax[darmor, Flamer] = 0; 
$ItemMax[darmor, IonGun] = 0;
$ItemMax[darmor, Shotgun] = 1; 
$ItemMax[darmor, TranqGun] = 0; 
$ItemMax[darmor, Napalm] = 1;
$ItemMax[darmor, Omega] = 1;
//=====================================================TOOLS
$ItemMax[darmor, JailGun] = 1; 
$ItemMax[darmor, TargetingLaser] = 1;
$ItemMax[darmor, Fixit] = 0; 
$ItemMax[darmor, Hackit] = 0;
//=====================================================ARMOR ITEMS
$ItemMax[darmor, Grenade] = 10; 
$ItemMax[darmor, Beacon] = 5; 
$ItemMax[darmor, Boost] = 4;
$ItemMax[darmor, RepairKit] = 1;  
$ItemMax[darmor, Plastique] = 0; 
$ItemMax[darmor, MineAmmo] = 20; 
//=====================================================AMMO
$ItemMax[darmor, FlamerAmmo] = 0; 
$ItemMax[darmor, ShotgunAmmo] = 20; 
$ItemMax[darmor, BulletAmmo] = 300; 
$ItemMax[darmor, PlasmaAmmo] = 50; 
$ItemMax[darmor, DiscAmmo] = 30; 
$ItemMax[darmor, GrenadeAmmo] = 20; 
$ItemMax[darmor, MortarAmmo] = 10; 
$ItemMax[darmor, RocketAmmo] = 10;
$ItemMax[darmor, MissileAmmo] = 15;  
$ItemMax[darmor, SniperAmmo] = 15; 
$ItemMax[darmor, RailAmmo] = 25; 
$ItemMax[darmor, VulcanAmmo] = 400; 
$ItemMax[darmor, TranqAmmo] = 20; 
$ItemMax[darmor, NapalmAmmo] = 10;
$ItemMax[darmor, SilencerAmmo] = 30;  
//=====================================================BACKPACKS
$ItemMax[darmor, EnergyPack] = 1; 
$ItemMax[darmor, RepairPack] = 1; 
$ItemMax[darmor, ShieldPack] = 1;
$ItemMax[darmor, AmmoPack] = 1;
$ItemMax[darmor, CloakingDevice] = 0; 
$ItemMax[darmor, StealthShieldPack] = 1;
$ItemMax[darmor, Laptop] = 0;
$ItemMax[darmor, RegenerationPack] = 0; 
$ItemMax[darmor, LightningPack] = 0; 
$ItemMax[darmor, OpticPack] = 0; 
$ItemMax[darmor, SMRPack] = 1; 
$ItemMax[darmor, SuicidePack] = 0;
$ItemMax[darmor, SensorJammerPack] = 0;  
//=====================================================SENSORS
$ItemMax[darmor, MotionSensorPack] = 1; 
$ItemMax[darmor, PulseSensorPack] = 1; 
$ItemMax[darmor, DeployableSensorJammerPack] = 1; 
$ItemMax[darmor, CameraPack] = 1; 
$ItemMax[darmor, BaseAlarm] = 1;
//=====================================================STATIONS
$ItemMax[darmor, DeployablevhclPack] = 0;
$ItemMax[darmor, DeployableInvPack] = 0; 
$ItemMax[darmor, DeployableAmmoPack] = 1; 
$ItemMax[darmor, DeployableComPack] = 0; 
//=====================================================TURRETS
$ItemMax[darmor, TurretPack] = 0; 
$ItemMax[darmor, LaserTurret] = 0;
$ItemMax[darmor, IndoorPack] = 0; 
$ItemMax[darmor, DeployableElfTurret] = 0; 
$ItemMax[darmor, AntiAirPack] = 1; 
$ItemMax[darmor, ShockPack] = 0; 
$ItemMax[darmor, RocketPack] = 1; 
$ItemMax[darmor, LaserPack] = 0;
$ItemMax[darmor, TargetPack] = 0; 
$ItemMax[darmor, RailTurret] = 0; 
$ItemMax[darmor, VulcanTurret] = 0;
//=====================================================WALLS
$ItemMax[darmor, ForceFieldPack] = 1;
$ItemMax[darmor, MedffPack] = 0;
$ItemMax[darmor, LargeForceFieldPack] = 0; 
$ItemMax[darmor, TripwirePack] = 0; 
$ItemMax[darmor, newdoorone] = 0;
$ItemMax[darmor, newdoortwo] = 0;
$ItemMax[darmor, newdoorthree] = 0;
$ItemMax[darmor, newdoorfour] = 0;
//=====================================================DOORS
$ItemMax[darmor, doorthreebyfourForceFieldPack] = 0;
$ItemMax[darmor, doorfourbyeightForceFieldPack] = 0;
$ItemMax[darmor, doorfourbyfourteenForceFieldPack] = 0;
$ItemMax[darmor, doorfourbyseventeenForceFieldPack] = 0;
$ItemMax[darmor, doorfivebyfiveForceFieldPack] = 0;
$ItemMax[darmor, BlastDoorPack] = 0;
$ItemMax[darmor, PlatformDoorPack] = 0;
//=====================================================PLATFORMS
$ItemMax[darmor, LrgPltPack] = 0;
$ItemMax[darmor, PlatformPack] = 0; 
$ItemMax[darmor, MedPlatform] = 0;
//=====================================================ITEMS
$ItemMax[darmor, HoloPack] = 1; 
$ItemMax[darmor, TeleportPack] = 0; 
$ItemMax[darmor, SpringPack] = 1; 
$ItemMax[darmor, jailpack] = 1;
$ItemMax[darmor, JailCapPack] = 1;
$ItemMax[darmor, ArbitorBoxPack] = 0;
$ItemMax[darmor, TreePack] = 0;
$ItemMax[darmor, FlagstandPack] = 0;
$ItemMax[darmor, BuilderPole] = 0;
$ItemMax[darmor, RemoteBase] = 0;
$ItemMax[darmor, SniperHut] = 0;
//=====================================================VEHICLES
$ItemMax[darmor, BigBomberPack] = 0;
$ItemMax[darmor, cloakjetPack] = 0;
$ItemMax[darmor, bomberPack] = 0;
$ItemMax[darmor, MechPack] = 0;
$ItemMax[darmor, DetPack] = 0;
$MaxWeapons[darmor] = 6; 

PlayerData darmor 
{ 
className = "Armor"; 
shapeFile = "harmor"; 
flameShapeName = "hflame"; 
shieldShapeName = "shield"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8; 
maxJetForwardVelocity = 30; 
minJetEnergy = 1; 
jetForce = 395; 
jetEnergyDrain = 1.1; 
maxDamage = 1.60; 
maxForwardSpeed = 6.0; 
maxBackwardSpeed = 5.0; 
maxSideSpeed = 4.0; 
groundForce = 35 * 19.0; 
groundTraction = 4.5; 
mass = 19.0; 
maxEnergy = 300; 
drag = 1.0; 
density = 2.5; 
canCrouch = false; 
minDamageSpeed = 25; 
damageScale = 0.006; 
jumpImpulse = 200; 
jumpSurfaceMinDot = 0.2; 
animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; 
animData[3] = { "side left", none, 1, true, false, true, false, 3 }; 
animData[4] = { "side left", none, -1, true, false, true, false, 3 }; 
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; 
animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; 
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; 
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; 
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; 
animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; 
animData[21] = { "throw", none, 1, true, false, false, false, 3 }; 
animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; 
animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; 
animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; 
animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; 
animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 
animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; 
animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; 
animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; 
animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; 
animData[50] = { "wave", none, 1, true, false, false, true, 1 }; 
jetSound = SoundJetHeavy; 
rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft }; 
lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft }; 
footPrints = { 4, 5 }; 
boxWidth = 0.8; boxDepth = 0.8; 
boxNormalHeight = 2.6; 
boxNormalHeadPercentage = 0.70; 
boxNormalTorsoPercentage = 0.45; 
boxHeadLeftPercentage = 0.48; 
boxHeadRightPercentage = 0.70; 
boxHeadBackPercentage = 0.48; 
boxHeadFrontPercentage = 0.60; 
}; 

