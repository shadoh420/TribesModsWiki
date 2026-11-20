//================================================================
//T2 Plasma Rifle
//================================================================
//================================================================
//================================================================

//================================================================
SoundData PlasmaExplosion
{
   wavFileName = "exp_Plasma.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNPlasmaReload
{
   wavFileName = "wpn_Plasma_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNPlasmaIdle
{
   wavFileName = "wpn_Plasma_idle.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNPlasma
{
   wavFileName = "wpn_Plasma.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNPlasmaAct
{
   wavFileName = "wpn_Plasma_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWhizPlasma
{
   wavFileName = "whiz_plasma.wav";
   profile = Profile3dMedium;
};

//================================================================
ExplosionData PlasmacanExp
{
   shapeName = "exp_vortex.dts";
   soundId   = PlasmaExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 0.75;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 0.25, 0.25, 1.0 };
   radFactors = { 1.0, 1.0, 0.0 };
};
//================================================================
RocketData Plasmaproj
{ 
   bulletShapeName = "proj_plasma.dts";
   explosionTag = PlasmacanExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 3.0;
   damageType = $PlasmaDamageType;
   explosionRadius = 20;
   kickBackStrength = 0;
   
   muzzleVelocity = 125.0;
   
   terminalVelocity = 300.0;
   acceleration = 3.0;
   
   totalTime = 20.0;
   liveTime = 21.0;

   trailType = 2; 
   trailString = "breath.dts";
   

   inheritedVelocityScale = 0.76;
   
   soundId = SoundWhizPlasma;
}; 
//================================================================

ItemImageData PlasmaGunImage
{
	shapeFile = "wpn_plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//ammoType = PlasmaAmmo;
	projectileType = Plasmaproj;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.15;
	minEnergy = 0.01;
	maxEnergy = 0.01;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0, 0, 1 };

	sfxFire = SoundWPNPlasma;
	sfxActivate = SoundWPNPlasmaAct;
	sfxReload = SoundWPNPlasmaReload;
	sfxReady = SoundWPNPlasmaIdle;
};
ItemData PlasmaGun
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "wpn_plasma";
	hudIcon = "Plasma";
   heading = "TWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 0;
	  showWeaponBar = false;
};
//================================================================
//echo("Plasma Loaded");

