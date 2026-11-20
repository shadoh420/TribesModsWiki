// Player Info by Plasmatic 1/30/2005 2:45AM
// This is an extention of the Ip Logger, and will replace it eventually. 
// This is a lot nicer on Tribes memory and stability. 

function Ann::PlayerInfo::Connect(%client)
{
//	echo("player Info?!! ZOMG!@@!##1`q!");

	%transport = Client::getTransportAddress(%client);
	%ip = Ann::ipCut(%transport);

	if(%ip!="")
	{
		schedule("Ann::PlayerInfo::Saves("@%client@", "@%transport@");",18000);	//5 mins between saves.
		
		%address = Ann::Replace(%ip, ".", ":");	//"IP"@Ann::Replace(%ip, ".", ":");
		%clname = client::getName(%client);
		
		%file = "Z" @ %ip @ ".cs";	// no ':'s in windows file names. 
	
	// Tribes doesn't like xp file permissions and has path issues.... 
	// I'd really like to shove this crap to a new directory. -Plasmatic	
		
		if(isFile("Temp\\"@%file)) 
		{			
		//	echo(%file@" found.");
			// push into sys memory
			exec(%file);	
			
			//now we parse this crap up
			%more = %address@":name";
			%nameString = $annInfo::[%more];	//$annInfo::[%address];	
			
			if(Ann::StrLen(%nameString)>950)
				%namestring = string::getsubstr(%namestring,0,900);
				
				
		//	echo("found an existing name");		
			if(%nameString == %clname)	//!string::ICompare(%nameString,%clname) == 0)
			{
				%adminmessage = %clname@" Has connected before, only one name saved for this IP.";
				%names = %namestring;	
			}
			else
			{
				if(string::findSubStr(%nameString, "~") == 0)
				{
					// corrupt file... Remove ~ at beginning of string.
					// This happens when a file is cleared accidently. 
					// Shouldn't happen anymore.
					%namestring = string::getsubstr(%namestring,1,900);
					$annInfo::[%more] = %nameString;
					Ann::PlayerInfo::VarSet(%file, %address, "name", %nameString);
					%newname = true;	// not really new, but we're changing it.
				}
				else if(String::findSubStr(%nameString, "~") > 0)
				{		
					//check other names here.. code gnomes, do your work..
					%names = Ann::Replace(%namestring, "~", ", ");
					if(string::findSubStr(%nameString, %clname) != -1)
					{
				//		echo("found clients name, not changing");
						%adminmessage = %clname@"'s IP Has connected before as: "@%names;	
					}
					else
					{
				//		echo("adding new name to list");
						%nameString = %nameString@"~"@%clname;	
						%adminmessage = %clname@"'s IP Has connected before as: "@%names;
						Ann::PlayerInfo::VarSet(%file, %address, "name", %nameString);
						%newname = true;
					}				
				}
				else
				{
			//		echo("adding new name to list");
					if(%nameString != "")
						%nameString = %nameString@"~"@%clname;
					else
						%nameString = %clname;
					%adminmessage = %clname@"'s IP Has connected before as: "@%namestring;						
					Ann::PlayerInfo::VarSet(%file, %address, "name", %nameString);
					%newname = true;
				}			
			}

			%more = %address@":Tkills";
			%client.TKills = $annInfo::[%more];
			
			%more = %address@":TDeaths";
			%client.TDeaths = $annInfo::[%more];			
				
		}
		else
		{
			// first connect. 
		//	echo("Creating "@%file@", dumping to Temp\\");
			Ann::PlayerInfo::VarSet(%file, %address, "name", %clname);
			%newname = true;
			%adminmessage = %clname@"'s IP hasn't connected before.";	
			
			//Export name
			%export = "$anninfo::"@%address@":*";			
			export(%export, "Temp\\"@ %file, false);	//true = append	
			evalsearchpath();	
			$modList = "Annihilation";
				
					
		}
	}
	%adminmessage = %ip@" "@%adminmessage;
	echo(%adminmessage);
	admin::BPmessage(%adminmessage);
	$Client::names[%client] = %names;	//we can't use %client. because the memory isn't allocated yet.. 
	if(%newname)	
		Ann::PlayerInfo::Export(%client);	
}

function Ann::PlayerInfo::Export(%client)
{
	%transport = Client::getTransportAddress(%client);
	%ip = Ann::ipCut(%transport);

	if(%ip!="")
	{
		%address = Ann::Replace(%ip, ".", ":");	
		
	//	echo("Store player Info?!! ZOMG!@@!##1`q!");
		%ip = Ann::ipCut(%transport);

		%address = Ann::Replace(%ip, ".", ":");	//"IP"@Ann::Replace(%ip, ".", ":");
		%clname = client::getName(%client);
			
		%file = "Z" @ %ip @ ".cs";
				
		if(isFile("Temp\\"@%file)) 
		{
			//set our saved info vars.
			Ann::PlayerInfo::VarSet(%file, %address, "TKills", %client.TKills);
			Ann::PlayerInfo::VarSet(%file, %address, "TDeaths", %client.TDeaths);
			
			//Export them all.
			%export = "$anninfo::"@%address@":*";			
			export(%export, "Temp\\"@ %file, false);	//true = append
											
		}
	}	
}

function Ann::PlayerInfo::VarSet(%file, %address, %variableName, %value)
{
	%more = %address@":"@%variableName;
	$annInfo::[%more] = %value;
	%export = "$anninfo::"@%more;
//	export(%export,"Temp\\"@ %file, true);	
//	echo("Setting " @ %export @ " = " @ %value ); 	
}

function Ann::PlayerInfo::Disconnect(%client)
{
	Ann::PlayerInfo::Export(%client);
	
	%transport = Client::getTransportAddress(%client);
	%ip = Ann::ipCut(%transport);

	if(%ip!="")
	{
		%address = Ann::Replace(%ip, ".", ":");	
		// They left, delete crap. 
		%DUMP = "$annInfo::" @ %address @ "*";
		deleteVariables(%dump);			
		
	}	
}

function Ann::PlayerInfo::Saves(%client,%trans)
{
	echo("Save player info");
	%transport = Client::getTransportAddress(%client);
	if(%trans == %transport)
	{
		Ann::PlayerInfo::Export(%client);
		schedule("Ann::PlayerInfo::Saves("@%client@", "@%transport@");",18000);	//5 mins between saves.
	}	
	
}
