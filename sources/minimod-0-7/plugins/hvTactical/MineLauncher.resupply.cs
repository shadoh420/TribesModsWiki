// This is a MiniMod Plugin.
// This plugin is the Mine Launcher from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    MineLauncher.ArmorData.cs
//    MineLauncher.baseProjData.cs
//    MineLauncher.item.cs
//    MineLauncher.station.cs
//
// to your MiniMod/plugins directory.

%cnt = %cnt + AmmoStation::resupply(%player,MineLauncher,MinelAmmo,5); 

