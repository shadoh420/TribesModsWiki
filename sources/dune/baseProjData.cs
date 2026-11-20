# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$StabDamageType        = 14;
$PoisonDamageType      = 15;
$StunnerDamageType     = 16; // *Depreciated* must define a new type to make sure it goes through shields
$NukeDamageType        = 17;
$Poison2DamageType     = 18; // had to define a new one for the Slip-Tip, seeing as how it should go through shields, and the other shouldnt
$WormDamageType	       = 19; // Worm attack!!!
//Keep all three at same damage level as we may only use one to represent all 3.
$CutterayDamageType    = 20;
$SmallLasDamageType    = 21;
$RifleLasDamageType    = 22;
$HeavyLasDamageType    = 23;
$AsphyxiationDamageType = 24;
$LargeBulletDamageType   =  25;
$ThrownWeaponDamageType = 26;
$ThrownPoisonWeaponDamageType = 27;
$TackleDamageType = 28;
$AssassinDamageType = 29;
$GaroteDamageType = 30;
$HSDamageType = 31;
$HS2DamageType = 32;

$DamageType[-1] = "Impact";
$DamageType[0] = "Landing";
$DamageType[1] = "Bullet";
$DamageType[2] = "Energy";
$DamageType[3] = "Plasma";
$DamageType[4] = "Explosion";
$DamageType[5] = "Shrapnel";
$DamageType[6] = "Laser";
$DamageType[7] = "Mortar";
$DamageType[8] = "Blaster";
$DamageType[9] = "Electricity";
$DamageType[10] = "Crush";
$DamageType[11] = "Debris";
$DamageType[12] = "Missle";
$DamageType[13] = "Mine";
$DamageType[14] = "Stab";
$DamageType[15] = "Poison";
$DamageType[16] = "Stunner";
$DamageType[17] = "Nuke";
$DamageType[18] = "Poison2";
$DamageType[19] = "Worm";
$DamageType[20] = "Cutteray";
$DamageType[21] = "SmallLas";
$DamageType[22] = "RifleLas";
$DamageType[23] = "HeavyLas";
$DamageType[24] = "Asphyxiation";
$DamageType[25] = "LargeBullet";
$DamageType[26] = "ThrownWeapon";
$DamageType[27] = "ThrownPoisonWeapon";
$DamageType[28] = "Tackle";
$DamageType[29] = "Assassin";
$DamageType[30] = "Garote";
$DamageType[31] = "HS";
$DamageType[32] = "HS2";

//---------------------------------------------------------
//********************NEW PROJECTILES**********************
//---------------------------------------------------------
GrenadeData WormAttack
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = wormExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 20.0; // 0.3
   damageType         = $WormDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

//Unarmed

//===========FDNECKBREAK============
BulletData NeckBreak
{
   bulletShapeName    = "breath.dts";
   explosionTag       = NeckExp;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0;
   damageType         = $AssassinDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========CORRINONECKGAROTE============
BulletData NeckGarote
{
   bulletShapeName    = "breath.dts";
   explosionTag       = NeckExp;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0;
   damageType         = $GaroteDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------




//BLADES

//===========KNIFESTAB============
BulletData KnifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0.15;
   damageType         = $StabDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========SLIP-TIPSTAB============
BulletData SlipTipStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.0;
   
   damageClass        = 0;
   damageValue        = 0.07;
   damageType         = $Poison2DamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========CRYSKNIFESTAB============
BulletData CrysknifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.0;
   
   damageClass        = 0;
   damageValue        = 0.7;
   damageType         = $StabDamageType;

   muzzleVelocity     = 20.0;
   totalTime          = 0.1;
   
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========KINDJALSTAB============
BulletData KindjalStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.0;
   
   damageClass        = 0;
   damageValue        = 0.3;
   damageType         = $StabDamageType;

   muzzleVelocity     = 25.0;
   totalTime          = 0.1;
  
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========RAPIERSTAB============
BulletData RapierStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.0;
   
   damageClass        = 0;
   damageValue        = 0.25;
   damageType         = $StabDamageType;

   muzzleVelocity     = 35.0;
   totalTime          = 0.1;
  
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//===========SABERSTAB============
BulletData SaberStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   mass               = 0.0;
   
   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $StabDamageType;

   muzzleVelocity     = 35.0;
   totalTime          = 0.1;
  
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//-----------------------------------------------

//Projectiles

//===========PISTOLBULLET============
BulletData PistolBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};
//-----------------------------------------------

//===========MAULABULLET============
BulletData MaulaBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $PoisonDamageType;

   aimDeflection      = 0.0065;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
};
//-----------------------------------------------

