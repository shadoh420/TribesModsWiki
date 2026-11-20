messageall(1,"Grappling hook v.2 -29may");
messageall(1,"Impulse = distance * 0.5. Rope scale = 0.85, ");
echo("Grappling hook v.1 -29may");
function GrapplingHook::Swing(%player)
{
	//29may
	if(%player.Grapple)
	{
		if(Player::getMountedItem(%player,0) == GrapplingHook || Player::getItemCount(%player, GrapplingHook) > 0 )
		{
		//	echo("swing!!");
			%anchor = %player.anchor;
			%anchorPos = GameBase::getPosition(%anchor);
			if(%anchorPos != 0)
			{
				%ropelength = %player.GrappleLength;
				%playerpos = GameBase::getPosition(%player);
				if(vector::getdistance(%anchorPos,%playerpos) > %ropelength*0.85)	//stretching
				{	
					//Hmm, lets reduce the velocity in the dir of rope pull by impulsing the other direction.
					// we're allowing Tribes to handle the rest.. -Plasmatic
		
					%x = 0.5;		//sideways
					%y = 0.5;		//sideways
					%z = 0.65;		//up, down
					%elasticity = %x@" "@%y@" "@%z;
					
					%vec = vector::sub(%anchorPos,%playerpos);
					Player::applyImpulse(%player,vector::multiply(%vec,%elasticity));
				}
				schedule("GrapplingHook::Swing("@%player@");",0.05);
			}
			else
			{
				%player.Grapple = false;
				Client::sendMessage(Player::getclient(%player), 0, "Grapple hook dislodged.");		
				%anchor = %player.anchor;
				GameBase::playSound(%player, ForceFieldOpen,0);				
				
			}
		}
		else
		{
			%player.Grapple = false;
			Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");		
			%anchor = %player.anchor;
			GameBase::playSound(%player, ForceFieldOpen,0);
			if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
				deleteobject(%anchor);			
		}
	}
	else
	{	
		%anchor = %player.anchor;
		if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
			deleteobject(%anchor);
	}
}
	
	

