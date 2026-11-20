// mini bomber
// grenade, triple grenade, mine dropper, starburst mine

$InvList[GrenadeLauncher] = 1;
$MobileInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;

$InvList[GrenadeAmmo] = 1;
$MobileInvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = false;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

// addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);

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

GrenadeData GrenadeLauncherGrenFake
{	
	bulletShapeName = "mortar.dts";
	explosionTag = grenadeExp;
	collideWithOwner = false;
	ownerGraceMS = 350;
	collisionRadius = 0.2;
	mass = 0.1;
	elasticity = 0.35;
	damageClass = 1;
	damageValue = 0.40;	//0.25
	damageType = $ShrapnelDamageType;
	explosionRadius = 20;	//15
	kickBackStrength = 10.0;
	maxLevelFlightDist = 130;
	totalTime = 12.0;
	liveTime = 1.0;
	projSpecialTime = 0.2;
	inheritedVelocityScale = 0.25;
	smokeName = "plasmatrail.dts";
};
ItemImageData GrenadeLauncherImage 
{	
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GrenadeAmmo;
	projectileType = GrenadeLauncherGrenFake;	//BomberWarhead;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;	//SoundTurretDeploy;	//SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher 
{	
	description = "Mini Bomber";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncher::MountExtras(%player,%weapon)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
	{
		if(%clientId.MiniMode == 0)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>Triple Grenade Projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
		else if(%clientId.MiniMode == 1)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>Starburst Mine Projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
		else if(%clientId.MiniMode == 2)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>Lucifers Hammer Projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
		else if(%clientId.MiniMode == 3)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>Camera Projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
			
	}	
}
		// <jc> = center justified, 
		// <f1> = tan font, 
		// <f2> = white font, 

//
//function GrenadelauncherImage::onFire(%player)
// Grenade Launcher just got it's target (laser) back. 3/11/2008 2:58AM -Plasmatic
function Grenadelauncher::onFired(%player)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%team = GameBase::getTeam(%clientId);


	if(%clientId.MiniMode == 0)
	{
		if(%AmmoCount > 1)
		{
			Projectile::spawnProjectile("GrenadeLauncherGren1",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren2",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren3",%trans,%player,%vel,%player);
			Annihilation::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Triple Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}	
	else if(%clientId.MiniMode == 1)
	{
		if(%AmmoCount > 4)
		{
			CountMines("MiniMine",300);	//Plasmatic 3.1
			%player.team = %team; //hard coded to guard against players firing then dying before mines deploy -plasmatic
	 		%newObj = Projectile::spawnProjectile("MinerShell", %trans, %player, %vel);
			schedule("SplitMines(" @ %newObj @ ", " @ %player @ ");", 2.8);
			schedule("TossMines(" @ %newObj @ ", " @ %player @ ", 10,true);", 3.0);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
			Annihilation::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],5);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Mine Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}
	else if(%clientId.MiniMode == 2)
	{
		if(%AmmoCount > 0)
		{		
			%vel = Item::getVelocity(%player);
			// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
			if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
			{	
				%energy = GameBase::getEnergy(%player);
				gamebase::setenergy(%player,%energy -20);
				%trans = GameBase::getMuzzleTransform(%player);
				%newObj = Projectile::spawnProjectile("HammerShell",%trans,%player,%vel);
				schedule("HammerShell::Arm(" @ %NewObj @ ", " @ %player @ ");", 0.1);	//0.3
				Annihilation::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
				playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
			}
			else 	
				echo("!! Butterfly Error, Hammer fire. vel ="@%vel);	
		}	
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Grenade Launcher out of ammo.");
			return false;
		}				
	}	
	if(%clientId.MiniMode == 3)
	{
		if(%AmmoCount > 0)
		{
			%proj = Projectile::spawnProjectile("GrenadeLauncherGren",%trans,%player,%vel,%player);
			$owner[%proj] = %clientId;
			Player::trigger(%clientId, 0, false);
			schedule("projectile::follow("@%proj@");",0.125);
			Annihilation::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));	
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Grenade Launcher out of ammo.");
			return false;
		}
	}		
}
// Remember, a grenade is a lobbed projectile, a handgrenade is actually a mine with a timer. -Plasmatic
function GrenadeLauncherGrenFake::onadd(%this)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{	
			%player = Client::getOwnedObject(%cl);
			%trans = GameBase::getMuzzleTransform(%player);	//position of tip
				%posX = getWord(%trans,9);		//x
				%posY = getWord(%trans,10);		//y
				%posZ = getWord(%trans,11); 		//z	
			%GunTipPos = %posX@" "@%posY@" "@%posZ;	
			if(vector::getdistance(%GunTipPos, gamebase::getposition(%this))< 0.01)
			{	
				//yes this is ugly.. -Plasmatic
				schedule("deleteobject("@%this@");",0.01);
				%weapon = Player::getMountedItem(%cl,$WeaponSlot);
				messageall(1,%e);
				%e = %weapon@"::onFired("@%player@");";
				//messageall(1,%e);
				eval(%e);
				
			}
		}
	}
}

