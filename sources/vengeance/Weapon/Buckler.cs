
// Vengeance mod built on Annihilation 3 code
// By Plasmatic
// www.annihilation.info/plasmatic
// icq 77161332

// all code by Plasmatic 
// aka Steve Madden
// copyright 2004
// Buckler

// Hack in player::ondamage to remount this beast when it returns -Plasmatic

$InvList[Buckler] = 1;
$MobileInvList[Buckler] = 1;
$RemoteInvList[Buckler] = 1;

//	$InvList[BucklerShells] = 1;
//	$MobileInvList[BucklerShells] = 1;
//	$RemoteInvList[BucklerShells] = 1;

$AutoUse[Buckler] = false;
//	$WeaponAmmo[Buckler] = BucklerShells;
//	$SellAmmo[BucklerShells] = 5;

addWeapon(Buckler);
//	addAmmo(Buckler, BucklerShells, 5);

SeekingMissileData BucklerFrisbee
{
	bulletShapeName = "shield.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;	//0.5
	damageType = $SoulDamageType;
	explosionRadius = 15.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 30.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 1.5;
	nonSeekingTurningRadius = 1.5;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 1.25;
	soundId = SoundJetHeavy;
};
RocketData BucklerDumb
{
	bulletShapeName = "shield.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.125;
	damageType = $SoulDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 75.0;
	muzzleVelocity = 45.0;
	terminalVelocity = 50.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 1.0;
	// rocket specific
	trailType = 2; // smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};
ItemImageData BucklerAImage 
{
	shapeFile = "shield";
	mountPoint = 0;
	weaponType = 0;
//	ammoType = BucklerShells;
//	projectileType = MortarShell;
	mountOffset = { 0.0, -0.095, -0.15};		// 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
	mountRotation = {0.0, 3.14, 0.0};		// ?, around gun barrel, ?
	accuFire = false;
	reloadTime = 0.1;	//0.28;
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

ItemData BucklerA
{
	description = "Buckler";
	shapeFile = "shield";
	hudIcon = "ammopack";
	className = "EyeCandy";	//className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BucklerAImage;
	showWeaponBar = true;
	price = 85;
};
SoundData SoundBucklerReload
{
	wavFileName = "mortar_reload.wav";
	profile = Profile3dNear;
};

//-------------------------------------------------------------------------------	
// fakey weapon shape for speed pack compatibility
ItemImageData BucklerImage
{
	shapeFile = "breath";	//breath";	//bullet";
	mountPoint = 0;
	weaponType = 0;
//	ammoType = BucklerShells;

	mountOffset = { 0.0, 0.5, 0.0};	//mountOffset = { 0.0, 0.095, -0.15};		// 0.07, -0.05, 0.01 };//right, forward, up	//0.1, 0.25, 0.01
//	mountRotation = {0.0, 3.14, 0.0};		// ?, around gun barrel, ?
	accuFire = true;
	
	reloadTime = 0.01;	//0.1
	fireTime = 0.01;	//0.25;
	
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
};

ItemData Buckler
{
	description = "Buckler";
	className = "Weapon";
	shapeFile = "shield";
	hudIcon = "ammopack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BucklerImage;
	price = 175;
	showWeaponBar = true;
};
//-------------------------------------------------------------------------------

function Buckler::MountExtras(%player,%weapon) 
{	
	Player::mountItem(%player,BucklerA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Throw this shield for Ginsu action..");
}
// crazy aussies.. 
function BucklerImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	if(!%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)])
	{
		if(Player::getMountedItem(%player,$SpareSlot1) == BucklerA)	//cant throw it if we don't have it.. -Plasmatic
		{	
			Player::trigger(%player, $SpareSlot1,true);
			%player.WeaponReloading[Player::getMountedItem(%player,$WeaponSlot)]= true;
			schedule("Player::trigger("@%player@","@ $SpareSlot1@", false);",0.01);
			Weapon::SpeedPackCheck(%player,Player::getMountedItem(%player,$WeaponSlot),0.5);	//fast reload, dependent on image..
			
		//	Player::decItemCount(%player,$WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)],1);
	
			%vel = Item::getVelocity(%player);
			// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
			if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
			{	
				%trans = GameBase::getMuzzleTransform(%player);
				GameBase::playSound(%player, SoundThrowItem, 0);
				
			//	schedule("GameBase::playSound("@%player@", SoundBucklerReload, 0);",2.0 );
					
				%newObj = Projectile::spawnProjectile("BucklerDumb",%trans,%player,%vel);	// Seeker, seek thy master.. -Plasmatic
				%newObj.Owner = %player;
				%newObj.ReturnTime = 12;	// in 0.125 second chunks
				schedule("Buckler::Steer(" @ %newObj @ ", " @ %player @ ",true);", 0.5);
				%player.BucklerRockets++;
				
				Player::unmountItem(%player,$SpareSlot1);
			}
			else 	
				echo("!! Butterfly Error, Rocket Pod Photon. vel ="@%vel);
		}

	}
}


