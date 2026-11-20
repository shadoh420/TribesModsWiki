exec("comchat.cs");
exec("shban.cs"); //=== SHBan Modified For Shifter
exec("remote.cs");
if($Shifter::noSwearing)
   exec("SHBadwordlist.cs");
exec("scoretracker.cs");
exec("game_dmsg.cs");

$Shifter::Hunters = false;

$Shifter::DeathMatch = false;

if (getNumTeams() == 2 || $Shifter::newFairTeams != "false") //== Init Fair Teams ONLY on two team maps...
{	
	if ($debug) echo ("There are only 2 team init Fair Teams");
	exec("fairteams.cs");
}

//================================================== Globals

if ($Shifter::TeamDamage != false)
	$Server::TeamDamageScale = 1;


$fa_armor = "";
$fa_pack = "";
$pskin = $Shifter::PersonalSkin;
$SensorNetworkEnabled = true;
$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$modmgtModName = "SHAntiTK";
$modmgtModVers = "1.30";
$SHBanListMarker = "true";
$SpawnFav = True;

//================================================== End Globals

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
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 1;

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
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 7500;

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

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    	//Define Max Length of the area
$TurretBoxMaxWidth =  50;    	//Define Max Width of the area
$TurretBoxMaxHeight = 10;    	//Define Max Height of the area

$TurretBoxMinLength = 10;	//Define Min Length from another turret
$TurretBoxMinWidth =  10;	//Define Min Width from another turret
$TurretBoxMinHeight = 10;    	//Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType   = 1 << 1;
$SimInteriorObjectType  = 1 << 2;
$SimPlayerObjectType    = 1 << 7;

$MineObjectType		= 1 << 26;	
$MoveableObjectType	= 1 << 22;
$VehicleObjectType	= 1 << 29;  
$StaticObjectType	= 1 << 23;	   
$ItemObjectType		= 1 << 21;	  

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------

$ServerCheats = 0;
$TestCheats = 0;
$AutoRespawn = 0;

//===============================================================================================================
// Randomize Spawn Buy List
//===============================================================================================================

if (!$Shifter::Factory && !$Shifter::SaveOn)
{
	if ($Debug) echo ("Loading Standard Equip Set");
	$spawnBuyList[0] = MediumArmor;
	$spawnBuyList[1] = HyperB;
	$spawnBuyList[2] = Vulcan;
	$spawnBuyList[3] = Disclauncher;
	$spawnBuyList[4] = RepairKit; 
	$spawnBuyList[5] = PlasmaGun; 
	$spawnBuyList[6] = BoomStick; 
	$spawnBuyList[7] = Grenade; 
	$spawnBuyList[8] = Grenade;
	$spawnBuyList[9] = MineAmmo;
	$spawnBuyList[10] = Beacon;
	$spawnBuyList[11] = Beacon;
	$spawnBuyList[12] = Beacon;
	$spawnBuyList[13] = TargetingLaser;
	$spawnBuyList[14] = RepairPack;
	$spawnBuyList[15] = "";
	$fa_armor = "Mercenary";
	$fa_pack = "RepairPack";
}


//===============================================================================================================
function standardSpawnlist(%client)
{
	if ($Debug) echo ("----------------------->Spawning Standard");
	if($Shifter::EngStandard != "False")
	{
		$spawnBuyList[0, %client] = EngArmor;
		$spawnBuyList[1, %client] = RailGun;
		$spawnBuyList[2, %client] = PlasmaGun;
		$spawnBuyList[3, %client] = RocketLauncher;
		$spawnBuyList[4, %client] = GravGun; 
		$spawnBuyList[5, %client] = RepairKit; 
		$spawnBuyList[6, %client] = Grenade; 
		$spawnBuyList[7, %client] = Grenade; 
		$spawnBuyList[8, %client] = MineAmmo;
		$spawnBuyList[9, %client] = Beacon;
		$spawnBuyList[10, %client] = HackIt;
		$spawnBuyList[11, %client] = DisIt;
		$spawnBuyList[12, %client] = FixIt;
		$spawnBuyList[13, %client] = TargetingLaser;
		$spawnBuyList[14, %client] = DeployableInvPack;
		$spawnBuyList[15, %client] = "";
		$fa_pack = "Inventory Station";
		$fa_armor = "Engineer";
	}
	else
	{
		$spawnBuyList[0, %client] = MediumArmor;
		$spawnBuyList[1, %client] = HyperB;
		$spawnBuyList[2, %client] = Vulcan;
		$spawnBuyList[3, %client] = Disclauncher;
		$spawnBuyList[4, %client] = RepairKit; 
		$spawnBuyList[5, %client] = Chaingun; 
		$spawnBuyList[6, %client] = BoomStick; 
		$spawnBuyList[7, %client] = Grenade; 
		$spawnBuyList[8, %client] = Grenade;
		$spawnBuyList[9, %client] = MineAmmo;
		$spawnBuyList[10, %client] = Beacon;
		$spawnBuyList[11, %client] = Beacon;
		$spawnBuyList[12, %client] = Beacon;
		$spawnBuyList[13, %client] = TargetingLaser;
		$spawnBuyList[14, %client] = RepairPack;
		$spawnBuyList[15, %client] = "";
		$fa_armor = "Mercenary";
		$fa_pack = "Repair Pack";
	}	
}

//===============================================================================================================
function savedSpawnList(%clientId)
{
	if ($Debug) echo ("----------------------->Spawning Saved");
	
	//$spawnBuyList[%clientId, 0] = $funk::var[%name, 1];
	
	if ($debug) echo("Loading armor " @ %clientId.SavedList[0] @ " for " @ %clientId);
	   	
	for(%i = 0; %clientId.SavedList[%i] != ""; %i++)
	{
		%item = GetWord(%clientId.SavedList[%i], 0);
		%ammt = GetWord(%clientId.SavedList[%i], 1);
		
		$spawnBuyList[%i, %clientId] = %item;
	}
		
	if (%clientId.favsettings)
		%clientId.spawntype = %clientId.spawntypetwo;

	%clientId.spawn = false;

	if($Shifter::LoadoutList == "false")
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f2>You have spawned with your previously saved favorites.\", 10);", 3);
}	

//===============================================================================================================
function favoriteSpawnList(%client)
{
	if ($Debug) echo ("----------------------->Spawning Favorites");
	%clientId = %client;
	if (%client.favsettings)
	{
		if ($SpawnFav)
		{
			%error = 0;
			%max = getNumItems();
			
			if ($debug) echo ("Checking Items");
			
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				%count = Player::getItemCount(%client,%item);

				if(%count)
				{
					if(%item.className != Armor)
					teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
					Player::setItemCount(%client, %item, 0);  
				}				
			}
			
			if ($debug) echo ("Buying New");
			
			for (%i = 0; %i <= 19; %i++)
			{
				if(%client.fav[%i] != "")
				{
					%item = getItemData(%client.fav[%i]);
					if ($debug) echo ("Bought " @ %i @ " - " @ %item @ "");
					if (%i == 0)
					{
						$fa_armor = %item.description;
					}
					$spawnBuyList[%i, %clientId] = %item;
				}
		  	}
		}
	}
}

