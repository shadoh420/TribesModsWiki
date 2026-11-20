$InvList[Vulcan] = 1;			//1
$MobileInvList[Vulcan] = 1;		//1
$RemoteInvList[Vulcan] = 1;		//1

$InvList[VulcanAmmo] = 1;
$MobileInvList[VulcanAmmo] = 1;
$RemoteInvList[VulcanAmmo] = 1;

$AutoUse[Vulcan] = false;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$SellAmmo[VulcanAmmo] = 100;

addWeapon(Vulcan);
addAmmo(Vulcan, VulcanAmmo, 50);

ItemData VulcanAmmo 
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 1;
};
//=====================
// Added image by: Arma
//=====================
ItemImageData Vulcan2Image
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Vulcan2
{
	description = "Vulcan2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Vulcan2Image;
	showWeaponBar = false;
};
//===========================
ItemImageData VulcanImage 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.75;
	spinDownTime = 3;
	fireTime = 0.045;
	ammoType = VulcanAmmo;
	//projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Vulcan 
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

function Vulcan2::onMount(%player,%item) 
{
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "Vulcan: <f2>Fires high speed explosive bullets to mow down your enemies.");
}

// Weapon Options - AUTO
function VulcanImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Vulcan]);
	%clientId = Player::getClient(%player);
	 if(%AmmoCount > 0)
	 {
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);

		if (!%clientId.Vulcan || %clientId.Vulcan == 0)
		{
			Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
			Player::decItemCount(%player,VulcanAmmo);
		}
		else if (%clientId.Vulcan == 1)
		{
			Projectile::spawnProjectile("VulcanBullet",%trans,%player,%vel);
			Player::decItemCount(%player,VulcanAmmo);
			Player::decItemCount(%player,VulcanAmmo);
		}

	}	
}

function Vulcan::onMount(%player,%item) //onUse
{	
      Player::mountItem(%player,Vulcan2,7); 

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%client = GameBase::getOwnerClient(%player);
	if(%clientId.weaponHelp)
	{
		if (!%client.Vulcan || %client.Vulcan == 0)
		{
			bottomprint(%client, "<jc>Vulcan:<f2> Standard Chaingun Rounds", 2);
		}
		if (%client.Vulcan == 1)
		{
			bottomprint(%client, "<jc>Vulcan:<f2> Fiery Vulcan Rounds", 2);
		}
	}
}
// END Weapon Options
function Vulcan::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}