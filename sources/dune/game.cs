exec("comchat.cs");
$SensorNetworkEnabled = true;

$GuiModePlay = 1;
$GuiModeCommand = 2;
$GuiModeVictory = 3;
$GuiModeInventory = 4;
$GuiModeObjectives = 5;
$GuiModeLobby = 6;
$Console::LogMode = 2;

//  Global Variables

$LasHitGraceTime = 1;
$GholaOwnedMax = 3;
$CorpseRot = false;
$MaxCorpses = 10;
//---------------------------------------------------------------------------------
// Disable/enable globalchat.
//---------------------------------------------------------------------------------
$NoTalk = false;
$NoLoudTalk = true; // No use of sounds on global
$NoRepeat = true; // No use of repeat on global

//---------------------------------------------------------------------------------
// Should we nuke through the prefab shapes? Turn to false for missions that are D&D
//---------------------------------------------------------------------------------
$NukeThroughPrefabs = true;

//---------------------------------------------------------------------------------
// Shell stuff: what we want outputted. Most are set to true at first.
//---------------------------------------------------------------------------------
$STEAMTALK = true;
$STALK = true;
$SKILL = true;
$SSPAWN = true;
$STKILL = true;
$STHROW = false;
$SDEPLOY = false;
function SAllOff()
{
	$STEAMTALK = false;
	$STALK = false;
	$SKILL = false;
	$SSPAWN = false;
	$STKILL = false;
	$STHROW = false;
	$SDEPLOY = false;
}

function SAllOn()
{
	$STEAMTALK = true;
	$STALK = true;
	$SKILL = true;
	$SSPAWN = true;
	$STKILL = true;
	$STHROW = true;
	$SDEPLOY = true;
}

function SDefault()
{
	$STEAMTALK = true;
	$STALK = true;
	$SKILL = true;
	$SSPAWN = true;
	$STKILL = true;
	$STHROW = false;
	$SDEPLOY = false;
}




//---------------------------------------------------------------------------------
//    Fuel pack constants
//---------------------------------------------------------------------------------

$FuelPackBlowMethod = 1;
$FuelPackBlowRadius = 1.5;
$FuelPackBlowHeight = 3.0;

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "90000";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 90000;

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. 
//---------------------------------------------------------------------------------
$flagToStandTime = 600;	  

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
//Amount of Energy remote stations start out with
//---------------------------------------------------------------------------------
$RemoteAmmoEnergy = 2500; 
$RemoteInvEnergy = 3000;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//---------------------------------------------------------------------------------
// REMOTE TURRET
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 2;     //Number of remote turrets allowed in the area
$TurretBoxMaxLength = 50;    //Define Max Length of the area
$TurretBoxMaxWidth =  50;    //Define Max Width of the area
$TurretBoxMaxHeight = 25;    //Define Max Height of the area

$TurretBoxMinLength = 10;	  //Define Min Length from another turret
$TurretBoxMinWidth =  10;	  //Define Min Width from another turret
$TurretBoxMinHeight = 10;    //Define Min Height from another turret

//---------------------------------------------------------------------------------
//	Object Types	
//---------------------------------------------------------------------------------
$SimTerrainObjectType    = 1 << 1;
$SimInteriorObjectType   = 1 << 2;
$SimPlayerObjectType     = 1 << 7;

$GroupTriggerObjectType     = 1 << 4;

$MineObjectType		    = 1 << 26;	
$MoveableObjectType	    = 1 << 22;
$VehicleObjectType	 	 = 1 << 29;  
$StaticObjectType			 = 1 << 23;	   
$ItemObjectType			 = 1 << 21;	  

// 0,1 = ***nothing***
// 2,3 = simterrain
// 4,5 = interiorshape (prefab)
// 6,7 = simterrain + interiorshape
// 8,9 = ***nothing***
// 10,11 = simterrain
// 12,13 = interiorshape
// 14,15 = simterrain + interiorshape
// 16,17 = grouptrigger
// 18,19 = simterrain + grouptrigger
// 20,21 = grouptrigger + interiorshape
// 22,23 = simterrain + grouptrigger + interiorshape
// 24,25 = grouptrigger
// 26,27 = simterrain + grouptrigger
// 28,29 = grouptrigger + interiorshape
// 30,31 = simterrain + grouptrigger + interiorshape
// 32,33 = ***nothing***
// 34,35 = simterrain
// 36,37 = interiorshape
// 38,39 = simterrain + interiorshape
// 40,41 = ***nothing***
// 42,43 = simterrain
// 44,45 = interiorshape
// 46,47 = simterrain + interiorshape
// 48,49 = grouptrigger
// 50,51 = simterrain + grouptrigger
// 52,53 = grouptrigger + interiorshape
// 54,55 = simterrain + grouptrigger + interiorshape
// 56,57 = grouptrigger
// 58,59 = simterrain + grouptrigger
// 60,61 = grouptrigger + interiorshape
// 62,63 = simterrain + grouptrigger + interiorshape
// 64,65 = simterrain + interiorshape
// 66,67 = simterrain + interiorshape
//
// 1 << 1 = simterrain			********
// 1 << 2 = interiorshape		********
// 1 << 3 = ***nothing***
// 1 << 4 = grouptrigger		********
// 1 << 5 = ***nothing***
// 1 << 6 = simterrain + interiorshape
// 1 << 7 = player			********
// 1 << 8 = ***nothing***
// 1 << 9 = ***nothing***
// 1 << 10 = ***nothing***
// 1 << 11 = ***nothing***
// 1 << 12 = ***nothing***
// 1 << 13 = ***nothing***
// 1 << 14 = ***nothing***
// 1 << 15 = ***nothing***
// 1 << 16 = ***nothing***
// 1 << 17 = ***nothing***
// 1 << 18 = ***nothing***
// 1 << 19 = ***nothing***
// 1 << 20 = ***nothing***
// 1 << 21 = ItemType			********
// 1 << 22 = MoveableType		********
// 1 << 23 = StaticShape		********
// 1 << 24 = ***nothing***
// 1 << 25 = ***nothing***
// 1 << 26 = MineType			********
// 1 << 27 = ***nothing***
// 1 << 28 = GroupTrigger
// 1 << 29 = VehicleType		********
// 1 << 30 = ***nothing***
// ?
// 1 << 100 = GroupTrigger
//
// 2 << 1 = InteriorShape
// 2 << 2 = ***nothing***
// 2 << 3 = GroupTriggers

//---------------------------------------------------------------------------------
// CHEATS
//---------------------------------------------------------------------------------
$ServerCheats = 0;
$TestCheats = 0;

//---------------------------------------------------------------------------------
//Respawn automatically after X sec's -  If 0..no respawn
//---------------------------------------------------------------------------------
$AutoRespawn = 0;

