$InvList[MineAmmo] = 1;
$MobileInvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;
AddItem(MineAmmo);

$SellAmmo[MineAmmo] = 5;
$TeamItemMax[mineammo] = 35;

//$InvList[ReplicatingMine] = 1;
//$RemoteInvList[ReplicatingMine] = 1;

addAmmo("", MineAmmo, 1);

function oldMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}


function Mine::Detonate(%this) 
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//function MineAmmo::onUse(%player,%item)
//{
//	if($matchStarted)
//	{
//		if(%player.throwTime < getSimTime() )
//		{
//
//			if(Player::getItemCount(%player, OriginalMine))
//			{
//				%name = "AntipersonelMine";
//				%item = OriginalMine;
//			}
//			else if(Player::getItemCount(%player, ReplicatingMine))
//			{
//				%name = "ReplicatorMine";
//				%item = ReplicatingMine;
//			}
//			else if(Player::getItemCount(%player, FlagMine))
//			{
//				%name = "FakeFlag";
//				%item = FlagMine;
//			}
//
//			if(!$build)Annihilation::decItemCount(%player,%item);
//			Annihilation::decItemCount(%player, MineAmmo);
//			%obj = newObject("","Mine",%name);
//			%obj.cloakable = true;	//for base cloaker
//			addToSet("MissionCleanup", %obj);
//			%client = Player::getClient(%player);
//			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
//			%player.throwTime = getSimTime() + 0.5;
//			GameBase::setTeam(%obj,GameBase::getTeam(%client));
//		}
//	}
//}

 //-=-=-=-

MineData Handgrenade 
{
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;
	
	// distance fix for 3.0 -plasm
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;	
	
};

function Handgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Handgrenade::onRemove(%this)
{
	//do nothing yet..
}


 //-=-=-=- MineAmmo

