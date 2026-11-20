$MaxWeapons[armormDM] = 4;
$MaxWeapons[armorfDM] = 4;
$MaxWeapons[armormAngel] = 2;
$MaxWeapons[armorfAngel] = 2;
$MaxWeapons[armormSpy] = 3;
$MaxWeapons[armorfSpy] = 3;
$MaxWeapons[armormNecro] = 3;
$MaxWeapons[armorfNecro] = 3;
$MaxWeapons[armormMercenary] = 5;
$MaxWeapons[armorfMercenary] = 5;
$MaxWeapons[armormBuilder] = 4;
$MaxWeapons[armorfBuilder] = 4;
$MaxWeapons[armorTroll] = 5;
$MaxWeapons[armorTank] = 6;
$MaxWeapons[armorTitan] = 5;

function PopulateCanPilot(%APC, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI)
{
  $VehicleUse[armormDM, %APC] = %mDM;
  $VehicleUse[armorfDM, %APC] = %fDM;
  $VehicleUse[armormAngel, %APC] = %mAN;
  $VehicleUse[armorfAngel, %APC] = %fAN;
  $VehicleUse[armormSpy, %APC] = %mSP;
  $VehicleUse[armorfSpy, %APC] = %fSP;
  $VehicleUse[armormNecro, %APC] = %mNE;
  $VehicleUse[armorfNecro, %APC] = %fNE;
  $VehicleUse[armormMercenary, %APC] = %mME;
  $VehicleUse[armorfMercenary, %APC] = %fME;
  $VehicleUse[armormBuilder, %APC] = %mBU;
  $VehicleUse[armorfBuilder, %APC] = %fBU;
  $VehicleUse[armorTroll, %APC] = %TR;
  $VehicleUse[armorTank, %APC] = %TA;
  $VehicleUse[armorTitan, %APC] = %TI;  
}

$CP = 1;
$CR = 2;
//                             mDM,       fDM,       mAN,       fAN,       mSP,       fSP,       mNE,       fNE,       mME,       fME,       mBU,       fBU,        TR,        TA,  TI
//                             ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---  ---
PopulateCanPilot(Wraith,       $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR, $CR);
PopulateCanPilot(Interceptor,  $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR, $CR);
PopulateCanPilot(Fighter,      $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR, $CR);
PopulateCanPilot(LAPC,         $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);
PopulateCanPilot(HAPC,         $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);

