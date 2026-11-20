// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

function Interior::lightOn(%int, %light)
{
   Interior::setLightTime(%int, %light, 0.5);
}

function Interior::lightOff(%int, %light)
{
   Interior::setLightTime(%int, %light, 0);
}

