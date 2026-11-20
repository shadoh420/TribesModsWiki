
instant SimGroup "Watchtower-"@$tmpteam@"-"@$tmpnum {
			center = "0 0 -3";
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
				useLOS = "True";
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
