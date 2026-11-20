//================================================================
// Lasher
//================================================================

//================================================================
SoundData SoundWPNLasher
{
   wavFileName = "wpn_Lasher.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNLasherHit
{
   wavFileName = "exp_lasher.wav";
   profile = Profile3dNear;
};
SoundData SoundLasherproj
{
   wavFileName = "whiz_lasher.wav";
   profile = Profile3dNear;
};
SoundData SoundWhizLasher
{
   wavFileName = "whiz_lasher.wav";
   profile = Profile3dNear;
};
//================================================================

//================================================================

LightningData BeamofPainproj
{
   bitmapName       = "lasherpulse.bmp";

   damageType       = $BeamofPainDamageType;
   boltLength       = 70.0;
   coneAngle        = 25.0;
   damagePerSec      = 0.45;
   energyDrainPerSec = 0.05;
   segmentDivisions = 1;
   numSegments      = 3;
   beamWidth        = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundWPNLasherHit;
};

function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%friendFire = $Server::TeamDamageScale;
	%playerId = %shooterId;
	//if (%playerId.GravBolt == "0")
	//{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -80;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $BeamOfPainDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);

}
//================================================================
ItemImageData BeamOfPainImage
{
	shapeFile = "wpn_lasher";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = BeamOfPainProj;
	minEnergy = 0.01;
	maxEnergy = 0.01;
	reloadTime = 0.1;
                        
   //lightType = 3;  // Weapon Fire
   //lightRadius = 2;
   //lightTime = 1;
   //lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundWPNLasher;
};

ItemData BeamOfPain
{
   description = "Lasher";
	shapeFile = "wpn_lasher";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "TWeapons";
   shadowDetailMask = 4;
   imageType = BeamOfPainImage;
	  showWeaponBar = false;
   price = 125;
   validateShape = true;
};

//----------------------------------






//--------------------------------------

//================================================================
echo("Lasher Loaded");
