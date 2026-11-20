
$BulletDmgType10 = 45; //Shotgun slug
$BulletDmgType11 = 46; //Turret bullet
$BulletDmgType12 = 47; //sequential bullet damage types
$BulletDmgType13 = 48; //sequential bullet damage types
$BulletDmgType14 = 49; //sequential bullet damage types
$BulletDmgType15 = 50; //sequential bullet damage types
$BulletDmgType16 = 51; //sequential bullet damage types
$BulletDmgType17 = 52; //sequential bullet damage types
$BulletDmgType18 = 53; //sequential bullet damage types
$BulletDmgType19 = 54; //sequential bullet damage types
$BulletDmgType20 = 55; //sequential bullet damage types

// Shotgun slug

$DamageScale[hlarmor, $BulletDmgType10] = 1.0;
$DamageScale[hlfemale, $BulletDmgType10] = 1.0;
$DamageScale[larmor, $BulletDmgType10] = 1.0;
$DamageScale[lfemale, $BulletDmgType10] = 1.0;
$DamageScale[earmor, $BulletDmgType10] = 1.0;
$DamageScale[efemale, $BulletDmgType10] = 1.0;
$DamageScale[marmor, $BulletDmgType10] = 1.0;
$DamageScale[mfemale, $BulletDmgType10] = 1.0;
$DamageScale[harmor, $BulletDmgType10] = 1.0;
$DamageScale[uharmor, $BulletDmgType10] = 1.0;
$DamageScale[Scout, $BulletDmgType10] = 1.0;
$DamageScale[LAPC, $BulletDmgType10] = 1.0;
$DamageScale[HAPC, $BulletDmgType10] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType10] = 2.0;
$DoorScale[$BulletDmgType10] = 2; //damage done to a door

$DamageDescription[$BulletDmgType10] = "Shotgun Slug";

$deathMsg[$BulletDmgType10, 0]      = "%1 replaces %2's brain with a lead slug.";
$deathMsg[$BulletDmgType10, 1]      = "%1 splatters %2 with a lead slug.";
$deathMsg[$BulletDmgType10, 2]      = "%1 knocks %2 back with a shotgun slug.";
$deathMsg[$BulletDmgType10, 3]      = "%1 pounded %2 with a heavy slug.";

// Turret round

$DamageScale[hlarmor, $BulletDmgType11] = 1.0;
$DamageScale[hlfemale, $BulletDmgType11] = 1.0;
$DamageScale[larmor, $BulletDmgType11] = 1.0;
$DamageScale[lfemale, $BulletDmgType11] = 1.0;
$DamageScale[earmor, $BulletDmgType11] = 1.0;
$DamageScale[efemale, $BulletDmgType11] = 1.0;
$DamageScale[marmor, $BulletDmgType11] = 1.0;
$DamageScale[mfemale, $BulletDmgType11] = 1.0;
$DamageScale[harmor, $BulletDmgType11] = 1.0;
$DamageScale[uharmor, $BulletDmgType11] = 1.0;
$DamageScale[Scout, $BulletDmgType11] = 1.0;
$DamageScale[LAPC, $BulletDmgType11] = 1.0;
$DamageScale[HAPC, $BulletDmgType11] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType11] = 2.0;
$DoorScale[$BulletDmgType11] = 2.0; //damage done to a door

$DamageDescription[$BulletDmgType11] = "Turret bullet";

$deathMsg[$BulletDmgType11, 0]      = "%2 found %1's turret.";
$deathMsg[$BulletDmgType11, 1]      = "%2 lost to a duel with %1's turret.";
$deathMsg[$BulletDmgType11, 2]      = "%2 had a bad experience with %1's turret.";
$deathMsg[$BulletDmgType11, 3]      = "%2 thought %1's turret was inanimate.";

// OICW round

