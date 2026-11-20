
//----making room lol
//=======================
$ItemFavoritesKey = "Hybridx1";	
//----------------------------------------------------------------------------
$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[XHChaingun] = True;
$AutoUse[Srocket] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[PlasmaBlaster] = True;
$AutoUse[PlasmaGrenade] = True;
$AutoUse[PlasmaELFLauncher] = True;
$AutoUse[ChainRocket] = True;
$AutoUse[PlasmaSniper] = True;
$AutoUse[LilRocketL] = True;
$AutoUse[Kicker] = True;
$AutoUse[Tachyon] = True;
$AutoUse[TRocketLauncher] = True;
$AutoUse[Magnum] = True;
$AutoUse[Chaingun] = True;
$AutoUse[BlueRage] = True;
$AutoUse[Minigun] = True;
$AutoUse[Ambush] = True;
$AutoUse[M10] = True;
$AutoUse[EMP] = True;
$AutoUse[Grappling] = True;
$AutoUse[HybridRail] = True;
$AutoUse[TankShredder] = True;
$AutoUse[TankRPGLauncher] = True;
$AutoUse[TBlastCannon] = True;
$AutoUse[Vulcan] = True;
$AutoUse[AutoShotgun] = True;
$AutoUse[MP5] = True;
$AutoUse[AssaultChaingun] = True;
$AutoUse[Flak] = True;
$AutoUse[Sniper] = True;
$AutoUse[AntimatterDiscLauncher] = True;
$AutoUse[UFC] = True;
$AutoUse[TTG] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[PlasmaShotgun] = True;
$AutoUse[Afterburner] = True;
$AutoUse[Ramjet] = True;
$AutoUse[Firestorm] = True;
$AutoUse[RFPlasma] = True;
$AutoUse[Railgun] = True;
$AutoUse[PhasedPlasmaCannon] = True;
$AutoUse[GravShock] = True;
$AutoUse[PhaserRifle] = True;
$AutoUse[PulsePhaser] = True;
$AutoUse[ChargedPlasma] = True;
$AutoUse[Mortar] = True;
$AutoUse[AMM] = True;
$AutoUse[Cannon] = True;
$AutoUse[Scorpian] = True;
$AutoUse[Hydra] = True;
$AutoUse[Bazooka] = True;
$AutoUse[Claymore] = True;
$AutoUse[Metreon] = True;
$AutoUse[RepairShell] = True;
$AutoUse[EnergyBall] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[AGL] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[Tau] = True;
$AutoUse[Phaser] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[Terawatt] = True;
$AutoUse[Gluon] = True;
$AutoUse[Cutter] = True;
$AutoUse[GLaser] = True;
$AutoUse[Beam] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[Flashlight] = True;
$AutoUse[ChargeGun] = True;

$Use[Blaster] = True;
$Use[Srocket] = True;

