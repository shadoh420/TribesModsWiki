// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!


function Game::menuRequest(%clientId)
{

	if(%clientId.normal == 0)
		processMenuOptions(%clientId, "Ideal"); //make ideal default menu

   %curItem = 0;
   Client::buildMenu(%clientId, "Options", "options", true);
   if(!$matchStarted || !$Server::TourneyMode)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change Teams/Observe", "changeteams");
   }
   if(%clientId.selClient)
   {
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

      if($curVoteTopic == "" && !%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isAdmin)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
         if(%clientId.isSuperAdmin)
         {
            Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
            Client::addMenuItem(%clientId, %curItem++ @ "Admin " @ %name, "admin " @ %sel);
         }
         Client::addMenuItem(%clientId, %curItem++ @ "Change " @ %name @ "'s team", "fteamchange " @ %sel);
      }
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
      if(%clientId.observerMode == "observerOrbit")
         Client::addMenuItem(%clientId, %curItem++ @ "Observe " @ %name, "observe " @ %sel);
   }
   if($curVoteTopic != "" && %clientId.vote == "")
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   }
   else if($curVoteTopic == "" && !%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
               
      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter FFA mode", "vcffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Vote to start the match", "vsmatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enter Tournament mode", "vctourney");

   }
   else if(%clientId.isAdmin)
   {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      if($Server::TeamDamageScale == 1.0)
         Client::addMenuItem(%clientId, %curItem++ @ "Disable team damage", "dtd");
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Enable team damage", "etd");

      if($Server::TourneyMode)
      {
         Client::addMenuItem(%clientId, %curItem++ @ "Change to FFA mode", "cffa");
         if(!$CountdownStarted && !$matchStarted)
            Client::addMenuItem(%clientId, %curItem++ @ "Start the match", "smatch");
      }
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Change to Tournament mode", "ctourney");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
//mod:
      Client::addMenuItem(%clientId, %curItem++ @ "Ideal Weapon Options", "Ideal");
	if(Player::getArmor(%clientId) == SCVArmor)
		Client::addMenuItem(%clientId, %curItem++ @ "SCV Deployment Options", "SCV");
}

function processMenuOptions(%clientId, %option)
{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);


   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }      
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "observe")
   {
      Observer::setTargetClient(%clientId, %cl);
      return;
   }
   else if(%opt == "Ideal") //mod:
   {
	%clientId.normal = 0;
	Client::buildMenu(%clientId, "Choose a Weapon:", "Weapon", true);
	%i = 0;
	if(Player::getItemCount(%clientId, Blaster))
		Client::addMenuItem(%clientId, %i++ @ "Blaster", "Blaster");
	if(Player::getItemCount(%clientId, PlasmaGun))
		Client::addMenuItem(%clientId, %i++ @ "Plasma Gun", "plasma");
	if(Player::getItemCount(%clientId, DiscLauncher))
		Client::addMenuItem(%clientId, %i++ @ "Disc Launcher", "disclauncher");
	if(Player::getItemCount(%clientId, energyrifle) || Player::getItemCount(%clientId, shortenergyrifle) || Player::getItemCount(%clientId, longenergyrifle))
		Client::addMenuItem(%clientId, %i++ @ "ELF", "elf");
	if(Player::getItemCount(%clientId, GrenadeLauncher))
		Client::addMenuItem(%clientId, %i++ @ "Grenade Launcher", "grenadeL");
	if(Player::getItemCount(%clientId, mortar))
		Client::addMenuItem(%clientId, %i++ @ "Mortar", "mortar");
	if(Player::getItemCount(%clientId, SlowGun))
		Client::addMenuItem(%clientId, %i++ @ "Mass Gun", "mass");
	if(Player::getItemCount(%clientId, concuss))
		Client::addMenuItem(%clientId, %i++ @ "Chaos Gun", "chaos");
	Client::addMenuItem(%clientId, %i++ @ "List all options", "list");
	Client::addMenuItem(%clientId, %i++ @ "Normal Menu", "normal");
	return;
   }
   else if(%opt == "SCV")
   {
	%i = 0;
	Client::buildMenu(%clientId, "Choose Deployable:", "Deployable", true);
	Client::addMenuItem(%clientId, %i++ @ "Dep. Inv. Station", "DeployableInv");
	Client::addMenuItem(%clientId, %i++ @ "Dep. Ammo Station", "DeployableAmmo");
	Client::addMenuItem(%clientId, %i++ @ "Dep. Inv. Station", "DeployableInv");
	Client::addMenuItem(%clientId, %i++ @ "Motion Sensor", "MotionSensor");
	Client::addMenuItem(%clientId, %i++ @ "Pulse Sensor", "PulseSensor");
	Client::addMenuItem(%clientId, %i++ @ "Sensor Jammer", "DeployableSensorJammer");
	Client::addMenuItem(%clientId, %i++ @ "Camera", "Camera");
	Client::addMenuItem(%clientId, %i++ @ "More Options", "More");
	return;
   }

   Game::menuRequest(%clientId);
}

