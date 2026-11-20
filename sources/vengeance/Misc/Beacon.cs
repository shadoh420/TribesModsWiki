$InvList[Beacon] = 1;
$MobileInvList[Beacon] = 1;
$RemoteInvList[Beacon] = 0;
AddItem(Beacon);

$SellAmmo[Beacon] = 5;
$TeamItemMax[Beacon] = 40;

addAmmo("", Beacon, 1);

// ok, we're doing some trickery with these lil buggers. 
// When a player uses one, we change armor to one with little ground traction..
// for slip and slide action.. -Plasmatic


ItemData Beacon 
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	showInventory = false;
};

StaticShapeData DefaultBeacon
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.1;
	maxEnergy = 200;

	castLOS = true;
	supression = false;
	mapFilter = 2;
	//mapIcon = "M_marker";
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};
																						 


function Beacon::onUse(%player,%item) 
{
//	echo("beacon");
	if(!$matchStarted) 
		return;
		
	//Pitchfork fun via beacon key. -Plasmatic
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon == Pitchfork && Player::isTriggered(%player,$WeaponSlot))
	{
		%object = %player.GrabObject;
		Player::trigger(%player,$WeaponSlot,false);		
		schedule("Pitchfork::fire("@%player@","@%object@");",0.1);		
		return;
	}		
	else
	{	
		// Toggle sliderz
		%client = Player::getClient(%player);
		%armor = Player::getArmor(%client);
		%baseArmor = $ArmorName[%armor];
		
		if(%player.BeaconSlide)	//String::findSubStr(%armor, "Ice") > 5)
		{
			//we're slippery, damnit!
			//female1.wcolor2.wav
			client::sendmessage(Player::getclient(%player),1,"Ski Boots OFF.~wfemale1.wcolor2.wav");
			if(!%player.slide)
				%buyarmor = Ann::Replace(%armor, "Ice", "");
			%player.BeaconSlide = false;
		}
		else
		{
			client::sendmessage(Player::getclient(%player),1,"Turning on Ski Boots.~wfemale1.wtaunt1.wav");
			%buyarmor = %armor @ "Ice";
			%player.BeaconSlide = true;
			schedule("CheckSlide("@%player@");",0.25);
		}	
		%energy = GameBase::getEnergy(%player);
		Player::setArmor(%client,%buyarmor);
		GameBase::setEnergy(%player,%energy);	
	}
}

function checkslide(%player)
{
	if(%player.BeaconSlide)
	{
		if(!%player.slide)	// no change if we're overiding with the manual client ski key.. -Plasmatic
		{
			%client = Player::getClient(%player);
			%vel = Item::getVelocity(%player);
			%speed = vector::getdistance(%vel,"0 0 0");
			if(%speed > 22 || Player::getLastContactCount(%Client) > 0.5)
				%shouldSlide = true;
				
			%armor = Player::getArmor(%client);
			
			if(String::findSubStr(%armor, "Ice") > 5)
				%iceArmor = true;
			
			if(%shouldSlide != %iceArmor)
			{
					
				if(%shouldSlide)
					%buyarmor = %armor @ "Ice";
				else	
					%buyarmor = Ann::Replace(%armor, "Ice", "");
				%energy = GameBase::getEnergy(%player);
				Player::setArmor(%client,%buyarmor);
				GameBase::setEnergy(%player,%energy);								
			}
		}	
	schedule("CheckSlide("@%player@");",0.25);
	}
}


function remoteSlide(%client,%flag)
{
	//echo("remote slide "@%flag);
	%player = Client::getOwnedObject(%client);
	%time = getsimtime();	// Idiot proofing.. Sigh. -Plasmatic
	if(%player.lastSlide + 0.125 <=  %time)	
	{
		%armor = Player::getArmor(%client);
		%player.lastSlide = %time;
		%player.slide = %flag;
		if(String::findSubStr(%armor, "Ice") > 5)
			%slider = true;

		if(!%flag)
		{
			//we're slippery, damnit!
			client::sendmessage(Player::getclient(%player),1,"You = !Slide.");
			%buyarmor = Ann::Replace(%armor, "Ice", "");
		}
		else
		{
			client::sendmessage(Player::getclient(%player),1,"Slide!");		
			%buyarmor = %armor @ "Ice";
		}	
		if(%flag != %slider)
		{
			%energy = GameBase::getEnergy(%player);
			Player::setArmor(%client,%buyarmor);
			GameBase::setEnergy(%player,%energy);	
		}					
	}
}