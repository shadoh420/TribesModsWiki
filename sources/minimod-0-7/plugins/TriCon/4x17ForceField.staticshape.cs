///-----------------------------------------------
/// description = "4x17 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData fourbyseventeenForceFieldShape
{
        shapeFile = "forcefield_4x17";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x17 Force Field";
};

function fourbyseventeenForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyseventeenForceFieldPack"]--;

}