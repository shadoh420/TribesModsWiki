
//ClayPigeon

$InvList[ClayPigeon] = 1;
$MobileInvList[ClayPigeon] = 1;
$RemoteInvList[ClayPigeon] = 1;

$InvList[ClayPigeonShells] = 1;
$MobileInvList[ClayPigeonShells] = 1;
$RemoteInvList[ClayPigeonShells] = 1;

$AutoUse[ClayPigeon] = false;
$WeaponAmmo[ClayPigeon] = ClayPigeonShells;
$SellAmmo[ClayPigeonShells] = 15;

addWeapon(ClayPigeon);
addAmmo(ClayPigeon, ClayPigeonShells, 5);

BulletData PigeonCapsule 
{
	bulletShapeName = "rocket.dts";
	explosionTag = ShotExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.07;
	damageType = $ShotgunDamageType;
	kickBackStrength = 40.0;
	aimDeflection = 0.1;	//0.02;
	muzzleVelocity = 25.0;
	acceleration = 5.0;
	totalTime = 0.5;
	inheritedVelocityScale = 1.0;
	isVisible = true;
	tracerPercentage = 1.0;	//1.0
	tracerLength = 30;
};
RocketData oldPigeonCapsule
{	
	bulletShapeName = "Mortar.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $RocketDamageType;		//damageType = $ExplosionDamageType; -plasmatic 2.2
	explosionRadius = 20.5;
	kickBackStrength = 450.0;
	muzzleVelocity = 25.0;		//75
	terminalVelocity = 25.0;
	acceleration =0.0;
	totalTime = 2.5;
	liveTime = 3.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};
GrenadeData newPigeonCapsule
{
	bulletShapeName = "mortar.dts";
	explosionTag = mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 0.01;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $MortarDamageType;
	explosionRadius = 20.0;
	kickBackStrength = 250.0;
	maxLevelFlightDist = 275;
	totalTime = 3.0;
	liveTime = 2.0;
	projSpecialTime = 0.5;
	inheritedVelocityScale = 0.5;
	smokeName = "rsmoke.dts";
};


GrenadeData ClayPigeonSplit
{
//plasmatic
   bulletShapeName    = "shotgunbolt.dts";//grenade.dts
   explosionTag       = AgedonSplitExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.00;
   damageType         = $ShrapnelDamageType;//$PlasmaDamageType;//

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";//smoke.dts
};



ItemData ClayPigeonShells 
{
	description = "ClayPigeon Can";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};
MineData ClayPigeonShellsBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};

ItemImageData ClayPigeonImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ClayPigeonShells;
	reloadTime = 0.10;
	accuFire = false;
	fireTime = 0.75;
	sfxFire = SoundFireGrenade;	//sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ClayPigeon 
{
	description = "Clay Pigeon Launcher";
	shapeFile = "grenadeL";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ClayPigeonImage;
	showWeaponBar = true;
	price = 85;
};

function ClayPigeon::MountExtras(%player,%weapon) 
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Launches fakes for target practice.");
}

function ClayPigeonImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	Player::decItemCount(%player,$WeaponAmmo[ClayPigeon],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
//	for(%i=0; %i<3; %i++)
//	{
		%newObj = Projectile::spawnProjectile("newPigeonCapsule",%trans,%player,%vel);
		schedule("SplitClay(" @ %newObj @ ", " @ %player @ ");", 0.4+ %i/10);
		//schedule("TossMines(" @ %newObj @ ", " @ %player @ ", 10,true);", 3.0);
		schedule("RepaceClayPigeon(" @ %NewObj @ ", " @ %player @ ");", 0.5+ %i/10);
//	}

}

function SplitClay(%newobj,%this)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
// Pretty shell split
	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("ClayPigeonSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function RepaceClayPigeon(%newobj,%this){

	if (GameBase::getPosition(%newObj)){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
   		%Mine = newObject("","Mine","FakeMine");
 		addToSet("MissionCleanup", %Mine);
      		GameBase::throw(%Mine,%this,-1,true);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);

	deleteobject(%newObj);
	}
}

//=====================================================================
// Clay Pigeon Fakes
//=====================================================================
MineData FakeMine
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Mini Mine";
	shapeFile = "Larmor";	//mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 0.025;
};

function FakeMine::onAdd(%this)
{
	%this.damage = 0;
	FakeMine::deployCheck(%this);
	$mine::count++;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function FakeMine::onRemove(%this)
{
	$mine::count -= 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}


function FakeMine::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second -plasmatic
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //no teamdmg
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		$mine::count--;
	}
}

// modified so cannot tk, even if player is dead -plasmatic
function FakeMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) 
	{
		//Player::blowUp(%this);
		schedule("GameBase::setDamageLevel("@%this@", 2);",1);
		$mine::count--;
	}
	else 
		schedule("FakeMine::deployCheck(" @ %this @ ");", 1, %this);
}
