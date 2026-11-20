$InvList[SpellFlameThrower] = 1;
$MobileInvList[SpellFlameThrower] = 1;
$RemoteInvList[SpellFlameThrower] = 1;

$AutoUse[SpellFlameThrower] = False;
$WeaponAmmo[SpellFlameThrower] = "";

addWeapon(SpellFlameThrower);
GrenadeData SpellFlameThrowerGren
{	bulletShapeName = "PlasmaBolt.dts";
	explosionTag = plasmaExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 1.0;
	elasticity = 0.3;
	damageClass = 1;
	damageValue = 0.1;
	damageType = $PlasmaDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 150;
	totalTime = 5.0;
	liveTime = 0.001;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "Plasmatrail.dts";
	smokeDist = 1.5;
};

ItemImageData SpellFlameThrowerImage 
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = SpellFlameThrowerGren;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SpellFlameThrower 
{
	description = "Spell: Flame Thrower";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "weapon";
	heading = $InvHead[ihSpl];
	shadowDetailMask = 4;
	imageType = SpellFlameThrowerImage;
	price = 175;
	showWeaponBar = true;
};


function SpellFlameThrower::MountExtras(%player,%weapon) 
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Hurls fiery death.");
}
