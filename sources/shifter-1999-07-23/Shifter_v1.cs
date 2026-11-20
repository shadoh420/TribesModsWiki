//=========================================================================================================================================
// Client Options
//=========================================================================================================================================


//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

//==== Wild card IP's must just be left blank. Do NOT use the * in place of an octet. Note below for an example.

$Server::AutoAdmin0 = "Emo1313";				// Enter the PlayerName to be given Admin here
$Server::AutoAdmin1 = "Emo1313";
$Server::AutoAdmin2 = "Karaya";
$Server::AutoAdmin3 = "Karaya";
$Server::AutoAdmin4 = "Emo1313";
$Server::AutoAdmin5 = "Thai";

$Server::AutoAdminAddr0 = "IP:192.168.0";       //== Enter The Players Address Here
$Server::AutoAdminAddr1 = "IP:207.13.31.10";
$Server::AutoAdminAddr2 = "IP::209.196";
$Server::AutoAdminAddr3 = "IPX";
$Server::AutoAdminAddr4 = "IPX";
$Server::AutoAdminAddr5 = "IP:208";
							
//=========================================================================================================================================
// Server Options
//=========================================================================================================================================

$Shifter::Weapons = True;                               //== Advanced Weapon Options On 
$Shifter::emailAddress = "emo1313@dopplegangers.com";	//== Email address to show banned users for reinstatement
$Shifter::VoteAdmin =  False;							//== Can players initiate vote to admin
$Shifter::VoteKick = True;								//== Can players initiate vote to kick
$Shifter::VoteFFA = False;								//== Clients can Vote For FFA or Tournement Mode
$Shifter::RandomMissions = True;						//== Random Missions on/off

$Shifter::KeepBalanced = True;							//== Keep Balanced
$Shifter::SpawnRandom = True;							//== Turn on Random Spawn Setup?
$Shifter::NoOutside = True;								//== Turn on Outside of mission area damage
$Shifter::TurretKill = False;                           //== Turret Kills Count For Player
$Shifter::PersonalSkin = True;				//== Personal Skins On or Off

//=========================================================================================================================================
// Advanced Flag Options
//=========================================================================================================================================
$Shifter::FlagNoReturn = "True";
$Shifter::FlagReturnTime = "400";

//=========================================================================================================================================
// Advanced Scoring System
//=========================================================================================================================================
$ScoreOn = True;		    		//== If True will show client thier score on change in a bottom print message for 3 seconds.

$Score::25Meters = "5";     		//== Less Than 25 Meters To Flag
$Score::75Meters = "3";     		//== From 25 to 75 Meters
$Score::150Meters = "2";    		//== From 75 to 150 Meters
$Score::250Meters = "1";    		//== From 150 to 250 Meters

$Score::FlagCapture = "15";			//== Points For A Successful Flag Capture 
$Score::FlagKill = "7";  			//== Bonus For Killing Flag Runner
$Score::FlagDef  = "3";   			//== Bonus Points For Defending The Runner
$Score::FlagReturn = "3";   		//== Points For Returning Dropped

$Score::CaptureOdj = "2";   		//== Points For Capturing An Objective
$Score::HoldingObj = "5";   		//== Points For Holding An Objective For 60 Seconds.
$Score::InitialObj = "2";   		//== Points For Getting The Objective First

$Score::ObjDestroy = "15";      	//== Objective Destroyed
 
//=========================================================================================================================================
// Note about the following section... These points are awarded for destroying the enemy stations, generators, etc. 
// These points are also used in a calculation to give points for repairing things on your own team and to deduct points for
// repairing things on the enemy's team.
//
// The Lower option, Score::RepairObject is a base repair score. You can make this zero if you do not want players to get the 
// base 1 point ofr repairing... 
//
// You do NOT just get points for walking up and shooting something with a repair gun for a couple seconds. There is a detailed
// calculation that gets the total points for a repair job. The (ammount the item was damaged X the point value below) + the 
// Score::RepairObject... This ammount is given for repairing the players own teams equipment. It will also deduct this amount
// if the player repairs enemy equipment. 
//
// You will only gain points for repairing an object COMPLETELY... Points are calculated from the time you start the repair to the 
// time you finish, if you want full points you had better not stop...
//
// What stops a player from just shooting and repairing his own stuff to horde points?! If the player is the last person to have
// damaged the object he will recieve NO points.
//=========================================================================================================================================

$Score::ObjStationS = "7";      //== Destroy Supply Station 
$Score::ObjStationA = "5";      //== Destroy Ammo Station or Command
$Score::ObjStationR = "3";      //== Destroy Remote Station
$Score::ObjFlier = "3";         //== Destroy Flyer Pad or Station
$Score::ObjGeneratorB = "10";   //== Destroy Large Generator
$Score::ObjGeneratorS = "5";    //== Destroy Small Generator including - Panels
$Score::ObjSensorL = "5";       //== Destroy Large Sensors
$Score::ObjSensorS = "2";       //== Destroy Deployable Sensors

$Score::ObjTurretL = "3";       //== Large Turrets
$Score::ObjTurretS = "1";       //== Deployable Turrets

$Score::Kill15Meters = "0";		//== Player Makes A Kill With In 15m
$Score::Kill50Meters = "1";		//== Kill From 15 to 50m
$Score::Kill100Meters = "1";	//== Kill From 50 to 100m
$Score::Kill250Meters = "2";	//== Kill From 100 to 250m
$Score::Kill250Plus = "3";		//== Kill 250m Or More

$Score::RepairObject = "1";     //== Repair Bonus. Base Points For Repair...

$Shifter::SpawnSafe = "10";   	//== If the player is killed before X - Only Half Points Are Awarded.

//=========================================================================================================================================
// Fair Teams Variables
//=========================================================================================================================================

$Shifter::FairTeams = True;  //== Is Fair Teams Is On
$Shifter::FairCheck = "30";  //== Number in seconds that Shifter will check the teams evenness and warn players
$Shifter::FairEvens = "120"; //== Number in seconds that Shifter will move the last connected player to the un even team.

//=========================================================================================================================================
// Team Killing Options
//=========================================================================================================================================

$Shifter::TeamKillOn 	= "True";			//== Is Anti TK On/Off
$Shifter::KillTerm 		= "1";				//== Number Of Time A Player Can Team Kill
											//== Before Being Terminated (Killed By Server
$SHAntiTeamKillWarnKills 	= "1";         	//== Number Of Team Kills Before Player Gets Warning.
$SHAntiTeamKillBanTime 		= "600";		//== Length Of Time In Seconds Player Is Banded For.
$SHAntiTeamKillMaxKills 	= "2";			//== Maximum Team Kills Before Kicked - Banned.
$SHAntiTeamKillProximity	= "50";        	//== Proximity Distance For Accidental Damage.
	
//=========================================================================================================================================
// Varrious Server Messages To The Client
//=========================================================================================================================================

//================================================================= Message To Banned Team Killer
$Shifter::TeamKillMsg = "You have been kick and banned for team killing, i hope you enjoyed it. Email:" @ $Shifter::emailAddress @ " for reinstatement.";

//================================================================= Show When Client Spawns For The First Time

$Shifter::WelcomeMsg = "<jc><f2>Welcome to Dopplegangers Inc. Tribes\nMOD: Shifter V1.0 Beta 6-19-99\nServer site:www.dopplegangers.com/tribes\nMission: <f1>" @ $missionName @ " <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>2 TeamKill KickBan in effect.\nIf you LAG, leave...  Don't whine. We dont want to hear it!";

$Shifter::WelcomeDelay = "20";  //== Amount in seconds that the message is shown. If "0" message will not be displayed.

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

