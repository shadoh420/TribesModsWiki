RocketData AtomShell
{
   bulletShapeName = "mortar.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass     = 1;       
   damageValue     = 5;
   damageType      = $ExplosionDamageType;
   explosionRadius = 5;
   kickBackStrength = 5;
   muzzleVelocity  = 75;
   terminalVelocity = 100;
   acceleration    = 1;
   totalTime       = 2;
   liveTime        = 1;
   trailType       = 1;
   trailLength     = 25;
   trailWidth      = 1.5;
   soundId         = SoundDiscSpin;
   inheritedVelocityScale = 0.5;
};

GrenadeData ScatterShell
{
   bulletShapeName    = "sensor_small.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData AtomShell2
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
   damageValue        = 0.32;
   damageType         = $MortarDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 9.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};


ItemData ATosserAmmo
{
	description = "ATosser Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData ATosserImage
{
	shapeFile   = "grenadeL";
	mountPoint  = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType  = 0; 
	reloadTime  = 0.25;
	fireTime    = 0.1;
	minEnergy   = 5;
	maxEnergy   = 6;
//	projectileType = AtomShell;
	ammoType    = ATosserAmmo;
	accuFire    = true;
	sfxFire	    = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload   = SoundMortarReload;
};

ItemData ATosser
{
	heading   = $InvHeading[BulletWeapons];
	description = "Atom Tosser";
	classname = "Weapon";
	shapeFile = "GrenadeL";
	hudIcon	  = "sensorjamerpack";
	shadowDetailMask = 4;
	imageType = ATosserImage;
	price     = 350;
	showWeaponBar = true;
};

function ATosserImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%ammo = Player::getItemCount(%player, ATosserAmmo);
	if(%ammo > 0)
	{
//		%trans = getPerfectTrans(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		if(GameBase::getLOSInfo(%player, 800))
		{
			%dist = Vector::getDistance(GameBase::getPosition(%player), $los::position);
			if(%dist == 0)
			{ %time = -0.05; }
			else
			{ %time = (%dist / 180) + 0.25; }
			%obj = Projectile::spawnProjectile(AtomShell, %trans, %player, %vel);
			Schedule("ScatterBombs("@ %player @", "@ %client @", "@ %obj @");", %time, %obj);
		}
		else
		{
			%obj = Projectile::spawnProjectile(AtomShell, %trans, %player, %vel);
			Schedule("ScatterBombs("@ %player @", "@ %client @", "@ %obj @");", 2);
		}
		Player::decItemCount(%player, $WeaponAmmo[ATosser]);
	}
}