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
}

function Player::onRemove(%this)
{
	for (%i = 0; %i < 8; %i = %i + 1)
	{
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) 
		{
			// Note: Player::dropItem is not called here.
			%item = newObject("","Item",%type,1,false);
         		schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
         		addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	if($debug) echo("No ammo for weapon ",%itemType.description," slot(",%imageSlot,")");
}

function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if($debug)
	{
		echo("Damaging player " @ %this);
		echo("type, value, pos, vec, mom, vertPos, quadrant, object");
		echo(%type @", "@ %value @", "@ %pos @", "@ %vec @", "@ %mom @", "@ %vetPos @", "@ %quadrant @", "@ %object);
	}

	%damagedClient = Player::getClient(%this);
	%shooterClient = %object;

	//=== The below code relates to special damage types for turret projectiles.  If it is from a deployed turret and the
	//===  original deployer has switched teams it will make it so the damage does not lead back to them
	if(%type >= 99 || %type == $LaserDamageType) //=== Laser Beams cannot have their damage type overridden
	{
		%client = Player::getClient(%object);
		if(%client > 0 && !$Shifter::DeathMatch)
		{
			if($InfTime[%client] > 0 && %client.origTeam != "")
				%team = %client.origTeam;
			else
				%team = Client::getTeam(%client);

			if($InfTime[%damagedClient] > 0 && %damagedClient.origTeam != "")
				%dteam = %damagedClient.origTeam;
			else
				%dteam = Client::GetTeam(%damagedClient);

			if(%team == %dteam || %damagedClient == %client)
			{
				if(%type == $LaserDamageType)
				{
					if((Player::getMountedItem(%object,$WeaponSlot) != LasCannon && Player::getMountedItem(%object,$WeaponSlot) != LaserRifle) || %damagedClient == %client)
					{
						%object = 0;
						%shooterClient = 0;	
					}
					else if(!Player::isTriggered(%object,$WeaponSlot))
					{
						%object = 0;
						%shooterClient = 0;
					}
				}
				else
				{
					%object = 0;
					%shooterClient = 0;
				}
			}
		}
		if(%type >= 99) %type -= 100;

		//== Any turrets that do plasma damage might as well set you on fire
		if(%type == $PlasmaDamageType) %type = $FlareDamageType;
	}

	if(%damagedClient)
		if(%damagedClient.obsposs != "" && %damagedClient.obsposs != False)
			return;

	if(%type == $DeSupressDamageType)
	{
		if(Player::getSensorSupression(%this) >= 30)
		{
			Player::setSensorSupression(%this,Player::getSensorSupression(%this)-1);
			if(Player::getSensorSupression(%this) < 30)
				Client::sendMessage(%damagedClient,1,"You have been detected by an enemy camera!~waccess_denied.wav");
		}
		return;
	}

	if(%type == $FlareDamageType)
	{
		%armor = Player::getArmor(%this);

		if(%armor != "barmor" && %armor != "bfemale")
		{
			if(Player::getClient(%object) > 0)
				%damagedClient.burner = Player::getClient(%object);
			Renegades_startBurn(%damagedClient, %this);
			if($BurnTime[%damagedClient])
				$BurnTime[%damagedClient] += 30;
		}

		Gamebase::ApplyDamage(%this,$PlasmaDamageType,%value,%pos,%vec,%mom,%object);

		if(Gamebase::getTeam(%damagedClient) != Gamebase::getTeam(%shooterClient))
		{
			$Cloaktime[%damagedClient] = 0;
			if(Player::getMountedItem(%this,$BackPackSlot) == CloakingDevice)
			{
				Player::trigger(%this,$BackPackSlot,false);
			}
		}
		return;
	}

	if (%type == $CloakDamageType)
	{

		if(Gamebase::getTeam(%damagedClient) == Gamebase::getTeam(%shooterClient))
		{
			Renegades_startCloak(%damagedClient, %this);
			$cloakTime[%damagedClient] = 90;
			return;
	        }
		else
		{
			if($Cloaktime[%damagedClient] != 0)
			{
				$Cloaktime[%damagedClient] = 0;
				Gamebase::startFadeIn(%this);
			}
			if(Player::getMountedItem(%this,$BackPackSlot) == CloakingDevice)
			{
				Player::trigger(%this,$BackPackSlot,false);
			}
			return;
		}
	}

	//=== Railgun REALLY hurts everyone but Engineers
	if(%type == $RailDamageType && $ArmorName[Player::getArmor(%this)] != "EngArmor")
		%value *= 1.2; 

	if(%object > 0)
		if (getObjectType(%object) == "Player")
			%shooterClient = Player::getClient(%object);
	else
	{
		//== Missile locks that occured because of fire effects and are otherwise unclaimed go to whoever started the burn
		if(%type == $MissileDamageType && $burnTime[%damagedClient] > 0 && %damagedClient.burner > 0)
			%shooterClient = %damagedClient.burner;
	}

	if(%damagedClient)
	{
		//=== If a player has just been flung via Grav Gun, the player who did the Grav-ing does the damage
		if(%type == $LandingDamageType && %damagedClient.gravTime > 0 && %damagedClient.gravSource > 0)
		{
			%shooterClient = %damagedClient.gravSource;
			%object = Client::getOwnedObject(%shooterClient);
			%type = $GravDamageType;
		}
	}

	if (%shooterClient)
	{
		%damagedClient.lastdamager = %shooterClient;
		%steam = Client::getTeam(%shooterClient);
	}

	if(%damagedClient)
		%dteam = Client::getTeam(%damagedClient);
	else
		%dteam = GameBase::getTeam(%this);

	if($InfTime[%shooterClient] > 0 && %shooterClient > 0 && %shooterClient.origteam)
		%steam = %shooterClient.origteam;
	if($InfTime[%damagedClient] > 0 && %damagedClient.origteam)
		%dteam = %damagedClient.origteam;

	if(%type == $ELFDamageType && $ELFDamageType != 0) //In case someone forgot to set the global variable
	{
		if(%dteam != %steam || %damagedClient == %shooterClient || $Server::TeamDamageScale > 0)
		{
			%darmor = Player::getArmor(%this);
			if(%darmor != "aarmor" && %darmor != "afemale")
			{
				%enval = GameBase::getEnergy(%this);
				%enval -= (%darmor.maxEnergy * %value);
				if(%enval < 0)
					%enval = 0;
				GameBase::setEnergy(%this,%enval);
			}

			Gamebase::ApplyDamage(%this,$ElectricityDamageType,%value,%pos,%vec,%mom,%object);
		}
		return;
	}

	if($debug) echo("Part 1 of Damage calc complete");

	if (Player::isExposed(%this))
	{
		if($debug) echo("Part 2 initiated");
		Player::applyImpulse(%this,%mom);
		//======================================================================== Determine Team Damage
		if($teamplay && %damagedClient != %shooterClient && %dteam == %steam) //Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) )
		{
			if (%shooterClient)
			{
				%curTime = getSimTime();

			   if ((%curTime - %this.DamageStamp > 1.5 || %this.LastHarm != %shooterClient) && (%type != $GravDamageType) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0 && %type != DeCloakDamageType) //%curTime - %this.DamageTime > 1.5 
			   {
					if(%type != $MineDamageType)
					{
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
			            		%shooterClient.score = (%shooterClient.score -1);
						if ($ScoreOn) bottomprint(%shooterClient, "You harmed your team mate... Score -1 = " @ %shooterClient.score @ " Total Score");
					}
					else if(%dteam == Client::getTeam(%damagedClient))
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
		else
		{
			if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
				%friendFire = $Server::TeamDamageScale;
			else  
				%friendFire = 1.0;
		}
		if($debug) echo("Continuing part 2");
		//============================================================== Reaction Damage
		if ($Shifter::Reactions)
		{
			if(%vertPos == "torso")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient,%kick, (%kick/2));
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient, -%kick, (%kick/2));

					if (%kick > 45 && Player::getArmor(%this) != "jarmor")
					{
						%item = Player::getMountedItem(%damagedClient,$BackpackSlot);
						Player::dropItem(%damagedClient,%item);
						if(%item.description != false)
							Client::sendMessage(%shooterClient,0,"You knocked the " @ %item.description @ " off of " @ Client::getName(%damagedClient) @ "'s back!");
					}
				}
			}
			else if (%vertPos == "legs")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 150);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 200);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
			}
			else if (%vertPos == "head")
			{
				if(%quadrant == "front_right" || %quadrant == "front_left")
				{
					%kick = (%value * 50);
					ixApplyKickback(%damagedClient,%kick, %kick);
				}
				else if(%quadrant == "back_right" || %quadrant == "back_left")
				{
					%kick = (%value * 100);
					ixApplyKickback(%damagedClient, -%kick, -%kick);
				}
			}
		}

