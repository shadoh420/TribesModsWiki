
//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                          PREBRIDGE                                          *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["PreBridge"] = 2;
$AAISpawning::QuadrantTrigger[15] = "PreBridge";
$AAISpawning::GroupDelay["PreBridge", 0] = 5;
$AAISpawning::GroupDelay["PreBridge", 1] = 3;


	
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
						isInitialPath = "1";
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
						isInitialPath = "1";
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
						isInitialPath = "1";
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
//--- export object end ---//
}

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
		};

//--- export object end ---//
}

function PostBuilding::AIDelay1()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 5;
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

//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                          WALL BREAK                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["WallBreak"] = 3;
$AAISpawning::QuadrantTrigger[25] = "WallBreak";
$AAISpawning::GroupDelay["WallBreak", 0] = 7.5;
$AAISpawning::GroupDelay["WallBreak", 1] = 10;
$AAISpawning::GroupDelay["WallBreak", 1] = 2.5;

		
		
		

function WallBreak::AIDelay0()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 7.5;
			showname = "WallBreak D7.5 (5)";
			instant SimGroup "Infantry M16 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.346 -34.4791 33.1619";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10746";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.83 -30.3996 37.1259";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10739";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.077 -19.8528 37.1262";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10743";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.386 -20.0159 37.1271";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10738";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.608 -14.7262 39.1264";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10740";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-357.81 -14.5044 39.1271";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10744";
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
						position = "-356.646 -29.5994 33.1658";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10272";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.381 -34.8666 33.1616";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10273";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.226 -30.8323 37.1261";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10274";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.45 -20.3611 37.1261";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10275";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.421 -15.392 39.1256";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10276";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.398 -15.805 39.1251";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10277";
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
						position = "-352.951 -31 33.1637";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10278";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.798 -28.9845 33.1662";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10279";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.452 -34.6129 33.1618";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10280";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.945 -30.9212 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10281";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.225 -23.7534 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10282";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-343.091 -21.2515 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10283";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-343.945 -19.0106 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10284";
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
						position = "-353.788 -25.3001 33.1677";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10655";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.23 -30.378 33.1635";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10656";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.252 -26.3358 33.1678";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10657";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.258 -32.3499 33.1635";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10658";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.345 -34.8022 33.1616";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10659";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-344.928 -30.851 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10660";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.4 -27.4072 37.126";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10661";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-341.278 -24.9188 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10662";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-339.875 -26.884 39.125";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10663";
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
						position = "-383.852 117.875 66.6339";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10294";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.607 40.1122 49.1911";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10295";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.912 27.991 38.1325";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10296";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.752 29.2229 37.3579";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10297";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-392.506 21.6501 42.5126";
						rotation = "0 0 0";
						mark = "10298";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-388.59 29.035 37.5155";
						rotation = "0 0 0";
						mark = "10299";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-392.575 21.9267 42.3004";
						rotation = "0 0 0";
						mark = "10300";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::AIDelay1()
{
//--- export object begin ---//
instant SimGroup "AI Delay10" {
			showname = "WallBreak D10 (4)";
			instant SimGroup "SpecOps MP5 Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.142 -29.3942 33.1638";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10301";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.475 -25.2225 33.1673";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10302";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.859 -30.2638 33.1638";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10303";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.335 -25.6982 33.1676";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10304";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.915 -31.1093 33.1636";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10305";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.839 -26.4041 33.1676";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10306";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-355.352 -32.5973 33.1634";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10307";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.595 -34.702 33.1618";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10308";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.795 -31.4956 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10309";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-348.161 -26.773 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10310";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-341.76 -23.5245 39.125";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10311";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-326.034 -17.4817 25.1149";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10312";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-300.354 -7.8692 24.3609";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10313";
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
						position = "-352.187 -25.0439 33.1673";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10813";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.975 -23.8788 33.169";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10814";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.125 -25.2283 33.1672";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10815";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-350.589 -29.1759 33.1641";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10816";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.231 -25.9137 33.1674";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10817";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.077 -30.5707 33.1637";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10818";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.608 -26.2363 33.168";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10819";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.25 -31.2833 33.1639";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10820";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.455 -29.6331 33.1657";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10821";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-354.856 -34.5953 33.1619";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10822";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.228 -30.9003 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10823";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.5 -19.7966 37.1263";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10824";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.401 -15.1895 39.1257";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10825";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-306.645 23.5105 26.3414";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10826";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "SpecOps MP5 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-210.67 164.928 66.1302";
						rotation = "0 0 0";
						mark = "10328";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-224.699 80.8376 60.7425";
						rotation = "0 0 0";
						mark = "10329";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-386.542 -4.81478 16.1625";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10268";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-395.52 -10.9663 15.8284";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10272";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-391.125 -22.9689 21.7398";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10274";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.237 -2.26714 19.7767";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10276";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-390.149 -20.0625 20.5771";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10278";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.98 -19.3966 20.5608";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10280";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-383.134 -2.42318 19.7587";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10282";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::AIDelay2()
{
//--- export object begin ---//
instant SimGroup "AI Delay2.5" {
			showname = "WallBreak D2.5 (7) [1]";
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-329.222 181.66 56.5316";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10330";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-255.924 52.8569 29.2939";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10331";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.605 15.2151 22.9272";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10332";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-258.003 52.9444 29.1842";
						rotation = "0 0 0";
						mark = "10333";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-248.418 14.0949 22.8577";
						rotation = "0 0 0";
						mark = "10334";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-259.25 39.8079 25.9562";
						rotation = "0 0 0";
						mark = "10335";
						isInitialPath = "-1";
					};
				};
			};
			instant SimGroup "Sniper PSG1 Elite Radio" {
				DelayCount = "1";
				DelayID[0] = 0;
				showname = "Sniper PSG1 Elite Radio";
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-346.656 25.9046 40.9957";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10336";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.937 20.7264 39.9957";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10337";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-338 18.9654 39.9957";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10338";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-351.952 18.9943 39.9957";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10339";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.023 19.0917 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10340";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.918 19.25 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10341";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.144 18.9011 39.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10342";
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
						position = "-315.667 -100.037 57.7527";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10266";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-281.635 -28.1332 48.7674";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10267";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.048 2.393 27.9912";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10268";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.049 115.477 69.3144";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10358";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-303.721 31.1733 31.5189";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10359";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-304.382 31.7676 31.5849";
						rotation = "0 0 0";
						mark = "10360";
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
						position = "-383.5 123.5 67.509";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10361";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-365.541 133.033 70.8295";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10362";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.96 48.7175 30.9025";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10363";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-273.017 43.552 28.8965";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10364";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-273.325 43.2959 28.907";
						rotation = "0 0 0";
						mark = "10365";
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
						position = "-383.974 113.719 69.03";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10366";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.761 108.275 71.6064";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10367";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-280.773 47.5236 31.1383";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10368";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.567 36.3326 28.316";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10369";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-278.7 36.5527 28.3769";
						rotation = "0 0 0";
						mark = "10370";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-287.654 50.5391 33.2791";
						rotation = "0 0 0";
						mark = "10371";
						isInitialPath = "-1";
					};
				};
			};
		};
