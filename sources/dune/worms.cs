// WORM TYPE I (Small, fast, vertical attack)


StaticShapeData WormPos
{
	shapeFile = "breath";
	maxDamage = 1.0;
	debrisId = defaultDebrisLarge;
	shadowDetailMask = 16;
        explosionId = debrisExpLarge;
	description = "Sandworm";
	visibleToSensor = false;
        mapFilter = 4;
        damageSkinData = "ArmorDamageSkins";
};

function wormPos::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

StaticShapeData GhostPos
{
	shapeFile = "breath";
	maxDamage = 1.0;
	debrisId = defaultDebrisLarge;
	shadowDetailMask = 16;
        explosionId = debrisExpLarge;
	description = "Sandworm";
	visibleToSensor = false;
        mapFilter = 4;
        damageSkinData = "ArmorDamageSkins";
};

function GhostPos::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}



StaticShapeData WormSegment
{
	shapeFile = "newdoor5";
	maxDamage = 1.0;
	debrisId = defaultDebrisLarge;
	shadowDetailMask = 1;
        explosionId = debrisExpLarge;
	description = "Sandworm";
	visibleToSensor = true;
        mapFilter = 1;
        damageSkinData = "ArmorDamageSkins";
};


function WormSegment::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function WormSegment::onCollision(%this,%obj)
{
	if( getObjectType(%obj)=="Player") {
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 1"), 5, 30, 30,$Worm[%this]);
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 0"), 5, 30, 30,$Worm[%this]);
	} else if ( getObjectType(%obj)=="Flier" ) {
		Vehicle::kickout(%obj,"0 0 0");
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 1"), 5, 30, 30,$Worm[%this]);
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 0"), 5, 30, 30,$Worm[%this]);
	}

}

function WormMouth::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function WormMouth::onCollision(%this,%obj)
{
	if( getObjectType(%obj)=="Player") {
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 1"), 5, 30, 30,$Worm[%this]);
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 0"), 5, 30, 30,$Worm[%this]);
	} else if ( getObjectType(%obj)=="Flier" ) {
		Vehicle::kickout(%obj,"0 0 0");
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 1"), 5, 30, 30,$Worm[%this]);
		GameBase::applyRadiusDamage(19, vector::add(gamebase::getposition(%obj), "0 0 0"), 5, 30, 30,$Worm[%this]);
	}
}


GrenadeData WormAttack2
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = knifeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 20.0; // 0.3
   damageType         = $WormDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 30.0;
   maxLevelFlightDist = 0.0;
   totalTime          = 0.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.005;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

function WormKill(%playerPosition,%worm)
{
	GameBase::applyRadiusDamage(19, vector::add(%playerPosition, "0 0 1"), 20, 30, 30,8673);
	GameBase::applyRadiusDamage(19, vector::add(%playerPosition, "0 0 0"), 20, 30, 30,8673);
}




function SandWormS::AdminAttack( %victim )
{
	
	if(Player::getClient(%victim) == -1 || !Player::getClient(%victim) || $Worm::Attacking)
		return;
	%worm = newObject("AdminSandworm", "StaticShape", "WormPos", true);

	newObject("WormStorage", SimGroup);
	addToSet("MissionCleanup","WormStorage");

	%victim = Player::getClient(%victim);
	if( getObjectType(Client::getControlObject(%victim))== "Flier" ){
		vehicle::kickout(Client::getControlObject(%victim),"0 0 0");
	}

	%position = GameBase::getPosition(%victim);
	Sandworm::onAttack(%position, %worm);
	deleteobject(%worm);
	
}

function Sandworm::createMaw( %position, %worm )
{
	for(%x = 1; %x <= 12; %x++)
	{
		%segment[%x] = newObject("Sandworm", "StaticShape", "WormSegment", true);
		
		%this = %segment[%x];
		//schedule("deleteobject(\""@%this@"\");",(8+%length));
		//schedule("$Worm::Attacking = false;",(8.1+%length));
		$Worm[%x] = %segment[%x];
		addToSet("MissionCleanup/WormStorage/WormParts", %segment[%x]);
	}
	
		
	$WormSegments = 12;

//*****MAW 1
	
	%position = Vector::add(%position, "5 0 -10");
	GameBase::setRotation(%segment[1],"0 0.7853 1.7707");
	GameBase::setPosition(%segment[1],%position);
	
	GameBase::setRotation(%segment[2],"0 -0.7853 1.3707");
	GameBase::setPosition(%segment[2],%position);

	GameBase::setRotation(%segment[7],"0 -0 1.9707");
	GameBase::setPosition(%segment[7],Vector::add(GameBase::getPosition(%segment[1]), "0 3.2 -6"));

	GameBase::setRotation(%segment[10],"0 -0 1.1707");
	GameBase::setPosition(%segment[10],Vector::add(GameBase::getPosition(%segment[2]), "0 -3.2 -6"));

	

//*****MAW 2

	%position = Vector::add(%position, "-8.5355 4.5355 0");
	GameBase::setRotation(%segment[3],"0 0.7853 0.2853");
	GameBase::setPosition(%segment[3],%position);

	GameBase::setRotation(%segment[4],"0 -0.7853 0.6853");
	GameBase::setPosition(%segment[4],%position);

	GameBase::setRotation(%segment[8],"0 -0 0.8853");
	GameBase::setPosition(%segment[8],Vector::add(GameBase::getPosition(%segment[3]), "-2.5 -1.5 -6"));

	GameBase::setRotation(%segment[11],"0 -0 0.0853");
	GameBase::setPosition(%segment[11],Vector::add(GameBase::getPosition(%segment[4]), "3.5 1.65 -6"));

//*****MAW 3
	
	%position = Vector::add(%position, "0 -9.0711 0");            
	GameBase::setRotation(%segment[5],"0 0.7853 -0.2853");        
	GameBase::setPosition(%segment[5],%position);                  

	GameBase::setRotation(%segment[6],"0 -0.7853 -0.6853");
	GameBase::setPosition(%segment[6],%position);

	GameBase::setRotation(%segment[9],"0 0 -0.8853");
	GameBase::setPosition(%segment[9],Vector::add(GameBase::getPosition(%segment[5]), "-2.5 1.5 -6"));

	GameBase::setRotation(%segment[12],"0 0 -0.0853");
	GameBase::setPosition(%segment[12],Vector::add(GameBase::getPosition(%segment[6]), "3.5 -1.65 -6"));

	return 12;
}

