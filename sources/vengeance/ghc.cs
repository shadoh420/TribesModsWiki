messageall(1,"Grappling hook v.3 -2june");
messageall(1,"Impulse = norm vec *distance *mass * 0.2. Rope scale = 0.95, ");
echo("Grappling hook v.2 -2june");
function GrapplingHook::Swing(%player)
{
	//2june
	if(%player.Grapple && !Player::isDead(%player))
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
				%distance = vector::getdistance(%anchorPos,%playerpos);
				%move = 1.0;	// position flag
				%threshold = 0.95;	// Impulse threshold. less that 1.0 will make rope more rigid.. -Plasmatic
				
								
				// position method
				// move the player to a closer position when they exceed rope length.
				// Tribes will keep increasing speed whenever player isn't touching ground,
				// so we need to use something to check speed also. -Plasmatic
				%tolerance = %ropelength * 10.375;
				if(%distance > %tolerance)	// stretch length
				{	
					%reelin = %distance * 0.975;			
					%vec = vector::sub(%playerpos,%anchorPos);
					%length = vector::multiply(vector::normalize(%vec),%reelin@" "@%reelin@" "@%reelin);
					%pos = vector::add(%length,%anchorPos);
					if(GameBase::testPosition(%player, %pos))
					{
						GameBase::setPosition(%player, %pos);
				//		messageall(1,"reposition");	
						%move = 1.0;	// reduce the ammount of impulse when repositioning.. 
					}
				}
				
				// elastic method	
				// Reduce the velocity in the direction of rope pull by impulsing towards hook.
				// we're allowing Tribes to handle the rest.. -Plasmatic					
				
				if(%distance > %ropelength * %threshold)	
				{	
					%mass = ((Player::getArmor(%player)).mass) * %move;	// light = 9, med = 13, henry = 16
					//Item::setVelocity(%player,Item::getVelocity(%anchor));
						%x = 0.2 * %mass;		// sideways
						%y = 0.2 * %mass;		// sideways
						%z = 0.3 * %mass;		// up and down
				//		%elasticity = %x@" "@%y@" "@%z;
					
					%force = %distance - %ropelength;
				//	%vFudge = 1.5;

					
					%vec = vector::sub(%anchorPos,%playerpos);
					%norm = vector::normalize(%vec);
			//		%vrope = vector::multiply(%norm,%ropelength@" "@%ropelength@" "@%ropelength);
			//		%stretch = vector::sub(%vec,%vrope);
			
					%impulse = vector::multiply(%norm,%force*%x@" "@%force*%y@" "@%force*%z);
				//	Bottomprint(Player::getclient(%player),"<jc>"@%impulse);
					Player::applyImpulse(%player,%impulse);
					
				}	

				if(%distance > %ropelength*10.15)	//stretching //85
				{			
				// speed method
				// more reliable than impulse, and not mass dependant... 
				// not as smooth as impulse, needs to be scheduled more often
					%playerSpeed = Item::getVelocity(%player);
					%diff = %distance - %ropelength;	
					
					%vec = vector::sub(%anchorPos,%playerpos);
					%norm = vector::normalize(%vec);
					
					%diff3 = %diff@" "@%diff@" "@%diff;
					
					%newspeed = vector::add(vector::multiply(%norm,%diff3),%playerSpeed);
				//	%newspeed = vector::add(vector::multiply(%vec,%elasticity),%playerSpeed);
					messageall(1,%playerSpeed@", "@%newspeed);
					Item::setVelocity(%player,%newspeed);		
				}
					
					
				
				
				schedule("GrapplingHook::Swing("@%player@");",0.025);
			}
			else
			{
				%player.Grapple = false;
				Client::sendMessage(Player::getclient(%player), 0, "Grapple hook dislodged.");		
				%anchor = %player.anchor;
				GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen			
				
			}
		}
		else
		{
			%player.Grapple = false;
			Client::sendMessage(Player::getclient(%player), 0, "Grapple released.");		
			%anchor = %player.anchor;
			GameBase::playSound(%player, SoundDiscReload,0);	//ForceFieldOpen
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
	
	