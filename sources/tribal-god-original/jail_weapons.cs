// Part One: Projectile Data Blocks
//==========================================================================================
$jailBolt::jailTime = 30;
LightningData jailbolt
{
	bitmapName        = "lightningNew.bmp";
	damageType        = $ElectricityDamageType;
	boltLength        = 350;
	coneAngle         = 1.0;
	damagePerSec      = 0.0;
	energyDrainPerSec = 60.0;
	segmentDivisions  = 1;
	numSegments       = 1;
	beamWidth         = 0.125;
	updateTime        = 120;
	skipPercent       = 0.5;
	displaceBias      = 0.15;
	lightRange        = 3.0;
	lightColor        = { 0.25, 0.25, 0.85 };
	soundId           = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(getObjectType(%target) != "Player" || GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
	{ return; }
	
	%teleset = nameToID("MissionCleanup/jailports");
	%playerTeam = GameBase::getTeam(%target);
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam = GameBase::getTeam(%o);
		%oPOS = GameBase::getPosition(%o);
		if(%oteam != %playerTeam)
		{
			%sClient = Player::getClient(%shooterId);
			%sName = Client::getName(%sClient);
			
			%tClient = Player::getClient(%target);
			%tName = Client::getName(%tClient);
			%tClient.jailed = 1;
			Schedule(%tClient @".jailed = 0;", $jailBolt::jailTime);
			
			GameBase::SetPosition(%target, %oPOS);
			Client::SendMessage(%tClient, 0, "Your jail sentence will last "@ $jailBolt::jailTime @" seconds.");
			messageAllExcept(%tClient, 0, %tName @" Went to say hi to Bubba.");
			Schedule("Jail::JailDoorShape::Sesame("@ %target @");", $jailBolt::jailTime);
		}
	}
}

RocketData JailDart
{
	bulletShapeName  = "bullet.dts";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 0.2;
	damageClass      = 0;
	damageValue      = 0.25;
	damageType       = $JailDamageType;
	explosionRadius  = 0.1;
	bulletHoleIndex  = 0;
	kickBackStrength = 600.0;
	muzzleVelocity   = 9000;
	terminalVelocity = 9000;
	acceleration     = 500.0;
	totalTime        = 10.0;
	liveTime         = 11.0;
	lightRange       = 10.0;
	lightColor       = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 0.0;
	soundId = SoundJetHeavy;
};

//==========================================================================================


// Part Two: ItemData Blocks
//==========================================================================================

ItemImageData JailGunImage
{
	shapeFile   = "shotgun";
	mountPoint  = 0;
	weaponType  = 2;
	projectileType = jailbolt;
	minEnergy   = 3;
	maxEnergy   = 11;
	reloadTime  = 0.25;
	lightType   = 3;
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData JailGun
{
	heading     = $InvHeading[EnergyWeapons];
	description = "Jail Gun";
	className   = "Weapon";
	shapeFile   = "repairgun";
	shadowDetailMask = 4;
	imageType   = JailGunImage;
	price       = 385;
	showWeaponBar = true;
};
function JailGun::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//------------------------------------------------------------------------------------------

ItemImageData JailRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	minEnergy = 10;
	maxEnergy = 0.01;
	weaponType = 0;
	projectileType = JailDart;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.01;
	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData JailRifle
{
	description = "Jail Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = JailRifleImage;
	price = 375;
	showWeaponBar = true;
	validateShape = false;
	validateMaterials = false;
};

function JailRifle::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//==========================================================================================