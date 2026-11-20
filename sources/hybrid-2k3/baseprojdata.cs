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

$FusionDamageType      = 14; //for fusion cannon
$QuantumDamageType     = 15; //for the Enterprise E
$EnergyDamageType2     = 16; //for things that damage with energy but need a different death message
$SniperDamageType      = 17; //for the sniper rifle
$BlueDamageType        = 18; //for the minigun
$AvengerDamageType     = 19; //for the A-10
$MagnumDamageType      = 20; //for the .357 Magnum
$GluonDamageType       = 21; //for the gluon gun
$ArwingDamageType      = 22; //for the Arwing
$ColossusDamageType    = 23; //for the GTVA Colossus
$ThermonuclearDamageType = 24; //for the thermonuclear bomb
$RockeyeDamageType     = 25; //for the rockeye
$AssaultChaingunDamageType = 26; //for the Eradicator
$PhaserRifleDamageType = 27; //for the phaser rifle
$PhaserDamageType      = 28; //for the phaser type 10
$ShotgunDamageType     = 29; //for the automatic shotgun
$PulsePhaserDamageType = 30; //for the pulse phaser
$CannonDamageType      = 31; //for the 120mm Cannon
$FirestormDamageType   = 32; //for the firestorm cannon
$FlakDamageType        = 33; //for the flak gun
$UFCDamageType         = 34; //for the UFC
$EMPDamageType         = 35; //for the EMP
///+++++++++++++++Nuker
GrenadeData ClusterBomb
{
   bulletShapeName    = "discb.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 500;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.4;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5;
   damageType         = $FlierBombDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 350;
   totalTime          = 50.0;
   liveTime           = 6.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
   };

function ClusterBomb::onAdd(%this, %player)
{
	schedule("bombspread(" @ %this @ ");",5.0);
}

function bombspread(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


}

//______________________________________________________________________________________



RocketData swordhit 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = WebExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $FlashDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//--------------------------------------
// GripBolt By: *SlipKnot*
//--------------------------------------
RocketData IonEEBolt 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = WebExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $FlashDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//=======================
SeekingMissileData MiniFlakproj
{
   bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpLarge;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ShrapnelDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 100.0;
   totalTime         = 3;
   liveTime          = 3;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   //smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Rocketexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 30.0;
   terminalvelocity  = 100;
   acceleration      = 2;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.76;

   //soundId = SoundJetHeavy;
};
//---------
BulletData PlasmaBoltTurrt
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};



