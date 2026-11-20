// Admin.cs
// Originally By Plasmatic in his Annihilation Mod,
// Changed to better fit my mod.

$curVoteTopic = "";
$curVoteAction = "";
$curVoteOption = "";
$curVoteCount = 0;

//====================================================================================
//          INITIAL MENU:
function Game::menuRequest(%clientId)
{
	if(!%clientId.isGodAdmin && (%clientId.isPossessed)) 
	{ return; }
	
	%clientIdName = Client::getName(%clientId);
		
	%curItem = 0;
	%clientId.MissVote = "";
	if(%clientId.selClient)
	{
		%cl = %clientId.selClient;
		%clName = Client::getName(%cl);
		%status = Client::getStatus(%cl);
		
		Client::buildMenu(%clientId, %clName @": "@ %status, "Options", true);
		
		if(%clientId.isAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Change "@ %clName @"'s team", "fteamchange "@ %cl);
			if(%clientId.isGodAdmin)
			{ Client::addMenuItem(%clientId, %curItem++ @"Be An Ass To "@ %clName, "BAnAss "@ %cl); }
			Client::addMenuItem(%clientId, %curItem++ @"Manage "@ %clName, "ManageMAIN "@ %cl);
			if(%clientId.isSuperAdmin)
			{ Client::addMenuItem(%clientId, %curItem++ @"TelePort", "teleopt "@ %cl); }
		}
		
		if(%clientId != %clientId.selClient)
		{
			if(%clientId.whisper == "")
			{ Client::addMenuItem(%clientId, %curItem++ @"Whisper to "@ %clName, "whisper "@ %cl); }
			else 
			{ Client::addMenuItem(%clientId, %curItem++ @"Cancel Whisper", "nowhisper "@ %cl); }
		}
		
		if(%cl.isSuperAdmin != true)// Can't Mute Admins
		{
			if(%clientId.muted[%cl])
			{ Client::addMenuItem(%clientId, %curItem++ @"Unmute "@ %clName, "unmute "@ %cl); }
			else
			{ Client::addMenuItem(%clientId, %curItem++ @"Mute "@ %clName, "mute "@ %cl); }
		}
	
		if(%clientId.observerMode == "observerOrbit" && !%clientId.issuperAdmin && !%clientId.isAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Observe "@ %clName, "observe "@ %cl); }
		
		if($curVoteTopic == "" && !$NoVote && !%clientId.isAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Start vote on "@ %clName, "voteToPlayer "@ %cl); }
		return;
	}
	else
	{
		Client::buildMenu(%clientId, "[TG] Server Options ", "options", true);
		
		// New vote in progress and we havn't voted, setup vote menu.
		if($curVoteTopic != "" && %clientId.vote == "" && !%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Vote YES to "@ $curVoteTopic, "voteYes "@ $curVoteCount);
			Client::addMenuItem(%clientId, %curItem++ @"Vote NO to "@ $curVoteTopic , "voteNo "@ $curVoteCount);
			return;
		}
		else
		{
			if(!$matchStarted || !$Server::TourneyMode)
			{
				Client::addMenuItem(%clientId, %curItem++ @"Change Teams/Observe", "changeteams");
				Client::addMenuItem(%clientId, %curItem++ @"Customize Character" , "character");
			}
			
			if($curVoteTopic == "" && %clientId.isGodAdmin)
			{
				if($NoVote == 1) 
				{ Client::addMenuItem(%clientId, %curItem++ @"Enable voting", "eVote"); }
				else 
				{ Client::addMenuItem(%clientId, %curItem++ @"[TG] Voting Options", "vote"); }
			}
			else if($curVoteTopic == "" && !%clientId.isAdmin && !$NoVote)
			{
				Client::addMenuItem(%clientId, %curItem++ @"Vote Mission ", "voteMiss");
				Client::addMenuItem(%clientId, %curItem++ @"Vote Time "   , "voteTime");
				Client::addMenuItem(%clientId, %curItem++ @"Vote Damage " , "voteDamage");
			}
			
			if($curVoteTopic != "" && %clientId.isGodAdmin && !$curVoteForce)
			{ Client::addMenuItem(%clientId, %curItem++ @"Force Vote", "voteForce"); }
			
			if(%clientId.isAdmin)
			{
				Client::addMenuItem(%clientId, %curItem++ @"Mission Menu", "mapMenu");
				if(%clientId.isSuperAdmin)
				{ Client::addMenuItem(%clientId, %curItem++ @"Damage Menu", "damageMenu"); }
				if(%clientId.isGodAdmin)
				{
					Client::addMenuItem(%clientId, %curItem++ @"Server Opts Menu", "ServerOptions");
					Client::addMenuItem(%clientId, %curItem++ @"Destroy/Repair Opts", "Equipment");
				}
			}
			Client::addMenuItem(%clientId, %curItem++ @ "Mod Info", "ModInfo");
		}
	}
}

function remoteAdminPassword(%client, %password)
{
	%ip = Client::getTransportAddress(%client);
	%clientName = Client::getName(%client);
	
	if(%client.passprotect == true)
	{ return; }
	else
	{
		%client.passprotect = true;
		Schedule(%client @".passprotect = false;", 3);// Only One Pass Every 3 Seconds.
	}
	
	if($TG::GodPassword != "" && %password == $TG::GodPassword)
	{ 
		%client.isAdmin = true;
		%client.isSuperAdmin = true;
		%client.isGodAdmin = true;
		MessageAll(0, %clientname @ " became a GodAdmin by force.~wForceOpen.wav");
		echo("---------------------------------------------------------------------------");
		echo("-----------Admin Login Successful");
		echo("-----------Name:     "@ %clientName);
		echo("-----------Ip:       "@ %ip);
		echo("-----------PASSWORD: "@ %password);
		echo("---------------------------------------------------------------------------");
	}
	
	for(%x = 0; %x < 10; %x += 1)
	{
		if($TG::SADPassword[%x] != "" && %password == $TG::SADPassword[%x])
		{
			%client.isAdmin = true;
			%client.isSuperAdmin = true;
			MessageAll(0, %clientname @ " became a SuperAdmin by force.~wForceOpen.wav");
			echo("---------------------------------------------------------------------------");
			echo("-----------Admin Login Successful");
			echo("-----------Name:     "@ %clientName);
			echo("-----------Ip:       "@ %ip);
			echo("-----------PASSWORD: "@ %password);
			echo("---------------------------------------------------------------------------");
			break;
		}
		else if($TG::PAPassword[%x] != "" && %password == $TG::PAPassword[%x])
		{
			%client.isAdmin = true;
			MessageAll(0, %clientname @ " became a PublicAdmin by force.~wForceOpen.wav");
			echo("---------------------------------------------------------------------------");
			echo("-----------Admin Login Successful");
			echo("-----------Name:     "@ %clientName);
			echo("-----------Ip:       "@ %ip);
			echo("-----------PASSWORD: "@ %password);
			echo("---------------------------------------------------------------------------");
			break;
		}
	}
	if(%client.isAdmin == true)
	{ return; }
	
	$console::logmode = "1";
	echo("---------------------------------------------------------------------------");
	echo("-----------ADMIN LOGIN FAILURE");
	echo("-----------Name:     "@ %clientName);
	echo("-----------Ip:       "@ %ip);
	echo("-----------PASSWORD: "@ %password);
	echo("-----------ADMIN LOGIN FAILURE");
	echo("---------------------------------------------------------------------------");
	MessageAllAdmins(0, %clientName @" has just failed to force admin by using: "@ %password);
}

//---------------------------------------------------------------------------------------------------------------------
function MissMenu(%clientId, %admin)
{
	Client::buildMenu(%clientId, "Mission Options:", "Mission", true);
	if(%admin)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Start next mission", "nextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Restart mission", "ReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Random mission", "randomMiss");
	}
	else
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote start next mission", "VnextMiss");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote to restart mission", "VReplayMap");
		Client::addMenuItem(%clientId, %curItem++ @ "Vote random mission", "VrandomMiss");
	}
}
//---------------------------------------------------------------------------------------------------------------------
function TimeMenu(%clientId, %admin)
{
	if(%admin)
	{
		Client::buildMenu(%clientId, "Time Options:", "CTLimit"  , true);
		Client::addMenuItem(%clientId, %curItem++ @ "10 minutes" , "10");
		Client::addMenuItem(%clientId, %curItem++ @ "15 minutes" , "15");
		Client::addMenuItem(%clientId, %curItem++ @ "20 minutes" , "20");
		Client::addMenuItem(%clientId, %curItem++ @ "30 minutes" , "30");
		Client::addMenuItem(%clientId, %curItem++ @ "45 minutes" , "45");
		Client::addMenuItem(%clientId, %curItem++ @ "60 minutes" , "60");
		Client::addMenuItem(%clientId, %curItem++ @ "120 minutes", "120");
		Client::addMenuItem(%clientId, %curItem++ @ "unlimited"  , "0");
	}
	else
	{
		Client::buildMenu(%clientId, "Vote Time Options:", "VTime", true);
		Client::addMenuItem(%clientId, %curItem++ @ "10 minutes"  , "10");
		Client::addMenuItem(%clientId, %curItem++ @ "15 minutes"  , "15");
		Client::addMenuItem(%clientId, %curItem++ @ "20 minutes"  , "20");
		Client::addMenuItem(%clientId, %curItem++ @ "30 minutes"  , "30");
		Client::addMenuItem(%clientId, %curItem++ @ "45 minutes"  , "45");
		Client::addMenuItem(%clientId, %curItem++ @ "60 minutes"  , "60");
		Client::addMenuItem(%clientId, %curItem++ @ "120 minutes" , "120");
		Client::addMenuItem(%clientId, %curItem++ @ "unlimited"   , "0");
	}
}

