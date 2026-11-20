
//============================ Functions For Beacons and Other Ammos and Items ===============================
//
// Holds functions for varrious items in the game, including cloaking and stim, as well as varrious beacons 
// and other stuff. All are special functions specific to a given item.
//
//==================================================================================================== Det.Bug

function doneposs(%cl) 
{  
	if(%cl.possessing)
	{  
		Client::setControlObject(%cl, %cl);  
		Client::setControlObject(%cl.poss, %cl.poss);
		if(%cl.obsposs)
		{
			deleteobject(%cl.obsposs);
			%cl.obsposs = "";
			%cl.observerMode = "observerOrbit";
			Observer::enterObserverMode(%cl);
			Observer::jump(%cl);
		}
		if($Hologram2[%cl.poss] == false) //%cl.poss != %cl.holo)
		{ 
			MessageAllExcept(%cl.poss, 0, Client::getName(%cl.poss) @ " is no longer possessed by " @ Client::getName(%cl) @ ".~wteleport2.wav");  
			Client::sendMessage(%cl.poss,1,"Your soul has been freed of " @ Client::getName(%cl)@".~wteleport2.wav"); 
		}
		else
		{
			$Hologram[%cl.poss, Possessor] = false;
			$point[%cl.poss] = "";
			setCommandStatus(%cl.poss,0,"");
		}
		%cl.possessing = false;  
		(%cl.poss).possessed = false; 
		(%cl.poss).possby = "";
		%cl.poss = "";
		UnCheckObservers(%cl); 
	}
	if(%cl.possessed)
	{
		Client::setControlObject(%cl.possby, %cl.possby);   
		Client::setControlObject(%cl, %cl);
		%poss = %cl.possby;
		if(%poss.obsposs)
		{
			deleteobject(%poss.obsposs);
			%poss.obsposs = "";
			%poss.observerMode = "observerOrbit";
			Observer::enterObserverMode(%poss);
			Observer::jump(%poss);
		}
		if($Hologram2[%cl] == false) //%cl != (%cl.possby).holo)
		{ 
			MessageAllExcept(%cl , 0, Client::getName(%cl) @ " is no longer possessed by " @ Client::getName(%cl.possby) @ ".~wteleport2.wav"); 
			Client::sendMessage(%cl ,1,"Your soul has been freed of " @ Client::getName(%cl.possby)@".~wteleport2.wav");
		}
		else
		{
			$Hologram[%cl, Possessor] = false;
			$point[%cl] = "";
			setCommandStatus(%cl,0,"");
		}
		%cl.possessed = false;  
		(%cl.possby).possessing = false; 
		(%cl.possby).poss = "";   %cl.possby = ""; 
	} 
}

function startposs(%cl, %possessor)
{
	if(!%cl || !%possessor)
		return;

	if(%possessor.observermode == "ObserverOrbit" || %possessor.observermode == "ObserverFly")
	{
		%possessor.observermode = "";
		%pos = GameBase::getPosition(%cl);
		%rot = GameBase::getRotation(%cl);
		%ppos = Vector::Sub(%pos,"0 0 500");
		%pl = spawnPlayer(dmarmor, %ppos, %rot);
		%possessor.obsposs = %pl;
   	   	Client::setOwnedObject(%possessor, %pl);
		Client::setControlObject(%possessor, %pl);
		Player::setItemCount(%pl,Grenade,1);
		Player::SetItemCount(%pl,MineAmmo,1);
		Player::setItemCount(%pl,Beacon,1);
	}

	if(%possessor.possessing)
	{ 
		if(%possessor.poss == %cl)
		{
			doneposs(%possessor);
			return;
		}
		doneposs(%possessor);
	}
	if($Hologram2[%cl] == false && %cl != %possessor.holo && %cl != %possessor)
	{
		MessageAllExcept(%cl , 0, Client::getName(%cl) @ " is possessed by " @ Client::getName(%possessor) @ ".~wteleport2.wav"); 
		Client::sendMessage(%cl ,1,"Your soul is under the command of " @ Client::getName(%possessor)@".~wteleport2.wav");
	}
	else if($Hologram2[%cl])
	{
		$Hologram[%cl, Possessor] = %possessor;
		$point[%cl] = "";
		setCommandStatus(%cl,0,"");
	}
	Client::setControlObject(%possessor, %cl);
	if(%possessor != %cl)
	{
		Client::setControlObject(%cl, -1);
		%cl.possby = %possessor;
		%cl.possessed = true;
		%possessor.possessing = true;
		%possessor.poss = %cl;
	}
	else
		%possessor.possessing = false;
	checkObserved(%possessor,%cl);
}

