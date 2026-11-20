///-----------------------------------------------
/// description = "5x5 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData fivebyfiveForceFieldShape
{
        shapeFile = "forcefield_5x5";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "5x5 Force Field";
};

function fivebyfiveForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fivebyfiveForceFieldPack"]--;

}