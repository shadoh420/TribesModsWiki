//================================================================
//Grappling Hook
//================================================================
//$InvList[Grapple] = 1;
//$InvList[TargetingLaser] = 1;
//$RemoteInvList[Grapple] = 1;
//$RemoteInvList[TargetingLaser] = 1;
//==========================================

//===============================================================
SoundData SoundGrappling
{
   wavFileName = "bxplo4.wav";
   profile = Profile3dNear;
};
//================================================================
LightningData ttargetpull { bitmapName = "repairadd.bmp"; damageType = 0; boltLength = 80.0; coneAngle = 32.0; damagePerSec = 0.0; energyDrainPerSec = 0.0; segmentDivisions = 5; numSegments = 1; beamWidth = 0.25; updateTime = 300; skipPercent = 0.5; displaceBias = 0.0; }; 

function abs(%val) {
	if(%val < 0)
		return -%val;
	else
		return %val;
}

function ttargetpull::damageTarget(%obj, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %client) {	
	%type = getObjectType(%obj);
	if(%type == "Mine" || %type == "Player") return;
	%pos = GameBase::getPosition(%client);
	%oPos = GameBase::getPosition(%obj);
	%hdist = getWord(%oPos, 2) - getWord(%pos, 2);
	%rot = GameBase::getRotation(%client);
	%flatPos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " 0";
	%oFlatPos = getWord(%oPos, 0) @ " " @ getWord(%oPos, 1) @ " 0";
	%dist = Vector::getDistance(%flatPos, %oFlatPos); 
	%curVel = Item::getVelocity(%client);
	%force = ((%dist / 75) * 50) + 5.3;
	if(%hdist > 0) %height = ((%hdist / 75) * 52) + 5;
	%addVel = Vector::getFromRot(%rot, %force, %height);
	%newXvel = getword(%addVel, 0) + getword(%curVel, 0);
	if(abs(%newXvel) > 28)
		%addVel = getword(%addVel, 0) - getword(%curVel, 0) @ " " @ getword(%addVel, 1) @ " " @ getword(%addVel, 2);
	%newYvel = getword(%addVel, 1) + getword(%curVel, 1);
	if(abs(%newYvel > 28))
		%addVel = getword(%addVel, 0) @ " " @ getword(%addVel, 1) - getword(%curVel, 1) @ " " @ getword(%addVel, 2);
	%newZvel = getword(%addVel, 2) + getword(%curVel, 2);
	if(%newZvel > 50)
		%addVel = getword(%addVel, 0) @ " " @ getword(%addVel, 1) @ " " @ getword(%addVel, 2) - getword(%curVel, 2);
	Player::applyImpulse(%client, %addVel);
}		
//================================================================
ItemImageData TargetingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = NoProjectile; accuFire = true; minEnergy = 5; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundNoSound; sfxActivate = SoundPickUpWeapon; }; 

ItemData TargetingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "iSpecial"; shadowDetailMask = 4; imageType = TargetingLaserImage; price = 25; showWeaponBar = false; showInventory = false;}; 

