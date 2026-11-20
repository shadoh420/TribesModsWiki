// amadeus code whored down to T1

messageall(1,"Grappling hook v.7 -25june");
messageall(1,"Impulse = Amadeus code. Rope scale = 1.0, ");
echo("Grappling hook v.7 -25june");
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
function VectorProject(%vec, %target) 
{
//	%len = vector::getdistance(%target,"0 0 0");
//	%x = getWord(%vec, 0) *getWord(%target, 0) / %len;
//	%y = getWord(%vec, 1) *getWord(%target, 1) / %len;
//	%z = getWord(%vec, 2) *getWord(%target, 2) / %len;	
	
//	return %x@" "@%y@" "@%z;	
	
	// fugly.. -Plasmatic
	return ((getWord(%vec, 0)*getWord(%target, 0))
		 + (getWord(%vec, 1)*getWord(%target, 1))
		 + (getWord(%vec, 2)*getWord(%target, 2))) / vector::getdistance(%target,"0 0 0");	//VectorLen(%target);
}

unction Player::fixedGrappleSwingLoop(%player)
{
//	Whored down to Tribes 1 level by Plasmatic	

// Tribes 1 vector operators:
// Vector::dot 
// Vector::add 
// Vector::sub 
// Vector::neg 
// Vector::getFromRot 
// Vector::getDistance 
// Vector::getRotation -sticks a vector magnatude 1 perpindicular to 
// Vector::normalize

// VectorCross and vectorScale are notably absent, So we'll build our own.. -Plasmatic

	%anchor = %player.anchor;
	%SwingPos = GameBase::getPosition(%anchor);
	
	%vel = Item::getVelocity(%player);			//%player.getVelocity();
	%pos = GameBase::getPosition(%player);		//%player.getPosition();
	%rad = vector::sub(%SwingPos, %pos);	//may be reversed in T1		//VectorSub(%SwingPos, %pos);
	%dist = vector::getdistance(%rad,"0 0 0");		//VectorLen(%rad);
//	if (%dist > %player.grappleLength && vector::getdistance(Vector::Sub(%SwingPos, Vector::Add(%pos, %vel)),"0 0 0") > %player.grappleLength ) // why are we double checking this.. With position added to velocity...? -Plasmatic

	%force = VectorProject(%vel, %rad);
	%surplus = %dist - %player.grappleLength;
	%tanVel = VectorProject(%vel, Vector::Cross(%rad, Vector::Cross(%rad, %vel)));	//VectorCross(%rad, VectorCross(%rad, %vel)));
	%value = %tanVel+(getWord(%rad, 2)/%player.grappleLength)*%force;
//	%mass = %player.getDataBlock().mass;
	%mass = (Player::getArmor(%player)).mass;	// T1 light = 9, med = 13, henry = 16
					
	%vec = Vector::Scale(Vector::Normalize(%rad), (%dist / %player.grappleLength) * mAbs(%force) * %mass / 2);
	//VectorScale(VectorNormalize(%rad), (%dist / %player.grappleLength) * mAbs(%force) * %mass / 2);
	Player::applyImpulse(%player,%vec);	//%player.ApplyImpulse(%player.getPosition(), %vec);
	%force = %vec;
//	if(!$dedicated)
		bottomprint(Player::getclient(%player),"<jc>"@floor(getword(%force,0))@" "@floor(getword(%force,1))@" "@floor(getword(%force,2)));			
}
ffunction GrapplingHook::Swing(%player)
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
				if(%dist > %ropelength)	//*0.85)	//stretching
				{	
					Player::fixedGrappleSwingLoop(%player);							
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
function Vector::floor(%force)
{
	return floor(getword(%force,0))@" "@floor(getword(%force,1))@" "@floor(getword(%force,2));	
}