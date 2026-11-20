$InvList[MineAmmo] = 1;
$MobileInvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;
AddItem(MineAmmo);

$SellAmmo[MineAmmo] = 5;
$TeamItemMax[mineammo] = 35;

addAmmo("", MineAmmo, 1);

function oldMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this) 
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}



 //================================================

MineData Handgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
		elasticity = 0.15;
		friction = 1.0;
		
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;	//plasmatic
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}



 //================================================ MineAmmo
ItemImageData MineDeployerImage 
{
	shapeFile = "mine";
	mountPoint = 0;
	weaponType = 0;
//	ammoType = MineDeployerShells;
//	projectileType = MortarShell;
	mountOffset = { 0.1, 0.2 , -0.3 };	//right, forward, up
	mountRotation = {0, 0, 1.07};	//up, right, around player axis
	accuFire = false;
	reloadTime = 0.28;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
//	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
//	sfxReady = SoundUseAmmoStation;	//SoundElevatorBlocked;	//SoundMortarIdle;
};

ItemData MineDeployer 
{
	description = "Mine Deployer";
	shapeFile = "grenadeL";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MineDeployerImage;
	showWeaponBar = true;
	price = 85;
};

function MineDeployerImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	MineAmmo::onUse(%player,MineAmmo);
//	Player::setAnimation(%player, 21);	//added animation for 2.2 -plasmatic anim 21 is grenade throw, but long animation...
}
function MineDeployer::MountExtras(%player,%weapon)
{	
	// handled in ::onuse
}

ItemData MineAmmo 
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item) 
{
	if($matchStarted) 
	{
		
		//GameBase::playSound(%player, SoundThrowItem,0);
		if(Player::getMountedItem(%player,$WeaponSlot) != MineDeployer)
		{
			Player::unmountItem(%player,0);
			Player::mountItem(%player,MineDeployer,$WeaponSlot);
			if((Player::getclient(%player)).weaponHelp)
				bottomprint(Player::getclient(%player), "<jc>Claymore Mine: <f2>Better than electric socks!");
		}
		else
		{

				
			
			if(MineAmmo::deployShape(%player))
			{
				if(!$build)
					Player::decItemCount(%player,%item);				
				Player::unmountItem(%player,0);
				if(Player::getItemCount(%player,MineAmmo)>0)
					schedule("MineAmmo::ReloadDeployer("@%player@");",0.5);				
			}
			

	//		%obj = newObject("","Mine","antipersonelMine");
	//		GameBase::setTeam (%obj,GameBase::getTeam (%client));
	//		%obj.cloakable = true;	//for base cloaker
	//		addToSet("MissionCleanup", %obj);
	//		GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	//		%player.throwTime = getSimTime() + 0.5;

		}
	}
}

function MineAmmo::deployShape(%player)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5)) 
	{
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object

		// Try to stick it straight up or down, otherwise
		// just use the surface normal
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
		// meh, Mine class doesnt get along with rotations... -Plasmatic
	//	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	//	{
	//		%rot = "0 0 " @ %zRot;
	//	}
	//	else 
	//	{
	//		if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	//			%rot = "3.14159 0 " @ %zRot;
	//		
	//		else
	//			%rot = Vector::getRotation($los::normal);
	//	}
			GameBase::playSound(%player, SoundThrowItem,0);
			%obj = newObject("","Mine","antipersonelMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,3,false);
			
		//could use this if the rotations worked... =plasmatic	
	//		GameBase::setRotation(%obj ,%rot);
	//		GameBase::setPosition(%obj ,$los::position);
	//		Client::sendMessage(%client,0,"Mine deployed");
			playSound(SoundPickupBackpack,$los::position);
			echo("MSG: ",%client," deployed a Mine");
			return true;
	}
	else 
	{
		
		GameBase::playSound(%player, SoundPackFail,0);
		Client::sendMessage(%client,0,"Deploy position out of range");		
	}

	return false;
}

function MineAmmo::ReloadDeployer(%player)
{
	if(Player::getItemCount(%player,MineAmmo)>0 && Player::getMountedItem(%player,$WeaponSlot) == -1)
		Player::mountItem(%player,MineDeployer,$WeaponSlot);
}
 //================================================ 

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 100;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	
	//plasmatic
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;	
	
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	// friendly mines are more fun damnit -Plasmatic

			
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
	{
		if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		{
			//lets give team mates 1/2 a chance.. -plasmatic
		//	%dam = GameBase::getDamageLevel(%this)+(%data.maxDamage)/4;
		//	GameBase::playSound(%this, SoundMineActivate, 0);
		//	schedule("GameBase::setDamageLevel("@%this@", "@%dam@");",0.25);
			
		}		
		else
		{
			%dam = %data.maxDamage;
			GameBase::playSound(%this, SoundMineActivate, 0);
			schedule("GameBase::setDamageLevel("@%this@", "@%dam@");",0.125);
		}
	}
		
}

function AntipersonelMine::deployCheck(%this)
{
	echo("arming mine "@%this);
	if (GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
	 	echo("activate "@%this);
	 	//GameBase::playSound(%this, SoundMineActivate, 0);
	 	
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $NullDamageType)
		return;		
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	//T:V mod -Plasmatic
	if(%type ==$HealingDamage || %type == $RepairTurretDamage)
	{
	//	if(GameBase::getTeam(%this) ==  GameBase::getTeam(%object))
	//		RepairDamage(%this,%value);
		return;	
	}
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
 //================================================



MineData Shockgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = ShockGrenadeExp;	//Shockwave;	//plasmatic -2.2
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ShockDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Shockgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Shockgrenade::onRemove(%this)
{
	//do nothing yet..
}


 //================================================


