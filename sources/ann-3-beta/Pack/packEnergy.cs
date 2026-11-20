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
	maxEnergy = -5;
	firstPerson = false;
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

function EnergyPack::onUse(%player,%item) 
{		
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		//Plasmatic 3.0 -E Pack booster
		%armor = Player::getArmor(%player);
		%available = GameBase::getEnergy(%player) / (%armor.maxEnergy);
		if(%available < 0.20) // || %player.usedpack)
			echo("no eboost");//Client::sendMessage(Player::getClient(%player),0, "Not enough energy to convert.");		
		else
		{
			//.maxEnergy
		//	%armor = Player::getArmor(%player);
		//	%maxEnergy = %armor.maxEnergy;
		//	%energy = GameBase::getEnergy(%player);
		//	%available = GameBase::getEnergy(%player)/(%armor.maxEnergy);
			%power = %available*100+50;
		//	echo("epack boost "@%power);
			gamebase::setenergy(%player,GameBase::getEnergy(%player)*2/3);

			%vec = Item::getVelocity(%player);
			if(%vec == "0 0 0")
			{
			//send em where they look... not just forward..
				%trans = GameBase::getMuzzleTransform(%player);
				%smack = %power/25;
				%rot=GameBase::getRotation(%player);
				%tr= getWord(%trans,5);
				if(%tr <=0 )%tr -=%tr;
				%up = %tr+0.15;
				%out = 1-%tr;
				%vec = Vector::getFromRot(%rot,30*%out*%smack,30*%up*%smack);
				}
		
			else
			{	
				%vec = Vector::Normalize(%vec);
				%vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power;
			}
			Player::applyImpulse(%player, %vec);
			GameBase::playSound(%player, SoundFireGrenade, 0);
		//	Client::sendMessage(Player::getClient(%player),0, "Converting energy to speed.");
			SplitMines(%player,%player);
		//	%player.usedpack = true;
		//	schedule(%player@".usedpack = false;",1.5);	
		}
			
	}
}

function EnergyPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	Player::trigger(%player,$BackpackSlot,true);
	bottomprint(Player::getClient(%player), "<jc> " @ %item.description , 15);	
}