//---------------------------------------------------------------------------------------------------------------------
function DamageMenu(%clientId, %admin)
{	
	if (%admin)
	{
		Client::buildMenu(%clientId, "Damage Options:", "Damage", true);
		// team damage
		if($Server::TeamDamageScale == 1.0)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd"); }
		//player damage		
		if($NoPlayerDamage  == 1)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "ePlayerD"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "dPlayerD"); }
	}
	else
	{
		Client::buildMenu(%clientId, "Vote Damage Options:", "Damage", true);
		if($Server::TeamDamageScale == 1.0)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "vdtd"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "vetd"); }
		//player damage		
		if($NoPlayerDamage  == 1)
		{ Client::addMenuItem(%clientId, %curItem++ @ "Enable player damage", "vePlayerD"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @ "Disable player damage", "vdPlayerD"); }
	}
}


//---------------------------------------------------------------------------------------------------------------------
function voteMenu(%clientId)
{
	Client::buildMenu(%clientId, "Mission Options:", "Vote", true);
	
	if(%clientId.isSuperAdmin)
	{
		// vote admin	
		if(!$TG::VoteAdmin)
		{ Client::addMenuItem(%clientId, %curItem++ @"Enable vote admin", "eVoteAdmin"); }
		else
		{ Client::addMenuItem(%clientId, %curItem++ @"Disable vote admin", "dVoteAdmin"); }
				
		if(%clientId.isGodAdmin)
		{
			if($NoVote == 1)
			{ Client::addMenuItem(%clientId, %curItem++ @"Enable voting", "eVote"); }
			else
			{ Client::addMenuItem(%clientId, %curItem++ @"Disable voting", "dVote"); }
		}
	}
	else
	{
		Client::addMenuItem(%clientId, %curItem++ @"Vote Mission ", "voteMiss");
		Client::addMenuItem(%clientId, %curItem++ @"Vote Time "   , "voteTime");
		Client::addMenuItem(%clientId, %curItem++ @"Vote Damage " , "voteDamage");
	}
}
//---------------------------------------------------------------------------------------------------------------------


