///-----------------------------------------------
/// description = "Air Ammo Pad";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData AirAmmoBasePad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "AirAmmoBasePad";
};

function thinelevator::onDestroyed(%this)
{
   StaticShape::objectiveDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "AirAmmoPad"]--;
}