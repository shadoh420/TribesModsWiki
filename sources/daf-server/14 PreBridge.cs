
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                          PREBRIDGE                                          *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["PreBridge"] = 3;
$AAISpawning::QuadrantTrigger[14] = "PreBridge";
$AAISpawning::GroupDelay["PreBridge", 0] = 5;
$AAISpawning::GroupDelay["PreBridge", 1] = 3;
$AAISpawning::GroupDelay["PreBridge", 2] = 5;
$AAISpawning::TriggerWithoutFlag[14] = 1;
	
function PreBridge::AIDelay0()
{
//--- export object begin ---//
instant SimGroup "NewDelay" {
			delay = 5;
			showname = "PreBridge D5 (13)";
			instant SimGroup "Infantry Shotgun Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "69.6325 120.838 61.7151";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10712";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "98.4476 16.9157 24.3441";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10713";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "102.285 9.05616 17.3964";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10714";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "114.625 14.1849 16.8708";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10715";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "114.625 13.8003 16.7438";
						rotation = "0 0 0";
						mark = "10716";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "101.804 15.9316 15.976";
						rotation = "0 0 0";
						mark = "10717";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "98.2126 17.1728 24.2637";
						rotation = "0 0 0";
						mark = "10718";
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
						position = "65.8434 121.625 61.8593";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10280";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "92.3058 15.5994 23.5345";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10281";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "85.5445 12.7188 13.5444";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10282";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "115.688 -2.42481 15.7797";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10283";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "119.949 -21.7538 20.9178";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10284";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "120.148 -21.9113 21.0307";
						rotation = "0 0 0";
						mark = "10285";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "115.75 -2.64002 15.7568";
						rotation = "0 0 0";
						mark = "10286";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "82.9048 14.2743 13.1829";
						rotation = "0 0 0";
						mark = "10287";
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
						position = "69.545 24.922 22.75";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10288";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "63.4887 18.6375 12.6462";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10289";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "84.6446 13.6372 13.4209";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10290";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "84.9272 16.1284 13.5107";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10291";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "84.8144 13.3578 13.4442";
						rotation = "0 0 0";
						mark = "10292";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "85.243 16.0407 13.5183";
						rotation = "0 0 0";
						mark = "10293";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "63.9611 18.0673 12.5859";
						rotation = "0 0 0";
						mark = "10294";
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
						position = "75.2032 31.7323 23.7768";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10295";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "82.927 39.5371 30.9613";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						nostop = "1";
						mark = "10296";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "82.8166 34.0453 29.2269";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10297";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "68.2993 20.1647 26.5871";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10298";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "69.7633 19.4389 26.8532";
						rotation = "0 0 0";
						mark = "10299";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "72.5533 21.9676 27.3606";
						rotation = "0 0 0";
						mark = "10300";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "78.223 27.6198 28.3915";
						rotation = "0 0 0";
						mark = "10301";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "83.8399 33.1599 29.4129";
						rotation = "0 0 0";
						mark = "10302";
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
						position = "65.5691 29.1002 22.0249";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10303";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "53.8808 19.864 12.5901";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10304";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "59.7808 17.971 17.0625";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10305";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "63.0043 24.3084 13.6503";
						rotation = "0 0 0";
						mark = "10306";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "54.0288 18.1328 12.5567";
						rotation = "0 0 0";
						mark = "10307";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "59.7689 17.8186 17.0922";
						rotation = "0 0 0";
						mark = "10308";
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
						position = "69.9856 29.8394 22.828";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10309";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "68.2138 21.5071 13.752";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10310";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "70.5477 23.8666 14.4679";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10311";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "60.801 20.6875 12.8009";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10312";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "68.2071 21.125 13.6906";
						rotation = "0 0 0";
						mark = "10313";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "70.9169 23.7284 14.5007";
						rotation = "0 0 0";
						mark = "10314";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "SpecOps MP5 Vet NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "59.5567 30.8228 17.1282";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10315";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry Shotgun" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "15.5542 -13.4183 9.85984";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10316";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "16.25 -10.0625 9.63542";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10317";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "21.0257 -11.3173 9.64559";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10318";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "26.6149 -12.267 9.61306";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10319";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "26.6039 -12.1142 9.65961";
						rotation = "0 0 0";
						mark = "10320";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Infantry Shotgun Vet NoPatrol" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "67.6875 31.2201 22.4099";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10321";
						useInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "71.3802 34.4115 23.0817";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						nostop = "1";
						mark = "10322";
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
						position = "47.6603 -114.921 50.9642";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10323";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "58.2923 -54.6601 41.9229";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10324";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "48.9352 -55.2623 41.1051";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10325";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "58 -54.8281 41.9821";
						rotation = "0 0 0";
						mark = "10326";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "47.8619 -55.5625 41.1103";
						rotation = "0 0 0";
						mark = "10327";
						isInitialPath = "-1";
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
						position = "13.8196 -72.7055 44.842";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10328";
						isInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "57.119 -10.9913 10.9073";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10329";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "31.413 -28.2621 15.8427";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10330";
						isInitialPath = "1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "57.3608 -11.0221 11.0497";
						rotation = "0 0 0";
						mark = "10331";
						isInitialPath = "-1";
					};
				};
			};
			
		};	
