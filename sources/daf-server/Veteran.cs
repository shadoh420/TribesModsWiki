//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Sorry pilots. This module is for ground combatants only.
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Adds veteran abilities to weapons of your choice.
// Basically, your veteran status builds up during each spawn.
// Once you die, it goes away and you have to start all over again.
// To reach the first veteran status, you need to kill X number of
// people with one weapon. The veteran status only builds up on
// individual weapons however. Killing one guy with a pistol and
// and two guys with an M16 won't get you veteran status if the
// first vet level is set to 3. You need to kill 3 guys with the 
// pistol OR with the M16, and then you get the vet status for that
// weapon only.
// The different advantages of the vet stati differ for each weapon,
// but for the most part (all the bullet/laser weapons) your accuracy
// improves. A normal M16er has a bullet deflection of X; a level 1
// vet M16er could have a bullet deflection of X/Y; a level 2 vet
// M16er could have a bullet deflection of X/ZY; ect.
// Note: Don't make any of the deflections TOO low (unless it's a
// sniper rifle of course). All that will do is have people sniping
// with pistols/saws/m16s ect. Not too bad sounding? Well.. consider
// the fact that they have as much zoom as a sniper rifle as well...
//
// Needs just a little bit of tailoring in order to make it work:
// 1) Add a line in Client::onKilled(%playerId, %killerId, %damageType)
//    in game.cs
//   Veteran::IncreaseKills(%playerId.LastDamagedBy,%playerId,%playerId.LastDamagedByType);
//    
// 2) In player.cs in Player::onDamage... replace the line:
//    %value = $DamageScale[%armor, %type] * %value * %friendFire;
//    with:
//    if(%type == $FlameThrowerDamageType)
//    {
//    	%value = $DamageScale[%armor, %type, %cl] * %value * %friendFire;
//    } else {
//	%value = $DamageScale[%armor, Veteran::getRealDamageType(%type)] * %value * %friendFire;
//    }
// 3) In game.cs function Game::onPlayerConnected(%playerId), add the line:
//    $DamageScale[iarmor, $PlasmaDamageType, %playerId] = $DamageScale[iarmor, $PlasmaDamageType];
//    to the beginning of the function.
// 4) Go through, in item.cs, all the weapons we are "veteranizing"
//    and comment out the projectile assignment in the weaponImage
//    block, if it hasn't already been done.
// 5) In server.cs, function createServer(%mission, %dedicated)
//    add to the exec(); calls, the line:
//    exec("Veteran.cs");
// 6) The crappy part i didn't anticipate: In player.cs change all
//    instances of %type in player::ondamage to:
//    Veteran::getRealDamageType(%type) (except for the spot we took
//    care of in 2, and the LAST line where it calls client::onkilled)
// 7) More crappy part. In game.cs change all the instances of %damagetype
//    in client::onkilled to:
//    Veteran::getRealDamageType(%damagetype) (except for the line
//    we added in 1)
// 8) In Staticshape.cs sandbag::ondamage, add the line:
//    %type = Veteran::getRealDamageType(%type); 
//    to the beginning
// 9) In vehicle.cs vehicle::ondamage, add the line:
//    %type = Veteran::getRealDamageType(%type); 
//    to the beginning
// 10) In player.cs in Player::onDamage... put this:
//			%guy = Player::getClient(%object);
//			if(%guy == 0){
//				%guy = %object;
//			}
//			if(%damagedClient != %guy && %guy != "" && %guy > 2048)
//			{
//				%damagedCLient.LastDamagedByType = %type;
//				%damagedClient.LastDamagedBy = %guy;
//			}
//	right between these lines:
//			} else if((Veteran::getRealDamageType(%type) == $BulletDamageType || Veteran::getRealDamageType(%type) == $ShrapnelDamageType || Veteran::getRealDamageType(%type) == $LaserDamageType) && %vertPos == "torso" && (%quadrant == "front_left" || %quadrant == "back_left")) {
//				
//				$PlayerBleeding[Player::getClient(%this)] = 1;
//				schedule("BleedTick("@%this@", "@%object@");", 3, %this);
//			} 
//			// You want it here.			
//
//			// END DELTAFORCE
//			//If Shield Pack is on
//			if (Veteran::getRealDamageType(%type) != -1 && %this.shieldStrength) {
//	
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Here we define some new damage types, and redefine the old ones
// so we don't have to screw around fixing *everything* so that it
// accepts the new code.
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

$SAWDamageType = 100; // Better aim
$M16DamageType = 101; // Better aim
$PistolDamageType = 102; // Better aim
$MP5DamageType = 103; // Better aim
$RobarDamageType = 104; // Better aim
$PSG1DamageType = 105; // Better aim
$ShotGunDamageType = 106; // Better aim
$LawDamageType = 107; // Don't have to wait as long-> Don't have to wait-> Don't have to kneel(do they kneel? If not, don't have to wait here, and don't have to wait as long on the prev)
$FlameThrowerDamageType = 108; // Personal armor more resistant to flame-> More resis -> Immune

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Here are the constants for this module.
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

