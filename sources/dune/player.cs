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
//ICE'S LASER RECOGNITION MODULE, DAMAGE TO PERFECTION
//----------------------------------------------------------------------------
//$DamageToLaser[(Weapon ImageType Here)]          = (DamageType Goes here);
$DamageToLaser[Cutteray]	= $CutterayDamageType;
$DamageToLaser[SmallLas]	= $SmallLasDamageType;
$DamageToLaser[RifleLas]	= $RifleLasDamageType;
$DamageToLaser[HeavyLas]	= $HeavyLasDamageType;
$DamageToLaser[DLT]	= $HeavyLasDamageType;
//----------------------------------------------------------------------------
//ICE'S LASER DETERIOTATION MODULE, DAMAGE BY DISTANCE
//----------------------------------------------------------------------------
//$LaserFullPwrRange[(Weapon ImageType Here)]          = (How far the laser reaches while applying full damage);
//$LaserFullPwrRange[Cutteray] = 12;
$LaserFullPwrRange[Cutteray] = 1.3;
$LaserFullPwrRange[SmallLas] = 20;
$LaserFullPwrRange[RifleLas] = 100;
$LaserFullPwrRange[HeavyLas] = 45;
$LaserFullPwrRange[DLT] = 100;

//$LaserDeterioRate[(Weapon ImageType Here)]          = (The rate of how fast the laser loses strength past its $LaserFullPwrRange);
//$LaserDeterioRate[Cutteray] = 0.5;
$LaserDeterioRate[Cutteray] = 0.0057; //10m max
$LaserDeterioRate[SmallLas] = 0.0029;  //40m max
$LaserDeterioRate[RifleLas] = 0.000999; //200 max
$LaserDeterioRate[HeavyLas] = 0.00841; //75 Max
$LaserDeterioRate[DLT] = 0.00049; // 200 max
//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	%this.BlockDelay = 0.2;
	GameBase::setRechargeRate(%this,8);
}

function Player::onRemove(%this)
{
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
			if(%type == FuelPack)
			{
				//echo("Filling fuel on remove.");
				%item.Fuel = player::getItemcount(%this,FlamethrowerAmmo);
				player::setItemcount(%this,FlameThrowerAmmo,0);
			}
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
	%clip = $Clip[%itemType];
	
	if( %clip != "" ){
		%clipCount = Player::getItemCount(%player,%clip);
		if(%clipCount > 0)
			Player::useItem(%player,%clip);
		else {
			if(%clip != "") 
				bottomprint(Player::getClient(%player), "<jc><f0>Out of Clips!!!", 2);
		}
	}
}

function Player::onKilled(%this)
{
	%holding = $UA::grabbing[Gamebase::GetOwnerClient(%this)];
	if(%Holding != "" && %holding > 0)
	{
		UA::releaseGrip(Gamebase::getOwnerClient(%this));
	}
	%holder = $UA::grabbed[GameBase::getOwnerClient(%this)];
	if(%holder != "" && %holder > 0)
	{
		UA::ReleaseGrip(%holder);
	}
	if(%this.tackled)
	{
		%object.tackled = false;
		%cl = %this.tackle::ownedBy;
		%cl.tackled = false;
	} else
	{
		%cl = GameBase::getOwnerClient(%this);
	}
	
	%this.lastBlockTime = 0;
	
	%this.lastOwner = %cl;
	%this.lastOwnerName = Client::getname(%cl);
	%this.lastOwnerSex = Client::getGender(%cl);
	%this.corpseOwner = %cl;
	%this.lastOwnerTeam = Client::getTeam(%cl);
	%cl.lastCorpse = %this;
	%this.lastfuel = player::getItemcount(%this,FlamethrowerAmmo);
	%cl.dead = 1;
	if($AutoRespawn > 0)
		schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	Player::setDamageFlash(%this,0.75);
	
	
	for(%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2")
				Player::dropItem(%this,%type);
		}
	}

	$PlayerBurning[%cl] = 0;
	$PlayerPoisoned[%cl] = 0;
	
	// For BT Gholas
	if( !Player::isAiControlled(%cl) && !$FaceDancerIsSwitched[%cl] && (Player::getArmor(%cl) != fdarmor && Player::getArmor(%cl) != fdfemale)){
		// Keep track of the last 5 people that died.
		if (!$LastDied || $LastDied == 5 )
			$LastDied = 1;
		else
			$LastDied++;
		$LastPlayerDied[$LastDied] = client::getname(%cl);
		$LastSexDied[$LastDied] = Client::getGender(%cl);
		$LastArmorDied[$LastDied] = Player::getArmor(%cl);
		$LastTeamDied[$LastDied] = $ServerNameToKeyName[Client::getTeam(%cl)];
	}
	if(!$FaceDancerIsSwitched[%cl]) {
		$TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%cl)], $ArmorName[Player::getArmor(%cl)]] = $TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%cl)], $ArmorName[Player::getArmor(%cl)]] - 1;	
	} else {
		$TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%cl)], FaceDancerArmor] = $TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%cl)], FaceDancerArmor] - 1;	
		FaceDancerRevertBack(%cl);
	}

	// For worms
	Worm::RemoveFromTargetQueue(%this);
	if(%cl != -1) {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
				Client::setControlObject(Player::getClient(%this), %this);
				Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
		if(!mech::isMech(%this))
		{
			Client::setOwnedObject(%cl, -1);
			Client::setControlObject(%cl, Client::getObserverCamera(%cl));
			Observer::setOrbitObject(%cl, %this, 5, 5, 5);
			schedule("DeleteCorpse("@%this@");",0.1,%this);
			%cl.observerMode = "dead";	
			%cl.lastObservedTeammate = %cl;
			%cl.dieTime = getSimTime();
		} else {
			Mech::ReturnOwner(%this);
			//for(%i = 0; %i < 8; %i = %i + 1) {
			//	%type = Player::getMountedItem(%this,%i);
			//	if (%type != -1) {
			//		player::unmountItem(%this, %type);
			//	}
			//}
			schedule("DeleteCorpse("@%this@");",0.1,%this);
			
		}
	}

}

function DeleteCorpse(%this)
{
		if($CorpseRot || %this.blowup){
			schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
			schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
			%this.corpseOwner.lastCorpse = -1;
			%this.corpseOwner = -1;

		} else {
			schedule(%this @ ".rotten = true;", $CorpseTimeoutValue + 2.5, %this);
			if($Corpses[$numCorpses] != "" && (getObjectType($Corpses[$numCorpses]) == "Player") ) {
				GameBase::startFadeOut($corpses[$numCorpses]);
				schedule("deleteObject(" @ $corpses[$numCorpses] @ ");", 3, $corpses[$numCorpses]);
			}
			$corpses[$numCorpses] = %this;
			$numCorpses++;
			if($numCorpses > $MaxCorpses-1)
				$numCorpses = 0;
		}


}
function BurnTick(%this, %object) {
	if($PlayerBurning[Player::getClient(%this)] == 1) {
		GameBase::applyDamage(%this, $PlasmaDamageType, 0.2, GameBase::getPosition(%this), "0 0 0", "0 0 0", %object);
		schedule("BurnTick("@%this@", "@%object@");", 1, %this);
	}
}

function PoisonTick(%this, %object,%HS) {
	if($HSPoison[Player::getClient(%this)])
	{
		$HSPoison[Player::getClient(%this)] = false;
		%HS = true;
	}

	if($PlayerPoisoned[Player::getClient(%this)] == 1) {
		GameBase::applyDamage(%this, $Poison2DamageType, 0.05, GameBase::getPosition(%this), "0 0 0", "0 0 0", %object);
		remoteEval(Player::getClient(%this), BP, "<f5><jc>You are poisoned!!", 3);
		if(%HS)
		{
			schedule("HSPDamage("@%this@","@%object@");",0.1);
			schedule("HSPDamage("@%this@","@%object@");",0.2);
			schedule("HSPDamage("@%this@","@%object@");",0.3);
			schedule("HSPDamage("@%this@","@%object@");",0.4);
			schedule("HSPDamage("@%this@","@%object@");",0.5);
			schedule("HSPDamage("@%this@","@%object@");",0.6);
			schedule("HSPDamage("@%this@","@%object@");",0.7);
			schedule("HSPDamage("@%this@","@%object@");",0.8);
			schedule("HSPDamage("@%this@","@%object@");",0.9);
			schedule("PoisonTick("@%this@", "@%object@", true);", 1, %this);		
		} else
			schedule("PoisonTick("@%this@", "@%object@");", 1, %this);		
	} else if(!Player::isDead(%this))
	{
		Client::sendMessage(Player::getClient(%this),1,"You're cured!");
	}
}

