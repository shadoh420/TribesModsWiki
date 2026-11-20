
// The file with the same name as the parent folder gets executed first.
// Remaining files are executed in alphabetical order. -Plasmatic

$armor::Fast = 1.25; 
$armor::Speed = 1.50; 

function Armor::add(%name, %description, %price)
{
	%ItemData = "ItemData iarmor"@ %name @" {    heading = \"aArmor\";    description = \""@ %description @"\";    className = Armor;    price = "@ %price @"; };"; 	
	
	eval(%ItemData); 

	%aname = armorm@%name;
	%armorShape = %aname.shapeFile;
	// Heavy armor uses the same shape for male and female armors
	// We'll define the armors acordingly... -Plasmatic
	if(%armorShape != false)
	{
		// defining light and med armors...
		%maxdamage = %aname.maxDamage;
		//stock
		$ArmorType[Male,iarmor@%name] = armorm@%name;
		$ArmorType[Female, iarmor@%name] = armorf@%name;
		$ArmorName[armorm@%name] = iarmor@%name;
		$ArmorName[armorf@%name] = iarmor@%name;
		
		//define fast
		$ArmorType[Male,iarmor@%name@"Fast"] = armorm@%name;
		$ArmorType[Female, iarmor@%name@"Fast"] = armorf@%name;
		$ArmorName[armorm@%name@"Fast"] = iarmor@%name;
		$ArmorName[armorf@%name@"Fast"] = iarmor@%name;	
		
		//define speed
		$ArmorType[Male,iarmor@%name@"Speed"] = armorm@%name;
		$ArmorType[Female, iarmor@%name@"Speed"] = armorf@%name;
		$ArmorName[armorm@%name@"Speed"] = iarmor@%name;
		$ArmorName[armorf@%name@"Speed"] = iarmor@%name;	
		
		// ice
		$ArmorType[Male,iarmor@%name@"Ice"] = armorm@%name;
		$ArmorType[Female, iarmor@%name@"Ice"] = armorf@%name;
		$ArmorName[armorm@%name@"Ice"] = iarmor@%name;
		$ArmorName[armorf@%name@"Ice"] = iarmor@%name;
		
		//define fast ice
		$ArmorType[Male,iarmor@%name@"FastIce"] = armorm@%name;
		$ArmorType[Female, iarmor@%name@"FastIce"] = armorf@%name;
		$ArmorName[armorm@%name@"FastIce"] = iarmor@%name;
		$ArmorName[armorf@%name@"FastIce"] = iarmor@%name;	
		
		//define speed ice
		$ArmorType[Male,iarmor@%name@"SpeedIce"] = armorm@%name;
		$ArmorType[Female, iarmor@%name@"SpeedIce"] = armorf@%name;
		$ArmorName[armorm@%name@"SpeedIce"] = iarmor@%name;
		$ArmorName[armorf@%name@"SpeedIce"] = iarmor@%name;			
		
		//inv list crap	
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
			//stock
			$ArmorType[Male,iarmor@%name] = armor@%name;
			$ArmorType[Female, iarmor@%name] = armor@%name;
			$ArmorName[armor@%name] = iarmor@%name;
			
			//define fast
			$ArmorType[Male,iarmor@%name@"Fast"] = armor@%name;
			$ArmorType[Female, iarmor@%name@"Fast"] = armor@%name;
			$ArmorName[armor@%name@"Fast"] = iarmor@%name;
			
			//define Speed
			$ArmorType[Male,iarmor@%name@"Speed"] = armor@%name;
			$ArmorType[Female, iarmor@%name@"Speed"] = armor@%name;
			$ArmorName[armor@%name@"Speed"] = iarmor@%name;
			
			//stock ice
			$ArmorType[Male,iarmor@%name@"Ice"] = armor@%name;
			$ArmorType[Female, iarmor@%name@"Ice"] = armor@%name;
			$ArmorName[armor@%name@"Ice"] = iarmor@%name;
			
			//define fast ice
			$ArmorType[Male,iarmor@%name@"FastIce"] = armor@%name;
			$ArmorType[Female, iarmor@%name@"FastIce"] = armor@%name;
			$ArmorName[armor@%name@"FastIce"] = iarmor@%name;
			
			//define Speed ice
			$ArmorType[Male,iarmor@%name@"SpeedIce"] = armor@%name;
			$ArmorType[Female, iarmor@%name@"SpeedIce"] = armor@%name;
			$ArmorName[armor@%name@"SpeedIce"] = iarmor@%name;									
			
			$InvList[iarmor@%name] = 1;
			$MobileInvList[iarmor@%name] = 1;
			$RemoteInvList[iarmor@%name] = 0;
		}
	}
	
	if(!%maxdamage)
		echo("+++++ Armor::add("@%name@","@ %description@","@ %price@"); FAILED +++++ Check armor definitions.");

	AddItem("iarmor"@%name);	//add all items to a list for zappy/ quick invs.
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
					Player::decItemCount(%targetPlayer,%i,%delta);
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