$Veteran::L1VetKills = 3; // How many kills to get to be a level 1 vet?
$Veteran::L2VetKills = $Veteran::L1VetKills + 2; // How many kills to get to be a level 2 vet?
$Veteran::L3VetKills = $Veteran::L2VetKills + 5; // How many kills to get to be a level 3 vet?


//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// We're going to redefine new projectiles for all stages of the 
// veterancy, even the non-vets, so that we don't screw anything
// up. We're then going to redefine new onfire functions for all
// the weapons.
// Heres the new projectiles.
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

// I don't actually use a knife stab in mine, but you do I believe.
// I'd define the three Knife stabs as increasing in damage.
// Normal does normal stab damage, vet1 does half damage, vet2
// does almost kill, and vet3 does instant kill.
// I would also then remove the specops insta-kill knife.

BulletData NewKnifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0.3;
   damageType         = $StabDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

BulletData Vet1KnifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0.5;
   damageType         = $StabDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

BulletData Vet2KnifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 0.7;
   damageType         = $StabDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

BulletData Vet3KnifeStab
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   mass               = 0.1;
   
   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $StabDamageType;

   muzzleVelocity     = 15.0;
   totalTime          = 0.1;
   	
   lightRange         = 0.0;
   lightColor         = { 1.0, 0, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = false;

};

//----------------------------------------------------------------

BulletData NewPistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PistolDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet1PistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PistolDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet2PistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PistolDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet3PistolBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PistolDamageType;

   aimDeflection      = 0.0035;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

//----------------------------------------------------------------

BulletData NewSAWBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $SAWDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet1SAWBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $SAWDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet2SAWBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $SAWDamageType;

   aimDeflection      = 0.0055;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

BulletData Vet3SAWBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $SAWDamageType;

   aimDeflection      = 0.0035;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

//----------------------------------------------------------------

BulletData NewM16Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $M16DamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 50;
};


BulletData Vet1M16Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $M16DamageType;

   aimDeflection      = 0.0035;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 50;
};


BulletData Vet2M16Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $M16DamageType;

   aimDeflection      = 0.0025;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 50;
};


BulletData Vet3M16Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $M16DamageType;

   aimDeflection      = 0.001;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 50.0;
   tracerLength       = 50;
};

//----------------------------------------------------------------

BulletData NewMP5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $MP5DamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet1MP5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $MP5DamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet2MP5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $MP5DamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet3MP5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $MP5DamageType;

   aimDeflection      = 0.0045;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

//----------------------------------------------------------------

BulletData NewPSG1Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PSG1DamageType;

   aimDeflection      = 0.0009;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

BulletData Vet1PSG1Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PSG1DamageType;

   aimDeflection      = 0.0006;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

BulletData Vet2PSG1Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PSG1DamageType;

   aimDeflection      = 0.00045;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};


BulletData Vet3PSG1Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PSG1DamageType;

   aimDeflection      = 0.00015;
   muzzleVelocity     = 650.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

//----------------------------------------------------------------

BulletData NewRobarBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.85;
   damageType         = $RobarDamageType;

   aimDeflection      = 0.0005;
   muzzleVelocity     = 750.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

BulletData Vet1RobarBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.85;
   damageType         = $RobarDamageType;

   aimDeflection      = 0.0003;
   muzzleVelocity     = 750.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

BulletData Vet2RobarBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.85;
   damageType         = $RobarDamageType;

   aimDeflection      = 0.0002;
   muzzleVelocity     = 750.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

BulletData Vet3RobarBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.85;
   damageType         = $RobarDamageType;

   aimDeflection      = 0.0000;
   muzzleVelocity     = 750.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 5;
};

//----------------------------------------------------------------

BulletData NewShotgunFlechette
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.03;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 5;
};


BulletData Vet1ShotgunFlechette
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 5;
};


BulletData Vet2ShotgunFlechette
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 5;
};


BulletData Vet3ShotgunFlechette
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 500.0;
   totalTime          = 1.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 5;
};

//----------------------------------------------------------------

BulletData NewShotgunSlug
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.01;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet1ShotgunSlug
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.008;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet2ShotgunSlug
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.007;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};


BulletData Vet3ShotgunSlug
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $ShotGunDamageType;

   aimDeflection      = 0.006;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 100.0;
   tracerLength       = 50;
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Here we're just going to redefine all the onfire functions for
// all the weapons. This means that you'll have to go through each
// weapon and comment out the "projectileType = whatever;" line in
// each weaponImage (or else the onfire won't call).
// If any of these onfires are different from mine (what's here)
// then you'll have to change them.
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


