//frag grens, terran, L
$InvList[Virus] = 1;
$InvList[VirusAmmo] = 1;
$RemoteInvList[Virus] = 1;
$RemoteInvList[VirusAmmo] = 1;
$AutoUse[Virus] = False;
$SellAmmo[VirusAmmo] = 50;
$WeaponAmmo[Virus] = VirusAmmo;
$VehicleInvList[Virus] = 1;
$VehicleInvList[VirusAmmo] = 1;

addWeapon(Virus);
addAmmo(Virus, VirusAmmo, 20);

BulletData VirusShell 
{
  bulletShapeName = "mortar.dts";
  explosionTag  = grenadeExp;
  damageClass = 1;
  damageValue = 0.135;
  elasticity = 0.15;
  damageType = $ReaperDamageType;
  aimDeflection = 0.018;
  explosionRadius = 5.0;
  muzzleVelocity = 65.0;
//  terminalVelocity = 65.0;
  totalTime = 0.8;
  liveTime = 1.2;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.5;
  isVisible = True;
//   trailType   = 2;                // smoke trail
//   trailString = "lflame.dts";
//   smokeDist   = 1.0;
};

ItemData VirusAmmo
{
	description = "Frag Grens";
	className = "Ammo";
   heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
	showInventory = False;
};

ItemImageData VirusImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = VirusAmmo;
	projectileType = VirusShell;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Virus
{
	description = "Frag Grenades";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VirusImage;
	price = 475;
	showWeaponBar = true;
};

function Virus::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "The Fragmentation Grenades: <f2>hurls deadly canisters that explode on impact");
}
