// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt

function registervolume( %VolName )
{
	if( %VolName == "")
	{
		echo("registervolume volumename");
	}
	else
	{
		if( focusServer )
		{
			%Name = strcat("MissionGroup\\Volumes\\", %VolName);
			if( isObject( %Name) )
			{
			//		
			}
			else
			{
				%Volume = strcat(%VolName, ".vol");
				newObject( %VolName, SimVolume, %Volume );
				addToSet( "MissionGroup\\Volumes", %VolName);
			}
			focusClient();
		}
	}
}