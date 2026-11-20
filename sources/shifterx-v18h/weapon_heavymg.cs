$InvList[HeavyMGGun] = 1;
$InvList[HeavyMGAmmo] = 1;
$RemoteInvList[HeavyMGGun] = 1;
$RemoteInvList[HeavyMGAmmo] = 1;

$WeaponAmmo[HeavyMGGun] = HeavyMGAmmo;
$SellAmmo[HeavyMGAmmo] = 50;
$AutoUse[HeavyMGGun] = True;


$temp = $NextWeapon[GravGun];
$NextWeapon[GravGun] = HeavyMGGun;
$NextWeapon[HeavyMGGun] = $temp;

$temp = $PrevWeapon[BoomStick];
$PrevWeapon[BoomStick] = HeavyMGGun;
$PrevWeapon[HeavyMGGun] = $temp;

$temp = "";

$ItemMax[darmor, HeavyMGGun] = 1;
$ItemMax[darmor, HeavyMGAmmo] = 450;
$ItemMax[dfemale, HeavyMGGun] = 1;
$ItemMax[dfemale, HeavyMGAmmo] = 450;

$ItemMax[harmor, HeavyMGGun] = 1;
$ItemMax[harmor, HeavyMGAmmo] = 350;
$ItemMax[hfemale, HeavyMGGun] = 1;
$ItemMax[hfemale, HeavyMGAmmo] = 350;

$ItemMax[barmor, HeavyMGGun] = 1;
$ItemMax[barmor, HeavyMGAmmo] = 350;
$ItemMax[bfemale, HeavyMGGun] = 1;
$ItemMax[bfemale, HeavyMGAmmo] = 350;

$ItemMax[marmor, HeavyMGGun] = 0;
$ItemMax[marmor, HeavyMGAmmo] = 0;
$ItemMax[mfemale, HeavyMGGun] = 0;
$ItemMax[mfemale, HeavyMGAmmo] = 0;

$ItemMax[earmor, HeavyMGGun] = 0;
$ItemMax[earmor, HeavyMGAmmo] = 0;
$ItemMax[efemale, HeavyMGGun] = 0;
$ItemMax[efemale, HeavyMGAmmo] = 0;

$ItemMax[dmarmor, HeavyMGGun] = 0;
$ItemMax[dmarmor, HeavyMGAmmo] = 0;
$ItemMax[dmfemale, HeavyMGGun] = 0;
$ItemMax[dmfemale, HeavyMGAmmo] = 0;

$ItemMax[larmor, HeavyMGGun] = 0;
$ItemMax[larmor, HeavyMGAmmo] = 0;
$ItemMax[lfemale, HeavyMGGun] = 0;
$ItemMax[lfemale, HeavyMGAmmo] = 0;

$ItemMax[spyarmor, HeavyMGGun] = 0;
$ItemMax[spyarmor, HeavyMGAmmo] = 0;
$ItemMax[spyfemale, HeavyMGGun] = 0;
$ItemMax[spyfemale, HeavyMGAmmo] = 0;

$ItemMax[stimarmor, HeavyMGGun] = 0;
$ItemMax[stimarmor, HeavyMGAmmo] = 0;
$ItemMax[stimfemale, HeavyMGGun] = 0;
$ItemMax[stimfemale, HeavyMGAmmo] = 0;

$ItemMax[sarmor, HeavyMGGun] = 0;
$ItemMax[sarmor, HeavyMGAmmo] = 0;
$ItemMax[sfemale, HeavyMGGun] = 0;
$ItemMax[sfemale, HeavyMGAmmo] = 0;

$ItemMax[aarmor, HeavyMGGun] = 0;
$ItemMax[aarmor, HeavyMGAmmo] = 0;
$ItemMax[afemale, HeavyMGGun] = 0;
$ItemMax[afemale, HeavyMGAmmo] = 0;

$ItemMax[jarmor, HeavyMGGun] = 0;
$ItemMax[jarmor, HeavyMGAmmo] = 0;


function HeavyMGImage::onFire(%player, %slot)
{
 Player::decItemCount(%player,"HeavyMGAmmo",1);

 if (GameBase::isAtRest(%player)) 
 {
  Projectile::spawnProjectile("HeavyMGBulletA",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
 } else {
  Projectile::spawnProjectile("HeavyMGBulletI",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
 }
}

