//---------------------------------------
// Wrote in by +]-[+Armageddon+
//---------------------------------------
// Register objects to be used with the mission editor in this file
// Format is:
//  MissionRegObject MenuCategory Description ConsoleScript...

function MissionRegDis( %MenuGroup, %ItemName )
{
	%DisName = strcat( %ItemName, ".dis" );
	MissionRegObject( %MenuGroup, %ItemName, MissionCreateObject, %ItemName, InteriorShape, %DisName );
}

function MissionRegItem( %MenuGroup, %Desc, %ItemName, %count )
{
	MissionRegObject( %MenuGroup, %Desc, MissionCreateObject, %ItemName, Item, %ItemName, %count, false, true);
}	

//---------------------------------------

MissionRegObject( Mission, Group, MissionCreateObject, "Group", SimGroup );
MissionRegObject( Mission, Set, MissionCreateObject, "Set", SimSet );
MissionRegObject( Mission, Path, MissionCreateObject, "Path", SimPath );
MissionRegObject( Mission, Marker, MissionCreateObject, "Marker", Marker, PathMarker );
MissionRegObject( Mission, "Map Marker", MissionCreateObject, "Map Marker", Marker, MapMarker );
MissionRegObject( Mission, "Drop Point", MissionCreateObject, "Drop Point", Marker, DropPointMarker );
MissionRegObject( Mission, Trigger, MissionCreateObject,GroupTrigger, Trigger, GroupTrigger );
MissionRegObject( Mission, Volume, ME::onCreateVolume);
MissionRegObject( Mission, "Point Light", MissionCreateObject, PointLight, SimLight, Point, 10, 1, 1, 1, 0, 0, 0);

MissionRegObject( Sky, Sky, MissionCreateObject, sky, Sky, ".5", ".5", ".5" );
MissionRegObject( Sky, Planet, MissionCreateObject, planet, Planet );
MissionRegObject( Sky, Starfield, MissionCreateObject, stars, StarField );
MissionRegObject( Sky, Snow, MissionCreateObject, snow, Snowfall, 1, 0, 0, 0 );
MissionRegObject( Sky, Rain, MissionCreateObject, rain, Snowfall, 1, 0, 0, 1 );

MissionRegObject( Objectives, "Flag", ME::AddFlag);
MissionRegObject( Objectives, "Flag Stand", MissionCreateObject, Stand, StaticShape, FlagStand );
MissionRegObject( Objectives, "Tower Switch", ME::AddTowerSwitch);

MissionRegObject( Stations, "Inventory", MissionCreateObject, InventoryStation, StaticShape, InventoryStation );
MissionRegObject( Stations, "Ammo", MissionCreateObject, AmmoStation, StaticShape, AmmoStation );
MissionRegObject( Stations, "Command", MissionCreateObject, CommandStation, StaticShape, CommandStation );
MissionRegObject( Stations, "Vehicle", MissionCreateObject, VehicleStation, StaticShape, VehicleStation );
MissionRegObject( Stations, "Vehicle Pad", MissionCreateObject, VehiclePad, StaticShape, VehiclePad);

MissionRegObject( Generators, "Generator", MissionCreateObject, Generator, StaticShape, Generator );
MissionRegObject( Generators, "Portable Generator", MissionCreateObject, PortGen, StaticShape, PortGenerator );
MissionRegObject( Generators, "Solar Panel", MissionCreateObject, Solar, StaticShape, SolarPanel );

MissionRegObject( Turrets, "Plasma Turret",  MissionCreateObject, plasmaTurret, Turret, plasmaTurret );
MissionRegObject( Turrets, "Indoor Turret",  MissionCreateObject, indoorTurret, Turret, indoorTurret );
MissionRegObject( Turrets, "Mortar Turret",  MissionCreateObject, mortarTurret, Turret, mortarTurret );
MissionRegObject( Turrets, "Rocket Turret",  MissionCreateObject, rocketTurret, Turret, rocketTurret );
MissionRegObject( Turrets, "ELF Turret",     MissionCreateObject, ELFTurret,    Turret, ELFTurret );

MissionRegObject( Panels, "Square", MissionCreateObject, SquarePanel, StaticShape, SquarePanel );
MissionRegObject( Panels, "Vertical", MissionCreateObject, VerticalPanel, StaticShape, VerticalPanel );
MissionRegObject( Panels, "Blue", MissionCreateObject, BluePanel, StaticShape, BluePanel );
MissionRegObject( Panels, "Yellow", MissionCreateObject, YellowPanel, StaticShape, YellowPanel );
MissionRegObject( Panels, "Set", MissionCreateObject, SetPanel, StaticShape, SetPanel );
MissionRegObject( Panels, "Vertical2", MissionCreateObject, "VertPanel2", StaticShape, VerticalPanelB );
MissionRegObject( Panels, "Display1", MissionCreateObject, "Display1", StaticShape, DisplayPanelOne );
MissionRegObject( Panels, "Display2", MissionCreateObject, "Display2", StaticShape, DisplayPanelTwo );
MissionRegObject( Panels, "Display3", MissionCreateObject, "Display3", StaticShape, DisplayPanelThree );
MissionRegObject( Panels, "DisplayH1", MissionCreateObject, "DisplayH1", StaticShape, HOnePanel );
MissionRegObject( Panels, "DisplayH2", MissionCreateObject, "DisplayH2", StaticShape, HTwoPanel );
MissionRegObject( Panels, "DisplayS1", MissionCreateObject, "DisplayS1", StaticShape, SOnePanel );
MissionRegObject( Panels, "DisplayS2", MissionCreateObject, "DisplayS2", StaticShape, STwoPanel );
MissionRegObject( Panels, "DisplayV1", MissionCreateObject, "DisplayV1", StaticShape, VOnePanel );
MissionRegObject( Panels, "DisplayV2", MissionCreateObject, "DisplayV2", StaticShape, VTwoPanel );

