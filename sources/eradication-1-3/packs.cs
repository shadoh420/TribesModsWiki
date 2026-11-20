
//----------------------------------------------------------------------------
$InvList[RepairPack] = 1;
$RemoteInvList[RepairPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[harmor, RepairPack] = 1;
$ItemMax[carmor, RepairPack] = 1;
$ItemMax[sarmor, RepairPack] = 1;

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
   minEnergy = 3;
	maxEnergy = 5;   // Energy used/sec for sustained weapons
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 199;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onMount(%player,%item)
{
	GameBase::setAutoRepairRate(%player,GameBase::getAutoRepairRate(%player)+0.03);
}

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
	GameBase::setAutoRepairRate(%player,GameBase::getAutoRepairRate(%player)-0.03);
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		%player.lastWeaponUsed = Player::getMountedItem(%player, $WeaponSlot);
		Player::mountItem(%player,RepairGun,$WeaponSlot);
		%client = Player::getClient(%player);
		Bottomprint(%client, "Repair Gun");
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------
$AssaultPackItems[0] = BulletAmmo;
$AssaultPackItems[1] = GrenadeAmmo;
$AssaultPackItems[2] = MortarAmmo;
$AssaultPackItems[3] = HowitzerAmmo;
$AssaultPackItems[4] = Grenade;

$InvList[AssaultPack] = 1;
$RemoteInvList[AssaultPack] = 1;
$ItemMax[larmor, AssaultPack] = 0;
$ItemMax[lfemale, AssaultPack] = 0;
$ItemMax[marmor, AssaultPack] = 1;
$ItemMax[mfemale, AssaultPack] = 1;
$ItemMax[harmor, AssaultPack] = 1;
$ItemMax[carmor, AssaultPack] = 0;
$ItemMax[sarmor, AssaultPack] = 0;

$AssaultPackMax[BulletAmmo] = 100;
$AssaultPackMax[GrenadeAmmo] = 15;
$AssaultPackMax[MortarAmmo] = 8;
$AssaultPackMax[HowitzerAmmo] = 5;
$AssaultPackMax[Grenade] = 5;

ItemImageData AssaultPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	weaponType = 2; 
	minEnergy = 3;
	maxEnergy = 10;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData AssaultPack
{
	description = "Assault Pack";
	shapeFile = "ShieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AssaultPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 299;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AssaultPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	for(%i = 0; %i <= 4 ; %i = %i +1) 
		{
		%numPack = 0;
		%ammoItem = $AssaultPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		if(%i == 0) %item.BulletAmmo = %numPack;
		else if(%i == 1) %item.GrenadeAmmo = %numPack;
		else if(%i == 2) %item.MortarAmmo = %numPack;
		else if(%i == 3) %item.HowitzerAmmo = %numPack;
		else %item.Grenade = %numPack;
		}
	}
}

function AssaultPack::onCollision(%this,%object)
{
if (getObjectType(%object) == "Player") 
	{
	%item = Item::getItemData(%this);
	%count = Player::getItemCount(%object,%item);
	if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
		Item::playPickupSound(%this);
		checkPacksAmmo(%object, %this);
		Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i <=4 ; %i = %i +1) {
		%ammoItem = $AssaultPackItems[%i];
		if(%i == 0) %numAdd = %item.BulletAmmo;
		else if(%i == 1) %numAdd = %item.GrenadeAmmo;
		else if(%i == 2) %numAdd = %item.MortarAmmo;
		else if(%i == 3) %numAdd = %item.HowitzerAmmo;
		else %numAdd = %item.Grenade;
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "Grenade" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%player,%ammoItem,%numAdd);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
	}						 
}

function fillAssaultPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i <=4 ; %i = %i +1) 
	{
	%item = $AssaultPackItems[%i];
	%maxnum = $AssaultPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "Grenade" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
	}
}

function AssaultPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function AssaultPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}

function AssaultPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 1.5);
}

function AssaultPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 1.5);
}

//----------------------------------------------------------------------------

$DefenderPackItems[0] = DiscAmmo;
$DefenderPackItems[1] = PlasmaAmmo;
$DefenderPackItems[2] = ShotgunAmmo;
$DefenderPackItems[3] = MineAmmo;

