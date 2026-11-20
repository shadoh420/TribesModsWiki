for(%x = 0; %x <=5; %x++)
{
	%tag="moo";
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
$DamageScale[%armor, $BulletDamageType] = 1.0;
$DamageScale[%armor, $PlasmaDamageType] = 0.6;
$DamageScale[%armor, $EnergyDamageType] = 1.0;
$DamageScale[%armor, $ExplosionDamageType] = 1.0;
$DamageScale[%armor, $MissileDamageType] = 1.0;
$DamageScale[%armor, $ShrapnelDamageType] = 1.0;
$DamageScale[%armor, $DebrisDamageType] = 1.0;
$DamageScale[%armor, $LaserDamageType] = 1.0;
$DamageScale[%armor, $MortarDamageType] = 1.0;
$DamageScale[%armor, $BlasterDamageType] = 1.0;
$DamageScale[%armor, $ElectricityDamageType] = 1.0;
$DamageScale[%armor, $MineDamageType] = 1.0;
$DamageScale[%armor, $ChargeDamageType] = 1.0;
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
$ItemMax[%armor, BouncingMinePack] = 0;
$ItemMax[%armor, APMinePack] = 1;
$ItemMax[%armor, AAMinePack] = 0;
$ItemMax[%armor, Grenade] = 3;
$ItemMax[%armor, Beacon]  = 3;
$ItemMax[%armor, Knife] = 1;
$ItemMax[%armor, SOCOM] = 1;
$ItemMax[%armor, OICW] = 1;
$ItemMax[%armor, SAW] = 1;
$ItemMax[%armor, MP5] = 0;
$ItemMax[%armor, PSG1] = 0;
$ItemMax[%armor, FiftyCal] = 0;
$ItemMax[%armor, LAW] = 1;
$ItemMax[%armor, AutoShotgun] = 1;
$ItemMax[%armor, Stinger] = 0;
$ItemMax[%armor, Flamethrower] = 1;
$ItemMax[%armor, Howitzer] = 0;
$ItemMax[%armor, Airstrike] = 0;

$ItemMax[%armor, BulletAmmo] = 100;
$ItemMax[%armor, PlasmaAmmo] = 30;
$ItemMax[%armor, DiscAmmo] = 15;
$ItemMax[%armor, GrenadeAmmo] = 10;
$ItemMax[%armor, MortarAmmo] = 10;
$ItemMax[%armor, SOCOMAmmo] = 15;
$ItemMax[%armor, OICWAmmo] = 30;
$ItemMax[%armor, SAWAmmo] = 200;
$ItemMax[%armor, MP5Ammo] = 0;
$ItemMax[%armor, PSG1Ammo] = 0;
$ItemMax[%armor, FiftyCalAmmo] = 0;
$ItemMax[%armor, LAWAmmo] = 1;
$ItemMax[%armor, AutoShotgunAmmo] = 7;
$ItemMax[%armor, FlameAmmo] = 150;
$ItemMax[%armor, StingerAmmo] = 0;
$ItemMax[%armor, HowitzerAmmo] = 0;

$ItemMax[%armor, SOCOMClip] = 1;
$ItemMax[%armor, OICWClip] = 2;
$ItemMax[%armor, SAWClip] = 1;
$ItemMax[%armor, MP5Clip] = 0;
$ItemMax[%armor, PSG1Clip] = 0;
$ItemMax[%armor, FiftyCalClip] = 0;
$ItemMax[%armor, AutoShotgunClip] = 5;
$ItemMax[%armor, StingerClip] = 0;

$ItemMax[%armor, EnergyPack] = 0;
$ItemMax[%armor, RepairPack] = 1;
$ItemMax[%armor, ShieldPack] = 0;
$ItemMax[%armor, SensorJammerPack] = 0;
$ItemMax[%armor, MotionSensorPack] = 0;
$ItemMax[%armor, PulseSensorPack] = 0;
$ItemMax[%armor, RadarPack] = 0;
$ItemMax[%armor, DeployableSensorJammerPack] = 0;
$ItemMax[%armor, DeployableHealthPack] = 0;
$ItemMax[%armor, CameraPack] = 0;
$ItemMax[%armor, TurretPack] = 0;
$ItemMax[%armor, AmmoPackSmall] = 1;
$ItemMax[%armor, AmmoPackHeavy] = 1;
$ItemMax[%armor, AmmoPackExp] = 1;
$ItemMax[%armor, RepairKit] = 1;
$ItemMax[%armor, DeployableInvPack] = 0;
$ItemMax[%armor, DeployableAmmoPack] = 0;
$ItemMax[%armor, TwentyPack] = 0;
$ItemMax[%armor, HowitzerPack] = 0;
$ItemMax[%armor, SAMPack] = 0;
$ItemMax[%armor, Charge] = 0;
$ItemMax[%armor, AirstrikePack] = 0;
$ItemMax[%armor, GrapplePack] = 0;
$ItemMax[%armor, GrappleHook] = 0;
$ItemMax[%armor, ReloaderPack] = 1;
$ItemMax[%armor, Parachute] = 1;
$ItemMax[%armor, FuelPack] = 1;
$ItemMax[%armor, PortGenPack] = 1;
$ItemMax[%armor, AAPack] = 0;
$ItemMax[%armor, MedicPack] = 0;
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

$MaxWeapons[%armor] = 2;
}

PlayerData mooarmor
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

   maxJetSideForceFactor = 10.0;
   maxJetForwardVelocity = 10;
   minJetEnergy = 0.0;
   jetForce = 10;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundtraction = 3.0;
	
	maxEnergy = 100.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 12;
	damageScale = 0.01;

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
   //animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[19] = { "run", none, 1, true, false, true, false, 3 };

   // misc. animations:
   animData[20] = { "sign salut", none, 1, true, false, false, true, 1 }; 
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

   //jetSound = SoundJetLight;

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

   footPrints = { 0, 3 };

   boxWidth = 0.4;
   boxDepth = 0.4;
   boxNormalHeight = 2.25;

   boxNormalHeadPercentage  = 0.90;
   boxNormalTorsoPercentage = 0.20;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};
