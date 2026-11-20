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
	if (GameBase::isPowered(%this) || %this.poweron == true)
	{ 
		GameBase::playSequence(%this,0,"power");
		GameBase::setRechargeRate(%this,10);
	}
}

function StaticShape::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);
}

function StaticShape::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::setRechargeRate(%this,0);

	if (getObjectType(%this.lastDamageObject) != "Player")
	{
		return;
	}
	
	if ($debug) echo ("StaticShape::objectiveDestroyed = StaticShape.cs 1");
   	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
}

function StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $DeSupressDamageType)
		return;

	if(%type == $DeCloakDamageType)
	{
		if(GameBase::getTeam(%this) != GameBase::getTeam(%object))
		{
			if($cloakTime[%this] != 0)
				$cloakTime[%this] = 0;
			GameBase::startFadeIn(%this);
		}
		return;
	}

	if(%type == $CloakDamageType)
	{
		if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		{
			Shifter_startCloak(%this);
			$cloakTime[%this] = 90;
//			GameBase::startFadeOut(%this);
		}
		else
		{
			if($cloakTime[%this] != 0)
				$cloakTime[%this] = 0;
			GameBase::startFadeIn(%this);
		}
		return;
	}

	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
   	
   	if (%object != "0" && %object != -1)
   	{
   		if (gamebase::getownerclient(%object) != "-1")
   			%this.lastDamageObject = client::getownedobject(gamebase::getownerclient(%object));
		else   	
   			%this.lastDamageObject = %object;
   	}


	//=== Some special conditions for Chemeleon Infiltrate
	//If the player is infiltrating use their Original Team value, not their current one
	if($InfTime[Player::getClient(%this.lastDamageObject)] > 0)
		%this.lastDamageTeam = Player::getClient(%this.lastDamageObject).OrigTeam;
	//Otherwise, proceed as normal
	else
	   	%this.lastDamageTeam = GameBase::getTeam(%this.lastDamageObject);
	
	%name = GameBase::getDataName(%this);

	//=== For a number of reasons, Generators cannot be damaged by nukes
	if(%name.className == Generator && %type == $NukeDamageType)
		return;

	if(GameBase::getTeam(%this) == %this.lastDamageTeam && %name != DeployableSatchel && %name != DeployableInvStation) //== GameBase::getTeam(%object)
	{
		%TDS = $Server::TeamDamageScale;
		%value *= %TDS;
		%dValue = %damageLevel + %value;
//		%dValue = %damageLevel + %value * %TDS;
		if(%name.className == Generator || %name.className == Station)
		{
			if($Shifter::Hunters)
				return;

			%disable = GameBase::getDisabledDamage(%this);
			if(!$Server::TourneyMode && %dValue > %disable - 0.05)
			{
				if(%damageLevel > %disable - 0.05)
					return;
				else
					%dValue = %disable - 0.05;
			}
		}
	}

	if(%this.shieldstrength > 0 && GameBase::getEnergy(%this) > 0 && %value > 0 && (GameBase::isPowered(%this) || %this.poweron == true || %name.className == Generator) && GameBase::getDamageLevel(%this) < GameBase::getDisabledDamage(%this))
	{
		StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
	else
	{
		GameBase::setDamageLevel(%this,%dValue);
	}
}

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%this.lastDamageObject = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);

	
	if (%this.shieldStrength && %type != $DeCloakDamageType && %type != $CloakDamageType)
	{
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;

		//=== Anti-Air turrets are resistant to damage done by players piloting vehicles
		if(%object.driver != "" && GameBase::getDataName(%this) == "BarrageTurret")
			%strength *= 2.0;

		if (%type == $ShrapnelDamageType || %type == $NukeDamageType)
			%strength *= 0.5;
		else if (%type == $MortarDamageType)
			%strength *= 0.25;
		else if (%type == $BlasterDamageType)
			%strength *= 2.0;
		//=== Interceptor modules do less damage against shielded objects
		else if (%type == $IDamageType)
			%strength *= 2.0;
		else if (%type == $ElectricityDamageType)
			%strength *= 0.75;
			
		%absorb = %energy * %strength;

		if (%value < %absorb)
		{
			GameBase::setEnergy(%this,%energy - (%value / %strength));
			%centerPos = getBoxCenter(%this);
			%sphereVec = findPointOnSphere(getBoxCenter(%object),%centerPos,%vec,%this);
			%centerPosX = getWord(%centerPos,0);
			%centerPosY = getWord(%centerPos,1);
			%centerPosZ = getWord(%centerPos,2);

			%pointX = getWord(%pos,0);
			%pointY = getWord(%pos,1);
			%pointZ = getWord(%pos,2);

			%newVecX = %centerPosX - %pointX;
			%newVecY = %centerPosY - %pointY;
			%newVecZ = %centerPosZ - %pointZ;
			%norm = Vector::normalize(%newVecX @ " " @ %newVecY @ " " @ %newVecZ);
			%zOffset = 0;

			if(GameBase::getDataName(%this) == PulseSensor)
				%zOffset = (%pointZ-%centerPosZ) * 0.5;
			
			GameBase::activateShield(%this,%sphereVec,%zOffset);
		}
		else
		{
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else
	{
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) 
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

StaticShapeData FlagStand
{
	description = "Flag Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};


function FlagStand::onDamage()
{
}

//------------------------------------------------------------------------
// Generators
//------------------------------------------------------------------------

function Generator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
	GameBase::setRechargeRate(%this,10);
}

function Generator::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
	GameBase::setRechargeRate(%this,0);
}

function Generator::onDestroyed(%this)
{
	Generator::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	if(%this.deployed)
	{
		$portagen[GameBase::getTeam(%this)] = false;
		%this.deployed = false;
	}
	CheckNetwork(%this);
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
	maxEnergy = 140;
	shieldShapeName = "shield_medium";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

StaticShapeData SolarBig
{
    	description = "SolarBig";
    	shapeFile = "solar";
	className = "Generator";
    	sfxAmbient = SoundGeneratorPower;
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
    	maxDamage = 5.0;
	maxEnergy = 110;
	shieldShapeName = "shield_medium";
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
	maxEnergy = 100;
	shieldShapeName = "shield";
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
	maxEnergy = 120;
	shieldShapeName = "shield";
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

StaticShapeData EmplacementGenerator
{
   	description = "Portable Generator";
   	shapeFile = "generator_p";
	className = "Generator";
	debrisId = flashDebrisSmall;
   	sfxAmbient = SoundGeneratorPower;
   	maxDamage = 1.6;
	maxEnergy = 120;
	shieldShapeName = "shield";
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
};

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
	maxDamage = 0.9;
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

//------------------------------------------------------------------------ Force Field Walls
StaticShapeData ForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField1
{
	shapeFile = "ForceField_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField2
{
	shapeFile = "ForceField_4x17";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField3
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField4
{
	shapeFile = "ForceField_5x5";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};
StaticShapeData ForceField5
{
	shapeFile = "ForceField_4x14";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Force Field";
};

StaticShapeData PlasmaWall
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Plasma Wall";
};

//========================================================================= Misc Not In Base
StaticShapeData Enerpad
{
	shapeFile = "enerpad";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Telepad";
};

StaticShapeData Mainpad
{
	shapeFile = "mainpad";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "MainPad";
};

StaticShapeData TribesLogo
{
	shapeFile = "logo";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "logo";
};

StaticShapeData Bridge
{
	shapeFile = "bridge";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Bridge";
};

StaticShapeData GunTuret
{
	shapeFile = "GunTuret";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "Gun Turret";
};

StaticShapeData SatBig
{
	shapeFile = "sat_big";
	debrisId = defaultDebrisSmall;
	maxDamage = 10000.0;
	isTranslucent = true;
   	description = "SatBig";
};

//------------------------------------------------------------------------ Beams
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

function Cactus1::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(GameBase::getDamageLevel(%obj)) 
	{
		Gamebase::setDamageLevel(%obj,0);
		$emptime[%c] = 0;
		$poisontime[%c] = 0;
		$burntime[%c] = 0;
		Item::giveItem(%obj,Repairkit,1);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}
//------------------------------------------------------------------------
StaticShapeData Cactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
	description = "Cactus";
};

function Cactus2::onCollision(%this,%obj)
{
	Cactus1::onCollision(%this,%obj);
}
//------------------------------------------------------------------------
StaticShapeData Cactus3
{
	shapeFile = "cactus3";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.4;
	description = "Cactus";
};

function Cactus3::onCollision(%this,%obj)
{
	Cactus1::onCollision(%this,%obj);
}

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
//============================================================================ Small Force Field
// Deployable Forcefield 

StaticShapeData DeployableForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 5.50;
	visibleToSensor = true;
	isTranslucent = true;
   	description = "Small Force Field";
};

function DeployableForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.isactive==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ( (%armor == "spyarmor") || (%armor == "spyfemale") ) )
	{	
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		ForceField::Open(%this);
		return;
	}
	return;
}

function DeployableForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--;
	
}

//============================================================================ Large Force Field
StaticShapeData LargeForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    description = "Large Force Field";
};

function LargeForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this) || ((%armor == "spyarmor" || %armor == "spyfemale")) )
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		ForceField::Open(%this);
		return;
	}
	echo ("Wrong Team");
	return;
}

function LargeForceField::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--;	
}

//============================================================================ Large Shock Force Field
StaticShapeData LargeShockForceField
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    	description = "Large Shock Force Field";
};

function LargeShockForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		ForceField::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if(Gamebase::getTeam(%this.deployr) != Gamebase::getTeam(%clientId) && $Shifter::TurretKill != "false" && %this.deployr)
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployr);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	if ($debug) echo ("Wrong Team");
	return;
}

function LargeShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeShockForceFieldPack"]--;	
}

//============================================================================ Small Shock Force Field
StaticShapeData ShockForceField
{
	shapeFile = "forcefield_3x4";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
    	description = "Small Shock Force Field";
};

function ShockForceField::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		ForceField::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if(Gamebase::getTeam(%this.deployr) != Gamebase::getTeam(%clientId) && $Shifter::TurretKill != "false" && %this.deployr)
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployr);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	if($debug) echo ("Wrong Team");
	return;
}

