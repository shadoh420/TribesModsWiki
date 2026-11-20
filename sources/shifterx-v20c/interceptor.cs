function Jet::onFire(%this)
{
	if (GameBase::GetEnergy(%this) < 30) return;

	GameBase::getLOSInfo(%this,800);
	%target = $los::object;
	%type = getObjectType(%target);
	if ((%target > 0) && ((%type == "Player") || (%type == "Flier"))) {
		 LaunchInterceptorRocket(%this, %target);
		return;
	}

	%trans = GameBase::getMuzzleTransform(%this);
	%vel = Item::getVelocity(%this);
	%proj = Projectile::spawnProjectile("InterceptorLock",%trans,%this,%vel);
	schedule("deleteobject(" @ %proj @ ");",0.08);
//	Player::trigger(%this,$WeaponSlot,false);
}

function InterceptorLock::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %player)
{
	%client = Player::getClient(%player);
  	%type = getObjectType(%target);

	if ((%type != "Player") && (%type != "Flier")) return;
	if (gamebase::getteam(%target) == gamebase::getteam(%player)) return;
	if ((%type == "Player") && (!Player::isJetting(%target))) return;

	schedule("LaunchInterceptorRocket("@Player::getMountObject(%player)@","@%target@");", 0.05, %player);
}

function LaunchInterceptorRocket(%jet, %target)
{
	if (%target < 1)	return;	//Meaning no target found (-1 or 0)
	if (GameBase::GetEnergy(%jet) < 30) return;
	%player = GameBase::getControlClient(%jet);
	%trans = GameBase::getMuzzleTransform(%jet);
	%vel = Item::getVelocity(%jet);

	GameBase::SetEnergy(%jet, 0);
	playSound(bigExplosion1,gamebase::getposition(%player));
	Projectile::spawnProjectile("InterceptorRocket",%trans,%jet,%vel,%target);

	if (getObjectType(%target) == "Player")
	{
		%tclient = player::getClient(%target);
		Client::sendMessage(%client,0,"** SAM Lock Aquired - " @ client::getName(%tclient) @ "~wmine_act.wav");
		Client::sendMessage(%tclient, 0, "** WARNING ** SAM launch from " @ client::getName(%client) @ " detected!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %tclient @ ",0,\"~waccess_denied.wav\");",0.5);
		schedule("Client::sendMessage(" @ %tclient @ ",0,\"~waccess_denied.wav\");",1.0);
	}
	else	Client::sendMessage(%client,0,"** SAM Lock Aquired - " @ GameBase::getDataName(%target) @ "~wmine_act.wav");
}