function Sandworm::onAttack( %position, %worm )
{
//echo("Small");
//echo(%Position);
	%origPosition = %position;
	$Worm::Attacking = true;

	// Get our length
	%ghost = newObject("GhostWorm", "StaticShape", "GhostPos", true);
	gamebase::Setposition(%ghost,vector::Add(%position,"0 0 -1"));
	%length = 0;
	if(GameBase::getLOSInfo(%ghost,1000,"-1.570796327 0 0")){
//echo($LOS::Position);
		%length = (getword(%position,2) - getword($LOS::Position,2))/6;	
		%position = $LOS::Position;
//echo("LOS found");
	}
//echo(%length);
//echo(%position);

	%length = floor(%length);
	deleteObject(%ghost);
	
	//Always have one extra ring.
	%length = %length+1;
	if(%length > 4)
		%length = 4;
	

	newObject("WormParts", SimGroup);
	addToSet("MissionCleanup/WormStorage","WormParts");

	// Make our segments
	%segments = Sandworm::createMaw( %position, %worm, %length );
	$WormSegments = %segments;
	%MouthSegments = $WormSegments;
	for(%x = $WormSegments+1; %x < (($WormSegments+1) + %length*6); %x++){
		%segment[%x] = newObject("Sandworm", "StaticShape", "WormSegment", true);
		%segments++;
		%this = %segment[%x];
		//schedule("deleteobject(\""@%this@"\");",(8+%length));
		addToSet("MissionCleanup/WormStorage/WormParts", %segment[%x]);
		$Worm[%x] = %segment[%x];
	}
	$WormSegments = %segments;

	schedule("Worm::free(\""@%origPosition@"\");",(8+%length));

	//**** Position our rings
	%y = %MouthSegments;
	for(%x = 6; %x <= (%length*6); %x= %x+6 ) 
	{

		%y++;
		GameBase::setRotation(%segment[%y],"0 -0 1.9707");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"5 3.2 "@-16-%x));

		%y++;
		GameBase::setRotation(%segment[%y],"0 -0 1.1707");
		GameBase::setPosition(%segment[%y],Vector::add(%position, "5 -3.2 "@-16-%x));

		%y++;
		GameBase::setRotation(%segment[%y],"0 -0 0.8853");
		GameBase::setPosition(%segment[%y],Vector::add(%position, "-6.0355 2.855 " @-16-%x));

		%y++;
		GameBase::setRotation(%segment[%y],"0 -0 0.0853");
		GameBase::setPosition(%segment[%y],Vector::add(%position, "-0.0355 6.005 " @-16-%x));

		%y++;
		GameBase::setRotation(%segment[%y],"0 0 -0.8853");
		GameBase::setPosition(%segment[%y],Vector::add(%position, "-6.0355 -3.0375 " @-16-%x));

		%y++;
		GameBase::setRotation(%segment[%y],"0 0 -0.0853");
		GameBase::setPosition(%segment[%y],Vector::add(%position, "-0.0355 -6.1876 " @-16-%x));
	}



	%playerPosition = %position;

	%position = 0;
	schedule("Sandworm::move(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	schedule("WormKill(\""@%playerPosition@"\",\""@%worm@"\");", 3.1);
}

function echomissioncleanup()
{
echo("Worm Cleanup");
echo($wormsegments);

	//echomissioncleanupgo();
}

function echomissioncleanupgo()
{
	%count = group::objectcount("MissionCleanup");
	echo("*****"@%count);
	%gren = 0;
	%item = 0;
	%ss = 0;
	%player = 0;
	for(%x=0;%x < %count;%x++)
	{
		%obj = Group::getObject("missionCleanup", %x);
//		echo(%obj@" "@getobjecttype(%obj) @ " " @gamebase::getdataname(%obj) @ " " @ %obj.objectname);
		if(getobjecttype(%obj) == SimSet)
		{
			echo("  " @group::objectcount(%obj));
			for(%y=0;%y < group::objectcount(%obj);%y++)
			{
				%obj2 = Group::getObject("missionCleanup", %y);
				echo("  "@%obj2@" "@getobjecttype(%obj2) @ " " @ gamebase::getdataname(%obj2) @ " " @ %obj2.objectname);

				if(getobjecttype(%obj2) == SimSet)
				{
					echo("    " @group::objectcount(%obj2));
					for(%z=0;%z < group::objectcount(%obj2);%z++)
					{
						%obj3 = Group::getObject("missionCleanup", %z);
						echo("    "@%obj3@" "@getobjecttype(%obj3) @ " " @ gamebase::getdataname(%obj3) @ " " @ %ob3j.objectname);
					}
				}
			}
		}
		if(getobjecttype(%obj) == Grenade)
		{
			%gren++;
		} else if(getobjecttype(%obj) == Item)
		{
			%item++;
		} else if(getobjecttype(%obj) == staticshape)
		{
			%ss++;
		} else if(getobjecttype(%obj) == Player)
		{
			%player++;
		}


	}

echo("*****Grenade: "@%gren@ " Item: "@%item@ " Staticshape: "@%ss@ " Player: "@%player);

}
function startTree()
{
	getTree(nametoId("missioncleanup"),"");
}

function getTree(%group,%level)
{
	%count = group::objectcount(%group);

	if(((getobjecttype(%group) == SimSet || getObjectType(%group) == SimGroup) && group::objectCount(%group) > 0)
		|| (getobjecttype(%group) != SimSet && getObjectType(%group) != SimGroup && getObjectType(%group) != Grenade) )
	 	echo(%level@%group@" "@getobjecttype(%group) @ " " @ gamebase::getdataname(%group) @" : " @ gamebase::GetMapName(%group));
	%level = %level @ "  ";

	if(getobjecttype(%group) == SimSet || getObjectType(%group) == SimGroup)
	{
		for(%z=0;%z < group::objectcount(%group);%z++)
		{
			%obj = Group::getObject(%group, %z);
			getTree(%obj,%level);
		}
	}
}

//Up
function Sandworm::move(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");
	if(%position <= (20+%length*12))
	{
		for(%x = 1; %x <= $WormSegments; %x++)
		{
			GameBase::setPosition($Worm[%x], Vector::add(GameBase::getPosition($Worm[%x]), "0 0 0.5"));
		}
		%position++;
		schedule("Sandworm::move(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.02);
	} else 
	{
		%position = 0;
		schedule("Sandworm::move2(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	}
}

//Close
function Sandworm::move2(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");

	if(%position <= 40)
	{
		//Hate to use hardcore constants here, but best way to do it ATM.
		for(%x = 1; %x < 3; %x++) 
		{
			GameBase::setRotation($Worm[%x], Vector::add(GameBase::getRotation($Worm[%x]), "-0.023 0 0"));

		}
		for(%x = 3; %x < 5; %x++) 
		{
			GameBase::setRotation($Worm[%x], Vector::add(GameBase::getRotation($Worm[%x]), "0.023 0 0"));

		}
		for(%x = 5; %x < 7; %x++) 
		{
			GameBase::setRotation($Worm[%x], Vector::add(GameBase::getRotation($Worm[%x]), "-0.023 0 0"));

		}
		
		%position++;
		schedule("Sandworm::move2(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.1);

	}else{
		%position = 0;
		schedule("Sandworm::move3(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	}
}

//Down
function Sandworm::move3(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");

	if(%position < (72+%length*43))
	{
		for(%x = 1; %x <= $WormSegments; %x++)
		{
			GameBase::setPosition($Worm[%x], Vector::add(GameBase::getPosition($Worm[%x]), "0 0 -0.14"));
		}
		%position++;
		schedule("Sandworm::move3(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.02);

	} else {
		%position = 0;
		//schedule("Sandworm::move4(0,\""@%playerPosition@"\",\""@%length@"\");", 1.0);
	}
}

//Delete
// Nothing more then a double check, since we delete already.
// OLD. Using Worm::free now
function Sandworm::move4(%position, %playerPosition, %length)
{
echomissioncleanup();
	Worm::display(%playerposition, "0 0 0");
	for(%x = 1; %x <= $WormSegments; %x++)
	{
		if($Worm[%x])
			deleteObject($Worm[%x]);
	}
	// Tripple check
	$Worm::Attacking = false;
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


function SandWormM::AdminAttack( %victim )
{
	if(Player::getClient(%victim) == -1 || !Player::getClient(%victim) || $Worm::Attacking)
		return;

	newObject("WormStorage", SimGroup);
	addToSet("MissionCleanup","WormStorage");

	%worm = newObject("Sandworm", "StaticShape", "WormPos", true);
	%victim = Player::getClient(%victim);
	if( getObjectType(Client::getControlObject(%victim))== "Flier" ){
		Vehicle::kickout(Client::getControlObject(%victim),"0 0 0");
	}
	%position = GameBase::getPosition(%victim);
	SandwormMedium::onAttack(%position,%worm);
	deleteobject(%worm);
}



function SandwormMedium::CreateMouth( %position, %worm)
{
	
	for(%x = 1; %x <= 6; %x++) 
	{
		%segment[%x] = newObject("Sandworm", "StaticShape", "WormSegment", true);
		%this = %segment[%x];
		//schedule("deleteobject(\""@%this@"\");",(6+%length));
		//schedule("$Worm::Attacking = false;",(6.1+%length));
		
	}
	for(%x = 1; %x <= 6; %x++) 
	{
		$Worm[%x] = %segment[%x];
	}

	for(%x = 1; %x <= 6; %x++) 
	{
		addToSet("MissionCleanup/WormStorage/WormParts", %segment[%x]);
	}

	%playerPosition = %position;


	//*** Create our mouth
	
	%y = 1;

	GameBase::setRotation(%segment[%y],"0 0.8 0");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"-4.3 7.8 -13"));

	%y++;
	GameBase::setRotation(%segment[%y],"0 0.8 -2.09439");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"-4.3 7.8 -13"));
	
	%y++;
	GameBase::setRotation(%segment[%y],"0 0.8 2.09439");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"8.7 0 -13"));

	%y++;
	GameBase::setRotation(%segment[%y],"0 0.8 -2.09439");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"8.7 0 -13"));

	%y++;
	GameBase::setRotation(%segment[%y],"0 0.8 0");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"-4.3 -7.8 -13"));

	%y++;
	GameBase::setRotation(%segment[%y],"0 0.8 2.09439");
	GameBase::setPosition(%segment[%y],Vector::add(%position,"-4.3 -7.8 -13"));
	return %y;
}

