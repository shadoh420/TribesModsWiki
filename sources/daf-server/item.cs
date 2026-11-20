//----------------------------------------------------------------------------

$ItemFavoritesKey = "DeltaAirForce";  // Change this if you add new items
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

// DELTA FORCE
$AutoUse[SOCOM] = True;
$AutoUse[OICW] = True;
$AutoUse[SAW] = True;
$AutoUse[MP5] = True;
$AutoUse[LAW] = True;
$AutoUse[Howitzer] = True;
$AutoUse[PSG1] = True;
$AutoUse[Minigun] = True;
$AutoUse[LowMountMinigun] = True;
$AutoUse[TwentyFivemmgun] = True;
$AutoUse[LowMountTwentyFivemmgun] = True;
$AutoUse[Fortymmgun] = True;
$AutoUse[AbramsGun] = True;
$AutoUse[LowMountAbramsGun] = True;
$AutoUse[StingerLauncherGun] = True;
$AutoUse[MLRSGun] = True;
$AutoUse[TOW] = True;
$AutoUse[AutoGrenLauncher] = True;
$AutoUse[AutoShotgun] = True;
$AutoUse[Stinger] = True;
$AutoUse[Flamethrower] = True;
$AutoUse[FiftyCal] = True;
$AutoUse[Airstrike] = False;
$AutoUse[RepairGun] = False;
$AutoUse[MedicGun] = True;
$AutoUse[Knife] = False;
// END DELTA FORCE

$Use[SOCOM] = True;

// DELTA FORCE
$ArmorType[Male, MedicArmor] = marmor;
$ArmorType[Male, InfantryArmor] = iarmor;
$ArmorType[Male, GrenadierArmor] = garmor;
$ArmorType[Male, SniperArmor] = sarmor;
$ArmorType[Male, SpecOpsArmor] = carmor;
$ArmorType[Male, EngineerArmor] = earmor;
$ArmorType[Male, PilotArmor] = larmor;
$ArmorType[Male, ArtilleryArmor] = aarmor;
$ArmorType[Male, CommandoArmor] = comarmor;
$ArmorType[Female, MedicArmor] = mfemale;
$ArmorType[Female, InfantryArmor] = ifemale;
$ArmorType[Female, GrenadierArmor] = gfemale;
$ArmorType[Female, SniperArmor] = sfemale;
$ArmorType[Female, SpecOpsArmor] = cfemale;
$ArmorType[Female, EngineerArmor] = efemale;
$ArmorType[Female, PilotArmor] = lfemale;
$ArmorType[Female, ArtilleryArmor] = afemale;
$ArmorType[Female, CommandoArmor] = comfemale;
$ArmorType[Male, Medic2Armor] = marmor2;
$ArmorType[Male, Infantry2Armor] = iarmor2;
$ArmorType[Male, Grenadier2Armor] = garmor2;
$ArmorType[Male, Sniper2Armor] = sarmor2;
$ArmorType[Male, SpecOps2Armor] = carmor2;
$ArmorType[Male, Engineer2Armor] = earmor2;
$ArmorType[Male, Pilot2Armor] = larmor2;
$ArmorType[Male, Artillery2Armor] = aarmor2;
$ArmorType[Male, Commando2Armor] = comarmor2;
$ArmorType[Female, Medic2Armor] = mfemale2;
$ArmorType[Female, Infantry2Armor] = ifemale2;
$ArmorType[Female, Grenadier2Armor] = gfemale2;
$ArmorType[Female, Sniper2Armor] = sfemale2;
$ArmorType[Female, SpecOps2Armor] = cfemale2;
$ArmorType[Female, Engineer2Armor] = efemale2;
$ArmorType[Female, Pilot2Armor] = lfemale2;
$ArmorType[Female, Artillery2Armor] = afemale2;
$ArmorType[Female, Commando2Armor] = comfemale2;
$ArmorType[Male, Medic3Armor] = marmor2;
$ArmorType[Male, Infantry3Armor] = iarmor2;
$ArmorType[Male, Grenadier3Armor] = garmor2;
$ArmorType[Male, Sniper3Armor] = sarmor2;
$ArmorType[Male, SpecOps3Armor] = carmor2;
$ArmorType[Male, Engineer3Armor] = earmor2;
$ArmorType[Male, Pilot3Armor] = larmor2;
$ArmorType[Male, Artillery3Armor] = aarmor2;
$ArmorType[Male, Commando3Armor] = comarmor2;
$ArmorType[Female, Medic3Armor] = mfemale2;
$ArmorType[Female, Infantry3Armor] = ifemale2;
$ArmorType[Female, Grenadier3Armor] = gfemale2;
$ArmorType[Female, Sniper3Armor] = sfemale2;
$ArmorType[Female, SpecOps3Armor] = cfemale2;
$ArmorType[Female, Engineer3Armor] = efemale2;
$ArmorType[Female, Pilot3Armor] = lfemale2;
$ArmorType[Female, Artillery3Armor] = afemale2;
$ArmorType[Female, Commando3Armor] = comfemale2;
// END DELTA FORCE

// DELTA FORCE
$ArmorName[marmor] = MedicArmor;
$ArmorName[sarmor] = SniperArmor;
$ArmorName[iarmor] = InfantryArmor;
$ArmorName[garmor] = GrenadierArmor;
$ArmorName[carmor] = SpecOpsArmor;
$ArmorName[earmor] = EngineerArmor;
$ArmorName[larmor] = PilotArmor;
$ArmorName[aarmor] = ArtilleryArmor;
$ArmorName[comarmor] = CommandoArmor;
$ArmorName[mfemale] = MedicArmor;
$ArmorName[sfemale] = SniperArmor;
$ArmorName[ifemale] = InfantryArmor;
$ArmorName[gfemale] = GrenadierArmor;
$ArmorName[cfemale] = SpecOpsArmor;
$ArmorName[efemale] = EngineerArmor;
$ArmorName[lfemale] = PilotArmor;
$ArmorName[afemale] = ArtilleryArmor;
$ArmorName[comfemale] = CommandoArmor;
$ArmorName[marmor2] = Medic2Armor;
$ArmorName[sarmor2] = Sniper2Armor;
$ArmorName[iarmor2] = Infantry2Armor;
$ArmorName[garmor2] = Grenadier2Armor;
$ArmorName[carmor2] = SpecOps2Armor;
$ArmorName[earmor2] = Engineer2Armor;
$ArmorName[larmor2] = Pilot2Armor;
$ArmorName[aarmor2] = Artillery2Armor;
$ArmorName[comarmor2] = Commando2Armor;
$ArmorName[mfemale2] = Medic2Armor;
$ArmorName[sfemale2] = Sniper2Armor;
$ArmorName[ifemale2] = Infantry2Armor;
$ArmorName[gfemale2] = Grenadier2Armor;
$ArmorName[cfemale2] = SpecOps2Armor;
$ArmorName[efemale2] = Engineer2Armor;
$ArmorName[lfemale2] = Pilot2Armor;
$ArmorName[afemale2] = Artillery2Armor;
$ArmorName[comfemale2] = Commando2Armor;
$ArmorName[marmor3] = Medic3Armor;
$ArmorName[sarmor3] = Sniper3Armor;
$ArmorName[iarmor3] = Infantry3Armor;
$ArmorName[garmor3] = Grenadier3Armor;
$ArmorName[carmor3] = SpecOps3Armor;
$ArmorName[earmor3] = Engineer3Armor;
$ArmorName[larmor3] = Pilot3Armor;
$ArmorName[aarmor3] = Artillery3Armor;
$ArmorName[comarmor3] = Commando3Armor;
$ArmorName[mfemale3] = Medic3Armor;
$ArmorName[sfemale3] = Sniper3Armor;
$ArmorName[ifemale3] = Infantry3Armor;
$ArmorName[gfemale3] = Grenadier3Armor;
$ArmorName[cfemale3] = SpecOps3Armor;
$ArmorName[efemale3] = Engineer3Armor;
$ArmorName[lfemale3] = Pilot3Armor;
$ArmorName[afemale3] = Artillery3Armor;
$ArmorName[comfemale3] = Commando3Armor;
// END DELTA FORCE

// Amount to remove when selling or dropping ammo
// DELTA FORCE
$SellAmmo[Beacon] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[SOCOMAmmo] = 10;
$SellAmmo[OICWAmmo] = 25;
$SellAmmo[SAWAmmo] = 25;
$SellAmmo[MP5Ammo] = 25;
$SellAmmo[PSG1Ammo] = 10;
$SellAmmo[FiftyCalAmmo] = 10;
$SellAmmo[AutoShotgunAmmo] = 50;
$SellAmmo[StingerAmmo] = 1;
$SellAmmo[FlameAmmo] = 50;
$SellAmmo[LAWAmmo] = 5;
$SellAmmo[HowitzerAmmo] = 5;
// END DELTA FORCE

// Max Amount of ammo the Ammo Pack can carry
// DELTA FORCE
$AmmoPackMax[Grenade] = 2;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[PSG1Ammo] = 5;
$AmmoPackMax[FiftyCalAmmo] = 3;
$AmmoPackMax[SOCOMAmmo] = 20;
$AmmoPackMax[OICWAmmo] = 50;
$AmmoPackMax[AutoShotgunAmmo] = 50;
$AmmoPackMax[SAWAmmo] = 50;
$AmmoPackMax[StingerAmmo] = 1;
$AmmoPackMax[MP5Ammo] = 50;
$AmmoPackMax[FlameAmmo] = 50;
$AmmoPackMax[HowitzerAmmo] = 2;
// END DELTA FORCE

// Items in the AmmoPack
//$AmmoPackItems[0] = BulletAmmo;
//$AmmoPackItems[1] = PlasmaAmmo;
//$AmmoPackItems[2] = DiscAmmo;
//$AmmoPackItems[3] = GrenadeAmmo;
//$AmmoPackItems[4] = Grenade;
//$AmmoPackItems[5] = MortarAmmo;
//$AmmoPackItems[6] = Beacon;
// DELTA FORCE
//$AmmoPackItems[7] = SOCOMAmmo;
//$AmmoPackItems[8] = OICWAmmo;
//$AmmoPackItems[9] = SAWAmmo;
//$AmmoPackItems[10] = MP5Ammo;
//$AmmoPackItems[11] = PSG1Ammo;
//$AmmoPackItems[12] = HowitzerAmmo;
//$AmmoPackItems[13] = FiftyCalAmmo;
//$AmmoPackItems[14] = AutoShotgunAmmo;
//$AmmoPackItems[15] = StingerAmmo;
//$AmmoPackItems[16] = FlameAmmo;
//$AmmoPackItems[17] = Grenade;

//$NumAPackItems = 17;

$AmmoPackAllItems[0] = SOCOMClip;
$AmmoPackAllItems[1] = OICWClip;
$AmmoPackAllItems[2] = SAWClip;
$AmmoPackAllItems[3] = MP5Clip;
$AmmoPackAllItems[4] = PSG1Clip;
$AmmoPackAllItems[5] = FiftyCalClip;
$AmmoPackAllItems[6] = AutoShotgunClip;
$AmmoPackAllItems[7] = StingerClip;
$AmmoPackAllItems[8] = Grenade;

$NumAllPackItems = 9;

$SmallAmmoPackItems[0] = SOCOMClip;
$SmallAmmoPackItems[1] = OICWClip;
$SmallAmmoPackItems[2] = MP5Clip;
$SmallAmmoPackItems[3] = PSG1Clip;

$SmallAmmoPackMax[SOCOMClip] = 2;
$SmallAmmoPackMax[OICWClip] = 2;
$SmallAmmoPackMax[MP5Clip] = 2;
$SmallAmmoPackMax[PSG1Clip] = 2;

$NumSAPackItems = 4;

$HeavyAmmoPackItems[0] = SAWClip;
$HeavyAmmoPackItems[1] = FiftyCalClip;
$HeavyAmmoPackItems[2] = AutoShotgunClip;

$HeavyAmmoPackMax[SAWClip] = 1;
$HeavyAmmoPackMax[FiftyCalClip] = 1;
$HeavyAmmoPackMax[AutoShotgunClip] = 3;

$NumHAPackItems = 3;

$ExpAmmoPackItems[0] = StingerClip;
$ExpAmmoPackItems[1] = Grenade;

$ExpAmmoPackMax[StingerClip] = 1;
$ExpAmmoPackMax[Grenade] = 4;

$NumEAPackItems = 2;
// END DELTA FORCE

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 5;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[RadarPack] = 5;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[BouncingMinePack] = 20;
$TeamItemMax[APMinePack] = 12;
$TeamItemMax[AAMinePack] = 35;
$TeamItemMax[SandBagpack] = 75;
// DELTA FORCE
$TeamItemMax[DeployableHealthPack] = 5;
$TeamItemMax[ReloaderPack] = 5;
$TeamItemMax[PortGenPack] = 3;
$TeamItemMax[AirstrikePack] = 4;
$TeamItemMax[GrapplePack] = 5;
$TeamItemMax[SAMPack] = 4;
$TeamItemMax[HowitzerPack] = 3;
$TeamItemMax[AAPack] = 2;
$TeamItemMax[TwentyPack] = 3;
$TeamItemMax[FalconVehicle] = 3;
//$TeamItemMax[DiveBomberVehicle] = 3;
$TeamItemMax[TomcatVehicle] = 3;
$TeamItemMax[ApacheVehicle] = 3;
$TeamItemMax[KiowaVehicle] = 1;
$TeamItemMax[WarthogVehicle] = 2;
$TeamItemMax[BlackhawkVehicle] = 2;
$TeamItemMax[HumveeVehicle] = 3;
$TeamItemMax[AbramsVehicle] = 3;
$TeamItemMax[BradleyVehicle] = 3;
$TeamItemMax[LineBackerVehicle] = 3;
$TeamItemMax[MLRSVehicle] = 3;
$TeamItemMax[MineLayerVehicle] = 2;
$TeamItemMax[BomberVehicle] = 2;
$TeamItemMax[HerculesVehicle] = 2;
$TeamItemMax[SentryVehicle] = 1;
$TeamItemMax[GunshipVehicle] = 2;
$TeamItemMax[HindVehicle] = 3;
$TeamItemMax[Charge] = 3;
// END DELTA FORCE


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
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
// DELTA FORCE
$WeaponAmmo[Knife] = "";
$WeaponAmmo[SOCOM] = SOCOMAmmo;
$WeaponAmmo[OICW] = OICWAmmo;
$WeaponAmmo[SAW] = SAWAmmo;
$WeaponAmmo[MP5] = MP5Ammo;
$WeaponAmmo[LAW] = LAWAmmo;
$WeaponAmmo[PSG1] = PSG1Ammo;
$WeaponAmmo[Minigun] = MinigunAmmo;
$WeaponAmmo[LowMountMinigun] = LowMountMinigunAmmo;
$WeaponAmmo[TwentyFivemmgun] = TwentyFivemmAmmo;
$WeaponAmmo[LowMountTwentyFivemmgun] = LowMountTwentyFivemmAmmo;
$WeaponAmmo[Fortymmgun] = FortymmAmmo;
$WeaponAmmo[AbramsGun] = AbramsAmmo;
$WeaponAmmo[LowMountAbramsGun] = LowMountAbramsAmmo;
$WeaponAmmo[StingerLauncherGun] = StingerLauncherAmmo;
$WeaponAmmo[MLRSLauncher] = MLRSAmmo;
$WeaponAmmo[TOW] = TOWAmmo;
$WeaponAmmo[Flamethrower] = FlameAmmo;
$WeaponAmmo[AutoGrenLauncher] = AutoGrenAmmo;
$WeaponAmmo[Howitzer] = HowitzerAmmo;
$WeaponAmmo[Airstrike] = "";
$WeaponAmmo[GrappleHook] = "";
$WeaponAmmo[Stinger] = StingerAmmo;
$WeaponAmmo[FiftyCal] = FiftyCalAmmo;
$WeaponAmmo[AutoShotgun] = AutoShotgunAmmo;

$AmmoWeapon[MinigunAmmo] = Minigun;
$AmmoWeapon[LowMountMinigunAmmo] = LowMountMinigun;
$AmmoWeapon[TwentyFivemmAmmo] = TwentyFivemmgun;
$AmmoWeapon[LowMountTwentyFivemmAmmo] = LowMountTwentyFivemmgun;
$AmmoWeapon[FortymmAmmo] = Fortymmgun;
$AmmoWeapon[AbramsAmmo] = AbramsGun;
$AmmoWeapon[LowMountAbramsAmmo] = LowMountAbramsGun;
$AmmoWeapon[MLRSAmmo] = MLRSLauncher;
$AmmoWeapon[StingerLauncherAmmo] = StingerLauncherGun;
$AmmoWeapon[TOWAmmo] = TOW;
$AmmoWeapon[AutoGrenAmmo] = AutoGrenLauncher;
// END DELTA FORCE

//----------------------------------------------------------------------------//
//-CLIPCODE BY ICE------------------------------------------------------------//
//----------------------------------------------------------------------------//
// !!!NOTE!!!: You will need to set the the reloading times AND the prices for//
// the magazines, I have already set everything else into their places, modify//
// the third term section below to set the reloading time in seconds          //
//----------------------------------------------------------------------------//

//>-Defines what Magazine each gun uses
$Clip[Knife] = "";
$Clip[SOCOM] = SOCOMClip;
$Clip[OICW] = OICWClip;
$Clip[SAW] = SAWClip;
$Clip[MP5] = MP5Clip;
$Clip[PSG1] = PSG1Clip;
$Clip[FiftyCal] = FiftyCalClip;
$Clip[LAW] = "";
$Clip[Howitzer] = "";
$Clip[Airstrike] = "";
$Clip[Minigun] = "";
$Clip[LowMountMinigun] = "";
$Clip[TwentyFivemmgun] = "";
$Clip[LowMountTwentyFivemmgun] = "";
$Clip[Fortymmgun] = "";
$Clip[AbramsGun] = "";
$Clip[LowMountAbramsGun] = "";
$Clip[TOW] = "";
$Clip[AutoGrenLauncher] = "";
$Clip[StingerLauncherGun] = "";
$Clip[MLRSLauncher] = "";
$Clip[AutoShotgun] = AutoShotgunClip;
$Clip[Stinger] = StingerClip;
$Clip[Flamethrower] = "";
$Clip[RepairGun] = "";
$Clip[MedicGun] = "";
$Clip[GrappleHook] = "";

$Clip[SOCOMClip] = SOCOM;
$Clip[OICWClip] = OICW;
$Clip[SAWClip] = SAW;
$Clip[MP5Clip] = MP5;
$Clip[PSG1Clip] = PSG1;
$Clip[FiftyCalClip] = FiftyCal;
$Clip[AutoShotgunClip] = AutoShotgun;
$Clip[StingerClip] = Stinger;

$AmmoToWeapon[SOCOMAmmo] = SOCOM;
$AmmoToWeapon[OICWAmmo] = OICW;
$AmmoToWeapon[SAWAmmo] = SAW;
$AmmoToWeapon[MP5Ammo] = MP5;
$AmmoToWeapon[PSG1Ammo] = PSG1;
$AmmoToWeapon[FiftyCalAmmo] = FiftyCal;
$AmmoToWeapon[AutoShotgunAmmo] = AutoShotgun;
$AmmoToWeapon[StingerAmmo] = Stinger;


//>-Defines the Magazine's size
$ClipSize[Knife] = "";
$ClipSize[SOCOM] = 15;
$ClipSize[OICW] = 30;
$ClipSize[SAW] = 200;
$ClipSize[MP5] = 30;
$ClipSize[PSG1] = 5;
$ClipSize[FiftyCal] = 5;
$ClipSize[LAW] = "";
$ClipSize[Howitzer] = "";
$ClipSize[Airstrike] = "";
$ClipSize[Minigun] = "";
$ClipSize[LowMountMinigun] = "";
$ClipSize[TwentyFivemmgun] = "";
$ClipSize[LowMountTwentyFivemmgun] = "";
$ClipSize[Fortymmgun] = "";
$ClipSize[AbramsGun] = "";
$ClipSize[LowMountAbramsGun] = "";
$ClipSize[TOW] = "";
$ClipSize[AutoGrenLauncher] = "";
$ClipSize[StingerLauncherGun] = "";
$ClipSize[MLRSLauncher] = "";
$ClipSize[AutoShotgun] = 7;
$ClipSize[Stinger] = 1;
$ClipSize[Flamethrower] = "";
$ClipSize[RepairGun] = "";
$ClipSize[MedicGun] = "";
$ClipSize[GrappleHook] = "";