//--- export object end ---//
}

function WallBreak::Radio0()
{
//--- export object begin ---//
			instant SimGroup "NewDelay" {
					Delay = 0;
					showname = "Sn PSG Eli R D0 (1) [1]";
					instant SimGroup "Infantry SAW Vet" {
						instant SimPath "Patrol" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-368.304 120.3 67.4762";
								rotation = "0 0 0";
								useInitialPath = "-1";
								isInitialPath = "1";
								mark = "10349";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-352.012 22.5537 39.9957";
								rotation = "0 0 0";
								useInitialPath = "-1";
								isInitialPath = "1";
								mark = "10350";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-337.819 22.0429 39.9957";
								rotation = "0 0 0";
								useInitialPath = "0";
								isInitialPath = "-1";
								mark = "10351";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-352.231 22.0329 39.9957";
								rotation = "0 0 0";
								useInitialPath = "0";
								isInitialPath = "-1";
								mark = "10352";
							};
						};
						instant SimPath "React" {
							isLooping = "False";
							isCompressed = "False";
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-351.937 22.0284 39.9957";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10353";
							};
							instant Marker "Marker1" {
								dataBlock = "PathMarker";
								name = "";
								position = "-337.875 21.9311 39.9957";
								rotation = "0 0 0";
								isInitialPath = "-1";
								mark = "10354";
							};
						};
					};
				};
//--- export object end ---//
}

//********************************************************************************************************
//********************************************************************************************************
//******                                                                                             *****
//******                                         EMBARKMENTS                                         *****
//******                                                                                             *****
//********************************************************************************************************
//********************************************************************************************************
$AAISpawning::DelayCount["Embankments"] = 2;
$AAISpawning::QuadrantTrigger[27] = "Embankments";
$AAISpawning::GroupDelay["Embankments", 0] = 0;
$AAISpawning::GroupDelay["Embankments", 1] = 7.5;

