$InvList[ParticleBeamWeapon] = 1;
$MobileInvList[ParticleBeamWeapon] = 1;
$RemoteInvList[ParticleBeamWeapon] = 1;

$AutoUse[ParticleBeamWeapon] = false;

// addWeapon(ParticleBeamWeapon);

LaserData ParticleBeam
{	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!     = "warp.bmp";
	hitName = "shockwave_large.dts";
	damageConversion = 0.025;	//0.064;	
	//DamageType = $BulletDamageType;
	DamageType = $LaserDamageType;	//could make this anything, it will still be type 6..	-plasmatic
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};


LaserData PhrailterLaser
{
	laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!   = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!  laserbitmapName = "paintPulse.bmp";	//Driving out all the snakes for St Patricks day!       = "blue_blink4.bmp";		//"pulse.bmp";
	hitName   	  = "shockwave_large.dts";	//"laserhit.dts";

	damageConversion  = 0.00;		//0.007
	baseDamageType    = $LaserDamageType;

	beamTime          = 1.0;	//0.7;

	lightRange        = 2.0;
	lightColor        = { 1.0, 0.25, 0.25 };

	detachFromShooter = true;
	hitSoundId	= SoundFlierCrash;
	//   hitSoundId        = SoundParticleBeamExplosion;	//SoundLaserHit;
};
ItemImageData ParticleBeamWeaponImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 1;
//	projectileType = markerLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	fireTime = 0.001;
	spinUpTime = 0.001;
	spinDownTime = 0.001;
	reloadTime = 2.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 1, 0.25 };
	//sfxFire = SoundFireTargetingLaser;
	//sfxActivate = SoundPickUpWeapon;
};

ItemData ParticleBeamWeapon
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	heading = $InvHead[ihWea];
	imageType = ParticleBeamWeaponImage;
	showWeaponBar = true;
	showInventory = true;
	price = 2000;
};

ItemImageData ParticleBeamWeaponImage2
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60; //plasmatic
	maxEnergy = -6; //plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , -2.5 , 0 };
	mountOffset = { -0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 0.0;	//1.5;
	fireTime = 0.0;	//2.5;	//4/4/2007 5:35AM
};