function HSPDamage(%this,%object)
{
	if($PlayerPoisoned[Player::getClient(%this)] == 1)
		GameBase::applyDamage(%this, $Poison2DamageType, 0.05, GameBase::getPosition(%this), "0 0 0", "0 0 0", %object);

}

//-Ice's GetTeam() function
function GetTeam(%this,%object)
{
	if($teamplay && Player::getClient(%this) != Player::getClient(%object) && Client::getTeam(Player::getClient(%this)) == Client::getTeam(Player::getClient(%object)))
		return Same;
	else if($teamplay && Player::getClient(%this) != Player::getClient(%object) && Client::getTeam(Player::getClient(%this)) != Client::getTeam(Player::getClient(%object)))
		return Dif;
	else if(!$teamplay && Player::getClient(%this) != Player::getClient(%object))
		return Enemies;
	else
		return You;
}
//-Ice's Vector::getRotAim(,) function
function Vector::getRotAim(%pos1,%pos2)
{
	%vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
	%rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
	return %rot;
}
//-Ice's Vector::Scale(,) function
function Vector::Scale(%vec,%multiplier)
{
	%vec = getWord(%vec,0)*%multiplier@" "@getWord(%vec,1)*%multiplier@" "@getWord(%vec,2)*%multiplier;
	return %vec;
}

function shove(%this, %vertPos, %quadrant, %force, %pos, %object)
{
//echo(gamebase::getrotation(%object));

//	Player::applyImpulse(%this,gamebase::getrotation(%object));

}



