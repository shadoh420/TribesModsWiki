
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                        AMBUSH BRIDGE                                        *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["AmbushBridge"] = 4;
$AAISpawning::QuadrantTrigger[17] = "AmbushBridge";
$AAISpawning::GroupDelay["AmbushBridge", 0] = 5;
$AAISpawning::GroupDelay["AmbushBridge", 1] = 0;
$AAISpawning::GroupDelay["AmbushBridge", 2] = 15;
$AAISpawning::GroupDelay["AmbushBridge", 3] = 20;
$AAISpawning::TriggerWithoutFlag[17] = 1;

function AmbushBridge::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			delay = 5;
			movetogether = 1;
			showname = "AmbushBridge D5 (8) [2]";
			
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker2S" {
						dataBlock = "PathMarker";
						name = "";
						position = "-1.22416 -108.174 36.5912";
						rotation = "0 0 0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-21.322 -10.4367 36.4555";
						rotation = "0 0 0";
						useInitialPath = "1";
						jumpup = 1;
						mark = "10745";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.3374 -9.53353 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						dograpple = 1;
						mark = "10745";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-7.21557 -8.06113 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10744";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.304 -9.76093 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10747";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-7.21559 -8.06113 10";
						rotation = "0 0 0";
						mark = "10738";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.304 -9.76093 10";
						rotation = "0 0 0";
						mark = "10746";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-23.322 -10.4367 36.4555";
						rotation = "0 0 0";
						useInitialPath = "1";
						jumpup = 1;
						mark = "10745";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.3374 -9.53353 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						dograpple = 1;
						mark = "10745";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1S" {
						dataBlock = "PathMarker";
						name = "";
						position = "-2.00027 -104.632 36.6667";
						rotation = "0 0 0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-25.14 -2.032 36.4546";
						jumpup = 1;
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10741";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-20.6934 -1.02798 37.9519";
						dograpple = 1;
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10741";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.3277 2.37728 9.98915";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10714";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-21.1648 0.891129 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10716";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.3277 2.37728 9.98915";
						rotation = "0 0 0";
						mark = "10726";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-21.1647 0.891129 9.99947";
						rotation = "0 0 0";
						mark = "10712";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-25.14 -2.032 36.4546";
						jumpup = 1;
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10741";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-20.6934 -1.02798 37.9519";
						dograpple = 1;
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10741";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Elite NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1N" {
						dataBlock = "PathMarker";
						name = "";
						position = "-57.6097 104.474 37.4113";
						rotation = "0 0 0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-24.87 6.076 36.456";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10708";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-22.5091 7.01931 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10708";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-21.9292 10.8662 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10730";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-12.1122 11.5711 9.98262";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10748";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-21.9292 10.8662 10";
						rotation = "0 0 0";
						mark = "10713";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-12.1122 11.5711 9.98262";
						rotation = "0 0 0";
						mark = "10715";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-26.87 6.076 36.456";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10708";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-22.5091 7.01931 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10708";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker2N" {
						dataBlock = "PathMarker";
						name = "";
						position = "-58.327 107.05 37.45";
						rotation = "0 0 0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-28.1 14.0872 36.4546";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10717";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-24.7559 14.8385 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10717";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-14.5843 19.3443 10.3835";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10718";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-26.41 18.6767 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10734";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-14.5843 19.3443 10.3835";
						rotation = "0 0 0";
						mark = "10728";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-26.41 18.6767 10";
						rotation = "0 0 0";
						mark = "10719";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-28.1 14.0872 36.4546";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10717";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-24.7559 14.8385 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10717";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker2N" {
						dataBlock = "PathMarker";
						name = "";
						position = "-59.785 115.05 37.0663";
						rotation = "0 0 0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-29.724 21.7893 36.4546";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10743";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-26.5817 22.4105 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10743";
					};
					
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-23.696 22.0627 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10740";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-29.3789 25.76 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "8928";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						jumpup = 1;
						position = "-29.724 21.7893 36.4546";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10743";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						dograpple = 1;
						position = "-26.5817 22.4105 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10743";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-17.3242 26.7791 12.1503";
						rotation = "0 0 0";
						mark = "10721";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-26.9575 26.357 10";
						rotation = "0 0 0";
						mark = "10723";
					};
				};
			};
			
		};
//--- export object end ---//
}

