$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);
	
	if(!Player::isAIControlled(%this))	// Plasmatic! 1/11/2006 11:37AM
		Armor::speedcheck(%this);
}

function Player::onRemove(%this)
{
	deletevariables(%this);	//Plasmatic 3.x 1/11/2006 11:52AM
	// Drop anything left at the players pos
	for(%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1)
		{
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
			schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
			addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	//echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onKilled(%this)
{
	%this.Station = "";
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
//	Player::setDamageFlash(%this,0.75);
	for(%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if(%type != -1)
		{
			if(%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
			if(%i == $WeaponSlot && %type == BabyNukeMortar)
				Player::trigger(%this,$WeaponSlot,false);
		}
	}

	if(%cl != -1)
	{
		if(%this.vehicle != "")	
		{
			if(%this.driver != "") 
			{
				%this.driver = "";
				%this.vehicle.Pilot = "";
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
		schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
		Client::setOwnedObject(%cl, -1);
		Client::setControlObject(%cl, Client::getObserverCamera(%cl));
		
		//Plasmatic
		//%pos = 	//%cl.killdirection;
		%vec = %this.lastdamagevec;	//vector::sub(gamebase::getposition(%shooterObject),gamebase::getposition(%this));
		//messageall(1,%vec);
		%crot = vector::add("1.5 0 0",vector::getrotation(vector::neg(vector::normalize(%vec))));	
		
		Observer::setOrbitObject(%cl, %this, 5, 5, 5, %crot);
		
		schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
		%cl.observerMode = "dead";

		%cl.dieTime = getSimTime();
	}
}

// spawn some grenades for the hell of it.. -plasmatic 
function player::blood(%this)
{
	echo("Spawn blood halo around "@%this);
	%Pos = GameBase::getPosition(%this); 
	%vel = Item::getVelocity(%this);
	if(vector::normalize(%vel) != "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic
	{	
		%vel = vector::multiply(%Vel,"0.75 0.75 0.75");
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%this);	
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);
	
	// Spawn butterflies
		for(%i=0; %i < 15; %i += 1) 
		{
			%xrnd = %xvel + floor(getRandom() * 30) -15;
			%yrnd = %yvel + floor(getRandom() * 30) -15;
			%zrnd = %zvel + floor(getRandom() * 20) -10;
			%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;
			//echo(%this@" blood "@%forceVel);
			%obj = Projectile::spawnProjectile("FieryBlood", %trans, %this, %vel);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %forceVel);
		}
	}
	else
		echo("!! Butterfly Error, Blood Butterflies. vel ="@%vel);	
}


//plasmatic
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
//	messageall(1,"Obj:"@%object@" damaged This:"@%this);
	if($debug::Damage)
	{
		echo("Player::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%vertPos@", "@%quadrant@", "@%object@" )");
	}
	//echo("type damage "@%type@"object "@%object);
	if(%type == $NullDamageType || !Player::isExposed(%this) || Player::isDead(%this) || %value <= 0) 
		return;//plasmatic 2.3	
	
	// plasmatic body blocking
	// set threshold in playerdata -mindamagespeed	
	if(%type == $LandingDamageType)		// && GameBase::getControlClient(%this) != -1)
	{	
		if($debug::Damage)
		{
			echo("Landing damage animation: "@%this);
		}			
		%vel = Item::getVelocity(%this);	
		%speed = vector::getdistance(%vel,"0 0 0");
		%speedChange = vector::getdistance(%speed,%this.lastSpeed);
		
		if(%speed > 500)
		{
			messageall(1,"skidmark!");	// bad attempt at leaving markers where people ski -Plasmatic
		//	
			%dir = vector::normalize(%vel);	//vector::neg(vector::normalize(%vel));
			%pos = vector::sub(getBoxCenter(%this),%dir);
			%obj = newobject("", "item", "RepairKit", 1, false);
		//	%proj = Projectile::spawnProjectile("skidmark","0 0 0 "@ %dir @" 0 0 1 "@%pos,%obj,%vel);
		//	deleteobject(%obj);
			GameBase::setPosition(%obj,%pos);	
		}	
		
		
		%this.lastSpeed = %speed;
		%this.lastVel = %vel;
		%this.lastImpact  = getSimTime();
//		if(%speed > 25)
//		{
			
			if(%speedchange > 20)
			{	
				Player::setAnimation(Client::getOwnedObject(%this),28);		
				GameBase::playSound(%this, SoundLandOnGround, 0);	
			}
			%value = %value -0.12;
			if(%value <0 )
				%value = 0;
		//	%this.lastimpact  = getSimTime();
//		}
//		else
//			%value = 0;

		//%Pos = vector::add(getBoxCenter(%this),vector::normalize(%vel));	//sometimes spawns in floor..	
		%thisPos = getBoxCenter(%this);
		%trans =  "0 0 1 0 0 0 0 0 1 " @ %thisPos;
		//%kicker = 
		Projectile::spawnProjectile("KickerGrenade", %trans, %this, %vel);
			
		if($debug)
			echo("player landing damage v"@%value@", s"@%speed@", strength "@%strength);
		
		if(%value <= 0)
			return;
	}	
	if(!%object)
		%object = Player::getClient(%this).AIkiller;
	%shooterClient = %object;
		
	%damagedClient = Player::getClient(%this);
	%targetTeam = GameBase::getTeam(Player::getClient(%this));
	%shooterTeam = GameBase::getTeam(%shooterClient);
	%shooterObject = Client::getOwnedObject(%shooterClient); 

	//	if (!Player::isDead(%this))
	//	{ 
	//		if(%type == $SniperDamageType || %type == $LaserDamageType) 
	//		{
	//			messageall(1,%value);
	//			%value *= O:Snipe(%this,%shooterClient);
	//			messageall(1,%value);
	//		
	//		}
	//		
	//	}	

	// Check for wankers, ignore laser damage as it won't damage past visible anyhow. -Plasmatic
//	if($MissionInfo:VisibleDist && %type != 6 && %shooterObject != -1 && !Player::isAIControlled(%shooterObject))
//	{
//		%shooterPos = gamebase::getposition(%shooterObject);
//		%targetPos = gamebase::getposition(%this);
//		%hitDist = vector::getdistance(%shooterPos,%targetPos);
//		if(%hitDist > $MissionInfo:VisibleDist)
//			messageall(0,Client::getName(%shooterClient)@" hit "@Client::getName(%damagedClient)@" "@floor(%hitDist - $MissionInfo:VisibleDist) @"m past visible distance. Type = "@%type);
//		
//	}	
		
	//Pitchfork impact damage -plasmatic 2.2
	if(%type == 0 && getSimTime() - %this.BoostTime < 2)// they were boosted less than 2 seconds ago.
	{
		%object = %this.LastBoost;
		//echo("boost damage "@%type@"object "@%object);
		%type = $ForkImpact;
	}


	
	if(Player::isAIControlled(%this) && %type == 6 && client::getname(%damagedClient) == "Froggy")
	{
		%ppos = gamebase::getposition(%this);
		%tpos = gamebase::getposition($fogturret);
		%d = vector::getdistance(%ppos,%tpos);
		$MissionInfo:VisibleDist = %d;
		messageall(0,"Visible Distance is "@floor(%d) @" (+-"@floor(%d/100)@")");
	%file = String::convertSpaces($missionName);
	export("MissionInfo:VisibleDist","temp\\Map_Info_"@%file@".cs",false);
			
		//exec(player);
		deleteobject(%this);
		//schedule("deleteobject("@$fogturret@");",1);
		GameBase::setDamageLevel($fogturret, 5);
		return;
	}
	
	if(%damagedClient != %object)	
		%this.lastdamagevec = %vec;	//Mmm.. 
	else
		%this.lastdamagevec = Vector::getFromRot(GameBase::getRotation(%this),1,0.5);
		
	%armor = Player::getArmor(%this);
		
	//	%InAir = Player::getLastContactCount(%damagedClient);	//time in air
		
	//start special bullet animation -plasmatic
	if(%type == $SniperDamageType || %type == $LaserDamageType) 
	{
		if(%type == $SniperDamageType && Player::getMountedItem(%shooterClient,$WeaponSlot) == Railgun && %shooterClient.rail)
			%value = %value*3;
		
		if(%vec != "0 0 0")
		{
			if($debug::Damage)
			{
				echo("Sniper damage animation: "@%this);
			}			
			%vel = Item::getVelocity(%this);			
			%vecPos = getBoxCenter(%this);		
			%zpos = ((getWord(%pos,2))-(getWord(%vecPos,2)));
			%thispos =  vector::add("0 0 "@%zpos,%vecpos);		
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %thispos;		
			%objb = Projectile::spawnProjectile("blood", %trans, %this, %vel);
				
						
	//		%trans =  "0 0 1 "@vector::normalize(vector::neg(%vec))@" 0 0 1 " @ %thispos;
	//		
	//		%objf = Projectile::spawnProjectile(TurretMissile, %trans, %this, %vel,Client::getOwnedObject(%object));
	//		
	//		%damagedClient.ObserverTarget = %objf;
	//		%damagedClient.lastControlObject = %this;
	//		$watcher[%objf] = %damagedClient;
	//		projectile::follow(%objf);
	//		messageall(1,"follow "@%objf);
			
			
			GameBase::setPosition(%obj, %thispos);			
			%back = Vector::Multiply(vector::normalize(%vec), "15 15 1");
	//		%front = Vector::neg(%back);
	//		Item::setVelocity(%objf, %front);
			Item::setVelocity(%objb, %back);	
				
		}
	}
	//ending special bullet damage	
		

	
	//something for inv discing wankers.. -plasmatic	
	%station = %this.Station;
	if(%targetTeam == %shooterTeam && %station && %type == $ExplosionDamageType)
	{
				
		Player::trigger(%shooterObject, $WeaponSlot, false);
		%weaponType = Player::getMountedItem(%shooterObject,$WeaponSlot);
		if(%weaponType == DiscLauncher)
		{
			Player::unmountItem(%shooterObject,$WeaponSlot);
			//Player::dropItem(%shooterObject,%weaponType);		
			Client::sendMessage(%shooterClient,0,"~wfemale2.wdsgst2.wav");
			schedule("client::sendmessage("@%shooterClient@",0,\"~wfemale1.wwshoot.wav\");",0.8);
			return;
		}
		
	}
	else	
	{
		%mult = $ArmorKickback[$ArmorName[%armor]];
		if(%mult != 0)
		{	
			%mom = (getWord(%mom, 0) * %mult) @ " " @ (getWord(%mom, 1) * %mult) @ " " @ (getWord(%mom, 2) * %mult);
		}
		Player::applyImpulse(%this,%mom);
		
	}
	//spys and necro absorb mine damage, lose energy
	if(%type == $MineDamageType && ($ArmorName[%armor] == iarmorSpy || $ArmorName[%armor] == iarmorNecro))	
	{
		%energy = GameBase::getEnergy(%this);	
		GameBase::setEnergy(%this,%energy - 40);
	}
	if($build && %type == 6)
	{
		%weaponType = Player::getMountedItem(%shooterObject,$WeaponSlot);
		if(%weaponType == CuttingLaser)
		{	
			return;	//they're using a builder cutting laser, do nothing -plasmatic
		}		
	}	
	
//starting normal damage..
	if($debug) 
		echo("?? EVENT player damage "@Client::getName(%damagedClient)@" damaged by "@Client::getName(%shooterClient)@" damage type = "@%type);

	%InAir = Player::getLastContactCount(%damagedClient);	//time in air	
	// special damage types -----------------			
		//stasis
	if(%type == $StasisDamageType)
	{
		//no stasis yerself or team members when td is off -plasmatic
		if (Player::getClient(%this) == %object || (%shooterTeam == %targetTeam && !$Server::TeamDamageScale))
			return;
		Client::SendMessage(%damagedClient,1,"You've been hit with Stasis!");
		if(%armor == harmor1 || %armor == harmor2 || %armor == harmor3)
			return;
		if(%armor == armormAngel || %armor == armorfAngel || %armor == armormSpy || %armor == armorfSpy || %armor == armormNecro || %armor == armorfNecro)
			Player::setArmor(%damagedClient, "harmor1");
		else if(%armor == armormWarrior || %armor == armorfWarrior || %armor == armormBuilder || %armor == armorfBuilder)// || %armor == armormDM || %armor == armorfDM)
			Player::setArmor(%damagedClient, "harmor2");
		else if(%armor == armorTroll || %armor == armorTank || %armor == armorTitan)
			Player::setArmor(%damagedClient, "harmor3");
		%damagedClient.isStasis = true;
		schedule("Stasis::resetArmor("@ %damagedClient @", "@ %armor @");",10);
		//schedule("Player::setArmor("@ %damagedClient @", "@ %armor @");",5);
		//schedule("UnstasisMsg("@ %damagedClient @");",5);
	}
	//end stasis	
	if(Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient) || $Deathmatch)
	{
		if(%type == $DisarmDamageType) 
		{
			Player::trigger(%this, $WeaponSlot, false);
			%weaponType = Player::getMountedItem(%this,$WeaponSlot);
			if(%weaponType != -1)
				Player::dropItem(%this,%weaponType);
			Client::sendMessage(Player::getClient(%damagedClient),0,"Your have been hit by a disarm spell!");
		}
	}
//-----------	other special damage			
	if(%shooterTeam != %targetTeam || $Server::TeamDamageScale || Player::getClient(%this) == %object)
	{	
		if(%type == $PlasmaDamageType)
			eval(%armor @ "::onBurn(" @ %damagedClient @ ", " @ %this @ ");");							
		else if(%type == $ShockDamageType)
			eval(%armor @ "::onShock(" @ %damagedClient @ ", " @ %this @ ");");
		else if(%type == $PoisonDamageType && !$Annihilation::NoPlayerDamage)
			eval(%armor @ "::onPoison(" @ %damagedClient @ ", " @ %this @ ");");
	}
			

// end special ----------------------------------------- 

	//==== yep, more stuff for invulnerability, jail, and admin -Plasmatic
		
	if($debug)
		echo("damage? cl ",%damagedClient," pl ",%this," inv ",%this.invulnerable ," no dam ", $Annihilation::NoPlayerDamage, " frozen ",%this.frozen ," jailed ",$jailed[%player]);

	if(%this.invulnerable || $Annihilation::NoPlayerDamage || %this.frozen || $jailed[%this])
	{
		if($debug)
			echo("No Damage");
			
		// no damage, just play a shield.
		%thisPos = getBoxCenter(%this);
		%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
		GameBase::activateShield(%this,%vec,%offsetZ);
		return;
	}
	//================

	if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) 
	{
		if(%shooterClient != -1) 
		{
			%curTime = getSimTime();
			if((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0) 
			{
				if(%type != $MineDamageType) 
				{
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
					Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
				}
				else
				{
					Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
					Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
				}
				%this.LastHarm = %shooterClient;
				%this.DamageStamp = %curTime;
			}
		}
		%friendFire = $Server::TeamDamageScale;
	}
	else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
		%friendFire = $Server::TeamDamageScale;
	else
		%friendFire = 1.0;
	if(!Player::isDead(%this)) 
	{
		//More damage applyed to head shots sniper rifle
		if(%vertPos == "head" && (%type == $SniperDamageType || %type == $LaserDamageType))	//3.x fix, added sniper damage. See below. -Plasmatic 
		{
			if(%armor == "armorTroll" || %armor == "armorTank" ||  %armor == "armorTitan") 	// -plasmatic
			{
				if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 
					{
						%value += (%value * 0.45);	//0.3
					}
				}
				else 
				{
					%value += (%value * 0.55);	//0.3
				}
			}
			// 3.x fix. This was being skipped before. See above. 
			//rail and pbeam do more damage to players than objects, + more for head shot.. -plasmatic
			if(%type == $SniperDamageType) 
			{
				if(%vertPos == "head")
				{
					if(%armor == "armorTroll" || %armor == "armorTank" ||  %armor == "armorTitan") 	// -plasmatic
					{
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") 
						{
							%value += (%value * 0.3);	//head shot to heavy
						}
					}
					else 
					{
						%value += (%value * 0.35);	//med/ light head shots
					}
				}
				else %value += (%value * 0.27);// adding 27% to any other shot
			}			
			
			
			//If Shield Pack is on
			if(%type != -1 && %this.shieldStrength) 
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				if(%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if(%type == $ElectricityDamageType)
					%strength *= 0.0;
				%absorb = %energy * %strength;
				if(%value < %absorb) 
				{
					GameBase::setEnergy(%this,%energy - ((%value / %strength)*%friendFire));
					%thisPos = getBoxCenter(%this);
					%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
					GameBase::activateShield(%this,%vec,%offsetZ);
					%value = 0;
				}
				else 
				{
					GameBase::setEnergy(%this,0);
					%value = %value - %absorb;
				}
			}
			%value = $DamageScale[%armor, %type] * %value * %friendFire;
			// moved this up here so we can skip this if no damage -plasmatic 2.2			
			if(%value) 
			{
				//%value = $DamageScale[%armor, %type] * %value * %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
				%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				// notifying shooter they hit something..
				if(%object != 0 && %damagedClient != %object && !%object.lastDamageSound)
				{		
					Client::sendMessage(%object, 0, "~wButton3.wav");
					%object.lastDamageSound = true;
					schedule(%object@".lastDamageSound = false;",0.0125);	
				}				
				
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this))
				{
				//	if(%damagedClient.lastDamage < getSimTime())
				//	{
						// left over from base, these sounds don't exist.. -plasmatic	
						//	%sound = radnomItems(3,injure1,injure2,injure3);
						//	playVoice(%damagedClient,%sound);
						//	%damagedClient.lastdamage = getSimTime() + 1.5;
						
				//	}
				
					
				}
				else
				{
				
					//added pbeam massive kills also
					if(%spillOver > 0.35 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType) || %spillOver > 1.5 && %type == $SniperDamageType)
					{
						Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
						if($Annihilation::blood)
							player::blood(%this);	
						Player::blowUp(%this);
					}
					else
					{
						if((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) )
						{
							if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this)) 
							%curDie = $PlayerAnim::Crouching;
						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
							else
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if(%vertPos == "torso")
						{
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if(%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%shooterObject && !Player::isAiControlled(%shooterObject))
					{
						//v mod -plasmatic
						if(%InAir > 10 && %damagedClient != %shooterClient)
						{
							bottomprint(%shooterClient, "<f1><jc>M i d   a i r   h i t !");
								
						}
											
						remoteeval(%shooterClient,MaHitReport, %dist, %damagedClient, %InAir);	// v mod -plasmatic
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")
						%shooterClient = %object.clLastMount;
					if(%damagedClient != -1)
						Client::onKilled(%damagedClient,%shooterClient, %type);
					else 
						schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);	//necro bot..
				}
			}
		}
