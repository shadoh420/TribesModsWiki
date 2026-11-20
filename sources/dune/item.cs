//----------------------------------------------------------------------------

$ItemFavoritesKey = "DUNE";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Knife] = False;
$AutoUse[Knife2] = False;
$AutoUse[SlipTip] = False;
$AutoUse[Crysknife] = False;
$AutoUse[Kindjal] = False;
$AutoUse[Rapier] = False;
$AutoUse[Saber] = False;
$AutoUse[Pistol] = False;
$AutoUse[Maula] = False;
$AutoUse[Stunner] = False;
$AutoUse[Rifle] = False;
$AutoUse[MGun] = False;
$AutoUse[MGun2] = False;
$AutoUse[SniperRifle] = False;
$AutoUse[RLauncher] = False;
$AutoUse[Flamethrower] = False;
$AutoUse[Piller] = False;
$AutoUse[Cutteray] = False;
$AutoUse[SmallLas] = False;
$AutoUse[RifleLas] = False;
$AutoUse[HeavyLas] = False;
$AutoUse[MountedArtillaryGun] = True;
$AutoUse[MountedMachineGun] = True;

$WeapThrowCTH[knife] = 100;
$WeapThrowCTH[knife2] = 100;
$WeapThrowCTH[sliptip] = 80;
$WeapThrowCTH[crysknife] = 80;
$WeapThrowCTH[kindjal] = 70;
$WeapThrowCTH[Rapier] = 30;
$WeapThrowCTH[saber] = 50;


$ArmorType[Male, SoldierArmor] = sarmor;
$ArmorType[Male, TrooperArmor] = tarmor;
$ArmorType[Male, FremenArmor] = farmor;
$ArmorType[Male, FedaykinArmor] = ffarmor;
$ArmorType[Male, SardaukarArmor] = ssarmor;
$ArmorType[Male, BasharArmor] = barmor;
$ArmorType[Male, BursegArmor] = bbarmor;
$ArmorType[Male, FaceDancerArmor] = fdarmor;
$ArmorType[Female, SoldierArmor] = sfemale;
$ArmorType[Female, TrooperArmor] = tfemale;
$ArmorType[Female, FremenArmor] = ffemale;
$ArmorType[Female, FedaykinArmor] = fffemale;
$ArmorType[Female, SardaukarArmor] = ssfemale;
$ArmorType[Female, BasharArmor] = bfemale;
$ArmorType[Female, BursegArmor] = bbfemale;
$ArmorType[Female, FaceDancerArmor] = fdfemale;


$ArmorName[sarmor] = SoldierArmor;
$ArmorName[tarmor] = TrooperArmor;
$ArmorName[farmor] = FremenArmor;
$ArmorName[ffarmor] = FedaykinArmor;
$ArmorName[ssarmor] = SardaukarArmor;
$ArmorName[barmor] = BasharArmor;
$ArmorName[bbarmor] = BursegArmor;
$ArmorName[fdarmor] = FaceDancerArmor;

$ArmorName[sarmor2] = SoldierArmor;
$ArmorName[ssarmor2] = SardaukarArmor;
$ArmorName[barmor2] = BasharArmor;
$ArmorName[bbarmor2] = BursegArmor;


$ArmorName[sfemale] = SoldierArmor;
$ArmorName[tfemale] = TrooperArmor;
$ArmorName[ffemale] = FremenArmor;
$ArmorName[fffemale] = FedaykinArmor;
$ArmorName[ssfemale] = SardaukarArmor;
$ArmorName[bfemale] = BasharArmor;
$ArmorName[bbfemale] = BursegArmor;
$ArmorName[fdfemale] = FaceDancerArmor;

$ArmorName[sfemale2] = SoldierArmor;
$ArmorName[ssfemale2] = SardaukarArmor;
$ArmorName[bfemale2] = BasharArmor;
$ArmorName[bbfemale2] = BursegArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[PistolAmmo] = 0;//15;
$SellAmmo[MaulaAmmo] = 0;//5;
$SellAmmo[StunnerAmmo] = 0;//5;
$SellAmmo[RifleAmmo] = 0;//30;
$SellAmmo[MGunAmmo] = 0;//40;
$SellAmmo[SniperAmmo] = 0;//1;
$SellAmmo[RLauncherAmmo] = 0;//1;
$SellAmmo[FlamethrowerAmmo] = 0;//25;
$SellAmmo[PillerAmmo] = 0;//1;
$SellAmmo[CutterayAmmo] = 0;//25;
$SellAmmo[SmallLasAmmo] = 0;//25;
$SellAmmo[RifleLasAmmo] = 0;//25;
$SellAmmo[HeavyLasAmmo] = 0;//5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[PistolClip] = 2; //-Modified for Clips instead of Ammo
$AmmoPackMax[MaulaClip] = 1; //-Modified for Clips instead of Ammo
$AmmoPackMax[StunnerClip] = 1; //-Modified for Clips instead of Ammo
$AmmoPackMax[RifleClip] = 3; //-Modified for Clips instead of Ammo
$AmmoPackMax[MGunClip] = 3; //-Modified for Clips instead of Ammo
$AmmoPackMax[SniperClip] = 3; //-Modified for Clips instead of Ammo
$AmmoPackMax[RLauncherClip] = 1;
$AmmoPackMax[CutterayCell] = 1; //-Modified for Cells instead of Ammo
$AmmoPackMax[SmallLasCell] = 1; //-Modified for Cells instead of Ammo
$AmmoPackMax[RifleLasCell] = 1; //-Modified for Cells instead of Ammo
$AmmoPackMax[HeavyLasCell] = 1; //-Modified for Cells instead of Ammo

// Items in the AmmoPack
$AmmoPackItems[0] = PistolClip; //-Modified for Clips instead of Ammo
$AmmoPackItems[1] = MaulaClip; //-Modified for Clips instead of Ammo
$AmmoPackItems[2] = StunnerClip; //-Modified for Clips instead of Ammo
$AmmoPackItems[3] = RifleClip; //-Modified for Clips instead of Ammo
$AmmoPackItems[4] = RLauncherClip;
$AmmoPackItems[5] = CutterayCell; //-Modified for Cells instead of Ammo
$AmmoPackItems[6] = SmallLasCell; //-Modified for Cells instead of Ammo
$AmmoPackItems[7] = RifleLasCell; //-Modified for Cells instead of Ammo
$AmmoPackItems[8] = HeavyLasCell; //-Modified for Cells instead of Ammo
$AmmoPackItems[9] = MGunClip; //-Modified for Clips instead of Ammo
$AmmoPackItems[10] = SniperClip; //-Modified for Clips instead of Ammo


// Limit on number of special Items you can buy
// Not used
$TeamItemMax[ScoutVehicle] = 0;
$TeamItemMax[LAPCVehicle] = 0;
$TeamItemMax[HAPCVehicle] = 0;
$TeamItemMax[TurretPack] = 0;
$TeamItemMax[RepeaterLasgunPack] = 0;
//Used
$TeamItemMax[DeployableAmmoPack] = 4;
$TeamItemMax[DeployableInvPack] = 4;
$TeamItemMax[CameraPack] = 6;
$TeamItemMax[DeployableSensorJammerPack]= 6;
$TeamItemMax[PulseSensorPack] = 6;
$TeamItemMax[MotionSensorPack] = 6;
$TeamItemMax[Beacon] = 25;
$TeamItemMax[mineammo] = 100;
$TeamItemMax[PlasteelPack] = 10;
$TeamItemMax[LPentashieldPack] = 2;
$TeamItemMax[SPentashieldPack] = 4;
$TeamItemMax[DeployableGenPack] = 2;
$TeamItemMax[HieregPack] = 3;
$TeamItemMax[StationaryLasgunPack] = 5;
$TeamItemMax[RemoteLasgunPack] = 7;
$TeamItemMax[RemoteProjectileGunPack] = 7;
$TeamItemMax[HunterSeekerPlatformPack] = 4;
$TeamItemMax[BasicThopterVehicle] = 3;
$TeamItemMax[VulcanThopterVehicle] = 3;
$TeamItemMax[LasgunThopterVehicle] = 3;
$TeamItemMax[ArtillaryThopterVehicle] = 3;
$TeamItemMax[CarryallVehicle] = 2;
$TeamItemMax[RollerVehicle] = 3;
$TeamItemMax[TrackerVehicle] = 3;
$TeamItemMax[CrawlerVehicle] = 2;
$TeamItemMax[ThumperPack] = 2;
$TeamItemMax[MechGunPack] = 3;
$TeamItemMax[MechArtillaryPack] = 3;
$TeamItemMax[MechRocketPack] = 3;
$TeamItemMax[MechFlamePack] = 3;

// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};

// Weapon to ammo table
$WeaponAmmo[Knife] = "";
$WeaponAmmo[Knife2] = "";
$WeaponAmmo[SlipTip] = "";
$WeaponAmmo[Kindjal] = "";
$WeaponAmmo[Crysknife] = "";
$WeaponAmmo[Rapier] = "";
$WeaponAmmo[Saber] = "";

$WeaponAmmo[MountedArtillaryGun] = "";
$WeaponAmmo[MountedMachineGun] = "";

$WeaponAmmo[Pistol] = PistolAmmo;
$WeaponAmmo[Maula] = MaulaAmmo;
$WeaponAmmo[Stunner] = StunnerAmmo;
$WeaponAmmo[Rifle] = RifleAmmo;
$WeaponAmmo[Rifle2] = RifleAmmo;
$WeaponAmmo[MGun] = MGunAmmo;
$WeaponAmmo[MGun2] = MGunAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[RLauncher] = RLauncherAmmo;
$WeaponAmmo[Flamethrower] = FlamethrowerAmmo;
$WeaponAmmo[Piller] = FlamethrowerAmmo;
$WeaponAmmo[Cutteray] = CutterayAmmo;
$WeaponAmmo[SmallLas] = SmallLasAmmo;
$WeaponAmmo[RifleLas] = RifleLasAmmo;
$WeaponAmmo[HeavyLas] = HeavyLasAmmo;


$AmmoWeapon[PistolAmmo] = Pistol;
$AmmoWeapon[MaulaAmmo] = Maula;
$AmmoWeapon[StunnerAmmo] = Stunner;
$AmmoWeapon[RifleAmmo] = Rifle;
$AmmoWeapon[MGunAmmo] = MGun;// Check MGun2 as well...
$AmmoWeapon[SniperAmmo] = SniperRifle;
$AmmoWeapon[RLauncherAmmo] = RLauncher;
$AmmoWeapon[FlamethrowerAmmo] = Flamethrower;
$AmmoWeapon[PillerAmmo] = Piller;
$AmmoWeapon[CutterayAmmo] = Cutteray;
$AmmoWeapon[SmallLasAmmo] = SmallLas;
$AmmoWeapon[RifleLasAmmo] = RifleLas;
$AmmoWeapon[HeavyLasAmmo] = HeavyLas;



$MeleeWeapon[Knife] = true;
$MeleeWeapon[Knife2] = true;
$MeleeWeapon[SlipTip] = true;
$MeleeWeapon[Kindjal] = true;
$MeleeWeapon[Crysknife] = true;
$MeleeWeapon[Rapier] = true;
$MeleeWeapon[Saber] = true;

$MeleeWeapon[MountedArtillaryGun] = false;
$MeleeWeapon[MountedMachineGun] = false;

$MeleeWeapon[Pistol] = false;
$MeleeWeapon[Maula] = false;
$MeleeWeapon[Stunner] = false;
$MeleeWeapon[Rifle] = false;
$MeleeWeapon[Rifle2] = false;
$MeleeWeapon[MGun] = false;
$MeleeWeapon[MGun2] = false;
$MeleeWeapon[SniperRifle] = false;
$MeleeWeapon[RLauncher] = false;
$MeleeWeapon[Flamethrower] = false;
$MeleeWeapon[Piller] = false;
$MeleeWeapon[Cutteray] = false;
$MeleeWeapon[SmallLas] = false;
$MeleeWeapon[RifleLas] = false;
$MeleeWeapon[HeavyLas] = false;

//----------------------------------------------------------------------------//
//-CLIPCODE BY ICE------------------------------------------------------------//
//----------------------------------------------------------------------------//
// !!!NOTE!!!: You will need to set the the reloading times AND the prices for//
// the magazines, I have already set everything else into their places, modify//
// the third term section below to set the reloading time in seconds          //
//----------------------------------------------------------------------------//

//Pistol:	12 to a clip	w/ 3 clips +2 extra for ammo pack
//Maula:	5 to a clip	w/ 2 clips +1 extra for ammo pack
//Stunner:	2 to a clip	w/ 2 clips +1 extra for ammo pack 
//Rifle:	50 to a clip	w/ 3 clips +1 extra for ammo pack
//Cutteray:	25 to a cell	w/ 3 cells +1 extra for ammo pack
//SmallLas:	25 to a cell	w/ 3 cells +1 extra for ammo pack
//RifleLas:	25 to a cell	w/ 2 cells +1 extra for ammo pack
//HeavyLas:	10 to a cell	w/ 3 cells +1 extra for ammo pack

//>-Defines what Magazine each gun uses
$Clip[RLauncher] = RLauncherClip;
$Clip[Pistol] = PistolClip;
$Clip[Maula] = MaulaClip;
$Clip[Stunner] = StunnerClip;
$Clip[Rifle] = RifleClip;
$Clip[Rifle2] = RifleClip;
$Clip[MGun] = MGunClip;
$Clip[MGun2] = MGunClip;
$Clip[SniperRifle] = SniperClip;
$Clip[Cutteray] = CutterayCell;
$Clip[SmallLas] = SmallLasCell;
$Clip[RifleLas] = RifleLasCell;
$Clip[HeavyLas] = HeavyLasCell;


$ClipToWeapon[RLauncherClip] = RLauncher;
$ClipToWeapon[PistolClip] = Pistol;
$ClipToWeapon[MaulaClip] = Maula;
$ClipToWeapon[StunnerClip] = Stunner;
$ClipToWeapon[RifleClip] = Rifle;
$ClipToWeapon[MGunClip] = MGun;
$ClipToWeapon[SniperClip] = SniperRifle;
$ClipToWeapon[CutterayCell] = Cutteray;
$ClipToWeapon[SmallLasCell] = SmallLas;
$ClipToWeapon[RifleLasCell] = RifleLas;
$ClipToWeapon[HeavyLasCell] = HeavyLas;

//>-Defines the Magazine's size
$ClipSize[RLauncher] = 1;
$ClipSize[Pistol] = 12;
$ClipSize[Maula] = 5;
$ClipSize[Stunner] = 2;
$ClipSize[Rifle] = 50;
$ClipSize[Rifle2] = 50;
$ClipSize[SniperRifle] = 3;
$ClipSize[MGun] = 75;
$ClipSize[MGun2] = 75;
$ClipSize[Cutteray] = 25;
$ClipSize[SmallLas] = 75;
$ClipSize[RifleLas] = 75;
$ClipSize[HeavyLas] = 30;

//>-Defines how long the gun takes to switch magazines 
$ClipTime[RLauncher] = 2.5;
$ClipTime[Pistol] = 2.5;
$ClipTime[Maula] = 2.5;
$ClipTime[Stunner] = 2.5;
$ClipTime[Rifle] = 2.5;
$ClipTime[Rifle2] = 2.5;
$ClipTime[SniperRifle] = 1.5;
$ClipTime[MGun] = 2.5;
$ClipTime[MGun2] = 2.5;
$ClipTime[Cutteray] = 2.5;
$ClipTime[SmallLas] = 2.5;
$ClipTime[RifleLas] = 2.5;
$ClipTime[HeavyLas] = 2.5;


// Mechs don't exist i tell ya! And i'm too lazy to rip out all the code!
function Mech::isMech()
{
	return false;
}

//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 		%client.teamEnergy += %cost;   //Personal TeamEnergy
	}
}

function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client))
		return;

   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime || $FaceDancerIsSwitched[%client])
      return;
   %player = Client::getOwnedObject(%client);
   %client.lastBuyFavTime = %time;

	%station = (%player).Station;
	if(%station != "" ) {
		%stationName = GameBase::getDataName(%station); 
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0) {
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) {
					%count = Player::getItemCount(%client,%item);
					RemoveAllAmmo(%client);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));

						if(%item == ShieldPack){
							if($Shieldon[%player])	
								Client::sendMessage(%client,0,"Shield Off");
							%player.shieldStrength = 0;
							$ShieldOn[%player] = false;
							Player::trigger(%player,4,false);
							Player::UnMountItem(%player, 4);
							GameBase::setRechargeRate(%player,0.1); //Diddily bug fix.

						}

						if(%item == FuelPack)
							Player::Setitemcount(%client,FlamethrowerAmmo,0);
				
						if(%item.className != Armor) 
							Player::setItemCount(%client, %item, 0); 
					}
				}
			}
			for (%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);

					if (((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item))) || (%item.className == Armor && ( $ArmorName[Player::getArmor(%client)] != %item)) ) {
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
			if(%bought) {
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}


function RemoveAllAmmo(%client)
{
	player::SetItemCount(%client, PistolAmmo, 0);
	player::SetItemCount(%client, MaulaAmmo, 0);
	player::SetItemCount(%client, StunnerAmmo, 0);
	player::SetItemCount(%client, RifleAmmo, 0);
	player::SetItemCount(%client, MGunAmmo, 0);
	player::SetItemCount(%client, SniperAmmo, 0);
	player::SetItemCount(%client, RLauncherAmmo, 0);
	player::SetItemCount(%client, CutterayAmmo, 0);
	player::SetItemCount(%client, SmallLasAmmo, 0);
	player::SetItemCount(%client, RifleLasAmmo, 0);
	player::SetItemCount(%client, HeavyLasAmmo, 0);

}

function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}

