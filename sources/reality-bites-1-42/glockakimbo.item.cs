
$InvList[GlockAkimbo] = 1;
$RemoteInvList[GlockAkimbo] = 1;
$InvList[GlockAkimboAmmo] = 1;
$RemoteInvList[GlockAkimboAmmo] = 1;
$HelpMessage[GlockAkimbo] = "A glock for each hand.  It is you, John Woo!";


SoundData SoundGlockAkimbo
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData GlockAkimboPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.40;
   damageType         = $BulletDmgType15;

   aimDeflection      = 0.002;
   muzzleVelocity     = 800.0;
   totalTime          = 2.5;
   inheritedVelocityScale = 0.5;
   isVisible          = False;

   tracerPercentage   = 0.1;
   tracerLength       = 1;


};


$ItemMax[hlarmor, GlockAkimbo] = 0;
$ItemMax[hlfemale, GlockAkimbo] = 0;
$ItemMax[marmor, GlockAkimbo] = 1;
$ItemMax[mfemale, GlockAkimbo] = 1;
$ItemMax[larmor, GlockAkimbo] = 0;
$ItemMax[lfemale, GlockAkimbo] = 0;
$ItemMax[earmor, GlockAkimbo] = 1;
$ItemMax[efemale, GlockAkimbo] = 1;
$ItemMax[harmor, GlockAkimbo] = 1;
$ItemMax[uharmor, GlockAkimbo] = 1;

 addPluginWeapon(LaserRifle, GlockAkimbo);
 $AutoUse[GlockAkimbo] = True;

 $WeaponAmmo[GlockAkimbo] = GlockAmmo;



ItemImageData GlockAkimboImage
{
	shapeFile = "breath";
	mountPoint = 0;
	mountOffset = { -0.4, -0.5, 0.3 };
	weaponType = 1; // Single Shot
	// projectileType = GlockPellet;

	spinUpTime = 0.0;
	spinDownTime = 0.2;

	ammoType = GlockAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 1.0;
	
	lightType = 3; // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0, 0, 1 };

	// sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData GlockAkimbo
{
	description = "Akimbo-Style Glocks";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = GlockAkimboImage;
	price = 250;
	showWeaponBar = true;
};

function GlockAkimbo::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Glock, Akimbo style - a 9mm Glock for each hand.", 2);
	}
}

function GlockAkimboImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Glock]);

		if(%AmmoCount)
		{
			
			Player::trigger(%player,7,true);    
			Player::trigger(%player,7,false);   
			schedule("SecondShot(" @ %player @ ");", 0.5);

			
		}
		else
		{
			playSound(SoundWeaponClick,GameBase::getPosition(%player));
			Player::trigger(%player,0,false);			
		}

}
 
function Secondshot(%player)
{
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
			%client = GameBase::getOwnerClient(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%fired = (Projectile::spawnProjectile("GlockAkimboPellet",%trans,%player,%vel));
}

ItemImageData GlockAkimboClipImage
{
	shapeFile  = "paintgun";
	mountPoint = 0;
	mountRotation = {0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.9, 0.0, -0.0 };
	ammoType = GlockAmmo;
	reloadTime = 0.0;
	fireTime = 0.0;

	// projectileType = GlockAkimboPellet;
	accuFire = true;

	sfxFire = debrisMediumExplosion;
	//sfxActivate = SoundPickUpWeapon;
};

ItemData GlockAkimboClip
{
	heading = "cSecondary Weapons";
	description = "GlockAkimboClip";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = GlockAkimboClipImage;
	price = 50;
	showWeaponBar = true;
};


// 


function GlockAkimboClip::onMount(%player,%item)
{

	
}


function GlockAkimbo::onMount(%player,%item)
{
	Player::MountItem(%player,Glock,7);
	Player::MountItem(%player,GlockAkimboClip,6);
}
function GlockAkimbo::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}
