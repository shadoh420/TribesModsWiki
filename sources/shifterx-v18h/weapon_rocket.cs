function RocketImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier") 
				 {			 
					%name = Client::getName(%targetId);
					Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
					Client::sendMessage(%targetId,0,"** WARNING ** - " @ Client::getName(%client) @ " has a Missile Lock!~waccess_denied.wav");
				 }
				 else
				 {
					 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	} //=== End standard missile fire.