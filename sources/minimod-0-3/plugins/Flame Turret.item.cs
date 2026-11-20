//This is a MiniMod Plugin...
//This is the Flame Turret from the Ideal mod. Ported by Dewy.

$TeamItemMax[FlameTurretPack] = 2;

ItemImageData FlameTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData FlameTurretPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function FlameTurretPack::onUse(%player,%item)
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

function FlameTurretPack::onDeploy(%player,%item,%pos)
{
	if (FlameTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function FlameTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				%Set = newObject("set",SimSet); 
				%Mask = $StaticObjectType; 
				%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
				for(%i; %i < %num; %i++)
				{
					%thing = Group::getObject(%Set, %i);
					if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
					{
						%inbase= true;
						break;
					}
				}
				deleteObject(%Set);
				if(%inbase)
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret = newObject("Flame Turret","Turret",FlameTurret,true);
     		           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Flame Turret " @ Client::getName(%client));

							%cyl = newObject("Flame Turret Fuel","StaticShape",Canister,true);
     		           				addToSet("MissionCleanup", %cyl);
							GameBase::setTeam(%cyl,GameBase::getTeam(%player));
							%backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.

							GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
							GameBase::setRotation(%cyl,%rot);
							Gamebase::setMapName(%cyl,"Flame Turret Fuel");

							%turret.cyl = %cyl;
							%cyl.turret = %turret;

							Client::sendMessage(%client,0,"Flame Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
							echo("MSG: ",%client," deployed an Flame Turret");
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);

							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							{
								GameBase::setDamageLevel(%turret, 0.7 * FlameTurret.maxDamage);
								GameBase::setDamageLevel(%cyl, 0.7 * Canister.maxDamage);
							}

							return true;
						}
						else
							Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"You must be near your own base");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

$TeamItemCount[0 @ FlameTurretPack] = 0;
$TeamItemCount[1 @ FlameTurretPack] = 0;
$TeamItemCount[2 @ FlameTurretPack] = 0;
$TeamItemCount[3 @ FlameTurretPack] = 0;
$TeamItemCount[4 @ FlameTurretPack] = 0;
$TeamItemCount[5 @ FlameTurretPack] = 0;
$TeamItemCount[6 @ FlameTurretPack] = 0;
$TeamItemCount[7 @ FlameTurretPack] = 0;