$DefenderPackMax[DiscAmmo] = 15;
$DefenderPackMax[PlasmaAmmo] = 15;
$DefenderPackMax[ShotgunAmmo] = 15;
$DefenderPackMax[MineAmmo] = 5;

$InvList[DefenderPack] = 1;
$RemoteInvList[DefenderPack] = 1;
$ItemMax[larmor, DefenderPack] = 1;
$ItemMax[lfemale, DefenderPack] = 1;
$ItemMax[marmor, DefenderPack] = 1;
$ItemMax[mfemale, DefenderPack] = 1;
$ItemMax[harmor, DefenderPack] = 1;
$ItemMax[carmor, DefenderPack] = 1;
$ItemMax[sarmor, DefenderPack] = 1;

ItemImageData DefenderPackImage
{
	shapeFile = "ShieldPack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	weaponType = 2;
	minEnergy = 3;
	maxEnergy = 10;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData DefenderPack
{
	description = "Defender Pack";
	shapeFile = "ShieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = DefenderPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 299;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DefenderPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	for(%i = 0; %i <= 3 ; %i = %i +1) 
		{
		%numPack = 0;
		%ammoItem = $DefenderPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		if(%i == 0) %item.DiscAmmo = %numPack;
		else if(%i == 1) %item.DiscAmmo = %numPack;
		else if(%i == 2) %item.PlasmaAmmo = %numPack;
		else if(%i == 3) %item.ShotgunAmmo = %numPack;
		else %item.MineAmmo = %numPack;
		}
	}
}

function DefenderPack::onCollision(%this,%object)
{
if (getObjectType(%object) == "Player") 
	{
	%item = Item::getItemData(%this);
	%count = Player::getItemCount(%object,%item);
	if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
		Item::playPickupSound(%this);
		checkPacksAmmo(%object, %this);
		Item::respawn(%this);
		}
	}
}

function DefenderPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.08;
}

function DefenderPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}


function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i <=3 ; %i = %i +1) {
		%ammoItem = $DefenderPackItems[%i];
		if(%i == 0) %numAdd = %item.DiscAmmo;
		else if(%i == 1) %numAdd = %item.DiscAmmo;
		else if(%i == 2) %numAdd = %item.PlasmaAmmo;
		else if(%i == 3) %numAdd = %item.ShotgunAmmo;
		else %numAdd = %item.MineAmmo;
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%player,%ammoItem,%numAdd);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
	}						 
}

function fillDefenderPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i <=3 ; %i = %i +1) 
	{
	%item = $DefenderPackItems[%i];
	%maxnum = $DefenderPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
	}
}


function DefenderPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 1.5);
}

function DefenderPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 1.5);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Scout Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

$InvList[ScoutPack] = 1;
$RemoteInvList[ScoutPack] = 1;
$ItemMax[larmor, ScoutPack] = 1;
$ItemMax[lfemale, ScoutPack] = 1;
$ItemMax[marmor, ScoutPack] = 1;
$ItemMax[mfemale, ScoutPack] = 1;
$ItemMax[harmor, ScoutPack] = 0;
$ItemMax[carmor, ScoutPack] = 1;
$ItemMax[sarmor, ScoutPack] = 0;

ItemImageData ScoutPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	sfxFire = SoundFireFlierRocket;
};

