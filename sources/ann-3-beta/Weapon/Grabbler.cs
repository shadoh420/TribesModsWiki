// all code by Plasmatic 
// aka Steve Madden
// copyright 2003

$InvList[Grabbler] = 1;
$MobileInvList[Grabbler] = 1;
$RemoteInvList[Grabbler] = 1;

$AutoUse[Grabbler] = False;
$WeaponAmmo[Grabbler] = "";

addWeapon(Grabbler);

SoundData GrabblerFire
{
	wavFileName = "turretfire2.wav";//door2.wav";//BXplo4.wav//Grenade.wav//rifle1.wav//turretfire2.wav
	profile = Profile3dFar;
};

SeekingMissileData GrabblerShock
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;	//0.5
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 350.0;
	muzzleVelocity = 120.0;
	totalTime = 1;
	liveTime = 1;
	seekingTurningRadius = 2.5;
	nonSeekingTurningRadius = 3.0;
	proximityDist = 0.25;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
};

LightningData GrabLightning
{
	bitmapName = "grn_blink4.bmp";	//lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 15.0;
	coneAngle = 35.0;
	damagePerSec = 0.0;
	energyDrainPerSec = 60.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.075;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundLaserIdle;
};


RepairEffectData GrabBolt
{
	bitmapName = "grn_blink4.bmp";//lightningNewSub.bmp";//lightningTemp.bmp";//fx_lensflare_5.bmp";//cphoenix.flag.bmp";	//grn_blink4.bmp";	//mort0000.bmp";	//repairadd.bmp";
	boltLength = 15.5;
	
	segmentDivisions = 4;
	beamWidth = 0.25;
	updateTime = 450;	//how fast beam oscilates
	skipPercent = 0.0001;	//0.6
	displaceBias = 0.15;	//0.15 //displaced side to side
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};



ItemImageData GrabblerImage 
{
	shapeFile = "mortargun";	//"tracer";
	mountPoint = 0;
	mountOffset = { -0.1, -0.3, -0.1 };
	mountRotation = {0, 1.57, 0};
	weaponType = 2; // 2Sustained
	projectileType = GrabBolt;	//GrabLightning;	//GrabBolt;
	minEnergy = 3;
	maxEnergy = 0; //8 Energy used/sec for sustained weapons
	reloadTime = 0.0;
	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxReady = SoundJammerOn;
	sfxActivate = SoundActivateAmmoStation;
	sfxFire = SoundLaserIdle;//SoundSpinUpDisc;	//SoundELFIdle;
};

ItemData Grabbler 
{
	description = "Pitchfork";	//Energy Glove";	//"Spider Beam";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
	heading = $InvHead[ihtool];	//$InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrabblerImage;
	price = 375;
	showWeaponBar = true;
};
ItemImageData PitchforkImage 
{
	shapeFile = "mine";	//"tracer";
	mountPoint = 0;
	mountOffset = { 0.05, 0.5, -0.1 };	// 0.1, 0.5, -0.2	right,forward,up
	mountRotation = {0, -1.57, 1.57};
	weaponType = 2; // 2Sustained
//	projectileType = GrabBolt;	//GrabLightning;	//GrabBolt;
//	minEnergy = 3;
//	maxEnergy = 0; //8 Energy used/sec for sustained weapons
//	reloadTime = 0.0;
//	lightType = 3; // Weapon Fire
//	lightRadius = 2;
//	lightTime = 1;
//	lightColor = { 0.25, 0.25, 0.85 };
//	sfxReady = SoundJammerOn;
//	sfxActivate = SoundActivateAmmoStation;
//	sfxFire = SoundLaserIdle;//SoundSpinUpDisc;	//SoundELFIdle;
};

ItemData Pitchfork 
{
	description = "Pitchfork";	//Energy Glove";	//"Spider Beam";
	className = "Weapon";
	shapeFile = "mine";
	//hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PitchforkImage;
	price = 375;
	showWeaponBar = true;
};

function GrabblerImage::onFire(%player)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("GrabBolt",%trans,%player,%vel);
}

//Plasmatic 2.2
function Grabbler::MountExtras(%player,%weapon)
{	
	Player::mountItem(%player,Pitchfork,7);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Plasmatics' brain fart.");
}