function AmbushBridge::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "AmbushBridge D0 (7)";
			instant SimGroup "Infantry SAW" {
				instant SimGroup "Sniper FiftyCal Vet Radio" {
				showname = "Sniper FiftyCal Vet Radio";
				DelayID[0] = 0;
				DelayCount = "1";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-175.375 -69.5589 33.3229";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10725";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-171.671 -59.8286 33.3252";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10727";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-155.5 -55.7272 33.3262";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10729";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-158.897 -78.3175 33.3207";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10761";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-154.779 -74.4129 33.3217";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10749";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-189.424 -72.6798 33.3221";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10752";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-188.455 -55.6856 33.3262";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10762";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-188.349 -53.5492 33.3268";
						rotation = "0 0 0";
						mark = "10755";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-156.169 -53.9748 33.3267";
						rotation = "0 0 0";
						mark = "10753";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-154.875 -73.7112 33.3219";
						rotation = "0 0 0";
						mark = "10757";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-189.25 -71.9349 33.3223";
						rotation = "0 0 0";
						mark = "10751";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-171.474 -55.4727 33.3263";
						rotation = "0 0 0";
						mark = "10754";
						isInitialPath = "-1";
					};
				};
			};
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-94.3177 -69.2534 32.0753";
						rotation = "0 0 0";
						mark = "10784";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-104.566 -63.0767 32.4859";
						rotation = "0 0 0";
						mark = "10785";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-101.097 -54.5206 32.3471";
						rotation = "0 0 0";
						mark = "10786";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.009 -56.7799 32.5037";
						rotation = "0 0 0";
						mark = "10787";
						nostop = "1";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-103.751 -54.3827 32.4533";
						rotation = "0 0 0";
						mark = "10788";
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
						position = "-104.377 -54.3727 32.4784";
						rotation = "0 0 0";
						mark = "10789";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-101.26 -54.38 32.3537";
						rotation = "0 0 0";
						mark = "10790";
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
						position = "-91.1232 -69.1765 31.9474";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10791";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-91.1099 -54.3613 31.9469";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10792";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-96.4803 -58.2905 32.1618";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10793";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-94.2656 -54.4662 32.0732";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10794";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-94.0814 -54.477 32.0658";
						rotation = "0 0 0";
						mark = "10795";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-90.5759 -54.4143 31.9255";
						rotation = "0 0 0";
						mark = "10796";
						isInitialPath = "-1";
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
						position = "-51.0099 -29.986 9.77272";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10797";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-57.9262 -29.5288 9.72112";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10798";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-50.8681 -26.1759 9.67595";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10799";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-50.5625 -31.2118 9.91107";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10800";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-53.918 -30.3801 9.81721";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10801";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-53.5325 -31.1587 9.90507";
						rotation = "0 0 0";
						mark = "10802";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-60.5556 -31.5304 9.94701";
						rotation = "0 0 0";
						mark = "10803";
						isInitialPath = "-1";
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
						position = "-54.9583 -33.9319 11.3969";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10804";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-49.4893 -39.75 15.5833";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10805";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-49.5239 -32.7107 15";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10806";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-60.5789 -30.6583 13.998";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10807";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-50.5201 -32.2214 13.9956";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10808";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-50.5752 -32.5016 13.9955";
						rotation = "0 0 0";
						mark = "10809";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-60.1282 -30.4509 13.998";
						rotation = "0 0 0";
						mark = "10810";
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
						position = "-99.6875 88.6439 41.5853";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10811";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-76.5918 48.7764 36.4375";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10812";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-66.6165 31.8048 15.9741";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10813";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-63.9744 30.9733 15.3282";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10814";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-69.5531 30.4184 15.2139";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10815";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-72.5291 48.5228 36.0324";
						rotation = "0 0 0";
						mark = "10816";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-63.6734 30.9613 15.3477";
						rotation = "0 0 0";
						mark = "10817";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-69.9138 30.3452 15.1786";
						rotation = "0 0 0";
						mark = "10818";
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
						position = "-90.5331 -53.6336 17.0171";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10819";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-92.3387 -32.3636 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10820";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-79.9278 -32.9696 10.3085";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10821";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-76.7151 -32.0642 12.2005";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10822";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-82.5954 -32.375 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10823";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-79.5074 -32.8188 10.4474";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10824";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-75.6611 -31.3603 12.8138";
						rotation = "0 0 0";
						mark = "10825";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-79.216 -32.4764 10.5998";
						rotation = "0 0 0";
						mark = "10826";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-82.9479 -36.4908 10.4693";
						rotation = "0 0 0";
						mark = "10827";
						isInitialPath = "-1";
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
						position = "-68.6409 -12.0924 9.84718";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10828";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-73.0776 -12.9926 9.09444";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10829";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-70.3769 -9.10403 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10830";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-72.362 -13.8931 8.82143";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10831";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-67.2958 -14.7453 9.576";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10832";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-70.308 -9.34799 10";
						rotation = "0 0 0";
						mark = "10833";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-66.6639 -14.625 9.7322";
						rotation = "0 0 0";
						mark = "10834";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-68.4168 -12.131 9.88564";
						rotation = "0 0 0";
						mark = "10835";
						isInitialPath = "-1";
					};
				};
			};
		};
		
