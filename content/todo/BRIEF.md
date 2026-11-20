# Write-up brief for mod variants

Wiki root: C:\Users\c\TribeWiki\tribes-wiki

This is a static wiki for Starsiege: Tribes (1998) mods. Stats are rendered automatically from each mod's scripts, so your job is prose about *behavior*, grounded strictly in script code.

## Inputs
- `sources/<mod-id>/` — the mod's TorqueScript `.cs` files (it overrides same-named files in `sources/base/`, stock Tribes 1.11). Many files are minified onto very long lines: use grep -o with bounded context (e.g. `grep -o -i '.\{0,200\}Name::onUse.\{0,800\}'`), or Python run as `python -I script.py` from a script file — never `python -` with stdin (blocked). Don't read whole minified files.
- The parent mod: each mod's `base=` in the `MODS` list at the top of `build.py` (e.g. UR3 Mayhem's parent is `ur2`; some Ultra builds compare to `base`, stock Tribes). Its scripts are `sources/<parent>/`, and its write-ups (if already written) `content/<parent>.json`. Where this file says "Classic", read "the parent mod". The Renegades variants all derive from Renegades Classic 1.1c (`sources/renegades-classic/`, `content/renegades-classic.json`).
- Ultra Renegades scale: many UR/VX builds use their own damage and health scale (weapon damage of 1–280, armor maxDamage to match) and their own shop headings ("TWeapons", "LTurretsVX", "WPsionics"). That's by design; describe relative strength, not "huge numbers".
- Annihilation family: `sources/annihilation/` is the late, community-maintained Total Annihilation release (it has 2009-era patches); UltrAnnihilation (2002) and Apteryx (2003, on Annihilation 2.1) were built on earlier versions, so a difference from it is not necessarily a change their authors made. Say "Unlike this wiki's Total Annihilation release, ..." rather than claiming the mod changed it. Armor items are named `iarmor<Name>` and their PlayerData `armorm<Name>`/`armorf<Name>` (or `armor<Name>` for heavies); `Armor::add()` in armor.cs creates them. Tribal God compares to stock Tribes (`base`). Gender-neutral wording: "the wearer", "the player", "their".
- Shifter family: `shifter` (Emo1313's 09-28-2000 release) is the root for SG1, Xtreme and v1G; v1G is the parent of 2K5; Ultra Shifter Duel's parent is Shifter; the 1999 `shifter-bots` is the parent of STAR Mod. Parents' write-ups may be written in parallel with yours, so compare against the parent's `sources/` directly, not its `content/` JSON. Shifter reuses some Renegades datablock names (DragArmor is the DreadNaught here); describe the Shifter item, not the Renegades one. Some mods' own entry scripts (e.g. `Shifter2k5.cs`, `UltraShifterDuel.cs`) are port notes from the asset store's maintainers; trust the game scripts over their comments.
- `content/todo/<mod-id>.txt` — the items you must write: datablock name, display name, and why (new / renamed / scripts = its item functions differ from Classic / stats).
- `python changed.py <mod-id>` (run from wiki root) regenerates that list. `python tscript.py` self-checks the parser.

## Output: `content/<mod-id>.json`
```
{
  "mod": {"overview": "2-4 sentences: what this mod is and how it plays differently from Renegades Classic.",
          "notes": ["mod-wide mechanics/differences from Classic, short facts, numbers where code gives them"]},
  "items": {"<DatablockName>": {"summary": "1-3 sentences: what it is and does in play.",
                                "notes": ["specific mechanics from code"],
                                "source": "file.cs function(s) used"}}
}
```
Rules:
- Cover every item in the to-do list. Items not listed reuse Classic's write-up automatically; don't write them.
- For items that exist in Classic, read both versions' functions and say concretely what changed (e.g. "Unlike Classic, ..."). You may adapt Classic's text, but verify each fact against this mod's code.
- Read `::onUse`, `::onDeploy`, `::deployShape`, `::onMount`, `::onActivate`/`onDeactivate`, `::onFire`, collision/damage handlers; `newObject(...)`'s 3rd argument is the datablock deployed/thrown. Grenade/Mine/Beacon often switch on armor class; list what each class gets.
- Plain text only (no markdown/HTML). No invented lore or guessing: if code doesn't show it, write "Behavior not determined from scripts." Don't restate raw stats (damage, speed, price) unless needed for context — they're rendered automatically.
- Don't run build.py (other writers share the output folder). Validate with `python -I -c "import json,sys;json.load(open(sys.argv[1],encoding='utf-8'))" content/<mod-id>.json` and check every to-do key is present.
- Report back: items written per mod, items you couldn't determine, and any notable script bugs you found (state them in notes as facts about the code).
