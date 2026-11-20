

// Cooler Mortar Gun, Grenade Launcher code by Plasmatic.
// Grenade launcher and Mortar projectiles can be shot down and will detonate on contact.
// Please contact me if you would like to use this.
// www.annihilation.info

// We're firing a regular projectile (grenade type) with regular properties (damage).
// If the player is still alive 0.3 seconds later, we replace it with a mine type object, and delete the origional.
// This is done through ( function GrenadeShell::Arm )
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
// If a collision with a player or vehicle is detected, it is detonated immediatly.
// If the live time is exceeded (tracked through %this.spawntime) the Mine is exploded.
//
// -Plasmatic

$InvList[GrenadeLauncher] = 1;
$MobileInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;

$InvList[GrenadeAmmo] = 1;
$MobileInvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = false;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);
$oundReload[GrenadeLauncherImage] =  SoundDryFire;

//======= projectile


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

GrenadeData GrenadeTrailGren
{
	bulletShapeName    = "breath.dts";		//mortartrail.dts";	//mortar.dts";
	explosionTag       = SmokeFade;	//mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 1.0;
	elasticity         = 0.45;

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
	smokeName              = "smoke.dts";
};

// mortar payload when player is alive
MineData GrenadeShellMine
{
	mass = 3.0;		//0.3;
	drag = 0.01;	//1.0;
	density = 2.0;
		elasticity = 0.35;	//0.15;
		friction = 1.0;
		
	className = "Handgrenade";	//className = "Mine";
	description = "Mini Mine";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 0.40;	//0.40;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	triggerRadius = 4.25;	//5.0	 Any larger and may fall through floor in raindance -Plasmatic
	maxDamage = 0.005;
};

// ==== ammo
ItemData GrenadeAmmo 
{	
	description = "Mini ammo"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = $InvHead[ihAmm]; 
	shadowDetailMask = 4; 
	price = 2;
}; 

MineData GrenadeAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};
GrenadeData GrenadeAmmoStray
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

ItemImageData GrenadeLauncherAImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
//	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.01;	//0.5;
	fireTime = 0.1;	//0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncherA
{
	description = "Grenade Launcher";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherAImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};
//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData GrenadeLauncherImage
{
	shapeFile = "Force";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GrenadeAmmo;

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

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
function GrenadeLauncher::MountExtras(%player,%weapon)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	Player::mountItem(%player,GrenadeLauncherA,$SpareSlot1);
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>"@%weapon.description@": <f2>Exploding fun in a can!", 2);
	
}

function GrenadeLauncherImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
			Player::trigger(%player, $SpareSlot1,true);
			%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
			schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.01);
			Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),1.0);
			
		Player::decItemCount(%player,$WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)],1);
		
		%vel = Item::getVelocity(%player);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%trans = GameBase::getMuzzleTransform(%player);
			%newObj = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			schedule("GrenadeShell::Arm(" @ %NewObj @ ", " @ %player @ ");", 0.15);	//0.3
		}
		else 	
			echo("!! Butterfly Error, Grenade Launcher fire. vel ="@%vel);			
	}
}


// hacky, but we can replace projectiles with a mine type object so it could be shot down, or explode other grenades.
function GrenadeShell::Arm(%newobj,%this)
{	
	if (GameBase::getPosition(%newObj) != "0 0 0" && !player::isdead(%this))
	{
		%Pos = vector::add(GameBase::getPosition(%newobj),"0 0 0.1"); 
   		%vel = Item::getVelocity(%newobj);
   		%Mine = newObject("","Mine","GrenadeShellMine");
 		addToSet("MissionCleanup", %Mine);
      		GameBase::throw(%Mine,%this,-1,true);	//throwing from the firing player to set ownership
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);	
		%mine.owner = %this;
			
		Deleteobject(%newobj);		
	}
}


function GrenadeShellMine::onAdd(%this)
{
	%this.damage = 0;
	%this.spawntime = getSimTime();
	GrenadeShellMine::deployCheck(%this);
	$mine::count++;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}




function GrenadeShellMine::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	%type = getObjectType(%object);
	//messageall(1,%type);
	%data = GameBase::getDataName(%this);
	if(%type == "Player" || %type == Flier)// Blow this bitch when it hits a flyer or player. Reward for good aim. -Plasmatic
	{
		schedule("GameBase::setDamageLevel("@%this@",1);",0.1);
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
				echo("+ MA Grenade "@client::getname(Player::getclient(%object)));
				%time = getsimtime();
				%object.grenadedTime = %time;
				%object.grenadedBy = Player::getclient(%owner);
			}
				
		}		
		
		
		
	}
}

// modified so cannot tk, even if player is dead -plasmatic
function GrenadeShellMine::deployCheck(%this)
{
	%spawntime = %this.spawntime;
	%livetime = getSimTime() - %spawntime;
//	bottomprintall(%this@" grenade time "@%livetime);
//	echo(%this@" grenade time "@%livetime);
	if(GameBase::isAtRest(%this) || %livetime >15) 
	{
		//echo("mine (g-launch) Detonate -at rest");
		schedule("GameBase::setDamageLevel("@%this@", 2);",0.25);
		$mine::count--;
	}
	else 
	{
		%vel = Item::getVelocity(%this);	
	   	if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{		
			%Pos = GameBase::getPosition(%this); 	
			%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%this);
		 	%obj = Projectile::spawnProjectile("GrenadeTrailGren", %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %vel);
		}
		else
			echo("!! Butterfly Error, Grenade Trail. vel ="@%vel);				
				
		schedule("GrenadeShellMine::deployCheck(" @ %this @ ");", 0.25, %this);
	}
}