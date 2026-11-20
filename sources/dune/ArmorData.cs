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


DamageSkinData armorDamageSkinsTest
{
   bmpName[0] = "shinny_tech";
   bmpName[1] = "shinny_tech";
   bmpName[2] = "shinny_tech";
   bmpName[3] = "shinny_tech";
   bmpName[4] = "shinny_tech";
   bmpName[5] = "shinny_tech";
   bmpName[6] = "shinny_tech";
   bmpName[7] = "shinny_tech";
   bmpName[8] = "shinny_tech";
   bmpName[9] = "shinny_tech";
};

//----------------------------------//
// ARMOR THROW STRENGTH CODE BY ICE //
//----------------------------------//

//- 1.0 is normal strength and the default strength
$ThrowStrength[sarmor] = 1.0;				$ThrowStrength[sfemale] = 1.0;
$ThrowStrength[tarmor] = 1.0;				$ThrowStrength[tfemale] = 1.0;
$ThrowStrength[farmor] = 1.3;				$ThrowStrength[ffemale] = 1.3;
$ThrowStrength[ffarmor] = 1.5;				$ThrowStrength[fffemale] = 1.5;
$ThrowStrength[ssarmor] = 1.3;				$ThrowStrength[ssfemale] = 1.3;
$ThrowStrength[barmor] = 1.5;				$ThrowStrength[bfemale] = 1.5;
$ThrowStrength[bbarmor] = 1.5;				$ThrowStrength[bbfemale] = 1.5;
$ThrowStrength[fdarmor] = 1.5;				$ThrowStrength[fdfemale] = 1.5;

$ThrowStrength[sarmor2] = 1.0;				$ThrowStrength[sfemale2] = 1.0;
$ThrowStrength[ssarmor2] = 1.3;				$ThrowStrength[ssfemale2] = 1.3;
$ThrowStrength[barmor2] = 1.5;				$ThrowStrength[bfemale2] = 1.5;
$ThrowStrength[bbarmor2] = 1.5;				$ThrowStrength[bbfemale2] = 1.5;


$WeapThrowCTH[sarmor] = 50;				$WeapThrowCTH[sfemale] = 50;
$WeapThrowCTH[tarmor] = 50;				$WeapThrowCTH[tfemale] = 50;
$WeapThrowCTH[farmor] = 75;				$WeapThrowCTH[ffemale] = 75;
$WeapThrowCTH[ffarmor] = 90;				$WeapThrowCTH[fffemale] = 90;
$WeapThrowCTH[ssarmor] = 75;				$WeapThrowCTH[ssfemale] = 75;
$WeapThrowCTH[barmor] = 90;				$WeapThrowCTH[bfemale] = 90;
$WeapThrowCTH[bbarmor] = 90;				$WeapThrowCTH[bbfemale] = 90;
$WeapThrowCTH[fdarmor] = 90;				$WeapThrowCTH[fdfemale] = 90;

$WeapThrowCTH[sarmor2] = 50;				$WeapThrowCTH[sfemale2] = 50;
$WeapThrowCTH[ssarmor2] = 75;				$WeapThrowCTH[ssfemale2] = 75;
$WeapThrowCTH[barmor2] = 90;				$WeapThrowCTH[bfemale2] = 90;
$WeapThrowCTH[bbarmor2] = 90;				$WeapThrowCTH[bbfemale2] = 90;


//------------------------------------------------------------------
//******************************************************************
//***************************NEW ARMORS*****************************
//******************************************************************

//----------------------------------------------------------------------------
// Soldier Armor
//----------------------------------------------------------------------------

