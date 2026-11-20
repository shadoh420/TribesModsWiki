
// The file with the same name as the parent folder gets executed first.
// Remaining files are executed in alphabetical order. -Plasmatic
//	ItemData DiscLauncher 
//	{
//		description = "Disc Launcher";
//		className = "Weapon";
//		shapeFile = "disc";
//		hudIcon = "disk";
//		heading = $InvHead[ihWea];
//		shadowDetailMask = 4;
//		imageType = DiscLauncherImage;
//		price = 150;
//		showWeaponBar = true;
//	};
function Armor::add(%name, %description, %price)
{
	%aname = armorm@%name;
	%armorShape = %aname.shapeFile;
	



	// Heavy armor uses the same shape for male and female armors
	// We'll define the armors acordingly... -Plasmatic
	if(%armorShape != false)
	{
		// defining light and med armors...
		%maxdamage = %aname.maxDamage;
		$ArmorType[Male,iarmor@%name] = armorm@%name;
		$ArmorType[Female, iarmor@%name] = armorf@%name;
		$ArmorName[armorm@%name] = iarmor@%name;
		$ArmorName[armorf@%name] = iarmor@%name;
		
		$InvList[iarmor@%name] = 1;
		$MobileInvList[iarmor@%name] = 1;
		$RemoteInvList[iarmor@%name] = 0;
	}
	else	
	{
		// defining harmor armors...
		%aname = armor@%name;
		%armorShape = %aname.shapeFile;
		if(%armorShape != false)
		{		
			%maxdamage = %aname.maxDamage;
			$ArmorType[Male,iarmor@%name] = armor@%name;
			$ArmorType[Female, iarmor@%name] = armor@%name;
			$ArmorName[armor@%name] = iarmor@%name;
			
			$InvList[iarmor@%name] = 1;
			$MobileInvList[iarmor@%name] = 1;
			$RemoteInvList[iarmor@%name] = 0;
		}
	}
	%ItemData = "ItemData iarmor"@ %name @" {    heading = \"aArmor\";    description = \""@ %description @"\";    className = Armor;   shapeFile = \""@%armorShape @"\"; price = "@ %price @"; };"; 	
	
	eval(%ItemData); 
		
	if(!%maxdamage)
		echo("+++++ Armor::add("@%name@","@ %description@","@ %price@"); FAILED +++++ Check armor definitions.");

	AddItem("iarmor"@%name);	//add all items to a list for zappy/ quick invs.
}

function startCloak(%clientId) 
{
	// Taken straight from Renegades
	// fixed to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);
	Client::sendMessage(%clientId,0,"You Cast Invisibility");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
	if($cloakTime[%clientId] == 0) 
	{	$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId);
	}
	else $cloakTime[%clientId] = 20;
}