function SandwormMedium::onAttack( %position, %worm )
{
	%origPosition = %position;
	$Worm::Attacking = true;
	%length = 0;
	
	// Get our length
	%ghost = newObject("GhostWorm", "StaticShape", "GhostPos", true);
	%length = 0;
	gamebase::Setposition(%ghost,vector::Add(%position,"0 0 -1"));
	if(GameBase::getLOSInfo(%ghost,1000,"-1.570796327 0 0")){
		%length = (getword(%position,2) - getword($LOS::Position,2))/6;	
		%position = $LOS::Position;
	}
	// Always have at least 2 rings.
	%length = floor(%length)+2;
	deleteObject(%ghost);

	if(%length > 6)
		%length = 6;

	// Make our segments
	newObject("WormParts", SimGroup);
	addToSet("MissionCleanup/WormStorage","WormParts");

	%segments = SandWormMedium::createMouth(%position, %worm);
	$WormSegments = %segments;
	%MouthSegments = $WormSegments;
	for(%x = $WormSegments+1; %x <= (($WormSegments+1) + %length*6); %x++){
		%segment[%x] = newObject("Sandworm", "StaticShape", "WormSegment", true);
		%segments++;
		%this = %segment[%x];
		//schedule("deleteobject(\""@%this@"\");",(6+%length));
		addToSet("MissionCleanup/WormStorage/WormParts", %segment[%x]);
		$Worm[%x] = %segment[%x];
	}
	schedule("Worm::free(\""@%origPosition@"\");",(6+%length));
	$WormSegments = %segments;

	//**** Position our rings
	%y = %MouthSegments;
	for(%x = 0; %x <= (%length*6); %x= %x+6 ) 
	{
		%y++;
		GameBase::setRotation(%segment[%y],"0.06 0 0");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"0 8.4 "@-%x-19));
		%y++;
		GameBase::setRotation(%segment[%y],"-0.06 0 2.0944");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"7.1 4 "@-%x-19));
	
		%y++;
		GameBase::setRotation(%segment[%y],"-0.06 0 1.0472");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"7.1 -4 "@-%x-19));
	
		%y++;
		GameBase::setRotation(%segment[%y],"0.06 0 3.1416");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"0 -8.4 "@-%x-19));
		
		%y++;
		GameBase::setRotation(%segment[%y],"-0.06 0 5.2360");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"-7.1 -4 "@-%x-19));
	
		%y++;
		GameBase::setRotation(%segment[%y],"-0.06 0 4.1888");
		GameBase::setPosition(%segment[%y],Vector::add(%position,"-7.1 4 "@-%x-19));
		
	}
	%playerPosition = %position;
	schedule("SandwormMedium::move(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	schedule("WormKill(\""@%playerPosition@"\",\""@%worm@"\");", 4.1);
}