function processMenuWeapon(%clientId, %opt)
{
	if(%opt == "normal")
	{
		%clientId.normal = 1;
		Game::menuRequest(%clientId);
	}
	else if(%opt == "chaos")
	{
		Client::buildMenu(%clientId, "Chaos Gun Ammo", "ChaosGun", true);
	      Client::addMenuItem(%clientId, "1Jitterbug Ammo", "jitterbug");
      	Client::addMenuItem(%clientId, "2Concussion Ammo", "concuss");
	}
	else if(%opt == "elf")
	{
		Client::buildMenu(%clientId, "ELF Style", "ELF", true);
	      Client::addMenuItem(%clientId, "1Short Range/Max. Damage", "short");
	      Client::addMenuItem(%clientId, "2Mid Range/Mid. Damage", "");
	      Client::addMenuItem(%clientId, "3Long Range/Min. Damage", "long");
	}
	else if(%opt == "mortar")
	{
		Client::buildMenu(%clientId, "Mortar Ammo", "Mortar", true);
	      Client::addMenuItem(%clientId, "1Regular Ammo", "");
      	Client::addMenuItem(%clientId, "2EMP Ammo", "emp");
	}
	else if(%opt == "Blaster")
	{
		Client::buildMenu(%clientId, "Blaster", "Blaster", true);
	      Client::addMenuItem(%clientId, "1Regular Fire", 0);
      	Client::addMenuItem(%clientId, "2Overload Capacitor", 1);
	}
	else if(%opt == "mass")
	{
		Client::buildMenu(%clientId, "Mass Gun", "Mass", true);
	      Client::addMenuItem(%clientId, "1Increase Mass (Slow down)", "SlowPod");
      	Client::addMenuItem(%clientId, "2Decrease Mass (Speed up)", "FastPod");
	}
	else if(%opt == "disclauncher")
	{
		Client::buildMenu(%clientId, "Disc Launcher", "disc", true);
	      Client::addMenuItem(%clientId, "1Normal Disc", "Normal");
      	Client::addMenuItem(%clientId, "2Homing Disc (requires 3 shots)", "Homing");
	}
	else if(%opt == "grenadeL")
	{
		Client::buildMenu(%clientId, "Grenade Launcher", "grenadeL", true);
	      Client::addMenuItem(%clientId, "1Normal Grenade", "Grenade");
      	Client::addMenuItem(%clientId, "2ECM Grenades", "ECM");
	}
	else if(%opt == "plasma")
	{
		Client::buildMenu(%clientId, "Plasma Gun", "plasma", true);
	      Client::addMenuItem(%clientId, "1Normal Plasma", "PlasmaBolt");
      	Client::addMenuItem(%clientId, "2Overheated Plasma", "FlamePlasma");
      	Client::addMenuItem(%clientId, "     aka Flamethrower", "FlamePlasma");

	}
	else if(%opt == "list")
	{
		Client::buildMenu(%clientId, "All Weapons", "Weapon", true);
		Client::addMenuItem(%clientId, %i++ @ "Blaster", "Blaster");
		Client::addMenuItem(%clientId, %i++ @ "Plasma Gun", "plasma");
		Client::addMenuItem(%clientId, %i++ @ "Disc Launcher", "disclauncher");
		Client::addMenuItem(%clientId, %i++ @ "ELF", "elf");
		Client::addMenuItem(%clientId, %i++ @ "Grenade Launcher", "grenadeL");
		Client::addMenuItem(%clientId, %i++ @ "Mortar", "mortar");
		Client::addMenuItem(%clientId, %i++ @ "Mass Gun", "mass");
		Client::addMenuItem(%clientId, %i++ @ "Chaos Gun", "chaos");
	}
}

