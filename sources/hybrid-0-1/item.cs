

$ItemFavoritesKey = "HW";

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = True;
$AutoUse[Tachyon] = True;
$AutoUse[Magnum] = True;
$AutoUse[Chaingun] = True;
$AutoUse[Minigun] = True;
$AutoUse[M60] = True;
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
$AutoUse[GCannon] = True;
$AutoUse[Scorpian] = True;
$AutoUse[Hydra] = True;
$AutoUse[HomingTorpedo] = True;
$AutoUse[Bazooka] = True;
$AutoUse[Claymore] = True;
$AutoUse[Thermonucluear] = True;
$AutoUse[FusionCannon] = True;
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
$AutoUse[AntimatterLaser] = True;
$AutoUse[ALC] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[Flashlight] = True;
$AutoUse[ChargeGun] = True;

$Use[Blaster] = True;

$ArmorType[Male, BrandonArmor] = barmor;
$ArmorType[Female, BrandonArmor] = barmor;

$ArmorType[Male, JohnArmor] = jarmor;
$ArmorType[Female, JohnArmor] = jarmor;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[barmor] = BrandonArmor;
$ArmorName[jarmor] = JohnArmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[MagnumAmmo] = 5;
$SellAmmo[MinigunAmmo] = 100;
$SellAmmo[M60Ammo] = 10;
$SellAmmo[VulcanAmmo] = 100;
$SellAmmo[ShotgunAmmo] = 25;
$SellAmmo[MP5Ammo] = 25;
$SellAmmo[AssaultChaingunAmmo] = 10;
$SellAmmo[FlakAmmo] = 10;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[RFPlasmaAmmo] = 10;
$SellAmmo[AfterburnerAmmo] = 100;
$SellAmmo[RamjetAmmo] = 100;
$SellAmmo[FirestormAmmo] = 50;
$SellAmmo[DiscAmmo] = 5;
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
$SellAmmo[CannonAmmo] = 5;
$SellAmmo[GCannonAmmo] = 25;
$SellAmmo[ScorpianAmmo] = 5;
$SellAmmo[HydraAmmo] = 5;
$SellAmmo[HomingTorpedoAmmo] = 5;
$SellAmmo[BazookaAmmo] = 5;
$SellAmmo[ClaymoreAmmo] = 5;
$SellAmmo[ThermonuclearAmmo] = 1;
$SellAmmo[FusionCannonAmmo] = 1;
$SellAmmo[MetreonAmmo] = 5;
$SellAmmo[RepairShellAmmo] = 25;
$SellAmmo[EnergyBallAmmo] = 10;
$SellAmmo[AntimatterLaserAmmo] = 1;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[MagnumAmmo] = 15;
$AmmoPackMax[MinigunAmmo] = 250;
$AmmoPackMax[ShotgunAmmo] = 50;
$AmmoPackMax[MP5Ammo] = 50;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[AfterburnerAmmo] = 200;
$AmmoPackMax[FirestormAmmo] = 50;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[RailgunAmmo] = 100;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[CannonAmmo] = 10;
$AmmoPackMax[GCannonAmmo] = 50;
$AmmoPackMax[BazookaAmmo] = 10;
$AmmoPackMax[ThermonuclearAmmo] = 1;
$AmmoPackMax[MineAmmo] = 5;
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
$AmmoPackMax[M60Ammo] = 30;
$AmmoPackMax[HydraAmmo] = 20;
$AmmoPackMax[VulcanAmmo] = 100;
$AmmoPackMax[AMMAmmo] = 10;
$AmmoPackMax[UFCAmmo] = 10;
$AmmoPackMax[TTG] = 10;
$AmmoPackMax[Claymore] = 10;
$AmmoPackMax[Ramjet] = 100;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = MagnumAmmo;
$AmmoPackItems[2] = MinigunAmmo;
$AmmoPackItems[3] = ShotgunAmmo;
$AmmoPackItems[4] = MP5Ammo;
$AmmoPackItems[5] = PlasmaAmmo;
$AmmoPackItems[6] = AfterburnerAmmo;
$AmmoPackItems[7] = FirestormAmmo;
$AmmoPackItems[8] = DiscAmmo;
$AmmoPackItems[9] = RailgunAmmo;
$AmmoPackItems[10] = GrenadeAmmo;
$AmmoPackItems[11] = MortarAmmo;
$AmmoPackItems[12] = CannonAmmo;
$AmmoPackItems[13] = GCannonAmmo;
$AmmoPackItems[14] = BazookaAmmo;
$AmmoPackItems[15] = MineAmmo;
$AmmoPackItems[16] = Grenade;
$AmmoPackItems[17] = Beacon;
$AmmoPackItems[18] = RFPlasmaAmmo;
$AmmoPackItems[19] = AntimatterDiscLauncherAmmo;
$AmmoPackItems[20] = PhasedPlasmaCannonAmmo;
$AmmoPackItems[21] = GravShockAmmo;
$AmmoPackItems[22] = RepairShellAmmo;
$AmmoPackItems[23] = PhaserRifleAmmo;
$AmmoPackItems[24] = AntimatterLaserAmmo;
$AmmoPackItems[25] = ChargedPlasmaAmmo;
$AmmoPackItems[26] = ScorpianAmmo;
$AmmoPackItems[27] = SniperAmmo;
$AmmoPackItems[28] = EnergyBallAmmo;
$AmmoPackItems[29] = ThermonuclearAmmo;
$AmmoPackItems[30] = AssaultChaingunAmmo;
$AmmoPackItems[31] = FlakAmmo;
$AmmoPackItems[32] = M60Ammo;
$AmmoPackItems[33] = HydraAmmo;
$AmmoPackItems[34] = VulcanAmmo;
$AmmoPackItems[35] = AMMAmmo;
$AmmoPackItems[36] = UFCAmmo;
$AmmoPackItems[37] = TTGAmmo;
$AmmoPackItems[38] = ClaymoreAmmo;
$AmmoPackItems[39] = RamjetAmmo;


// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 25;
$ItemMax[harmor, Twig] = 1;
$ItemMax[larmor, Twig] = 1;
$ItemMax[lfemale, Twig] = 1;
$ItemMax[marmor, Twig] = 1;
$ItemMax[mfemale, Twig] = 1;

$ItemMax[harmor, RailPack] = 1;
$ItemMax[larmor, RailPack] = 1;
$ItemMax[lfemale, RailPack] = 1;
$ItemMax[marmor, RailPack] = 1;
$ItemMax[mfemale, RailPack] = 1;

$ItemMax[harmor, LaserPack] = 1;
$ItemMax[larmor, LaserPack] = 1;
$ItemMax[lfemale, LaserPack] = 1;
$ItemMax[marmor, LaserPack] = 1;
$ItemMax[mfemale, LaserPack] = 1;


$ItemMax[harmor, vortexTurretPack] = 1;
$ItemMax[larmor, vortexTurretPack] = 1;
$ItemMax[lfemale, vortexTurretPack] = 1;
$ItemMax[marmor, vortexTurretPack] = 1;
$ItemMax[mfemale, vortexTurretPack] = 1;

$ItemMax[harmor, ZapperPack] = 1;
$ItemMax[larmor, ZapperPack] = 1;
$ItemMax[lfemale, ZapperPack] = 1;
$ItemMax[marmor, ZapperPack] = 1;
$ItemMax[mfemale, ZapperPack] = 1;

$ItemMax[harmor, PencilPack] = 1;
$ItemMax[larmor, PencilPack] = 1;
$ItemMax[lfemale, PencilPack] = 1;
$ItemMax[marmor, PencilPack] = 1;
$ItemMax[mfemale, PencilPack] = 1;

$SellAmmo[Seed] = 5;
$AmmoPackMax[Seed] = 20;
$AmmoPackItems[10] = Seed;
$WeaponAmmo[JumpGun] = Seed;

$ItemMax[larmor, Seed] = 10;
$ItemMax[lfemale, Seed] = 10;
$ItemMax[marmor, Seed] = 5;
$ItemMax[mfemale, Seed] = 5;
$ItemMax[harmor, Seed] = 1;

$TeamItemMax[vortexTurretPack] = 300;
$TeamItemMax[RailPack] = 300;
$TeamItemMax[ZapperPack] = 300;
$TeamItemMax[PencilPack] = 300;