//===========STUNNERBULLET============
BulletData StunnerBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $Poison2DamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 25.0;
   totalTime          = 3.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 1;
};
//-----------------------------------------------

//===========RIFLEBULLET============
BulletData RifleBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData RifleBulletSingle
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
//-----------------------------------------------

//===========MACHINEBULLET============
BulletData MachineBullet4
{
   bulletShapeName    = "laserhit.dts";
   validateShape      = false;
   explosionTag       = MachineExp1;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $LargeBulletDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData MachineBullet3
{
   bulletShapeName  = "laserhit.dts";
   explosionTag     = MachineExp1;
   collisionRadius  = 0.0;
   expRandCycle       = 3;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $LargeBulletDamageType;

   explosionRadius  = 6.5;
   kickBackStrength = 75.0;
   muzzleVelocity   = 425.0;
   terminalVelocity = 425.0;
   acceleration     = 0.0;
   totalTime        = 1.5;
   liveTime         = 0.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 0;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 30;

   soundId = SoundJetHeavy;
};


GrenadeData MachineBullet2
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = MachineExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 2.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 40.44;
   damageType         = $LargeBulletDamageType;

   explosionRadius    = 1.01;
   kickBackStrength   = 75.0;
   maxLevelFlightDist = 8000.0;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 1.0;
   smokeName              = "laserhit.dts";
};

GrenadeData MachineBullet
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = MachineExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 2.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 40.44;
   damageType         = $LargeBulletDamageType;

   explosionRadius    = 1.01;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 8000.0;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 1.0;
   smokeName              = "breath.dts";
};

BulletData RMachineBullet
{
   bulletShapeName    = "laserhit.dts";
   validateShape      = false;
   explosionTag       = MachineExp1;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $LargeBulletDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//-----------------------------------------------


//===========SNIPERBULLET============
BulletData SniperBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.5;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $LaserDamageType;

   aimDeflection      = 0.00005;
   muzzleVelocity     = 1000.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 0.1;
   tracerLength       = 1;
};

//~~~~~~~~~~~~~~START ROCKET CODE~~~~~~~~~~~~~~~~~~~~~~~~
RocketData StingerRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 6.5;
   kickBackStrength = 175.0;
   muzzleVelocity   = 70.0;
   terminalVelocity = 90.0;
   acceleration     = 5.0;
   totalTime        = 8.0;
   liveTime         = 0.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData StingerRocketSlow
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 6.5;
   kickBackStrength = 175.0;
   muzzleVelocity   = 5.0;
   terminalVelocity = 5.0;
   acceleration     = 0.0;
   totalTime        = 30.0;
   liveTime         = 0.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

SeekingMissileData StingerMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;
   explosionRadius  = 6.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 90.0;
   totalTime         = 8;
   liveTime          = 8;
   seekingTurningRadius    = 5;
   nonSeekingTurningRadius = 60.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function StingerRocket::onAdd(%this)
{
	schedule("StingerBoxCheck(" @ %this @ ");",0.5,%this);
}