//--- export object end ---//
}

function PreBridge::AIDelay2()
{
//--- export object begin ---//


	instant SimGroup "NewDelay" {
		Delay = 5;
		spawnall = 1;
		movetogether = 1;
		instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "15.8501 -74.2073 44.0584";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10332";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "39.2143 -38.7811 27.4721";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10333";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "59.9433 -12.7052 12.2705";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10334";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "60.0037 -12.8298 12.2802";
						rotation = "0 0 0";
						mark = "10335";
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
						position = "18.1219 -72.7197 44.4576";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10336";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "34.7405 -48.3618 34.3918";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10337";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "54.6442 -23.2167 19.5027";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10338";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "61.3795 -15.8209 12.4661";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10339";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "61.4722 -15.4683 12.6015";
						rotation = "0 0 0";
						mark = "10340";
						isInitialPath = "-1";
					};
				};
			};
};
function PreBridge::AIDelay1()
{
//--- export object begin ---//


	instant SimGroup "NewDelay" {
			Delay = 10;
			showname = "PreBridge D10 (4)";
			instant SimGroup "Infantry SAW" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-40.278 66.9031 37.0981";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10341";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-42.9922 61.2729 36.4517";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10342";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-36.6957 62.2531 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10343";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-30.6932 32.7392 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10344";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-28.854 31.2437 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10345";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-38.1532 63.6326 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10346";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-36.2845 61.6875 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10347";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-11.4821 -44.7306 37.9517";
						rotation = "0 0 0";
						mark = "10348";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-17.0769 -19.4947 37.9517";
						rotation = "0 0 0";
						mark = "10349";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-27.8524 23.9867 37.9517";
						rotation = "0 0 0";
						mark = "10350";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-19.2846 -12.2525 37.9517";
						rotation = "0 0 0";
						mark = "10351";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-36.3602 61.9395 37.9517";
						rotation = "0 0 0";
						mark = "10352";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-32.5636 46.9519 37.9517";
						rotation = "0 0 0";
						mark = "10353";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-28.5951 31.1804 37.9517";
						rotation = "0 0 0";
						mark = "10354";
						isInitialPath = "-1";
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
						position = "-10.4144 -55.7792 37.4811";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10355";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.102 -51.4438 36.4517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10356";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-9.21925 -48.0124 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10357";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-17.2583 -21.689 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10358";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-16.0879 -19.802 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10359";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.2282 -50.6639 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10360";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-8.77996 -49.4844 37.9517";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10361";
						isInitialPath = "1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-9.22939 -49.0224 37.9517";
						rotation = "0 0 0";
						mark = "10362";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.0871 -50.2406 37.9517";
						rotation = "0 0 0";
						mark = "10363";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.6272 -43.9901 37.9517";
						rotation = "0 0 0";
						mark = "10364";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-11.5584 -40.0746 37.9517";
						rotation = "0 0 0";
						mark = "10365";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-12.0625 -38.133 37.9517";
						rotation = "0 0 0";
						mark = "10366";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-12.7462 -35.8056 37.9517";
						rotation = "0 0 0";
						mark = "10367";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-13.8935 -33.6445 37.9517";
						rotation = "0 0 0";
						mark = "10368";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-14.203 -31.5802 37.9517";
						rotation = "0 0 0";
						mark = "10369";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-14.5461 -29.7118 37.9517";
						rotation = "0 0 0";
						mark = "10370";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.1313 -27.5856 37.9517";
						rotation = "0 0 0";
						mark = "10371";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-15.5531 -25.6331 37.9517";
						rotation = "0 0 0";
						mark = "10372";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-16.2163 -23.1074 37.9517";
						rotation = "0 0 0";
						mark = "10373";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-16.8851 -20.6941 37.9517";
						rotation = "0 0 0";
						mark = "10374";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-17.2282 -19.0577 37.9517";
						rotation = "0 0 0";
						mark = "10375";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-11.5132 -42.3208 37.9517";
						rotation = "0 0 0";
						mark = "10376";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.5874 -46.3717 37.9517";
						rotation = "0 0 0";
						mark = "10377";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-10.2542 -47.5096 37.9517";
						rotation = "0 0 0";
						mark = "10378";
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
						position = "19.8704 27.2986 11.7268";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10379";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "23.7732 19.4645 9.80687";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10380";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "17.1135 12.4414 9.34999";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10381";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "19.2228 -8.06479 9.56699";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10382";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "18.9275 -10.4771 9.70271";
						rotation = "0 0 0";
						mark = "10383";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "23.4929 19.1627 9.74466";
						rotation = "0 0 0";
						mark = "10384";
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
						position = "19.0691 31.6252 13.8331";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10385";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "20.042 35.2038 16.9496";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10386";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "29.2248 35.8834 19.0368";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10387";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "30.0182 28.5251 14.2047";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10388";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "29.9828 27.8094 13.8445";
						rotation = "0 0 0";
						mark = "10389";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "20.9945 33.3018 15.3293";
						rotation = "0 0 0";
						mark = "10390";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "23.983 34.4313 16.5629";
						rotation = "0 0 0";
						mark = "10391";
						isInitialPath = "-1";
					};
				};
			};
		};
	//--- export object end ---//
	}	

	