
$DefaultArmor[Male] = armormWarrior;
$DefaultArmor[Female] = armorfWarrior;

 // Initial buy list
$spawnBuyList[0] = iarmorWarrior;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = PlasmaGun;
$spawnBuyList[3] = Shotgun;
$spawnBuyList[4] = Beacon;
$spawnBuyList[5] = RepairKit;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Grenade;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = Beacon;
$spawnBuyList[14] = MineAmmo;
$spawnBuyList[15] = TargetingLaser;
$spawnBuyList[16] = EnergyPack;
$spawnBuyList[17] = "";

function serverAnnihilation::Armors()
{
   echo('>> Loading armor classes');
	exec(armorAngel);
	exec(armorSpy);
	exec(armorNecro);
	exec(armorWarrior);
	exec(armorBuilder);
	exec(armorTroll);
	exec(armorTank);
	exec(armorTitan);
	exec(armorDM);
}

function serverAnnihilation::Items()
{
   echo('>> Loading weapons');
	exec(weaponAngelFire);
	//exec(weaponAutoCannon);
	exec(weaponBabyNuke);
	//exec(weaponBeaconGun);
	exec(weaponFixit);
	exec(weaponDiscLauncher);
	//exec(weaponGatlingBlaster);
	exec(weaponGrenadeLauncher);
	exec(weaponFlamer);
	exec(weaponFlameThrower);
	exec(weaponHDiscLauncher);
	exec(weaponHeavensfury);
	//exec(weaponHellfire);
	exec(weaponJailgun);
	//exec(weaponMassDriver);
	exec(weaponMineLauncher);
	exec(weaponMortar);
	exec(weaponOSLauncher);
	exec(weaponParticleBeam);
	exec(weaponPhaseDisrupter);
	exec(weaponPlasmaGun);
	exec(weaponPulseCannon);
	exec(weaponRailgun);
	exec(weaponRocketLauncher);
	exec(weaponRubberMortar);
	exec(weaponShockwave);
	exec(weaponShotGun);
	exec(weaponSniperRifle);
	exec(weaponStinger);
	exec(weaponTankBlastCannon);
	exec(weaponTankShredder);
	exec(weaponTankRocketLauncher);
	exec(weaponTankRPG);	
	exec(weaponTargetLaser);
	exec(weaponVulcan);

   echo('>> Loading spells');
	exec(spellDeathRay);
	exec(spellDisarmer);
	exec(spellFlameStrike);
	exec(spellFlameThrower);
	exec(spellShockingGrasp);
	exec(spellStasis);
	
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packChameleon);
	exec(packCloak);
	exec(packEnergy);
	exec(packCommand);
	exec(packPhaseShifter);
	exec(packRepair);
	exec(packJammer);
	exec(packShield);
	exec(packStealthShield);
	exec(packSuicide);
	//exec(packTNT);
	exec(packRegeneration);
	//exec(packTarget);
	
   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);
	exec(miscRepairPatch);
	
   echo('>> Loading deploy functions');
	exec(deployFunctions);
	
   echo('>> Loading deployable sensors');
	exec(deployCamera);
	exec(deployMotionSensor);
        exec(deployPulseSensor);
	exec(deploySensorJammer);
	
   echo('>> Loading deployable objects');
	exec(deployAccelerator);
	exec(deployAmmoStation);
	exec(deployBaseCloak);
	exec(deployCommandStation);
	exec(deployControlJammer);
	exec(deployFighter);
	exec(deployInventoryStation);
	exec(deployJailPack);
	//exec(deployMannequin);
	exec(deploySpringboard);
	exec(deployTeleporter);
	exec(deployTransport);
	//exec(deployTree);

   echo('>> Loading deployable barriers');
	exec(deployBlastWall);
	exec(deployForceField);
	exec(deployForceFieldDoor);
	exec(deployLargeForceField);
	exec(deployLargeForceFieldDoor);
	exec(deployPlatform);

   echo('>> Loading power systems');
	exec(powerFunctions);
	exec(deployMobileInventory);
	exec(deployPortableGenerator);
	exec(deployPortableSolar);
	//exec(deployPowerNode);
	//exec(deploySatSystem);
	//exec(deployShieldGen);
	//exec(deployShieldNode);

   echo('>> Loading remote base objects');
	exec(deployAirbase);
	//exec(deployBorgCube);
	exec(deployBunkerPack);
	exec(dropShipCommandShip);
	exec(dropShipGunShip);

   echo('>> Droids');
	exec(droidProbeDroid);
	exec(droidSuicideDroid);
	exec(droidSurveyDroid);
}
	
function serverAnnihilation::Turrets()
{
   echo('>> Loading deployable weapons');
	exec(turretFlameTurret);
	exec(turretFusionTurret);
	exec(turretIonTurret);
	exec(turretIrradiationTurret);
	exec(turretLaserTurret);
	//exec(turretMMTurret);
	exec(turretMissileTurret);
	exec(turretMortarTurret);
	exec(turretNuclearTurret);
	exec(turretParticleBeamTurret);
	exec(turretPlasmaTurret);
	//exec(turretRailTurret);
	exec(turretShockTurret);
	exec(turretVortexTurret);
}

function serverAnnihilation::Vehicles()
{
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	//exec(vehicleWraith);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
}	

function serverAnnihilation::Others()
{
   echo('>> Others');
}

function serverAnnihilation::InitializeMission()
{
  // Barriers
	deployBlastWall::Initialize();
	deployForceField::Initialize();
	deployForceFieldDoor::Initialize();
	deployLargeForceField::Initialize();
	deployLargeForceFieldDoor::Initialize();
	deployPlatform::Initialize();

   // Deployables
	deployAccelerator::Initialize();
	deployAmmoStation::Initialize();
	deployBaseCloak::Initialize();
	deployCommandStation::Initialize();
	deployControlJammer::Initialize();
	deployFighter::Initialize();
	deployJailpack::Initialize();
	deployInventoryStation::Initialize();
	//deployMannequin::Initialize();
	deploySpringboard::Initialize();
	deployTeleporter::Initialize();
	deployTransport::Initialize();
	//deployTree::Initialize();
	
   // Misc
	miscMine::Initialize();
	miscBeacon::Initialize();

   // Powered Items
	deployMobileInventory::Initialize();
	deployPortableGenerator::Initialize();
	deployPortableSolar::Initialize();
	//deployPowerNode::Initialize();
	//deploySatSystem::Initialize();
	//deployShieldGen::Initialize();
	//deployShieldNode::Initialize();

   // Remote base objects
	deployAirbase::Initialize();
	//deployBorgCube::Initialize();
	deployBunkerpack::Initialize();
	deployCommandShip::Initialize();
	deployGunShip::Initialize();

   // Sensors
	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

   // Turrets
	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	//deployMMTurret::Initialize();
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	//deployRailTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
	
   // Vehicles
	vehicleFighter::Initialize();
	vehicleInterceptor::Initialize();
	//vehicleWraith::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();
}
