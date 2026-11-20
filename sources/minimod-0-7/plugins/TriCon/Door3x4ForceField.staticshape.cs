///-----------------------------------------------
/// description = "3x4 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorthreebyfourForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_3x4";
maxDamage = 200.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "3x4 Field Door";
};
function doorthreebyfourForceFieldShape::Destruct(%this)
{
doorthreebyfourForceFieldShape::doDamage(%this);
}
function doorthreebyfourForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorthreebyfourForceFieldShape::onDestroyed(%this)
{
doorthreebyfourForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorthreebyfourForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorthreebyfourForceFieldShape::openDoor(%this);
return;
}
function doorthreebyfourForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",4);
}
function doorthreebyfourForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorthreebyfourForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",4);
}




