//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Titan);
$InvList[Titan] = 1;

$AutoUse[Titan] = True;
$WeaponAmmo[Titan] = "";

$ItemMax[larmor, Titan] = 0;		//Seraph
$ItemMax[lfemale, Titan] = 0;		//Seraph
$ItemMax[earmor, Titan] = 0;		//Slave
$ItemMax[efemale, Titan] = 0;		//Slave
$ItemMax[marmor, Titan] = 0;		//Pawn
$ItemMax[aarmor, Titan] = 0;		//Navigator
$ItemMax[darmor, Titan] = 0;		//Atomizer
$ItemMax[barmor, Titan] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++




//blue_blink4

LaserData Nuclearbeam
{	laserBitmapName = "blue_blink4.bmp"; //lightningNew  blue_blink4  zap03
	hitName = "enex.dts";//fusionex.dts laserhit  //fusionbolt  //enex
	damageConversion = 0.0138;
	DamageType = $ElectricityDamageType;
	beamTime = 1.0;
	lightRange = 2.0;
	lightColor = { 0.25, 0.25, 0.85 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit; //SoundFlierCrash
};

RocketData SniperShell
{
   bulletShapeName = "enex.dts";
  explosionTag    = turretExp;//rocketExp;bulletExp1
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.56;
   damageType       = $ElectricityDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 1;
   trailWidth  = 0.05;
//   soundId = SoundDiscSpin;
};

RocketData SniperShell2
{
   bulletShapeName = "enex.dts";
  explosionTag    = Shockwave;//rocketExp;bulletExp1
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.58;
   damageType       = $ElectricityDamageType;//$ExplosionDamageType;
   explosionRadius  = 0.5;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 0.0;
   totalTime        = 0.5;
   liveTime         = 0.5;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   // rocket specific
   trailType   = 1;
   trailLength = 1;
   trailWidth  = 0.05;
//   soundId = SoundDiscSpin;
};

//ItemImageData TitanImage 
//{
//	shapeFile = "shotgun";
//	mountPoint = 0;
//	mountRotation = { 0, 3.1416, 0};
//	mountOffset = { 0 , 0, -0.1 };
//	weaponType = 0;
//	projectileType = Nuclearbeam;
//	accuFire = true;
//	reloadTime = 1.5;
//	fireTime = 3.0;
//	minEnergy = 290;
//	maxEnergy = 300;
//	lightType = 3;
//	lightRadius = 2;
//	lightTime = 1;
//	lightColor = { 0, 0, 0 };
//	sfxFire = SoundFireLaser;
//	sfxActivate = SoundPickUpWeapon;
//}; 

SoundData SoundNegatronFire
{	wavFileName = "targetlaser.wav";  
	profile = Profile3dFar;
};

ItemImageData TitanImage 
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0};
	mountOffset = { 0 , 0, -0.1 };
	weaponType = 1; //0
	//projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 2;
	fireTime = 0.001;//5
	//
	spinUpTime = 0.001;//3
	spinDownTime = 0.001;//3
	//

	minEnergy = -20;//140
	maxEnergy = -10;//150
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	//sfxFire = SoundFireLaser;
	//sfxActivate = SoundPickUpWeapon;
		
	sfxFire = SoundNegatronFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = ForceFieldOpen;
	sfxSpinDown = ForceFieldClose;
}; 



ItemImageData TitanImage2 
{
	shapeFile = "grenammo";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.1416};
	mountOffset = { 0 , 0.2, -0.07 };
	weaponType = 0;
	projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = -40;
	maxEnergy = -30;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData TitanImage3 
{
	shapeFile = "shieldPack";
	mountPoint = 0;
	mountRotation = { 0, 0, 1.57};
	mountOffset = { 0.15 , 0.04, -0.05 };
	weaponType = 0;
	projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = 290;
	maxEnergy = 300;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemImageData TitanImage4 
{
	shapeFile = "shieldPack";
	mountPoint = 0;
	mountRotation = { 0, 0, -1.57};
	mountOffset = { -0.15 , 0.04, -0.05 };
	weaponType = 0;
	projectileType = Nuclearbeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 3.0;
	minEnergy = 290;
	maxEnergy = 300;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData Titan 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage;
	price = 777;
	showWeaponBar = true;
};

ItemData Titan 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage;
	price = 777;
	showWeaponBar = true;
};

