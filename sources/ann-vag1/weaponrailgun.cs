$InvList[Railgun] = 1;
$MobileInvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$InvList[RailAmmo] = 1;
$MobileInvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$AutoUse[Railgun] = false;
$SellAmmo[RailAmmo] = 10;
$WeaponAmmo[Railgun] = RailAmmo;

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

ItemData RailAmmo 
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 75;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper"; //"sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.1, -0.08 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
      minEnergy = 30;
	maxEnergy = 60;
	weaponType = 0; // Single Shot
	ammoType = RailAmmo;
    //projectileType = "";
	accuFire = true;
	reloadTime = 0.05;//++++
	fireTime = 1.75;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 2;
	lightColor = {0.05, 0.25, 0.45}; 
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundAmmoStationPower;
	sfxReady = SoundGeneratorPower;
};

ItemData Railgun 
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData Railgun2Image 
{
	shapeFile = "shotgun";
	mountPoint = 0;	
	mountOffset = { -0.02, -0.04, 0.01 }; 
	mountRotation = { 0, 1.57, 0 }; 
	weaponType = 0;
	//projectileType = "";
	accuFire = true;
};

ItemData Railgun2
{
	description = "Railgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Railgun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};

function RailgunImage::onFire(%player,%slot)
 {

if($debug)
	echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

   %enVal  = 25.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Railgun]);
   if (%energy > 20.0)
{
		 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
		 Player::decItemCount(%player,$WeaponAmmo[Railgun],1);
		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("RailRound",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundElevatorStop,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"Your energy level is to low to fire a rail shot.");
	}
 }

function Railgun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,Railgun2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Rail Gun: <f2>The ultimate sniper weapon.");
}

function Railgun::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}
