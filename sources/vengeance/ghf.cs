messageall(1,"Grappling hook v.6 -6june");
messageall(1,"Impulse = distance * mass * 0.05. Rope scale = 0.85, ");
echo("Grappling hook v.6 -6june");
function GrapplingHook::Swing(%player)
{
	// 2 june 06
	%anchor = %player.anchor;
	if(%player.Grapple && !Player::isDead(%player))
	{
		
		//Player::getMountedItem(%player,0) == GrapplingHook || 
		%anchorPos = GameBase::getPosition(%anchor);
		if(%anchorPos != 0 )
		{		
			%playerpos = GameBase::getPosition(%player);
			%dist = vector::getdistance(%anchorPos,%playerpos);
			if(%dist < 200 && Player::getItemCount(%player, GrapplingHook) > 0 && Player::getclient(%player) == GameBase::getControlClient(%player))
			{
				
			//	echo("swing!! "@%dist);
				%ropelength = %player.GrappleLength;			
				if(%dist > %ropelength*0.85)	//stretching
				{	
					// Reduce the velocity in the dir of rope pull by impulsing the other direction.
					// we're allowing Tribes to handle the rest.. -Plasmatic
					%mass = (Player::getArmor(%player)).mass;	// light = 9, med = 13, henry = 16
					%vec = vector::sub(%anchorPos,%playerpos);
							
					%x = %mass * getWord(%vec, 0) * 0.05;	//0.0555;		//sideways
					%y = %mass * getWord(%vec, 1) * 0.05;	//0.0555;		//sideways
					%z = %mass * getWord(%vec, 2) * 0.075;	//0.0769;		//up, down
					%force = %x@" "@%y@" "@%z;
					
					Player::applyImpulse(%player,%force);
			
					if(getObjectType(%anchor) == "Player")
					{
						%force = -%x * 0.125@" "@-%y * 0.125@" "@-%z * 0.125;
						Player::applyImpulse(%anchor,%force);	
					}								
				}
				schedule("GrapplingHook::Swing("@%player@");",0.05);
			}
			else
			{
				%player.Grapple = false;
				Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");		
				GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen
				if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
					deleteobject(%anchor);			
			}
		}
		else
		{
			// Hook was destroyed
			%player.Grapple = false;
			Client::sendMessage(Player::getclient(%player), 0, "Grapple hook dislodged.");		
			GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen			
			
		}
	}			
	else
	{	
		
		if(getObjectType(%anchor) != "Flier" && getObjectType(%anchor) != "Player")
			deleteobject(%anchor);
	}
}