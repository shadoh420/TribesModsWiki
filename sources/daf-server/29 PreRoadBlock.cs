
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                        PRE ROADBLOCK                                        *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************

$AAISpawning::DelayCount["PreRoadBlock"] = 5;
$AAISpawning::QuadrantTrigger[29] = "PreRoadBlock";
$AAISpawning::GroupDelay["PreRoadBlock", 0] = 0;
$AAISpawning::GroupDelay["PreRoadBlock", 1] = 10;
$AAISpawning::GroupDelay["PreRoadBlock", 2] = 5;
$AAISpawning::GroupDelay["PreRoadBlock", 3] = 15;
$AAISpawning::GroupDelay["PreRoadBlock", 4] = 17.5;
$AAISpawning::TriggerWithoutFlag[29] = 1;
	
		
		
		
	

function PreRoadBlock::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "PreRoadBlock D0 (4)";
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-466.093 -35.1151 28.5132";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10556";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-453.169 -12.6859 11.5819";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10557";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-453.298 -12.3835 11.5695";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10558";
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
						position = "-488.25 -15.9082 7.0162";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10559";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-472.606 -12.0157 11.0957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10560";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-472.86 -12.0568 11.0775";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10561";
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
						position = "-473.657 -35.3993 24.9103";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10655";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-482.908 -36.7905 21.7768";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10656";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-471.945 -16.9607 12.5645";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10657";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-472.072 -17.1255 12.6096";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10658";
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
						position = "-464.462 -35.2569 29.2316";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10566";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-423.989 -29.6531 17.1747";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10567";
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

function PreRoadBlock::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 10;
			showname = "PreRoadBlock D10 (5)";
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-476.515 18.4081 10.6979";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10568";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-476.551 16.4542 10.751";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10569";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-476.436 16.8802 10.75";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10570";
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
						position = "-469.875 25.5198 12.4179";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10743";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-466.16 27.8238 14.841";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10738";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-467.083 27.0486 14.1468";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10739";
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
						position = "-450.399 122.752 62.324";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10574";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-441.5 105.565 65.2095";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10575";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-461.654 -5.65279 10.5232";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10576";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-428.656 9.87776 13.1079";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10577";
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
						position = "-496.888 -19.7051 10.545";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10578";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-503.927 14.4446 9.95501";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10579";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-514.702 7.27737 9.97569";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10580";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-502.567 -0.608145 9.95659";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10581";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-514.69 7.52814 9.97569";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10582";
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
						position = "-502.518 -0.999075 9.96014";
						rotation = "0 0 0";
						mark = "10583";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-503.875 14.3789 9.95488";
						rotation = "0 0 0";
						mark = "10584";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-504.007 7.18915 9.95429";
						rotation = "0 0 0";
						mark = "10585";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Sniper FiftyCal Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-495.456 -21.4953 11.0976";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10586";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-502.226 -32.281 13.7825";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10587";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-497.25 -32.9032 14.3012";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10588";
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
						position = "-497.478 -32.845 14.2577";
						rotation = "0 0 0";
						mark = "10589";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function PreRoadBlock::AIDelay2()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 5;
			showname = "PreRoadBlock D5 (4)";
			instant SimGroup "Infantry Shotgun Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-462.125 32.4233 17.7957";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10590";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-461.916 37.2255 21.0094";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10591";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-445.235 34.7768 21.7622";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10592";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-445.385 34.7836 21.7139";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10593";
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
						position = "-462.6 29.3917 16.2044";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10594";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-462.774 16.61 11.8233";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10595";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-462.656 16.6825 11.8425";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10596";
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
						position = "-495.893 -21.3888 11.0199";
						rotation = "0 0 0";
						mark = "10597";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-492.7 -26.3517 12.5922";
						rotation = "0 0 0";
						mark = "10598";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-465.265 -23.7384 17.9638";
						rotation = "0 0 0";
						mark = "10599";
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
						position = "-465.375 -24.0377 18.1268";
						rotation = "0 0 0";
						mark = "10600";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Sniper FiftyCal Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-549.917 94.1257 44.6908";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10601";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-535.093 50.8588 33.1991";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10602";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-532 48.0122 32.0892";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10603";
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
						position = "-532.125 48.0129 32.0865";
						rotation = "0 0 0";
						mark = "10604";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function PreRoadBlock::AIDelay3()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 15;
			showname = "PreRoadBlock D15 (2) [1]";
			instant SimGroup "Infantry LAW Elite Radio" {
				showname = "Infantry LAW Elite Radio";
				DelayCount = "1";
				DelayID[0] = 0;
				GroupDelay[0] = 2.5;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-576.848 161.205 34.6078";
						rotation = "0 0 0";
						mark = "10605";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-585.194 153.192 33.5131";
						rotation = "0 0 0";
						mark = "10606";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-575.581 152.19 33.6465";
						rotation = "0 0 0";
						mark = "10607";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-582.331 152.766 33.542";
						rotation = "0 0 0";
						mark = "10608";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-578.348 147.375 33.6115";
						rotation = "0 0 0";
						mark = "10609";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-582.405 148.209 33.5673";
						rotation = "0 0 0";
						mark = "10610";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-577.523 132.101 35.6345";
						rotation = "0 0 0";
						mark = "10611";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-558.647 44.1705 37.9111";
						rotation = "0 0 0";
						mark = "10612";
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
						position = "-558.702 44.2537 37.9111";
						rotation = "0 0 0";
						mark = "10613";
						nostop = "1";
						isInitialPath = "-1";
					};
				};
				
			};
		};
