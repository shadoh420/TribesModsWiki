//**********************************************************************************************
// Ok. To set up a new airstrike sequence, you need to define the first three variables below
// once for the whole sequence, and the next 5 multiple times. Check below for examples.
// Simply put, Each sequence number needs to be *different* for each type of vehicle. So if you
// add in a second Falcon type, you need to increase the sequence number for *that* airstrike
// to 2. Each node-waypoint is defined by a "AirStrike::Path" location. The other const can be
// used only in combination with a "Path" variable. Each node *also* is required to have a
// "AirStrike::PathRotChange" variable defined. 
//
//
//**********************************************************************************************

//**********************************************************************************************
// Define once per airstrike
//**********************************************************************************************
// $AirStrike::PayLoad[<vehicle-type>,<path-sequence>] = <projectile-type>;
// $AirStrike::PayLoadReleaseNum[<vehicle-type>,<path-sequence>] = <number-of-projectile-to-drop>;
// $AirStrike::TMinusTime[<vehicle-type>,<path-sequence>] = <time-it-takes-to-bomb-target>;
// $AirStrike::WPTollerance[<vehicle-type>,<path-sequence>] = <how close they need to get to each waypoint. Default 7.2>
//**********************************************************************************************

//**********************************************************************************************
// Define once per node
//**********************************************************************************************
// $AirStrike::Path[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <coordinate>;
// $AirStrike::PathRotChange[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <amount to change rotation by>; // This rotation is how much the jet will rotate by on it's way TO that waypoint. I.e. from A to B, it uses B's RotChange value

//**********************************************************************************************
// Define on each node that you need it for.
//**********************************************************************************************
// $AirStrike::PathFire[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <true|false>; // Fire at this node?
// $AirStrike::PathContFire[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <frequency-of-fire|-1>; // Start Firing at this node, until we find a -1 node.
// $AirStrike::PathExit[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <true|false>; // Exit at this node?
// $AirStrike::PathRoll[<vehicle-type>,<path-sequence>,<node-in-sequence>] = <roll-radian-amount>; // No idea if this one really works. It causes things to freak out anyway.
//**********************************************************************************************

//******************************************************************
// Falcon - Partial Clover. Attacks from all 4 directions with 1 mav.
//******************************************************************

$AirStrike::PayLoad[Falcon,1] = "MavRocket";
$AirStrike::PayLoadReleaseNum[Falcon,1] = 1;
$AirStrike::TMinusTime[Falcon,1] = 25;
$AirStrike::WPTollerance[Falcon,1] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Falcon,1,$AS::C] = "0 -2000 500";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -600 250";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Fly over 1
$AirStrike::Path[Falcon,1,$AS::C] = "0 -350 175";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.1; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -300 150";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -200 100";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AirStrike::PathFire[Falcon,1,$AS::C] = true; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -150 75";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 150 75";	 		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Circle 1
$AirStrike::Path[Falcon,1,$AS::C] = "0 400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.07; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-117.157 682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-400 800 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-682.843 682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-800 400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-682.843 117.157 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-400 0 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Fly over 2
$AirStrike::Path[Falcon,1,$AS::C] = "-350 0 175";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-300 0 150";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-200 0 100";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AirStrike::PathFire[Falcon,1,$AS::C] = true; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-150 0 75";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "150 0 75";	 		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Circle 2
$AirStrike::Path[Falcon,1,$AS::C] = "400 0 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.07; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "682.843 117.157 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "800 400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "682.843 682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "400 800 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "117.157 682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Fly over 3
$AirStrike::Path[Falcon,1,$AS::C] = "0 350 175";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 300 150";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 200 100";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AirStrike::PathFire[Falcon,1,$AS::C] = true; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 150 75";	 		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "0 -150 75";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Circle 3
$AirStrike::Path[Falcon,1,$AS::C] = "0 -400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.07; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "117.157 -682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "400 -800 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "682.843 -682.843 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "800 -400 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "682.843 -117.157 200";	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "400 0 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Fly over 4
$AirStrike::Path[Falcon,1,$AS::C] = "350 0 175";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "300 0 150";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "200 0 100";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AirStrike::PathFire[Falcon,1,$AS::C] = true; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "150 0 75";	 		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.5; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-150 0 75";	 	$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;

