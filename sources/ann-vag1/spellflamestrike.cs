$InvList[FlameStrike] = 1;
$MobileInvList[FlameStrike] = 1;
$RemoteInvList[FlameStrike] = 1;

$AutoUse[FlameStrike] = True;
$WeaponAmmo[FlameStrike] = "";

addWeapon(FlameStrike);

ItemImageData FlameStrikeImage
{
	shapeFile = "laserhit";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	//projectileType = PlasIC;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 1.0;
	minEnergy = 50;
	maxEnergy = 60;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = bigExplosion2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameStrike
{
	description = "Spell: Flame Strike";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "plasma";
	heading = $InvHead[ihSpl];
	shadowDetailMask = 4;
	imageType = FlameStrikeImage;
	price = 1000;
	showWeaponBar = true;
};

function FlameStrike::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Flame Strike: <f2>Sends 3 racing bolts of flame to incinerate your target.");
}

function FlameStrikeImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("FlameStrikeSmall",%trans,%player,%vel-15);
      Projectile::spawnProjectile("FlameStrikeSmall",%trans,%player,%vel);
	Projectile::spawnProjectile("FlameStrikeSmall",%trans,%player,%vel+15);
	//Player::decItemCount(%player,$WeaponAmmo[FlameStrike],1);
}
