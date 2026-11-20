//=============Functions used in ShifterTW / X==================
// New functions - external file. Formerly lofnfunc.cs.
// These don't replace anything in the MOD, they are all new

//Make sure the station time is a multiple of 5
if ($insomniax::stationtime < 0) $insomniax::stationtime = 0;
else if ($insomniax::stationtime > 3600) $insomniax::stationtime = 3600;

$insomniax::stationtime = floor($insomniax::stationtime);
while ($insomniax::stationtime / 5 != floor($insomniax::stationtime / 5))
	$insomniax::stationtime++;

function ixCheckStationEject(%player, %station, %stat, %count)
{
	if((%player.inStation) && (%player.inStation == %station) && (%stat == %player.stationAccess))
	{
		if(%count)
		{
			if(%count == 1)
				Client::sendMessage(GameBase::getOwnerClient(%player),1,"You will be Ejected from the station in 5 Seconds.~waccess_denied.wav");
			schedule("ixCheckStationEject(" @ %player @ "," @ %station @ "," @ %stat @ "," @ %count - 1 @ ");",5,%player);
			if ($TeamEnergy[Client::getTeam(%client)] == "Infinite") Client::setInventoryText(GameBase::getOwnerClient(%player), "<f2><jc>STATION TIME REMAINING: <f0>" @ %count * 5);
		}
		else
		{
			Client::sendMessage(GameBase::getOwnerClient(%player),1,"You have been Ejected from the Station to give others access to it.~waccess_denied.wav");
			Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%client)]);
			ixStationEjectPlayer(%station, %player);
		}
	}
}

function showInfoLine(%clientId)
{
	remoteEval(%clientId, "setInfoLine", 1, $Server::Hostname);
	remoteEval(%clientId, "setInfoLine", 2, "You're playing ShifterX, by [*HF] Lofar");
	remoteEval(%clientId, "setInfoLine", 3, "Only at HomeLAN - www.homelanfed.com");
	remoteEval(%clientId, "setInfoLine", 4, "Thanks to HomeLAN, the beta testers, Emo1313, and Dynamix.");

	if (%clientid % 5 == 0) {
		remoteEval(%clientId, "setInfoLine", 5, " ShifterX - Grabbing life by the disc since 2000");
		remoteEval(%clientId, "setInfoLine", 6, " www.homelanfed.com/shifterx");

	} else if (%clientid % 4 == 0) {
		remoteEval(%clientId, "setInfoLine", 5, " ShifterX - The \"X\" stands for \"Awesome\"!");
		remoteEval(%clientId, "setInfoLine", 6, " www.homelanfed.com/shifterx");

	} else if (%clientid % 3 == 0) {
		remoteEval(%clientId, "setInfoLine", 5, " Shifter X - Why Willy Wonka owned that really creapy boat");
		remoteEval(%clientId, "setInfoLine", 6, " www.homelanfed.com/shifterx");

	} else if (%clientid % 2 == 0) {
		remoteEval(%clientId, "setInfoLine", 5, " Shifter X - The only game without a Desert Eagle");
		remoteEval(%clientId, "setInfoLine", 6, " www.homelanfed.com/shifterx");

	} else {
		remoteEval(%clientId, "setInfoLine", 5, " ShifterX - Sign up for the official league at:");
		remoteEval(%clientId, "setInfoLine", 6, " www.homelanfed.com/shifterx");
	}
}

function ixStationEjectPlayer(%station, %player)
{
	%rot = GameBase::getRotation(%station);
	%rad = getWord(%rot, 2);
//	%x = (-1) * (ixSin(%rad));
//	%y = ixCos(%rad);
	%x = (-1) * (Sin(%rad));
	%y = Cos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),10);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%vel = %x @ " " @ %y @ " " @ 15;
	Item::setVelocity(%player,%vel);
}

function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}	

function Vehicle::TestArmor(%this, %object)
{
 %armor = Player::getArmor(%object);
 %client = Player::getClient(%object);
 if (Player::getMountObject(%client) == -1) return;
 if (!(%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "sfemale" || %armor == "spyarmor" || %armor == "spyfemale"))
 {
  Vehicle::dismount(%this, GameBase::getRotation(%client));
  Client::sendMessage(%client,1,"Cheating gets you nowhere!");
 }
}