//====================================== Checkhackable Returns TRUE if NOT in the list.
function checkHackable(%name, %shape)
{ 
	if(%shape == "generator" ||
	%shape == "Generator" ||
	%shape == "generator_p" ||
	%shape == "solar_med" ||
	%shape == "inventory_sta" ||
	%shape == "elevator_4x4" ||
	%shape == "elevator_6x6" ||
	%shape == "elevator_6x6_octagon" ||
	%shape == "elevator_8x4" ||
	%shape == "elevator_8x6" ||
	%shape == "elevator_9x9" ||
	%shape == "elevator16x16_octo" ||
	%shape == "elevator6X4" ||
	%shape == "elevator_6x5" ||
	%shape == "elevator_8x8" ||
	%shape == "elevator6x4thin" ||
	%shape == "elevator6x6thin" ||
	%shape == "elevator_5x5" ||
	%shape == "elevator_4x5" ||
	%shape == "door_top" ||
	%shape == "door_bot" ||
	%shape == "newdoor1_l" ||
	%shape == "newdoor1_r" ||
	%shape == "newdoor2_l" ||
	%shape == "newdoor2_r" ||
	%shape == "newdoor3_l" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" ||
	%shape == "newdoor4_r" ||
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r" ||
	%shape == "door_8x8_l" ||
	%shape == "door_8x8_r" ||
	%shape == "forcefield" ||
	%shape == "forcefield_3x4" ||
	%shape == "forcefield_4x17" ||
	%shape == "newdoor3_r" ||
	%shape == "newdoor4_l" || 
	%shape == "newdoor4_r" || 
	%shape == "newdoor6_l" ||
	%shape == "newdoor6_r"	||
	%shape == "forcefield_4x14" ||
	%shape == "forcefield_4x8" ||
	%shape == "forcefield_5x5" || 
	%shape == "door_4x4_diagonal" ||
	%shape == "tower" ||
	%shape == "camera" ||
	%shape == "hellfiregun" ||
	%shape == "indoorgun" ||
	%shape == "mortar_turret" ||
	%shape == "ammounit" || 
	%shape == "sensor_pulse_med" ||
	%shape == "station_cmdpnl" ||
	%shape == "missileturret" ||
	%shape == "cmdpnl" ||
	%shape == "radar" ||
	%shape == "anten_lava" ||
	%shape == "chainturret" ||
	%shape == "vehi_pur_poles" ||
	%shape == "remoteturret")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;

	%player = Client::getOwnedObject(%client);
	
	if ($debug) echo  ("Hacking");
	
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{
			if($debug)
			{
				echo ("TARGET   " @ %target);
				echo ("PTEAM    " @ %pTeam);
				echo ("PNAME    " @ %pName);
				echo ("TNAME    " @ %tName);
				echo ("NAME     " @ %name);
				echo ("SHAPE    " @ %shape);
				echo ("TEAM     " @ %team);
				echo ("CLIENT   " @ %client);
			}
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time -1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true")
	{
		if ($debug) echo ("PT - " @ %pteam @ "");
		if ($debug) echo ("TT - " @ %team @ "");
		if ($debug) echo ("HK - " @ $hacking[%client] @ "");
		if ($debug) echo ("TG - " @ %target @ "");
		if ($debug) echo ("Tm - " @ %time @ "");

		if($hacking[%client] == "true")
		{
			if(%team == %pTeam)
			{
				if ($debug) echo ("infecting");
				%target.infected = "true";
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection from hacking.");
				return;
			}
			else
			{
			
				if (%target.infected == "true")
				{
					%rnd = floor(getRandom() * 100);	
					if (%rnd > 50)
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!");
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						if($debug) echo ("hackerror");
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						if($debug) echo ("hackerror");
						return;
					}
				}
				
				if(%name == "False" && %shape == "magcargo")
				{

					$Nukecount[GameBase::getTeam(%target)]++;
					$Nukecount[GameBase::getTeam(%client)]--;
					TeamMessages(1,GameBase::getTeam(%target),Client::getName(%client) @ " has disarmed and stolen #" @ $Nukecount[GameBase::getTeam(%target)] @ " of your team's " @ $Shifter::AllNukeLimit @ " nuclear devices.",GameBase::getTeam(%client),Client::getName(%client) @ " has increased your team's nuclear stockpile by 1.");
					deleteObject(%target);
					Client::sendMessage(%client,1,"You safely disarm the Suicide Det Pack.");	
					%client.score = %client.score + 20;
					Game::refreshClientScore(%client);
				}
				else if(String::findSubStr(%name, "SatchelPack") >= 0)
				{
					%rnd = floor(getRandom() * 25);
					if(%rnd == 1)
					{	
					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						GameBase::applyDamage(%target, $DebrisDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %client);
						return;
					}
					else
					{	
					    Client::sendMessage(%client,1,"You safely disarm and dispose of the Satchel Charge.");
						%client.score = %client.score + 5;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}
				}
				else
				{
					if(%name != False && %name != "")
					{
						TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
						TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					}
					GameBase::setTeam(%target,%pTeam);
					if(Player::isAIControlled(%target))
						Client::setTeam(Player::getClient(%target),%pTeam);
					
					if($Shifter::HackedTime > 0)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
						if(Player::isAIControlled(%target))
							schedule("Client::setTeam('" @ Player::getClient(%target) @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime, %target);
						
					}

					if(%target < $minHacked || $minHacked == -1)
					{
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1)
					{
						$maxHacked = %target;
					}
				}	
			}
		}
	}
}

function cycleWeaponOptions(%client)
{
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if($debug) echo("Weapon Cycle - " @ Client::getName(%client) @ " - " @ %weapon.description @ "");
	if(%weapon == "PlasmaGun")
	{
		if(%client.Plasma == 0 || !%client.Plasma)
			remoteweapon_plasma_rapid(%client);
		else if(%client.Plasma == 1)
			remoteweapon_plasma_multi(%client);
		else
			remoteweapon_plasma_regular(%client);
	}
	else if(%weapon == "Mortar")
	{
		if(%client.Mortar == 0 || !%client.Mortar)
			remoteweapon_mortar_emp(%client);
		else if(%client.Mortar == 1)
			remoteweapon_mortar_frag(%client);
		else if(%client.Mortar == 2)
			remoteweapon_mortar_mdm(%client);
		else
			remoteweapon_mortar_regular(%client);
	}
	else if(%weapon == "Disclauncher" && $Shifter::DiscOpts != "false")
	{
		if(%client.Disc == 0 || !%client.Disc)
			remoteweapon_disc_rapid(%client);
		else
			remoteweapon_disc_regular(%client);
	}
	else if(%weapon == "RocketLauncher")
	{
		if(%client.rocket == 0 || !%client.rocket)
		{
			if($Shifter::LockOn != "false")
				remoteweapon_rocket2(%client);
			else
				remoteweapon_rocket3(%client);
		}
		else if(%client.rocket == 1)
			remoteweapon_rocket3(%client);
		else if(%client.rocket == 2)
			remoteweapon_rocket4(%client);
		else
			remoteweapon_rocket1(%client);
	}
	else if(%weapon == "TranqGun")
	{
		if(%client.Tranq == 0 || !%client.Tranq)
			remoteweapon_dart_emp(%client);
		else if(%client.Tranq == 1)
			remoteweapon_dart_flare(%client);
		else
			remoteweapon_dart_regular(%client);
	}
	else if(%weapon == "GravGun")
	{
		if(%client.GravBolt == 0 || !%client.GravBolt)
			remoteweapon_gravgun_repulse(%client);
		else if(%client.GravBolt == 1)
			remoteweapon_gravgun_pull(%client);
		else
		{
//			if(%client.GravADV == "0" || !%client.GravADV)
//				remoteweapon_gravgun_ADV(%client);
//			else
//				remoteweapon_gravgun_norm(%client);
			remoteweapon_gravgun_tract(%client);
		}
	}
	else if(%weapon.description != "false")
		bottomprint(%client,"<f1><jc>The " @ %weapon.description @ " does not have any alternate modes of fire.",5);
}

//==================================================================================== Deployables Functions
function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	%n = Group::objectCount(%set);	
	
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}

	%datab = GameBase::getDataName(Group::getObject(%set,0));
	%obj = (getObjectType(Group::getObject(%set,0)));
	
	if ((%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "AirAmmoBasePad"))
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,1,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,1,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,1,"Unable to deploy - Item in the way");
	
	deleteObject(%set);
	return 0;
}

//======================================= Check For Objects In a Deployables way.
function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("set",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	if (%l && %w && %h)
	{
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}
	else
	{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);	
	}

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != "-1")
		{
			if (getObjectType(%obj) == "Player")
			{
			}
			else
			{
				deleteObject(%set);
				return False;
			}
		}
	}
	deleteObject(%set);
	return True;
}

//===========================================
function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++)
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}
//===========================================
function ixApplyKickback(%player, %strength, %lift) 
{
	if((!%lift) && (%lift != 0))
		%lift = 0;

	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%dir = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

function ixDotProd(%vec, %scalar) 
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta) 
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta) 
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

