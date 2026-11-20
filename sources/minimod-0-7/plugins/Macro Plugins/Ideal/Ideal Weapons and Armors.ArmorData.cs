// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they WILL cause
//  massive amounts of clashing with other plugins!!!

// The following has been placed here for lack of "Game.cs" support.
$deathMsg[$LCGDamageType, 0]       = "%1 adds a few scorches to %2's hide.";
$deathMsg[$LCGDamageType, 1]       = "%1 gives %2 a much needed hole in the head.";
$deathMsg[$LCGDamageType, 2]       = "%2 becomes a victim of %1's laser chaingun.";
$deathMsg[$LCGDamageType, 3]       = "%2 was cut in half by %1's laser chaingun.";
$deathMsg[$MarlinDamageType, 0]       = "%1 snipes %2.";
$deathMsg[$MarlinDamageType, 1]       = "%2 claimed to be immortal. %1 proved him wrong.";
$deathMsg[$MarlinDamageType, 2]       = "%1 tells %2 you zigged when you should have zagged.";
$deathMsg[$MarlinDamageType, 3]       = "%1 shaves a little too much off %2.";
$deathMsg[$SCVDamageType, 0]       = "%2 confuses everyone by letting %1, an SCV, kill him.";
$deathMsg[$SCVDamageType, 1]       = "%2 proves his infinite stupidity by being killed by %1's Nanite Assembler.";
$deathMsg[$SCVDamageType, 2]       = "%2 shows off his mad dying skills.";
$deathMsg[$SCVDamageType, 3]       = "%1 says, 'Sorry %2, I thought I was repairing you...'";
$deathMsg[$FlameDamageType, 0]       = "%1 says to %2, 'Only I can prevent forest fires.'";
$deathMsg[$FlameDamageType, 1]       = "%2 needed a light. %1 gave it to him.";
$deathMsg[$FlameDamageType, 2]       = "%2 dies of %1's second-hand smoke.";
$deathMsg[$FlameDamageType, 3]       = "%1 says to %2, 'Toasty!'";
// End of displacment.

$DamageScale[larmor, $SCVDamageType] = 0.9;
$DamageScale[marmor, $SCVDamageType] = 1.0;
$DamageScale[harmor, $SCVDamageType] = 1.1;
$DamageScale[lfemale, $SCVDamageType] = 0.9;
$DamageScale[mfemale, $SCVDamageType] = 1.0;
$DamageScale[sarmor, $SCVDamageType] = 1.4;
$DamageScale[aarmor, $SCVDamageType] = 1.0;
$DamageScale[tarmor, $SCVDamageType] = 1.3;
$DamageScale[scvarmor, $SCVDamageType] = 2.0;


$DamageScale[larmor, $FlameDamageType] = 0.9;
$DamageScale[marmor, $FlameDamageType] = 1.0;
$DamageScale[harmor, $FlameDamageType] = 1.1;
$DamageScale[lfemale, $FlameDamageType] = 0.9;
$DamageScale[mfemale, $FlameDamageType] = 1.0;
$DamageScale[sarmor, $FlameDamageType] = 1.4;
$DamageScale[aarmor, $FlameDamageType] = 1.0;
$DamageScale[tarmor, $FlameDamageType] = 1.3;
$DamageScale[scvarmor, $FlameDamageType] = 1.0;


$ItemMax[harmor, ObeliskPowerPack] = 1;
$ItemMax[tarmor, JetfirePack] = 1;
$ItemMax[harmor, FlameTurretPack] = 1;

$ItemMax[larmor, TractorBeam] = 1;
$ItemMax[marmor, TractorBeam] = 1;
$ItemMax[harmor, TractorBeam] = 1;
$ItemMax[lfemale, TractorBeam] = 1;
$ItemMax[mfemale, TractorBeam] = 1;
$ItemMax[tarmor, TractorBeam] = 1;

$DamageScale[larmor, $ObeliskDamageType] = 1.0;
$DamageScale[marmor, $ObeliskDamageType] = 0.9;
$DamageScale[harmor, $ObeliskDamageType] = 0.8;
$DamageScale[lfemale, $ObeliskDamageType] = 1.0;
$DamageScale[mfemale, $ObeliskDamageType] = 0.9;
$DamageScale[sarmor, $ObeliskDamageType] = 0.2;
$DamageScale[aarmor, $ObeliskDamageType] = 1.0;
$DamageScale[tarmor, $ObeliskDamageType] = 0.9;
$DamageScale[scvarmor, $ObeliskDamageType] = 1.0;

$ItemMax[harmor, ArbitorBoxPack] = 1;

