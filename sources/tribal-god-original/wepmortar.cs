$AmmoPackMax[MortarAmmo] = 75;

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload; 
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = MortarImage;
	showWeaponBar = true;
    validateShape = false;
    price = 375;
};

function MortarImage::onFire(%player, %slot)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	if(!%Ammo){ return; }
	
	%clientId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%vel    = Item::getVelocity(%player);
	%trans  = GameBase::getMuzzleTransform(%player);
	%armor  = Player::getArmor(%player);
	
	//>> Nuke Mortar Setting.
	if(%clientId.MortarPref == "Nuke")
	{
		if(%clientId.coolingGun)
		{ Player::trigger(%player, 0, false); Client::sendMessage(%clientId, 1, "Gathering Plutonium.."); }
		else
		{
			CoolGun(%clientId, 5);
			%fired = Projectile::spawnProjectile("MortarShellNuke", %trans, %player, %vel);
			%fired.deployer = %clientId;
			Schedule("Client::sendMessage("@ %clientId @", 1, \"Plutonium Is Ready.~wbuysellsound.WAV\");", 5);
			Player::trigger(%player, 0, false);
		}
	}//<< Nuke Mortar Setting.
	
	//>> Multiple Mortar Setting.
	else if (%clientId.MortarPref == "Multi")
	{
		if(!%clientId.coolingGun)
		{
			CoolGun(%clientId, 2);
			%player.team = GameBase::getTeam(%clientId);
			Schedule("Client::sendMessage("@ %clientId @", 1, \"Bunker Buster Is Ready.~wbuysellsound.WAV\");", 2); 
			%newObj = Projectile::spawnProjectile("MinerShell", %trans, %player, %vel);
			Schedule("SplitExplosion("@ %newObj @", "@ %player @");", 2.8);
			Schedule("TG::TossMines("@ %newObj @", "@ %player @", 5, true, \"MortarBunkerShell\");", 3.0);
		}
		else
		{
			Player::trigger(%player,0,false);
			if(!%clientId.justheard)
			{
				Client::sendMessage(%clientId, 1, "Re-Packing Bunker Buster Mortar.~wSensor_Deploy.wav");
				%clientId.justHeard = true;
				Schedule(%clientId @".justheard = false;", 5);
				return;
			}
		}
	}//<< Multiple Mortar Setting.
	
	//>> FlameStrike Mortar Setting.
	else if (%clientId.MortarPref == "Flame")
	{
		// check target distance
		if(!GameBase::getLOSInfo(%player, 25))
		{
			%fired = Projectile::spawnProjectile("MortarFlameShell", %trans, %player, %vel);
			%fired.deployer = %client;
		}
		else
		{
			Player::trigger(%player, 0, false);
			CenterPrint(%clientId, "<jc><f0>That Aim Needs Some Work Buddy, Thats A Sure Fire Way To Kill YourSelf...", 5);
			Client::sendMessage(%clientId, 0, "~wmale1.wwshoot1.wav");
		}
	}//<< FlameStrike Mortar Setting.
	
	//>> Default Mortar Setting, or no pref selected.
	else if (%clientId.MortarPref == "Default" || %clientId.MortarPref != "Default" 
	&& %clientId.MortarPref != "Flame" && %clientId.MortarPref != "Multi" 
	&& %clientId.MortarPref != "Nuke")
	{
		%fired = Projectile::spawnProjectile("MortarShell", %trans, %player, %vel);
		%fired.deployer = %client;
	}//<< Default Mortar Setting, or no pref selected.
	
	if($TG::InfiniteAmmo:Mortar != true)
	{ Player::decItemCount(%player, $WeaponAmmo[Mortar], 1); }
}