//---------------------------------------------------------------------------------
// Player death messages - %1 = killer's name, %2 = victim's name
//       %3 = killer's gender pronoun (his/her), %4 = victim's gender pronoun
//---------------------------------------------------------------------------------
$deathMsg[$LandingDamageType, 0]      = "%2 falls to %3 death.";
$deathMsg[$LandingDamageType, 1]      = "%2 forgot to tie %3 bungie cord.";
$deathMsg[$LandingDamageType, 2]      = "%2 bites the dust in a forceful manner.";
$deathMsg[$LandingDamageType, 3]      = "%2 fall down go boom.";
$deathMsg[$ImpactDamageType, 0]      = "%1 makes quite an impact on %2.";
$deathMsg[$ImpactDamageType, 1]      = "%2 becomes the victim of a fly-by from %1.";
$deathMsg[$ImpactDamageType, 2]      = "%2 leaves a nasty dent in %1's fender.";
$deathMsg[$ImpactDamageType, 3]      = "%1 says, 'Hey %2, you scratched my paint job!'";
$deathMsg[$BulletDamageType, 0]      = "%1 ventilates %2 with %3 chaingun.";
$deathMsg[$BulletDamageType, 1]      = "%1 gives %2 an overdose of lead.";
$deathMsg[$BulletDamageType, 2]      = "%1 fills %2 full of holes.";
$deathMsg[$BulletDamageType, 3]      = "%1 guns down %2.";
$deathMsg[$LargeBulletDamageType, 0]      = "%1 chews up %2 with %3 machinegun.";
$deathMsg[$LargeBulletDamageType, 1]      = "%1 tears %2 apart with %3 machinegun.";
$deathMsg[$LargeBulletDamageType, 2]      = "%1 saws %2 in half with a hail of bullets.";
$deathMsg[$LargeBulletDamageType, 3]      = "%1 vulcanizes %2.";
$deathMsg[$EnergyDamageType, 0]      = "%2 dies of turret trauma.";
$deathMsg[$EnergyDamageType, 1]      = "%2 is chewed to pieces by a turret.";
$deathMsg[$EnergyDamageType, 2]      = "%2 walks into a stream of turret fire.";
$deathMsg[$EnergyDamageType, 3]      = "%2 ends up on the wrong side of a turret.";
$deathMsg[$PlasmaDamageType, 0]      = "%2 feels the warm glow of %1's plasma.";
$deathMsg[$PlasmaDamageType, 1]      = "%1 gives %2 a white-hot plasma injection.";
$deathMsg[$PlasmaDamageType, 2]      = "%1 asks %2, 'Got plasma?'";
$deathMsg[$PlasmaDamageType, 3]      = "%1 gives %2 a plasma transfusion.";
$deathMsg[$ExplosionDamageType, 0]   = "%2 found %1's package.";
$deathMsg[$ExplosionDamageType, 1]   = "%1 sends an overnight delivery to %2.";
$deathMsg[$ExplosionDamageType, 2]   = "%1's explosion took %2 by surprise.";
$deathMsg[$ExplosionDamageType, 3]   = "%2 was standing too close to %1's detonator.";
$deathMsg[$ShrapnelDamageType, 0]    = "%1 blows %2 up real good.";
$deathMsg[$ShrapnelDamageType, 1]    = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$ShrapnelDamageType, 2]    = "%1 gives %2 a fatal concussion.";
$deathMsg[$ShrapnelDamageType, 3]    = "%2 never saw it coming from %1.";
//Old laser
//$deathMsg[$LaserDamageType, 0]       = "%1 adds %2 to %3 list of sniper victims.";
//$deathMsg[$LaserDamageType, 1]       = "%1 fells %2 with a sniper shot.";
//$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's laser rifle.";
//$deathMsg[$LaserDamageType, 3]       = "%2 stayed in %1's crosshairs for too long.";
//New laser
$deathMsg[$LaserDamageType, 0]       = "%1 blows %2 head off.";
$deathMsg[$LaserDamageType, 1]       = "%1 picks off %2 with %3 Sniper Rifle.";
$deathMsg[$LaserDamageType, 2]       = "%2 becomes a victim of %1's Sniper Rifle.";
$deathMsg[$LaserDamageType, 3]       = "%2 is felled by %1 Sniper Rifle.";
$deathMsg[$CutterayDamageType, 0]       = "%1 sliced through %2's armor with %3 Cutteray.";
$deathMsg[$CutterayDamageType, 1]       = "%2 found out that %1's Cutteray was more than a tool.";
$deathMsg[$CutterayDamageType, 2]       = "%2 realized that %1's Cutteray could cut more than rock.";
$deathMsg[$CutterayDamageType, 3]       = "%1 and %3 Cutteray assisted %2 in kissing %4 ass good-bye.";
$deathMsg[$SmallLasDamageType, 0]       = "%1 fries %2 with %3 Small Lasgun.";
$deathMsg[$SmallLasDamageType, 1]       = "%1 cuts down %2 with %3 Small Lasgun.";
$deathMsg[$SmallLasDamageType, 2]       = "%2 becomes a victim of %1's Small Lasgun.";
$deathMsg[$SmallLasDamageType, 3]       = "%2 was cut in half by %1's Small Lasgun.";
$deathMsg[$RifleLasDamageType, 0]       = "%1 fries %2 with %3 Rifle Lasgun.";
$deathMsg[$RifleLasDamageType, 1]       = "%1 cuts down %2 with %3 Rifle Lasgun.";
$deathMsg[$RifleLasDamageType, 2]       = "%2 becomes a victim of %1's Rifle Lasgun.";
$deathMsg[$RifleLasDamageType, 3]       = "%2 was cut in half by %1's Rifle Lasgun.";
$deathMsg[$HeavyLasDamageType, 0]       = "%1 fries %2 with %3 Heavy Lasgun.";
$deathMsg[$HeavyLasDamageType, 1]       = "%1 cuts down %2 with %3 Heavy Lasgun.";
$deathMsg[$HeavyLasDamageType, 2]       = "%2 becomes a victim of %1's Heavy Lasgun.";
$deathMsg[$HeavyLasDamageType, 3]       = "%2 was cut in half by %1's Heavy Lasgun.";
//Old
$deathMsg[$MortarDamageType, 0]      = "%1 mortars %2 into oblivion.";
$deathMsg[$MortarDamageType, 1]      = "%2 didn't see that last mortar from %1.";
$deathMsg[$MortarDamageType, 2]      = "%1 inflicts a mortal mortar wound on %2.";
$deathMsg[$MortarDamageType, 3]      = "%1's mortar takes out %2.";
$deathMsg[$BlasterDamageType, 0]     = "%2 gets a blast out of %1.";
$deathMsg[$BlasterDamageType, 1]     = "%2 succumbs to %1's rain of blaster fire.";
$deathMsg[$BlasterDamageType, 2]     = "%1's puny blaster shows %2 a new world of pain.";
$deathMsg[$BlasterDamageType, 3]     = "%2 meets %1's master blaster.";
$deathMsg[$ElectricityDamageType, 0] = "%2 gets zapped.";
$deathMsg[$ElectricityDamageType, 1] = "%2 was electrocuted.";
$deathMsg[$ElectricityDamageType, 2] = "%2 gets a real shock.";
$deathMsg[$ElectricityDamageType, 3] = "%2 is fried.";
$deathMsg[$CrushDamageType, 0]		 = "%2 didn't stay away from the moving parts.";
$deathMsg[$CrushDamageType, 1]		 = "%2 is crushed.";
$deathMsg[$CrushDamageType, 2]		 = "%2 gets smushed flat.";
$deathMsg[$CrushDamageType, 3]		 = "%2 gets caught in the machinery.";
$deathMsg[$DebrisDamageType, 0]		 = "%2 is a victim among the wreckage.";
$deathMsg[$DebrisDamageType, 1]		 = "%2 is killed by debris.";
$deathMsg[$DebrisDamageType, 2]		 = "%2 becomes a victim of collateral damage.";
$deathMsg[$DebrisDamageType, 3]		 = "%2 got too close to the exploding stuff.";
$deathMsg[$MissileDamageType, 0]	    = "%2 takes a missile up the keister.";
$deathMsg[$MissileDamageType, 1]	    = "%2 gets shot down.";
$deathMsg[$MissileDamageType, 2]	    = "%2 gets real friendly with a rocket.";
$deathMsg[$MissileDamageType, 3]	    = "%2 feels the burn from a warhead.";
$deathMsg[$MineDamageType, 0]	       = "%1 blows %2 up real good.";
$deathMsg[$MineDamageType, 1]	       = "%2 gets a taste of %1's explosive temper.";
$deathMsg[$MineDamageType, 2]	       = "%1 gives %2 a fatal concussion.";
$deathMsg[$MineDamageType, 3]	       = "%2 never saw it coming from %1.";
//New
$deathMsg[$StabDamageType, 0]		= "%2 lost the melee to %1.";
$deathMsg[$StabDamageType, 1]		= "%2 was run through by %1.";
$deathMsg[$StabDamageType, 2]		= "%1 cut %2 apart.";
$deathMsg[$StabDamageType, 3]		= "%1 turned %2 into a pincusion.";
$deathMsg[$PoisonDamageType, 0]		= "%1 killed %2 with a drug overdose.";
$deathMsg[$PoisonDamageType, 1]		= "%1's poison was too much for %2.";
$deathMsg[$PoisonDamageType, 2]		= "%2 thought %1's dart wasn't poisoned... How silly.";
$deathMsg[$PoisonDamageType, 3]		= "%2's nervious system breaks down as %1 looks on in glee.";
$deathMsg[$ThrownWeaponDamageType, 0]	= "%2 catches %1's thrown blade in the throat.";
$deathMsg[$ThrownWeaponDamageType, 1]	= "%1 nails %2 with a thrown blade.";
$deathMsg[$ThrownWeaponDamageType, 2]	= "%2 caught %1's thrown blade before %3 shield went up.";
$deathMsg[$ThrownWeaponDamageType, 3]	= "%1 kills %2 with a thrown blade.";
$deathMsg[$ThrownPoisonWeaponDamageType, 0]		= "%2 catches %1's thrown blade in the throat.";
$deathMsg[$ThrownPoisonWeaponDamageType, 1]		= "%1 nails %2 with a thrown blade.";
$deathMsg[$ThrownPoisonWeaponDamageType, 2]		= "%2 caught %1's thrown blade before %4 shield went up.";
$deathMsg[$ThrownPoisonWeaponDamageType, 3]		= "%1 kills %2 with a thrown blade.";
$deathMsg[$StunnerDamageType, 0]	= "%1 guns down %2";
$deathMsg[$StunnerDamageType, 1]	= "%1 plugs %2 in the head.";
$deathMsg[$StunnerDamageType, 2]	= "%2 wasn't able move out of the way of %1's stunner.";
$deathMsg[$StunnerDamageType, 3]	= "%2 became to mesmerized by the slow advance of %1's stunner slug.";
$deathMsg[$NukeDamageType, 0]		= "%1 shows off %3 family's impressive collection of Atomics to %2";
$deathMsg[$NukeDamageType, 1]		= "%2 decides to tell the Lansarad about %1's use of Atomics.";
$deathMsg[$NukeDamageType, 2]		= "%1 shows off %3 atomic abilities to %2.";
$deathMsg[$NukeDamageType, 3]		= "%2 didn't even have a chance to escape %1's atomic strike.";
$deathMsg[$Poison2DamageType, 0]	= "%1 killed %2 with a drug overdose.";
$deathMsg[$Poison2DamageType, 1]	= "%1's poison was too much for %2.";
$deathMsg[$Poison2DamageType, 2]	= "%2 was poisoned by %1.";
$deathMsg[$Poison2DamageType, 3]	= "%2 forgot to use a snooper on %1's gift.";
$deathMsg[$WormDamageType, 0]		= "%2 is eaten alive by a worm.";
$deathMsg[$WormDamageType, 1]		= "%2 goes to join Shaitan... REAL personal like.";
$deathMsg[$WormDamageType, 2]		= "%2 couldn't out run the worm.";
$deathMsg[$WormDamageType, 3]		= "%2 becomes a tasty snack for a worm.";
$deathMsg[$TackleDamageType, 0]		= "%1 gives %2 a deadly check.";
$deathMsg[$TackleDamageType, 1]		= "%1 gives %2 a fatal concussion.";
$deathMsg[$TackleDamageType, 2]		= "%2 gets %4 head knocked off by %1.";
$deathMsg[$TackleDamageType, 3]		= "%1 beats the hell out of %2.";