function Embankments::AIDelay0()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 0;
			showname = "Embankments D0 (7)";
			instant SimGroup "Infantry SAW Elite" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-394.508 22.0389 37";
						rotation = "0 0 0";
						useInitialPath = "1";
						mark = "10655";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.033 23.9277 34.8464";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10656";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-400.503 23.7835 35.0145";
						rotation = "0 0 0";
						mark = "10657";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-394.709 22.0937 36.9354";
						rotation = "0 0 0";
						mark = "10658";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-397.611 22.9459 35.9689";
						rotation = "0 0 0";
						mark = "10659";
						isInitialPath = "-1";
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
						position = "-384.801 -1.85351 16.6309";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10316";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.541 35.0924 50.3583";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10317";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.668 18.3062 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10318";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.25 18.2114 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10319";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.25 18.2673 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10320";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-352.825 18.3206 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10321";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-347.815 18.1937 40.9957";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10322";
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
						position = "-389.003 -11.6542 16.5318";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10323";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-393.303 -23.628 21.781";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10324";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-372.321 -52.1732 55.2093";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10325";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.977 -37.4937 37.1295";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10326";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-359.799 -32.0245 37.1295";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10327";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-361.377 -25.7161 37.1292";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10328";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-365.163 -22.4916 39.1297";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10329";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.274 -14.6483 39.1273";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10330";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.444 -15.2723 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10331";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-337.568 -31.0881 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10332";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.786 -15.9643 39.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10333";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.107 -14.8784 39.1273";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10334";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.625 -26.8584 39.1309";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10335";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-362.025 -40.9953 39.131";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10336";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-369.003 -26.8768 39.131";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10337";
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
						position = "-392.064 -22.428 21.3346";
						rotation = "0 0 0";
						mark = "10338";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-372.194 -53.3558 56.7084";
						rotation = "0 0 0";
						mark = "10339";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.386 -32.398 37.1292";
						rotation = "0 0 0";
						mark = "10340";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-361.677 -41.1798 39.1309";
						rotation = "0 0 0";
						mark = "10341";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-364.717 -36.1118 39.1311";
						rotation = "0 0 0";
						mark = "10342";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-367.125 -30.7919 39.131";
						rotation = "0 0 0";
						mark = "10343";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.679 -27.1662 39.131";
						rotation = "0 0 0";
						mark = "10344";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-364.571 -21.1813 39.1294";
						rotation = "0 0 0";
						mark = "10345";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.823 -14.1782 39.1274";
						rotation = "0 0 0";
						mark = "10346";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-338.108 -30.9852 39.125";
						rotation = "0 0 0";
						mark = "10347";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-345.42 -15.7568 39.125";
						rotation = "0 0 0";
						mark = "10348";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-358.528 -14.4862 39.1273";
						rotation = "0 0 0";
						mark = "10349";
						nostop = "1";
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
						position = "-388.342 -10.481 16.2834";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10350";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-398.66 -0.164905 15.8284";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10351";
						nostop = "1";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-305.625 5.51655 21.8317";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10352";
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
						position = "-307.088 5.84724 21.5625";
						rotation = "0 0 0";
						mark = "10353";
						nostop = "1";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-384.529 -0.859302 16.7733";
						rotation = "0 0 0";
						mark = "10354";
						nostop = "1";
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
						position = "-402.808 33.0235 31.0992";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10355";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-400.126 37.2501 37.5";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10356";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.763 24.7394 38.924";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10357";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.189 32.5192 33.4793";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10358";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.957 24.5965 39.0069";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10359";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-401.091 31.9952 33.8776";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10360";
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
						position = "-391.875 30.3198 34.0845";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10361";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-387.6 14.8955 23.1013";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10362";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-389.281 15.1216 22.739";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10363";
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
						position = "-390.778 16.8271 19.2666";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10364";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-393.913 26.652 28.1194";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10365";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-395.71 16.8879 18.5905";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10366";
						useInitialPath = "0";
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

function Embankments::AIDelay1()
{
//--- export object begin ---//
		instant SimGroup "NewDelay" {
			Delay = 7.5;
			showname = "Embankments D7.5 (5)";
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-403.541 14.6033 16.9899";
						rotation = "0 0 0";
						useInitialPath = "-1";
						mark = "10367";
						isInitialPath = "1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.192 9.40327 17.6391";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10368";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-404.506 23.786 21.125";
						rotation = "0 0 0";
						useInitialPath = "0";
						mark = "10369";
						isInitialPath = "-1";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-407.653 9.71149 17.5324";
						rotation = "0 0 0";
						mark = "10370";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-405.273 23.7592 20.8726";
						rotation = "0 0 0";
						mark = "10371";
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
						position = "-462.974 20.3482 12.7564";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10372";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-463.102 16.5494 11.7747";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10373";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-463 16.9703 11.8036";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10374";
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
						position = "-381.819 -120.663 70.5875";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10316";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-369.358 -65.6817 69.2852";
						rotation = "0 0 0";
						useInitialPath = "-1";
						isInitialPath = "1";
						mark = "10313";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-424.014 -25.7431 16.2292";
						rotation = "0 0 0";
						useInitialPath = "0";
						isInitialPath = "-1";
						mark = "10314";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-424.125 -25.6275 16.27";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10319";
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
						position = "-379.359 -124.072 70.2246";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10319";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-368.073 -65.0499 69.1987";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10317";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-370.125 -15.4617 17.375";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10302";
						useInitialPath = "0";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-356.25 -9.39632 16.6374";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10379";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
				};
			};
			instant SimGroup "Infantry SAW Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-464.81 -35.84 28.9009";
						rotation = "0 0 0";
						isInitialPath = "1";
						mark = "10313";
						useInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-419.791 -29.5809 20.1556";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10379";
						useInitialPath = "0";
					};
				};
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-420 -29.798 20.0646";
						rotation = "0 0 0";
						isInitialPath = "-1";
						mark = "10320";
					};
				};
			};
		};
