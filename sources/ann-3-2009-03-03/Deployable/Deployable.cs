function SelfPoweredSensor::onPower(%this,%power,%generator)
{
	%data = GameBase::getDataName(%this);
	// we're not going to mess with deployable turrets. Only base turrets.
//	messageall(1,%data @", "@%this@" SelfPoweredSensor::onPower "@%data.className);

}


function SelfPoweredSensor::onEnabled(%this)
{
	%data = GameBase::getDataName(%this);
	// we're not going to mess with deployable turrets. Only base turrets.
//	messageall(1,%data @", "@%this@" SelfPoweredSensor::onEnabled "@%data.className);
	
	%this.shieldStrength = 0.03;
	GameBase::setRechargeRate(%this,10);
	GameBase::setActive(%this,true);
}


function SelfPoweredSensor::onDisabled(%this)
{
	%data = GameBase::getDataName(%this);
	// we're not going to mess with deployable turrets. Only base turrets.
//	messageall(1,%data @", "@%this@" SelfPoweredSensor::onDisabled "@%data.className);
	
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	SelfPoweredSensor::onDeactivate(%this);
}




function SelfPoweredSensor::onAdd(%this)
{
	schedule("SelfPoweredSensor::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.0;
	if(GameBase::getMapName(%this) == "") 
	{
		%data = GameBase::getDataName(%this);
		
		GameBase::setMapName (%this, %data.description);
		
	}
}

function SelfPoweredSensor::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function SelfPoweredSensor::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}


function SelfPoweredSensor::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	%this.OrgTeam = "";
	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}



//	function SelfPoweredSensor::onActivate(%this)
//	{
//		GameBase::playSequence(%this,0,"power");
//	}

//	function SelfPoweredSensor::onDeactivate(%this)
//	{
//		GameBase::pauseSequence(%this,0);
//	}
////////////////////////////////////



