$InvList[ParticleBeamWeapon] = 1;
$MobileInvList[ParticleBeamWeapon] = 1;
$RemoteInvList[ParticleBeamWeapon] = 1;

$AutoUse[ParticleBeamWeapon] = false;

addWeapon(ParticleBeamWeapon);

ItemImageData ParticleBeamWeaponImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 1;
	//projectileType = targetLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	fireTime = 0.001;
	spinUpTime = 0.001;
	spinDownTime = 0.001;
	reloadTime = 2.0;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	//sfxFire = SoundFireTargetingLaser;
	//sfxActivate = SoundPickUpWeapon;
};

ItemData ParticleBeamWeapon
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	heading = $InvHead[ihWea];
	imageType = ParticleBeamWeaponImage;
	showWeaponBar = true;
	showInventory = true;
	price = 2000;
};

ItemImageData ParticleBeamWeaponImage2
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60; //plasmatic
	maxEnergy = -6; //plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , -2.5 , 0 };
	mountOffset = { -0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
};

ItemData ParticleBeamWeapon2
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage2;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage3
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = -60;	//plasmatic
	maxEnergy = -6;	//plasmatic
	projectileType = PhrailterLaser; //plasmatic
	mountRotation = { 0 , 2.5 , 0 };
	mountOffset = { 0.1 , 0 , 0 };
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
};