//This is cool. Get the player's weapon, and if its got toggleable features, remoteeval it for them
function remoteWeaponSettings(%player)
{
	%wep = Player::getMountedItem(%player, $weaponslot);

	if (%wep == "Mortar")
	{
		if (%player.mortar == 0) remoteSetMortar(%player, 1);
		else if (%player.mortar == 1) remoteSetMortar(%player, 2);
		else remoteSetMortar(%player, 0);
	}
	else if (%wep == "PlasmaGun")
	{
		if (%player.plasma == 0) remoteSetPlasma(%player, 1);
		else if (%player.plasma == 1) remoteSetPlasma(%player, 2);
		else remoteSetPlasma(%player, 0);
	}
	else if (%wep == "GravGun")
	{
		if (%player.gravgun == 1) remoteSetGravGun(%player, 0);
		else remoteSetGravGun(%player, 1);
	}
	else if ((%wep == "Fixit") || (%wep == "Disit") || (%wep == "Hackit")) remoteSetEngGun(%player, 3);
	else bottomprint(%player, "<jc><f1>No weapon options to set for this weapon.", 5);
}

//Code from the good old days. Use remote Evals to set your prefs.

function remoteSetMortar(%player, %to)
{
 %to = floor(%to);
 if ((%to > -1) && (%to < 3))
 {
  %player.mortar = %to;
  if (%to == 0) bottomprint(%player, "<jc><f1>Mortar set to<f2> Standard", 7);
  else if (%to == 1) bottomprint(%player, "<jc><f1>Mortar set to<f2> EMP", 7);
  else if (%to == 2) bottomprint(%player, "<jc><f1>Mortar set to<f2> Frag", 7);
 }
}

function remoteSetPlasma(%player, %to)
{
 %to = floor(%to);
 if ((%to > -1) && (%to < 3))
 {
  %player.plasma = %to;
  if (%to == 0) bottomprint(%player, "<jc><f1>Plasma set to<f2> Standard", 7);
  else if (%to == 1) bottomprint(%player, "<jc><f1>Plasma set to<f2> Rapid", 7);
  else if (%to == 2) bottomprint(%player, "<jc><f1>Plasma set to<f2> Multi-Shot", 7);
 }
}

function remoteSetGravGun(%player, %to)
{
 %to = floor(%to);
 if ((%to == 0) || (%to == 1))
 {
  %player.gravgun = %to;
  if (%to == 0) bottomprint(%player, "<jc><f1>GravGun set to<f2> Tractor", 7);
  else bottomprint(%player, "<jc><f1>GravGun set to<f2> Repulse", 7);
 }
}

function remoteSetEngGun(%clientId, %to)
{
	if (!(Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt) || Player::getItemCount(%clientId, HackIt)))
	{
		bottomprint(%clientId, "<jc><f1>You don't have an Engineer Gun silly!", 7);
		return;
	}

	%to = floor(%to);
	if (%to < 0) %to = 0;
	else if (%to > 3) %to = 3;

	if ((%to == 0) || (Player::getItemCount(%clientId, HackIt) || Player::getItemCount(%clientId, DisIt)))
	{
		%clientId.Eng = 0;		
		Player::setItemCount(%clientId, Fixit , 1);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::mountItem(%clientId, Fixit, $WeaponSlot);		
		bottomprint(%clientId, "<jc><f1>Engineer Gun set to <f2>Repair Gun<f1>.", 7);
	}
	else if ((%to == 1) || (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, DisIt)))
	{
		%clientId.Eng = 1;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, Hackit, 1);
		Player::setItemCount(%clientId, DisIt, 0);
		Player::mountItem(%clientId, HackIt, $WeaponSlot);
		bottomprint(%clientId, "<jc><f1>Engineer Gun set to <f2>Hacking Tool<f1>.", 7);
	}
	else if ((%to == 2) || (Player::getItemCount(%clientId, FixIt) || Player::getItemCount(%clientId, HackIt)))
	{
		%clientId.Eng = 2;
		Player::setItemCount(%clientId, Fixit, 0);
		Player::setItemCount(%clientId, Hackit, 0);
		Player::setItemCount(%clientId, DisIt, 1);
		Player::mountItem(%clientId, DisIt, $WeaponSlot);
		bottomprint(%clientId, "<jc><f1>Engineer Gun set to <f2>Dissembler<f1>.", 7);
	}
}