//--- export object end ---//
}

function AmbushBridge::AIDelay2()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 15;
			waittime = 30;
			Movetogether = 1;
			showname = "AmbushBridge D15 (6)";
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "346.532 -44.9249 10.6945";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10854";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "292.93 -30.1415 14.3674";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10855";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "287.537 -4.87167 18.6623";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10856";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "259.056 10.7023 23.8789";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10857";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "222.279 3.09738 24.7807";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10858";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "211.221 -10.7816 26.2762";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10859";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "164.38 -2.39418 17.3075";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10860";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "125.534 -14.125 17.2757";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10861";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "69.4256 -12.9501 12.5594";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10862";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "9.49173 -33.174 14.3692";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10863";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.3988 -31.3412 12.5454";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10864";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-40.2357 -13.7723 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10865";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-145.787 -44.9288 12.9965";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10866";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-252.087 -5.87857 24.1341";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10867";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-266.995 21.3657 26.1628";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10868";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-276.38 24.7712 25.8125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10869";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-297 0.0558468 22.371";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10870";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-329.486 3.12204 19.7089";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10871";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.435 2.87728 16.4925";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10872";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.007 -7.31278 13.7501";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10873";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-442.216 2.31869 10.7432";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10874";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-499.919 -2.98153 9.8928";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10875";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-524.112 -19.1469 10.0127";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10876";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.346 -33.1532 10.147";
						rotation = "0 0 0";
						mark = "10877";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "300.279 -17.3623 15.3441";
						rotation = "0 0 0";
						mark = "10878";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "288.964 5.82333 20.7368";
						rotation = "0 0 0";
						mark = "10879";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "256.467 15.7164 24.4567";
						rotation = "0 0 0";
						mark = "10880";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "222.167 14.793 23.5819";
						rotation = "0 0 0";
						mark = "10881";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "197.042 16.4765 23.6398";
						rotation = "0 0 0";
						mark = "10882";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "165.255 4.81756 18.1578";
						rotation = "0 0 0";
						mark = "10883";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "121.941 -7.5455 15.6397";
						rotation = "0 0 0";
						mark = "10884";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "70.6632 6.48678 11.1709";
						rotation = "0 0 0";
						mark = "10885";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "7.34927 2.68411 9.86084";
						rotation = "0 0 0";
						mark = "10886";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-42.4453 -2.91073 10";
						rotation = "0 0 0";
						mark = "10887";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-70.5328 12.1895 9.29373";
						rotation = "0 0 0";
						mark = "10888";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-150.153 -17.8118 15.2824";
						rotation = "0 0 0";
						mark = "10889";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-181.584 -27.7127 11.5973";
						rotation = "0 0 0";
						mark = "10891";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-242.235 34.5927 23.7356";
						rotation = "0 0 0";
						mark = "10893";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-275.069 32.4533 27.2723";
						rotation = "0 0 0";
						mark = "10895";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-307.028 20.5319 25.4427";
						rotation = "0 0 0";
						mark = "10897";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-334.739 11.3579 22.2957";
						rotation = "0 0 0";
						mark = "10899";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.036 9.66549 16.4807";
						rotation = "0 0 0";
						mark = "10901";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.773 7.84292 17.7862";
						rotation = "0 0 0";
						mark = "10903";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-442.596 10.6236 11.6148";
						rotation = "0 0 0";
						mark = "10905";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-491.821 10.6381 9.93039";
						rotation = "0 0 0";
						mark = "10907";
						isInitialPath = "1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-521.101 18.4478 10.8359";
						rotation = "0 0 0";
						mark = "10909";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "346.76 -47.0537 10.7567";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10956";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "291.935 -31.78 14.5421";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10958";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "286.45 -7.10874 18.5007";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10960";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "259.128 9.15189 23.9018";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10962";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "222.768 1.74033 25.0526";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10964";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "212.24 -12.7419 27.6";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10966";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "164.389 -3.69793 17.1681";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10968";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "125.792 -15.7898 17.6765";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10970";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "69.7977 -14.6794 12.9346";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10972";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "10.3851 -34.6162 15.3448";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10974";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.5601 -33.5857 13.9639";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10976";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-39.9948 -15.3395 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10978";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-145.642 -46.4361 13.413";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10980";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-252.787 -7.75205 24.6213";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10982";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-267.561 19.6157 26.1016";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10710";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-276.816 22.4972 25.5567";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "8929";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-295.899 -1.56656 22.9807";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10984";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-328.216 1.59421 19.3985";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10985";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.163 1.1525 16.8253";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10986";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.279 -9.08687 13.6117";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10987";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-442.394 1.176 10.6243";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10989";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-499.75 -4.42356 9.88039";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10720";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-522.657 -20.4812 10.0149";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10724";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.857 -43.182 10.5093";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10993";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "293.892 -28.8838 14.1534";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10994";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "289.149 -3.15287 18.8696";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10996";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "259.138 12.063 23.8201";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10998";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "221.912 4.86503 24.4504";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11000";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "210.991 -9.17057 25.176";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11002";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "164.428 -0.595246 17.5051";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11004";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "125.376 -12.9589 16.9881";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11006";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "69.5437 -10.9333 12.0472";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11008";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "9.3892 -31.7142 13.4704";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11010";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.718 -28.7897 11.6607";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11012";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-39.647 -11.3029 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11014";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-145.775 -43.4119 12.6122";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11016";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-251.197 -4.53129 23.6422";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11018";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-266.386 23.3049 26.2925";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11020";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-276.132 26.261 25.9925";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11022";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-297.189 2.37803 22.5884";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11024";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-330.496 4.5098 19.996";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11026";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.389 4.66105 16.1926";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11028";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-406.864 -5.95874 13.8493";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11030";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-441.985 3.51627 10.8668";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11032";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-499.767 -1.57316 9.86808";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11034";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-522.476 -17.4177 10.0723";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "11036";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.365 -34.4629 10.149";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11038";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "299.588 -18.8643 15.0037";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11040";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "287.969 4.69492 20.2804";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11042";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "257 14.2076 24.3434";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11044";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "222.745 13.2086 23.6852";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11046";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "196.857 15.2323 23.0908";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11048";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "165.209 2.96937 17.9551";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11050";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "123.007 -9.36716 15.9744";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11052";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "70.6049 4.16617 10.9209";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11054";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "7.58195 0.936704 9.95142";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11056";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-42.1078 -4.76468 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11058";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-70.3039 10.5677 9.00899";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11060";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-149.957 -19.2687 14.5638";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11062";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-181.774 -29.2792 10.973";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11064";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-243.111 33.0004 23.5635";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11066";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-275.296 30.4915 26.7799";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11068";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-307.11 18.8544 24.8656";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11070";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-334.432 9.90543 21.6202";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11072";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.866 8.40445 15.7533";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11074";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.522 6.16959 17.1388";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11076";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-442.459 9.03336 11.4493";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11078";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-491.45 9.39343 9.92951";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11080";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-520.02 16.8549 10.494";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10739";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "345.146 -31.6413 10.2658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11082";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "302.157 -16.8027 15.2749";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11039";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "290.052 6.81284 21.1861";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11041";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "255.725 17.1035 24.6021";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11043";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "221.938 16.6705 23.7454";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11045";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "197.78 17.7512 24.375";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11047";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "164.827 6.3457 18.2857";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11049";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "122.667 -5.02909 16.0044";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11051";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "71.3546 8.31186 11.3419";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11053";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "7.39036 4.47397 9.76808";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11055";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-42.3207 -1.39396 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11057";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-70.714 13.9297 9.59464";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11059";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-150.219 -16.2612 16.0204";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11061";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-181.208 -26.4703 12.1012";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11063";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-241.244 35.9929 24.4317";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11065";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-274.412 34.5311 27.8786";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11067";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-306.894 22.1026 25.9318";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11069";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-333.876 13.0788 23.1264";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11071";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-382.987 10.734 17.0101";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11073";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.482 9.68278 17.557";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11075";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-442.507 11.931 11.7629";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11077";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-491.977 11.8491 9.93086";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "11079";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-519.13 19.9791 11.1958";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "11081";
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