//	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

// Body blocking by Plasmatic..
// billiards game type anyone?... -Plasmatic
function Player::onCollision(%this,%obj)
{	
	if($debug) 
		event::collision(%this,%obj);
	if(%obj.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;
	//echo("player::oncollision "@getObjectType(%obj));
	//body blocking -Plasmatic
	if(getObjectType(%obj) == "Player")
	{
		//player colliding with another player
		if(Player::isDead(%obj))
		{
			//Kick dat corpse..  -Plasmatic
			%thisVel = Item::getVelocity(%this);	
			%objVel = Item::getVelocity(%obj);
			Item::setVelocity(%obj, %thisVel);
		}	
		else if(Player::isDead(%this)) 
		{
			// Dead players transfer all items to the live player
			%sound = false;
			%max = getNumItems();
			for(%i = 0; %i < %max; %i = %i + 1) 
			{
				%count = Player::getItemCount(%this,%i);
				if(%count) 
				{
					%delta = Item::giveItem(%obj,getItemData(%i),%count);
					if(%delta > 0) 
					{
						Annihilation::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			if(%sound) 
			{
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}			
		else
		{
			// 2 live players colliding. Annihilation stuff. 
			%cliendId = Player::getClient(%obj);
			%thisId = Player::getClient(%this);
			%armor = Player::getArmor(%obj);
			eval(%armor @ "::onPlayerContact(" @ %this @ ", " @ %obj @ ");");	//fixed in 3.0 1/27/2005 6:03AM -Plasmatic
			
			if(GameBase::getTeam(%obj) == GameBase::getTeam(%this))
			{
				if(%this.cloaked > 0)
				{
					//pop this player visible for a second -plasmatic
					GameBase::startFadein(%this);	
					%this.cloaked = "";
				}
			}			
			// Body slamming with 2 live players -Plasmatic
			if(getSimTime() - %this.lastImpact < 1 && getObjectType(%obj) == "Player")
			{
				%Tm = player::getarmor(%this).mass;
				%Om = player::getarmor(%obj).mass;
				%m = %tm/%om;	//weight ratio between armors
				
				%vel = vector::multiply(%this.lastVel,%m@" "@%m@" "@%m);
				%speed = vector::getdistance("0 0 0",%vel);
						
				if(%speed > 100)
				{
					// Tackle deaths.
					playSound(shockExplosion,GameBase::getPosition(%this));
				//	GameBase::playSound(%player, shockExplosion, 0);
				//	Item::setVelocity(%obj,0);				
					%dead = Client::getName(GameBase::getControlClient(%obj));
					%killer = Client::getName(GameBase::getControlClient(%this));
					Item::setVelocity(%obj,"0 0 1");
					if($Annihilation::blood)
						Player::blowUp(%obj);	
					player::blood(%obj);	
					Player::kill(%obj);
					%message = %killer @ " tackled " @ %dead @" to death at "@%speed @"mph";
					echo(%message);
					messageall(0,%message);
					Player::setAnimation(%obj,$animNumber++);
										
					return;
				}
				else if(%speed > 65)
					playSound(soundArmorCrunch,GameBase::getPosition(%this));		
				else if(%speed > 45)
					playSound(soundArmorCrash,GameBase::getPosition(%this));
				else if(%speed > 25)	{}
				else if(%speed > 10)
					playSound(soundArmorSmack,GameBase::getPosition(%this));
				else 	
					playSound(soundArmorSlap,GameBase::getPosition(%this));
			
				Item::setVelocity(%obj,%vel);
			//	messageall(1,"bam? "@%m@", "@%speed@", "@%impactsound);				
			}		
		}
	}
	else
	{
		//player collision with something besides a player
		if(!Player::isDead(%this))
		{
			if(GameBase::getTeam(%obj) == GameBase::getTeam(%this))
			{
				if($ArmorName[Player::getArmor(%this)] == iarmorBuilder)		
				{
					
					if(GameBase::getDamageLevel(%obj))
					{
						%this.repairTarget = %obj;	
						GameBase::repairDamage(%obj, 0.07);
						GameBase::playSound(%this, ForceFieldOpen,0);
					}
					else if(%this.repairTarget == %obj)
					{
						//we repaired this last, eh?
						RepairRewards(%this);	
					}
				}
			}	
		}
		else
		{
			//dead player health kit?
		}			
	}
}


function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	
	//overhauled by Plasmatic to remove faulty droid/ OSMissile/ observer targeting
	%client = Player::getClient(%this);
	%control = Client::getControlObject(%client);
	if(%control != %this)
	{
		%data = gamebase::getdataname(%control);
		if(%data == false || %client.observerMode == "observerAdmin")		
			return 0.0;
		
		if(%data == ProbeDroid || %data == SuicideDroid || %data == SurveyDroid || %data == OSMissile)
			return 0.0;
				
		else	return 1.0;
	}
	
	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if((%lastTime + 1.5) < %time) 
	{
		return 0.0;
	}
	else 
	{
		%diff = %time - %lastTime;
		%heat = 1.0 - (%diff / 1.5);
		return %heat;
	}
}

function Player::jump(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1)
	{
		%vehicle = Player::getMountObject (%this);
		%this.lastMount = %vehicle;
		%this.newMountTime = getSimTime() + 3.0;
		Player::setMountObject(%this, %vehicle, 0);
		Player::setMountObject(%this, -1, 0);
		Player::applyImpulse(%pl,%mom);
		playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	}
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{
	if(!evalspam(%client))
		return;	//plasm 3.0
		
	if(!$matchStarted)
		return;
//plasmatic		
//echo(%client);
	%player = Client::getOwnedObject(%client);
	if(%player.frozen == true || $jailed[%player] == true)
	{
		client::sendmessage(%client,2,"WARDEN: Not on my watch son...");
		return;
	}
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack) 
		{
			Player::unmountItem(%player,$BackpackSlot);
			%obj = newObject("","Mine","Suicidebomb");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
		}
		else 
		{
			//%mass = Player::getArmor(%player).mass;.maxEnergy
			if(GameBase::getEnergy(%Player)*1.05 >= Player::getArmor(%player).maxEnergy)
			{
				GameBase::playSound(%player, shockExplosion, 0);
				Player::trigger(%player, $WeaponSlot, false);
				%weaponType = Player::getMountedItem(%player,$WeaponSlot);
				if(%weaponType != -1)
					Player::dropItem(%player,%weaponType);
				Item::setVelocity(%player,vector::add(Item::getVelocity(%player),"0 0 1"));
				if($Annihilation::blood)
					player::blood(%player);		
				Player::blowUp(%player);	
						
			}
			else		
				playNextAnim(%client);
				
			Player::kill(%client);
			Client::onKilled(%client,%client);
		}
		//new here to clean up droids -2.2 plasmatic
		if(%client.droid)
		{
			%obj = %client.droid;
			GameBase::setDamageLevel(%obj,1);	
		}
	}
	schedule("Client::clearItemShopping("@%client@");",0.5);	

}
function player::shockwave(%player)
{
	//Plasmatic, no bogarting. 1/11/2006 11:38AM
	if(!Player::isDead(%player) && !%player.hasPhaseShifted)	//No more shockwave for necro phase shifting. 7/21/2006 5:12AM Plasmatic
	{
		%pos = getboxcenter(%player);
	
		%vel = Item::getVelocity(%player);
		if(vector::getdistance(%vel,"0 0 0") < 1)
			%vel = vector::getfromrot(gamebase::getrotation(%player),-1);
		%obj = newobject("", "item", "RepairKit", 1, false);	//getObjectByTargetIndex(0);	//
		%start = vector::add(%pos,vector::normalize(vector::neg(%vel)));
		%proj = Projectile::spawnProjectile("ShockwaveEffect","0 0 0 "@ vector::normalize(%vel) @" 0 0 1 "@%start,%obj,%vel);
		deleteobject(%obj);	
	}
}
$animNumber = 25;
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;
	Player::setAnimation(%client,$animNumber++);
}
function Client::takeControl(%clientId, %objectId)
{
	// remote control
	if(%objectId == -1)
	{
		//echo("objectId = " @ %objectId);
		return;
	}

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
		//echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		//echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	if(GameBase::getDamageState(%objectId) != "Enabled")
		return;

	Turret::onAttemptControl(%objectId, %clientId);

	//%name = GameBase::getDataName(%objectId);
	//if(%name != CameraTurret && %name != DeployableTurret)
	//{
	//	if(!GameBase::isPowered(%objectId)) 
	//	{
	//		// echo("Turret " @ %objectId @ " not powered.");
	//		return;
	//	}
	//}
	//if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
	//	!$TestCheats) {
	//	Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
	//		return;
	//}
	//if(GameBase::getDamageState(%objectId) == "Enabled") {
	//	Client::setControlObject(%clientId, %objectId);
	//	Client::setGuiMode(%clientId, $GuiModePlay);
	//}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
	if(!evalspam(%client))
		return;	//plasm 3.0		
	%objectIdx = Ann::Clean::string(%objectIdx);
	if(%objectIdx < 128)	// 10/2/2007 8:34AM Target Index fix -Plasmatic
		Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject)
	{
		if(%ownedObject == -1 || %ctrlObject == -1)
			return;
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
			return;
		Client::setControlObject(%clientId, %ownedObject);
	}
	GameBase::virtual(%ctrlObject, onDismount, %ctrlObject, %clientID);
}

function player::onTrigger(%this,%object,%trigger)
{
messageall(1,"trigger player, bitch");
}