$TeamItemMax[RPTPack] = 25;
$TeamItemMax[BazookaPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 20;
$TeamItemMax[PulseSensorPack] = 20;
$TeamItemMax[MotionSensorPack] = 20;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[WarthogVehicle] = 2;
$TeamItemMax[SR71Vehicle] = 1;
$TeamItemMax[EnterpriseVehicle] = 1;
$TeamItemMax[BomberVehicle] = 3;
$TeamItemMax[SpeedBikeVehicle] = 3;
$TeamItemMax[ColossusVehicle] = 1;
$TeamItemMax[ArwingVehicle] = 2;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 100;
$TeamItemMax[Thermonuclear] = 1;

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
$WeaponAmmo[Tachyon] = "";
$WeaponAmmo[Magnum] = MagnumAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[PlasmaShotgun] = PlasmaShotgunAmmo;
$WeaponAmmo[RFPlasma] = RFPlasmaAmmo;
$WeaponAmmo[Afterburner] = AfterburnerAmmo;
$WeaponAmmo[Ramjet] = RamjetAmmo;
$WeaponAmmo[Firestorm] = FirestormAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[Minigun] = MinigunAmmo;
$WeaponAmmo[M60] = M60Ammo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[AutoShotgun] = ShotgunAmmo;
$WeaponAmmo[MP5] = MP5Ammo;
$WeaponAmmo[AssaultChaingun] = AssaultChaingunAmmo;
$WeaponAmmo[Flak] = FlakAmmo;
$WeaponAmmo[Sniper] = SniperAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
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
$WeaponAmmo[Cannon] = CannonAmmo;
$WeaponAmmo[GCannon] = GCannonAmmo;
$WeaponAmmo[Scorpian] = ScorpianAmmo;
$WeaponAmmo[Hydra] = HydraAmmo;
$WeaponAmmo[HomingTorpedo] = HomingTorpedoAmmo;
$WeaponAmmo[Bazooka] = BazookaAmmo;
$WeaponAmmo[Claymore] = ClaymoreAmmo;
$WeaponAmmo[Thermonuclear] = ThermonuclearAmmo;
$WeaponAmmo[FusionCannon] = FusionCannonAmmo;
$WeaponAmmo[Metreon] = MetreonAmmo;
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
$WeaponAmmo[AntimatterLaser] = AntimatterLaserAmmo;
$WeaponAmmo[ALC] = "";
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
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
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
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
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
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
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

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

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
	if (isPlayerBusy(%client))
		return;

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
			else if(%item == EnergyPack) { 
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
			}
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
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		echo("Throw item: " @ %type @ " " @ %strength);
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

//
$NextWeapon[EnergyRifle] = Terawatt;
$NextWeapon[Terawatt] = Blaster;
$NextWeapon[Blaster] = Tachyon;
$NextWeapon[Tachyon] = Magnum;
$NextWeapon[Magnum] = PlasmaGun;
$NextWeapon[PlasmaGun] = PlasmaShotgun;
$NextWeapon[PlasmaShotgun] = RFPlasma;
$NextWeapon[RFPlasma] = Afterburner;
$NextWeapon[Afterburner] = Ramjet;
$NextWeapon[Ramjet] = Firestorm;
$NextWeapon[Firestorm] = Chaingun;
$NextWeapon[Chaingun] = Minigun;
$NextWeapon[Minigun] = M60;
$NextWeapon[M60] = Vulcan;
$NextWeapon[Vulcan] = AutoShotgun;
$NextWeapon[AutoShotgun] = MP5;
$NextWeapon[MP5] = Flak;
$NextWeapon[Flak] = AssaultChaingun;
$NextWeapon[AssaultChaingun] = Sniper;
$NextWeapon[Sniper] = DiscLauncher;
$NextWeapon[DiscLauncher] = AntimatterDiscLauncher;
$NextWeapon[AntimatterDiscLauncher] = UFC;
$NextWeapon[UFC] = TTG;
$NextWeapon[TTG] = Railgun;
$NextWeapon[Railgun] = PhasedPlasmaCannon;
$NextWeapon[PhasedPlasmaCannon] = GravShock;
$NextWeapon[GravShock] = PhaserRifle;
$NextWeapon[PhaserRifle] = PulsePhaser;
$NextWeapon[PulsePhaser] = ChargedPlasma;
$NextWeapon[ChargedPlasma] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = AGL;
$NextWeapon[AGL] = Mortar;
$NextWeapon[Mortar] = AMM;
$NextWeapon[AMM] = Cannon;
$NextWeapon[Cannon] = GCannon;
$NextWeapon[GCannon] = Hydra;
$NextWeapon[Hydra] = Scorpian;
$NextWeapon[Scorpian] = HomingTorpedo;
$NextWeapon[HomingTorpedo] = Bazooka;
$NextWeapon[Bazooka] = Claymore;
$NextWeapon[Claymore] = Thermonuclear;
$NextWeapon[Thermonuclear] = FusionCannon;
$NextWeapon[FusionCannon] = Metreon;
$NextWeapon[Metreon] = RepairShell;
$NextWeapon[RepairShell] = EnergyBall;
$NextWeapon[EnergyBall] = LaserRifle;
$NextWeapon[LaserRifle] = Tau;
$NextWeapon[Tau] = Phaser;
$NextWeapon[Phaser] = Cutter;
$NextWeapon[Cutter] = Gluon;
$NextWeapon[Gluon] = GLaser;
$NextWeapon[GLaser] = AntimatterLaser;
$NextWeapon[AntimatterLaser] = ALC;
$NextWeapon[ALC] = Flashlight;
$NextWeapon[Flashlight] = EnergyRifle;

$PrevWeapon[Blaster] = Terawatt;
$PrevWeapon[Tachyon] = Blaster;
$PrevWeapon[Magnum] = Tachyon;
$PrevWeapon[PlasmaGun] = Magnum;
$PrevWeapon[PlasmaShotgun] = PlasmaGun;
$PrevWeapon[RFPlasma] = PlasmaShotgun;
$PrevWeapon[Afterburner] = RFPlasma;
$PrevWeapon[Ramjet] = Afterburner;
$PrevWeapon[Firestorm] = Ramjet;
$PrevWeapon[Chaingun] = Firestorm;
$PrevWeapon[Minigun] = Chaingun;
$PrevWeapon[M60] = Minigun;
$PrevWeapon[Vulcan] = M60;
$PrevWeapon[AutoShotgun] = Vulcan;
$PrevWeapon[MP5] = AutoShotgun;
$PrevWeapon[Flak] = MP5;
$PrevWeapon[AssaultChaingun] = Flak;
$PrevWeapon[Sniper] = AssaultChaingun;
$PrevWeapon[DiscLauncher] = Sniper;
$PrevWeapon[AntimatterDiscLauncher] = DiscLauncher;
$PrevWeapon[UFC] = AntimatterDiscLauncher;
$PrevWeapon[TTG] = UFC;
$PrevWeapon[Railgun] = TTG;
$PrevWeapon[PhasedPlasmaCannon] = Railgun;
$PrevWeapon[GravShock] = PhasedPlasmaCannon;
$PrevWeapon[PhaserRifle] = GravShock;
$PrevWeapon[PulsePhaser] = PhaserRifle;
$PrevWeapon[ChargedPlasma] = PulsePhaser;
$PrevWeapon[GrenadeLauncher] = ChargedPlasma;
$PrevWeapon[AGL] = GrenadeLauncher;
$PrevWeapon[Mortar] = AGL;
$PrevWeapon[AMM] = Mortar;
$PrevWeapon[Cannon] = AMM;
$PrevWeapon[GCannon] = Cannon;
$PrevWeapon[Hydra] = GCannon;
$PrevWeapon[Scorpian] = Hydra;
$PrevWeapon[HomingTorpedo] = Scorpian;
$PrevWeapon[Bazooka] = HomingTorpedo;
$PrevWeapon[Claymore] = Bazooka;
$PrevWeapon[Thermonuclear] = Claymore;
$PrevWeapon[FusionCannon] = Thermonuclear;
$PrevWeapon[Metreon] = FusionCannon;
$PrevWeapon[RepairShell] = Metreon;
$PrevWeapon[EnergyBall] = RepairShell;
$PrevWeapon[LaserRifle] = EnergyBall;
$PrevWeapon[Tau] = LaserRifle;
$PrevWeapon[Phaser] = Tau;
$PrevWeapon[Cutter] = Phaser;
$PrevWeapon[Gluon] = Cutter;
$PrevWeapon[GLaser] = Gluon;
$PrevWeapon[AntimatterLaser] = GLaser;
$PrevWeapon[ALC] = AntimatterLaser;
$PrevWeapon[Flashlight] = ALC;
$PrevWeapon[EnergyRifle] = Flashlight;
$PrevWeapon[Terawatt] = EnergyRifle;

function remoteNextWeapon(%client)
{
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

function remotePrevWeapon(%client)
{
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

function selectValidWeapon(%client)
{
	%item = EnergyRifle;
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
	if (Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
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

ItemData BrandonArmor
{
   heading = "a.:]Bodies[:.";
	description = "[Crolite]";
	className = "Armor";
	price = 150;
};

ItemData LightArmor
{
   heading = "a.:]Bodies[:.";
	description = "[Argon]";
	className = "Armor";
	price = 250;
};

ItemData MediumArmor
{
   heading = "a.:]Bodies[:.";
	description = "[Engineer]";
	className = "Armor";
	price = 350;
};

ItemData HeavyArmor
{
   heading = "a.:]Bodies[:.";
	description = "[Mercenary]";
	className = "Armor";
	price = 450;
};

ItemData JohnArmor
{
   heading = "a.:]Bodies[:.";
	description = "[Destroyer]";
	className = "Armor";
	price = 550;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Hell Scout";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 150;
};

ItemData WarthogVehicle
{
	description = "Blue Angel Fighter";
	classname = "Vehicle";
	heading = "a||Vehicle||";
	price = 250;
};

ItemData SR71Vehicle
{
	description = "Death Rain";
	classname = "Vehicle";
	heading = "a||Vehicle||";
	price = 350;
};

ItemData EnterpriseVehicle
{
	description = "...:::The Light:::...";
	className = "Vehicle";
   	heading = "a||Vehicle||";
	price = 450;
};

ItemData BomberVehicle
{
	description = "Brimstone Bomber";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 550;
};

ItemData SpeedBikeVehicle
{
	description = "Speed Demon";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 650;
};

ItemData ColossusVehicle
{
	description = "Godly Rain";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData ArwingVehicle
{
	description = "SFDF";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 850;
};

ItemData LAPCVehicle
{
	description = "LAPD";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 950;
};

ItemData HAPCVehicle
{
	description = "HRPS";
	className = "Vehicle";
   heading = "a||Vehicle||";
	price = 1050;
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
	if(%player.Station==""){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else {
				Client::sendMessage(Player::getClient(%player),0,
				strcat(%item.description," has no ammo"));
			}
		}
	}
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

function Ammo::onDrop(%player,%item)
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
   heading = "b.:]New age[:.";
	description = "[Blaster]";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Blaster]: <f2>Blaster with a KICK!");
}

ItemImageData TachyonImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 0.99, 0 };//1.57
      mountOffset = {-0.065, 0, 0.07};

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.4;
	minEnergy = 7;
	maxEnergy = 8;

	projectileType = TachyonBullet;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Tachyon
{
   heading = "c.:]Power[:.";
	description = "[Fusion Rifle]";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = TachyonImage;
	price = 100;
	showWeaponBar = true;
};

function Tachyon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fusion Rifle]: <f2>Shoots a fast bolt of electricty that when come in contact with anything burst into a fire.");
}

ItemData MagnumAmmo
{
	description = "[MM]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MagnumImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single shot
	reloadTime = 0.2;
	fireTime = 0.2;

	ammoType = MagnumAmmo;
	projectileType = MagnumBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Magnum
{
	description = "[PP7 Pistal] ";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = MagnumImage;
	price = 200;
	showWeaponBar = true;
};

function Magnum::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[PP7 Pistal]: <f2>Shoots a high Cal.bullet.");
}

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "[HM]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";//paintgun;
	mountPoint = 0;
      mountRotation = { 0, 0.99, 0 };//1.57
      mountOffset = {-0.065, 0, 0.07};

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
	description = "[Heavy Metal]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "b.:]New age[:.";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Heavy Metal]: <f2>Like the original chaingun but with a few modifications.");
}

//----------------------------------------------------------------------------

ItemData MinigunAmmo
{
	description = "[BR]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MinigunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.5;
	spinDownTime = 3;
	fireTime = 0.001;

	ammoType = MinigunAmmo;
	projectileType = MinigunBullet;
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

ItemData Minigun
{
	description = "[Blue Rage]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 900;
	showWeaponBar = true;
};

function Minigun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Blue Rage]: <f2>A very fast and furious killer.");
}

ItemData M60Ammo
{
	description = "[AMBUSH]Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData M60Image
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 1.0;
	fireTime = 0.1;

	ammoType = M60Ammo;
	projectileType = M60Bullet;
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

ItemData M60
{
	description = "[Ambush]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = M60Image;
	price = 1500;
	showWeaponBar = true;
};

function M60::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Ambush]: <f2>This weapon has to abilities. (1)A very High Calibur bullet, (2)The explosion from the bullest can act like a smoke screen of make your foe think there being bombed.");
}

ItemData VulcanAmmo
{
	description = "[SD]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 1.0;
	fireTime = 0.001;

	ammoType = VulcanAmmo;
	projectileType = VulcanBullet;
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

ItemData Vulcan
{
	description = "[Star Dust]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 1300;
	showWeaponBar = true;
};

function Vulcan::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Star Dust]: <f2>Rip your foe apart with a burst of cosmic power.");
}


ItemData ShotgunAmmo
{
	description = "[WT]Shell";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData AutoShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // SingleShot
	reloadTime = 0.1;
	fireTime = 0.2;

	ammoType = ShotgunAmmo;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AutoShotgun
{
	description = "[WT.12G]";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = AutoShotgunImage;
	price = 400;
	showWeaponBar = true;
};

function AutoShotgunImage::onFire(%player,%slot)
{
	echo("Firing Auto Shotgun!");

	for(%i = 0; %i < 10; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[AutoShotgun],1);
}

function AutoShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[WT.12G]: <f2>A powerful and fast double barreled killer.");
}

//----------------------------------------------------------------------------

ItemData MP5Ammo
{
	description = "[Havoc]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MP5Image
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.001;
	fireTime = 0.001;

	ammoType = MP5Ammo;
	projectileType = MP5Bullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MP5
{
	description = "[Havoc v.2]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = MP5Image;
	price = 100;
	showWeaponBar = true;
};

function MP5::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Havoc v.2]: <f2>A newer virsion of the Havoc Sniper Rifle.");
}

ItemData AssaultChaingunAmmo
{
	description = "[ARPG]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AssaultChaingunImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.3;

	ammoType = AssaultChaingunAmmo;
	projectileType = AssaultChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireAssaultChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AssaultChaingun
{
	description = "[ARPG]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = AssaultChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function AssaultChaingun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[ARPG]: <f2>The Auto Rocket Propelled Grenade Launcher, Is used to Clear deep lines of enemy soldiers.");
}

