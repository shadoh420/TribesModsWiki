$Server::teamName[0] = "Blood Eagle";
$Server::teamSkin[0] = "beagle";
$Server::teamName[1] = "Diamond Sword";
$Server::teamSkin[1] = "dsword";
$Server::teamName[2] = "Children of the Phoenix";
$Server::teamSkin[2] = "cphoenix";
$Server::teamName[3] = "Starwolf";
$Server::teamSkin[3] = "swolf";
$Server::teamName[4] = "Generic 1";
$Server::teamSkin[4] = "base";
$Server::teamName[5] = "Generic 2";
$Server::teamSkin[5] = "base";
$Server::teamName[6] = "Generic 3";
$Server::teamSkin[6] = "base";
$Server::teamName[7] = "Generic 4";
$Server::teamSkin[7] = "base";

$Server::HostName = "TRIBES Server";
$Server::MaxPlayers = "8";
$Server::HostPublicGame = false;
$Server::AutoAssignTeams = true;
$Server::Port = "28001";

$Server::timeLimit = 25;
$Server::warmupTime = 20;

if($pref::lastMission == "")
   $pref::lastMission = Raindance;

$Server::MinVoteTime = 45;
$Server::VotingTime = 20;
$Server::VoteWinMargin = 0.55;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::VoteFailTime = 30; // 30 seconds if your vote fails + $Server::MinVoteTime

$Server::TourneyMode = false;
$Server::TeamDamageScale = 0;

$Server::Info = "Default TRIBES server setup\nAdmin: Unknown\nEmail: Unknown";
$Server::JoinMOTD = "<jc><f1>Message of the Day:\nWelcome to TRIBES!\n\nFire to spawn.";

$Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
$Server::MasterName0 = "US Tribes Master";
$Server::MasterName1 = "UK Tribes Master";
$Server::MasterName2 = "Australian Tribes Master";
$Server::CurrentMaster = 0;

$Server::respawnTime = 2; // number of seconds before a respawn is allowed

// default translated masters:
$Server::XLMasterN0 = "IP:209.185.222.237:28000";
$Server::XLMasterN1 = "IP:209.67.28.148:28000";
$Server::XLMasterN2 = "IP:198.74.40.67:28000";
$Server::FloodProtectionEnabled = true;

//---------------------------------------------------------------------------------
// Insomniax MOD Default Settings - *IX*Savage1
//---------------------------------------------------------------------------------

//  When a player Leaves the Mission Area they may incurr the wrath
//  of the server. Server adminds can control how much time you have 
//  out of bounds to live. From 10 - 60 seconds. And this Leave
//  Area Kill Can be switched off. (Set to Zero Seconds.) 
//  The Mod will round to the nearest multiple of 5 (Rounding down)
$Insomniax::LeaveAreaTime = "0";

// Number of Seconds Player is Banned for After Kicked. 
// This is applied to ALL Kicks including Team Killer Kicks.
$Insomniax::BanKickTime = "120";

// Number of Team Kills Before Action is Taken.
$Insomniax::tkLimit = 5;

// Setting to Determine Server Action Taken when $Insomniax::tkLimit is reached.
// Levels
//  	0 = No Action Taken.
//      1 = Kick Vote initiated by Server (Automaticly For Last Player Killed)
//      2 = Kick Vote initiated by Server (Same as lvl 1) 
//          when they reach the "tkLimit" a number of "tkMultiple" times.
//          They are kicked Regardless of the vote. 
//      (ex. tkLimit = 3, tkMultiple = 3. On the 9th Kill the TK Gets kicked)
//      3 = Team Killer Kicked By server immediately when "tkLimit" is reached.
//          or a multiple of tkLimit. 
//	(ex. tkLimit = 3, I have 5 TK's when server is set to Level 3. On my next TK im out)
// NOTE: At Level Zero Players can still initiate Team Killer Vote
//       From Options Menu (TAB).
$Insomniax::tkServerLvl = 1;

// Settings to Determine Client Action Allowed when $insomniax::tkLimit is Reached.
//
//  	0 = Vote Option after $Insomniax::tkLimit is Reached.
//      1 = Kick Option after $Insomniax::tkLimit is Reached. 
//
$Insomniax::tkClientLvl = 0;

// How many Sets of TK's before Booted outright (Level 2)
$Insomniax::tkMultiple = 3; 

// -- Public Admin (PA) Toggles for Admin menu Choices.
// 	1 = On , 0(Zero) = Off. Everything is Accessable 
// 	By the Super Admin. (Guy with the password) 
// 	These Toggles can be changed by The Super Admin 
// 	but NOT By the Public Admin.

// -- Change Player's Team
$Insomniax::PATeamChange = "true";

// -- Allowed to Kick Players
$Insomniax::PAKick = "true";

// -- Allowed to Ban Players
$Insomniax::PABan = "true";

// -- Allowed to Change the Mission
$Insomniax::PAMission = "true";

// -- Allowed to Change Team Damage Settings
$Insomniax::PATeamDamage = "true";

// -- Allowed to Change Tourney Mode 
$Insomniax::PATourneyMode = "true";

// -- Allowed to Change Time Limit
$Insomniax::PATimelimit = "true";

// -- Allowed to Reset the Server to the Startup Settings
$Insomniax::PAResetDefaults = "true";

// -- Allowed to Change the Insomniax Mod Options 
// NOTE: The Public Admin NEVER has access to these Toggles.
//       This setting is for the TK Settings and Out of Bounds Kill.
$Insomniax::PAModOptions = "true";

// -- Toggle Public Admin Vote.
$Insomniax::PAVote = "true";

// -- Toggle Public Admin Access to SetTeamInfo();
$Insomniax::PATeamInfo = "true";