function remoteSetEngMine(%player, %to)
{
 %to = floor(%to);
 if ((%to > 0) && (%to < 4))
 {
  %player.engmine = %to;
  if (%to == 1) bottomprint(%player, "<jc><f1>Engineer Mine set to<f2> Cloaking Mine", 7);
  else if (%to == 2) bottomprint(%player, "<jc><f1>Engineer Mine set to<f2> Laser Mine", 7);
  else if (%to == 3) bottomprint(%player, "<jc><f1>Engineer Mine set to<f2> Standard Mine", 7);
 }
}

function remoteSetPlastic(%player, %to)
{
 %to = floor(%to);
 if ((%to > 2) && (%to < 51))
 {
  %player.plastic = %to;
  bottomprint(%player, "<jc><f1>Plastique Explosive timing set to <f2>" @ %to @ "<f1> seconds.", 7);
 }
}

function BoostPlayer(%player)
{
	%trans=GameBase::getMuzzleTransform(%player);
	%vec=GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
	%rot=Vector::add(Vector::getRotation(%vec), "1.571 0 0");
	%vec=Vector::getFromRot(%rot, 550, 0);
	Player::applyImpulse(%player,%vec);
	playSound(shockExplosion,gamebase::getposition(%player));
	GameBase::setDamageLevel(%player, GameBase::getDamageLevel(%player) + 0.09);
	Player::setDamageFlash(%player,0.15);
}

function KnockbackPlayer(%player)
{
	%trans=GameBase::getMuzzleTransform(%player);
	%vec=GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
	%rot=Vector::add(Vector::getRotation(%vec), "-1.571 0 0");
	%vec=Vector::getFromRot(%rot, 200, 0);
	Player::applyImpulse(%player,%vec);
	Player::setDamageFlash(%player,0.15);
}

function remoteAdminInfo(%client)
{
	if (!%client.observerMode) return;
	bottomprint(%client, "<jc>Observing " @ Client::getName(%client.observerTarget), 15);
}

// Based on (read: mostly) Zear's String replace function
function String::replace(%string, %search, %replace)
{
    if(%search == %replace || String::findSubStr(%replace, %search) != -1) return %string;
        
    while((%idx = String::findSubStr(%string, %search)) != -1)             
    {   
        %front = String::getSubStr(%string, 0, %idx);
        %idx += String::len(%search);
        %back = String::getSubStr(%string, %idx, String::len(%string) - %idx);
        %string = %front @ %replace @ %back;
    }
    return %string; 
}

function NameToSafeFileName(%name)
{
 %name = String::replace(%name, "\\", "_");
 %name = String::replace(%name, "/", "_");
 %name = String::replace(%name, "*", "_");
 %name = String::replace(%name, "?", "_");
 %name = String::replace(%name, "\"", "_");
 %name = String::replace(%name, "|", "_");
 %name = String::replace(%name, "<", "_");
 %name = String::replace(%name, ">", "_");
 return %name;
}

