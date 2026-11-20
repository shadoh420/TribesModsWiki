




function Game::playerSpawned(%pl, %clientId, %armor)
{
//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	if($Nappy::PersonalSkins)
		Client::setSkin(%clientId, $Client::info[%clientId, 0]); //personal skin
//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
	%player = Client::getOwnedObject(%clientId);
	%client = Player::getClient(%player);
	$Client[%client, Nappy:stopLag] = 0;
	%clientId.spawn= 1;
	%max = getNumItems();
	%team = Client::getTeam(%client);
	if(%team > -1){
		for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++){
			buyItem(%clientId,%item);	
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
		}
	}
	else{
		for(%i = 0; (%item = $duelBuyList[%i]) != ""; %i++){
			buyItem(%clientId,%item);	
			if(%item.className == Weapon) 
				%clientId.spawnWeapon = %item;
		}
	}
	%clientId.spawn = "";
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   	%clientId.spawnWeapon = "";
	}
} 



function Game::startMatch()
{
	$matchStarted = true;
	$missionStartTime = getSimTime();
	messageAll(0, "Match started.");
	Game::resetScores();	
	%numTeams = getNumTeams();
	for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)){
		if(%cl.observerMode == "pregame"){
			if(%cl.froze != 0) {			
				Client::setControlObject(%cl, Client::getObserverCamera(%cl));
				Observer::setOrbitObject(%cl, Client::getOwnedObject(%cl), 3, 3, 3);
			} 
			else{
				%cl.observerMode = "";
				Client::setControlObject(%cl, Client::getOwnedObject(%cl));
			}
		}
		Game::refreshClientScore(%cl);
	}
	Game::checkTimeLimit();
}







function Client::onKilled(%playerId, %killerId, %damageType)
{
	$Client[%playerId, Nappy:stopLag] = 1;
   echo("GAME: kill " @ %killerId @ " " @ %playerId @ " " @ %damageType);
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
	%victimName = Client::getName(%playerId);


   if(!%killerId)
   {
      messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
      %playerId.scoreDeaths++;
  }
   else if(%killerId == %playerId)
   {
	  %oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
      messageAll(0, %oopsMsg, $DeathMessageMask);
      %playerId.scoreDeaths++;
      %playerId.score--;
      Game::refreshClientScore(%playerId);
   }
   else
   {
		if(!String::ICompare(Client::getGender(%killerId), "Male"))
		{
			%killerGender = "his";
		}
		else
		{
			%killerGender = "her";
		}
      if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)))
      {
		if(%damageType != $MineDamageType) 
	    	messageAll(0, strcat(Client::getName(%killerId), 
   	        " mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
		else 
	         messageAll(0, strcat(Client::getName(%killerId), 
   	     	" killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
		 %killerId.scoreDeaths++;
       %killerId.score--;
       Game::refreshClientScore(%killerId);
      }
      else
      {
	     %obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId),
	       %victimName, %killerGender, %playerGender);
         messageAll(0, %obitMsg, $DeathMessageMask);
         %killerId.scoreKills++;
         %playerId.scoreDeaths++;  // test play mode
         %killerId.score++;
         Game::refreshClientScore(%killerId);
         Game::refreshClientScore(%playerId);
      }
   }
   Game::clientKilled(%playerId, %killerId);
}













//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------

$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";

$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";

$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";

$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";

$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";

$deathMsg[$ExplosionDamageType, 0]   = "%2 catches a Frisbee of Death thrown by %1.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 blasts %2 with a well-placed disc.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's spinfusor caught %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 falls victim to %1's Stormhammer.";

$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";

$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";

$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";

$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";

$deathMsg[$ElectricityDamageType, 0]	= "%2 gets zapped with %1's ELF gun.";
$deathMsg[$ElectricityDamageType, 1]	= "%1 gives %2 a nasty jolt.";
$deathMsg[$ElectricityDamageType, 2] 	= "%2 gets a real shock out of meeting %1.";
$deathMsg[$ElectricityDamageType, 3] 	= "%1 short-circuits %2's systems.";

$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";

$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";

$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";

$deathMsg[$MineDamageType, 0]		= "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]		= "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]		= "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]		= "%2 never saw it coming from %1.";

$deathMsg[$PoisonDamageType, 0]		= "%2 dies of poisoning."; 
$deathMsg[$PoisonDamageType, 1]		= "%2 gets a lethal injection."; 
$deathMsg[$PoisonDamageType, 2] 	= "%2 falls victim to a deadly virus."; 
$deathMsg[$PoisonDamageType, 3] 	= "%2 could not find the vaccine in time."; 

$deathMsg[$FireDamageType, 0] 		= "%2 bursts into flames thanks to %1."; 
$deathMsg[$FireDamageType, 1] 		= "%1 gives %2 a white-hot plasma injection."; 
$deathMsg[$FireDamageType, 2] 		= "%1 asks %2, 'Need a light?'"; 
$deathMsg[$FireDamageType, 3] 		= "%1 lights %2 on fire."; 

