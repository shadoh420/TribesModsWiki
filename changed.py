"""List items a variant adds or changes relative to its parent mod: python changed.py <mod-id> ...
Those need their own write-up in content/<mod-id>.json; the rest reuse the parent's."""
import sys
from build import Mod, MODS, changed

by = {m['id']: m for m in MODS}
for mid in sys.argv[1:]:
    M = Mod(by[mid]); P = Mod(by[by[mid]['base']])
    c = changed(M, P)
    print(f'{mid}: {len(c)} of {len(M.items)} need write-ups')
    for k, v in c.items(): print(f'  {k} ({M.items[k]["title"]}): {v}')