// Go home
$AirStrike::Path[Falcon,1,$AS::C] = "-400 0 200";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.07; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-600 0 250";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Falcon,1,$AS::C] = "-2000 0 500";		$AirStrike::PathRotChange[Falcon,1,$AS::C] = 0.05;  $AirStrike::PathExit[Falcon,1,$AS::C] = true; $AS::C++;
$AS::C[Falcon,1]=$AS::C;


//******************************************************************
// Warthog - DiveBomb, with HE
//******************************************************************

$AirStrike::PayLoad[Warthog,1] = "BigBomb";
$AirStrike::PayLoadReleaseNum[Warthog,1] = 2;
$AirStrike::TMinusTime[Warthog,1] = 42;
$AirStrike::WPTollerance[Warthog,1] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Warthog,1,$AS::C] = "0 -2000 200";		$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.05; $AS::C++;

// Dive
$AirStrike::Path[Warthog,1,$AS::C] = "0 -89 200";		$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,1,$AS::C] = "0 -19 60";		$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.2; $AirStrike::PathFire[Warthog,1,$AS::C] = true; $AS::C++;
$AirStrike::Path[Warthog,1,$AS::C] = "0 -9 50";			$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Warthog,1,$AS::C] = "0 189 200";		$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.1; $AS::C++;

// Go home
$AirStrike::Path[Warthog,1,$AS::C] = "0 2000 200";		$AirStrike::PathRotChange[Warthog,1,$AS::C] = 0.05; $AirStrike::PathExit[Warthog,1,$AS::C] = true; $AS::C++;
$AS::C[Warthog,1]=$AS::C;

//******************************************************************
// Warthog - DiveBomb, with Napalm
//******************************************************************
$AirStrike::PayLoad[Warthog,2] = "ASNapalmBomb";
$AirStrike::PayLoadReleaseNum[Warthog,2] = 1;
$AirStrike::TMinusTime[Warthog,2] = 42;
$AirStrike::WPTollerance[Warthog,2] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Warthog,2,$AS::C] = "0 -2000 200";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.05; $AS::C++;

// Dive
$AirStrike::Path[Warthog,2,$AS::C] = "0 -400 200";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,2,$AS::C] = "0 -200 50";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Warthog,2,$AS::C] = "0 -175 50";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.2; $AS::C++;
$AirStrike::Path[Warthog,2,$AS::C] = "0 -150 50";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.2; $AirStrike::PathFire[Warthog,2,$AS::C] = true; $AS::C++;
$AirStrike::Path[Warthog,2,$AS::C] = "0 0 50";			$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.07; $AS::C++;
$AirStrike::Path[Warthog,2,$AS::C] = "0 200 200";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.07; $AS::C++;

// Go home
$AirStrike::Path[Warthog,2,$AS::C] = "0 2000 200";		$AirStrike::PathRotChange[Warthog,2,$AS::C] = 0.05; $AirStrike::PathExit[Warthog,2,$AS::C] = true; $AS::C++;
$AS::C[Warthog,2]=$AS::C;


//******************************************************************
// B-52s (Bomber)x4 - CarpetBombing
// To do multiple jets in formation, we actually need to call 
//  multiple paths at once. For this one, we could easily define
//  one path, and just "call" it 4 times in a formation,
//  but for others (that arn't doing the same basic relative path)
//  like a group of jets pulling a blue angles manuver, we would
//  want to write separate paths for each.
//******************************************************************

$AirStrike::PayLoad[Bomber,1] = "BigBomb";
$AirStrike::PayLoadReleaseNum[Bomber,1] = 1;
$AirStrike::TMinusTime[Bomber,1] = 60;
$AirStrike::WPTollerance[Bomber,1] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Bomber,1,$AS::C] = "0 -2000 500";		$AirStrike::PathRotChange[Bomber,1,$AS::C] = 0.05; $AS::C++;

