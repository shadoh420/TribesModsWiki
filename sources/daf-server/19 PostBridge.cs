
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                         POST BRIDGE                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["PostBridge"] = 1;
$AAISpawning::QuadrantTrigger[19] = "PostBridge";
$AAISpawning::GroupDelay["PostBridge", 0] = 2.5;
$AAISpawning::TriggerWithoutFlag[19] = 1;

		



function PostBridge::AIDelay0()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 2.5;
			showname = "PostBridge D2.5 (11) [1]";
			instant SimGroup "Infantry Shotgun" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-117.203 -58.9933 20.0789";
						rotation = "0 0 0";
						mark = "9979";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-117.418 -45.7757 10";
						rotation = "0 0 0";
						mark = "9938";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-82.6196 -48.764 15.9104";
						rotation = "0 0 0";
						mark = "9926";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-82.9463 -48.8942 15.9041";
						rotation = "0 0 0";
						mark = "9946";
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
						position = "-117.086 -64.7172 25.9657";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9942";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-117.58 -89.726 39.5";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "8928";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-111.126 -85.094 38.7535";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9935";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.5 -50.4723 38.5281";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9940";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.724 -88.41 38.5373";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9937";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.654 -87.3389 38.5345";
						rotation = "0 0 0";
						mark = "9920";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.662 -63.8453 38.5348";
						rotation = "0 0 0";
						mark = "9916";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-105.544 -51.1135 38.5301";
						rotation = "0 0 0";
						mark = "9945";
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
						position = "-191.586 -55.2075 16.3452";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9922";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-181.303 -7.47228 21.8469";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "8927";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-193.144 -54.5312 16.3194";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9943";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-191.13 -51.4189 14.3147";
						rotation = "0 0 0";
						mark = "9939";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-189.091 -24.2822 11.8992";
						rotation = "0 0 0";
						mark = "9936";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-182.923 -8.57103 20.6735";
						rotation = "0 0 0";
						mark = "9928";
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
						position = "-197.664 12.8761 29.4248";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9947";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-201.902 8.79222 25.5156";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9948";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-195.974 -0.353563 22.7805";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9949";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-196.033 0.011046 22.9187";
						rotation = "0 0 0";
						mark = "9950";
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
						position = "-195.136 12.2197 29.9266";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9951";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-193.425 20.4249 35.4886";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9918";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-179.052 14.6131 36.8814";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9955";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-166.858 -7.63939 25.3631";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9956";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-166.538 -7.63646 25.3449";
						rotation = "0 0 0";
						mark = "9957";
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
						position = "-209.846 -58.8043 24.8901";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9958";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-206.344 -61.5175 26.5603";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9959";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-206.932 -60.9554 26.1331";
						rotation = "0 0 0";
						mark = "9960";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet Radio" {
				showname = "SpecOps MP5 Vet Radio";
				DelayCount = "1";
				DelayID[0] = 0;
				GroupDelay[0] = 2.5;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-224.008 -46.4153 22.2616";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9961";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-232.878 -35.419 22.2704";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9962";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-210.802 -52.3529 29.6535";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9963";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-211.564 -51.8704 29.3828";
						rotation = "0 0 0";
						mark = "9964";
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
						position = "-260.005 51.6981 28.6936";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "9973";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-258.072 54.5056 29.6603";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "9974";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-242.346 51.1481 30.0511";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "9975";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-223.53 39.3631 31.4834";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "9976";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-223.016 37.1563 30.8835";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "9977";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-204.901 12.3366 26.7123";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "9978";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-205.091 12.8484 26.9359";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "9924";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-222.846 36.391 30.6713";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "9980";
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
						position = "-149.375 -34.4093 11.2686";
						rotation = "0 0 0";
						isInitialPath = "1";
						nostop = "1";
						mark = "9926";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-148 -40.4836 11.5141";
						rotation = "0 0 0";
						isInitialPath = "-1";
						nostop = "1";
						mark = "9942";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-148.918 -39.0912 11.1875";
						rotation = "0 0 0";
						isInitialPath = "-1";
						nostop = "1";
						mark = "9935";
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
						position = "-151.551 -26.5628 12.3278";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10081";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-163.212 -31.0957 10.875";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10011";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-163.125 -16.4444 15.0055";
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
						position = "-162.951 -16.5395 14.8379";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10015";
					};
				};
			};
		};
//--- export object end ---//
}

function PostBridge::Radio0()
{
		instant SimGroup "NewDelay" {
					Delay = 2.5;
					showname = "Sp MP5 Vet R D2.5 (1) [1]";
					instant SimGroup "Infantry M16 Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-223.599 -47.0576 22.3589";
								rotation = "0 0 0";
								mark = "9969";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-231.25 -38.6373 22.9534";
								rotation = "0 0 0";
								mark = "9970";
								isInitialPath = "1";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-118.625 -50.3441 11.9602";
								rotation = "0 0 0";
								mark = "9971";
								isInitialPath = "1";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-230.131 -36.5602 21.425";
								rotation = "0 0 0";
								mark = "9972";
								isInitialPath = "-1";
							};
						};
					};
				};


}