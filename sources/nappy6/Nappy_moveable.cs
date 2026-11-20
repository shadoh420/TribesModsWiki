function Elevator::onBlocker(%this,%obj)
{
// Will get called 30/s for blocking objects
//echo("Moveable::onBlocker: " @ %this @ " " @ %obj);
%object = GameBase::getDataName(%obj);
%class = %object.className;
if(%class == "ARMOR"){
GameBase::applyDamage(%obj,$CrushDamageType,$Nappy::Elevator::ArmorCrushDamage,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}
else{
GameBase::applyDamage(%obj,$CrushDamageType,$Nappy::Elevator::ObjectCrushDamage,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}
}
