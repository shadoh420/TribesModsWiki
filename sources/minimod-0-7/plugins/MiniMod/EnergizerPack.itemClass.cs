// This is a MiniMod Plugin.
// This plugin is the Energizer Pack. Created/Ported by Dewy.

// Classes are as Follows...

// class 0  = general stuff (ie. repair kits, flares, anything that most armors should carry.)
// class 1  = recon stuff
// class 2  = sniper stuff (weapons and ammo)
// class 3  = protective stuff (ie. shields, etc.)
// class 4  = light weapons
// class 5  = medium weapons
// class 6  = heavy weapons
// class 7  = assault weapons
// class 8  = defence weapons
// class 9  = light deployables
// class 10 = medium deployables
// class 11 = heavy deployables (ie. big sensors)
// class 12 = heavy defence deployabes (ie. big turrets)
// class 13 = special deployables (ie. air bases, etc.)[Engineer stuff]
// class 14 = support stuff (ie. Inv. Stat's, Ammo Stat's, bulk ammo, etc.)
// class 15 = repair stuff (ie. repair packs, etc.)
// class 16 = sensor stuff
// class 17 = heavy-duty sensor stuff
// class 18 = general packs
// class 19 = special packs (you may wish to manually set these, instead)
// class 20 = command packs (ie. command PDA)
// class 21 = vehicle packs
// class 22 = sniper   armor specific
// class 23 = flight   armor specific
// class 24 = light    armor specific
// class 24 = engineer armor specific
// class 25 = burster  armor specific
// class 26 = arbitor  armor specific
// class 27 = medium   armor specific
// class 28 = dragoon  armor specific
// class 29 = heavy    armor specific

// Classes 60-79 are slated for Vehicle DamageFactors
// class 60 = Scout Vehicle   (ONLY used when setting damage types)
// class 61 = LAPC  Vehicle   (ONLY used when setting damage types)
// class 62 = HAPC  Vehicle   (ONLY used when setting damage types)
// class 63 = Cloaked Scouts  (ONLY used when setting damage types)
// class 64 = Cloaked LAPCs   (ONLY used when setting damage types)
// class 65 = Cloaked HAPCs   (ONLY used when setting damage types)

// Classes 80-99 are slated for Armor DamageFactors
// class 80 = Light  Armor  DamageScale
// class 81 = Medium Armor  DamageScale
// class 82 = Heavy  Armor  DamageScale

// If you need to use a new class, E-Mail me and I'll add it to the list.
// My E-Mail addy is: Dewy@planetstarsiege.com
// It's no big deal just holler if your gonna an unknown class so I can make it known.

// Now lets put em' to use. :)

$ItemClass = 18;
$Item = EnergizerPack;
$qty = 1;
MiniMod::Build::Classes();
