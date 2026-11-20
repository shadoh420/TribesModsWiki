//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

// type = weapon type, 0 single, 1 rotating, 2 sustained, 3disc
// icon = HudIcon, deployable, ammopack, shieldpack, sensorjamerpack, energypack, repairpack, plasma, blaster
//                targetlaser, disk, weapon, sniper, grenade, energyrifle, mortar, fear, reticle, clock, chain

function Pack::Define(%name,%shape,%description,%price,%icon,%min,%max,%type,%active,%reload,%ready,%fire)
{
	%ImageData = "ItemImageData "@ %name@"Image"@	
		" { "@
			"shapeFile = \""@%shape@"\";"@
			"mountPoint = 2;"@	
			"weaponType = "@%type@";"@
			"minEnergy = "@%min@";"@
			"maxEnergy = "@%max@";"@
			"firstPerson = false;"@
		" };"; 	
	eval(%ImageData); 
	
	//define other stuff that will break the image if false... -Plasmatic
	%Image = %name@"Image";
	if(%active)%Image.sfxActivate = %active;
	if(%reload)%Image.sfxReload = %reload;
	if(%ready)%Image.sfxReady = %ready;
	if(fire)%Image.sfxFire = %fire;

	%Data = 	"ItemData "@ %name@
		" { "@	
			"description = \""@%description@"\";"@
			"shapeFile = \""@%shape@"\";"@
			"className = \"Backpack\";"@
			"heading = "@$InvHead[ihBac]@";"@
			"shadowDetailMask = 4;"@
			"imageType = "@%name@"Image;"@
			"price = "@%price@";"@
			"showWeaponBar = true;"@
			"hudIcon = "@%icon@";"@
			"hiliteOnActive = true;"@
		"};"; 	
	eval(%Data);
}
	
	
	
	

// defining a parent class function for this to eliminate some other functions. -Plasmatic
function Backpack::onUse(%player,%item)
{
	if($debug)
		echo("Backpack::onUse "@%item@", deployable ="@$TeamItemMax[%item]);
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		//plasmatic
		if(!Client::isItemShoppingOn(%client,%item) || $build || $Annihilation::QuickInv) 
		{  	
			// If theres a team max, chances are its a deployable.. -Plasmatic 3.0
			if($TeamItemMax[%item])
			{
				// Ok, old method for deployable, on backpack use, we:
				// call this function, which calls blah::onuse, which 
				// in turn calls blah::ondeploy that in turn actually deploys the thing..
				// we're eliminating 2 redundant functions here...
				// ::onuse and ::ondeploy, of course these may be overwritten by ::onuse -Plasmatic
				
				//Player::deployItem(%player,%item);	lets kill 2 functions at once.. -Plasmatic
				if (eval(%item@"::deployShape("@%player@","@%item@");") && !$build)
					Player::decItemCount(%player,%item);	//success!!
						
			}
			else
			{
				//echo("Trigger "@%item);
				Player::trigger(%player,$BackpackSlot);
			}
		}
		else Client::sendMessage(%client,0,"~waccess_denied.wav");
	}
}
//	function BackPack::onUse(%player,%item)
//	{
//		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
//			Player::mountItem(%player,%item,$BackpackSlot);
//		else
//			Player::deployItem(%player,%item);
//	}