//---------------------------------------------------------------------------------
// Deployable Box
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 55;    	//Define Max Length of the area
$TurretBoxMaxWidth =  55;    	//Define Max Width of the area
$TurretBoxMaxHeight = 55;    	//Define Max Height of the area

$TurretBoxMinLength = 15;	//Define Min Length from another turret
$TurretBoxMinWidth =  15;	//Define Min Width from another turret
$TurretBoxMinHeight = 15;    	//Define Min Height from another turret

//=============================================================================================== Deployable Functions
// %player  = Player Id doing the deploy
// %item    = Item being deployed
// %type    = Type of item - Turret, StaticShape, Beacon - etc
// %name    = Name of item - Ion Turret
// %angle   = Check angel (to mount on walls, etc.) (True/False/Player) Checks angel - Does Not Check - Uses Players Rotation Reguardless
// %freq    = Check Frequency (True/False) = Too Many Of SAME Type Of Item
// %prox    = Check Proximity (True/False)
// %area    = Check Area (for objects in the way) (True/False)
// %surface = Check Surface Type  (True/False)
// %range   = Max deploy distance from player (number best between 3 and 5) meters from player.
// %limit   = Check limit (True/False)
// %flag    = Give Flag Defence Bonus 0 = None and higher for score ammount.
// %kill    = Count for kills (for turrets)
// %deploy  = The item to be deployed (actualy item data name)
// %count   = What item to count

function deployable(%player,%item,%type,%name,%angle,%freq,%prox,%area,%surface,%range,%limit,%flag, %kill, %deploy, %count)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);
	//in case the player is possessed
	if(%client.possessed) %client = %client.possby;
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);

	if($TeamItemCount[GameBase::getTeam(%player) @ %count] < $TeamItemMax[%count] || !%limit)
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);

			if (%surface)
			{
				if (%obj == "SimTerrain" || %obj == "InteriorShape")
				{
				
				}
				else if (%datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "LargeEmplacementPlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "AirAmmoBasePad")
				{

				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
					return;
				}
			}

			if (%prox)
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
	
				if($MaxNumTurretsInBox > %num)
				{
				}
				else
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
					return;
				}
			}

			if (%freq)
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,($TurretBoxMaxLength/2),($TurretBoxMaxWidth/2),($TurretBoxMaxHeight/2),0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);

				if(%num == 0)
				{
				
				}
				else
				{
					Client::sendMessage(%client,1,"Interference from other remote turrets in the area");
					return;
				}				
			}

//fix to prevent a server from crashing when
//several satchel packs are detonated at the same time

			if (%name == "SatchelPack")
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,25,25,25,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);

				if(%num <= 5)
				{
				
				}
				else
				{
					Client::sendMessage(%client,1,"Too many Satchels nearby, cannot deploy Satchel Pack safely");
					return;
				}				
			}

//fix to stop Laser Airbases
//stolen from Grey's mod
//disabled due to new airbase deploy method, which removes the gap used in making a typical laser airbase
//			if (%name == "Laser Turret")
//			{
//				%posX = getWord(%Pos,0);
//				%posY = getWord(%Pos,1) - 1;
//				%posZ = getWord(%Pos,2);
//				%newpos = %posX @ " " @ %posY @ " " @ %posZ;
//				%set = newObject("laserset",SimSet);
//				%num0 = containerBoxFillSet(%Set, %Mask, %newpos, 1,2,1,0);
//				%num = CountObjects(%set,%deploy,%num0);
//				deleteObject(%set);
//				if(%datab == "LargeAirBasePlatform" || %o.airbase == "true")
//				{
//					if (Vector::dot($los::normal,"0 0 1") > 0.7)
//					{
//						%prot = GameBase::getRotation(%player);
//						%zRot = getWord(%prot,2);
//						if (Vector::dot($los::normal,"0 0 1") > 0.6)
//							%rot = "0 0 " @ %zRot;
//						else if (Vector::dot($los::normal,"0 0 -1") > 0.6)
//							%rot = "3.14159 0 " @ %zRot;
//						else
//							%rot = Vector::getRotation($los::normal);
//					}
//					else
//					{
//						Client::sendMessage(%client,1,"Laser Airbase?  Not only no, but Hell no."); 
//						GameBase::applyDamage(%player, $ImpactDamageType, 5.2, "0 0 0", "0 0 0", "0 0 0", %client);
//
//						return 0;
//					}
//				}
//			}
			if (%angle == "True")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);

					if (Vector::dot($los::normal,"0 0 1") > 0.6)
					{
						%rot = "0 0 " @ %zRot;
					}
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
						{
							%rot = "3.14159 0 " @ %zRot;
						}
						else
						{
							%rot = Vector::getRotation($los::normal);
						}
					}
				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on flat surfaces");
					return 0;
				}
			}
			else if (%angle == "Player")
			{
				%rot = GameBase::getRotation(%player);
			}
			else if (!%angle || %angle == "False")
			{
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);

				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}			
			}



			if (%area)
			{
				if(!checkDeployArea(%client,$los::position))
				{
					return 0;
				}
			}

//Y|yukichigai add-in
//Fix to prevent offensive/base turreting

			if(%type == "Turret" && (String::findSubStr(%name,"Beacon") == -1 || %name == "EMPBeacon") && $Shifter::FairPlay != "false" && %name != "Camera" && %name != "SatchelPack")
			{
				%enemydata = false;
				%friendlydata = false;
				%Set = newObject("FairSet",SimSet); 
				%Pos = $los::position; 
				%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;
				if(%name == "EMPBeacon")
					containerBoxFillSet(%Set, %Mask, %Pos, 36, 36, 36,0);
				else
					containerBoxFillSet(%Set, %Mask, %Pos, 50, 50, 50,0);
				%num = Group::objectCount(%Set);

				for(%i=0; %i < %num; %i++)
				{
					%obj = Group::getObject(%Set, %i);
					%datab = GameBase::getDataName(%obj);
					if(%datab == "InventoryStation" || %datab == "AmmoStation" || (%datab.classname == "Generator" && %datab != "EmplacementGenerator"))
					{
						if((GameBase::getTeam(%obj) != Client::getTeam(%client) && GameBase::getTeam(%obj) != -1 && ($OrigTeam[%obj] == -1 || $OrigTeam[%obj] == "")) || ($OrigTeam[%obj] != Client::getTeam(%client) && $OrigTeam[%obj] != -1 && $OrigTeam[%obj] != ""))
						{
							%enemydata = true;
						}
						if(GameBase::getTeam(%obj) == Client::getTeam(%client))
						{
							%friendlydata = true;
						}
					}
					//=== If we've found sufficient cause to get a solid unshakeable decision, stop checking
					if(%enemydata == true && (%friendlydata == true || %name == "EMPBeacon"))
						break;
				}
				deleteObject(%Set);
				if(%enemydata == true && (%friendlydata != true || %name == "EMPBeacon"))
				{
					Client::sendMessage(%client,1,"Cannot deploy, too close to enemy stations.~waccess_denied.wav");
					return;
				}
			}

			%turret = newObject(%name,%type, %deploy,true);

			if(%name == "JammerBeacon")
			{
				%teleset = nameToID("MissionCleanup/MJammerD");
			
				if(%teleset == -1)
				{
					newObject("MJammerD",SimSet);
					addToSet("MissionCleanup","MJammerD");
					%teleset = nameToID("MissionCleanup/MJammerD");				
				}

				addToSet("MissionCleanup/MJammerD", %turret);
			}

			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;
			
			//echo("MSG: ",%client," deployed a " @ %name);

