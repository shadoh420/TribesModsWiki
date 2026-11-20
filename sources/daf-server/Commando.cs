// This armor is for future use in a "Rabbit" style game.


for(%x = 0; %x <=5; %x++)
{
	%tag="com";
	if(%x<3)
		%sex="armor";
 	else
		%sex="female";
	%num="";
	if(%x==1||%x==4)
		%num="2";
	if(%x==2||%x==5)
		%num="3";
	
	%armor=%tag@%sex@%num;
	
$DamageScale[%armor, $LandingDamageType] = 1.0;
$DamageScale[%armor, $ImpactDamageType] = 1.0;
$DamageScale[%armor, $CrushDamageType] = 1.0;
$DamageScale[%armor, $BulletDamageType] = 1.2;
$DamageScale[%armor, $PlasmaDamageType] = 1.0;
$DamageScale[%armor, $EnergyDamageType] = 1.3;
$DamageScale[%armor, $ExplosionDamageType] = 1.0;
$DamageScale[%armor, $MissileDamageType] = 1.0;
$DamageScale[%armor, $DebrisDamageType] = 1.2;
$DamageScale[%armor, $ShrapnelDamageType] = 1.2;
$DamageScale[%armor, $LaserDamageType] = 1.0;
$DamageScale[%armor, $MortarDamageType] = 1.3;
$DamageScale[%armor, $BlasterDamageType] = 1.3;
$DamageScale[%armor, $ElectricityDamageType] = 1.0;
$DamageScale[%armor, $MineDamageType] = 1.2;
$DamageScale[%armor, $ChargeDamageType] = 1.2;
$DamageScale[%armor, $AirstrikeDamageType] = 1.0;
$DamageScale[%armor, $BleedDamageType] = 1.0;
$DamageScale[%armor, $GrenadeDamageType] = 1.0;
$DamageScale[%armor, $PoisonDamageType] = 1.0;
$DamageScale[%armor, $SmokeDamageType] = 1.0;
$DamageScale[%armor, $StabDamageType] = 1.0;
$DamageScale[%armor, $UCBombDamageType] = 1.0;


$ItemMax[%armor, Blaster] = 1;
$ItemMax[%armor, Chaingun] = 1;
$ItemMax[%armor, Disclauncher] = 1;
$ItemMax[%armor, GrenadeLauncher] = 1;
$ItemMax[%armor, Mortar] = 0;
$ItemMax[%armor, PlasmaGun] = 1;
$ItemMax[%armor, LaserRifle] = 1;
$ItemMax[%armor, EnergyRifle] = 1;
$ItemMax[%armor, TargetingLaser] = 1;
$ItemMax[%armor, BouncingMinePack] = 1;
$ItemMax[%armor, APMinePack] = 1;
$ItemMax[%armor, AAMinePack] = 1;
$ItemMax[%armor, Grenade] = 5;
$ItemMax[%armor, Beacon]  = 3;
$ItemMax[%armor, Knife] = 1;
$ItemMax[%armor, SOCOM] = 1;
$ItemMax[%armor, OICW] = 1;
$ItemMax[%armor, SAW] = 1;
$ItemMax[%armor, MP5] = 1;
$ItemMax[%armor, PSG1] = 1;
$ItemMax[%armor, FiftyCal] = 1;
$ItemMax[%armor, LAW] = 1;
$ItemMax[%armor, AutoShotgun] = 1;
$ItemMax[%armor, Howitzer] = 1;
$ItemMax[%armor, Airstrike] = 1;
$ItemMax[%armor, Stinger] = 1;
$ItemMax[%armor, Flamethrower] = 1;

$ItemMax[%armor, BulletAmmo] = 100;
$ItemMax[%armor, PlasmaAmmo] = 30;
$ItemMax[%armor, DiscAmmo] = 15;
$ItemMax[%armor, GrenadeAmmo] = 10;
$ItemMax[%armor, MortarAmmo] = 10;
$ItemMax[%armor, SOCOMAmmo] = 15;
$ItemMax[%armor, OICWAmmo] = 30;
$ItemMax[%armor, SAWAmmo] = 200;
$ItemMax[%armor, MP5Ammo] = 30;
$ItemMax[%armor, PSG1Ammo] = 5;
$ItemMax[%armor, FiftyCalAmmo] = 5;
$ItemMax[%armor, LAWAmmo] = 1;
$ItemMax[%armor, AutoShotgunAmmo] = 7;
$ItemMax[%armor, HowitzerAmmo] = 0;
$ItemMax[%armor, StingerAmmo] = 1;
$ItemMax[%armor, FlameAmmo] = 100;

$ItemMax[%armor, SOCOMClip] = 10;
$ItemMax[%armor, OICWClip] = 10;
$ItemMax[%armor, SAWClip] = 10;
$ItemMax[%armor, MP5Clip] = 10;
$ItemMax[%armor, PSG1Clip] = 10;
$ItemMax[%armor, FiftyCalClip] = 10;
$ItemMax[%armor, AutoShotgunClip] = 10;
$ItemMax[%armor, StingerClip] = 10;

$ItemMax[%armor, EnergyPack] = 0;
$ItemMax[%armor, RepairPack] = 0;
$ItemMax[%armor, ShieldPack] = 0;
$ItemMax[%armor, SensorJammerPack] = 0;
$ItemMax[%armor, MotionSensorPack] = 0;
$ItemMax[%armor, PulseSensorPack] = 0;
$ItemMax[%armor, RadarPack] = 0;
$ItemMax[%armor, DeployableSensorJammerPack] = 0;
$ItemMax[%armor, DeployableHealthPack] = 0;
$ItemMax[%armor, CameraPack] = 1;
$ItemMax[%armor, TurretPack] = 0;
$ItemMax[%armor, AmmoPackSmall] = 1;
$ItemMax[%armor, AmmoPackHeavy] = 1;
$ItemMax[%armor, AmmoPackExp] = 1;
$ItemMax[%armor, RepairKit] = 5;
$ItemMax[%armor, DeployableInvPack] = 0;
$ItemMax[%armor, DeployableAmmoPack] = 0;
$ItemMax[%armor, TwentyPack] = 0;
$ItemMax[%armor, HowitzerPack] = 0;
$ItemMax[%armor, SAMPack] = 0;
$ItemMax[%armor, Charge] = 10;
$ItemMax[%armor, AirstrikePack] = 1;
$ItemMax[%armor, GrapplePack] = 1;
$ItemMax[%armor, GrappleHook] = 1;
$ItemMax[%armor, ReloaderPack] = 1;
$ItemMax[%armor, Parachute] = 1;
$ItemMax[%armor, FuelPack] = 1;
$ItemMax[%armor, PortGenPack] = 0;
$ItemMax[%armor, AAPack] = 0;
$ItemMax[%armor, MedicPack] = 1;
$ItemMax[%armor, SandBagpack] = 0;

//Modules
$ItemMax[%armor, SideWinderModule] = 0;
$ItemMax[%armor, PhoenixModule] = 0;
$ItemMax[%armor, HellFireModule] = 0;
$ItemMax[%armor, HydraModule] = 0;
$ItemMax[%armor, GUVGunPodModule] = 0;
$ItemMax[%armor, FiftyCalModule] = 0;
$ItemMax[%armor, UPKGunPodModule] = 0;
$ItemMax[%armor, MaverickModule] = 0;
$ItemMax[%armor, HARMModule] = 0;
$ItemMax[%armor, Mk82Module] = 0;
$ItemMax[%armor, Mk84Module] = 0;
$ItemMax[%armor, Mk82PackageModule] = 0;
$ItemMax[%armor, Mk84PackageModule] = 0;
$ItemMax[%armor, APClusterModule] = 0;
$ItemMax[%armor, MineClusterModule] = 0;
$ItemMax[%armor, BombletClusterModule] = 0;
$ItemMax[%armor, BunkerBusterModule] = 0;
$ItemMax[%armor, TankSmokeModule] = 0;
$ItemMax[%armor, TankNerveGasModule] = 0;
$ItemMax[%armor, IncendiaryNapamModule] = 0;
$ItemMax[%armor, NuclearModule] = 0;
$ItemMax[%armor, EMCModule] = 0;
$ItemMax[%armor, DaisyCutterModule] = 0;
$ItemMax[%armor, SupplyCrateModule] = 0;

$MaxWeapons[%armor] = 3;

}

