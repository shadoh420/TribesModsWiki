//==================================================================================================== Nuclear Explosion

RocketData NukeShell2
{
   bulletShapeName  = "cactus1.dts";
   explosionTag     = NukeExp;
   collisionRadius  = 0.0;
   mass             = 9.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1000.0;
   damageType       = $NukeDamageType;

   explosionRadius  = 100.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 5.0;
   terminalVelocity = 25.0;
   acceleration     = 10.0;
   totalTime        = 1000.0;
   liveTime         = 0.5;
   lightRange       = 0.01;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 0.5;

   soundId = SoundJetHeavy;
};

GrenadeData NukeShell
{
   bulletShapeName    = "cactus1.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 9.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 100.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 100.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 1000.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.0;
   smokeName = "breath.dts";
};

function NukeShell::onAdd(%this)
{
	//Player::applyImpulse(%this, "0 0 75");
	//schedule("NukeCheckGround(" @ %this @ ");",0.5,%this);
	//NuclearExplosion(%this, 1);
}

GrenadeData NukeSmallBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 150.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeSubBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 150.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeMediumBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 500.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 400.0;
   kickBackStrength   = 700.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeLargeBlast
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1000.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 1000.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeBlast0
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 3.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeBlast10
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 10.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast20
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 20.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};

GrenadeData NukeBlast30
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 30.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast40
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 40.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 40.0;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast50
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 400.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast60
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = NukeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 60.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 60.0;
   kickBackStrength   = 400.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast70
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 70.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 70.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast80
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 80.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 80.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};



GrenadeData NukeBlast90
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 90.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 90.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NukeBlast100
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = FlashExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 2.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 100.0;
   damageType         = $NukeDamageType;

   explosionRadius    = 100.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.02;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName = "breath.dts";
};


GrenadeData NBase
{
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 3.5;
	damageType         = $PlasmaDamageType;

	explosionRadius    = 35;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.0;
};

GrenadeData NRing
{
	explosionTag       = LargeShockwave;
    	explosionId        = LargeShockwave;
	
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 2.5;
	damageType         = $PlasmaDamageType;

	explosionRadius    = 35;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 1.1;
	liveTime           = 0.1;
	projSpecialTime    = 1.9;

	inheritedVelocityScale = 0.0;
};

MineData NRing1
{
	mass = 1.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0;
	friction = 10.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 10000.0;
};

function NRing1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}


GrenadeData NBlast
{
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;
	
	damageClass        = 1;
	damageValue        = 1.0;
	damageType         = $PlasmaDamageType;

	explosionRadius    = 25;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.0;
};

GrenadeData NCloud
{
	explosionTag       = mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 5.0;
	elasticity         = 0.0;

	damageClass        = 1;
	damageValue        = 1.0;
	damageType         = $PlasmaDamageType;

	explosionRadius    = 25;
	kickBackStrength   = 1.0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.0;
};

function NukeBoxKill(%this, %position)
{
	%set = newObject("set",SimSet); // make new box for killing.
	if(containerBoxFillSet(%set,$StaticObjectType | $VehicleObjectType | $SimPlayerObjectType,%position,700,700,700,0)){ // if we find a player or staticshape in the box,
		%num = containerBoxFillSet(%set,$StaticObjectType | $VehicleObjectType | $SimPlayerObjectType,%position,700,700,700,0);
		for(%i=0;%num>%i;%i++){ // To walk through the objects in the box.
			%pos = gamebase::getposition(Group::getObject(%set,%i));
			Staticshape::ondamage(Group::getobject(%set,%i), $plasmadamagetype, 1000, %pos);
			GameBase::applyRadiusDamage($PlasmaDamageType, %pos, 30, 1000, 30, -1);
		}
	}	
	deleteObject(%set);	
}

//============================================================================================OBTAINED FROM SHIFTER'S "Tatical Nuke" along with the individal 
//============================================================================================blasts used for it

