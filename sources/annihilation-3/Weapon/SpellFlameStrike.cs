$InvList[FlameStrike] = 1;
$MobileInvList[FlameStrike] = 1;
$RemoteInvList[FlameStrike] = 1;

$AutoUse[FlameStrike] = True;
$WeaponAmmo[FlameStrike] = "";

// addWeapon(FlameStrike);

ItemImageData FlameStrikeImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	//projectileType = PlasIC;
	accuFire = true;
	reloadTime = 0.0;	//1.0; handling this with code to fix ghost pack armor change reload time// plasmatic
	fireTime = 0.0;		//1.0;
	minEnergy = 50;
	maxEnergy = 60;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 1.0, 0.25 }; 	//Driving out all the snakes for St Patricks day! lightColor = { 1, 0, 0 };
	//sfxFire = bigExplosion2;
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

function FlameStrike::MountExtras(%player,%weapon)
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Sends a racing bolt of flame to incinerate your target.");
}

function FlameStrikeImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

	if(!%player.Reloading)
	{	
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%player.Reloading = true;		//handling reload time through code now -plasmatic
		if(!$Annihilation::uber)
			%reload = 1.7;
		else 
			%reload = 1.7 / 5;		
		schedule(%player @ ".Reloading = false;" , %reload);
		GameBase::playSound(%player, bigExplosion2, 0);		
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
	}
}
