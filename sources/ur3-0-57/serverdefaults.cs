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
$Server::VoteWinMargin = 0.7;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::TourneyMode = false;
$Server::Info = "Default TRIBES server setup\nAdmin: Unknown\nEmail: Unknown";
$Server::JoinMOTD = "<jc><f1>Message of the Day:\nWelcome to TRIBES!\n\nFire to spawn.";

$Server::MasterAddress0 = "IP:tribes.dynamix.com:28000";
$Server::MasterName0 = "Tribes Master";
$Server::Master1 = "IP:tribes.dynamix.com:28000";
$Server::Master2 = "IP:BROADCAST:28001";

//---------------------------------------------------------------------------------
// Percentage of Damage taken during friendly fire
//---------------------------------------------------------------------------------
$Server::TeamDamageScale = 1.0;

