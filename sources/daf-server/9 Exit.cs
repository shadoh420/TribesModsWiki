
	
//*******************************************************************************************************
//*******************************************************************************************************
//******                                                                                            *****
//******                                            EXIT                                            *****
//******                                                                                            *****
//*******************************************************************************************************
//*******************************************************************************************************
$AAISpawning::DelayCount["Exit"] = 2;
$AAISpawning::QuadrantTrigger[9] = "Exit";
$AAISpawning::GroupDelay["Exit", 0] = 0;
$AAISpawning::GroupDelay["Exit", 1] = 15;
$AAISpawning::TriggerWithoutFlag[9] = 1;

function Exit::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			
			Delay = 0;
			showname = "Exit D0 (17) [3]";
			instant SimGroup "Infantry Shotgun" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "305.811 -72.8579 35.2384";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10392";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "304.879 -68.9627 32.8487";
						rotation = "0 0 0";
						mark = "10393";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "311.784 -27.6586 11.6351";
						rotation = "0 0 0";
						mark = "10394";
						isIntitalPath = "0";
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
						position = "331.375 -0.97928 26.1823";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10395";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "306.25 -1.96675 20.7361";
						rotation = "0 0 0";
						mark = "10396";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "307.838 -19.6789 14.2651";
						rotation = "0 0 0";
						mark = "10397";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "323.275 7.68189 27.8848";
						rotation = "0 0 0";
						mark = "10398";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "307.146 -2.68305 20.5258";
						rotation = "0 0 0";
						mark = "10399";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "330.661 -1.45124 25.6789";
						rotation = "0 0 0";
						mark = "10400";
					};
				};
			};
			instant SimGroup "Infantry SAW" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "337.519 -1.09291 27.9067";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10401";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "322.75 17.1166 33.5118";
						rotation = "0 0 0";
						mark = "10402";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "311.519 20.4541 33.4317";
						rotation = "0 0 0";
						mark = "10403";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.219 21.6021 35.1962";
						rotation = "0 0 0";
						mark = "10404";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "319.508 16.7591 32.1955";
						rotation = "0 0 0";
						mark = "10405";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "331.955 13.0999 35.516";
						rotation = "0 0 0";
						mark = "10406";
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
						position = "340.561 -1.12232 28.9609";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10407";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "349.397 6.41999 35.9293";
						rotation = "0 0 0";
						mark = "10408";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "359.94 1.13404 32.4589";
						rotation = "0 0 0";
						mark = "10409";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "359.326 -5.24016 31.4649";
						rotation = "0 0 0";
						mark = "10410";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "359.792 -4.87975 31.4649";
						rotation = "0 0 0";
						mark = "10411";
					};
				};
			};
			instant SimGroup "Sniper PSG1" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "342.701 -1.00025 29.8088";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10412";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "346.904 -1.38636 30.7343";
						rotation = "0 0 0";
						mark = "10413";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "343.408 -4.63533 27.3547";
						rotation = "0 0 0";
						mark = "10414";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.762 -17.9125 15.6047";
						rotation = "0 0 0";
						mark = "10415";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "330 -15.7964 17.3803";
						rotation = "0 0 0";
						mark = "10416";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "315.375 -18.3473 15.4222";
						rotation = "0 0 0";
						mark = "10417";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "343.509 -5.73554 26.5719";
						rotation = "0 0 0";
						mark = "10418";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "343.821 -1.6244 29.7406";
						rotation = "0 0 0";
						mark = "10419";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "351.58 -2.05749 31.4649";
						rotation = "0 0 0";
						mark = "10420";
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
						position = "182.594 -82.1362 67.5083";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10421";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "216 -64.0431 70.809";
						rotation = "0 0 0";
						mark = "10422";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "257.546 -44.4774 38.6375";
						rotation = "0 0 0";
						mark = "10423";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "216.763 -64.466 70.4724";
						rotation = "0 0 0";
						mark = "10424";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "257.201 -43.6875 38.2767";
						rotation = "0 0 0";
						mark = "10425";
					};
				};
			};
			instant SimGroup "Infantry SAW Vet" {
				mustspawn = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "290.125 14.169 23.0919";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10426";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "290.002 14.0409 23.0146";
						rotation = "0 0 0";
						mark = "10427";
					};
				};
			};
			instant SimGroup "Infantry M16" {
				mustspawn = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "285.821 10.6306 25.9795";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10428";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "285.75 10.6699 25.9859";
						rotation = "0 0 0";
						mark = "10429";
					};
				};
			};
			instant SimGroup "Infantry M16" {
				mustspawn = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "292.549 13.9854 26.3464";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10430";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "292.625 13.875 26.3309";
						rotation = "0 0 0";
						mark = "10431";
					};
				};
			};
			instant SimGroup "Sniper FiftyCal" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "252.529 -123 43.6278";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10432";
						isIntitalPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "282.166 -84.0548 44.383";
						rotation = "0 0 0";
						mark = "10433";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "293.673 -65.8676 34.4312";
						rotation = "0 0 0";
						mark = "10434";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "299.077 -59.5189 33.1219";
						rotation = "0 0 0";
						mark = "10435";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "283.655 -47.4533 26.921";
						rotation = "0 0 0";
						mark = "10436";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "300 -57.7107 33.4759";
						rotation = "0 0 0";
						mark = "10437";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "291.758 -52.4432 30.1743";
						rotation = "0 0 0";
						mark = "10438";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "283.956 -47.4808 27.0409";
						rotation = "0 0 0";
						mark = "10439";
						isIntitalPath = "0";
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
						position = "290.263 59.0095 43.5";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10440";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "300.158 58.2797 48.0589";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10441";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "299.375 43.2197 39.1946";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10442";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "303.254 2.9017 22.1364";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10443";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "302.408 -0.0451022 21.1622";
						rotation = "0 0 0";
						mark = "10444";
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
						position = "306.939 -19.7645 14.2241";
						rotation = "0 0 0";
						mark = "10445";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Sniper PSG1 Vet Radio" {
				showname = "Sniper PSG1 Vet Radio";
				DelayID[0] = 0;
				GroupDelay[0] = 5;
				DelayCount = "1";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "275.681 62.3457 38.4134";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10446";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "307.375 59.2016 51.3281";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10447";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "307.969 42.4695 46.9179";
						rotation = "0 0 0";
						mark = "10448";
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
						position = "307.698 42.8191 46.8095";
						rotation = "0 0 0";
						mark = "10449";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "307.283 59.4801 51.4698";
						rotation = "0 0 0";
						mark = "10450";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Pilot Radio" {
				showname = "Pilot Radio";
				DelayCount = "1";
				DelayID[0] = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "208.326 30.6459 25.612";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10738";
						isInitialPath = -1;
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "207.944 30.3511 25.6524";
						rotation = "0 0 0";
						mark = "10740";
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
						position = "203.77 27.463 26.7399";
						rotation = "0 0 0";
						mark = "10744";
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
						position = "208.165 -4.10726 22.745";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10482";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "208.314 -4.11007 22.7528";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10483";
					};
				};
			};
		};