MissionRegItem( PaintGuns, "WDP IR3 Angel 2002", Angel, 1);
MissionRegItem( PaintGuns, "Shocktech Autococker", AutoCocker, 1);
MissionRegItem( PaintGuns, "AWPT Shotgun", AWPTShotgun, 1);
MissionRegItem( PaintGuns, "AWTP Bunker Thumper", Bunker, 1);
MissionRegItem( PaintGuns, "ADG MiniMag", Delta, 1);
MissionRegItem( PaintGuns, "M3 Dragun LCD", Dragun, 1);
MissionRegItem( PaintGuns, "Diablo Inferno T3 Model", Inferno, 1);
MissionRegItem( PaintGuns, "Bob Long Intimidator GZ", Intimidator, 1);
MissionRegItem( PaintGuns, "M-79 PB Gren Launcher", M79, 1);
MissionRegItem( PaintGuns, "Diablo Mongoose LCD", Mongoose, 1);
MissionRegItem( PaintGuns, "Psycho Ballistic Lightning", Psycho, 1);
MissionRegItem( PaintGuns, "Spyder E-99", Spyder, 1);
MissionRegItem( PaintGuns, "Tippmann 98 Sniper", TipmannS, 1);

MissionRegItem( PaintClip, "WDP IR3 Angel Clip", AngelClip,1);
MissionRegItem( PaintClip, "Shocktech Autococker Clip", AutoCockerClip,1);
MissionRegItem( PaintClip, "ADG MiniMag Clip", DeltaClip,1);
MissionRegItem( PaintClip, "M3 Dragun LCD Clip", AngelClip,1);
MissionRegItem( PaintClip, "Diablo Inferno T3 Model Clip", InfernoClip,1);
MissionRegItem( PaintClip, "Bob Long Intimidator GZ Clip", IntimidatorClip,1);
MissionRegItem( PaintClip, "Diablo Mongoose LCD Clip", MongooseClip,1);
MissionRegItem( PaintClip, "Psycho Ballistic Clip", PsychoClip,1);
MissionRegItem( PaintClip, "Spyder E-99 Clip", SpyderClip,1);
MissionRegItem( PaintClip, "Tippmann 98 Sniper Clip", TipmannSClip,1);

MissionRegItem( PaintAmmo, "WDP IR3 Angel Ammo", AngelAmmo,50);
MissionRegItem( PaintAmmo, "Shocktech Autococker Ammo", AutoCockerAmmo,50);
MissionRegItem( PaintAmmo, "AWPT Shotgun Ammo", AWPTShotgunAmmo,4);
MissionRegItem( PaintAmmo, "AWTP Bunker Thumper Ammo", BunkerAmmo,2);
MissionRegItem( PaintAmmo, "ADG MiniMag Ammo", DeltaAmmo,10);
MissionRegItem( PaintAmmo, "M3 Dragun LCD Ammo", AngelAmmo,50);
MissionRegItem( PaintAmmo, "Diablo Inferno T3 Model Ammo", InfernoAmmo,50);
MissionRegItem( PaintAmmo, "Bob Long Intimidator GZ Ammo", IntimidatorAmmo,50);
MissionRegItem( PaintAmmo, "M-79 PB Gren Launcher Ammo", M79Ammo,5);
MissionRegItem( PaintAmmo, "Diablo Mongoose LCD Ammo", MongooseAmmo,50);
MissionRegItem( PaintAmmo, "Psycho Ballistic Ammo", PsychoAmmo,50);
MissionRegItem( PaintAmmo, "Spyder E-99 Ammo", SpyderAmmo,50);
MissionRegItem( PaintAmmo, "Tippmann 98 Sniper Ammo", TipmannSAmmo,50);

MissionRegItem( PaintCammo, "Desert Camo", Camo, 1 );
MissionRegItem( PaintCammo, "Forest Camo", Camo2, 1);
MissionRegItem( PaintCammo, "Jungle Camo", Camo3, 1);
MissionRegItem( PaintCammo, "Micro Mesh Black", MicroBlk, 1);
MissionRegItem( PaintCammo, "Micro Mesh Brown", MicroBrn, 1);

MissionRegItem( PaintAddon, "Flash Light", FLPack, 1 );
MissionRegItem( PaintAddon, "Laser Scope", TLPack, 1);
MissionRegItem( PaintAddon, "Supply Pack", SuPack, 1);

MissionRegItem( PaintMisc, "Paint Mines", MineAmmo, 2 );
MissionRegItem( PaintMisc, "Paint Grenades", OriginalGrenade, 4);
MissionRegItem( PaintMisc, "Smoke Bomb", SmokerGrenade, 2);
MissionRegItem( PaintMisc, "Flash Bang", FlareGrenade, 3);

MissionRegObject( Stations, "*Deployable Inventory", MissionCreateObject, DeployableInvPack, StaticShape, DeployableInvPack );
MissionRegObject( Stations, "*Deployable Ammo", MissionCreateObject, DeployableAmmoPack, StaticShape, DeployableAmmoPack );

MissionRegObject( Turrets, "*Camera", MissionCreateObject, CameraTurret, Turret, CameraTurret );
MissionRegObject( Turrets, "*Deployable Turret", MissionCreateObject, DeployableTurret, Turret, DeployableTurret );

MissionRegObject( FakeTurret, "*ChainTurret", MissionCreateObject, chainturretEd, StaticShape, chainturretEd );
MissionRegObject( FakeTurret, "*GunTurret", MissionCreateObject, gunturetEd, StaticShape, gunturetEd );
MissionRegObject( FakeTurret, "*HellFireGun", MissionCreateObject, hellfiregunEd, StaticShape, hellfiregunEd );

