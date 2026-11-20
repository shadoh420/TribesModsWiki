$InvList[BabyNukeMortar] = 1;
$MobileInvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$InvList[BabyNukeAmmo] = 1;
$MobileInvList[BabyNukeAmmo] = 1;
$RemoteInvList[BabyNukeAmmo] = 1;


$AutoUse[BabyNukeMortar]= True;
$WeaponAmmo[BabyNukeMortar] = BabyNukeAmmo;
$SellAmmo[BabyNukeAmmo] = 1;

// addWeapon(BabyNukeMortar);
addAmmo(BabyNukeMortar, BabyNukeAmmo, 1);

$BabyNukeMortarSlotA=4;


ItemData BabyNukeAmmo 
{
	description = "Nuclear Device";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1000;
	//imageType = LeadWeightImage;	//?!
};

MineData BabyNukeAmmoBomb
{
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
//	description = "Halo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};

ItemImageData BabyNukeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.005, 0 };
	mountRotation = { 0, 0 , 0 };
	weaponType = 0; // Single Shot
	//projectileType = BabyNukeBomb;
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 2.0;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
	
};

ItemData BabyNukeMortar
{
	description = "Baby Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNukeImage;
	price = 1500;
	showWeaponBar = true;
};

ItemImageData BabyNuke2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.0365, 0, -0.035 };
	mountRotation = { 0, -1.575, 0 };
	weaponType = 0; // Single Shot
	//projectileType = BabyNukeBomb;
	accuFire = true;
	ammoType = BabyNukeAmmo;
	reloadTime = 2.0;
	fireTime = 2.0;
};

ItemData BabyNukeMortar2
{
	//description = "Baby Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = BabyNuke2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;

};

function BabyNukeMortar::MountExtras(%player,%weapon)
{	
	// ok, let's initiate an ammo check and modify player energy
	// recharge based on ammo count to simulate weight.
//	BabyNukeMortar::AmmoCheck(%player);
	
	Player::mountItem(%player,BabyNukeMortar2,$BabyNukeMortarSlotA);
	%client = Player::getclient(%player);
	if(%client.weaponHelp)
	{
	
	if(%client.Baby == 1)
		schedule("bottomprint(" @ %client @ ", \"<jc>Baby Nuke Launcher:<f2> Rocket propelled.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
	else
		schedule("bottomprint(" @ %client @ ", \"<jc>Baby Nuke Launcher:<f2> Standard.\\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.\", 10);", 0);
			
		
	//	Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Throw this lil baby and watch them run for the hills.");	
	}
}

function FireBabyNukeMortar(%client, %player) 
{
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "BabyNukeMortar")) 
	{
		Player::trigger(%player,$BabyNukeMortarSlotA,true);
		schedule("FireBabyNukeMortar(" @ %client @ "," @ %player @ ");",0.1); 
		%player.firingBabyNuke = true;
	}
	else 
	{
		Player::trigger(%player,$BabyNukeMortarSlotA,false);
		%player.firingBabyNuke = false;
	}
}

MineData BombHalo
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Halo";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function BombHalo::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);	//0.2
}

function BabyNukeBomb::onAdd(%this)
{	
	//schedule("BombHalo(" @ %this @ ");",5.25);
}
function BombHalo(%this,%cl)
{
	%obj = newObject("","Mine","BombHalo");
	%obj.client = %cl;
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1 ,false);
	//%pos = Vector::add(GameBase::getPosition(%this), "0 0 2");
	//GameBase::setPosition(%obj, %pos);
}