function LoadClientData(%client)
{
 %name = Client::GetName(%client);
 echo("Loading personal settings for " @ %name @ "...");
 exec("xPlayerSave_" @ NameToSafeFileName(%name) @ ".cs");

 $SavedPlayerData[%name, "greeting"] = $SavedPlayerDataT["greeting"];
// $SavedPlayerData[%name, "WeaponSet_EngMine"] = $SavedPlayerDataT["WeaponSet_EngMine"];
// $SavedPlayerData[%name, "WeaponSet_Plastic"] = $SavedPlayerDataT["WeaponSet_Plastic"];
// $SavedPlayerData[%name, "WeaponSet_Mortar"] = $SavedPlayerDataT["WeaponSet_Mortar"];
// $SavedPlayerData[%name, "WeaponSet_Plasma"] = $SavedPlayerDataT["WeaponSet_Plasma"];
// $SavedPlayerData[%name, "WeaponSet_LasMortar"] = $SavedPlayerDataT["WeaponSet_LasMortar"];
// $SavedPlayerData[%name, "WeaponSet_GravBolt"] = $SavedPlayerDataT["WeaponSet_GravBolt"];

 if ($SavedPlayerData[%name, "greeting"] != "")
 {
  schedule(String::replace($SavedPlayerData[%name, "greeting"], "%client", %client), 0.1);
  // $SavedPlayerInfo[%name, "greeting"] = "";
 }

 // Saved weapon settings
 if ($SavedPlayerDataT["WeaponSet_EngMine"] != "")
 {
  %client.EngMine = $SavedPlayerDataT["WeaponSet_EngMine"];
 }

 if ($SavedPlayerDataT["WeaponSet_Plastic"] != "")
 {
  %client.Plastic = $SavedPlayerDataT["WeaponSet_Plastic"];
 }

 if ($SavedPlayerDataT["WeaponSet_Mortar"] != "")
 {
  %client.Mortar = $SavedPlayerDataT["WeaponSet_Mortar"];
 }

 if ($SavedPlayerDataT["WeaponSet_Plasma"] != "")
 {
  %client.Plasma = $SavedPlayerDataT["WeaponSet_Plasma"];
 }

 if ($SavedPlayerDataT["WeaponSet_LasMortar"] != "")
 {
  %client.LasMortar = $SavedPlayerDataT["WeaponSet_LasMortar"];
 }

 if ($SavedPlayerDataT["WeaponSet_GravBolt"] != "")
 {
  %client.GravBolt = $SavedPlayerDataT["WeaponSet_GravBolt"];
 }

 $SavedPlayerDataT["greeting"] = "";
 $SavedPlayerDataT["WeaponSet_EngMine"]= "";
 $SavedPlayerDataT["WeaponSet_Plastic"]= "";
 $SavedPlayerDataT["WeaponSet_Mortar"]= "";
 $SavedPlayerDataT["WeaponSet_Plasma"]= "";
 $SavedPlayerDataT["WeaponSet_LasMortar"]= "";
 $SavedPlayerDataT["WeaponSet_GravBolt"]= "";

 Client::sendMessage(%client, 0, "Your weapon settings have been restored from your last game.");
}

function StoreClientData(%client)
{
 %name = Client::GetName(%client);
 echo("Saving personal settings for " @ %name @ "...");

 $SavedPlayerDataT["greeting"] = $SavedPlayerData[%name, "greeting"];
 $SavedPlayerDataT["WeaponSet_EngMine"] = %client.EngMine;
 $SavedPlayerDataT["WeaponSet_Plastic"] = %client.Plastic;
 $SavedPlayerDataT["WeaponSet_Mortar"] = %client.Mortar;
 $SavedPlayerDataT["WeaponSet_Plasma"] = %client.Plasma;
 $SavedPlayerDataT["WeaponSet_LasMortar"] = %client.LasMortar;
 $SavedPlayerDataT["WeaponSet_GravBolt"] = %client.GravBolt;

 export("$SavedPlayerDataT*", "config\\xPlayerSave_" @ NameToSafeFileName(%name) @ ".cs", False); // Don't append

 $SavedPlayerDataT["greeting"] = "";
 $SavedPlayerDataT["WeaponSet_EngMine"]= "";
 $SavedPlayerDataT["WeaponSet_Plastic"]= "";
 $SavedPlayerDataT["WeaponSet_Mortar"]= "";
 $SavedPlayerDataT["WeaponSet_Plasma"]= "";
 $SavedPlayerDataT["WeaponSet_LasMortar"]= "";
 $SavedPlayerDataT["WeaponSet_GravBolt"]= "";
}