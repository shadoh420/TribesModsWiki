

SoundData SoundMPlayerDeath
{
   wavFileName = "death_male.wav";
   profile = Profile3dMedium;
};

SoundData SoundFPlayerDeath
{
   wavFileName = "death_female.wav";
   profile = Profile3dMedium;
};

SoundData SoundLandOnGround
{
   wavFileName = "ground_hit.wav";
   profile = Profile3dNear;
};

//----------------------------------------------------------------------------
// Light Armor
//----------------------------------------------------------------------------

$DamageScale[larmor, $LandingDamageType] = 1.0;
$DamageScale[larmor, $ImpactDamageType] = 1.0;
$DamageScale[larmor, $CrushDamageType] = 1.0;
$DamageScale[larmor, $EnergyDamageType] = 1.3;
$DamageScale[larmor, $DebrisDamageType] = 1.2;
$DamageScale[larmor, $ElectricityDamageType] = 1.0;
$DamageScale[larmor, $MineDamageType] = 1.2;
$DamageScale[larmor, $EMPDamageType] = 1.0;
$DamageScale[larmor, $MissileDamageType] = 1.0;
$DamageScale[larmor, $beamofpainDamageType] = 1.0;
$DamageScale[larmor, $BulletDamageType] = 1.2;
$DamageScale[larmor, $DiscDamageType] = 1.0;
$DamageScale[larmor, $AssaultDamageType] = 1.0;
$DamageScale[larmor, $TranqDamageType] = 1.0;
$DamageScale[larmor, $TorqueDamageType] = 1.0;
$DamageScale[larmor, $LaserDamageType] = 1.0; 
$DamageScale[larmor, $RLaserDamageType] = 1.0;
$DamageScale[larmor, $NapalmDamageType] = 0.01;
$DamageScale[larmor, $FlameDamageType] = 0.01;
$DamageScale[larmor, $FBWDamageType] = 1.0;
$DamageScale[larmor, $PlasmaDamageType] = 1.0;
$DamageScale[larmor, $FusionDamageType] = 1.0;
$DamageScale[larmor, $shredderDamageType] = 1.0;

$ItemMax[larmor, Blaster] = 1;
$ItemMax[larmor, Chaingun] = 1;
$ItemMax[larmor, Disclauncher] = 1;
$ItemMax[larmor, GrenadeLauncher] = 1;
$ItemMax[larmor, Mortar] = 1;
$ItemMax[larmor, PlasmaGun] = 1;
$ItemMax[larmor, LaserRifle] = 1;
$ItemMax[larmor, EnergyRifle] = 1;
$ItemMax[larmor, TargetingLaser] = 0;
$ItemMax[larmor, MineAmmo] = 1;
$ItemMax[larmor, Grenade] = 1;
$ItemMax[larmor, Beacon]  = 1;

//--VX



$MaxWeapons[larmor] = 7;


//----------------------------------------------------------------------------
// light Female Armor
//----------------------------------------------------------------------------
$DamageScale[lfemale, $LandingDamageType] = 1.0;
$DamageScale[lfemale, $ImpactDamageType] = 1.0;	
$DamageScale[lfemale, $CrushDamageType] = 1.0;	
$DamageScale[lfemale, $BulletDamageType] = 1.2;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;
$DamageScale[lfemale, $EnergyDamageType] = 1.3;
$DamageScale[lfemale, $DiscDamageType] = 1.0;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[lfemale, $DebrisDamageType] = 1.2;
$DamageScale[lfemale, $ElectricityDamageType] = 1.0;
$DamageScale[lfemale, $MineDamageType] = 1.2;
$DamageScale[lfemale, $EMPDamageType] = 1.0;
$DamageScale[lfemale, $SmokeDamageType] = 1.0;
$DamageScale[lfemale, $MiniELFDamageType] = 1.0;
$DamageScale[lfemale, $beamofpainDamageType] = 1.0;
$DamageScale[lfemale, $FlameDamageType] = 1.0;
$DamageScale[lfemale, $NapalmDamageType] = 0.01;
$DamageScale[lfemale, $TorqueDamageType] = 1.0;
$DamageScale[lfemale, $LaserDamageType] = 1.0; 
$DamageScale[lfemale, $RlaserDamageType] = 1.0;
$DamageScale[lfemale, $shredderDamageType] = 1.0;
$DamageScale[lfemale, $PlasmaDamageType] = 1.0;	
$DamageScale[lfemale, $FusionDamageType] = 1.0;
$DamageScale[lfemale, $FBWDamageType] = 1.0;