function Buckler::Steer(%obj,%this,%start)
{
	if($debug)
		echo("Buckler::Steer "@%obj@", "@%this@", "@%start);
	
	%type = getObjectType(%obj);
//	echo(%type);
	%position = GameBase::getPosition(%obj);
	
	if(%position == "0 0 0")
	{
		Buckler::return(%this);
		return;
	}	
//	echo("buckler return "@%Obj.ReturnTime@", "@%position);
	if(Player::isDead(%this) || (%type != "SeekingMissile" && !%start))	//%distFromOwner > 1000 ||  || Player::getMountedItem(%this,$WeaponSlot) != RocketPod
	{
		return;	
	}

		
	%oldDir = %obj.appliedDir;
		
	%trans = GameBase::getMuzzleTransform(%this);	
	//figure out general relativity, Einstein..
		%d1= getWord(%trans,3);		//sideways
		%d2= getWord(%trans,4);		//sideways
		%d3= getWord(%trans,5);		//up-down	3,4,5 are dir vec -plas	 
	
	if(%start)
	{
//		echo("start buckler steer");
		// Remember projectile velocity (based on inherited velocity) -Plasmatic
		%vel = Item::getVelocity(%obj);
		//%obj.initialspeed = vector::getdistance("0 0 0",%vel);	
		
		%initialspeed = vector::getdistance("0 0 0",%vel);
		%returnTime = %Obj.ReturnTime;
		
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			deleteObject(%obj);			
			%trans = GameBase::getMuzzleTransform(%this);
	
			%trans1= getWord(%trans,0);
			%trans2= getWord(%trans,1);
			%trans3= getWord(%trans,2);
			%trans4= getWord(%trans,3);
			%trans5= getWord(%trans,4);
			%trans6= getWord(%trans,5);
			%trans7= getWord(%trans,6);
			%trans8= getWord(%trans,7);
			%trans9= getWord(%trans,8);
			%trans10=getWord(%trans,9);
			%trans11=getWord(%trans,10);
			%trans12=getWord(%trans,11);
		
			%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %position;	
			%Obj = Projectile::spawnProjectile("BucklerFrisbee",%newtrans,%this,%vel);				
			
			%obj.initialspeed = %initialspeed;	
			%obj.ReturnTime = %returnTime;
			%this.lastBuckler = %obj;
		}
		else 	
			echo("!! Butterfly Error, Rocket Pod Start. vel ="@%vel);							
	}
	
	%change = vector::getdistance(%olddir,%dir);
	%return = %Obj.ReturnTime;
	%Obj.ReturnTime = %return -1;	

	%mult = %obj.initialspeed;
	if(%return >0)
	{
		%wang = 1.5;	// steer ratio -Plasmatic
		%x =%d1 * %wang;
		%y =%d2 * %wang;
		%z =%d3 * %wang;
		
		%look =  %x@" "@%y@" "@%z;
		%repulse = vector::normalize(vector::sub(getboxcenter(%obj),getboxcenter(%this)));

		%vec = vector::normalize(vector::sub(%look,%repulse));	
		%newVel = vector::scale(%vec,%mult);		
	}
	else if(%return < -25)
	{
//		echo("Delete Buckler "@%obj);
		deleteObject(%obj);
		buckler::return(%this);
		return;
	}
	else
	{	

		//echo("steer"@%olddir);
		%wang = 0.75;	// steer ratio -Plasmatic
		%x =%d1 * %wang;
		%y =%d2 * %wang;
		%z =%d3 * %wang;
		
		%look =  %x@" "@%y@" "@%z;
		%seek = vector::normalize(vector::sub(getboxcenter(%this),getboxcenter(%obj)));
		if(vector::getdistance(getboxcenter(%this),getboxcenter(%obj)) > 5)
			%vec = vector::normalize(vector::add(%seek,%look));
		else
		{
		//	// eliminates projectile freakyness -Plasmatic
		//	%vec = %seek;
		//	%newVel = vector::scale(%vec,%mult*3);
		//	Item::setVelocity(%obj,%newvel);
		//	%obj.home = true;
		//	return;
		
	//		echo("Delete Buckler "@%obj);
			deleteObject(%obj);
			buckler::return(%this);	
			return;	
		
		
		}
				
		%newVel = vector::scale(%vec,%mult);					
					
	}
			
	%obj.appliedDir = %vec;
		Item::setVelocity(%obj,%newvel);		
		
	if((%this.lastBuckler) == %obj)
		schedule("Buckler::Steer(" @ %obj @ ", " @ %this @ ");", 0.125);
	
}


function Buckler::return(%player)
{
	if(Player::getMountedItem(%player,$WeaponSlot) == Buckler && Player::getMountedItem(%player,$SpareSlot1) != BucklerA)
	{
		client::sendmessage(Player::getClient(%player),1,"~wmine_act.wav");
		Buckler::MountExtras(%player,Buckler);	
	}
}
//Tribes 1 version of vectorScale -Plasmatic
function Vector::scale(%vec,%mult)
{
	%x = getWord(%vec, 0) * %mult;
	%y = getWord(%vec, 1) * %mult;
	%z = getWord(%vec, 2) * %mult;
	
	return %x@" "@%y@" "@%z;		
}