//Up
function SandwormMedium::move(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");
	if(%position <= (12+%length*12))
	{
		for(%x = 1; %x < $WormSegments; %x++)
		{
			GameBase::setPosition($Worm[%x], Vector::add(GameBase::getPosition($Worm[%x]), "0 0 0.5"));
		}
		%position++;
		schedule("SandwormMedium::move(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.02);
	} else 
	{
		%position = 0;
		schedule("SandwormMedium::move2(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	}
}

//Close
function SandwormMedium::move2(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");

	if(%position <= 40)
	{
		//Hate to use hardcore constants here, but best way to do it ATM.
			GameBase::setRotation($Worm[1], Vector::add(GameBase::getRotation($Worm[1]), "0.023 0 0"));
		GameBase::setPosition($Worm[1], Vector::add(GameBase::getPosition($Worm[1]), "0.011 -0.02 0.06"));

			GameBase::setRotation($Worm[2], Vector::add(GameBase::getRotation($Worm[2]), "-0.023 0 0"));
		GameBase::setPosition($Worm[2], Vector::add(GameBase::getPosition($Worm[2]), "0.011 -0.02 0.06"));

			GameBase::setRotation($Worm[3], Vector::add(GameBase::getRotation($Worm[3]), "-0.023 0 0"));
		GameBase::setPosition($Worm[3], Vector::add(GameBase::getPosition($Worm[3]), "-.0223 0 0.06"));

			GameBase::setRotation($Worm[4], Vector::add(GameBase::getRotation($Worm[4]), "0.023 0 0"));
		GameBase::setPosition($Worm[4], Vector::add(GameBase::getPosition($Worm[4]), "-.0223 0 0.06"));

			GameBase::setRotation($Worm[5], Vector::add(GameBase::getRotation($Worm[5]), "-0.023 0 0"));
		GameBase::setPosition($Worm[5], Vector::add(GameBase::getPosition($Worm[5]), "0.011 0.02 0.06"));

			GameBase::setRotation($Worm[6], Vector::add(GameBase::getRotation($Worm[6]), "0.023 0 0"));
		GameBase::setPosition($Worm[6], Vector::add(GameBase::getPosition($Worm[6]), "0.011 0.02 0.06"));			

		%position++;
		schedule("SandwormMedium::move2(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.1);

	}else{
		%position = 0;
		schedule("SandwormMedium::move3(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
	}
}

//Down
function SandwormMedium::move3(%position, %playerPosition, %length)
{
	Worm::display(%playerposition, "0 0 0");

	if(%position < (43+%length*43))
	{
		for(%x = 1; %x <= $WormSegments; %x++)
		{
			GameBase::setPosition($Worm[%x], Vector::add(GameBase::getPosition($Worm[%x]), "0 0 -0.14"));
		}
		%position++;
		schedule("SandwormMedium::move3(\""@%position@"\",\""@%playerPosition@"\",\""@%length@"\");", 0.02);

	} else {
		%position = 0;
		// This get's called by a schedule right after the worm's made.
		//schedule("SandwormMedium::move4(0,\""@%playerPosition@"\",\""@%length@"\");", 0.1);
		// Double check
		//$Worm::Attacking = false;
	}
}

//Delete OLD
// Just double check that everything is gone...
function SandwormMedium::move4(%position, %playerPosition, %length)
{
echomissioncleanup();
	Worm::display(%playerposition, "0 0 0");
	for(%x = 1; %x <= $WormSegments; %x++)
	{
		if($Worm[%x])
			deleteObject($Worm[%x]);
	}
	// Tripple check
	$Worm::Attacking = false;
}

//Delete NEW
// Clean up for both types of worms.
function Worm::free( %playerPosition )
{
echomissioncleanup();
	Worm::display(%playerposition, "0 0 0");
	for(%x = 1; %x <= $WormSegments; %x++)
	{
		if($Worm[%x])
		{
			deleteObject($Worm[%x]);
			$Worm[%x] = false;
		}
	}

	deletegroup(nameToID("MissionCleanup/WormStorage/WormParts"));

	// Tripple check
	//echo("$Worm::Attacking = false");
	//$Worm::Attacking = false;
}


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//     WORM TYPE II (Large, slower, horizontal attack) **NO GOOD! TOO SLOW! TOO LAGGY! DONT USE!**

function LSandworm::onAttack( %victim )
{
	%victim = Player::getClient(%victim);
echo("attacking " @ %victim); 

//*****Small plates
	for(%x = 1; %x < 54; %x++) 
	{
		%wormPlate[%x] = newObject("Sandworm", InteriorShape,"flatbrdg512.dis");
	}
//*****Large plates
	for(%x = 54; %x < 58; %x++) 
	{
		%wormPlate[%x] = newObject("Sandworm", InteriorShape,"flatbrdg1024.dis");
	}
	for(%x = 1; %x < 58; %x++) 
	{
		addToSet("MissionCleanup", %wormPlate[%x]); 
	
	}
	for(%x = 1; %x < 58; %x++) 
	{
		$LWorm[%x] = %wormPlate[%x];
	
	}

	
	
	%position = vector::add(GameBase::getPosition(%victim), "0 70 -25");
	%rotation = GameBase::getRotation(%victim);

//*****BodyRings

	%y = 0;
	for(%x = 0; %x < 91; %x = %x + 9)
	{
		%y++;
		%lock = %x;
		GameBase::setRotation(%wormPlate[%y],"1.570796327 0 1.570796327");
		GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "-18.5 "@ %x @" "@-7-(%lock/3.3)));
		
		%y++;
		%lock = %x;
		GameBase::setRotation(%wormPlate[%y],"2.35619449 -0.1 1.570796327");
		GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "-18.5 "@ %x @" "@9-(%lock/3.3)));
	
		%y++;
		%lock = %x;
		GameBase::setRotation(%wormPlate[%y],"3.141592654 -0.2 1.570796327");
		GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "-8 "@ %x @" "@20-(%lock/3.3)));
	
		%y++;
		%lock = %x;
		GameBase::setRotation(%wormPlate[%y],"-2.35619449 -0.1 1.570796327");
		GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "8 "@ %x @" "@20.5-(%lock/3.3)));
		
		%y++;
		%lock = %x;
		GameBase::setRotation(%wormPlate[%y],"-1.570796327 0 1.570796327");
		GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "19.5 "@ %x @" "@9-(%lock/3.3)));
		%lock = %x;
	}
	
//*****AssCover #51
	
	%y++;
	%x = %lock+8;
	%lock = %x;
	GameBase::setRotation(%wormPlate[%y],"3.141592654 -1.0 1.570796327");
	GameBase::setPosition(%wormPlate[%y],Vector::add(%position, "-0 "@ %lock @" "@20-(%lock/3)));

//*****Maw #52, #54, #55

	GameBase::setRotation(%wormPlate[52],"0 -2.35619449 0.1"); // "0 0 -0" to close
	GameBase::setPosition(%wormPlate[52],Vector::add(%position, "15 -18 16"));

	GameBase::setRotation(%wormPlate[54],"0.15 -3.00 0.5"); 
	GameBase::setPosition(%wormPlate[54],Vector::add(%position, "17 -30 16.5"));

	GameBase::setRotation(%wormPlate[55],"-0.5 -1.780796327 -0.15"); 
	GameBase::setPosition(%wormPlate[55],Vector::add(%position, "15.5 -30 18"));

//*****Maw #53, #56, #57

	GameBase::setRotation(%wormPlate[53],"0 2.35619449 -0.1"); // "0 0 -0" to close
	GameBase::setPosition(%wormPlate[53],Vector::add(%position, "-14 -18 16"));

	GameBase::setRotation(%wormPlate[56],"0.15 3.00 -0.5"); 
	GameBase::setPosition(%wormPlate[56],Vector::add(%position, "-16 -30 16.5"));

	GameBase::setRotation(%wormPlate[57],"-0.5 1.780796327 0.15"); 
	GameBase::setPosition(%wormPlate[57],Vector::add(%position, "-14.5 -30 18"));
	


	%position = 0;
	schedule("LSandworm::move(\""@%position@"\");", 5.0);
echo("creation done");
}

