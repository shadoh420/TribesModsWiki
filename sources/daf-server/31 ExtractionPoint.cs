function AAI::RunTriggerExtractionPoint(%cl)
{
	$ExtractionPoint::RandomSpawnCount=0;
	
	ExtractionPoint::RandomSpawnsLoop();
}
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                       EXTRACTIONPOINT                                       *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["ExtractionPoint"] = 2;
$AAISpawning::QuadrantTrigger[31] = "ExtractionPoint";
$AAISpawning::GroupDelay["ExtractionPoint", 0] = 0;
$AAISpawning::GroupDelay["ExtractionPoint", 1] = 7.5;

$AAI::GoSuicidal = 1;	
		
function ExtractionPoint::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "ExtractionPoint D0 (1)";
			instant SimGroup "Sniper PSG1 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-723.784 113.824 69.3734";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10813";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-688.088 99.2297 73.3772";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10814";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-688.262 99.2247 73.3788";
						rotation = "0 0 0";
						mark = "10815";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}
		


function ExtractionPoint::AIDelay1()
{
//--- export object begin ---//

		instant SimGroup "NewDelay" {
			Delay = 7.5;
			spawnall = 1;
			AAIFuncOnGroupDeath = "ExtractionPoint::Finals";
			showname = "ExtractionPoint D7.5 (4)";
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					AAIFuncOnDeath = "ExtractionPoint::CountDeaths";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-761.404 49.0976 28.3201";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10816";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-735.646 -1.55091 19.0446";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10817";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-682.11 -38.876 9.98434";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10818";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-621.852 -3.90699 10.1038";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10819";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-562.782 20.1638 10.1563";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10820";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-545.658 21.4595 10.0672";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10821";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-508.221 22.8911 11.3385";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10822";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-493.445 17.575 9.08224";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10823";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-480.98 16.8897 10.4329";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10824";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-478.537 26.8837 13.6501";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10825";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-468.038 19.8145 11.29";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10826";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					AAIFuncOnDeath = "ExtractionPoint::CountDeaths";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-762.708 45.9759 26.778";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10838";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.046 -3.1637 18.9458";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10839";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-682.131 -42.9253 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10840";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-549.514 -21.5068 9.92345";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10841";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-514.041 -29.5002 11.7987";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10842";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-472.359 -21.808 14.3086";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10843";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-450.774 -14.7476 12.6064";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10844";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					AAIFuncOnDeath = "ExtractionPoint::CountDeaths";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-765.345 48.9767 28.2356";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10854";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.205 -0.758051 19.2473";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10855";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-683.993 -39.823 9.99749";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10856";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-623.933 -8.97437 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10857";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-557.378 9.17902 9.9262";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10858";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-546.171 -2.50855 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10859";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.922 -5.70716 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10860";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-487.92 -2.07349 10.1404";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10861";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-473.232 -12.0231 11.0275";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10862";
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
						position = "-758.311 45.0615 26.5582";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10873";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-702.355 -14.9909 16.9677";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10874";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-637.644 -32.2858 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10875";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-541.427 -51.3029 32.5872";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10876";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.993 -50.5963 33.5528";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10877";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-529.443 -46.816 31.7468";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10878";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-529.689 -46.9889 31.6631";
						rotation = "0 0 0";
						mark = "10879";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.601 -50.4269 33.5026";
						rotation = "0 0 0";
						mark = "10880";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-540.545 -51.554 32.689";
						rotation = "0 0 0";
						mark = "10881";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-636.42 -32.491 10";
						rotation = "0 0 0";
						mark = "10882";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-616.442 -38.5358 10";
						rotation = "0 0 0";
						mark = "10883";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-604.431 -42.0316 10.6217";
						rotation = "0 0 0";
						mark = "10884";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-591.194 -45.8279 15.2899";
						rotation = "0 0 0";
						mark = "10885";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-579.633 -49.57 23.1295";
						rotation = "0 0 0";
						mark = "10886";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-551.26 -49.5218 32.2526";
						rotation = "0 0 0";
						mark = "10887";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-569.065 -49.5551 27.3381";
						rotation = "0 0 0";
						mark = "10888";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-563.811 -50.9257 31.4138";
						rotation = "0 0 0";
						mark = "10889";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-702.091 -15.8026 16.618";
						rotation = "0 0 0";
						mark = "10890";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-664.3 -21.587 13.7423";
						rotation = "0 0 0";
						mark = "10891";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-684.646 -11.6834 21.5635";
						rotation = "0 0 0";
						mark = "10892";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-750.961 39.3718 26.0761";
						rotation = "0 0 0";
						mark = "10893";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-729.326 13.4781 24.2405";
						rotation = "0 0 0";
						mark = "10894";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function ExtractionPoint::SpecSquad()
{
//--- export object begin ---//

		instant SimGroup "SpecNewDelay" {
			Delay = 2;
			NoDeleteOnDone = 1;
			spawnall = 1;
			noreact = 1;
			showname = "ExtractionPoint D7.5 (4)";
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					NoDeleteOnDone = 1;
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-761.404 49.0976 28.3201";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10816";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-735.646 -1.55091 19.0446";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10817";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-682.11 -38.876 9.98434";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10818";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-621.852 -3.90699 10.1038";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10819";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-562.782 20.1638 10.1563";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10820";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-545.658 21.4595 10.0672";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10821";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-508.221 22.8911 11.3385";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10822";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-493.445 17.575 9.08224";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10823";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-480.98 16.8897 10.4329";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10824";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-478.537 26.8837 13.6501";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10825";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-468.038 19.8145 11.29";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10826";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React";
			};
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					NoDeleteOnDone = 1;
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-762.708 45.9759 26.778";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10838";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.046 -3.1637 18.9458";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10839";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-682.131 -42.9253 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10840";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-621.122 -15.6536 10.005";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10841";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-549.514 -21.5068 9.92345";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10841";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-514.041 -29.5002 11.7987";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10842";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-472.359 -21.808 14.3086";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10843";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-450.774 -14.7476 12.6064";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10844";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React";
			};
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					NoDeleteOnDone = 1;
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-765.345 48.9767 28.2356";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10854";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.205 -0.758051 19.2473";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10855";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-683.993 -39.823 9.99749";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10856";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-623.933 -8.97437 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10857";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-557.378 9.17902 9.9262";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10858";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-546.171 -2.50855 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10859";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-530.922 -5.70716 10";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10860";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-487.92 -2.07349 10.1404";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10861";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-473.232 -12.0231 11.0275";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10862";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React";
			};
			
		};
}
function ExtractionPoint::RandomAI()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 15;
			spawnall = 1;
			showname = "ExtractionPoint D15 (1)";
			instant SimGroup "Random Elite" {
				AAIhasFuncOnDeath = 1;
				AAIFuncOnDeath = "ExtractionPoint::RandomSpawnsLoop";
				NoDeleteOnDone = 1;
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "0 0 -100";
						rotation = "0 0 0";
						mark = "10815";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-474.888 -174.884 32.7766";
						rotation = "0 0 0";
						mark = "10815";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.664 -151.361 46.5942";
						rotation = "0 0 0";
						mark = "10822";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-391.139 -166.741 45.8027";
						rotation = "0 0 0";
						mark = "10819";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355 -159.263 57.8354";
						rotation = "0 0 0";
						mark = "10821";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-575.377 -312.461 35.9715";
						rotation = "0 0 0";
						mark = "10827";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-625.759 -190.338 40.6956";
						rotation = "0 0 0";
						mark = "10825";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-425.997 -153.671 45.8365";
						rotation = "0 0 0";
						mark = "10816";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-471.947 127.981 62.0915";
						rotation = "0 0 0";
						mark = "10828";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-447.767 136.126 57.1148";
						rotation = "0 0 0";
						mark = "10831";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-431.209 134.324 57.0207";
						rotation = "0 0 0";
						mark = "10833";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.242 128.119 60.4497";
						rotation = "0 0 0";
						mark = "10835";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.992 119.032 65.888";
						rotation = "0 0 0";
						mark = "10837";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-528.996 168.252 44.4876";
						rotation = "0 0 0";
						mark = "10839";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-520.407 171.482 47.4117";
						rotation = "0 0 0";
						mark = "10841";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-493.107 182.159 53.1105";
						rotation = "0 0 0";
						mark = "10843";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-467.732 174.997 56.584";
						rotation = "0 0 0";
						mark = "10845";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-721.509 164.299 66.201";
						rotation = "0 0 0";
						mark = "10847";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-715.293 109.131 70.042";
						rotation = "0 0 0";
						mark = "10849";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-732.953 73.0311 54.0422";
						rotation = "0 0 0";
						mark = "10851";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-733.577 36.7348 31.4771";
						rotation = "0 0 0";
						mark = "10853";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-721.191 -147.43 52.0835";
						rotation = "0 0 0";
						mark = "10855";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-680.862 -177.686 39.9266";
						rotation = "0 0 0";
						mark = "10857";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-662.369 -179.776 39.4365";
						rotation = "0 0 0";
						mark = "10859";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-584.475 -123.029 43.4888";
						rotation = "0 0 0";
						mark = "10861";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-608.127 -168.353 28.7706";
						rotation = "0 0 0";
						mark = "10863";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-503.109 0.488462 9.95176";
						rotation = "0 0 0";
						mark = "10865";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-476.748 -37.2461 24.2395";
						rotation = "0 0 0";
						mark = "10867";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-508.075 -41.5644 22.0696";
						rotation = "0 0 0";
						mark = "10869";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-519.547 -41.1668 21.1561";
						rotation = "0 0 0";
						mark = "10871";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-512.009 -33.0697 13.5677";
						rotation = "0 0 0";
						mark = "10873";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-500.89 -31.462 13.403";
						rotation = "0 0 0";
						mark = "10875";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-498.23 -19.4115 10.2812";
						rotation = "0 0 0";
						mark = "10877";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-484.704 -14.1935 9.3244";
						rotation = "0 0 0";
						mark = "10879";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-473.4 -12.3299 11.0891";
						rotation = "0 0 0";
						mark = "10882";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-469.853 -20.7824 14.2831";
						rotation = "0 0 0";
						mark = "10880";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-467.197 -16.1632 12.9622";
						rotation = "0 0 0";
						mark = "10885";
						isInitialPath = "-1";
					};
				};
			};
		};

