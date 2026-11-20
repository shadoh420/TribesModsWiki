

//======================================================================================== Booster Pad
StaticShapeData booster9x9 { shapeFile = "elevator_9x9"; maxDamage = 10000.0; description = "Platform"; disableCollision = false; isTranslucent = False; }; function platform_9x9::onDamage() { }
function booster9x9::onCollision(%this,%obj)
{
	%c = Player::getClient(%obj);
	if (floor(getRandom() * 30) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 600; %zVec = 800;
		%rnd = floor(getRandom() * 3);
		if (%rnd == 0) {  }  else if (%rnd == 1)  { }  else if (%rnd == 2)  {  }
	} 
	else if (floor(getRandom() * 7) == 0)
	{ 
		GameBase::playSound(%this, debrisLargeExplosion, 0);
		%velocity = 600; %zVec = 45;
	} 
	else 
	{ 
		GameBase::playSound(%this, SoundFireMortar, 0);
		%velocity = 600;
		%zVec = 45;
	} 
	%jumpDir = Vector::getFromRot(GameBase::getRotation(%obj),%velocity,%zVec);
	Player::applyImpulse(%obj,%jumpDir);
} 

//======================================================================== Grav Charge
LightningData repCharge
{
	bitmapName       = "repairadd.bmp";
	damageType       = $GravDamageType;
	boltLength       = 100.0;
	coneAngle        = 40.0;
	damagePerSec      = 0.01;
	energyDrainPerSec = 1.0;
	segmentDivisions = 2;
	numSegments      = 1;
	beamWidth        = 0.5;
	updateTime   = 120;
	skipPercent  = 0.1;
	displaceBias = 0.35;
	lightRange = 3.0;
	lightColor = { 0.15, 0.85, 0.15 };
	soundId = SoundELFFire;
};

function repCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = %Rotation;
	%velocity = 25;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
	Player::applyImpulse(%obj,%vec);
	Player::applyImpulse(%target, %shooterDir);
	%damVal = %timeSlice * %damPerSec;
	%enVal  = %timeSlice * %enDrainPerSec;
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
}

//======================================================================== Grav Charge
LightningData tracCharge
{
	bitmapName       = "repairadd.bmp";
	damageType       = $GravDamageType;
	boltLength       = 100.0;
	coneAngle        = 40.0;
	damagePerSec      = 0.01;
	energyDrainPerSec = 1.0;
	segmentDivisions = 2;
	numSegments      = 1;
	beamWidth        = 0.5;
	updateTime   = 120;
	skipPercent  = 0.1;
	displaceBias = 0.35;
	lightRange = 3.0;
	lightColor = { 0.15, 0.85, 0.15 };
	soundId = SoundELFFire;

};
function tracCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = %Rotation;
	%velocity = -25;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
	%damVal = %timeSlice * %damPerSec;
	%enVal  = %timeSlice * %enDrainPerSec;
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
}





//======================================================================================== Tractor And Repulsor Turrets
TurretData tracTurret 	
{
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "indoorgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = tracCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	isSustained     = true;
	firingTimeMS    = 750;
	energyRate      = 30.0;
};


TurretData repTurret 	
{
maxDamage = 1.0;
maxEnergy = 150;
minGunEnergy = 50;
maxGunEnergy = 5;
range = 40;
visibleToSensor = true;
dopplerVelocity = 0;
castLOS = true;
supression = false;
mapFilter = 2;
mapIcon = "M_turret";
debrisId = defaultDebrisMedium;
className = "ELF Turret";
shapeFile = "indoorgun";
shieldShapeName = "shield";
speed = 5.0;
speedModifier = 1.5;
projectileType = repCharge;
reloadDelay = 0.3;
explosionId = LargeShockwave;
description = "ELF Turret";

fireSound        = SoundGeneratorPower;
activationSound  = SoundChainTurretOn;
deactivateSound  = SoundChainTurretOff;
damageSkinData   = "objectDamageSkins";
shadowDetailMask = 8;

isSustained     = true;
firingTimeMS    = 750;
energyRate      = 30.0;
};











