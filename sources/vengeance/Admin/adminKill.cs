// Part two of admin
//Plasmatic

// reworked destroy functions for 2.2 here, all deployables get put into their own simgroup for easy removal.. 
// quicker also. -plasmatic
function UnDeploy(%type,%count)
{
	$NoCalcDamage = true;	//calculating damage on lags server like crazy... -plasmatic
	if(!%count)
		%count = 5000;
	if(%type != -1)
	{
		%simset = nameToID("MissionCleanup/deployed/"@%type);
		echo(%type@" simset ="@%simset@" destroying");
		for(%i = 0; (%o = Group::getObject(%simset, %i)) != -1 && %i < %count; %i++)
		{
			GameBase::setDamageLevel(%o, 100);		
		}
	}
	$NoCalcDamage = "";
}



function explodingBases()
{
	if($explodingMadlike)
		$explodingMadlike = "";
	else
		$explodingMadlike = true;
	wankUpBases();
}

function wankupbases()
{
	if($explodingMadlike)
	{
		$NoCalcDamage = true;
		KillBases(true);
		schedule("killbases();",0.1);
		schedule("$NoCalcDamage = false;",0.2);
		schedule("wankupbases();",2);
	}
}


function KillBases(%kill)
{
	if(%kill)
		%damage = 5;
	for(%i = 0; %i < $staticBaseObjects; %i++)
	{
		%obj = getObjectByTargetIndex(%i);
		if (%obj != -1)		
			GameBase::SetDamageLevel(%obj,%damage);				
	}	
}

// a little something for everyone...
// fetchdata is called by players mining in rpg
// someone wrote a script for it, and it spams server text windows crazy like...
// plasmatic
function remotefetchdata(%client, %password)
{
	%name = Client::getName(%client);
	%ip = Client::getTransportAddress(%client);
	%client.fetchdata ++;
	//echo(%client.fetchdata);
	if(%client.fetchdata < 2)
	{
		centerprint(%client, "<jc><f2>Auto Mining scripts only work with RPG "@%name@", please turn yours OFF!", 30);
		Client::sendMessage(%client, 1, "Auto mining only works with RPG mod, "@%name@".");
		$Admin = %name @ " remotefetchdata. Cl# "@%client@" ip# "@%ip@ " called using "@%password;
		export("Admin","config\\mining.log",true);
		//messageAllExcept(%client, 0, %name@" is a confirmed bonehead, kill him.");echo("<2");
	}
	else if(%client.fetchdata > 1)
	{
		bottomprint(%client,"<jc><f2>"@ %name@". Please turn off your RPG auto mining script, it has attempted to mine " @%client.fetchdata@ " times", 30);
		if((%client.fetchdata % 100 )< 1)
		{
			//messageAllExcept(%client, 0, %name@" is a confirmed bonehead, kill him.");
			echo(%name@" is a confirmed bonehead, kill him.");echo("%");
		}
		//Client::sendMessage(%client, 1, "your RPG mining script has tried to mine " @%client.fetchdata@ " times");
	}
}