function StingerBoxCheck(%this)
{
	if(%this && %this != -1 && %this != "")
	{
		%position = GameBase::getPosition(%this);  //GameBase::getLOSInfo(%player,3); dont test where the shot is aimed, test from the position of the bullet
		%set = newObject("set",SimSet); // make new box for testing.
		if(containerBoxFillSet(%set,$VehicleObjectType,%position,60,60,60,0)){ // if we find a player or vehicle in the box,
	
			%num = containerBoxFillSet(%set,$VehicleObjectType,%position,60,60,60,0);
			%num = CheckForAircraft(%set, %position, %num);
			if(%num != -1){ // as long as we found a flying vehicle
				%player = 2048; // have to make the attacker flag on the projectile a null or else things will crash.
				%target = Group::getObject(%set,%num); // get the objNum of the found object.
				// GameBase::getDataName(
				%rotation = GameBase::getRotation(%this); // get rotation of object...
				%velocity = Item::getVelocity(%this); // get velocity of object...
				%transform = "0 0 0 0 0 0 "@ %rotation @" "@ %position; // make the transform for the new object...
			
				Projectile::spawnProjectile(StingerMissile, %transform, %player, %velocity, %target); // spawn new seeking projectile
				//warningMessage(%target); // send warning to target
				deleteObject(%this); // and delete original projectile
			} else { // if we didnt find a flying vehicle,
				schedule("StingerBoxCheck(" @ %this @ ");",0.05,%this); // then run this bad boy again.
			}
		} else { // else if nothing significant is inside the box
			schedule("StingerBoxCheck(" @ %this @ ");",0.05,%this); // then run this bad boy again.
		}
		deleteObject(%set); // then delete current box no matter what.
	}				
	
}


RocketData MechRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.75;

   soundId = SoundJetHeavy;
};



SeekingMissileData MechMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 200.0;
   totalTime         = 5;
   liveTime          = 5;
   seekingTurningRadius    = 5;
   nonSeekingTurningRadius = 60.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};
function MechRocket::onAdd(%this)
{
	schedule("MechBoxCheck(" @ %this @ ");",0.5,%this);
}

function MechBoxCheck(%this)
{
	%position = GameBase::getPosition(%this);  //GameBase::getLOSInfo(%player,3); dont test where the shot is aimed, test from the position of the bullet
	%set = newObject("set",SimSet); // make new box for testing.
	if(containerBoxFillSet(%set,$VehicleObjectType,%position,200,200,200,0)){ // if we find a player or vehicle in the box,

		%num = containerBoxFillSet(%set,$VehicleObjectType,%position,200,200,200,0);
		%num = CheckForVehicle(%set, %position, %num);
		if(%num != -1){ // as long as we found a flying vehicle
			%player = 2048; // have to make the attacker flag on the projectile a null or else things will crash.
			%target = Group::getObject(%set,%num); // get the objNum of the found object.
			// GameBase::getDataName(
			%rotation = GameBase::getRotation(%this); // get rotation of object...
			%velocity = Item::getVelocity(%this); // get velocity of object...
			%transform = "0 0 0 0 0 0 "@ %rotation @" "@ %position; // make the transform for the new object...
		
			Projectile::spawnProjectile(MechMissile, %transform, %player, %velocity, %target); // spawn new seeking projectile
			//warningMessage(%target); // send warning to target
			deleteObject(%this); // and delete original projectile
		} else { // if we didnt find a flying vehicle,
			schedule("MechBoxCheck(" @ %this @ ");",0.1,%this); // then run this bad boy again.
		}
	} else { // else if nothing significant is inside the box
		schedule("MechBoxCheck(" @ %this @ ");",0.1,%this); // then run this bad boy again.
	}
	deleteObject(%set); // then delete current box no matter what.
				
	
}


//~~~~END ROCKETS~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

SeekingMissileData HunterSeekerProj
{
   bulletShapeName = "force.dts";
   explosionTag    = knifeExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 10.5;
   damageType       = $HSDamageType;
   explosionRadius  = 1.01;
   kickBackStrength = 0.0;

   muzzleVelocity    = 100.0;
   totalTime         = 2;
   liveTime          = 2;
   seekingTurningRadius    = 60;
   nonSeekingTurningRadius = 60.0;
   proximityDist     = 0.2;
   smokeDist         = 0.00;

   lightRange       = 0.01;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.0;

   soundId = SoundShieldOn;
};


