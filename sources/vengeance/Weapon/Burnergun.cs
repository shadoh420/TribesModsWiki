
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332
// curtain O fire code by Plasmatic

// I'd really like to change the name here, but it would break some maps with rotating guns or ammo. -Plasmatic

$InvList[PlasmaGun] = 1;
$MobileInvList[PlasmaGun] = 1;
$RemoteInvList[PlasmaGun] = 1;

$AutoUse[PlasmaGun] = false;
addWeapon(PlasmaGun);
$oundReload[PlasmaGunImage] =  SoundDryFire;


RocketData PlasmaBolt
{	
	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.2;	//0.1;	//0.45;	//initial damage.
	//we're doing damage through function Armor::onBurn,
	// and function Plasmafire, so this is initial damage. -Plasmatic
	
	DamageType = $FireDamageType;		//$PlasmaDamageType;
	explosionRadius = 4.0;
	kickBackStrength = 0.0;
	muzzleVelocity = 55.0;		//55.0;
	terminalVelocity = 55.0;	//55.0;
	acceleration = 0.0;	//0
	totalTime = 1.0;	//1.5	1.0;
	liveTime = 1.0;	//1.75	1.25;
	lightRange = 6.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.5;	//0.3;
	isVisible = True;
	soundId = SoundJetLight;
	trailType = 1;
	trailLength = 10;
	trailWidth = 0.3;
};

ItemImageData PlasmaGunAImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;
//	ammoType = PlasmaAmmo;
//	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.01;	//0.1;
	fireTime = 0.1;	//0.25;
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDryFire;
};

ItemData PlasmaGunA
{
	description = "Burner";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunAImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData PlasmaGunImage
{
	shapeFile = "Force";
	mountPoint = 0;
	weaponType = 0;
//	ammoType = PlasmaAmmo;

	minEnergy = 0;	// min fire energy
	maxEnergy = 5;	// energy used per sec
	
	mountOffset = { 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.0, 3.14, 0.0};		//mountRotation = {0.5,-1.57, -1.57 };	//0.5,-1.57, -1.57
	accuFire = true;
	
	reloadTime = 0.01;	//0.1
	fireTime = 0.01;	//0.25;
	
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
};

ItemData PlasmaGun
{
	description = "Burner";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------	
function PlasmaGunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%client = Player::getClient(%player);

	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
		Player::trigger(%player, $SpareSlot1,true);
		
		%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
		schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.01);
		Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),0.55);
		
		%vel = Item::getVelocity(%player);
		
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%trans = GameBase::getMuzzleTransform(%player);	
			%proj = Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
			Plasmabolt::checkFire(%proj);
			$burnerOwner[%proj] = %player;

			%energy = GameBase::getEnergy(%player);
			gamebase::setenergy(%player,%energy -10);	
		}
		else 	
			echo("!! Butterfly Error, Burner. vel ="@%vel);			
		
	}
}

function PlasmaGun::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,PlasmaGunA,$SpareSlot1);

	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Fires flaming plasma to toast those marshmallows.");
}

// ----------------------------------------------
// Code to set the air on fire.. 
//-----------------------------------------------
function Plasmabolt::checkFire(%this)
{
	// curtain 'O' fire code by Plasmatic
	%pos = GameBase::getPosition(%this);
	if(%pos != "0 0 0")
	{
		$burnerPos[%this] = %pos;
		schedule("Plasmabolt::checkFire("@%this@");",0.025);		
	}
	else
		PlasmaBolt::startfire(%this);
}

function PlasmaBolt::startFire(%this)
{
	// curtain 'O' fire code by Plasmatic
	%Pos = $burnerPos[%this]; 
	%player = $burnerOwner[%this]; 
	$burnerPos[%this] = false; 
	$burnerOwner[%this] = false; 
		
	%fire = newObject("", "StaticShape", BurnerFireanchor, true);
	GameBase::setPosition(%fire,%pos);
	addToSet("MissionCleanup", %fire);
	%fire.firetime = 10;	//5
	Plasmabolt::floatFire(%player,%fire);
}

function Plasmabolt::floatFire(%player,%fire)
{
	// curtain 'O' fire code by Plasmatic
	%Pos = GameBase::getPosition(%fire); 
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ %pos;

	Projectile::spawnProjectile("BurnerFloater", %trans, %player, "0 0 0"); //transform, object, velocity vector, <projectile target (seeker)>

	%fire.firetime--;	
	if(%fire.firetime > 0 )
		schedule("Plasmabolt::floatFire("@%player@", "@%fire@");",0.5);
	else	
		deleteobject(%fire);
	
}

StaticShapeData BurnerFireAnchor 	
{ 
		// Plasmatic -Vengeance mod
	shapeFile = "breath";	//"zap";		
	maxDamage = 10000.0; 
	isTranslucent = true; 
	description = "Fiiiire!";  
	disableCollision = true;	
};

ExplosionData BurnerFloaterExp
{
		// Plasmatic -Vengeance mod	
	shapeName = "plasmaex.dts";
	soundId = SoundEmpIdle;	//explosion4;
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
		// Plasmatic -Vengeance mod
	lightRange = 6;

	timeZero = 0.450;
	timeOne  = 0.750;

	colors[0]  = { 1.0, 0, 0 };
	colors[1]  = { 1.0, 0, 0 };
	colors[2]  = { 1.0, 0.25, 0.25 };
	radFactors = { 1.0, 1.0, 1.0 };
	shiftPosition = true;
};

GrenadeData BurnerFloater
{
			// Plasmatic -Vengeance mod
	bulletShapeName = "plasmabolt.dts";
	explosionTag       = BurnerFloaterExp;	//BurnExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0.1;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue = 0.1;	//0.45;	//initial damage -Plasmatic
	//we're doing damage through function Armor::onBurn,
	// and function Plasmafire, so this is initial damage. -Plasmatic
	damageType = $FireDamageType;

	explosionRadius    = 4.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 275;
	totalTime          = 0.01;
	liveTime           = 0.01; // grenade time live after contact
	projSpecialTime    = 0.01;

	inheritedVelocityScale = 1.0;
	smokeName              = "plastrail.dts";//mortartrail
};

