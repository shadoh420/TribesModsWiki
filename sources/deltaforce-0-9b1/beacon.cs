StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 
function Beacon::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Beacon::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

function Beacon::onDestroyed(%this)
{
   GameBase::setIsTarget(%this,false);
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

// --------------------------------------------------
// DELTA FORCE

StaticShapeData DefaultCharge
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = LargeShockwave;
	debrisId = flashDebrisSmall;
};
																						 
function Charge::onEnabled(%this)
{
	Gamebase::setIsTarget(%this, false);
	startCount(%this);
}

function Charge::onDisabled(%this) {}

function Charge::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "Charge"]--;
}

function startCount(%object) 
{
	if ($countDown[%object] == 0) {
		$countDown[%object] = 15;
		checkTheCount(%object);
	} else $countDown[%object] = 15;
}

function checkTheCount(%object)
{
	if ($countDown[%object] > 0) {
		$countDown[%object]--;
		//echo("Charge: Timer at ",$countDown[%object],".");
		schedule("checkTheCount(" @ %object @ ");", 1, %object);
	} else {
		// %chargepos = Gamebase::getPosition(%object);
		// %chargerad = Gamebase::getRadius(%object) + 50.0;
		// Gamebase::applyRadiusDamage($DebrisDamageType, %chargepos, %chargerad, 20.0, 10.0, %object);
		CalcRadiusDamage(%object,$ChargeDamageType,20,0.2,25,20,20,20.5,10.1,200,100); 
		Gamebase::setDamageLevel(%object, 0.1);
		$TeamItemCount[GameBase::getTeam(%this) @ "Charge"]--;
		echo("MSG: Charge has exploded");
	}	
}

// END DELTA FORCE
// --------------------------------------------------