function KnifeImage::onFire(%player, %slot) {
	
	
	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;
	
	AAI::AddToStats(%cl, "knifefired");

	if($Veteran::Kills[%cl,Knife] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3KnifeStab;
	} else if($Veteran::Kills[%cl,Knife] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2KnifeStab;
	} else if($Veteran::Kills[%cl,Knife] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1KnifeStab;
	} else
	{
		%projectile = NewKnifeStab;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
}


function SOCOMImage::onFire(%player, %slot) {
	

	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;
	
	AAI::AddToStats(%cl, "socomfired");

	if($Veteran::Kills[%player,%cl,Pistol] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3PistolBullet;
	} else if($Veteran::Kills[%cl,Pistol] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2PistolBullet;
	} else if($Veteran::Kills[%cl,Pistol] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1PistolBullet;
	} else
	{
		%projectile = NewPistolBullet;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, SOCOMAmmo);
}


function OICWImage::onFire(%player, %slot) {
	

	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
	{
		%cl = %player;
	}
	
	AAI::AddToStats(%cl, "oicwfired");

	if($Veteran::Kills[%cl,M16] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3M16Bullet;
	} else if($Veteran::Kills[%cl,M16] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2M16Bullet;
	} else if($Veteran::Kills[%cl,M16] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1M16Bullet;
	} else
	{
		%projectile = NewM16Bullet;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, OICWAmmo);
}


function SAWImage::onFire(%player, %slot) {
	

	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;

	AAI::AddToStats(%cl, "sawfired");	

	if($Veteran::Kills[%cl,SAW] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3SAWBullet;
	} else if($Veteran::Kills[%cl,SAW] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2SAWBullet;
	} else if($Veteran::Kills[%cl,SAW] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1SAWBullet;
	} else
	{
		%projectile = NewSAWBullet;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, SAWAmmo);
}


function MP5Image::onFire(%player, %slot) {
	
	//AAI::onFire(%player,true);


	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;
	if($Veteran::Kills[%cl,MP5] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3MP5Bullet;
	} else if($Veteran::Kills[%cl,MP5] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2MP5Bullet;
	} else if($Veteran::Kills[%cl,MP5] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1MP5Bullet;
	} else
	{
		%projectile = NewMP5Bullet;
	}	
	
	%cl = Player::getClient(%player);
	if ($MP5NotReady[%cl] == 0) {
		%vel = Item::getVelocity(%player);
		%trans = Veteran::GetTransform(%player);
		if($MP5Mode[%cl] == 1) { // Three-shot Burst
			%ammoRemaining = Player::getItemCount(%player, MP5Ammo);
			if(%ammoRemaining > 3)
				%ammoRemaining = 3;
			for (%i = 0; %i < %ammoRemaining; %i++) 
			{
				schedule("MP5::Burst("@%projectile@", "@%player@");", %i * 0.1);
				
			}
			$MP5NotReady[%cl] = 1;
			schedule("$MP5NotReady["@%cl@"] = 0;", 0.5);
		} else
		{
			AAI::AddToStats(%cl, "MP5fired");
			%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
			AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)), true);
			Player::decItemCount(%player, MP5Ammo);
		}
	} else MP5Loading(%player);
}

function MP5::Burst(%projectile, %player)
{
	%cl = Player::getClient(%player);
	AAI::AddToStats(%cl, "Mp5fired");
	%vel = Item::getVelocity(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, %vel);
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)), true);
	Player::decItemCount(%player, MP5Ammo);

}
function PSG1Image::onFire(%player, %slot) {
	

	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;

	AAI::AddToStats(%cl, "psg1fired");
	
	if($Veteran::Kills[%cl,PSG1] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3PSG1Bullet;
	} else if($Veteran::Kills[%cl,PSG1] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2PSG1Bullet;
	} else if($Veteran::Kills[%cl,PSG1] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1PSG1Bullet;
	} else
	{
		%projectile = NewPSG1Bullet;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, PSG1Ammo);
}


function FiftyCalImage::onFire(%player, %slot) {
	
	

	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;

	AAI::AddToStats(%cl, "FiftyCalfired");

	if($Veteran::Kills[%cl,Robar] >= $Veteran::L3VetKills)
	{
		%projectile = Vet3RobarBullet;
	} else if($Veteran::Kills[%cl,Robar] >= $Veteran::L2VetKills)
	{
		%projectile = Vet2RobarBullet;
	} else if($Veteran::Kills[%cl,Robar] >= $Veteran::L1VetKills)
	{
		%projectile = Vet1RobarBullet;
	} else
	{
		%projectile = NewRobarBullet;
	}	
	%cl = Player::getClient(%player);
	%trans = Veteran::GetTransform(%player);
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, FiftyCalAmmo);
}


