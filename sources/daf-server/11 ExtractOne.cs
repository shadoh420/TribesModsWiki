//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                         EXTRACT ONE                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["ExtractOne"] = 2;
$AAISpawning::QuadrantTrigger[11] = "ExtractOne";
$AAISpawning::GroupDelay["ExtractOne", 0] = 0;
$AAISpawning::GroupDelay["ExtractOne", 1] = 5;


function ExtractOne::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "ExtractOne D0 (6)";
			instant SimGroup "Infantry LAW Vet" {
				mustspawn = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "329.297 111.56 73.654";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10042";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.013 34.3291 41.4283";
						rotation = "0 0 0";
						mark = "10044";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "318.315 24.8841 39.2442";
						rotation = "0 0 0";
						mark = "9988";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.538 33.557 41.2854";
						rotation = "0 0 0";
						mark = "10028";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "318.147 25.0933 39.2211";
						rotation = "0 0 0";
						mark = "9983";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "316.383 29.625 39.8362";
						rotation = "0 0 0";
						mark = "10020";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.655 31.8077 40.6854";
						rotation = "0 0 0";
						mark = "10045";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "317.281 27.2312 39.3714";
						rotation = "0 0 0";
						mark = "10043";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "316.811 28.4268 39.4617";
						rotation = "0 0 0";
						mark = "10063";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "316.044 30.6624 40.2417";
						rotation = "0 0 0";
						mark = "10084";
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
						position = "215.419 29.8481 27.1633";
						rotation = "0 0 0";
						mark = "10126";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "230.557 33.024 27.344";
						rotation = "0 0 0";
						mark = "10127";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "227.479 25.2857 25.4073";
						rotation = "0 0 0";
						mark = "10128";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "263.829 11.4536 22.7317";
						rotation = "0 0 0";
						mark = "10129";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "293.5 -11.21 17.7927";
						rotation = "0 0 0";
						mark = "10130";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "280.269 -33.3878 20.8225";
						rotation = "0 0 0";
						mark = "10131";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "284.354 -17.957 17.2475";
						rotation = "0 0 0";
						mark = "10132";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "280.806 -34.1194 20.8699";
						rotation = "0 0 0";
						mark = "10133";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "287.238 -16.7433 16.9854";
						rotation = "0 0 0";
						mark = "10134";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "288.017 -6.45803 18.4095";
						rotation = "0 0 0";
						mark = "10135";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "272.911 3.45645 20.9448";
						rotation = "0 0 0";
						mark = "10136";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "248.541 18.7883 26.1386";
						rotation = "0 0 0";
						mark = "10137";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "227.591 27.7733 26.0868";
						rotation = "0 0 0";
						mark = "10138";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "227.792 32.1678 27.1489";
						rotation = "0 0 0";
						mark = "10139";
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
						position = "212.264 30.0047 26.2377";
						rotation = "0 0 0";
						mark = "10140";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "216.221 35.766 29.7398";
						rotation = "0 0 0";
						mark = "10141";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "225.075 32.1201 27.1887";
						rotation = "0 0 0";
						mark = "10142";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "221.98 31.4556 27.2154";
						rotation = "0 0 0";
						mark = "10143";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "224.285 31.7008 27.0988";
						rotation = "0 0 0";
						mark = "10144";
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
						position = "233.5 33.4476 27.4766";
						rotation = "0 0 0";
						mark = "10145";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "231.663 28.1428 26.1165";
						rotation = "0 0 0";
						mark = "10146";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "245.954 28.5283 26.519";
						rotation = "0 0 0";
						mark = "10147";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "246.308 28.7531 26.4767";
						rotation = "0 0 0";
						mark = "10148";
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
						position = "234.5 37.1173 28.572";
						rotation = "0 0 0";
						mark = "10149";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "235.273 41.5368 29.1236";
						rotation = "0 0 0";
						mark = "10150";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "246.189 31.6238 26.4846";
						rotation = "0 0 0";
						mark = "10151";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "248.083 35.1668 26.4168";
						rotation = "0 0 0";
						mark = "10152";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "277.772 11.5716 21.2876";
						rotation = "0 0 0";
						mark = "10153";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "304.217 -16.7796 15.0656";
						rotation = "0 0 0";
						mark = "10154";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "330.856 -18.6065 16.0947";
						rotation = "0 0 0";
						mark = "10155";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "313.703 -20.3487 14.5824";
						rotation = "0 0 0";
						mark = "10156";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "330.406 -17.0582 16.8112";
						rotation = "0 0 0";
						mark = "10157";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "285.089 9.42807 21.2688";
						rotation = "0 0 0";
						mark = "10158";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "254.506 34.9813 25.1131";
						rotation = "0 0 0";
						mark = "10159";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "246.469 31.7399 26.4513";
						rotation = "0 0 0";
						mark = "10160";
						isInitialPath = "-1";
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
						position = "151.417 -38.9889 33.2001";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10161";
						useInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "151.219 -39.1223 33.2993";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10162";
					};
				};
			};
		};