// "you just killed yourself" messages
//   %1 = player name,  %2 = player gender pronoun

$deathMsg[-2,0]						 = "%1 goes to join Shaitan.";
$deathMsg[-2,1]						 = "%1 takes fanaticism a little too far.";
$deathMsg[-2,2]						 = "%1 kills %2 own dumb self.";
$deathMsg[-2,3]						 = "%1 won't be joining us on the Jihad.";

$numDeathMsgs = 4;
//---------------------------------------------------------------------------------

//-Weapons:
$WeapMountMSG[Knife] = 				"The Knife is the most widly standard issue weapon in the universe. With the advent of personal shields, it is also one of the most deadly. The main weapon of most soldiers, it causes good damage, and can be used very fast in experianced hands.";
$WeapMountMSG[Knife2] = 			"The Knife is the most widly standard issue weapon in the universe. With the advent of personal shields, it is also one of the most deadly. The main weapon of most soldiers, it causes good damage, and can be used very fast in experianced hands.";
$WeapMountMSG[SlipTip] = 			"The Slip-Tip is a weapon a size smaller then the knife, but coated with a deadly poison. One good stab from this weapon will send most to their graves in a matter of seconds.";
$WeapMountMSG[Crysknife] = 			"The Crysknife is an extreamly deadly weapon that can be used only by the Fremen, and those that they would honor. The blade itself is a razar sharp tooth taken from the maw of a Little Maker. Its quick action and deadly damage in the hands";
$WeapMountMSG2[Crysknife] = 			"of an experianced Fremen make it one of the most deadly hand to hand weapons obtainable.";
$WeapMountMSG[Kindjal] = 			"The Kindjal is a double-bladed short sword, or long knife, with about 20 centimeter long, slightly curved blade. It boasts high damage, but is much slower then the smaller knives. ";
$WeapMountMSG[Saber] = 				"The Saber is weapon mastered by few. In particular those of a royal guard. It is not particularly quick, even in skilled hands, but deals out large amounts of damage with each hit.";
$WeapMountMSG[Pistol] = 			"The Pistol is a standard short nozeled projectile weapon. It has a semi-high rate of fire, and can do good damange to anyone unfortunate enough not to be shielded. However, the high velocity of the bullets prevent them from penetrating";
$WeapMountMSG2[Pistol] = 			"any shield, rendering the pistol useless in most cases.";
$WeapMountMSG[Maula] = 				"The Maula Pistol is a small projectile weapon that fires a dart filled with poison. It has a slow rate of fire, and cannot penetrate shields, but the poison recieved by anyone not wearing one and hit, can kill them in mere seconds.";
$WeapMountMSG[Stunner] = 			"The Stunner is a slow-pellet projectile weapon throwing a poison-tipped dart. It can penetrate shields with ease, but are difficult to use against moving targets. However, if successful, the poison is usualy enough to kill in mere seconds.";
$WeapMountMSG[Rifle] = 				"The Rifle is a standard issue semi-automatic projectile weapon. It has a high rate of fire, and can do sickining damage to anyone unfortunate enough not to be shielded. However, the high velocity of the bullets prevent them from penetrating";
$WeapMountMSG2[Rifle] = 			"any shield, rendering the rifle useless in most cases.";
$WeapMountMSG[MGun] = 				"The Heavy Machine Gun is a fully automatic vulcan projectile weapon, and is the choice projectile weapon of the Sardaukar. Its large bullets and a RoF twice that of the Rifle makes it one of the deadlies Projectiles around. However, the high";
$WeapMountMSG2[MGun] = 				"velocity of the bullets prevent them from penetrating any shield, rendering the Machine Gun useless in most cases.";
$WeapMountMSG[SniperRifle] = 			"The Sniper Rifle is an archaic projectile weapon. It has a slow rate of fire, but is extreamly accurate. As the high velocity of the bullets prevent them from penetrating any shield, it was phased out, unlike rifles which still were usefull";
$WeapMountMSG2[SniperRifle] = 			"against large collections of unshielded troops. The fremen found that on an unshield world, sniper rifles work well.";
$WeapMountMSG[RLauncher] = 			"The Rocket Launcher is a shoulder mounted rocket launcher. It fires a missile capable of being utilized as a Surface-To-Surface missile, or Surface-To-Air missile. It is best when used against ground cars, or unshielded Ornithopters. If fired";
$WeapMountMSG2[RLauncher] = 			"at a flying object, it has the capability of locking on. As with most projectiles the missile, and the subsequent blast, cannot penetrate shields.";
$WeapMountMSG[Flamethrower] =	 		"The flamethrower is an extreamly inhumane weapon. Used mostly for clearing out sections of infantry, It is most effective when employed against those without shields. But if used against a shielded unit, it's high temperatures are more then";
$WeapMountMSG2[Flamethrower] =	 		"enough to damage said unit, but only at a fraction of what it could do against an unshielded soldier.";
$WeapMountMSG[Piller] = 			"The Piller-of-Fire is an intense plasma weapon. It works in the same manor as a flamethrower, only at a higher temperature which renders it more dangerous, and lighter then its counterpart. Its primariy use is against shielded Ornithopters,";
$WeapMountMSG2[Piller] = 			"which have no defense against them but their agility, the shield being able to stop only a small fraction of the heat.";
$WeapMountMSG[Cutteray] =	 		"The Cutteray is a small hand held Lasgun. It is one of the smallest of the species, and has a short range of effect. Its primariy function is ment to dispose of building material, or clear out rocks ect.";
$WeapMountMSG2[Cutteray] =	 		"***WARNING If a Lasgun is used against a shield of any kind, the resulting fusion contact can cause an atomic reaction at the point of contact, and at the point of origin. USE SPARINGLY AND WITH CAUTION.";
$WeapMountMSG[SmallLas] = 			"The Small Lasgun is a hand held pistol form of a Lasgun. It deals more damage then the cutteray, and has a better range.***WARNING If a Lasgun is used against a shield of any kind, the resulting fusion contact can cause an atomic reaction";
$WeapMountMSG2[SmallLas] = 			"at the point of contact, and at the point of origin. USE SPARINGLY AND WITH CAUTION.";
$WeapMountMSG[RifleLas] = 			"The Rifle Lasgun is a medium power Lasgun. It deals a large amount of damage at a long range and can be very deadly if used with experience.***WARNING If a Lasgun is used against a shield of any kind, the resulting fusion contact can cause";
$WeapMountMSG2[RifleLas] = 			"an atmoic reaction at the point of contact, and at the point of origin. USE SPARINGLY AND WITH CAUTION.";
$WeapMountMSG[HeavyLas] = 			"The Heavy Lasgun is a large power Lasgun. It is capable of clearing whole platoons of soldiers and destorying large sections of bases. It deals an extream amount of damage, and has a good range.***WARNING If a Lasgun is used against a shield";
$WeapMountMSG2[HeavyLas] = 			"of any kind, the resulting fusion contact can cause an atomic reaction at the point of contact, and at the point of origin. USE SPARINGLY AND WITH CAUTION.";