$DamageScale[hlarmor, $BulletDmgType12] = 1.0;
$DamageScale[hlfemale, $BulletDmgType12] = 1.0;
$DamageScale[larmor, $BulletDmgType12] = 1.0;
$DamageScale[lfemale, $BulletDmgType12] = 1.0;
$DamageScale[earmor, $BulletDmgType12] = 1.0;
$DamageScale[efemale, $BulletDmgType12] = 1.0;
$DamageScale[marmor, $BulletDmgType12] = 1.0;
$DamageScale[mfemale, $BulletDmgType12] = 1.0;
$DamageScale[harmor, $BulletDmgType12] = 1.0;
$DamageScale[uharmor, $BulletDmgType12] = 1.0;
$DamageScale[Scout, $BulletDmgType12] = 1.0;
$DamageScale[LAPC, $BulletDmgType12] = 1.0;
$DamageScale[HAPC, $BulletDmgType12] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType12] = 2.0;
$DoorScale[$BulletDmgType12] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType12] = "OICW bullet";

$deathMsg[$BulletDmgType12, 0]      = "%2 got caught by %1's OICW spray.";
$deathMsg[$BulletDmgType12, 1]      = "%1 chopped %2 into bite size chunks with his OICW.";
$deathMsg[$BulletDmgType12, 2]      = "%2 was pureed by %1's OICW.";
$deathMsg[$BulletDmgType12, 3]      = "%2 was belittled by %1's OICW.";

// OICW Grenade

$DamageScale[hlarmor, $BulletDmgType13] = 0.25;
$DamageScale[hlfemale, $BulletDmgType13] = 0.25;
$DamageScale[larmor, $BulletDmgType13] = 0.25;
$DamageScale[lfemale, $BulletDmgType13] = 0.25;
$DamageScale[earmor, $BulletDmgType13] = 0.28;
$DamageScale[efemale, $BulletDmgType13] = 0.28;
$DamageScale[marmor, $BulletDmgType13] = 0.28;
$DamageScale[mfemale, $BulletDmgType13] = 0.28;
$DamageScale[harmor, $BulletDmgType13] = 0.35;
$DamageScale[uharmor, $BulletDmgType13] = 0.35;
$DamageScale[Scout, $BulletDmgType13] = 50.0;
$DamageScale[LAPC, $BulletDmgType13] = 50.0;
$DamageScale[HAPC, $BulletDmgType13] = 50.0;
$DamageScale[AttackDrone, $BulletDmgType13] = 2.0;
$DoorScale[$BulletDmgType13] = 20; //damage done to a door

$DamageDescription[$BulletDmgType13] = "OICW Grenade";

$deathMsg[$BulletDmgType13, 0]      = "%2 was disintegrated by %1's OICW Grenade.";
$deathMsg[$BulletDmgType13, 1]      = "%1 shoved an OICW grenade into %2's pants.";
$deathMsg[$BulletDmgType13, 2]      = "%2 was tagged by %1's OICW grenade.";
$deathMsg[$BulletDmgType13, 3]      = "%2 was turned to kibble by %1's OICW grenade.";

// Remington round

$DamageScale[hlarmor, $BulletDmgType14] = 1.0;
$DamageScale[hlfemale, $BulletDmgType14] = 1.0;
$DamageScale[larmor, $BulletDmgType14] = 1.0;
$DamageScale[lfemale, $BulletDmgType14] = 1.0;
$DamageScale[earmor, $BulletDmgType14] = 1.0;
$DamageScale[efemale, $BulletDmgType14] = 1.0;
$DamageScale[marmor, $BulletDmgType14] = 1.0;
$DamageScale[mfemale, $BulletDmgType14] = 1.0;
$DamageScale[harmor, $BulletDmgType14] = 1.0;
$DamageScale[uharmor, $BulletDmgType14] = 1.0;
$DamageScale[Scout, $BulletDmgType14] = 1.0;
$DamageScale[LAPC, $BulletDmgType14] = 1.0;
$DamageScale[HAPC, $BulletDmgType14] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType14] = 2.0;
$DoorScale[$BulletDmgType14] = 0.5; //damage done to a door

$DamageDescription[$BulletDmgType12] = "Remington bullet";

