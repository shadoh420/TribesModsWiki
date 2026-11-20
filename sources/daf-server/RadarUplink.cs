
instant SimGroup "RadarUplink-"@$tmpteam@"-"@$tmpnum {
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
				UplinkCmd = 1;
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



$lastissat[$tmpteam]=true;