//			if(%datab == "LargeAirBasePlatform" || %this.airbase == "true")
//			{
//				%turret.airbase = true;
//			}
//			else
//				%turret.airbase = "";

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			else
				Gamebase::setMapName(%turret, %name);

			if (%flagdist < %flag && %flag != 0)
			{
				%client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
				Game::refreshClientScore(%client);
			}

			if ($Shifter::TurretKill && (%kill || %type == "StaticShape" || %name == "EMPBeacon"))
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);

				//=== Turret Tracker.  Doesn't work as slick as I'd like it to, but it will keep the kills where they
				//===  belong for the most part, at least if someone drops and then rejoins
				if($Shifter::TurretTracker != "false")
				{
					if($TurretTrack[Client::getName(%client),0] != "")
					{
						for(%i = 0;$TurretTrack[Client::getName(%client),%i] != ""; %i++)
						{
							if($TurretTrack[Client::getName(%client),%i+1] == "")
							{
								%j = %i+1;
								break;
							}
						}
					}
					else
					{
						%j = 0;
						$TurretTrack[Names,$TurretTrackNames] = Client::getName(%clientId);
						$TurretTrackNames++;
					}
					if($TurretTrack[Client::getName(%client),%j] == "")
					{
						$TurretTrack[Client::getName(%client),%j] = %turret;
					}
				}
				%turret.deployr = %client;
			}
			return %turret;
		}
		else 
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s.");
	return false;
}

//================================================================================================ Deploy Shape
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,5)) { //was 5

			%obj = getObjectType($los::object);
			%datab = GameBase::getDataName($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeAirBasePlatform" || %datab == "LargeEmplacementPlatform" || %datab == "AirAmmoBasePad")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position)) 
					{
						%sensor = newObject("","Sensor",%shape,true);
 	        	  	 		addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
//================================================================================================= Check Item Max

function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

//============================================================================== Return All Items To Zero After Mission
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}
//==============================================================
function Mission::reinitData()
{
	recountitem("DeployableAmmoPack");
	recountitem("DeployableInvPack");
	recountitem("TurretPack");
	recountitem("CameraPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("PulseSensorPack");
	recountitem("MotionSensorPack");
	recountitem("ScoutVehicle");
	recountitem("LAPCVehicle");
	recountitem("HAPCVehicle");
	recountitem("Beacon");
	recountitem("mineammo");
	recountitem("RocketPack");
	recountitem("ForceFieldPack");
	recountitem("LaserPack");
	recountitem("DeployableComPack");
	recountitem("PlasmaTurretPack");
	recountitem("DeployableElf");
	recountitem("DeployableTeleport");
	recountitem("WraithVehicle");
	recountitem("JetVehicle");
	recountitem("BlastWallPack");
	recountitem("BlastFloorPack");
	recountitem("ShockPack");
	recountitem("PlatformPack");
	recountitem("TreePack");
	recountitem("LargeForceFieldPack");
	recountitem("TargetPack");
	recountitem("PlantPack");
	recountitem("hologram");
	recountitem("SatchelPack");
	recountitem("LaunchPack");
	recountitem("proxLaserT");
	recountitem("AccelPPack");
	recountitem("AirAmmoPad");
	recountitem("AirBase");
	recountitem("CoolLauncher");
	recountitem("AOE");
	recountitem("EngBeacons");
	recountitem("TeleBeacons");
	recountitem("EmplacementPack");
	recountitem("LargeShockForceFieldPack");
	recountitem("ShockForceFieldPack");
	recountitem("ArbitorBeaconPack");
	recountitem("EMPBeaconPack");
	recountitem("ShieldBeaconPack");
	recountitem("SuicidePack");
	recountitem("MFGLAmmo");
	recountitem("PowerGeneratorPack");
	recountitem("BarragePack");
	recountitem("ShockFloorPack");
	recountitem("JammerBeaconPack");

	for(%i = 0; %i < 8; %i++) //====== For Guided Missiles // and now Portagens
	{
		$TeamItemCountAOE[%i] = 0;
		$Portagen[%i] = false;
		$Nukecount[%i] = 0;
	}

	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		$EmpTime[%cl] = 0;
		$PoisonTime[%cl] = 0;
		$ShieldTime[%cl] = 0;
		$CloakTime[%cl] = 0;
		$BurnTime[%cl] = 0;
		%cl.obsposs = "";
		%cl.possessed = "";
		%cl.possessing = "";
		%cl.boosted = "";
		%cl.burner = "";
		%cl.EMPMessageTime = 0;
		%cl.gravSource = 0;
		%cl.gravTime = 0;
	}

	for(%i = 0; %i < $TurretTrackNames; %i++)
	{
		%name = $TurretTrack[Names,%i];
		for(%j = 0; $TurretTrack[%name,%j] != ""; %j++)
		{
			$TurretTrack[%name,%j] = "";
		}
		
	}

	$TurretTrackNames = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	if($minhacked != -1 && $maxhacked != -1)
	{
		for(%object = $minHacked; %object <= $maxHacked; %object++)
		{
			$origTeam[%object] = "";
		}
	}

	if($minShielded != -1 && $maxShielded != -1)
	{
		for(%object = $minShielded; %object <= $maxShielded; %object++)
		{
			$OgShieldStrength[%object] = "";
			$ShieldTime[%object] = 0;
			$CloakTime[%object] = 0;
			%object.cloaked = 0;
		}
	}

	$minHacked = -1;
	$maxHacked = -1;
	$minShielded = -1;
	$maxShielded = -1;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 

	//======================= Kill All Mission Varialbles (Global) That are not needed...
	DeleteVariables($funk::var);
}

function telebeacon(%clientId)
{
	%armor = Player::getArmor(%clientId);
	
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","Telebeacon");
	 	addToSet("MissionCleanup", %obj);
	 	%obj.deployer = %clientId;
	 	%clientId.telebeacon = %obj;
		GameBase::throw(%obj,%clientId,15 * %clientId.throwStrength,false);
		%clientId.throwTime = getSimTime() + 0.5;
		GameBase::setTeam (%obj,GameBase::getTeam (%clientId));
		
		$TeamItemCount[GameBase::getTeam(%clientId) @ "TeleBeacons"]++;
	}
}

//========================================================================================================= Scout Stim

function ScoutStim(%clientId, %player, %item)
{
	%armor = Player::getArmor(%player);

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	
	if ($stimTime[%clientId] > 0)
	{
		Client::sendMessage(%clientId,0,"Already Stimmed!");
		if(Player::getMountedItem(%clientId,$Weaponslot) == "LaserRifle")
		{
			%clientId.ovd = %clientId.ovd + floor(getRandom() * 12);
			if($debug) echo("Player " @ Client::getName(%clientId) @ " is using Laser Rifle, adding overdose increase for double beacon use.");
			if(Player::getItemCount(%clientId,AmmoPack) > 0)
			{
				%clientId.ovd = %clientId.ovd + floor(getRandom() * 7);
				if($debug) echo("Player " @ Client::getName(%clientId) @ " has Ammo Pack with Laser Rifle, adding overdose increase.");
			}
		}
		$StimTime[%clientId] = 0;
	}
	else
	{
		if (%armor == "sarmor")
		{
			Player::setArmor(%player,stimarmor);
		}
		else if (%armor == "sfemale")
		{
			Player::setArmor(%player,stimfemale);
		}
		Player::decItemCount(%player, %item);
		Client::sendMessage(%clientId,0,"You used a Stim Pack!");
		$stimTime[%clientId] = 10;
		CheckStim(%clientId, %player);		
	}
}

function OverDoseStim (%clientId, %player)
{
		Client::sendMessage(%clientId,0,"You took a little too much.");
		messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
		$StimTime[%clientId]=0;
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
}

function CheckStim(%clientId, %player)
{

	if($debug) echo ("P- " @ %player @ "");
	if($debug) echo ("Cl- " @ %clientId @ "");
	if($debug) echo ("S- " @ %ClientId.ovd @ "");

	%rnd = floor(getRandom() * 100);

	if($StimTime[%clientId] > 0)
	{
		Player::trigger(%client,$BackpackSlot,false);

		$StimTime[%clientId] -= 2; 
		
		%drrate = GameBase::getDamageLevel(%player) - 0.035; //==== Damage Rate When Stimmed
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 5);

		if(Player::getMountedItem(%clientId,$Weaponslot) == "LaserRifle")
		{
			%clientId.ovd = %clientId.ovd + floor(getRandom() * 10);
			if($debug) echo("Player is using Laser Rifle, doubling OD increase.");
		}

	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);

		if (%rnd > (120 - %clientId.ovd) || %clientId.ovd >= 100)
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId, %player);
			Player::setDamageFlash(%player,0.95);  
		}
		
		
		if  (!Player::isDead(%player)) 
		{  
			Player::setDamageFlash(%player,0.35);  
			GameBase::setDamageLevel(%player, %drrate);
			
			if  (Player::isDead(%player))
			{
				messageall(0, Client::getName(%clientId) @ " overdosed... How sad.");
				%clientId.scoreDeaths++;
      				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$StimTime[%clientId] = 0;
			}

		}
		else
		{
			$StimTime[%clientId] = 0;		
		}
		schedule("CheckStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
   	}
	else
	{
		Client::sendMessage(%clientId,0,"Stim Effect Wears Off.");
		%armor = Player::getArmor(%player);

	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);

		if(%clientId.ovd >= 100 || %rnd > (125 - %clientId.ovd))
		{
			%clientId.ovd = 0;
			OverDoseStim(%clientId,%player);
			Player::setDamageFlash(%player,0.95);
			return;
		}

		if  (!Player::isDead(%player))
		{
			if (%armor == "stimarmor")
			{
				Player::setArmor(%player,sarmor);
				GameBase::setDamageLevel(%player,%clientId.damagelevel);			
			}
			else if (%armor == "stimfemale")
			{
				Player::setArmor(%player,sfemale);
				GameBase::setDamageLevel(%player,%clientId.damagelevel);
			}
		}
	}					
}

