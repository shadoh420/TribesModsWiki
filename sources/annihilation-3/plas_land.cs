//fixed for Annihilation Mod here -Plasmatic
function Game::playerSpawn(%clientId, %respawn)
{
	if(!$ghosting)
		return false;

	%clientId.cankillbot = "true";

	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn || !%clientId.pickedSpawn)
	{
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 0);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Hi, " @ Client::getName(%clientId) @ "!\", 4);", 0);
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 3);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Welcome to Plasmatic Land!\", 4);", 3);
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 6);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>The Object: Build defence for your flag!\", 4);", 6);
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 9);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>First you will need to decide where to start!\", 5);", 9);
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 13);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1 Hit your Beacon key (B key) to set your spawn point.\", 4);", 13);
		schedule("Client::sendMessage(" @ %clientId @ ", 1,\"~wshell_click.wav\");", 16);
		schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Once you pick a spawn point (Beacon Key) you can start!\", 4);", 16);
	}
	if(%spawnMarker) {   
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

	%mod = getWord($modlist, 0);
	//echo("mod = "@%mod);
	if(%mod == "Annihilation")
	{
		//echo("found annihilation mod");
		%armor = $DefaultArmor[Client::getGender(%clientId)];
	}
	else
	{	
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      		%armor = "larmor";
		else
			%armor = "lfemale";
	}
	      
	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
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
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}
function Game::playerSpawned(%pl, %clientId, %armor)
{
	// hard coded here -plasmatic
	
	schedule("Client::clearItemShopping("@%clientId@");",1);
	
	if($Annihilation::UsePersonalSkin)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]);
	else Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
	
	client::setSkin(%clientId, "green");	//Driving out all the snakes for St Patricks day!
	
	if(%clientId.pickedSpawn)
	{
		Annihilation::setItemCount(%clientId, iarmorWarrior, 1);	
		Annihilation::setItemCount(%clientId, DiscLauncher, 1);
		Annihilation::setItemCount(%clientId, PlasmaGun, 1);
		Annihilation::setItemCount(%clientId, Shotgun, 1);
		Annihilation::setItemCount(%clientId, TargetingLaser, 1);
		   
		Annihilation::setItemCount(%clientId, discammo, 30);		   
		Annihilation::setItemCount(%clientId, PlasmaAmmo, 30);	  
		Annihilation::setItemCount(%clientId, ShotgunShells, 30);
		   
		Annihilation::setItemCount(%clientId, RepairKit, 1);
		Annihilation::setItemCount(%clientId, Beacon, 5);
		Annihilation::setItemCount(%clientId, Grenade, 8);	   
		Annihilation::setItemCount(%clientId, MineAmmo, 3);
		   	   
		Annihilation::setItemCount(%clientId, EnergyPack, 1);
		Player::useItem(%pl,EnergyPack);	   
		Player::useItem(%pl,PlasmaGun);
	}
	else
	{
		Annihilation::setItemCount(%clientId, iarmorAngel, 1);
		Annihilation::setItemCount(%clientId, TargetingLaser, 1);
	}
}


// when map ends...reset everything so it won't affect other maps =|
// can't redefine data blocks, tribes will freak.
function Game::EndFrame()
   {
	if($missionname != "plas_land")
	{
		exec(player);
		exec(ai);
		exec(game);
		exec(dm);
		exec(objectives);
		exec(client);

		return;
	}
   }
   
//don't worry, everything is back to normal.