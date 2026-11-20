echo( "starting Logger" );

if ($Logger::logRemote == "")
   $Logger::logRemote = 0;

function Logger::getObjectStr(%object)
{
//	echo( "in GetObjectStr" );
	%str = "obj:" @ %object;

	%MaxItems = getNumItems();
	if ((%object >= 0) && (%object < %MaxItems))
	{
		// Need Item::getItemData(%object) if it is a pack of some sort, etc
		%name = getItemData(%object);
		%str = "itm:" @ %object @ " (" @ %name @ ")";
	}
	else if (%object >= 0)
	{
		%otype = getObjectType(%object);
		if(%otype == "Player")
		{
			%client = Player::getClient(%object); // -1 = failure
			if (%client != -1)
			{
				%cname = escapeString(Client::getName(%client));
				%str = "pl:" @ %object @ " (cl:" @ %client @ ", \"" @ %cname @ "\")";
			}
			else
			{
				%str = "pl:" @ %object @ " (cl:" @ %client @ ")";
			}
		}
		else if(%otype == "Net::PacketStream")	// Client
		{
			%client = %object;
			if (%client != -1)
			{
				%aname = GameBase::getDataName(%object); // Data name is the armor
				%cname = escapeString(Client::getName(%client));
				%str = "cl:" @ %client @ " (\"" @ %cname @ "\" armor:" @ %aname @ ")";
			}
			else
			{
				%str = "cl:" @ %client;
			}
		}
		else if(%otype == False)	// Client
		{
			%str = "txt:" @ %object;
		}
		else
		{
			%name = GameBase::getDataName(%object);
			%client = GameBase::getOwnerClient(%object); // -1 = failure
			if (%client != -1)
			{
				%cname = escapeString(Client::getName(%client));
				%str = "obj:" @ %object @ " (\"" @ %name @ "\" otype: \"" @ %otype @ "\" from cl:" @ %client @ ", \"" @ %cname @ "\")";
			}
			else
			{
				%str = "obj:" @ %object @ " (\"" @ %name @ "\" otype: \"" @ %otype @ "\" from cl:" @ %client @ ")";
			}
		}
	}
	else
	{
		%str = "obj:" @ %object;
	}
	return %str;
}

function Logger::getItemStr(%object)
{
//	echo( "in GetObjectStr" );
	%str = "obj:" @ %object;

	%MaxItems = getNumItems();
	if ((%object >= 0) && (%object < %MaxItems))
	{
		// Need Item::getItemData(%object) if it is a pack of some sort, etc
		%name = getItemData(%object);
		%str = "itm:" @ %object @ " (" @ %name @ ")";
	}
	else
	{
		%str = "txt:" @ %object;
	}
	return %str;
}

function Logger::getClientStr(%client)
{
//	echo( "in GetClientStr" );
	%str = "cl:" @ %client;

	if (%client != -1)
	{
		%cname = escapeString(Client::getName(%client));
		%str = "cl:" @ %client @ " (\"" @ %cname @ "\")";
	}
	else
	{
		%str = "cl:" @ %client;
	}
	return %str;
}

function Logger::trimIP(%ipstr)
{
   // IP:#.#.#.#:#
   %ip = String::getSubStr(%ipstr,3,16);
   for (%i=6;String::getSubStr(%ip,%i,1)!="";%i++)
   {
      if (String::getSubStr(%ip,%i,1)==":")
      {
         return String::getSubStr(%ip,0, %i);
      }
   }
   return %ip;
}

$PlayerList::newUser = "";
function Logger::showAlias(%client,%tellto)
{
   %name = Client::getName(%client);
   %ip = Logger::trimIP(Client::getTransportAddress(%client));

   // Find the IP address
   %found = 0;
   for (%i=0; $PlayerList::users[%i,0]!="";%i++)
   {
      if($PlayerList::users[%i,0] == %ip)
      {
         // Found the name
         %found = 1;
         break;
      }
   }

   if (%found)
   {
     // Find the player name in the IP address
     %found = 0;
     for (%j=1; $PlayerList::users[%i,%j]!="";%j++)
     {
        if($PlayerList::users[%i,%j] == %name)
        {
           // Found the name
           %found = 1;
           break;
        }
     }

     // List all other names for this IP
     for (%k=1; $PlayerList::users[%i,%k]!="";%k++)
     {
        if(%j != %k)
        {
           %message = %name @ " alias " @ $PlayerList::users[%i,%k];
           if (%tellto == 0)
           {
              Logger::LogMessage(%client,"ALIAS",%message);
              messageAll(0, %message );
           }
           else
           {
              Client::sendMessage(%tellto,0,%message);
           }
        }
     }
   }
   else
   {
     if (%tellto == 0)
     {
        Logger::LogMessage(%client,"ALIAS",%message);
        messageAll(0, %message );
     }
     else
     {
        Client::sendMessage(%tellto,0,%message);
     }
   }
}

