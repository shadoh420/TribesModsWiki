// - = - = - = - = - = - = - = - = - = - = - = - \\
//      U l t r a  R e n e g a d e s  V X E      \\
// - = - = - = - = - = - = - = - = - = - = - = - \\
//serverDefaults.cs

//$TelnetPort = 2000;
//$TelnetPassword = "XXXXX";

$Server::MaxPlayers = "8";
$Server::Port = "28001";

$Server::Password = "";
$AdminPassword = "";
$MatchAdminPassword = "";

//Put as many match admin passwords as you want...
//example: $MatchAdminPasswordList = "2wire intelinside";
$MatchAdminPasswordList = "";
//Seperate each password with a space  

$Server::HostName = "UltraVX Extreme Server";
$Server::Info = "UltraVX Extreme";
$Server::JoinMOTD = "<jc><f1>Play fair, Play nice.\n\n<f2>UltraVX Extreme, Bringing the Ultra mods together!!";
$Server::HostPublicGame = "true";

$Server::TourneyMode = "false";
$Server::timeLimit = "35";
$Server::AutoAssignTeams = "true";
$Server::FloodProtectionEnabled = "false";
$Server::respawnTime = "0";

$Server::TeamDamageScale = "0";
$Server::teamName0 = "Mercenaries"; 
$Server::teamName1 = "Bandits";
$Server::teamName2 = "Children of the Phoenix";
$Server::teamName3 = "Starwolf";
$Server::teamName4 = "Generic 1";
$Server::teamName5 = "Generic 2";
$Server::teamName6 = "Generic 3";
$Server::teamName7 = "Generic 4";
$Server::teamSkin0 = "beagle";
$Server::teamSkin1 = "dsword";
$Server::teamSkin2 = "cphoenix";
$Server::teamSkin3 = "swolf";
$Server::teamSkin4 = "base";
$Server::teamSkin5 = "base";
$Server::teamSkin6 = "base";
$Server::teamSkin7 = "base";

$Server::VoteAdminWinMargin = "0.659999";
$Server::VoteFailTime = "30";
$Server::VoteWinMargin = "0.549999";
$Server::VotingTime = "20";
$Server::warmupTime = "15";

$pref::LastMission = "Raindance";

$pref::PacketRate = 20; 
$pref::PacketSize = 400;

$ultra_renegades::PVMission = true;
$ultra_renegades::PVTeamDamage = true;
$ultra_renegades::PVFairTeams = true;
$ultra_renegades::PVTourneyMode = true;
