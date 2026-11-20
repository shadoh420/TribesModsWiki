///-----------------------------------------------
/// description = "4x8 Force Field";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


StaticShapeData doorfourbyeightForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x8";
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
description = "4x8 Field Door";
};
function doorfourbyeightForceFieldShape::Destruct(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
}
function doorfourbyeightForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfourbyeightForceFieldShape::onDestroyed(%this)
{
doorfourbyeightForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfourbyeightForceFieldShape::onCollision(%this,%obj)
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
doorfourbyeightForceFieldShape::openDoor(%this);
return;
}
function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}
function doorfourbyeightForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfourbyeightForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",4);
}


