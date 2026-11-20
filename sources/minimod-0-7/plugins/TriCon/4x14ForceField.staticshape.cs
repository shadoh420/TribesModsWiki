//This is a MiniMod Plugin...
//This is the Teleport Pad from the ol' Renegades1.2 mod. Ported&Modified by Dewy.

StaticShapeData fourbyfourteenForceFieldShape
{
        shapeFile = "forcefield_4x14";
        debrisId = defaultDebrisSmall;
        maxDamage = 4.50;
        visibleToSensor = true;
        isTranslucent = true;
        description = "4x14 Force Field";
};

function fourbyfourteenForceFieldShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "fourbyfourteenForceFieldPack"]--;

}