function AutoShotgunImage::onFire(%player, %slot) 
{
	
	%cl = Player::getClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;

	AAI::AddToStats(%cl, "shotgunfired");

	if($Veteran::Kills[%cl,Shotgun] >= $Veteran::L3VetKills)
	{	
		if($ShotgunMode[%cl] == 0)
			%projectile = Vet3ShotgunFlechette;
		else
			%projectile = Vet3ShotgunSlug;
	} else if($Veteran::Kills[%cl,Shotgun] >= $Veteran::L2VetKills)
	{
		if($ShotgunMode[%cl] == 0)
			%projectile = Vet2ShotgunFlechette;
		else
			%projectile = Vet2ShotgunSlug;
	} else if($Veteran::Kills[%cl,Shotgun] >= $Veteran::L1VetKills)
	{
		if($ShotgunMode[%cl] == 0)
			%projectile = Vet1ShotgunFlechette;
		else
			%projectile = Vet1ShotgunSlug;
	} else
	{
		if($ShotgunMode[%cl] == 0)
			%projectile = NewShotgunFlechette;
		else
			%projectile = NewShotgunSlug;
	}	

	%trans = Veteran::GetTransform(%player);
	AAI::onFire(%player, getword(%trans, 3)@" "@getword(%trans, 4)@" "@getword(%trans, 5));
	if ($ShotgunMode[%cl] == 0) {   // Flechette Mode
		for (%i = 0; %i < 8; %i++) {
			Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
			
		}
	} else {				  // Slug Mode
		Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
		
	}
	Player::decItemCount(%player, AutoShotgunAmmo);
}


// Handle this how it's handled in your code.
function LAWImage::onFire(%player, %slot) 
{
	%cl = Gamebase::getOwnerClient(%player);
	if(Player::isAIControlled(%player))
		%cl = %player;
	%projectile = LAWRocket;

	if($Veteran::Kills[%cl,LAW] >= $Veteran::L3VetKills)
	{
		%div = 50;
		%delay = 0.4;
	} else if($Veteran::Kills[%cl,LAW] >= $Veteran::L2VetKills)
	{
		%div = 40;
		%delay = 0.7;
	} else if($Veteran::Kills[%cl,LAW] >= $Veteran::L1VetKills)
	{
		%div = 30;
		%delay = 0.8;
	} else
	{
		%div = 15;
		%delay = 1.0;
	}	

	schedule("LAWImage::finishFiring("@%player@","@%slot@","@%cl@","@%div@","@%projectile@");",%delay);
}

function LAWImage::finishFiring(%player,%slot,%cl,%div,%projectile)
{
	

	%vel = item::Getvelocity(%player);
	%trans = Veteran::GetTransform(%player);
	%x = (getRandom()+0.0001)*getword(%vel,0)/(%div);
	%y = (getRandom()+0.0001)*getword(%vel,1)/(%div);
	%z = (getRandom()+0.0001)*getword(%vel,2)/(%div);
	if(%x > 0.4)
		%x = 0.4;
	else if(%x < -0.4)
		%x = -0.4;

	if(%y > 0.4)
		%y = 0.4;
	else if(%y < -0.4)
		%y = -0.4;

	if(%z > 0.4)
		%z = 0.4;
	else if(%z < -0.4)
		%z = -0.4;

	%trans = getWord(%trans,0) @ " " @ getWord(%trans,1) @ " " @ getWord(%trans,2) @ " " @ getWord(%trans,3)+%x @ " " @ 
		getWord(%trans,4)+%y @ " " @ getWord(%trans,5)+%z @ " " @ getWord(%trans,6) @ " " @ getWord(%trans,7) @ " " @ 
		getWord(%trans,8) @ " " @ getWord(%trans,9) @ " " @ getWord(%trans,10) @ " " @ getWord(%trans,11);
		
	%cl = Player::getClient(%player);
	AAI::AddToStats(%cl, "Lawfired");
	%bullet = Projectile::spawnProjectile(%projectile, %trans, %player, Item::getVelocity(%player));
	AAI::onFire(%player, vector::normalize(item::getvelocity(%bullet)));
	Player::decItemCount(%player, LAWAmmo);
	schedule("Player::decItemCount("@%player@", LAW);",0.5);
	if(Player::isAIControlled(%player))
		   schedule("Player::mountItem("@%player@", SOCOM, 0);",2);

}

// Standard. We're handling the flamethrower a tad differently.
function Flamethrower::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FuelPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have a Fuel Pack to use the Flamethrower."); 
}

function Veteran::updateFlamethrower(%player)
{
	%cl = Gamebase::getOwnerClient(%player);
	// Only applies to infantry armor

	if($Veteran::Kills[%cl,Flamethrower] >= $Veteran::L3VetKills)
	{
		$DamageScale[iarmor, $PlasmaDamageType, %player] = 0.0;
	} else if($Veteran::Kills[%cl,Flamethrower] >= $Veteran::L2VetKills)
	{
		$DamageScale[iarmor, $PlasmaDamageType, %player] = 0.2;
	} else if($Veteran::Kills[%cl,Flamethrower] >= $Veteran::L1VetKills)
	{
		$DamageScale[iarmor, $PlasmaDamageType, %player] = 0.4;
	} else
	{
		$DamageScale[iarmor, $PlasmaDamageType, %player] = $DamageScale[iarmor, $PlasmaDamageType]; //0.6
	}	
}


$Veteran::MedicIncrease = 0.1;
$Veteran::MedicLegBoost = 4; // 3X the normal medic increase
$Veteran::MedicArmBoost = 3; // 3X the normal Medic increase

