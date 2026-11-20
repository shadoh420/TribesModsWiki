instant SimGroup "DropBase" {
		instant SimGroup "CommandTent" {
			instant InteriorShape "Bunker" {
				fileName = "flatbrdg512.dis";
				isContainer = "1";
				position = "9.72491 2.00005 4.18894";
				rotation = "0 -2.44332 0";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "flatbrdg512.dis";
				isContainer = "1";
				position = "1.99992 2 4.18894";
				rotation = "0 2.44332 0";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "flatbrdg512.dis";
				isContainer = "1";
				position = "13.4995 2.00003 -3.81102";
				rotation = "0 -1.56998 0";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "flatbrdg512.dis";
				isContainer = "1";
				position = "-1.75 1.99994 -3.81102";
				rotation = "0 1.56998 0";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "PortGenerator";
				name = "";
				position = "2.05267 8.03976 0.5";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Item "Bunker" {
				dataBlock = "RepairPack";
				name = "";
				position = "-3.02498 0.0920105 0.499998";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
				rotates = "True";
				collideable = "False";
				count = "10";
			};
			instant StaticShape "Bunker" {
				dataBlock = "InventoryStation";
				name = "";
				position = "9.18298 8.21123 0";
				rotation = "0 -0 -1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "InventoryStation";
				name = "";
				position = "9.25598 13.6389 0";
				rotation = "0 -0 -1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "CommandStation";
				name = "";
				position = "1.78392 12.5566 0.499998";
				rotation = "0 -0 1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};
		instant SimGroup "RdrUplnk" {
			instant InteriorShape "Bunker" {
				fileName = "bunker6.dis";
				isContainer = "1";
				position = "0 19.9998 -6.99997";
				rotation = "0 0 0";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "CommandStation";
				name = "";
				position = "4.99995 20 0.999997";
				rotation = "0 -0 -1.57078";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "PortGenerator";
				name = "";
				position = "-4.99995 19.9998 0.999997";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Sensor "Bunker" {
				dataBlock = "SataliteUplinkDish";
				name = "";
				position = "0 20 11.9997";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
				shieldStrength = "0.0299999";
			};
		};
		instant SimGroup "Bunker" {
			instant InteriorShape "Bunker" {
				fileName = "ebunker.dis";
				isContainer = "1";
				position = "1.99995 6.39099e-07 -1.89997";
				rotation = "0 0 0";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "PortGenerator";
				name = "";
				position = "5.99991 -2.49994 3.00406e-05";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "InventoryStation";
				name = "";
				position = "4.99991 3.00001 -0.199969";
				rotation = "0 -0 -0.785397";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "AmmoStation";
				name = "";
				position = "-1.5 3.49997 -0.199969";
				rotation = "0 -0 0.785397";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Turret "Bunker" {
				dataBlock = "PlasmaTurret";
				name = "Turret";
				position = "1.99992 3.00004 6.10001";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
				shieldStrength = "0.0299999";
			};
		};
		instant SimGroup "WatchTower" {
			instant InteriorShape "Bunker" {
				fileName = "tank14.dis";
				isContainer = "1";
				position = "9.47709e-05 14.9995 -3";
				rotation = "0 -0 3.14157";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "PortGenerator";
				name = "";
				position = "3.02415 5.99857 5.0486";
				rotation = "0 -0 1.57078";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Sensor "Bunker" {
				dataBlock = "MediumPulseSensor";
				name = "";
				position = "7.29974 4.09991 36.9997";
				rotation = "0 -0 1.57078";
				destroyable = "True";
				deleteOnDestroy = "False";
				shieldStrength = "0.0299999";
			};
			instant Sensor "Bunker" {
				dataBlock = "MediumPulseSensor";
				name = "";
				position = "-6.70006 25.8796 36.9997";
				rotation = "0 -0 -1.5708";
				destroyable = "True";
				deleteOnDestroy = "False";
				shieldStrength = "0.0299999";
			};
			instant InteriorShape "Bunker" {
				fileName = "logo1.dis";
				isContainer = "1";
				position = "7.00004 14.9995 0.499988";
				rotation = "-0.799998 0 3.14157";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "logo1.dis";
				isContainer = "1";
				position = "8.49991 3.9999 10.4997";
				rotation = "-0.799998 0 1.57077";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "logo3.dis";
				isContainer = "1";
				position = "10.9997 1.19988 11.4997";
				rotation = "-1.57045 0 1.57077";
				lightParams = "0 ";
			};
		};
		instant SimGroup "Airstrip" {
			instant InteriorShape "Bunker" {
				fileName = "bunker.dis";
				isContainer = "1";
				position = "-4.99998 -9.99992 -0.499988";
				rotation = "0 -0 3.14158";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "EXPBRIDGE.dis";
				isContainer = "1";
				position = "0.000221884 79.9996 1";
				rotation = "2.7736e-06 -3.14159 -1.27871e-05";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "SolarPanel";
				name = "";
				position = "-4.99247e-05 -17.9997 4.29997";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "JetStation";
				name = "";
				position = "-5.82452e-05 -20.9996 1.01326e-06";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "JetPad";
				name = "";
				position = "5.54717e-05 19.9997 0.2";
				rotation = "0 -0 -5.5472e-06";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};
		instant SimGroup "ChopperPad" {
			instant InteriorShape "Bunker" {
				fileName = "bunker.dis";
				isContainer = "1";
				position = "-4.99998 -9.99992 -0.499988";
				rotation = "0 -0 3.14158";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "etower.dis";
				isContainer = "1";
				position = "5.54746e-05 20 -35.1997";
				rotation = "0 -0 3.14158";
				lightParams = "0 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "SolarPanel";
				name = "";
				position = "-4.99247e-05 -17.9997 4.29997";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "ChopperStation";
				name = "";
				position = "-5.82452e-05 -20.9996 1.01326e-06";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "ChopperPad";
				name = "";
				position = "5.54717e-05 19.9997 0.2";
				rotation = "0 -0 -5.5472e-06";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};
		instant SimGroup "TankPad" {
			instant InteriorShape "Bunker" {
				fileName = "bunker.dis";
				isContainer = "1";
				position = "-4.99998 -9.99992 -0.499988";
				rotation = "0 -0 3.14158";
				lightParams = "0 ";
			};
			instant InteriorShape "Bunker" {
				fileName = "COPMfloatingpad.dis";
				isContainer = "1";
				position = "4.1605e-05 14.9998 -15.4997";
				rotation = "0 -0 3.14158";
				lightParams = "20 4.899999 1 4.899999 1 4.899999 1 4.899999 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 ";
			};
			instant StaticShape "Bunker" {
				dataBlock = "SolarPanel";
				name = "";
				position = "-4.99247e-05 -17.9997 4.29997";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "TankStation";
				name = "";
				position = "-5.82452e-05 -20.9996 1.01326e-06";
				rotation = "0 -0 3.14158";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "TankPad";
				name = "";
				position = "4.16037e-05 14.9997 0.2";
				rotation = "0 -0 -5.5472e-06";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};
		instant SimGroup "Concrete" {
			instant InteriorShape "Bunker" {
				fileName = "iblock.dis";
				isContainer = "1";
				position = "0 34 -4";
				rotation = "0 0 0";
				lightParams = "0 ";
			};
		};
	};