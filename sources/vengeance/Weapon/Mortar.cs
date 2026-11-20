
// Cooler Mortar Gun, Grenade Launcher code by Plasmatic.
// Grenade launcher and Mortar projectiles can be shot down and will detonate on contact.
// Please contact me if you would like to use this.
// www.annihilation.info

// We're firing a regular projectile (grenade type) with regular properties (damage).
// If the player is still alive 0.3 seconds later, we replace it with a mine type object, and delete the origional.
// This is done through ( function MortarShell::Arm )
// The replacement is thrown from the firing player to transfer ownership to the new Mine object.
// This replacement Mine will deal damage when it explodes.
// Speed and direction are transfered to the new Mine object.
// ( MortarShellMine::onAdd ) Sets a creation time and starts the trail animation for the mine.
// To simulate a grenade type projectiles trail while in the air, grenade projectiles are spawned,
// and given the same position and velocity as the replacement mine type object.
// These projectiles deal no damage, and have a small explosion animation.
// To fudge around screwy elasticity and other randomness these projectiles are short lived and respawned often, every 0.25 seconds.
// ( function MortarShellMine::deployCheck ) handles the trail animation and collision checks.
// If the Mine object is at rest, it is detonated 0.75 seconds later. 
// If a collision with a player, grenade or vehicle is detected, it is detonated immediatly.
// If the live time is exceeded (tracked through %this.spawntime) the Mine is exploded.
//
// -Plasmatic


$InvList[Mortar] = 1;
$MobileInvList[Mortar] = 1;
$RemoteInvList[Mortar] = 1;

$InvList[MortarAmmo] = 1;
$MobileInvList[MortarAmmo] = 1;
$RemoteInvList[MortarAmmo] = 1;

$AutoUse[Mortar] = false;
$SellAmmo[MortarAmmo] = 5;
$WeaponAmmo[Mortar] = MortarAmmo;

addWeapon(Mortar);
addAmmo(Mortar, MortarAmmo, 2);

$oundReload[MortarImage] = SoundPodReload;

//======= projectile


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
   damageValue        = 0.75;	//1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData MortarTrailGren
{
	bulletShapeName    = "breath.dts";		//mortartrail.dts";	//mortar.dts";
	explosionTag       = SmokeFade;	//mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.1;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;	//1.0
	damageType         = $ShrapnelDamageType;

	explosionRadius    = 1.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 275;
	totalTime          = 0.25;
	liveTime           = 0.25;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 0.5;
	smokeName              = "mortartrail.dts";
};

// mortar payload when player is alive
MineData MortarShellMine
{
	mass = 5.0;		//5.0;
	drag = 2.0;	//1,0
	density = 1.0;	//5.0;	//2.0;
		elasticity = 0.1;	//0.1;	//0.15;
		friction = 2.0;	//1.0;
	className = "Handgrenade";	//className = "Mine";
	description = "Mini Mine";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 0.75;	//1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 2.5;	//5.0  Any larger and may fall through floor in raindance -Plasmatic
	maxDamage = 0.005;
};

// ==== ammo
ItemData MortarAmmo 
{
	description = "Mortar Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};
MineData MortarAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};

GrenadeData MortarAmmoStray
{
	bulletShapeName = "mortar.dts";
	explosionTag = flashExpSmall;	//mortarExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.1;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $MortarDamageType;
	explosionRadius = 10.0;
	kickBackStrength = 125.0;
	maxLevelFlightDist = 10;
	totalTime = 0.5;
	liveTime = 0.5;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";
};