MissionRegObject( PlayerModels, "*LightM", MissionCreateObject, larmorEd, StaticShape, larmorEd );
MissionRegObject( PlayerModels, "*MediumM", MissionCreateObject, marmorEd, StaticShape, marmorEd );
MissionRegObject( PlayerModels, "*Heavy", MissionCreateObject, harmorEd, StaticShape, harmorEd );
MissionRegObject( PlayerModels, "*LightF", MissionCreateObject, lfemaleEd, StaticShape, lfemaleEd );
MissionRegObject( PlayerModels, "*MediumF", MissionCreateObject, mfemaleEd, StaticShape, mfemaleEd );
MissionRegObject( PlayerModels, "*lflame", MissionCreateObject, lflameEd, StaticShape, lflameEd );
MissionRegObject( PlayerModels, "*mflame", MissionCreateObject, mflameEd, StaticShape, mflameEd );
MissionRegObject( PlayerModels, "*hflame", MissionCreateObject, hflameEd, StaticShape, hflameEd );

MissionRegObject( AmmoShapes, "*ammo1", MissionCreateObject, ammo1Ed, StaticShape, ammo1Ed );
MissionRegObject( AmmoShapes, "*ammo2", MissionCreateObject, ammo2Ed, StaticShape, ammo2Ed );
MissionRegObject( AmmoShapes, "*discammo", MissionCreateObject, discammoEd, StaticShape, discammoEd );
MissionRegObject( AmmoShapes, "*grenammo", MissionCreateObject, grenammoEd, StaticShape, grenammoEd );
MissionRegObject( AmmoShapes, "*mineammo", MissionCreateObject, mineammoEd, StaticShape, mineammoEd );
MissionRegObject( AmmoShapes, "*mortarammo", MissionCreateObject, mortarammoEd, StaticShape, mortarammoEd );
MissionRegObject( AmmoShapes, "*plasammo", MissionCreateObject, plasammoEd, StaticShape, plasammoEd );

MissionRegObject( Projectiles, "*Flame", MissionCreateObject, Flame, StaticShape, Flame );
MissionRegObject( Projectiles, "*Fire", MissionCreateObject, Fire, StaticShape, Fire );
MissionRegObject( Projectiles, "*Ice", MissionCreateObject, Ice, StaticShape, Ice );
MissionRegObject( Projectiles, "*Tracer Bullet", MissionCreateObject, TracerBullet, StaticShape, TracerBullet );
MissionRegObject( Projectiles, "*Disc", MissionCreateObject, Disc, StaticShape, Disc );
MissionRegObject( Projectiles, "*Missle", MissionCreateObject, Missle, StaticShape, Missle );
MissionRegObject( Projectiles, "*Grenade", MissionCreateObject, GrenadeFire, StaticShape, GrenadeFire );
MissionRegObject( Projectiles, "*Mortar", MissionCreateObject, MortarFire, StaticShape, MortarFire );
MissionRegObject( Projectiles, "*Paint", MissionCreateObject, PaintEd, StaticShape, PaintEd );
MissionRegObject( Projectiles, "*Fusion", MissionCreateObject, fusionboltEd, StaticShape, fusionboltEd );

MissionRegObject( Explosions, "*RocketEx", MissionCreateObject, bluexEd, StaticShape, bluexEd );
MissionRegObject( Explosions, "*BulletEx", MissionCreateObject, chainspkEd, StaticShape, chainspkEd );
MissionRegObject( Explosions, "*EnergyEx", MissionCreateObject, enexEd, StaticShape, enexEd );
MissionRegObject( Explosions, "*GrenadeEx", MissionCreateObject, fieryEd, StaticShape, fieryEd );
MissionRegObject( Explosions, "*FlashSmEx", MissionCreateObject, flash_smallEd, StaticShape, flash_smallEd );
MissionRegObject( Explosions, "*FlashMdEx", MissionCreateObject, flash_mediumEd, StaticShape, flash_mediumEd );
MissionRegObject( Explosions, "*FlashLgEx", MissionCreateObject, flash_largeEd, StaticShape, flash_largeEd );
MissionRegObject( Explosions, "*FusionEx", MissionCreateObject, fusionexEd, StaticShape, fusionexEd );
MissionRegObject( Explosions, "*LaserEx", MissionCreateObject, laserhitEd, StaticShape, laserhitEd );
MissionRegObject( Explosions, "*MortarEx", MissionCreateObject, mortarexEd, StaticShape, mortarexEd );
MissionRegObject( Explosions, "*PlasmaEx", MissionCreateObject, plasmaexEd, StaticShape, plasmaexEd );
MissionRegObject( Explosions, "*ShockWaveSmEx", MissionCreateObject, shockwaveEd, StaticShape, shockwaveEd );
MissionRegObject( Explosions, "*ShockWaveLgEx", MissionCreateObject, shockwave_largeEd, StaticShape, shockwave_largeEd );
MissionRegObject( Explosions, "*BlasterEx", MissionCreateObject, shotgunexEd, StaticShape, shotgunexEd );
MissionRegObject( Explosions, "*DebrisSmEx", MissionCreateObject, tumult_smallEd, StaticShape, tumult_smallEd );
MissionRegObject( Explosions, "*DebrisMdEx", MissionCreateObject, tumult_mediumEd, StaticShape, tumult_mediumEd );
MissionRegObject( Explosions, "*DebrisLgEx", MissionCreateObject, tumult_largeEd, StaticShape, tumult_largeEd );