function MedicBolt::onAcquire(%this, %player, %target)
{

	%client = Player::getClient(%player);

	if (%target == %player &&  false) {// can't repair self anymore.
		%player.repairTarget = -1;
		$woundedWeaponArm[%client] = 0;
		$woundedLegs[%client] = 0;
		if(Player::getArmor(%player) == "marmor2" || Player::getArmor(%player) == "marmor3")
			Player::setArmor(%player,marmor);
	   	else if(Player::getArmor(%player) == "sarmor2" || Player::getArmor(%player) == "sarmor3")
			Player::setArmor(%player,sarmor);
		else if(Player::getArmor(%player) == "iarmor2" || Player::getArmor(%player) == "iarmor3")
			Player::setArmor(%player,iarmor);
		else if(Player::getArmor(%player) == "garmor2" || Player::getArmor(%player) == "garmor3")
			Player::setArmor(%player,garmor);
		else if(Player::getArmor(%player) == "carmor2" || Player::getArmor(%player) == "carmor3")
			Player::setArmor(%player,carmor);
		else if(Player::getArmor(%player) == "earmor2" || Player::getArmor(%player) == "earmor3")
			Player::setArmor(%player,earmor);
		else if(Player::getArmor(%player) == "larmor2" || Player::getArmor(%player) == "larmor3")
			Player::setArmor(%player,larmor);
		else if(Player::getArmor(%player) == "aarmor2" || Player::getArmor(%player) == "aarmor3")
			Player::setArmor(%player,aarmor);
		else if(Player::getArmor(%player) == "mfemale2" || Player::getArmor(%player) == "mfemale3")
			Player::setArmor(%player,mfemale);
		else if(Player::getArmor(%player) == "sfemale2" || Player::getArmor(%player) == "sfemale3")
			Player::setArmor(%player,sfemale);
		else if(Player::getArmor(%player) == "ifemale2" || Player::getArmor(%player) == "ifemale3")
			Player::setArmor(%player,ifemale);
		else if(Player::getArmor(%player) == "gfemale2" || Player::getArmor(%player) == "gfemale3")
			Player::setArmor(%player,gfemale);
		else if(Player::getArmor(%player) == "cfemale2" || Player::getArmor(%player) == "cfemale3")
			Player::setArmor(%player,cfemale);
		else if(Player::getArmor(%player) == "efemale2" || Player::getArmor(%player) == "efemale3")
			Player::setArmor(%player,efemale);
		else if(Player::getArmor(%player) == "lfemale2" || Player::getArmor(%player) == "lfemale3")
			Player::setArmor(%player,lfemale);
		else if(Player::getArmor(%player) == "afemale2" || Player::getArmor(%player) == "afemale3")
			Player::setArmor(%player,afemale);
		armorChange2(%player);
		$PlayerBleeding[Player::getClient(%player)] = 0;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			GameBase::setAutoRepairRate(%player.repairTarget, %player.repairRate);
			Client::sendMessage(%client, 0, "AutoHeal On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
		%player.repairTarget = %target;
		%player.repairRate   = 0.1;
		
		if (getObjectType(%player.repairTarget) == "Player" && %target != %player ) {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
			if($woundedWeaponArm[%rClient] != 0)
			{
				for(%x=0;%x<$Veteran::MedicArmBoost;%x++)
					Veteran::increaseMedicVet(%client,%rClient);
			}
			$woundedWeaponArm[%rclient] = 0;
			if($woundedLegs[%rClient] != 0)
			{
				for(%x=0;%x<$Veteran::MedicLegBoost;%x++)
					Veteran::increaseMedicVet(%client,%rClient);
			}
			$woundedLegs[%rclient] = 0;
			if(Player::getArmor(%rclient) == "marmor2" || Player::getArmor(%rclient) == "marmor3")
				Player::setArmor(%rclient,marmor);
		   	else if(Player::getArmor(%rclient) == "sarmor2" || Player::getArmor(%rclient) == "sarmor3")
				Player::setArmor(%rclient,sarmor);
			else if(Player::getArmor(%rclient) == "iarmor2" || Player::getArmor(%rclient) == "iarmor3")
				Player::setArmor(%rclient,iarmor);
			else if(Player::getArmor(%rclient) == "garmor2" || Player::getArmor(%rclient) == "garmor3")
				Player::setArmor(%rclient,garmor);
			else if(Player::getArmor(%rclient) == "carmor2" || Player::getArmor(%rclient) == "carmor3")
				Player::setArmor(%rclient,carmor);
			else if(Player::getArmor(%rclient) == "earmor2" || Player::getArmor(%rclient) == "earmor3")
				Player::setArmor(%rclient,earmor);
			else if(Player::getArmor(%rclient) == "larmor2" || Player::getArmor(%rclient) == "larmor3")
				Player::setArmor(%rclient,larmor);
			else if(Player::getArmor(%rclient) == "aarmor2" || Player::getArmor(%rclient) == "aarmor3")
				Player::setArmor(%rclient,aarmor);
			else if(Player::getArmor(%rclient) == "mfemale2" || Player::getArmor(%rclient) == "mfemale3")
				Player::setArmor(%rclient,mfemale);
			else if(Player::getArmor(%rclient) == "sfemale2" || Player::getArmor(%rclient) == "sfemale3")
				Player::setArmor(%rclient,sfemale);
			else if(Player::getArmor(%rclient) == "ifemale2" || Player::getArmor(%rclient) == "ifemale3")
				Player::setArmor(%rclient,ifemale);
			else if(Player::getArmor(%rclient) == "gfemale2" || Player::getArmor(%rclient) == "gfemale3")
				Player::setArmor(%rclient,gfemale);
			else if(Player::getArmor(%rclient) == "cfemale2" || Player::getArmor(%rclient) == "cfemale3")
				Player::setArmor(%rclient,cfemale);
			else if(Player::getArmor(%rclient) == "efemale2" || Player::getArmor(%rclient) == "efemale3")
				Player::setArmor(%rclient,efemale);
			else if(Player::getArmor(%rclient) == "lfemale2" || Player::getArmor(%rclient) == "lfemale3")
				Player::setArmor(%rclient,lfemale);
			else if(Player::getArmor(%rclient) == "afemale2" || Player::getArmor(%rclient) == "afemale3")
				Player::setArmor(%rclient,afemale);
			armorChange2(%rclient);
			$PlayerBleeding[Player::getClient(%rclient)] = 0;
			if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
				Client::sendMessage(%client,0,%name @ " is not wounded");
				Player::trigger(%player,$WeaponSlot,false);
				%player.repairTarget = -1;
				return;
			}
			Client::sendMessage(%rclient,0,"Being healed by " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Healing " @ %name);
			%player.repairRate = %player.repairRate*(Veteran::GetMedicVetLevel(%client)+1);
			%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);
			%client.mediccing = true;
			schedule("Veteran::CntIncreaseMedicVet("@%client@","@%rclient@");",0.5);
		} else {
			Client::sendMessage(%client,0,"You can't heal an inanimate object...");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
	}
}

function MedicBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoHeal Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Healing Complete");
			}
			else {
				Client::sendMessage(%client,0,"Healing Stopped");
			}
		}
		%client.mediccing = false;
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function Veteran::getMedicVetLevel(%client)
{

	if($Veteran::Kills[%Client,Medic] >= $Veteran::L3VetKills)
	{
		return 3;
	} else if($Veteran::Kills[%Client,Medic] >= $Veteran::L2VetKills)
	{
		return 2;
	} else if($Veteran::Kills[%Client,Medic] >= $Veteran::L1VetKills)
	{
		return 1;
	} else
	{
		return 0;
	}
}