//===================================================================================================== Start Shielding

function Renegades_startShield(%clientId, %player)
{
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%armor = Player::getArmor(%player);

	if (%armor == "jarmor")
		%player.shieldStrength = 0.016;
	else
		%player.shieldStrength = 0.006;

	if($shieldTime[%clientId] <= 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else if ($shieldTime[%clientId] <= 40)
		$shieldTime[%clientId] += 20;  // used to just set it to 20
	else
		$shieldTime[%clientId] = 60;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($shieldTime[%clientId] > 0)
	{
		//=== Maintain shielding in Jug when below half health
		if(GameBase::getDamageLevel(%player) < 1.0 || %armor != "jarmor")
			$shieldTime[%clientId] -= 2;  

		if  ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale" || %armor == "jarmor"))
		{
			if  (Player::isDead(%player))
			{
			}
		}
		else
		{
			$shieldTime[%clientId] = 0;
		}
		

		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);	
	}			

		
}

//===================================================================================================== Shieldbeacon Shielding

function Shifter_startShield(%clientId, %player, %chem)
{
	if(%clientId == -1)
		%clientId = %player;

	if($shieldTime[%clientId] == 0)
	{
		if(%clientId != -1 && !%chem && %player != %clientId)
		{
			Client::sendMessage(%clientId,0,"Shielding Activated.");
		}
		//=== What we do if the target is a Turret, Generator or Station
		else if(%player == %clientId)
		{
			if(GameBase::getDamageState(%player) != "Enabled")
				return;

			if($OgShieldstrength[%player] == "" && %player.shieldstrength != 0)
				$OgShieldstrength[%player] = %player.shieldstrength;
			if(%player < $minShielded || $minShielded == -1)
				$minShielded = %player;
			if(%player > $maxShielded || $maxShielded == -1)
				$maxShielded = %player;
		}
		//=== Special code for enemy chems
		if(%chem)
		{
			%player.shieldstrength = 0.012;
			Client::sendMessage(%client,0,"Receiving partial shielding from enemy Shield Beacon.");
		}
		else
			%player.shieldstrength = 0.022;

		$shieldTime[%clientId] = 20;

		if(%clientId != %player)
			GameBase::playSound(%player,ForceFieldOpen,0);

		checkPlayerShield2(%clientId, %player,%chem);
	}
	else if($shieldTime[%clientId] <= 20) //=== Don't wanna accidentally cut the Regeneration Gun shielding down
		$shieldTime[%clientId] = 20;
}