function TargetingLaser::onUse(%player,%item)
{
	if(Player::getItemCount(%player, RealTargetingLaser))
		Tool::onUse(%player, RealTargetingLaser);
	else if(Player::getItemCount(%player, Smoker))
		Tool::onUse(%player, Smoker);
	else if(Player::getItemCount(%player, TractorBeam))
		Tool::onUse(%player, TractorBeam);
	else if(Player::getItemCount(%player, Grapple)) {
		if(Player::getMountedItem(%player, $WeaponSlot) != Grapple) {
			%state = Player::getItemState(%player,$WeaponSlot);
			if (%state == "Fire" || %state == "Reload") return;
			Tool::onUse(%player, Grapple);
			TargetingLaser::onUse(%player,%item);
		} else if(%player.lastgrap < getSimTime()) {
			%client = Player::getClient(%player); 
			if (GameBase::getLOSInfo(%player, 80)) { 	
				if(satcheckDeployArea(%client, $los::position)) {
					if(Vector::getDistance($los::position, GameBase::getPosition(%player)) > 5) {
						%type = getObjectType($los::object);	
						if(%type != "Player" && %type != "Flier") {
							%player.lastgrap = getSimTime() + 4;
							Grapple::onUnmount(%player, 0);
							Grapple::setHook(%player);
						} else {
							Client::sendMessage(%client, 0, "Cannot attach to this object.");
						}
					} else {
						Client::sendMessage(%client, 0, "Unable to deploy - You're in the way.");
					}
				}
			} else {
				Client::sendMessage(%client, 0, "Nothing to attach to in range.");
			}
		} else {
			%client = Player::getClient(%player); 
			Client::sendMessage(%client, 0, "Grappling hook reloading.");
		}
	} else if(Player::getItemCount(%player, PSmoker))
		Tool::onUse(%player, PSmoker);
	else if(Player::getItemCount(%player, Bee)) {
		if(BBB(%player)) Player::decItemCount(%player,Bee);
	} else if(Player::getItemCount(%player, Anti)) {
		Player::setItemCount(%player, Anti, 0);
		GameBase::repairDamage(%player,0.1); 
		%c = Player::getClient(%player);
		if(%c.poisonTime > 0) %c.poisonTime = -10; 
		if(%c.empTime > 2) %c.empTime = 2;
	} else if(Player::getItemCount(%player, Scouter))
		Scouter::deployShape(%player,Scouter);
	else if(Player::getItemCount(%player, Flagger)) {
		%fsitem = Player::getMountedItem(%player, $FlagSlot);
		if(%fsitem == -1) {
			Player::mountItem(%player,Flagger,$FlagSlot); 
			Client::sendMessage(Player::getClient(%player),0,"Flag Decoy On"); 	
		} else if(%fsitem == Flagger) {			
			Player::unmountItem(%player,$FlagSlot); 
			Client::sendMessage(Player::getClient(%player),0,"Flag Decoy Off"); 	
		}
	} else if(Player::getItemCount(%player, EMPMine)) {
		ThrowMine(%player, EMPMine, EMPME);
	} else if(Player::getItemCount(%player, GASMine)) {
		ThrowMine(%player, GASMine, GASME);
	}

}

function ThrowMine(%player, %item, %mine) {
	%client = Player::getClient(%player);
	if(%client.possessed || %client.possessing) return;
	if(%player.throwTime < getSimTime()) { 
		Player::decItemCount(%player, %item); 
		%armor = Player::getArmor(%player); 
		%obj = newObject("", "Mine", %mine); 
		if($Game::missionType == "Duel") {
			$DuelMines[%client, $DuelMinesCount[%client]] = %obj;
			$DuelMinesCount[%client]++;
		}
		GameBase::setTeam(%obj, GameBase::getTeam(%client)); 
		addToSet("MissionCleanup", %obj); 
		GameBase::throw(%obj, %player, 8, false); 
		%player.throwTime = getSimTime() + 0.5; 
	}
}



ItemImageData GrappleImage {
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2; 
	projectileType = ttargetPull;
	accuFire = true;
	minEnergy = 2;
	maxEnergy = 23;
	reloadTime = 0.75;
	//lightType   = 3;  
	//lightRadius = 5;
	//lightTime   = 1;
	//lightColor  = { 0.1, 1.0, 0.1 };
	//sfxFire     = SoundGrappling;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Grapple {
	description   = "Grappling Hook";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "tTool";
	showInventory = false;
	shadowDetailMask = 4;
	imageType     = GrappleImage;
	price         = 250;
	showWeaponBar = false;
	showInventory = false;
	   validateShape = true;
   validateMaterials = true;
};
function Grapple::onUnmount(%player,%imageSlot) {
	%client = Player::getClient(%player); 
	if(%client.hook)
		GameBase::setDamageLevel(%client.hook, 9);
}
function Grapple::setHook(%player) {
	%client = Player::getClient(%player); 
	Client::sendMessage(%client,0,"~wbxplo4.wav");
	%hook = newObject("", "StaticShape", "GHook", true);
	%hook.setter = %client;
	addToSet("MissionCleanup", %hook);		
	%client.hook = %hook;
	GameBase::setRotation(%hook, Vector::getRotation($los::normal));
	GameBase::setPosition(%hook, $los::position);
}
//================================================================