PlayerData comarmor
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

PlayerData comarmor2
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 5;
   maxSideSpeed = 5;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

   jumpImpulse = 0;
   jumpSurfaceMinDot = 1.0;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

PlayerData comarmor3
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 1;
   maxBackwardSpeed = 1;
   maxSideSpeed = 1;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

   jumpImpulse = 0;
   jumpSurfaceMinDot = 1.0;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//FEMALES
PlayerData comfemale
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

PlayerData comfemale2
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 5;
   maxSideSpeed = 5;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

   jumpImpulse = 0;
   jumpSurfaceMinDot = 1.0;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

PlayerData comfemale3
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

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0.0;
   minJetEnergy = 1.0;
   jetForce = 0;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 1;
   maxBackwardSpeed = 1;
   maxSideSpeed = 1;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundtraction = 3.0;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 12;
	damageScale = 0.01;

   jumpImpulse = 0;
   jumpSurfaceMinDot = 1.0;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
   animData[19] = { "run", none, 1, true, false, true, false, 3 };

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

   //jetSound = SoundJetLight;
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

   boxWidth = 0.35;
   boxDepth = 0.35;
   boxNormalHeight = 2.05;
   boxCrouchHeight = 1.5;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.25;
   boxCrouchHeadPercentage  = 0.80;
   boxCrouchTorsoPercentage = 0.30;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function GoCommando(%clientId, %pos, %level)
{
	// find out if we can spawn here.
	%pos = getWord(%pos,0) @ " " @ getWord(%pos,1);

	%mask = ~0;
	%los = getLOSInfo(vector::Add(%pos@ " 0",%pos@ " 10000"),%pos@ " -10000",%mask);
	if(!%los)
	{
		echo("Ground not found");
		return;
	}
	%pos = vector::add(%lospos,"0 0 1000");

	   %pl = spawnPlayer("larmor", %pos, "0 0 0");

           GameBase::setTeam(%pl, -1);
	   Client::setOwnedObject(%clientId, %pl);
	   Client::setControlObject(%clientId, %pl);
	   %clientId.guilock = false;


	%clientId.spawn= "";
	$Reloading[%clientId] = 0;
	%clientid.inVehicle = false;
	%clientId.observerMode = "";

	Player::setSensorSupression(%clientid,3);
//	GameBase::startFadeOut(%clientid);

	player::Setarmor(%clientId,"comArmor");

	if(%level == "")
		%level = "standard";
	%setUp = %level@"::Commando("@%clientId@");";	
	eval(%setup);


        player::Setitemcount(%clientId,parachute,1);
	player::mountitem(%clientId,parachute,$BackPackslot);

	$Veteran::Kills[%clientId,knife] = 20;
	$Veteran::Kills[%clientId,Pistol] = 20;
	$Veteran::Kills[%clientId,M16] = 20;
	$Veteran::Kills[%clientId,SAW] = 20;
	$Veteran::Kills[%clientId,psg1] = 20;
	$Veteran::Kills[%clientId,mp5] = 20;
	$Veteran::Kills[%clientId,M16] = 20;
	$Veteran::Kills[%clientId,FiftyCal] = 20;
	$Veteran::Kills[%clientId,AutoShotgun] = 20;
	$Veteran::Kills[%clientId,LAW] = 20;
	$Veteran::Kills[%clientId,Flamethrower] = 20;

}

