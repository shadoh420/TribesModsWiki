$TestLocking = 1;
function StingerLoading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,Stinger,$WeaponSlot);
}
	 
function StingerImage::onFire(%player, %slot)
{
    %cl = Player::getClient(%player);
   if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::RedLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("Stinger2Missile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);
	%projectile.owner = %player;
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
										
   } else if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::YellowLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("StingerMissile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);	
	%projectile.owner = %player;	
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
   } else
   {
	Client::sendMessage(%cl,1,"A stronger heat signature is required for lock.~waccess_denied.wav");
   }
}

// On what $Locking::LockStatus value we gain the lock type.
$Locking::GreenLock = 5; // Greenlock isn't anything really..
$Locking::YellowLock = 6;
$Locking::RedLock = 20;

$Locking::LockChargeTime = 0.1;
$Locking::TimeSkip = $Locking::LockChargeTime*4 + 0.1; //Seconds; time for each loop.

$Locking::statusNone = 0;
$Locking::statusInc[Default,"Infared"]   = 0;		$Locking::statusInc[Default,"Radar"]   = 2;
$Locking::statusInc[Tomcat,"Infared"]    = 3;		$Locking::statusInc[Tomcat,"Radar"]    = 3;
$Locking::statusInc[Falcon,"Infared"]    = 3;		$Locking::statusInc[Falcon,"Radar"]    = 3;
$Locking::statusInc[Warthog,"Infared"]   = 2;		$Locking::statusInc[Warthog,"Radar"]   = 3;
$Locking::statusInc[Bomber,"Infared"]    = 2;		$Locking::statusInc[Bomber,"Radar"]    = 1; // Course, this will be set to 1 anyway on the ECM check.
$Locking::statusInc[Gunship,"Infared"]   = 1;		$Locking::statusInc[Gunship,"Radar"]   = 3;
$Locking::statusInc[Hercules,"Infared"]  = 1;		$Locking::statusInc[Hercules,"Radar"]  = 3;
$Locking::statusInc[Sentry,"Infared"]    = 2;		$Locking::statusInc[Sentry,"Radar"]    = 3;

$Locking::statusInc[Apache,"Infared"]    = 1;		$Locking::statusInc[Apache,"Radar"]    = 3;
$Locking::statusInc[Kiowa,"Infared"]     = 1;		$Locking::statusInc[Kiowa,"Radar"]     = 3;
$Locking::statusInc[Hind,"Infared"]      = 1;		$Locking::statusInc[Hind,"Radar"]      = 3;
$Locking::statusInc[Blackhawk,"Infared"] = 1;		$Locking::statusInc[Blackhawk,"Radar"] = 3;

$Locking::Type[Stinger]           = "Infared";
$Locking::Type[StingerLauncher]   = "Infared";
$Locking::Type[SidewinderRocket]  = "Infared";
$Locking::Type[PhoenixRocket]     = "Radar";

$Locking::Type[HARMRocket]        = "Radar";
$Locking::Type[MavRocket]           = "Radar";

//----Diddily's Shiz----
$Locking::GunTargetType[Stinger] = "Aircraft";
$Locking::GunTargetType[StingerLauncher] = "Aircraft";
$Locking::GunTargetType[SidewinderRocket] = "Aircraft";
$Locking::GunTargetType[PhoenixRocket] = "Aircraft";

$Locking::GunTargetType[HARMRocket] = "Ground";
$Locking::GunTargetType[MavRocket] = "Ground";



$Locking::WeaponRedLock[Stinger] = Stinger2Missile;
$Locking::WeaponYellowLock[Stinger] = StingerMissile;
$Locking::WeaponGreenLock[Stinger] = "";

$Locking::WeaponRedLock[StingerLauncher] = Stinger2Missile;
$Locking::WeaponYellowLock[StingerLauncher] = StingerMissile;
$Locking::WeaponGreenLock[StingerLauncher] = "";