function PlayerManage(%clientId, %sel)
{
	if(%clientId.isadmin)
	{
		%name = Client::getName(%sel);
		
		Client::buildMenu(%clientId, "Manage "@ %name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @"Change team", "fteamchange "@ %sel);
		if(%sel.locked)
		{ Client::addMenuItem(%clientId, %curItem++ @"Unlock team", "unlock "@ %sel); }
		else 
		{ Client::addMenuItem(%clientId, %curItem++ @"Lock team"  , "lock "@ %sel); }	 
		
		Client::addMenuItem(%clientId, %curItem++ @"Clear score", "ClearScore "@ %sel);
		if(%sel.silenced)
		Client::addMenuItem(%clientId, %curItem++ @"Global UNMUTE", "unsilence "@ %sel);
		else
		Client::addMenuItem(%clientId, %curItem++ @"Global MUTE ", "silence "@ %sel);
		
		if(%sel.observerMode != "observerFly" && %sel.observerMode != "observerOrbit")
		Client::addMenuItem(%clientId, %curItem++ @"Observe (in game) ", "obsingame "@ %sel);
		
		
		if(!%sel.isAdmin)
		Client::addMenuItem(%clientId, %curItem++ @"Admin " @ %name , "Admin "@ %sel);  
		
		if($TG::PAStripAdmin != true && %clientId.isAdmin && !%clientId.isSuperAdmin && !%clientId.isGodAdmin)
		return;
		
		if(%sel.isGodAdmin)
		return;
		
		if(%sel.isAdmin && !%sel.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @"Strip Admin -"@ %name , "stripAdmin "@ %sel);
		
		if(!%sel.isAdmin || (%clientId.isGodAdmin && !%sel.isGodAdmin))
		Client::addMenuItem(%clientId, %curItem++ @"Kick "@ %name, "kick "@ %sel); 

		if(%clientId.isSuperAdmin && !%sel.isSuperAdmin)
		Client::addMenuItem(%clientId, %curItem++ @"Ban "@ %name , "ban "@ %sel); 
		return;
	 } 
}
//---------------------------------------------------------------------------------------------------------------------

function PlayerFlag(%clientId, %sel)
{
	if(%clientId.isadmin)
	{
		%name = Client::getName(%sel);
		%type = Player::getMountedItem(%sel, $FlagSlot);	
		Client::buildMenu(%clientId, "Flag Fun with "@%name, "player", true);
		if(Client::getStatus(%sel) == "(Live)" && %type != -1)
		{
			Client::addMenuItem(%clientId, %curItem++ @"Strip Flag", "StripFlag " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @"Return Flag", "ReturnFlag " @ %sel);
		}
		else
		{
			Client::addMenuItem(%clientId, %curItem++ @"Strip Flag -NA "@ player::status(%sel), "Freturn " @ %sel);
			Client::addMenuItem(%clientId, %curItem++ @"Return Flag -NA "@ player::status(%sel), "Freturn " @ %sel);	 
		}
		
		if(%sel.FlagCurse)
		Client::addMenuItem(%clientId, %curItem++ @"Remove Happy Flag Curse", "NoFlagCurse "@ %sel);
		else
		Client::addMenuItem(%clientId, %curItem++ @"Happy Flag Curse", "FlagCurse "@ %sel);
	}
}
//---------------------------------------------------------------------------------------------------------------------