MissionRegObject( Trails, "*MortarTrail", MissionCreateObject, mortartrailEd, StaticShape, mortartrailEd );
MissionRegObject( Trails, "*PlasmaTrail", MissionCreateObject, plasmatrailEd, StaticShape, plasmatrailEd );
MissionRegObject( Trails, "*PlasTrail", MissionCreateObject, plastrailEd, StaticShape, plastrailEd );
MissionRegObject( Trails, "*RSmoke", MissionCreateObject, rsmokeEd, StaticShape, rsmokeEd );
MissionRegObject( Trails, "*Smoke", MissionCreateObject, smokeEd, StaticShape, smokeEd );
MissionRegObject( Trails, "*SnowPlume", MissionCreateObject, snowplumeEd, StaticShape, snowplumeEd );

MissionRegObject( NonPwrUnits, "*AmmoPad", MissionCreateObject, ammopadEd, StaticShape, ammopadEd );
MissionRegObject( NonPwrUnits, "*AmmoUnit", MissionCreateObject, ammounitEd, StaticShape, ammounitEd );
MissionRegObject( NonPwrUnits, "*AmmoRemote", MissionCreateObject, ammounit_remoteEd, StaticShape, ammounit_remoteEd );
MissionRegObject( NonPwrUnits, "*CmdPanel", MissionCreateObject, cmdpnlEd, StaticShape, cmdpnlEd );
MissionRegObject( NonPwrUnits, "*Command", MissionCreateObject, commandEd, StaticShape, commandEd );
MissionRegObject( NonPwrUnits, "*EnergyPad", MissionCreateObject, enerpadEd, StaticShape, enerpadEd );
MissionRegObject( NonPwrUnits, "*Gen", MissionCreateObject, generatorEd, StaticShape, generatorEd );
MissionRegObject( NonPwrUnits, "*Gen-P", MissionCreateObject, generator_pEd, StaticShape, generator_pEd );
MissionRegObject( NonPwrUnits, "*Inv.Sta", MissionCreateObject, inventory_staEd, StaticShape, inventory_staEd );
MissionRegObject( NonPwrUnits, "*Inv.Rmt", MissionCreateObject, invent_remoteEd, StaticShape, invent_remoteEd );
MissionRegObject( NonPwrUnits, "*Radar", MissionCreateObject, radarEd, StaticShape, radarEd );
MissionRegObject( NonPwrUnits, "*RadarSm", MissionCreateObject, radar_smallEd, StaticShape, radar_smallEd );
MissionRegObject( NonPwrUnits, "*Remote Turret", MissionCreateObject, remoteturretEd, StaticShape, remoteturretEd );
MissionRegObject( NonPwrUnits, "*Sat Big", MissionCreateObject, sat_bigEd, StaticShape, sat_bigEd );
MissionRegObject( NonPwrUnits, "*Sensor Jam", MissionCreateObject, sensor_jammerEd, StaticShape, sensor_jammerEd );
MissionRegObject( NonPwrUnits, "*Sensor Pulse", MissionCreateObject, sensor_pulse_medEd, StaticShape, sensor_pulse_medEd );
MissionRegObject( NonPwrUnits, "*Sensor Small", MissionCreateObject, sensor_smallEd, StaticShape, sensor_smallEd );
MissionRegObject( NonPwrUnits, "*Solar Big", MissionCreateObject, solarEd, StaticShape, solarEd );
MissionRegObject( NonPwrUnits, "*Solar Reg", MissionCreateObject, solar_medEd, StaticShape, solar_medEd );
MissionRegObject( NonPwrUnits, "*Tele Sqr", MissionCreateObject, teleport_squareEd, StaticShape, teleport_squareEd );
MissionRegObject( NonPwrUnits, "*Tele Vert", MissionCreateObject, teleport_verticalEd, StaticShape, teleport_verticalEd );
MissionRegObject( NonPwrUnits, "*Tower", MissionCreateObject, towerEd, StaticShape, towerEd );

MissionRegObject( PoweredDown, "*PwrdElectricBeam", MissionCreateObject, PwrdElectrBeam, StaticShape, PoweredElectricalBeam );
MissionRegObject( PoweredDown, "*PwrdBigElectricBeam", MissionCreateObject, PwrdElectrBeamBig, StaticShape, PoweredElectricalBeamBig );
MissionRegObject( PoweredDown, "*PwrdShield", MissionCreateObject, PoweredShield1, StaticShape, PoweredShield1 );
MissionRegObject( PoweredDown, "*PwrdMediumShield", MissionCreateObject, PoweredShieldMedium1, StaticShape, PoweredShieldMedium1 );
MissionRegObject( PoweredDown, "*PwrdLargeShield", MissionCreateObject, PoweredShieldLarge1, StaticShape, PoweredShieldLarge1 );
MissionRegObject( PoweredDown, "*PwrdFlame", MissionCreateObject, PoweredFlame, StaticShape, PoweredFlame );
MissionRegObject( PoweredDown, "*PwrdFire", MissionCreateObject, PoweredFire, StaticShape, PoweredFire );
MissionRegObject( PoweredDown, "*PwrdIce", MissionCreateObject, PoweredIce, StaticShape, PoweredIce );
MissionRegObject( PoweredDown, "*PwrdTracer", MissionCreateObject, PoweredTracerBullet, StaticShape, PoweredTracerBullet );
MissionRegObject( PoweredDown, "*PwrdDisc", MissionCreateObject, PoweredDisc, StaticShape, PoweredDisc );
MissionRegObject( PoweredDown, "*PwrdMissle", MissionCreateObject, PoweredMissle, StaticShape, PoweredMissle );
MissionRegObject( PoweredDown, "*PwrdGrenade", MissionCreateObject, PoweredGrenadeFire, StaticShape, PoweredGrenadeFire );
MissionRegObject( PoweredDown, "*PwrdMortar", MissionCreateObject, PoweredMortarFire, StaticShape, PoweredMortarFire );
MissionRegObject( PoweredDown, "*PwrdFlyer", MissionCreateObject, PwrdStaticFlyer, StaticShape, PwrdStaticFlyer );
MissionRegObject( PoweredDown, "*PwrdLAPC", MissionCreateObject, PwrdStaticLAPC, StaticShape, PwrdStaticLAPC );
MissionRegObject( PoweredDown, "*PwrdHAPC", MissionCreateObject, PwrdStaticHAPC, StaticShape, PwrdStaticHAPC );