function projectile::follow(%this)
{
	%cl = $owner[%this];	

	if(%cl)
	{
		if (GameBase::getPosition(%this) != "0 0 0")
		{
			%cl.ObserverTarget = %this;
			%cam = Client::getControlObject(%cl);
			%pl = client::getownedobject(%cl);
			if(%cam == %pl)
			{
				%camera = Client::getObserverCamera(%cl);
				Client::setControlObject(%cl, %camera);
				%pvel = Item::getVelocity(%this);
				%pnor = vector::normalize(%pvel);			
				Observer::setOrbitObject(%cl, %this ,0,0,10,vector::add("1.57 0 0",vector::getrotation(%pnor)));	//start, min, max, fucking rotation (bitch) in rad.
				
			}
		}
	}
}

function Grenade::onremove(%this)
{
	%client = $owner[%this];
	if(%client.ObserverTarget != %this)
		return;	
		
	%client.ObserverTarget = "";
	%pl = client::getownedobject(%client);
	$owner[%this] = "";
	if(%pl != -1 && !Player::isDead(%client)) 
		Client::setControlObject(%client, %pl);
}

function grenade::jump(%client)
{
	%target = %client.ObserverTarget;	//we could do something interesting with this... 
	%client.ObserverTarget = "";
	%pl = client::getownedobject(%client);
	if(%pl != -1 && !Player::isDead(%client)) 
		Client::setControlObject(%client, %pl);	
}

function grenade::triggerdown(%client)
{
}

function beginmines(%newobj,%this,%count)
{	
	if(%count)
	{
	//	echo(GameBase::getPosition(%newObj));
		if (GameBase::getPosition(%newObj) != "0 0 0")
		{
			TossMines( %newObj, %this, 1, false);
			%count = %count -1;
			schedule("BeginMines(" @ %newObj @ ", " @ %this @ ", "@ %count @");", 0.3);
		}
	}
}

//--------------------------------------
function SplitMines(%newobj,%this)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	if(vector::normalize(%vel) != "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic
	{	
	// Pretty shell split
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
	 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %vel);
	}
	else
		echo("!! Butterfly Error, Splitmines. vel ="@%vel);		
}


function TossMines(%newobj,%this,%count,%delete)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%vel = Item::getVelocity(%newobj);
	if(vector::normalize(%vel) != "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic
	{	
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);
	
	// Spawn butterflies
		if (GameBase::getPosition(%newObj))
		{
			for(%i=0; %i < %count; %i += 1) 
			{
				%xrnd = %xvel + floor(getRandom() * 60) -30;
				%yrnd = %yvel + floor(getRandom() * 60) -30;
				%zrnd = %zvel + floor(getRandom() * 20);
	
				%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;
	
				%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
		 		%obj = Projectile::spawnProjectile("MineFloaters", %trans, %this, %vel);
				//Projectile::spawnProjectile(%obj);
				GameBase::setPosition(%obj, %pos);
				Item::setVelocity(%obj, %forceVel);
				%rnd = (floor(getRandom()*20)/80);
				schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
			}
		if (%delete) 
			deleteobject(%newObj);
		}
	}
	else
		echo("!! Butterfly Error, Tossmines. vel ="@%vel);	
}

function SetMines(%newobj,%this){

	if (GameBase::getPosition(%newObj))
	{
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
   		%Mine = newObject("","Mine","MiniMine");
   		%mine.noOwner = "";
   		if(player::isdead(%this)) 
   		{
   			%team = %this.team;
   			%mine.noOwner = true;
   		}
  		else 
  			%team = GameBase::getTeam (%this);

 		//addToSet("MissionCleanup", %Mine);
 		addToSet("MissionCleanup/MiniMine", %mine);	//3.1 Plasmatic
      		GameBase::throw(%Mine,%this,-1,true);
      		GameBase::setTeam (%Mine,%team);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);

		deleteobject(%newObj);
	}
}

