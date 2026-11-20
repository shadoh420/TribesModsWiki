function ChaingunImage::onFire(%player, %slot)
{
//	if (Player::GetItemCount(%player, $WeaponAmmo[Chaingun]) <= 0) return;

	Player::decitemcount(%player, $WeaponAmmo[Chaingun]);
 
	%trans = GameBase::GetMuzzleTransform(%player);

	%x = getWord(%trans,3) + ((getRandom() - 0.5) * 0.04);
	%y = getWord(%trans,4) + ((getRandom() - 0.5) * 0.04);
	%z = getWord(%trans,5) + ((getRandom() - 0.5) * 0.04);

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

	Projectile::spawnProjectile("ChaingunBulletLaser",%trans,%player,Item::getVelocity(%player));
	Projectile::spawnProjectile("ChaingunBulletBullet",%trans,%player,Item::getVelocity(%player));
}