function Veteran::MedicResurrection(%client,%player)
{
	if(%player && %player != -1 && %player != "")
	{
		AAI::AddToStats(%client, "revived");
		%pos = gamebase::Getposition(%player);
		%rot = gamebase::GetRotation(%player);
		%armor = %player.armor;
		%newBody = spawnPlayer(%armor, %Pos, %Rot);
		GiveLives(%client, 1);
		if(%newBody != -1)
		{
			GameBase::setTeam(%newBody, Client::getTeam(%client));
			Client::setOwnedObject(%client, %newBody);
		       	Client::setControlObject(%client, %newBody);
			%client.observerMode = "";
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) {
				%count = Player::getItemCount(%player,%i);
				if (%count) {
					%delta = Item::giveItem(%newBody,getItemData(%i),%count);
					if (%delta > 0) {
						Player::decItemCount(%player,%i,%delta);
					}
				}
			}
			deleteobject(%player);

			GameBase::setDamageLevel(%newBody,%armor.maxDamage - 0.01);
			Veteran::RestoreVet(%client);
		}
	}
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// The house functions...
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Veteran::ClearStatus(%player)
{

	$Veteran::Kills[%player,Knife] = 0;
	$Veteran::Kills[%player,Pistol] = 0;
	$Veteran::Kills[%player,M16] = 0;
	$Veteran::Kills[%player,SAW] = 0;
	$Veteran::Kills[%player,MP5] = 0;
	$Veteran::Kills[%player,PSG1] = 0;
	$Veteran::Kills[%player,Robar] = 0;
	$Veteran::Kills[%player,Shotgun] = 0;
	$Veteran::Kills[%player,Law] = 0;
	$Veteran::Kills[%player,Flamethrower] = 0;
	$Veteran::Kills[%player,Medic] = 0;
	Veteran::updateFlamethrower(client::Getcontrolobject(%player));
}

function Veteran::SaveVet(%player)
{
	$Veteran::Oldkills[%player,Knife] = $Veteran::Kills[%player,Knife];
	$Veteran::OldKills[%player,Pistol] = $Veteran::Kills[%player,Pistol];
	$Veteran::OldKills[%player,M16] = $Veteran::Kills[%player,M16];
	$Veteran::OldKills[%player,SAW] = $Veteran::Kills[%player,SAW];
	$Veteran::OldKills[%player,MP5] = $Veteran::Kills[%player,MP5];
	$Veteran::OldKills[%player,PSG1] = $Veteran::Kills[%player,PSG1];
	$Veteran::OldKills[%player,Robar] = $Veteran::Kills[%player,Robar];
	$Veteran::OldKills[%player,Shotgun] = $Veteran::Kills[%player,Shotgun];
	$Veteran::OldKills[%player,Law] = $Veteran::Kills[%player,Law];
	$Veteran::OldKills[%player,Flamethrower] = $Veteran::Kills[%player,Flamethrower];
	$Veteran::OldKills[%player,Medic] = $Veteran::Kills[%player,Medic];
}

