// all code by Plasmatic 
// aka Steve Madden
// copyright 2004
// RocketPod

$InvList[RocketPod] = 1;
$MobileInvList[RocketPod] = 1;
$RemoteInvList[RocketPod] = 1;

$InvList[RocketPodShells] = 1;
$MobileInvList[RocketPodShells] = 1;
$RemoteInvList[RocketPodShells] = 1;

$AutoUse[RocketPod] = false;
$WeaponAmmo[RocketPod] = RocketPodShells;
$SellAmmo[RocketPodShells] = 15;

addWeapon(RocketPod);
addAmmo(RocketPod, RocketPodShells, 5);

BulletData PodDumbRocket 
{
	bulletShapeName = "rocket.dts";
	explosionTag = ShotExp;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.07;
	damageType = $ShotgunDamageType;
	kickBackStrength = 40.0;
	aimDeflection = 0.1;	//0.02;
	muzzleVelocity = 25.0;
	acceleration = 5.0;
	totalTime = 5.0;
	inheritedVelocityScale = 1.0;
	isVisible = true;
	tracerPercentage = 5.0;	//1.0
	tracerLength = 30;
};

RocketData PodSmartRocket
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 250.0;
	muzzleVelocity = 25.0;
	terminalVelocity = 25.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 15.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 1.0;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};



ItemData RocketPodShells 
{
	description = "Rocket Pod Rockets";
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

ItemImageData RocketPodImage 
{
	shapeFile = "chaingun";	//shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 1;		//0 single, 1 rotating, 2 sustained, 3disc
	ammoType = RocketPodShells;
	
	mountOffset = { -0.1, 0, 0.1 };	//right, forward, up
	mountRotation = {0, 2.57, 0};	//up, right, around player axis
	
	reloadTime = 0;
	spinUpTime = 0.75;
	spinDownTime = 3;
	fireTime = 0.25;	
	
	//reloadTime = 0.10;
	accuFire = false;
//	fireTime = 0.25;
	sfxFire = SoundFireSeeking;	//SoundFireGrenade;	//sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RocketPod 
{
	description = "Rocket Pod";
	shapeFile = "grenadeL";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RocketPodImage;
	showWeaponBar = true;
	price = 85;
};

function RocketPod::MountExtras(%player,%weapon) 
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Sends a battery of rockets swarming towards your target.");
}

function RocketPodImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
//	for(%i=0; %i<6; %i++)
//	{
//	if(%player.RocketPodRockets <6)
//	{
		%newObj = Projectile::spawnProjectile("PodDumbRocket",%trans,%player,%vel);
		schedule("SteerRocketPod(" @ %newObj @ ", " @ %player @ ",true);", 0.5);
		%player.RocketPodRockets++;
		Player::decItemCount(%player,$WeaponAmmo[RocketPod],1);
//	}

	

}
function SteerRocketPod(%obj,%this,%start)
{
	%position = GameBase::getPosition(%obj);
	%distFromOwner = vector::getdistance(GameBase::getPosition(%this),%position);
	echo("position ?"@%position);
	if(%position == "0 0 0" || %distFromOwner > 100)
	{
		if(Player::getItemCount(%this,RocketPodShells)<6)
			Player::IncItemCount(%this,RocketPodShells,1);
	//	if(%this.RocketPodRockets > 0 )
	//		%this.RocketPodRockets--;
	}
	
	if(Player::isDead(%this))
		return;
		
		//grab some info from player, biaaatch!
		%trans = GameBase::getMuzzleTransform(%this);
		%position = GameBase::getPosition(%obj);	
		%rotation = GameBase::getRotation(%obj);
		%oldDir = %obj.appliedDir;
		
	//	deleteobject(%obj);				// beleted!
		%t1= getWord(%trans,0);
		%t2= getWord(%trans,1);
		%t3= getWord(%trans,2);
			%top = %t1@" "@%t2@" "@%t3;
	//		echo("norm = "@vector::normalize(%top));
		%f1= getWord(%trans,6);
		%f2= getWord(%trans,7);
		%f3= getWord(%trans,8);
			%end = %f1@" "@%f2@" "@%f3;
		%d1= getWord(%trans,3);
		%d2= getWord(%trans,4);
		%d3= getWord(%trans,5);		//3,4,5 are dir vec.
			%dir = %d1@" "@%d2@" "@%d3;
	//		echo("norm = "@vector::normalize(%top)@" dir="@%dir@" end=" @vector::normalize(%end) );
		
		if(%start)
			%change = 0;
		else 
			%change = vector::getdistance(%olddir,%dir);
		if(%change < 0.65)
		{
			deleteobject(%obj);
			%newtrans =  %top@ " " @ %dir @ " " @ %end @ " " @ %position;
			%newobj = Projectile::spawnProjectile("PodSmartRocket", %newtrans, %this, 0);	
			%newobj.appliedDir = %dir;
			%newobj.owner = %this;
			schedule("SteerRocketPod(" @ %newobj @ ", " @ %this @ ");", 1);
		//	schedule("RocketPod::newRocket(" @ %newTrans @ ", " @ %this @ ");", 0.1);
		}
		else
		{
			if(Player::getItemCount(%this,$WeaponAmmo[RocketPod])<6)
				Player::IncItemCount(%this,RocketPodShells,1);	
		//	if(%this.RocketPodRockets > 0 )
		//		%this.RocketPodRockets--;			
			
		}
		
		//	bottomprintall("<jc>"@%change);	//%dir@", "@%aim);
}

function RocketPod::newRocket(%newtrans, %this)
{
	echo("new rocket");
	
	//%trans = GameBase::getMuzzleTransform(%this);
	
	%newobj = Projectile::spawnProjectile("PodSmartRocket", %newtrans, %this, 0);	
	%newobj.appliedDir = %dir;
	%newobj.owner = %this;
	schedule("SteerRocketPod(" @ %newobj @ ", " @ %this @ ");", 1);	
}

function RepaceRocketPod(%obj,%this)
{
	%Pos = GameBase::getPosition(%obj); 
	%vel = Item::getVelocity(%obj);
// Pretty shell split
	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%Obj);
 	%newobj = Projectile::spawnProjectile("DiscShell", %trans, %player, %vel);
 	//GameBase::setRotation(%newobj,GameBase::getRotation(%obj));
//	Projectile::spawnProjectile(%newobj);
	//GameBase::setPosition(%newobj, %pos);
	//Item::setVelocity(%newobj, %vel);
}



