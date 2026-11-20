//================================================================
//NUKE
//================================================================

//===========================================

//================================================================
							
//================================================================
SoundData SoundWPNNuke
{
   wavFileName = "wpn_nuke.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNNukeIdle
{
   wavFileName = "wpn_nuke_idle.wav";
   profile = Profile3dCloseLoop;
};
SoundData NukeExplosion
{
	wavFilename = "exp_nuke.wav";
	profile = Profile3dFarFar;
};
SoundData SoundWhizNuke
{
   wavFileName = "whiz_nuke.wav";
   profile = Profile3dMediumLoop;
};
//================================================================
ExplosionData NukeExp
{
   shapeName = "fiery.dts";
   soundId   = NukeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 8.5;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 1.0, 0.5, 0.0 };
   colors[1]  = { 2.0, 1.0, 0.0 };
   colors[2]  = { 3.0, 1.5, 0.0 };
   radFactors = { 1.0, 0.75, 0.0 };
};
//=====================================================
RocketData Nukeproj
{
   bulletShapeName  = "proj_Rocket.dts";
   explosionTag     = NukeExp;
   collisionRadius  = 0.0;
   mass             = 3.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $FBWDamageType;

   explosionRadius  = 30;
   kickBackStrength = -500;
   muzzleVelocity   = 750;
   terminalVelocity = 250;
   acceleration     = 1;
   totalTime        = 10;
   liveTime         = 10;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.75;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 3.0;

   soundId = SoundWhizNuke;
};
BulletData InvisFBWRocket
{
	bulletShapeName  = "proj_Rocket.dts";
	explosionTag     = NukeExp;
	mass             = 0.1;
	
	damageClass      = 1;       
	damageValue      = 0.0;
	damageType       = $FBWDamageType;
	aimDeflection      = 0.0;
	kickBackStrength = 0.1;
	muzzleVelocity   = 0.1;
	totalTime        = 0.01;
	liveTime         = 0.01;
	inheritedVelocityScale = 1.5;
	
	soundId = SoundWhizNuke;
};

// BEGIN ADDED CODE
function FBWOutOfFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	Vehicle::dismount(%fbw, "0 0 0");
	remoteEval(%cl, BP, "<jc><f0>Nuke Out of Fuel", 2);
}
function FBWLowFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	remoteEval(%cl, BP, "<jc><f0>Nuke Low On Fuel", 3);
}
// END ADDED CODE

function InvisFBWRocket::onAdd(%this)
{
	%rot = GameBase::getRotation(%this);
	%pos = GameBase::getPosition(%this);
	%client = $clientID;
	$clientID = 0;
	
	//Spawn Rocket
	%obj = newObject("","Flier","FBWRocket",true);
	addToSet("MissionCleanup", %obj);
	$FBWClientID[%obj] = %client;
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
	//echo("$FBWClientID[%obj] - Proj onAdd ",$FBWClientID[%obj]);
	//Position
	GameBase::setPosition(%obj, %pos);
	GameBase::setRotation(%obj, %rot);
	//Set Controls
	Client::setControlObject(%client,%obj);
	
	// BEGIN ADDED CODE
	schedule("FBWLowFuel("@%obj@");", 12, %obj);
	schedule("FBWOutOfFuel("@%obj@");", 15, %obj);
	// END ADDED CODE
}
//================================================================
ItemData FBWRocketAmmo
{
	description = "Nuke Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

//-----------------
// 6/16/99 - 6:30PM
//-----------------
//FBW Rocket Launcher


ItemImageData FBWRocketLauncherImage
{
	shapeFile = "wpn_fbwlauncher";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = FBWRocketAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 1.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = SoundWPNNuke;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FBWRocketLauncher
{
	description = "Nuke Weapon";
	className = "Weapon";
	shapeFile = "wpn_fbwlauncher";
	hudIcon = "FBW";
	heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = FBWRocketLauncherImage;
	price = 1000;
	  showWeaponBar = false;
showInventory = true;
	   //validateShape = true;
         //validateMaterials = true;
};

function FBWRocketLauncherImage::onFire(%player, %slot) 
{
	%client = Player::getClient(%player);
	
	if ( $FBWRocketReload[%player] == TRUE )
	{
		remoteEval(%client, BP, "<jc><f0>Reloading...", 1);
		FBWRocketNoFireAnim(%player);
	}
	else
	{
		if ( !Player::isCrouching(%player) || Player::getLastContactCount(%player) > 0 )
		{
			remoteEval(%client, BP, "<jc><f0>Must Be Crouched to Fire Guided Nuke", 3);
			FBWRocketNoFireAnim(%player);
		}
		else
		{
			%item = "FBW";
			//echo("My Above Check ", CheckAboveMe(%player));
			if( CheckAboveMe(%player) == FALSE )
			{
				if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] )
				{
					%trans = LabRat::getMuzzleTransform(%player);
					%vel = Item::getVelocity(%player);
					$clientID = GameBase::getOwnerClient(%player);
					Projectile::spawnProjectile("InvisFBWRocket",%trans,%player,%vel);
					
					//Misc
					Player::decItemCount(%player, FBWRocketAmmo, 1);
					GameBase::playSound(%player , SoundWPNNuke, 0);
					$TeamItemCount[GameBase::getTeam(%client) @ %item]++;
					$FBWRocketReload[%player] = TRUE;
					schedule("$FBWRocketReload["@%player@"] = FALSE;", 2.5);
					schedule("FBWRocketNoFireAnim(" @%player@ ");", 0.05);
				}
				else
				{
					remoteEval(%client, BP, "<jc><f1>FREQUENCY OVERLOAD: <f0>To Many Nukes in Flight", 3);
					FBWRocketNoFireAnim(%player);
				}
			}
			else
			{
				remoteEval(%client, BP, "<jc><f1>LAUNCH ABORTED: <f0>Satellite Contact Blocked", 3);
				FBWRocketNoFireAnim(%player);
			}
		}
	}
}

function CheckAboveMe(%player)
{
	%rot = "1.570796 0 0";
	//Do LOS directly above player to see if building is found
	if(GameBase::getLOSInfo(%player,10000,%rot))
	{
		if( $los::object )
			return TRUE;
		else
			return FALSE;
	}
	else
		return FALSE;
}

function FBWRocketNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,FBWRocketLauncher,$WeaponSlot);
}


exec("lrgmt.cs");
exec(fbw_rocket);

//================================================================
//echo("Nuke Loaded");