//>-Defines how long the gun takes to switch magazines 
$ClipTime[Knife] = "";
$ClipTime[SOCOM] = 0.8;
$ClipTime[OICW] = 1;
$ClipTime[SAW] = 1.4;
$ClipTime[MP5] = 1;
$ClipTime[PSG1] = 1;
$ClipTime[FiftyCal] = 1;
$ClipTime[LAW] = "";
$ClipTime[Howitzer] = "";
$ClipTime[Airstrike] = "";
$ClipTime[Minigun] = "";
$ClipTime[LowMountMinigun] = "";
$ClipTime[TwentyFivemmgun] = "";
$ClipTime[LowMountTwentyFivemmgun] = "";
$ClipTime[Fortymmgun] = "";
$ClipTime[AbramsGun] = "";
$ClipTime[LowMountAbramsGun] = "";
$ClipTime[TOW] = "";
$ClipTime[AutoGrenLauncher] = "";
$ClipTime[StingerLauncherGun] = "";
$ClipTime[MLRSLauncher] = "";
$ClipTime[AutoShotgun] = 1;
$ClipTime[Stinger] = 1.4;
$ClipTime[Flamethrower] = "";
$ClipTime[RepairGun] = "";
$ClipTime[MedicGun] = "";
$ClipTime[GrappleHook] = "";

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
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
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
					removeAllAmmo(%client);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));

						if(%item == FuelPack)
							Player::Setitemcount(%client,FlameAmmo,0);

						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
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
	Player::SetItemCount(%client,SOCOMAmmo,0);
	Player::SetItemCount(%client,OICWAmmo,0);
	Player::SetItemCount(%client,SAWAmmo,0);
	Player::SetItemCount(%client,MP5Ammo,0);
	Player::SetItemCount(%client,PSG1Ammo,0);
	Player::SetItemCount(%client,FiftyCalAmmo,0);
	Player::SetItemCount(%client,LAWAmmo,0);
	Player::SetItemCount(%client,AutoShotgunAmmo,0);
	Player::SetItemCount(%client,HowitzerAmmo,0);
	Player::SetItemCount(%client,StingerAmmo,0);
	Player::SetItemCount(%client,FlameAmmo,0);
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
	%extraAmmo = 0;
	%mountItem = Player::getMountedItem(%client,$BackpackSlot);
	if (%mountItem == ammopacksmall && $SmallAmmoPackMax[%item] != "")
	{
		%extraAmmo = $SmallAmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	} else if(%mountItem == ammopackheavy && $HeavyAmmoPackMax[%item] != "")
	{
		%extraAmmo = $HeavyAmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	} else if(%mountItem == ammopackexp && $ExpAmmoPackMax[%item] != "")
	{
		%extraAmmo = $ExpAmmoPackMax[%item];
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
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	if(%item=="TargetingLaser"||%item=="Flashlight")
	{
		toolbuycheck(Client::getOwnedObject(%client), %item);
		return 1;
	}

	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	%team = GameBase::getTeam(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		
		if (%item.className == Armor) {
				// Assign armor by requested type & gender
				%buyarmor = $ArmorType[Client::getGender(%client), %item];
				if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
					teamEnergyBuySell(%player,$ArmorName[%armor].price);
					if(checkResources(%player,%item,1)) {
						// DELTA FORCE
						// Sniper limitations
						if(%item == "SniperArmor" || %armor == "sarmor" || %armor == "sfemale"){

						}else if(%item == "SniperArmor") {
							if($SniperCount[%team] >= ($Server::SniperLimit * getTeamNumPlayers(%team)))
							{
								Client::sendMessage(%client,0,"Your team has too many snipers");			
	
								// Bug fix - make sure the player is actually wearing something...
								%buyarmor = $ArmorType[Client::getGender(%client), "InfantryArmor"];
								Player::setArmor(%client,%buyarmor);
								teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
								Player::setArmor(%client,%buyarmor);
								checkMax(%client,%buyarmor);
								armorChange(%client);
     								Player::setItemCount(%client, $ArmorName[%armor], 0);  
     								Player::setItemCount(%client, "InfantryArmor", 1);										
								setupShoppingList(%client,%client.invo,%client.ListType);
								return 0;
							} else
							{
								$SniperCount[%team]++;
							}							
						} else if(%armor == "sarmor" || %armor == "sfemale")
						{
							$SniperCount[%team]--;
						}
						// END DELTA FORCE
						teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
						Player::setArmor(%client,%buyarmor);
						checkMax(%client,%buyarmor);
						armorChange(%client);
     						Player::setItemCount(%client, $ArmorName[%armor], 0);  
     						Player::setItemCount(%client, %item, 1);    

						setupShoppingList(%client,%client.invo,%client.ListType);

						if (Player::getMountedItem(%client,$BackpackSlot) == ammopacksmall) 
							fillSmallAmmoPack(%client);
						else if (Player::getMountedItem(%client,$BackpackSlot) == ammopackheavy) 
							fillHeavyAmmoPack(%client);
						else if (Player::getMountedItem(%client,$BackpackSlot) == ammopackexp) 
							fillExpAmmoPack(%client);	
						return 1;
					}	

					teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
				}
		
		}
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Vehicle Hardpoint mounted Modules
		else if (%item.className == VModule)
		{
			//remoteSellItem(%client,%item);
			// Missiles/Rockets
			
			if(Player::getItemCount(%client,SideWinderModule))teamEnergyBuySell(%player,SideWinderModule.price );
			if(Player::getItemCount(%client,PhoenixModule))teamEnergyBuySell(%player,PhoenixModule.price );
			if(Player::getItemCount(%client,HellFireModule))teamEnergyBuySell(%player,HellFireModule.price );
			if(Player::getItemCount(%client,HydraModule))teamEnergyBuySell(%player,HydraModule.price );
			if(Player::getItemCount(%client,UPKGunPodModule))teamEnergyBuySell(%player,UPKGunPodModule.price );
			if(Player::getItemCount(%client,GUVGunPodModule))teamEnergyBuySell(%player,GUVGunPodModule.price );
			if(Player::getItemCount(%client,FiftyCalModule))teamEnergyBuySell(%player,FiftyCalModule.price );
			if(Player::getItemCount(%client,MaverickModule))teamEnergyBuySell(%player,MaverickModule.price );
			if(Player::getItemCount(%client,HARMModule))teamEnergyBuySell(%player,HARMModule.price );
			if(Player::getItemCount(%client,Mk82Module))teamEnergyBuySell(%player,Mk82Module.price );
			if(Player::getItemCount(%client,Mk84Module))teamEnergyBuySell(%player,Mk84Module.price );
			if(Player::getItemCount(%client,APClusterModule))teamEnergyBuySell(%player,APClusterModule.price );
			if(Player::getItemCount(%client,MineClusterModule))teamEnergyBuySell(%player,MineClusterModule.price );
			if(Player::getItemCount(%client,BombletClusterModule))teamEnergyBuySell(%player,BombletClusterModule.price );
			if(Player::getItemCount(%client,BunkerBusterModule))teamEnergyBuySell(%player,BunkerBusterModule.price );
			if(Player::getItemCount(%client,TankSmokeModule))teamEnergyBuySell(%player,TankSmokeModule.price );
			if(Player::getItemCount(%client,TankNerveGasModule))teamEnergyBuySell(%player,TankNerveGasModule.price );
			if(Player::getItemCount(%client,IncendiaryNapamModule))teamEnergyBuySell(%player,IncendiaryNapamModule.price );
			if(Player::getItemCount(%client,NuclearModule))teamEnergyBuySell(%player,NuclearModule.price );
			if(Player::getItemCount(%client,Mk82PackageModule))teamEnergyBuySell(%player,Mk82PackageModule.price );
			if(Player::getItemCount(%client,Mk84PackageModule))teamEnergyBuySell(%player,Mk84PackageModule.price );
			if(Player::getItemCount(%client,DaisyCutterModule))teamEnergyBuySell(%player,DaisyCutterModule.price );
			if(Player::getItemCount(%client,EMCModule))teamEnergyBuySell(%player,EMCModule.price );
			
			Player::setItemCount(%client,SideWinderModule, 0);
			Player::setItemCount(%client,PhoenixModule, 0);
			Player::setItemCount(%client,HellFireModule, 0);
			Player::setItemCount(%client,HydraModule, 0);
			Player::setItemCount(%client,UPKGunPodModule, 0);
			Player::setItemCount(%client,FiftyCalModule, 0);
			Player::setItemCount(%client,MaverickModule, 0);
			Player::setItemCount(%client,HARMModule, 0);
			// Bombs
			Player::setItemCount(%client,Mk82Module, 0);
			Player::setItemCount(%client,Mk84Module, 0);
			Player::setItemCount(%client,APClusterModule, 0);
			Player::setItemCount(%client,MineClusterModule, 0);
			Player::setItemCount(%client,BombletClusterModule, 0);
			Player::setItemCount(%client,BunkerBusterModule, 0);
			Player::setItemCount(%client,TankSmokeModule, 0);
			Player::setItemCount(%client,TankNerveGasModule, 0);
			Player::setItemCount(%client,IncendiaryNapamModule, 0);
			Player::setItemCount(%client,NuclearModule, 0);
			Player::setItemCount(%client,Mk82PackageModule, 0);
			Player::setItemCount(%client,Mk84PackageModule, 0);
			Player::setItemCount(%client,DaisyCutterModule, 0);
			// Other
			Player::setItemCount(%client,EMCModule, 0);
			
			if(%item == SideWinderModule) Bottomprint(%client, "The AIM-9 Sidewinder is a fast, heat-seeking, air-to-air locking missile. It has a high-explosive warhead and an active infrared guidance system. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == PhoenixModule) Bottomprint(%client, "The AIM-54 Phoenix is a fast, long-range, air-to-air radar guided locking missile. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == HellFireModule) Bottomprint(%client, "The AGM-114 Hellfire is an anti-armor air-to-surface missile primarily used by attack helicopters against ground armored units. It is a 4/1 Missile/Hardpoint requirement.", 10);
			if(%item == HydraModule) Bottomprint(%client, "The HYDRA 70 (70mm) Rocket System is a family of 2.75inch unguided rockets. Although mainly used as AtG missiles in ground supression, they can even be used as AtA missiles, delivering a violent shower of explosives to the enemy. It is a 19/1 Missile/Hardpoint requirement.", 10);
			if(%item == UPKGunPodModule) Bottomprint(%client, "The UPK-23 gun pod is mountable on the Hind. It houses a GSh-23L twin-barrel 23mm gun capable of 3000 rpm. It is a 250/1 Missile/Hardpoint requirement.", 10);
			if(%item == GUVGunPodModule) Bottomprint(%client, "The GUV gun pod is mountable on the Hind. It houses a four barreled 12.7mm YaKB-12.7 machinegun capable of 4000 rpm. It is a 750/1 Missile/Hardpoint requirement.", 10);
			if(%item == FiftyCalModule) Bottomprint(%client, "The M296 gun pod is mountable on the Kiowa. It houses a single .50 calibure machinegun capable of 500 rpm. It is a 500/1 Missile/Hardpoint requirement.", 10);
			if(%item == MaverickModule) Bottomprint(%client, "The AGM-65 Maverick is a tactical, air-to-surface missile designed for close air support, interdiction and ground defense suppression mission vs. Structures and armored units. It is a 1/1 Missile/Hardpoint requirement. ", 10);
			if(%item == HARMModule) Bottomprint(%client, "The AGM-88 HARM (high-speed antiradiation missile) is an air-to-surface tactical missile designed to seek and destroy enemy radar-equipped air defense systems. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == Mk82Module) Bottomprint(%client, "The MK-82 is a cheap, free-fall, nonguided general purpose 500-pound explosive bomb. It is a 1/2 Missile/Hardpoint requirement or a 1/1 bomb-bay requirement.", 10);
			if(%item == Mk84Module) Bottomprint(%client, "The MK-84 is a cheap, free-fall, nonguided general purpose 2000-pound explosive bomb. It is a 1/3 Missile/Hardpoint requirement or a 1/2 bomb-bay requirement.", 10);
			if(%item == APClusterModule) Bottomprint(%client, "The CBU-59 APAM an antipersonnel, antimaterial cluster bomb that expells hundreds of razar shards right before impact. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == MineClusterModule) Bottomprint(%client,"The CBU-89 Gator Mine is a 1,000-pound cluster munition containing a number of proximity mines, which are relased before impact. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == BombletClusterModule) Bottomprint(%client,"The CBU-87 is a 1,000-pound, Combined Effects Munition (CEM) for attacking soft target areas with 202 detonating bomblets, deadly to all targets. It is bright yellow when new. It is a 1/1 Missile/Hardpoint requirement.", 10);
			if(%item == BunkerBusterModule) Bottomprint(%client, "The BLU-113 Penetrator 'BunkerBuster' is a special weapon developed for penetrating any underground facilities. On impact, it burrows itself until a certain depth where it exploads. It is a 1/1 Missile/Hardpoint Requirement.", 10);
			if(%item == TankSmokeModule) Bottomprint(%client, "The M10 smoke tank is a large continer ment to lay a smoke screen or dispense chemicals such as tear gas. This type is a smoke tank. It is a 1/2 Missile/Hardpoint requirement.", 10);
			if(%item == TankNerveGasModule) Bottomprint(%client, "The M10 smoke tank is a large continer ment to lay a smoke screen or dispense chemicals such as tear gas. This type contains standard tear gas to confuse the enemy. It is a 1/2 Missile/Hardpoint requirement.", 10);
			if(%item == IncendiaryNapamModule) Bottomprint(%client, "The Mk77 is a fire bomb type bomb. Basicaly, it is a thin skinned container of nalpalm designed for use against dug-in troops, supply installations, and land convoys. It is a 1/3 Missile/Hardpoint requirement, but drops 5 bombs for each mounted bomb.", 10);
			if(%item == NuclearModule)
			{
				if(%client.scomm <= 3)
				{
					Client::sendMessage(%client,0,"You must be set as a commander by " @ 4 - %client.scomm @ " more people, in order to purchace a Hydrogen Bomb.");
					return;		
				}
				Bottomprint(%client, "The Mk-53 'hydrogen' bomb, first produced in 1962 is the most devistating weapon available. It is a Nuclear weapon capable of destroying everything. When dropped, it deploys parachutes to slowing carry it down. It is a 1/max bomb-bay requirement.", 10);
			}
			if(%item == EMCModule) Bottomprint(%client, "The ALQ-131 is an advanced electronic countermeasures (ECM) pod designed to provide an aircraft self-protection against radar threats. By carrying one, the aircraft is immune to all radar detection. It is a 1/2 Missile/Hardpoint requirement.", 10);
			if(%item == Mk82PackageModule) Bottomprint(%client, "The MK-82 is a cheap, free-fall, nonguided general purpose 500-pound explosive bomb. This module comes in a package of 4, ment to load Bombers faster. It is a a 4/4 bomb-bay requirement.", 10);
			if(%item == Mk84PackageModule) Bottomprint(%client, "The MK-84 is a cheap, free-fall, nonguided general purpose 2000-pound explosive bomb. This module comes in a package of 2, ment to load Bombers faster. It is a 2/4 bomb-bay requirement.", 10);
			if(%item == DaisyCutterModule) Bottomprint(%client, "The BLU-82B Daisy Cutter Bomb, is the largest conventional bomb weighing in at 15,000 pounds. It is delivered from an C-130 Hercules since it is far too heavy for the bomb racks on any bomber or attack aircraft, and eliminates one passenger seat per bomb. ", 10);
			if(%item == SupplyCrateModule) Bottomprint(%client, "The Supply crate is just that. A crate full of ammunition and medical supplies that can be dropped to remote positions during battle. It must be loaded on, an dropped from a cargo plane.", 10);
			teamEnergyBuySell(%player,%item.price * -1);
			Player::incItemCount(%client,%item);
			return 1;			
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopacksmall || %pack == ammopackheavy || %pack == ammopackexp) 
					checkMax(%client,%armor);
				// DELTA FORCE
				if(%item == charge) Bottomprint(%client, "The Explosive Charge is a small package of plastic explosive that is pre-set to a 15-second timer. Once it's been placed, get away from the area immediately!", 10);
				if(%item == twentypack) Bottomprint(%client, "The 20mm Cannon turret, in both deployable and static versions, is extremely powerful but must be controlled manually.", 10);
				if(%item == sampack) Bottomprint(%client, "The SAM Launcher is a powerful anti-aircraft weapon which fires automatically.", 10);
				if(%item == turretpack) Bottomprint(%client, "The Machine Gun is a small automatic rifle that fires on enemies automatically.", 10);
				if(%item == aapack) Bottomprint(%client, "The AA Flak Gun is an anti-aircraft turret that fires shells packed with flechette, preset to explode at a certain altitude.", 10);
				if(%item == howitzerpack) Bottomprint(%client, "The Howitzer is an artillery piece that lobs 120mm High-Explosive shells long distances to their targets.", 10);
				if(%item == portgenpack) Bottomprint(%client, "The Portable Generator, when placed in close proximity to stations, can provide a secondary source of power in case of failure in the primary generators.", 10);
				if(%item == reloaderpack) Bottomprint(%client, "The Reloader is used to reload turrets and vehicles when they have exhausted their ammunition supply.", 10);
				if(%item == medicpack) Bottomprint(%client, "The Medikit is the medic's primary tool. In skilled hands, it can quickly patch up wounded soldiers.", 10);
				if(%item == repairpack) Bottomprint(%client, "The Repair Toolkit is an all-purpose device that can repair damage to mechanical items such as stations, vehicles, and turrets.", 10);
				if(%item == parachute) Bottomprint(%client, "The best friend of the airborne infantry, the Parachute is the only thing that turns a terrifying plunge to earth into a gentle gliding descent.", 10);
				if(%item == airstrikepack) Bottomprint(%client, "The Airstrike is a laser designator which calls in friendly high-altitude bombers to drop a high-explosive care package on the selected location.", 10); 
				if(%item == grapplepack) Bottomprint(%client, "The Grappling Hook is the tool of choice for quickly scaling large obstacles and entering structures covertly.", 10);
				if(%item == sensorjammerpack) Bottomprint(%client, "The Sensor Jammer uses electronic warfare to confuse enemy ground sensors into not seeing the pack carrier, and those around him.", 10); 
				if(%item == pulsesensorpack) Bottomprint(%client, "The Ground Sensor is a minature version of a static sensor tower, and is able to detect and target enemy targets for friendly exploitation. This does not have radar capabilities.", 10);
				if(%item == radarpack) Bottomprint(%client, "The Radar is a minature version of a static radar tower, and is able to detect aircraft within a 400m radius.", 10);
				if(%item == deployablesensorjammerpack) Bottomprint(%client, "The Deployable Sensor Jammer uses electronic warfare to confuse enemy ground sensors into not seeing anyone around the device.", 10);
				if(%item == camerapack) Bottomprint(%client, "The Camera pack contains a small hidden camera that can be planted inside enemy strongholds in order to remotely view them.", 10);
				if(%item == motionsensorpack) Bottomprint(%client, "The Motion Sensor tracks nearby enemy movements.", 10);
				if(%item == sandbagpack) Bottomprint(%client, "The Sand Bag is just your standard canvas bag filled with sand. Effective for protecting troops against any type of non-Explosive projectile.", 10);
				if(%item == BouncingMinepack) Bottomprint(%client, "The M16 AP Mine is a bounding fragmentation type mine for use against Personel. When pressure is exerted onto the mine, it throws an explosive about head height in the air, ment to kill.", 10);
				if(%item == APMinepack) Bottomprint(%client, "The M14 AP Mine is a blast type mine for use against Personel. When pressure is exerted onto the mine, it exploads, causing lower body injury, ment to incapacitate. ", 10);
				if(%item == AAMinepack) Bottomprint(%client, "The M15 AA Mine is a blast type mine for use against Armored Vehicles. It uses an M624 fuse, which is activated when vehicle proprtionate presure is exerted. This is a KKill type mine.", 10);
				// END DELTA FORCE	
				if(%pack == FuelPack) {
					if(Player::getItemCount(%client,"Flamethrower") > 0) {
						Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
						remoteSellItem(%client,91);
					}
					player::setitemcount(%client,FlameAmmo,0);
					
				}

				teamEnergyBuySell(%player,%pack.price);
				Player::setItemCount(%client,%pack, 0);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				if(%item == APMinepack) {
					Player::incItemCount(%client,%item);
					Player::incItemCount(%client,%item);
				} else if(%item == BouncingMinepack) 
					Player::incItemCount(%client,%item);
				
				
				Player::useItem(%client,%item);									 
				if(%item == ammopacksmall) 
					fillSmallAmmoPack(%client);
				else if(%item == ammopackheavy) 
					fillHeavyAmmoPack(%client);
				else if(%item == ammopackexp) 
					fillExpAmmoPack(%client);
				else if(%item == reloaderpack)
					$ReloaderPackLeft[%client] = 100;
				if(%item == FuelPack)
					player::Setitemcount(%client,FlameAmmo,150);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%item == ammopacksmall) 
					fillSmallAmmoPack(%client);
				else if(%item == ammopackheavy) 
					fillHeavyAmmoPack(%client);
				else if(%item == ammopackexp) 
					fillExpAmmoPack(%client);
				else if(%item == reloaderpack)
					$ReloaderPackLeft[%client] = 100;
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				// DELTA FORCE
				if(%item == Flamethrower && Player::getItemCount(%client,"FuelPack") == 0) {
					buyItem(%client,"FuelPack");
					Client::sendMessage(%client,0,"Bought Flamethrower - Auto buying Fuel Pack");
				}
				if(%item == Knife) Bottomprint(%client, "This is a standard issue miliatry knife ment for survival if abandoned. If your out of ammo, and useing this, chances are your about to die. However, it could get you out alive if your lucky.", 10);
				if(%item == SOCOM) Bottomprint(%client, "The M9 Beretta is the preferred sidearm of many special forces units. It has high stopping power, but a low fire rate and ammo capacity, making it more of a weapon of last re.", 10);
				if(%item == OICW) Bottomprint(%client, "The M16 is a standard assault rifle. It has good stopping power and a fairly high fire rate, combined with good accuracy at both medium and short ranges.", 10);
				if(%item == SAW) Bottomprint(%client, "The M249 SAW is an infantry support light machine gun. It isn't as accurate as the OICW and its bullets don't have quite the stopping power, but it does have an insanely fast fire rate.", 10);
				if(%item == MP5) Bottomprint(%client, "The Silenced MP5 is a sub-machine gun designed for use in close quarters. It is somewhat inaccurate at any range beyond short, but it fires silently, allowing a commando to kill without alerting nearby enemies to his presence.", 10);
				if(%item == Flamethrower) Bottomprint(%client, "The Flamethrower, banned by many treaty organizations because of its horrible potential, has recently become more popular because of its ability to clear out enemy strongpoints with flame very quickly.", 10);
				if(%item == PSG1) Bottomprint(%client, "The PSG-1 is a semi-automatic sniper rifle. It has an exceptional rate of fire for a sniper rifle and carries a good amount of ammo, but is less accurate and less powerful than its counterpart, the Robar.", 10);
				if(%item == Stinger) Bottomprint(%client, "The Stinger is a man-portable SAM (Surface-to-Air Missile) Launcher that fires a small yet powerful heat-seeking warhead. It will not fire unless it is locked on to a valid target, so it is useless against all other targets besides aircraft.", 10);
				if(%item == FiftyCal) Bottomprint(%client, "The M40A1 is a bolt-action sniper rifle. It has incredible stopping power, accuracy, and range. Its disadvantages lie with its low ammo capacity and slow firing rate.", 10);
				if(%item == AutoShotgun) Bottomprint(%client, "The SPAS-12 is an automatic shotgun. It can be loaded with either flechette or slug rounds, and is extremely effective at close range.", 10);
				if(%item == LAW) Bottomprint(%client, "The LAW (Light Anti-tank Weapon) is a shoulder-fired rocket launcher. It is good at stopping enemy ground vehicles and clearing out bunkers. It has a short range, and is a one shot use, throw-away weapon.", 10);
				if(%item == Howitzer) Bottomprint(%client, "The Howitzer is an artillery piece that lobs 120mm High-Explosive shells long distances to their target. It fires very slowly, but it has an enormous explosion radius.", 10); 
				// END DELTA FORCE
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType;
				if(%ammoItem != "") {
//					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
//					if((%delta || $testCheats) && %item != Flamethrower){
//						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						if($ClipSize[%item] != "")
							Player::incItemCount(%client,%ammoitem,$ClipSize[%item]);
						else if(%ammoItem == LAWAmmo)
							player::incitemcount(%client,%ammoitem,1); // DIRT HACK!
//					}
				}
				%ammoItem =  $Clip[%item]; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				
				%team = GameBase::getTeam(%client);
				
						
				// DELTA FORCE
				if(%item == FalconVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The F-16 Falcon is a fast, light Air to Ground attack craft with good dogfighting capabilites. It is heavier, but slower and less manuverable then the F-14 Tomcat. It boasts an interal 20mm cannon and 7 hard points to mount varius air to air, and air to surface, missiles, as well as a number of bombs.", 10);
				%shouldBuy = JetStation::checkBuying(%client,%item);
				$AirUnits[%team]--;
				}
				//if(%item == DiveBomberVehicle) {
				//	Bottomprint(%client, "The JU87B-1 Stuka is a fast, light Air to Ground Divebomber craft, wielding heavy Mk 84 Bombs, and bosting a 20mm chaingun for personal protection.", 10);
				//%shouldBuy = JetStation::checkBuying(%client,%item);
				//}
				if(%item == TomcatVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The F-14 Tomcat is a twin-engine, variable sweep wing fighter designed to attack and destroy enemy aircraft. It is faster and more manuverable, but lighter then its F-16 child. It houses a 20mm M61-A1 Vulcan Gun, and 6 hard points for air to air mounted missiles. It also has a small selection of bombs to choice from.", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == ApacheVehicle) {
					if($IsTourny)
						if($ChopperUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Choppers left!");
							return 0;
						}
					Bottomprint(%client, "The Apache is a lightly-armored fast-attack VTOL craft that mounts a 20mm chaingun 6 hard points for hellfire and sidewinder missiles.", 10);
				$ChopperUnits[%team]--;
				%shouldBuy = ChopperStation::checkBuying(%client,%item);
				}
				if(%item == KiowaVehicle) {
					if($IsTourny)
						if($ChopperUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Choppers left!");
							return 0;
						}
					Bottomprint(%client, "The OH-58D Kiowa Warrior is a two-place single engine armed reconnaissance helicopter. The OH-58D's highly accurate navigation system permits precise target location that can be handed-off to other engagement systems.", 10);
				$ChopperUnits[%team]--;
				%shouldBuy = ChopperStation::checkBuying(%client,%item);
				}
				if(%item == HindVehicle) {
					if($IsTourny)
						if($ChopperUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Choppers left!");
							return 0;
						}
					Bottomprint(%client, "The Mi-24 Hind is one of the scariest sights for anyone unfortunate enough to be on the ground. Its seemingly impenetrable exterior protects it from almost any kind of attack. It boasts 30mm Vulcan cannons to quickly clear enemy troops, and 6 hard points cabable of carrying almost any mountable weapon an A-10 can.", 10);
				$ChopperUnits[%team]--;
				%shouldBuy = ChopperStation::checkBuying(%client,%item);
				}
				if(%item == WarthogVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The A-10 Warthog is an extremely durable aircraft that serves primarily in an anti-tank role, and low altitude bomber roll. It carries a 30mm cannon, and can mount an extreamly wide array of missiles and bombs on its numerous 11 hard points.", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == BomberVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The B-52 Stratofortress is the most powerfull bomber available. Along with its heavy armor, it flies at high alditudes, has radar jamming capabilites, and mostly relies on an escort to keap it safe. It can house an extreamly large number of freefall bombs, or even a hydrogen bomb for devistating effects on target instalations.", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == HerculesVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The C-130 Hercules is a personel and equipment carrier. Its primary roll is to carry soldiers high over enemy territory, and paratroop them in. This vehicle is highly vulnerable to enemy fighters, so keap it well guarded! ", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == SentryVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The E-3 Sentry is an airborne warning and control system (AWACS) aircraft that provides all-weather long range radar, and serves as a command, control, and communications center for commanders. A vital aircraft to any air defense or attack, it is usually best to shoot this one down first!", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == GunshipVehicle) {
					if($IsTourny)
						if($AirUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Jets left!");
							return 0;
						}
					Bottomprint(%client, "The AC-130U Gunship is a heavily modified C-130. It boasts a 105mm cannon, a 40mm cannon, and two 25mm guns. This weapons platform, although slow, is heavily armored, and can take care of itself if needed. It is primarily used to guard defensless planes against enemy attackers, as well as wiping the ground of enemy troopers and tanks before invasions.", 10);
				$AirUnits[%team]--;
				%shouldBuy = JetStation::checkBuying(%client,%item);
				}
				if(%item == BlackhawkVehicle) {
					if($IsTourny)
						if($ChopperUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Choppers left!");
							return 0;
						}
					Bottomprint(%client, "The Blackhawk is a three-man VTOL craft that doubles as a personnel carrier and a gunship. Each passenger automatically mounts a minigun while on the vehicle which they can use to attack targets of opportunity on the ground.", 10);
				$ChopperUnits[%team]--;
				%shouldBuy = ChopperStation::checkBuying(%client,%item);
				}
				if(%item == AbramsVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "The M1A1 Abrams is a standard three-man battle tank. The passenger on the left side of the vehicle mounts the 105mm main turret gun while the one on the right uses the anti-personnel machine gun. The Abrams is completely invulnerable to small arms fire.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				if(%item == BradleyVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "The M113 APC is a five-man transport tank. It has only minor mounted guns, and passengers can shoot out of it. It is completely invulnerable to small arms fire.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				if(%item == HumveeVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "The HMMWV \"Hummer\" is a fast scout vehicle used for anti-tank operations and forward recon. It is mounted with a TOW Launcher and an MK-19 Auto Grenade Launcher.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				if(%item == LineBackerVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "Linebacker provides heavy maneuver forces with dedicated air defense fire power: the modified fire control subsystem fires the Stinger missile from the turret while the four- man squad remains under armor and on the move.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				if(%item == MLRSVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "The Multiple Launch Rocket System (MLRS) provides the Army an all-weather, indirect, area fire weapon system to strike counterfire, air defense, armored formations, and other high-payoff targets at all depths of the tactical battlefield. Primary missions of MLRS include the suppression, neutralization and destruction of threat fire support and forward area air defense targets.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				if(%item == MineLayerVehicle) {
					if($IsTourny)
						if($TankUnits[%team] <= 0) {
							Client::sendMessage(%client,0,"You have no Tanks left!");
							return 0;
						}
					Bottomprint(%client, "The M548A3 Cargo Carrier is a tracked vehicle ment for general purpose cargo. However, it has been fitted with the Volcano mine dispensing system for rapid minefield deployment.", 10);
				$TankUnits[%team]--;
				%shouldBuy = TankStation::checkBuying(%client,%item);
				}
				// END DELTA FORCE
				//%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
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
}

function armorChange2(%client)
{
	%player = Client::getOwnedObject(%client);
	
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(Client::getOwnedObject(%client).Station == "")
		return;
	if(buyItem(%client,%item)) 
	{
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
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) && %player.Station != "" ) 
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor) 
		{
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) 
			{
				return;
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopacksmall || %item == ammopackheavy || %item == ammopackexp) 
				checkMax(%client,Player::getArmor(%client));
			else if(%item == FuelPack) 
			{
				if(Player::getItemCount(%client,"Flamethrower") > 0) 
				{
					Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
					remoteSellItem(%client,91);
				}
					player::Setitemcount(%client,FlameAmmo,0);
			}
			else if($TeamItemMax[%item] != "") 
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			if(%item.className == Weapon && %item.imageType.ammoType != "" && %item != Flamethrower)
			{
				player::setitemcount(%player,%item.imageType.ammoType,0);
			}
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
%item = getItemData(%type);
	%clientid = player::getClient(%client);
	if(%clientid.ismaker)
	{
		SortRemoteItem(%clientid, %item);

	}
	%client.throwStrength = 1;

	//%item = getItemData(%type);
	if(%item=="TargetingLaser")
	{
		checkwhichtool(%client);
		return;
	}
	if(%item=="Beacon"&&(player::getmounteditem(%client,0)=="GrappleHook")&&%client.isgrappling)
	{
	  swing(%client, 0);
	   return;
	}
	else if(%item=="Beacon" && (player::getmounteditem(%client,3)=="Flashlight"))
	{
	   doflash(%client);
	   return;
	} else if(%item=="Beacon")
	{
		Beacon::onuse(%client);
	}
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon)
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	if ($woundedWeaponArm[Player::getClient(%client)] == 1 && %item == Weapon)
		bottomprint(%client, "<f5><jc>You've been shot in the arm and cannot hold a weapon!", 3);
	else if(%client.inVehicle)
		return;
	else
	{
		Player::useItem(%client,%item);
	}
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(getItemData(%type) == "mineammo"&&(player::getmounteditem(%player,0)=="GrappleHook")&&%player.isgrappling)
	{
		swing(%player, 8);
		return;
	}
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) 
	{

		if(getItemData(%type) == grenade && Gamebase::getcontrolclient(%player) == -1)
		{
			%vehicle = Client::getControlObject(%client);
			%vehicleName = GameBase::getDataName(%vehicle);
			if( %vehiclename == Hurcules  || %vehiclename == Abrams || %vehiclename == Bradley || %vehiclename == Humvee || %vehiclename == LineBacker || %vehiclename == MLRS || %vehiclename == MineLayer )
			{
				bottomprint(%client, "<jc>No countermeasures availabe for this vehicle!", 5);
			} 
			else if ( %client.countermeasure != "Flare" && %client.countermeasure != "Chaff")					
			{

				bottomprint(%client, "<jc>You must set your countermeasure type!(tab->weaponoptions->countermeasure)!", 5);
			}
			else 
			{

				if($VehicleCounterMeasuresCur[%vehicle] < 1) 
				{
					bottomprint(%client, "<jc>Out of countermeasures!", 5);
					return;
				} else 
				{
					bottomprint(%client, "<jc>Droping " @ %player.countermeasure @ " " @$VehicleCounterMeasuresCur[%vehicle]@ "/" @$VehicleCounterMeasures[%vehiclename], 5);
					$VehicleCounterMeasuresCur[%vehicle]--;
					DropCountermeasure(%vehicle, %player);
				}
			}	
			
		
		}
		else if(getItemData(%type) == MineAmmo && Gamebase::getcontrolclient(%player) == -1) 
		{
	
			if(%player.driver == 1)
				Vehicle::EndRoll(%player.vehicle);
		
		} 
		else if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") 
		{
		//if(GameBase::getControlClient(%player) != -1) 
			if($STHROW)
		  		echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			
			if($cannotthrow[%client])
				return;
			if(%item==grenade&&player::getitemcount(%player, grenade)>0&&!$Reloading[%client])
			{
				
				if (%strength < 0)
					%strength = 0;
				else
				if (%strength > 100)
					%strength = 100;
				newthrow(%client, %Item, %strength);
				return;
			}
			if (%item == Grenade || %item == MineAmmo && !$cannotthrow[%client]) 
			{
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;

				%client.throwStrength = 0.3 + 0.35 * (%strength / 100);
				//put in something for genediers.
				if(Player::getArmor(%player) == garmor || Player::getArmor(%player) == gfemale ) 
				{
					%client.throwStrength = 0.3 + 0.35 * (%strength / 100)* 2;				

				}
				if(%item == MineAmmo)
					MineAmmo::onuse(%client, %Item);
				else
					Player::useItem(%client,%item);
			}
		} 
	}
}

