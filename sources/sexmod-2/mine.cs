
//--------------------------------------

$InvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;

//--------------------------------------



//--------------------------------------

$AutoUse[RepairKit] = true;

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

//--------------------------------------
function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}
//--------------------------------------

$SellAmmo[MineAmmo] = 5;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackItems[5] = MineAmmo;

//--------------------------------------

$TeamItemMax[mineammo] = 35;

//--------------------------------------

$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;

//--------------------------------------


function MineAmmo::onUse(%player,%item) 
{
	GameBase::playSound(%player, throwitem, 0);
	 if($matchStarted) { if(%player.throwTime < getSimTime() ) { Player::decItemCount(%player,%item); %armor = Player::getArmor(%player); %client = Player::getClient(%player); if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine"); else { %obj = newObject("","Mine","antipersonelMine"); GameBase::setTeam (%obj,GameBase::getTeam (%client)); } addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } }

//function MineAmmo::onUse(%player,%item)
//{
//	if($matchStarted) {
//		if(%player.throwTime < getSimTime() ) {
//			Player::decItemCount(%player,%item);
//			%obj = newObject("","Mine","antipersonelMine");
//		 	addToSet("MissionCleanup", %obj);
//			%client = Player::getClient(%player);
//			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
//			%player.throwTime = getSimTime() + 0.5;
//		}
//	}
//}

//--------------------------------------

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = false;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 0.6;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}


function AntipersonelMine::onCollision(%this,%object) 
{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this);
	 if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && 
		GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); }

function AntipersonelMine::deployCheck(%this) 
{
	 if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this); }


function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//--------------------------------------

$SellAmmo[Grenade] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackItems[4] = Grenade;

//--------------------------------------

$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;

//--------------------------------------


function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
			GameBase::playSound(%player, throwitem, 0);
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
echo("grenade tosser ",%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//--------------------------------------

MineData Handgrenade
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
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0 ,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//--------------------------------------

$SellAmmo[Beacon] = 5;
$AmmoPackMax[Beacon] = 10;
$AmmoPackItems[12] = Beacon;

//--------------------------------------

$TeamItemMax[Beacon] = 40;

//--------------------------------------

$InvList[Beacon] = 1;
$RemoteInvList[Beacon] = 1;

//--------------------------------------


MineData Agedoner
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
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};
																		 