//- ------------ Charge bolts
BulletData MC00
{
   bulletShapeName    = "enbolt.dts";
   validateShape      = true;
   explosionTag       = energyExp;
   mass               = 0.05;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.01;
   muzzleVelocity     = 200.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC01
{
   bulletShapeName    = "shotgunbolt.dts";
   validateShape      = true;
   explosionTag       = BlasterXExp;
   mass               = 0.05;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.01;
   muzzleVelocity     = 200.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC02
{
   bulletShapeName    = "fusionbolt.dts";
   validateShape      = true;
   explosionTag       = turretExp;
   mass               = 0.05;
   explosionRadius = 3.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.009;
   muzzleVelocity     = 210.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC03
{
   bulletShapeName    = "plasmabolt.dts";
   validateShape      = true;
   explosionTag       = plasmaExp;
   mass               = 0.05;
   explosionRadius = 5.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 240.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC04
{
   bulletShapeName    = "shield.dts";
   validateShape      = true;
   explosionTag       = ShockwaveFour;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 0.6;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.02;
   muzzleVelocity     = 270.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC05
{
   bulletShapeName    = "fusionex.dts";
   validateShape      = true;
   explosionTag       = grenadeExp;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 0.95;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.002;
   muzzleVelocity     = 280.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC06
{
   bulletShapeName    = "mortar.dts";
   validateShape      = true;
   explosionTag       = nappyExp;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 1.3;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 310.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData MCMega
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $PhaserDamageType;

   explosionRadius  = 25.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 265.0;
   terminalVelocity = 380.0;
   acceleration     = 2.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "Plasmaex.dts";
   smokeDist   = 1.0;
   soundId = SoundJetHeavy;
};
//--------------------------------------
GrenadeData NapSplit
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;     
   damageValue        = 0.1;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

GrenadeData NapShell
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;      
   damageValue        = 0.2;
   damageType         = $PlasmaDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; 
   projSpecialTime    = 0.01; 

   inheritedVelocityScale = 0.5;
   smokeName     = "plasmatrail.dts";
};

GrenadeData NapFire
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	
   elasticity         = 0.45;	

   damageClass        = 1;       
   damageValue        = 0.22;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 45.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; 
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//--------------------------------------
LightningData TractorBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 3;
   beamWidth        = 1.0;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};

$TractorPower = 50;

function TractorBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %obj1 = %target;
  %obj2 = %shooterId;

   // Get object's mass  
  if (getObjectType(%obj1) == "Player") 
    %obj1mass = Player::getArmor(%obj1).mass;
  else
    %obj1mass = 10000;

  %obj2mass = Player::getArmor(%obj2).mass;

   // 
  %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));

  if (getObjectType(%obj1) == "Player")
  {
    %mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
    %nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
    //Player::applyImpulse(%obj1, %nvec);
    Item::setVelocity(%obj1, %nvec);
  }

   // obj2 is always a player
  %mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
  %nvec = (getWord(%vec, 0) * %mul) @ " " @
          (getWord(%vec, 1) * %mul) @ " " @
          (getWord(%vec, 2) * %mul);
  //Player::applyImpulse(%obj2, %nvec);
  Item::setVelocity(%obj2, %nvec);
}
//======================================
//======================================
BulletData swordBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = armExp;
   damageClass        = 0;
   damageValue        = 0.075;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 90.0;
   totalTime          = 0.03;
   liveTime           = 0.031;
   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = false;
};
//--------------------------------------
RocketData StingerRocket
{	bulletShapeName = "discb.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "snowplume.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//--------------------------------------
SeekingMissileData StingerMissile
{	bulletShapeName = "fusionbolt.dts";
	explosionTag = MortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
      // rocket specific
	trailType = 2;
	trailString = "enex";
	smokeDist = 1;
};
//--------------------------------------
SeekingMissileData TankMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $MissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "plasmabolt";
	smokeDist = 1;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
}
//--------------------------------------
GrenadeData BigBoom
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = False;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $BoomDamageType;

   explosionRadius    = 50;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";
};
//---------------------------------------- 
GrenadeData HybridShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};

GrenadeData HybridShell2
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};
//---------------------------------------
RocketData NRocket
{	bulletShapeName = "Mortar.dts";
	explosionTag = DebrisExpLarge;
	collisionRadius = 0.0;
	mass = 1.5;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $FlakDamageType;
	explosionRadius = 5;
	kickBackStrength = 35;
	muzzleVelocity = 120.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 3.0, 0.7, 5.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plastrail.dts";
	smokeDist = 5;
	soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = HybridExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.13;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData chainRockets
{	bulletShapeName = "discb.dts";
	explosionTag = TurretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $ExplosionDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "snowplume.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

BulletData ShredderBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = HybridCExp;
	expRandCycle = 0;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

BulletData ALCbullet
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.35;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData MinigunBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $BulletDamageType;
      aimDeflection      = 0.001;
	muzzleVelocity = 900.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

GrenadeData ScatterBomb
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = PopcornExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 20.0;
   maxLevelFlightDist = 445;
   totalTime          = 3.6;
   liveTime           = 3.5;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0.5;
   smokeName              = "flash_small.dts";
};

BulletData BlastCannonShot
{	bulletShapeName = "shotgunbolt.dts";
	explosionTag = flashExpSmall;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.255;
	damageType = $MissileDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.025;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

RocketData TankRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};

RocketData RPG
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.4;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

RocketData HMS
{	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "shield.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

GrenadeData HMSL
{
   bulletShapeName    = "shield.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $PlasmaDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "shield.dts";
   smokeDist          = 0.01;
};

RocketData ScoutRocket1
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 3;
	soundId = SoundJetHeavy;
};

RocketData ScoutRocket2
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "smoke.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};

BulletData BlueRageBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = ShardExp;
   expRandCycle       = 0;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.16;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 0.7;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData AmbushBullet
{
   bulletShapeName    = "rsmoke.dts";
   explosionTag       = smokerExp;
   expRandCycle       = 0;
   mass               = 0.01;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

BulletData VulcanBullet
{	bulletShapeName = "rocket.dts";
	explosionTag = RocketExp;
	mass = 0.10;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $BulletDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0;
	muzzleVelocity = 355.0;
	totalTime = 10;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

RocketData VulcanRocket
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = vulcanrocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $BulletDamageType;

   explosionRadius  = 10;
   kickBackStrength = 5;

   muzzleVelocity   = 355;
   terminalVelocity = 355;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.8;

   soundId = SoundDiscSpin;
};


BulletData FlierBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 3;
   mass               = 5.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $AvengerDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData HybridRailBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BulletExp0;  
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 8.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.5; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};


BulletData ShotgunPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = ShotExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $ShotgunDamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 300.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData MP5Bullet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = shotexp;  
   collisionRadius  = 0.0;
   mass             = 0.8;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   //trailType   = 1;         
   //trailLength = 3000; 
   //trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};


//--------------------------------------
RocketData M10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = M102Exp;  
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 2.0; 
   kickBackStrength = 6.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 1000.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 5.0;
   lightRange       = 1.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 0.5;

 soundId = SoundJetHeavy;
};

