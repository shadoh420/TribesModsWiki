$InvList[FlameStrike] = 1;
$MobileInvList[FlameStrike] = 1;
$RemoteInvList[FlameStrike] = 1;

$AutoUse[FlameStrike] = True;
$WeaponAmmo[FlameStrike] = "";

addWeapon(FlameStrike);

ItemImageData FlameStrikeImage
{
	shapeFile = "plasmabolt";
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
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "Flame Strike: <f2>Sends a racing bolt of flame to incinerate your target.");
}

function FlameStrikeImage::onFire(%player, %slot) 
{	
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if(floor(getRandom() * 30) == 0)
	{
		%client = Player::getClient(%player);
		Bottomprint(%client, "WARNING: FLAME STRIKE OUT OF CONTROL- CLEAR THE EXPLOSION AREA");
		Projectile::spawnProjectile("FlameStrikeBig",%trans,%player,%vel);
	}
	else
	{
		Projectile::spawnProjectile("FlameStrikeSmall",%trans,%player,%vel);
	}
	return;
}
