//**************************************
//***ALL DIDDILY'S WORK
//**************************************


StaticShapeData GrapHook
{
	shapeFile = "mine";
	debrisId = defaultDebrisSmall;
	maxDamage = 0.5;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = debrisExpMedium;
   description = "GrappleHook";
};

LightningData GrappleString
{
   //bitmapName       = "fiery.bmp";
   bitmapName       = "lightningNew.bmp";
   damageType       = $BulletDamageType;
   boltLength       = 2000.0;
   coneAngle        = 2.0;
   damagePerSec      = 0.001;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.2;//075;

   updateTime   = 120;
   skipPercent  = 0.05;
   displaceBias = 0.001;

   lightRange = 0;
   lightColor = { 0.25, 0.25, 0.85 };

   //soundId = SoundELFFire;
};

function graphook::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	HookForce($HookOwner[%this]);
}

GrenadeData HookSmall
{
   bulletShapeName    = "mine.dts";
   explosionTag       = bulletExp1;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.1;

   aimDeflection      = 0.001;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   explosionRadius    = 0.5;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 40;
   totalTime          = 90.0;    // special meaning for grenades...
   liveTime           = 10.00;
   projSpecialTime    = 1000;

   inheritedVelocityScale = 0.4;

   smokeName              = "breath.dts";
};

function HookSmall::oncollision(%this,%obj)
{
echo(%this@" "@%obj);
}
GrenadeData HookMedium
{
   bulletShapeName    = "mine.dts";
   explosionTag       = bulletExp1;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.1;

   aimDeflection      = 0.001;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BulletDamageType;

   explosionRadius    = 0.5;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 80;
   totalTime          = 100.0;    // special meaning for grenades...
   liveTime           = 90.0;
   projSpecialTime    = 1000;

   inheritedVelocityScale = 0.4;

   smokeName              = "breath.dts";
};

GrenadeData HookLarge
{
   bulletShapeName    = "mine.dts";
   explosionTag       = bulletExp1;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.0;
   mass               = 1.0;
   elasticity         = 0.1;

   aimDeflection      = 0.001;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $BulletDamageType;

   explosionRadius    = 0.1;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 120;
   totalTime          = 100.0;    // special meaning for grenades...
   liveTime           = 90.0;
   projSpecialTime    = 1000;

   inheritedVelocityScale = 0.4;

   smokeName              = "breath.dts";
};