function BabyNukeImage::onFire(%player) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	%client = GameBase::getOwnerClient(%player);
		
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if(%client.Baby == 1)
	{
		Annihilation::decItemCount(%player,BabyNukeAmmo,2);
		Projectile::spawnProjectile("BabyShell",%trans,%player,%vel,%player);
		if(!%player.firingBabyNuke)
			FireBabyNukeMortar(%client, %player);		
	}	
	else
	{	
		Annihilation::decItemCount(%player,BabyNukeAmmo,1);
		
		while(%group != -1)
		{
			%i++;
			%group = nameToID("MissionCleanup/nuke" @ %i);
			
		}
		%group = newObject("nuke" @ %i,SimGroup);
		addToSet("MissionCleanup",%group);		
		
		
		//let the beatings begin -Plasmatic
		%bomb = Projectile::spawnProjectile("NukeExplosion3",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 40";
		addToSet(%group, %bomb);
		schedule("BombHalo(" @ %bomb @ ", " @ %client @ ");",5.45);		
		
		Projectile::spawnProjectile("BabyNukeBomb",%trans,%player,%vel,%player);
		
		for(%i=0; %i < 6.28; %i += 1.256)
		{
			%forceVel = Vector::getFromRot("0 0 " @ %i, 15, 40);
			%bomb = Projectile::spawnProjectile("NukeExplosion4",%trans,%player,%vel,%player);
			%bomb.forceVel = %forceVel;	
			addToSet(%group, %bomb);
		}

		%bomb = Projectile::spawnProjectile("NukeExplosion4",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 50";	
		addToSet(%group, %bomb);		
		%bomb = Projectile::spawnProjectile("NukeExplosion2",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 35";
		addToSet(%group, %bomb);		
		%bomb = Projectile::spawnProjectile("NukeExplosion2",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 30";
		addToSet(%group, %bomb);		
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 25";
		addToSet(%group, %bomb);			
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 20";
		addToSet(%group, %bomb);			
		%bomb = Projectile::spawnProjectile("NukeExplosion1",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 15";
		addToSet(%group, %bomb);			
		%bomb = Projectile::spawnProjectile("NukeExplosion0",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 10";
		addToSet(%group, %bomb);			
		%bomb = Projectile::spawnProjectile("NukeExplosion0",%trans,%player,%vel,%player);
		%bomb.forceVel = "0 0 5";
		addToSet(%group, %bomb);
						
				
		if(!%player.firingBabyNuke)
			FireBabyNukeMortar(%client, %player);
	}
						
}
function NukeExplosion0::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion1::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion2::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeExplosion3::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);	
}
function NukeExplosion4::onAdd(%this)
{
	schedule("NukeSpread(" @ %this @ ");",5.25);
}
function NukeSpread(%this)
{
	%forceVel = %this.forceVel;
	Item::setVelocity(%this, %forceVel);
	
}


SoundData NukeWind
{
	wavFileName = "wind1.wav";
	profile = Profile3dLudicrouslyFar;
};
ExplosionData NukeCrownExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = NukeWind;


	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=9.0;			
	timeZero=0.300;			
	timeOne=0.900;			
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={0.5,0.4,0.2};
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={1.0,1.0,0.5};
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};
SoundData NukeSound
{
	wavFileName = "turretexp.wav";
	profile = Profile3dLudicrouslyFar;
};
ExplosionData NukeExp
{
   shapeName = "mortarex.dts";//fiery
   soundId   = NukeSound;


	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=9.0;			
	timeZero=0.300;			
	timeOne=0.900;			
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={0.5,0.4,0.2};
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={1.0,1.0,0.5};
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;


};


GrenadeData NukeExplosion0
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag = NukeExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 5.85;
	liveTime = 5.85;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
	   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion1
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag = WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 6.0;
	liveTime = 6.0;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
	   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion2
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag = 	NukeCrownExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.75;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 60.0;	//40.0;
	kickBackStrength = 250;	//100.0;
	maxLevelFlightDist = 350;
	totalTime = 6.15;
	liveTime = 6.15;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
	   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion3
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag = NukeCrownExp;	//WickedBadExp;	//LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.5;	//1
	damageType = $ShrapnelDamageType;
	explosionRadius = 100.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 6.3;
	liveTime = 6.3;
	projSpecialTime = 10.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
	   smokeName              = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail
};
GrenadeData NukeExplosion4
{	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "breath.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.2;	//0.4;
	damageClass = 1; // 0 impact, 1, radius
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 40.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 350;
	totalTime = 6.45;
	liveTime = 6.45;
	projSpecialTime = 10.0;
	inheritedVelocityScale = 0.5;
	//smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "paint.dts";
	   smokeName   = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! "breath.dts";	//plastrail.dts";//mortartrail
};





