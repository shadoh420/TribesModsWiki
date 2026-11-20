"""Minimal Tribes 1 script parser: datablocks and $Global[...] = value assignments."""
import fnmatch, re, os

def strip_comments(s):
    out, i, n, q = [], 0, len(s), None
    while i < n:
        c = s[i]
        if q:
            out.append(c)
            if c == '\\' and i + 1 < n:
                out.append(s[i + 1]); i += 2; continue
            if c == q: q = None
        elif c in '"\'':
            q = c; out.append(c)
        elif s.startswith('//', i):
            j = s.find('\n', i)
            i = n if j < 0 else j
            continue
        else:
            out.append(c)
        i += 1
    return ''.join(out)

BLOCK = re.compile(r'\b(\w+Data)\s+(\w+)\s*\{')
V = r'("(?:[^"\\]|\\.)*"|[^;]*)'
FIELD = re.compile(r'(\w+(?:\[\s*\w+\s*\])?)\s*=\s*' + V + ';')
GLOBAL = re.compile(r'\$(\w+(?:::\w+)*)\s*\[([^\]]*)\]\s*=\s*' + V + ';')
SCALAR = re.compile(r'\$(\w+(?:::\w+)*)\s*=\s*' + V + ';')

def _val(v):
    v = v.strip()
    if len(v) >= 2 and v[0] == v[-1] == '"': return v[1:-1]
    try: return float(v) if '.' in v or 'e' in v.lower() else int(v)
    except ValueError: return v

def _body(s, i):
    depth, j = 1, i
    while j < len(s) and depth:
        depth += {'{': 1, '}': -1}.get(s[j], 0)
        j += 1
    return s[i:j - 1], j

ARMOR_ADD = re.compile(r'(?<!function )\bArmor::add\(\s*"?(\w+)"?\s*,\s*"([^"]*)"\s*,\s*([\d.]+)\s*\)\s*;', re.I)

def _armor_add(s):
    """Annihilation's Armor::add(name, desc, price) evals an ItemData iarmor<name> and fills $ArmorType
    (armorm/armorf<name> pair, or a single armor<name> for heavies)."""
    out = []
    for name, desc, price in ARMOR_ADD.findall(_outside_functions(s)):
        m, f = (f'armorm{name}', f'armorf{name}') if re.search(rf'\bPlayerData\s+armorm{name}\b', s, re.I) else (f'armor{name}',) * 2
        out.append(f'ItemData iarmor{name} {{ heading = "aArmor"; description = "{desc}"; className = Armor; price = {price}; }};\n'
                   f'$ArmorType[Male, iarmor{name}] = {m}; $ArmorType[Female, iarmor{name}] = {f};\n')
    return ''.join(out)

def _eval_blocks(s):
    """Vengeance builds datablocks as strings and eval()s them: defineLightArmor("", 1, 1) concatenates
    "PlayerData armormNecro"@%tag@" { ... maxForwardSpeed = "@13*%mult@"; ... };". Expand each top-level call with its
    literal arguments and return the datablock text."""
    # ponytail: stitches every string literal in the body, so if/else branches both land in the block (later field wins)
    out, top = [], _outside_functions(s)
    for m in re.finditer(r'function\s+(\w+)\s*\(([^)]*)\)\s*\{', s):
        body = _body(s, m.end())[0]
        if 'eval(' not in body or not re.search(r'"\s*\w+Data\s+\w+', body): continue
        params = [p.strip() for p in m.group(2).split(',') if p.strip()]
        for call in re.finditer(r'(?<!function )\b' + m.group(1) + r'\s*\(([^;]*)\)\s*;', top):
            args = dict(zip(params, (a.strip().strip('"') for a in call.group(1).split(','))))
            def expr(e):
                e = re.sub(r'%\w+', lambda p: args.get(p.group(0), ''), e).strip()
                if re.fullmatch(r'[\d\s.+\-*/()]+', e):
                    try: v = eval(e); return str(int(v)) if float(v).is_integer() else str(v)
                    except Exception: pass
                return e.strip('"')
            parts = [t.group(1).replace('\\"', '"') if t.group(1) is not None else expr(t.group(2))
                     for t in re.finditer(r'"((?:[^"\\]|\\.)*)"|@([^@";{}]*[^\s@";{}][^@";{}]*)@', body)]
            out.append(''.join(parts) + '\n')
    return ''.join(out)