ItemData FlakAmmo
{
	description = "[RPT]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData FlakImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 3;
	fireTime = 0.3;

	ammoType = FlakAmmo;
	projectileType = FlakBullet;
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

ItemData Flak
{
	description = "[RPT]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = FlakImage;
	price = 150;
	showWeaponBar = true;
};

function Flak::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[RPT]: <f2>Rocket Propelled Thumper. You figure it out.");
}

echo("ARM: Compiling sniper rifle!");

ItemData SniperAmmo
{
	description = "[HS]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;

	ammoType = SniperAmmo;
	projectileType = SniperBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Sniper
{
	description = "[Havoc]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "d.:]Guns[:.";
	shadowDetailMask = 4;
	imageType = SniperImage;
	price = 150;
	showWeaponBar = true;
};

echo("SWORD: Done with sniper rifle!");

function Sniper::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Havoc]: <f2>The most advanced Sniper rifle ever to exist.");
}


//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "[ELFL]Charges";
   heading = "x.:]Ammo[:.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
      mountOffset = {0.065, 0.05, 0};
      mountRotation = {0, -1.57, 0};

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
	description = "[ELF Launcher]";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "b.:(Standard):.";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[ELFL]: <f2>Sends electricly charged particals at a foe.");
}

ItemData PlasmaShotgunAmmo
{
	description = "[HF]Ammo";
   heading = "x.:]Ammo[:.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaShotgunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaShotgunAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaShotgun
{
	description = "[Hell Fire]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "e.:]Fire[:.";
	shadowDetailMask = 4;
	imageType = PlasmaShotgunImage;
	price = 200;
	showWeaponBar = true;
};

function UnchargePlasmaShotgun(%player)
{
	echo("Uncharging Plasma Shotgun...");

	if(Player::getItemCount(%player, $WeaponAmmo[PlasmaShotgun]) > 1)
	{
		Player::decItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
	}

	if($PlasmaShotgunUncharging[%player] == True)
	{
		schedule("UnchargePlasmaShotgun(" @ %player @ ");", 1.5);
	}
}

function PlasmaShotgunImage::onFire(%player,%slot)
{
	echo("Firing PlasmaShotgun!");

	if(Player::getItemCount(%player, $WeaponAmmo[PlasmaShotgun]) > 9)
	{
		for(%i = 0; %i < 10; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PlasmaShotgunBullet",%trans,%player,%vel);
		}
		Player::setItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
		$PlasmaShotgunUncharging[%player] = False;
	}
	else
	{
		Player::incItemCount(%player, $WeaponAmmo[PlasmaShotgun], 1);
		if($PlasmaShotgunUncharging[%player] == False)
		{
			echo("$PlasmaShotgunUncharging is false!");
			schedule("UnchargePlasmaShotgun(" @ %player @ ");", 1.5);
			$PlasmaShotgunUncharging[%player] = True;
		}
	}
}

function PlasmaShotgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Hell Fire]: <f2>This weapon pulls atoms form the air and charges them to there max then sends these pellets into your foe.");
}

ItemData RFPlasmaAmmo
{
	description = "[FX2]Ammo";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RFPlasmaImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RFPlasmaAmmo;
	projectileType = RFPlasmaBullet;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RFPlasma
{
	description = "[Fusion v.2]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "e.:]Fire[:.";
	shadowDetailMask = 4;
	imageType = RFPlasmaImage;
	price = 200;
	showWeaponBar = true;
};

function RFPlasma::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Fusion v.2]: <f2>An updated virsion of the Fusion Rifle");
}

//----------------------------------------------------------------------------

ItemData AfterburnerAmmo
{
	description = "[FT]Ammo";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AfterburnerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = AfterburnerAmmo;
	accuFire = false;
	reloadTime = 0.0000001;
	fireTime = 0.000001;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Afterburner
{
	description = "[Flame Thrower]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "e.:]Fire[:.";
	shadowDetailMask = 4;
	imageType = AfterburnerImage;
	price = 200;
	showWeaponBar = true;
};

function AfterburnerImage::onFire(%player,%slot)
{
	//echo("Firing afterburner!");
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AfterburnerBullet",%trans,%player,%vel);
	//Projectile::spawnProjectile("EngineBullet",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Afterburner],1);
}

function Afterburner::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Flame Thrower]: <f2>Basic Flame thrower.");
}

ItemData RamjetAmmo
{
	description = "[CT]";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RamjetImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	spinUpTime = 0;
	spinDownTime = 0;

	weaponType = 1; // Spinning (for faster shots)
	ammoType = RamjetAmmo;
	accuFire = false;
	reloadTime = 0.0000001;
	fireTime = 0.000001;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Ramjet
{
	description = "[Charged Thrower]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "e.:(Fire):.";
	shadowDetailMask = 4;
	imageType = RamjetImage;
	price = 200;
	showWeaponBar = true;
};

function RamjetImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("RamjetBullet",%trans,%player,%vel);
	//Projectile::spawnProjectile("EngineBullet",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Ramjet],1);
}

function Ramjet::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Charged Thrower]: <f2>Sends Charged plasma heated to 100,000 Degrees.");
}


//------------------------------------------

ItemData FirestormAmmo
{
	description = "[FG]Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData FirestormImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 3;
	fireTime = 0.1;

	ammoType = FirestormAmmo;
	projectileType = FirestormBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundFireGluon;
	sfxSpinDown = SoundFireGluon;
};

ItemData Firestorm
{
	description = "[Fusion Gat]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "e.:(Fire):.";
	shadowDetailMask = 4;
	imageType = FirestormImage;
	price = 800;
	showWeaponBar = true;
};

function Firestorm::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Fusion Gat]: <f2>Rapid Fire Fusion Rifle.");
}

ItemData PhasedPlasmaCannonAmmo
{
	description = "[Cs]Ammo";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData PhasedPlasmaCannonImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PhasedPlasmaCannonAmmo;
	projectileType = PhasedPlasmaCannonBullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PhasedPlasmaCannon
{
	description = "[Comet Lancher]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = "e.:(Fire):.";
	shadowDetailMask = 4;
	imageType = PhasedPlasmaCannonImage;
	price = 350;
	showWeaponBar = true;
};

function PhasedPlasmaCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Comet Launcher]: <f2>A very high powered Rocket.");
}

ItemData GravShockAmmo
{
	description = "[SN]Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GravShockImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GravShockAmmo;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GravShock
{
	description = "[Super Nova]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "d.:(Guns):.";
	shadowDetailMask = 4;
	imageType = GravShockImage;
	price = 225;
	showWeaponBar = true;
};

function GravShockImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("GravShockBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("GravShockBullet2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[GravShock],1);
}

function GravShock::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Super Nova]: <f2>A hard weapon to master but well worth the practice to learn it.");
}

ItemData PhaserRifleAmmo
{
	description = "[Ssr]Ammo";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData PhaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PhaserRifleAmmo;
	projectileType = PhaserRifleBullet;
	accuFire = true;
	reloadTime = 0.08;
	fireTime = 0.4;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PhaserRifle
{
	description = "[Stealth]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = PhaserRifleImage;
	price = 350;
	showWeaponBar = true;
};

function PhaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Stealth]: <f2>A slower sniper rifle but it's a very powerfull shot.");
}

ItemData PulsePhaserAmmo
{
	description = "[HS]Ammo";
   heading = "x.:(Ammo):.";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData PulsePhaserImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PulsePhaserAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PulsePhaser
{
	description = "[Hell Storm]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = PulsePhaserImage;
	price = 500;
	showWeaponBar = true;
};

function RechargePulsePhaserAmmo(%player)
{
	echo("Recharging ammo for Pulse Phaser");
	%armor = Player::GetArmor(%player);
	if(Player::getItemCount(%player,PulsePhaser) > 0)
	{
		if(Player::getItemCount(%player,PulsePhaserAmmo) < $ItemMax[%armor,PulsePhaserAmmo])
		{
			Player::incItemCount(%player,PulsePhaserAmmo,1);
		}
		else
			$PulsePhaserRecharging[%player] = False;
	}
}

function FirePulsePhaser(%player)
{
	echo("Firing Pulse Phaser!");
	if($FiringPulsePhaser[%player] == True)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PulsePhaserBullet",%trans,%player,%vel);
	}
	
	if($PulsePhaserFired[%player] < 2)
	{
		$PulsePhaserFired[%player]++;
		schedule("FirePulsePhaser(" @ %player @ ");", 0.2);
	}
}

function PulsePhaserImage::onFire(%player,%slot)
{
	echo("Firing Pulse Phaser!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("PulsePhaserBullet",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[PulsePhaser],1);

	$FiringPulsePhaser[%player] = True;
	$PulsePhaserFired[%player] = 1;

	schedule("FirePulsePhaser(" @ %player @ ");", 0.2);

	schedule("RechargePulsePhaserAmmo(" @ %player @ ");", 3.5);
}

function PulsePhaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Hell Storm]: <f2>Shoots a Storm of Flamable Gases.");
}

//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "[RR]Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x.:(Ammo):.";
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
	description = "[Retarded Rocket]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "b.:(Standard):.";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Retarded Rocket]: <f2>It was meant to be a projectile but somewhere along the way a miss-calculation was obviosly made.");
}

ItemData AGLAmmo
{
	description = "[NN]Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData AGLImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = AGLAmmo;
	projectileType = AGLBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AGL
{
	description = "[Nitro Nader]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "grenade";
   heading = "f.:]Bombs & Rockets[:.";
	shadowDetailMask = 4;
	imageType = AGLImage;
	price = 300;
	showWeaponBar = true;
};

function AGL::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Nitro Nader]: <f2>Lobbs Grenades filled with Nitro at your enemy.");
}


//----------------------------------------------------------------------------

ItemData ChargedPlasmaAmmo
{
	description = "[STG]Missile";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ChargedPlasmaImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ChargedPlasmaAmmo;
	projectileType = ChargedPlasmaBullet;
	accuFire = true;
	reloadTime = 2;
	fireTime = 2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = explosion4; //the sound plasma bolts make when they explode
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData ChargedPlasma
{
	description = "[S.T.G Launcher]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "e.:(Fire):.";
	shadowDetailMask = 4;
	imageType = ChargedPlasmaImage;
	price = 225;
	showWeaponBar = true;
};

function ChargedPlasma::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[S.T.G Launcher]: <f2>Sky To Ground Launcher is the best way to lead an attack from the sky.");
}

//----------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "[THP]Shells";
	className = "Ammo";
   heading = "x.:(Ammo):.";
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
	description = "[Thumper]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "b.:(Standard):.";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Thumper]: <f2>High power mortar,Long range.");
}

ItemData AMMAmmo
{
	description = "[FM]Ammo";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AMMImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AMMAmmo;
	projectileType = AMMBullet;
	accuFire = false;
	reloadTime = 0.25;
	fireTime = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AMM
{
	description = "[Fire Mortar]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = AMMImage;
	price = 400;
	showWeaponBar = true;
};

function AMM::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fire Mortar]: <f2>***WARNING*** Very large radius.");
}


//----------------------------------------------------------------------------

ItemData CannonAmmo
{
	description = ".:]A[:.Shells";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData CannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountRotation = { 0, 0.99, 0 };//1.57
      mountOffset = {-0.065, 0, 0.07};

	weaponType = 0; // Single Shot
	ammoType = CannonAmmo;
	projectileType = CannonBullet;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Cannon
{
	description = ".:]A[:.Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = CannonImage;
	price = 400;
	showWeaponBar = true;
};

function Cannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[.:]A[:.Cannon]: <f2>Devloped by the .:]X-Treme Anarchist[:. Tribe.");
}