function ShockForceField::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockForceFieldPack"]--;	
}
//============================================================================ Shock Floor ForceField
// Created by Mark Williamson for his customized Shifter servers
// contact mark@webpit.com (Customized by Emo1313 to Open by Teammates)
StaticShapeData ShockFloor
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisLarge;
	maxDamage = 8.00;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Shock Floor";
};

function ShockFloor::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj))
	{
		return;
	}

	if (GameBase::getTeam(%clientId) == Gamebase::getTeam(%this))
	{		
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		Forcefield::Open(%this);
		return;
	}
	else
	{
		schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %obj @ "));",0.1);
		if(Gamebase::getTeam(%this.deployr) != Gamebase::getTeam(%clientId) && $Shifter::TurretKill != "false" && %this.deployr)
		{
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this.deployr);
		}
		else
			GameBase::applyDamage(%player,$FlashDamageType,0.30,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	return;
}

function ShockFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockFloorPack"]--;	
}
//============================================================================ Open function
function ForceField::Open(%this)
{
		if(%this.activated)
			return;

		%pos=GameBase::getPosition(%this);

		%posX = getWord(%pos,0);
		%posY = getWord(%pos,1);
		%posZ = getWord(%pos,2);
		
		%height = 5000;
		%newpos = (%posX @ " " @ %posY @ " " @ (%posZ - %height));

		%this.activated = true;

		schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
		schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",2.8);
		schedule(%this@".activated = false;",2.8);
		GameBase::playSound(%this,ForceFieldOpen,0);
		gamebase::setposition(%this, %newpos);		
}

//============================================================================ Blast Wall
StaticShapeData BlastWall
{
	shapeFile = "newdoor5";
	maxDamage = 12.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Blast Wall";
	damageSkinData = "objectDamageSkins";
};

function BlastWall::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;	
}

//============================================================================ Blast Floor
StaticShapeData BlastFloor
{
	shapeFile = "elevator_8x8";
	maxDamage = 12.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Blast Floor";
	damageSkinData = "objectDamageSkins";
};

function BlastFloor::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastFloorPack"]--;	
}

//============================================================================ Blast Wall2
StaticShapeData BlastWall2
{
	shapeFile = "teleport_vertical";
	maxDamage = 10.0;
	debrisId = defaultDebrisLarge;
	explosionId = debrisExpLarge;
	description = "Blast Wall";
};
function BlastWall2::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "BlastWallPack"]--;
}

//============================================================================ Deployable Platform

StaticShapeData DeployablePlatform
{
	shapeFile = "elevator_4x4";
	debrisId = defaultDebrisSmall;
	maxDamage = 9.25; //4.00;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Deployable Platform";
	damageSkinData = "objectDamageSkins";
};