//-Packs:
$WeapMountMSG[RepairPack] = 			"The Repair Toolkit is an all-purpose device that can repair damage to items such as stations, vehicles, bodysuits, and turrets.";
$WeapMountMSG[ShieldPack] = 			"This pack contains a portable Holtzman Generator that molds a protective field around its wearer. This field derives from Phase One of the suspensor-nullification effect and will permit entry only to objects moving at slow speeds. Although it";
$WeapMountMSG2[ShieldPack] = 			"cannot stop it, it will also reduce the effects of any sudden changes in heat. Because of the slow diffusion rate of the shield, the wearer can only have it activated for a certain amount of time before they begin to sufficate.**Warning** Do";
$WeapMountMSG3[ShieldPack] = 			"not fire any projectile weapons while inside a shield. Such actions will result in a sudden spike in heat energy inside the shield, and kill the user.";
$WeapMountMSG[SensorJammerPack] = 		"The pack contains a minature portable radar jammer that creates large amounts of radar noise, effectivly hidding its wearer and those surounding from radar detection."; 
$WeapMountMSG[AmmoPack] = 			"The ammo pack is a canvas and plasteel pack containing a wide asortment of ammo for distrbution to troops in the field.";
$WeapMountMSG[ExplosivePack] = 			"This pack contains a timed charge that once placed and set, will detonate in 15 seconds.";
$WeapMountMSG[SuicidePack] = 			"The suicide pack is a weapon of last resorts. Worn only by loyal fanatics of certain Houses, when triggered, it creates an explosion capable of doing much damage, including overburdening smaller shields like those worn by individual soldiers.";
$WeapMountMSG[FuelPack] = 			"The fuel pack is a plasteel tank containing presurized plasma that ignites on contact with oxygen. It is required for use of the flamethrower as well as the piller-of-fire";
$WeapMountMSG[SuspensorPack] = 			"The suspensor pack when activated allows the wearer to rise into the air, or decend from it at his or her own control. It has limited power however, and thus the wearer can only be suspended for a certain amount of time.";
$WeapMountMSG[CamoPack] = 			"The Camo pack is available only to Fremen and their kind. It allows them to quickly bury themselves in the sand, and remain there until they are ready to leave. While hidden, they, for the most part, cannot be detected.";
$WeapMountMSG[StoneBurnerPack] = 		"This pack contains a small localized atmoic weapon that is devised to incinerate a vertical cylindrical area of space. When placed, it will detonate in 30 seconds. Although more powerfull versions of this weapon could penetrate deep enough into the";
$WeapMountMSG2[StoneBurnerPack] = 		"crust of a planet to punch a hole through it, this version is small enough not to.***WARNING: This weapon is BANNED by the Great Convention and reenforced by the Lansarad Council. Use of Family Atomics could result in banishment of your House.";
$WeapMountMSG[SNukePack] = 			"This pack contains a small atmoic warhead detonation device. When detonated, it creates a localized atmoic blast slightly larger then that of a Stone Burner. When placed, it will detonate in 60 seconds. ***WARNING: This weapon is BANNED by the";
$WeapMountMSG2[SNukePack] = 			"Great Convention and reenforced by the Lansarad Council. Use of Family atmoics could result in banishment of your House.";
$WeapMountMSG[MNukePack] = 			"This pack contains a medium sized atmoic warhead detonation device. When detonated, it creates a wide atmoic blast that will incinerate anything in its radius.  When placed, it will detonate in 120 seconds. ***WARNING: This weapon is BANNED by";
$WeapMountMSG2[MNukePack] = 			"the Great Convention and reenforced by the Lansarad Council. Use of Family atmoics could result in banishment of your House.";
$WeapMountMSG[LNukePack] = 			"This pack contains a large sized atmoic warhead detonation device. When detonated, it creates an extreamly widespread atmoic blast that will incinerate anything within miles. When placed, it will detonate in 300 seconds. ***WARNING: This weapon";
$WeapMountMSG2[LNukePack] = 			"is BANNED by the Great Convention and reenforced by the Lansarad Council. Use of Family atmoics could result in banishment of your House.";
$WeapMountMSG[MotionSensorPack] = 		"When deployed this small sensor will alert any enemy movement detected within its visable radius.";
$WeapMountMSG[PulseSensorPack] = 		"This is a small radar device that, when deployed, will detect any enemy activity in its radius.";
$WeapMountMSG[DeployableSensorJammerPack] = 	"This is a deployable sensor jammer that when activated will jam any enemy radar scanning by method of employing radar noise, effectivly covering the position of any surrounding units.";
$WeapMountMSG[CameraPack] =			"This is a small camara that when deployed, may be viewed through by a remote user, inorder to watch for any enemy movement.";
$WeapMountMSG[DeployableInvPack] =		"This is a small utility station that contains an assortment of military items. Although it is designed for on-field use, it is extreamly fragile when compaired to traditional inventory stations."; 
$WeapMountMSG[DeployableAmmopack] = 		"This is a small ammo station that contains an assortment of ammunition. Although it is designed for on-field use, it is extreamly fragile when compaired to traditional ammo stations.";
$WeapMountMSG[PlasteelPack] = 			"This pack contains a deployable blast wall constructed of strong Plasteel material. It is usefull for reenforcing bases, and other defenseable positions.";
$WeapMountMSG[LPentashieldPack] = 		"This pack contains a large deployable Pentashield. The shield is a five-layer shield-generator field suitable for small areas such as doorways or passages. It contains large reinforcing and virtually impassable to anyone not wearing a dissembler";
$WeapMountMSG2[LPentashieldPack] = 		"tuned to the shield codes. As with personal shields, a large enough stress can over burden Pentashields.";
$WeapMountMSG[SPentashieldPack] = 		"This pack contains a small deployable Pentashield. The shield is a five-layer shield-generator field suitable for small areas such as doorways or passages. It contains large reinforcing and virtually impassable to anyone not wearing a dissembler";
$WeapMountMSG2[SPentashieldPack] = 		"tuned to the shield codes. As with personal shields, a large enough stress can over burden Pentashields.";
$WeapMountMSG[DeployableGenPack] = 		"This pack contains a deployable generator that can be used to reenforce local power grids, providing power incase main generators are disabled.";
$WeapMountMSG[HieregPack] = 			"The Hiereg pack contains a Fremen Hiereg that is normaly deployed on open sand. Once set up, the deployer gains a temporary Fremen desert camp, complete with touch Plasteel walls, which makes for an excelent defensive position.";
$WeapMountMSG[StationaryLasgunPack] = 		"This pack contains a deployable gun emplacement that must be controled by an infantryman. The gun itself contains a powerful Heavy Lasgun that is even more distructable then the portable kind.";
$WeapMountMSG[RemoteLasgunPack] = 		"This pack contains a small deployable remote turret. Smuggled and forbidden technology from Ix, it is completely automated and will fire at any enemies within range. It contains a handheld sized Lasgun for weaponry, and thus must be placed VERY";
$WeapMountMSG2[RemoteLasgunPack] = 		"carefully.***WARNING Use sparingly, and away from main bases! Dispite the best efforts of the Ix, these turrets WILL fire at shielded enemies, and can be extreamly destructive to the placer if ignorantly used.";
$WeapMountMSG[RemoteProjectileGunPack] = 	"This pack contains a small deployable remote turret. Smuggled and forbidden technology from Ix, it is completely automated and will fire at any enemies within range. It contains a machine gun for weaponry and is useful for indoor placement.";
$WeapMountMSG[HunterSeekerPlatformPack] = 	"This pack contains a Hunter-Seeker Platform. When deployed, the user may take control of the platform. After doing so, he or she may fire and control the hunter-seeker for assasinations. Best for use against important high ranking enemies.";
$WeapMountMSG[GholaPack] = 			"This pack contains a Ghola. The ghola will be the clone of any chosen dead warrior on the field. After birth, it can be controled through the team chat channel by it's master to preform varius tasks.";
$WeapMountMSG[ThumperPack] = 			"This pack contains a long range Thumper. When deployed in sand, it will issue a series deep rythmic poundings through the terrain, which will subsequently attract a worm. The worm will usualy end up heading directly for the thumper and eating it.";