$Locking::WeaponRedLock[SidewinderRocket] = Sidewinder2Missile;
$Locking::WeaponYellowLock[SidewinderRocket] = SidewinderMissile;
$Locking::WeaponGreenLock[SidewinderRocket] = SidewinderRocket;

$Locking::WeaponRedLock[PhoenixRocket] = Phoenix2Missile;
$Locking::WeaponYellowLock[PhoenixRocket] = PhoenixMissile;
$Locking::WeaponGreenLock[PhoenixRocket] = PhoenixRocket;

$Locking::WeaponRedLock[HARMRocket] = HARM2Missile;
$Locking::WeaponYellowLock[HARMRocket] = HARMMissile;
$Locking::WeaponGreenLock[HARMRocket] = HARMRocket;

$Locking::WeaponRedLock[MavRocket] = Mav2Missile;
$Locking::WeaponYellowLock[MavRocket] = MavMissile;
$Locking::WeaponGreenLock[MavRocket] = MavRocket;


function Locking::CheckToStartLoop(%this,%Weap)
{
	// If we can't lock with the weapon, or we're attempting to kill the loops, don't venture in.
	if(!$Locking::KillLoop[%this] && !$Locking::Type[%weap] && $Locking::Type[%weap] != "" && $Locking::Type[%weap] != -1)
	{
		$Locking::LockStatus[%this] = 0;
		echo("STARTING LOOP FOR "@%this@" WITH A "@%weap);
		// Enable this long enough to clear out any current lockings.
		$Locking::KillLoop[%this,$Locking::Type[%weap]] = true;
		schedule("$Locking::KillLoop["@%this@",$Locking::Type["@%weap@"]] = false;",$Locking::TimeSkip*2,%this);
		schedule("Locking::LockingLoop("@%this@","@%weap@");",$Locking::TimeSkip*2+0.1,%this);
	}
}

function Locking::LockingLoop(%this,%weap)
{
	// Dead check
	if(getObjectType(%this) == "Player" && Player::isDead(%this))
		return;	
	// No ammo check
	%client = Gamebase::GetControlClient(%this);
	if(!($WeaponAmmo[%weap] == ""||Player::getItemCount(%client,$WeaponAmmo[%weap]) > 0|| ($Clip[%weap] != "" && Player::getItemCount(%client,$Clip[%weap]) > 0)))
		return;
	// Make sure the locking weapon is still equipped.
	if(!$Locking::KillLoop[%this,$Locking::Type[%weap]] && Locking::weaponEquipped(%this,%weap))
	{
echo("Spark");
		
		// Spark 3 times (Three different lengths, and cone-sizes)
		Locking::SparkForTarget(%this, %weap);
		schedule("Locking::SparkForTarget("@%this@","@%weap@");",$Locking::LockChargeTime);
		schedule("Locking::SparkForTarget("@%this@","@%weap@");",$Locking::LockChargeTime*2);

		//schedule("Locking::findTarget("@%this@","@%weap@");",$Locking::LockChargeTime*3);

		// Need to give time for the LockingCharge beams to find a target.
		schedule("Locking::LockingLoopPost("@%this@","@%weap@");",$Locking::LockChargeTime*3,%this);
	}
}

