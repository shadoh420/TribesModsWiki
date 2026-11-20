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
   explosionId = debrisExpSmall;
	debrisId = defaultDebrisSmall;
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

function DefaultBeacon::onCollision(%this,%obj)
{
	GameBase::setDamageLevel(%this,0.2);
}

//New

$DamageScale[PentashieldGen, $LandingDamageType] = 1.0;	
$DamageScale[PentashieldGen, $ImpactDamageType] = 1.0;
$DamageScale[PentashieldGen, $CrushDamageType] = 1.0;
$DamageScale[PentashieldGen, $BulletDamageType] = 1.0;
$DamageScale[PentashieldGen, $PlasmaDamageType] = 0.0;
$DamageScale[PentashieldGen, $EnergyDamageType] = 1.0;
$DamageScale[PentashieldGen, $ExplosionDamageType] = 1.0;
$DamageScale[PentashieldGen, $MissileDamageType] = 1.0;
$DamageScale[PentashieldGen, $DebrisDamageType] = 1.0;
$DamageScale[PentashieldGen, $ShrapnelDamageType] = 1.0;
$DamageScale[PentashieldGen, $LaserDamageType] = 1.0;	
$DamageScale[PentashieldGen, $MortarDamageType] = 1.0;	
$DamageScale[PentashieldGen, $BlasterDamageType] = 1.0;	
$DamageScale[PentashieldGen, $ElectricityDamageType] = 1.0;
$DamageScale[PentashieldGen, $MineDamageType] = 1.0;	
$DamageScale[PentashieldGen, $StabDamageType] = 0.7;	
$DamageScale[PentashieldGen, $PoisonDamageType] = 0.5;	
$DamageScale[PentashieldGen, $StunnerDamageType] = 0.1;	
$DamageScale[PentashieldGen, $NukeDamageType] = 1.0;	
$DamageScale[PentashieldGen, $Poison2DamageType] = 0.0;	
$DamageScale[PentashieldGen, $WormDamageType] = 1.0;	
$DamageScale[PentashieldGen, $CutterayDamageType] = 1.5;
$DamageScale[PentashieldGen, $SmallLasDamageType] = 0.8;
$DamageScale[PentashieldGen, $RifleLasDamageType] = 0.8;
$DamageScale[PentashieldGen, $HeavyLasDamageType] = 0.8;
$DamageScale[PentashieldGen, $AsphyxiationDamageType] = 0.0;
$DamageScale[PentashieldGen, $LargeBulletDamageType] = 1.0;
$DamageScale[PentashieldGen, $ThrownWeaponDamageType] = 0.1;
$DamageScale[PentashieldGen, $ThrownPoisonWeaponDamageType] = 0.1;

StaticShapeData PentashieldGen
{
	className = "PentashieldGen";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 1.0;
	maxEnergy = 200;

   castLOS = true;
   supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
   explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	description = "PentashieldGen";
};

function PentashieldGen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
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
																				 
function PentashieldGen::onEnabled(%this)
{
}

function PentashieldGen::onDisabled(%this)
{
}

function PentashieldGen::onDestroyed(%this)
{  
	if($GenShield[%this] && $GenShield[%this] != "")
		GameBase::setDamageLevel($GenShield[%this], GameBase::getDataName($GenShield[%this]).maxDamage+0.1);
 		

}




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
   explosionId = mineexp;
	debrisId = flashDebrisSmall;
};
																						 
function Charge::onEnabled(%this)
{
	Gamebase::setIsTarget(%this, false);
	GameBase::setMapName(%this, "Charge");
echo(%this.owner);
	//%this.owner
	startCount(%this);
}

function Charge::onDisabled(%this) {}

function Charge::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "Charge"]--;
}

function startCount(%object) 
{
	schedule("ChargeDetonate("@%object@");", 15, %object);
}

function ChargeDetonate(%object)
{
	%pos = gamebase::getposition(%object);
	%pos = GetOffSetRot("0 0 0.1",Vector::add(Gamebase::getrotation(%object),"0 0 0"),%pos);
	GameBase::applyRadiusDamage($ExplosionDamageType, %pos, 20,6,250,%object.client);
	schedule("GameBase::applyRadiusDamage(\""@$ExplosionDamageType@"\",\""@ %pos@"\", 20,6,250,\""@%object.client@"\");",0.1);
	//CalcRadiusDamage(%object,$ExplosionDamageType,20,0.2,25,20,20,20.5,10.1,200,100); 
	Gamebase::setDamageLevel(%object, 0.1);

	%pos = gamebase::Getposition(%object);

	%pos = vector::add(%pos,"0 0 0.3");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	%pos = vector::Add(%pos,"0 0 -0.6");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	%pos = vector::Add(%pos,"0 0.3 0.3");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	%pos = vector::Add(%pos,"0 -0.6 0");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	%pos = vector::Add(%pos,"0.3 0.3 0");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	%pos = vector::Add(%pos,"-0.6 0 0");
	projectile::spawnProjectile(ExpPackPop,"0 0 0 0 0 0 0 0 0 "@%pos,%object.owner,"0 0 0");
	//$TeamItemCount[GameBase::getTeam(%this) @ "ExplosivePack"]--;
	echo("MSG: Charge has exploded");
		
	%set = newObject("set",SimSet); // make new box for testing.
	if(containerBoxFillSet(%set,$StaticObjectType,%pos,5,5,5,0))
	{ 
		%num = containerBoxFillSet(%set,$StaticObjectType,%pos,5,5,5,0);
		for(%x=0;%x<%num;%x++)
		{
			%item = group::getObject(%set,%x);
			if(gamebase::Getdataname(%item) == LargeForceField || gamebase::Getdataname(%item) == SmallForceField
				|| gamebase::Getdataname(%item) == DeployableForceField)
			{
				GameBase::setDamageLevel(%item, GameBase::getDataName(%item).maxDamage+0.1);
			}
		}
	}
}