BulletData AssaultChaingunBullet
{	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.25;
	damageType = $AssaultChaingunDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.01;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

RocketData FlakBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpMedium;

   collisionRadius = 0.0;
   mass            = 1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;
   aimDeflection = 0;
   explosionRadius  = 5.0;
   kickBackStrength = 0.10;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1;

   
   soundId = SoundDiscSpin;
};


BulletData ChargedPlasmaBullet
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = plasmaExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 6;

   muzzleVelocity     = 75.0;
   totalTime          = 111.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   rotationPeriod     = 144.0;
};

RocketData MetreonBullet
{
   bulletShapeName = "fusionex.dts";
   explosionTag    = mortarExp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 100;
   terminalVelocity = 120;
   acceleration     = 1;

   totalTime        = 20.0;
   liveTime         = 21.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 20;

   soundId = SoundDiscSpin;
};


RocketData SniperBullet
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = ionExp_4;  
   collisionRadius  = 0.0;
   mass             = 0.8;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $SniperDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   mass               = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 150.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

BulletData QuantumTorpedo
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = mortarExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $QuantumDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enbolt.dts";
   smokeDist   = 1.8;

   rotationPeriod = 1.5;
};

BulletData SR71Bolt
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   damageClass        = 0;
   damageValue        = 0.075;
   damageType         = $EnergyDamageType2;

   muzzleVelocity     = 100.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

RocketData FusionRifleBullet
{
   bulletShapeName = "Shotgunex.dts";
   explosionTag    = FusionRifleExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.60;
   damageType       = $EnergyDamageType2;

   explosionRadius  = 0;
   kickBackStrength = 0;

   muzzleVelocity   = 500.0;
   terminalVelocity = 500.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 5.0, 0, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};
//---------------------
BulletData UFCPellet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BlasterExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $UFCDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData FusionCannonBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = FusionCannonExplosion;
   mass               = 0.05;
   explosionRadius    = 50;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5.0;
   damageType         = $FusionDamageType;

   muzzleVelocity     = 30.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData SpeedBikeBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $EnergyDamageType2;
   explosionRadius    = 3.0;

   muzzleVelocity     = 175.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   rotationPeriod = 0.1;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = FusionturretXExp;

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
   explosionTag       = BlasterXExp;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 5.0, 0.2, 0.2 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData RFPlasmaBullet
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 400;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

RocketData MagnumBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = smokerExp;  
   collisionRadius  = 0.0;
   mass             = 0.4;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MagnumDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   //trailType   = 1;         
   //trailLength = 3000; 
   //trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};


RocketData MagnumBulletXXX
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = smokerExp;  
   collisionRadius  = 0.0;
   mass             = 0.4;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   //trailType   = 1;         
   //trailLength = 3000; 
   //trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};
//-----------------------------------
RocketData NewPlasmaBoltX
{
   bulletShapeName = "shield_large.dts";
   explosionTag    = TurretExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmawall.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};
//--------------------------------------
RocketData PlasmaBolt
{
   bulletShapeName = "plasmaex.dts";
   explosionTag    = debrisExpLarge;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

RocketData PlasmaBlasterBolt
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = PlasmaExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 350;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};



