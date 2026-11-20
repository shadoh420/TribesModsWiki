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

function modify(%type, %var, %multi, %return, %nocheck) 
{ 
     %max = getNumItems();  
     for (%i = 0; %i < %max; %i = %i + 1) 
     {  
          %item = getItemData(%i); 
          if((String::findSubStr(%type.className,%name) != "-1") && (String::findSubStr(%type,%item.className) != "-1")) 
          { 
               if(!%nocheck) 
               { 
                    if(%item.imageType != "") 
                         %item = %item.imageType; 
                    if((String::findSubStr("armor",%type) != "-1") && (String::findSubStr(%type,"armor") != "-1")) 
                    { 
                         %armorType = true; 
                         %item2 = $ArmorType[Female, %item]; 
                         %item = $ArmorType[Male, %item]; 
                    } 
               } 
 
               if(!%return && %item != "") 
               { 
                    if(!$parsed[%item]) 
                    { 
                         $parsed[%item] = true; 
                         eval("parsedOld["@%item@"] = "@%item@"."@%var@";"); 
                         if(%armorType) 
                              eval("parsedOld["@%item2@"] = "@%item2@"."@%var@";"); 
                    } 
                    eval(%item@"."@%var@" = "@%multi@" * "@%item@"."@%var@";"); 
                    if(%armorType) 
                         eval(%item2@"."@%var@" = "@%multi@" * "@%item2@"."@%var@";"); 
               } 
               else if(%return && $parsed[%item]) 
               { 
                    eval(%item@"."@%var@" = "@$parsedOld[%item]@";"); 
                    if(%armorType) 
                         eval(%item2@"."@%var@" = "@$parsedOld[%item2]@";"); 
               } 
          } 
     } 
}