//--- export object end ---//
}

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
			showname = "ExtractionPoint D7.5 (4)";
			instant SimGroup "Infantry M16 Vet" {
				instant SimPath "Patrol" {
					isLooping = "False";
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
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-488.336 22.192 10.1299";
						rotation = "0 0 0";
						mark = "10827";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-476.857 17.1622 10.7041";
						rotation = "0 0 0";
						mark = "10828";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-503.722 27.8206 12.5831";
						rotation = "0 0 0";
						mark = "10829";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-558.609 23.9552 9.80882";
						rotation = "0 0 0";
						mark = "10830";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-515.341 31.5722 15.1201";
						rotation = "0 0 0";
						mark = "10831";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-539.29 7.71631 10";
						rotation = "0 0 0";
						mark = "10832";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-759.618 49.8065 28.6915";
						rotation = "0 0 0";
						mark = "10833";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-621.926 -5.52119 10.0627";
						rotation = "0 0 0";
						mark = "10834";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-681.668 -38.2604 9.9767";
						rotation = "0 0 0";
						mark = "10835";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-734.265 -1.94568 19.043";
						rotation = "0 0 0";
						mark = "10836";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-462.847 17.9525 12.1121";
						rotation = "0 0 0";
						mark = "10837";
						isInitialPath = "-1";
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
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-451.163 -14.1424 12.5006";
						rotation = "0 0 0";
						mark = "10845";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-762.799 45.1185 26.3301";
						rotation = "0 0 0";
						mark = "10846";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-513.615 -29.8967 11.9284";
						rotation = "0 0 0";
						mark = "10847";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-493.056 -23.9526 11.8839";
						rotation = "0 0 0";
						mark = "10848";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-682.869 -43.275 10";
						rotation = "0 0 0";
						mark = "10849";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.326 -3.50873 18.9334";
						rotation = "0 0 0";
						mark = "10850";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-471.893 -18.9174 13.2963";
						rotation = "0 0 0";
						mark = "10851";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-555.542 -21.933 9.9381";
						rotation = "0 0 0";
						mark = "10852";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-540.438 -24.988 10.3168";
						rotation = "0 0 0";
						mark = "10853";
						isInitialPath = "-1";
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
				instant SimPath "React" {
					isLooping = "False";
					isCompressed = "False";
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-473.243 -12.0984 11.0458";
						rotation = "0 0 0";
						mark = "10863";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-487.563 -7.78229 9.65079";
						rotation = "0 0 0";
						mark = "10864";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-522.85 -9.73023 10";
						rotation = "0 0 0";
						mark = "10865";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-543.866 -2.15668 10";
						rotation = "0 0 0";
						mark = "10866";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-559.491 8.39887 9.97499";
						rotation = "0 0 0";
						mark = "10867";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-623.625 -9.6363 10";
						rotation = "0 0 0";
						mark = "10868";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-683.765 -40.1581 10";
						rotation = "0 0 0";
						mark = "10869";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-737.25 -0.970331 19.2333";
						rotation = "0 0 0";
						mark = "10870";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-765.244 49.3425 28.395";
						rotation = "0 0 0";
						mark = "10871";
						isInitialPath = "-1";
					};
					instant Marker "Marker1" {
						dataBlock = "PathMarker";
						name = "";
						position = "-540.268 2.76752 10";
						rotation = "0 0 0";
						mark = "10872";
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

function ExtractionPoint::RandomAI()
{
//--- export object begin ---//
	instant SimGroup "NewDelay" {
			Delay = 15;
			showname = "ExtractionPoint D15 (1)";
			instant SimGroup "Random Elite" {
				AAIFuncOnDeath = "ExtractionPoint::RandomSpawnsLoop";
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

function ExtractionPoint::RandomSpawnsLoop()
{
	$ExtractionPoint::RandomSpawnCount++;
	if($ExtractionPoint::RandomSpawns>20)
		return;
	
	LoadDelayGroup("ExtractionPoint", "RandomAI");


}

function ExtractionPoint::AIDelay()
{
//--- export object begin ---//

//--- export object end ---//
}
function Type::AIDelay()
{
//--- export object begin ---//

//--- export object end ---//
}