//============================================================================= More Damage To Head Shots
		if (!Player::isDead(%this))
		{
			if($debug) echo("Part 3 initiated.  Player is not dead.");
			%armor = Player::getArmor(%this);
			
			if(%vertPos == "head")
			{
				if (%type == $LaserDamageType || %type == $SniperDamageType || %type == $RailDamageType)
				{
					%value += %value;
					if(%type == $SniperDamageType) //== All your Sniper Rifles are belong to... one shot... headshot... kills... ... yeah.
					{
						%value *= 1.5;
					}
				}
				else
				{
					if(%armor == "harmor")
					{ 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
						{
							%value += (%value * 0.2);
						}
					}
					else
					{
						%value += (%value * 0.5);
					}
				}
			}
			
//============================================================================= Shield Pack On
			if (%type != -1 && %type != 16 && %type != 17 && %type != 26 && %this.shieldStrength)
			{
				%energy = GameBase::getEnergy(%this);
				%strength = %this.shieldStrength;
				
				if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
					%strength *= 0.75;
				if (%type == $RailDamageType)
					%strength *= 0.5;
				if (%type == $ElectricityDamageType)
					%strength *= 0.0;

				%absorb = %energy * %strength;
				
				if (%value < %absorb)
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

//============================================================================= Flash Damage Does EMP Effect

			if((%type == $FlashDamageType || %type == $NukeDamageType) && ((%dteam == %steam && $Server::TeamDamageScale != 0) || %dteam != %steam || %damagedClient == %shooterClient))
			{	%weapon = Player::getMountedItem(%this,0);				
				Insomniax_startEMP(%damagedClient, %this, 14);
//				%emptime = (%value * 10);
//				if ($debug) echo ("Emp Time = " @ %emptime);
				if(Player::isAIControlled(%this) && %weapon)
					schedule("Player::mountItem("@%this@","@%weapon@",0);",floor(getRandom()*2) + 1); //schedule("AI::reMountAfterEMP("@%damagedClient@","@%weapon@");",floor(getRandom()*2)+1); //
			}
//============================================================================= Juggernaught Shield
			%armor = Player::getArmor(%this);
			if ((%armor == "jarmor") && (!%this.shieldStrength))
				Renegades_startShield(%damagedClient, %this);

//============================================================================= Cloaking Blast

			if(%type == $DeCloakDamageType)
			{
				if(Gamebase::getTeam(%damagedClient) != %steam) //Gamebase::getTeam(%shooterClient))
				{
					$Cloaktime[%damagedClient] = 0;
					if(Player::getMountedItem(%this,$BackPackSlot) == CloakingDevice && Player::isTriggered(%player,$BackPackSlot))
					{
						Player::trigger(%this,$BackPackSlot,false);
					}
					Gamebase::startFadeIn(%this);
				}
			}

//============================================================================= Life Drain - Poison

			if ((%type == $EnergyDamageType) && %value > 0 && (%steam != %dteam || $Shifter::DeathMatch)) //&& (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient))
			{
				%armor = Player::getArmor(%this);
				if ((%armor != "aarmor") && (%armor != "afemale"))
				{
					Renegades_startBlind(%damagedClient, %this);
					if(%shooterClient > 0)
						%damagedClient.poisoner = %shooterClient;
				}
			}

			//=== Once the poison effects have kicked in we can convert the re-poison type to normal for the purposes of death messages
			if(%type == $PoisonDamageType) %type = $EnergyDamageType;

//============================================================================= Grav Damage 
			if (%type == $GravDamageType)
			{
				//Pointless, since in order for this section to take effect a separate onDamage function
				// must be coded for the projectile and Grav effects have already been put there
			}
//============================================================================= Plasma Damage Catches Player On Fire

			if (((%type == $PlasmaDamageType) || (%type == $NukeDamageType)) && (Client::getTeam(%damagedClient) != %steam || $Shifter::DeathMatch) && %value > 0) //Client::getTeam(%shooterClient)))
			{
				%rnd = floor(getRandom() * 10);
				if(%rnd > 7 || Player::getArmor(%object) == "barmor" || Player::getArmor(%object) == "bfemale")
				{
					%armor = Player::getArmor(%this);
					if ((%armor != "barmor") && (%armor != "bfemale"))
					{
						if(%shooterClient > 0)
							%damagedClient.burner = %shooterClient;
						Renegades_startBurn(%damagedClient, %this);
					}
				}
			}

			//=== Similarly, convert re-burn damage type to plasma for the purposes of death messages
			if(%type == $ReFireDamageType) %type = $PlasmaDamageType;
//============================================================================= Body Area Damage Effects
  			if (%value) 
			{
				%armor = Player::getArmor(%this);
				%hitdamageval = 0.05;
				
				if(%armor == "harmor" || %armor == "darmor" || %armor == "jarmor")
					%hittolerance = 0.25;
				else
					%hittolerance = 0.25;

				%weaponType = Player::getMountedItem(%this,$WeaponSlot);

//============================================================================= Suicide Pack Explodes

				if((Player::getMountedItem(%this,$BackpackSlot) == SuicidePack))
				{						
					if( ((%type == $LaserDamageType) || (%type == $SniperDamageType) || (%type == $BulletDamageType) || (%type == $RailDamageType)) && (%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")  && (Client::getTeam(%damagedClient) != %steam)) //Client::getTeam(%shooterClient)))
					{
						MessageAllExcept(Player::getClient(%damagedClient), 0, Client::getName(%shooterClient) @ " sniped the huge bomb on " @ Client::getName(%damagedClient) @ "'s back!");
						Client::sendMessage(Player::getClient(%damagedClient),0,"Your Suicide Pack exploded!");
						Player::unmountItem(%this,$BackpackSlot);	
						%obj = newObject("","Mine","Suicidebomb");
						%obj.deployer = %shooterClient;
						%obj.deaddeploy = true;
		 				addToSet("MissionCleanup", %obj);
						%client = Player::getClient(%this);
						GameBase::throw(%obj,%this,9 * %client.throwStrength,false);
					}
				}

//============================================================================= Weapons Drop On Sniper Shot

				if ((%vertPos == "torso") && (%quadrant == "front_right") && (%type == $LaserDamageType) && (%value > %hittolerance) && (%weaponType != -1 && %weaponType != "RepairGun") && %armor != "jarmor" && Player::getMountedItem(%shooterClient,$WeaponSlot) != "LasCannon")
				{
					Player::dropItem(%this,%weaponType);
	       		   		%dlevel = GameBase::getDamageLevel(%this) + (%value * 0.25);
					Client::sendMessage(Player::getClient(%shooterClient),0,"You shot the " @ %weaponType.description @ " out of "  @ Client::getName(%damagedClient) @ "'s hand!");
				}
				else
				{
					%value = $DamageScale[%armor, %type] * %value * %friendFire;
		        	   	%dlevel = GameBase::getDamageLevel(%this) + %value;
				}
            			
            			%spillOver = %dlevel - %armor.maxDamage;

				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				
				if (%flash > 0.75)
					%flash = 0.75;
				
				Player::setDamageFlash(%this,%flash);
				
				if(!Player::isDead(%this))
				{ 
					//=== Repair pack has "idle" effects
					if(Player::getMountedItem(%this,$BackPackSlot) == RepairPack)
						GameBase::repairDamage(%this,%value * 0.5);

					//========================= Check for flag kick on sniper shot - *IX*Savage1
					%flag = Player::getMountedItem(%this,$FlagSlot);
					if((%value > %hittolerance) && (%type == $LaserDamageType || %type == $SniperDamageType || %type == $RailDamageType) && (%quadrant == "middle_back" || %quadrant == "middle_middle") && (%vertpos == "head") && (%flag == "flag") && (Client::getTeam(%damagedClient) != Client::getTeam(%shooterClient)))
						DoTheFlagDrop(%this, %shooterClient);

					if(%damagedClient.lastDamage < getSimTime())
					{
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
					if(Player::isAIControlled(%this))
					{
						%armor = Player::getArmor(%this);
						//=== Holos autouse RepairKits
						if(%dlevel*2 >= %armor.maxDamage)
							RepairKit::onUse(%this,RepairKit);
					}
				}
				else 
				{

	           			if((%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType)) || %type == $ElectricityDamageType)
					{
						Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
						if (%type == $ElectricityDamageType) 
							playSound(ShockExplosion,GameBase::getPosition(%this));
					   	Player::blowUp(%this);
						Player::unMountItem(%this,4);
						Player::unMountItem(%this,5);
					}
					else
					{
						if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) )
						{
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						
						else if(%vertPos=="head")
						{
							if(%quadrant == "front_left" ||	%quadrant == "front_right") 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso")
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
						else if (%vertPos == "legs")
						{
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}

						//== On the offchance we get a bad animation
						if(%curDie > 37 || %curDie < 25)
							%curDie = floor(getRandom() * 13) + 25;


						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;

					if ($Shifter::AmmoBoom != "False" && %damagedClient != %shooterClient) // && Player::isAIControlled(%this) != "true")
					{
						itemfuncs::ammoboom(%this);
					}					
//					Player::setItemCount(%damagedClient, Hammer1Pack,0);
//					Player::setItemCount(%damagedClient, Hammer2Pack,0);
					Client::onKilled(%damagedClient,%shooterClient, %type, %vertPos, %quadrant);
				}
			}
		}
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

//========================================================================================================================================
//==================================================== Collisions With Players ===========================================================
//========================================================================================================================================

function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this))
	{
		%pickarmor = Player::getArmor(%object);
		%deadarmor = Player::getArmor(%this);
		
		if (getObjectType(%object) == "Player")
		{
			if(%this.isamine && GameBase::getTeam(%object) != GameBase::getTeam(%this))
			{
				%pos = GameBase::getPosition(%this);
				%obj = newObject("","Mine","HoloMine1");
				GameBase::throw(%obj,%this.droppr,0,false);
				GameBase::SetPosition(%obj,%pos);
				%this.isamine = false;
				%this.droppr = "";
				deleteobject(%this);
				return;
			}
			%sound = false;
			%max = getNumItems();
			
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%count = Player::getItemCount(%this,%i);
				%itemname = getItemData(%i);
								
				if (%itemname == "Grenade" && %pickarmor != %deadarmor)
				{
					%itemname = "";
				}
				
				if (%itemname == "Beacon" && %pickarmor == "jarmor")
				{
					%itemname = "";
				}
				
				if (%itemname == "mineammo")
				{
					if (%pickarmor == "earmor" || %pickarmor == "efemale" || %deadarmor == "earmor" || %deadarmor == "efemale")
					{
					}
					else if(($ArmorName[%pickarmor] == "ScoutArmor" || $ArmorName[%pickarmor] == "BursterArmor" || $ArmorName[%pickarmor] == "MediumArmor" || %pickarmor == "stimarmor" || %pickarmor == "stimfemale") && ($ArmorName[%deadarmor] == "ScoutArmor" || $ArmorName[%deadarmor] == "BursterArmor" || $ArmorName[%deadarmor] == "MediumArmor" || %deadarmor == "stimarmor" || %deadarmor == "stimfemale"))
					{
					}
					else if (%pickarmor != %deadarmor)
					{
						%itemname = "";
					}
				}
				
				if (%count && %itemname != "")
				{
					%delta = Item::giveItem(%object,getItemData(%i),%count);
					if (%delta > 0)
					{
						Player::decItemCount(%this,%i,%delta);
						%sound = true;
					}
				}
			}
			
			if (%sound && gamebase::getteam(%this) != gamebase::getteam(%object))
			{
				if (%deadarmor == "lfemale" || %deadarmor == "larmor")
				{
					if (%pickarmor == "lfemale" || %pickarmor == "larmor" || %pickarmor == "aarmor" || %pickarmor == "afemale")
					{
					}
					else
					{
						bottomprint(player::getclient(%object), "<jc>You are poisoned by assassins items.");
						Renegades_startBlind(player::getclient(%object), %object);
					}
				}
			}
			
			if (%sound)
			{
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	
//=================================================================================================================
// 												Werewolfs Bot stuff
//												 Dealing with Bots
//												   Bot Collision	                                          Edited By Emo1313
//=================================================================================================================

	if (Player::isAIControlled(%this) == "true" && Player::isAIControlled(%object) == "false" && (%object != "Flier") && (!Player::isDead(%this) || !Player::isDead(%object)) && ($Hologram[Player::getClient(%this),Deployer]).poss != Player::getClient(%this))
	{
		%Player1 = Player::getClient(%this);
		%Player2 = Player::getClient(%object);

		%aiId = Player::getClient(%this);
		%aiName = Client::GetName(%aiId);
		%aiTeam = Client::GetTeam(%this);	 
		%objTeam = Client::GetTeam(%object);

		echo("BOT: Collision <" @ %aiName @ " - " @ %aiId @ ">");
		
//======================================================================================================== Class Specific

		if (%aiTeam == %objTeam)                          //===== Make Sure Bot Doesnt Repair Other Teams Stuff
		{

		}

//====================================================================================== Attempt Object Move Around

		if((GameBase::testPosition(%aiId,(%posX + 2) @ " " @ (%posY + 2) @ " " @ (%posZ + 2)))  && (getObjectType(%object) != "Vehicle"))
		{	
				%targLoc = GameBase::getPosition(Client::getOwnedObject(%object));		
				%aiLoc = GameBase::getPosition(Client::getOwnedObject(%aiId));		
				%aiRotation = GameBase::GetRotation(Client::getOwnedObject(%aiId)); 
		
			   	%aiRotation = (%aiRotation + 60);
				%Length = 225;
				%Zvalue = $aiRotation;
		
				%aiVect = Vector::getFromRot(%aiRotation, %Length, %Zvalue); 			
				%rotZ = getWord(GameBase::getRotation(Client::getOwnedObject(%aiId)),2);			
				%rotZ = (%rotZ + 90);
		
				%velocity = 75;
			
				GameBase::setRotation(Client::getOwnedObject(%aiId), "0 0 " @ %rotZ);
		
				%jumpDir = Vector::getFromRot(GameBase::getRotation(%aiId),%velocity,%Zvalue);
				Vehicle::passengerJump(0,%aiId,0);		 								 		//Crude way to make players avoid obstacles
				Player::applyImpulse(%aiId, %jumpDir);
		}
		else
	      	{
			echo ( %aiId @ " Can not avoid...");
		}

	}

//=============================================================================================== End AI Collision
//=============================================================================================== Scout Steal Items

	if (getObjectType(%object) == "Player") 
	{
		if (Player::isDead(%object) || Player::isDead(%this))
		{
			return;
		}
		
		if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
		{
			%armor = Player::getArmor(%object);
			if (%armor == "sarmor" || %armor == "sfemale" || %armor == "stimarmor" || %armor == "stimfemale")
			{
				%client = Player::getClient(%object);
				%client2 = Player::getClient(%this);

				if($debug)
				{
					echo("Scout Mugging");
					echo("Mugger: " @ Client::getName(%client) @ " - " @ %client @ ".");
					echo("Victim: " @ Client::getName(%client2) @ " - " @ %client2 @ ".");
				}

				Client::sendMessage(%client,1,"You mug " @ Client::getName(%client2) @ ".");
				Client::sendMessage(%client2,1,"You have been mugged by " @ Client::getName(%client) @ "!");

				// Transfer all our items to the player and drop players pack...
				%DropPack = (Player::getMountedItem(%this, $BackPackSlot));
				Player::dropItem(%this, %DropPack) ;

				%FlagDrop = (Player::getMountedItem(%this, $FlagSlot));
				Player::dropItem(%this, %FlagDrop) ;
				
				Player::setDamageFlash(%this,0.95);
				%sound = false;
				%max = getNumItems();
	
				for (%i = 0; %i < %max; %i = %i + 1)
				{
					%count = Player::getItemCount(%this,%i);
					if (%count)
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);					
						if (%delta > 0)
						{
							Player::decItemCount(%this,%i,%delta);
							Player::unmountItem(%this,$WeaponSlot);
							%sound = true;
						}
					}
				}
				if (%sound)
				{
					playSound(SoundPickupItem,GameBase::getPosition(%this));
				}
			}		
		}
	}

//============================================================================= Eng. Medic Touch
	
		if (getObjectType(%object) == "Player") 
		{
			if (Player::isDead(%object))
			{
				return;
			}
				if (Player::isDead(%this))
				{
					return;
				}

				if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if (%armor == "earmor" || %armor == "efemale")
			      		{
						if(GameBase::getDamageLevel(%this)) 
						{
							GameBase::repairDamage(%this,0.10);
							GameBase::playSound(%this,ForceFieldOpen,0);
				      		}
					}		
				}	
			}

//============================================================================= Arbitor Death Touch
	
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
				
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);
	
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					%tarmor = Player::getArmor(%this);
					
					if ((%armor == "aarmor" || %armor == "afemale") && (%tarmor != "aarmor" && %tarmor != "afemale" && %tarmor != "marmor" && %tarmor != "mfemale")) //&& %tarmor != "larmor" && %tarmor != "lfemale" 
		    	  		{
		    	  			if($debug) echo ("Shock From " @ %armor @ " to " @ %tarmor @ ".");
						%tenergy = GameBase::getEnergy(%this);
						%penergy = GameBase::getEnergy(%object);
						GameBase::setEnergy(%object,%tenergy + %penergy);
						GameBase::applyDamage(%this,$FlashDamageType,0.25,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  
						if(GameBase::getDamageLevel(%object)) 
						{
							GameBase::repairDamage(%object,0.30);
						}
						GameBase::playSound(%this,ForceFieldOpen,0);
						Client::sendMessage(Player::getClient(%object),1,
						"You drain "  @ Client::getName(%thisId) @ "'s energy...");
					}		
				}
				else if(Gamebase::getTeam(%object) == Gamebase::getTeam(%this))
				{
					%client2 = Player::getClient(%this);
					$Emptime[%client2] = 0;
				}	
			}
	
