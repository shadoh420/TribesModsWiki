// ______________________________________________________________
//|                                                              |
//| This file should be called MiniMod.InteriorLight.cs          |
//|______________________________________________________________|
//|                                					     |
//| Put the following line JUST BELOW your InteriorLight.cs line |
//| in your sever.cs file.                                       |
//|                                                              |
//| exec("plugins\\MiniMod.InteriorLight.cs");                   |
//|______________________________________________________________|
//|                                                              |
//| Notice to all you mod makers and scriptors alike. I do       |
//| encourage the use of My work to be used in anyone's mods     |
//| or scripts. All I ask if that you give me credits within     |
//| the .cs files. If you add something please put in the        |
//| credits as to whom made it and/or modified it. I intend      |
//| this to be a combined effort of anyone whom wishes to add    |
//| stuff to it. (Its a community thing.) :)                     |
//|                                                              |
//| Sincerly,                                                    |
//|         Dewy (Creater of the MiniMod concept.)               |
//|                                                              |
//|         http://www.planetstarsiege.com/minimod               |
//|______________________________________________________________|
//|										     |
//| The following command is only used to keep the file from     |
//| displaying errors when the file has no plugins listed in it. |
//|                                                              |
//| You can disable it if you wish. (Its a do nothing command.)  |
//|______________________________________________________________|

echo("MiniMod: Loading plugins for InteriorLight.cs");

//_______________________________________________________________
//|                                                              |
//| The following lines will be executed when Tribes executes    |
//| the "server.cs" file.                                        |
//|______________________________________________________________|

// This is where you add your stuff. :)

%file = File::findFirst("plugins\\*.InteriorLight.cs");
for(%i = 0; %file != ""; %file = File::findNext("plugins\\*.InteriorLight.cs"))
exec(%file);
%i++;