MissionRegObject( PoweredUp, "*PwrdUpElectricBeam", MissionCreateObject, PwrdUpElectrBeam, StaticShape, PoweredUpElectricalBeam );
MissionRegObject( PoweredUp, "*PwrdUpBigElectricBeam", MissionCreateObject, PwrdUpElectrBeamBig, StaticShape, PoweredUpElectricalBeamBig );
MissionRegObject( PoweredUp, "*PwrdUpShield", MissionCreateObject, PoweredUpShield1, StaticShape, PoweredUpShield1 );
MissionRegObject( PoweredUp, "*PwrdUpMediumShield", MissionCreateObject, PoweredUpShieldMedium1, StaticShape, PoweredUpShieldMedium1 );
MissionRegObject( PoweredUp, "*PwrdUpLargeShield", MissionCreateObject, PoweredUpShieldLarge1, StaticShape, PoweredUpShieldLarge1 );
MissionRegObject( PoweredUp, "*PwrdUpFlame", MissionCreateObject, PoweredUpFlame, StaticShape, PoweredUpFlame );
MissionRegObject( PoweredUp, "*PwrdUpFire", MissionCreateObject, PoweredUpFire, StaticShape, PoweredUpFire );
MissionRegObject( PoweredUp, "*PwrdUpIce", MissionCreateObject, PoweredUpIce, StaticShape, PoweredUpIce );
MissionRegObject( PoweredUp, "*PwrdUpTracer", MissionCreateObject, PoweredUpTracerBullet, StaticShape, PoweredUpTracerBullet );
MissionRegObject( PoweredUp, "*PwrdUpDisc", MissionCreateObject, PoweredUpDisc, StaticShape, PoweredUpDisc );
MissionRegObject( PoweredUp, "*PwrdUpMissle", MissionCreateObject, PoweredUpMissle, StaticShape, PoweredUpMissle );
MissionRegObject( PoweredUp, "*PwrdUpGrenade", MissionCreateObject, PoweredUpGrenadeFire, StaticShape, PoweredUpGrenadeFire );
MissionRegObject( PoweredUp, "*PwrdUpMortar", MissionCreateObject, PoweredUpMortarFire, StaticShape, PoweredUpMortarFire );
MissionRegObject( PoweredUp, "*PwrdUpFlyer", MissionCreateObject, PwrdUpStaticFlyer, StaticShape, PwrdUpStaticFlyer );
MissionRegObject( PoweredUp, "*PwrdUpLAPC", MissionCreateObject, PwrdUpStaticLAPC, StaticShape, PwrdUpStaticLAPC );
MissionRegObject( PoweredUp, "*PwrdUpHAPC", MissionCreateObject, PwrdUpStaticHAPC, StaticShape, PwrdUpStaticHAPC );

MissionRegObject( ShieldShapes, "*Shield", MissionCreateObject, Shield1, StaticShape, Shield1 );
MissionRegObject( ShieldShapes, "*Shield Medium", MissionCreateObject, ShieldMedium1, StaticShape, ShieldMedium1 );
MissionRegObject( ShieldShapes, "*Shield Large", MissionCreateObject, ShieldLarge1, StaticShape, ShieldLarge1 );

MissionRegObject( Misc, "*Mine", MissionCreateObject, AntipersonelMine, Mine, AntipersonelMine );
MissionRegObject( Misc, "*Minefield", ME::PasteFile, "minefield.cs" );

MissionRegObject( CrashedVehicles, "*CrashedScout", MissionCreateObject, StaticFlyer, StaticShape, StaticFlyer );
MissionRegObject( CrashedVehicles, "*CrashedLAPC", MissionCreateObject, StaticLAPC, StaticShape, StaticLAPC );
MissionRegObject( CrashedVehicles, "*CrashedHAPC", MissionCreateObject, StaticHAPC, StaticShape, StaticHAPC );

MissionRegObject( SpringPads, "*Light Springpad", MissionCreateObject, LightSpringPad, StaticShape, LightSpringPad );
MissionRegObject( SpringPads, "*Standard Springpad", MissionCreateObject, SpringPad, StaticShape, SpringPad );
MissionRegObject( SpringPads, "*Powerful Springpad", MissionCreateObject, MegaSpringPad, StaticShape, MegaSpringPad );

// new elevator macros
MissionRegObject(StpElevMacros, StpElev_4x4, ME::PasteFile, "StpElev_4x4.cs");
MissionRegObject(StpElevMacros, StpElev_4x5, ME::PasteFile, "StpElev_4x5.cs");
MissionRegObject(StpElevMacros, StpElev_5x5, ME::PasteFile, "StpElev_5x5.cs");
MissionRegObject(StpElevMacros, StpElev_6x4, ME::PasteFile, "StpElev_6x4.cs");
MissionRegObject(StpElevMacros, StpElev_6x4t, ME::PasteFile, "StpElev_6x4t.cs");
MissionRegObject(StpElevMacros, StpElev_6x5, ME::PasteFile, "StpElev_6x5.cs");
MissionRegObject(StpElevMacros, StpElev_6x6, ME::PasteFile, "StpElev_6x6.cs");
MissionRegObject(StpElevMacros, StpElev_6x6octa, ME::PasteFile, "StpElev_6x6octa.cs");
MissionRegObject(StpElevMacros, StpElev_6x6t, ME::PasteFile, "StpElev_6x6t.cs");
MissionRegObject(StpElevMacros, StpElev_8x4, ME::PasteFile, "StpElev_8x4.cs");
MissionRegObject(StpElevMacros, StpElev_8x6, ME::PasteFile, "StpElev_8x6.cs");
MissionRegObject(StpElevMacros, StpElev_8x8, ME::PasteFile, "StpElev_8x8.cs");
MissionRegObject(StpElevMacros, StpElev_9x9, ME::PasteFile, "StpElev_9x9.cs");
MissionRegObject(StpElevMacros, StpElev_16x16, ME::PasteFile, "StpElev_16x16.cs");
MissionRegObject(StpElevMacros, markerx3, ME::PasteFile, "markerx3");

