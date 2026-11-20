$InvList[Mfgl] = 1;
$InvList[MfglAmmo] = 1;

$WeaponAmmo[Mfgl] = MFGLammo;
$SellAmmo[MfglAmmo] = 1;

$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = Mfgl;
$NextWeapon[Mfgl] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = Mfgl;
$PrevWeapon[Mfgl] = $temp;

function MfglImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	if (%client.isNuking) return;
	%client.isNuking = 1;
	if (Player::getItemCount(%player, $WeaponAmmo[Mfgl])) flashNuke(%player,4);
}

function flashNuke(%player, %t)
{
	%client = Player::getClient(%player);
	if (Player::isDead(%player) || (Player::getMountedItem(%player, $WeaponSlot) != Mfgl)) {
		%client.isNuking = "";
		return;
	}

	%trans = GameBase::GetMuzzleTransform(%player);
	%vec = GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
	gamebase::activateshield(%player, vector::neg(%vec), 0.8);
	if(%t > 1) {
		client::sendmessage(%client, 1, "Discharging containment field, "@%t@" seconds remaining...~wenergypackon.wav");
		schedule("flashNuke("@%player@"," @ %t - 1 @ ");", 4, %player);
	} else {
		client::sendmessage(%client, 1, "Discharging containment field, 1 second remaining...~wenergypackon.wav");
		schedule("fireNuke("@%player@");", 1, %player);
	}
}

function fireNuke(%player)
{
	%client = Player::getClient(%player);
	if (Player::isDead(%player) || (Player::getMountedItem(%player, $WeaponSlot) != Mfgl)) {
		%client.isNuking = "";
		return;
	}

	%client.isNuking = "";
	echo("ADMINMSG: **** " @ client::getName(%client) @ " launched a nuke.");
	Player::decItemCount(%player,$WeaponAmmo[MFGL],1);
	%trans = GameBase::GetMuzzleTransform(%player);

	%proj = Projectile::spawnProjectile("FgcShell", %trans, %player, Item::getVelocity(%player));
	schedule("NuclearExplosion(" @ %proj @ "," @ %client @ ");",3.0,%proj);
	playSound(mineExplosion,gamebase::getposition(%player));
	KnockbackPlayer(%player);
}