function Bloop(%this)
{
	echo(getobjecttype(%this));



}
function Hook::Track(%proj)
{
	if (Player::isDead($HookPl[%proj])) 
	{
	  DeadonGrapple($HookPl[%proj]);
	  return;
	}
	%pos=gamebase::getposition(%proj);
	if((vector::getdistance(item::getvelocity(%proj), "0 0 0")<=0.1)||(vector::getdistance(%pos, $pos[%proj])<=0.031))
	{
	%obj=newObject("GrapHook","StaticShape","GrapHook",true);
	addToSet($HookPl[%proj].HookGroup, %obj);

	gamebase::setposition(%obj, gamebase::getposition(%proj));
	gamebase::setrotation(%obj,%rot);
	$pos[%proj]=-1;
	$pos2[%proj]=-1;
	
	$HookPl[%proj].hookpos=gamebase::getposition(%obj);
	$HookPl[%proj].hook=%obj;
	$HookOwner[%obj]=$HookPl[%proj];
	$HookPl[%proj].nograpshot=0;
	%set = newObject("set",SimSet); // make new box for killing.
	if(containerBoxFillSet(%set,$MoveableObjectType | $VehicleObjectType | $SimPlayerObjectType ,gamebase::getposition(%proj),1.0,1.0,1.0,0)){ // if we find a player or staticshape in the box,
		%num = Group::objectCount(%set);
		if(%num>0)
{
		for(%i=0;%num>%i;%i++){ // To walk through the objects in the box.
			%pos = gamebase::getposition(Group::getObject(%set2,%i));
			if(getobjecttype(Group::getObject(%set,%i))=="Player"&& !Player::isDead(Group::getObject(%set,%i)&&Group::getObject(%set,%i)!=$hookpl[%proj]))
			  GameBase::applyDamage(Group::getObject(%set,%i), $GrappleDamageType, 0.25, %pos, "0 0 0", "0 0 0", player::getclient($hookpl[%proj]));
			}
}
		HookBadTarget($HookPl[%proj]);
		return;
	}
	deleteobject(%set);
	if(vector::getdistance(gamebase::getposition(%proj), gamebase::getposition($HookPl[%proj]))>4)
	{
		if(getword(vector::sub(gamebase::getposition(%proj),gamebase::getposition($HookPl[%proj])),2)<2)
		{
		HookBadTarget($HookPl[%proj]);
		//deleteobject(%proj);
		return;
		}
	}	
	$HookPl[%proj].isgrappling=1;
	
	//GameBase::playSequence(%obj,1,"deploy");
	mounthook($HookPl[%proj]);
	
deleteobject(%proj);
	//echo("ha");
	Client::sendMessage(player::getclient($HookPl[%proj]),0, "Hook ready!");
	MakeRope($HookPl[%proj]);
	DoGrapple($HookPl[%proj]);
	
	return;
	}

	$pos2[%proj]=$pos[%proj];
	$pos[%proj]=%pos;
	
	schedule("Hook::track("@%proj@");", 0.1, %proj);
}
function MakeRope(%pl)
{
%t=gamebase::getmuzzletransform(%pl);
%q=getword(%t, 9)@" "@getword(%t, 10)@" "@getword(%t, 11);
%dir = Vector::sub(%pl.hookpos, %q);
%la=vector::getrotation(%dir);
%la=vector::normalize(%dir);
%trans = vector::getrotation(%la)@" "@%la@" "@vector::getrotation(%la)@" "@%q;	
%rope=Projectile::spawnProjectile("GrappleString", %trans,%pl, item::getvelocity(%pl));
addToSet(%pl.HookGroup, %rope);

}


function Hook::onremove(%this)
{
	
}


function HookC::onremove(%this)
{
	blah();
}

function blah(%obj)
{
	echo($roty);
	if(gamebase::getlosinfo(%obj, 100, gamebase::getrotation(%obj)))
	   echo(getObjectType($los::object));
	if($roty!="moo")
	schedule("Blah("@%obj@");", 1.0, %obj);	

}


function EndGrapple(%pl)
{
   Client::sendMessage(player::getclient(%pl),0, "Hook released.");
   if(%pl.veh)
	{
	if(Gamebase::getcontrolclient(%pl.veh))
		Client::sendMessage(player::getclient(Gamebase::getcontrolclient(%pl.veh)),0, "Grappler released.");
	%pl.veh="";
	
	}
   %pl.isgrappling=0;
   deleteobject(%pl.hookgroup);
   mounthook(%pl);
}

function GrappleSnap(%pl)
{
   Client::sendMessage(player::getclient(%pl),0, "Line snapped!");
	   if(%pl.veh)
	{
	if(Gamebase::getcontrolclient(%pl.veh))
		Client::sendMessage(player::getclient(Gamebase::getcontrolclient(%pl.veh)),0, "Grappler line snapped!");
	%pl.veh="";
	
	}
   %pl.isgrappling=0;
   deleteobject(%pl.hookgroup);
   mounthook(%pl);
}

function DeadonGrapple(%pl)
{
   %pl.isgrappling=0;
      if(%pl.veh)
	{
	if(Gamebase::getcontrolclient(%pl.veh))
		Client::sendMessage(player::getclient(Gamebase::getcontrolclient(%pl.veh)),0, "Grappler died...");
	%pl.veh="";
	
	}
   deleteobject(%pl.hookgroup);
   mounthook(%pl);
}

function HookBadTarget(%pl)
{
   Client::sendMessage(player::getclient(%pl),0, "Hook failed.");
   deleteobject(%pl.hookgroup);
   mounthook(%pl);
}

function HookForce(%pl)
{
   Client::sendMessage(player::getclient(%pl),0, "Hook forced to release!");
   %pl.isgrappling=0;
   deleteobject(%pl.hookgroup);
   mounthook(%pl);
}

function GrappleHook::onMount(%player,%item)
{
	mounthook(%player);
}

function GrappleHook::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 5);
}