MissionRegItem( Packs, "Energy Pack", EnergyPack, 1);
MissionRegItem( Packs, "Repair Pack", RepairPack, 1);
MissionRegItem( Packs, "Shield Pack", ShieldPack, 1);
MissionRegItem( Packs, "Sensor Jammer Pack", SensorJammerPack, 1);
MissionRegItem( Packs, "Ammo Pack", AmmoPack, 1);
MissionRegItem( Packs, "Repair Kit (inventory)", RepairKit, 1);
MissionRegItem( Packs, "Repair Patch (instant)", RepairPatch, 1);

MissionRegObject( Comms, "Small Antenna", MissionCreateObject, AntennaSmall, StaticShape, SmallAntenna );
MissionRegObject( Comms, "Medium Antenna", MissionCreateObject, AntennaMed, StaticShape, MediumAntenna );
MissionRegObject( Comms, "Large Antenna", MissionCreateObject, AntennaLarge, StaticShape, LargeAntenna );
MissionRegObject( Comms, "Antenna Array", MissionCreateObject, AntennaArray, StaticShape, ArrayAntenna );
MissionRegObject( Comms, "Antenna Rod", MissionCreateObject, AntennaRod, StaticShape, RodAntenna );
MissionRegObject( Comms, "Force Beacon", MissionCreateObject, Beacon, StaticShape, ForceBeacon );

MissionRegObject( Sensors, "Remote Pulse Sensor", MissionCreateObject, RmtPulse, Sensor, DeployablePulseSensor );
MissionRegObject( Sensors, "Pulse Sensor", MissionCreateObject, Sensor, Sensor, PulseSensor );
MissionRegObject( Sensors, "Medium Pulse Sensor", MissionCreateObject, MedPulse, Sensor, MediumPulseSensor );
MissionRegObject( Sensors, "Portable Motion Sensor", MissionCreateObject, MotionSens, Sensor, DeployableMotionSensor );

MissionRegObject( Base, "Air Filter", MissionCreateObject, filter, StaticShape, AirFilter );
MissionRegObject( Base, "Cargo Crate", MissionCreateObject, MagCargo, StaticShape, CargoCrate );
MissionRegObject( Base, "Liquid Cylinder", MissionCreateObject, LiquidCyl, StaticShape, CargoBarrel );

MissionRegObject( Doors, "AngleCut-T",  MissionCreateObject, DoorOneTop,  Moveable,  DoorOneTop );
MissionRegObject( Doors, "AngleCut-B", MissionCreateObject, DoorOneBottom, Moveable,  DoorOneBottom );
MissionRegObject( Doors, "RedSpider-L",  MissionCreateObject, DoorOneLeft,  Moveable,  DoorOneLeft );
MissionRegObject( Doors, "RedSpider-R", MissionCreateObject, DoorOneRight, Moveable,  DoorOneRight );
MissionRegObject( Doors, "GreyStaff-L",  MissionCreateObject, DoorTwoLeft,  Moveable,  DoorTwoLeft );
MissionRegObject( Doors, "GreyStaff-R", MissionCreateObject, DoorTwoRight, Moveable,  DoorTwoRight );
MissionRegObject( Doors, "GoldLogo-L",  MissionCreateObject, DoorThreeLeft,  Moveable,  DoorThreeLeft );
MissionRegObject( Doors, "GoldLogo-R", MissionCreateObject, DoorThreeRight, Moveable,  DoorThreeRight );
MissionRegObject( Doors, "GoldMartini-L",   MissionCreateObject, DoorFourLeft,Moveable,  DoorFourLeft );
MissionRegObject( Doors, "GoldMartini-R",  MissionCreateObject, DoorFourRight,  Moveable,  DoorFourRight );
MissionRegObject( Doors, "Red&Blue-L", MissionCreateObject, DoorSixLeft, Moveable,  DoorSixLeft );
MissionRegObject( Doors, "Red&Blue-R", MissionCreateObject, DoorSixRight, Moveable,  DoorSixRight );
MissionRegObject( Doors, "Single", MissionCreateObject, DoorFive, Moveable,  DoorFive );
MissionRegObject( Doors, "ForceField", MissionCreateObject, DoorForceField, Moveable,  DoorForceField );
MissionRegObject( Doors, "ForceField3x4", MissionCreateObject, DoorForceField, Moveable,  DoorForceField3x4 );
MissionRegObject( Doors, "ForceField4x17", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x17 );
MissionRegObject( Doors, "ForceField4x14", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x14 );
MissionRegObject( Doors, "ForceField4x8", MissionCreateObject, DoorForceField, Moveable,  DoorForceField4x8 );
MissionRegObject( Doors, "ForceField5x5", MissionCreateObject, DoorForceField, Moveable,  DoorForceField5x5 );
MissionRegObject( Doors, "Diagonal", MissionCreateObject, DoorDiagonal, Moveable,  DoorDiagonal );

