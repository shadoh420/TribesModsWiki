
instant SimGroup "Bunker-"@$tmpteam@"-"@$tmpnum {
			center = "2 0 -1.9";
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
