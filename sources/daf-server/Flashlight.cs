//**************************************
//***ALL DIDDILY'S WORK
//**************************************

$ItemMax[marmor,	Flashlight] = 1;		     $ItemMax[mfemale,	Flashlight] = 1;
$ItemMax[sarmor,	Flashlight] = 1;		     $ItemMax[sfemale,	Flashlight] = 1;
$ItemMax[iarmor,	Flashlight] = 1;		     $ItemMax[ifemale,	Flashlight] = 1;
$ItemMax[garmor,	Flashlight] = 1;		     $ItemMax[gfemale,	Flashlight] = 1;
$ItemMax[earmor,	Flashlight] = 1;		     $ItemMax[efemale,	Flashlight] = 1;
$ItemMax[carmor,	Flashlight] = 1;		     $ItemMax[cfemale,	Flashlight] = 1;
$ItemMax[larmor,	Flashlight] = 1;		     $ItemMax[lfemale,	Flashlight] = 1;

//$Tool2Slot=4;

$ItemMax[aarmor,	Flashlight] = 1;		     $ItemMax[afemale,	Flashlight] = 1;

$ItemMax[marmor2,	Flashlight] = 1;		     $ItemMax[mfemale2,	Flashlight] = 1;
$ItemMax[sarmor2,	Flashlight] = 1;		     $ItemMax[sfemale2,	Flashlight] = 1;
$ItemMax[iarmor2,	Flashlight] = 1;		     $ItemMax[ifemale2,	Flashlight] = 1;
$ItemMax[garmor2,	Flashlight] = 1;		     $ItemMax[gfemale2,	Flashlight] = 1;
$ItemMax[earmor2,	Flashlight] = 1;		     $ItemMax[efemale2,	Flashlight] = 1;
$ItemMax[carmor2,	Flashlight] = 1;		     $ItemMax[cfemale2,	Flashlight] = 1;
$ItemMax[larmor2,	Flashlight] = 1;		     $ItemMax[lfemale2,	Flashlight] = 1;
$ItemMax[aarmor2,	Flashlight] = 1;		     $ItemMax[afemale2,	Flashlight] = 1;

$ItemMax[marmor3,	Flashlight] = 1;		     $ItemMax[mfemale3,	Flashlight] = 1;
$ItemMax[sarmor3,	Flashlight] = 1;		     $ItemMax[sfemale3,	Flashlight] = 1;
$ItemMax[iarmor3,	Flashlight] = 1;		     $ItemMax[ifemale3,	Flashlight] = 1;
$ItemMax[garmor3,	Flashlight] = 1;		     $ItemMax[gfemale3,	Flashlight] = 1;
$ItemMax[earmor3,	Flashlight] = 1;		     $ItemMax[efemale3,	Flashlight] = 1;
$ItemMax[carmor3,	Flashlight] = 1;		     $ItemMax[cfemale3,	Flashlight] = 1;
$ItemMax[larmor3,	Flashlight] = 1;		     $ItemMax[lfemale3,	Flashlight] = 1;
$ItemMax[aarmor3,	Flashlight] = 1;		     $ItemMax[afemale3,	Flashlight] = 1;

ItemImageData FlashlightImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
        
        mountRotation = { 0, -1.57, 0 };
	weaponType = 1; // Sustained
	
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.09;
	reloadTime = 0.0;
	lightType   = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime   = 0.01;
	lightColor  = { 1, 1, 1 };

	//sfxFire     = SoundFireTargetingLaser;
	sfxFire     = SoundPickupWeapon;
	sfxActivate = SoundPickUpWeapon;
};

ItemData flashlight
{
	description   = "Flashlight";
	className     = "tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FlashlightImage;
	price         = 50;
	showWeaponBar = false;
};



