//=============================================================================================================================
// DogFight Parameters
$DogFight::NetMask = "IP:192.168.1";	// This is used to increase server player limit when local LAN players connect.
$DogFight::IncreaseMax = false;		// If true, will increase player limit on server if IP of client connect matches NetMask.
$DogFight::GiveLocalAdmin = true;		// If true, will give SuperAdmin status to players who are on the same machine as the server.
$DogFight::ShoppingList = true;		// Set to true to limit item shopping list to display only items available for current armor.
$DogFight::ResetServer = true;		// Set to true to rotate server to next map in list when last player leaves.
$DogFight::KickTime = 180;			// Time (in seconds) for kicks.
$DogFight::BanTime = 1800;			// Time (in seconds) for bans.
$DogFight::StationTime = 20;		// Time allowed for Station Access.


//============================================================================================================================
// Public Voting Parameters
$DogFight::PVAdmin = false;			// Allow Public Admin Voting.
$DogFight::PVKick = true;			// Allow Public Kick Voting.
$DogFight::PVChangeMission = true;		// Allow Public Mission Voting.
$DogFight::PVTeamDamage = false;		// Allow Public Team Damage Voting.
$DogFight::PVTourneyMode = false;		// Allow Public Tournament Mode Voting.


//=============================================================================================================================
// SuperAdmin Passwords, Up to 100 are available
$DogFight::SADPassword[1] = "password"; // CHANGE THIS

// SuperAdmin Parameters
$DogFight::SADBan = true;			// Allow Super Admins to Ban.
$DogFight::SADGiveAdmin = true;		// Allow Super Admins to Give Public Admin to other players.
$DogFight::SADForceVote = true;		// Allow Super Admins to Force Votes to Pass/Fail.


//=============================================================================================================================
// Public Admin Passwords, Up to 100 are available
$Annihilation::PAPassword[1] = "password"; // CHANGE THIS


// Public Admin Parameters
$DogFight::PAKick = true;			// Allow Public Admins to Kick.
$DogFight::PATeamChange = true;		// Allow Public Admins to Change other Players Teams.
$DogFight::PAChangeMission = true;		// Allow Public Admins to Change the Mission.
$DogFight::PATeamDamage = true;		// Allow Public Admins to Enable/Disable Team Damage.
$DogFight::PATourneyMode = false;		// Allow Public Admins to Enable/Disable Tournament Mode.


// Other Parameters
$DogFight::FairTeams = true;		// Prevent team changing to the larger team
$DogFight::UsePersonalSkin = true;		// Allows use of Personal Skins