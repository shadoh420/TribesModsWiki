//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                           MAIN AI                                           *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["MainAI"] = 1;
$AAISpawning::GroupDelay["MainAI", 0] = 0;

function MainAI::AIDelay0()
{
instant SimGroup "NewDelay" {
	Delay = 0;
	spawnall = 1;
	showname = "AI (20) [9]";	
	instant SimGroup "Infantry Shotgun" {
		instant SimPath "Patrol" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "468.502 -150.626 35.0965";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9867";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "459.808 -150.448 40.6396";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9868";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "454.625 -150.875 44.0149";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9869";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "456.812 -144.6 44.6";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9870";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "454.469 -152.429 44.0157";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9871";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "459.661 -152.005 40.6404";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9872";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "469.875 -148.648 35.0965";
				rotation = "0 0 0";
				mark = "9873";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "455.203 -151.31 44.0151";
				rotation = "0 0 0";
				mark = "9874";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "462.083 -147.461 44.5965";
				rotation = "0 0 0";
				mark = "9875";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "460.063 -151.017 40.6399";
				rotation = "0 0 0";
				mark = "9876";
			};
		};
	};
	instant SimGroup "Infantry Shotgun Radio" {
		DelayCount = "1";
		DelayID[0] = 0;
		showname = "Infantry Shotgun Radio";
		instant SimPath "Patrol" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "466.375 -156.051 52.5985";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9980";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "469.934 -148.756 52.5985";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9981";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "466.018 -137.375 52.5985";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9982";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "466.375 -156.051 52.5985";
				rotation = "0 0 0";
				mark = "9983";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "466.018 -137.375 52.5985";
				rotation = "0 0 0";
				mark = "9984";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "469.933 -148.756 52.5985";
				rotation = "0 0 0";
				mark = "9985";
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
				position = "465.125 11.3774 34.0662";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9782";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "468.53 -31.2758 34.0662";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9783";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "472.05 -74.25 44.4713";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9784";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "486.5 -31.2014 34.0648";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9785";
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
				position = "463.5 37.9169 34.8877";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "10060";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "463 44.3174 34.8672";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "10064";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "479.666 45.6681 34.0634";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "10072";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "482.25 15.8504 34.0722";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "10074";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "472.762 39.7955 34.0637";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "10076";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "481.77 15.8508 34.0662";
				rotation = "0 0 0";
				mark = "10062";
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
				position = "451.17 32.2635 34.0637";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9792";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "452.505 23.7734 34.0637";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9793";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "466.5 25.156 34.0637";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9794";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "452.625 23.8975 34.0637";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9795";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "451.75 30.6775 34.0637";
				rotation = "0 0 0";
				mark = "9796";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "454.041 26.1875 34.0645";
				rotation = "0 0 0";
				mark = "9797";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "464.276 26.8684 34.0645";
				rotation = "0 0 0";
				mark = "9798";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "459.293 26.4616 34.0645";
				rotation = "0 0 0";
				mark = "9799";
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
				position = "476.5 16.0198 10.0695";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9800";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "473.511 14.2508 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9801";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "475.125 2.04741 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9802";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "470.016 1.70578 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9803";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "470.137 -3.15567 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9804";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "478.784 -2.12094 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9805";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "477.125 7.53976 10.0695";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9806";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "475.375 14.0267 10.0695";
				rotation = "0 0 0";
				mark = "9807";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "474.551 7.00588 10.0695";
				rotation = "0 0 0";
				mark = "9808";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "471.434 -1.70472 10.0695";
				rotation = "0 0 0";
				mark = "9809";
			};
		};
	};
	instant SimGroup "Commander Elite Radio" {
		DelayCount = "1";
		DelayID[0] = 1;
		GroupDelay[0] = 10;
		showname = "Commander Elite Radio";
		instant SimGroup "Patrol" {
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "478.887 28.8125 26.0664";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9810";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "478.625 32.3995 26.0664";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9811";
			};
		};
		instant SimGroup "React" {
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "478.262 36.4404 26.069";
				rotation = "0 0 0";
				mark = "9812";
			};
		};
	};
	instant SimGroup "Pilot" {
		instant SimPath "Patrol" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "469.078 -26.0406 10.0721";
				rotation = "0 -0 1.4144";
				useInitialPath = "1";
				mark = "9836";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "462.174 -28.0118 10.0698";
				rotation = "0 -0 1.82582";
				useInitialPath = "0";
				mark = "9837";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "463.257 -24.2916 10.0761";
				rotation = "0 -0 -0.23086";
				useInitialPath = "0";
				mark = "9838";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "453.875 -31.331 9.93868";
				rotation = "0 -0 -0.41127";
				mark = "9839";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "469.654 -26.7129 10.0716";
				rotation = "0 -0 0.172957";
				mark = "9840";
			};
		};
	};
	instant SimGroup "Infantry M16 Vet Radio" {
		showname = "Infantry M16 Vet Radio";
		DelayCount = "1";
		DelayID[0] = 2;
		GroupDelay[0] = 10;
		instant SimPath "Patrol" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "354.251 -22.9473 14.2183";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9842";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "352.157 -25.178 14.2183";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9843";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "349.774 -23.1194 14.2183";
				rotation = "0 0 0";
				useInitialPath = "0";
				mark = "9844";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "354.25 -23.003 14.2183";
				rotation = "0 0 0";
				mark = "9845";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "352.125 -25.1728 14.2183";
				rotation = "0 0 0";
				mark = "9846";
			};
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "349.794 -23.0806 14.2183";
				rotation = "0 0 0";
				mark = "9847";
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
				position = "468.883 22.4335 26.07";
				rotation = "0 0 0";
				useInitialPath = "1";
				mark = "9865";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "467.834 24.3859 26.07";
				rotation = "0 0 0";
				mark = "9866";
			};
		};
	};
};

}


