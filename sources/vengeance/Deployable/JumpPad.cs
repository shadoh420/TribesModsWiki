$InvList[JumpPadPack] = 1;
$MobileInvList[JumpPadPack] = 1;
$RemoteInvList[JumpPadPack] = 1;
AddItem(JumpPadPack);
addWeapon(JumpPadPack);

$CanAlwaysTeamDestroy[JumpPad] = 1;

ItemImageData JumpPadPackImage
{
	shapeFile = "discb";	//"grenammo";	//discb";
	
	mountPoint = 0;			//Vengeance
	weaponType = 0;			//Vengeance
	reloadTime = 0.1;			//Vengeance	
	fireTime = 0.1;			//Vengeance
	sfxActivate = SoundPickUpWeapon;	//Vengeance
	mountOffset = { 0.1, 0.2 , 0.05 };		//Vengeance	//right, forward, up
	mountRotation = {1.07, -0.11, 0};		//Vengeance	//up, right, around player axis	
//	mountOffset = {0.25, 0.5, -0.25};	//{ 0.21, 0.5 , -0.3 };	//right, forward, up
//	mountRotation = {1.57,0 , 0};	//up, right, around player axis

	//firstPerson = false;
};

ItemData JumpPadPack
{
	description = "Catapult Pad";
	shapeFile = "flagstand";
	className = "HandDeployable";	//className = "Tool";	//className = "Backpack";
	heading = $InvHead[ihDSm];
	imageType = JumpPadPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JumpPadPackImage::onFire(%player,%item)	//JumpPadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	%item = JumpPadPack;
	
	if($TeamItemCount[%team @ %item] >= $TeamItemMax[%item] && !$build)
	{
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 -1") > 0.6)
	{
		Client::sendMessage(%client,0,"Cannot deploy on ceiling.");
		return false;
	}
	if(Vector::dot($los::normal,"0 0 1") < 0.7)
	{
		Client::sendMessage(%client,0,"Area not flat enough to deploy.");
		return false;
	}	
// check if object is in motion, for dropships and jail cell -plasmatic
	%obj = $los::object;
	if(%obj.inmotion == true)	 
	{ 
		Client::sendMessage(%client,0,"Deploy area crappy, cannot deploy.");
		return false;
	}
	%pos = $los::position;	//Vector::add($los::position,"0 0 -0.5");		
	%obj = newObject("JumpPad","StaticShape",JumpPad,true);
	
	if(GameBase::testPosition(%obj, %pos))
	{
		%decoration = newObject("Accelerator Device", "Item", JumpPadSpinna, 1, true, true);
		addToSet("MissionCleanup/deployed/object", %decoration);
		%obj.cloakable = true;
		addToSet("MissionCleanup/deployed/object", %obj);
		GameBase::setTeam(%obj,%team);
	
		%rot=GameBase::getRotation(%player);
		
		GameBase::setPosition( %obj, %pos );
		GameBase::startFadeIn(%obj);
		GameBase::setRotation(%obj,GameBase::getRotation(%player));
		GameBase::setPosition(%decoration,vector::add(%pos,"0 0 0.25"));
		GameBase::setRotation(%decoration,GameBase::getRotation(%player));
		
		%obj.decoration = %decoration;
	
		Gamebase::setMapName(%obj,"Catapult Pad ");
		Client::sendMessage(%client,0,%item.description @ " deployed");
		if(!$build)
			echo("MSG: ",%client," deployed a Catapult Pad ");
	
		$TeamItemCount[%team @ %item]++;
		GameBase::startFadeIn(%obj);
		playSound(SoundThrowItem,$los::position);	//playSound(SoundPickupBackpack,$los::position);
		
		if(!$build)
			Player::setItemCount(%player, %item, 0);
		//remotenextweapon(%client);
		return true;
	}
	else
	{
		Client::sendMessage(%client,0,%item.description @ " will not fit there.");
		deleteobject(%obj);
	}
}
function JumpPadPack::onmount(%player,%weapon) 
{	
	//Player::mountItem(%player,BlasterGunA,$SpareSlot1);
	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Catapults players around.");
}


StaticShapeData JumpPad 
{
	shapeFile = "flagstand";
	maxDamage = 5.00;
	debrisId = defaultDebrisMedium;
	explosionId = debrisExpLarge;
	visibleToSensor = true;
	damageSkinData = "objectDamageSkins";
	description = "JumpPad";
};

ItemData JumpPadSpinna
{
   	description = "Spinnah";
	shapeFile = "discb";	
//	imageType = 0;
	showInventory = false;
	shadowDetailMask = 4;
	
	lightType = 1; // 1=continuous, 2=Pulsing, 3=fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.3, 0.4, 0.5};	//lightColor = { 1, 1, 0.2 };yellow	//lightColor = { 0.4, 0.4, 1.0 };	//
};
function JumpPad::onDestroyed(%this)
{
	%this.cloakable = "";
	%this.nuetron = "";
	%decoration = %this.decoration;
	deleteobject(%decoration);
	$TeamItemCount[GameBase::getTeam(%this) @ "JumpPadPack"]--;
}

function JumpPad::onCollision(%this,%obj)
{	
	
//	if($debug) 
		event::collision(%this,%obj);

	if(getObjectType(%obj) != "Player")
		return;
	if(Player::isDead(%obj))
		return;
	if(%this.cloaked > 0 && getObjectType(%obj) == "Player")
	{
		//pop this visible for a second -plasmatic
		%this.cloaked = "";
		GameBase::startFadein(%this);
	}	
	%client = Player::getClient(%obj);
	%dist = vector::getdistance(GameBase::getPosition(%this),GameBase::getPosition(%obj));


	//only pass through this if on top.. -Plasmatic
	if(%dist < 1.50)
	{
		%power = 300;
		%vel = Item::getVelocity(%obj);
		%speed = vector::getdistance(0,%vel);
		//echo("jumpy dist"@%dist@", speed ="@%speed@", vel ="@%vel);
		//bottomprint(%client, "<jc>"@%dist@", speed ="@%speed);
		if(%speed > 5.5)
		{	
			%vec = Vector::Normalize(%vel);
			%fvec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power;
			Player::applyImpulse(%obj, %fvec);
			GameBase::playSound(%this, SoundFireMortar, 0);
			schedule("player::getspeed("@%obj@");",0.05);
		}
	}	
}
function player::getspeed(%player)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%player);
	%speed = vector::getdistance(0,%vel);	
	Client::sendMessage(%client,0, "*spank! "@floor(%speed)@"kph.");	
}

