// ----------------------------------------------------------------------------
// Settings File
// --
// Please configure the below information to your liking.
// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
// Mod Information
// ----------------------------------------------------------------------------

// Paintbball version (use quotes or tribes has a wierd round bug)
$PB::Version = "2.6";

// Validate shapes found in the mod (Weapons, Packs, whatever)
$PB::Validate = false;

// Enable player shows from the server-side end (use 1.0 for yes,
// or 0.0 for no)
$PB::Shadows = 1.0;

// Version of paintball
$MODVersion = "v" @ $PB::Version;

// Information displayed on the connections screen.
$MODInfo	= "<f0>Welcome to<f2> PAINTBALL! <f1>"@$MODVersion@"\n"
		@ "<f0>Mod By: <f1>|K0RN|<F0> & <f1>[RR]MisterPibb\n"
		@ "<f0>Further modification by <f1>KingTomato\n"
		@ "<f2>http://www.KingTomato.org";

// ----------------------------------------------------------------------------
// Admin Login
// ----------------------------------------------------------------------------

// Number of login attempts allowed
$PB::Admin::Attempts = 3;

// Message admins a password attempt
$PB::Admin::Announce = True;

// Announce the passwor dused
$PB::Admin::SayPass = True;

// Color fo the message
$PB::Admin::TextColor = 1;

// Apply the rotating skin to admins
$PB::Admin::Skin = true;

// Log the attempts
$PB::Admin::Logging = True;

// If logging is enabled, name the file
$PB::Admin::LogFile = "AdminLog.cs";

// Login Information
// Use the following template to add a new user account:
// $PB::Admin::Pass[<level>, <pass>] = <user>;
// Where..
//	<level> can be Super or Public
//	<pass> is the login password
//	<user> is the name of the user logging in.
// Example, if I wanted super admin and my password was "elite", I would use:
//	$PB::Admin::Pass[Super, "elite"] = "KingTomato";

// $PB::Admin::Pass[Super, "login"] = "username";
// $PB::Admin::Pass[Super, "login"] = "username";
// $PB::Admin::Pass[Public, "login"] = "username";
// $PB::Admin::Pass[Public, "login"] = "username";

// ----------------------------------------------------------------------------
// Administrative Bans
// ----------------------------------------------------------------------------

// Make a list of IPs to ban from the server.
$PB::Admin::BanList[1] = "68.59.36.247";	// DaJackaI
$PB::Admin::BanList[2] = "67.80.86.170";	// Trogdor
$PB::Admin::BanList[3] = "";

// ----------------------------------------------------------------------------
// General Options
// ----------------------------------------------------------------------------

// Amount of time a body stays ont he ground after having been killed
$PB::CorpseTimeout = 1;

// Time before flag is returned when dropped
$PB::FlagReturnTime = 5;

// Delay before an item is replaced when picked up
$PB::ItemSpawnTime = 0;

// Time before an item fades out when dropped
$PB::itemPopTime = 30;

// Number of paint "splats" to fire when a grenade goes off.
$PB::Grenade::Splats = 30;

// Allow the fake death command
$PB::FakeDeath = true;

// Delay between fake death usages
$PB::FakeDeathTime = 5;

// Color of the flashlight, but use the following names:
// Red		Green		Teal		White
// Blue		Yellow		Pink
$PB::FLightColor = White;

// Logging enabled (to the console.log file in dynamix\tribes folder)
$PB::Logging = true;

// ----------------------------------------------------------------------------
// Money (Spending) Settings
// ----------------------------------------------------------------------------

// Enable Spending
$Money::Enabled	= true;

// Enable strict login, which means it checks for password and a name or ip match
$Money::StrictLogin = true;

// Minimum then maximum length a password can be
$Money::PassLength = "6 12";

// Delay between information backups (in seconds) default is 5 minutes.
$Money::BackupTime = "300";

// Starting balance of an account
$Money::StartAmount = "200.00";

// This alters $PB::itemPopTime above when spending is enabled.
$Money::PopTime	= 0;

// Minimum blanace requirement to have the ability to use auto-grenade buy
$Money::BuyNadePrice = "1200.00";

// When you sell an item, how much of th eitem cost do you get back
// 0.5 for half the cost (a 'used' price, 1.0 for total proce, etc)
$Money::Price[Sell] = "0.5";

// Cost of a kill
$Money::Price[Kill] = "5.00";

// Cost of a headshot
$Money::Price[HeadS] = "10.00";