function mounthook(%pl)
{
	if(!%pl.nograpshot&&!%pl.isgrappling)
	 if(Player::getMountedItem(%pl,$WeaponSlot) == "GrappleHook")
	{
	  Player::mountItem(%pl, HookGun, 5);
	  schedule("HookCheck("@%pl@");",0.4,%pl);
	}
}

function HookCheck(%pl)
{
	 if(Player::getMountedItem(%pl,$WeaponSlot) != "GrappleHook")
	{
	  Player::unmountItem(%pl, 5);
	 
	}
}


ItemImageData HookgunImage
{
	shapeFile = "mine";
	mountPoint = 0;
	mountOffset = {0.0,0.6,0.0};
	mountRotation = {$pi/6,$pi/2,-1*$pi/2};
	firstPerson = "true";
	accuFire = "false";
	weaponType = 0;  // Sustained
	reloadTime = 0;
	fireTime = 1;
	sfxFire = "SoundThrowItem";
	minEnergy = 0;
	maxEnergy = 0;

	sfxActivate = "SoundPickUpWeapon";
};

ItemData HookGun
{
	description = "Combat Knife";
	heading = "bWeapons";
	className = "tool";
	shapeFile = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = "HookGunImage";
	price = 5;
	showInventory = "false";
	showWeaponBar = "false";	
};
	
$baba=1;
$brace=0.5;
$str=100;
$offset=0.45;
$scale=4;


function AllowSwing(%pl)
{
  %pl.swingmove--;
  if(%pl.swingmove<0)
	%pl.swingmove=0;
  if(%pl.swingmove==0)
	%pl.noswingmove=0;
}


function Vector::scale(%vec, %scalar)
{
	%x = getWord(%vec, 0);
	%y = getWord(%vec, 1);
	%z = getWord(%vec, 2);

	%x *= %scalar;
	%y *= %scalar;
	%z *= %scalar;

	%result = %x @ " " @ %y @ " " @ %z;

	return %result;
}


function DoGrapple(%pl)
{
	
	if (Player::isDead(%pl)) 
		DeadonGrapple(%pl);

	if(!%pl.isgrappling)
		return;
	%t = gamebase::getmuzzletransform(%pl);
	%v = getword(%t, 6)@" "@getword(%t, 7)@" "@getword(%t, 8);
	%q = getword(%t, 9)@" "@getword(%t, 10)@" "@getword(%t, 11);
	%dir = Vector::sub(%pl.hookpos, gamebase::getposition(%pl));
	%mooy = 1;
	%blag = 1;

	if(getword(%dir, 2) <= -0.2)
		%mooy = 0;

	if(getword(%dir, 2) >= -5.2)
	{
		%dist = %dir;
		%rot = vector::getrotation(%v);
		%rot2 = getword(%rot, 0)@" "@getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
		%distance = vector::getdistance(%rot, %rot2);
	
		if(%distance >= 3)
		   	%rot=-1*getword(%rot, 0)@" "@-1*getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
	
		if(player::getmounteditem(%pl, 0) != "GrappleHook")
			%rot="0 0 0";

		%dir = Vector::scale(getword(%dir,0)@" "@getword(%dir,1)@" 0", 1);//change this for faster swing


		%lookDir = getword(%rot, 0);
		
		%pos = gamebase::getPosition(%pl);
		%down = vector::Add(%pos,"0 0 -1");
		%mask = ~0 ^ $BitMask::Player; 
		// If nothing is under us, make our lookdir fast to zip down.
		if(%lookDir < 0 && !getlosinfo(%pos,%down,%mask))
		{
			%lookDir = %lookDir*%lookDir*3;
			%lookDir = -1*%lookdir;
		}		

		%dir = vector::add(%dir, "0 0 "@(%lookDir+0.45)*25);
		
		if(%lookDir<-0.9)
			%dir=vector::sub(%dir, "0 0 -10");
		%zvel=0.0;
		
		if(!%mooy)
		{
			%dir = Vector::scale(%dir, 0.05);
			%dir = getword(%dir, 0)@" "@getword(%dir, 1)@" 0";
			%zvel=getword(item::getvelocity(%pl), 2);
		} else 
		{
			%sc=0.97;
		
			if(%pl.swingslow)
				%sc=0.8;
		
			%vel = vector::scale(item::getvelocity(%pl), %sc);
			%zvel = 0.0;
			%test = gamebase::getlosinfo(%pl, 1, -1*getword(%rot, 0)@" 0 0")
				&& player::getmounteditem(%pl, 0) == "GrappleHook";
			if(%test)
			{
				%vel=vector::scale(item::getvelocity(%pl), 0.75);
			}

			if((vector::getdistance("0 0 0", item::getvelocity(%pl))>13) && gamebase::getlosinfo(%pl, 5))
			{
				if(%pl.swingslow||!%pl.noswingmove)
				{
					%pl.noswingmove=1;
					%pl.swingmove++;
					schedule("AllowSwing("@%pl@");", 1);
					%vel=vector::scale(item::getvelocity(%pl), %sc-0.5);
				}
			}

			if(vector::getdistance("0 0 0", item::getvelocity(%pl)) > 5 
				&& (gamebase::getlosinfo(%pl, 5,"-1.575 0 0")))
			{
				// We're standing on something.. don't let us go this fast.
				item::SetVelocity(%pl,"0 0 0");
				%scale = 5/vector::GetDistance("0 0 0",%dir);
				
				%dir = vector::scale(%dir,%scale);
			}

			item::setvelocity(%pl, getword(%vel, 0)@" "@getword(%vel, 1)@" "@%zvel);
		}

// Don't apply a velocity if the angle to target is more than 45 (0.7071)
		%totDist = Vector::getDistance(%pl.hookpos, gamebase::getposition(%pl));
		%ZDist = Vector::getDistance("0 0 "@getword(%pl.hookpos,2),"0 0 "@getword(gamebase::getposition(%pl),2));

		if(%totDist < 10 || sin(%ZDist/%totDist) > 0.7071)
			Player::applyImpulse(%pl, %dir);
		else
			GrappleSnap(%pl); // If people want to abuse it, then they'll get burnt. No other choice.

	}
	schedule("DoGrapple("@%pl@");", 0.1, %pl);
}