//===============================================================================================================
function randomSpawnList(%client)
{
	if ($Debug) echo ("----------------------->Spawning Randonm");

		%rnd = floor(getRandom() * 61) + 1;	
		if ($debug) echo("Setting Up Gear For Random Spawn" @ %rnd @ " - ");
		if (%rnd <= 10) //20) //=========================== Most of the time 
		{
			if ($debug) echo("Spawn - Mercenary");
			$spawnBuyList[0, %client] = MediumArmor;
			$spawnBuyList[1, %client] = BoomStick;
			$spawnBuyList[2, %client] = Vulcan;
			$spawnBuyList[3, %client] = RocketLauncher;
			$spawnBuyList[4, %client] = PlasmaGun; 
			$spawnBuyList[5, %client] = GrenadeLauncher;
			$spawnBuyList[6, %client] = Grenade; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = RepairKit;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = ShieldPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Shield Pack";
			$fa_armor = "Mercenary";


		}
		if (%rnd >= 11 && %rnd <= 18)
		{
			if ($debug) echo("Spawn - Chemeleon");
			$spawnBuyList[0, %client] = SpArmor;
			$spawnBuyList[1, %client] = Silencer;
			$spawnBuyList[2, %client] = PlasmaGun;
			$spawnBuyList[3, %client] = Disclauncher;
			$spawnBuyList[4, %client] = Grenade; 
			$spawnBuyList[5, %client] = Grenade;
			$spawnBuyList[6, %client] = Grenade; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = MineAmmo;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = RepairKit;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = StealthShieldPack;
			$spawnBuyList[15, %client] = "";
			$fa_armor = "Chemeleon";
			$fa_pack = "Stealth Shield";
		}
		if (%rnd >= 19 && %rnd <= 20)
		{
			if ($debug) echo("Spawn - Juggernaught");
			$spawnBuyList[0, %client] = Juggernaught;
			$spawnBuyList[1, %client] = RocketLauncher;
			$spawnBuyList[2, %client] = Hammer1Pack;
			$spawnBuyList[3, %client] = Hammer2Pack;
			$spawnBuyList[4, %client] = MortarAmmo;
			$spawnBuyList[5, %client] = RepairKit;
			$spawnBuyList[6, %client] = RepairKit; 
			$spawnBuyList[7, %client] = RepairKit; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = HammerPack;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = Mortar;
			$spawnBuyList[15, %client] = "";
			$fa_armor = "Juggernaught";
			$fa_pack = "Godhammer Cannon";
		}	
		if ((%rnd >= 21) && (%rnd <= 28))
		{
			if ($debug) echo("Spawn - Drednaught");
			$spawnBuyList[0, %client] = DragArmor;
			$spawnBuyList[1, %client] = Mortar;
			$spawnBuyList[2, %client] = Vulcan;
			$spawnBuyList[3, %client] = RocketLauncher;
			$spawnBuyList[4, %client] = RepairKit; 
			$spawnBuyList[5, %client] = ConCun; 
			$spawnBuyList[6, %client] = Chaingun; 
			$spawnBuyList[7, %client] = PlasmaGun; 
			$spawnBuyList[8, %client] = Blaster;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = Grenade;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = SMRPack;
			$spawnBuyList[15, %client] = "";
			$fa_armor = "Dreadnaught";
			$fa_pack = "Rocket Launcher Pack";
		}

		if ((%rnd >= 29) && (%rnd <= 35))
		{
			if ($debug) echo("Spawn - Assassin");
			$spawnBuyList[0, %client] = LightArmor;
			$spawnBuyList[1, %client] = Silencer;
			$spawnBuyList[2, %client] = Railgun;
			$spawnBuyList[3, %client] = SniperRifle;
			$spawnBuyList[4, %client] = RepairKit; 
			$spawnBuyList[5, %client] = MineAmmo; 
			$spawnBuyList[6, %client] = Grenade; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = Beacon;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = EnergyPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Energy Pack";
			$fa_armor = "Assassin";
		}
	
		if ((%rnd >= 36) && (%rnd <= 40))
		{
			if($debug) echo("Spawn - Goliath");
			$spawnBuyList[0, %client] = BursterArmor;
			$spawnBuyList[1, %client] = Mortar;
			$spawnBuyList[2, %client] = RocketLauncher;
			$spawnBuyList[3, %client] = Flamer;
			$spawnBuyList[4, %client] = RepairKit;
			$spawnBuyList[5, %client] = PlasmaGun; 
			$spawnBuyList[6, %client] = DiscLauncher; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = EnergyPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Energy Pack";
			$fa_armor = "Goliath";
		}
	
		if ((%rnd >= 41) && (%rnd <= 45))
		{
			if ($debug) echo("Spawn - Arbitor");
			$spawnBuyList[0, %client] = AlArmor;
			$spawnBuyList[1, %client] = HyperB;
			$spawnBuyList[2, %client] = Volter;
			$spawnBuyList[3, %client] = Boomer;
			$spawnBuyList[4, %client] = RepairKit; 
			$spawnBuyList[5, %client] = FusionBlaster; 
			$spawnBuyList[6, %client] = Grenade; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = LightningPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Teleport Pack";
			$fa_armor = "Arbitor";
		}
	
		if ((%rnd >= 46) && (%rnd <= 48))
		{
			if ($debug) echo("Spawn - Scout");
			$spawnBuyList[0, %client] = ScoutArmor;
			$spawnBuyList[1, %client] = Mortar;
			$spawnBuyList[2, %client] = RocketLauncher;
			$spawnBuyList[3, %client] = RepairKit;
			$spawnBuyList[4, %client] = MineAmmo; 
			$spawnBuyList[5, %client] = MineAmmo; 
			$spawnBuyList[6, %client] = Grenade; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = MineAmmo;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Beacon;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = FlightPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Flight Pack";
			$fa_armor = "Scout";
		}
	
		if ((%rnd >= 49) && (%rnd <= 51))
		{
			if ($debug) echo("Spawn - Engineer");
			$spawnBuyList[0, %client] = EngArmor;
			$spawnBuyList[1, %client] = RailGun;
			$spawnBuyList[2, %client] = PlasmaGun;
			$spawnBuyList[3, %client] = RocketLauncher;
			$spawnBuyList[4, %client] = RepairKit; 
			$spawnBuyList[5, %client] = HackIt; 
			$spawnBuyList[6, %client] = Chaingun; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = MineAmmo;
			$spawnBuyList[9, %client] = DisIt;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = FixIt;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = DeployableInvPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Inventory Station";
			$fa_armor = "Engineer";
		}

		if ((%rnd >= 52) && (%rnd <= 57))
		{
			if ($debug) echo("Spawn - Neo-Juggernaught");
			$spawnBuyList[0, %client] = HeavyArmor;
			$spawnBuyList[1, %client] = Mfgl;
			$spawnBuyList[2, %client] = HammerPack;
			$spawnBuyList[3, %client] = Hammer1Pack;
			$spawnBuyList[4, %client] = Hammer2Pack; 
			$spawnBuyList[5, %client] = RocketLauncher; 
			$spawnBuyList[6, %client] = Mortar; 
			$spawnBuyList[7, %client] = HammerAmmo; 
			$spawnBuyList[8, %client] = HammerAmmo;
			$spawnBuyList[9, %client] = HammerAmmo;
			$spawnBuyList[10, %client] = MortarAmmo;
			$spawnBuyList[11, %client] = RocketAmmo;
			$spawnBuyList[12, %client] = MortarAmmo;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = FGCPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Containment Pack";
			$fa_armor = "Neo-Juggernaught";
		}

		if ((%rnd >= 58)) // && (%rnd <= 61))
		{
			if ($debug) echo("Spawn - Arbitor 2");
			$spawnBuyList[0, %client] = AlArmor;
			$spawnBuyList[1, %client] = Flamer;
			$spawnBuyList[2, %client] = LaserRifle;
			$spawnBuyList[3, %client] = Blaster;
			$spawnBuyList[4, %client] = EnergyRifle; 
			$spawnBuyList[5, %client] = Beacon; 
			$spawnBuyList[6, %client] = Mine; 
			$spawnBuyList[7, %client] = Grenade; 
			$spawnBuyList[8, %client] = Grenade;
			$spawnBuyList[9, %client] = Mine;
			$spawnBuyList[10, %client] = Beacon;
			$spawnBuyList[11, %client] = Beacon;
			$spawnBuyList[12, %client] = Mine;
			$spawnBuyList[13, %client] = TargetingLaser;
			$spawnBuyList[14, %client] = EnergyPack;
			$spawnBuyList[15, %client] = "";
			$fa_pack = "Energy Pack";
			$fa_armor = "Arbitor";
		}
	
	if($Shifter::SpawnRandom == "false" && !%client.favsettings)
	{
		if ($debug) echo("Spawn - Standard - No Random");
		standardSpawnlist(%client);
	}
}