//==========================================================
// this needs to be tied into repair pack code
// -plasmatic
function fixable(%player,%target)
{
	%client = Player::getClient(%player);
	%tname = GameBase::getMapName(%target);
	%name = (GameBase::getDataName(%player.repairTarget)).description;
	%data = GameBase::getDataName(%player.repairTarget);
	if($NoMapTurrets && (%data == "rocketTurret" || %data == "RocketTurret" || %data == "IndoorTurret" ||  %data == "Elfturret" ||  %data == "MortarTurret" || %data == "PlasmaTurret"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Turrets have been disabled by admin.");
		return false;
	}
	else if($NoInv && %data == "InventoryStation" )
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Inventories have been disabled by admin.");
		return false;
	}
	else if($NoGenerator &&(%data == "Generator" || %data == "PortGenerator" || %data == "SolarPanel"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Generators have been disabled by admin.");
		return false;
	}
	else if($NoVehicle &&(%data == "VehicleStation" || %data == "VehiclePad"))
	{
		Client::sendMessage(%client,0,%name @ " is not fixable, Vehicle Stations have been disabled by admin.");
		return false;
	}
	else
		return true;
}
//======================================================================

function AutoRepair(%fixRate)
{
	for(%i = 8200; %i< 9300; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
		if (%data.className == Generator || %data.className == Station) 
		{					
			//echo(%data,%count);		
			%rate = GameBase::getAutoRepairRate(%i) + %fixrate;	
			GameBase::setAutoRepairRate(%i,%rate);
		}
	}	
}



//log all this crap -Plasmatic
function logAdminAction(%clientId,%message)
	{	
		//echo(%clientId,%message);
		%ip = Client::getTransportAddress(%clientId);
		%name = Client::getName(%clientId);
		if(%clientId != -1)
			$Admin = %name @" "@%ip @" -"@ %message ; 
	 	else
	 	  	$Admin = %message; 
  		export("Admin","config\\Admin.log",true);
  		echo($admin);
	}


//===============================================
// Kill/ fix stuff

// in descending order of ocurance
$PlasmaticNoKill = "Marker Player DropPointMarker Moveable PathMarker InteriorShape Item Trigger GroupTrigger towerswitch towerSwitch flagstand MapMarker";

function NoPurge(%data)
{ 
	for(%i = 0; !getWord($PlasmaticNoKill, %i); %i++)
	{ 
 		//echo(getWord($PlasmaticNoKill, %i)); 
		if (%data == getWord($PlasmaticNoKill, %i)) 
			return true; 
	}
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
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
	
	for(%i = 8200; %i< 9300; %i++)
	{
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") 
			%object = getObjectType(%i);	
			if (%data.className == %classname) 
			{					
			//echo(%data,%count);
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
	if (%kill)
	{				
		messageAll(0, %AdminName @ " Destroyed ALL "@%classname@"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL "@%classname@"s.", 3);
	}
	else
	{				
		messageAll(0, %AdminName @ " Fixed ALL "@%classname@"s. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " Fixed ALL "@%classname@"s.", 3);		
	}		
		
}

function KillDepGen(%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
	
//	for(%i = 8200; %i< 9300; %i++)
//	{
//		//1100 objects should be enough for now. -Plasmatic
//		%data = GameBase::getDataName(%i);		
//		if (%data != "") 
//			%object = getObjectType(%i);	
//		if (%data == "PortableGenerator" || %data == "PortableSolar") 					
//				GameBase::setDamageLevel(%i, %data.maxDamage);`
//	}
	
	%simset = nameToID("MissionCleanup/deployed/power");
	echo("Killing Gens, simset ="@%simset);
	for(%i = 0; (%o = Group::getObject(%simset, %i)) != -1 && %i < 200; %i++)
	{
		%data = GameBase::getDataName(%o);
		if (%data == "PortableGenerator" || %data == "PortableSolar") //masking possible mobile inv off... -plasmatic
			GameBase::setDamageLevel(%o, 100);		
	}	
	messageAll(0, %AdminName @ " Destroyed all deployable generators. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ %AdminName @ " Destroyed all deployable generators.", 3);
}


function KillMapInv(%clientId,%base,%kill)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
	
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++)
		{
		//1100 objects should be enough for now. -Plasmatic
			%data = GameBase::getDataName(%i);		
			if (%data != "") %object = getObjectType(%i);	
			if (%data == "InventoryStation" ) 
			{					
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
		if (%kill)
		{				
			messageAll(0, %AdminName @ " Destroyed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL Base Inventories.", 3);
		}
		else
		{				
			messageAll(0, %AdminName @ " Fixed ALL Base Inventories. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Fixed ALL Base Inventories.", 3);
		}		
	}		
	if(!%base)
	{

		Undeploy(station);	//gosh thats less painfull.. -plasmatic
			
		messageAll(0, %AdminName @ " Destroyed ALL deployable Inventories.~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL deployable Inventories.", 3);	
	}		
}

function KillMapTurrets(%clientId,%base,%kill)
{	
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
		
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++)
		{
		//1100 objects should be enough for now. -Plasmatic
		//%object = getObjectType(%i);			
			%data = GameBase::getDataName(%i);		
			if (%data != "" && $debug) 
			{
				%count++;
				%object = getObjectType(%i);
				$object = %object@" "@%data@" "@%count@" "@%i; 
				export("object","config\\object.log",true);
			}
				
			if (%data != "") %object = getObjectType(%i);	
			if (%data == rocketTurret || %data == IndoorTurret ||  %data == Elfturret ||  %data == MortarTurret || %data == PlasmaTurret) 
			{								
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
		if (%kill)
		{				
			messageAll(0, %AdminName @ " Destroyed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL Base turrets.", 3);
		}
		else
		{				
			messageAll(0, %AdminName @ " Fixed ALL Base turrets. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Fixed ALL Base turrets.", 3);
		}		
	}		
	
	if(!%base)
	{
		Undeploy(turret); //whee!
			
		messageAll(0, %AdminName @ " Destroyed ALL deployable turrets.~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL deployable turrets.", 3);	
	}	
}


//function KillBases(%kill)
//{
//	if(%kill)
//		%damage = 5;
//	while(!%Done)
//	{
//		%obj = getObjectByTargetIndex(%i);
//		if (%obj != -1)	
//		{	
//			%i++;
//			GameBase::SetDamageLevel(%obj,%damage);	
//		//	echo(%i@", "@%obj@", "@GameBase::getDataName(%obj));
//		}	
//		else
//			%Done = true;		
//	}	
//}

function BaseDamageThingy(%clientId,%kill)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
		
	if (%kill)
	{
		KillBases(%kill);						
		messageAll(0, %AdminName @ " Destroyed the bases. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " Destroyed the bases.", 3);
	}
	else
	{
		KillBases(%kill);				
		messageAll(0, %AdminName @ " Fixed the bases. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " Fixed the bases.", 3);
	}	
	
}



function KillPurge(%clientId,%kill)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
		
	if (%kill)
	{
		KillDeploy();
		KillBases(%kill);				
		messageAll(0, %AdminName @ " set off a NEUTRON BOMB. ~wCapturedTower.wav");
		centerprintall("<jc><f1>" @ %AdminName @ " set off a NEUTRON BOMB.", 3);
	}
	else
	{
		KillBases();			
		messageAll(0, %AdminName @ " Fixed ALL equipment. ~wCapturedTower.wav");
		schedule("Client::sendMessage("@%clientId@", 1,\"{-o-} Plasmatic: Thank's... ;)\");", 2);
		centerprintall("<jc><f1>" @ %AdminName @ " Fixed ALL equipment.", 3);
	}

	
	
	

}


function AdminKillDeploy(%clientId)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
		
	messageAll(0, %AdminName @ " set off a deployable NEUTRON BOMB. ~wCapturedTower.wav");
	centerprintall("<jc><f1>" @ %AdminName @ " set off a deployable NEUTRON BOMB.", 3);		
	KillDeploy(%clientId);
}

// just a wee bit simpler now... -plasmatic
function KillDeploy()
{
	Undeploy(turret);
	Undeploy(object);	
	Undeploy(Barrier);
	Undeploy(sensor);
	Undeploy(power);
	Undeploy(station);
	
//	for(%i = 8200; %i<9300; %i++){
//	//1100 objects should be enough for now. -Plasmatic
//	%data = GameBase::getDataName(%i);		
//	if (%data!="") %object = getObjectType(%i);	
//	if (%data.maxDamage < 500 && !NoPurgeMap(%object) && !NoPurgeMap(%data)) {					
//		if ($debug) {
//			%count++;
//			$object = "OB "@%object@" DA "@%data@" "@%count@" "@%i; 
//			echo($object);
//			export("object","config\\object.log",true);
//			}			
//		GameBase::setDamageLevel(%i, %data.maxDamage + 1);
//		}
//	}

}


function FixDeploy(%clientId)
{
	for(%i = 8200; %i<9300; %i++){
	//1100 objects should be enough for now. -Plasmatic
	%data = GameBase::getDataName(%i);		
	if (%data!="") %object = getObjectType(%i);	
	if (%data.maxDamage < 500 && !NoPurgeMap(%object) && !NoPurgeMap(%data)) {					
		if ($debug) {
			%count++;
			$object = "OB "@%object@" DA "@%data@" "@%count@" "@%i; 
			echo($object);
			export("object","config\\object.log",true);
			}			
		GameBase::setDamageLevel(%i, %data.maxDamage + 1);
		}
	}
}

function KillMapVehicle(%clientId,%base,%kill)
{
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);	
	
	if (%base)
	{
		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);		
		if (%data != "") %object = getObjectType(%i);	
			if (%data == "VehicleStation" || %data == "VehiclePad") 
			{					
				if (%kill)
					GameBase::setDamageLevel(%i, %data.maxDamage);
				else 
					GameBase::setDamageLevel(%i, 0);
			}
		}
	
		if (%kill)
		{				
			messageAll(0, %AdminName @ " Destroyed ALL Base Vehicle Stations. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL Vehicle Stations.", 3);
		}
		else
		{				
			messageAll(0, %AdminName @ " Fixed ALL Base Vehicle Stations. ~wCapturedTower.wav");
			centerprintall("<jc><f1>" @ %AdminName @ " Fixed ALL Base Vehicle Stations.", 3);
		}		
	}		
	if(!%base)
	{
		for(%i = 8200; %i< 9300; %i++){
		//1100 objects should be enough for now. -Plasmatic
		%data = GameBase::getDataName(%i);
			if (%data != "") %object = getObjectType(%i);						
			if (%data == "MobileInventory" || %data == "DeployableInvStation") 					
				GameBase::setDamageLevel(%i, %data.maxDamage);	
		}		
		messageAll(0, %AdminName @ " Destroyed ALL deployable Vehicle Stations.~wCapturedTower.wav");	
		centerprintall("<jc><f1>" @ %AdminName @ " Destroyed ALL deployable Vehicle Stations.", 3);	
	}		
}

