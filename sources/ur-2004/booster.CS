//================================================================
// Booster Pack
//================================================================
$ItemMax[marmor, Booster1Pack] = 1;
$ItemMax[marmor, Booster2Pack] = 1;
$ItemMax[mfemale, Booster1Pack] = 1;
$ItemMax[mfemale, Booster2Pack] = 1;

$DamageScale[marmor, $BoostDamageType] = 0.33;
$DamageScale[mfemale, $BoostDamageType] = 0.33;
//================================================================

SoundData boostExplosion
{
   wavFileName = "bxplo4.wav";
   profile = Profile3dMedium;
};

SoundData brakeExplosion
{
   wavFileName = "mine_exp.wav";
   profile = Profile3dMedium;
};

///////////////////////////////////////////////////////
ExplosionData BrakeExp
{
   shapeName = "shield_large.dts";
   soundId   = BrakeExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};
///////////////////////////////////////////////////////////
ExplosionData boostExp
{
   shapeName = "shield_large.dts";
   soundId   = boostExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 2.0;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

/////////////////////////////////////////////////////////////////
MineData Boost
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = BoostExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $BoostDamageType;
	kickBackStrength = 0; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};


MineData Brake
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = BrakeExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $BoostDamageType;
	kickBackStrength = 0; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function VelocityCheck(%player,%var)
{
	%armor = Player::getArmor(%player);
	%this = $SpeedMax[%armor];
	if (%var < 0)
	{
	%var *= -1;
	}
	else
	{
	%var *= 1;
	}
	%num = (%this - %var);
	$VelRatio = %num/%this;
	return $VelRatio;
}

function Beacon::onUse(%player,%item)
{
if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","Boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.2;
				%dir = Item::getVelocity(%player);
				%armor = Player::getArmor(%player);
				%X = getWord(%dir,0);
				VelocityCheck(%player,%X);
				%Y = getWord(%dir,1);
				%Z = getWord(%dir,2);
				%this = ($BoostSpeed[%armor]*$VelRatio);
				%Xset = %X * %this;
				%Yset = %Y * %this;
				%Zset = %Z * %this;
				%force = "" @ %Xset @ " " @ %Yset @ " " @ %Zset @ "";
				Item::setVelocity(%player, %force); 
                        Client::sendMessage(Player::getClient(%player),0, "You used a Speed Booster.");
                }
        }
}



function Grenade::onUse(%player,%item)
{
%clientId = Player::getClient(%player); 
if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","Brake");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.2;
				%dir = Item::getVelocity(%player);
				%armor = Player::getArmor(%player);
				%X = getWord(%dir,0);
				VelocityCheck(%player,%X);
				%Y = getWord(%dir,1);
				%Z = getWord(%dir,2);
				%this = (%clientId.breakspeed*$VelRatio);
				%Xset = %X * %this;
				%Yset = %Y * %this;
				%Zset = %Z * %this;
				%force = "" @ %Xset @ " " @ %Yset @ " " @ %Zset @ "";
				Item::setVelocity(%player, %force); 
                        Client::sendMessage(Player::getClient(%player),0, "You used a Brake.");
                }
        }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//================================================================
ItemImageData Booster1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 2; 
	mountOffset = { 0.05, -0.1, 0.2 }; 
	mountRotation = { -1.57, 1.55, 0 }; 
	weaponType = 0; 
	projectileType = CHANGEMEPLZ;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster1Pack 
{ 
	description = "Booster Pack";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Booster2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 2; 
	mountOffset = { -0.05, -0.1, 0.2 };
	mountRotation = { -1.57, -1.55, 0 }; 
	weaponType = 0;
	projectileType = CHANGEMEPLZ; 
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.0; 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster2Pack 
{ 
	description = "Booster Pack";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//================================================================
echo("booster pack Loaded");