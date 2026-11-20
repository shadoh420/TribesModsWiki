//----------------------------------------------------------------------------



//----------------------------------------------------------------------------
// Exploding ammo by Plasmatic
// copywrite 2002, 2003 Plasmatic
// aka Steve Madden
// defining mines for ammo shapes -plasmatic
// Defining collisions for ammo mines, fix for 2.2 -plasmatic

if(!$AmmoMineStrength) // 11/13/2005 5:11AM
	$AmmoMineStrength = 0.01;	// <!> edit 25;	//0.5 //3.0;

MineData DiscAmmoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	//3.0;	//4,5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData PlasAmmoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	damageClass = 1; // 0 impact, 1, radius
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData ammo1Mine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData grenammoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData mortarammoMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData rocketMine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;
};


MineData ammo2Mine 
{	
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "ammo2";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;	
};


MineData mortarMine 
{	
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
	description = "Ammo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = $AmmoMineStrength;	// 3.0;	//5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 0.3;	
};


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

// Changed the class name for ammo mines to 'AmmoMine' to use Tribes :: function calling. in 3.0 -Plasmatic
// className = "AmmoMine";	// plasmatic 3.0 -Tribes will use AmmoMine:: functions instead of Mine::
function AmmoMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if($debug::Damage)
		echo("AmmoMine::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	
	if($annihilation::safeAmmo)
		return;
	
	%damageLevel = GameBase::getDamageLevel(%this);	
	%data = GameBase::getDataName(%this);
	if(%value <= 0)return;//plasmatic 2.3

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
		// This method works fine too, but tribes animates (rotates) all grenade type projectiles
		// in the same direction. looks goofy to see all spin the same direction -plasmatic 2.2
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
	GameBase::setDamageLevel(%this,%damageLevel + %value);	
}
			
			
// fix for 2.2 -plasmatic
function AmmoMine::onCollision(%this,%object) 
{	
	if($debug) 
		echo("Ammo collision "@%this.type@", "@%this.count);
	if(%object.testing)	//Plasmatic -Portal gun 11/20/2007 11:45PM
		return;	
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

function AmmoMine::onAdd(%this)
{
	if($annihilation::safeAmmo)
		return;
			
	AmmoMine::deployCheck(%this);
	$Ammo::count += 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function AmmoMine::onRemove(%this)
{
	$Ammo::count -= 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function AmmoMine::deployCheck(%this)
{
	echo("AmmoMine::deploycheck");
	
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
		schedule("AmmoMine::deployCheck(" @ %this @ ");", 3, %this);
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
			GameBase::throw(%obj,%player,5,false);			

			%obj.count = %delta;
			%obj.type = %item;
			
			Item::playPickupSound(%obj);
			Annihilation::decItemCount(%player,%item,%delta);	
			
			if(%client.InvConnect)
			{	
				%client.ThrowWait = true;
				schedule(%client@".ThrowWait = false;",0.5);		
			}
					
		}
	}
}	