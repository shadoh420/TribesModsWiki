//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[PhaseShifterPack] = 1;

$ItemMax[larmor, PhaseShifterPack] = 1;	//Seraph
$ItemMax[lfemale, PhaseShifterPack] = 1;//Seraph
$ItemMax[earmor, PhaseShifterPack] = 0;	//Slave
$ItemMax[efemale, PhaseShifterPack] = 0;//Slave
$ItemMax[marmor, PhaseShifterPack] = 0;	//Pawn
$ItemMax[aarmor, PhaseShifterPack] = 1;	//Navigator
$ItemMax[darmor, PhaseShifterPack] = 0;	//Atomizer
$ItemMax[barmor, PhaseShifterPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

// From Annihilation

$WarpSafeTime = 8;
$WarpRange = 210;
$WarpChance = 6.5;

ItemImageData PhaseShifterPackImage
{	
	shapeFile = "shieldpack";  //chaingun
	
	//mountOffset = { -0.3, -0.6, 0 };
        //mountRotation = {1.57,0, 3.14 };
	
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = false;
};

ItemData PhaseShifterPack
{	
	description = "Hyperdrive";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = PhaseShifterPackImage;
	price = 333;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PhaseShifterPackImage::onActivate(%player,%imageSlot)
{	
	%client = Player::getClient(%player);
	%player = Client::getOwnedObject(%client);
	if (GameBase::getLOSInfo(%player,$WarpRange))
	{
		%dest = $los::position;
		if($WarpTime[%client] > 0)
		{
			Bottomprint(%client, "<jc><f1>Warning!\n<jc><f0>Hyperdrive Core not stable.");
			if(floor(getrandom() * 100) > $WarpChance)
			{	
				GameBase::setPosition(%client,"0 0 10000");
				$WarpWrapTime[%client] = 0.6;
				$WarpStable[%client] = 0;
				WarpWrap(%client,%player,%dest);
				GameBase::setEnergy(%client,0);
				Player::kill(%client);
				Client::onKilled(%client,%client);
				$WarpTime[%client] = 0;
				PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
			}
			else
			{	
				GameBase::setPosition(%client,"0 0 10000");
				$WarpWrapTime[%client] = 0.6;
				$WarpStable[%client] = 1;
				WarpWrap(%client,%player,%dest);
				GameBase::setEnergy(%client,0);
				PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
			}
		}
		else
		{	
			GameBase::setPosition(%client,"0 0 10000");
			$WarpWrapTime[%client] = 0.6;
			$WarpStable[%client] = 2;
			WarpWrap(%client,%player,%dest);
			GameBase::setEnergy(%client,0);
			PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
			$WarpTime[%client] = $WarpSafeTime;
			checkSafeWarp(%client,%player);
		}
	}
	else
	{	
		Bottomprint(%client, "<jc>Hyperdrive coordinates out of range");
		PhaseShifterPackImage::onDeactivate(%client,%imageSlot);
	}
}

function PhaseShifterPackImage::onDeactivate(%player,%imageSlot)
{	
	Player::trigger(%player,$BackpackSlot,false);
}

function PhaseShifterPack::onMount(%player,%item)
{	
	%client = Player::getClient(%player);
	Bottomprint(%client, "<f1>Hyperdrive: <f2>**WARNING** <f0>Allows short range teleportation via the users HUD crosshair. <f2>**WARNING**<f1>");
}

function checkSafeWarp(%client,%player)
{	
	if ($WarpTime[%client] > 0)
	{	
		$WarpTime[%client] -= 1;
		schedule("checkSafeWarp(" @ %client @ "," @ %player @ ");",1,%player);
	}
	else
	{	
		$WarpTime[%client] = 0;
		Bottomprint(%client, "<jc><f1>Hyperdrive Core stabilized");
	}
}

function WarpWrap(%client,%player,%dest)
{	
	if ($WarpWrapTime[%client] > 0)
	{	
		$WarpWrapTime[%client] -= 0.6;
		schedule("WarpWrap(" @ %client @ "," @ %player @ ",\"" @ %dest @ "\");",1,%player);
	}
	else
	{	
		$WarpWrapTime[%client] = 0;
		GameBase::setPosition(%client,%dest);
		if ($WarpStable[%client] == 2)
		{	
			Bottomprint(%client, "<jc><f1>Hyperdrive Successful!\n<jc><f0>Drive Core restabilizing");
		}
		else
		{	if ($WarpStable[%client] == 1)
			{	
				Bottomprint(%client, "<jc><f1>Hyperdrive Successful!\n<jc><f0>Drive Core still unstable");
			}
			else
			{	
				Bottomprint(%client, "<jc><f1>Hyperdrive Unsuccessful!\n<jc><f0>The Drive Core has failed, you have been torn apart");
			}
		}
	}
}