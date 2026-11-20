
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332

// all code by Plasmatic 
// aka Steve Madden
// copyright 2004
// Reworked July 2004
// RocketPod

//Tribes 1 version of vectorScale -Plasmatic
function Vector::scale(%vec,%mult)
{
	%x = getWord(%vec, 0) * %mult;
	%y = getWord(%vec, 1) * %mult;
	%z = getWord(%vec, 2) * %mult;
	
	return %x@" "@%y@" "@%z;		
}

$InvList[RocketPod] = 1;
$MobileInvList[RocketPod] = 1;
$RemoteInvList[RocketPod] = 1;

$InvList[RocketPodShells] = 1;
$MobileInvList[RocketPodShells] = 1;
$RemoteInvList[RocketPodShells] = 1;

$AutoUse[RocketPod] = false;
$WeaponAmmo[RocketPod] = RocketPodShells;
$SellAmmo[RocketPodShells] = 5;

// addWeapon(RocketPod);
addAmmo(RocketPod, RocketPodShells, 5);

$oundReload[RocketPodImage] = SoundPodReload;



SeekingMissileData PodSwarmer
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.25;	//0.5
	damageType = $OSMissileDamageType;
	explosionRadius = 15.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 60;	//40.0;	 	// we're setting velocity later so ignore this.. -Plasmatic
	totalTime = 12;
	liveTime = 12;
	seekingTurningRadius = 7.5;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 0.5;	//10.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;	//inheritedVelocityScale = 1.0;
	soundId = SoundJetHeavy;
};

//====================================================
ItemData RocketPodShells 
{
	description = "Pod Rockets";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};
MineData RocketPodShellsBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};
//===============================================
ItemImageData RocketPodImage 
{
	shapeFile = "mortargun";


	
//	projectileType = MortarShell;
	mountOffset = { -0.1, -0.1 , -0.1 };	//right, forward, up
	mountRotation = {0, 1.77, 0};	//up, right, around player axis
	mountPoint = 0;
	weaponType = 0;
	ammoType = RocketPodShells;
//	projectileType = MortarShell;
//	mountOffset = { -0.1, -0.1 , -0.1 };	//right, forward, up
//	mountRotation = {0, 1.77, 0};	//up, right, around player axis
	accuFire = true;	//false;
	reloadTime = 3.0;	//0.1;	//0.28;
	fireTime = 0.1;	//6.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
//	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
//	sfxReady = SoundUseAmmoStation;	//SoundElevatorBlocked;	//SoundMortarIdle;
};

ItemData RocketPod
{
	description = "Rocket Pod";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RocketPodImage;
	showWeaponBar = true;
	price = 85;
};


//===============================================

//-------------------------------------------------------------------------------

function RocketPod::MountExtras(%player,%weapon) 
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Sends a battery of rockets swarming towards your target.");
}

function RocketPodImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
//	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
//	{
	//	Player::trigger(%player, $SpareSlot1,true);
		%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
		schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.1);
	//	Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),3.5);

		if(Player::getMountedItem(%player,$BackpackSlot) != TankPack) 		
			Player::decItemCount(%player,$WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)],1);
		
		for(%i=0; %i<6; %i++)
		{
			schedule("RocketPod::PhotonTorpedo("@%player@");", %i/5 );
		}
//	}
}

// Yep, these things are grenade types that we're changing velocity (direction) on. 
// I did this to eliminate any vehicle related screwyness with the old style flier method.
// Fliers (vehicle) and Grenade type (Mortar and grenade launcher) are the only projectile
// type things in tribes that you can change direction with. 
// Mine types (mine and hand grenade) can also be manipulated, but Tribes applies gravity.
// Vehicles can create stability problems, so that leaves us with grenade type.. 
// It may look like jumping dolphins, but effective -Plasmatic
// ok, scratch that.
// Looks like seeking missiles can be redirected by messing with velocity. Go figure.
// This is actually what I wanted, but didn't try messing with velocity to change direction untill after I tried Mine types.
//
// Tribes bitchslapped by Plasmatic.


