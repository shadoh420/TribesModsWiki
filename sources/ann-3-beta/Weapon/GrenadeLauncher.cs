// mini bomber
// grenade, tripple grenade, mine dropper, starburst mine

$InvList[GrenadeLauncher] = 1;
$MobileInvList[GrenadeLauncher] = 1;
$RemoteInvList[GrenadeLauncher] = 1;

$InvList[GrenadeAmmo] = 1;
$MobileInvList[GrenadeAmmo] = 1;
$RemoteInvList[GrenadeAmmo] = 1;

$AutoUse[GrenadeLauncher] = false;
$SellAmmo[GrenadeAmmo] = 5;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;

addWeapon(GrenadeLauncher);
addAmmo(GrenadeLauncher, GrenadeAmmo, 2);

ItemData GrenadeAmmo 
{	
	description = "Mini ammo"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = $InvHead[ihAmm]; 
	shadowDetailMask = 4; 
	price = 2;
}; 

MineData GrenadeAmmoBomb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Halo";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;	//mineExp;
	explosionRadius = 5.0;
	damageValue = 0.0;	//0.5
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 10.5;
};
ItemImageData GrenadeLauncherImage 
{	
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GrenadeAmmo;
	//projectileType = BomberWarhead;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;	//SoundTurretDeploy;	//SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher 
{	
	description = "Mini Bomber";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncher::MountExtras(%player,%weapon)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
	{
		if(%clientId.MiniMode == 1)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>SINGLE <f2>Grenade Projectile", 2);
		else if(%clientId.MiniMode == 0)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>TRIPLE <f2>Grenade Projectile", 2);
		else if(%clientId.MiniMode == 2)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>MINE dropper<f2> Projectile", 2);
		else if(%clientId.MiniMode == 3)
			bottomprint(%clientId, "<jc>Mini Bomber: <f2>Starburst MINE <f2>Projectile", 2);
	}	
}

function GrenadelauncherImage::onFire(%player, %slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	if(%clientId.MiniMode == 1)
	{
		if(%AmmoCount > 0)
		{
			Projectile::spawnProjectile("GrenadeLauncherGren",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Grenade Launcher out of ammo.");
			return false;
		}
	}
	else if(%clientId.MiniMode == 0)
	{
		if(%AmmoCount > 1)
		{
			Projectile::spawnProjectile("GrenadeLauncherGren1",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren2",%trans,%player,%vel,%player);
			Projectile::spawnProjectile("GrenadeLauncherGren3",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
			playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Triple Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}
	else if(%clientId.MiniMode == 2)
	{
		if(%AmmoCount > 4)
		{
		%player.team = GameBase::getTeam(%clientId); //hard coded to guard against players firing then dying before mines deploy -plasmatic
 		%newObj = Projectile::spawnProjectile("MineShell", %trans, %player, %vel);
		schedule("BeginMines(" @ %newObj @ ", " @ %player @ ", 10);", 0.3);
		playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],5);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Mine Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}
	
	else if(%clientId.MiniMode == 3)
	{
		if(%AmmoCount > 4)
		{
		%player.team = GameBase::getTeam(%clientId); //hard coded to guard against players firing then dying before mines deploy -plasmatic
 		%newObj = Projectile::spawnProjectile("MinerShell", %trans, %player, %vel);
		schedule("SplitMines(" @ %newObj @ ", " @ %player @ ");", 2.8);
		schedule("TossMines(" @ %newObj @ ", " @ %player @ ", 10,true);", 3.0);
		playSound(SoundFireGrenade, GameBase::getPosition(%clientId));
		Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],5);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough ammo to fire Mine Projectiles.");//~wdryfire1.wav");
			return false;
		}
	}	
}
function beginmines(%newobj,%this,%count)
{	
	if(%count){
	//	echo(GameBase::getPosition(%newObj));
		if (GameBase::getPosition(%newObj) != "0 0 0")
		{
			TossMines( %newObj, %this, 1, false);
			%count = %count -1;
			schedule("BeginMines(" @ %newObj @ ", " @ %this @ ", "@ %count @");", 0.3);
		}
	}
}

//--------------------------------------
function SplitMines(%newobj,%this)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	if(vector::normalize(%vel) != "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic
	{	
	// Pretty shell split
		%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
	 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %vel);
	}
	else
		echo("!! Butterfly Error, Splitmines. vel ="@%vel);		
}


function TossMines(%newobj,%this,%count,%delete)
{
	%Pos = GameBase::getPosition(%newobj); 
	%vel = Item::getVelocity(%newobj);
	%vel = Item::getVelocity(%newobj);
	if(vector::normalize(%vel) != "-NAN -NAN -NAN")	//Vengeance mod -Plasmatic
	{	
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);
	
	// Spawn butterflies
		if (GameBase::getPosition(%newObj))
		{
			for(%i=0; %i < %count; %i += 1) 
			{
				%xrnd = %xvel + floor(getRandom() * 60) -30;
				%yrnd = %yvel + floor(getRandom() * 60) -30;
				%zrnd = %zvel + floor(getRandom() * 20);
	
				%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;
	
				%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
		 		%obj = Projectile::spawnProjectile("MineFloaters", %trans, %this, %vel);
				Projectile::spawnProjectile(%obj);
				GameBase::setPosition(%obj, %pos);
				Item::setVelocity(%obj, %forceVel);
				%rnd = (floor(getRandom()*20)/80);
				schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
			}
		if (%delete) 
			deleteobject(%newObj);
		}
	}
	else
		echo("!! Butterfly Error, Tossmines. vel ="@%vel);	
}

function SetMines(%newobj,%this){

	if (GameBase::getPosition(%newObj)){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
   		%Mine = newObject("","Mine","MineShell1");
   		%mine.noOwner = "";
   		if(player::isdead(%this)) {
   			%team = %this.team;
   			%mine.noOwner = true;
   			}
  		else %team = GameBase::getTeam (%this);

 		addToSet("MissionCleanup", %Mine);
      		GameBase::throw(%Mine,%this,-1,true);
      		GameBase::setTeam (%Mine,%team);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);

	deleteobject(%newObj);
	}
}