function Locking::LockingLoopPost(%this,%weap)
{		
	// Dead check
	if(getObjectType(%this) == "Player" && Player::isDead(%this))
		return;	
	// No ammo check
	%client = Gamebase::GetControlClient(%this);
	if(!($WeaponAmmo[%weap] == ""||Player::getItemCount(%client,$WeaponAmmo[%weap]) > 0|| ($Clip[%weap] != "" && Player::getItemCount(%client,$Clip[%weap]) > 0)))
		return;
	// Make sure the locking weapon is still equipped.
	if(!$Locking::KillLoop[%this,$Locking::Type[%weap]] && Locking::weaponEquipped(%this,%weap))
	{
		// Sure, we've got a valid target (From FindTarget)
		if($Locking::TargetFound[%this] > 0)
		{
			// Increase our attempt count.
			$Locking::LockStatus[%this] = $Locking::LockStatus[%this] + $Locking::TargetFound[%this];
			// If we've got a RedLock, then we're ready to fire!
			if($Locking::LockStatus[%this] >= $Locking::RedLock)
			{
				// Some  of message?
				Locking::Message(%this,$Locking::Type[%weap]);
				$Locking::LockStatus[%this] = $Locking::RedLock + $Locking::TargetFound[%this];
			} else if($Locking::LockStatus[%this] >= $Locking::YellowLock)
			{
				// Some sort of message?
				if($Locking::LockStatus[%this]%2 == 0)
					Locking::Message(%this,$Locking::Type[%weap]);
				
			}
			// Reset to no target found for the next time we want to check
			$Locking::TargetFound[%this] = $Locking::statusNone;
		}
		// No valid target
		else
		{
			$Locking::AttackTarget[%this] = "";
			$Locking::LockStatus[%this]--;
			if($Locking::LockStatus[%this] < 0)
				$Locking::LockStatus[%this] = 0;
		}
		schedule("Locking::LockingLoop("@%this@","@%weap@");",$Locking::TimeSkip-$Locking::LockChargeTime*3,%this);
	}
}

function Locking::weaponEquipped(%this,%weap)
{	
	// If we don't have a pilot weapon, then we're either a player object, or a vehicle that can't lock...
	if(Vehicle::hasPilotWeapon(%this))
	{
		// And as a result, our equipped weapon is found elsewhere.
		if(gamebase::getcontrolclient(%this).hflink != 2)
		{
			// Same weapon?
			if(%weap == $VehicleOwnedWeapon[%this,$VehicleCurWeapon[%this]])
				return true;
		} else
		{
			// Selected fire-linking; We've got to look through all selected hardpoint weapons.

			if(Vehicle::getDataName(%this) == Apache)
				%hp = $VehicleMaxHardPoints[Vehicle::getDataName(%this)]+2;
			else
				%hp = $VehicleMaxHardPoints[Vehicle::getDataName(%this)];
			// If any are a locker, then return true
			for(%cur=0;%cur <%hp;%cur++)
			{
				if($HPToFire[%this,%cur] && $VehicleHPList[%this,%cur] == %weap)
					return true;
			}
		}
	} else 
	// If we're a player, we're holding our weapon.
	if(getObjectType(%this) == "Player")
	{
		if(%weap == Player::getMountedItem(%this,$WeaponSlot))
			return true;
	}
	return false;
}