//-Vehicles:
$WeapMountMSG[BasicThopter] = 			"The Spotter is a standard scouting Ornithopter. It has no weapons, and no shields, but is faster then normal Ornithopters. Used primarily to watch for wormsign during harvesting, they have been found to be very effective scouts.";
$WeapMountMSG[ArtillaryThopter] = 		"This Ornithopter is designed for taking out shielded and armored ground targets. Its high explosive bombs can overload shields, and clear empalcements in seconds. It employs its artillary bombs for offense, and a standard 'Thopter shield for defense. The 'Thopter's fire control will";
$WeapMountMSG2[ArtillaryThopter] = 		"not allow the bombs to deploy unless the shield is down. As a result, when the bombs are dropping, the 'Thopter is made vulnerable.";
$WeapMountMSG[VulcanThopter] = 			"This Ornithopter is designed for taking out unshielded squads. Its vulcan cannons can tear apart whole platoons in seconds. It employs its Vulcan cannon for offense, and a standard 'Thopter shield for defense. The 'Thopter's fire control will";
$WeapMountMSG2[VulcanThopter] = 		"not allow the guns to fire unless the shield is down. As a result, when the Vulcans are firing, the 'Thopter is made vulnerable.";
$WeapMountMSG[LasgunThopter] = 			"This Ornithopter is designed for taking out armored units and UNSHIELDED ground targets. Its Heavy lasgun is capable of doing large amounts of damage. It carries a standard 'Thopter shield for defense. The 'Thopter's fire control will not";
$WeapMountMSG2[LasgunThopter] = 		"allow the guns to fire unless the shield is down. As a result, while the Lasgun is fireing, the 'Thopter is made vulnerable.***WARNING If a Lasgun is used against a shield of any kind, the resulting fusion contact can cause an atmoic";
$WeapMountMSG3[LasgunThopter] = 		"reaction at the point of contact, and at the point of origin. USE SPARINGLY AND WITH CAUTION.";
$WeapMountMSG[Carryall] = 			"This Ornithopter is a large multitask airborn unit. Its primary purpose is to act as an APC and deposit troops in enemy territoy, or evactuate them. It also is capable of ferrying single ground cars to remote locations. It has has a standard";
$WeapMountMSG2[Carryall] = 			"'Thopter shield for protection against AA fire, but no weapons. The size makes it slow and somewhat unmanuverable when compared to the smaller 'Thopters.";
$WeapMountMSG[Roller] = 			"The Roller is a one manned ground car. It has no shields, but is quite fast and boasts a mounted chain cannon for personal protection. It is ment as a scouting vehicle.";
$WeapMountMSG[Tracker] = 			"The Tracker is a 3 manned assult ground car. It has no shields, and is slower then the Roller, but has a passenger mounted chain cannon for anti-personal, and a large artilary shell cannon for anti-armor.";
$WeapMountMSG[Crawler] = 			"The Crawler is a large armored APC ground car capable of carrying 4 extra troops. It has no shields, only one mounted chain cannon, and is somewhat sluggish, and thus relies on its heavy armor for protection.";