ItemData ScorpianAmmo
{
	description = "[TRI]Ammo";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ScorpianImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ScorpianAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Scorpian
{
	description = "[TRI]";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = ScorpianImage;
	price = 500;
	showWeaponBar = true;
};

function FireScorpian(%player)
{
	echo("Firing Scorpian!");
	if($FiringScorpian[%player] == True)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ScorpianBullet",%trans,%player,%vel);
	}
	
	if($ScorpianFired[%player] < 2)
	{
		$ScorpianFired[%player]++;
		schedule("FireScorpian(" @ %player @ ");", 0.2);
	}
}

function ScorpianImage::onFire(%player,%slot)
{
	echo("Firing Scorpian!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ScorpianBullet",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[Scorpian],1);

	$FiringScorpian[%player] = True;
	$ScorpianFired[%player] = 1;

	schedule("FireScorpian(" @ %player @ ");", 0.2);
}

function Scorpian::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[TRI]: <f2>Launches 3 Missiles at one time.");
}

ItemData HydraAmmo
{
	description = "[FF]Missiles";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HydraImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HydraAmmo;
	projectileType = HydraBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hydra
{
	description = "[Fire Fly]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = HydraImage;
	price = 650;
	showWeaponBar = true;
};

function Hydra::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Fire Fly]: <f2>Sends rapid fire missles at your foe.");
}


//This weapon is not working
//Whenever it fires anything that is supposed to
//be homing, the game randomly quits and won't fire
//I think I need to add an "OnFire" function,
//but so far any attempts at that have failed
//For now, the entries in station.cs have
//been commented out to prevent players
//from getting crashed
//SEE ABOVE NOTE


ItemData BazookaAmmo
{
	description = "[IPM]Shells";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BazookaImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = BazookaAmmo;
	projectileType = BazookaBullet;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Bazooka
{
	description = "[Impact Mortar]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = BazookaImage;
	price = 400;
	showWeaponBar = true;
};

function Bazooka::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Impact Mortar]: <f2>Explodes on contact.");
}

ItemData ClaymoreAmmo
{
	description = "[AS]Ammo";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ClaymoreImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ClaymoreAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Claymore
{
	description = "[Air Strike]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = ClaymoreImage;
	price = 400;
	showWeaponBar = true;
};

function ClaymoreImage::onFire(%player,%slot)
{
	echo("Firing Claymore!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	Projectile::spawnProjectile("ClaymoreBullet1",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet2",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet3",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet4",%trans,%player,%vel);
	Projectile::spawnProjectile("ClaymoreBullet5",%trans,%player,%vel);
      Projectile::spawnProjectile("ClaymoreBullet6",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[Claymore],1);
}

function Claymore::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Air Strike]: <f2>The weapon that makes you a one man Air raid.");
}



ItemData MetreonAmmo
{
	description = "[ERPM]Ammo";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MetreonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MetreonAmmo;
	projectileType = MetreonBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Metreon
{
	description = "[ERPM]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disc";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = MetreonImage;
	price = 1500;
	showWeaponBar = true;
};

function Metreon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[ERPM]: <f2>The Electric Rocket Propelled Mortar delivers a large blast of energy.");
}


ItemData RepairShellAmmo
{
	description = "[+M+]Shells";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 25;
};

ItemImageData RepairShellImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RepairShellAmmo;
	projectileType = RepairShellBullet;
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

ItemData RepairShell
{
	description = "[+M+ Launcher]";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = RepairShellImage;
	price = 400;
	showWeaponBar = true;
};

function RepairShell::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[+M+ Launcher]: <f2>Repairs anything 100% as long as Team Damage is on.");
}

ItemData EnergyBallAmmo
{
	description = "[TB]Shells";
	className = "Ammo";
   heading = "x.:(Ammo):.";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData EnergyBallImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EnergyBallAmmo;
	projectileType = EnergyBallBullet;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData EnergyBall
{
	description = "[Time Bomb Lobber]";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "mortar";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = EnergyBallImage;
	price = 350;
	showWeaponBar = true;
};

function EnergyBall::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Time Bomb Launcher]: <f2>Drops Mortars that explode after 25 seconds after the time of the drop.");
}



//----------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "[Disc]Ammo";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x.:(Ammo):.";
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
	reloadTime = 0.1;
	fireTime = 0.5;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "[DX 2050]";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "b.:(Standard):.";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[DX 2050]: <f2>Basic Disc launcher but faster and a touch stronger.");
}

ItemData AntimatterDiscLauncherAmmo
{
	description = "[SMS]Shells";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData AntimatterDiscLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = AntimatterDiscLauncherAmmo;
	projectileType = AntimatterDiscLauncherBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.0;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData AntimatterDiscLauncher
{
	description = "[Straight Mortar Shot]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "disk";
   heading = "f.:(Bombs & Rockets):.";
	shadowDetailMask = 4;
	imageType = AntimatterDiscLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function AntimatterDiscLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, " [S.M.S]: <f2>Is an Updated virsion of the lobbing mortar.");
}

ItemData UFCAmmo
{
	description = "[PS]Shell";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData UFCImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = UFCAmmo;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.5;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData UFC
{
	description = "[Partical Shotgun]";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
   heading = "d.:(Guns):.";
	shadowDetailMask = 4;
	imageType = UFCImage;
	price = 150;
	showWeaponBar = true;
};

function UFCImage::onFire(%player,%slot)
{
	echo("Firing UFC!");

	for(%i = 0; %i < 10; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("UFCPellet",%trans,%player,%vel);
	}

	Player::decItemCount(%player,$WeaponAmmo[UFC],1);
}

function UFC::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Partical Shotgun]: <f2>Powerfull Bullets that can rip threw any armor in a hurry");
}

ItemData TTGAmmo
{
	description = "[EL]Shell";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TTGImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0;
	ammoType = TTGAmmo;
	projectileType = TTGBullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData TTG
{
	description = "[Ever Laster]";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "d.:(Guns):.";
	shadowDetailMask = 4;
	imageType = TTGImage;
	price = 200;
	showWeaponBar = true;
};

function TTG::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Ever Laster]: <f2>Fires a high powered Disc at a Medium speed.");
}


ItemData RailgunAmmo
{
	description = "[THR]Ammo";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "x.:(Ammo):.";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 1; // Spinning
	ammoType = RailgunAmmo;
	projectileType = RailgunBullet;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
	spinUpTime = 1.5;
	spinDownTime = 2.0;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun
{
	description = "[TH Rail Gun]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "d.:(Guns):.";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 450;
	showWeaponBar = true;
};

function Railgun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[TH Rail]: <f2>Great weapon for Sniping and destroying anything in it's way.");
}

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
	description = "[Lazer X]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "b.:(Standard):.";
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
			"Must have an Energy Pack to use [Lazer X]."); 
}

function LaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[Lazer X]: <f2>High power,Long range Need i say more.");
}

//----------------------------------------------------------------------------

ItemImageData TauImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = TauLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 40;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 10;
	lightColor = { 2.0, 2.0, 0.0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Tau
{
	description = "[Radiation Rifle]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = TauImage;
	price = 1000;
	showWeaponBar = true;
};

function Tau::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Radiation Rifle]: <f2>You tend to glow after useing this.");
}

//----------------------------------------------------------------------------

ItemImageData PhaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PhaserBullet;
	accuFire = true;
	reloadTime = 10.0;
	fireTime = 1.0;
	minEnergy = 140;
	maxEnergy = 450;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Phaser
{
	description = "[Multi-Rifle]";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = PhaserImage;
	price = 3000;
	showWeaponBar = true;
};

function Phaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Multi-Rifle]: <f2>This weapon has 3 Uses,It can be like a Range finder,A Flash Light and a true killer.");
}

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
	description   = "[Range Finder]";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "b.:(Standard):.";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function Phaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Range Finder]: <f2>A tool for pointing out things.");
}


ItemImageData FlashlightImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = FlashlightLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	reloadTime = 0.01;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 1, 1, 1 };

	sfxFire     = 0;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flashlight
{
	description   = "[The Touch]";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType     = FlashlightImage;
	price         = 25;
	showWeaponBar = true;
};

function Flashlight::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[The Touch]: <f2>The bad touch.");
}

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "paintgun";
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
   description = "[ELFx]";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "b.:(Standard):.";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};

function EnergyRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "[ELFx]: <f2>An ELF at a high speed");
}

ItemImageData TerawattImage
{
	shapeFile = "mortargun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = TerawattBullet;
   minEnergy = 10;
   maxEnergy = 23;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Terawatt
{
   description = "[Lightning Cannon]";
	shapeFile = "mortargun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "c.:(Energy):.";
   shadowDetailMask = 4;
   imageType = TerawattImage;
	showWeaponBar = true;
   price = 500;
};

function Terawatt::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Lightning Cannon]: <f2>The power of Lightning in a Cannon.");
}

ItemImageData GluonImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 3;
	spinUpTime = 0.0;
	spinDownTime = 0.0;
	fireTime = 0.00001;

	minEnergy = 1;
	maxEnergy = 2;

	projectileType = GluonLaser;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundFireGluon;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = 0;
	sfxSpinDown = 0;
};

ItemData Gluon
{
	description = "[Whizzer]";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "blaster";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = GluonImage;
	price = 2000;
	showWeaponBar = true;
};

function Gluon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Whizzer]: <f2>Nice for cutting shit into tiny pieces.");
}

ItemImageData CutterImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0.0;
	fireTime = 0.00001;

	minEnergy = 1;
	maxEnergy = 1;

	projectileType = CutterBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundFireGluon;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = 0;
	sfxSpinDown = 0;
};

ItemData Cutter
{
	description = "[Slicer]";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "blaster";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = CutterImage;
	price = 600;
	showWeaponBar = true;
};

function Cutter::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Slicer]: <f2>Low powered but very effective.");
}

ItemImageData GLaserImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 2.0;
	fireTime = 0.025;

	minEnergy = 1;
	maxEnergy = 2;

	projectileType = GLaserBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundFireGLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = 0;
	sfxSpinDown = 0;
};

ItemData GLaser
{
	description = "[Lazer Gat]";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = GLaserImage;
	price = 200;
	showWeaponBar = true;
};

function GLaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[Lazer Gat]: <f2>Fast and furious.");
}

ItemData AntimatterLaserAmmo
{
	description = "";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData AntimatterLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AntimatterLaserAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 2.0;
	minEnergy = 195;
	maxEnergy = 200;

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AntimatterLaser
{
	description = "";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "f.:(Mod By: Armagedon):.";
	shadowDetailMask = 4;
	imageType = AntimatterLaserImage;
	price = 950;
	showWeaponBar = true;
};

function FireAL(%player)
{
	if($FiringAntimatterLaser[%player] == True)
	{
		if($FiredAL[%player] < 100)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("AntimatterLaserBullet",%trans,%player,%vel);
			
			$FiredAL[%player]++;
		}
		else
			$FiringAntimatterLaser[%player] = False;
	}
}

function AntimatterLaserImage::onFire(%player,%slot)
{
	$FiringAntimatterLaser[%player] = True;
	$FiredAL[%player] = 0;

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AntimatterLaserBullet",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[AntimatterLaser],1);

	schedule("FireAL(" @ %player @ ");", 0.01);
}

ItemImageData ALCImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0.0;
	fireTime = 0.1;

	minEnergy = 3;
	maxEnergy = 4;

	projectileType = ALCBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = 0;
	sfxSpinDown = 0;
};

ItemData ALC
{
	description = "[RHB]";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "chain";
   heading = "c.:(Energy):.";
	shadowDetailMask = 4;
	imageType = ALCImage;
	price = 200;
	showWeaponBar = true;
};

