//=============================================================================================================================
// Annihilation Parameters
$Annihilation::NetMask = "IP:192.168.1";	// This is used to increase server player limit when local LAN players connect.
$Annihilation::LocalIncreaseMax = false;	// If true, will increase player limit on server if IP of client is local to the machine.
$Annihilation::NetworkIncreaseMax = false;	// If true, will increase player limit on server if IP of client connect matches NetMask.
$Annihilation::GiveLocalAdmin = true;		// If true, will give SuperAdmin status to players who are on the same machine as the server.
$Annihilation::GiveNetworkAdmin = true;		// If true, will give SuperAdmin status to players who are on the same network as the NetMask..
$Annihilation::ShoppingList = true;		// If true, will limit item shopping list to display only items available for current armor.
$Annihilation::ResetServer = true;		// If true, will rotate server to next map in list when last player leaves.
$Annihilation::KickTime = 300;			// Time (in seconds) for kicks.
$Annihilation::BanTime = 10800;			// Time (in seconds) for bans.
$Annihilation::StationTime = 20;		// Time allowed for Station Access.


//============================================================================================================================
// Public Voting Parameters
$Annihilation::PVAdmin = false;			// Allow Public Admin Voting.
$Annihilation::PVKick = true;			// Allow Public Kick Voting.
$Annihilation::PVChangeMission = true;		// Allow Public Mission Voting.
$Annihilation::PVTeamDamage = true;		// Allow Public Team Damage Voting.
$Annihilation::PVTourneyMode = true;		// Allow Public Tournament Mode Voting.


//=============================================================================================================================
// SuperAdmin Passwords, Up to 100 are available
$Annihilation::SADPassword[1] = "";
$Annihilation::SADPassword[2] = "";
$Annihilation::SADPassword[3] = "";
$Annihilation::SADPassword[4] = "";
$Annihilation::SADPassword[5] = "";

// SuperAdmin Parameters
$Annihilation::SADBan = true;			// Allow Super Admins to Ban.
$Annihilation::SADGiveAdmin = true;		// Allow Super Admins to Give Public Admin to other players.
$Annihilation::SADForceVote = true;		// Allow Super Admins to Force Votes to Pass/Fail.


//=============================================================================================================================
// Public Admin Passwords, Up to 100 are available
$Annihilation::PAPassword[1] = "";
$Annihilation::PAPassword[2] = "";
$Annihilation::PAPassword[3] = "";
$Annihilation::PAPassword[4] = "";
$Annihilation::PAPassword[5] = "";


// Public Admin Parameters
$Annihilation::PAKick = true;			// Allow Public Admins to Kick.
$Annihilation::PATeamChange = true;		// Allow Public Admins to Change other Players Teams.
$Annihilation::PAChangeMission = true;		// Allow Public Admins to Change the Mission.
$Annihilation::PATeamDamage = true;		// Allow Public Admins to Enable/Disable Team Damage.
$Annihilation::PATourneyMode = true;		// Allow Public Admins to Enable/Disable Tournament Mode.


// Other Parameters
$Annihilation::FairTeams = true;		// Prevent team changing to the larger team
$Annihilation::UsePersonalSkin = true;
$Annihilation::RandomMissionStart = false;
$Annihilation::BeaconDelay = 3.25;

//=============================================================================================================================
// Ban Strings, Up to 100 are available
$Annihilation::BanString[1] = "b00";
$Annihilation::BanString[2] = "boo";
$Annihilation::BanString[3] = "=MP=";
$Annihilation::BanString[4] = "";
$Annihilation::BanString[5] = "";


$Annihilation::BannedEmail = "";
$Annihilation::KickMessage = "JackAss!!!";