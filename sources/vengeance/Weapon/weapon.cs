
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

// For multi image weapon sweetness
ItemData EyeCandy
{
	description = "EyeCandy";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{	
	if(%player.Station=="")
	{
		%ammo = %item.imageType.ammoType;
		if(%ammo == "") 
		{
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else 
		{
			if(Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else 
				Client::sendMessage(Player::getClient(%player),0,%item.description@" has no ammo");
			
		}
	}
}

// weapons use this function to determine reload speed based on speed pack state. -Plasmatic Vengeance
function Weapon::SpeedPackCheck(%player,%weapon,%reload)
{
	%Fast = 0.85;	//0.85;
	%Speed = 0.70;	//0.70;
	
	%client = GameBase::getOwnerClient(%player);
	%armor = Player::getArmor(%client);
//	%baseArmor = $ArmorName[%armor];

//	echo(%player.WeaponReloading[%weapon]);
	
//	echo(%armor@", "@$ArmorType[Client::getGender(%client), %basearmor]);
	%basearmor = $ArmorType[Client::getGender(%client), $ArmorName[%armor]];
		
	if(String::findSubStr(%armor, "Fast") > 3)	//!string::icompare(%basearmor @ "Fast", %armor))
	{
		schedule(%player@".WeaponReloading["@%weapon@"] = false;",%reload*%fast);
		schedule("Weapon::ReloadSound("@%player@", "@%weapon@");",%reload*%fast -0.1);
	}
		
	else if(String::findSubStr(%armor, "Speed") > 3)	//!string::icompare(%basearmor @ "Speed", %armor))
	{
		schedule(%player@".WeaponReloading["@%weapon@"] = false;",%reload*%speed);
		schedule("Weapon::ReloadSound("@%player@", "@%weapon@");",%reload*%speed -0.1);
	}
	
	else	//if(!string::icompare(%basearmor, %armor))
	{
		schedule(%player@".WeaponReloading["@%weapon@"] = false;",%reload);
		schedule("Weapon::ReloadSound("@%player@", "@%weapon@");",%reload -0.1);
		
	}			
}

function Weapon::ReloadSound(%player,%weapon)
{
// lets notify the player they can fire again.. -Plasmatic Vengeance
	%mounted = Player::getMountedItem(%player,$WeaponSlot);
	if(%mounted == %weapon)
	{		
		%image = %mounted@"Image";
		%sound = $oundReload[%image];
		%ammo = %image.ammoType;
		if($WeaponAmmo[%weapon] == "")
			%count = true;
		else
			%count = Player::getItemCount(%player,$WeaponAmmo[%weapon]);

		if(%sound != "" && %count >0)
			GameBase::playSound(%player, %sound,0);
		
	}
}
//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{

	Player::mountItem(%player,%item,$ToolSlot);
}

// function by Plasmatic -2.2 
// delays mount of extra weapon shapes untill origional shape completely mounts.
// fix to syncronise weapon mount while reloading or firing prev. weapon. // 2.3 Plasmatic
// Using this for weapon help now too. -Plas 3.0

// Remember kiddies. This function is called for ALL weapon type items by:
// function Item::onMount(%player,%item) in item.cs
// This function may cause problems if the second item mounted is also a weapon type.
// set $Console::LogMode = "1"; and $Console::printLevel = "2"; somewhere to check for redundant retardedness.
// -Plasmatic, Vengeance mod

function Weapon::CompleteMount(%player,%weapon)
{
	if(!Player::isDead(%player)) 
	{
		%client = Player::getclient(%player);
		%mounted = Player::getMountedItem(%client,$WeaponSlot);
		
//	echo("Weapon::CompleteMount P"@%player@", W"@%weapon@", M"@%mounted);
		
		if(%mounted  == %weapon)	
			eval(%weapon @ "::MountExtras("@%player@","@%weapon@");");	
		else
		{
			//sigh, lets double check anyhow.. -Plasmatic
			%check = false;
			for(%i = 4; %i<8; %i++)
			{
				%w = Player::getMountedItem(%player,%i);
				if(%w == %weapon)
					%check = true;
			}			
			if(!%check)
				schedule("Weapon::CompleteMount("@%player@","@%weapon@");",0.25);
		}
	}
}



// ok, lets calculate a miss ratio for fakeys and players for the hell of it.. ;) -Plasmatic
function Weapon::MissPercentage(%player)
{
	%trans = GameBase::getMuzzleTransform(%player);	//position of tip
		%posX = getWord(%trans,9);		//x
		%posY = getWord(%trans,10);		//y
		%posZ = getWord(%trans,11); 		//z	
	//figure out general relativity, Einstein..
		%d1= getWord(%trans,3);
		%d2= getWord(%trans,4);
		%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas		
	//check fakey players...
	%simset = nameToID("MissionCleanup/HappyFakes");
	for(%i = 0; (%object = Group::getObject(%simset, %i)) != -1 ; %i++)
	{		
		//echo(getObjectType(%object));
		if(getObjectType(%object) == "Player")
		{
			%TargetPos = getBoxCenter(%object);
			%PlayerPos = %posX@" "@%posY@" "@%posZ;
			%TargetDist = vector::getdistance(%PlayerPos,%TargetPos);
			
			//%GunExtPos is like the end of a broom handle shoved down gun barrel.
			%GunExtPos = %posX + %d1 * %TargetDist@" "@%posY + %d2 * %TargetDist@" "@%posZ + %d3 * %TargetDist;
			%MissDist = vector::getdistance(%GunExtPos,%TargetPos);
			%MissPercent = %MissDist/%TargetDist;
			
			if(!%BestMissPercent)
				%BestMissPercent = %MissPercent;
			if(%BestMissPercent >= %MissPercent)
			{
				%BestMissPercent = %MissPercent;
				%ClosestTarget = %object;
				%BestMissDist = %MissDist;
				%fakeflag = true;
			}
		}
	}
	//check against real players..
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		//echo("client "@%cl);
		%object = Client::getOwnedObject(%cl);
		if(getObjectType(%object) == "Player")
		{
			//echo("checking clients");
			%TargetPos = getBoxCenter(%object);
			%PlayerPos = %posX@" "@%posY@" "@%posZ;
			%TargetDist = vector::getdistance(%PlayerPos,%TargetPos);
			
			//%GunExtPos is like the end of a broom handle shoved down gun barrel.
			%GunExtPos = %posX + %d1 * %TargetDist@" "@%posY + %d2 * %TargetDist@" "@%posZ + %d3 * %TargetDist;
			%MissDist = vector::getdistance(%GunExtPos,%TargetPos);
			%MissPercent = %MissDist/%TargetDist;
			
			if(!%BestMissPercent)
				%BestMissPercent = %MissPercent;
			if(%BestMissPercent >= %MissPercent)
			{
				%BestMissPercent = %MissPercent;
				%ClosestTarget = %object;
				%BestMissDist = %MissDist;
				%fakeflag = false;
			}
		}
	}	
	
	%playerName = Client::getName(gamebase::getownerclient(%ClosestTarget ));		//ai friendly..
	if((%BestMissPercent < 0.055 || %BestMissDist < 5) && %fakeflag)
		client::sendmessage(gamebase::getownerclient(%player ),1,floor((1-%BestMissPercent)*100)@"% "@%playerName@", "@%BestMissDist@"m");	
}
		
			



function remoteNextWeapon(%client)
{
	if($debug)
		echo("remoteNextWeapon"@ Client::getControlObject(%client)@ " owned "@Client::getOwnedObject(%client)@" is observer= "@Observer::isObserver(%client)@" admin obs ="@%client.AdminobserverMode);
	
	if($loadingMission)//2.2 -plasmatic
		return;

	if(%client.observerMode == dead || %client.observerMode == justJoined || %client.observerMode == observerFly) return;

	// toggle distance for obs -plasmatic
	if(%client.observerMode == "observerOrbit" || %client.AdminobserverMode == "AdminObserve")
	{
			%client.obsmode += 1;
			if(%client.obsmode >= 6)
				%client.obsmode = "";	
			if($debug)
				echo("toggle obsmode "@%client@" to "@%client.obsmode);
				
			Observer::setAnnihilationOrbit(%client, %client.observerTarget);
			return;		
	}	
	//end toggle, start weapon change
	else
	{
		if($debug)
			echo("weapon change");
		%player = Client::getOwnedObject(%client);		
		%item = Player::getMountedItem(%client,$WeaponSlot);					
		%player.invulnerable = "";
		// remove invulnerability when player selects weapon.	
		
		if(%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
			
		else
		{
			for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
			{
				if($debug)
					echo("find next weapon "@%weapon);
				if(isSelectableWeapon(%client,%weapon))
				{
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if(Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;	
				}
			}			
		}
	}
}
	
function remotePrevWeapon(%client)
{
	if($loadingMission || %client.observerMode == dead || %client.observerMode == justJoined || %client.observerMode == observerFly)//2.2 -plasmatic
		return;	
	
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if(%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for(%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if(isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if(Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	//%item = EnergyRifle;
	if($debug)
		echo("select valid weapon");
	if(isSelectableWeapon(%client,$FirstWeapon))
	{
		//	3.0 fix for no mount first weapon -Plasmatic
		Player::useItem(%client,$FirstWeapon);
		return;
	}
		
	%item = $FirstWeapon; 
	for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
	{
		if(isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon))
	{
		%ammo = $WeaponAmmo[%weapon];
		if(%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}

//==============================================================
// Ammo


//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

//----------------------------------------------------------------------------
// Exploding ammo by Plasmatic
// copywrite 2002, 2003 Plasmatic
// aka Steve Madden
// defining mines for generic ammo shapes -plasmatic
// Defining collisions for ammo mines, fix for 2.2 -plasmatic


MineData DiscAmmoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//4,5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function DiscammoMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData PlasAmmoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	damageClass = 1; // 0 impact, 1, radius
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function PlasammoMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData ammo1Mine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function ammo1Mine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData grenammoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function grenammoMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData mortarammoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function mortarammoMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData rocketMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};
function rocketMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

MineData ammo2Mine 
{	
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;	
};
function Ammo2Mine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}
MineData mortarMine 
{	
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Ammo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 5.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;	
};
function mortarMine::onCollision(%this,%object) 
{
	AmmoMine::onCollision(%this,%object);
}

// this function could be called when ammo mine is damaged -plasmatic
//function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
//{
//	%damageLevel = GameBase::getDamageLevel(%this);	
//	%data = GameBase::getDataName(%this);
//	if(%damageLevel + %value > %data.maxDamage)
//	{
//		// could run this through a function to spawn correct damage type
//		// or increased kickback/ damage for more ammo counts,
//		// even other cool stuff like grenades-
//		// disk shaped grenade shot up out of disk ammo can for an example.
//		// but doing so causes team/ player ownership problems
//		// allowing players to Team Kill.
//		// -Plasmatic
//		GameBase::setDamageLevel(%this,%damageLevel + %value);	
//	}		
//	else GameBase::setDamageLevel(%this,%damageLevel + %value);	
//}

// default mine damage, since ammo mine damage isnt defined, uses this one. -plasmatic
// all other mines -player deployed have their own damage functions.
// we're going to use this for some visual candy here.. ;) -plasmatic 2.2
function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $NullDamageType)
		return;		
	%damageLevel = GameBase::getDamageLevel(%this);	
	%data = GameBase::getDataName(%this);
	if(%value <= 0)return;//plasmatic 2.3
	
	//T:V mod -Plasmatic
	if(%type ==$HealingDamage || %type == $RepairTurretDamage)
	{
	//	if(GameBase::getTeam(%this) ==  GameBase::getTeam(%object))
	//		RepairDamage(%this,%value);
		return;	
	}
	if($Annihilation::AmmoCooking)
	{
		if(%damageLevel + %value > %data.maxDamage && %this.count)//only called for ammo mines... -plasmatic 2.2
		{
			%type = %this.type;
			if(%type != PlasmaAmmo)	// && %type != PhaseAmmo)
			{
				%count = %this.count;
				if(%count > 3)
					%count = 3;
					
				%bomb = %type@"Bomb";
				for(%i = 0; %i < %count; %i++)
				{
					%obj = newObject("","Mine",%bomb);
					addToSet("MissionCleanup", %obj);
					GameBase::throw(%obj,%this,100 ,true);	
					schedule("GameBase::setDamageLevel("@%obj@", 20);",1);		
				}	
			// this method works fine too, but tribes animates (rotates) all grenade type projectiles
			// in the same direction looks goofy to see all them spin the same direction -plasmatic 2.2
			//	%pos = GameBase::getPosition(%this);
			//	%stray = %type@"stray";
			//	for(%i = 0; %i < %count; %i++)
			//	{
			//		%xrnd = (floor(getRandom() *201)-100)/100;
			//		%yrnd = (floor(getRandom() *201)-100)/100;				
			//		%aim = %xrnd @" "@ %yrnd @" 1";	//always up..
			//		%newtrans = "0 0 1 "@ %aim @" 0 0 1 "@ %pos; 
			//		Projectile::spawnProjectile(%stray,%newtrans,%this,%vel,%target);		
			//	}		
					
			}
		
		}
	}			
	GameBase::setDamageLevel(%this,%damageLevel + %value);	
}

//	function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
//	{
//		%damageLevel = GameBase::getDamageLevel(%this);	
//		GameBase::setDamageLevel(%this,%damageLevel + %value);
//	}
			
			
// fix for 2.2 -plasmatic
function AmmoMine::onCollision(%this,%object) 
{	
	if($debug) echo("Ammo collision "@%this.type@", "@%this.count);
	//echo("proj ="@%this.type.imageType);
	if(getObjectType(%object) == "Player" && !Player::isDead(%object)) 
	{	
		// transfer ammo to colliding player -plasmatic
		%item = %this.type;
		%count = %this.count;
		if(Item::giveItem(%object,%item,%count)) 
		{
			Item::playPickupSound(%this);
			deleteObject(%this);
		}
	}	
	else
	{
		//echo("mine colllision with "@getObjectType(%object));	
		//Hmm, could detonate on contact with enemy objects here... -plasmatic
	}	
}

function Mine::onAdd(%this)
{
	Mine::deployCheck(%this);
	$Ammo::count += 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function Mine::onRemove(%this)
{
	$Ammo::count -= 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function Mine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) 
	{
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			if(%data == GameBase::getDataName(Group::getObject(%set,0)))
				GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("Mine::deployCheck(" @ %this @ ");", 3, %this);
}


function Ammo::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if($debug)
			echo("Ammo::onDrop(%player,%item,%count) ",%player,%item,%count);
		if(%count <= %delta)
		{
			if(%item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;
		}
		if(%delta > 0)
		{
			
			%client = Player::getClient(%player);
			%shape = %item.shapeFile;
			%obj = newObject("","Mine",%shape@"Mine");
			GameBase::setTeam (%obj,GameBase::getTeam(%client));
			GameBase::setMapName(%obj,%item);						
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,4+getRandom()*2,false);			

			%obj.count = %delta;
			%obj.type = %item;
			
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);	
			
			if(%client.InvConnect)
			{	
				%client.ThrowWait = true;
				schedule(%client@".ThrowWait = false;",0.5);		
			}
					
		}
	}
}
// end ammo routines	
//=======================================================