ItemData Titan2 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage2;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Titan3 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage3;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Titan4 
{
	description = "Negatron Beam";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TitanImage4;
	price = 777;
	showWeaponBar = false;
	showinventory = false;
};



function charger(%player)
	{
//	if (%player.lasercharging != "True") return;
	if (%player.reloading == "True") return;

	if (Player::isTriggered(%player,$WeaponSlot)){
		%player.Charge ++ ;	//0.1
if (%player.Charge > 50 ) %player.Charge = 50;

		%player.lasercharging = "True";
		schedule("charger(" @ %player @ ");",0.1); 
	%energy = GameBase::getEnergy(%player);
 	%energy -= 5;
	GameBase::setEnergy(%player,%energy);
%client = GameBase::getOwnerClient(%player);
bottomprint(%client, "<jc><f2>"@%player.Charge@"                                        "@%player.Charge, 0.5);
		}
	if (!Player::isTriggered(%player,$WeaponSlot)){
		%trans = GameBase::getMuzzleTransform(%player);
		//centerprint(%client, "bite me", 1);
		%vel = Item::getVelocity(%player);
		%smack = %player.Charge / 10;
	playSound(SoundFireLaser, GameBase::getPosition(%player));
	if (%smack < 2) playSound(SoundNegatronFire, GameBase::getPosition(%player));
	if (%smack >= 2) playSound(SoundNegatronFire, GameBase::getPosition(%player));
	if (%smack >= 3) playSound(SoundNegatronFire, GameBase::getPosition(%player));
	
	//sfxFire = SoundNegatronFire;
	//sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = ForceFieldOpen;
	//sfxSpinDown = ForceFieldClose;
	
	Player::trigger(%player, 4, true);
	Player::trigger(%player, 6, true);
	Player::trigger(%player, 7, true);
	//Projectile::spawnProjectile("Nuclearbeam", %trans, %player, %vel);

		for(%i=0; %i < %smack; %i += 1) //+= 1
		{
			Projectile::spawnProjectile("SniperShell", %trans, %player, %vel);
			//Projectile::spawnProjectile("SniperShell2", %trans, %player, %vel);
			}
		%player.Charge = 0;
		//Player::decItemCount(%player,$WeaponAmmo[PlasmaticGun],1); 
		%player.lasercharging = "";
		%player.reloading = "True";
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);
		Player::trigger(%player, 7, false);
		schedule("reload(" @ %player @ ");",2.0); 
		WeaponKickBack(%player,%smack);
		}

}

function TitanImage::onfire(%player) 
	{	
		if (%player.lasercharging) return;

		%player.Charge = 0;
		charger( %player );
	}

function reload(%player) {
			%player.reloading = "";
		//echo("ready");
		playSound(MortarReload, GameBase::getPosition(%player));
		}



$TitanSlotA=4;
$TitanSlotB=7;
$TitanSlotC=6;

//function Titan::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	if(Player::getMountedItem(%player,$BackpackSlot) == IonPack)
//	Weapon::onUse(%player,%item);
//	%client = Player::getclient(%player);
//        bottomprint(%client, "<jc><f2>Negatron Beam");
//
//	Player::mountItem(%player,Titan2,$TitanSlotA); 
//	Player::mountItem(%player,Titan3,$TitanSlotB);
//	Player::mountItem(%player,Titan4,$TitanSlotC);
//
//}

function Titan::onUse(%player,%item, $WeaponSlot)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == IonPack)
	{
	Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Negatron Beam", 2);
	Player::mountItem(%player,Titan2,$TitanSlotA); 
	Player::mountItem(%player,Titan3,$TitanSlotB);
	Player::mountItem(%player,Titan4,$TitanSlotC);
	}
	//Client::sendMessage(%client,0,"Must have Ion Gen to use Negatron Beam");
}

function Titan::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$TitanSlotA); 
	Player::unmountItem(%player,$TitanSlotB); 
	Player::unmountItem(%player,$TitanSlotC); 
}

//function Titan::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	if(Player::getMountedItem(%player,$BackpackSlot) == IonPack)
//	Weapon::onUse(%player,%item);
//	%client = Player::getclient(%player);
//        bottomprint(%client, "<jc><f2>Negatron Beam");
//	//Player::mountItem(%player,nukesi,$NukesSlotA);
//	
//
//}