//--- export object end ---//
}
function ExtractionPoint::CountDeaths(%ainame)
{
	$ExtractionPointDeaths++;
	//if($ExtractionPointDeaths >= 3)
		// ExtractionPoint::RandomSpawnsLoop();

}
function DF_Extraction_RunExtractionPointScripts()
{
	schedule("ExtractionPoint::RandomSpawnsLoop();", 45);
}

function ExtractionPoint::RandomSpawnsLoop(%ainame)
{
	
	if(%ainame != "")
		%ai = AI::getObject(%ainame);
	else
	{
		%message = "Commander: Look out, they are converging on your location from the hills!";
		Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@0@"\",\"" @%message@"\");",0);
		//echo(NameToId("MissionGroup\\AIs\\ExtractionPoint"));
		LoadDelayGroup(NameToId("MissionGroup\\AIs\\ExtractionPoint"), "RandomAI");
		return;
	}	

	if($CDCarrier.CurQuad >= 30)
		$ExtractionPoint::RandomSpawnCount++;
	else	
		schedule("teammessages("@$MsgTypeTeamChat@", 0, \"Commander: DAMNIT! Get that Data CD to the Extraction Point on the DOUBLE!~wmale5.wcolor6.wav\");", getrandom()*10);
	
	if($ExtractionPoint::RandomSpawnCount==3 && $CDCarrier)
	{
		ExtractionPoint::BringInChopper();
	}

	if($ExtractionPoint::RandomSpawnCount>5)
	{
		deleteobject(getgroup(%ai.patrol));
		return;
	}
	//if($ExtractionPoint::RandomSpawnCount>=3)
		//AAI::SpawnAIDelayGroup(NameToId("MissionGroup\\AIs\\ExtractionPoint\\AI Delay15"), 1);

	AAI::SpawnAIDelayGroup(NameToId("MissionGroup\\AIs\\ExtractionPoint\\AI Delay15"), 1);
	//LoadDelayGroup(NameToId("MissionGroup\\AIs\\ExtractionPoint"), "RandomAI", 1);


}
$DF_Extraction_Count = 0;
$DF_Extraction_Speaker["Ending-1",$DF_Extraction_Count] = "Commander"; $DF_Extraction_Message["Ending-1",$DF_Extraction_Count] = "Ok, our Blackhawk is in range... I'll have the Techs at HQ patch her through to you..."; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-1",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-1",$DF_Extraction_Count] = "Hi boys! I got here as fast as I could... who has the Data CD?~wfemale2.whello.wav"; $DF_Extraction_Count++;
$DF_Extraction_Count["Ending-1"] = $DF_Extraction_Count;

