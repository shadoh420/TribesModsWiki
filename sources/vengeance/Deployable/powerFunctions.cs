//------------------------------------------------------------------------
// Power Grid Functions -plasmatic 2.3
//------------------------------------------------------------------------
//

$Power::Range[Generator] = 400;
$Power::Range[PortGenerator] = 300;
$Power::Range[SolarPanel] = 200;

$Power::Range[PortableGenerator] = 300;
$Power::Range[PortableSolar] = 200;

// for mobile inventory, but will work with other deployables that need external power.. -plasmatic 2.3 power
function Ann::PowerTap(%this)
{
	//echo("Ann::PowerTap"@GameBase::getDamageState(%this));
	if(GameBase::getDamageState(%this) == "0" || GameBase::isPowered(%this))
		return;	
	echo("cycling power source for "@GameBase::getDataName(%this).description@" #"@%this);
	%team = GameBase::getteam(%this);
	%Pos = GameBase::getPosition(%this);
	for(%i = 0; %i < 200; %i++)
	{
		%obj = getObjectByTargetIndex(%i);
		%data = GameBase::getDataName(%obj);		
		if(%data.className == Generator && GameBase::getteam(%obj) == %team && GameBase::isPowered(%obj))
		{
			%GenPos = GameBase::getPosition(%obj);
			//echo("Found Gen "@%data);
			if(Vector::getDistance(%Pos,%GenPos) <= $Power::Range[%data])
			{
				%group = getGroup(%obj);
				addToSet(%group, %this);
				echo("Found power, adding "@%this@" to group "@%group);
				%team = GameBase::getTeam(%this);
				DropshipTeamMessage(%team, 3, "Power found for "@GameBase::getDataName(%this).description@" #"@%this@".");	
				return;				
			}
		}		
	}
	schedule("Ann::PowerTap("@%this@");",5);				
}

function Ann::Powering(%this,%power)
{		
	%team = GameBase::getTeam(%this);
	%data = GameBase::getDataName(%this);
	echo("checking "@%data.description@"'s power range");
	%Pos = GameBase::getPosition(%this);
	for(%i = 0; %i < 200; %i++)
	{
		%obj = getObjectByTargetIndex(%i);
		%objData = GameBase::getDataName(%obj);			
		%class = %objData.className;
		%state = GameBase::getDamageState(%obj);	
		if(%class == "Generator")
		{ 
			%Objteam = GameBase::getTeam(%obj);
			if(%Objteam == %team)
			{ 
				%dist = Vector::getDistance(%Pos,%ObjPos);
				if(%data == PortableGenerator || (%dist <= $Power::Range[%data] || !%power))
					%obj.PortGenPower = %power;
				else if(%data == PortableSolar || (%dist <= $Power::Range[%data] || !%power))	
					%obj.PortSolarPower = %power;
					
				%ObjPos = GameBase::getPosition(%obj);
				if(%state != "Enabled")
				{
					if(!%power)
					{
						if(%obj.PortGenPower != true && %obj.PortSolarPower != true)
						{
							GameBase::generatePower(%obj, false);
							echo("Removing power to "@%objdata.description@" team "@%objTeam);
						}
						else
							echo("disabled "@%objdata.description@" still powered by other backup gen");
					}
					else 
					{
						%dist = Vector::getDistance(%Pos,%ObjPos);
						if(%dist <= $Power::Range[%data])
						{
							GameBase::generatePower(%obj, true);
							echo("Powering "@%objdata.description@" #"@%obj@" team "@%objTeam@" with "@%data.description);				
							
						}
						else
							echo(%objdata.description@" team "@%objTeam@" out of "@%data.description@"'s range.");						
					}	
				}
				echo("Reinforcing "@%objdata.description@" #"@%obj@" team "@%objTeam@" with "@%data.description);			
			}
		}		
	}
}