//-Items:
$WeapMountMSG[PistolClip] = 			"A 12 round Magazine for the Pistol.";
$WeapMountMSG[RepairKit] = "";
$WeapMountMSG[Beacon] = "";

//-Armors:
$WeapMountMSG[SoldierArmor] = "";
$WeapMountMSG[TrooperArmor] = "";
$WeapMountMSG[FremenArmor] = "";
$WeapMountMSG[FedaykinArmor] = "";
$WeapMountMSG[SardaukarArmor] = "";
$WeapMountMSG[BasharArmor] = "";
$WeapMountMSG[BursegArmor] = "";
$WeapMountMSG[FaceDancerArmor] = "";

//---------------------------------------------------------------------------------

//Depreciated.
$spawnBuyList[0] = SoldierArmor;
$spawnBuyList[1] = Knife;
$spawnBuyList[2] = Pistol;
$spawnBuyList[3] = Grenade;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = "";

function remotePlayMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModePlay);
   }
}

function remoteCommandMode(%clientId)
{
   // can't switch to command mode while a server menu is up
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);  // force the bandwidth to be full command
		if(%clientId.observerMode != "pregame")
		   checkControlUnmount(%clientId);
		Client::setGuiMode(%clientId, $GuiModeCommand);
   }
}

function remoteInventoryMode(%clientId)
{
   if(!%clientId.guiLock && !Observer::isObserver(%clientId))
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeInventory);
   }
}

function remoteObjectivesMode(%clientId)
{
   if(!%clientId.guiLock)
   {
      remoteSCOM(%clientId, -1);
      Client::setGuiMode(%clientId, $GuiModeObjectives);
   }
}

function remoteScoresOn(%clientId)
{
   if(!%clientId.menuMode)
      Game::menuRequest(%clientId);
}

function remoteScoresOff(%clientId)
{
   Client::cancelMenu(%clientId);
}

function remoteToggleCommandMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeCommand)
		remoteCommandMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleInventoryMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeInventory)
		remoteInventoryMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function remoteToggleObjectivesMode(%clientId)
{
	if (Client::getGuiMode(%clientId) != $GuiModeObjectives)
		remoteObjectivesMode(%clientId);
	else
		remotePlayMode(%clientId);
}

function Time::getMinutes(%simTime)
{
   return floor(%simTime / 60);
}

function Time::getSeconds(%simTime)
{
   return %simTime % 60;
}

function Game::pickRandomSpawn(%team)
{
   %group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/Random");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;
  	%spawnIdx = floor(getRandom() * (%count - 0.1));
  	%value = %count;
	for(%i = %spawnIdx; %i < %value; %i++) {
		%set = newObject("set",SimSet);
		%obj = Group::getObject(%group, %i);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$VehicleObjectType,GameBase::getPosition(%obj),2,2,4,0) == 0) {
			deleteObject(%set);
			return %obj;		
		}
		if(%i == %count - 1) {
			%i = -1;
			%value = %spawnIdx;
		}
		deleteObject(%set);
	}
   return false;
}

function Game::pickStartSpawn(%team)
{
   %group = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\DropPoints\\Start");
   %count = Group::objectCount(%group);
   if(!%count)
      return -1;

   %spawnIdx = $lastTeamSpawn[%team] + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   $lastTeamSpawn[%team] = %spawnIdx;
   return Group::getObject(%group, %spawnIdx);
}

function Game::pickTeamSpawn(%team, %respawn)
{
   if(%respawn)
      return Game::pickRandomSpawn(%team);
   else
   {
      %spawn = Game::pickStartSpawn(%team);
      if(%spawn == -1)
         return Game::pickRandomSpawn(%team);
      return %spawn;
   }
}

function Game::pickObserverSpawn(%client)
{
   %group = nameToID("MissionGroup\\ObserverDropPoints");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team" @ Client::getTeam(%client) @ "\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      %group = nameToID("MissionGroup\\Teams\\team0\\DropPoints\\Random");
   %count = Group::objectCount(%group);
   if(%group == -1 || !%count)
      return -1;
   %spawnIdx = %client.lastObserverSpawn + 1;
   if(%spawnIdx >= %count)
      %spawnIdx = 0;
   %client.lastObserverSpawn = %spawnIdx;
	return Group::getObject(%group, %spawnIdx);
}

function UpdateClientTimes(%time)
{
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      remoteEval(%cl, "setTime", -%time);
}

function Game::notifyMatchStart(%time)
{
   messageAll(0, "Match starts in " @ %time @ " seconds.");
   UpdateClientTimes(%time);
}

function Game::startMatch()
{
   $matchStarted = true;
   $missionStartTime = getSimTime();
   messageAll(0, "Match started.");
	Game::resetScores();	

   %numTeams = getNumTeams();
   for(%i = 0; %i < %numTeams; %i = %i + 1) {
		if($TeamEnergy[%i] != "Infinite")
			schedule("replenishTeamEnergy(" @ %i @ ");", $secTeamEnergy);
	}

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.observerMode == "pregame")
      {
         %cl.observerMode = "";
         Client::setControlObject(%cl, Client::getOwnedObject(%cl));
      }
   	Game::refreshClientScore(%cl);
	}
   Game::checkTimeLimit();
}

function Game::pickPlayerSpawn(%clientId, %respawn)
{
   return Game::pickTeamSpawn(Client::getTeam(%clientId), %respawn);
}