// If the player is dead, "%Object" is -1. "object" is actually the player's game number, not their body's object number
// As a result, turrets are always 0 (the SimManager)
// For reference, %vec is actually the distance vector between the shooter and damage. Use this for the turrets.
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
	if(%type == $HSDamageType)
	{
		%type = $PoisonDamageType;
		$HSPoison[Player::getClient(%this)] = true;
	}
	if(%type == $HS2DamageType)
	{
		%type = $Poison2DamageType;
		$HSPoison[Player::getClient(%this)] = true;
	}
	if(%type == $AssassinDamageType && (String::findSubStr(%quadrant,"back") == -1 && %quadrant != "middle_middle"))
	{
		Client::sendMessage(%object,1,"You can only assassinate from behind!");
		return;
	} else if(%type == $AssassinDamageType)
	{
		Client::sendMessage(%object,1,"***You hear a loud snap as you break "@Client::Getname(player::getclient(%this))@"'s neck!***");
		Client::sendMessage(player::getclient(%this),1,"You hear a loud snap and everything goes black...");
		%value = 10;
	}

	if(%type == $GaroteDamageType && (String::findSubStr(%quadrant,"back") == -1 && %quadrant != "middle_middle"))
	{
		Client::sendMessage(%object,1,"You can only garote from behind!");
		return;
	} else if(%type == $GaroteDamageType)
	{
		UA::GaroteTargetFound(%object,player::GetClient(%this));
		Client::sendMessage(%object,1,"You quickly slip the shigawire around "@Client::Getname(player::getclient(%this))@"'s neck!");
		Client::sendMessage(player::getclient(%this),1,"You feel a wire suddenly pulled taut around your neck!");
	}

	%armor = Player::getArmor(%this);
	%value *= $DamageScale[%armor, %type];
       	if(%type == $WormDamageType) {
		Player::blowUp(%this);
		%this.blowup = true;
	}

	if(Mech::isMech(%this))
	{	player::blowUp(%this);
		%this.blowup = true;
	}
	if( %object !="" && %object != -1 && %object != 2048 && getObjectType(%object) == "Flier") {
		if( %object.clLastMount == "" )
			%object = gamebase::Getcontrolclient(%object);
		else
			%object = %object.ClLastMount;
	}
	//*** Depreciated. Except for the turrets. I stuck the type conversions in the "Weapon::onfire"
	if(%type == $LaserDamageType) {
		if(getobjecttype(%object) == SimManager){
			%type = $SmallLasDamageType;
		} else if(GameBase::getDataName(Client::getControlObject(%object) ) == StationaryLasgun){
			%type = $HeavyLasDamageType;
			%DLT = true;
		} else {
			%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		}
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
		{
			%value = 0;
		}
	}
	//***

	//-Laser Range Damage Multiplier Dont do with normal $laserdamagetype because sniper rifles use that.
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		if(%weap == -1 || %DLT)
		{
			// Then it's a turret
			if(%weap == -1)
			{
				%weap = SmallLas;
				%value = 0.06;
			}
			%Dist = Vector::getDistance(%vec,"0 0 0");
		} else
			%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		//echo(%Dist@" ::: "@%value);
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			//echo("Spill: "@%DistSpillover);
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			//echo("Rate: "@%rate);
			//echo("Old: "@%value);
			%value -= %rate;
			//echo("New: "@%value);
		}
		//-Jes, its up to you whether you want insta-kills at point blank with a laser
		//if(%Dist <= 1.75) //- Instant kill at point blank if its a laser
		//	%value = 1.5;
		if(%value <= 0.00005)
			%value = 0;
	}

	if(Player::isExposed(%this)) {

		if(%type == $LargeBulletDamageType)
		{
			shove(%this,%vertPos,%quadrant,75, %pos,%object);
		}
		%damagedClient = Player::getClient(%this);
		%shooterClient = %object;
		%curTime = getSimTime();
		if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient)) {
			if(%shooterClient != -1) {
				
				if(%value > 0 && (%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0 && %Type != $GaroteDamageType && %Type != $AsphyxiationDamageType && ((!HurtsShielded(%type)&&$ShieldOn[%this])||!$ShieldOn[%this])) { //Diddily Bug Fix
					if(%type != $MineDamageType) {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
						Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
					
					}
					else {
						Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
						Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
						IncSpawnTime(%killerId, $TDSpawnInc);

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
		if(!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			if(%vertPos == "head" && %type == $LaserDamageType) { //Diddily Bug Fix -Moved by J.-
				if(!%this.shieldstrength) // -To here-
				{
 					bottomprint(%shooterClient,"<jc>Headshot!", 4);
 					if(%armor == "harmor") { 
						if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle")
							%value += (%value * 0.3);
					}
					else
						%value = %value * 4;
				}
			}
			else if((%vertPos == "torso") && (Player::getItemCount(%this, FuelPack) > 0) && (%value > 0) && %type != $GaroteDamageType && %type != $AssassinDamageType) {
				if((%quadrant == "back_left") || (%quadrant == "back_right") || (%quadrant == "back_middle")) {
					Player::blowUp(%this);
					%this.blowup = true;
					GameBase::playSound(%this, shockExplosion, 3);
					Player::setItemCount(%this, FuelPack, 0);
					%value *= 100;
					%pos = GameBase::getPosition(%this);
					%pos1 = Vector::Add(%pos,"0 0 "@$FuelPackBlowHeight);
					%vel = "0 0 0";
					//-Ice's Fuel Pack Explosion Method
					if($FuelPackBlowMethod == "" || $FuelPackBlowMethod == 1) {
						%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
						%rot2  = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");   	   //- rotation aim back
						%rot3  = Vector::Add(GameBase::getRotation(%this),"0 0 -1.570796327");  	   //- rotation aim left
						%rot4  = Vector::Add(GameBase::getRotation(%this),"0 0 1.570796327");   	   //- rotation aim right
						%rot5  = Vector::Add(GameBase::getRotation(%this),"1.570796327 0 0");   	   //- rotation aim up
						%rot6  = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0 0");  	   //- rotation aim down
						%rot7  = Vector::Add(GameBase::getRotation(%this),"-0.7853981635 0 0");		   //- rotation aim down/forward
						%rot8  = Vector::Add(GameBase::getRotation(%this),"0.7853981635 0 0");  	   //- rotation aim up/forward
						%rot9  = Vector::Add(GameBase::getRotation(%this),"-3.9269908175 0 0");            //- rotation aim down/back
						%rot10 = Vector::Add(GameBase::getRotation(%this),"3.9269908175 0 0");             //- rotation aim up/back
						%rot11 = Vector::Add(GameBase::getRotation(%this),"0 0 -0.7853981635");            //- rotation aim left/forward
						%rot12 = Vector::Add(GameBase::getRotation(%this),"0 0 0.7853981635");             //- rotation aim right/forward
						%rot13 = Vector::Add(GameBase::getRotation(%this),"0 0 -3.9269908175");            //- rotation aim left/back
						%rot14 = Vector::Add(GameBase::getRotation(%this),"0 0 3.9269908175");             //- rotation aim right/back
						%rot15 = Vector::Add(GameBase::getRotation(%this),"1.570796327 0.7853981635 0");   //- rotation aim up/right
						%rot16 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0.7853981635 0");  //- rotation aim down/right
						%rot17 = Vector::Add(GameBase::getRotation(%this),"1.570796327 -0.7853981635 0");  //- rotation aim up/left
						%rot18 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
	
						%vec[1]  = Vector::getFromRot(%rot1,$FuelPackBlowRadius);
						%vec[2]  = Vector::getFromRot(%rot2,$FuelPackBlowRadius);
						%vec[3]  = Vector::getFromRot(%rot3,$FuelPackBlowRadius);
						%vec[4]  = Vector::getFromRot(%rot4,$FuelPackBlowRadius);
						%vec[5]  = Vector::getFromRot(%rot5,$FuelPackBlowRadius);
						%vec[6]  = Vector::getFromRot(%rot6,$FuelPackBlowRadius);
						%vec[7]  = Vector::getFromRot(%rot7,$FuelPackBlowRadius);
						%vec[8]  = Vector::getFromRot(%rot8,$FuelPackBlowRadius);
						%vec[9]  = Vector::getFromRot(%rot9,$FuelPackBlowRadius);
						%vec[10] = Vector::getFromRot(%rot10,$FuelPackBlowRadius);
						%vec[11] = Vector::getFromRot(%rot11,$FuelPackBlowRadius);
						%vec[12] = Vector::getFromRot(%rot12,$FuelPackBlowRadius);
						%vec[13] = Vector::getFromRot(%rot13,$FuelPackBlowRadius);
						%vec[14] = Vector::getFromRot(%rot14,$FuelPackBlowRadius);
						%vec[15] = Vector::getFromRot(%rot15,$FuelPackBlowRadius);
						%vec[16] = Vector::getFromRot(%rot16,$FuelPackBlowRadius);
						%vec[17] = Vector::getFromRot(%rot17,$FuelPackBlowRadius);
						%vec[18] = Vector::getFromRot(%rot18,$FuelPackBlowRadius);
					
						%pos[19] = Vector::add(%pos1,%vec[1]);
						%pos[20] = Vector::add(%pos1,%vec[2]);
						%pos[21] = Vector::add(%pos1,%vec[3]);
						%pos[22] = Vector::add(%pos1,%vec[4]);
						%pos[23] = Vector::add(%pos1,%vec[5]);
						%pos[24] = Vector::add(%pos1,%vec[6]);
						%pos[25] = Vector::add(%pos1,%vec[7]);
						%pos[26] = Vector::add(%pos1,%vec[8]);
						%pos[27] = Vector::add(%pos1,%vec[9]);
						%pos[28] = Vector::add(%pos1,%vec[10]);
						%pos[29] = Vector::add(%pos1,%vec[11]);
						%pos[30] = Vector::add(%pos1,%vec[12]);
						%pos[31] = Vector::add(%pos1,%vec[13]);
						%pos[32] = Vector::add(%pos1,%vec[14]);
						%pos[33] = Vector::add(%pos1,%vec[15]);
						%pos[34] = Vector::add(%pos1,%vec[16]);
						%pos[35] = Vector::add(%pos1,%vec[17]);
						%pos[36] = Vector::add(%pos1,%vec[18]);
			
						%trans = %rot1@" "@%vec[1]@" "@%rot1@" "@%pos[19];
						projectile::spawnProjectile(FlameExplosionThree,%trans,%this,%vel);
						for(%i = 1; %i <= 18; %i++) {
							%trans = %rot1@" "@%vec[%i]@" "@%rot1@" "@%pos[%i+18];
							if($FuelPackBlowType == 1 || $FuelPackBlowType == "")
								schedule("Projectile::spawnProjectile(FlameExplosionTwo,\""@%trans@"\",\""@%this@"\",\""@%vel@"\");",%i/18);
							else
								projectile::spawnProjectile(FlameExplosionTwo,%trans,%this,%vel);
						}
					}
					else if($FuelPackBlowMethod == 2) {
						%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
							
						%transOne = "0 0 0 0 0 0 0 0 0 " @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) + 1;
						%transTwo = "0 0 0 0 0 0 0 0 0 " @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) + 1.5;
							
						%transI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2);
						%transII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2);
						%transIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) + 3;
						%transIV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) + 3;
						%transV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) + 3;
						%transVI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) + 3;
						%transVII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2);
	
						%transVIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2);
						%transIX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2);
						%transX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) - 3;
						%transXI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) - 3;
						%transXII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2);
						%transXIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) - 3;
						%transXIV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) - 3;
		
						%transXV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2);
						%transXVI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2);
						%transXVII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) + 3;
						%transXVIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) - 3;
						%transXIX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) - 3;
						%transXX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) + 3;
		
						%transXXI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) - 3;
						%transXXII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) + 3;
						%transXXIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) + 3;
						%transXXIV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) + 3;
						%transXXV = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) + 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) - 3;
						%transXXVI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) + 3 @ " " @ getWord(%pos, 2) - 3;
		
						%transXXVII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2);
						%transXXVIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2);
						%transXXIX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) - 3;
						%transXxX = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) - 3;
						%transXXXI = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2);
						%transXXXII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) - 3 @ " " @ getWord(%pos, 1) @ " " @ getWord(%pos, 2) - 3;
						%transXXXIII = "0 0 0 0 0 0 0 0 0" @ getWord(%pos, 0) @ " " @ getWord(%pos, 1) - 3 @ " " @ getWord(%pos, 2) - 3;
						
						schedule("GameBase::applyRadiusDamage(3, \"" @ %pos @ "\", 5, 1, 30, " @ %object @ ");", 0.1);
						Projectile::spawnProjectile("FlameExplosionTwo", %transOne, %this, "0 0 0");
						Projectile::spawnProjectile("FlameExplosionThree", %transTwo, %this, "0 0 0");
	
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transI 		@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.3);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transVIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.3);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXV 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.3);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.3);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXVII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.3);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.4);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transIX 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.4);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXVI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.4);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.4);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXVIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.4);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.5);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transX 		@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.5);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXVII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.5);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXIII	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.5);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXIX 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.5);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transIV 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.6);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.6);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXVIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.6);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXIV 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.6);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXX	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.6);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transV 		@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.7);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.7);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXIX	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.7);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXV 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.7);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXXI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.7);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transVI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.8);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.8);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXX 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.8);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXVI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.8);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXXII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.8);
						
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transVII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.9);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXIV 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.9);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXI 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.9);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXVII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.9);
						schedule("Projectile::spawnProjectile(FlameExplosionTwo, \"" @ %transXXXIII 	@ "\", \"" @ %this @ "\", \"" @ %vel @ "\");", 0.9);
					}
				}
			}

		//If Shield Pack is on
			if(%type != "" && %this.shieldStrength) {
				//**Standard damage assesments block (w/ shield on)
				//If its a type that can over load our shield,
				if(%type == $CrushDamageType || (%value >= 2.1 && (%type == $ImpactDamageType || %type == $LandingDamageType || %type == $ExplosionDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MineDamageType || %type == $WormDamageType || %type == $NukeDamageType))) {//
					%this.shieldStrength = 0; // set shield = 0 and let damage go through
				} else if(%type == $PlasmaDamageType) { // if its plasma/fire, then it can go through shields, but loses damage amount
					%value *= 0.25;
				} else if(%type != $StunnerDamageType && %type != $Poison2DamageType && %type != $StabDamageType && %type != $PlasmaDamageType && %type != $CutterayDamageType && %type != $SmallLasDamageType && %type != $RifleLasDamageType && %type != $HeavyLasDamageType && %type != $AsphyxiationDamageType && %type != $AssassinDamageType) { // if not one of these, does no damage what so ever.
					%value = 0;
				}
				//**Specialty damage effects block (w/ shield on) 
				if(%value > 0.0 && (%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) ) { //  if its a lasgun no matter what,
					if(getobjecttype(%object) != SimManager && ($nuketime[%shooterclient] == "" || $nuketime[%shooterclient] + 0.5 <= getsimtime())) {
						//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%damagedclient);
						//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");	
						//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%shooterclient);
						//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");
						//$NukeKiller[gamebase::getcontrolclient(%this),
						NuclearExplosion( %shooterclient, 1);
						Player::unMountItem(%shooterclient,$WeaponSlot);
						NuclearExplosion(%this, 1);
						//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
						//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
						
						//Who's fault is it?
						if((getsimtime() - $TimeLastHitWithLasgun[%this]) <= $LasHitGraceTime) {
							// Then its the shielded player's fault for throwing up his shield
							NukeCaused(player::getclient(%this));
							$nuketime[%damagedClient] = getsimtime();
						} else {
							// Then its the lasgun player's fault for firing at a shield.
							NukeCaused(Player::getClient(%object));
							$nuketime[%shooterclient] = getsimtime();	
						}
					} else {
						if( getobjecttype(%object) == SimManager && ($turretNukeTime == "" || $turretnuketime + 0.5 < getsimtime()) ) {
	 						NuclearExplosion(%this, 1);
							//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
							//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
							$turretnukeTime = getsimtime();
						}
					}
					
				}
			} else if( %value > 0.0 && (%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) )
			{
				//Mark them. VERY descriptive! :P
				$TimeLastHitWithLasgun[%this] = getsimtime();
			}
			if(%type == $AsphyxiationDamageType && %value != 0) { // if we cant breath
				if($UA::grabbed[%damagedClient] != "")
				{
					if(%DamagedClient.choakMessage)
					{	
						%damagedClient.ChoakMessage = false;
						Client::sendMessage(%damagedClient,1,"You can't breath!");
					}
				}
				else
				{
					if(%curTime - %damagedClient.lastAsph > 1||%damagedClient.lastAsph=="")
					{
					Client::sendMessage(%damagedClient,1,"You can't breath!");
					%damagedClient.lastAsph = %curTime;
					}
				}	
			
			}
			else if(%type == $PlasmaDamageType && %value != 0) { // if we took plasma damage
				if($PlayerBurning[%damagedClient] == 0) {
					$PlayerBurning[%damagedClient] = 1;
					Client::sendMessage(%damagedClient,1,"You are on fire!");
					BurnTick(%this, %object);
					schedule("$PlayerBurning["@%damagedClient@"] = 0;", 5);
					schedule("Client::sendMessage("@%damagedClient@",1,\"You stop burning.\");", 5);
				}	
			}	
				
			if($ArmorName[player::Getarmor(%damagedClient)] == SoldierArmor
			&& ($ServerNameToKeyName[GameBase::getTeam(%damagedClient)] == HA 
				|| ($FaceDancerIsSwitched[%damagedClient] && $ServerNameToKeyName[%damagedClient.impersonatingWhoTeam] == HA)))
				%AtreidesFactor = 10;
			else if($ArmorName[player::Getarmor(%damagedClient)] == TrooperArmor
			&& ($ServerNameToKeyName[GameBase::getTeam(%damagedClient)] == HA 
				|| ($FaceDancerIsSwitched[%damagedClient] && $ServerNameToKeyName[%damagedClient.impersonatingWhoTeam] == HA)))
				%AtreidesFactor = 10;
			else
				%AtreidesFactor = 0;
			

			if(((%quadrant == front_left) || (%quadrant == front_right) || (%quadrant == middle_front) )
				&&(%type == $stabDamageType || %type == $poison2DamageType) && Player::IsBlocking(%this) == 1)
			{
				if($training)
					messageall(1,client::getname(%shooterClient) @"'s attack blocked by "@client::getname(%damagedclient));
				%value = 0;
			} else if(((%quadrant == front_left) || (%quadrant == front_right) || (%quadrant == middle_front) )
				&&(%type == $stabDamageType || %type == $poison2DamageType) && Player::IsBlocking(%this) == 2 
				&& floor(getrandom()*100) < (($Block::Weapon[Player::getMountedItem(%this,$WeaponSlot)] + (100 - $Block::Weapon[Player::getMountedItem(%object,$WeaponSlot)]) + $Block::Armor[$ArmorName[Player::getArmor(%this)]] + %AtreidesFactor)/3) )
			{
				if($training)
					messageall(1,client::getname(%shooterClient) @"'s attack blocked by "@client::getname(%damagedclient));
				%value = 0;
			} else if((%vertPos == "torso") && (%quadrant == "front_right") 
				&& (%type == $stabDamageType || %type == $poison2DamageType)
				&& (Player::getMountedItem(%this,$WeaponSlot) == knife || Player::getMountedItem(%this,$WeaponSlot) == knife2 || Player::getMountedItem(%this,$WeaponSlot) == Sliptip || Player::getMountedItem(%this,$WeaponSlot) == crysknife || Player::getMountedItem(%this,$WeaponSlot) == kindjal || Player::getMountedItem(%this,$WeaponSlot) == saber || Player::getMountedItem(%this,$WeaponSlot) == rapier )
				&& Player::Disarmed(%this,player::getMountedItem(%this,$WeaponSlot),player::Getmounteditem(%object,$Weaponslot))) {
				%weaponType = Player::getMountedItem(%this,$WeaponSlot);
				Player::trigger(%this, $WeaponSlot, false);	
				%obj = newObject("","Item",%Weapontype,1,false);
 	 	  		schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 		addToSet("MissionCleanup", %obj);
				GameBase::throw(%obj,%this,2,true);
				Item::playPickupSound(%obj);
				%obj.lastowner = Player::getClient(%this);
				%obj.lastownerarmor = player::getarmor(%this);
				Player::decItemCount(%this,%weapontype,1);
				%value = 0;
			} else if((%vertpos == legs) && %type != $PlasmaDamageType && %type != $AsphyxiationDamageType && %type != $AsphyxiationDamageType )
			{
				%value *= 0.80;
			} else if((%vertpos == head) && %type != $PlasmaDamageType && %type != $AsphyxiationDamageType && %type != $AsphyxiationDamageType )
			{
				%value *= 1.3;
			}


			// Atreides soldiers do 10% more melee damage
			if($ArmorName[player::Getarmor(%object)] == SoldierArmor 
			&& ($ServerNameToKeyName[GameBase::getTeam(%object)] == HA 
				|| ($FaceDancerIsSwitched[%object] && $ServerNameToKeyName[%object.impersonatingWhoTeam] == HA))
			&& (%type == $stabDamageType || %type == $poison2DamageType))
			{
				%value *= 1.1;
			}
	
			// Atreides troopers do 20% more melee damage
			if($ArmorName[player::Getarmor(%object)] == TrooperArmor
			&& ($ServerNameToKeyName[GameBase::getTeam(%object)] == HA 
				|| ($FaceDancerIsSwitched[%object] && $ServerNameToKeyName[%object.impersonatingWhoTeam] == HA))
			&& (%type == $stabDamageType || %type == $poison2DamageType))
			{
				%value *= 1.2;
			}
			

			if((%type == $PoisonDamageType || %type == $Poison2DamageType || %type == $ThrownPoisonWeaponDamageType) && %value != 0) { // if we took poison damage
				if($PlayerPoisoned[%damagedClient] == 0) {
					$PlayerPoisoned[%damagedClient] = 1;
					Client::sendMessage(%damagedClient,1,"You have been poisoned!");
					schedule("PoisonTick("@%this@", "@%object@");", 1, %this);
					schedule("$PlayerPoisoned["@%damagedClient@"] = 0;", 20);
//					schedule("Client::sendMessage("@%damagedClient@",1,\"You're cured!.\");", 20);
				}
			}

			if(%value) {
				if($training && (%type == $stabDamageType || %type == $poison2DamageType  || %type == $ThrownPoisonWeaponDamageType  || %type == $ThrownWeaponDamageType)) //%Type != $GaroteDamageType && %Type != $AsphyxiationDamageType)
					messageall(1,client::getname(%shooterClient) @" hits "@client::Getname(%damagedclient)@"'s "@%vertpos @ %quadrant);
				
				%value *= %friendFire;
				%dlevel = GameBase::getDamageLevel(%this) + %value;
           			%spillOver = %dlevel - %armor.maxDamage;
				GameBase::setDamageLevel(%this,%dlevel);
				%flash = Player::getDamageFlash(%this) + %value * 2;
				if(%flash > 0.75) 
					%flash = 0.75;
				Player::setDamageFlash(%this,%flash);
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						%sound = radnomItems(3,injure1,injure2,injure3);
						playVoice(%damagedClient,%sound);
						%damagedClient.lastdamage = getSimTime() + 1.5;
					}
				}
				else {
            				if(%spillOver > 0.5 && (%type == $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType || %type == $NukeDamageType)) {
			 			Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::dropItem(%this,%weaponType);
					%this.blowup = true;

               	 			Player::blowUp(%this);
					}
					else {
						if((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
					  		if(%quadrant == "front_left" || %quadrant == "front_right") 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieForward;
						}
						else if(Player::isCrouching(%this)) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right") 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if(%vertPos == "torso") {
							if(%quadrant == "front_left") 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" || %quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						Player::setAnimation(%this, %curDie);
					}
					if(%type == $ImpactDamageType && %object.clLastMount != "")  
						%shooterClient = %object.clLastMount;
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
		if(%value > 0)
			Player::applyImpulse(%this,%mom);
		
	}
}

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision1(%this,%object)
{
	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {

			if( (Player::getArmor(%object) == fdarmor || Player::getArmor(%object) == fdfemale) && gamebase::Getteam(%this) != gamebase::Getteam(%object)  && !%this.rotten) 
			{
				%cl = GameBase::getOwnerClient(%object);
				$FaceDancerIsSwitched[%cl] = true;
				%cl.impersonatingWho = %this.lastOwnerName;
				%cl.impersonatingWhoSex = %this.lastOwnerSex;
				%cl.impersonatingWhoTeam = %this.lastOwnerTeam;
				%vicarmor = player::Getarmor(%this);
				Player::setArmor(%cl,%Vicarmor);
				Player::setItemCount(%cl, $ArmorName[Player::getArmor(%object)], 0);  
     				Player::setItemCount(%cl, $ArmorName[%VicArmor], 1);

				//Client::setSkin(%cl, $KeyNameToTeamSkin[$ServerNameToKeyName[gamebase::Getteam(%this)]]);
				Dune::SwitchSkin(%cl, $ArmorName[%vicArmor], $ServerNameToKeyName[gamebase::Getteam(%this)]);
				Client::sendMessage(%cl,1,"Assuming enemy form.~wbuysellsound.wav");

			} 
			// Transfer all our items to the player
			%sound = false;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
				if (%count) {
					if(getItemData(%i).classname != Ammo)
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);
						if (%delta > 0) {
							Player::decItemCount(%this,%i,%delta);
							%sound = true;
							if(getItemData(%i).classname == weapon && $WeaponAmmo[getItemData(%i)] != "" && player::getItemCount(%object,getItemData(%i)) > 0)
							{
								%newCount = Player::getItemCount(%this, $WeaponAmmo[getItemData(%i)]);
								%newDelta = Item::giveItem(%object, $WeaponAmmo[getItemData(%i)],%newCount);
								if(%newdelta >0)
									Player::decItemCount(%this,$WeaponAmmo[getItemData(%i)],%newdelta);
							}
						}
					}

					// I'm still able to pick up ammo from corpses...

//					if(getItemData(%i) == RLauncherClip && (Player::getArmor(%object) == sarmor || Player::getArmor(%object) == sfemale || Player::getArmor(%object) == sarmor2 || Player::getArmor(%object) == sfemale2)
//						&& player::getItemCount(%object, RLauncher) > 0 && player::getItemCount(%object, RLauncherAmmo) < 1 && player::getItemCount(%object, RLauncherClip) < 1)
//					{
//							player::incitemcount(%object, RLauncherClip,1);
//							Player::decItemCount(%this,RLauncherClip,1);
//							%sound = true;
//					}

				}
			}
			if (%sound) {
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	} else if(mech::isMech(%object))
	{
		// Spawn small explosion
	}
}