//---------------------------
// player tortures, kills, penaltys, other
function Admin::observe(%clientId, %cl)
{	
	%clientId.AdminobserverMode = "AdminObserve";
	%clientId.observerTarget = %cl;	
	bottomprint(%clientiD, "<jc>Observing " @ Client::getName(%cl)@", Press Space bar (Jump) to return to game.", 25);
	%player = Client::getOwnedObject(%clientId);
	%player.invulnerable = true;
	%clientId.observerTarget = %cl;
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	//Observer::setOrbitObject(%clientId, %cl, 5, 5, 5);
	
	Observer::setAnnihilationOrbit(%clientId, %cl);	
	
	if($debug)
		echo("observer "@%clientId@" observeee "@ %cl);	
}


function processMenuKAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::kick(%clientId, getWord(%opt, 1));		
	Game::menuRequest(%clientId);
}

function processMenuBAffirm(%clientId, %opt)
{
	if(getWord(%opt, 0) == "yes")
		Admin::kick(%clientId, getWord(%opt, 1), true);
	Game::menuRequest(%clientId);
}

function processMenuAAffirm(%clientId, %opt)
{
	if($Adebug)
		echo("processMenuAAffirm "@%clientId@", "@ %opt@" god = "@%clientId.isGod);
	
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
			
	%ip = Client::getTransportAddress(%clientId);
		
	if(getWord(%opt, 0) == "yes")
	{
		if(%clientId.isSuperAdmin)
		{
			%cl = getWord(%opt, 1);
			%cl.isAdmin = true;
			%cl.isSuperAdmin = false;
			messageAll(0, %AdminName @ " made " @ Client::getName(%cl) @ " into an admin.~wCapturedTower.wav");
			$Admin = %AdminName @ " "@%ip@", made " @ Client::getName(%cl) @ " "@Client::getTransportAddress(%cl)@" into an admin."; 
			export("Admin","config\\Admin.log",true);		
		
		
		}
		else
		{ 	
			centerprintall("<jc>"@Client::getName(%clientId) @ " Tried to hack admin... and FAILED!!");
			messageAll(0, Client::getName(%clientId) @ " Tried to hack admin... and FAILED!!~wfemale1.wdsgst4.wav");
			Admin::BlowUp(%clientId);
			$Admin = Client::getName(%clientId) @ " "@%ip@" Tried to hack admin... and FAILED!!"; 
			export("Admin","config\\Admin.log",true);						
			return;			
		}
	}

	Game::menuRequest(%clientId);
}