function checkPlayerShield2(%clientId, %player,%chem)
{
	if($shieldTime[%clientId] > 0)
	{
		if(%clientId != %player)
		{
			if($shieldTime[%clientId] == 1)
				Client::sendMessage(%clientId,0,"Shielding wears off in 1 second.~wenergypackon.wav");
			else if($shieldTime[%clientId] <= 3)
				Client::sendMessage(%clientId,0,"Shielding wears off in "@ $shieldTime[%clientId] @" seconds.~wenergypackon.wav");
		}
		$shieldTime[%clientId] -= 1;
		if($shieldTime[%clientId] <= 0)
			$shieldTime[%clientId] = 0;		  

		if(!Player::isDead(%player) && ( (GameBase::getDataName(%player).className != "generator" && GameBase::getDataName(%player).className != "Station") && (GameBase::getDamageState(%player) == "Enabled" && (%player.poweron == "True" || GameBase::isPowered(%player))) || %player != %clientId))
		{
			if(%player.shieldstrength < 0.022 && !%chem)
				%player.shieldstrength = 0.022;
			else if(%player.shieldstrength < 0.012 && %chem)
				%player.shieldstrength = 0.012;
		}
		else
		{
			$shieldTime[%clientId] = 0;
		}
		

		schedule("checkPlayerShield2(" @ %clientId @ ", " @ %player @ "," @ %chem @ ");",1,%player);
    	}
	else
	{
		if(%clientId != %player && !%player.shieldon)
			Client::SendMessage(%clientId,0,"Shielding Inactive.");
		else if(%player.shieldon)
			Client::SendMessage(%clientId,0,"Shieldbeacon shielding inactive, switching to backpack shielding.");

		if($OgShieldStrength[%player] && GameBase::getDamageState(%player) == "Enabled" && %clientId == %player)
			%player.shieldStrength = $OgShieldStrength[%player];
		//=== While it could allow a player with a StealthShield to maintain higher-than-normal shielding
		//===  don't set the shieldstrength to 0 if they have a shield on.
		else if(!%player.shieldon)
			%player.shieldStrength = 0;
		$shieldTime[%clientId] = 0;

		if(%clientId != %player)
			GameBase::playSound(%player,ForceFieldOpen,0);	
	}			

		
}

//=============================================================================== Juggernaught Energy recharge

function JugCharge(%clientId,%player)
{
	%armor = Player::getArmor(%player);
	if(%armor == "jarmor" && $emptime[%clientId] <= 0 && !Player::isTriggered(%player,6))
	{
		if(Player::getMountedItem(%clientId,6) != "EnergyBelt")
			Player::mountItem(%clientId,EnergyBelt,6);
		Player::trigger(%player,6,true);
		Player::decItemCount(%clientId,Beacon);
		schedule("checkJugCharge(" @ %clientId @ ", " @ %player @ ");",5,%player);
		Client::sendMessage(%clientId,1,"Recharge Beacon Activated.  Energy reserves will recharge rapidly for the next 5 seconds.");
	}
	else
	if($emptime[%clientId] > 0)
		Client::sendMessage(%clientId,1,"Electro-Magnetic Interference.  Cannot activate Recharge Beacon.~wfailpack.wav");
}

function checkJugCharge(%clientId,%player)
{
	if($emptime[%clientId] == 0)
	{
		Player::trigger(%player,6,false);
		Client::sendMessage(%clientId,1,"Recharge Beacon Exausted.");
	}
}


//=================================================================================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"Cloaking On");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%player.cloaked = 1;
	
	//Player::setDetectParameters(%player , 50,150);

	%rate = 20;

	if($cloakTime[%clientId] == 0 || !$cloakTime[%clientId])
	{
		%rate = Player::getSensorSupression(%player);
		if(%rate < 0)
			%rate = 0;
		%rate += 20;
		$cloakTime[%clientId] = 20;
		if(Player::getArmor(%player) == "aarmor" || Player::getArmor(%player) == "afemale")
			Cloaker(%player);
		checkPlayerCloak(%clientId, %player);
	}
	else if($cloakTime[%clientId] < 20)
		$cloakTime[%clientId] = 20;

	Player::setSensorSupression(%player,%rate);
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		if($cloakTime[%clientId] == 1)
			Client::sendMessage(%clientId,0,"Cloaking wears off in 1 second.~wenergypackon.wav");
		else if($cloakTime[%clientId] <= 3)
			Client::sendMessage(%clientId,0,"Cloaking wears off in "@ $cloakTime[%clientId] @" seconds.~wenergypackon.wav");

		$cloakTime[%clientId] -= 1;  
		
		if  ((!Player::isDead(%player))) // &&  (%armor == "aarmor" || %armor == "afemale"))
		{
			if($cloakTime[%clientId] < 0)
				$cloakTime[%clientId] = 1;
		
		}
		else
		{
			$cloakTime[%clientId] = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",1,%player);
    	}
	else
	{
		Client::sendMessage(%clientId,0,"Cloaking Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		
		//Player::setDetectParameters(%player , 0.027, 0);

		%player.cloaked = 0;
		$cloakTime[%clientId] = 0;
		Player::setSensorSupression(%player,0);
	}
}


//=================================================================================================== Grav tracker -- for body slams and such
function Shifter_startGravTracker(%player,%client,%timeSlice)
{
	if(Player::isDead(%player))
		return;

	%target = Player::getClient(%player);

	%target.gravSource = %client;

	if(%target.gravTime <= 0)
	{
		%target.gravTime = 2;
		Shifter_checkGravTracker(%player,%target);
	}
	else if(%target.gravTime < 8)
		%target.gravTime += (%timeSlice*5);
}

function Shifter_checkGravTracker(%player,%target)
{
	if(Player::isDead(%player))
		%target.gravTime = 0;

	%target.gravTime -= 1;

	if(%target.gravTime <= 0)
	{
		%target.gravSource = 0;
		%target.gravTime = 0;
	}
	else
	{
		schedule("Shifter_checkGravTracker("@%player@","@%target@");",0.5);
	}
}

//=================================================================================================== Item Cloaking

function Shifter_startCloak(%object)
{
	%object.cloaked = 1;
	
	//Player::setDetectParameters(%player , 50,150);

	if($cloakTime[%object] == 0 || !$cloakTime[%object])
	{
		GameBase::playSound(%object,ForceFieldOpen,0);
		GameBase::startFadeout(%object);
		if(%object < $minShielded || $minShielded == -1)
			$minShielded = %object;
		if(%object > $maxShielded || $maxShielded == -1)
			$maxShielded = %object;

		$cloakTime[%object] = 20;
		checkObjCloak(%object);
	}
	else if($cloakTime[%object] < 20)
		$cloakTime[%object] = 20;
}


function checkObjCloak(%object)
{
	if($cloakTime[%object] > 0)
	{
		$cloakTime[%object] -= 1;  
		schedule("checkObjCloak(" @ %object @ ");",1,%object);
    	}
	else
	{
		GameBase::playSound(%object,ForceFieldOpen,0);
		GameBase::startFadein(%object);
		
		//Player::setDetectParameters(%player , 0.027, 0);

		%object.cloaked = 0;
		$cloakTime[%object] = 0;
	}
}