function FlashlightImage::onfire(%player, %slot)
{
if(GameBase::getLOSInfo(%player, 100))
{
	
	%distance=vector::getdistance(gamebase::getposition(%player),$los::position);
	   %size=%distance/4+2;
	   %br=10/%distance;
	   if (%br>1)
		%br=1;
	   if (%br<0.001)
		%br=0;
		//%light = newObject("pointlight","SimLight", Point, Size, Red, Green, Blue, Xpos, Ypos, Zpos);
           %light = newObject("pointlight","SimLight", Point, %size, %br, %br, %br, getword($los::position,0), getword($los::position,1), getword($los::position,2));
 	   addToSet("MissionCleanup", %light);
	   schedule("deleteObject("@%light@");",0.2, %light);
	   return;
}
}

function doflash(%client)
{
	if(!%client.flashon)
    	{
    		bottomprint(Player::getClient(%client), "<f0><jc>Flashlight on.", 1);
    		player::trigger(%client, 3, true);
    		%client.flashon=1;
    	}else{
   	 	bottomprint(Player::getClient(%client), "<f0><jc>Flashlight off.", 1);
    		player::trigger(%client, 3, false);
    		%client.flashon=0;
    	}
}


$InvList[Flashlight] = 1;
$RemoteInvList[Flashlight] = 1;

function toolcheck(%player,%item,%delta)
{	

	%targ=player::getitemcount(%player, "TargetingLaser");
	%flas=player::getitemcount(%player, "flashlight");
	if(%targ>=1||%flas>=1)
	  return 0;
	Player::incItemCount(%player,%item);
	Player::useItem(%player,%item);
	Client::sendMessage(Player::getClient(%player),0,"You received a " @ %item.description);
	return 1;
}

function checkwhichtool(%player)
{
   %targ=player::getitemcount(%player, "TargetingLaser");
   %flas=player::getitemcount(%player, "flashlight");
   if(%targ==1)
   	Player::useItem(%player,"TargetingLaser");
   if(%flas==1)
   {
	if(player::Getmounteditem(%player,$WeaponSlot) == SOCOM && player::Getmounteditem(%player,3) == flashlight)
	{
   	 	bottomprint(Player::getClient(%player), "<f0><jc>Flashlight off.", 1);
    		player::trigger(%client, 3, false);
    		%player.flashon=0;
		player::unmountitem(%player,3);
	} else if(player::Getmounteditem(%player,$WeaponSlot) == SOCOM)
	{
		player::mountitem(%player,flashlight,3);
	} else
	{
		Player::useItem(%player,"flashlight");
	}
   }
}



function toolbuycheck(%player,%item)
{
if(Player::getItemCount(Player::getClient(%player),flashlight))
	teamEnergyBuySell(%player,flashlight.price );
if(Player::getItemCount(Player::getClient(%player),TargetingLaser))
	teamEnergyBuySell(%player,TargetingLaser.price );


Player::setItemCount(Player::getClient(%player),flashlight, 0);
Player::setItemCount(Player::getClient(%player),TargetingLaser, 0);
teamEnergyBuySell(%player, %item.price * -1);
Player::incItemCount(Player::getClient(%player),%item);
}

function SOCOM::onUnmount(%player,%item)
{
        player::trigger(%player, 3, false);
	Player::unmountItem(%player,3);
        %player.flashon=0;
}

function toolcheck(%player,%item,%delta)
{	

	%targ=player::getitemcount(%player, "TargetingLaser");
	%flas=player::getitemcount(%player, "flashlight");
	if(%targ>=1||%flas>=1)
	  return 0;
	Player::incItemCount(%player,%item);
	Player::useItem(%player,%item);
	Client::sendMessage(Player::getClient(%player),0,"You received a " @ %item.description);
	return 1;
}

function toolbuycheck(%player,%item)
{
if(Player::getItemCount(Player::getClient(%player),flashlight))
	teamEnergyBuySell(%player,flashlight.price );
if(Player::getItemCount(Player::getClient(%player),TargetingLaser))
	teamEnergyBuySell(%player,TargetingLaser.price );


Player::setItemCount(Player::getClient(%player),flashlight, 0);
Player::setItemCount(Player::getClient(%player),TargetingLaser, 0);
teamEnergyBuySell(%player, %item.price * -1);
Player::incItemCount(Player::getClient(%player),%item);
}