$InvList[RepairPack] = 1;
$MobileInvList[RepairPack] = 1;
$RemoteInvList[RepairPack] = 1;
AddItem(RepairPack);



ItemImageData RepairPackImage 
{	
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	sfxFire = SoundRepairItem;
};

ItemData RepairPack 
{	
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};



ExplosionData repairExp
{
	shapeName = "plasmaex.dts";
//	soundId = SoundPickupHealth;
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeZero = 0.9;
	timeOne = 0.250;
	colors[0] = { 1.0, 1.0, 0.0 };
	colors[1] = { 1.0, 1.0, 0.75 };
	colors[2] = { 1.0, 1.0, 0.75 };
	radFactors = { 0.375, 1.0, 0.9 };
};	
GrenadeData RepairlBurn
{

   bulletShapeName = "plasmabolt.dts";
   explosionTag       = repairExp;
   collideWithOwner   = True;
   ownerGraceMS       = 25;	//250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $HealingDamage;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 25;	//275
   totalTime          = 0.25;
   liveTime           = 0.25; // grenade time live after contact
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";//mortartrail
};


// cycle time is 18 secs, active time is 10 seconds.. 8 secs recharge. -Plasmatic


function RepairDamage(%this,%value)
{

	%dlevel = GameBase::getDamageLevel(%this) - %value;
	//GameBase::setDamageLevel(%this,%dlevel);	
	GameBase::repairDamage(%this,%value);

	
}

function RepairPackImage::onActivate(%player,%imageSlot) 
{

//	GameBase::playSound(%player, SoundFireGrenade, 0);
	%item = Player::getMountedItem(%player,$BackpackSlot);
	
//	schedule("Player::trigger("@%player@",1,false);",10);
	%player.packrecharge = 18;
	Backpack::recharge(%player,%item);
	RepairPack::Animate(%player,%item);
}
function RepairPack::Animate(%player,%pack)
{
	%item = Player::getMountedItem(%player,$BackpackSlot);
	if(Player::isTriggered(%player,$BackpackSlot) && %item == %pack)
	{
		%vel = Item::getVelocity(%player);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{
			%pos = getBoxCenter(%player);
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %pos;
			 %rot = GameBase::getRotation(%player);			
			for(%i=0.627; %i < 6.28; %i += 1.256) 
			{
				%forceVel = Vector::getFromRot(vector::add("0 0 " @ %i,%rot), 10, 5);
		 		%obj = Projectile::spawnProjectile("RepairlBurn", %trans, %player, %vel);
				Projectile::spawnProjectile(%obj);
				Item::setVelocity(%obj, %forceVel);
			}
		}
		else 	
			echo("!! Butterfly Error, Repair Pack. vel ="@%vel);			
		schedule("RepairPack::Animate("@%player@", "@%pack@");",1);		
	}
}
function RepairPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	GameBase::setAutoRepairRate(%player,0.0125);		//0.025 %2.5% rate.. -Plasmatic
	//Player::trigger(%player,$BackpackSlot,true);
	if((Player::getclient(%player)).weaponHelp)
		bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);	
}

function RepairPack::onDrop(%player,%item) 
{	
	if($matchStarted) 
	{	
		GameBase::setAutoRepairRate(%player,0.0);
		%obj = Item::onDrop(%player,%item);
		//transfer pack properties -Plasmatic
		%obj.packused = %player.usedpack;
		%player.usedpack = false;
	}
}