function light::Commando(%clientId)
{
	player::Setitemcount(%clientId,CommandoArmor,1);

	player::Setitemcount(%clientId,knife,1);

	player::Setitemcount(%clientId,repairkit,10);

}

function standard::Commando(%clientId)
{
	light::Commando(%clientId);

	player::Setitemcount(%clientId,grenade,10);

	player::Setitemcount(%clientId,mp5,1);
	player::Setitemcount(%clientId,mp5Clip,10);

	player::Setitemcount(%clientId,psg1,1);
	player::Setitemcount(%clientId,psg1Clip,10);

	player::Setitemcount(%clientId,Stinger,1);
	player::Setitemcount(%clientId,StingerClip,10);

        player::Setitemcount(%clientId,charge,20);

}

function medic::Commando(%clientId)
{
	light::Commando(%clientId);

	player::Setitemcount(%clientId,grenade,10);

	player::Setitemcount(%clientId,pistol,1);
	player::Setitemcount(%clientId,pistolClip,10);

	player::Setitemcount(%clientId,mp5,1);
	player::Setitemcount(%clientId,mp5Clip,10);

	player::Setitemcount(%clientId,Stinger,1);
	player::Setitemcount(%clientId,StingerClip,10);

	$Veteran::Kills[%clientId,Medic] = 20;
}

function heavy::Commando(%clientId)
{
	standard::Commando(%clientId);

	player::Setitemcount(%clientId,M16,1);
	player::Setitemcount(%clientId,M16Clip,10);

	player::Setitemcount(%clientId,SAW,1);
	player::Setitemcount(%clientId,SAWClip,10);

	player::Setitemcount(%clientId,FiftyCal,1);
	player::Setitemcount(%clientId,FiftyCalClip,10);

	player::Setitemcount(%clientId,LAW,1);
	player::Setitemcount(%clientId,LAWAmmo,1);

	player::Setitemcount(%clientId,AutoShotgun,1);
	player::Setitemcount(%clientId,AutoShotgunClip,10);

	player::Setitemcount(%clientId,AirstrikePack,10);
	player::Setitemcount(%clientId,MedicPack,1);

}


