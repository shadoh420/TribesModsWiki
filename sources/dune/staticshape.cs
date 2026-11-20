//------------------------------------------------------------------------
// Generic static shapes
//------------------------------------------------------------------------


//------------------------------------------------------------------------
// Default power animation behavior for all static shapes

function StaticShape::onPower(%this,%power,%generator)
{
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this)
{
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function StaticShape::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
}

function StaticShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
   StaticShape::objectiveDestroyed(%this);
	if(GameBase::getDataName(%this) == BlastWall)
	{
		calcRadiusDamage(%this, $DebrisDamageType, 0.5, 0.05, 5, 13, 2, 0.05, 
			0.01, 250, 100); 
	} else if(Gamebase::getDataName(%this) == HunterSeeker)
	{
		// Nothing
	} else
	{
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
			0.1, 250, 100); 
	}
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	if(%type == $AssassinDamageType || %type == $GaroteDamageType)
		return;

	if(%object && getObjectType(%object) == "Flier") {
		%object = %object.clLastMount;
	}
	if(%type == $LaserDamageType) {
		%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
			%value = 0;
	}
	//-Laser Range Damage Multiplier
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType || %type == $LaserDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			%value -= %rate;
		}
		if(%value <= 0.00005)
			%value = 0;
	}
//echo($damageScale[GameBase::getDataName(%this), %type]);
	if($damageScale[GameBase::getDataName(%this), %type] != "")
		%value *= $damageScale[GameBase::getDataName(%this), %type];	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}
	GameBase::setDamageLevel(%this,%dValue);

}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//echo("StaticShape::shieldDamage() " @%type);
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(getObjectType(%object) == "Flier") {
		%object = %object.clLastMount;
	}
	if(%type == $LaserDamageType) {
		%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
			%value = 0;
	}
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType || %type == $LaserDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			%value -= %rate;
		}
		if(%value <= 0.00005)
			%value = 0;
	}
	if(%type != "" && %this.shieldStrength) {
		if(%type == $CrushDamageType || (%value >= 0.6 && %type == $ImpactDamageType) || (%value >= 2.1 && ( %type == $LandingDamageType || %type == $ExplosionDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MineDamageType || %type == $WormDamageType || %type == $NukeDamageType))) {//
			%this.shieldStrength = 0; // set shield = 0 and let damage go through
		} else if(%type == $PlasmaDamageType) { // if its plasma/fire, then it can go through shields, but loses damage amount
			%value *= 0.25;
		} else if(%type != $StunnerDamageType && %type != $Poison2DamageType && %type != $StabDamageType && %type != $PlasmaDamageType && %type != $CutterayDamageType && %type != $SmallLasDamageType && %type != $RifleLasDamageType && %type != $HeavyLasDamageType) { // if not one of these, does no damage what so ever.
			%value = 0;
		}
		if(%value > 0.0 && (%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) ) { //  if its a lasgun no matter what,
			NuclearExplosion(Client::getOwnedObject(%object),1);
			Player::unMountItem(%object,$WeaponSlot);
			NuclearExplosion(%this,1);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(Client::getOwnedObject(%shooterclient)),"0 0 3"), 50, 50, 30, Client::getOwnedObject(%object));
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(%this),"0 0 3"), 50, 50, 30, %this);
			NukeCaused(player::getclient(%object));
		}
	}
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);

}

StaticShapeData FlagStand
{
   description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};


function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,
	%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
{
	%radius = GameBase::getRadius(%this);
	if(%radius) {
		%radius *= %radiusRatio;
		%damageValue = %radius * %damageRatio;
		%force = %radius * %forceRatio;
		if(%radius > %rMax)
			%radius = %rMax;
		else if(%radius < %rMin)
			%radius = %rMin;
		if(%damageValue > %dMax)
			%damageValue = %dMax; 
		else if(%damageValue < %dMin)
			%damageValue = %dMin;
		if(%force > %fMax)
			%force = %fMax; 
		else if(%force < %fMin)
			%force = %fMin;
		GameBase::applyRadiusDamage(%type,getBoxCenter(%this), %radius,
			%damageValue,%force,%this);
	}
}



function FlagStand::onDamage()
{
}

//------------------------------------------------------------------------
// Generators
//------------------------------------------------------------------------

$DamageScale[Generator, $LandingDamageType] = 1.0;	
$DamageScale[Generator, $ImpactDamageType] = 1.0;
$DamageScale[Generator, $CrushDamageType] = 1.0;
$DamageScale[Generator, $BulletDamageType] = 0.2;
$DamageScale[Generator, $PlasmaDamageType] = 0.2;
$DamageScale[Generator, $EnergyDamageType] = 1.0;
$DamageScale[Generator, $ExplosionDamageType] = 1.0;
$DamageScale[Generator, $MissileDamageType] = 1.0;
$DamageScale[Generator, $DebrisDamageType] = 1.0;
$DamageScale[Generator, $ShrapnelDamageType] = 0.2;
$DamageScale[Generator, $LaserDamageType] = 0.2;	
$DamageScale[Generator, $MortarDamageType] = 1.0;	
$DamageScale[Generator, $BlasterDamageType] = 1.0;	
$DamageScale[Generator, $ElectricityDamageType] = 1.0;
$DamageScale[Generator, $MineDamageType] = 1.0;	
$DamageScale[Generator, $StabDamageType] = 0.1;	
$DamageScale[Generator, $PoisonDamageType] = 0.1;	
$DamageScale[Generator, $StunnerDamageType] = 0.1;	
$DamageScale[Generator, $NukeDamageType] = 1.0;	
$DamageScale[Generator, $Poison2DamageType] = 0.1;	
$DamageScale[Generator, $WormDamageType] = 1.0;	
$DamageScale[Generator, $CutterayDamageType] = 1.5;
$DamageScale[Generator, $SmallLasDamageType] = 0.8;
$DamageScale[Generator, $RifleLasDamageType] = 0.8;
$DamageScale[Generator, $HeavyLasDamageType] = 0.8;
$DamageScale[Generator, $AsphyxiationDamageType] = 0.0;
$DamageScale[Generator, $LargeBulletDamageType] = 0.8;
$DamageScale[Generator, $ThrownWeaponDamageType] = 0.1;
$DamageScale[Generator, $ThrownPoisonWeaponDamageType] = 0.1;

