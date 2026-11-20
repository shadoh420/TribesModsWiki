# Tribes Mod Wiki
https://shadoh420.github.io/TribesModsWiki/

Static wiki for Starsiege: Tribes and its mods. Stats come from each mod's scripts; write-ups live in `content/`.

```
python build.py              # writes site/
python -m http.server 8765 -d site   # browse http://localhost:8765
```

## Layout
- `sources/<mod>/` — the mod's `.cs` scripts. `sources/base/` is stock Tribes 1.11 (`base/scripts.vol` extracted).
- `content/<mod>.json` — overview, mechanics notes and per-item write-ups, keyed by datablock name.
- `content/catalog.json` — the full mod list on the home page (metadata only, from the earlier Gemini index).
- `tscript.py` — parses datablocks, `$Global[...]` tables and functions. `python tscript.py` runs its self-check.
- `build.py` — builds every page. Mods are listed in `MODS` at the top.

## Adding a mod
1. Copy its `scripts/*.cs` into `sources/<id>/`.
2. Add an entry to `MODS` with `dirs=['base', '<id>']` (files override base by name, like `-mod` does) and `base='base'` to get "Changes from Base Tribes" tables.
3. Optionally add `content/<id>.json`; `build.py` prints which items still lack a write-up.
   `python changed.py <id>` lists the items that differ from the parent (only those need their own text).

Per-mod options in `MODS`: `base` (parent to compare against and inherit write-ups from), `group` (sidebar section),
`skip` (files a mod execs only as a runtime swap, e.g. RenegadesMod's Elite mode or VX5's HARD difficulty), and
`entry` (server script name when a mod renames `server.cs`, e.g. Ultra Warfare).

The parser follows `exec()` from the server script (including `"Folder\\file.cs"` paths; flatten such mods into
`sources/<id>/`, as done for Tribal God), expands table-filling helpers like `PopulateItemMax(...)` even when
defined in another file, emulates Annihilation's `Armor::add(...)`, and applies top-level `Block.field = value;`
overrides in load order.

## Sources
- Base: `C:\Program Files (x86)\Dynamix\TRIBES11\base\scripts.vol`
- Mods: https://github.com/jcmolnar/Tribes-Asset-Store (`packs/<id>/Mods/<Name>/scripts`)
- More mods: Krogoth's File Library, https://library.theexiled.pwnageservers.com/category.php?id=2 (used with Krogoth's permission).
  Added from it: dune, ravenstorm, ultra-ux, ur-2004, ultra-vx3, shifter-k, foundation, nappy-builder, nappy-c-builder,
  hybrid-gold, annihilation-3, vengeance, tsc. Only scripts that differ from base are kept; annihilation-3 and vengeance
  keep their `Armor/`, `Weapon/`... folders because their `ExecFiles(Folder)` loader reads them by folder.
  Alternate builds of existing mods (156, e.g. dated Shifter and Annihilation builds) are in the "... builds" groups at the
  end of `MODS`, each compared against the previous build of its family.
  Weapons without `projectileType` are resolved from `$WeapProjectile[weapon]` (DUNE) or the first
  `Projectile::spawnProjectile("X", ...)` in the image's `onFire` (Annihilation 3, Vengeance). `tscript.py` also expands
  datablocks a mod builds as strings and `eval()`s (Vengeance's armors).