function dorepel(%cl)
{

%t=gamebase::getmuzzletransform(%cl);
	%v=getword(%t, 6)@" "@getword(%t, 7)@" "@getword(%t, 8);
	%rot=vector::getrotation(%v);
	%rot2=getword(%rot, 0)@" "@getword(%rot, 1)@" "@getword(gamebase::getrotation(%cl), 2);
	%distance=vector::getdistance(%rot, %rot2);
	if(%distance>=3)
	  %rot=-1*getword(%rot, 0)@" "@-1*getword(%rot, 1)@" "@getword(gamebase::getrotation(%cl), 2);
  if(gamebase::getlosinfo(%cl, 1, -1*getword(%rot, 0)@" 0 0"))
	{
	%dir=vector::scale($los::normal, 30);
	Client::sendMessage(player::getclient(%cl),0, "Repelling!");
	%cl.noswingmove=1;
	%cl.swingmove++;
	schedule("AllowSwing("@%cl@");", 1);
	Player::applyImpulse(%cl, %dir);
	return;
	}
}
$Pi= 3.141592654;
$PiF=0.78539816339744830961566084581988; //Pi Fourth
$SwingRot[8]=0*$PiF;
$SwingRot[9]=1*$PiF;
$SwingRot[6]=2*$PiF;
$SwingRot[3]=3*$PiF;
$SwingRot[2]=4*$PiF;
$SwingRot[1]=5*$PiF;
$SwingRot[4]=6*$PiF;
$SwingRot[7]=7*$PiF;

