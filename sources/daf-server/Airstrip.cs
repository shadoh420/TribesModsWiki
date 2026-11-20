
instant SimGroup "Airstrip-"@$tmpteam@"-"@$tmpnum {
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
