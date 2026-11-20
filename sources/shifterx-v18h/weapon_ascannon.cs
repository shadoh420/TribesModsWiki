$InvList[AsCannonGun] = 1;
$RemoteInvList[AsCannonGun] = 1;

$AutoUse[AsCannonGun] = True;
$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = AsCannonGun;
$NextWeapon[AsCannonGun] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = AsCannonGun;
$PrevWeapon[AsCannonGun] = $temp;

$temp = "";

$ItemMax[earmor, AsCannonGun] = 1;
$ItemMax[efemale, AsCannonGun] = 1;

$ItemMax[marmor, AsCannonGun] = 1;
$ItemMax[mfemale, AsCannonGun] = 1;

$ItemMax[spyarmor, AsCannonGun] = 0;
$ItemMax[spyfemale, AsCannonGun] = 0;

$ItemMax[darmor, AsCannonGun] = 1;
$ItemMax[dfemale, AsCannonGun] = 1;

$ItemMax[harmor, AsCannonGun] = 1;
$ItemMax[hfemale, AsCannonGun] = 1;

$ItemMax[barmor, AsCannonGun] = 1;
$ItemMax[bfemale, AsCannonGun] = 1;

$ItemMax[dmarmor, AsCannonGun] = 0;
$ItemMax[dmfemale, AsCannonGun] = 0;

$ItemMax[larmor, AsCannonGun] = 0;
$ItemMax[lfemale, AsCannonGun] = 0;

$ItemMax[stimarmor, AsCannonGun] = 0;
$ItemMax[stimfemale, AsCannonGun] = 0;

$ItemMax[sarmor, AsCannonGun] = 0;
$ItemMax[sfemale, AsCannonGun] = 0;

$ItemMax[aarmor, AsCannonGun] = 1;
$ItemMax[afemale, AsCannonGun] = 1;

$ItemMax[jarmor, AsCannonGun] = 0;


function AsCannonImage::onFire(%player, %slot)
{
 Player::trigger(%player,%slot,false);

 if (GameBase::GetEnergy(%player) >= 4)
 {
  GameBase::SetEnergy(%player, GameBase::GetEnergy(%player) - 4);
  playSound(debrisSmallExplosion,GameBase::getPosition(%player));
  Projectile::spawnProjectile("AsCannonBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
 }
}

