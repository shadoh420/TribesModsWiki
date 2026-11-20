//===============================
// Mine Data
//===============================
// Anti-Personel Mine		- Scout, Goliath
// Proximity Mine		- Engineer
// SubSpace Mine		- Chemeleon
// Mock-Repair Kit		- Assassin
// Speed Boost			- Mercinary
// Flag Mine			- Assassin
// ShockWave			- Arbitor
// Replicator			- Engineer
//============================================================================================ Anti-Personel Mine

MineData AntipersonelMine
{
	className = "Mine";
   	description = "Antipersonel Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& ((GameBase::getTeam(%this)!=GameBase::getTeam(%object))||($Shifter::DeathMatch)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		deleteObject(%set); //
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;
   if(%type == $FlashDamageType)
      %value = 5.0;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//============================================================================================ Proximity Detection Mine

//As far as I'm concerned, the dumbest mine ever.  I'm working on fixing it so it's not so damn lame -- Y|yukichigai
//Update: They are now powered-down Det Bugs.  No killing, just minor EMP damage.  Much better than proximity mines

MineData ProxMine
{
	className = "Mine";
	description = "Det Bug"; //"Antipersonel Mine";
	shapeFile = "armorPatch"; //"radar_small";
	shadowDetailMask = 4;
	rotates = true;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 1.5; //20;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ProxMine::onAdd(%this)
{
	%this.damage = 0;
	ProxMine::deployCheck(%this);
}

function ProxMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);

	if ((%type == "Player" || %data == Vehicle || %type == "Moveable") &&
		GameBase::isActive(%this)
		&& ((GameBase::getTeam(%this)!=GameBase::getTeam(%object))||($Shifter::DeathMatch)) //no teamdmg
		) 
	{		
		%client = Player::getClient(%object);
		if(%client)
		{
			if(%client.lastdropper)
				%client.lastdropper = "Add "@%this.deployer;
			else
			{
				%client.lastdropper = "";
				Client::sendMessage(%client,1,"Warning: energy circuit malfunction detected!~waccess_denied.wav");
				DetBug::checkDet(%object,%this,%this.deployer,5,1);
			}

			GameBase::ApplyDamage(%this,$FlashDamageType,5,"0 0 0","0 0 0","0 0 0",%object);
		}
	
//		if ($ScreamerDelay == "" || $ScreamerDelay == 0)
//		{
//			$proxteam = GameBase::getTeam(%this);
//			$ScreamerDelay = "1";
//			TeamMessages(1, $proxteam, "Incoming Enemies. ~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav~wusepack.wav");
//			schedule("$ScreamerDelay = 0;", 10);
//			//echo ("Alerting Team");
//		}
//
	}		
}

