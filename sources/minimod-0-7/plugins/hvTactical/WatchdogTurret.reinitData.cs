// This is a MiniMod Plugin.
// This plugin is the GuardDog (Spotter) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    WatchdogTurret.ArmorData.cs
//    WatchdogTurret.baseProjData.cs
//    WatchdogTurret.item.cs
//    WatchdogTurret.reinitData.cs
//    WatchdogTurret.station.cs
//    WatchdogTurret.turret.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ WatchdogPack] = 0;
}