function LSandworm::move(%position, %playerPosition)
{
echo("moving");
	if(%position < 760)
	{
		for(%x = 1; %x < 58; %x++) 
		{
			GameBase::setPosition($LWorm[%x],Vector::add(Gamebase::getposition($LWorm[%x]), "0 -0.01 0.03"));

		}
		%position++;
		schedule("LSandworm::move(\""@%position@"\",\""@%playerPosition@"\");", 0.1);

	} else if(%position < 2760)
	{
		for(%x = 1; %x < 58; %x++) 
		{
			GameBase::setPosition($LWorm[%x],Vector::add(Gamebase::getposition($LWorm[%x]), "0 -0.02 0"));

		}
		%position++;
		schedule("LSandworm::move(\""@%position@"\",\""@%playerPosition@"\");", 0.1);
	} else if(%position < 5010)
	{
		for(%x = 1; %x < 58; %x++) 
		{
			GameBase::setPosition($LWorm[%x],Vector::add(Gamebase::getposition($LWorm[%x]), "0 -0.01 -0.01"));

		}
		%position++;
		schedule("LSandworm::move(\""@%position@"\",\""@%playerPosition@"\");", 0.1);
	} else if(%position >= 3510)
	{
		for(%x = 1; %x < 58; %x++) 
		{
			deleteObject($LWorm[%x]);

		}
	}
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//      Worm hunting      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

// How fast they move normally
$Worm::speed = 0.12;
// How many cycles do they update the target normally? (Time = cycles*$worm::speed)
$Worm::TargetUpdate = 40;
// Time to wait after attack.
$Worm::TWAA = 20;
// How big should the movement step be?
$Worm::StepSize = 2;
// How often to refresh the worms?
$Worm::Refresh = 450;

function Worm::add(%misX, %misY, %misW, %misH)
{
	deleteGroup(nameToID("MissionCleanup/WormStorage"));
	newObject("WormStorage", SimGroup);
	addToSet("MissionCleanup","WormStorage");

	// Disallow more then one worm. I don't think we'll every need more then one.
	// One is destructive enough as it is...
	if($Worm::number[$Worm::amt] != 0 && $Worm::number[$Worm::amt] != -1 && $Worm::number[$Worm::amt] != "" && $Worm::number[$Worm::amt] != false)
	{
		echo("ERROR ADDING NEW WORM: Worm already exists.");
		return;
	}

	//return;//disabled

	$Worm::MisBoundries[x] = %misX;
	$Worm::MisBoundries[y] = %misY;
	$Worm::MisBoundries[w] = %misW;
	$Worm::MisBoundries[h] = %misH;

	if(!$worm::amt || $worm::amt == "")
		$Worm::amt = 1;
	else
		$Worm::amt++;
	%worm = newObject("Sandworm", "StaticShape", "WormPos", true);
	AddToSet("MissionCleanup/WormStorage",%worm);
	%worm.camera = newObject("Sandworm", "StaticShape", "WormPos", true);
	$Worm::number[$worm::amt] = %worm;
	
	%newPos = "0 0 0";
	%continue = true;
	for(%count = 0; %count < 100 || %continue; %count++)
	{

		%X = floor(getRandom() *(%misX));
		%W = floor(getRandom() *(%misW));
		%Y = floor(getRandom() *(%misY));
		%H = floor(getRandom() *(%misH));
		%tx = %X + %W; 
		%ty = %Y + %H; 
		%tz = 1000;
		%pos = %tx @" "@ %ty @" "@ %tz;
		gamebase::setposition(%worm, %pos);
		
		GameBase::getLOSInfo(%worm,10000,"-1.570796327 0 0");
		%newPos = $los::position;		

		if( !%newPos || %newPos == "0 0 0" || %newPos == "" 
		|| Worm::inWormBox(%newPos))
			%continue = true;
		else
			%continue = false;
	}
	if(%continue) {
		echo("ERROR: Could not place worm #" @ %worm@  "!");
		$Worm::amt--;
		deleteobject(%worm);
		deleteobject(%worm.camera);
		return;
	}
	gamebase::setposition(%worm, %pos);
	gamebase::setposition(%worm.camera, %pos);
	// 1 = small worm, 2 = medium worm
	if(floor(getrandom()*2) == 0)
		$Worm::Size[%worm] = 1;
	else
		$Worm::Size[%worm] = 1; // 2;

	// So we can keep track of our worms. and readd when they dissapear
	if($Worm::WormCount || $Worm::WormCount == "" || $Worm::WormCount < 0)
		$Worm::WormCount = 1;
	else
		$Worm::WormCount = $Worm::WormCount + 1;
	$Worm::List[$Worm::WormCount] = %worm;

echo("Worm added");
	$lasthunt = 0; //IMPORTANT! Else the worm will not work ever again after first map! Geeze!
	%Worm.isalive = true;
	Worm::hunttarget(%worm, 0);
	Worm::checkObserved();
//	schedule("Worm::WarnObserved();",($Worm::Refresh-4));
//	for(%x=($Worm::Refresh/5); %x>0; %x= %x-($Worm::Refresh/10))
//{
//	schedule("messageall(0, \"Time left: "@$Worm::Refresh-%x@"\");",%x);
//}
//	for(%x=$Worm::Refresh; %x>($Worm::Refresh/5); %x= %x-($Worm::Refresh/20))
//{
//	schedule("messageall(0, \"Time left: "@$Worm::Refresh-%x@"\");",%x);
//}

	schedule("Worm::delete("@%worm@");",$Worm::Refresh);	
	schedule("$Worm::number[$Worm::Amt] = 0;",$Worm::Refresh);	
	schedule("$Worm::Amt--;",$Worm::Refresh);	
	
}

function Worm::delete(%worm)
{
	if($Worm::Attacking && $Worm::DelOne <= 60) {
		$Worm::DelOne = $Worm::delOne+1;
		//messageall(0, "DELONE: "@$delOne);
		schedule("Worm::delete("@%worm@");",1);
		return;
	} else {
		$Worm::DelOne = 0;
		%worm.isalive = False; 
		deleteObject(%worm.camera);
		deleteObject(%worm);
		schedule("Worm::add("@$Worm::MisBoundries[x]@", "@$Worm::MisBoundries[y]@", "@$Worm::MisBoundries[w]@", "@$Worm::MisBoundries[h]@");",1);
	}
}

function Worm::inWormBox(%position)
{

	%toReturn = false;
	%set = newObject("set",SimSet); // make new box for testing.
	%number = containerBoxFillSet(%set,$GroupTriggerObjectType,getword(%position,0) @ " "@ getword(%position,1) @ " -100",2,2,50,0);
	if(%number){ // Found a box?
		for(%x = 0; %x <= %number && !%toReturn; %x++){
//echo("InWormBoxLoop " @ %x);

			%target = Group::getObject(%set,%x); // get the objNum of the found object.

			// is this a wormbox?
			if(Object::Getname(%target) == "WormBox")
				%toReturn = true;
		}
	
	}
	deleteObject(%set); // then delete current box no matter what.
	return %toReturn;
}

function Worm::inWormBox2(%position)
{

	%group = nameToID("MissionGroup/WormBox");
	
	for(%i = 0; (%box = Group::getObject(%group, %i)) != -1; %i++)
	{
		if(Object::Getname(%box) == WormBox)
		{
			%Bpos = gamebase::getposition(%box);	
			%BposX = getword(%Bpos,0);
			%BposY = getword(%Bpos,1);
			%posX = getword(%position,0);
			%posY = getword(%position,1);

	echo(abs(%posx - %Bposx)@" <= "@abs(getword(%box.dim,0))@" || "@abs(%posx - %Bposx)@" <= "@abs(getword(%box.dim,3))@") && ("@abs(%posy - %Bposy)@" <= "@abs(getword(%box.dim,1))@" || "@abs(%posy - %Bposy)@" <= "@abs(getword(%box.dim,4)));	

			if((abs(%posx - %Bposx) <= abs(getword(%box.dim,0)) || abs(%posx - %Bposx) <= abs(getword(%box.dim,3)))
			   && (abs(%posy - %Bposy) <= abs(getword(%box.dim,1)) || abs(%posy - %Bposy) <= abs(getword(%box.dim,4))))	
				return true;
		}
		
	}
	return false;
}

function abs(%val)
{
	if(%val >= 0)
		return %val;
	else
		return -1*%val;
}
function Worm::hunttarget(%worm, %pass)
{
	//return; //disabled
	if(!%worm || %worm == "" || !%worm.isalive) {
		return;
	}
%time = getsimtime();
%moo = %time - $lasthunt;
$lasthunt = %time;
if(%moo<0.06)
{
	echo(%moo);
	echo("KILLING EXTRA HUNT LOOP");
	return;

}
//echo("Hunting: " @%worm);

//echo("Worm hunting: " @ gamebase::Getposition(%worm));
//echo("              " @ gamebase::Getposition($Worm::CurTarget[%worm])@ getObjectType($Worm::CurTarget[%worm]));

	if( %pass == 0 )
	{
		%pass++;
		Worm::GetBestTarget(%worm, $Worm::CurTarget[%worm]);
//echo("WormCurTarget: *" @$Worm::CurTarget[%worm]@ "*");
		if($Worm::CurTarget[%worm] == "" )
		{
			$Worm::PositionTarget[%worm] = true;
			%X = floor(getRandom() *($Worm::MisBoundries[x]));
			%W = floor(getRandom() *($Worm::MisBoundries[y]));
			%Y = floor(getRandom() *($Worm::MisBoundries[w]));
			%H = floor(getRandom() *($Worm::MisBoundries[h]));
			%tx = %X + %W; 
			%ty = %Y + %H; 
			%tz = 1000;
			$Worm::CurTarget[%worm] = %tx @" "@ %ty @" "@ %tz;

		} else 
			$Worm::PositionTarget[%worm] = false;
	} else if( %pass == $Worm::TargetUpdate )
		%pass = 0;
	else
		%pass++;
if(%pass > $Worm::TargetUpdate)
{
echo("ERROR!!!!!!");
}
	%target = $Worm::CurTarget[%worm];
	if($Worm::PositionTarget[%worm])
		%TargetPos = %target;
	else
		%TargetPos = gamebase::Getposition(%target);

	%ghostdrop = newObject("GhostWorm", "StaticShape", "GhostPos", true);
	gamebase::Setposition(%ghostdrop,vector::Add(%Targetpos,"0 0 -1"));
	%length = 0;
	if(GameBase::getLOSInfo(%ghostdrop,1000,"-1.570796327 0 0")){
		%length = floor((getword(%targetpos,2) - getword($LOS::Position,2)))/6;	
	}
	deleteobject(%ghostdrop);

	//If worm is under it's target to attack
	if($Worm::PositionTarget[%worm] && Worm::UnderTarget(%worm, %target))
	{
		//K. Its just a waypoint, not a target. So dont eat anything.
		// Get new target though.
		%pass = 0;
		%WormPos = gamebase::Getposition(%worm);

		%GhostPos = newObject("GhostWorm", "StaticShape", "GhostPos", true);
	
		//Move a ghost step ahead $Worm::StepSize distance to target.
		%nozWormPos = getword(%WormPos,0) @ " " @ getword(%WormPos,1) @ " 0";
		%noZTargPos = getword(%targetPos,0) @ " " @ getword(%targetPos,1) @ " 0";
		%rot = vector::getrotaim(%nozwormpos,%noztargpos);
		gamebase::setrotation(%worm.camera, %rot);
		%newpos = vector::Add(vector::getFromRot(vector::getrotaim(%nozwormpos,%noztargpos),$worm::StepSize),%nozwormpos);
		
		Worm::SetPosition(%GhostPos,%newPos);
		
		//If ghost is not in violation of a rock
		if(!Worm::inWormBox(gamebase::getposition(%GhostPos)))
		{
			// Emit 
			Worm::display(gamebase::getposition(%worm), Vector::getRotAim(gamebase::getposition(%worm),%targetPos));
			Worm::display(gamebase::getposition(%GhostPos), Vector::getRotAim(gamebase::getposition(%GhostPos),%targetPos));
			gamebase::setposition(%worm.camera, vector::add(gamebase::Getposition(%ghostpos), "0 0 5"));
			
		}
		else
		{
			// Move ghost a good distance below any surface, so we dont find a floating worm marker in a base
			gamebase::setposition(%worm.camera, vector::add(gamebase::Getposition(%ghostpos), "0 0 20"));
			gamebase::setposition(%GhostPos, vector::add(gamebase::getposition(%GhostPos),"0 0 -1000"));
			
		}
// *Vetoed: Didnt want to try and worry about having the worm avoid obsticles, either by calculation or pathmarkers.
// *if ghost is in violation of rock
// *check front right, front left, left, right, back right, back left, back
// *Go to closest position to target
// *or
// *if ghost is in violation of rock
// *mark as moving around obstical
// *get nearest pathmarker for obstical
// *get closest pathmarker to target
// *get direction for shortest path.
// *move closer to next waypoint

		//Move worm to ghoststep
		gamebase::setposition(%worm, gamebase::Getposition(%ghostpos));
		
		//Delete ghost
		deleteobject(%ghostpos);

		//Start hunting target
		schedule("Worm::hunttarget(\""@%worm@"\",\""@%pass@"\");", $Worm::Speed);

	}
	else if(!$Worm::PositionTarget[%worm] && Worm::UnderTarget(%worm, %target) && !$Worm::Attacking && (($Worm::Size[%worm] == 1 && %length < 5) || ($Worm::Size[%worm] == 2 && %length < 7)))
	{
		// If target is not in rockspace
		gamebase::setposition(%worm.camera, vector::add(gamebase::Getposition(%target), "0 0 20"));
		gamebase::setrotation(%worm.camera, "-1.570796327 0 0");
		if( !Worm::inWormBox(gamebase::getposition(%target)) )
		{


			//   Attack target.
			if($Worm::Size[%worm] == 1)
			{
				%victim = Player::getClient(%target);
				if( %victim && %victim != "" && %victim != -1 && Client::getControlObject(%victim) && Client::getControlObject(%victim) != "" && Client::getControlObject(%victim) != -1 
					&& getObjectType(Client::getControlObject(%victim))== "Flier" ) {
					//Vehicle::kickout(Client::getControlObject(%victim),"0 0 0");
				}
				Sandworm::onAttack( gamebase::getposition(%target), %worm );
	
			} else if($Worm::Size[%worm] == 2)
			{
				
				%victim = Player::getClient(%target);
				if( %victim && %victim != "" && %victim != -1 && Client::getControlObject(%victim) && Client::getControlObject(%victim) != "" && Client::getControlObject(%victim) != -1 
					&& getObjectType(Client::getControlObject(%victim))== "Flier" ) {
					//Vehicle::kickout(Client::getControlObject(%victim),"0 0 0");
				}
				SandwormMedium::onAttack( gamebase::getposition(%target), %worm );
			}
			// Assume target dead. Get new target.
			%pass = 0;
			
			//   Start hunting target
			$worm::attacking = true;
			schedule("$worm::attacking = false;", ($Worm::TWAA-0.5));
			schedule("Worm::hunttarget(\""@%worm@"\",\""@%pass@"\");", $Worm::TWAA);
		} else
		{
			$worm::attacking = true;
			schedule("$worm::attacking = false;", ($Worm::TWAA-0.5));
			schedule("Worm::hunttarget(\""@%worm@"\",\""@%pass@"\");", $Worm::TWAA);
		}
	}
	else
	{

		%WormPos = gamebase::Getposition(%worm);

		%GhostPos = newObject("GhostWorm", "StaticShape", "GhostPos", true);
	
		//Move a ghost step ahead $Worm::StepSize distance to target.
		%nozWormPos = getword(%WormPos,0) @ " " @ getword(%WormPos,1) @ " 0";
		%noZTargPos = getword(%targetPos,0) @ " " @ getword(%targetPos,1) @ " 0";
		//%dist = vector::getdistance(%nozwormpos,%noztargpos);
		//echo(%dist@" : "@%moo);

		%newpos = vector::Add(vector::getFromRot(vector::getrotaim(%nozwormpos,%noztargpos),$worm::StepSize),%nozwormpos);
		
		Worm::SetPosition(%GhostPos,%newPos);
		%rot = vector::getrotaim(%nozwormpos,%noztargpos);
		gamebase::setrotation(%worm.camera, %rot);
		//If ghost is not in violation of a rock
		if(!Worm::inWormBox(gamebase::getposition(%GhostPos)))
		{
			// Emit
			Worm::display(gamebase::getposition(%worm), Vector::getRotAim(gamebase::getposition(%worm),%targetPos));
			Worm::display(gamebase::getposition(%GhostPos), Vector::getRotAim(gamebase::getposition(%GhostPos),%targetPos));
			gamebase::setposition(%worm.camera, vector::add(gamebase::Getposition(%ghostpos), "0 0 5"));
			
		}
		else
		{
			// Move ghost a good distance below any surface, so we dont find a floating worm marker in a base
			gamebase::setposition(%worm.camera, vector::add(gamebase::Getposition(%ghostpos), "0 0 20"));
			gamebase::setposition(%GhostPos, vector::add(gamebase::getposition(%GhostPos),"0 0 -1000"));
		}

// *Vetoed: Didnt want to try and worry about having the worm avoid obsticles, either by calculation or pathmarkers.
// *if ghost is in violation of rock
// *check front right, front left, left, right, back right, back left, back
// *Go to closest position to target
// *or
// *if ghost is in violation of rock
// *mark as moving around obstical
// *get nearest pathmarker for obstical
// *get closest pathmarker to target
// *get direction for shortest path.
// *move closer to next waypoint

		//Move worm to ghoststep
		gamebase::setposition(%worm, gamebase::Getposition(%ghostpos));
		
		//Delete ghost
		deleteobject(%ghostpos);

		//Start hunting target
		schedule("Worm::hunttarget(\""@%worm@"\",\""@%pass@"\");", $Worm::Speed);
	}

}
$wormObserve = -1;
function Worm::Observe(%cl)
{
	Observer::setOrbitObject(%cl, -1, $WormObserve, $WormObserve, $WormObserve);
	Observer::setOrbitObject(%cl, $worm::list[1].camera, $WormObserve, $WormObserve, $WormObserve);
	bottomprint(%cl, "<jc>Observing worm.", 1);

}

function Worm::checkObserved()
{
   // this function loops through all the clients and checks
   // if anyone was observing %client... if so, it updates that
   // observation to reflect the new %client owned object.

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
         if(%cl.observerMode == "observerWorm")
      	   Worm::Observe(%cl);
      }
   
}