$DF_Extraction_Count = 0;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "Hmm... well I'm starting my approach, keep the extraction point clear.~wfemale2.wcolor3.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Commander"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "Hang on, we're reading motion to your west... you guys have company.~wmale5.wincom2.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "I can see them..."; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "AH CRAP! They have Stingers! I can't clear out in time and there are too many for you boys to take!~wfemale2.wcolor7.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Commander"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "Where do they keep coming from!? We need to extract those men NOW! Can you land?"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "Negative... SHIT! They're locking on! HELP!~wfemale2.whelp.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Warthog Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "WOO-HOO! Anybody need a light?~wmale4.wtaunt1.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Warthog Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "COME GET SOME!~wmale4.wtaunt4.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Warthog Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "Now get them outta here..."; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "YEAH! You nailed them!~wfemale2.wcheer1.wav"; $DF_Extraction_Count++;
$DF_Extraction_Speaker["Ending-2",$DF_Extraction_Count] = "Blackhawk Pilot"; $DF_Extraction_Message["Ending-2",$DF_Extraction_Count] = "APC ready to go... waiting for passengers!~wfemale2.wwaitpas.wav"; $DF_Extraction_Count++;

$DF_Extraction_Count["Ending-2"] = $DF_Extraction_Count;

function ExtractionPoint::FirstLoad()
{
	LoadDelayGroup(NameToId("MissionGroup\\AIs\\ExtractionPoint"), "SpecSquad");
}
function ExtractionPoint::BringInChopper()
{
	ECHO("Incoming Chopper");
	AirStrike::BlackHawkTwo();
	%messages = "Ending-1";
	%delay = 10;
	%team = 0;
	for(%x = 0;%x < $DF_Extraction_Count[%messages];%x++)
	{
		%message = $DF_Extraction_Speaker[%messages,%x] @ ": "@$DF_Extraction_Message[%messages,%x];
	
		Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@%team@"\",\"" @%message@"\");",%delay);
		%delay = %delay + String::length(%message)/13;
	}
	if(client::Getname($CDCarrier) != "")
		%message = client::Getname($CDCarrier) @ ": That'd be me, ma'am.";
	else						   
		%message = client::Getname(Client::GetFirst()) @ ": None of us do ma'am.";
	Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@%team@"\",\"" @%message@"\");",%delay);
	%delay = %delay + String::length(%message)/13;
	//echo(%delay);
	%messages = "Ending-2";
	for(%x = 0;%x < $DF_Extraction_Count[%messages];%x++)
	{
		%message = $DF_Extraction_Speaker[%messages,%x] @ ": "@$DF_Extraction_Message[%messages,%x];
		//echo(%delay@" "@%message);
		Schedule("teamMessages(\""@$MsgTypeTeamChat@"\", \""@%team@"\",\"" @%message@"\");",%delay);
		%delay = %delay + String::length(%message)/13;
	}
	
	Schedule("Extraction::RunNap();", 53);
}