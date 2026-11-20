///-----------------------------------------------
/// description = "Hologram";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

StaticShapeData Hologram1
{
        shapeFile = "larmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 0.75;
   description = "Hologram";
};
function Hologram1::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}


StaticShapeData Hologram2
{
        shapeFile = "marmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 1.10;
   description = "Hologram";
};
function Hologram2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}

//----------------
StaticShapeData Hologram3
{
        shapeFile = "harmor";
        debrisId = defaultDebrisSmall;
        maxDamage = 1.5;
   description = "Hologram";
};
function Hologram1::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;

}