function Worm::WarnObserved()
{
   // this function loops through all the clients and checks
   // if anyone was observing %client... if so, it updates that
   // observation to reflect the new %client owned object.

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
         if(%cl.observerMode == "observerWorm")
      	   bottomprint(%cl, "<jc>Warning: Worm Refreshing...", 5);
      }
   
}

function Worm::RemoveFromTargetQueue(%this)
{
	for(%x = 1;%x <= $Worm::TargetQueueCount && !%done; %x++)
	{
//echo("RemoveFromTargetQueue " @ %x);

		if($Worm::TargetQueue[%x] == %this)
		{
			for(%pack = %x;%pack <= $Worm::TargetQueueCount; %pack++)
			{
				$Worm::TargetQueue[%pack] = $Worm::TargetQueue[(%pack)+1];
			}
			%done = true;
		}
	}
	$Worm::TargetQueueCount--;
	//if(%this == $Worm::CurTarget[$worm::getlist[1]])
	//	Worm::GetBestTarget($Worm::CurTarget[$worm::getlist[1]], -1);
}

function Worm::AddToTargetQueue(%this)
{
	$Worm::TargetQueueCount++;
	$Worm::TargetQueue[$Worm::TargetQueueCount] = %this;
}

function deleteGroup(%Group)
{
	for(%i = 0; (%obj = Group::getObject(%group, %i)) != -1; %i++)
	{
		if(getObjectType(%obj) == SimGroup)
		{
			DeleteGroup(%obj);
		} else
		{
			deleteObject(%obj);
		}
	}
	if(%group != -1)
		DeleteObject(%group);
}