def parse_text(s, macros=None):
    s = strip_comments(s)
    s += _armor_add(s) + _eval_blocks(s)
    blocks, rest, pos = {}, [], 0
    for m in BLOCK.finditer(s):
        if m.start() < pos: continue
        body, end = _body(s, m.end())
        rest.append(s[pos:m.start()])
        pos = end
        flat = re.sub(r'\{[^{}]*\}', lambda b: b.group(0).replace(';', ','), body)
        fields = {k.strip(): _val(v) for k, v in FIELD.findall(flat)}
        blocks[m.group(2)] = {'_type': m.group(1), '_name': m.group(2), **fields}
    rest.append(s[pos:])
    glue = ''.join(rest)
    glue += _expand_table_macros(glue, macros)
    globs = {}
    for name, key, v in GLOBAL.findall(glue):
        key = re.sub(r'\s+', '', key).strip('"')
        if '%' not in key: globs.setdefault(name, {})[key] = _val(v)
    scal = {name: _val(v) for name, v in SCALAR.findall(glue)}
    funcs = {}
    for m in FUNC.finditer(glue):
        j = glue.find('{', m.end())
        if j < 0: continue
        funcs[(m.group(1).lower(), m.group(2).lower())] = _body(glue, j + 1)[0]
    # top-level "Block.field = value;" statements patch datablocks after definition (VX5 difficulty files)
    globs['.fields'] = {f'{b}.{f}': _val(v) for b, f, v in DOTSET.findall(_outside_functions(glue))}
    return blocks, globs, scal, funcs

DOTSET = re.compile(r'(?<![%$\w.])([A-Za-z_]\w*)\.(\w+)\s*=\s*' + V + ';')

def _outside_functions(s):
    out, pos = [], 0
    for m in re.finditer(r'function\s+[\w:]+\s*\([^)]*\)\s*\{', s):
        if m.start() < pos: continue
        out.append(s[pos:m.start()]); pos = _body(s, m.end())[1]
    return ''.join(out) + s[pos:]

FUNC = re.compile(r'function\s+(\w+)::(\w+)\s*\(')

def table_macros(s):
    """Helper functions whose body only fills global tables from their parameters: {name: (params, body)}."""
    out = {}
    for m in re.finditer(r'function\s+(\w+)\s*\(([^)]*)\)\s*\{', s):
        body = _body(s, m.end())[0]
        if re.fullmatch(r'(\s*\$\w+\s*\[[^\]]*\]\s*=\s*%\w+\s*;)+\s*', body):
            out[m.group(1)] = ([p.strip() for p in m.group(2).split(',')], body)
    return out

def _expand_table_macros(s, macros=None):
    """Inline calls to helper functions that only fill global tables, e.g. Ren2K's
    PopulateItemMax(Blaster, 1, 1, ...) -> $ItemMax[dmarmor, Blaster] = 1; ...
    macros: helpers defined in other files (Tribal God defines ItemMax() in server[TG].cs, calls it everywhere)."""
    out = []
    for name, (params, body) in {**(macros or {}), **table_macros(s)}.items():
        for call in re.finditer(r'(?<!function )\b' + name + r'\s*\(([^;]*)\)\s*;', s):
            args = dict(zip(params, (a.strip() for a in call.group(1).split(','))))
            out.append(re.sub(r'%\w+', lambda p: args.get(p.group(0), p.group(0)), body))
    return ''.join(out)

def exec_order(dirs, skip=(), entry='server'):
    """Script files in the order the server script execs them, depth-first; a later dir overrides same-named files.
    skip: files exec'd only as runtime swaps (e.g. RenegadesMod's Elite mode), not part of the default game.
    entry: the server script's name when a mod renames it (Ultra Warfare: Ultra_Warfare.cs)."""
    files = {}
    for d in dirs:
        by_depth, d_files = [], {}
        for root, _, fs in os.walk(d):
            for f in fs:
                if not f.lower().endswith('.cs'): continue
                full = os.path.join(root, f)
                rel = os.path.relpath(full, d).replace('\\', '/').lower()
                by_depth.append((rel.count('/'), rel, f.lower(), full))
        for _, rel, base, full in sorted(by_depth):
            d_files[rel] = full
            if rel.startswith('scripts/'):
                d_files[rel[8:]] = full
            d_files.setdefault(base, full)
        files.update(d_files)
    skip = {s.lower() + '.cs' for s in skip}
    seen = []
    def resolve(raw):
        p = raw.replace('\\', '/').strip().lower()
        if not p.endswith('.cs'): p += '.cs'
        if p in files: return p
        if p.startswith('scripts/') and p[8:] in files: return p[8:]
        base = p.rsplit('/', 1)[-1]
        return base if base in files else None
    def visit(f):
        f = resolve(f) if f not in files else f
        if not f or f in skip or f in seen: return
        if os.path.basename(files[f]).lower() in skip: return
        seen.append(f)
        txt = strip_comments(open(files[f], encoding='latin-1').read())
        # Follow exec("..."), exec(name), exec("Folder\\file.cs"), and NovaMorpher's exec(Server::detVerAp("..."))
        for n in re.findall(r'exec\s*\(\s*(?:Server::detVerAp\s*\(\s*)?"?([^"()\s]+)"?\s*\)', txt, re.I):
            n = n.strip()
            if not n or any(c in n for c in ('$', '%', '@')): continue
            visit(n)
        # Dynamic wildcard loaders: ShifterX File::findFirst("data_*.cs"), MiniMod/rb2 plugins\*.Item.cs & MiniMod::Load(...)
        pats = [pat for _, pat in re.findall(r'(%[A-Za-z_]\w*)\s*=\s*File::findFirst\(\s*"([^"]*?\*[^"]*?\.cs)"\s*\)[\s\S]{0,400}?exec\s*\(\s*\1\s*\)', txt, re.I)]
        for arg in re.findall(r'MiniMod::Load\s*\(\s*"([^"]+\.cs)"\s*\)', txt, re.I):
            if '*' in arg: pats.append(arg)
            else: visit(arg)
        # Annihilation 3 / Vengeance: ExecFiles(Weapon) runs Weapon/Weapon.cs, then the folder's other files alphabetically
        for folder in re.findall(r'^\s*ExecFiles\s*\(\s*"?(\w+)"?\s*\)', txt, re.I | re.M):
            visit(f'{folder}/{folder}.cs'.lower())
            pats.append(folder + '/*.cs')
        for pat in pats:
            pat_l = re.sub(r'[\\/]+', '/', pat).lower()
            prefix, pbase = pat_l.rsplit('/', 1) if '/' in pat_l else ('', pat_l)
            for k in sorted(files):
                if prefix:
                    if k.startswith(prefix + '/') and fnmatch.fnmatch(k.rsplit('/', 1)[-1], pbase):
                        visit(k)
                elif '/' not in k and fnmatch.fnmatch(k, pbase):
                    visit(k)
    visit('game.cs')  # ponytail: game-type globals ($RemoteInvEnergy etc.) feed datablock prices; some mods only exec it from mission scripts
    entry = entry.lower() + '.cs'
    visit(entry)
    if entry == 'server.cs' and 'moddatablocks.cs' in files:
        visit('moddatablocks.cs')
    if entry in seen: seen.remove(entry)
    return [files[f] for f in seen]