// Start bombing
$AirStrike::Path[Bomber,1,$AS::C] = "0 -300 500";		$AirStrike::PathRotChange[Bomber,1,$AS::C] = 0.05; $AirStrike::PathFireCont[Bomber,1,$AS::C] = 0.3; $AS::C++;
// Stop bombing
$AirStrike::Path[Bomber,1,$AS::C] = "0 -100 500";		$AirStrike::PathRotChange[Bomber,1,$AS::C] = 0.05; $AirStrike::PathFireCont[Bomber,1,$AS::C] = -1; $AS::C++;

// Go home
$AirStrike::Path[Bomber,1,$AS::C] = "0 2000 500";		$AirStrike::PathRotChange[Bomber,1,$AS::C] = 0.05; $AirStrike::PathExit[Bomber,1,$AS::C] = true; $AS::C++;
$AS::C[Bomber,1]=$AS::C;


//******************************************************************
// F-16
// This isn't really a bombing run. It's an example of what you can
//  do with the module. Basically we'll have 4 paths for 4 jets.
//  They'll fly in delta, until they pull up and over themselves.
//  You'll see...
//******************************************************************


//---------------------------------------------
// First..
//---------------------------------------------
$AirStrike::PayLoad[Falcon,2] = "TankSmoke";
$AirStrike::PayLoadReleaseNum[Falcon,2] = 1;
$AirStrike::TMinusTime[Falcon,2] = 24;
$AirStrike::WPTollerance[Falcon,2] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Falcon,2,$AS::C] = "0 -2000 50";		$AirStrike::PathRotChange[Falcon,2,$AS::C] = 0.05; $AS::C++;

// Start Smoking
$AirStrike::Path[Falcon,2,$AS::C] = "0 -500 50";		$AirStrike::PathRotChange[Falcon,2,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,2,$AS::C] = 0.2; $AS::C++;

$AirStrike::Path[Falcon,2,$AS::C] = "0 5 50";			$AirStrike::PathRotChange[Falcon,2,$AS::C] = 0.05; $AS::C++; 

// Flower out
$AirStrike::Path[Falcon,2,$AS::C] = "200 500 300";		$AirStrike::PathRotChange[Falcon,2,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,2,$AS::C] = -1; $AS::C++;

// Leave
$AirStrike::Path[Falcon,2,$AS::C] = "200 2000 300";		$AirStrike::PathRotChange[Falcon,2,$AS::C] = 0.05; $AirStrike::PathExit[Falcon,2,$AS::C] = true; $AS::C++;
$AS::C[Falcon,2]=$AS::C;


//---------------------------------------------
// Second..
//---------------------------------------------
$AirStrike::PayLoad[Falcon,3] = "TankSmoke";
$AirStrike::PayLoadReleaseNum[Falcon,3] = 1;
$AirStrike::TMinusTime[Falcon,3] = 24;
$AirStrike::WPTollerance[Falcon,3] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Falcon,3,$AS::C] = "0 -2005 50";		$AirStrike::PathRotChange[Falcon,3,$AS::C] = 0.05; $AS::C++;

// Start Smoking
$AirStrike::Path[Falcon,3,$AS::C] = "0 -505 50";		$AirStrike::PathRotChange[Falcon,3,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,3,$AS::C] = 0.2; $AS::C++;

$AirStrike::Path[Falcon,3,$AS::C] = "0 10 50";			$AirStrike::PathRotChange[Falcon,3,$AS::C] = 0.05; $AS::C++;
	
// Flower out
$AirStrike::Path[Falcon,3,$AS::C] = "-200 500 300";		$AirStrike::PathRotChange[Falcon,3,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,3,$AS::C] = false; $AS::C++;