function MainAI::Radio0()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "In Sho R D0 (4) [4]";
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.4 31.2717 34.0638";
						rotation = "0 0 0";
						mark = "9877";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.75 23.9261 34.0638";
						rotation = "0 0 0";
						mark = "9878";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "472.125 25.8685 34.0638";
						rotation = "0 0 0";
						mark = "9879";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "477.786 -48.7387 34.0638";
						rotation = "0 0 0";
						mark = "9880";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "491.875 -107.285 36.4167";
						rotation = "0 0 0";
						mark = "9881";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "499.504 -143.125 34.8301";
						rotation = "0 0 0";
						mark = "9882";
					};
				};
				instant SimGroup "React";
			};
			instant SimGroup "Infantry M16 NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "453.75 32.2716 34.0638";
						rotation = "0 0 0";
						mark = "9883";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "453.375 24.9771 34.0638";
						rotation = "0 0 0";
						mark = "9884";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "469.77 26.3375 34.0638";
						rotation = "0 0 0";
						mark = "9885";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.264 -45.7516 34.0638";
						rotation = "0 0 0";
						mark = "9886";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "477.375 -122.75 38.7099";
						rotation = "0 0 0";
						mark = "9887";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "479.875 -133.439 34.8301";
						rotation = "0 0 0";
						mark = "9888";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "453.75 32.2715 34.0638";
						rotation = "0 0 0";
						mark = "9889";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "453.375 24.977 34.0638";
						rotation = "0 0 0";
						mark = "9890";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "477.375 -122.75 38.7099";
						rotation = "0 0 0";
						mark = "9891";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.264 -45.7516 34.0638";
						rotation = "0 0 0";
						mark = "9892";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "469.77 26.3374 34.0638";
						rotation = "0 0 0";
						mark = "9893";
					};
				};
			};
			instant SimGroup "Infantry M16 NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "451.045 33.2638 34.0638";
						rotation = "0 0 0";
						mark = "9894";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "451.671 22.9429 34.0638";
						rotation = "0 0 0";
						mark = "9895";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "477.299 24.9138 34.0638";
						rotation = "0 0 0";
						mark = "9896";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "484.189 -50.6707 34.0638";
						rotation = "0 0 0";
						mark = "9897";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "556.625 -108.793 51.4035";
						rotation = "0 0 0";
						mark = "9898";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "451.045 33.2637 34.0638";
						rotation = "0 0 0";
						mark = "9899";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "556.625 -108.793 51.4035";
						rotation = "0 0 0";
						mark = "9900";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "484.189 -50.6706 34.0638";
						rotation = "0 0 0";
						mark = "9901";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "477.299 24.9138 34.0638";
						rotation = "0 0 0";
						mark = "9902";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "451.671 22.9429 34.0638";
						rotation = "0 0 0";
						mark = "9903";
					};
				};
			};
			instant SimGroup "Infantry SAW NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.625 33.3667 34.0638";
						rotation = "0 0 0";
						mark = "9904";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.875 23.6664 34.0638";
						rotation = "0 0 0";
						mark = "9905";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.555 25.9909 34.0638";
						rotation = "0 0 0";
						mark = "9906";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "478 -48.0543 34.0638";
						rotation = "0 0 0";
						mark = "9907";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.637 -115.125 40.315";
						rotation = "0 0 0";
						mark = "9908";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "479.125 -161.756 34.8301";
						rotation = "0 0 0";
						mark = "9909";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "490.125 -161.5 34.8301";
						rotation = "0 0 0";
						mark = "9910";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "499.625 -169 34.8301";
						rotation = "0 0 0";
						mark = "9911";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "509.878 -170.529 34.8301";
						rotation = "0 0 0";
						mark = "9912";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "513.817 -179.008 34.9285";
						rotation = "0 0 0";
						mark = "9913";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "481.25 -166.875 34.8319";
						rotation = "0 0 0";
						mark = "9914";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "500.286 -172.811 34.8314";
						rotation = "0 0 0";
						mark = "9915";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.625 33.3665 34.0638";
						rotation = "0 0 0";
						mark = "9916";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "513.817 -179.008 34.9285";
						rotation = "0 0 0";
						mark = "9917";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "478 -48.0544 34.0638";
						rotation = "0 0 0";
						mark = "9918";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.555 25.9905 34.0638";
						rotation = "0 0 0";
						mark = "9919";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "490.125 -161.5 34.8301";
						rotation = "0 0 0";
						mark = "9920";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.875 23.6655 34.0638";
						rotation = "0 0 0";
						mark = "9921";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.637 -115.125 40.315";
						rotation = "0 0 0";
						mark = "9922";
					};
				};
			};
		};

