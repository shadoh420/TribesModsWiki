
//=========================================================================================================================================
// Client Options
//=========================================================================================================================================

$Shifter::PersonalSkin = True;								//== Personal Skins On or Off

//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

$Shifter::AutoSuperAdmin = True;							//== Auto Super Admin
$Shifter::AdminName = "Emo1313";							//== AutoSuper Admin Player Name 1
$Shifter::AdminIP = "*.*.*.*";								//== AutoSuper Admin IP 1
$Shifter::AdminName1 = "Karaya";							//== AutoSuper Admin Player Name 2
$Shifter::AdminIP1 = "*.*.*.*";								//== AutoSuper Admin IP 2
$Shifter::AdminName2 = "nooneithink";						//== AutoSuper Admin Player Name 3
$Shifter::AdminIP2 = "*.*.*.*";								//== AutoSuper Admin IP 3  

//=========================================================================================================================================
// Server Options
//=========================================================================================================================================

$Shifter::SpawnRandom = True;								//== Turn on Random Spawn Setup?
$Shifter::VoteAdmin = True;									//== Can players initiate vote to admin
$Shifter::VoteKick = True;									//== Can players initiate vote to kick

//=========================================================================================================================================
// Advanced Scoring System
//=========================================================================================================================================
$ScoreOn = True;		    //== If True will show client thier score on change in a bottom print message for 3 seconds.

$Score::25Meters = "7";     //== Less Than 25 Meters To Flag
$Score::75Meters = "5";     //== From 25 to 75 Meters
$Score::150Meters = "2";    //== From 75 to 150 Meters
$Score::250Meters = "1";    //== From 150 to 250 Meters

$Score::FlagCapture = "15";	//== Points For A Successful Flag Capture 
$Score::FlagKill = "5";  	//== Bonus For Killing Flag Runner
$Score::FlagDef  = "3";   	//== Bonus Points For Defending The Runner
$Score::FlagReturn = "3";   //== Points For Returning Dropped

$Score::CaptureOdj = "2";   //== Points For Capturing An Objective
$Score::HoldingObj = "5";   //== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = "2";   //== Points For Getting The Objective First

$Score::ObjDestroy = "15";  //== Objective Destroyed

$Score::ObjStationS = "7";    //== Destroy Supply Station 
$Score::ObjStationA = "5";    //== Destroy Ammo Station or Command
$Score::ObjStationR = "3";    //== Destroy Remote Station
$Score::ObjFlier = "3";       //== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "10"; //== Destroy Large Generator
$Score::ObjGeneratorS = "5";  //== Destroy Small Generator including - Panels
$Score::ObjSensor = "5";      //== Destroy Large Sensors
$Score::ObjSensor = "2";      //== Destroy Deployable Sensors

$Score::ObjTurretL = "8";     //== Large Turrets
$Score::ObjTurretS = "1";     //== Deployable Turrets

$Score::Kill15Meters = "0";		//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";		//== Kill From 15 to 50m
$Score::Kill100Meters = "1";	//== Kill From 50 to 100m
$Score::Kill250Meters = "2";	//== Kill From 100 to 250m
$Score::Kill250Plus = "3";		//== Kill 250m Or More

$Shifter::SpawnSafe = "10";   //== If the player is killed before X - Only Half Points Are Awarded.


//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================

$Shifter::TeamKillOn 	= "True";							//== Is Anti TK On/Off
$Shifter::KillTerm 		= "2";								//== Number Of Time A Player Can Team Kill
															//== Before Being Terminated (Killed By Server)
//============================================================== Message To Banned Team Killer
$Shifter::TeamKillMsg = "You have been kickbanned for team killing, i hope you enjoyed it.";

$SHAntiTeamKillWarnKills 	= "1";         //== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "600";	   //== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "4";		   //== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "50";        //== Proximity Distance For Accidental Damage.
	
//=========================================================================================================================================
// Bot Options
//=========================================================================================================================================


$Shifter::BotsGoCrazy = "False";		//== Do Bots have a chance of ShortCircuiting and Spawning as not on a team.

$Shifter::AntiTKBots = False;			//== Will Bots Attack Own Team From Team Damage

$Shifter::AutoSpawnEven = True;			//== This will autoSpawn Bots Until The Teams A Even And No More, Used With The AutoSpawn Below.
										//== Up to 3 Exra Bots Will be added per team to even the odds.
										//== If the teams are already even the bots will autospawn up to the max players listed here.
										