//===============================================================================================================
function Game::playerSpawned(%pl, %clientId, %armor)
{	

//========================== Set some of the Deathmatch variables back to normal in a really Ghetto fashion.

	if($Shifter::DeathMatch != "false")
	$Shifter::DeathMatch = false;

//========================== End Ghetto coding

	//end Blink curse period
	%clientId.Blinked = false;

	Observer::checkObserved(%clientId);

	$InfTime[%clientId] = 0;
	$burntime[%clientId] = 0;
	$cloaktime[%clientId] = 0;
	$empTime[%clientId] = 0;
	$shieldTime[%clientId] = 0;
	$poisonTime[%clientId] = 0;

	$bob = false;

	if ($debug) echo ("PL " @ %pl @ "");
	if ($debug) echo ("CL " @ %clientId @ "");
	if ($debug) echo ("ST " @ %clientId.spawntype @ "");
	
	if(%clientId.custom)
	{
	       	Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	}
	
	%clientId.spawntime = getsimtime();
	
	//=================================================================== Custom Spawn Settings

	if ($Shifter::PowerCheck == "true" && !ispowerdown(gamebase::getteam(%clientId)) && !$Portagen[GameBase::getTeam(%clientId)] && $matchStarted)
	{
		standardSpawnList(%clientId);
		%msg = "<jc><f3>Your power is down!";
		if($debug) echo("Team " @ GameBase::getTeam(%clientId) @ "'s power is down, spawning " @ Client::getName(%clientId) @ " in Standard armor.");
	}	
	else if (%clientId.spawntype == "standard")
	{
		standardSpawnList(%clientId);
		%msg = "<jc><f3>You have spawned in Standard armor.";
		if($debug) echo("Spawning " @ Client::getName(%clientId) @ " in Standard armor.");
	}
	else if (%clientId.spawntype == "random")
	{
		randomSpawnList(%clientId);
		%msg = "<jc><f3>You have spawned in a randomly selected loadout.";
		if($debug) echo("Spawning " @ Client::getName(%clientId) @ " in a Random armor.");
	}
	else if (%clientId.spawntype == "favs")
	{
		if($Shifter::SpawnFavs)
		{
			if (%clientId.favsettings)
			{
				FavoriteSpawnList(%clientId);
				%msg = "<jc><f3>You have spawned with your selected favorites.";
			}
			else
			{
				%msg = "<jc><f3>You must select your favorites before you can be spawned with them.";
			}
		}
		else
		{
			%msg = "<jc><f3>You have spawned in a randomly selected loadout.";
			randomSpawnList(%clientId);
		}
	}
	else if ($Shifter::SaveOn && %clientId.SavedInfo && %clientId.spawntype == "saved")
	{
		savedSpawnList(%clientId);
		%clientId.spawntype = %clientId.spawntypetwo;
		%msg = "<jc><f3>You have spawned with your last saved loadout.";
		if($debug) echo("Spawning " @ Client::getName(%clientId) @ " with saved favorites.");
	}

	$Shifter::JustSpawned[%clientId] = "True";
	schedule ("$Shifter::JustSpawned[" @ %clientId @ "] = False;",$Shifter::SpawnSafe);

	//======================================================================================== Buy Actual Items

	if ($Debug) echo ("Buying Inventory");

	%clientId.spawn= 1;
	%max = getNumItems();

	if($spawnBuyList[0, %clientId] == "")
		randomSpawnList(%clientId);

	for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
	{
		//=== Prevent ammo pack spawns from creating erroneous ammo readings
//		if(getWord(%item,0) == ammopack)
//		{
//			schedule(%clientId@".spawn = 1;",0.3);
//			schedule("buyItem("@%clientId@","@%item@");",0.3);
//			schedule(%clientId@".spawn = 0;",0.3);			
//		}
//		else
			buyItem(%clientId,%item);
		if(%item.className == Weapon) 
			%clientId.spawnWeapon = %item;
		if ($Debug) echo ("Buying = " @ %item);
	}

	for (%i = 0; %i < 12; %i++)
	{
		buyItem(%clientId,"Beacon");
		buyItem(%clientId,"Grenade");
		buyItem(%clientId,"MineAmmo");
	}


	%clientId.spawn= "";

	if(%clientId.spawnWeapon != "")
	{
		Player::useItem(%pl,%clientId.spawnWeapon);	
		%clientId.spawnWeapon="";
	}

//====================================== Prevent Weaponless (naked) Spawns
	if((Player::getArmor(%pl) == "larmor" || Player::getArmor(%pl) == "lfemale") && Player::getItemCount(%clientId,LightArmor) == 0)
	{
		standardSpawnlist(%clientId);

		if($debug) echo("Player " @ Client::getName(%clientId) @ " spawned naked, using standard spawn.");

		%clientId.spawn = 1;

		for(%i = 0; (%item = $spawnBuyList[%i, %clientId]) != ""; %i++)
		{
			//=== Prevent ammo pack spawns from creating erroneous ammo readings
//			if(getWord(%item,0) == ammopack)
//			{
//				schedule(%clientId@".spawn = 1;",0.3);
//				schedule("buyItem("@%clientId@","@%item@");",0.3);
//				schedule(%clientId@".spawn = 0;",0.3);			
//			}
//			else
				buyItem(%clientId,%item);
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
			if ($Debug) echo ("Buying = " @ %item);
		}
		%clientId.spawn = "";

//		if($Shifter::EngStandard != "False")
//		{
//			if(%armor == "larmor")
//				%armor = earmor;
//			else
//				%armor = efemale;
//		}
//		else
//		{
//			if(%armor == "larmor")
//				%armor = marmor;
//			else
//				%armor = mfemale;
//		}
//		Player::setArmor(%clientId,%armor);

//		if($Shifter::BoosterPacks && $Shifter::EngStandard == "False")
//		{
//			Player::setItemCount(%clientId,Booster1Pack,1);
//			Player::setItemCount(%clientId,Booster2Pack,1);
//			schedule ("Player::mountItem( " @ %clientId @ ", Booster1Pack,4);",0.3);
//			schedule ("Player::mountItem( " @ %clientId @ ", Booster2Pack,5);",0.3);
//		}

//		for(%i = 0; $spawnBuyList[%i, %clientId] != ""; %i++)
//		{
//			%item = $spawnBuyList[%i, %clientId];
//			Player::incItemCount(%clientId,%item);
//			if($debug) echo("Buying " @ %item.description @ ".");

//			if($WeaponAmmo[%item] != "")
//			{
//				%ammo = $WeaponAmmo[%item];
//				%maxammo = $ItemMax[%armor, %ammo];
//				Player::setItemCount(%clientId,%ammo,%maxammo);
//			}

//			if(%i == 14)
//			{
//				Player::useItem(%clientId,%item);
//				if($debug) echo("Mounting " @ %item.description @ ".");
//			}
//		}
		remoteNextWeapon(%clientId);
		$bob = true;
		%msg = "<jc><f3>You have spawned in Standard armor.";
	}
//============================================================== Message players about gens being down
	if(!ispowerdown(gamebase::getteam(%clientId)) && !$Portagen[Gamebase::getTeam(%clientId)] && $matchStarted)
		%msg = "<jc><f3>Your power is down!";

//=========================== Give Juggernaught full ammo and prevent Godhammer being mounted to weapon slot
	if(Player::getArmor(%clientId) == "jarmor")
	{
		Player::setItemCount(%clientId,AutoRocketAmmo,35);
		Player::setItemCount(%clientId,MortarAmmo,35);
		Player::setItemCount(%clientId,RocketAmmo,35);
		Player::mountItem(%clientId,RocketLauncher,$Weaponslot);
	}

//============================================================== Cool spawn messages
	if(%clientId.spawntype == "standard" || %clientId.spawntype == "random" || $bob)
		bottomprint(%clientId, "<jc><f2>You have spawned in <f0>" @ $fa_armor @ "<f2> armor with a <f0>" @ $fa_pack @ "<f2> backpack.", 10);

	if($Shifter::LoadoutList != "false")
		ListClientLoadout(%clientId,%msg);

//============================================================== Reset FastFavs
	%clientId.tobuy = false;
} 

//================================================== Y|yukichigai's Uber-cool Loadout Listing
function ListClientLoadout(%client,%msg)
{
	$bob = false;

	//====================== Armor
	%armor = Player::getArmor(%client);
	%adata = $ArmorName[%armor];
	%aname = %adata.description;
	%msg = %msg @ "\n<f1>Armor: <f2>" @ %aname;

	//====================== Pack
	%pack = Player::getMountedItem(%client,1);
	%pname = %pack.description;
	if(%pname == false)
	{
		//=============================== Check for Godhammers
		if(Player::getItemCount(%client,Hammer1Pack) && %armor == jarmor)
			%pname = "Godhammer Cannons";
		else
			%pname = "None";
	}
	%msg = %msg @ "\n<f1>Pack: <f2>" @ %pname;

	//====================== Weapons
	%msg = %msg @ "\n<f1>Weapons:<f2>";
	for(%i=0;%i<=$WeaponAmmt;%i++)
	{
		if(Player::getItemCount(%client,$WeaponList[%i]))
		{
			%weapon = $WeaponList[%i];
			%wname = %weapon.description;
			if(%weapon.classname != "tool")  //Exclude Engineer Guns
			{
				if($bob) %msg = %msg @ "<f1>,<f2>";
				%msg = %msg @ " " @ %wname;
				$bob = true;
			}
		}
	}

	//====================== Print to screen
	bottomprint(%client,%msg,10);
}	

//===============================================================================================================

