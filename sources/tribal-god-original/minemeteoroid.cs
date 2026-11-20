MineData Meteoroid
{
	mass = 10.0;
	drag = 1.0;
	density = 1.0;
	elasticity = 0;
	friction = 10000;
	className = "Handgrenade";
	description = "Meteoroid";
	shapeFile = "shockwave_large";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 10;
	damageType = $MeteoroidDamageType;
	kickBackStrength = 1000;
	triggerRadius = 5;
	maxDamage = 0.001;
};

function Meteoroid::onAdd(%this)
{ Schedule("AirStrikeShell::CheckRest("@ %this @");", 1.0); }

function Meteoroid::onDestroyed(%this)
{ Meteoroid::ExtraExplode(%this); }

$TG::MeteoroidWaitTime = 120;
function Meteoroid::onStart()
{
	if($Meteoroid::Stop)
	{ $Meteoroid::Stop = false; return; }
		
	%numClients = getNumClients();
	%numCl = ((2049 + %numClients) + 20);
	%linenum = 10;

	for(%k = 0; %k < %numClients; %k++) 
	{ %clientList[%k] = getClientByIndex(%k); }

	for(%k = 0; %k < %numClients; %k++)
	{
		%player = Client::getOwnedObject(%clientList[%k]);
		%checkChance = floor(getRandom() * 50);
		
		if(%checkChance <= 5)
		{ %msg = ", But it was burnt up upon entering the atmosphere."; }
		else if(%player != "-1")
		{
			%type = getObjectType(%player);
			if(Player::isDead(%player) || %type != "Player")
			{ %msg = ", no worries though, it won't hurt dead ppl."; }
			else
			{
				%pos = GameBase::getPosition(%player);
				%Xpos = getword(%pos, 0) + ((getRandom() * 200) - (getRandom() * 200));
				%Ypos = getword(%pos, 1) + ((getRandom() * 200) - (getRandom() * 200));
				%Zpos = getword(%pos, 2);
				%NZpos = floor(getRandom() * 1000) + 1000;
				%NZpos += %Zpos;

				%pos = %Xpos @" "@ %Ypos @" "@ %NZpos;
				%obj = newObject("", "Mine", "Meteoroid");
				GameBase::setPosition(%obj, %pos);
				
				%msg = "! They are " @ %NZpos @ "meters above your head.";
			}
		}
		else
		{ %msg = ", but who cares, your not even alive."; }
		BottomPrint(%clientList[%k],"<jc>A Meteoroid <f1>Is in the area"@ %msg,10);
	}
	
	%waitTime = floor(getRandom() * 60 + $TG::MeteoroidWaitTime);
	Schedule("Meteoroid::onStart();", %waitTime);
}

function KeepHeightTrack(%clientId, %this)
{
	%pos = GameBase::getPosition(%this);
	if((%Zpos = getword(%pos, 2)) == 0)
	{ bottomprint(%clientId,"<jc><f2>Take COVER!", 5); return; }
	else if(%Zpos == "-98298")
	{ return; }
	bottomprint(%clientId,"<jc><f1>Meteoroid Status: <f2>"@ %Zpos @" <f1>meters above your head!", 1);
	schedule("KeepHeightTrack("@ %clientId @","@ %this @");",0.1);
}

function Meteoroid::ExtraExplode(%this)
{
	%Pos = GameBase::getPosition(%this); 
	%vel = Item::getVelocity(%this);
	%xvel = getWord(%vel, 0);
	%yvel = getWord(%vel, 1);
	%zvel = getWord(%vel, 2);
	
	if (GameBase::getPosition(%this))
	{
		for(%i = 0; %i < 5; %i += 1)
		{
			%xrnd = %xvel + floor(getRandom() * 60) - 30;
			%yrnd = %yvel + floor(getRandom() * 60) - 30;
			%zrnd = %zvel + floor(getRandom() * 20);
			
			%forceVel = %xrnd @" "@ %yrnd @" "@ %zrnd;
			%trans =  "0 0 1 0 0 0 0 0 1 "@ getBoxCenter(%this);
			%obj = Projectile::spawnProjectile("MeteroidShell", %trans, %this, %vel);
			Projectile::spawnProjectile(%obj);
			GameBase::setPosition(%obj, %pos);
			Item::setVelocity(%obj, %forceVel);
		}
	}
}