$ItemMax[larmor, FlagMine] = 1;
$ItemMax[marmor, FlagMine] = 1;
$ItemMax[harmor, FlagMine] = 1;
$ItemMax[lfemale, FlagMine] = 1;
$ItemMax[mfemale, FlagMine] = 1;
$ItemMax[sarmor, FlagMine] = 1;

$ItemMax[larmor, ReplicatingMine] = 1;
$ItemMax[marmor, ReplicatingMine] = 1;
$ItemMax[harmor, ReplicatingMine] = 1;
$ItemMax[lfemale, ReplicatingMine] = 1;
$ItemMax[mfemale, ReplicatingMine] = 1;


$ItemMax[larmor, OriginalMine] = 3;
$ItemMax[marmor, OriginalMine] = 4;
$ItemMax[harmor, OriginalMine] = 5;
$ItemMax[lfemale, OriginalMine] = 3;
$ItemMax[mfemale, OriginalMine] = 4;
$ItemMax[sarmor, OriginalMine] = 2;


$ItemMax[marmor, SuperSensorPack] = 1;
$ItemMax[harmor, SuperSensorPack] = 1;
$ItemMax[mfemale, SuperSensorPack] = 1;
$ItemMax[sarmor, SuperSensorPack] = 1;

$ItemMax[harmor, ObeliskPack] = 1;

$ItemMax[tarmor, JetFirePack] = 1;

//$ItemMax[aarmor, ChangelingNet] = 1;

$ItemMax[larmor, FlagMovePack] = 1;
$ItemMax[marmor, FlagMovePack] = 1;
$ItemMax[harmor, FlagMovePack] = 1;
$ItemMax[lfemale, FlagMovePack] = 1;
$ItemMax[mfemale, FlagMovePack] = 1;
$ItemMax[sarmor, FlagMovePack] = 1;

$ItemMax[larmor, Marlin] = 1;
$ItemMax[marmor, Marlin] = 1;
$ItemMax[lfemale, Marlin] = 1;
$ItemMax[mfemale, Marlin] = 1;


$ItemMax[larmor, MarlinAmmo] = 8;
$ItemMax[marmor, MarlinAmmo] = 16;
$ItemMax[lfemale, MarlinAmmo] = 8;
$ItemMax[mfemale, MarlinAmmo] = 16;


$ItemMax[larmor, TreePack] = 1;
$ItemMax[marmor, TreePack] = 1;
$ItemMax[harmor, TreePack] = 1;
$ItemMax[lfemale, TreePack] = 1;
$ItemMax[mfemale, TreePack] = 1;
$ItemMax[sarmor, TreePack] = 1;

$ItemMax[larmor, C4Ammo] = 2;
$ItemMax[marmor, C4Ammo] = 3;
$ItemMax[harmor, C4Ammo] = 4;
$ItemMax[lfemale, C4Ammo] = 2;
$ItemMax[mfemale, C4Ammo] = 3;

$ItemMax[larmor, HandgrenadeAmmo] = 5;
$ItemMax[marmor, HandgrenadeAmmo] = 6;
$ItemMax[harmor, HandgrenadeAmmo] = 8;
$ItemMax[lfemale, HandgrenadeAmmo] = 5;
$ItemMax[mfemale, HandgrenadeAmmo] = 6;
$ItemMax[sarmor, HandgrenadeAmmo] = 3;

$ItemMax[larmor, FlashgrenadeAmmo] = 12;
$ItemMax[marmor, FlashgrenadeAmmo] = 15;
$ItemMax[harmor, FlashgrenadeAmmo] = 18;
$ItemMax[lfemale, FlashgrenadeAmmo] = 12;
$ItemMax[mfemale, FlashgrenadeAmmo] = 15;
$ItemMax[sarmor, FlashgrenadeAmmo] = 8;

$ItemMax[larmor, StungrenadeAmmo] = 5;
$ItemMax[marmor, StungrenadeAmmo] = 6;
$ItemMax[harmor, StungrenadeAmmo] = 8;
$ItemMax[lfemale, StungrenadeAmmo] = 5;
$ItemMax[mfemale, StungrenadeAmmo] = 6;
$ItemMax[sarmor, StungrenadeAmmo] = 3;

$ItemMax[larmor, SuicideAmmo] = 1;
$ItemMax[marmor, SuicideAmmo] = 1;
$ItemMax[harmor, SuicideAmmo] = 1;
$ItemMax[lfemale, SuicideAmmo] = 1;
$ItemMax[mfemale, SuicideAmmo] = 1;