function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	if($TestCheats == 0 && %client.spawn == "") {
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
	%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation){
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") {
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 ) {

				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon) {
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
		if (player::Getitemcount(%client,Rifle2) > 0 && %item == Rifle)
			return;
  	}
	else if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
   	}
   	else if($TeamItemMax[%item] != "" && !$TestCheats) {
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) {
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle) {
		%count = Player::getItemCount(%client,%item);
	   	if($ItemMax[Player::getArmor(%client), %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%client)], Player::getArmor(%client), %item])
	  		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo;
		else
			%max = 0;
		if(%item == RLauncherClip && (Player::getArmor(%client) == sarmor || Player::getArmor(%client) == sfemale || Player::getArmor(%client) == sarmor2 || Player::getArmor(%client) == sfemale2)
			&& player::getItemCount(%client, RLauncher) > 0 && player::getItemCount(%client, RLauncherAmmo) < 1 && player::getItemCount(%client, RLauncherClip) < 1)
			%max = 1;
	   	if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	//if(%player.Station == "")
	//	return 0;
	if (!$FaceDancerIsSwitched[%client] && ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && (($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%client)], %armor, %item]) || (%item.className == Armor && ( ( $TeamArmor[$ServerNameToKeyName[GameBase::getTeam(%client)], %item] != 0) && (( ( $TeamArmorCount[$ServerNameToKeyName[client::getteam(%client)], %item] / Game::NumTeamPlayers(client::getteam(%client)) ) *100) < $TeamArmor[$ServerNameToKeyName[client::getteam(%client)], %item] ) ) ) || (%item.className == Vehicle && $TeamVehicleMax[$ServerNameToKeyName[GameBase::getTeam(%client)], %item] != 0) || $TestCheats)) {
		//-Ice added Weapon::descriptionMSG code to write description for item when bought
		//Weapon::descriptionMSG(%client,%item);
		if (%item.className == Armor) {
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					remoteeval(%client,setArmor,%item);
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
     					Player::setItemCount(%client, %item, 1);
					$TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%client)], $ArmorName[%armor]] = $TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%client)], $ArmorName[%armor]] - 1;
					$TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%client)], $ArmorName[%buyarmor]] = $TeamArmorCount[$ServerNameToKeyName[GameBase::getTeam(%client)], $ArmorName[%buyarmor]] + 1;

					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);
				
					setupShoppingList(%client,%client.invo,%client.ListType);
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {

				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) {
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItem(%client,22);						
					}
				} 
				//****NEW
				else if(%pack == FuelPack) {
					if(Player::getItemCount(%client,"Flamethrower") > 0) {
						Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
						remoteSellItem(%client,22);
					}
					if(Player::getItemCount(%client,"Piller") > 0) {
						Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Piller of Fire");
						remoteSellItem(%client,22);						
					}
					player::setitemcount(%client,FlamethrowerAmmo,0);
					
				}
				else if(%pack == ShieldPack ){
					if($shieldon[%player])
						Client::sendMessage(%client,0,"Shield Off");
					%player.shieldStrength = 0;
					$ShieldOn[%player] = false;
					Player::trigger(%player,4,false);
					Player::UnMountItem(%player, 4);
					GameBase::setRechargeRate(%player,0.1); //Diddily bug fix.
				}
				else if(%pack == SuspensorPack){
					$TimeSuspensorOn[%player] = 0;
					if($SuspensorActivate[%player] == 1) {
						Client::sendMessage(%client,0,"Suspensor Pack sold; Deactivating");
						Player::trigger(%player,$BackpackSlot,false);
						disableSuspensorPack(%player);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
				
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				if(%item == FuelPack)
					player::Setitemcount(%client,FlamethrowerAmmo,100);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				//****NEW
				if(%item == Flamethrower && Player::getItemCount(%client,"FuelPack") == 0) {
					buyItem(%client,"FuelPack");
					Client::sendMessage(%client,0,"Bought Flamethrower - Auto buying Fuel Pack");
				}
				if(%item == Piller && Player::getItemCount(%client,"FuelPack") == 0) {
					buyItem(%client,"FuelPack");
					Client::sendMessage(%client,0,"Bought Piller of Fire - Auto buying Fuel Pack");
				}
				//*******
				//- Ice Added Auto Clip-Buying
				if($Clip[%item] != "")
					buyItem(%client,$Clip[%item]);
				//- End
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if((%delta || $testCheats) && %item != Flamethrower && %item != Piller){
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				//****NEW
				if(%item == BasicThopterVehicle)
					%shouldBuy = OrnithopterStation::checkBuying(%client,%item);
				if(%item == VulcanThopterVehicle)
					%shouldBuy = OrnithopterStation::checkBuying(%client,%item);
				if(%item == LasgunThopterVehicle)
					%shouldBuy = OrnithopterStation::checkBuying(%client,%item);
				if(%item == ArtillaryThopterVehicle)
					%shouldBuy = OrnithopterStation::checkBuying(%client,%item);
				if(%item == CarryallVehicle)
					%shouldBuy = OrnithopterStation::checkBuying(%client,%item);
				if(%item == RollerVehicle)
					%shouldBuy = GroundCarStation::checkBuying(%client,%item);
				if(%item == TrackerVehicle)
					%shouldBuy = GroundCarStation::checkBuying(%client,%item);
				if(%item == CrawlerVehicle)
					%shouldBuy = GroundCarStation::checkBuying(%client,%item);
				//*******
				//%shouldBuy = VehicleStation::checkBuying(%client,%item); //commented out because we dont use vehicle stations anymore.
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		//else if(%item.className == Ammo && %item != FlameThrowerAmmo && %item != PillerAmmo) {
		else if(%item.className == Ammo) {
			return 0;
		} 
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
 	}
	return 0;
}

function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "") {
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);	
	  	%newPosX = (getWord(%vec,0) * 1) + %posX;		 
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
	// Skin setting
	%armor = $ArmorName[Player::GetArmor(%client)];
	%team = $ServerNameToKeyName[Client::GetTeam(%client)];
	Dune::SwitchSkin(%client,%Armor,%team);
}

function Dune::SwitchSkin(%client,%armor,%team)
{
 	if(%Team == HA)
	{
		if(%Armor == SoldierArmor)
			client::Setskin(%client,AtreidesSoldier);
		else if(%Armor == TrooperArmor)
			client::Setskin(%client,AtreidesTrooper);
		else if(%Armor == FedaykinArmor)
			client::Setskin(%client,AtreidesFedaykin);
		else if(%Armor == FremenArmor)
			client::Setskin(%client,AtreidesFremen);
	} else if(%Team == HH)
	{
		if(%Armor == SoldierArmor)
			client::Setskin(%client,HarkSoldier);
		else if(%Armor == TrooperArmor)
			client::Setskin(%client,HarkTrooper);
		else if(%Armor == SardaukarArmor)
			client::Setskin(%client,HarkSardaukar);
	} else if(%Team == HC)
	{
		if(%Armor == BursegArmor)
			client::Setskin(%client,CorrinoBurseg);
		else if(%Armor == BasharArmor)
			client::Setskin(%client,CorrinoBashar);
		else if(%Armor == SardaukarArmor)
			client::Setskin(%client,CorrinoSardaukar);
	} else if(%Team == IX)
	{
		if(%Armor == SoldierArmor)
			client::Setskin(%client,IxSoldier);
	} else if(%Team == BT)
	{
		if(%Armor == SoldierArmor)
			client::Setskin(%client,TleilaxuSoldier);
		else if(%Armor == FaceDancerArmor)
			client::SetSkin(%client,TleilaxuFaceDancer);
	} else if(%Team == MH || %Team == MH2)
	{
		if(%Armor == SoldierArmor)
			client::Setskin(%client,MinorSoldier);
		else if(%Armor == TrooperArmor)
			client::SetSkin(%client,MinorTrooper);
	}
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	
	if(Client::getOwnedObject(%client).Station == "")
		return;

	if(buyItem(%client,%item)) {
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if (!$FaceDancerIsSwitched[%client] && ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || (%item == Rifle2 && player::getitemcount(%client,Rifle2) > 0)) && %player.Station != "" ) {
		if(Player::getItemCount(%client,%item) && %item.className != Armor) {
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) {
				return;
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack) { 
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
			}
			else if(%item == FuelPack) {
				if(Player::getItemCount(%client,"Flamethrower") > 0) {
					Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
					remoteSellItem(%client,22);
				} else if(Player::getItemCount(%client,"Piller") > 0) {
					Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Piller of Fire");
					remoteSellItem(%client,22);
				}
					player::Setitemcount(%client,FlamethrowerAmmo,0);
			}//****NEW
			else if(%item == SuspensorPack){
				$TimeSuspensorOn[%player] = 0;
				if($SuspensorActivate[%player] == 1) {
					Client::sendMessage(%client,0,"Suspensor Pack sold; Deactivating");
					Player::trigger(%player,$BackpackSlot,false);
					disableSuspensorPack(%player);
				}
				remoteSellItem(%client,22);
			}
			else if(%item == ShieldPack){
				if($Shieldon[%player])	
					Client::sendMessage(%client,0,"Shield Off");
				%player.shieldStrength = 0;
				$ShieldOn[%player] = false;
				Player::trigger(%player,4,false);
				Player::UnMountItem(%player, 4);
				GameBase::setRechargeRate(%player,0.1); //Diddily bug fix.

				remoteSellItem(%client,22);
			}
			//*******
			if(%item == Rifle2)
			{
				teamEnergyBuySell(%player,Rifle.price * %numsell);
				Player::setItemCount(%player,%item,(%count-%numsell));
				if(%item.className == Weapon && %item.imageType.ammoType != "")
				{
					player::setitemcount(%player,%item.imageType.ammoType,0);
				}
				updateBuyingList(%client);
				Client::SendMessage(%client,0,"~wbuysellsound.wav");
				return 1;
			} else {			
				teamEnergyBuySell(%player,%item.price * %numsell);
				Player::setItemCount(%player,%item,(%count-%numsell));
				if(%item.className == Weapon && %item.imageType.ammoType != "" && %item != Piller && %item != Flamethrower)
				{
					player::setitemcount(%player,%item.imageType.ammoType,0);
				}
				updateBuyingList(%client);
				Client::SendMessage(%client,0,"~wbuysellsound.wav");
				return 1;
			}
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
//echo("Use " @ %client @ ", " @%type);
	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

	//echo("Use item: " @ %type @ " " @ %item);
	%client.throwStrength = 1;
	%item = getItemData(%type);
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon)
			%item = Player::getMountedItem(%client,$WeaponSlot);
		else if (%item == TargetingLaser)
			%item = "Cutteray";
	}
	Player::useItem(%client,%item);
}

$WeaponType[melee,8] = ""; 			$WeaponType[melee,""] = 8;
$WeaponType[melee,7] = Stunner; 		$WeaponType[melee,Stunner] = 7;
$WeaponType[melee,6] = Knife;			$WeaponType[melee,Knife] = 6;
$WeaponType[melee,5] = Knife2;			$WeaponType[melee,Knife2] = 5;
$WeaponType[melee,4] = SlipTIp;			$WeaponType[melee,SlipTIp] = 4;
$WeaponType[melee,3] = Kindjal;			$WeaponType[melee,Kindjal] = 3;
$WeaponType[melee,2] = Rapier;			$WeaponType[melee,Rapier] = 2;
$WeaponType[melee,1] = Saber;			$WeaponType[melee,Saber] = 1;
$WeaponType[melee,0] = Crysknife;		$WeaponType[melee,Crysknife] = 0;

$WeaponType[throwing,7] = "";			$WeaponType[throwing,""] = 7;
$WeaponType[throwing,6] = Rapier;		$WeaponType[throwing,Rapier] = 6;
$WeaponType[throwing,5] = Saber;		$WeaponType[throwing,Saber] = 5;
$WeaponType[throwing,4] = Kindjal;		$WeaponType[throwing,Kindjal] = 4;
$WeaponType[throwing,3] = SlipTip;		$WeaponType[throwing,SlipTip] = 3;
$WeaponType[throwing,2] = Crysknife;		$WeaponType[throwing,Crysknife] = 2;
$WeaponType[throwing,1] = Knife2;		$WeaponType[throwing,Knife2] = 1;
$WeaponType[throwing,0] = Knife;		$WeaponType[throwing,Knife] = 0;

$WeaponType[projectile,12] = "";		$WeaponType[projectile,""] = 12;
$WeaponType[projectile,11] = Stunner;		$WeaponType[projectile,Stunner] = 11;
$WeaponType[projectile,10] = RLauncher;		$WeaponType[projectile,RLauncher] = 10;
$WeaponType[projectile,9] = Maula;		$WeaponType[projectile,Maula] = 9;
$WeaponType[projectile,8] = Pistol;		$WeaponType[projectile,Pistol] = 8;
$WeaponType[projectile,7] = Rifle2;		$WeaponType[projectile,Rifle2] = 7;
$WeaponType[projectile,6] = Rifle;		$WeaponType[projectile,Rifle] = 6;
$WeaponType[projectile,5] = Flamethrower;	$WeaponType[projectile,Flamethrower] = 5;
$WeaponType[projectile,4] = SniperRifle;	$WeaponType[projectile,SniperRifle] = 4;
$WeaponType[projectile,3] = MGun;		$WeaponType[projectile,MGun] = 3;
$WeaponType[projectile,2] = MGun2;		$WeaponType[projectile,MGun2] = 2;
$WeaponType[projectile,1] = MountedMachineGun;	$WeaponType[projectile,MountedMachineGun] = 1;
$WeaponType[projectile,0] = MountedArtillaryGun;$WeaponType[projectile,MountedArtillaryGun] = 0;

$WeaponType[lasgun,4] = "";			$WeaponType[lasgun,""] = 4;
$WeaponType[lasgun,3] = Cutteray;		$WeaponType[lasgun,Cutteray] = 3;
$WeaponType[lasgun,2] = SmallLas;		$WeaponType[lasgun,SmallLas] = 2;
$WeaponType[lasgun,1] = RifleLas;		$WeaponType[lasgun,RifleLas] = 1;
$WeaponType[lasgun,0] = HeavyLas;		$WeaponType[lasgun,HeavyLas] = 0;

$WeaponType[aa,9] = "";				$WeaponType[aa,""] = 9;
$WeaponType[aa,8] = Pistol;			$WeaponType[aa,Pistol] = 8;
$WeaponType[aa,7] = RifleLas;			$WeaponType[aa,RifleLas] = 7;
$WeaponType[aa,6] = Rifle2;			$WeaponType[aa,Rifle2] = 6;
$WeaponType[aa,5] = Rifle;			$WeaponType[aa,Rifle] = 5;
$WeaponType[aa,4] = Mgun;			$WeaponType[aa,Mgun] = 4;
$WeaponType[aa,3] = MGun2;			$WeaponType[aa,MGun2] = 3;
$WeaponType[aa,2] = MountedMachineGun;		$WeaponType[aa,MountedMachineGun] = 2;
$WeaponType[aa,1] = RLauncher;			$WeaponType[aa,RLauncher] = 1;
$WeaponType[aa,0] = Piller;			$WeaponType[aa,Piller] = 0;

$WeaponType[at,12] = "";			$WeaponType[at,""] = 12;
$WeaponType[at,11] = Cutteray;			$WeaponType[at,Cutteray] = 11;
$WeaponType[at,10] = Pistol;			$WeaponType[at,Pistol] = 10;
$WeaponType[at,9] = SmallLas;			$WeaponType[at,SmallLas] = 9;
$WeaponType[at,8] = Rifle2;			$WeaponType[at,Rifle2] = 8;
$WeaponType[at,7] = Rifle;			$WeaponType[at,Rifle] = 7;
$WeaponType[at,6] = MGun;			$WeaponType[at,MGun] = 6;
$WeaponType[at,5] = MGun2;			$WeaponType[at,MGun2] = 5;
$WeaponType[at,4] = MountedMachineGun;		$WeaponType[at,MountedMachineGun] = 4;
$WeaponType[at,3] = RifleLas;			$WeaponType[at,RifleLas] = 3;
$WeaponType[at,2] = HeavyLas;			$WeaponType[at,HeavyLas] = 2;
$WeaponType[at,1] = RLauncher;			$WeaponType[at,RLauncher] = 1;
$WeaponType[at,0] = MountedArtillaryGun;	$WeaponType[at,MountedArtillaryGun] = 0;

$WeaponType[tool,1] = "";			$WeaponType[tool,""] = 1;
$WeaponType[tool,0] = Cutteray;			$WeaponType[tool,Cutteray] = 0;

$WeaponType[Knife] = melee;
$WeaponType[Knife2] = melee;
$WeaponType[SlipTip] = melee;
$WeaponType[Kindjal] = melee;
$WeaponType[Rapier] = melee;
$WeaponType[Saber] = melee;
$WeaponType[Crysknife] = melee;

$WeaponType[Stunner] = projectile;
$WeaponType[RLauncher] = projectile;
$WeaponType[Maula] = projectile;
$WeaponType[Pistol] = projectile;
$WeaponType[Rifle2] = projectile;
$WeaponType[Rifle] = projectile;
$WeaponType[Flamethrower] = projectile;
$WeaponType[SniperRifle] = projectile;
$WeaponType[MGun] = projectile;
$WeaponType[MGun2] = projectile;
$WeaponType[MountedMachineGun] = projectile;
$WeaponType[MountedArtillaryGun] = projectile;

$WeaponType[Cutteray] = lasgun;
$WeaponType[SmallLas] = lasgun;
$WeaponType[RifleLas] = lasgun;
$WeaponType[HeavyLas] = lasgun;

$WeaponType[Piller] = aa;

function remoteUseItemType(%client,%type)
{
	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

	if(Player::getItemState(%client,$WeaponSlot) == Spinup || Player::getItemState(%client,$WeaponSlot) == Fire || Player::getItemState(%client,$WeaponSlot) == SpinDown)
		return;

	if(Client::getOwnedObject(%client) == -1)
		return;

	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) > 0)
		return;


		
	%item = "";
	%client.throwStrength = 1; // Why..?
	
	%player = Client::getOwnedObject(%client);

	if(%player.vehicle && %player.vehicle != -1 && %player.vehicle != "")
		return;
	if(%type == nothing && Player::getMountedItem(%player, $WeaponSlot) != -1)
	{

		%player.LastWeapon = Player::getMountedItem(%player, $WeaponSlot);
		Player::unmountItem(%player,$WeaponSlot);
	} else
	{
		%done = false;
		for(%x=0;%x<20 && $WeaponType[%type,%x] != "" && !%done;%x++)
		{
			if(isSelectableWeapon(%client,$WeaponType[%type,%x]))
			{
				%item = $WeaponType[%type,%x];
				%client.Weapontype = %type;
				%done = true;
			}	
		}
	}
	if(%done)
	{
		Player::useItem(%client,%item);
		$CurWeap[%client] = $WeaponToNum[%item];

		$LastUsedWeap[%client] = $WeaponToNum[%item];
	}
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if($UA::grabbed[%client] != "")
	{
		// Then we're being held, and are in orbit.
		UA::AttemptBreakGrip(%client);
	} 


	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		//echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if(%item == Grenade && (!$IsBlocking[%player] || $isblocking[%player] == "")
			&& (Player::getMountedItem(%client,$WeaponSlot) == knife || Player::getMountedItem(%client,$WeaponSlot) == knife2 || Player::getMountedItem(%client,$WeaponSlot) == Sliptip || Player::getMountedItem(%client,$WeaponSlot) == crysknife || Player::getMountedItem(%client,$WeaponSlot) == kindjal || Player::getMountedItem(%client,$WeaponSlot) == rapier || Player::getMountedItem(%client,$WeaponSlot) == saber || (Player::getMountedItem(%client,$WeaponSlot) == -1 && %player.shieldStrength) ))
			{
				Player::Block(%player);
			}
			else if(%item == MineAmmo) {
				if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
					return;
				%weapon = Player::getMountedItem(%player, $WeaponSlot);
				if(%weapon == -1)
				{
					Player::useItem(%player,%player.lastweapon);
				} else if($MeleeWeapon[%weapon])
				{
					%player.LastWeapon = %weapon;
					Player::unmountItem(%player,$WeaponSlot);
				} else
				{
					Clip::onUse(%player);
				}
				//if(%strength < 0)
				//	%strength = 0;
				//else
				//	if(%strength > 100)
				//		%strength = 100;
				//%Multiplier = $ThrowStrength[%armor];
				//if(!%Multiplier)
				//	%Multiplier = 1.0;
				//%strength *= %Multiplier;
				//%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				//Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

	if((Client::getOwnedObject(%client)).driver != 1) {
		//echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		if (%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	   	else if (%item == Weapon) {

			%item = Player::getMountedItem(%client,$WeaponSlot);
			
			player::dropitem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon && $Clip[%item] != "") {
				%item = $Clip[%item];
				Player::dropItem(%client,%item);	
			}
		}
		else 
			Player::dropItem(%client,%item);
	}
}