function DeployablePlatform::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
	
}

//============================================================================ Tree 1

StaticShapeData DeployableTree
{
	shapeFile = "tree1";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Mechanical Tree";
};

StaticShapeData DeployableTree2
{
	shapeFile = "tree2";
	debrisId = defaultDebrisSmall;
	maxDamage = 6.50;
	visibleToSensor = false;
	isTranslucent = true;
   	description = "Mechanical Tree";
};

function DeployableTree::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

function DeployableTree2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "TreePack"]--;
	
}

//============================================================================ Cactus 2

StaticShapeData DeployableCactus2
{
	shapeFile = "cactus2";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
   	description = "Healing Plant";
};

function DeployableCactus2::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "PlantPack"]--;
	
}

function DeployableCactus2::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);


	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(GameBase::getDamageLevel(%obj)) 
	{
		Gamebase::setDamageLevel(%obj,0);
		//Player::setItemCount(%obj,Healthkit,1);
		GameBase::playSound(%this,ForceFieldOpen,0);
	}
}

//============================================================================ HoloGram 1

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

//============================================================================ HoloGram 2
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

//============================================================================ HoloGram 3
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
    
//                                                  =-=-=-=-=- Teleporter =-=-=-=-
StaticShapeData DeployableTeleport
{
    	className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";
   	description = "Teleport Pad";

	shapeFile = "flagstand";
	maxDamage = 1.75;
//	maxEnergy = 20;
//	shieldShapeName = "shield";

   	mapFilter = 2;
	visibleToSensor = true;
    	explosionId = mortarExp;
    	debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};
				
function RemoveBeam(%b)
{
	deleteObject(%b);
}				
														 
function DeployableTeleport::onDestroyed(%this)
{
	schedule("RemoveBeam("@%this.beam1@");",1);
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
		{
			GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			return;
		}
	}
}

function DeployableTeleport::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}

	if(Player::isDead(%obj))
	{
		return;
	}

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if(%teleTeam != %playerTeam)
	{
		if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
			Client::SendMessage(%c,0,"Phased through enemy teleporter");
		else
		{ 
			Client::SendMessage(%c,0,"Wrong Team"); 
			return;
		}
	}

	if(%this.disabled == true)
	{
	        Client::SendMessage(%c,0,"Teleport Pad is recharging");
	        return;
	}

	%teleset = nameToID("MissionCleanup/Teleports");

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if ($Debug) echo ("Group Set Teleporter = " @ Group::getObject(%teleset, %i));
		if(GameBase::getTeam(%o) == %playerteam && %o != %this)
		{
			if((Player::getArmor(%obj) == "harmor") || (Player::getArmor(%obj) == "parmor"))
			{
			        Client::SendMessage(%c,0,"Cannot teleport in this armor type");
				return;
			}
			else
			{
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;
			}
		}
		else if((Player::getArmor(%obj) == "spyarmor") || (Player::getArmor(%obj) == "spyfemale"))
		{
			if(GameBase::getTeam(%o) != %playerteam && %o != %this)
			{
				Client::SendMessage(%c,0,"Transporting To Enemy Telepad!");
				GameBase::playSound(%o,ForceFieldOpen,0);
				GameBase::playSound(%this,ForceFieldOpen,0);
		           	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
				%o.Disabled = true;
				%this.Disabled = true;
				schedule("DeployableTeleport::Reenable("@%o@");",5);
				schedule("DeployableTeleport::Reenable("@%this@");",5);
				return;								
			}		
		}
	}
	Client::SendMessage(%c,0,"No other pad to teleport to.");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

//================================================ Air Bases ====================================================

StaticShapeData AirAmmoBasePad //=================================================================== Air Ammo Pad
{
        shapeFile = "elevator6x6thin";
        debrisId = defaultDebrisLarge;
        maxDamage = 5.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air-Ammo Base Pad";
};

//================================================================================================== Air Base
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
//================================================================================================== Air Base
StaticShapeData LargeEmplacementPlatform
{
        shapeFile = "elevator16x16_octo";
        debrisId = defaultDebrisLarge;
        maxDamage = 1500.0;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Emplacement Platform";
};
//============================================== Personal Movers ================================================