def parse_mod(dirs, skip=(), entry='server'):
    blocks, globs, scal, funcs = {}, {}, {}, {}
    texts = [(p, strip_comments(open(p, encoding='latin-1').read())) for p in exec_order(dirs, skip, entry)]
    macros = {}
    for _, t in texts: macros.update(table_macros(t))
    for p, t in texts:
        b, g, s, fn = parse_text(t, macros)
        for k, v in b.items(): v['_file'] = os.path.basename(p); blocks[k] = v
        lower = {k.lower(): v for k, v in blocks.items()}
        for key, val in g.pop('.fields', {}).items():
            name, field = key.split('.', 1)
            if name.lower() in lower: lower[name.lower()][field] = val
        for k, v in g.items(): globs.setdefault(k, {}).update(v)
        scal.update(s); funcs.update(fn)
    return blocks, globs, scal, funcs

if __name__ == '__main__':
    b, g, s, f = parse_text('''// c
ItemImageData X { a = 1; c = { 1, 2, 3 }; d = "x;y"; }; $ItemMax[larmor, Blaster] = 1;
PlayerData p { maxDamage = 0.66; }; function X::onUse(%a) { if (1) { newObject("", Mine, Handgrenade); } }''')
    assert b['X']['a'] == 1 and b['X']['d'] == 'x;y' and b['p']['maxDamage'] == 0.66, b
    assert g['ItemMax']['larmor,Blaster'] == 1, g
    assert 'Handgrenade' in f[('x', 'onuse')], f
    _, g, _, _ = parse_text('function Pop(%item, %a, %b) { $ItemMax[larmor, %item] = %a; $ItemMax[harmor, %item] = %b; }\nPop(Disc, 1, 0);')
    assert g['ItemMax'] == {'larmor,Disc': 1, 'harmor,Disc': 0}, g
    _, g, _, _ = parse_text('Pop(Disc, 1, 0);', table_macros('function Pop(%item, %a, %b) { $ItemMax[larmor, %item] = %a; $ItemMax[harmor, %item] = %b; }'))
    assert g['ItemMax'] == {'larmor,Disc': 1, 'harmor,Disc': 0}, g
    _, g, _, _ = parse_text('Bolt.damageValue = 280;\nfunction F() { Bolt.damageValue = 9; }\n%p.x = 1;')
    assert g['.fields'] == {'Bolt.damageValue': 280}, g
    b, g, _, _ = parse_text('PlayerData armormAngel { maxDamage = 1; };\nArmor::add("Angel", "Rogue Angel", 175);\nArmor::add("Titan", "Titan", 400);')
    assert b['iarmorAngel']['price'] == 175 and g['ArmorType']['Female,iarmorAngel'] == 'armorfAngel', g
    assert g['ArmorType']['Male,iarmorTitan'] == 'armorTitan', g
    b, _, _, _ = parse_text('function defL(%tag,%mult)\n{\n %d = "PlayerData armorm"@%tag@"X { maxDamage = 0.56;"@\n'
                            '  " maxForwardSpeed = "@13*%mult@"; groundForce ="@ 40 * 9.0@";";\n %d = %d @ "};";\n eval(%d);\n}\n'
                            'defL("",1);\ndefL("Fast",1.25);')
    assert b['armormX']['maxForwardSpeed'] == 13 and b['armormFastX']['maxForwardSpeed'] == 16.25 and b['armormX']['groundForce'] == 360, b
    print('ok')