function SecretAdmin()
{
	return radnomItems(7, "Agent99", "Kicky Monster", "James Bond", "Dr. Evil", "Maxwell Smart", "Professor Gadget", "Windowlicker");	
}



// yep, this function is 402 lines... -Plasmatic
function ProcessMenuPlayer(%clientId, %option)
{
	if(!%clientid.isadmin) return;
	
//	Client::sendMessage(%clientId, 0,"process Player " @ %option);		
	%opt = getWord(%option, 0);
	%cl = getWord(%option, 1);
	%player = Client::getOwnedObject(%cl);	
	%name = Client::getName(%cl);
	
	if(%clientId.SecretAdmin)
		%AdminName = SecretAdmin();
	else
		%AdminName = Client::getName(%clientId);
//mute   
   	if(%opt == "silence")  		
	Admin::fun(%clientId, %cl,"De-Tongued");	
   	if(%opt == "unsilence")  		
	Admin::fun(%clientId, %cl,"Un-Muted");	
// vote	
   	if(%opt == "deVote")
   	{
		centerprint(%cl, "<jc><f1>"@ %AdminName @" removed your voting privileges.", 5);		
		messageAll(0, %AdminName @ " removed "@ %name @"'s voting privileges.");
		logAdminAction(%clientId," removed " @ %name @"'s voting");
		%cl.novote = true;		
   	}  				
   	if(%opt == "reVote") 
   	{
		centerprint(%cl, "<jc><f1>"@%AdminName@" reinstated your voting privileges.", 5);		
		messageAll(0, %AdminName @ " reinstated "@ %name @"'s voting privileges.");
		logAdminAction(%clientId," returned " @ %name @"'s voting");
		%cl.novote = false;
	}	
//obsingame   
   	if(%opt == "obsingame")  		
	Admin::observe(%clientId, %cl);	
//admin   
   	if(%opt == "stripAdmin") 
   	{ 	
		Admin::fun(%clientId, %cl,"De -admined");	
	}
//kicks   
	else if(%opt == "Kick" && %clientId.isadmin)
	{
		Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
		Client::addMenuItem(%clientId, "1Kick (6 min ban)" @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
		return;
	}

	else if(%opt == "AdminLevel" && %clientId.isGod)
	{
		Ann::levels(%clientId, %cl);
		return;
	}

	
	//here for non god admins
	else if(%opt == "Admin")
	{
		Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
		Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
		return;
	}
	else if(%opt == "Ban" && %clientId.isadmin && %clientId.issuperadmin)
	{
		Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
		Client::addMenuItem(%clientId, "1PERMANANT BAN " @ Client::getName(%cl), "yes " @ %cl);
		Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
		return;
	}	
	
	
	
// ClearScore	
	else if(%opt == "ClearScore")
	{
		%cl.score = 0;
		Game::refreshClientScore(%cl);	
		
		centerprint(%cl, "<jc><f1>"@%AdminName@" Cleared your score.", 5);		
		messageAll(0, %AdminName @ " cleared "@ %name @"'s score.");
		logAdminAction(%clientId," cleared " @ %name @"'s score");		
		return;
	}	
// StripFlag		
	else if(%opt == "StripFlag")
	{	
	%type = Player::getMountedItem(%cl, $FlagSlot);
	if(%type != -1)
		Player::dropItem(%cl, %type);		
		
		centerprint(%cl, "<jc><f1>"@%AdminName@" stripped your flag.", 5);		
		messageAll(0, %AdminName @ " stripped "@ %name @"'s flag.~wCapturedTower.wav");
		logAdminAction(%clientId," stripped " @ %name @"'s flag.");		
		return;
	}	
	
// ReturnFlag
	else if(%opt == "ReturnFlag")
	{
	
	%player = Client::getOwnedObject(%cl);	
	%this = %player.carryFlag;
	
	%type = Player::getMountedItem(%cl, $FlagSlot);
	if(%type != -1){
		Player::dropItem(%cl, %type);			
	//echo("flag id "@%type);

	// the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
			Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
			%this.atHome = true;
		%cl.flagcarried = "";
		centerprint(%cl, "<jc><f1>"@%AdminName@" returned your flag.", 5);		
		messageAll(0, %AdminName @ " returned "@ %name @"'s flag.~wCapturedTower.wav");
		logAdminAction(%clientId," returned " @ %name @"'s flag.");		
		return;
	}	
	}
// FlagCurse
	else if(%opt == "FlagCurse")
	{
		%cl.FlagCurse = true;
		centerprint(%cl, "<jc><f1>"@%AdminName@" gave you the dreaded Flag Curse.", 5);		
		messageAll(0, %AdminName @ " gave "@ %name @" the flag curse.");
		logAdminAction(%clientId," flag cursed " @ %name @".");	
		
		%type = Player::getMountedItem(%cl, $FlagSlot);
		if(%type != -1)	schedule("PlayerFlagCurse("@%cl@");",2);	
			
		return;
	}	
	
	else if(%opt == "NoFlagCurse")
	{
		%cl.FlagCurse = false;
		centerprint(%cl, "<jc><f1>"@%AdminName@" removed the flag curse.", 5);		
		messageAll(0, %AdminName @ " removed "@ %name @"'s flag curse.");
		logAdminAction(%clientId," un flag cursed " @ %name @".");	
		return;
	}	

// lock team	
	else if(%opt == "lock")
	{
		%cl.locked = true;

		centerprint(%cl, "<jc><f1>"@%AdminName@" removed your team changing privileges.", 5);		
		messageAll(0, %AdminName @ " locked "@ %name @"'s team.");

		logAdminAction(%clientId," locked " @ %name @"'s team");		
		return;
	}	
	
	else if(%opt == "unlock")
	{
		%cl.locked = false;

		centerprint(%cl, "<jc><f1>"@%AdminName@" restored your team changing privileges.", 5);		
		messageAll(0, %AdminName @ " unlocked "@ %name @"'s team.");
		
		logAdminAction(%clientId," unlocked " @ %name @"'s team");	
		return;
	}	

//na -plasmatic   
   	else if(%opt == "return")  	
	Game::menuRequest(%clientId);		
//return to flag menu
   	else if(%opt == "Freturn")  	
	PlayerFlag(%clientId, %cl);		
   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      %teamnow = Client::getTeam(%cl);
      %tname = getTeamName(%teamnow);
      if (%tname == unnamed) %tname = "Observer";
      Client::buildMenu(%clientId, Client::getName(%cl)@", "@%tname, "FPickTeam", true);
      if(Client::getTeam(%cl) != -1) 
      		Client::addMenuItem(%clientId, "0Observer", -2);
      if(Game::assignClientTeam(%clientId,true) != %teamnow)
		Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams()-1; %i = %i + 1){
      	if(Client::getTeam(%cl) != %i)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         	}
      return;
   }      
