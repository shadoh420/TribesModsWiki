// amadeus code whored down to T1

messageall(1,"Grappling hook v.8 -28june");
messageall(1,"Impulse = distance * mass * 0.5. Rope scale = 1.00, ");
echo("Grappling hook v.8 -28june");
//Tribes 1 version of vectorCross -Plasmatic
function Vector::Cross(%vecA, %vecB)
{
	%Ax = getWord(%vecA, 0);
	%Ay = getWord(%vecA, 1);
	%Az = getWord(%vecA, 2);
	
	%Bx = getWord(%vecB, 0);
	%By = getWord(%vecB, 1);
	%Bz = getWord(%vecB, 2);	
		
	%x = %Ay * %Bz - %By * %Az;
	%y = %Az * %Bx - %Bz * %Ax;
	%z = %Ax * %By - %Bx * %Ay;
	
	return %x@" "@%y@" "@%z;	
}
//Tribes 1 version of vectorScale -Plasmatic
function Vector::scale(%vec,%mult)
{
	%x = getWord(%vec, 0) * %mult;
	%y = getWord(%vec, 1) * %mult;
	%z = getWord(%vec, 2) * %mult;
	
	return %x@" "@%y@" "@%z;		
}
function mABS(%value)
{
	if(%value < 0)
		return -%value;
	else return %value;
}
function Vector::floor(%force)
{
	return floor(getword(%force,0))@" "@floor(getword(%force,1))@" "@floor(getword(%force,2));	
}
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
				if(%dist > %ropelength)	//stretching
				{	
					// Reduce the velocity in the dir of rope pull by impulsing the other direction.
					// we're allowing Tribes to handle the rest.. -Plasmatic
					%mass = (Player::getArmor(%player)).mass;	// light = 9, med = 13, henry = 16
					%vec = vector::sub(%anchorPos,%playerpos);
					%vel = Item::GetVelocity(%player);
					%velScalar = vector::getdistance(%vel,"0 0 0");
					%veldot = mabs(vector::dot(%vel,%vec));
					%velNorm = vector::normalize(%vel);
					%vecNorm = vector::normalize(%vec);
					%cross = vector::scale(vector::normalize(vector::cross(%vel,%vec)),10);
					
					%bias = 50;
					%dir = vector::normalize(vector::add(vector::scale(%vecnorm,%bias), %velnorm));
	
					%dot = vector::dot(%vec,%vel);
					
					
					
							
			//		%x = %mass * getWord(%vec, 0) * 0.05 *%bias;	//0.0555;		//sideways
			//		%y = %mass * getWord(%vec, 1) * 0.05 *%bias;	//0.0555;		//sideways
			//		%z = %mass * getWord(%vec, 2) * 0.05 *%bias;	//0.0769;		//up, down
					
					%ropeforce = vector::scale(%vecnorm, 0.05 *%mass * (%dist - %ropelength + 5));		//%x@" "@%y@" "@%z;
					%speedforce = vector::scale(%dir,%veldot/10);
					
					if(%veldot>1000)
						%veldot = 1000;
					
					%dotforce = vector::scale(vector::normalize(%vec),%veldot / 10);
				//	%force = vector::add(%ropeforce,%dotforce);
				
					%force = vector::add(%ropeforce,%speedforce);
					
				//	Item::setvelocity(%player,vector::scale(%dir,10));
					
					if(%velscalar > 0.125)
					{
						Player::applyImpulse(%player,%force);
				//	if(!$dedicated)
		bottomprint(Player::getclient(%player),"<jc>ropeforce"@vector::floor(%ropeforce)@", speedforce"@vector::floor(%speedforce)@", vec"@vector::floor(vector::scale(%vec,10))@", vel"@vector::floor(%vel)@", dir"@vector::floor(%dir)@", velscalar"@%velscalar@", veldot"@floor(%veldot));			
			
						
						
					}
						
				//	GameBase::setRotation(%player,getWord(%vec, 0)@" "@getWord(%vec, 1)@" "@);	
						
						
			//		if(getObjectType(%anchor) == "Player")
			//		{
			//			%force = -%x * 0.125@" "@-%y * 0.125@" "@-%z * 0.125;
			//			Player::applyImpulse(%anchor,%force);	
			//		}								
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
	
	