function Locking::findTarget(%this, %weap, %target, %rate)
{
	//%target = $Locking::SparkTarget[%this];
	if(Gamebase::GetDataName(%target).classname == "ARMOR")
	{

		%target = %target.vehicle;
	}

	//$Locking::SparkTarget[%this] = "";
	if(%target && %target != "" && %target != -1)
	{
		// Check if it's a valid target
		if(Locking::ValidTarget(%target,%weap) || true)
		{
			
			// If it isn't the same target we had, we need to reset our counter.
			if($Locking::CurTarget[%this] != %target && $Locking::CurRate[%this] > %rate+10)
			{
				// If we're a tomcat, we've got a sweet tracking system.
				if(Vehicle::isTomcat(%this))
				{
					// Save our cur target.
					$Locking::TomcatTracking[%this,$Locking::CurTarget[%this]] = $Locking::LockStatus[%this];
					$Locking::TomcatTrackTime[%this,$Locking::CurTarget[%this]] = getSimTime(); 
	
					// Already tracking this target? Pull it out.
					if($Locking::TomcatTracking[%this,%target] > 0 && $Locking::TomcatTrackTime[%this,%target] > 0)
					{
						// Divide any time that passed by our Timeskip, and subtract it from the last lock status.
							// This is to reflect the target degredation that we have in Locking::LockingLoop
						$Locking::LockStatus[%this] = $Locking::TomcatTracking[%this,%target] - 
							floor((getSimTime() - $Locking::TomcatTracktime[%this,%target])/$Locking::TimeSkip);
					
						// Just in case.
						if($Locking::LockStatus[%this] < 0)
							$Locking::LockStatus[%this] = 0;
					
						// Update the values.	
						$Locking::TomcatTracking[%this,%target] = $Locking::LockStatus[%this];
						$Locking::TomcatTractTime[%this,%target] = getSimTime();
					}
				} else
					$Locking::LockStatus[%this] = $Locking::statusNone;
			}
			// Cur target is for always remembering which our last target was.
			$Locking::CurTarget[%this] = %target;
			$Locking::CurRate[%this] = %rate;
			// Attack target is to tell us if we actually have a target ready for attacking.
			$Locking::AttackTarget[%this] = %target;
			
			// Basically, we could run into an instance where we lose our target for a second. We don't want to kill
			// the Cur target, because if we regain it, we want the lock still to be fairly strong (depending on how
			// long we lost it for). But during the interum, we don't want to be able to "fire" at the target that's
			// locked, because.. it isn't there.


			// If we're an aircaft (or a countermeasure), find out our inc amount for the weapontype
			if(Vehicle::isAircraft(%target))
				$Locking::TargetFound[%this] = $Locking::statusInc[Vehicle::GetDataName(%target),$Locking::Type[%weap]];
			// Otherwise, use the default.
			else
				$Locking::TargetFound[%this] = $Locking::statusInc[Default,$Locking::Type[%weap]] * (1+3/%rate);
			
			// Check to see if they're using an ECM, or in an ECM zone.
			if(player::getsensorsupression(%this) > 0 && $locking::Type[%weap] == "Radar")
				$Locking::TargetFound[%this] = 1;
	
		}
		// If we arn't a valid target, then just consider us not having a target.
		else
			$Locking:TargetFound[%this] = $Locking::statusNone;		
	}
	else
		$Locking:TargetFound[%this] = $Locking::statusNone;		
}


function Locking::ValidTarget(%target,%weap)
{
	%type = $Locking::Type[%weap];

	// HARMs will only lock onto radar sources (Sensors and SAMs)
	if( %Weap == HARMRocket && (
		GameBase::getDataName(%target).className == Sensor ||  GameBase::getDataName(%target).className == DeployableSensor
		|| Gamebase::GetDataName(%target) == DeployableSAM || Gamebase::GetDataName(%target) == RocketTurret))
		return true;
	else if(%weap == HARMRocket)
		return false;
	
	// Mavarick missiles will only lock onto staticshapes/Tanks/Sensors/Turrets
	if(%weap == MavRocket && (
		Gamebase::GetDataName(%target).className == Staticshape || Vehicle::isTank(%target) || 
		GameBase::getDataName(%target).className == Sensor ||  GameBase::getDataName(%target).className == DeployableSensor
		|| Gamebase::GetDataName(%target) == DeployableSAM || Gamebase::GetDataName(%target) == RocketTurret))
		return true;
	else if(%weap == MavRocket)
		return false;

	// All aircraft are always valid.
	if(Vehicle::isAircraft(%target))
		return true;

	// Tanks and staticshapes are only valid if it's Radar lock
	if(%type == "Radar" && (Vehicle::isTank(%target) || getObjectType(%target).className == StaticShape))
		return true;

	// Flare is only valid if it's an infered lock
	if(%type == "Infared" && getObjectType(%target) == Flare)
		return true;
	
	// Chaff is only valid if it's a Radar lock
	if(%type == "Radar" && getObjectType(%target) == Chaff)
		return true;
	
	return false;
}