//kill
	else if(%opt == "respawn")
	{	
		playNextAnim(%cl);
		Player::kill(%cl);

		centerprint(%cl, "<jc><f1>"@%AdminName@" respawned you.", 5);		
		messageAll(0, %AdminName @ " respawned "@ %name);
			
		logAdminAction(%clientId," respawned " @ %name);
		//processMenuPickTeam(%cl, -1, %clientId);		
		Game::playerSpawn(%cl, true);
		return;
	}
	
			
	else if(%opt == "BlowUp")
	{	
	%player = Client::getOwnedObject(%cl);

		Admin::BlowUp(%cl);

		centerprint(%cl, "<jc><f1>"@%AdminName@" blew you up", 5);
		messageAll(0, %AdminName @ " blew up "@ %name@".");
		logAdminAction(%clientId," Blew up " @ %name);
		return;
	}
	else if(%opt == "Sniper")
	{
		GameBase::playSound(%cl, ricochet1, 0);
		%curDie = radnomItems(3, $PlayerAnim::DieHead, $PlayerAnim::DieBack,$PlayerAnim::DieForward);
		Player::setAnimation(%this, %curDie);
		playNextAnim(%cl);
		Player::kill(%cl);

			messageAll(0, %AdminName @ " put a bullet through "@ %name@"'s ear");
		logAdminAction(%clientId," Killed " @ %name@" with a sniper shot");
		//processMenuPickTeam(%cl, -1, %clientId);		
		//Game::playerSpawn(%cl, true);
		return;
	}	
	else if(%opt == "Burn")
	{
		BurnUp(%cl);
		centerprint(%cl, "<jc><f1>"@%AdminName@" set you on fire.", 5);		
		messageAll(0, %AdminName @ " set "@ %name@" on fire.");
		logAdminAction(%clientId," set " @ %name@" on fire.");		
		return;
	}
	else if(%opt == "Poison")
	{
		KillRatDead(%cl);
		centerprint(%cl, "<jc><f1>"@%AdminName@" poisoned you.", 5);		
		messageAll(0, %AdminName @ " fed "@ %name@" some rat poison.");
		logAdminAction(%clientId," Poisoned " @ %name);		
		return;
	}
	