$Disarm::AWeapon[Knife] = 20;
$Disarm::AWeapon[Knife2] = 20;
$Disarm::AWeapon[SlipTip] = 0;
$Disarm::AWeapon[Crysknife] = 50;
$Disarm::AWeapon[Kindjal] = 50;
$Disarm::AWeapon[Rapier] = 50;
$Disarm::AWeapon[Saber] = 70;

$Disarm::DWeapon[Knife] = 20;
$Disarm::DWeapon[Knife2] = 20;
$Disarm::DWeapon[SlipTip] = 50;
$Disarm::DWeapon[Crysknife] = 50;
$Disarm::DWeapon[Kindjal] = 50;
$Disarm::DWeapon[Rapier] = 70;
$Disarm::DWeapon[Saber] = 70;

$Block::Armor[SoldierArmor] = 50;
$Block::Armor[TrooperArmor] = 30;
$Block::Armor[FremenArmor] = 40;
$Block::Armor[FedaykinArmor] = 40;
$Block::Armor[SardaukarArmor] = 20;
$Block::Armor[BursegArmor] = 20;
$Block::Armor[BasharArmor] = 30;
$Block::Armor[FaceDancerArmor] = 50;

function Player::Disarmed(%player,%DefWeapon,%AttWeapon)
{
	%client = player::Getclient(%player);
	%defarmor = $ArmorName[Player::getArmor(%player)];
	if(%DefArmor == SoldierArmor
	&& ($ServerNameToKeyName[GameBase::getTeam(%client)] == HA 
		|| ($FaceDancerIsSwitched[%client] && $ServerNameToKeyName[%client.impersonatingWhoTeam] == HA)))
		%AtreidesFactor = 10;
	else if(%DefArmor == TrooperArmor
	&& ($ServerNameToKeyName[GameBase::getTeam(%client)] == HA 
		|| ($FaceDancerIsSwitched[%client] && $ServerNameToKeyName[%client.impersonatingWhoTeam] == HA)))
		%AtreidesFactor = 10;
	else
		%AtreidesFactor = 0;
	%Perc = ($Disarm::AWeapon[%AttWeapon] + $Disarm::DWeapon[%DefWeapon] + $Disarm::Armor[%DefArmor]-%AtreidesFactor)/3;
	if((getRandom()*100) < %perc)
		return 1;
	else
		return 0;

}
// Is it a good blocking weapon?
$Block::Weapon[Knife] = 50;
$Block::Weapon[Knife2] = 50;
$Block::Weapon[SlipTip] = 30;
$Block::Weapon[Crysknife] = 90;
$Block::Weapon[Kindjal] = 70;
$Block::Weapon[Rapier] = 90;
$Block::Weapon[Saber] = 80;