function Game::playerSpawn(%clientId, %respawn)
{
   	if(!$ghosting)
      		return false;

	if ($debug) echo ("ST1" @ %clientId.spawntype @ "");

	if(%clientId.laswait != 0)
		%clientId.laswait = 0;

	if(%clientId.boosted != 0)
		%clientId.boosted = 0;

	if(%clientId.observermode)
		%clientId.observermode = "";

	//=== Return any team's flag that is out of bounds whenever a player spawns
	if($Shifter::NoFlagOOB != "false" && $matchstarted)
	{
		for(%i = 0; %i <= $teamFlags; %i++)
		{
			if(%i == 0)
				%flag = $teamFlag[Client::getTeam(%clientId)];
			else
				%flag = $teamFlag[Client::getTeam(%clientId),%i];
			if(%flag)
			{
				%fpos = GameBase::getPosition(%flag);
				%xpos = getWord(%fpos,0);
				%ypos = getWord(%fpos,1);
				if(%xpos > $mBounds[X,Max] || %xpos < $mBounds[X,Min] || %ypos > $mBounds[Y,Max] || %ypos < $mBounds[Y,Min])
				{
					GameBase::startFadeOut(%flag);
					GameBase::setPosition(%flag, %flag.originalPosition);
					Item::setVelocity(%this, "0 0 0");
					GameBase::startFadeIn(%flag);
					%flag.atHome = true;
					%flag.carrier = -1;                           
					Item::hide(%flag, false);
					messageAll(1,"The "@getTeamName(Client::getTeam(%clientId))@" flag left the mission area and was returned to base.~wflagreturn.wav");
					ObjectiveMission::ObjectiveChanged(%flag);
				}
			}
		}
		for(%i=0;%i < $FnRFlags;%i++)
		{
			%flag = $FnRFlag[%i];
			%fpos = GameBase::getPosition(%flag);
			%xpos = getWord(%fpos,0);
			%ypos = getWord(%fpos,1);
			if(%xpos > $mBounds[X,Max] || %xpos < $mBounds[X,Min] || %ypos > $mBounds[Y,Max] || %ypos < $mBounds[Y,Min])
			{
				GameBase::startFadeOut(%flag);
				GameBase::setPosition(%flag, %flag.originalPosition);
				Item::setVelocity(%this, "0 0 0");
				GameBase::startFadeIn(%flag);
				%flag.atHome = true;
				%flag.carrier = -1;                           
				Item::hide(%flag, false);
				messageAll(1,%flag.objectiveName@" left the mission area and was returned to base.~wflagreturn.wav");
				ObjectiveMission::objectiveChanged(%flag);
			}
		}
	}

	//=== Turret Tracker.  Prevents you from getting TK warnings from turrets you deployed
	//===  Doesn't work yet.  I'll get it though
//	if($Shifter::TurretTracker != "false" && $matchStarted)
//	{
//		%name = Client::getName(%clientId);
//		for(%i = 0;$TurretTrack[%name,%i] != "";%i++)
//		{
//			%turret = $TurretTrack[%name,%i];
//			if(getObjectType(%turret) != "Player")
//			{
//				if(GameBase::getTeam(%turret) != Client::getTeam(%clientId))
//				{
//					%turret.deployr = 2150;
//					Client::setOwnedObject(2150,%turret);
//				}
//				else
//				{
//					%turret.deployr = %clientId;
//					Client::setOwnedObject(%clientId,%turret);
//				}
//			}
//		}
//	}

	if (!$Shifter::SpawnType || ($Shifter::SpawnType != "random" && $Shifter::SpawnType != "standard" && $Shifter::SpawnType != "favs"))
	{
		if($Shifter::SpawnType == "favorites")
			$Shifter::SpawnType = "favs";
		else
			$Shifter::SpawnType = "random";
	}	
	
	if (%clientId.spawntype != "favs" && %clientId.spawntype != "random" && %clientId.spawntype != "standard" && %clientId.spawntype != "saved")
	{
		%clientId.spawntype = $Shifter::SpawnType;
	}


	Client::clearItemShopping(%clientId);
   	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);

   if(!%respawn) //================================================================================== Server Welcome Message On First Spawn
   {
		if ($Shifter::WelcomeDelay > 0)
		{
			//bottomprint(%clientId, $Shifter::WelcomeMsg, $Shifter::WelcomeDelay);
			schedule("bottomprint(" @ %clientId @ ",$Shifter::WelcomeMsg, $Shifter::WelcomeDelay);", 1);
		}
   
   		if ($Shifter::Saveon)
   		{
   			LoadCharacter(%clientId);
		}	
   }
	if(%spawnMarker)
	{
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   	if(%spawnMarker == -1)
	   	{
	   	   	%spawnPos = "0 0 300";
	   	   	%spawnRot = "0 0 0";
	   	}
	   	else
	   	{
	   	   	%spawnPos = GameBase::getPosition(%spawnMarker);
	   	   	%spawnRot = GameBase::getRotation(%spawnMarker);
	   	}

		if($Shifter::DeathMatch)
		{
		   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
		   		%armor = "dmarmor";
		   	else
		   		%armor = "dmfemale";
		}
		else
		{
		   	if(!String::ICompare(Client::getGender(%clientId), "Male"))
		   		%armor = "larmor";
		   	else
		   		%armor = "lfemale";
		}

	   	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		if ($debug) echo ("ST2 " @ %clientId.spawntype @ "");
	   	if ($debug) echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   	
	   	if(%pl != -1)
	   	{
	   	   	GameBase::setTeam(%pl, Client::getTeam(%clientId));
	   	   	Client::setOwnedObject(%clientId, %pl);
	   	   	Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	   	   
	   	   	if($matchStarted)
	   	      		Client::setControlObject(%clientId, %pl);
	   	   	else
	   	   	{
	   	   	   	%clientId.observerMode = "pregame";
	   	   	   	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	   	   	   	Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	   	   	}
	   	}
      		return true;
	}
	else
	{
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      		return false;
	}
}


//===============================================================================================Game CS Functions
	
function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
	%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
	%count = Group::objectCount(%group);

	if(!%count)
		return -1;

	%spawnIdx = floor(getRandom() * (%count - 0.1));
	%value = %count;

	for(%i = %spawnIdx; %i < %value; %i++)
	{
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);

		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0)
		{
			deleteObject(%set);
			return %obj;		
		}

		if(%i == %count - 1)
		{
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
	return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()																						// game.cs
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");

	for(%i = 0; %i < $ObjSwitches; %i++)
	{
		%q = $ObjSwitch[%i];
		if(%q.objectiveName == "")
		{
			if(GameBase::getMapName(%q) != "")
				%q.objectiveName = GameBase::getMapName(%q);
			else
				%q.objectiveName = "Objective "@%i + 1;
		}
	}

	//=== Set some values for the mission bounds
	%temp = WaypointtoWorld("1023 1023");
	$mBounds[X,Max] = getWord(%temp,0);
	$mBounds[Y,Max] = getWord(%temp,1);
	%temp = WaypointtoWorld("0 0");
	$mBounds[X,Min] = getWord(%temp,0);
	$mBounds[Y,Min] = getWord(%temp,1);


	Game::resetScores();	

	echo("\"M\"" @ $missionName @ "\"" @ ($Server::timeLimit * 60) + $missionStartTime - getSimTime() @ "\"");


	//======================= Create Power Object Tree
	DumpObjectTree();	

	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1)
	{
		if($TeamEnergy[%i] != "Infinite")
		schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
		{
			%cl.observerMode = "";
			Client::setControlObject(%cl, Client::getOwnedObject(%cl));
		}
		Game::refreshClientScore(%cl);
	}
	Game::checkTimeLimit();
}


function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);
   	
   	if($Server::TourneyMode)
   	{
      		%clName = Client::getName(%clientId);
      		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %clientId));
      		if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %clientId));
      		if(String::findSubStr(%clName,$Shifter::Tag0) >= 0)
			{
			GameBase::setTeam(%clientId, 0);
			}
		else if(String::findSubStr(%clName,$Shifter::Tag1) >= 0)
			{
			GameBase::setTeam(%clientId, 1);
			}
      		else 
      			GameBase::setTeam(%clientId, -1);
      		
   	}
   	else
   	{
   	   	if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
   	   	{
   		    	%clientId.observerMode = "observerOrbit";
   		    	%clientId.guiLock = "";
	   	    	Observer::jump(%clientId);
   	        	return;
       		}
   
       		%numTeams = getNumTeams();
   	   	%curTeam = Client::getTeam(%clientId);

      		if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         		Game::assignClientTeam(%clientId);
   	}    


	

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%camSpawn = Game::pickObserverSpawn(%clientId);
	Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	GameBase::getRotation(%camSpawn), true, true);

	if(Client::getTeam(%clientId) == -1)
	{
		%clientId.observerMode = "pickingTeam";
		
		if($Server::TourneyMode && ($matchStarted || $matchStarting))
		{
			%clientId.observerMode = "observerFly";
			return;
		}
		else if($Server::TourneyMode)
		{
			if($Server::TeamDamageScale)
				%td = "ENABLED";
			else
				%td = "DISABLED";
			bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nYour team will be assigned.\nTeam damage is " @ %td, 0);
		}
	
		if(!$Server::TourneyMode)
		{
		Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
		Client::addMenuItem(%clientId, "0Observe", -2);
		Client::addMenuItem(%clientId, "1Automatic", -1);
		
		for(%i = 0; %i < getNumTeams(); %i = %i + 1)
			Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
		}
		%clientId.justConnected = "";
		
	}
	else 
	{
		Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);

		if(%clientId.justConnected)
		{
			SHCheckAutoAdmins(%clientId);
			SHCheckTransportAddress(%clientid);
			CheckNoBans(%clientId);

			//============================================================================================================= Player - Personal Skin Menu
			if ($Shifter::PersonalSkin != "false")
			{
				Client::buildMenu(%clientId, "Choose Your Skin Setting:", "usecustom");
				Client::addMenuItem(%clientId, "0 Use Personal Skin", 0);
				Client::addMenuItem(%clientId, "1 Use Team Default", 1);
			}

			%name = Client::getName(%clientId);
			if($Shifter::TurretTracker != "false")
			{
				for(%i = 0; $TurretTrack[%name,%i] != ""; %i++)
				{
					%turret = $TurretTrack[%name,%i];
					Client::setOwnedObject(%clientId,%turret);
					%turret.deployr = %client;
				}
			}

			bottomprint(%clientId, $Server::JoinMOTD, 0);	      
			%clientId.observerMode = "justJoined";
			%clientId.justConnected = "";
		}
		else if(%clientId.observerMode == "justJoined")
		{
			centerprint(%clientId, "");
			%clientId.observerMode = "";
			Game::playerSpawn(%clientId, false);
			%clientId.TeamJoinTime = getSimTime();
		}   
		else
		{
			Game::playerSpawn(%clientId, false);
			%clientId.TeamJoinTime = getSimTime();
		}
	}

	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuuseCustom(%clientId, %skin)
{
	if(%skin == 0)
	{
		%clientId.custom = True;
	}
	if(%skin == 1)
	{
		%clientId.custom = False;
	}
	if(%team != -2)
	{
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;

		%clientId.teamEnergy = 0;
		Client::setControlObject(%clientId, -1);
		Game::playerSpawn(%clientId, false);
		%clientId.TeamJoinTime = getSimTime();
	}
}