// Leave
$AirStrike::Path[Falcon,3,$AS::C] = "-200 2000 300";		$AirStrike::PathRotChange[Falcon,3,$AS::C] = 0.05; $AirStrike::PathExit[Falcon,3,$AS::C] = true; $AS::C++;
$AS::C[Falcon,3]=$AS::C;


//---------------------------------------------
// Third..
//---------------------------------------------
$AirStrike::PayLoad[Falcon,4] = "TankSmoke";
$AirStrike::PayLoadReleaseNum[Falcon,4] = 1;
$AirStrike::TMinusTime[Falcon,4] = 24;
$AirStrike::WPTollerance[Falcon,4] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Falcon,4,$AS::C] = "5 -2002.5 50";		$AirStrike::PathRotChange[Falcon,4,$AS::C] = 0.05; $AS::C++;

// Start Smoking
$AirStrike::Path[Falcon,4,$AS::C] = "5 -502.5 50";		$AirStrike::PathRotChange[Falcon,4,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,4,$AS::C] = 0.2; $AS::C++;

$AirStrike::Path[Falcon,4,$AS::C] = "5 2.5 50";			$AirStrike::PathRotChange[Falcon,4,$AS::C] = 0.05; $AS::C++;
	
// Flower out
$AirStrike::Path[Falcon,4,$AS::C] = "400 500 300";		$AirStrike::PathRotChange[Falcon,4,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,4,$AS::C] = false; $AS::C++;

// Leave
$AirStrike::Path[Falcon,4,$AS::C] = "400 2000 300";		$AirStrike::PathRotChange[Falcon,4,$AS::C] = 0.05; $AirStrike::PathExit[Falcon,4,$AS::C] = true; $AS::C++;
$AS::C[Falcon,4]=$AS::C;

//---------------------------------------------
// Fourth..
//---------------------------------------------
$AirStrike::PayLoad[Falcon,5] = "TankSmoke";
$AirStrike::PayLoadReleaseNum[Falcon,5] = 1;
$AirStrike::TMinusTime[Falcon,5] = 24;
$AirStrike::WPTollerance[Falcon,5] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Falcon,5,$AS::C] = "-5 -2002.5 50";		$AirStrike::PathRotChange[Falcon,5,$AS::C] = 0.05; $AS::C++;

// Start Smoking
$AirStrike::Path[Falcon,5,$AS::C] = "-5 -502.5 50";		$AirStrike::PathRotChange[Falcon,5,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,5,$AS::C] = 0.2; $AS::C++;

$AirStrike::Path[Falcon,5,$AS::C] = "-5 2.5 50";		$AirStrike::PathRotChange[Falcon,5,$AS::C] = 0.05; $AS::C++;
	
// Flower out
$AirStrike::Path[Falcon,5,$AS::C] = "-400 500 300";		$AirStrike::PathRotChange[Falcon,5,$AS::C] = 0.05; $AirStrike::PathFireCont[Falcon,5,$AS::C] = false; $AS::C++;

// Leave
$AirStrike::Path[Falcon,5,$AS::C] = "-400 2000 300";		$AirStrike::PathRotChange[Falcon,5,$AS::C] = 0.05; $AirStrike::PathExit[Falcon,5,$AS::C] = true; $AS::C++;
$AS::C[Falcon,5]=$AS::C;



//******************************************************************
// Warthog for DF_Extraction
// It'll fly in down the canyon and nap the area.
//******************************************************************

// start at "-35 -2 38"

$AirStrike::PayLoad[Warthog,3] = "ASNapalmBomb";
$AirStrike::PayLoadReleaseNum[Warthog,3] = 1;
$AirStrike::TMinusTime[Warthog,3] = 0;
$AirStrike::WPTollerance[Warthog,3] = 10;

$AS::C=0;
// Approach
$AirStrike::Path[Warthog,3,$AS::C] = "-2100 0 100";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "-750 0 100";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.05; $AS::C++;

