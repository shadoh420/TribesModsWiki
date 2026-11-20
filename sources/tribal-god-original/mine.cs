StaticShapeData DefaultBeacon
{
	className      = "Beacon";
	damageSkinData = "objectDamageSkins";
	shapeFile      = "sensor_small";
	maxDamage      = 0.1;
	maxEnergy      = 200;
    castLOS        = true;
    supression     = false;
	mapFilter      = 2;
	visibleToSensor = true;
    explosionId     = flashExpSmall;
	debrisId        = flashDebrisSmall;
};																		 
function Beacon::onEnabled(%this)
{
   echo("Beacon  onEnabled");
   GameBase::setIsTarget(%this,true);
}
function Beacon::onDisabled(%this)
{
   echo("Beacon  onDisabled");
   GameBase::setIsTarget(%this,false);
}
function Beacon::onDestroyed(%this)
{
	echo("Beacon  onDestroyed");
	GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}


MineData lilBoost
{
	className = "Mine";
   description = "LiLBoost";
   shapeFile = "mine";
      validateShape = false;
   validateMaterials = false;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 113;
	triggerRadius = 250;
	maxDamage = 0.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function lilBoost::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
   if(%type == $MineDamageType)
   { %value = %value * 0.25; }

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

MineData BoostBrake
{
	className = "Mine";
	description = "";
	shapeFile = "mine";
	validateShape = false;
	validateMaterials = false;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 8.0;
	damageValue = 0.0; 
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 250;
	maxDamage = 0.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};



//========== Mine Functions ==========//
function Mine::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
	if(%type == $MineDamageType){ return; }
	
	%damLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this, %damLevel + %value);
}
function Mine::Detonate(%this)
{ %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); }