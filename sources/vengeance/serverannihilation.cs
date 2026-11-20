
// moved to serveritemusage.cs
//	// has to be the same as the mod folder name.. 
//	$modList = "Vengeance";  	// What shows up in server list. -plasmatic
//	
//	$ModVersion = "1.0 Beta";	//9/6/2003 7:51AM		// BETA";
//	$betaBuildNumber = "";			//"11.02.02";



echo("+++++ Starting Annihilation Loadin +++++");


// 	Load in all the .cs files in the folder path.  -Plasmatic
// 	Rip like a twister straight through your trailer.
function ExecFiles(%folder)
{
	echo(">> Loading "@%folder@" folder.....");
	
	//	Damn find first function finds the last in alphabetical order... -Plasmatic
 	%file = File::findFirst(%folder@"\\*.cs");
	while(%file != "")
	{
		if(string::ICompare(file::getbase(%file), %folder) == 0)	// Using ICompare to fudge around case differences...
			exec(%file);	//nail the %folder / %folder file first, if it exists... -Plasmatic
		else
			%file[%c++] = %file;
		%file = File::findNext(%folder@"\\*.cs");
	}
	%file[%c++] = File::findNext(%folder@"\\*.cs");	//don't forget the first file, bah... -Plas	
	
	// spin backwards..
	while(%c-- > 0)
		exec(%file[%c]);
		
	echo("<< "@%folder@" finished.");	
}


	// Sounds before Explosions before Projectiles. ALWAYS!! -Plasmatic
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
// Generics...	
	exec(Item);
	exec(Marker);
	exec(Trigger);		
	ExecFiles(admin);

// Brand Name...
	ExecFiles(Armor);
	ExecFiles(Weapon);
	ExecFiles(Pack);
	ExecFiles(Turret);
	ExecFiles(Station);
	ExecFiles(Vehicle);
	
	ExecFiles(Deployable);	
	ExecFiles(Misc);	
	
	exec(comchat);	//moved here from game.cs No need to redefine these functions every *&^%ing mission load -Plasmatic 3.0
	exec(Player);
		
	exec(StaticShape);
	
	exec(Moveable);
	exec(Sensor);

	exec(AI);
	exec(InteriorLight);

	exec(ServerItemUsage);	
	
	exec(HappyBreaker);


		
// Let the server roll. -Plasmatic
	