function ALC::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "[RHB]: <f2>Turn your enemy into a pile of ash.");
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

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
	description = "[Inventory Station]";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "h.:]Deployables[:.";
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
	description = "[Ammo Station]";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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

//$CanAlwaysTeamDestroy[vortexTurretPack] = 1;

function deployVortexTurret::Initialize()
{	$TeamItemCount[0 @ vortexTurretPack] = 0;
	$TeamItemCount[1 @ vortexTurretPack] = 0;
	$TeamItemCount[2 @ vortexTurretPack] = 0;
	$TeamItemCount[3 @ vortexTurretPack] = 0;
	$TeamItemCount[4 @ vortexTurretPack] = 0;
	$TeamItemCount[5 @ vortexTurretPack] = 0;
	$TeamItemCount[6 @ vortexTurretPack] = 0;
	$TeamItemCount[7 @ vortexTurretPack] = 0;
}

ItemImageData vortexTurretPackImage 
{	shapeFile = "hellfiregun";//camera
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData vortexTurretPack 
{	description = "[Fire Fly Turret]";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "h.:]Deploayables[:.";
	imageType = vortexTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function vortexTurretPack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}


TurretData Deployablevortex 
{	className = "Turret";
	shapeFile = "hellfiregun";//camera,
	projectileType = HydraBullet;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 1.0;
	maxGunEnergy = 1;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 3.0;
	speedModifier = 1.5;
	range = 60;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundFireLaser;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "[Fire Fly Turret]";
	damageSkinData = "objectDamageSkins";
};

function Deployablevortex::onAdd(%this)
{	schedule("Deployablevortex::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.05;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Vortex Turret");
}

function Deployablevortex::deploy(%this) 
{	GameBase::playSequence(%this,1,"deploy");
}

function Deployablevortex::onEndSequence(%this,%thread) 
{	GameBase::setActive(%this,true);
}

function Deployablevortex::onDestroyed(%this) 
{	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "vortexTurretPack"]--;
}

function Deployablevortex::onPower(%this,%power,%generator) 
{
}

function Deployablevortex::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

function vortexTurretPack::onDeploy(%player,%item,%pos) { 
	if (vortexTurretPack::deployShape(%player,%item)&& !$build) { 
	Player::decItemCount(%player,%item); } 
	%client = Player::getClient(%player); 
	if(Client::isItemShoppingOn(%client,%item)) {  
		GameBase::playSound(%this, SoundFireMortar, 0.2);
		%velocity = 0;
		%zVec = 100;
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%c),%velocity,%zVec);
		Player::applyImpulse(%client,%jumpDir);
		centerprint(%client, "<jc><f1>Armagedon Sticks his Dick up your ASS.", 10);
		Player::blowUp(%client); //This can be fun without killing them...
		playNextAnim(%client);   //Let the ceiling kill them...
		Player::kill(%client);   //Landing damage is disabled in SEX mod...
		//Client::onKilled(%c,%client); //Global death message

		//Client::sendMessage(%client,0,"Armagedon Sticks his Dick up your ASS.");// Chat box message
  	}
  

//------------relocated here from game.cs 

$TeamItemMax[vortexTurretPack] = 300;

$MaxNumVortexInBox = 2;     //Number of remote turrets allowed in the area
$VortexBoxMaxLength = 50;    //Define Max Length of the area
$VortexBoxMaxWidth =  50;    //Define Max Width of the area
$VortexBoxMaxHeight = 15;    //Define Max Height of the area

//------------

function vortexTurretPack::deployShape(%player,%item) { 
%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) { 
		if (GameBase::getLOSInfo(%player,3)) { 
		%obj = getObjectType($los::object); 
		%set = newObject("set",SimSet); 
		%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$VortexBoxMaxLength,$VortexBoxMaxWidth,$VortexBoxMaxHeight,0); 
	  	%num = CountObjects(%set,"Deployablevortex",%num);
		deleteObject(%set); 
		  if($MaxNumVortexInBox > %num) { 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { 
			%prot = GameBase::getRotation(%player); 
			%zRot = getWord(%prot,2); 
			  if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
			  %rot = "3.14159 0 " @ %zRot; } 

			else { %rot = Vector::getRotation($los::normal); } } 
		if(checkDeployArea(%client,$los::position)) { 
			%camera = newObject("Camera","Turret",Deployablevortex,true);  
			addToSet("MissionCleanup", %camera);  
			GameBase::setTeam(%camera,GameBase::getTeam(%player));  
			GameBase::setRotation(%camera,%rot);  
			GameBase::setPosition(%camera,$los::position); 
			Gamebase::setMapName(%camera,"Havoc v.2 Turret#"@ $totalNumVortex++ @ " " @ Client::getName(%client)); 
 			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Havoc v.2 Turret");
			if(!$build)Client::sendMessage(%client,0,"Havoc v.2 Turret deployed");  
			playSound(SoundPickupBackpack,$los::position);  
			$TeamItemCount[GameBase::getTeam(%camera) @ "vortexTurretPack"]++;$vortex++;  
			return true; } }  
	  else { 
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
	} 
}  
	else 
		{	

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other Havoc turrets in the area");} 
	}  
    else { 
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range"); 
	}
 }  
  else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 


//--------------------------------------

//--------------------------------------



//--------------------------------------

$TeamItemMax[TurretPack] = 300;

//--------------------------------------

ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

//------relocated here by 

$MaxNumTurretsInBox = 20;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 20;	  //Define Min Length from another turret
$TurretBoxMinWidth =  2;	  //Define Min Width from another turret
$TurretBoxMinHeight = 2;    //Define Min Height from another turret
}


ItemData TurretPack
{
	description = "[ES Turret]";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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
	if (TurretPack::deployShape(%player,%item)&& !$build) {
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
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
								if(!$build)Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Turrets only deploy on flat surfaces");}
					} 
					else{

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Ionic interference with other turrets.");
			}
				}
			   else {

			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other remote turrets.");
			}
			}
			else {
			if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");}
		}
		else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range");}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//--------------------------------------

TurretData DeployableTurret
{
	className = "Turret";
	shapeFile = "remoteturret";
   validateShape = true;
   validateMaterials = true;
	projectileType = PGBullet;
	maxDamage = 0.75;
	maxEnergy = 200;
	minGunEnergy = 75;//6
	maxGunEnergy = 1;//5
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.2;
	speed = 4.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 4;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "[ES Turret]";
	damageSkinData = "objectDamageSkins";
};

function DeployableTurret::onAdd(%this)
{
	schedule("DeployableTurret::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,50);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Remote Turret");
	}
}

function DeployableTurret::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableTurret::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableTurret::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "TurretPack"]--;
}

// Override base class just in case.
function DeployableTurret::onPower(%this,%power,%generator) {}
function DeployableTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,50);
	GameBase::setActive(%this,true);
}

//=========================================





LightningData ZapperCharge
{
   bitmapName       = "laser_pulse.bmp"; //lightningNew.bmp
   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------

//--------------------------------------

ItemImageData ZapperPackImage
{
	shapeFile = "indoorgun"; //remoteturret,camera
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = true; //false
};

ItemData ZapperPack
{
	description = "[ELFx2]"; //TurretMine
	shapeFile = "indoorgun"; //camera,remoteturret
	className = "Backpack";
   heading = "h.:(Deployables):.";
	imageType = ZapperPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ZapperPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ZapperPack::onDeploy(%player,%item,%pos)
{
	if (ZapperPack::deployShape(%player,%item)&& !$build) {
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
//------------relocated here from game.cs 
//--------------------------------------

//limit how many can be set in box
$TeamItemMax[ZapperPack] = 300;

$MaxNumZappersInBox = 2;     //Number of remote turrets allowed in the area
$ZapperBoxMaxLength = 50;    //Define Max Length of the area
$ZapperBoxMaxWidth =  50;    //Define Max Width of the area
$ZapperBoxMaxHeight = 15;    //Define Max Height of the area

//------------
function ZapperPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build){ if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ZapperBoxMaxLength,$ZapperBoxMaxWidth,$ZapperBoxMaxHeight,0);   %num = CountObjects(%set,"DeployableZapper",%num);   deleteObject(%set); if($MaxNumZappersInBox > %num) { if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") { 
				%prot = GameBase::getRotation(%player); 
				%zRot = getWord(%prot,2); 
				if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
		%rot = "3.14159 0 " @ %zRot; } 

	else { %rot = Vector::getRotation($los::normal); } } 
		if(checkDeployArea(%client,$los::position)) { 
			%camera = newObject("Camera","Turret",DeployableZapper,true);  
				addToSet("MissionCleanup", %camera);  
				GameBase::setTeam(%camera,GameBase::getTeam(%player));  
				GameBase::setRotation(%camera,%rot);  
				GameBase::setPosition(%camera,$los::position); 
				Gamebase::setMapName(%camera,"eLFx2#"@ $totalNumZapper++ @ " " @ Client::getName(%client));  
				if(!$build)Client::sendMessage(%client,0,"ELFx2 deployed");
  				echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a ELFx2");
				playSound(SoundPickupBackpack,$los::position);  
				$TeamItemCount[GameBase::getTeam(%camera) @ "ZapperPack"]++;$zap++;  
					return true; } }  
			else { if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
			}
 }  
		else{
			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other ELFx2 turrets in the area"); 
		}
		}  
			else { 
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range"); }
		 }  
			else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			 return false; 
	} 


//--------------------------------------

TurretData DeployableZapper
{
	className = "Turret"; //Turret
	shapeFile = "indoorgun";//camera
   validateShape = true;
   validateMaterials = true;
	projectileType = turretCharge;
	maxDamage = 0.65;
	maxEnergy = 100;
	minGunEnergy = 10;//6
	maxGunEnergy = 90;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.5;
	range = 30;
	visibleToSensor = true;
	shadowDetailMask = 8;//4
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	//fireSound        = SoundGeneratorPower;

	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "[ELFx2]"; //RemoteTurretMine
	damageSkinData = "objectDamageSkins";
	
	isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;


};

function DeployableZapper::onAdd(%this)
{
	schedule("DeployableZapper::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Zapper");
	}
}

function DeployableZapper::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableZapper::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function DeployableZapper::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableZapper"]--;
	GameBase::setRechargeRate(%this,0); GameBase::setActive(%this,false);
}

// Override base class just in case.
function DeployableZapper::onPower(%this,%power,%generator) {}
function DeployableZapper::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


//=====================================
//





//--------------------------------------




ItemImageData PencilPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };



ItemData PencilPack { description = "[Rail Turret]"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
   heading = "h.:(Deployables):.";
	imageType = PencilPackImage; 
	shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 500; 
	hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function PencilPack::onUse(%player,%item) {
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 
	Player::mountItem(%player,%item,$BackpackSlot); } 
	else { Player::deployItem(%player,%item); } } 

function PencilPack::onDeploy(%player,%item,%pos) { 
	if (PencilPack::deployShape(%player,%item)&& !$build) { 
	Player::decItemCount(%player,%item); } 
	%client = Player::getClient(%player); 
	if(!$build && Client::isItemShoppingOn(%client,%item)) {  
		playNextAnim(%client); 
		Player::kill(%client); 
		centerprint(%client, "<jc><f1>No exploiting Inventories!!", 10);
		Client::sendMessage(%client,0,"No exploiting Inventories!!");  }
		 } 

//------------relocated here from game.cs 

$TeamItemMax[PencilPack] = 300;//large numbers mean large fun...

$MaxNumPencilInBox = 5;     //Number of remote turrets allowed in the area
$PencilBoxMaxLength = 50;    //Define Max Length of the area
$PencilBoxMaxWidth =  50;    //Define Max Width of the area
$PencilBoxMaxHeight = 15;    //Define Max Height of the area