function remoteDeployItem(%client,%type)
{

	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//--------------------------------------//
// ADVANCED WEAPON SWAPPING CODE BY ICE //
//--------------------------------------//
// Easier to use for modding, just add a weapon, and modify the Max number

// Except you need to know more about the script then you did before, just to debug all the problems with it... -Jesus

$WeaponNum[1] =  Knife;
$WeaponNum[2] =  SlipTip;
$WeaponNum[3] =  Crysknife;
$WeaponNum[4] =  Kindjal;
$WeaponNum[5] =  Rapier;
$WeaponNum[6] =  Saber;
$WeaponNum[7] =  Pistol;
$WeaponNum[8] =  Maula;
$WeaponNum[9] =  Stunner;
$WeaponNum[10] =  Rifle;
$WeaponNum[11] =  Rifle2;
$WeaponNum[12] = RLauncher;
$WeaponNum[13] = Flamethrower;
$WeaponNum[14] = Piller;
$WeaponNum[15] = SmallLas;
$WeaponNum[16] = RifleLas;
$WeaponNum[17] = HeavyLas;
$WeaponNum[18] = MGun;
$WeaponNum[19] = MGun2;
$WeaponNum[20] = SniperRifle;
$WeaponNum[21] =  Knife2;
$WeaponNum[22] =  MountedArtillaryGun;
$WeaponNum[23] =  MountedMachineGun;

$WeaponToNum[Knife] =  1;
$WeaponToNum[SlipTip] =  2;
$WeaponToNum[Crysknife] =  3;
$WeaponToNum[Kindjal] =  4;
$WeaponToNum[Rapier] =  5;
$WeaponToNum[Saber] =  6;
$WeaponToNum[Pistol] = 7;
$WeaponToNum[Maula] =  8;
$WeaponToNum[Stunner] =  9;
$WeaponToNum[Rifle] =  10;
$WeaponToNum[Rifle2] =  11;
$WeaponToNum[RLauncher] = 12;
$WeaponToNum[Flamethrower] = 13;
$WeaponToNum[Piller] = 14;
$WeaponToNum[SmallLas] = 15;
$WeaponToNum[RifleLas] = 16;
$WeaponToNum[HeavyLas] = 17;
$WeaponToNum[MGun] = 18;
$WeaponToNum[MGun2] = 19;
$WeaponToNum[SniperRifle] = 20;
$WeaponToNum[Knife2] =  21;
$WeaponToNum[MountedArtillaryGun] =  22;
$WeaponToNum[MountedMachineGun] =  23;

$MaxWeapon=23;

function remoteNextWeapon(%client)
{
	if(%client.dead) //Diddily Bug Fix
		return; 



	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

	if(Mech::isMech(%client))
	{
		return;
	}
		
	if(Client::getOwnedObject(%client) == -1)
		return;

	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) > 0)
		return;

	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).driver == 1) {
		remoteVehNextWeapon(%client,Client::getOwnedObject(%client).vehicle);
		return;
	}
	//if(Client::getOwnedObject(%client).turret) {
		//-Later to add in turret weaps...?
	//	return;
	//}
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemState(%client,$WeaponSlot) == Spinup || Player::getItemState(%client,$WeaponSlot) == Fire || Player::getItemState(%client,$WeaponSlot) == SpinDown)
		return;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
		return FALSE;
	}

	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).vehicle != -1 && Client::getOwnedObject(%client).vehicle != "")
		return;

	if(%client.weaponLooping != true)
	{
		if($WeapSwapNotInit[%client] != true && Player::GetMountedItem(%client,$WeaponSlot) != -1)
		{
			$WeapSwapNotInit[%client] = true;
			%item = $WeaponToNum[Player::getMountedItem(%client,$WeaponSlot)];
		}		
		else
			%item = $CurWeap[%client];
		%item++;
		if(%item > $MaxWeapon)
			%item = 1;
		%weapon = $WeaponNum[%item];
		$CurWeap[%client] = %item;
		
		// If true, get the hell out of here. We got no weapons to use.
		if( %item == $LastUsedWeap[%client])
		{
			player::useItem(%client,$WeaponNum[%item]);
			$WeapSwapNotInit[%client] = false;
			return FALSE;
		}
		if(isSelectableWeapon(%client,%weapon)) {
			
			$LastUsedWeap[%client] = %item;
			Player::useItem(%client,%weapon);
			$CurWeap = %item;
			%client.WeaponType = $WeaponType[$WeaponNum[%item]];
			$WeapSwapNotInit[%client] = false;
			if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
				break;
		}			
		else
			remoteNextWeapon(%client);
	} else
	{
		weaponLoopingNextWeapon(%client);
	}
}

// Problem: echo below
// WeaponType = projectile
// CurWeap = flamethrower (as atreides trooper?!?)
// Weapon in hand = none
// switch weapon causes problem.
// I believe i picked up a rocket launcher (maybe a semi auto?). I must have also accedently set the weapon type to projectile then,
// as all i have at current time is a lasgun.
// I SOLD the projectile gun, bought the lasgun.
// Deployed the blastwall, switched weapons, got message.




// That weaponswap was terribly buggy for it's marginal "advancements" over the original dynamix one..
// Enough ranting though
// Here's support for weapontype switching.
function weaponLoopingNextWeapon(%client)
{
	if($Player::WeaponSwitchCount[%client] < 1 ||  $Player::WeaponSwitchCount[%client] == "")
		$Player::WeaponSwitchCount[%client] = 0;
	$Player::WeaponSwitchCount[%client]++;

	if($Player::WeaponSwitchCount[%client] > 30)
	{
		$player::WeaponSwitchCount[%client] = 0;
		ECHO("*****PROBLEM WITH WEAPON SWITCHING******");
		centerprint(%client, "<jc><f0>A problem with weapon switching just occured. Please let Jesus know *EXACTLY* what weapon you switched to, from, and what class of weapons you were in.", 20);
		return false;
	}
	if(%client.WeaponType == "")
		%client.WeaponType = melee;

	if($WeapSwapNotInit[%client] != true && Player::GetMountedItem(%client,$WeaponSlot) != -1)
	{
		$WeapSwapNotInit[%client] = true;
		%curWeap = Player::getMountedItem(%client,$WeaponSlot);
	}
	else
		%curWeap = $WeaponNum[$CurWeap[%client]];//Player::getMountedItem(%client,$WeaponSlot);
	%num = $WeaponType[%client.Weapontype,%curWeap];
	if(%num == "")
		%num = -1;
	%num = %num++;
	%nextWeap = $WeaponType[%client.WeaponType,%num];
	if(%nextWeap == "")
		%nextWeap = $WeaponType[%client.WeaponType,0];
	$CurWeap[%client] = $WeaponToNum[%nextWeap];
	// If true, get the hell out of here. We got no weapons to use.
	if( $WeaponToNum[%nextweap] == $LastUsedWeap[%client])
	{
		player::useItem(%client,%nextweap);
		$WeapSwapNotInit[%client] = false;
		$Player::WeaponSwitchCount[%client] = 0;
		return FALSE;
	}
	if(isSelectableWeapon(%client,%nextweap)) {
		$LastUsedWeap[%client] = $WeaponToNum[%nextweap];
		$WeapSwapNotInit[%client] = false;
		Player::useItem(%client,%nextweap);
		$Player::WeaponSwitchCount[%client] = 0;
		if(Player::getMountedItem(%client,$WeaponSlot) == %nextweap||Player::getNextMountedItem(%client,$WeaponSlot) == %nextweap)
			break;
	}			
	else
		remoteNextWeapon(%client);
}

function weaponLoopingPrevWeapon(%client)
{
	if($WeapSwapNotInit[%client] != true && Player::GetMountedItem(%client,$WeaponSlot) != -1)
	{
		$WeapSwapNotInit[%client] = true;
		%curWeap =Player::getMountedItem(%client,$WeaponSlot);
	}
	else
		%curWeap = $WeaponNum[$CurWeap[%client]];//Player::getMountedItem(%client,$WeaponSlot);
	%num = $WeaponType[%client.Weapontype,%curWeap];
	if(%num == "")
		%num = 0;

	%nextWeap = $WeaponType[%client.WeaponType,%num--];
	if(%nextWeap == "")
		%nextWeap = $WeaponType[%client.WeaponType,$WeaponType[%client.WeaponType,""]-1];
	$CurWeap[%client] = $WeaponToNum[%nextWeap];


	// If true, get the hell out of here. We got no weapons to use.
	if( $WeaponToNum[%nextweap] == $LastUsedWeap[%client])
	{
		player::useItem(%client,%nextweap);
		$WeapSwapNotInit[%client] = false;
		return FALSE;
	}
	if(isSelectableWeapon(%client,%nextweap)) {
		
		$LastUsedWeap[%client] = $WeaponToNum[%nextweap];
		Player::useItem(%client,%nextweap);
		$WeapSwapNotInit[%client] = false;
		if(Player::getMountedItem(%client,$WeaponSlot) == %nextweap||Player::getNextMountedItem(%client,$WeaponSlot) == %nextweap)
			break;
	}			
	else
		remoteNextWeapon(%client);
}
// end

function remotePrevWeapon(%client)
{
	if(%client.dead) //Diddily Bug Fix
		return; 

	if($UA::grabbing[%client] != "" || $UA::grabbed[%client] != "")
		return;

	if(Mech::isMech(%client))
	{
		return;
	}

	if(Client::getOwnedObject(%client) == -1)
		return;

	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) > 0)
		return;
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).driver == 1) {
		remoteVehPrevWeapon(%client,Client::getOwnedObject(%client).vehicle);
		return;
	}
	//if(Client::getOwnedObject(%client).turret) {
		//-Later to add in turret weaps...?
	//	return;
	//}
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemState(%client,$WeaponSlot) == Spinup || Player::getItemState(%client,$WeaponSlot) == Fire || Player::getItemState(%client,$WeaponSlot) == SpinDown)
		return;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
		return FALSE;
	}

	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).vehicle != -1 && Client::getOwnedObject(%client).vehicle != "")
		return;
	if(%client.weaponLooping != true)
	{
		if($WeapSwapNotInit[%client] != true && Player::GetMountedItem(%client,$WeaponSlot) != -1)
		{
			$WeapSwapNotInit[%client] = true;
			%item = $WeaponToNum[Player::getMountedItem(%client,$WeaponSlot)];
		}
		else
			%item = $CurWeap[%client];
		%item--;
		if(%item < 1)
			%item = $MaxWeapon;
		%weapon = $WeaponNum[%item];				
	
		// If true, get the hell out of here. We got no weapons to use.
		if( %item == $LastUsedWeap[%client])
		{
		
			$WeapSwapNotInit[%client] = false;
			return FALSE;
		}
		$CurWeap[%client] = %item;
		if(isSelectableWeapon(%client,%weapon)) {
			$LastUsedWeap[%client] = %item;
			Player::useItem(%client,%weapon);
			$WeapSwapNotInit[%client] = false;
			%client.WeaponType = $WeaponType[$WeaponNum[%item]];
			if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
				break;
		}			
		else {
			remotePrevWeapon(%client);
		}
	} else
	{
		weaponLoopingNextWeapon(%client);
	}
}

function remoteVehNextWeapon(%client,%veh)
{
	if(checkVehicleAmmo(%veh) != true) {
		bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>Complete Arsenal Ammo Supply Dry!<jr><f5>", 1);
		GameBase::playSound(%client,SoundError,1);
		return FALSE;
	}
	%data = GameBase::getDataName(%veh);
	if($VehicleWeapons[%data] > 0) {
		%curNum = $VehicleWeaponMode[%veh];
		if($FireTime[%this] != 1) {
			%curNum++;
			if(%curNum > $VehicleWeapons[%data]-1)
				%curNum = 0;
			%curWeap = $VehicleWeaponNum[%data,%curNum];
			$VehicleWeaponMode[%veh] = %curNum;
			if($VehicleAmmo[%veh,%curWeap] > 0)
				Vehicle::onWeaponSwitch(%veh);
			else
				remoteVehNextWeapon(%client,%veh);
		}
		else
			schedule("remoteVehNextWeapon("@%client@","@%veh@");",0.5,%veh);
	}
}

function remoteVehPrevWeapon(%client,%veh)
{
	if(checkVehicleAmmo(%veh) != true) {
		bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>Complete Arsenal Ammo Supply Dry!<jr><f5>", 1);
		GameBase::playSound(%client,SoundError,1);
		return FALSE;
	}
	%data = GameBase::getDataName(%veh);
	if($VehicleWeapons[%data] > 0) {
		%curNum = $VehicleWeaponMode[%veh];
		%curWeap = $VehicleWeaponNum[%data,%curNum];
		if($FireTime[%this] != 1) {
			%curNum--;
			if(%curNum < 0)
				%curNum = $VehicleWeapons[%data]-1;
			%curWeap = $VehicleWeaponNum[%data,%curNum];
			$VehicleWeaponMode[%veh] = %curNum;
			if($VehicleAmmo[%veh,%curWeap] > 0)
				Vehicle::onWeaponSwitch(%veh);
			else
				remoteVehPrevWeapon(%client,%veh);
		}
		else
			schedule("remoteVehPrevWeapon("@%client@","@%veh@");",0.5,%veh);
	}
}

function checkVehicleAmmo(%veh)
{
	%data = GameBase::getDataName(%veh);
	for(%i = 0; %i < $VehicleWeapons[%data]; %i++) {
		%curWeap = $VehicleWeaponNum[%data,%i];
		if($VehicleAmmo[%veh,%curWeap] > 0)
			return true;
		if(%i > $VehicleWeapons[%data])
			return false;
	}
	return false;
}

function selectValidWeapon(%client)
{
	if(Mech::isMech(%client))
	{
		return;
	}
	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) > 0)
		return;
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).vehicle != -1 && Client::getOwnedObject(%client).vehicle != "")
		return;
	%item = 1;
	for(%weapon = %item+1; %weapon != %item; %weapon = %item+1) {
		echo(%weapon);
		if(isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Mech::isMech(%client))
	{
		return;
	}

	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) > 0)
		return;
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).vehicle != -1 && Client::getOwnedObject(%client).vehicle != "")
		return;
	if(Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		//-As long as your not reloading 
		if($Reloading[%client] != 1) {

			if(%weapon == Piller && player::Getitemcount(%client,%ammo) < 20)
			{
				return false;
			}
			//-New Code to allow you to switch to a Weap with an empty magazine, as long as you have more magazines to reload to.
			if(%ammo == "" || Player::getItemCount(%client,%ammo) > 0 || ($Clip[%weapon] != "" && Player::getItemCount(%client,$Clip[%weapon]) > 0))
				return true;
		}
	}
	return false;
}
//****END ICE'S NEW WEAPSWAP CHANGES****//
//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	%continue = false;

	if(%item == RLauncherClip && (Player::getArmor(%player) == sarmor || Player::getArmor(%player) == sfemale || Player::getArmor(%player) == sarmor2 || Player::getArmor(%player) == sfemale2))
	{
		if(player::getItemCount(%player, RLauncher) > 0 && player::getItemCount(%player, RLauncherAmmo) < 1 && player::getItemCount(%player, RLauncherClip) < 1)
		{
			%continue = 1;
		}
	}
	%client = Player::getClient(%player);
		
	if(%continue || (!$FaceDancerIsSwitched[%client] && ($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%player)], %armor, %item])) || ($FaceDancerIsSwitched[%client] && ($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[%client.impersonatingWhoTeam], %armor, %item]))) {
		if (%item.className == Backpack) {
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo+ %continue) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo + %continue) - %count;
			if (%delta > 0 || %continue) {
				Player::incItemCount(%player,%item,%delta);
				if ((%count == 0 && $AutoUse[%item]) || (%item.classname == Clip && $Clip[Player::getMountedItem(%player,$WeaponSlot)] == %item && player::getItemCount(%player,$WeaponAmmo[Player::getMountedItem(%player,$WeaponSlot)]) < 1))
				{
					Player::useItem(%player,%item);
				}
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
   }
	return 0;
}

//----------------------------------------------------------------------------
// Default Item object methods

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else {
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if (Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ "); if(Item::getItemData("@%this@")== FuelPack){"@ %this @".fuel = 100;}",$ItemRespawnTime,%this);
	}
	else { 
		deleteObject(%this);
	}
}	

function Item::onAdd(%this)
{
}


function Item::onCollision(%this,%object)
{
	if(Mech::isMech(%object))
	{
		return;
	}
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);

		%count = Player::getItemCount(%object,%item);
		%velThis = Item::getVelocity(%this);
		%VelObj = Item::getVelocity(%object);
		//%speedThis = sqrt(pow(getword(%velthis,0),2) + pow(getword(%velthis,1),2) + pow(getword(%velthis,2),2));
		%speedThis = vector::getdistance(%velthis,"0 0 0");

		//%speedObj = sqrt(pow(getword(%velobj,0),2) + pow(getword(%velobj,1),2) + pow(getword(%velobj,2),2));
		%speedObj = vector::getdistance(%velobj,"0 0 0");
		%speed = vector::subtract(%velthis,%velobj);
		//%speed = sqrt(pow(getword(%speed,0),2) + pow(getword(%speed,1),2) + pow(getword(%speed,2),2));
		%speed = vector::getdistance(%speed,"0 0 0");
		if((%item == Knife || %item == Knife2 || %item == Sliptip || %item == Crysknife || %item == Kindjal
		|| %item == Rapier || %item == Saber ) && %speedthis > 5 && %speed > 8 && %this.dangerous == true)
		{
			//%chance = ($WeapThrowCTH[%this.lastownerarmor] + $WeapThrowCTH[%item]) / 2;
			
			// New format. Only consider weapon type when throwing. 
			// We're increasing throw % and damage. Make this more worthwhile.
			%chance = $WeapThrowCTH[%item];
			
			if(floor(getrandom()*100) <= %chance )
			{
				if(%item == Sliptip )
					GameBase::applyDamage(%object, $ThrownPoisonWeaponDamageType, ($WeapProjectile[%item].damageValue)*(%speed/ 8)*1, gamebase::getposition(%this), "0 0 0", "0 0 0", %this.lastowner);
				else
					GameBase::applyDamage(%object, $ThrownWeaponDamageType, ($WeapProjectile[%item].damageValue)*(%speed/ 8)*2, gamebase::getposition(%this), "0 0 0", "0 0 0", %this.lastowner);
			}
	
		}
		else if (%item.className == Ammo)
		{}
		else if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			if($WeaponAmmo[%item] != "" && %item != Flamethrower && %item != Piller)
			{
				player::setitemcount(%object,$WeaponAmmo[%item],%this.ammocount);
				%this.ammocount = 0;
				
			} else if(%item == FuelPack)
			{
				player::setitemcount(%object,FlamethrowerAmmo,%this.fuel);
				%this.fuel = 0;
			}
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}




function Vector::Subtract(%vec1, %vec2)
{
	%vector = (getword(%vec1, 0) - getword(%vec2, 0) )@ " " @( getword(%vec1, 1) - getword(%vec2, 1) )@ " " @( getword(%vec1, 2) - getword(%vec2, 2));
	return %Vector;
}

