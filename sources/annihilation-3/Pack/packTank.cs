$InvList[TankPack] = 1;
$MobileInvList[TankPack] = 1;
$RemoteInvList[TankPack] = 1;
AddItem(TankPack);



ItemImageData TankPackImage 
{	
	shapeFile = "remoteturret";	//shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mass = 1;
	mountOffset = { -0.40, 0.025 , 0.35 };	//right, forward, up
	mountRotation = {-1.57, 0, 0};	//up, right, around player axis	
	firstPerson = false;
};

ItemData TankPack 
{	
	description = "Tank Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TankPackImage;
	price = 125;
	hudIcon = "RepairPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
ItemImageData TankPackImageA 
{	
	shapeFile = "energygun";	//shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { -0.35, 0.2 , 0.45 };	//right, forward, up
	mountRotation = {0.20, 0, 0};	//up, right, around player axis	
	firstPerson = true;
};
ItemData TankPackA 
{	
	description = "Tank Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = TankPackImageA;
	price = 125;
	hudIcon = "RepairPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function TankPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
		Player::mountItem(%player,TankPackA,7);
		%player.shieldStrength = 0.004;	//0.012
	}
	else 
	{	
		if($debug)
			echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		if(!%player.packreloading)	
		{
			for(%i=0; %i<6; %i++)
			{
				schedule("RocketPod::PhotonTorpedo("@%player@");", %i/5 );
			}
			%player.packreloading = true;
			schedule(%player@".packreloading=false;",5);
			schedule(%player@".packreloading=false;",5);
			schedule("GameBase::playSound("@%player@", SoundEnergyTurretOff, 0);",5);
		}
	}


}

function TankPack::onDrop(%player,%item) 
{	
	if($matchStarted) 
	{	
//		%mounted = Player::getMountedItem(%player,7);
//		if(%mounted == RocketPod) 
//		{	
			Player::unmountItem(%player,7);
//		}

		Item::onDrop(%player,%item);
	}
	%player.shieldStrength = 0;
}
function TankPack::onUnmount(%player,%item) 
{	
	
	Player::unmountItem(%player,7);
	%player.shieldStrength = 0;
}