//we dont care how close they're set, just how many in a given area
//------------

function PencilPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) { 
	  if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); 
	  %set = newObject("set",SimSet); 
	  %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$PencilBoxMaxLength,$PencilBoxMaxWidth,$PencilBoxMaxHeight,0); 
	  %num = CountObjects(%set,"DeployablePencil",%num); 
	  deleteObject(%set); 
	    if($MaxNumPencilInBox > %num) { 
		 if (%obj == "SimTerrain" || %obj == "InteriorShape" ) { 
		   %prot = GameBase::getRotation(%player); 
		   %zRot = getWord(%prot,2); 
			if (Vector::dot($los::normal,"0 0 1") > 0.6) { 
			%rot = "0 0 " @ %zRot; } 
			  else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
			  %rot = "3.14159 0 " @ %zRot; } 
				else { %rot = Vector::getRotation($los::normal); 
			} 
		} 
			if(checkDeployArea(%client,$los::position)) {
 			  %camera = newObject("Camera","Turret",DeployablePencil,true); 
			  addToSet("MissionCleanup", %camera); 
			  GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
			  GameBase::setRotation(%camera,%rot); 
			  GameBase::setPosition(%camera,$los::position); 
			  Gamebase::setMapName(%camera,"Rail Turret# "@ $totalNumPencil++ @ " " @ Client::getName(%client));
			  if(!$build)Client::sendMessage(%client,0,"Rail Turret deployed"); 
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a RAil Turret");
			  playSound(SoundPickupBackpack,$los::position); 
		//	Remote turrets - kill points to player that deploy them
		 Client::setOwnedObject(%client, %camera); 
		 Client::setOwnedObject(%client, %player);
			  $TeamItemCount[GameBase::getTeam(%camera) @ "PencilPack"]++;$PencilPack++; return true; } } 

		  else { if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); }
	 } 
		else{
			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other Rail Turrets in the area");
			}
		 } 
	  else { 	
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range"); } 
	} 
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false;
	 } 


TurretData DeployablePencil { className = "Turret"; 
	shapeFile = "camera";	projectileType = RailGunBullet; 
	maxDamage = 0.5; 
	maxEnergy = 60; 
	minGunEnergy = 1; 
	maxGunEnergy = 1; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.1; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 70; 
	visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; 
	castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; shieldShapeName = "shield"; 
	fireSound = ricochet3; 	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; 
	description = "[Rail Turret]"; 
	damageSkinData = "objectDamageSkins"; }; 

function DeployablePencil::onAdd(%this) { 
	schedule("DeployablePencil::deploy(" @ %this @ ");",1,%this); 	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0; 
		if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Pencil Turret"); } } 


function DeployablePencil::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployablePencil::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployablePencil::onDestroyed(%this) { 
	Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "PencilPack"]--; } 

function DeployablePencil::onPower(%this,%power,%generator) {} 

function DeployablePencil::onEnabled(%this) { GameBase::setRechargeRate(%this,5); 	GameBase::setActive(%this,true); } 


///-----------------------------------------------
ItemImageData PencilPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };



ItemData PencilPack { description = "[Laser Turret]"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
   heading = "h.:(Deployables):.";
	imageType = PencilPackImage; 
	shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 500; 
	hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function PencilPack::onUse(%player,%item) {
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 
	Player::mountItem(%player,%item,$BackpackSlot); } 
	else { Player::deployItem(%player,%item); } } 

function PencilPack::onDeploy(%player,%item,%pos) { 
	if (PencilPack::deployShape(%player,%item)&& !$build) { 
	Player::decItemCount(%player,%item); } 
	%client = Player::getClient(%player); 
	if(!$build && Client::isItemShoppingOn(%client,%item)) {  
		playNextAnim(%client); 
		Player::kill(%client); 
		centerprint(%client, "<jc><f1>No exploiting Inventories!!", 10);
		Client::sendMessage(%client,0,"No exploiting Inventories!!");  }
		 } 

//------------relocated here from game.cs 

$TeamItemMax[LaserPack] = 300;//large numbers mean large fun...

$MaxNumPencilInBox = 5;     //Number of remote turrets allowed in the area
$PencilBoxMaxLength = 50;    //Define Max Length of the area
$PencilBoxMaxWidth =  50;    //Define Max Width of the area
$PencilBoxMaxHeight = 15;    //Define Max Height of the area

//we dont care how close they're set, just how many in a given area
//------------

function PencilPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) { 
	  if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); 
	  %set = newObject("set",SimSet); 
	  %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$PencilBoxMaxLength,$PencilBoxMaxWidth,$PencilBoxMaxHeight,0); 
	  %num = CountObjects(%set,"DeployablePencil",%num); 
	  deleteObject(%set); 
	    if($MaxNumPencilInBox > %num) { 
		 if (%obj == "SimTerrain" || %obj == "InteriorShape" ) { 
		   %prot = GameBase::getRotation(%player); 
		   %zRot = getWord(%prot,2); 
			if (Vector::dot($los::normal,"0 0 1") > 0.6) { 
			%rot = "0 0 " @ %zRot; } 
			  else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
			  %rot = "3.14159 0 " @ %zRot; } 
				else { %rot = Vector::getRotation($los::normal); 
			} 
		} 
			if(checkDeployArea(%client,$los::position)) {
 			  %camera = newObject("Camera","Turret",DeployablePencil,true); 
			  addToSet("MissionCleanup", %camera); 
			  GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
			  GameBase::setRotation(%camera,%rot); 
			  GameBase::setPosition(%camera,$los::position); 
			  Gamebase::setMapName(%camera,"Laser Turret# "@ $totalNumPencil++ @ " " @ Client::getName(%client));
			  if(!$build)Client::sendMessage(%client,0,"Laser Turret deployed"); 
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Laser Turret");
			  playSound(SoundPickupBackpack,$los::position); 
		//	Remote turrets - kill points to player that deploy them
		 Client::setOwnedObject(%client, %camera); 
		 Client::setOwnedObject(%client, %player);
			  $TeamItemCount[GameBase::getTeam(%camera) @ "Laser Turret"]++;$PencilPack++; return true; } } 

		  else { if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); }
	 } 
		else{
			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other Laser Turrets in the area");
			}
		 } 
	  else { 	
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range"); } 
	} 
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false;
	 } 


TurretData DeployablePencil { className = "Turret"; 
	shapeFile = "camera";	projectileType =sniperLaser; 
 
	maxDamage = 0.5; 
	maxEnergy = 60; 
	minGunEnergy = 1; 
	maxGunEnergy = 1; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.1; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 70; 
	visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; 
	castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; shieldShapeName = "shield"; 
	fireSound = ricochet3; 	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; 
	description = "[Laser Turret]"; 
	damageSkinData = "objectDamageSkins"; }; 

function DeployablePencil::onAdd(%this) { 
	schedule("DeployablePencil::deploy(" @ %this @ ");",1,%this); 	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0; 
		if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Laser Turret"); } } 


function DeployablePencil::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployablePencil::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployablePencil::onDestroyed(%this) { 
	Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "PencilPack"]--; } 

function DeployablePencil::onPower(%this,%power,%generator) {} 

function DeployablePencil::onEnabled(%this) { GameBase::setRechargeRate(%this,5); 	GameBase::setActive(%this,true); }


///-----------------------------------------------
ItemImageData PencilPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };



ItemData PencilPack { description = "[Plasma Turret]"; 
	shapeFile = "camera"; 
	className = "Backpack"; 
   heading = "h.:(Deployables):.";
	imageType = PencilPackImage; 
	shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 500; 
	hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function PencilPack::onUse(%player,%item) {
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 
	Player::mountItem(%player,%item,$BackpackSlot); } 
	else { Player::deployItem(%player,%item); } } 

function PencilPack::onDeploy(%player,%item,%pos) { 
	if (PencilPack::deployShape(%player,%item)&& !$build) { 
	Player::decItemCount(%player,%item); } 
	%client = Player::getClient(%player); 
	if(!$build && Client::isItemShoppingOn(%client,%item)) {  
		playNextAnim(%client); 
		Player::kill(%client); 
		centerprint(%client, "<jc><f1>No exploiting Inventories!!", 10);
		Client::sendMessage(%client,0,"No exploiting Inventories!!");  }
		 } 

//------------relocated here from game.cs 

$TeamItemMax[LaserPack] = 300;//large numbers mean large fun...

$MaxNumPencilInBox = 5;     //Number of remote turrets allowed in the area
$PencilBoxMaxLength = 50;    //Define Max Length of the area
$PencilBoxMaxWidth =  50;    //Define Max Width of the area
$PencilBoxMaxHeight = 15;    //Define Max Height of the area

//we dont care how close they're set, just how many in a given area
//------------

function PencilPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) { 
	  if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); 
	  %set = newObject("set",SimSet); 
	  %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$PencilBoxMaxLength,$PencilBoxMaxWidth,$PencilBoxMaxHeight,0); 
	  %num = CountObjects(%set,"DeployablePencil",%num); 
	  deleteObject(%set); 
	    if($MaxNumPencilInBox > %num) { 
		 if (%obj == "SimTerrain" || %obj == "InteriorShape" ) { 
		   %prot = GameBase::getRotation(%player); 
		   %zRot = getWord(%prot,2); 
			if (Vector::dot($los::normal,"0 0 1") > 0.6) { 
			%rot = "0 0 " @ %zRot; } 
			  else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
			  %rot = "3.14159 0 " @ %zRot; } 
				else { %rot = Vector::getRotation($los::normal); 
			} 
		} 
			if(checkDeployArea(%client,$los::position)) {
 			  %camera = newObject("Camera","Turret",DeployablePencil,true); 
			  addToSet("MissionCleanup", %camera); 
			  GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
			  GameBase::setRotation(%camera,%rot); 
			  GameBase::setPosition(%camera,$los::position); 
			  Gamebase::setMapName(%camera,"Plasma Turret# "@ $totalNumPencil++ @ " " @ Client::getName(%client));
			  if(!$build)Client::sendMessage(%client,0,"Plasma Turret deployed"); 
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Plasma Turret");
			  playSound(SoundPickupBackpack,$los::position); 
		//	Remote turrets - kill points to player that deploy them
		 Client::setOwnedObject(%client, %camera); 
		 Client::setOwnedObject(%client, %player);
			  $TeamItemCount[GameBase::getTeam(%camera) @ "Plasma Turret"]++;$PencilPack++; return true; } } 

		  else { if ($build) Client::sendMessage(%client,0,"~waccess_denied.wav");
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); }
	 } 
		else{
			GameBase::playSound(%player, mine_act, 0);
			if (!$build) Client::sendMessage(%client,0,"Interference from other Plasma Turrets in the area");
			}
		 } 
	  else { 	
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Deploy position out of range"); } 
	} 
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false;
	 } 


TurretData DeployablePencil { className = "Turret"; 
	shapeFile = "camera";	projectileType =PlasmaBolt; 
 
	maxDamage = 0.5; 
	maxEnergy = 60; 
	minGunEnergy = 1; 
	maxGunEnergy = 1; 
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor }; 
	reloadDelay = 0.1; 
	speed = 4.0; 
	speedModifier = 1.5; 
	range = 70; 
	visibleToSensor = true; shadowDetailMask = 4; dopplerVelocity = 0; 
	castLOS = true; supression = false; mapFilter = 2; mapIcon = "M_turret"; 
	debrisId = flashDebrisMedium; shieldShapeName = "shield"; 
	fireSound = ricochet3; 	activationSound = SoundRemoteTurretOn; 
	deactivateSound = SoundRemoteTurretOff; explosionId = flashExpMedium; 
	description = "[Plasma Turret]"; 
	damageSkinData = "objectDamageSkins"; }; 