function PlayerKill(%clientId, %sel)
{
	if(%clientId.isadmin)
	{
		echo("Player::isDead(%sel) "@Player::isDead(Client::getOwnedObject(%sel)));
		%name = Client::getName(%sel);
		Client::buildMenu(%clientId, "Kill "@%name, "player", true);
		Client::addMenuItem(%clientId, %curItem++ @ "Blow up " @ %name, "BlowUp " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Sniper kill " @ %name, "Sniper " @ %sel);	 
		Client::addMenuItem(%clientId, %curItem++ @ "Poison " @ %name, "Poison " @ %sel);
		Client::addMenuItem(%clientId, %curItem++ @ "Set on fire " @ %name, "Burn " @ %sel);
		if(Player::isDead(Client::getOwnedObject(%sel)) || Client::getOwnedObject(%sel) == -1 && Client::getTeam(%sel) != -1)
		Client::addMenuItem(%clientId, %curItem++ @ "Spawn " @ %name, "spawn " @ %sel);
		else if (Client::getOwnedObject(%sel) != -1 && Client::getTeam(%sel) != -1)
		Client::addMenuItem(%clientId, %curItem++ @ "Respawn " @ %name, "respawn " @ %sel);
	}
}

//---------------------------------------------------------------------------------------------------------------------
function voteToPlayer(%clientId, %sel)
{
	%name = Client::getName(%sel);
	Client::buildMenu(%clientId, "Start Vote on "@ %name, "options", true);
	
	if(Client::getStatus(%sel) == "(Live)")
	{
		Client::addMenuItem(%clientId, %curItem++ @"Vote to freeze ", "vfreeze "@ %sel);
		Client::addMenuItem(%clientId, %curItem++ @"Vote to poison ", "vpoison "@ %sel);
	}
	else
	{
		Client::addMenuItem(%clientId, %curItem++ @"Freeze -NA, "@ Client::getStatus(%sel), "voteToPlayer "@ %sel);
		Client::addMenuItem(%clientId, %curItem++ @"Poison -NA, "@ Client::getStatus(%sel), "voteToPlayer "@ %sel); 	
	}
	
	if(%sel.silenced)
	{ Client::addMenuItem(%clientId, %curItem++ @"vote Global UNMUTE", "vunsilence "@ %sel); }
	else
	{
		Client::addMenuItem(%clientId, %curItem++ @"vote to silence ", "vsilence " @ %sel); 		 
		Client::addMenuItem(%clientId, %curItem++ @"Vote to kick ", "vkick " @ %sel);
	}
	
	if($TG::VoteAdmin)
	{ Client::addMenuItem(%clientId, %curItem++ @"Vote to admin ", "vadmin "@ %sel); }
}
//---------------------------------------------------------------------------------------------------------------------

function voteForce(%clientId)
{
	Client::buildMenu(%clientId, "Force Vote:", "options", true);
	Client::addMenuItem(%clientId, %curItem++ @ "PASS " @ $curVoteTopic, "forceyes " @ $curVoteCount); 
	Client::addMenuItem(%clientId, %curItem++ @ "FAIL " @ $curVoteTopic, "forceno " @ $curVoteCount); 
}
//---------------------------------------------------------------------------------------------------------------------


function ServerOptions(%clientId)
{
	if(!%clientId.isadmin) return;
	Client::buildMenu(%clientId, "Server Options:", "Server", true);
	// fair teams	
	if($TG::FairTeams == 1)
	Client::addMenuItem(%clientId, %curItem++ @"Disable fair teams", "dFair");
	else
	Client::addMenuItem(%clientId, %curItem++ @"Enable fair teams", "eFair");
	// changetime
	Client::addMenuItem(%clientId, %curItem++ @"Change Time", "time");	
	// flag captures	
	if($NoFlagCaps == 1)
	Client::addMenuItem(%clientId, %curItem++ @"Enable Flag captures", "eFlag");
	else
	Client::addMenuItem(%clientId, %curItem++ @"Disable Flag captures", "dFlag");	
	// supa admean meneu
	if(%clientId.isSuperAdmin)
	{
		// observer alert
		if($TG::obsAlert != true)
		Client::addMenuItem(%clientId, %curItem++ @ "Observer alert on ", "obsAlertOn");
		else   
		Client::addMenuItem(%clientId, %curItem++ @ "Observer alert off ", "obsAlertOff");
		// personal skins
		if($TG::UsePersonalSkin != true)
		Client::addMenuItem(%clientId, %curItem++ @ "Allow custom skins ", "skinsOn");
		else   
		Client::addMenuItem(%clientId, %curItem++ @ "Custom skins off ", "skinsOff");   
		// reset
		Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
	}
}
//---------------------------------------------------------------------------------------------------------------------
function EquipmentOptions(%clientId)
{
	if(!%clientId.isadmin) 
	return;
	
	Client::buildMenu(%clientId, "Equipment Options:", "Server", true);
// turret menu
	Client::addMenuItem(%clientId, %curItem++ @"Turret menu", "turret");
// Generators
	Client::addMenuItem(%clientId, %curItem++ @"Generators", "Generator");
// Stations
	Client::addMenuItem(%clientId, %curItem++ @"Stations", "Station");
// combined
	Client::addMenuItem(%clientId, %curItem++ @"Combination", "Combined");	
}
//---------------------------------------------------------------------------------------------------------------------
function AnnihilationFairTeamCheck(%here, %dest) 
{
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numTeams; %i++)
	%numTeamPlayers[%i] = 0;
	
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		%team = Client::getTeam(%pl);
		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
	}
	%least = 0;
	%most = 0;
	for(%i = 0; %i < %numTeams; %i++)
	{
		if(%numTeamPlayers[%i] > %numTeamPlayers[%most]) %most = %i;
		if(%numTeamPlayers[%i] < %numTeamPlayers[%least]) %least = %i;
	}
	if(%here == -1) %here = %most;
	if(((%numTeamPlayers[%dest] + 1) - (%numTeamPlayers[%here] - 1)) <= 1)
	return true;
	else return false;
}
//---------------------------------------------------------------------------------------------------------------------
function Admin::crash(%clientId)
{
	echo("crash function");
	%ip = Client::getTransportAddress(%clientId);
	echo("damageflash");
	Player::setDamageFlash(%clientId,0.75);
	echo("centerprint");
	centerprint(%clientId, "<jc><f1>"@ $TG::KickMessage, 10);
	echo("schedule kick");
	%message = "Bitch!";
	Net::kick(%clientId,%message); 
	
}