//===============FLAMETHROWERSTUFF===============

GrenadeData Flame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 5.0;
   mass               = 5.0;
   elasticity         = 0.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3; // 0.3
   damageType         = $PlasmaDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 300.0;
   totalTime          = 0.3;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData AirFlame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 50.0;
   totalTime          = 100.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

RocketData FlameExplosion
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 4.0;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 0.0001;
   terminalVelocity = 0.0001;
   acceleration     = 0.0001;
   totalTime        = 0.0001;
   liveTime         = 0.0001;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

GrenadeData FlameExplosionTwo
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 7.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData FlameExplosionThree
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData PillerFlame
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = -10.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0; // 0.3
   damageType         = $PlasmaDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 200.0;
   totalTime          = 3.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

function PillerFlame::onAdd(%this)
{
	schedule("FlameTrail(" @ %this @ ");",0.3,%this); 
}

function FlameTrail(%this)
{
	if(%this){
		%position = GameBase::getPosition(%this);
		%player = %this.owner;
		//%rotation = GameBase::getRotation(%this); // get rotation of object...
		%velocity = Item::getVelocity(%this); // get velocity of object...
		%transform = "0 0 0 0 0 0 0 0 0 "@ %position; // make the transform for the new object...
			
		Projectile::spawnProjectile(PillerExplosion, %transform, %player, %velocity); // spawn new projectile
		schedule("Projectile::spawnProjectile(PillerExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.2, %this); 
		schedule("Projectile::spawnProjectile(PillerExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.4, %this); 
		schedule("Projectile::spawnProjectile(PillerExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.6, %this); 
		schedule("Projectile::spawnProjectile(PillerExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 0.8, %this); 
		schedule("Projectile::spawnProjectile(PillerExplosion, \""@ %transform @ "\", \"" @ %player @ "\", \"" @ %velocity @ "\");", 1.0, %this); 
		schedule("FlameTrail(" @ %this @ ");",0.2,%this); 
	}

}
GrenadeData PillerExplosion
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasma2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

//**New stuff for shield-down firing.

GrenadeData ShieldDispOne
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 1.0;
   smokeName              = "plasmabolt.dts";
};

GrenadeData ShieldDispTwo
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 1.0;
   smokeName              = "plasmabolt.dts";
};

GrenadeData ShieldDispThree
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 1.0;
   smokeName              = "plasmabolt.dts";
};



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//+=+=+=+=+=+=+=+=+=LASGUNPROJECTILESECTION+=+=+=+=+=+=+=+=+=
//___________________________________________________________
//   laserBitmapName   = "repairadd.bmp"; //- Red
//   laserBitmapName   = "Laserpulse.bmp"; //- Red (default)
//   laserBitmapName   = "rpulse04.bmp"; //- Red Spotted
//   laserBitmapName   = "Lightningtemp.bmp"; //- ?Blue ?
//   laserBitmapName   = "Lightningnewsub.bmp"; //- ?Blue ?
//   laserBitmapName   = "TrailAdd.bmp"; //- ?Green?
//   laserBitmapName   = "TrailAdd2.bmp"; //- ?Green?
//   laserBitmapName   = "TrailTest.bmp"; //- ?Green?
//   laserBitmapName   = "PaintPulse.bmp"; //- Green
//   laserBitmapName   = "Solar.bmp"; //- SolarPanel Blue


//=============CUTTERAY================
LaserData CutterayLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $CutterayDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

//=============SMALLLASGUN================
LaserData SLasgunLaser
{
   laserBitmapName   = "Laserpulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.01;
   baseDamageType    = $SmallLasDamageType;

   beamTime          = 0.5;
   //beamWidth         =  1; // see if we cant add this in to make em different.

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

//=============RIFLELASGUN================
LaserData RLasgunLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.02;
   baseDamageType    = $RifleLasDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//--------------------------------------

//=============HEAVYLASGUN================
LaserData HLasgunLaser
{
//   laserBitmapName   = "repairadd.bmp"; //- Red

   hitName           = "laserhit.dts";

   damageConversion  = 0.05;
   baseDamageType    = $HeavyLasGunDamageType;

//   beamTime          = 0.5;
   beamTime          = 0.7; //- Extended Time for nicer effect

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


GrenadeData SuicideShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.7;
   damageType         = $MortarDamageType;

   explosionRadius    = 25.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};


GrenadeData ExpPackPop
{
   bulletShapeName    = "breath.dts";
   explosionTag       = debrisExpMedium;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 6.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
};


LaserData Grapple
{
	laserBitmapName = "paintPulse.bmp";

	damageConversion = 0.0;
	baseDamageType = 0;

	beamTime          = 0.2;

	lightRange = 0.0;
	lightColor = { 0, 0, 0 };

	detachFromShooter = false;
};

//-----------------------------------------------
//-------------------Old stuff-------------------
//-----------------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = false;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "plasma.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 500;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 700;
   totalTime          = 1000.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
};

function MortarTurretShell::onAdd(%this)
{
	MortarTurretShell::Track(%this);
}

function MortarTurretShell::Track(%this)
{

	$ProjPosition[%this] = gamebase::getposition(%this);
	schedule("MortarTurretShell::Track(" @ %this @ ");", 0.01, %this);
}


function MortarTurretShell::onRemove(%this)
{
	playSound(ShellExplosion,$ProjPosition[%this]);

}

GrenadeData Bomb
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 0;
   totalTime          = 1000.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 1.0;
   smokeName              = "breath.dts";
};