$deathMsg[$FlashDamageType, 0] 		= "%1 blows %2 up real good."; 
$deathMsg[$FlashDamageType, 1] 		= "%2 gets a taste of %1's explosive temper."; 
$deathMsg[$FlashDamageType, 2] 		= "%1 gives %2 a fatal concussion."; 
$deathMsg[$FlashDamageType, 3] 		= "%1 shocks the hell out of %2."; 

$deathMsg[$SniperDamageType, 0] 	= "%1 picks off %2."; 
$deathMsg[$SniperDamageType, 1] 	= "%1 fells %2 with a sniper shot."; 
$deathMsg[$SniperDamageType, 2] 	= "%2 was assassinated by %1."; 
$deathMsg[$SniperDamageType, 3] 	= "%2 stayed in %1's crosshairs for too long."; 

// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 ends it all.";
$deathMsg[-2,1]						 = "%1 takes %2 own life.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 decides to see what the afterlife is like.";

$numDeathMsgs = 4; 








if ($BaseMode){
$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";
}

if (!$BaseMode){
//$spawnBuyList[0] = ScoutArmor;
//$spawnBuyList[0] = SpyArmor;
//$spawnBuyList[0] = SniperArmor;
$spawnBuyList[0] = MercenaryArmor;
//$spawnBuyList[0] = EngineerArmor;
//$spawnBuyList[0] = FlagMoverArmor;
//$spawnBuyList[0] = BursterArmor;
//$spawnBuyList[0] = DragArmor;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Chaingun;
$spawnBuyList[3] = Disclauncher;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Beacon;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = TargetingLaser;
$spawnBuyList[8] = EnergyPack;
//$spawnBuyList[8] = DeployableInvPack;
$spawnBuyList[9] = "";
$spawnBuyList[10] = "";
}

       

function Game::playerSpawn(%clientId, %respawn)
{
	if(!$ghosting)
		return false;
	Client::clearItemShopping(%clientId);
	%spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
	if(!%respawn)
		bottomprint(%clientId, "<jc><f0>Mission: <f1>" @ $missionName @ "   <f0>Mission Type: <f1>" @ $Game::missionType @ "\n<f0>Press <f1>'O'<f0> for specific objectives.", 5); 
	if(%spawnMarker) {   
		%clientId.guiLock = "";
		%clientId.dead = "";
		if(%spawnMarker == -1){
			%spawnPos = "0 0 300";
			%spawnRot = "0 0 0";
		}
		else{
			%spawnPos = GameBase::getPosition(%spawnMarker);
			%spawnRot = GameBase::getRotation(%spawnMarker);
		}
		if(!String::ICompare(Client::getGender(%clientId), "Male"))
			%armor = "mercarmor";
		else
			%armor = "mercfemale";
		%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
		echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
		if(%pl != -1){
			GameBase::setTeam(%pl, Client::getTeam(%clientId));
			Client::setOwnedObject(%clientId, %pl);
			Game::playerSpawned(%pl, %clientId, %armor, %respawn);
			if($Nappy::respawnInvulnerableTime && %respawn){
				GameBase::setEnergy(%pl, 90);
				GameBase::setAutoRepairRate(%pl, 2);
				%pl.shieldStrength = 0.99;
				%pl.invulnerable = true;
				schedule("incInvulnerable(" @ %pl @ ", 0);", 0, %pl);
			}
			if($matchStarted){
				if(%clientId.froze != 0) {			
					Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
					Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
				}
				else 
					Client::setControlObject(%clientId, %pl);
			}
			else{
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







function incInvulnerable(%player, %time)
{
	if(%time > $Nappy::respawnInvulnerableTime){
		%player.invulnerable = "";
		GameBase::setAutoRepairRate(%player, 0);
		%player.shieldStrength = 0.0;
	}
	else{
		%t2 = %time * 2;
		if(%t2 & 2){
			if((%t2) & 1)
				%vec = "0 -1 0";
			else
				%vec = "0 1 0";
		}
		else{
			if((%t2) & 1)
				%vec = "1 0 0";
			else
				%vec = "-1 0 0";
		}
		GameBase::activateShield(%player,%vec, 0);
		schedule("incInvulnerable(" @ %player @ ", "@ %time + 0.5 @ ");", 0.5, %player);
	}
}





function Client::leaveGame(%clientId)
{
	if (%clientId.possessed){
		%cl = %clientId.possby;
		Client::setControlObject(%cl, %cl);
		%clientId.possby = "";
		%clientId.possessed = "false";
		%cl.poss = "";
		%cl.possessing = "false";
	}
}







function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock && !%clientId.possessed && !%clientId.possessing && !%clientId.froze)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}
