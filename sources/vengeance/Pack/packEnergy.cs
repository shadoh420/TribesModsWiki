$InvList[EnergyPack] = 1;
$MobileInvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;
AddItem(EnergyPack);

ItemImageData EnergyPackImage 
{	
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -3;
	maxEnergy = -5;	//energy used per sec.
	firstPerson = false;
	sfxFire = SoundEnergyPackOn;
};

ItemData EnergyPack 
{	
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};





GrenadeData PrettySplit
{
//plasmatic
   bulletShapeName    = "shotgunbolt.dts";//grenade.dts
   explosionTag       = AgedonSplitExp;//FlakExp;//VolcanoExp;//plasmaExp
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;	//0.1
   damageType         = $ShrapnelDamageType;//$PlasmaDamageType;//

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";//smoke.dts
};

function EnergyPackImage::onActivate(%player,%imageSlot) 
{
	if(%player.packrecharge <1)
	{	
		//send em where they look... not just forward..
		%power = 150;	//%available*100+50;
			%trans = GameBase::getMuzzleTransform(%player);
			%smack = %power/25;
			%rot=GameBase::getRotation(%player);
			%up= getWord(%trans,5);
	
			if(%up >0 )
				%out = 1-%up;
			else
				%out = 1+%up;
			%vec = Vector::getFromRot(%rot,30*%out*%smack,30*%up*%smack);
		//	echo("e pack force "@%vec);
		Player::applyImpulse(%player, %vec);
		GameBase::playSound(%player, SoundFireGrenade, 0);
		%item = Player::getMountedItem(%player,$BackpackSlot);
		EnergyPack::Animate(%player,%player);
	//	schedule("Player::trigger("@%player@",1,false);",10);
		%player.packrecharge = 18;
		Backpack::recharge(%player,%item);
	}
}
function EnergyPack::Animate(%newobj,%this)
{
	
	%vel = Item::getVelocity(%newobj);
	if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
	{	
		// Pretty shell split
		%Pos = GameBase::getPosition(%newobj); 
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
		%vel = Item::getVelocity(%newobj);
	 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %vel);
	}
	else
		echo("!! Butterfly Error, Energypack. vel ="@%vel);		
}
function EnergyPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	GameBase::setRechargeRate(%player,8*1.30);		// %30% increase.. -Plasmatic
	
	//Player::trigger(%player,$BackpackSlot,true);
	if((Player::getclient(%player)).weaponHelp)
		bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);	
}

function EnergyPack::onDrop(%player,%item) 
{	
	if($matchStarted) 
	{	
		GameBase::setRechargeRate(%player,8);
		%obj = Item::onDrop(%player,%item);
		//transfer pack properties -Plasmatic
		%obj.packused = %player.usedpack;
		%player.usedpack = false;
	}
}
