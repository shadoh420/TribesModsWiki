$ObjectTypeProjectile = 1 << 8;
$TeamItemMax[ANuke] = 6;

$InvList[ANuke] = 1;
$RemoteInvList[ANuke] = 1;

$ItemMax[darmor, ANuke] = 0;
$ItemMax[dfemale, ANuke] = 0;

$ItemMax[harmor, ANuke] = 0;
$ItemMax[hfemale, ANuke] = 0;

$ItemMax[barmor, ANuke] = 0;
$ItemMax[bfemale, ANuke] = 0;

$ItemMax[marmor, ANuke] = 0;
$ItemMax[mfemale, ANuke] = 0;

$ItemMax[earmor, ANuke] = 1;
$ItemMax[efemale, ANuke] = 1;

$ItemMax[dmarmor, ANuke] = 0;
$ItemMax[dmfemale, ANuke] = 0;

$ItemMax[larmor, ANuke] = 0;
$ItemMax[lfemale, ANuke] = 0;

$ItemMax[spyarmor, ANuke] = 0;
$ItemMax[spyfemale, ANuke] = 0;

$ItemMax[stimarmor, ANuke] = 0;
$ItemMax[stimfemale, ANuke] = 0;

$ItemMax[sarmor, ANuke] = 0;
$ItemMax[sfemale, ANuke] = 0;

$ItemMax[aarmor, ANuke] = 0;
$ItemMax[afemale, ANuke] = 0;

$ItemMax[jarmor, ANuke] = 0;

function ANukeTarget::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $NukeDamageType) return;
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function ANukeTarget::onDestroyed(%this)
{
	GameBase::stopSequence(%this,0);
	if (getobjecttype(%this.nuke) == false) return;
	if (GameBase::Virtual(%this.nuke, "isNuke")) {
		deleteObject(%this.nuke);
		if (getobjecttype(%this.subnuke) != false) deleteObject(%this.subnuke);
	}
}

function ANukeTarget::setUpNukeObjs(%this, %nuke, %snuke, %isup)
{
	%this.nuke = %nuke;
	%this.subnuke = %snuke;
	%this.isPointingUp = %isup;
}

function ANukeTarget::TrackPosition(%this)
{
	//word 0 of rot is up/down (positive/negative)
	//word 2 of pos is height

	%trans = GameBase::GetPosition(%this.nuke);
	if (%this.isPointingUp) {
		%trans = getWord(%trans, 0) @ " " @ getWord(%trans, 1) @ " " @ (getWord(%trans, 2) - 1);
	} else {
		%trans = getWord(%trans, 0) @ " " @ getWord(%trans, 1) @ " " @ (getWord(%trans, 2) + 1);
	}
	GameBase::setPosition(%this, %trans);
	//schedule("ANukeTarget::TrackPosition(" @ %this @ ");", 1, %this);
}

function ANukeTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "ANuke"]--;
}

// Override base class just in case.
function ANukeTurret::onPower(%this,%power,%generator) {}
function ANukeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function ANukeTurret::CheckForNukes(%this)
{
	if (!GameBase::isActive(%this)) return;
	%set = newObject("set",SimSet);
	if (%set) {
		%num = containerBoxFillSet(%set, $ObjectTypeProjectile, GameBase::GetPosition(%this), 250, 250, 250);

		for(%i=0;%i<%num;%i++)
		{
			%obj = Group::getObject(%set, %i);
			%isNuke = GameBase::Virtual(%obj, "isNuke");
			echo("Object " @ %i @ " = " @ getObjectType(%obj) @ ", isnuke = " @ %isNuke @ ", its owners team = " @ GameBase::Virtual(%obj, "getOwnerTeam") @ ", myteam = " @ Gamebase::GetTeam(%this) @ ", rot = " @ Gamebase::GetRotation(%obj));
			if ((!%isNuke) || (GameBase::Virtual(%obj, "getOwnerTeam") == Gamebase::GetTeam(%this))) continue;
			if (%isNuke) {
				%nt = newObject("","StaticShape",ANukeTarget);
       	  		 	addToSet("MissionCleanup", %nt);
				schedule("deleteObject(" @ %nt @ ");", 10, %nt);

				GameBase::Virtual(%nt, "setUpNukeObjs", %obj, GameBase::Virtual(%obj, "getSubProj"), (getWord(GameBase::GetRotation(%obj), 0) > 0));
				ANukeTarget::TrackPosition(%nt);

				%trans = GameBase::getMuzzleTransform(%this);
				%trans = getWord(%trans, 0) @ " " @ getWord(%trans, 1) @ " " @ getWord(%trans, 2) @ " " @ getWord(%trans, 3) @ " " @ getWord(%trans, 4) @ " 3.1415 " @ getWord(%trans, 6) @ " " @ getWord(%trans, 7)  @ " " @ getWord(%trans, 8) @ " " @ getWord(%trans, 9) @ " " @ getWord(%trans, 10) @ " " @ getWord(%trans, 11);
				Projectile::spawnProjectile("ANukeRocket",%trans,%this,0, %nt);
				playSound(bigExplosion1,gamebase::getposition(%this));
				break;
			}
		}
		deleteObject(%set);
	}
	schedule("ANukeTurret::CheckForNukes(" @ %this @ ");", 2.5, %this);
}

function ANukeTurret::verifyTarget(%this,%target) {
	return false;
}

//Item stuff

function ANuke::onUse(%player,%item)
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

function ANuke::onDeploy(%player,%item,%pos)
{
	if (ANuke::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ANuke::deployShape(%player,%item)
{

	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);					//== Player Team
	%playerpos = GameBase::getPosition(%player);				//== Player Position
	%homepos = ($teamFlag[%playerteam]).originalPosition;
//	%flagdist = Vector::getDistance(%playerpos,%homepos);   		//== Player To Flag Distance

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
	    			//%set = newObject("set",SimSet);
				//%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				//%num = CountObjects(%set,"DeployableTurret",%num);
				//deleteObject(%set);
				//if($MaxNumTurretsInBox > %num)
				//{
		    			//%set = newObject("set",SimSet);
					//%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					//%num = CountObjects(%set,"DeployableTurret",%num);
					//deleteObject(%set);
					//if(0 == %num)
					//{
						//if (Vector::dot($los::normal,"0 0 1") > 0.7)
						//{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("ANukeTurret","Turret",ANukeTurret,true);
	                    					addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Nuclear Defense System");
								Client::sendMessage(%client,0,"Nuclear Defense System deployed.");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ANuke"]++;
								echo("MSG: ",%client," deployed an anti-nuke turret.");
								GameBase::setRechargeRate(%turret,5);
								%turret.shieldStrength = 0.005;
								GameBase::setActive(%turret,true);
								ANukeTurret::CheckForNukes(%turret);
								return true;
							}
						//}
						//else 
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
					//else
					//	Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
			   //	}
			   //else 
			   //		Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