//============================================================================= Assassin Death Touch
	
			if (getObjectType(%object) == "Player") 
			{
				if (Player::isDead(%this))
				{
					return;
				}
			
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);

				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					%tarmor = Player::getArmor(%this);
		
					if ((%armor == "larmor" || %armor == "lfemale") && %tarmor != "aarmor" && %tarmor != "afemale")
		    	  	{
						
						GameBase::playSound(%this,ForceFieldOpen,0);
						GameBase::applyDamage(%this,$EnergyDamageType,0.10,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);  		
//						%thisId.poisoner = %clientId;
						Client::sendMessage(Player::getClient(%object),1,"You death touch "  @ Client::getName(%thisId) @ ".");
				
					}		
				}	
			}

//============================================================================= Spy Disguise - Skin Snatch

			if (getObjectType(%object) == "Player") 
			{		
				%cliendId = Player::getClient(%object);
				%thisId = Player::getClient(%this);
				%tarmor = Player::getArmor(%this);

				if (Player::isDead(%object))
				{
					return;
				}
		
				if(GameBase::getTeam(%object) != GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%object);
					if ((%armor == "spyarmor" || %armor == "spyfemale") && %cliendId.skintouch != "false" && $Shifter::Infiltration != "false")
			      		{
						Shifter_startInfiltrate(%cliendId,%thisId);
					}

//=================================================================== Grey's Juggy Death from Above
					else if (%armor == "jarmor" && %tarmor != "jarmor")
 					{  
 						%tpos = GameBase::getPosition(%this); 
						%oZpos = getword(GameBase::getPosition(%object), 2);  
						%tZpos = getword(%tpos, 2) + 1.5;  

						//%armor is object  
						//echo("CRUNCHY!");  
						if(%tZpos < %oZpos)  
						{  
 							Player::blowUp(%this);
							Player::blowUp(Player::getClient(%this)); //to be sure
							Player::unMountItem(%this,4);
							Player::unMountItem(%this,5);  
 							GameBase::applyDamage(%this,$CrushDamageType,10.0,%tpos,"0 0 0","0 0 0",%object);    
 							GameBase::playSound(%object,SoundFlierCrash,0);  
 							Client::sendMessage(Player::getClient(%this),0,"CRUNCH!");  
 							Client::sendMessage(Player::getClient(%object),0,"CRUNCH!");  
 						}  
					}
				}		
			}
