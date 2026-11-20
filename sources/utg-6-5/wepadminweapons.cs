// Part One: Projectile Data Blocks
LightningData AlightningCharge
{
   bitmapName	    = "zap03.bmp";
   damageType	    = $ElectricityDamageType;
   boltLength	    = 40.0;
   coneAngle	    = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 6;
   numSegments	    = 8;
   beamWidth	    = 0.4;//075;
   updateTime	= 120;
   skipPercent	= 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

function AlightningCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%TDS = $Server::TeamDamageScale;
	%shooter = %shooterId;
	%sPlayer = Client::getOwnedObject(%shooter);
	%sROT = GameBase::getRotation(%sPlayer);
	%velocity = -80;
	%shooterDir = Vector::getFromRot(%sROT, %velocity, %sROT);
	%drate = GameBase::getDamageLevel(%target);
	
	if(GameBase::getTeam(%sPlayer) == GameBase::getTeam(%target) && %drate == 0 && %sPlayer.isRepairing == 0 && %TDS != 1)
	{
		if(%shooterId.msgSpam != true)
		{
			Client::sendMessage(%shooter, 0, GameBase::getDataName(%target) @" is Not Damaged.~wAccess_Denied.Wav");
			Player::Trigger(%sPlayer, $WeaponSlot, false);
			%shooterId.msgSpam = true;
			Schedule(%shooterId @".msgSpam = false;", 3);
		}
		%sPlayer.isRepairing = 0;
		return;
	}
	
	if(%TDS == 1 || GameBase::getTeam(%sPlayer) != GameBase::getTeam(%target))
	{
		Player::applyImpulse(%target, %shooterDir);
		%damVal = %timeSlice * 350;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $BeamOfPainDamageType, 9999, %pos, %vec, %mom, %shooterId);
		%energy = GameBase::getEnergy(%target);
		%energy = %energy - %enVal;
		if (%energy < 0)
		{ %energy = 0; }
		GameBase::setEnergy(%target, %energy);
	}
	else if(GameBase::getTeam(%sPlayer) == GameBase::getTeam(%target) && %TDS != 1)
	{
		if(%drate != 0)
		{ %sPlayer.isRepairing = 1; }
		if(%drate == 0 && %sPlayer.isRepairing == 1)
		{
			Client::sendMessage(%shooter, 0, "Repair Done.");
			Player::Trigger(%sPlayer, $WeaponSlot, false);
			%sPlayer.isRepairing = 0;
			return;
		}
		// Subtract 5 from the damage level.
		%drate -= 5.0;
		if(%drate < 0)
		{ %drate = 0; }
		GameBase::setDamageLevel(%target, %drate);	
	}	
}

//------------------------------------------------------------------------------------------

BulletData AdminBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;
   damageClass        = 0;
   damageValue        = 999999;
   damageType         = $AdminDamageType;
   muzzleVelocity     = 100;
   totalTime          = 4;
   liveTime           = 2.5;
   inheritedVelocityScale = 0.5;
   isVisible          = true;
   rotationPeriod = 1;
};
//==========================================================================================

ItemImageData AdminGunImage
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	weaponType = 0;
	projectileType = AtomShell; 
	accuFire=true; 
	minEnergy=1; 
	maxEnergy=0.03; 
	reloadTime=0.03; 
	sfxFire=SoundTaserFire; 
	sfxActivate=SoundPickUpWeapon; 
	sfxReady=SoundEnergyPackOn; 
};
ItemData AdminGun
{ 
	description = "@DMIN$ G|_|N"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "sniper"; 
	heading = $InvHeading[EnergyWeapons]; 
	shadowDetailMask = 4; 
	imageType = AdminGunImage; 
	price = 500; 
	showWeaponBar = true; 
};
function AdminGun::OnUse(%player, %item)
{ Weapon::onUse(%player,%item); }
//------------------------------------------------------------------------------------------

ItemImageData AEnergyRifleImage
{
	shapeFile   = "shotgun";
	mountPoint  = 0;
	weaponType  = 2;
	projectileType = AlightningCharge;
	minEnergy   = 3;
	maxEnergy   = 11;
	reloadTime  = 0.08;
	lightType   = 3;
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData AEnergyRifle
{
   description = "AELF Gun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHeading[EnergyWeapons];
   shadowDetailMask = 4;
   imageType = AEnergyRifleImage;
   showWeaponBar = true;
   price = 125;
   validateShape = false;
};
function AEnergyRifle::onUse(%player, %item)
{ Weapon::onUse(%player, %item); }