function AmbushBridge::AIDelay3()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			delay = 20;
			showname = "AmbushBridge D20 (2)";
			instant SimGroup "Sniper FiftyCal Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-187.937 11.5933 31.2876";
						rotation = "0 0 0";
						mark = "10836";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-185.921 21.93 37.6804";
						rotation = "0 0 0";
						mark = "10837";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-164.398 12.9549 38.6547";
						rotation = "0 0 0";
						mark = "10838";
						isInitialPath = "1";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-151.375 1.111 37.6222";
						rotation = "0 0 0";
						mark = "10839";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-152.095 -1.29071 37.622";
						rotation = "0 0 0";
						mark = "10840";
						isInitialPath = "-1";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-153.557 1.91551 37.6217";
						rotation = "0 0 0";
						mark = "10841";
						nostop = "1";
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
						position = "-151.153 1.49407 37.6223";
						rotation = "0 0 0";
						mark = "10842";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-151.942 -1.28762 37.6221";
						rotation = "0 0 0";
						mark = "10843";
						nostop = "1";
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
						position = "-190.505 11.6082 30.594";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10844";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-187.962 31.5008 42.4354";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10845";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-162.277 12.6804 39.0181";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10846";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-157.906 -1.30623 37.6206";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10847";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-161.5 7.07638 37.6197";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10848";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-164.375 6.99946 37.6191";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10849";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-161.25 7.05339 37.6198";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10850";
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
						position = "-164.302 6.70626 37.6191";
						rotation = "0 0 0";
						mark = "10851";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-157.672 -1.22803 37.6207";
						rotation = "0 0 0";
						mark = "10852";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-161.339 12.7167 39.2547";
						rotation = "0 0 0";
						mark = "10853";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}