//========================================================================================== Eng Touch Heal All			
			%shape = (GameBase::getDataName(%object)).shapeFile;
			%name = GameBase::getMapName(%object);
			%datab = GameBase::getDataName(%object);
			
			if ($debug) echo ("DataB = " @ %datab @ ".");
			if ($debug) echo ("Shape = " @ %shape @ ".");
			if ($debug) echo ("Name  = " @ %name @ ".");
			if ($debug) echo ("This  = " @ %this @ ".");
			if ($debug) echo ("Obj   = " @ %object @ ".");
	
			if ($Shifter::EngHealAll) // && !checkhackable(%name, %shape))
			{
				if(GameBase::getTeam(%object) == GameBase::getTeam(%this))
				{
					%armor = Player::getArmor(%this);
					if (%armor == "earmor" || %armor == "efemale")
			      		{
						if(GameBase::getDamageLevel(%object)) 
						{
							GameBase::repairDamage(%object,0.10);
							GameBase::playSound(%object,ForceFieldOpen,0);
				      		}
					}		
				}
			}


		//=== In-map cactuses heal players
		if(%shape == "cactus1" || %shape == "cactus2" || %shape == "cactus3")
		{
			if(%datab != "HealingPlant" && getObjectType(%object) != "Item")
				Cactus1::onCollision(%object,%this);
		}
}