$deathMsg[$BulletDmgType14, 0]      = "%2 is leaking from %1's Remington hole.";
$deathMsg[$BulletDmgType14, 1]      = "%1 gave %2 a free Remington nipple piercing.";
$deathMsg[$BulletDmgType14, 2]      = "%2 thinks %1's Remington bullet tastes funny.";
$deathMsg[$BulletDmgType14, 3]      = "%2 coughed up %1's Remington round.";

// Glock round

$DamageScale[hlarmor, $BulletDmgType15] = 1.0;
$DamageScale[hlfemale, $BulletDmgType15] = 1.0;
$DamageScale[larmor, $BulletDmgType15] = 1.0;
$DamageScale[lfemale, $BulletDmgType15] = 1.0;
$DamageScale[earmor, $BulletDmgType15] = 1.0;
$DamageScale[efemale, $BulletDmgType15] = 1.0;
$DamageScale[marmor, $BulletDmgType15] = 1.0;
$DamageScale[mfemale, $BulletDmgType15] = 1.0;
$DamageScale[harmor, $BulletDmgType15] = 1.0;
$DamageScale[uharmor, $BulletDmgType15] = 1.0;
$DamageScale[Scout, $BulletDmgType15] = 1.0;
$DamageScale[LAPC, $BulletDmgType15] = 1.0;
$DamageScale[HAPC, $BulletDmgType15] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType14] = 2.0;
$DoorScale[$BulletDmgType14] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType12] = "Glock bullet";

$deathMsg[$BulletDmgType15, 0]      = "%2 got clocked by %1's Glock.";
$deathMsg[$BulletDmgType15, 1]      = "%1 gave %2 a tingly sensation with %3 glock.";
$deathMsg[$BulletDmgType15, 2]      = "%2 was bled out by %1's glock.";
$deathMsg[$BulletDmgType15, 3]      = "%2 has a nice 9mm hole from %1.";

// Ruger round

$DamageScale[hlarmor, $BulletDmgType16] = 1.0;
$DamageScale[hlfemale, $BulletDmgType16] = 1.0;
$DamageScale[larmor, $BulletDmgType16] = 1.0;
$DamageScale[lfemale, $BulletDmgType16] = 1.0;
$DamageScale[earmor, $BulletDmgType16] = 1.0;
$DamageScale[efemale, $BulletDmgType16] = 1.0;
$DamageScale[marmor, $BulletDmgType16] = 1.0;
$DamageScale[mfemale, $BulletDmgType16] = 1.0;
$DamageScale[harmor, $BulletDmgType16] = 1.0;
$DamageScale[uharmor, $BulletDmgType16] = 1.0;
$DamageScale[Scout, $BulletDmgType16] = 1.0;
$DamageScale[LAPC, $BulletDmgType16] = 1.0;
$DamageScale[HAPC, $BulletDmgType16] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType16] = 2.0;
$DoorScale[$BulletDmgType16] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType16] = "Ruger bullet";

$deathMsg[$BulletDmgType16, 0]      = "%2 was brained by %1's Ruger.";
$deathMsg[$BulletDmgType16, 1]      = "%1 gave %2 a new Ruger .22 shaped nostril.";
$deathMsg[$BulletDmgType16, 2]      = "%2 was popped by %1's Ruger.";
$deathMsg[$BulletDmgType16, 3]      = "%2 found %1's ruger to be weak but deadly.";

// Tommy Gun round

$DamageScale[hlarmor, $BulletDmgType17] = 1.0;
$DamageScale[hlfemale, $BulletDmgType17] = 1.0;
$DamageScale[larmor, $BulletDmgType17] = 1.0;
$DamageScale[lfemale, $BulletDmgType17] = 1.0;
$DamageScale[earmor, $BulletDmgType17] = 1.0;
$DamageScale[efemale, $BulletDmgType17] = 1.0;
$DamageScale[marmor, $BulletDmgType17] = 1.0;
$DamageScale[mfemale, $BulletDmgType17] = 1.0;
$DamageScale[harmor, $BulletDmgType17] = 1.0;
$DamageScale[uharmor, $BulletDmgType17] = 1.0;
$DamageScale[Scout, $BulletDmgType17] = 1.0;
$DamageScale[LAPC, $BulletDmgType17] = 1.0;
$DamageScale[HAPC, $BulletDmgType17] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType17] = 2.0;
$DoorScale[$BulletDmgType17] = 0.25; //damage done to a door

