
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                            ALARM                                            *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["Alarm"] = 2;
$AAISpawning::GroupDelay["Alarm", 0] = 0;
$AAISpawning::GroupDelay["Alarm", 1] = 3;


function Alarm::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			spawnall = 1;
			showname = "Alarm D0 (5)";
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "466.069 -37.3151 28.9967";
						rotation = "0 0 0";
						mark = "10538";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "415.64 -58.518 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10539";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "357.125 -64.3809 28.997";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10540";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "416.875 -61.471 28.997";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10541";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.636 -39.1587 28.9967";
						rotation = "0 0 0";
						mark = "10542";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "415.044 -56.9715 28.9967";
						rotation = "0 0 0";
						mark = "10543";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "355.753 -60.1281 28.9967";
						rotation = "0 0 0";
						mark = "10544";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "374.387 -59.2182 28.9967";
						rotation = "0 0 0";
						mark = "10545";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "394.192 -58.3532 28.9967";
						rotation = "0 0 0";
						mark = "10546";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "430.63 -49.617 28.9967";
						rotation = "0 0 0";
						mark = "10547";
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
						position = "461.93 -36.8459 28.9967";
						rotation = "0 0 0";
						mark = "10548";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "448 -41.7065 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10549";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "448.254 -41.6838 28.9967";
						rotation = "0 0 0";
						mark = "10550";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "459.509 -35.9375 28.9967";
						rotation = "0 0 0";
						mark = "10551";
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
						position = "464.125 -40.103 28.9967";
						rotation = "0 0 0";
						mark = "10552";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "436.665 -51.8381 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10553";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "415.75 -59.2329 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10554";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "389.44 -60.2376 28.997";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10555";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "439.681 -45.3589 28.9967";
						rotation = "0 0 0";
						mark = "10556";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "449.5 -40.9399 28.9967";
						rotation = "0 0 0";
						mark = "10557";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "388.5 -59.8838 28.997";
						rotation = "0 0 0";
						mark = "10558";
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
						position = "465.785 -40.0535 28.9967";
						rotation = "0 0 0";
						mark = "10559";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "436.625 -53.3524 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10560";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "424.769 -52.2982 28.9967";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10561";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "424.325 -52.6541 28.9967";
						rotation = "0 0 0";
						mark = "10562";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "435.75 -47.1468 28.9967";
						rotation = "0 0 0";
						mark = "10563";
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
						position = "266.296 -116.938 48.0976";
						rotation = "0 0 0";
						mark = "10564";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.172 -66.545 28.2214";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10565";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.085 -66.2733 28.2301";
						rotation = "0 0 0";
						mark = "10566";
					};
				};
			};
		};
//--- export object end ---//
}

function Alarm::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 3;
			spawnall = 1;
			showname = "Alarm D3 (6)";
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "448.72 24.9387 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10567";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "389.916 21.6072 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10568";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "379.454 8.15625 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10569";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "390.202 15.5136 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10570";
						useInitialPath = "0";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "370.955 3 30.9955";
						rotation = "0 0 0";
						mark = "10571";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "390 15.9463 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10572";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "377.72 8.26192 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10573";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "429.425 18.6988 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10574";
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
						position = "448.505 22.5518 31.4647";
						rotation = "0 0 0";
						mark = "10575";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "414.771 19.8434 31.4647";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10576";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "412.801 18.0577 31.4649";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10577";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "413.928 17.6644 31.4647";
						rotation = "0 0 0";
						mark = "10578";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "422.558 19.0528 31.4647";
						rotation = "0 0 0";
						mark = "10579";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "449.514 19.8494 31.4647";
						rotation = "0 0 0";
						mark = "10580";
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
						position = "448.5 23.7046 31.4649";
						rotation = "0 0 0";
						mark = "10581";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "395.558 20.1006 31.4649";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10582";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "348 -10.8509 31.4649";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10583";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "395.692 21.2449 31.4649";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10584";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "437.32 18.7751 31.4647";
						rotation = "0 0 0";
						mark = "10585";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "408.25 17.1286 31.4647";
						rotation = "0 0 0";
						mark = "10586";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "387.948 14.2846 31.4647";
						rotation = "0 0 0";
						mark = "10587";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "368.152 -0.0523399 31.4647";
						rotation = "0 0 0";
						mark = "10588";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "346.524 -9.4934 31.4647";
						rotation = "0 0 0";
						mark = "10589";
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
						position = "444.75 25.3932 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10590";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "421.175 22.4733 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10591";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "389.507 20.4375 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10592";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "367.5 2.93571 31.4658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10593";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "370.679 2.40959 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10594";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "348.564 -11.8715 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						nostop = "1";
						mark = "10595";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "350.509 -11.7055 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10596";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "409.375 17.3717 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10597";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "395.169 16.9029 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10598";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "350.764 -11.6271 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10599";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "370.764 2.25833 31.4658";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10600";
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
						position = "352.375 -69.8483 25.8045";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10601";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "352.446 -62.1596 20.4105";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10602";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "352.186 -59.2729 20.4104";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10603";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "352.191 -48.007 20.4104";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10604";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "352.203 -58.5531 20.4104";
						rotation = "0 0 0";
						mark = "10605";
						isInitialPath = "-1";
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
						position = "280.891 -141.433 44.0634";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10606";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "308.755 -79.4572 38.7892";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10607";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "310.925 -72.8773 34.8171";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10608";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "309.322 -71.5909 34.1837";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10609";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "311.085 -72.7191 34.7128";
						rotation = "0 0 0";
						mark = "10610";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}
	