//============================================================================= Get Heat Factor

function Player::getHeatFactor(%this)
{
	//=== Hack to avoid turret not tracking vehicles.
	//=== Assumes that if we are not in the player we are
	//=== controlling a vechicle, which is not always correct
	//=== but should be OK for now.
	
	%client = Player::getClient(%this);

	//=== If the player is on fire then they DEFINITELY have a heat factor.
	if($burntime[%client] > 0 && %client > 1)
	{
//		return(($burntime[%client]/140) + 0.5);
		return 1.0;
	}

	//=== If the player is suppressed and/or wearing a Sensor Jammer pack don't bother firing at 'em
//	%pack = Player::getMountedItem(%this,$BackpackSlot);
	if(Player::getSensorSupression(%this) > 19) //%pack == DeployableSensorJammerPack || %pack == SensorJammerPack || 
		return 0;

	if ( (Client::getControlObject(%client) != %this) && (!Player::isAIControlled(%this)) && %client.possessing != "true" && %client.possessed != "true")
		return 1.0;

	%time = getIntegerTime(true) >> 5;
	%lastTime = Player::lastJetTime(%this) >> 10;

	if ((%lastTime + 1.5) < %time)
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

//============================================================================= Jump To Mount Point

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


//========================================================================================== On Kill Self
function remoteKill(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);

//============================================================================================ Suicide Pack

	if(%client.possessed == "true")
	{
		Client::sendMessage(%client,1,"Sorry, the admin is busy playing with your body.  Try again later.~waccess_denied.wav");
		return;
	}

   	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   	{
		if(Player::getMountedItem(%player,$BackpackSlot) == SuicidePack)
		{
			if($Nukecount[Gamebase::getTeam(%player)] < $Shifter::AllNukeLimit || $Shifter::LimitNukes == "false")
			{
				Player::unmountItem(%player,$BackpackSlot);	
				%client = Player::getClient(%player);
				Player::decItemCount(%player,"SuicidePack");
				%obj = newObject("","Mine","Suicidebomb");
				%obj.deployer = %client;
				addToSet("MissionCleanup", %obj);
				GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
				$TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"]++;
			}
			else
			{
				Client::sendMessage(%client,1,"Your team has used all their Det Packs for this mission.  No Det Pack for you!~waccess_denied.wav");
				Player::dropItem(%client,"SuicidePack");
			}
		}
		else if(%armor == parmor)
		{
			bottomprint(%client,"<jc>Ah ah AH!  Not so fast, Wang-boy....");
		}
		else if (%client.possessing)
		{
			doneposs(%client.poss);
			remotekill(%client.poss);
		}
		else
		{
			   playNextAnim(%client);
			   Player::kill(%client);
			   Client::onKilled(%client,%client);
		}
   	}
  
//	$animNumber = 25;

}

