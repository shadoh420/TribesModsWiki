//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 100.0;
	damageType = $MineDamageType;
	kickBackStrength = 300;
	triggerRadius = 1.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
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
	if (((%type == "Player") || %data == AntipersonelMine || %data == MiniMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		%pickAnim = radnomItems(4, 34, 34, 33, 28);
		Player::setAnimation(%object, %pickAnim);
	}
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
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

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 2.0;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",20.0,%this);
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

//for the rockeye
MineData Clus { className = "Mine"; description = "Handgrenade"; shapeFile = "mortar"; shadowDetailMask = 4; explosionId = debrisEoxpMedium; explosionRadius = 0; damageValue = 0; damageType = 187; kickBackStrength = 0; triggerRadius = 1.0; maxDamage = 2.0; 
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 1, 1, 1};
	}; 

function Clus::onAdd(%this) { schedule("Clus::Detonate(" @ %this @ ", " @ $SClu @ ");",0.8,%this); } 

function Clus::Detonate(%this, %cl) { 
	GameBase::applyRadiusDamage($MortarDamageType, getBoxCenter(%this), 9, 0.45, 10, %cl);
	GameBase::setDamageLevel(%this, 1); 
} 
