
//============================ Functions For Beacons and Other Ammos and Items ===============================
//
// Holds functions for varrious items in the game, including cloaking and stim, as well as varrious beacons 
// and other stuff. All are special functions specific to a given item.
//
//==================================================================================================== Det.Bug

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
	%shape == "vehi_pur_poles")
	{
		return 0;
	}

	return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if ($debug) echo  ("Hacking");
	
	if(%time > 0)
	{
		if($hacking[%client] == "true")
		{		
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "','" @ %pName @ "','" @ %tName @ "','" @ %name @ "','" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
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
				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection, from hacking.");
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
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						echo (%player);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else
					{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				
				if(%name == "False" && %shape == "magcargo")
				{

					%rnd = floor(getRandom() * 10);
					if(%rnd == 1)
					{	
					    Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						Mine::Detonate(" @ %this @ ");
						return;
					}
					else
					{	
					    Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}


				}
				else
				{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					if($Shifter::HackedTime)
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
					}
					else
					{
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "120");
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

//==================================================================================== Deployables Functions
function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	
	deleteObject(%set);
	return 0;
}

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

//=============================================================================================== Deployable Functions
//== Use this function to deploy turrets
//== Read the function heading for instructions
//
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
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%obj = getObjectType($los::object);
			if ((%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") || !%surface)
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
				
				if($MaxNumTurretsInBox > %num || !%prox)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,%deploy,%num);
					deleteObject(%set);
					
					if(0 == %num || !%freq)
					{
						echo ("Angle " @ Vector::dot($los::normal,"0 0 1"));
						if (%angle == "True")
						{
							echo ("Angle True");
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
							echo ("Angle Player");
							%rot = GameBase::getRotation(%player);
						}
						else if (!%angle || %angle == "False")
						{
							echo ("Angle False");
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

						%turret = newObject(%name,%type, %deploy,true);
						addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						
						if (%type == "Turret")
							Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
						else
							Gamebase::setMapName(%turret, %name);
						
						
						Client::sendMessage(%client,0,"" @ %name @ " deployed");
						GameBase::startFadeIn(%turret);
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;
						echo("MSG: ",%client," deployed a " @ %name);

						if (%flagdist < %flag && %flag != 0)
						{
							%client.score = %client.score + $Score::FlagDef;
							if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
							Game::refreshClientScore(%client);
						}

						if ($Shifter::TurretKill && %kill)
						{
							Client::setOwnedObject(%client, %turret);
							Client::setOwnedObject(%client, %player);
						}
						return true;

					} 
					else
						Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
				}
			   	else 
					Client::sendMessage(%client,1,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,1,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//================================================================================================ Deploy Shape
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) {

			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
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
function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor]) {
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "") {
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum) {
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon) {
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}

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
	recountitem("PlasmaTurretPack");
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
	recountitem("ArbitorBeaconPack");
	recountitem("EMPBeaconPack");


	if ($Shifter::PlugIns)
		exec ("missionend");

	for(%i = 0; %i < 8; %i++) //====== For Guided Missiles
	{
		$TeamItemCountAOE[%i] = 0;
	}
	
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

function telebeacon(%clientId)
{
	%armor = Player::getArmor(%clientId);
	echo (%clientId @ " Used TeleBeacon");
	
	if (%armor == "aarmor" || %armor == "afemale")
	{
		%obj = newObject("","Mine","Telebeacon");
	 	addToSet("MissionCleanup", %obj);
	 	
	 	%obj.deployer = %clientId;
		
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
		$StimTime[%clientId]=0;
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

	if($StimTime[%clientId] > 0)
	{
		$StimTime[%clientId] -= 2; 
		
		%drrate = GameBase::getDamageLevel(%player) - 0.035; //==== Damage Rate When Stimmed
		%clientId.damagelevel = %drrate;
		GameBase::setDamageLevel(%player,%drrate);
		
		if ($Debug) echo("DR " @ %drrate @ "");
		if ($Debug) echo("ID " @ %clientId @ "");
		if ($Debug) echo("PL " @ %player @ "");
		
		%clientId.ovd = %clientId.ovd + floor(getRandom() * 10);
	        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Increased By " @ %clientId.ovd @ "%.", 2);
		%rnd = floor(getRandom() * 100);

		if (%rnd > (150 - %clientId.ovd))
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

	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}


function checkPlayerShield(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($shieldTime[%clientId] > 0)
	{
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

//=================================================================================================== Start Cloaking

function Renegades_startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"Cloaking On");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);

	if($cloakTime[%clientId] == 0)
	{
		$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else
		$cloakTime[%clientId] = 20;
}


function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if($cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;  
		
		if  ((!Player::isDead(%player)) &&  (%armor == "aarmor" || %armor == "afemale"))
		{
		
		}
		else
		{
			$cloakTime[%clientId] = 0;
		}
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
    	}
	else
	{
		Client::sendMessage(%clientId,0,"Cloaking Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
	
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

//==================================================================================================== Satchel Deploy
	
function DeploySatchel(	%clientId, %player, %bec)
{
	%item = "SatchelPack";
	deployable(%player,%item,"Turret","Satchel",False,False,False,False,True,5,True,0, False, "DeployableSatchel", %item);
}

//============================================================================================== Engineer TeleDisruptor
function EngTeleDisruptor(%clientId, %player, %item)
{
	%client = Player::getClient(%player);

	%obj = getObjectType($los::object);
	%set=newObject("set",SimSet);

	%team = GameBase::getTeam(%player);

	%teleset = nameToID("MissionCleanup/TeleJammer");

	if(%teleset == -1)
	{
		newObject("TeleJammer",SimSet);
		addToSet("MissionCleanup","TeleJammer");
		%teleset = nameToID("MissionCleanup/TeleJammer");				
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
		else
		{
			%rot = Vector::getRotation($los::normal);
		}
	}

	%beacon = newObject("TelePoint Jammer", "StaticShape", "BeaconTwo", true);
	addToSet("MissionCleanup/TeleJammer", %beacon);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,GameBase::GetPosition(%player));
	Gamebase::setMapName(%beacon,"TeleJammer");
	Client::sendMessage(%client,0,"TelePoint Disruptor deployed");
	playSound(SoundPickupBackpack,$los::position);
	return true;
	return false;
}

//============================================================================================ Eng Missile Lock
function EngMissileLock(%clientId, %player, %item)
{
	%client = Player::getClient(%player);
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

			%beacon = newObject("MJammer Jammer", "StaticShape", "BeaconTwo", true);
			addToSet("MissionCleanup/MJammer", %beacon);
			addToSet("MissionCleanup", %beacon);
			GameBase::setTeam(%beacon,GameBase::getTeam(%player));
			GameBase::setRotation(%beacon,%rot);
			GameBase::setPosition(%beacon,$los::position);
			Gamebase::setMapName(%beacon,"MJammer");
			Client::sendMessage(%client,0,"MJammer Disruptor deployed");
			playSound(SoundPickupBackpack,$los::position);
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
	%pteam = GameBase::getTeam(%player);

	if ($debug) echo ("checking jammer is set "  @ %teleset);
	
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
function CheckTeleJammer(%player)
{
	%teleset = nameToID("MissionCleanup/TeleJammer");
	%pteam = Gamebase::getTeam(%player);

	for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		%oteam = Gamebase::getTeam(%o);
		%ppos = GameBase::getPosition(%player);
		%opos = GameBase::getPosition(%o);

		if ($Debug) echo ("Tele Jammer Number  = ", %o);
		if ($Debug) echo ("Tele Jammer Team    = ", %oteam);
		if ($Debug) echo ("Players Team        = ", %pteam);
		
		%dist = Vector::getDistance(%ppos,%opos);  	//== Player To Jammer Distance		
		
		if (%dist < 125 && %pteam != %oteam)
		{
			if ($Debug) echo ("Jammed");
			bottomprint(%client, "<jc><f2>Lock Failed, You are being JAMMED! 125m From Jammer Required!.", 2);
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
		%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
		deleteObject(%set);
		if(!%num)
		{
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


//==================================================================================================== Engineer Camera

function EngCamera(%clientId, %player, %bec)
{
	%item = "CameraPack";
	%client = Player::getClient(%player);
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
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($debug) echo("MSG: ",%client," deployed a Camera");
					Player::decItemCount(%player,%bec);
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
	%playerteam = Client::getTeam(%playerId);
	%playerpos = GameBase::getPosition(%playerId);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	
	%flagdist = Vector::getDistance(%playerpos,%homepos);  	//== Player To Flag Distance		

	echo ("PT " @ %playerteam);
	echo ("PP " @ %playerpos);
	echo ("HP " @ %homepos);
	echo ("FD " @ %flagdist);

	if (%flagdist < %dist)
	{
		return %flagdist;
		if ($debug) echo ("Player " @ %player @ " Is With In " @ %dist @ " Of Thier Own Flag . Dist = " @ %flagdist);
	}

}