$DamageScale[larmor, $MarlinDamageType] = 1.0;
$DamageScale[marmor, $MarlinDamageType] = 1.0;
$DamageScale[harmor, $MarlinDamageType] = 1.0;
$DamageScale[lfemale, $MarlinDamageType] = 1.0;
$DamageScale[mfemale, $MarlinDamageType] = 1.0;
$DamageScale[sarmor, $MarlinDamageType] = 1.0;
$DamageScale[aarmor, $MarlinDamageType] = 1.0;
$DamageScale[tarmor, $MarlinDamageType] = 1.0;
$DamageScale[scvarmor, $MarlinDamageType] = 1.0;

$DamageScale[scvarmor, $LCGDamageType] = 1.0;
$DamageScale[scvarmor, $NoDamageType] = 1.0;
$DamageScale[scvarmor, $SlowDamageType] = 1.0;


$DamageScale[larmor, $LCGDamageType] = 1.5;
$DamageScale[larmor, $NoDamageType] = 1.0;
$DamageScale[larmor, $SlowDamageType] = 0.1;
$ItemMax[larmor, LaserChaingun] = 1;
$ItemMax[larmor, SlowGun] = 1;
$ItemMax[larmor, SlowGunAmmo] = 10;
$ItemMax[larmor, Concuss] = 1;
$ItemMax[larmor, ConcussAmmo] = 10;
$ItemMax[larmor, TeleportPack] = 1;

$DamageScale[marmor, $LCGDamageType] = 1.3;
$DamageScale[marmor, $NoDamageType] = 1.0;
$DamageScale[marmor, $SlowDamageType] = 0.1;
$ItemMax[marmor, LaserChaingun] = 1;
$ItemMax[marmor, SlowGun] = 1;
$ItemMax[marmor, SlowGunAmmo] = 15;
$ItemMax[marmor, Concuss] = 1;
$ItemMax[marmor, ConcussAmmo] = 15;

$DamageScale[harmor, $LCGDamageType] = 1.0;
$DamageScale[harmor, $NoDamageType] = 1.0;
$DamageScale[harmor, $SlowDamageType] = 0.1;
$ItemMax[harmor, LaserChaingun] = 1;
$ItemMax[harmor, SlowGun] = 1;
$ItemMax[harmor, SlowGunAmmo] = 20;
$ItemMax[harmor, Concuss] = 1;
$ItemMax[harmor, ConcussAmmo] = 20;

$DamageScale[lfemale, $LCGDamageType] = 1.5;
$DamageScale[lfemale, $NoGunDamageType] = 1.0;
$DamageScale[lfemale, $SlowDamageType] = 0.1;
$ItemMax[lfemale, LaserChaingun] = 1;
$ItemMax[lfemale, SlowGun] = 1;
$ItemMax[lfemale, SlowGunAmmo] = 10;
$ItemMax[lfemale, Concuss] = 1;
$ItemMax[lfemale, ConcussAmmo] = 10;
$ItemMax[lfemale, TeleportPack] = 1;

$DamageScale[mfemale, $LCGDamageType] = 1.3;
$DamageScale[mfemale, $NoDamageType] = 1.0;
$DamageScale[mfemale, $SlowDamageType] = 0.1;
$ItemMax[mfemale, LaserChaingun] = 1;
$ItemMax[mfemale, SlowGun] = 1;
$ItemMax[mfemale, SlowGunAmmo] = 15;
$ItemMax[mfemale, Concuss] = 1;
$ItemMax[mfemale, ConcussAmmo] = 15;

$DamageScale[sarmor, $LCGDamageType] = 3;
$DamageScale[sarmor, $NoDamageType] = 1;
$DamageScale[sarmor, $SlowDamageType] = 5;
$ItemMax[sarmor, SlowGun] = 1;
$ItemMax[sarmor, SlowGunAmmo] = 25;
$ItemMax[sarmor, Concuss] = 1;
$ItemMax[sarmor, ConcussAmmo] = 25;
$ItemMax[sarmor, SpecialistPack] = 1;
$ItemMax[sarmor, Cloaker] = 1;
$ItemMax[sarmor, TeleportPack] = 1;

$DamageScale[aarmor, $LCGDamageType] = 1;
$DamageScale[aarmor, $NoDamageType] = 1;
$DamageScale[aarmor, $SlowDamageType] = 1;
$ItemMax[aarmor, SlowGun] = 1;
$ItemMax[aarmor, SlowGunAmmo] = 25;
$ItemMax[aarmor, Concuss] = 1;
$ItemMax[aarmor, ConcussAmmo] = 25;