//Player 1.0
$Worm::PlayerMod = 1.0;
//Thumper 2.0
$Worm::ThumperMod = 2.0;
//Ground Vehicle 2.0
$Worm::GCarMod = 2.0;
//Air Vehicle 0.5
$Worm::ThopterMod = 0.5;
//HunterSeekers 0.5
$Worm::HunterSeekerMod = 0.5;
//Shield on 2.0
$Worm::ShieldMod = 2.0;
//Suspensor on 1.5
$Worm::SuspensorMod = 1.5;
//XY Distance from worm 100.0/dist
$Worm::XYDistMod = 100.0;
//XY Distance from Thumper to worm 500.0/dist
$Worm::XYThumpDistMod = 500.0;
//Z Distance From worm -dist/25.0
$Worm::ZDistMod = 25.0;
//Not on Sand -1.0
$Worm::NotOnSandMod = -3.0;
//Previous Target
$Worm::PrevTargetMod = 1.0;

function Worm::GetBestTarget(%worm, %prevTarget)
{

	%Best = "";
	%BestValue = 0;
	%CurValue = 0;


	// It was adding SimVolumes and other things to the queue for some reason...
	//  So do some matinence before hand. Removing one each update should be fine
	for(%x = 1; %x <= $Worm::TargetQueueCount; %x++)
	{
		// We only track these objects.
		if($Worm::TargetQueue[%x] && $Worm::TargetQueue[%x] != -1 && $Worm::TargetQueue[%x] != "" && Getobjecttype($Worm::TargetQueue[%x]) != "Player" && Getobjecttype($Worm::TargetQueue[%x]) != "Flier" && GameBase::getDataName($Worm::TargetQueue[%x]) != Thumper)
		{
			//echo("Removing "@$Worm::TargetQueue[%x] @ " " @ getobjecttype($Worm::TargetQueue[%x]));		
			Worm::RemoveFromTargetQueue($Worm::TargetQueue[%x]);
		
		}
	}

	for(%x = 1; %x <= $Worm::TargetQueueCount; %x++)
	{
//echo($Worm::TargetQueue[%x] @ " " @ getobjecttype($Worm::TargetQueue[%x]));

//echo(GameBase::getDataName($Worm::TargetQueue[%x]));
		
					
	
		%CurValue = 0;
		%CurTarget = $Worm::TargetQueue[%x];
		if( %curTarget && %curTarget != -1 && %curtarget != "" && Getobjecttype(%CurTarget) == "Player")
		{
			%curValue = %curvalue + $Worm::PlayerMod;
			if( $SuspensorActivate[%curtarget])
				%curValue = %curvalue + $Worm::SuspensorMod; 
				
		}		
		if( GameBase::getDataName(%CurTarget) == BasicThopter || GameBase::getDataName(%CurTarget) == VulcanThopter || GameBase::getDataName(%CurTarget) == LasgunThopter || GameBase::getDataName(%CurTarget) == Carryall)
			%curValue = %curvalue + $Worm::ThopterMod;
		if( GameBase::getDataName(%CurTarget) == Roller || GameBase::getDataName(%CurTarget) == Tracker || GameBase::getDataName(%CurTarget) == Crawler) 
			%curValue = %curvalue + $Worm::GCarMod;
		if( GameBase::getDataName(%CurTarget) == HunterSeeker) 
			%curValue = %curvalue + $Worm::HunterSeekerMod;
		if( GameBase::getDataName(%CurTarget) == Thumper )
			%curValue = %curvalue + $Worm::ThumperMod;
		else if( $ShieldOn[%curtarget])
			%curValue = %curvalue + $Worm::ShieldMod;
		if( Worm::inWormBox(gamebase::Getposition(%curTarget)) )
			%curValue = %curvalue + $Worm::NotOnSandMod;
		if(%curTarget == %prevTarget)
			%curValue = %curvalue + $Worm::PrevTargetMod;
		
		%dist = Vector::getDistance(getword(GameBase::getPosition(%curtarget),0) @" "@getword(GameBase::getPosition(%curtarget),1) @" 0",
			getword(GameBase::getPosition(%worm),0)@" "@getword(GameBase::getPosition(%worm),1)@" 0");
		if( GameBase::getDataName(%CurTarget) == Thumper )
			%dist = $Worm::XYThumpDistMod/%dist;
		else
			%dist = $Worm::XYDistMod/%dist;

		if(%dist > 1.0)
			%dist = 1.0;
		%curValue = %curValue + %dist;
		
		GameBase::getLOSInfo(%CurTarget,10000,"-1.570796327 0 0");
		%groundZ = getword($los::position,2);		

		%dist = getword(GameBase::getPosition(%curtarget),2) - %groundZ;
		
		if(%dist > 0)
			%dist = %dist/$Worm::zDistMod;
		else
			%dist = 0;
		%curValue = %curValue - %dist;
	
		%curValue = %curValue + getrandom();
		
		if(%curvalue < 0)
			%curvalue = 0;
	
		if( GameBase::getDataName(%CurTarget) == farmor || GameBase::getDataName(%CurTarget) == ffarmor
			|| GameBase::getDataName(%CurTarget) == ffemale || GameBase::getDataName(%CurTarget) == fffemale )
			%curvalue = -10;

//echo(%curvalue @ " "@ %bestvalue);
		if(%curValue > %BestValue)
		{
			%BestValue = %curValue;
			%Best = %CurTarget;
		}
	}
//echo("Attacking: " @ %best);
	$Worm::CurTarget[%worm] = %best;

}

