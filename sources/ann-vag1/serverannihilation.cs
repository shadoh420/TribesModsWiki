// moved out of functions to this file to conserve memory -Plasmatic	

	exec(admin);
	exec(joinsay);
	exec(Marker);
	exec(Trigger);
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);	
	exec(Item);
	
//armors	
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
	
	exec(Mission);

   echo('>> Loading Weapons');
 	exec(weaponDiscLauncher);  
 	exec(weaponGrenadeLauncher);	
 	exec(weaponPlasmaGun);
 	exec(weaponShotGun);
 	exec(weaponFlameThrower);
 	exec(weaponAcidSpray);//Armagedon
	exec(weaponHDiscLauncher);	
 	exec(weaponJailgun);				
 	exec(weaponRocketLauncher);
 	exec(weaponMortar);	
 	exec(weaponRubberMortar);
 	exec(weaponPulseCannon);
 	exec(weaponShockwave);			
 	exec(weaponStinger);
 	exec(weaponVulcan);			
	exec(weaponAngelFire);
	exec(weaponHeavensfury);
	exec(weaponHeavenRevenge);	    //Armagedon
	exec(weaponSoul);		
	exec(weaponSniperRifle);
	exec(weaponFEBRifle);
	exec(weaponFixit);
	exec(weaponRailgun);
	exec(weaponPhaseDisrupter);
	exec(weaponTankBlastCannon);
	exec(weaponTankShredder);
	exec(weaponTankRocketLauncher);
	exec(weaponTankRPG);
	exec(weaponTankMortar);	    //Armagedon

	exec(weaponBabyNuke);
	exec(weaponOSLauncher);
	exec(weaponParticleBeam);
	exec(weaponTargetLaser);
   echo('<< Weapons Complete');

   echo('>> Loading Spells');
	exec(spellDeathRay);
	exec(spellDisarmer);
	exec(spellFlameStrike);
	exec(spellFlameThrower);
	exec(spellShockingGrasp);
	exec(spellStasis);
   echo('<< Spells Complete');
	
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
	exec(packRegeneration);
	exec(packHover);         //Armagedon
	exec(packShort);         //Armagedon
	exec(packTitanBurst);         //Armagedon
	exec(packBurner);         //Armagedon
	exec(packTrollMagma);         //Armagedon
	exec(packSniper);         //Armagedon
	exec(packHawkEye);         //Armagedon
   echo('<< Packs Complete');

   echo('>> Loading Misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
   echo('<< Misc Complete');
	
   echo('>> Loading Deploy Functions');
	exec(deployFunctions);
   echo('<< Deploy Functions Complete');
	
   echo('>> Loading Deployable Sensors');
	exec(deployCamera);
	exec(deployMotionSensor);
	exec(deploySensorCat);	//Plasmatic
        exec(deployPulseSensor);
	exec(deploySensorJammer);
   echo('<< Deployable Sensors Complete');
	
   echo('>> Loading Deployable Objects');
	exec(deployAmmoStation);
	exec(deployBaseCloak);
	exec(deployCommandStation);
	exec(deployControlJammer);
	exec(deployFighter);
	exec(deployInventoryStation);
	exec(deployJailTower);
	exec(deployJumpPad);
	exec(deployTeleporter);
	exec(deployTransport);
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
	
	exec(Player);
		
	exec(Vehicle);
   echo('>> Loading Vehicles');
	exec(vehicleFighter);
	exec(vehicleInterceptor);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('<< Vehicles Complete');
	
	
	exec(Turret);
   echo('>> Loading Turrets');
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

	exec(StaticShape);
	
	exec(Station);
   echo('>> Loading Stations');
	exec(StationQuick);
	exec(stationAmmoStation);
	exec(stationCommandStation);
	exec(stationDeployableStation);
	exec(stationInventoryStation);
	exec(stationMobileStation);
	exec(stationVehicleStation);
   echo('<< Stations Complete');

	
	exec(Moveable);
	exec(Sensor);

	exec(AI);
	exec(InteriorLight);

	exec(serverItemUsage);
	exec(WeaponCuttingLaser);	//plasmatic builder