$ItemMax[lfemale, Blaster] = 1;
$ItemMax[lfemale, Chaingun] = 1;
$ItemMax[lfemale, Disclauncher] = 1;
$ItemMax[lfemale, GrenadeLauncher] = 1;
$ItemMax[lfemale, Mortar] = 1;
$ItemMax[lfemale, PlasmaGun] = 1;
$ItemMax[lfemale, LaserRifle] = 1;
$ItemMax[lfemale, EnergyRifle] = 1;
$ItemMax[lfemale, MineAmmo] = 1;
$ItemMax[lfemale, Grenade] = 1;
$ItemMax[lfemale, Beacon] = 1;

$MaxWeapons[lfemale] = 7;

$ItemMax[larmor, flamer] = 1;
$ItemMax[lfemale, flamer] = 1;
$ItemMax[larmor, Fusion] = 1;
$ItemMax[lfemale, Fusion] = 1;
$ItemMax[larmor, Lasercan] = 1;
$ItemMax[lfemale, Lasercan] = 1;
$ItemMax[larmor, BeamOfPain] = 1;
$ItemMax[lfemale, BeamOfPain] = 1;
$ItemMax[larmor, LiLPOOmki] = 1;
$ItemMax[lfemale, LiLPOOmki] = 1;
$ItemMax[larmor, LiLPOOmkii] = 1;
$ItemMax[lfemale, LiLPOOmkii] = 1;
$ItemMax[larmor, Minigun] = 1;
$ItemMax[lfemale, Minigun] = 1;
$ItemMax[larmor, shredder] = 1;				
$ItemMax[lfemale, shredder] = 1;				
$ItemMax[larmor, shredderAmmo] = 1;				
$ItemMax[lfemale, shredderAmmo] = 1;
$ItemMax[larmor, RocketLauncher] = 1;
$ItemMax[lfemale, RocketLauncher] = 1;
$ItemMax[larmor, FBWRocketLauncher] = 1;				
$ItemMax[lfemale, FBWRocketLauncher] = 1;	
$ItemMax[larmor, FBWRocketAmmo] = 3;				
$ItemMax[lfemale, FBWRocketAmmo] = 3;



//------------------------------------------------------------------
// light armor data:
//------------------------------------------------------------------

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
//------------------------------------------------------------------
// 2004 Armor data:
//------------------------------------------------------------------

PlayerData larmor
{
   className = "Armor";
   shapeFile = "carmor";
   flameShapeName = "thrust";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
  // validateShape = true;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 5;
   maxJetForwardVelocity = 50;
   minJetEnergy = 0.5;
   jetForce = 600;
   jetEnergyDrain = 0.5;

	maxDamage = 0.66;
   maxForwardSpeed = 20;
   maxBackwardSpeed = 20;
   maxSideSpeed = 15;
   groundForce = 35 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 250;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 40;
	damageScale = 0.005;

   jumpImpulse = 90;
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
   animData[25] = { "crouch die", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundMPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundMPlayerDeath, 1, false, false, false, false, 4 };

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



//------------------------------------------------------------------
// 2004 female data:
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "cfemale";
   flameShapeName = "thrust";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
  // validateShape = true;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

  canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 5;
   maxJetForwardVelocity = 50;
   minJetEnergy = 0.5;
   jetForce = 600;
   jetEnergyDrain = 0.5;

	maxDamage = 0.66;
   maxForwardSpeed = 20;
   maxBackwardSpeed = 20;
   maxSideSpeed = 15;
   groundForce = 35 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 250;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 40;
	damageScale = 0.005;

   jumpImpulse = 90;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

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
   animData[25] = { "crouch die", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundFPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundFPlayerDeath, 1, false, false, false, false, 4 };

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