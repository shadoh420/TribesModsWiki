// Flare Gun by [BIO]iCE.! and [BIO]EvilBastard (uses a Tool Slot)
$WeaponAmmo[FlareGun] = FlareAmmo;

$SellAmmo[FlareAmmo] = 5;

addPluginWeapon(Mortar, FlareGun);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemData FlareAmmo
{
	description = "Flares";
	className = "Ammo";
	shapeFile = "rocket";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData FlareGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0; // Sustained
	// projectileType = Flare;
	AmmoType = FlareAmmo;
	accuFire = true;
	reloadTime = 1.5;
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 1, 1, 1 };
	sfxFire     = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlareGun
{
	description   = "Flare Gun";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "plasma";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FlareGunImage;
	price         = 300;
	showWeaponBar = true;
};

function FlareGunImage::onFire(%player, $WeaponSlot)
{ 
  %client = Player::getClient(%player);
  %name = client::getname(%client);
  %shooterteam = Client::getTeam(%client);
  %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[FlareGun]);
  if(%AmmoCount)
  {
  	%mt = GameBase::GetMuzzleTransform(%player);
    %vel = Item::getVelocity(%player);
    Projectile::Spawnprojectile("Flare",%mt,%player,%vel);
	%numPlayers = getNumClients();
	for(%loop = 0; %loop < %numPlayers; %loop++) 
	{ 
		%pl = getClientByIndex(%loop);
		%plteam = Client::Getteam(%pl);
		if(%plteam == %shooterteam) 
			client::sendmessage(%pl,3,%name@" has fired a flare.  Heads up!");
	}
	Player::decItemCount(%player,$WeaponAmmo[FlareGun],1);
  }
}

function FlareGun::OnMount(%player,%imageslot)
{
  client::SendMessage(Player::GetClient(%player),0,"Flare Gun armed.");
}