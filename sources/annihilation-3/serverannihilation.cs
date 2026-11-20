echo("+++++ Starting Annihilation Loadin +++++");

//	Damn find first function finds the last in alphabetical order... -Plasmatic
function ExecFiles(%folder)
{
	echo(">> Loading "@%folder@" folder.....");
	
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
	while(%c-- > 0)
		exec(%file[%c]);
		
	echo("<< "@%folder@" finished.");	
}
	//gotta load these datablocks first... 
	exec(Trigger);
	exec(Marker);
	

// Sounds before Explosions before Projectiles before Weapons...  ALWAYS!! -Plasmatic
	exec(NSound);
	exec(BaseExpData);
	exec(BaseDebrisData);
	exec(BaseProjData);
	
// Generics...	
	exec(Item);
	exec(StaticShape);
	exec(Moveable);
	exec(Sensor);
	exec(AI);		
	exec(comchat);	//moved here from game.cs... No need to redefine these functions every mission load -Plasmatic 3.0
	exec(Player);
	exec(InteriorLight);
				
// House brand...
	ExecFiles(admin);
	ExecFiles(Station);
	
// Brand Name...	
	ExecFiles(Armor);
	ExecFiles(Weapon);
	ExecFiles(Pack);
	ExecFiles(Turret);
//	ExecFiles(Station);
	ExecFiles(Vehicle);	
	ExecFiles(Deployable);
	ExecFiles(Dropship);
	ExecFiles(Probe);	
	ExecFiles(Misc);

	exec(ServerItemUsage);	
	
//	ExecFiles(Buildmod);
	
if(!$build)
	exec(HappyBreaker);
	

	exec(a);	