//function processMenuPickTeam(%clientId, %team, %adminClient) // admin.cs 
//{
//   if (%adminClient==2048) $AdminName = "the Administrator";
//   else $AdminName = Client::getName(%adminClient);

//   	checkPlayerCash(%clientId);
//   if(%team != -1 && %team == Client::getTeam(%clientId))
//      return;

//   if(%clientId.observerMode == "justJoined")
//   {
//      %clientId.observerMode = "";
//      centerprint(%clientId, "");
//   }

//   if((!$matchStarted || !$Server::TourneyMode || %adminClient) && %team == -2)
//   {
//      if(Observer::enterObserverMode(%clientId))
//      {
//       //TS
//       echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");
//       
//         %clientId.notready = "";
//         if(%adminClient == "" || %adminClient == %clientId) 
//            messageAll(0, Client::getName(%clientId) @ " became an observer.");
//         else
//            messageAll(0, Client::getName(%clientId) @ " was forced into observer mode by " @ $AdminName @ ".");
//			Game::resetScores(%clientId);
//		   Game::refreshClientScore(%clientId);
//      }
//      return;
//   }

//   %player = Client::getOwnedObject(%clientId);
//   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
//   {
//		playNextAnim(%clientId);
//	   Player::kill(%clientId);
//	}
//   %clientId.observerMode = "";
//   if(%adminClient == "" || %adminClient == %clientId)
//      messageAll(0, Client::getName(%clientId) @ " changed teams.");
//   else
//      messageAll(0, Client::getName(%clientId) @ " was teamchanged by " @ $AdminName @ ".");

//   if(%team == -1)
//   {
//      Game::assignClientTeam(%clientId);
//      %team = Client::getTeam(%clientId);
//   }
//   
//   //TS
//   echo("\"A\"" @ %clientId @ "\"" @ %team @ "\"");

//   GameBase::setTeam(%clientId, %team);
//   %clientId.teamEnergy = 0;
//	Client::clearItemShopping(%clientId);
//	if(Client::getGuiMode(%clientId) != 1)
//		Client::setGuiMode(%clientId,1);		
//	Client::setControlObject(%clientId, -1);

//   Game::playerSpawn(%clientId, false);
//	%team = Client::getTeam(%clientId);
//	if($TeamEnergy[%team] != "Infinite")
//		$TeamEnergy[%team] += $InitialPlayerEnergy;
//   if($Server::TourneyMode && !$CountdownStarted)
//   {
//      cneterprint(%clientId, "<f1><jc>Press FIRE when ready.", 0);
//      %clientId.notready = true;
//   }
//}

function Game::ForceTourneyMatchStart()
{
	%playerCount = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pregame")
			%playerCount++;
	}

	if(%playerCount == 0)
		return;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")   
			processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
	}
	Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
	if($CountdownStarted || $matchStarted)
		return;

	// loop through all the clients and see if any are still notready
	%playerCount = 0;
	%notReadyCount = 0;

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.observerMode == "pickingTeam")
		{
			%notReady[%notReadyCount] = %cl;
			%notReadyCount++;
		}   
		else if(%cl.observerMode == "pregame")
		{
			if(%cl.notready)
			{
				%notReady[%notReadyCount] = %cl;
				%notReadyCount++;
			}
			else
				%playerCount++;
		}
	}
	
	if(%notReadyCount)
	{
		if(%notReadyCount == 1)
			MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
		else if(%notReadyCount < 4)
		{
			for(%i = 0; %i < %notReadyCount - 2; %i++)
				%str = Client::getName(%notReady[%i]) @ ", " @ %str;

			%str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) @ " are holding things up!";
		
			MessageAll(0, %str);
		}
		return;
	}

	if(%playerCount != 0)
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%cl.notready = "";
			%cl.notreadyCount = "";
			bottomprint(%cl, "", 0);
		}
		Server::Countdown(30);
	}
}


function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: Timelimit reached.");
      $timeLimitReached = true;
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}
//======================================================================================================== Reset Client Scores Back To Zero
function Game::resetScores(%client)
{
	if ($debug) echo("*** Resetting Client Scores");
	if(%client == "")
	{
	   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	   	{
			if ($debug) echo ("*** Begin Scores For " @ %cl);
	
	   		%cl.scoreKills = 0;
   	   		%cl.scoreDeaths = 0;
			%cl.ratio = 0;
      			%cl.score = 0;
			%cl.FlagCaps = 0;			
			if (%cl.TKCount > 0)
				%cl.TKCount = %cl.TKCount;
			else
				%cl.TKCount = 0;
		}
	}
	else
	{
		if ($Shifter::Saveon)
		{
			SaveCharacter(%client);
		}
		else
		{
			if ($debug) echo ("*** Resetting Scores For " @ %client);
			if (%client.TKCount > 0)
				%client.TKCount = %cl.TKCount;
			else
				%client.TKCount = 0;

			%client.BadWordsSpoken = 0;
			%client.scoreKills = 0;
			%client.scoreDeaths = 0;
			%client.FlagCaps = 0;		
			%client.ratio = 0;
			%client.score = 0;
			%client.ismuted=False;
		}
	}
}

//function remoteSetArmor(%player, %armorType)
//{
//	%client = Player::getClient(%player);
//	if(%client.isGod)
//	{
//	   	Player::setArmor(%player, %armorType);
//	}
//}

//========================================================================================================== SetUp Players Stats On Connect
function Game::onPlayerConnected(%playerId)
{

	%playerId.scoreKills = 0;
	%playerId.scoreDeaths = 0;
	%playerId.score = 0;
	%playerId.TKCount = 0;
	%playerId.FlagCaps = 0;
	%playerId.justConnected = true;
	%playerId.favsettings = "False";
	%playerId.Plastic = 2;	//Defaults Plastique detonation time to 2 seconds
	%playerId.morphcheat = 0;  //added
	$InfTime[%playerId] = 0;

	for (%i = 0; %i <= 21; %i++)
	{
		%playerId.fav[%i] = "";
		$spawnBuyList[%i, %playerId] = "";	
	}

	$menuMode[%playerId] = "None";
	Game::refreshClientScore(%playerId);
	//echo ("Setting up " @ %PlayerId);	
}


function Game::assignClientTeam(%clientId)																		// game.cs
{
	if($teamplay)
	{
		%name = Client::getName(%clientId);
		%numTeams = getNumTeams();
		%numPlayers = getNumClients();

		for(%i = 0; %i < %numTeams; %i = %i + 1)
			%numTeamPlayers[%i] = 0;

		for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
			%pl = getClientByIndex(%i);

			if(%pl != %clientId)
			{
				%team = Client::getTeam(%pl);
				%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
			}
		}

		%leastPlayers = %numTeamPlayers[0];
		%leastTeam = 0;

		for(%i = 1; %i < %numTeams; %i++)
		{
			if((%numTeamPlayers[%i] < %leastPlayers) || (%numTeamPlayers[%i] == %leastPlayers && $teamScore[%i] < $teamScore[%leastTeam]))
			{
					%leastTeam = %i;
					%leastPlayers = %numTeamPlayers;
			}
		}

		GameBase::setTeam(%clientId, %leastTeam);
		//echo("**** Player " @ %clientId @ " set to team " @ gamebase::getteam(%clientId));
		echo("\"A\"" @ %clientId @ "\"" @ %leastTeam @ "\"");
	}
	else
	{
		GameBase::setTeam(%clientId, 0);
		//echo ("Client Team Set To " @ gamebase::getteam(%clientId));
	}	
}

function Game::setRandomTeam()
{
	bottomprintall ("<jc>Randomly Assigning Teams - Occurs Every " @ $Shifter::TeamJuggle @ " Missions.");
	%numTeams = getNumTeams();
	%numPlayers = getNumClients();
	echo ("*********************** BEGINING TEAM ASSIGNMENT");
	
	if (!%numPlayers)
	{
		if ($debug) echo ("ADMINMSG **** No Players In Game Not Assigning Teams");
		return;
	}

	echo ("**** Numbers Of Players " @ %numPlayers);
	
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		%player[%i] = %pl;
		gamebase::setteam(%pl, -1);		
		echo ("**** Clearing Player Teams " @ %pl);
	}

	%assigned = 0;
	
	for(%k = 0; AllOnTeam() || (%assigned < %numplayers); %k++)
	{
		if (%k > 2000)
		{	
			echo ("**** Could Not Assign All Players In Given Time - Breaking Loop.");	
			break;
		}
		
		%rnd = floor(getRandom() * (%numPlayers) );
		%playerId = %player[%rnd];
		
		if (gamebase::getteam(%playerId) == -1)
		{
			Game::assignClientTeam(%playerId);
			echo ("**** Player " @ %playerId @ " Assigned To Team " @ gamebase::getteam(%playerId));
			%assigned++;
		}
	}
	echo ("***********************");
	echo ("**** Players Assigned To Teams = " @ %assigned @ " out of " @ %numplayers);
	echo ("*********************** DONE WITH TEAM ASSIGNMENT");
}

