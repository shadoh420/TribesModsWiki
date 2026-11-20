$Nade::MaxShot[larmor] = 5;
$Nade::MaxShot[lfemale] = 5;
$Nade::MaxShot[marmor] = 10;
$Nade::MaxShot[mfemale] = 10;
$Nade::MaxShot[harmor] = 20;
$Nade::MaxShot[Earmor] = 15;

ItemData DGrenade {
	description = "Nade Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData GrenadeGunImage {
	shapeFile = "grenade";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0;
	fireTime = 0.02;
	ammoType = DGrenade;
	accuFire = true;
};

ItemData GrenadeGun {
	description = "Nader";
	className = "Weapon";
	shapeFile = "grenade";
    validateShape = false;
	hudIcon = "sniper";
    heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = GrenadeGunImage;
	price = 75;
	showWeaponBar = true;
};

function GrenadeGun::onUse(%player, %item){
	Weapon::onUse(%player,%item);
}

function GrenadeGunImage::onFire(%player, %slot){
	%ammo = Player::getItemCount(%player, $WeaponAmmo[GrenadeGun]);
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	
	if(%ammo <= 0){
		return;
	}else{
		if(%player.cooltime == 1){
			playVoice(%client, outway);
		}
		
		if(%player.cooltime == $Nade::MaxShot[%armor]){
			if(%player.countdown == ""){
				Schedule(%player @".cooltime = 0;", 4, %player);
				%player.countdown = true;
				Schedule(%player @".countdown = \"\";", 4.1, %player);
			}
			return;
		}
		else if($Nade::MaxShot[%armor] > %player.cooltime || %player.cooltime == ""){
			Player::decItemCount(%player, $WeaponAmmo[GrenadeGun], 1);
			%obj = newObject("", "Mine", "Handgrenade");
			addToSet("MissionCleanup", %obj);
			Player::setAnimation(%player, 21);
			Schedule("GameBase::throw("@ %obj @", "@ %player @", 10, false);", 0.8);
			GameBase::setTeam(%obj, GameBase::getTeam(%client));
			%player.cooltime += 1;		
		}
	}
}