// Canyon
$AirStrike::Path[Warthog,3,$AS::C] = "-475 -5 0";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "-375 0 -15";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "-300 5 -10";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "-250 30 -5";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "-110 -30 -10";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AirStrike::PathFire[Warthog,3,$AS::C] = true; $AS::C++;
// Fire/aimup
$AirStrike::Path[Warthog,3,$AS::C] = "-75 -10 -15";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.25; $AS::C++;
// Above bridge
$AirStrike::Path[Warthog,3,$AS::C] = "-0 0 50";			$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.15; $AS::C++;


// Go home
$AirStrike::Path[Warthog,3,$AS::C] = "300 0 100";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,3,$AS::C] = "2000 0 100";		$AirStrike::PathRotChange[Warthog,3,$AS::C] = 0.05; $AirStrike::PathExit[Warthog,3,$AS::C] = true; $AS::C++;
$AS::C[Warthog,3]=$AS::C;

//******************************************************************
// Second Warthog for DF_Extraction
// It'll fly in down the canyon but will get blown up before it does anything.
//******************************************************************

// From -371 0 17

$AirStrike::PayLoad[Warthog,4] = "ASNapalmBomb";
$AirStrike::PayLoadReleaseNum[Warthog,4] = 1;
$AirStrike::TMinusTime[Warthog,4] = 0;
$AirStrike::WPTollerance[Warthog,4] = 10;

$AS::C=0;
// Approach
$AirStrike::Path[Warthog,4,$AS::C] = "-2000 0 100";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,4,$AS::C] = "-750 -30 100";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.05; $AS::C++;

// Canyon
$AirStrike::Path[Warthog,4,$AS::C] = "-400 -15 15";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,4,$AS::C] = "-330 -38 10";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,4,$AS::C] = "-241 -12 10";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,4,$AS::C] = "-145 0 10";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.15; $AS::C++;
// Fire/aimup
$AirStrike::Path[Warthog,4,$AS::C] = "-50 0 10";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.25; $AirStrike::PathFire[Warthog,4,$AS::C] = true; $AS::C++;
// up
$AirStrike::Path[Warthog,4,$AS::C] = "-0 0 10";			$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.15; $AS::C++;


// Go home
$AirStrike::Path[Warthog,4,$AS::C] = "300 0 100";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,4,$AS::C] = "2000 0 100";		$AirStrike::PathRotChange[Warthog,4,$AS::C] = 0.05; $AirStrike::PathExit[Warthog,4,$AS::C] = true; $AS::C++;
$AS::C[Warthog,4]=$AS::C;


//******************************************************************
// Tomcat for DF_Extraction
// It'll fly down and kill the incomming warthog.
//******************************************************************

$AirStrike::PayLoad[Tomcat,1] = "Phoenix2Missile";
$AirStrike::PayLoadReleaseNum[Tomcat,1] = 2;
$AirStrike::TMinusTime[Tomcat,1] = 0;
$AirStrike::WPTollerance[Tomcat,1] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 3000 200";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 400 200";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AS::C++;

// attack
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 200 100";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AS::C++;
// Fire/aimup
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 100 50";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AirStrike::PathFire[Tomcat,1,$AS::C] = true; $AS::C++;
// Above bridge
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 0 50";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 -300 200";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AS::C++;


// Go home
$AirStrike::Path[Tomcat,1,$AS::C] = "-228 -2300 200";		$AirStrike::PathRotChange[Tomcat,1,$AS::C] = 0.15; $AirStrike::PathExit[Tomcat,1,$AS::C] = true; $AS::C++;
$AS::C[Tomcat,1]=$AS::C;

//******************************************************************
// Blackhawk for DF_Alamo
// Lands on top of building
//******************************************************************

// Start at "-1828 881 125"
//extraction::spawnExtractionvehicle("-1828 881 125",0);

$AirStrike::PayLoad[Blackhawk,1] = "";
$AirStrike::PayLoadReleaseNum[Blackhawk,1] = 0;
$AirStrike::TMinusTime[Blackhawk,1] = 0;
$AirStrike::WPTollerance[Blackhawk,1] = 7.2;

