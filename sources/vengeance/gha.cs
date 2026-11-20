messageall(1,"Grappling hook v.1 -26may");
messageall(1,"Impulse = distance * 0.5. Rope scale = 1.0, ");
echo("Grappling hook v.1 -26may");
function GrapplingHook::Swing(%player)
{
	//26may
	if(%player.Grapple)
	{
		if(Player::getMountedItem(%player,0) == GrapplingHook)
		{
		//	echo("swing!!");
		
		//	%anchorPos = %player.GrapplePos;
			%anchor = %player.anchor;
			%anchorPos = GameBase::getPosition(%anchor);
					
			%ropelength = %player.GrappleLength;
			%playerpos = GameBase::getPosition(%player);
			if(vector::getdistance(%anchorPos,%playerpos) > %ropelength)	//stretching
			{	
				//Hmm, lets reduce the velocity in the dir of rope pull by impulsing the other direction.
	
				%x = 0.5;
				%y = 0.5;
				%z = 0.75;		//up, down
				%elasticity = %x@" "@%y@" "@%z;
				
				%vec = vector::sub(%anchorPos,%playerpos);
				Player::applyImpulse(%player,vector::multiply(%vec,%elasticity));
			}
			schedule("GrapplingHook::Swing("@%player@");",0.05);
		}
		else
		{
			%player.Grapple = false;
			Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");		
			%anchor = %player.anchor;
			deleteobject(%anchor);			
		}
	}
	else
	{	
		%anchor = %player.anchor;
		deleteobject(%anchor);
	}
}
