
//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = shockwave;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $MineDamageType;
	kickBackStrength = 450;
	triggerRadius = 150.0;
	maxDamage = 0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.0001,%this);
}

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == AntipersonelMine || %data == MiniMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		%pickAnim = radnomItems(4, 34, 34, 33, 28);
		Player::setAnimation(%object, %pickAnim);
	}
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.5;
	friction = 0.5;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "Discb";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = -450;
	triggerRadius = 150.0;
	maxDamage = 0;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.0001,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//-----------------------------------------------------------------------------------

MineData Boost
{
	className = "Handgrenade";
   description = "Beacon";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 475; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	//shadowDetailMask = 0;
	//destroyDamage = 1.0;
	//damageLevel = {1.0, 1.0};
};

function Boost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //echo("Boost  onDamage");
   //if (%type == $MineDamageType)
   //   %value = %value * 0.25;

   //	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,2);
}

//-----------------------------------------------------------------------
//--------------------------------------------------------------
//Scatter Mortar - based on Tricon Mine Launcher
//--------------------------------------------------------------
MineData Bomb1
{
   mass = 9;
   drag = 0.3;
   density = 2.0;
	elasticity = 0;
	friction = 1.0;
	className = "Bomblet";
   description = "Scatter Shot";
   shapeFile = "plasmabolt";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = PopcornExp;
	explosionRadius = 20.0;
	damageValue = 0.6;
	damageType = $MortarDamageType;
	kickBackStrength = 150;
	triggerRadius = 4;
	maxDamage = 100;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Bomb1::onAdd(%this)
{
	%this.damage = 0;
	Bomb1::deployCheck(%this);
	%data = GameBase::getDataName(%this);
}

function Bomb1::onCollision(%this,%object)
{
	%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Bomb1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else 
		schedule("Bomb1::deployCheck(" @ %this @ ");", 0.1, %this);
}	

//--------------------------------------------------------------
MineData Bomb2
{
   mass = 9;
   drag = 0.3;
   density = 2.0;
	elasticity = 0;
	friction = 1.0;
	className = "Bomblet";
   description = "Scatter Shot";
   shapeFile = "plasmabolt";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = PopcornExp;
	explosionRadius = 20.0;
	damageValue = 0.6;
	damageType = $MortarDamageType;
	kickBackStrength = 150;
	triggerRadius = 4;
	maxDamage = 100;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Bomb2::onAdd(%this)
{
	%this.damage = 0;
	Bomb2::deployCheck(%this);
	%data = GameBase::getDataName(%this);
}

function Bomb2::onCollision(%this,%object)
{
	%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Bomb2::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
			%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
	}
	else 
		schedule("Bomb2::deployCheck(" @ %this @ ");", 0.1, %this);
}	

//--------------------------------------------------------------
MineData Bomb3
{
   mass = 9;
   drag = 0.3;
   density = 2.0;
	elasticity = 0;
	friction = 1.0;
	className = "Bomblet";
   description = "Scatter Shot";
   shapeFile = "plasmabolt";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = PopcornExp;
	explosionRadius = 20.0;
	damageValue = 0.6;
	damageType = $MortarDamageType;
	kickBackStrength = 150;
	triggerRadius = 4;
	maxDamage = 100;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Bomb3::onAdd(%this)
{
	%this.damage = 0;
	Bomb3::deployCheck(%this);
	%data = GameBase::getDataName(%this);
}

function Bomb3::onCollision(%this,%object)
{
	%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Bomb3::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
			%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
	}
	else 
		schedule("Bomb3::deployCheck(" @ %this @ ");", 0.1, %this);
}

//--------------------------------------------------------------
MineData Bomb4
{
   mass = 9;
   drag = 0.3;
   density = 2.0;
	elasticity = 0;
	friction = 1.0;
	className = "Bomblet";
   description = "Scatter Shot";
   shapeFile = "plasmabolt";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = PopcornExp;
	explosionRadius = 20.0;
	damageValue = 0.6;
	damageType = $MortarDamageType;
	kickBackStrength = 150;
	triggerRadius = 4;
	maxDamage = 100;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Bomb4::onAdd(%this)
{
	%this.damage = 0;
	Bomb4::deployCheck(%this);
	%data = GameBase::getDataName(%this);
}

function Bomb4::onCollision(%this,%object)
{
	%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Bomb4::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) 
	{
			%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
	}
	else 
		schedule("Bomb4::deployCheck(" @ %this @ ");", 0.1, %this);
}

//----------------------------------------------------------------------------


MineData Bomba
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = GrenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}


MineData Bombe
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 25.0;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Bomblet";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.5;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}