function Bomb::onAdd(%this)
{
	Bomb::Track(%this);
}

function Bomb::Track(%this)
{

	$ProjPosition[%this] = gamebase::getposition(%this);
	schedule("Bomb::Track(" @ %this @ ");", 0.01, %this);
}


function Bomb::onRemove(%this)
{
	playSound(ShellExplosion,$ProjPosition[%this]);

}
//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData TurretRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 175.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 200.0;
   totalTime         = 5;
   liveTime          = 5;
   seekingTurningRadius    = 5;
   nonSeekingTurningRadius = 60.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

//function SeekingMissile::updateTargetPercentage(%target)
//{
//   return GameBase::virtual(%target, "getHeatFactor");
//}



function TurretRocket::onAdd(%this)
{
	schedule("TurretBoxCheck(" @ %this @ ");",0.05,%this);
}

function TurretBoxCheck(%this)
{

	if(%this && %this != -1 && %this != "")
	{
		%position = GameBase::getPosition(%this);  //GameBase::getLOSInfo(%player,3); dont test where the shot is aimed, test from the position of the bullet
		%set = newObject("set",SimSet); // make new box for testing.
		if(containerBoxFillSet(%set,$VehicleObjectType,%position,80,80,80,0)){ // if we find a player or vehicle in the box,				

			%num = containerBoxFillSet(%set,$VehicleObjectType,%position,80,80,80,0);
			%num = CheckForAircraft(%set, %position, %num);
			if(%num != -1){ // as long as we found a flying vehicle
				%player = 2048; // have to make the attacker flag on the projectile a null or else things will crash.
				%target = Group::getObject(%set,%num); // get the objNum of the found object.
				// GameBase::getDataName(
				%rotation = GameBase::getRotation(%this); // get rotation of object...
				%velocity = Item::getVelocity(%this); // get velocity of object...
				%transform = "0 0 0 0 0 0 "@ %rotation @" "@ %position; // make the transform for the new object...
		
				Projectile::spawnProjectile(TurretMissile, %transform, %player, %velocity, %target); // spawn new seeking projectile
				//warningMessage(%target); // send warning to target
				deleteObject(%this); // and delete original projectile
			} else { // if we didnt find a flying vehicle,
				schedule("TurretBoxCheck(" @ %this @ ");",0.05,%this); // then run this bad boy again.
			}
		} else { // else if nothing significant is inside the box
			schedule("TurretBoxCheck(" @ %this @ ");",0.05,%this); // then run this bad boy again.
		}
		deleteObject(%set); // then delete current box no matter what.
	}				
	
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData WormLightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 10000.0;
   coneAngle        = 5.0;
   damagePerSec      = 10.06;
   energyDrainPerSec = 160.0;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 3.125;

   updateTime   = 300;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = ShellExplosion;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
// 		//No more autorepair
//		if (GameBase::getDamageLevel(%player) != 0) {
//			%player.repairRate = 0.05;
//			%player.repairTarget = %player;
//			Client::sendMessage(%client, 0, "AutoRepair On");
//		}
//		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
//		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
			$PlayerPoisoned[%rclient] = 0;
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

function CheckForAircraft(%set,%position, %num)
{
	for(%i=0;%num>%i;%i++){ // a loop to make sure our target is a flying vehicle, not a ground based.
		if(GameBase::getDataName(Group::getObject(%set,%i)) == BasicThopter || GameBase::getDataName(Group::getObject(%set,%i)) == VulcanThopter || GameBase::getDataName(Group::getObject(%set,%i)) == LasgunThopter || GameBase::getDataName(Group::getObject(%set,%i)) == ArtillaryThopter || GameBase::getDataName(Group::getObject(%set,%i)) == Carryall){ // if our object is an aircraft,
			%num = %i; // then do everything
			return %num;
		} // do nothing if it isnt, and check loop again.
	}
	return -1; // when loop comes back empty, return a -1 
		
}

function CheckForVehicle(%set,%position, %num)
{
	for(%i=0;%num>%i;%i++){ // a loop to make sure our target is a flying vehicle, not a ground based.
		if(GameBase::getDataName(Group::getObject(%set,%i)) == BasicThopter || GameBase::getDataName(Group::getObject(%set,%i)) == VulcanThopter || GameBase::getDataName(Group::getObject(%set,%i)) == LasgunThopter || GameBase::getDataName(Group::getObject(%set,%i)) == ArtillaryThopter || GameBase::getDataName(Group::getObject(%set,%i)) == Carryall
			|| GameBase::getDataName(Group::getObject(%set,%i)) == Tracker || GameBase::getDataName(Group::getObject(%set,%i)) == Roller || GameBase::getDataName(Group::getObject(%set,%i)) == Crawler){ // if our object is an aircraft,
			%num = %i; // then do everything
			return %num;
		} // do nothing if it isnt, and check loop again.
	}
	return -1; // when loop comes back empty, return a -1 
		
}

function alldie()
{
	%home = "0 0 1000";
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%pos = gamebase::getposition(%cl);
		%trans = "0 0 0 0 0 0 0 0 0 0 0 0";
		%vel = vector::Add(vector::getFromRot(vector::getrotaim(%home,%pos),1000),%home);
		%proj = projectile::spawnProjectile(MortarTurretShell,%trans,2048,%vel);
		echo(%proj);
	}
}


LightningData stingerlock
{
   //bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 2000.0;
   coneAngle        = 8.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.000000000000000000000000125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.5;

   lightRange = 0;
   lightColor = { 0.25, 0.25, 0.85 };

  // soundId = SoundELFFire;
};

function stingerlock::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	dolock(%target, %shooterId);
}	
//--------------------------------------
GrenadeData FlakShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function startFlak()
{
	$flakrunning = 1;	
	continueFlak();
}

function continueFlak()
{
	%home = "0 0 50";
	if($flakrunning)
	{
		for(%x=0;%x < 1;%x++)
		{
			%home = vector::add(%home,floor(getrandom()*200)-floor(getrandom()*-200)@" "@floor(getrandom()*200)-floor(getrandom()*-200)@" "@floor(getrandom()*200));
			projectile::spawnProjectile(mortarturretShell,"0 0 0 0 0 0 0 0 0 "@%home,2048,"0 0 0");
	
		}
		schedule("continueFlak();",0.05);
	}
}

function endFlak()
{
	$flakrunning = 0;

}