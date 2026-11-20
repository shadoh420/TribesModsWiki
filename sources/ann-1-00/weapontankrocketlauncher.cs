$InvList[KRocketLauncher] = 1;
$MobileInvList[KRocketLauncher] = 1;
$RemoteInvList[KRocketLauncher] = 1;

$InvList[KRocketLauncherAmmo] = 1;
$MobileInvList[KRocketLauncherAmmo] = 1;
$RemoteInvList[KRocketLauncherAmmo] = 1;

$AutoUse[KRocketLauncher] = True;
$WeaponAmmo[KRocketLauncher] = KRocketLauncherAmmo;

addweapon(KRocketLauncher);
addAmmo(KRocketLauncher, KRocketLauncherAmmo, 8);

$KRocketLauncherSlotA=4;
$KRocketLauncherSlotB=7;
$KRocketLauncherSlotC=6; 

ItemData KRocketLauncherAmmo
{	description = "KRocketLauncher Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData KRocketLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = KRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData KRocketLauncher 
{	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "mortar"; 
	heading = $InvHead[ihWea]; 
	shadowDetailMask = 4; 
	imageType = KRocketLauncherImage; 
	price = 2500; 
	showWeaponBar = true; 
}; 

ItemImageData KRocketLauncher2Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = KRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};	

ItemData KRocketLauncher2 
{	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = KRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData KRocketLauncher3Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = KRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData KRocketLauncher3 
{	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = KRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData KRocketLauncher4Image 
{	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = KRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData KRocketLauncher4 
{	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = KRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

//  Begin KRocketLauncher Fire Function
                     
function KRocketLauncherImage::onFire(%player, %slot) 
{	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[KRocketLauncher]);
	if(%AmmoCount)
	{	%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		
		// ------- Second Projectile Placement --------
		
		%pos=gamebase::getposition(%player);
		%rot=gamebase::getrotation(%player);
		%vec=Vector::getFromRot(%rot);
		
		%vec1=getWord(%vec,0);
		%vec2=getWord(%vec,1);
		
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=getWord(%trans,3);
		%pos5=getWord(%trans,4);
		%pos6=getWord(%trans,5);
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9) + %vec2;
		%pos11=getWord(%trans,10) - %vec1;
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
		// ----- End of Second Projectile Placement -----
		
		%vel = Item::getVelocity(%player);
		GameBase::getLOSInfo(%player,3000);
		%tpos=($los::position);
		%target=AquireTarget(%player,0,%tpos);
		if(%target)
		{	%targetcl=Player::GetClient(%target);	 
			%jam=CheckTargetJamming(%target);
			if(%jam==1)
			{	Player::decItemCount(%player,$WeaponAmmo[KRocketLauncher],2);
				Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,$los::object);
				if(!$MDFiringKRocketLauncher[%client]) 
					MDCheckKRocketLauncher(%client, %player);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				//GiveKickBack(%player, 125, 1);
			}
			else
			{	Player::decItemCount(%player,$WeaponAmmo[KRocketLauncher],2);
				Projectile::spawnProjectile("TankMissile",%trans,%player,%vel,%target);
				Projectile::spawnProjectile("TankMissile",%trans2,%player,%vel,%target);
				if(!$MDFiringKRocketLauncher[%client]) 
					MDCheckKRocketLauncher(%client, %player); 
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				//GiveKickBack(%player, 125, 1);
				%name = Client::getName(%target);
				SendLockWarning(%TargetCl,1);
				Client::sendMessage(%client,0,"** Image Lock Aquired - " @ %name @ "~wmine_act.wav");
			}
		}
		else
		{	Client::sendMessage(%client,0,"** No Image Lock (Alternate Scan Engaged)- " @ %name @ "~wmine_act.wav");
			%tpos=GameBase::getPosition(%player);
			%target=AquireTarget(%player,1,%tpos);
			if(%target)
			{	%TargetCl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	Player::decItemCount(%player,$WeaponAmmo[KRocketLauncher],2);
					Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,$los::object);
					Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,$los::object);
					if(!$MDFiringKRocketLauncher[%client]) 
						MDCheckKRocketLauncher(%client, %player);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					//GiveKickBack(%player, 125, 1);
				}
				else
				{	Player::decItemCount(%player,$WeaponAmmo[KRocketLauncher],2);
					Projectile::spawnProjectile("TankMissile",%trans,%player,%vel,%target);
					Projectile::spawnProjectile("TankMissile",%trans2,%player,%vel,%target);
					if(!$MDFiringKRocketLauncher[%client]) 
						MDCheckKRocketLauncher(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					//GiveKickBack(%player, 125, 1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,2);
					Client::sendMessage(%client,0,"** Sensor Lock Aquired - " @ %name @ "~wmine_act.wav");
				}
			}
			else
			{	Player::decItemCount(%player,$WeaponAmmo[KRocketLauncher],2);
				Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,$los::object);
				if(!$MDFiringKRocketLauncher[%client]) 
					MDCheckKRocketLauncher(%client, %player);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				//GiveKickBack(%player, 125, 1);  // ??? new 
				Client::sendMessage(%client,0,"** NO Valid Target Firing Unprogrammed Missile ** " @ %name @ "~wmine_act.wav");
			}
		}
	}	
	else
	Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

