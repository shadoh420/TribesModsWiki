




//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                           MAIN AI                                           *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["MainAI"] = 1;
$AAISpawning::QuadrantTrigger[0] = "MainAI";
$AAISpawning::GroupDelay["MainAI", 0] = 0;

function MainAI::AIDelay0()
{
instant SimGroup "NewDelay" {
	Delay = 0;
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
				position = "459.5 -144.927 44.5965";
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
	instant SimGroup "Commander Elite" {
		instant SimPath "Patrol" {
			isLooping = "False";
			isCompressed = "False";
			instant Marker "Marker1" {
				dataBlock = "PathMarker";
				name = "";
				position = "394.135 -401.125 596.375";
				rotation = "0 -0 -0.125047";
				useInitialPath = "1";
				mark = "9841";
			};
		};
		instant SimPath "React" {
			isLooping = "False";
			isCompressed = "False";
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
						isInitialPath = "1";
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

function AmbushBridge::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			delay = 5;
			showname = "AmbushBridge D5 (8) [2]";
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.3374 -9.53353 37.9519";
						rotation = "0 0 0";
						useInitialPath = "1";
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
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-20.6934 -1.02798 37.9519";
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
				};
			};
			instant SimGroup "SpecOps MP5 Elite NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
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
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
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
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimGroup "Patrol" {
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
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
						useInitialPath = "0";
						mark = "8928";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-26.9575 26.357 10";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10740";
					};
				};
				instant SimGroup "React" {
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
						useInitialPath = "-1";
						mark = "10738";
						isInitialPath = "1";
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
						isInitialPath = "1";
						mark = "10482";
						useInitialPath = "-1";
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

function Exit::AIRadio0()
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

function Exit::AIRadio1()
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
		