function Cloaker(%player)  //Grey is a frikkin genius for figuring this shiz out
{
	%cl = Player::getclient(%player);
	%plTeam = GameBase::GetTeam(%player);
	%UserPos = gamebase::getPosition(%player);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%TargetPlayer = Client::getOwnedObject(%clientId);
		if(GameBase::GetTeam(%clientId) != %plTeam)
		{
			%TargetPos = gamebase::getPosition(%TargetPlayer);
			%dist = Vector::getDistance(%UserPos, %TargetPos);
			%matrix = %clientId @ %player;
			if(%dist < 200 && %player.cloaked == 1 && $ArmorName[Player::getArmor(%targetPlayer)] != AlArmor && $ArmorName[Player::getArmor(%player)] == AlArmor) 
			{
				if($cloakEffected[%matrix] != 1)
				{
					Player::setDetectParameters(%Targetplayer, 90, 300);
					$TotalCloaks[%ClientId]++;
					$cloakEffected[%matrix] = 1;
				}
			}
			else
			{
				if($cloakEffected[%matrix] == 1)
					$TotalCloaks[%ClientId]--;
				if($TotalCloaks[%ClientId] < 1)
				{
					Player::setDetectParameters(%Targetplayer, 0.027, 0);
					$cloakEffected[%matrix] = 0;
				}
			}
		}
	}
	if((Player::isTriggered(%player, $BackPackSlot) && Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice") || $cloaktime[%cl]) 
		schedule("Cloaker(" @ %player @ ");", 0.5, %player);
}


//============================================================================================ Eng Missile Lock
function EngMissileLock(%clientId, %player, %item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%client),%item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,1,"Deployable item limit reached for "@ %item.description @".");
		return false;
	}
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
		deleteObject(%set);
		if(!%num)
		{
			%team = GameBase::getTeam(%player);
			
			%teleset = nameToID("MissionCleanup/MJammer");
			
			if(%teleset == -1)
			{
				newObject("MJammer",SimSet);
				addToSet("MissionCleanup","MJammer");
				%teleset = nameToID("MissionCleanup/MJammer");				
			}
			
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
			if (Vector::dot($los::normal,"0 0 1") > 0.6)
			{
				%rot = "0 0 " @ %zRot;
			}
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)
				{
					%rot = "3.14159 0 " @ %zRot;
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}

			%beacon = newObject("Sensor Jammer","Sensor","DeployableSensorJammer",true); //newObject("MJammer Jammer", "StaticShape", "BeaconTwo", true);
			addToSet("MissionCleanup/MJammer", %beacon);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Sensor Jammer");
			Client::sendMessage(%client,0,"Sensor Jammer deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%client),%item]++;
			return true;
		}
		else
			Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

function CheckMissileJammer(%player)
{
	%teleset = nameToID("MissionCleanup/MJammer");
	%teleset2 = nameToID("MissionCleanup/MJammerD");
	%pteam = GameBase::getTeam(%player);

	if ($debug) echo ("checking jammer is set "  @ %teleset);

	for(%i = 0; (%o = Group::getObject(%teleset2, %i)) != -1; %i++)
	{

		%oteam = GameBase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("MissileJammer = ", %o);
		if ($debug) echo ("OTeam " @ %oteam);
		if ($debug) echo ("PPos  " @ %ppos);
		if ($debug) echo ("Opos  " @ %opos);
		if ($debug) echo ("PTeam " @ %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		if ($debug) echo ("Distance " @ %dist);
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			%player.popped = 1;
			return true;
		}
	}
	
	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{

		%oteam = GameBase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("MissileJammer = ", %o);
		if ($debug) echo ("OTeam " @ %oteam);
		if ($debug) echo ("PPos  " @ %ppos);
		if ($debug) echo ("Opos  " @ %opos);
		if ($debug) echo ("PTeam " @ %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		if ($debug) echo ("Distance " @ %dist);
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			%data = GameBase::getDataName(%o);
			if (GameBase::setDamageLevel(%o, %data.maxDamage))
				if ($debug) echo ("BOOM");
			return true;
		}
	}
	return false;
}

//==================================================================================================== Engineer Beacon
function EngBeacon(%clientId, %player, %bec)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
//		%set=newObject("set",SimSet);
//		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
//		deleteObject(%set);
//		if(!%num)
//		{
			%team = GameBase::getTeam(%player);
			%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"Target Beacon");
			Beacon::onEnabled(%beacon);
			Client::sendMessage(%client,0,"Beacon deployed");
			playSound(SoundPickupBackpack,$los::position);
			return true;
//		}
//		else
//			Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
	{
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//==================================================================================================== Engineer Camera

function EngCamera(%clientId, %player, %bec)
{
	%item = "CameraPack";
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,5))  //was 3
		{
			%obj = getObjectType($los::object);
			%name = GameBase::getDataName(%obj);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %name == "DeployablePlatform" || %name == "EmplacementPlatform" || %name == "BlastFloor" || %name == "AirBasePlatform" || %name == "BlastWall")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("Cloaking Camera","Turret",CloakCameraTurret,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Cloaking Camera #"@ $totalNumClCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Cloaking Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Cloaking Camera");
					GameBase::startFadeOut(%camera);
						return true;
				}
			}
			else 
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else 
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
		return false;
}

//==================================================================================================== Sniper Jammer