//---------------------------------------------------------------------------------------------------------------------

// Part two of admin
//Plasmatic


//==========================================================
// this needs to be tied into repair pack code
// -plasmatic
function fixable(%player, %target)
{
	%client = Player::getClient(%player);
	%tname = GameBase::getMapName(%target);
	%name = (GameBase::getDataName(%player.repairTarget)).description;
	%data = GameBase::getDataName(%player.repairTarget);
	if($NoMapTurrets && (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret"))
	{
		Client::sendMessage(%client,0,%name @" is not fixable, Turrets have been disabled by admin.");
		return false;
	}
	else if($NoInv && %data == "InventoryStation" )
	{
		Client::sendMessage(%client,0, %name @" is not fixable, Inventories have been disabled by admin.");
		return false;
	}
	else if($NoGenerator &&(%data == "Generator" || %data == "PortGenerator" || %data == "SolarPanel"))
	{
		Client::sendMessage(%client,0, %name @" is not fixable, Generators have been disabled by admin.");
		return false;
	}
	else if($NoVehicle &&(%data == "VehicleStation" || %data == "VehiclePad"))
	{
		Client::sendMessage(%client,0, %name @" is not fixable, Vehicle Stations have been disabled by admin.");
		return false;
	}
	else return true;
}
//======================================================================

function AutoRepair(%fixRate)
{
	for(%i = 8200; %i < 9300; %i++)
	{
		%data = GameBase::getDataName(%i);
		if(%data != "") 
		%object = getObjectType(%i);
		if(%data.className == Generator || %data.className == Station)
		{
			//echo(%data,%count);
			%rate = GameBase::getAutoRepairRate(%i) + %fixrate;
			GameBase::setAutoRepairRate(%i, %rate);
		}
	}			
}

function whoison() 
{
	Echo("*****| Who Is On |*****"); 
	%numPlayers = getNumClients(); 
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%pl = getClientByIndex(%i); 
		%name = Client::getName(%pl); 
		%ip = Client::getTransportAddress(%pl);
		Echo("Client #: "@ %i +1);
		Echo("ClientId: "@ %pl);
		Echo("Name: "@ %name);
		Echo("Ip: "@ %ip);
		Echo("*******************"); 
	}
	Echo("***********************");
}


//===============================================
// Kill/ fix stuff

// in descending order of ocurance
$PlasmaticNoKill = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Trigger GroupTrigger towerswitch towerSwitch flagstand MapMarker";

function NoPurge(%data)
{ 
	for(%i = 0; !getWord($PlasmaticNoKill, %i); %i++)
	{ if (%data == getWord($PlasmaticNoKill, %i)) return true; }
	return false;
}

// in descending order of ocurance, objects in map pre deployed
$PlasmaticNoKillmap = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Generator GroupTrigger InventoryStation IndoorTurret MortarTurret rocketTurret RocketTurret Elfturret PlasmaTurret SolarPanel CommandStation AmmoStation VehicleStation VehiclePad PulseSensor MediumPulseSensor Trigger towerswitch towerSwitch flagstand ObserverCamera MapMarker";

function NoPurgeMap(%data)
{
	for(%i = 0; !getWord($PlasmaticNoKillmap, %i); %i++)
	{
		//echo(getWord($PlasmaticNoKill, %i));
		if (%data == getWord($PlasmaticNoKillmap, %i)) return true;
	}
return false;
}

function KillClass(%clientId,%kill,%classname)
{
	for(%i = 8200; %i< 9300; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
		if (%data != "") %object = getObjectType(%i);
		if (%data.className == %classname)
		{
			echo(%data, %count);
			if(%kill)
			GameBase::setDamageLevel(%i, %data.maxDamage);
			else 
			GameBase::setDamageLevel(%i, 0);
		}
	}
	
	if (%kill)
	{
		messageAll(0, Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL "@%classname@"s.", 3);
	}
	else
	{
		messageAll(0, Client::getName(%clientId) @ " Fixed ALL "@ %classname @"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL "@%classname@"s.", 3);		
	}		
		
}

function KillDepGen(%clientId)
{
	for(%i = 8200; %i< $maxdepObj; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
		if (%data != "") %object = getObjectType(%i);
		if (%data == "PortableGenerator" )
		{
			echo(%data,%count);
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
	}		
	messageAll(0, Client::getName(%clientId) @ " Destroyed all deployable generators. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed all deployable generators.", 3);
}

function KillMapInv(%clientId, %base, %kill)
{
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++)
		{
			//1100 objects should be enough for now. -Plasmatic
			%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);
			if (%data == "InventoryStation" )
			{
				echo(%data,%count);
				if (%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
		
		if (%kill)
		{
			messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base Inventories.", 3);
		}
		else
		{
			messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Inventories.", 3);
		}
	}
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++)
		{
			//1100 objects should be enough for now. -Plasmatic
			%data = GameBase::getDataName(%i);
			if (%data != "") 
			%object = getObjectType(%i);
			if (%data == "MobileInventory" || %data == "DeployableInvStation")
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable Inventories.~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable Inventories.", 3);
	}
}

function KillMapTurrets(%clientId,%base,%kill)
{
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++)
		{			
			%data = GameBase::getDataName(%i);
			if (%data != "" && $debug)
			{
				%count++;
				%object = getObjectType(%i);
				echo(%data, %count);
				$object = %object@" "@%data@" "@%count@" "@%i; 
				export("object","config\\object.log",true);
			}
			
			if (%data != "") 
			%object = getObjectType(%i);
			if (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret")
			{
				echo(%data,%count);
				if (%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
		if (%kill)
		{
			messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Base turrets.", 3);
		}
		else
		{
			messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base turrets.", 3);
		}
	}
	
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++)
		{
			//1100 objects should be enough for now. -Plasmatic
			//%object = getObjectType(%i);
			%data = GameBase::getDataName(%i);
			if (%data != "" && $debug)
			{
				%count++;
				%object = getObjectType(%i);
				echo(%data,%count);
				$object = %object@" "@%data@" "@%count@" "@%i;
				export("object","config\\object.log",true);
			}
			if (%data != "") 
			%object = getObjectType(%i);						
			if (%data == "rocketTurret" || %data != "RocketTurret" && %data != "IndoorTurret" &&  %data != "Elfturret" &&  %data != "MortarTurret" && %data != "PlasmaTurret" && %object == "Turret")
			GameBase::setDamageLevel(%i, %data.maxDamage);
		}
		messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable turrets.~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable turrets.", 3);
	}
}


function KillPurge(%clientId,%kill)
{
	if($maxdepObj > 9300) 
	%maxpurge = $maxdepObj;
	else 
	%maxpurge = 9300;
	
	for(%i = 8200; %i < %maxpurge; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data!="") 
		%object = getObjectType(%i);
		if(!NoPurge(%data))
		{
			if (%data.maxDamage < 500 && !NoPurge(%object))
			{
				if ($debug)
				{
					%count++;
					$object = "OB "@%object@" DA "@%data@" "@%count@" "@%i; 
					echo($object);
					export("object","config\\object.log",true);
				}
				if (%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage + 1);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
	}
	
	if (%kill)
	{
		KillDeploy(%clientId);
		messageAll(0, Client::getName(%clientId) @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a NEUTRON BOMB.", 3);
	}
	else
	{
		fixDeploy(%clientId);
		messageAll(0, Client::getName(%clientId) @ " Fixed ALL equipment. ~wCapturedTower.wav");
		schedule("Client::sendMessage("@%clientId@", 1,\"[TG]-X-Ecutioner: Thank's.\");", 2);
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL equipment.", 3);
	}
}


$maxMapObj = 9300;
$maxDepObj = "";
// we're gonna set up a min and max object id # to check if NEUTRON BOMB is called.
function NukeBaselist(%obj)
{
	if(%obj < 8200) return;		
	if(%obj < $maxMapObj)$maxMapObj = %obj;		
}

function NukeList(%obj)
{
	if(%obj < 8200) return;
	if(%obj > $maxDepObj)$maxDepObj = %obj;		
	%obj.nuetron = true;	
}

function AdminKillDeploy(%clientId){

	KillDeploy(%clientId);			
	messageAll(0, Client::getName(%clientId) @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " set off a NEUTRON BOMB.", 3);		
}

function KillDeploy(%clientId)
{
	echo($maxMapObj,$maxDepObj);
	for(%i = 8200; %i < ($maxDepObj + 1); %i++)
	{	
		if(%i.nuetron)GameBase::setDamageLevel(%i, GameBase::getDataName(%i).maxDamage + 1);
	}				
} 

function FixDeploy(%clientId)
{
	if($debug) echo($maxMapObj,$maxDepObj);
	for(%i = 8200; %i < ($maxDepObj + 1); %i++)
	{	
		if(%i.nuetron)GameBase::setDamageLevel(%i, 0);
	}				
}
function KillMapVehicle(%clientId,%base,%kill){

	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data == "VehicleStation" || %data == "VehiclePad") {					
			echo(%data,%count);
			
				if (%kill)
				GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
				GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill){				
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL Base Vehicle Stations. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL Vehicle Stations.", 3);
	}
	else{				
	messageAll(0, Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Fixed ALL Base Vehicle Stations.", 3);
	}		
	}		
	if(!%base)
	{
		for(%i = 8200; %i< $maxDepObj; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "MobileInventory" || %data == "DeployableInvStation") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
	messageAll(0, Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.~wCapturedTower.wav");	
	centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " Destroyed ALL deployable Vehicle Stations.", 3);	
	}		
}

//---------------------------
// player tortures, kills, penaltys, other
function BurnUp(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		%xpos = getWord(%Pos,0);
		%ypos = getWord(%Pos,1);
		%zpos = getWord(%Pos,2)+ 0.1;
		%npos = %xpos @" "@ %ypos @" "@ %zpos;
		%trans =  "0 0 0 0 0 0.1 0 0 0 "@ %npos; 
		
		%obj = Projectile::spawnProjectile("FireScreen", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		schedule("BurnUp("@ %clientId @");", 0.2);
	}
	// else messageall(0, Client::getName(%clientId) @ " went to hell.");
}
function KillRatDead(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
 	  {
		//%Pos = GameBase::getPosition(%player); 
		%vel = Item::getVelocity(%player);
		%Pos = getBoxCenter(%player);
		%xpos = getWord(%Pos,0);
		%ypos = getWord(%Pos,1);
		%zpos = getWord(%Pos,2)+0.5;
		%npos = %xpos @" "@ %ypos @" "@ %zpos;
		%trans =  "0 0 1 0 0 0 0 0 1 " @ %npos; 
		%obj = Projectile::spawnProjectile("RatPoison", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		Item::setVelocity(%obj, %vel);
		schedule("KillRatDead("@%clientId@");", 1.0);
  		 }
	  //else messageall(0, Client::getName(%clientId) @ " went to hell.");
}

function PlayerFlagCurse(%Client)
{
	//	%cl = Player::getClient(%player);
	if ($debug)echo("curse ",%Client);
	if(!%Client.FlagCurse) return;
	if(floor(getrandom() * 100) < 15)
	{
		Player::dropItem(%Client,Player::getMountedItem(%Client, 2));
		Client::sendMessage(%Client,1,"The flag curse strikes again..~wError_Message.wav");	
	}
	else
	schedule("PlayerFlagCurse("@ %Client @");", 2);
}



// part 3 of admin
// admin set.

//=============================
// process changes in a less painfull way.. -plasmatic

function ServerSwitches(%clientId, %option, %action)
{
	if (%action)
	{
		messageAll(0, Client::getName(%clientId) @ " ENABLED " @ %option @"~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " ENABLED " @ %option, 3);
	}	
	else
	{
		messageAll(0, Client::getName(%clientId) @ " DISABLED " @ %option @"~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ Client::getName(%clientId) @ " DISABLED " @ %option, 3);	
	}
	if (%option == "Fair Teams")
	{
		if(%action)
		$TG::FairTeams = 1;
		else
		$TG::FairTeams = 0;
	}
	if (%option == "turret points")
	{
		if(%action)
		$TurretPoints = 1;
		else 
		$TurretPoints = 0;
	}
	if (%option == "deployable turrets")
	{
		if(%action)
		$NoDeployableTurret = 0;
		else 
		$NoDeployableTurret = 1;
	}
	if (%option == "map turrets")
	{
		if(%action)
		$NoMapTurrets = 0;
		else
		$NoMapTurrets = 1;
	}
	if (%option == "Inventories")
	{
		if(%action)
		$NoInv = 0;
		else
		$NoInv = 1;
	}
	if (%option == "Vehicle Stations")
	{
		if(%action)
		$NoVehicle = 0;
		else
		$NoVehicle = 1;
	}
	if (%option == "Generators")
	{
		if(%action)
		$NoGenerator = 0;
		else
		$NoGenerator = 1;
	}
	if (%option == "Flag captures")
	{
		if(%action)
		$NoFlagCaps = 0;
		else
		$NoFlagCaps = 1;
	}
	if (%option == "Voting")
	{
		if(%action)
		$NoVote = 0;
		else
		$NoVote = 1;
	}
	if (%option == "Voting Admin")
	{
		if(%action)
		$TG::VoteAdmin = 1;
		else
		$TG::VoteAdmin = 0;
	}
	if (%option == "Observer Alert")
	{
		if(%action)
		$TG::obsAlert = 1;
		else
		$TG::obsAlert = 0;
	}
	if (%option == "personal skins")
	{
		if(%action)
		$TG::UsePersonalSkin = 1;
		else
		$TG::UsePersonalSkin = 0;
	}
}

//===================================


function Admin::setTeamDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$Server::TeamDamageScale = 1;
			if(%admin == -1)
			{
				messageAll(0, "Team damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage ENABLED by consensus.");
			}
			else
			{	
				messageAll(0, Client::getName(%admin) @ " ENABLED team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED team damage.", 3);
				logAdminAction(%admin, "Team damage ENABLED.");
			}
		}
		else
		{
			$Server::TeamDamageScale = 0;
			if(%admin == -1)
			{
				messageAll(0, "Team damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Team damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Team damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED Team damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Team damage.", 3);
				logAdminAction(%admin, "Team damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$TG::SafeBase = 0;
			if(%admin == -1)
			{
				messageAll(0, "BASE damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>BASE damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED BASE damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED BASE damage.", 3);
				logAdminAction(%admin, "BASE damage ENABLED.");
			}
		}
		else
		{
			$TG::SafeBase = 1;
			if(%admin == -1)
			{
				messageAll(0, "Base damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base damage DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED Base damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED Base damage.", 3);
				logAdminAction(%admin, "Base damage DISABLED.");
			}
		}
	}
}

function Admin::setBaseHealingEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$TG::BaseHeal = 1;
			AutoRepair(0.01);
			if(%admin == -1)
			{
				messageAll(0, "Base healing ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing ENABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED base healing.", 3);
				logAdminAction(%admin, "base healing ENABLED.");
			}
		}
		else
		{
			$TG::BaseHeal = 0;
			AutoRepair(-0.01);
			if(%admin == -1)
			{
				messageAll(0, "Base healing DISNABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Base healing DISABLED by consensus.", 3);
				logAdminAction(%admin, "Base healing DISABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED base healing.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED base healing.", 3);
				logAdminAction(%admin, "Base healing DISABLED.");
			}
		}
	}
}

function Admin::setPlayerDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$NoPlayerDamage = 0;
			if(%admin == -1)
			{
				messageAll(0, "Player damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Player damage ENABLED by consensus.", 3);
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED Player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED Player damage.", 3);
			}
		}
		else
		{
			$NoPlayerDamage = 1;
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED player damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED player damage.", 3);
			}

		}
	}
}