function PopulateDamageScale(%damagetype, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI, %h1, %vSc, %vIn, %vWr, %vLa, %vHa, %pSv, %pPr, %pSu, %wOs)
{
  $DamageScale[armormDM, %damagetype] = %mDM;
  $DamageScale[armorfDM, %damagetype] = %fDM;
  $DamageScale[armormAngel, %damagetype] = %mAN;
  $DamageScale[armorfAngel, %damagetype] = %fAN;
  $DamageScale[armormSpy, %damagetype] = %mSP;
  $DamageScale[armorfSpy, %damagetype] = %fSP;
  $DamageScale[armormNecro, %damagetype] = %mNE;
  $DamageScale[armorfNecro, %damagetype] = %fNE;
  $DamageScale[armormMercenary, %damagetype] = %mME;
  $DamageScale[armorfMercenary, %damagetype] = %fME;
  $DamageScale[armormBuilder, %damagetype] = %mBU;
  $DamageScale[armorfBuilder, %damagetype] = %fBU;
  $DamageScale[armorTroll, %damagetype] = %TR;
  $DamageScale[armorTank, %damagetype] = %TA;
  $DamageScale[armorTitan, %damagetype] = %TI;  
  $DamageScale[harmor, %damagetype] = %h1;
  $DamageScale[Fighter, %damagetype] = %vSc;
  $DamageScale[interceptor, %damagetype] = %vIn;
  $DamageScale[wraith, %damagetype] = %vWr;
  $DamageScale[lapc, %damagetype] = %vLa;
  $DamageScale[hapc, %damagetype] = %vHa;
  $DamageScale[SurveyDroid, %damagetype] = %pSv;
  $DamageScale[ProbeDroid, %damagetype] = %pPr;
  $DamageScale[SuicideDroid, %damagetype] = %pSu;
  $DamageScale[OSMissile, %damagetype] = %wOs;
}

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DAMAGE SCALE
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// 	                                       mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI,  h1,  h2,  h3, vSc, vIn, vWr, vLa, vHa, pSv, pPr, pSu, wOS
//	                                       ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateDamageScale($ImpactDamageType,         1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($LandingDamageType,        1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BulletDamageType,         1.0, 1.0, 1.2, 1.2, 0.5, 0.5, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 1.3, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($EnergyDamageType,         1.0, 1.0, 1.3, 1.3, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.1, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 1.5, 1.0);
PopulateDamageScale($PlasmaDamageType,         1.0, 1.0, 1.0, 1.0, 1.2, 1.2, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 2.0, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($ExplosionDamageType,      1.0, 1.0, 1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.2, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($ShrapnelDamageType,       1.0, 1.0, 1.2, 1.2, 1.3, 1.3, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($LaserDamageType,          1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($MortarDamageType,         1.0, 1.0, 1.3, 1.3, 1.3, 1.3, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 1.2, 0.5, 0.6, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.7, 1.0, 2.0, 2.0, 2.0, 1.0);
PopulateDamageScale($BlasterDamageType,        1.0, 1.0, 1.3, 1.3, 1.3, 1.3, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 1.5, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 0.5, 0.5, 2.0, 2.0, 2.0, 0.5);
PopulateDamageScale($ElectricityDamageType,    1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($CrushDamageType,          1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DebrisDamageType,         1.0, 1.0, 1.2, 1.2, 1.3, 1.3, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 1.5, 1.0);
PopulateDamageScale($MissileDamageType,        1.0, 1.0, 1.0, 1.0, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.2, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MineDamageType,           1.0, 1.0, 1.2, 1.2, 1.2, 1.2, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 1.1, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SniperDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 1.5, 1.0);
PopulateDamageScale($ShockDamageType,          1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShotgunDamageType,        1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0,10.0,10.0,10.0,10.0);
PopulateDamageScale($AssassinDamageType,       1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DisarmDamageType,         1.0, 1.0, 1.0, 1.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($TurretVortexDamageType,   1.0, 1.0, 1.3, 1.3, 1.3, 1.3, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($TurretLaserDamageType,    1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($PoisonDamageType,         1.0, 1.0, 1.3, 1.3, 1.3, 1.3, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.1, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 1.5, 1.0);

function PopulateItemMax(%item, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI, %h1, %h2, %h3)
{
  $ItemMax[armormDM, %item] = %mDM;
  $ItemMax[armorfDM, %item] = %fDM;
  $ItemMax[armormAngel, %item] = %mAN;
  $ItemMax[armorfAngel, %item] = %fAN;
  $ItemMax[armormSpy, %item] = %mSP;
  $ItemMax[armorfSpy, %item] = %fSP;
  $ItemMax[armormNecro, %item] = %mNE;
  $ItemMax[armorfNecro, %item] = %fNE;
  $ItemMax[armormMercenary, %item] = %mME;
  $ItemMax[armorfMercenary, %item] = %fME;
  $ItemMax[armormBuilder, %item] = %mBU;
  $ItemMax[armorfBuilder, %item] = %fBU;
  $ItemMax[armorTroll, %item] = %TR;
  $ItemMax[armorTank, %item] = %TA;
  $ItemMax[armorTitan, %item] = %TI;  
}

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DiscLauncher,                   1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(DiscAmmo,                      30,  30,   0,   0,  30,  30,   0,   0,  30,  30,  30,  30,  30,   0,  15);
PopulateItemMax(Fixit,                          0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(GrenadeLauncher,                1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(GrenadeAmmo,                   20,  20,   0,   0,   0,   0,   0,   0,  20,  20,  20,  20,  30,  30,  30);
PopulateItemMax(MassDriver,                     1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(MassAmmo,                      20,  20,   0,   0,   0,   0,   0,   0,  20,  20,   0,   0,   0,   0,  25);
PopulateItemMax(Mortar,                         0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(MortarAmmo,                     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15,   0,   0);
PopulateItemMax(PlasmaGun,                      1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(PlasmaAmmo,                    30,  30,   0,   0,  25,  25,   0,   0,  30,  30,  30,  30,  40,   0,  40);
PopulateItemMax(Railgun,                        0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(RailAmmo,                       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  30,  30,   0,   0,   0);
PopulateItemMax(RocketLauncher,                 1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(RocketAmmo,                    10,  10,   0,   0,   0,   0,   0,   0,  10,  10,  10,  10,  10,   0,  20);
PopulateItemMax(Shotgun,                        1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0);
PopulateItemMax(ShotGunShells,                 30,  30,   0,   0,  30,  30,   0,   0,  30,  30,  30,  30,  30,  30,   0);
PopulateItemMax(SniperRifle,                    0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperAmmo,                     0,   0,   0,   0,  15,  15,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TargetMarkLaser,                1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(TranqGun,                       0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TranqAmmo,                      0,   0,   0,   0,  30,  30,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Vulcan,                         1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0);
PopulateItemMax(VulcanAmmo,                   200, 200,   0,   0,   0,   0,   0,   0, 200, 200, 200, 200, 400, 400,   0);
PopulateItemMax(WaveGun,                        1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(HDiscLauncher,                  1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(HDiscLauncherAmmo,             30,  30,   0,   0,   0,   0,   0,   0,  30,  30,  30,  30,  30,   0,  40);
PopulateItemMax(KShredder,                      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(KShredderAmmo,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 500,   0);
PopulateItemMax(KRocketLauncher,                0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(KRocketLauncherAmmo,            0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  40,   0);
PopulateItemMax(TankRPGLauncher,                0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TankRPGAmmo,                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  60,   0);
PopulateItemMax(KBlastCannon,                   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(KBlastCannonAmmo,               0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  30,   0);
PopulateItemMax(AngelFire,                      0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ATC,                            1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   1);
PopulateItemMax(ATCAmmo,                       70,  70,   0,   0,   0,   0,   0,   0,  70,  70,   0,   0, 100,   0, 100);
PopulateItemMax(BabyNukeMortar,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(BabyNukeAmmo,                   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10);
PopulateItemMax(BeaconGun,                      0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1,   1,   1,   0,   1);
PopulateItemMax(BeaconAmmo,                     0,   0,   0,   0,   5,   5,   0,   0,   0,   0,   8,   8,   5,   0,  10);

 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MineLauncher,                   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(MinelAmmo,                      5,   5,   0,   0,   0,   0,   0,   0,   5,   5,   5,   5,   0,   0,  10);
PopulateItemMax(OSLauncher,                     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(OSAmmo,                         0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  10);
PopulateItemMax(Flamer,                         1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(Gasoline,                      50,  50,   0,   0,   0,   0,   0,   0,  50,  50,  50,  50,  75, 100, 100);
PopulateItemMax(FlameThrower,                   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   1);
PopulateItemMax(FlameThrowerAmmo,              50,  50,   0,   0,   0,   0,   0,   0,  50,  50,   0,   0,  75, 100, 100);
PopulateItemMax(GatlingBlaster,                 1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(Hellfire,                       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(HellfireAmmo,                   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15);
PopulateItemMax(Jailgun,                        1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(TargetingLaser,                 1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(HeavensFury,                    0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Stinger,                        1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(StingerAmmo,                   10,  10,   0,   0,   0,   0,   0,   0,  10,  10,  10,  10,  15,   0,   0);
PopulateItemMax(ParticleBeamWeapon,             0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(RubberMortar,                   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RubberAmmo,                    10,  10,   0,   0,   0,   0,   0,   0,  10,  10,  10,  10,  15,  20,  20);
PopulateItemMax(PhaseDisrupter,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   1);
PopulateItemMax(PhaseDisrupterAmmo,             0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15,   0,  20);
PopulateItemMax(PulseCannon,                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   0,   1);

//Spells
PopulateItemMax(DeathRay,                       0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DisarmerSpell,                  0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ShockingGrasp,                  0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Stasis,                         0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Elf,                            0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0); 
PopulateItemMax(FlameStrike,                    0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);  
PopulateItemMax(SpellFlameThrower,              0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0); 

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // MISC 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Beacon,                         1,   1,   1,   1,   5,   5,   5,   5,   5,   5,   1,   1,   5,   5,   5);  
PopulateItemMax(Grenade,                        8,   8,   8,   8,   8,   8,   8,   8,   8,   8,   8,   8,   8,   8,   8);
PopulateItemMax(MineAmmo,                       3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   3,   5,   5,   5);
PopulateItemMax(RepairKit,                      1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // PACKS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,                       1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(EnergyPack,                     1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(RepairPack,                     1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(ShieldPack,                     1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(SensorJammerPack,               1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(PhaseShifterPack,               0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(CloakingDevice,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0); 
PopulateItemMax(StealthShieldPack,              1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0); 
PopulateItemMax(Laptop,                         0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);  
PopulateItemMax(SuicidePack,                    0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0); 
PopulateItemMax(RegenerationPack,               0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0); 
PopulateItemMax(LightningPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0); 
PopulateItemMax(TeleportPack2,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ChameleonPack,                  0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0); 
PopulateItemMax(SurveyDroidPack,                0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 
PopulateItemMax(ProbeDroidPack,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 
PopulateItemMax(SuicideDroidPack,               0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE SENSORS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,                     0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack,     0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MotionSensorPack,               0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PulseSensorPack,                0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE WEAPONS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(FusionTurretPack,               1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(LaserTurretPack,                0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(RocketPack,                     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   0,   0); 
PopulateItemMax(PlasmaTurretPack,               0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1); 
PopulateItemMax(MortarTurretPack,               0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);  
PopulateItemMax(ShockTurretPack,                0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 
PopulateItemMax(MMTurretPack,                   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(NuclearTurretPack,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(FlameTurretPack,                0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(RailTurretPack,                 1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 
PopulateItemMax(IrradiationTurretPack,          1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1); 
PopulateItemMax(IonTurretPack,                  0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   1,   1);
PopulateItemMax(vortexTurretPack,               0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ParticleBeamTurretPack,         1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   1,   1);

 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // DEPLOYABLE OBJECTS
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 //                                            mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
 //                                            ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DeployableAmmoPack,             1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(AirbasePack,                    1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(DropShipDSPack,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(DropShipSWPack,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(BunkerPack,                     0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(BaseCloakPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(Plastique,                    1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ProbePack,                      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(AcceleratorDevicePack,          1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(BlastWallPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ForceFieldPack,                 1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(LargeForceFieldPack,            0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(doorfivebyfiveForceFieldPack, 	0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(doorfourbyeightForceFieldPack, 	0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(MannequinPack,                  1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(PlatformPack,                   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(DeployableComPack,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(DeployableInvPack,              1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(SpringPack,                     1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TreePack,                       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TeleportPack,                   1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(FighterPack,                    0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TransportPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(MobileGenPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PortableSolarPack,              0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PowerNodePack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(SatSystemPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ShieldGenPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ShieldNodePack,                 0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(JailPack,                       0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(MobileInvPack,                  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
 
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TEAM ITEM MAXs
 //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
 // TURRETS
$TeamItemMax[BeaconAmmo] = 20;

$TeamItemMax[IrradiationTurretPack] = 2;
$TeamItemMax[FlameTurretPack] = 6;
$TeamItemMax[FusionTurretPack] = 4;
$TeamItemMax[IonTurretPack] = 10;
$TeamItemMax[MMTurretPack] = 2;
$TeamItemMax[MortarTurretPack] = 2;
$TeamItemMax[NuclearTurretPack] = 2;
$TeamItemMax[ParticleBeamTurretPack] = 2;
$TeamItemMax[PlasmaTurretPack] = 8;
$TeamItemMax[RailTurretPack] = 4;
$TeamItemMax[RocketPack] = 6;
$TeamItemMax[ShockTurretPack] = 8;
$TeamItemMax[LaserTurretPack] = 16;
$TeamItemMax[VortexTurretPack] = 6;

 // REMOTE BASES
$TeamItemMax[BaseOpsPack] = 1; //Borg Cube
$TeamItemMax[DeployableBaseOps] = 1; //Borg Cube
$TeamItemMax[AirbasePack] = 0;
$TeamItemMax[BunkerPack] = 4;
$TeamItemMax[DropShipDSPack] = 1;
$TeamItemMax[DropShipSWPack] = 1;

 // DEPLOYABLE OBJECTS
$TeamItemMax[AcceleratorDevicePack] = 12;
$TeamItemMax[AcceleratorDevice] = 12;
$TeamItemMax[BaseCloakPack] = 1;
$TeamItemMax[BlastWallPack] = 20; 
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableComPack] = 5; 
$TeamItemMax[DeployableInvPack] = 10; 
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[doorfivebyfiveForceFieldPack] = 6;
$TeamItemMax[doorfourbyeightForceFieldPack] = 4;
$TeamItemMax[ForceFieldPack] = 20; 
$TeamItemMax[JailPack] = 1;
$TeamItemMax[LargeForceFieldPack] = 8; 
$TeamItemMax[Mannequin] = 12;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[PlatformPack] = 20; 
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[Springboard] = 6;
$TeamItemMax[TreePack] = 4;
$TeamItemMax[TNTPack] = 4;

 // DRONES
$TeamItemMax[SurveyDroidPack] = 10;
$TeamItemMax[ProbeDroidPack] = 3;
$TeamItemMax[SuicideDroidPack] = 6;

 // POWER SYSTEMS
$TeamItemMax[MobileInvPack] = 5;
$TeamItemMax[MobileGenPack] = 3;
$TeamItemMax[PortableSolarPack] = 3;
$TeamItemMax[PowerNodePack] = 20;
$TeamItemMax[SatSystemPack] = 1;
$TeamItemMax[ShieldGenPack] = 1;
$TeamItemMax[ShieldNodePack] = 20;

 // VEHICLES
$TeamItemMax[FighterVehicle] = 6;
$TeamItemMax[InterceptorVehicle] = 5;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[LAPCVehicle] = 4;
$TeamItemMax[HAPCVehicle] = 2;
