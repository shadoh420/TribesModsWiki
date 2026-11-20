############################################################################################################################
# This mod is copyrighted © 2000 INH*DynaBlade                                                                             #
#                                                                                                                          #
# Base Programming by INH*DynaBlade                                                                                        #
# Debuggin' by {J}MEGA-Man                                                                                                 #
# Additional programming by: Z_Dog and Valya[AAOD]                                                                         #
# Other people who contributed: [CLU]Clu, [CLU]Robear, Desertfox, Shayne Hyde, Emo1313, [HvC]NateDoGG, and <SSA>           #  
# Email: meltdown@clannorthwind.net                                                                                        #
############################################################################################################################

######################################
# Server startup variables           #
# Color Tags:                        #
# White Text = <f2>                  #
# Light Text = <f1>                  #
# Normal Text = <f0>                 # 
# \n = New Line                      #
# Leaving the messages without color #
# tags will result in the usage of   #
# the last used color                #
# In this case, White.               #
# You can also use these commands    #
# for setting up your server         #
# information (serverprefs.cs)       #
######################################

$Meltdown::JoinMOTD = "<f0>I dare you to find a <f1>BETTER<f0> Mod than Meltdown. Then email me <f2>meltdown@clannorthwind.net<f1>\n\nGo ahead and play! It's fun!";

#############################################
# Server Switches (set to false to disable) #
#############################################

$Meltdown::PublicAdminVote = False; 		// Can vote to admin
$Meltdown::ChangeMissionVote = True; 		// Can vote to change missions
$Meltdown::ChangeTeams = True; 			// Must be true for Fair teams to work
$Meltdown::KickVote = True; 				// Can vote to Kick
$Meltdown::TeamDamageSwitch = True; 		// Can vote to Enable/disable team damage
$Meltdown::FlagReturnTime = 45; 			// Time in seconds before flag will return to it's flagstand
$Meltdown::StationTime = 50; 				// Cannot be less than 10 or higher than 60 or else it will use default. Set to false to disable
$Meltdown::VoteIncTime = 15; 				// # of mins to vote to increase time
$Meltdown::KickMessage = "Go away you idiot!";  // The message that displays when you kick/ban someone  
$Meltdown::RespawnEffectTime = 8;			// How long the cool respawn effect lasts (seconds)
$mallcomment = "Try not to get killed!";	      // What displays in the bottom mission window when they respawn
$Meltdown::TeleCountdownTime = 300;			// Time in seconds it takes the teleporter to blow up if not deployed
$trace = false;						// Extra in-game messages exported to console

###########################
# Server Anti-TK settings #
###########################

$TeamKillMin = 2;             			// Before he can qualify for being kicked for TKs
$Meltdown::TKLimit = 3; 				// How many TKs before he is kicked 
$Meltdown::BaseKillWarning = 3;			// How many base kills before warned
$Meltdown::BaseKillLimit = 5;				// Haw many Base kills before he's Kicked

#######################################################
# Server Public Admin (PA) Passwords                  #
# Great for those clan Members who want Admin         #
# Usage: (console) sad("Password");                   # 
# You can add up to 96 differrent PA passwords (0-95) #
#######################################################

$Meltdown::PAPassword[0] = "";
$Meltdown::PAPassword[1] = "";
$Meltdown::PAPassword[2] = "";
$Meltdown::PAPassword[3] = "";
$Meltdown::PAPassword[4] = "";
$Meltdown::PAPassword[5] = "";
$Meltdown::PAPassword[6] = "";
$Meltdown::PAPassword[7] = "";
$Meltdown::PAPassword[8] = "";
$Meltdown::PAPassword[9] = "";
$Meltdown::PAPassword[10] = "";
$Meltdown::PAPassword[11] = "";
$Meltdown::PAPassword[12] = "";
$Meltdown::PAPassword[13] = "";
$Meltdown::PAPassword[14] = "";
$Meltdown::PAPassword[15] = "";

#################################################################################
# Server Sad Password allocation                                                #
# Allows you to have multiple SAD passwords or store other ppl's SAD passwords. #
# MUCH safer than Auto-Admin, but it's manual...                                #
# You can add up to 64 differrent SAD passwords (0-63)                          #
#################################################################################

$Meltdown::SadPassword[0] = "";
$Meltdown::SadPassword[1] = "";
$Meltdown::SadPassword[2] = "";
$Meltdown::SadPassword[3] = "";
$Meltdown::SadPassword[4] = "";
$Meltdown::SadPassword[5] = "";
$Meltdown::SadPassword[6] = "";
$Meltdown::SadPassword[7] = "";

######################################################################
# Server Auto-admin Variables                                        #
# Add your ppl who you want to admin when they connect to the server #
# You can have as many as 128 different auto-admin names             #
######################################################################

$CurAdminName = "Meltdown";  			// The Auto-Admin name that prompts you when you've been auto-admined by that name.

$Server::AutoAdmin[0] = "";
$Server::AutoAdmin[1] = "";
$Server::AutoAdmin[2] = "";
$Server::AutoAdmin[3] = "";
$Server::AutoAdmin[4] = "";
$Server::AutoAdmin[5] = "";
$Server::AutoAdmin[6] = "";
$Server::AutoAdmin[7] = "";
$Server::AutoAdmin[8] = "";
$Server::AutoAdmin[9] = "";
$Server::AutoAdmin[10] = "";
$Server::AutoAdmin[11] = "";
$Server::AutoAdmin[12] = "";
$Server::AutoAdmin[13] = "";
$Server::AutoAdmin[14] = "";
$Server::AutoAdmin[15] = "";

##############################################################
# IPs have to be placed by IP: then your IP number.          #
# Ex.                                                        #
#                                                            #
# $Server::AutoAdminAddr[99] = "IP:123.456.789.0";           #
# You can have as many as 128 different auto-admin addresses #
##############################################################

$Server::AutoAdminAddr[0] = "";
$Server::AutoAdminAddr[1] = "";
$Server::AutoAdminAddr[2] = "";
$Server::AutoAdminAddr[3] = "";
$Server::AutoAdminAddr[4] = "";
$Server::AutoAdminAddr[5] = "";
$Server::AutoAdminAddr[6] = "";
$Server::AutoAdminAddr[7] = "";
$Server::AutoAdminAddr[8] = "";
$Server::AutoAdminAddr[9] = "";
$Server::AutoAdminAddr[10] = "";
$Server::AutoAdminAddr[11] = "";
$Server::AutoAdminAddr[12] = "";
$Server::AutoAdminAddr[13] = "";
$Server::AutoAdminAddr[14] = "";
$Server::AutoAdminAddr[15] = "";

##########################
# Default game variables #
# for more advanced      #
# servers ONLY!          #
# -INH*DynaBlade         #
##########################

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. Only for F&R Missions
//---------------------------------------------------------------------------------
$flagToStandTime = 180;

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//===============================================================================//

$Meltdown::AutoAssignTeam = true;
$Meltdown::AutoAssignTribe = "";
$Meltdown::AutoAssignLength = 5;
