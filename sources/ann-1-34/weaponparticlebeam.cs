$InvList[ParticleBeamWeapon] = 1;
$MobileInvList[ParticleBeamWeapon] = 1;
$RemoteInvList[ParticleBeamWeapon] = 1;

$AutoUse[ParticleBeamWeapon] = True;

addweapon(ParticleBeamWeapon);

ItemImageData ParticleBeamWeaponImage 
{
	shapeFile = "grenammo";
	mountPoint = 0;
	weaponType = 0; 
	minEnergy = 70;
	maxEnergy = 120;
        projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.5;
	sfxFire = SoundParticleBeamFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundParticleBeamRecharge;
};

ItemData ParticleBeamWeapon
{
	description = "Particle Beam";
	className = "Weapon";
	shapeFile = "grenammo";
	hudIcon = "reticle";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ParticleBeamWeaponImage;
	price = 2500;
	showWeaponBar = true;
};

function ParticleBeamWeapon::onMount(%player,%item)
{
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "Particle Beam: <f2>An super accelerated particle weapon.");
}