function AmbushBridge::Radio0()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					Delay = 0;
					showname = "Sn 50C Vet R D0 (2) [2]";
					instant SimGroup "Infantry SAW Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-172.286 -53.1636 12.8163";
								rotation = "0 0 0";
								mark = "10771";
								isInitialPath = "1";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-151.383 -21.817 13.6393";
								rotation = "0 0 0";
								mark = "10772";
								isInitialPath = "-1";
								useInitialPath = "0";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-148.291 -31.2154 11.6117";
								rotation = "0 0 0";
								mark = "10773";
								nostop = "1";
								isInitialPath = "-1";
								useInitialPath = "0";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-149.375 -29.2399 11.9176";
								rotation = "0 0 0";
								mark = "10774";
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
								position = "-150.625 -21.6359 13.5792";
								rotation = "0 0 0";
								mark = "10775";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-149.669 -29.4577 11.881";
								rotation = "0 0 0";
								mark = "10776";
								isInitialPath = "-1";
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
								position = "-175.23 -53.2984 13.0076";
								rotation = "0 0 0";
								mark = "10777";
								isInitialPath = "1";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-174.042 -40.4767 10";
								rotation = "0 0 0";
								mark = "10778";
								isInitialPath = "1";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-147.581 -39.9412 11.45";
								rotation = "0 0 0";
								mark = "10779";
								isInitialPath = "-1";
								useInitialPath = "0";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-149.5 -32.786 11.4099";
								rotation = "0 0 0";
								mark = "10780";
								nostop = "1";
								isInitialPath = "-1";
								useInitialPath = "0";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-149.09 -33.9561 11.3098";
								rotation = "0 0 0";
								mark = "10781";
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
								position = "-149.5 -32.905 11.3995";
								rotation = "0 0 0";
								mark = "10782";
								isInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-147.338 -39.5563 11.4642";
								rotation = "0 0 0";
								mark = "10783";
								isInitialPath = "-1";
							};
						};
					};
				};
//--- export object end ---//
}