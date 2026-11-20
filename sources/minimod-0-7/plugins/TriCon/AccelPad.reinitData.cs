///-----------------------------------------------
/// Description - "Accelerator pad";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
/// Original Idea ripped from Z-Tek
/// http://216.169.122.124/Z-Tek
///-----------------------------------------------

for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ AccelPPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}