function checkPlayerCloak(%clientId, %player) 
{
	%player = Client::getOwnedObject(%clientId);
	if(!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
	{
		$cloakTime[%clientId] -= 2;
		schedule("checkPlayerCloak(" @ %clientId @ ");",2,%player);
	}
	else 
	{
		$cloakTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your Invisibilty Spell Wears Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

function divineintervention(%clientId, %player) 
{
	Client::sendMessage(%clientId,0,"You summon the powers of the Gods!");
	GameBase::repairDamage(%player,0.5);
	GameBase::playSound(%player,ForceFieldOpen,0);
	%player.shieldStrength = 0.200;
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	if($shieldTime[%clientId] == 0) 
	{
		$shieldTime[%clientId] = 5;
		checkdivineintervention(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 5;
}

function checkdivineintervention(%clientId, %player) 
{
	if($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{
		$shieldTime[%clientId] -= 2;
		schedule("checkdivineintervention(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{
		$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your powers wear off.");
		%player.shieldStrength = 0;
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,%rate);
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

function Drain(%damagedPlayer, %damagingPlayer)
{
	if(GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%damagingPlayer))
		return;
	GameBase::applyDamage(%damagedPlayer,$EnergyDamageType,0.2,GameBase::getPosition(%damagedPlayer),"0 0 0","0 0 0",%damagingPlayer);
	GameBase::setEnergy(%damagedPlayer, GameBase::getEnergy(%damagedPlayer) - 80);
	%lev = GameBase::getDamageLevel(%damagingPlayer);
	if(%lev <0.2)
		GameBase::setDamageLevel(%damagingPlayer, 0);
	else
		GameBase::setDamageLevel(%damagingPlayer,%lev-0.2);
	GameBase::setEnergy(%damagingPlayer, GameBase::getEnergy(%damagingPlayer) + 120);
	GameBase::playSound(%damagedPlayer,ForceFieldOpen,0);
	Client::sendMessage(Player::getClient(%damagingPlayer), 1, "You suck out " @ Client::getName(Player::getClient(%damagedPlayer)) @ "'s life force");
}

function startShield(%clientId) 
{
	// Taken straight from Renegades
	// fixed by to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);	
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%player.shieldStrength = 0.006;
	if($shieldTime[%clientId] == 0) 
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}

function checkPlayerShield(%clientId) 
{
	// Taken straight from Renegades
	// fixed to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);
	if($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{
		$shieldTime[%clientId] -= 2;
		schedule("checkPlayerShield(" @ %clientId @ ");",2,%player);
	}
	else 
	{
		$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

function Steal(%targetPlayer, %sourcePlayer)
{
	// Steal from targetPlayer and give to sourcePlayer
	// Taken straight from Renegades
	// fixed by Plasmatic so flags arent stolen/ sent to the twilight zone...
	// and so same armors dont steal from each other.. pointless..
	// added super sweet pirate sound... -plasmatic
	//echo(%targetPlayer, %sourcePlayer);

	if($ArmorName[Player::getArmor(%targetPlayer)] == $ArmorName[Player::getArmor(%sourcePlayer)])
	{
		
		%client = Player::getClient(%sourcePlayer);
		if(!String::ICompare(Client::getGender(%client), "Male"))
			GameBase::playSound(%client, MAaargh, 0);//client::sendmessage(%client, 0, "~wmale5.wdsgst4.wav");
		else 
			GameBase::playSound(%client, FAaargh, 0);//client::sendmessage(%client, 0, "~wfemale1.wdsgst4.wav");
		return;
	}
		
	if(GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%sourcePlayer))
		return;
		

	Player::setDamageFlash(%targetPlayer,1.95);
	%sound = false;
	%max = getNumItems();
	for(%i = 0; %i < %max; %i = %i + 1)
	{
		%count = Player::getItemCount(%targetPlayer,%i);
		if(%count)
		{
			%item = getItemData(%i);//
			if(%item != flag)
			{
				%delta = Item::giveItem(%sourcePlayer,%item,%count);
				if(%delta > 0)
				{
					Annihilation::decItemCount(%targetPlayer,%i,%delta);
					%sound = true;
				}
			}
		}
	}
	if(%sound)
		playSound(SoundPickupItem,GameBase::getPosition(%sourcePlayer));
}

$AssassinateChance = 25;
// function fixed so team members dont attemp to assinate each other -Plasmatic
function Assassinate(%targetPlayer, %sourcePlayer)
{
	%Tteam = GameBase::getTeam(%targetPlayer);
	%Steam = GameBase::getTeam(%sourcePlayer);
	%SClient = Player::getClient(%sourcePlayer);
	if((%Tteam != %Steam && %SClient.isSpy) || (%Tteam == %Steam && !%SClient.isSpy) || Player::isDead(%targetPlayer) || Player::isDead(%sourcePlayer))
		return;
	Client::sendMessage(%SClient, 1, "You attempt to assassinate your target");
	if(Player::getArmor(%targetPlayer) != Player::getArmor(%sourcePlayer))
	{
		if(floor(getrandom() * 100) <= $AssassinateChance)
		{
			GameBase::applyDamage(%targetPlayer,$AssassinDamageType,14.2,GameBase::getPosition(%targetPlayer),"0 0 0","0 0 0",%SClient);
			Client::sendMessage(Player::getClient(%targetPlayer), 1, "You were ASSASSINATED");
			Client::sendMessage(%SClient, 1, "You ASSASSINATED your target");
		}
		else
		{
			Client::sendMessage(%SClient, 1, "You failed to assassinate your target");
		}
	}
	else			
	{
		Client::sendMessage(%SClient, 1, "You cannot assassinate another assassin");
	}
}



function startPoison(%clientId, %player) 
{
	// Taken straight from Renegades
	
	Client::sendMessage(%clientId,1,"You have herpes!");
	if($poisonTime[%clientId] == 0) 
	{
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 30;
		checkPlayerPoison(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 30;
}

function checkPlayerPoison(%clientId, %player) 
{
	// Taken straight from Renegades
	// fixed to include death animation. -plasm 1/18/2005 5:42AM
	if($poisonTime[%clientId] > 0) 
	{
		$poisonTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
		if(!Player::isDead(%player)) 
		{
			if(%player.invulnerable || $Annihilation::NoPlayerDamage || %player.frozen || $jailed[%player])
			{
				// no damage, just play a shield. -plasmatic
				%thisPos = getBoxCenter(%this);
				%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
				GameBase::activateShield(%this,%vec,%offsetZ);
				return;
			}
			else 
				GameBase::setDamageLevel(%player, %drrate);
				
			Player::setDamageFlash(%player,0.75);
			if(Player::isDead(%player)) 
			{
				Player::setAnimation(%player, $PlayerAnim::DieSpin);	// plasm 3.0 1/18/2005 5:49AM
				messageall(0, Client::getName(%clientId) @ " died from a disease from Geno's mom.");
				%clientId.scoreDeaths++;
				%clientId.TDeaths++;
				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$poisonTime[%clientId] = 0;
			}
			else
				schedule("checkPlayerPoison(" @ %clientId @ ", " @ %player @ ");", 5, %player);
		}
		else 
			$poisonTime[%clientId] = 0;
	}
	else 
		Client::sendMessage(%clientId,1,"The effects of the poison wear off.");
}


DamageSkinData armorDamageSkins 
{
	bmpName[0] = "dskin1_armor";
	bmpName[1] = "dskin2_armor";
	bmpName[2] = "dskin3_armor";
	bmpName[3] = "dskin4_armor";
	bmpName[4] = "dskin5_armor";
	bmpName[5] = "dskin6_armor";
	bmpName[6] = "dskin7_armor";
	bmpName[7] = "dskin8_armor";
	bmpName[8] = "dskin9_armor";
	bmpName[9] = "dskin10_armor";
};

function Armor::onPoison(%client, %player)
{
	startPoison(%client, %player);
}

function Armor::onBurn(%client, %player)
{	
	
	if (!%player.onfire) 
	{
		Plasmafire(%player);
		Client::sendMessage(%client,0, "Your energy system is on fire!");	
	}
	%player.onfire = 200;
}



function Plasmafire(%player)
{
	//plasmatic
//	echo("Plasmafire("@%player@");");
	if(Player::isDead(%player))
		return;
	%player.onfire--;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	%jet = player::isjetting(%player);
	if(%player.onfire > 70 )
	{
		Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		if(%jet && GameBase::getEnergy(%Player)/ Player::getArmor(%player).maxEnergy < 0.25)
			Projectile::spawnProjectile("PlasmaShockJet", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	}
	else if(%player.onfire > 50 && vector::getdistance(%vel,"0 0 0") > 3)
		Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel);	//3.0 addition. -Plasmatic		
	else if(%jet)
		Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onfire)
		schedule("PlasmaFire("@%player@");",0.1);	
}



function Armor::onShock(%client, %player)
{	
	
	if (!%player.Shocked) 
	{
		//Player::unmountItem(%player,$WeaponSlot);
		Shockfire(%player);
		Client::sendMessage(%client,0, "Your energy system is FRIED!");	
	}
	%player.Shocked = 20;
	GameBase::setEnergy(%player,0);
	if(%player.GrabObject)
		Player::trigger(%player,$WeaponSlot,false);	//plasmatic 2.3
}



function Shockfire(%player)
{
	//plasmatic
	if(Player::isDead(%player))	return;
	GameBase::playSound(%player, SoundEmpIdle,0);
	%player.Shocked = %player.Shocked -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
	%vel = Item::getVelocity(%player);
	if(%player.Shocked > 10 )
		Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(player::isjetting(%player))
		Projectile::spawnProjectile("ShockJet", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.Shocked)
		schedule("Shockfire("@%player@");",0.5);
	
}



function Armor::onPlayerContact(%targetPlayer, %sourcePlayer)
{
	
}

function Armor::ThrowGrenade(%player, %obj)
{
	Player::setAnimation(%player, 45);	//added animation for 2.2 -plasmatic anim 21 is grenade throw, but long animation...
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam (%obj,GameBase::getTeam (%client));
}


function Armor::onRepairKit(%player)
{
	 // Heal poison with repair kit
	 %client = Player::getClient(%player);
	$poisonTime[%client] = 0;
	
	GameBase::repairDamage(%player,0.2); // moved here from RepairKit::onUse(%player,%item) -Plasmatic 3.x
	if(GameBase::getLOSInfo(%player,5)) 
	{
		// Ok, it looks like the origional (Annihilation) Health kit code
		// was intended to use a healthKit to partially fix a station
		// It's now working.. Plasmatic 1/31/2005 6:55AM
		
		// I also added in throwing repair damage.. Toss one at some items to repair..
		%object = $los::object;	
		if(GameBase::getDamageLevel(%object))
		{
			%name = GameBase::getDataName(%object);	
			%class = %name.className;
			%data = %name.description;		
			if(%name == PulseSensor || %class == Generator || %class == Station || %class == Turret)
			{
	
				remoteDropItem(%client,RepairKit);
				if($build)
					Annihilation::incItemCount(%player,RepairKit);	
					//throw removes it.. 	
				
				//handling this in RepairKit::onCollision(%this,%object)
			//	GameBase::repairDamage(%object,0.27);
			//	GameBase::playSound(%object, ForceFieldOpen,0);
			}
		}
	}
	if(!$build)
		Annihilation::decItemCount(%player,RepairKit);

}

function Armor::SpeedBooster(%player, %item, %power)
{
	%vel = Item::getVelocity(%player);

	if(getsimtime() - %player.LastBeacon > 4.0)
		%player.BeaconTimer = 0;	
	
	%player.LastBeacon = getSimTime();	
		
	if(%player.BeaconTimer > 40)
	{

//		if(vector::normalize(%vel) == "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic	
//			messageall(1,"butterfly!");
			
		%Pos = getboxcenter(%player); 
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player); 
		%obj = Projectile::spawnProjectile("suicideShell", %trans, %player, %vel);
		Projectile::spawnProjectile(%obj);
		Item::setVelocity(%obj, %vel);
		Client::sendMessage(Player::getClient(%player),0, "Your booster exploded!");
	
		
	}
	else
	{
		if(%vel == "0 0 0")
		{
			//fixed for stationary player, this is called if player is at rest -plasmatic
			//fixed to send em where they look... not just forward..
			%trans = GameBase::getMuzzleTransform(%player);
			%smack = %power/25;
			%rot=GameBase::getRotation(%player);
			%len = 30;
			%tr= getWord(%trans,5);
			if(%tr <=0 )%tr -=%tr;
			%up = %tr+0.15;
			%out = 1-%tr;
			%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
			Player::applyImpulse(%player, %vec);
			GameBase::playSound(%player, SoundFireMortar, 0);
			Client::sendMessage(Player::getClient(%player),0, "You spank yourself.");	
		}
		else
		{	
			%vel = Vector::Normalize(%vel);
			%vec = GetWord(%vel, 0) * %power @ " " @ GetWord(%vel, 1) * %power @ " " @ GetWord(%vel, 2) * %power;
			Player::applyImpulse(%player, %vec);
			GameBase::playSound(%player, SoundFireMortar, 0);
			Client::sendMessage(Player::getClient(%player),0, "You spank yourself.");	
		}
		
		player::shockwave(%player);
		
	}
	


	if(!$build)
		Annihilation::decItemCount(%player,%item);
		
	if(!%player.BeaconTimer)
		Beacon::timer(%player);
		
	if(%player.BeaconTimer < 250)
		%player.BeaconTimer += 40;			
}

function Beacon::timer(%player)
{
	//plasmatic	
	if(Player::isDead(%player))
		return;
				
	%player.BeaconTimer--;
//	messageall(1,%player.BeaconTimer);

	if(%player.BeaconTimer)
		schedule("Beacon::timer("@%player@");",0.1);	
}

function Armor::Speedcheck(%player)	//Plasmatic 3.x 1/11/2006 11:36AM
{
	
	//plasmatic
	if(Player::isDead(%player))
		return;
	%vel = Item::getVelocity(%player);
	%speed = vector::getdistance(%vel,"0 0 0");
//	echo("speed check "@%speed);	
//	%type = getObjectType(%this);
	%control = GameBase::getControlClient(%player);
//	if(%control != -1 && %type == Flier)
	// fixed redundancy when piloting... 10/14/2007 6:50AM -Plasmatic
	if(%speed > 50 && %control != -1)	//speed O sound ~ 331 m/s
	{
		if(!Player::isAIControlled(%player) && !Player::getclient(%player).nospeedo)
			bottomprint(Player::getclient(%player), "<jc>"@floor(%speed), 1);
			
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
		
		if(%speed > 125)
			player::shockwave(%player);
		else if(%speed > 100)
			Projectile::spawnProjectile("PlasmaShockJet", %trans, %player, %Vel);
		else if(%speed > 85)
			Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		else if(%speed > 70) 
			Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel);			
	
		schedule("Armor::speedcheck("@%player@");",0.1);	//zomg, we need to do something here.. QUICK!
	}	
	else
		schedule("Armor::speedcheck("@%player@");",2);		//check again in a while. 
}