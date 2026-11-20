$InvList[PhaseShifterPack] = 1;
$MobileInvList[PhaseShifterPack] = 1;
$RemoteInvList[PhaseShifterPack] = 1;

$WarpSafeTime = 8;
$WarpRange = 550;
$WarpChance = 60;

ItemImageData PhaseShifterPackImage
{	
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 10;
	maxEnergy = 10;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 3.14, 0, 0 };
	lightType = 3;
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 0.3, 0.1, 0.6 };
	firstPerson = false;
};

ItemData PhaseShifterPack
{	
	description = "Phase Shifter";
	shapeFile = "shield";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = PhaseShifterPackImage;
	price = 15;
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
			Bottomprint(%client, "<jc><f1>Warning!\n<jc><f0>Phase Shifter field not stabilized");
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
		Bottomprint(%client, "<jc>Phase Shift position out of range");
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
	Bottomprint(%client, "<f1>Phase Shifter:<f0> Allows short range teleportation via the users HUD crosshair - but can badly misfunction. ");
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
		Bottomprint(%client, "<jc><f1>Phase Shifter field stabilized");
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
			Bottomprint(%client, "<jc><f1>Phase Shift Successful!\n<jc><f0>Phase Shift field restabilizing");
		}
		else
		{	if ($WarpStable[%client] == 1)
			{	
				Bottomprint(%client, "<jc><f1>Phase Shift Successful!\n<jc><f0>Phase Shift field still unstable");
			}
			else
			{	
				Bottomprint(%client, "<jc><f1>Phase Shift Unsuccessful!\n<jc><f0>The Phase Shift tears you to apart");
			}
		}
	}
}
