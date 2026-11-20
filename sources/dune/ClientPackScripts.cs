// This module interprets the calls from the Clientpack.


// Let them know they're on a DUNE server
function remoteCheckDUNE( %client )
{
	remoteEval(%client, "DUNEAccepted");
}

// Do they want to loop their weapon switching?
function remoteSetWeaponLoop(%client,%loop)
{
	%client.weaponLooping = %loop;
	if(%loop == true)
		Client::sendMessage(%client,1,"Weapon looping is ON.");
	else
		Client::sendMessage(%client,1,"Weapon looping is OFF.");
}


// Toggle the singleshot and full auto
function remoteRifleSingleOnOff(%client)
{
	%player = client::getControlobject(%client);
	if(Player::getMountedItem(%client, $WeaponSlot) == "Rifle" && getobjecttype(%player) == "Player")
	{
		Client::sendMessage(%client,1,"Rifle set to single-shot.");
		// Switch weapons
		Player::setitemcount(%client,Rifle,0);
		Player::setitemcount(%client,Rifle2,1);
		Player::useItem(%client,Rifle2);
	} else 	if(Player::getMountedItem(%client, $WeaponSlot) == "Rifle2" && getobjecttype(%player) == "Player")
	{
		Client::sendMessage(%client,1,"Rifle set to full auto.");
		// Switch weapons
		Player::setitemcount(%client,Rifle2,0);
		Player::setitemcount(%client,Rifle,1);
		Player::useItem(%client,Rifle);
	}
}


