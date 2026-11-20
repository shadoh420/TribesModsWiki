//--- export object begin ---//
	instant SimGroup "FakeAirBase" {
		instant SimGroup "AirBase0" {
			instant InteriorShape "Air Base" {
				fileName = "BEMfloatingpad.dis";
				isContainer = "1";
				position = "-5 -5 0";
				rotation = "0 0 0";
				lightParams = "20 4.899999 1 4.899999 1 4.899999 1 4.899999 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 ";
			};
			instant InteriorShape "Air Base" {
				fileName = "BESfloatingPad.dis";
				isContainer = "1";
				position = "0 0 38";
				rotation = "0 3.14156 0";
				lightParams = "9 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 ";
			};
			instant StaticShape "Air Base" {
				dataBlock = "AirBaseForceFieldLarge";
				name = "Air Base";
				position = "5.87456 0 14.5";
				rotation = "0 -0 1.57077";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Air Base Small1" {
				dataBlock = "AirBaseForceFieldSmall";
				name = "Air Base";
				position = "-5.75 2.05 16";
				rotation = "0 -0 1.57077";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Air Base" {
				dataBlock = "AirBaseForceFieldLarge";
				name = "Air Base";
				position = "0 5.87456 14.5";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Air Base Small2" {
				dataBlock = "AirBaseForceFieldSmall";
				name = "Air Base";
				position = "2.02996 -5.75 16";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Vehicle Station" {
				dataBlock = "VehicleStation";
				name = "Air Base Vehicle Station";
				position = "-3.60173 3.95518 16";
				rotation = "0 -0 0.785396";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Vehicle Pad" {
				dataBlock = "VehiclePad";
				name = "Air Base Vehicle Pad";
				position = "-10.6858 -11.1693 16";
				rotation = "0 -0 2.35617";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Inventory Station" {
				dataBlock = "InventoryStation";
				name = "Air Base Inventory Station";
				position = "3.69685 -3.64704 16";
				rotation = "0 -0 -2.35617";
				destroyable = "True";
				deleteOnDestroy = "False";
				group = "8466";
				rTurret = "8468";
				lTurret = "8469";
			};
			instant StaticShape "Command Station" {
				dataBlock = "CommandStation";
				name = "Air Base Command Station";
				position = "4.25584 4.13447 16";
				rotation = "0 -0 -0.785396";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Sensor "MedPulse" {
				dataBlock = "MediumPulseSensor";
				name = "Air Base Pulse Sensor";
				position = "0 0 20.5497";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
				shieldStrength = "0.0299999";
			};
			instant StaticShape "Solar Panel" {
				dataBlock = "SolarPanel";
				name = "Air Base Solar Panel";
				position = "-7.49751 1.43983 16";
				rotation = "0 -0 -1.57077";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Solar Panel" {
				dataBlock = "SolarPanel";
				name = "Air Base Solar Panel";
				position = "1.5801 -7.45508 16";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};
	};
//--- export object end ---//