function Locking::Message(%this,%type)
{
	%cl = gamebase::getcontrolclient(%this);
	%target = gamebase::Getcontrolclient($Locking::AttackTarget[%this]);
	if($Locking::LockStatus[%this] < $Locking::RedLock)
	{
		if($Locking::LockStatus[%this] >= $Locking::YellowLock && 
			$Locking::LockStatus[%this] < ($Locking::YellowLock + $Locking::TargetFound[%this]))
		{
			Client::sendMessage(%cl,0,"** Aquiring "@%type@" Lock **");
			Client::sendMessage(%target,1,"* Warning * The enemy is attempting to aquire a lock on you!");
		}
		bottomprint(%cl, "<f4><jc>** Aquiring "@%type@" Lock **", 1.05);
		bottomprint(%target, "<f4><jc>* Warning * The enemy is attempting to aquire a lock on you!", 1.05);
		Client::sendMessage(%cl,0,"~wmine_act.wav");
		Client::sendMessage(%target,0,"~waccess_denied.wav");
		
	} else if($Locking::LockStatus[%this] >= $Locking::RedLock)
	{
		if($Locking::LockStatus[%this] >= $Locking::RedLock && 
			$Locking::LockStatus[%this] < ($Locking::RedLock + $Locking::TargetFound[%this]))
		{
			Client::sendMessage(%cl,1,"*** "@%type@" Lock Aquired ***");
			Client::sendMessage(%target,1,"*** WARNING! *** The enemy has a lock on you!");
		}
		bottomprint(%cl, "<f4><jc>*** "@%type@" Lock Aquired ***", 0.55);
		bottomprint(%target, "<f5><jc>*** WARNING! *** The enemy has a lock on you!", 0.55);
		Client::sendMessage(%cl,0,"~wmine_act.wav");
		Client::sendMessage(%target,0,"~waccess_denied.wav");
	}
}

function spark(%cl)
{
echo(client::Getcontrolobject(%cl));
	%targ = Locking::SparkForTarget(client::Getcontrolobject(%cl));
	echo("*"@%targ@"*");
}
$Locking::MaxDistance = 1000;
$Locking::MinimumCloseness = 15;
$Locking::Offset["small"] = 0.4;
$Locking::Offset["medium"] = 0.5;
$Locking::Offset["large"] = 1.0;
$Locking::Offset["unknown"] = 0.0;

function Locking::RemoveNullFromList(%this, %type)
{
$Locking::TargetsList[%type] = String::ReplaceAll($Locking::TargetsList[%type], %this@" ", " ");
}