$DamageDescription[$BulletDmgType17] = "Tommy Gun";

$deathMsg[$BulletDmgType17, 0]      = "%2 disrespected %1's Tommy gun.";
$deathMsg[$BulletDmgType17, 1]      = "%1 whacked %2 with his Tommy gun";
$deathMsg[$BulletDmgType17, 2]      = "%2 disrespected %1's family and was whacked.";
$deathMsg[$BulletDmgType17, 3]      = "%1 played a game of Al Capone with %2.";

// Flash Grenade

$DamageScale[hlarmor, $BulletDmgType18] = 1.0;
$DamageScale[hlfemale, $BulletDmgType18] = 1.0;
$DamageScale[larmor, $BulletDmgType18] = 1.0;
$DamageScale[lfemale, $BulletDmgType18] = 1.0;
$DamageScale[earmor, $BulletDmgType18] = 1.0;
$DamageScale[efemale, $BulletDmgType18] = 1.0;
$DamageScale[marmor, $BulletDmgType18] = 1.0;
$DamageScale[mfemale, $BulletDmgType18] = 1.0;
$DamageScale[harmor, $BulletDmgType18] = 1.0;
$DamageScale[uharmor, $BulletDmgType18] = 1.0;
$DamageScale[Scout, $BulletDmgType18] = 1.0;
$DamageScale[LAPC, $BulletDmgType18] = 1.0;
$DamageScale[HAPC, $BulletDmgType18] = 1.0;
$DamageScale[AttackDrone, $BulletDmgType18] = 2.0;
$DoorScale[$BulletDmgType18] = 200.0; //damage done to a door

$DamageDescription[$BulletDmgType18] = "Flash Grenade";

$deathMsg[$BulletDmgType18, 0]      = "%2 was flashed by %1 and died of a heart attack.";
$deathMsg[$BulletDmgType18, 1]      = "%2 was blinded by %1's light";
$deathMsg[$BulletDmgType18, 2]      = "%2 walked towards %1's light.";
$deathMsg[$BulletDmgType18, 3]      = "%2 can see no evil thanks to %1.";

// Sticky Bomb

$DamageScale[hlarmor, $BulletDmgType19] = 1.0;
$DamageScale[hlfemale, $BulletDmgType19] = 1.0;
$DamageScale[larmor, $BulletDmgType19] = 1.0;
$DamageScale[lfemale, $BulletDmgType19] = 1.0;
$DamageScale[earmor, $BulletDmgType19] = 1.0;
$DamageScale[efemale, $BulletDmgType19] = 1.0;
$DamageScale[marmor, $BulletDmgType19] = 1.0;
$DamageScale[mfemale, $BulletDmgType19] = 1.0;
$DamageScale[harmor, $BulletDmgType19] = 1.0;
$DamageScale[uharmor, $BulletDmgType19] = 1.0;
$DamageScale[Scout, $BulletDmgType19] = 10.0;
$DamageScale[LAPC, $BulletDmgType19] = 10.0;
$DamageScale[HAPC, $BulletDmgType19] = 10.0;
$DamageScale[AttackDrone, $BulletDmgType19] = 2.0;
$DoorScale[$BulletDmgType19] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType19] = "Sticky Bomb";

$deathMsg[$BulletDmgType19, 0]      = "'I am rubber, you are glue.' says %1 to %2.";
$deathMsg[$BulletDmgType19, 1]      = "%1 put %2 in a sticky situation.";
$deathMsg[$BulletDmgType19, 2]      = "%2 tasted %1's sticky monkey.";
$deathMsg[$BulletDmgType19, 3]      = "'Say hello to my little friend!' says %1 to %2.";