function remoteDropItem(%client,%type)
{
	// centerprintall("remoteDropItem() called",5);
	if((Client::getOwnedObject(%client)).driver != 1) {
		//echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		if (%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
			if (%item == Parachute || $ParaActivated[%client] == 1) { 
				hitGround(%client);
				// centerprintall("parachute check sound in remotedropitem()",5);		

			}
		}
	    else if (%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon && $Clip[%item] != "") {
				%item = $Clip[%item];
				Player::dropItem(%client,%item);	
			}
		}
		else if(%item == Flag)
		{
			Player::dropItem(%client,Flag);
			player::dropItem(%client,CDFlag);
		}
		else
			Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

// DELTA FORCE
$NextWeapon[Knife] = SOCOM;
$NextWeapon[SOCOM] = OICW;
$NextWeapon[OICW] = SAW;
$NextWeapon[SAW] = MP5;
$NextWeapon[MP5] = PSG1;
$NextWeapon[PSG1] = FiftyCal;
$NextWeapon[FiftyCal] = LAW;
$NextWeapon[LAW] = Howitzer;
$NextWeapon[Howitzer] = Airstrike;
$NextWeapon[Airstrike] = Minigun;
$NextWeapon[Minigun] = LowMountMinigun;
$NextWeapon[LowMountMinigun] = TwentyFivemmgun;
$NextWeapon[TwentyFivemmgun] = LowMountTwentyFivemmgun;
$NextWeapon[LowMountTwentyFivemmgun] = Fortymmgun;
$NextWeapon[Fortymmgun] = AbramsGun;
$NextWeapon[AbramsGun] = LowMountAbramsGun;
$NextWeapon[LowMountAbramsGun] = TOW;
$NextWeapon[TOW] = AutoGrenLauncher;
$NextWeapon[AutoGrenLauncher] = StingerLauncherGun;
$NextWeapon[StingerLauncherGun] = MLRSLauncher;
$NextWeapon[MLRSLauncher] = AutoShotgun;
$NextWeapon[AutoShotgun] = Stinger;
$NextWeapon[Stinger] = Flamethrower;
$NextWeapon[Flamethrower] = RepairGun;
$NextWeapon[RepairGun] = MedicGun;
$NextWeapon[MedicGun] = GrappleHook;
$NextWeapon[GrappleHook] = Knife;

$PrevWeapon[OICW] = SOCOM;
$PrevWeapon[SOCOM] = Knife;
$PrevWeapon[Knife] = GrappleHook;
$PrevWeapon[Airstrike] = Howitzer;
$PrevWeapon[Howitzer] = LAW;
$PrevWeapon[LAW] = FiftyCal;
$PrevWeapon[FiftyCal] = PSG1;
$PrevWeapon[PSG1] = MP5;
$PrevWeapon[MP5] = SAW;
$PrevWeapon[SAW] = OICW;
$PrevWeapon[Minigun] = Airstrike;
$PrevWeapon[LowMountMinigun] = Minigun;
$PrevWeapon[TwentyFivemmgun] = LowMountMinigun;
$PrevWeapon[LowMountTwentyFivemmgun] = TwentyFivemmgun;
$PrevWeapon[Fortymmgun] = LowMountTwentyFivemmgun;
$PrevWeapon[AbramsGun] = Fortymmgun;
$PrevWeapon[LowMountAbramsGun] = AbramsGun;
$PrevWeapon[TOW] = LowMountAbramsGun;
$PrevWeapon[AutoGrenLauncher] = TOW;
$PrevWeapon[MLRSLauncher] = AutoGrenLauncher;
$PrevWeapon[StingerLauncherGun] = MLRSLauncher;
$PrevWeapon[AutoShotgun] = StingerLauncherGun;
$PrevWeapon[Stinger] = AutoShotgun;
$PrevWeapon[Flamethrower] = Stinger;
$PrevWeapon[RepairGun] = Flamethrower;
$PrevWeapon[MedicGun] = RepairGun;
$PrevWeapon[GrappleHook] = MedicGun;
// END DELTA FORCE