function Swing(%pl,%value)
{
if(%pl.noswingmove)
	return;

if(%value=="0")
{
	DoRepel(%pl);
	return;
}
if(%value=="5")
{
	%pl.noswingmove=1;
%pl.swingmove++;
schedule("AllowSwing("@%pl@");", 1);
	%pl.swingslow=1;
        schedule(%pl@".swingslow=0;", 0.5);
	return;
}
%t=gamebase::getmuzzletransform(%pl);
	%v=getword(%t, 6)@" "@getword(%t, 7)@" "@getword(%t, 8);
	%rot=vector::getrotation(%v);
	%rot2=getword(%rot, 0)@" "@getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
	%distance=vector::getdistance(%rot, %rot2);
	if(%distance>=3)
	  %rot=-1*getword(%rot, 0)@" "@-1*getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
for(%x = 0; %x < 8; %x++)
{
	%off=%x*$PiF;
	%dir=vector::sub(getword(gamebase::getrotation(%pl), 2), %off);
	for(%z = 0; %z < 8; %z++)
	{
	%offz=%z*$PiF;
         if(gamebase::getlosinfo(%pl, 1.0, %offz+(-1*getword(%rot, 0))@" 0 "@%dir))
	{
		return;
	}
}
}
%pl.noswingmove=1;
%pl.swingmove++;
schedule("AllowSwing("@%pl@");", 1);
%rot=$SwingRot[%value];
%moo=vector::sub(gamebase::getrotation(%pl), "0 0 "@%rot);
%dir=vector::getfromrot(%moo, 50);
Player::applyImpulse(%pl, %dir);

}

function StartGrappleFromChopper(%pl, %vehicle, %off)
{
	Player::mountItem(%pl,GrappleHook,$WeaponSlot);
	
	%byename="HookGroup"@%pl;
	%bye=newObject(%byename, SimGroup);
	addToSet("MissionCleanup", %bye);
	%pl.hookgroup=%bye;
	%pl.hookpos=vector::add(gamebase::getposition(%vehicle), %off);
	makerope(%pl);
	%pl.off=%off;
	%pl.isgrappling=1;
	%pl.veh=%vehicle;
	%pl.lastvehpos=gamebase::getposition(%pl.veh);
	DoHeliGrap(%pl);
	schedule("Player::unmountItem("@%player@", 5);", 0.1);
}


function DoHeliGrap(%pl)
{
	if (Player::isDead(%pl)) 
	  DeadonGrapple(%pl);

	if(!%pl.isgrappling)
	   return;
	
	if(gamebase::getposition(%pl.veh) == "0 0 0")
	{
	
	  %pl.veh="";
   	  GrappleSnap(%pl);

	}	

	%t=gamebase::getmuzzletransform(%pl);
	%v=getword(%t, 6)@" "@getword(%t, 7)@" "@getword(%t, 8);
	%q=getword(%t, 9)@" "@getword(%t, 10)@" "@getword(%t, 11);
	//makechoprope(%pl);
	%dir = Vector::sub(vector::add(gamebase::getposition(%pl.veh), vector::getfromrot(vector::add(%pl.off,gamebase::getrotation(%pl.veh)), 2.7)), gamebase::getposition(%pl));
	if(getword(%dir, 2)>=-0.2)
	 	  {
	%rot=vector::getrotation(%v);
	%rot2=getword(%rot, 0)@" "@getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
	%distance=vector::getdistance(%rot, %rot2);
	if(%distance>=3)
	   	%rot=-1*getword(%rot, 0)@" "@-1*getword(%rot, 1)@" "@getword(gamebase::getrotation(%pl), 2);
		if(player::getmounteditem(%pl, 0)!="GrappleHook")
		  %rot="0 0 0";
%zdist=vector::getdistance("0 0 "@getword(gamebase::getposition(%pl), 2),"0 0 "@getword(gamebase::getposition(%pl.veh), 2));
if(%zdist>=90)
	{
	%rot="1 0 0";
	bottomprint(player::getclient(%pl), "Bottom of line reached.");
	}
		%dir = Vector::scale(getword(%dir,0)@" "@getword(%dir,1)@" 0", 3);
		%dir = vector::add(%dir, "0 0 "@(getword(%rot, 0)+0.45)*25);
		%dist=vector::sub(gamebase::getposition(%pl.veh), %pl.lastvehpos);
		%extra= vector::scale(%dist, -10);
		
		%zext=getword(%dist, 2)*75;
		if(vector::getdistance(%extra, "0 0 0")>50)
			GrappleSnap(%pl);
		%dir = vector::add(%dir, %extra);
		if(%zext<=0||gamebase::getlosinfo(%pl, 1, -1.5707+(-1*getword(%rot, 0))@" 0 0"))
		  %dir = vector::add(%dir, "0 0 "@%zext);
		%sc=0.97;
		if(%pl.swingslow)
			%sc=0.8;
		%vel=vector::scale(item::getvelocity(%pl), %sc);
		%zvel=0.0;
		item::setvelocity(%pl, getword(%vel, 0)@" "@getword(%vel, 1)@" "@%zvel);
		//item::setvelocity(%pl, getword(%vel, 0)@" "@getword(%vel, 1)@" "@%zvel);
		Player::applyImpulse(%pl, %dir);
		}
		%pl.lastvehpos=gamebase::getposition(%pl.veh);
			schedule("DoHeliGrap("@%pl@");", 0.1, %pl);

}