function AllOnTeam()
{
	%numPlayers = getNumClients();

	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if (gamebase::getteam(%pl) == "-1")
		{
			//echo ("**** Player " @ %pl @ " still unassigned.");
			return true;
		}
	}
	echo ("**** All Players Have Been Assigned");
	return false;
}




function Game::clientKilled(%playerId, %killerId)
{

}

function Client::leaveGame(%clientId)
{

}

//==================================================================================== Outside Mission Area Damage
function Player::enterMissionArea(%player)
{
	%player.outArea="";
	echo("player entering map again");
	%cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have returned to the mission area");
}

function Player::leaveMissionArea(%player)
{  
	%cl = Player::getClient(%player);
	if(%cl.obsposs == true)
		return;
	if($Shifter::OOBBounce)
	{
		BouncePlayer(%player);
		%player.outArea = 1;
	}
  	else if($Shifter::NoOutside || $Shifter::DeathMatch)
  	{
		if($Game::missionType == "CTF")
		{
		    if($debug) echo("Player " @ %player @ " has left the mission area. 10 Sec to Death");
			Client::sendMessage(%cl,1,"You have left the mission area. In 10 secs, you start to die!");
			%player.outArea=1;
			alertPlayer(%player, 5);
		}
		else
		{
  		    if($debug) echo("Player " @ %player @ " has left the mission area.");
		    %player.outArea = 1;
		}
  	}
}

//=== BouncePlayer sends the player back into the mission area with a tiny bit of extra kick
function BouncePlayer(%player)
{
	%pos = GameBase::GetPosition(%player);
	%vel = Item::getVelocity(%player);
	%xpos = getWord(%pos,0);
	%ypos = getWord(%pos,1);
	%xvel = getWord(%vel,0);
	%yvel = getWord(%vel,1);
	%zvel = getWord(%vel,2);
	if(%xpos >= $mBounds[X,Max] || %xpos <= $mBounds[X,Min])
	{
		%xvel *= -1.1;
	}
	if(%ypos >= $mBounds[Y,Max] || %ypos <= $mBounds[Y,Min])
	{
		%yvel *= -1.1;
	}
	Item::setVelocity(%player,%xvel@" "@%yvel@" "@%zvel);
	GameBase::playSound(%player, SoundFireMortar, 0);
//	Client::sendMessage(Player::getClient(%player),1,"Bouncy!");
	schedule("FlingPlayer("@%player@");",1);
	
}

//=== If the player is somehow still outside the mission area, FlingPlayer will send them flying so fast they'll have to get in it
function FlingPlayer(%player)
{
	if(Player::isDead(%player))
		return;

	%pos = GameBase::GetPosition(%player);
	%xpos = getWord(%pos,0);
	%ypos = getWord(%pos,1);
	if(%xpos > $mBounds[X,Max] || %xpos < $mBounds[X,Min] || %ypos > $mBounds[Y,Max] || %ypos < $mBounds[Y,Min])
	{ 
		%armor = Player::getArmor(%player);
		%velocity = 55 * %armor.mass;
		%dpos = Vector::Sub(%xpos@" "@%ypos@" 0",($mBounds[X,Min] + $mBounds[X,Max])/2@" "@($mBounds[Y,Min] + $mBounds[Y,Max])/2@" 0");
		%Vsq = %velocity * %velocity;
		%Vecsq = (GetWord(%dpos,0) * GetWord(%dpos,0)) + (GetWord(%dpos,1) * GetWord(%dpos,1));
		%vdif = (sqrt(%Vsq / %Vecsq) * -1);
		%diffVector = GetWord(%dpos,0) * %vdif @ " " @ GetWord(%dpos,1) * %vdif @ " 0";//GetWord(%dpos,2) * %vdif;
		Player::applyImpulse(%player,%diffVector);
		Client::sendMessage(Player::getClient(%player),1,"Get back in the mission area!");
		//=== In case they're somehow WAY far out.
		schedule("FlingPlayer("@%player@");",2);
	}
}

function alertPlayer(%player, %count)
{
	if(%player.outArea == 1)
	{
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count == 4)
		{
			%set = nameToID("MissionCleanup/ObjectivesSet");
			for(%i = 0; (%obj = Group::getObject(%set, %i)) != -1; %i++)
	  		GameBase::virtual(%obj, "playerLeaveMissionArea", %player);		
			schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		}	
		else if(%count > 1)
		   	schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",2,%clientId);
		else
		   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) 
	{
		if(!Player::isDead(%player))
		{
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
			if(!Player::isDead(%player))
	   			schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
			else
			{ 
				playNextAnim(%client);
				messageAll(0,Client::GetName(%client) @" stayed outside the mission area too long.");
			}
		}
	}
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

//========================================================================================================================================
//========================================================================================================================================
//                                   ...Player Kills Or Dies - Anti-TK Stuff - Kill Scoring Etc...
//========================================================================================================================================
//========================================================================================================================================

