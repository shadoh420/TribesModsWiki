///-----------------------------------------------
/// description = "3x4 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData threebyfourForceFieldShape
{
        shapeFile = "forcefield_3x4";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "3x4 Force Field";
};

function threebyfourForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "threebyfourForceFieldPack"]--;

}