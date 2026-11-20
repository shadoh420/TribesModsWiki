
//----------------------------------------------------------------------------
// MINE Friendly

$SellAmmo[MineAmmo] = 5;
$TeamItemMax[MineAmmo] = 40;
$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;
$ItemMax[larmor, MineAmmo] = 1;
$ItemMax[lfemale, MineAmmo] = 1;
$ItemMax[marmor, MineAmmo] = 1;
$ItemMax[mfemale, MineAmmo] = 1;
$ItemMax[harmor, MineAmmo] = 2;
$ItemMax[carmor, MineAmmo] = 1;
$ItemMax[sarmor, MineAmmo] = 3;


ItemImageData MineAmmoImage
{
	shapeFile = "mine";
	mountPoint = 2;
	mountOffset = { 0.65, 0, -0.25 };
	mountRotation = { 0, -1.57, -0.35 };
	firstPerson = false;
	mass = 0.3;
};

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMines";
   shadowDetailMask = 4;
   price = 39;
	className = "HandAmmo";
   imageType = MineAmmoImage;
   mass = 0.5;
   elasticity = 0.2;};

function MineAmmo::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$MineSlot) != %item) {
		if (Player::getMountedItem(%player,$MineSlot) != -1) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%MineSlot));
			}
		else
			Player::mountItem(%player,%item,$MineSlot);
	}
	else {
		if($matchStarted) {
			if(%player.throwTime < getSimTime() ) {
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","AntipersonelMine");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
		}
	}
}
function MineAmmo::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
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
	%whosisit = GameBase::getControlClient(%this);
	%mineTeam = GameBase::getTeam(%whosisit);
	%targetTeam = Client::getTeam(%object);
	if (((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable" || %type == "Weapon" || %type == "Ammo")
		&& GameBase::isActive(%this)) && %targetTeam != %mineTeam)
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
		deleteObject(%set);
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
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


//----------------------------------------------------------------------------

$SellAmmo[Grenade] = 5;
$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;
$ItemMax[larmor, Grenade] = 2;
$ItemMax[lfemale, Grenade] = 2;
$ItemMax[marmor, Grenade] = 3;
$ItemMax[mfemale, Grenade] = 3;
$ItemMax[harmor, Grenade] = 5;
$ItemMax[carmor, Grenade] = 2;
$ItemMax[sarmor, Grenade] = 2;

ItemImageData GrenadeImage
{
	shapeFile = "grenade";
	mountPoint = 2;
	mountOffset = { 0.25, 0.05, -0.25 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 0.2;
};

ItemData Grenade
{
   description = "Frag Grenade";
   shapeFile = "grenade";
   heading = "eMines";
   shadowDetailMask = 4;
   price = 29;
   className = "HandAmmo";
   imageType = GrenadeImage;
   mass = 0.5;
   elasticity = 0.2;
};

function Grenade::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$MineSlot) != %item) {
		if (Player::getMountedItem(%player,$MineSlot) != -1) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%MineSlot));
			}
		else
			Player::mountItem(%player,%item,$MineSlot);
	}
	else {
		if($matchStarted) {
			if(%player.throwTime < getSimTime() ) {
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","Handgrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
		}
	}
}

function Grenade::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

$SellAmmo[FlashGrenade] = 5;
$InvList[FlashGrenade] = 1;
$RemoteInvList[FlashGrenade] = 1;
$ItemMax[larmor, FlashGrenade] = 2;
$ItemMax[lfemale, FlashGrenade] = 2;
$ItemMax[marmor, FlashGrenade] = 3;
$ItemMax[mfemale, FlashGrenade] = 3;
$ItemMax[harmor, FlashGrenade] = 4;
$ItemMax[carmor, FlashGrenade] = 2;
$ItemMax[sarmor, FlashGrenade] = 2;

ItemImageData FlashGrenadeImage
{
	shapeFile = "grenade";
	mountPoint = 2;
	mountOffset = { 0.25, 0.05, -0.25 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 0.2;
};

ItemData FlashGrenade
{
   description = "Flash Grenade";
   shapeFile = "grenade";
   heading = "eMines";
   shadowDetailMask = 4;
   price = 29;
   className = "HandAmmo";
   imageType = FlashGrenadeImage;
   mass = 0.5;
   elasticity = 0.2;
};

function FlashGrenade::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$MineSlot) != %item) {
		if (Player::getMountedItem(%player,$MineSlot) != -1) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%MineSlot));
			}
		else
			Player::mountItem(%player,%item,$MineSlot);
	}
	else {
		if($matchStarted) {
			if(%player.throwTime < getSimTime() ) {
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","FlashHandgrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
		}
	}
}

function FlashGrenade::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


MineData FlashHandgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function FlashHandgrenade::onAdd(%this)
{
	schedule("FlashGrenade::Detonate(" @ %this @ ");",2.0,%this);
}


