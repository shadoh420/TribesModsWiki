$Server::teamName[0] = "Gods";
$Server::teamSkin[0] = "beagle";
$Server::teamName[1] = "Mortals";
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

$Server::HostName = "UltraVX3+Dynamix PLUS mod 1.1 Server";
$Server::MaxPlayers = "24";
$Server::HostPublicGame = true;
$Server::AutoAssignTeams = true;
$Server::Port = "28001";

$Server::timeLimit = 25;
$Server::warmupTime = 10;

if($pref::lastMission == "")
   $pref::lastMission = Raindance;

$Server::respawnInvulnerableTime = 0; // 6 second invulnerable period
$Server::MinVoteTime = 12;
$Server::VotingTime = 12;
$Server::VoteWinMargin = 0.55;
$Server::VoteAdminWinMargin = 0.66;
$Server::MinVotes = 1;
$Server::MinVotesPct = 0.5;
$Server::VoteFailTime = 12; // 30 seconds if your vote fails + $Server::MinVoteTime

$Server::TourneyMode = false;
$Server::TeamDamageScale = 0;

$Server::Info = "UltraVX3+Dynamix PLUS mod 1.1\nAdmin: kissie-POO\nEmail: kissie@speakeasy.org";
$Server::JoinMOTD = "<jc><f1>Message of the Day:\nWelcome to TRIBES!\n\nFire to spawn.";

$Server::MasterAddressN0 = "t1m1.masters.dynamix.com:28000 t1m2.masters.dynamix.com:28000 t1m3.masters.dynamix.com:28000";
$Server::MasterAddressN1 = "t1ukm1.masters.dynamix.com:28000 t1ukm2.masters.dynamix.com:28000 t1ukm3.masters.dynamix.com:28000";
$Server::MasterAddressN2 = "t1aum1.masters.dynamix.com:28000 t1aum2.masters.dynamix.com:28000 t1aum3.masters.dynamix.com:28000";
$Server::MasterName0 = "US Tribes Master";
$Server::MasterName1 = "UK Tribes Master";
$Server::MasterName2 = "Australian Tribes Master";
$Server::CurrentMaster = 0;

$Server::respawnTime = 1; // number of seconds before a respawn is allowed

// default translated masters:
$Server::XLMasterN0 = "IP:209.185.222.237:28000";
$Server::XLMasterN1 = "IP:209.67.28.148:28000";
$Server::XLMasterN2 = "IP:198.74.40.67:28000";
$Server::FloodProtectionEnabled = true;

//$MODInfo = "<f2>Dynamix PLUS mod 1.1 - features:\n<f1><jl>Reduced Skiing <jr>+spread chain\n<jl>Respawn invulnerability<jr>Faster/tougher medium\n<jl>Longer range mortar, ELF, repair<jr>Mine fixes\n<jl>Shielded vehicle pads<jr>Faster/tougher vehicles\n";
//$MODInfo = "<f2>UltraVX3+Dynamix PLUS mod 1.1 - features:\n<f1><jl>Reduced Skiing <jr>+spread chain\n<jl>Respawn invulnerability<jr>Faster/tougher medium\n<jl>Longer range mortar, ELF, repair<jr>Mine fixes\n<jl>Shielded vehicle pads<jr>Faster/tougher vehicles\n";