function Game::playerSpawn(%clientId, %respawn)
{
   if(!$ghosting)
      return false;

   if(!DropShips::CanSpawn(%clientid))
   {
	if(!Observer::nextObservableTeamMate(%clientid))
	{
		DropShip::getTeamObserverPoint(%clientid);
	}
	Client::setOwnedObject(%clientid, -1);
	Client::setControlObject(%clientid, Client::getObserverCamera(%clientid));
	%clientid.observerMode = "dead";
	return false;
   }
	Client::clearItemShopping(%clientId);
   %spawnMarker = Game::pickPlayerSpawn(%clientId, %respawn);
   centerprint(%clientid,"",0);
   if(!%respawn)
   {
      // initial drop
      MissionIntro::init(%clientId);
   }
	if(%spawnMarker) {   
		%clientId.guiLock = "";
	 	%clientId.dead = "";
	   if(%spawnMarker == -1)
	   {
	      %spawnPos = "0 0 300";
	      %spawnRot = "0 0 0";
	   }
	   else
	   {
	      %spawnPos = GameBase::getPosition(%spawnMarker);
	      %spawnRot = GameBase::getRotation(%spawnMarker);
	   }

		if(!String::ICompare(Client::getGender(%clientId), "Male"))
	      %armor = "sarmor";
	   else
	      %armor = "sfemale";

	   %pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	   echo("SPAWN: cl:" @ %clientId @ " pl:" @ %pl @ " marker:" @ %spawnMarker @ " armor:" @ %armor);
	   if(%pl != -1)
	   {
	      GameBase::setTeam(%pl, Client::getTeam(%clientId));
	      Client::setOwnedObject(%clientId, %pl);
	      Game::playerSpawned(%pl, %clientId, %armor, %respawn);
	      
	      if($matchStarted)
	         Client::setControlObject(%clientId, %pl);
	      else
	      {
	         %clientId.observerMode = "pregame";
	         Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	         Observer::setOrbitObject(%clientId, %pl, 3, 3, 3);
	      }
	   }
      return true;
	}
	else {
		Client::sendMessage(%clientId,0,"Sorry No Respawn Positions Are Empty - Try again later ");
      return false;
	}
}

function Game::playerSpawned(%pl, %clientId, %armor)
{
	remoteeval(%clientid,setTeam,$ServerNameToKeyName[client::getteam(%clientId)]);
	Worm::AddToTargetQueue(%pl);
			  
	%clientId.spawn= 1;
	%max = getNumItems();

// Depreciated because of teambased spawnsets
//	for(%i = 0; (%item = $spawnBuyList[%i]) != ""; %i++) {
//		buyItem(%clientId,%item);	
//		echo("Spawn-Buying: "@%item);
//		if(%item.className == Weapon) 
//			%clientId.spawnWeapon = %item;
//	}
	%armor = "";

	for(%i = 0; (%item = $TeamSpawnBuyList[$ServerNameToKeyName[client::getteam(%clientId)], %i]) != ""; %i++) {
		//buyItem(%clientId,%item);	
		//echo("Spawn-Buying: "@%item);
		player::incitemcount(%clientID,%item);
		if(%item.className == Weapon) 
		{
			%clientId.spawnWeapon = %item;
			if($ClipSize[%item])
			{
				player::incitemcount(%clientid,$WeaponAmmo[%item],$ClipSize[%item]);
			}
			if($Clip[%item] != "")
			{
				player::incitemcount(%clientid,$Clip[%item],$ItemMax[player::getarmor(%clientid), $Clip[%item]]);
			}

		} else if (%item.className == Armor)
		{
			%armor = %item;
			Player::setArmor(%clientid,$ArmorType[Client::getGender(%clientid), %item]);
			remoteeval(%clientid,setArmor,%armor);
			armorChange(%clientid);
		} else if (%item.classname == BackPack)
		{
				Player::useItem(%clientid,%item);		
		}
	}
	%clientId.spawn= "";
	$Reloading[%clientId] = "";
	%sw = %clientId.spawnWeapon;
	if(%clientId.spawnWeapon != "") {
		Player::useItem(%pl,%clientId.spawnWeapon);	
   		%clientId.spawnWeapon = "";
	}
	$CurWeap[%clientId] = $WeaponToNum[%clientId.spawnweapon];
	$LastUsedWeap[%clientid] = $WeaponToNum[%sw];
	// Weapon type is always melee at spawn.
	%clientId.weaponType = melee;
} 

function Game::autoRespawn(%client)
{
	if(%client.dead == 1)
		Game::playerSpawn(%client, "true");
}

function onServerGhostAlwaysDone()
{
}

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      //Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
         centerprint(%clientId, $Server::JoinMOTD, 0);
         //displayMessage( %clientId);
	 %clientId.observerMode = "justJoined";
         %clientId.justConnected = "";
	 %clientId.dietime = getSimTime(); //Diddily bug fix.

      }
      else if(%clientId.observerMode == "justJoined")
      {

         centerprint(%clientId, "");
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
	{
         Game::playerSpawn(%clientId, false);
	}	
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}

function processMenuInitialPickTeam(%clientId, %team)
{
   if($Server::TourneyMode && $matchStarted)
      %team = -2;

   if(%team == -2)
   {
      Observer::enterObserverMode(%clientId);
   }
   if(%team == -1)
   {
      Game::assignClientTeam(%clientId);
      %team = Client::getTeam(%clientId);
   }
   if(%team != -2)
   {
      GameBase::setTeam(%clientId, %team);
		if($TeamEnergy[%team] != "Infinite")
			$TeamEnergy[%team] += $InitialPlayerEnergy;
      %clientId.teamEnergy = 0;
      Client::setControlObject(%clientId, -1);
      Game::playerSpawn(%clientId, false);
   }
   if($Server::TourneyMode && !$CountdownStarted)
   {
      if(%team != -2)
      {
         bottomprint(%clientId, "<f1><jc>For Shai-Hulud.", 0);
         %clientId.notready = true;
         %clientId.notreadyCount = "";
      }
      else
      {
         bottomprint(%clientId, "", 0);
         %clientId.notready = "";
         %clientId.notreadyCount = "";
      }
   }
}

function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}


function Game::checkTimeLimit()
{
   // if no timeLimit set or timeLimit set to 0,
   // just reschedule the check for a minute hence
   $timeLimitReached = false;

   if(!$Server::timeLimit)
   {
      schedule("Game::checkTimeLimit();", 60);
      return;
   }
   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
      echo("GAME: Timelimit reached.");
      $timeLimitReached = true;
      Server::nextMission();
   }
   else
   {
      schedule("Game::checkTimeLimit();", 20);
      UpdateClientTimes(%curTimeLeft);
   }
}

function Game::resetScores(%client)
{
	if(%client == "") {
	   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	      %cl.scoreKills = 0;
   	   %cl.scoreDeaths = 0;
			%cl.ratio = 0;
      	%cl.score = 0;
		}
	}
	else {
      %client.scoreKills = 0;
  	   %client.scoreDeaths = 0;
		%client.ratio = 0;
     	%client.score = 0;
	}
}

function remoteSetArmor(%player, %armorType)
{
	if ($ServerCheats) {
		checkMax(Player::getClient(%player),%armorType);
	   Player::setArmor(%player, %armorType);
	}
	else if($TestCheats) {
	   Player::setArmor(%player, %armorType);
	}
}


function Game::onPlayerConnected(%playerId)
{
   %playerId.scoreKills = 0;
   %playerId.scoreDeaths = 0;
	%playerId.score = 0;
   %playerId.justConnected = true;
   $menuMode[%playerId] = "None";
   Game::refreshClientScore(%playerId);
}