function Veteran::RestoreVet(%player)
{
	$Veteran::Kills[%player,Knife] = $Veteran::OldKills[%player,Knife];
	$Veteran::Kills[%player,Pistol] = $Veteran::OldKills[%player,Pistol];
	$Veteran::Kills[%player,M16] = $Veteran::OldKills[%player,M16];
	$Veteran::Kills[%player,SAW] = $Veteran::OldKills[%player,SAW];
	$Veteran::Kills[%player,MP5] = $Veteran::OldKills[%player,MP5];
	$Veteran::Kills[%player,PSG1] = $Veteran::OldKills[%player,PSG1];
	$Veteran::Kills[%player,Robar] = $Veteran::OldKills[%player,Robar];
	$Veteran::Kills[%player,Shotgun] = $Veteran::OldKills[%player,Shotgun];
	$Veteran::Kills[%player,Law] = $Veteran::OldKills[%player,Law];
	$Veteran::Kills[%player,Flamethrower] = $Veteran::OldKills[%player,Flamethrower];
	$Veteran::Kills[%player,Medic] = $Veteran::OldKills[%player,Medic];
}

function Veteran::IncreaseKills(%killerId,%playerId,%damagetype)
{
	%player = %killerId;
	Veteran::SaveVet(%playerId);
	Veteran::ClearStatus(%playerId);
	%playerId.LastDamagedBy = 0;
	if(GameBase::getTeam(%killerId) == GameBase::getTeam(%playerId))
		return;

	echo("Damage: "@%damagetype);
	if(%damageType == $StabDamageType)
	{
		$Veteran::Kills[%killerId,Knife]++;
		if($Veteran::Kills[%player,Knife] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the Combat Knife.",5);
		} else if($Veteran::Kills[%player,Knife] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the Combat Knife.",5);
		} else if($Veteran::Kills[%player,Knife] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the Combat Knife.",5);
		}	
	} else if(%damageType == $PistolDamageType)
	{
		$Veteran::Kills[%killerId,Pistol]++;
		if($Veteran::Kills[%player,Pistol] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the M9 Beretta.",5);
		} else if($Veteran::Kills[%player,Pistol] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the M9 Beretta.",5);
		} else if($Veteran::Kills[%player,Pistol] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the M9 Beretta.",5);
		}	
	} else if(%damageType == $SAWDamageType)
	{
		$Veteran::Kills[%killerId,SAW]++;
		if($Veteran::Kills[%player,SAW] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the M249 SAW.",5);
		} else if($Veteran::Kills[%player,SAW] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the M249 SAW.",5);
		} else if($Veteran::Kills[%player,SAW] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the M249 SAW.",5);
		}	
	} else if(%damageType == $M16DamageType)
	{

		$Veteran::Kills[%killerId,M16]++;
		if($Veteran::Kills[%player,M16] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the M16 Rifle.",5);
		} else if($Veteran::Kills[%player,M16] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the M16 Rifle.",5);
		} else if($Veteran::Kills[%player,M16] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the M16 Rifle.",5);
		}	
	} else if(%damageType == $MP5DamageType)
	{
		$Veteran::Kills[%killerId,MP5]++;
		if($Veteran::Kills[%player,MP5] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the Silenced MP5.",5);
		} else if($Veteran::Kills[%player,MP5] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the Silenced MP5.",5);
		} else if($Veteran::Kills[%player,MP5] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the Silenced MP5.",5);
		}	
	} else if(%damageType == $RobarDamageType)
	{
		$Veteran::Kills[%killerId,Robar]++;
		if($Veteran::Kills[%player,Robar] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the M40A1 Sniper Rifle.",5);
		} else if($Veteran::Kills[%player,Robar] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the M40A1 Sniper Rifle.",5);
		} else if($Veteran::Kills[%player,Robar] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the M40A1 Sniper Rifle.",5);
		}	
	} else if(%damageType == $PSG1DamageType)
	{
		$Veteran::Kills[%killerId,PSG1]++;
		if($Veteran::Kills[%player,PSG1] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the PSG-1 Sniper Rifle.",5);
		} else if($Veteran::Kills[%player,PSG1] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the PSG-1 Sniper Rifle.",5);
		} else if($Veteran::Kills[%player,PSG1] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the PSG-1 Sniper Rifle.",5);
		}	
	} else if(%damageType == $ShotGunDamageType)
	{
		$Veteran::Kills[%killerId,ShotGun]++;
		if($Veteran::Kills[%player,ShotGun] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the SPAS-12 Auto Shotgun.",5);
		} else if($Veteran::Kills[%player,ShotGun] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the SPAS-12 Auto Shotgun.",5);
		} else if($Veteran::Kills[%player,ShotGun] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the SPAS-12 Auto Shotgun.",5);
		}	
	} else if(%damageType == $LawDamageType)
	{
		$Veteran::Kills[%killerId,Law]++;
		if($Veteran::Kills[%player,LAW] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the LAW.",5);
		} else if($Veteran::Kills[%player,LAW] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the LAW.",5);
		} else if($Veteran::Kills[%player,LAW] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the LAW.",5);
		}	
	} else if(%damageType == $FlameThrowerDamageType)
	{
		$Veteran::Kills[%killerId,FlameThrower]++;
		Veteran::updateFlamethrower(Client::Getcontrolobject(%killerId));
		if($Veteran::Kills[%player,FlameThrower] == $Veteran::L3VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 3 with the FlameThrower.",5);
		} else if($Veteran::Kills[%player,FlameThrower] == $Veteran::L2VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 2 with the FlameThrower.",5);
		} else if($Veteran::Kills[%player,FlameThrower] == $Veteran::L1VetKills)
		{
			Bottomprint(%killerId,"<jc>You have reached veteran level 1 with the FlameThrower.",5);
		}	
	}
}