function CheckTargetJamming(%target)
{	// Is Target A Player If not Return a 0
	// If target Wearing a jamming Pack & is it turned on If No Return a 0 If Yes return a 1
	%jamming=0;
	%type=getObjectType(%target);
	if(%type!="PLAYER")
		return(0);
	%pack=Player::getMountedItem(%target,$BackpackSlot);
	if (%pack=="SensorJammerPack")
	{	if($trace) 
			echo($ver,"| Target Has Jammer Pack =",%pack);
		if(Player::isTriggered(%target,$BackpackSlot) )
			%jamming=1;
	}
	return (%jamming);
}

function AquireTarget(%this,%option,%pos)
{	// Options are	0 - Line of Sight Scan
	//		1 - Local Area Scan
	//		2 - Infiltrator Jammed Scan
	//		3 - AAPC Scan
	if($trace) 
		echo($ver,"| Aquiring Target for player ",%this," type of scan ",%option," Position ",%pos);
	%team = GameBase::getTeam(%this);
	%target=0;
	%set = newObject("set",SimSet);
	if(%option==1)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,250,250,250,0);
	}
	else if(%option==2)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,250,250,250,0);
	}
	else if(%option==3)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,200,200,-100,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,80,80,80,0);
	// echo(" Number of Objects = ",%tnum);
	if (%tnum>0)
	{	// There are Targets within scan range
		if($traceAll) echo($Ver,"| RocketGun Scan Has Located ",%tnum," Targets.. in a ",%option," Scan");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(%option==2)
			{	echo("Jammed Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team==%tgtTeam)
					%target=%tgt;
			}
			else
			{	echo("Normal Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team!=%tgtTeam) 
					%target=%tgt;
			}
			if(%target)
			{	%i=%tnum;
			}
		}
	}
	deleteObject(%set);
	return (%target);
}

function KRocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, KRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function KRocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,KRocketLauncher2,$KRocketLauncherSlotA); 
	Player::mountItem(%player,KRocketLauncher3,$KRocketLauncherSlotB); 
	Player::mountItem(%player,KRocketLauncher4,$KRocketLauncherSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Tank RocketLauncher: <f2>This duel heat seeking launcher will lock onto your enemies."); 
}

function KRocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$KRocketLauncherSlotA);
	Player::unmountItem(%player,$KRocketLauncherSlotB);	 
	Player::unmountItem(%player,$KRocketLauncherSlotC);
}

function MDCheckKRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "KRocketLauncher")) 
	{	Player::trigger(%player,$KRocketLauncherSlotA,true);
		Player::trigger(%player,$KRocketLauncherSlotB,true);
		Player::trigger(%player,$KRocketLauncherSlotC,true);
		schedule("MDCheckKRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringKRocketLauncher[%client] = true;
	} 
	else 
	{	Player::trigger(%player,$KRocketLauncherSlotA,false); 
		Player::trigger(%player,$KRocketLauncherSlotB,false); 
		Player::trigger(%player,$KRocketLauncherSlotC,false); 
		$MDFiringKRocketLauncher[%client] = false; 
	} 
}