$DamageScale[TemperatureRegulator, $LandingDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $ImpactDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $CrushDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $BulletDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $PlasmaDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $EnergyDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $ExplosionDamageType] = 1.0;
$DamageScale[TemperatureRegulator, $MissileDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $DebrisDamageType] = 1.0;
$DamageScale[TemperatureRegulator, $ShrapnelDamageType] = 1.0;
$DamageScale[TemperatureRegulator, $LaserDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $MortarDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $BlasterDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $ElectricityDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $MineDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $StabDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $PoisonDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $StunnerDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $NukeDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $Poison2DamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $WormDamageType] = 0.0;	
$DamageScale[TemperatureRegulator, $CutterayDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $SmallLasDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $RifleLasDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $HeavyLasDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $AsphyxiationDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $LargeBulletDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $ThrownWeaponDamageType] = 0.0;
$DamageScale[TemperatureRegulator, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[SolarPanel, $LandingDamageType] = 1.0;	
$DamageScale[SolarPanel, $ImpactDamageType] = 1.0;
$DamageScale[SolarPanel, $CrushDamageType] = 1.0;
$DamageScale[SolarPanel, $BulletDamageType] = 0.8;
$DamageScale[SolarPanel, $PlasmaDamageType] = 0.2;
$DamageScale[SolarPanel, $EnergyDamageType] = 1.0;
$DamageScale[SolarPanel, $ExplosionDamageType] = 1.0;
$DamageScale[SolarPanel, $MissileDamageType] = 1.0;
$DamageScale[SolarPanel, $DebrisDamageType] = 1.0;
$DamageScale[SolarPanel, $ShrapnelDamageType] = 0.8;
$DamageScale[SolarPanel, $LaserDamageType] = 0.3;	
$DamageScale[SolarPanel, $MortarDamageType] = 1.0;	
$DamageScale[SolarPanel, $BlasterDamageType] = 1.0;	
$DamageScale[SolarPanel, $ElectricityDamageType] = 1.0;
$DamageScale[SolarPanel, $MineDamageType] = 1.0;	
$DamageScale[SolarPanel, $StabDamageType] = 0.5;	
$DamageScale[SolarPanel, $PoisonDamageType] = 0.5;	
$DamageScale[SolarPanel, $StunnerDamageType] = 0.5;	
$DamageScale[SolarPanel, $NukeDamageType] = 1.0;	
$DamageScale[SolarPanel, $Poison2DamageType] = 0.5;	
$DamageScale[SolarPanel, $WormDamageType] = 1.0;	
$DamageScale[SolarPanel, $CutterayDamageType] = 1.5;
$DamageScale[SolarPanel, $SmallLasDamageType] = 1.0;
$DamageScale[SolarPanel, $RifleLasDamageType] = 1.0;
$DamageScale[SolarPanel, $HeavyLasDamageType] = 1.0;
$DamageScale[SolarPanel, $AsphyxiationDamageType] = 0.0;
$DamageScale[SolarPanel, $LargeBulletDamageType] = 1.0;
$DamageScale[SolarPanel, $ThrownWeaponDamageType] = 0.5;
$DamageScale[SolarPanel, $ThrownPoisonWeaponDamageType] = 0.5;


$DamageScale[PortGenerator, $LandingDamageType] = 1.0;	
$DamageScale[PortGenerator, $ImpactDamageType] = 1.0;
$DamageScale[PortGenerator, $CrushDamageType] = 1.0;
$DamageScale[PortGenerator, $BulletDamageType] = 0.2;
$DamageScale[PortGenerator, $PlasmaDamageType] = 0.2;
$DamageScale[PortGenerator, $EnergyDamageType] = 1.0;
$DamageScale[PortGenerator, $ExplosionDamageType] = 1.0;
$DamageScale[PortGenerator, $MissileDamageType] = 1.0;
$DamageScale[PortGenerator, $DebrisDamageType] = 1.0;
$DamageScale[PortGenerator, $ShrapnelDamageType] = 0.2;
$DamageScale[PortGenerator, $LaserDamageType] = 0.2;	
$DamageScale[PortGenerator, $MortarDamageType] = 1.0;	
$DamageScale[PortGenerator, $BlasterDamageType] = 1.0;	
$DamageScale[PortGenerator, $ElectricityDamageType] = 1.0;
$DamageScale[PortGenerator, $MineDamageType] = 1.0;	
$DamageScale[PortGenerator, $StabDamageType] = 0.1;	
$DamageScale[PortGenerator, $PoisonDamageType] = 0.1;	
$DamageScale[PortGenerator, $StunnerDamageType] = 0.1;	
$DamageScale[PortGenerator, $NukeDamageType] = 1.0;	
$DamageScale[PortGenerator, $Poison2DamageType] = 0.1;	
$DamageScale[PortGenerator, $WormDamageType] = 1.0;	
$DamageScale[PortGenerator, $CutterayDamageType] = 1.5;
$DamageScale[PortGenerator, $SmallLasDamageType] = 0.8;
$DamageScale[PortGenerator, $RifleLasDamageType] = 0.8;
$DamageScale[PortGenerator, $HeavyLasDamageType] = 0.8;
$DamageScale[PortGenerator, $AsphyxiationDamageType] = 0.0;
$DamageScale[PortGenerator, $LargeBulletDamageType] = 0.8;
$DamageScale[PortGenerator, $ThrownWeaponDamageType] = 0.1;
$DamageScale[PortGenerator, $ThrownPoisonWeaponDamageType] = 0.1;


function Generator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
		0.30, 250, 170);
	if(%this.IsHiereg == true)
	{
		$TeamItemCount[GameBase::getTeam(%this)@HieregPack]--;
	} else if(%this.IsDeployable == true)
	{
		$TeamItemCount[GameBase::getTeam(%this)@DeployableGenPack]--;
	}
}