// How good are they at blocking? (%)
$Block::Armor[SoldierArmor] = 40;
$Block::Armor[TrooperArmor] = 50;
$Block::Armor[FremenArmor] = 90;
$Block::Armor[FedaykinArmor] = 100;
$Block::Armor[SardaukarArmor] = 60;
$Block::Armor[BursegArmor] = 70;
$Block::Armor[BasharArmor] = 80;
$Block::Armor[FaceDancerArmor] = 40;

function Player::isBlocking(%player)
{

	%obj = %player;//Client::getOwnedObject(%player);

	%weap = Player::getMountedItem(%player,$WeaponSlot);
	if($IsBlocking[%obj]
		&& (%weap == Knife || %weap == Knife2 || %weap == Sliptip || %weap == Crysknife || %weap == Kindjal
		|| %weap == Saber || %weap == Rapier) && !%obj.shieldStrength)
		return 2;
	else if($IsBlocking[%obj]
		&& (%weap == Knife || %weap == Knife2 || %weap == Sliptip || %weap == Crysknife || %weap == Kindjal
		|| %weap == Saber || %weap == Rapier || %weap == -1) && %obj.shieldStrength)
		return 1;
	else
		return 0;
}


// For tackling
$Tackle::TackleWaitTime = 2; // Time to wait before you can attempt another tackle *DEPRECIATED*
$Tackle::TackleDownTime = 2; // Time you're down on the ground for after being tackled
$Tackle::BaseDisarmPercent = 50; // % of the time you'll be disamed when tackled on a "normal" hit // We're not using this anymore.
$Tackle::Elasticity = 1.0; // Elasticity constant for our player objects. 

