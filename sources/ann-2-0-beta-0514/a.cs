// Plasmatics super secret test file
// for testing purposes only

// repositions player with a defined vector
function a(%client){
	%player = Client::getOwnedObject(%client);
	%prot =GameBase::getRotation(%player);
	%pos = GameBase::getPosition(%client);
	echo("old pos  ",%pos);
	%vec = "2 4 1";
	%vec = rotateVector(%vec,%prot);
	echo("rotated vec ",%vec);
	%newloc = vector::add(%vec,%pos);	
	echo("new pos  ",%newloc);
	GameBase::SetPosition(%client, %newloc);
	}

// rotates around the z axis only
// for player rotations -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
// reduce angle to the correct range
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
// break vector down to components
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vec3= getWord(%vec,2);
	%vc = %vec2;
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5); 
// calculate offset to left or right
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
// put it back together with new offset
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
// calculate and add forward and vertical components
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}

