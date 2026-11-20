// - = - = - = - = - = - = - = - = - = - = - = - \\
//      U l t r a  R e n e g a d e s  V X E      \\
// - = - = - = - = - = - = - = - = - = - = - = - \\
//interiorLight.cs

function Interior::lightOn(%int, %light)
{
   Interior::setLightTime(%int, %light, 0.5);
}

function Interior::lightOff(%int, %light)
{
   Interior::setLightTime(%int, %light, 0);
}