$GrappleDamageType=21;

$deathMsg[$GrappleDamageType, 0]      = "%2 ended up on the wrong end of %1's hook.";
$deathMsg[$GrappleDamageType, 1]      = "%2 was got %4 insides yanked out by %1.";
$deathMsg[$GrappleDamageType, 2]      = "%1 implanted %3 hook into %2's skull.";
$deathMsg[$GrappleDamageType, 3]      = "%1 really hooked %2.";

$DamageScale[marmor,	$GrappleDamageType] = 1.0;		     $DamageScale[mfemale,	$GrappleDamageType] = 1.0;
$DamageScale[sarmor,	$GrappleDamageType] = 1.0;		     $DamageScale[sfemale,	$GrappleDamageType] = 1.0;
$DamageScale[iarmor,	$GrappleDamageType] = 1.0;		     $DamageScale[ifemale,	$GrappleDamageType] = 1.0;
$DamageScale[garmor,	$GrappleDamageType] = 1.0;		     $DamageScale[gfemale,	$GrappleDamageType] = 1.0;
$DamageScale[earmor,	$GrappleDamageType] = 1.0;		     $DamageScale[efemale,	$GrappleDamageType] = 1.0;
$DamageScale[carmor,	$GrappleDamageType] = 1.0;		     $DamageScale[cfemale,	$GrappleDamageType] = 1.0;
$DamageScale[larmor,	$GrappleDamageType] = 1.0;		     $DamageScale[lfemale,	$GrappleDamageType] = 1.0;
$DamageScale[aarmor,	$GrappleDamageType] = 1.0;		     $DamageScale[afemale,	$GrappleDamageType] = 1.0;
$DamageScale[comarmor,	$GrappleDamageType] = 1.0;		     $DamageScale[comfemale,	$GrappleDamageType] = 1.0;

$DamageScale[marmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[mfemale2,	$GrappleDamageType] = 1.0;
$DamageScale[sarmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[sfemale2,	$GrappleDamageType] = 1.0;
$DamageScale[iarmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[ifemale2,	$GrappleDamageType] = 1.0;
$DamageScale[garmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[gfemale2,	$GrappleDamageType] = 1.0;
$DamageScale[earmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[efemale2,	$GrappleDamageType] = 1.0;
$DamageScale[carmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[cfemale2,	$GrappleDamageType] = 1.0;
$DamageScale[larmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[lfemale2,	$GrappleDamageType] = 1.0;
$DamageScale[aarmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[afemale2,	$GrappleDamageType] = 1.0;
$DamageScale[comarmor2,	$GrappleDamageType] = 1.0;		     $DamageScale[comfemale2,	$GrappleDamageType] = 1.0;

$DamageScale[marmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[mfemale3,	$GrappleDamageType] = 1.0;
$DamageScale[sarmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[sfemale3,	$GrappleDamageType] = 1.0;
$DamageScale[iarmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[ifemale3,	$GrappleDamageType] = 1.0;
$DamageScale[garmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[gfemale3,	$GrappleDamageType] = 1.0;
$DamageScale[earmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[efemale3,	$GrappleDamageType] = 1.0;
$DamageScale[carmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[cfemale3,	$GrappleDamageType] = 1.0;
$DamageScale[larmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[lfemale3,	$GrappleDamageType] = 1.0;
$DamageScale[aarmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[afemale3,	$GrappleDamageType] = 1.0;
$DamageScale[comarmor3,	$GrappleDamageType] = 1.0;		     $DamageScale[comfemale3,	$GrappleDamageType] = 1.0;