$DamageScale[sarmor, $LandingDamageType] = 1.0;		$DamageScale[sfemale, $LandingDamageType] = 1.0;		
$DamageScale[sarmor, $ImpactDamageType] = 1.0;		$DamageScale[sfemale, $ImpactDamageType] = 1.0;		
$DamageScale[sarmor, $CrushDamageType] = 1.0;		$DamageScale[sfemale, $CrushDamageType] = 1.0;		
$DamageScale[sarmor, $BulletDamageType] = 1.2;		$DamageScale[sfemale, $BulletDamageType] = 1.2;		
$DamageScale[sarmor, $PlasmaDamageType] = 1.2;		$DamageScale[sfemale, $PlasmaDamageType] = 1.2;		
$DamageScale[sarmor, $EnergyDamageType] = 1.3;		$DamageScale[sfemale, $EnergyDamageType] = 1.3;		
$DamageScale[sarmor, $ExplosionDamageType] = 1.0;	$DamageScale[sfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[sarmor, $MissileDamageType] = 1.0;		$DamageScale[sfemale, $MissileDamageType] = 1.0;		
$DamageScale[sarmor, $DebrisDamageType] = 1.2;		$DamageScale[sfemale, $DebrisDamageType] = 1.2;		
$DamageScale[sarmor, $ShrapnelDamageType] = 1.2;	$DamageScale[sfemale, $ShrapnelDamageType] = 1.2;		
$DamageScale[sarmor, $LaserDamageType] = 1.2;		$DamageScale[sfemale, $LaserDamageType] = 1.2;		
$DamageScale[sarmor, $MortarDamageType] = 1.3;		$DamageScale[sfemale, $MortarDamageType] = 1.3;		
$DamageScale[sarmor, $BlasterDamageType] = 1.3;		$DamageScale[sfemale, $BlasterDamageType] = 1.3;		
$DamageScale[sarmor, $ElectricityDamageType] = 1.0;	$DamageScale[sfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[sarmor, $MineDamageType] = 1.2;		$DamageScale[sfemale, $MineDamageType] = 1.2;		
$DamageScale[sarmor, $StabDamageType] = 1.0;		$DamageScale[sfemale, $StabDamageType] = 1.0;		
$DamageScale[sarmor, $PoisonDamageType] = 1.0;		$DamageScale[sfemale, $PoisonDamageType] = 1.0;		
$DamageScale[sarmor, $StunnerDamageType] = 1.0;		$DamageScale[sfemale, $StunnerDamageType] = 1.0;		
$DamageScale[sarmor, $NukeDamageType] = 1.0;		$DamageScale[sfemale, $NukeDamageType] = 1.0;		
$DamageScale[sarmor, $Poison2DamageType] = 1.0;		$DamageScale[sfemale, $Poison2DamageType] = 1.0;		
$DamageScale[sarmor, $WormDamageType] = 1.0;		$DamageScale[sfemale, $WormDamageType] = 1.0;		
$DamageScale[sarmor, $CutterayDamageType] = 1.2;	$DamageScale[sfemale, $CutterayDamageType] = 1.2;		
$DamageScale[sarmor, $SmallLasDamageType] = 1.2;	$DamageScale[sfemale, $SmallLasDamageType] = 1.2;		
$DamageScale[sarmor, $RifleLasDamageType] = 1.2;	$DamageScale[sfemale, $RifleLasDamageType] = 1.2;		
$DamageScale[sarmor, $HeavyLasDamageType] = 1.2;	$DamageScale[sfemale, $HeavyLasDamageType] = 1.2;		
$DamageScale[sarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[sfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[sarmor, $LargeBulletDamageType] = 1.2;	$DamageScale[sfemale, $LargeBulletDamageType] = 1.2;		
$DamageScale[sarmor, $ThrownWeaponDamageType] = 1.0;	$DamageScale[sfemale, $ThrownWeaponDamageType] = 1.0;		
$DamageScale[sarmor, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[sfemale, $ThrownPoisonWeaponDamageType] = 1.0;		
$DamageScale[sarmor, $AssassinDamageType] = 1.0;	$DamageScale[sfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[sarmor, Blaster] = 0;				$ItemMax[sfemale, Blaster] = 0;				
$ItemMax[sarmor, Chaingun] = 0;				$ItemMax[sfemale, Chaingun] = 0;				
$ItemMax[sarmor, Disclauncher] = 0;			$ItemMax[sfemale, Disclauncher] = 0;			
$ItemMax[sarmor, GrenadeLauncher] = 0;			$ItemMax[sfemale, GrenadeLauncher] = 0;			
$ItemMax[sarmor, Mortar] = 0;				$ItemMax[sfemale, Mortar] = 0;				
$ItemMax[sarmor, PlasmaGun] = 0;			$ItemMax[sfemale, PlasmaGun] = 0;			
$ItemMax[sarmor, LaserRifle] = 0;			$ItemMax[sfemale, LaserRifle] = 0;			
$ItemMax[sarmor, EnergyRifle] = 0;			$ItemMax[sfemale, EnergyRifle] = 0;			
$ItemMax[sarmor, TargetingLaser] = 0;			$ItemMax[sfemale, TargetingLaser] = 0;			
$ItemMax[sarmor, MineAmmo] = 0;				$ItemMax[sfemale, MineAmmo] = 0;				
$ItemMax[sarmor, Grenade] = 0;				$ItemMax[sfemale, Grenade] = 0;				

//Blades
$ItemMax[sarmor, Knife]  = 1;				$ItemMax[sfemale, Knife]  = 1;				
$ItemMax[sarmor, Knife2]  = 1;				$ItemMax[sfemale, Knife2]  = 1;				
$ItemMax[sarmor, SlipTip]  = 1;				$ItemMax[sfemale, SlipTip]  = 1;			
$ItemMax[sarmor, Crysknife]  = 0;			$ItemMax[sfemale, Crysknife]  = 0;			
$ItemMax[sarmor, Kindjal]  = 0;				$ItemMax[sfemale, Kindjal]  = 0;				
$ItemMax[sarmor, Saber]  = 0;				$ItemMax[sfemale, Saber]  = 0;				

//Projectiles
$ItemMax[sarmor, Pistol]  = 1;				$ItemMax[sfemale, Pistol]  = 1;				
$ItemMax[sarmor, Maula]  = 1;				$ItemMax[sfemale, Maula]  = 1;				
$ItemMax[sarmor, Stunner]  = 1;				$ItemMax[sfemale, Stunner]  = 1;				
$ItemMax[sarmor, Rifle]  = 1;				$ItemMax[sfemale, Rifle]  = 1;				
$ItemMax[sarmor, Rifle2]  = 1;				$ItemMax[sfemale, Rifle2]  = 1;				
$ItemMax[sarmor, MGun]  = 0;				$ItemMax[sfemale, MGun]  = 0;
$ItemMax[sarmor, SniperRifle]  = 0;			$ItemMax[sfemale, SniperRifle]  = 0;								
$ItemMax[sarmor, RLauncher]  = 1;			$ItemMax[sfemale, RLauncher]  = 1;			
$ItemMax[sarmor, Flamethrower]  = 0;			$ItemMax[sfemale, Flamethrower]  = 0;			
$ItemMax[sarmor, Piller]  = 1;				$ItemMax[sfemale, Piller]  = 1;				

//Lasguns
$ItemMax[sarmor, Cutteray]  = 1;			$ItemMax[sfemale, Cutteray]  = 1;			
$ItemMax[sarmor, SmallLas]  = 1;			$ItemMax[sfemale, SmallLas]  = 1;			
$ItemMax[sarmor, RifleLas]  = 1;			$ItemMax[sfemale, RifleLas]  = 1;			
$ItemMax[sarmor, HeavyLas]  = 1;			$ItemMax[sfemale, HeavyLas]  = 1;			

//Items...
$ItemMax[sarmor, RepairKit] = 1;			$ItemMax[sfemale, RepairKit] = 1;			
$ItemMax[sarmor, Beacon]  = 3;				$ItemMax[sfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[sarmor, BulletAmmo] = 0;			$ItemMax[sfemale, BulletAmmo] = 0;			
$ItemMax[sarmor, PlasmaAmmo] = 0;			$ItemMax[sfemale, PlasmaAmmo] = 0;			
$ItemMax[sarmor, DiscAmmo] = 0;				$ItemMax[sfemale, DiscAmmo] = 0;				
$ItemMax[sarmor, GrenadeAmmo] = 0;			$ItemMax[sfemale, GrenadeAmmo] = 0;			
$ItemMax[sarmor, MortarAmmo] = 0;			$ItemMax[sfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[sarmor, PistolClip] = 3;			$ItemMax[sfemale, PistolClip] = 3;			
$ItemMax[sarmor, MaulaClip] = 2;			$ItemMax[sfemale, MaulaClip] = 2;			
$ItemMax[sarmor, StunnerClip] = 2;			$ItemMax[sfemale, StunnerClip] = 2;			
$ItemMax[sarmor, RifleClip] = 3;			$ItemMax[sfemale, RifleClip] = 3;			
$ItemMax[sarmor, SniperClip] = 0;			$ItemMax[sfemale, SniperClip] = 0;			
$ItemMax[sarmor, MGunClip] = 0;				$ItemMax[sfemale, MGunClip] = 0;			
$ItemMax[sarmor, CutterayCell] = 3;			$ItemMax[sfemale, CutterayCell] = 3;			
$ItemMax[sarmor, SmallLasCell] = 3;			$ItemMax[sfemale, SmallLasCell] = 3;			
$ItemMax[sarmor, RifleLasCell] = 2;			$ItemMax[sfemale, RifleLasCell] = 2;			
$ItemMax[sarmor, HeavyLasCell] = 3;			$ItemMax[sfemale, HeavyLasCell] = 3;			
$ItemMax[sarmor, RLauncherClip] = 0;			$ItemMax[sfemale, RLauncherClip] = 0;			

//New ammos
$ItemMax[sarmor, PistolAmmo] = 12;			$ItemMax[sfemale, PistolAmmo] = 12;			
$ItemMax[sarmor, MaulaAmmo] = 5;			$ItemMax[sfemale, MaulaAmmo] = 5;			
$ItemMax[sarmor, StunnerAmmo] = 2;			$ItemMax[sfemale, StunnerAmmo] = 2;			
$ItemMax[sarmor, RifleAmmo] = 50;			$ItemMax[sfemale, RifleAmmo] = 50;			
$ItemMax[sarmor, MGunAmmo] = 0;				$ItemMax[sfemale, MGunAmmo] = 0;			
$ItemMax[sarmor, SniperAmmo] = 0;			$ItemMax[sfemale, SniperAmmo] = 0;			
$ItemMax[sarmor, RLauncherAmmo] = 1;			$ItemMax[sfemale, RLauncherAmmo] = 1;			
$ItemMax[sarmor, FlamethrowerAmmo] = 0;			$ItemMax[sfemale, FlamethrowerAmmo] = 0;			
$ItemMax[sarmor, PillerAmmo] = 3;			$ItemMax[sfemale, PillerAmmo] = 3;			
$ItemMax[sarmor, CutterayAmmo] = 25;			$ItemMax[sfemale, CutterayAmmo] = 25;			
$ItemMax[sarmor, SmallLasAmmo] = 75;			$ItemMax[sfemale, SmallLasAmmo] = 75;			
$ItemMax[sarmor, RifleLasAmmo] = 75;			$ItemMax[sfemale, RifleLasAmmo] = 75;			
$ItemMax[sarmor, HeavyLasAmmo] = 30;			$ItemMax[sfemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[sarmor, EnergyPack] = 0;			$ItemMax[sfemale, EnergyPack] = 0;			
$ItemMax[sarmor, TurretPack] = 0;			$ItemMax[sfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[sarmor, RepairPack] = 1;			$ItemMax[sfemale, RepairPack] = 1;			
$ItemMax[sarmor, ShieldPack] = 1;			$ItemMax[sfemale, ShieldPack] = 1;			
$ItemMax[sarmor, SensorJammerPack] = 1;			$ItemMax[sfemale, SensorJammerPack] = 1;			
$ItemMax[sarmor, AmmoPack] = 1;				$ItemMax[sfemale, AmmoPack] = 1;			

//New Packs
$ItemMax[sarmor, ExplosivePack] = 1;			$ItemMax[sfemale, ExplosivePack] = 1;			
$ItemMax[sarmor, SuicidePack] = 1;			$ItemMax[sfemale, SuicidePack] = 1;			
$ItemMax[sarmor, FuelPack] = 1;				$ItemMax[sfemale, FuelPack] = 1;				
$ItemMax[sarmor, SuspensorPack] = 1;			$ItemMax[sfemale, SuspensorPack] = 1;			
$ItemMax[sarmor, StoneBurnerPack] = 1;			$ItemMax[sfemale, StoneBurnerPack] = 1;			
$ItemMax[sarmor, SNukePack] = 1;			$ItemMax[sfemale, SNukePack] = 1;			
$ItemMax[sarmor, MNukePack] = 1;			$ItemMax[sfemale, MNukePack] = 1;			
$ItemMax[sarmor, LNukePack] = 1;			$ItemMax[sfemale, LNukePack] = 1;			
$ItemMax[sarmor, CamoPack] = 0;				$ItemMax[sfemale, CamoPack] = 0;			
$ItemMax[sarmor, ThumperPack] = 1;			$ItemMax[sfemale, ThumperPack] = 1;			

//Old deployable packs used
$ItemMax[sarmor, MotionSensorPack] = 1;			$ItemMax[sfemale, MotionSensorPack] = 1;			
$ItemMax[sarmor, PulseSensorPack] = 1;			$ItemMax[sfemale, PulseSensorPack] = 1;			
$ItemMax[sarmor, DeployableSensorJammerPack] = 1;	$ItemMax[sfemale, DeployableSensorJammerPack] = 1;	
$ItemMax[sarmor, CameraPack] = 1;			$ItemMax[sfemale, CameraPack] = 1;			
$ItemMax[sarmor, DeployableInvPack] = 1;		$ItemMax[sfemale, DeployableInvPack] = 1;		
$ItemMax[sarmor, DeployableAmmoPack] = 1;		$ItemMax[sfemale, DeployableAmmoPack] = 1;		

//New deployable packs used
$ItemMax[sarmor, PlasteelPack] = 1;			$ItemMax[sfemale, PlasteelPack] = 1;			
$ItemMax[sarmor, LPentashieldPack] = 1;			$ItemMax[sfemale, LPentashieldPack] = 1;			
$ItemMax[sarmor, SPentashieldPack] = 1;			$ItemMax[sfemale, SPentashieldPack] = 1;			
$ItemMax[sarmor, DeployableGenPack] = 1;		$ItemMax[sfemale, DeployableGenPack] = 1;		
$ItemMax[sarmor, HieregPack] = 0;			$ItemMax[sfemale, HieregPack] = 0;			
$ItemMax[sarmor, StationaryLasgunPack] = 1;		$ItemMax[sfemale, StationaryLasgunPack] = 1;		
$ItemMax[sarmor, RepeaterLasgunPack] = 0;		$ItemMax[sfemale, RepeaterLasgunPack] = 0;		
$ItemMax[sarmor, RemoteLasgunPack] = 1;			$ItemMax[sfemale, RemoteLasgunPack] = 1;			
$ItemMax[sarmor, RemoteProjectileGunPack] = 1;		$ItemMax[sfemale, RemoteProjectileGunPack] = 1;		
$ItemMax[sarmor, HunterSeekerPlatformPack] = 1;		$ItemMax[sfemale, HunterSeekerPlatformPack] = 1;		
$ItemMax[sarmor, GholaPack] = 1;			$ItemMax[sfemale, GholaPack] = 1;		

$MaxWeapons[sarmor] = 3;				$MaxWeapons[sfemale] = 3;

//----------------------------------------------------------------------------
// Trooper Armor
//----------------------------------------------------------------------------

$DamageScale[tarmor, $LandingDamageType] = 1.0;		$DamageScale[tfemale, $LandingDamageType] = 1.0;		
$DamageScale[tarmor, $ImpactDamageType] = 1.0;		$DamageScale[tfemale, $ImpactDamageType] = 1.0;		
$DamageScale[tarmor, $CrushDamageType] = 1.0;		$DamageScale[tfemale, $CrushDamageType] = 1.0;		
$DamageScale[tarmor, $BulletDamageType] = 0.8;		$DamageScale[tfemale, $BulletDamageType] = 0.8;		
$DamageScale[tarmor, $PlasmaDamageType] = 1.0;		$DamageScale[tfemale, $PlasmaDamageType] = 1.0;		
$DamageScale[tarmor, $EnergyDamageType] = 1.3;		$DamageScale[tfemale, $EnergyDamageType] = 1.3;		
$DamageScale[tarmor, $ExplosionDamageType] = 1.0;	$DamageScale[tfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[tarmor, $MissileDamageType] = 1.0;		$DamageScale[tfemale, $MissileDamageType] = 1.0;		
$DamageScale[tarmor, $DebrisDamageType] = 1.0;		$DamageScale[tfemale, $DebrisDamageType] = 1.0;		
$DamageScale[tarmor, $ShrapnelDamageType] = 1.0;	$DamageScale[tfemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[tarmor, $LaserDamageType] = 0.8;		$DamageScale[tfemale, $LaserDamageType] = 0.8;		
$DamageScale[tarmor, $MortarDamageType] = 1.3;		$DamageScale[tfemale, $MortarDamageType] = 1.3;		
$DamageScale[tarmor, $BlasterDamageType] = 1.3;		$DamageScale[tfemale, $BlasterDamageType] = 1.3;		
$DamageScale[tarmor, $ElectricityDamageType] = 1.0;	$DamageScale[tfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[tarmor, $MineDamageType] = 1.0;		$DamageScale[tfemale, $MineDamageType] = 1.0;		
$DamageScale[tarmor, $StabDamageType] = 1.0;		$DamageScale[tfemale, $StabDamageType] = 1.0;		
$DamageScale[tarmor, $PoisonDamageType] = 1.0;		$DamageScale[tfemale, $PoisonDamageType] = 1.0;		
$DamageScale[tarmor, $StunnerDamageType] = 1.0;		$DamageScale[tfemale, $StunnerDamageType] = 1.0;		
$DamageScale[tarmor, $NukeDamageType] = 1.0;		$DamageScale[tfemale, $NukeDamageType] = 1.0;		
$DamageScale[tarmor, $Poison2DamageType] = 1.0;		$DamageScale[tfemale, $Poison2DamageType] = 1.0;		
$DamageScale[tarmor, $WormDamageType] = 1.0;		$DamageScale[tfemale, $WormDamageType] = 1.0;		
$DamageScale[tarmor, $CutterayDamageType] = 1.0;	$DamageScale[tfemale, $CutterayDamageType] = 1.0;		
$DamageScale[tarmor, $SmallLasDamageType] = 1.0;	$DamageScale[tfemale, $SmallLasDamageType] = 1.0;		
$DamageScale[tarmor, $RifleLasDamageType] = 1.0;	$DamageScale[tfemale, $RifleLasDamageType] = 1.0;		
$DamageScale[tarmor, $HeavyLasDamageType] = 1.0;	$DamageScale[tfemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[tarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[tfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[tarmor, $LargeBulletDamageType] = 1.0;	$DamageScale[tfemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[tarmor, $ThrownWeaponDamageType] = 1.0;	$DamageScale[tfemale, $ThrownWeaponDamageType] = 1.0;		
$DamageScale[tarmor, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[tfemale, $ThrownPoisonWeaponDamageType] = 1.0;
$DamageScale[tarmor, $AssassinDamageType] = 1.0;	$DamageScale[tfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[tarmor, Blaster] = 0;				$ItemMax[tfemale, Blaster] = 0;				
$ItemMax[tarmor, Chaingun] = 0;				$ItemMax[tfemale, Chaingun] = 0;				
$ItemMax[tarmor, Disclauncher] = 0;			$ItemMax[tfemale, Disclauncher] = 0;			
$ItemMax[tarmor, GrenadeLauncher] = 0;			$ItemMax[tfemale, GrenadeLauncher] = 0;			
$ItemMax[tarmor, Mortar] = 0;				$ItemMax[tfemale, Mortar] = 0;				
$ItemMax[tarmor, PlasmaGun] = 0;			$ItemMax[tfemale, PlasmaGun] = 0;			
$ItemMax[tarmor, LaserRifle] = 0;			$ItemMax[tfemale, LaserRifle] = 0;			
$ItemMax[tarmor, EnergyRifle] = 0;			$ItemMax[tfemale, EnergyRifle] = 0;			
$ItemMax[tarmor, TargetingLaser] = 0;			$ItemMax[tfemale, TargetingLaser] = 0;			
$ItemMax[tarmor, MineAmmo] = 0;				$ItemMax[tfemale, MineAmmo] = 0;				
$ItemMax[tarmor, Grenade] = 0;				$ItemMax[tfemale, Grenade] = 0;				

//Blades
$ItemMax[tarmor, Knife]  = 1;				$ItemMax[tfemale, Knife]  = 1;				
$ItemMax[tarmor, Knife2]  = 1;				$ItemMax[tfemale, Knife2]  = 1;				
$ItemMax[tarmor, SlipTip]  = 1;				$ItemMax[tfemale, SlipTip]  = 1;			
$ItemMax[tarmor, Crysknife]  = 0;			$ItemMax[tfemale, Crysknife]  = 0;			
$ItemMax[tarmor, Kindjal]  = 1;				$ItemMax[tfemale, Kindjal]  = 1;				
$ItemMax[tarmor, Saber]  = 0;				$ItemMax[tfemale, Saber]  = 0;				

//Projectiles
$ItemMax[tarmor, Pistol]  = 1;				$ItemMax[tfemale, Pistol]  = 1;				
$ItemMax[tarmor, Maula]  = 1;				$ItemMax[tfemale, Maula]  = 1;				
$ItemMax[tarmor, Stunner]  = 1;				$ItemMax[tfemale, Stunner]  = 1;
$ItemMax[tarmor, Rifle]  = 1;				$ItemMax[tfemale, Rifle]  = 1;				
$ItemMax[tarmor, Rifle2]  = 1;				$ItemMax[tfemale, Rifle2]  = 1;				
$ItemMax[tarmor, RLauncher]  = 1;			$ItemMax[tfemale, RLauncher]  = 1;			
$ItemMax[tarmor, Flamethrower]  = 1;			$ItemMax[tfemale, Flamethrower]  = 1;			
$ItemMax[tarmor, Piller]  = 1;				$ItemMax[tfemale, Piller]  = 1;				

//Lasguns
$ItemMax[tarmor, Cutteray]  = 1;			$ItemMax[tfemale, Cutteray]  = 1;			
$ItemMax[tarmor, SmallLas]  = 1;			$ItemMax[tfemale, SmallLas]  = 1;			
$ItemMax[tarmor, RifleLas]  = 1;			$ItemMax[tfemale, RifleLas]  = 1;			
$ItemMax[tarmor, HeavyLas]  = 0;			$ItemMax[tfemale, HeavyLas]  = 0;			

//Items...
$ItemMax[tarmor, RepairKit] = 2;			$ItemMax[tfemale, RepairKit] = 2;			
$ItemMax[tarmor, Beacon]  = 3;				$ItemMax[tfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[tarmor, BulletAmmo] = 0;			$ItemMax[tfemale, BulletAmmo] = 0;			
$ItemMax[tarmor, PlasmaAmmo] = 0;			$ItemMax[tfemale, PlasmaAmmo] = 0;			
$ItemMax[tarmor, DiscAmmo] = 0;				$ItemMax[tfemale, DiscAmmo] = 0;				
$ItemMax[tarmor, GrenadeAmmo] = 0;			$ItemMax[tfemale, GrenadeAmmo] = 0;			
$ItemMax[tarmor, MortarAmmo] = 0;			$ItemMax[tfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[tarmor, PistolClip] = 3;			$ItemMax[tfemale, PistolClip] = 3;			
$ItemMax[tarmor, MaulaClip] = 2;			$ItemMax[tfemale, MaulaClip] = 2;			
$ItemMax[tarmor, StunnerClip] = 2;			$ItemMax[tfemale, StunnerClip] = 2;			
$ItemMax[tarmor, RifleClip] = 3;			$ItemMax[tfemale, RifleClip] = 3;			
$ItemMax[tarmor, CutterayCell] = 3;			$ItemMax[tfemale, CutterayCell] = 3;			
$ItemMax[tarmor, SmallLasCell] = 3;			$ItemMax[tfemale, SmallLasCell] = 3;			
$ItemMax[tarmor, RifleLasCell] = 2;			$ItemMax[tfemale, RifleLasCell] = 2;			
$ItemMax[tarmor, HeavyLasCell] = 3;			$ItemMax[tfemale, HeavyLasCell] = 3;			
$ItemMax[tarmor, RLauncherClip] = 1;			$ItemMax[tfemale, RLauncherClip] = 1;			

//New ammos
$ItemMax[tarmor, PistolAmmo] = 12;			$ItemMax[tfemale, PistolAmmo] = 12;			
$ItemMax[tarmor, MaulaAmmo] = 5;			$ItemMax[tfemale, MaulaAmmo] = 5;			
$ItemMax[tarmor, StunnerAmmo] = 2;			$ItemMax[tfemale, StunnerAmmo] = 2;			
$ItemMax[tarmor, RifleAmmo] = 50;			$ItemMax[tfemale, RifleAmmo] = 50;			
$ItemMax[tarmor, RLauncherAmmo] = 1;			$ItemMax[tfemale, RLauncherAmmo] = 1;			
$ItemMax[tarmor, FlamethrowerAmmo] = 100;		$ItemMax[tfemale, FlamethrowerAmmo] = 100;			
$ItemMax[tarmor, PillerAmmo] = 5;			$ItemMax[tfemale, PillerAmmo] = 5;			
$ItemMax[tarmor, CutterayAmmo] = 25;			$ItemMax[tfemale, CutterayAmmo] = 25;			
$ItemMax[tarmor, SmallLasAmmo] = 75;			$ItemMax[tfemale, SmallLasAmmo] = 75;			
$ItemMax[tarmor, RifleLasAmmo] = 75;			$ItemMax[tfemale, RifleLasAmmo] = 75;			
$ItemMax[tarmor, HeavyLasAmmo] = 30;			$ItemMax[tfemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[tarmor, EnergyPack] = 0;			$ItemMax[tfemale, EnergyPack] = 0;			
$ItemMax[tarmor, TurretPack] = 0;			$ItemMax[tfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[tarmor, RepairPack] = 1;			$ItemMax[tfemale, RepairPack] = 1;			
$ItemMax[tarmor, ShieldPack] = 1;			$ItemMax[tfemale, ShieldPack] = 1;			
$ItemMax[tarmor, SensorJammerPack] = 1;			$ItemMax[tfemale, SensorJammerPack] = 1;			
$ItemMax[tarmor, AmmoPack] = 1;				$ItemMax[tfemale, AmmoPack] = 1;			

//New Packs
$ItemMax[tarmor, ExplosivePack] = 1;			$ItemMax[tfemale, ExplosivePack] = 1;			
$ItemMax[tarmor, SuicidePack] = 1;			$ItemMax[tfemale, SuicidePack] = 1;			
$ItemMax[tarmor, FuelPack] = 1;				$ItemMax[tfemale, FuelPack] = 1;				
$ItemMax[tarmor, SuspensorPack] = 0;			$ItemMax[tfemale, SuspensorPack] = 0;			
$ItemMax[tarmor, StoneBurnerPack] = 0;			$ItemMax[tfemale, StoneBurnerPack] = 0;			
$ItemMax[tarmor, SNukePack] = 1;			$ItemMax[tfemale, SNukePack] = 1;			
$ItemMax[tarmor, MNukePack] = 0;			$ItemMax[tfemale, MNukePack] = 0;			
$ItemMax[tarmor, LNukePack] = 0;			$ItemMax[tfemale, LNukePack] = 0;			
$ItemMax[tarmor, CamoPack] = 0;				$ItemMax[tfemale, CamoPack] = 0;			
$ItemMax[tarmor, ThumperPack] = 1;			$ItemMax[tfemale, ThumperPack] = 1;			

//Old deployable packs used
$ItemMax[tarmor, MotionSensorPack] = 1;			$ItemMax[tfemale, MotionSensorPack] = 1;			
$ItemMax[tarmor, PulseSensorPack] = 1;			$ItemMax[tfemale, PulseSensorPack] = 1;			
$ItemMax[tarmor, DeployableSensorJammerPack] = 1;	$ItemMax[tfemale, DeployableSensorJammerPack] = 1;	
$ItemMax[tarmor, CameraPack] = 1;			$ItemMax[tfemale, CameraPack] = 1;			
$ItemMax[tarmor, DeployableInvPack] = 1;		$ItemMax[tfemale, DeployableInvPack] = 1;		
$ItemMax[tarmor, DeployableAmmoPack] = 1;		$ItemMax[tfemale, DeployableAmmoPack] = 1;		

//New deployable packs used
$ItemMax[tarmor, PlasteelPack] = 1;			$ItemMax[tfemale, PlasteelPack] = 1;			
$ItemMax[tarmor, LPentashieldPack] = 1;			$ItemMax[tfemale, LPentashieldPack] = 1;			
$ItemMax[tarmor, SPentashieldPack] = 1;			$ItemMax[tfemale, SPentashieldPack] = 1;			
$ItemMax[tarmor, DeployableGenPack] = 1;		$ItemMax[tfemale, DeployableGenPack] = 1;		
$ItemMax[tarmor, HieregPack] = 0;			$ItemMax[tfemale, HieregPack] = 0;			
$ItemMax[tarmor, StationaryLasgunPack] = 0;		$ItemMax[tfemale, StationaryLasgunPack] = 0;		
$ItemMax[tarmor, RepeaterLasgunPack] = 0;		$ItemMax[tfemale, RepeaterLasgunPack] = 0;		
$ItemMax[tarmor, RemoteLasgunPack] = 0;			$ItemMax[tfemale, RemoteLasgunPack] = 0;			
$ItemMax[tarmor, RemoteProjectileGunPack] = 0;		$ItemMax[tfemale, RemoteProjectileGunPack] = 0;		
$ItemMax[tarmor, HunterSeekerPlatformPack] = 1;		$ItemMax[tfemale, HunterSeekerPlatformPack] = 1;		
$ItemMax[tarmor, GholaPack] = 0;			$ItemMax[tfemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[tarmor, SniperRifle] = 0;		$ItemMax[tfemale, SniperRifle] = 0;		
$ItemMax[tarmor, MGun] = 0;			$ItemMax[tfemale, MGun] = 0;		
$ItemMax[tarmor, SniperAmmo] = 0;		$ItemMax[tfemale, SniperAmmo] = 0;		
$ItemMax[tarmor, MGunAmmo] = 0;			$ItemMax[tfemale, MGunAmmo] = 0;		
$ItemMax[tarmor, SniperClip] = 0;		$ItemMax[tfemale, SniperClip] = 0;		
$ItemMax[tarmor, MGunClip] = 0;			$ItemMax[tfemale, MGunClip] = 0;		
	
$MaxWeapons[tarmor] = 3;				$MaxWeapons[tfemale] = 3;				

//----------------------------------------------------------------------------
// Fremen Armor
//----------------------------------------------------------------------------

$DamageScale[farmor, $LandingDamageType] = 1.0;		$DamageScale[ffemale, $LandingDamageType] = 1.0;		
$DamageScale[farmor, $ImpactDamageType] = 1.0;		$DamageScale[ffemale, $ImpactDamageType] = 1.0;		
$DamageScale[farmor, $CrushDamageType] = 1.0;		$DamageScale[ffemale, $CrushDamageType] = 1.0;		
$DamageScale[farmor, $BulletDamageType] = 1.0;		$DamageScale[ffemale, $BulletDamageType] = 1.0;		
$DamageScale[farmor, $PlasmaDamageType] = 1.0;		$DamageScale[ffemale, $PlasmaDamageType] = 1.0;		
$DamageScale[farmor, $EnergyDamageType] = 1.3;		$DamageScale[ffemale, $EnergyDamageType] = 1.3;		
$DamageScale[farmor, $ExplosionDamageType] = 1.0;	$DamageScale[ffemale, $ExplosionDamageType] = 1.0;		
$DamageScale[farmor, $MissileDamageType] = 1.0;		$DamageScale[ffemale, $MissileDamageType] = 1.0;		
$DamageScale[farmor, $DebrisDamageType] = 1.0;		$DamageScale[ffemale, $DebrisDamageType] = 1.0;		
$DamageScale[farmor, $ShrapnelDamageType] = 1.0;	$DamageScale[ffemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[farmor, $LaserDamageType] = 1.0;		$DamageScale[ffemale, $LaserDamageType] = 1.0;		
$DamageScale[farmor, $MortarDamageType] = 1.3;		$DamageScale[ffemale, $MortarDamageType] = 1.3;		
$DamageScale[farmor, $BlasterDamageType] = 1.3;		$DamageScale[ffemale, $BlasterDamageType] = 1.3;		
$DamageScale[farmor, $ElectricityDamageType] = 1.0;	$DamageScale[ffemale, $ElectricityDamageType] = 1.0;		
$DamageScale[farmor, $MineDamageType] = 1.0;		$DamageScale[ffemale, $MineDamageType] = 1.0;		
$DamageScale[farmor, $StabDamageType] = 0.8;		$DamageScale[ffemale, $StabDamageType] = 0.8;		
$DamageScale[farmor, $PoisonDamageType] = 0.5;		$DamageScale[ffemale, $PoisonDamageType] = 0.5;		
$DamageScale[farmor, $StunnerDamageType] = 1.0;		$DamageScale[ffemale, $StunnerDamageType] = 1.0;		
$DamageScale[farmor, $NukeDamageType] = 1.0;		$DamageScale[ffemale, $NukeDamageType] = 1.0;		
$DamageScale[farmor, $Poison2DamageType] = 0.5;		$DamageScale[ffemale, $Poison2DamageType] = 0.5;		
$DamageScale[farmor, $WormDamageType] = 1.0;		$DamageScale[ffemale, $WormDamageType] = 1.0;		
$DamageScale[farmor, $CutterayDamageType] = 1.0;	$DamageScale[ffemale, $CutterayDamageType] = 1.0;		
$DamageScale[farmor, $SmallLasDamageType] = 1.0;	$DamageScale[ffemale, $SmallLasDamageType] = 1.0;		
$DamageScale[farmor, $RifleLasDamageType] = 1.0;	$DamageScale[ffemale, $RifleLasDamageType] = 1.0;		
$DamageScale[farmor, $HeavyLasDamageType] = 1.0;	$DamageScale[ffemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[farmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[ffemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[farmor, $LargeBulletDamageType] = 1.0;	$DamageScale[ffemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[farmor, $ThrownWeaponDamageType] = 0.8;	$DamageScale[ffemale, $ThrownWeaponDamageType] = 0.8;		
$DamageScale[farmor, $ThrownPoisonWeaponDamageType] = 0.5;	$DamageScale[ffemale, $ThrownPoisonWeaponDamageType] = 0.5;		
$DamageScale[farmor, $AssassinDamageType] = 1.0;	$DamageScale[ffemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[farmor, Blaster] = 0;				$ItemMax[ffemale, Blaster] = 0;				
$ItemMax[farmor, Chaingun] = 0;				$ItemMax[ffemale, Chaingun] = 0;				
$ItemMax[farmor, Disclauncher] = 0;			$ItemMax[ffemale, Disclauncher] = 0;			
$ItemMax[farmor, GrenadeLauncher] = 0;			$ItemMax[ffemale, GrenadeLauncher] = 0;			
$ItemMax[farmor, Mortar] = 0;				$ItemMax[ffemale, Mortar] = 0;				
$ItemMax[farmor, PlasmaGun] = 0;			$ItemMax[ffemale, PlasmaGun] = 0;			
$ItemMax[farmor, LaserRifle] = 0;			$ItemMax[ffemale, LaserRifle] = 0;			
$ItemMax[farmor, EnergyRifle] = 0;			$ItemMax[ffemale, EnergyRifle] = 0;			
$ItemMax[farmor, TargetingLaser] = 0;			$ItemMax[ffemale, TargetingLaser] = 0;			
$ItemMax[farmor, MineAmmo] = 0;				$ItemMax[ffemale, MineAmmo] = 0;				
$ItemMax[farmor, Grenade] = 0;				$ItemMax[ffemale, Grenade] = 0;				

//Blades
$ItemMax[farmor, Knife]  = 1;				$ItemMax[ffemale, Knife]  = 1;				
$ItemMax[farmor, Knife2]  = 1;				$ItemMax[ffemale, Knife2]  = 1;				
$ItemMax[farmor, SlipTip]  = 0;				$ItemMax[ffemale, SlipTip]  = 0;			
$ItemMax[farmor, CrysKnife]  = 1;			$ItemMax[ffemale, CrysKnife]  = 1;			
$ItemMax[farmor, Kindjal]  = 0;				$ItemMax[ffemale, Kindjal]  = 0;				
$ItemMax[farmor, Saber]  = 0;				$ItemMax[ffemale, Saber]  = 0;				

//Projectiles
$ItemMax[farmor, Pistol]  = 0;				$ItemMax[ffemale, Pistol]  = 0;				
$ItemMax[farmor, Maula]  = 0;				$ItemMax[ffemale, Maula]  = 0;				
$ItemMax[farmor, Stunner]  = 0;				$ItemMax[ffemale, Stunner]  = 0;				
$ItemMax[farmor, Rifle]  = 1;				$ItemMax[ffemale, Rifle]  = 1;					
$ItemMax[farmor, Rifle2]  = 1;				$ItemMax[ffemale, Rifle2]  = 1;				
$ItemMax[farmor, SniperRifle]  = 1;			$ItemMax[ffemale, SniperRifle]  = 1;				
$ItemMax[farmor, RLauncher]  = 1;			$ItemMax[ffemale, RLauncher]  = 1;			
$ItemMax[farmor, Flamethrower]  = 0;			$ItemMax[ffemale, Flamethrower]  = 0;			
$ItemMax[farmor, Piller]  = 1;				$ItemMax[ffemale, Piller]  = 1;				

//Lasguns
$ItemMax[farmor, Cutteray]  = 1;			$ItemMax[ffemale, Cutteray]  = 1;			
$ItemMax[farmor, SmallLas]  = 0;			$ItemMax[ffemale, SmallLas]  = 0;			
$ItemMax[farmor, RifleLas]  = 0;			$ItemMax[ffemale, RifleLas]  = 0;			
$ItemMax[farmor, HeavyLas]  = 0;			$ItemMax[ffemale, HeavyLas]  = 0;			

//Items...
$ItemMax[farmor, RepairKit] = 2;			$ItemMax[ffemale, RepairKit] = 2;			
$ItemMax[farmor, Beacon]  = 3;				$ItemMax[ffemale, Beacon]  = 3;				

//Old ammos
$ItemMax[farmor, BulletAmmo] = 0;			$ItemMax[ffemale, BulletAmmo] = 0;			
$ItemMax[farmor, PlasmaAmmo] = 0;			$ItemMax[ffemale, PlasmaAmmo] = 0;			
$ItemMax[farmor, DiscAmmo] = 0;				$ItemMax[ffemale, DiscAmmo] = 0;				
$ItemMax[farmor, GrenadeAmmo] = 0;			$ItemMax[ffemale, GrenadeAmmo] = 0;			
$ItemMax[farmor, MortarAmmo] = 0;			$ItemMax[ffemale, MortarAmmo] = 0;			

//Clips
$ItemMax[farmor, PistolClip] = 3;			$ItemMax[ffemale, PistolClip] = 3;			
$ItemMax[farmor, MaulaClip] = 2;			$ItemMax[ffemale, MaulaClip] = 2;			
$ItemMax[farmor, StunnerClip] = 2;			$ItemMax[ffemale, StunnerClip] = 2;			
$ItemMax[farmor, RifleClip] = 3;			$ItemMax[ffemale, RifleClip] = 3;			
$ItemMax[farmor, SniperClip] = 4;			$ItemMax[ffemale, SniperClip] = 4;			
$ItemMax[farmor, CutterayCell] = 3;			$ItemMax[ffemale, CutterayCell] = 3;			
$ItemMax[farmor, SmallLasCell] = 3;			$ItemMax[ffemale, SmallLasCell] = 3;			
$ItemMax[farmor, RifleLasCell] = 2;			$ItemMax[ffemale, RifleLasCell] = 2;			
$ItemMax[farmor, HeavyLasCell] = 3;			$ItemMax[ffemale, HeavyLasCell] = 3;			
$ItemMax[farmor, RLauncherClip] = 2;			$ItemMax[ffemale, RLauncherClip] = 2;			

//New ammos
$ItemMax[farmor, PistolAmmo] = 12;			$ItemMax[ffemale, PistolAmmo] = 12;			
$ItemMax[farmor, MaulaAmmo] = 5;			$ItemMax[ffemale, MaulaAmmo] = 5;			
$ItemMax[farmor, StunnerAmmo] = 2;			$ItemMax[ffemale, StunnerAmmo] = 2;			
$ItemMax[farmor, RifleAmmo] = 50;			$ItemMax[ffemale, RifleAmmo] = 50;			
$ItemMax[farmor, SniperAmmo] = 3;			$ItemMax[ffemale, SniperAmmo] = 3;			
$ItemMax[farmor, RLauncherAmmo] = 1;			$ItemMax[ffemale, RLauncherAmmo] = 1;			
$ItemMax[farmor, FlamethrowerAmmo] = 0;			$ItemMax[ffemale, FlamethrowerAmmo] = 0;			
$ItemMax[farmor, PillerAmmo] = 5;			$ItemMax[ffemale, PillerAmmo] = 5;			
$ItemMax[farmor, CutterayAmmo] = 25;			$ItemMax[ffemale, CutterayAmmo] = 25;			
$ItemMax[farmor, SmallLasAmmo] = 75;			$ItemMax[ffemale, SmallLasAmmo] = 75;			
$ItemMax[farmor, RifleLasAmmo] = 75;			$ItemMax[ffemale, RifleLasAmmo] = 75;			
$ItemMax[farmor, HeavyLasAmmo] = 30;			$ItemMax[ffemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[farmor, EnergyPack] = 0;			$ItemMax[ffemale, EnergyPack] = 0;			
$ItemMax[farmor, TurretPack] = 0;			$ItemMax[ffemale, TurretPack] = 0;			

//Old packs used
$ItemMax[farmor, RepairPack] = 1;			$ItemMax[ffemale, RepairPack] = 1;			
$ItemMax[farmor, ShieldPack] = 0;			$ItemMax[ffemale, ShieldPack] = 0;			
$ItemMax[farmor, SensorJammerPack] = 1;			$ItemMax[ffemale, SensorJammerPack] = 1;			
$ItemMax[farmor, AmmoPack] = 1;				$ItemMax[ffemale, AmmoPack] = 1;			

//New Packs
$ItemMax[farmor, ExplosivePack] = 1;			$ItemMax[ffemale, ExplosivePack] = 1;			
$ItemMax[farmor, SuicidePack] = 1;			$ItemMax[ffemale, SuicidePack] = 1;			
$ItemMax[farmor, FuelPack] = 1;				$ItemMax[ffemale, FuelPack] = 1;				
$ItemMax[farmor, SuspensorPack] = 0;			$ItemMax[ffemale, SuspensorPack] = 0;			
$ItemMax[farmor, StoneBurnerPack] = 0;			$ItemMax[ffemale, StoneBurnerPack] = 0;			
$ItemMax[farmor, SNukePack] = 0;			$ItemMax[ffemale, SNukePack] = 0;			
$ItemMax[farmor, MNukePack] = 0;			$ItemMax[ffemale, MNukePack] = 0;			
$ItemMax[farmor, LNukePack] = 0;			$ItemMax[ffemale, LNukePack] = 0;			
$ItemMax[farmor, CamoPack] = 1;				$ItemMax[ffemale, CamoPack] = 1;			
$ItemMax[farmor, ThumperPack] = 1;			$ItemMax[ffemale, ThumperPack] = 1;			

//Old deployable packs used
$ItemMax[farmor, MotionSensorPack] = 1;			$ItemMax[ffemale, MotionSensorPack] = 1;			
$ItemMax[farmor, PulseSensorPack] = 1;			$ItemMax[ffemale, PulseSensorPack] = 1;			
$ItemMax[farmor, DeployableSensorJammerPack] = 1;	$ItemMax[ffemale, DeployableSensorJammerPack] = 1;	
$ItemMax[farmor, CameraPack] = 1;			$ItemMax[ffemale, CameraPack] = 1;			
$ItemMax[farmor, DeployableInvPack] = 0;		$ItemMax[ffemale, DeployableInvPack] = 0;		
$ItemMax[farmor, DeployableAmmoPack] = 1;		$ItemMax[ffemale, DeployableAmmoPack] = 1;		

//New deployable packs used
$ItemMax[farmor, PlasteelPack] = 0;			$ItemMax[ffemale, PlasteelPack] = 0;			
$ItemMax[farmor, LPentashieldPack] = 0;			$ItemMax[ffemale, LPentashieldPack] = 0;			
$ItemMax[farmor, SPentashieldPack] = 0;			$ItemMax[ffemale, SPentashieldPack] = 0;			
$ItemMax[farmor, DeployableGenPack] = 0;		$ItemMax[ffemale, DeployableGenPack] = 0;		
$ItemMax[farmor, HieregPack] = 1;			$ItemMax[ffemale, HieregPack] = 1;			
$ItemMax[farmor, StationaryLasgunPack] = 0;		$ItemMax[ffemale, StationaryLasgunPack] = 0;		
$ItemMax[farmor, RepeaterLasgunPack] = 0;		$ItemMax[ffemale, RepeaterLasgunPack] = 0;		
$ItemMax[farmor, RemoteLasgunPack] = 0;			$ItemMax[ffemale, RemoteLasgunPack] = 0;			
$ItemMax[farmor, RemoteProjectileGunPack] = 0;		$ItemMax[ffemale, RemoteProjectileGunPack] = 0;		
$ItemMax[farmor, HunterSeekerPlatformPack] = 0;		$ItemMax[ffemale, HunterSeekerPlatformPack] = 0;		
$ItemMax[farmor, GholaPack] = 0;			$ItemMax[ffemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[farmor, MGun] = 0;			$ItemMax[ffemale, MGun] = 0;		
$ItemMax[farmor, MGunAmmo] = 0;			$ItemMax[ffemale, MGunAmmo] = 0;		
$ItemMax[farmor, MGunClip] = 0;			$ItemMax[ffemale, MGunClip] = 0;		

$MaxWeapons[farmor] = 4;				$MaxWeapons[ffemale] = 4;				

//----------------------------------------------------------------------------
// Fedaykin Armor
//----------------------------------------------------------------------------

$DamageScale[ffarmor, $LandingDamageType] = 1.0;	$DamageScale[fffemale, $LandingDamageType] = 1.0;		
$DamageScale[ffarmor, $ImpactDamageType] = 1.0;		$DamageScale[fffemale, $ImpactDamageType] = 1.0;		
$DamageScale[ffarmor, $CrushDamageType] = 1.0;		$DamageScale[fffemale, $CrushDamageType] = 1.0;		
$DamageScale[ffarmor, $BulletDamageType] = 1.0;		$DamageScale[fffemale, $BulletDamageType] = 1.0;		
$DamageScale[ffarmor, $PlasmaDamageType] = 1.0;		$DamageScale[fffemale, $PlasmaDamageType] = 1.0;		
$DamageScale[ffarmor, $EnergyDamageType] = 1.3;		$DamageScale[fffemale, $EnergyDamageType] = 1.3;		
$DamageScale[ffarmor, $ExplosionDamageType] = 1.0;	$DamageScale[fffemale, $ExplosionDamageType] = 1.0;		
$DamageScale[ffarmor, $MissileDamageType] = 1.0;	$DamageScale[fffemale, $MissileDamageType] = 1.0;		
$DamageScale[ffarmor, $DebrisDamageType] = 1.0;		$DamageScale[fffemale, $DebrisDamageType] = 1.0;		
$DamageScale[ffarmor, $ShrapnelDamageType] = 1.0;	$DamageScale[fffemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[ffarmor, $LaserDamageType] = 1.0;		$DamageScale[fffemale, $LaserDamageType] = 1.0;		
$DamageScale[ffarmor, $MortarDamageType] = 1.3;		$DamageScale[fffemale, $MortarDamageType] = 1.3;		
$DamageScale[ffarmor, $BlasterDamageType] = 1.3;	$DamageScale[fffemale, $BlasterDamageType] = 1.3;		
$DamageScale[ffarmor, $ElectricityDamageType] = 1.0;	$DamageScale[fffemale, $ElectricityDamageType] = 1.0;		
$DamageScale[ffarmor, $MineDamageType] = 1.0;		$DamageScale[fffemale, $MineDamageType] = 1.0;		
$DamageScale[ffarmor, $StabDamageType] = 0.8;		$DamageScale[fffemale, $StabDamageType] = 0.8;		
$DamageScale[ffarmor, $PoisonDamageType] = 0.5;		$DamageScale[fffemale, $PoisonDamageType] = 0.5;		
$DamageScale[ffarmor, $StunnerDamageType] = 1.0;	$DamageScale[fffemale, $StunnerDamageType] = 1.0;		
$DamageScale[ffarmor, $NukeDamageType] = 1.0;		$DamageScale[fffemale, $NukeDamageType] = 1.0;		
$DamageScale[ffarmor, $Poison2DamageType] = 0.5;	$DamageScale[fffemale, $Poison2DamageType] = 0.5;		
$DamageScale[ffarmor, $WormDamageType] = 1.0;		$DamageScale[fffemale, $WormDamageType] = 1.0;		
$DamageScale[ffarmor, $CutterayDamageType] = 1.0;	$DamageScale[fffemale, $CutterayDamageType] = 1.0;		
$DamageScale[ffarmor, $SmallLasDamageType] = 1.0;	$DamageScale[fffemale, $SmallLasDamageType] = 1.0;		
$DamageScale[ffarmor, $RifleLasDamageType] = 1.0;	$DamageScale[fffemale, $RifleLasDamageType] = 1.0;		
$DamageScale[ffarmor, $HeavyLasDamageType] = 1.0;	$DamageScale[fffemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[ffarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[fffemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[ffarmor, $LargeBulletDamageType] = 1.0;	$DamageScale[fffemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[ffarmor, $ThrownWeaponDamageType] = 0.8;	$DamageScale[fffemale, $ThrownWeaponDamageType] = 0.8;		
$DamageScale[ffarmor, $ThrownPoisonWeaponDamageType] = 0.5;	$DamageScale[fffemale, $ThrownPoisonWeaponDamageType] = 0.5;		
$DamageScale[ffarmor, $AssassinDamageType] = 1.0;	$DamageScale[fffemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[ffarmor, Blaster] = 0;				$ItemMax[fffemale, Blaster] = 0;				
$ItemMax[ffarmor, Chaingun] = 0;			$ItemMax[fffemale, Chaingun] = 0;				
$ItemMax[ffarmor, Disclauncher] = 0;			$ItemMax[fffemale, Disclauncher] = 0;			
$ItemMax[ffarmor, GrenadeLauncher] = 0;			$ItemMax[fffemale, GrenadeLauncher] = 0;			
$ItemMax[ffarmor, Mortar] = 0;				$ItemMax[fffemale, Mortar] = 0;				
$ItemMax[ffarmor, PlasmaGun] = 0;			$ItemMax[fffemale, PlasmaGun] = 0;			
$ItemMax[ffarmor, LaserRifle] = 0;			$ItemMax[fffemale, LaserRifle] = 0;			
$ItemMax[ffarmor, EnergyRifle] = 0;			$ItemMax[fffemale, EnergyRifle] = 0;			
$ItemMax[ffarmor, TargetingLaser] = 0;			$ItemMax[fffemale, TargetingLaser] = 0;			
$ItemMax[ffarmor, MineAmmo] = 0;			$ItemMax[fffemale, MineAmmo] = 0;				
$ItemMax[ffarmor, Grenade] = 0;				$ItemMax[fffemale, Grenade] = 0;				

//Blades
$ItemMax[ffarmor, Knife]  = 1;				$ItemMax[fffemale, Knife]  = 1;				
$ItemMax[ffarmor, Knife2]  = 1;				$ItemMax[fffemale, Knife2]  = 1;				
$ItemMax[ffarmor, SlipTip]  = 0;			$ItemMax[fffemale, SlipTip]  = 0;			
$ItemMax[ffarmor, Crysknife]  = 1;			$ItemMax[fffemale, Crysknife]  = 1;			
$ItemMax[ffarmor, Kindjal]  = 0;			$ItemMax[fffemale, Kindjal]  = 0;				
$ItemMax[ffarmor, Saber]  = 0;				$ItemMax[fffemale, Saber]  = 0;				

//Projectiles
$ItemMax[ffarmor, Pistol]  = 1;				$ItemMax[fffemale, Pistol]  = 1;				
$ItemMax[ffarmor, Maula]  = 0;				$ItemMax[fffemale, Maula]  = 0;				
$ItemMax[ffarmor, Stunner]  = 0;			$ItemMax[fffemale, Stunner]  = 0;				
$ItemMax[ffarmor, Rifle]  = 1;				$ItemMax[fffemale, Rifle]  = 1;					
$ItemMax[ffarmor, Rifle2]  = 1;				$ItemMax[fffemale, Rifle2]  = 1;				
$ItemMax[ffarmor, SniperRifle]  = 1;			$ItemMax[fffemale, SniperRifle]  = 1;				
$ItemMax[ffarmor, RLauncher]  = 0;			$ItemMax[fffemale, RLauncher]  = 0;			
$ItemMax[ffarmor, Flamethrower]  = 0;			$ItemMax[fffemale, Flamethrower]  = 0;			
$ItemMax[ffarmor, Piller]  = 0;				$ItemMax[fffemale, Piller]  = 0;				

//Lasguns
$ItemMax[ffarmor, Cutteray]  = 1;			$ItemMax[fffemale, Cutteray]  = 1;			
$ItemMax[ffarmor, SmallLas]  = 0;			$ItemMax[fffemale, SmallLas]  = 0;			
$ItemMax[ffarmor, RifleLas]  = 0;			$ItemMax[fffemale, RifleLas]  = 0;			
$ItemMax[ffarmor, HeavyLas]  = 0;			$ItemMax[fffemale, HeavyLas]  = 0;			

//Items...
$ItemMax[ffarmor, RepairKit] = 2;			$ItemMax[fffemale, RepairKit] = 2;			
$ItemMax[ffarmor, Beacon]  = 3;				$ItemMax[fffemale, Beacon]  = 3;				

//Old ammos
$ItemMax[ffarmor, BulletAmmo] = 0;			$ItemMax[fffemale, BulletAmmo] = 0;			
$ItemMax[ffarmor, PlasmaAmmo] = 0;			$ItemMax[fffemale, PlasmaAmmo] = 0;			
$ItemMax[ffarmor, DiscAmmo] = 0;			$ItemMax[fffemale, DiscAmmo] = 0;				
$ItemMax[ffarmor, GrenadeAmmo] = 0;			$ItemMax[fffemale, GrenadeAmmo] = 0;			
$ItemMax[ffarmor, MortarAmmo] = 0;			$ItemMax[fffemale, MortarAmmo] = 0;			

//Clips
$ItemMax[ffarmor, PistolClip] = 3;			$ItemMax[fffemale, PistolClip] = 3;			
$ItemMax[ffarmor, MaulaClip] = 2;			$ItemMax[fffemale, MaulaClip] = 2;			
$ItemMax[ffarmor, StunnerClip] = 2;			$ItemMax[fffemale, StunnerClip] = 2;			
$ItemMax[ffarmor, RifleClip] = 3;			$ItemMax[fffemale, RifleClip] = 3;			
$ItemMax[ffarmor, SniperClip] = 4;			$ItemMax[fffemale, SniperClip] = 4;			
$ItemMax[ffarmor, CutterayCell] = 3;			$ItemMax[fffemale, CutterayCell] = 3;			
$ItemMax[ffarmor, SmallLasCell] = 3;			$ItemMax[fffemale, SmallLasCell] = 3;			
$ItemMax[ffarmor, RifleLasCell] = 2;			$ItemMax[fffemale, RifleLasCell] = 2;			
$ItemMax[ffarmor, HeavyLasCell] = 3;			$ItemMax[fffemale, HeavyLasCell] = 3;			
$ItemMax[ffarmor, RLauncherClip] = 0;			$ItemMax[fffemale, RLauncherClip] = 0;			

//New ammos
$ItemMax[ffarmor, PistolAmmo] = 12;			$ItemMax[fffemale, PistolAmmo] = 12;			
$ItemMax[ffarmor, MaulaAmmo] = 5;			$ItemMax[fffemale, MaulaAmmo] = 5;			
$ItemMax[ffarmor, StunnerAmmo] = 2;			$ItemMax[fffemale, StunnerAmmo] = 2;			
$ItemMax[ffarmor, RifleAmmo] = 50;			$ItemMax[fffemale, RifleAmmo] = 50;			
$ItemMax[ffarmor, SniperAmmo] = 3;			$ItemMax[fffemale, SniperAmmo] = 3;			
$ItemMax[ffarmor, RLauncherAmmo] = 0;			$ItemMax[fffemale, RLauncherAmmo] = 0;			
$ItemMax[ffarmor, FlamethrowerAmmo] = 0;		$ItemMax[fffemale, FlamethrowerAmmo] = 0;			
$ItemMax[ffarmor, PillerAmmo] = 0;			$ItemMax[fffemale, PillerAmmo] = 0;			
$ItemMax[ffarmor, CutterayAmmo] = 25;			$ItemMax[fffemale, CutterayAmmo] = 25;			
$ItemMax[ffarmor, SmallLasAmmo] = 75;			$ItemMax[fffemale, SmallLasAmmo] = 75;			
$ItemMax[ffarmor, RifleLasAmmo] = 75;			$ItemMax[fffemale, RifleLasAmmo] = 75;			
$ItemMax[ffarmor, HeavyLasAmmo] = 30;			$ItemMax[fffemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[ffarmor, EnergyPack] = 0;			$ItemMax[fffemale, EnergyPack] = 0;			
$ItemMax[ffarmor, TurretPack] = 0;			$ItemMax[fffemale, TurretPack] = 0;			

//Old packs used
$ItemMax[ffarmor, RepairPack] = 1;			$ItemMax[fffemale, RepairPack] = 1;			
$ItemMax[ffarmor, ShieldPack] = 0;			$ItemMax[fffemale, ShieldPack] = 0;			
$ItemMax[ffarmor, SensorJammerPack] = 1;		$ItemMax[fffemale, SensorJammerPack] = 1;			
$ItemMax[ffarmor, AmmoPack] = 1;			$ItemMax[fffemale, AmmoPack] = 1;			

//New Packs
$ItemMax[ffarmor, ExplosivePack] = 1;			$ItemMax[fffemale, ExplosivePack] = 1;			
$ItemMax[ffarmor, SuicidePack] = 1;			$ItemMax[fffemale, SuicidePack] = 1;			
$ItemMax[ffarmor, FuelPack] = 0;			$ItemMax[fffemale, FuelPack] = 0;				
$ItemMax[ffarmor, SuspensorPack] = 0;			$ItemMax[fffemale, SuspensorPack] = 0;			
$ItemMax[ffarmor, StoneBurnerPack] = 0;			$ItemMax[fffemale, StoneBurnerPack] = 0;			
$ItemMax[ffarmor, SNukePack] = 1;			$ItemMax[fffemale, SNukePack] = 1;			
$ItemMax[ffarmor, MNukePack] = 1;			$ItemMax[fffemale, MNukePack] = 1;			
$ItemMax[ffarmor, LNukePack] = 1;			$ItemMax[fffemale, LNukePack] = 1;			
$ItemMax[ffarmor, CamoPack] = 1;			$ItemMax[fffemale, CamoPack] = 1;			
$ItemMax[ffarmor, ThumperPack] = 1;			$ItemMax[fffemale, ThumperPack] = 1;			

//Old deployable packs used
$ItemMax[ffarmor, MotionSensorPack] = 0;		$ItemMax[fffemale, MotionSensorPack] = 0;			
$ItemMax[ffarmor, PulseSensorPack] = 0;			$ItemMax[fffemale, PulseSensorPack] = 0;			
$ItemMax[ffarmor, DeployableSensorJammerPack] = 0;	$ItemMax[fffemale, DeployableSensorJammerPack] = 0;	
$ItemMax[ffarmor, CameraPack] = 0;			$ItemMax[fffemale, CameraPack] = 0;			
$ItemMax[ffarmor, DeployableInvPack] = 0;		$ItemMax[fffemale, DeployableInvPack] = 0;		
$ItemMax[ffarmor, DeployableAmmoPack] = 0;		$ItemMax[fffemale, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[ffarmor, PlasteelPack] = 0;			$ItemMax[fffemale, PlasteelPack] = 0;			
$ItemMax[ffarmor, LPentashieldPack] = 0;		$ItemMax[fffemale, LPentashieldPack] = 0;			
$ItemMax[ffarmor, SPentashieldPack] = 0;		$ItemMax[fffemale, SPentashieldPack] = 0;			
$ItemMax[ffarmor, DeployableGenPack] = 0;		$ItemMax[fffemale, DeployableGenPack] = 0;		
$ItemMax[ffarmor, HieregPack] = 0;			$ItemMax[fffemale, HieregPack] = 0;			
$ItemMax[ffarmor, StationaryLasgunPack] = 0;		$ItemMax[fffemale, StationaryLasgunPack] = 0;		
$ItemMax[ffarmor, RepeaterLasgunPack] = 0;		$ItemMax[fffemale, RepeaterLasgunPack] = 0;		
$ItemMax[ffarmor, RemoteLasgunPack] = 0;		$ItemMax[fffemale, RemoteLasgunPack] = 0;			
$ItemMax[ffarmor, RemoteProjectileGunPack] = 0;		$ItemMax[fffemale, RemoteProjectileGunPack] = 0;		
$ItemMax[ffarmor, HunterSeekerPlatformPack] = 0;	$ItemMax[fffemale, HunterSeekerPlatformPack] = 0;		
$ItemMax[ffarmor, GholaPack] = 0;			$ItemMax[fffemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[ffarmor, MGun] = 0;				$ItemMax[fffemale, MGun] = 0;		
$ItemMax[ffarmor, MGunAmmo] = 0;			$IftemMax[ffemale, MGunAmmo] = 0;		
$ItemMax[ffarmor, MGunClip] = 0;			$IftemMax[ffemale, MGunClip] = 0;		

$MaxWeapons[ffarmor] = 3;				$MaxWeapons[fffemale] = 3;				

//----------------------------------------------------------------------------
// Sardaukar Armor
//----------------------------------------------------------------------------

$DamageScale[ssarmor, $LandingDamageType] = 1.0;	$DamageScale[ssfemale, $LandingDamageType] = 1.0;		
$DamageScale[ssarmor, $ImpactDamageType] = 1.0;		$DamageScale[ssfemale, $ImpactDamageType] = 1.0;		
$DamageScale[ssarmor, $CrushDamageType] = 1.0;		$DamageScale[ssfemale, $CrushDamageType] = 1.0;		
$DamageScale[ssarmor, $BulletDamageType] = 0.8;		$DamageScale[ssfemale, $BulletDamageType] = 0.8;		
$DamageScale[ssarmor, $PlasmaDamageType] = 0.5;		$DamageScale[ssfemale, $PlasmaDamageType] = 0.5;		
$DamageScale[ssarmor, $EnergyDamageType] = 1.3;		$DamageScale[ssfemale, $EnergyDamageType] = 1.3;		
$DamageScale[ssarmor, $ExplosionDamageType] = 1.0;	$DamageScale[ssfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[ssarmor, $MissileDamageType] = 1.0;	$DamageScale[ssfemale, $MissileDamageType] = 1.0;		
$DamageScale[ssarmor, $DebrisDamageType] = 1.0;		$DamageScale[ssfemale, $DebrisDamageType] = 1.0;		
$DamageScale[ssarmor, $ShrapnelDamageType] = 1.0;	$DamageScale[ssfemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[ssarmor, $LaserDamageType] = 0.8;		$DamageScale[ssfemale, $LaserDamageType] = 0.8;		
$DamageScale[ssarmor, $MortarDamageType] = 1.3;		$DamageScale[ssfemale, $MortarDamageType] = 1.3;		
$DamageScale[ssarmor, $BlasterDamageType] = 1.3;	$DamageScale[ssfemale, $BlasterDamageType] = 1.3;		
$DamageScale[ssarmor, $ElectricityDamageType] = 1.0;	$DamageScale[ssfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[ssarmor, $MineDamageType] = 1.0;		$DamageScale[ssfemale, $MineDamageType] = 1.0;		
$DamageScale[ssarmor, $StabDamageType] = 1.0;		$DamageScale[ssfemale, $StabDamageType] = 1.0;		
$DamageScale[ssarmor, $PoisonDamageType] = 1.0;		$DamageScale[ssfemale, $PoisonDamageType] = 1.0;		
$DamageScale[ssarmor, $StunnerDamageType] = 1.0;	$DamageScale[ssfemale, $StunnerDamageType] = 1.0;		
$DamageScale[ssarmor, $NukeDamageType] = 1.0;		$DamageScale[ssfemale, $NukeDamageType] = 1.0;		
$DamageScale[ssarmor, $Poison2DamageType] = 1.0;	$DamageScale[ssfemale, $Poison2DamageType] = 1.0;		
$DamageScale[ssarmor, $WormDamageType] = 1.0;		$DamageScale[ssfemale, $WormDamageType] = 1.0;		
$DamageScale[ssarmor, $CutterayDamageType] = 1.0;	$DamageScale[ssfemale, $CutterayDamageType] = 1.0;		
$DamageScale[ssarmor, $SmallLasDamageType] = 1.0;	$DamageScale[ssfemale, $SmallLasDamageType] = 1.0;		
$DamageScale[ssarmor, $RifleLasDamageType] = 1.0;	$DamageScale[ssfemale, $RifleLasDamageType] = 1.0;		
$DamageScale[ssarmor, $HeavyLasDamageType] = 1.0;	$DamageScale[ssfemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[ssarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[ssfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[ssarmor, $LargeBulletDamageType] = 1.0;	$DamageScale[ssfemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[ssarmor, $ThrownWeaponDamageType] = 1.0;	$DamageScale[ssfemale, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[ssarmor, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[ssfemale, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[ssarmor, $AssassinDamageType] = 1.0;	$DamageScale[ssfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[ssarmor, Blaster] = 0;				$ItemMax[ssfemale, Blaster] = 0;				
$ItemMax[ssarmor, Chaingun] = 0;			$ItemMax[ssfemale, Chaingun] = 0;				
$ItemMax[ssarmor, Disclauncher] = 0;			$ItemMax[ssfemale, Disclauncher] = 0;			
$ItemMax[ssarmor, GrenadeLauncher] = 0;			$ItemMax[ssfemale, GrenadeLauncher] = 0;			
$ItemMax[ssarmor, Mortar] = 0;				$ItemMax[ssfemale, Mortar] = 0;				
$ItemMax[ssarmor, PlasmaGun] = 0;			$ItemMax[ssfemale, PlasmaGun] = 0;			
$ItemMax[ssarmor, LaserRifle] = 0;			$ItemMax[ssfemale, LaserRifle] = 0;			
$ItemMax[ssarmor, EnergyRifle] = 0;			$ItemMax[ssfemale, EnergyRifle] = 0;			
$ItemMax[ssarmor, TargetingLaser] = 0;			$ItemMax[ssfemale, TargetingLaser] = 0;			
$ItemMax[ssarmor, MineAmmo] = 0;			$ItemMax[ssfemale, MineAmmo] = 0;				
$ItemMax[ssarmor, Grenade] = 0;				$ItemMax[ssfemale, Grenade] = 0;				

//Blades
$ItemMax[ssarmor, Knife]  = 1;				$ItemMax[ssfemale, Knife]  = 1;				
$ItemMax[ssarmor, Knife2]  = 1;				$ItemMax[ssfemale, Knife2]  = 1;				
$ItemMax[ssarmor, SlipTip]  = 1;			$ItemMax[ssfemale, SlipTip]  = 1;			
$ItemMax[ssarmor, Crysknife]  = 0;			$ItemMax[ssfemale, Crysknife]  = 0;			
$ItemMax[ssarmor, Kindjal]  = 1;			$ItemMax[ssfemale, Kindjal]  = 1;				
$ItemMax[ssarmor, Saber]  = 1;				$ItemMax[ssfemale, Saber]  = 1;				

//Projectiles
$ItemMax[ssarmor, Pistol]  = 1;				$ItemMax[ssfemale, Pistol]  = 1;				
$ItemMax[ssarmor, Maula]  = 1;				$ItemMax[ssfemale, Maula]  = 1;				
$ItemMax[ssarmor, Stunner]  = 1;			$ItemMax[ssfemale, Stunner]  = 1;				
$ItemMax[ssarmor, Rifle]  = 1;				$ItemMax[ssfemale, Rifle]  = 1;					
$ItemMax[ssarmor, Rifle2]  = 1;				$ItemMax[ssfemale, Rifle2]  = 1;				
$ItemMax[ssarmor, MGun]  = 1;				$ItemMax[ssfemale, MGun]  = 1;				
$ItemMax[ssarmor, RLauncher]  = 1;			$ItemMax[ssfemale, RLauncher]  = 1;			
$ItemMax[ssarmor, Flamethrower]  = 1;			$ItemMax[ssfemale, Flamethrower]  = 1;			
$ItemMax[ssarmor, Piller]  = 1;				$ItemMax[ssfemale, Piller]  = 1;				

//Lasguns
$ItemMax[ssarmor, Cutteray]  = 1;			$ItemMax[ssfemale, Cutteray]  = 1;			
$ItemMax[ssarmor, SmallLas]  = 1;			$ItemMax[ssfemale, SmallLas]  = 1;			
$ItemMax[ssarmor, RifleLas]  = 1;			$ItemMax[ssfemale, RifleLas]  = 1;			
$ItemMax[ssarmor, HeavyLas]  = 0;			$ItemMax[ssfemale, HeavyLas]  = 0;			

//Items...
$ItemMax[ssarmor, RepairKit] = 1;			$ItemMax[ssfemale, RepairKit] = 1;			
$ItemMax[ssarmor, Beacon]  = 3;				$ItemMax[ssfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[ssarmor, BulletAmmo] = 0;			$ItemMax[ssfemale, BulletAmmo] = 0;			
$ItemMax[ssarmor, PlasmaAmmo] = 0;			$ItemMax[ssfemale, PlasmaAmmo] = 0;			
$ItemMax[ssarmor, DiscAmmo] = 0;			$ItemMax[ssfemale, DiscAmmo] = 0;				
$ItemMax[ssarmor, GrenadeAmmo] = 0;			$ItemMax[ssfemale, GrenadeAmmo] = 0;			
$ItemMax[ssarmor, MortarAmmo] = 0;			$ItemMax[ssfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[ssarmor, PistolClip] = 3;			$ItemMax[ssfemale, PistolClip] = 3;			
$ItemMax[ssarmor, MaulaClip] = 2;			$ItemMax[ssfemale, MaulaClip] = 2;			
$ItemMax[ssarmor, StunnerClip] = 2;			$ItemMax[ssfemale, StunnerClip] = 2;			
$ItemMax[ssarmor, RifleClip] = 3;			$ItemMax[ssfemale, RifleClip] = 3;			
$ItemMax[ssarmor, MGunClip] = 4;			$ItemMax[ssfemale, MGunClip] = 4;			
$ItemMax[ssarmor, CutterayCell] = 3;			$ItemMax[ssfemale, CutterayCell] = 3;			
$ItemMax[ssarmor, SmallLasCell] = 3;			$ItemMax[ssfemale, SmallLasCell] = 3;			
$ItemMax[ssarmor, RifleLasCell] = 2;			$ItemMax[ssfemale, RifleLasCell] = 2;			
$ItemMax[ssarmor, HeavyLasCell] = 3;			$ItemMax[ssfemale, HeavyLasCell] = 3;			
$ItemMax[ssarmor, RLauncherClip] = 1;			$ItemMax[ssfemale, RLauncherClip] = 1;			

//New ammos
$ItemMax[ssarmor, PistolAmmo] = 12;			$ItemMax[ssfemale, PistolAmmo] = 12;			
$ItemMax[ssarmor, MaulaAmmo] = 5;			$ItemMax[ssfemale, MaulaAmmo] = 5;			
$ItemMax[ssarmor, StunnerAmmo] = 2;			$ItemMax[ssfemale, StunnerAmmo] = 2;			
$ItemMax[ssarmor, RifleAmmo] = 50;			$ItemMax[ssfemale, RifleAmmo] = 50;			
$ItemMax[ssarmor, MGunAmmo] = 75;			$ItemMax[ssfemale, MGunAmmo] = 75;			
$ItemMax[ssarmor, RLauncherAmmo] = 1;			$ItemMax[ssfemale, RLauncherAmmo] = 1;			
$ItemMax[ssarmor, FlamethrowerAmmo] = 100;		$ItemMax[ssfemale, FlamethrowerAmmo] = 100;			
$ItemMax[ssarmor, PillerAmmo] = 5;			$ItemMax[ssfemale, PillerAmmo] = 5;			
$ItemMax[ssarmor, CutterayAmmo] = 25;			$ItemMax[ssfemale, CutterayAmmo] = 25;			
$ItemMax[ssarmor, SmallLasAmmo] = 75;			$ItemMax[ssfemale, SmallLasAmmo] = 75;			
$ItemMax[ssarmor, RifleLasAmmo] = 75;			$ItemMax[ssfemale, RifleLasAmmo] = 75;			
$ItemMax[ssarmor, HeavyLasAmmo] = 30;			$ItemMax[ssfemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[ssarmor, EnergyPack] = 0;			$ItemMax[ssfemale, EnergyPack] = 0;			
$ItemMax[ssarmor, TurretPack] = 0;			$ItemMax[ssfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[ssarmor, RepairPack] = 1;			$ItemMax[ssfemale, RepairPack] = 1;			
$ItemMax[ssarmor, ShieldPack] = 1;			$ItemMax[ssfemale, ShieldPack] = 1;			
$ItemMax[ssarmor, SensorJammerPack] = 0;		$ItemMax[ssfemale, SensorJammerPack] = 0;			
$ItemMax[ssarmor, AmmoPack] = 1;			$ItemMax[ssfemale, AmmoPack] = 1;			

//New Packs
$ItemMax[ssarmor, ExplosivePack] = 1;			$ItemMax[ssfemale, ExplosivePack] = 1;			
$ItemMax[ssarmor, SuicidePack] = 1;			$ItemMax[ssfemale, SuicidePack] = 1;			
$ItemMax[ssarmor, FuelPack] = 1;			$ItemMax[ssfemale, FuelPack] = 1;				
$ItemMax[ssarmor, SuspensorPack] = 1;			$ItemMax[ssfemale, SuspensorPack] = 1;			
$ItemMax[ssarmor, StoneBurnerPack] = 1;			$ItemMax[ssfemale, StoneBurnerPack] = 1;			
$ItemMax[ssarmor, SNukePack] = 1;			$ItemMax[ssfemale, SNukePack] = 1;			
$ItemMax[ssarmor, MNukePack] = 1;			$ItemMax[ssfemale, MNukePack] = 1;			
$ItemMax[ssarmor, LNukePack] = 1;			$ItemMax[ssfemale, LNukePack] = 1;			
$ItemMax[ssarmor, CamoPack] = 0;			$ItemMax[ssfemale, CamoPack] = 0;			
$ItemMax[ssarmor, ThumperPack] = 0;			$ItemMax[ssfemale, ThumperPack] = 0;			

//Old deployable packs used
$ItemMax[ssarmor, MotionSensorPack] = 0;		$ItemMax[ssfemale, MotionSensorPack] = 0;			
$ItemMax[ssarmor, PulseSensorPack] = 0;			$ItemMax[ssfemale, PulseSensorPack] = 0;			
$ItemMax[ssarmor, DeployableSensorJammerPack] = 0;	$ItemMax[ssfemale, DeployableSensorJammerPack] = 0;	
$ItemMax[ssarmor, CameraPack] = 0;			$ItemMax[ssfemale, CameraPack] = 0;			
$ItemMax[ssarmor, DeployableInvPack] = 0;		$ItemMax[ssfemale, DeployableInvPack] = 0;		
$ItemMax[ssarmor, DeployableAmmoPack] = 0;		$ItemMax[ssfemale, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[ssarmor, PlasteelPack] = 0;			$ItemMax[ssfemale, PlasteelPack] = 0;			
$ItemMax[ssarmor, LPentashieldPack] = 0;		$ItemMax[ssfemale, LPentashieldPack] = 0;			
$ItemMax[ssarmor, SPentashieldPack] = 0;		$ItemMax[ssfemale, SPentashieldPack] = 0;			
$ItemMax[ssarmor, DeployableGenPack] = 0;		$ItemMax[ssfemale, DeployableGenPack] = 0;		
$ItemMax[ssarmor, HieregPack] = 0;			$ItemMax[ssfemale, HieregPack] = 0;			
$ItemMax[ssarmor, StationaryLasgunPack] = 0;		$ItemMax[ssfemale, StationaryLasgunPack] = 0;		
$ItemMax[ssarmor, RepeaterLasgunPack] = 0;		$ItemMax[ssfemale, RepeaterLasgunPack] = 0;		
$ItemMax[ssarmor, RemoteLasgunPack] = 0;		$ItemMax[ssfemale, RemoteLasgunPack] = 0;			
$ItemMax[ssarmor, RemoteProjectileGunPack] = 0;		$ItemMax[ssfemale, RemoteProjectileGunPack] = 0;		
$ItemMax[ssarmor, HunterSeekerPlatformPack] = 1;	$ItemMax[ssfemale, HunterSeekerPlatformPack] = 1;		
$ItemMax[ssarmor, GholaPack] = 0;			$ItemMax[ssfemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[ssarmor, SniperRifle] = 0;		$ItemMax[ssfemale, SniperRifle] = 0;		
$ItemMax[ssarmor, SniperAmmo] = 0;		$ItemMax[ssfemale, SniperAmmo] = 0;		
$ItemMax[ssarmor, SniperClip] = 0;		$ItemMax[ssfemale, SniperClip] = 0;		


$MaxWeapons[ssarmor] = 4;				$MaxWeapons[ssfemale] = 4;				

//----------------------------------------------------------------------------
// Bashar Armor
//----------------------------------------------------------------------------

$DamageScale[barmor, $LandingDamageType] = 1.0;		$DamageScale[bfemale, $LandingDamageType] = 1.0;		
$DamageScale[barmor, $ImpactDamageType] = 1.0;		$DamageScale[bfemale, $ImpactDamageType] = 1.0;		
$DamageScale[barmor, $CrushDamageType] = 1.0;		$DamageScale[bfemale, $CrushDamageType] = 1.0;		
$DamageScale[barmor, $BulletDamageType] = 0.8;		$DamageScale[bfemale, $BulletDamageType] = 0.8;		
$DamageScale[barmor, $PlasmaDamageType] = 0.5;		$DamageScale[bfemale, $PlasmaDamageType] = 0.5;		
$DamageScale[barmor, $EnergyDamageType] = 1.3;		$DamageScale[bfemale, $EnergyDamageType] = 1.3;		
$DamageScale[barmor, $ExplosionDamageType] = 1.0;	$DamageScale[bfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[barmor, $MissileDamageType] = 1.0;		$DamageScale[bfemale, $MissileDamageType] = 1.0;		
$DamageScale[barmor, $DebrisDamageType] = 1.0;		$DamageScale[bfemale, $DebrisDamageType] = 1.0;		
$DamageScale[barmor, $ShrapnelDamageType] = 1.0;	$DamageScale[bfemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[barmor, $LaserDamageType] = 0.8;		$DamageScale[bfemale, $LaserDamageType] = 0.8;		
$DamageScale[barmor, $MortarDamageType] = 1.3;		$DamageScale[bfemale, $MortarDamageType] = 1.3;		
$DamageScale[barmor, $BlasterDamageType] = 1.3;		$DamageScale[bfemale, $BlasterDamageType] = 1.3;		
$DamageScale[barmor, $ElectricityDamageType] = 1.0;	$DamageScale[bfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[barmor, $MineDamageType] = 1.0;		$DamageScale[bfemale, $MineDamageType] = 1.0;		
$DamageScale[barmor, $StabDamageType] = 1.0;		$DamageScale[bfemale, $StabDamageType] = 1.0;		
$DamageScale[barmor, $PoisonDamageType] = 1.0;		$DamageScale[bfemale, $PoisonDamageType] = 1.0;		
$DamageScale[barmor, $StunnerDamageType] = 1.0;		$DamageScale[bfemale, $StunnerDamageType] = 1.0;		
$DamageScale[barmor, $NukeDamageType] = 1.0;		$DamageScale[bfemale, $NukeDamageType] = 1.0;		
$DamageScale[barmor, $Poison2DamageType] = 1.0;		$DamageScale[bfemale, $Poison2DamageType] = 1.0;		
$DamageScale[barmor, $WormDamageType] = 1.0;		$DamageScale[bfemale, $WormDamageType] = 1.0;		
$DamageScale[barmor, $CutterayDamageType] = 1.0;	$DamageScale[bfemale, $CutterayDamageType] = 1.0;		
$DamageScale[barmor, $SmallLasDamageType] = 1.0;	$DamageScale[bfemale, $SmallLasDamageType] = 1.0;		
$DamageScale[barmor, $RifleLasDamageType] = 1.0;	$DamageScale[bfemale, $RifleLasDamageType] = 1.0;		
$DamageScale[barmor, $HeavyLasDamageType] = 1.0;	$DamageScale[bfemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[barmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[bfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[barmor, $LargeBulletDamageType] = 1.0;	$DamageScale[bfemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[barmor, $ThrownWeaponDamageType] = 1.0;	$DamageScale[bfemale, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[barmor, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[bfemale, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[barmor, $AssassinDamageType] = 1.0;	$DamageScale[bfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[barmor, Blaster] = 0;				$ItemMax[bfemale, Blaster] = 0;				
$ItemMax[barmor, Chaingun] = 0;				$ItemMax[bfemale, Chaingun] = 0;				
$ItemMax[barmor, Disclauncher] = 0;			$ItemMax[bfemale, Disclauncher] = 0;			
$ItemMax[barmor, GrenadeLauncher] = 0;			$ItemMax[bfemale, GrenadeLauncher] = 0;			
$ItemMax[barmor, Mortar] = 0;				$ItemMax[bfemale, Mortar] = 0;				
$ItemMax[barmor, PlasmaGun] = 0;			$ItemMax[bfemale, PlasmaGun] = 0;			
$ItemMax[barmor, LaserRifle] = 0;			$ItemMax[bfemale, LaserRifle] = 0;			
$ItemMax[barmor, EnergyRifle] = 0;			$ItemMax[bfemale, EnergyRifle] = 0;			
$ItemMax[barmor, TargetingLaser] = 0;			$ItemMax[bfemale, TargetingLaser] = 0;			
$ItemMax[barmor, MineAmmo] = 0;				$ItemMax[bfemale, MineAmmo] = 0;				
$ItemMax[barmor, Grenade] = 0;				$ItemMax[bfemale, Grenade] = 0;				

//Blades
$ItemMax[barmor, Knife]  = 1;				$ItemMax[bfemale, Knife]  = 1;				
$ItemMax[barmor, Knife2]  = 1;				$ItemMax[bfemale, Knife2]  = 1;				
$ItemMax[barmor, SlipTip]  = 1;				$ItemMax[bfemale, SlipTip]  = 1;			
$ItemMax[barmor, Crysknife]  = 0;			$ItemMax[bfemale, Crysknife]  = 0;			
$ItemMax[barmor, Kindjal]  = 1;				$ItemMax[bfemale, Kindjal]  = 1;				
$ItemMax[barmor, Saber]  = 1;				$ItemMax[bfemale, Saber]  = 1;				

//Projectiles
$ItemMax[barmor, Pistol]  = 1;				$ItemMax[bfemale, Pistol]  = 1;				
$ItemMax[barmor, Maula]  = 1;				$ItemMax[bfemale, Maula]  = 1;				
$ItemMax[barmor, Stunner]  = 1;				$ItemMax[bfemale, Stunner]  = 1;				
$ItemMax[barmor, Rifle]  = 1;				$ItemMax[bfemale, Rifle]  = 1;					
$ItemMax[barmor, Rifle2]  = 1;				$ItemMax[bfemale, Rifle2]  = 1;				
$ItemMax[barmor, RLauncher]  = 1;			$ItemMax[bfemale, RLauncher]  = 1;			
$ItemMax[barmor, Flamethrower]  = 0;			$ItemMax[bfemale, Flamethrower]  = 0;			
$ItemMax[barmor, Piller]  = 1;				$ItemMax[bfemale, Piller]  = 1;				

//Lasguns
$ItemMax[barmor, Cutteray]  = 1;			$ItemMax[bfemale, Cutteray]  = 1;			
$ItemMax[barmor, SmallLas]  = 1;			$ItemMax[bfemale, SmallLas]  = 1;			
$ItemMax[barmor, RifleLas]  = 1;			$ItemMax[bfemale, RifleLas]  = 1;			
$ItemMax[barmor, HeavyLas]  = 0;			$ItemMax[bfemale, HeavyLas]  = 0;			

//Items...
$ItemMax[barmor, RepairKit] = 1;			$ItemMax[bfemale, RepairKit] = 1;			
$ItemMax[barmor, Beacon]  = 3;				$ItemMax[bfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[barmor, BulletAmmo] = 0;			$ItemMax[bfemale, BulletAmmo] = 0;			
$ItemMax[barmor, PlasmaAmmo] = 0;			$ItemMax[bfemale, PlasmaAmmo] = 0;			
$ItemMax[barmor, DiscAmmo] = 0;				$ItemMax[bfemale, DiscAmmo] = 0;				
$ItemMax[barmor, GrenadeAmmo] = 0;			$ItemMax[bfemale, GrenadeAmmo] = 0;			
$ItemMax[barmor, MortarAmmo] = 0;			$ItemMax[bfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[barmor, PistolClip] = 3;			$ItemMax[bfemale, PistolClip] = 3;			
$ItemMax[barmor, MaulaClip] = 2;			$ItemMax[bfemale, MaulaClip] = 2;			
$ItemMax[barmor, StunnerClip] = 2;			$ItemMax[bfemale, StunnerClip] = 2;			
$ItemMax[barmor, RifleClip] = 3;			$ItemMax[bfemale, RifleClip] = 3;			
$ItemMax[barmor, CutterayCell] = 3;			$ItemMax[bfemale, CutterayCell] = 3;			
$ItemMax[barmor, SmallLasCell] = 3;			$ItemMax[bfemale, SmallLasCell] = 3;			
$ItemMax[barmor, RifleLasCell] = 2;			$ItemMax[bfemale, RifleLasCell] = 2;			
$ItemMax[barmor, HeavyLasCell] = 3;			$ItemMax[bfemale, HeavyLasCell] = 3;			
$ItemMax[barmor, RLauncherClip] = 1;			$ItemMax[bfemale, RLauncherClip] = 1;			

//New ammos
$ItemMax[barmor, PistolAmmo] = 12;			$ItemMax[bfemale, PistolAmmo] = 12;			
$ItemMax[barmor, MaulaAmmo] = 5;			$ItemMax[bfemale, MaulaAmmo] = 5;			
$ItemMax[barmor, StunnerAmmo] = 2;			$ItemMax[bfemale, StunnerAmmo] = 2;			
$ItemMax[barmor, RifleAmmo] = 50;			$ItemMax[bfemale, RifleAmmo] = 50;			
$ItemMax[barmor, RLauncherAmmo] = 1;			$ItemMax[bfemale, RLauncherAmmo] = 1;			
$ItemMax[barmor, FlamethrowerAmmo] = 100;		$ItemMax[bfemale, FlamethrowerAmmo] = 100;			
$ItemMax[barmor, PillerAmmo] = 5;			$ItemMax[bfemale, PillerAmmo] = 5;			
$ItemMax[barmor, CutterayAmmo] = 25;			$ItemMax[bfemale, CutterayAmmo] = 25;			
$ItemMax[barmor, SmallLasAmmo] = 75;			$ItemMax[bfemale, SmallLasAmmo] = 75;			
$ItemMax[barmor, RifleLasAmmo] = 75;			$ItemMax[bfemale, RifleLasAmmo] = 75;			
$ItemMax[barmor, HeavyLasAmmo] = 30;			$ItemMax[bfemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[barmor, EnergyPack] = 0;			$ItemMax[bfemale, EnergyPack] = 0;			
$ItemMax[barmor, TurretPack] = 0;			$ItemMax[bfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[barmor, RepairPack] = 1;			$ItemMax[bfemale, RepairPack] = 1;			
$ItemMax[barmor, ShieldPack] = 1;			$ItemMax[bfemale, ShieldPack] = 1;			
$ItemMax[barmor, SensorJammerPack] = 0;			$ItemMax[bfemale, SensorJammerPack] = 0;			
$ItemMax[barmor, AmmoPack] = 1;				$ItemMax[bfemale, AmmoPack] = 1;			

//New Packs
$ItemMax[barmor, ExplosivePack] = 1;			$ItemMax[bfemale, ExplosivePack] = 1;			
$ItemMax[barmor, SuicidePack] = 1;			$ItemMax[bfemale, SuicidePack] = 1;			
$ItemMax[barmor, FuelPack] = 1;				$ItemMax[bfemale, FuelPack] = 1;				
$ItemMax[barmor, SuspensorPack] = 1;			$ItemMax[bfemale, SuspensorPack] = 1;			
$ItemMax[barmor, StoneBurnerPack] = 0;			$ItemMax[bfemale, StoneBurnerPack] = 0;			
$ItemMax[barmor, SNukePack] = 0;			$ItemMax[bfemale, SNukePack] = 0;			
$ItemMax[barmor, MNukePack] = 0;			$ItemMax[bfemale, MNukePack] = 0;			
$ItemMax[barmor, LNukePack] = 0;			$ItemMax[bfemale, LNukePack] = 0;			
$ItemMax[barmor, CamoPack] = 0;				$ItemMax[bfemale, CamoPack] = 0;			
$ItemMax[barmor, ThumperPack] = 0;			$ItemMax[bfemale, ThumperPack] = 0;			

//Old deployable packs used	
$ItemMax[barmor, MotionSensorPack] = 1;			$ItemMax[bfemale, MotionSensorPack] = 1;			
$ItemMax[barmor, PulseSensorPack] = 1;			$ItemMax[bfemale, PulseSensorPack] = 1;			
$ItemMax[barmor, DeployableSensorJammerPack] = 0;	$ItemMax[bfemale, DeployableSensorJammerPack] = 0;	
$ItemMax[barmor, CameraPack] = 1;			$ItemMax[bfemale, CameraPack] = 1;			
$ItemMax[barmor, DeployableInvPack] = 0;		$ItemMax[bfemale, DeployableInvPack] = 0;		
$ItemMax[barmor, DeployableAmmoPack] = 0;		$ItemMax[bfemale, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[barmor, PlasteelPack] = 1;			$ItemMax[bfemale, PlasteelPack] = 1;			
$ItemMax[barmor, LPentashieldPack] = 1;			$ItemMax[bfemale, LPentashieldPack] = 1;			
$ItemMax[barmor, SPentashieldPack] = 1;			$ItemMax[bfemale, SPentashieldPack] = 1;			
$ItemMax[barmor, DeployableGenPack] = 1;		$ItemMax[bfemale, DeployableGenPack] = 1;		
$ItemMax[barmor, HieregPack] = 0;			$ItemMax[bfemale, HieregPack] = 0;			
$ItemMax[barmor, StationaryLasgunPack] = 0;		$ItemMax[bfemale, StationaryLasgunPack] = 0;		
$ItemMax[barmor, RepeaterLasgunPack] = 0;		$ItemMax[bfemale, RepeaterLasgunPack] = 0;		
$ItemMax[barmor, RemoteLasgunPack] = 0;			$ItemMax[bfemale, RemoteLasgunPack] = 0;			
$ItemMax[barmor, RemoteProjectileGunPack] = 0;		$ItemMax[bfemale, RemoteProjectileGunPack] = 0;		
$ItemMax[barmor, HunterSeekerPlatformPack] = 1;		$ItemMax[bfemale, HunterSeekerPlatformPack] = 1;		
$ItemMax[barmor, GholaPack] = 0;			$ItemMax[bfemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[barmor, SniperRifle] = 0;		$ItemMax[bfemale, SniperRifle] = 0;		
$ItemMax[barmor, MGun] = 0;			$ItemMax[bfemale, MGun] = 0;		
$ItemMax[barmor, SniperAmmo] = 0;		$ItemMax[bfemale, SniperAmmo] = 0;		
$ItemMax[barmor, MGunAmmo] = 0;			$ItemMax[bfemale, MGunAmmo] = 0;		
$ItemMax[barmor, SniperClip] = 0;		$ItemMax[bfemale, SniperClip] = 0;		
$ItemMax[barmor, MGunClip] = 0;			$ItemMax[bfemale, MGunClip] = 0;		


$MaxWeapons[barmor] = 3;				$MaxWeapons[bfemale] = 3;				

//----------------------------------------------------------------------------
// Burseg Armor
//----------------------------------------------------------------------------

$DamageScale[bbarmor, $LandingDamageType] = 1.0;	$DamageScale[bbfemale, $LandingDamageType] = 1.0;		
$DamageScale[bbarmor, $ImpactDamageType] = 1.0;		$DamageScale[bbfemale, $ImpactDamageType] = 1.0;		
$DamageScale[bbarmor, $CrushDamageType] = 1.0;		$DamageScale[bbfemale, $CrushDamageType] = 1.0;		
$DamageScale[bbarmor, $BulletDamageType] = 0.8;		$DamageScale[bbfemale, $BulletDamageType] = 0.8;		
$DamageScale[bbarmor, $PlasmaDamageType] = 0.5;		$DamageScale[bbfemale, $PlasmaDamageType] = 0.5;		
$DamageScale[bbarmor, $EnergyDamageType] = 1.3;		$DamageScale[bbfemale, $EnergyDamageType] = 1.3;		
$DamageScale[bbarmor, $ExplosionDamageType] = 1.0;	$DamageScale[bbfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[bbarmor, $MissileDamageType] = 1.0;	$DamageScale[bbfemale, $MissileDamageType] = 1.0;		
$DamageScale[bbarmor, $DebrisDamageType] = 1.0;		$DamageScale[bbfemale, $DebrisDamageType] = 1.0;		
$DamageScale[bbarmor, $ShrapnelDamageType] = 1.0;	$DamageScale[bbfemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[bbarmor, $LaserDamageType] = 0.8;		$DamageScale[bbfemale, $LaserDamageType] = 0.8;		
$DamageScale[bbarmor, $MortarDamageType] = 1.3;		$DamageScale[bbfemale, $MortarDamageType] = 1.3;		
$DamageScale[bbarmor, $BlasterDamageType] = 1.3;	$DamageScale[bbfemale, $BlasterDamageType] = 1.3;		
$DamageScale[bbarmor, $ElectricityDamageType] = 1.0;	$DamageScale[bbfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[bbarmor, $MineDamageType] = 1.0;		$DamageScale[bbfemale, $MineDamageType] = 1.0;		
$DamageScale[bbarmor, $StabDamageType] = 1.0;		$DamageScale[bbfemale, $StabDamageType] = 1.0;		
$DamageScale[bbarmor, $PoisonDamageType] = 1.0;		$DamageScale[bbfemale, $PoisonDamageType] = 1.0;		
$DamageScale[bbarmor, $StunnerDamageType] = 1.0;	$DamageScale[bbfemale, $StunnerDamageType] = 1.0;		
$DamageScale[bbarmor, $NukeDamageType] = 1.0;		$DamageScale[bbfemale, $NukeDamageType] = 1.0;		
$DamageScale[bbarmor, $Poison2DamageType] = 1.0;	$DamageScale[bbfemale, $Poison2DamageType] = 1.0;		
$DamageScale[bbarmor, $WormDamageType] = 1.0;		$DamageScale[bbfemale, $WormDamageType] = 1.0;		
$DamageScale[bbarmor, $CutterayDamageType] = 1.0;	$DamageScale[bbfemale, $CutterayDamageType] = 1.0;		
$DamageScale[bbarmor, $SmallLasDamageType] = 1.0;	$DamageScale[bbfemale, $SmallLasDamageType] = 1.0;		
$DamageScale[bbarmor, $RifleLasDamageType] = 1.0;	$DamageScale[bbfemale, $RifleLasDamageType] = 1.0;		
$DamageScale[bbarmor, $HeavyLasDamageType] = 1.0;	$DamageScale[bbfemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[bbarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[bbfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[bbarmor, $LargeBulletDamageType] = 1.0;	$DamageScale[bbfemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[bbarmor, $ThrownWeaponDamageType] = 1.0;	$DamageScale[bbfemale, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[bbarmor, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[bbfemale, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[bbarmor, $AssassinDamageType] = 1.0;	$DamageScale[bbfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[bbarmor, Blaster] = 0;				$ItemMax[bbfemale, Blaster] = 0;				
$ItemMax[bbarmor, Chaingun] = 0;			$ItemMax[bbfemale, Chaingun] = 0;				
$ItemMax[bbarmor, Disclauncher] = 0;			$ItemMax[bbfemale, Disclauncher] = 0;			
$ItemMax[bbarmor, GrenadeLauncher] = 0;			$ItemMax[bbfemale, GrenadeLauncher] = 0;			
$ItemMax[bbarmor, Mortar] = 0;				$ItemMax[bbfemale, Mortar] = 0;				
$ItemMax[bbarmor, PlasmaGun] = 0;			$ItemMax[bbfemale, PlasmaGun] = 0;			
$ItemMax[bbarmor, LaserRifle] = 0;			$ItemMax[bbfemale, LaserRifle] = 0;			
$ItemMax[bbarmor, EnergyRifle] = 0;			$ItemMax[bbfemale, EnergyRifle] = 0;			
$ItemMax[bbarmor, TargetingLaser] = 0;			$ItemMax[bbfemale, TargetingLaser] = 0;			
$ItemMax[bbarmor, MineAmmo] = 0;			$ItemMax[bbfemale, MineAmmo] = 0;				
$ItemMax[bbarmor, Grenade] = 0;				$ItemMax[bbfemale, Grenade] = 0;				

//Blades
$ItemMax[bbarmor, Knife]  = 1;				$ItemMax[bbfemale, Knife]  = 1;				
$ItemMax[bbarmor, Knife2]  = 1;				$ItemMax[bbfemale, Knife2]  = 1;				
$ItemMax[bbarmor, SlipTip]  = 1;			$ItemMax[bbfemale, SlipTip]  = 1;			
$ItemMax[bbarmor, Crysknife]  = 0;			$ItemMax[bbfemale, Crysknife]  = 0;			
$ItemMax[bbarmor, Kindjal]  = 1;			$ItemMax[bbfemale, Kindjal]  = 1;				
$ItemMax[bbarmor, Saber]  = 1;				$ItemMax[bbfemale, Saber]  = 1;				

//Projectiles
$ItemMax[bbarmor, Pistol]  = 1;				$ItemMax[bbfemale, Pistol]  = 1;				
$ItemMax[bbarmor, Maula]  = 1;				$ItemMax[bbfemale, Maula]  = 1;				
$ItemMax[bbarmor, Stunner]  = 1;			$ItemMax[bbfemale, Stunner]  = 1;				
$ItemMax[bbarmor, Rifle]  = 1;				$ItemMax[bbfemale, Rifle]  = 1;					
$ItemMax[bbarmor, Rifle2]  = 1;				$ItemMax[bbfemale, Rifle2]  = 1;				
$ItemMax[bbarmor, RLauncher]  = 0;			$ItemMax[bbfemale, RLauncher]  = 0;			
$ItemMax[bbarmor, Flamethrower]  = 0;			$ItemMax[bbfemale, Flamethrower]  = 0;			
$ItemMax[bbarmor, Piller]  = 0;				$ItemMax[bbfemale, Piller]  = 0;				

//Lasguns
$ItemMax[bbarmor, Cutteray]  = 1;			$ItemMax[bbfemale, Cutteray]  = 1;			
$ItemMax[bbarmor, SmallLas]  = 1;			$ItemMax[bbfemale, SmallLas]  = 1;			
$ItemMax[bbarmor, RifleLas]  = 1;			$ItemMax[bbfemale, RifleLas]  = 1;			
$ItemMax[bbarmor, HeavyLas]  = 0;			$ItemMax[bbfemale, HeavyLas]  = 0;			

//Items...
$ItemMax[bbarmor, RepairKit] = 1;			$ItemMax[bbfemale, RepairKit] = 1;			
$ItemMax[bbarmor, Beacon]  = 3;				$ItemMax[bbfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[bbarmor, BulletAmmo] = 0;			$ItemMax[bbfemale, BulletAmmo] = 0;			
$ItemMax[bbarmor, PlasmaAmmo] = 0;			$ItemMax[bbfemale, PlasmaAmmo] = 0;			
$ItemMax[bbarmor, DiscAmmo] = 0;			$ItemMax[bbfemale, DiscAmmo] = 0;				
$ItemMax[bbarmor, GrenadeAmmo] = 0;			$ItemMax[bbfemale, GrenadeAmmo] = 0;			
$ItemMax[bbarmor, MortarAmmo] = 0;			$ItemMax[bbfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[bbarmor, PistolClip] = 3;			$ItemMax[bbfemale, PistolClip] = 3;			
$ItemMax[bbarmor, MaulaClip] = 2;			$ItemMax[bbfemale, MaulaClip] = 2;			
$ItemMax[bbarmor, StunnerClip] = 2;			$ItemMax[bbfemale, StunnerClip] = 2;			
$ItemMax[bbarmor, RifleClip] = 3;			$ItemMax[bbfemale, RifleClip] = 3;			
$ItemMax[bbarmor, CutterayCell] = 3;			$ItemMax[bbfemale, CutterayCell] = 3;			
$ItemMax[bbarmor, SmallLasCell] = 3;			$ItemMax[bbfemale, SmallLasCell] = 3;			
$ItemMax[bbarmor, RifleLasCell] = 2;			$ItemMax[bbfemale, RifleLasCell] = 2;			
$ItemMax[bbarmor, HeavyLasCell] = 3;			$ItemMax[bbfemale, HeavyLasCell] = 3;			
$ItemMax[bbarmor, RLauncherClip] = 1;			$ItemMax[bbfemale, RLauncherClip] = 1;			

//New ammos
$ItemMax[bbarmor, PistolAmmo] = 12;			$ItemMax[bbfemale, PistolAmmo] = 12;			
$ItemMax[bbarmor, MaulaAmmo] = 5;			$ItemMax[bbfemale, MaulaAmmo] = 5;			
$ItemMax[bbarmor, StunnerAmmo] = 2;			$ItemMax[bbfemale, StunnerAmmo] = 2;			
$ItemMax[bbarmor, RifleAmmo] = 50;			$ItemMax[bbfemale, RifleAmmo] = 50;			
$ItemMax[bbarmor, RLauncherAmmo] = 1;			$ItemMax[bbfemale, RLauncherAmmo] = 1;			
$ItemMax[bbarmor, FlamethrowerAmmo] = 100;		$ItemMax[bbfemale, FlamethrowerAmmo] = 100;			
$ItemMax[bbarmor, PillerAmmo] = 5;			$ItemMax[bbfemale, PillerAmmo] = 5;			
$ItemMax[bbarmor, CutterayAmmo] = 25;			$ItemMax[bbfemale, CutterayAmmo] = 25;			
$ItemMax[bbarmor, SmallLasAmmo] = 75;			$ItemMax[bbfemale, SmallLasAmmo] = 75;			
$ItemMax[bbarmor, RifleLasAmmo] = 75;			$ItemMax[bbfemale, RifleLasAmmo] = 75;			
$ItemMax[bbarmor, HeavyLasAmmo] = 30;			$ItemMax[bbfemale, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[bbarmor, EnergyPack] = 0;			$ItemMax[bbfemale, EnergyPack] = 0;			
$ItemMax[bbarmor, TurretPack] = 0;			$ItemMax[bbfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[bbarmor, RepairPack] = 1;			$ItemMax[bbfemale, RepairPack] = 1;			
$ItemMax[bbarmor, ShieldPack] = 1;			$ItemMax[bbfemale, ShieldPack] = 1;			
$ItemMax[bbarmor, SensorJammerPack] = 0;		$ItemMax[bbfemale, SensorJammerPack] = 0;			
$ItemMax[bbarmor, AmmoPack] = 1;			$ItemMax[bbfemale, AmmoPack] = 1;			
$ItemMax[bbarmor, CamoPack] = 0;			$ItemMax[bbfemale, CamoPack] = 0;			

//New Packs
$ItemMax[bbarmor, ExplosivePack] = 1;			$ItemMax[bbfemale, ExplosivePack] = 1;			
$ItemMax[bbarmor, SuicidePack] = 0;			$ItemMax[bbfemale, SuicidePack] = 0;			
$ItemMax[bbarmor, FuelPack] = 0;			$ItemMax[bbfemale, FuelPack] = 0;				
$ItemMax[bbarmor, SuspensorPack] = 1;			$ItemMax[bbfemale, SuspensorPack] = 1;			
$ItemMax[bbarmor, StoneBurnerPack] = 1;			$ItemMax[bbfemale, StoneBurnerPack] = 1;			
$ItemMax[bbarmor, SNukePack] = 1;			$ItemMax[bbfemale, SNukePack] = 1;			
$ItemMax[bbarmor, MNukePack] = 1;			$ItemMax[bbfemale, MNukePack] = 1;			
$ItemMax[bbarmor, LNukePack] = 1;			$ItemMax[bbfemale, LNukePack] = 1;			
$ItemMax[bbarmor, ThumperPack] = 0;			$ItemMax[bbfemale, ThumperPack] = 0;			

//Old deployable packs used	
$ItemMax[bbarmor, MotionSensorPack] = 0;		$ItemMax[bbfemale, MotionSensorPack] = 0;			
$ItemMax[bbarmor, PulseSensorPack] = 0;			$ItemMax[bbfemale, PulseSensorPack] = 0;			
$ItemMax[bbarmor, DeployableSensorJammerPack] = 0;	$ItemMax[bbfemale, DeployableSensorJammerPack] = 0;	
$ItemMax[bbarmor, CameraPack] = 0;			$ItemMax[bbfemale, CameraPack] = 0;			
$ItemMax[bbarmor, DeployableInvPack] = 0;		$ItemMax[bbfemale, DeployableInvPack] = 0;		
$ItemMax[bbarmor, DeployableAmmoPack] = 0;		$ItemMax[bbfemale, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[bbarmor, PlasteelPack] = 0;			$ItemMax[bbfemale, PlasteelPack] = 0;			
$ItemMax[bbarmor, LPentashieldPack] = 0;		$ItemMax[bbfemale, LPentashieldPack] = 0;			
$ItemMax[bbarmor, SPentashieldPack] = 0;		$ItemMax[bbfemale, SPentashieldPack] = 0;			
$ItemMax[bbarmor, DeployableGenPack] = 0;		$ItemMax[bbfemale, DeployableGenPack] = 0;		
$ItemMax[bbarmor, HieregPack] = 0;			$ItemMax[bbfemale, HieregPack] = 0;			
$ItemMax[bbarmor, StationaryLasgunPack] = 0;		$ItemMax[bbfemale, StationaryLasgunPack] = 0;		
$ItemMax[bbarmor, RepeaterLasgunPack] = 0;		$ItemMax[bbfemale, RepeaterLasgunPack] = 0;		
$ItemMax[bbarmor, RemoteLasgunPack] = 0;		$ItemMax[bbfemale, RemoteLasgunPack] = 0;			
$ItemMax[bbarmor, RemoteProjectileGunPack] = 0;		$ItemMax[bbfemale, RemoteProjectileGunPack] = 0;		
$ItemMax[bbarmor, HunterSeekerPlatformPack] = 0;	$ItemMax[bbfemale, HunterSeekerPlatformPack] = 0;		
$ItemMax[bbarmor, GholaPack] = 0;			$ItemMax[bbfemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[bbarmor, SniperRifle] = 0;			$ItemMax[bbfemale, SniperRifle] = 0;		
$ItemMax[bbarmor, MGun] = 0;				$ItemMax[bbfemale, MGun] = 0;		
$ItemMax[bbarmor, SniperAmmo] = 0;			$ItemMax[bbfemale, SniperAmmo] = 0;		
$ItemMax[bbarmor, MGunAmmo] = 0;			$ItemMax[bbfemale, MGunAmmo] = 0;		
$ItemMax[bbarmor, SniperClip] = 0;			$ItemMax[bbfemale, SniperClip] = 0;		
$ItemMax[bbarmor, MGunClip] = 0;			$ItemMax[bbfemale, MGunClip] = 0;		


$MaxWeapons[bbarmor] = 2;				$MaxWeapons[bbfemale] = 2;				

//----------------------------------------------------------------------------
// Sardaukar Armor***WITH SUSPENSORPACK ENABLED***
//----------------------------------------------------------------------------

$DamageScale[ssarmor2, $LandingDamageType] = 1.0;	$DamageScale[ssfemale2, $LandingDamageType] = 1.0;		
$DamageScale[ssarmor2, $ImpactDamageType] = 1.0;	$DamageScale[ssfemale2, $ImpactDamageType] = 1.0;		
$DamageScale[ssarmor2, $CrushDamageType] = 1.0;		$DamageScale[ssfemale2, $CrushDamageType] = 1.0;		
$DamageScale[ssarmor2, $BulletDamageType] = 0.8;	$DamageScale[ssfemale2, $BulletDamageType] = 0.8;		
$DamageScale[ssarmor2, $PlasmaDamageType] = 0.5;	$DamageScale[ssfemale2, $PlasmaDamageType] = 0.5;		
$DamageScale[ssarmor2, $EnergyDamageType] = 1.3;	$DamageScale[ssfemale2, $EnergyDamageType] = 1.3;		
$DamageScale[ssarmor2, $ExplosionDamageType] = 1.0;	$DamageScale[ssfemale2, $ExplosionDamageType] = 1.0;		
$DamageScale[ssarmor2, $MissileDamageType] = 1.0;	$DamageScale[ssfemale2, $MissileDamageType] = 1.0;		
$DamageScale[ssarmor2, $DebrisDamageType] = 1.0;	$DamageScale[ssfemale2, $DebrisDamageType] = 1.0;		
$DamageScale[ssarmor2, $ShrapnelDamageType] = 1.0;	$DamageScale[ssfemale2, $ShrapnelDamageType] = 1.0;		
$DamageScale[ssarmor2, $LaserDamageType] = 0.8;		$DamageScale[ssfemale2, $LaserDamageType] = 0.8;		
$DamageScale[ssarmor2, $MortarDamageType] = 1.3;	$DamageScale[ssfemale2, $MortarDamageType] = 1.3;		
$DamageScale[ssarmor2, $BlasterDamageType] = 1.3;	$DamageScale[ssfemale2, $BlasterDamageType] = 1.3;		
$DamageScale[ssarmor2, $ElectricityDamageType] = 1.0;	$DamageScale[ssfemale2, $ElectricityDamageType] = 1.0;		
$DamageScale[ssarmor2, $MineDamageType] = 1.0;		$DamageScale[ssfemale2, $MineDamageType] = 1.0;		
$DamageScale[ssarmor2, $StabDamageType] = 1.0;		$DamageScale[ssfemale2, $StabDamageType] = 1.0;		
$DamageScale[ssarmor2, $PoisonDamageType] = 1.0;	$DamageScale[ssfemale2, $PoisonDamageType] = 1.0;		
$DamageScale[ssarmor2, $StunnerDamageType] = 1.0;	$DamageScale[ssfemale2, $StunnerDamageType] = 1.0;		
$DamageScale[ssarmor2, $NukeDamageType] = 1.0;		$DamageScale[ssfemale2, $NukeDamageType] = 1.0;		
$DamageScale[ssarmor2, $Poison2DamageType] = 1.0;	$DamageScale[ssfemale2, $Poison2DamageType] = 1.0;		
$DamageScale[ssarmor2, $WormDamageType] = 1.0;		$DamageScale[ssfemale2, $WormDamageType] = 1.0;		
$DamageScale[ssarmor2, $CutterayDamageType] = 1.0;	$DamageScale[ssfemale2, $CutterayDamageType] = 1.0;		
$DamageScale[ssarmor2, $SmallLasDamageType] = 1.0;	$DamageScale[ssfemale2, $SmallLasDamageType] = 1.0;		
$DamageScale[ssarmor2, $RifleLasDamageType] = 1.0;	$DamageScale[ssfemale2, $RifleLasDamageType] = 1.0;		
$DamageScale[ssarmor2, $HeavyLasDamageType] = 1.0;	$DamageScale[ssfemale2, $HeavyLasDamageType] = 1.0;		
$DamageScale[ssarmor2, $AsphyxiationDamageType] = 1.0;	$DamageScale[ssfemale2, $AsphyxiationDamageType] = 1.0;		
$DamageScale[ssarmor2, $LargeBulletDamageType] = 1.0;	$DamageScale[ssfemale2, $LargeBulletDamageType] = 1.0;		
$DamageScale[ssarmor2, $ThrownWeaponDamageType] = 1.0;	$DamageScale[ssfemale2, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[ssarmor2, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[ssfemale2, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[ssarmor2, $AssassinDamageType] = 1.0;	$DamageScale[ssfemale2, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[ssarmor2, Blaster] = 0;			$ItemMax[ssfemale2, Blaster] = 0;				
$ItemMax[ssarmor2, Chaingun] = 0;			$ItemMax[ssfemale2, Chaingun] = 0;				
$ItemMax[ssarmor2, Disclauncher] = 0;			$ItemMax[ssfemale2, Disclauncher] = 0;			
$ItemMax[ssarmor2, GrenadeLauncher] = 0;		$ItemMax[ssfemale2, GrenadeLauncher] = 0;			
$ItemMax[ssarmor2, Mortar] = 0;				$ItemMax[ssfemale2, Mortar] = 0;				
$ItemMax[ssarmor2, PlasmaGun] = 0;			$ItemMax[ssfemale2, PlasmaGun] = 0;			
$ItemMax[ssarmor2, LaserRifle] = 0;			$ItemMax[ssfemale2, LaserRifle] = 0;			
$ItemMax[ssarmor2, EnergyRifle] = 0;			$ItemMax[ssfemale2, EnergyRifle] = 0;			
$ItemMax[ssarmor2, TargetingLaser] = 0;			$ItemMax[ssfemale2, TargetingLaser] = 0;			
$ItemMax[ssarmor2, MineAmmo] = 0;			$ItemMax[ssfemale2, MineAmmo] = 0;				
$ItemMax[ssarmor2, Grenade] = 0;			$ItemMax[ssfemale2, Grenade] = 0;				

//Blades
$ItemMax[ssarmor2, Knife]  = 1;				$ItemMax[ssfemale2, Knife]  = 1;				
$ItemMax[ssarmor2, Knife2]  = 1;			$ItemMax[ssfemale2, Knife2]  = 1;				
$ItemMax[ssarmor2, SlipTip]  = 1;			$ItemMax[ssfemale2, SlipTip]  = 1;			
$ItemMax[ssarmor2, Crysknife]  = 0;			$ItemMax[ssfemale2, Crysknife]  = 0;			
$ItemMax[ssarmor2, Kindjal]  = 1;			$ItemMax[ssfemale2, Kindjal]  = 1;				
$ItemMax[ssarmor2, Saber]  = 1;				$ItemMax[ssfemale2, Saber]  = 1;				

//Projectiles
$ItemMax[ssarmor2, Pistol]  = 1;			$ItemMax[ssfemale2, Pistol]  = 1;				
$ItemMax[ssarmor2, Maula]  = 1;				$ItemMax[ssfemale2, Maula]  = 1;				
$ItemMax[ssarmor2, Stunner]  = 1;			$ItemMax[ssfemale2, Stunner]  = 1;				
$ItemMax[ssarmor2, Rifle]  = 1;				$ItemMax[ssfemale2, Rifle]  = 1;				
$ItemMax[ssarmor2, Rifle2]  = 1;			$ItemMax[ssfemale2, Rifle2]  = 1;				
$ItemMax[ssarmor2, MGun]  = 1;				$ItemMax[ssfemale2, MGun]  = 1;				
$ItemMax[ssarmor2, RLauncher]  = 1;			$ItemMax[ssfemale2, RLauncher]  = 1;			
$ItemMax[ssarmor2, Flamethrower]  = 1;			$ItemMax[ssfemale2, Flamethrower]  = 1;			
$ItemMax[ssarmor2, Piller]  = 1;			$ItemMax[ssfemale2, Piller]  = 1;				

//Lasguns
$ItemMax[ssarmor2, Cutteray]  = 1;			$ItemMax[ssfemale2, Cutteray]  = 1;			
$ItemMax[ssarmor2, SmallLas]  = 1;			$ItemMax[ssfemale2, SmallLas]  = 1;			
$ItemMax[ssarmor2, RifleLas]  = 1;			$ItemMax[ssfemale2, RifleLas]  = 1;			
$ItemMax[ssarmor2, HeavyLas]  = 0;			$ItemMax[ssfemale2, HeavyLas]  = 0;			

//Items...
$ItemMax[ssarmor2, RepairKit] = 1;			$ItemMax[ssfemale2, RepairKit] = 1;			
$ItemMax[ssarmor2, Beacon]  = 3;			$ItemMax[ssfemale2, Beacon]  = 3;				

//Old ammos
$ItemMax[ssarmor2, BulletAmmo] = 0;			$ItemMax[ssfemale2, BulletAmmo] = 0;			
$ItemMax[ssarmor2, PlasmaAmmo] = 0;			$ItemMax[ssfemale2, PlasmaAmmo] = 0;			
$ItemMax[ssarmor2, DiscAmmo] = 0;			$ItemMax[ssfemale2, DiscAmmo] = 0;				
$ItemMax[ssarmor2, GrenadeAmmo] = 0;			$ItemMax[ssfemale2, GrenadeAmmo] = 0;			
$ItemMax[ssarmor2, MortarAmmo] = 0;			$ItemMax[ssfemale2, MortarAmmo] = 0;			

//Clips
$ItemMax[ssarmor2, PistolClip] = 3;			$ItemMax[ssfemale2, PistolClip] = 3;			
$ItemMax[ssarmor2, MaulaClip] = 2;			$ItemMax[ssfemale2, MaulaClip] = 2;			
$ItemMax[ssarmor2, StunnerClip] = 2;			$ItemMax[ssfemale2, StunnerClip] = 2;			
$ItemMax[ssarmor2, RifleClip] = 3;			$ItemMax[ssfemale2, RifleClip] = 3;			
$ItemMax[ssarmor2, MGunClip] = 4;			$ItemMax[ssfemale2, MGunClip] = 4;			
$ItemMax[ssarmor2, CutterayCell] = 3;			$ItemMax[ssfemale2, CutterayCell] = 3;			
$ItemMax[ssarmor2, SmallLasCell] = 3;			$ItemMax[ssfemale2, SmallLasCell] = 3;			
$ItemMax[ssarmor2, RifleLasCell] = 2;			$ItemMax[ssfemale2, RifleLasCell] = 2;			
$ItemMax[ssarmor2, HeavyLasCell] = 3;			$ItemMax[ssfemale2, HeavyLasCell] = 3;			
$ItemMax[ssarmor2, RLauncherClip] = 1;			$ItemMax[ssfemale2, RLauncherClip] = 1;			

//New ammos
$ItemMax[ssarmor2, PistolAmmo] = 12;			$ItemMax[ssfemale2, PistolAmmo] = 12;			
$ItemMax[ssarmor2, MaulaAmmo] = 5;			$ItemMax[ssfemale2, MaulaAmmo] = 5;			
$ItemMax[ssarmor2, StunnerAmmo] = 2;			$ItemMax[ssfemale2, StunnerAmmo] = 2;			
$ItemMax[ssarmor2, RifleAmmo] = 50;			$ItemMax[ssfemale2, RifleAmmo] = 50;			
$ItemMax[ssarmor2, MGunAmmo] = 75;			$ItemMax[ssfemale2, MGunAmmo] = 75;			
$ItemMax[ssarmor2, RLauncherAmmo] = 1;			$ItemMax[ssfemale2, RLauncherAmmo] = 1;			
$ItemMax[ssarmor2, FlamethrowerAmmo] = 100;		$ItemMax[ssfemale2, FlamethrowerAmmo] = 100;			
$ItemMax[ssarmor2, PillerAmmo] = 5;			$ItemMax[ssfemale2, PillerAmmo] = 5;			
$ItemMax[ssarmor2, CutterayAmmo] = 25;			$ItemMax[ssfemale2, CutterayAmmo] = 25;			
$ItemMax[ssarmor2, SmallLasAmmo] = 75;			$ItemMax[ssfemale2, SmallLasAmmo] = 75;			
$ItemMax[ssarmor2, RifleLasAmmo] = 75;			$ItemMax[ssfemale2, RifleLasAmmo] = 75;			
$ItemMax[ssarmor2, HeavyLasAmmo] = 30;			$ItemMax[ssfemale2, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[ssarmor2, EnergyPack] = 0;			$ItemMax[ssfemale2, EnergyPack] = 0;			
$ItemMax[ssarmor2, TurretPack] = 0;			$ItemMax[ssfemale2, TurretPack] = 0;			

//Old packs used
$ItemMax[ssarmor2, RepairPack] = 1;			$ItemMax[ssfemale2, RepairPack] = 1;			
$ItemMax[ssarmor2, ShieldPack] = 1;			$ItemMax[ssfemale2, ShieldPack] = 1;			
$ItemMax[ssarmor2, SensorJammerPack] = 0;		$ItemMax[ssfemale2, SensorJammerPack] = 0;			
$ItemMax[ssarmor2, AmmoPack] = 1;			$ItemMax[ssfemale2, AmmoPack] = 1;			
$ItemMax[ssarmor2, CamoPack] = 0;			$ItemMax[ssfemale2, CamoPack] = 0;			

//New Packs
$ItemMax[ssarmor2, ExplosivePack] = 1;			$ItemMax[ssfemale2, ExplosivePack] = 1;			
$ItemMax[ssarmor2, SuicidePack] = 1;			$ItemMax[ssfemale2, SuicidePack] = 1;			
$ItemMax[ssarmor2, FuelPack] = 1;			$ItemMax[ssfemale2, FuelPack] = 1;				
$ItemMax[ssarmor2, SuspensorPack] = 1;			$ItemMax[ssfemale2, SuspensorPack] = 1;			
$ItemMax[ssarmor2, StoneBurnerPack] = 1;		$ItemMax[ssfemale2, StoneBurnerPack] = 1;			
$ItemMax[ssarmor2, SNukePack] = 1;			$ItemMax[ssfemale2, SNukePack] = 1;			
$ItemMax[ssarmor2, MNukePack] = 1;			$ItemMax[ssfemale2, MNukePack] = 1;			
$ItemMax[ssarmor2, LNukePack] = 1;			$ItemMax[ssfemale2, LNukePack] = 1;			
$ItemMax[ssarmor2, ThumperPack] = 0;			$ItemMax[ssfemale2, ThumperPack] = 0;			

//Old deployable packs used
$ItemMax[ssarmor2, MotionSensorPack] = 0;		$ItemMax[ssfemale2, MotionSensorPack] = 0;			
$ItemMax[ssarmor2, PulseSensorPack] = 0;		$ItemMax[ssfemale2, PulseSensorPack] = 0;			
$ItemMax[ssarmor2, DeployableSensorJammerPack] = 0;	$ItemMax[ssfemale2, DeployableSensorJammerPack] = 0;	
$ItemMax[ssarmor2, CameraPack] = 0;			$ItemMax[ssfemale2, CameraPack] = 0;			
$ItemMax[ssarmor2, DeployableInvPack] = 0;		$ItemMax[ssfemale2, DeployableInvPack] = 0;		
$ItemMax[ssarmor2, DeployableAmmoPack] = 0;		$ItemMax[ssfemale2, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[ssarmor2, PlasteelPack] = 0;			$ItemMax[ssfemale2, PlasteelPack] = 0;			
$ItemMax[ssarmor2, LPentashieldPack] = 0;		$ItemMax[ssfemale2, LPentashieldPack] = 0;			
$ItemMax[ssarmor2, SPentashieldPack] = 0;		$ItemMax[ssfemale2, SPentashieldPack] = 0;			
$ItemMax[ssarmor2, DeployableGenPack] = 0;		$ItemMax[ssfemale2, DeployableGenPack] = 0;		
$ItemMax[ssarmor2, HieregPack] = 0;			$ItemMax[ssfemale2, HieregPack] = 0;			
$ItemMax[ssarmor2, StationaryLasgunPack] = 0;		$ItemMax[ssfemale2, StationaryLasgunPack] = 0;		
$ItemMax[ssarmor2, RepeaterLasgunPack] = 0;		$ItemMax[ssfemale2, RepeaterLasgunPack] = 0;		
$ItemMax[ssarmor2, RemoteLasgunPack] = 0;		$ItemMax[ssfemale2, RemoteLasgunPack] = 0;			
$ItemMax[ssarmor2, RemoteProjectileGunPack] = 0;	$ItemMax[ssfemale2, RemoteProjectileGunPack] = 0;		
$ItemMax[ssarmor2, HunterSeekerPlatformPack] = 1;	$ItemMax[ssfemale2, HunterSeekerPlatformPack] = 1;		
$ItemMax[ssarmor2, GholaPack] = 0;			$ItemMax[ssfemale2, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[ssarmor2, SniperRifle] = 0;			$ItemMax[ssfemale2, SniperRifle] = 0;		
$ItemMax[ssarmor2, SniperAmmo] = 0;			$ItemMax[ssfemale2, SniperAmmo] = 0;		
$ItemMax[ssarmor2, SniperClip] = 0;			$ItemMax[ssfemale2, SniperClip] = 0;		


$MaxWeapons[ssarmor2] = 4;				$MaxWeapons[ssfemale2] = 4;				

//----------------------------------------------------------------------------
// Bashar Armor***WITH SUSPENSOR PACK ENABLED***
//----------------------------------------------------------------------------

$DamageScale[barmor2, $LandingDamageType] = 1.0;	$DamageScale[bfemale2, $LandingDamageType] = 1.0;		
$DamageScale[barmor2, $ImpactDamageType] = 1.0;		$DamageScale[bfemale2, $ImpactDamageType] = 1.0;		
$DamageScale[barmor2, $CrushDamageType] = 1.0;		$DamageScale[bfemale2, $CrushDamageType] = 1.0;		
$DamageScale[barmor2, $BulletDamageType] = 0.8;		$DamageScale[bfemale2, $BulletDamageType] = 0.8;		
$DamageScale[barmor2, $PlasmaDamageType] = 0.5;		$DamageScale[bfemale2, $PlasmaDamageType] = 0.5;		
$DamageScale[barmor2, $EnergyDamageType] = 1.3;		$DamageScale[bfemale2, $EnergyDamageType] = 1.3;		
$DamageScale[barmor2, $ExplosionDamageType] = 1.0;	$DamageScale[bfemale2, $ExplosionDamageType] = 1.0;		
$DamageScale[barmor2, $MissileDamageType] = 1.0;	$DamageScale[bfemale2, $MissileDamageType] = 1.0;		
$DamageScale[barmor2, $DebrisDamageType] = 1.0;		$DamageScale[bfemale2, $DebrisDamageType] = 1.0;		
$DamageScale[barmor2, $ShrapnelDamageType] = 1.0;	$DamageScale[bfemale2, $ShrapnelDamageType] = 1.0;		
$DamageScale[barmor2, $LaserDamageType] = 0.8;		$DamageScale[bfemale2, $LaserDamageType] = 0.8;		
$DamageScale[barmor2, $MortarDamageType] = 1.3;		$DamageScale[bfemale2, $MortarDamageType] = 1.3;		
$DamageScale[barmor2, $BlasterDamageType] = 1.3;	$DamageScale[bfemale2, $BlasterDamageType] = 1.3;		
$DamageScale[barmor2, $ElectricityDamageType] = 1.0;	$DamageScale[bfemale2, $ElectricityDamageType] = 1.0;		
$DamageScale[barmor2, $MineDamageType] = 1.0;		$DamageScale[bfemale2, $MineDamageType] = 1.0;		
$DamageScale[barmor2, $StabDamageType] = 1.0;		$DamageScale[bfemale2, $StabDamageType] = 1.0;		
$DamageScale[barmor2, $PoisonDamageType] = 1.0;		$DamageScale[bfemale2, $PoisonDamageType] = 1.0;		
$DamageScale[barmor2, $StunnerDamageType] = 1.0;	$DamageScale[bfemale2, $StunnerDamageType] = 1.0;		
$DamageScale[barmor2, $NukeDamageType] = 1.0;		$DamageScale[bfemale2, $NukeDamageType] = 1.0;		
$DamageScale[barmor2, $Poison2DamageType] = 1.0;	$DamageScale[bfemale2, $Poison2DamageType] = 1.0;		
$DamageScale[barmor2, $WormDamageType] = 1.0;		$DamageScale[bfemale2, $WormDamageType] = 1.0;		
$DamageScale[barmor2, $CutterayDamageType] = 1.0;	$DamageScale[bfemale2, $CutterayDamageType] = 1.0;		
$DamageScale[barmor2, $SmallLasDamageType] = 1.0;	$DamageScale[bfemale2, $SmallLasDamageType] = 1.0;		
$DamageScale[barmor2, $RifleLasDamageType] = 1.0;	$DamageScale[bfemale2, $RifleLasDamageType] = 1.0;		
$DamageScale[barmor2, $HeavyLasDamageType] = 1.0;	$DamageScale[bfemale2, $HeavyLasDamageType] = 1.0;		
$DamageScale[barmor2, $AsphyxiationDamageType] = 1.0;	$DamageScale[bfemale2, $AsphyxiationDamageType] = 1.0;		
$DamageScale[barmor2, $LargeBulletDamageType] = 1.0;	$DamageScale[bfemale2, $LargeBulletDamageType] = 1.0;		
$DamageScale[barmor2, $ThrownWeaponDamageType] = 1.0;	$DamageScale[bfemale2, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[barmor2, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[bfemale2, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[barmor2, $AssassinDamageType] = 1.0;	$DamageScale[bfemale2, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[barmor2, Blaster] = 0;				$ItemMax[bfemale2, Blaster] = 0;				
$ItemMax[barmor2, Chaingun] = 0;			$ItemMax[bfemale2, Chaingun] = 0;				
$ItemMax[barmor2, Disclauncher] = 0;			$ItemMax[bfemale2, Disclauncher] = 0;			
$ItemMax[barmor2, GrenadeLauncher] = 0;			$ItemMax[bfemale2, GrenadeLauncher] = 0;			
$ItemMax[barmor2, Mortar] = 0;				$ItemMax[bfemale2, Mortar] = 0;				
$ItemMax[barmor2, PlasmaGun] = 0;			$ItemMax[bfemale2, PlasmaGun] = 0;			
$ItemMax[barmor2, LaserRifle] = 0;			$ItemMax[bfemale2, LaserRifle] = 0;			
$ItemMax[barmor2, EnergyRifle] = 0;			$ItemMax[bfemale2, EnergyRifle] = 0;			
$ItemMax[barmor2, TargetingLaser] = 0;			$ItemMax[bfemale2, TargetingLaser] = 0;			
$ItemMax[barmor2, MineAmmo] = 0;			$ItemMax[bfemale2, MineAmmo] = 0;				
$ItemMax[barmor2, Grenade] = 0;				$ItemMax[bfemale2, Grenade] = 0;				

//Blades
$ItemMax[barmor2, Knife]  = 1;				$ItemMax[bfemale2, Knife]  = 1;				
$ItemMax[barmor2, Knife2]  = 1;				$ItemMax[bfemale2, Knife2]  = 1;				
$ItemMax[barmor2, SlipTip]  = 1;			$ItemMax[bfemale2, SlipTip]  = 1;			
$ItemMax[barmor2, Crysknife]  = 0;			$ItemMax[bfemale2, Crysknife]  = 0;			
$ItemMax[barmor2, Kindjal]  = 1;			$ItemMax[bfemale2, Kindjal]  = 1;				
$ItemMax[barmor2, Saber]  = 1;				$ItemMax[bfemale2, Saber]  = 1;				

//Projectiles
$ItemMax[barmor2, Pistol]  = 1;				$ItemMax[bfemale2, Pistol]  = 1;				
$ItemMax[barmor2, Maula]  = 1;				$ItemMax[bfemale2, Maula]  = 1;				
$ItemMax[barmor2, Stunner]  = 1;			$ItemMax[bfemale2, Stunner]  = 1;				
$ItemMax[barmor2, Rifle]  = 1;				$ItemMax[bfemale2, Rifle]  = 1;					
$ItemMax[barmor2, Rifle2]  = 1;				$ItemMax[bfemale2, Rifle2]  = 1;				
$ItemMax[barmor2, RLauncher]  = 1;			$ItemMax[bfemale2, RLauncher]  = 1;			
$ItemMax[barmor2, Flamethrower]  = 0;			$ItemMax[bfemale2, Flamethrower]  = 0;			
$ItemMax[barmor2, Piller]  = 1;				$ItemMax[bfemale2, Piller]  = 1;				

//Lasguns
$ItemMax[barmor2, Cutteray]  = 1;			$ItemMax[bfemale2, Cutteray]  = 1;			
$ItemMax[barmor2, SmallLas]  = 1;			$ItemMax[bfemale2, SmallLas]  = 1;			
$ItemMax[barmor2, RifleLas]  = 1;			$ItemMax[bfemale2, RifleLas]  = 1;			
$ItemMax[barmor2, HeavyLas]  = 0;			$ItemMax[bfemale2, HeavyLas]  = 0;			

//Items...
$ItemMax[barmor2, RepairKit] = 1;			$ItemMax[bfemale2, RepairKit] = 1;			
$ItemMax[barmor2, Beacon]  = 3;				$ItemMax[bfemale2, Beacon]  = 3;				

//Old ammos
$ItemMax[barmor2, BulletAmmo] = 0;			$ItemMax[bfemale2, BulletAmmo] = 0;			
$ItemMax[barmor2, PlasmaAmmo] = 0;			$ItemMax[bfemale2, PlasmaAmmo] = 0;			
$ItemMax[barmor2, DiscAmmo] = 0;			$ItemMax[bfemale2, DiscAmmo] = 0;				
$ItemMax[barmor2, GrenadeAmmo] = 0;			$ItemMax[bfemale2, GrenadeAmmo] = 0;			
$ItemMax[barmor2, MortarAmmo] = 0;			$ItemMax[bfemale2, MortarAmmo] = 0;			

//Clips
$ItemMax[barmor2, PistolClip] = 3;			$ItemMax[bfemale2, PistolClip] = 3;			
$ItemMax[barmor2, MaulaClip] = 2;			$ItemMax[bfemale2, MaulaClip] = 2;			
$ItemMax[barmor2, StunnerClip] = 2;			$ItemMax[bfemale2, StunnerClip] = 2;			
$ItemMax[barmor2, RifleClip] = 3;			$ItemMax[bfemale2, RifleClip] = 3;			
$ItemMax[barmor2, CutterayCell] = 3;			$ItemMax[bfemale2, CutterayCell] = 3;			
$ItemMax[barmor2, SmallLasCell] = 3;			$ItemMax[bfemale2, SmallLasCell] = 3;			
$ItemMax[barmor2, RifleLasCell] = 2;			$ItemMax[bfemale2, RifleLasCell] = 2;			
$ItemMax[barmor2, HeavyLasCell] = 3;			$ItemMax[bfemale2, HeavyLasCell] = 3;			
$ItemMax[barmor2, RLauncherClip] = 1;			$ItemMax[bfemale2, RLauncherClip] = 1;			

//New ammos
$ItemMax[barmor2, PistolAmmo] = 12;			$ItemMax[bfemale2, PistolAmmo] = 12;			
$ItemMax[barmor2, MaulaAmmo] = 5;			$ItemMax[bfemale2, MaulaAmmo] = 5;			
$ItemMax[barmor2, StunnerAmmo] = 2;			$ItemMax[bfemale2, StunnerAmmo] = 2;			
$ItemMax[barmor2, RifleAmmo] = 50;			$ItemMax[bfemale2, RifleAmmo] = 50;			
$ItemMax[barmor2, RLauncherAmmo] = 1;			$ItemMax[bfemale2, RLauncherAmmo] = 1;			
$ItemMax[barmor2, FlamethrowerAmmo] = 100;		$ItemMax[bfemale2, FlamethrowerAmmo] = 100;			
$ItemMax[barmor2, PillerAmmo] = 5;			$ItemMax[bfemale2, PillerAmmo] = 5;			
$ItemMax[barmor2, CutterayAmmo] = 25;			$ItemMax[bfemale2, CutterayAmmo] = 25;			
$ItemMax[barmor2, SmallLasAmmo] = 75;			$ItemMax[bfemale2, SmallLasAmmo] = 75;			
$ItemMax[barmor2, RifleLasAmmo] = 75;			$ItemMax[bfemale2, RifleLasAmmo] = 75;			
$ItemMax[barmor2, HeavyLasAmmo] = 30;			$ItemMax[bfemale2, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[barmor2, EnergyPack] = 0;			$ItemMax[bfemale2, EnergyPack] = 0;			
$ItemMax[barmor2, TurretPack] = 0;			$ItemMax[bfemale2, TurretPack] = 0;			

//Old packs used
$ItemMax[barmor2, RepairPack] = 1;			$ItemMax[bfemale2, RepairPack] = 1;			
$ItemMax[barmor2, ShieldPack] = 1;			$ItemMax[bfemale2, ShieldPack] = 1;			
$ItemMax[barmor2, SensorJammerPack] = 0;		$ItemMax[bfemale2, SensorJammerPack] = 0;			
$ItemMax[barmor2, AmmoPack] = 1;			$ItemMax[bfemale2, AmmoPack] = 1;			

//New Packs
$ItemMax[barmor2, ExplosivePack] = 1;			$ItemMax[bfemale2, ExplosivePack] = 1;			
$ItemMax[barmor2, SuicidePack] = 1;			$ItemMax[bfemale2, SuicidePack] = 1;			
$ItemMax[barmor2, FuelPack] = 1;			$ItemMax[bfemale2, FuelPack] = 1;				
$ItemMax[barmor2, SuspensorPack] = 1;			$ItemMax[bfemale2, SuspensorPack] = 1;			
$ItemMax[barmor2, StoneBurnerPack] = 0;			$ItemMax[bfemale2, StoneBurnerPack] = 0;			
$ItemMax[barmor2, SNukePack] = 0;			$ItemMax[bfemale2, SNukePack] = 0;			
$ItemMax[barmor2, MNukePack] = 0;			$ItemMax[bfemale2, MNukePack] = 0;			
$ItemMax[barmor2, LNukePack] = 0;			$ItemMax[bfemale2, LNukePack] = 0;			
$ItemMax[barmor2, CamoPack] = 0;			$ItemMax[bfemale2, CamoPack] = 0;			
$ItemMax[barmor2, ThumperPack] = 0;			$ItemMax[bfemale2, ThumperPack] = 0;			

//Old deployable packs used	
$ItemMax[barmor2, MotionSensorPack] = 1;		$ItemMax[bfemale2, MotionSensorPack] = 1;			
$ItemMax[barmor2, PulseSensorPack] = 1;			$ItemMax[bfemale2, PulseSensorPack] = 1;			
$ItemMax[barmor2, DeployableSensorJammerPack] = 0;	$ItemMax[bfemale2, DeployableSensorJammerPack] = 0;	
$ItemMax[barmor2, CameraPack] = 1;			$ItemMax[bfemale2, CameraPack] = 1;			
$ItemMax[barmor2, DeployableInvPack] = 0;		$ItemMax[bfemale2, DeployableInvPack] = 0;		
$ItemMax[barmor2, DeployableAmmoPack] = 0;		$ItemMax[bfemale2, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[barmor2, PlasteelPack] = 1;			$ItemMax[bfemale2, PlasteelPack] = 1;			
$ItemMax[barmor2, LPentashieldPack] = 1;		$ItemMax[bfemale2, LPentashieldPack] = 1;			
$ItemMax[barmor2, SPentashieldPack] = 1;		$ItemMax[bfemale2, SPentashieldPack] = 1;			
$ItemMax[barmor2, DeployableGenPack] = 1;		$ItemMax[bfemale2, DeployableGenPack] = 1;		
$ItemMax[barmor2, HieregPack] = 0;			$ItemMax[bfemale2, HieregPack] = 0;			
$ItemMax[barmor2, StationaryLasgunPack] = 0;		$ItemMax[bfemale2, StationaryLasgunPack] = 0;		
$ItemMax[barmor2, RepeaterLasgunPack] = 0;		$ItemMax[bfemale2, RepeaterLasgunPack] = 0;		
$ItemMax[barmor2, RemoteLasgunPack] = 0;		$ItemMax[bfemale2, RemoteLasgunPack] = 0;			
$ItemMax[barmor2, RemoteProjectileGunPack] = 0;		$ItemMax[bfemale2, RemoteProjectileGunPack] = 0;		
$ItemMax[barmor2, HunterSeekerPlatformPack] = 1;	$ItemMax[bfemale2, HunterSeekerPlatformPack] = 1;
$ItemMax[barmor2, GholaPack] = 0;			$ItemMax[bfemale2, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[barmor2, SniperRifle] = 0;			$ItemMax[bfemale2, SniperRifle] = 0;		
$ItemMax[barmor2, MGun] = 0;				$ItemMax[bfemale2, MGun] = 0;		
$ItemMax[barmor2, SniperAmmo] = 0;			$ItemMax[bfemale2, SniperAmmo] = 0;		
$ItemMax[barmor2, MGunAmmo] = 0;			$ItemMax[bfemale2, MGunAmmo] = 0;		
$ItemMax[barmor2, SniperClip] = 0;			$ItemMax[bfemale2, SniperClip] = 0;		
$ItemMax[barmor2, MGunClip] = 0;			$ItemMax[bfemale2, MGunClip] = 0;		


$MaxWeapons[barmor2] = 3;				$MaxWeapons[bfemale2] = 3;				

//----------------------------------------------------------------------------
// Burseg Armor***WITH SUSPENSOR PACK ENABLED***
//----------------------------------------------------------------------------

$DamageScale[bbarmor2, $LandingDamageType] = 1.0;	$DamageScale[bbfemale2, $LandingDamageType] = 1.0;		
$DamageScale[bbarmor2, $ImpactDamageType] = 1.0;	$DamageScale[bbfemale2, $ImpactDamageType] = 1.0;		
$DamageScale[bbarmor2, $CrushDamageType] = 1.0;		$DamageScale[bbfemale2, $CrushDamageType] = 1.0;		
$DamageScale[bbarmor2, $BulletDamageType] = 0.8;	$DamageScale[bbfemale2, $BulletDamageType] = 0.8;		
$DamageScale[bbarmor2, $PlasmaDamageType] = 0.5;	$DamageScale[bbfemale2, $PlasmaDamageType] = 0.5;		
$DamageScale[bbarmor2, $EnergyDamageType] = 1.3;	$DamageScale[bbfemale2, $EnergyDamageType] = 1.3;		
$DamageScale[bbarmor2, $ExplosionDamageType] = 1.0;	$DamageScale[bbfemale2, $ExplosionDamageType] = 1.0;		
$DamageScale[bbarmor2, $MissileDamageType] = 1.0;	$DamageScale[bbfemale2, $MissileDamageType] = 1.0;		
$DamageScale[bbarmor2, $DebrisDamageType] = 1.0;	$DamageScale[bbfemale2, $DebrisDamageType] = 1.0;		
$DamageScale[bbarmor2, $ShrapnelDamageType] = 1.0;	$DamageScale[bbfemale2, $ShrapnelDamageType] = 1.0;		
$DamageScale[bbarmor2, $LaserDamageType] = 0.8;		$DamageScale[bbfemale2, $LaserDamageType] = 0.8;		
$DamageScale[bbarmor2, $MortarDamageType] = 1.3;	$DamageScale[bbfemale2, $MortarDamageType] = 1.3;		
$DamageScale[bbarmor2, $BlasterDamageType] = 1.3;	$DamageScale[bbfemale2, $BlasterDamageType] = 1.3;		
$DamageScale[bbarmor2, $ElectricityDamageType] = 1.0;	$DamageScale[bbfemale2, $ElectricityDamageType] = 1.0;		
$DamageScale[bbarmor2, $MineDamageType] = 1.0;		$DamageScale[bbfemale2, $MineDamageType] = 1.0;		
$DamageScale[bbarmor2, $StabDamageType] = 1.0;		$DamageScale[bbfemale2, $StabDamageType] = 1.0;		
$DamageScale[bbarmor2, $PoisonDamageType] = 1.0;	$DamageScale[bbfemale2, $PoisonDamageType] = 1.0;		
$DamageScale[bbarmor2, $StunnerDamageType] = 1.0;	$DamageScale[bbfemale2, $StunnerDamageType] = 1.0;		
$DamageScale[bbarmor2, $NukeDamageType] = 1.0;		$DamageScale[bbfemale2, $NukeDamageType] = 1.0;		
$DamageScale[bbarmor2, $Poison2DamageType] = 1.0;	$DamageScale[bbfemale2, $Poison2DamageType] = 1.0;		
$DamageScale[bbarmor2, $WormDamageType] = 1.0;		$DamageScale[bbfemale2, $WormDamageType] = 1.0;		
$DamageScale[bbarmor2, $CutterayDamageType] = 1.0;	$DamageScale[bbfemale2, $CutterayDamageType] = 1.0;		
$DamageScale[bbarmor2, $SmallLasDamageType] = 1.0;	$DamageScale[bbfemale2, $SmallLasDamageType] = 1.0;		
$DamageScale[bbarmor2, $RifleLasDamageType] = 1.0;	$DamageScale[bbfemale2, $RifleLasDamageType] = 1.0;		
$DamageScale[bbarmor2, $HeavyLasDamageType] = 1.0;	$DamageScale[bbfemale2, $HeavyLasDamageType] = 1.0;		
$DamageScale[bbarmor2, $AsphyxiationDamageType] = 1.0;	$DamageScale[bbfemale2, $AsphyxiationDamageType] = 1.0;		
$DamageScale[bbarmor2, $LargeBulletDamageType] = 1.0;	$DamageScale[bbfemale2, $LargeBulletDamageType] = 1.0;		
$DamageScale[bbarmor2, $ThrownWeaponDamageType] = 1.0;	$DamageScale[bbfemale2, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[bbarmor2, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[bbfemale2, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[bbarmor2, $AssassinDamageType] = 1.0;	$DamageScale[bbfemale2, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[bbarmor2, Blaster] = 0;			$ItemMax[bbfemale2, Blaster] = 0;				
$ItemMax[bbarmor2, Chaingun] = 0;			$ItemMax[bbfemale2, Chaingun] = 0;				
$ItemMax[bbarmor2, Disclauncher] = 0;			$ItemMax[bbfemale2, Disclauncher] = 0;			
$ItemMax[bbarmor2, GrenadeLauncher] = 0;		$ItemMax[bbfemale2, GrenadeLauncher] = 0;			
$ItemMax[bbarmor2, Mortar] = 0;				$ItemMax[bbfemale2, Mortar] = 0;				
$ItemMax[bbarmor2, PlasmaGun] = 0;			$ItemMax[bbfemale2, PlasmaGun] = 0;			
$ItemMax[bbarmor2, LaserRifle] = 0;			$ItemMax[bbfemale2, LaserRifle] = 0;			
$ItemMax[bbarmor2, EnergyRifle] = 0;			$ItemMax[bbfemale2, EnergyRifle] = 0;			
$ItemMax[bbarmor2, TargetingLaser] = 0;			$ItemMax[bbfemale2, TargetingLaser] = 0;			
$ItemMax[bbarmor2, MineAmmo] = 0;			$ItemMax[bbfemale2, MineAmmo] = 0;				
$ItemMax[bbarmor2, Grenade] = 0;			$ItemMax[bbfemale2, Grenade] = 0;				

//Blades
$ItemMax[bbarmor2, Knife]  = 1;				$ItemMax[bbfemale2, Knife]  = 1;				
$ItemMax[bbarmor2, Knife2]  = 1;			$ItemMax[bbfemale2, Knife2]  = 1;				
$ItemMax[bbarmor2, SlipTip]  = 1;			$ItemMax[bbfemale2, SlipTip]  = 1;			
$ItemMax[bbarmor2, Crysknife]  = 0;			$ItemMax[bbfemale2, Crysknife]  = 0;			
$ItemMax[bbarmor2, Kindjal]  = 1;			$ItemMax[bbfemale2, Kindjal]  = 1;				
$ItemMax[bbarmor2, Saber]  = 1;				$ItemMax[bbfemale2, Saber]  = 1;				

//Projectiles
$ItemMax[bbarmor2, Pistol]  = 1;			$ItemMax[bbfemale2, Pistol]  = 1;				
$ItemMax[bbarmor2, Maula]  = 1;				$ItemMax[bbfemale2, Maula]  = 1;				
$ItemMax[bbarmor2, Stunner]  = 1;			$ItemMax[bbfemale2, Stunner]  = 1;				
$ItemMax[bbarmor2, Rifle]  = 1;				$ItemMax[bbfemale2, Rifle]  = 1;				
$ItemMax[bbarmor2, Rifle2]  = 1;			$ItemMax[bbfemale2, Rifle2]  = 1;				
$ItemMax[bbarmor2, RLauncher]  = 0;			$ItemMax[bbfemale2, RLauncher]  = 0;			
$ItemMax[bbarmor2, Flamethrower]  = 0;			$ItemMax[bbfemale2, Flamethrower]  = 0;			
$ItemMax[bbarmor2, Piller]  = 0;			$ItemMax[bbfemale2, Piller]  = 0;				

//Lasguns
$ItemMax[bbarmor2, Cutteray]  = 1;			$ItemMax[bbfemale2, Cutteray]  = 1;			
$ItemMax[bbarmor2, SmallLas]  = 1;			$ItemMax[bbfemale2, SmallLas]  = 1;			
$ItemMax[bbarmor2, RifleLas]  = 1;			$ItemMax[bbfemale2, RifleLas]  = 1;			
$ItemMax[bbarmor2, HeavyLas]  = 0;			$ItemMax[bbfemale2, HeavyLas]  = 0;			

//Items...
$ItemMax[bbarmor2, RepairKit] = 1;			$ItemMax[bbfemale2, RepairKit] = 1;			
$ItemMax[bbarmor2, Beacon]  = 3;			$ItemMax[bbfemale2, Beacon]  = 3;				

//Old ammos
$ItemMax[bbarmor2, BulletAmmo] = 0;			$ItemMax[bbfemale2, BulletAmmo] = 0;			
$ItemMax[bbarmor2, PlasmaAmmo] = 0;			$ItemMax[bbfemale2, PlasmaAmmo] = 0;			
$ItemMax[bbarmor2, DiscAmmo] = 0;			$ItemMax[bbfemale2, DiscAmmo] = 0;				
$ItemMax[bbarmor2, GrenadeAmmo] = 0;			$ItemMax[bbfemale2, GrenadeAmmo] = 0;			
$ItemMax[bbarmor2, MortarAmmo] = 0;			$ItemMax[bbfemale2, MortarAmmo] = 0;			

//Clips
$ItemMax[bbarmor2, PistolClip] = 3;			$ItemMax[bbfemale2, PistolClip] = 3;			
$ItemMax[bbarmor2, MaulaClip] = 2;			$ItemMax[bbfemale2, MaulaClip] = 2;			
$ItemMax[bbarmor2, StunnerClip] = 2;			$ItemMax[bbfemale2, StunnerClip] = 2;			
$ItemMax[bbarmor2, RifleClip] = 3;			$ItemMax[bbfemale2, RifleClip] = 3;			
$ItemMax[bbarmor2, CutterayCell] = 3;			$ItemMax[bbfemale2, CutterayCell] = 3;			
$ItemMax[bbarmor2, SmallLasCell] = 3;			$ItemMax[bbfemale2, SmallLasCell] = 3;			
$ItemMax[bbarmor2, RifleLasCell] = 2;			$ItemMax[bbfemale2, RifleLasCell] = 2;			
$ItemMax[bbarmor2, HeavyLasCell] = 3;			$ItemMax[bbfemale2, HeavyLasCell] = 3;			
$ItemMax[bbarmor2, RLauncherClip] = 1;			$ItemMax[bbfemale2, RLauncherClip] = 1;			

//New ammos
$ItemMax[bbarmor2, PistolAmmo] = 12;			$ItemMax[bbfemale2, PistolAmmo] = 12;			
$ItemMax[bbarmor2, MaulaAmmo] = 5;			$ItemMax[bbfemale2, MaulaAmmo] = 5;			
$ItemMax[bbarmor2, StunnerAmmo] = 2;			$ItemMax[bbfemale2, StunnerAmmo] = 2;			
$ItemMax[bbarmor2, RifleAmmo] = 50;			$ItemMax[bbfemale2, RifleAmmo] = 50;			
$ItemMax[bbarmor2, RLauncherAmmo] = 1;			$ItemMax[bbfemale2, RLauncherAmmo] = 1;			
$ItemMax[bbarmor2, FlamethrowerAmmo] = 100;		$ItemMax[bbfemale2, FlamethrowerAmmo] = 100;			
$ItemMax[bbarmor2, PillerAmmo] = 5;			$ItemMax[bbfemale2, PillerAmmo] = 5;			
$ItemMax[bbarmor2, CutterayAmmo] = 25;			$ItemMax[bbfemale2, CutterayAmmo] = 25;			
$ItemMax[bbarmor2, SmallLasAmmo] = 75;			$ItemMax[bbfemale2, SmallLasAmmo] = 75;			
$ItemMax[bbarmor2, RifleLasAmmo] = 75;			$ItemMax[bbfemale2, RifleLasAmmo] = 75;			
$ItemMax[bbarmor2, HeavyLasAmmo] = 30;			$ItemMax[bbfemale2, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[bbarmor2, EnergyPack] = 0;			$ItemMax[bbfemale2, EnergyPack] = 0;			
$ItemMax[bbarmor2, TurretPack] = 0;			$ItemMax[bbfemale2, TurretPack] = 0;			

//Old packs used
$ItemMax[bbarmor2, RepairPack] = 1;			$ItemMax[bbfemale2, RepairPack] = 1;			
$ItemMax[bbarmor2, ShieldPack] = 1;			$ItemMax[bbfemale2, ShieldPack] = 1;			
$ItemMax[bbarmor2, SensorJammerPack] = 0;		$ItemMax[bbfemale2, SensorJammerPack] = 0;			
$ItemMax[bbarmor2, AmmoPack] = 1;			$ItemMax[bbfemale2, AmmoPack] = 1;			

//New Packs
$ItemMax[bbarmor2, ExplosivePack] = 1;			$ItemMax[bbfemale2, ExplosivePack] = 1;			
$ItemMax[bbarmor2, SuicidePack] = 0;			$ItemMax[bbfemale2, SuicidePack] = 0;			
$ItemMax[bbarmor2, FuelPack] = 0;			$ItemMax[bbfemale2, FuelPack] = 0;				
$ItemMax[bbarmor2, SuspensorPack] = 1;			$ItemMax[bbfemale2, SuspensorPack] = 1;			
$ItemMax[bbarmor2, StoneBurnerPack] = 1;		$ItemMax[bbfemale2, StoneBurnerPack] = 1;			
$ItemMax[bbarmor2, SNukePack] = 1;			$ItemMax[bbfemale2, SNukePack] = 1;			
$ItemMax[bbarmor2, MNukePack] = 1;			$ItemMax[bbfemale2, MNukePack] = 1;			
$ItemMax[bbarmor2, LNukePack] = 1;			$ItemMax[bbfemale2, LNukePack] = 1;			
$ItemMax[bbarmor2, CamoPack] = 0;			$ItemMax[bbfemale2, CamoPack] = 0;			
$ItemMax[bbarmor2, ThumperPack] = 0;			$ItemMax[bbfemale2, ThumperPack] = 0;			

//Old deployable packs used	
$ItemMax[bbarmor2, MotionSensorPack] = 0;		$ItemMax[bbfemale2, MotionSensorPack] = 0;			
$ItemMax[bbarmor2, PulseSensorPack] = 0;		$ItemMax[bbfemale2, PulseSensorPack] = 0;			
$ItemMax[bbarmor2, DeployableSensorJammerPack] = 0;	$ItemMax[bbfemale2, DeployableSensorJammerPack] = 0;	
$ItemMax[bbarmor2, CameraPack] = 0;			$ItemMax[bbfemale2, CameraPack] = 0;			
$ItemMax[bbarmor2, DeployableInvPack] = 0;		$ItemMax[bbfemale2, DeployableInvPack] = 0;		
$ItemMax[bbarmor2, DeployableAmmoPack] = 0;		$ItemMax[bbfemale2, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[bbarmor2, PlasteelPack] = 0;			$ItemMax[bbfemale2, PlasteelPack] = 0;			
$ItemMax[bbarmor2, LPentashieldPack] = 0;		$ItemMax[bbfemale2, LPentashieldPack] = 0;			
$ItemMax[bbarmor2, SPentashieldPack] = 0;		$ItemMax[bbfemale2, SPentashieldPack] = 0;			
$ItemMax[bbarmor2, DeployableGenPack] = 0;		$ItemMax[bbfemale2, DeployableGenPack] = 0;		
$ItemMax[bbarmor2, HieregPack] = 0;			$ItemMax[bbfemale2, HieregPack] = 0;			
$ItemMax[bbarmor2, StationaryLasgunPack] = 0;		$ItemMax[bbfemale2, StationaryLasgunPack] = 0;		
$ItemMax[bbarmor2, RepeaterLasgunPack] = 0;		$ItemMax[bbfemale2, RepeaterLasgunPack] = 0;		
$ItemMax[bbarmor2, RemoteLasgunPack] = 0;		$ItemMax[bbfemale2, RemoteLasgunPack] = 0;			
$ItemMax[bbarmor2, RemoteProjectileGunPack] = 0;	$ItemMax[bbfemale2, RemoteProjectileGunPack] = 0;		
$ItemMax[bbarmor2, HunterSeekerPlatformPack] = 0;	$ItemMax[bbfemale2, HunterSeekerPlatformPack] = 0;		
$ItemMax[bbarmor2, GholaPack] = 0;			$ItemMax[bbfemale2, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[bbarmor2, SniperRifle] = 0;			$ItemMax[bbfemale2, SniperRifle] = 0;		
$ItemMax[bbarmor2, MGun] = 0;				$ItemMax[bbfemale2, MGun] = 0;		
$ItemMax[bbarmor2, SniperAmmo] = 0;			$ItemMax[bbfemale2, SniperAmmo] = 0;		
$ItemMax[bbarmor2, MGunAmmo] = 0;			$ItemMax[bbfemale2, MGunAmmo] = 0;		
$ItemMax[bbarmor2, SniperClip] = 0;			$ItemMax[bbfemale2, SniperClip] = 0;		
$ItemMax[bbarmor2, MGunClip] = 0;			$ItemMax[bbfemale2, MGunClip] = 0;		


$MaxWeapons[bbarmor2] = 2;				$MaxWeapons[bbfemale2] = 2;				


//----------------------------------------------------------------------------
// Soldier Armor***WITH SUSPENSOR PACK ENABLED***
//----------------------------------------------------------------------------

$DamageScale[sarmor2, $LandingDamageType] = 1.0;	$DamageScale[sfemale2, $LandingDamageType] = 1.0;		
$DamageScale[sarmor2, $ImpactDamageType] = 1.0;		$DamageScale[sfemale2, $ImpactDamageType] = 1.0;		
$DamageScale[sarmor2, $CrushDamageType] = 1.0;		$DamageScale[sfemale2, $CrushDamageType] = 1.0;		
$DamageScale[sarmor2, $BulletDamageType] = 1.2;		$DamageScale[sfemale2, $BulletDamageType] = 1.2;		
$DamageScale[sarmor2, $PlasmaDamageType] = 1.2;		$DamageScale[sfemale2, $PlasmaDamageType] = 1.2;		
$DamageScale[sarmor2, $EnergyDamageType] = 1.3;		$DamageScale[sfemale2, $EnergyDamageType] = 1.3;		
$DamageScale[sarmor2, $ExplosionDamageType] = 1.0;	$DamageScale[sfemale2, $ExplosionDamageType] = 1.0;		
$DamageScale[sarmor2, $MissileDamageType] = 1.0;	$DamageScale[sfemale2, $MissileDamageType] = 1.0;		
$DamageScale[sarmor2, $DebrisDamageType] = 1.2;		$DamageScale[sfemale2, $DebrisDamageType] = 1.2;		
$DamageScale[sarmor2, $ShrapnelDamageType] = 1.2;	$DamageScale[sfemale2, $ShrapnelDamageType] = 1.2;		
$DamageScale[sarmor2, $LaserDamageType] = 1.2;		$DamageScale[sfemale2, $LaserDamageType] = 1.2;		
$DamageScale[sarmor2, $MortarDamageType] = 1.3;		$DamageScale[sfemale2, $MortarDamageType] = 1.3;		
$DamageScale[sarmor2, $BlasterDamageType] = 1.3;	$DamageScale[sfemale2, $BlasterDamageType] = 1.3;		
$DamageScale[sarmor2, $ElectricityDamageType] = 1.0;	$DamageScale[sfemale2, $ElectricityDamageType] = 1.0;		
$DamageScale[sarmor2, $MineDamageType] = 1.2;		$DamageScale[sfemale2, $MineDamageType] = 1.2;		
$DamageScale[sarmor2, $StabDamageType] = 1.0;		$DamageScale[sfemale2, $StabDamageType] = 1.0;		
$DamageScale[sarmor2, $PoisonDamageType] = 1.0;		$DamageScale[sfemale2, $PoisonDamageType] = 1.0;		
$DamageScale[sarmor2, $StunnerDamageType] = 1.0;	$DamageScale[sfemale2, $StunnerDamageType] = 1.0;		
$DamageScale[sarmor2, $NukeDamageType] = 1.0;		$DamageScale[sfemale2, $NukeDamageType] = 1.0;		
$DamageScale[sarmor2, $Poison2DamageType] = 1.0;	$DamageScale[sfemale2, $Poison2DamageType] = 1.0;		
$DamageScale[sarmor2, $WormDamageType] = 1.0;		$DamageScale[sfemale2, $WormDamageType] = 1.0;		
$DamageScale[sarmor2, $CutterayDamageType] = 1.2;	$DamageScale[sfemale2, $CutterayDamageType] = 1.2;		
$DamageScale[sarmor2, $SmallLasDamageType] = 1.2;	$DamageScale[sfemale2, $SmallLasDamageType] = 1.2;		
$DamageScale[sarmor2, $RifleLasDamageType] = 1.2;	$DamageScale[sfemale2, $RifleLasDamageType] = 1.2;		
$DamageScale[sarmor2, $HeavyLasDamageType] = 1.2;	$DamageScale[sfemale2, $HeavyLasDamageType] = 1.2;		
$DamageScale[sarmor2, $AsphyxiationDamageType] = 1.0;	$DamageScale[sfemale2, $AsphyxiationDamageType] = 1.0;		
$DamageScale[sarmor2, $LargeBulletDamageType] = 1.2;	$DamageScale[sfemale2, $LargeBulletDamageType] = 1.2;		
$DamageScale[sarmor2, $ThrownWeaponDamageType] = 1.0;	$DamageScale[sfemale2, $ThrownWeaponDamageType] = 1.0;	
$DamageScale[sarmor2, $ThrownPoisonWeaponDamageType] = 1.0;	$DamageScale[sfemale2, $ThrownPoisonWeaponDamageType] = 1.0;	
$DamageScale[sarmor2, $AssassinDamageType] = 1.0;	$DamageScale[sfemale2, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[sarmor2, Blaster] = 0;				$ItemMax[sfemale2, Blaster] = 0;				
$ItemMax[sarmor2, Chaingun] = 0;			$ItemMax[sfemale2, Chaingun] = 0;				
$ItemMax[sarmor2, Disclauncher] = 0;			$ItemMax[sfemale2, Disclauncher] = 0;			
$ItemMax[sarmor2, GrenadeLauncher] = 0;			$ItemMax[sfemale2, GrenadeLauncher] = 0;			
$ItemMax[sarmor2, Mortar] = 0;				$ItemMax[sfemale2, Mortar] = 0;				
$ItemMax[sarmor2, PlasmaGun] = 0;			$ItemMax[sfemale2, PlasmaGun] = 0;			
$ItemMax[sarmor2, LaserRifle] = 0;			$ItemMax[sfemale2, LaserRifle] = 0;			
$ItemMax[sarmor2, EnergyRifle] = 0;			$ItemMax[sfemale2, EnergyRifle] = 0;			
$ItemMax[sarmor2, TargetingLaser] = 0;			$ItemMax[sfemale2, TargetingLaser] = 0;			
$ItemMax[sarmor2, MineAmmo] = 0;			$ItemMax[sfemale2, MineAmmo] = 0;				
$ItemMax[sarmor2, Grenade] = 0;				$ItemMax[sfemale2, Grenade] = 0;				

//Blades
$ItemMax[sarmor2, Knife]  = 1;				$ItemMax[sfemale2, Knife]  = 1;				
$ItemMax[sarmor2, Knife2]  = 1;				$ItemMax[sfemale2, Knife2]  = 1;				
$ItemMax[sarmor2, SlipTip]  = 1;			$ItemMax[sfemale2, SlipTip]  = 1;			
$ItemMax[sarmor2, Crysknife]  = 0;			$ItemMax[sfemale2, Crysknife]  = 0;			
$ItemMax[sarmor2, Kindjal]  = 0;			$ItemMax[sfemale2, Kindjal]  = 0;				
$ItemMax[sarmor2, Saber]  = 0;				$ItemMax[sfemale2, Saber]  = 0;				

//Projectiles
$ItemMax[sarmor2, Pistol]  = 1;				$ItemMax[sfemale2, Pistol]  = 1;				
$ItemMax[sarmor2, Maula]  = 1;				$ItemMax[sfemale2, Maula]  = 1;				
$ItemMax[sarmor2, Stunner]  = 1;			$ItemMax[sfemale2, Stunner]  = 1;				
$ItemMax[sarmor2, Rifle]  = 1;				$ItemMax[sfemale2, Rifle]  = 1;					
$ItemMax[sarmor2, Rifle2]  = 1;				$ItemMax[sfemale2, Rifle2]  = 1;				
$ItemMax[sarmor2, MGun]  = 0;				$ItemMax[sfemale2, MGun]  = 0;
$ItemMax[sarmor2, SniperRifle]  = 0;			$ItemMax[sfemale2, SniperRifle]  = 0;								
$ItemMax[sarmor2, RLauncher]  = 1;			$ItemMax[sfemale2, RLauncher]  = 1;			
$ItemMax[sarmor2, Flamethrower]  = 0;			$ItemMax[sfemale2, Flamethrower]  = 0;			
$ItemMax[sarmor2, Piller]  = 1;				$ItemMax[sfemale2, Piller]  = 1;				

//Lasguns
$ItemMax[sarmor2, Cutteray]  = 1;			$ItemMax[sfemale2, Cutteray]  = 1;			
$ItemMax[sarmor2, SmallLas]  = 1;			$ItemMax[sfemale2, SmallLas]  = 1;			
$ItemMax[sarmor2, RifleLas]  = 1;			$ItemMax[sfemale2, RifleLas]  = 1;			
$ItemMax[sarmor2, HeavyLas]  = 1;			$ItemMax[sfemale2, HeavyLas]  = 1;			

//Items...
$ItemMax[sarmor2, RepairKit] = 1;			$ItemMax[sfemale2, RepairKit] = 1;			
$ItemMax[sarmor2, Beacon]  = 3;				$ItemMax[sfemale2, Beacon]  = 3;				

//Old ammos
$ItemMax[sarmor2, BulletAmmo] = 0;			$ItemMax[sfemale2, BulletAmmo] = 0;			
$ItemMax[sarmor2, PlasmaAmmo] = 0;			$ItemMax[sfemale2, PlasmaAmmo] = 0;			
$ItemMax[sarmor2, DiscAmmo] = 0;			$ItemMax[sfemale2, DiscAmmo] = 0;				
$ItemMax[sarmor2, GrenadeAmmo] = 0;			$ItemMax[sfemale2, GrenadeAmmo] = 0;			
$ItemMax[sarmor2, MortarAmmo] = 0;			$ItemMax[sfemale2, MortarAmmo] = 0;			

//Clips
$ItemMax[sarmor2, PistolClip] = 3;			$ItemMax[sfemale2, PistolClip] = 3;			
$ItemMax[sarmor2, MaulaClip] = 2;			$ItemMax[sfemale2, MaulaClip] = 2;			
$ItemMax[sarmor2, StunnerClip] = 2;			$ItemMax[sfemale2, StunnerClip] = 2;			
$ItemMax[sarmor2, RifleClip] = 3;			$ItemMax[sfemale2, RifleClip] = 3;			
$ItemMax[sarmor2, SniperClip] = 0;			$ItemMax[sfemale2, SniperClip] = 0;			
$ItemMax[sarmor2, MGunClip] = 0;			$ItemMax[sfemale2, MGunClip] = 0;			
$ItemMax[sarmor2, CutterayCell] = 3;			$ItemMax[sfemale2, CutterayCell] = 3;			
$ItemMax[sarmor2, SmallLasCell] = 3;			$ItemMax[sfemale2, SmallLasCell] = 3;			
$ItemMax[sarmor2, RifleLasCell] = 2;			$ItemMax[sfemale2, RifleLasCell] = 2;			
$ItemMax[sarmor2, HeavyLasCell] = 3;			$ItemMax[sfemale2, HeavyLasCell] = 3;			
$ItemMax[sarmor2, RLauncherClip] = 0;			$ItemMax[sfemale2, RLauncherClip] = 0;			

//New ammos
$ItemMax[sarmor2, PistolAmmo] = 12;			$ItemMax[sfemale2, PistolAmmo] = 12;			
$ItemMax[sarmor2, MaulaAmmo] = 5;			$ItemMax[sfemale2, MaulaAmmo] = 5;			
$ItemMax[sarmor2, StunnerAmmo] = 2;			$ItemMax[sfemale2, StunnerAmmo] = 2;			
$ItemMax[sarmor2, RifleAmmo] = 50;			$ItemMax[sfemale2, RifleAmmo] = 50;			
$ItemMax[sarmor2, MGunAmmo] = 0;			$ItemMax[sfemale2, MGunAmmo] = 0;			
$ItemMax[sarmor2, SniperAmmo] = 0;			$ItemMax[sfemale2, SniperAmmo] = 0;			
$ItemMax[sarmor2, RLauncherAmmo] = 1;			$ItemMax[sfemale2, RLauncherAmmo] = 1;			
$ItemMax[sarmor2, FlamethrowerAmmo] = 0;		$ItemMax[sfemale2, FlamethrowerAmmo] = 0;			
$ItemMax[sarmor2, PillerAmmo] = 3;			$ItemMax[sfemale2, PillerAmmo] = 3;			
$ItemMax[sarmor2, CutterayAmmo] = 25;			$ItemMax[sfemale2, CutterayAmmo] = 25;			
$ItemMax[sarmor2, SmallLasAmmo] = 75;			$ItemMax[sfemale2, SmallLasAmmo] = 75;			
$ItemMax[sarmor2, RifleLasAmmo] = 75;			$ItemMax[sfemale2, RifleLasAmmo] = 75;			
$ItemMax[sarmor2, HeavyLasAmmo] = 30;			$ItemMax[sfemale2, HeavyLasAmmo] = 30;			

//Old packs not used
$ItemMax[sarmor2, EnergyPack] = 0;			$ItemMax[sfemale2, EnergyPack] = 0;			
$ItemMax[sarmor2, TurretPack] = 0;			$ItemMax[sfemale2, TurretPack] = 0;			

//Old packs used
$ItemMax[sarmor2, RepairPack] = 1;			$ItemMax[sfemale2, RepairPack] = 1;			
$ItemMax[sarmor2, ShieldPack] = 1;			$ItemMax[sfemale2, ShieldPack] = 1;			
$ItemMax[sarmor2, SensorJammerPack] = 1;		$ItemMax[sfemale2, SensorJammerPack] = 1;			
$ItemMax[sarmor2, AmmoPack] = 1;			$ItemMax[sfemale2, AmmoPack] = 1;			

//New Packs
$ItemMax[sarmor2, ExplosivePack] = 1;			$ItemMax[sfemale2, ExplosivePack] = 1;			
$ItemMax[sarmor2, SuicidePack] = 1;			$ItemMax[sfemale2, SuicidePack] = 1;			
$ItemMax[sarmor2, FuelPack] = 1;			$ItemMax[sfemale2, FuelPack] = 1;				
$ItemMax[sarmor2, SuspensorPack] = 1;			$ItemMax[sfemale2, SuspensorPack] = 1;			
$ItemMax[sarmor2, StoneBurnerPack] = 1;			$ItemMax[sfemale2, StoneBurnerPack] = 1;			
$ItemMax[sarmor2, SNukePack] = 1;			$ItemMax[sfemale2, SNukePack] = 1;			
$ItemMax[sarmor2, MNukePack] = 1;			$ItemMax[sfemale2, MNukePack] = 1;			
$ItemMax[sarmor2, LNukePack] = 1;			$ItemMax[sfemale2, LNukePack] = 1;			
$ItemMax[sarmor2, CamoPack] = 0;			$ItemMax[sfemale2, CamoPack] = 0;			
$ItemMax[sarmor2, ThumperPack] = 1;			$ItemMax[sfemale2, ThumperPack] = 1;			

//Old deployable packs used
$ItemMax[sarmor2, MotionSensorPack] = 1;		$ItemMax[sfemale2, MotionSensorPack] = 1;			
$ItemMax[sarmor2, PulseSensorPack] = 1;			$ItemMax[sfemale2, PulseSensorPack] = 1;			
$ItemMax[sarmor2, DeployableSensorJammerPack] = 1;	$ItemMax[sfemale2, DeployableSensorJammerPack] = 1;	
$ItemMax[sarmor2, CameraPack] = 1;			$ItemMax[sfemale2, CameraPack] = 1;			
$ItemMax[sarmor2, DeployableInvPack] = 1;		$ItemMax[sfemale2, DeployableInvPack] = 1;		
$ItemMax[sarmor2, DeployableAmmoPack] = 1;		$ItemMax[sfemale2, DeployableAmmoPack] = 1;		

//New deployable packs used
$ItemMax[sarmor2, PlasteelPack] = 1;			$ItemMax[sfemale2, PlasteelPack] = 1;			
$ItemMax[sarmor2, LPentashieldPack] = 1;		$ItemMax[sfemale2, LPentashieldPack] = 1;			
$ItemMax[sarmor2, SPentashieldPack] = 1;		$ItemMax[sfemale2, SPentashieldPack] = 1;			
$ItemMax[sarmor2, DeployableGenPack] = 1;		$ItemMax[sfemale2, DeployableGenPack] = 1;		
$ItemMax[sarmor2, HieregPack] = 0;			$ItemMax[sfemale2, HieregPack] = 0;			
$ItemMax[sarmor2, StationaryLasgunPack] = 1;		$ItemMax[sfemale2, StationaryLasgunPack] = 1;		
$ItemMax[sarmor2, RepeaterLasgunPack] = 0;		$ItemMax[sfemale2, RepeaterLasgunPack] = 0;		
$ItemMax[sarmor2, RemoteLasgunPack] = 1;		$ItemMax[sfemale2, RemoteLasgunPack] = 1;			
$ItemMax[sarmor2, RemoteProjectileGunPack] = 1;		$ItemMax[sfemale2, RemoteProjectileGunPack] = 1;		
$ItemMax[sarmor2, HunterSeekerPlatformPack] = 1;	$ItemMax[sfemale2, HunterSeekerPlatformPack] = 1;		
$ItemMax[sarmor2, GholaPack] = 1;			$ItemMax[sfemale2, GholaPack] = 1;		

$MaxWeapons[sarmor2] = 3;				$MaxWeapons[sfemale2] = 3;




//----------------------------------------------------------------------------
// Face Dancer Armor
//----------------------------------------------------------------------------

$DamageScale[fdarmor, $LandingDamageType] = 1.0;	$DamageScale[fdfemale, $LandingDamageType] = 1.0;		
$DamageScale[fdarmor, $ImpactDamageType] = 1.0;		$DamageScale[fdfemale, $ImpactDamageType] = 1.0;		
$DamageScale[fdarmor, $CrushDamageType] = 1.0;		$DamageScale[fdfemale, $CrushDamageType] = 1.0;		
$DamageScale[fdarmor, $BulletDamageType] = 1.0;		$DamageScale[fdfemale, $BulletDamageType] = 1.0;		
$DamageScale[fdarmor, $PlasmaDamageType] = 1.0;		$DamageScale[fdfemale, $PlasmaDamageType] = 1.0;		
$DamageScale[fdarmor, $EnergyDamageType] = 1.3;		$DamageScale[fdfemale, $EnergyDamageType] = 1.3;		
$DamageScale[fdarmor, $ExplosionDamageType] = 1.0;	$DamageScale[fdfemale, $ExplosionDamageType] = 1.0;		
$DamageScale[fdarmor, $MissileDamageType] = 1.0;	$DamageScale[fdfemale, $MissileDamageType] = 1.0;		
$DamageScale[fdarmor, $DebrisDamageType] = 1.0;		$DamageScale[fdfemale, $DebrisDamageType] = 1.0;		
$DamageScale[fdarmor, $ShrapnelDamageType] = 1.0;	$DamageScale[fdfemale, $ShrapnelDamageType] = 1.0;		
$DamageScale[fdarmor, $LaserDamageType] = 1.0;		$DamageScale[fdfemale, $LaserDamageType] = 1.0;		
$DamageScale[fdarmor, $MortarDamageType] = 1.3;		$DamageScale[fdfemale, $MortarDamageType] = 1.3;		
$DamageScale[fdarmor, $BlasterDamageType] = 1.3;	$DamageScale[fdfemale, $BlasterDamageType] = 1.3;		
$DamageScale[fdarmor, $ElectricityDamageType] = 1.0;	$DamageScale[fdfemale, $ElectricityDamageType] = 1.0;		
$DamageScale[fdarmor, $MineDamageType] = 1.0;		$DamageScale[fdfemale, $MineDamageType] = 1.0;		
$DamageScale[fdarmor, $StabDamageType] = 0.8;		$DamageScale[fdfemale, $StabDamageType] = 0.8;		
$DamageScale[fdarmor, $PoisonDamageType] = 0.5;		$DamageScale[fdfemale, $PoisonDamageType] = 0.5;		
$DamageScale[fdarmor, $StunnerDamageType] = 1.0;	$DamageScale[fdfemale, $StunnerDamageType] = 1.0;		
$DamageScale[fdarmor, $NukeDamageType] = 1.0;		$DamageScale[fdfemale, $NukeDamageType] = 1.0;		
$DamageScale[fdarmor, $Poison2DamageType] = 0.5;	$DamageScale[fdfemale, $Poison2DamageType] = 0.5;		
$DamageScale[fdarmor, $WormDamageType] = 1.0;		$DamageScale[fdfemale, $WormDamageType] = 1.0;		
$DamageScale[fdarmor, $CutterayDamageType] = 1.0;	$DamageScale[fdfemale, $CutterayDamageType] = 1.0;		
$DamageScale[fdarmor, $SmallLasDamageType] = 1.0;	$DamageScale[fdfemale, $SmallLasDamageType] = 1.0;		
$DamageScale[fdarmor, $RifleLasDamageType] = 1.0;	$DamageScale[fdfemale, $RifleLasDamageType] = 1.0;		
$DamageScale[fdarmor, $HeavyLasDamageType] = 1.0;	$DamageScale[fdfemale, $HeavyLasDamageType] = 1.0;		
$DamageScale[fdarmor, $AsphyxiationDamageType] = 1.0;	$DamageScale[fdfemale, $AsphyxiationDamageType] = 1.0;		
$DamageScale[fdarmor, $LargeBulletDamageType] = 1.0;	$DamageScale[fdfemale, $LargeBulletDamageType] = 1.0;		
$DamageScale[fdarmor, $ThrownWeaponDamageType] = 0.8;	$DamageScale[fdfemale, $ThrownWeaponDamageType] = 0.8;	
$DamageScale[fdarmor, $ThrownPoisonWeaponDamageType] = 0.5;	$DamageScale[fdfemale, $ThrownPoisonWeaponDamageType] = 0.5;
$DamageScale[fdarmor, $AssassinDamageType] = 1.0;	$DamageScale[fdfemale, $AssassinDamageType] = 1.0;		

//Old ones
$ItemMax[fdarmor, Blaster] = 0;				$ItemMax[fdfemale, Blaster] = 0;				
$ItemMax[fdarmor, Chaingun] = 0;			$ItemMax[fdfemale, Chaingun] = 0;				
$ItemMax[fdarmor, Disclauncher] = 0;			$ItemMax[fdfemale, Disclauncher] = 0;			
$ItemMax[fdarmor, GrenadeLauncher] = 0;			$ItemMax[fdfemale, GrenadeLauncher] = 0;			
$ItemMax[fdarmor, Mortar] = 0;				$ItemMax[fdfemale, Mortar] = 0;				
$ItemMax[fdarmor, PlasmaGun] = 0;			$ItemMax[fdfemale, PlasmaGun] = 0;			
$ItemMax[fdarmor, LaserRifle] = 0;			$ItemMax[fdfemale, LaserRifle] = 0;			
$ItemMax[fdarmor, EnergyRifle] = 0;			$ItemMax[fdfemale, EnergyRifle] = 0;			
$ItemMax[fdarmor, TargetingLaser] = 0;			$ItemMax[fdfemale, TargetingLaser] = 0;			
$ItemMax[fdarmor, MineAmmo] = 0;			$ItemMax[fdfemale, MineAmmo] = 0;				
$ItemMax[fdarmor, Grenade] = 0;				$ItemMax[fdfemale, Grenade] = 0;				

//Blades
$ItemMax[fdarmor, Knife]  = 1;				$ItemMax[fdfemale, Knife]  = 1;				
$ItemMax[fdarmor, Knife2]  = 1;				$ItemMax[fdfemale, Knife2]  = 1;				
$ItemMax[fdarmor, SlipTip]  = 1;			$ItemMax[fdfemale, SlipTip]  = 1;			
$ItemMax[fdarmor, Crysknife]  = 0;			$ItemMax[fdfemale, Crysknife]  = 0;			
$ItemMax[fdarmor, Kindjal]  = 0;			$ItemMax[fdfemale, Kindjal]  = 0;				
$ItemMax[fdarmor, Saber]  = 0;				$ItemMax[fdfemale, Saber]  = 0;				

//Projectiles
$ItemMax[fdarmor, Pistol]  = 1;				$ItemMax[fdfemale, Pistol]  = 1;				
$ItemMax[fdarmor, Maula]  = 1;				$ItemMax[fdfemale, Maula]  = 1;				
$ItemMax[fdarmor, Stunner]  = 0;			$ItemMax[fdfemale, Stunner]  = 0;				
$ItemMax[fdarmor, Rifle]  = 0;				$ItemMax[fdfemale, Rifle]  = 0;					
$ItemMax[fdarmor, Rifle2]  = 0;				$ItemMax[fdfemale, Rifle2]  = 0;				
$ItemMax[fdarmor, SniperRifle]  = 0;			$ItemMax[fdfemale, SniperRifle]  = 0;				
$ItemMax[fdarmor, RLauncher]  = 0;			$ItemMax[fdfemale, RLauncher]  = 0;			
$ItemMax[fdarmor, Flamethrower]  = 0;			$ItemMax[fdfemale, Flamethrower]  = 0;			
$ItemMax[fdarmor, Piller]  = 0;				$ItemMax[fdfemale, Piller]  = 0;				

//Lasguns
$ItemMax[fdarmor, Cutteray]  = 1;			$ItemMax[fdfemale, Cutteray]  = 1;			
$ItemMax[fdarmor, SmallLas]  = 0;			$ItemMax[fdfemale, SmallLas]  = 0;			
$ItemMax[fdarmor, RifleLas]  = 0;			$ItemMax[fdfemale, RifleLas]  = 0;			
$ItemMax[fdarmor, HeavyLas]  = 0;			$ItemMax[fdfemale, HeavyLas]  = 0;			

//Items...
$ItemMax[fdarmor, RepairKit] = 1;			$ItemMax[fdfemale, RepairKit] = 1;			
$ItemMax[fdarmor, Beacon]  = 3;				$ItemMax[fdfemale, Beacon]  = 3;				

//Old ammos
$ItemMax[fdarmor, BulletAmmo] = 0;			$ItemMax[fdfemale, BulletAmmo] = 0;			
$ItemMax[fdarmor, PlasmaAmmo] = 0;			$ItemMax[fdfemale, PlasmaAmmo] = 0;			
$ItemMax[fdarmor, DiscAmmo] = 0;			$ItemMax[fdfemale, DiscAmmo] = 0;				
$ItemMax[fdarmor, GrenadeAmmo] = 0;			$ItemMax[fdfemale, GrenadeAmmo] = 0;			
$ItemMax[fdarmor, MortarAmmo] = 0;			$ItemMax[fdfemale, MortarAmmo] = 0;			

//Clips
$ItemMax[fdarmor, PistolClip] = 3;			$ItemMax[fdfemale, PistolClip] = 3;			
$ItemMax[fdarmor, MaulaClip] = 2;			$ItemMax[fdfemale, MaulaClip] = 2;			
$ItemMax[fdarmor, StunnerClip] = 2;			$ItemMax[fdfemale, StunnerClip] = 2;			
$ItemMax[fdarmor, RifleClip] = 3;			$ItemMax[fdfemale, RifleClip] = 3;			
$ItemMax[fdarmor, SniperClip] = 4;			$ItemMax[fdfemale, SniperClip] = 4;			
$ItemMax[fdarmor, CutterayCell] = 3;			$ItemMax[fdfemale, CutterayCell] = 3;			
$ItemMax[fdarmor, SmallLasCell] = 3;			$ItemMax[fdfemale, SmallLasCell] = 3;			
$ItemMax[fdarmor, RifleLasCell] = 2;			$ItemMax[fdfemale, RifleLasCell] = 2;			
$ItemMax[fdarmor, HeavyLasCell] = 3;			$ItemMax[fdfemale, HeavyLasCell] = 3;			
$ItemMax[fdarmor, RLauncherClip] = 0;			$ItemMax[fdfemale, RLauncherClip] = 0;			

//New ammos
$ItemMax[fdarmor, PistolAmmo] = 12;			$ItemMax[fdfemale, PistolAmmo] = 12;			
$ItemMax[fdarmor, MaulaAmmo] = 5;			$ItemMax[fdfemale, MaulaAmmo] = 5;			
$ItemMax[fdarmor, StunnerAmmo] = 2;			$ItemMax[fdfemale, StunnerAmmo] = 2;			
$ItemMax[fdarmor, RifleAmmo] = 50;			$ItemMax[fdfemale, RifleAmmo] = 50;			
$ItemMax[fdarmor, SniperAmmo] = 3;			$ItemMax[fdfemale, SniperAmmo] = 3;			
$ItemMax[fdarmor, RLauncherAmmo] = 0;			$ItemMax[fdfemale, RLauncherAmmo] = 0;			
$ItemMax[fdarmor, FlamethrowerAmmo] = 0;		$ItemMax[fdfemale, FlamethrowerAmmo] = 0;			
$ItemMax[fdarmor, PillerAmmo] = 0;			$ItemMax[fdfemale, PillerAmmo] = 0;			
$ItemMax[fdarmor, CutterayAmmo] = 25;			$ItemMax[fdfemale, CutterayAmmo] = 25;			
$ItemMax[fdarmor, SmallLasAmmo] = 75;			$ItemMax[fdfemale, SmallLasAmmo] = 75;			
$ItemMax[fdarmor, RifleLasAmmo] = 75;			$ItemMax[fdfemale, RifleLasAmmo] = 75;			
$ItemMax[fdarmor, HeavyLasAmmo] = 30;			$ItemMax[fdfemale, HeavyLasAmmo] = 30;		

//Old packs not used
$ItemMax[fdarmor, EnergyPack] = 0;			$ItemMax[fdfemale, EnergyPack] = 0;			
$ItemMax[fdarmor, TurretPack] = 0;			$ItemMax[fdfemale, TurretPack] = 0;			

//Old packs used
$ItemMax[fdarmor, RepairPack] = 0;			$ItemMax[fdfemale, RepairPack] = 1;			
$ItemMax[fdarmor, ShieldPack] = 0;			$ItemMax[fdfemale, ShieldPack] = 0;			
$ItemMax[fdarmor, SensorJammerPack] = 1;		$ItemMax[fdfemale, SensorJammerPack] = 1;			
$ItemMax[fdarmor, AmmoPack] = 0;			$ItemMax[fdfemale, AmmoPack] = 1;			

//New Packs
$ItemMax[fdarmor, ExplosivePack] = 0;			$ItemMax[fdfemale, ExplosivePack] = 0;			
$ItemMax[fdarmor, SuicidePack] = 1;			$ItemMax[fdfemale, SuicidePack] = 1;			
$ItemMax[fdarmor, FuelPack] = 0;			$ItemMax[fdfemale, FuelPack] = 0;				
$ItemMax[fdarmor, SuspensorPack] = 0;			$ItemMax[fdfemale, SuspensorPack] = 0;			
$ItemMax[fdarmor, StoneBurnerPack] = 0;			$ItemMax[fdfemale, StoneBurnerPack] = 0;			
$ItemMax[fdarmor, SNukePack] = 0;			$ItemMax[fdfemale, SNukePack] = 0;			
$ItemMax[fdarmor, MNukePack] = 0;			$ItemMax[fdfemale, MNukePack] = 0;			
$ItemMax[fdarmor, LNukePack] = 0;			$ItemMax[fdfemale, LNukePack] = 0;			
$ItemMax[fdarmor, CamoPack] = 0;			$ItemMax[fdfemale, CamoPack] = 0;			
$ItemMax[fdarmor, ThumperPack] = 0;			$ItemMax[fdfemale, ThumperPack] = 0;			

//Old deployable packs used
$ItemMax[fdarmor, MotionSensorPack] = 0;		$ItemMax[fdfemale, MotionSensorPack] = 0;			
$ItemMax[fdarmor, PulseSensorPack] = 0;			$ItemMax[fdfemale, PulseSensorPack] = 0;			
$ItemMax[fdarmor, DeployableSensorJammerPack] = 0;	$ItemMax[fdfemale, DeployableSensorJammerPack] = 0;	
$ItemMax[fdarmor, CameraPack] = 0;			$ItemMax[fdfemale, CameraPack] = 0;			
$ItemMax[fdarmor, DeployableInvPack] = 0;		$ItemMax[fdfemale, DeployableInvPack] = 0;		
$ItemMax[fdarmor, DeployableAmmoPack] = 0;		$ItemMax[fdfemale, DeployableAmmoPack] = 0;		

//New deployable packs used
$ItemMax[fdarmor, PlasteelPack] = 0;			$ItemMax[fdfemale, PlasteelPack] = 0;			
$ItemMax[fdarmor, LPentashieldPack] = 0;		$ItemMax[fdfemale, LPentashieldPack] = 0;			
$ItemMax[fdarmor, SPentashieldPack] = 0;		$ItemMax[fdfemale, SPentashieldPack] = 0;			
$ItemMax[fdarmor, DeployableGenPack] = 0;		$ItemMax[fdfemale, DeployableGenPack] = 0;		
$ItemMax[fdarmor, HieregPack] = 0;			$ItemMax[fdfemale, HieregPack] = 0;			
$ItemMax[fdarmor, StationaryLasgunPack] = 0;		$ItemMax[fdfemale, StationaryLasgunPack] = 0;		
$ItemMax[fdarmor, RepeaterLasgunPack] = 0;		$ItemMax[fdfemale, RepeaterLasgunPack] = 0;		
$ItemMax[fdarmor, RemoteLasgunPack] = 0;		$ItemMax[fdfemale, RemoteLasgunPack] = 0;			
$ItemMax[fdarmor, RemoteProjectileGunPack] = 0;		$ItemMax[fdfemale, RemoteProjectileGunPack] = 0;		
$ItemMax[fdarmor, HunterSeekerPlatformPack] = 0;	$ItemMax[fdfemale, HunterSeekerPlatformPack] = 0;		
$ItemMax[fdarmor, GholaPack] = 0;			$ItemMax[fdfemale, GholaPack] = 0;		

// Me to lazy to put them in proper places
$ItemMax[fdarmor, MGun] = 0;				$ItemMax[fdfemale, MGun] = 0;		
$ItemMax[fdarmor, MGunAmmo] = 0;			$IftemMax[ffemale, MGunAmmo] = 0;		
$ItemMax[fdarmor, MGunClip] = 0;			$IftemMax[ffemale, MGunClip] = 0;		

$MaxWeapons[fdarmor] = 2;				$MaxWeapons[fdfemale] = 2;				


// Really lazy				
$ItemMax[sarmor, Rapier]  = 1;				$ItemMax[sfemale, Rapier]  = 1;	
$ItemMax[sarmor2, Rapier]  = 1;				$ItemMax[sfemale2, Rapier]  = 1;	
$ItemMax[tarmor, Rapier]  = 1;				$ItemMax[tfemale, Rapier]  = 1;	
$ItemMax[farmor, Rapier]  = 0;				$ItemMax[ffemale, Rapier]  = 0;	
$ItemMax[ffarmor, Rapier]  = 0;				$ItemMax[fffemale, Rapier]  = 0;	
$ItemMax[fdarmor, Rapier]  = 1;				$ItemMax[fdfemale, Rapier]  = 1;	
$ItemMax[ssarmor, Rapier]  = 1;				$ItemMax[ssfemale, Rapier]  = 1;	
$ItemMax[ssarmor2, Rapier]  = 1;			$ItemMax[ssfemale2, Rapier]  = 1;	
$ItemMax[barmor, Rapier]  = 1;				$ItemMax[bfemale, Rapier]  = 1;	
$ItemMax[barmor2, Rapier]  = 1;				$ItemMax[bfemale2, Rapier]  = 1;	
$ItemMax[bbarmor, Rapier]  = 1;				$ItemMax[bbfemale, Rapier]  = 1;	
$ItemMax[bbarmor2, Rapier]  = 1;			$ItemMax[bbfemale2, Rapier]  = 1;	

$ItemMax[sarmor, GrapplePack]  = 0;			$ItemMax[sfemale, GrapplePack]    = 0;	
$ItemMax[sarmor2, GrapplePack]  = 0;			$ItemMax[sfemale2, GrapplePack]    = 0;	
$ItemMax[tarmor, GrapplePack]  = 0;			$ItemMax[tfemale, GrapplePack]    = 0;	
$ItemMax[farmor, GrapplePack]  = 0;			$ItemMax[ffemale, GrapplePack]    = 0;	
$ItemMax[ffarmor, GrapplePack]  = 0;			$ItemMax[fffemale, GrapplePack]    = 0;	
$ItemMax[fdarmor, GrapplePack]    = 1;			$ItemMax[fdfemale, GrapplePack]    = 1;	
$ItemMax[ssarmor, GrapplePack]    = 0;			$ItemMax[ssfemale, GrapplePack]    = 0;	
$ItemMax[ssarmor2, GrapplePack]    = 0;			$ItemMax[ssfemale2, GrapplePack]    = 0;	
$ItemMax[barmor, GrapplePack]    = 0;			$ItemMax[bfemale, GrapplePack]    = 0;	
$ItemMax[barmor2, GrapplePack]    = 0;			$ItemMax[bfemale2, GrapplePack]    = 0;	
$ItemMax[bbarmor, GrapplePack]    = 0;			$ItemMax[bbfemale, GrapplePack]    = 0;	
$ItemMax[bbarmor2, GrapplePack]    = 0;			$ItemMax[bbfemale2, GrapplePack]    = 0;	

//------------------------------------------------------------------
// Soldier data:
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
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;//81;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 6;
   maxSideSpeed = 9;
   groundForce = 400;//40 * 9.0;
   mass = 4.5;
   groundTraction = 0.8;//0.5; // 3 // Anything over 1 is about the same. 
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpImpulse = 37.2;
   jumpsurfacemindot = 0.55;//2 //This is what angle of incline they can still jump on. The lower the number, the steepper the incline they can jump on.

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };
   
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

   jetSound = SoundlFootRSoft;
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


//------------------------------------------------------------------
// Soldier female data:
//------------------------------------------------------------------

PlayerData sfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
   //damageSkinData = "armorDamageSkinsTest";

	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 6;
   maxSideSpeed = 9;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
  // animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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


   jetSound = SoundLFootRSoft;

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

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Soldier ***With suspensor enabled***data:
//------------------------------------------------------------------

PlayerData sarmor2
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 150;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 6;
   maxSideSpeed = 9;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };
   
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

   jetSound = SoundlFootRSoft;
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


//------------------------------------------------------------------
// Soldier female ***With suspensor enabled***data:
//------------------------------------------------------------------

PlayerData sfemale2
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
   //damageSkinData = "armorDamageSkinsTest";

	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 150;
   jetEnergyDrain = 0.0;

	maxDamage = 0.66;
   maxForwardSpeed = 11;
   maxBackwardSpeed = 6;
   maxSideSpeed = 9;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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


   jetSound = SoundLFootRSoft;

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

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};

//------------------------------------------------------------------
// Trooper Armor data:
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
   validateShape = false;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;//81;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.2;
   maxForwardSpeed = 7.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 600;
   mass = 6.5;
   groundtraction = 0.666;
	
	maxEnergy = 1.0;//80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
  // animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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
// Trooper female data:
//------------------------------------------------------------------

PlayerData tfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

   canCrouch = false;
	maxDamage = 1.2;
   maxForwardSpeed = 7.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   mass = 6.5;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
  // animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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


//------------------------------------------------------------------
// Fremen data:
//------------------------------------------------------------------

PlayerData farmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.88;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 17;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundlFootRSoft;
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


//------------------------------------------------------------------
// Fremen female data:
//------------------------------------------------------------------

PlayerData ffemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.88;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 17;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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


   jetSound = SoundLFootRSoft;

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

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};




//------------------------------------------------------------------
// Fedaykin data:
//------------------------------------------------------------------

PlayerData ffarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.9;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 17;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundlFootRSoft;
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


//------------------------------------------------------------------
// Fedaykin female data:
//------------------------------------------------------------------

PlayerData fffemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.9;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 17;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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


   jetSound = SoundLFootRSoft;

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

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


//------------------------------------------------------------------
// Sardaukar Armor data:
//------------------------------------------------------------------

PlayerData ssarmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.2;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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
// Sardaukar female data:
//------------------------------------------------------------------

PlayerData ssfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

   canCrouch = false;
	maxDamage = 1.2;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   mass = 6.5;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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


//------------------------------------------------------------------
// Sardaukar Armor data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData ssarmor2
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 135;
   jetEnergyDrain = 0.0;

	maxDamage = 1.2;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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
// Sardaukar female data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData ssfemale2
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 135;
   jetEnergyDrain = 0.0;

   canCrouch = false;
	maxDamage = 1.2;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 6.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 80;
   mass = 6.5;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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


//------------------------------------------------------------------
// Bashar Armor data:
//------------------------------------------------------------------

PlayerData barmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 5.0;
   maxSideSpeed = 8.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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
// Bashar female data:
//------------------------------------------------------------------

PlayerData bfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 5.0;
   maxSideSpeed = 8.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   mass = 6.5;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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


//------------------------------------------------------------------
// Bashar Armor data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData barmor2
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 145;
   jetEnergyDrain = 0.0;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 5.0;
   maxSideSpeed = 8.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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
// Bashar female data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData bfemale2
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 145;
   jetEnergyDrain = 0.0;

   canCrouch = false;
	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 5.0;
   maxSideSpeed = 8.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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

//------------------------------------------------------------------
// Burseg Armor data:
//------------------------------------------------------------------

PlayerData bbarmor
{
   className = "Armor";
   shapeFile = "larmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.9;
   maxForwardSpeed = 11.0;
   maxBackwardSpeed = 6.0;
   maxSideSpeed = 9.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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
// Burseg female data:
//------------------------------------------------------------------

PlayerData bbfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

   canCrouch = true;
	maxDamage = 0.9;
   maxForwardSpeed = 11.0;
   maxBackwardSpeed = 6.0;
   maxSideSpeed = 9.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   mass = 6.5;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundMFootRSoft;

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


//------------------------------------------------------------------
// Burseg Armor data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData bbarmor2
{
   className = "Armor";
   shapeFile = "larmor";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   canCrouch = true;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 150;
   jetEnergyDrain = 0.0;

	maxDamage = 0.9;
   maxForwardSpeed = 11.0;
   maxBackwardSpeed = 6.0;
   maxSideSpeed = 9.0;
   groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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
// Burseg female data****WITH SUSPENSOR PACK ENABLED****:
//------------------------------------------------------------------

PlayerData bbfemale2
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "mflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 12;
   minJetEnergy = 79;
   jetForce = 150;
   jetEnergyDrain = 0.0;

   canCrouch = true;
	maxDamage = 0.9;
   maxForwardSpeed = 11.0;
   maxBackwardSpeed = 6.0;
   maxSideSpeed = 9.0;
   groundForce = 500;
   mass = 6.5;
  groundForce = 500;
   mass = 6.5;
   groundtraction = 0.8;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 55;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundGeneratorPower;

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


//------------------------------------------------------------------
// Face Dancer data:
//------------------------------------------------------------------

PlayerData fdarmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.88;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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

   jetSound = SoundlFootRSoft;
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

//------------------------------------------------------------------
// Face Dancer female data:
//------------------------------------------------------------------

PlayerData fdfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "lflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 0.88;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 7;
   maxSideSpeed = 12;
   groundForce = 400;
   mass = 4.5;
   groundtraction = 0.8;
	maxEnergy = 1.0;
   drag = 1.0;
   density = 1.2;
	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpimpulse = 37.2;
   jumpsurfacemindot = 0.55;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   //animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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


   jetSound = SoundLFootRSoft;

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

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};



//******************************************************************------------------------------------------------------------------
// Mech data:
//******************************************************************------------------------------------------------------------------


PlayerData marmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = defaultDebrisMedium; //playerDebris; // why not have it palyerdebris, have them always expload, and have it spawn medium debris independently.
   shadowDetailMask = 1;
   validateShape = false;

   visibleToSensor = False;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = false;
   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1.0;
   jetForce = 1;
   jetEnergyDrain = 0.0;

	maxDamage = 5.0;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 2;
   maxSideSpeed = 0;
   groundForce = 50 * 100.0;
   mass = 100.0;
   groundTraction = 70;
	maxEnergy = 50;
   drag = 1.0;
   density = 1.2;
	minDamageSpeed = 14;
	damageScale = 0.065;

   jumpImpulse = 0;
   jumpSurfaceMinDot = 0.0;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
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
   //animData[19] = { "root", none, 1, true, true, true, false, 2 };
   animData[19]  = { "run", none, 1, true, false, true, false, 3 };

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
	animData[38] = { "root", none, 1, true, false, false, false, 2 };
   animData[39] = { "root", none, 1, true, false, false, false, 2 };
   animData[40] = { "root", none, 1, true, false, false, false, 2 };
   animData[41] = { "root", none, 1, true, false, false, false, 2 };
   animData[42] = { "root", none, 1, true, false, false, false, 2 }; 

    // celebraton animations:
   animData[43] = { "root", none, 1, true, false, false, false, 2 };
   animData[44] = { "root", none, 1, true, false, false, false, 2 };
   animData[45] = { "root", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "root", none, 1, true, false, false, false, 2 };
   animData[47] = { "root", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "root", none, 1, true, false, false, false, 2 };
   animData[49] = { "root", none, 1, true, false, false, false, 2 };

	// Bonus wave
   animData[50] = { "root", none, 1, true, false, false, false, 2 };


   jetSound = SoundHFootRSoft;

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

// See mech.cs for rest of info