function Logger::LogNewClient(%client)
{
   if($DebugMsg) echo("in Log New Client" );

   $ClientDataFile = "config\\UserList" @ $Server::Port @ ".cs";
   $IPDataFile = "IPList" @ $Server::Port;

   if ($PlayerList::users[0,0] == "")
   {
      Logger::LogMessage(%client,"EXEC","loading users");
      exec($IPDataFile);
   }

   %name = Client::getName(%client);
   %ip = Logger::trimIP(Client::getTransportAddress(%client));

   $PlayerList::newUser = %ip @ " " @ escapeString(%name) @ " " @ "cl:" @ %client;
   export("PlayerList::newUser", $ClientDataFile, true);

   // Find the IP address
   %found = 0;
   for (%i=0; $PlayerList::users[%i,0]!="";%i++)
   {
      if($PlayerList::users[%i,0] == %ip)
      {
         // Found the name
         %found = 1;
         break;
      }
   }

   if (%found)
   {
     // Find the player name in the IP address
     %found = 0;
     for (%j=1; $PlayerList::users[%i,%j]!="";%j++)
     {
        if($PlayerList::users[%i,%j] == %name)
        {
           // Found the name
           %found = 1;
           break;
        }
     }

     if (!%found)
     {
      echo( "NEW NAME: " @ $PlayerList::newUser );
      $PlayerList::users[%i,%j] = %name;
      export("PlayerList::users*", "config\\" @ $IPDataFile @ ".cs", false);
     }
   }
   else
   {
      echo( "NEW IP: " @ $PlayerList::newUser );
      $PlayerList::users[%i,0] = %ip;
      $PlayerList::users[%i,1] = %name;
      export("PlayerList::users*", "config\\" @ $IPDataFile @ ".cs", false);
   }
   Logger::showAlias(%client,0);
}

$MessageList::newMessage = "";

function Logger::LogMessage(%client,%type,%message)
{
   $ClientDataFile = "config\\MessageList" @ $Server::Port @ ".cs";

   $MessageList::newMessage = %type @ " " @ Logger::getClientStr(%client)
	@ " \"" @ escapeString( %message ) @ "\"";
   echo( $MessageList::newMessage );

   export("MessageList::newMessage", $ClientDataFile, true);
}

function cleanupItem(%turret)
{
   %type = getObjectType(%turret);
   %name = GameBase::getDataName(%turret);
   if($DebugMsg) echo("Deleting " @ %type @ " " @ %name );

   if((%type != "SimGroup") && (%type != "SimSet"))
   {
      %turret.shieldStrength = 0;
      GameBase::setRechargeRate(%turret, 0);
      GameBase::virtual(%turret,onDeactivate);

      // Increment the number of packs available for this item
      %packName = $DItemPack[%name];

	if($DebugMsg) echo( "Pack for " @ Logger::getObjectStr(%turret) @ " is " @ %packName );

      if(%packName == "")
	{
         %packName = %turret.itemName;
	   if($DebugMsg) echo( "Pack (from object) for " @ Logger::getObjectStr(%turret) @ " is " @ %packName );
	}
      if(%packName != "")
	{
	   if($DebugMsg) echo( "Increments " @ %packName @ " packs for team " @ GameBase::getTeam(%turret) );
	   $TeamItemCount[GameBase::getTeam(%turret)@%packName]--;
	}
      
   }
   deleteObject( %turret );
}

function delSetElements(%group)
{
   if($DebugMsg) echo("Deleting set " @ %group );
   %numObjs = Group::objectCount(%group);
   for(%i=%numObjs - 1; %i>=0; %i--)
   {
      %turret = Group::getObject(%group,%i);
	%type = getObjectType(%turret);
      %name = GameBase::getDataName(%turret);
      if((%type == "SimGroup") || (%type == "SimSet"))
      {
         delSetElements(%turret);
      }
      if($DebugMsg) echo( "Deleting set element " @ %type @ " " @ %name @ " " @ %turret @ " in " @ %group );
      removeFromSet(%group, %i);
      deleteObject( %turret );
   }
}

function checkDelSetElements(%client,%group)
{
   %numObjs = Group::objectCount(%group);
   if($DebugMsg) echo( "Checking set or group " @ %group @ ", " @ %numObjs @ " items");
   for(%i=%numObjs - 1; %i>=0; %i--)
   {
      %turret = Group::getObject(%group,%i);
	%type = getObjectType(%turret);
      %name = GameBase::getDataName(%turret);
      if($DebugMsg) echo( "Checking " @ %type @ " " @ %name @ " " @ %turret @ " in " @ %group );
      if (%turret.deployer == %client)
      {
	   if((%type == "SimGroup") || (%type == "SimSet"))
         {
            delSetElements( %turret );
         }
	   if($DebugMsg) echo("Deleting object " @ getObjectType(%turret) );
         removeFromSet(%group, %i);
         cleanupItem(%turret);
      }
	else if((%type == "SimGroup") || (%type == "SimSet"))
      {
         checkDelSetElements(%client,%turret);
      }
   }
}
function delDeploys(%client)
{
   %group = "MissionCleanup";
   checkDelSetElements(%client,%group);
}