function Veteran::increaseMedicVet(%healerId,%playerId)
{
	if(GameBase::getTeam(%healerId) != GameBase::getTeam(%playerId))
		return;

	
	%ldbt = %playerId.LastTeam;
	if(%ldbt == "" || %ldbt == gamebase::Getteam(%playerId))
	{
		return;
	}
	%cur = $Veteran::Kills[%healerId,Medic];
	$Veteran::Kills[%healerId,Medic] = %cur+ $Veteran::MedicIncrease;
		%cur = floor(%cur*10);
		if(%cur == $Veteran::L3VetKills*10)
		{
			Bottomprint(%healerId,"<jc>You have reached veteran level 3 as a Medic.",5);
		} else if(%cur == $Veteran::L2VetKills*10)
		{
			Bottomprint(%healerId,"<jc>You have reached veteran level 2 as a Medic.",5);
		} else if(%cur == $Veteran::L1VetKills*10)
		{
			Bottomprint(%healerId,"<jc>You have reached veteran level 1 as a Medic.",5);
		}	
		
}

function Veteran::cntIncreaseMedicVet(%healerId,%playeriD)
{
	if(%healerId.mediccing == true)
	{
		AAI::AddToStats(%healerId, "medic");
		if(gamebase::getteam(%healerId) != gamebase::getteam(%playerId))
			AAI::AddToStats(%healerId, "enemymedic");
		Veteran::increaseMedicVet(%healerId,%PlayerId);
		schedule("Veteran::CntIncreaseMedicVet("@%healerId@","@%playerId@");",0.5);
	}
}
function Veteran::getRealDamageType(%type)
{
	if(%type == $SAWDamageType || %type == $M16DamageType || %type == $PistolDamageType || %type == $MP5DamageType || %type == $ShotGunDamageType)
	{
		return $BulletDamageType;
	}

	if(%type == $RobarDamageType || %type == $PSG1DamageType)
	{
		return $LaserDamageType;
	}
	
	if(%type == $FlameThrowerDamageType)
	{
		return $PlasmaDamageType;
	}

	if(%type == $LawDamageType)
	{
		return $MissileDamageType;
	}

	return %type;	
}

function veteran::getTransform(%player)
{
	if(GameBase::getLOSInfo(%player,10000) && !Player::isDead(%player))
	{
		%rot = GameBase::getRotation(%player);
		%targetPos = $los::position;
		%trans = GameBase::getMuzzleTransform(%player);
		%vec0 = getWord(%trans,0);
		%vec1 = getWord(%trans,1);
		%vec2 = getWord(%trans,2);
		%vec3 = getWord(%trans,6);
		%vec4 = getWord(%trans,7);
		%vec5 = getWord(%trans,8);
		%vec6 = getWord(%trans,9);
		%vec7 = getWord(%trans,10);
		%vec8 = getWord(%trans,11);
		%vecX = getWord(%trans,3)@" "@getWord(%trans,4)@" "@getWord(%trans,5);
		%rot1 = %vec0@" "@%vec1@" "@%vec2;
		%rot2 = %vec3@" "@%vec4@" "@%vec5;
		%pos1 = %vec6@" "@%vec7@" "@%vec8;
		%rot0 = Vector::getRotAim(%Pos1,%targetPos);
		%speed = 1;
		%vec = Vector::getFromRot(%rot0,%speed);
		if(%targetPos)
			%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vec@" "@%rot0@" "@%pos1;
	
	} else
		%trans = GameBase::getMuzzleTransform(%player);
	return %trans;
}

function Vector::getRotAim(%pos1,%pos2,%neg)
{
	%vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
	if(%neg)
		%vec = Vector::normalize(Vector::sub(%pos1,%pos2));
	%rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
	return %rot;
}