ItemData ParticleBeamWeapon2
{
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage2;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage3
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60;	//plasmatic
	maxEnergy = -6;	//plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , 2.5 , 0 };
	mountOffset = { 0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 0.0;	//1.5;
	fireTime = 0.0;	//2.5;	// 4/4/2007 5:36AM
};

ItemData ParticleBeamWeapon3
{
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage3;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage4
{
	shapeFile = "jetpack";
	mountPoint = 0;
	mountRotation = { -1.57, 0 , 3.14 };
	mountOffset = { 0 , 0.1 , 0 };
	weaponType = 0;
	minEnergy = 70;
	maxEnergy = 120;
	projectileType = ParticleBeam;
	accuFire = true;
	fireTime = 0.25;
	reloadTime = 0.38;
	sfxFire = SoundParticleBeamFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon4
{
	shapeFile = "jetpack";
	hudIcon = "reticle";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage4;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage5
{
//	shapeFile = "grenammo";
//	mountPoint = 0;
	shapeFile = "jetpack";
	mountPoint = 0;
	mountRotation = { -1.57, 0 , 3.14 };
	mountOffset = { 0 , 0.1 , 0 };

	weaponType = 0; 
	minEnergy = -100;	//70
	maxEnergy = 120;
	projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 1.0;	//2.5
	fireTime = 1.0;	//2.5
	sfxFire = SoundParticleBeamFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon5
{
	className = "Weapon";
//	shapeFile = "grenammo";
	shapeFile = "jetpack";
	hudIcon = "reticle";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage5;
	price = 2500;
	showWeaponBar = true;
};

//Plasmatic 2.2
function ParticleBeamWeapon::MountExtras(%player,%weapon)
{			
	Player::mountItem(%player,ParticleBeamWeapon2,4);
	Player::mountItem(%player,ParticleBeamWeapon3,6);
	
	%client = Player::getclient(%player);
//	if(%client.pbeam == 1)
//	{
//		if(player::getitemcount(%client,EnergyPack) == 1)
//			Player::mountItem(%player,ParticleBeamWeapon4,7);	
//	}
//	else	
		Player::mountItem(%player,ParticleBeamWeapon5,7);	//screw it, we're triggering/ spawning this anyhow... -Plas 9/19/2007 4:23AM
			
	if(%client.weaponHelp)
	{
		if(%client.pbeam == 1)
		{
			if(player::getitemcount(%client,EnergyPack) == 1)	
				Bottomprint(%client, "<jc>Particle Beam Weapon: <f2>Enhanced Positron Beam. Hold fire to charge.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.");
			else 
			{
			//	Client::sendMessage(%client, 0, "The Particle Beam requires an Energy Pack to function in enhanced mode..~wC_BuySell.wav");	
				Bottomprint(%client, "<jc>Particle Beam Weapon: <f2>Standard Neutron Beam.");
			}
		}
		else
		{
			if(player::getitemcount(%client,EnergyPack) == 1)
				Bottomprint(%client, "<jc>Particle Beam Weapon: <f2>Standard Neutron Beam.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.");
			else
				Bottomprint(%client, "<jc>Particle Beam Weapon: <f2>Standard Neutron Beam.");
		}
	}	
}


// ::onfire is called once, at first trigger. -Plasmatic
function ParticleBeamWeaponImage::onFire(%player) 
{	
	// max damage new 'charge up beam' is 12.5
	// max player damage = 4;
	//
	// max damage old single shot style is 3
	// player damage = 3, over 2 times highest maxdamage for player
	
	%client = Player::getclient(%player);	
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ %client);	
	

	if(%client.pbeam == 1 && player::getitemcount(%client,EnergyPack) == 1)
	{	
		if(%player.pbeamcharging)
			return;
		%player.pbeamcharge=0;
		ParticleBeamWeapon::onCharge(%player);
	}
	else
	{
		// fire standard beam. 
		if(!%client.pbeamReseting && GameBase::getEnergy(%Player) > 70)//70
		{
			%smack = GameBase::getEnergy(%Player)/20;	//8;
			Player::trigger(%player, 7, true);	
			schedule("Player::trigger(" @ %player @ ", 7, false);",0.1);	
			%client.pbeamReseting = true;
			schedule(%client@".pbeamReseting = false;",2.5);
			//schedule("GameBase::playSound("@%player@", forcefieldopen, 0);",2.5);
			
			//new kickback- Plasmatic
			%trans = GameBase::getMuzzleTransform(%player);
			
			%rot=GameBase::getRotation(%player);
				%len = 30;
				%tr= getWord(%trans,5);
				%tr = -%tr;
				%tr = %tr+0.15;
				%up = %tr;
				%out = %tr -1;
			%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
			Player::applyImpulse(%player,%vec);			
		}
		else 
		{
			// do nothing, recharging standard beam.
		}
		
	}
}

//plasmatic
function reload(%player) 
{
	%player.reloading = "";
	//echo("ready");
//	playSound(SoundMortarReload, GameBase::getPosition(%player));
//	GameBase::playSound(%player, MortarReload, 0);
	GameBase::playSound(%player, forcefieldopen, 0);
}
function ResetPbeamLock(%ClientId)
{
	%clientId.locksound = "";
}

function ParticleBeamWeapon::onCharge(%player)
{
	if(%player.reloading == "True") 
		return;//plasmatic
	%clientId = GameBase::getOwnerClient(%player);
	if(Player::isTriggered(%player,0))
	{
		%player.pbeamcharging = true;
		if (%player.pbeamcharge < 100)
			%player.pbeamcharge++;
		else
		 	%player.pbeamcharge = 100;
	 	
		schedule("ParticleBeamWeapon::onCharge(" @ %player @ ");",0.05);
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-2.5);
		
		if (%player.pbeamcharge > 60 && GameBase::getLOSInfo(%player,3000))
		{
			if(!%clientId.locksound) 
			{
				%obj = getObjectType($los::object);
			//echo(%obj);
				if(%obj == "Player" || %obj == "Flier")
				{
					GameBase::playSound(%clientId,SoundMineActivate, 0);
					%clientId.locksound = true;
					schedule("ResetPbeamLock("@%ClientId@");",2);
				}
				else if(%obj != "SimTerrain" && %obj != "InteriorShape")
				{
					GameBase::playSound(%clientId,soundpackuse, 0);
					%ClientId.locksound = true;
					schedule("ResetPbeamLock("@%ClientId@");",2);
				}	
			}
			%trans = GameBase::getMuzzleTransform(%player);	
			%d1= getWord(%trans,3);
			%d2= getWord(%trans,4);
			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas
			
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z	
			%GunTipPos = %posX@" "@%posY@" "@%posZ;	
			
			%gunVec = vector::normalize(vector::sub($los::position,%GunTipPos));				
			
			%vec = vector::sub($los::position,%gunVec);
			%trans =  getWord(%trans,0)@" "@getWord(%trans,1)@" "@getWord(%trans,2)@" "@%gunVec@" "@getWord(%trans,6)@" "@getWord(%trans,7)@" "@getWord(%trans,8)@" "@%vec;
			%proj = Projectile::spawnProjectile("MarkerLaser", %trans, 2048, %vel);					
		}
		bottomprint(%clientId, "<jc><f2>ParticleBeam charged to <f1>"@%player.pbeamcharge@"<f2>%", 0.5);
	}
	
	else //if(!Player::isTriggered(%player,0))	//fire this bad boy. 
	{
		if(GameBase::getLOSInfo(%player,3000)) //plasmatic 3.0 Fixed sky fire bug. 
		{
			// there must be something in our sight. 
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%target = $los::object;	
			%obj = getObjectType(%target);
			if(%obj != "SimTerrain" || %obj != "InteriorShape") 
			{
				if (%obj=="Player" || %obj =="Flier") 
					%value = %player.pbeamcharge/25;
				if(GameBase::getMapName(%target) == Bunker)
					%value = %player.pbeamcharge/25;	//6 shots fer bunker -plasmatic
				else  %value = %player.pbeamcharge/8;
					GameBase::applyDamage(%target, $SniperDamageType, %value, $los::position, "0 0 0","0 0 0", %clientId);
				if($debug)
					Client::sendMessage(%clientId,0,"target "@ %target @" object type "@%obj@" Damage value "@%value);
				
			}			
			
		}	
		// animate the beams -Plasmatic 3.0
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		playSound(SoundFireLaser, GameBase::getPosition(%player));
		Player::trigger(%player, 4, true);
		Player::trigger(%player, 6, true);
	
		%smack = %player.pbeamcharge / 10;
		if (%smack < 4) 
			playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
		if (%smack >= 4) 
			playSound(SoundPlasmaTurretFire, GameBase::getPosition(%player));
		if (%smack >= 8) 
			playSound(explo3, GameBase::getPosition(%player));
	
		if($debug)
			Client::sendMessage(%clientId,0,GameBase::getMapName(%target)@"target "@ %target @" object type "@%obj@" Damage value "@%value);

		%player.pbeamcharge = 0;
		%player.pbeamHoldcharge = 0;
		%player.pbeamcharging = false;
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);

		%player.reloading = "True";//plasmatic
		schedule("reload(" @ %player @ ");",2.0); //PLASMATIC

	//new kickback- Plasmatic
		if(!Player::isDead(%player)) 
		{
			%rot=GameBase::getRotation(%player);
			%len = 30;
			%tr= getWord(%trans,5);
			%tr = -%tr;
			%tr = %tr+0.15;
			%up = %tr;
			%out = %tr -1;
			
			%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
			Player::applyImpulse(%player,%vec);
		}
	}
}