// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ FlakPack] = 0;
}
