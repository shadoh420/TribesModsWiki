// This is a MiniMod Plugin.
// This plugin is the "Obelisk Of Light" (And Power source) from
// the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Obelisk Of Light.ArmorData.cs
//    Obelisk Of Light.baseProjData.cs
//    Obelisk Of Light.item.cs
//    Obelisk Of Light.Nsound.cs
//    Obelisk Of Light.reinitData.cs
//    Obelisk Of Light.staticshape.cs
//    Obelisk Of Light.station.cs
//    Obelisk Of Light.turret.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ ObeliskPowerPack] = 0;
		$TeamItemCount[%i @ ObeliskPack] = 0;
}
