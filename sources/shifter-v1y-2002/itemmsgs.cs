function Blaster::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Blaster", 2);
}

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
	if($Shifter::DeathMatch != "true")
	        bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
	else
		bottomprint(Player::getClient(%player), "<jc><f2>Using Chaingun", 2);
}

function LasCannon::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Cannon", 2);
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


function GrenadeLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Grenade Launcher", 2);
}

function LaserRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Rifle", 2);
}

function EnergyRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using ELF Gun", 2);
}

function Mortar::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.mortar || %client.rocket == 0)
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
}

function TargetingLaser::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Targeting Laser", 2);
}

function HyperB::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Hyper Blaster", 2);
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

function SniperRifle::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Sniper Rifle", 2);
}

function Equalizer::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Equalizer", 2);
}

function BoomStick::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Boom Stick", 2);
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

function Silencer::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Magnum", 2);
}

function ConCun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Shockwave Cannon", 2);
}

function Railgun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Railgun", 2);
}

function Vulcan::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Vulcan", 2);
}

function Flamer::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Flame Thrower", 2);
}

function IonGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Ion Rifle", 2);
}

function Volter::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Volter", 2);
}

function GravGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%msg = "<jc><f2>Using Grav Gun -";
	%client = Player::getClient(%player);
	if(%client.GravADV != 0)
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

function FixIt::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Repair-Gun", 2);
}

function Hackit::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Hack-Gun", 2);
}

function DisIt::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Disassymbler", 2);
}

function FlareGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Flare Gun", 2);
}

function FusionGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Fusion Blaster", 2);
}

function ClusterBomb::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Particle Accelerator", 2);
}

function MineLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Mine Launcher", 2);
}

function PlasmaCannon::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon", 2);
}

function Jailgun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Jailer's Gun", 2);
}

function Concuss::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Chaos Gun", 2);
}

function Cloaker::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Handheld Cloak", 2);
}

function Shotgun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Shotgun", 2);
}

function MegaDiscLauncher::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Mega-Disc Launcher", 2);
}

function Boomer::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Using Boomer", 2);
}
