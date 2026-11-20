//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[GhostPack] = 1;

$ItemMax[larmor, GhostPack] = 1;	//Seraph
$ItemMax[lfemale, GhostPack] = 1;	//Seraph
$ItemMax[earmor, GhostPack] = 0;	//Slave
$ItemMax[efemale, GhostPack] = 0;	//Slave
$ItemMax[marmor, GhostPack] = 0;	//Pawn
$ItemMax[aarmor, GhostPack] = 0;	//Navigator
$ItemMax[darmor, GhostPack] = 0;	//Atomizer
$ItemMax[barmor, GhostPack] = 0;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//Ghost Pack coding by Plasmatica ----- CHECK OUT SEX MOD!
//edited by Auto


ItemData GhostArmor
{
	heading = "aArmor";
        description = "Not of this World";
        className = "Armor";
        price = 175;
	showInventory = false;               
};


ItemImageData GhostPackImage
{
        shapeFile = "grenammo";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { 0.07, 0.1, 0 };
        mountRotation = { 0.7, 0, 0.65 };

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemImageData GhostPack2Image
{
        shapeFile = "grenammo";
        weaponType = 2; // Sustained

        mountPoint = 2;
        mountOffset = { -0.07, 0.1, 0 };
        mountRotation = { 0.7, 0, -0.65 };

        minEnergy = 2.5;
        maxEnergy = 2.5;
        firstPerson = false;
};

ItemData GhostPack
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPackImage;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

ItemData GhostPack2
{
        description = "Wraith Pack";
        shapeFile = "jetPack";
        className = "Backpack";
	heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = GhostPack2Image;
        price = 333;
        hudIcon = "energypack";
        showWeaponBar = false;
        hiliteOnActive = false;
        showInventory = false;   
};

$GhostPackSlotA=4;

function GhostPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}

function GhostPack::onMount(%player,%item)
{
        //%player.shieldStrength = -0.052;
	Player::mountItem(%player,GhostPack2,$GhostPackSlotA);
       // bottomprint(Player::getClient(%player), "<f1>Wraith Pack: <f2>**WARNING**<f0> Play nice Casper. <f2>**WARNING**<f1> ||BY Plasmatica||", 10);
}

function GhostPack::onUnmount(%player,%item)
{        
        Player::unmountItem(%player,$GhostPackSlotA);
        //%player.shieldStrength = 0.0;
}

function GhostPack::onUse(%player,%item)
{
%client = GameBase::getOwnerClient(%player);
if (Player::getMountedItem(%player,$BackpackSlot) != %item)
{
        Player::mountItem(%player,%item,$BackpackSlot);
         bottomprint(Player::getClient(%player), "<f1>Wraith Pack: <f2>**WARNING**<f0> Play nice Casper. <f2>**WARNING**<f1> ||BY Plasmatica||", 10);
}
else
{
	if (!%player.ghoster)
	{
		%player.ghoster = true;
		 Player::trigger(%player,$BackpackSlot,true);
                schedule("Casper(" @ %player @ ");", 1);
                Client::sendMessage(Player::getClient(%player), 1, "Wraith Pack Activated");
                %c = Player::getClient(%player);
                %armor = Player::getArmor(%client);
                %buyarmor = $ArmorType[Client::getGender(%client), GhostArmor];
                Player::setArmor(%client,%buyarmor);
                Player::setItemCount(%client, $ArmorName[%armor], 0);
                Player::setItemCount(%client, GhostArmor, 1);
        }
        else
        {
        	%player.Ghoster = false;
        	Player::trigger(%player,$BackpackSlot,false);
        	%c = Player::getClient(%player);
        	gamebase::setautorepairrate(client::getownedobject(%c), 0.0);
                Client::sendMessage(Player::getClient(%player), 1, "Wraith Pack Deactivated");
        	%armor = Player::getArmor(%client);
      		%buyarmor = $ArmorType[Client::getGender(%client), lightArmor];
        	Player::setArmor(%client,%buyarmor);
        	Player::setItemCount(%client, $ArmorName[%armor], 0);
        	Player::setItemCount(%client, lightArmor, 1); 
        }
}
}


function Casper (%player)
{
	if (%player.ghoster)
	{
		Player::setDamageFlash(%player,0.2);
                %c = Player::getClient(%player);
                %name = Client::getName(%c);
                %dlevel = GameBase::getDamageLevel(%player) + 0.03;
                GameBase::setDamageLevel(%player,%dlevel);
                if(Player::isDead(%player))
                {
                	//GameBase::setPosition(%client,"0 0 10000");
                	Messageall(0,%name@" is truly a ghost now");
                	playNextAnim(%player);
                	%player.Ghoster = false;
                }
                schedule("Casper(" @ %player @ ");", 1);
	}
}

//-----------------------