function DeployablePencil::onAdd(%this) { 
	schedule("DeployablePencil::deploy(" @ %this @ ");",1,%this); 	GameBase::setRechargeRate(%this,5); 
	%this.shieldStrength = 0; 
		if (GameBase::getMapName(%this) == "") { GameBase::setMapName (%this, "Plasma Turret"); } } 


function DeployablePencil::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); } 

function DeployablePencil::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); } 

function DeployablePencil::onDestroyed(%this) { 
	Turret::onDestroyed(%this); $TeamItemCount[GameBase::getTeam(%this) @ "PencilPack"]--; } 

function DeployablePencil::onPower(%this,%power,%generator) {} 

function DeployablePencil::onEnabled(%this) { GameBase::setRechargeRate(%this,5); 	GameBase::setActive(%this,true); }
///-----------------------------------------------


$TeamItemMax[door5x5pack] = 1000;

$ItemMax[larmor, door5x5pack] = 1;
$ItemMax[lfemale, door5x5pack] = 1;
$ItemMax[marmor, door5x5pack] = 1;
$ItemMax[mfemale, door5x5pack] = 1;
$ItemMax[harmor, door5x5pack] = 1;

///-----------------------------------------------

ItemImageData door5x5packImage
{
        //shapeFile = "forcefield_5x5";
        shapeFile = "armorkit";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.375, 0, 0 };
        mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData door5x5pack
{
        description = "[5x5 FFD]";
        //shapeFile = "forcefield_5x5";
        shapeFile = "armorkit";//
        className = "Backpack";
        heading = "h.:(Deployables):.";//        heading = "h.:(Deployables):.";
        imageType = door5x5packImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function door5x5pack::onUse(%player,%item)
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

function door5x5pack::onDeploy(%player,%item,%pos)
{
        if (door5x5pack::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function door5x5pack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("door5x5pack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"5x5 FFD#"@ $totalNumBlue++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"5x5 FFD deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "door5x5pack"]++;$blue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a 5x5 FFD");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Nope wrong asshole.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------


StaticShapeData doorfivebyfiveForceFieldShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";//
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "Blue Door";
};
function doorfivebyfiveForceFieldShape::Destruct(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
}
function doorfivebyfiveForceFieldShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}
function doorfivebyfiveForceFieldShape::onDestroyed(%this)
{
doorfivebyfiveForceFieldShape::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}
function doorfivebyfiveForceFieldShape::onCollision(%this,%obj)
{
if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam)
{
return;
}
doorfivebyfiveForceFieldShape::openDoor(%this);
return;
}
function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",4);
}
function doorfivebyfiveForceFieldShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function doorfivebyfiveForceFieldShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("doorfivebyfiveForceFieldShape::closeDoor("@%this@");",2);
}


///-----------------------------------------------


$ItemMax[larmor, door4x14pack] = 1;
$ItemMax[lfemale, door4x14pack] = 1;
$ItemMax[marmor, door4x14pack] = 1;
$ItemMax[mfemale, door4x14pack] = 1;
$ItemMax[harmor, door4x14pack] = 1;

$TeamItemMax[door4x14pack] = 1000;
///-----------------------------------------------


ItemImageData door4x14packImage
{
        //shapeFile = "forcefield_4x14";
        shapeFile = "ammo2";//AmmoPack
        mountPoint = 2;
        mountOffset = { -0.25, 0, 0 };
        mountRotation = { 1.57, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData door4x14pack
{
        description = "[4x14 FFD]";
        //shapeFile = "forcefield_4x14";
        shapeFile = "ammo2";//AmmoPack
        className = "Backpack";
        heading = "h.:(Depolyables):.";//          heading = "h.:(Deployables):."; 
        imageType = door4x14packImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function door4x14pack::onUse(%player,%item)
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

function door4x14pack::onDeploy(%player,%item,%pos)
{
        if (door4x14pack::deployShape(%player,%item) && !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function door4x14pack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("door4x14pack","StaticShape",BigBlueDoorShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"4x14 FFD#"@ $totalNumBigBlue++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"4x14 FFD deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "door4x14pack"]++;
						    $BigBlue++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a 4x14 FFD");
                                        return true;

                        }
                       else   {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Too far away.");

                        }

         }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}



StaticShapeData BigBlueDoorShape
{
className = "LargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_4x14";
maxDamage = 30.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
description = "[4x14 FFD]";
};

function BigBlueDoorShape::Destruct(%this)
      {BigBlueDoorShape::doDamage(%this);}

function BigBlueDoorShape::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100);
}

function BigBlueDoorShape::onDestroyed(%this)
{	BigBlueDoorShape::doDamage(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "LargeForceField"]--;
}

function BigBlueDoorShape::onCollision(%this,%obj)
{	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
	return;
}
		%c = Player::getClient(%obj);
		%playerTeam = GameBase::getTeam(%obj);
		%fieldTeam = GameBase::getTeam(%this);
		if(%fieldTeam != %playerTeam)
		{return;}
			BigBlueDoorShape::openDoor(%this);return;
}

function BigBlueDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BigBlueDoorShape::closeDoor("@%this@");",4);
}

function BigBlueDoorShape::closeDoor(%this) {
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -6");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);

}

function BigBlueDoorShape::openDoor(%this) {

GameBase::startfadeout(%this);

%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 6");
GameBase::setPosition(%this,%pos);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
schedule("BigBlueDoorShape::closeDoor("@%this@");",2);
}


///-----------------------------------------------

$ItemMax[harmor, BlastWall] = 1;
$ItemMax[larmor, BlastWall] = 1;
$ItemMax[lfemale, BlastWall] = 1;
$ItemMax[marmor, BlastWall] = 1;
$ItemMax[mfemale, BlastWall] = 1;

///-----------------------------------------------

$TeamItemMax[BlastWall] = 200;

ItemImageData BlastWallImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastWall
{
        description = "[Blast Wall]";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
        heading = "h.:]Deployables[:.";//h.:]Deployables[:.";
        imageType = BlastWallImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWall::onUse(%player,%item)
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

function BlastWall::onDeploy(%player,%item,%pos)
{
        if (BlastWall::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastWall::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Wall#"@ $totalNumBlast++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Wall deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "BlastWall"]++;$blast++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Blast wall");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData BlastWallShape
{
        shapeFile = "newdoor5";
        debrisId = defaultDebrisLarge;
        maxDamage = 60.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Portable Wall";
};

function BlastWallShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "BlastWall"]--;

}

///-----------------------------------------------



///-----------------------------------------------
$ItemMax[harmor, Tree] = 1;
$ItemMax[larmor, Tree] = 1;
$ItemMax[lfemale, Tree] = 1;
$ItemMax[marmor, Tree] = 1;
$ItemMax[mfemale, Tree] = 1;

///-----------------------------------------------

$TeamItemMax[Tree] = 200;

ItemImageData TreeImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData Tree
{
        description = "[Tree Pack]";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
        heading = "h.:(Deployables):.";//h.:(Deployables):.";
        imageType = TreeImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 250;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWall::onUse(%player,%item)
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

function Tree::onDeploy(%player,%item,%pos)
{
        if (BlastWall::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function Tree::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("Tree","StaticShape",TreeShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Tree#"@ $totalNumBlast++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Tree deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "Tree"]++;$blast++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Tree");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData TreeShape
{
        shapeFile = "Tree1";
        debrisId = defaultDebrisLarge;
        maxDamage = 60.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Portable Wall";
};

function TreeShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "Tree"]--;

}
///-----------------------------------------------



$ItemMax[harmor, plat] = 1;
$ItemMax[larmor, plat] = 1;
$ItemMax[lfemale, plat] = 1;
$ItemMax[marmor, plat] = 1;
$ItemMax[mfemale, plat] = 1;

///-----------------------------------------------

$TeamItemMax[plat] = 2000;

ItemImageData platImage
{
        shapeFile = "AmmoPack";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData plat
{
        description = "[Sonic Floor]";
        shapeFile = "AmmoPack";//newdoor5
        className = "Backpack";
         heading = "h.:(Deployables):.";//       heading = "h.:(Deployables):.";
        imageType = platImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function plat::onUse(%player,%item)
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

function plat::onDeploy(%player,%item,%pos)
{
        if (plat::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}

function plat::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                                %prot = GameBase::getRotation(%player);
					  %xRot = getWord(%prot,0);
					  %yRot = getWord(%prot,1);
					  %zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						%rot = GameBase::getRotation(%player);//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot =  %xRot + 3.14159@" " @%yRot@" "@%zRot;//ceiling...
					}
					else {
						%rot = GameBase::getRotation(%player);//other
					}
				}

                                        %camera = newObject("plat","StaticShape",platShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Sonic Floor#"@ $totalNumPlat++ @ " " @ Client::getName(%client));
                                        if(!$build)Client::sendMessage(%client,0,"Sonic Floor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "plat"]++;$Plat++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Sonic Floor");
                                        return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData platShape
{
        shapeFile = "elevator6X6thin";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = defaultDebrisLarge;
        maxDamage = 25.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "[Sonic Floor]";
};

function platShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "plat"]--;

}

///-----------------------------------------------

//Origional 
///-----------------------------------------------
///-----------------------------------------------


$ItemMax[harmor, Twig] = 1;
$ItemMax[larmor, Twig] = 1;
$ItemMax[lfemale, Twig] = 1;
$ItemMax[marmor, Twig] = 1;
$ItemMax[mfemale, Twig] = 1;



$SellAmmo[Seed] = 5;
$AmmoPackMax[Seed] = 20;
$AmmoPackItems[10] = Seed;
$WeaponAmmo[JumpGun] = Seed;

$ItemMax[larmor, Seed] = 10;
$ItemMax[lfemale, Seed] = 10;
$ItemMax[marmor, Seed] = 5;
$ItemMax[mfemale, Seed] = 5;
$ItemMax[harmor, Seed] = 1;

///-----------------------------------------------

$TeamItemMax[Twig] = 1000;

ItemImageData TwigImage
{
        shapeFile = "flag";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData Twig
{
        description = "Touch Explosives";
        shapeFile = "Flag";//newdoor5
        className = "Backpack";
        heading = "i.:]Miscellany[:.";//        heading = "i.:(Miscellany):.";
        imageType = TwigImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

ItemData Seed
{
	description = "[XxX]";
	className = "Ammo";
	shapeFile = "mortarammo";//mortarammo,endarrow,endarrow
   heading = "x.:]Ammo[:.";
	shadowDetailMask = 4;
	price = 2;
};



function Twig::onMount(%player,%item){
		%client = Player::getClient(%player);
		%AmmoCount = (Player::getItemCount(%player,Seed));
		if(%AmmoCount == 0 && Client::isItemShoppingOn(%client,%item)){	

		buyItem(%client,Seed);
		//Client::sendMessage(%client,0,"Auto buying C-4");
		}
	}



function Twig::onUse(%player,%item)
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

function Twig::onDeploy(%player,%item,%pos)
{
        if (Twig::deployShape(%player,%item))
        {
	%AmmoCount = ( Player::getItemCount(%player,Seed)) ;
	if(%AmmoCount)Player::decItemCount(%player,Seed);

	else Player::decItemCount(%player,%item);
        }
}
function Twig::deployShape(%player,%item)
{
      %client = Player::getClient(%player);
	%AmmoCount = ( Player::getItemCount(%player,Seed)+1) ;
	if(%AmmoCount){
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
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
	                  %camera = newObject("Twig","StaticShape",TwigShape,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
                              Gamebase::setMapName(%camera,"Touch Explosive#"@ $totalNumTwig++ @ " " @ Client::getName(%client));
					if(!$build)Client::sendMessage(%client,0,"Touch Explosive Set");
					playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "Twig"]++;$Twig++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed Touch Explosive ");
					return true;

                        }
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}}

StaticShapeData TwigShape
{
        shapeFile = "flag";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = flashDebrisLarge;//defaultDebrisLarge
        maxDamage = 5.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Touch Explosives";
};




function TwigShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "Touch Explosive"]--;

}

function TwigShape::onCollision(%this,%obj){
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%TwigTeam = GameBase::getTeam(%this);
		if(%TwigTeam != %playerTeam){
		%dlevel = GameBase::getDamageLevel(%obj) + 0.2;
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		GameBase::setDamageLevel(%obj, %dlevel); 
		Player::setDamageFlash(%obj,0.5);
	if(Player::isDead(%obj)){
		%name = Client::getName(%c); 
		Messageall(0,%name@" Fall for someones fake flag gag."); 
 		playNextAnim(%obj); 
		//Player::blowUp(%obj); 
		//Player::kill(%obj); 
	}
		return;
		}
	TwigShape::openDoor(%this);
	client::sendmessage(%c, 0, "~wmale1.wdsgst4.wav"); 
	return;
	}


function TwigShape::openDoor(%this) {

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -2");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
	schedule("TwigShape::closeDoor("@%this@");",1);
	}

function TwigShape::closeDoor(%this) {
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 2");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
	}



//should of been added by dynamix a LONG time ago
//unrelated to twig
function CargoBarrel::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}

function CargoCrate::onDestroyed(%this)
{
schedule("deleteobject(" @ %this @ ");", 2);
}   


///-----------------------------------------------


///-----------------------------------------------



$ItemMax[harmor, Girl] = 1;
$ItemMax[larmor, Girl] = 1;
$ItemMax[lfemale, Girl] = 1;
$ItemMax[marmor, Girl] = 1;
$ItemMax[mfemale, Girl] = 1;

///-----------------------------------------------

$TeamItemMax[Girl] = 1000;

ItemImageData GirlImage
{
        shapeFile = "harmor";//newdoor5
        mountPoint = 0;
        
        mass = 1.5;
        firstPerson = false;
};

ItemData Girl
{
        description = "[Hologram]";
        shapeFile = "harmor";//newdoor5
        className = "Backpack";
        heading = "h.:(Deployables):.";//        heading = "h.:(Deployables):.";
        imageType = GirlImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 25;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function Girl::onUse(%player,%item)
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

function Girl::onDeploy(%player,%item,%pos)
{
        if (Girl::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}
function Girl::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
					%xpos = getWord($los::position,0);
					%ypos = getWord($los::position,1);
					%zpos = getWord($los::position,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot + 3.14159;%zpos += 1.1;//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;%zpos -= 1.1;//ceiling
					}
					else {
						%rot = Vector::getRotation($los::normal);//other
					}
				}

	                  %camera = newObject("Girl","StaticShape",GirlShape,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);				
					GameBase::setPosition(%camera,%xpos@" "@%ypos@" "@%zpos);
                              Gamebase::setMapName(%camera,"Hologram# "@ $totalNumGirl++ @ " " @ Client::getName(%client));
					if(!$build)Client::sendMessage(%client,0,"Hologram set");
					playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "Hologram"]++;$Girl++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Hologram");
					return true;
					}
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData GirlShape
{
        shapeFile = "harmor";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = defaultDebrisLarge;
        maxDamage = 20.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "[Hologram]";
};




function GirlShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "Girl"]--;

}

function GirlShape::onCollision(%this,%obj){
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%GirlTeam = GameBase::getTeam(%this);
		if(%GirlTeam != %playerTeam){
			return;
		}
	GirlShape::openDoor(%this);
	client::sendmessage(%c, 0, "~wmale1.whello.wav");
	schedule("Client::sendMessage("@%c@", 0,\"~wmale1.wbye.wav\");", 0.50);
	return;
	}


function GirlShape::openDoor(%this) {

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 4");
	GameBase::setPosition(%this,%pos);
	//schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
	schedule("GirlShape::closeDoor("@%this@");",1);
	}

function GirlShape::closeDoor(%this) {
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -4");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);

	}



//----------------------------------------------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "rocket";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -3;
 	maxEnergy = -5;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "[Energy Pack]";
	shapeFile = "rocket";
	className = "Backpack";
   heading = "g.:]Backpacks[:.";
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
	description = "[Repair Pack]";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "g.:(Backpacks):.";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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
	description = "[Shield Pack]";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "g.:(Backpacks):.";
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
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "[Sneak Pack]";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "g.:(Backpacks):.";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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
	description = "[Motion Sensor]";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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

ItemData AmmoPack
{
	description = "[Ammo Pack]";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "g.:(Backpacks):.";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 7 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
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
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
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
	description = "[Pulse Sensor]";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "h.:]Deployables[:.";
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
	description = "[Sensor Jammer]";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "h.:(Deployables):.";
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
	description = "[Spy Camera]";
	shapeFile = "camera";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Blaster Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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

//----------------------------------------------------

ItemImageData TurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "[RPT Turret]";
	shapeFile = "camera";
	className = "Backpack";
   heading = "h.:(Deployables):.";
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


//----------------------------------------------------------------------------
																			
ItemImageData BazookaPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BazookaPack
{
	description = "[Hell Fire Turret]";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "h.:(Deployables):.";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BazookaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BazookaPack::onDeploy(%player,%item,%pos)
{
	if (BazookaPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BazookaPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"Hell Fire Turret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"Hell Fire Turret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%bazookaturret = newObject("mortar_turret","Turret",BazookaTurret,true);
	                     addToSet("MissionCleanup", %bazookaturret);
								GameBase::setTeam(%bazookaturret,GameBase::getTeam(%player));
								GameBase::setPosition(%bazookaturret,$los::position);
								GameBase::setRotation(%bazookaturret,%rot);
								Gamebase::setMapName(%bazookaturret,"Hell Fire Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Hell Fire Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "BazookaPack"]++;
								echo("MSG: ",%client," deployed a Hell Fire Turret");
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
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other installations in the area");
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
   heading = "i.:]Miscellany[:.";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "i.:]Miscellany[:.";
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
   heading = "iMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
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
   heading = "iMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
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
   heading = "iMiscellany";
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
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ BomberVehicle] = 0;
	$TeamItemCount[0 @ SR71Vehicle] = 0;
	$TeamItemCount[0 @ EnterpriseVehicle] = 0;
	$TeamItemCount[0 @ WarthogVehicle] = 0;
	$TeamItemCount[0 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[0 @ ColossusVehicle] = 0;
	$TeamItemCount[0 @ ArwingVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;
	$TeamItemCount[0 @ Thermonuclear] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ SR71Vehicle] = 0;
	$TeamItemCount[1 @ WarthogVehicle] = 0;
	$TeamItemCount[1 @ EnterpriseVehicle] = 0;
	$TeamItemCount[1 @ BomberVehicle] = 0;
	$TeamItemCount[1 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[1 @ ColossusVehicle] = 0;
	$TeamItemCount[1 @ ArwingVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;
	$TeamItemCount[1 @ Thermonuclear] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ SR71Vehicle] = 0;
	$TeamItemCount[2 @ WarthogVehicle] = 0;
	$TeamItemCount[2 @ EnterpriseVehicle] = 0;
	$TeamItemCount[2 @ BomberVehicle] = 0;
	$TeamItemCount[2 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[2 @ ColossusVehicle] = 0;
	$TeamItemCount[2 @ ArwingVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;
	$TeamItemCount[2 @ Thermonuclear] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ SR71Vehicle] = 0;
	$TeamItemCount[3 @ WarthogVehicle] = 0;
	$TeamItemCount[3 @ EnterpriseVehicle] = 0;
	$TeamItemCount[3 @ BomberVehicle] = 0;
	$TeamItemCount[3 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[3 @ ColossusVehicle] = 0;
	$TeamItemCount[3 @ ArwingVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;
	$TeamItemCount[3 @ Thermonuclear] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ SR71Vehicle] = 0;
	$TeamItemCount[4 @ WarthogVehicle] = 0;
	$TeamItemCount[4 @ EnterpriseVehicle] = 0;
	$TeamItemCount[4 @ BomberVehicle] = 0;
	$TeamItemCount[4 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[4 @ ColossusVehicle] = 0;
	$TeamItemCount[4 @ ArwingVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;
	$TeamItemCount[4 @ Thermonuclear] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ SR71Vehicle] = 0;
	$TeamItemCount[5 @ WarthogVehicle] = 0;
	$TeamItemCount[5 @ EnterpriseVehicle] = 0;
	$TeamItemCount[5 @ BomberVehicle] = 0;
	$TeamItemCount[5 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[5 @ ColossusVehicle] = 0;
	$TeamItemCount[5 @ ArwingVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;
	$TeamItemCount[5 @ Thermonuclear] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ SR71Vehicle] = 0;
	$TeamItemCount[6 @ WarthogVehicle] = 0;
	$TeamItemCount[6 @ EnterpriseVehicle] = 0;
	$TeamItemCount[6 @ BomberVehicle] = 0;
	$TeamItemCount[6 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[6 @ ColossusVehicle] = 0;
	$TeamItemCount[6 @ ArwingVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;
	$TeamItemCount[6 @ Thermonuclear] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ SR71Vehicle] = 0;
	$TeamItemCount[7 @ WarthogVehicle] = 0;
	$TeamItemCount[7 @ EnterpriseVehicle] = 0;
	$TeamItemCount[7 @ BomberVehicle] = 0;
	$TeamItemCount[7 @ SpeedBikeVehicle] = 0;
	$TeamItemCount[7 @ ColossusVehicle] = 0;
	$TeamItemCount[7 @ ArwingVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
	$TeamItemCount[7 @ Thermonuclear] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

/*
function RechargeAmmo(%player,%gunType)
{
	echo("Recharging ammo");
	%armor = Player::GetArmor(%player);
	if(%gunType == PulsePhaser && (Player::getItemCount(%player,PulsePhaser) > 0))
	{
		if(Player::getItemCount(%player,PulsePhaserAmmo) < $ItemMax[%armor,PulsePhaserAmmo])
		{
			Player::incItemCount(%player,PulsePhaser,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",1.0,%player);
		}
		else
			$PulsePhaserRecharging[%player] = False;
	}
}
echo("SWORD: rechargeammo passed");
*/

//from Havoc mod
function dropClusters(%this, %count) {
	if(%count && %this) {
		%obj = newObject("","HandGrenade","Clus");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 15, true);

		%obj = newObject("","HandGrenade","Clus");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 10, true);

		%obj = newObject("","HandGrenade","Clus");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 12, true);

		%obj = newObject("","Handgrenade","Clus");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj, %this, 1, true);

		%count--;
		schedule("dropClusters(" @ %this @ " , " @ %count @ ");",0.4,%this);
		return;
	} else
		$SClu = false;
}

//from Talon mod

/*
function BlastRifleImage::onFire(%player,%slot)
{
	%rawCharge = Player::getItemCount(%player,BlastAmmo);
	%charge = %rawCharge *= 0.2;
	if(%charge > 0)
	{
		for(%i=1; %i<%charge; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BlastShell",%trans,%player,%vel);
		}
		Player::setItemCount(%player,BlastAmmo,0);
		if($BlastRifleRecharging[%player] != True)
		{
			$BlastRifleRecharging[%player] = True;
			%guntype = BlastRifle;
			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.25,%player);
		}
	}
		else Client::sendMessage(Player::getClient(%player),0,"Pulse Phaser is out of ammo.");
}
*/