// Rock

$DamageScale[hlarmor, $BulletDmgType20] = 1.0;
$DamageScale[hlfemale, $BulletDmgType20] = 1.0;
$DamageScale[larmor, $BulletDmgType20] = 1.0;
$DamageScale[lfemale, $BulletDmgType20] = 1.0;
$DamageScale[earmor, $BulletDmgType20] = 1.0;
$DamageScale[efemale, $BulletDmgType20] = 1.0;
$DamageScale[marmor, $BulletDmgType20] = 1.0;
$DamageScale[mfemale, $BulletDmgType20] = 1.0;
$DamageScale[harmor, $BulletDmgType20] = 1.0;
$DamageScale[uharmor, $BulletDmgType20] = 1.0;
$DamageScale[Scout, $BulletDmgType20] = 10.0;
$DamageScale[LAPC, $BulletDmgType20] = 10.0;
$DamageScale[HAPC, $BulletDmgType20] = 10.0;
$DamageScale[AttackDrone, $BulletDmgType20] = 2.0;
$DoorScale[$BulletDmgType20] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType20] = "Rock";

$deathMsg[$BulletDmgType20, 0]      = "'%1 got %2 stoned.";
$deathMsg[$BulletDmgType20, 1]      = "%2 was stoned by %1.";
$deathMsg[$BulletDmgType20, 2]      = "%2 was rocked by %1.";
$deathMsg[$BulletDmgType20, 3]      = "%1 rocked %2's world.";

// Belly Gun

$DamageScale[hlarmor, $BulletDmgType21] = 1.0;
$DamageScale[hlfemale, $BulletDmgType21] = 1.0;
$DamageScale[larmor, $BulletDmgType21] = 1.0;
$DamageScale[lfemale, $BulletDmgType21] = 1.0;
$DamageScale[earmor, $BulletDmgType21] = 1.0;
$DamageScale[efemale, $BulletDmgType21] = 1.0;
$DamageScale[marmor, $BulletDmgType21] = 1.0;
$DamageScale[mfemale, $BulletDmgType21] = 1.0;
$DamageScale[harmor, $BulletDmgType21] = 1.0;
$DamageScale[uharmor, $BulletDmgType21] = 1.0;
$DamageScale[Scout, $BulletDmgType21] = 5.0;
$DamageScale[LAPC, $BulletDmgType21] = 5.0;
$DamageScale[HAPC, $BulletDmgType21] = 5.0;
$DamageScale[AttackDrone, $BulletDmgType21] = 2.0;
$DoorScale[$BulletDmgType21] = 50.0; //damage done to a door

$DamageDescription[$BulletDmgType21] = "Belly Gun";

$deathMsg[$BulletDmgType21, 0]      = "%2 rubbed %1's belly gun.";
$deathMsg[$BulletDmgType21, 1]      = "%2 couldn't run from %1's belly gun.";
$deathMsg[$BulletDmgType21, 2]      = "%2 was a victim of %1's belly gun.";
$deathMsg[$BulletDmgType21, 3]      = "%2 met %1's air superiority.";


// POINTS TO BE SCORED FOR EACH KILL


// You must have a score for every damage type or scores wont work
// So lets start with a score of 0 for all items for now -- Deadtaco

