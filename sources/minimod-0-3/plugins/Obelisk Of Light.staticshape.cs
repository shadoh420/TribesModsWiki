// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from the Ideal mod. Ported by Dewy.
//


function ObeliskPower::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function ObeliskPower::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down
}

function ObeliskPower::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPowerPack"]--;
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170); 
}

function ObeliskPower::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function ObeliskPower::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setDamageLevel(%this.obelisk, 20); //kill the turret when it goes down

}

StaticShapeData ObeliskPower
{
   description = "Obelisk Power Source";
	shapeFile = "solar";
	className = "Generator";
	debrisId = flashDebrisLarge;
	maxDamage = 1.5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};


StaticShapeData ObeliskOfLight
{
   description = "Obelisk of Light";
	shapeFile = "anten_med";
	className = "Decoration";
	debrisId = flashDebrisLarge;
	maxDamage = 5;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;

   sfxAmbient = SoundBuzz;

};



function ObeliskOfLight::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 

	%realGun = %this.realGun;
	GameBase::setDamageLevel(%realGun, 10);
	%gen = %this.gen;
	%gen.obelisk = "";
  	$TeamItemCount[GameBase::getTeam(%this) @ "ObeliskPack"]--;
}

// Override base class just in case.
function ObeliskOfLight::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}


function ObeliskOfLight::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function ObeliskOfLight::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}