//from shifter, modified by Plasmatic to use %trans
function JumpPadPack::CheckPlayer(%this,%obj)
{
	echo("check player deploy");
	%tpos=GameBase::getPosition(%this);
	%opos=GameBase::getPosition(%obj);
	%tstartX=getWord(%tpos,0);
	%tstartY=getWord(%tpos,1);
	%tstartZ=getWord(%tpos,2);
	%ostartX=getWord(%opos,0);
	%ostartY=getWord(%opos,1);
	%ostartZ=getWord(%opos,2);

	%diffX=%ostartX-%tstartX;
	%diffY=%ostartY-%tstartY;
	%diffZ=%ostartZ-%tstartZ-0.92;
	%deploy=0;
	%recall=1;

	if(%diffZ>0.5) %deploy=1;
	if(%diffZ<0) %deploy=-1;
	
	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%client);
	
	if(%deploy>0)
	{
		//begin deploy
		%armor=GameBase::getDataName(%obj);
		%mass=%armor.mass;
		%rot=GameBase::getRotation(%obj);

		%rnd=floor(getrandom()*30);
		if(%rnd > 20) 
		{
			GameBase::playSound(%this, debrisLargeExplosion, 0);
			Client::SendMessage(%client, 0, "K-E-R-S-P-R-O-I-N-G-g-g-g-!-!");
			%rnd = %rnd + 10;
		}
		else
		{
			GameBase::playSound(%this, SoundFireMortar, 0);
			Client::SendMessage(%client, 0, "SPROING!");
		}	
		%len = 40 + %rnd;
		%trans = GameBase::getMuzzleTransform(%obj);
		%tr= getWord(%trans,5);
		if(%tr < 0) %tr = -%tr;
		%tr = %tr+ 0.15;
		%up = %tr;
		%out = 1-%tr;
		%vec = Vector::getFromRot(%rot,%len*%mass*%out,%len*%mass*%up);
		Player::applyImpulse(%obj,%vec);
		schedule(%obj @ ".deployStandby=0;",0.1);
		%recall = 0;
		// end deploy
	}
	else if(%deploy < 0)
	{
		%recall = 0;
		%obj.deployStandby = 0;
	}
	if(%recall)
		schedule("JumpPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
	else
		bottomprint(%client, "",0);//remoteEval(%client, "CP", "", 0);
}
