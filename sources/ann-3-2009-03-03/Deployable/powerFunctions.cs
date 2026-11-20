//------------------------------------------------------------------------
// Power Grid Functions -plasmatic 2.3
//------------------------------------------------------------------------
//
// Reworked and simplified 1/21/2008 3:32AM -Plasmatic


$Power::Range[Generator] = 400;
$Power::Range[PortGenerator] = 300;
$Power::Range[SolarPanel] = 200;

$Power::Range[PortableGenerator] = 300;
$Power::Range[PortableSolar] = 200;

// damn snowblind map only has one gen.. ann3 fix0r, Plasmatic 1/27/2005 4:57AM
$Power::Range[InventoryStation] = 175;
$Power::Range[CommandStation] = 150;

//added these  2/4/2008 2:51AM
$Power::Range[VehicleStation] = 150;
$Power::Range[AmmoStation] = 150;

// Power functions rewriten again 1/21/2008 4:37AM -Plasmatic

function Ann::PowerGlide(%this)
{
	//%this is a powered device	
	
	%team = GameBase::getTeam(%this);
	%data = GameBase::getDataName(%this);
	%desc = GameBase::getDataName(%this).description;
	
	if(GameBase::isPowered(%this) || %desc == shape || %desc == false || %data.className == DeployableSensor)
		return;	
	
	%firstset = %this.firstset;	
	if(%firstset && %firstset != "" && %firstset != getgroup(%this))
	{
		addToSet(%firstset, %this);	//go to your home first
		schedule("Ann::PowerGlide("@%this@");",5);	
	}
	else
	{				
	//	messageall(1,"cycling power source for "@%desc@" #"@%this);
		%team = GameBase::getteam(%this);
		%Pos = GameBase::getPosition(%this);
	
		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$StaticObjectType,%pos,600,600,600,0);
		%totalnum = Group::objectCount(%set);
		
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%data = GameBase::getDataName(%obj);	
			%objteam = GameBase::getteam(%obj);	
				
			if(%objteam == %team && GameBase::isPowered(%obj))
			{
			//	messageall(1,%desc@" #"@%this@" Found a powered "@%data@", -"@%data.className);		
					
				// Snowblind map has only one gen on team -1, 1000m below ground.. 
				// So I'm expanding the power grid to include stations. -Plasmatic
				if((%data.className == Generator || %data.className == Station))
				{	
					%GenPos = GameBase::getPosition(%obj);
					if(Vector::getDistance(%Pos,%GenPos) <= $Power::Range[%data])
					{
						if(!%firstset || %firstset == "")
							%this.firstset = getgroup(%this);
						%group = %obj.set;
						if(!%group)
							%group = getGroup(%obj);
						if(%group != -1 && %group != "")
						{
							// Found a powered base asset, move into group. 
							addToSet(%group, %this);
						//	TeamMessages(3, %team, "Linking "@GameBase::getDataName(%this).description@" power with "@%data.description);						
							
							return;	
						}
					}
				}
			}		
		}
		deleteObject(%set);
		schedule("Ann::PowerGlide("@%this@");",2 + getRandom()*5);
	}				
}
