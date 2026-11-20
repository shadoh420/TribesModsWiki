//=====================================================================
// itemmsgs.cs -- Item Messages
// This file now only contains messages for multi-mode items.  All
// other items/tools/weapons send messages via the default
// Weapon::onUse() call. -- Y|yukichigai
//=====================================================================

function PlasmaGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.Plasma || %client.rocket == 0)
	{
	        bottomprint(%client, "<jc><f2>Using Plasma Gun - Standard", 2);
	}
	if (%client.Plasma == 1)
	{
	        bottomprint(%client, "<jc><f2>Using Plasma Gun - Rapid Fire", 2);
	}
	if (%client.Plasma == 2)
	{
	        bottomprint(%client, "<jc><f2>Using Plasma Gun - Spread Fire", 2);
	}     
}


function Chaingun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
//	if($Shifter::DeathMatch != "true")
//	        bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
//	else
//		bottomprint(Player::getClient(%player), "<jc><f2>Using Chaingun", 2);
	%client = Player::getClient(%player);
	if(%client.Chaingun == 1)
		bottomprint(%client, "<jc><f2>Using Chaingun - Equalizer Mode", 2);
	else
		bottomprint(%client, "<jc><f2>Using Chaingun - Standard Mode", 2);
}

function DiscLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = Player::getClient(%player);
	if($Shifter::DiscOpts == "false")
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Disc Launcher", 2);
	else if(%client.Disc == 0 || !%client.Disc)
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Disc Launcher - Standard", 2);
	else if(%client.Disc == 1)
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Disc Launcher - Rapid Fire", 2);
}

function Mortar::onUse(%player,%item)
{
	//=== This will be modified later for possession and such
        Weapon::onUse(%player,%item);
	if(Player::isAIControlled(%player))
	{
		Player::unMountItem(%player,0);
		Player::mountItem(%player,Mortar0,0);
	}
	%client = GameBase::getOwnerClient(%player);
	if (!%client.mortar || %client.mortar == 0)
	{
	        bottomprint(%client, "<jc><f2>Using Mortar - Standard Shell", 2);
	}
	if (%client.mortar == 1)
	{
	        bottomprint(%client, "<jc><f2>Using Mortar - EMP Shell", 2);
	}
	if (%client.mortar == 2)
	{
	        bottomprint(%client, "<jc><f2>Using Mortar - Frag Shell", 2);
	}      
	if (%client.mortar == 3)
	{
	        bottomprint(%client, "<jc><f2>Using Mortar - MDM Shell", 2);
	}    
	if (%client.mortar == 4)
	{
	        bottomprint(%client, "<jc><f2>Using Mortar - Ice Shell", 2);
	}   
}

function RocketLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);

	//Lockjaw Projector
	Player::mountItem(%client,LJ,7);

	if (!%client.rocket || %client.rocket == 0)
	{
	        bottomprint(%client, "<jc><f2>Using Rocket Launcher - Stinger Mode", 2);
	}
	if (%client.rocket == 1)
	{
	        bottomprint(%client, "<jc><f2>Using Rocket Launcher - Locking Mode", 2);
	}
	if (%client.rocket == 2)
	{
		if($Shifter::HeatSeeker == "false" && $MatchConfig != "true")
		        bottomprint(%client, "<jc><f2>Using Rocket Launcher - Lock Jaw Mode", 2);
		else
			bottomprint(%client, "<jc><f2>Using Rocket Launcher - Heat Seeker Mode", 2);
	}
	if (%client.rocket == 3)
	{
	        bottomprint(%client, "<jc><f2>Using Rocket Launcher - WireGuided Mode", 2);
	}
}

function TranqGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = Player::getClient(%player);
	if(%client.Tranq == 0 || !%client.Tranq)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Dart Rifle - Poison Dart", 2);
		Player::mountItem(%player,TranqGun0,7);
	}
	else if(%client.Tranq == 1)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Dart Rifle - EMP Dart", 2);
		Player::mountItem(%player,TranqGun1,7);
	}
	else if(%client.Tranq == 2)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Dart Rifle - Flare Dart", 2);
		Player::mountItem(%player,TranqGun2,7);
	}
}

function GravGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%msg = "<jc><f2>Using Grav Gun -";
	%client = Player::getClient(%player);
	if(%client.GravADV != "0")
		%msg = %msg @ " Advanced (3d)";
	if(%client.GravBolt == 1)
		%msg = %msg @ " Repulse Mode";
	else if(%client.GravBolt == 2)
		%msg = %msg @ " Grapple Mode";
	else
		%msg = %msg @ " Tractor Mode";
//	bottomprint(Player::getClient(%player), "<jc><f2>Using Grav Gun", 2);
	bottomprint(%client,%msg,2);
}