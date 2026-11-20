// DeadTaco's orbiter grenade -  An idea created just for entertainment purposes
// and to see how well it would work in a tribes environment.
// Update -- Turned it into a sticky bomb since that's what it ended up becoming


$InvList[BouncingBettyMine] = 0;
$RemoteInvList[BouncingBettyMine] = 0;
$HelpMessage[BouncingBettyMine] = "A mine that jumps to waist level and explodes, cutting people in half.";

$ItemMax[hlarmor, BouncingBettyMine] = 0;
$ItemMax[hlfemale, BouncingBettyMine] = 0;
$ItemMax[marmor, BouncingBettyMine] = 0;
$ItemMax[mfemale, BouncingBettyMine] = 0;
$ItemMax[larmor, BouncingBettyMine] = 0;
$ItemMax[lfemale, BouncingBettyMine] = 0;
$ItemMax[earmor, BouncingBettyMine] = 1;
$ItemMax[efemale, BouncingBettyMine] = 1;
$ItemMax[harmor, BouncingBettyMine] = 0;
$ItemMax[uharmor, BouncingBettyMine] = 0;

$SellAmmo[BouncingBettyMine] = 10;
$TeamItemMax[BouncingBettyMine] = 50;

ItemData BouncingBettyMine
{
	description = "Bouncing Betty";
	shapeFile = "discammo";
	heading = "mMines";
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};


MineData BettyMine
{
	className = "Mine";
	description = "Bouncing Betty";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = BulletShellExp;
	explosionRadius = 0.5;
	damageValue = 0.1;
	damageType = $MineDamageType;
	kickBackStrength = 750;
	triggerRadius = 5.5;
	maxDamage = 0.1;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function BettyMine::onAdd(%this)
{
	%this.damage = 0;
	BettyMine::deployCheck(%this);
}

function BettyMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ($Game::missionType != "DM")
	{
		if ((%type == "Player" || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object))
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else
	{
		if ((%type == "Player" || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
}

function BettyMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%team = GameBase::getTeam(%this);
		$TeamItemCount[%team @ "BouncingBettyMine"]++;

		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "BouncingBettyMine"] > $TeamItemMax[BouncingBettyMine])
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
			if($TeamItemCount[%team @ "BouncingBettyMine"] > $TeamItemMax[BouncingBettyMine])
				$TeamItemCount[%team @ "BouncingBettyMine"]--;
		}
		deleteObject(%set);
	}
	else 
		schedule("BettyMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function BettyMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "BouncingBettyMine"]--;
	// %trans = GameBase::getMuzzleTransform(%this);
	// %vel = Item::getVelocity(%this);
	// Projectile::spawnProjectile("BettyJumper",%trans,%this,"0 0 10");

}

function BettyMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

		GameBase::setDamageLevel(%this, %data.maxDamage);
		%this.damage += %value;
		messageall(1, %this.damage);

}


		// %loc = Gamebase::getPosition(%this);
		// %locZ = getWord(%loc,2);
		// %locx = getWord(%loc,0);
		// %locy = getWord(%loc,1);
		// GameBase::setPosition(%this, %locX @ " " @ %locY @ " " @ %locZ + 1);
// --- The bouncing betty popper grenade

RocketData BettyJumper
{
   bulletShapeName  = "discammo.dts";
   explosionTag     = grenadeExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $BulletDmgType13;

   explosionRadius  = 25.0;
   kickBackStrength = 100.0;
   muzzleVelocity   = 0.0;
   terminalVelocity = 0.0;
   acceleration     = 300.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 2.8;

   soundId = SoundJetHeavy;
};
