// This is a MiniMod Plugin.
// This is the Mini-Plasma turret created/ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Mini-PlasmaTurret.ArmorData.cs
//    Mini-PlasmaTurret.baseProjData.cs
//    Mini-PlasmaTurret.item.cs
//    Mini-PlasmaTurret.reinitData.cs
//    Mini-PlasmaTurret.station.cs
//    Mini-PlasmaTurret.turret.cs
//
// to your MiniMod/plugins directory.

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ PlasmaPack] = 0;
}
