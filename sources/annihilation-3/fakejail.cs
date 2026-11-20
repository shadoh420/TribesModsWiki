//--- export object begin ---//
	instant SimGroup "FakeJail" {
		instant InteriorShape "Jail Tower" {
			fileName = "BESfloatingPad.dis";
			isContainer = "1";
			position = "0 0 -1.5";
			rotation = "0 0 0";
			lightParams = "9 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 ";
			inmotion = "true";
		};
		instant StaticShape "Release Swicth" {
			dataBlock = "JailReleaseSwitch";
			name = "Jail Tower";
			position = "0 0 14.1498";
			rotation = "0 3.14156 0";
			destroyable = "True";
			deleteOnDestroy = "False";
			numSwitchTeams = "0";
		};
		instant StaticShape "Jail Tower" {
			dataBlock = "JailWall";
			name = "";
			position = "0 -5.87455 16.0108";
			rotation = "0 0 0";
			destroyable = "True";
			deleteOnDestroy = "False";
		};
		instant StaticShape "Jail Tower" {
			dataBlock = "JailWall";
			name = "";
			position = "0 5.87455 16.0108";
			rotation = "0 0 0";
			destroyable = "True";
			deleteOnDestroy = "False";
		};
		instant StaticShape "Jail Tower" {
			dataBlock = "JailWall";
			name = "";
			position = "-5.87455 0 16.0108";
			rotation = "0 -0 1.57077";
			destroyable = "True";
			deleteOnDestroy = "False";
		};
		instant StaticShape "Jail Tower" {
			dataBlock = "JailWall";
			name = "";
			position = "5.87455 0 16.0108";
			rotation = "0 -0 1.57077";
			destroyable = "True";
			deleteOnDestroy = "False";
		};
		instant InteriorShape "Jail Tower" {
			fileName = "mis_ob1.0.dis";
			isContainer = "1";
			position = "0 0 15";
			rotation = "0 3.14159 0";
			lightParams = "0 ";
			inmotion = "true";
		};
		instant InteriorShape "Jail Tower" {
			fileName = "BESfloatingPad.dis";
			isContainer = "1";
			position = "0 0 39.5216";
			rotation = "0 3.14159 0";
			lightParams = "9 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 0.700000 1 ";
			inmotion = "true";
		};
	};