$ArmorType[Male, BrandonArmor] = barmor;
$ArmorType[Female, BrandonArmor] = barmor;
$ArmorType[Male, NewArmor] = narmor;
$ArmorType[Female, NewArmor] = narmor;
$ArmorType[Female, JohnArmor] = jarmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[barmor] = BrandonArmor;
$ArmorName[narmor] = NewArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[RocketAmmo] = 25;
$SellAmmo[xgatlingAmmo] = 25;
$SellAmmo[MagnumAmmo] = 5;
$SellAmmo[BlueRageAmmo] = 100;
$SellAmmo[MinigunAmmo] = 100;
$SellAmmo[AmbushAmmo] = 10;
$SellAmmo[M10Ammo] = 10;
$SellAmmo[LilRocketLAmmo] = 10;
$SellAmmo[EMPAmmo] = 10;
$SellAmmo[HybridRailAmmo] = 10;
$SellAmmo[TankShredderAmmo] = 100;
$SellAmmo[TankRPGAmmo] = 10;
$SellAmmo[PlasmaELFAmmo] = 10;
$SellAmmo[TBlastCannonAmmo] = 100;
$SellAmmo[TRocketLauncherAmmo] = 10;
$SellAmmo[VulcanAmmo] = 100;
$SellAmmo[ShotgunAmmo] = 25;
$SellAmmo[MP5Ammo] = 25;
$SellAmmo[AssaultChaingunAmmo] = 10;
$SellAmmo[FlakAmmo] = 10;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[PlasmaGrenadeAmmo] = 5;
$SellAmmo[RFPlasmaAmmo] = 10;
$SellAmmo[AfterburnerAmmo] = 100;
$SellAmmo[RamjetAmmo] = 100;
$SellAmmo[FirestormAmmo] = 50;
$SellAmmo[DiscLauncherAmmo] = 5;
$SellAmmo[AntimatterDiscLauncherAmmo] = 5;
$SellAmmo[UFCAmmo] = 5;
$SellAmmo[TTGAmmo] = 5;
$SellAmmo[RailgunAmmo] = 50;
$SellAmmo[PhasedPlasmaCannonAmmo] = 10;
$SellAmmo[GravShockAmmo] = 10;
$SellAmmo[PhaserRifleAmmo] = 10;
$SellAmmo[PulsePhaserAmmo] = 1;
$SellAmmo[ChargedPlasma] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[AMMAmmo] = 5;
$SellAmmo[ScorpianAmmo] = 5;
$SellAmmo[HydraAmmo] = 5;
$SellAmmo[BazookaAmmo] = 5;
$SellAmmo[ClaymoreAmmo] = 5;
$SellAmmo[RepairShellAmmo] = 25;
$SellAmmo[EnergyBallAmmo] = 10;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[M10Ammo] = 150;
$AmmoPackMax[MagnumAmmo] = 15;
$AmmoPackMax[HybridRailAmmo] = 15;
$AmmoPackMax[TankShredderAmmo] = 150;
$AmmoPackMax[TankRPGAmmo] = 15;
$AmmoPackMax[PlasmaELFAmmo] = 15;
$AmmoPackMax[LilRocketLAmmo] = 15;
$AmmoPackMax[TBlastCannonAmmo] = 20;
$AmmoPackMax[xgatlingAmmo] = 20;
$AmmoPackMax[RocketAmmo] = 20;
$AmmoPackMax[BlueRageAmmo] = 250;
$AmmoPackMax[ShotgunAmmo] = 50;
$AmmoPackMax[MP5Ammo] = 50;
$AmmoPackMax[MinigunAmmo] = 50;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[PlasmaGrenadeAmmo] = 20;
$AmmoPackMax[AfterburnerAmmo] = 200;
$AmmoPackMax[FirestormAmmo] = 50;
$AmmoPackMax[DiscLauncherAmmo] = 15;
$AmmoPackMax[RailgunAmmo] = 100;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[BazookaAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[EMPAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[RFPlasmaAmmo] = 50;
$AmmoPackMax[AntimatterDiscLauncherAmmo] = 15;
$AmmoPackMax[PhasedPlasmaCannonAmmo] = 30;
$AmmoPackMax[GravShockAmmo] = 30;
$AmmoPackMax[RepairShellAmmo] = 50;
$AmmoPackMax[PhaserRifleAmmo] = 25;
$AmmoPackMax[AntimatterLaserAmmo] = 10;
$AmmoPackMax[ChargedPlasmaAmmo] = 20;
$AmmoPackMax[ScorpianAmmo] = 15;
$AmmoPackMax[SniperAmmo] = 10;
$AmmoPackMax[EnergyBallAmmo] = 20;
$AmmoPackMax[AssaultChaingunAmmo] = 40;
$AmmoPackMax[FlakAmmo] = 40;
$AmmoPackMax[AmbushAmmo] = 30;
$AmmoPackMax[HydraAmmo] = 20;
$AmmoPackMax[VulcanAmmo] = 100;
$AmmoPackMax[AMMAmmo] = 10;
$AmmoPackMax[UFCAmmo] = 10;
$AmmoPackMax[TTG] = 10;
$AmmoPackMax[TRocketLauncher] = 10;
$AmmoPackMax[Claymore] = 10;
$AmmoPackMax[Ramjet] = 100;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = MagnumAmmo;
$AmmoPackItems[2] = BlueRageAmmo;
$AmmoPackItems[3] = ShotgunAmmo;
$AmmoPackItems[4] = MP5Ammo;
$AmmoPackItems[5] = PlasmaAmmo;
$AmmoPackItems[6] = AfterburnerAmmo;
$AmmoPackItems[7] = FirestormAmmo;
$AmmoPackItems[8] = DiscLauncherAmmo;
$AmmoPackItems[9] = RailgunAmmo;
$AmmoPackItems[10] = GrenadeAmmo;
$AmmoPackItems[11] = MortarAmmo;

$AmmoPackItems[12] = BazookaAmmo;
$AmmoPackItems[13] = MineAmmo;
$AmmoPackItems[14] = Grenade;
$AmmoPackItems[15] = Beacon;
$AmmoPackItems[16] = RFPlasmaAmmo;
$AmmoPackItems[17] = AntimatterDiscLauncherAmmo;
$AmmoPackItems[18] = PhasedPlasmaCannonAmmo;
$AmmoPackItems[19] = GravShockAmmo;
$AmmoPackItems[20] = RepairShellAmmo;
$AmmoPackItems[21] = PhaserRifleAmmo;
$AmmoPackItems[22] = AntimatterLaserAmmo;
$AmmoPackItems[23] = ChargedPlasmaAmmo;
$AmmoPackItems[24] = ScorpianAmmo;
$AmmoPackItems[25] = SniperAmmo;
$AmmoPackItems[26] = EnergyBallAmmo;
$AmmoPackItems[27] = AssaultChaingunAmmo;
$AmmoPackItems[28] = FlakAmmo;
$AmmoPackItems[29] = AmbushAmmo;
$AmmoPackItems[30] = HydraAmmo;
$AmmoPackItems[31] = VulcanAmmo;
$AmmoPackItems[32] = AMMAmmo;
$AmmoPackItems[33] = UFCAmmo;
$AmmoPackItems[34] = TTGAmmo;
$AmmoPackItems[35] = ClaymoreAmmo;
$AmmoPackItems[36] = RamjetAmmo;
$AmmoPackItems[37] = M10Ammo;
$AmmoPackItems[38] = HybridRailAmmo;
$AmmoPackItems[39] = EMPAmmo;
$AmmoPackItems[40] = PlasmaGrenadeAmmo;
$AmmoPackItems[41] = TankShredderAmmo;
$AmmoPackItems[42] = TBlastCannonAmmo;
$AmmoPackItems[43] = TRocketLauncherAmmo;
$AmmoPackItems[44] = TankRPGAmmo;
$AmmoPackItems[45] = LilRocketLAmmo;
$AmmoPackItems[46] = MinigunAmmo;
$AmmoPackItems[47] = xgatlingAmmo;
$AmmoPackItems[48] = RocketAmmo;
$AmmoPackItems[49] = plasmaELFAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 9999;
$TeamItemMax[DeployableInvPack] = 9999;
$TeamItemMax[TurretPack] = 9999;
$ItemMax[harmor, Twig] = 1;
$ItemMax[larmor, Twig] = 1;
$ItemMax[lfemale, Twig] = 1;
$ItemMax[marmor, Twig] = 1;
$ItemMax[mfemale, Twig] = 1;

$ItemMax[marmor, RailTurretPack] = 1;
$ItemMax[mfemale, RailTurretPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
$ItemMax[marmor, KickerTurretPack] = 1;
$ItemMax[mfemale, KickerTurretPack] = 1;
$TeamItemMax[AcceleratorDevice1] = 2;
$ItemMax[marmor, FireFlyTurretPack] = 1;
$ItemMax[mfemale, FireFlyTurretPack] = 1;
$ItemMax[marmor, ELFx2TurretPack] = 1;
$ItemMax[mfemale, ELFx2TurretPack] = 1;
$ItemMax[marmor, RailPack] = 1;
$ItemMax[mfemale, RailPack] = 1;

$SellAmmo[Seed] = 5;
$AmmoPackMax[Seed] = 20;
$AmmoPackItems[10] = Seed;
$ItemMax[marmor, Seed] = 5;
$ItemMax[mfemale, Seed] = 5;

$TeamItemMax[KickerTurretPack] = 10;
$TeamItemMax[FireFlyTurretPack] = 12;
$TeamItemMax[RailTurretPack] = 10;
$TeamItemMax[ELFx2TurretPack] = 10;
$TeamItemMax[LaserTurretPack] = 14;
$TeamItemMax[ARPGTurretPack] = 10;
$TeamItemMax[MeltTurretPack] = 18;
$TeamItemMax[TrackerTurretPack] = 5;

$TeamItemMax[CameraPack] = 3;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[WarthogVehicle] = 10;
$TeamItemMax[SR71Vehicle] = 10;
$TeamItemMax[EnterpriseVehicle] = 10;
$TeamItemMax[BomberVehicle] = 10;
$TeamItemMax[SpeedBikeVehicle] = 10;
$TeamItemMax[ColossusVehicle] = 10;
$TeamItemMax[ArwingVehicle] = 2;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 100;
$TeamItemMax[mineammo] = 9999;
$TeamItemMax[Boostermine] = 1000;
$TeamItemMax[grenade] = 9999;

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
$WeaponAmmo[XHChaingun] = "xgatlingAmmo";
$WeaponAmmo[RocketLauncher] = "RocketAmmo";
$WeaponAmmo[Srocket] = "";
$WeaponAmmo[PlasmaBlaster] = "";
$WeaponAmmo[PlasmaELFLauncher] = "PlasmaELFAmmo";
$WeaponAmmo[PlasmaSniper] = "";
$WeaponAmmo[PlasmaGrenade] = "PlasmaGrenadeAmmo";
$WeaponAmmo[Minigun] = "MinigunAmmo";
$WeaponAmmo[Kicker] = "";
$WeaponAmmo[Tachyon] = "";
$WeaponAmmo[TRocketLauncher] = "TRocketLauncherAmmo";
$WeaponAmmo[Grappling] = "";
$WeaponAmmo[EMP] = "EMPAmmo";
$WeaponAmmo[Magnum] = MagnumAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[PlasmaShotgun] = PlasmaShotgunAmmo;
$WeaponAmmo[RFPlasma] = RFPlasmaAmmo;
$WeaponAmmo[Afterburner] = AfterburnerAmmo;
$WeaponAmmo[Ramjet] = RamjetAmmo;
$WeaponAmmo[Firestorm] = FirestormAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[ChainRocket] = "ChainRocketAmmo";
$WeaponAmmo[BlueRage] = BlueRageAmmo;
$WeaponAmmo[Ambush] = AmbushAmmo;
$WeaponAmmo[M10] = M10Ammo;
$WeaponAmmo[HybridRail] = HybridRailAmmo;
$WeaponAmmo[TankShredder] = TankShredderAmmo;
$WeaponAmmo[TankRPGLauncher] = TankRPGAmmo;
$WeaponAmmo[TBlastCannon] = TBlastCannonAmmo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[AutoShotgun] = ShotgunAmmo;
$WeaponAmmo[MP5] = MP5Ammo;
$WeaponAmmo[LilRocketL] = LilRocketLAmmo;
$WeaponAmmo[AssaultChaingun] = AssaultChaingunAmmo;
$WeaponAmmo[Flak] = FlakAmmo;
$WeaponAmmo[Sniper] = SniperAmmo;
$WeaponAmmo[DiscLauncher] = DiscLauncherAmmo;
$WeaponAmmo[AntimatterDiscLauncher] = AntimatterDiscLauncherAmmo;
$WeaponAmmo[UFC] = UFCAmmo;
$WeaponAmmo[TTG] = TTGAmmo;
$WeaponAmmo[Railgun] = RailgunAmmo;
$WeaponAmmo[PhasedPlasmaCannon] = PhasedPlasmaCannonAmmo;
$WeaponAmmo[GravShock] = GravShockAmmo;
$WeaponAmmo[PhaserRifle] = PhaserRifleAmmo;
$WeaponAmmo[PulsePhaser] = PulsePhaserAmmo;
$WeaponAmmo[ChargedPlasma] = ChargedPlasmaAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[AGL] = AGLAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[AMM] = AMMAmmo;
$WeaponAmmo[Cannon] = "";
$WeaponAmmo[Scorpian] = ScorpianAmmo;
$WeaponAmmo[Hydra] = HydraAmmo;
$WeaponAmmo[Bazooka] = BazookaAmmo;
$WeaponAmmo[Claymore] = ClaymoreAmmo;
$WeaponAmmo[Metreon] = "";
$WeaponAmmo[RepairShell] = RepairShellAmmo;
$WeaponAmmo[EnergyBall] = EnergyBallAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[Tau] = "";
$WeaponAmmo[Phaser] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Terawatt] = "";
$WeaponAmmo[Gluon] = "";
$WeaponAmmo[Cutter] = "";
$WeaponAmmo[GLaser] = "";
$WeaponAmmo[TargetingLaser] = "";
$WeaponAmmo[Beam] = "";
$WeaponAmmo[Flashlight] = "";

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


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29,%favItem30,%favItem31,%favItem32,%favItem33,%favItem34,%favItem35,%favItem36,%favItem37,%favItem38,%favItem39,%favItem40,%favItem41,%favItem42,%favItem43,%favItem44,%favItem45,%favItem46,%favItem47,%favItem48,%favItem49,%favItem50)
{
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
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 51; %i++) { 
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
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
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
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
//				else if(%pack == EnergyPack) {
//					if(Player::getItemCount(%client,"LaserRifle") > 0) {
//						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
//						remoteSellItem(%client,22);						
//					}
//				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
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
//				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
//					buyItem(%client,"EnergyPack");
//					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
//				}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
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
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}			
 			else if(%shouldBuy == 2)
				return 1;
		}
		else {
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

ExplosionData invExp
{
	shapeName = "enex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData Fire
{
	bulletShapeName = "hflame.dts";
	explosionTag = invExp;
	collideWithOwner = true;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 1;
	damageValue = -100;
	explosionRadius = 1.8;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "mflame.dts";
};

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
		for(%i=0; %i < 6.28; %i += 1.256) {
			%trans = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 1.3, 1.2));
			Projectile::spawnProjectile("Fire", "0 0 1 0 0 0 0 0 1 " @ %trans, %player, "0 0 -2");
		}
	}
}