$DamageScale[tarmor, $LCGDamageType] = 1;
$DamageScale[tarmor, $NoDamageType] = 1;
$DamageScale[tarmor, $SlowDamageType] = 1;


//More Mod:


$DamageScale[sarmor, $LandingDamageType] = 1.0;
$DamageScale[sarmor, $ImpactDamageType] = 1.0;
$DamageScale[sarmor, $CrushDamageType] = 0.1;
$DamageScale[sarmor, $BulletDamageType] = 8;
$DamageScale[sarmor, $PlasmaDamageType] = 6;
$DamageScale[sarmor, $EnergyDamageType] = 8;
$DamageScale[sarmor, $ExplosionDamageType] = 0.3;
$DamageScale[sarmor, $MissileDamageType] = 0.3;
$DamageScale[sarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[sarmor, $DebrisDamageType] = 1.0;
$DamageScale[sarmor, $LaserDamageType] =3;
$DamageScale[sarmor, $MortarDamageType] = 0.2;
$DamageScale[sarmor, $BlasterDamageType] = 8;
$DamageScale[sarmor, $ElectricityDamageType] = 0.9;
$DamageScale[sarmor, $MineDamageType] = 0.0;

$ItemMax[sarmor, Blaster] = 0;
$ItemMax[sarmor, Chaingun] = 0;
$ItemMax[sarmor, Disclauncher] = 0;
$ItemMax[sarmor, GrenadeLauncher] = 0;
$ItemMax[sarmor, Mortar] = 0;
$ItemMax[sarmor, PlasmaGun] = 0;
$ItemMax[sarmor, LaserRifle] = 0;
$ItemMax[sarmor, EnergyRifle] = 1;
$ItemMax[sarmor, RealTargetingLaser] = 1;
$ItemMax[sarmor, Beacon] = 5;

$ItemMax[sarmor, BulletAmmo] = 0;
$ItemMax[sarmor, PlasmaAmmo] = 0;
$ItemMax[sarmor, DiscAmmo] = 0;
$ItemMax[sarmor, GrenadeAmmo] = 0;
$ItemMax[sarmor, MortarAmmo] = 0;

$ItemMax[sarmor, EnergyPack] = 1;
$ItemMax[sarmor, RepairPack] = 1;
$ItemMax[sarmor, ShieldPack] = 1;
$ItemMax[sarmor, SensorJammerPack] = 1;
$ItemMax[sarmor, MotionSensorPack] = 1;
$ItemMax[sarmor, PulseSensorPack] = 1;
$ItemMax[sarmor, DeployableSensorJammerPack] = 1;
$ItemMax[sarmor, CameraPack] = 1;
$ItemMax[sarmor, TurretPack] = 1;
$ItemMax[sarmor, AmmoPack] = 1;
$ItemMax[sarmor, RepairKit] = 4;
$ItemMax[sarmor, DeployableInvPack] = 1;
$ItemMax[sarmor, DeployableAmmoPack] = 1;

$MaxWeapons[sarmor] = 5;

//------------------------------------------------------------------
// sarmor armor data:
//------------------------------------------------------------------


PlayerData sarmor
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

   maxJetSideForceFactor = 1.5;
   maxJetForwardVelocity = 52;
   minJetEnergy = 0.1;
   jetForce = 260;
   jetEnergyDrain = 0.01;

	maxDamage = 0.5;
   maxForwardSpeed = 18;
   maxBackwardSpeed = 15;
   maxSideSpeed = 15;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 2.5;
	maxEnergy = 100;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.01;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


// Secret Agent Man

$DamageScale[aarmor, $LandingDamageType] = 1.0;
$DamageScale[aarmor, $ImpactDamageType] = 1.0;
$DamageScale[aarmor, $CrushDamageType] = 0.1;
$DamageScale[aarmor, $BulletDamageType] = 1;
$DamageScale[aarmor, $PlasmaDamageType] = 1;
$DamageScale[aarmor, $EnergyDamageType] = 1;
$DamageScale[aarmor, $ExplosionDamageType] = 1;
$DamageScale[aarmor, $MissileDamageType] = 1;
$DamageScale[aarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[aarmor, $DebrisDamageType] = 1.0;
$DamageScale[aarmor, $LaserDamageType] =1;
$DamageScale[aarmor, $MortarDamageType] = 1;
$DamageScale[aarmor, $BlasterDamageType] = 1;
$DamageScale[aarmor, $ElectricityDamageType] = 1;

$ItemMax[aarmor, Blaster] = 1;
$ItemMax[aarmor, Chaingun] = 1;
$ItemMax[aarmor, Disclauncher] = 1;
$ItemMax[aarmor, GrenadeLauncher] = 1;
$ItemMax[aarmor, PlasmaGun] = 1;
$ItemMax[aarmor, EnergyRifle] = 1;

$ItemMax[aarmor, BulletAmmo] = 100;
$ItemMax[aarmor, PlasmaAmmo] = 20;
$ItemMax[aarmor, DiscAmmo] = 15;
$ItemMax[aarmor, GrenadeAmmo] = 10;

$ItemMax[aarmor, RepairKit] = 1;

$MaxWeapons[aarmor] = 3;

//------------------------------------------------------------------
// aarmor armor data:
//------------------------------------------------------------------


PlayerData aarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.7;
   maxJetForwardVelocity = 20;
   minJetEnergy = 1;
   jetForce = 236;
   jetEnergyDrain = 0.8;

	maxDamage = 0.56;
   maxForwardSpeed = 10;
   maxBackwardSpeed = 9;
   maxSideSpeed = 9;
   groundForce = 40 * 9.0;
   mass = 10.0;
   groundTraction = 3.0;
	maxEnergy = 60;
   drag = 1.0;
   density = 1.0;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 75;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
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


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
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
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//----------------------------------------------------------------------------
// Transformer Armor
//----------------------------------------------------------------------------

$DamageScale[tarmor, $LandingDamageType] = 0.3;
$DamageScale[tarmor, $ImpactDamageType] = 0.3;
$DamageScale[tarmor, $CrushDamageType] = 0.3;
$DamageScale[tarmor, $BulletDamageType] = 1.2;
$DamageScale[tarmor, $PlasmaDamageType] = 1.0;
$DamageScale[tarmor, $EnergyDamageType] = 1.3;
$DamageScale[tarmor, $ExplosionDamageType] = 1.0;
$DamageScale[tarmor, $MissileDamageType] = 0.3;
$DamageScale[tarmor, $DebrisDamageType] = 1.2;
$DamageScale[tarmor, $ShrapnelDamageType] = 1.2;
$DamageScale[tarmor, $LaserDamageType] = 1.0;
$DamageScale[tarmor, $MortarDamageType] = 1.3;
$DamageScale[tarmor, $BlasterDamageType] = 1.3;
$DamageScale[tarmor, $ElectricityDamageType] = 1.2;
$DamageScale[tarmor, $MineDamageType] = 1.2;

$ItemMax[tarmor, Blaster] = 1;
$ItemMax[tarmor, LaserRifle] = 1;
$ItemMax[tarmor, EnergyRifle] = 1;
$ItemMax[tarmor, RealTargetingLaser] = 1;

$ItemMax[tarmor, RepairKit] = 2;

$MaxWeapons[tarmor] = 4;

//------------------------------------------------------------------
// Transformer Armor data:
//------------------------------------------------------------------

PlayerData tarmor
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
   jetForce = 320;
   jetEnergyDrain = 1.0;

	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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

$DamageScale[scvarmor, $LandingDamageType] = 1.0;
$DamageScale[scvarmor, $ImpactDamageType] = 1.0;
$DamageScale[scvarmor, $CrushDamageType] = 1.0;
$DamageScale[scvarmor, $BulletDamageType] = 1.0;
$DamageScale[scvarmor, $PlasmaDamageType] = 1.0;
$DamageScale[scvarmor, $EnergyDamageType] = 1.0;
$DamageScale[scvarmor, $ExplosionDamageType] = 1.0;
$DamageScale[scvarmor, $MissileDamageType] = 1.0;
$DamageScale[scvarmor, $DebrisDamageType] = 1.0;
$DamageScale[scvarmor, $ShrapnelDamageType] = 1.0;
$DamageScale[scvarmor, $LaserDamageType] = 1.0;
$DamageScale[scvarmor, $MortarDamageType] = 1.0;
$DamageScale[scvarmor, $BlasterDamageType] = 1.0;
$DamageScale[scvarmor, $ElectricityDamageType] = 1.0;
$DamageScale[scvarmor, $MineDamageType] = 1.0;


$MaxWeapons[scvarmor] = 1;

//------------------------------------------------------------------
// SCV Armor data:
//------------------------------------------------------------------

PlayerData scvarmor
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
   maxJetForwardVelocity = 18;
   minJetEnergy = 1;
   jetForce = 420;
   jetEnergyDrain = 0.8;

	maxDamage = 0.55;
   maxForwardSpeed = 7.5;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	
	maxEnergy = 70;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 120;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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