//--- export object end ---//
}	

function Exit::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 15;
			showname = "Exit D15 (4)";
			instant SimGroup "Infantry SAW" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "179.385 -88.1415 66.2051";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10512";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "226.917 -52.0564 60.313";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10513";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "262.664 -51.0049 40.8666";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10514";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "267.388 -50.7356 38.5817";
						rotation = "0 0 0";
						mark = "10515";
						isInitialPath = "0";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "272.536 -51.7156 40.2315";
						rotation = "0 0 0";
						mark = "10516";
						isInitialPath = "0";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "272.5 -51.3285 40.2131";
						rotation = "0 0 0";
						mark = "10517";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "239.667 -40.2161 52.3357";
						rotation = "0 0 0";
						mark = "10518";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "254.752 -50.5145 45.0154";
						rotation = "0 0 0";
						mark = "10519";
						isIntitalPath = "0";
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
						position = "251.781 -2.8619 26.5442";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10520";
						isIntitalPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "249.504 -11.5004 28.5256";
						rotation = "0 0 0";
						mark = "10521";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "262.397 -14.5354 23.5943";
						rotation = "0 0 0";
						mark = "10522";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "262.644 -9.49593 23.2767";
						rotation = "0 0 0";
						mark = "10523";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "283.429 -15.3361 22.1287";
						rotation = "0 0 0";
						mark = "10524";
						isIntitalPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "282.75 -6.28212 19.0184";
						rotation = "0 0 0";
						mark = "10525";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "283.25 -17.375 23.2003";
						rotation = "0 0 0";
						mark = "10526";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "283.503 -16.4836 22.8048";
						rotation = "0 0 0";
						mark = "10527";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "282.754 -9.27041 18.5875";
						rotation = "0 0 0";
						mark = "10528";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "262.75 -14.2875 23.4324";
						rotation = "0 0 0";
						mark = "10529";
						isIntitalPath = "0";
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
						position = "256.383 3.64943 24.9023";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10530";
						isIntitalPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "278.902 28.7461 24.4883";
						rotation = "0 0 0";
						mark = "10531";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "278.937 13.318 21.6497";
						rotation = "0 0 0";
						mark = "10532";
						isIntitalPath = "0";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "278.881 13.1605 21.6184";
						rotation = "0 0 0";
						mark = "10533";
						isIntitalPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "278.639 28.0004 24.2281";
						rotation = "0 0 0";
						mark = "10534";
						isIntitalPath = "0";
					};
				};
			};
			instant SimGroup "Infantry LAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "308.375 94.9228 68.5684";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10535";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "303.648 47.808 43.9313";
						rotation = "0 0 0";
						mark = "10536";
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
						position = "303.593 47.7303 43.861";
						rotation = "0 0 0";
						mark = "10537";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}	

