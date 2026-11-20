$InvList[SAMgun] = 1;
$InvList[SAMAmmo] = 1;
$RemoteInvList[SAMgun] = 1;
$RemoteInvList[SAMAmmo] = 1;

$WeaponAmmo[SAMgun] = SAMammo;
$SellAmmo[SAMAmmo] = 1;
$AmmoPackMax[SAMAmmo] = 1;
$AmmoPackItems[17] = SAMAmmo;
$AutoUse[SAMgun] = True;


$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = SAMgun;
$NextWeapon[SAMgun] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = SAMgun;
$PrevWeapon[SAMgun] = $temp;

$temp = "";

$ItemMax[marmor, SAMgun] = 1;
$ItemMax[marmor, SAMAmmo] = 3;
$ItemMax[mfemale, SAMgun] = 1;
$ItemMax[mfemale, SAMAmmo] = 3;

$ItemMax[earmor, SAMgun] = 1;
$ItemMax[earmor, SAMAmmo] = 4;
$ItemMax[efemale, SAMgun] = 1;
$ItemMax[efemale, SAMAmmo] = 4;

$ItemMax[darmor, SAMgun] = 1;
$ItemMax[darmor, SAMAmmo] = 4;

$ItemMax[harmor, SAMgun] = 1;
$ItemMax[harmor, SAMAmmo] = 4;

$ItemMax[barmor, SAMgun] = 1;
$ItemMax[barmor, SAMAmmo] = 4;
$ItemMax[bfemale, SAMgun] = 1;
$ItemMax[bfemale, SAMAmmo] = 4;

$ItemMax[dmarmor, SAMgun] = 0;
$ItemMax[dmarmor, SAMAmmo] = 0;
$ItemMax[dmfemale, SAMgun] = 0;
$ItemMax[dmfemale, SAMAmmo] = 0;

$ItemMax[larmor, SAMgun] = 0;
$ItemMax[larmor, SAMAmmo] = 0;
$ItemMax[lfemale, SAMgun] = 0;
$ItemMax[lfemale, SAMAmmo] = 0;

$ItemMax[spyarmor, SAMgun] = 0;
$ItemMax[spyarmor, SAMAmmo] = 0;
$ItemMax[spyfemale, SAMgun] = 0;
$ItemMax[spyfemale, SAMAmmo] = 0;

$ItemMax[stimarmor, SAMgun] = 0;
$ItemMax[stimarmor, SAMAmmo] = 0;
$ItemMax[stimfemale, SAMgun] = 0;
$ItemMax[stimfemale, SAMAmmo] = 0;

$ItemMax[sarmor, SAMgun] = 0;
$ItemMax[sarmor, SAMAmmo] = 0;
$ItemMax[sfemale, SAMgun] = 0;
$ItemMax[sfemale, SAMAmmo] = 0;

$ItemMax[aarmor, SAMgun] = 0;
$ItemMax[aarmor, SAMAmmo] = 0;
$ItemMax[afemale, SAMgun] = 0;
$ItemMax[afemale, SAMAmmo] = 0;

$ItemMax[jarmor, SAMgun] = 0;
$ItemMax[jarmor, SAMAmmo] = 0;

function SAMlock::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %player)
{
	%client = Player::getClient(%player);
  	%type = getObjectType(%target);

	if ((%type != "Player") && (%type != "Flier")) return;
	if (gamebase::getteam(%target) == gamebase::getteam(%player)) return;
	if ((%type == "Player") && (!Player::isJetting(%target))) return;

	schedule("LaunchSAM("@%player@","@%target@");", 0.05, %player);
}

function SAMimage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%proj = Projectile::spawnProjectile("SAMlock",%trans,%player,%vel);
	schedule("deleteobject(" @ %proj @ ");",0.08);
	Player::trigger(%client,$WeaponSlot,false);
}

function LaunchSAM(%player, %target)
{
	if (%target < 1)	return;	//Meaning no target found (-1 or 0)
	%client = %player;
	%player = client::getOwnedObject(%player);	//%player is actually the clientId, lets fix that

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SAMrocket",%trans,%player,%vel,%target);
	playSound(bigExplosion1,gamebase::getposition(%player));

	Player::decItemCount(%player,"SAMAmmo",1);
	if (Player::getItemCount(%player, "SAMAmmo") == 0)
	{
		Player::unMountItem(%client,$WeaponSlot);
		remoteNextWeapon(%client);
	}

	if (getObjectType(%target) == "Player")
	{
		%tclient = player::getClient(%target);
		Client::sendMessage(%client,0,"** SAM Lock Aquired - " @ client::getName(%tclient) @ "~wmine_act.wav");
		Client::sendMessage(%tclient, 0, "** WARNING ** SAM launch from " @ client::getName(%client) @ " detected!~waccess_denied.wav");
//		schedule("Client::sendMessage(" @ %tclient @ ",0,\"~waccess_denied.wav\");",0.5);
//		schedule("Client::sendMessage(" @ %tclient @ ",0,\"~waccess_denied.wav\");",1.0);
	}
	else	Client::sendMessage(%client,0,"** SAM Lock Aquired - " @ GameBase::getDataName(%target) @ "~wmine_act.wav");
}