ItemData MineAmmo 
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};
// over writes function above.. -plasmatic
function MineAmmo::onUse(%player,%item) 
{
	if($matchStarted) 
	{
		GameBase::playSound(%player, SoundThrowItem,0);
		if(%player.throwTime < getSimTime() ) 
		{
			if(!$build)Annihilation::decItemCount(%player,%item);
			%armor = Player::getArmor(%player);
			%client = Player::getClient(%player);
			if($Deathmatch)
				%obj = newObject("","Mine","DMMine");
			else 
			{
				%obj = newObject("","Mine","antipersonelMine");
				GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
			%obj.cloakable = true;	//for base cloaker
			//addToSet("MissionCleanup", %obj);
			addToSet("MissionCleanup/AntipersonelMine", %obj);	//3.1 Plasmatic
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			CountMines("AntipersonelMine",100);	//Plasmatic 3.1
		}
	}
}

 //-=-=-=- 

MineData AntipersonelMine 
{		
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	validateShape = true;
	validateMaterials = true;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this) 
{
	%this.damage = 0;
	GameBase::setMapName(%this,"Mine");
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onRemove(%this)
{
	//do nothing yet..
}


function AntipersonelMine::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player")
	{
		GameBase::startFadein(%this);	//pop this visible for a second -plasmatic
		%this.cloaked = "";
	}
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

// default annihilation mine
function AntipersonelMine::deployCheck(%this) 
{
	if(GameBase::isAtRest(%this)) 
	{
		//GameBase::playSound(%this, SoundMineActivate,0.5);
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}

function AntipersonelMine::onDestroyed(%this) 
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if($debug::Damage)
		echo("AntipersonelMine::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	
	if(%value <= 0) return;	//plasmatic 2.3
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}



 //-=-=-=-

MineData DMMine 
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 250;
	triggerRadius = 2.5;
	maxDamage = 0.75;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function DMMine::onAdd(%this) 
{
	%this.damage = 0;
	DMMine::deployCheck(%this);
}
 
function DMMine::onRemove(%this)
{
	//do nothing yet..
}


function DMMine::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second -plasmatic
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DMMine::deployCheck(%this) 
{
	if(GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else schedule("DMMine::deployCheck(" @ %this @ ");", 3, %this);
}

function DMMine::onDestroyed(%this) 
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if($debug::Damage)
	{
		echo("DMMine::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}	
	if(%value <= 0) return;	//plasmatic 2.3
	if(%type == $MineDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

 //-=-=-=-

MineData HoloMine 
{
	className = "Mine";
	description = "Hologram";
	shapeFile = "larmor";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 2.5;
	maxDamage = 2.00;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this,%clientId) 
{
	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	Client::sendMessage(%clientId,0,"You summon a mirror image of yourself");
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function HoloMine::onRemove(%this)
{
	//do nothing yet..
}


function HoloMine::onCollision(%this,%object) 
{	
	if($debug) 
	  echo("?? EVENT collision "@GameBase::getDataName(%this)@" contacted by "@GameBase::getDataName(%object)@" control cl# "@GameBase::getControlClient(%object));

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second -plasmatic
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::onUse(%clientId) 
{
Client::sendMessage(%clientId,0,"You summon a mirror image of yourself");
}

function HoloMine::deployCheck(%this) 
{
	 if(GameBase::isAtRest(%this))
	{
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}

function HoloMine::onDestroyed(%this) 
{
	if($debug::Damage)
	{
		echo("HoloMine::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	}	
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%value <= 0) return;	//plasmatic 2.3
	if(%type == $MineDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

 //-=-=-=-


MineData Tranqgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.15;
	damageType = $EnergyDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Tranqgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Shockgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = ShockGrenadeExp;	//Shockwave;	//plasmatic -2.2
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ShockDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Shockgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Shockgrenade::onRemove(%this)
{
	//do nothing yet..
}


 //-=-=-=-

 //-=-=-=-

MineData Nukebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Plastique";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 7.5;
	damageValue = 2.0;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 3.0;
};

function Nukebomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}

function Nukebomb::onRemove(%this)
{
	//do nothing yet..
}


function Nukebomb::onCollision(%this,%obj) 
{	
	if($debug) 
		event::collision(%this,%obj);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second -plasmatic
		
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj)) 
		return;

	%clientId = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%armor == "armormBuilder" || %armor == "armorfBuilder") 
	{
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8.5) 
		{
			Client::sendMessage(%clientId,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(%this);
			return;
		}
		else 
		{
			deleteObject(%this);
			Client::sendMessage(%clientId,1,"You disarm the Plastique Explosive.");
		}
	}
}

//----------------- a lil easter egg.. -plasmatic
MineData Fighterbomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Plastique";
	shapeFile = "flyer";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 7.5;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 3.0;
	
};

function Fighterbomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}
 
function Fighterbomb::onRemove(%this)
{
	//do nothing yet..
}


//-------------------------------


// Deployed if Player wearing SuicidePack actually commits suicide
MineData Suicidebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 50.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
 
function Suicidebomb::onRemove(%this)
{
	//do nothing yet..
}


// Deployed in normal manner with pack key
MineData Suicidebomb2 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 70.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

// Override base class
function Suicidebomb2::onAdd(%this) 
{
}
 
function Suicidebomb2::onRemove(%this)
{
	//do nothing yet..
}


function Suicidebomb2::onCollision(%this,%obj) 
{	
	if($debug) 
	  echo("?? EVENT collision "@GameBase::getDataName(%this)@" contacted by "@GameBase::getDataName(%obj)@" control cl# "@GameBase::getControlClient(%obj));
	
	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
	}
		
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj)) 
		return;

	%clientId = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%armor == "armormBuilder" || %armor == "armorfBuilder") 
	{
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) 
		{
			Client::sendMessage(%clientId,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(" @ %this @ ");
			return;
		}
		else 
		{
			deleteObject(%this);
			Client::sendMessage(%clientId,1,"You disarm the DetPack.");
		}
	}
}

 //-=-=-=-

MineData Mortarbomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "sensor_small"; //"grenade";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Mortarbomb::onRemove(%this)
{
	//do nothing yet..
}


MineData Clusterbombmine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "plasammo"; //"grenade";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $MortarDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

function Clusterbombmine::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Clusterbombmine::onRemove(%this)
{
	//do nothing yet..
}

MineData TankBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Tank Bomb";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 30.0;
	damageValue = 0.8;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

function TankBomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function TankBomb::onRemove(%this)
{
	//do nothing yet..
}


MineData Firebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $ExplosionDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Firebomb::onRemove(%this)
{
	//do nothing yet..
}




MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ReplicatorMine::onAdd(%this)
{
	%this.damage = 0;
	ReplicatorMine::deployCheck(%this);
}

function ReplicatorMine::onCollision(%this,%object)
{
	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second -plasmatic
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(((%type == "Player") || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ReplicatorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		%team = GameBase::getTeam(%this);
		echo(%team @ " in deploy check");

		$TeamItemCount[%team @ "replicatingmine"]++;
		if(%this.generation == 0)
			$TeamItemCount[%team @ "originalreplicatingmine"]++;
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine] || $TeamItemCount[%team @ "originalreplicatingmine"] > 5)
		{
			%this.generation = 5;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ReplicatorMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ReplicatorMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	echo(%team @ " in on Destroyed");

	$TeamItemCount[%team @ "replicatingmine"]--;

	if(%this.generation < 4)
		replicateMines(%this, %this.generation+1);
}

function ReplicatorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	 if(%type == $MineDamageType)
			%value = %value * 0.3;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function replicateMines(%this, %generation)
{
	%team = GameBase::getTeam(%this);
	echo("Creating generation " @ %generation @ " for team " @ %team);

	%obj = newObject("","Mine","ReplicatorMine");
	%obj.cloakable = true;	//for base cloaker
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);

	%obj = newObject("","Mine","ReplicatorMine");
			%obj.cloakable = true;	//for base cloaker
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);
}



//-------Mine Launcher---------

MineData MiniMine
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Mini Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.6;
	damageType = $MineDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.0;
};