function Generator::onActivate(%this)
{
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
}

function Generator::onDeactivate(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
}

//

StaticShapeData TowerSwitch
{
	description = "Tower Control Switch";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
};

StaticShapeData Generator
{
   description = "Generator";
   shapeFile = "generator";
	className = "Generator";
   sfxAmbient = SoundGeneratorPower;
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
   maxDamage = 2.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

StaticShapeData SolarPanel
{
   description = "Solar Panel";
	shapeFile = "solar_med";
	className = "Generator";
	debrisId = flashDebrisMedium;
	maxDamage = 1.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
    damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};

StaticShapeData PortGenerator
{
   description = "Portable Generator";
   shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
   sfxAmbient = SoundGeneratorPower;
   maxDamage = 1.6;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

StaticShapeData TemperatureRegulator
{
   description = "TemperatureRegulator";
   shapeFile = "generator";
	className = "Generator";
   sfxAmbient = SoundGeneratorPower;
	debrisId = flashDebrisLargeTR;
	explosionId = flashExpLarge;
   maxDamage = 1.0;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

function TemperatureRegulator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
   StaticShape::objectiveDestroyed(%this);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 
	//	0.30, 250, 170);
	%pos1 = vector::Add(gamebase::Getposition(%this),"0 0 2");
	Schedule("GameBase::applyRadiusDamage(\""@$DebrisDamageType@"\", \""@%pos1@"\", 100,10,2000,\""@%this.lastDamageObject@"\");",0.1);


}



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//New
//**********************************************

$DamageScale[BlastWall, $LandingDamageType] = 1.0;	
$DamageScale[BlastWall, $ImpactDamageType] = 1.0;
$DamageScale[BlastWall, $CrushDamageType] = 1.0;
$DamageScale[BlastWall, $BulletDamageType] = 0.01;
$DamageScale[BlastWall, $PlasmaDamageType] = 0.05;
$DamageScale[BlastWall, $EnergyDamageType] = 0.0;
$DamageScale[BlastWall, $ExplosionDamageType] = 1.0;
$DamageScale[BlastWall, $MissileDamageType] = 2.0;
$DamageScale[BlastWall, $DebrisDamageType] = 1.0;
$DamageScale[BlastWall, $ShrapnelDamageType] = 0.01;
$DamageScale[BlastWall, $LaserDamageType] = 0.01;	
$DamageScale[BlastWall, $MortarDamageType] = 2.0;	
$DamageScale[BlastWall, $BlasterDamageType] = 1.0;	
$DamageScale[BlastWall, $ElectricityDamageType] = 0.0;
$DamageScale[BlastWall, $MineDamageType] = 1.0;	
$DamageScale[BlastWall, $StabDamageType] = 0.0;	
$DamageScale[BlastWall, $PoisonDamageType] = 0.0;	
$DamageScale[BlastWall, $StunnerDamageType] = 0.0;	
$DamageScale[BlastWall, $NukeDamageType] = 1.0;	
$DamageScale[BlastWall, $Poison2DamageType] = 0.0;	
$DamageScale[BlastWall, $WormDamageType] = 1.0;	
$DamageScale[BlastWall, $CutterayDamageType] = 3.0;
$DamageScale[BlastWall, $SmallLasDamageType] = 0.5;
$DamageScale[BlastWall, $RifleLasDamageType] = 0.5;
$DamageScale[BlastWall, $HeavyLasDamageType] = 0.5;
$DamageScale[BlastWall, $AsphyxiationDamageType] = 0.0;
$DamageScale[BlastWall, $LargeBulletDamageType] = 0.05;
$DamageScale[BlastWall, $ThrownWeaponDamageType] = 0.0;
$DamageScale[BlastWall, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[DeployableForceField, $LandingDamageType] = 1.0;	
$DamageScale[DeployableForceField, $ImpactDamageType] = 1.0;
$DamageScale[DeployableForceField, $CrushDamageType] = 1.0;
$DamageScale[DeployableForceField, $BulletDamageType] = 0.00;
$DamageScale[DeployableForceField, $PlasmaDamageType] = 0.05;
$DamageScale[DeployableForceField, $EnergyDamageType] = 0.0;
$DamageScale[DeployableForceField, $ExplosionDamageType] = 2.0;
$DamageScale[DeployableForceField, $MissileDamageType] = 1.0;
$DamageScale[DeployableForceField, $DebrisDamageType] = 0.0;
$DamageScale[DeployableForceField, $ShrapnelDamageType] = 0.0;
$DamageScale[DeployableForceField, $LaserDamageType] = 1.00;	
$DamageScale[DeployableForceField, $MortarDamageType] = 1.0;	
$DamageScale[DeployableForceField, $BlasterDamageType] = 0.0;	
$DamageScale[DeployableForceField, $ElectricityDamageType] = 0.0;
$DamageScale[DeployableForceField, $MineDamageType] = 0.0;	
$DamageScale[DeployableForceField, $StabDamageType] = 0.0;	
$DamageScale[DeployableForceField, $PoisonDamageType] = 0.0;	
$DamageScale[DeployableForceField, $StunnerDamageType] = 0.0;	
$DamageScale[DeployableForceField, $NukeDamageType] = 1.0;	
$DamageScale[DeployableForceField, $Poison2DamageType] = 0.0;	
$DamageScale[DeployableForceField, $WormDamageType] = 1.0;	
$DamageScale[DeployableForceField, $CutterayDamageType] = 1.0;
$DamageScale[DeployableForceField, $SmallLasDamageType] = 1.0;
$DamageScale[DeployableForceField, $RifleLasDamageType] = 1.0;
$DamageScale[DeployableForceField, $HeavyLasDamageType] = 1.0;
$DamageScale[DeployableForceField, $AsphyxiationDamageType] = 0.0;
$DamageScale[DeployableForceField, $LargeBulletDamageType] = 0.0;
$DamageScale[DeployableForceField, $ThrownWeaponDamageType] = 0.0;
$DamageScale[DeployableForceField, $ThrownPoisonWeaponDamageType] = 0.0;

$DamageScale[LargeForceField, $LandingDamageType] = 1.0;	
$DamageScale[LargeForceField, $ImpactDamageType] = 1.0;
$DamageScale[LargeForceField, $CrushDamageType] = 1.0;
$DamageScale[LargeForceField, $BulletDamageType] = 0.00;
$DamageScale[LargeForceField, $PlasmaDamageType] = 0.05;
$DamageScale[LargeForceField, $EnergyDamageType] = 0.0;
$DamageScale[LargeForceField, $ExplosionDamageType] = 2.0;
$DamageScale[LargeForceField, $MissileDamageType] = 1.0;
$DamageScale[LargeForceField, $DebrisDamageType] = 0.0;
$DamageScale[LargeForceField, $ShrapnelDamageType] = 0.0;
$DamageScale[LargeForceField, $LaserDamageType] = 1.00;	
$DamageScale[LargeForceField, $MortarDamageType] = 1.0;	
$DamageScale[LargeForceField, $BlasterDamageType] = 0.0;	
$DamageScale[LargeForceField, $ElectricityDamageType] = 0.0;
$DamageScale[LargeForceField, $MineDamageType] = 0.0;	
$DamageScale[LargeForceField, $StabDamageType] = 0.0;	
$DamageScale[LargeForceField, $PoisonDamageType] = 0.0;	
$DamageScale[LargeForceField, $StunnerDamageType] = 0.0;	
$DamageScale[LargeForceField, $NukeDamageType] = 1.0;	
$DamageScale[LargeForceField, $Poison2DamageType] = 0.0;	
$DamageScale[LargeForceField, $WormDamageType] = 1.0;	
$DamageScale[LargeForceField, $CutterayDamageType] = 1.0;
$DamageScale[LargeForceField, $SmallLasDamageType] = 1.0;
$DamageScale[LargeForceField, $RifleLasDamageType] = 1.0;
$DamageScale[LargeForceField, $HeavyLasDamageType] = 1.0;
$DamageScale[LargeForceField, $AsphyxiationDamageType] = 0.0;
$DamageScale[LargeForceField, $LargeBulletDamageType] = 0.0;
$DamageScale[LargeForceField, $ThrownWeaponDamageType] = 0.0;
$DamageScale[LargeForceField, $ThrownPoisonWeaponDamageType] = 0.0;




StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 6.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Plasteel BlastWall";
	damageSkinData = "objectDamageSkins";
};

function BlastWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "PlasteelPack"]--;	
}