function NuclearExplosionOld(%this, %size)
{
echo(%this @ " " @ client::Getname(%this) @ " is nuking");
	//%cl = $ProjectileOwner[%this];
	//%player = client::getownedobject(%cl);

	if( %this != -1 && getobjectType(%this) == "Player" ) {
		%player = %this;
	}
	else if(%this)
		%player = %this.shooter;

	if(!%player || %player == -1)
		%player = 2048;

	%vel = "0 0 0";
	%vel1 = "0 0 200";
	
	//if (!%player)
	//	return;
	
	%pos1 = vector::add(gamebase::getposition(%this), "0 0 10");
	//%pos1 = vector::add(gamebase::getposition(%this), "0 0 0");

//	%rot = (gamebase::getrotation(%this)); //Causes bugs and is not needed! probably was supposed to work with a mine projectile, not a bullet proj.
//	%dir = (Vector::getfromrot(%rot));	
//	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	
	//We wanna use this at all..? Should default to false anyway
	if($NukeThroughPrefabs && 0){
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("NukeBoxKill(\"" @ %this @ "\", \"" @ %pos1 @ "\");",0.5);
	}



	%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
	if ( %size == 1 )
		schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);
	else if ( %size == 2 )
		schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);
	else if ( %size == 3 )
		schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);

	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
	if ( %size == 1 )
		schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);
	else if ( %size == 2 )
		schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);
	else if ( %size == 3 )
		schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",1.0);

	%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
	schedule ("Projectile::spawnProjectile(NukeSubBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
	schedule ("Projectile::spawnProjectile(NukeSubBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
	%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
	schedule ("Projectile::spawnProjectile(NukeSubBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
	%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
	schedule ("Projectile::spawnProjectile(NukeSubBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);



	%padd = "0 0 2.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBase, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 3.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",1.1);

	%padd = "0 0 4.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

	%padd = "0 0 8.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);
	
	//schedule ("Projectile::spawnProjectile(NRing1, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 0\");",0.2);
	%obj = newObject("","Mine","NRing1"); 
	addToSet("MissionCleanup", %obj);
	gamebase::setposition(%obj, %pos);
	schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);
	
	%padd = "0 0 10.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
	
	//schedule ("Projectile::spawnProjectile(NRing1, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 0\");",0.2);
	%obj = newObject("","Mine","NRing1"); 
	addToSet("MissionCleanup", %obj);
	gamebase::setposition(%obj, %pos);
	schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);
	
	%padd = "0 0 25.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 35.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 45.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "15.0 0 60.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "-15.0 0 60.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 15.0 60.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 -15.0 60.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 75.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

	%padd = "0 0 65";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
	schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);
	
	//schedule ("Projectile::spawnProjectile(NRing1, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 0\");",0.2);
	%obj = newObject("","Mine","NRing1"); 
	addToSet("MissionCleanup", %obj);
	gamebase::setposition(%obj, %pos);
	schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);
	remoteKill(%this);
}


// Nice and dynamic, and uses new forms for the explosions, instead of the shfiter nuke... but isn't much different from shifters really.
function NuclearExplosion(%this, %size)
{
echo(%this @ " " @ client::Getname(%this) @ " is nuking");
	
	%random = (floor(getRandom()*10) + floor(getRandom()*5))*10;


	if( %this != -1 && getobjectType(%this) == "Player" ) {
		%player = %this;
	} else if(%this)
		%player = %this.shooter;

	if(!%player || %player == -1)
		%player = 2048;

	%vel = "0 0 0";
	%vel1 = "0 0 "@%random + 10;
	
	%pos1 = vector::add(gamebase::getposition(%this), "0 0 10");
echo("Size: " @%random);
	if(%random == 0)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 5 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
	}
	else if(%random == 10)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 5 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -5 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-5 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "5 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

	}else if(%random == 20)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 10 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -10 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-10 0 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "10 0 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "0 0 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.18);

		%padd = "0 0 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
//		schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);

	} else if(%random == 30)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 15 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -15 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-15 0 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "15 0 -3";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "15 15 -4";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.18);

		%padd = "15 -15 -4";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

		%padd = "-15 15 -4";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.22);

		%padd = "15 15 -4";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.24);

		%padd = "-15 15 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.26);

		%padd = "-15 -15 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.28);

		%padd = "-15 -15 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

		%padd = "15 -15 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.32);

		%padd = "0 0 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.34);

		%padd = "0 0 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
