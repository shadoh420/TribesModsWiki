//Nuke4

$InvList[Mfgl4] = 1;
$InvList[Mfgl4Ammo] = 1;
$RemoteInvList[Mfgl4] = 1;
$RemoteInvList[Mfgl4Ammo] = 1;

$WeaponAmmo[Mfgl4] = Mfgl4ammo;
$SellAmmo[Mfgl4Ammo] = 1;

$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = Mfgl4;
$NextWeapon[Mfgl4] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = Mfgl4;
$PrevWeapon[Mfgl4] = $temp;

$temp = "";

$ItemMax[darmor, Mfgl4] = 1;
$ItemMax[darmor, Mfgl4Ammo] = 8;
$ItemMax[dfemale, Mfgl4] = 1;
$ItemMax[dfemale, Mfgl4Ammo] = 8;

$ItemMax[harmor, Mfgl4] = 0;
$ItemMax[harmor, Mfgl4Ammo] = 0;
$ItemMax[hfemale, Mfgl4] = 0;
$ItemMax[hfemale, Mfgl4Ammo] = 0;

$ItemMax[barmor, Mfgl4] = 0;
$ItemMax[barmor, Mfgl4Ammo] = 0;
$ItemMax[bfemale, Mfgl4] = 0;
$ItemMax[bfemale, Mfgl4Ammo] = 0;

$ItemMax[marmor, Mfgl4] = 0;
$ItemMax[marmor, Mfgl4Ammo] = 0;
$ItemMax[mfemale, Mfgl4] = 0;
$ItemMax[mfemale, Mfgl4Ammo] = 0;

$ItemMax[earmor, Mfgl4] = 0;
$ItemMax[earmor, Mfgl4Ammo] = 0;
$ItemMax[efemale, Mfgl4] = 0;
$ItemMax[efemale, Mfgl4Ammo] = 0;

$ItemMax[dmarmor, Mfgl4] = 0;
$ItemMax[dmarmor, Mfgl4Ammo] = 0;
$ItemMax[dmfemale, Mfgl4] = 0;
$ItemMax[dmfemale, Mfgl4Ammo] = 0;

$ItemMax[larmor, Mfgl4] = 0;
$ItemMax[larmor, Mfgl4Ammo] = 0;
$ItemMax[lfemale, Mfgl4] = 0;
$ItemMax[lfemale, Mfgl4Ammo] = 0;

$ItemMax[spyarmor, Mfgl4] = 0;
$ItemMax[spyarmor, Mfgl4Ammo] = 0;
$ItemMax[spyfemale, Mfgl4] = 0;
$ItemMax[spyfemale, Mfgl4Ammo] = 0;

$ItemMax[stimarmor, Mfgl4] = 0;
$ItemMax[stimarmor, Mfgl4Ammo] = 0;
$ItemMax[stimfemale, Mfgl4] = 0;
$ItemMax[stimfemale, Mfgl4Ammo] = 0;

$ItemMax[sarmor, Mfgl4] = 0;
$ItemMax[sarmor, Mfgl4Ammo] = 0;
$ItemMax[sfemale, Mfgl4] = 0;
$ItemMax[sfemale, Mfgl4Ammo] = 0;

$ItemMax[aarmor, Mfgl4] = 0;
$ItemMax[aarmor, Mfgl4Ammo] = 0;
$ItemMax[afemale, Mfgl4] = 0;
$ItemMax[afemale, Mfgl4Ammo] = 0;

$ItemMax[jarmor, Mfgl4] = 0;
$ItemMax[jarmor, Mfgl4Ammo] = 0;

function Mfgl4Image::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	if (%client.isNuking) return;
	%client.isNuking = 1;
	if (Player::getItemCount(%player, $WeaponAmmo[Mfgl4])) fireNuke4(%player, 8);
	Player::decItemCount(%player,$WeaponAmmo[MFGL4],1);
}

function fireNuke4(%player, %count)
{
	%client = Player::getClient(%player);

	if (Player::isDead(%player) || (Player::getMountedItem(%player, $WeaponSlot) != Mfgl4)) {
		%client.isNuking = "";
		return;
	}

	%client.isNuking = "";
	%trans = GameBase::GetMuzzleTransform(%player);

	%x = getWord(%trans,3) + ((getRandom() - 0.5) * 0.12);
	%y = getWord(%trans,4) + ((getRandom() - 0.5) * 0.12);
	%z = getWord(%trans,5) + ((getRandom() - 0.5) * 0.12);

	%trans= getWord(%trans,0)@" "@
		getWord(%trans,1)@" "@
		getWord(%trans,2)@" "@
		%x@" "@%y@" "@%z@" "@
		getWord(%trans,6)@" "@
		getWord(%trans,7)@" "@
		getWord(%trans,8)@" "@
		getWord(%trans,9)@" "@
		getWord(%trans,10)@" "@
		getWord(%trans,11);

	%vel = Item::getVelocity(%player);

	%proj = Projectile::spawnProjectile("Nuke4Shell", %trans, %player, %vel);

	playSound(SoundFireFlierRocket,gamebase::getposition(%player));
	%count--;
	if (%count > 0) schedule("fireNuke4(" @ %player @ "," @ %count @");", 0.2);
}