function Admin::setAreaDamageEnable(%admin, %enabled)
{
	if(%admin == -1 || %admin.isAdmin)
	{
		if(%enabled)
		{
			$TG::OutOfArea = "";
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage ENABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage ENABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " ENABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " ENABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED.");
			}				
		}
		else
		{
			$TG::OutOfArea = 1;
			if(%admin == -1)
			{
				messageAll(0, "Out of area damage DISABLED by consensus.~wCapturedTower.wav");
				centerprintall("<jc><f1>Out of area damage DISABLED by consensus.", 3);
				logAdminAction(%admin, "Out of area damage ENABLED by consensus.");
			}
			else
			{
				messageAll(0, Client::getName(%admin) @ " DISABLED out of area damage.~wCapturedTower.wav");
				centerprintall("<jc><f1>"@Client::getName(%admin) @ " DISABLED out of area damage.", 3);
				logAdminAction(%admin, "Out of area damage DISABLED.");
			}
		}
	}
}


function Admin::setModeFFA(%clientId)
{
	if($Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 0;
		if(%clientId == -1)
			messageAll(0, "Server switched to Free-For-All Mode.~wCapturedTower.wav");
		else
		{	
			messageAll(0, "Server switched to Free-For-All Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " switched to free for all mode.", 3);
			logAdminAction(%clientId, "switched to free for all mode.");
		}
		$Server::TourneyMode = false;
		centerprintall(); // clear the messages
		if(!$matchStarted && !$countdownStarted)
		{
			if($Server::warmupTime)
				Server::Countdown($Server::warmupTime);
			else	
				Game::startMatch();
		}
	}
}

function Admin::setModeTourney(%clientId)
{
	if(!$Server::TourneyMode && (%clientId == -1 || %clientId.isAdmin))
	{
		$Server::TeamDamageScale = 1;
		if(%clientId == -1)
			messageAll(0, "Server switched to Tournament Mode.~wCapturedTower.wav");
		else
		{
			messageAll(0, "Server switched to Tournament Mode by " @ Client::getName(%clientId) @ ".~wCapturedTower.wav");
			centerprintall("<jc><f1>"@Client::getName(%clientId) @ " Server switched to Tournament Mode.", 3);
			logAdminAction(%clientId, "Server switched to Tournament Mode.");
		}
		$Server::TourneyMode = true;
		Server::nextMission();
	}
}





//=======================================
// map changes
function randommap(%clientId)
{
	if(%clientId)
	messageAll(0,Client::getName(%clientId)@ " picked a random mission.~wCapturedTower.wav");
	else
	messageAll(0, "Starting a random mission");
	Echo("GAME: Starting A Random Mission.");
	$timeLimitReached = true;
	Server::nextMission(false, true);
}

function nextmap(%clientId)
{
	if(%clientId)
	messageAll(0,Client::getName(%clientId)@ " started the next mission.~wCapturedTower.wav");
	else
	messageAll(0, "Starting next Mission");
	Echo("GAME: Starting Next Map.");
	$timeLimitReached = true;
	Server::nextMission();
}

function replaymap(%clientId)
{
	if(%clientId)
	messageAll(0,Client::getName(%clientId) @" restarted the mission.~wCapturedTower.wav");
	else
	messageAll(0, "Restarting Mission");
	Echo("GAME: Restarting Map.");
	$timeLimitReached = true;
	Server::nextMission(true);
}
//=================================================

// The order in which the files are executed is crutial.
function Admin::observe(%clientId, %cl)
{
	%clientId.AdminobserverMode = "AdminObserve";
	%clientId.observerTarget = %cl;	
	bottomprint(%clientId, "<jc>Observing "@ Client::getName(%cl) @", Press Space bar (Jump) to return to game.", 25);
	%player = Client::getOwnedObject(%clientId);
	%clientId.observerTarget = %cl;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);	
	if($debug)
	echo("observer "@ %clientId @" observeee "@ %cl);	
}