function penisCurse(%cl,%admin)
{
	 %armor = Player::getArmor(%cl);
	if(%admin.isSuperAdmin)
	{
		if (%armor != parmor) 
		{
			 Player::setArmor(%cl,parmor);
			 checkMaxDrop(%cl,parmor);
			 armorChange(%cl);
			 Player::setItemCount(%cl, $ArmorName[%armor], 0);
			 bottomprint(%cl,"<jc>It's Wang-tastic!",10);
			 messageAll(0, Client::getName(%cl) @ " was given one for being one by " @ Client::getName(%admin) @ ".");
	
			for(%i=0;%i<=$WeaponAmmt;%i++)
			{
			 Player::dropItem(%cl,$WeaponList[%i]);
			}
			Player::setItemCount(%cl,Hammer1Pack,0);
			Player::setItemCount(%cl,Hammer2Pack,0);
			Player::unMountItem(%cl,4);
			Player::unMountItem(%cl,5);
			 Player::setItemCount(%cl, Penis, 1);
			 Player::mountItem(%cl, Penis, $BackPackSlot);
 
		  	 if(Player::getMountedItem(%cl,$FlagSlot) != -1)
		 	 	Player::dropItem(%cl,Player::getMountedItem(%cl,$FlagSlot));
		}
		else
		{
		  	Client::sendMessage(%clientId,0,"Removing The Curse...");
			messageAll(0, "The curse has been lifted from " @ Client::getName(%cl) @ ".  The price is death!");
			Player::setArmor(%cl,aarmor);
			schedule ("Player::setArmor(" @ %cl @ ",marmor);", 0.4);
			schedule ("Player::setArmor(" @ %cl @ ",larmor);", 0.8);
			schedule ("Player::setArmor(" @ %cl @ ",harmor);", 1.1);
			schedule ("Player::setArmor(" @ %cl @ ",earmor);", 1.4);
			schedule ("Player::setArmor(" @ %cl @ ",spyarmor);", 1.7);
			Vehicle::passengerJump(0,%cl,0);	
			Player::dropItem(%cl,Penis);
		   	Player::blowUp(%cl);
			Player::unMountItem(%cl,4);
			Player::unMountItem(%cl,5);
			schedule ("Player::Kill(" @ %cl @ ");", 2.0);
			schedule ("playSound(ShockExplosion,GameBase::getPosition(" @ %cl @ "));",2.0);

		                %obj = newObject("","Mine","PenisBlast");
		                addToSet("MissionCleanup", %obj);
		                %pos = GameBase::getPosition(%cl);
	                    GameBase::setPosition(%obj, %pos);
		}
	}
	else
	{
		%admin.adminspam++;
		checkAdminSpam(%admin);	
		return;
	}
}

//=============================================================================================================

function playNextAnim(%client)
{
	if($animNumber > 36 || $animNumber < 25) 
		$animNumber = 25;		
	Player::setAnimation(%client,$animNumber++);
}