function SniperJammer(%clientId, %player, %bec)
{
	%item = "DeployableSensorJammerPack";
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else 
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"SensorJammer");
					Client::sendMessage(%client,0,"SensorJammer deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++;
					if($debug) echo("MSG: ",%client," deployed a Sensor Jammer");
					Player::decItemCount(%player,%bec);
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//==================================================================================================== Scout Sensor

function ScoutSensor(%clientId, %player, %bec)
{
	%item = "PulseSensorPack";
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("radar_small","Sensor",DeployablePulseSensor,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Pulse Sensor");
					Client::sendMessage(%client,0,"Pulse Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++;
					if($debug) echo("MSG: ",%client," deployed a Pulse Sensor");
					Player::decItemCount(%player,%bec);
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function getflagtoplayer(%playerId, %dist)
{
	%playerteam = GameBase::getTeam(%playerId);
	%playerpos = GameBase::getPosition(%playerId);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	
	%flagdist = Vector::getDistance(%playerpos,%homepos);  	//== Player To Flag Distance		
	if (%flagdist < %dist)
	{
		return %flagdist;
		if ($debug) echo ("Player " @ %player @ " Is With In " @ %dist @ " Of Thier Own Flag . Dist = " @ %flagdist);
	}

}

function itemFuncs::AmmoBoom(%playerId)
{
	%clientId = player::getclient(%playerId);
	
	%chance = 0;
	%max = getNumItems();
	%armor = Player::getArmor(%playerId);
	%maxcount = 0;
	%k = 0;
	%boom = "BOOM";

	if (%armor == "larmor") 	  {%kval = 200;}
	else if (%armor == "lfemale")	  {%kval = 200;}
	else if (%armor == "marmor")	  {%kval = 500;}
	else if (%armor == "mfemale")	  {%kval = 500;}
	else if (%armor == "earmor") 	  {%kval = 700;}
	else if (%armor == "efemale")	  {%kval = 700;}
	else if (%armor == "spyarmor")    {%kval = 200;}
	else if (%armor == "spyfemale")   {%kval = 200;}
	else if (%armor == "sarmor")	  {%kval = 200;}
	else if (%armor == "sfemale")	  {%kval = 200;}
	else if (%armor == "stimarmor")	  {%kval = 200;}
	else if (%armor == "stimfemale")  {%kval = 200;}
	else if (%armor == "barmor") 	  {%kval = 800;}
	else if (%armor == "bfemale")	  {%kval = 800;}
	else if (%armor == "darmor") 	  {%kval = 900;}
	else if (%armor == "harmor")	  {%kval = 1000;}
	else if (%armor == "aarmor")	  {%kval = 200;}
	else if (%armor == "afemale")	  {%kval = 200;}
	else if (%armor == "dmarmor")	  {%kval = 500;}
	else if (%armor == "dmfemale")    {%kval = 500;}
	else if (%armor == "parmor")      {%kval = 0;}
	else if (%armor == "jarmor")	  {%kval = 1000;}
	
//	for (%i = 0; %i < %max; %i = %i + 1)
	for (%j = 0; %j <= $WeaponAmmt + 3; %j++)
	{
//		%count = Player::getItemCount(%playerId,%i);
//		%itemname = getItemData(%i);
		%itemname = $WeaponAmmo[$WeaponList[%j]];
		if(%j - $WeaponAmmt == 1)
			%itemname = Grenade;
		if(%j - $WeaponAmmt == 2)
			%itemname = mineammo;
		if(%j - $WeaponAmmt == 3)
			%itemname = AutoRocketAmmo;
		if(%itemname != "")
		{
//			echo(%itemname);
			%i = %itemname;
			%count = Player::getItemCount(%playerId,%itemname);

			//=== Because certain situations can produce ammo amounts that are significantly larger than
			//===  the expected max, don't count any ammo above the armor's max ammo (plus ammo pack if appropriate)
			if(%count > $ItemMax[%armor, %itemname])
			{
				if(Player::getItemCount(%playerId, AmmoPack) > 0 && %count > $ItemMax[%armor, %itemname] + $AmmoPackMax[%itemname])
					%count = $AmmoPackMax[%itemname];
				else
					%count = 0;

				%count += $ItemMax[%armor, %itemname];
			}

			%rnd = (floor (getRandom() * 300)+1);


			if (%itemname == "Grenade") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;}}		
			else if (%itemname == "mineammo") {%mod = (5*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
			else if (%itemname == "RocketAmmo") {%mod = (4*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "RegStingerMissile " @ %i;%k++;}}
			else if (%itemname == "BulletAmmo") {%mod = (0.1*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "ChaingunBullet " @ %i;%k++;}}
			else if (%itemname == "VulcanAmmo") {%mod = (0.15*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "VulcanBullet " @ %i;%k++;}}
			else if (%itemname == "GrenadeAmmo") {%mod = (3*%count); if(%armor == "darmor")%mod = (2*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "GrenadeShell " @ %i;%k++;}}
			else if (%itemname == "MortarAmmo") { %mod = (12*%count); %chance = %chance + %mod; if (%rnd - %mod < 0) { %boom[%k] = "MortarShell " @ %i; %k++; } }
			else if (%itemname == "MfglAmmo") {%mod = (75*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "FgcShell2 " @ %i;%k++;}}
			else if (%itemname == "PlasmaAmmo") {%mod = (2*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "PlasmaBolt " @ %i;%k++;}}
			else if (%itemname == "DiscAmmo") {%mod = (3*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "DiscShell2 " @ %i;%k++;}}
			else if (%itemname == "AutoRocketAmmo") {%mod = (10*%count);%chance = %chance + %mod; if (%rnd - %mod < 0){%boom[%k] = "StingerMissile " @ %i;%k++;}}
//			echo("chance " @ %chance);
//			echo("boomk " @ %boom[%k]);
		}
	}
	if(%armor == "aarmor" || %armor == "afemale")
	{
		%mod = (0.7*GameBase::getEnergy(%playerId));
		%chance = %chance + %mod;
		if(%rnd < %mod)
		{
			%boom[%k] = "IonBolt Energy";
		}
	}

	%rnd = (floor (getRandom() * %kval));
	%dif = (%rnd - %chance);
//	echo("diff " @ %dif);
	%pos = (gamebase::getposition(%playerId));
	
	if (%dif < 0 && getflagtoplayer(%playerId) > 150)
	{

		for (%k = 0; %boom[%k] != ""; %k++)
		{
			%blammo = %boom[%k];
			
			%cnt = getWord(%blammo, 1);
			%thing = %cnt;
			
//			if (getItemData(%cnt) == "MfglAmmo")
			if(%cnt == "MfglAmmo")
				%cnt = Player::getItemCount(%playerId,%cnt) + 1;
			else if(%cnt == "Energy")
				%cnt = floor(GameBase::GetEnergy(%player) / 4);
			else
				%cnt = floor(Player::getItemCount(%playerId,%cnt) / 2.5);

			if(%cnt > $ItemMax[%armor, %thing] / 2.5)
			{
				if(Player::getItemCount(%playerId, AmmoPack) > 0 && %cnt > ($ItemMax[%armor, %thing] + $AmmoPackMax[%thing])/2.5)
					%cnt = $AmmoPackMax[%thing];
				else
					%cnt = 0;

				%cnt += $ItemMax[%armor, %thing];
				%cnt *= 1/2.5;
			}		

			%cnt = (floor(getRandom() * %cnt));
		
			%blammo = getword(%blammo, 0);

//			echo("%blammo " @ %blammo @ " count " @ %cnt);
			for (%j=0; %j < %cnt; %j++)
			{
				%neg1 = (floor(getRandom() * 2) * -2) + 1;
				%neg2 = (floor(getRandom() * 2) * -2) + 1;
				%neg3 = (floor(getRandom() * 2) * -2) + 1;	
				%dir = (getRandom() * %neg2 @ " " @ getRandom() * %neg1 @ " " @ getRandom() * %neg3);
				%dir1 = (getRandom() * %neg3 @ " " @ getRandom() * %neg2 @ " " @ getRandom() * %neg1);
				%dir2 = (getRandom() * %neg1 @ " " @ getRandom() * %neg2 @ " " @ getRandom() * %neg3);
				%fired = Projectile::spawnProjectile(%blammo,(%dir @ " " @ %dir1 @ " " @ %dir2 @ " " @ %pos),%playerId,"0 0 0");
				%fired.deployer = %clientId;
			}
		}
	}
}

function Mine::Detonate(%this)
{
	%client = %this.deployer;
	%player = client::getownedobject(%client);

	Client::setOwnedObject(%client, %this);
	Client::setOwnedObject(%client, %player);
	
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}