function FlashGrenade::Detonate(%this)
{
	%set=newObject("set",SimSet);
	%targetCount = containerBoxFillSet(%set,$SimPlayerObjectType,GameBase::getPosition(%this),15,15,15,0);
	for(%i=0; %i<=%targetCount; %i++)
		{ 
		%target=Group::getObject(%set, %i);
		Player::setDamageFlash(%target,1.0); 
		for(%seconds=1; %seconds<=5; %seconds++)
			{ schedule("Player::setDamageFlash("@ %target @",1.0);",%seconds,%target); }
		}
	deleteObject(%set);

	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
//----------------------------------------------------------------------------
// Vortex Grenade
//----------------------------------------------------------------------------
$SellAmmo[VortexGrenade] = 1;
$InvList[VortexGrenade] = 1;
$RemoteInvList[VortexGrenade] = 1;
$ItemMax[larmor, VortexGrenade] = 1;
$ItemMax[lfemale, VortexGrenade] = 1;
$ItemMax[marmor, VortexGrenade] = 1;
$ItemMax[mfemale, VortexGrenade] = 1;
$ItemMax[harmor, VortexGrenade] = 2;
$ItemMax[carmor, VortexGrenade] = 1;

ItemImageData VortexGrenadeImage
{
	shapeFile = "grenade";
	mountPoint = 2;
	mountOffset = { 0.25, 0.05, -0.25 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 0.3;
};

ItemData VortexGrenade
{
   description = "Vortex Grenade";
   shapeFile = "grenade";
   heading = "eMines";
   shadowDetailMask = 4;
   price = 59;
	className = "HandAmmo";
   imageType = VortexGrenadeImage;
   mass = 0.5;
   elasticity = 0.2;
};

function VortexGrenade::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$MineSlot) != %item) {
		if (Player::getMountedItem(%player,$MineSlot) != -1) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%MineSlot));
			}
		else
			Player::mountItem(%player,%item,$MineSlot);
	}
	else {
		if($matchStarted) {
			if(%player.throwTime < getSimTime() ) {
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","VortexHandGrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
		}
	}
}

function VortexGrenade::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


MineData VortexHandGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Vortex Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function VortexHandgrenade::onAdd(%this)
{
	%startSlurping = 1.0;
	%boomTime = 3.0;
	for (%timeCounter=%startSlurping; %timeCounter <= %boomTime; %timeCounter = %timeCounter + 0.1)
	{ schedule("Vortexgrenade::VortexFun(" @ %this @ "," @ %timeCounter @ ");",%timeCounter,%this); }
	schedule("Mine::Detonate(" @ %this @ ");",%boomTime,%this);
}

function Vortexgrenade::VortexFun(%this, %timeCounter)
{
	%grenadePos=GameBase::getPosition(%this);
  	%grenadeSet=newObject("grendadeSet",SimSet);
	%numObjects=containerBoxFillSet(%grenadeSet,$SimPlayerObjectType | $VehicleObjectType,%grenadePos,40,40,40,0);
	for (%objCounter=0; %objCounter <= %numObjects; %objCounter++)
		{
		%target=Group::getObject(%grenadeSet, %objCounter);
		%targetPos=GameBase::getPosition(%target);

		%grenadeX=getWord(%grenadePos, 0);
		%grenadeY=getWord(%grenadePos, 1);
		%grenadeZ=getWord(%grenadePos, 2);
		%targetX=getWord(%targetPos, 0);
		%targetY=getWord(%targetPos, 1);
		%targetZ=getWord(%targetPos, 2);
		%wayPointOne=%grenadeX+(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY+(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointTwo=%grenadeX+(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY-(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointThree=%grenadeX-(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY-(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointFour=%grenadeX-(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY+(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";

		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointTwo;
		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointThree;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointFour;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointOne;

		%distanceToWayPoint=Vector::getDistance(%targetPos, %targetWayPoint);
		%force=1+(%distanceToWayPoint / 200);
		%targetVector=Vector::sub(%targetWayPoint, %targetPos);
		%targetNewVector=getWord(%targetVector, 0) * %force @ " " @ getWord(%targetVector, 1) * %force @ " " @ getWord(Vector, 2) * %force @ " "; 
		Item::setVelocity(%target, %targetNewVector);
		}
		
	deleteObject(%grenadeSet);
}



//----------------------------------------------------------------------------

$SellAmmo[StickyBomb] = 1;
$InvList[StickyBomb] = 1;
$RemoteInvList[StickyBomb] = 1;
$ItemMax[larmor, StickyBomb] = 1;
$ItemMax[lfemale, StickyBomb] = 1;
$ItemMax[marmor, StickyBomb] = 2;
$ItemMax[mfemale, StickyBomb] = 2;
$ItemMax[harmor, StickyBomb] = 3;
$ItemMax[carmor, StickyBomb] = 1;
$ItemMax[sarmor, StickyBomb] = 1;

ItemImageData StickyBombImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0.25, 0.15, -0.25 };
	mountRotation = { 0, 1.57, -0.4 };
	firstPerson = false;
	mass = 0.5;
};


ItemData StickyBomb
{
   description = "Sticky Bomb";
   shapeFile = "sensor_small";
   heading = "eMines";
   shadowDetailMask = 4;
   price = 49;
	className = "HandAmmo";
   imageType = StickyBombImage;
   mass = 0.5;
   elasticity = 0.2;
};

function StickyBomb::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$MineSlot) != %item) {
		if (Player::getMountedItem(%player,$MineSlot) != -1) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) 
				Player::decItemCount(%player, Player::getMountedItem(%player,%MineSlot));
			}
		else
			Player::mountItem(%player,%item,$MineSlot);
	}
	else {
		if($matchStarted) {
			if(%player.throwTime < getSimTime() ) {
				Player::decItemCount(%player,%item);
				%obj = newObject("","Mine","StickyHandgrenade");
	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,10 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
		}
	}
}

function StickyBomb::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,1)) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


MineData StickyHandgrenade
{
   mass = 0.5;
   drag = 1.0;
   density = 2.0;
	elasticity = 0;
	friction = 10.0;
	className = "Handgrenade";
   description = "Sticky Bomb";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function StickyBombgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",8.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


