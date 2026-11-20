
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                        POST BUILDING                                        *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["PostBuilding"] = 2;
$AAISpawning::QuadrantTrigger[22] = "PostBuilding";
$AAISpawning::GroupDelay["PostBuilding", 0] = 0;
$AAISpawning::GroupDelay["PostBuilding", 1] = 5;
$AAISpawning::TriggerWithoutFlag[22] = 1;

		
function PostBuilding::AIDelay0()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "PostBuilding D0 (8) [3]";
			instant SimGroup "SpecOps MP5 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-150.343 178.474 45.7005";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10024";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-235.923 77.4935 55.2782";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10081";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-250.175 59.4784 41.83";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10011";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-256.831 53.2074 29.3395";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10067";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.202 52.7356 29.9067";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10015";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-257.405 52.5768 29.1089";
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
						position = "-249.25 52.6858 29.8767";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10010";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-257.687 53.1354 29.263";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10039";
					};
				};
			};
			instant SimGroup "Sniper FiftyCal Vet Radio" {
				DelayCount = "1";
				DelayID[0] = 0;
				
				showname = "Sniper FiftyCal Vet Radio";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-175.151 184.736 52.8905";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10006";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-191.627 151.901 70.7225";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10004";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-227.516 83.2092 60.2857";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10017";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-232.676 72.3824 56.4578";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10018";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-238.186 77.6079 55.4033";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10019";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-233.018 72.0208 56.5808";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10020";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-238 77.5184 55.4144";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10021";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-238.19 77.4692 55.4417";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10022";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-232.974 72.3575 56.4852";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10023";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-224.541 80.5741 60.8039";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10024";
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
						position = "-197.756 132.475 73.4744";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10043";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-251.155 60.222 41.5234";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10044";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-210.027 -23.2451 13.6585";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10045";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-259.93 -15.7657 28.581";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10067";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-220.777 25.2086 27.2289";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10036";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-250.932 -12.0473 24.1347";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10088";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-251.265 -11.793 24.2796";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10023";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-221.305 25.3636 27.0771";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10034";
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
						position = "-249.578 27.9513 23.5";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10088";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.896 15.3626 22.9951";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10034";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.944 15.9108 23.0195";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10010";
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
						position = "-260.887 -16.235 29.2302";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10117";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-271.313 2.39813 26.1942";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10123";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-271.509 2.27136 26.2038";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10133";
					};
				};
			};
		};

//--- export object end ---//
}

function PostBuilding::AIDelay1()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 5;
			spawnall = 1;
			movetogether = 1;
			showname = "PostBuilding D5 (4)";
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-334.125 -79.9175 67.7328";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10655";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-280.977 -29.0882 48.2863";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10656";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.875 -18.5526 45.1404";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10657";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-274.834 -19.2544 44.5651";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10658";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-283.258 -18.5341 46.0466";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10659";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-275 -19.2794 44.6074";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10660";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-282.948 -18.6134 46.0119";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10661";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-280.724 -29.1732 48.243";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10662";
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
						position = "-336.295 -76.293 67.4375";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10064";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-284.129 -29.6462 48.0146";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10021";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-281.737 -13.975 44.0151";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10138";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-274.809 -15.0732 42.9871";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10144";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-282.005 -14.0641 44.1044";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10117";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-274.679 -15.087 42.9651";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10146";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-281.875 -13.7979 43.9749";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10150";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-283.18 -27.4188 49.1297";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10142";
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
						position = "-330.783 -84.4217 66.6704";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10010";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.096 -29.8033 47.9199";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10024";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-275.875 -23.1822 46.2582";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10081";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-284.125 -22.8838 47.8623";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10011";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-284 -23.1064 47.9195";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10067";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-275.803 -22.9954 46.1739";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10015";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.136 -32.0287 46.8035";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10077";
					};
				};
			};
			
		};
//--- export object end ---//
}

function PostBuilding::Radio0()
{
//--- export object begin ---//
			instant SimGroup "NewDelay" {
					showname = "Sn 50C Vet R D0 (3) [3]";
					instant SimGroup "Infantry Shotgun Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-278.813 12.9669 25.0625";
								rotation = "0 0 0";
								isInitialPath = "1";
								mark = "10011";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-268.375 30.9674 26.7901";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10067";
								useInitialPath = "0";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-268.75 30.573 26.8359";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10015";
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
								position = "-258.979 52.5829 29.0109";
								rotation = "0 0 0";
								isInitialPath = "1";
								mark = "10067";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-265.11 39.0055 26.7833";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10015";
								useInitialPath = "0";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-265.159 39.007 26.7941";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10011";
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
								position = "-280.345 6.86572 25.2527";
								rotation = "0 0 0";
								isInitialPath = "1";
								mark = "10168";
								useInitialPath = "-1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-272.034 24.2421 26.4871";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10170";
								useInitialPath = "0";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-272.079 24.1708 26.473";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10166";
							};
						};
					};
				};
//--- export object end ---//
}
