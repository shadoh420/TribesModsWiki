// This is a MiniMod Plugin.
// This plugin is the Nuclear Turret from the Ideal mod.
// Ported by Dewy.

function Mission::reinitData()
{
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ NuclearTurretPack] = 0;

		$TeamEnergy[%i] = $DefaultTeamEnergy;
	}
}