function Locking::SparkForTarget(%this,%weap)
{
	
	%trans = GameBase::getMuzzleTransform(%this);
	%pos=getword(%trans, 9)@" "@getword(%trans, 10)@" "@getword(%trans, 11);
	%AimVector=getword(%trans, 3)@" "@getword(%trans, 4)@" "@getword(%trans, 5);
	%x = 0;
	%type = $Locking::GunTargetType[%weap];
	if(getObjectType(%this) == "Flier")
	{
		%up = vector::getfromrot(vector::add(gamebase::getrotation(%this), $pi/2@" 0 0"), $Locking::Offset[Vehicle::GetSize(%this)]);
		%up = vector::getfromrot(vector::add(gamebase::getrotation(%obj), $pi/2@" 0 0"), 2);

	}
	
	while(getword($Locking::TargetsList[%type], %x) != -1)
	{
		%obj = getword($Locking::TargetsList[%type], %x);
		if(gamebase::getposition(%obj) == "0 0 0")
		{
			echo("Removing " @ %obj @ " from " @ %type @ " due to it not existing. Name: " @ object::getname(%obj));
			Locking::RemoveNullFromList(%obj, %type);
			echo("RAR");
			%x--;
			//return;
		}
		%x++;
		//echo(%this @" is Sparking "@%obj);
		//    Opposite Leg
		//  	   |
		//         v
		//    VEH____.
		//	 \   |
		//    --->\  | <--AimVector/AdjacentLeg
		//    |	   \ |
		//    |     \|
		//    |	     GUN
		//  GuntoVehicleVector		
		if(vector::getdistance(%pos, gamebase::getposition(%obj)) < $Locking::MaxDistance)
		{

			%GunToVehicleVector = vector::sub(gamebase::getposition(%obj), %Pos);
			%dot = vector::dot(%aimvector, %GunToVehicleVector);
			if(%dot > 0)
			{
			%AdjacentLeg = vector::scale(%AimVector, %dot);
			%OppositeLeg = vector::sub(%GunToVehicleVector, %AdjacentLeg);
			%OppDist = vector::getdistance(%oppositeLeg, "0 0 0");
			
			if(%OppDist < $Locking::MinimumCloseness)
			{	
				%middle = "0 0 0";
				if(getObjectType(%obj) == "Flier")
					%middle = vector::getfromrot(vector::add(gamebase::getrotation(%obj), $pi/2@" 0 0"), $Locking::Offset[Vehicle::GetSize(%obj)]);
				if(getObjectType(%obj) == "StaticShape")
					%middle = vector::getfromrot(vector::add(gamebase::getrotation(%obj), $pi/2@" 0 0"), 0.5);


				//echo(%middle);
				//gamebase::Setposition($moo, vector::add(gamebase::getposition(%obj), %middle));
				//gamebase::Setrotation($moo, vector::add(gamebase::getrotation($moo), 0@" 0 "@$pi/12));
				if(getLosInfo(%pos, vector::add(gamebase::getposition(%obj), %middle),~0))
				{
					
					if($LOS::Object == %obj)
					{
					echo(client::getname(player::getclient(%this))@" found "@%obj@" of type "@%type@" at "@vector::add(gamebase::getposition(%obj), %middle)@" OFF:" @ %OppDist);
					Locking::findTarget(%this, %weap, %obj, %OppDist);
					
				} else {
					echo("NO LOS "@$LOS::Object@" ("@getobjectype($LOS::Object)@"/"@Object::getname($LOS::Object)@")");

				}
				}
			}
			}
		}
	}


	if($Locking::SparkTarget[%this] == "" && false)
	{
		%trans = GameBase::getMuzzleTransform(%this);
		if(%num == 1)
			%projectile = Projectile::spawnProjectile("LockingCharge", %trans, %this, "0 0 0");
		else if(%num == 2)
			%projectile = Projectile::spawnProjectile("Locking2Charge", %trans, %this, "0 0 0");
		else if(%num == 3)
			%projectile = Projectile::spawnProjectile("Locking3Charge", %trans, %this, "0 0 0");
		schedule ("deleteobject(" @ %projectile @ ");",$Locking::LockChargeTime);
	}
}
function StartHeli(%cl)
{
for(%x = 0; %x <4; %x++)
{
%blade = newobject("Blade", StaticShape, "AAIBorderMarker");
gamebase::setrotation(%blade, $pi/2@" 0 "@$pi * (%x/2));
Heli(%cl, %blade);
}
}

function slocktest(%cl)
{
player::setitemcount(%cl, "MaverickModule", 10);
player::setarmor(%cl, earmor);
schedule("Player::setarmor("@%cl@", larmor);", 20);


}

