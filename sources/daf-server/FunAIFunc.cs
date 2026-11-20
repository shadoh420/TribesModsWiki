
//AI::ActionResult(); 
//AI::Attack();  *** Doesn't work
//AI::CallbackDied(); 
//AI::CallbackPeriodic(); 
//AI::CallWithId(); 
//AI::Delete(); 
//AI::DirectiveCallback1(); 
//AI::DirectiveCallback2(); 
//AI::DirectiveCallback3(); 
//AI::DirectiveCallback4(); 
//AI::DirectiveFollow(); 
//AI::DirectiveList(); 
//AI::DirectiveRemove(); 
//AI::DirectiveTarget(); 
//AI::DirectiveTargetLaser(); 
//AI::DirectiveTargetPoint(); 
//AI::DirectiveWaypoint(); 
//AI::GetCount(); 
//AI::GetId(); 
//AI::GetObject(); 
//AI::GetTarget(); 
//AI::List(); 
//AI::SetAutomaticTargets(); 
//AI::SetScriptedTargets();   *** Doesn't work
//AI::SetVar(); 
//AI::Spawn(); 
//AI::CallbackBored()
//
// iq
//attackMode
//pathType
//spotDist
//seekOff
//triggerWindup
//triggerPct
//smartGuyWeaponRange
//dumbGuyWeaponRange
//smartGuyMinAccuracy
//
//
//
//433 -337 584
//
//
//
//


//this one still needs work...
function AAI::HumanShield(%cl)
{


%aipos = gamebase::getposition(AI::GetID("Hostage1"));
//%dot = vector::dot(, item::Getvelocity(%cl));
%dist = vector::getdistance(item::Getvelocity(%cl), "0 0 0");
%rot = vector::getfromrot(gamebase::getrotation(%cl), %dist);



	AI::SetVAR("Hostage1", Seekoff, %rot);

schedule("AAI::HumanShield("@%cl@");", 0.25);
}


function AI::Circle(%ainame, %dist, %speed, %x)
{


if(%x >= 2)
	%x = 0;

%rot = vector::getfromrot(0@" 0 "@%x*$pi, %dist);
//echo(%rot);
AI::SetVAR(%ainame, Seekoff, %rot);

schedule("AI::Circle("@ %ainame @", "@ %dist @", "@ %speed @", "@%x+$pi/12@");", %speed);
}

function AI::random()
{

%x = getrandom()*2;

%rot = vector::getfromrot(0@" 0 "@%x*$pi, 3);
//echo(%rot);
AI::SetVAR("Hostage1", Seekoff, %rot);
if($gogo)
schedule("AI::Random();", 1.5);
}
