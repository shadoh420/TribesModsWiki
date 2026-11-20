//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// _RaMpAgE_v1.7 By: Armagedon
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//===============================
// Admin settups
//===============================
$XKmod::BanKickTime = "9999";
$XKmod::fairTeams = "true";
$XKmod::PABan = "false";
$XKmod::PAKick = "true";
$XKmod::PAMission = "true";

$XKmod::PADetongue = "true";        //Allows PublicAdmins to have the ability to detongue someone
$XKmod::PABlowUp = "true";           //Allows PublicAdmins to have the ability to blowup someone
$XKmod::PAStripVoteRights = "true"; //Allows PublicAdmins to have the ability to strip someones ability to vote
$XKmod::PAModOptions = "false";
$XKmod::PAResetDefaults = "true";
$XKmod::PATeamChange = "true";
$XKmod::PATeamDamage = "true";
$XKmod::PATeamInfo = "false";
$XKmod::PATimelimit = "false";
$XKmod::PATourneyMode = "false";
$XKmod::PAVote = "false";
$XKmod::PAareaDamage = "false"; //must turn on PAModOptions also; allows PubAdmins to toggle Out of Area Damage
$XKmod::tkClientLvl = "1";
$XKmod::tkLimit = "3";
$XKmod::tkMultiple = "3";
$XKmod::tkServerLvl = "3";
$TelnetPort = 28001;

//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$XKmod::OutOfAreaDamage = false;

//Set to 1 if you want to enable the ban/kick by name, on player connect.  Make sure to set
//up your list in the config\\BBNList.cs
$BanByName::IsOn = 1;

//This will change the console output.  If set to 1, will set the console back to the original
//output so that older versions of Tricon will work.  If set to 2, it will use 
//the same echoing as usual.  Setting 3 is a minimum setting that will only echo chat,
//kill messages, who starts a vote, and general server echos.
$ConOutput = 1;

//logs the name and IP of everyone who connects, to config\\Connect.log
$ConnectLog = true; 

//log people who are kicked by admins, to config\\KickList.log
$ExportAKicks = true; 

//log people who are kicked by the computer, to config\\KickList.log
$ExportCKicks = true; 

//log everyone who is auto-admined to config\\AdminLog.log
$ExportAdmin = 1;

//log all admins punishments applied to players to config\\AdminPunish.log
$ExportAdminPun = 1;

//What you want it to say when an admin kicks a client, this is a centerprint message
//The "\n" will seperate lines of text on the screen... Example....
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the dumbass.";

//If you want to see your personal skins.  The skins must be installed in your(clientside)
//tribes\base\skins directory, and set this option to true.
$XKmod::PersonalSkin = "true"; 

//When set to true, no one can blow you out of ANY stations
//I wouldn't set this unless you have the station kick on also.
//Without the station kick, they can tie up a station for the rest of the game
//if they want, and nothing will blow them out!!
//If the person gets blocked in so that the station kick function can't
//kick them out, THEN you can shoot them out of the station, but not before.
$StationLockTD = "true";  // no knock from station with teamdamage off
$StationLockNTD = "true";  // no knock from station with teamdamage on

//How long the server will wait before ejecting someone out of a inventory station.  This
//only works when there are more then 3 people in the game
$XKmod::StationTime = "30";  //range is 10-60

$PA::noKick = "True";  //if set to true, public admins cant be kicked by a vote

 

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

$TelnetPassword = "";
$AdminPassword = "";
$PublicPassword = "";

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops, 
//objective captures, destroyed objects.....etc.
$StatTrack = true;