function Player::onKilled(%this)
{
	echo("*** Player Killed ***");

	%this.Station = "";

   	$killedflagcarry = "False";
	%killedflag = "false";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	if($Hologram[%cl,Possessor])
		doneposs($Hologram[%cl,Possessor]);

	%client = Player::getClient(%this);

	%client.heatup = "0";
	%client.heatlock = "0";
	%client.plasmacharge = "0";
	%client.charging = "0";
	%client.lascharge = "0";
	%client.laswait = 0; //for laser mine limit
	%client.boosted = "0"; //added
	%client.ovd = 0;
	%client.contrling = "";
	%client.missile = "";
	%client.burner = "";
	%client.EMPMessageTime = 0;
	%client.gravSource = 0;
	%client.gravTime = 0;
	$emptime[%client] = 0;
	$poisonTime[%client] = 0;
	$stimTime[%client] = 0;
	$shieldTime[%client] = 0;
	$burntime[%client] = 0;
	$InfTime[%client] = 0;

	UnCheckObservers(%client);
	doneposs(%cl);
	doneposs(%client);

	(%client.posstarby).posstar = "";
	%client.posstarby = "";
	(%client.posstar).posstarby = "";
	%client.posstar = "";

	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
		
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
		
	Player::setDamageFlash(%this,0.75);
	
	for (%i = 0; %i < 8; %i = %i + 1) 
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type == "flag")
			$killedflagcarry = "True";
		if (%type != -1)
		{
			if ((%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") && %i != 4 && %i != 5) 
				Player::dropItem(%this,%type);
		}
	}

   	if(%cl != -1)
   	{
		if(%this.vehicle != "")
		{
			if(%this.driver != "")
			{
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			}
			else
			{
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
	
		%kdpos = GameBase::getPosition(%this);
		%this.shit = 1;
		%this.TKDeathPos = %kdpos;

		%cl.lastkillpos = %kdpos;
		$killedarmor = Player::getArmor(%this);

		%this.owned = %client; //=== Allows Multi-mode weapons to fire in the mode the player was using

		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		Observer::setOrbitObject(%cl, %this, 5, 5, 5);
		%cl.observerMode = "dead";
		%cl.dieTime = getSimTime();
   	}
	schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
	schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
	schedule(%this@".owned = 0;", $CorpseTimeoutValue + 2.0, %this);
}


function Client::onKilled(%playerId, %killerId, %damageType, %vertPos, %quadrant)													// game.cs
{
	echo ("Player " @ %playerId);
	echo ("Killer " @ %killerId);
	
	%playerId.lascharge = "";
	%playerId.charging = "";


	if($Hologram2[%playerId])
	{
		if($Hologram[%playerId,Deployer].poss == %cl)
			doneposs($Hologram[%playerId,Deployer]);

		if($origTeam[Client::GetOwnedObject(%playerId)] == "")
			%team = GameBase::GetTeam(%playerId);
		else
			%team = $origTeam[Client::getOwnedObject(%playerId)];

		$origTeam[Client::getOwnedObject(%playerId)] = "";

		$TeamItemCount[%team @ "hologram"]--;
		
	}

	if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && (%killerId != playerId))
		echo("\"T\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");
	else
		echo("\"K\"" @ %killerId @ "\"" @ %playerId @ "\"" @ %damageType @ "\"" @ "1" @ "\"");   

	%killedflag = $killedflagcarry;	
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);

	if(!String::ICompare(Client::getGender(%playerId), "Male"))
	{
		%playerGender = "his";
	}
	else
	{
		%playerGender = "her";
	}
	
	%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%ridy = %ridx + 4;
	%victimName = Client::getName(%playerId);

	if(%victimName == "")
		%victimName = "a mindless automoton";

	if(!%killerId || %killerId == "-1") // || %victimName == "") //=== No Killer Listed
	{
		%obitMsg = sprintf($deathMsg[%damageType, %ridy],%victimName,%playerGender);
		if($deathMsg[%damageType, %ridy] != "")
		{
			messageAll(0, %obitMsg, $DeathMessageMask);
		}
		else
		{
			messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
		}
		%playerId.scoreDeaths++;
		if ($ScoreOn) bottomprint(%playerId,"You have died " @ %playerId.scoreDeaths @ " time(s).",3);	
	
		//End the possession period
//		doneposs(%playerId.poss);
		doneposs(%playerId);
		return;
	}
	else if(%killerId == %playerId) //=== Suicide Kill
	{
		if (%damageType == $LandingDamageType)
		{
			%cratMsg = sprintf($deathMsg[$LandingDamageType, %ridx], %victimName, %playerGender);
			messageAll(0, %cratMsg, $DeathMessageMask);
			%playerId.scoreDeaths++;
		}
		else
		{
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		}
		if (%killedflag)
		{
			%playerId.score = (%playerId.score - $Score::FlagDef);
			if ($ScoreOn) bottomprint(%playerId,"You had the Flag. Your score reduced to " @ %playerId.score @ " Due To Suicide.",3);  
		}
		else
		{
			%playerId.score--;
			if ($ScoreOn) bottomprint(%playerId,"Your score reduced to " @ %playerId.score @ " Due To Suicide <-1 Point>.",3);
		}

		echo("*** Suicide Death");
		Game::refreshClientScore(%playerId);
	
		//End the possession period
		doneposs(%playerId);
		return;
	}
	else
	{
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
			%killerGender2 = "he";
			%killerGender3 = "him";
		}
		else
		{
			%killerGender = "her";
			%killerGender2 = "she";
			%killerGender3 = "her";
		}

		%pteam = Client::getTeam(%playerId);
		%kteam = Client::getTeam(%killerId);

		if($InfTime[%killerId] > 0)
			%kteam = %killerId.origTeam;
		if($InfTime[%playerId] > 0)
			%pteam = %playerId.origTeam;
		
		if($teamplay && %kteam == %pteam) //(Client::getTeam(%killerId) == Client::getTeam(%playerId)))
		{
			if(%damageType != $MineDamageType && %killerId.observerMode != "dead" && %playerId.possessed != "true") 
				messageAll(0, strcat(Client::getName(%killerId), " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else if(%killerId.observerMode == "dead")
				messageAll(0, strcat(Client::getName(%killerId), " cuts down ", %killerGender, " teammate ", %victimName ," in the throws of death."), $DeathMessageMask);
			else if(%playerId.possessed == "true")
				messageAll(0, strcat(Client::getName(%killerId), " takes out ", %killerGender, " possessed teammate, ", %victimName), $DeathMessageMask);
			else 
				messageAll(0, strcat(Client::getName(%killerId), " killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			
			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);

			 if ($Shifter::TeamKillOn == "True" && %killerId.observerMode != "dead")
			 {
				CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant);
	
				//End the possession period
//				doneposs(%playerId.poss);
				doneposs(%playerId);
				return;
			 }
			
			//End the possession period
//			doneposs(%playerId.poss);
			doneposs(%playerId);	 
		}
		else
		{
			%killername = Client::getName(%killerId);
			if(%killername == "" || %killername == false || %killername == False)
			{
				%kobj = GameBase::getDataName(%killerId);
				%participle = getParticiple(%kobj.description);
				%killername = %participle @ " " @ %kobj.description;
				%killerGender = "its";
			}
			%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killername,%victimName, %killerGender, %playerGender);
			messageAll(0, %obitMsg, $DeathMessageMask);

			%score = (Game::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant));
			%killedpos = $lastkillpos;				//== Killed Pos
			%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
			%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag
			
			if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType || %damagetype == $RailDamageType) )
			{
				%msg = " HEAD SHOT";
			}
			
			if ($Shifter::JustSpawned[%playerId])
			{
				%score = floor (%score / 2);
				if($debug) echo ("*** Player Just Spawned - Points Are Halved");
			}

			if(%score < 1) %score = 1;

			%killerId.scoreKills++;					//=== Killer Number Of Kills
            		%playerId.scoreDeaths++;  				//=== Killed Player Deaths
            		%killerId.score = (%killerId.score + %score);		//=== Killer Score
			
			if (%killedflag)
			{
				if ($ScoreOn) bottomprint(%killerId, "Flag Runner Killed! Score +" @ %score @ " = " @ %killerId.score @ " Total Score");
              				messageAll(0, Client::getName(%killerId) @ " gets a bonus for killing the flag runner!!!");
			}
			else
			{
				if ($ScoreOn) bottomprint(%killerId, "Score +" @ %score @ " = " @ %killerId.score @ " Total Score" @ %msg @ ".");
   			}

   			//====================================== Refresh Scores		 
         
			Game::refreshClientScore(%killerId);
         		Game::refreshClientScore(%playerId);
	
			//End the possession period
//			doneposs(%playerId.poss);
			doneposs(%playerId);
         		return;
		}
	}
}

function CheckTeamKiller(%killerId,%playerId,%damagetype, %vertPos, %quadrant)
{
	if(%damagetype != $MineDamageType && %damagetype != $GravDamageType && %damagetype != $CloakDamageType && $InfTime[%playerId] <= 0 && $InfTime[%killerId] <= 0)
	{
		%ppos = %playerid.TKDeathPos;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if($teamplay && (Client::getTeam(%killerId) != Client::getTeam(%cl)))
			{
				if(%cl != %playerId && %cl != %killerId)
				{
					%pppos = GameBase::getPosition(%cl);
					%dist = Vector::getDistance(%ppos,%pppos);
					if ($debug) echo("***" @ Client::getName(%cl) @ " was " @ %dist @ " from " @ Client::getName(%playerId));
					if ($debug) echo("***" @ %dist @ " " @ $SHAntiTeamKillProximity);

					if(%dist < $SHAntiTeamKillProximity)
					{
						if ($debug) echo("***Player "@ Client::getName(%playerId) @" was close, kill is accidental.");
						Client::sendMessage(%killerId, 0, "You team killed...");
						return;
					}
				}
			}
		}	
	        messageAll(0, "***" @ Client::getName(%killerId) @ " TeamKilled***");

  	$killedflagcarry = "False";		 //== Reset
	%playerId.lastkillpos = -1;			 //== Reset
	$killedarmor = -1;			 //== Reset		   		
	   		
	%score = (Game::killpoints(%playerId, %killerId, %vertPos,%quadrant));

	if ($Shifter::JustSpawned[%playerId] == "false")
	{
		%killerId.scoreDeaths++;									//=== Killer Number Of Kills
		%killerId.score = (%killerId.score - %score);				//=== Killer Score
		if ($Shifter::Debug) echo ("*** Player Team Killed - Deducting Points");
	}
	else
	{
		%score = floor(%score / 2);
		%killerId.scoreDeaths++;									//=== Killer Number Of Kills
		%killerId.score = (%killerId.score - %score);				//=== Killer Score
		if ($Shifter::Debug) echo ("*** Team Kill - But Killed Player Just Spawned - Possible Accident - Points Deducted Halved");
	}
	
	//====================================== Refresh Scores
	Game::refreshClientScore(%killerId);
	Game::refreshClientScore(%playerId);

	if (%killedflag)
	{
		if ($ScoreOn) centerprint(%killerId, "You Team Killed The Flag Runner! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
		messageAll(0, Client::getName(%killerId) @ " TEAM KILLED his own Flag Runner!!!");
	}
	else
	{
		if ($ScoreOn) bottomprint(%killerId, " You Team Killed! Score -" @ %score @ " = " @ %killerId.score @ " Total Score");
	}

	$Shifter::LastTker = (Client::getName(%killerId));
	$Shifter::LastTKed = (Client::getName(%playerId));
	$Shifter::LastTKno = (%killerid.TKCount + 1);

        if(%killerid.TKCount == "")
        {
                %killerid.TKCount = 1;
        }
        else
        {
            	%killerid.TKCount = %killerid.TKCount + 1;
			
		//=============================================================================================== Server Terminates Team Killer

		if (%killerid.TKCount > $Shifter::KillTerm)
		{
			if ($Shifter::KillTerm > "1")
			{
				bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than " @ $Shifter::KillTerm @ " Times.",5);
				schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
			}
			else
			{
				bottomprintall("***" @ Client::getName(%killerId) @ " Was Terminated For TeamKilling More Than 1 Time.", 5); 
				schedule ("Player::Kill(" @ %killerId @ ");", 2.0);
			}
		}

		if(%killerid.TKCount > $SHAntiTeamKillMaxKills)
		{
			%clientId = %killerId;
			%addr = Client::getTransportAddress(%killerId);

			for(%i=0; $Server::NoBan[%i] != "" || $Server::NoBanAddr[%i] != "" ;%i++)
			{
				if(($Server::NoBan[%i] == "" || $Server::NoBan[%i] == Client::getName(%clientId)) && String::findSubStr(%addr,$Server::NoBanAddr[%i]) == 0)
				{
					return;
				}
			}		
			
			bottomprintall("***" @ Client::getName(%killerId) @ " Was Kicked and Banned For TeamKilling", 5); 

			%ip = Client::getTransportAddress(%killerId);
			BanList::add(%ip, $SHAntiTeamKillBanTime);      //=== Add Player To BanList
			shban(%ip);
			%killer = Client::getOwnedObject(%killerId);
			messageAll(0, Client::getName(%killerId) @ " was kicked and banned for teamkilling");
			Net::kick(%killerId,"***" @ $Shifter::TeamKillMsg @ "***");
		}
		else
		{
	            	if(%killerid.TKCount > $SHAntiTeamKillWarnKills)
	            	{
	                	centerprint(%killerId, "You have killed " @ %killerId.TKCount @ " teammates. If you continue you will be kicked and banned.", 10);
	            	}	
		}
        }		
    }
}

