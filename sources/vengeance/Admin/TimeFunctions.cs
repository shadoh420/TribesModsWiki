

function uptime()
{


	%secondsLive = getintegertime(true)>>5;
	%minutesLive = %secondsLive/60;
	%hoursLive = %secondslive/3600;
}	
function WhatTime()
{
	echo(getintegertime(true)>>5);
	%time = getintegertime(true)>>5;	//getSimTime();
	%minutes = floor(%time / 60);
	%seconds = %Time % 60;
	while(%minutes > 60)
	{			
		%minutes = %minutes - 60;
		%hours++;
		if(%hours > 2400)
			break;
	}
	while(%hours > 24)
	{			
		%hours = %hours - 24;
		%days++;
		if(%days > 100)
			break;
	}	
	echo("Server up time: "@%days@" Days, "@%hours@":"@%minutes@":"@%seconds);
}	

function Time::getMinutes(%simTime)
{
	return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
	return %simTime % 60;
}
	