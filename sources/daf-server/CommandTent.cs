
instant SimGroup "CommandTent-"@$tmpteam@"-"@$tmpnum {
			center = "2 2 3.189";
			spawns = 1;
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
				useLOS = true;
				name = "";
				position = "2.05267 8.03976 0.5";
				rotation = "0 0 0";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant Item "Bunker" {
				dataBlock = "RepairPack";
				name = "";
				position = "-3.025 0.0 0.5";
				useLOS = true;
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
				useLOS = true;
				rotation = "0 -0 -1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "InventoryStation";
				name = "";
				position = "9.25598 13.6389 0";
				useLOS = true;
				rotation = "0 -0 -1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
			instant StaticShape "Bunker" {
				dataBlock = "CommandStation";
				name = "";
				position = "1.78392 12.5566 0.5";
				useLOS = true;
				rotation = "0 -0 1.59986";
				destroyable = "True";
				deleteOnDestroy = "False";
			};
		};

$opt = "CommandTent";

				instant SimGroup "Drops"
				{
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "1.99992 -2.99995 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "13.9995 14 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "-2 -2.99997 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "-3 13.9998 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "-4 -2.99998 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "14.9995 14 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "15.9995 -2.99986 6.18893";
						rotation = "0 0 0";
					};
					instant Marker "Drop Point" {
						dataBlock = "DropPointMarker";
						name = ""; 
						DBNum = $opt@$tmpnum;
						position = "16.9995 14 6.18893";
						rotation = "0 0 0";
					};
				};
			
$CTLayed[$tmpteam]++;