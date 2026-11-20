//This is a MiniMod Plugin...
//This is the Flame Turret from the Ideal mod. Ported by Dewy.

StaticShapeData Canister
{
   description = "Flame Turret Fuel";
	shapeFile = "liqcyl";
	className = "Decoration";
	debrisId = flashDebrisMedium;
	maxDamage = 0.55;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;

};



function Canister::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 

	GameBase::setDamageLevel(%this.turret, 0.6);
}

// Override base class just in case.
function Canister::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}


function Canister::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function Canister::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}



