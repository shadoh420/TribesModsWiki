function TargetingLaserImage::onFire(%player, %slot) 
{
	%client = player::getclient(%player);

	if (GameBase::getLOSInfo(%player,600) == false)
	{
		$LasTargets[%client] = 0;
		client::sendmessage(%client, 1, "Laser Target Out of Range!~waccess_denied.wav");
		return;
	}

	if (%client.LasMortar == 0) %dim = 5;
	else if (%client.LasMortar == 1) %dim = 1;
	else if (%client.LasMortar == 2) %dim = 15;
	else if (%client.LasMortar == 3) %dim = 10;

	if (LasCheckSky($los::position, %dim) > 0)
	{
		$LasTargets[%client] = 0;
		client::sendmessage(%client, 1, "Laser Target is Covered!~waccess_denied.wav");
		return;
	}

	$LasTargets[%client] = $los::position;

	if (%client.LasMortar == 0) {%time = 8; %client.LasMortar = 0;}	//Odd looking line of code, but if
	else if (%client.LasMortar == 1) %time = 6;			//you dont set it to 0, it assumes ""
	else if (%client.LasMortar == 2) %time = 10;			//which screws up the schedule
	else if (%client.LasMortar == 3) %time = 9;

	Projectile::spawnProjectile("LasMortarBolt", GameBase::getMuzzleTransform(%player),
		%player,Item::getVelocity(%player));

	playSound(SoundPackFail,gamebase::getposition(%player));
	GameBase::setEnergy(%player,0);

	schedule("LasCheckTarget("@%client@",1,"@%time@","@%client.LasMortar@");", 1);
}

function LasCheckTarget(%client, %count, %time, %type)
{
	%player = client::getownedobject(%client);

	if (GameBase::getLOSInfo(%player,600) == false)
	{
		$LasTargets[%client] = 0;
		client::sendmessage(%client, 1, "Laser Target Out of Range!~waccess_denied.wav");
		return;
	}

	if ($LasTargets[%client] == $los::position)
	{
		GameBase::setEnergy(%player,0);
		if (%count < %time)
		{
			Projectile::spawnProjectile("LasMortarBolt", GameBase::getMuzzleTransform(%player),
				%player,Item::getVelocity(%player));
			%count++;
			schedule("LasCheckTarget("@%client@","@%count@","@%time@","@%type@");", 1);
		}
		else
		{
			if (%type == 0) LasMortarFire($LasTargets[%client], %client);
			else if (%type == 1) LasIonFire($LasTargets[%client], %client);
			else if (%type == 2) LasAirFire($LasTargets[%client], %client);
			else if (%type == 3) LasFlameStrike($LasTargets[%client], %client);
			$LasTargets[%client] = 0;
		}
	}
	else
	{
		$LasTargets[%client] = 0;
		client::sendmessage(%client, 1, "Laser Target Lost!~waccess_denied.wav");
	}
}

function LasCheckSky(%pos, %dim)
{
	%x = getWord(%pos, 0);
	%y = getWord(%pos, 1);
	%z = getWord(%pos, 2) + 350;
	%pos = %x@" "@%y@" "@%z;

  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$SimInteriorObjectType,%pos,%dim,%dim,600,0); 
	deleteObject(%set);

	return %num;
}

function LasMortarFire(%pos, %client)
{
	%x = getword(%pos, 0);
	%y = getword(%pos, 1);
	%z = getword(%pos, 2);
	client::sendmessage(%client, 1, "Target Locked - Take Cover!~wmine_act.wav");

	Projectile::spawnProjectile("LasMortar", "1 0 0 0 1 0 0 0 1 "@%x+1@" "@%y@" "@%z+200, "", "0 0 0");
	Projectile::spawnProjectile("LasMortar", "1 0 0 0 1 0 0 0 1 "@%x-1@" "@%y+1@" "@%z+217, "", "0 0 0");
	Projectile::spawnProjectile("LasMortar", "1 0 0 0 1 0 0 0 1 "@%x@" "@%y-2@" "@%z+247, "", "0 0 0");
	Projectile::spawnProjectile("LasMortar", "1 0 0 0 1 0 0 0 1 "@%x-2@" "@%y+1@" "@%z+273, "", "0 0 0");
}

function LasIonFire(%pos, %client)
{
	%xy = getword(%pos, 0) @ " " @ getword(%pos, 1) @ " ";
	%z = getword(%pos, 2);
	client::sendmessage(%client, 1, "Target Locked - Ion Cannon Ready!~wmine_act.wav");

	schedule("LasIonSpawnRing(\"" @ %xy@(%z+35) @ "\");", 0.5);
	schedule("LasIonSpawnRing(\"" @ %xy@(%z+28) @ "\");", 0.56);
	schedule("LasIonSpawnRing(\"" @ %xy@(%z+21) @ "\");", 0.82);
	schedule("LasIonSpawnRing(\"" @ %xy@(%z+14) @ "\");", 0.98);
	schedule("LasIonSpawnRing(\"" @ %xy@(%z+7) @ "\");", 1.14);
	schedule("LasIonSpawnRing(\"" @ %xy@%z @ "\");", 1.4);
	schedule("LasIonSpawnProj(\""@%xy@(%z+30)@"\");", 1.4);
}

function LasIonSpawnProj(%pos, %client)
{
	Projectile::spawnProjectile("LasIonBolt","0 0 0 0 0 -1 0 0 0 "@%pos,"","0 0 0");
}

function LasIonSpawnRing(%pos)
{
	%obj = newObject("","Mine","IonRing");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, %pos);
}

function LasAirFire(%pos, %client)
{
	%x = getword(%pos, 0);
	%y = getword(%pos, 1);
	%z = getword(%pos, 2) + 220;
	client::sendmessage(%client, 1, "Target Locked - Bombs Away!~wmine_act.wav");

	LasAirSpawnMortar(%x@" "@%y+21@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y+14@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y+7@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y-7@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y-14@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x@" "@%y-21@" "@%z);

	%z += 70;
	LasAirSpawnMortar(%x+17@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x+10@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x+3@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x-3@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x-10@" "@%y@" "@%z);
	%z += 30;
	LasAirSpawnMortar(%x-17@" "@%y@" "@%z);
}

function LasAirSpawnMortar(%pos)
{
	Projectile::spawnProjectile("LasMortar","0 0 0 0 0 -1 0 0 0 "@%pos,"","0 0 0");
}

//function LasFlameStrike(%pos, %client)
//{
//	%x = getword(%pos, 0);
//	%y = getword(%pos, 1);
//	%z = getword(%pos, 2) + 180;
//	client::sendmessage(%client, 1, "Target Locked - Naplam Away!~wmine_act.wav");

//	for (%i=0; %i < 112; %i++)
//	{
//		%dx = floor(getRandom() * 42)-21;
//		%dy = floor(getRandom() * 42)-21;
//		Schedule("LasSpawnFlame(\""@%dx+%x@" "@%dy+%y@" "@%z@"\");", %i/4.5, %client);
//	}
//}

//function LasSpawnFlame(%pos)
//{
//	Projectile::spawnProjectile("FlameStrike","0 0 0 0 0 -1 0 0 0 "@%pos,"","0 0 0");
//}