function Exit::Radio0()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					Delay = 5;
					showname = "Sn PSG Vet R D5 (2) [2]";
					instant SimGroup "Infantry Shotgun" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "331.698 111.569 73.5827";
								rotation = "0 0 0";
								mark = "10484";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "312.574 41.152 43.331";
								rotation = "0 0 0";
								mark = "10485";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "288.156 -2.1929 18.955";
								rotation = "0 0 0";
								mark = "10486";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "261.592 -11.4103 23.8445";
								rotation = "0 0 0";
								mark = "10487";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "247.037 -10.0585 29.0214";
								rotation = "0 0 0";
								mark = "10488";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "252.875 4.21817 25.4286";
								rotation = "0 0 0";
								mark = "10489";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "246.75 -10.1308 29.0984";
								rotation = "0 0 0";
								mark = "10490";
								isInitialPath = "-1";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "261.182 -13.746 24.1297";
								rotation = "0 0 0";
								mark = "10491";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "283.53 -8.05478 18.7016";
								rotation = "0 0 0";
								mark = "10492";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "304.516 13.5663 26.8125";
								rotation = "0 0 0";
								mark = "10493";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "310.644 45.9431 45.032";
								rotation = "0 0 0";
								mark = "10494";
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
								position = "316.066 114.25 73.0335";
								rotation = "0 0 0";
								mark = "10495";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "305.411 66.3608 55.0625";
								rotation = "0 0 0";
								mark = "10496";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "293.32 38.6122 33.7453";
								rotation = "0 0 0";
								mark = "10497";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "273.625 31.625 23.9186";
								rotation = "0 0 0";
								mark = "10498";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "270.275 25.8704 27.3206";
								rotation = "0 0 0";
								mark = "10499";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "266.912 33.9235 26.1933";
								rotation = "0 0 0";
								mark = "10500";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "258.306 33.7683 30.6008";
								rotation = "0 0 0";
								mark = "10501";
								isInitialPath = "-1";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "258.199 33.7917 30.6469";
								rotation = "0 0 0";
								mark = "10502";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "270.567 25.544 27.2878";
								rotation = "0 0 0";
								mark = "10503";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "279.562 30.0513 24.9937";
								rotation = "0 0 0";
								mark = "10504";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "294.562 43.9728 36.7896";
								rotation = "0 0 0";
								mark = "10505";
								isInitialPath = "-1";
							};
						};
					};
				};
//--- export object end ---//
}	

function Exit::Radio1()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					Delay = 0;
					showname = "Pi R D0 (1) [1]";
					instant SimGroup "SpecOps MP5 Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "136.775 66.6162 66.4632";
								rotation = "0 0 0";
								mark = "10506";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "206.002 44.5225 48.1222";
								rotation = "0 0 0";
								mark = "10507";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "183.064 30.8608 48.1222";
								rotation = "0 0 0";
								mark = "10508";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "208.293 46.0035 50.125";
								rotation = "0 0 0";
								mark = "10509";
								isInitialPath = "-1";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "205.97 44.7048 48.1222";
								rotation = "0 0 0";
								mark = "10510";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "182.929 31.0299 48.1222";
								rotation = "0 0 0";
								mark = "10511";
								isInitialPath = "-1";
							};
						};
					};
				};
//--- export object end ---//
}	
	