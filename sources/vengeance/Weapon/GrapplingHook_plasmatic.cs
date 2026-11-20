
// all code by Plasmatic 
// aka Steve Madden
// copyright 2004

$InvList[GrapplingHook] = 1;
$MobileInvList[GrapplingHook] = 1;
$RemoteInvList[GrapplingHook] = 1;

$AutoUse[GrapplingHook] = False;
$WeaponAmmo[GrapplingHook] = "";

addWeapon(GrapplingHook);

SoundData GrapplingHookFire
{
	wavFileName = "turretfire2.wav";//door2.wav";//BXplo4.wav//Grenade.wav//rifle1.wav//turretfire2.wav
	profile = Profile3dFar;
};

LightningData GrapplingHookBolt
{	
	bitmapName = "lightningNew.bmp";
	damageType = $JailDamageType;
	boltLength = 50.0;
	coneAngle = 1.0;
	damagePerSec = 0.01;
	energyDrainPerSec = 0.0;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

ItemImageData GrapplingHookImage 
{
	shapeFile = "paintgun";	//mortargun";	//"tracer";
	mountPoint = 0;
	mountOffset = { 0, 0.03, 0.1 };		// right,forward,up
	//mountRotation = {0, 1.57, 0};
	weaponType = 0;		//0 single, 1 rotating, 2 sustained, 3disc	//weaponType = 2; // 2Sustained
	//projectileType = GrapplingHookBolt;	//GrabBolt;	//GrabLightning;	//GrabBolt;
	minEnergy = 3;
	maxEnergy = 0; //8 Energy used/sec for sustained weapons
	reloadTime = 0.1;
	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxReady = SoundJammerOn;
	sfxActivate = SoundPickUpWeapon;	//sfxActivate = SoundActivateAmmoStation;
	sfxFire = SoundThrowItem;	//SoundLaserIdle;//SoundSpinUpDisc;	//SoundELFIdle;
};

ItemData GrapplingHook 
{
	description = "Grappling Hook";	
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrapplingHookImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData RopeCanImage 
{
	shapeFile = "discammo";	//"tracer";
	mountPoint = 0;
	mountOffset = { 0.1, 0.0, -0.1 };	// 0.1, 0.5, -0.2	right,forward,up
	mountRotation = {0, -1.57, 1.57};
	weaponType = 2; // 2Sustained
};

ItemData RopeCan 
{
	description = "RopeCan";	//Energy Glove";	//"Spider Beam";
	className = "EyeCandy";	//className = "Weapon";
	shapeFile = "mine";
	//hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RopeCanImage;
	price = 375;
	showWeaponBar = true;
};



StaticShapeData RopeAnchor 	
{ 
		// Plasmatic -Vengeance mod
	shapeFile = "mine";		
	maxDamage = 0.10; 
	isTranslucent = true; 
	description = "Fiiiire!";  
	disableCollision = true;	
	
	lightType = 1; // 1=continuous, 2=Pulsing, 3=fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.3, 0.4, 0.5};	//lightColor = { 1, 1, 0.2 };yellow	//lightColor = { 0.4, 0.4, 1.0 };	//
};

TargetLaserData TargetLaserBlue
{
	laserBitmapName = "blue_blink1.bmp"; //fuex08   blue_blink4 //blue
	damageConversion  = 0.0;
	baseDamageType    = 0;
	lightRange        = 2.0;
	lightColor        = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
};

// Ho'k, we're checking LOS to see if there's something we can attach to, 
// If its a player or flier, we attach to that, otherwise, set a 'hook' and swing on that.
// setting 2 child variables. %player.anchor (object) and %player.grapple (true or false)
// -Plasmatic
function GrapplingHookImage::onFire(%player)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%grappling = %player.Grapple;
	if(!%grappling)
	{
		%clientId = Player::getClient(%player);
		
		if(GameBase::getLOSInfo(%player,75)) 	
		{
			GameBase::playSound(%player, GrapplingHookFire,0);//playSound(GrapplingHookFire,%player);

			%player.Grapple = true;
			
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object	
			%rot = Vector::getRotation($los::normal);

			%playerpos = GameBase::getPosition(%player);
			
			//%player.GrapplePos = $los::position;
			%player.GrappleLength = vector::getdistance(%playerPos,$los::position);

			%player.Grapple = true;
			%type = getObjectType($los::object);
			%name = GameBase::getMapName($los::object);
			%description = (GameBase::getDataName($los::object)).description;
			
		//	messageall(1,"type "@%type@%name@%description);
		
			if(%description != "" && %description != false && %description != shape)
				Client::sendMessage(Player::getclient(%player), 0, "Grappleing "@%description@".");			
			else if(%name != "" && %name != false && %name != Shape)
				Client::sendMessage(Player::getclient(%player), 0, "Grappleing "@%name@".");		
			else if(%type == SimTerrain)
				Client::sendMessage(Player::getclient(%player), 0, "Grappleing the ground.");	
			else if(%type == InteriorShape)
				Client::sendMessage(Player::getclient(%player), 0, "Grappleing concrete.");
			else	
				Client::sendMessage(Player::getclient(%player), 0, "Grappleing "@%type@".");
				
			if(%type == "Flier")
				%player.anchor = $los::object;
			else if (%type == "Player")
			{
				%player.anchor = $los::object;
				Client::sendMessage(Player::getclient($los::object), 0, "Being grappled by: "@Client::getName(Player::getclient(%player))@".");
			}
			else
			{
				
				//echo("newobj");		
				%anchor = newObject("", "StaticShape", RopeAnchor, true);
				GameBase::setPosition(%anchor,$los::position);
				GameBase::setRotation(%anchor,%rot);
				addToSet("MissionCleanup", %anchor);
				%player.anchor = %anchor;
			}
				
			%trans = GameBase::getMuzzleTransform(%player);		
			%newobj = Projectile::spawnProjectile(TargetLaserBlue,%trans,%player,%vel);
			Projectile::spawnProjectile("GrappleRopeRocket", %trans, %player,%vel); //transform, object, velocity vector, <projectile target (seeker)>					
			schedule("deleteobject("@%newobj@");",0.25);				
				
			GrapplingHook::Swing(%player);
			
		//	Projectile::spawnProjectile("GrabBolt",%trans,%player,%vel);
		}
		else
			GameBase::playSound(%player, SoundPackFail,0);
	}
	else
	{
		%player.Grapple = false;
		Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");
		GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen
	}
	Player::trigger(%player, $WeaponSlot,false);
}




//Plasmatic 2.2
function GrapplingHook::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,RopeCan,7);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Swing around like Tarzan on crack!");
}