$ScorePoints[-1] = 10;
$ScorePoints[0] = -1;
$ScorePoints[1] = 10;
$ScorePoints[2] = 0;
$ScorePoints[3] = 0;
$ScorePoints[4] = 0;
$ScorePoints[5] = 0;
$ScorePoints[6] = 0;
$ScorePoints[7] = 0;
$ScorePoints[8] = 0;
$ScorePoints[9] = 0;
$ScorePoints[10] = 0;
$ScorePoints[11] = 0;
$ScorePoints[12] = 0;
$ScorePoints[13] = 0;
$ScorePoints[14] = 0;
$ScorePoints[15] = 0;
$ScorePoints[16] = 0;
$ScorePoints[17] = 0;
$ScorePoints[18] = 0;
$ScorePoints[19] = 0;
$ScorePoints[20] = 0;
$ScorePoints[21] = 0;
$ScorePoints[22] = 0;
$ScorePoints[23] = 0;
$ScorePoints[24] = 0;
$ScorePoints[25] = 0;
$ScorePoints[26] = 0;
$ScorePoints[27] = 0;
$ScorePoints[28] = 0;
$ScorePoints[29] = 0;
$ScorePoints[30] = 0;
$ScorePoints[31] = 0;
$ScorePoints[32] = 0;
$ScorePoints[33] = 0;
$ScorePoints[34] = 0;
$ScorePoints[35] = 0;
$ScorePoints[36] = 0;
$ScorePoints[37] = 0;
$ScorePoints[38] = 0;
$ScorePoints[39] = 0;
$ScorePoints[40] = 0;
$ScorePoints[41] = 0;
$ScorePoints[42] = 0;
$ScorePoints[43] = 0;
$ScorePoints[44] = 0;
$ScorePoints[45] = 0;
$ScorePoints[46] = 0;
$ScorePoints[47] = 0;
$ScorePoints[48] = 0;
$ScorePoints[49] = 0;
$ScorePoints[50] = 0;

// Now lets give a good score number to each existing damage type

$ScorePoints[$ImpactDamageType] = 10;
$ScorePoints[$LandingDamageType] = -1;
$ScorePoints[$BulletDamageType] = 10;
$ScorePoints[$EnergyDamageType] = 0;
$ScorePoints[$PlasmaDamageType] = 0;
$ScorePoints[$ExplosionDamageType] = 10;
$ScorePoints[$ShrapnelDamageType] = 10;
$ScorePoints[$LaserDamageType] = 0;
$ScorePoints[$MortarDamageType] = 15;
$ScorePoints[$BlasterDamageType] = 0;
$ScorePoints[$ElectricityDamageType] = 0;
$ScorePoints[$CrushDamageType] = 0;
$ScorePoints[$DebrisDamageType] = 0;
$ScorePoints[$MissileDamageType] = 5;
$ScorePoints[$MineDamageType] = 3;
$ScorePoints[$FighterGunDamageType] = 5;
$ScorePoints[$KamikaziDamageType] = 10;
$ScorePoints[$ElectricDamageType] = 10;
$ScorePoints[$RocketDamageType] = 5;
$ScorePoints[$PlasmaCannonDamageType] = 20;
$ScorePoints[$FlameDamageType] = 5;
$ScorePoints[$SatchelDamageType] = 15;
$ScorePoints[$BombDamageType] = 10;
$ScorePoints[$AdminKillDamageType] = 0;
$ScorePoints[$SurpriseDamageType] = 15;
$ScorePoints[$BulletDmgType1] = 10;
$ScorePoints[$BulletDmgType2] = 15;
$ScorePoints[$BulletDmgType3] = 10;
$ScorePoints[$BulletDmgType4] = 10;
$ScorePoints[$BulletDmgType5] = 5;
$ScorePoints[$BulletDmgType6] = 10;
$ScorePoints[$BulletDmgType7] = 10;
$ScorePoints[$BulletDmgType8] = 10;
$ScorePoints[$BulletDmgType9] = 3;
$ScorePoints[$BulletDmgType10] = 10;
$ScorePoints[$BulletDmgType11] = 2;
$ScorePoints[$BulletDmgType12] = 10;
$ScorePoints[$BulletDmgType13] = 5;
$ScorePoints[$BulletDmgType14] = 8;
$ScorePoints[$BulletDmgType15] = 15;
$ScorePoints[$BulletDmgType16] = 20;
$ScorePoints[$BulletDmgType17] = 10;
$ScorePoints[$BulletDmgType18] = 20;
$ScorePoints[$BulletDmgType19] = 10;
$ScorePoints[$BulletDmgType20] = 20;
$ScorePoints[$BulletDmgType21] = 2;
$ScorePoints[$StrikeDmgType] = 10;
