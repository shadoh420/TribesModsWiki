$InvList[HawkEyePack] = 1;
$MobileInvList[HawkEyePack] = 1;
$RemoteInvList[HawkEyePack] = 1;
AddItem(HawkEyePack);

//----------------------------------------------------------------------------
// HawkEye pack a snipers only friend is a friend that can help him kill...
//----------------------------------------------------------------------------

LightningData HawkEyeLaserBeam
{
  bitmapName = "smoke08.bmp";
  boltLength = 2000.0;
  coneAngle = 0.0;
  damagePerSec = 0.0;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.05;
  updateTime = 99999;
  skipPercent = 99999;
  displaceBias = 0;
  lightRange = 0;
  lightColor = { 0, 0, 0 };
  //soundId = SoundLaserFire;
};

function HawkEyeLaserBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
	if (%shooterId.LaunchAt != %target)
	{
		%shooterID.LaunchAt=%target;
		//Get preferred name
		if (getObjectType(%target) == "Player") 
		%n = Client::getName(Player::getClient(%target));
		else %n = GameBase::getMapName(%target);
		//If better names are blank, grab the data name
		if (%n == "") %n = GameBase::getDataName(%target);
		Client::sendMessage(%shooterId, 0, "Hawk Eye Sight Set On: " @ %n);
	}
}



ItemImageData HawkEyePackImage 
{
  shapeFile = "grenade";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = -1;
  maxEnergy = -5;   // Energy used/sec for sustained weapons
  projectileType = HawkEyeLaserBeam;
  minEnergy = 0.00000001;
  maxEnergy = 0.0000001;
  sfxFire = SoundJammerOn;
  //reloadTime = 0.2;
};

ItemData HawkEyePack
{
	description = "HawkEye Pack";
	shapeFile = "sniper";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = HawkEyePackImage;
	price = 1150;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HawkEyePackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Hawk Eye Sight On");
}

function HawkEyePackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Hawk Eye Sight Off");
	Player::trigger(%player,$BackpackSlot,false);
}