BulletData AfterburnerBullet
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 0.4;
   liveTime           = 0.3;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData EngineBullet
{
   bulletShapeName = "bullet.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 51.0;
   acceleration     = 1.0;

   totalTime        = 0.1;
   liveTime         = 10.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 11;
   trailLength = 11;
   trailWidth  = 11;

   soundId = SoundDiscSpin;
};

BulletData RamjetBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = fireExp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 1.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 5.0;
   lightColor         = { 0, 0, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;

   rotationPeriod = 0.1;
};

BulletData FirestormBullet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $FirestormDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 600.0;
   aimDeflection      = 0.001;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData PhasedPlasmaCannonBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = fire3Exp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 300;
   terminalVelocity = 310;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};



RocketData PhaserRifleBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = Armexp;  
   collisionRadius  = 0.0;
   mass             = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $PhaserRifleDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};





BulletData PulsePhaserBullet
{
   bulletShapeName    = "fiery.dts";
   explosionTag       = grenadeExp;

   collisionRadius    = 0.0;
   mass               = 1.0;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $PulsePhaserDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 200;

   muzzleVelocity     = 350.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

BulletData PlasmaShotgunBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = PlasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 3.5;

   muzzleVelocity     = 90.0;
   aimDeflection      = 0.01;
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
   damageValue      = 0.7;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;


   trailType = 2;
   trailString = "rsmoke.dts";
   smokeDist = 4.5;
   soundId = SoundDiscSpin;
};



RocketData AntimatterDiscLauncherBullet
{
   bulletShapeName = "Mortartrail.dts";
   explosionTag    = SludgeExp;

   collisionRadius = 0.0;
   mass            = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 10.0;

   totalTime        = 100;
   liveTime         = 100;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

GrenadeData EMPShell 
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = PulseExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 1.0; 
	elasticity = 0.20; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $EMPDamageType; 
	explosionRadius = 40; 
	kickBackStrength = 900.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 0.25; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "Shield.dts"; 
	soundId = SoundELFFire; 
};

RocketData TTGBullet
{
   bulletShapeName = "discb.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};
//--------------------------------------
RocketData KickerBullet
{
   bulletShapeName = "Shield_Large.dts";
   explosionTag    = PulseExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 900.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Shotgunex.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};

//--------------------------------------
RocketData GravShockBullet
{
   bulletShapeName    = "dirarrows.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

//this is just to make it look cooler
RocketData GravShockBullet2
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = LargeShockwave;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;       // no damage
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

RocketData RailgunBullet
{
   bulletShapeName = "paint.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.20;
   damageType       = $BulletDamageType;

   aimDeflection    = 0;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 3;
   trailLength = 3;
   trailWidth  = 3;

   soundId = SoundDiscSpin;
};

RocketData ColossusBullet
{
   bulletShapeName = "discb.dts";
   explosionTag       = rocketExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $ColossusDamageType;

   aimDeflection    = 0.025;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 15.0;
   lightColor       = { 1.0, 0.0, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 4000;
   trailWidth  = 3.0;

   soundId = SoundDiscSpin;
};

RocketData ArwingBullet
{
   bulletShapeName = "rocket.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $ArwingDamageType;

   aimDeflection    = 0.0;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.75;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = grenadeExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 5;
        elasticity = 0.02;
        damageClass = 1;
        damageValue = 0.9;
        damageType = $ShrapnelDamageType;
        explosionRadius = 12;
        kickBackStrength = 100;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 1.5;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "smoke.dts";
        soundId = SoundELFFire;
};
GrenadeData AGLBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "laserhit.dts";
};

GrenadeData Smoker
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = SmokerExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

GrenadeData PGBullet
{
   bulletShapeName    = "enbolt.dts";
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
   totalTime          = 20.0;    // special meaning for grenades...
   liveTime           = 15.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData AMMBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 24.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 525;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};

GrenadeData BazookaBullet
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "snowplume.dts";
};
   


GrenadeData ThermonuclearBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 200.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 200.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 500;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "smoke.dts";
   smokeDist          = 0.01;
};