// for repairbolt data method.. yes, this is a 'repair' type bolt. -plasmatic
function GrabBolt::onAcquire(%this, %player, %target)
{
	%player.GrabObject = "";
	%player.Grabdist = "";
	%player.GrabRoty = "";
	%player.GrabOffsetVec = "";
		
	if($build)
		%player.GrabObject = %target;
		
	if(%target == %player) 
	{
		return;
	}
	else
	{
		
		%client = Player::getClient(%player);
		%player.GrabObject = %target;		
		%type = getObjectType(%target);
		%dataName = GameBase::getDataName(%target);
		%shape = %dataName.shapeFile;
		
		if($debug)
			bottomprint(%client,"<jc>"@%type@" Data Name= "@%dataName@" shape= "@%shape);
				
		if(!$build)
		{
			if(%type != "Player" && %dataName != BlastWall && %dataName != LargeForcefield && %dataName != ForceFieldDoorShape && %dataName != DeployableForcefield && %dataName != LargeForceFieldDoorShape && %dataName != DeployablePlatform && %dataName != DeployablePlasmaFloor)
				return;
		}
		if(%dataname == JailWall)
			return;
			
		%trans = GameBase::getMuzzleTransform(%player);	//position of tip
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z	
		%GunTipPos = %posX@" "@%posY@" "@%posZ;
			
		//figure out general relativity, Einstein..
			%d1= getWord(%trans,3);
			%d2= getWord(%trans,4);
			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas			
			
			%TargetPos = GameBase::getPosition(%target);
			
		//simplified for these -player and flier pos is at at bottom center -plasmatic
		if(%type == "Player" || %type == "Flier")// || %type == "Mine")
		{
			%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);
			%player.GrabOffsetVec = "";
			%player.GrabRoty = "";
			%target.forker = %player;	// for release code, plasmatic 2.3
		}

		else		
		{	
		// This works ok for now. When beam attach point changes
		// while rotating, movement is still funky...
		// hack to move static objects correctly -plasmatic
			GameBase::getLOSInfo(%player,1000);
				// GetLOSInfo sets the following globals:
				// 	los::position
				// 	los::normal
				// 	los::object	
						
			%RealDist = vector::getdistance($los::position,%GunTipPos);				
			%player.Grabdist = %RealDist;	
			
			%TargetRot = GameBase::getRotation(%target);
			%playerRot = GameBase::getRotation(%player);
			%targetRelative = vector::add(%TargetRot ,vector::multiply("0 0 -1",%playerRot));// hacking for screwy spawn pts -players only rotate around z -plas
			
			%player.GrabRoty = %targetRelative;
				
		//%GunExtPos is like the end of a broom handle shoved down gun barrel.
			%GunExtPos = %posX + %d1 * %RealDist@" "@%posY + %d2 * %RealDist@" "@%posZ + %d3 * %RealDist;
			
		// offsetvec is vec from where we're grabbing to the actual obj position 'handle'
		// position on object we're grabbing may change, but this works good. -plasmatic
			%OffsetVec = vector::add(vector::multiply("-1 -1 -1",%GunExtPos),%TargetPos);	//dist from gun tip to where beam is hitting, more or less...
	//		%Nrot = vector::add(vector::multiply("-1 -1 -1",%targetRot),%playerRot);
	//		%OffsetVecNew = RotateVector(%OffsetVec,%Nrot);	//normalizing vector relative to player
			%player.GrabOffsetVec = %OffsetVec;			
			
				
		}			
	Grabler::move(%player,%target);			
	}
}

// called a few times a sec.. not fast enough for 'move' but we'll use to simplify things -plasmatic
// maybe not.. meh..
function GrabBolt::checkDone(%this, %player)
{
}


