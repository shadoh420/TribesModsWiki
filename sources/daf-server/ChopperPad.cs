
instant SimGroup "ChopperPad-"@$tmpteam@"-"@$tmpnum {
			center = "0 0 1";
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