function remoteBuyItem(%client,%type)
{
	%item = getItemData(%type);
	if(buyItem(%client,%item)) {
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
		if(Player::getItemCount(%client,%item) && %item.className != Armor) {
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) {
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
//			else if(%item == EnergyPack) { 
//				if(Player::getItemCount(%client,"LaserRifle") > 0) {
//					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser-X");
//					remoteSellItem(%client,22);						
//				}
//                else if(%item == XTremePack) { 
//				if(Player::getItemCount(%client,"LaserRifle") > 0) {
//					Client::sendMessage(%client,0,"Sold XTreme Pack - Auto Selling Laser-X");
//					remoteSellItem(%client,22);						
//				}
//			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
	//echo("Use item: " @ %type @ " " @ %item);
	%client.throwStrength = 1;

	%item = getItemData(%type);
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	//echo("Throw item: " @ %type @ " " @ %strength);
	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo) {
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
	}
}

function remoteDropItem(%client,%type)
{
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
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) {
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
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
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if (%delta > 0) {
				Player::incItemCount(%player,%item,%delta);
				if (%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
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
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
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
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
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

function Item::onDeploy(%player,%item,%pos)
{
}
//=======================
$WeaponNum[1] = EnergyRifle; 
$WeaponNum[2] = Terawatt; 
$WeaponNum[3] = Blaster; 
$WeaponNum[4] = Tachyon; 
$WeaponNum[5] = Magnum; 
$WeaponNum[6] = PlasmaGun;
$WeaponNum[7] = PlasmaShotgun;
$WeaponNum[8] = RFPlasma;
$WeaponNum[9] = Afterburner;
$WeaponNum[10] = Ramjet;
$WeaponNum[11] = Firestorm;
$WeaponNum[12] = Chaingun;
$WeaponNum[13] = BlueRage;
$WeaponNum[14] = Ambush;
$WeaponNum[15] = Vulcan;
$WeaponNum[16] = AutoShotgun;
$WeaponNum[17] = MP5;
$WeaponNum[18] = Flak;
$WeaponNum[19] = AssaultChaingun;
$WeaponNum[20] = Sniper;
$WeaponNum[21] = DiscLauncher;
$WeaponNum[22] = AntimatterDiscLauncher;
$WeaponNum[23] = UFC;
$WeaponNum[24] = TTG; 
$WeaponNum[25] = Railgun;
$WeaponNum[26] = PhasedPlasmaCannon;
$WeaponNum[27] = GravShock;
$WeaponNum[28] = PhaserRifle;
$WeaponNum[29] = PulsePhaser;
$WeaponNum[30] = ChargedPlasma;
$WeaponNum[31] = GrenadeLauncher;
$WeaponNum[32] = AGL;
$WeaponNum[33] = Mortar;
$WeaponNum[34] = AMM;
$WeaponNum[35] = Cannon;
$WeaponNum[36] = Hydra;
$WeaponNum[37] = Scorpian;
$WeaponNum[38] = Bazooka;
$WeaponNum[39] = Claymore;
$WeaponNum[40] = Metreon;
$WeaponNum[41] = RepairShell;
$WeaponNum[42] = EnergyBall;
$WeaponNum[43] = LaserRifle;
$WeaponNum[44] = Tau;
$WeaponNum[45] = Phaser;
$WeaponNum[46] = Cutter;
$WeaponNum[47] = Gluon;
$WeaponNum[48] = GLaser;
$WeaponNum[49] = Beam;
$WeaponNum[50] = Flashlight;
$WeaponNum[51] = M10;
$WeaponNum[52] = HybridRail;
$WeaponNum[53] = EMP;
$WeaponNum[54] = Grappling;
$WeaponNum[55] = Kicker;
$WeaponNum[56] = PlasmaBlaster;
$WeaponNum[57] = PlasmaGrenade;
$WeaponNum[58] = PlasmaELFLauncher;
$WeaponNum[59] = PlasmaSniper;
$WeaponNum[60] = TankShredder;
$WeaponNum[61] = TBlastCannon;
$WeaponNum[62] = TRocketLauncher;
$WeaponNum[63] = TankRPGLauncher;
$WeaponNum[64] = LilRocketL;
$WeaponNum[65] = Minigun;
$WeaponNum[66] = TargetingLaser;
$WeaponNum[67] = ChainRocket;
$WeaponNum[68] = Srocket;
$WeaponNum[69] = XHChaingun;
$WeaponNum[70] = RocketLauncher;

$MaxWeapon=70;

function remoteNextWeapon(%client)
{
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>[You Have No Weapons]", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item++;
	if(%item == $MaxWeapon+1)
		%item = 1;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		$CurWeap = %item;
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		remoteNextWeapon(%client);
}

function remotePrevWeapon(%client)
{
	if($Reloading[%client] == 1)
		return Reloading;
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>[You Have No Weapons]", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item--;
	if(%item == 0)
		%item = $MaxWeapon;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		remotePrevWeapon(%client);
}

function selectValidWeapon(%client)
{
	%item = 1;
	for(%weapon = %item++; %weapon != %item; %weapon = %item++) {
		echo(%weapon);
		if(isSelectableWeapon(%client,%weapon)) {
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
			if(%ammo == ""||Player::getItemCount(%client,%ammo) > 0||Player::getItemCount(%client,$Clip[%weapon]) > 0||%weapon == PAttack)
				return true;
		}
	}
	return false;
}