ItemData ScoutPack
{
	description = "Scout Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ScoutPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ScoutPackImage::onActivate(%player,%imageSlot)
{
if(GameBase::isAtRest(%player) != True)
	{
	if (GameBase::getEnergy(%player) > 30)
		{ schedule("ScoutPackImage::Boost(" @ %player @ ");",0,%player); }
	else
		{
		Client::sendMessage(Player::getClient(%player),0,"Not enough energy for afterburners.");
		%newEnergy=GameBase::getEnergy(%player)/1.5;
		GameBase::setEnergy(%player,%newEnergy);
		}
	}
if(Player::isTriggered(%player,$BackpackSlot))
	{ Player::trigger(%player,$BackpackSlot,false); }
}


function ScoutPackImage::Boost(%player)
{
	%playerVector=Item::getVelocity(%player);
	%rndCheck=Floor(getRandom()*100);
	if (%rndCheck <=2)
		{ %boostAmount=0.5; %message="They said they fixed it! I trusted them! It's not my fault!"; }
	else if (%rndCheck > 2 && %rndCheck <=5)
		{ %boostAmount=1.0; %message="Damn piece of junk!"; }
	else if (%rndCheck > 10 && %rndCheck < 90)
		{ %boostAmount=2.5; %message="Afterburners!"; }
	else if (%rndCheck >=90 && %rndCheck < 95)
		{ %boostAmount=3; %message="Gawd damn!"; }
	else if (%rndCheck >=95)
		{ %boostAmount=5; %message="You must have a ramjet in your pants!"; }
	else
		{ %boostAmount=2; %message="Boosted."; }
	%boostVector=getWord(%playerVector, 0)*%boostAmount @ " " @ getWord(%playerVector, 1)*%boostAmount @ " " @ getWord(%playerVector, 2)*%boostAmount @ " ";
	Item::setVelocity(%player, %boostVector);
	if(%boostAmount<2)
		playVoice(Player::getClient(%player),"dsgst4");
	else
		{
		GameBase::playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
		playVoice(Player::getClient(%player),"cheer2");
		}
	%newEnergy=GameBase::getEnergy(%player)-30;
	GameBase::setEnergy(%player,%newEnergy);
	Client::sendMessage(Player::getClient(%player),0,%message);
}

function ScoutPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) + 4);
}

function ScoutPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 4);
}

$ScoutPackMax[Beacon] = 3;

function ScoutPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
		%numPack = 0;
		%ammoItem = Beacon;
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		%item.Beacon = %numPack;
	}
}

function ScoutPack::onCollision(%this,%object)
{
if (getObjectType(%object) == "Player") 
	{
	%item = Item::getItemData(%this);
	%count = Player::getItemCount(%object,%item);
	if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
		Item::playPickupSound(%this);
		checkPacksAmmo(%object, %this);
		Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	%ammoItem = Beacon;
	%numAdd = %item.Beacon;
		%sensor = Player::getMountedItem(%player,$SensorSlot);
		if(%sensor != -1 && %sensor != "Beacon" && %maxnum > 0) {
			teamEnergyBuySell(%player,%sensor.price);
			Player::decItemCount(%player,%sensor);
			}
	Player::incItemCount(%player,%ammoItem,%numAdd);
	Player::mountItem(%player,%item,$SensorSlot);
}

function fillScoutPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%item = Beacon;
	%maxnum = $ScoutPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%sensor = Player::getMountedItem(%client,$SensorSlot);
		if(%sensor != -1 && %sensor != "Beacon" && %maxnum > 0) {
			teamEnergyBuySell(%player,%sensor.price);
			Player::decItemCount(%client,%sensor);
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		Player::mountItem(%player,%item,$SensorSlot);
		}	
}

//----------------------------------------------------------------------------

$SniperPackItems[0] = SniperAmmo;
$SniperPackItems[1] = DiscAmmo;
$SniperPackItems[2] = Grenade;
$SniperPackItems[3] = MineAmmo;

$SniperPackMax[DiscAmmo] = 15;
$SniperPackMax[SniperAmmo] = 15;

$InvList[SniperPack] = 1;
$RemoteInvList[SniperPack] = 1;
$ItemMax[larmor, SniperPack] = 1;
$ItemMax[lfemale, SniperPack] = 1;
$ItemMax[marmor, SniperPack] = 1;
$ItemMax[mfemale, SniperPack] = 1;
$ItemMax[harmor, SniperPack] = 0;
$ItemMax[carmor, SniperPack] = 0;
$ItemMax[sarmor, SniperPack] = 0;

ItemImageData SniperPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2; 
	maxEnergy = 10.5;
	sfxFire = SoundJammerOn;
	firstPerson = false;
};