//--- export object end ---//
}

function MainAI::Radio1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 10;
			showname = "Co Eli R D10 (3) [3]";
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "476.065 10.9383 26.0638";
						rotation = "0 0 0";
						mark = "9923";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.681 25.8322 26.0638";
						rotation = "0 0 0";
						mark = "9924";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "466.25 32.102 26.064";
						rotation = "0 0 0";
						mark = "9925";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "463.5 31.816 26.064";
						rotation = "0 0 0";
						mark = "9926";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "459.639 33.8049 26.0638";
						rotation = "0 0 0";
						mark = "9927";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "458.5 29.125 29.5625";
						rotation = "0 0 0";
						mark = "9928";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "462.125 29.25 29.5625";
						rotation = "0 0 0";
						mark = "9929";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "462 34.1353 33.1607";
						rotation = "0 0 0";
						mark = "9930";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "459.27 33.9375 33.1607";
						rotation = "0 0 0";
						mark = "9931";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "458.659 31.6134 33.7616";
						rotation = "0 0 0";
						mark = "9932";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "451.875 31.0065 34.0638";
						rotation = "0 0 0";
						mark = "9933";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "452.677 23.7648 34.0638";
						rotation = "0 0 0";
						mark = "9934";
					};
				};
				instant SimGroup "React";
			};
			instant SimGroup "Infantry M16 NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.5 10.4723 26.0638";
						rotation = "0 0 0";
						mark = "9935";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "474.276 15.7517 26.0638";
						rotation = "0 0 0";
						mark = "9936";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.75 18.7697 26.0638";
						rotation = "0 0 0";
						mark = "9937";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "471 22.0117 26.0638";
						rotation = "0 0 0";
						mark = "9938";
					};
				};
				instant SimGroup "React" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.013 16.8435 26.0653";
						rotation = "0 0 0";
						mark = "9939";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "471 22.0127 26.0672";
						rotation = "0 0 0";
						mark = "9940";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "473.25 18.8254 26.065";
						rotation = "0 0 0";
						mark = "9941";
					};
				};
			};
			instant SimGroup "Infantry Shotgun NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "478.958 13.1829 26.07";
						rotation = "0 0 0";
						mark = "9942";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "476.254 17.519 26.07";
						rotation = "0 0 0";
						mark = "9943";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "476.125 20.7798 26.07";
						rotation = "0 0 0";
						mark = "9944";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "470.647 40.9241 26.07";
						rotation = "0 0 0";
						mark = "9945";
					};
				};
				instant SimGroup "React";
			};
		};

//--- export object end ---//
}

function MainAI::Radio2()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 10;
			showname = "In M16 Vet R D10 (2) [2]";
			instant SimGroup "SpecOps MP5 NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "276.625 -27.2897 20.3538";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9946";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "282.637 -13.4039 17.7813";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "9947";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "320.816 -35.857 9.94222";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9948";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "344.405 -46.4056 10.1158";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9949";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "356.66 -44.5138 11.7959";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9950";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "402.066 -46.1672 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9951";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "419.646 -43.1306 10.9567";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9952";
						isInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "413.181 -1.76254 10.3314";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9953";
						isInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "412.75 6.05936 11.3656";
						rotation = "0 0 0";
						mark = "9954";
						isInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "415.699 -15.4339 9.77672";
						rotation = "0 0 0";
						mark = "9955";
						isInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "408.75 -47.6147 10.2292";
						rotation = "0 0 0";
						mark = "9956";
						isInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "350.4 -45.3651 11.5897";
						rotation = "0 0 0";
						mark = "9957";
						isInitialPath = "0";
					};
				};
			};
			instant SimGroup "Infantry LAW" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "336.934 44.6114 47.9869";
						rotation = "0 0 0";
						mark = "9958";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "352.001 16.5 41.206";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9959";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "359.916 -2.44932 31.4644";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "9960";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "351.827 16.4949 41.2029";
						rotation = "0 0 0";
						mark = "9961";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "359.837 -2.47382 31.4644";
						rotation = "0 0 0";
						mark = "9962";
					};
				};
			};
		};

//--- export object end ---//
}