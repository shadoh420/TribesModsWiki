// This is a MiniMod Plugin.
// This is the Arbitor Box from the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Arbitor Box.ArmorData.cs
//    Arbitor Box.item.cs
//    Arbitor Box.reinitData.cs
//    Arbitor Box.station.cs
//    Arbitor Box.turret.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ ArbitorBoxPack] = 0;
}
