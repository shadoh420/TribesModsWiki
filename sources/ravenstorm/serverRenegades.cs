$ItemFavoritesKey = "war40k";
$Welcome="<jc><f2>Warhammer 40K\n http://www.goncalves.com/mike\n\n";
$DefaultArmor[Male] = dmarmor;
$DefaultArmor[Female] = dmfemale;

 // Initial buy list
$spawnBuyList[0] = iarmorMercenary;
$spawnBuyList[1] = HyperB;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Silencer;
$spawnBuyList[4] = Screamer;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Grenade;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = Beacon;
$spawnBuyList[14] = RepairPack;
$spawnBuyList[15] = "";

function serverRenegades::Start()
{
   echo('>> Loading armor classes');
	exec(armorScout);
	exec(armorSpy);
	exec(armorMercenary);
	exec(armorEngineer);
	exec(armorBurster);
	exec(armorCyborg);
        exec(armorEngineer);
        exec(armorSprint);
        exec(armorSniper);
        exec(armorAlien);
        exec(armorDM);
        exec(armorCommando);
        exec(armorLoader);
        exec(armorDestroyer);
   echo('>> Loading weapons');
        exec(weaponTargetLaser);
	exec(weaponBlaster);
        exec(weaponPlasmaGun);
        exec(weaponShockwave);
        exec(weaponLasPist);
        exec(weaponLaserRifle);
	exec(weaponHyperBlaster);
        exec(weaponDeathLaser);
        exec(weaponLasCannon);
        exec(weaponScreamer);
        exec(weaponChaingun);
        exec(weaponAutogun);
        exec(weaponMagnum);
        exec(weaponVulcan); 
        exec(weaponRailgun);
        exec(weaponPartGun);
        exec(weaponSniperRifle);
        exec(weaponDart);
        exec(weaponLongRifle); 
        exec(weaponShotgun);
        exec(weaponFlamer);
        exec(weaponHFlamer);
        exec(weaponChem);
        exec(weaponOmega);
        exec(weaponMelta);
        exec(weaponIon);
        exec(weaponDiscLauncher);
        exec(weaponShurCannon);
	exec(weaponGrenade);
     	exec(weaponMortar);
      exec(weaponTacticalNuke);
	exec(weaponDemoGun);
      exec(weaponHornetLauncher);
      exec(weaponPlasmaMortar);
      exec(weaponRocketLauncher);
        exec(weaponCyc);
        exec(weaponEMP);
	exec(weaponMassDriver);
	exec(weaponWarp);
	exec(weaponELF);
	exec(weaponFixit);
        exec(weaponTractorDevice);
        
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCommand);
	exec(packEnergy);
        exec(packJetPack);
        exec(packRegeneration);
        exec(packRepair);
        exec(packShield);
        exec(packCloak);
        exec(packStealthShield);
	exec(packJammer);
	exec(packLightening);
	exec(packOptic);
        exec(packSMR);
	exec(packSuicide);
        exec(packOMen);
        

   echo('>> Targeting systems');
	exec(weaponTargetMark);
	exec(packPhotonTorpedo);
	exec(packTrackerMissile);

   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);

   echo('>> Loading deployable sensors');
	exec(deployMotionSensor);
	exec(deployPulseSensor);
        exec(deployCamera);
	exec(deploySensorJammer);

   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation); 
        exec(deployBlastWall); 
        exec(deployPlatform);  
        exec(deployAirPlat);      
	exec(deployForceField);
	exec(deployBigField);
        exec(deployMannequin);
	exec(deployTree);
	exec(deployTeleporter);
	exec(deploySpringboard);
	exec(deployAccelerator);
	exec(deployVehicles);
	exec(deploySatchelCharge);
        exec(deployLRSensorJammerPack);
        exec(deployLRMotionSensorPack);
        exec(deployLRPulseSensorPack);
        exec(deployVehiclex);
         
   echo('>> Loading deployable weapons');
	exec(deployIonTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployBarrageTurret);
	exec(deployMortarTurret);
	exec(deployShockTurret);
	exec(deployPlasmaTurret);
	exec(deployRailTurret);
	exec(deployVulcanTurret);
        exec(deployHFlameTurret);
        exec(deployElecTurret);
        exec(deployFlameTurret);
        exec(deployAAGun);
         
   echo('>> Loading Psionics');
       exec(weaponPsiShock);
       exec(weaponHeal);
       exec(weaponSuck);
       exec(weaponPsiStream);
       exec(weaponZap);
       exec(weaponFireball);
       exec(packChameleon);
       exec(weaponPull);
       exec(weaponPsiLas);
       exec(weaponPsiSword);
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleScout);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
        exec(vehicleFighter);
        exec(vehicleHAPC);
        exec(vehicleTempest);
	exec(vehicleLAPC);
        exec(vehicleHvyFighter);
        exec(vehicleSpeeder);
   echo('>> Usage');
	exec(serverRenegades_ItemUsage);
}

function serverRenegades::InitializeMission()
{
         // Initialize vehicles
	vehicleScout::Initialize();
	vehicleInterceptor::Initialize();
	vehicleWraith::Initialize();
        vehicleDogFighter::Initialize();
        vehicleHAPC::Initialize();
        vehicleTempest::Initialize();
	vehicleLAPC::Initialize();
	vehicleQuickLPC::Initialize();
        vehicleSpeeder::Initialize();
	 // Initialize deployables
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deployForceField::Initialize(); 
	deployBigField::Initialize();
	deployMannequin::Initialize();
	deployTree::Initialize();
	deployBlastWall::Initialize();
	deployPlatform::Initialize();
	deployTeleporter::Initialize();
	deploySpringboard::Initialize();
	deployAccelerator::Initialize();
        deployAirPlat::Initialize();
        deployLRSensorJammerPack::Initialize();
        deployLRMotionSensorPack::Initialize();
        deployLRPulseSensorPack::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployVulcanTurret::Initialize();
	deployRailTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployMortarTurret::Initialize();
	deployMissileTurret::Initialize();
	deployBarrageTurret::Initialize();
	deployLaserTurret::Initialize();
	deployIonTurret::Initialize();	
        deployHFlameTurret::Initialize();
        deployElecTurret::Initialize();
        deployFlameTurret::Initialize();
        deployAAgun::Initialize();

	deploySatchelCharge::Initialize();
}