function remoteUnarmedAttackBegin(%client)
{
	%player = client::getControlobject(%client);
	// Can't do it under these conditions.
	if(%player && getobjecttype(%player) != "Player" || Player::isDead(%player) || Player::IsBlocking(%player) || %player.tackled
		|| Player::getMountedItem(%player, $WeaponSlot) != -1 || %client.UA::JustAttacked || $Reloading[%client] == 1)
		return;

	Client::sendMessage(%client,0,"Attack!");
	%client.UA::JustAttacked = true;
	schedule(%client@".UA::JustAttacked = false;",1);

	if($ArmorName[player::Getarmor(%client)] == SoldierArmor)
	{
		UA::Trip(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == TrooperArmor)
	{
		UA::AttemptGrab(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == SardaukarArmor)
	{
		UA::AttemptGrab(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == BasharArmor)
	{
		UA::AttemptGarote(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == BursegArmor)
	{
		UA::AttemptGarote(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == FremenArmor)
	{
		UA::FremenUAAttack(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == FedaykinArmor)
	{
		UA::FedaykinUAAttack(%client,%player);
	} else if($ArmorName[player::Getarmor(%client)] == FaceDancerArmor)	
	{
		UA::AttemptAssassination(%client,%player);
	}
}

function remoteUnarmedAttackEnd(%client)
{
	%victim = $UA::grabbing[%client];

	if(UA::CanLetGo(%client,%victim))
	{
		%client.AttemptingGarote = false; // Got to do it here.
		if(%victim != "" && %victim > 0 
			&& ($ArmorName[player::Getarmor(%client)] == TrooperArmor || $ArmorName[player::Getarmor(%client)] == SardaukarArmor))
		{
			Player::setAnimation(%client,46);// Throw (Howed that feel)
			schedule("UA::ThrowTarget("@%client@", "@%victim@");",0.6);
			//$UA::grabbing[%client] = ""; // Moved to Throw
			//$UA::grabbed[%victim] = ""; // Moved to Throw
		} else if(%victim != "" && %victim > 0 
			&& ($ArmorName[player::Getarmor(%client)] == BursegArmor || $ArmorName[player::Getarmor(%client)] == BasharArmor))
		{
			UA::ReleaseGrip(%client);
		}
	}
}

function UA::AttemptAssassination(%client,%player)
{
	%trans = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile(neckBreak, %trans, %player, Item::getVelocity(%player));
}

function UA::AttemptGrab(%client,%player)
{
	if(GameBase::getLOSInfo(%player,2)) {
		%victim = $los::object;
		%target = gamebase::getcontrolclient(%victim);
		if(%victim != "" && %victim != 0 && %victim != -1 && getObjectType(%victim) == "Player" && %victim.tackled != True && !Player::IsBlocking(%victim)) 
		{
			$UA::grabbing[%client] = %target;
			$UA::Grabbed[%target] = %client;
			%target.GrabbedTime = getsimtime();
			Client::setControlObject(player::getclient(%victim), Client::getObserverCamera(%victim));
			//Observer::setOrbitObject(player::getclient(%victim), %victim, -8, -8, -8);
			%victim.tackled = True;
			%target.tackled = True;
			%target.tackle::ownedby = %victim;
			%victim.tackle::ownedby = %target;
			Player::setAnimation(%client,39);// Grab (move out of the way)
			UA::MaintainPosition(%target,%victim,%client);
		}
	}
}


function UA::AttemptGarote(%client,%player)
{
	%trans = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile(neckGarote, %trans, %player, Item::getVelocity(%player));
	%client.attemptingGarote = true;
}

function UA::GaroteTargetFound(%client,%target)
{
	if(!%client.attemptingGarote)
		return;
	%player = client::getControlobject(%client);
	%victim = client::getcontrolobject(%target);
	if(%victim != "" && %victim != 0 && %victim != -1 && getObjectType(%victim) == "Player" && %victim.tackled != True) 
	{
		$UA::grabbing[%client] = %target;
		$UA::Grabbed[%target] = %client;
		%target.garrotenotalk = true;
		%target.GrabbedTime = getsimtime();
		Client::setControlObject(player::getclient(%victim), Client::getObserverCamera(%victim));
		//Observer::setOrbitObject(player::getclient(%victim), %victim, -8, -8, -8);
		%victim.tackled = True;
		%target.tackled = True;
		%target.tackle::ownedby = %victim;
		%victim.tackle::ownedby = %target;
		Player::setAnimation(%client,20);// Strangle (PDA Acces)
		UA::MaintainPosition(%target,%victim,%client,true);
		UA::ToggleChoakMessage(%target);
	}
}

function UA::FremenUAAttack(%client,%player)
{
	if(GameBase::getLOSInfo(%player,3)) {
		%victim = $los::object;
		%target = gamebase::getcontrolclient(%victim);
		if(%victim != "" && %victim != 0 && %victim != -1 && getObjectType(%victim) == "Player") 
		{
			if($IsBlocking[%victim])
				UA::TackleRedirect(%client,%player,%victim,%target); // Redirect the tackle.
			else
				UA::ThrowSand(%victim,%target,0); // Sand in eyes.

		}
	}
}

function UA::FedaykinUAAttack(%client,%player)
{
	if(GameBase::getLOSInfo(%player,3)) {
		%victim = $los::object;
		%target = gamebase::getcontrolclient(%victim);
		if(%victim != "" && %victim != 0 && %victim != -1 && getObjectType(%victim) == "Player") 
		{
			if($IsBlocking[%victim])
				UA::TackleRedirect(%client,%player,%victim,%target); // Redirect the tackle.
			else
				UA::Disarm(%target,%victim); // Disarm/Steal their weapon

		}
	}
}

function UA::ThrowSand(%victim,%target,%count)
{
	// Armors that are immune to this:
	// -BT Soldier
	// -IX Soldier (possibly)
	// -Burseg

	if($ArmorName[player::Getarmor(%victim)] == SoldierArmor
		&& ($ServerNameToKeyName[GameBase::getTeam(%victim)] == BT
		|| ($FaceDancerIsSwitched[%victim] && $ServerNameToKeyName[%victim.impersonatingWhoTeam] == BT)))
		return;

	if($ArmorName[player::Getarmor(%victim)] == SoldierArmor
		&& ($ServerNameToKeyName[GameBase::getTeam(%victim)] == IX 
		|| ($FaceDancerIsSwitched[%victim] && $ServerNameToKeyName[%victim.impersonatingWhoTeam] == IX)))
		return;

	if($ArmorName[player::Getarmor(%victim)] == BursegArmor)
		return;

	if(%count < 50)
	{
		%count++;
		%flash = 1 / (%count%4 + 1) +0.25;
		if(%flash == 0.5)
			bottomprint(%target,"<jc>* * * * * * * * *You can't see!!* * * * * * * * *",0.2);
		else if(%flash == 0.75)
			centerprint(%target,"<jc>* * * * * * * * *Sand in your eyes!!* * * * * * * * *",0.2);
		else
			topprint(%target,"<jc>* * * * * * * * *It stings like hell!!* * * * * * * * *",0.2);

		Player::setDamageFlash(%victim, %flash);
		schedule("UA::ThrowSand("@%victim@","@%target@","@%count@");",0.1);
	}
}

function UA::TackleRedirect(%id1,%this,%id2,%object)
{
	if(!Player::isDead(%object))
	{
		%id1Armor = $ArmorName[Player::getArmor(%id1)];
		%id2Armor = $ArmorName[Player::getArmor(%id2)];

		%V = %id1.velocity;
		if(%V == "0 0 0")
			%V = GetOffSetRot("3 3 0",gamebase::Getrotation(%id1),"0 0 0");
		%M[%id1] = $Tackle::ArmorMass[%id1Armor];
		%M[%id2] = $Tackle::ArmorMass[%id2Armor];
		
		%Mult = (%M[%id1]*4)/(%M[%id2]*3);
	
		%V = getWord(%V,0)*%mult @ " " @ getWord(%V,1)*%mult @ " " @ ((getWord(%V,2)/3)*%mult + 5);

		Item::setVelocity(%id2, %V);

		Player::setAnimation(%id2, 33);
		%id2.tackled = True;
		%object.tackled = True;
		%id2.justThrown = true;
		%id1.justthrew = %id2;
		%object.tackle::ownedby = %id2;
		%id2.tackle::ownedby = %object;

		Client::setControlObject(%object, Client::getObserverCamera(%id2));
		schedule(%id1@".justThrew = false;",$Tackle::TackleDownTime);	
		schedule(%id2@".justThrown = false;",$Tackle::TackleDownTime);	
		schedule("Tackle::setControlObject(" @ %object @ ", " @ %id2 @ ");", $Tackle::TackleDownTime);
		
	}
}

function UA::Disarm(%client,%Object)
{
	if(Player::getMountedItem(%object,$WeaponSlot) != -1)
	{
		%weaponType = Player::getMountedItem(%object,$WeaponSlot);
		Player::trigger(%object, $WeaponSlot, false);	
		%obj = newObject("","Item",%Weapontype,1,false);
 		//schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 		addToSet("MissionCleanup", %obj);
		if($WeaponAmmo[%weapontype] != "")
		{
			%obj.ammoCount = player::getItemCount(%client,$WeaponAmmo[%weaponType]);
			player::setItemCount(%client,$WeaponAmmo[%weaponType],0);
		}
		GameBase::throw(%obj,%object,2,true);
		Item::playPickupSound(%obj);
		%obj.lastowner = %client;
		%obj.lastownerarmor = player::getarmor(%object);
		Player::decItemCount(%object,%weapontype,1);
	}
}

$Trip::Bonus[SoldierArmor] = 0;
$Trip::Bonus[FremenArmor] = 25;
$Trip::Bonus[FedaykinArmor] = 30;
$Trip::Bonus[FaceDancerArmor] = 10;
$Trip::Bonus[TrooperArmor] = 0;
$Trip::Bonus[BursegArmor] = 0;
$Trip::Bonus[BasharArmor] = 0;
$Trip::Bonus[SardaukarArmor] = 0;
function UA::Trip(%id1,%this)
{

	if(GameBase::getLOSInfo(%this,2)) {
		%id2 = $los::object;
		%object = gamebase::getcontrolclient(%id2);
		if(%id2 != "" && %id2 != 0 && %id2 != -1 && getObjectType(%id2) == "Player") 
		{
			%math = $Tackle::ArmorMass[$ArmorName[Player::getArmor(%id2)]]/2 + $Trip::Bonus[$ArmorName[Player::getArmor(%id2)]];
			
			if(!Player::isDead(%id2) && getrandom()*90 > %math)
			{
				%id1Armor = $ArmorName[Player::getArmor(%id1)];
				%id2Armor = $ArmorName[Player::getArmor(%id2)];

				%V = %id1.velocity;
				if(%V == "0 0 0")
					%V = GetOffSetRot("3 3 0",gamebase::Getrotation(%id1),"0 0 0");
				%M[%id1] = $Tackle::ArmorMass[%id1Armor];
				%M[%id2] = $Tackle::ArmorMass[%id2Armor];
				
				%Mult = (%M[%id1]*4)/(%M[%id2]*3);
	
				%V = getWord(%V,0)*%mult @ " " @ getWord(%V,1)*%mult @ " " @ ((getWord(%V,2)/3)*%mult + 5);

				//Item::setVelocity(%id2, %V);
	
				Player::setAnimation(%id2, 33);
				%id2.tackled = True;
				%object.tackled = True;
				%object.tackle::ownedby = %id2;
				%id2.tackle::ownedby = %object;

				Client::setControlObject(%object, Client::getObserverCamera(%id2));
				schedule("Tackle::setControlObject(" @ %object @ ", " @ %id2 @ ");", $Tackle::TackleDownTime);
				
				%Object1 = gamebase::getcontrolclient(%id1);

				Player::setAnimation(%id1, 33);
				%id1.tackled = True;
				%this.tackled = True;
				%this.tackle::ownedby = %id1;
				%id1.tackle::ownedby = %this;

				Client::setControlObject(%id1, Client::getObserverCamera(%this));
				schedule("Tackle::setControlObject(" @ %id1 @ ", " @ %this @ ");", $Tackle::TackleDownTime);
			}
		}	
	}
}
function UA::AttemptBreakGrip(%victim)
{
	%player = $UA::grabbed[%victim];
	%rand = getRandom();
	%Chance = ((($Tackle::ArmorMass[$ArmorName[Player::getArmor(%victim)]]/3)*%rand * ((getSimTime() - %victim.GrabbedTime)/360))) * 100;
	Player::setAnimation(%victim,38);
	if((%victim.tackle::ownedby).garrotenotalk)
		%chance = %chance - 10;
	if(%player != "" && %player > 0 && %chance > 50)
	{
		UA::ReleaseGrip(%player);
	}
}

function UA::ReleaseGrip(%player)
{
	%victim = $UA::grabbing[%player];
	if(UA::CanLetGo(gamebase::getcontrolclient(%player),%victim))
	{
		if(%victim != "" && %victim > 0)
		{
			%victim.garrotenotalk = false;
			$UA::grabbing[%player] = "";	
			$UA::grabbed[%victim] = "";
			Tackle::setControlObject(%victim, %victim.tackle::ownedby);
		}
	}
}

function UA::ThrowTarget(%client, %victim)
{	
	%this = Client::Getcontrolobject(%client);
	%object = %victim.tackle::ownedby;

	if(UA::CanLetGo(%client,%victim))
	{
		if(!Player::isDead(%object))
		{
			$UA::grabbing[%client] = ""; // Moved to Throw
			$UA::grabbed[%victim] = ""; // Moved to Throw
			%id1 = Player::getClient(%this);
			%id2 = Player::getClient(%object);
			%id1Armor = $ArmorName[Player::getArmor(%id1)];
			%id2Armor = $ArmorName[Player::getArmor(%id2)];

			%V = %id1.velocity;
			if(%V == "0 0 0")
				%V = GetOffSetRot("3 3 0",gamebase::Getrotation(%id1),"0 0 0");
			%M[%id1] = $Tackle::ArmorMass[%id1Armor];
			%M[%id2] = $Tackle::ArmorMass[%id2Armor];
			
			%Mult = (%M[%id1]*4)/(%M[%id2]*3);
		
			%V = getWord(%V,0)*%mult @ " " @ getWord(%V,1)*%mult @ " " @ ((getWord(%V,2)/3)*%mult + 5);

			Item::setVelocity(%id2, %V);		
	
			Player::setAnimation(%id2, 33);
			%id2.tackled = True;
			%object.tackled = True;
			%id2.justThrown = true;
			%id1.justthrew = %id2;
			schedule(%id1@".justThrew = false;",$Tackle::TackleDownTime);	
			schedule(%id2@".justThrown = false;",$Tackle::TackleDownTime);	
			schedule("Tackle::setControlObject(" @ %id2  @ ", " @ %object @ ");", $Tackle::TackleDownTime);
		}	
	}
}

function UA::MaintainPosition1(%VicClient,%VicPlayer,%client,%garote)
{
	if(%garote == "")
		%garote = false;
	else if(%garote && !%client)
		return;

	if($UA::grabbing[%client] == %vicClient && $UA::grabbed[%VicClient] == %client)
	{
		%pos = gamebase::Getposition(%client);
		if(%pos != "0 0 0" && %pos != "")
		{
			%rot = gamebase::GetRotation(%client);
			if(%garote)
			{	
				GameBase::applyDamage(%vicPlayer, $AsphyxiationDamageType, 0.0005, GameBase::getPosition(%vicPlayer), "0 0 0", "0 0 0", %client);	
				%newPos = GetOffSetRot("0 1 0",%rot,%pos);
				%newRot = %rot;
			}
			else
			{
				%newPos = GetOffSetRot("0 2 0.2",%rot,%pos);
				%newRot = Vector::Add(%rot,"0 0 3.141592654");
			}
			gamebase::setposition(%vicplayer,%newPos);
			gamebase::setrotation(%vicplayer,%newRot);
			item::setvelocity(%VicClient, "0 0 0");	
			item::setvelocity(%VicPlayer, "0 0 0");	
		}
		schedule("UA::MaintainPosition("@ %vicClient @","@ %vicPlayer @","@ %Client @","@ %garote @");",0.005);
	}
}


// Try using impluses.
function UA::MaintainPosition(%VicClient,%VicPlayer,%client,%garote)
{
	if(%garote == "")
		%garote = false;
	else if(%garote && !%client)
		return;

	if($UA::grabbing[%client] == %vicClient && $UA::grabbed[%VicClient] == %client)
	{
		%pos = gamebase::Getposition(%client);
		if(%pos != "0 0 0" && %pos != "")
		{
			%rot = gamebase::GetRotation(%client);
			%armor = player::Getarmor(%vicclient);
			if(%garote)
			{	
				if(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "farmor" || %armor == "ffemale" || %armor == "ffarmor" || %armor == "fffemale")
					%mag = 62; 
				else
					%mag = 90;
				GameBase::applyDamage(%vicPlayer, $AsphyxiationDamageType, 0.0005, GameBase::getPosition(%vicPlayer), "0 0 0", "0 0 0", %client);	
				%newPos = GetOffSetRot("0 1 0.3",%rot,%pos);
				%newRot = %rot;
			}
			else
			{
				if(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "farmor" || %armor == "ffemale" || %armor == "ffarmor" || %armor == "fffemale")
					%mag = 58.8; 
				else
					%mag = 85;
				%newPos = GetOffSetRot("0 2 0.2",%rot,%pos);
				%newRot = Vector::Add(%rot,"0 0 3.141592654");
			}
			gamebase::setrotation(%vicplayer,%newRot);
			item::setvelocity(%VicClient, "0 0 0");	
			item::setvelocity(%VicPlayer, "0 0 0");
			%pre = vector::getrotaim(gamebase::Getposition(%vicplayer),%newPos);
			%imp = vector::Getfromrot(%pre,%mag);
			Player::applyImpulse(%vicplayer, %imp);
		}

		if(%garote && vector::getdistance(gamebase::Getposition(%vicPlayer),gamebase::Getposition(%client)) > 3.0)//2.9)
		{
			Client::sendMessage(%client,1,"Your shigawire breaks!");			
			Client::sendMessage(%vicclient,1,"You hear a loud snap as the pressure is taken off your neck!");						
			UA::ReleaseGrip(%client);
		}
		if(!%garote && vector::getdistance(gamebase::Getposition(%vicPlayer),gamebase::Getposition(%client)) > 2.9)
		{
			Client::sendMessage(%client,1,"You lose your grip on your victim!");			
			Client::sendMessage(%vicclient,1,client::Getname(%client) @ " loses his grip on you!");						
			UA::ReleaseGrip(%client);
		}

		schedule("UA::MaintainPosition("@ %vicClient @","@ %vicPlayer @","@ %Client @","@ %garote @");",0.005);
	}
}

function UA::ToggleChoakMessage(%client)
{
	if($UA::grabbed[%Client] == "")
		return;
	%client.ChoakMessage = true;
	schedule("UA::ToggleChoakMessage("@%client@");",1);
}


// Don't want them letting a live victim go inside a wall, or through a pentashield/blastwall.
// If attacker is dead, then he lets go, but victim takes his position.
function UA::CanLetGo(%client,%victim)
{
	return true; // Sure! New updates say they can't go inside walls! So it's always true!  Yay!
}


StaticShapeData LOSPos
{
	shapeFile = "breath";
	maxDamage = 999999999999999999999.0;
	debrisId = defaultDebrisLarge;
	shadowDetailMask = 16;
        explosionId = debrisExpLarge;
	description = "";
	visibleToSensor = false;
        mapFilter = 4;
        damageSkinData = "ArmorDamageSkins";
};

function remoteClimb(%client,%weapon)
{
	%player = client::getControlobject(%client);

	if(%client.justclimbed == true)
		return false;	

	%client.Justclimbed = true;
	schedule(%client@".Justclimbed = false;",0.6);

	%armor = Player::getArmor(%player);
	%light = %armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "sarmor2" || %armor == "sfemale2" || %armor == "farmor" || %armor == "ffemale" || %armor == "ffarmor" || %armor == "fffemale";
	%div = 1;
	if(%light == true)
	{
		%div = 2;
	}
	if(getobjecttype(%player) != "Player" || Player::isDead(%player) || Player::IsBlocking(%player) || %player.tackled
		|| %client.UA::JustAttacked)
		return;
	
//	if(Item::Getvelocity(%client) == "0 0 0" && GameBase::getLOSInfo(%player,2)) {
	if( GameBase::getLOSInfo(%player,2)) {
		%id2 = $los::object;
		%pos = $los::position;
		%rot = $los::normal;
		%dist =	getword(%pos,2) - getword(gamebase::getposition(%client),2);
		if(%dist < 0)
			%dist = -1*%dist;
		%object = gamebase::getcontrolclient(%id2);
		if(getobjecttype(%id2) == "InteriorShape" && %dist > 0.2 && getword(%rot,2) > 0.8){//&& GameBase::getLOSInfo(%player,10,"-1.57 0 0")) {
			if(%weapon != true && Player::getMountedItem(%player, $WeaponSlot) != -1)
			{
				Client::sendMessage(%client,0,"You must put away your weapon before attempting to climb.");
				return;
			} else {
				%weapon = Player::getMountedItem(%player, $WeaponSlot);
				if(%weapon != -1)
				{
					%player.LastWeapon = %weapon;
					Player::unmountItem(%player,$WeaponSlot);
				}
		
			}

			item::setvelocity(%player,"0 0 0");
			Client::sendMessage(%client,0,"You attempt to climb over the obstacle.");
			// climb
			%aim = "0 0 10";
			player::applyimpulse(%client,%aim);
			%aim = getword(%aim,0)/%div @" "@getword(%aim,1)/%div @" "@getword(%aim,2)/%div;
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.05);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.1);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.15);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.2);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.25);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.3);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.35);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.4);
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.45);
			
			%aim = vector::add(vector::getfromrot(gamebase::getrotation(%client),20),"0 0 0");
			%aim = getword(%aim,0)/%div @" "@getword(%aim,1)/%div @" "@getword(%aim,2)/%div;
			//player::applyimpulse(%client,getword(%aim,0)*10@" "@getword(%aim,1)*10@" 50");
			schedule("player::applyimpulse("@%client@",\""@%aim@"\");",0.5);	
		}
	}
}