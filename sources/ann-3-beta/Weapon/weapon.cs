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
	if(%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	
	if(%player.Station=="")
	{
		%ammo = %item.imageType.ammoType;
		if(%ammo == "") 
		{
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else 
		{
			if(Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else 
				Client::sendMessage(Player::getClient(%player),0,%item.description@" has no ammo");
			
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

// function by Plasmatic -2.2 
// delays mount of extra weapon shapes untill origional shape completely mounts.
// fix to syncronise weapon mount while reloading or firing prev. weapon. // 2.3 Plasmatic
// Using this for weapon help now too. -Plas 3.0

// Remember kiddies. This function is called for ALL weapon type items by:
// function Item::onMount(%player,%item) in item.cs
// This function may cause problems if the second item mounted is also a weapon type.
// set $Console::LogMode = "1"; and $Console::printLevel = "2"; somewhere to check for redundant retardedness.
// -Plasmatic, Vengeance mod

function Weapon::CompleteMount(%player,%weapon)
{
	if(!Player::isDead(%player)) 
	{
		%client = Player::getclient(%player);
		%mounted = Player::getMountedItem(%client,$WeaponSlot);
		
//	echo("Weapon::CompleteMount P"@%player@", W"@%weapon@", M"@%mounted);
		
		if(%mounted  == %weapon)	
			eval(%weapon @ "::MountExtras("@%player@","@%weapon@");");	
		else
		{
			//sigh, lets double check anyhow.. -Plasmatic
			%check = false;
			for(%i = 4; %i<8; %i++)
			{
				%w = Player::getMountedItem(%player,%i);
				if(%w == %weapon)
					%check = true;
			}			
			if(!%check)
				schedule("Weapon::CompleteMount("@%player@","@%weapon@");",0.25);
		}
	}
}


// uses the default use blaster and use laser rifle buttons to cycle weapon modes	-plasmatic
function Weapon::Mode(%player,%rotate)
{
	%client = Player::getClient(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	
	if($debug)	
		echo(%client@": change weap options "@%weapon);
		
	if(%weapon == grenadelauncher)
	{
		%mode = %client.MiniMode += %rotate; 
		
		if(%mode >3) %mode = 0;
		else if (%mode <0) %mode = 3;
		%client.MiniMode = %mode;

		Client::sendMessage(%client, 0, "~wturreton1.wav");		
		if(%client.MiniMode == 1)
			bottomprint(%client, "<jc>Mini Bomber: <f2>SINGLE <f2>Grenade Projectile", 2);
		else if(%client.MiniMode == 0)
			bottomprint(%client, "<jc>Mini Bomber: <f2>TRIPLE <f2>Grenade Projectile", 2);
		else if(%client.MiniMode == 2)
			bottomprint(%client, "<jc>Mini Bomber: <f2>MINE dropper<f2> Projectile", 2);
		else if(%client.MiniMode == 3)
			bottomprint(%client, "<jc>Mini Bomber: <f2>Starburst MINE <f2>Projectile", 2);
		return;
	}
	else if(%weapon == Vulcan)
	{
		%mode = %client.Vulcan += %rotate;

		if(%mode > 1) %mode = 0;
		else if (%mode < 0) %mode = 1;
		%client.Vulcan = %mode;	
		
		Client::sendMessage(%client, 0, "~wturreton1.wav");	
		if (!%client.Vulcan || %client.Vulcan == 0)
			bottomprint(%client, "<jc>Vulcan:<f2> Standard Chaingun Rounds", 2);
		if (%client.Vulcan == 1)
			bottomprint(%client, "<jc>Vulcan:<f2> Fiery Vulcan Rounds", 2);
		return;
	}	
	else if(%weapon == ParticleBeamWeapon)
	{
		%mode = %client.pbeam += %rotate;

		if(%mode > 1) %mode = 0;
		else if (%mode < 0) %mode = 1;
		%client.pbeam = %mode;	
			
		Client::sendMessage(%client, 0, "~wturreton1.wav");
		if (%client.pbeam == 0)			
			bottomprint(%client, "<jc>ParticleBeamWeapon: <f2>Standard Beam.", 7);
		else if (%client.pbeam == 1)		
			bottomprint(%client,"<jc>ParticleBeamWeapon: <f2>Turret Killer mode. Hold fire to charge.", 7);
		return;
	}
	else if(%weapon == Slapper)
	{
		Slapper::Mode(%player,%rotate);
		return;
	}	
	else if(%weapon == grabbler && Player::isTriggered(%player,$WeaponSlot))
	{
		%object = %player.GrabObject;
		Player::trigger(%player,$WeaponSlot,false);
		
		schedule("grabbler::fire("@%player@","@%object@");",0.1);
		
		return;
	}	
	else if($build && (%weapon == CuttingLaser || %weapon == TargetingLaser))
	{
		%mode = %client.CuttingLaser += %rotate;

		if(%mode > 1) %mode = 0;
		else if (%mode < 0) %mode = 1;
		%client.CuttingLaser = %mode;	
			
		Client::sendMessage(%client, 0, "~wturreton1.wav");
		if(%client.CuttingLaser == 0)
		{		
			Player::mountItem(%player,TargetingLaser,0);
			bottomprint(%client, "<jc>Target Laser: <f2>Standard Beam.", 7);
		}
		else if(%client.CuttingLaser == 1)
		{	
			Player::mountItem(%player,CuttingLaser,0);	
			bottomprint(%client,"<jc>Target Laser: <f2>Cutting Laser, <f2>Watch your eyes.", 7);
		}
		return;
	}					
}

// ok, lets calculate a miss ratio for fakeys and players for the hell of it.. ;) -Plasmatic
function Weapon::MissPercentage(%player)
{
	%trans = GameBase::getMuzzleTransform(%player);	//position of tip
		%posX = getWord(%trans,9);		//x
		%posY = getWord(%trans,10);		//y
		%posZ = getWord(%trans,11); 		//z	
	//figure out general relativity, Einstein..
		%d1= getWord(%trans,3);
		%d2= getWord(%trans,4);
		%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas		
	//check fakey players...
	%simset = nameToID("MissionCleanup/HappyFakes");
	for(%i = 0; (%object = Group::getObject(%simset, %i)) != -1 ; %i++)
	{		
		//echo(getObjectType(%object));
		if(getObjectType(%object) == "Player")
		{
			%TargetPos = getBoxCenter(%object);
			%PlayerPos = %posX@" "@%posY@" "@%posZ;
			%TargetDist = vector::getdistance(%PlayerPos,%TargetPos);
			
			//%GunExtPos is like the end of a broom handle shoved down gun barrel.
			%GunExtPos = %posX + %d1 * %TargetDist@" "@%posY + %d2 * %TargetDist@" "@%posZ + %d3 * %TargetDist;
			%MissDist = vector::getdistance(%GunExtPos,%TargetPos);
			%MissPercent = %MissDist/%TargetDist;
			
			if(!%BestMissPercent)
				%BestMissPercent = %MissPercent;
			if(%BestMissPercent >= %MissPercent)
			{
				%BestMissPercent = %MissPercent;
				%ClosestTarget = %object;
				%BestMissDist = %MissDist;
				%fakeflag = true;
			}
		}
	}
	//check against real players..
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		//echo("client "@%cl);
		%object = Client::getOwnedObject(%cl);
		if(getObjectType(%object) == "Player")
		{
			//echo("checking clients");
			%TargetPos = getBoxCenter(%object);
			%PlayerPos = %posX@" "@%posY@" "@%posZ;
			%TargetDist = vector::getdistance(%PlayerPos,%TargetPos);
			
			//%GunExtPos is like the end of a broom handle shoved down gun barrel.
			%GunExtPos = %posX + %d1 * %TargetDist@" "@%posY + %d2 * %TargetDist@" "@%posZ + %d3 * %TargetDist;
			%MissDist = vector::getdistance(%GunExtPos,%TargetPos);
			%MissPercent = %MissDist/%TargetDist;
			
			if(!%BestMissPercent)
				%BestMissPercent = %MissPercent;
			if(%BestMissPercent >= %MissPercent)
			{
				%BestMissPercent = %MissPercent;
				%ClosestTarget = %object;
				%BestMissDist = %MissDist;
				%fakeflag = false;
			}
		}
	}	
	
	%playerName = Client::getName(gamebase::getownerclient(%ClosestTarget ));		//ai friendly..
	if((%BestMissPercent < 0.055 || %BestMissDist < 5) && %fakeflag)
		client::sendmessage(gamebase::getownerclient(%player ),1,floor((1-%BestMissPercent)*100)@"% "@%playerName@", "@%BestMissDist@"m");	
}
		
			