function Client::takeControl(%clientId, %objectId)
{
	if(%objectId == -1)
	{
		return;
	}
	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{
		return;
	}
	if(GameBase::getControlClient(%objectId) != -1)
	{
		echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	
        %player = Client::getOwnedObject(%clientId);
        %name = GameBase::getDataName(%objectId);
        %armor = Player::getArmor(%clientId);
        
        if(Player::getMountedItem(%player,$BackpackSlot) != Laptop) // && (%armor != "sarmor" || %armor != "sfemale" ))
        {
                if (!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && GameBase::getDataName(%objectId) != DeployableHolo && GameBase::getDataName(%objectId) != DeployableHolo2 && GameBase::getDataName(%objectId) != DeployableMini && GameBase::getDataName(%objectId) != DeployableSatchel && !$TestCheats && GameBase::getDataName(%objectId) != CloakCameraTurret)
                {
                        Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
                        return;
                }
        }

   	if(GameBase::getDamageState(%objectId) == "Enabled") 
   	{
   		Client::setControlObject(%clientId, %objectId);
   		Client::setGuiMode(%clientId, $GuiModePlay);
		%clientId.contrling = %objectId;
		CheckObservers(%clientId,%objectId); //added
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
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
	UnCheckObservers(%clientId); //added
	%clientId.contrling = "";
   }
}

//============================================================================= EMP Effects

function Insomniax_startEMP(%clientId, %player, %time)
{
	if(%clientId.EMPMessageTime < getSimTime() || !%clientId.EMPMessageTime)
	{
		Client::sendMessage(%clientId,1,"You were hit with EMP!");
		%clientId.EMPMessageTime = getSimTime() + 0.5;
	}
	Player::unmountItem(%player,$WeaponSlot);
	%pack = Player::getMountedItem(%player,$Backpackslot);
	%armor = player::getarmor(%player);

	if($empTime[%clientId] <= 0)
	{
		//=== Whole bunch of special cases here
		Player::trigger(%player,6,false); //Juggy Energy Beacon should be turned off
		//=== First, Players with energy pack
		if (%pack == "EnergyPack")
		{
			%energy = Gamebase::getEnergy(%player);
			//=== ...in Engineer armor
			if(%armor == earmor || %armor == efemale)
			{
				GameBase::setRechargeRate(%player,3);
				GameBase::setEnergy(%player,45);
				$empTime[%clientId] = 8;
			}
			//=== ...and not
			else
			{
				GameBase::setRechargeRate(%player,2);
				GameBase::setEnergy(%player,15);
				$empTime[%clientId] = 12;
			}
		}
		//=== And now the players without energy packs
		else if (%armor == earmor || %armor == efemale)
		{
			GameBase::setEnergy(%player,45);
			GameBase::setRechargeRate(%player,2);
			$empTime[%clientId] = 8;
		}
		else
		{
			GameBase::setEnergy(%player,0);
			GameBase::setRechargeRate(%player,0);
			$empTime[%clientId] = 12;
		}
		checkPlayerEMP(%clientId, %player);
	}
	else
	{
		if (%time)
			$empTime[%clientId] = %time;
		else
			$empTime[%clientId] = 14;

//		if(%pack == "EnergyPack")
//		{
//			if((%armor == earmor || %armor == efemale) && GameBase::getRechargeRate(%player) > 3)
//				checkPlayerEMP(%clientId,%player);
//			else if(GameBase::getRechargeRate(%player) > 2)
//				checkPlayerEMP(%clientId,%player);
//		}
//		else
//		{
//			if((%armor == earmor || %armor == efemale) && GameBase::getRechargeRate(%player) > 2)
//				checkPlayerEMP(%clientId,%player);
//			else if(GameBase::getRechargeRate(%player) > 0)
//				checkPlayerEMP(%clientId,%player);
//		}
	}
	$CloakTime[%clientId] = 0;
}

// This checks the current Status of EMP Effect on the player - *IX*Savage1

function checkPlayerEMP(%clientId, %player)
{
	%pack = Player::getMountedItem(%player,$Backpackslot);
	%armor = player::getarmor(%player);
	if($empTime[%clientId] > 1) //0)
	{
		$empTime[%clientId] -= 2;
		if($empTime[%clientId] <= 0)
			$empTime[%clientId] = 1;
		if(%pack != "EnergyPack")
		{
			if(%armor == "earmor" || %armor == "efemale")
			{
				Gamebase::setRechargeRate(%player,2);
			}
			else
			{
				GameBase::setRechargeRate(%player,0);
			}
		}
		else
		{
			if(%armor == "earmor" || %armor == "efemale")
			{
				Gamebase::setRechargeRate(%player,3);
			}
			else
			{
				GameBase::setRechargeRate(%player,2);
			}
		}
		schedule("checkPlayerEMP(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
	else
	{
		$empTime[%clientId] = 0;
		Client::sendMessage(%clientId,1,"EMP Effects have dissapated.");
		%clientId.EMPMessageTime = 0; //shouldn't be needed, but just in case
		GameBase::setRechargeRate(%player,8);
	}			
}

//============================================================================= Poisoning

function Renegades_startBlind(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are poisoned!");
	if($poisonTime[%clientId] == 0)
	{
		
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 15;
		checkPlayerBlind(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 15;
}


function checkPlayerBlind(%clientId, %player)
{
	if($poisonTime[%clientId] > 0)
	{
		$poisonTime[%clientId] -= 2;  
//		%drrate = GameBase::getDamageLevel(%player) + 0.07;
			if  (!Player::isDead(%player)) 
			{
//				GameBase::setDamageLevel(%player, %drrate);  
				GameBase::applyDamage(%player,$PoisonDamageType,0.1,GameBase::getPosition(%player),"0 0 0","0 0 0",%clientId.poisoner);  				
				Player::setDamageFlash(%player,0.75);  
				if  (Player::isDead(%player))
				{
//					messageall(0, Client::getName(%clientId) @ " died from a strange disease.");
//					%clientId.scoreDeaths++;
//			      		%clientId.score--;
//					Game::refreshClientScore(%clientId);
					$poisonTime[%clientId] = 0;
				}
			}
			else
			{
				%clientId.poisoner = "";
				$poisonTime[%clientId] = 0;
			}
		

		schedule("checkPlayerBlind(" @ %clientId @ ", " @ %player @ ");",5,%player);
	}
	else
	{
		Client::sendMessage(%clientId,1,"The effects of the poison wear off.");		
	}			
}

//============================================================================= Flamer Burn

function Renegades_startBurn(%clientId, %player)
{
	Client::sendMessage(%clientId,1,"You are on fire!");
	
	if($burnTime[%clientId] == 0)
	{
		Player::setDamageFlash(%player,0.25);//.50
		$burnTime[%clientId] = 60;
		checkPlayerBurn(%clientId, %player);
	}
	else
		$burnTime[%clientId] = 70;
}

function checkPlayerBurn(%clientId, %player)
{
	if($burnTime[%clientId] > 0)
	{
		%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
		%vel = Item::getVelocity(%player);

		$burnTime[%clientId] -= 1;
		%damage = 0.001 + ((floor(getRandom() * 10) + 1) * 0.0002);
		%drrate = (GameBase::getDamageLevel(%player) + %damage); //0.001 + (floor(getRandom() * 10) * 0.0001)); //*10
		if  (!Player::isDead(%player)) 
		{
			//Visible burn effects, stolen from Shifter2k4
			if($burnTime[%clientId] >= 30)
				Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %vel);
			else
				Projectile::spawnProjectile("JetSmoke", %trans, %player, %vel);

//			GameBase::setDamageLevel(%player, %drrate);  
//			Player::setDamageFlash(%player,0.25);
			Player::setDamageFlash(%player,Player::getDamageFlash(%player) + 0.01);  
			GameBase::applyDamage(%player,$ReFireDamageType,%damage,GameBase::getPosition(%player),"0 0 0", "0 0 0", %clientId.burner);
			if  (Player::isDead(%player))
			{
//				messageall(0, Client::getName(%clientId) @ " was incinerated.");
//				%clientId.scoreDeaths++;
//      			%clientId.score--;
//				Game::refreshClientScore(%clientId);
				$burnTime[%clientId] = 0;
				%clientId.burner = "";
			}
		}
		else
		{
			$burnTime[%clientId] = 0;
			%clientId.burner = "";
		}
		schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");",0.1,%player);// 1,%player);
     	}
	else
	{
		%clientId.burner = "";
		$burnTime[%clientId] = 0;
		Client::sendMessage(%clientId,1,"You stop burning.");
	}			
}

//============================================================================= Chemeleon Infiltration

function Shifter_startInfiltrate(%clientId,%targetId)
{
	if($InfTime[%clientId] > 0)
	{
		$InfTime[%clientId] = 20;
		return;
	}

	%tteam = Client::getTeam(%targetId);
	%cteam = Client::getTeam(%clientId);

	if(%tteam < 0)
	{
		echo("Something is amiss: a Chemeleon has tried to mimic someone on a non-existant team.");
		return;
	}

	$InfTime[%clientId] = 31;

	//Stolen from Shifter2k4, which stole this from Annihilation
	Player::dropItem(%clientId, Flag);

	%clientId.OrigTeam = Client::getTeam(%clientId);
	Client::sendMessage(%clientId,0,"Chemeleon Infiltration initiated.  Mimicing " @ getTeamName(%tteam) @ " friendly beacon.");
	GameBase::playSound(Client::getOwnedObject(%clientId),ForceFieldOpen,0);

	%clientId.OrigTeam = %cteam;
	Client::setInitialTeam(%clientId, %tteam);
	GameBase::setTeam(%clientId, %tteam);
	Client::setInitialTeam(%clientId,%clientId.OrigTeam);

	checkPlayerInfiltrate(%clientId);

}

function checkPlayerInfiltrate(%clientId) //, %origskin)
{

	if($InfTime[%clientId] > 0 && (Player::getArmor(%clientId) == "spyarmor" || Player::getArmor(%clientId) == "spyfemale") && !Player::isDead(Client::getOwnedObject(%clientId)))
	{
		$InfTime[%clientId] -= 1;
		if($InfTime[%clientId] == 5 || $InfTime[%clientId] == 10 || $InfTime[%clientId] == 15 ||$InfTime[%clientId] == 20 || $InfTime[%clientId] == 25 || $InfTime[%clientId] == 30)
			Client::sendMessage(%clientId,1,"You have " @ $InfTime[%clientId] @ " seconds of Infiltration left.");
		schedule("checkPlayerInfiltrate(" @ %clientId @ ");",1,Client::getOwnedObject(%clientId));
     	}
	else
	{
		$InfTime[%clientId] = 0;
		Client::sendMessage(%clientId,1,"Infiltration disengaged.");
		GameBase::setTeam(%clientId,%clientId.OrigTeam);
		%clientId.OrigTeam = "";
		GameBase::playSound(Client::getOwnedObject(%clientId),ForceFieldClose,0);
	}			
}

//============================================================================= Flag Shot Off

function DoTheFlagDrop(%player, %shooterId) 
{
	%playerTeam = GameBase::getTeam(%player);
	%flag = %player.carryFlag;
	%flagTeam = GameBase::getTeam(%flag);
	%playerClient = Player::getClient(%player);
	%dropClientName = Client::getName(%playerClient);
	%shooterName = Client::getName(%shooterId);

	if (%shooterid)
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 1, %shooterName @ " sniped " @ %flag.objectiveName @ " off of your back!");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of " @ %dropClientName @ "'s back!");
			Client::sendMessage(%playerClient, 0, %shooterName @ " sniped the " @ getTeamName(%flagTeam) @ " flag off of your back!");
			TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
		}
	}	
	else
	{
		if(%flagTeam == -1)
		{
			MessageAllExcept(%playerClient, 1, %dropClientName @ " has butter fingers and dropped the flag.");
		}
		else
		{
			MessageAllExcept(%playerClient, 0, %dropClientName @ " has butter fingers and dropped the flag.");
		}
	}
	GameBase::throw(%flag, %player, -15, false);
	Item::hide(%flag, false);
	Player::setItemCount(%player, "Flag", 0);
	%flag.carrier = -1;
	%player.carryFlag = "";
	Flag::clearWaypoint(%playerClient, false);

	schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
	ObjectiveMission::ObjectiveChanged(%flag);
}

