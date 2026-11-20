instant SimGroup "TankYard-"@$tmpteam@"-"@$tmpnum {
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