//----------------------------------------------------------------------------
// Default Inventory methods

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{

	if($UA::grabbing[Player::getClient(%player)] != "" || $UA::grabbed[Player::getClient(%player)] != "")
		return;

	if(Mech::isMech(%player))
	{
		return;
	}
	//echo("Item used: ",%player," ",%item);
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	if($UA::grabbing[Player::getClient(%player)] != "" || $UA::grabbed[Player::getClient(%player)] != "")
		return;

	if(Mech::isMech(%player))
	{
		return;
	}
	if($matchStarted) {
		if(%item.className != Armor) {
			if($ShieldOn[%player]){
				Client::sendMessage(Player::getClient(%player),0,"Not with your shield up.");
				return false;
			}
			if(%item == MountedArtillaryGun || %Item == MountedMachineGun){
				Client::sendMessage(Player::getClient(%player),0,"This weapon cannot be dropped.");
				return false;
			}
			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			
			if(%item.classname == Weapon && $WeaponAmmo[%item] != "")
			{
				%obj.ammoCount = player::getItemCount(%player,$WeaponAmmo[%item]);
				player::setItemCount(%player,$WeaponAmmo[%item],0);
			}
			if(%item == FuelPack)
			{
				if(%player.lastfuel != -1)
				{
					%obj.Fuel = %player.lastfuel;//player::getItemcount(%player,FlamethrowerAmmo);
					%player.lastfuel = -1;
				}
				else
					%obj.Fuel = player::getItemcount(%player,FlamethrowerAmmo);
				
				player::setItemcount(%player,FlameThrowerAmmo,0);
			}
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else {
				%obj.dangerous = true;
				GameBase::throw(%obj,%player,15*$ThrowStrength[player::getarmor(%player)],false);
				Item::playPickupSound(%obj);
			}
			%obj.lastowner = Player::getClient(%player);
			%obj.lastownerarmor = player::getarmor(%player);
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}

//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	className = "Flag";
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
	className = "Flag";
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData SoldierArmor
{
   heading = "aArmor";
	description = "Soldier Armor";
	className = "Armor";
	price = 200;
};

ItemData TrooperArmor
{
   heading = "aArmor";
	description = "Trooper Armor";
	className = "Armor";
	price = 300;
};

ItemData FremenArmor
{
   heading = "aArmor";
	description = "Fremen Armor";
	className = "Armor";
	price = 500;
};

ItemData FedaykinArmor
{
   heading = "aArmor";
	description = "Fedaykin Armor";
	className = "Armor";
	price = 700;
};

ItemData SardaukarArmor
{
   heading = "aArmor";
	description = "Sardaukar Armor";
	className = "Armor";
	price = 500;
};

ItemData BasharArmor
{
   heading = "aArmor";
	description = "Bashar Armor";
	className = "Armor";
	price = 700;
};

ItemData BursegArmor
{
   heading = "aArmor";
	description = "Burseg Armor";
	className = "Armor";
	price = 700;
};

ItemData FaceDancerArmor
{
   heading = "aArmor";
	description = "FaceDancer Armor";
	className = "Armor";
	price = 700;
};


//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData BasicThopterVehicle
{
	description = "Spotter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 6000;
};

ItemData VulcanThopterVehicle
{
	description = "Vulcan mounted Thopter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 10000;
};

ItemData LasgunThopterVehicle
{
	description = "Lasgun mounted Thopter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 9000;
};

ItemData ArtillaryThopterVehicle
{
	description = "Artillary Thopter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 9000;
};

ItemData CarryallVehicle
{
	description = "Carryall";
	className = "Vehicle";
   heading = "aVehicle";
	price = 15000;
};

ItemData RollerVehicle
{
	description = "Roller";
	className = "Vehicle";
   heading = "aVehicle";
	price = 7000;
};

ItemData TrackerVehicle
{
	description = "Tracker";
	className = "Vehicle";
   heading = "aVehicle";
	price = 10000;
};

ItemData CrawlerVehicle
{
	description = "Crawler";
	className = "Vehicle";
   heading = "aVehicle";
	price = 11000;
};

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);	
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}

function Weapon::onUse(%player,%item)
{

	%client = Player::getclient(%player);
	if(player::Getitemcount(%client,MountedArtillaryGun) > 0 || player::Getitemcount(%client,MountedMachineGun) >0)
		return;
	if(Client::getOwnedObject(%client).vehicle && Client::getOwnedObject(%client).vehicle != -1 && Client::getOwnedObject(%client).vehicle != "")
		return;
	if(%player.Station == "") {
		%ammo = %item.imageType.ammoType;
		Player::mountItem(%player,%item,$WeaponSlot);
		//Weapon::descriptionMSG(%client,%item);
		if(%ammo < 0 && $Clip[%item] < 0)
			bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
		if(%ammo < 0 && $Clip[%item] > 0)
			Player::useItem(%player,$Clip[%item]);
	}
}

function Weapon::descriptionMSG(%clientId,%item)
{
	if($Reloading[%clientid] != 1 && $ShowWeapMountMsg[%clientId] != false) {
		if($FireModes[%item] == "") {
			bottomprint(%clientId,$WeapMountMSG[%item],10, %clientId);
			if( $WeapMountMSG2[%item] != "" )
				schedule("bottomprint(\"" @ %clientId @ "\",\"" @ $WeapMountMSG2[%item] @ "\",10);",10, %clientId);
			if( $WeapMountMSG3[%item] != "" )
				schedule("bottomprint(\"" @ %clientId @ "\",\"" @ $WeapMountMSG3[%item] @ "\",10);",20, %clientId);
		} else {
			%CurMode = $WeapMode[%clientId,%item];
			if(%CurMode == "")
				%CurMode = 1;
			bottomprint(%clientId,$WeapMountMSG[%item,%CurMode],10);
		}
	}
}

$WeapProjectile[Knife] = KnifeStab;
$WeapProjectile[Knife2] = KnifeStab;
$WeapProjectile[SlipTip] = SlipTipStab;
$WeapProjectile[Crysknife] = CrysknifeStab;
$WeapProjectile[Kindjal] = KindjalStab;
$WeapProjectile[Rapier] = RapierStab;
$WeapProjectile[Saber] = SaberStab;
$WeapProjectile[Pistol] = PistolBullet;
$WeapProjectile[Maula] = MaulaBullet;
$WeapProjectile[Stunner] = StunnerBullet;
$WeapProjectile[Rifle] = RifleBullet;
$WeapProjectile[Rifle2] = RifleBulletSingle;
$WeapProjectile[RLauncher] = StingerRocket;
$WeapProjectile[Flamethrower] = Flame;
$WeapProjectile[Piller] = PillerFlame;
$WeapProjectile[MGun] = RMachineBullet;
$WeapProjectile[MGun2] = RMachineBullet;
$WeapProjectile[SniperRifle] = SniperBullet;
$WeapProjectile[Cutteray] = CutterayLaser;
$WeapProjectile[SmallLas] = SLasgunLaser;
$WeapProjectile[RifleLas] = RLasgunLaser;
$WeapProjectile[HeavyLas] = HLasgunLaser;
$WeapProjectile[HeavyLas1] = HLasgunLaser;
$WeapProjectile[HeavyLas2] = HLasgunLaser;
$WeapProjectile[HeavyLas3] = HLasgunLaser;
$WeapProjectile[MountedArtillaryGun] = MortarTurretShell;
$WeapProjectile[MountedMachineGun] = RMachineBullet;

//-Engine onFire replicant by Ice
function Weapon::onFire(%player,%special,%Eat,%speed)
{
	%client = Player::getClient(%player);
//	if(client::getname(%client) == "[HC] Jesus")
//		echo("Firing");


	%vel = Item::getVelocity(%player);
	%armor = Player::getArmor(%player);
	%weap = Player::getMountedItem(%player,$WeaponSlot);
	
	%ammo = $WeaponAmmo[%weap];
	
	
	
	if(%ammo != "") {

		if(Player::getItemCount(%player,%ammo) < 1)
			return;
	}

	if((Player::isDead(%player) || %player.tackled) || ($IsBlocking[%player] 
		&& (%weap == Knife || %weap == Knife2 || %weap == Sliptip || %weap == Crysknife || %weap == Kindjal
		|| %weap == Rapier || %weap == Saber || %weap == RLauncher || %weap == Piller)))
	{
		Player::trigger(%player,$WeaponSlot);
		return; 	
	}

	if(GameBase::getLOSInfo(%player,10000) && !Player::isDead(%player))
	{
		%object = $los::object;
		%rot = GameBase::getRotation(%player);
		%targetPos = $los::position;
		%trans = GameBase::getMuzzleTransform(%player);
		%vec0 = getWord(%trans,0);
		%vec1 = getWord(%trans,1);
		%vec2 = getWord(%trans,2);
		%vec3 = getWord(%trans,6);
		%vec4 = getWord(%trans,7);
		%vec5 = getWord(%trans,8);
		%vec6 = getWord(%trans,9);
		%vec7 = getWord(%trans,10);
		%vec8 = getWord(%trans,11);
		%vecX = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
		%rot1 = %vec0@" "@%vec1@" "@%vec2;
		%rot2 = %vec3@" "@%vec4@" "@%vec5;
		%pos1 = %vec6@" "@%vec7@" "@%vec8;
		%rot0 = Vector::getRotAim(%Pos1,%targetPos);
		if(%speed == "")
			%speed = 1;
		%vec = Vector::getFromRot(%rot0,%speed);
		if(%targetPos)
			%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot0@" "@%pos1;
	
		// Hopefully will stop ais from causing nukes, and from shooting teammates to a degree.

//echo("Full: " @ (Player::isAiControlled(%player)

//			&& ((( %weap == Cutteray || %weap == SmallLas || %weap == RifleLas || %weap == HeavyLas)
//			&& %object.shieldStrength) || 
//			(gamebase::getteam(%object) == client::Getteam(%player)))));

		if(Player::isAiControlled(%player) 
			&& ((( %weap == Cutteray || %weap == SmallLas || %weap == RifleLas || %weap == HeavyLas)
			&& (%object.shieldStrength || %player.shieldstrength)) || 
			(gamebase::getteam(%object) == gamebase::Getteam(%player))
			|| %player.dontFire))
		{
				if(%player.dontfire == "" || %player.dontfire < 1 || %player.dontfire == false)
				{
					%player.dontfire = true;
					schedule(%player@".dontfire = false;",1);
					return;
				}else
				{
					return;
				}
		}
	} else
		%trans = GameBase::getMuzzleTransform(%player);
		%type = $WeapProjectile[%weap];
		if(%special != "" && %special != "0")
			%type = %special;

	%shieldactivated = %player.shieldStrength;
	// If we have a shield activated,
	if(%shieldactivated && ( %weap == Pistol || %weap == Maula || %weap == Rifle  || %weap == Rifle2 || %weap == SniperRifle || %weap == MGun2 || %weap == MGun || %weap == FlameThrower || %weap == Cutteray || %weap == SmallLas || %weap == RifleLas || %weap == HeavyLas || %weap == Piller || %weap  == RLauncher)) 
	{
		// Then shooting with anything fast is a mistake...
		if(%weap == Pistol || %weap == Maula || %weap == Rifle || %weap == Rifle2) {
			Projectile::spawnProjectile("ShieldDispOne", "0 0 0 0 0 0 0 0 0 " @ vector::add(GameBase::getposition(%player), "0 0 1.3"), %player, %vel);
		// Shooting with anything fast and large is a mistake (flamethrower sized mistake)
		} else if(%weap == SniperRifle || %weap == MGun || %weap == MGun2 || %weap == FlameThrower) {
			Projectile::spawnProjectile("ShieldDispTwo", "0 0 0 0 0 0 0 0 0 " @ vector::add(GameBase::getposition(%player), "0 0 1.3"), %player, %vel);
		// Shooting with anything REALLY BIG and fast is a mistake (Pillerflame sized mistake)
		} else if(%weap == Piller || %weap  == RLauncher) {
			Projectile::spawnProjectile("ShieldDispThree", "0 0 0 0 0 0 0 0 0 " @ vector::add(GameBase::getposition(%player), "0 0 1.3"), %player, %vel);
		// And shooting with a lasgun is well.... you definately deserve this you stupid moron.
		} else if(($nuketime[%client] == "" || $nuketime[%client]+0.5 <= getsimtime() ) && (%weap == Cutteray || %weap == SmallLas || %weap == RifleLas || %weap == HeavyLas)) {
			$JustNuked[%client, getIP(%client)] = true;
			NuclearExplosion(%player, false, 1);
			NukeCaused(%client);
			$nuketime[%client] = getsimtime();
		}
		GameBase::setEnergy(%player, 0);
	
	// Was fun and cool, but caused way to many problems, including lag.
	//} else if(%weap == MGun || %weap == MGun2 || %weap == MountedMachineGun || %weap == MechMachine2Gun || %weap == MechMachine4Gun || %weap == MechMachine1Gun || %weap == MechMachine3Gun)
	//{
	//
	//	%cl = %client;
	//	%vel = Item::getVelocity(%player);
	//	%trans = GameBase::getMuzzleTransform(%player);
	//	if(%weap == MechMachine2Gun || %weap == MechMachine4Gun || %weap == MechMachine1Gun || %weap == MechMachine3Gun)
	//	{
	//		%x = (getRandom() - getRandom()+0.0001)/(60);
	//		%y = (getRandom() - getRandom()+0.0001)/(60);
	//		%z = (getRandom() - getRandom()+0.0001)/(60);
	//	}
	//	else
	//	{
	//		%x = (getRandom() - getRandom()+0.0001)/(40);
	//		%y = (getRandom() - getRandom()+0.0001)/(40);
	//		%z = (getRandom() - getRandom()+0.0001)/(40);
	//	}
	//	
	//	%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ getWord(%trans,3)+%x @ " " @ 
	//		getWord(%trans,4)+%y @ " " @ getWord(%trans,5)+%z @ " " @ getWord(%trans,6) @ " " @ getWord(%trans,7) @ " " @ 
	//		getWord(%trans,8) @ " " @ getWord(%trans,9) @ " " @ getWord(%trans,10) @ " " @ getWord(%trans,11);
	//
	//	Projectile::spawnProjectile(MachineBullet, %trans, %player, %vel);
	//	Player::decItemCount(%player, MGunAmmo);
	}else if(%weap == MechArtillary1Gun || %weap == MechArtillary2Gun) 
	{
		%cl = %client;
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%x = (getRandom() - getRandom()+0.0001)/(40);
		%y = (getRandom() - getRandom()+0.0001)/(40);
		%z = (getRandom() - getRandom()+0.0001)/(40);
		
		%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ getWord(%trans,3)+%x @ " " @ 
			getWord(%trans,4)+%y @ " " @ getWord(%trans,5)+%z @ " " @ getWord(%trans,6) @ " " @ getWord(%trans,7) @ " " @ 
			getWord(%trans,8) @ " " @ getWord(%trans,9) @ " " @ getWord(%trans,10) @ " " @ getWord(%trans,11);

		Projectile::spawnProjectile(%type, %trans, %player, %vel);
	}else if(%weap == Mech3RLauncher || %weap == Mech4RLauncher) 
	{
	//echo("yes");
		if(GameBase::getLOSInfo(%player,10000))
		{
			%target = $los::object;
			if((GameBase::getDataName(%target)).maxDamage> 0)
				projectile::spawnProjectile(mechMissile,%trans,%player,%vel,%target);
			else
				Projectile::spawnProjectile(MechRocket, %trans, %player, %vel);
		} else
			Projectile::spawnProjectile(MechRocket, %trans, %player, %vel);
	} else if(%weap == RLauncher)
	{
		GameBase::getLOSInfo(%player, 1000);
		%target = $LOS::object;
		//if (GameBase::getDataName($los::object) == BasicThopter || GameBase::getDataName($los::object) == Vul|| GameBase::getDataName($los::object) == DiveBomber || GameBase::getDataName($los::object) == Fighter2 || GameBase::getDataName($los::object) == Blackhawk || GameBase::getDataName($los::object) == Warthog || GameBase::getDataName($los::object) == MoveWarthog || GameBase::getDataName($los::object) == Bomber || GameBase::getDataName($los::object) == Hercules || GameBase::getDataName($los::object) == Hind || GameBase::getDataName($los::object) == Gunship) {
		if(%target.vehicle)
		{
			bottomprint(Player::getClient(%player), "<f0><jc>Target Lock Achieved", 3);
			%proj = projectile::spawnProjectile(%type,%trans,%player,%vel,%target);
		} else {
			%x = (getRandom()+0.0001)*getword(%vel,0)/(15);
			%y = (getRandom()+0.0001)*getword(%vel,1)/(15);
			%z = (getRandom()+0.0001)*getword(%vel,2)/(15);
			if(%x > 0.4)
				%x = 0.4;
			else if(%x < -0.4)
				%x = -0.4;

			if(%y > 0.4)
				%y = 0.4;
			else if(%y < -0.4)
				%y = -0.4;

			if(%z > 0.4)
				%z = 0.4;
			else if(%z < -0.4)
				%z = -0.4;

			%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ getWord(%trans,3)+%x @ " " @ 
				getWord(%trans,4)+%y @ " " @ getWord(%trans,5)+%z @ " " @ getWord(%trans,6) @ " " @ getWord(%trans,7) @ " " @ 
				getWord(%trans,8) @ " " @ getWord(%trans,9) @ " " @ getWord(%trans,10) @ " " @ getWord(%trans,11);
			%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);
		}
	}else
	{
	 	%proj = projectile::spawnProjectile(%type,%trans,%player,%vel);
//	 	%proj = projectile::spawnProjectile(WormLightningCharge,%trans,%player,%vel);
		if(getObjectType(%proj) == LaserProjectile && $los::object) {
			%value = %type.damageConversion;
			if(GameBase::getEnergy(%player) > %weap.imageType.minEnergy)
				%value *= %weap.imageType.maxEnergy;
			//%pos = GameBase::getPosition($los::object);
			%pos = %targetPos;
			%vecI = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
			%mom = "0 0 0";
			%type = $DamageToLaser[%weap];
			
			GameBase::applyDamage($los::object,%type,%value,%pos,%vecI,%mom,%player);
		}
	}
	if(%weap == Rifle)
	{
		gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 -0.03"));
	}
	if(%weap == Pistol || %weap == Stunner || %weap == Maula || %weap == SniperRifle || %weap == Rifle2)
	{
		if(!Player::isAiControlled(%player))
			Player::trigger(%player,$WeaponSlot);
		if(%weap == Rifle2)
			gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 -0.005"));
		else if(%weap == Pistol)
			gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 -0.03"));
		else
			gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 -0.01"));
	}
	if(%weap == Mgun || MGun2)
	{
		if((getRandom()*100) < 60) //60% of the time go to the right
		{
			gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 -0.005"));
		} else // 40% go to the left
		{
			gamebase::Setrotation(%player,vector::add(gamebase::getrotation(%player),"0 0 0.005"));
		}
	}
	if(%ammo != "" && %Eat != False)
		Player::DecItemCount(%player,%ammo);
	//else if(%weap.imageType.maxEnergy != "")
	//	GameBase::setEnergy(%player,GameBase::getEnergy(%player)-%weap.imageType.maxEnergy);
	if($FifthElementGuns != 1)
		$los::position = "";
	$los::object = "";
	return %proj;
}

//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}

//----------------------------------------------------------------------------//
//-CLIPCODE BY ICE------------------------------------------------------------//
//----------------------------------------------------------------------------//

ItemData Clip
{
	description = "Clip";
	showInventory = false;
};

function Clip::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		if(%count > 0) {
			%obj = newObject("","Item",%item,1,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Clip::onUse(%player, %item)
{
	%client = Player::getclient(%player);
	%weapon = Player::getMountedItem(%player, $WeaponSlot);
	if($Clip[%weapon] != "" && Player::getItemState(%player,$WeaponSlot) != Spinup && Player::getItemState(%player,$WeaponSlot) != Fire && Player::getItemState(%player,$WeaponSlot) != SpinDown  ) {
		%clip = $Clip[%weapon];
		if(Player::getItemCount(%player,%clip) > 0)
			Reload(%player,%weapon,$ClipTime[%weapon]);
		else {
			if(%clip != "")
				bottomprint(%client, "<jc><f0>Out of Clips!!!", 2);
		}
	}
}

//-The actual reloading process
function Reload(%player,%weapon,%RDPer)
{
	%client = Player::getClient(%player);
	$Reloading[%client] = 1;
	Player::unMountItem(%player, %weapon);
	bottomprint(%client, "<jc><f0>Reloading...", %RDPer);
	schedule("ReloadTwo("@%player@","@%weapon@","@%RDPer@");",%RDPer-1.13);
	schedule("ReloadThree("@%player@","@%weapon@","@%RDPer@");",%RDPer/2);
	schedule("ReloadFour("@%player@","@%weapon@","@%RDPer@");",%RDPer);
	schedule("ReloadFive("@%player@","@%weapon@","@%RDPer@");",%RDPer++);
}

function ReloadTwo(%player,%weapon,%RDPer)
{
	%armor = Player::getArmor(%player);
	%item = %weapon;
	if(($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%player)], %armor, %item])) 
		Player::setAnimation(%player, 21);
}

function ReloadThree(%player,%weapon,%RDPer)
{
	%armor = Player::getArmor(%player);
	%item = %weapon;
	if(($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%player)], %armor, %item])) 
	{
		Player::setItemCount(%player,%weapon.imageType.ammoType,$ClipSize[%weapon]);
		Player::decItemCount(%player,$Clip[%weapon]);
	}
}