//		schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.25);

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);
	} else if(%random == 40)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.11);

		%padd = "-20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.13);

		%padd = "20 20 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "20 -20 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.15);

		%padd = "-20 20 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "20 20 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.17);

		%padd = "-20 20 2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.18);

		%padd = "-20 -20 2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.19);

		%padd = "-20 -20 2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

		%padd = "20 -20 2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.21);

		%padd = "0 0 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.22);

		%padd = "0 0 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
 		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);
	} else if(%random == 50)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "15 15 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

		%padd = "15 -15 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.22);

		%padd = "-15 15 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.24);

		%padd = "15 15 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.26);

		%padd = "-10 10 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

		%padd = "-10 -10 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.32);

		%padd = "-10 -10 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.34);

		%padd = "10 -10 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.36);

		%padd = "0 0 17";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.33);

		%padd = "0 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);

		%padd = "0 0 10";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.3,%this);

	} else if(%random == 60)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -20 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "20 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "12 12 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.24);

		%padd = "12 -12 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.26);

		%padd = "-12 12 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.28);

		%padd = "12 12 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

		%padd = "-8 8 20";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.38);

		%padd = "-8 -8 20";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.4);

		%padd = "-8 -8 20";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.42);

		%padd = "8 -8 20";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.44);

		%padd = "0 0 23";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.46);

		%padd = "0 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);

		%padd = "0 0 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.4,%this);

	} else if(%random == 70)
	{
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
		schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		%padd = "0 20 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -20 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.12);

		%padd = "-20 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.14);

		%padd = "20 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "8 8 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.24);

		%padd = "8 -8 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.26);

		%padd = "-8 8 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.28);

		%padd = "8 8 8";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

		%padd = "-3 3 15";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.38);

		%padd = "-3 -3 20";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.4);

		%padd = "-3 -3 25";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.42);

		%padd = "3 -3 30";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.44);

		%padd = "0 10 33";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.46);

		%padd = "10 0 33";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.48);

		%padd = "0 -10 33";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);

		%padd = "-10 0 33";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.52);

		%padd = "0 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.2,%this);

		%padd = "0 0 25";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.4,%this);

		%padd = "0 0 28";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.5,%this);

	} else
	{
		if(%random >= 140)
		{
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
	
			%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
			schedule ("Projectile::spawnProjectile(NukeLargeBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

		} else if(%random == 130)
		{
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
	
			%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
			schedule ("Projectile::spawnProjectile(NukeMediumBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
		} else if(%random == 120)
		{
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
	
			%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
			schedule ("Projectile::spawnProjectile(NukeSmallBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
		} else
		{
			%random = 100;
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -11");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -9");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -7");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -5");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.7);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 -10");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
	
			%trans = "0 0 0 0 0 0 0 0 0 " @ %pos1;
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);

			%trans = "0 0 0 0 0 0 0 0 0 " @ vector::add(%pos1, "0 0 2");
			schedule ("Projectile::spawnProjectile(NukeBlast"@%random@", \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel1 @ "\");",0.3);
		}

		%padd = "0 20 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

		%padd = "0 -20 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.13);

		%padd = "-20 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.16);

		%padd = "20 0 -5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.19);

		%padd = "-5 0 0";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.22);

		%padd = "5 0 5";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.25);

		%padd = "0 5 12";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.28);

		%padd = "0 -5 19";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.31);

		%padd = "-3 3 26";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.34);

		%padd = "-3 -3 33";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.37);

		%padd = "-3 -3 40";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.40);

		%padd = "3 -3 47";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.43);

		%padd = "0 20 50";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.46);

		%padd = "20 0 50";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.49);

		%padd = "0 -20 50";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.52);

		%padd = "-20 0 50";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
		schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.55);

		%padd = "0 0 -2";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.25,%this);

		%padd = "0 0 25";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.45,%this);

		%padd = "0 0 35";
		%pos = Vector::add(%pos1, %padd);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

		%obj = newObject("","Mine","NRing1"); 
		addToSet("MissionCleanup", %obj);
		gamebase::setposition(%obj, %pos);
		schedule("Mine::Detonate(" @ %obj @ ");",0.55,%this);

	}
	
	schedule("Atomic::killIfNotDead("@%player@");",0.5);
}

function Atomic::killIfNotDead(%player)
{
	if(%player && %player != 0 && %player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
	{
echo("Nuker Not dead--Killing");
		GameBase::applyDamage(%player, $NukeDamageType, 10, gamebase::Getposition(%player), "0 0 0", "0 0 0", player::getclient(%player));
		//GameBase::setDamageLevel(%player,100);
		//Player::kill(player::getClient(%player));
	   	//Client::onKilled(player::getClient(%player),player::getClient(%player));
	}
}

function  dne(%this,%time)
{
	Schedule("NuclearExplosion("@%this@", 1);",%time);
}