function ProxMine::deployCheck(%this)
{
	%player = %this.deployer;

	if($TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"] >= $TeamItemMax[PulseSensorPack])
	{
		GameBase::ApplyDamage(%this,$FlashDamageType,5.0, "0 0 0", "0 0 0", "0 0 0", %this);
		return;
	}

	if (GameBase::isAtRest(%this)) {

//		%pos = GameBase::getPosition(%this);
//		%rot = GameBase::getRotation(%this);
//
//		deleteObject(%this);
//		$TeamItemCount[GameBase::getTeam(%player) @ "mineammo"]--;
//
//		%sensor = newObject("","Sensor",DeployablePulseSensor,true);
//		addToSet("MissionCleanup", %sensor);
//		GameBase::setTeam(%sensor,GameBase::getTeam(%player));
//		GameBase::setPosition(%sensor,%pos);
//		GameBase::setRotation(%sensor,%rot);
//		Gamebase::setMapName(%sensor,"Remote Pulse Sensor");
//
//		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;

		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
//		%set = newObject("set",SimSet);
//
//		deleteObject(%set); //
	}
	else 
		schedule("ProxMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ProxMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function ProxMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== SubSpace-Cloak Mine

MineData SubspaceMine
{
	className = "Mine";
        description = "Subspace Mine";
        shapeFile = "sensor_small";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function SubspaceMine::onAdd(%this)
{
	//echo("SubSpace Mine Added");

	%this.damage = 0;
        SubspaceMine::deployCheck(%this);
}

function SubspaceMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::startFadeOut(%this);
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);

		%set = newObject("set",SimSet);

		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
        schedule("SubspaceMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function SubspaceMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        
        if (((GameBase::getTeam(%object) != GameBase::getTeam(%this))||($Shifter::DeathMatch)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
        GameBase::setDamageLevel(%this, %data.maxDamage);
}

function SubspaceMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;
   if(%type == $FlashDamageType)
      %value = 5.0;

   if(%type == $DeCloakDamageType || (%type == $CloakDamageType && GameBase::getTeam(%this) != GameBase::getTeam(%object)))
	GameBase::startFadeIn(%this);

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//==================================================================================================== Mock Repair Pack

MineData HoloMine
{
	className = "Mine";
   description = "Hologram";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 350; //500
	triggerRadius = 2.5; //250
	maxDamage = 2.00;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this)
{
	//echo("Holo Mine Added");

	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);

}

function HoloMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& ((GameBase::getTeam(%this)!=GameBase::getTeam(%object))||($Shifter::DeathMatch)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function HoloMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;
   if(%type == $FlashDamageType)
      %value = 5.0;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//========================================= Insta-holo Mine
MineData HoloMine1
{
	className = "Mine";
   description = "Hologram";
   shapeFile = "armorPack";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0; //250
	damageValue = 0.75; //0
	damageType = $MineDamageType;
	kickBackStrength = 350; //500
	triggerRadius = 2.5; //250
	maxDamage = 2.00;//0
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine1::onAdd(%this)
{
	%this.damage = 0;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);

}

//==================================================================================================== Dead Body Mine

MineData BodyMine1
{
	className = "Mine";
        description = "Body Mine";
        shapeFile = "larmor";
        shadowDetailMask = 4;
        explosionId = mineExp;
        explosionRadius = 15.0;
        damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
};

function BodyMine1::onAdd(%this)
{

	%this.damage = 0;
        BodyMine1::deployCheck(%this);
}

function BodyMine1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		%rnd = floor(getRandom() * 5);
		if(%rnd == 5)
			%armor = "darmor";
		else if(%rnd == 4)
			%armor = "mfemale";
		else if(%rnd == 3)
			%armor = "marmor";
		else if(%rnd == 2)
			%armor = "lfemale";
		else
			%armor = "larmor";
	   	%pl = spawnPlayer(%armor, GameBase::getPosition(%this), GameBase::getRotation(%this));
		GameBase::setTeam(%pl,GameBase::getTeam(%this));
		deleteobject(%this);
		%pl.isamine = true;
		%pl.droppr = %this.deployer;
		GameBase::setDamageLevel(%pl,5);
	}
	else 
        schedule("BodyMine1::deployCheck(" @ %this @ ");", 3, %this);
}	

function BodyMine1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        
        if (((GameBase::getTeam(%object) != GameBase::getTeam(%this))||($Shifter::DeathMatch)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
        GameBase::setDamageLevel(%this, %data.maxDamage);
}


//==================================================================================================== Flag Mine - Decoy

MineData Hologram
{
	className = "Mine";
	description = "Flag";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 3.5;//5.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 100;//150;
	triggerRadius = 2.5;
	maxDamage = 2.0; //3.00;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

};

function Hologram::onAdd(%this)
{
	%this.damage = 0;
	Hologram::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
        if (((GameBase::getTeam(%object) != GameBase::getTeam(%this))||($Shifter::DeathMatch)) && (%type == "Player" || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}	

function Hologram::onDestroyed(%this)
{
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   %data = GameBase::getDataName(%this);
   if ($Shifter::FlagMines != "false" && $MatchConfig != "true")
   {
	GameBase::setDamageLevel(%this, %data.maxDamage);
	return;
   }
   if(%type == $FlashDamageType)
      %value = 5.0;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

//==================================================================================================== ShockWave Mine

MineData ShockMine
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $ImpactDamageType; //$MortarDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function ShockMine::onAdd(%this)
{
	
	%data = GameBase::getDataName(%this);
	schedule("GameBase::startFadeOut(" @ %this @ ");",8.0,%this);

}
function ShockMine::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	if ((GameBase::getTeam(%this)!= GameBase::getTeam(%obj))||($Shifter::DeathMatch))
	{
        GameBase::startFadeIn(%this);
		schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
	}
}

function ShockMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType || %type == $ImpactDamageType)
      %value = %value * 0.25;

	if(%type == $FlashDamageType)
		%value = 5.0;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ShockMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//==================================================================================================== Replicator

//=== The mine itself does no damage.  Rather, the onDestroyed function does, allowing players to get kills for
//===  any mine collisions beyond the first

MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.0;//0.65;
	damageType = $MineDamageType;
	kickBackStrength = 0.0;//150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ReplicatorMine::onAdd(%this)
{
	%this.damage = 0.0;
	ReplicatorMine::deployCheck(%this);
}

function ReplicatorMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	
	if (((%type == "Player")  || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && ((GameBase::getTeam(%this)!=GameBase::getTeam(%object))||($Shifter::DeathMatch))) //JR 1/31/99
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ReplicatorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		%team = GameBase::getTeam(%this);
		//echo(%team @ " in deploy check");

		$TeamItemCount[%team @ "replicatingmine"]++;
		
		if(%this.generation == 0)
			$TeamItemCount[%team @ "originalreplicatingmine"]++;
 	
	 	GameBase::setActive(%this,true);
		
		%set = newObject("set",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine])
		{
//			if($TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine])
				%this.generation = 6;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ReplicatorMine::deployCheck(" @ %this @ ");", 1 + getRandom()* 3, %this);
}	

function ReplicatorMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);

	//=== Only apply damage if the mine wasn't destroyed because of proximity/team limit issues
	if(%this.generation < 5)
		GameBase::applyRadiusDamage($MineDamageType, getBoxCenter(%this), 10.0, 0.65, 150,%this.deployer); //added

	$TeamItemCount[%team @ "replicatingmine"]--;

	if(%this.generation < 4)
		replicateMines(%this, %this.generation+1);
}

function ReplicatorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.3;
   if(%type == $FlashDamageType)
      %value = 5.0;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function replicateMines(%this, %generation)
{
	%team = GameBase::getTeam(%this);
	%owner = %this.deployer; //GameBase::getownerclient(%this);
	//echo("Creating generation " @ %generation @ " for team " @ %team);

	%obj = newObject("","Mine","ReplicatorMine");
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;
	%obj.deployer = %owner; //added

	GameBase::setTeam(%obj, %team);
	//GameBase::setOwnerClient(%obj, %owner);

	%obj = newObject("","Mine","ReplicatorMine");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;
	%obj.deployer = %owner; //added

	GameBase::setTeam(%obj, %team);
	//GameBase::setTeam(%obj, %owner);
}


//================================================================================================= Telebeacon Mine

MineData Telebeacon
{
	className = "Mine";
        description = "Telebeacon";
        shapeFile = "discb"; //"sensor_small";
        shadowDetailMask = 4;
        explosionId = ShockwaveFour;
        explosionRadius = 5.0;
        damageValue = 0.15;
	damageType = $ImpactDamageType;
	kickBackStrength = 450;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Telebeacon::onAdd(%this)
{
	if ($debug) echo("Telebeacon Mine Added");
	%this.damage = 0;
        Telebeacon::deployCheck(%this);
}

function Telebeacon::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::setActive(%this,true);
		%clientId = %this.deployer;
		%pos = GameBase::getPosition(%this);

		//=== Clear out any old telebeacons, just in case
		if(%clientId.telebeacon > 0)
		{
			GameBase::applyDamage(%clientId.telebeacon, $FlashDamageType, 0.1, %clientId.telepoint,"0 0 0", "0 0 0", Client::getOwnedObject(%clientId));
			if($debug) echo("Killing rogue Telebeacon");
		}
		%clientId.telepoint = %pos;
		%clientId.telebeacon = %this;
		bottomprint(%clientId, "<jc><f2>Your TeleBeacon is now active.  Use your pack to teleport.", 3);

	}
	else 
        	schedule("Telebeacon::deployCheck(" @ %this @ ");", 3, %this);
}	

function Telebeacon::onCollision(%this,%object)
{
	return;
}

function Telebeacon::onDestroyed(%this)
{
	%clientId = %this.deployer;
	bottomprint(%clientId, "<jc><f2>Your TeleBeacon has been destroyed!!!", 3);
	%clientId.telebeacon = 0;
	%clientId.telepoint = "false";
	$TeamItemCount[GameBase::getTeam(%this) @ "TeleBeacons"]--;
}

function Teleceacon::onDeactivate(%this)
{
	Telebeacon::onDestroyed(%this);
}

function Telebeacon::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
	if(%type == $FlashDamageType)
		%value = 5.0;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}
//================================================================================================ Suicide Pack 2 On Deploy

MineData PickUpPack
{
	mass = 999.3;
	drag = 999.0;
	density = 999.0;
	elasticity = 0.0;
	friction = 999.0;
	className = "Handgrenade";
	description = "ShockWave Mine";
	shapeFile = "MagCargo";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.25;
	damageType = $MortarDamageType;
	kickBackStrength = 100;
	triggerRadius = 1.0;
	maxDamage = 2.0;
};

function PickUpPack::onAdd(%this)
{
	PickUpPack::deployCheck(%this);
	schedule ("deleteobject( " @ %this @ ");",120);
}

function PickUpPack::onCollision(%this,%player)
{
	if(getObjectType(%player) != "Player") {return;}
	if(Player::isDead(%player)) {return;}

    	%client = Player::getClient(%player);
    	%plTeam = GameBase::getTeam(%player);
	%ppTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	
	if (%player != -1)
	{
		%cnt = Station::itemsToResupply(%player);
		//echo ("Ammount " @ %cnt);
		
		if(getSimTime() - %this.enterTime > 11)
			%cnt = 0;
			
		if (%cnt != 0)
		{
			return;
		}
	}
	GameBase::setActive(%this,false);
	%this.enterTime="";
}

function PickUpPack::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
	 	GameBase::setActive(%this,true);
		Gamebase::setMapName(%this, "Pick Up Pack");
		%this.ammount = 5000;	
		//echo ("Active");
	}
	else
	{
		schedule("PickUpPack::deployCheck(" @ %this @ ");", 3, %this);
	}
}

