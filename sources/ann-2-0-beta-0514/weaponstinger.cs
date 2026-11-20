$InvList[Stinger] = 1;
$MobileInvList[Stinger] = 1;
$RemoteInvList[Stinger] = 1;

$InvList[StingerAmmo] = 1;
$MobileInvList[StingerAmmo] = 1;
$RemoteInvList[StingerAmmo] = 1;

$AutoUse[Stinger] = false;
$WeaponAmmo[Stinger] = StingerAmmo;
$SellAmmo[StingerAmmo] = 5;

addweapon(Stinger);
addammo(Stinger, StingerAmmo, 2);

ItemData StingerAmmo
{
	description = "Stinger Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData StingerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType = 0; 
	reloadTime = 1.5;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	ammoType = StingerAmmo;
	accuFire = true;
	sfxFire	= SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData Stinger
{
	heading = $InvHead[ihWea];
	description = "Stinger Missle";
	classname = "Weapon";
	shapeFile = "GrenadeL";
	hudIcon	= "sensorjamerpack";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 350;
	showWeaponBar = true;
};

function Stinger::onMount(%player,%item)
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Stinger Missile: <f2>Give it a good lock, it'll give you a good hit.");
}

function StingerImage::onFire(%player,%slot)
{		
	if($debug)echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Stinger]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,0,"Stinger lock acquired "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,0,"Stinger lock detected - " @ %clientId @ "~wono.wav");
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
			}
			else
			{
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[Hellfire],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"Stinger out of ammo.~waccess_denied.wav");
}		