function Worm::UnderTarget(%worm, %target, %pos)
{
	
//echo(%target@":"@getword(%target, 2));

	%toReturn = false;
	//if(!%pos || %pos == 0 || %pos == ""||getword(%target, 2)!=-1)
	if(getword(%target, 2)==-1)
		{
		%vicPos = gamebase::Getposition(%target);

		if(%vicpos=="0 0 0"||gamebase::getdamagestate(%target)!="Enabled")
		{
		%vicpos="0 0 -1000000000";
		}
		}
	else
		%vicPos = %target;
	
	%wormPos = gamebase::Getposition(%worm);
//echo(%Wormpos @" :: " @%vicpos);
//echo(vector::getdistance(%vicpos, %wormpos) @" <= "@(getword(%vicpos, 2) - getword(%wormpos, 2) + 1) @" *** "@gamebase::getdamagestate(%target));
	
	if(vector::getdistance(%vicpos, %wormpos) <= (getword(%vicpos, 2) - getword(%wormpos, 2) + 1))
	{
//echo("Yes");
		%toReturn = true;
	}
	return %toReturn;
}

function Worm::Setposition(%worm, %newPos)
{
//echo("***Old: " @gamebase::Getposition(%worm));
//echo("**NEw: " @%NewPos);
		%X = getword(%newPos,0);
		%Y = getword(%newPos,1);
		//%Z = getword(%newPos,2);
		
		%newPos2 = "0 0 0";
		%continue = true;
		for(%count = 10; %count < 1000 && %continue; %count = %count*2)
		{
//echo("SetPosLoop "@ %count @ " " @ %continue );
			%pos = %X @" "@ %Y @" "@ %count;
			gamebase::setposition(%worm, %pos);
//echo("***setposworm: " @gamebase::Getposition(%worm));
			if(GameBase::getLOSInfo(%worm,%count+5,"-1.570796327 0 0"))
			{
				if(getobjecttype($los::object) == SimTerrain)
				{
					%continue = false;
					%newPos2 = $los::position;
					$Worm::LastX = getword(%newPos2,2);
				}

			}

			if( !%newPos2 || %newPos2 == "0 0 0" || %newPos2 == "")
				%continue = true;
			else
				%continue = false;
		}
		
		// Should never happen. Unless we find a hole....
		if(%continue == true) {
			%newPos2 = %X @" "@ %Y @" -1000";
}		else
			%newPos2 = %X @" "@ %Y @" "@ $Worm::LastX;
//echo("NewPos: " @ %newPos2);
		gamebase::setposition(%worm,vector::add(%NewPos2, "0 0 -3"));
}

function Worm::display(%position, %rotTT,%low)
{
	//if( 50 == floor(getrandom()*100))
	//	Worm::Lightning(%position);
	if(%low)
		%times = floor(getrandom()*5);
	else
		%times = floor(getrandom()*10);

	for(%x = 0; %x < %times; %x++)
	{
//echo("Disploop");
		%xplus = floor(getrandom()*6) - floor(getrandom()*6); 
		%yplus = floor(getrandom()*8) - floor(getrandom()*8); 
		%zplus = floor(getrandom()*5); 
		%pos = GetOffSetRot(%xplus@" "@%yplus@" "@%zplus,%rotTT,%position);
		%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
//echo("Display");
		if(!$worm::sound && false)
		schedule ("Projectile::spawnProjectile(Dust, \"" @ %trans @ "\", \"" @ 2048 @ "\", \"" @ "0 0 0" @ "\");",getrandom()*0.5);
		else{
			$worm::sound = false;
			schedule("$worm::sound = true;",0.7);
		schedule ("Projectile::spawnProjectile(Dust2, \"" @ %trans @ "\", \"" @ 2048 @ "\", \"" @ "0 0 0" @ "\");",getrandom()*0.5);
//echo("Sound");
}

	}
}

function Worm::Lightning(%position)
{
	%rot = "-1.570796327 0 0"; 
	%LGen = newObject("breath","Turret",WormLightningGen,true); 
	addToSet("MissionCleanup", %LGen); 
	GameBase::setPosition(%LGen,vector::Add(%position,"0 0 20")); 
	GameBase::setRotation(%LGen,%rot); 
	
	%LTar = newObject("breath","StaticShape",WormLightningTarget,true); 
	addToSet("MissionCleanup", %LTar); 
	GameBase::setPosition(%LTar,vector::Add(%position,"0 0 1")); 
	
echo(gamebase::getmuzzletransform(%LGen));
	%proj = Projectile::spawnProjectile(WormLightningCharge,gamebase::getmuzzletransform(%LGen),%LGen,Item::getVelocity(%LGen));
	gamebase::setenergy(%LGen, 0);
	echo(%LGen @ " " @ %LTar @" " @%proj);
	//DeleteObject(%LGen);
	//DeleteObject(%LTar);
	schedule("DeleteObject("@%LGen@");",1.9);
	schedule("DeleteObject("@%LTar@");",1.9);
	schedule("DeleteObject("@%proj@");",1.9);
	schedule("Worm::Lightning(\""@%position@"\");",2.0);
}


ExplosionData DustPlume
{
	shapeName = "dustplume.dts";
	//soundId   = turretExplosion; //if were desparate
	//soundId   = rocketExplosion;
	//soundId   = SoundFireFlierRocket;

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.500;
	timeOne  = 1.000;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

//----------------------------------------------------------------------------


GrenadeData Dust
{
	bulletShapeName    = "dustplume.dts";
	explosionTag       = DustPlume;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0.1;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.1;

	inheritedVelocityScale = 1.0;
	smokeName              = "dustplume.dts";
};

ExplosionData DustPlume2
{
	shapeName = "dustplume.dts";
	//soundId   = turretExplosion; //if were desparate
	//soundId   = rocketExplosion;
	//soundId   = SoundFireFlierRocket;// Fix up wormroar to use this with extended range.
	soundId   = WormRoar;// Fix up wormroar to use this with extended range.

	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 1.0;
	timeZero = 0.500;
	timeOne  = 1.000;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

//----------------------------------------------------------------------------


GrenadeData Dust2
{
	bulletShapeName    = "dustplume.dts";
	explosionTag       = DustPlume2;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0.1;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.1;

	inheritedVelocityScale = 1.0;
	smokeName              = "dustplume.dts";
};

//-----------------------------------------------------------------------------
//          Lightning effects
//-----------------------------------------------------------------------------
TurretData WormLightningGen   
{			 
	maxDamage = 100000;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 1;
	visibleToSensor = false;
	dopplerVelocity = 0;
	castLOS = false;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "shotgun";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = WormLightningCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "LGen";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

   isSustained     = true;
   firingTimeMS    = 750;
   energyRate      = 30.0;
};


StaticShapeData WormLightningTarget
{
   description = "LTar";
   shapeFile = "breath";
	className = "Generator";
   //sfxAmbient = WormRoar;
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
   maxDamage = 1.0;
	visibleToSensor = false;
	mapFilter = 4;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