ItemData ParticleBeamWeapon3
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage3;
	showWeaponBar = true; 
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage4
{
	shapeFile = "jetpack";
	mountPoint = 0;
	mountRotation = { -1.57, 0 , 3.14 };
	mountOffset = { 0 , 0.1 , 0 };
	weaponType = 0;
	minEnergy = 70;
	maxEnergy = 120;
	projectileType = ParticleBeam;
	accuFire = true;
	fireTime = 0.25;
	reloadTime = 0.38;
	sfxFire = SoundParticleBeamFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon4
{
	description = "Particle Beam";
	shapeFile = "jetpack";
	hudIcon = "reticle";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage4;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData ParticleBeamWeaponImage5
{
//	shapeFile = "grenammo";
//	mountPoint = 0;
	shapeFile = "jetpack";
	mountPoint = 0;
	mountRotation = { -1.57, 0 , 3.14 };
	mountOffset = { 0 , 0.1 , 0 };

	weaponType = 0; 
	minEnergy = 70;
	maxEnergy = 120;
	projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
	sfxFire = SoundParticleBeamFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon5
{
	description = "Particle Beam";
	className = "Weapon";
//	shapeFile = "grenammo";
	shapeFile = "jetpack";
	hudIcon = "reticle";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage5;
	price = 2500;
	showWeaponBar = true;
};

function ParticleBeamWeapon::onMount(%player, %item) 
{
	%clientId = Player::getclient(%player);
	if($debug)	
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ %clientId);
		
	Player::mountItem(%player,ParticleBeamWeapon2,4);
	Player::mountItem(%player,ParticleBeamWeapon3,6);
	
	if(%clientId.pbeam == 1)
		Player::mountItem(%player,ParticleBeamWeapon4,7);	
	else	
		Player::mountItem(%player,ParticleBeamWeapon5,7);

	if(%clientId.weaponHelp && %clientId.pbeam == 1)	
		Bottomprint(%clientId, "<jc>ParticleBeamWeapon: <f2>Turret Killer mode. Hold fire to charge.");
	if(%clientId.weaponHelp && (%clientId.pbeam == 0 || %clientId.pbeam == ""))	
		Bottomprint(%clientId, "<jc>ParticleBeamWeapon: <f2>Standard Beam. A standard double barreled Particle Beam.");
	
}

function ParticleBeamWeapon::onUnmount(%player)
{
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function ParticleBeamWeaponImage::onFire(%player) 
{	
	// max damage new 'charge up beam' is 12.5
	// max player damage = 4;
	//
	// max damage old single shot style is 3
	// player damage = 3, over 2 times highest maxdamage for player
	
	%client = Player::getclient(%player);	
	if($debug
		)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ %client);	
	
	if(%client.pbeam == 1)
	{	
		if(%player.pbeamcharging)
			return;
		%player.pbeamcharge=0;
		ParticleBeamWeapon::onCharge(%player);
	}
	else
	{
		if(!%client.pbeamReseting && GameBase::getEnergy(%Player) > 70)
		{
			Player::trigger(%player, 7, true);	
			schedule("Player::trigger(" @ %player @ ", 7, false);",0.1);	
			%client.pbeamReseting = true;
			schedule(%client@".pbeamReseting = false;",2.5);
	//new kickback- Plasmatic
	%trans = GameBase::getMuzzleTransform(%player);
	%smack = 8;
		%rot=GameBase::getRotation(%player);
		%len = 30;
		%tr= getWord(%trans,5);
		%tr = -%tr;
		%tr = %tr+0.15;
		%up = %tr;
		%out = %tr -1;
	%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
	Player::applyImpulse(%player,%vec);			
			
		}
		else 
		{
		}
		
	}
}

//plasmatic
function reload(%player) 
{
	%player.reloading = "";
	//echo("ready");
	playSound(MortarReload, GameBase::getPosition(%player));
}
function ResetPbeamLock(%ClientId)
{
	%clientId.locksound = "";
}

function ParticleBeamWeapon::onCharge(%player)
{

	if (%player.reloading == "True") return;//plasmatic
	%clientId = GameBase::getOwnerClient(%player);
	if(Player::isTriggered(%player,0))
	{
		%player.pbeamcharging = true;
		if (%player.pbeamcharge < 100)
			%player.pbeamcharge++;
		else
		 	%player.pbeamcharge = 100;
		schedule("ParticleBeamWeapon::onCharge(" @ %player @ ");",0.05);
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-2.5);

		if (%player.pbeamcharge > 60 && GameBase::getLOSInfo(%player,3000) && !%clientId.locksound) {
		%obj = getObjectType($los::object);
		//echo(%obj);
			if(%obj == "Player" || %obj == "Flier"){
				GameBase::playSound(%clientId,SoundMineActivate, 0);
				%clientId.locksound = true;
				schedule("ResetPbeamLock("@%ClientId@");",2);
				}
			else if(%obj != "SimTerrain" && %obj != "InteriorShape"){
				GameBase::playSound(%clientId,soundpackuse, 0);
				%ClientId.locksound = true;
				schedule("ResetPbeamLock("@%ClientId@");",2);
				}
		}
		bottomprint(%clientId, "<jc><f2>ParticleBeam charged to <f1>"@%player.pbeamcharge@"<f2>%", 0.5);
	}
	if(!Player::isTriggered(%player,0))
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		playSound(SoundFireLaser, GameBase::getPosition(%player));
		Player::trigger(%player, 4, true);
		Player::trigger(%player, 6, true);
		//Player::trigger(%player, 7, true);

//plamatic
	%smack = %player.pbeamcharge / 10;
	if (%smack < 4) playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
	if (%smack >= 4) playSound(SoundPlasmaTurretFire, GameBase::getPosition(%player));
	if (%smack >= 8) playSound(explo3, GameBase::getPosition(%player));


		if (GameBase::getLOSInfo(%player,3000)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if($debug)
				Client::sendMessage(%clientId,0,"target "@ $los::object @" object type "@%obj@" Damage value "@%value);

			if (%obj != "SimTerrain" || %obj != "InteriorShape") {

				if (%obj=="Player" || %obj =="Flier") %value = %player.pbeamcharge/25;
				else  %value = %player.pbeamcharge/8;
			GameBase::applyDamage($los::object, $SniperDamageType, %value, $los::position, "0 0 0","0 0 0", %clientId);
			if($debug)
				Client::sendMessage(%clientId,0,"target "@ $los::object @" object type "@%obj@" Damage value "@%value);
				
			}
		}

		%player.pbeamcharge=0;
		%player.pbeamcharging=false;
		Player::trigger(%player, 4, false);
		Player::trigger(%player, 6, false);
		//Player::trigger(%player, 7, false);
		%player.reloading = "True";//plasmatic
		schedule("reload(" @ %player @ ");",2.0); //PLASMATIC

	//new kickback- Plasmatic
		%rot=GameBase::getRotation(%player);
		%len = 30;
		%tr= getWord(%trans,5);
		%tr = -%tr;
		%tr = %tr+0.15;
		%up = %tr;
		%out = %tr -1;
	%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
	Player::applyImpulse(%player,%vec);

	}
}