function GrapplingHook::Swing(%player)
{
	// 2 june 06
	%anchor = %player.anchor;
	if(%player.Grapple && !Player::isDead(%player))
	{
		
		//Player::getMountedItem(%player,0) == GrapplingHook || 
		%anchorPos = getboxcenter(%anchor);	//GameBase::getPosition(%anchor);
		if(%anchorPos != 0 )
		{	
			%trans = GameBase::getMuzzleTransform(%player);	//"0 0 -1 0 0 0 0 0 -1 " @ vector::add(%playerpos,"0 0 0.5");	
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z	
			%GunTipPos = %posX@" "@%posY@" "@%posZ;
			
			%playerpos = %GunTipPos;	//GameBase::getPosition(%player);
			%dist = vector::getdistance(%anchorPos,%playerpos);
			if(%dist < 200 && Player::getItemCount(%player, GrapplingHook) > 0 && Player::getclient(%player) == GameBase::getControlClient(%player))
			{
				%vec = vector::sub(%anchorPos,%playerpos);		//the magic starts here. -Plas
				
				//H'ok, lets animate a rope of sorts so noobs can tell WTF is going on here.. -Plasmatic
				%time = getsimtime();	
				%isplayer = getObjectType(%anchor) == "Player";
				if(%player.lastRope + 0.350 <=  %time)
				{
					//%trans = GameBase::getMuzzleTransform(%player);	//"0 0 -1 0 0 0 0 0 -1 " @ vector::add(%playerpos,"0 0 0.5");
					%jerk = 2.5;
					%newVel = getWord(%vec, 0) * %jerk@" "@getWord(%vec, 1) * %jerk@" "@getWord(%vec, 2) * %jerk;	
					%rope = Projectile::spawnProjectile("GrappleRopeRocket", %trans, %player,%newVel); //transform, object, velocity vector, <projectile target (seeker)>						
					Item::setVelocity(%rope,%newVel);
					%player.lastRope = %time;
					if(%isplayer && !$NoPlayerDamage)
						GameBase::applyDamage(%anchor, $ElectricityDamageType, 0.005, %anchorPos, "0 0 0","0 0 0", Player::getclient(%player));					
					
				}				
				
			//	echo("swing!! "@%dist);
				%ropelength = %player.GrappleLength;			
				if(%dist > %ropelength*0.925)	// 0.85	stretching
				{	
					// Reduce the velocity in the dir of rope pull by impulsing the other direction.
					// we're allowing Tribes to handle the rest.. -Plasmatic
					%mass = (Player::getArmor(%player)).mass;	// light = 9, med = 13, henry = 16
					
							
					%x = %mass * getWord(%vec, 0) * 0.05;	//0.0555;		//sideways
					%y = %mass * getWord(%vec, 1) * 0.05;	//0.0555;		//sideways
					%z = %mass * getWord(%vec, 2) * 0.075;	//0.0769;		//up, down
					%force = %x@" "@%y@" "@%z;
					
					Player::applyImpulse(%player,%force);
			
					if(%isplayer)
					{
						// this is the player we're grabbing onto.. 
						%neg = 0.1250 * %mass / ((Player::getArmor(%anchor)).mass);	//0.125;
						%force = -%x * %neg@" "@-%y * %neg@" "@-%z * %neg;
						Player::applyImpulse(%anchor,%force);
				
					}
																	
				}
				
				schedule("GrapplingHook::Swing("@%player@");",0.05);
			}
			else
			{
				%player.Grapple = false;
				Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");		
				GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen
				if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
					deleteobject(%anchor);			
			}
		}
		else
		{
			// Hook was destroyed
			%player.Grapple = false;
			Client::sendMessage(Player::getclient(%player), 0, "Grapple hook dislodged.");		
			GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen			
			
		}
	}			
	else
	{	
		
		if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
			deleteobject(%anchor);
	}
}
	
ExplosionData GrappleRopeExp
{
   shapeName = "rsmoke.dts";
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
//   lightRange = 1.0;

   lightRange = 0;
   timeScale = 0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};


RocketData GrappleRopeRocket
{
	bulletShapeName = "discb.dts";
	explosionTag = GrappleRopeExp;	//rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;		 // 0 impact, 1, radius
	damageValue = 0.0;	//0.5;
	damageType  = $ExplosionDamageType;
	explosionRadius  = 7.5;
	kickBackStrength = 0.0;
	muzzleVelocity = 150.0;
	terminalVelocity =150.0;
	acceleration = 5.0;
	totalTime = 0.40;
	liveTime = 0.40;
	lightRange  = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 1.0;
	// rocket specific
	trailType	= 1;
	trailLength = 150;
	trailWidth  = 1.0;
	soundId = SoundDiscSpin;
};