
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                         EMBANKMENTS                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["Embankments"] = 2;
$AAISpawning::QuadrantTrigger[27] = "Embankments";
$AAISpawning::GroupDelay["Embankments", 0] = 0;
$AAISpawning::GroupDelay["Embankments", 1] = 7.5;
$AAISpawning::TriggerWithoutFlag[27] = 1;

function Embankments::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "Embankments D0 (7)";
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-394.508 22.0389 37";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10655";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.033 23.9277 34.8464";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10656";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-400.503 23.7835 35.0145";
						rotation = "0 0 0";
						mark = "10657";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-394.709 22.0937 36.9354";
						rotation = "0 0 0";
						mark = "10658";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-397.611 22.9459 35.9689";
						rotation = "0 0 0";
						mark = "10659";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Infantry Shotgun Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-384.801 -1.85351 16.6309";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10316";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.541 35.0924 50.3583";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10317";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.668 18.3062 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10318";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.25 18.2114 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10319";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.25 18.2673 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10320";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.825 18.3206 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10321";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-347.815 18.1937 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10322";
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
						position = "-389.003 -11.6542 16.5318";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10323";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-393.303 -23.628 21.781";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10324";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-372.321 -52.1732 55.2093";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10325";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.977 -37.4937 37.1295";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10326";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-359.799 -32.0245 37.1295";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10327";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-361.377 -25.7161 37.1292";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10328";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-365.163 -22.4916 39.1297";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10329";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.274 -14.6483 39.1273";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10330";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.444 -15.2723 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10331";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.568 -31.0881 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10332";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.786 -15.9643 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10333";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.107 -14.8784 39.1273";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10334";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.625 -26.8584 39.1309";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10335";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-362.025 -40.9953 39.131";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10336";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-369.003 -26.8768 39.131";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10337";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-392.064 -22.428 21.3346";
						rotation = "0 0 0";
						mark = "10338";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-372.194 -53.3558 56.7084";
						rotation = "0 0 0";
						mark = "10339";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.386 -32.398 37.1292";
						rotation = "0 0 0";
						mark = "10340";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-361.677 -41.1798 39.1309";
						rotation = "0 0 0";
						mark = "10341";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-364.717 -36.1118 39.1311";
						rotation = "0 0 0";
						mark = "10342";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-367.125 -30.7919 39.131";
						rotation = "0 0 0";
						mark = "10343";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.679 -27.1662 39.131";
						rotation = "0 0 0";
						mark = "10344";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-364.571 -21.1813 39.1294";
						rotation = "0 0 0";
						mark = "10345";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.823 -14.1782 39.1274";
						rotation = "0 0 0";
						mark = "10346";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-338.108 -30.9852 39.125";
						rotation = "0 0 0";
						mark = "10347";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.42 -15.7568 39.125";
						rotation = "0 0 0";
						mark = "10348";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.528 -14.4862 39.1273";
						rotation = "0 0 0";
						mark = "10349";
						nostop = "1";
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
						position = "-388.342 -10.481 16.2834";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10350";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-398.66 -0.164905 15.8284";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10351";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-305.625 5.51655 21.8317";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10352";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-307.088 5.84724 21.5625";
						rotation = "0 0 0";
						mark = "10353";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-384.529 -0.859302 16.7733";
						rotation = "0 0 0";
						mark = "10354";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-402.808 33.0235 31.0992";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10355";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-400.126 37.2501 37.5";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10356";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.763 24.7394 38.924";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10357";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.189 32.5192 33.4793";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10358";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.957 24.5965 39.0069";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10359";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.091 31.9952 33.8776";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10360";
					};
				};
			};
			instant SimGroup "Infantry Shotgun Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-391.875 30.3198 34.0845";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10361";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-387.6 14.8955 23.1013";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10362";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.281 15.1216 22.739";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10363";
					};
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-390.778 16.8271 19.2666";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10364";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-393.913 26.652 28.1194";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10365";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-395.71 16.8879 18.5905";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10366";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
		};
//--- export object end ---//
}

function Embankments::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 7.5;
			showname = "Embankments D7.5 (5)";
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.541 14.6033 16.9899";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10367";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.192 9.40327 17.6391";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10368";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-404.506 23.786 21.125";
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
						position = "-407.653 9.71149 17.5324";
						rotation = "0 0 0";
						mark = "10370";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-405.273 23.7592 20.8726";
						rotation = "0 0 0";
						mark = "10371";
						isInitialPath = "-1";
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
						position = "-462.974 20.3482 12.7564";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10372";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-463.102 16.5494 11.7747";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10373";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-463 16.9703 11.8036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10374";
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
						position = "-381.819 -120.663 70.5875";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10316";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-369.358 -65.6817 69.2852";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10313";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-424.014 -25.7431 16.2292";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10314";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-424.125 -25.6275 16.27";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10319";
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
						position = "-379.359 -124.072 70.2246";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10319";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.073 -65.0499 69.1987";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10317";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-370.125 -15.4617 17.375";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10302";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.25 -9.39632 16.6374";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10379";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-464.81 -35.84 28.9009";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10313";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-419.791 -29.5809 20.1556";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10379";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-420 -29.798 20.0646";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10320";
					};
				};
			};
		};
//--- export object end ---//
}