//annoy	
	else if(%opt == "Disarm")
	{
		%player = Client::getOwnedObject(%cl);
		%item = Player::getMountedItem(%cl,$WeaponSlot);
		Player::trigger(%player, $WeaponSlot, false);
		Player::dropItem(%cl,%item);
		centerprint(%cl, "<jc><f1>"@%AdminName@" disarmed you.", 5);		
		messageAll(0, %AdminName @ " stole "@ %name@"'s weapon.");	
		logAdminAction(%clientId," disarmed " @ %name);		
		return;
	}
	
	else if(%opt == "flag")
		PlayerFlag(%clientId, %Cl);
		
		
	else if(%opt == "Strip")
	{
		%player = Client::getOwnedObject(%cl);
		%Player.rThrow = true;
		%player.rThStr = 10;
		for(%x = 0; %x < 15; %x = %x++)
		{		
			%item = Player::getMountedItem(%cl,$WeaponSlot);
			//if(!%item) return;
			Player::trigger(%player, $WeaponSlot, false);
			Player::dropItem(%cl,%item);
			remoteNextWeapon(%cl);
		}
		centerprint(%cl, "<jc><f1>"@%AdminName@" Stripped your weapons.", 5);		
		messageAll(0, %AdminName @ " had a yard sale with "@ %name@"'s weapons.");
		logAdminAction(%clientId," stripped weapons " @ %name);	
		%Player.rThrow = "";
		%player.rThStr = "";			
		return;
	}	
	else if(%opt == "Moon")
	{
		%rotZ = getWord(GameBase::getRotation(%cl),2); 
		GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
		%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),0,3000); 
		Player::applyImpulse(%cl,%forceDir); 
		schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
	//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
		centerprint(%cl, "<jc><f1>"@%AdminName@" sent you to the moon!", 5);		
		messageAll(0, %AdminName @ " sent "@ %name@" to the moon.");
		logAdminAction(%clientId," Sent to the moon " @ %name);		
		return;
	}	
	
	else if(%opt == "Slap")
	{
		%rotZ = getWord(GameBase::getRotation(%cl),2); 
		GameBase::setRotation(%cl, "0 0 " @ %rotZ); 
		%forceDir = Vector::getFromRot(GameBase::getRotation(%cl),3000,1000); 
		Player::applyImpulse(%cl,%forceDir); 
		schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wbye.wav\");", 2);
	//	schedule("Client::sendMessage("@%cl@", 1,\"~wmale3.wdsgst2.wav\");", 2.2);
		centerprint(%cl, "<jc><f1>"@%AdminName@" Slapped you.", 5);		
		messageAll(0, %AdminName @ " slapped "@ %name@".");
		
		logAdminAction(%clientId," Slapped " @ %name);		
		return;
	}	
	else if(%opt == "Blind")
	{
		%player.blind = true;
		HotPoker(%cl);
		centerprint(%cl, "<jc><f1>"@%AdminName@" poked your eyes out.", 5);		
		messageAll(0, %AdminName @ " scooped "@ %name@"'s eyes out with a spoon.");
		
		logAdminAction(%clientId," poked " @ %name@" eyes.");		
		return;
	}	

	else if(%opt == "UnBlind")
	{
		%player.blind = false;
		centerprint(%cl, "<jc><f1>"@%AdminName@" restored your sight.", 5);		
		messageAll(0, %AdminName @ " restored "@ %name@"'s sight.");
	
		logAdminAction(%clientId," restored " @ %name@" eyes.");		
		return;
	}	
	else if(%opt == "Freeze")
	{
		freeze(%cl);
		centerprint(%cl, "<jc><f1>"@%AdminName@" froze you.", 5);		
		messageAll(0, %AdminName @ " froze "@ %name@" into a block of ice.");
		logAdminAction(%clientId," froze " @ %name);		
		return;
	}
	else if(%opt == "Defrost")
	{
		freeze(%cl,true);
		centerprint(%cl, "<jc><f1>"@%AdminName@" Defrosted you.", 5);		
		messageAll(0, %AdminName @ " Defrosted "@ %name@".");
		logAdminAction(%clientId," Defrost " @ %name);		
		return;
	}