$Tackle::TrackVelocityWait = 0.1; // Time to wait after each update of the Tackle::TrackVelocity() function

// Special masses for our armors, in 
$Tackle::ArmorMass[SoldierArmor] = 50;
$Tackle::ArmorMass[FremenArmor] = 45;
$Tackle::ArmorMass[FedaykinArmor] = 35;
$Tackle::ArmorMass[FaceDancerArmor] = 45;
$Tackle::ArmorMass[TrooperArmor] = 100;
$Tackle::ArmorMass[BursegArmor] = 70;
$Tackle::ArmorMass[BasharArmor] = 100;
$Tackle::ArmorMass[SardaukarArmor] = 110;

// No damage for now, or maybe ever
//$Tackle::BaseDamage = 0.05; // Base amount of damage done on a "normal" hit. Modified by speed, and armor mass
//$Tackle::DamageType = $TackleDamageType;


// Didn't want to do it.. but players don't have a velocity after an oncollision
function Tackle::TrackVelocity()
{
	for(%id = Client::getFirst(); %id != -1; %id = Client::getNext(%id))
		%id.velocity = Item::getVelocity(%id);
	schedule("Tackle::TrackVelocity();",$Tackle::TrackVelocityWait);
}



function Player::onCollision(%this,%object)
{
	if (Player::isDead(%this)) {
		if (getObjectType(%object) == "Player") {

			if( (Player::getArmor(%object) == fdarmor || Player::getArmor(%object) == fdfemale) && gamebase::Getteam(%this) != gamebase::Getteam(%object)  && !%this.rotten) 
			{
				%cl = GameBase::getOwnerClient(%object);
				$FaceDancerIsSwitched[%cl] = true;
				%cl.impersonatingWho = %this.lastOwnerName;
				%cl.impersonatingWhoSex = %this.lastOwnerSex;
				%cl.impersonatingWhoTeam = %this.lastOwnerTeam;
				%vicarmor = player::Getarmor(%this);
				Player::setArmor(%cl,%Vicarmor);
				Player::setItemCount(%cl, $ArmorName[Player::getArmor(%object)], 0);  
     				Player::setItemCount(%cl, $ArmorName[%VicArmor], 1);

				Client::setSkin(%cl, $KeyNameToTeamSkin[$ServerNameToKeyName[gamebase::Getteam(%this)]]);
				Dune::SwitchSkin(%cl, $ArmorName[%vicArmor],$ServerNameToKeyName[gamebase::Getteam(%this)]);
				Client::sendMessage(%cl,1,"Assuming enemy form.~wbuysellsound.wav");

				%max = getNumItems();
				for (%i = 0; %i < %max; %i = %i + 1) {
					%count = Player::getItemCount(%object,%i);
					if (%count) {
						if ((!$ItemMax[player::Getarmor(%cl), getItemData(%i)] 
						|| $TeamRestrictedItem[$ServerNameToKeyName[%cl.impersonatingwhoTeam], player::Getarmor(%cl), getItemData(%i)])) {
							if(getItemData(%i).className != Armor && getItemData(%i).className != Flag ) {
								%obj = newObject("","Item",getItemData(%i),1,false);
		 		  				schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
		 		 				addToSet("MissionCleanup", %obj);
								if($WeaponAmmo[getItemData(%i)] != "")
								{
									%obj.ammoCount = player::getItemCount(%cl,$WeaponAmmo[getItemData(%i)]);
									player::setItemCount(%cl,$WeaponAmmo[getItemData(%i)],0);
								}
								GameBase::throw(%obj,%cl,2,true);
								%obj.lastowner = %cl;
								%obj.lastownerarmor = player::getarmor(%cl);
								Player::decItemCount(%cl,getItemData(%i),1);
								%sound = true;		
							}
						}
					}
				}
			} 
			%sound = false;
			// Transfer all our items to the player
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%this,%i);
				if (%count) {
					if(getItemData(%i).classname != Ammo)
					{
						%delta = Item::giveItem(%object,getItemData(%i),%count);
						if (%delta > 0) {
							Player::decItemCount(%this,%i,%delta);
							%sound = true;
							if(getItemData(%i).classname == weapon && $WeaponAmmo[getItemData(%i)] != "" && player::getItemCount(%object,getItemData(%i)) > 0)
							{
								%newCount = Player::getItemCount(%this, $WeaponAmmo[getItemData(%i)]);
								%newDelta = Item::giveItem(%object, $WeaponAmmo[getItemData(%i)],%newCount);
								if(%newdelta >0)
									Player::decItemCount(%this,$WeaponAmmo[getItemData(%i)],%newdelta);
							}
						}
					}
				}
			}
			if (%sound) {
				// Play pickup if we gave him anything
				playSound(SoundPickupItem,GameBase::getPosition(%this));
			}
		}
	}
	// Tackle stuff. Modified from "FootBall Mod." I.e. most of this isn't my code. (not initially anyway)
	// -Well.. there've been lots of modifications.. like making it realistic but.. still not my original concept.
	else if(!Player::isDead(%object))
	{
		if(getObjectType(%object) == "Player")
		{
			%id1 = Player::getClient(%this);
			%id2 = Player::getClient(%object);
			%id1Armor = $ArmorName[Player::getArmor(%id1)];
			%id2Armor = $ArmorName[Player::getArmor(%id2)];

			%rotation[%id1] = gamebase::Getrotation(%id1);
			%rotation[%id2] = gamebase::GetRotation(%id2);

			%pos[%id1] = gamebase::Getposition(%id1);
			%pos[%id2] = gamebase::Getposition(%id2);

			%math = getword(%rotation[%id1],2) - getword(vector::getrotaim(%pos[%id1],%pos[%id2]),2);

			%BlockNegated[%id1] = false;
			%BlockNegated[%id2] = false;

			if((%math < -1.6 && %math > -4.68) || (%math > 1.6 && %math < 4.68))
			{
				%BlockNegated[%id1] = true;
			}

			%math = getword(%rotation[%id2],2) - getword(vector::getrotaim(%pos[%id2],%pos[%id1]),2);

			if((%math < -1.6 && %math > -4.68) || (%math > 1.6 && %math < 4.68))
			{
				%BlockNegated[%id2] = true;
			}

			if((Player::isBlocking(%this) && !%blockNegated[%id1]) || (Player::isBlocking(%object) && !%blockNegated[%id2]) || %id1.justThrown || %id2.justThrown)
			{
				//The .SecondEventCall is a little workaround so only the second event
				//of onCollision between two players gets called.
				//if(true||( %id1.SecondEventCall == %id2 && %id2.SecondEventCall == %id1 ))
				//{
					if( (!%id2.tackled && %id2.tackled) || (%id2.tackled && !%id2.tackled) || (!%id2.tackled && !%id2.tackled))
					{
						%Vi[%id1] = %id1.velocity;
						%Vi[%id2] = %id2.velocity;
						%Vi["x",%id1] = getword(%Vi[%id1],0);
						%Vi["y",%id1] = getword(%Vi[%id1],1);
						if(GameBase::getTeam(%id1) != GameBase::getTeam(%id2))
							%Vi["z",%id1] = getword(%Vi[%id1],2);
						else
							%Vi["z",%id1] = 0;
						
						%Vi["x",%id2] = getword(%Vi[%id2],0);
						%Vi["y",%id2] = getword(%Vi[%id2],1);
						if(GameBase::getTeam(%id1) != GameBase::getTeam(%id2))
							%Vi["z",%id2] = getword(%Vi[%id2],2);
						else
							%Vi["z",%id2] = 0;
						
						%M[%id1] = $Tackle::ArmorMass[%id1Armor];
						%M[%id2] = $Tackle::ArmorMass[%id2Armor];


						// Use a simple, basic physics collision/Conservation of momentum Forumla

						// Vaf = / Vai*/_Ma-Mb_\ + Vbi*/__2*Mb_\ \*e
						//	 \     \ Ma+Mb /       \ Ma+Mb / /
						// Vbf = / Vai*/__2*Ma_\ + Vbi*/_Ma-Mb_\ \*e
						//       \     \ Ma+mb /       \ Ma+Mb / /
					
						%Vf["x",%id1] = (%Vi["x",%id1]*((%m[%id1]-%m[%id2])/(%m[%id1]+%m[%id2])) 
								+ %Vi["x",%id2]*((2*%m[%id2])/(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;
						%Vf["y",%id1] = (%Vi["y",%id1]*((%m[%id1]-%m[%id2])/(%m[%id1]+%m[%id2])) 
								+ %Vi["y",%id2]*((2*%m[%id2])/(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;
						%Vf["z",%id1] = (%Vi["z",%id1]*((%m[%id1]-%m[%id2])/(%m[%id1]+%m[%id2])) 
								+ %Vi["z",%id2]*((2*%m[%id2])/(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;

									
						%Vf["x",%id2] = (%Vi["x",%id2]*((%m[%id1]-%m[%id2])/
										(%m[%id1]+%m[%id2])) 
								+ %Vi["x",%id1]*((2*%m[%id1])/
										(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;
						%Vf["y",%id2] = (%Vi["y",%id2]*((%m[%id1]-%m[%id2])/(%m[%id1]+%m[%id2])) 
								+ %Vi["y",%id1]*((2*%m[%id1])/(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;
						%Vf["z",%id2] = (%Vi["z",%id2]*((%m[%id1]-%m[%id2])/(%m[%id1]+%m[%id2])) 
								+ %Vi["z",%id1]*((2*%m[%id1])/(%m[%id1]+%m[%id2])))*$Tackle::Elasticity;
						%Vf[%id1] = %Vf["x",%id1] @ " " @ %Vf["y",%id1] @ " " @ %Vf["z",%id1];
						%Vf[%id2] = %Vf["x",%id2] @ " " @ %Vf["y",%id2] @ " " @ %Vf["z",%id2];

						Item::setVelocity(%id1, %Vf[%id1]);
						Item::setVelocity(%id2, %Vf[%id2]);

						//determine who hit hardest
						//%VelNVelDiff[%id1] = Vector::getDistance(%Vi[%id1], %Vf[%id1]);
						%VelNBaseDiff[%id1] = Vector::getDistance("0 0 0", %Vf[%id1]);
						
						//%VelNVelDiff[%id2] = Vector::getDistance(%Vi[%id2], %Vf[%id2]);
						%VelNBaseDiff[%id2] = Vector::getDistance("0 0 0", %Vf[%id2]);
//echo("VNV1: "@%VelNVelDiff[%id1]); //  13 11
//echo("VNB1: "@%VelNBaseDiff[%id1]); // 13 11
//echo("VNV2: "@%VelNVelDiff[%id2]); //  0  0
//echo("VNB2: "@%VelNBaseDiff[%id2]); // 13 11
// Two sets of answers for each collision...
// One still jump
// 13 and 13
// 13 and 0
// 0  and 13
// 13 and 13
// One still no jump
// 11 and 11
// 11 and 0
// 0  and 11
// 11 and 11
// Both motion no jump
// 22 and 22
// 11 and 11
// 22 and 22
// 11 and 11
// Both motion jump
// 23 and 23
// 13 and 11
// 23 and 23
// 11 and 13

// Rule:
// If you wern't blocking
//  && your VNB > 11
// Then you get tackled.
// If you Were blocking
//  && your VNB > 20
// Then you get tackled.

// id1 is main

						if((!Player::isBlocking(%this) || %blockNegated[%id1]) && %VelNBaseDiff[%id1] > 11.5)
							%status[%id1] = "tackled";
						else if(Player::isBlocking(%this) && %VelNBaseDiff[%id1] > 20)
							%status[%id1] = "tackled";
						if((!Player::isBlocking(%object) || %blockNegated[%id2]) && %VelNBaseDiff[%id2] > 11.5)
							%status[%id2] = "tackled";
						else if(Player::isBlocking(%object) && %VelNBaseDiff[%id2] > 20)
							%status[%id2] = "tackled";

						if(%id1.justThrown && %id2.justThrew != %id1)
							%status[%id2] = "tackled";
						if(%id2.justThrown && %id1.justThrew != %id2)
							%status[%id1] = "tackled";
						%involved[1] = %id1;
						%involved[2] = %id2;
//echo(%status[%id1]);
//echo(%status[%id2]);

						if(%status[%id1] == "tackled" && $Training == true)
							messageall(1,client::getname(%id2) @" tackled "@client::Getname(%id1));
						if(%status[%id2] == "tackled" && $Training == true)
							messageall(1,client::getname(%id1) @" tackled "@client::Getname(%id2));

						for(%i = 1; %i <= 2; %i++)
						{

							%id = %involved[%i];

							if(%status[%id] == "tackled")
							{

								//-----------------
								//  TACKLE
								//-----------------
								//Tackle::doTackle(%pid,%id

								%pid = Client::getOwnedObject(%id);
								%pid.tackle::ownedby = %id;
								Player::setAnimation(%id, 33);
								//Client::setControlObject(%id, Client::getObserverCamera(%id));
								Client::setControlObject(%id, "");
								//Observer::setOrbitObject(%id, %pid, -8, -8, -8);
								%id.tackled = True;
								%pid.tackled = True;	
								schedule("Tackle::setControlObject(" @ %id @ ", " @ %pid @ ");", $Tackle::TackleDownTime);
							}
						}
					}
			}
		}
	}
}

function Tackle::setControlObject(%client, %object)
{
	if(!Player::isDead(%object))
	{
		%client.tackled = false;
		client::SetControlObject(%client,%object);
		%object.tackled = false;
	}
}


function getVelocity(%clientId)
{
	%v = Item::getVelocity(%clientId);
	%cv = round(getWord(%v, 0)) @ " " @ round(getWord(%v, 1)) @ " " @ round(getWord(%v, 2));
	if(%cv == "0 0 0")
		%v = %clientId.velocity;

	return %v;
}

function round(%n)
{
	if(%n < 0)
	{
		%t = -1;
		%n = -%n;
	}	
	else if(%n >= 0)
		%t = 1;

	%f = floor(%n);
	%a = %n - %f;
	if(%a < 0.5)
		%b = 0;
	else if(%a >= 0.5)
		%b = 1;

	return (%f + %b) * %t;
}

function FaceDancerRevertBack(%clientId)
{
	$FaceDancerIsSwitched[%clientId] = false;
	//Return armor to normal
	Player::setItemCount(%clientid, $ArmorName[Player::getArmor(%clientId)], 0);  
	Player::setArmor(%clientId,$ArmorType[Client::getGender(%clientid), FaceDancerArmor]);
	Player::setItemCount(%clientid, FaceDancerArmor, 1);
	//Return skin to normal
	Dune::SwitchSkin(%clientId, $ArmorName[Player::GetArmor(%clientId)],$ServerNameToKeyName[gamebase::Getteam(%clientId)]);
	%player = Client::getControlObject(%clientid);
	if($ShieldOn[%player])
	{

			Client::sendMessage(Player::getClient(%player),0,"Shield Off");
			Player::trigger(%player,$BackpackSlot,false);
			%player.shieldStrength = 0;
			$ShieldOn[%player] = false;
			Player::trigger(%player,4,false);
			Player::UnMountItem(%player, 4);
	}
	if($SuspensorActivate[%player] == 1)
	{

			Client::sendMessage(Player::getClient(%player),0,"Suspensor Pack Off");
			Player::trigger(%player,$BackpackSlot,false);
			disableSuspensorPack(%player);
			Player::trigger(%player,4,false);
			Player::UnMountItem(%player, 4);
	}
	//Drop any non-armor items.
	%sound = false;
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%count = Player::getItemCount(%clientId,%i);
		if (%count) {
			if ((!$ItemMax[$ArmorType[Client::getGender(%clientid), FaceDancerArmor], getItemData(%i)] 
			|| $TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%clientid)], $ArmorType[Client::getGender(%clientId), FaceDancerArmor], getItemData(%i)])) {
				if(getItemData(%i).className != Armor && getItemData(%i).className != Flag ) {
					%obj = newObject("","Item",getItemData(%i),1,false);
		 	  		schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
		 	 		addToSet("MissionCleanup", %obj);
					if($WeaponAmmo[getItemData(%i)] != "")
					{
						%obj.ammoCount = player::getItemCount(%clientID,$WeaponAmmo[getItemData(%i)]);
						player::setItemCount(%clientID,$WeaponAmmo[getItemData(%i)],0);
					}
					GameBase::throw(%obj,%clientId,2,true);
					%obj.lastowner = %clientId;
					%obj.lastownerarmor = player::getarmor(%clientId);
					Player::decItemCount(%clientId,getItemData(%i),1);
					%sound = true;

				}
			}
		}
	}
	while(Player::getItemClassCount(%clientid,"Weapon") > $MaxWeapons[$ArmorType[Client::getGender(%clientid), FaceDancerArmor]])
	{
		%max = getNumItems();
		%abort = false;
		for (%i = 0; %i < %max && !%abort; %i = %i + 1) {
			%count = Player::getItemCount(%clientId,%i);
			if (%count) {
				if(getItemData(%i).className == Weapon) {
					%obj = newObject("","Item",getItemData(%i),1,false);
		 	  		schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
		 	 		addToSet("MissionCleanup", %obj);
					if($WeaponAmmo[getItemData(%i)] != "")
					{
						%obj.ammoCount = player::getItemCount(%clientID,$WeaponAmmo[getItemData(%i)]);
						player::setItemCount(%clientID,$WeaponAmmo[getItemData(%i)],0);
					}
					GameBase::throw(%obj,%clientId,2,true);
					%obj.lastowner = %clientId;
					%obj.lastownerarmor = player::getarmor(%clientId);
					Player::decItemCount(%clientId,getItemData(%i),1);
					%sound = true;
					%abort = true;
				}
			}
		}
	}
	if (%sound) {
		// Play pickup if we gave him anything
		playSound(SoundPickupItem,GameBase::getPosition(%client));
	}
	Client::sendMessage(%clientid,1,"Returning to original form.~wbuysellsound.wav");


}


function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	%vehicle = Client::getControlObject(%client);
	if (%vehicle != %this) {
		if (Gamebase::getDataName(%vehicle) == BasicThopter || Gamebase::getDataName(%vehicle) == VulcanThopter || 		Gamebase::getDataName(%vehicle) == LasgunThopter || Gamebase::getDataName(%vehicle) == Carryall){
			return 1.0;
		}
	}
	if($SuspensorActivated[%client] == 1)
		return 1.0;


//	if (Client::getControlObject(%client) != %this)
//		return 1.0;
//   %time = getIntegerTime(true) >> 5;
//   %lastTime = Player::lastJetTime(%this) >> 10;

//   if ((%lastTime + 1.5) < %time) {
//	return 0.0;
//   } else {
//      %diff = %time - %lastTime;
//      %heat = 1.0 - (%diff / 1.5);
//      return %heat;
//   }
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
   if(!$matchStarted)
      return;
   else if( $CamoActivate[$CamoBody[%client]])
   {
	Client::SendMessage(%client,0,"You'll have to get up to do that.");
	return;
   }	

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
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
	if(%objectId == -1)
		return;
	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;
	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId) && !$FaceDancerIsSwitched[%clientId])
		return;
	if(GameBase::getControlClient(%objectId) != -1) {
		//echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret) {
		if(!GameBase::isPowered(%objectId) && GameBase::getDataName(%this) != StationaryLasgun) {
			Client::SendMessage(%clientId,0,"Turret not powered.");
			return;
		}
	}
	if(!(Client::getOwnedObject(%clientId)).CommandTag && !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
		return;
	}
	if(GameBase::getDamageState(%objectId) == "Enabled") {
		Client::setControlObject(%clientId, %objectId);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function blah()
{
	for(%x = 0;%x < 100;%x++)
		if($Mech::list[%x] != "")
			echo(%x @ " " @$Mech::list[%x]);
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
	Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
	%ownedObject = Client::getOwnedObject(%clientId);
	%ctrlObject = Client::getControlObject(%clientId);
	if(%ownedObject != %ctrlObject) {
		if(%ownedObject == -1 || %ctrlObject == -1)
			return;
		if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
			return;
		if(GameBase::getDataName(%ctrlObject) != "HunterSeeker" && $CamoActivate[$CamoBody[%clientId]] == 0)
			Client::setControlObject(%clientId, %ownedObject);
	}
}

function HurtsShielded(%type) //Diddily Bug Fix
{
	
	if(%type != $StunnerDamageType && %type != $Poison2DamageType && %type != $StabDamageType && %type != $PlasmaDamageType && %type != $CutterayDamageType && %type != $SmallLasDamageType && %type != $RifleLasDamageType && %type != $HeavyLasDamageType && %type != $AsphyxiationDamageType && %type != $AssassinDamageType) // if not one of these, does no damage what so ever.
		return true;
	else
		return false;
}


function Player::Block(%player)
{
	// Can never go below 0.5 due to previous check to get in here.
	if((getSimTime() - %player.lastBlockTime) >= %player.BlockDelay)
	{
		//block for about 0.5 seconds
		$IsBlocking[%player] = true;
		schedule("$isBlocking[" @ %player@ "] = false;", 0.5,%player);
		GameBase::playSound(%player,SoundPickUpWeapon,1);
		Player::setAnimation(%player,49);// 49
		%player.lastBlockTime = getSimTime();

		%player.blockDelay= %player.blockDelay * %player.blockDelay + %player.blockDelay * 2;
		StartDecreasingBlockDelay(%player);
	}
}

function StartDecreasingBlockDelay(%player)
{
	if(%player.BlockDelayDecreasing == "")
	{
		%player.BlockDelayDecreasing = true;	
		Player::decreaseBlockDelay(%player);
	}
}

function Player::decreaseBlockDelay(%player)
{
	if(%player.BlockDelay > 0.2)
	{
		%player.BlockDelay = %player.BlockDelay - %player.BlockDelay*0.05;
		schedule("Player::DecreaseBlockDelay("@%player@");",0.1);
	} else
	{
		%player.BlockDelayDecreasing = "";
	}
}