// Deployable Forcefield 

StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 2.1;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Small Pentashield";
};


// Can only kill the shield (with damage to the shield) by overloading. (laser will cause nuke, and nuke will overload it)
function DeployableForceField::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//*** Depreciated. Except for the turrets. I stuck the type conversions in the "Weapon::onfire"
	if(%type == $LaserDamageType) {
		if(getobjecttype(%object) == SimManager){
			%type = $SmallLasDamageType;
		} else if(GameBase::getDataName(Client::getControlObject(%object) ) == StationaryLasgun){
			%type = $HeavyLasDamageType;
			%DLT = true;
		} else {
			%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		}
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
			%value = 0;
	}
	//***

	//-Laser Range Damage Multiplier Dont do with normal $laserdamagetype because sniper rifles use that.
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		if(%DLT)
			%weap = DLT; 
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		//echo(%Dist@" ::: "@%value);
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			//echo("Spill: "@%DistSpillover);
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			//echo("Rate: "@%rate);
			//echo("Old: "@%value);
			%value -= %rate;
			//echo("New: "@%value);
		}
		//-Jes, its up to you whether you want insta-kills at point blank with a laser
		//if(%Dist <= 1.75) //- Instant kill at point blank if its a laser
		//	%value = 1.5;
		if(%value <= 0.00005)
			%value = 0;
	}
	//if($damageScale[GameBase::getDataName(%this), %type])
		%value *= $damageScale[GameBase::getDataName(%this), %type];	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}
	if(%type == $CrushDamageType || (%value >= GameBase::getDataName(%this).maxdamage && (%type == $ImpactDamageType || %type == $LandingDamageType || %type == $ExplosionDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MineDamageType || %type == $WormDamageType || %type == $NukeDamageType))) {//
		%dvalue = GameBase::getDataName(%this).maxDamage +0.1; //let damage go through
		%value = GameBase::getDataName(%this).maxDamage +0.1; //let damage go through
	}
	if(%value > 0.0 && (%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) ) { //  if its a lasgun no matter what,
		if(getobjecttype(%object) != SimManager) {
			%damagedClient = Player::getClient(%this);
			%shooterClient = %object;
			//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%damagedclient);
			//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");	
			//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%shooterclient);
			//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");
			//$NukeKiller[gamebase::getcontrolclient(%this),
			//NuclearExplosion( Client::getOwnedObject(%shooterclient), 1);
			NuclearExplosion( %shooterclient, 1);
			Player::unMountItem(%shooterclient,$WeaponSlot);
			schedule("NuclearExplosion("@%this@", 1);",0.05);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(Client::getOwnedObject(%shooterclient)),"0 0 3"), 50, 50, 30, Client::getOwnedObject(%shooterclient));
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(%this),"0 0 3"), 50, 50, 30, %this);
			NukeCaused(player::getclient(%object));
		} else {
			if( !$turretNukeTime || $turretnuketime + 0.5 < getsimtime() ) {
					NuclearExplosion(%this, 1);
				//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
				//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
				$turretnukeTime = getsimtime();
			}
		}
	}
	if(%value > GameBase::getDataName(%this).maxdamage)
		GameBase::setDamageLevel(%this,%dValue);
}

function DeployableForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	if(%this.isactive==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ($FaceDancerIsSwitched[%clientId] && Gamebase::getTeam(%this) == %clientId.ImpersonatingWhoTeam))
	{	
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		DeployableForceField::Open(%this);
		return;
	}
	//echo ("Wrong Team");
	return;
}
function DeployableForceField::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",4);
		%pos=GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));
	
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
		gamebase::setposition(%this, %newpos);
		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
	}
}


function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   //Kill the shield gen
   GameBase::setDamageLevel($ShieldGen[%this], GameBase::getDataName($ShieldGen[%this]).maxDamage+0.1);
   $TeamItemCount[GameBase::getTeam(%this) @ "SPentashieldPack"]--;
	
}

//============================================================================ Large Force Field
StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 2.1;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Large Pentashield";
};

// Can only kill the shield (with damage to the shield) by overloading. (laser will cause nuke, and nuke will overload it)
function LargeForceField::ondamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//*** Depreciated. Except for the turrets. I stuck the type conversions in the "Weapon::onfire"
	if(%type == $LaserDamageType) {
		if(getobjecttype(%object) == SimManager){
			%type = $SmallLasDamageType;
		} else if(GameBase::getDataName(Client::getControlObject(%object) ) == StationaryLasgun){
			%type = $HeavyLasDamageType;
			%DLT = true;
		} else {
			%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		}
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
			%value = 0;
	}
	//***

	//-Laser Range Damage Multiplier Dont do with normal $laserdamagetype because sniper rifles use that.
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		if(%DLT)
			%weap = DLT; 
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		//echo(%Dist@" ::: "@%value);
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			//echo("Spill: "@%DistSpillover);
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			//echo("Rate: "@%rate);
			//echo("Old: "@%value);
			%value -= %rate;
			//echo("New: "@%value);
		}
		//-Jes, its up to you whether you want insta-kills at point blank with a laser
		//if(%Dist <= 1.75) //- Instant kill at point blank if its a laser
		//	%value = 1.5;
		if(%value <= 0.00005)
			%value = 0;
	}
	//if($damageScale[GameBase::getDataName(%this), %type])
		%value *= $damageScale[GameBase::getDataName(%this), %type];	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		if(%name.className == Generator || %name.className == Station) { 
			%TDS = $Server::TeamDamageScale;
			%dValue = %damageLevel + %value * %TDS;
			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05) {
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}
	if(%type == $CrushDamageType || (%value >= GameBase::getDataName(%this).maxdamage && (%type == $ImpactDamageType || %type == $LandingDamageType || %type == $ExplosionDamageType || %type == $MortarDamageType || %type == $MissileDamageType || %type == $MineDamageType || %type == $WormDamageType || %type == $NukeDamageType))) {//
		%dvalue = GameBase::getDataName(%this).maxDamage +0.1; //let damage go through
		%value = GameBase::getDataName(%this).maxDamage +0.1; //let damage go through
	}
	if(%value > 0.0 && (%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType) ) { //  if its a lasgun no matter what,
		if(getobjecttype(%object) != SimManager) {
			%damagedClient = Player::getClient(%this);
			%shooterClient = %object;
			//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%damagedclient);
			//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");	
			//%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%shooterclient);
			//Projectile::spawnProjectile(SNukeShell, %transform, %shooterclient, "0 0 0");
			//$NukeKiller[gamebase::getcontrolclient(%this),
			NuclearExplosion( %shooterclient, 1);
			Player::unMountItem(%shooterclient,$WeaponSlot);
			schedule("NuclearExplosion("@%this@", 1);",0.05);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(Client::getOwnedObject(%shooterclient)),"0 0 3"), 50, 50, 30, Client::getOwnedObject(%shooterclient));
			//GameBase::applyRadiusDamage(17, vector::add(GameBase::getPosition(%this),"0 0 3"), 50, 50, 30, %this);
			NukeCaused(player::getclient(%object));
		} else {
			if( !$turretNukeTime || $turretnuketime + 0.5 < getsimtime() ) {
					NuclearExplosion(%this, 1);
				//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
				//schedule("GameBase::applyRadiusDamage(3, " @ %pos @ ", 5, 1, 30, " @ %object @ ");", 0.1);
				$turretnukeTime = getsimtime();
			}
		}
	}
	if(%value > GameBase::getDataName(%this).maxdamage)
		GameBase::setDamageLevel(%this,%dValue);
}



function LargeForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ($FaceDancerIsSwitched[%clientId] && Gamebase::getTeam(%this) == %clientId.ImpersonatingWhoTeam))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		LargeForceField::Open(%this);
		return;
	}
	//echo ("Wrong Team");
	return;
}

function LargeForceField::Open(%this)
{
	if(%this.isactive == "false")
	{
		GameBase::startfadeout(%this);
		%this.isactive=true;
		schedule("LargeForceField::Open("@%this@");",3);
		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ + %height));

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
		gamebase::setposition(%this, %newpos);		
	}
	else
	{
		%this.isactive = "false";
		%pos=GameBase::getPosition(%this);
		
		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));
	
		gamebase::setposition(%this, %newpos);
	
		GameBase::setPosition(%this,%pos);
		GameBase::startfadein(%this);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   //Kill the shield gen
   GameBase::setDamageLevel($ShieldGen[%this], GameBase::getDataName($ShieldGen[%this]).maxDamage+0.1);
   $TeamItemCount[GameBase::getTeam(%this) @ "LPentashieldPack"]--;	
}


StaticShapeData LargeAirBasePlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1500.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Base";
};


//==================================================================================

StaticShapeData Thumper
{
	shapeFile = "grenadel";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = false;        
   description = "Thumper";
};

function Thumper::soundThumper(%this)
{
	if(%this && %this != "" && %this > 1)
	{
		GameBase::playSound(%this,ThumperSound,3);
		schedule("Thumper::soundThumper("@%this@");",1,%this);
	}
}

function Thumper::onDestroyed(%this)
{
	Worm::RemoveFromTargetQueue(%this);
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ThumperPack"]--;
	
}

//------------------------------------------------------------------------
StaticShapeData SmallAntenna
{
	shapeFile = "anten_small";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Small Antenna";
};

//------------------------------------------------------------------------
StaticShapeData MediumAntenna
{
	shapeFile = "anten_med";
	debrisId = flashDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Medium Antenna";
};

//------------------------------------------------------------------------
StaticShapeData LargeAntenna
{
	shapeFile = "anten_lrg";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Large Antenna";
};

//------------------------------------------------------------------------
StaticShapeData ArrayAntenna
{
	shapeFile = "anten_lava";
	debrisId = flashDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Array Antenna";
};

//------------------------------------------------------------------------
StaticShapeData RodAntenna
{
	shapeFile = "anten_rod";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Rod Antenna";
};

//------------------------------------------------------------------------
StaticShapeData ForceBeacon
{
	shapeFile = "force";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Force Beacon";
};

//------------------------------------------------------------------------
StaticShapeData CargoCrate
{
	shapeFile = "magcargo";
	debrisId = flashDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
   description = "Cargo Crate";
};

//------------------------------------------------------------------------
StaticShapeData CargoBarrel
{
	shapeFile = "liqcyl";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "Cargo Barrel";
};