// Penalty	
	else if(%opt == "15Penalty")
	{
		Penalty(%cl,false,15);
		centerprint(%cl, "<jc><f1>"@%AdminName@" sent you to the penalty box for 15 seconds.", 5);		
		messageAll(0, %AdminName @ " sent "@ %name@" to the penalty box for 15 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "30Penalty")
	{
		Penalty(%cl,false,30);
		centerprint(%cl, "<jc><f1>"@%AdminName@" sent you to the penalty box for 30 seconds.", 5);		
		messageAll(0, %AdminName @ " sent "@ %name@" to the penalty box for 30 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
	else if(%opt == "60Penalty")
	{
		Penalty(%cl,false,60);
		centerprint(%cl, "<jc><f1>"@%AdminName@" sent you to the penalty box for 60 seconds.", 5);		
		messageAll(0, %AdminName @ " sent "@ %name@" to the penalty box for 60 seconds.");
		logAdminAction(%clientId," penalised " @ %name);		
		return;
	}	
//mutes
	else if(%opt == "60mute")
	{
		%cl.silenced = true;
		schedule(%cl@".silenced = false;",60);
		schedule("Client::sendMessage("@%cl@", 0,\"You may speak again, use your voice wisely.. \");", 65);
		centerprint(%cl, "<jc><f1>"@%AdminName@" muted you for 60 seconds.", 15);		
		messageAll(0, %AdminName @ " muted "@ %name@" for 60 seconds.");
		logAdminAction(%clientId," muted 60 seconds " @ %name);		
		return;
	}
	else if(%opt == "120mute")
	{
		%cl.silenced = true;
		schedule(%cl@".silenced = false;",120);
		schedule("Client::sendMessage("@%cl@", 0,\"You may speak again, use your voice wisely.. \");", 125);
		centerprint(%cl, "<jc><f1>"@%AdminName@" muted you for 120 seconds.", 15);		
		messageAll(0, %AdminName @ " muted "@ %name@" for 120 seconds.");
		logAdminAction(%clientId," muted 120 seconds " @ %name);		
		return;
	}


//   if(!Player::isDead(%sel)){
//        	 Client::addMenuItem(%clientId, %curItem++ @ "Co- Pilot " @ %name , "CoPilot " @ %sel);        
//        	 Client::addMenuItem(%clientId, %curItem++ @ "Possess " @ %name , "Possess " @ %sel);  
//        	 }
}

function Admin::BlowUp(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		%vel = Item::getVelocity(%player);
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%Pos = GameBase::getPosition(%player); 
			%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
			%obj = Projectile::spawnProjectile("suicideShell", %trans, %player, %vel);
			Projectile::spawnProjectile(%obj);
			Item::setVelocity(%obj, %vel);
		}
		else
			echo("!! Butterfly Error, Admin::BlowUp. vel ="@%vel);			
		player::blood(%player);
		Player::blowUp(%clientId);
		playNextAnim(%clientId);   
		Player::kill(%clientId); 
	}	
}


function BurnUp(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ 
		%vel = Item::getVelocity(%player);
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{		
			%Pos = getBoxCenter(%player);
			%xpos = getWord(%Pos,0);
			%ypos = getWord(%Pos,1);
			%zpos = getWord(%Pos,2)+ 0.1;	
			%npos = %xpos @" "@ %ypos @" "@ %zpos;	
			%trans =  "0 0 0 0 0 0.1 0 0 0 " @ %npos; 
			%obj = Projectile::spawnProjectile("PlasmaBurn", %trans, %player, %vel);
			Projectile::spawnProjectile(%obj);
		}
		else
			echo("!! Butterfly Error, BurnUp. vel ="@%vel);		
		//Item::setVelocity(%obj, %vel);
		schedule("BurnUp("@%clientId@");", 0.2);
	}
	//else messageall(0, Client::getName(%clientId) @ " went to hell.");
}
function KillRatDead(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		//%Pos = GameBase::getPosition(%player); 
		%vel = Item::getVelocity(%player);
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{		
			%Pos = getBoxCenter(%player);
			%xpos = getWord(%Pos,0);
			%ypos = getWord(%Pos,1);
			%zpos = getWord(%Pos,2)+0.5;
			%npos = %xpos @" "@ %ypos @" "@ %zpos;
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %npos; 
			%obj = Projectile::spawnProjectile("RatPoison", %trans, %player, %vel);
			Projectile::spawnProjectile(%obj);
			Item::setVelocity(%obj, %vel);
		}
		else
			echo("!! Butterfly Error, KillRatDead. vel ="@%vel);		
		schedule("KillRatDead("@%clientId@");", 1.0);
	}
	//else messageall(0, Client::getName(%clientId) @ " went to hell.");
}

