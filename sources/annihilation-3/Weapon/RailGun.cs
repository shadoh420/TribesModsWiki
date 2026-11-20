$InvList[Railgun] = 1;
$MobileInvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$InvList[RailAmmo] = 1;
$MobileInvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$AutoUse[Railgun] = false;
$SellAmmo[RailAmmo] = 10;
$WeaponAmmo[Railgun] = RailAmmo;

// addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

RocketData RailRound
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "tracer.dts";	//bullet.dts";	plasmatic 2.2
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.2666;	//0.80;	//0.75	//for 3x bullets
	damageType = $SniperDamageType;		//adjusted this some when I fixed head shot damage -plasmatic
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;	//2000.0;	
	terminalVelocity = 3500.0;	//2000.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};
RocketData RailRound2
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "tracer.dts";	//bullet.dts";	plasmatic 2.2
	explosionTag = bulletExp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.2666;	//0.80;	//0.75	// for 3x bullets
	damageType = $SniperDamageType;		//adjusted this some when I fixed head shot damage -plasmatic
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 3500.0;	//2000.0;	
	terminalVelocity = 3500.0;	//2000.0;
	acceleration = 6.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};

ItemData RailAmmo 
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 75;
};
MineData RailAmmoBomb
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

ItemImageData RailgunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;	
	accuFire = true;
	ammoType = RailAmmo;
	projectileType = RailRound;	//Primary weapon image now, no more function! 11/5/2007 1:51AM -Plasmatic
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 1.75;	
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData Railgun2Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;	
	mountOffset = { 0, -0.2, 0 };
	mountRotation = { 0.005, 0, 0 };
	weaponType = 0;
	projectileType = RailRound2;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.1;
	maxEnergy = 10;	//0;	//energy/sec
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
};

ItemData Railgun2
{
	shapeFile = "shotgun";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Railgun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};


ExplosionData BurningOzoneExp
{
	shapeName = "flash_small.dts";
	//soundId = debrisSmallExplosion;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 2.5;
	timeZero = 0.250;
	timeOne = 0.650;
	colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 0.0, 0.0, 0.0 };
	colors[1] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 0.5, 0.16 };
	colors[2] = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! colors[0] = { 1.0, 0.5, 0.16 };
	radFactors = { 0.0, 1.0, 1.0 };
};

GrenadeData BurningOzone
{	
	bulletShapeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! bulletShapeName = "flash_small.dts";	//enbolt.dts";	//bullet
	explosionTag = BurningOzoneExp;	//SpentShellExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.01;
	elasticity = 0.15;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	explosionRadius = 8;
	kickBackStrength = 0;
	maxLevelFlightDist = 3;
	totalTime = 0.15;
	liveTime = 0.15;	//after collision
	projSpecialTime = 0.0015;	//smoke time
	inheritedVelocityScale = 0.5;
	smokeName = "mortartrail.dts";	//Driving out all the snakes for St Patricks day! smokeName = "rsmoke.dts";	//breath.dts";	//rsmoke
	smokeDist = 0.001;	//1.5;
};
//	ItemImageData Ejectorimage
//	{
//		shapeFile = "force";
//		mountPoint = 0;
//		accuFire = false;
//		mountOffset = { 0.05, 0.3, 0.025 };//right, forward, up	//0.1, 0.25, 0.01
//		mountRotation = {0.5,-1.57, -1.57 };	//0.5,-1.57, -1.57	
//	//	mountOffset = { 0, 0.34, -0.01 };
//	//	mountRotation = {0.5,-1.57, -1.57 };
//		weaponType = 0;
//		projectileType = BurningOzone;	//SpentShell;
//		maxEnergy = 0;	//energy/sec
//		fireTime = 0.0;
//	};
//	
//	ItemData Ejector 
//	{
//		description = "Ejector";
//		className = "Weapon";
//		shapeFile = "force";
//		hudIcon = "mortar";
//		heading = $InvHead[ihWea];
//		shadowDetailMask = 4;
//		imageType = Ejectorimage;
//		price = 375;
//		showWeaponBar = true;
//	};
//

//Plasmatic 2.2
function Railgun::MountExtras(%player,%weapon)
{		
	Player::mountItem(%player,Railgun2,4);
//	Player::mountItem(%player,Ejector,5);
	
//	if((Player::getclient(%player)).weaponHelp)
//		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>The ultimate sniper weapon, now with less suck.");
	
	%client = Player::getclient(%player);
	if (!%client.rail || %client.rail == 0)
		bottomprint(%client, "<jc>Railgun:<f2> Triple projectile, 1/3 damage each projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
	if (%client.rail == 1)
		bottomprint(%client, "<jc>Railgun:<f2> Standard, full damage each projectile.\nPress <f1>Use Laser<f2> or <f1>Use Blaster<f2> (1 and 6 keys) to change.",10);
	
}

// Plasmatic 11/7/2007 5:11AM
// This may be overkill, but it's very accurate.

function RailRound::onadd(%this)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(isPlayerBusy(%cl))
		{
			if(Player::getMountedItem(%cl,$WeaponSlot) == Railgun)
			{
				%player = Client::getOwnedObject(%cl);
				%trans = GameBase::getMuzzleTransform(%player);	//position of tip
				%posX = getWord(%trans,9);		//x
				%posY = getWord(%trans,10);		//y
				%posZ = getWord(%trans,11); 		//z	
				%GunTipPos = %posX@" "@%posY@" "@%posZ;	

				if(vector::getdistance(%GunTipPos, gamebase::getposition(%this))< 0.01)
				{					
					if(%cl.rail != 1)
					{
						schedule("spewRails("@%player@");",0.175);
						schedule("spewRails("@%player@");",0.35);
					}
					else
					{
						%energy = GameBase::getEnergy(%player);
						gamebase::setenergy(%player,%energy -20);
					}
									
			
				}
			}
		}
	}
}

function spewRails(%player)
{
	Player::trigger(%player, 4, true);
	schedule("Player::trigger("@%player@", 4, false);",0.1);
}