///-----------------------------------------------
/// description = "Air Base";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData ABPortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";
        className = "Generator";
        debrisId = flashDebrisSmall;
        sfxAmbient = SoundGeneratorPower;
        maxDamage = 5.0;
        mapIcon = "M_generator";
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = flashExpMedium;
        visibleToSensor = true;
        mapFilter = 4;

};

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;
}

StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1000.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};

StaticShapeData LargeAirBaseRadar
{
        shapeFile = "radar";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.00;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Air Base Radar";
};

function LargeRadar::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);

function ABPortGenerator::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "airbase"]--;

}
}