// Cost of a death (money reduced)
$Money::Price[Death] = "0.00";

// Cose of a suicide (money reduced)
$Money::Price[Suicide] = "5.00";

// Cost of a flag capture
$Money::Price[Cap] = "20.00";

// Cost of a flag return
$Money::Price[Return] = "10.00";

// Cost of a Team Kill (money reduced)
$Money::Price[TeamKill] = "10.00";

// ----------------------------------------------------------------------------
// Clone Prefs
// ----------------------------------------------------------------------------

// Enable Scanner
$Clones::WatchEnabled = True;

// name of file
$Clones::CloneFile = "ClonesList.cs";

// Enable logging of connect/disconnect
$Clones::LoggingEnabled	= True;

// Save connects.disconnects to this file
$Clones::LoggingFile = "ServerLog.cs";

// ----------------------------------------------------------------------------
// Message Filtering
// ----------------------------------------------------------------------------

// Stop tab crash?
$PB::Msg::NoTabCrash = true;

// Stop Hex Crash
$PB::Msg::NoHexCrash = true;

// Stop \n Crash?
$PB::Msg::NoCrCrash = true;

// Sensativity to detect crash (number that can be in one message)
$PB::Msg::Sensativity = 15;

// Notify super admins of attempt
$PB::Msg::NotifyCrash = true;

// Limit for a A-Kick to be triggered
$PB::Msg::KickLimit = 2;

// Auto kick use when limit is reached
$PB::Msg::AutoKick = true;

// Time (in secs) a kick lasts
$PB::Msg::KickTime = 300;

// ----------------------------------------------------------------------------
// Tab Menu Settings
// ----------------------------------------------------------------------------

// TAB Menu Title
$PB::Menu::Title = "Paintball v"@$PB::Version;

// Very nifty addition-- this will msg all ops that a user is trying to
// forcefully gain admin. Very cool. >:D
$PB::Menu::HackAlert = true;

// Log the hack with the ip
$PB::Menu::HackLog = true;

// Teletypes the user info when clicked on in the tab menu. Can cause lag
// though, so up to you to use.
$PB::Menu::Teletype = false;

// Color of manipulations actions.
$PB::Menu::ManipColor = 1;

// Sound a manipulation makes
$PB::Menu::ManipSound = "~wshieldhit.wav";

// Here you can setup a list of reasons to kick people. The list is used on
// the tab menu when you select to kick or ban a player. You can have as
// many reasons as you'd like, just be warned you'll need to scroll them like
// selecting a mission. When you add these in, make sure to leave one at the
// bottom as a blank also.
// You may also use %1 in place of the admin's name, and %2 in place of the
// client's name.
$PB::Menu::KReason[1] = "Generic Kick";
$PB::Menu::KReason[2] = "Spawn Killing";
$PB::Menu::KReason[3] = "Team Killing";
$PB::Menu::KReason[4] = "Offensive Language";
$PB::Menu::KReason[5] = "Can't Follow Directions";
$PB::Menu::KReason[6] = "%1 is your God.";
$PB::Menu::KReason[7] = "Attempted Server Crash";
$PB::Menu::KReason[8] = ""; // This would be the blank

// ----------------------------------------------------------------------------
// Weapon Settings
// ----------------------------------------------------------------------------

// Spawn Weapon
$PB::SpawnAmmoMax 	= 100;	// Max ammo
$PB::SpawnClipSize	= 25;	// Size of a magazine
$PB::ReloadTime		= "1.0";// Time it takes to reload a magazine

// Every other weapon
$PB::AmmoMax		= 500;	// Max ammo
$PB::ClipSize		= 250;	// Size of a magazine
$PB::ReloadTime		= "3.03";// Time it takes to reload a magazine

// ----------------------------------------------------------------------------
// Debugging
// ----------------------------------------------------------------------------

// Enable debugging (Raw output to console)
$PB::Debug = false;

// Much more detailed debug (not recommended)
$PB::ExtDebug = false;

// ----------------------------------------------------------------------------
// Recruit Mode
// ----------------------------------------------------------------------------

// Leave it false, or else some wierd crap will happen. I have some options
// that appear only with this on, but they aren't done or debugged so it will
// not be pretty.

// this is a cool mode that will enable the server into a recruitment
// mode. The extent of it is you have all the users in the server that
// want to be recuited added to a queue. When they are ready to be tested,
// a 1v1 game is established vs an admin. From there, the players fight
// until one user gets 10 points.

$PB::RecruitMode = false;