//Allow clients to use the fakedeath script
function remotePlayFakeDeath(%client,%anim)
{
    Player::setAnimation(%client,%anim);
}

//================================================= Blink curse, stolen from Meltdown Holocaust
function KeepBlinking(%client, %player)
{
	if(%client.Blinked) 
	{
		%rnd = floor(getRandom() * 35);
		if(%rnd > 23)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 0 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 23)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 22)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "40 40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 21)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "-40 40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 20)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "40 0 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 19)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "40 -40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 18)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 -40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 17)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "-40 0 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 16)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "-40 -40 40");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd < 16 && %rnd > 10)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 0 50");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 10 || %rnd == 9 || %rnd == 2 || %rnd == 1)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 50 0");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 8 || %rnd == 7)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "50 0 0");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 6 || %rnd == 5)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "0 -50 0");
			GameBase::setPosition(%player,%pos);
		}
		else if(%rnd == 4 || %rnd == 3)
		{
			%pos = Vector::add(GameBase::getPosition(%player), "-50 0 0");
			GameBase::setPosition(%player,%pos);
		}
		else
		{
			Ix_applykickback(%client,50,10);
		}
		if($debug) echo("Blinking " @ Client::getName(%client) @ ".");
		schedule("KeepBlinking(" @ %client @ ", " @ %player @ ");",1);
	}
}