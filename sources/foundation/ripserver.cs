//--------------------------------------------------------------------
// Foundation mod custom server script - by Nicodemus - 30.05.2000
//--------------------------------------------------------------------
//
//------------------------------------------------------------
// Notes on adding new items:
//------------------------------------------------------------
//
// 1. Be aware that the order in which you load items in
// here has a direct effect on the order in which they will
// appear in the stations. You can rearrange the order as
// you prefer, but I'd suggest you don't stray too far from
// the defaults. Also be aware that items will always go
// into their default categories. For example: you couldn't
// have the Blaster showing up under 'Armours'.
//
// 2. Be sure to complete the exec command including the ""
// (quotes) & .cs extension. This is really only necessary
// if you place the script in a subdirectory as all the
// default items are in this mod.
//
// 3. All script names are appropriate to the data they
// contain. When deciding on a name for a new item you
// should break it down by category, most general first.
//
// e.g. StaticSensorPulseMedium.cs 
//
// Static: Because it's present at the start of the game,
// and doesn't move during the game.
// Sensor: It's a sensor, dummy!
// Pulse: It's a pulse sensor, not a motion sensor.
// Medium: It's a medium sized item.
//
// You should be able to figure out the rest. :)
//
// Follow these simple rules, and it'll make your life a
// whole lot easier when trying to track down a single script
// file mixed in amongst hundreds.
//
//------------------------------------------------------------
//
//------------------------------------------------------------
// Static items (anything pre-deployed in a map):
//------------------------------------------------------------
// Stations
exec("stations\\StaticStationAmmo.cs");
exec("stations\\StaticStationCommand.cs");
exec("stations\\StaticStationInventory.cs");
exec("stations\\StaticStationVehicle.cs");

// Turrets
exec("turrets\\StaticTurretELF.cs");
exec("turrets\\StaticTurretIndoor.cs");
exec("turrets\\StaticTurretMortar.cs");
exec("turrets\\StaticTurretPlasma.cs");
exec("turrets\\StaticTurretRocket.cs");

// Sensors
exec("sensors\\StaticSensorPulseLarge.cs");
exec("sensors\\StaticSensorPulseMedium.cs");


//------------------------------------------------------------
// Items available through stations (arranged by category):
//------------------------------------------------------------
// Armour:
//--------------------------------------
exec("armours\\ArmourLight.cs");
exec("armours\\ArmourMedium.cs");
exec("armours\\ArmourHeavy.cs");

// Weapons:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts.
exec("weapons\\WeaponBlaster.cs");
exec("weapons\\WeaponChainGun.cs");
exec("weapons\\WeaponPlasmaGun.cs");
exec("weapons\\WeaponGrenadeLauncher.cs");
exec("weapons\\WeaponMortar.cs");
exec("weapons\\WeaponDiscLauncher.cs");
exec("weapons\\WeaponLaserRifle.cs");
exec("weapons\\WeaponTargetingLaser.cs");
exec("weapons\\WeaponEnergyRifle.cs");

// Backpacks:
//--------------------------------------
exec("packs\\PackEnergy.cs");
exec("packs\\PackRepair.cs");
exec("packs\\PackShield.cs");
exec("packs\\PackSensorJammer.cs");
exec("packs\\PackAmmo.cs");

// Deployables:
//--------------------------------------
exec("deployables\\DeployableStationInventory.cs");
exec("deployables\\DeployableStationAmmo.cs");
exec("deployables\\DeployableSensorMotion.cs");
exec("deployables\\DeployableSensorPulse.cs");
exec("deployables\\DeployableSensorJammer.cs");
exec("deployables\\DeployableTurretCamera.cs");
exec("deployables\\DeployableTurret.cs");

// Miscellany:
//--------------------------------------
exec("miscellany\\MiscRepairKit.cs");
exec("miscellany\\MiscMine.cs");
exec("miscellany\\MiscGrenade.cs");
exec("miscellany\\MiscBeacon.cs");

// Ammo:
//--------------------------------------
// NOTE: All ammo data is included in the weapon scripts. This
// is just here as a guide to where you should place the data
// if a seperate ammo script is required.


// Vehicles:
//--------------------------------------
exec("vehicles\\VehicleScout.cs");
exec("vehicles\\VehicleLAPC.cs");
exec("vehicles\\VehicleHAPC.cs");

