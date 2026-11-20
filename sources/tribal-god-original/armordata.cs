//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin8420@adelphia.net
// Aim: Dustin8420
//------------------------------------|
//
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

function DamageScale(%DamageType, %lm, %lf, %mm, %mf, %h)
{
	$DamageScale[larmor , %DamageType] = %lm;
	$DamageScale[lfemale, %DamageType] = %lf;
	$DamageScale[marmor , %DamageType] = %mm;
	$DamageScale[mfemale, %DamageType] = %mf;
	$DamageScale[harmor , %DamageType] = %h;
}

//========== Initialize All Damage Scales ==========//
DamageScale($PlasmaCannonDamageType, 1.0, 1.0, 1.5, 1.5, 2.0);
DamageScale($ElectricityDamageType, 1.0, 1.0, 0.7, 0.7, 1.0);
DamageScale($LiLPOOmkiiDamageType, 1.5, 1.5, 1.0, 1.0, 0.9);
DamageScale($beamofpainDamageType, 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($ExplosionDamageType, 1.0, 1.0, 0.7, 0.7, 0.6);
DamageScale($LiLRocketDamageType, 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($ShrapnelDamageType, 0.7, 0.7, 0.5, 0.5, 0.2);
DamageScale($ChainGunDamageType, 1.0, 1.0, 1.5, 1.5, 2.0);
DamageScale($LandingDamageType, 0.1, 0.1, 0.3, 0.3, 0.7);
DamageScale($ImpactDamageType , 0.5, 0.5, 0.7, 0.7, 1.0);
DamageScale($CrushDamageType  , 0.7, 0.7, 0.7, 0.7, 1.0);
DamageScale($BulletDamageType , 0.8, 0.8, 0.7, 0.7, 0.6);
DamageScale($PlasmaDamageType , 0.95, 0.95, 0.6, 0.6, 0.4);
DamageScale($EnergyDamageType , 1.0, 1.0, 0.7, 0.7, 0.5);
DamageScale($MissileDamageType, 1.0, 1.0, 0.7, 0.7, 0.6);
DamageScale($DebrisDamageType , 1.0, 1.0, 0.7, 0.7, 0.8);
DamageScale($LaserDamageType  , 1.0, 1.0, 0.7, 0.7, 0.6);
DamageScale($MortarDamageType , 1.0, 1.0, 0.7, 0.7, 0.6);
DamageScale($BlasterDamageType, 1.0, 1.0, 0.7, 0.7, 0.6);
DamageScale($MineDamageType   , 0.9, 0.9, 0.7, 0.7, 0.8);
DamageScale($EMPDamageType    , 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($SmokeDamageType  , 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($MiniELFDamageType, 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($SniperDamageType , 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($FlashDamageType  , 1.0, 1.0, 1.0, 1.0, 1.0);
DamageScale($FlameDamageType  , 0.9, 0.9, 1.0, 1.0, 1.1);
//==================================================//


$MaxWeapons[harmor] = 10;



//----------------------------------------------------------------------------
// Medium Female Armor
//----------------------------------------------------------------------------

$ItemMax[harmor, TurretPack] = 1;
 
$ItemMax[marmor, RailTurret] = 1;// 0; 
$ItemMax[harmor, RailTurret] = 1; 
$ItemMax[mfemale, RailTurret] = 1;// 0;

$ItemMax[marmor, ChaingunTurretPack] = 1;// 0;
$ItemMax[mfemale, ChaingunTurretPack] = 1;

$ItemMax[marmor, TurretPack] = 1;// 0;
$ItemMax[harmor, TurretPack] = 1;// 0;
$ItemMax[mfemale, TurretPack] = 1;// 0;

$ItemMax[marmor, SeekerPack] = 1;// 0;
$ItemMax[harmor, SeekerPack] = 1;// 0;
$ItemMax[mfemale, SeekerPack] = 1;// 0;

$ItemMax[marmor, ArbitorBoxPack] = 1;// 0;
$ItemMax[harmor, ArbitorBoxPack] = 1;// 0;
$ItemMax[mfemale, ArbitorBoxPack] = 1;// 0;

//------------------------------------------------------------------
// Heavy Armor data:
//------------------------------------------------------------------

PlayerData harmor
{
	className = "Armor";
	shapeFile = "harmor";
	flameShapeName = "hflame";
	shieldShapeName = "shield";
	damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
	shadowDetailMask = 1;
	validateShape = false;
	visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
	maxJetSideForceFactor = 0.8;
	maxJetForwardVelocity = 13;
	minJetEnergy = 1;
	jetForce = 436;
	jetEnergyDrain = 0.1;
	maxDamage = 2.5;
	maxForwardSpeed = 13;
	maxBackwardSpeed = 13;
	maxSideSpeed = 12;
	groundForce = 40 * 9;
	groundTraction = 4;
	mass = 10;
	maxEnergy = 100;
	drag = 1.0;
	density = 2.5;
	canCrouch = false;
	minDamageSpeed = 25;
	damageScale = 0.006;
	jumpImpulse = 150;
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

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};