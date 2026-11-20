//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(WaveGun);
$InvList[WaveGun] = 1;

$AutoUse[WaveGun] = True;
$WeaponAmmo[WaveGun] = "";

$ItemMax[larmor, WaveGun] = 0;		//Seraph
$ItemMax[lfemale, WaveGun] = 0;		//Seraph
$ItemMax[earmor, WaveGun] = 1;		//Slave
$ItemMax[efemale, WaveGun] = 1;		//Slave
$ItemMax[marmor, WaveGun] = 1;		//Pawn
$ItemMax[aarmor, WaveGun] = 1;		//Navigator
$ItemMax[darmor, WaveGun] = 1;		//Atomizer
$ItemMax[barmor, WaveGun] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

RocketData Shock 
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $MissileDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0; //350
	muzzleVelocity = 50.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
}; 



ItemImageData WaveGunImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 40;
	maxEnergy = 45;
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData WaveGun 
{
	description = "Proton Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = WaveGunImage;
	price = 77;
	showWeaponBar = true;
}; 

//WaveGunImage weaponkickback(player,10);
//{
//%client = GameBase::getOwnerClient(%player); 
//%trans = GameBase::getMuzzleTransform(%player); 
//%vel = Item::getVelocity(%player); 
//%energy = GameBase::getEnergy(%player);
// %energy -= 40;
//%newObj = Projectile::spawnProjectile("shock", %trans, %player, %vel);
////ixApplyKickback
//}


function WaveGun::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Proton Cannon", 2); }
