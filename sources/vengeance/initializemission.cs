
// Gutted this file and replaced it with the function below.. Mmm, sexay! -Plasmatic

// set team item counts to 0
%i = $item+1;
while(%i-- >0)
{
	%item = $Itemlist[%i];

	if($TeamItemMax[%item] > 0)
	{	
		if($debug)
			echo("Initialize #"@%i@" "@%item@", team max ="@$TeamItemMax[%item]);		
		for(%t = 0; %t < getnumteams(); %t++)
			$TeamItemCount [%t@ %item] = 0;
	}
}
// drop ships..
for(%i = 0; %i < 100; %i++)
{
	$DropShipPosition[%i] = "";
}
$Ship = 0;	
	

$totalNumCameras = 0;
$totalNumTurrets = 0;
for(%i = -1; %i < 8 ; %i++)
{
	$TeamEnergy[%i] = $DefaultTeamEnergy;
	
	$PowerSet[%i] = false;
	$ClassBGen[%i] = "";
	$ClassAGen[%i] = "";
	$Alarm[%i] = false;
	$GenSet[%i] = "";
}
	
//for object counters -plas
$item::count = 0;
$Ammo::count = 0;
$mine::count = 0;
$turret::count = 0;
$StaticShape::count = 0;
	
	
