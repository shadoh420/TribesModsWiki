
																										
function StaticShape::onPower(%this,%power,%generator) {
	if (%power) 
		GameBase::playSequence(%this,0,"power");
	else 
		GameBase::stopSequence(%this,0);
}

function StaticShape::onEnabled(%this) {
	if (GameBase::isPowered(%this)) 
		GameBase::playSequence(%this,0,"power");
}

function StaticShape::onDisabled(%this) {
	GameBase::stopSequence(%this,0);
}

function StaticShape::onDestroyed(%this) {
	GameBase::stopSequence(%this,0);
   StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 15, 4, 0.44, 
		0.14, 255, 100); 
}

exec(statFunc);

function StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object) {

	if(%type == 999)
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
		
	%damageLevel = GameBase::getDamageLevel(%this);
   %this.lastDamageObject = %object;
     %this.lastDamageTT = %type;
   %this.lastDamageTeam = GameBase::getTeam(%object);
	if (%this.shieldStrength) {
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		%name = GameBase::getDataName(%object);
		if(getObjectType(%object) == "Flier" && %name.shapefile == "rocket" && %this.lastDamageTeam != GameBase::getTeam(%this)) {
			GameBase::setDamageLevel(%object, 10); 
			%strength *= 0.5;
			if (%name == BooProj) {
				StaticShape::onDamage(%this,%type,(%value),%pos,%vec,%mom,%object);
				%energy *= 0.5;
				%strength *= 0.55;
			} else {
				StaticShape::onDamage(%this,%type,(%value/2),%pos,%vec,%mom,%object);
			}
		}		
		if (%type == $ShrapnelDamageType) %strength *= 0.5; 
			else if (%type == $MortarDamageType) %strength *= 0.25;
				else if (%type == $BlasterDamageType) %strength *= 2.0; 
					else if(%type == $RailDamageType) { 
						%value *= 0; 
						%energy *= 0.7; 
					}
		%absorb = %energy * %strength;
		if (%value < %absorb) {
			if(%type == $EMPDamageType || %type == $FlashDamageType) {
				GameBase::setEnergy(%this,(%energy * 0.82));
				playSound(SoundEMPDrain,GameBase::getPosition(%this)); 
			} else {
				GameBase::setEnergy(%this,%energy - (%value / %strength));
				if(%this.lastsound < getSimTime()) {
					playSound(SoundShldOn, GameBase::getPosition(%this));
					%this.lastsound = getSimTime() + 1;
				}
			}
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
		} else { 
			GameBase::setEnergy(%this,0);
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	}
	else {
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

StaticShapeData FlagStand { description = "Flag Stand"; shapeFile = "flagstand"; visibleToSensor = false; }; 

function calcRadiusDamage(%this,%type,%radiusRatio,%damageRatio,%forceRatio,%rMax,%rMin,%dMax,%dMin,%fMax,%fMin) {
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

function FlagStand::onDamage() { } 

function Generator::onEnabled(%this) { GameBase::setActive(%this,true); } 

function Generator::onDisabled(%this) { GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); } 

function Generator::onDestroyed(%this) { Generator::onDisabled(%this); StaticShape::objectiveDestroyed(%this); calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); } 

function Generator::onActivate(%this) { GameBase::playSequence(%this,0,"power"); GameBase::generatePower(%this, true); } function Generator::onDeactivate(%this) { GameBase::stopSequence(%this,0); GameBase::generatePower(%this, false); } 

StaticShapeData TowerSwitch { description = "Tower Control Switch"; className = "towerSwitch"; shapeFile = "tower"; showInventory = "false"; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; }; 

StaticShapeData Generator { description = "Generator"; shapeFile = "generator"; className = "Generator"; sfxAmbient = SoundGeneratorPower; debrisId = flashDebrisLarge; explosionId = flashExpLarge; maxDamage = 2.0; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; }; 


StaticShapeData GHook {
	damageSkinData = "objectDamageSkins";
	shapeFile = "sensor_small";
	maxDamage = 0.2;
	triggerradius = 10;
	visibleToSensor = false;
    explosionId = kakeExp;
};

function GHook::onDestroyed(%this) { 
	%this.setter.hook = 0;
}

StaticShapeData SolarPanel { description = "Solar Panel"; shapeFile = "solar_med"; className = "Generator"; debrisId = flashDebrisMedium; maxDamage = 1.3; visibleToSensor = true; mapFilter = 4; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpLarge; }; StaticShapeData PortGenerator { description = "Portable Generator"; shapeFile = "generator_p"; className = "Generator"; debrisId = flashDebrisSmall; sfxAmbient = SoundGeneratorPower; maxDamage = 1.7; mapIcon = "M_generator"; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; visibleToSensor = true; mapFilter = 4; }; StaticShapeData SmallAntenna { shapeFile = "anten_small"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Small Antenna"; }; StaticShapeData MediumAntenna { shapeFile = "anten_med"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Medium Antenna"; }; StaticShapeData LargeAntenna { shapeFile = "anten_lrg"; debrisId = defaultDebrisSmall; maxDamage = 1000; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Large Antenna"; }; StaticShapeData ArrayAntenna { shapeFile = "anten_lava"; debrisId = flashDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Array Antenna"; }; StaticShapeData RodAntenna { shapeFile = "anten_rod"; debrisId = defaultDebrisSmall; maxDamage = 1.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Rod Antenna"; }; StaticShapeData ForceBeacon { shapeFile = "force"; debrisId = defaultDebrisSmall; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Force Beacon"; }; StaticShapeData CargoCrate { shapeFile = "magcargo"; debrisId = flashDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = flashExpMedium; description = "Cargo Crate"; }; StaticShapeData CargoBarrel { shapeFile = "liqcyl"; debrisId = defaultDebrisSmall; maxDamage = 1.0; damageSkinData = "objectDamageSkins"; shadowDetailMask = 16; explosionId = debrisExpMedium; description = "Cargo Barrel"; }; StaticShapeData SquarePanel { shapeFile = "teleport_square"; debrisId = flashDebrisSmall; maxDamage = 0.3; damageSkinData = "objectDamageSkins"; explosionId = flashExpMedium; description = "Panel"; }; StaticShapeData VerticalPanel { shapeFile = "teleport_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData BluePanel { shapeFile = "panel_blue"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData YellowPanel { shapeFile = "panel_yellow"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData SetPanel { shapeFile = "panel_set"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData VerticalPanelB { shapeFile = "panel_vertical"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData DisplayPanelOne { shapeFile = "display_one"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData DisplayPanelTwo { shapeFile = "display_two"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData DisplayPanelThree { shapeFile = "display_three"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData HOnePanel { shapeFile = "dsply_h1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData HTwoPanel { shapeFile = "dsply_h2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData SOnePanel { shapeFile = "dsply_s1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData STwoPanel { shapeFile = "dsply_s2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData VOnePanel { shapeFile = "dsply_v1"; debrisId = defaultDebrisSmall; explosionId = debrisExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; StaticShapeData VTwoPanel { shapeFile = "dsply_v2"; debrisId = flashDebrisSmall; explosionId = flashExpMedium; maxDamage = 0.5; damageSkinData = "objectDamageSkins"; description = "Panel"; }; 

StaticShapeData AirAmmoBasePad {
        shapeFile = "elevator_8x8";
        debrisId = defaultDebrisLarge;
        maxDamage = 4.5;
        damageSkinData = "objectDamageSkins";
        shadowDetailMask = 16;
        explosionId = debrisExpLarge;
        visibleToSensor = true;
        mapFilter = 4;
        description = "Air Pad";
};

function AirAmmoBasePad::onDestroyed(%this) {
	StaticShape::objectiveDestroyed(%this);
   	GameBase::applyRadiusDamage(412, getBoxCenter(%this), 14, 30.0, 50, 0);
    $TeamItemCount[GameBase::getTeam(%this) @ "AirAmmoPad"]--;
}

StaticShapeData ForceField { shapeFile = "forcefield"; debrisId = defaultDebrisSmall; maxDamage = 10200.0; isTranslucent = true; description = "Force Field"; }; 

StaticShapeData ElectricalBeam { shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

StaticShapeData ElectricalBeamBig { shapeFile = "zap_5"; maxDamage = 1.75; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

StaticShapeData Twiggy { shapeFile = "mrtwig"; maxDamage = 10000.0; description = "Twig"; }; 

StaticShapeData LittleCraft { shapeFile = "flyer"; maxDamage = 10000.0; description = "Scout"; }; 

StaticShapeData HoverCraft { shapeFile = "hover_apc"; maxDamage = 10000.0; description = "HAPC"; }; 

StaticShapeData SmokePuff { shapeFile = "smoke"; maxDamage = 10000.0; description = "Smoke"; disableCollision = true; isTranslucent = true;  }; 

StaticShapeData Fire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = true; isTranslucent = true; }; 

StaticShapeData PoweredFire { shapeFile = "plasmabolt"; maxDamage = 10000.0; description = "Fire"; disableCollision = false; isTranslucent = true; }; 

function PoweredFire::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData BlueWall { shapeFile = "plasmawall"; maxDamage = 10000.0; description = "Wall"; disableCollision = true; isTranslucent = true; }; 

StaticShapeData BlueFWall { shapeFile = "plasmawall"; maxDamage = 10000.0; description = "Wall"; disableCollision = false; isTranslucent = true; }; 

StaticShapeData PoweredElectricalBeam { shapeFile = "zap"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

function PoweredElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData PoweredBElectricalBeam { shapeFile = "zap_5"; maxDamage = 10000.0; isTranslucent = true; description = "Electrical Beam"; disableCollision = true; }; 

function PoweredBElectricalBeam::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

StaticShapeData BigAssSat { shapeFile = "sat_big"; maxDamage = 10000.0; description = ""; }; 

StaticShapeData Cactus1 { shapeFile = "cactus1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; }; StaticShapeData Cactus2 { shapeFile = "cactus2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; }; StaticShapeData Cactus3 { shapeFile = "cactus3"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Cactus"; }; StaticShapeData SteamOnGrass { shapeFile = "steamvent_grass"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; StaticShapeData SteamOnMud { shapeFile = "steamvent_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; StaticShapeData TreeShape { shapeFile = "tree1"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; }; StaticShapeData TreeShapeTwo { shapeFile = "tree2"; maxDamage = 10.0; isTranslucent = "True"; description = "Tree"; }; StaticShapeData SteamOnGrass2 { shapeFile = "steamvent2_grass"; maxDamage = 999.0; isTranslucent = "True"; }; StaticShapeData SteamOnMud2 { shapeFile = "steamvent2_mud"; maxDamage = 999.0; isTranslucent = "True"; description = "Steam Vent"; }; StaticShapeData PlantOne { shapeFile = "plant1"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; }; StaticShapeData PlantTwo { shapeFile = "plant2"; debrisId = defaultDebrisSmall; maxDamage = 0.4; description = "Plant"; }; 

StaticShapeData DeployableForceField { className = "FF"; shapeFile = "forcefield_5x5"; debrisId = flashDebrisMedium; explosionId = debrisExpSmall; maxDamage = 3.6; visibleToSensor = true; isTranslucent = true; description = "Force Field"; }; 
function DeployableForceField::Destruct(%this) {
	DeployableForceField::doDamage(%this);
}
function DeployableForceField::doDamage(%this) {
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 3, 1.2, 100, %this);
}
function DeployableForceField::onDestroyed(%this) {
	DeployableForceField::doDamage(%this);
	StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "ForceFieldPack"]--; 
} 

StaticShapeData LargeForceField { className = "FF"; shapeFile = "forcefield"; debrisId = flashDebrisLarge; explosionId = debrisExpLarge; maxDamage = 4.6; visibleToSensor = true; isTranslucent = true; description = "Force Field"; }; 
function LargeForceField::Destruct(%this) {
	LargeForceField::doDamage(%this);
}
function LargeForceField::doDamage(%this) {
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 3, 1.3, 100, %this);
}
function LargeForceField::onDestroyed(%this) {
	LargeForceField::doDamage(%this);
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceFieldPack"]--; 
} 


StaticShapeData doorthreebyfourForceFieldShape {
	className = "FF";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_5x5";
	maxDamage = 4;
	maxEnergy = 20;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = debrisExpSmall;
	debrisId = flashDebrisMedium;
	side = "single";
	isTranslucent = true;
	description = "Force Field Door";
};

function doorthreebyfourForceFieldShape::Destruct(%this) {
	doorthreebyfourForceFieldShape::doDamage(%this);
}
function doorthreebyfourForceFieldShape::doDamage(%this) {
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 3, 1.2, 100, %this);
}
function doorthreebyfourForceFieldShape::onDestroyed(%this) {
	doorthreebyfourForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorthreebyfourForceFieldPack"]--;
}
function doorthreebyfourForceFieldShape::onCollision(%this,%obj) {
	if(%this.opening == true) return;
	%data = GameBase::getDataName(%obj);
	if(%data != Dr)
		if(getObjectType(%obj) != "Player" || Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	if(%data != Dr && GameBase::getTeam(%this) != Client::getTeam(%c)) {
		%a = Player::getArmor(%c);
		if(%a != "earmor" && %a != "efemale" && %a != "spyarmor" && %a != "spyfemale" && %a != "ifarmor" && %a != "iarmor") return;
	}
	doorthreebyfourForceFieldShape::openDoor(%this);
}
function doorthreebyfourForceFieldShape::openDoor(%this) {
	GameBase::startfadeout(%this);
	%this.opening = true;
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 2000");
	schedule("GameBase::setPosition("@%this@",\""@%pos@"\");", 2, %this);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",1.8, %this);
	schedule("doorthreebyfourForceFieldShape::closeDoor("@%this@");",6, %this);
}
function doorthreebyfourForceFieldShape::closeDoor(%this) {
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 -2000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	%this.opening = false;
}

StaticShapeData doorfourbyeightForceFieldShape {
	className = "FF";
	damageSkinData = "objectDamageSkins";
	shapeFile = "forcefield_4x8";
	maxDamage = 3.3;
	maxEnergy = 15;
	mapFilter = 2;
	visibleToSensor = true;
	debrisId = flashDebrisLarge; 
	explosionId = debrisExpLarge;
	side = "single";
	isTranslucent = true;
	description = "Large Force Field Door";
};
function doorfourbyeightForceFieldShape::Destruct(%this) {
	doorfourbyeightForceFieldShape::doDamage(%this);
}
function doorfourbyeightForceFieldShape::doDamage(%this) {
	GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 3, 1.3, 100, %this);
}
function doorfourbyeightForceFieldShape::onDestroyed(%this) {
	doorfourbyeightForceFieldShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "doorfourbyeightForceFieldPack"]--;
}
function doorfourbyeightForceFieldShape::onCollision(%this, %obj) {
	if(%this.opening == true) return;
	%data = GameBase::getDataName(%obj);
	if(%data != Dr)
		if(getObjectType(%obj) != "Player" || Player::isDead(%obj)) return;
	%c = Player::getClient(%obj);
	if(%data != Dr && GameBase::getTeam(%this) != Client::getTeam(%c)) { 
		%a = Player::getArmor(%c); 
		if(%a != "earmor" && %a != "efemale" && %a != "spyarmor" && %a != "spyfemale" && %a != "ifarmor" && %a != "iarmor") return; 
	}
	doorfourbyeightForceFieldShape::openDoor(%this);
}
function doorfourbyeightForceFieldShape::openDoor(%this) {
	GameBase::startfadeout(%this);
	%this.opening = true;
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 2000");
	schedule("GameBase::setPosition("@%this@",\""@%pos@"\");", 2, %this);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",1.8, %this);
	schedule("doorfourbyeightForceFieldShape::closeDoor("@%this@");",6, %this);
}
function doorfourbyeightForceFieldShape::closeDoor(%this) {
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, "0 0 -2000");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
	%this.opening = false;
}

StaticShapeData DeployableSpring { shapeFile = "flagstand"; debrisId = defaultDebrisSmall; maxDamage = 1.50; visibleToSensor = false; isTranslucent = true; description = "Deployable Spring"; }; 

function DeployableSpring::onDestroyed(%this) { StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ %this]--; } 

function DeployableSpring::onCollision(%this,%obj) { 
	%c = Player::getClient(%obj); 
	if (floor(getRandom() * 80) == 0) {
		GameBase::playSound(%this, debrisLargeExplosion, 0); 
		Client::SendMessage(%c, 0, "BYE BYYYYYEEEEEE!"); 
		%velocity = 30; 
		%zVec = 3000; 
		%rnd = floor(getRandom() * 3); 
		if (%rnd == 0) { 
			MessageAll(0,strcat(Client::getName(%c), " blasts off.")); 
		} else if (%rnd == 1) { 
			MessageAll(0,strcat(Client::getName(%c), " visits Jupiter.")); 
		} else if (%rnd == 2) { 
			MessageAll(0,strcat(Client::getName(%c), " runs out of springboard luck.")); 
		} 
	} else if (floor(getRandom() * 65) == 0) { 
		GameBase::playSound(%this, debrisLargeExplosion, 0); 
		Client::SendMessage(%c, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!"); 
		%velocity = 250; 
		%zVec = 850; 
	} else { 
		if(%playerArm == "harmor" || %playerArm == "darmor") {
			%velocity = 175; 
			%zVec = 200; 
		} else if (%playerArm == "marmor" || %playerArm == "barmor" || %playerArm == "iarmor" || %playerArm == "mfemale" || %playerArm == "bfemale" || %playerArm == "ifarmor") {
			%velocity = 200; 
			%zVec = 330; 
		} else {
			%velocity = 150; 
			%zVec = 260; 
		}
		GameBase::playSound(%this, SoundFireMortar, 0); 
		Client::SendMessage(%c, 0, "SSPROING!"); 
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec); 
	Player::applyImpulse(%obj,%jumpDir); 
} 

StaticShapeData BlastWall { shapeFile = "newdoor5"; maxDamage = 10.0; debrisId = defaultDebrisLarge; explosionId = debrisExpLarge; }; function BlastWall::onDestroyed(%this) { StaticShape::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "TripwirePack"]--; } 
