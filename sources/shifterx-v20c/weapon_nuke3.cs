//Nuke3 (The big rocket)

$InvList[Mfgl3] = 1;
$InvList[Mfgl3Ammo] = 1;
$RemoteInvList[Mfgl3] = 0;
$RemoteInvList[Mfgl3Ammo] = 0;

$WeaponAmmo[Mfgl3] = Mfgl3ammo;
$SellAmmo[Mfgl3Ammo] = 1;

$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = Mfgl3;
$NextWeapon[Mfgl3] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = Mfgl3;
$PrevWeapon[Mfgl3] = $temp;

$temp = "";

$ItemMax[darmor, Mfgl3] = 0;
$ItemMax[darmor, Mfgl3Ammo] = 0;
$ItemMax[dfemale, Mfgl3] = 0;
$ItemMax[dfemale, Mfgl3Ammo] = 0;

$ItemMax[harmor, Mfgl3] = 0;
$ItemMax[harmor, Mfgl3Ammo] = 0;
$ItemMax[hfemale, Mfgl3] = 0;
$ItemMax[hfemale, Mfgl3Ammo] = 0;

$ItemMax[barmor, Mfgl3] = 0;
$ItemMax[barmor, Mfgl3Ammo] = 0;
$ItemMax[bfemale, Mfgl3] = 0;
$ItemMax[bfemale, Mfgl3Ammo] = 0;

$ItemMax[marmor, Mfgl3] = 0;
$ItemMax[marmor, Mfgl3Ammo] = 0;
$ItemMax[mfemale, Mfgl3] = 0;
$ItemMax[mfemale, Mfgl3Ammo] = 0;

$ItemMax[earmor, Mfgl3] = 0;
$ItemMax[earmor, Mfgl3Ammo] = 0;
$ItemMax[efemale, Mfgl3] = 0;
$ItemMax[efemale, Mfgl3Ammo] = 0;

$ItemMax[dmarmor, Mfgl3] = 0;
$ItemMax[dmarmor, Mfgl3Ammo] = 0;
$ItemMax[dmfemale, Mfgl3] = 0;
$ItemMax[dmfemale, Mfgl3Ammo] = 0;

$ItemMax[larmor, Mfgl3] = 0;
$ItemMax[larmor, Mfgl3Ammo] = 0;
$ItemMax[lfemale, Mfgl3] = 0;
$ItemMax[lfemale, Mfgl3Ammo] = 0;

$ItemMax[spyarmor, Mfgl3] = 0;
$ItemMax[spyarmor, Mfgl3Ammo] = 0;
$ItemMax[spyfemale, Mfgl3] = 0;
$ItemMax[spyfemale, Mfgl3Ammo] = 0;

$ItemMax[stimarmor, Mfgl3] = 0;
$ItemMax[stimarmor, Mfgl3Ammo] = 0;
$ItemMax[stimfemale, Mfgl3] = 0;
$ItemMax[stimfemale, Mfgl3Ammo] = 0;

$ItemMax[sarmor, Mfgl3] = 0;
$ItemMax[sarmor, Mfgl3Ammo] = 0;
$ItemMax[sfemale, Mfgl3] = 0;
$ItemMax[sfemale, Mfgl3Ammo] = 0;

$ItemMax[aarmor, Mfgl3] = 0;
$ItemMax[aarmor, Mfgl3Ammo] = 0;
$ItemMax[afemale, Mfgl3] = 0;
$ItemMax[afemale, Mfgl3Ammo] = 0;

$ItemMax[jarmor, Mfgl3] = 1;
$ItemMax[jarmor, Mfgl3Ammo] = 2;

function Mfgl3Image::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	if (%client.isNuking) return;
	%client.isNuking = 1;
	if (Player::getItemCount(%player, $WeaponAmmo[Mfgl3])) flashNuke3(%player,4);
}

function flashNuke3(%player, %t)
{
	%client = Player::getClient(%player);
	if (Player::isDead(%player) || (Player::getMountedItem(%player, $WeaponSlot) != Mfgl3)) {
		%client.isNuking = "";
		return;
	}

	%trans = GameBase::GetMuzzleTransform(%player);
	%vec = GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
	gamebase::activateshield(%player, vector::neg(%vec), 0.8);
	if(%t > 1) {
		client::sendmessage(%client, 1, "Discharging containment field, "@%t@" seconds remaining...~wenergypackon.wav");
		schedule("flashNuke3("@%player@"," @ %t - 1 @ ");", 1, %player);
	} else {
		client::sendmessage(%client, 1, "Discharging containment field, 1 second remaining...~wenergypackon.wav");
		schedule("fireNuke3("@%player@");", 1, %player);
	}
}

function fireNuke3(%player)
{
	%client = Player::getClient(%player);
	if (Player::isDead(%player) || (Player::getMountedItem(%player, $WeaponSlot) != Mfgl3)) {
		%client.isNuking = "";
		return;
	}

	%client.isNuking = "";
	echo("ADMINMSG: **** " @ client::getName(%client) @ " launched a nuke.");
	Player::decItemCount(%player,$WeaponAmmo[MFGL3],1);

	%trans = GameBase::GetMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	%proj = Projectile::spawnProjectile("Nuke3Rocket", %trans, %player, %vel);
	%subproj = Projectile::spawnProjectile("Nuke3Rocket2", %trans, %player, %vel);
	GameBase::Virtual(%proj, "setUpTeamAndProj", Gamebase::GetTeam(%client), %subproj);

	playSound(mineExplosion,gamebase::getposition(%player));
	KnockbackPlayer(%player);
}

function Nuke3Rocket::isNuke(%this) {
 return 1;
}

function Nuke3Rocket::setUpTeamAndProj(%this, %ownerteam, %subproj) {
 %this.ownerTeam = %ownerteam;
 %this.subProj = %subproj;
}

function Nuke3Rocket::getOwnerTeam(%this) {
 return %this.ownerTeam;
}

function Nuke3Rocket::getSubProj(%this) {
 return %this.subProj;
}