//================================================================================================ Bouncin' Betty Mine

MineData BBMine
{
	className = "Mine";
   	description = "Bouncin' Betty";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = fakeExp;
	explosionRadius = 10.0;
	damageValue = 0.1;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function BBMine::onAdd(%this)
{
	%this.damage = 0;
	BBMine::deployCheck(%this);
}

function BBMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& ((GameBase::getTeam(%this)!=GameBase::getTeam(%object))||($Shifter::DeathMatch)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function BBMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1.5,1.5,1.5,0)) {
			%data = GameBase::getDataName(%this);
			%this.dead = true;
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		
		deleteObject(%set); //
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function BBMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;

	if(%this.dead)
	{
		%this.dead = "";
		return;
	}

	%player = Client::getOwnedObject(%this.deployer);
	%trans = "0 0 0 0 0 0 0 0 0 "@ getBoxCenter(%this);

	%proj = Projectile::spawnProjectile("BBShell", %trans, %player, "0 0 25");

	%proj.deployer = %this.deployer;
}

function BBMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;
   if(%type == $FlashDamageType)
      %value = 5.0;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

GrenadeData BBShell
{
   bulletShapeName    = "mine.dts";
   explosionTag       = mineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.35;
   damageType         = $MineDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 400;
   totalTime          = 200.0;
   liveTime           = 0.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "breath.dts";
};

