///-----------------------------------------------
/// Engineer
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Female, EngArmor] = efemale;

$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;

$MaxWeapons[earmor] = 3;
$MaxWeapons[efemale] = 3;

ItemData EngArmor
{
   heading = "aArmor";
        description = "Engineer";
        className = "Armor";
        price = 250;
};
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

$ItemMax[earmor, Blaster] = 1;
$ItemMax[earmor, Chaingun] = 1;
$ItemMax[earmor, Disclauncher] = 1;
$ItemMax[earmor, GrenadeLauncher] = 1;
$ItemMax[earmor, Mortar] = 0;
$ItemMax[earmor, PlasmaGun] = 1;
$ItemMax[earmor, LaserRifle] = 1;
$ItemMax[earmor, EnergyRifle] = 1;
$ItemMax[earmor, TargetingLaser] = 1;
$ItemMax[earmor, MineAmmo] = 3;
$ItemMax[earmor, Grenade] = 5;
$ItemMax[earmor, Beacon] = 3;

$ItemMax[earmor, BulletAmmo] = 100;
$ItemMax[earmor, PlasmaAmmo] = 30;
$ItemMax[earmor, DiscAmmo] = 15;
$ItemMax[earmor, GrenadeAmmo] = 10;
$ItemMax[earmor, MortarAmmo] = 10;

$ItemMax[earmor, EnergyPack] = 1;
$ItemMax[earmor, RepairPack] = 1;
$ItemMax[earmor, ShieldPack] = 1;
$ItemMax[earmor, SensorJammerPack] = 1;
$ItemMax[earmor, MotionSensorPack] = 1;
$ItemMax[earmor, PulseSensorPack] = 1;
$ItemMax[earmor, DeployableSensorJammerPack] = 1;
$ItemMax[earmor, CameraPack] = 1;
$ItemMax[earmor, TurretPack] = 0;
$ItemMax[earmor, AmmoPack] = 1;
$ItemMax[earmor, RepairKit] = 1;
$ItemMax[earmor, DeployableInvPack] = 0;
$ItemMax[earmor, DeployableAmmoPack] = 0;

$ItemMax[efemale, Blaster] = 1;
$ItemMax[efemale, Chaingun] = 1;
$ItemMax[efemale, Disclauncher] = 1;
$ItemMax[efemale, GrenadeLauncher] = 1;
$ItemMax[efemale, Mortar] = 0;
$ItemMax[efemale, PlasmaGun] = 1;
$ItemMax[efemale, LaserRifle] = 1;
$ItemMax[efemale, EnergyRifle] = 1;
$ItemMax[efemale, TargetingLaser] = 1;
$ItemMax[efemale, MineAmmo] = 3;
$ItemMax[efemale, Grenade] = 5;
$ItemMax[efemale, Beacon] = 3;

$ItemMax[efemale, BulletAmmo] = 100;
$ItemMax[efemale, PlasmaAmmo] = 30;
$ItemMax[efemale, DiscAmmo] = 15;
$ItemMax[efemale, GrenadeAmmo] = 10;
$ItemMax[efemale, MortarAmmo] = 10;

$ItemMax[efemale, EnergyPack] = 1;
$ItemMax[efemale, RepairPack] = 1;
$ItemMax[efemale, ShieldPack] = 1;
$ItemMax[efemale, SensorJammerPack] = 1;
$ItemMax[efemale, MotionSensorPack] = 1;
$ItemMax[efemale, PulseSensorPack] = 1;
$ItemMax[efemale, DeployableSensorJammerPack] = 1;
$ItemMax[efemale, CameraPack] = 1;
$ItemMax[efemale, TurretPack] = 0;
$ItemMax[efemale, AmmoPack] = 1;
$ItemMax[efemale, RepairKit] = 1;
$ItemMax[efemale, DeployableInvPack] = 0;
$ItemMax[efemale, DeployableAmmoPack] = 0;




PlayerData earmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
        debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = true;
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


   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };

   // death animations:
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

   // signal moves:
        animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

        // Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


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

   canCrouch = true;
        maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;

        maxEnergy = 90;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

        minDamageSpeed = 25;
        damageScale = 0.005;

   jumpImpulse = 125;
   jumpSurfaceMinDot = 0.2;

     // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };

   // death animations:
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

   // signal moves:
        animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

        // Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetLight;

   rFootSounds =
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  };
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};