function Grabler::move(%player,%target)
{
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(Player::isTriggered(%player,$WeaponSlot) && %weapon == Grabbler)
	{
		if(%player.GrabObject != %target || %player.GrabObject == "")
		{
			%player.GrabObject = "";
			%player.Grabdist = "";
			%player.GrabRoty = "";
			%player.GrabOffsetVec = "";
			return;
		}
		%type = getObjectType(%target);
		%trans = GameBase::getMuzzleTransform(%player);	
		%vel = Item::getVelocity(%player);
		
		//position of tip
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z	
			%GunTipPos = %posX@" "@%posY@" "@%posZ;
		//direction gun is pointed foo.
		%d1= getWord(%trans,3);
			%d2= getWord(%trans,4);
			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas	
			%GunRotVec = %d1 @" " @ %d2 @" " @ %d3;	//%d3 is up/ down
	
		%dist = %player.Grabdist;
		
		if(%type == "Player" || %type == "Flier")
		{
			Item::setVelocity(%target, 0);
			%position = %posX + %d1 * %dist@" "@%posY + %d2 * %dist@" "@%posZ + %d3 * %dist;
			if(GameBase::testPosition(%target, %position))
			{
				GameBase::setPosition(%target,%position);
			}	
			else 
			{
				%TargetPos = GameBase::getPosition(%target);
				%oldheight = getword(%TargetPos,2);
				%newHeight = getword(%position,2);
				
				//player aiming down, pushing player through ground?
				if(%newHeight < %oldheight)		//%d3 < -0.5)
				{
					//Player::trigger(%player,$WeaponSlot,false);
					GameBase::setPosition(%target,vector::add(%TargetPos,"0 0 0.2"));
					return;
				}
				else
				{
					
					%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);			
				}
				
			}
			schedule("Grabler::move("@%player@","@%target@");",0.037);	
		}		
		else
		{					
			%targetRelative = %player.GrabRoty;
			%playerRot = GameBase::getRotation(%player);
			%newrot = vector::add(%playerRot,%targetRelative);
			%GunExtPos = vector::add(vector::multiply(%GunRotVec,%dist@" "@%dist@" "@%dist),%GunTipPos);		
			
			%OffsetVec = %player.GrabOffsetVec;
	//	bottomprint(Player::getClient(%player),%OffsetVec@" "@%playerRot);
	//		%OffsetVecNew = RotateVector(%OffsetVec,%targetRot);	//%newrot);	//ah the joys of rotation... 
			%position = vector::add(%GunExtPos,%OffsetVec);	//%OffsetVecNew
			GameBase::setPosition(%target,%position);
			gamebase::setrotation(%target,%newrot);	
			schedule("Grabler::move("@%player@","@%target@");",0.025);			
		}
		
		
	}

}



function GrabBolt::onRelease(%this, %player)
{
	%target = %player.GrabObject;	// for release code, plasmatic 2.3
	%target.forker = "";		// for release code, plasmatic 2.3
	%player.GrabObject = "";
	%player.Grabdist = "";
	%player.GrabRoty = "";
	%player.GrabOffsetVec = "";	
	%player.Mine = "";
}


// called when player shoots object
function grabbler::fire(%player,%object)
{	
	//echo("firegrab");
	%type = getObjectType(%object);
	if(%type == "Player")
	{		
		//%object = %player.GrabObject;
		%client = Player::getClient(%player);
	
		%trans = GameBase::getMuzzleTransform(%player);	
		%vel = Item::getVelocity(%player);
								//position of tip
		%posX = getWord(%trans,9);		//x
		%posY = getWord(%trans,10);		//y
		%posZ = getWord(%trans,11); 		//z	
		%GunTipPos = %posX@" "@%posY@" "@%posZ;
	
		%d1= getWord(%trans,3);
		%d2= getWord(%trans,4);
		%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas
		if(%player != %object)
		{		
			Projectile::spawnProjectile("GrabblerShock",%trans,%player,%vel,%object);
			playSound(GrabblerFire, GameBase::getPosition(%client));
			Messageall(0,Client::getName(%client)@" gave "@client::getName(Player::getClient(%object))@" a boost.");
			
			//anti tk code, and death message tracker.
			%object.LastBoost = %client;
			%object.BoostTime = getSimTime();	//sim time returns map time in seconds -plas				
		}	
		
		%GunRotVec = %d1 @" " @ %d2 @" " @ %d3;
		%fireImpulse = vector::add(vector::multiply("75 75 75",%GunRotVec),%vel);	//75
	//	Player::trigger(%player,$WeaponSlot,false);
		//Player::applyImpulse(%obj,%vec);
		//bottomprint(%client,"fire grabbler "@%object@" impulse "@%fireImpulse);
		//echo(%client,"fire grabbler "@%object@" impulse "@%fireImpulse);
	
		GameBase::playSound(%player, GrabblerFire, 0);	//SoundDoorClose, 0);
	//	Player::applyImpulse(%object,%fireImpulse); //gives a screwy trajectory
		
		%object.Grabfire = 150;
		Grabbler::smoke(%object);
		Item::setVelocity(%object,%fireImpulse);
		

		%target = %player.GrabObject;	// for release code, plasmatic 2.3
		%target.forker = "";		// for release code, plasmatic 2.3		
		%player.GrabObject = "";
		%player.Grabdist = "";
		%player.GrabRoty = "";
		%player.GrabOffsetVec = "";		
		
	}
	
	
}


// player smoke trail
function Grabbler::smoke(%player)
{
	//plasmatic
	if(Player::isDead(%player))	return;
	%player.Grabfire = %player.Grabfire -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(vector::getdistance(%vel,"0 0 0") > 10)
		Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.Grabfire > 1)
		schedule("Grabbler::smoke("@%player@");",0.05);	
	
}