//--- export object end ---//
}

function ExtractOne::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 5;
			showname = "ExtractOne D5 (19) [5]";
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "115.467 4.05795 15.7728";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "9983";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "116.183 8.7662 16.331";
						rotation = "0 0 0";
						mark = "9984";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "136.755 6.59701 16.7356";
						rotation = "0 0 0";
						mark = "9985";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "115.693 8.8754 16.421";
						rotation = "0 0 0";
						mark = "9986";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "114.382 11.2683 16.6518";
						rotation = "0 0 0";
						mark = "9987";
					};
				};
			};
			instant SimGroup "Infantry SAW NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "83.8429 15.0416 13.3125";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "9988";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "83.1145 10.3393 13.089";
						rotation = "0 0 0";
						mark = "9989";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "105.804 1.14718 15.2359";
						rotation = "0 0 0";
						mark = "9990";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "127 -8.54166 15.9585";
						rotation = "0 0 0";
						mark = "9991";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "152.519 -8.8125 16.5434";
						rotation = "0 0 0";
						mark = "9992";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "164.91 3.51631 17.9882";
						rotation = "0 0 0";
						mark = "9993";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "186.465 -5.43277 20.2433";
						rotation = "0 0 0";
						mark = "9994";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "197.526 7.26686 21.1723";
						rotation = "0 0 0";
						mark = "9995";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "208.716 4.17099 22.0093";
						rotation = "0 0 0";
						mark = "9996";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "84.7148 13.5506 13.4307";
						rotation = "0 0 0";
						mark = "9997";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "116.128 7.47494 16.2522";
						rotation = "0 0 0";
						mark = "9998";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "126.064 -18.1092 19.0709";
						rotation = "0 0 0";
						mark = "9999";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "158.774 -13.9195 17.7746";
						rotation = "0 0 0";
						mark = "10000";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "171.875 20.5641 28.9876";
						rotation = "0 0 0";
						mark = "10001";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "208.432 3.48691 21.8523";
						rotation = "0 0 0";
						mark = "10002";
					};
				};
			};
			instant SimGroup "SpecOps MP5 NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "117.375 -79.5836 68.1984";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10003";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "123.375 -67.3238 65.3204";
						rotation = "0 0 0";
						mark = "10004";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "141.794 -43.2351 45.8416";
						rotation = "0 0 0";
						mark = "10005";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "157.875 -39 41.5471";
						rotation = "0 0 0";
						mark = "10006";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry SAW" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "119.183 21.4443 26.3028";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10007";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "125.58 23.6223 27.9402";
						rotation = "0 0 0";
						mark = "10008";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry Shotgun Vet NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "89.3038 -24.6111 21.6028";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10009";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "89.4237 -21.554 21.0652";
						rotation = "0 0 0";
						mark = "10010";
					};
				};
			};
			instant SimGroup "Infantry Shotgun" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "157.333 -17.9656 19.2647";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10011";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "182.157 -12.6951 22.4314";
						rotation = "0 0 0";
						mark = "10012";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Radio" {
				showname = "SpecOps MP5 Radio";
				DelayID[0] = "0";
				GroupDelay[0] = "10";
				DelayCount = "1";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "159.875 -19.7558 20.6599";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10013";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "115.572 -2.39114 15.7714";
						rotation = "0 0 0";
						mark = "10014";
					};
				};
				
			};
			instant SimGroup "Infantry M16 Radio" {
				showname = "Infantry M16 Radio";
				DelayID[0] = "1";
				DelayCount = "1";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "102.215 -32.0191 29.84";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10023";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "84.1072 -32.072 29.84";
						rotation = "0 0 0";
						mark = "10024";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "72.4013 -32.5352 29.84";
						rotation = "0 0 0";
						mark = "10025";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "98.7524 -35.8049 29.84";
						rotation = "0 0 0";
						mark = "10026";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "87.0056 -32.4303 29.84";
						rotation = "0 0 0";
						mark = "10027";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "74.8828 -32.3061 29.84";
						rotation = "0 0 0";
						mark = "10028";
					};
				};
			};
			instant SimGroup "Sniper PSG1 Radio" {
				showname = "Sniper PSG1 Radio";
				DelayCount = "0";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "109.125 42.1622 43.1392";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10049";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "129.087 26.7212 45.1875";
						rotation = "0 0 0";
						mark = "10050";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "101.377 22.4232 40.0671";
						rotation = "0 0 0";
						mark = "10051";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "122.75 12.7687 39.8618";
						rotation = "0 0 0";
						mark = "10052";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "106.479 34.98 45";
						rotation = "0 0 0";
						mark = "10053";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "129.143 28.2994 44.7172";
						rotation = "0 0 0";
						mark = "10054";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "123.25 14.3858 40.4744";
						rotation = "0 0 0";
						mark = "10055";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "102.794 23.5357 40.6409";
						rotation = "0 0 0";
						mark = "10056";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "106.5 33.7502 44.5888";
						rotation = "0 0 0";
						mark = "10057";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "108.769 40.6784 43.6175";
						rotation = "0 0 0";
						mark = "10058";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "116.754 30.0151 44.7927";
						rotation = "0 0 0";
						mark = "10059";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "112.186 16.6783 39.6749";
						rotation = "0 0 0";
						mark = "10060";
					};
				};
			};
			instant SimGroup "Infantry Shotgun" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "162.719 24.7545 33.9959";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10061";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "155.206 17.0547 23.2795";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10062";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "168.167 20.6261 29.1121";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "1";
						mark = "10063";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "172.28 23.6337 31.2688";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10064";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "173.027 18.9928 27.4891";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10065";
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
						position = "141.5 15.8053 21.0999";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10066";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "143.693 5.31579 17.0884";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10067";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "153.235 0.921878 16.7139";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10068";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "142.057 10.3391 18.1633";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "1";
						mark = "10069";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "141.601 12.8094 19.5408";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10070";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "139.65 7.35847 20.0747";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10071";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "141.737 12.6917 19.4796";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10072";
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
						position = "159.038 22.3451 30.3059";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10073";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "155.525 16.5483 22.6467";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10074";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "178.445 17.3878 25.1572";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10075";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "182.178 24.039 29.5733";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10076";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "189.39 24.7753 29.8943";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10077";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "182.5 23.9904 29.4245";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10078";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "189.41 24.9294 30.0761";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10079";
					};
				};
			};
			instant SimGroup "Infantry M16" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "198.29 27.1064 31.0481";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10044";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "192.464 25.1834 30.2248";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10043";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "192.678 25.1155 30.1143";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10042";
					};
				};
			};
			instant SimGroup "Infantry M16" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "116.614 -23.578 21.1603";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10083";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "120.781 -23.6584 22.1863";
						rotation = "0 0 0";
						mark = "10084";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "119.718 -21.4189 20.6852";
						rotation = "0 0 0";
						mark = "10085";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "120.012 -21.4466 20.7306";
						rotation = "0 0 0";
						mark = "10086";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "121.051 -23.0583 21.8142";
						rotation = "0 0 0";
						mark = "10087";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function ExtractOne::Radio0()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					delay = 10;
					showname = "Sp MP5 R D10 (2) [2]";
					instant SimGroup "Sniper PSG1" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "199.899 -70.9822 70.5956";
								rotation = "0 0 0";
								mark = "10088";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "181.939 -43.9604 58.5899";
								rotation = "0 0 0";
								mark = "10089";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "210.9 -52.1387 66.456";
								rotation = "0 0 0";
								mark = "10090";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
						};
					};
					instant SimGroup "Sniper PSG1" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "203.571 -69.1259 70.7201";
								rotation = "0 0 0";
								mark = "10091";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "217.125 -56.0105 65.7905";
								rotation = "0 0 0";
								mark = "10092";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "186.222 -51.8076 63.8519";
								rotation = "0 0 0";
								mark = "10093";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "217.254 -56.2097 65.8549";
								rotation = "0 0 0";
								mark = "10094";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "183.542 -50.3806 62.2583";
								rotation = "0 0 0";
								mark = "10095";
							};
						};
					};
				};