function Heli(%cl, %blade)
{
if($killheli)
{

	deleteobject(%blade);
	return;
}
%trans = GameBase::getMuzzleTransform(%cl);
	%pos=getword(%trans, 9)@" "@getword(%trans, 10)@" "@getword(%trans, 11);
	%AimVector=getword(%trans, 3)@" "@getword(%trans, 4)@" "@getword(%trans, 5);
%xat = getword(gamebase::getrotation(%cl), 2);
%add= (vector::getfromrot(vector::add(vector::getrotation(%aimvector), $pi@" 0 0"), 3.5));
%x = $pi/2 - $pi/12*(vector::dot(vector::normalize(vector::flatten(%AimVector)), vector::getfromrot(vector::add($pi/2@" 0 0", gamebase::getrotation(%blade)))));
%blade.owner = %cl;

gamebase::setrotation(%blade, vector::add($pi/2@" 0 "@getword(gamebase::getrotation(%blade), 2), 0@" "@$pi/4@" "@$pi/8));
gamebase::setposition(%blade, vector::add(gamebase::getposition(%cl), %add));

schedule("Heli("@%cl@", "@%blade@");", 0.05);
}
function AAIBorderMarker::oncollision(%this, %object)
{
if(vector::getdistance(gamebase::getposition(%this), gamebase::getposition(%object)) > 0&& %this.owner!= player::getclient(%object))
	gamebase::applydamage(%object, $StabDamageType , 0.5, gamebase::getposition(%object), "0 0 0", "0 0 10", 2048);


}
function testTriangle(%vec1, %vec2)
{
	%AimVector = %vec1;
	%GunToVehicleVector = %vec2;
	%AdjacentLeg = vector::scale(%AimVector, vector::dot(%aimvector, %GunToVehicleVector));
	%OppositeLeg = vector::sub(%GunToVehicleVector, %AdjacentLeg);
	echo(vector::dot(%aimvector, %GunToVehicleVector)@" "@%AdjacentLeg@" "@%oppositeleg);

}
function test2los(%cl, %detail, %targ)
{
	%pl = %cl;
	%t=gamebase::getmuzzletransform(%pl);
	%p=getword(%t, 9)@" "@getword(%t, 10)@" "@getword(%t, 11);
	%w=getword(%t, 3)@" "@getword(%t, 4)@" "@getword(%t, 5);
	%rot = vector::getrotation(%w);
	%rot = ($pi/2 + getword(%rot, 0))@" 0 "@getword(%rot, 2);
	%smov = vector::getfromrot(%rot, 1);
	%mov = vector::getfromrot(%rot, 1000);
	echo(%rot@" vs "@%smov);
	%tp = vector::add(gamebase::getposition(%cl), vector::add(%smov, "0 0 2"));
if(!%targ)
testlos(%p, vector::add(%p, %mov), %detail);
else
testlos(%p, vector::add(gamebase::getposition(%targ), "0 0 0.5"), %detail);

}
function testlos(%pos1, %pos2, %detail)
{
if(getLosInfo(%pos1, %pos2, %detail))
{
	echo($LOS::Position@" "@$LOS::Normal@" "@$LOS::Object@" "@Object::getname($LOS::Object));
	if(!$rawrrawr)
		$rawrrawr = newObject(AAIPathMarker, StaticShape, AAIPathMarker);
	else
	{
		deleteobject($rawrrawr);
		$rawrrawr = newObject(AAIPathMarker, StaticShape, AAIPathMarker);

	}
	gamebase::setposition($rawrrawr, $LOS::Position);
	gamebase::setrotation($rawrrawr, vector::getrotation($LOS::Normal));
	export("$LOS*", "config\\export1.cs", 0);
	}



}

//Types:
//Aircraft/Chaff/Flare
//Tank
//Sensor/Turret
//Targetting Laser
$Locking::ListTypeCount = -1;

$Locking::ListType[$Locking::ListTypeCount++] = "Aircraft";
$Locking::ListType[$Locking::ListTypeCount++] = "Ground";
$Locking::ListType[$Locking::ListTypeCount++] = "Laser";
$Locking::ListType[$Locking::ListTypeCount++] = "Unknown";
function Locking::GetTypeFromObject(%this)
{
	%type = "Unknown";

	if(Vehicle::isAirCraft(%this))
		%type = "Aircraft";
	if(Vehicle::isTank(%this))
		%type = "Tank";

	if(getObjectType(%this) == "Turret" || Gamebase::GetDataName(%this).classname == "Turret")
		%type = "Turret";
	
	if(getObjectType(%this) == "Sensor" || Gamebase::GetDataName(%this).classname == "DeployableSensor")
		%type = "Sensor";

	if(Gamebase::GetDataName(%this) == "SolarPanel")
		%type = "Ground";	

	if(Gamebase::GetDataName(%this) == "LaserPoint")
		%type = "Laser";

	if(Gamebase::GetDataName(%this) == "Flare")
		%type = "Flare";
	
	if(Gamebase::GetDataName(%this) == "Chaff")
		%type = "Chaff";

	if(%type == "Unknown")
		echo("Still Unknown: "@%this@"   DN: "@Gamebase::GetDataName(%this)@"   OBJTYPE: "@getObjectType(%this)@"   CLASS: "@Gamebase::GetDataName(%this).classname);
	
	return Locking::GetRealType(%type);	
}