//===== weapon
ItemImageData MortarAImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
//	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.05;	//0.28;
	fireTime = 0.1;	//1.25;	//1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundPodReload;	//SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData MortarA 
{
	description = "Mortar";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarAImage;
	price = 375;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData MortarImage
{
	shapeFile = "Force";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;

	mountOffset = { 0.0, -0.095, 0.05};		// 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.0, 3.14, 0.0};		// ?, around gun barrel, ?
	accuFire = true;
	
	reloadTime = 0.01;	//0.1
	fireTime = 0.01;	//0.25;
	
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
function Mortar::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,MortarA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Lob this explosive canister at someone you love.");
}

function MortarImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
		Player::trigger(%player, $SpareSlot1,true);
		%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
		schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.1);
		Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),1.53);
		
		Player::decItemCount(%player,$WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)],1);
			
		%vel = Item::getVelocity(%player);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%trans = GameBase::getMuzzleTransform(%player);
			%newObj = Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
			schedule("MortarShell::Arm(" @ %NewObj @ ", " @ %player @ ");", 0.3);
		}
		else 	
			echo("!! Butterfly Error, Mortar fire. vel ="@%vel);			
	}
}


// hacky, but we can replace projectiles with a mine type object so it could be shot down, or explode other mortars. -Plasmatic
// side effect is they are 'triggered', we can use ::oncollision to set off. kekekekeke.. 
function MortarShell::Arm(%newobj,%this)
{	
	if (GameBase::getPosition(%newObj) != "0 0 0" && !player::isdead(%this))
	{
		%Pos = vector::add(GameBase::getPosition(%newobj),"0 0 0.1"); 
   		%vel = Item::getVelocity(%newobj);
   		%Mine = newObject("","Mine","MortarShellMine");
 		addToSet("MissionCleanup", %Mine);
      		GameBase::throw(%Mine,%this,1,true);	//throwing from the firing player to set ownership -plas
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);	
		%mine.owner = %this;
			
	//	schedule("Deleteobject("@%newobj@");",0.01);	
		Deleteobject(%newobj);
	}
}


function MortarShellMine::onAdd(%this)
{
	%this.damage = 0;
	%this.spawntime = getSimTime();
	MortarShellMine::deployCheck(%this);
	$mine::count++;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}




function MortarShellMine::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	%type = getObjectType(%object);
	//messageall(1,%type);
	//%data = GameBase::getDataName(%this);
	if(%type == "Player" || %type == Flier) // Blow this bitch when it hits a flyer or player. Reward for good aim.-Plasmatic
	{
		schedule("GameBase::setDamageLevel("@%this@",1);",0.15);
		//GameBase::setDamageLevel(%this, %data.maxDamage);
		$mine::count--;
		if(%type == "Player")
		{
			%owner = %this.owner;
			if(%owner != %object)
			{
			//		messageall(0,client::getname(Player::getclient(%object))@" set off "@client::getname(Player::getclient(%owner))@"'s mortar.");
			//	else
			//		messageall(0,client::getname(Player::getclient(%object))@" heroically swallowed a mortar.");
				echo("+ MA Mortar "@client::getname(Player::getclient(%object)));
				%time = getsimtime();
				%object.mortaredTime = %time;
				%object.morteredBy = Player::getclient(%owner);
			}
				
		}
	}
}

function MortarShellMine::deployCheck(%this)
{
	%spawntime = %this.spawntime;
	%livetime = getSimTime() - %spawntime;
//	bottomprintall(%this@" mortar time "@%livetime);
//	echo(%this@" mortar time "@%livetime);
	if(GameBase::isAtRest(%this) || %livetime >15) 
	{
		//echo("mine (mortar) Detonate -at rest");
		schedule("GameBase::setDamageLevel("@%this@", 2);",1.25);	//0.75
		$mine::count--;
	}
	else 
	{
		%vel = Item::getVelocity(%this);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{
			%Pos = GameBase::getPosition(%this); 
			%box = getBoxCenter(%this);
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %box;
		//	echo("Poof! pos"@%pos@" vel "@%vel);
			%obj = Projectile::spawnProjectile("MortarTrailGren", %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %vel);	
		}
		else 	
			echo("!! Butterfly Error, Mortar Trail. vel ="@%vel);	
		
		schedule("MortarShellMine::deployCheck(" @ %this @ ");", 0.25, %this);
	
	}
}


