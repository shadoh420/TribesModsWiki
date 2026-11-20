	$ShieldRot[1] = "0 0 0";                                  	   //- rotation aim forward
	$ShieldRot[2] = "0 0 3.141592654";   	   //- rotation aim back
	$ShieldRot[3] = "0 0 -1.570796327";  	   //- rotation aim left
	$ShieldRot[4] = "0 0 1.570796327";   	   //- rotation aim right
	$ShieldRot[5] = "1.570796327 0 0";   	   //- rotation aim up
	$ShieldRot[6] = "-1.570796327 0 0";  	   //- rotation aim down
	$ShieldRot[7] = "-0.7853981635 0 0";		   //- rotation aim down/forward
	$ShieldRot[8] = "0.7853981635 0 0";  	   //- rotation aim up/forward
	$ShieldRot[9] = "-3.9269908175 0 0";            //- rotation aim down/back
	$ShieldRot[10] = "3.9269908175 0 0";             //- rotation aim up/back
	$ShieldRot[11] = "0 0 -0.7853981635";            //- rotation aim left/forward
	$ShieldRot[12] = "0 0 0.7853981635";             //- rotation aim right/forward
	$ShieldRot[13] = "0 0 -3.9269908175";            //- rotation aim left/back
	$ShieldRot[14] = "0 0 3.9269908175";             //- rotation aim right/back
	$ShieldRot[15] = "1.570796327 0.7853981635 0";   //- rotation aim up/right
	$ShieldRot[16] = "-1.570796327 0.7853981635 0";  //- rotation aim down/right
	$ShieldRot[17] = "1.570796327 -0.7853981635 0";  //- rotation aim up/left
	$ShieldRot[18] = "-1.570796327 -0.7853981635 0"; //- rotation aim down/left
	
	for(%z = 1; %z <=18; %z++)
	{
	%D = vector::add("0.0 0.2 -0.25", Vector::getfromrot($ShieldRot[%z], 0.5));
	%x = getword(%D, 0)*0.8;
	%y = getword(%D, 1)*0.75;
	%q = getword(%D, 2)*1.75;
	$SDX[%z] = %x;
	$SDY[%z] = %y; 
	$SDZ[%z] = %q;
	$SRX[%z] = getword($ShieldRot[%z], 0);
	$SRY[%z] = getword($ShieldRot[%z], 1);
	$SRZ[%z] = getword($ShieldRot[%z], 2);
	}

	$ShieldRotB[1] = "{0, 0, 0}"; 	   //- rotation aim forward
	$ShieldRotB[2] = "{0, 0, 3.141592654}";   	   //- rotation aim back
	$ShieldRotB[3] = "{0, 0, -1.570796327}";  	   //- rotation aim left
	$ShieldRotB[4] = "{0, 0, 1.570796327}";   	   //- rotation aim right
	$ShieldRotB[5] = "{1.570796327, 0, 0}";   	   //- rotation aim up
	$ShieldRotB[6] = "{-1.570796327, 0, 0}";  	   //- rotation aim down
	$ShieldRotB[7] = "{-0.7853981635, 0, 0}";		   //- rotation aim down/forward
	$ShieldRotB[8] = "{0.7853981635, 0, 0}";  	   //- rotation aim up/forward
	$ShieldRotB[9] = "{-3.9269908175, 0, 0}";            //- rotation aim down/back
	$ShieldRotB[10] = "{3.9269908175, 0, 0}";             //- rotation aim up/back
	$ShieldRotB[11] = "{0, 0, -0.7853981635}";            //- rotation aim left/forward
	$ShieldRotB[12] = "{0, 0, 0.7853981635}";             //- rotation aim right/forward
	$ShieldRotB[13] = "{0, 0, -3.9269908175}";            //- rotation aim left/back
	$ShieldRotB[14] = "{0, 0, 3.9269908175}";             //- rotation aim right/back
	$ShieldRotB[15] = "{1.570796327, 0.7853981635, 0}";  //- rotation aim up/right
	$ShieldRotB[16] = "{-1.570796327, 0.7853981635, 0}";  //- rotation aim down/right
	$ShieldRotB[17] = "{1.570796327, -0.7853981635, 0}";  //- rotation aim up/left
	$ShieldRotB[18] = "{-1.570796327, -0.7853981635, 0}"; //- rotation aim down/left
$ShieldShape = Shield;
$SCount = 1;


ItemImageData CenterI{ shapeFile = "dirArrows"; 

mountOffset = {0, 0, 0}; 
mountRotation = {0, 0, 0}; 
};

ItemData Center{ imageType = CenterI; };


ItemImageData MoveI{ shapeFile = "dirArrows"; 

mountOffset = {0, 0.2, -0.2}; 
mountRotation = {0, 0, 0}; 
};

ItemData Move{ imageType = MoveI; };

ItemImageData sI1{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S1{ imageType = SI1; }; $SCount++;

ItemImageData sI2{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S2{ imageType = SI2; }; $SCount++;

ItemImageData sI3{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S3{ imageType = SI3; }; $SCount++;

ItemImageData sI4{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S4{ imageType = SI4; }; $SCount++;

ItemImageData sI5{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S5{ imageType = SI5; }; $SCount++;

ItemImageData sI6{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S6{ imageType = SI6; }; $SCount++;

ItemImageData sI7{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S7{ imageType = SI7; }; $SCount++;

ItemImageData sI8{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S8{ imageType = SI8; }; $SCount++;

ItemImageData sI9{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S9{ imageType = SI9; }; $SCount++;

ItemImageData sI10{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S10{ imageType = SI10; }; $SCount++;

ItemImageData sI11{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S11{ imageType = SI11; }; $SCount++;

ItemImageData sI12{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S12{ imageType = SI12; }; $SCount++;

ItemImageData sI13{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S13{ imageType = SI13; }; $SCount++;

ItemImageData sI14{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S14{ imageType = SI14; }; $SCount++;

ItemImageData sI15{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S15{ imageType = SI15; }; $SCount++;

ItemImageData sI16{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S16{ imageType = SI16; }; $SCount++;

ItemImageData sI17{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S17{ imageType = SI17; }; $SCount++;

ItemImageData sI18{ shapeFile = $ShieldShape; mountOffset = {$SDX[$SCount], $SDY[$SCount], $SDZ[$SCount]}; mountRotation = {$SRX[$SCount], $SRY[$SCount], $SRZ[$SCount]}; };
ItemData S18{ imageType = SI18; }; $SCount++;


