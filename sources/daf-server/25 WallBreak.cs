
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                          WALL BREAK                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["WallBreak"] = 3;
$AAISpawning::QuadrantTrigger[25] = "WallBreak";
$AAISpawning::GroupDelay["WallBreak", 0] = 7.5;
$AAISpawning::GroupDelay["WallBreak", 1] = 10;
$AAISpawning::GroupDelay["WallBreak", 2] = 2.5;
$AAISpawning::TriggerWithoutFlag[25] = 1;
		
		
		

function WallBreak::AIDelay0()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 7.5;
			spawnall = 1;
			showname = "WallBreak D7.5 (5)";
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.346 -34.4791 33.1619";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10746";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.83 -30.3996 37.1259";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10739";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.077 -19.8528 37.1262";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10743";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.386 -20.0159 37.1271";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10738";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.608 -14.7262 39.1264";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10740";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-357.81 -14.5044 39.1271";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10744";
					};
				};
			};
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.646 -29.5994 33.1658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10272";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.381 -34.8666 33.1616";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10273";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.226 -30.8323 37.1261";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10274";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.45 -20.3611 37.1261";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10275";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.421 -15.392 39.1256";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10276";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.398 -15.805 39.1251";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10277";
					};
				};
			};
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.951 -31 33.1637";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10278";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.798 -28.9845 33.1662";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10279";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.452 -34.6129 33.1618";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10280";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.945 -30.9212 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10281";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.225 -23.7534 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10282";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-343.091 -21.2515 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10283";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-343.945 -19.0106 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10284";
					};
				};
			};
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-353.788 -25.3001 33.1677";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10655";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.23 -30.378 33.1635";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10656";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.252 -26.3358 33.1678";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10657";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.258 -32.3499 33.1635";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10658";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.345 -34.8022 33.1616";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10659";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.928 -30.851 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10660";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.4 -27.4072 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10661";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-341.278 -24.9188 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10662";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-339.875 -26.884 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10663";
					};
				};
			};
			instant SimGroup "Sniper FiftyCal Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.852 117.875 66.6339";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10294";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.607 40.1122 49.1911";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10295";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.912 27.991 38.1325";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10296";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.752 29.2229 37.3579";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10297";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-392.506 21.6501 42.5126";
						rotation = "0 0 0";
						mark = "10298";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.59 29.035 37.5155";
						rotation = "0 0 0";
						mark = "10299";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-392.575 21.9267 42.3004";
						rotation = "0 0 0";
						mark = "10300";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::AIDelay1()
{
//--- export object begin ---//
instant SimGroup "NewDelay" {
			showname = "WallBreak D10 (4)";
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.142 -29.3942 33.1638";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10301";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.475 -25.2225 33.1673";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10302";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.859 -30.2638 33.1638";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10303";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.335 -25.6982 33.1676";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10304";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.915 -31.1093 33.1636";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10305";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.839 -26.4041 33.1676";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10306";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.352 -32.5973 33.1634";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10307";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.595 -34.702 33.1618";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10308";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.795 -31.4956 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10309";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.161 -26.773 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10310";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-341.76 -23.5245 39.125";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10311";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-326.034 -17.4817 25.1149";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10312";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-300.354 -7.8692 24.3609";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10313";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.187 -25.0439 33.1673";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10813";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.975 -23.8788 33.169";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10814";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.125 -25.2283 33.1672";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10815";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.589 -29.1759 33.1641";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10816";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.231 -25.9137 33.1674";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10817";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.077 -30.5707 33.1637";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10818";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.608 -26.2363 33.168";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10819";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.25 -31.2833 33.1639";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10820";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.455 -29.6331 33.1657";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10821";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.856 -34.5953 33.1619";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10822";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.228 -30.9003 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10823";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.5 -19.7966 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10824";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.401 -15.1895 39.1257";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10825";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-306.645 23.5105 26.3414";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10826";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "SpecOps MP5 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-210.67 164.928 66.1302";
						rotation = "0 0 0";
						mark = "10328";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-224.699 80.8376 60.7425";
						rotation = "0 0 0";
						mark = "10329";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-386.542 -4.81478 16.1625";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10268";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-395.52 -10.9663 15.8284";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10272";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-391.125 -22.9689 21.7398";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10274";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.237 -2.26714 19.7767";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10276";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-390.149 -20.0625 20.5771";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10278";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.98 -19.3966 20.5608";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10280";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.134 -2.42318 19.7587";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10282";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::AIDelay2()
{
//--- export object begin ---//
instant SimGroup "NewDelay" {
			showname = "WallBreak D2.5 (7) [1]";
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-329.222 181.66 56.5316";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10330";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-255.924 52.8569 29.2939";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10331";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.605 15.2151 22.9272";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10332";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-258.003 52.9444 29.1842";
						rotation = "0 0 0";
						mark = "10333";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.418 14.0949 22.8577";
						rotation = "0 0 0";
						mark = "10334";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-259.25 39.8079 25.9562";
						rotation = "0 0 0";
						mark = "10335";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Sniper PSG1 Elite Radio" {
				DelayCount = "1";
				DelayID[0] = 0;
				showname = "Sniper PSG1 Elite Radio";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.656 25.9046 40.9957";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10336";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.937 20.7264 39.9957";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10337";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-338 18.9654 39.9957";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10338";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.952 18.9943 39.9957";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10339";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.023 19.0917 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10340";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.918 19.25 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10341";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.144 18.9011 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10342";
					};
				};
				
			};
			instant SimGroup "Infantry Shotgun Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-315.667 -100.037 57.7527";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10266";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-281.635 -28.1332 48.7674";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10267";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.048 2.393 27.9912";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10268";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.049 115.477 69.3144";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10358";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-303.721 31.1733 31.5189";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10359";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-304.382 31.7676 31.5849";
						rotation = "0 0 0";
						mark = "10360";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "SpecOps MP5" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.5 123.5 67.509";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10361";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-365.541 133.033 70.8295";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10362";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.96 48.7175 30.9025";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10363";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-273.017 43.552 28.8965";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10364";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-273.325 43.2959 28.907";
						rotation = "0 0 0";
						mark = "10365";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.974 113.719 69.03";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10366";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.761 108.275 71.6064";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10367";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-280.773 47.5236 31.1383";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10368";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.567 36.3326 28.316";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10369";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.7 36.5527 28.3769";
						rotation = "0 0 0";
						mark = "10370";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-287.654 50.5391 33.2791";
						rotation = "0 0 0";
						mark = "10371";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::Radio0()
{
//--- export object begin ---//
			instant SimGroup "NewDelay" {
					Delay = 0;
					showname = "Sn PSG Eli R D0 (1) [1]";
					instant SimGroup "Infantry SAW Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-368.304 120.3 67.4762";
								rotation = "0 0 0";
								useInitialPath = "-1";
								isInitialPath = "1";
								mark = "10349";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-352.012 22.5537 39.9957";
								rotation = "0 0 0";
								useInitialPath = "-1";
								isInitialPath = "1";
								mark = "10350";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-337.819 22.0429 39.9957";
								rotation = "0 0 0";
								useInitialPath = "0";
								isInitialPath = "-1";
								mark = "10351";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-352.231 22.0329 39.9957";
								rotation = "0 0 0";
								useInitialPath = "0";
								isInitialPath = "-1";
								mark = "10352";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-351.937 22.0284 39.9957";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10353";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-337.875 21.9311 39.9957";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10354";
							};
						};
					};
				};
//--- export object end ---//
}