ItemData SniperPack
{
	description = "Sniper Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = SniperPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 199;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SniperPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	for(%i = 0; %i <= 1 ; %i = %i +1) 
		{
		%numPack = 0;
		%ammoItem = $SniperPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		if(%i == 0) %item.SniperAmmo = %numPack;
		else %item.DiscAmmo = %numPack;
		}
	}
}

function SniperPack::onCollision(%this,%object)
{
if (getObjectType(%object) == "Player") 
	{
	%item = Item::getItemData(%this);
	%count = Player::getItemCount(%object,%item);
	if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
		Item::playPickupSound(%this);
		checkPacksAmmo(%object, %this);
		Item::respawn(%this);
		}
	}
}

function SniperPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SniperPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

function SniperPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	%rechargeRate = GameBase::getRechargeRate(%player) + 2;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function SniperPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	%rechargeRate = GameBase::getRechargeRate(%player) - 2;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i <=1 ; %i = %i +1) {
		%ammoItem = $SniperPackItems[%i];
		if(%i == 0) %numAdd = %item.SniperAmmo;
		else %numAdd = %item.DiscAmmo;
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillSniperPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i <=1 ; %i = %i +1) 
	{
	%item = $SniperPackItems[%i];
	%maxnum = $SniperPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//----------------------------------------------------------------------------
$InvList[StealthPack] = 1;
$RemoteInvList[StealthPack] = 1;
$ItemMax[larmor, StealthPack] = 1;
$ItemMax[lfemale, StealthPack] = 1;
$ItemMax[marmor, StealthPack] = 1;
$ItemMax[mfemale, StealthPack] = 1;
$ItemMax[harmor, StealthPack] = 1;
$ItemMax[carmor, StealthPack] = 1;
$ItemMax[sarmor, StealthPack] = 1;

ItemImageData StealthPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
	maxEnergy = 10.5;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
	firstPerson = false;
};

ItemData StealthPack
{
	description = "Stealth Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthPackImage;
	price = 199;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Stealth On");
	%rate = Player::getSensorSupression(%player) + 50;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeOut(%player);
	Item::hide(%player, true);
	GameBase::setIsTarget(%player, false);
}

function StealthPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Stealth Off");
	%rate = Player::getSensorSupression(%player) - 50;
	Player::setSensorSupression(%player,%rate);
	Item::hide(%player, false);
	GameBase::setIsTarget(%player, true);
	GameBase::startFadeIn(%player);
	Player::trigger(%player,$BackpackSlot,false);
}


function StealthPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 2);
}

function StealthPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 2);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Minelayer Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

$InvList[MinelayerPack] = 1;
$RemoteInvList[MinelayerPack] = 1;
$ItemMax[larmor, MinelayerPack] = 1;
$ItemMax[lfemale, MinelayerPack] = 1;
$ItemMax[marmor, MinelayerPack] = 1;
$ItemMax[mfemale, MinelayerPack] = 1;
$ItemMax[harmor, MinelayerPack] = 1;
$ItemMax[carmor, MinelayerPack] = 1;
$ItemMax[sarmor, MinelayerPack] = 1;

ItemImageData MinelayerPackImage
{
	shapeFile = "AmmoPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData MinelayerPack
{
	description = "Minelayer Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = MinelayerPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$MinelayerPackMax[mineammo] = 10;

function MinelayerPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
		%numPack = 0;
		%ammoItem = MineAmmo;
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		%item.MineAmmo = %numPack;
	}
}

function MinelayerPack::onCollision(%this,%object)
{
if (getObjectType(%object) == "Player") 
	{
	%item = Item::getItemData(%this);
	%count = Player::getItemCount(%object,%item);
	if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
		Item::playPickupSound(%this);
		checkPacksAmmo(%object, %this);
		Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	%ammoItem = minemmmo;
	%numAdd = %item.MineAmmo;
	%mine = Player::getMountedItem(%player,$MineSlot);
	if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
		while(Player::getMountedItem(%player,$MineSlot) != -1) {
			teamEnergyBuySell(%player,%mine.price);
			Player::decItemCount(%player,%mine);
			}
		}
	Player::incItemCount(%player,%ammoItem,%numAdd);
	if(Player::getMountedItem(%player,$MineSlot) == -1)
		Player::useItem(%player,%item);
}

function fillMinelayerPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%item = MineAmmo;
	%maxnum = $MinelayerPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
}


function MinelayerPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 3);
}

function MinelayerPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) - 3);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Repulsor Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

$InvList[RepulsorPack] = 1;
$RemoteInvList[RepulsorPack] = 1;
$ItemMax[larmor, RepulsorPack] = 1;
$ItemMax[lfemale, RepulsorPack] = 1;
$ItemMax[marmor, RepulsorPack] = 1;
$ItemMax[mfemale, RepulsorPack] = 1;
$ItemMax[harmor, RepulsorPack] = 0;
$ItemMax[carmor, RepulsorPack] = 1;
$ItemMax[sarmor, RepulsorPack] = 1;

ItemImageData RepulsorPackImage
{
	shapeFile = "armorPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	sfxFire = rocketExplosion;
};

ItemData RepulsorPack
{
	description = "Repulsor Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepulsorPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepulsorPackImage::onActivate(%player,%imageSlot)
{
if (GameBase::getEnergy(%player) > 30)
	{ schedule("RepulsorPackImage::Repel(" @ %player @ ");",0,%player); }
else
	{
	Client::sendMessage(Player::getClient(%player),0,"Not enough energy to repulse.");
	%newEnergy=GameBase::getEnergy(%player)/1.5;
	GameBase::setEnergy(%player,%newEnergy);
	}
if(Player::isTriggered(%player,$BackpackSlot))
	{ Player::trigger(%player,$BackpackSlot,false); }
}


function RepulsorPackImage::Repel(%player)
{
	%playerPos=GameBase::getPosition(%player);
  	%repelSet=newObject("grendadeSet",SimSet);
	%numObjects=containerBoxFillSet(%repelSet,$SimPlayerObjectType | $VehicleObjectType,%playerPos,35,35,15,0);
	for (%objCounter=0; %objCounter <= %numObjects; %objCounter++)
		{
		%target=Group::getObject(%repelSet, %objCounter);
		if (%target != %player)
			{
			%targetPos=GameBase::getPosition(%target);
			%targetVector=Vector::neg(Vector::sub(%playerPos, %targetPos));
			%distanceToTarget=Vector::getDistance(%targetPos, %playerPos);
			%force=10-(%distanceToTarget*0.25);
			%targetNewVector=getWord(%targetVector, 0) * %force @ " " @ getWord(%targetVector, 1) * %force @ " " @ getWord(%targetVector, 2) * %force @ " "; 
			playSound(rocketExplosion, %targetPos);
			Item::setVelocity(%target, %targetNewVector);
			}
		}
	deleteObject(%repelSet);
//	playVoice(Player::getClient(%player),"hitdeck");
	%newEnergy=GameBase::getEnergy(%player)-30;
	GameBase::setEnergy(%player,%newEnergy);
}

function RepulsorPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	%rechargeRate = GameBase::getRechargeRate(%player) + 2;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function RepulsorPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	%rechargeRate = GameBase::getRechargeRate(%player) - 2;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Commander Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

$InvList[CommanderPack] = 1;
$RemoteInvList[CommanderPack] = 1;
$ItemMax[larmor, CommanderPack] = 0;
$ItemMax[lfemale, CommanderPack] = 0;
$ItemMax[marmor, CommanderPack] = 0;
$ItemMax[mfemale, CommanderPack] = 0;
$ItemMax[harmor, CommanderPack] = 0;
$ItemMax[carmor, CommanderPack] = 1;
$ItemMax[sarmor, CommanderPack] = 0;

ItemImageData CommanderPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	sfxFire = SoundRepairItem;
};

ItemData CommanderPack
{
	description = "Commander Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CommanderPackImage;
	price = 499;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CommanderPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 3);
	GameBase::setAutoRepairRate(%player, Gamebase::getAutoRepairRate(%player) + 0.085);
	%player.shieldStrength = 0.005;
}

function CommanderPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 3);
	GameBase::setAutoRepairRate(%player, Gamebase::getAutoRepairRate(%player) - 0.085);
	%player.shieldStrength = 0;
}