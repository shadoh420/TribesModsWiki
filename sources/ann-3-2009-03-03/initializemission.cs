
// Gutted this file and replaced it with the function below.. Mmm, sexay! -Plasmatic

// set team item counts to 0
//	%i = $item+1;
//	while(%i-- >0)
//	{
//		%item = $Itemlist[%i];
//	
//		if($TeamItemMax[%item] > 0)
//		{	
//			if($debug)
//				echo("Initialize #"@%i@" "@%item@", team max ="@$TeamItemMax[%item]);		
//			for(%t = 0; %t < getnumteams(); %t++)
//				$TeamItemCount [%t@ %item] = 0;
//		}
//	}

deletevariables("$TeamItemCount*");	//mmmm, sexayier! -Plasmatic
deletevariables("$JailPosition*");	

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
deletevariables("$mine::*");	//$mine::count = 0;	//added mine tracker for 3.1 -Plasmatic
$turret::count = 0;
$StaticShape::count = 0;


// new for 3.x -Plasmatic
deletevariables("$MissionInfo:*");

%start = waypointtoworld("0 0");
%end = waypointtoworld("1024 1024");
$MissionInfo:X = getword(%start,0);
$MissionInfo:Y = getword(%start,1);
$MissionInfo:H = getword(%end,0)-$MissionInfo:X;
$MissionInfo:W = getword(%end,1)-$MissionInfo:Y;

echo("X: "@$MissionInfo:X);
echo("Y: "@$MissionInfo:Y);	
echo("H: "@$MissionInfo:H);
echo("W: "@$MissionInfo:W);	


%file = "Map_Info_"@string::convertSpaces($missionName);
if($terrainInfoPlugin && Terrain::GetInfo() != -1)	//Thanks NoFix!
{
	
	//Terrain::GetInfo(); //returns <haze> <perspective> <visible>
	%d = getword(Terrain::GetInfo(),2);
	$MissionInfo:VisibleDist = %d;
		%vis = floor(%d) @" (+-"@floor(%d/100)@")";
		messageall(0,"Visible Distance is "@%vis);
		echo("Visible Distance is "@%vis@" -Thanks NoFix!");
	
	
}
else if(isFile("temp\\"@%file@".cs")) 
{
	$MissionInfo:VisibleDist = "";
	exec(%file);
	
	%d = $MissionInfo:VisibleDist;
	if(%d > 1)
	{
		%vis = floor(%d) @" (+-"@floor(%d/100)@")";
		messageall(0,"Visible Distance is "@%vis);
		echo("Visible Distance is "@%vis);
		return;
	}
}
else
{
	%try = %start @ " -3000";
	while(getlosInfo(%try,vector::add(%try,"0 0 2000"),1) && %a < 100)
	{
		%try = vector::add(%try,"0 0 2000");
		%a++;
	}
	
	function Froggy::Speedcheck(%pl)	
	{
		//echo(fogcheck);
		//plasmatic
		if(Player::isDead(%pl) || !Player::isAIControlled(%pl) || client::getname(%pl) != "Froggy" || gamebase::getposition(%pl) == "0 0 0")
			return;
			
		//	Player::isAIControlled(%this) && %type == 6 && client::getname(%damagedClient) == "Froggy"
		%vel = Item::getVelocity(%pl);
		%speed = vector::getdistance(%vel,"0 0 0");
			
		if(%speed > 50)	
		{
			Item::setVelocity(%pl,"0 0 0");
			//messageall(1,"speed check "@%speed);
		}	
	
		schedule("Froggy::Speedcheck("@%pl@");",0.2);		
	}
	
	
	echo();
	echo(%a@" fog check pos: "@%try);
	
	$fogturret = newObject("","Turret",FogCheckerLaserTurret,true);
	GameBase::setTeam($fogturret,0);
	GameBase::setPosition($fogturret,%try);
	GameBase::setRotation($fogturret,"0 1.57 1.57");
	addToSet("MissionCleanup", $fogturret);
	GameBase::setRechargeRate($fogturret,500);
	GameBase::setActive($fogturret,true);
	
	AI::spawn("Froggy", armormWarrior, vector::add(%try,"0 0 2000"), %spawnRot, "Froggy", "male2" );
	%cl = AI::getId("Froggy");
	%pl = Client::getOwnedObject(%cl);
	echo("Fog check position: "@ %try @" AI: "@ Client::getName(%cl)@ " cl:" @ %cl @ " pl:" @ %pl @ " position: "@gamebase::getposition(%pl));
	addToSet("MissionCleanup", %pl);
	
	Client::setinitialTeam(%cl, 1);
	GameBase::setTeam(%cl, 1); 
	Froggy::Speedcheck(%cl);
		
	

}