//--- export object end ---//
}

function PreRoadBlock::AIDelay4()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 17.5;
			showname = "PreRoadBlock D17.5 (6)";
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-523.831 -104.878 35.4891";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10655";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.418 -41.0273 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10656";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.479 -41.0422 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10657";
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
						position = "-523.5 -107.382 35.192";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10738";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-529.679 -44.8095 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10739";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-529.649 -44.7256 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10743";
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
						position = "-524.406 -102.25 35.9279";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10626";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-531.25 -37.0149 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10627";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-531.322 -37.0446 37.2036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10628";
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
						position = "-546.713 -20.6434 10.0823";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10629";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-545.857 -23.2979 10.3149";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10630";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-517.711 -28.9067 11.5715";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10631";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-509.631 -37.521 17.2723";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10632";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-509.605 -37.2988 17.0718";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10633";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-523.329 -28.8889 11.6448";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10634";
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
						position = "-545.567 -7.44639 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10635";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-543.908 -15.4442 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10636";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-536.703 -15.8922 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10637";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-491.885 -11.2459 9.76641";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10638";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Sniper FiftyCal Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-527.987 -20.8467 10";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10639";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-551.447 -0.538975 14.947";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10640";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-555.185 2.55619 16.0572";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10641";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-552.741 -0.391834 15.026";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10642";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-552.789 -0.431202 15.0085";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10643";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-551.733 -0.257036 14.9501";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10644";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-555.055 2.52714 16.052";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10645";
					};
				};
			};
		};
//--- export object end ---//
}

function PreRoadBlock::Radio0()
{
//--- export object begin ---//
				instant SimGroup "NewDelay" {
					Delay = 2.5;
					showname = "In LAW Eli R D2.5 (1) [1]";
					instant SimGroup "Infantry LAW Elite" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-577.393 156.657 34.1013";
								rotation = "0 0 0";
								mark = "10617";
								nostop = "1";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-554.5 44.999 37.9111";
								rotation = "0 0 0";
								mark = "10618";
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
								position = "-554.506 45.2569 37.9111";
								rotation = "0 0 0";
								mark = "10619";
								nostop = "1";
								isInitialPath = "-1";
							};
						};
					};
				};
//--- export object end ---//
}