$RepulsePower = 350;

function Repulse(%player, %item)
{
	// Alazane
	%set = newObject("set",SimSet);
	%ppos = GameBase::getPosition(%player);
	%num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
	for(%i=0; %i<%num; %i++)
	{
		%oply = Group::getObject(%set,%i);
		if(%oply != %player)
		{
			%vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
			%vec = (getWord(%vec, 0) * $RepulsePower) @ " " @ (getWord(%vec, 1) * $RepulsePower) @ " " @ (getWord(%vec, 2) * $RepulsePower);
			Player::applyImpulse(%oply, %vec);
		}
	}
	deleteObject(%set);
	Client::sendMessage(Player::getClient(%player),0, "You use a Repulsion Beacon");
	GameBase::playSound(%player, SoundFireMortar, 0);
	Player::decItemCount(%player,%item);
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
	if($poisonTime[%clientId] > 0) 
	{
		$poisonTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
		if(!Player::isDead(%player)) 
		{
		if(%player.invulnerable || $NoPlayerDamage || %player.frozen)	// || $jailed[%player])
		{
			// no damage, just play a shield. -plasmatic
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			return;
		}
		else GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.75);
			if(Player::isDead(%player)) 
			{
				messageall(0, Client::getName(%clientId) @ " died from a disease from Geno's mom.");
				%clientId.scoreDeaths++;
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
//==============================================
// fire damage.

// damage handled through projectile..
ExplosionData AnnihilationFlameExp
{
   shapeName = "plasmatrail.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 1.5;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 1.0, 0, 0 };
   colors[1]  = { 1.0, 0, 0 };
   colors[2]  = { 1.0, 0.25, 0.25 };
   radFactors = { 1.0, 1.0, 1.0 };

   shiftPosition = true;
};

GrenadeData AnnihilationFlame
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = AnnihilationFlameExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.5;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 0;	//0 impact, 1 radius
   damageValue        = 0.01;	//0.00675;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 0.0;	// Needs to be zero to animate properly for some reason -Plasmatic
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;    	//0.01// special meaning for grenades...
   liveTime           = 0.1;		//0.01
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//====== Damage when on fire and jetting... -Plasmatic
GrenadeData PlasmaShockJet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = debrisExpSmall;
   
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.00;//0.0125
   damageType         = $JettingDamage;	//9/6/2003 8:21AM $EnergyDamageType;	//$PlasmaDamageType

   explosionRadius    = 2.5;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.05;	//0.01// special meaning for grenades...
   liveTime           = 0.05;	//0.01
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};
//====================
function Armor::onBurn(%player,%ShooterClient)
{	
	if(%shooterclient == "")
		%shooterClient = 0;
	//GameBase::applyDamage(%player, $PlasmaDamageType, 0.1, getBoxCenter(%player),"0 0 0","0 0 0", %ShooterClient);
	%Client = Player::getClient(%player);
	if (!%player.onfire && !Player::isDead(%player)) 
	{
		Plasmafire(%player,%ShooterClient);
		Client::sendMessage(%client,0, "Your energy system is on fire!");	
	}
	%player.onfire = 200;
}


// Tracks shooter and damages player accordingly. -Plasmatic, Vengeance mod
function Plasmafire(%player,%ShooterClient)
{
	//plasmatic
	if(Player::isDead(%player))
		return;
	%player.onfire = %player.onfire -1;
	
	if(%player.onfire > 150 )
		GameBase::applyDamage(%player, $PlasmaDamageType, 0.0015, getBoxCenter(%player),"0 0 0","0 0 0", %ShooterClient);
	%vel = Item::getVelocity(%player);		
	if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
	{	
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
		%jet = player::isjetting(%player);
		if(%player.onfire > 70 )
		{
			Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
			if(%jet && GameBase::getEnergy(%Player)/ Player::getArmor(%player).maxEnergy < 0.35)
				Projectile::spawnProjectile("PlasmaShockJet", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		}
		if(%jet)
			Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	}
	else 	
		echo("!! Butterfly Error, Plasmafire. vel ="@%vel);	
		
	if(%player.onfire)
		schedule("PlasmaFire("@%player@","@%ShooterClient@");",0.1);
	
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
	%vel = Item::getVelocity(%player);
	
	// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
	if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
	{	
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
		if(%player.Shocked > 10 )
			Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		if(player::isjetting(%player))
			Projectile::spawnProjectile("ShockJet", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	}
	else 	
		echo("!! Butterfly Error, Shockfirer. vel ="@%vel);	
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
	$poisonTime[Player::getClient(%player)] = 0;
	if(GameBase::getLOSInfo(%player,5)) 
	{
		%obj = getObjectType($los::object);
		%name = GameBase::getDataName(%obj);
		if((%name.className == Station))
			GameBase::repairDamage(%obj,0.27);
	}
}