MissionRegObject( Environment, "Tree 1", MissionCreateObject, TreeOne, StaticShape, TreeShape );
MissionRegObject( Environment, "Tree 2", MissionCreateObject, TreeTwo, StaticShape, TreeShapeTwo );
MissionRegObject( Environment, "Cactus1", MissionCreateObject, Cactus1, StaticShape, Cactus1 );
MissionRegObject( Environment, "Cactus2", MissionCreateObject, Cactus2, StaticShape, Cactus2 );
MissionRegObject( Environment, "Cactus3", MissionCreateObject, Cactus3, StaticShape, Cactus3 );
MissionRegObject( Environment, "Plant", MissionCreateObject, PlantTwo, StaticShape, PlantTwo );
MissionRegObject( Environment, "MUD - Grass Vent", MissionCreateObject, GrassVent, StaticShape, SteamOnGrass );
MissionRegObject( Environment, "MUD - Mud Vent", MissionCreateObject, MudVent, StaticShape, SteamOnMud );
MissionRegObject( Environment, "MUD - Grass Vent2", MissionCreateObject, GrassVent, StaticShape, SteamOnGrass2 );
MissionRegObject( Environment, "MUD - Mud Vent2", MissionCreateObject, MudVent, StaticShape, SteamOnMud2 );

MissionRegObject( Misc, "Forcefield", MissionCreateObject, Forcefield, StaticShape, ForceField );
MissionRegObject( Misc, "Electric Beam", MissionCreateObject, ElectrBeam, StaticShape, ElectricalBeam );
MissionRegObject( Misc, "Bigger Elec. Beam", MissionCreateObject, BigElectroBeam, StaticShape, ElectricalBeamBig );
MissionRegObject( Misc, "*ArmorKit", MissionCreateObject, armorkitEd, StaticShape, armorkitEd );
MissionRegObject( Misc, "*ArmorPatch", MissionCreateObject, armorpatchEd, StaticShape, armorpatchEd );
MissionRegObject( Misc, "*BigTwig", MissionCreateObject, bigtwigEd, StaticShape, bigtwigEd );
MissionRegObject( Misc, "*Bridge", MissionCreateObject, bridgeEd, StaticShape, bridgeEd );
MissionRegObject( Misc, "*Direction Arrow", MissionCreateObject, dirarrowsEd, StaticShape, dirarrowsEd );
MissionRegObject( Misc, "*DustPlume", MissionCreateObject, dustplumeEd, StaticShape, dustplumeEd );
MissionRegObject( Misc, "*Plat2", MissionCreateObject, elevpad2Ed, StaticShape, elevpad2Ed );
MissionRegObject( Misc, "*Plat3", MissionCreateObject, elevpad3Ed, StaticShape, elevpad3Ed );
MissionRegObject( Misc, "*End Arrow", MissionCreateObject, endarrowEd, StaticShape, endarrowEd );
MissionRegObject( Misc, "*FF3x4", MissionCreateObject, forcefield_3x4Ed, StaticShape, forcefield_3x4Ed );
MissionRegObject( Misc, "*FF4x8", MissionCreateObject, forcefield_4x8Ed, StaticShape, forcefield_4x8Ed );
MissionRegObject( Misc, "*FF4x14", MissionCreateObject, forcefield_4x14Ed, StaticShape, forcefield_4x14Ed );
MissionRegObject( Misc, "*FF4x17", MissionCreateObject, forcefield_4x17Ed, StaticShape, forcefield_4x17Ed );
MissionRegObject( Misc, "*FF5x5", MissionCreateObject, forcefield_5x5Ed, StaticShape, forcefield_5x5Ed );
MissionRegObject( Misc, "*Evil", MissionCreateObject, logoEd, StaticShape, logoEd );
MissionRegObject( Misc, "*MainPad", MissionCreateObject, mainpadEd, StaticShape, mainpadEd );
MissionRegObject( Misc, "*Spikey", MissionCreateObject, mineEd, StaticShape, mineEd );
MissionRegObject( Misc, "*Mr.Twig", MissionCreateObject, mrtwigEd, StaticShape, mrtwigEd );
MissionRegObject( Misc, "*Wall1", MissionCreateObject, newdoor1_rEd, StaticShape, newdoor1_rEd );
MissionRegObject( Misc, "*Wall2", MissionCreateObject, newdoor1_lEd, StaticShape, newdoor1_lEd );
MissionRegObject( Misc, "*Wall3", MissionCreateObject, newdoor2_rEd, StaticShape, newdoor2_rEd );
MissionRegObject( Misc, "*Wall4", MissionCreateObject, newdoor2_lEd, StaticShape, newdoor2_lEd );
MissionRegObject( Misc, "*Wall5", MissionCreateObject, newdoor3_rEd, StaticShape, newdoor3_rEd );
MissionRegObject( Misc, "*Wall6", MissionCreateObject, newdoor3_lEd, StaticShape, newdoor3_lEd );
MissionRegObject( Misc, "*Wall7", MissionCreateObject, newdoor4_rEd, StaticShape, newdoor4_rEd );
MissionRegObject( Misc, "*Wall8", MissionCreateObject, newdoor4_lEd, StaticShape, newdoor4_lEd );
MissionRegObject( Misc, "*Wall9", MissionCreateObject, newdoor5Ed, StaticShape, newdoor5Ed );
MissionRegObject( Misc, "*Wall10", MissionCreateObject, newdoor6_rEd, StaticShape, newdoor6_rEd );
MissionRegObject( Misc, "*Wall11", MissionCreateObject, newdoor6_lEd, StaticShape, newdoor6_lEd );
MissionRegObject( Misc, "*PlasWall", MissionCreateObject, plasmawallEd, StaticShape, plasmawallEd );
MissionRegObject( Misc, "*Staff", MissionCreateObject, staffEd, StaticShape, staffEd );
MissionRegObject( Misc, "*w64elevpad", MissionCreateObject, w64elevpadEd, StaticShape, w64elevpadEd );