function Game::assignClientTeam(%playerId)
{
   if($teamplay)
   {
      %name = Client::getName(%playerId);
      %numTeams = getNumTeams();
      if($teamPreset[%name] != "")
      {
         if($teamPreset[%name] < %numTeams)
         {
            GameBase::setTeam(%playerId, $teamPreset[%name]);
            echo(Client::getName(%playerId), " was preset to team ", $teamPreset[%name]);
            return;
         }            
      }
      %numPlayers = getNumClients();
      for(%i = 0; %i < %numTeams; %i = %i + 1)
         %numTeamPlayers[%i] = 0;

      for(%i = 0; %i < %numPlayers; %i = %i + 1)
      {
         %pl = getClientByIndex(%i);
         if(%pl != %playerId)
         {
            %team = Client::getTeam(%pl);
            %numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
         }
      }
      %leastPlayers = %numTeamPlayers[0];
      %leastTeam = 0;
      for(%i = 1; %i < %numTeams; %i = %i + 1)
      {
         if( (%numTeamPlayers[%i] < %leastPlayers) || 
            ( (%numTeamPlayers[%i] == %leastPlayers) && 
            ($teamScore[%i] < $teamScore[%leastTeam] ) ))
         {
            %leastTeam = %i;
            %leastPlayers = %numTeamPlayers;
         }
      }
      GameBase::setTeam(%playerId, %leastTeam);
      echo(Client::getName(%playerId), " was automatically assigned to team ", %leastTeam);
   }
   else
   {
      GameBase::setTeam(%playerId, 0);
   }
}

//****Overwriting old function with new %special cases****//
//function Client::onKilled(%playerId, %killerId, %damageType)
function Client::onKilled(%playerId, %killerId, %damageType, %special)
{
	%playerGender = "his";
	%killerGender = %playerGender;
	if(Mech::isMech(%playerId))
	{	
		Mech::RemoveFromList(client::getname(%playerId));
		$TeamItemCount[gamebase::GetTeam(%playerId) @ $Mech::nameToType[client::getname(%playerId)]]--;
	}

	if(gamebase::getcontrolclient(%killerId) != -1)
		%killerId = gamebase::getcontrolclient(%killerId);
	echo("GAME: kill " @ %playerId @ " killed by " @ %killerId @ ": " @ $damageType[%damageType]);
	%playerId.guiLock = true;
	Client::setGuiMode(%playerId, $GuiModePlay);
//	if(!String::ICompare(Client::getGender(%playerId), "Male"))
//		%playerGender = "his";
//	else
//		%playerGender = "her";
	//-Here I make it so that the number used in the Death MSG is assigned to the var %special unless it doesn't exist
	%ridx = %special;
	if(%special == "")
		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	//-End of %special MSG var setup
	%victimName = Client::getName(%playerId);
	//if(%damageType && %damageType == $WormDamageType) {
	//	messageAll(0, strcat(%victimName, " dies."), $DeathMessageMask);
	//	%playerId.scoreDeaths++;
	//}
	if(%damageType == $WormDamageType){
		%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
		messageAll(0, %obitMsg, $DeathMessageMask);
		
		%playerId.scoreDeaths++;
	}
	else if(%killerId == %playerId) {
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		if(%damagetype != $AssassinDamageType)
			messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
		IncSpawnTime(%playerId, $SuicideSpawnInc);
		if( floor(getRandom() * 5) == 3 ) {
			$FirstClassMessage[%playerId] = "<jc>Every time you commit suicide, your spawntime increases " @$SuicideSpawnInc @ " seconds!";
			$FirstClassMessageExists[%playerId] = true;
			Bottomprint(%playerId, $FirstClassMessage[%playerId], 10);
			schedule("$FirstClassMessageExists["@%playerId@"] = false;", 10);
		}

	}
	else if($FaceDancerIsSwitched[%killerId] && !String::Compare(%killerId.ImpersonatingWho,client::getName(%playerId))) {
		%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender);
		if(%damagetype != $AssassinDamageType)
			messageAll(0, %oopsMsg, $DeathMessageMask);
		%killerId.scoreKills++;
		%playerId.scoreDeaths++;  // test play mode
		%killerId.score++;
		Game::refreshClientScore(%killerId);
		Game::refreshClientScore(%playerId);
	}
	else {
//		if(!String::ICompare(Client::getGender(%killerId), "Male"))
//			%killerGender = "his";
//		else
//			%killerGender = "her";
		if($teamplay && (Client::getTeam(%killerId) == Client::getTeam(%playerId)) && !Mech::isMech(%playerID)) {
			if(%damageType != $MineDamageType) 
				messageAll(0, strcat(Client::getName(%killerId)," mows down ", %killerGender, " teammate, ", %victimName), $DeathMessageMask);
			else 
				messageAll(0, strcat(Client::getName(%killerId)," killed ", %killerGender, " teammate, ", %victimName ," with a mine."), $DeathMessageMask);
			%killerId.scoreDeaths++;
			%killerId.score--;
			Game::refreshClientScore(%killerId);
			IncSpawnTime(%killerId, $TKSpawnInc);

		}
		else if(!Mech::isMech(%playerID)){

//			if($FaceDancerIsSwitched[%killerId] && !String::ICompare(%killerId.ImpersonatingWhoSex, "Male"))
//				%killerGender = "his";
//			else
//				%killerGender = "her";
			if($FaceDancerIsSwitched[%killerId])
				%obitMsg = sprintf($deathMsg[%damageType, %ridx], %killerId.ImpersonatingWho, %victimName, %killerGender, %playerGender, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
			else
				%obitMsg = sprintf($deathMsg[%damageType, %ridx], Client::getName(%killerId), %victimName, %killerGender, %playerGender, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
			if(%damagetype != $AssassinDamageType && %damageType != $AsphyxiationDamageType)
				messageAll(0, %obitMsg, $DeathMessageMask);
			%killerId.scoreKills++;
			%playerId.scoreDeaths++;  // test play mode
			%killerId.score++;
			Game::refreshClientScore(%killerId);
			Game::refreshClientScore(%playerId);
		}
	}
	CalcSpawnTime(%playerId);
	Game::clientKilled(%playerId, %killerId);
	displayMessage(%playerId);
	//Centerprint(%playerId, "<jc>O you who know what we suffer here, do not forget us in your prayers.", 5);
	$CanSpawnSpecial[%playerId] = "Yes";
}

function Game::clientKilled(%playerId, %killerId)
{
   // do nothing
}


function Game::NumTeamPlayers(%team)
{
	%numplayers = 0;
	for(%i = Client::getFirst(); %i != -1; %i = Client::getNext(%i))
         	if(Client::getteam(%i) == %team)
         	   %numplayers = %numplayers + 1;

	return %numplayers;
}

function Client::leaveGame(%clientId)
{
   // do nothing
}

function Player::enterMissionArea(%player)
{
   echo("Player " @ %player @ " entered the mission area.");
}

function Player::leaveMissionArea(%player)
{
   echo("Player " @ %player @ " left the mission area.");
}

function GameBase::getHeatFactor(%this)
{
   return 0.0;
}