$AS::C=0;
// Approach
$AirStrike::Path[Blackhawk,1,$AS::C] = "100 -1000 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,1,$AS::C] = "100 0 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,1,$AS::C] = "0 100 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,1,$AS::C] = "-100 0 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,1,$AS::C] = "-75 -75 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,1,$AS::C] = "0 -25 0";		$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.10; $AS::C++;

// Go home
$AirStrike::Path[Blackhawk,1,$AS::C] = "0 0 0";			$AirStrike::PathRotChange[Blackhawk,1,$AS::C] = 0.10; $AirStrike::PathFunction[Blackhawk,1,$AS::C] = "Extraction::SwitchVehicles(%this);"; $AirStrike::PathExit[Blackhawk,1,$AS::C] = true; $AS::C++;
$AS::C[Blackhawk,1]=$AS::C;

//******************************************************************
// Blackhawk 1 for DF_Extraction
// Gets shot down as it arrives
//******************************************************************

// Start at "243 10 26"
//extraction::spawnExtractionvehicle("-1828 881 125",0);

$AirStrike::PayLoad[Blackhawk,2] = "";
$AirStrike::PayLoadReleaseNum[Blackhawk,2] = 0;
$AirStrike::TMinusTime[Blackhawk,2] = 0;
$AirStrike::WPTollerance[Blackhawk,2] = 7.2;



$AS::C=0;
// Approach
$AirStrike::Path[Blackhawk,2,$AS::C] = "100 2000 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "100 0 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "0 -100 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "-100 0 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "0 100 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "100 0 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AirStrike::PathFunction[Blackhawk,2,$AS::C] = "Extraction::ShootDown(%this);"; $AS::C++;

// Die
$AirStrike::Path[Blackhawk,2,$AS::C] = "0 -100 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AirStrike::PathFunction[Blackhawk,2,$AS::C] = "Extraction::ShootDown(%this);"; $AS::C++;
$AirStrike::Path[Blackhawk,2,$AS::C] = "-100 0 100";		$AirStrike::PathRotChange[Blackhawk,2,$AS::C] = 0.05; $AirStrike::PathExit[Blackhawk,2,$AS::C] = true; $AS::C++;

$AS::C[Blackhawk,2]=$AS::C;

//******************************************************************
// Blackhawk 2 for DF_Extraction
// Will "extract" the players
//******************************************************************

// Start at "-525 -3 10"
//extraction::BlackHawkTwo("-525 -3 10");

$AirStrike::PayLoad[Blackhawk,3] = "";
$AirStrike::PayLoadReleaseNum[Blackhawk,3] = 0;
$AirStrike::TMinusTime[Blackhawk,3] = 0;
$AirStrike::WPTollerance[Blackhawk,3] = 7.2;

function WipePaths()
{
deletevariables("$AirStrike::Path*");


}

$AS::C=0;
// Approach
$AirStrike::Path[Blackhawk,3,$AS::C] = "100 1000 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "100 0 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "0 -100 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "-100 0 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "0 100 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "100 0 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "0 -100 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "-100 0 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "0 100 100";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "100 0 50";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,3,$AS::C] = "25 0 25";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.10; $AS::C++;

$AirStrike::Path[Blackhawk,3,$AS::C] = "0 0 25";		$AirStrike::PathRotChange[Blackhawk,3,$AS::C] = 0.10; $AirStrike::PathFunction[Blackhawk,3,$AS::C] = "Extraction::SwitchVehicles(%this);";  $AirStrike::PathExit[Blackhawk,3,$AS::C] = true; $AS::C++;

$AS::C[Blackhawk,3]=$AS::C;

//******************************************************************
// Blackhawk 3 for DF_Extraction
// Flys in for the enemy at the beginning.
// Part 1 of 2
//******************************************************************

// Start at "498 -145 35"
//extraction::BlackHawkThree("498 -145 35");