$Shifter::PlayerMax = "12";				//== Max Player With Bots, This needs to be higher than you total max players.
										
$Shifter::AreThereBots = True;			//== Are there bots? Allow Or DisAllow Bots Spawned By Players

$Shifter::BotsAttackBots = True;		//== Do Bots Automatically Attack Bots When Game Starts. This will make the bots attack right off.
										//== This can lead to a sluggish server...
										
$Spoonbot::AutoSpawn = True;			//== Automatic bot-spawning True = Spawns Bots Below up to 20 Bots can be Spawned Automatically
$Spoonbot::RespawnDelay = 30;			//== How many seconds until bots respawn after being killed?
$Spoonbot::IQ = 90;						//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.
$Spoonbot::ThinkingInterval = 10;		//== Interval in sec between which bots will "reconsider" their situation
										//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
$Spoonbot::BotsRetreat = True;			//== Bots will retreat if severely damaged
$Spoonbot::RetreatDamageLevel = 0.8;	//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.
$Spoonbot::BotJetting = True;			//== The bot "jetting" is very "jumpy" right now, so you can switch that off if it annoys you
$Spoonbot::BotChat = True;				//== If the bot's chat messages annoy you, you can turn them off here.




//=================================================== Now, the auto-spawned bots are being set up... 
//=================================================== Each Name Per Team MUST Be Unique!!!
//== The name must contain one for the following so that they will spawn as special bot classes.
//== 
//== Guard  = Dreadnaught
//== Sniper = Sniper Bot
//== Demo   = Standard Burster w/ varrious weapons
//== Miner  = Standard Light, doesnt mine yet.
//== Medic  = Engineer Bot

$Spoonbot::NumBots = 8;									//== Total Number of bots

$Spoonbot::Bot1Name = "T0_Demo_Female_Roam";
$Spoonbot::Bot1Team = 0;
$Spoonbot::Bot2Name = "T0_Guard_Male";
$Spoonbot::Bot2Team = 0;
$Spoonbot::Bot3Name = "T0_Sniper_Male_Roam";
$Spoonbot::Bot3Team = 0;
$Spoonbot::Bot4Name = "T0_Medic_Male_Roam";
$Spoonbot::Bot4Team = 0;

$Spoonbot::Bot5Name = "T1_Demo_Male_Roam";
$Spoonbot::Bot5Team = 1;
$Spoonbot::Bot6Name = "T1_Guard_Male";
$Spoonbot::Bot6Team = 1;
$Spoonbot::Bot7Name = "T1_Sniper_Male_Roam";
$Spoonbot::Bot7Team = 1;
$Spoonbot::Bot8Name = "T1_Medic_Female_Roam";
$Spoonbot::Bot8Team = 1;

//=========================================================================================================================================
// Set Default Anti-TK Functions
//=========================================================================================================================================

if($SHAntiTeamKillWarnKills == "")
	$SHAntiTeamKillWarnKills = 1;
if($SHAntiTeamKillBanTime == "")
	$SHAntiTeamKillBanTime = 600;
if($SHAntiTeamKillMaxKills == "")
	$SHAntiTeamKillMaxKills = 2;
if($SHAntiTeamKillProximity == "")
    $SHAntiTeamKillProximity = 50;

//======================================================= Admin Checking Scheme
function Shifter::CheckAdmin(%cl){
     %address = Client::getTransportAddress(%cl);
     //%string = String::replace(%address, ":", " ");
	 
     %ip1 = getword(%string,1);
     %ip2 = $Shifter::AdminIP;
	 
     %name1 = Client::getName(%cl);
     %name2 = $Shifter::AdminName;
	 
     for(%i = 0; %i < 4; %i++)
	 {
       %ipword1[%i] = getword(%string1,%i);
       %ipword2[%i] = getword(%string2,%i);
     }
	   
//======================================================= Check Admin And IP

 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;

 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;
	 	 
//======================================================= Check Admin1 And IP1

     %ip2 = $Shifter::AdminIP1;
     %name2 = $Shifter::AdminName1;


 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;
	 
 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;

//======================================================= Check Admin1 And IP1

     %ip2 = $Shifter::AdminIP2;
     %name2 = $Shifter::AdminName2;

 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;
	 
 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;

 else
     return false;
}    






