function BBShell::onAdd(%this)
{
	schedule("BBShell::Deploy("@%this@");",0.4);
}

function BBShell::Deploy(%this)
{
	%pos = GameBase::getPosition(%this);
	%playerId = Client::getOwnedObject(%this.deployer);
	%cnt = 25;
	%blammo = BBBullet;
	for (%j=0; %j < %cnt; %j++)
	{
		%neg1 = (floor(getRandom() * 2) * -2) + 1;
		%neg2 = (floor(getRandom() * 2) * -2) + 1;
		%neg3 = (floor(getRandom() * 2) * -2) + 1;	
		%neg4 = (floor(getRandom() * 2) * -2) + 1;
		%neg5 = (floor(getRandom() * 2) * -2) + 1;
		%neg6 = (floor(getRandom() * 2) * -2) + 1;
		%neg7 = (floor(getRandom() * 2) * -2) + 1;
		%neg8 = (floor(getRandom() * 2) * -2) + 1;
		%neg9 = (floor(getRandom() * 2) * -2) + 1;
		%dir = (getRandom() * %neg2 @ " " @ getRandom() * %neg1 @ " " @ getRandom() * %neg3);
		%dir1 = (getRandom() * %neg6 @ " " @ getRandom() * %neg5 @ " " @ getRandom() * %neg4);
		%dir2 = (getRandom() * %neg7 @ " " @ getRandom() * %neg8 @ " " @ getRandom() * %neg9);
		%fired = Projectile::spawnProjectile(%blammo,(%dir @ " " @ %dir1 @ " " @ %dir2 @ " " @ %pos),%playerId,"0 0 0");
		%fired.deployer = %this.deployer;
	}
}

BulletData BBBullet
{
	bulletShapeName    = "tumult_small.dts";
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.30;
	damageType         = $MineDamageType;

	explosionRadius    = 8.0;
	kickBackStrength   = 350.0;
	maxLevelFlightDist = 150;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 1.5;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.1;
	muzzleVelocity     = 500.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 45;
};

//============================================================================================ Mine Module Antipersonel Mine

MineData AntipersonelMine2
{
	className = "Mine";
   	description = "Antipersonel Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
	elasticity = 0.0;
   	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelMine2::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine2::deployCheck(%this);
}

function AntipersonelMine2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine2::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
	}
	else 
		schedule("AntipersonelMine2::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine2::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine2::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//============================================================================================ Anti-Personel Mine (unfriendly)

MineData AntipersonelMine3
{
	className = "Mine";
   	description = "Antipersonel Mine";
   	shapeFile = "mine";
   	shadowDetailMask = 4;
   	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	//validateShape = true;
};

function AntipersonelMine3::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine3::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
	//		&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine3::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine3::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $CloakDamageType)
   {
	GameBase::startFadeout(%this);
	return;
   }
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