GrenadeData BomberBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 10;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData RepairShellBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.2;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData EnergyBallBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = TimeBombExp;
   collideWithOwner   = false;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 30.0;
   damageType         = $QuantumDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData Suicidebomb2
{
   bulletShapeName    = "generator_p.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 45.0;
   damageType         = $EnergyDamageType2;

   explosionRadius    = 20.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData ClaymoreBullet1
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet3
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 150;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet4
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet5
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 250;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

GrenadeData ClaymoreBullet6
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "rsmoke.dts";
   smokeDist          = 0.01;
};

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
RocketData CannonBullet
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData BlasRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasmabolt.dts";
   smokeDist   = 1.3;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ShieldRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = -500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
//-----------------------
// minies
//-----------------------
TargetLaserData targetLaser21
{
   laserBitmapName   = "LaserPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = 0;
   lightRange        = 0;
   lightColor        = { 0, 0, 0 };
   detachFromShooter = false;
};

LaserData Laser1
{
   laserBitmapName   = "laserpulse.bmp";
   hitname           = "laserhit.dts";
   damageConversion  = 0.2;
   baseDamageType    = $ShockDamageType;
   beamTime          = 2.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = true;
   hitSoundId        = Soundlaseridle;
};

//--------------------------------------
RocketData BlasRocket2
{
   bulletShapeName  = "breath.dts";
   explosionTag     = MitziExpL;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $CannonDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   //rocket specific
  //trailType   = 2;                
  //trailString = "plasmatrail.dts";
   //smokeDist   = 1.8;

   soundId = SoundFireSeeking;
};

RocketData ShieldRocket2
{
   bulletShapeName  = "shield.dts";
   explosionTag     = MitziExpL;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $CannonDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 125.0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 100.0;
   acceleration     = 10.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 2;                
   //trailString = "shield.dts";
   //smokeDist   = 1.8;

   soundId = Sounddiscspin;
};
//------------------------
RocketData GCannonBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 8;
   kickBackStrength = 250.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 210.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 0;
//   trailString = "laserhit.dts";
//   smokeDist   = 0.01;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ScorpianBullet
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
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

RocketData HydraBullet
{
   bulletShapeName  = "shotgunbolt.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.4;
   damageType       = $MissileDamageType;

   explosionRadius  = 4.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 0.2;

   soundId = SoundJetHeavy;
};

RocketData RockeyeBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.0;
   damageType       = $RockeyeDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 50.0;
   terminalVelocity = 75.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "discb.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};


LaserData sniperLaser
{
   laserBitmapName   = "forcefield5.bmp";
   hitName           = "shield.dts";

   damageConversion  = 0.80;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.7;

   lightRange        = 2.0;
   lightColor        = { 0.0, 0.0, 25.25 };

   detachFromShooter = false;
   hitSoundId        = SoundShieldHit;
};
//--------------------------------------
LaserData BeamLaser
{
   laserBitmapName   = "warp.bmp";
   hitname           = "plasmatrail.dts";
   damageConversion  = 0.25;
   baseDamageType    = $laserDamageType;
   beamTime          = 6.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.0, 1.0 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};
//----------------------------------------------



//--------------------------------------
LaserData GatlaserBeam
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunex.dts";
   damageConversion  = 0.05;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundShieldHit;
};
//--------------------------------------
LaserData GRLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.55;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.10;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundPlasmaTurretOn;
};

LaserData PlasmaLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "Plasmabolt.dts";

   damageConversion  = 0.08;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.4;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundChainTurretOn;
};

