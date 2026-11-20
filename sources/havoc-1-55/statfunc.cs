function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if(%type == 999) {
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object)) return;
		%damageLevel = GameBase::getDamageLevel(%this);
		%dValue = %damageLevel - %value;		
		if(%dValue < 0) %dValue = 0;
		GameBase::setDamageLevel(%this,%dValue);
		return;
	}

	%name = GameBase::getDataName(%this);
	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   %this.lastDamageObject = %object;
    %this.lastDamageTT = %type;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == %this.lastDamageTeam) {
		if(%name.className == Generator || (%name.className == Station && %name != "DeployableComStation")) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
	            if(%damageLevel > %disable - 0.05) {
	               return;
    	        } else {
	               %dValue = %disable - 0.05;
				}
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);
}