function RocketPod::Steer(%obj,%this,%start)
{
//	if($debug)
//		echo("RocketPod::Steer "@%obj@", "@%this@", "@%start);

	%type = getObjectType(%obj);
	%position = GameBase::getPosition(%obj);

	if(%position == "0 0 0")
		return;	
	if(Player::isDead(%this) || (%type != "SeekingMissile" && !%start) || (Player::getMountedItem(%this,$WeaponSlot) != RocketPod && Player::getMountedItem(%this,$BackpackSlot) != TankPack))	//%distFromOwner > 1000 || 
		return;

		
	%oldDir = %obj.appliedDir;
		
	%trans = GameBase::getMuzzleTransform(%this);	
	//figure out general relativity, Einstein..
		%d1= getWord(%trans,3);		//sideways
		%d2= getWord(%trans,4);		//sideways
		%d3= getWord(%trans,5);		//up-down	3,4,5 are dir vec -plas	 

	%dir = %d3@" "@%d1@" "@%d2;	//vector::add(GameBase::getRotation(%this),%d3@" 0 0");	// 2.4	
	%change = vector::getdistance(%olddir,%dir);
	if(%start)
	{
//		echo("start pod steer");
		// Remember projectile velocity (based on inherited velocity) -Plasmatic
		%vel = Item::getVelocity(%obj);		
		%initialspeed = vector::getdistance("0 0 0",%vel);
			
		%obj.initialspeed = %initialspeed;
		%obj.appliedDir = %dir;
		schedule("RocketPod::Steer(" @ %obj @ ", " @ %this @ ");", 0.125);
				
	}	
	else if(%change < 0.5 || %start)
	{
		%wang = 40.0;	//1.25;	//1.5;	// steer ratio, higher = less response -Plasmatic
		%x =%d1 * %wang;
		%y =%d2 * %wang;
		%z =%d3 * %wang;
		
		%look =  %x@" "@%y@" "@%z;
		%repulse = vector::normalize(vector::sub(getboxcenter(%obj),getboxcenter(%this)));
		%vec = vector::normalize(vector::sub(%look,%repulse));	
		%mult = %obj.initialspeed;
		%newVel = vector::scale(%vec,%mult);	
			
		%obj.appliedDir = %dir;
		Item::setVelocity(%obj,%newvel);		
		
		schedule("RocketPod::Steer(" @ %obj @ ", " @ %this @ ");", 0.125);
	}
	else
	{		
		//client::sendmessage(Player::getclient(%this),1,%change@"~wmine_act.wav");
	}
	
}


function RocketPod::PhotonTorpedo(%player) 
{	
	%vel = Item::getVelocity(%player);
	// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
	if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
	{						
		%trans = GameBase::getMuzzleTransform(%player);
		GameBase::playSound(%player, SoundFireSeeking, 0);

		
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
		
		if(Player::getMountedItem(%player,$BackpackSlot) == TankPack)
		{
			%ppos = gamebase::getposition(%player);
			%rot = gamebase::getrotation(%player);
			%vec = Vector::getFromRot(%rot);
			%pos = Vector::add(%ppos,-getWord(%vec,1)*1/8 @" "@ getWord(%vec,0)*1/8 @" 2.15");
			%pos = vector::add(%pos,%vec);
		}
		else
			%pos = %trans10 @" "@ %trans11 @" "@ %trans12;

		// random proj code yanked from Sex mod -plasmatic
		// modified with %skew
		%skew = 20;	//15;	// needs to be reduced when maxLevelFlightDist is reduced.. (ignore this..  -Plasmatic)
		%xrnd = (floor(getRandom() *(%skew*2+1))-%skew)/100;	// %xrnd = (floor(getRandom() *21)-10)/100;
		%yrnd = (floor(getRandom() *(%skew*2+1))-%skew)/100;
		%zrnd = (floor(getRandom()  *(%skew*2+1))-%skew)/100;
		%trans1= getWord(%trans,0);
		%trans2= getWord(%trans,1);
		%trans3= getWord(%trans,2);
		%trans4= getWord(%trans,3) + %xrnd;
		%trans5= getWord(%trans,4) + %yrnd;
		%trans6= getWord(%trans,5) + %zrnd;
		%trans7= getWord(%trans,6);
		%trans8= getWord(%trans,7);
		%trans9= getWord(%trans,8);
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
	
		%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %pos;	
		//%newObj = Projectile::spawnProjectile("PodSwarmer",%newtrans,%player,%vel);	//PodSwarmer		
		%newObj = Projectile::spawnProjectile("BasicRocket",%newtrans,%player,%vel);	//PodSwarmer		
		%newobj.owner = %player;


		schedule("RocketPod::replace(" @ %newObj @ ", " @ %player @ ",true);", 0.125);
				
	}
	else 	
		echo("!! Butterfly Error, Rocket Pod Photon. vel ="@%vel);		
}

function Rocketpod::replace(%this,%player)
{
	%pos = gamebase::getposition(%this);
	%vel = Item::getVelocity(%this);
	%nvel = vector::normalize(%vel);

	// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
	if(%vel == 0 || %nvel != "-NAN -NAN -NAN")	
	{	
	
		%NewTrans = "1 0 0 "@ %nvel @" 0 0 1 "@ %pos;
//		messageall(3,%newtrans);
		deleteobject(%this);	
		%newObj = Projectile::spawnProjectile("PodSwarmer",%newtrans,%player,%vel);	//PodSwarmer		
			
		schedule("RocketPod::Steer(" @ %newObj @ ", " @ %player @ ",true);", 0.1);
	}
}