function ReloadFour(%player,%weapon,%RDPer)
{
	%armor = Player::getArmor(%player);
	%item = %weapon;
	if(($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%player)], %armor, %item]))
	{
		
			Player::useItem(%player,%weapon);			
		//else
		//	Player::MountItem(%player,%weapon,$WeaponSlot);
	}
}

function ReloadFive(%player,%weapon,%RDPer)
{
	// Always want to end reloading.
	%client = Player::getClient(%player);
	$Reloading[%client] = 0;
}

//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
}
function Ammo::onDropORIG(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	
//----------------------------------------------------------------------------
//***************************NEW WEAPONS SECTION******************************
//----------------------------------------------------------------------------

ItemImageData KnifeImage
{
   shapeFile  = "repairgun";
	mountRotation = { 0, 1.57, 0 };
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = KnifeStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Knife
{
	heading = "bBlades";
	description = "Knife";
	className = "Weapon";
	shapeFile  = "repairgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = KnifeImage;
	price = 20;
	showWeaponBar = true;
};


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


ItemImageData Knife2Image
{
   shapeFile  = "repairgun";
	mountRotation = { 0, 1.57, 0 };
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = KnifeStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Knife2
{
	heading = "bBlades";
	description = "Knife";
	className = "Weapon";
	shapeFile  = "repairgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = Knife2Image;
	price = 20;
	showWeaponBar = true;
};


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData SlipTipImage
{
   shapeFile  = "repairgun";
	mountRotation = { 0, -1.57, 0 };
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = SlipTipStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SlipTip
{
  	heading = "bBlades";
	description = "Slip-Tip";
	className = "Weapon";
	shapeFile  = "repairgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SlipTipImage;
	price = 50;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData CrysknifeImage
{
   shapeFile  = "paintgun";
	mountRotation = { 0, 1.57, 0 };
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = CrysknifeStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Crysknife
{
	heading = "bBlades";
	description = "Crysknife";
	className = "Weapon";
	shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = CrysknifeImage;
	price = 150;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData KindjalImage
{
   shapeFile  = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 0 };
	
	weaponType = 0; // Single Shot
	reloadTime = 0.4;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = KindjalStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Kindjal
{
	heading = "bBlades";
	description = "Kindjal";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = KindjalImage;
	price = 70;
	showWeaponBar = true;
};


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData RapierImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	
	weaponType = 0; // Single Shot
	reloadTime = 0.4;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = RapierStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Rapier
{
	heading = "bBlades";
	description = "Rapier";
	className = "Weapon";
	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = RapierImage;
	price = 80;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData SaberImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 1.57, 0 };
	
	weaponType = 0; // Single Shot
	reloadTime = 0.5;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;
	
	//projectileType = SaberStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Saber
{
	heading = "bBlades";
	description = "Saber";
	className = "Weapon";
	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SaberImage;
	price = 100;
	showWeaponBar = true;
};
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData PistolClip
{
        description = "Pistol Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 30;
};

ItemData PistolAmmo
{
	description = "Pistol Bullet";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PistolImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;

	ammoType = PistolAmmo;
	//projectileType = PistolBullet;
	accuFire = true;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Pistol
{
   heading = "cProjectile Weapons";
	description = "Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PistolImage;
	price = 800;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData MaulaClip
{
        description = "Maula Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 30;
};

ItemData MaulaAmmo
{
	description = "Maula Bullet";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData MaulaImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;

	ammoType = MaulaAmmo;
	//projectileType = MaulaBullet;
	accuFire = true;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Maula
{
   heading = "cProjectile Weapons";
	description = "Maula Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = MaulaImage;
	price = 500;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData StunnerClip
{
        description = "Stunner Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 200;
};

ItemData StunnerAmmo
{
	description = "Stunner Slug";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 100;
};

ItemImageData StunnerImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.8;

	ammoType = StunnerAmmo;
	//projectileType = StunnerBullet;
	accuFire = true;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Stunner
{
   heading = "cProjectile Weapons";
	description = "Stunner";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = StunnerImage;
	price = 1400;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData RifleClip
{
        description = "Rifle Clip"; //-"Rifle Belt" just didn't seem to fit in
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 150;
};

ItemData RifleAmmo
{
	description = "Rifle Bullet";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RifleAmmo;
	//projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.1;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Rifle
{
	description = "Semiautomatic Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = RifleImage;
	price = 1200;
	showWeaponBar = true;
};

ItemImageData RifleImage2
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RifleAmmo;
	//projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.35;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Rifle2
{
	description = "Semiautomatic Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = RifleImage2;
	price = 1200;
	showWeaponBar = true;
};


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemData MGunClip
{
        description = "Machine Gun belt";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 500;
};

ItemData MGunAmmo
{
	description = "MGun Bullet";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	ammoType = MGunAmmo;
	//projectileType = MachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.05;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MGun
{
	description = "Heavy Machine Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MGunImage;
	price = 3000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemImageData MGun2Image
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	ammoType = MGunAmmo;
	//projectileType = MachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 4;
	fireTime = 0.05;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MGun2
{
	description = "Heavy Machine Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MGun2Image;
	price = 3000;
	showWeaponBar = true;
};
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData SniperClip
{
        description = "Sniper Clip"; 
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 50;
};

ItemData SniperAmmo
{
	description = "Sniper Bullet";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	//projectileType = SniperBullet;
	accuFire = true;
	reloadTime = 0.7;
	fireTime = 0.1;

	sfxFire = ShockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 2000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


ItemData RLauncherClip
{
        description = "Rockets"; 
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 300;
};

ItemData RLauncherAmmo
{
	description = "Loaded Rockets";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 300;
};

ItemImageData RLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { 0, -0.5, 0.2 };

	weaponType = 0; // Single Shot
	ammoType = RLauncherAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData RLauncher
{
	description = "Rocket Launcher (SSM SAM)";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = RLauncherImage;
	price = 1500;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemData FlamethrowerAmmo
{
	description = "Napalm";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 8;
};

ItemImageData FlamethrowerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FlamethrowerAmmo;
	//projectileType = Flame;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Flamethrower
{
	description = "Flamethrower";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = FlamethrowerImage;
	price = 1500;
	showWeaponBar = true;
};

function Flamethrower::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FuelPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have a Fuel Pack to use the Flamethrower."); 
}

// Overload the weapon::onfire above, because.. it doesnt seem to work well with this...
function FlamethrowerImage::onfire(%player,%slot) 
{
	%proj = Projectile::spawnProjectile("Flame",gamebase::getmuzzletransform(%player),%player,Item::getVelocity(%player));
	%proj.owner = %player;
	Player::decItemcount(%player,FlamethrowerAmmo);
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemData PillerAmmo
{
	description = "Piller of Fire Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 200;
};

ItemImageData PillerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType =  FlamethrowerAmmo;
	//projectileType = PillerFlame;
	accuFire = True;
	reloadTime = 1.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Piller
{
	description = "Piller of Fire";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = PillerImage;
	price = 2000;
	showWeaponBar = true;
};

function Piller::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FuelPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Fuel Pack to use the Piller of Fire.");
}




function PillerImage::onFire(%player, %slot)
{
	if(player::getitemcount(%player, FlamethrowerAmmo) >= 20)
	{
		if(getword(gamebase::getmuzzletransform(%player),5) > 0.6666) {
			%proj = Projectile::spawnProjectile("PillerFlame",gamebase::getmuzzletransform(%player),%player,Item::getVelocity(%player));
			%proj.owner = %player;
			Player::decItemcount(%player,FlamethrowerAmmo,20);
		}
		else
			Client::sendMessage(GameBase::getControlClient(%player),0,"Piller must be at a minimum angle of 60 degrees.~waccess_denied.wav");
	} else
		Client::sendMessage(GameBase::getControlClient(%player),0,"Not enough fuel left for a shot.");
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData CutterayCell
{
        description = "Cutteray Cell";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 30;
};

ItemData CutterayAmmo
{
	description = "Cutteray Blast";
	className = "Ammo";
	shapeFile = "plasammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData CutterayImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0;
	ammotype = CutterayAmmo;
	//projectileType = CutterayLaser;
	accuFire = true;
	reloadTime = 0.075;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireTargetingLaser; 
	sfxActivate = SoundPickUpWeapon;
	accuFire = true;
	minEnergy = 0.0;
	maxEnergy = 5.0;
};

ItemData Cutteray
{
	description = "Cutteray";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "chaingun";
	heading = "dLasguns";
	shadowDetailMask = 4;
	imageType = CutterayImage;
	price = 400;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData SmallLasCell
{
        description = "Small Lasgun Cell";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 100;
};

ItemData SmallLasAmmo
{
	description = "Small Lasgun Blast";
	className = "Ammo";
	shapeFile = "plasammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SmallLasImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 1; // Spinning
	ammotype = SmallLasAmmo;
	//projectileType = SLasgunLaser;
	accuFire = true;
	reloadTime = 0.125;
	fireTime = 0;
	spinUptime = 0.0;
	spindowntime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireTargetingLaser; 
	sfxActivate = SoundPickUpWeapon;
	minEnergy = 0.0;
	maxEnergy = 5.0;
};

ItemData SmallLas
{
	description = "Small Lasgun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "chaingun";
	heading = "dLasguns";
	shadowDetailMask = 4;
	imageType = SmallLasImage;
	price = 750;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData RifleLasCell
{
        description = "Rifle Lasgun Cell";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 200;
};

ItemData RifleLasAmmo
{
	description = "Rifle Lasgun Blast";
	className = "Ammo";
	shapeFile = "plasammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RifleLasImage
{
	shapeFile = "grenadel";
	mountPoint = 0;

	weaponType = 1; // Spinning
	minEnergy = 0.0;
	maxEnergy = 5.0;
	ammotype = RifleLasAmmo;
	//projectileType = RLasgunLaser;
	accuFire = true;
	reloadTime = 0.125;
	fireTime = 0;
	spinUptime = 0.0;
	spindowntime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundRepairItem; 
	sfxActivate = SoundPickUpWeapon;
};

ItemData RifleLas
{
	description = "Rifle Lasgun";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "chaingun";
   heading = "dLasguns";
	shadowDetailMask = 4;
	imageType = RifleLasImage;
	price = 1000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemData HeavyLasCell
{
        description = "Heavy Lasgun Cell";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "wClips";
        shadowdetailmask = 4;
        price = 400;
};

ItemData HeavyLasAmmo
{
	description = "Heavy Lasgun Blast";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData HeavyLasImage
{
	shapeFile = "mortargun"; //-No more animation!
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0 };

	weaponType = 1; // Spinning
	minEnergy = 0.0;
	maxEnergy = 5.0;
	ammotype = HeavyLasAmmo;
	//projectileType = HLasgunLaser;
	accuFire = true;
	reloadTime = 0.125;
	fireTime = 0;
	spinUptime = 0.0;
	spindowntime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetHeavy; 
	sfxActivate = SoundPickUpWeapon;
	sfxIdle = SoundMortarIdle;
};

ItemData HeavyLas
{
	description = "Heavy Lasgun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "chaingun";
	heading = "dLasguns";
	shadowDetailMask = 4;
	imageType = HeavyLasImage;
	price = 1300;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


ItemImageData MountedMachineGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	weaponType = 1; // Spin
	//projectileType = MachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.05;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MountedMachineGun
{
	description = "Heavy Machine Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MountedMachineGunImage;
	price = 3000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData MountedArtillaryGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.5, 0, -0.05 };

	weaponType = 0; // Single Shot
	reloadTime = 5.0;
	fireTime = 0.0;

	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	//projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundArtillaryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData MountedArtillaryGun
{
	description = "Artillary Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MountedArtillaryGunImage;
	price = 5000;
	showWeaponBar = true;
};

//function MountedArtillaryGunImage::onfire(%client){echo("Firing");}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// MechWeapons
//---------------------------------------------------


ItemImageData MechMachineGunTriggerImage
{
	shapeFile = "breath";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundDryFire;
	firstPerson = false;
};

ItemData MechMachineGunTrigger
{
	description = "Mech Machine Gun Trigger";
	className = "Backpack";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechMachineGunTriggerImage;
	price = 3000;
	showWeaponBar = true;
};

ItemImageData MechMachineGunTrigger2Image
{
	//mountOffset = { -3, -0.3, 0.1 };
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = MachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0.05;

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemImageData MechNullGunImage
{
	//mountOffset = { 0, -0.3, 0.1 };
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = RMachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 1;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MechNullGun
{
	description = "Mech Null Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechNullGunImage;
	price = 3000;
	showWeaponBar = true;
};

ItemImageData MechMachine1GunImage
{
	mountOffset = { 0, -0.3, 0.1 };
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = RMachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MechMachine1Gun
{
	description = "Mech Machine Gun 1";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechMachine1GunImage;
	price = 3000;
	showWeaponBar = true;
};

ItemImageData MechMachine2GunImage
{
	mountOffset = { 0, -0.45, 0.5 };
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = RMachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MechMachine2Gun
{
	description = "Mech Machine Gun 2";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechMachine2GunImage;
	price = 3000;
	showWeaponBar = true;
};

ItemImageData MechMachine3GunImage
{
	mountOffset = { -1.2, -0.3, 0.1 };
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = RMachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MechMachine3Gun
{
	description = "Mech Machine Gun 3";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechMachine3GunImage;
	price = 3000;
	showWeaponBar = true;
};

ItemImageData MechMachine4GunImage
{
	mountOffset = { -1.2, -0.45, 0.5 };
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spin
	//projectileType = RMachineBullet;
	accuFire = false;
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 4;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MechMachine4Gun
{
	description = "Mech Machine Gun 4";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechMachine4GunImage;
	price = 3000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData MechArtillary1GunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.2 };

	weaponType = 0; // Single Shot
	reloadTime = 5.0;
	fireTime = 0.0;

	//projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundArtillaryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData MechArtillary1Gun
{
	description = "Mech Artillary Gun 1";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MechArtillary1GunImage;
	price = 5000;
	showWeaponBar = true;
};

ItemImageData MechArtillary2GunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.2 };

	weaponType = 0; // Single Shot
	reloadTime = 5.0;
	fireTime = 0.0;

	//projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundArtillaryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData MechArtillary2Gun
{
	description = "Mech Artillary Gun 2";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MechArtillary2GunImage;
	price = 5000;
	showWeaponBar = true;
};

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
ItemImageData MechRLauncherTriggerImage
{
	shapeFile = "breath";
	mountPoint = 2;
	weaponType = 2;  // 
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundDryFire;
	firstPerson = false;
};

ItemData MechRLauncherTrigger
{
	description = "Mech Rocket Launcher Trigger";
	className = "Backpack";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = MechRLauncherTriggerImage;
	price = 3000;
	showWeaponBar = true;
};


ItemImageData Mech1RLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountRotation = { 0, 0, 0 };
	mountOffset = { 0, -0.3, 0.0 };

	weaponType = 0; // Single Shot
	ammoType = RLauncherAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Mech1RLauncher
{
	description = "Mech Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mech1RLauncherImage;
	price = 1500;
	showWeaponBar = true;
};

ItemImageData Mech2RLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountRotation = { 0, -1.57, 0 };
	mountOffset = { -1.2, -0.3, 0.0 };

	weaponType = 0; // Single Shot
	ammoType = RLauncherAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Mech2RLauncher
{
	description = "Mech Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mech2RLauncherImage;
	price = 1500;
	showWeaponBar = true;
};

ItemImageData Mech3RLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountRotation = { 0, -1.57, 0 };
	mountOffset = { -0.25, -0.7, 0.5 };

	weaponType = 0; // Single Shot
	ammoType = RLauncherAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Mech3RLauncher
{
	description = "Mech Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mech3RLauncherImage;
	price = 1500;
	showWeaponBar = true;
};

ItemImageData Mech4RLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	//mountRotation = { 0, -1.57, 0 };
	mountOffset = { -0.95, -0.7, 0.5 };

	weaponType = 0; // Single Shot
	ammoType = RLauncherAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Mech4RLauncher
{
	description = "Mech Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = Mech4RLauncherImage;
	price = 1500;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
//OLD WEAPONS
//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};


//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	//projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = false;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};


//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	//projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = false;
};


//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	//projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = false;
};


//----------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	//projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = false;
};


//----------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	//projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};


//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = false;
   validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle."); 
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = false;
};

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 0.001;
	maxEnergy = 0.1;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
   validateShape = false;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}


//----------------------------------------------------------------------------
//***************************NEW BACKPACKS SECTION******************************
//----------------------------------------------------------------------------

ItemImageData GrappleHookImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 1; // Sustained
	//projectileType = Grapple;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.08;
	reloadTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime   = 1;
	lightColor  = { 0, 0, 0 };

	//sfxFire     = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

function GrappleHookImage::onFire(%player, %slot)
{
	%clientPos = GameBase::getPosition(%player);

	if((getSimTime() - $HookTime[%player]) < 0.5)
	{
		// Spawn the rope
		%transform = GameBase::getMuzzleTransform(%player);
		Projectile::spawnProjectile("Grapple", %transform, %player, "0 0 0");

		%zDist = getWord($HookPos[%player], 2) - getWord(%clientPos, 2);
		//if(%zDist >= 5)
		//{
			// if we have an angle of more then 60, continue. If you want to change it to more then 60 deg, or less then
			// 60 deg, then simply caclulate sin(angle) and round up, and stick the number in. I may later make this a variable
			// to make changing it easier. (just change it from config.cs, or game.cs or something)
			if( (%zDist / Vector::getDistance(%clientPos, $HookPos[%player]) ) >= 0.86603 ) { 
				// Climb it
				%dir = Vector::sub($HookPos[%player], %clientPos);
				%dir = Vector::normalize(%dir);
				if(getword(Item::getVelocity(%player),2) < 10)
					%dir = Vector::scale(%dir, 30);
			}			
		//}
		// If the player has grabbed a moving object, inherit its velocity
		if($HookObject[%player])
			%dir = Vector::add(%dir, Item::getVelocity($HookObject[%player]));
					
		Player::applyImpulse(%player, %dir);
		
		$HookTime[%player] = getSimTime();		
	} else
	{
		if(GameBase::getLOSInfo(%player, 1000))
		{
			if(Vector::getDistance(%clientPos, $los::position) <= 50)
			{
						if(getObjectType($los::object) != "Player")
						{
							$HookObject[%player] = 0;
							$HookPos[%player] = $los::position;
							$UsingHook[%player] = 1;
							
							// Spawn the rope
							%transform = GameBase::getMuzzleTransform(%player);
							Projectile::spawnProjectile("Grapple", %transform, %player, "0 0 0");

							%zDist = getWord($los::position, 2) - getWord(%clientPos, 2);
							if(%zDist >= 5)
							{
								// if we have an angle of more then 60, continue. If you want to change it to more then 60 deg, or less then
								// 60 deg, then simply caclulate sin(angle) and round up, and stick the number in. I may later make this a variable
								// to make changing it easier. (just change it from config.cs, or game.cs or something)
								if( (%zDist / Vector::getDistance(%clientPos, $los::position) ) >= 0.86603 ) { 
									// Climb it
									%dir = Vector::sub($los::position, %clientPos);
									%dir = Vector::normalize(%dir);
									%dir = Vector::scale(%dir, 30);
								}
							}
							// If the player has grabbed a moving object, inherit its velocity
							if($los::object > 1000)
							{
								$HookObject[%player] = $los::object;
								%dir = Vector::add(%dir, Item::getVelocity($HookObject[%player]));
							}

							Player::applyImpulse(%player, %dir);
					
							$HookTime[%player] = getSimTime();
						}
					
				
			}
		}
	}
}

ItemData GrappleHook
{
	description   = "Grappling Hook";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = GrappleHookImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData GrapplePackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData GrapplePack
{
	description = "Grappling Hook";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = GrapplePackImage;
	price = 100;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GrapplePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == GrappleHook) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function GrapplePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,GrappleHook,$WeaponSlot);
	}
}

function GrapplePack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == GrappleHook) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Grappling Hook
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData FuelPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData FuelPack
{
	description = "Fuel Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = FuelPackImage;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FuelPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FuelPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FuelPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamethrower || Player::getMountedItem(%player,$WeaponSlot) == Piller) 
		Player::unmountItem(%player,$WeaponSlot);
}


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData ExplosivePackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ExplosivePack
{
	description = "Explosive Charge Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "fBackPacks";
	shadowDetailMask = 4;
	imageType = ExplosivePackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ExplosivePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}

function ExplosivePack::onDeploy(%player,%item,%pos)
{
	if (ExplosivePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function ExplosivePack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	//if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Explosive Charge","StaticShape","DefaultCharge",true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Charge::onEnabled(%camera);
					Client::sendMessage(%client,0,"Explosive Charge placed - 15 seconds until detonation");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Charge"]++;
					echo("MSG: ",%client," placed an Explosive Charge");
					Client::setOwnedObject(%client, %camera); 
					Client::setOwnedObject(%client, %player);
					%camera.owner = %player;
					%camera.client = %client;
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	//}
	//else																						  
	// 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData SuicidePackImage
{
	shapeFile = "ammoPack";
	mountPoint = 2;
	weaponType = 0;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SuicidePack
{
	description = "Suicide Pack";
	shapeFile = "ammoPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = SuicidePackImage;
	price = 700;
	hudIcon = "plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		%transform = "0 0 0 0 0 0 0 0 0 " @ Vector::add(GameBase::getPosition(%player), "0 0 3");
		Player::decItemCount(%player,%item);
		$SuicideCount[getIP(gamebase::Getcontrolclient(%player))]++;
		$JustSuicided[getIP(gamebase::getcontrolclient(%player))] = true;
		Projectile::spawnProjectile(SuicideShell, %transform, %player, "0 0 0");
	}
}

function SuicidePackImage::onActivate(%player,%imageSlot)
{
	%transform = "0 0 0 0 0 0 0 0 0 " @ GameBase::getPosition(%player);
	Player::decItemCount(%player,%itemSlot);
		$SuicideCount[getIP(gamebase::Getcontrolclient(%player))]++;
	$JustSuicided[getIP(gamebase::getcontrolclient(%player))] = true;
	Projectile::spawnProjectile(SuicideShell, %transform, %player, "0 0 0");

}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData SuspensorPack2Image
{
	shapeFile = "breath";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundDiscSpin;
	firstPerson = false;
};

ItemData SuspensorPack2
{
	description = "Suspensor Pack";
	shapeFile = "JetPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = SuspensorPack2Image;
	price = 100;
	hudIcon = "Suspensorpack";
	showWeaponBar = false;
	hiliteOnActive = false;
   validateShape = false;
   validateMaterials = true;
};


ItemImageData SuspensorPackImage
{
	shapeFile = "jetPack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundPickupItem;
	firstPerson = false;
};

ItemData SuspensorPack
{
	description = "Suspensor Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = SuspensorPackImage;
	price = 1200;
	hudIcon = "disk";
	showWeaponBar = true;
	hiliteOnActive = true;
};

// Well that was fun! Did you know switching to a different armor breaks the execution of onActivate and executes deactivate?
// Yep..... thats why this mess is here.
function SuspensorPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		if( $TimeSuspensorOn[%player] )
			%item.timeUsed = $TimeSuspensorOn[%player];
		$TimeSuspensorOn[%player] = 0;
		Client::sendMessage(Player::getClient(%player),0,"Suspensor Pack dropped; Deactivating.");
		disableSuspensorPack(%player);
		Player::trigger(%player,4,false);
		Player::UnMountItem(%player, 4);
		
	}
}

function SuspensorPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			if( %this.timeUsed )
				$TimeSuspensorOn[%object] = %this.timeUsed;
			else 
				$TimeSuspensorOn[%object] = 1;
			Item::respawn(%this);
		}
	}
}

function SuspensorPackImage::onactivate(%player, %imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	if((getSimTime() - %player.packTime) > 1 || !%player.packTime)
	{
		%player.packTime = getSimTime();
		if($SuspensorActivate[%player] != 1) { // then its off. Turn it on
			Client::sendMessage(Player::getClient(%player),0,"Suspensor Pack On");
			$SuspensorActivate[%player] = 1;
			ActivateJets(player::getClient(%player));
			//switch their armors, and set the switch on
			suspensorTick(%player, %imageSlot);
			if(Player::getArmor(%player) == "ssarmor")
				Player::setArmor(%player,ssarmor2);
	   		else if(Player::getArmor(%player) == "barmor")
				Player::setArmor(%player,barmor2);
	   		else if(Player::getArmor(%player) == "bbarmor")
				Player::setArmor(%player,bbarmor2);
			else if(Player::getArmor(%player) == "sarmor")
				Player::setArmor(%player,sarmor2);
			else if(Player::getArmor(%player) == "ssfemale")
				Player::setArmor(%player,ssfemale2);
			else if(Player::getArmor(%player) == "bfemale")
				Player::setArmor(%player,bfemale2);
			else if(Player::getArmor(%player) == "bbfemale")
				Player::setArmor(%player,bbfemale2);
			else if(Player::getArmor(%player) == "sfemale")
				Player::setArmor(%player,sfemale2);
			Player::MountItem(%player, SuspensorPack2, 4);
			Player::trigger(%player,4,true);

		} else { // Then its on, lets turn it off.
		
			Client::sendMessage(Player::getClient(%player),0,"Suspensor Pack Off");
			Player::trigger(%player,$BackpackSlot,false);
			disableSuspensorPack(%player);
			Player::trigger(%player,4,false);
			Player::UnMountItem(%player, 4);

		}
	}
	// Doesnt matter what gets called here! it will never be executed! HA!

}



function SuspensorPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


function suspensorTick(%client,%imageSlot) {
	if(!$TimeSuspensorOn[%client] || $TimeSuspensorOn[%client] < 1 ) {
		$TimeSuspensorOn[%client] = 1;
		schedule("suspensorTick(" @ %client @ "," @ %imageSlot @ ");", 0.5);	
	} else if($TimeSuspensorOn[%Client] <= 120 && $SuspensorActivate[%client] == 1) {
		$TimeSuspensorOn[%client]++;
		schedule("suspensorTick(" @ %client @ "," @ %imageSlot @ ");", 0.5);
	} else if($TimeSuspensorOn[%client] > 120) {
		$TimeSuspensorOn[%client] = 0;
		deactivateSuspensorPack(%client);
	}

	// Check for height
	// Don't check for height any longer. Doesn't work very well.
	//%playerPos = GameBase::getPosition(%client);
	//%playerZ = getword(%playerPos, 2);
	//if(%playerZ >= 100)
	//{
	//	GameBase::setEnergy(%client,76);
	//} else {
	//	GameBase::setEnergy(%client,80);
	//}			


}

function disableSuspensorPack(%client) 
{
	$SuspensorActivate[%client] = 0;
	DeactivateJets(player::getClient(%client));
	if(Player::getArmor(%client) == "ssarmor2")
		Player::setArmor(%client,ssarmor);
   	else if(Player::getArmor(%client) == "barmor2")
		Player::setArmor(%client,barmor);
   	else if(Player::getArmor(%client) == "bbarmor2")
		Player::setArmor(%client,bbarmor);
	else if(Player::getArmor(%client) == "sarmor2")
		Player::setArmor(%client,sarmor);
	else if(Player::getArmor(%client) == "ssfemale2")
		Player::setArmor(%client,ssfemale);
	else if(Player::getArmor(%client) == "bfemale2")
		Player::setArmor(%client,bfemale);
	else if(Player::getArmor(%client) == "bbfemale2")
		Player::setArmor(%client,bbfemale);
	else if(Player::getArmor(%client) == "sfemale2")
		Player::setArmor(%client,sfemale);

}

function deactivateSuspensorPack(%client) {
	Client::sendMessage(Player::getClient(%client),0,"Suspensor Pack out of power; Deactivating.");
	disableSuspensorPack(%client);
	$SuspensorActivate[%client] = 0;
	$TimeSuspensorOn[%client] = 0;
	Player::setItemCount(%client,SuspensorPack,0);
	Player::trigger(Player::getClient(%client),4,false);
	Player::UnMountItem(Player::getClient(%client), 4);
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData CamoPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundCamo;
	firstPerson = false;
};

ItemData CamoPack
{
	description = "Camo Pack";
	shapeFile = "ammoPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = CamoPackImage;
	price = 300;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};


StaticShapeData CamoPos
{
	shapeFile = "breath";
	maxDamage = 1.0;
	shadowDetailMask = 16;
        explosionId = knifeExp;
	description = "Fremen";
	visibleToSensor = false;
        mapFilter = 4;
        damageSkinData = "ArmorDamageSkins";
};

function CamoPos::OnDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%object && getObjectType(%object) == "Flier") {
		%object = %object.clLastMount;
	}
	if(%type == $LaserDamageType) {
		%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(%this,%object) == "Same")
			%value = 0;
	}
	//-Laser Range Damage Multiplier
	if(%type == $CutterayDamageType || %type == $SmallLasDamageType || %type == $RifleLasDamageType || %type == $HeavyLasDamageType || %type == $LaserDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			%value -= %rate;
		}
		if(%value <= 0.00005)
			%value = 0;
	}
	if($damageScale[Player::getArmor($Camobeacontoplayer[%this]), %type])
		%value *= $damageScale[Player::getArmor($Camobeacontoplayer[%this]), %type];	
	%damageLevel = GameBase::getDamageLevel(%this);
	%dValue = %damageLevel + %value;
	%this.lastDamageObject = %object;
	$Camobeacontoplayer[%this].lastcamodamager = %object;
	%this.lastDamageTeam = GameBase::getTeam(%object);
	$Camobeacontoplayer[%this].lastcamodamagetype = %Type;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)) {
		%name = GameBase::getDataName(%this);
		%TDS = $Server::TeamDamageScale;
		%dValue = %damageLevel + %value * %TDS;
		
		%curTime = getSimTime();
		if(%dvalue > 0 && (%curTime - %this.DamageTime > 3.5 || %this.lastDamageObject != %object) && $Camobeacontoplayer[%this] != %object && $Server::TeamDamageScale > 0) {
			Client::sendMessage(%object,0,"You just harmed Teammate " @ Client::getName($Camobeacontoplayer[%this]) @ "!");
			Client::sendMessage($Camobeacontoplayer[%this],0,"You took Friendly Fire from " @ Client::getName(%object) @ "!");
			%this.DamageStamp = %curTime;
		}


	}
	GameBase::setDamageLevel(%this,%dValue);

}

function CamoPos::onDestroyed(%this)
{
	$CamoPosDead[%this@""] = true;
	CamoPackUnBury($Camobeacontoplayer[%this],gamebase::getposition(%this),%this.lastDamageObject);

}



// When activated, its going to "bury" the person in the sand. And probably give them an OOC view.
function CamoPackImage::onactivate(%player, %imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	if((getSimTime() - %player.packTime) > 1 || !%player.packTime)
	{
		%player.packTime = getSimTime();

		//Check to make sure they are on the sand.
		if(!Worm::inWormBox(gamebase::Getposition(%player)) && GameBase::getLOSInfo(%player,100,"-1.570796327 0 0"))
		{
			if(getObjectType($los::object) == "SimTerrain" && vector::Getdistance($los::position, gamebase::getposition(%player)) < 3)
			{
				if($CamoActivate[%player] != 1) { // then its off. Turn it on
					Client::sendMessage(Player::getClient(%player),0,"Camo Pack On");
					//Bury the person.
					CamoPackBury(%player);					


				} else { // Then its on, lets turn it off.
			
					Client::sendMessage(Player::getClient(%player),0,"Camo Pack Off");
					Player::trigger(%player,$BackpackSlot,false);
					//Restore the person
					CamoPackUnBury(%player);
				}
			} else
				Client::sendMessage(Player::getClient(%player),0,"You must be on sand to use the camo pack.");		
		} else
			Client::sendMessage(Player::getClient(%player),0,"You must be on sand to use the camo pack.");
	}
	// Doesnt matter what gets called here! it will never be executed! HA!

}



function CamoPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

// Turns the pack on.
function CamoPackBury(%client) 
{
	
	Player::trigger(%client,$WeaponSlot,false);
	//GameBase::playSound(%client,Soundflagfa,3);
	$CamoActivate[%client] = 1;
	$CamoBody[Player::getClient(%client)] = %client;
	
	%CamoGuy = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy1 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy2 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy3 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy4 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy5 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy6 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy7 = newObject("Fremen", "StaticShape", "CamoPos", true);
	%CamoGuy8 = newObject("Fremen", "StaticShape", "CamoPos", true);

	$CamoPosDead[%CamoGuy@""] = false;
	$CamoPosDead[%CamoGuy1@""] = false;
	$CamoPosDead[%CamoGuy2@""] = false;
	$CamoPosDead[%CamoGuy3@""] = false;
	$CamoPosDead[%CamoGuy4@""] = false;
	$CamoPosDead[%CamoGuy5@""] = false;
	$CamoPosDead[%CamoGuy6@""] = false;
	$CamoPosDead[%CamoGuy7@""] = false;
	$CamoPosDead[%CamoGuy8@""] = false;

	addToSet("MissionCleanup", %camoguy);
	addToSet("MissionCleanup", %camoguy1);
	addToSet("MissionCleanup", %camoguy2);
	addToSet("MissionCleanup", %camoguy3);
	addToSet("MissionCleanup", %camoguy4);
	addToSet("MissionCleanup", %camoguy5);
	addToSet("MissionCleanup", %camoguy6);
	addToSet("MissionCleanup", %camoguy7);
	addToSet("MissionCleanup", %camoguy8);
	GameBase::setTeam(%camoguy,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy1,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy2,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy3,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy4,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy5,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy6,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy7,GameBase::getTeam(%client));
	GameBase::setTeam(%camoguy8,GameBase::getTeam(%client));
	GameBase::setPosition(%camoguy,vector::add(gamebase::getposition(%client),"0 0 0.5"));
	GameBase::setPosition(%camoguy1,vector::add(gamebase::getposition(%client),"0 0.5 0.5"));
	GameBase::setPosition(%camoguy2,vector::add(gamebase::getposition(%client),"0.5 0 0.5"));
	GameBase::setPosition(%camoguy3,vector::add(gamebase::getposition(%client),"0.5 0.5 0.5"));
	GameBase::setPosition(%camoguy4,vector::add(gamebase::getposition(%client),"0 -0.5 0.5"));
	GameBase::setPosition(%camoguy5,vector::add(gamebase::getposition(%client),"-0.5 0 0.5"));
	GameBase::setPosition(%camoguy6,vector::add(gamebase::getposition(%client),"-0.5 -0.5 0.5"));
	GameBase::setPosition(%camoguy7,vector::add(gamebase::getposition(%client),"-0.5 0.5 0.5"));
	GameBase::setPosition(%camoguy8,vector::add(gamebase::getposition(%client),"0.5 -0.5 0.5"));
	Gamebase::setMapName(%camoguy,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy1,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy2,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy3,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy4,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy5,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy6,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy7,gamebase::Getmapname(%client));
	Gamebase::setMapName(%camoguy8,gamebase::Getmapname(%client));
   	$Camobeacon[%client] = %camoguy;
   	$Camobeacon1[%client] = %camoguy1;
   	$Camobeacon2[%client] = %camoguy2;
   	$Camobeacon3[%client] = %camoguy3;
   	$Camobeacon4[%client] = %camoguy4;
   	$Camobeacon5[%client] = %camoguy5;
   	$Camobeacon6[%client] = %camoguy6;
   	$Camobeacon7[%client] = %camoguy7;
   	$Camobeacon8[%client] = %camoguy8;
	$Camobeacontoplayer[%camoguy] = %client;
	$Camobeacontoplayer[%camoguy1] = %client;
	$Camobeacontoplayer[%camoguy2] = %client;
	$Camobeacontoplayer[%camoguy3] = %client;
	$Camobeacontoplayer[%camoguy4] = %client;
	$Camobeacontoplayer[%camoguy5] = %client;
	$Camobeacontoplayer[%camoguy6] = %client;
	$Camobeacontoplayer[%camoguy7] = %client;
	$Camobeacontoplayer[%camoguy8] = %client;
	Gamebase::setDamageLevel(%camoguy, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy1, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy2, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy3, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy4, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy5, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy6, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy7, GameBase::getDamageLevel(%client));
	Gamebase::setDamageLevel(%camoguy8, GameBase::getDamageLevel(%client));
	
	   
	Client::setControlObject(Player::getClient(%client), Client::getObserverCamera(Player::getClient(%client)));
	Observer::setOrbitObject(Player::getClient(%client), %camoguy, 5, 5, 5);
//$PlayerAnim::DieForward
//$PlayerAnim::DieHead
//$PlayerAnim::DieGrabBack
//$PlayerAnim::DieLeftSide
//$PlayerAnim::DieRightSide
	Player::setAnimation(%client,$playerAnim::DieForward); //7(8)
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.1");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.0);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.2");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.1);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.3");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.2);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.4");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.3);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.5");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.4);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.6");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.5);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -0.7");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.6);
	%newPos = vector::Add(gamebase::getposition(%client),"0 0 -10");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",1.7);
	
	
}

// Turns the pack off.
function CamoPackUnBury(%client,%position) 
{
	//GameBase::playSound(%client,SoundCamo,3);
	Client::sendMessage(Player::getClient(%client),0,"Camo Pack Off");
	Player::trigger(%client,$BackpackSlot,false);
	$CamoActivate[%client] = 0;
	Client::setControlObject(Player::getClient(%client), %client);
	item::setvelocity(%client, "0 0 0");	
	%camopos = $Camobeacon[%client];	
	%camopos1 = $Camobeacon1[%client];	
	%camopos2 = $Camobeacon2[%client];	
	%camopos3 = $Camobeacon3[%client];	
	%camopos4 = $Camobeacon4[%client];	
	%camopos5 = $Camobeacon5[%client];	
	%camopos6 = $Camobeacon6[%client];	
	%camopos7 = $Camobeacon7[%client];	
	%camopos8 = $Camobeacon8[%client];

	if(%position && %position != "" ) {
		//Gamebase::setDamageLevel(%client, 0.9);
		%camobeacon = %position;
		
	} else {
		Gamebase::setDamageLevel(%client, GameBase::getDamageLevel(%camopos));
		%camobeacon = gamebase::getposition(%camopos);
	}
	

	%newPos = vector::Add(%camobeacon,"0 0 -1.5");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.1);
	schedule("GameBase::playSound(\""@%client@"\",SoundCamo,3);",0.11);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %camobeacon;
	schedule ("Projectile::spawnProjectile(Dust, \"" @ %trans @ "\", \"" @ 2048 @ "\", \"" @ "0 0 0" @ "\");",0.1);
	%newPos = vector::Add(%camobeacon,"0 0 -1.3");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.2);
	%newPos = vector::Add(%camobeacon,"0 0 -1.1");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.3);
	%newPos = vector::Add(%camobeacon,"0 0 -0.9");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.4);
	%newPos = vector::Add(%camobeacon,"0 0 -0.7");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.5);
	%newPos = vector::Add(%camobeacon,"0 0 -0.49");
	schedule("gamebase::setposition(\""@%client@"\",\""@%newPos@"\");",0.6);
	
	if(!%position || %position == "" ){
		schedule("deletecamopos(\""@%camopos@"\");",0.7);
		schedule("deletecamopos(\""@%camopos1@"\");",0.7);
		schedule("deletecamopos(\""@%camopos2@"\");",0.7);
		schedule("deletecamopos(\""@%camopos3@"\");",0.7);
		schedule("deletecamopos(\""@%camopos4@"\");",0.7);
		schedule("deletecamopos(\""@%camopos5@"\");",0.7);
		schedule("deletecamopos(\""@%camopos6@"\");",0.7);
		schedule("deletecamopos(\""@%camopos7@"\");",0.7);
		schedule("deletecamopos(\""@%camopos8@"\");",0.7);
	}else {		
		%null = "0 0 0";
		%pos1 = gamebase::getposition(%client);
		%type = %client.lastcamodamagetype;
		%killer = %client.lastcamodamager;
		schedule("GameBase::applyDamage(\""@%client@"\",\""@%type@"\",\""@1.5@"\",\""@%pos1@"\",\""@%null@"\",\""@%null@"\",\""@%killer@"\");",0.6);

		schedule("deletecamopos(\""@%camopos@"\");",0.7);
		schedule("deletecamopos(\""@%camopos1@"\");",0.7);
		schedule("deletecamopos(\""@%camopos2@"\");",0.7);
		schedule("deletecamopos(\""@%camopos3@"\");",0.7);
		schedule("deletecamopos(\""@%camopos4@"\");",0.7);
		schedule("deletecamopos(\""@%camopos5@"\");",0.7);
		schedule("deletecamopos(\""@%camopos6@"\");",0.7);
		schedule("deletecamopos(\""@%camopos7@"\");",0.7);
		schedule("deletecamopos(\""@%camopos8@"\");",0.7);
	}
	

}

