
$InvList[MolotovGrenade] = 1;
$RemoteInvList[MolotovGrenade] = 1;
$HelpMessage[MolotovGrenade] = "Laces an area with burning alcohol.";

$ItemMax[hlarmor, MolotovGrenade] = 2;
$ItemMax[hlfemale, MolotovGrenade] = 2;
$ItemMax[marmor, MolotovGrenade] = 0;
$ItemMax[mfemale, MolotovGrenade] = 0;
$ItemMax[larmor, MolotovGrenade] = 0;
$ItemMax[lfemale, MolotovGrenade] = 0;
$ItemMax[earmor, MolotovGrenade] = 0;
$ItemMax[efemale, MolotovGrenade] = 0;
$ItemMax[harmor, MolotovGrenade] = 0;
$ItemMax[uharmor, MolotovGrenade] = 0;

MineData Molotov
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "Molotov Cocktail";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LavaExp;
	explosionRadius = 8.0;
	damageValue = 0.2;
	damageType = $ScramblerDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 500.01; //If Molotov can be destroyed, then the game will crash!
};

BulletData MolotovSpew
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = MolotovExp;


   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ScramblerDamageType;
   explosionRadius    = 7.0;


   aimDeflection      = 1.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

BulletData MolotovHeat
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = LavaExp;


   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $ScramblerDamageType;
   explosionRadius    = 6.0;


   aimDeflection      = 3.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 1.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

function Molotov::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",16.0,%this);
	schedule("BurnLikeHell(" @ %this @ ", 120);",1.0,%this); 

	
}

function BurnLikeHell(%this, %steps) //Deadtaco's Molotov spew code
{
	if(%steps)
	{
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("MolotovSpew",%trans,%this,"0 0 -2");
		// Projectile::spawnProjectile("MolotovSpew",%trans,%this,"0 0 -2");
		Projectile::spawnProjectile("MolotovHeat",%trans,%this,%vel);
		schedule("BurnLikeHell(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function Molotov::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}
	if(Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
}

function Molotov::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function Molotov::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function Molotov::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);

}