// This is a MiniMod Plugin.
// This plugin is the Particle Accelerator from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ParticleAccelerator.ArmorData.cs
//    ParticleAccelerator.baseProjData.cs
//    ParticleAccelerator.item.cs
//    ParticleAccelerator.station.cs
//
// to your MiniMod/plugins directory.

 BulletData ClusterBombShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = debrisExpSmall;
	 mass = 0.05;
	 bulletHoleIndex = 0;
  collisionRadius    = 15.0;//++++++
	 damageClass = 1;
   explosionRadius    = 8;//5;+++++++++++
   kickBackStrength   = 100.0;//++++++++
	 damageValue = 0.038; //0.05;+++++++++++++++++++
	 damageType = $ShrapnelDamageType;
	 aimDeflection = 0.01;//++++++++++
	 muzzleVelocity = 300.0;
	 totalTime = 1.0; //0.8;+++++++++++++++++
	 liveTime = 0.05;//++++++++++++++++++++++++++++++++++++++++++++
	 inheritedVelocityScale = 1.0;
	 isVisible = True;
	
	triggerRadius = 5;//+++++++++++
	damageLevel = {1.0, 1.0};//++++
	maxDamage = 1.0;//0++++++++++++

   tracerPercentage   = 100.0; //1.0;++++++++++++++++++++++++++++++++++++++++++++++
	 tracerLength = 30;
   smokeName              = "plasmatrail.dts";
 };
function ClusterBombShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClusterBombShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}