function deleteCamoPos(%this)
{
	if($CamoPosDead[%this] != true)
		deleteobject(%this);
}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData PlasteelPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasteelPack
{
	description = "Plasteel Blast wall";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "hDefensive Deployables";
	imageType = PlasteelPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasteelPack::onUse(%player,%item)
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

function PlasteelPack::onDeploy(%player,%item,%pos)
{
	if (PlasteelPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function PlasteelPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Blast Wall",True,False,False,False,true,4,True,0, False, "BlastWall", "PlasteelPack");
} 

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData ThumperPackImage
{
	shapeFile = "grenadel";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, 0.1 };
	mountRotation = { -1.57, 0, 3.94 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ThumperPack
{
	description = "Thumper";
	shapeFile = "grenadel";
	className = "Backpack";
    	heading = "gDeployables";
	imageType = ThumperPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ThumperPack::onUse(%player,%item)
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

function ThumperPack::onDeploy(%player,%item,%pos)
{
		//Check to make sure they are on the sand.
		if(!Worm::inWormBox(gamebase::Getposition(%player)) && GameBase::getLOSInfo(%player,100,"-1.570796327 0 0"))
		{
			if(getObjectType($los::object) == "SimTerrain" && !Worm::inWormBox($los::position) && vector::Getdistance($los::position, gamebase::getposition(%player)) < 3)
			{
				if (ThumperPack::deployShape(%player,%item))
				{
					Player::decItemCount(%player,%item);
				}
			} else
				Client::sendMessage(Player::getClient(%player),0,"Thumpers must be deployed on the sand.");		
		} else
			Client::sendMessage(Player::getClient(%player),0,"Thumpers must be deployed on the sand.");

}

function ThumperPack::deployShape(%player,%item)
{
	%object = (deployable(%player,%item,"StaticShape","Thumper",True,False,False,False,False,4,True,0, False, "Thumper", "ThumperPack"));
	if (%object)
	{
		Worm::AddToTargetQueue(%object);
		Thumper::soundThumper(%object);
		gamebase::setrotation(%object,"-1.57 0 0");
		gamebase::setposition(%object,vector::add(gamebase::Getposition(%object),"0 0 0.5"));
	}
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData SPentashieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SPentashieldPack
{
	description = "Small Pentashield";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "hDefensive Deployables";
	imageType = SPentashieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SPentashieldPack::onUse(%player,%item)
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

function SPentashieldPack::onDeploy(%player,%item,%pos)
{
	if (SPentashieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function SPentashieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Small Force Field",True,False,False,False,True,4,True,0, False, "DeployableForceField", "SPentashieldPack");
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData LPentashieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LPentashieldPack
{
	description = "Large Pentashield Field";
	shapeFile = "AmmoPack";
	className = "Backpack";
    	heading = "hDefensive Deployables";
	imageType = LPentashieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 4000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LPentashieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LPentashieldPack::onDeploy(%player,%item,%pos)
{
	if (LPentashieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LPentashieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Large Force Field",True,False,False,False,Talse,4,True,0, False, "LargeForceField", "LPentashieldPack");
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData DeployableGenPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableGenPack
{
	description = "Deployable Generator";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "gDeployables";
	imageType = DeployableGenPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableGenPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Power Generator Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function DeployableGenPack::onDeploy(%player,%item,%pos)
{
	if (DeployableGenPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableGenPack::deployShape(%player,%item)
{
	%object = (deployable(%player,"PortGenerator","StaticShape","PortGenerator",True,True,True,True,Talse,5,False,0,False, "PortGenerator", "DeployableGenPack"));
	if (%object)
	{
		%object.IsDeployable = true;
		gamebase::setteam(%object, gamebase::getteam(%player));
		addToSet("MissionCleanup", %object);
		addToSet("MissionGroup/Teams/Team" @ gamebase::getteam(%player), %object);
	}
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData HieregPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.4, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData HieregPack
{
        description = "Hiereg";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "gDeployables";
        shadowDetailMask = 4;
        imageType = HieregPackImage;
        mass = 2.0;
        elasticity = 0.2;
        price = 5000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function HieregPack::onUse(%player,%item)
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

function HieregPack::onDeploy(%player,%item,%pos)
{
	if (HieregPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player)@%item]++;
	}
}

function HieregPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,6))
                {
                        %obj = getObjectType($los::object);

                        if (!CheckForObjects($los::position))
                        {
                                Client::sendMessage(%client,1,"Objects In The Way, Can not deploy.");
                        	return;
                        }
                        
                        if (%obj == "SimTerrain")
                        {
                                if (Vector::dot($los::normal,"0 0 1") > 0.8)
                                {
					%group = "Hiereg"@$TeamItemCount[GameBase::getTeam(%player) @ %item];
					newObject(%group,SimGroup);
					addToSet("MissionCleanup",%group);

					%Blastwall1 = newObject(client::getname(%Client)@" Blastwall","StaticShape", Blastwall,true);
					addToSet("MissionCleanup/"@%group,%Blastwall1);
					GameBase::setTeam(%Blastwall1,GameBase::getTeam(%client));
					GameBase::setPosition(%Blastwall1,Vector::add(Gamebase::getPosition(%player), "-6 3 -0.5"));
					GameBase::setRotation(%Blastwall1,"0.7853 0 1.047");

					%Blastwall2 = newObject(client::getname(%Client)@" Blastwall","StaticShape", Blastwall,true);
					addToSet("MissionCleanup/"@%group,%Blastwall2);
					GameBase::setTeam(%Blastwall2,GameBase::getTeam(%client));
					GameBase::setPosition(%Blastwall2,Vector::add(Gamebase::getPosition(%player), "6 3 -0.5"));
					GameBase::setRotation(%Blastwall2,"-0.7853 0 2.094");

					%Blastwall3 = newObject(client::getname(%Client)@" Blastwall","StaticShape", Blastwall,true);
					addToSet("MissionCleanup/"@%group,%Blastwall3);
					GameBase::setTeam(%Blastwall3,GameBase::getTeam(%client));
					GameBase::setPosition(%Blastwall3,Vector::add(Gamebase::getPosition(%player), "0 6 -0.5"));
					GameBase::setRotation(%Blastwall3,"-0.7853 0 3.14");

					%Blastwall4 = newObject(client::getname(%Client)@" Blastwall","StaticShape", Blastwall,true);
					addToSet("MissionCleanup/"@%group,%Blastwall4);
					GameBase::setTeam(%Blastwall4,GameBase::getTeam(%client));
					GameBase::setPosition(%Blastwall4,Vector::add(Gamebase::getPosition(%player), "-6 -3 -0.5"));
					GameBase::setRotation(%Blastwall4,"-0.7853 0 -1.047");

					%Blastwall5 = newObject(client::getname(%Client)@" Blastwall","StaticShape", Blastwall,true);
					addToSet("MissionCleanup/"@%group,%Blastwall5);
					GameBase::setTeam(%Blastwall5,GameBase::getTeam(%client));
					GameBase::setPosition(%Blastwall5,Vector::add(Gamebase::getPosition(%player), "6 -3 -0.5"));
					GameBase::setRotation(%Blastwall5,"0.7853 0 -2.0940");

				
					%Forceshield1 = newObject(client::getname(%Client)@" Pentashield","StaticShape", DeployableForceField,true);
					addToSet("MissionCleanup/"@%group,%Forceshield1);
					GameBase::setTeam(%Forceshield1,GameBase::getTeam(%client));
					GameBase::setPosition(%Forceshield1,Vector::add(Gamebase::getPosition(%player), "1.4 -7.1 -0.1"));
					GameBase::setRotation(%Forceshield1,"0.67 0 -2.8");
					
					%Forceshield2 = newObject(client::getname(%Client)@" Pentashield","StaticShape", DeployableForceField,true);
					addToSet("MissionCleanup/"@%group,%Forceshield2);
					GameBase::setTeam(%Forceshield2,GameBase::getTeam(%client));
					GameBase::setPosition(%Forceshield2,Vector::add(Gamebase::getPosition(%player), "-1.4 -7.1 -0.1"));
					GameBase::setRotation(%Forceshield2,"0.67 0 2.8");


					%ShldGen1 = newObject(client::getname(%Client)@" ShieldGen","StaticShape", PentashieldGen,true);
					addToSet("MissionCleanup/"@%group,%ShldGen1);
					GameBase::setTeam(%ShldGen1,GameBase::getTeam(%client));
					GameBase::setPosition(%ShldGen1,Vector::add(Gamebase::getPosition(%player), "1.7 -6.0 -0.0"));
					$ShieldGen[%Forceshield1] = %ShldGen1;
					$GenShield[%ShldGen1] = %Forceshield1;
					
					%ShldGen2 = newObject(client::getname(%Client)@" ShieldGen","StaticShape", PentashieldGen,true);
					addToSet("MissionCleanup/"@%group,%ShldGen2);
					GameBase::setTeam(%ShldGen2,GameBase::getTeam(%client));
					GameBase::setPosition(%ShldGen2,Vector::add(Gamebase::getPosition(%player), "-1.7 -6.0 -0.0"));
					$ShieldGen[%Forceshield2] = %ShldGen2;
					$GenShield[%ShldGen2] = %Forceshield2;


					%Inv = newObject(client::getname(%Client)@" Inventory","StaticShape", InventoryStation,true);
					addToSet("MissionCleanup/"@%group,%Inv);
					GameBase::setTeam(%Inv,GameBase::getTeam(%client));
					GameBase::setPosition(%Inv,Vector::add(Gamebase::getPosition(%player), "0 2 0"));
					GameBase::setRotation(%Inv,"0 0 0");

					%Gen = newObject(client::getname(%Client)@" SolarPanel","StaticShape", SolarPanel,true);
					addToSet("MissionCleanup/"@%group,%Gen);
					GameBase::setTeam(%Gen,GameBase::getTeam(%client));
					GameBase::setPosition(%Gen,Vector::add(Gamebase::getPosition(%player), "0 -1 4.5"));
					GameBase::setRotation(%Gen,"-0.75 0 0");
					%Gen.IsHiereg = true;				
			

                                return true;
                                }
                                else
                                        Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else
                                Client::sendMessage(%client,0,"Can only deploy on terrain.");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
                 return false;
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData MechGunPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.4, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 20.0;
        firstPerson = false;
};

ItemData MechGunPack
{
        description = "RAM-X44";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "gDeployables";
        shadowDetailMask = 4;
        imageType = MechGunPackImage;
        mass = 20.0;
        elasticity = 0.0;
        price = 7000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MechGunPack::onUse(%player,%item)
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

function MechGunPack::onDeploy(%player,%item,%pos)
{
	if (Mech::addMech(%player,%item,1))
	Player::decItemCount(%player,%item);
}



ItemImageData MechArtillaryPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.4, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 20.0;
        firstPerson = false;
};

ItemData MechArtillaryPack
{
        description = "RAM-A25";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "gDeployables";
        shadowDetailMask = 4;
        imageType = MechArtillaryPackImage;
        mass = 20.0;
        elasticity = 0.0;
        price = 7000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MechArtillaryPack::onUse(%player,%item)
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

function MechArtillaryPack::onDeploy(%player,%item,%pos)
{
	if (Mech::addMech(%player,%item,2))
	Player::decItemCount(%player,%item);
}




ItemImageData MechRocketPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.4, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 20.0;
        firstPerson = false;
};

ItemData MechRocketPack
{
        description = "RAM-R22";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "gDeployables";
        shadowDetailMask = 4;
        imageType = MechRocketPackImage;
        mass = 20.0;
        elasticity = 0.0;
        price = 7000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MechRocketPack::onUse(%player,%item)
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

function MechRocketPack::onDeploy(%player,%item,%pos)
{
	if (Mech::addMech(%player,%item,3))
	Player::decItemCount(%player,%item);
}



ItemImageData MechFlamePackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.4, -0.5 };
        mountRotation = { 0, 0, 0 };
        mass = 20.0;
        firstPerson = false;
};

ItemData MechFlamePack
{
        description = "RAM-N12";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "gDeployables";
        shadowDetailMask = 4;
        imageType = MechFlamePackImage;
        mass = 20.0;
        elasticity = 0.0;
        price = 7000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MechFlamePack::onUse(%player,%item)
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

function MechFlamePack::onDeploy(%player,%item,%pos)
{
	if (Mech::addMech(%player,%item,4))
	Player::decItemCount(%player,%item);
}



//======================================= Check For Objects In a Deployables way.
function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("cfoset",SimSet);
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
				if(%set)deleteobject(%set);
				return False;
			}
		}
	}
	if(%set)deleteobject(%set);
	return True;
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData StationaryLasgunPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData StationaryLasgunPack
{
	description = "Stationary Lasgun Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "hDefensive Deployables";
	imageType = StationaryLasgunPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StationaryLasgunPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function StationaryLasgunPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function StationaryLasgunPack::onDeploy(%player,%item,%pos)
{
	if (StationaryLasgunPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function StationaryLasgunPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"StationaryLasgun",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"StationaryLasgun",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position,true)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",StationaryLasgun,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"Stationary Lasgun Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"Stationary Lasgun Turret deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "StationaryLasgunPack"]++;
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


ItemImageData RepeaterLasgunPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RepeaterLasgunPack
{
	description = "Repeater Lasgun Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "hDefensive Deployables";
	imageType = RepeaterLasgunPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepeaterLasgunPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RepeaterLasgunPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function RepeaterLasgunPack::onDeploy(%player,%item,%pos)
{
	if (RepeaterLasgunPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function RepeaterLasgunPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"RepeaterLasgun",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"RepeaterLasgun",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position,True)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",RepeaterLasgun,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"Repeater Lasgun Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"Repeater Lasgun Turret deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RepeaterLasgunPack"]++;
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
																			
ItemImageData RemoteLasgunPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RemoteLasgunPack
{
	description = "Remote Lasgun";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "hDefensive Deployables";
	imageType = RemoteLasgunPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemoteLasgunPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RemoteLasgunPack::onDeploy(%player,%item,%pos)
{
	if (RemoteLasgunPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function RemoteLasgunPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"RemoteLasgunTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"RemoteLasgunTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position,True)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remotelasgunTurret","Turret",RemoteLasgunTurret,true);
	                     					addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RLG Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Lasgun deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RemoteLasgunPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
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

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
																			
ItemImageData RemoteProjectileGunPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RemoteProjectileGunPack
{
	description = "Remote Projectile Gun";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "hDefensive Deployables";
	imageType = RemoteProjectileGunPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RemoteProjectileGunPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RemoteProjectileGunPack::onDeploy(%player,%item,%pos)
{
	if (RemoteProjectileGunPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function RemoteProjectileGunPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"RemoteProjectileGunTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"RemoteProjectileGunTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position,true)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteprojectileTurret","Turret",RemoteProjectileGunTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RPG Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Projectile Gun deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RemoteProjectileGunPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
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

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemImageData HunterSeekerPlatformPackImage 
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.06 };
	mountRotation = {0, 0, 0};
	firstPerson = false;
};

ItemData HunterSeekerPlatformPack
{
	description = "Hunter-Seeker Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "gDeployables";
	imageType = HunterSeekerPlatformPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function HunterSeekerPlatformPack::onUse(%player,%item) 
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


function HunterSeekerPlatformPack::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>The Hunter-Seeker Platform has no remote control and must be controlled manually to fire.");
}

function HunterSeekerPlatformPack::onDeploy(%player,%item,%pos) 
{
	if (HunterSeekerPlatformPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	}
}

function HunterSeekerPlatformPack::deployShape(%player,%item) 
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,4)) 
		{
			%normal = $los::normal;
			%position = $los::position;
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);			
			
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{

			}
			else
			{
				Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
				return;
			}

				if (Vector::dot(%normal,"0 0 1") > 0.94) 
				{
					%rot = GameBase::getRotation(%player);
						
					if(checkDeployArea2(%client,%position)) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot(%normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 
						{
							if (Vector::dot(%normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation(%normal);
							}
						}
						%rot = GameBase::getRotation(%player);
						%forward = Vector::getFromRot(%rot, 0.1);
						%pos = Vector::add(%position, %forward);
						if(!checkDeployArea2(%client,%pos))
							return;
						%turret = newObject("HSTurret","Turret",DeployableHunterSeekerTurret,true);
						addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,%pos);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Hunter-Seeker Platform");
						Client::sendMessage(%client,0,"Hunter-Seeker Platform deployed");
						%inv = newObject("comunit_remote", "StaticShape", DeployableHunterSeekerStation, true);
						addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						%backward = Vector::neg(Vector::getFromRot(%rot, 0.2));
						GameBase::setPosition(%inv,Vector::add(%pos, %backward));
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Hunter-Seeker Platform");
						%turret.comstation = %inv;
						%inv.comstation = %turret;
						playSound(SoundPickupBackpack,%position);
						$CanUseHS[%client] = 0;
						schedule("$CanUseHS[\"" @ %client @ "\"] = 1;",2);
						return true;
					}
				}
				else Client::sendMessage(%client,0,"Can only deploy on very flat surfaces");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

TurretData DeployableHunterSeekerTurret
{
	projectileType = knifestab;
	className = "Turret";
	shapeFile = "remoteturret";
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	sequenceSound[0] = {"deploy", SoundActivateMotionSensor};
	reloadDelay = 2.0;
	speed = 2.0;
	speedModifier = 1.5;
	range = 0;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	explosionId = flashExpMedium;
	description = "HunterSeeker Platform";
	damageSkinData = "objectDamageSkins";
};

function DeployableHunterSeekerTurret::onAdd(%this)
{
	schedule("DeployableHunterSeekerTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,7);
	%this.shieldStrength = 0.000;
	if (GameBase::getMapName(%this) == "")
	{
		GameBase::setMapName (%this, "HunterSeeker Platform");
	}
}

function DeployableHunterSeekerTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}
function DeployableHunterSeekerTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}
 
function DeployableHunterSeekerTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
	%inv = %this.comstation;
	%data = GameBase::getDataName(%inv);
	GameBase::setDamageLevel(%inv, %data.maxDamage);
	$TeamItemCount[GameBase::getTeam(%this) @ "HunterSeekerPlatformPack"]--;
}

function DeployableHunterSeekerTurret::onPower(%this,%power,%generator)
{

}


 
function DeployableHunterSeekerTurret::onEnabled(%this)
{
	GameBase::setRechargeRate(%this,7);
	GameBase::setActive(%this,true);
}


//===========================================================

FlierData HunterSeeker 
{
	description = "HunterSeeker";
	explosionId = knifeExp;
	className = "Vehicle";
	shapeFile = "force";
	mountRotation = { 0, -1.57, 0 };
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 1.0;
	drag = 1.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 3;
	minSpeed = 0;
	lift = 3;
	maxAlt = 2300;
	maxVertical = 0.001;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 2.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = ricochet1;
	ramDamage = 0;
	ramDamageType = $ImpactDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundGeneratorPower;
	moveSound = SoundGeneratorPower;
	visibleDriver = true;
	driverPose = 22;
};


function HunterSeeker::onCollision(%this, %object)
{

	GameBase::setDamageLevel(%this, 1);	
}

FlierData HunterSeeker2 
{
	description = "HunterSeeker Attack";
	//explosionId = knifeExp;
	explosionId = mortarexp;
	className = "Vehicle";
	shapeFile = "force";
	mountRotation = { 0, -1.57, 0 };
	shieldShapeName = "shield_medium";
	projectile = "Undefined";
	mass = 1.0;
	drag = 1.5;
	density = 1.2;
	maxBank = 50;
	maxPitch = 5000;
	maxSpeed = 100;
	minSpeed = 100;
	lift = 3;
	maxAlt = 2300;
	maxVertical = 0.001;
	destroyDamage = 0.001;
	maxDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 10;
	accel = 25.0;
	groundDamageScale = 1000.0;
	repairRate = 0;
	damageSound = ricochet1;
	ramDamage = 0;
	ramDamageType = $HSDamageType;
	visibleToSensor = false;
	shadowDetailMask = 2;
	idleSound = SoundGeneratorPower;
	moveSound = SoundGeneratorPower;
	visibleDriver = true;
	driverPose = 22;
};

function HunterSeeker::onFire(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%this);
	%vel   = Item::getVelocity(%this);

	if(GameBase::getLOSInfo(%this,2000)) {
		%target = $los::object;
		%pos1 = gamebase::getposition(%target);
		schedule("HunterSeeker::Attack(\""@%this@"\",\""@%target@"\",\""@%pos1@"\");",0.1,%this);	
	} else {
		bottomprint(%client,"<jc><f5>No Target To Lock", 2);
	}

}

function HunterSeeker::Attack(%this,%target,%pos1)
{

	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%pos2 = gamebase::getposition(%target);	// if we are a player AND we are moving
	if(%target && getObjectType(%target) == "Player" && Vector::getDistance(%pos1,%pos2) != 0) {
		bottomprint(%client,"<jc><f5>Target found", 2);
		%trans = GameBase::getMuzzleTransform(%this);
		schedule ("Projectile::spawnProjectile(hunterseekerproj, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ "0 0 0" @ "\", \"" @ %target @ "\");",0.1);
//		Vehicle::onDestroyed(%this,%mom);

		if(%player != -1) {
		   Player::setMountObject(%player, -1, 0);
	   	Client::setControlObject(%client, %player);
		
		%player.HSStation.comstation.controller = "";
		%player.HSStation = "";
		$SFdrivingAPC[%client] = 0;
			if(%player.lastWeapon != "") {
				Player::useItem(%player,%player.lastWeapon);		 	
				%player.lastWeapon = "";
			}
			%player.driver = "";
		   %player.vehicle= "";
		}

		deleteobject(%this);
		$CanUseHS[%client] = 0;
		schedule("$CanUseHS[\""@%client@"\"] = 1;",1.0);
	}
	else {
	
		bottomprint(%client,"<jc><f5>No Target To lock", 2);
	}


}

function HunterSeeker::Attack2(%this,%target,%bool)
{
echo("Attacking");
	%mom = "0 0 50";
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%vel = Item::getVelocity(%this);
	%vec = Vector::getFromRot(%rot,10);
	%obj = newObject("Flier","Flier","HunterSeeker2",true);
	addToSet("MissionCleanup",%obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
	if($KamiKazeDiveStyle == 1) {
		Player::setMountObject(%this.clLastMount,%obj,1);
		Client::setControlObject(%this.clLastMount,%obj);
		%this.clLastMount.vehicle = %obj;
		%obj.clLastMount = %this.clLastMount;
	}
	Item::setVelocity(%this,"0 0 0");
	Item::setVelocity(%obj,%vel);
	Vehicle::onDestroyed(%this,%mom);
echo(%this);
echo(Getobjecttype(%this));
	deleteobject(%this);
echo(%obj);
	if(%bool)
		HunterSeeker::Straight(%obj,%target,"Target");
	else
		HunterSeeker::Straight(%obj,%target,"Pos");
	schedule("StaticShape::onDamage(\""@%obj@"\",\""@$HSDamageType@"\",\""@HunterSeeker2.maxDamage+0.1@"\",\""@%pos@"\",\""@%vec@"\",\""@%mom@"\",\""@%obj@"\");",20,%obj);
}

//- In the long run this will probably cause some lag... but hey, it will never last more than 20 secs
function HunterSeeker::Straight(%this,%target,%type)
{
echo("going straight");
echo(%this);
echo("pos: " @ gamebase::getposition(%this));
	%pos = %target;
	echo(%pos);
	if(%type == "Target")
		%pos = GameBase::getPosition(%target);
	GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),%pos));
	schedule("HunterSeeker::Straight(\""@%this@"\",\""@%target@"\",\""@%type@"\");",0.05,%this);
}

//----------------------------------------------------------------------------
//OLD BACKPACKS
//----------------------------------------------------------------------------


//----------------------------------------------------------------------------

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "gDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	 		         addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//----------------------------------------------------------------------------

ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "gDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Ammo Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
						echo("MSG: ",%client," deployed an Ammo Station");
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//----------------------------------------------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = false;
   validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

//----------------------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = false;
   validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


//----------------------------------------------------------------------------

ItemImageData ShieldPack2Image
{
	shapeFile = "breath";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack2
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPack2Image;
	price = 100;
	hudIcon = "shieldpack";
	showWeaponBar = false;
	hiliteOnActive = false;
   validateShape = false;
   validateMaterials = true;
};


ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundPickupItem;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 100;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = false;
   validateMaterials = true;
};

// Had to redo shields.
function ShieldPack::onDrop(%player, %item)
{
	if($matchStarted) {
		if($shieldon[%player])
			if($Shieldon[%player])	
				Client::sendMessage(Player::getClient(%player),0,"Shield Off");
			Player::trigger(%player,$BackpackSlot,false);
			%player.shieldStrength = 0;
			$ShieldOn[%player] = false;
			Player::trigger(%player,4,false);
			Player::UnMountItem(%player, 4);
			GameBase::setRechargeRate(%player,0.1);
		%item = Item::onDrop(%player,%item);
		return %item;
	}
}

function ShieldPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}



function ShieldPackImage::onactivate(%player, %imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);

	if((getSimTime() - %player.packTime) > 1 || !%player.packTime)
	{
		%player.packTime = getSimTime();
		if(!$ShieldOn[%player]) { // then its off. Turn it on
			Client::sendMessage(Player::getClient(%player),0,"Shield On");
			$ShieldOn[%player] = true;
			//turn it on, and set the switch on
			//suspensorTick(%player, %imageSlot);
			%player.shieldStrength = 0.012;
			DisplayShields(%player);
			//More shield effect/sound
			Player::MountItem(%player, ShieldPack2, 4);
			Player::trigger(%player,4,true);
			GameBase::setRechargeRate(%player,0);
			
		} else { // Then its on, lets turn it off.
			Client::sendMessage(Player::getClient(%player),0,"Shield Off");
			Player::trigger(%player,$BackpackSlot,false);
			%player.shieldStrength = 0;
			$ShieldOn[%player] = false;
			Player::trigger(%player,4,false);
			Player::UnMountItem(%player, 4);
			GameBase::setRechargeRate(%player,0.1);

		}
	}
	// Doesnt matter what gets called here! it will never be executed! HA!

}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);

}


//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 0;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 500;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = false;
   validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "gDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it strai straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "fBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 11 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0)
	 	    		%item.PistolClip = %numPack;
			else if(%i == 1)
	 	    		%item.MaulaClip = %numPack;
			else if(%i == 2)
	 	    		%item.StunnerClip = %numPack;
			else if(%i == 3)
	 	    		%item.RifleClip = %numPack;
			else if(%i == 4)
	 	    		%item.RLauncherAmmo = %numPack;
			else if(%i == 5)
	 	    		%item.CutterayCell = %numPack;
			else if(%i == 6)
	 	    		%item.SmallLasCell = %numPack;
			else if(%i == 7)
	 	    		%item.RifleLasCell = %numPack;
			else if(%i == 8)
	 	    		%item.HeavyLasCell = %numPack;
			else if(%i == 9)
	 	    		%item.MGunClip = %numPack;
			else //if(%i == 10)
	 	    		%item.SniperClip = %numPack;
			
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 11 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0)
	        	%numAdd = %item.PistolClip;
		else if(%i == 1)
	    		%numAdd = %item.MaulaClip;
		else if(%i == 2)
	    		%numAdd = %item.StunnerClip;
		else if(%i == 3)
	    		%numAdd = %item.RifleClip;
		else if(%i == 4)
	    		%numAdd = %item.RLauncherAmmo;
		else if(%i == 5)
			%numAdd = %item.CutterayCell;
		else if(%i == 6)
			%numAdd = %item.SmallLasCell;
		else if(%i == 7)
			%numAdd = %item.RifleLasCell;
		else if(%i == 8)
			%numAdd = %item.HeavyLasCell;
		else if(%i == 9)
	    		%numAdd = %item.MGunClip;
		else //if(%i == 10)
	    		%numAdd = %item.SniperClip;
		
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = player::getarmor(%client);
	for(%i = 0; %i < 14 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum && ($ItemMax[%armor, %item] && !$TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%client)], %armor, %item])) {
			%weapon = $ClipToWeapon[%item];
			%altweapon = %weapon;
			if(%weapon == Rifle)
				%altweapon = Rifle2;
			if(%weapon == MGun)
				%altweapon = MGun2;
			if(player::getItemCount(%client,%weapon) > 0 || player::getItemCount(%client,%altweapon) > 0)
			{
				Player::incItemCount(%client,%item,%maxnum);
				teamEnergyBuySell(%player,%item.price * %maxnum * -1);
			}
		}	
	}
}

