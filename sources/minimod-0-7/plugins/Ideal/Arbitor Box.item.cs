// This is a MiniMod Plugin.
// This is the Arbitor Box from the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Arbitor Box.ArmorData.cs
//    Arbitor Box.item.cs
//    Arbitor Box.reinitData.cs
//    Arbitor Box.station.cs
//    Arbitor Box.turret.cs
//
// to your MiniMod/plugins directory.

$TeamItemMax[ArbitorBoxPack] = 1;

ItemImageData ArbitorBoxPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ArbitorBoxPack
{
	description = "Arbitor Device";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ArbitorBoxPack::onUse(%player,%item)
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

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBoxPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBoxPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Arbitor Device deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
						echo("MSG: ",%client," deployed an Arbitor Box");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");

	return false;
}

		$TeamItemCount[0 @ ArbitorBoxPack] = 0;
		$TeamItemCount[1 @ ArbitorBoxPack] = 0;
		$TeamItemCount[2 @ ArbitorBoxPack] = 0;
		$TeamItemCount[3 @ ArbitorBoxPack] = 0;
		$TeamItemCount[4 @ ArbitorBoxPack] = 0;
		$TeamItemCount[5 @ ArbitorBoxPack] = 0;
		$TeamItemCount[6 @ ArbitorBoxPack] = 0;
		$TeamItemCount[7 @ ArbitorBoxPack] = 0;