MissionRegObject( Platforms, "Elev:4x4", MissionCreateObject, elevator_4x4,  Moveable, elevator4x4 );
MissionRegObject( Platforms, "Elev:4x5", MissionCreateObject, elevator_4x5,  Moveable, elevator4x5 );
MissionRegObject( Platforms, "Elev:5x5", MissionCreateObject, elevator_5x5,  Moveable, elevator5x5 );
MissionRegObject( Platforms, "Elev:6x4", MissionCreateObject, elevator_6x4, Moveable, elevator6x4 );
MissionRegObject( Platforms, "Elev:6x4_thin", MissionCreateObject, elevator_6x4thin, Moveable, elevator6x4thin );
MissionRegObject( Platforms, "Elev:6x5", MissionCreateObject, elevator_6x5, Moveable, elevator6x5 );
MissionRegObject( Platforms, "Elev:6x6_thin", MissionCreateObject, elevator_6x6thin, Moveable, elevator6x6thin );
MissionRegObject( Platforms, "Elev:6x6", MissionCreateObject, elevator_6x6,  Moveable, elevator6x6 );
MissionRegObject( Platforms, "Elev:6x6_Octa", MissionCreateObject, elevator_6x6_octagon,  Moveable, elevator6x6Octa );
MissionRegObject( Platforms, "Elev:8x4", MissionCreateObject, elevator_8x4,Moveable, elevator8x4 );
MissionRegObject( Platforms, "Elev:8x6", MissionCreateObject, elevator_8x6, Moveable, elevator8x6 );
MissionRegObject( Platforms, "Elev:8x8", MissionCreateObject, elevator_8x8, Moveable, elevator8x8 );
MissionRegObject( Platforms, "Elev:9x9", MissionCreateObject, elevator_9x9, Moveable, elevator9x9 );
MissionRegObject( Platforms, "Elev:16x16_Octa", MissionCreateObject, elevator16x16_octo, Moveable, elevator16x16Octa);

// door groupings
MissionRegObject(DoorMacros, DoubleDoor1, ME::PasteFile, "doubledoor1.cs");
MissionRegObject(DoorMacros, DoubleDoor2, ME::PasteFile, "doubledoor2.cs");
MissionRegObject(DoorMacros, DoubleDoor3, ME::PasteFile, "doubledoor3.cs");
MissionRegObject(DoorMacros, DoubleDoor4, ME::PasteFile, "doubledoor4.cs");
MissionRegObject(DoorMacros, DoubleDoor5, ME::PasteFile, "doubledoor5.cs");
MissionRegObject(DoorMacros, DoubleDoor6, ME::PasteFile, "doubledoor6.cs");
MissionRegObject(DoorMacros, ForceField, ME::PasteFile, "forcefield.cs");
MissionRegObject(DoorMacros, ForceField3x4, ME::PasteFile, "forcefield3x4.cs");
MissionRegObject(DoorMacros, Forcefield4x8, ME::PasteFile, "Forcefield4x8.cs");
MissionRegObject(DoorMacros, Forcefield4x14, ME::PasteFile, "Forcefield4x14.cs");
MissionRegObject(DoorMacros, Forcefield4x17, ME::PasteFile, "Forcefield4x17.cs");
MissionRegObject(DoorMacros, Forcefield5x5, ME::PasteFile, "Forcefield5x5.cs");
MissionRegObject(DoorMacros, SingleDoorRotate, ME::PasteFile, "SingleDoorRotate.cs");
MissionRegObject(DoorMacros, SingleDoorSlide, ME::PasteFile, "SingleDoorSlide.cs");
MissionRegObject(DoorMacros, SingleDoorUp, ME::PasteFile, "SingleDoorUp.cs");

// elevator groupings
MissionRegObject(ElevatorMacros, Elevator4x4, ME::PasteFile, "Elevator4x4.cs");
MissionRegObject(ElevatorMacros, Elevator4x5, ME::PasteFile, "Elevator4x5.cs");
MissionRegObject(ElevatorMacros, Elevator5x5, ME::PasteFile, "Elevator5x5.cs");
MissionRegObject(ElevatorMacros, Elevator6x4, ME::PasteFile, "Elevator6x4.cs");
MissionRegObject(ElevatorMacros, Elevator6x4t, ME::PasteFile, "Elevator6x4t.cs");
MissionRegObject(ElevatorMacros, Elevator6x5, ME::PasteFile, "Elevator6x5.cs");
MissionRegObject(ElevatorMacros, Elevator6x6, ME::PasteFile, "Elevator6x6.cs");
MissionRegObject(ElevatorMacros, Elevator6x6octa, ME::PasteFile, "Elevator6x6octa.cs");
MissionRegObject(ElevatorMacros, Elevator6x6t, ME::PasteFile, "Elevator6x6t.cs");
MissionRegObject(ElevatorMacros, Elevator8x4, ME::PasteFile, "Elevator8x4.cs");
MissionRegObject(ElevatorMacros, Elevator8x6, ME::PasteFile, "Elevator8x6.cs");
MissionRegObject(ElevatorMacros, Elevator8x8, ME::PasteFile, "Elevator8x8.cs");
MissionRegObject(ElevatorMacros, Elevator9x9, ME::PasteFile, "Elevator9x9.cs");
MissionRegObject(ElevatorMacros, Elevator16x16, ME::PasteFile, "Elevator16x16.cs");

//---------------------------------------
exec("registerworld.cs");
exec("registerUserObjects.cs");