//----------------------------------------------------------------------------

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "gDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}


//----------------------------------------------------------------------------

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "gDeployables";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}


//----------------------------------------------------------------------------


ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = "gDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = false;
   validateMaterials = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//----------------------------------------------------------------------------
																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "hDefensive Deployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
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

function checkDeployArea(%client,%pos,%nonearshield)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
		deleteObject(%set);
		%set = newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType,%pos,10,10,10,10);
		for(%x=0;%x<%num;%x++) {
			if(%nonearshield && gamebase::getDataName(Group::getObject(%set,%x)) == "PentashieldGen")
			{
				Client::SendMessage(%client,0,"Unable to deploy - Too strong a Holtzman field near by.");
				deleteObject(%set);
				return 0;
			}
		}
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
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

function checkDeployArea2(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);

	if(GameBase::getLOSInfo(Client::getControlObject(%client),10,"1.570796327 0 0"))
	{
 		if(vector::getdistance(getword($los::position,0)@ " "@getword($los::position,1)@" "@ getword(%pos,2), %pos) < 4.5)
		%num2 = 1;
	}			

	if(!%num && !%num2) {
		deleteObject(%set);
		%set = newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType,%pos,10,10,10,10);
		for(%x=0;%x<%num;%x++) {
			if(%nonearshield && gamebase::getDataName(Group::getObject(%set,%x)) == "PentashieldGen")
			{
				Client::SendMessage(%client,0,"Unable to deploy - Too strong a Holtzman field near by.");
				deleteObject(%set);
				return 0;
			}
		}
		deleteObject(%set);
		return 1;
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
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

