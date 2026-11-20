
//$Welcome="<jc><f2>TotalAnnihilation - Created by {PaGaN}Scavenger\n\";

$DefaultArmor[Male] = armormDM;
$DefaultArmor[Female] = armorfDM;

 // Initial buy list
$spawnBuyList[0] = iarmorMercenary;
$spawnBuyList[1] = DiscLauncher;
$spawnBuyList[2] = GatlingBlaster;
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
	exec(armorMercenary);
	exec(armorBuilder);
	exec(armorTroll);
	exec(armorTank);
	exec(armorTitan);
	exec(armorDM);
}

function serverAnnihilation::Items()
{   
   echo('>> Loading weapons');
	exec(weaponGatlingBlaster);
	exec(weaponPlasmaGun);
	exec(weaponGrenadeLauncher);
	exec(weaponMortar);
	exec(weaponDiscLauncher);
	exec(weaponRocketLauncher);
	exec(weaponSniperRifle);
        exec(weaponShotGun);
	exec(weaponShockwave);
	exec(weaponRailgun);
	exec(weaponVulcan);
  	exec(weaponFlamer);
	exec(weaponAngelFire);
	exec(weaponHeavensfury);
	exec(weaponFixit);
        //exec(weaponMassDriver);
	exec(weaponHellfire);
	exec(weaponPhaseDisrupter);
	exec(weaponFlameThrower);
	exec(weaponHDiscLauncher);
	exec(weaponBabyNuke);
	exec(weaponrubbermortar);
	exec(weaponautocannon);
	exec(weaponparticlebeam);
	exec(weaponTargetLaser);
	exec(weaponpulsecannon);
	exec(weaponoslauncher);
	exec(weaponTankShredder);
	exec(weaponTankRPG);
	exec(weaponTankRocketLauncher);
	exec(weaponTankBlastCannon);
	exec(weaponJailgun);
	exec(weaponMineLauncher);
	exec(weaponStinger);
	exec(weaponBeaconGun);
   echo('>> Loading spells');
	exec(spellFlameStrike);
	exec(spellFlameThrower);
	exec(spellDeathRay);
	exec(spellShockingGrasp);
	exec(spellDisarmer);
	exec(spellStasis);
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packCloak);
	exec(packCommand);
	exec(packEnergy);
	exec(packJammer);
	exec(packRepair);
	exec(packShield);
	exec(packStealthShield);
	exec(packSuicide);
	exec(packTNT);
	exec(packRegeneration);
	exec(packPhaseShifter);
	exec(packChameleon);
	exec(packTarget);
   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);
	exec(miscRepairPatch);
   echo('>> Loading deploy functions');
	exec(deployFunctions);
   echo('>> Loading deployable sensors');
	exec(deployPulseSensor);
	exec(deployMotionSensor);
        exec(deployCamera);
	exec(deploySensorJammer);
   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
	exec(deploySmallCommandStation);         
	exec(deployForceField);
	exec(deployForceFieldDoors);
	exec(deployBlastWall);
	exec(deployPlatform);
	exec(deploySpringboard);
	exec(deployAccelerator);
	exec(deployTeleporter);
	exec(deployVehicles);
	exec(deployBaseCloak);
	exec(deployJailPack);
	exec(deployMannequin);
	exec(deployTree);
   echo('>> Loading remote base objects');
	exec(deployBorgCube);
	exec(deployDropShipDS);
	exec(deployDropShipSW);
	//exec(deployAirbase);
	exec(deployBunkerPack);
   echo('>> Loading generation objects');
	exec(powerFunctions);
	exec(deployMobileInv);
	exec(deployGenerator);
	exec(deploySolarPanel);
	exec(deploySatSystem);
	exec(deployPowerNode);
	exec(deployShieldGen);	
	exec(deployShieldNode);
   echo('>> Drones');
	exec(packSurveyDroid);
	exec(packProbeDroid);
	exec(packSuicideDroid);
}
	
function serverAnnihilation::Turrets()
{
   echo('>> Loading deployable weapons');
	exec(deployIonTurret);
	exec(deployIrradiationTurret);
	exec(deployLaserTurret);
	exec(deployMissileTurret);
	exec(deployMortarTurret);
	exec(deployShockTurret);
	exec(deployPlasmaTurret);
	exec(deployFusionTurret);
	exec(deployRailTurret);
        exec(deployVortexTurret);
	exec(deployMMTurret);
	exec(deployNuclearTurret);
	exec(deployFlameTurret);
	exec(deployParticleBeamTurret);
}

function serverAnnihilation::Vehicles()
{
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	exec(vehicleWraith);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
}	

function serverAnnihilation::Others()
{
   echo('>> Others');
}

function serverAnnihilation::InitializeMission()
{	// Initialize vehicles
	vehicleFighter::Initialize();
	vehicleInterceptor::Initialize();
	vehicleWraith::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();

	// Initialize deployables
	deployAccelerator::Initialize();
	deployAirbase::Initialize();
	deployBaseCloak::Initialize();
	deployBlastWall::Initialize();
	deployBorgCube::Initialize();
	deployBunkerpack::Initialize();
	deployDropShipDS::Initialize();
	deployDropShipSW::Initialize();
	deployForceField::Initialize();
	deployForceFieldDoor::Initialize();
	deployJailpack::Initialize();
	deployMannequin::Initialize();
	deployPlatform::Initialize();
	deployMobileInv::Initialize();
	deployMobileGen::Initialize();
	deployPowerNode::Initialize();
	deployPortableSolar::Initialize();
	deploySatSystem::Initialize();
	deployShieldGen::Initialize();
	deployShieldNode::Initialize();
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();
	deploySmallCommandStation::Initialize();
	deploySpringboard::Initialize();
	deployTeleporter::Initialize();
	deployTree::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployFlameTurret::Initialize();
	deployFusionTurret::Initialize();
	deployIonTurret::Initialize();	
	deployIrradiationTurret::Initialize();
	deployLaserTurret::Initialize();
	deployMissileTurret::Initialize();
	deployMMTurret::Initialize();	
	deployMortarTurret::Initialize();
	deployNuclearTurret::Initialize();
	deployParticleBeamTurret::Initialize();
	deployPlasmaTurret::Initialize();
	deployRailTurret::Initialize();
	deployShockTurret::Initialize();
	deployVortexTurret::Initialize();
}