LaserData TauLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.025;
   baseDamageType    = $LaserDamageType;

   beamTime          = 2.0;

   lightRange        = 10.0;
   lightColor        = { 0, 5.0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData PhaserBullet
{
   laserBitmapName   = "x08.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 75;
   damageValue = 50;

   baseDamageType    = $PhaserDamageType;

   beamTime          = 30.0;

   lightRange        = 10;
   lightColor        = { 40.0, 0.23, 1.0 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

LaserData GluonLaser
{
   laserBitmapName   = "blite01.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.002;
   damageValue = 0.002;

   baseDamageType    = $GluonDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 40.0, 35.0, 19.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

LaserData CutterBullet
{
   laserBitmapName   = "pulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.01;
   

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 7.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LaserData SMLaser
{
   laserBitmapName   = "LaserPulse.bmp";
   hitName           = "PlasmaEx.dts";

   damageConversion  = 0.02;
   baseDamageType    = $laserDamageType;

   beamTime          = 0.4;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData GLaserBullet
{
   laserBitmapName   = "shex03.bmp";
   hitName           = "shotgunbolt.dts"; //make it like the disk explosion

   damageConversion  = 0.060;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData GrapBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 35.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 1000.0;
   segmentDivisions = 1;
   numSegments      = 5;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };
};


LaserData AntimatterLaserBullet
{
   laserBitmapName   = "rlite00.bmp";
   hitName           = "laserhit.dts";

   damageValue = 0.30;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 0.0, 1.0 };

   detachFromShooter = false;
   hitSoundId        = 0;
};
//++++++++++++++++++++++++++++++++++++++
LightningData destructiveCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 45.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 80;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData OmegaBolt
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 10.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.155;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function OmegaBolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %dectructiveValue = %DestructiveRotation;
   %DestructiveRotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
   %velocity = -35;
   %destructiveShooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%destuctiveValue);
   Player::applyImpulse(%target, %destructiveShooterDir);
   
   %player = client::getOwnedObject(%shooterId);
   %armor = Player::getArmor(%shooterId);
   %targetDestruction = GameBase::getDamageState(%targetDestuction);

   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if(%energy < 0) %energy = 0;
   GameBase::setEnergy(%target, %energy);

   if(%targetDestruction != "Destroyed")
   {
   %destructorHealth = GameBase::getDamageLevel(%player);
   if(%destructorHealth != 0) 
   GameBase::setDamageLevel(%player,%destructorHealth - (%enVal * 0.01));
   }
}
//++++++++++++++++++++++++++++++++++++++
LaserData CannonLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "fusionex.dts";
   damageConversion  = 0.05;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.3;
   lightRange        = 4.0;
   lightColor        = { 0, 3, 0 };
   detachFromShooter = false;
   hitSoundId        = turretExplosion;
};


LightningData PlasmaBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 3;
   numSegments      = 3;
   beamWidth        = 0.30;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 8;
   numSegments      = 2;
   beamWidth        = 0.12;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData EMPBullet
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 10.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 30.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};


LightningData TerawattBullet
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 60.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 80.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

RepairEffectData RepairBullet
{
   bitmapName       = "fx_lensflare_3.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 60.0;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepairing...");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range Max Range 35.5m");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 60.0;
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
			Client::sendMessage(%client,0,%name @ " is not in need of medical attention");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being Patched by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Patching " @ %name);
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
			Client::sendMessage(%client,0,"AutoRepair Complete.");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Completed");
			}
			else {
				Client::sendMessage(%client,0,"Repair Interupted");
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

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = 0;

   damageConversion  = 0; 
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   hitSoundId        = 0;
};

LightningData turretCharge
{
   bitmapName       = "paintpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 100.0;
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
   bitmapName       = "eflsh5.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 100.0;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
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
//===================
//Field Repair
//===================
RepairEffectData ToolBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function ToolBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairTarget = %target;
	if(getObjectType(%target) == "Player")
		return false;
	if(getObjectType(%player.repairTarget) != "Player") {
		%player.repairRate = 100.0;
		%name = GameBase::getMapName(%target);
		if(%name == "")
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return false;
		}
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function ToolBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(getObjectType(%object) == "Player")
		return false;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(getObjectType(%object) != "Player") {
			if(GameBase::getDamageLevel(%object) == 0)
				Client::sendMessage(%client,0,"Fixing Done");
			else
				Client::sendMessage(%client,0,"Fixing Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function ToolBolt::checkDone(%this,%player)
{
	if(getObjectType(%player.repairTarget) == "Player")
		return false;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == TB && %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if(getObjectType(%object) != "Player" && GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
	}
}

//----------------------------------------------------------------
//Cluster Mortar - based on Tricon Mine Launcher
//----------------------------------------------------------------

function ScatterBomb::onAdd(%this)
{
	schedule("DeployBombsA(" @ %this @ " , 2);",1.5,%this);
}

function DeployBombsA(%this, %count) 
{
	if(%count && %this)
	{

		%obj = newObject("","Mine","Bomb1");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,-1.0,false);	

		%obj = newObject("","Mine","Bomb2");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,-8.0,false);

		schedule("DeployBombsB(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

function DeployBombsB(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomb3");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,1.0,false);

		%obj = newObject("","Mine","Bomb4");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,8.0,false);	

		%count --;
		schedule("DeployBombsA(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}