//----------------------------------------------------------------------------
//Ghola Deploy

ItemImageData GholaPackImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.3, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData GholaPack
{
	description = "Ghola";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "gDeployables";
	imageType = GholaPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GholaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function GholaPack::onDeploy(%player,%item,%pos)
{
	if (GholaPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function GholaPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($GholaOwned[%client] < $GholaOwnedMax) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						if(%client.gholapickname != "") {
							%rot = GameBase::getRotation(%player);
							
							%gholaName = ("Ghola" @ %client.gholapickname);
							$NumGhola[%ghola]++;
							%gholaName = %gholaName @ $NumGhola[%ghola];
							%gholaArmor = %client.gholapickarmor;
							%gholaTeam = %client.gholapickteam;
							%ghola = AI::GholaSpawn( %gholaName, %gholaArmor, %client, $los::position, %rot);
							Dune::SwitchSkin(player::getclient(%ghola),$ArmorName[%gholaArmor],%gholaTeam);
							for(%x = 1; %x < $GholaOwnedMax + 1; %x++)
							{
								if( $OwnedGholaList[%client, %x] == "" )
								{
									$OwnedGholaList[%client, %x] = %ghola;
									break;
								}
							}
							//$OwnedGholaList[%client, $GholaOwned[%client] +1] = %ghola;
							//addToSet("MissionCleanup", AI::getId(%ghola));
							$IsGhola[%ghola] = true;
							GameBase::setTeam(AI::getId(%ghola),GameBase::getTeam(%player));
							Client::sendMessage(%client,0,%gholaName @" Spawned");
							playSound(SoundPickupBackpack,$los::position);
							$GholaOwned[%client]++;
							$GholaOwner[%ghola] = %client;
							echo("MSG: ",%client," deployed a Ghola");
							return true;
						}
						else
							Client::sendMessage(%client,0,"You must pick a valid Ghola Subject first");
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
	 	Client::sendMessage(%client,0,"You may only have up to three Gholas.");

	return false;
}




//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = false;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	$PlayerPoisoned[Player::getClient(%player)] = 0;

}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   validateMaterials = true;
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = false;
   validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}


//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}


//----------------------------------------------------------------------------


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
		if(%maxnum != 0 && $TeamRestrictedItem[$ServerNameToKeyName[GameBase::getTeam(%client)], %armor, %item])
			%maxnum = 0;
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
				if(%item == shieldpack)
				{
				if($shieldon[client::getcontrolobject(%client)])
						Client::sendMessage(%client,0,"Shield Off");
					client::getcontrolobject(%client).shieldStrength = 0;
					$ShieldOn[client::getcontrolobject(%client)] = false;
					Player::trigger(%client,4,false);
					Player::UnMountItem(%client, 4);
				}
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				if(%item.className == Weapon && %item.imageType.ammoType != "")
				{
					player::setitemcount(%client,%item.imageType.ammoType,0);
				}
				updateBuyingList(%client);
			} 
		}
	}
}

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
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);


	if(%name == "Small Force Field" || %name == "Large Force Field")
	{
		%set = newObject("set",SimSet); // make new box for testing.
		%number = containerBoxFillSet(%set,$GroupTriggerObjectType,gamebase::getposition(%player),10,10,10,0);
		if(%number){ // Found a box?
			for(%x = 0; %x <= %number; %x++){
				%target = Group::getObject(%set,%x); // get the objNum of the found object.
				// is this a NoShield box?
				if(Object::Getname(%target) == "NoShield")
				{
					Client::sendMessage(Player::getClient(%player),0,"You cannot deploy a pentashield inside of a static field!");
					return false;
				}	
			}
	
		}

	}

	// Check for turrets... damn cheating bastards...
	if(%name == "Small Force Field" || %name == "Large Force Field" || %name == "Blast Wall")
	{
		%set = newObject("set",SimSet); // make new box for testing.
		%number = containerBoxFillSet(%set,$StaticObjectType,gamebase::getposition(%player),10,10,10,0);
		if(%number){ 
			for(%x = 0; %x <= %number; %x++){
				%target = Group::getObject(%set,%x); 
				if(gamebase::getdataname(%target) == RemoteProjectileGunTurret || gamebase::getdataname(%target) == RemoteLasgunTurret || gamebase::getdataname(%target) == StationaryLasgun)
				{
					Client::sendMessage(Player::getClient(%player),0,"Unable to deploy - Item in the way");
					return false;
				}	
			}
	
		}

	}


	if($TeamItemCount[GameBase::getTeam(%player) @ %count] < $TeamItemMax[%count])
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
				else if (%datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall")
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


			%turret = newObject(%name,%type, %deploy,true);
			addToSet("MissionCleanup", %turret);
			
			// If its a pentashield, deploy its gen.
			if(%name == "Small Force Field" || %name == "Large Force Field" )
			{
				%shieldgen = newObject(""@%name@" Gen","StaticShape", PentashieldGen,true);
				addToSet("MissionCleanup", %shieldgen);
				GameBase::setTeam(%shieldgen,GameBase::getTeam(%player));
				GameBase::setPosition(%shieldgen,(GetOffSetRot("0.5 0 0.1",Vector::add(%rot,"0 0 -1.570796327"),$los::position)));
				$ShieldGen[%turret] = %shieldgen;
				$GenShield[%shieldgen] = %turret;
			}	
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;
			
			//echo("MSG: ",%client," deployed a " @ %name);

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			else
				Gamebase::setMapName(%turret, %name);

			//if (%flagdist < %flag && %flag != 0)
			//{
			//	%client.score = %client.score + $Score::FlagDef;
			//	if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
			//	Game::refreshClientScore(%client);
			//}

			//if ($Shifter::TurretKill && %kill)
			//{
			//	Client::setOwnedObject(%client, %turret);
			//	Client::setOwnedObject(%client, %player);
			//}
			return %turret;
		}
		else 
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "'s.");
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


function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite") {
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

function Mission::reinitData()
{

	for( %i = 0; %i < 8; %i++) {
		//Old
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;
		$TeamItemCount[%i @ TurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ Beacon] = 0;
		$TeamItemCount[%i @ mineammo] = 0;
		//New
		$TeamItemCount[%i @ PlasteelPack] = 0;
		$TeamItemCount[%i @ ThumperPack] = 0;
		$TeamItemCount[%i @ LPentashieldPack] = 0;
		$TeamItemCount[%i @ SPentashieldPack] = 0;
		$TeamItemCount[%i @ DeployableGenPack] = 0;
		$TeamItemCount[%i @ HieregPack] = 0;
		$TeamItemCount[%i @ StationaryLasgunPack] = 0;
		$TeamItemCount[%i @ RepeaterLasgunPack] = 0;
		$TeamItemCount[%i @ RemoteLasgunPack] = 0;
		$TeamItemCount[%i @ RemoteProjectileGunPack] = 0;
		$TeamItemCount[%i @ HunterSeekerPlatformPack] = 0;
		$TeamItemCount[%i @ ShieldThopterVehicle] = 0;
		$TeamItemCount[%i @ VulcanThopterVehicle] = 0;
		$TeamItemCount[%i @ LasgunThopterVehicle] = 0;
		$TeamItemCount[%i @ CarryallVehicle] = 0;
		$TeamItemCount[%i @ RollerVehicle] = 0;
		$TeamItemCount[%i @ TrackerVehicle] = 0;
		$TeamItemCount[%i @ CrawlerVehicle] = 0;
		$TeamItemCount[%i @ MechGunPack] = 0;
		$TeamItemCount[%i @ MechArtillaryPack] = 0;
		$TeamItemCount[%i @ MechRocketPack] = 0;
		$TeamItemCount[%i @ MechFlamePack] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], SoldierArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], TrooperArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], FremenArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], FedaykinArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], SardaukarArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], BasharArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], BursegArmor] = 0;
		$TeamArmorCount[$ServerNameToKeyName[%i], FaceDancerArmor] = 0;
	}

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy;   
}

