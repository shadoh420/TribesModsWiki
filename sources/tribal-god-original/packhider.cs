//------------------------------------|
// Author: VRWarper
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin8420@adelphia.net
// Aim: Dustin8420
//------------------------------------|
//
// This was modified alot, check out Warper's Mod To Tell The Diference.
// In His Mod It's Named Terrain Shifter.

StaticShapeData HiderStand
{
	description = "Hider Stand";
	shapeFile = "flagstand";
	visibleToSensor = false;
};

function HiderStand::onCollision(%this, %obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor  = Player::getArmor(%clientId);
	%data   = GameBase::getDataName(%obj); 
	%thisTeam = GameBase::getTeam(%this);
	%objTeam = GameBase::getTeam(%player);
	
	if(%objTeam == %thisTeam)
	{ return; }
	if(%data.shapefile == "rocket")
	{ GameBase::setDamageLevel(%obj, 10); return; }
	if(%this.activated == true || Player::isDead(%obj))
	{ return; }
	else
	{ BurnUp(%clientId); }
	return;
}
function HiderStand::onDamage(){}

ItemImageData HiderPackImage
{
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData HiderPack
{
	description = "Hider_v1.2";
	shapeFile = "shield";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = HiderPackImage;
	price = 175;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = false;
	validateMaterials = false;
};

function HiderPackImage::onActivate(%player, %imageSlot)
{
	%clientId = Player::getClient(%player);
	%clientId.guiLock = true;
	%player.hiderOn = true;
	
	// Admins don't get booted outa the hider :)
	if(!%clientId.isSuperAdmin)
	{ Schedule("Player::Trigger("@ %player @", 1, false);", 15); }
	
	if(Player::getMountedItem(%player, $FlagSlot) != -1 && !%clientId.isSuperAdmin)
	{ Player::dropItem(%player, $FlagSlot); Client::sendMessage(%client, 1, "You materialized without the flag!~werror_message.wav"); }
	
	// Establish Position reference variables.
	$HiderPack::OldPos[%player] = GameBase::getPosition(%player);
	%xPos = getword($HiderPack::OldPos[%player], 0);
	%yPos = getword($HiderPack::OldPos[%player], 1);
	%zPos = getWord($HiderPack::OldPos[%player], 2);
	%Pos = %xPos @" "@ %yPos @" -100000";
	GameBase::setPosition(%player, %Pos);

	%player.Sub = newObject("Player Substitution", "StaticShape", ElectricalBeamBig, true);
	GameBase::setPosition(%player.Sub, $HiderPack::OldPos[%player]);

	%player.Sub1 = newObject("Player Substitution1", "StaticShape", HiderStand, false);
	GameBase::setPosition(%player.Sub1, $HiderPack::OldPos[%player]);
	
	%player.Sub2 = newObject("Player Substitution2", "StaticShape", FlagStand, false);
	%nzPos = %zPos + 5;
	%nPos = %xPos @" "@ %yPos @" "@ %nzPos;
	%rot = "3.14159 0 0";
	GameBase::setPosition(%player.Sub2, %nPos);
	GameBase::setRotation(%player.Sub2, %rot);
	
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %player.Sub, 5, 5, 5);
	
	Client::sendMessage(%clientId, 0, "Activating Terrain Shifter");
	BottomPrint(%clientId, "<jc><f1>Press the <f2>Jump Key (Space Bar) <f1> when you want to return!", 10);
}

function HiderPackImage::onDeactivate(%player, %imageSlot)
{
	%player.hiderOn = false;
	%clientId = Player::getClient(%player);
	%clientId.guiLock = false;
	Item::setVelocity(%player, 0);
	GameBase::setPosition(%player, $HiderPack::OldPos[%player]);
	Item::setVelocity(%player, 0);
	Client::setControlObject(%clientId, %player);
	deleteObject(%player.Sub);
	deleteObject(%player.Sub1);
	deleteObject(%player.Sub2);
	%player.Sub2 = "";
	%player.Sub1 = "";
	%player.Sub = "";
	Client::sendMessage(%clientId, 0, "Deactivating Terrain Shifter");
}