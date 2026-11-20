///-----------------------------------------------
/// description = "4x8 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData fourbyeightForceFieldShape
{
        shapeFile = "forcefield_4x8";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x8 Force Field";
};

function fourbyeightForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyeightForceFieldPack"]--;

}