$AirStrike::PayLoad[Blackhawk,4] = "";
$AirStrike::PayLoadReleaseNum[Blackhawk,4] = 0;
$AirStrike::TMinusTime[Blackhawk,4] = 0;
$AirStrike::WPTollerance[Blackhawk,4] = 7.2;



$AS::C=0;
// Approach
$AirStrike::Path[Blackhawk,4,$AS::C] = "0 -2000 50";		$AirStrike::PathRotChange[Blackhawk,4,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,4,$AS::C] = "0 -100 50";		$AirStrike::PathRotChange[Blackhawk,4,$AS::C] = 0.05; $AS::C++;

$AirStrike::Path[Blackhawk,4,$AS::C] = "0 0 25";		$AirStrike::PathRotChange[Blackhawk,4,$AS::C] = 0.10; $AirStrike::PathFunction[Blackhawk,4,$AS::C] = "Extraction::LandAndWait(%this);";  $AirStrike::PathExit[Blackhawk,4,$AS::C] = true; $AS::C++;

$AS::C[Blackhawk,4]=$AS::C;

//******************************************************************
// Blackhawk 3 for DF_Extraction
// Flys out for the enemy at the beginning.
// Part 2 of 2
//******************************************************************

$AirStrike::PayLoad[Blackhawk,5] = "";
$AirStrike::PayLoadReleaseNum[Blackhawk,5] = 0;
$AirStrike::TMinusTime[Blackhawk,5] = 0;
$AirStrike::WPTollerance[Blackhawk,5] = 7.2;



$AS::C=0;
// Approach
$AirStrike::Path[Blackhawk,5,$AS::C] = "0 0 0";			$AirStrike::PathRotChange[Blackhawk,5,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,5,$AS::C] = "0 100 25";		$AirStrike::PathRotChange[Blackhawk,5,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,5,$AS::C] = "100 0 50";		$AirStrike::PathRotChange[Blackhawk,5,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Blackhawk,5,$AS::C] = "100 -100 100";		$AirStrike::PathRotChange[Blackhawk,5,$AS::C] = 0.10; $AS::C++;

$AirStrike::Path[Blackhawk,5,$AS::C] = "100 -2000 100";		$AirStrike::PathRotChange[Blackhawk,5,$AS::C] = 0.10; $AirStrike::PathExit[Blackhawk,5,$AS::C] = true; $AS::C++;

$AS::C[Blackhawk,5]=$AS::C;

//******************************************************************
// Warthog for DF_Extraction
// It'll fly in down the canyon and nap the area.
//******************************************************************

// start at "-35 -2 38"

$AirStrike::PayLoad[Warthog,5] = "ASNapalmBomb";
$AirStrike::PayLoadReleaseNum[Warthog,5] = 1;
$AirStrike::TMinusTime[Warthog,5] = 0;
$AirStrike::WPTollerance[Warthog,5] = 10;

$AS::C=0;
// Approach
$AirStrike::Path[Warthog,5,$AS::C] = "400 0 100";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.05; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "300 0 100";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AirStrike::PathFunction[Warthog,5,$AS::C] = "Extraction::HurtMe(%this);";$AS::C++;

// Canyon
// Fire/aimup
// Above bridge
$AirStrike::Path[Warthog,5,$AS::C] = "-0 0 50";			$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-75 -10 -15";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.25; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-110 -20 -10";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-250 30 0";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-300 5 -5";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.25; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-375 0 -15";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15;  $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-475 5 -5";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AirStrike::PathFunction[Warthog,5,$AS::C] = "Extraction::GetAim(%this);";$AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-565 -5 -5";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.15; $AirStrike::PathMarked[Warthog,5] = $AS::C; $AirStrike::PathFire[Warthog,5,$AS::C] = true; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-750 0 50";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.25; $AS::C++;
$AirStrike::Path[Warthog,5,$AS::C] = "-2100 0 100";		$AirStrike::PathRotChange[Warthog,5,$AS::C] = 0.05; $AirStrike::PathExit[Warthog,5,$AS::C] = true; $AS::C++;

// Go home


$AS::C[Warthog,5]=$AS::C;

