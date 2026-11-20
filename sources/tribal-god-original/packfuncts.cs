//------------------------------------|
// Author: Whoever Made Vx5
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin8420@adelphia.net
// Aim: Dustin8420
//------------------------------------|

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player, $BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else
	{ Player::trigger(%player, $BackpackSlot); }
}

//========== Setup ItemMax ==========//
ItemMax(SensorJammerPack, 1, 1, 1, 1, 0);
ItemMax(CloakingDevice, 1, 1, 1, 1, 0);
ItemMax(ChameleonPack , 1, 1, 1, 1, 1);
ItemMax(BorgDevice    , 0, 0, 1, 1, 1);
ItemMax(AdminPack     , 1, 1, 1, 1, 1);
ItemMax(EnergyPack    , 1, 1, 1, 1, 1);
ItemMax(HackPack      , 0, 0, 1, 1, 0);
ItemMax(HiderPack     , 1, 1, 1, 1, 0);
ItemMax(RepairPack    , 1, 1, 1, 1, 1);
ItemMax(ShieldPack    , 1, 1, 1, 1, 1);
ItemMax(SuicidePack   , 1, 1, 1, 1, 1);
ItemMax(AmmoPack      , 0, 0, 1, 1, 1);
//===================================//


//========== Setup InvList ==========//
AddToInv(SensorJammerPack, 1, 1);
AddToInv(CloakingDevice, 1, 1);
AddToInv(ChameleonPack, 0, 0);
AddToInv(SuicidePack, 1, 1);
AddToInv(BorgDevice, 1, 1);
AddToInv(EnergyPack, 1, 1);
AddToInv(RepairPack, 1, 1);
AddToInv(ShieldPack, 1, 1);
AddToInv(AdminPack, 0, 0);
AddToInv(HiderPack, 1, 0);
AddToInv(HackPack, 1, 0);
AddToInv(AmmoPack, 1, 1);
//===================================//