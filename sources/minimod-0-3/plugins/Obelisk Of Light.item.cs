// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from the Ideal mod. Ported by Dewy.
//

$TeamItemMax[ObeliskPack] = 2;

$TeamItemMax[ObeliskPowerPack] = 2;

ItemImageData ObeliskPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPack
{
	description = "Obelisk of Light";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ObeliskPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ObeliskPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%Set = newObject("set",SimSet); 
			%Mask = $StaticObjectType; 
			%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
			for(%i; %i < %num; %i++)
			{
				%gen = Group::getObject(%Set, %i);
				if(%gen.obeliskpower && %gen.obelisk == "")
				{
					%powered = true;
					break;
				}
			}
			deleteObject(%Set);
			if(%powered)
			{
				%obj = getObjectType($los::object);
				if (%obj != "InteriorShape")
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret2 = newObject("ObeliskBarrel","Turret",RealObeliskOfLight,true);
	                 				addToSet("MissionCleanup", %turret2);
							GameBase::setTeam(%turret2,GameBase::getTeam(%player));
							GameBase::setPosition(%turret2,Vector::add($los::position, "0 0 11.5"));
							GameBase::setRotation(%turret2,%rot);

							%turret = newObject("Obelisk","StaticShape",ObeliskOfLight,true);
      	           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);

							%turret.realGun = %turret2; //referencing variables
							%turret.gen = %gen;
							%gen.obelisk = %turret2;

							Gamebase::setMapName(%turret,"Obelisk of Light " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Obelisk of Light deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPack"]++;
							echo("MSG: ",%client," deployed an Obelisk of Light. Turret is:" @ %turret @ " and Turret2 is: " @ %turret2);
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);
							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
								GameBase::setDamageLevel(%turret, 0.7 * ObeliskOfLight.maxDamage);

							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"Cannot deploy in buildings");
			}
			else
				Client::sendMessage(%client, 0, "Must be within range of an Obelisk Power Source");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData ObeliskPowerPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -1.0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPowerPack
{
	description = "Obelisk Power Souce";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPowerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ObeliskPowerPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPowerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPowerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 

						%generator = newObject("ObeliskPower","StaticShape",ObeliskPower,true);
                 				addToSet("MissionCleanup", %generator );
						GameBase::setTeam(%generator ,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);

						%generator.obeliskpower = true;

						Gamebase::setMapName(%turret,"Obelisk Power Source " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Obelisk Power Source deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPowerPack"]++;
						echo("MSG: ",%client," deployed an Obelisk Power Source");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %generator); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%generator, 0.7 * ObeliskPower.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

		$TeamItemCount[%i @ ObeliskPack] = 0;