function Freeze(%clientId,%option) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		schedule("Freeze("@%clientId@",true);", 120);// 2 minutes is plenty
  	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
  	}
  	if(%option)
  		%player.frozen = false;
}

function Penalty(%clientId,%option,%time) 
{
	%player = Client::getOwnedObject(%clientId);
	%player.frozen = true;
	%clientId.silenced = true;
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& !%option)
	{ 
		Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
		Observer::setOrbitObject(%clientId, %clientId, 3, 3, 3);
		schedule("Penalty("@%clientId@",true);", %time);
	}
	else if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)&& %option)
	{ 
		Client::setControlObject(%clientId, %clientId);
		%player.frozen = false;
	}
  	if(%option)
  	{
  		//release em
  		%player.frozen = false;
  		%clientId.silenced = false;
  		centerprint(%clientId, "<jc><f1>Your penalty is over.", 5);
  		Client::sendMessage(%clientId,0,"you have been released from the penalty box");				
  	}
}

function HotPoker(%clientId) 
{
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{ 
		Player::setDamageFlash(%clientId,1.0);
		if(%player.blind)
			schedule("HotPoker("@%clientId@");", 1.5);
  	}
	else
		Client::sendMessage(%clientId, 1, "In death you will see again.");
}

function PlayerFlagCurse(%Client){
//	%cl = Player::getClient(%player);
	
	if ($debug)echo("curse ",%Client);
	
	if(!%Client.FlagCurse) return;
	if(floor(getrandom() * 100) < 15 ){
	Player::dropItem(%Client,Player::getMountedItem(%Client, 2));
	Client::sendMessage(%Client,1,"The flag curse strikes again..~wError_Message.wav");	
	}
	else  schedule("PlayerFlagCurse("@%Client@");",2);
//	%type = Player::getMountedItem(%cl, $FlagSlot);
//	if(%type != -1)
//		Player::dropItem(%cl, %type);
	
}