//------------------------------------------------------------------------
StaticShapeData SquarePanel
{
	shapeFile = "teleport_square";
	debrisId = flashDebrisSmall;
	maxDamage = 0.3;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VerticalPanel
{
	shapeFile = "teleport_vertical";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData BluePanel
{
	shapeFile = "panel_blue";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData YellowPanel
{
	shapeFile = "panel_yellow";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData SetPanel
{
	shapeFile = "panel_set";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VerticalPanelB
{
	shapeFile = "panel_vertical";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelOne
{
	shapeFile = "display_one";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelTwo
{
	shapeFile = "display_two";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData DisplayPanelThree
{
	shapeFile = "display_three";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData HOnePanel
{
	shapeFile = "dsply_h1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData HTwoPanel
{
	shapeFile = "dsply_h2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData SOnePanel
{
	shapeFile = "dsply_s1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData STwoPanel
{
	shapeFile = "dsply_s2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VOnePanel
{
	shapeFile = "dsply_v1";
	debrisId = defaultDebrisSmall;
	explosionId = debrisExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData VTwoPanel
{
	shapeFile = "dsply_v2";
	debrisId = flashDebrisSmall;
	explosionId = flashExpMedium;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
   description = "Panel";
};

//------------------------------------------------------------------------
StaticShapeData ForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   description = "Force Field";
};

//------------------------------------------------------------------------
StaticShapeData ElectricalBeam
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

StaticShapeData ElectricalBeamBig
{
	shapeFile = "zap_5";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

StaticShapeData PoweredElectricalBeam
{
	shapeFile = "zap";
	maxDamage = 10000.0;
	isTranslucent = true;
    description = "Electrical Beam";
   disableCollision = true;
};

//function to fade in electrical beam based on base power.
function PoweredElectricalBeam::onPower(%this, %power, %generator)
{
   if(%power)
	  GameBase::startFadeIn(%this);
   else
      GameBase::startFadeOut(%this);
}
      
//-----------------------------------------------------------------------
StaticShapeData Cactus1
{
	shapeFile = "cactus1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
//------------------------------------------------------------------------
StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};
//------------------------------------------------------------------------
StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Cactus";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnGrass
{
	shapeFile = "steamvent_grass";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnMud
{
	shapeFile = "steamvent_mud";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};

//------------------------------------------------------------------------
StaticShapeData TreeShape
{
	shapeFile = "tree1";
	maxDamage = 10.0;
	isTranslucent = "True";
   description = "Tree";
};

//------------------------------------------------------------------------
StaticShapeData TreeShapeTwo
{
	shapeFile = "tree2";
	maxDamage = 10.0;
	isTranslucent = "True";
   description = "Tree";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnGrass2
{
	shapeFile = "steamvent2_grass";
	maxDamage = 999.0;
	isTranslucent = "True";
};

//------------------------------------------------------------------------
StaticShapeData SteamOnMud2
{
	shapeFile = "steamvent2_mud";
	maxDamage = 999.0;
	isTranslucent = "True";
   description = "Steam Vent";
};
//------------------------------------------------------------------------
StaticShapeData PlantOne
{
	shapeFile = "plant1";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Plant";
};

//------------------------------------------------------------------------
StaticShapeData PlantTwo
{
	shapeFile = "plant2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
   description = "Plant";
};



StaticShapeData Corpse
{
	shapeFile = "larmor";
	maxDamage = 10000.0;
	isTranslucent = false;
	description = "Duke Leto";
	disableCollision = false;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
};


StaticShapeData PalaceShieldGenerator
{
	shapeFile = "generator";
	maxDamage = 10000.0;
	isTranslucent = false;
	description = "Palace Shield Generator";
	disableCollision = false;
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
};



DebrisData caveDebris
{
   type      = 0;
   imageType = 0;
   
   mass       = 100.0;
   elasticity = 0.1;
   friction   = 0.5;
   center     = { 0, 0, 0 };

   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;

   animationSequence = -1;

   minTimeout = 3.0;
   maxTimeout = 6.0;

   explodeOnBounce = 0.5;

   damage          = 1000.0;
   damageThreshold = 100.0;

   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 90;
   spawnedDebrisRadius   = 0.5;

   spawnedExplosionID = flashExpLarge;

   p = 1;

   explodeOnRest   = True;
   collisionDetail = 0;
};

StaticShapeData CaveEnterence
{
	shapeFile = "breath";
	maxDamage = 300.0;
	debrisId = caveDebris;
	isTranslucent = false;
	description = "Cave Enterence";
	disableCollision = false;
	visibleToSensor = false;
	mapFilter = 4;
};


function CaveEnterence::onDestroyed(%this)
{
	if($CaveDead[%this.cave] != true)
	{
		$CaveDead[%this.cave] = true;
		StaticShape::onDestroyed(%this);

		// Award points.
		%playerClient = GameBase::getControlClient(%this.lastDamageObject);
       		if(%playerClient != -1)
	        {
			%playerClient.score+=5;
			Game::refreshClientScore(%playerClient);
	      		MessageAllExcept(%playerClient, 0, %clientName @ " destroyed an objective!");
	      		Client::sendMessage(%playerClient, 0, "You destroyed an objective!");
	        }
	        MessageAll(1, getTeamName(%thisTeam) @ " objective Cave Enterence " @ %this.cave @ " destroyed.");
		$TeamScore[1] = $teamScore[1] + $TeamScoreLimit/3;
		ObjectiveMission::checkScoreLimit();

		// Remove spawnpoints
		%dropPoints = nameToID("MissionGroup/Teams/Team0/MoveBlocks/Cave"@%this.cave@"/DropPoints");
   		%oldDropSet = nameToID("MissionCleanup/TeamDrops0");
		if(%dropPoints != -1)
   		{
      			for(%i = 0; (%dropPoint = Group::getObject(%dropPoints, %i)) != -1; %i++)
      			{
        			if(%oldDropSet != -1)
            				removeFromSet(%oldDropSet, %dropPoint);
         		}
   		}
			
		// Move Blocks
		CaveEnterence::Collapse(%this.cave);
		
	}	
}


function CaveEnterence::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{	

	%value = %value * $damageScale[GameBase::getDataName(%this), %type];
	%this.lastDamageObject = %object;

	GameBase::setDamageLevel(%this, Gamebase::getDamageLevel(%this) + %value);

	%group = GetGroup(%this);
	for(%i = 0; (%hitPoint = Group::getObject(%group, %i)) != -1; %i++)
	{
   		GameBase::setDamageLevel(%hitPoint, Gamebase::getDamageLevel(%this));
	}
}

$DamageScale[CaveEnterence, $LandingDamageType] = 1.0;	
$DamageScale[CaveEnterence, $ImpactDamageType] = 1.0;
$DamageScale[CaveEnterence, $CrushDamageType] = 1.0;
$DamageScale[CaveEnterence, $ExplosionDamageType] = 1.0;
$DamageScale[CaveEnterence, $MissileDamageType] = 0.001;
$DamageScale[CaveEnterence, $MortarDamageType] = 1.0;	
$DamageScale[CaveEnterence, $CutterayDamageType] = 0.01;
$DamageScale[CaveEnterence, $SmallLasDamageType] = 0.01;
$DamageScale[CaveEnterence, $RifleLasDamageType] = 0.01;
$DamageScale[CaveEnterence, $HeavyLasDamageType] = 0.01;

$CaveEnterence:RockPosJump = 0.1;
$CaveEnterence:RockRotJump = 0.1;

function CaveEnterence::Collapse(%caveNum)
{
	%doneMoving = true;
	
	// Move and rotate each block a little towards it's goal
	%moveFrom = nameToID("MissionGroup/Teams/Team0/MoveBlocks/Cave"@%caveNum@"/MoveFrom");
	%moveTo = nameToID("MissionGroup/Teams/Team0/MoveBlocks/Cave"@%caveNum@"/MoveTo");
	if(%moveFrom != -1)
   	{
      		for(%i = 0; (%rock = Group::getObject(%MoveFrom, %i)) != -1; %i++)
      		{
			%to = CaveEnterence::FindToPosition(%moveTo,%rock.name);

			
			%trans = "0 0 0 0 0 0 0 0 0 "@gamebase::Getposition(%to);
			if(getRandom() > 0.9)
			{
				// RockSlide2
				schedule ("Projectile::spawnProjectile(RockSlide2, \"" @ %trans @ "\", \"" @ 2048 @ "\", \"" @ "0 0 0" @ "\");",getrandom()*0.5);
				
			} else if(getRandom() > 0.9)
			{
				// RockSlide
				schedule ("Projectile::spawnProjectile(RockSlide, \"" @ %trans @ "\", \"" @ 2048 @ "\", \"" @ "0 0 0" @ "\");",getrandom()*0.5);
			}

			%posdist = vector::getdistance(gamebase::Getposition(%rock),gamebase::Getposition(%to));
			%rotdist = vector::getdistance(gamebase::Getrotation(%rock),gamebase::GetRotation(%to));

			if(%to != 0 && ((%posdist > 2*$CaveEnterence:RockPosJump || %posdist < -2*$CaveEnterence:RockPosJump) 
				|| (%rotdist > 2*$CaveEnterence:RockRotJump || %rotdist < -2*$CaveEnterence:RockRotJump)))
			{
				%curPosition = vector::Add(vector::getFromRot(vector::getrotaim(gamebase::Getposition(%rock),Gamebase::getPosition(%to)),$CaveEnterence:RockPosJump),gamebase::Getposition(%rock));
				gamebase::setposition(%rock,%curPosition);
				%curRotation = Vector::Add(vector::getFromRot(vector::getrotaim(gamebase::GetRotation(%rock),Gamebase::getRotation(%to)),$CaveEnterence:RockRotJump),gamebase::GetRotation(%rock));
				gamebase::setRotation(%rock,%curRotation);
				%doneMoving = false;
			}
		
		}
   	}
	if(!%doneMoving)
		schedule("CaveEnterence::Collapse("@%caveNum@");",0.01);
}

function CaveEnterence::FindToPosition(%group,%name)
{
	for(%i = 0; (%pos = Group::getObject(%group, %i)) != -1; %i++)
	{
		if(String::Compare(object::Getname(%pos),%name) == 0)
		{
			return %pos;
		}
	}
	return 0;
}


function CE::pos(%num)
{
	%group = nameToID("MissionGroup/Teams/Team0/MoveBlocks/Cave"@%Num@"/MoveFrom");
	for(%i = 0; (%pos = Group::getObject(%group, %i)) != -1; %i++)
	{
echo(%pos @ " :: " @ object::Getname(%pos) @ " :: "@ gamebase::getposition(%pos));
	}
}

function move()
{
	gamebase::setposition($Obj,vector::add(gamebase::Getposition($obj),$mv));
}

ExplosionData RockSlideExp
{
	shapeName = "dustplume.dts";
	//soundId   = turretExplosion; //if were desparate
	//soundId   = rocketExplosion;
	soundId   = ShellExplosion;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.500;
	timeOne  = 1.000;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

//----------------------------------------------------------------------------


GrenadeData RockSlide
{
	bulletShapeName    = "dustplume.dts";
	explosionTag       = RockSlideExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 5.0;
	damageType         = $CrushDamageType;

	explosionRadius    = 10.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0.1;
	totalTime          = 1.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.1;

	inheritedVelocityScale = 1.0;
	smokeName              = "dustplume.dts";
};

//----------------------------------------------------------------------------


GrenadeData RockSlide2
{
	bulletShapeName    = "flash_large.dts";
	explosionTag       = flashExpLarge;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 5.0;
	damageType         = $CrushDamageType;

	explosionRadius    = 10.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0.1;
	totalTime          = 1.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.1;

	inheritedVelocityScale = 1.0;
	smokeName              = "flash_large.dts";
};