function MiniMine::onAdd(%this)
{
	%a= $Mine::Count[MiniMine]++;
	%type = "MiniMine";
	$Mine::[%type,%a] = %this;	//plasmatic 3.1 mine tracker.. 
	%this.damage = 0;
	MiniMine::deployCheck(%this);
	$mine::count++;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function MiniMine::onRemove(%this)
{
	$mine::count -= 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}


function MiniMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if($debug::Damage)
		echo("AntipersonelMine::onDamage("@%this@", "@%type@", "@%value@", "@%pos@", "@%vec@", "@%mom@", "@%object@" )");
	
	if(%value <= 0) return;	//plasmatic 2.3
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function MiniMine::onCollision(%this,%object)
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
function MiniMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			if(!%this.noOwner)
			{
				%data = GameBase::getDataName(%this);
				GameBase::setDamageLevel(%this, %data.maxDamage);
				//$mine::count--;
			}
			else if(%this.noOwner) 
			{
				%this.noOwner = "";
				deleteObject(%this);
				$mine::count--;
			}
			
			
		}
		deleteObject(%set);
	}
	else 
		schedule("MiniMine::deployCheck(" @ %this @ ");", 3, %this);
}

// Plasmatic 3.1
function CountMines(%type,%limit)
{
	%group = nameToID("MissionCleanup/"@%type);
	%count = Group::objectCount(%group);

//	echo($Mine::Count[%type]@", "@%count@" mines ("@ %type @") in group, limit = "@%limit);
	
	if(%count > %limit)
	{
		%d = %count - %limit;
		%description = %type.description;
		messageall(0,"Too many "@%description@"s in play, destroying "@%d@".");
		
		%z = $Mine::Count[%type] - 1200;	//$mine::lower[%type];			
		if(%z<0) 
			%z=0;
			
		while(%o < %d && %o < %count && %f < $Mine::Count[%type])	//Group::objectCount(%group) > %limit)// && %c < %count)
		{
			
			//%obj = Group::getObject(%group, %o);

			%f++;
			%this = $Mine::[%type,%z++];
			%pos = gamebase::getposition(%this);
		//	echo(%z@", "@%pos);
			if(vector::getdistance(%pos,"0 0 0")>1)
			{
				%o++;
				if(GameBase::getDataName(%this) == %type)
				{
					%rnd = getRandom() * 10;
					schedule("GameBase::setDamageLevel("@%this@",2);",%rnd);
				}
				echo(%z@"# exploding "@%type @", "@%this);		
			}
		//	else 
		//		echo(%z);
		}
	}
}