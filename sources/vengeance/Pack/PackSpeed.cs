$InvList[SpeedPack] = 1;
$MobileInvList[SpeedPack] = 1;
$RemoteInvList[SpeedPack] = 1;
AddItem(SpeedPack);



ItemImageData SpeedPackImage 
{	
	shapeFile = "sensorjampack";	//shapeFile = "ammoPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	sfxFire = SoundJammerOn;
};

ItemData SpeedPack 
{	
	description = "Speed Pack";
	shapeFile = "sensorjampack";	//shapeFile = "ammoPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SpeedPackImage;
	price = 125;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function oldSpeedPackImage::onActivate(%player,%imageSlot) 
{

//	GameBase::playSound(%player, SoundFireGrenade, 0);
	%item = Player::getMountedItem(%player,$BackpackSlot);
	
	%player.packrecharge = 18;
	Backpack::recharge(%player,%item);
//	SpeedPack::Animate(%player,%item);
	
	%client = 	Player::getClient(%player);
	
	%armor = Player::getArmor(%client);
	%baseArmor = $ArmorName[%armor];
	%buyarmor = $ArmorType[Client::getGender(%client), %basearmor] @ "Speed";
	Player::setItemCount(%client, $ArmorName[%armor], 0);  
	
	%energy = GameBase::getEnergy(%player);
//	Player::setArmor(%client,%buyarmor);
	Player::setItemCount(%client, $ArmorName[%armor], 1);  
	GameBase::setEnergy(%player,%energy);	
		
		
//	bottomprint(Player::getClient(%player), "<jc> a " @%armor@", an "@ %basearmor@", new "@%buyarmor, 15);
		
	
}

function SpeedPack::Deactivate(%player)
{

//	GameBase::playSound(%player, SoundFireGrenade, 0);
	%item = Player::getMountedItem(%player,$BackpackSlot);
	if(%item == SpeedPack)
	{
		
		%client = 	Player::getClient(%player);
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
	//	Player::unMountItem(%player,$WeaponSlot);
	//	if(!string::icompare($ArmorType[Client::getGender(%client), %basearmor] @ "Speed", %armor))
	
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		%buyarmor = $ArmorType[Client::getGender(%client), %basearmor]@"Fast";
		
		%energy = GameBase::getEnergy(%player);
		Player::setArmor(%client,%buyarmor);
		GameBase::setEnergy(%player,%energy);
	//	Player::MountItem(%player,%weapon,$WeaponSlot);
		
//		echo("speedpack off");

	}

}

function SpeedPack::Animate(%player,%pack)
{

	%item = Player::getMountedItem(%player,$BackpackSlot);
//	echo("speed animate "@%player@", "@%pack@", "@%item@", charge "@%player.packrecharge);	
	if(%item == %pack && %player.packrecharge > 8)
	{
		%vel = Item::getVelocity(%player);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{
			%pos = getBoxCenter(%player);
			%trans =  "0 0 1 0 0 0 0 0 1 " @ %pos;
			 %rot = GameBase::getRotation(%player);		
			Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		}
		else 	
			echo("!! Butterfly Error, Speed Pack. vel ="@%vel);	
		schedule("SpeedPack::Animate("@%player@", "@%pack@");",0.2);		
	}
}
function SpeedPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	%client = 	Player::getClient(%player);
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
	//	Player::unMountItem(%player,$WeaponSlot);
			
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		%buyarmor = $ArmorType[Client::getGender(%client), %basearmor]@"Fast";
		
		%energy = GameBase::getEnergy(%player);
		Player::setArmor(%client,%buyarmor);
		GameBase::setEnergy(%player,%energy);
	//	Player::MountItem(%player,%weapon,$WeaponSlot);

	
	//bottomprint(Player::getClient(%player), "<jc> a " @%armor@", an "@ %basearmor@", new "@%buyarmor, 15);
	
	
	
	
	//Player::trigger(%player,$BackpackSlot,true);
	if((Player::getclient(%player)).weaponHelp)
		bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);	
}

function SpeedPack::onDrop(%player,%item) 
{	
	if($matchStarted) 
	{	

	%client = 	Player::getClient(%player);
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
	//	Player::unMountItem(%player,$WeaponSlot);	
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		%buyarmor = $ArmorType[Client::getGender(%client), %basearmor];
		
		%energy = GameBase::getEnergy(%player);
		Player::setArmor(%client,%buyarmor);
		GameBase::setEnergy(%player,%energy);
	//	Player::MountItem(%player,%weapon,$WeaponSlot);


		%obj = Item::onDrop(%player,%item);
		//transfer pack properties -Plasmatic
		%obj.packused = %player.usedpack;
		%player.usedpack = false;
	}
}

// had to be ::onUse for this, crashy otherwise.. -Plasmatic
function SpeedPack::onUse(%player,%item)
{
	%client = GameBase::getOwnerClient(%player);
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	//	bottomprint(Player::getClient(%player), "<jc>Ghost Pack: <f2>Shadow shift through walls.", 10);
	}
	else
	{
		if(%player.packrecharge > 0)
			GameBase::playSound(%player, SoundPackFail, 0);
		else
		{
			Player::trigger(%player,$BackpackSlot,true);
			%armor = Player::getArmor(%client);
			%baseArmor = $ArmorName[%armor];
		//	if(!string::icompare($ArmorType[Client::getGender(%client), %basearmor] @ "Fast", %armor))
		//	{
				if(!String::ICompare(Client::getGender(%client), "Male"))
					GameBase::playSound(%client, MAaargh, 0);//client::sendmessage(%client, 0, "~wmale5.wdsgst4.wav");
				else 
					GameBase::playSound(%client, FAaargh, 0);//client::sendmessage(%client, 0, "~wfemale1.wdsgst4.wav");
		%weapon = Player::getMountedItem(%player,$WeaponSlot);
	//	Player::unMountItem(%player,$WeaponSlot);			
				
				%buyarmor = $ArmorType[Client::getGender(%client), %basearmor] @ "Speed";
				
				%energy = GameBase::getEnergy(%player);
				Player::setArmor(%client,%buyarmor);
				GameBase::setEnergy(%player,%energy);
		//		Player::MountItem(%player,%weapon,$WeaponSlot);	
					
					
		//		bottomprint(Player::getClient(%player), "<jc> ON! a " @%armor@", an "@ %basearmor@", new "@%buyarmor, 15);
		
			%item = Player::getMountedItem(%player,$BackpackSlot);
		
			%player.packrecharge = 18;
		//	SpeedPack::Animate(%player,%item);
			Backpack::recharge(%player,%item);	
		//	}	
		//	else	
		//		bottomprint(Player::getClient(%player), "<jc> ????! a " @%armor@", an "@ %basearmor@", new "@%buyarmor, 15);
			
			
		}
			
	}
}