StaticShapeData AccelPadPack
{
	className = "AccelPadPack";
	damageSkinData = "objectDamageSkins";
	shapeFile = "elevator_6x6_octagon";
	maxDamage = 3.33333;
//	maxEnergy = 20;
//	shieldShapeName = "shield_medium";
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = debrisExpLarge;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	description = "Accelerator Pad"; //added
	isTranslucent = false;
};

function AccelPadPack::Destruct(%this)
{
	AccelPadPack::doDamage(%this);
}

function AccelPadPack::doDamage(%this) {}

function AccelPadPack::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	AccelPadPack::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "AccelPPack"]--;
}

function AccelPadPack::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player") {return;}
	if(Player::isDead(%obj)) {return;}
	%c = Player::getClient(%obj);
	%pteam = GameBase::getTeam(%obj);
	%oteam = GameBase::getTeam(%this);
	%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);
	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ;
	if(%pteam==%oteam || Player::getArmor(%obj) == "spyarmor" || Player::getArmor(%obj) == "spyfemale")
	{
		if(%obj.deployStandby!=1)
		{
			if(%diffZ>0.950)
			{
				%obj.deployStandby=1;
				%msg="<f1>Accelerator Pad: <f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
				if(Player::getArmor(%obj) == "jarmor")
					%msg = "<f1>Accelerator Pad: <f0>The Accelerator Pad does not have enough strength to boost a Juggernaught.";
				remoteEval(%c, "BP", %msg, 0);
				AccelPadPack::CheckPlayer(%this,%obj);
			}
		}
		else if(%diffZ<0.950)
		{
			remoteEval(%c, "CP", "", 0);
			%obj.deployStandby=0;
		}
	}
	return;
}

function AccelPadPack::CheckPlayer(%this,%obj)
{
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);

	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ-0.92;
	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;
	
	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);
	
	if(%deploy>0)
	{
		%armor=GameBase::getDataName(%obj);
//		if($Shifter::newAccel != "false")
//		{
			%mass=%armor.mass;
			%rot=GameBase::getRotation(%obj);
			%len=50;
			%zlen=25;
			%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
			%val=(%mass/2)*(%mass/2);
//			if(%armor == "jarmor") %val=%val*1.5;
			if(%armor != "jarmor")
			{
				Player::applyImpulse(%obj,%vec);	
				playSound(debrisMediumExplosion,gamebase::getposition(%obj));
			}
//			if($Shifter::Acceldamage != "false")
//				GameBase::applyDamage(%this,$ImpactDamageType, %val*0.01,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
//		}
//		else
//		{
//			%mass=%armor.mass;
//			%rot=GameBase::getRotation(%obj);
//			%len=50;
//			%zlen=50;
//			%rnd=floor(getrandom()*30);
//		
//			if (%armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale" || %armor == "larmor" || %armor == "lfemale" || %armor == "stimarmor" || %armor == "stimfemale")
//			{
//				playSound(debrisMediumExplosion,%tpos);
//			}
//			if (%armor == "barmor" || %armor == "bfemale" || %armor == "aarmor" || %armor == "afemale" || %armor == "earmor" || %armor == "efemale" || %armor == "marmor" || %armor == "mfemale")
//			{
//				playSound(debrisMediumExplosion,%tpos);
//				%len-=10;
//				%zlen-=15; 
//			}
//			if (%armor == "darmor" || %armor == "jarmor" || %armor == "parmor")
//			{
//				playSound(debrisMediumExplosion,%tpos);
//				%len-=35;
//				%zlen-=35;
//			}
//
//			playSound(debrisSmallExplosion,%tpos);
//
//			%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
//			Player::applyImpulse(%obj,%vec);
//		}
		schedule(%obj@".deployStandby=0;",0.1);
		%recall=0;
	}
	else if(%deploy<0)
	{
		%recall=0;
		%obj.deployStandby=0;
	}
	if(%recall)
	{
		schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	}
	else
	{
		remoteEval(%client, "CP", "", 0);
	}
}

//============================================================================================= Launch Pad

StaticShapeData DeployableLaunch
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 1.50;
	visibleToSensor = false;
	isTranslucent = true;
	description = "Launch Pad";
};

function DeployableLaunch::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LaunchPack"]--;
}

function DeployableLaunch::onCollision(%this,%obj) 
{
	%c = Player::getClient(%obj);

	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::SendMessage(%c, 0, "SPROING!");
	%velocity = 200;
	%zVec = 600;
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
}


