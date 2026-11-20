
// shielded players convert some damage into kickback also, handled in player.cs -Plasmatic

$InvList[ShieldPack] = 1;
$MobileInvList[ShieldPack] = 1;
$RemoteInvList[ShieldPack] = 1;
AddItem(ShieldPack);

ItemImageData ShieldPackImage 
{	
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack 
{	
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};



//====================



//==========================
function ShieldPackImage::onActivate(%player,%imageSlot) 
{
	%player.shieldStrength = 0.65;
	
//	GameBase::playSound(%player, SoundFireGrenade, 0);
	%item = Player::getMountedItem(%player,$BackpackSlot);
	ShieldPack::Animate(%player,%player);
//	schedule("Player::trigger("@%player@",1,false);",10);
	%player.packrecharge = 18;
	Backpack::recharge(%player,%item);
}

function ShieldPack::Animate(%player,%pack)
{
	%item = Player::getMountedItem(%player,$BackpackSlot);
	if(Player::isTriggered(%player,$BackpackSlot) && %item == %pack)
	{
		%vel = Item::getVelocity(%player);
		// verify we're not getting "-INF +INF -INF" or something similar for vel... -Plasmatic
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{
			%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
			Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
		}
		else 	
			echo("!! Butterfly Error, Shield Pack. vel ="@%vel);

		schedule("ShieldPack::Animate("@%player@", "@%pack@");",1);		
	}
}

function ShieldPackImage::onDeactivate(%player,%imageSlot) 
{	
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0.20;
}


function ShieldPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	%player.shieldStrength = 0.20;		// %20% damage reduction.. -Plasmatic
	//Player::trigger(%player,$BackpackSlot,true);
	if((Player::getclient(%player)).weaponHelp)
		bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);	
}

function ShieldPack::onDrop(%player,%item) 
{	
	if($matchStarted) 
	{	
		%player.shieldStrength = 0.0;
		%obj = Item::onDrop(%player,%item);
		//transfer pack properties -Plasmatic
		%obj.packused = %player.usedpack;
		%player.usedpack = false;
	}
}
