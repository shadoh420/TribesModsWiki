//--------------------------------------------------------| - Begin Laser Data
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 25;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.05;
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|

LaserData TaserRfLaser
{
   laserBitmapName   = "blite01.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 5.25;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.99;
   detachFromShooter = false;
   hitSoundId        = SoundBeaconUse;
};
//--------------------------------------------------------|

LaserData TaserTrtBLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.05;
        baseDamageType = $LaserDamageType;
        beamTime = 2;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};
//--------------------------------------------------------|

LaserData TaserTrtCLaser 
{ 
        laserBitmapName = "paintPulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.0001;
        baseDamageType = $LaserDamageType;
        beamTime = 0.3;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};
//--------------------------------------------------------|

LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};
//--------------------------------------------------------|

LaserData DissectionLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.025;
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.25;
   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 1.0 };
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|

LaserData ObeliskBeam
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.25;
   damageType        = $ObeliskDamageType;
   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|

LaserData railLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 1.0;
   baseDamageType    = $SniperDamageType;
   beamTime          = 1.5;
   lightRange        = 5.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|

LaserData SeekerLaser
{
   bulletShapeName    = "mortar.dts"; 
   hitName           = "laserhit.dts";
   damageConversion  = 0.25; 
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.6;
   lightRange        = 5.0;
   lightColor        = { 0.25, 0.25, 0.85 };
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "laserhit.dts";
   damageConversion  = 0.001; 
   baseDamageType    = $LaserDamageType;
   beamTime          = 0.8;
   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};
//--------------------------------------------------------|


//--------------------------------------------------------|
LightningData lightningCharge
{
   bitmapName        = "laserpulse.bmp";
   damageType        = $ElectricityDamageType;
   boltLength        = 100.0;
   coneAngle         = 3.0;
   damagePerSec      = 2;
   energyDrainPerSec = 500.0;
   segmentDivisions  = 6;
   numSegments       = 2;
   beamWidth         = 0.125;
   updateTime        = 120;
   skipPercent       = 0.5;
   displaceBias      = 0.25;
   lightRange        = 3.0;
   lightColor        = { 0.25, 0.25, 0.85 };
   soundId           = SoundELFFire;
};
//--------------------------------------------------------|

LightningData BeamOfPainProj
{
   bitmapName       = "trailadd2.bmp";

   damageType       = $BeamOfPainDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 1.25;
   energyDrainPerSec = 25;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 0.5;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;
   soundId = SoundELFFire;
};
//--------------------------------------------------------|

LightningData MiniSmokeTurretproj // Beam Of Pain Turret
{
   bitmapName       = "trailadd2.bmp";

   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 3.0;
   damagePerSec      = 0.025;
   energyDrainPerSec = 2;
   segmentDivisions = 4;
   numSegments      = 1;
   beamWidth        = 2;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0;
   soundId = SoundELFFire;
};
//--------------------------------------------------------|

LightningData MiniELFTurretproj
{
   bitmapName       = "laserpulse.bmp";
   damageType       = $MiniELFDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 1000;
   segmentDivisions = 6;
   numSegments      = 2;
   beamWidth        = 0.25;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.25;
   soundId = SoundELFFire;
};
//--------------------------------------------------------|

LightningData turretCharge
{
   bitmapName       = "laserpulse.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 100.0;
   coneAngle        = 35.0;
   damagePerSec      = 0;
   energyDrainPerSec = 500;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

function BeamOfPainproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%friendFire = $Server::TeamDamageScale;
	%playerId = %shooterId;
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
	if (%energy < 0)
	{ %energy = 0; }
	GameBase::setEnergy(%target, %energy);
}
//--------------------------------------------------------|

function MiniELFturretproj::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%damVal = %timeSlice * %damPerSec;
	%enVal  = %timeSlice * %enDrainPerSec;
	GameBase::applyDamage(%target, $MiniELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if(%energy < 0)
	{ %energy = 0; }
	GameBase::setEnergy(%target, %energy);
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;
   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}
//--------------------------------------------------------|


//--------------------------------------------------------|
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = 0;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};
//--------------------------------------------------------|