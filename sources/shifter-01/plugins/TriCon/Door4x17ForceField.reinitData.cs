//This is a MiniMod Plugin...
//This is the Chaingun Turret from the Ideal mod. Ported by Dewy.

for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfourbyseventeenForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}