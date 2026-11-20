// Unused i think... could be used as an actuall suicide bomb.. but im 
// not taking the time to code that up.
MineData Suicidebomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "marmor";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 600;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 5000;
};

function Suicidebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate("@ %this @");", 0.5, %this);
}

//====This is the bomb that is used in the detpack launcher and the====//
//====detpack which is found in the pack menu in the inventory=========//
MineData Suicidebomb2
{
	mass = 0.3;
	drag = 0.1;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "marmor";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 200;
	damageValue = 750.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 500;
};

function Suicidebomb2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate("@ %this @");", 20, %this);
}

function Suicidebomb2::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj))
	{ return; }
	
	%clientId = Player::getClient(%obj);
	%pTeam = GameBase::getTeam(%obj);
	%dTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	
	if (%armor != "larmor")
	{ return; }
	
	%rnd = floor(getRandom() * 10);
	Echo("RND: "@ %rnd);
	
	if(%rnd > 7)
	{
		// Make it look like the client is actually talking with the light brown or font #5.
		MessageAll(5, Client::getName(%clientId) @": I just ate my own ass after trying to Disarm a DetPack.");
		CenterPrint(%clientId, "<jc><f1> It Was The Blue Wire You Dumb Shit.", 5);
		Mine::Detonate(%this);
		%clientId.fuckedup = true;
		Schedule(%clientId @".fuckedup = false:", 20);
		return;
	}
	else
	{
		deleteObject(%this);
		Client::sendMessage(%clientId, 0, "You disarmed A DetPack!");
		CenterPrint(%clientId, "<jc><f1>You disarmed A DetPack!", 5);
	}
}