//--- export object end ---//
}

function ExtractOne::Radio1()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					delay = 0;
					showname = "In M16 R D0 (3) [3]";
					instant SimGroup "Sniper FiftyCal Vet NoPatrol" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "57.6289 -103.282 55.8061";
								rotation = "0 0 0";
								mark = "10096";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "72.942 -55.7711 43.1379";
								rotation = "0 0 0";
								mark = "10097";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "76.9188 -36.5589 29.84";
								rotation = "0 0 0";
								mark = "10098";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "67.857 -32.2154 27.6718";
								rotation = "0 0 0";
								mark = "10099";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "81.4404 -34.2524 25.2775";
								rotation = "0 0 0";
								mark = "10100";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "92.0202 -30.1987 22.6036";
								rotation = "0 0 0";
								mark = "10101";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "92.301 -31.7679 22.8817";
								rotation = "0 0 0";
								mark = "10102";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "66.2777 -32.7949 28.9204";
								rotation = "0 0 0";
								mark = "10103";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "57.7892 -54.1048 41.6954";
								rotation = "0 0 0";
								mark = "10104";
							};
						};
					};
					instant SimGroup "Infantry Shotgun NoPatrol" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "137.152 -149.848 60.1602";
								rotation = "0 0 0";
								mark = "10105";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "151.64 -69.4446 69.3666";
								rotation = "0 0 0";
								mark = "10106";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "164.875 -59.0499 61.7423";
								rotation = "0 0 0";
								mark = "10107";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "162.084 -36.4793 39.9896";
								rotation = "0 0 0";
								mark = "10108";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "152.406 -28.9115 26.267";
								rotation = "0 0 0";
								mark = "10109";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "151.136 -4.39014 16.5378";
								rotation = "0 0 0";
								mark = "10110";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "159.25 -13.5833 17.6723";
								rotation = "0 0 0";
								mark = "10111";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "167.876 -28.793 33.2991";
								rotation = "0 0 0";
								mark = "10112";
							};
						};
					};
					instant SimGroup "Infantry M16 NoPatrol" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "131.915 -148.684 59.9381";
								rotation = "0 0 0";
								mark = "10113";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "143.905 -64.4251 69.0625";
								rotation = "0 0 0";
								mark = "10114";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "143.415 -64.3624 68.9593";
								rotation = "0 0 0";
								mark = "10115";
							};
						};
					};
				};
//--- export object end ---//
}