function Locking::GetRealType(%type)
{


if(%type == "Aircraft" || %type == "Chaff" || %type == "Flare")
	return "Aircraft";


if(%type == "Tank" || %type == "Sensor" || %type == "Turret")
	return "Ground";


if(%type == "Laser")
	return "Laser";

return "Unknown";

}
function L::GRT(%type)
{
	return Locking::GetRealType(%type);
}
function Locking::AddToList(%this)
{
	%type = Locking::GetTypeFromObject(%this);
	$Locking::TargetsList[%type] = $Locking::TargetsList[%type] @ %this @ " ";
	//schedule("Locking::CheckGroup("@%this@");", 1);
}

function Locking::CheckGroup(%this)
{
if(Object::GetName(getgroup(%this)) != "MissionCleanup")
	{
		echo("Moved "@%this@" to MissionCleanup");
		AddToSet("MissionCleanup", %this);
		//Vehicle::onAdd(%this);
	}

}

function Locking::SwapOut(%this, %newVeh)
{
	%type = Locking::GetTypeFromObject(%this);
	$Locking::TargetsList[%type] = String::ReplaceAll($Locking::TargetsList[%type], %this@" ", %newveh@" ");
}

function Locking::RemoveFromList(%this)
{
	%type = Locking::GetTypeFromObject(%this);
	$Locking::TargetsList[%type] = String::ReplaceAll($Locking::TargetsList[%type], %this@" ", " ");
}


function Locking::ClearList(%this)
{
	for(%x = 0; %x < $Locking::ListTypeCount; %x++)
	{
		$Locking::TargetsList[%x] = "";
	}
}

function Locking::CheckForTargets(%group)
{

	group::iteraterecursive(%group, Locking::FindNewTargets);


}
function Locking::FindNewTargets(%this)
{
	if(Locking::GetTypeFromObject(%this) != "Unknown")
	{
		if(Gamebase::GetPosition(%this) != "0 0 0")
		{	
			Locking::AddToList(%this);
		}
	}
}
function Locking::CheckForNewVehicles(%group)
{
	return;
	$Locking::NotFoundList = $Locking::TargetsList;
	group::iteraterecursive(%group, Locking::FindNewVehicles);
	%x = 0;
	while(getword($Locking::NotFoundList, %x) != -1)
	{
		%this = getword($Locking::NotFoundList, %x);
		%x++;
		if(Gamebase::GetPosition(%this) != "0 0 0" || !Vehicle::isVehicle(%this))
		{
			echo(%this@"'s removal was missed...");
			Locking::RemoveFromList(%this);
		} else if(Object::GetName(getgroup(%this)) != "MissionCleanup")
		{
			echo("Moved "@%this@" to MissionCleanup");
			AddToSet("MissionCleanup", %this);
			Vehicle::onAdd(%this);
		} else {
			echo("ERROR: Locking check couldn't find this: "@%this);
		}
	}
}

function Locking::FindNewVehicles(%this)
{
	if(Vehicle::isVehicle(%this))
	{
		if(Gamebase::GetPosition(%this) != "0 0 0")
		{
			if(String::FindSubStr($Locking::NotFoundList, %this) != -1)
			{
				$Locking::NotFoundList = String::ReplaceAll($Locking::NotFoundList, %this@" ", " ");
			} else {
				Locking::AddToList(%this);
			}
		}
	}
}