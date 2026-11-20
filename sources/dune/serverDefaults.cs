$Server::teamName[0] = "House Atreides";
$Server::teamSkin[0] = "green";
$Server::teamName[1] = "House Harkonnen";
$Server::teamSkin[1] = "blue";
$Server::teamName[2] = "House Corrino";
$Server::teamSkin[2] = "swolf"; 
$Server::teamName[3] = "Ix";
$Server::teamSkin[3] = "dsword";
$Server::teamName[4] = "Bene Tleilax";
$Server::teamSkin[4] = "beagle";
$Server::teamName[5] = "Minor House";
$Server::teamSkin[5] = "MinorOne";
$Server::teamName[6] = "Minor House 2";
$Server::teamSkin[6] = "MinorTwo";

$Server::Team[0] = "HA";
$Server::Team[1] = "HH";
$Server::Team[2] = "HC";
$Server::Team[3] = "IX";
$Server::Team[4] = "BT";
$Server::Team[5] = "MH";
$Server::Team[6] = "MH2";


$Server::HostName = "Dune Tribes Server";
$Server::MaxPlayers = "16";
$Server::HostPublicGame = true;
$Server::AutoAssignTeams = true;
$Server::Port = "28001";

$Server::timeLimit = 60;
$Server::warmupTime = 10;

if($pref::lastMission == "")
   $pref::lastMission = Raindance;

$Server::MinVoteTime = 45;
$Server::VotingTime = 20;
$Server::VoteWinMargin = 0.55;
$Server::VoteAdminWinMargin = 0.66;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::VoteFailTime = 30; // 30 seconds if your vote fails + $Server::MinVoteTime

$Server::TourneyMode = false;
$Server::TeamDamageScale = 0;

$Server::Info = "DUNE TRIBES server setup\nAdmin: Unknown\nEmail: Unknown";
$Server::JoinMOTD = "<jc><f1>Message of the Day:\nWelcome to DUNE Tribes!\n\nFire to spawn.";

$Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
$Server::MasterName0 = "US Tribes Master";
$Server::MasterName1 = "UK Tribes Master";
$Server::MasterName2 = "Australian Tribes Master";
$Server::CurrentMaster = 0;

$Server::respawnTime = 10; // number of seconds before a respawn is allowed

// default translated masters:
$Server::XLMasterN0 = "IP:209.185.222.237:28000";
$Server::XLMasterN1 = "IP:209.67.28.148:28000";
$Server::XLMasterN2 = "IP:198.74.40.67:28000";
$Server::FloodProtectionEnabled = true;