function remoteNextWeapon(%client)
{
	// Al-la WorstAim's crash protection
	// **

	if(%client.observerMode != "")
	{
		return;
	}
	// **

	%vehicle = Client::getControlObject(%client);
	%name = GameBase::getDataName(%vehicle);
	// If the player is flying something...
	if(%client.hflink == 2 && Vehicle::hasPilotWeapon(%vehicle))
	return;

	if(Vehicle::hasPilotWeapon(%vehicle))
	{
		%weaponNum = $VehicleGuns[%vehicle];
		if(%weaponNum > 0) {
			if($VehicleCurWeapon[%vehicle] < (%weaponNum-1))
				$VehicleCurWeapon[%Vehicle]++;
			else
				$VehicleCurWeapon[%vehicle] = 0;
			
			%weapPName = $WeaponDesc[$VehicleOwnedWeapon[%Vehicle,$VehicleCurWeapon[%vehicle]]];
			%weapName = $VehicleOwnedWeapon[%Vehicle,$VehicleCurWeapon[%vehicle]];

			Bottomprint(%client, "<jc>" @ %weapPName @ " selected", 3);

			%enerLevel = 100;
			if($VehicleWeaponAmmoMax[%name, %weapName] != -1)
			{
				%enerLevel = $VehicleWeaponAmmo[%vehicle, %weapName] / $VehicleWeaponAmmoMax[%name, %weapName] * 100;
			}
			GameBase::setEnergy(%vehicle, %enerLevel);
			Locking::CheckToStartLoop(%vehicle,%weapName);
		}		
	} else { // Just a standard weapon change
		if(Player::getItemClassCount(%client,Weapon) == 0 && player::Getitemcount(%client,knife) == 0) {
			bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
			return FALSE;
		}

		if ($woundedWeaponArm[Player::getClient(%client)] == 1)
		{
			bottomPrint(%client, "<f5><jc>You've been shot in the arm and cannot hold a weapon!", 3);
			return;
		}
		if($Reloading[%client] == 1)
			return Reloading;
		if(Player::getItemState(%client,$WeaponSlot) == Spinup || Player::getItemState(%client,$WeaponSlot) == Fire || Player::getItemState(%client,$WeaponSlot) == SpinDown)
			return;
		if (%client.inVehicle && Gamebase::getDataName(%client.vehicle) != Hind){
			return;
		}
		else {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if (%item == -1 || $NextWeapon[%item] == "")
				selectValidWeapon(%client);
			else {
				for (%weapon = $NextWeapon[%item]; %weapon != %item; 
				%weapon = $NextWeapon[%weapon]) {
					if (isSelectableWeapon(%client,%weapon)) {

						Player::useItem(%client,%weapon);
						// Make sure it mounted (laser may not), or at least
						// next in line to be mounted.
						if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || 
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
							break;
					}
				}
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	// Al-la WorstAim's crash protection
	// **
	if(%client.observerMode != "")
	{
			return;
	}
	// **

	%vehicle = Client::getControlObject(%client);
	%name = GameBase::getDataName(%vehicle);
	// If the player is flying something...
	if(%client.hflink == 2 && Vehicle::hasPilotWeapon(%vehicle))
	return;
	if( Vehicle::hasPilotWeapon(%vehicle))
	{
		%weaponNum = $VehicleGuns[%Vehicle];
		if(%weaponNum > 0) {
			if($VehicleCurWeapon[%vehicle] == 0)
				$VehicleCurWeapon[%vehicle] = %weaponNum-1;
			else
				$VehicleCurWeapon[%vehicle]--;

			%weapPName = $WeaponDesc[$VehicleOwnedWeapon[%Vehicle,$VehicleCurWeapon[%vehicle]]];
			%weapName = $VehicleOwnedWeapon[%Vehicle,$VehicleCurWeapon[%vehicle]];

			Bottomprint(%client, "<jc>" @ %weapPName @ " selected", 3);


			if($VehicleWeaponAmmoMax[%name, %weapName] != -1)
			{
				%enerLevel = $VehicleWeaponAmmo[%vehicle, %weapName] / $VehicleWeaponAmmoMax[%name, %weapName] * 100;
			} else
			{
				%enerLevel = 100;
			}
			GameBase::setEnergy(%vehicle, %enerLevel);
			Locking::CheckToStartLoop(%vehicle,%weapName);	
		}
	} else {  // Just a standard weapon change

		if(Player::getItemClassCount(%client,Weapon) == 0 && player::Getitemcount(%client,knife) == 0) {
			bottomprint(%client, "<jc><f0>No Weapons!!!", 1);
			return FALSE;
		}
		if ($woundedWeaponArm[Player::getClient(%client)] == 1)
		{
			bottomPrint(%client, "<f5><jc>You've been shot in the arm and cannot hold a weapon!", 3);
			return;
		}
		if($Reloading[%client] == 1)
			return Reloading;
		if(Player::getItemState(%client,$WeaponSlot) == Spinup || Player::getItemState(%client,$WeaponSlot) == Fire || Player::getItemState(%client,$WeaponSlot) == SpinDown)
			return;
		if (%client.inVehicle && Gamebase::getDataName(%client.vehicle) != Hind){
			return;
		}
		else {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if (%item == -1 || $PrevWeapon[%item] == "")
				selectValidWeapon(%client);
			else {
				for (%weapon = $PrevWeapon[%item]; %weapon != %item; 
				%weapon = $PrevWeapon[%weapon]) {
					if (isSelectableWeapon(%client,%weapon)) {
						Player::useItem(%client,%weapon);
						// Make sure it mounted (laser may not), or at least
						// next in line to be mounted.
						if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || 
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
							break;
					}
				}
			}
		}
	}
}

function selectValidWeapon(%client)
{
	%item = Flamethrower;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;
			%weapon = $NextWeapon[%weapon]) {
		if (isSelectableWeapon(%client,%weapon)) {

			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if($Reloading[%client] != 1) {
			if(%ammo == ""||Player::getItemCount(%client,%ammo) > 0|| ($Clip[%weapon] != "" && Player::getItemCount(%client,$Clip[%weapon]) > 0))
				return true;
		}
	}
	return false;
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
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
			%extraAmmo = 0;
			%mountItem = Player::getMountedItem(%client,$BackpackSlot);
//			if ((%mountItem == ammopacksmall || %mountItem == ammopackheavy || %mountItem == ammopackexp) && $AmmoPackMax[%item] != "") 
//				%extraAmmo = $AmmoPackMax[%item];
			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if (%delta > 0) {
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
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");if(Item::getItemData("@%this@")==LAW){"@%this@".ammocount=1;}",$ItemRespawnTime,%this);
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
	
	if (getObjectType(%object) == "Player") {
		
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		
		if($woundedWeaponArm[Player::getClient(%object)] == 1 && %item.className == Weapon ) 
			bottomprint(%object, "<f5><jc>You've been shot in the arm and cannot hold a weapon!", 3);
		else if (%item.className == Ammo)
		{
			// Dirty ugly hack!
			if($AmmoToWeapon[%item] != "")
				Item::giveItem(%object,$Clip[$AmmoToWeapon[%item]],1);
		}
		else if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			if($WeaponAmmo[%item] != "" && %item != Flamethrower)
			{
				%amt = %this.ammocount;
				if(%amt > $ClipSize[%item])
					%amt = $ClipSize[%item];
				player::setitemcount(%object,$WeaponAmmo[%item],%amt);
				if(%item == LAW && %this.ammocount == "")// another dirty hack
					player::Setitemcount(%object,$WeaponAmmo[%item],1);
				%this.ammocount = 0;
				
			} else if(%item == FuelPack)
			{
				if(%this.autofill)
				{
				%this.autofill = 0;
				player::setitemcount(%object,FlameAmmo, 150);
				%this.fuel = 0;
				} else
				{
				player::setitemcount(%object,FlameAmmo,%this.fuel);
				%this.fuel = 0;
				}
			}
			if(%this.autofill)
			{
			echo(%item);
			%this.autofill = 0;
			if(%item == AmmoPackHeavy)
				fillHeavyAmmoPack(player::GetClient(%object));
			if(%item == AmmoPackSmall)
				fillSmallAmmoPack(player::GetClient(%object));
			if(%item == AmmoPackExp)
				fillExpAmmoPack(player::GetClient(%object));
			if(%item == reloaderpack)
				$ReloaderPackLeft[player::GetClient(%object)] = 100;
			}
			else if(%item == AmmoPackHeavy || %item == AmmoPackSmall || %item == AmmoPackExp)
				checkPacksAmmo(%object, %this);
			
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
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
	//echo("Item used: ",%player," ",%item);
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
	%item.autofill = 0;
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
			
				//echo("Item dropped: ",%player," ",%item);
				%obj = newObject("","Item",%item,1,false);
 	 		  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 		addToSet("MissionCleanup", %obj);
				if(%item == Parachute && $ParaActivated[%player] == 1 && !Player::isDead(%player)){
						hitGround(%player);
				} else {
		
					if(%item.classname == Weapon && $WeaponAmmo[%item] != "" && %item != Flamethrower)
					{
						%amt = 	player::getItemCount(%player,$WeaponAmmo[%item]);		
						if(%amt > $ClipSize[%item])
							%amt = $ClipSize[%item];
						%obj.ammoCount = %amt;
						player::setItemCount(%player,$WeaponAmmo[%item],0);
					}
					if(%item == FuelPack)
					{
						%obj.Fuel = player::getItemcount(%player,FlameAmmo);
						player::setItemcount(%player,FlameAmmo,0);
					}
					if (Player::isDead(%player)) 
						GameBase::throw(%obj,%player,10,true);
					else {
						GameBase::throw(%obj,%player,15,false);
						Item::playPickupSound(%obj);
					}
					Player::decItemCount(%player,%item,1);
					return %obj;
				}
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
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
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
// DELTA FORCE ARMOR
// ------------------------------------

ItemData InfantryArmor
{
   heading = "aArmor";
	description = "Infantry";
	className = "Armor";
	price = 200;
};

ItemData GrenadierArmor
{
   heading = "aArmor";
	description = "Grenadier";
	className = "Armor";
	price = 200;
};

ItemData MedicArmor
{
   heading = "aArmor";
	description = "Medic";
	className = "Armor";
	price = 300;
};

ItemData SniperArmor
{
   heading = "aArmor";
	description = "Sniper";
	className = "Armor";
	price = 250;
};

ItemData SpecOpsArmor
{
   heading = "aArmor";
	description = "SpecOps";
	className = "Armor";
	price = 350;
};

ItemData EngineerArmor
{
   heading = "aArmor";
	description = "Army Engineer";
	className = "Armor";
	price = 250;
};

ItemData PilotArmor
{
   heading = "aArmor";
	description = "Pilot";
	className = "Armor";
	price = 200;
};

ItemData ArtilleryArmor
{
   heading = "aArmor";
	description = "Artillery";
	className = "Armor";
	price = 400;
};

ItemData CommandoArmor
{
   heading = "aArmor";
	description = "Commando";
	className = "Armor";
	price = 1000;
};

// END DELTA FORCE ARMOR
// -------------------------------------------------

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

// DELTA FORCE VEHICLES
// --------------------------------------------

ItemData FalconVehicle
{
	description = "F-16 Falcon";
	className = "Vehicle";
   heading = "aVehicle";
	price = 7000;
};

//ItemData DiveBomberVehicle
//{
//	description = "JU87B-1 Sturzkampfflugzeus";
//	className = "Vehicle";
//   heading = "aVehicle";
//	price = 7000;
//};

ItemData TomcatVehicle
{
	description = "F-14 Tomcat";
	className = "Vehicle";
   heading = "aVehicle";
	price = 7000;
};

ItemData ApacheVehicle
{
	description = "AH-64 Apache";
	className = "Vehicle";
   heading = "aVehicle";
	price = 7000;
};

ItemData KiowaVehicle
{
	description = "OH-58D Kiowa";
	className = "Vehicle";
   heading = "aVehicle";
	price = 10000;
};

ItemData HindVehicle
{
	description = "Mi-24 Hind";
	className = "Vehicle";
   heading = "aVehicle";
	price = 9000;
};

ItemData WarthogVehicle
{
	description = "A-10 Warthog";
	className = "Vehicle";
   heading = "aVehicle";
	price = 9000;
};

ItemData BomberVehicle
{
	description = "B-52 Stratofortress";
	className = "Vehicle";
   heading = "aVehicle";
	price = 11000;
};

ItemData HerculesVehicle
{
	description = "C-130 Hercules";
	className = "Vehicle";
   heading = "aVehicle";
	price = 10000;
};

ItemData SentryVehicle
{
	description = "E-3 Sentry";
	className = "Vehicle";
   heading = "aVehicle";
	price = 12000;
};

ItemData GunshipVehicle
{
	description = "AC-130U Gunship";
	className = "Vehicle";
   heading = "aVehicle";
	price = 11000;
};

ItemData BlackhawkVehicle
{
	description = "UH-60 Blackhawk";
	className = "Vehicle";
   heading = "aVehicle";
	price = 8500;
};

ItemData HumveeVehicle
{
	description = "HMMWV";
	className = "Vehicle";
   heading = "aVehicle";
	price = 7000;
};

ItemData AbramsVehicle
{
	description = "M1A1 Abrams Tank";
	className = "Vehicle";
   heading = "aVehicle";
	price = 9000;
};

ItemData BradleyVehicle
{
	description = "M113 APC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 9000;
};

ItemData LineBackerVehicle
{
	description = "M6 Bradley LineBacker";
	className = "Vehicle";
	heading = "aVehicle";
	price = 10000;
};

ItemData MLRSVehicle
{
	description = "M270 MLRS SPLL";
	className = "Vehicle";
	heading = "aVehicle";
	price = 12000;
};

ItemData MineLayerVehicle
{
	description = "M548A3 W/ Volcano";
	className = "Vehicle";
	heading = "aVehicle";
	price = 10000;
};

// ---------------------------------------------
//END DELTA FORCE VEHICLES

//======================================================================== 
// Vehicle Module's
//========================================================================
	
ItemImageData FlyerModuleImage 
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.5 };
	mountRotation = {0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData SideWinderModule
{
	description = "AIM-9 SideWinder Missile";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 700;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData PhoenixModule
{
	description = "AIM-54 Phoenix Missile";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 2000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData HellFireModule
{
	description = "AGM-114 HellFire Missiles";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1300;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData HydraModule
{
	description = "HYDRA-70/2.75 Inch Rocket System";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData UPKGunPodModule
{
	description = "UPK-23-250 23mm Gun Pod";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData GUVGunPodModule
{
	description = "GUV YaKB 12.7mm Gun Pod";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData FiftyCalModule
{
	description = "M296 .50 Cal Gun Pod";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData MaverickModule
{
	description = "AGM-65 Maverick Missile";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 800;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData HARMModule
{
	description = "AGM-88 HARM Missile";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 900;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData Mk82Module
{
	description = "Mk-82 500Lb Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData Mk84Module
{
	description = "Mk84 2000Lb Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 400;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData APClusterModule
{
	description = "CBU-59 APAM ClusterBomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData MineClusterModule
{
	description = "CBU-89 GatorMine ClusterBomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData BombletClusterModule
{
	description = "CBU-87 CEM ClusterBomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData BunkerBusterModule
{
	description = "BLU-113 Penetrator";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData TankSmokeModule
{
	description = "M-10 Tank: Smoke screen";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 700;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData TankNerveGasModule
{
	description = "M-10 Tank: Nerve Gas";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1100;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData IncendiaryNapamModule
{
	description = "Mk-77 Incendiary Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 900;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData NuclearModule
{
	description = "Mk-53 Hydrogen Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 189000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData EMCModule
{
	description = "ALQ-131 EMC Pod";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData Mk82PackageModule
{
	description = "[4]Mk-82 500Lb Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 800;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData Mk84PackageModule
{
	description = "[2]Mk84 2000Lb Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 800;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};
ItemData DaisyCutterModule
{
	description = "BLU-82B Daisy Cutter Bomb";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 1500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData SupplyCrateModule
{
	description = "Supply Crate";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "nVehicle Module";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = $RemoteInvEnergy + 400;
	hudIcon = "shieldpack";
	showWeaponBar = true;
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
	if(%player.Station == "") {
		%ammo = %item.imageType.ammoType;
		Player::mountItem(%player,%item,$WeaponSlot);
		if(Player::getItemCount(%player,%ammo) < 0 && Player::getItemCount(%player,$Clip[%item]) < 0)
		{
			bottomprint(%client,"<jc><f0>Out of Clips!!!", 2);
			if(Player::isAIControlled(%player))
				   Player::mountItem(%aiId, SOCOM, 0);

		}
		if(Player::getItemCount(%player,%ammo) < 0 && Player::getItemCount(%player,$Clip[%item]) > 0)
			Player::useItem(%player,$Clip[%item]);
	}
		Locking::CheckToStartLoop(Client::getControlObject(%client),%item);	
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

//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDropOrig(%player,%item)
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

function Ammo::onDrop(%player,%item)
{
}	



ItemData Ghost
{
	description = "Ghost";
	showInventory = false;
};



ItemData GhostTarget
{
        description = "Ghost Target";
        className = "Ghost";
        shapeFile = "breath";
        heading = "xAmmunition";
        shadowdetailmask = 0;
        price = 0;
};


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
			
			if(Player::isAIControlled(%player))
				schedule("Player::mountItem("@%player@", SOCOM, 0);",2);
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
	if(($ItemMax[%armor, %item])) 
		Player::setAnimation(%player, 21);
}

function ReloadThree(%player,%weapon,%RDPer)
{
	%armor = Player::getArmor(%player);
	%item = %weapon;
	if(($ItemMax[%armor, %item])) 
	{
		Player::setItemCount(%player,%weapon.imageType.ammoType,$ClipSize[%weapon]);
		Player::decItemCount(%player,$Clip[%weapon]);
	}
}

function ReloadFour(%player,%weapon,%RDPer)
{
	%armor = Player::getArmor(%player);
	%item = %weapon;
	if(($ItemMax[%armor, %item])) 
	{
		Locking::CheckToStartLoop(%player,%item);	
		Player::MountItem(%player,%weapon,$WeaponSlot);
	
	}
}

function ReloadFive(%player,%weapon,%RDPer)
{
	// Always want to end reloading.
	%client = Player::getClient(%player);
	$Reloading[Player::getClient(%player)] = 0;
}

//----------------------------------------------------------------------------
//-Clips
//----------------------------------------------------------------------------

ItemData SOCOMClip
{
        description = "M9 Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 30;
};

ItemData OICWClip
{
        description = "M16 Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 60;
};

ItemData SAWClip
{
        description = "SAW Mag";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 200;
};

ItemData MP5Clip
{
        description = "MP5 Clip";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 60;
};

ItemData PSG1Clip
{
        description = "PSG1 Mag";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 10;
};

ItemData FiftyCalClip
{
        description = "FiftyCal Mag";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 10;
};

ItemData AutoShotgunClip
{
        description = "AutoShotgun Mag";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 10;
};

ItemData StingerClip
{
        description = "Stinger Missile";
        className = "Clip";
        shapeFile = "ammo1";
        heading = "xAmmunition";
        shadowdetailmask = 4;
        price = 300;
};



//----------------------------------------------------------------------------
//-Weapons
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

	projectileType = BlasterBolt;
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
	projectileType = ChaingunBullet;
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
	projectileType = PlasmaBolt;
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
	projectileType = GrenadeShell;
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
	projectileType = MortarShell;
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
	projectileType = DiscShell;
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

// DELTA FORCE WEAPONS
// ------------------------------------------

ItemImageData KnifeImage
{
   shapeFile = "force";
	mountPoint = 0;
	//mountRotation = { 1.57, 0, 0 };
	
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = KnifeStab;
	accuFire = true;

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Knife
{
   heading = "bWeapons";
	description = "Combat Knife";
	className = "Tool";
   shapeFile = "bullet";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = KnifeImage;
	price = 10;
	showWeaponBar = true;
};
//function KnifeImage::onFire(%player, %slot) {
//	return;
//}
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

ItemData SOCOMAmmo
{
	description = "M9 Bullet";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SOCOMImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.5;

	ammoType = SOCOMAmmo;
	//projectileType = SAWBullet;
	accuFire = true;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SOCOM
{
   heading = "bWeapons";
	description = "M9 Beretta";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SOCOMImage;
	price = 85;
	showWeaponBar = true;
};

// -------------------------------------------

ItemData OICWAmmo
{
	description = "M16 Bullet";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData OICWImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = OICWAmmo;
	//projectileType = NATOBullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.25;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData OICW
{
	description = "M16 Rifle";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = OICWImage;
	price = 175;
	showWeaponBar = true;
};

// ------------------------------------------

ItemData SAWAmmo
{
	description = "M249 Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SAWImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;

	ammoType = SAWAmmo;
	//projectileType = SAWBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData SAW
{
	description = "M249 SAW";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SAWImage;
	price = 125;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData MP5Ammo
{
	description = "MP5 Bullet";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MP5Image
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MP5Ammo;
	//projectileType = MP5Bullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.1;

	sfxActivate = SoundPickUpWeapon;
};

ItemData MP5
{
	description = "Silenced MP5";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MP5Image;
	price = 175;
	showWeaponBar = true;
};

function MP5Loading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,MP5,$WeaponSlot);	
}

//function MP5Image::onFire(%player, %slot) {
//	%cl = Player::getClient(%player);
//	if ($MP5NotReady[%cl] == 0) {
//		%vel = Item::getVelocity(%player);
//		%trans = GameBase::getMuzzleTransform(%player);
//		if($MP5Mode[%cl] == 1) { // Three-shot Burst
//			%ammoRemaining = Player::getItemCount(%player, MP5Ammo);
//			if(%ammoRemaining > 3)
//				%ammoRemaining = 3;
//			for (%i = 0; %i < %ammoRemaining; %i++) 
///			{
//				schedule("Projectile::spawnProjectile(\"MP5Bullet\", GameBase::getMuzzleTransform("@%player@"), "@%player@", Item::getVelocity("@%player@"));", %i * 0.1);
//				schedule("Player::decItemCount("@%player@", MP5Ammo);", %i * 0.1);
//			}
//			$MP5NotReady[%cl] = 1;
//			schedule("$MP5NotReady["@%cl@"] = 0;", 0.5);
//		} else
//		{
//			Projectile::spawnProjectile("MP5Bullet", %trans, %player, %vel);
//			Player::decItemCount(%player, MP5Ammo);
//		}
//	} else MP5Loading(%player);
//}

// ----------------------------------------

ItemData PSG1Ammo
{
	description = "PSG-1 Bullet";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData PSG1Image
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PSG1Ammo;
	//projectileType = PSG1Bullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PSG1
{
	description = "PSG-1 Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PSG1Image;
	price = 200;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData FiftyCalAmmo
{
	description = "FiftyCal Bullet";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FiftyCalImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FiftyCalAmmo;
	//projectileType = FiftyCalBullet;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.5;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData FiftyCal
{
	description = "M40A1 Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FiftyCalImage;
	price = 250;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData AutoShotgunAmmo
{
	description = "Shotgun Shell";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AutoShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AutoShotgunAmmo;
	//projectileType = AutoShotgunFlechette;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 0.2;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AutoShotgun
{
	description = "SPAS-12 Auto Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoShotgunImage;
	price = 300;
	showWeaponBar = true;
};

//function AutoShotgunImage::onFire(%player, %slot) 
//{
//	%cl = Player::getClient(%player);
//	%trans = GameBase::getMuzzleTransform(%cl);
//	if ($ShotgunMode[%cl] == 0) {   // Flechette Mode
//		for (%i = 0; %i < 8; %i++) {
//			Projectile::spawnProjectile("AutoShotgunFlechette", %trans, %player, Item::getVelocity(%player));
//		}
//	} else {				  // Slug Mode
//		Projectile::spawnProjectile("AutoShotgunSlug", %trans, %player, Item::getVelocity(%player));
//	}
//	Player::decItemCount(%player, AutoShotgunAmmo);
//}

// ----------------------------------------

ItemData LAWAmmo
{
	description = "LAW Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData LAWImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { 0, -0.5, 0.2 };

	weaponType = 0; // Single Shot
	ammoType = LAWAmmo;
	//projectileType = LAWRocket;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData LAW
{
	description = "LAW";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LAWImage;
	price = 200;
	showWeaponBar = true;
};

//function LAWImage::onFire(%player, %slot) 
//{
//	%cl = Player::getClient(%player);
//	%trans = GameBase::getMuzzleTransform(%cl);
//	Projectile::spawnProjectile("LAWRocket", %trans, %player, Item::getVelocity(%player));
//	Player::decItemCount(%player, LAWAmmo);
//	Player::decItemCount(%player, LAW);
//}

// ---------------------------------------------

ItemData FlameAmmo
{
	description = "Flamethrower Ammo";
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
	ammoType = FlameAmmo;
	projectileType = Flame;
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
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamethrowerImage;
	price = 300;
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

// ---------------------------------------------

ItemData StingerAmmo
{
	description = "Stinger Missile";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData StingerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { 0, -0.5, 0.2 };

	weaponType = 0; // Single Shot
	ammoType = StingerAmmo;
	//projectileType = StingerRocket;
	accuFire = true;
	reloadTime = 4.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Stinger
{
	description = "Stinger SAM Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 300;
	showWeaponBar = true;
};


//=====================ORIGINAL DF Stinger Locking Code: Phased out because of new Box format.
//==And.... back in use if they player chooses to...
//===And out again because a more realistic type is used for all lockers. (2/25/05)

function StingerLoading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,Stinger,$WeaponSlot);
}
	 
function StingerImage::onFire(%player, %slot)
{
    %cl = Player::getClient(%player);
   if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::RedLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("Stinger2Missile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);
	%projectile.owner = %player;
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
										
   } else if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::YellowLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("StingerMissile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);	
	%projectile.owner = %player;	
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
   } else
   {
	Client::sendMessage(%cl,1,"A stronger heat signature is required for lock.~waccess_denied.wav");
   }
}

// On what $Locking::LockStatus value we gain the lock type.
$Locking::GreenLock = 5; // Greenlock isn't anything really..
$Locking::YellowLock = 6;
$Locking::RedLock = 20;

$Locking::LockChargeTime = 0.1;
$Locking::TimeSkip = $Locking::LockChargeTime*4 + 0.1; //Seconds; time for each loop.

$Locking::statusNone = 0;
$Locking::statusInc[Default,"Infared"]   = 0;		$Locking::statusInc[Default,"Radar"]   = 2;
$Locking::statusInc[Tomcat,"Infared"]    = 3;		$Locking::statusInc[Tomcat,"Radar"]    = 3;
$Locking::statusInc[Falcon,"Infared"]    = 3;		$Locking::statusInc[Falcon,"Radar"]    = 3;
$Locking::statusInc[Warthog,"Infared"]   = 2;		$Locking::statusInc[Warthog,"Radar"]   = 3;
$Locking::statusInc[Bomber,"Infared"]    = 2;		$Locking::statusInc[Bomber,"Radar"]    = 1; // Course, this will be set to 1 anyway on the ECM check.
$Locking::statusInc[Gunship,"Infared"]   = 1;		$Locking::statusInc[Gunship,"Radar"]   = 3;
$Locking::statusInc[Hercules,"Infared"]  = 1;		$Locking::statusInc[Hercules,"Radar"]  = 3;
$Locking::statusInc[Sentry,"Infared"]    = 2;		$Locking::statusInc[Sentry,"Radar"]    = 3;

$Locking::statusInc[Apache,"Infared"]    = 1;		$Locking::statusInc[Apache,"Radar"]    = 3;
$Locking::statusInc[Kiowa,"Infared"]     = 1;		$Locking::statusInc[Kiowa,"Radar"]     = 3;
$Locking::statusInc[Hind,"Infared"]      = 1;		$Locking::statusInc[Hind,"Radar"]      = 3;
$Locking::statusInc[Blackhawk,"Infared"] = 1;		$Locking::statusInc[Blackhawk,"Radar"] = 3;

$Locking::Type[Stinger]           = "Infared";
$Locking::Type[StingerLauncherGun]   = "Infared";
$Locking::Type[SidewinderRocket]  = "Infared";
$Locking::Type[PhoenixRocket]     = "Radar";

// locking isn't working for AtG, so disable for now.
//$Locking::Type[HARMRocket]        = "Radar";
//$Locking::Type[MavRocket]           = "Radar";

$Locking::WeaponRedLock[Stinger] = Stinger2Missile;
$Locking::WeaponYellowLock[Stinger] = StingerMissile;
$Locking::WeaponGreenLock[Stinger] = "";

$Locking::WeaponRedLock[StingerLauncherGun] = Stinger2Missile;
$Locking::WeaponYellowLock[StingerLauncherGun] = StingerMissile;
$Locking::WeaponGreenLock[StingerLauncherGun] = "";

$Locking::WeaponRedLock[SidewinderRocket] = Sidewinder2Missile;
$Locking::WeaponYellowLock[SidewinderRocket] = SidewinderMissile;
$Locking::WeaponGreenLock[SidewinderRocket] = SidewinderRocket;

$Locking::WeaponRedLock[PhoenixRocket] = Phoenix2Missile;
$Locking::WeaponYellowLock[PhoenixRocket] = PhoenixMissile;
$Locking::WeaponGreenLock[PhoenixRocket] = PhoenixRocket;

$Locking::WeaponRedLock[HARMRocket] = HARM2Missile;
$Locking::WeaponYellowLock[HARMRocket] = HARMMissile;
$Locking::WeaponGreenLock[HARMRocket] = HARMRocket;

$Locking::WeaponRedLock[MavRocket] = Mav2Missile;
$Locking::WeaponYellowLock[MavRocket] = MavMissile;
$Locking::WeaponGreenLock[MavRocket] = MavRocket;


function Locking::CheckToStartLoop(%this,%Weap)
{
	// If we can't lock with the weapon, or we're attempting to kill the loops, don't venture in.
	if(!$Locking::KillLoop[%this] && !$Locking::Type[%weap] && $Locking::Type[%weap] != "" && $Locking::Type[%weap] != -1)
	{
		$Locking::LockStatus[%this] = 0;
		
		// Enable this long enough to clear out any current lockings.
		$Locking::KillLoop[%this,$Locking::Type[%weap]] = true;
		schedule("$Locking::KillLoop["@%this@",$Locking::Type["@%weap@"]] = false;",$Locking::TimeSkip*2,%this);
		schedule("Locking::LockingLoop("@%this@","@%weap@");",$Locking::TimeSkip*2+0.1,%this);
	}
}

function Locking::LockingLoop(%this,%weap)
{
	// Dead check
	if(getObjectType(%this) == "Player" && Player::isDead(%this))
		return;	
	// No ammo check
	%client = Gamebase::GetControlClient(%this);
	if(!($WeaponAmmo[%weap] == ""||Player::getItemCount(%client,$WeaponAmmo[%weap]) > 0|| ($Clip[%weap] != "" && Player::getItemCount(%client,$Clip[%weap]) > 0)))
		return;
	// Make sure the locking weapon is still equipped.
	if(!$Locking::KillLoop[%this,$Locking::Type[%weap]] && Locking::weaponEquipped(%this,%weap))
	{
		
		// Spark 3 times (Three different lengths, and cone-sizes)
		Locking::SparkForTarget(%this,1);
		schedule("Locking::SparkForTarget("@%this@",2);",$Locking::LockChargeTime);
		schedule("Locking::SparkForTarget("@%this@",3);",$Locking::LockChargeTime*2);

		schedule("Locking::findTarget("@%this@","@%weap@");",$Locking::LockChargeTime*3);

		// Need to give time for the LockingCharge beams to find a target.
		schedule("Locking::LockingLoopPost("@%this@","@%weap@");",$Locking::LockChargeTime*4,%this);
	}
}

function Locking::LockingLoopPost(%this,%weap)
{		
	// Dead check
	if(getObjectType(%this) == "Player" && Player::isDead(%this))
		return;	
	// No ammo check
	%client = Gamebase::GetControlClient(%this);
	if(!($WeaponAmmo[%weap] == ""||Player::getItemCount(%client,$WeaponAmmo[%weap]) > 0|| ($Clip[%weap] != "" && Player::getItemCount(%client,$Clip[%weap]) > 0)))
		return;
	// Make sure the locking weapon is still equipped.
	if(!$Locking::KillLoop[%this,$Locking::Type[%weap]] && Locking::weaponEquipped(%this,%weap))
	{
		// Sure, we've got a valid target (From FindTarget)
		if($Locking::TargetFound[%this] > 0)
		{
			// Increase our attempt count.
			$Locking::LockStatus[%this] = $Locking::LockStatus[%this] + $Locking::TargetFound[%this];
			// If we've got a RedLock, then we're ready to fire!
			if($Locking::LockStatus[%this] >= $Locking::RedLock)
			{
				// Some  of message?
				Locking::Message(%this,$Locking::Type[%weap]);
				$Locking::LockStatus[%this] = $Locking::RedLock + $Locking::TargetFound[%this];
			} else if($Locking::LockStatus[%this] >= $Locking::YellowLock)
			{
				// Some sort of message?
				if($Locking::LockStatus[%this]%2 == 0)
					Locking::Message(%this,$Locking::Type[%weap]);
				
			}
			// Reset to no target found for the next time we want to check
			$Locking::TargetFound[%this] = $Locking::statusNone;
		}
		// No valid target
		else
		{
			$Locking::AttackTarget[%this] = "";
			$Locking::LockStatus[%this]--;
			if($Locking::LockStatus[%this] < 0)
				$Locking::LockStatus[%this] = 0;
		}
		schedule("Locking::LockingLoop("@%this@","@%weap@");",$Locking::TimeSkip-$Locking::LockChargeTime*4,%this);
	}
}

function Locking::weaponEquipped(%this,%weap)
{	
	// If we don't have a pilot weapon, then we're either a player object, or a vehicle that can't lock...
	if(Vehicle::hasPilotWeapon(%this))
	{
		// And as a result, our equipped weapon is found elsewhere.
		if(gamebase::getcontrolclient(%this).hflink != 2)
		{
			// Same weapon?
			if(%weap == $VehicleOwnedWeapon[%this,$VehicleCurWeapon[%this]])
				return true;
		} else
		{
			// Selected fire-linking; We've got to look through all selected hardpoint weapons.

			if(Vehicle::getDataName(%this) == Apache)
				%hp = $VehicleMaxHardPoints[Vehicle::getDataName(%this)]+2;
			else
				%hp = $VehicleMaxHardPoints[Vehicle::getDataName(%this)];
			// If any are a locker, then return true
			for(%cur=0;%cur <%hp;%cur++)
			{
				if($HPToFire[%this,%cur] && $VehicleHPList[%this,%cur] == %weap)
					return true;
			}
		}
	} else 
	// If we're a player, we're holding our weapon.
	if(getObjectType(%this) == "Player")
	{
		if(%weap == Player::getMountedItem(%this,$WeaponSlot))
			return true;
	}
	return false;
}

function Locking::findTarget(%this,%weap)
{
	%target = $Locking::SparkTarget[%this];
	if(Gamebase::GetDataName(%target).classname == "ARMOR")
	{

		%target = %target.vehicle;
	}

	$Locking::SparkTarget[%this] = "";
	if(%target && %target != "" && %target != -1)
	{
		// Check if it's a valid target
		if(Locking::ValidTarget(%target,%weap))
		{
			
			// If it isn't the same target we had, we need to reset our counter.
			if($Locking::CurTarget[%this] != %target)
			{
				// If we're a tomcat, we've got a sweet tracking system.
				if(Vehicle::isTomcat(%this))
				{
					// Save our cur target.
					$Locking::TomcatTracking[%this,$Locking::CurTarget[%this]] = $Locking::LockStatus[%this];
					$Locking::TomcatTrackTime[%this,$Locking::CurTarget[%this]] = getSimTime(); 
	
					// Already tracking this target? Pull it out.
					if($Locking::TomcatTracking[%this,%target] > 0 && $Locking::TomcatTrackTime[%this,%target] > 0)
					{
						// Divide any time that passed by our Timeskip, and subtract it from the last lock status.
							// This is to reflect the target degredation that we have in Locking::LockingLoop
						$Locking::LockStatus[%this] = $Locking::TomcatTracking[%this,%target] - 
							floor((getSimTime() - $Locking::TomcatTracktime[%this,%target])/$Locking::TimeSkip);
					
						// Just in case.
						if($Locking::LockStatus[%this] < 0)
							$Locking::LockStatus[%this] = 0;
					
						// Update the values.	
						$Locking::TomcatTracking[%this,%target] = $Locking::LockStatus[%this];
						$Locking::TomcatTractTime[%this,%target] = getSimTime();
					}
				} else
					$Locking::LockStatus[%this] = $Locking::statusNone;
			}
			// Cur target is for always remembering which our last target was.
			$Locking::CurTarget[%this] = %target;
			// Attack target is to tell us if we actually have a target ready for attacking.
			$Locking::AttackTarget[%this] = %target;
			
			// Basically, we could run into an instance where we lose our target for a second. We don't want to kill
			// the Cur target, because if we regain it, we want the lock still to be fairly strong (depending on how
			// long we lost it for). But during the interum, we don't want to be able to "fire" at the target that's
			// locked, because.. it isn't there.


			// If we're an aircaft (or a countermeasure), find out our inc amount for the weapontype
			if(Vehicle::isAircraft(%target))
				$Locking::TargetFound[%this] = $Locking::statusInc[Vehicle::GetDataName(%target),$Locking::Type[%weap]];
			// Otherwise, use the default.
			else
				$Locking::TargetFound[%this] = $Locking::statusInc[Default,$Locking::Type[%weap]];
			
			// Check to see if they're using an ECM, or in an ECM zone.
			if(player::getsensorsupression(%this) > 0 && $locking::Type[%weap] == "Radar")
				$Locking::TargetFound[%this] = 1;
	
		}
		// If we arn't a valid target, then just consider us not having a target.
		else
			$Locking:TargetFound[%this] = $Locking::statusNone;		
	}
	else
		$Locking:TargetFound[%this] = $Locking::statusNone;		
}


function Locking::ValidTarget(%target,%weap)
{
	%type = $Locking::Type[%weap];

	// HARMs will only lock onto radar sources (Sensors and SAMs)
	if( %Weap == HARMRocket && (
		GameBase::getDataName(%target).className == Sensor ||  GameBase::getDataName(%target).className == DeployableSensor
		|| Gamebase::GetDataName(%target) == DeployableSAM || Gamebase::GetDataName(%target) == RocketTurret))
		return true;
	else if(%weap == HARMRocket)
		return false;
	
	// Mavarick missiles will only lock onto staticshapes/Tanks/Sensors/Turrets
	if(%weap == MavRocket && (
		Gamebase::GetDataName(%target).className == Staticshape || Vehicle::isTank(%target) || 
		GameBase::getDataName(%target).className == Sensor ||  GameBase::getDataName(%target).className == DeployableSensor
		|| Gamebase::GetDataName(%target) == DeployableSAM || Gamebase::GetDataName(%target) == RocketTurret))
		return true;
	else if(%weap == MavRocket)
		return false;

	// All aircraft are always valid.
	if(Vehicle::isAircraft(%target))
		return true;

	// Tanks and staticshapes are only valid if it's Radar lock
	if(%type == "Radar" && (Vehicle::isTank(%target) || getObjectType(%target).className == StaticShape))
		return true;

	// Flare is only valid if it's an infered lock
	if(%type == "Infared" && getObjectType(%target) == Flare)
		return true;
	
	// Chaff is only valid if it's a Radar lock
	if(%type == "Radar" && getObjectType(%target) == Chaff)
		return true;
	
	return false;
}

function Locking::Message(%this,%type)
{
	%cl = gamebase::getcontrolclient(%this);
	%target = gamebase::Getcontrolclient($Locking::AttackTarget[%this]);
	if($Locking::LockStatus[%this] < $Locking::RedLock)
	{
		if($Locking::LockStatus[%this] >= $Locking::YellowLock && 
			$Locking::LockStatus[%this] < ($Locking::YellowLock + $Locking::TargetFound[%this]))
		{
			Client::sendMessage(%cl,0,"** Aquiring "@%type@" Lock **");
			Client::sendMessage(%target,1,"* Warning * The enemy is attempting to aquire a lock on you!");
		}
		bottomprint(%cl, "<f4><jc>** Aquiring "@%type@" Lock **", 1.05);
		bottomprint(%target, "<f4><jc>* Warning * The enemy is attempting to aquire a lock on you!", 1.05);
		Client::sendMessage(%cl,0,"~wmine_act.wav");
		Client::sendMessage(%target,0,"~waccess_denied.wav");
		
	} else if($Locking::LockStatus[%this] >= $Locking::RedLock)
	{
		if($Locking::LockStatus[%this] >= $Locking::RedLock && 
			$Locking::LockStatus[%this] < ($Locking::RedLock + $Locking::TargetFound[%this]))
		{
			Client::sendMessage(%cl,1,"*** "@%type@" Lock Aquired ***");
			Client::sendMessage(%target,1,"*** WARNING! *** The enemy has a lock on you!");
		}
		bottomprint(%cl, "<f4><jc>*** "@%type@" Lock Aquired ***", 0.55);
		bottomprint(%target, "<f5><jc>*** WARNING! *** The enemy has a lock on you!", 0.55);
		Client::sendMessage(%cl,0,"~wmine_act.wav");
		Client::sendMessage(%target,0,"~waccess_denied.wav");
	}
}

function spark(%cl)
{
	%targ = Locking::SparkForTarget(client::Getcontrolobject(%cl));
	echo("*"@%targ@"*");
}

function Locking::SparkForTarget(%this,%num)
{
	if($Locking::SparkTarget[%this] == "")
	{
		%trans = GameBase::getMuzzleTransform(%this);
		if(%num == 1)
			%projectile = Projectile::spawnProjectile("LockingCharge", %trans, %this, "0 0 0");
		else if(%num == 2)
			%projectile = Projectile::spawnProjectile("Locking2Charge", %trans, %this, "0 0 0");
		else if(%num == 3)
			%projectile = Projectile::spawnProjectile("Locking3Charge", %trans, %this, "0 0 0");
		schedule ("deleteobject(" @ %projectile @ ");",$Locking::LockChargeTime);
	}
}



// ---------------------------------------------

ItemData HowitzerAmmo
{
	description = "Howitzer Shells";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData HowitzerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HowitzerAmmo;
	projectileType = HowitzerShell;
	accuFire = false;
	reloadTime = 1.0;
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

ItemData Howitzer
{
	description = "Howitzer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HowitzerImage;
	price = 375;
	showWeaponBar = true;
};

// -------------------------------------

ItemData AbramsAmmo
{
	description = "105mm Shells";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AbramsGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.5, 0, -0.05 };

	weaponType = 0; // Single Shot
	ammoType = AbramsAmmo;
	reloadTime = 1.5;
	fireTime = 0.5;

	projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AbramsGun
{
	description = "Abrams Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AbramsGunImage;
	price = 999;
	showWeaponBar = true;
};

function AbramsGunImage::onFire(%player, %slot) {
	
	AAI::onFire(%player);

	%trans = Veteran::GetTransform(%player);
	Projectile::spawnProjectile(AbramsShell, %trans, %player, Item::getVelocity(%player));
	Player::decItemCount(%player, AbramsAmmo);
}

// -------------------------------------

ItemData LowMountAbramsAmmo
{
	description = "105mm Shells";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData LowMountAbramsGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
  	mountOffset = { -0.5, 1, -1.75 };

	weaponType = 0; // Single Shot
	ammoType = LowMountAbramsAmmo;
	reloadTime = 1.5;
	fireTime = 0.5;

	projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData LowMountAbramsGun
{
	description = "Abrams Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LowMountAbramsGunImage;
	price = 999;
	showWeaponBar = true;
};

function LowMountAbramsGunImage::onFire(%player, %slot) {
	
	AAI::onFire(%player);

	%trans = Veteran::GetTransform(%player);
	Projectile::spawnProjectile(AbramsShell, %trans, %player, Item::getVelocity(%player));
	Player::decItemCount(%player, LowMountAbramsAmmo);
}
// ----------------------------------

function sendGameTeamMessage(%teamNum, %msg) {
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) {
		%tNum = Client::getTeam(%clientId);
		if (%tNum == %teamNum) Client::sendMessage(%clientId, 1, %msg);
	}
}

ItemImageData AirstrikeImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 1; // Single (Sustained)
	// projectileType = FakeStuff;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;
	reloadTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Airstrike
{
	description   = "Airstrike";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = AirstrikeImage;
	price         = 999;
	showWeaponBar = false;
};
// HACK!
$AirTime[0] = 0.1;
$AirTime[1] = 0.2;
$AirTime[2] = 0.3;
$AirTime[3] = 0.4;
$AirTime[4] = 0.5;

exec(airstrike);

function AirstrikeImage::onFire(%player, %slot) {
	
	//%tform = Gamebase::getMuzzleTransform(%player);
	%clientId = Gamebase::getOwnerClient(%player);
	
	$tempCount[%player]++;

	// If the player is activating the airstrike for the first time, start the count
	if($airstrikeIn[%player] == 0) {
		$airstrikeIn[%player] = 16;
		Client::sendMessage(%clientId, 1, "Airstrike called in - designate target for 15 seconds");
		$AirstrikePos[%player] = GameBase::getPosition(%player);
		if(Client::getTeam(%clientId) == 0) {
			%numOtherTeam = 1;
		} else %numOtherTeam = 0;
		sendGameTeamMessage(%numOtherTeam, "Beware - the enemy is calling in an airstrike.~wsniper.wav");
		schedule("decAirstrike(" @ %player @ "," @ %clientId @ ");", 1);
	}

	// If the count has run out, "call in" the airstrike and remove the pack 
	if($airstrikeIn[%player] == 1) {
		//Projectile::spawnProjectile("AirstrikeShot", %transform, %player, Item::getVelocity(%player));
		GameBase::getLOSInfo(%player, 5000);
		%pos = $los::position;
		%player.ASPos = %pos;
		%tx = getWord($los::position, 0);
		%ty = getWord($los::position, 1);
		%tz = getWord($los::position, 2);
		%tz += 200;
		//echo("Transform: " @ %transform);

		Airstrike::Fire(%clientId,%pos,%player);

		$airstrikeIn[%player]--;
		Player::setItemCount(%clientId,Airstrike,0);
		Player::DecItemCount(%clientId,AirstrikePack);
		Client::sendMessage(%clientId, 1, "Airstrike successful.");
		$successAS[%player] = 1;
		$tempCount[%player] = 0;
		%quitFlag[%player] = 1;
		return;
	}
}

function testAS(%clientId, %pos)
{
	if($done)
	return;
	%player  = client::getOwnedObject(%clientId);
	
	%pos = (getWord(%pos,0)+5*(getRandom()-getRandom())) @ " " @
		(getWord(%pos,1)+5*(getRandom()-getRandom())) @ " " @
		(getWord(%pos,2)+5*(getRandom()-getRandom()));
	
	Airstrike::Fire(%clientId,%pos,%player);

	schedule("testAS("@%clientId@",\""@%pos@"\");",2);
}

function Airstrike::Fire(%clientId,%pos,%player)
{
	// Blue angels, Away!!		
//	for(%x=0;%x<4;%x++)
//		AirStrike::spawnvehicle(FalconMoveVehicle,%pos,%player,0,%x+2);	
	

	// High Explosive
	if($ASMode[%clientId] == 0)
	{
		// 60% Warthog
		// 30% Falcon
		// 10% Bombers
		%rand = floor(getRandom()*10);

		$AirStrike::Client[%player] = %clientId;
		if(%rand > 3)
		{
			Client::sendMessage(%clientId, $MsgTypeTeamChat, "A-10 Pilot: I am enroute to your target, and beginning my attack run.");
			Client::sendMessage(%clientId,0,"~wmale1.wtgtacq.wav");
			schedule("Client::sendMessage("@%clientId@", "@$MsgTypeTeamChat@", \"A-10 Pilot: Contact in T-"@$AirStrike::TMinusTime[Warthog,1]@" seconds.\");",1.2);
			AirStrike::spawnvehicle(MoveWarthogVehicle,%pos,%player,BigBomb,1);	
		}
		else if(%rand > 0)
		{
				
			Client::sendMessage(%clientId, $MsgTypeTeamChat, "F-16 Pilot: I am enroute to your target, and beginning my attack runs.");
			Client::sendMessage(%clientId,0,"~wfemale4.wtgtacq.wav");
			schedule("Client::sendMessage("@%clientId@", "@$MsgTypeTeamChat@", \"F-16 Pilot: Contact in T-"@$AirStrike::TMinusTime[Falcon,1]@" seconds.\");",1.2);
			AirStrike::spawnvehicle(FalconMoveVehicle,%pos,%player,MavRocket,1);	
		}
		else
		{
			%flightNum = 50+floor(getRandom()*100);
			Client::sendMessage(%clientId, $MsgTypeTeamChat, "Bomber Flight Commander: B-52 Flight "@%flightNum@" enroute to your target.");
			Client::sendMessage(%clientId,0,"~wfemale1.wtgtacq.wav");
			schedule("Client::sendMessage("@%clientId@", "@$MsgTypeTeamChat@", \"Bomber Flight Commander: Warn your squad to clear the target area imediately.\");",1.2);
			schedule("Client::sendMessage("@%clientId@", "@$MsgTypeTeamChat@", \"Bomber Flight Commander: Contact in T-"@$AirStrike::TMinusTime[Bomber,1]@" seconds.\");",1.8);
			
			%defaultBomberPos = %pos;
			%dist = 20;
			%num = 6;
			for(%BNum=0; %BNum < 4; %BNum++)
			{
				%pos = vector::add(%DefaultBomberPos,(pow(-1,(%BNum))*floor(((%BNum)/2)+0.5)*%Dist)@" "@(-1*floor(((%BNum)/2)+0.5)*%Dist)@" 0");
				AirStrike::spawnvehicle(BomberMoveVehicle,%pos,%player,BigBomb,1);	
			}
		}
	}
	// Napalm
	else if($ASMode[%clientId] == 1)
	{
		Client::sendMessage(%clientId, $MsgTypeTeamChat, "A-10 Pilot: I am enroute to your target, and beginning my attack run.");
		Client::sendMessage(%clientId,0,"~wmale1.wtgtacq.wav");
		schedule("Client::sendMessage("@%clientId@", "@$MsgTypeTeamChat@", \"A-10 Pilot: Contact in T-"@$AirStrike::TMinusTime[Warthog,1]@" seconds.\");",1.2);
		AirStrike::spawnvehicle(MoveWarthogVehicle,%pos,%player,ASNapalmBomb,2);	
	}	
}

function decAirstrike(%player, %clientId) {
	if ($quitFlag[%player] == 1) {
		$quitFlag[%player] = 0;
		$countRef[%player] = 0;
		$tempCount[$player] = 0;
		$airstrikeIn[%player] = 0;
		return;
	}
	%diff = $tempCount[%player] - $countRef[%player];
	if (%diff < 3 || GameBase::getPosition(%player) != $AirstrikePos[%player]) {
		if ($successAS[%player] == 1) {
			$successAS[%player] = 0;
			return;
		}
		client::sendMessage(%clientId, 1, "Airstrike cancelled.");
		if(Client::getTeam(%clientId) == 0) {
			%numOtherTeam = 1;
		} else %numOtherTeam = 0;
		sendGameTeamMessage(%numOtherTeam, "The enemy has cancelled their airstrike.");
		$airstrikeIn[%player] = 0;
		$tempCount[%player] = 0;
		$countRef[%player] = 0;
		return;
	}	
	$countRef[%player] = $tempCount[%player];	
	$airstrikeIn[%player]--;
	schedule("decAirstrike(" @ %player @ ", " @ %clientId @ ");", 1);
}
			
// -----------------------------------------------

ItemData TOWAmmo
{
	description = "TOW Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData TOWImage
{
	shapeFile = "magcargo";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = TOWAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.15;
	minEnergy = 5;
	maxEnergy = 5;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TOW
{
	description = "TOW Launcher";
	className = "Weapon";
	shapeFile = "magcargo";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TOWImage;
	price = 999;
	showWeaponBar = true;
};

function TOWImage::onFire(%player, %slot)
{
	%cl = Player::getClient(%player);
	if ($FiringTOW[%cl] == 0) {
		//GameBase::playSound(%player,SoundJetHeavy);
		%rot = GameBase::getRotation(%player);
		%pos = GameBase::getPosition(%player);
		%vec = Vector::getFromRot(%rot, 8);
		%pos = ""@getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%pos,2)+5@"";
		%newvec = ""@getWord(%vec, 0)+getWord(%pos, 0)@" "@getWord(%vec, 1)+getWord(%pos, 1)@" "@getWord(%vec, 2)+getWord(%pos, 2)@"";
		%tow = newObject("","Flier","TOWMissile", true);
		addToSet("MissionCleanup", %tow);
		GameBase::setTeam(%tow, GameBase::getTeam(%cl));
		GameBase::setPosition(%tow, %newvec);
		GameBase::setRotation(%tow, %rot);
		schedule("Client::setControlObject("@%cl@","@%tow@");", 0.25, %tow);
		Player::decItemCount(%player, TOWAmmo);
		$FiringTOW[%cl] = 1;
		schedule("$FiringTOW["@%cl@"] = 0;", 1);
	}
}

// -----------------------------------------------

ItemData StingerLauncherAmmo
{
	description = "Stinger Missiles";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData StingerLauncherGunImage
{
	shapeFile = "magcargo";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = StingerLauncherAmmo;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.15;
	
	//projectileType = StingerRocket;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData StingerLauncherGun
{
	description = "Fixed Stinger Launcher";
	className = "Weapon";
	shapeFile = "magcargo";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = StingerLauncherGunImage;
	price = 999;
	showWeaponBar = true;
};

//=====================ORIGINAL DF Stinger Locking Code: Phased out because of new Box format.

function StingerLauncherGunLoading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,StingerLauncherGun,$WeaponSlot);
}

function StingerLauncherGunImage::onFire(%player, %slot)
{
    %cl = Player::getClient(%player);
   if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::RedLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("Stinger2Missile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);
	%projectile.owner = %player;
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
   } else if($Locking::AttackTarget[%player] != "" && $Locking::LockStatus[%player] >= $Locking::YellowLock)
   {
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("StingerMissile", %trans, %player, Item::getVelocity(%player), $Locking::AttackTarget[%player]);
	Player::decItemCount(%player, StingerAmmo);
	warningMessage(GameBase::getControlClient($Locking::AttackTarget[%player]), %projectile);		
	%projectile.owner = %player;
	%projectile.target = $Locking::AttackTarget[%player];
	Vehicle::AddSeekingMissile($Locking::AttackTarget[%player],%projectile);
   } else
   {
	Client::sendMessage(%cl,1,"A stronger heat signature is required for lock.~waccess_denied.wav");
   }
}
// -----------------------------------------------

ItemData MLRSAmmo
{
	description = "MLRS Rockets";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MLRSLauncherImage
{
	shapeFile = "magcargo";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MLRSAmmo;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.35;
	
	projectileType = MLRSRocket;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MLRSLauncher
{
	description = "MLRS Launcher";
	className = "Weapon";
	shapeFile = "magcargo";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MLRSLauncherImage;
	price = 999;
	showWeaponBar = true;
};

function MLRSLauncherImage::onFire(%player, %slot) 
{
	%trans = GameBase::getMuzzleTransform(%player);
	%projectile = Projectile::spawnProjectile("MLRSRocket", %trans, %player, Item::getVelocity(%player));
	%projectile.owner = %player;
	Player::decItemCount(%player, MLRSAmmo);
}		



//=====================ORIGINAL Locking Code: Phased out because of new Box format.

//function MLRSLauncherImage::onFire(%player, %slot) 
//{
//	%cl = Player::getClient(%player);
//	%trans = GameBase::getMuzzleTransform(%cl);
//	GameBase::getLOSInfo(%this, 1000);
//	if (!(GameBase::getDataName($los::object) == Falcon || GameBase::getDataName($los::object) == DiveBomber || GameBase::getDataName($los::object) == Tomcat || GameBase::getDataName($los::object) == Apache || GameBase::getDataName($los::object) == Blackhawk || GameBase::getDataName($los::object) == Warthog || GameBase::getDataName($los::object) == MoveWarthog || GameBase::getDataName($los::object) == Hind || GameBase::getDataName($los::object) == Bomber || GameBase::getDataName($los::object) == Hercules || GameBase::getDataName($los::object) == Gunship)){
//	//if ($MLRSLauncherMode[%cl] == 0) {   // Normal Rocket Mode Not working so take it out for now.
//		Projectile::spawnProjectile("MLRSRocket", %trans, %player, Item::getVelocity(%player));
//		Player::decItemCount(%player, MLRSAmmo);
//	} else {				  // Locking AA Mode. If not targeted on a airborn vehicle.
//		MLRSLauncherAAFire(%player, %slot);
//	}
//	
//}

//function MLRSLauncherLoading(%player)
//{
//	Player::unmountItem(%player,$WeaponSlot);
//	Player::mountItem(%player,MLRSLauncher,$WeaponSlot);
//}

//function MLRSLauncherAAFire(%player, %slot)
//{
//	GameBase::getLOSInfo(%player, 1000);
//	if (GameBase::getDataName($los::object) == Apache || GameBase::getDataName($los::object) == Falcon || GameBase::getDataName($los::object) == DiveBomber || GameBase::getDataName($los::object) == Tomcat || GameBase::getDataName($los::object) == Blackhawk || GameBase::getDataName($los::object) == Warthog || GameBase::getDataName($los::object) == MoveWarthog || GameBase::getDataName($los::object) == Bomber || GameBase::getDataName($los::object) == Hercules || GameBase::getDataName($los::object) == Hind || GameBase::getDataName($los::object) == Gunship) {
//		remoteEval(Player::getClient(%player), BP, "<f0><jc>Target Lock Achieved", 3);
//		%trans = GameBase::getMuzzleTransform(%player);
//		Projectile::spawnProjectile("MLRSMissile", %trans, %player, Item::getVelocity(%player), $los::object);
//		Player::decItemCount(%player, MLRSAmmo);
//		Client::sendMessage(GameBase::getControlClient($los::object),0,"** WARNING ** -Enemy Missile Lock detected!~waccess_denied.wav");
//		schedule("Client::sendMessage(" @ GameBase::getControlClient($los::object) @ ",0,\"~waccess_denied.wav\");",0.5);
//		schedule("Client::sendMessage(" @ GameBase::getControlClient($los::object) @ ",0,\"~waccess_denied.wav\");",1.0);
//		schedule("Client::sendMessage(" @ GameBase::getControlClient($los::object) @ ",0,\"~waccess_denied.wav\");",1.5);	
//		//bottomprintall(GameBase::getControlClient($los::object),5);
//	} else {
//		remoteEval(Player::getClient(%player), BP, "<f0><jc>Invalid Target", 2);
//		Client::sendMessage(Player::getClient(%player), 0, "~wError_Message.wav");
//		MLRSLauncherLoading(%player);
//	}
//}
// -----------------------------------------------

ItemData AutoGrenAmmo
{
	description = "Grenades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AutoGrenLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AutoGrenAmmo;
	projectileType = AutoGrenShell;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AutoGrenLauncher
{
	description = "MK-19-3 Auto Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoGrenLauncherImage;
	price = 999;
	showWeaponBar = true;
};

// -----------------------------------------------

ItemData MinigunAmmo
{
	description = "Minigun Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MinigunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	ammoType = MinigunAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;

	//projectileType = NATOBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Minigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 999;
	showWeaponBar = true;
};

function MinigunImage::onFire(%player, %slot) {
	
	AAI::onFire(%player);

	%trans = Veteran::GetTransform(%player);
	Projectile::spawnProjectile(NATOBullet, %trans, %player, Item::getVelocity(%player));
	Player::decItemCount(%player, MinigunAmmo);
}


// -----------------------------------------------

ItemData LowMountMinigunAmmo
{
	description = "Minigun Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData LowMountMinigunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
  	mountOffset = { -0.5, 0.75, -1.75 };

	weaponType = 1; // Spinning
	ammoType = LowMountMinigunAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;

	//projectileType = NATOBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData LowMountMinigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LowMountMinigunImage;
	price = 999;
	showWeaponBar = true;
};

function LowMountMinigunImage::onFire(%player, %slot) {
	
	AAI::onFire(%player);

	%trans = Veteran::GetTransform(%player);
	Projectile::spawnProjectile(NATOBullet, %trans, %player, Item::getVelocity(%player));
	Player::decItemCount(%player, LowMountMinigunAmmo);
}
// -----------------------------------------------

ItemData TwentyFivemmAmmo
{
	description = "25mm Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData TwentyFivemmgunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	ammoType = TwentyFivemmAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.03;

	projectileType = TwentyFivemmBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TwentyFivemmgun
{
	description = "25mm Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TwentyFivemmgunImage;
	price = 999;
	showWeaponBar = true;
};

// -----------------------------------------------

ItemData LowMountTwentyFivemmAmmo
{
	description = "25mm Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData LowMountTwentyFivemmgunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
  	mountOffset = { -0.5, 1, -1.75 };

	weaponType = 1; // Spinning
	ammoType = LowMountTwentyFivemmAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.03;

	projectileType = TwentyFivemmBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData LowMountTwentyFivemmgun
{
	description = "25mm Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LowMountTwentyFivemmgunImage;
	price = 999;
	showWeaponBar = true;
};

// -----------------------------------------------

ItemData FortymmAmmo
{
	description = "40mm Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FortymmgunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
  	mountOffset = { -0.5, 1, -1.75 };

	weaponType = 0; // Spinning
	ammoType = FortymmAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.6;

	//projectileType = FortymmBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Fortymmgun
{
	description = "40mm Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FortymmgunImage;
	price = 999;
	showWeaponBar = true;
};

function FortymmgunImage::onFire(%player, %slot) 
{
	
//	AAI::onFire(%player);

	%def = 0.0075;

	%trans = Veteran::GetTransform(%player);
echo(%trans);

        %vectorOrig = getword(%trans,3) @ " " @ getword(%trans,4) @ " " @ getword(%trans,5);//%obj.getMuzzleVector(%slot);
//	%vector = getword(%vectorOrig,0)*%x @ " " @getword(%vectorOrig,1)*%y @ " " @getword(%vectorOrig,2)*%z;

	%x = (getRandom() - getRandom()) * 2 * 3.1415926 * %def;
	%y = (getRandom() - getRandom()) * 2 * 3.1415926 * %def;
	%z = (getRandom() - getRandom()) * 2 * 3.1415926 * %def;

	%vector = vector::add(%x @ " " @ %y @ " " @ %z, %vectororig);

	%trans = getword(%trans,0) @ " " @ getword(%trans,1) @ " " @ getword(%trans,2) @ " " @
			%vector @ " " @
			getword(%trans,6) @ " " @ getword(%trans,7) @ " " @ getword(%trans,8) @ " " @
			getword(%trans,9) @ " " @ getword(%trans,10) @ " " @ getword(%trans,11);
echo(%trans);

	Projectile::spawnProjectile(FortymmBullet, %trans, %player, Item::getVelocity(%player));
	Player::decItemCount(%player, FortymmAmmo);
}
// -----------------------------------------

ItemImageData ReloaderImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 0.1;
   maxEnergy = 0.2;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Reloader
{
   description = "Reloader";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = ReloaderImage;
	showWeaponBar = true;
   price = 300;
};

ItemImageData ReloaderPackImage
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

ItemData ReloaderPack
{
	description = "Reloader";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ReloaderPackImage;
	price = 400;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ReloaderPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Reloader) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function ReloaderPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,Reloader,$WeaponSlot);
	}
}

function ReloaderPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Reloader) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Reloader
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

// -------------------------------------------------

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
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FuelPackImage;
	price = 150;
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
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamethrower) 
		Player::unmountItem(%player,$WeaponSlot);
}

// -------------------------------------------------

ItemImageData ParachuteImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        maxEnergy = 0;  // Energy used/sec for sustained weapons
        minEnergy = 0;
        sfxFire = SoundJammerOn;
        mountOffset = { 0, -0.03, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData Parachute
{
        description = "Parachute";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = ParachuteImage;
        price = 100;
        hudIcon = "sensorjamerpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function startPara(%player)
{
	if(floor(getrandom()*100) <= 10)
	{
		bottomprint(Player::getClient(%player), "<f1><jc>Parachute failed to deploy!! Deploying Secondary parachute...", 4);
		schedule("subPara("@%player@");",2);
	} else {
		doParaOne(%player);
	}
}

function subPara(%player)
{
	if(floor(getRandom()*100) <= 10)
	{
		bottomprint(Player::getClient(%player), "<f2><jc>Secondary parachute failed to deploy!! Start panicing...", 4);
		AAI::AddToStats(Player::getClient(%player), "failedpara");
	} else {
		doParaOne(%player);
	}
}

function doParaOne(%player)
{
	AAI::AddToStats(Player::getClient(%player), "parachute");
	%velocity = Item::getVelocity(%player);
	%vel1 = -getword(%velocity, 0)*5.10;
	%vel2 = -getword(%velocity, 1)*5.10;
	%vel3 = -getword(%velocity, 2)*5.10;
        Player::applyImpulse(%player, %vel1 @ " " @ %vel2 @ " " @ %vel3);
	schedule("bottomprint(Player::getClient("@%player@"), \"<f0><jc>Parachute deployed.\", 4);",1);

	doPara(%player);
}

function doPara(%player) 
{

	//echo("doPara() called");
      %velocity = Item::getVelocity(%player);
      %vel3 = -getword(%velocity, 2)*5.1;
	
	// Get direction to aim.
	%trans = GameBase::getMuzzleTransform(%player);
	
	%vel1 = getWord(%velocity,0);
	%vel2 = getWord(%velocity,1);

	%amt = 10;

	if(%vel1 > %amt)
		%vel1 = %amt;
	else if(%vel1 < -1*%amt)
		%vel1 = -1*%amt;
	if(%vel2 > %amt)
		%vel2 = %amt;
	else if(%vel2 < -1*%amt)
		%vel2 = -1*%amt;

	%aim = (getword(%trans,3)*%amt - %vel1) @ " " @ (getword(%trans,4)*%amt - %vel2);
	
	

      Player::applyImpulse(%player, %aim @ " " @ %vel3 );
      if ($ParaActivated[%player] == 1) {
	  	if (Player::getLastContactCount(%player) > 5) {
                	schedule("doPara("@%player@");", 0.5);
		//} else ParachuteImage::onDeactivate(%player, $BackpackSlot);
		} else hitGround(%player);
	  }
}

function ParachuteImage::onActivate(%player,%imageSlot)
{
	if($ParaActivated[%player] == 0) {
		%contact = Player::getLastContactCount(%player);
		if(%contact > 11 )
		{
			$ParaActivated[%player] = 1;
			bottomprint(Player::getClient(%player), "<f0><jc>Deploying Parachute...", 4);
			schedule("StartPara("@%player@");",1);
		}
		else
		{
			Player::trigger(%player, $BackpackSlot, false);
			bottomprint(Player::getClient(%player), "<f0><jc>You must be falling to deploy the Parachute", 4);
		}
	}
}

function ParachuteImage::onDeactivate(%player,%imageSlot)
{}

function hitGround(%player) {
	$ParaActivated[%player] = 0;
    //remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Discarded", 4);
    bottomprint(Player::getClient(%player), "<f0><jc>Parachute Discarded", 4);
    Player::trigger(%player,$BackpackSlot,false);
	Player::decItemCount(%player, Parachute);
}



// ------------------------------------------------------------------

ItemImageData GrappleHookImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.7;
	fireTime = 0.7;
        minEnergy = -1.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundThrowItem;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrappleHook
{
	description = "Grapple Hook";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrappleHookImage;
	price = 150;
	showWeaponBar = true;
   validateShape = false;
};

function GrappleHookImage::onFire(%player, %slot)
{
	if(%player.nograpshot)
	{
		Client::sendMessage(player::getclient(%player),0, "Recalling hook...");
		%player.nograpshot=0;
		schedule("mounthook("@%player@");", 0.6, %player);
		deleteobject(%player.HookGroup);
		return;
	}
	Player::unmountItem(%player, 5);
	if(%player.isgrappling)
	{
	EndGrapple(%player);
	}else{
	%player.nograpshot=1;
	%byename="HookGroup"@%player;
	%bye=newObject(%byename, SimGroup);
	addToSet("MissionCleanup", %bye);
	%player.HookGroup=%bye;
	%projtype="Hook"@%player.hooktype;
	if(%player.hooktype=="")
	%projtype="HookSmall";
	%proj=Projectile::spawnProjectile(%projtype, gamebase::getmuzzletransform(%player), %player, item::getvelocity(%player), %player);
	$HookPl[%proj]=%player;
	%player.proj=%proj;
	addToSet(%player.HookGroup, %proj);
	Hook::Track(%proj);
	}
}

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
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = GrapplePackImage;
	price = 600;
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
	} else {
		if (%player.vehicle)
			{
			Vehicle::passengerJump(%player.vehicle,%player,"Grapple");
			return;
			}
		if (Player::getMountedItem(%player,$WeaponSlot) != "GrappleHook")
			{
				Player::mountItem(%player,GrappleHook,$WeaponSlot);
			} else {
	   			if(%player.hooktype=="Small")
					%player.hooktype="Medium";
	   			else if(%player.hooktype=="Medium")
					%player.hooktype="Large";
	   			else if(%player.hooktype=="Large")
					%player.hooktype="Small";
	   			else %player.hooktype="Medium";
	  		 Client::sendMessage(player::getclient(%player),0, "Rope length set to: "@%player.hooktype);  
			}
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


// ------------------------------------------------------------

// END DELTA FORCE WEAPONS

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

	weaponType = 1; // Sustained
//	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;
	reloadTime = 0.0;

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

ItemData TargetItem 
{ 
     description = ""; 
     shapeFile = "breath"; 
     showInventory = false; 
     shadowDetailMask = 4; 
 
     lightType = 0;   // Pulsing 
}; 

function TargetingLaserImage::onFire(%player, %slot)
{
	if($Player::TargetingLaserOn[%player] == "")
	{
		if(GameBase::getLOSInfo(%player, 10000)) 
		{ 	
			$Player::TargetingLaserOn[%player] = getSimTime();
			%pos = $LOS::Position;
			%marker = newObject("",Item,TargetItem,1,true, true, false);
			$Player::TargetingLaser[%player] = %marker;
			GameBase::setIsTarget(%marker,true);
			gamebase::setteam(%marker, gamebase::GetTeam(%player)); 
			gamebase::setposition(%marker, %pos); 
			schedule("TargetingLaserImage::remove("@%player@","@%slot@");",0.2);
		} else
		{
			Player::trigger(%player,%slot,false);
			schedule("TargetingLaserImage::remove("@%player@","@%slot@");",0.2);
		}
	} else
	{

		if(GameBase::getLOSInfo(%player, 10000)) 
		{ 	
			$Player::TargetingLaserOn[%player] = getSimTime();
			%pos = $LOS::Position;
			gamebase::setposition($Player::TargetingLaser[%player], %pos); 
			schedule("TargetingLaserImage::remove("@%player@","@%slot@");",0.2);
		} else
		{
			Player::trigger(%player,%slot,false);
			schedule("TargetingLaserImage::remove("@%player@","@%slot@");",0.2);
		}
	}
}

function TargetingLaserImage::remove(%player,%slot)
{
	if((getSimTime() - $Player::TargetingLaserOn[%player]) > 0.15)
	{
		$Player::TargetingLaserOn[%player] = "";	
		if(isObject($Player::TargetingLaser[%player]) && Gamebase::GetDataName($Player::TargetingLaser[%player]) == TargetItem)
			deleteObject($Player::TargetingLaser[%player]);
		$Player::TargetingLaser[%player] = "";
	}
}

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
};

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 0.1;
	maxEnergy = 0.15;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemImageData MedicGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = MedicBolt;
	minEnergy  = 0.1;
	maxEnergy = 0.2;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.0, 0.0, 1.0 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Toolkit";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

ItemData MedicGun
{
	description = "Medikit";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = MedicGunImage;	
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

function MedicGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function MedicGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

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
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
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
						if($SDEPLOY)
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

ItemImageData DeployableHealthPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableHealthPack
{
	description = "Medical Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableHealthPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableHealthPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableHealthPack::onDeploy(%player,%item,%pos)
{
	if (DeployableHealthPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableHealthPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableHealthStation",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Medical Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableHealthPack"]++;
						if($SDEPLOY)
							echo("MSG: ",%client," deployed a Medical Station");
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
   heading = "dDeployables";
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
						if($SDEPLOY)
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
	description = "Repair Toolkit";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData MedicPack
{
	description = "Medikit";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MedicPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == MedicGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function MedicPack::onUse(%player,%item)
{
	if($woundedWeaponArm[Player::getClient(%player)] == 1)
		bottomprint(%player,"<f5><jc>You've been shot in the arm and cannot hold a medic tool!", 3);
	else {
			
		if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
			Player::mountItem(%player,%item,$BackpackSlot);
		}
		else {
			Player::mountItem(%player,MedicGun,$WeaponSlot);
		}
	}
}

function RepairPack::onUse(%player,%item)
{
	if($woundedWeaponArm[Player::getClient(%player)] == 1)
		bottomprint(%player, "<f5><jc>You've been shot in the arm and cannot hold a repair tool!", 3);
	else {
			
		if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
			Player::mountItem(%player,%item,$BackpackSlot);
		}
		else {
			Player::mountItem(%player,RepairGun,$WeaponSlot);
		}
	}
}

function MedicPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == MedicGun) {
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

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}


//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 0.12;  // Energy used/sec for sustained weapons
	minEnergy  = 0.1;
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
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function SensorJammerPackImage::onActivate(%player,%imageSlot)
{	if(!%player.isthrowing || !%player.sensorJammerOn)
	{
		%player.sensorJammerOn = true;
		Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
		%rate = Player::getSensorSupression(%player) + 20;
		Player::setSensorSupression(%player,%rate);
		if(%player.isthrowing)
		{
			player::Trigger(%player,$Backpackslot,false);
		}
	}
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	if(!%player.isthrowing)
	{
		%player.sensorJammerOn = false;
		Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
		%rate = Player::getSensorSupression(%player) - 20;
		Player::setSensorSupression(%player,%rate);
		Player::trigger(%player,$BackpackSlot,false);
	}
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
   heading = "dDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
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

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) 
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
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					if($SDEPLOY)
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
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPackSmall
{
	description = "Light Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData AmmoPackHeavy
{
	description = "Heavy Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData AmmoPackExp
{
	description = "Explosive Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPackSmall::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		
		for(%i = 0; %i < $NumSAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $SmallAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			eval("%item."@%ammoItem@" = "@%numPack@";");
		}
	}
}

function AmmoPackHeavy::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $NumHAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $HeavyAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			eval("%item."@%ammoItem@" = "@%numPack@";");
		}
	}
}

function AmmoPackExp::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		
		for(%i = 0; %i < $NumEAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $ExpAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				
				%numPack = %pCount - %maxnum;
				
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			eval("%item."@%ammoItem@" = "@%numPack@";");
		}
	}
}

//function AmmoPackSmall::onCollision(%this, %item)
//{
//	Item::onCollision(%this, %object);
//}

//function AmmoPackHeavy::onCollision(%this, %item)
//{
//	Item::onCollision(%this, %object);
//}

//function AmmoPackExp::onCollision(%this, %item)
//{
//	Item::onCollision(%this, %object);
//}

function APonDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 7; %i < $NumAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 7) {
	 	    	%item.SOCOMClip = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.OICWClip = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.SAWClip = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.MP5Clip = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.PSG1Clip = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.HowitzerClip = %numPack;
			}
			else if(%i == 13) {
			%item.FiftyCalClip = %numPack;
			}
			else if(%i == 14) {
			%item.AutoShotgunClip = %numPack;
			}
			else if(%i == 15) {
			%item.StingerClip = %numPack;
			}
			else if(%i == 16) {
			%item.FlameClip = %numPack;
			}
			else {
			%item.Grenade = %numPack;
			}
		}
	}
}

//function APonCollision(%this,%object)
//{
//	centerprintall(%object, 5);
//	if (getObjectType(%object) == "Player") {
//		Item::onCollision(%this, %object);	
//		checkPacksAmmo(%object, %this);
//	}
//}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < $NumAllPackItems ; %i = %i +1) {
		%ammoItem = $AmmoPackAllItems[%i];
 	    	eval("%numAdd = "@%item@"."@$AmmoPackAllItems[%i]@";");
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function oldcheckPacksAmmo(%player, %item)
{
	for(%i = 0; %i < $NumAllPackItems ; %i = %i +1) {
		%ammoItem = $AmmoPackAllItems[%i];
		if(%i == 0) {
	      %numAdd = %item.SOCOMAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.OICWClip;
		}
		else if(%i == 2) {
	    	%numAdd = %item.SAWClip;
		}
		else if(%i == 3) {
	    	%numAdd = %item.MP5Clip;
		}
		else if(%i == 4) {
	    	%numAdd = %item.PSG1Clip;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.FiftyCalClip;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.AutoShotgunClip;
		}
		else if(%i == 7) {
		%numAdd = %item.StingerClip;
		}
		else {
 	    	%numAdd = %item.Grenade;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}
function fillSmallAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumSAPackItems ; %i = %i +1) {
		%item = $SmallAmmoPackItems[%i];
		%maxnum = $SmallAmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

function fillHeavyAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumHAPackItems ; %i = %i +1) { 
		%item = $HeavyAmmoPackItems[%i];
		%maxnum = $HeavyAmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

function fillExpAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumEAPackItems ; %i = %i +1) {
		%item = $ExpAmmoPackItems[%i];
		%maxnum = $ExpAmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
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
	description = "Ground Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
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
	if (Item::deployShape(%player,"Ground Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}
//----------------------------------------------------------------------------

ItemImageData RadarPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData RadarPack
{
	description = "Radar Dish";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = RadarPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RadarPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RadarPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Radar Dish",DeployableRadar,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "RadarPack"]++;
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
   heading = "dDeployables";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
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

ItemImageData SandbagpackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Sandbagpack
{
	description = "Sand Bag";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SandbagpackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 10;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Sandbagpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function Sandbagpack::onDeploy(%player,%item,%pos)
{
	if (SandBagPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function DropSandBag(%player, %position, %rotation)
{
	%name = client::getname(Player::getClient(%player));
	%bag = newObject("Sand Bag", "StaticShape", "SandBag", true);
	addToSet("MissionCleanup", %bag);
	%bag.deployerName = %name;
	GameBase::setTeam(%bag,GameBase::getTeam(%player));
	GameBase::setRotation(%bag,%rotation);
	GameBase::setPosition(%bag,%position);
//echo("Sand bag deployed");
					
}

function Sandbagpack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "SandBag") {
				%rot = "1.5 ";
				%rot = %rot @ "0 " @ Getword(GameBase::getrotation(%player), 2) + 1.57;
				//%rottwo = %rot @ "0 " @ Getword(GameBase::getrotation(%player), 2);
				
			%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StationObjectType | $SimPlayerObjectType,$los::position,1.3,1.3,1.3,1);
			%numTwo=containerBoxFillSet(%set,$ItemObjectType | $StaticObjectType,$los::position,15.3,15.3,15.3,1);

			for(%i=0;%numTwo>%i;%i++){ 
				if(Group::getObject(%set,%i).objectiveLine) {
					%yes = true; 				
				} 
			}
			deleteObject(%set);
			if(!%num) {
			if(!%yes) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							
		
					DropSandBag(%player, $los::position, %rot);
					%rot = vector::add(%rot, "0 0 3.14");
					DropSandBag(%player, $los::position, %rot);

					Client::sendMessage(%client,0,"Sand Bag deployed");
					$TeamItemCount[GameBase::getTeam(%beacon) @ "SandBagpack"]++;
					$TeamItemCount[GameBase::getTeam(%beacon) @ "SandBagpack"]++;
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}		
			else
				Client::sendMessage(%client,0,"Unable to deploy - To close to objective");	
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
   heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
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
					if($SDEPLOY)
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
	description = "Remote Machine Gun";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
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
								if($SDEPLOY)
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

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num) {
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
						if($SDEPLOY)
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

// DELTA FORCE DEPLOYABLES
// ---------------------------------------------------------

ItemImageData AirstrikePackImage
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

ItemData AirstrikePack
{
	description = "Airstrike";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = AirstrikePackImage;
	price = 1000;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AirstrikePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Airstrike) {
		Player::unmountItem(%player,$WeaponSlot);
	}

	$airstrikeIn[%player] = 0;
}

function AirstrikePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,Airstrike,$WeaponSlot);
	}
}

function AirstrikePack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Airstrike) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Airstrike
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

// ---------------------------------------------------------

ItemImageData TwentyPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TwentyPack
{
	description = "20mm Cannon Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TwentyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TwentyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TwentyPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function TwentyPack::onDeploy(%player,%item,%pos)
{
	if (TwentyPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TwentyPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployablePlasma",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployablePlasma",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployablePlasma,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"20mm Cannon Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"20mm Cannon Turret deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TwentyPack"]++;
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

// --------------------------------------

ItemImageData AAPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData AAPack
{
	description = "AA Flak Gun";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TwentyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AAPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AAPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function AAPack::onDeploy(%player,%item,%pos)
{
	if (AAPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AAPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableAA",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployableAA",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployableAA,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"AA Flak Gun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"AA Flak Gun deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AAPack"]++;
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

// --------------------------------------

ItemImageData PortGenImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.15, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PortGenPack
{
	description = "Deployable Generator";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PortGenImage;
	shadowDetailMask = 4;
	mass = 10.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PortGenPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PortGenPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function PortGenPack::onDeploy(%player,%item,%pos)
{
	if (PortGenPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function checkPower(%this) {
	%num = Group::objectCount($PowerSet[%this]);
	for(%i = 0; %i < %num; %i++) {
		%obj = Group::getObject($PowerSet[%this], %i);
		%objName = GameBase::getDataName(%obj);
		if (%objName == InventoryStation || %objName == AmmoStation || %objName == VehicleStation || %objName == CommandStation || %objName == VehiclePad || %objName == ChopperStation || %objName == ChopperPad || %objName == JetStation || %objName == JetPad || %objName == TankStation || %objName == TankPad) {
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				//if (%objName != VehiclePad || %objName != JetPad || %objName != ChopperPad || %objName != TankPad) {
					GameBase::playSequence(%obj,0,"power");
					GameBase::playSequence(%obj,1);
				//}
				GameBase::setActive(%obj, true);
				$PortGenPower[%obj] = 1;
			}
		}
		else if(GameBase::getClassName(%obj) == "Elevator") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Elevator::onPower(%obj,true);
				$PortGenPower[%obj] = 1;
			} 
		}
		else if(GameBase::getClassName(%obj) == "Door") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Door::onPower(%obj,true);
				$PortGenPower[%obj] = 1;
			}
		}
	}
	schedule("checkPower("@%this@");", 5, %this); 
}

function PortGenPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
					if(checkDeployArea(%client,$los::position)) { 
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("generator_p","StaticShape",DeployablePortGen,true); 
						addToSet("MissionCleanup", %turret); 
						GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
						GameBase::setPosition(%turret,$los::position); 
						GameBase::setRotation(%turret,%rot); 
						Gamebase::setMapName(%turret,"Portable Generator#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
						Client::sendMessage(%client,0,"Portable Generator deployed"); 
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "PortGenPack"]++;
						$PowerSet[%turret] = newObject("PowerSet" @ %turret,SimSet);
						%mask = $StaticObjectType | MoveableObjectType;
						%num = containerBoxFillSet($PowerSet[%turret],%mask,$los::position,20,20,20,0);
						if (%num > 0) checkPower(%turret); 
						return true; 
					} 
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

// --------------------------------------

ItemImageData HowitzerPackImage { 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
}; 

ItemData HowitzerPack { 
	description = "Howitzer"; 
	shapeFile = "mortar_turret"; 
	className = "Backpack"; 
	heading = "dDeployables"; 
	imageType = HowitzerPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 800; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function HowitzerPack::onUse(%player,%item) { 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else { 
		Player::deployItem(%player,%item); 
	} 
} 

function HowitzerPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 



function HowitzerPack::onDeploy(%player,%item,%pos) { 
	if (HowitzerPack::deployShape(%player,%item)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function HowitzerPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableMortar",%num); 
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
								%turret = newObject("remoteTurret","Turret",DeployableMortar,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"Howitzer#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Howitzer deployed"); 
								playSound(SoundPickupBackpack,$los::position); 
								$TeamItemCount[GameBase::getTeam(%player) @ "HowitzerPack"]++; 
								if($SDEPLOY)
									echo("MSG: ",%client," deployed a Howitzer"); 
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


// --------------------------------------------------------------------

ItemImageData SAMPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SAMPack
{
	description = "SAM Launcher";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SAMPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SAMPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SAMPack::onDeploy(%player,%item,%pos)
{
	if (SAMPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function SAMPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSAM",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSAM",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableSAM,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"SAM Launcher#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"SAM Launcher deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "SAMPack"]++;
								if($SDEPLOY)
									echo("MSG: ",%client," deployed a SAM Launcher");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other SAM Launchers");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other launchers in the area");
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



// ---------------------------------------------------------

ItemImageData TripodPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TripodPack
{
	description = "M240G Machine Gun";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "CBackpacks";
	imageType = TripodPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	ammo = 500;
};

function TripodPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TripodPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function TripodPack::onDeploy(%player,%item,%pos)
{
	if (TripodPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		
	}
}

function TripodPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				//%set = newObject("set",SimSet); 
				//%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				//%num = CountObjects(%set,"DeployablePlasma",%num); 
				//deleteObject(%set); 
				//if($MaxNumTurretsInBox > %num) { 
					//%set = newObject("set",SimSet); 
					//%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					//%num = CountObjects(%set,"TripodGun",%num); 
					//deleteObject(%set); 
					//if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("tripodGun","Turret",TripodGun,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Client::sendMessage(%client,0,"M240G Machine Gun deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TripodPack"]++;
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					//} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				//} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

// --------------------------------------




//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	$woundedWeaponArm[Player::getClient(%player)] = 0;
	$woundedLegs[Player::getClient(%player)] = 0;
	if(Player::getArmor(%player) == "marmor2" || Player::getArmor(%player) == "marmor3")
		Player::setArmor(%player,marmor);
   	else if(Player::getArmor(%player) == "sarmor2" || Player::getArmor(%player) == "sarmor3")
		Player::setArmor(%player,sarmor);
	else if(Player::getArmor(%player) == "iarmor2" || Player::getArmor(%player) == "iarmor3")
		Player::setArmor(%player,iarmor);
	else if(Player::getArmor(%player) == "garmor2" || Player::getArmor(%player) == "garmor3")
		Player::setArmor(%player,garmor);
	else if(Player::getArmor(%player) == "carmor2" || Player::getArmor(%player) == "carmor3")
		Player::setArmor(%player,carmor);
	else if(Player::getArmor(%player) == "earmor2" || Player::getArmor(%player) == "earmor3")
		Player::setArmor(%player,earmor);
	else if(Player::getArmor(%player) == "larmor2" || Player::getArmor(%player) == "larmor3")
		Player::setArmor(%player,larmor);
	else if(Player::getArmor(%player) == "aarmor2" || Player::getArmor(%player) == "aarmor3")
		Player::setArmor(%player,aarmor);
	else if(Player::getArmor(%player) == "comarmor2" || Player::getArmor(%player) == "comarmor3")
		Player::setArmor(%player,comarmor);
	else if(Player::getArmor(%player) == "mfemale2" || Player::getArmor(%player) == "mfemale3")
		Player::setArmor(%player,mfemale);
	else if(Player::getArmor(%player) == "sfemale2" || Player::getArmor(%player) == "sfemale3")
		Player::setArmor(%player,sfemale);
	else if(Player::getArmor(%player) == "ifemale2" || Player::getArmor(%player) == "ifemale3")
		Player::setArmor(%player,ifemale);
	else if(Player::getArmor(%player) == "gfemale2" || Player::getArmor(%player) == "gfemale3")
		Player::setArmor(%player,gfemale);
	else if(Player::getArmor(%player) == "cfemale2" || Player::getArmor(%player) == "cfemale3")
		Player::setArmor(%player,cfemale);
	else if(Player::getArmor(%player) == "efemale2" || Player::getArmor(%player) == "efemale3")
		Player::setArmor(%player,efemale);
	else if(Player::getArmor(%player) == "lfemale2" || Player::getArmor(%player) == "lfemale3")
		Player::setArmor(%player,lfemale);
	else if(Player::getArmor(%player) == "afemale2" || Player::getArmor(%player) == "afemale3")
		Player::setArmor(%player,afemale);
	else if(Player::getArmor(%player) == "comfemale2" || Player::getArmor(%player) == "comfemale3")
		Player::setArmor(%player,comfemale);
	armorChange2(%player);
	$PlayerBleeding[Player::getClient(%player)] = 0;
}

//----------------------------------------------------------------------------

//No longer used
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};


ItemData BouncingMinePack
{
	description = "M16 APMine";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData APMinePack
{
	description = "M14 APMine";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData AAMinePack
{
	description = "M15 AAMine";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function MineAmmo::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	//if(false)
	if($matchStarted) {
		if(%player.driver == 1)
			Vehicle::EndRoll(%player.vehicle);
		else if(%player.throwTime < getSimTime()) {
			if(Player::getItemCount(%client,BouncingMinePack) > 0){
				%obj = newObject("","Mine","antipersonelMineBouncing");
				Player::decItemCount(%player,BouncingMinePack);
			}else if(Player::getItemCount(%client,APMinePack) > 0){
				%obj = newObject("","Mine","antipersonelMine");
				Player::decItemCount(%player,APMinePack);
			}else if(Player::getItemCount(%client,AAMinePack) > 0){
				%obj = newObject("","Mine","antiarmorMine");
				Player::decItemCount(%player,AAMinePack);
			}else{
				return;
			}
			
			
		 	addToSet("MissionCleanup", %obj);
			GameBase::setIsTarget(%obj,true);
 			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			%client = Player::getClient(%player);
			%Multiplier = $ThrowStrength[%armor];
			if(!%Multiplier)
				%Multiplier = 1.0;
			GameBase::throw(%obj,%player,15 * %Multiplier * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			%player.grenadeType = %item;
			%obj.thrower = %player;
			
		}
	}
}

function remoteCheckForRoll(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.driver == 1) {
		%player.vehicle.rolling = 1;
		Vehicle::BarrelRoll(%player.vehicle);
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
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.driver == 1) {
			DropCounterMeasure(%player.vehicle,%player);
			return;
		}
			if(!$cannotthrow[Player::getClient(%player)])
				return;
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			%throwStrength = 0.3 + 0.35 * (%client.throwstrength / 100)/ 2;
			if(Player::getArmor(%player) == garmor || Player::getArmor(%player) == gfemale )
					%throwStrength = 0.3 + 0.35 * (%client.throwstrength / 100);
			if(%client.throwstrength==-1)
				%throwstrength=0.05;
			
			if(player::isdead(%player))
				%throwStrength = 1;
			else
				%throwStrength = 9 * %throwStrength * 2;

			GameBase::throw(%obj,%player,%throwStrength,false);

			  %time=5-(getsimtime()-%client.startedattime);
			%obj.time=%time;
			$Thrower[%obj] = %client;
	}
}

function Dropflare(%player)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	//if(false)
	if($matchStarted) {
//		%obj = newObject("","Mine","Flare");
//		addToSet("MissionCleanup", %obj);
//		GameBase::setTeam(%obj,GameBase::getTeam(%player));
//		%client = Player::getClient(%player);
//		GameBase::throw(%obj,%player,20,false);
//		%obj.thrower = %player;
		Projectile::spawnProjectile("FlareBurst", "0 0 0 0 0 0 0 0 0 " @ getword(gamebase::getposition(%player), 0) @ " " @ getword(gamebase::getposition(%player), 1) @ " 10",  2048, "0 0 50");
	}
}

$CMDropBack = -1;
$CMDropDown = -0.5;

function DropCounterMeasure(%vehicle, %player)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	//if(false)
	if($matchStarted) {
		// Fire the gun
		%vel1 = Item::getVelocity(%vehicle);
		%rot1 = GameBase::getRotation(%vehicle);
		%rot2 = Vector::Add(%rot1,"-1.570796327 0 0");
		%vec1 = Vector::getFromRot(%rot1,$CMDropBack);
		%vec2 = Vector::getFromRot(%rot2,$CMDropDown);
		%pos1 = Vector::add(getBoxCenter(%vehicle),%vec1);
		%pos2 = Vector::add(%pos1,%vec2);
		
		%transform = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
		if(%client.countermeasure == "Flare")
			Projectile::spawnProjectile(FlareBurst, %transform, %player, %vel1);
		else if(%client.countermeasure == "Chaff") {
			Projectile::spawnProjectile(ChaffBurst, %transform, %player, %vel1);
			for(%i = 0; %i < 10; %i++) {
				
				%vel1 = getword(%vel1, 0) + getrandom()*20 - getrandom()*20 @" "@ getword(%vel1, 1) + getrandom()*20 - getrandom()*20 @" "@ getword(%vel1, 2) + getrandom()*20 - getrandom()*20 ;
				
				Projectile::spawnProjectile(Chaff, %transform, %player, %vel1);
			}
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
};

function Beacon::onUse(%player,%item)
{
	Clip::onUse(%player, $Clip[Player::getMountedItem(%player,$WeaponSlot)]);
	//if (Beacon::deployShape(%player,%item)) {
	//	Player::decItemCount(%player,%item);
	//}
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	//if (%armor == "earmor" || %armor == "efemale" || %armor == "earmor2" || %armor == "efemale2" || %armor == "earmor3" || %armor == "efemale3")
	//	return DeploySandBag(%player, %item);
	
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
// DELTA FORCE

ItemImageData ChargeImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData Charge
{
	description = "Explosive Charge";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = ChargeImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function Charge::onUse(%player,%item)
{
	if(!player::isdead(%player)){
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}}
}

function Charge::onDeploy(%player,%item,%pos)
{
	if (Charge::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function Charge::deployShape(%player,%item)
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
					%camera = newObject("Explosive Charge","StaticShape","DefaultCharge",true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Charge::onEnabled(%camera);
					Client::sendMessage(%client,0,"Explosive Charge placed - 15 seconds until detonation");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Charge"]++;
					if($SDEPLOY)
							echo("MSG: ",%client," placed an Explosive Charge");
					Client::setOwnedObject(%client, %camera); 
					Client::setOwnedObject(%client, %player);
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

// END DELTA FORCE
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Stimulants";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
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
			if(%item.classname == Ammo)
				%numsell = 0;
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
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
	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[0 @ DeployableInvPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ RadarPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[0 @ DeployableHealthPack] = 0;
	$TeamItemCount[0 @ TwentyPack] = 0;
	$TeamItemCount[0 @ HowitzerPack] = 0;
	$TeamItemCount[0 @ SAMPack] = 0;
	$TeamItemCount[0 @ GrapplePack] = 0;
	$TeamItemCount[0 @ ApacheVehicle] = 0;
	$TeamItemCount[0 @ KiowaVehicle] = 0;
	$TeamItemCount[0 @ FalconVehicle] = 0;
	$TeamItemCount[0 @ DiveBomberVehicle] = 0;
	$TeamItemCount[0 @ TomcatVehicle] = 0;
	$TeamItemCount[0 @ WarthogVehicle] = 0;
	$TeamItemCount[0 @ BlackhawkVehicle] = 0;
	$TeamItemCount[0 @ HumveeVehicle] = 0;
	$TeamItemCount[0 @ AbramsVehicle] = 0;
	$TeamItemCount[0 @ BradleyVehicle] = 0;
	$TeamItemCount[0 @ LineBackerVehicle] = 0;
	$TeamItemCount[0 @ MLRSVehicle] = 0;
	$TeamItemCount[0 @ MineLayerVehicle] = 0;
	$TeamItemCount[0 @ BomberVehicle] = 0;
	$TeamItemCount[0 @ HerculesVehicle] = 0;
	$TeamItemCount[0 @ SentryVehicle] = 0;
	$TeamItemCount[0 @ GunshipVehicle] = 0;
	$TeamItemCount[0 @ HindVehicle] = 0;
	$TeamItemCount[0 @ Charge] = 0;
	$TeamItemCount[0 @ AirstrikePack] = 0;
	$TeamItemCount[0 @ ReloaderPack] = 0;
	$TeamItemCount[0 @ PortGenPack] = 0;
	$TeamItemCount[0 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[0] = 0;
	// END DELTA FORCE

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ RadarPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[1 @ DeployableHealthPack] = 0;
	$TeamItemCount[1 @ TwentyPack] = 0;
	$TeamItemCount[1 @ HowitzerPack] = 0;
	$TeamItemCount[1 @ SAMPack] = 0;
	$TeamItemCount[1 @ GrapplePack] = 0;
	$TeamItemCount[1 @ ApacheVehicle] = 0;
	$TeamItemCount[1 @ KiowaVehicle] = 0;
	$TeamItemCount[1 @ FalconVehicle] = 0;
	$TeamItemCount[1 @ DiveBomberVehicle] = 0;
	$TeamItemCount[1 @ TomcatVehicle] = 0;
	$TeamItemCount[1 @ WarthogVehicle] = 0;
	$TeamItemCount[1 @ BlackhawkVehicle] = 0;
	$TeamItemCount[1 @ HumveeVehicle] = 0;
	$TeamItemCount[1 @ AbramsVehicle] = 0;
	$TeamItemCount[1 @ BradleyVehicle] = 0;
	$TeamItemCount[1 @ LineBackerVehicle] = 0;
	$TeamItemCount[1 @ MLRSVehicle] = 0;
	$TeamItemCount[1 @ MineLayerVehicle] = 0;
	$TeamItemCount[1 @ BomberVehicle] = 0;
	$TeamItemCount[1 @ HerculesVehicle] = 0;
	$TeamItemCount[1 @ SentryVehicle] = 0;
	$TeamItemCount[1 @ GunshipVehicle] = 0;
	$TeamItemCount[1 @ HindVehicle] = 0;
	$TeamItemCount[1 @ Charge] = 0;
	$TeamItemCount[1 @ AirstrikePack] = 0;
	$TeamItemCount[1 @ ReloaderPack] = 0;
	$TeamItemCount[1 @ PortGenPack] = 0;
	$TeamItemCount[1 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[1] = 0;
	// END DELTA FORCE

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ RadarPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[2 @ DeployableHealthPack] = 0;
	$TeamItemCount[2 @ TwentyPack] = 0;
	$TeamItemCount[2 @ HowitzerPack] = 0;
	$TeamItemCount[2 @ SAMPack] = 0;
	$TeamItemCount[2 @ GrapplePack] = 0;
	$TeamItemCount[2 @ ApacheVehicle] = 0;
	$TeamItemCount[2 @ KiowaVehicle] = 0;
	$TeamItemCount[2 @ FalconVehicle] = 0;
	$TeamItemCount[2 @ DiveBomberVehicle] = 0;
	$TeamItemCount[2 @ TomcatVehicle] = 0;
	$TeamItemCount[2 @ WarthogVehicle] = 0;
	$TeamItemCount[2 @ BlackhawkVehicle] = 0;
	$TeamItemCount[2 @ HumveeVehicle] = 0;
	$TeamItemCount[2 @ AbramsVehicle] = 0;
	$TeamItemCount[2 @ BradleyVehicle] = 0;
	$TeamItemCount[2 @ LineBackerVehicle] = 0;
	$TeamItemCount[2 @ MLRSVehicle] = 0;
	$TeamItemCount[2 @ MineLayerVehicle] = 0;
	$TeamItemCount[2 @ BomberVehicle] = 0;
	$TeamItemCount[2 @ HerculesVehicle] = 0;
	$TeamItemCount[2 @ SentryVehicle] = 0;
	$TeamItemCount[2 @ GunshipVehicle] = 0;
	$TeamItemCount[2 @ HindVehicle] = 0;
	$TeamItemCount[2 @ Charge] = 0;
	$TeamItemCount[2 @ AirstrikePack] = 0;
	$TeamItemCount[2 @ ReloaderPack] = 0;
	$TeamItemCount[2 @ PortGenPack] = 0;
	$TeamItemCount[2 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[2] = 0;
	// END DELTA FORCE

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ RadarPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[3 @ DeployableHealthPack] = 0;
	$TeamItemCount[3 @ TwentyPack] = 0;
	$TeamItemCount[3 @ HowitzerPack] = 0;
	$TeamItemCount[3 @ SAMPack] = 0;
	$TeamItemCount[3 @ GrapplePack] = 0;
	$TeamItemCount[3 @ ApacheVehicle] = 0;
	$TeamItemCount[3 @ KiowaVehicle] = 0;
	$TeamItemCount[3 @ FalconVehicle] = 0;
	$TeamItemCount[3 @ DiveBomberVehicle] = 0;
	$TeamItemCount[3 @ TomcatVehicle] = 0;
	$TeamItemCount[3 @ WarthogVehicle] = 0;
	$TeamItemCount[3 @ BlackhawkVehicle] = 0;
	$TeamItemCount[3 @ HumveeVehicle] = 0;
	$TeamItemCount[3 @ AbramsVehicle] = 0;
	$TeamItemCount[3 @ BradleyVehicle] = 0;
	$TeamItemCount[3 @ LineBackerVehicle] = 0;
	$TeamItemCount[3 @ MLRSVehicle] = 0;
	$TeamItemCount[3 @ MineLayerVehicle] = 0;
	$TeamItemCount[3 @ BomberVehicle] = 0;
	$TeamItemCount[3 @ HerculesVehicle] = 0;
	$TeamItemCount[3 @ SentryVehicle] = 0;
	$TeamItemCount[3 @ GunshipVehicle] = 0;
	$TeamItemCount[3 @ HindVehicle] = 0;
	$TeamItemCount[3 @ Charge] = 0;
	$TeamItemCount[3 @ AirstrikePack] = 0;
	$TeamItemCount[3 @ ReloaderPack] = 0;
	$TeamItemCount[3 @ PortGenPack] = 0;
	$TeamItemCount[3 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[3] = 0;
	// END DELTA FORCE

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ RadarPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[4 @ DeployableHealthPack] = 0;
	$TeamItemCount[4 @ TwentyPack] = 0;
	$TeamItemCount[4 @ HowitzerPack] = 0;
	$TeamItemCount[4 @ SAMPack] = 0;
	$TeamItemCount[4 @ GrapplePack] = 0;
	$TeamItemCount[4 @ ApacheVehicle] = 0;
	$TeamItemCount[4 @ KiowaVehicle] = 0;
	$TeamItemCount[4 @ FalconVehicle] = 0;
	$TeamItemCount[4 @ DiveBomberVehicle] = 0;
	$TeamItemCount[4 @ TomcatVehicle] = 0;
	$TeamItemCount[4 @ WarthogVehicle] = 0;
	$TeamItemCount[4 @ BlackhawkVehicle] = 0;
	$TeamItemCount[4 @ HumveeVehicle] = 0;
	$TeamItemCount[4 @ AbramsVehicle] = 0;
	$TeamItemCount[4 @ BradleyVehicle] = 0;
	$TeamItemCount[4 @ LineBackerVehicle] = 0;
	$TeamItemCount[4 @ MLRSVehicle] = 0;
	$TeamItemCount[4 @ MineLayerVehicle] = 0;
	$TeamItemCount[4 @ BomberVehicle] = 0;
	$TeamItemCount[4 @ HerculesVehicle] = 0;
	$TeamItemCount[4 @ SentryVehicle] = 0;
	$TeamItemCount[4 @ GunshipVehicle] = 0;
	$TeamItemCount[4 @ HindVehicle] = 0;
	$TeamItemCount[4 @ Charge] = 0;
	$TeamItemCount[4 @ AirstrikePack] = 0;
	$TeamItemCount[4 @ ReloaderPack] = 0;
	$TeamItemCount[4 @ PortGenPack] = 0;
	$TeamItemCount[4 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[4] = 0;
	// END DELTA FORCE

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ RadarPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[5 @ DeployableHealthPack] = 0;
	$TeamItemCount[5 @ TwentyPack] = 0;
	$TeamItemCount[5 @ HowitzerPack] = 0;
	$TeamItemCount[5 @ SAMPack] = 0;
	$TeamItemCount[5 @ GrapplePack] = 0;
	$TeamItemCount[5 @ ApacheVehicle] = 0;
	$TeamItemCount[5 @ KiowaVehicle] = 0;
	$TeamItemCount[5 @ FalconVehicle] = 0;
	$TeamItemCount[5 @ DiveBomberVehicle] = 0;
	$TeamItemCount[5 @ TomcatVehicle] = 0;
	$TeamItemCount[5 @ WarthogVehicle] = 0;
	$TeamItemCount[5 @ BlackhawkVehicle] = 0;
	$TeamItemCount[5 @ HumveeVehicle] = 0;
	$TeamItemCount[5 @ AbramsVehicle] = 0;
	$TeamItemCount[5 @ BradleyVehicle] = 0;
	$TeamItemCount[5 @ LineBackerVehicle] = 0;
	$TeamItemCount[5 @ MLRSVehicle] = 0;
	$TeamItemCount[5 @ MineLayerVehicle] = 0;
	$TeamItemCount[5 @ BomberVehicle] = 0;
	$TeamItemCount[5 @ HerculesVehicle] = 0;
	$TeamItemCount[5 @ SentryVehicle] = 0;
	$TeamItemCount[5 @ GunshipVehicle] = 0;
	$TeamItemCount[5 @ HindVehicle] = 0;
	$TeamItemCount[5 @ Charge] = 0;
	$TeamItemCount[5 @ AirstrikePack] = 0;
	$TeamItemCount[5 @ ReloaderPack] = 0;
	$TeamItemCount[5 @ PortGenPack] = 0;
	$TeamItemCount[5 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[5] = 0;
	// END DELTA FORCE

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ RadarPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[6 @ DeployableHealthPack] = 0;
	$TeamItemCount[6 @ TwentyPack] = 0;
	$TeamItemCount[6 @ HowitzerPack] = 0;
	$TeamItemCount[6 @ SAMPack] = 0;
	$TeamItemCount[6 @ GrapplePack] = 0;
	$TeamItemCount[6 @ ApacheVehicle] = 0;
	$TeamItemCount[6 @ KiowaVehicle] = 0;
	$TeamItemCount[6 @ FalconVehicle] = 0;
	$TeamItemCount[6 @ DiveBomberVehicle] = 0;
	$TeamItemCount[6 @ TomcatVehicle] = 0;
	$TeamItemCount[6 @ WarthogVehicle] = 0;
	$TeamItemCount[6 @ BlackhawkVehicle] = 0;
	$TeamItemCount[6 @ HumveeVehicle] = 0;
	$TeamItemCount[6 @ AbramsVehicle] = 0;
	$TeamItemCount[6 @ BradleyVehicle] = 0;
	$TeamItemCount[6 @ LineBackerVehicle] = 0;
	$TeamItemCount[6 @ MLRSVehicle] = 0;
	$TeamItemCount[6 @ MineLayerVehicle] = 0;
	$TeamItemCount[6 @ BomberVehicle] = 0;
	$TeamItemCount[6 @ HerculesVehicle] = 0;
	$TeamItemCount[6 @ SentryVehicle] = 0;
	$TeamItemCount[6 @ GunshipVehicle] = 0;
	$TeamItemCount[6 @ HindVehicle] = 0;
	$TeamItemCount[6 @ Charge] = 0;
	$TeamItemCount[6 @ AirstrikePack] = 0;
	$TeamItemCount[6 @ ReloaderPack] = 0;
	$TeamItemCount[6 @ PortGenPack] = 0;
	$TeamItemCount[6 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[6] = 0;
	// END DELTA FORCE

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ RadarPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
	// DELTA FORCE
	$TeamItemCount[7 @ DeployableHealthPack] = 0;
	$TeamItemCount[7 @ TwentyPack] = 0;
	$TeamItemCount[7 @ HowitzerPack] = 0;
	$TeamItemCount[7 @ SAMPack] = 0;
	$TeamItemCount[7 @ GrapplePack] = 0;
	$TeamItemCount[7 @ ApacheVehicle] = 0;
	$TeamItemCount[7 @ KiowaVehicle] = 0;
	$TeamItemCount[7 @ FalconVehicle] = 0;
	$TeamItemCount[7 @ DiveBomberVehicle] = 0;
	$TeamItemCount[7 @ TomcatVehicle] = 0;
	$TeamItemCount[7 @ WarthogVehicle] = 0;
	$TeamItemCount[7 @ BlackhawkVehicle] = 0;
	$TeamItemCount[7 @ HumveeVehicle] = 0;
	$TeamItemCount[7 @ AbramsVehicle] = 0;
	$TeamItemCount[7 @ BradleyVehicle] = 0;
	$TeamItemCount[7 @ LineBackerVehicle] = 0;
	$TeamItemCount[7 @ MLRSVehicle] = 0;
	$TeamItemCount[7 @ MineLayerVehicle] = 0;
	$TeamItemCount[7 @ BomberVehicle] = 0;
	$TeamItemCount[7 @ HerculesVehicle] = 0;
	$TeamItemCount[7 @ SentryVehicle] = 0;
	$TeamItemCount[7 @ GunshipVehicle] = 0;
	$TeamItemCount[7 @ HindVehicle] = 0;
	$TeamItemCount[7 @ Charge] = 0;
	$TeamItemCount[7 @ AirstrikePack] = 0;
	$TeamItemCount[7 @ ReloaderPack] = 0;
	$TeamItemCount[7 @ PortGenPack] = 0;
	$TeamItemCount[7 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[7] = 0;
	// END DELTA FORCE

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

ItemImageData CDFlagImage
{
	shapeFile = "breath";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData CDFlag
{
	description = "Race Flag";
	shapeFile = "discammo";
	imageType = CDFlagImage;
	showInventory = false;
	shadowDetailMask = 4;
	collisionradius = 5;
	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};



ItemImageData RadioFlasherImage
{
	shapeFile = "breath";
	mountPoint = 5;
	mountOffset = { 0.0, 0.0, 1.25 };
	mountRotation = { -$pi/2, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 1.5;
	lightColor = { 0, 1, 1};
};

ItemData RadioFlasher
{
	description = "Radio";
	shapeFile = "breath";
	imageType = RadioFlasherImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 1.5;
	lightColor = { 0, 1, 1 };
};

ItemImageData HeldGrenadeImage
{
	shapeFile = "Grenade";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 2.2;
        minEnergy = -1.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundLaserHit;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HeldGrenade
{
	description = "Grenade";
	className = "Weapon";
	shapeFile = "grenade";
	hudIcon = "grenade";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HeldGrenadeImage;
	price = 150;
	showWeaponBar = false;
   	validateShape = false;
};

function HeldGrenadeImage::onFire(%player, %slot)
{
	bottomprint(player::getclient(%player), "Press <G> again to throw grenade...", 2);
}