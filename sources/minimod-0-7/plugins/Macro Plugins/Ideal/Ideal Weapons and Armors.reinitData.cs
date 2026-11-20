// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

function Mission::reinitData()
{
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ originalMine] = 0;
		$TeamItemCount[%i @ ReplicatingMine] = 0;
		$TeamItemCount[%i @ FlagMine] = 0;
		$TeamItemCount[%i @ "originalreplicatingmine"] = 0;
		$TeamItemCount[%i @ JetFireVechicle] = 0;

		$TeamEnergy[%i] = $DefaultTeamEnergy;
	}
}
