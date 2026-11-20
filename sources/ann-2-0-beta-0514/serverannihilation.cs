
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
   echo('>> Loading Armors');
   	exec(ArmorData);
	exec(armorAngel);
	exec(armorSpy);
	exec(armorNecro);
	exec(armorghost); //plasmatic
	exec(armorWarrior);
	exec(armorBuilder);
	exec(armorTroll);
	exec(armorTank);
	exec(armorTitan);
	exec(armorDM);
   echo('<< Armors Complete');
}



function serverAnnihilation::Weapons()
{
   echo('>> Loading Weapons');
	exec(weaponAngelFire);
	exec(weaponBabyNuke);
	exec(weaponFixit);
	exec(weaponDiscLauncher);
	exec(weaponGrenadeLauncher);
	exec(weaponFlamer);
	exec(weaponFlameThrower);
	exec(weaponHDiscLauncher);
	exec(weaponHeavensfury);
	exec(weaponJailgun);
	//exec(weaponMineLauncher);
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
	exec(weaponSoul);	
	exec(weaponStinger);
	exec(weaponTankBlastCannon);
	exec(weaponTankShredder);
	exec(weaponTankRocketLauncher);
	exec(weaponTankRPG);	
	exec(weaponTargetLaser);
	exec(weaponVulcan);
   echo('<< Weapons Complete');
}

function serverAnnihilation::Spells()
{
   echo('>> Loading Spells');
	exec(spellDeathRay);
	exec(spellDisarmer);
	exec(spellFlameStrike);
	exec(spellFlameThrower);
	exec(spellShockingGrasp);
	exec(spellStasis);
   echo('<< Spells Complete');
}

function serverAnnihilation::Packs()
{	
   echo('>> Loading Packs');
	exec(packAmmo);
	exec(packChameleon);
	exec(packCloak);
	exec(packEnergy);
	exec(packCommand);
	exec(packPhaseShifter);
	exec(packRepair);
	exec(packJammer);
	exec(packTrueSight);		//plasmatic
	exec(packShield);
	exec(packBuilder);		//plasmatic
	exec(packStealthShield);
	exec(packghost);		//Plasmatic
	exec(packSuicide);
	//exec(packTNT);
	exec(packRegeneration);
	//exec(packTarget);
   echo('<< Packs Complete');
}


function serverAnnihilation::Items()
{
   echo('>> Loading Misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
//	exec(miscRepairKit);
//	exec(miscRepairPatch);
   echo('<< Misc Complete');
	
   echo('>> Loading Deploy Functions');
	exec(deployFunctions);
   echo('<< Deploy Functions Complete');
	
   echo('>> Loading Deployable Sensors');
	exec(deployCamera);
	exec(deployMotionSensor);
	exec(deployAlarm);	//Plasmatic
        exec(deployPulseSensor);
	exec(deploySensorJammer);
   echo('<< Deployable Sensors Complete');
	
   echo('>> Loading Deployable Objects');
	//exec(deployAccelerator);
	exec(deployAmmoStation);
	exec(deployBaseCloak);
	exec(deployCommandStation);
	exec(deployControlJammer);
	exec(deployFighter);
	exec(deployInventoryStation);
	exec(deployJailTower);
	exec(deployJumpPad);
	//exec(deployMannequin);
	//exec(deploySpringboard);
	exec(deployTeleporter);
	exec(deployTransport);
	//exec(deployTree);
   echo('<< Deployable Objects Complete');

   echo('>> Loading Deployable Barriers');
	exec(deployBlastWall);
	exec(deployForceField);
	exec(deployForceFieldDoor);
	exec(deployLargeForceField);
	exec(deployLargeForceFieldDoor);
	exec(deployPlatform);
   echo('<< Deployable Barriers Complete');

   echo('>> Loading Power Systems');
	exec(powerFunctions);
	exec(deployMobileInventory);
	exec(deployPortableGenerator);
	exec(deployPortableSolar);
	//exec(deployPowerNode);
	//exec(deploySatSystem);
	//exec(deployShieldGen);
	//exec(deployShieldNode);
   echo('<< Power Systems Complete');

   echo('>> Loading Remote Base Objects');
	exec(deployAirbase);
	exec(deployBunkerPack);
	exec(dropShipFunctions);
	exec(dropShipCommandShip);
	exec(dropShipGunShip);
	exec(dropShipSupplyShip);
   echo('<< Remote Base Objects Complete');

   echo('>> Loading Droids');
	exec(droidProbeDroid);
	exec(droidSuicideDroid);
	exec(droidSurveyDroid);
   echo('<< Droids Complete');
}

function serverAnnihilation::Stations()
{
   echo('>> Loading Stations');
	exec(Station);
	exec(stationAmmoStation);
	exec(stationCommandStation);
	exec(stationDeployableStation);
	exec(stationInventoryStation);
	exec(stationMobileStation);
	exec(stationVehicleStation);
   echo('<< Stations Complete');
}
	
function serverAnnihilation::Turrets()
{
   echo('>> Loading Turrets');
	exec(Turret);
	exec(turretFlameTurret);
	exec(turretFusionTurret);
	exec(turretIonTurret);
	exec(turretIrradiationTurret);
	exec(turretLaserTurret);
	exec(turretMissileTurret);
	exec(turretMortarTurret);
	exec(turretNuclearTurret);
	exec(turretParticleBeamTurret);
	exec(turretPlasmaTurret);
	exec(turretShockTurret);
	exec(turretVortexTurret);
   echo('<< Turrets Complete');
}

function serverAnnihilation::Vehicles()
{
   echo('>> Loading Vehicles');
	exec(Vehicle);
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('<< Vehicles Complete');
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
	//deployAccelerator::Initialize();
	deployAmmoStation::Initialize();
	deployBaseCloak::Initialize();
	deployCommandStation::Initialize();
	deployControlJammer::Initialize();
	deployFighter::Initialize();
	deployJailTower::Initialize();
	deployJumpPad::Initialize();
	deployInventoryStation::Initialize();
	//deployMannequin::Initialize();
	//deploySpringboard::Initialize();
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
	deployBunkerpack::Initialize();
	deployCommandShip::Initialize();
	deployGunShip::Initialize();
	deploySupplyShip::Initialize();

   // Sensors
	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();
	DeployAlarm::Initialize();

   // Turrets
	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
	
   // Vehicles
	vehicleFighter::Initialize();
	vehicleInterceptor::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();
}