function processMenuChaosGun(%clientId, %opt)
{
	%ammo = %opt @ "shot";
	%clientId.chaosShot = %ammo;
}

function processMenuELF(%clientId, %opt)
{
	%clientId.elfVersion = %opt @ "EnergyRifle";
	if(Player::getItemCount(%clientId, EnergyRifle) != 1) //if you have no regular elf
	{
		if(Player::getItemCount(%clientId, shortEnergyRifle) || Player::getItemCount(%clientId, longEnergyRifle)) //but have another elf
		{
			Player::setItemCount(%clientId, EnergyRifle, 1); //get regular elf so that you can change elf types
			Player::setItemCount(%clientId, shortEnergyRifle, 0); //get rid of these for the inv screens
			Player::setItemCount(%clientId, longEnergyRifle, 0);  //and weapon HUD to show up with just 1 ELF...
		}
	}
	Player::useItem(%clientId, EnergyRifle);
}

function processMenuMortar(%clientId, %opt)
{
	%ammo = %opt @ "MortarShell";
	%clientId.mortarShell = %ammo;
}

function processMenuBlaster(%clientId, %opt)
{
	if(%opt == %clientId.overloadblaster)
	{	
		return;
	}
//so they're changing...
	if(%opt == 0) //turn off overload
		Client::sendMessage(%clientId, 1, "Cooling down blaster... Please Wait.");
	else //turn on
		Client::sendMessage(%clientId, 1, "Overloading Blaster. Ready to fire in 5 seconds" @ "~wshieldhit.wav"); 
	%clientId.overloadblaster = 4;
	schedule("processBlasterPt2(" @ %clientId @ ", " @ %opt @ ");", 5.0, Client::getControlObject(%clientId));
}

function processBlasterPt2(%clientId, %opt)
{
	%clientId.overloadblaster = %opt;

	if(%opt == 0) //turn off overload
		Client::sendMessage(%clientId, 1, "Blaster state has return to normal.");
	else //turn on
		Client::sendMessage(%clientId, 1, "Blaster Overloaded. Ready to fire!" @ "~wshieldhit.wav"); 
}

function processMenuMass(%clientId, %opt)
{
	%clientId.massShot = %opt;
}

function processMenudisc(%clientId, %opt)
{
	if(%clientId.discType == %opt)
		return;

	%ammoCount = Player::getItemCount(%clientId, DiscAmmo);
	if(%opt == "Homing")
		%ammoCount = floor(%ammoCount/3);
	else if(%clientId.discType != "")
		%ammoCount = %ammoCount * 3;

	Player::setItemCount(%clientId, DiscAmmo, %ammoCount);

	%clientId.disctype = %opt;
}

function processMenugrenadeL(%clientId, %opt)
{
	%clientId.grentype = %opt @ "Shell";
}

function processMenuplasma(%clientId, %opt)
{
	if(%clientId.plasmaType == %opt)
		return;

	%ammoCount = Player::getItemCount(%clientId, PlasmaAmmo);
	if(%opt == "FlamePlasma")
		%ammoCount = 5 * %ammoCount;
	else if(%clientId.plasmaType != "")
		%ammoCount = floor(%ammoCount/5);

	Player::setItemCount(%clientId, PlasmaAmmo, %ammoCount);

	%clientId.plasmatype = %opt;
}

function processMenuDeployable(%clientId, %opt)
{
	if(%opt == "More")
	{
		Client::buildMenu(%clientId, "Choose Deployable:", "Deployable", true);
		Client::addMenuItem(%clientId, %i++ @ "Turret", "Turret");
		Client::addMenuItem(%clientId, %i++ @ "Arbitor Device", "ArbitorBox");
		Client::addMenuItem(%clientId, %i++ @ "Nuclear Turret", "NuclearTurret");
		Client::addMenuItem(%clientId, %i++ @ "Obelisk of Light", "Obelisk");
		Client::addMenuItem(%clientId, %i++ @ "Obelisk Power Station", "ObeliskPower");
		Client::addMenuItem(%clientId, %i++ @ "Flame Turret", "FlameTurret");
//		Client::addMenuItem(%clientId, %i++ @ "Super Sensor", "SuperSensor");
		Client::addMenuItem(%clientId, %i++ @ "More Options", "Less");
		return;
	}
	else if(%opt == "Less")
	{
		processMenuOptions(%clientId, "SCV");
		return;
	}

	%clientId.deployable = %opt @ "Pack";
}
