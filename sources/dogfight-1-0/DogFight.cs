//=============================================================================================================================
// Dogfight Parameters
$Dogfight::NetMask = "IP:192.168.1";	// This is used to increase server player limit when local LAN players connect.
$Dogfight::IncreaseMax = false;		// If true, will increase player limit on server if IP of client connect matches NetMask.
$Dogfight::GiveLocalAdmin = true;		// If true, will give SuperAdmin status to players who are on the same machine as the server.
$Dogfight::ShoppingList = true;		// Set to true to limit item shopping list to display only items available for current armor.
$Dogfight::ResetServer = true;		// Set to true to rotate server to next map in list when last player leaves.
$Dogfight::KickTime = 180;			// Time (in seconds) for kicks.
$Dogfight::BanTime = 1800;			// Time (in seconds) for bans.
$Dogfight::StationTime = 20;		// Time allowed for Station Access.


//============================================================================================================================
// Public Voting Parameters
$Dogfight::PVAdmin = false;			// Allow Public Admin Voting.
$Dogfight::PVKick = true;			// Allow Public Kick Voting.
$Dogfight::PVChangeMission = true;		// Allow Public Mission Voting.
$Dogfight::PVTeamDamage = false;		// Allow Public Team Damage Voting.
$Dogfight::PVTourneyMode = false;		// Allow Public Tournament Mode Voting.


//=============================================================================================================================
// SuperAdmin Passwords, Up to 100 are available
$Dogfight::SADPassword[1] = "Password";

// SuperAdmin Parameters
$Dogfight::SADBan = true;			// Allow Super Admins to Ban.
$Dogfight::SADGiveAdmin = true;		// Allow Super Admins to Give Public Admin to other players.
$Dogfight::SADForceVote = true;		// Allow Super Admins to Force Votes to Pass/Fail.


//=============================================================================================================================
// Public Admin Passwords, Up to 100 are available
$Dogfight::PAPassword[1] = "Password";


// Public Admin Parameters
$Dogfight::PAKick = true;			// Allow Public Admins to Kick.
$Dogfight::PATeamChange = true;		// Allow Public Admins to Change other Players Teams.
$Dogfight::PAChangeMission = true;		// Allow Public Admins to Change the Mission.
$Dogfight::PATeamDamage = true;		// Allow Public Admins to Enable/Disable Team Damage.
$Dogfight::PATourneyMode = false;		// Allow Public Admins to Enable/Disable Tournament Mode.


// Other Parameters
$Dogfight::FairTeams = true;		// Prevent team changing to the larger team
$Dogfight::UsePersonalSkin = true;		// Allows use of Personal Skins