function Game::killpoints(%playerId, %killerId, %damagetype, %vertPos, %quadrant)
{
	//==================================================================================================================== Advanced Scoring
	//== See also in the objectives.cs file for the print out of stats... Currently Stats are printed for all players... 
	//==================================================================================================================== Advanced Scoring

	%score = 0;						//== Reset Scoring
	%killerteam = Client::getTeam(%killerId);		//== Killers Team
	%diedteam = Client::getTeam(%playerId);			//== Died Team
	%killedpos = %playerId.lastkillpos;				//== Killed Pos
	%killerpos = GameBase::getPosition(%killerId);          //== Killers Pos
	%killerarmor = Player::getArmor(%killerId);		//== Killers Armor
	%diedarmor = $killedarmor;				//== Died Armor
	%flagpos = ($teamFlag[%killerteam]).originalPosition;	//== Flags Home Pos
	%flagdist = Vector::getDistance(%killedpos,%flagpos);	//== Distance from Killed Player To Enemy
	%killdist = Vector::getDistance(%killedpos,%killerpos);	//== Distance from Killed Player To Enemy Flag

	$killedflagcarry = "False";

	%playerId.lastkillpos = -1; //== Reset
	$killedarmor = -1; //== Reset

	//============================================================================================================== Flag Runner Killed Bonus

	if (%killedflag)
	{
		%score = (%score + $Score::FlagKill);
	}

	//============================= This data block is used to determin the amount of bonus kill points that a player
	//============================= with a certain armor type will get for killing a player of with another armor type.
	//============================= The calculation will take the difference of the two - player and killer armor types
	//============================= and award the killer with that number as a score bonus.
	//============================= If a player in SpyArmor Kills a player in Jarmor the difference is 5 points...

	if (%killerarmor == "larmor") 		  %kval = 1; //== Assassin Armor
	else if (%killerarmor == "lfemale")	  %kval = 1; //== Assassin Armor 
	else if (%killerarmor == "marmor")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "mfemale")	  %kval = 2; //== Mecenary
	else if (%killerarmor == "earmor") 	  %kval = 3; //== Engineer 
	else if (%killerarmor == "efemale")	  %kval = 3; //== Engineer 
	else if (%killerarmor == "spyarmor")  	  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "spyfemale") 	  %kval = 1; //== Chemeleon 
	else if (%killerarmor == "sarmor")	  %kval = 1; //== Scout 
	else if (%killerarmor == "sfemale")	  %kval = 1; //== Scout 
	else if (%killerarmor == "stimarmor")	  %kval = 2; //== Scout 
	else if (%killerarmor == "stimfemale")	  %kval = 2; //== Scout 
	else if (%killerarmor == "barmor") 	  %kval = 4; //== Goliath 
	else if (%killerarmor == "bfemale")	  %kval = 4; //== Goliath 
	else if (%killerarmor == "darmor") 	  %kval = 5; //== Dreadnaught 
	else if (%killerarmor == "harmor")	  %kval = 4; //== Heavy 
	else if (%killerarmor == "aarmor")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "afemale")	  %kval = 3; //== Arbitor 
	else if (%killerarmor == "dmarmor")	  %kval = 2; //== Death Match
	else if (%killerarmor == "dmfemale")      %kval = 2; //== Death Match
	else if (%killerarmor == "parmor")        %kval = 0; //== Penis Curse Armor
	else if (%killerarmor == "jarmor")	  %kval = 6; //== Juggernaught

	if (%diedarmor == "larmor") 		 %dval = 1; //== Assassin Armor
	else if (%diedarmor == "lfemale")	 %dval = 1; //== Assassin Armor 
	else if (%diedarmor == "marmor")         %dval = 2; //== Medium 
	else if (%diedarmor == "mfemale")	 %dval = 2; //== Medium 
	else if (%diedarmor == "earmor") 	 %dval = 3; //== Engineer 
	else if (%diedarmor == "efemale")	 %dval = 3; //== Engineer 
	else if (%diedarmor == "spyarmor")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "spyfemale")	 %dval = 1; //== Chemeleon 
	else if (%diedarmor == "sarmor")	 %dval = 1; //== Scout 
	else if (%diedarmor == "sfemale")	 %dval = 1; //== Scout 
	else if (%diedarmor == "stimarmor")	 %dval = 2; //== Scout 
	else if (%diedarmor == "stimfemale")	 %dval = 2; //== Scout 
	else if (%diedarmor == "barmor") 	 %dval = 4; //== Goliath 
	else if (%diedarmor == "bfemale")	 %dval = 4; //== Goliath 
	else if (%diedarmor == "darmor") 	 %dval = 5; //== Dreadnaught 
	else if (%diedarmor == "harmor")	 %dval = 4; //== Heavy 
	else if (%diedarmor == "aarmor")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "afemale")	 %dval = 3; //== Arbitor 
	else if (%diedarmor == "dmarmor")	 %dval = 2; //== Death Match
	else if (%diedarmor == "dmfemale")	 %dval = 2; //== Death Match
	else if (%diedarmor == "parmor")  	 %dval = 0; //== Penis Curse Armor
	else if (%diedarmor == "jarmor")	 %dval = 6; //== Juggernaught

	//=============================================================== Base-Flag Defence Scoring

	if (%flagdist <= 25)
	{
		%score = (%score + $Score::25Meters);
	}
	else if ((%flagdist > 25) && (%flagdist <= 75))
	{
		%score = (%score + $Score::75Meters);
	}
	else if ((%flagdist > 75) && (%flagdist <= 150))
	{
		%score = (%score + $Score::150Meters);
	}
	else if ((%flagdist > 150) && (%flagdist <= 250))
	{
		%score = (%score + $Score::250Meters);
	}
	else
	{
		%score = (%score + 1);
	}

	//=============================================================== Armor Kill Armor Bonuses

	if (%kval < %dval) 
	{
		%armordiff = (%dval - %kval);
		if($debug) echo ("    Kill Armor Diff   = " @ %armordiff);
		%score = (%score + %armordiff);
	}

	//=============================================================== Kill Range Bonus
		
	if (%killdist >= 800)
	{
		%score = (%score + $Score::Kill800Plus);
			
	}				
	else if (%killdist > 500 && %killdist <= 800)
	{
		%score = (%score + $Score::Kill800Meters);
			
	}
	else if (%killdist > 250 && %killdist <= 500)
	{
		%score = (%score + $Score::Kill500Meters);
			
	}
	else if (%killdist > 100 && %killdist <= 250)
	{
		%score = (%score + $Score::Kill250Meters);
			
	}
	else if (%killdist > 50 && %killdist <= 100)
	{
		%score = (%score + $Score::Kill100Meters);
			
	}				
	else if (%killdist > 15 && %killdist <= 50)
	{
		%score = (%score + $Score::Kill50Meters);
			
	}
	else if (%killdist <= 15)
	{
		%score = (%score + $Score::Kill15Meters);
			
	}	

	if (%vertPos == "head" && (%damagetype == $SniperDamageType || %damagetype == $BulletDamageType || %damagetype == $LaserDamageType) )
	{
		%score = %score + $Shifter::HeadShot;
	}

	if (%playerId.driver)
	{
		%score = %score + 3;
	}
	
	if (%damagetype == $NukeTypeDamage || %damagetype == $MortarTypeDamage)
	{
		%score = %score / 2;
	}

	%killtime = getsimtime();
	%killlife = (%killtime - %killerId.spawntime) - $Shifter::KillTime;

	if (%killlife > 0)
	{
		%killscore = floor(%killlife / 180);
		%score += %killscore;
	}

	if(%score == 0) %score++; //Y|yukichigai - no more score-less kills.

	return %score;
}

// ===============================================================================================================
function MatchAssign()
{
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%pl = getClientByIndex(%i);
		%clName = Client::getName(%pl);
		if ($debug) echo($Shifter::tag0 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag0 @ %pl));
      		if ($debug) echo($Shifter::tag1 @ " " @ %clName @ " " @ String::findSubStr(%clName,$Shifter::Tag1 @ %pl));
      		if(String::findSubStr(%clName,$Shifter::Tag0) == 0)
		 {
			//processmenuPickTeam(%pl,0,"");
			GameBase::setTeam(%pl,0);
		 }		
		else if(String::findSubStr(%clName,$Shifter::Tag1) == 0)
		 {
			//processmenuPickTeam(%pl,1,"");
			GameBase::setTeam(%pl, 1);
		 }
		 else 
      			GameBase::setTeam(%pl, -1);
	}
	return;
}
